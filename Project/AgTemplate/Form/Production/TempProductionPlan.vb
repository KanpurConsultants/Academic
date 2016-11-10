Imports CrystalDecisions.CrystalReports.Engine
Public Class TempProductionPlan
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Qty As String = "Production Order Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1StkQty_Finished As String = "Stock In Hand Finished"
    Protected Const Col1StkQty_SemiFinished As String = "Stock In Hand Semi Finished"
    Protected Const Col1PendingPurchaseOrderQty As String = "Pending Purchase Order Qty"
    Protected Const Col1StkQtyReq_OpenSaleOrder As String = "Stock Required For Open Orders"
    Protected Const Col1ExcessQty_Finished As String = "Excess Stock Finished"
    Protected Const Col1ExcessQty_SemiFinished As String = "Excess Stock Semi Finished"
    Protected Const Col1ComputerProdPlanQty As String = "Computer Plan Qty"
    Protected Const Col1ComputerProdPlanMeasure As String = "Computer Plan Measure"
    Protected Const Col1UserPurchPlanQty As String = "User Purch Plan Qty"
    Protected Const Col1UserPurchPlanMeasure As String = "User Purch Plan Measure"
    Protected Const Col1UserProdPlanQty As String = "User Prod Plan Qty"
    Protected Const Col1UserProdPlanMeasure As String = "User Prod Plan Measure"
    Protected Const Col1UserProdPlanRemarks As String = "User Prod Plan Remarks"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "MeasureUnit"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1ProdIssQty As String = "Prod Iss Qty"
    Protected Const Col1ProdIssMeasure As String = "Prod Iss Measure"
    Protected Const Col1ProdRecQty As String = "Prod Rec Qty"
    Protected Const Col1ProdRecMeasure As String = "Prod Rec Measure"
    Protected Const Col1PurchOrdQty As String = "Purch Ord Qty"
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents BtnFillDeatil As System.Windows.Forms.Button
    Protected Const Col1PurchQty As String = "Purch Qty"




    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtProductionOrderNo = New AgControls.AgTextBox
        Me.LblProductionOrderNo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblTotalComputerProdPlanQty = New System.Windows.Forms.Label
        Me.LblTotalComputerProdPlanQtyText = New System.Windows.Forms.Label
        Me.LblTotalUserPurchPlanQty = New System.Windows.Forms.Label
        Me.LblTotalUserPurchPlanQtyText = New System.Windows.Forms.Label
        Me.LblTotalUserProdPlanQty = New System.Windows.Forms.Label
        Me.LblTotalUserProdPlanQtyText = New System.Windows.Forms.Label
        Me.LblTotalUserProdPlanMeasure = New System.Windows.Forms.Label
        Me.LblTotalUserProdPlanMeasureText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblProductionOrderNoReq = New System.Windows.Forms.Label
        Me.LblDueDateReq = New System.Windows.Forms.Label
        Me.TxtDueDate = New AgControls.AgTextBox
        Me.LblDueDate = New System.Windows.Forms.Label
        Me.LblTotalUserPurchPlanMeasure = New System.Windows.Forms.Label
        Me.LblTotalUserPurchPlanMeasureText = New System.Windows.Forms.Label
        Me.LblTotalComputerProdPlanMeasure = New System.Windows.Forms.Label
        Me.LblTotalComputerProdPlanMeasureText = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.BtnFillDeatil = New System.Windows.Forms.Button
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
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 556)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 556)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 556)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 556)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 556)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 552)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 556)
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
        Me.LblV_No.Location = New System.Drawing.Point(485, 38)
        Me.LblV_No.Size = New System.Drawing.Size(58, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Plan No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(607, 37)
        Me.TxtV_No.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(363, 43)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(227, 39)
        Me.LblV_Date.Size = New System.Drawing.Size(65, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Plan Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(591, 23)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(379, 37)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(485, 19)
        Me.LblV_Type.Size = New System.Drawing.Size(66, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Plan Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(607, 17)
        Me.TxtV_Type.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(363, 23)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(227, 19)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(379, 17)
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
        Me.LblPrefix.Location = New System.Drawing.Point(545, 38)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 18)
        Me.TabControl1.Size = New System.Drawing.Size(990, 139)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.LblDueDateReq)
        Me.TP1.Controls.Add(Me.TxtDueDate)
        Me.TP1.Controls.Add(Me.LblDueDate)
        Me.TP1.Controls.Add(Me.LblProductionOrderNoReq)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtProductionOrderNo)
        Me.TP1.Controls.Add(Me.LblProductionOrderNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(982, 113)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProductionOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProductionOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProductionOrderNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDueDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDueDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDueDateReq, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
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
        'TxtProductionOrderNo
        '
        Me.TxtProductionOrderNo.AgMandatory = True
        Me.TxtProductionOrderNo.AgMasterHelp = False
        Me.TxtProductionOrderNo.AgNumberLeftPlaces = 8
        Me.TxtProductionOrderNo.AgNumberNegetiveAllow = False
        Me.TxtProductionOrderNo.AgNumberRightPlaces = 2
        Me.TxtProductionOrderNo.AgPickFromLastValue = False
        Me.TxtProductionOrderNo.AgRowFilter = ""
        Me.TxtProductionOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProductionOrderNo.AgSelectedValue = Nothing
        Me.TxtProductionOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProductionOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProductionOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProductionOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProductionOrderNo.Location = New System.Drawing.Point(379, 57)
        Me.TxtProductionOrderNo.MaxLength = 20
        Me.TxtProductionOrderNo.Name = "TxtProductionOrderNo"
        Me.TxtProductionOrderNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtProductionOrderNo.TabIndex = 4
        '
        'LblProductionOrderNo
        '
        Me.LblProductionOrderNo.AutoSize = True
        Me.LblProductionOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblProductionOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductionOrderNo.Location = New System.Drawing.Point(227, 58)
        Me.LblProductionOrderNo.Name = "LblProductionOrderNo"
        Me.LblProductionOrderNo.Size = New System.Drawing.Size(130, 16)
        Me.LblProductionOrderNo.TabIndex = 706
        Me.LblProductionOrderNo.Text = "Production Order No."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LblTotalComputerProdPlanQty)
        Me.Panel1.Controls.Add(Me.LblTotalComputerProdPlanQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalUserPurchPlanQty)
        Me.Panel1.Controls.Add(Me.LblTotalUserPurchPlanQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalUserProdPlanQty)
        Me.Panel1.Controls.Add(Me.LblTotalUserProdPlanQtyText)
        Me.Panel1.Location = New System.Drawing.Point(4, 500)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 25)
        Me.Panel1.TabIndex = 694
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(4, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 701
        Me.Label4.Text = "Totals :"
        '
        'LblTotalComputerProdPlanQty
        '
        Me.LblTotalComputerProdPlanQty.AutoSize = True
        Me.LblTotalComputerProdPlanQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComputerProdPlanQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalComputerProdPlanQty.Location = New System.Drawing.Point(340, 3)
        Me.LblTotalComputerProdPlanQty.Name = "LblTotalComputerProdPlanQty"
        Me.LblTotalComputerProdPlanQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalComputerProdPlanQty.TabIndex = 670
        Me.LblTotalComputerProdPlanQty.Text = "."
        Me.LblTotalComputerProdPlanQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalComputerProdPlanQtyText
        '
        Me.LblTotalComputerProdPlanQtyText.AutoSize = True
        Me.LblTotalComputerProdPlanQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComputerProdPlanQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalComputerProdPlanQtyText.Location = New System.Drawing.Point(131, 3)
        Me.LblTotalComputerProdPlanQtyText.Name = "LblTotalComputerProdPlanQtyText"
        Me.LblTotalComputerProdPlanQtyText.Size = New System.Drawing.Size(170, 16)
        Me.LblTotalComputerProdPlanQtyText.TabIndex = 669
        Me.LblTotalComputerProdPlanQtyText.Text = "Computer Prod Plan Qty :"
        '
        'LblTotalUserPurchPlanQty
        '
        Me.LblTotalUserPurchPlanQty.AutoSize = True
        Me.LblTotalUserPurchPlanQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserPurchPlanQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalUserPurchPlanQty.Location = New System.Drawing.Point(656, 3)
        Me.LblTotalUserPurchPlanQty.Name = "LblTotalUserPurchPlanQty"
        Me.LblTotalUserPurchPlanQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalUserPurchPlanQty.TabIndex = 668
        Me.LblTotalUserPurchPlanQty.Text = "."
        Me.LblTotalUserPurchPlanQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalUserPurchPlanQtyText
        '
        Me.LblTotalUserPurchPlanQtyText.AutoSize = True
        Me.LblTotalUserPurchPlanQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserPurchPlanQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalUserPurchPlanQtyText.Location = New System.Drawing.Point(479, 3)
        Me.LblTotalUserPurchPlanQtyText.Name = "LblTotalUserPurchPlanQtyText"
        Me.LblTotalUserPurchPlanQtyText.Size = New System.Drawing.Size(143, 16)
        Me.LblTotalUserPurchPlanQtyText.TabIndex = 667
        Me.LblTotalUserPurchPlanQtyText.Text = "User Purch Plan Qty :"
        '
        'LblTotalUserProdPlanQty
        '
        Me.LblTotalUserProdPlanQty.AutoSize = True
        Me.LblTotalUserProdPlanQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserProdPlanQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalUserProdPlanQty.Location = New System.Drawing.Point(906, 3)
        Me.LblTotalUserProdPlanQty.Name = "LblTotalUserProdPlanQty"
        Me.LblTotalUserProdPlanQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalUserProdPlanQty.TabIndex = 660
        Me.LblTotalUserProdPlanQty.Text = "."
        Me.LblTotalUserProdPlanQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalUserProdPlanQtyText
        '
        Me.LblTotalUserProdPlanQtyText.AutoSize = True
        Me.LblTotalUserProdPlanQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserProdPlanQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalUserProdPlanQtyText.Location = New System.Drawing.Point(732, 3)
        Me.LblTotalUserProdPlanQtyText.Name = "LblTotalUserProdPlanQtyText"
        Me.LblTotalUserProdPlanQtyText.Size = New System.Drawing.Size(136, 16)
        Me.LblTotalUserProdPlanQtyText.TabIndex = 659
        Me.LblTotalUserProdPlanQtyText.Text = "User Prod Plan Qty :"
        '
        'LblTotalUserProdPlanMeasure
        '
        Me.LblTotalUserProdPlanMeasure.AutoSize = True
        Me.LblTotalUserProdPlanMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserProdPlanMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalUserProdPlanMeasure.Location = New System.Drawing.Point(906, 3)
        Me.LblTotalUserProdPlanMeasure.Name = "LblTotalUserProdPlanMeasure"
        Me.LblTotalUserProdPlanMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalUserProdPlanMeasure.TabIndex = 666
        Me.LblTotalUserProdPlanMeasure.Text = "."
        Me.LblTotalUserProdPlanMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalUserProdPlanMeasureText
        '
        Me.LblTotalUserProdPlanMeasureText.AutoSize = True
        Me.LblTotalUserProdPlanMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserProdPlanMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalUserProdPlanMeasureText.Location = New System.Drawing.Point(732, 3)
        Me.LblTotalUserProdPlanMeasureText.Name = "LblTotalUserProdPlanMeasureText"
        Me.LblTotalUserProdPlanMeasureText.Size = New System.Drawing.Size(169, 16)
        Me.LblTotalUserProdPlanMeasureText.TabIndex = 665
        Me.LblTotalUserProdPlanMeasureText.Text = "User Prod Plan Measure :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 185)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(972, 314)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(227, 78)
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
        Me.TxtRemarks.Location = New System.Drawing.Point(379, 77)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.TabIndex = 6
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(771, 161)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(56, 23)
        Me.BtnFill.TabIndex = 7
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblProductionOrderNoReq
        '
        Me.LblProductionOrderNoReq.AutoSize = True
        Me.LblProductionOrderNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblProductionOrderNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblProductionOrderNoReq.Location = New System.Drawing.Point(363, 63)
        Me.LblProductionOrderNoReq.Name = "LblProductionOrderNoReq"
        Me.LblProductionOrderNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblProductionOrderNoReq.TabIndex = 729
        Me.LblProductionOrderNoReq.Text = "Ä"
        '
        'LblDueDateReq
        '
        Me.LblDueDateReq.AutoSize = True
        Me.LblDueDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDueDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDueDateReq.Location = New System.Drawing.Point(591, 63)
        Me.LblDueDateReq.Name = "LblDueDateReq"
        Me.LblDueDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDueDateReq.TabIndex = 732
        Me.LblDueDateReq.Text = "Ä"
        '
        'TxtDueDate
        '
        Me.TxtDueDate.AgMandatory = True
        Me.TxtDueDate.AgMasterHelp = True
        Me.TxtDueDate.AgNumberLeftPlaces = 8
        Me.TxtDueDate.AgNumberNegetiveAllow = False
        Me.TxtDueDate.AgNumberRightPlaces = 2
        Me.TxtDueDate.AgPickFromLastValue = False
        Me.TxtDueDate.AgRowFilter = ""
        Me.TxtDueDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDueDate.AgSelectedValue = Nothing
        Me.TxtDueDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDueDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDueDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDueDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDueDate.Location = New System.Drawing.Point(607, 57)
        Me.TxtDueDate.MaxLength = 20
        Me.TxtDueDate.Name = "TxtDueDate"
        Me.TxtDueDate.Size = New System.Drawing.Size(149, 18)
        Me.TxtDueDate.TabIndex = 5
        '
        'LblDueDate
        '
        Me.LblDueDate.AutoSize = True
        Me.LblDueDate.BackColor = System.Drawing.Color.Transparent
        Me.LblDueDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDueDate.Location = New System.Drawing.Point(485, 58)
        Me.LblDueDate.Name = "LblDueDate"
        Me.LblDueDate.Size = New System.Drawing.Size(62, 16)
        Me.LblDueDate.TabIndex = 731
        Me.LblDueDate.Text = "Due Date"
        '
        'LblTotalUserPurchPlanMeasure
        '
        Me.LblTotalUserPurchPlanMeasure.AutoSize = True
        Me.LblTotalUserPurchPlanMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserPurchPlanMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalUserPurchPlanMeasure.Location = New System.Drawing.Point(656, 3)
        Me.LblTotalUserPurchPlanMeasure.Name = "LblTotalUserPurchPlanMeasure"
        Me.LblTotalUserPurchPlanMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalUserPurchPlanMeasure.TabIndex = 696
        Me.LblTotalUserPurchPlanMeasure.Text = "."
        Me.LblTotalUserPurchPlanMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalUserPurchPlanMeasureText
        '
        Me.LblTotalUserPurchPlanMeasureText.AutoSize = True
        Me.LblTotalUserPurchPlanMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserPurchPlanMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalUserPurchPlanMeasureText.Location = New System.Drawing.Point(479, 3)
        Me.LblTotalUserPurchPlanMeasureText.Name = "LblTotalUserPurchPlanMeasureText"
        Me.LblTotalUserPurchPlanMeasureText.Size = New System.Drawing.Size(176, 16)
        Me.LblTotalUserPurchPlanMeasureText.TabIndex = 695
        Me.LblTotalUserPurchPlanMeasureText.Text = "User Purch Plan Measure :"
        '
        'LblTotalComputerProdPlanMeasure
        '
        Me.LblTotalComputerProdPlanMeasure.AutoSize = True
        Me.LblTotalComputerProdPlanMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComputerProdPlanMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalComputerProdPlanMeasure.Location = New System.Drawing.Point(340, 3)
        Me.LblTotalComputerProdPlanMeasure.Name = "LblTotalComputerProdPlanMeasure"
        Me.LblTotalComputerProdPlanMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalComputerProdPlanMeasure.TabIndex = 698
        Me.LblTotalComputerProdPlanMeasure.Text = "."
        Me.LblTotalComputerProdPlanMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalComputerProdPlanMeasureText
        '
        Me.LblTotalComputerProdPlanMeasureText.AutoSize = True
        Me.LblTotalComputerProdPlanMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComputerProdPlanMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalComputerProdPlanMeasureText.Location = New System.Drawing.Point(131, 3)
        Me.LblTotalComputerProdPlanMeasureText.Name = "LblTotalComputerProdPlanMeasureText"
        Me.LblTotalComputerProdPlanMeasureText.Size = New System.Drawing.Size(203, 16)
        Me.LblTotalComputerProdPlanMeasureText.TabIndex = 697
        Me.LblTotalComputerProdPlanMeasureText.Text = "Computer Prod Plan Measure :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.LblTotalComputerProdPlanMeasureText)
        Me.Panel2.Controls.Add(Me.LblTotalUserPurchPlanMeasure)
        Me.Panel2.Controls.Add(Me.LblTotalComputerProdPlanMeasure)
        Me.Panel2.Controls.Add(Me.LblTotalUserProdPlanMeasureText)
        Me.Panel2.Controls.Add(Me.LblTotalUserProdPlanMeasure)
        Me.Panel2.Controls.Add(Me.LblTotalUserPurchPlanMeasureText)
        Me.Panel2.Location = New System.Drawing.Point(4, 525)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(973, 23)
        Me.Panel2.TabIndex = 699
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(4, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 702
        Me.Label5.Text = "Totals :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 164)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(156, 20)
        Me.LinkLabel1.TabIndex = 732
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Production Plan Detail"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFillDeatil
        '
        Me.BtnFillDeatil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillDeatil.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillDeatil.Location = New System.Drawing.Point(861, 160)
        Me.BtnFillDeatil.Name = "BtnFillDeatil"
        Me.BtnFillDeatil.Size = New System.Drawing.Size(116, 24)
        Me.BtnFillDeatil.TabIndex = 733
        Me.BtnFillDeatil.Text = "Copy Std. Qty"
        Me.BtnFillDeatil.UseVisualStyleBackColor = True
        '
        'TempProductionPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 597)
        Me.Controls.Add(Me.BtnFillDeatil)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.BtnFill)
        Me.Name = "TempProductionPlan"
        Me.Text = "Template Production Plan"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.BtnFillDeatil, 0)
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TxtProductionOrderNo As AgControls.AgTextBox
    Protected WithEvents LblProductionOrderNo As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalUserProdPlanQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserProdPlanQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalUserProdPlanMeasure As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserProdPlanMeasureText As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LblProductionOrderNoReq As System.Windows.Forms.Label
    Protected WithEvents LblDueDateReq As System.Windows.Forms.Label
    Protected WithEvents TxtDueDate As AgControls.AgTextBox
    Protected WithEvents LblDueDate As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserPurchPlanQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserPurchPlanQtyText As System.Windows.Forms.Label
    Protected WithEvents LblTotalComputerProdPlanQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalComputerProdPlanQtyText As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserPurchPlanMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserPurchPlanMeasureText As System.Windows.Forms.Label
    Protected WithEvents LblTotalComputerProdPlanMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalComputerProdPlanMeasureText As System.Windows.Forms.Label
    Protected WithEvents Panel2 As System.Windows.Forms.Panel
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Label5 As System.Windows.Forms.Label
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "MaterialPlan"
        LogTableName = "MaterialPlan_Log"
        MainLineTableCsv = "MaterialPlanDetail"
        LogLineTableCsv = "MaterialPlanDetail_Log"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                       " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "P.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"
        mQry = " Select P.DocID As SearchCode " & _
            " From MaterialPlan P " & _
            " Left Join Voucher_Type Vt On P.V_Type = Vt.V_Type  " & _
            " Where IsNull(IsDeleted,0) = 0  " & mCondStr & "  Order By P.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "P.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select P.UID As SearchCode " & _
                " From MaterialPlan_Log P " & _
                " Left Join Voucher_Type Vt On P.V_Type = Vt.V_Type  " & _
                " Where P.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By P.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And IsNull(H.IsDeleted,0)=0  And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT P.DocID, P.V_Type + '-'+ Convert(NVARCHAR,P.V_No) AS [Plan No.], P.V_Date AS [Plan Date], " & _
        '                    " PO.ManualRefNo As [Prod Order No], Po.DueDate  " & _
        '                    " FROM MaterialPlan P " & _
        '                    " LEFT JOIN Voucher_type Vt ON P.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN ProdOrder Po On P.ProdOrder  = Po.DocId " & _
        '                    " LEFT JOIN Voucher_type V ON Po.V_Type = V.V_Type " & _
        '                    " Where 1=1 " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Plan Type], H.V_Prefix AS [Prefix], H.V_Date AS [Plan Date], H.V_No AS [Plan No], " & _
                            " H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.TotalComputerConsumptionPlanQty AS [Total Computer Consumption Plan Qty],  " & _
                            " H.TotalUserConsumptionPlanQty AS [Total User Consumption Plan Qty], H.Remarks, H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date],  " & _
                            " H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log],  " & _
                            " H.MoveToLogDate AS [Move To Log Date], H.Status, H.DueDate AS [Due Date], H.TotalComputerConsumptionPlanMeasure AS [Total Computer Consumption Plan Measure],  " & _
                            " H.TotalUserConsumptionPlanMeasure AS [Total User Consumption Plan Measure], H.TotalUserPurchPlanQty AS [Total User Purch Plan Qty], H.TotalUserPurchPlanMeasure AS [Total User Purch Plan Measure],  " & _
                            " H.TotalConsumptionQty AS [Total Consumption Qty], " & _
                            " D.Div_Name AS Division,SM.Name AS [Site Name], PO.ManualRefNo AS [Production ORDER No] " & _
                            " FROM  MaterialPlan H " & _
                            " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
                            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN MaterialPlan MP ON MP.DocID  = H.ProdPlan  " & _
                            " LEFT JOIN ProdOrder PO ON PO.DocID  = H.ProdOrder  " & _
                            " Where 1=1 " & mCondStr
        AgL.PubFindQryOrdBy = "[Plan Date]"
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT P.UID, P.V_Type + '-'+ Convert(NVARCHAR,P.V_No) AS [Plan No.], P.V_Date AS [Plan Date], " & _
        '                    " PO.ManualRefNo As [Prod Order No], Po.DueDate  " & _
        '                    " FROM MaterialPlan_Log P " & _
        '                    " LEFT JOIN Voucher_type Vt ON P.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN ProdOrder Po On P.ProdOrder  = Po.DocId " & _
        '                    " LEFT JOIN Voucher_type V ON Po.V_Type = V.V_Type " & _
        '                    " Where P.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Plan Type], H.V_Prefix AS [Prefix], H.V_Date AS [Plan Date], H.V_No AS [Plan No], " & _
                    " H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.TotalComputerConsumptionPlanQty AS [Total Computer Consumption Plan Qty],  " & _
                    " H.TotalUserConsumptionPlanQty AS [Total User Consumption Plan Qty], H.Remarks, H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date],  " & _
                    " H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log],  " & _
                    " H.MoveToLogDate AS [Move To Log Date], H.Status, H.DueDate AS [Due Date], H.TotalComputerConsumptionPlanMeasure AS [Total Computer Consumption Plan Measure],  " & _
                    " H.TotalUserConsumptionPlanMeasure AS [Total User Consumption Plan Measure], H.TotalUserPurchPlanQty AS [Total User Purch Plan Qty], H.TotalUserPurchPlanMeasure AS [Total User Purch Plan Measure],  " & _
                    " H.TotalConsumptionQty AS [Total Consumption Qty], " & _
                    " D.Div_Name AS Division,SM.Name AS [Site Name], PO.ManualRefNo AS [Production ORDER No] " & _
                    " FROM  MaterialPlan_Log H " & _
                    " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                    " LEFT JOIN MaterialPlan MP ON MP.DocID  = H.ProdPlan  " & _
                    " LEFT JOIN ProdOrder PO ON PO.DocID  = H.ProdOrder  " & _
                    " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr


        AgL.PubFindQryOrdBy = "[Plan Date]"
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 180, 0, Col1Item, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 70, 8, 4, False, Col1Qty, True, True, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1StkQty_Finished, 70, 8, 4, False, Col1StkQty_Finished, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1StkQty_SemiFinished, 70, 8, 4, False, Col1StkQty_SemiFinished, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1PendingPurchaseOrderQty, 70, 8, 4, False, Col1PendingPurchaseOrderQty, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1StkQtyReq_OpenSaleOrder, 70, 8, 4, False, Col1StkQtyReq_OpenSaleOrder, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1ExcessQty_Finished, 70, 8, 4, False, Col1ExcessQty_Finished, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1ExcessQty_SemiFinished, 70, 8, 4, False, Col1ExcessQty_SemiFinished, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1ComputerProdPlanQty, 70, 8, 4, False, Col1ComputerProdPlanQty, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1ComputerProdPlanMeasure, 70, 8, 4, False, Col1ComputerProdPlanMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1UserPurchPlanQty, 70, 8, 4, False, Col1UserPurchPlanQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1UserPurchPlanMeasure, 70, 8, 4, False, Col1UserPurchPlanMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1UserProdPlanQty, 70, 8, 4, False, Col1UserProdPlanQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1UserProdPlanMeasure, 70, 8, 4, False, Col1UserProdPlanMeasure, False, True, True)
            .AddAgTextColumn(Dgl1, Col1UserProdPlanRemarks, 200, 255, Col1UserProdPlanRemarks, True, False)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, False, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 100, 10, Col1MeasureUnit, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdIssQty, 100, 8, 4, False, Col1ProdIssQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdIssMeasure, 100, 8, 4, False, Col1ProdIssMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdRecQty, 100, 8, 4, False, Col1ProdRecQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdRecMeasure, 100, 8, 4, False, Col1ProdRecMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1PurchOrdQty, 100, 8, 4, False, Col1PurchOrdQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1PurchQty, 70, 8, 4, False, Col1PurchQty, False, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 65
        Dgl1.AllowUserToAddRows = False
        Dgl1.AgSkipReadOnlyColumns = True
        FrmProductionOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "UPDATE MaterialPlan_Log " & _
                " SET " & _
                " ProdOrder = " & AgL.Chk_Text(TxtProductionOrderNo.AgSelectedValue) & ", " & _
                " DueDate = " & AgL.Chk_Text(TxtDueDate.Text) & ", " & _
                " TotalUserConsumptionPlanQty = " & Val(LblTotalUserProdPlanQty.Text) & ", " & _
                " TotalUserConsumptionPlanMeasure = " & Val(LblTotalUserProdPlanMeasure.Text) & ", " & _
                " TotalUserPurchPlanQty = " & Val(LblTotalUserPurchPlanQty.Text) & ", " & _
                " TotalUserPurchPlanMeasure = " & Val(LblTotalUserPurchPlanMeasure.Text) & ", " & _
                " TotalComputerConsumptionPlanQty = " & Val(LblTotalComputerProdPlanQty.Text) & ", " & _
                " TotalComputerConsumptionPlanMeasure = " & Val(LblTotalComputerProdPlanMeasure.Text) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From MaterialPlanDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1
                    mQry = "INSERT INTO MaterialPlanDetail_Log(UID, DocId, Sr, Item, BomQty, Unit, " & _
                            " StockQty, StkQty_SemiFinished, " & _
                            " StkQtyReq_OpenSaleOrder, ExcessQty_Finished, " & _
                            " ExcessQty_SemiFinished, ComputerMaterialPlanQty,  " & _
                            " ComputerMaterialPlanMeasure, UserPurchPlanQty, " & _
                            " UserPurchPlanMeasure, UserMaterialPlanQty,  " & _
                            " UserMaterialPlanMeasure, UserMaterialPlanRemarks, " & _
                            " MeasurePerPcs, MeasureUnit, TotalMeasure, ProdIssQty, " & _
                            " ProdIssMeasure, ProdRecQty, ProdRecMeasure, " & _
                            " PurchOrdQty, PurchQty, PendingPurchaseOrderQty, ProdOrder) " & _
                            " VALUES( " & _
                            " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ", " & _
                            " " & Val(.Item(Col1Qty, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Unit, I).Value) & ",	" & _
                            " " & Val(.Item(Col1StkQty_Finished, I).Value) & ", " & _
                            " " & Val(.Item(Col1StkQty_SemiFinished, I).Value) & ", " & _
                            " " & Val(.Item(Col1StkQtyReq_OpenSaleOrder, I).Value) & ",	" & _
                            " " & Val(.Item(Col1ExcessQty_Finished, I).Value) & ",	" & _
                            " " & Val(.Item(Col1ExcessQty_SemiFinished, I).Value) & ",	" & _
                            " " & Val(.Item(Col1ComputerProdPlanQty, I).Value) & ",	" & _
                            " " & Val(.Item(Col1ComputerProdPlanMeasure, I).Value) & ",	" & _
                            " " & Val(.Item(Col1UserPurchPlanQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1UserPurchPlanMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col1UserProdPlanQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1UserProdPlanMeasure, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1UserProdPlanRemarks, I).Value) & ", " & _
                            " " & Val(.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1MeasureUnit, I).Value) & ",  " & _
                            " " & Val(.Item(Col1TotalMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col1ProdIssQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1ProdIssMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col1ProdRecQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1ProdRecMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col1PurchOrdQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1PurchQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1PendingPurchaseOrderQty, I).Value) & ", " & _
                            " " & AgL.Chk_Text(TxtProductionOrderNo.AgSelectedValue) & " " & _
                            " ) "

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select P.* " & _
                " From MaterialPlan P " & _
                " Where P.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select P.* " & _
                " From MaterialPlan_Log P " & _
                " Where P.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()
                TxtProductionOrderNo.AgSelectedValue = AgL.XNull(.Rows(0)("ProdOrder"))
                TxtDueDate.Text = AgL.XNull(.Rows(0)("DueDate"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalUserProdPlanQty.Text = AgL.VNull(.Rows(0)("TotalUserConsumptionPlanQty"))
                LblTotalUserProdPlanMeasure.Text = AgL.VNull(.Rows(0)("TotalUserConsumptionPlanMeasure"))
                LblTotalUserPurchPlanQty.Text = AgL.VNull(.Rows(0)("TotalUserPurchPlanQty"))
                LblTotalUserPurchPlanMeasure.Text = AgL.VNull(.Rows(0)("TotalUserPurchPlanMeasure"))
                LblTotalComputerProdPlanQty.Text = AgL.VNull(.Rows(0)("TotalComputerConsumptionPlanQty"))
                LblTotalComputerProdPlanMeasure.Text = AgL.VNull(.Rows(0)("TotalComputerConsumptionPlanMeasure"))
                Dgl1.Tag = AgL.XNull(.Rows(0)("ProdOrder"))

                DrTemp = TxtProductionOrderNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtProductionOrderNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    LblProductionOrderNo.Tag = AgL.XNull(DrTemp(0)("SaleOrder"))
                End If

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from MaterialPlanDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from MaterialPlanDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("BomQty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1StkQty_Finished, I).Value = AgL.VNull(.Rows(I)("StockQty"))
                            Dgl1.Item(Col1StkQty_SemiFinished, I).Value = AgL.VNull(.Rows(I)("StkQty_SemiFinished"))
                            Dgl1.Item(Col1StkQtyReq_OpenSaleOrder, I).Value = AgL.VNull(.Rows(I)("StkQtyReq_OpenSaleOrder"))
                            Dgl1.Item(Col1ExcessQty_Finished, I).Value = AgL.VNull(.Rows(I)("ExcessQty_Finished"))
                            Dgl1.Item(Col1ExcessQty_SemiFinished, I).Value = AgL.VNull(.Rows(I)("ExcessQty_SemiFinished"))
                            Dgl1.Item(Col1ComputerProdPlanQty, I).Value = AgL.VNull(.Rows(I)("ComputerMaterialPlanQty"))
                            Dgl1.Item(Col1ComputerProdPlanMeasure, I).Value = AgL.VNull(.Rows(I)("ComputerMaterialPlanMeasure"))
                            Dgl1.Item(Col1UserPurchPlanQty, I).Value = AgL.VNull(.Rows(I)("UserPurchPlanQty"))
                            Dgl1.Item(Col1UserPurchPlanMeasure, I).Value = AgL.VNull(.Rows(I)("UserPurchPlanMeasure"))
                            Dgl1.Item(Col1UserProdPlanQty, I).Value = AgL.VNull(.Rows(I)("UserMaterialPlanQty"))
                            Dgl1.Item(Col1UserProdPlanMeasure, I).Value = AgL.VNull(.Rows(I)("UserMaterialPlanMeasure"))
                            Dgl1.Item(Col1UserProdPlanRemarks, I).Value = AgL.XNull(.Rows(I)("UserMaterialPlanRemarks"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1ProdIssQty, I).Value = AgL.VNull(.Rows(I)("ProdIssQty"))
                            Dgl1.Item(Col1ProdIssMeasure, I).Value = AgL.VNull(.Rows(I)("ProdIssMeasure"))
                            Dgl1.Item(Col1ProdRecQty, I).Value = AgL.VNull(.Rows(I)("ProdRecQty"))
                            Dgl1.Item(Col1ProdRecMeasure, I).Value = AgL.VNull(.Rows(I)("ProdRecMeasure"))
                            Dgl1.Item(Col1PurchOrdQty, I).Value = AgL.VNull(.Rows(I)("PurchOrdQty"))
                            Dgl1.Item(Col1PurchQty, I).Value = AgL.VNull(.Rows(I)("PurchQty"))
                            Dgl1.Item(Col1PendingPurchaseOrderQty, I).Value = AgL.VNull(.Rows(I)("PendingPurchaseOrderQty"))
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

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, I.Measure, MeasureUnit " & _
                " FROM Item I"
        Dgl1.AgHelpDataSet(Col1Item, 5) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Po.DocID AS Code, PO.ManualRefNo as [Prod.Order No Manual] , Po.V_Type + '-' + Convert(NVARCHAR,Po.V_No) AS [Prod.Order No], " & _
                " IsNull(Po.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, Po.MoveToLog, IsNull(Po.IsDeleted ,0) AS IsDeleted, " & _
                " Po.V_Date As ProductionOrderDate, Po.Div_Code, Po.SaleOrder, V1.ProdOrder " & _
                " FROM ProdOrder Po " & _
                " LEFT JOIN ( " & _
                " 	    SELECT Pp.ProdOrder " & _
                " 	    FROM MaterialPlan Pp " & _
                "       LEFT JOIN Voucher_Type V On Pp.V_Type = V.V_Type " & _
                "       WHERE IsNull(Pp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                "       And IsNull(Pp.IsDeleted,0) = 0 " & _
                "       AND V.NCat = '" & EntryNCat & "' " & _
                " ) AS V1 ON Po.DocId = V1.ProdOrder	 " & _
                " LEFT JOIN Voucher_Type Vt ON Po.V_Type = Vt.V_Type"

        TxtProductionOrderNo.AgHelpDataSet(6, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalUserProdPlanQty.Text = 0 : LblTotalUserProdPlanMeasure.Text = 0
        LblTotalComputerProdPlanQty.Text = 0 : LblTotalComputerProdPlanMeasure.Text = 0
        LblTotalUserPurchPlanQty.Text = 0 : LblTotalUserPurchPlanMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1ComputerProdPlanMeasure, I).Value = Format(Val(Dgl1.Item(Col1ComputerProdPlanQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")
                Dgl1.Item(Col1UserPurchPlanMeasure, I).Value = Format(Val(Dgl1.Item(Col1UserPurchPlanQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")
                Dgl1.Item(Col1UserProdPlanMeasure, I).Value = Format(Val(Dgl1.Item(Col1UserProdPlanQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")

                'Footer Calculation
                LblTotalUserProdPlanQty.Text = Val(LblTotalUserProdPlanQty.Text) + Val(Dgl1.Item(Col1UserProdPlanQty, I).Value)
                LblTotalUserProdPlanMeasure.Text = Val(LblTotalUserProdPlanMeasure.Text) + Val(Dgl1.Item(Col1UserProdPlanMeasure, I).Value)
                LblTotalUserPurchPlanQty.Text = Val(LblTotalUserPurchPlanQty.Text) + Val(Dgl1.Item(Col1UserPurchPlanQty, I).Value)
                LblTotalUserPurchPlanMeasure.Text = Val(LblTotalUserPurchPlanMeasure.Text) + Val(Dgl1.Item(Col1UserPurchPlanMeasure, I).Value)
                LblTotalComputerProdPlanQty.Text = Val(LblTotalComputerProdPlanQty.Text) + Val(Dgl1.Item(Col1ComputerProdPlanQty, I).Value)
                LblTotalComputerProdPlanMeasure.Text = Val(LblTotalComputerProdPlanMeasure.Text) + Val(Dgl1.Item(Col1ComputerProdPlanMeasure, I).Value)
            End If
        Next
        LblTotalUserProdPlanMeasure.Text = Format(Val(LblTotalUserProdPlanMeasure.Text), "0.00")
        LblTotalUserPurchPlanMeasure.Text = Format(Val(LblTotalUserPurchPlanMeasure.Text), "0.00")
        LblTotalComputerProdPlanMeasure.Text = Format(Val(LblTotalComputerProdPlanMeasure.Text), "0.00")
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If AgL.RequiredField(TxtDueDate, "Due Date") Then passed = False : Exit Sub
        If AgL.RequiredField(TxtProductionOrderNo, "Production Order No") Then passed = False : Exit Sub

        If Validate_ProductionOrder() = False Then passed = False : Exit Sub

        If TxtDueDate.Text <> "" And TxtV_Date.Text <> "" Then
            If CDate(TxtDueDate.Text) < CDate(TxtV_Date.Text) Then
                MsgBox("Due date Can't be Less Than Production Plan Date", MsgBoxStyle.Information)
                TxtDueDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If TxtProductionOrderNo.AgSelectedValue <> "" Then
            If TxtProductionOrderNo.AgSelectedValue <> Dgl1.Tag Then
                MsgBox("Data In Grid Does Not Belong To " & TxtProductionOrderNo.Text & "", MsgBoxStyle.Information)
                TxtProductionOrderNo.Focus()
                passed = False : Exit Sub
            End If
        End If

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1ComputerProdPlanQty, I).Value) > 0 And Val(.Item(Col1UserProdPlanQty, I).Value) = 0 And Val(.Item(Col1UserPurchPlanQty, I).Value) = 0 Then
                        MsgBox("User Planned Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1UserProdPlanQty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl1.Tag = "" : LblProductionOrderNo.Tag = ""
        LblTotalComputerProdPlanQty.Text = 0 : LblTotalUserProdPlanQty.Text = 0 : LblTotalUserPurchPlanQty.Text = 0
        LblTotalComputerProdPlanMeasure.Text = 0 : LblTotalUserProdPlanMeasure.Text = 0 : LblTotalUserPurchPlanMeasure.Text = 0
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            mQry = "SELECT Po.Item, Po.Qty AS ProductionOrderQty, " & _
                    " IsNull(V1.StockInHandFinished,0) AS StockInHandFinished, " & _
                    " IsNull(V2.StockInProcess,0) + IsNull(V3.StockInProcess,0) AS StockInHandSemiFinished, " & _
                    " IsNull(V4.StockReqForOpenOrders,0) AS StockReqForOpenOrders, " & _
                    " IsNull(V5.PendingPurchaseOrderQty,0) AS PendingPurchaseOrderQty , " & _
                    " Po.Unit, IsNull(Po.MeasurePerPcs,0) As MeasurePerPcs, " & _
                    " IsNull(Po.TotalMeasure,0) As TotalMeasure, Po.MeasureUnit " & _
                    " FROM ProdOrderDetail Po " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT S.Item,  " & _
                    " 	IsNull(Sum(S.Qty_Rec),0) - IsNull(Sum(S.Qty_Iss),0) AS StockInHandFinished  " & _
                    " 	FROM Stock S " & _
                    " 	WHERE S.Process IS NULL " & _
                    "   AND IsNull(S.Status,'" & ClsMain.StockStatus.Standard & "') = '" & ClsMain.StockStatus.Standard & "' " & _
                    " 	GROUP BY S.Item   " & _
                    " ) AS V1 ON Po.Item =  V1.Item " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT S.Item,  " & _
                    " 	IsNull(Sum(S.Qty_Rec),0) - IsNull(Sum(S.Qty_Iss),0) AS StockInProcess  " & _
                    " 	FROM Stock S " & _
                    " 	WHERE S.Process IS NOT NULL " & _
                    "   AND IsNull(S.Status,'" & ClsMain.StockStatus.Standard & "') = '" & ClsMain.StockStatus.Standard & "' " & _
                    " 	GROUP BY S.Item   " & _
                    " ) AS V2 ON Po.Item =  V2.Item " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT Sp.Item,  " & _
                    " 	Sum(IsNull(Sp.Qty_Rec,0)) - Sum(IsNull(Sp.Qty_Iss,0)) AS StockInProcess  " & _
                    " 	FROM StockProcess Sp " & _
                    " 	WHERE IsNull(Sp.Status,'" & ClsMain.StockStatus.Standard & "') = '" & ClsMain.StockStatus.Standard & "' " & _
                    " 	GROUP BY Sp.Item   " & _
                    " ) AS V3 ON Po.Item =  V3.Item " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT Sod.Item,  " & _
                    " 	IsNull(Sum(Sod.Qty),0) - IsNull(Sum(Sod.ShippedQty),0) AS StockReqForOpenOrders " & _
                    " 	FROM SaleOrderDetail Sod " & _
                    " 	LEFT JOIN SaleOrder So ON Sod.DocId = So.DocID " & _
                    "   LEFT JOIN ProdOrder PrO On Pro.SaleOrder = So.DocID " & _
                    " 	WHERE IsNull(So.Status,'" & ClsMain.SaleOrderStatus.Active & "') = '" & ClsMain.SaleOrderStatus.Active & "' " & _
                    "   And IsNull(So.IsDeleted,0) = 0 " & _
                    "   AND (Pro.DocID <> '" & TxtProductionOrderNo.AgSelectedValue & "' Or Pro.DocID Is Null)  " & _
                    " 	GROUP BY Sod.Item " & _
                    " ) AS V4 ON Po.Item =  V4.Item " & _
                    " LEFT JOIN ( " & _
                    "   SELECT Ppd.Item, " & _
                    "   IsNull(Sum(Ppd.PurchOrdQty),0) - IsNull(Sum(Ppd.PurchQty),0) As PendingPurchaseOrderQty " & _
                    "   FROM MaterialPlanDetail Ppd " & _
                    "   LEFT JOIN MaterialPlan Pp On Ppd.DocId = Pp.DocId " & _
                    "   WHERE Pp.ProdOrder <> '" & TxtProductionOrderNo.AgSelectedValue & "' " & _
                    " 	And IsNull(Pp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    "   And IsNull(Pp.IsDeleted,0) = 0 " & _
                    "   GROUP BY Ppd.Item " & _
                    " ) AS V5 ON Po.Item =  V5.Item " & _
                    " WHERE Po.DocId = '" & TxtProductionOrderNo.AgSelectedValue & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("ProductionOrderQty"))

                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))

                        Dgl1.Item(Col1StkQty_Finished, I).Value = AgL.VNull(.Rows(I)("StockInHandFinished"))
                        Dgl1.Item(Col1StkQty_SemiFinished, I).Value = AgL.VNull(.Rows(I)("StockInHandSemiFinished"))
                        Dgl1.Item(Col1PendingPurchaseOrderQty, I).Value = AgL.VNull(.Rows(I)("PendingPurchaseOrderQty"))
                        Dgl1.Item(Col1StkQtyReq_OpenSaleOrder, I).Value = AgL.VNull(.Rows(I)("StockReqForOpenOrders"))
                        Dgl1.Item(Col1ExcessQty_Finished, I).Value = IIf(Val(Dgl1.Item(Col1StkQty_Finished, I).Value) - Val(Dgl1.Item(Col1StkQtyReq_OpenSaleOrder, I).Value) > 0, Val(Dgl1.Item(Col1StkQty_Finished, I).Value) - Val(Dgl1.Item(Col1StkQtyReq_OpenSaleOrder, I).Value), 0)
                        Dgl1.Item(Col1ExcessQty_SemiFinished, I).Value = IIf(Val(Dgl1.Item(Col1StkQty_SemiFinished, I).Value) > 0, IIf(Val(Dgl1.Item(Col1StkQty_SemiFinished, I).Value) + Val(Dgl1.Item(Col1StkQty_Finished, I).Value) - Val(Dgl1.Item(Col1StkQtyReq_OpenSaleOrder, I).Value) > 0, Val(Dgl1.Item(Col1StkQty_SemiFinished, I).Value) + Val(Dgl1.Item(Col1StkQty_Finished, I).Value) - Val(Dgl1.Item(Col1StkQtyReq_OpenSaleOrder, I).Value), 0), 0)
                        Dgl1.Item(Col1ComputerProdPlanQty, I).Value = IIf(Val(Dgl1.Item(Col1Qty, I).Value) - Val(Dgl1.Item(Col1StkQty_Finished, I).Value) - Val(Dgl1.Item(Col1StkQty_SemiFinished, I).Value) - Val(Dgl1.Item(Col1PendingPurchaseOrderQty, I).Value) > 0, Val(Dgl1.Item(Col1Qty, I).Value) - Val(Dgl1.Item(Col1StkQty_Finished, I).Value) - Val(Dgl1.Item(Col1StkQty_SemiFinished, I).Value) - Val(Dgl1.Item(Col1PendingPurchaseOrderQty, I).Value), 0)
                        Dgl1.Item(Col1UserProdPlanQty, I).Value = Val(Dgl1.Item(Col1ComputerProdPlanQty, I).Value)
                        'Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                    Next I
                End If
            End With
            Dgl1.Tag = TxtProductionOrderNo.AgSelectedValue
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Validate_ProductionOrder() As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If TxtProductionOrderNo.Text <> "" Then
                DrTemp = TxtProductionOrderNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtProductionOrderNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Production Order """ & TxtProductionOrderNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtProductionOrderNo.Text = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Production Order """ & TxtProductionOrderNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtProductionOrderNo.Text = ""
                        Exit Function
                    End If
                End If

                mQry = "SELECT Count(Pp.DocID)  " & _
                        " FROM MaterialPlan_Log Pp " & _
                        " LEFT JOIN Voucher_Type Vt On Pp.V_Type = Vt.V_Type " & _
                        " WHERE Pp.ProdOrder = '" & TxtProductionOrderNo.AgSelectedValue & "' " & _
                        " AND Pp.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "' " & _
                        " AND Vt.NCat = '" & EntryNCat & "'" & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Edit"), "Pp.DocId <> '" & mInternalCode & "'", "1=1") & " "

                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar() > 0 Then
                    MsgBox("A Production Plan For Production Order """ & TxtProductionOrderNo.Text & """ Already Exists In Log." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                    Exit Function
                End If
            End If
            Validate_ProductionOrder = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtProductionOrderNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtV_Type.Name
                    IniGrid()

                Case TxtProductionOrderNo.Name
                    DrTemp = TxtProductionOrderNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtProductionOrderNo.AgSelectedValue & "' ")
                    If DrTemp.Length > 0 Then
                        LblProductionOrderNo.Tag = AgL.XNull(DrTemp(0)("SaleOrder"))
                    End If
                    e.Cancel = Not Validate_ProductionOrder()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductionOrderNo.Enter
        Try
            Select Case sender.name
                Case TxtProductionOrderNo.Name
                    If TxtV_Date.Text <> "" Then
                        TxtProductionOrderNo.AgRowFilter = " IsDeleted = 0 And ProductionOrderDate <= '" & TxtV_Date.Text & "' And Div_Code = '" & AgL.PubDivCode & "' And (ProdOrder Is Null Or Code = '" & Dgl1.Tag & "')  "
                        'TxtProductionOrderNo.AgRowFilter = " IsDeleted = 0 And ProductionOrderDate <= '" & TxtV_Date.Text & "' And Div_Code = '" & AgL.PubDivCode & "' And (ProdPlanQty = 0  Or ProdOrder Is Null) " & IIf(AgL.StrCmp(Topctrl1.Mode, "Edit"), "Or Code = '" & Dgl1.Tag & "'", "And 1=1") & ""
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempProductionOrder_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        'If Not AgL.StrCmp(Topctrl1.Mode, "ADD") Then
        '    BtnFill.Enabled = False
        'Else
        '    BtnFill.Enabled = True
        'End If
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("Measure"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Protected Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    'Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer

        '------------------------------------------------------------------------
        'Updating Production Order Qty In Sale Order Detail
        '-------------------------------------------------------------------------
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE ProdOrderDetail " & _
                           " SET " & _
                           " ProdPlanQty = " & Val(.Item(Col1UserProdPlanQty, I).Value) + Val(.Item(Col1UserPurchPlanQty, I).Value) & ", " & _
                           " ProdPlanMeasure = " & Val(.Item(Col1UserProdPlanMeasure, I).Value) + Val(.Item(Col1UserPurchPlanMeasure, I).Value) & " " & _
                           " Where DocId = '" & TxtProductionOrderNo.AgSelectedValue & "' " & _
                           " And Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = "UPDATE SaleOrderDetail " & _
                           " SET " & _
                           " ProdPlanQty = " & Val(.Item(Col1UserProdPlanQty, I).Value) + Val(.Item(Col1UserPurchPlanQty, I).Value) & ", " & _
                           " ProdPlanMeasure = " & Val(.Item(Col1UserProdPlanMeasure, I).Value) + Val(.Item(Col1UserPurchPlanMeasure, I).Value) & " " & _
                           " Where DocId = '" & LblProductionOrderNo.Tag & "' " & _
                           " And Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
        '-------------------------------------------------------------------------

    End Sub

    Private Sub BtnFillDeatil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillDeatil.Click
        If Topctrl1.Mode <> "Browse" Then
            Dim I As Integer
            With Dgl1
                If .RowCount <> 0 Then
                    For I = 0 To .RowCount - 1
                        If .Item(Col1Item, I).Value <> "" Then
                            Dgl1.Item(Col1UserProdPlanQty, I).Value = Dgl1.Item(Col1Qty, I).Value
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' " & _
                    " FROM ( " & _
                    "   SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo " & _
                    "   FROM JobOrderDetail L " & _
                    "   LEFT JOIN JobOrder H ON L.DocId = H.DocID " & _
                    "   WHERE L.ProdOrder = '" & TxtProductionOrderNo.AgSelectedValue & "' " & _
                    "   And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Job Order " & bRData & " created against Prod Order No. " & TxtProductionOrderNo.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        'Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        'Passed = Not FGetRelationalData()
    End Sub
End Class
