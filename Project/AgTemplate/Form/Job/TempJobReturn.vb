Public Class TempJobReturn
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Enum EntryType
        MaterialReturn
        MaterialLossConsidered
        MaterialTransferedToJobOrder
        MaterialRateConversion
    End Enum


    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Protected WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid
    Protected WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1JobOrderDocId As String = "Job Order No"
    Protected Const Col1JobIssueDocId As String = "Job Issue No"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remark As String = "Remark"

    Protected Const AgCalc_NetAmount As String = "NAMT"
    Protected mJobReturnFor$ = ""
    Protected WithEvents TxtToJobOrder As AgControls.AgTextBox
    Protected WithEvents LblToJobOrderReq As System.Windows.Forms.Label
    Protected WithEvents LblToJobOrder As System.Windows.Forms.Label
    Dim mBillPosting As ClsMain.JobReceiveBillPosting = ClsMain.JobReceiveBillPosting.Dues

    Dim mEntryType As EntryType = EntryType.MaterialReturn

    Public Class HelpDataSet
        Public Shared Godown As DataSet = Nothing
        Public Shared Process As DataSet = Nothing
        Public Shared JobWorker As DataSet = Nothing
        Public Shared JobOrder As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared ItemFromJobOrder As DataSet = Nothing
        Public Shared ItemFromJobIssue As DataSet = Nothing
    End Class

    Public Property EntryNature() As EntryType
        Get
            EntryNature = mEntryType
        End Get
        Set(ByVal value As EntryType)
            mEntryType = value
        End Set
    End Property

    Public Property JobReturnFor() As String
        Get
            JobReturnFor = mJobReturnFor
        End Get
        Set(ByVal value As String)
            mJobReturnFor = value
        End Set
    End Property

    Public Property BillPosting() As ClsMain.JobReceiveBillPosting
        Get
            BillPosting = mBillPosting
        End Get
        Set(ByVal value As ClsMain.JobReceiveBillPosting)
            mBillPosting = value
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
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblGodown = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalRecMeasure = New System.Windows.Forms.Label
        Me.LblTotalMeasureText = New System.Windows.Forms.Label
        Me.LblTotalRecQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblGodownReq = New System.Windows.Forms.Label
        Me.TxtManualRefNo = New AgControls.AgTextBox
        Me.LblManualRefNo = New System.Windows.Forms.Label
        Me.LblJobWorkerReq = New System.Windows.Forms.Label
        Me.TxtJobWorker = New AgControls.AgTextBox
        Me.LblJobWorker = New System.Windows.Forms.Label
        Me.TxtProcess = New AgControls.AgTextBox
        Me.LblProcess = New System.Windows.Forms.Label
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.LblJobReceiveDetail = New System.Windows.Forms.LinkLabel
        Me.LblRemark = New System.Windows.Forms.LinkLabel
        Me.TxtToJobOrder = New AgControls.AgTextBox
        Me.LblToJobOrderReq = New System.Windows.Forms.Label
        Me.LblToJobOrder = New System.Windows.Forms.Label
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
        Me.GroupBox2.Location = New System.Drawing.Point(746, 575)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(582, 575)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(415, 575)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 575)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 575)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 571)
        Me.GroupBox1.Size = New System.Drawing.Size(983, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(285, 575)
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
        Me.LblV_No.Location = New System.Drawing.Point(473, 33)
        Me.LblV_No.Size = New System.Drawing.Size(101, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Job Receive No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(598, 32)
        Me.TxtV_No.Size = New System.Drawing.Size(125, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(349, 38)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(237, 33)
        Me.LblV_Date.Size = New System.Drawing.Size(108, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Job Receive Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(582, 18)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(367, 32)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(473, 14)
        Me.LblV_Type.Size = New System.Drawing.Size(109, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Job Receive Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(598, 12)
        Me.TxtV_Type.Size = New System.Drawing.Size(125, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(349, 18)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(237, 13)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(367, 12)
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
        Me.LblPrefix.Location = New System.Drawing.Point(853, 32)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 18)
        Me.TabControl1.Size = New System.Drawing.Size(970, 152)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtToJobOrder)
        Me.TP1.Controls.Add(Me.LblToJobOrderReq)
        Me.TP1.Controls.Add(Me.LblToJobOrder)
        Me.TP1.Controls.Add(Me.TxtManualRefNo)
        Me.TP1.Controls.Add(Me.LblManualRefNo)
        Me.TP1.Controls.Add(Me.TxtProcess)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.LblProcess)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.TxtJobWorker)
        Me.TP1.Controls.Add(Me.LblJobWorker)
        Me.TP1.Controls.Add(Me.LblJobWorkerReq)
        Me.TP1.Controls.Add(Me.TxtGodown)
        Me.TP1.Controls.Add(Me.LblGodownReq)
        Me.TP1.Controls.Add(Me.LblGodown)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(962, 126)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGodownReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblJobWorkerReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblJobWorker, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJobWorker, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProcess, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProcess, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToJobOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToJobOrderReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtToJobOrder, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(965, 41)
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
        Me.TxtGodown.Location = New System.Drawing.Point(367, 92)
        Me.TxtGodown.MaxLength = 20
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(127, 18)
        Me.TxtGodown.TabIndex = 6
        '
        'LblGodown
        '
        Me.LblGodown.AutoSize = True
        Me.LblGodown.BackColor = System.Drawing.Color.Transparent
        Me.LblGodown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGodown.Location = New System.Drawing.Point(237, 93)
        Me.LblGodown.Name = "LblGodown"
        Me.LblGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblGodown.TabIndex = 706
        Me.LblGodown.Text = "Godown"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalRecMeasure)
        Me.Panel1.Controls.Add(Me.LblTotalMeasureText)
        Me.Panel1.Controls.Add(Me.LblTotalRecQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(8, 426)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(948, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalRecMeasure
        '
        Me.LblTotalRecMeasure.AutoSize = True
        Me.LblTotalRecMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalRecMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalRecMeasure.Location = New System.Drawing.Point(424, 3)
        Me.LblTotalRecMeasure.Name = "LblTotalRecMeasure"
        Me.LblTotalRecMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalRecMeasure.TabIndex = 666
        Me.LblTotalRecMeasure.Text = "."
        Me.LblTotalRecMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTotalRecMeasure.Visible = False
        '
        'LblTotalMeasureText
        '
        Me.LblTotalMeasureText.AutoSize = True
        Me.LblTotalMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalMeasureText.Location = New System.Drawing.Point(313, 3)
        Me.LblTotalMeasureText.Name = "LblTotalMeasureText"
        Me.LblTotalMeasureText.Size = New System.Drawing.Size(106, 16)
        Me.LblTotalMeasureText.TabIndex = 665
        Me.LblTotalMeasureText.Text = "Total Measure :"
        Me.LblTotalMeasureText.Visible = False
        '
        'LblTotalRecQty
        '
        Me.LblTotalRecQty.AutoSize = True
        Me.LblTotalRecQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalRecQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalRecQty.Location = New System.Drawing.Point(116, 3)
        Me.LblTotalRecQty.Name = "LblTotalRecQty"
        Me.LblTotalRecQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalRecQty.TabIndex = 660
        Me.LblTotalRecQty.Text = "."
        Me.LblTotalRecQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Pnl1.Location = New System.Drawing.Point(8, 198)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(949, 228)
        Me.Pnl1.TabIndex = 2
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
        Me.TxtRemarks.Location = New System.Drawing.Point(8, 474)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(598, 93)
        Me.TxtRemarks.TabIndex = 2
        '
        'LblGodownReq
        '
        Me.LblGodownReq.AutoSize = True
        Me.LblGodownReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblGodownReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblGodownReq.Location = New System.Drawing.Point(349, 99)
        Me.LblGodownReq.Name = "LblGodownReq"
        Me.LblGodownReq.Size = New System.Drawing.Size(10, 7)
        Me.LblGodownReq.TabIndex = 724
        Me.LblGodownReq.Text = "Ä"
        '
        'TxtManualRefNo
        '
        Me.TxtManualRefNo.AgMandatory = False
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
        Me.TxtManualRefNo.Location = New System.Drawing.Point(367, 52)
        Me.TxtManualRefNo.MaxLength = 50
        Me.TxtManualRefNo.Name = "TxtManualRefNo"
        Me.TxtManualRefNo.Size = New System.Drawing.Size(356, 18)
        Me.TxtManualRefNo.TabIndex = 4
        '
        'LblManualRefNo
        '
        Me.LblManualRefNo.AutoSize = True
        Me.LblManualRefNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualRefNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualRefNo.Location = New System.Drawing.Point(237, 53)
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
        Me.LblJobWorkerReq.Location = New System.Drawing.Point(349, 80)
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
        Me.TxtJobWorker.Location = New System.Drawing.Point(367, 72)
        Me.TxtJobWorker.MaxLength = 20
        Me.TxtJobWorker.Name = "TxtJobWorker"
        Me.TxtJobWorker.Size = New System.Drawing.Size(356, 18)
        Me.TxtJobWorker.TabIndex = 5
        '
        'LblJobWorker
        '
        Me.LblJobWorker.AutoSize = True
        Me.LblJobWorker.BackColor = System.Drawing.Color.Transparent
        Me.LblJobWorker.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJobWorker.Location = New System.Drawing.Point(237, 73)
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
        Me.TxtProcess.Location = New System.Drawing.Point(831, 52)
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
        Me.LblProcess.Location = New System.Drawing.Point(849, 53)
        Me.LblProcess.Name = "LblProcess"
        Me.LblProcess.Size = New System.Drawing.Size(56, 16)
        Me.LblProcess.TabIndex = 737
        Me.LblProcess.Text = "Process"
        Me.LblProcess.Visible = False
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(615, 455)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(341, 113)
        Me.PnlCalcGrid.TabIndex = 725
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
        Me.TxtStructure.Location = New System.Drawing.Point(852, 74)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(43, 18)
        Me.TxtStructure.TabIndex = 742
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(844, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 743
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'LblJobReceiveDetail
        '
        Me.LblJobReceiveDetail.BackColor = System.Drawing.Color.SteelBlue
        Me.LblJobReceiveDetail.DisabledLinkColor = System.Drawing.Color.White
        Me.LblJobReceiveDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJobReceiveDetail.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblJobReceiveDetail.LinkColor = System.Drawing.Color.White
        Me.LblJobReceiveDetail.Location = New System.Drawing.Point(8, 177)
        Me.LblJobReceiveDetail.Name = "LblJobReceiveDetail"
        Me.LblJobReceiveDetail.Size = New System.Drawing.Size(123, 20)
        Me.LblJobReceiveDetail.TabIndex = 733
        Me.LblJobReceiveDetail.TabStop = True
        Me.LblJobReceiveDetail.Text = "Job Return Detail"
        Me.LblJobReceiveDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRemark
        '
        Me.LblRemark.BackColor = System.Drawing.Color.SteelBlue
        Me.LblRemark.DisabledLinkColor = System.Drawing.Color.White
        Me.LblRemark.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblRemark.LinkColor = System.Drawing.Color.White
        Me.LblRemark.Location = New System.Drawing.Point(8, 452)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(79, 20)
        Me.LblRemark.TabIndex = 734
        Me.LblRemark.TabStop = True
        Me.LblRemark.Text = "Remark"
        Me.LblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtToJobOrder
        '
        Me.TxtToJobOrder.AgMandatory = True
        Me.TxtToJobOrder.AgMasterHelp = False
        Me.TxtToJobOrder.AgNumberLeftPlaces = 8
        Me.TxtToJobOrder.AgNumberNegetiveAllow = False
        Me.TxtToJobOrder.AgNumberRightPlaces = 2
        Me.TxtToJobOrder.AgPickFromLastValue = False
        Me.TxtToJobOrder.AgRowFilter = ""
        Me.TxtToJobOrder.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToJobOrder.AgSelectedValue = Nothing
        Me.TxtToJobOrder.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToJobOrder.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtToJobOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToJobOrder.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToJobOrder.Location = New System.Drawing.Point(609, 92)
        Me.TxtToJobOrder.MaxLength = 20
        Me.TxtToJobOrder.Name = "TxtToJobOrder"
        Me.TxtToJobOrder.Size = New System.Drawing.Size(114, 18)
        Me.TxtToJobOrder.TabIndex = 7
        '
        'LblToJobOrderReq
        '
        Me.LblToJobOrderReq.AutoSize = True
        Me.LblToJobOrderReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblToJobOrderReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblToJobOrderReq.Location = New System.Drawing.Point(593, 99)
        Me.LblToJobOrderReq.Name = "LblToJobOrderReq"
        Me.LblToJobOrderReq.Size = New System.Drawing.Size(10, 7)
        Me.LblToJobOrderReq.TabIndex = 746
        Me.LblToJobOrderReq.Text = "Ä"
        '
        'LblToJobOrder
        '
        Me.LblToJobOrder.AutoSize = True
        Me.LblToJobOrder.BackColor = System.Drawing.Color.Transparent
        Me.LblToJobOrder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToJobOrder.Location = New System.Drawing.Point(503, 94)
        Me.LblToJobOrder.Name = "LblToJobOrder"
        Me.LblToJobOrder.Size = New System.Drawing.Size(82, 16)
        Me.LblToJobOrder.TabIndex = 745
        Me.LblToJobOrder.Text = "To Job Order"
        '
        'TempJobReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(965, 616)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.LblJobReceiveDetail)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Name = "TempJobReturn"
        Me.Text = "Template Job Receive"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
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
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.LblJobReceiveDetail, 0)
        Me.Controls.SetChildIndex(Me.LblRemark, 0)
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
    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblGodown As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalRecQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalRecMeasure As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents LblGodownReq As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasureText As System.Windows.Forms.Label
    Protected WithEvents TxtManualRefNo As AgControls.AgTextBox
    Protected WithEvents LblManualRefNo As System.Windows.Forms.Label
    Protected WithEvents TxtProcess As AgControls.AgTextBox
    Protected WithEvents LblProcess As System.Windows.Forms.Label
    Protected WithEvents LblJobWorkerReq As System.Windows.Forms.Label
    Protected WithEvents TxtJobWorker As AgControls.AgTextBox
    Protected WithEvents LblJobWorker As System.Windows.Forms.Label
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents LblJobReceiveDetail As System.Windows.Forms.LinkLabel
    Protected WithEvents LblRemark As System.Windows.Forms.LinkLabel
#End Region

    Private Sub TempJobReturn_BaseEvent_Approve_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Approve_PostTrans

    End Sub

    Private Sub Frm_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "JobIssRec"
        LogTableName = "JobIssRec_Log"
        MainLineTableCsv = "JobReceiveDetail,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "JobReceiveDetail_Log,Structure_TransFooter_Log,Structure_TransLine_Log"
        AgL.GridDesign(Dgl1)

        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = " SELECT J.UID as SearchCode, Vt.Description AS [Entry Type], " & _
        '                    " J.V_Date AS [Entry Date], J.V_No AS [Entry No], " & _
        '                    " J.ManualRefNo, J.DueDate " & _
        '                    " FROM JobIssRec_Log J " & _
        '                    " LEFT JOIN voucher_type Vt ON J.V_Type = Vt.V_Type " & _
        '                    " Where J.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  " & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Return Type], H.V_Prefix AS Prefix, H.V_Date AS Date, H.V_No AS [Return No], " & _
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

        'AgL.PubFindQry = " SELECT J.DocID as SearchCode, Vt.Description AS [Entry Type], " & _
        '                    " J.V_Date AS [Entry Date], J.V_No AS [Entry No], " & _
        '                    " J.ManualRefNo, J.DueDate " & _
        '                    " FROM JobIssRec J " & _
        '                    " LEFT JOIN voucher_type Vt ON J.V_Type = Vt.V_Type " & _
        '                    " Where 1=1  " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Return Type], H.V_Prefix AS Prefix, H.V_Date AS Date, H.V_No AS [Return No], " & _
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
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 70, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 70, 0, Col1MeasureUnit, True, True)
            .AddAgTextColumn(Dgl1, Col1JobOrderDocId, 100, 0, Col1JobOrderDocId, True, True)
            .AddAgTextColumn(Dgl1, Col1JobIssueDocId, 100, 0, Col1JobIssueDocId, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 70, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 70, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(Dgl1, Col1Remark, 200, 255, Col1Remark, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        FrmProductionOrder_BaseFunction_FIniList()
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True

        AgCalcGrid1.Ini_Grid(mSearchCode)
        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index

        FrmProductionOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        Dim Stock As AgTemplate.ClsMain.StructStock = Nothing, StockProcess As AgTemplate.ClsMain.StructStock = Nothing

        mQry = "UPDATE JobIssRec_Log " & _
                " SET " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtManualRefNo.Text) & ", " & _
                " Process = " & AgL.Chk_Text(TxtProcess.AgSelectedValue) & ", " & _
                " JobWorker = " & AgL.Chk_Text(TxtJobWorker.AgSelectedValue) & ", " & _
                " Godown = " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " RecQty = " & Val(LblTotalRecQty.Text) & ", " & _
                " RecMeasure = " & Val(LblTotalRecMeasure.Text) & ", " & _
                " JobReceiveFor = " & AgL.Chk_Text(mJobReturnFor) & ",  " & _
                " ToJobOrder = " & AgL.Chk_Text(TxtToJobOrder.AgSelectedValue) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From JobReceiveDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "INSERT INTO JobReceiveDetail_Log(UID, DocId, Sr, Item, Qty, Unit, MeasurePerPcs, TotalMeasure, " & _
                        " MeasureUnit, JobOrder, Rate, Amount, Remark, JobIssueDocId) " & _
                        " Values (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & "," & _
                        " " & mSr & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1JobOrderDocId, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1JobIssueDocId, I)) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


                If EntryNature = EntryType.MaterialTransferedToJobOrder Then
                    mQry = "INSERT INTO JobIssueDetail_Log(UID, DocId, Sr, Item, Qty, Unit, MeasurePerPcs, TotalMeasure, " & _
                            " MeasureUnit, JobOrder, Rate, Amount) " & _
                            " Values (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & "," & _
                            " " & mSr & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                            " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                            " " & AgL.Chk_Text(TxtToJobOrder.AgSelectedValue) & ", " & _
                            " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1Amount, I).Value) & ") "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                End If

                AgCalcGrid1.Save_TransLine(mInternalCode, mSr, I, Conn, Cmd, SearchCode)
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
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                IniGrid()

                TxtGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                TxtManualRefNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtProcess.AgSelectedValue = AgL.XNull(.Rows(0)("Process"))
                TxtJobWorker.AgSelectedValue = AgL.XNull(.Rows(0)("JobWorker"))
                TxtToJobOrder.AgSelectedValue = AgL.XNull(.Rows(0)("ToJobOrder"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalRecQty.Text = AgL.VNull(.Rows(0)("IssQty"))
                LblTotalRecMeasure.Text = AgL.VNull(.Rows(0)("IssMeasure"))

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from JobReceiveDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from JobReceiveDetail_Log where UID = '" & SearchCode & "' Order By Sr"
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
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.AgSelectedValue(Col1JobOrderDocId, I) = AgL.XNull(.Rows(I)("JobOrder"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            Dgl1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                            Dgl1.AgSelectedValue(Col1JobIssueDocId, I) = AgL.XNull(.Rows(I)("JobIssueDocId"))

                            AgCalcGrid1.MoveRec_TransLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
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
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtManualRefNo.Validating
        Select Case sender.NAME
            Case TxtV_Type.Name
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                IniGrid()
            Case TxtManualRefNo.Name
                e.Cancel = Not FCheckDuplicateRefNo()
        End Select
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        If mJobReturnFor = "" Then MsgBox("Job Return Property Is Not Set", MsgBoxStyle.Exclamation) : Topctrl1.FButtonClick(14, True)
        'If mBillPosting = ClsMain.JobReceiveBillPosting.None Then MsgBox("Bill Posting Property Is Not Set", MsgBoxStyle.Exclamation) : Topctrl1.FButtonClick(14, True)
        TxtProcess.AgSelectedValue = AgL.Dman_Execute(" SELECT H.NCat FROM Process H WHERE H.ProcessReturnNCat = '" & EntryNCat & "' ", AgL.GCn).ExecuteScalar
        TxtManualRefNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text.ToString
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtGodown.AgHelpDataSet(4, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Godown
        TxtProcess.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Process
        TxtJobWorker.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.JobWorker
        Dgl1.AgHelpDataSet(Col1JobOrderDocId, 5) = HelpDataSet.JobOrder
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtToJobOrder.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.JobOrder
        IniItemHelpList()
    End Sub

    Protected Sub IniItemHelpList()
        Try
            If AgL.StrCmp(mJobReturnFor, AgTemplate.ClsMain.JobReceiveFor.JobOrder) Then
                Dgl1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.ItemFromJobOrder
            Else
                Dgl1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.ItemFromJobIssue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0  " & _
                    " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
        End Select
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

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
                Dgl1.AgSelectedValue(Col1JobOrderDocId, mRow) = ""
                Dgl1.AgSelectedValue(Col1JobIssueDocId, mRow) = ""
            Else
                If Dgl1.AgDataRow IsNot Nothing Then
                    Dgl1.Item(Col1Qty, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("BalanceQty").Value)
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Rate").Value)
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Measure").Value)
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasureUnit").Value)
                    Dgl1.AgSelectedValue(Col1JobOrderDocId, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("JobOrderDocId").Value)
                    Dgl1.AgSelectedValue(Col1JobIssueDocId, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("JobIssueDocId").Value)
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

        LblTotalRecQty.Text = 0
        LblTotalRecMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.000")
                Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                LblTotalRecQty.Text = Val(LblTotalRecQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalRecMeasure.Text = Val(LblTotalRecMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalRecQty.Text = Format(Val(LblTotalRecQty.Text), "0.000")
        LblTotalRecMeasure.Text = Format(Val(LblTotalRecMeasure.Text), "0.000")
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        Dim DrTemp() As DataRow

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) = True Then passed = False : Exit Sub

        passed = FCheckDuplicateRefNo()

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If

                DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1Item, I) & "'")
                If Val(.Item(Col1Qty, I).Value) > 0 Then
                    If AgL.VNull(Dgl1.Item(Col1Qty, I).Value) > AgL.VNull(DrTemp(0)("BalanceQty")) Then
                        If MsgBox("Quantity Is Greater Than Balance Qty At Row No" & Dgl1.Item(ColSNo, I).Value & ".Do You Want To Continue.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                            .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                            passed = False : Exit Sub
                        End If
                    End If
                End If
            Next
        End With
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

    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGodown.Enter, TxtToJobOrder.Enter, TxtJobWorker.Enter
        Select Case sender.name
            Case TxtGodown.Name
                TxtGodown.AgRowFilter = " Div_Code = '" & AgL.PubDivCode & "' " & _
                        " And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' " & _
                        " And IsDeleted = 0 "

            Case TxtToJobOrder.Name
                TxtToJobOrder.AgRowFilter = " IsDeleted = 0 " & _
                    " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & _
                    " And " & AgTemplate.ClsMain.RetDivFilterStr & " " & _
                    " And JobWorker = '" & TxtJobWorker.AgSelectedValue & "' " & _
                    " And V_date <= '" & TxtV_Date.Text & "'"

            Case TxtJobWorker.Name
                TxtJobWorker.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And Process = '" & TxtProcess.AgSelectedValue & "' "

        End Select
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalRecMeasure.Text = 0 : LblTotalRecQty.Text = 0
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        Dim Stock As AgTemplate.ClsMain.StructStock = Nothing, StockProcess As AgTemplate.ClsMain.StructStock = Nothing
        Dim StructDues As ClsMain.Dues = Nothing, StructToBeBiiled As ClsMain.ToBeBilled = Nothing

        Call ProcUpDateJobOrder(SearchCode, Conn, Cmd)

        mQry = "Delete From Stock Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From StockProcess Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                If EntryNature = EntryType.MaterialReturn Then
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
                        .Item = Dgl1.AgSelectedValue(Col1Item, I)
                        .Godown = TxtGodown.AgSelectedValue
                        .Qty_Rec = Dgl1.Item(Col1Qty, I).Value
                        .Unit = Dgl1.Item(Col1Unit, I).Value
                        .MeasurePerPcs = Dgl1.Item(Col1MeasurePerPcs, I).Value
                        .Measure_Rec = Dgl1.Item(Col1TotalMeasure, I).Value
                        .MeasureUnit = Dgl1.Item(Col1MeasureUnit, I).Value
                        .Status = AgTemplate.ClsMain.StockStatus.Standard
                        .Rate = Dgl1.Item(Col1Rate, I).Value
                        .Amount = Dgl1.Item(Col1Amount, I).Value
                        .Process = TxtProcess.AgSelectedValue
                    End With
                    Call AgTemplate.ClsMain.ProcStockPost("Stock", Stock, Conn, Cmd)
                End If

                If EntryNature = EntryType.MaterialLossConsidered Or EntryNature = EntryType.MaterialReturn Or EntryNature = EntryType.MaterialRateConversion Then
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
                        .Item = Dgl1.AgSelectedValue(Col1Item, I)
                        .Godown = TxtGodown.AgSelectedValue
                        .Qty_Iss = Dgl1.Item(Col1Qty, I).Value
                        .Unit = Dgl1.Item(Col1Unit, I).Value
                        .MeasurePerPcs = Dgl1.Item(Col1MeasurePerPcs, I).Value
                        .Measure_Iss = Dgl1.Item(Col1TotalMeasure, I).Value
                        .MeasureUnit = Dgl1.Item(Col1MeasureUnit, I).Value
                        .Status = AgTemplate.ClsMain.StockStatus.Standard
                        .Process = TxtProcess.AgSelectedValue
                        .Rate = Dgl1.Item(Col1Rate, I).Value
                        .Amount = Dgl1.Item(Col1Amount, I).Value
                    End With
                    Call AgTemplate.ClsMain.ProcStockPost("StockProcess", StockProcess, Conn, Cmd)
                End If
            End If
        Next

        If EntryNature = EntryType.MaterialRateConversion Then
            Call ProcPostInPayment(Conn, Cmd)
        End If
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
        Dim bTableName$ = "", bDocId$ = ""

        If AgL.StrCmp(mJobReturnFor, AgTemplate.ClsMain.JobReceiveFor.JobOrder) Then
            bTableName = "JobOrderBOM"
            bDocId = Dgl1.AgSelectedValue(Col1JobOrderDocId, I)
        Else
            bTableName = "JobIssueDetail"
            bDocId = Dgl1.AgSelectedValue(Col1JobIssueDocId, I)
        End If

        With Dgl1
            For I = 0 To .RowCount - 1
                If AgL.StrCmp(mJobReturnFor, AgTemplate.ClsMain.JobReceiveFor.JobOrder) Then
                    bDocId = Dgl1.AgSelectedValue(Col1JobOrderDocId, I)
                Else
                    bDocId = Dgl1.AgSelectedValue(Col1JobIssueDocId, I)
                End If
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = " UPDATE " & bTableName & " " & _
                            " SET ReturnQty = (SELECT IsNull(Sum(L.Qty),0)  " & _
                            " 				   FROM JobReceiveDetail L With (NoLock) " & _
                            "                  LEFT JOIN JobIssRec H With (NoLock) On L.DocId = H.DocId " & _
                            "                  LEFT JOIN Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                            " 				   WHERE Vt.NCat = '" & EntryNCat & "'  " & _
                            "                  And L.JobOrder = '" & bDocId & "' " & _
                            " 				   And L.Item = '" & .AgSelectedValue(Col1Item, I) & "'), " & _
                            " ReturnMeasure = (SELECT IsNull(Sum(L.TotalMeasure),0)  " & _
                            " 				   FROM JobReceiveDetail L With (NoLock) " & _
                            "                  LEFT JOIN JobIssRec H With (NoLock) On L.DocId = H.DocId " & _
                            "                  LEFT JOIN Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                            " 				   WHERE Vt.NCat = '" & EntryNCat & "'  " & _
                            " 				   And L.JobOrder = '" & bDocId & "' " & _
                            " 				   And L.Item = '" & .AgSelectedValue(Col1Item, I) & "' ) " & _
                            " Where DocId = '" & bDocId & "' " & _
                            " And Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub TempJobReceive_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
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

        'mQry = "SELECT S.SubCode AS Code, S.Name  AS JobWorker " & _
        '      " FROM JobWorker J " & _
        '      " LEFT JOIN SubGroup S ON J.SubCode = S.SubCode "

        mQry = " SELECT J.SubCode AS Code, Sg.DispName AS JobWorker, H.Process, " & _
                " IsNull(Sg.IsDeleted,0) AS IsDeleted,  " & _
                " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM JobWorker J " & _
                " LEFT JOIN JobWorkerProcess H On J.SubCode = H.SubCode  " & _
                " LEFT JOIN SubGroup Sg ON J.SubCode = Sg.SubCode "
        HelpDataSet.JobWorker = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT J.DocId, J.ManualRefNo, " & _
                " IsNull(J.IsDeleted,0) AS IsDeleted, " & _
                " IsNull(J.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, " & _
                " J.Div_Code, J.JobWorker, J.V_Date " & _
                " FROM JobOrder J " & _
                " LEFT JOIN Voucher_Type Vt ON J.V_Type = Vt.V_Type "
        HelpDataSet.JobOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT I.Code AS Code, I.Description AS Item, H.ManualRefNo As JobOrderNo, " & _
                " IsNull(L.Qty,0) - IsNull(L.ReturnQty,0) AS BalanceQty, " & _
                " '' As JobIssueDocId, L.DocId AS JobOrderDocId, I.ItemType, I.SalesTaxPostingGroup,  " & _
                " L.Unit, L.MeasurePerPcs AS Measure, L.MeasureUnit, I.Rate,  " & _
                " IsNull(H.IsDeleted,0) AS IsDeleted, " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status, " & _
                " H.Div_Code, Vt.NCat, H.JobWorker " & _
                " FROM JobOrderBom L  " & _
                " LEFT JOIN Item I ON L.Item = I.Code " & _
                " LEFT JOIN JobOrder H ON L.DocId = H.DocID " & _
                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type "
        HelpDataSet.ItemFromJobOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description AS Item, H.ManualRefNo As JobIssueNo, " & _
                " IsNull(L.Qty,0) - IsNull(L.ReturnQty,0)  AS BalanceQty,  " & _
                " L.DocId AS JobIssueDocId, '' As JobOrderDocId, I.ItemType, " & _
                " I.SalesTaxPostingGroup, L.Unit, L.MeasurePerPcs As Measure,    " & _
                " L.MeasureUnit, I.Rate ,  IsNull(H.IsDeleted ,0) AS IsDeleted,   " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,  " & _
                " H.Div_Code, Vt.NCat, H.JobWorker    " & _
                " FROM JobIssueDetail L  " & _
                " LEFT JOIN Item I ON L.Item = I.Code " & _
                " LEFT JOIN JobIssRec H ON L.DocId = H.DocID " & _
                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type   "
        HelpDataSet.ItemFromJobIssue = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT  H.Code, H.Description, H.Unit, H.ItemType, H.IsDeleted, " & _
                " H.UpcCode, H.Bom, H.Status, " & _
                " H.Div_Code, H.SalesTaxPostingGroup, H.Measure, H.MeasureUnit, " & _
                " H.ItemGroup, H.Rate " & _
                " FROM Item H "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)


    End Sub

    Private Sub ProcPostInPayment(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        mQry = "Delete From DuesPayment Where DocID = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From DuesPaymentDetail Where DocID = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " INSERT INTO DuesPayment(DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                " ManualRefNo, TransactionType,  NetAmount,  " & _
                " Remark, EntryBy, EntryDate, EntryType, EntryStatus, " & _
                " Status) " & _
                " VALUES ('" & mInternalCode & "',	" & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(LblPrefix.Text) & ",	" & AgL.Chk_Text(TxtV_Date.Text) & ",	" & _
                " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtManualRefNo.Text) & ", '" & ClsMain.PaymentReceiptType.DebitNote & "' , " & _
                " " & Val(AgCalcGrid1.AgChargesValue(AgCalc_NetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                " " & AgL.Chk_Text(Topctrl1.Mode) & ",	" & AgL.Chk_Text(LogStatus.LogOpen) & ", " & _
                " " & AgL.Chk_Text(TxtStatus.Text) & ") "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        mQry = "Insert Into DuesPaymentDetail( " & _
                "DocId, " & _
                "Sr, " & _
                "TransactionType, " & _
                "Subcode, " & _
                "NetAmount, " & _
                "Remark " & _
                ") " & _
                " Values( " & _
                " " & AgL.Chk_Text(mInternalCode) & ", " & _
                " 1, " & _
                " '" & ClsMain.PaymentReceiptType.DebitNote & "' , " & _
                " " & AgL.Chk_Text(TxtJobWorker.AgSelectedValue) & ", " & _
                " " & Val(AgCalcGrid1.AgChargesValue(AgCalc_NetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " )"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        Call AccountPosting()

    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec
        Dim I As Integer, J As Integer = 0
        Dim DsTemp As DataSet = Nothing
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mNetAmount As Double, mRoundOff As Double = 0
        Dim bDebitNoteAc$ = ""

        mQry = " Select DebitNoteAc From DuesPaymentEnviro With (NoLock) "
        bDebitNoteAc = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar


        Dim GcnRead As SqlClient.SqlConnection
        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        mNetAmount = 0
        mCommonNarr = ""
        mCommonNarr = TxtRemarks.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)
        mNarr = TxtRemarks.Text
        If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

        ReDim Preserve LedgAry(I)

        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = TxtJobWorker.AgSelectedValue
        LedgAry(I).ContraSub = bDebitNoteAc
        LedgAry(I).AmtCr = 0
        LedgAry(I).AmtDr = Val(AgCalcGrid1.AgChargesValue(AgCalc_NetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
        mNarr = TxtRemarks.Text
        LedgAry(I).Narration = mNarr

        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = bDebitNoteAc
        LedgAry(I).ContraSub = TxtJobWorker.AgSelectedValue
        LedgAry(I).AmtCr = Val(AgCalcGrid1.AgChargesValue(AgCalc_NetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
        LedgAry(I).AmtDr = 0
        LedgAry(I).Narration = mNarr

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mInternalCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If
        GcnRead.Close()
        GcnRead.Dispose()
    End Function
End Class
