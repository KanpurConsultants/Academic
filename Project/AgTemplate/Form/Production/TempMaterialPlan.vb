Imports CrystalDecisions.CrystalReports.Engine
Public Class TempMaterialPlan
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseFunction_PostGrid1Fill()
    Public Event BaseFunction_PostGrid2Fill()

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "MeasurePerPcs"
    Protected Const Col1TotalMeasure As String = "TotalMeasure"
    Protected Const Col1MeasureUnit As String = "MeasureUnit"
    Protected Const Col1BOM As String = "BOM"

    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2Item As String = "Item"
    Protected Const Col2BomQty As String = "BomQty"
    Protected Const Col2Unit As String = "Unit"
    Protected Const Col2StockQty As String = "Stock In Hand"
    Protected Const Col2PendingPurchaseOrderQty As String = "Pending Purchase Order Qty"
    Protected Const Col2IssuedQty_ProdPlan As String = "To Be Issued For Previous Plans"
    Protected Const Col2ExcessQty_Finished As String = "Excess Stock"
    Protected Const Col2ComputerMaterialPlanQty As String = "Computer Plan Qty"
    Protected Const Col2ComputerMaterialPlanMeasure As String = "Computer Plan Measure"
    Protected Const Col2UserMaterialPlanQty As String = "User Plan Qty"
    Protected Const Col2UserMaterialPlanMeasure As String = "User Plan Measure"
    Protected Const Col2UserMaterialPlanRemarks As String = "User Plan Remarks"
    Protected Const Col2MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col2MeasureUnit As String = "Measure Unit"
    Protected Const Col2PurchOrdQty As String = "Purch Ord Qty"
    Protected Const Col2PurchOrdMeasure As String = "Purch Ord Measure"
    Protected Const Col2PurchQty As String = "Purch Qty"
    Protected Const Col2PurchMeasure As String = "Purch Measure"
    Protected Const Col2ProdIssQty As String = "Prod Issue Qty"
    Protected Const Col2ProdIssMeasure As String = "Prod Issue Measure"
    Protected WithEvents BtnFillDeatil As System.Windows.Forms.Button

    Dim mAddFlag As Boolean = True

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtProductionPlanNo = New AgControls.AgTextBox
        Me.LblProductionPlanNo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblProductionPlanNoReq = New System.Windows.Forms.Label
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LblTotalConsumptionQty = New System.Windows.Forms.Label
        Me.LblTotalConsumptionQtyText = New System.Windows.Forms.Label
        Me.LblTotalComputerConsumptionPlanQty = New System.Windows.Forms.Label
        Me.LblTotalComputerConsumptionPlanQtyText = New System.Windows.Forms.Label
        Me.LblTotalUserConsumptionPlanQty = New System.Windows.Forms.Label
        Me.LblTotalUserConsumptionPlanQtyText = New System.Windows.Forms.Label
        Me.LblConsumptionDetailForAboveItems = New System.Windows.Forms.LinkLabel
        Me.LblMaterialPlanForFollowingItems = New System.Windows.Forms.LinkLabel
        Me.LblProdOrderNoReq = New System.Windows.Forms.Label
        Me.TxtProdOrderNo = New AgControls.AgTextBox
        Me.LblProdOrderNo = New System.Windows.Forms.Label
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
        Me.GroupBox2.Location = New System.Drawing.Point(832, 585)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 585)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 585)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 585)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 585)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 581)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 585)
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
        Me.LblV_No.Location = New System.Drawing.Point(487, 32)
        Me.LblV_No.Size = New System.Drawing.Size(58, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Plan No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(609, 31)
        Me.TxtV_No.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(365, 37)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(227, 33)
        Me.LblV_Date.Size = New System.Drawing.Size(65, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Plan Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(593, 17)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(381, 31)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(487, 13)
        Me.LblV_Type.Size = New System.Drawing.Size(66, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Plan Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(609, 11)
        Me.TxtV_Type.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(365, 17)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(227, 13)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(381, 11)
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
        Me.LblPrefix.Location = New System.Drawing.Point(547, 32)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 19)
        Me.TabControl1.Size = New System.Drawing.Size(993, 144)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.LblProdOrderNoReq)
        Me.TP1.Controls.Add(Me.TxtProdOrderNo)
        Me.TP1.Controls.Add(Me.LblProdOrderNo)
        Me.TP1.Controls.Add(Me.LblProductionPlanNoReq)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtProductionPlanNo)
        Me.TP1.Controls.Add(Me.LblProductionPlanNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(985, 118)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProductionPlanNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProductionPlanNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProductionPlanNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProdOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProdOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblProdOrderNoReq, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
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
        'TxtProductionPlanNo
        '
        Me.TxtProductionPlanNo.AgMandatory = True
        Me.TxtProductionPlanNo.AgMasterHelp = False
        Me.TxtProductionPlanNo.AgNumberLeftPlaces = 8
        Me.TxtProductionPlanNo.AgNumberNegetiveAllow = False
        Me.TxtProductionPlanNo.AgNumberRightPlaces = 2
        Me.TxtProductionPlanNo.AgPickFromLastValue = False
        Me.TxtProductionPlanNo.AgRowFilter = ""
        Me.TxtProductionPlanNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProductionPlanNo.AgSelectedValue = Nothing
        Me.TxtProductionPlanNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProductionPlanNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProductionPlanNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProductionPlanNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProductionPlanNo.Location = New System.Drawing.Point(381, 71)
        Me.TxtProductionPlanNo.MaxLength = 20
        Me.TxtProductionPlanNo.Name = "TxtProductionPlanNo"
        Me.TxtProductionPlanNo.Size = New System.Drawing.Size(377, 18)
        Me.TxtProductionPlanNo.TabIndex = 5
        '
        'LblProductionPlanNo
        '
        Me.LblProductionPlanNo.AutoSize = True
        Me.LblProductionPlanNo.BackColor = System.Drawing.Color.Transparent
        Me.LblProductionPlanNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductionPlanNo.Location = New System.Drawing.Point(227, 72)
        Me.LblProductionPlanNo.Name = "LblProductionPlanNo"
        Me.LblProductionPlanNo.Size = New System.Drawing.Size(124, 16)
        Me.LblProductionPlanNo.TabIndex = 706
        Me.LblProductionPlanNo.Text = "Production Plan No."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(4, 324)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(972, 21)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(432, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 670
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(321, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 669
        Me.Label33.Text = "Total Measure :"
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
        Me.Pnl1.Location = New System.Drawing.Point(4, 189)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(972, 135)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(227, 92)
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
        Me.TxtRemarks.Location = New System.Drawing.Point(381, 91)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.TabIndex = 6
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(916, 167)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(56, 21)
        Me.BtnFill.TabIndex = 7
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblProductionPlanNoReq
        '
        Me.LblProductionPlanNoReq.AutoSize = True
        Me.LblProductionPlanNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblProductionPlanNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblProductionPlanNoReq.Location = New System.Drawing.Point(365, 77)
        Me.LblProductionPlanNoReq.Name = "LblProductionPlanNoReq"
        Me.LblProductionPlanNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblProductionPlanNoReq.TabIndex = 729
        Me.LblProductionPlanNoReq.Text = "Ä"
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(5, 373)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(972, 178)
        Me.Pnl2.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel2.Controls.Add(Me.LblTotalConsumptionQty)
        Me.Panel2.Controls.Add(Me.LblTotalConsumptionQtyText)
        Me.Panel2.Controls.Add(Me.LblTotalComputerConsumptionPlanQty)
        Me.Panel2.Controls.Add(Me.LblTotalComputerConsumptionPlanQtyText)
        Me.Panel2.Controls.Add(Me.LblTotalUserConsumptionPlanQty)
        Me.Panel2.Controls.Add(Me.LblTotalUserConsumptionPlanQtyText)
        Me.Panel2.Location = New System.Drawing.Point(5, 552)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(971, 22)
        Me.Panel2.TabIndex = 696
        '
        'LblTotalConsumptionQty
        '
        Me.LblTotalConsumptionQty.AutoSize = True
        Me.LblTotalConsumptionQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalConsumptionQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalConsumptionQty.Location = New System.Drawing.Point(177, 3)
        Me.LblTotalConsumptionQty.Name = "LblTotalConsumptionQty"
        Me.LblTotalConsumptionQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalConsumptionQty.TabIndex = 672
        Me.LblTotalConsumptionQty.Text = "."
        Me.LblTotalConsumptionQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalConsumptionQtyText
        '
        Me.LblTotalConsumptionQtyText.AutoSize = True
        Me.LblTotalConsumptionQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalConsumptionQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalConsumptionQtyText.Location = New System.Drawing.Point(12, 3)
        Me.LblTotalConsumptionQtyText.Name = "LblTotalConsumptionQtyText"
        Me.LblTotalConsumptionQtyText.Size = New System.Drawing.Size(160, 16)
        Me.LblTotalConsumptionQtyText.TabIndex = 671
        Me.LblTotalConsumptionQtyText.Text = "Total Consumption Qty :"
        '
        'LblTotalComputerConsumptionPlanQty
        '
        Me.LblTotalComputerConsumptionPlanQty.AutoSize = True
        Me.LblTotalComputerConsumptionPlanQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComputerConsumptionPlanQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalComputerConsumptionPlanQty.Location = New System.Drawing.Point(555, 3)
        Me.LblTotalComputerConsumptionPlanQty.Name = "LblTotalComputerConsumptionPlanQty"
        Me.LblTotalComputerConsumptionPlanQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalComputerConsumptionPlanQty.TabIndex = 670
        Me.LblTotalComputerConsumptionPlanQty.Text = "."
        Me.LblTotalComputerConsumptionPlanQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalComputerConsumptionPlanQtyText
        '
        Me.LblTotalComputerConsumptionPlanQtyText.AutoSize = True
        Me.LblTotalComputerConsumptionPlanQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalComputerConsumptionPlanQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalComputerConsumptionPlanQtyText.Location = New System.Drawing.Point(377, 3)
        Me.LblTotalComputerConsumptionPlanQtyText.Name = "LblTotalComputerConsumptionPlanQtyText"
        Me.LblTotalComputerConsumptionPlanQtyText.Size = New System.Drawing.Size(172, 16)
        Me.LblTotalComputerConsumptionPlanQtyText.TabIndex = 669
        Me.LblTotalComputerConsumptionPlanQtyText.Text = "Total Computer Plan Qty :"
        '
        'LblTotalUserConsumptionPlanQty
        '
        Me.LblTotalUserConsumptionPlanQty.AutoSize = True
        Me.LblTotalUserConsumptionPlanQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserConsumptionPlanQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalUserConsumptionPlanQty.Location = New System.Drawing.Point(854, 3)
        Me.LblTotalUserConsumptionPlanQty.Name = "LblTotalUserConsumptionPlanQty"
        Me.LblTotalUserConsumptionPlanQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalUserConsumptionPlanQty.TabIndex = 660
        Me.LblTotalUserConsumptionPlanQty.Text = "."
        Me.LblTotalUserConsumptionPlanQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalUserConsumptionPlanQtyText
        '
        Me.LblTotalUserConsumptionPlanQtyText.AutoSize = True
        Me.LblTotalUserConsumptionPlanQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUserConsumptionPlanQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalUserConsumptionPlanQtyText.Location = New System.Drawing.Point(712, 3)
        Me.LblTotalUserConsumptionPlanQtyText.Name = "LblTotalUserConsumptionPlanQtyText"
        Me.LblTotalUserConsumptionPlanQtyText.Size = New System.Drawing.Size(138, 16)
        Me.LblTotalUserConsumptionPlanQtyText.TabIndex = 659
        Me.LblTotalUserConsumptionPlanQtyText.Text = "Total User Plan Qty :"
        '
        'LblConsumptionDetailForAboveItems
        '
        Me.LblConsumptionDetailForAboveItems.BackColor = System.Drawing.Color.SteelBlue
        Me.LblConsumptionDetailForAboveItems.DisabledLinkColor = System.Drawing.Color.White
        Me.LblConsumptionDetailForAboveItems.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsumptionDetailForAboveItems.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblConsumptionDetailForAboveItems.LinkColor = System.Drawing.Color.White
        Me.LblConsumptionDetailForAboveItems.Location = New System.Drawing.Point(4, 351)
        Me.LblConsumptionDetailForAboveItems.Name = "LblConsumptionDetailForAboveItems"
        Me.LblConsumptionDetailForAboveItems.Size = New System.Drawing.Size(260, 19)
        Me.LblConsumptionDetailForAboveItems.TabIndex = 730
        Me.LblConsumptionDetailForAboveItems.TabStop = True
        Me.LblConsumptionDetailForAboveItems.Text = "Consumption Detail For Above Items"
        Me.LblConsumptionDetailForAboveItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMaterialPlanForFollowingItems
        '
        Me.LblMaterialPlanForFollowingItems.BackColor = System.Drawing.Color.SteelBlue
        Me.LblMaterialPlanForFollowingItems.DisabledLinkColor = System.Drawing.Color.White
        Me.LblMaterialPlanForFollowingItems.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMaterialPlanForFollowingItems.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblMaterialPlanForFollowingItems.LinkColor = System.Drawing.Color.White
        Me.LblMaterialPlanForFollowingItems.Location = New System.Drawing.Point(4, 168)
        Me.LblMaterialPlanForFollowingItems.Name = "LblMaterialPlanForFollowingItems"
        Me.LblMaterialPlanForFollowingItems.Size = New System.Drawing.Size(260, 20)
        Me.LblMaterialPlanForFollowingItems.TabIndex = 731
        Me.LblMaterialPlanForFollowingItems.TabStop = True
        Me.LblMaterialPlanForFollowingItems.Text = "Material Plan For Following Items"
        Me.LblMaterialPlanForFollowingItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblProdOrderNoReq
        '
        Me.LblProdOrderNoReq.AutoSize = True
        Me.LblProdOrderNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblProdOrderNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblProdOrderNoReq.Location = New System.Drawing.Point(365, 57)
        Me.LblProdOrderNoReq.Name = "LblProdOrderNoReq"
        Me.LblProdOrderNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblProdOrderNoReq.TabIndex = 732
        Me.LblProdOrderNoReq.Text = "Ä"
        '
        'TxtProdOrderNo
        '
        Me.TxtProdOrderNo.AgMandatory = True
        Me.TxtProdOrderNo.AgMasterHelp = False
        Me.TxtProdOrderNo.AgNumberLeftPlaces = 8
        Me.TxtProdOrderNo.AgNumberNegetiveAllow = False
        Me.TxtProdOrderNo.AgNumberRightPlaces = 2
        Me.TxtProdOrderNo.AgPickFromLastValue = False
        Me.TxtProdOrderNo.AgRowFilter = ""
        Me.TxtProdOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProdOrderNo.AgSelectedValue = Nothing
        Me.TxtProdOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProdOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProdOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProdOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProdOrderNo.Location = New System.Drawing.Point(381, 51)
        Me.TxtProdOrderNo.MaxLength = 20
        Me.TxtProdOrderNo.Name = "TxtProdOrderNo"
        Me.TxtProdOrderNo.Size = New System.Drawing.Size(377, 18)
        Me.TxtProdOrderNo.TabIndex = 4
        '
        'LblProdOrderNo
        '
        Me.LblProdOrderNo.AutoSize = True
        Me.LblProdOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblProdOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProdOrderNo.Location = New System.Drawing.Point(227, 52)
        Me.LblProdOrderNo.Name = "LblProdOrderNo"
        Me.LblProdOrderNo.Size = New System.Drawing.Size(130, 16)
        Me.LblProdOrderNo.TabIndex = 731
        Me.LblProdOrderNo.Text = "Production Order No."
        '
        'BtnFillDeatil
        '
        Me.BtnFillDeatil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillDeatil.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillDeatil.Location = New System.Drawing.Point(862, 346)
        Me.BtnFillDeatil.Name = "BtnFillDeatil"
        Me.BtnFillDeatil.Size = New System.Drawing.Size(113, 25)
        Me.BtnFillDeatil.TabIndex = 732
        Me.BtnFillDeatil.Text = "Copy Std. Qty"
        Me.BtnFillDeatil.UseVisualStyleBackColor = True
        '
        'TempMaterialPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 626)
        Me.Controls.Add(Me.BtnFillDeatil)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.LblMaterialPlanForFollowingItems)
        Me.Controls.Add(Me.LblConsumptionDetailForAboveItems)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Pnl2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempMaterialPlan"
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
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.LblConsumptionDetailForAboveItems, 0)
        Me.Controls.SetChildIndex(Me.LblMaterialPlanForFollowingItems, 0)
        Me.Controls.SetChildIndex(Me.BtnFill, 0)
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
    Protected WithEvents TxtProductionPlanNo As AgControls.AgTextBox
    Protected WithEvents LblProductionPlanNo As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LblProductionPlanNoReq As System.Windows.Forms.Label
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents Panel2 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalComputerConsumptionPlanQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalComputerConsumptionPlanQtyText As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserConsumptionPlanQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalUserConsumptionPlanQtyText As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents LblConsumptionDetailForAboveItems As System.Windows.Forms.LinkLabel
    Protected WithEvents LblMaterialPlanForFollowingItems As System.Windows.Forms.LinkLabel
    Protected WithEvents LblProdOrderNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtProdOrderNo As AgControls.AgTextBox
    Protected WithEvents LblProdOrderNo As System.Windows.Forms.Label
    Protected WithEvents LblTotalConsumptionQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalConsumptionQtyText As System.Windows.Forms.Label
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "MaterialPlan"
        LogTableName = "MaterialPlan_Log"
        MainLineTableCsv = "MaterialPlanForDetail,MaterialPlanDetail"
        LogLineTableCsv = "MaterialPlanForDetail_Log,MaterialPlanDetail_Log"
        AgL.GridDesign(Dgl1)
        AgL.GridDesign(Dgl2)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("M.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                       " And " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "M.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select M.DocID As SearchCode " & _
            " From MaterialPlan M " & _
            " Left Join Voucher_Type Vt On M.V_Type = Vt.V_Type  " & _
            " Where IsNull(IsDeleted,0) = 0  " & mCondStr & "  Order By M.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("M.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "M.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select M.UID As SearchCode " & _
               " From MaterialPlan_Log M " & _
               " Left Join Voucher_Type Vt On M.V_Type = Vt.V_Type  " & _
               " Where M.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By M.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = " SELECT P.DocID, P.V_Type + '-'+ Convert(NVARCHAR,P.V_No) [Plan NO], P.V_Date AS [Plan Date], " & _
        '                    " V.V_Type + Convert(nVarChar,Po.V_No) As [Prod. Plan No],POR.ManualRefNo AS [Prod. Order. No] " & _
        '                    " FROM MaterialPlan P " & _
        '                    " LEFT JOIN Voucher_type Vt ON P.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN MaterialPlan Po On P.ProdPlan  = Po.DocId " & _
        '                    " LEFT JOIN Voucher_type V ON Po.V_Type = V.V_Type " & _
        '                    " LEFT JOIN ProdOrder POR ON POR.DocID=P.ProdOrder " & _
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

        'AgL.PubFindQry = " SELECT P.UID, P.V_Type + '-'+ Convert(NVARCHAR,P.V_No) [Plan NO], P.V_Date AS [Plan Date], " & _
        '                    " V.V_Type + Convert(nVarChar,Po.V_No) As [Prod. Plan No],POR.ManualRefNo AS [Prod. Order. No] " & _
        '                    " FROM MaterialPlan P " & _
        '                    " LEFT JOIN Voucher_type Vt ON P.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN MaterialPlan Po On P.ProdPlan  = Po.DocId " & _
        '                    " LEFT JOIN Voucher_type V ON Po.V_Type = V.V_Type " & _
        '                    " LEFT JOIN ProdOrder POR ON POR.DocID=P.ProdOrder " & _
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
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 100, 8, 4, False, Col1Qty, True, True, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 100, 0, Col1MeasureUnit, False, True, False)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgTextColumn(Dgl1, Col1BOM, 200, 0, Col1BOM, False, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.AllowUserToAddRows = False
        Dgl1.AgSkipReadOnlyColumns = True

        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Item, 200, 0, Col2Item, True, True, False)
            .AddAgNumberColumn(Dgl2, Col2BomQty, 90, 8, 4, False, Col2BomQty, True, True, True)
            .AddAgTextColumn(Dgl2, Col2Unit, 50, 0, Col2Unit, True, True, False)
            .AddAgNumberColumn(Dgl2, Col2StockQty, 70, 8, 4, False, Col2StockQty, True, True, True)
            .AddAgNumberColumn(Dgl2, Col2PendingPurchaseOrderQty, 70, 8, 4, False, Col2PendingPurchaseOrderQty, True, True, True)
            .AddAgNumberColumn(Dgl2, Col2IssuedQty_ProdPlan, 90, 8, 4, False, Col2IssuedQty_ProdPlan, True, True, True)
            .AddAgNumberColumn(Dgl2, Col2ExcessQty_Finished, 70, 8, 4, False, Col2ExcessQty_Finished, True, True, True)
            .AddAgNumberColumn(Dgl2, Col2ComputerMaterialPlanQty, 80, 8, 4, False, Col2ComputerMaterialPlanQty, True, True, True)
            .AddAgNumberColumn(Dgl2, Col2ComputerMaterialPlanMeasure, 90, 8, 4, False, Col2ComputerMaterialPlanMeasure, False, True, True)
            .AddAgNumberColumn(Dgl2, Col2UserMaterialPlanQty, 70, 8, 3, False, Col2UserMaterialPlanQty, True, False, True)
            .AddAgNumberColumn(Dgl2, Col2UserMaterialPlanMeasure, 80, 8, 4, False, Col2UserMaterialPlanMeasure, False, True, True)
            .AddAgTextColumn(Dgl2, Col2UserMaterialPlanRemarks, 190, 255, Col2UserMaterialPlanRemarks, True, False)
            .AddAgNumberColumn(Dgl2, Col2MeasurePerPcs, 100, 8, 3, False, Col2MeasurePerPcs, False, True, True)
            .AddAgTextColumn(Dgl2, Col2MeasureUnit, 70, 0, Col2MeasureUnit, False, True, False)
            .AddAgNumberColumn(Dgl2, Col2PurchOrdQty, 100, 8, 4, False, Col2PurchOrdQty, False, True, True)
            .AddAgNumberColumn(Dgl2, Col2PurchOrdMeasure, 100, 8, 4, False, Col2PurchOrdMeasure, False, True, True)
            .AddAgNumberColumn(Dgl2, Col2PurchQty, 70, 8, 4, False, Col2PurchQty, False, True, True)
            .AddAgNumberColumn(Dgl2, Col2PurchMeasure, 100, 8, 4, False, Col2PurchMeasure, False, True, True)
            .AddAgNumberColumn(Dgl2, Col2ProdIssQty, 100, 8, 4, False, Col2ProdIssQty, False, True, True)
            .AddAgNumberColumn(Dgl2, Col2ProdIssMeasure, 80, 8, 4, False, Col2ProdIssMeasure, False, True, True)
        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.ColumnHeadersHeight = 50
        Dgl2.AllowUserToAddRows = False
        Dgl2.AgSkipReadOnlyColumns = True

        FrmProductionOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "UPDATE MaterialPlan_Log " & _
                " SET " & _
                " ProdOrder = " & AgL.Chk_Text(TxtProdOrderNo.AgSelectedValue) & ", " & _
                " ProdPlan = " & AgL.Chk_Text(TxtProductionPlanNo.AgSelectedValue) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & ", " & _
                " TotalComputerConsumptionPlanQty = " & Val(LblTotalComputerConsumptionPlanQty.Text) & ", " & _
                " TotalUserConsumptionPlanQty = " & Val(LblTotalUserConsumptionPlanQty.Text) & ", " & _
                " TotalConsumptionQty = " & Val(LblTotalConsumptionQty.Text) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From MaterialPlanForDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1
                    mQry = "INSERT INTO MaterialPlanForDetail_Log(UID, DocId, Sr, Item, Qty, Unit, MeasurePerPcs, " & _
                            " TotalMeasure, MeasureUnit, ProdOrder) " & _
                            " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ", " & _
                            " " & Val(.Item(Col1Qty, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Unit, I).Value) & ",	" & _
                            " " & Val(.Item(Col1MeasurePerPcs, I).Value) & ", " & Val(.Item(Col1TotalMeasure, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1MeasureUnit, I).Value) & ", " & _
                            " " & AgL.Chk_Text(TxtProdOrderNo.AgSelectedValue) & " " & _
                            " )"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With

        mQry = "Delete From MaterialPlanDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2Item, I).Value <> "" Then
                    mSr += 2
                    mQry = "INSERT INTO MaterialPlanDetail_Log(UID, DocId,	Sr,	Item,	BomQty,	Unit,	StockQty, " & _
                            " IssuedQty_ProdPlan, ExcessQty_Finished, 	ComputerMaterialPlanQty,	ComputerMaterialPlanMeasure,	UserMaterialPlanQty, " & _
                            " UserMaterialPlanMeasure, UserMaterialPlanRemarks, MeasurePerPcs, MeasureUnit, " & _
                            " PurchOrdQty, PurchOrdMeasure, PurchQty, PurchMeasure, ProdIssQty, " & _
                            " ProdIssMeasure, PendingPurchaseOrderQty, ProdOrder) " & _
                            " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & ", " & _
                            " " & Val(.Item(Col2BomQty, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Unit, I).Value) & ", " & _
                            " " & Val(.Item(Col2StockQty, I).Value) & ", " & Val(.Item(Col2IssuedQty_ProdPlan, I).Value) & ", " & _
                            " " & Val(.Item(Col2ExcessQty_Finished, I).Value) & ", " & _
                            " " & Val(.Item(Col2ComputerMaterialPlanQty, I).Value) & ", " & _
                            " " & Val(.Item(Col2ComputerMaterialPlanMeasure, I).Value) & ",	" & _
                            " " & Val(.Item(Col2UserMaterialPlanQty, I).Value) & ", " & _
                            " " & Val(.Item(Col2UserMaterialPlanMeasure, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col2UserMaterialPlanRemarks, I).Value) & ", " & _
                            " " & Val(.Item(Col2MeasurePerPcs, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col2MeasureUnit, I).Value) & ", " & _
                            " " & Val(.Item(Col2PurchOrdQty, I).Value) & ",	" & _
                            " " & Val(.Item(Col2PurchOrdMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col2PurchQty, I).Value) & ", " & _
                            " " & Val(.Item(Col2PurchMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col2ProdIssQty, I).Value) & ", " & _
                            " " & Val(.Item(Col2ProdIssMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col2PendingPurchaseOrderQty, I).Value) & ", " & _
                            " " & AgL.Chk_Text(TxtProdOrderNo.AgSelectedValue) & " " & _
                            " ) "

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With
        mAddFlag = False
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
                TxtProdOrderNo.AgSelectedValue = AgL.XNull(.Rows(0)("ProdOrder"))
                TxtProductionPlanNo.AgSelectedValue = AgL.XNull(.Rows(0)("ProdPlan"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))
                LblTotalComputerConsumptionPlanQty.Text = AgL.VNull(.Rows(0)("TotalComputerConsumptionPlanQty"))
                LblTotalUserConsumptionPlanQty.Text = AgL.VNull(.Rows(0)("TotalUserConsumptionPlanQty"))
                LblTotalConsumptionQty.Text = AgL.VNull(.Rows(0)("TotalConsumptionQty"))
                Dgl1.Tag = AgL.XNull(.Rows(0)("ProdOrder"))

                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from MaterialPlanForDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from MaterialPlanForDetail_Log where UID = '" & SearchCode & "' Order By Sr"
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
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from MaterialPlanDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from MaterialPlanDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl2.RowCount = 1
                    Dgl2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgl2.Rows.Add()
                            Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                            Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl2.Item(Col2BomQty, I).Value = Format(AgL.VNull(.Rows(I)("BomQty")), "0.000")
                            Dgl2.Item(Col2Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl2.Item(Col2StockQty, I).Value = Format(AgL.VNull(.Rows(I)("StockQty")), "0.000")
                            Dgl2.Item(Col2PendingPurchaseOrderQty, I).Value = Format(AgL.VNull(.Rows(I)("PendingPurchaseOrderQty")), "0.000")
                            Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value = Format(AgL.VNull(.Rows(I)("IssuedQty_ProdPlan")), "0.000")
                            Dgl2.Item(Col2ExcessQty_Finished, I).Value = Format(AgL.VNull(.Rows(I)("ExcessQty_Finished")), "0.000")
                            Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value = Format(AgL.VNull(.Rows(I)("ComputerMaterialPlanQty")), "0.000")
                            Dgl2.Item(Col2ComputerMaterialPlanMeasure, I).Value = Format(AgL.VNull(.Rows(I)("ComputerMaterialPlanMeasure")), "0.000")
                            Dgl2.Item(Col2UserMaterialPlanQty, I).Value = Format(AgL.VNull(.Rows(I)("UserMaterialPlanQty")), "0.000")
                            Dgl2.Item(Col2UserMaterialPlanMeasure, I).Value = Format(AgL.VNull(.Rows(I)("UserMaterialPlanMeasure")), "0.000")
                            Dgl2.Item(Col2UserMaterialPlanRemarks, I).Value = AgL.XNull(.Rows(I)("UserMaterialPlanRemarks"))
                            Dgl2.Item(Col2MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                            Dgl2.Item(Col2MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl2.Item(Col2PurchOrdQty, I).Value = Format(AgL.VNull(.Rows(I)("PurchOrdQty")), "0.000")
                            Dgl2.Item(Col2PurchOrdMeasure, I).Value = Format(AgL.VNull(.Rows(I)("PurchOrdMeasure")), "0.000")
                            Dgl2.Item(Col2PurchQty, I).Value = Format(AgL.VNull(.Rows(I)("PurchQty")), "0.000")
                            Dgl2.Item(Col2PurchMeasure, I).Value = Format(AgL.VNull(.Rows(I)("PurchMeasure")), "0.000")
                            Dgl2.Item(Col2ProdIssQty, I).Value = Format(AgL.VNull(.Rows(I)("ProdIssQty")), "0.000")
                            Dgl2.Item(Col2ProdIssMeasure, I).Value = Format(AgL.VNull(.Rows(I)("ProdIssMeasure")), "0.000")
                            Dgl2.Item(Col2PendingPurchaseOrderQty, I).Value = Format(AgL.VNull(.Rows(I)("PendingPurchaseOrderQty")), "0.000")

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
        Topctrl1.ChangeAgGridState(Dgl2, False)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd

    End Sub

    Private Sub FrmProductionOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, I.Status, I.Measure, MeasureUnit " & _
                " FROM Item I"
        Dgl1.AgHelpDataSet(Col1Item, 6) = AgL.FillData(mQry, AgL.GCn)
        Dgl2.AgHelpDataSet(Col2Item, 6) = Dgl1.AgHelpDataSet(Col1Item).Copy

        'mQry = "SELECT Po.DocID AS Code, Vt.Description + '/' + Convert(NVARCHAR,Po.V_No) AS ProductionPlanNo, " & _
        '        " IsNull(Po.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, " & _
        '        " Po.MoveToLog, IsNull(Po.IsDeleted ,0) AS IsDeleted, " & _
        '        " Po.V_Date As ProductionPlanDate, Po.Div_Code, V1.ProdPlan " & _
        '        " FROM MaterialPlan Po " & _
        '        " LEFT JOIN ( " & _
        '        " 	    SELECT Pp.ProdPlan " & _
        '        " 	    FROM MaterialPlan Pp " & _
        '        "       LEFT JOIN Voucher_Type Vt On Pp.V_Type = Vt.V_Type " & _
        '        "       WHERE IsNull(Pp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
        '        "       AND Vt.NCat = '" & EntryNCat & "' " & _
        '        " ) AS V1 ON Po.DocId = V1.ProdPlan	 " & _
        '        " LEFT JOIN Voucher_Type Vt ON Po.V_Type = Vt.V_Type " & _
        '        " WHERE Vt.NCat = '" & AgTemplate_Production.ClsMain.Temp_NCat.ProductionPlan & "' "

        mQry = "SELECT Pp.DocID AS Code, " & _
                " Pp.V_Type + '-' + Convert(NVARCHAR,Pp.V_No) AS ProductionPlanNo,  " & _
                " IsNull(Pp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, " & _
                " Pp.MoveToLog, IsNull(Pp.IsDeleted ,0) AS IsDeleted " & _
                " FROM MaterialPlan Pp " & _
                " LEFT JOIN Voucher_Type Vt ON Pp.V_Type = Vt.V_Type "
        TxtProductionPlanNo.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Po.DocID AS Code, Po.ManualRefNo as [Prod.Order No. Manual], PO.V_Type + '-' + Convert(NVARCHAR,Po.V_No) AS ProductionOrderNo, " & _
                " IsNull(Po.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, " & _
                " Po.MoveToLog, IsNull(Po.IsDeleted ,0) AS IsDeleted, " & _
                " Po.V_Date As ProductionOrderDate, Po.Div_Code, V1.MaterialPlanDocId, V2.ProductionPlanDocId " & _
                " FROM ProdOrder Po " & _
                " LEFT JOIN ( " & _
                "       SELECT Mp.DocID AS MaterialPlanDocId, Mp.ProdOrder " & _
                "       FROM MaterialPlan Mp " & _
                "       LEFT JOIN Voucher_Type V ON Mp.V_Type = V.V_Type " & _
                "       WHERE IsNull(Mp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                "       And IsNull(Mp.IsDeleted,0) = 0  " & _
                "       AND V.NCat = '" & EntryNCat & "' " & _
                " ) AS V1 ON Po.DocId = V1.ProdOrder " & _
                " LEFT JOIN ( " & _
                "       SELECT Pp.DocId As ProductionPlanDocId, Pp.ProdOrder " & _
                "       From MaterialPlan Pp " & _
                "       LEFT JOIN Voucher_Type V On Pp.V_Type = V.V_Type " & _
                "       WHERE IsNull(Pp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                "       And IsNull(Pp.IsDeleted,0) = 0  " & _
                "       AND V.NCat = '" & ClsMain.Temp_NCat.ProductionPlan & "'" & _
                " ) AS V2 ON Po.DocId = V2.ProdOrder " & _
                " LEFT JOIN Voucher_Type Vt ON Po.V_Type = Vt.V_Type " & _
                " WHERE Vt.NCat = '" & ClsMain.Temp_NCat.ProductionOrder & "'"
        TxtProdOrderNo.AgHelpDataSet(7, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 And Status <= '" & AgTemplate.ClsMain.EntryStatus.Active & "' And " & ClsMain.RetDivFilterStr & "  "
        End Select
    End Sub

    Private Sub Dgl2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl2.CellEnter
        Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
            Case Col2Item
                Dgl2.AgRowFilter(Dgl2.Columns(Col2Item).Index) = " IsDeleted = 0 And Status <= '" & AgTemplate.ClsMain.EntryStatus.Active & "' And " & ClsMain.RetDivFilterStr & "  "
        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl2.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0 : LblTotalMeasure.Text = 0
        LblTotalComputerConsumptionPlanQty.Text = 0
        LblTotalUserConsumptionPlanQty.Text = 0
        LblTotalConsumptionQty.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")
                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
            End If
        Next

        For I = 0 To Dgl2.RowCount - 1
            If Dgl2.Item(Col2Item, I).Value <> "" Then
                Dgl2.Item(Col2ComputerMaterialPlanMeasure, I).Value = Format(Val(Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value) * Val(Dgl2.Item(Col2MeasurePerPcs, I).Value), "0.00")
                Dgl2.Item(Col2UserMaterialPlanMeasure, I).Value = Format(Val(Dgl2.Item(Col2UserMaterialPlanQty, I).Value) * Val(Dgl2.Item(Col2MeasurePerPcs, I).Value), "0.00")
                'Footer Calculation
                LblTotalComputerConsumptionPlanQty.Text = Val(LblTotalComputerConsumptionPlanQty.Text) + Val(Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value)
                LblTotalUserConsumptionPlanQty.Text = Val(LblTotalUserConsumptionPlanQty.Text) + Val(Dgl2.Item(Col2UserMaterialPlanQty, I).Value)
                LblTotalConsumptionQty.Text = Val(LblTotalConsumptionQty.Text) + Val(Dgl2.Item(Col2BomQty, I).Value)
            End If
        Next
        LblTotalComputerConsumptionPlanQty.Text = Format(Val(LblTotalComputerConsumptionPlanQty.Text), "0.00")
        LblTotalUserConsumptionPlanQty.Text = Format(Val(LblTotalUserConsumptionPlanQty.Text), "0.00")
        LblTotalConsumptionQty.Text = Format(Val(LblTotalConsumptionQty.Text), "0.00")
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.00")
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If AgL.RequiredField(TxtProductionPlanNo, LblProductionPlanNo.Text) Then passed = False : Exit Sub
        If Validate_ProductionOrder() = False Then passed = False : Exit Sub
        If Validate_ProductionPlan() = False Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsBlankGrid(Dgl2, Dgl2.Columns(Col2Item).Index) Then passed = False : Exit Sub

        If TxtProductionPlanNo.AgSelectedValue <> "" Then
            If TxtProdOrderNo.AgSelectedValue <> Dgl1.Tag Then
                MsgBox("Data In Grid Does Not Belong To " & TxtProdOrderNo.Text & "", MsgBoxStyle.Information)
                TxtProdOrderNo.Focus()
                passed = False : Exit Sub
            End If
        End If
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        Dgl1.Tag = "" : LblProductionPlanNo.Tag = ""
        LblTotalMeasure.Text = 0 : LblTotalQty.Text = 0
        LblTotalComputerConsumptionPlanQty.Text = 0 : LblTotalUserConsumptionPlanQty.Text = 0
    End Sub

    Private Function Validate_ProductionOrder() As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If TxtProdOrderNo.Text <> "" Then
                DrTemp = TxtProdOrderNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtProdOrderNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    TxtProductionPlanNo.AgSelectedValue = AgL.XNull(DrTemp(0)("ProductionPlanDocId"))
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Production Order """ & TxtProdOrderNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtProdOrderNo.Text = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Production Order """ & TxtProdOrderNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtProdOrderNo.Text = ""
                        Exit Function
                    End If
                End If

                mQry = "SELECT Count(Pp.DocID)  " & _
                        " FROM MaterialPlan_Log Pp " & _
                        " LEFT JOIN Voucher_Type Vt On Pp.V_Type = Vt.V_Type " & _
                        " WHERE Pp.ProdOrder = '" & TxtProdOrderNo.AgSelectedValue & "' " & _
                        " AND Pp.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "' " & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Edit"), "Pp.DocId <> '" & mInternalCode & "'", "1=1") & " " & _
                        " AND Vt.NCat = '" & EntryNCat & "'  "

                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar() > 0 Then
                    MsgBox("A Material Plan For Production Order """ & TxtProdOrderNo.Text & """ Already Exists In Log." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                    Exit Function
                End If
            End If
            Validate_ProductionOrder = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Function Validate_ProductionPlan() As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If TxtProductionPlanNo.Text <> "" Then
                DrTemp = TxtProductionPlanNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtProductionPlanNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Production Plan """ & TxtProductionPlanNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtProductionPlanNo.Text = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Production Plan """ & TxtProductionPlanNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtProductionPlanNo.Text = ""
                        Exit Function
                    End If
                End If

                mQry = "SELECT Count(Pp.DocID)  " & _
                        " FROM MaterialPlan_Log Pp " & _
                        " LEFT JOIN Voucher_Type Vt On Pp.V_Type = Vt.V_Type " & _
                        " WHERE Pp.ProdPlan = '" & TxtProductionPlanNo.AgSelectedValue & "' " & _
                        " AND Pp.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "' " & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Edit"), "Pp.DocId <> '" & mInternalCode & "'", "1=1") & " " & _
                        " AND Vt.NCat = '" & EntryNCat & "'  "

                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar() > 0 Then
                    MsgBox("A Material Plan For Production Plan """ & TxtProductionPlanNo.Text & """ Already Exists In Log." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                    Exit Function
                End If
            End If
            Validate_ProductionPlan = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtProductionPlanNo.Validating, TxtProdOrderNo.Validating, TxtProdOrderNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtV_Type.Name


                Case TxtProdOrderNo.Name
                    e.Cancel = Not Validate_ProductionOrder()
                    e.Cancel = Not Validate_ProductionPlan()

                    'Case TxtProductionPlanNo.Name
                    '    e.Cancel = Not Validate_ProductionPlan()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductionPlanNo.Enter, TxtProdOrderNo.Enter
        Try
            Select Case sender.name
                Case TxtProdOrderNo.Name
                    If TxtV_Date.Text <> "" Then
                        TxtProdOrderNo.AgRowFilter = " IsDeleted = 0 And ProductionOrderDate <= '" & TxtV_Date.Text & "' And Div_Code = '" & AgL.PubDivCode & "' And ProductionPlanDocId Is Not Null And (MaterialPlanDocId Is Null Or Code = '" & Dgl1.Tag & "')  "
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempProductionOrder_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtProductionPlanNo.Enabled = False
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

    Protected Sub Validating_Material(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl2.Item(Col2Item, mRow).Value.ToString.Trim = "" Or Dgl2.AgSelectedValue(Col2Item, mRow).ToString.Trim = "" Then
                Dgl2.Item(Col2Unit, mRow).Value = ""
                Dgl2.Item(Col2MeasurePerPcs, mRow).Value = 0
                Dgl2.Item(Col2MeasureUnit, mRow).Value = ""
            Else
                If Dgl2.AgHelpDataSet(Col2Item) IsNot Nothing Then
                    DrTemp = Dgl2.AgHelpDataSet(Col2Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl2.Item(Col2Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl2.Item(Col2MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("Measure"))
                    Dgl2.Item(Col2MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Material Function ")
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

    Protected Sub FillProductionPlanDetail()
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            mQry = "SELECT Pp.Item, Pp.UserMaterialPlanQty, Pp.Unit, Pp.MeasurePerPcs, Pp.MeasureUnit, Pp.TotalMeasure " & _
                    " FROM MaterialPlanDetail Pp " & _
                    " WHERE Pp.DocId = '" & TxtProductionPlanNo.AgSelectedValue & "'"

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("UserMaterialPlanQty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                        'Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                    Next I
                End If
            End With
            Dgl1.Tag = TxtProdOrderNo.AgSelectedValue
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub FillCarpetConsumption()
        Dim I As Integer = 0
        Dim bQry$ = ""
        Dim DsTemp As DataSet = Nothing
        Dim bTempTable$ = ""
        Try
            bTempTable = AgL.GetGUID(AgL.GCn).ToString
            mQry = "CREATE TABLE [#" & bTempTable & "] " & _
                    " (Item NVARCHAR(10), TotalConsumptionQty Float, " & _
                    " StockInHand Float, PendingPurchaseOrderQty Float, IssuedAgainstProductionPlan Float)  "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    mQry = "INSERT INTO [#" & bTempTable & "] (Item,TotalConsumptionQty) " & _
                            " SELECT Bd.Item, Bd.Qty * " & Val(.Item(Col1TotalMeasure, I).Value) & " " & _
                            " FROM Bom B  " & _
                            " LEFT JOIN BomDetail Bd ON B.Code = Bd.Code " & _
                            " WHERE B.Code = '" & Dgl1.Item(Col1BOM, I).Value & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                Next
            End With

            mQry = "Select C.Item From [#" & bTempTable & "] C Group By C.Item "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        mQry = "INSERT INTO [#" & bTempTable & "](Item,StockInHand) " & _
                                " SELECT S.Item, Sum(IsNull(S.Qty_Rec,0)) - Sum(IsNull(S.Qty_Iss,0)) As StockInHand " & _
                                " FROM Stock S " & _
                                " WHERE S.Item = '" & AgL.XNull(.Rows(I)("Item")) & "' " & _
                                " GROUP BY S.Item "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                    Next I
                End If
            End With

            mQry = "INSERT INTO [#" & bTempTable & "](Item, IssuedAgainstProductionPlan, PendingPurchaseOrderQty) " & _
                    " SELECT Mpd.Item, IsNull(Sum(Mpd.UserMaterialPlanQty),0) - IsNull(Sum(Mpd.ProdIssQty),0)," & _
                    " IsNull(Sum(Mpd.PurchOrdQty),0) - IsNull(Sum(Mpd.PurchQty),0) " & _
                    " FROM MaterialPlan Mp " & _
                    " LEFT JOIN MaterialPlanDetail Mpd ON Mp.DocID = Mpd.DocId " & _
                    " WHERE Mp.ProdPlan <> '" & TxtProductionPlanNo.AgSelectedValue & "' " & _
                    " And IsNull(Mp.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " And IsNull(Mp.IsDeleted,0) = 0 " & _
                    " GROUP BY Mpd.Item "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            mQry = "SELECT T.Item, Sum(IsNull(TotalConsumptionQty,0)) As BomQty, " & _
                    " Sum(IsNull(StockInHand,0)) As StockQty, " & _
                    " Sum(IsNull(PendingPurchaseOrderQty,0)) As PendingPurchaseOrderQty, " & _
                    " Sum(IsNull(IssuedAgainstProductionPlan,0)) As IssuedQty_ProdPlan " & _
                    " From [#" & bTempTable & "] T " & _
                    " Group By T.Item " & _
                    " HAVING Sum(IsNull(TotalConsumptionQty,0)) > 0 "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl2.RowCount = 1
                Dgl2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl2.Rows.Add()
                        Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                        Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl2.Item(Col2BomQty, I).Value = Format(AgL.VNull(.Rows(I)("BomQty")), "0.000")
                        Dgl2.Item(Col2StockQty, I).Value = Format(AgL.VNull(.Rows(I)("StockQty")), "0.000")
                        Dgl2.Item(Col2PendingPurchaseOrderQty, I).Value = Format(AgL.VNull(.Rows(I)("PendingPurchaseOrderQty")), "0.000")
                        Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value = Format(AgL.VNull(.Rows(I)("IssuedQty_ProdPlan")), "0.000")
                        Dgl2.Item(Col2ExcessQty_Finished, I).Value = Format(IIf(Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value) > 0, Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value), 0), "0.000")
                        Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value = Format(IIf(Val(Dgl2.Item(Col2BomQty, I).Value) - (IIf(Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value) > 0, Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value), 0)) > 0, Val(Dgl2.Item(Col2BomQty, I).Value) - (IIf(Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value) > 0, Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value), 0)), 0), "0.000")
                        Dgl2.Item(Col2UserMaterialPlanQty, I).Value = Format(Val(Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value), "0.000")
                        Validating_Material(Dgl2.AgSelectedValue(Col2Item, I), I)
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        FillProductionPlanDetail()
        RaiseEvent BaseFunction_PostGrid1Fill()
        FillCarpetConsumption()
        RaiseEvent BaseFunction_PostGrid2Fill()
        Calculation()
    End Sub

    Private Sub FrmCarpetMaterialPlan_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        Dim mQry$ = ""
        Try
            If mAddFlag = True Then
                mQry = "SELECT Count(Pp.DocID)  " & _
                        " FROM MaterialPlan_Log Pp " & _
                        " LEFT JOIN Voucher_Type Vt On Pp.V_Type = Vt.V_Type " & _
                        " WHERE Pp.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "' " & _
                        " And Vt.NCat = '" & EntryNCat & "' "
                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar() > 0 Then
                    Topctrl1.FButtonClick(14, True)
                    MsgBox("You can create only one Materail Plan at a time." & vbCrLf & "First approve the existing material plans in log then you can continue...!", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                Topctrl1.FButtonClick(14, True)
                mAddFlag = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Dgl2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl2.CurrentCell.RowIndex
            mColumnIndex = Dgl2.CurrentCell.ColumnIndex
            If Dgl2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl2.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
                Case Col2Item

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillDeatil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillDeatil.Click
        If Topctrl1.Mode <> "Browse" Then
            Dim I As Integer
            With Dgl2
                If .RowCount <> 0 Then
                    For I = 0 To .RowCount - 1
                        If .Item(Col2Item, I).Value <> "" Then
                            Dgl2.Item(Col2UserMaterialPlanQty, I).Value = Dgl2.Item(Col2BomQty, I).Value
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
                    "   WHERE L.ProdOrder = '" & TxtProdOrderNo.AgSelectedValue & "' " & _
                    "   And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Job Order " & bRData & " created against Prod Order No. " & TxtProdOrderNo.Text & ". Can't Modify Entry")
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
