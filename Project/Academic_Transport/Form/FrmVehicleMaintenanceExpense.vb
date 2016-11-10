Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmVehicleMaintenanceExpense
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S. No."
    Protected Const Col1Expense As String = "Expense"
    Protected Const Col1ExpenseType As String = "Expense Type"
    Protected Const Col1ExpenseDescription As String = "Description"
    Protected Const Col1Qty As String = "Qty."
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Vehicle As String = "Vehicle"
    Protected Const Col1MeterReading As String = "Meter Reading"
    Protected Const Col1NextAfterKm As String = "Next After Km."
    Protected Const Col1NextMeterReading As String = "Next Reading."
    Protected Const Col1NextAfterDays As String = "Next After Days"
    Protected Const Col1NextDate As String = "Next Date"

    'Header Total From AgStructure
    Protected Const AgCalc_TotalLineAmount As String = "Gross Amount"
    Protected Const AgCalc_TotalLineAddition As String = "Addition"
    Protected Const AgCalc_TotalLineDeduction As String = "Deduction"
    Protected Const AgCalc_TotalLineNetAmount As String = "Net Amount"
    Protected Const AgCalc_NetSubTotal As String = "Sub Total"

    Protected WithEvents TxtPartyDocumentDate As AgControls.AgTextBox
    Protected WithEvents LblPartyDocumentDate As System.Windows.Forms.Label
    Protected WithEvents TxtPartyDocumentNo As AgControls.AgTextBox
    Protected WithEvents LblPartyDocumentNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents LblPartyReq As System.Windows.Forms.Label
    Protected WithEvents TxtParty As AgControls.AgTextBox
    Protected WithEvents LblParty As System.Windows.Forms.Label
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblValNetAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextNetAmount As System.Windows.Forms.Label

    Dim _EntryMode As String = "Browse"
    Dim _StrVehicleCode As String = "", _StrExpenseCode As String = ""
    Dim _StrDueOnDate$ = ""
    Dim _DblDueOnMeterReading As Double = 0


    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    
    Public Property VehicleCode() As String
        Get
            VehicleCode = _StrVehicleCode
        End Get
        Set(ByVal value As String)
            _StrVehicleCode = value
        End Set
    End Property

    Public Property ExpenseCode() As String
        Get
            ExpenseCode = _StrExpenseCode
        End Get
        Set(ByVal value As String)
            _StrExpenseCode = value
        End Set
    End Property


    Public Property DueOnDate() As String
        Get
            DueOnDate = _StrDueOnDate
        End Get
        Set(ByVal value As String)
            _StrDueOnDate = value
        End Set
    End Property

    Public Property DueOnMeterReading() As Double
        Get
            DueOnMeterReading = _DblDueOnMeterReading
        End Get
        Set(ByVal value As Double)
            _DblDueOnMeterReading = value
        End Set
    End Property

    Public Class HelpDataSet
        Public Shared Party As DataSet = Nothing
        Public Shared Expense As DataSet = Nothing
        Public Shared Vehicle As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
    End Class

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalQty = New System.Windows.Forms.Label
        Me.LblValNetAmount = New System.Windows.Forms.Label
        Me.LblTextNetAmount = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtPartyDocumentDate = New AgControls.AgTextBox
        Me.LblPartyDocumentDate = New System.Windows.Forms.Label
        Me.TxtPartyDocumentNo = New AgControls.AgTextBox
        Me.LblPartyDocumentNo = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblPartyReq = New System.Windows.Forms.Label
        Me.TxtParty = New AgControls.AgTextBox
        Me.LblParty = New System.Windows.Forms.Label
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
        Me.GroupBox1.Size = New System.Drawing.Size(1022, 4)
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
        Me.LblV_No.Tag = ""
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
        Me.LblV_Date.Tag = ""
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
        Me.LblV_Type.Tag = ""
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
        Me.TabControl1.Size = New System.Drawing.Size(992, 139)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtPartyDocumentDate)
        Me.TP1.Controls.Add(Me.LblPartyDocumentDate)
        Me.TP1.Controls.Add(Me.TxtPartyDocumentNo)
        Me.TP1.Controls.Add(Me.LblPartyDocumentNo)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.LblPartyReq)
        Me.TP1.Controls.Add(Me.TxtParty)
        Me.TP1.Controls.Add(Me.LblParty)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(984, 113)
        Me.TP1.Text = "Tp1"
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyDocumentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyDocumentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyDocumentDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyDocumentDate, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1004, 41)
        Me.Topctrl1.TabIndex = 3
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblValTotalQty)
        Me.Panel1.Controls.Add(Me.LblTextTotalQty)
        Me.Panel1.Controls.Add(Me.LblValNetAmount)
        Me.Panel1.Controls.Add(Me.LblTextNetAmount)
        Me.Panel1.Location = New System.Drawing.Point(0, 377)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(707, 3)
        Me.LblValTotalQty.Name = "LblValTotalQty"
        Me.LblValTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQty.TabIndex = 672
        Me.LblValTotalQty.Text = "."
        Me.LblValTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalQty
        '
        Me.LblTextTotalQty.AutoSize = True
        Me.LblTextTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalQty.Location = New System.Drawing.Point(618, 3)
        Me.LblTextTotalQty.Name = "LblTextTotalQty"
        Me.LblTextTotalQty.Size = New System.Drawing.Size(89, 16)
        Me.LblTextTotalQty.TabIndex = 671
        Me.LblTextTotalQty.Text = "Total Qty.    :"
        '
        'LblValNetAmount
        '
        Me.LblValNetAmount.AutoSize = True
        Me.LblValNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValNetAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValNetAmount.Location = New System.Drawing.Point(952, 3)
        Me.LblValNetAmount.Name = "LblValNetAmount"
        Me.LblValNetAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblValNetAmount.TabIndex = 670
        Me.LblValNetAmount.Text = "."
        Me.LblValNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextNetAmount
        '
        Me.LblTextNetAmount.AutoSize = True
        Me.LblTextNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextNetAmount.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextNetAmount.Location = New System.Drawing.Point(861, 4)
        Me.LblTextNetAmount.Name = "LblTextNetAmount"
        Me.LblTextNetAmount.Size = New System.Drawing.Size(93, 16)
        Me.LblTextNetAmount.TabIndex = 669
        Me.LblTextNetAmount.Text = "Net Payable :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(0, 207)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(1000, 170)
        Me.Pnl1.TabIndex = 1
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(244, 407)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(126, 144)
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
        Me.TxtStructure.Location = New System.Drawing.Point(876, 48)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(100, 18)
        Me.TxtStructure.TabIndex = 14
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(809, 48)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
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
        Me.LblReferenceNo.Size = New System.Drawing.Size(74, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Manual No."
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
        Me.LinkLabel1.Size = New System.Drawing.Size(185, 20)
        Me.LinkLabel1.TabIndex = 738
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Maintinance / Expense Detail:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(403, 408)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(295, 140)
        Me.PnlCShowGrid2.TabIndex = 751
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(704, 408)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(295, 140)
        Me.PnlCShowGrid.TabIndex = 2
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
        'TxtPartyDocumentDate
        '
        Me.TxtPartyDocumentDate.AgMandatory = False
        Me.TxtPartyDocumentDate.AgMasterHelp = False
        Me.TxtPartyDocumentDate.AgNumberLeftPlaces = 0
        Me.TxtPartyDocumentDate.AgNumberNegetiveAllow = False
        Me.TxtPartyDocumentDate.AgNumberRightPlaces = 0
        Me.TxtPartyDocumentDate.AgPickFromLastValue = False
        Me.TxtPartyDocumentDate.AgRowFilter = ""
        Me.TxtPartyDocumentDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtPartyDocumentDate.AgSelectedValue = Nothing
        Me.TxtPartyDocumentDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyDocumentDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPartyDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyDocumentDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyDocumentDate.Location = New System.Drawing.Point(876, 8)
        Me.TxtPartyDocumentDate.MaxLength = 35
        Me.TxtPartyDocumentDate.Name = "TxtPartyDocumentDate"
        Me.TxtPartyDocumentDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtPartyDocumentDate.TabIndex = 7
        '
        'LblPartyDocumentDate
        '
        Me.LblPartyDocumentDate.AutoSize = True
        Me.LblPartyDocumentDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyDocumentDate.Location = New System.Drawing.Point(759, 10)
        Me.LblPartyDocumentDate.Name = "LblPartyDocumentDate"
        Me.LblPartyDocumentDate.Size = New System.Drawing.Size(93, 15)
        Me.LblPartyDocumentDate.TabIndex = 775
        Me.LblPartyDocumentDate.Text = "Document Date"
        '
        'TxtPartyDocumentNo
        '
        Me.TxtPartyDocumentNo.AgMandatory = False
        Me.TxtPartyDocumentNo.AgMasterHelp = False
        Me.TxtPartyDocumentNo.AgNumberLeftPlaces = 0
        Me.TxtPartyDocumentNo.AgNumberNegetiveAllow = False
        Me.TxtPartyDocumentNo.AgNumberRightPlaces = 0
        Me.TxtPartyDocumentNo.AgPickFromLastValue = False
        Me.TxtPartyDocumentNo.AgRowFilter = ""
        Me.TxtPartyDocumentNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtPartyDocumentNo.AgSelectedValue = Nothing
        Me.TxtPartyDocumentNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyDocumentNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyDocumentNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyDocumentNo.Location = New System.Drawing.Point(599, 8)
        Me.TxtPartyDocumentNo.MaxLength = 35
        Me.TxtPartyDocumentNo.Name = "TxtPartyDocumentNo"
        Me.TxtPartyDocumentNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtPartyDocumentNo.TabIndex = 6
        '
        'LblPartyDocumentNo
        '
        Me.LblPartyDocumentNo.AutoSize = True
        Me.LblPartyDocumentNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyDocumentNo.Location = New System.Drawing.Point(512, 10)
        Me.LblPartyDocumentNo.Name = "LblPartyDocumentNo"
        Me.LblPartyDocumentNo.Size = New System.Drawing.Size(86, 15)
        Me.LblPartyDocumentNo.TabIndex = 774
        Me.LblPartyDocumentNo.Text = "Document No."
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
        Me.TxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(599, 28)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemark.TabIndex = 8
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(512, 29)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 767
        Me.LblRemark.Text = "Remark"
        '
        'LblPartyReq
        '
        Me.LblPartyReq.AutoSize = True
        Me.LblPartyReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPartyReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPartyReq.Location = New System.Drawing.Point(111, 57)
        Me.LblPartyReq.Name = "LblPartyReq"
        Me.LblPartyReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPartyReq.TabIndex = 773
        Me.LblPartyReq.Text = "Ä"
        '
        'TxtParty
        '
        Me.TxtParty.AgMandatory = True
        Me.TxtParty.AgMasterHelp = False
        Me.TxtParty.AgNumberLeftPlaces = 0
        Me.TxtParty.AgNumberNegetiveAllow = False
        Me.TxtParty.AgNumberRightPlaces = 0
        Me.TxtParty.AgPickFromLastValue = False
        Me.TxtParty.AgRowFilter = ""
        Me.TxtParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtParty.AgSelectedValue = Nothing
        Me.TxtParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParty.Location = New System.Drawing.Point(127, 48)
        Me.TxtParty.MaxLength = 123
        Me.TxtParty.Name = "TxtParty"
        Me.TxtParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtParty.TabIndex = 4
        '
        'LblParty
        '
        Me.LblParty.AutoSize = True
        Me.LblParty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParty.Location = New System.Drawing.Point(15, 50)
        Me.LblParty.Name = "LblParty"
        Me.LblParty.Size = New System.Drawing.Size(71, 15)
        Me.LblParty.TabIndex = 772
        Me.LblParty.Text = "Party Name"
        '
        'TempGr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1004, 599)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempGr"
        Me.Text = "Template Goods Receive"
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
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
#End Region

    Private Sub FrmVehicleMaintenanceExpense_BaseEvent_Approve_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Approve_PostTrans
        Try
            If VehicleCode.Trim <> "" Then
                Me.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Tp_MaintenanceExpenseEntry"
        LogTableName = "Tp_MaintenanceExpenseEntry_Log"
        MainLineTableCsv = "Tp_MaintenanceExpenseEntry1,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "Tp_MaintenanceExpenseEntry1_Log,Structure_TransFooter_Log,Structure_TransLine_Log"

        LblV_Type.Text = "Expense Type"
        LblV_Date.Text = "Expense Date"
        LblV_No.Text = "Exp. No."
        TP1.Text = "Maintinance/Exp. Detail"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)

        AgCShowGrid1.Visible = True
        AgCShowGrid2.Visible = True

        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From Tp_MaintenanceExpenseEntry H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select Convert(Varchar(36),UID) As SearchCode " & _
               " From Tp_MaintenanceExpenseEntry_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT Convert(varchar(36),H.Uid) as SearchCode, Vt.Description AS [" & LblV_Type.Text & "], " & _
                            " H.V_Date AS [" & LblV_Date.Text & "], " & _
                            " H.V_No AS [" & LblV_No.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " Sg.DispName As [" & LblParty.Text & "],  " & _
                            " H.PartyDocumentNo AS [" & LblPartyDocumentNo.Text & "], " & _
                            " H.PartyDocumentDate AS [" & LblPartyDocumentDate.Text & "] " & _
                            " FROM Tp_MaintenanceExpenseEntry_Log H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg On H.Party = Sg.SubCode " & _
                            " Where H.EntryStatus = '" & AgTemplate.ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [" & LblV_Type.Text & "], " & _
                            " H.V_Date AS [" & LblV_Date.Text & "], " & _
                            " H.V_No AS [" & LblV_No.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " Sg.DispName As [" & LblParty.Text & "],  " & _
                            " H.PartyDocumentNo AS [" & LblPartyDocumentNo.Text & "], " & _
                            " H.PartyDocumentDate AS [" & LblPartyDocumentDate.Text & "] " & _
                            " FROM Tp_MaintenanceExpenseEntry H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg On H.Party = Sg.SubCode " & _
                            " Where IsNull(H.IsDeleted,0)=0  " & mCondStr

        AgL.PubFindQryOrdBy = "Convert(SmallDateTime,[" & LblV_Date.Text & "])"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Expense, 130, 0, Col1Expense, True, False, False)
            .AddAgTextColumn(Dgl1, Col1ExpenseType, 60, 0, Col1ExpenseType, False, True, False)
            .AddAgTextColumn(Dgl1, Col1ExpenseDescription, 100, 0, Col1ExpenseDescription, False, False, False)
            .AddAgTextColumn(Dgl1, Col1Vehicle, 90, 0, Col1Vehicle, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 50, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 60, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 80, 8, 2, False, Col1Amount, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeterReading, 60, 8, 0, False, Col1MeterReading, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1NextAfterKm, 60, 8, 2, False, Col1NextAfterKm, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1NextMeterReading, 60, 8, 2, False, Col1NextMeterReading, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1NextAfterDays, 60, 8, 0, False, Col1NextAfterDays, True, False, True)
            .AddAgDateColumn(Dgl1, Col1NextDate, 80, Col1NextDate, True, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 50
        Dgl1.AgSkipReadOnlyColumns = True


        'Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))

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
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Expense).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.Visible = False


        FrmSaleOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI%, bIntSr%, bTempSr%

        Dim bDblTotalLineAddition = Val(AgCalcGrid1.AgChargesValue(AgCalc_TotalLineAddition, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))

        mQry = "Update dbo.Tp_MaintenanceExpenseEntry_Log " & _
                " SET Party = " & AgL.Chk_Text(TxtParty.AgSelectedValue) & ", " & _
                "   Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                "   ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " 	PartyDocumentNo = " & AgL.Chk_Text(TxtPartyDocumentNo.Text) & ", " & _
                " 	PartyDocumentDate = " & AgL.ConvertDate(TxtPartyDocumentDate.Text) & ", " & _
                " 	TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                " 	TotalLineAmount = " & Val(AgCalcGrid1.AgChargesValue(AgCalc_TotalLineAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	TotalLineNetAmount = " & Val(AgCalcGrid1.AgChargesValue(AgCalc_TotalLineNetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	NetSubTotal = " & Val(AgCalcGrid1.AgChargesValue(AgCalc_NetSubTotal, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	RoundOff = " & Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.ROUNDOFF, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	NetAmount = " & Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)


        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Tp_MaintenanceExpenseEntry1_Log WHERE UID = " & AgL.Chk_Text(mSearchCode) & " "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Expense, bIntI).Value <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Tp_MaintenanceExpenseEntry1_Log ( " & _
                        " UID, DocId, Sr, Expense, ExpenseDescription, Qty, Rate, Amount, Vehicle, MeterReading, NextAfterKm, NextMeterReading, NextAfterDays, NextDate) " & _
                        " VALUES (" & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Expense, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1ExpenseDescription, bIntI).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, bIntI).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, bIntI).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Vehicle, bIntI)) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeterReading, bIntI).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1NextAfterKm, bIntI).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1NextMeterReading, bIntI).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1NextAfterDays, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1NextDate, bIntI).Value.ToString) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                If Dgl1.Item(Col1Vehicle, bIntI).Value.ToString.Trim <> "" Then
                    mQry = "DELETE FROM Tp_Vehicle1 " & _
                            " WHERE 1=1 " & _
                            " And Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Vehicle, bIntI)) & " " & _
                            " And Expense = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Expense, bIntI)) & " " & _
                            " AND (DueOnDate <= " & AgL.Chk_Text(Dgl1.Item(Col1NextDate, bIntI).Value.ToString) & " OR Tp_Vehicle1.DueOnMeterReading <= " & Val(Dgl1.Item(Col1NextMeterReading, bIntI).Value) & ")"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = "SELECT IsNULL(Max(V1.Sr),0) + 1 FROM Tp_Vehicle1 V1 WITH (NoLock) WHERE V1.Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Vehicle, bIntI)) & " "
                    bTempSr = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)

                    mQry = "INSERT INTO dbo.Tp_Vehicle1 (Code, Sr, Expense, ExpenseType, DueOnDate, DueOnMeterReading, Remark) " & _
                            " VALUES (" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Vehicle, bIntI)) & ", " & bTempSr & ", " & _
                            " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Expense, bIntI)) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1ExpenseType, bIntI).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1NextDate, bIntI).Value.ToString) & ", " & _
                            " " & Val(Dgl1.Item(Col1NextMeterReading, bIntI).Value) & ", " & _
                            " Null " & _
                            " )"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If

                AgCalcGrid1.Save_TransLine(mInternalCode, bIntSr, bIntI, Conn, Cmd, SearchCode)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim bIntI As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Dim DtTemp As DataTable = Nothing

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From Tp_MaintenanceExpenseEntry H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From Tp_MaintenanceExpenseEntry_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        If DsTemp.Tables(0).Rows.Count > 0 Then
            With DsTemp.Tables(0)
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))


                TxtParty.AgSelectedValue = AgL.XNull(.Rows(0)("Party"))
                TxtPartyDocumentDate.Text = Format(AgL.XNull(.Rows(0)("PartyDocumentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtPartyDocumentNo.Text = AgL.XNull(.Rows(0)("PartyDocumentNo"))
                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))


                LblValNetAmount.Text = Format(AgL.VNull(.Rows(0)("NetAmount")), "0.00")
                LblValTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)
            End With

            '-------------------------------------------------------------
            'Line Records are showing in Grid
            '-------------------------------------------------------------
            If FrmType = ClsMain.EntryPointType.Main Then
                mQry = "Select * from Tp_MaintenanceExpenseEntry1 where DocId = '" & SearchCode & "' Order By L.Sr"
            Else
                mQry = "Select * from Tp_MaintenanceExpenseEntry1_Log where UID = '" & SearchCode & "' Order By L.Sr"
            End If
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()

                If DtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To DtTemp.Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, bIntI).Value = Dgl1.Rows.Count - 1

                        Dgl1.AgSelectedValue(Col1Expense, bIntI) = AgL.XNull(.Rows(bIntI)("Expense"))
                        DrTemp = Dgl1.AgHelpDataSet(Col1Expense).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Expense, bIntI)) & "")
                        If DrTemp.Length > 0 Then
                            Dgl1.Item(Col1ExpenseType, bIntI).Value = AgL.XNull(DrTemp(0)("Expense Type"))
                        End If
                        DrTemp = Nothing

                        Dgl1.Item(Col1ExpenseDescription, bIntI).Value = AgL.XNull(.Rows(bIntI)("ExpenseDescription"))
                        Dgl1.Item(Col1Qty, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Qty")), "0.000")
                        Dgl1.Item(Col1Rate, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Rate")), "0.00")
                        Dgl1.Item(Col1Amount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Amount")), "0.00")
                        Dgl1.AgSelectedValue(Col1Vehicle, bIntI) = AgL.XNull(.Rows(bIntI)("Vehicle"))
                        Dgl1.Item(Col1MeterReading, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("MeterReading")), "0.00")
                        Dgl1.Item(Col1NextMeterReading, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("NextMeterReading")), "0.00")
                        Dgl1.Item(Col1NextAfterKm, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("NextAfterKm")), "0.00")
                        Dgl1.Item(Col1NextAfterDays, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("NextAfterDays")), "0")
                        Dgl1.Item(Col1NextDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("NextDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                        RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)

                    Next bIntI
                End If
            End With

            AgCShowGrid1.MoveRec_FromCalcGrid()
            AgCShowGrid2.MoveRec_FromCalcGrid()
            '-------------------------------------------------------------

            Topctrl1.tPrn = False
        End If
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 630, 1010)

        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType

        If AgL.StrCmp(_EntryMode, "Add") Then
            Topctrl1.FButtonClick(0)
        Else
            MoveRec()
        End If
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    Call IniGrid()
                    Call ProcFillReferenceNo()

                Case TxtParty.Name
                    'e.Cancel = Not Validating_Controls(sender)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        Dim DrTemp As DataRow() = Nothing

        ProcFillReferenceNo()
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1


        'TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        'AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue

        If VehicleCode.Trim <> "" Then
            Dgl1.Rows.Add()
            Dgl1.Item(ColSNo, 0).Value = 1

            Dgl1.AgSelectedValue(Col1Vehicle, 0) = VehicleCode
            Call Validating_Vehicle(0)

            If ExpenseCode.Trim <> "" Then
                Dgl1.AgSelectedValue(Col1Expense, 0) = ExpenseCode
                Call Validating_Expense(0)

                If DueOnMeterReading > 0 Then
                    If Val(Dgl1.Item(Col1NextAfterKm, 0).Value) > 0 Then
                        Dgl1.Item(Col1NextMeterReading, 0).Value = Format(DueOnMeterReading + Val(Dgl1.Item(Col1NextAfterKm, 0).Value), "0.00")
                    End If
                End If

                If DueOnDate.Trim <> "" Then
                    If Val(Dgl1.Item(Col1NextAfterDays, 0).Value) > 0 Then
                        Dgl1.Item(Col1NextDate, 0).Value = Format(CDate(DueOnDate).AddDays(Val(Dgl1.Item(Col1NextAfterDays, 0).Value)), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    End If
                End If

            End If

        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure

        TxtParty.AgHelpDataSet(4, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Party.Copy
        Dgl1.AgHelpDataSet(Col1Expense) = HelpDataSet.Expense.Copy
        Dgl1.AgHelpDataSet(Col1Vehicle, 1) = HelpDataSet.Vehicle.Copy

    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim bIntI As Integer

        LblValTotalQty.Text = ""
        LblValNetAmount.Text = ""

        For bIntI = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Expense, bIntI).Value Is Nothing Then Dgl1.Item(Col1Expense, bIntI).Value = ""
            If Dgl1.Item(Col1Qty, bIntI).Value Is Nothing Then Dgl1.Item(Col1Qty, bIntI).Value = ""
            If Dgl1.Item(Col1Rate, bIntI).Value Is Nothing Then Dgl1.Item(Col1Rate, bIntI).Value = ""
            If Dgl1.Item(Col1Amount, bIntI).Value Is Nothing Then Dgl1.Item(Col1Amount, bIntI).Value = ""

            If Dgl1.Item(Col1Expense, bIntI).Value <> "" Then
                Dgl1.Item(Col1Amount, bIntI).Value = Format(Val(Dgl1.Item(Col1Qty, bIntI).Value) * Val(Dgl1.Item(Col1Rate, bIntI).Value), "0.00")


                If AgL.XNull(Dgl1.Item(Col1NextMeterReading, bIntI).Value).ToString.Trim = "" Then
                    If Val(Dgl1.Item(Col1NextAfterKm, bIntI).Value) > 0 Then
                        Dgl1.Item(Col1NextMeterReading, bIntI).Value = Format(Val(Dgl1.Item(Col1MeterReading, bIntI).Value) + Val(Dgl1.Item(Col1NextAfterKm, bIntI).Value), "0.00")
                    Else
                        Dgl1.Item(Col1NextMeterReading, bIntI).Value = ""
                    End If
                End If

                If AgL.XNull(Dgl1.Item(Col1NextDate, bIntI).Value).ToString.Trim = "" Then
                    If Val(Dgl1.Item(Col1NextAfterDays, bIntI).Value) > 0 Then
                        Dgl1.Item(Col1NextDate, bIntI).Value = Format(CDate(TxtV_Date.Text).AddDays(Val(Dgl1.Item(Col1NextAfterDays, bIntI).Value)), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    Else
                        Dgl1.Item(Col1NextDate, bIntI).Value = ""
                    End If
                End If


                'Footer Calculation
                LblValTotalQty.Text = Val(LblValTotalQty.Text) + Val(Dgl1.Item(Col1Qty, bIntI).Value)
            End If
        Next

        AgCalcGrid1.Calculation()

        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")
        LblValNetAmount.Text = Format(Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)), "0.00")
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then passed = False : Exit Sub
    End Sub

    Public Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Try
            If AgL.RequiredField(TxtParty, LblParty.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Expense).Index) Then Exit Function

            'With DGL1
            '    For bIntI = 0 To .Rows.Count - 1
            '        If .Item(Col1Item, bIntI).Value.ToString.Trim <> "" Then
            '            If Val(DGL1.Item(Col1ChallanQty, bIntI).Value) <= 0 Then
            '                If MsgBox("Challan Qty. Can't Be <= 0 (Zero) At Row No. : " & .Item(ColSNo, bIntI).Value & "!..." & vbCrLf & "Do You Want To Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Validation Check") = MsgBoxResult.No Then
            '                    DGL1.CurrentCell = DGL1(Col1ChallanQty, bIntI) : DGL1.Focus() : Exit Function
            '                End If
            '            End If
            '        End If
            '    Next
            'End With

            'Start Code ReferenceNo Validation
            If Topctrl1.Mode = "Add" Then
                mQry = " SELECT COUNT(*) FROM Tp_MaintenanceExpenseEntry WHERE ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
                        " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'"
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Reference No. Already Exists") : Exit Function
            Else
                mQry = " SELECT COUNT(*) FROM Tp_MaintenanceExpenseEntry WHERE ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
                        " AND V_Type ='" & TxtV_Type.AgSelectedValue & "' AND DocID <>'" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Reference No. Already Exists") : Exit Function
            End If
            'End Code By ReferenceNo Validation


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case sender.name
                'Case <sender>.Name
                '<Executable Code>
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub TempGr_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        '------------------------------------------------------------------------
        'Updating Goods Received Qty In Purchase Order Detail
        '-------------------------------------------------------------------------
        'With Dgl1
        '    For I = 0 To .RowCount - 1
        '        If .Item(Col1Item, I).Value <> "" Then
        '            mQry = "UPDATE PurchOrderDetail " & _
        '                    " SET ShippedQty = (SELECT IsNull(Sum(Cd.Qty),0) " & _
        '                    " 				    FROM PurchChallanDetail Cd With (NoLock) " & _
        '                    "                   LEFT JOIN PurchChallan C With (NoLock) On Cd.DocId = C.DocId " & _
        '                    " 				    WHERE Cd.PurchOrder = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
        '                    " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
        '                    "                   AND IsNull(C.IsDeleted,0) = 0 ), " & _
        '                    " ShippedMeasure = (SELECT IsNull(Sum(Cd.TotalMeasure),0) " & _
        '                    " 				    FROM PurchChallanDetail Cd With (NoLock) " & _
        '                    "                   LEFT JOIN PurchChallan C With (NoLock) On Cd.DocId = C.DocId " & _
        '                    " 				    WHERE Cd.PurchOrder = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
        '                    " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
        '                    "                   AND IsNull(C.IsDeleted,0) = 0 ) " & _
        '                    " WHERE DocId = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
        '                    " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
        '            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '        End If
        '    Next
        'End With

        'mQry = " UPDATE Form_ReceiveDetail " & _
        '        " SET IsUtilised = (SELECT Count(*) FROM PurchChallan WITH (NoLock) WHERE FormNo = '" & TxtFormNo.Text & "') " & _
        '        " WHERE FormNo = '" & TxtFormNo.Text & "' "
        'AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '-------------------------------------------------------------------------
    End Sub

    Public Sub ProcStockPost(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, ByVal RowIndex As Integer, ByVal mSr As Integer)
        'mQry = "Insert Into Stock_Log(UID, DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
        '            " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item, LotNo, " & _
        '            " Godown, Qty_Rec, Unit, MeasurePerPcs, Measure_Rec, MeasureUnit, " & _
        '            " Rate, Amount ) " & _
        '            " Values( " & _
        '            " '" & mSearchCode & "', '" & mInternalCode & "',  " & Val(mSr) & ", " & _
        '            " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
        '            " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(TxtBillingType.Text) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, RowIndex)) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1Qty, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1MeasurePerPcs, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1TotalMeasure, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1Rate, RowIndex).Value) & ", " & _
        '            " " & AgL.Chk_Text(Dgl1.Item(Col1Amount, RowIndex).Value) & ")  "
        'AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub TempGr_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            '<Executable Code>
        End If
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
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM QCDetail   L LEFT JOIN QC  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Quality Checking " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If


            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM PurchInvoiceDetail   L LEFT JOIN PurchInvoice  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "') AS X  "
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
        mQry = "Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, " & _
                " Sg.DispName AS PartyDispName, Sg.ManualCode, Sg.Nature  " & _
                " From SubGroup Sg " & _
                " LEFT JOIN AcGroup Ag ON Ag.GroupCode = Sg.GroupCode " & _
                " Left Join City On Sg.CityCode = City.CityCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " And (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & " Or " & _
                "       Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") " & _
                " Order By SG.Name "
        HelpDataSet.Party = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT E.Code, E.Description AS Name, " & _
                " E.ExpenseType As [Expense Type], E.OnEveryKms, E.OnEveryDays " & _
                " FROM Tp_Expense E " & _
                " ORDER BY E.Description"
        HelpDataSet.Expense = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V.Code  As Code, V.RegistrationNo As [Vehicle No], " & _
                " V.Description As [Vehicle Name], V.MeterReading " & _
                " From Tp_Vehicle V " & _
                " Order By V.RegistrationNo "
        HelpDataSet.Vehicle = AgL.FillData(mQry, AgL.GCn)

    End Sub

    'Start Code By Satyam on 18/11/2011
    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
            End If
        End If
    End Sub
    'Code End By Satyam on 18/11/2011

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            If Dgl1.CurrentCell Is Nothing Then Exit Sub

            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                'Case <ColumnIndex>
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""


            With Dgl1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1Expense
                        Call Validating_Expense(mRowIndex)

                    Case Col1Vehicle
                        Call Validating_Vehicle(mRowIndex)
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
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
                'Case <ColumnIndex>
                'e.Cancel = Not Validate_PurchOrder(Dgl1, Dgl1.CurrentCell.RowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Dgl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control = True And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
    End Sub

    Public Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            'Case TxtParty.Name
            '    If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
            '        Sender.AgSelectedValue = ""
            '        LblMaterialReceiveDocIdReq.Tag = ""
            '    Else
            '        If Sender.AgHelpDataSet IsNot Nothing Then
            '            DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
            '            LblMaterialReceiveDocIdReq.Tag = AgL.XNull(DrTemp(0)("Party"))
            '        End If
            '    End If
            '    DrTemp = Nothing
        End Select

        Validating_Controls = True
    End Function

    Public Function Validating_Expense(ByVal IntRowIndex As Integer) As Boolean
        Dim DrTemp As DataRow() = Nothing

        If Dgl1.Item(Col1Expense, IntRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Expense, IntRowIndex).Trim = "" Then
            Dgl1.AgSelectedValue(Col1Expense, IntRowIndex) = ""
            Dgl1.Item(Col1NextAfterKm, IntRowIndex).Value = ""
            Dgl1.Item(Col1NextAfterDays, IntRowIndex).Value = ""
            Dgl1.Item(Col1ExpenseType, IntRowIndex).Value = ""

        Else
            If Dgl1.AgHelpDataSet(Col1Expense) IsNot Nothing Then
                DrTemp = Dgl1.AgHelpDataSet(Col1Expense).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Expense, IntRowIndex)) & "")
                If DrTemp.Length > 0 Then
                    Dgl1.Item(Col1NextAfterKm, IntRowIndex).Value = Format(AgL.VNull(DrTemp(0)("OnEveryKms")), "0.00")
                    Dgl1.Item(Col1NextAfterDays, IntRowIndex).Value = Format(AgL.VNull(DrTemp(0)("OnEveryDays")), "0")
                    Dgl1.Item(Col1ExpenseType, IntRowIndex).Value = AgL.XNull(DrTemp(0)("Expense Type"))
                End If
            End If
            DrTemp = Nothing
        End If

        Validating_Expense = True
    End Function

    Public Function Validating_Vehicle(ByVal IntRowIndex As Integer) As Boolean
        Dim DrTemp As DataRow() = Nothing

        If Dgl1.Item(Col1Vehicle, IntRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Vehicle, IntRowIndex).Trim = "" Then
            Dgl1.AgSelectedValue(Col1Vehicle, IntRowIndex) = ""
            Dgl1.Item(Col1MeterReading, IntRowIndex).Value = ""
            Dgl1.Item(Col1NextAfterKm, IntRowIndex).Value = ""

        Else
            If Dgl1.AgHelpDataSet(Col1Vehicle) IsNot Nothing Then
                DrTemp = Dgl1.AgHelpDataSet(Col1Vehicle).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Vehicle, IntRowIndex)) & "")

                Dgl1.Item(Col1MeterReading, IntRowIndex).Value = Format(AgL.VNull(DrTemp(0)("MeterReading")), "0.00")
            End If
            DrTemp = Nothing
        End If

        Validating_Vehicle = True
    End Function

   
End Class
