Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmGRN
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid


    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1OrderNo As String = "Order No."
    Protected Const Col1Orderuid As String = "Order Uid"
    Protected Const Col1GatePassNo As String = "Gate Pass No."
    Protected Const Col1GatePassuid As String = "Gate Pass Uid"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1ItemDescription As String = "Item Description"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1BatchNo As String = "Batch No"
    Protected Const Col1Godown As String = "Godown"
    Protected Const Col1DocQty As String = "Doc. Qty"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1SalesTaxGroupItem As String = "Sales Tax Group"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"


    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Dim _BlnManageStock As Boolean = True, _BlnManageAccount As Boolean = True
    Dim _eQuantityType As eQuantityType = eQuantityType.Receive
#Region "Form Designer Code"
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtOrderNo As AgControls.AgTextBox
    Protected WithEvents LblOrderNo As System.Windows.Forms.Label
    Protected WithEvents RbtGRNDirect As System.Windows.Forms.RadioButton
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Friend WithEvents LblSalesTaxGroupParty As System.Windows.Forms.Label
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents LblAcCodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtAcCode As AgControls.AgTextBox
    Protected WithEvents LblAcCode As System.Windows.Forms.Label
    Protected WithEvents TxtPartyBillDate As AgControls.AgTextBox
    Protected WithEvents LblPartyBillDate As System.Windows.Forms.Label
    Protected WithEvents TxtPartyBillNo As AgControls.AgTextBox
    Protected WithEvents LblPartyBillNo As System.Windows.Forms.Label
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblValNetAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextNetAmount As System.Windows.Forms.Label
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtGatePass As AgControls.AgTextBox
    Protected WithEvents lblGatePass As System.Windows.Forms.Label
    Protected WithEvents RbtGRNForOrder As System.Windows.Forms.RadioButton
    Private Sub InitializeComponent()
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalQty = New System.Windows.Forms.Label
        Me.LblValNetAmount = New System.Windows.Forms.Label
        Me.LblTextNetAmount = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtOrderNo = New AgControls.AgTextBox
        Me.LblOrderNo = New System.Windows.Forms.Label
        Me.RbtGRNDirect = New System.Windows.Forms.RadioButton
        Me.RbtGRNForOrder = New System.Windows.Forms.RadioButton
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.LblSalesTaxGroupParty = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtStructure = New AgControls.AgTextBox
        Me.LblAcCodeReq = New System.Windows.Forms.Label
        Me.TxtAcCode = New AgControls.AgTextBox
        Me.LblAcCode = New System.Windows.Forms.Label
        Me.TxtPartyBillDate = New AgControls.AgTextBox
        Me.LblPartyBillDate = New System.Windows.Forms.Label
        Me.TxtPartyBillNo = New AgControls.AgTextBox
        Me.LblPartyBillNo = New System.Windows.Forms.Label
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtGatePass = New AgControls.AgTextBox
        Me.lblGatePass = New System.Windows.Forms.Label
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDivision
        '
        '
        'TxtDocId
        '
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(273, 68)
        Me.LblV_No.Size = New System.Drawing.Size(60, 15)
        Me.LblV_No.Text = "Order No."
        '
        'TxtV_No
        '
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(146, 73)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(32, 68)
        Me.LblV_Date.Size = New System.Drawing.Size(67, 15)
        Me.LblV_Date.Text = "Order Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(146, 53)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(162, 67)
        Me.TxtV_Date.Size = New System.Drawing.Size(105, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(32, 48)
        Me.LblV_Type.Size = New System.Drawing.Size(67, 15)
        Me.LblV_Type.Text = "Order Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(162, 47)
        Me.TxtV_Type.Size = New System.Drawing.Size(304, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(146, 33)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(32, 28)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(162, 27)
        Me.TxtSite_Code.Size = New System.Drawing.Size(304, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(0, 3)
        Me.Tc1.Size = New System.Drawing.Size(992, 178)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtGatePass)
        Me.TP1.Controls.Add(Me.lblGatePass)
        Me.TP1.Controls.Add(Me.TxtPartyBillDate)
        Me.TP1.Controls.Add(Me.LblPartyBillDate)
        Me.TP1.Controls.Add(Me.TxtPartyBillNo)
        Me.TP1.Controls.Add(Me.LblPartyBillNo)
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.LblSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.LblAcCodeReq)
        Me.TP1.Controls.Add(Me.TxtAcCode)
        Me.TP1.Controls.Add(Me.LblAcCode)
        Me.TP1.Controls.Add(Me.RbtGRNDirect)
        Me.TP1.Controls.Add(Me.RbtGRNForOrder)
        Me.TP1.Controls.Add(Me.TxtOrderNo)
        Me.TP1.Controls.Add(Me.LblOrderNo)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Size = New System.Drawing.Size(984, 150)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtGRNForOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtGRNDirect, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAcCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAcCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAcCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyBillNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyBillNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyBillDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyBillDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblGatePass, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGatePass, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(162, 87)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(105, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(32, 88)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 1020
        Me.LblReferenceNo.Text = "Reference No."
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(146, 93)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 1021
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtRemark
        '
        Me.TxtRemark.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtRemark.Location = New System.Drawing.Point(610, 68)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(315, 18)
        Me.TxtRemark.TabIndex = 12
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(505, 70)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 1024
        Me.LblRemark.Text = "Remark"
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblValNetAmount)
        Me.PnlFooter.Controls.Add(Me.LblTextNetAmount)
        Me.PnlFooter.Location = New System.Drawing.Point(12, 381)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(986, 21)
        Me.PnlFooter.TabIndex = 795
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(707, 2)
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
        Me.LblTextTotalQty.Location = New System.Drawing.Point(618, 2)
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
        Me.LblValNetAmount.Location = New System.Drawing.Point(856, 2)
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
        Me.LblTextNetAmount.Location = New System.Drawing.Point(765, 3)
        Me.LblTextNetAmount.Name = "LblTextNetAmount"
        Me.LblTextNetAmount.Size = New System.Drawing.Size(93, 16)
        Me.LblTextNetAmount.TabIndex = 669
        Me.LblTextNetAmount.Text = "Net Payable :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(12, 202)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(973, 178)
        Me.Pnl1.TabIndex = 1
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtOrderNo.AgMandatory = False
        Me.TxtOrderNo.AgMasterHelp = False
        Me.TxtOrderNo.AgNumberLeftPlaces = 8
        Me.TxtOrderNo.AgNumberNegetiveAllow = False
        Me.TxtOrderNo.AgNumberRightPlaces = 2
        Me.TxtOrderNo.AgPickFromLastValue = False
        Me.TxtOrderNo.AgRowFilter = ""
        Me.TxtOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOrderNo.AgSelectedValue = Nothing
        Me.TxtOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderNo.Location = New System.Drawing.Point(610, 48)
        Me.TxtOrderNo.MaxLength = 20
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.Size = New System.Drawing.Size(109, 18)
        Me.TxtOrderNo.TabIndex = 10
        '
        'LblOrderNo
        '
        Me.LblOrderNo.AutoSize = True
        Me.LblOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrderNo.Location = New System.Drawing.Point(505, 49)
        Me.LblOrderNo.Name = "LblOrderNo"
        Me.LblOrderNo.Size = New System.Drawing.Size(68, 16)
        Me.LblOrderNo.TabIndex = 1026
        Me.LblOrderNo.Text = "Order No. "
        '
        'RbtGRNDirect
        '
        Me.RbtGRNDirect.AutoSize = True
        Me.RbtGRNDirect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtGRNDirect.Location = New System.Drawing.Point(747, 105)
        Me.RbtGRNDirect.Name = "RbtGRNDirect"
        Me.RbtGRNDirect.Size = New System.Drawing.Size(88, 17)
        Me.RbtGRNDirect.TabIndex = 13
        Me.RbtGRNDirect.TabStop = True
        Me.RbtGRNDirect.Text = "GRN Direct"
        Me.RbtGRNDirect.UseVisualStyleBackColor = True
        '
        'RbtGRNForOrder
        '
        Me.RbtGRNForOrder.AutoSize = True
        Me.RbtGRNForOrder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtGRNForOrder.Location = New System.Drawing.Point(618, 105)
        Me.RbtGRNForOrder.Name = "RbtGRNForOrder"
        Me.RbtGRNForOrder.Size = New System.Drawing.Size(109, 17)
        Me.RbtGRNForOrder.TabIndex = 12
        Me.RbtGRNForOrder.TabStop = True
        Me.RbtGRNForOrder.Text = "GRN For Order"
        Me.RbtGRNForOrder.UseVisualStyleBackColor = True
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgMandatory = False
        Me.TxtSalesTaxGroupParty.AgMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgNumberLeftPlaces = 0
        Me.TxtSalesTaxGroupParty.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupParty.AgNumberRightPlaces = 0
        Me.TxtSalesTaxGroupParty.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupParty.AgRowFilter = ""
        Me.TxtSalesTaxGroupParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupParty.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(162, 127)
        Me.TxtSalesTaxGroupParty.MaxLength = 0
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(304, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 7
        '
        'LblSalesTaxGroupParty
        '
        Me.LblSalesTaxGroupParty.AutoSize = True
        Me.LblSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalesTaxGroupParty.Location = New System.Drawing.Point(32, 129)
        Me.LblSalesTaxGroupParty.Name = "LblSalesTaxGroupParty"
        Me.LblSalesTaxGroupParty.Size = New System.Drawing.Size(98, 15)
        Me.LblSalesTaxGroupParty.TabIndex = 1033
        Me.LblSalesTaxGroupParty.Text = "Sales Tax Group"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(306, 88)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 1032
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'TxtStructure
        '
        Me.TxtStructure.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStructure.Location = New System.Drawing.Point(373, 87)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(93, 18)
        Me.TxtStructure.TabIndex = 5
        Me.TxtStructure.Visible = False
        '
        'LblAcCodeReq
        '
        Me.LblAcCodeReq.AutoSize = True
        Me.LblAcCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAcCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAcCodeReq.Location = New System.Drawing.Point(146, 116)
        Me.LblAcCodeReq.Name = "LblAcCodeReq"
        Me.LblAcCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAcCodeReq.TabIndex = 1031
        Me.LblAcCodeReq.Text = "Ä"
        '
        'TxtAcCode
        '
        Me.TxtAcCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtAcCode.AgMandatory = True
        Me.TxtAcCode.AgMasterHelp = False
        Me.TxtAcCode.AgNumberLeftPlaces = 0
        Me.TxtAcCode.AgNumberNegetiveAllow = False
        Me.TxtAcCode.AgNumberRightPlaces = 0
        Me.TxtAcCode.AgPickFromLastValue = False
        Me.TxtAcCode.AgRowFilter = ""
        Me.TxtAcCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtAcCode.AgSelectedValue = Nothing
        Me.TxtAcCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAcCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAcCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAcCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcCode.Location = New System.Drawing.Point(162, 107)
        Me.TxtAcCode.MaxLength = 123
        Me.TxtAcCode.Name = "TxtAcCode"
        Me.TxtAcCode.Size = New System.Drawing.Size(304, 18)
        Me.TxtAcCode.TabIndex = 6
        '
        'LblAcCode
        '
        Me.LblAcCode.AutoSize = True
        Me.LblAcCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcCode.Location = New System.Drawing.Point(32, 109)
        Me.LblAcCode.Name = "LblAcCode"
        Me.LblAcCode.Size = New System.Drawing.Size(71, 15)
        Me.LblAcCode.TabIndex = 1030
        Me.LblAcCode.Text = "Party Name"
        '
        'TxtPartyBillDate
        '
        Me.TxtPartyBillDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtPartyBillDate.AgMandatory = False
        Me.TxtPartyBillDate.AgMasterHelp = False
        Me.TxtPartyBillDate.AgNumberLeftPlaces = 0
        Me.TxtPartyBillDate.AgNumberNegetiveAllow = False
        Me.TxtPartyBillDate.AgNumberRightPlaces = 0
        Me.TxtPartyBillDate.AgPickFromLastValue = False
        Me.TxtPartyBillDate.AgRowFilter = ""
        Me.TxtPartyBillDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtPartyBillDate.AgSelectedValue = Nothing
        Me.TxtPartyBillDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyBillDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPartyBillDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyBillDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyBillDate.Location = New System.Drawing.Point(814, 28)
        Me.TxtPartyBillDate.MaxLength = 35
        Me.TxtPartyBillDate.Name = "TxtPartyBillDate"
        Me.TxtPartyBillDate.Size = New System.Drawing.Size(111, 18)
        Me.TxtPartyBillDate.TabIndex = 9
        '
        'LblPartyBillDate
        '
        Me.LblPartyBillDate.AutoSize = True
        Me.LblPartyBillDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyBillDate.Location = New System.Drawing.Point(723, 30)
        Me.LblPartyBillDate.Name = "LblPartyBillDate"
        Me.LblPartyBillDate.Size = New System.Drawing.Size(61, 15)
        Me.LblPartyBillDate.TabIndex = 1037
        Me.LblPartyBillDate.Text = "Doc. Date"
        '
        'TxtPartyBillNo
        '
        Me.TxtPartyBillNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtPartyBillNo.AgMandatory = False
        Me.TxtPartyBillNo.AgMasterHelp = False
        Me.TxtPartyBillNo.AgNumberLeftPlaces = 0
        Me.TxtPartyBillNo.AgNumberNegetiveAllow = False
        Me.TxtPartyBillNo.AgNumberRightPlaces = 0
        Me.TxtPartyBillNo.AgPickFromLastValue = False
        Me.TxtPartyBillNo.AgRowFilter = ""
        Me.TxtPartyBillNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtPartyBillNo.AgSelectedValue = Nothing
        Me.TxtPartyBillNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyBillNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyBillNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyBillNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyBillNo.Location = New System.Drawing.Point(610, 28)
        Me.TxtPartyBillNo.MaxLength = 35
        Me.TxtPartyBillNo.Name = "TxtPartyBillNo"
        Me.TxtPartyBillNo.Size = New System.Drawing.Size(109, 18)
        Me.TxtPartyBillNo.TabIndex = 8
        '
        'LblPartyBillNo
        '
        Me.LblPartyBillNo.AutoSize = True
        Me.LblPartyBillNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyBillNo.Location = New System.Drawing.Point(505, 30)
        Me.LblPartyBillNo.Name = "LblPartyBillNo"
        Me.LblPartyBillNo.Size = New System.Drawing.Size(86, 15)
        Me.LblPartyBillNo.TabIndex = 1036
        Me.LblPartyBillNo.Text = "Document No."
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(387, 407)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(295, 140)
        Me.PnlCShowGrid2.TabIndex = 942
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(688, 407)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(297, 140)
        Me.PnlCShowGrid.TabIndex = 2
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(228, 406)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(126, 144)
        Me.PnlCalcGrid.TabIndex = 941
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 180)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(110, 20)
        Me.LinkLabel1.TabIndex = 740
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "ITEM DETAIL:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtGatePass
        '
        Me.TxtGatePass.AgAllowUserToEnableMasterHelp = False
        Me.TxtGatePass.AgMandatory = False
        Me.TxtGatePass.AgMasterHelp = False
        Me.TxtGatePass.AgNumberLeftPlaces = 8
        Me.TxtGatePass.AgNumberNegetiveAllow = False
        Me.TxtGatePass.AgNumberRightPlaces = 2
        Me.TxtGatePass.AgPickFromLastValue = False
        Me.TxtGatePass.AgRowFilter = ""
        Me.TxtGatePass.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGatePass.AgSelectedValue = Nothing
        Me.TxtGatePass.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGatePass.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGatePass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGatePass.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGatePass.Location = New System.Drawing.Point(814, 48)
        Me.TxtGatePass.MaxLength = 20
        Me.TxtGatePass.Name = "TxtGatePass"
        Me.TxtGatePass.Size = New System.Drawing.Size(111, 18)
        Me.TxtGatePass.TabIndex = 11
        '
        'lblGatePass
        '
        Me.lblGatePass.AutoSize = True
        Me.lblGatePass.BackColor = System.Drawing.Color.Transparent
        Me.lblGatePass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGatePass.Location = New System.Drawing.Point(723, 49)
        Me.lblGatePass.Name = "lblGatePass"
        Me.lblGatePass.Size = New System.Drawing.Size(98, 16)
        Me.lblGatePass.TabIndex = 1039
        Me.lblGatePass.Text = "Gate Pass No. "
        '
        'FrmGRN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmGRN"
        Me.Text = "GRN Entry"
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.Tc1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.GBoxApproved.ResumeLayout(False)
        Me.GBoxApproved.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxModified.ResumeLayout(False)
        Me.GBoxModified.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Class AgCalGridCharges
        Public Const GrossAmount As String = "GAMT"
        Public Const TotalLineAddition As String = "LAdd"
        Public Const TotalLineDeduction As String = "LDed"
        Public Const TotalLineNetAmount As String = "LNAmt"
        Public Const HeaderAddition As String = "HAdd"
        Public Const HeaderDeduction As String = "HDed"
        Public Const NetSubTotal As String = "NSTot"
        Public Const RoundOff As String = "ROff"
    End Class
    Public Enum eQuantityType
        Issue
        Receive
    End Enum

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.StoreGRN) & ""
    End Sub

    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property


    Public Property QuantityType() As eQuantityType
        Get
            QuantityType = _eQuantityType
        End Get
        Set(ByVal value As eQuantityType)
            _eQuantityType = value
        End Set
    End Property

    Public Property ManageStock() As Boolean
        Get
            ManageStock = _BlnManageStock
        End Get
        Set(ByVal value As Boolean)
            _BlnManageStock = value
        End Set
    End Property

    Public Property ManageAccount() As Boolean
        Get
            ManageAccount = _BlnManageAccount
        End Get
        Set(ByVal value As Boolean)
            _BlnManageAccount = value
        End Set
    End Property

    Public Class HelpDataSet
        Public Shared Party As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing
        Public Shared PurchOrderItem As DataSet = Nothing
        Public Shared PurchOrder As DataSet = Nothing
        Public Shared GatePassNo As DataSet = Nothing

        Public Shared SalesTaxGroupItem As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing

        Public Shared AgStructure As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_GRN"
        AglObj = AgL

        LblV_Type.Text = "GRN Type"
        LblV_Date.Text = "GRN Date"
        LblV_No.Text = "GRN No."
        TP1.Text = "GRN Detail"

        AglObj.GridDesign(DGL1)
        AglObj.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AglObj.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AglObj.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)

        AgCShowGrid1.Visible = True
        AgCShowGrid2.Visible = True

        AgCalcGrid1.AgLibVar = AglObj
        AgCalcGrid1.Visible = False

    End Sub

    Public Sub Form_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim mCondStr$ = ""

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "
        mCondStr = mCondStr & " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        mQry = " Select H.DocID As SearchCode " & _
                " From Store_GRN H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$ = " Where 1=1 "
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()

        mCondStr += " " & AglObj.CondStrFinancialYear("H.V_Date", AglObj.PubStartDate, AglObj.PubEndDate) & _
                        " And " & AglObj.PubSiteCondition("H.Site_Code", AglObj.PubSiteCode) & " "
        mCondStr += " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        AglObj.PubFindQry = "SELECT H.DocId AS SearchCode, H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " " & AglObj.V_No_Field("H.DocId") & " As [" & LblV_No.Text & "]," & _
                            " Vt.Description  As [" & LblV_Type.Text & "], " & _
                            " " & AglObj.ConvertDateTimeField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.DocumentNo  As [" & LblPartyBillNo.Text & "], " & _
                            " " & AglObj.ConvertDateTimeField("H.DocumentDate") & " As [" & LblPartyBillDate.Text & "], " & _
                            " Sg.Name AS [" & LblAcCode.Text & "], City.CityName AS [City Name], " & _
                            " H.TotalQty, H.InvoiceAmount, H.Remark, S.Name AS [Site Name], H.Div_Code, " & _
                            " H.PreparedBy As [Entry By], " & AglObj.ConvertDateTimeField("H.U_EntDt") & " As [Entry Date], " & _
                            " H.ModifiedBy As [Edit By], " & AglObj.ConvertDateTimeField("H.Edit_Date") & " As [Edit Date] " & _
                            " FROM dbo.Store_GRN H WITH (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S WITH (NoLock) ON S.Code = H.Site_Code  " & _
                            " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode  " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mCondStr

        AglObj.PubFindQryOrdBy = "Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, SearchCode "

        If GcnRead IsNot Nothing Then GcnRead.Dispose()

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1OrderNo, 110, 0, Col1OrderNo, False, False, False)
            .AddAgTextColumn(DGL1, Col1Orderuid, 110, 0, Col1Orderuid, False, False, False)
            .AddAgTextColumn(DGL1, Col1GatePassNo, 110, 0, Col1GatePassNo, False, False, False)
            .AddAgTextColumn(DGL1, Col1GatePassuid, 110, 0, Col1GatePassuid, False, False, False)
            .AddAgTextColumn(DGL1, Col1Item, 120, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 120, 255, Col1ItemDescription, True, False, False)
            .AddAgTextColumn(DGL1, Col1Unit, 70, 0, Col1Unit, True, True, False)
            .AddAgTextColumn(DGL1, Col1BatchNo, 80, 0, Col1BatchNo, True, False, False)
            .AddAgTextColumn(DGL1, Col1Godown, 80, 0, Col1Godown, True, False, False)
            .AddAgNumberColumn(DGL1, Col1DocQty, 60, 8, 3, False, Col1DocQty, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Qty, 60, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Rate, 60, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Amount, 80, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(DGL1, Col1SalesTaxGroupItem, 80, 0, Col1SalesTaxGroupItem, False, False, False)
            .AddAgTextColumn(DGL1, Col1Remark, 80, 255, Col1Remark, False, False, False)
            .AddAgTextColumn(DGL1, Col1UID, 80, 0, Col1UID, False, True, False)
            .AddAgTextColumn(DGL1, Col1TempUID, 80, 0, Col1TempUID, False, True, False)
        End With
        AglObj.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        Topctrl1.ChangeAgGridState(DGL1, Not AglObj.StrCmp(Topctrl1.Mode, "Browse"))

        AgCalcGrid1.Ini_Grid(mSearchCode)

        AgCalcGrid1.AgFixedRows = 5

        AgCShowGrid1.AgIsFixedRows = True
        AgCShowGrid1.AgParentCalcGrid = AgCalcGrid1
        AgCShowGrid2.AgParentCalcGrid = AgCalcGrid1
        If AgCalcGrid1.RowCount > 0 Then
            AgCShowGrid1.Ini_Grid()
            AgCShowGrid2.Ini_Grid()
        End If


        AgCalcGrid1.AgLineGrid = DGL1
        AgCalcGrid1.AgLineGridMandatoryColumn = DGL1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = DGL1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = DGL1.Columns(Col1SalesTaxGroupItem).Index
        AgCalcGrid1.Visible = False

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""

        mQry = "UPDATE dbo.Store_GRN " & _
                " SET " & _
                "   Structure = " & AglObj.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " 	ReferenceNo = " & AglObj.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " 	DocumentNo = " & AglObj.Chk_Text(TxtPartyBillNo.Text) & ", " & _
                " 	DocumentDate = " & AglObj.ConvertDate(TxtPartyBillDate.Text) & ", " & _
                " 	AcCode = " & AglObj.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                " 	Amount = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.GrossAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	NetAmount = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.TotalLineNetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	NetSubTotal = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.NetSubTotal, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	RoundOff = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.RoundOff, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	InvoiceAmount = " & Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                "   SalesTaxGroupParty = " & AglObj.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                "   Remark = " & AglObj.Chk_Text(TxtRemark.Text) & ", " & _
                "   PurchOrderDocId = " & AgL.Chk_Text(TxtOrderNo.AgSelectedValue) & ", " & _
                "   GatePassDocId = " & AgL.Chk_Text(TxtGatePass.AgSelectedValue) & ", " & _
                "   IsAgainstOrder=  " & IIf(RbtGRNForOrder.Checked, 1, 0) & " " & _
                "   Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mSearchCode, Conn, Cmd)

        '===================< Save Data in Stock Header Table >======================================
        '===============================< Start >====================================================
        '============================================================================================
        If ManageStock Then Call ProcSaveStockHeader(SearchCode, Conn, Cmd)
        '============================================================================================
        '===================< Save Data in Stock Header Table >======================================
        '===============================< Edn >======================================================


        If AglObj.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_GRNDetail WHERE DocId = '" & mSearchCode & "'"
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                bIntSr += 1

                If AglObj.XNull(DGL1.Item(Col1TempUID, bIntI).Value).ToString.Trim = "" Then
                    If AglObj.XNull(DGL1.Item(Col1UID, bIntI).Value).ToString.Trim = "" Then
                        DGL1.Item(Col1UID, bIntI).Value = AglObj.GetGUID(GcnRead).ToString
                    End If
                End If

                bStrLineUid = DGL1.Item(Col1UID, bIntI).Value

                mQry = "INSERT INTO dbo.Store_GRNDetail (" & _
                        " DocId, Sr, Uid, Item, ItemDescription, Unit, BatchNo, Godown, DocQty, Qty, Rate, Amount, NetAmount," & _
                        " SalesTaxGroupItem, Remark,PurchOrderDocId,PurchOrderUID,GatePassDocId,GatePassUID) " & _
                        " VALUES (" & AglObj.Chk_Text(mSearchCode) & ", " & bIntSr & ", " & AglObj.Chk_Text(bStrLineUid) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Unit, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1BatchNo, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Godown, bIntI)) & ", " & _
                        " " & Val(DGL1.Item(Col1DocQty, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Qty, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, bIntI).Value) & ", " & _
                        " " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.TotalLineNetAmount, bIntI, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1SalesTaxGroupItem, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & "," & AgL.Chk_Text(DGL1.AgSelectedValue(Col1OrderNo, bIntI)) & "," & AglObj.Chk_Text(DGL1.Item(Col1Orderuid, bIntI).Value) & "," & AgL.Chk_Text(DGL1.AgSelectedValue(Col1GatePassNo, bIntI)) & "," & AglObj.Chk_Text(DGL1.Item(Col1GatePassuid, bIntI).Value) & " " & _
                        " )"
                AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(mSearchCode, bIntSr, bIntI, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next


    End Sub
    Private Sub Form_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '============================================================================================
        '===================< Save Data in Stock Table >=============================================
        '============================< Start >=======================================================
        '============================================================================================
        If ManageStock Then Call ProcSaveStockLine(SearchCode, Sr, mGridRow, Conn, Cmd)
        '============================================================================================
        '===================< Save Data in Stock Table >=============================================
        '============================< End >=========================================================
        '============================================================================================
    End Sub
    Private Sub ProcSaveStockLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        Dim bStrLineUid$ = ""
        Dim bDblQty_Rec As Double = 0, bDblQty_Iss As Double = 0

        If QuantityType = eQuantityType.Receive Then
            bDblQty_Rec = Val(DGL1.Item(Col1Qty, mGridRow).Value)
            bDblQty_Iss = 0
        ElseIf QuantityType = eQuantityType.Issue Then
            bDblQty_Rec = 0
            bDblQty_Iss = Val(DGL1.Item(Col1Qty, mGridRow).Value)
        End If

        bStrLineUid = DGL1.Item(Col1UID, mGridRow).Value

        mQry = "INSERT INTO dbo.Store_Stock (DocId, Sr, UID, Div_Code, Site_Code, V_Type, V_Prefix, V_No, V_Date, " & _
                        " ReferenceNo, AcCode, Item, ItemDescription, Unit, BatchNo, Godown, DocQty, Qty_Rec, Qty_Iss, " & _
                        " Rate, Amount, NetAmount, Remark, Structure, SalesTaxGroupParty, SalesTaxGroupItem) " & _
                        " VALUES (" & _
                        " " & AglObj.Chk_Text(mSearchCode) & ", " & Sr & ", " & AglObj.Chk_Text(bStrLineUid) & ", " & _
                        " " & AglObj.Chk_Text(TxtDivision.AgSelectedValue) & ",  " & _
                        " " & AglObj.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AglObj.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AglObj.Chk_Text(LblPrefix.Text) & ", " & _
                        " " & Val(TxtV_No.Text) & ", " & _
                        " " & AglObj.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AglObj.Chk_Text(TxtReferenceNo.Text) & ", " & _
                        " " & AglObj.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, mGridRow)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, mGridRow).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Unit, mGridRow)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1BatchNo, mGridRow).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Godown, mGridRow)) & ", " & _
                        " " & Val(DGL1.Item(Col1DocQty, mGridRow).Value) & ", " & _
                        " " & bDblQty_Rec & ", " & _
                        " " & bDblQty_Iss & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, mGridRow).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, mGridRow).Value) & ", " & _
                        " " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.TotalLineNetAmount, mGridRow, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, mGridRow).Value) & ", " & _
                        " " & AglObj.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                        " " & AglObj.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & "," & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mGridRow)) & " " & _
                        " )"

        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub ProcSaveStockHeader(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        If AglObj.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = "INSERT INTO dbo.Store_StockHeader (DocId, Structure, PreparedBy, U_EntDt, U_AE)" & _
                    " VALUES (" & AglObj.Chk_Text(SearchCode) & ", " & _
                    " " & AglObj.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                    " " & AglObj.Chk_Text(AglObj.PubUserName) & ", " & _
                    " " & AglObj.Chk_Text(AglObj.PubLoginDate) & ", " & _
                    " 'A') "
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        Else
            mQry = "Update dbo.Store_StockHeader " & _
                    " SET  " & _
                    " Structure = " & AglObj.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                    " U_AE = 'E', " & _
                    " Edit_Date = " & AglObj.Chk_Text(AglObj.PubLoginDate) & ", " & _
                    " ModifiedBy = " & AglObj.Chk_Text(AglObj.PubUserName) & " " & _
                    " WHERE DocId = " & AglObj.Chk_Text(SearchCode) & " "
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        If AglObj.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_Stock WHERE DocId = " & AglObj.Chk_Text(SearchCode) & " "
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        If FGetRelationalData() = True Then
            Exit Sub
        End If
      
        '======================< Delete Stock Data >=================================================
        '============================< Start >=======================================================
        '============================================================================================
        mQry = "DELETE FROM Store_Stock WHERE DocId = " & AglObj.Chk_Text(SearchCode) & " "
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "DELETE FROM Store_StockHeader WHERE DocId = " & AglObj.Chk_Text(SearchCode) & " "
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '============================================================================================
        '======================< Delete Stock Data >=================================================
        '============================< End >=======================================================
        '============================================================================================


        mQry = "Delete From Store_GRNDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_GRN Where DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub
    Private Function FGetRelationalData() As Boolean
        Try

            Dim bRData As String
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT @Temp=@Temp+ X.VNo + ',' FROM (Select Distinct H.V_Type + '-' + Convert(VARCHAR,H.V_No) as VNo From Store_Stock L LEFT JOIN Store_Purchase H ON L.DocId = H.DocID WHERE L.GRNDocId = '" & TxtDocId.Text & "') As X "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchse " & bRData & " created against GRN No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer
        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
            " From Store_GRN H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AglObj.GcnRead)

                If AglObj.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AglObj.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = AgStructure.ClsMain.EntryPointType.Main
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AglObj.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AglObj.XNull(.Rows(0)("ReferenceNo"))

                TxtAcCode.AgSelectedValue = AglObj.XNull(.Rows(0)("AcCode"))
                TxtPartyBillNo.Text = AglObj.XNull(.Rows(0)("DocumentNo"))
                TxtPartyBillDate.Text = Format(AglObj.XNull(.Rows(0)("DocumentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                TxtSalesTaxGroupParty.AgSelectedValue = AglObj.XNull(.Rows(0)("SalesTaxGroupParty"))

                TxtRemark.Text = AglObj.XNull(.Rows(0)("Remark"))
                If AgL.VNull(.Rows(0)("IsAgainstOrder")) Then
                    RbtGRNForOrder.Checked = True
                    RbtGRNDirect.Checked = False
                Else
                    RbtGRNForOrder.Checked = False
                    RbtGRNDirect.Checked = True
                End If
                TxtOrderNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchOrderDocId"))
                TxtGatePass.AgSelectedValue = AgL.XNull(.Rows(0)("GatePassDocId"))

                LblValNetAmount.Text = Format(AglObj.VNull(.Rows(0)("InvoiceAmount")), "0.00")
                LblValTotalQty.Text = Format(AglObj.VNull(.Rows(0)("TotalQty")), "0.000")

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

             
                mQry = "Select L.* " & _
                                      " From Store_GRNDetail L With (NoLock) " & _
                                      " Where L.DocId = '" & SearchCode & "' " & _
                                      " Order By L.Sr"
                DtTemp = AglObj.FillData(mQry, AglObj.GCn).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1OrderNo, I) = AgL.XNull(.Rows(I)("PurchOrderDocId"))
                            DGL1.Item(Col1Orderuid, I).Value = AglObj.XNull(.Rows(I)("PurchOrderUID").ToString)

                            DGL1.AgSelectedValue(Col1GatePassNo, I) = AgL.XNull(.Rows(I)("GatePassDocId"))
                            DGL1.Item(Col1GatePassuid, I).Value = AglObj.XNull(.Rows(I)("GatePassUID").ToString)


                            DGL1.Item(Col1UID, bIntI).Value = AglObj.XNull(.Rows(bIntI)("UID").ToString)
                            DGL1.Item(Col1TempUID, bIntI).Value = AglObj.XNull(.Rows(bIntI)("UID").ToString)

                            DGL1.AgSelectedValue(Col1Item, bIntI) = AglObj.XNull(.Rows(bIntI)("Item"))
                            DGL1.Item(Col1ItemDescription, bIntI).Value = AglObj.XNull(.Rows(bIntI)("ItemDescription"))
                            DGL1.AgSelectedValue(Col1Godown, bIntI) = AglObj.XNull(.Rows(bIntI)("Godown"))
                            DGL1.AgSelectedValue(Col1Unit, bIntI) = AglObj.XNull(.Rows(bIntI)("Unit"))
                            DGL1.AgSelectedValue(Col1SalesTaxGroupItem, bIntI) = AglObj.XNull(.Rows(bIntI)("SalesTaxGroupItem"))

                            DGL1.Item(Col1DocQty, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("DocQty")), "0.000")
                            DGL1.Item(Col1Qty, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Qty")), "0.000")
                            DGL1.Item(Col1Rate, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Rate")), "0.00")
                            DGL1.Item(Col1Amount, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Amount")), "0.00")
                            DGL1.Item(Col1BatchNo, bIntI).Value = AglObj.XNull(.Rows(bIntI)("BatchNo"))
                            DGL1.Item(Col1Remark, bIntI).Value = AglObj.XNull(.Rows(bIntI)("Remark"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AglObj.VNull(.Rows(bIntI)("Sr")), bIntI)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AglObj.VNull(.Rows(bIntI)("Sr")), bIntI)

                        Next bIntI
                    End If
                End With
            End If
        End With

        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
              
        '-------------------------------------------------------------


        If SearchCode.Trim <> "" Then
            If mTransFlag Then
                Topctrl1.tEdit = False
                Topctrl1.tDel = False
                Topctrl1.tPrn = False
            Else
                If Me.FormType = eFormType.Main Then
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                End If
                If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
            End If
        End If

        Topctrl1.tPrn = False

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub
    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)
        Topctrl1.ChangeAgGridState(DGL1, False)
        AgCalcGrid1.FrmType = AgStructure.ClsMain.EntryPointType.Main
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AglObj.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
            IniGrid()
        Tc1.SelectedTab = TP1

        TxtSalesTaxGroupParty.AgSelectedValue = AglObj.XNull(DtStore_Enviro.Rows(0)("SalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue

        TxtPrepared.Text = AglObj.PubUserName
    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        '<Executbale Code>
        If FGetRelationalData() = True Then
            Exit Sub
        End If
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()

        Try
            mQry = "Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, " & _
                            " Sg.DispName AS PartyDispName, Sg.ManualCode, Sg.Nature, " & _
                            " '" & ClsMain.PartyMasterType.Cash & "' As MasterType,  " & _
                            " Sg.SalesTaxPostingGroup " & _
                            " From SubGroup Sg With (NoLock) " & _
                            " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                            " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                            " Where 1=1 And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Sg.Site_Code", AglObj.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AglObj.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & " " & _
                            " UNION ALL " & _
                            " Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, " & _
                            " Sg.DispName AS PartyDispName, Sg.ManualCode, Sg.Nature, " & _
                            " IsNull(P.MasterType,'') As MasterType, " & _
                            " Sg.SalesTaxPostingGroup " & _
                            " From Party P With (NoLock) " & _
                            " Left Join SubGroup Sg With (NoLock) On P.SubCode = Sg.SubCode " & _
                            " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                            " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                            " Where 1=1 And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Sg.Site_Code", AglObj.PubSiteCode, "Sg.CommonAc") & " " & _
                            " Order By Name "
            HelpDataSet.Party = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT Code, Description  FROM Structure With (NoLock)  ORDER BY Description "
            HelpDataSet.AgStructure = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT U.Code AS Code, U.Code AS Name FROM Store_Unit U With (NoLock)  ORDER BY U.Code"
            HelpDataSet.Unit = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT I.Code, I.Description AS [Name], I.Unit, " & _
                    " I.DisplayName AS [Display Name], I.ManualCode, " & _
                    " C.Description AS [Item Category], G.Description AS [Item Group], " & _
                    " I.Nature, I.MasterType, " & _
                    " I.PurchaseRate, I.SaleRate , I.MRP, I.PcsPerCase, " & _
                    " I.SalesTaxPostingGroup, " & _
                    " I.ItemCategory AS ItemCategoryCode, " & _
                    " I.ItemGroup AS ItemGroupCode " & _
                    " FROM Store_Item I  With (NoLock) " & _
                    " LEFT JOIN Store_ItemGroup G  With (NoLock) ON G.Code = I.ItemGroup  " & _
                    " LEFT JOIN Store_ItemCategory C With (NoLock)  ON C.Code = I.ItemCategory " & _
                     " Where I.MasterType = '" & ClsMain.ItemType.Store & "'" & _
                    " ORDER BY I.Nature, I.Description "
            HelpDataSet.Item = AglObj.FillData(mQry, GcnRead)


            mQry = "SELECT G.Code, G.Description AS Name FROM Store_Godown G  With (NoLock) ORDER BY G.Description "
            HelpDataSet.Godown = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                    " IsNull(P.Active,0) AS Active " & _
                    " FROM PostingGroupSalesTaxItem P With (NoLock)" & _
                    " Order By P.Description "
            HelpDataSet.SalesTaxGroupItem = AglObj.FillData(mQry, AglObj.GcnRead)


            mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                    " IsNull(P.Active,0) AS Active " & _
                    " FROM PostingGroupSalesTaxParty P With (NoLock)" & _
                    " Order By P.Description "
            HelpDataSet.SalesTaxGroupParty = AglObj.FillData(mQry, AglObj.GcnRead)


            mQry = "SELECT Po.DocID AS Code, Po.V_Type + '-' + Convert(NVARCHAR, Po.V_No) AS [Purch. Order No],Po.V_Date AS [Order Date], " & _
                    " PO.ReferenceNo AS [Manual No], PO.SubCode as Vendor , " & _
                    " Vt.NCat, Po.Div_Code ,  " & _
                    " Po.V_Date As PurchaseOrderDate " & _
                    " FROM Store_PurchOrder Po " & _
                    " Left Join " & _
                    " ( " & _
                    " SELECT Pod.DocId, IsNull(Sum(Pod.Qty),0) AS PendingQty " & _
                    " FROM Store_PurchOrderDetail Pod  " & _
                    " GROUP BY Pod.DocId) AS V1 ON Po.DocId = V1.DocId " & _
                    " LEFT JOIN Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
                    " LEFT JOIN SubGroup Sg On  PO.SubCode = Sg.SubCode "
            HelpDataSet.PurchOrder = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Pod.Item AS Code, I.Description AS Name, " & _
                      " I.Unit,  " & _
                      " Po.Div_Code,  Pod.Rate as PurchaseRate, Pod.Qty   As PendingQty, " & _
                      " Po.DocId As PurchOrder , Pod.DocId AS OrderDocId,Pod.Uid as OrderUID,I.SalesTaxPostingGroup " & _
                      " FROM Store_PurchOrderDetail Pod " & _
                      " LEFT JOIN Store_PurchOrder Po On Pod.DocId = Po.DocId " & _
                      " LEFT JOIN Store_Item I ON Pod.Item = I.Code " & _
                      " Where I.MasterType = '" & ClsMain.ItemType.Store & "'"
            HelpDataSet.PurchOrderItem = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Po.DocID AS Code,  Po.Manual_RefNo AS [Gate Pass No.],Po.VehicleNo AS [Vehicle No], Po.Driver as [Driver Name], Sg.DispName AS [Party],Po.V_Date AS [Gate Pass Date],PO.SubCode,Po.Uid as GatePassUID " & _
                  " FROM GateInOut Po " & _
                  " LEFT JOIN Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
                  " LEFT JOIN SubGroup Sg On  PO.SubCode = Sg.SubCode "
            HelpDataSet.GatePassNo = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtStructure.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.AgStructure.Copy
        TxtAcCode.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Party.Copy
        TxtSalesTaxGroupParty.AgHelpDataSet(1, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty.Copy
        DGL1.AgHelpDataSet(Col1SalesTaxGroupItem, 1) = HelpDataSet.SalesTaxGroupItem.Copy
        TxtOrderNo.AgHelpDataSet(5, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.PurchOrder
        TxtGatePass.AgHelpDataSet(4, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.GatePassNo


        'DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Unit) = HelpDataSet.Unit.Copy
        DGL1.AgHelpDataSet(Col1Godown) = HelpDataSet.Godown.Copy
        DGL1.AgHelpDataSet(Col1OrderNo, 5) = HelpDataSet.PurchOrder
        DGL1.AgHelpDataSet(Col1GatePassNo, 4) = HelpDataSet.GatePassNo

        Call IniItemList()

    End Sub
    Private Sub IniItemList(Optional ByVal All_Records As Boolean = True)
        If All_Records Then
            DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item
        Else
            DGL1.AgHelpDataSet(Col1Item, 7) = HelpDataSet.PurchOrderItem
        End If
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing

        If AglObj.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        LblValTotalQty.Text = ""
        LblValNetAmount.Text = ""

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
            If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""
            If DGL1.Item(Col1Rate, bIntI).Value Is Nothing Then DGL1.Item(Col1Rate, bIntI).Value = ""
            If DGL1.Item(Col1Amount, bIntI).Value Is Nothing Then DGL1.Item(Col1Amount, bIntI).Value = ""

            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                DGL1.Item(Col1Amount, bIntI).Value = Format(Val(DGL1.Item(Col1Qty, bIntI).Value) * Val(DGL1.Item(Col1Rate, bIntI).Value), "0.00")


                LblValTotalQty.Text = Val(LblValTotalQty.Text) + Val(DGL1.Item(Col1Qty, bIntI).Value)
            End If

            If TxtGatePass.AgSelectedValue <> "" Then
                DrTemp = TxtGatePass.AgHelpDataSet().Tables(0).Select("Code = '" & TxtGatePass.AgSelectedValue & "' ")
                DGL1.AgSelectedValue(Col1GatePassNo, bIntI) = AglObj.XNull(DrTemp(0)("Code"))
                DGL1.Item(Col1GatePassuid, bIntI).Value = AglObj.XNull(DrTemp(0)("GatePassUid").ToString)
            Else
                DGL1.AgSelectedValue(Col1GatePassNo, bIntI) = ""
                DGL1.Item(Col1GatePassuid, bIntI).Value = ""
            End If

        Next

        AgCalcGrid1.Calculation()

        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")
        LblValNetAmount.Text = Format(Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)), "0.00")


    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtAcCode, LblAcCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function


            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_GRN H With (NoLock) " & _
                        " WHERE H.ReferenceNo = " & AglObj.Chk_Text(TxtReferenceNo.Text) & " " & _
                        " AND " & IIf(AglObj.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AglObj.Chk_Text(mSearchCode) & " ") & " "
                If AglObj.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    MsgBox(LblReferenceNo.Text & " Already Exists!...")
                    TxtReferenceNo.Focus() : Exit Function
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Function
    Private Function Validate_PurchOrder(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case DGL1.Name
                    If DGL1.AgSelectedValue(Col1OrderNo, RowIndex) <> "" Then
                        DrTemp = DGL1.AgHelpDataSet(Col1OrderNo).Tables(0).Select("Code = '" & DGL1.AgSelectedValue(Col1OrderNo, RowIndex) & "' ")
                    End If
                    Validate_PurchOrder = True

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function Validate_GatePass(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case DGL1.Name
                    If DGL1.AgSelectedValue(Col1GatePassNo, RowIndex) <> "" Then
                        DrTemp = DGL1.AgHelpDataSet(Col1GatePassNo).Tables(0).Select("Code = '" & DGL1.AgSelectedValue(Col1GatePassNo, RowIndex) & "' ")
                        DGL1.Item(Col1GatePassuid, RowIndex).Value = AglObj.XNull(DrTemp(0)("GatePassUid").ToString)
                    End If
                    Validate_GatePass = True

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function



    Public Sub Form_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        mBlnIsApproved = False
    End Sub

    Private Sub TxtIndentNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOrderNo.Validating
        Try
            Select Case sender.Name

                Case TxtOrderNo.Name
                    If TxtOrderNo.Text.ToString.Trim = "" Then
                        TxtOrderNo.AgSelectedValue = ""
                        RbtGRNDirect.Checked = True
                    Else
                        RbtGRNForOrder.Checked = True
                    End If

            End Select
        Catch ex As Exception
        End Try
    End Sub
    'Private Sub Validating_PurchaseOrder(ByVal Code As String)
    '    Dim DrTemp As DataRow() = Nothing
    '    Try
    '        If TxtOrderNo.Text <> "" Then
    '            DrTemp = TxtOrderNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtOrderNo.Enter, TxtAcCode.Enter, TxtGatePass.Enter
        Try
            Select Case sender.name
                Case TxtAcCode.Name
                    TxtAcCode.AgRowFilter = " (MasterType = '" & ClsMain.PartyMasterType.Cash & "' Or MasterType = '" & ClsMain.PartyMasterType.Supplier & "') "

                Case TxtSalesTaxGroupParty.Name
                    sender.AgRowFilter = "  Active <> 0 "

                Case TxtGatePass.Name
                    TxtGatePass.AgRowFilter = "  SubCode = '" & AgL.XNull(TxtAcCode.AgSelectedValue) & "'"

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
         TxtV_Type.Validating, TxtAcCode.Validating, TxtRemark.Validating, TxtPartyBillNo.Validating, _
        TxtPartyBillDate.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, _
        TxtSite_Code.Validating, TxtStructure.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtSalesTaxGroupParty.Validating, TxtGatePass.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AglObj.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AglObj.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    Call IniGrid()

                Case TxtAcCode.Name
                    Call ProcValidatingControls(sender)

                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

               
            End Select

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AglObj.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
                Call ProcFillReferenceNo()
            End If


            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If AgL.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
                And AgL.XNull(LblPrefix.Text).ToString.Trim <> "" _
                And Val(TxtV_No.Text) > 0 Then

                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
                LblReferenceNo.Tag = TxtReferenceNo.Text
            End If
        End If
    End Sub
    Private Function ProcValidatingControls(ByVal Sender As Object) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case Sender.Name
                Case TxtAcCode.Name
                    If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                        Sender.AgSelectedValue = ""
                        TxtSalesTaxGroupParty.AgSelectedValue = ""
                    Else
                        If Sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                            TxtSalesTaxGroupParty.AgSelectedValue = AglObj.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                        End If
                    End If
                    DrTemp = Nothing
            End Select

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            ProcValidatingControls = bBlnReturn
        End Try
    End Function

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.

        If Enb Then
            '<Executable Code>
        End If
    End Sub

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                 
                    Case Col1DocQty
                        If DGL1.Item(Col1Qty, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Qty, mRowIndex).Value = ""

                        If Val(DGL1.Item(Col1Qty, mRowIndex).Value) = 0 _
                            And Val(DGL1.Item(Col1DocQty, mRowIndex).Value) > 0 Then

                            DGL1.Item(Col1Qty, mRowIndex).Value = DGL1.Item(Col1DocQty, mRowIndex).Value
                        End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name

                Case Col1Item
                    If TxtOrderNo.AgSelectedValue <> "" And RbtGRNForOrder.Checked = True Then
                        Call IniItemList(False)
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " PurchOrder = '" & TxtOrderNo.AgSelectedValue & "' "
                    ElseIf RbtGRNForOrder.Checked Then
                        Call IniItemList(False)
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " PurchOrder = '" & DGL1.AgSelectedValue(Col1OrderNo, mRowIndex) & "' "
                    Else
                        Call IniItemList()
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " Name Is Not Null "
                    End If

                Case Col1OrderNo
                    DGL1.AgRowFilter(DGL1.Columns(Col1OrderNo).Index) = "  PurchaseOrderDate <= '" & TxtV_Date.Text & "' "

                Case Col1SalesTaxGroupItem
                    DGL1.AgRowFilter(mColumnIndex) = " Active <> 0 "

                Case Col1GatePassNo
                    DGL1.AgRowFilter(DGL1.Columns(Col1GatePassNo).Index) = "  SubCode = '" & AgL.XNull(TxtAcCode.AgSelectedValue) & "' "


            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub
    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AglObj.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex
            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL1.Item(Col1Rate, mRowIndex).Value = ""
                        DGL1.AgSelectedValue(Col1OrderNo, mRowIndex) = ""
                        DGL1.AgSelectedValue(Col1Item, mRowIndex) = ""
                        DGL1.Item(Col1Orderuid, mRowIndex).Value = ""
                        DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = ""
                    Else
                        If DGL1.AgDataRow IsNot Nothing Then
                            If RbtGRNForOrder.Checked Then
                                DGL1.AgSelectedValue(Col1OrderNo, mRowIndex) = AgL.XNull(DGL1.AgDataRow.Cells("OrderDocId").Value)
                                DGL1.Item(Col1Orderuid, mRowIndex).Value = AglObj.XNull(DGL1.AgDataRow.Cells("OrderUID").Value.ToString)
                            End If
                            DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = AgL.XNull(DGL1.AgDataRow.Cells("SalesTaxPostingGroup").Value)
                            DGL1.Item(Col1Rate, mRowIndex).Value = AgL.XNull(DGL1.AgDataRow.Cells("PurchaseRate").Value)
                            DGL1.Item(Col1ItemDescription, mRowIndex).Value = AgL.XNull(DGL1.AgDataRow.Cells("Name").Value)
                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AgL.XNull(DGL1.AgDataRow.Cells("Unit").Value)
                        End If

                    End If

                Case Col1OrderNo
                    RbtGRNForOrder.Checked = True
                    e.Cancel = Not Validate_PurchOrder(DGL1, DGL1.CurrentCell.RowIndex)

                Case Col1GatePassNo
                    e.Cancel = Not Validate_GatePass(DGL1, DGL1.CurrentCell.RowIndex)

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub
    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Public Sub FrmMaterialVerification_BaseEvent_Approve_PreTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Approve_PreTrans
        '------------------------------------------------------------------------
        '<Executable Code For Before Record Apporval>
        '-------------------------------------------------------------------------  
    End Sub

    Public Sub Form_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        '------------------------------------------------------------------------
        '<Executable Code For Record Apporval>
        '-------------------------------------------------------------------------        
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        'Dim mCrd As New ReportDocument
        'Dim ReportView As New AgLibrary.RepView
        'Dim DsRep As New DataSet
        'Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        'Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    AgL.PubReportTitle = "Purchase Order"
        '    RepName = "Store_PurchOrder_Print" : RepTitle = AgL.PubReportTitle
        '    bTableName = "Store_PurchOrder" : bSecTableName = "Store_PurchOrderDetail P1 ON P1.DocID =P.DocID"
        '    bCondstr = "WHERE P.DocID='" & SearchCode & "' and Vt.NCat in (" & EntryNCatList & ")"


        '    strQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
        '            " P.Remark AS RemarkHeader,  P.ReferenceNo,P.TotalAmount,P.TotalQty, " & _
        '            " P.subcode, P1.Remark, P1.Sr,P1.Item, Qty,P1.Rate,P1.Amount, " & _
        '            " P1.Unit,  SM.Name AS SiteName,(ID.V_Type + '-' +convert(NVARCHAR(5),ID.V_No)) AS [Indent No],     " & _
        '            " I.Description AS ItemName,Sg.Name AS Supplier,P1.ItemDescription " & _
        '            " FROM " & bTableName & " P " & _
        '            " LEFT JOIN " & bSecTableName & "  " & _
        '            " LEFT JOIN Store_PurchIndent ID ON ID.DocID =P.PurchIndentDocId   " & _
        '            " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
        '            " LEFT JOIN Store_Item I ON I.Code=P1.Item " & _
        '            " LEFT JOIN SubGroup SG ON SG.SubCode=P.Subcode " & _
        '            " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type  " & _
        '            " " & bCondstr & ""

        '    AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
        '    AgL.ADMain.Fill(DsRep)
        '    AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
        '    mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
        '    mCrd.SetDataSource(DsRep.Tables(0))
        '    CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
        '    AgPL.Formula_Set(mCrd, RepTitle)
        '    AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

        '    Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try

    End Sub

End Class
