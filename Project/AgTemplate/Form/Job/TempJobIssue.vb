Public Class TempJobIssue
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Protected WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1StockItem As String = "Stock Item"
    Protected Const Col1LotNo As String = "Lot No"
    Protected Const Col1CurrentStock As String = "Curr Stock"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1PrevProcess As String = "Prev Process"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1JobOrder As String = "Job Order No"
    Protected Const Col1ReceiveQty As String = "Receive Qty"
    Protected Const Col1ReceiveMeasure As String = "Receive Measure"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected WithEvents TxtWithMaterialYN As AgControls.AgTextBox
    Protected WithEvents LblWithMaterialYN As System.Windows.Forms.Label

    Protected mPrevProcess$ = ""

    Public Class HelpDataSet
        Public Shared Item As DataSet = Nothing
        Public Shared ItemFromJobOrder As DataSet = Nothing
        Public Shared ItemAsPerBOM As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Process As DataSet = Nothing
        Public Shared JobWorker As DataSet = Nothing
        Public Shared JobOrder As DataSet = Nothing
        Public Shared LotNo As DataSet = Nothing
    End Class

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblGodown = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.LblTotalIssMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalIssQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblGodownReq = New System.Windows.Forms.Label
        Me.TxtManualRefNo = New AgControls.AgTextBox
        Me.LblManualRefNo = New System.Windows.Forms.Label
        Me.LblJobWorkerReq = New System.Windows.Forms.Label
        Me.TxtJobWorker = New AgControls.AgTextBox
        Me.LblJobWorker = New System.Windows.Forms.Label
        Me.TxtProcess = New AgControls.AgTextBox
        Me.LblProcess = New System.Windows.Forms.Label
        Me.LblJobIssueDetail = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtForJobOrder = New AgControls.AgTextBox
        Me.LblForJobOrder = New System.Windows.Forms.Label
        Me.TxtJobOrder = New AgControls.AgTextBox
        Me.LblJobOrderNo = New System.Windows.Forms.Label
        Me.RbtAllItemsFromJobOrder = New System.Windows.Forms.RadioButton
        Me.RbtPendingItems = New System.Windows.Forms.RadioButton
        Me.PnlForJobOrderYes = New System.Windows.Forms.Panel
        Me.PnlForJobOrderNo = New System.Windows.Forms.Panel
        Me.RbtItemAsPerBOM = New System.Windows.Forms.RadioButton
        Me.RbtAllItems = New System.Windows.Forms.RadioButton
        Me.TxtWithMaterialYN = New AgControls.AgTextBox
        Me.LblWithMaterialYN = New System.Windows.Forms.Label
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
        Me.PnlForJobOrderYes.SuspendLayout()
        Me.PnlForJobOrderNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(744, 451)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(580, 451)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(416, 451)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(151, 451)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 451)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 447)
        Me.GroupBox1.Size = New System.Drawing.Size(921, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(286, 451)
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
        Me.LblV_No.Location = New System.Drawing.Point(-1, 131)
        Me.LblV_No.Size = New System.Drawing.Size(87, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Job Issue No."
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(81, 131)
        Me.TxtV_No.Size = New System.Drawing.Size(130, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 37)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(17, 32)
        Me.LblV_Date.Size = New System.Drawing.Size(94, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Job Issue Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(344, 17)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(129, 31)
        Me.TxtV_Date.Size = New System.Drawing.Size(110, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(247, 12)
        Me.LblV_Type.Size = New System.Drawing.Size(95, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Job Issue Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(360, 11)
        Me.TxtV_Type.Size = New System.Drawing.Size(130, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 17)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(17, 12)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(129, 11)
        Me.TxtSite_Code.Size = New System.Drawing.Size(110, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(809, 184)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 18)
        Me.TabControl1.Size = New System.Drawing.Size(906, 117)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtWithMaterialYN)
        Me.TP1.Controls.Add(Me.LblWithMaterialYN)
        Me.TP1.Controls.Add(Me.TxtJobOrder)
        Me.TP1.Controls.Add(Me.LblJobOrderNo)
        Me.TP1.Controls.Add(Me.TxtForJobOrder)
        Me.TP1.Controls.Add(Me.LblForJobOrder)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.TxtProcess)
        Me.TP1.Controls.Add(Me.LblProcess)
        Me.TP1.Controls.Add(Me.LblJobWorkerReq)
        Me.TP1.Controls.Add(Me.TxtJobWorker)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.LblJobWorker)
        Me.TP1.Controls.Add(Me.TxtManualRefNo)
        Me.TP1.Controls.Add(Me.LblManualRefNo)
        Me.TP1.Controls.Add(Me.LblGodownReq)
        Me.TP1.Controls.Add(Me.TxtGodown)
        Me.TP1.Controls.Add(Me.LblGodown)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(898, 91)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGodownReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblJobWorker, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJobWorker, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblJobWorkerReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProcess, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProcess, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblForJobOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtForJobOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblJobOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJobOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblWithMaterialYN, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtWithMaterialYN, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(903, 41)
        Me.Topctrl1.TabIndex = 2
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
        'TxtGodown
        '
        Me.TxtGodown.AgMandatory = True
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
        Me.TxtGodown.Location = New System.Drawing.Point(582, 31)
        Me.TxtGodown.MaxLength = 20
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(293, 18)
        Me.TxtGodown.TabIndex = 7
        '
        'LblGodown
        '
        Me.LblGodown.AutoSize = True
        Me.LblGodown.BackColor = System.Drawing.Color.Transparent
        Me.LblGodown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGodown.Location = New System.Drawing.Point(495, 32)
        Me.LblGodown.Name = "LblGodown"
        Me.LblGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblGodown.TabIndex = 706
        Me.LblGodown.Text = "Godown"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Controls.Add(Me.LblTotalIssMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalIssQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(6, 412)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(772, 3)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 668
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTotalAmount.Visible = False
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(661, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 667
        Me.LblTotalAmountText.Text = "Total Amount :"
        Me.LblTotalAmountText.Visible = False
        '
        'LblTotalIssMeasure
        '
        Me.LblTotalIssMeasure.AutoSize = True
        Me.LblTotalIssMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalIssMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalIssMeasure.Location = New System.Drawing.Point(424, 3)
        Me.LblTotalIssMeasure.Name = "LblTotalIssMeasure"
        Me.LblTotalIssMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalIssMeasure.TabIndex = 666
        Me.LblTotalIssMeasure.Text = "."
        Me.LblTotalIssMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(313, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
        '
        'LblTotalIssQty
        '
        Me.LblTotalIssQty.AutoSize = True
        Me.LblTotalIssQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalIssQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalIssQty.Location = New System.Drawing.Point(116, 3)
        Me.LblTotalIssQty.Name = "LblTotalIssQty"
        Me.LblTotalIssQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalIssQty.TabIndex = 660
        Me.LblTotalIssQty.Text = "."
        Me.LblTotalIssQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(31, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(6, 167)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(894, 245)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(495, 52)
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
        Me.TxtRemarks.Location = New System.Drawing.Point(582, 51)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(293, 18)
        Me.TxtRemarks.TabIndex = 9
        '
        'LblGodownReq
        '
        Me.LblGodownReq.AutoSize = True
        Me.LblGodownReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblGodownReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblGodownReq.Location = New System.Drawing.Point(564, 37)
        Me.LblGodownReq.Name = "LblGodownReq"
        Me.LblGodownReq.Size = New System.Drawing.Size(10, 7)
        Me.LblGodownReq.TabIndex = 724
        Me.LblGodownReq.Text = "Ä"
        '
        'TxtManualRefNo
        '
        Me.TxtManualRefNo.AgMandatory = True
        Me.TxtManualRefNo.AgMasterHelp = False
        Me.TxtManualRefNo.AgNumberLeftPlaces = 8
        Me.TxtManualRefNo.AgNumberNegetiveAllow = False
        Me.TxtManualRefNo.AgNumberRightPlaces = 2
        Me.TxtManualRefNo.AgPickFromLastValue = False
        Me.TxtManualRefNo.AgRowFilter = ""
        Me.TxtManualRefNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualRefNo.AgSelectedValue = Nothing
        Me.TxtManualRefNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualRefNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualRefNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualRefNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualRefNo.Location = New System.Drawing.Point(360, 31)
        Me.TxtManualRefNo.MaxLength = 50
        Me.TxtManualRefNo.Name = "TxtManualRefNo"
        Me.TxtManualRefNo.Size = New System.Drawing.Size(130, 18)
        Me.TxtManualRefNo.TabIndex = 5
        '
        'LblManualRefNo
        '
        Me.LblManualRefNo.AutoSize = True
        Me.LblManualRefNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualRefNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualRefNo.Location = New System.Drawing.Point(247, 32)
        Me.LblManualRefNo.Name = "LblManualRefNo"
        Me.LblManualRefNo.Size = New System.Drawing.Size(101, 16)
        Me.LblManualRefNo.TabIndex = 726
        Me.LblManualRefNo.Text = "Manual Ref. No."
        '
        'LblJobWorkerReq
        '
        Me.LblJobWorkerReq.AutoSize = True
        Me.LblJobWorkerReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblJobWorkerReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblJobWorkerReq.Location = New System.Drawing.Point(111, 57)
        Me.LblJobWorkerReq.Name = "LblJobWorkerReq"
        Me.LblJobWorkerReq.Size = New System.Drawing.Size(10, 7)
        Me.LblJobWorkerReq.TabIndex = 735
        Me.LblJobWorkerReq.Text = "Ä"
        '
        'TxtJobWorker
        '
        Me.TxtJobWorker.AgMandatory = True
        Me.TxtJobWorker.AgMasterHelp = False
        Me.TxtJobWorker.AgNumberLeftPlaces = 8
        Me.TxtJobWorker.AgNumberNegetiveAllow = False
        Me.TxtJobWorker.AgNumberRightPlaces = 2
        Me.TxtJobWorker.AgPickFromLastValue = False
        Me.TxtJobWorker.AgRowFilter = ""
        Me.TxtJobWorker.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtJobWorker.AgSelectedValue = Nothing
        Me.TxtJobWorker.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtJobWorker.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtJobWorker.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtJobWorker.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJobWorker.Location = New System.Drawing.Point(129, 51)
        Me.TxtJobWorker.MaxLength = 20
        Me.TxtJobWorker.Name = "TxtJobWorker"
        Me.TxtJobWorker.Size = New System.Drawing.Size(361, 18)
        Me.TxtJobWorker.TabIndex = 6
        '
        'LblJobWorker
        '
        Me.LblJobWorker.AutoSize = True
        Me.LblJobWorker.BackColor = System.Drawing.Color.Transparent
        Me.LblJobWorker.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJobWorker.Location = New System.Drawing.Point(17, 52)
        Me.LblJobWorker.Name = "LblJobWorker"
        Me.LblJobWorker.Size = New System.Drawing.Size(74, 16)
        Me.LblJobWorker.TabIndex = 734
        Me.LblJobWorker.Text = "Job Worker"
        '
        'TxtProcess
        '
        Me.TxtProcess.AgMandatory = True
        Me.TxtProcess.AgMasterHelp = False
        Me.TxtProcess.AgNumberLeftPlaces = 8
        Me.TxtProcess.AgNumberNegetiveAllow = False
        Me.TxtProcess.AgNumberRightPlaces = 2
        Me.TxtProcess.AgPickFromLastValue = False
        Me.TxtProcess.AgRowFilter = ""
        Me.TxtProcess.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProcess.AgSelectedValue = Nothing
        Me.TxtProcess.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProcess.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProcess.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProcess.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProcess.Location = New System.Drawing.Point(762, 163)
        Me.TxtProcess.MaxLength = 20
        Me.TxtProcess.Name = "TxtProcess"
        Me.TxtProcess.Size = New System.Drawing.Size(125, 18)
        Me.TxtProcess.TabIndex = 5
        Me.TxtProcess.Visible = False
        '
        'LblProcess
        '
        Me.LblProcess.AutoSize = True
        Me.LblProcess.BackColor = System.Drawing.Color.Transparent
        Me.LblProcess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProcess.Location = New System.Drawing.Point(811, 147)
        Me.LblProcess.Name = "LblProcess"
        Me.LblProcess.Size = New System.Drawing.Size(56, 16)
        Me.LblProcess.TabIndex = 737
        Me.LblProcess.Text = "Process"
        Me.LblProcess.Visible = False
        '
        'LblJobIssueDetail
        '
        Me.LblJobIssueDetail.BackColor = System.Drawing.Color.SteelBlue
        Me.LblJobIssueDetail.DisabledLinkColor = System.Drawing.Color.White
        Me.LblJobIssueDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJobIssueDetail.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblJobIssueDetail.LinkColor = System.Drawing.Color.White
        Me.LblJobIssueDetail.Location = New System.Drawing.Point(6, 146)
        Me.LblJobIssueDetail.Name = "LblJobIssueDetail"
        Me.LblJobIssueDetail.Size = New System.Drawing.Size(116, 20)
        Me.LblJobIssueDetail.TabIndex = 732
        Me.LblJobIssueDetail.TabStop = True
        Me.LblJobIssueDetail.Text = "Job Issue Detail"
        Me.LblJobIssueDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(346, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 740
        Me.Label1.Text = "Ä"
        '
        'TxtForJobOrder
        '
        Me.TxtForJobOrder.AgMandatory = False
        Me.TxtForJobOrder.AgMasterHelp = False
        Me.TxtForJobOrder.AgNumberLeftPlaces = 0
        Me.TxtForJobOrder.AgNumberNegetiveAllow = False
        Me.TxtForJobOrder.AgNumberRightPlaces = 0
        Me.TxtForJobOrder.AgPickFromLastValue = False
        Me.TxtForJobOrder.AgRowFilter = ""
        Me.TxtForJobOrder.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForJobOrder.AgSelectedValue = Nothing
        Me.TxtForJobOrder.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForJobOrder.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtForJobOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForJobOrder.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForJobOrder.Location = New System.Drawing.Point(582, 11)
        Me.TxtForJobOrder.MaxLength = 255
        Me.TxtForJobOrder.Name = "TxtForJobOrder"
        Me.TxtForJobOrder.Size = New System.Drawing.Size(63, 18)
        Me.TxtForJobOrder.TabIndex = 746
        '
        'LblForJobOrder
        '
        Me.LblForJobOrder.AutoSize = True
        Me.LblForJobOrder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForJobOrder.Location = New System.Drawing.Point(496, 12)
        Me.LblForJobOrder.Name = "LblForJobOrder"
        Me.LblForJobOrder.Size = New System.Drawing.Size(87, 16)
        Me.LblForJobOrder.TabIndex = 747
        Me.LblForJobOrder.Text = "For Job Order"
        '
        'TxtJobOrder
        '
        Me.TxtJobOrder.AgMandatory = False
        Me.TxtJobOrder.AgMasterHelp = False
        Me.TxtJobOrder.AgNumberLeftPlaces = 0
        Me.TxtJobOrder.AgNumberNegetiveAllow = False
        Me.TxtJobOrder.AgNumberRightPlaces = 0
        Me.TxtJobOrder.AgPickFromLastValue = False
        Me.TxtJobOrder.AgRowFilter = ""
        Me.TxtJobOrder.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtJobOrder.AgSelectedValue = Nothing
        Me.TxtJobOrder.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtJobOrder.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtJobOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtJobOrder.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJobOrder.Location = New System.Drawing.Point(738, 11)
        Me.TxtJobOrder.MaxLength = 255
        Me.TxtJobOrder.Name = "TxtJobOrder"
        Me.TxtJobOrder.Size = New System.Drawing.Size(137, 18)
        Me.TxtJobOrder.TabIndex = 748
        '
        'LblJobOrderNo
        '
        Me.LblJobOrderNo.AutoSize = True
        Me.LblJobOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJobOrderNo.Location = New System.Drawing.Point(653, 12)
        Me.LblJobOrderNo.Name = "LblJobOrderNo"
        Me.LblJobOrderNo.Size = New System.Drawing.Size(84, 16)
        Me.LblJobOrderNo.TabIndex = 749
        Me.LblJobOrderNo.Text = "Job Order No"
        '
        'RbtAllItemsFromJobOrder
        '
        Me.RbtAllItemsFromJobOrder.AutoSize = True
        Me.RbtAllItemsFromJobOrder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtAllItemsFromJobOrder.Location = New System.Drawing.Point(127, 4)
        Me.RbtAllItemsFromJobOrder.Name = "RbtAllItemsFromJobOrder"
        Me.RbtAllItemsFromJobOrder.Size = New System.Drawing.Size(165, 17)
        Me.RbtAllItemsFromJobOrder.TabIndex = 751
        Me.RbtAllItemsFromJobOrder.TabStop = True
        Me.RbtAllItemsFromJobOrder.Text = "All Items From JobOrder"
        Me.RbtAllItemsFromJobOrder.UseVisualStyleBackColor = True
        '
        'RbtPendingItems
        '
        Me.RbtPendingItems.AutoSize = True
        Me.RbtPendingItems.Checked = True
        Me.RbtPendingItems.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtPendingItems.Location = New System.Drawing.Point(9, 4)
        Me.RbtPendingItems.Name = "RbtPendingItems"
        Me.RbtPendingItems.Size = New System.Drawing.Size(107, 17)
        Me.RbtPendingItems.TabIndex = 750
        Me.RbtPendingItems.TabStop = True
        Me.RbtPendingItems.Text = "Pending Items"
        Me.RbtPendingItems.UseVisualStyleBackColor = True
        '
        'PnlForJobOrderYes
        '
        Me.PnlForJobOrderYes.Controls.Add(Me.RbtAllItemsFromJobOrder)
        Me.PnlForJobOrderYes.Controls.Add(Me.RbtPendingItems)
        Me.PnlForJobOrderYes.Location = New System.Drawing.Point(138, 144)
        Me.PnlForJobOrderYes.Name = "PnlForJobOrderYes"
        Me.PnlForJobOrderYes.Size = New System.Drawing.Size(296, 22)
        Me.PnlForJobOrderYes.TabIndex = 752
        '
        'PnlForJobOrderNo
        '
        Me.PnlForJobOrderNo.Controls.Add(Me.RbtItemAsPerBOM)
        Me.PnlForJobOrderNo.Controls.Add(Me.RbtAllItems)
        Me.PnlForJobOrderNo.Location = New System.Drawing.Point(450, 144)
        Me.PnlForJobOrderNo.Name = "PnlForJobOrderNo"
        Me.PnlForJobOrderNo.Size = New System.Drawing.Size(235, 22)
        Me.PnlForJobOrderNo.TabIndex = 753
        Me.PnlForJobOrderNo.Visible = False
        '
        'RbtItemAsPerBOM
        '
        Me.RbtItemAsPerBOM.AutoSize = True
        Me.RbtItemAsPerBOM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtItemAsPerBOM.Location = New System.Drawing.Point(94, 4)
        Me.RbtItemAsPerBOM.Name = "RbtItemAsPerBOM"
        Me.RbtItemAsPerBOM.Size = New System.Drawing.Size(123, 17)
        Me.RbtItemAsPerBOM.TabIndex = 751
        Me.RbtItemAsPerBOM.TabStop = True
        Me.RbtItemAsPerBOM.Text = "Item As Per BOM"
        Me.RbtItemAsPerBOM.UseVisualStyleBackColor = True
        '
        'RbtAllItems
        '
        Me.RbtAllItems.AutoSize = True
        Me.RbtAllItems.Checked = True
        Me.RbtAllItems.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtAllItems.Location = New System.Drawing.Point(9, 4)
        Me.RbtAllItems.Name = "RbtAllItems"
        Me.RbtAllItems.Size = New System.Drawing.Size(76, 17)
        Me.RbtAllItems.TabIndex = 750
        Me.RbtAllItems.TabStop = True
        Me.RbtAllItems.Text = "All Items"
        Me.RbtAllItems.UseVisualStyleBackColor = True
        '
        'TxtWithMaterialYN
        '
        Me.TxtWithMaterialYN.AgMandatory = True
        Me.TxtWithMaterialYN.AgMasterHelp = False
        Me.TxtWithMaterialYN.AgNumberLeftPlaces = 8
        Me.TxtWithMaterialYN.AgNumberNegetiveAllow = False
        Me.TxtWithMaterialYN.AgNumberRightPlaces = 2
        Me.TxtWithMaterialYN.AgPickFromLastValue = False
        Me.TxtWithMaterialYN.AgRowFilter = ""
        Me.TxtWithMaterialYN.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWithMaterialYN.AgSelectedValue = Nothing
        Me.TxtWithMaterialYN.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWithMaterialYN.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtWithMaterialYN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWithMaterialYN.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWithMaterialYN.Location = New System.Drawing.Point(383, 220)
        Me.TxtWithMaterialYN.MaxLength = 20
        Me.TxtWithMaterialYN.Name = "TxtWithMaterialYN"
        Me.TxtWithMaterialYN.Size = New System.Drawing.Size(125, 18)
        Me.TxtWithMaterialYN.TabIndex = 750
        Me.TxtWithMaterialYN.Visible = False
        '
        'LblWithMaterialYN
        '
        Me.LblWithMaterialYN.AutoSize = True
        Me.LblWithMaterialYN.BackColor = System.Drawing.Color.Transparent
        Me.LblWithMaterialYN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWithMaterialYN.Location = New System.Drawing.Point(262, 222)
        Me.LblWithMaterialYN.Name = "LblWithMaterialYN"
        Me.LblWithMaterialYN.Size = New System.Drawing.Size(111, 16)
        Me.LblWithMaterialYN.TabIndex = 751
        Me.LblWithMaterialYN.Text = "With Material Y/N"
        Me.LblWithMaterialYN.Visible = False
        '
        'TempJobIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(903, 492)
        Me.Controls.Add(Me.PnlForJobOrderNo)
        Me.Controls.Add(Me.PnlForJobOrderYes)
        Me.Controls.Add(Me.LblJobIssueDetail)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempJobIssue"
        Me.Text = "Template Job Issue"
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
        Me.Controls.SetChildIndex(Me.LblJobIssueDetail, 0)
        Me.Controls.SetChildIndex(Me.PnlForJobOrderYes, 0)
        Me.Controls.SetChildIndex(Me.PnlForJobOrderNo, 0)
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
        Me.PnlForJobOrderYes.ResumeLayout(False)
        Me.PnlForJobOrderYes.PerformLayout()
        Me.PnlForJobOrderNo.ResumeLayout(False)
        Me.PnlForJobOrderNo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblGodown As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalIssQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalIssMeasure As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblGodownReq As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents TxtManualRefNo As AgControls.AgTextBox
    Protected WithEvents LblManualRefNo As System.Windows.Forms.Label
    Protected WithEvents TxtProcess As AgControls.AgTextBox
    Protected WithEvents LblProcess As System.Windows.Forms.Label
    Protected WithEvents LblJobWorkerReq As System.Windows.Forms.Label
    Protected WithEvents TxtJobWorker As AgControls.AgTextBox
    Protected WithEvents LblJobWorker As System.Windows.Forms.Label
    Protected WithEvents LblJobIssueDetail As System.Windows.Forms.LinkLabel
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtForJobOrder As AgControls.AgTextBox
    Protected WithEvents LblForJobOrder As System.Windows.Forms.Label
    Protected WithEvents TxtJobOrder As AgControls.AgTextBox
    Protected WithEvents LblJobOrderNo As System.Windows.Forms.Label
    Protected WithEvents RbtAllItemsFromJobOrder As System.Windows.Forms.RadioButton
    Protected WithEvents RbtPendingItems As System.Windows.Forms.RadioButton
    Protected WithEvents PnlForJobOrderYes As System.Windows.Forms.Panel
    Protected WithEvents PnlForJobOrderNo As System.Windows.Forms.Panel
    Protected WithEvents RbtItemAsPerBOM As System.Windows.Forms.RadioButton
    Protected WithEvents RbtAllItems As System.Windows.Forms.RadioButton
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
#End Region

    Private Sub Frm_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "JobIssRec"
        LogTableName = "JobIssRec_Log"
        MainLineTableCsv = "JobIssueDetail"
        LogLineTableCsv = "JobIssueDetail_Log"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Issue Type], H.V_Prefix AS Prefix, H.V_Date AS Date, H.V_No AS [Issue No], " & _
                        " H.ManualRefNo AS [Manual No], H.Process, H.DueDate AS [Due Date], H.IssQty AS [Issue Qty], H.IssMeasure AS [Issue Measure],  " & _
                        " H.RecQty AS [Rec Qty], H.RecMeasure AS [Rec Measure], H.JobReceiveFor AS [Job Receive For], H.Remarks, H.Structure, H.EntryBy AS [Entry By],  " & _
                        " H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date],  " & _
                        " H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, H.BillingType AS [Billing Type], H.OrderBy AS [ORDER By],  " & _
                        " H.TotalWeight AS [Total Weight], H.JobWorkerDocNo AS [Job Worker DocNo], H.TotalConsumptionQty AS [Total Consumption Qty], H.TotalConsumptionMeasure AS [Total Consumption Measure],  " & _
                        " H.TotalByProductQty AS [Total By Product Qty], H.TotalByProductMeasure AS [Total By Product Measure], " & _
                        " D.Div_Name AS Division, SM.Name AS [Site Name], SGJ.DispName AS [Job Worker Name], G.Description AS Godown, JO.ManualRefNo AS [Job ORDER No] " & _
                        " FROM JobIssRec_Log H " & _
                        " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                        " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                        " LEFT JOIN SubGroup SGJ ON SGJ.SubCode=H.JobWorker  " & _
                        " LEFT JOIN Godown G ON G.Code = H.Godown   " & _
                        " LEFT JOIN JobOrder  JO ON H.JobOrder   =JO.DocID  " & _
                        " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Issue Type], H.V_Prefix AS Prefix, H.V_Date AS Date, H.V_No AS [Issue No], " & _
                    " H.ManualRefNo AS [Manual No], H.Process, H.DueDate AS [Due Date], H.IssQty AS [Issue Qty], H.IssMeasure AS [Issue Measure],  " & _
                    " H.RecQty AS [Rec Qty], H.RecMeasure AS [Rec Measure], H.JobReceiveFor AS [Job Receive For], H.Remarks, H.Structure, H.EntryBy AS [Entry By],  " & _
                    " H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date],  " & _
                    " H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, H.BillingType AS [Billing Type], H.OrderBy AS [ORDER By],  " & _
                    " H.TotalWeight AS [Total Weight], H.JobWorkerDocNo AS [Job Worker DocNo], H.TotalConsumptionQty AS [Total Consumption Qty], H.TotalConsumptionMeasure AS [Total Consumption Measure],  " & _
                    " H.TotalByProductQty AS [Total By Product Qty], H.TotalByProductMeasure AS [Total By Product Measure], " & _
                    " D.Div_Name AS Division, SM.Name AS [Site Name], SGJ.DispName AS [Job Worker Name], G.Description AS Godown, JO.ManualRefNo AS [Job ORDER No] " & _
                    " FROM JobIssRec H " & _
                    " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                    " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                    " LEFT JOIN SubGroup SGJ ON SGJ.SubCode=H.JobWorker  " & _
                    " LEFT JOIN Godown G ON G.Code = H.Godown   " & _
                    " LEFT JOIN JobOrder  JO ON H.JobOrder   =JO.DocID  " & _
                    " Where 1=1  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("J.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("J.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "J.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select J.DocID As SearchCode " & _
                " From JobIssRec J " & _
                " Left Join Voucher_Type Vt On J.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0) = 0  " & mCondStr & "  Order By J.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("J.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("J.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "J.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"
        mCondStr = mCondStr & " And J.EntryStatus='" & LogStatus.LogOpen & "' "

        mQry = " Select J.UID As SearchCode " & _
            " From JobIssRec_Log J " & _
            " Left Join Voucher_Type Vt On J.V_Type = Vt.V_Type  " & _
            " Where 1=1  " & mCondStr & "  Order By J.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 250, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1StockItem, 150, 0, Col1StockItem, True, False)
            .AddAgTextColumn(Dgl1, Col1LotNo, 100, 20, Col1LotNo, False, False)
            .AddAgNumberColumn(Dgl1, Col1CurrentStock, 100, 8, 4, False, Col1CurrentStock, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 100, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 80, 0, Col1Unit, True, True)
            .AddAgTextColumn(Dgl1, Col1PrevProcess, 80, 0, Col1PrevProcess, False, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 70, 0, Col1MeasureUnit, True, True)
            .AddAgTextColumn(Dgl1, Col1JobOrder, 140, 0, Col1JobOrder, True, True)
            .AddAgNumberColumn(Dgl1, Col1ReceiveQty, 70, 8, 4, False, Col1ReceiveQty, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1ReceiveMeasure, 70, 8, 4, False, Col1ReceiveMeasure, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 70, 8, 2, False, Col1Rate, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 70, 8, 2, False, Col1Amount, False, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        FrmProductionOrder_BaseFunction_FIniList()
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True

        FrmProductionOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "UPDATE JobIssRec_Log " & _
                " SET " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtManualRefNo.Text) & ", " & _
                " Process = " & AgL.Chk_Text(TxtProcess.AgSelectedValue) & ", " & _
                " JobWorker = " & AgL.Chk_Text(TxtJobWorker.AgSelectedValue) & ", " & _
                " Godown = " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                " JobOrder = " & AgL.Chk_Text(TxtJobOrder.AgSelectedValue) & ", " & _
                " JobWithMaterialYN = " & IIf(AgL.StrCmp(TxtWithMaterialYN.Text, "Yes"), 1, 0) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " IssQty = " & Val(LblTotalIssQty.Text) & ", " & _
                " IssMeasure = " & Val(LblTotalIssMeasure.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From JobIssueDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "INSERT INTO JobIssueDetail_Log(UID, DocId, Sr, Item, StockItem, Qty, Unit, MeasurePerPcs, TotalMeasure, " & _
                        " MeasureUnit, JobOrder, ReceiveQty, ReceiveMeasure, PrevProcess , LotNo, CurrStock, Rate, Amount) " & _
                        " Values (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & "," & _
                        " " & mSr & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1StockItem, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1JobOrder, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1ReceiveQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ReceiveMeasure, I).Value) & "," & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1PrevProcess, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1CurrentStock, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DsTemp As DataSet

        Dgl1.AgHelpDataSet(Col1Item) = HelpDataSet.Item

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select J.* " & _
                " From JobIssRec J " & _
                " Where J.DocID='" & SearchCode & "'"
        Else
            mQry = "Select J.* " & _
                " From JobIssRec_Log J " & _
                " Where J.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()
                TxtGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                TxtManualRefNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtProcess.AgSelectedValue = AgL.XNull(.Rows(0)("Process"))
                TxtJobWorker.AgSelectedValue = AgL.XNull(.Rows(0)("JobWorker"))
                TxtJobOrder.AgSelectedValue = AgL.XNull(.Rows(0)("JobOrder"))
                TxtWithMaterialYN.Text = IIf(AgL.VNull(.Rows(0)("JobWithMaterialYN")) = 0, "No", "Yes")
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalIssQty.Text = AgL.VNull(.Rows(0)("IssQty"))
                LblTotalIssMeasure.Text = AgL.VNull(.Rows(0)("IssMeasure"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))

                If Dgl1.Item(Col1JobOrder, 0).Value <> "" Then
                    TxtForJobOrder.Text = "Yes"
                Else
                    TxtForJobOrder.Text = "No"
                End If


                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from JobIssueDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from JobIssueDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.AgSelectedValue(Col1StockItem, I) = AgL.XNull(.Rows(I)("StockItem"))
                            Dgl1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.".PadRight(CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1LotNo, I).Value = AgL.XNull(.Rows(I)("LotNo"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.AgSelectedValue(Col1PrevProcess, I) = AgL.XNull(.Rows(I)("PrevProcess"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.AgSelectedValue(Col1JobOrder, I) = AgL.XNull(.Rows(I)("JobOrder"))
                            Dgl1.Item(Col1ReceiveQty, I).Value = AgL.VNull(.Rows(I)("ReceiveQty"))
                            Dgl1.Item(Col1ReceiveMeasure, I).Value = AgL.VNull(.Rows(I)("ReceiveMeasure"))
                            Dgl1.Item(Col1ReceiveQty, I).Tag = Dgl1.Item(Col1Qty, I).Value
                            Dgl1.Item(Col1CurrentStock, I).Value = Format(AgL.VNull(.Rows(I)("CurrStock")), "0.".PadRight(CType(Dgl1.Columns(Col1CurrentStock), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.".PadRight(CType(Dgl1.Columns(Col1Rate), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmProductionOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtManualRefNo.Validating, TxtJobWorker.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    IniGrid()

                Case TxtManualRefNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()

                Case TxtJobWorker.Name
                    If sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                        TxtWithMaterialYN.Text = IIf(AgL.VNull(DrTemp(0)("JobWithMaterialYN")) = 0, "No", "Yes")
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()

        TxtProcess.AgSelectedValue = AgL.Dman_Execute(" SELECT H.NCat FROM Process H WHERE H.ProcessIssueNCat = '" & EntryNCat & "' ", AgL.GCn).ExecuteScalar
        mPrevProcess = FunGetPrevProcess(TxtProcess.AgSelectedValue)
        TxtManualRefNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text.ToString
        TxtForJobOrder.Text = "Yes"
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Dgl1.AgHelpDataSet(Col1StockItem, 6) = HelpDataSet.Item
        Dgl1.AgHelpDataSet(Col1Item, 6) = HelpDataSet.Item
        TxtGodown.AgHelpDataSet(4, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Godown
        TxtProcess.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Process
        TxtJobWorker.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.JobWorker
        Dgl1.AgHelpDataSet(Col1JobOrder) = HelpDataSet.JobOrder
        Dgl1.AgHelpDataSet(Col1LotNo, 1) = HelpDataSet.LotNo
        Dgl1.AgHelpDataSet(Col1PrevProcess) = HelpDataSet.Process
        TxtJobOrder.AgHelpDataSet(6, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.JobOrder
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Try
            If Dgl1.CurrentCell Is Nothing Then Exit Sub
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    If AgL.StrCmp(TxtForJobOrder.Text, "Yes") Then
                        Dgl1.AgHelpDataSet(Col1Item, 12) = HelpDataSet.ItemFromJobOrder
                        If RbtPendingItems.Checked Then
                            Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                                " And Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                " And BalanceQty > 0 " & _
                                " And JobWorker = '" & TxtJobWorker.AgSelectedValue & "'"
                        ElseIf RbtAllItemsFromJobOrder.Checked Then
                            Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                                " And Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                " And JobWorker = '" & TxtJobWorker.AgSelectedValue & "'"
                        End If
                    Else
                        If RbtAllItems.Checked Then
                            Dgl1.AgHelpDataSet(Col1Item, 10) = HelpDataSet.Item
                            Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                                " And Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                        ElseIf RbtItemAsPerBOM.Checked Then
                            Dgl1.AgHelpDataSet(Col1Item, 9) = HelpDataSet.ItemAsPerBOM
                            Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " JobWorker = '" & TxtJobWorker.AgSelectedValue & "'"
                        End If
                    End If

                Case Col1LotNo
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1LotNo).Index) = " Item = '" & Dgl1.AgSelectedValue(Col1StockItem, Dgl1.CurrentCell.RowIndex) & "' "

            End Select
        Catch ex As Exception
        End Try
    End Sub


    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
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
                    Dgl1.Item(Col1CurrentStock, mRowIndex).Value = AgTemplate.ClsMain.FunRetStock( _
                            Dgl1.AgSelectedValue(Col1Item, mRowIndex), mInternalCode, , TxtGodown.AgSelectedValue, , _
                            AgTemplate.ClsMain.StockStatus.Standard, TxtV_Date.Text, _
                            Dgl1.Item(Col1LotNo, mRowIndex).Value)


                    If Dgl1.Item(Col1Item, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRowIndex).ToString.Trim = "" Then
                        If AgL.StrCmp(TxtForJobOrder.Text, "Yes") Then
                            Dgl1.AgSelectedValue(Col1JobOrder, mRowIndex) = ""
                            Dgl1.Item(Col1Qty, mRowIndex).Value = 0
                        End If
                    Else
                        If Dgl1.AgDataRow IsNot Nothing Then
                            If AgL.StrCmp(TxtForJobOrder.Text, "Yes") Then
                                Dgl1.AgSelectedValue(Col1JobOrder, mRowIndex) = AgL.XNull(Dgl1.AgDataRow.Cells("JobOrderNo").Value)
                                Dgl1.Item(Col1Qty, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("BalanceQty").Value)
                            ElseIf AgL.StrCmp(TxtForJobOrder.Text, "No") Or TxtForJobOrder.Text = "" Then
                                Dgl1.Item(Col1Qty, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("BalanceQty").Value)
                                Dgl1.AgSelectedValue(Col1JobOrder, mRowIndex) = TxtJobOrder.AgSelectedValue
                            End If
                        End If
                    End If
                    If Dgl1.Item(Col1Qty, mRowIndex).Value < 0 Then Dgl1.Item(Col1Qty, mRowIndex).Value = 0

                Case Col1LotNo
                    Dgl1.Item(Col1CurrentStock, mRowIndex).Value = AgTemplate.ClsMain.FunRetStock( _
                            Dgl1.AgSelectedValue(Col1Item, mRowIndex), mInternalCode, , TxtGodown.AgSelectedValue, , _
                            AgTemplate.ClsMain.StockStatus.Standard, TxtV_Date.Text, _
                            Dgl1.Item(Col1LotNo, mRowIndex).Value)

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try

            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Qty, mRow).Value = 0
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
                Dgl1.Item(Col1JobOrder, mRow).Value = ""
                Dgl1.AgSelectedValue(Col1PrevProcess, mRow) = ""
                Dgl1.Item(Col1Rate, mRow).Value = 0
            Else
                If Dgl1.Item(Col1StockItem, mRow).Value Is Nothing Then Dgl1.Item(Col1StockItem, mRow).Value = ""
                Dgl1.AgSelectedValue(Col1StockItem, mRow) = Dgl1.AgSelectedValue(Col1Item, mRow)            
                If Dgl1.AgDataRow IsNot Nothing Then
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Measure").Value)
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasureUnit").Value)
                    Dgl1.AgSelectedValue(Col1PrevProcess, mRow) = mPrevProcess
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Rate").Value)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalIssQty.Text = 0
        LblTotalIssMeasure.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Dgl1.Item(Col1Amount, I).Value = Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value)

                LblTotalIssQty.Text = Val(LblTotalIssQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalIssMeasure.Text = Val(LblTotalIssMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        LblTotalIssQty.Text = Val(LblTotalIssQty.Text)
        LblTotalIssMeasure.Text = Val(LblTotalIssMeasure.Text)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0, mCurrStock As Double
        Dim DrTemp() As DataRow = Nothing
        If AgL.RequiredField(TxtGodown, LblGodown.Text) Then passed = False : Exit Sub
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) = True Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    mCurrStock = ClsMain.FunRetStock(.AgSelectedValue(Col1Item, I), mInternalCode, , TxtGodown.AgSelectedValue, , ClsMain.StockStatus.Standard, TxtV_Date.Text)
                    If mCurrStock < Val(.Item(Col1Qty, I).Value) Then
                        MsgBox("Qty of " & .Item(Col1Item, I).Value & " In " & TxtGodown.Text & " is less than " & Dgl1.Item(Col1Qty, I).Value & vbCrLf & " Current Stock Is : " & mCurrStock, MsgBoxStyle.Information, "Stock Not Available")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If AgL.StrCmp(TxtForJobOrder.Text, "Yes") Then
                        DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1Item, I) & "' And JobOrderNo = '" & Dgl1.AgSelectedValue(Col1JobOrder, I) & "'")
                        If DrTemp.Length > 0 Then
                            If Val(Dgl1.Item(Col1Qty, I).Value) > AgL.VNull(DrTemp(0)("BalanceQty")) Then
                                If MsgBox("Issued Quantity Is Greater Than Balance Quanty At Row No" & Dgl1.Item(ColSNo, I).Value & ". Do you want to continue?", MsgBoxStyle.YesNo, "Validation") = MsgBoxResult.No Then
                                    .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                                    passed = False : Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End With

        passed = FCheckDuplicateRefNo()
    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True
        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM JobIssRec WHERE ManualRefNo = '" & TxtManualRefNo.Text & "'   " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtManualRefNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM JobIssRec WHERE ManualRefNo = '" & TxtManualRefNo.Text & "'  " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtManualRefNo.Focus()
        End If
    End Function

    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGodown.Enter
        Select Case sender.name
            Case TxtGodown.Name
                TxtGodown.AgRowFilter = " Div_Code = '" & AgL.PubDivCode & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsDeleted = 0 "
            Case TxtJobOrder.Name
                TxtJobOrder.AgRowFilter = " IsDeleted = 0 " & _
                    " And Status = '" & ClsMain.EntryStatus.Active & "' " & _
                    " And " & ClsMain.RetDivFilterStr & " " & _
                    " And JobWorker = '" & TxtJobWorker.AgSelectedValue & "' " & _
                    " And JobOrderDate <= '" & TxtV_Date.Text & "' "
        End Select
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalIssMeasure.Text = 0 : LblTotalIssQty.Text = 0 : LblTotalAmount.Text = 0
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer = 0, mSr As Integer = 0
        Dim Stock As ClsMain.StructStock = Nothing, StockProcess As ClsMain.StructStock = Nothing

        Call ProcUpDateJobOrder(SearchCode, Conn, Cmd)

        mQry = "Delete From Stock Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From StockProcess Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                With Stock
                    .UID = mSearchCode
                    .DocID = mInternalCode
                    .Sr = mSr
                    .V_Type = TxtV_Type.AgSelectedValue
                    .V_Prefix = LblPrefix.Text
                    .V_Date = TxtV_Date.Text
                    .V_No = TxtV_No.Text
                    .Div_Code = TxtDivision.AgSelectedValue
                    .Site_Code = TxtSite_Code.AgSelectedValue
                    .SubCode = TxtJobWorker.AgSelectedValue
                    .Item = Dgl1.AgSelectedValue(Col1StockItem, I)
                    .Process = Dgl1.AgSelectedValue(Col1PrevProcess, I)
                    .Godown = TxtGodown.AgSelectedValue
                    .Qty_Iss = Dgl1.Item(Col1Qty, I).Value
                    .LotNo = Dgl1.Item(Col1LotNo, I).Value
                    .Unit = Dgl1.Item(Col1Unit, I).Value
                    .MeasurePerPcs = Val(Dgl1.Item(Col1MeasurePerPcs, I).Value)
                    .Measure_Iss = Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                    .MeasureUnit = Dgl1.Item(Col1MeasureUnit, I).Value
                    .Status = ClsMain.StockStatus.Standard
                End With
                Call ClsMain.ProcStockPost("Stock", Stock, Conn, Cmd)

                With StockProcess
                    .UID = mSearchCode
                    .DocID = mInternalCode
                    .Sr = mSr
                    .V_Type = TxtV_Type.AgSelectedValue
                    .V_Prefix = LblPrefix.Text
                    .V_Date = TxtV_Date.Text
                    .V_No = TxtV_No.Text
                    .Div_Code = TxtDivision.AgSelectedValue
                    .Site_Code = TxtSite_Code.AgSelectedValue
                    .SubCode = TxtJobWorker.AgSelectedValue
                    .Item = Dgl1.AgSelectedValue(Col1StockItem, I)
                    .Godown = TxtGodown.AgSelectedValue
                    .Qty_Rec = Dgl1.Item(Col1Qty, I).Value
                    .LotNo = Dgl1.Item(Col1LotNo, I).Value
                    .Unit = Dgl1.Item(Col1Unit, I).Value
                    .MeasurePerPcs = Val(Dgl1.Item(Col1MeasurePerPcs, I).Value)
                    .Measure_Rec = Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                    .MeasureUnit = Dgl1.Item(Col1MeasureUnit, I).Value
                    .Status = ClsMain.StockStatus.Standard
                    .Process = TxtProcess.AgSelectedValue
                End With
                Call ClsMain.ProcStockPost("StockProcess", StockProcess, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub TempJobOrder_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Call ProcUpDateJobOrder(SearchCode, Conn, Cmd)

        mQry = "Delete From Stock Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From StockProcess Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub ProcUpDateJobOrder(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        Dim I As Integer = 0
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = " UPDATE JobOrderBOM " & _
                            " SET IssuedQty = (SELECT IsNull(Sum(L.Qty),0)  " & _
                            " 				   FROM JobIssueDetail L " & _
                            " 				   WHERE L.JobOrder = '" & .AgSelectedValue(Col1JobOrder, I) & "' " & _
                            " 				   AND L.Item = '" & .AgSelectedValue(Col1Item, I) & "'), " & _
                            " IssuedMeasure = (SELECT IsNull(Sum(L.TotalMeasure),0)  " & _
                            " 				   FROM JobIssueDetail L " & _
                            "                  LEFT JOIN JOBISSREC H ON H.DocId=L.DocId " & _
                            " 				   WHERE L.JobOrder = '" & .AgSelectedValue(Col1JobOrder, I) & "' " & _
                            " 				   AND L.Item = '" & .AgSelectedValue(Col1Item, I) & "' And IsNull(H.IsDeleted,0)=0 ) " & _
                            " Where DocId = '" & .AgSelectedValue(Col1JobOrder, I) & "' " & _
                            " And Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = "UPDATE JobOrder " & _
                            " SET " & _
                            " LastIssueDate = (SELECT TOP 1 H.V_Date  " & _
                            "                  FROM JobIssueDetail L " & _
                            "                  LEFT JOIN JobIssRec H ON H.DocID = L.DocId " & _
                            "                  WHERE L.JobOrder = '" & .AgSelectedValue(Col1JobOrder, I) & "' " & _
                            "                  ORDER BY H.V_Date DESC) " & _
                            " Where DocId = '" & .AgSelectedValue(Col1JobOrder, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub TempJobIssue_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT I.Code, I.Description As Item, JO.ManualRefNo AS [Order No], " & _
                " J.Qty As JobOrderQty, J.IssuedQty, J.CancelQty, " & _
                " J.Qty - J.IssuedQty - J.CancelQty AS BalanceQty, J.DocId AS JobOrderNo, " & _
                " I.ItemType, I.SalesTaxPostingGroup, J.Unit, J.MeasurePerPcs As Measure, J.MeasureUnit, " & _
                " IsNull(Jo.IsDeleted ,0) AS IsDeleted, " & _
                " IsNull(Jo.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status, Jo.Div_Code, " & _
                " Vt.NCat, Jo.JobWorker, I.Rate  " & _
                " FROM JobOrderBOM J " & _
                " LEFT JOIN Item I On J.Item = I.Code " & _
                " LEFT JOIN JobOrder Jo On J.DocId = Jo.DocId " & _
                " LEFT JOIN Voucher_Type Vt On Jo.V_Type = Vt.V_Type "
        HelpDataSet.ItemFromJobOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, Max(I.Description) AS Item, " & _
                " Sum(IsNull(J.Qty,0) - IsNull(J.IssuedQty,0)  - IsNull(J.CancelQty,0)) AS BalanceQty, " & _
                " Max(Sg.DispName) AS JobWorkerName, " & _
                " Max(I.ItemType) AS ItemType, " & _
                " Max(I.SalesTaxPostingGroup) AS SalesTaxPostingGroup, Max(I.Unit) AS Unit, " & _
                " Max(I.Measure) AS Measure, Max(I.MeasureUnit) AS MeasureUnit, " & _
                " H.JobWorker, '' As JobOrderNo, Max(I.Rate) As Rate " & _
                " FROM JobOrderBOM J  " & _
                " LEFT JOIN JobOrder H ON J.DocId = H.DocID " & _
                " LEFT JOIN SubGroup Sg ON H.JobWorker = Sg.SubCode " & _
                " LEFT JOIN Item I ON J.Item = I.Code " & _
                " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                " WHERE IsNull(H.IsDeleted,0) = 0 " & _
                " GROUP BY H.JobWorker, I.Code "
        HelpDataSet.ItemAsPerBOM = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT I.Code, I.Description AS Item, I.ItemType, I.SalesTaxPostingGroup, I.Unit, " & _
                " I.Measure, I.MeasureUnit, IsNull(I.IsDeleted,0) AS IsDeleted, '' As JobOrderNo, " & _
                " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status , I.Div_Code, " & _
                " 0 As  BalanceQty, I.Rate " & _
                " FROM Item I  "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT G.Code, G.Description, Sm.ManualCode As Site, G.Site_Code, G.Div_Code, IsNull(G.IsDeleted,0) as IsDeleted, " & _
                " IsNull(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
                " FROM Godown G " & _
                " LEFT JOIN SiteMast Sm On G.Site_Code = Sm.Code " & _
                " Order By G.Description"
        HelpDataSet.Godown = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select P.NCat As Code, Vc.NCatDescription As Process, P.Div_Code " & _
                " From Process P " & _
                " LEFT JOIN VoucherCat Vc On P.NCat  = Vc.NCat " & _
                " Order By Vc.NCatDescription "
        HelpDataSet.Process = AgL.FillData(mQry, AgL.GCn)

        'mQry = "SELECT Sg.SubCode AS Code, Sg.DispName AS JobWorker,  " & _
        '        " IsNull(Sg.IsDeleted,0) AS IsDeleted, " & _
        '        " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status, " & _
        '        " Sg.Div_Code, IsNull(H.JobWithMaterialYN,0) AS JobWithMaterialYN " & _
        '        " FROM JobWorker H  " & _
        '        " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode "

        mQry = " SELECT J.SubCode AS Code, Sg.DispName AS JobWorker, H.Process, " & _
                " IsNull(Sg.IsDeleted,0) AS IsDeleted,  " & _
                " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, " & _
                " Sg.Div_Code, IsNull(J.JobWithMaterialYN,0) AS JobWithMaterialYN " & _
                " FROM JobWorker J " & _
                " LEFT JOIN JobWorkerProcess H On J.SubCode = H.SubCode  " & _
                " LEFT JOIN SubGroup Sg ON J.SubCode = Sg.SubCode "
        HelpDataSet.JobWorker = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT J.DocId, J.ManualRefNo As JobOrderNo, " & _
                " IsNull(J.IsDeleted,0) As IsDeleted, J.Div_Code, " & _
                " IsNull(J.Status,'" & ClsMain.EntryStatus.Active & "') As Status, " & _
                " J.JobWorker, Vt.NCat, J.V_Date As JobOrderDate " & _
                " FROM JobOrder J " & _
                " LEFT JOIN Voucher_Type Vt ON J.V_Type = Vt.V_Type "
        HelpDataSet.JobOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT S.LotNo AS Code, S.LotNo, S.Item FROM Stock S WHERE S.LotNo IS NOT NULL  "
        HelpDataSet.LotNo = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function FunGetPrevProcess(ByVal Process As String) As String
        Try
            mQry = " SELECT H.PrevProcess FROM Process H WHERE H.NCat = '" & Process & "' "
            FunGetPrevProcess = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
        Catch ex As Exception
            FunGetPrevProcess = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub TxtJobOrder_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtJobOrder.Enter, TxtJobWorker.Enter
        Try
            Select Case sender.Name
                Case TxtJobOrder.Name
                    TxtJobOrder.AgRowFilter = " IsDeleted = 0 " & _
                                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                        " And " & AgTemplate.ClsMain.RetDivFilterStr() & " " & _
                                        " And JobOrderDate <= '" & TxtV_Date.Text & "'"

                Case TxtJobWorker.Name
                    TxtJobWorker.AgRowFilter = " IsDeleted = 0 " & _
                                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                        " And Process = '" & TxtProcess.AgSelectedValue & "'"

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtForJobOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtForJobOrder.KeyDown
        Try
            If e.KeyCode = Keys.Y Then
                PnlForJobOrderYes.Visible = True
                PnlForJobOrderNo.Visible = False
            ElseIf e.KeyCode = Keys.N Then
                PnlForJobOrderYes.Visible = False
                PnlForJobOrderNo.Visible = True
                PnlForJobOrderNo.Location = PnlForJobOrderYes.Location
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
