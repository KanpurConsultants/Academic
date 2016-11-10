Public Class TempPurchase
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

    Public Enum eQuantityType
        Issue
        Receive
    End Enum

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

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Protected WithEvents LblAcCodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtAcCode As AgControls.AgTextBox
    Protected WithEvents LblAcCode As System.Windows.Forms.Label
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblValNetAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextNetAmount As System.Windows.Forms.Label


    Protected WithEvents TxtPartyBillDate As AgControls.AgTextBox
    Protected WithEvents LblPartyBillDate As System.Windows.Forms.Label
    Protected WithEvents TxtPartyBillNo As AgControls.AgTextBox
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Friend WithEvents LblSalesTaxGroupParty As System.Windows.Forms.Label
    Protected WithEvents LblPartyBillNo As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.TxtAcCode = New AgControls.AgTextBox
        Me.LblAcCode = New System.Windows.Forms.Label
        Me.LblAcCodeReq = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalQty = New System.Windows.Forms.Label
        Me.LblValNetAmount = New System.Windows.Forms.Label
        Me.LblTextNetAmount = New System.Windows.Forms.Label
        Me.TxtPartyBillNo = New AgControls.AgTextBox
        Me.LblPartyBillNo = New System.Windows.Forms.Label
        Me.TxtPartyBillDate = New AgControls.AgTextBox
        Me.LblPartyBillDate = New System.Windows.Forms.Label
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.LblSalesTaxGroupParty = New System.Windows.Forms.Label
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
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 551)
        '
        'TxtDivision
        '
        '
        'TxtDocId
        '
        Me.TxtDocId.Location = New System.Drawing.Point(748, 78)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(296, 52)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(402, 51)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(130, 57)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(22, 52)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(130, 37)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(146, 51)
        Me.TxtV_Date.Size = New System.Drawing.Size(129, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(22, 32)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(146, 31)
        Me.TxtV_Type.Size = New System.Drawing.Size(350, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(130, 17)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(22, 12)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(146, 11)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(701, 80)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(363, 52)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 162)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.LblSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtPartyBillDate)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblPartyBillDate)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtPartyBillNo)
        Me.TP1.Controls.Add(Me.LblPartyBillNo)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.LblAcCodeReq)
        Me.TP1.Controls.Add(Me.TxtAcCode)
        Me.TP1.Controls.Add(Me.LblAcCode)
        Me.TP1.Size = New System.Drawing.Size(984, 134)
        Me.TP1.Controls.SetChildIndex(Me.LblAcCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAcCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAcCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyBillNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyBillNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyBillDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyBillDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
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
        Me.TxtRemark.Location = New System.Drawing.Point(625, 31)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 10
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(520, 33)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'TxtAcCode
        '
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
        Me.TxtAcCode.Location = New System.Drawing.Point(146, 91)
        Me.TxtAcCode.MaxLength = 123
        Me.TxtAcCode.Name = "TxtAcCode"
        Me.TxtAcCode.Size = New System.Drawing.Size(350, 18)
        Me.TxtAcCode.TabIndex = 6
        '
        'LblAcCode
        '
        Me.LblAcCode.AutoSize = True
        Me.LblAcCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcCode.Location = New System.Drawing.Point(22, 93)
        Me.LblAcCode.Name = "LblAcCode"
        Me.LblAcCode.Size = New System.Drawing.Size(71, 15)
        Me.LblAcCode.TabIndex = 732
        Me.LblAcCode.Text = "Party Name"
        '
        'LblAcCodeReq
        '
        Me.LblAcCodeReq.AutoSize = True
        Me.LblAcCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAcCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAcCodeReq.Location = New System.Drawing.Point(130, 100)
        Me.LblAcCodeReq.Name = "LblAcCodeReq"
        Me.LblAcCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAcCodeReq.TabIndex = 733
        Me.LblAcCodeReq.Text = "Ä"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(5, 201)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(972, 172)
        Me.Pnl1.TabIndex = 1
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(130, 78)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 771
        Me.LblReferenceNoReq.Text = "Ä"
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(146, 71)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(129, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(22, 71)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(74, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Manual No."
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblValNetAmount)
        Me.PnlFooter.Controls.Add(Me.LblTextNetAmount)
        Me.PnlFooter.Location = New System.Drawing.Point(5, 372)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(972, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(741, 3)
        Me.LblValTotalQty.Name = "LblValTotalQty"
        Me.LblValTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQty.TabIndex = 668
        Me.LblValTotalQty.Text = "."
        Me.LblValTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalQty
        '
        Me.LblTextTotalQty.AutoSize = True
        Me.LblTextTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalQty.Location = New System.Drawing.Point(652, 3)
        Me.LblTextTotalQty.Name = "LblTextTotalQty"
        Me.LblTextTotalQty.Size = New System.Drawing.Size(89, 16)
        Me.LblTextTotalQty.TabIndex = 667
        Me.LblTextTotalQty.Text = "Total Qty.    :"
        '
        'LblValNetAmount
        '
        Me.LblValNetAmount.AutoSize = True
        Me.LblValNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValNetAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValNetAmount.Location = New System.Drawing.Point(890, 3)
        Me.LblValNetAmount.Name = "LblValNetAmount"
        Me.LblValNetAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblValNetAmount.TabIndex = 662
        Me.LblValNetAmount.Text = "."
        Me.LblValNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextNetAmount
        '
        Me.LblTextNetAmount.AutoSize = True
        Me.LblTextNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextNetAmount.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextNetAmount.Location = New System.Drawing.Point(799, 4)
        Me.LblTextNetAmount.Name = "LblTextNetAmount"
        Me.LblTextNetAmount.Size = New System.Drawing.Size(93, 16)
        Me.LblTextNetAmount.TabIndex = 661
        Me.LblTextNetAmount.Text = "Net Payable :"
        '
        'TxtPartyBillNo
        '
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
        Me.TxtPartyBillNo.Location = New System.Drawing.Point(625, 11)
        Me.TxtPartyBillNo.MaxLength = 35
        Me.TxtPartyBillNo.Name = "TxtPartyBillNo"
        Me.TxtPartyBillNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtPartyBillNo.TabIndex = 8
        '
        'LblPartyBillNo
        '
        Me.LblPartyBillNo.AutoSize = True
        Me.LblPartyBillNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyBillNo.Location = New System.Drawing.Point(520, 13)
        Me.LblPartyBillNo.Name = "LblPartyBillNo"
        Me.LblPartyBillNo.Size = New System.Drawing.Size(86, 15)
        Me.LblPartyBillNo.TabIndex = 764
        Me.LblPartyBillNo.Text = "Document No."
        '
        'TxtPartyBillDate
        '
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
        Me.TxtPartyBillDate.Location = New System.Drawing.Point(875, 11)
        Me.TxtPartyBillDate.MaxLength = 35
        Me.TxtPartyBillDate.Name = "TxtPartyBillDate"
        Me.TxtPartyBillDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtPartyBillDate.TabIndex = 9
        '
        'LblPartyBillDate
        '
        Me.LblPartyBillDate.AutoSize = True
        Me.LblPartyBillDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyBillDate.Location = New System.Drawing.Point(777, 13)
        Me.LblPartyBillDate.Name = "LblPartyBillDate"
        Me.LblPartyBillDate.Size = New System.Drawing.Size(61, 15)
        Me.LblPartyBillDate.TabIndex = 766
        Me.LblPartyBillDate.Text = "Doc. Date"
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(378, 400)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(295, 140)
        Me.PnlCShowGrid2.TabIndex = 939
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(679, 400)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(295, 140)
        Me.PnlCShowGrid.TabIndex = 2
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(219, 399)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(126, 144)
        Me.PnlCalcGrid.TabIndex = 938
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(2, 180)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(110, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "ITEM DETAIL:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.TxtStructure.Location = New System.Drawing.Point(396, 71)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(100, 18)
        Me.TxtStructure.TabIndex = 5
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(329, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 769
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
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
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(146, 111)
        Me.TxtSalesTaxGroupParty.MaxLength = 0
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(350, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 7
        '
        'LblSalesTaxGroupParty
        '
        Me.LblSalesTaxGroupParty.AutoSize = True
        Me.LblSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalesTaxGroupParty.Location = New System.Drawing.Point(22, 113)
        Me.LblSalesTaxGroupParty.Name = "LblSalesTaxGroupParty"
        Me.LblSalesTaxGroupParty.Size = New System.Drawing.Size(98, 15)
        Me.LblSalesTaxGroupParty.TabIndex = 773
        Me.LblSalesTaxGroupParty.Text = "Sales Tax Group"
        '
        'TempPurchase
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
        Me.Name = "TempPurchase"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
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

        Public Shared SalesTaxGroupItem As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing

        Public Shared AgStructure As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_Purchase"

        LblV_Type.Text = "Purchase Type"
        LblV_Date.Text = "Purchase Date"
        LblV_No.Text = "Purchase No."
        TP1.Text = "Purchase Detail"

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
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim mCondStr$

        mCondStr = " " & AglObj.CondStrFinancialYear("H.V_Date", AglObj.PubStartDate, AglObj.PubEndDate) & _
                        " And " & AglObj.PubSiteCondition("H.Site_Code", AglObj.PubSiteCode) & " "
        mCondStr = mCondStr & " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        mQry = " Select H.DocID As SearchCode " & _
                " From Store_Purchase H With (NoLock) " & _
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
                            " H.PartyBillNo  As [" & LblPartyBillNo.Text & "], " & _
                            " " & AglObj.ConvertDateTimeField("H.PartyBillDate") & " As [" & LblPartyBillDate.Text & "], " & _
                            " Sg.Name AS [" & LblAcCode.Text & "], City.CityName AS [City Name], " & _
                            " H.TotalQty, H.InvoiceAmount, H.Remark, S.Name AS [Site Name], H.Div_Code, " & _
                            " H.PreparedBy As [Entry By], " & AglObj.ConvertDateTimeField("H.U_EntDt") & " As [Entry Date], " & _
                            " H.ModifiedBy As [Edit By], " & AglObj.ConvertDateTimeField("H.Edit_Date") & " As [Edit Date] " & _
                            " FROM dbo.Store_Purchase H WITH (NoLock) " & _
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
            .AddAgTextColumn(DGL1, Col1Item, 120, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 120, 255, Col1ItemDescription, True, False, False)
            .AddAgTextColumn(DGL1, Col1Unit, 60, 0, Col1Unit, True, True, False)
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

        mQry = "UPDATE dbo.Store_Purchase " & _
                " SET  " & _
                "   Structure = " & AglObj.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " 	ReferenceNo = " & AglObj.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " 	PartyBillNo = " & AglObj.Chk_Text(TxtPartyBillNo.Text) & ", " & _
                " 	PartyBillDate = " & AglObj.ConvertDate(TxtPartyBillDate.Text) & ", " & _
                " 	AcCode = " & AglObj.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                " 	Amount = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.GrossAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	NetAmount = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.TotalLineNetAmount, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	NetSubTotal = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.NetSubTotal, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	RoundOff = " & Val(AgCalcGrid1.AgChargesValue(AgCalGridCharges.RoundOff, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	InvoiceAmount = " & Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) & ", " & _
                " 	TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                "   SalesTaxGroupParty = " & AglObj.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                "   Remark = " & AglObj.Chk_Text(TxtRemark.Text) & " " & _
                " WHERE DocId = " & AglObj.Chk_Text(SearchCode) & " "
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mSearchCode, Conn, Cmd)

        '============================================================================================
        '===================< Save Data in Stock Header Table >======================================
        '===============================< Start >====================================================
        '============================================================================================
        If ManageStock Then Call ProcSaveStockHeader(SearchCode, Conn, Cmd)
        '============================================================================================
        '===================< Save Data in Stock Header Table >======================================
        '===============================< Edn >======================================================
        '============================================================================================

        If AglObj.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_PurchaseDetail WHERE DocId = '" & mSearchCode & "'"
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

                mQry = "INSERT INTO dbo.Store_PurchaseDetail (" & _
                        " DocId, Sr, Uid, Item, ItemDescription, Unit, BatchNo, Godown, DocQty, Qty, Rate, Amount, NetAmount," & _
                        " SalesTaxGroupItem, Remark) " & _
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
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & " " & _
                        " )"
                AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(mSearchCode, bIntSr, bIntI, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next

        '============================================================================================
        '========================< Save Data in Account >============================================
        '===============================< Start >====================================================
        '============================================================================================
        If ManageAccount Then Call AccountPosting()
        '============================================================================================
        '========================< Save Data in Account >============================================
        '===============================< Edn >======================================================
        '============================================================================================

    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
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

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        '============================================================================================
        '======================< Delete Account Data >=================================================
        '============================< Start >=======================================================
        '============================================================================================
        AglObj.LedgerUnPost(AglObj.GCn, AglObj.ECmd, SearchCode)
        '============================================================================================
        '======================< Delete Account Data >=================================================
        '============================< End >=======================================================
        '============================================================================================

        '============================================================================================
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

        mQry = "Delete From Store_PurchaseDetail Where DocId = '" & SearchCode & "'"
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_Purchase Where DocId = '" & SearchCode & "' "
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet
        Dim DtTemp As DataTable = Nothing

        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
            " From Store_Purchase H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AglObj.FillData(mQry, AglObj.GCn)

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
                TxtPartyBillNo.Text = AglObj.XNull(.Rows(0)("PartyBillNo"))
                TxtPartyBillDate.Text = Format(AglObj.XNull(.Rows(0)("PartyBillDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                TxtSalesTaxGroupParty.AgSelectedValue = AglObj.XNull(.Rows(0)("SalesTaxGroupParty"))

                TxtRemark.Text = AglObj.XNull(.Rows(0)("Remark"))


                LblValNetAmount.Text = Format(AglObj.VNull(.Rows(0)("InvoiceAmount")), "0.00")
                LblValTotalQty.Text = Format(AglObj.VNull(.Rows(0)("TotalQty")), "0.000")

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                mQry = "Select L.* " & _
                        " From Store_PurchaseDetail L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AglObj.FillData(mQry, AglObj.GCn).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

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
            Else
                If Me.FormType = eFormType.Main Then
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                End If
                If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
            End If
        End If


        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AglObj.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)

        Topctrl1.ChangeAgGridState(DGL1, False)
        AgCalcGrid1.FrmType = AgStructure.ClsMain.EntryPointType.Main
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AglObj.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        Tc1.SelectedTab = TP1

        AgCalcGrid1.AgNCat = LblV_Type.Tag

        'TxtSalesTaxGroupParty.AgSelectedValue = AglObj.XNull(DtMess_Enviro.Rows(0)("SalesTaxGroupParty"))
        'AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue

        TxtPrepared.Text = AglObj.PubUserName
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

            mQry = "SELECT I.Code, I.Description AS [Item Name], I.Unit, " & _
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

        DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Unit) = HelpDataSet.Unit.Copy
        DGL1.AgHelpDataSet(Col1Godown) = HelpDataSet.Godown.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim bIntI As Integer = 0

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
                        " FROM Store_Purchase H With (NoLock) " & _
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

    Public Sub Form_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtAcCode.Enter, TxtRemark.Enter
        Try
            Select Case sender.name
                Case TxtAcCode.Name
                    TxtAcCode.AgRowFilter = " (MasterType = '" & ClsMain.PartyMasterType.Cash & "' Or MasterType = '" & ClsMain.PartyMasterType.Supplier & "') "

                Case TxtSalesTaxGroupParty.Name
                    sender.AgRowFilter = "  Active <> 0 "

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtV_Type.Validating, TxtAcCode.Validating, TxtRemark.Validating, TxtPartyBillNo.Validating, _
        TxtPartyBillDate.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, _
        TxtSite_Code.Validating, TxtStructure.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtSalesTaxGroupParty.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AglObj.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AglObj.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    AgCalcGrid1.AgNCat = LblV_Type.Tag
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
        'Coding To Enable/Disable Controls
    End Sub

    'Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
    '    If Topctrl1.Mode = "Browse" Then Exit Sub
    '    Dim mRowIndex As Integer, mColumnIndex As Integer

    '    Try
    '        mRowIndex = DGL1.CurrentCell.RowIndex
    '        mColumnIndex = DGL1.CurrentCell.ColumnIndex

    '        If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
    '        Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
    '            Case Col1SalesTaxGroupItem
    '                DGL1.AgRowFilter(mColumnIndex) = " Active <> 0 "

    '            Case Col1Item
    '                DGL1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Mess & "' "
    '        End Select

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
    '    If Topctrl1.Mode = "Browse" Then Exit Sub
    '    Dim mRowIndex As Integer, mColumnIndex As Integer
    '    Dim DrTemp As DataRow() = Nothing

    '    Try
    '        mRowIndex = DGL1.CurrentCell.RowIndex
    '        mColumnIndex = DGL1.CurrentCell.ColumnIndex

    '        If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

    '        With DGL1
    '            Select Case .Columns(.CurrentCell.ColumnIndex).Name
    '                Case Col1Item
    '                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
    '                        DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
    '                        DGL1.AgSelectedValue(Col1Unit, mRowIndex) = ""
    '                        DGL1.Item(Col1Rate, mRowIndex).Value = ""
    '                        DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = ""
    '                    Else
    '                        If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
    '                            DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AglObj.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
    '                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AglObj.XNull(DrTemp(0)("Unit"))
    '                            DGL1.Item(Col1Rate, mRowIndex).Value = Format(AglObj.VNull(DrTemp(0)("PurchaseRate")), "0.00")
    '                            DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = AglObj.XNull(DrTemp(0)("SalesTaxPostingGroup"))
    '                        End If
    '                        DrTemp = Nothing
    '                    End If

    '                Case Col1DocQty
    '                    If DGL1.Item(Col1Qty, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Qty, mRowIndex).Value = ""

    '                    If Val(DGL1.Item(Col1Qty, mRowIndex).Value) = 0 _
    '                        And Val(DGL1.Item(Col1DocQty, mRowIndex).Value) > 0 Then

    '                        DGL1.Item(Col1Qty, mRowIndex).Value = DGL1.Item(Col1DocQty, mRowIndex).Value
    '                    End If
    '            End Select
    '        End With

    '        Call Calculation()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AglObj.FSetSNo(sender, 0)

        Call Calculation()
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

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If AglObj.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
                And AglObj.XNull(LblPrefix.Text).ToString.Trim <> "" _
                And Val(TxtV_No.Text) > 0 Then

                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
                LblReferenceNo.Tag = TxtReferenceNo.Text
            End If
        End If
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

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer = 0, J As Integer = 0
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mVNo As Long = Val(AglObj.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))

        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection

        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AglObj.MidStr(mCommonNarr, 0, 255)

        AgCalcGrid1.AgPostingPartyAc = TxtAcCode.AgSelectedValue
        AgCalcGrid1.AgNCat = LblV_Type.Tag

        LedgAry = AgCalcGrid1.PostingLedgAry()

        If mCommonNarr.Length > 255 Then mCommonNarr = AglObj.MidStr(mCommonNarr, 0, 255)


        If AglObj.LedgerPost(AglObj.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AglObj.GCn, AglObj.ECmd, mSearchCode, CDate(TxtV_Date.Text), AglObj.PubUserName, AglObj.PubLoginDate, mCommonNarr, , AglObj.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        GcnRead.Close()
        GcnRead.Dispose()
    End Function



    'Private Sub FrmGrEntry_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
    '    Dim StructToBeBilled As AgTemplate.ClsMain.ToBeBilled = Nothing
    '    Dim StructDue As AgTemplate.ClsMain.Dues = Nothing
    '    Dim StructDuesPayment As ControlPayment.DuesPayement = Nothing
    '    Dim StructDuesPaymentDetail As ControlPayment.DuesPaymentDetail = Nothing
    '    Dim mSr As Integer = 0
    '    Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing

    '    If AglObj.StrCmp(TxtBiltyType.Text, BiltyType_Paid) Then
    '        With StructDue
    '            .DocID = mInternalCode
    '            .Sr += 1
    '            .V_Type = TxtV_Type.AgSelectedValue
    '            .V_Prefix = LblPrefix.Text
    '            .V_Date = TxtV_Date.Text
    '            .V_No = Val(TxtV_No.Text)
    '            .Div_Code = TxtDivision.AgSelectedValue
    '            .Site_Code = TxtSite_Code.AgSelectedValue
    '            .SubCode = IIf(TxtTransporter.AgSelectedValue <> "", TxtTransporter.AgSelectedValue, "")
    '            .RefPartyName = IIf(TxtTransporter.Text <> "", TxtTransporter.Text, TxtConsigner.Text)
    '            .Narration = ""
    '            .ReceivableAmount = Val(AgCalcGrid1.AgChargesValue(AgCalc_TotalBookingAmt, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
    '            .EntryBy = AglObj.PubUserName
    '            .EntryDate = AglObj.GetDateTime(AglObj.GcnRead)
    '            .EntryType = Topctrl1.Mode
    '            .EntryStatus = LogStatus.LogOpen
    '            .IsDeleted = 0
    '            .Status = TxtStatus.Text
    '            .UID = mSearchCode
    '            .CashCredit = ""
    '            .ReferenceDocID = mInternalCode
    '            .RefV_No = Val(TxtV_No.Text)
    '            .RefV_Type = TxtV_Type.AgSelectedValue
    '            Call ProcFillPartyDetails(.RefPartyAddress, .RefPartyCity, .SubCode)

    '            AgCalcGrid1.AgPostingPartyAc = .SubCode
    '            AglObj.LedgerPost(AglObj.MidStr(Topctrl1.Mode, 0, 1), AgCalcGrid1.PostingLedgAry, AglObj.GCn, AglObj.ECmd, mInternalCode, CDate(TxtV_Date.Text), AglObj.PubUserName, AglObj.PubLoginDate, .Narration, , AglObj.Gcn_ConnectionString)

    '        End With
    '        Call AgTemplate.ClsMain.ProcPostInDues(Conn, Cmd, StructDue)
    '    End If

    '    If AglObj.StrCmp(TxtBiltyType.Text, BiltyType_Paid) Then
    '        If TxtAgent.AgSelectedValue <> "" Then
    '            With StructDue
    '                .DocID = mInternalCode
    '                .Sr += 1
    '                .V_Type = TxtV_Type.AgSelectedValue
    '                .V_Prefix = LblPrefix.Text
    '                .V_Date = TxtV_Date.Text
    '                .V_No = Val(TxtV_No.Text)
    '                .Div_Code = TxtDivision.AgSelectedValue
    '                .Site_Code = TxtSite_Code.AgSelectedValue
    '                .SubCode = TxtAgent.AgSelectedValue
    '                .RefPartyName = TxtAgent.Text
    '                .Narration = ""
    '                .PaybleAmount = Val(mTotalCommAmt)
    '                .EntryBy = AglObj.PubUserName
    '                .EntryDate = AglObj.GetDateTime(AglObj.GcnRead)
    '                .EntryType = Topctrl1.Mode
    '                .EntryStatus = LogStatus.LogOpen
    '                .IsDeleted = 0
    '                .Status = TxtStatus.Text
    '                .UID = mSearchCode
    '                .CashCredit = ""
    '                .ReferenceDocID = mInternalCode
    '                .RefV_No = Val(TxtV_No.Text)
    '                .RefV_Type = TxtV_Type.AgSelectedValue
    '                Call ProcFillPartyDetails(.RefPartyAddress, .RefPartyCity, .SubCode)
    '                AgCalcGrid1.AgPostingPartyAc = .SubCode
    '                AglObj.LedgerPost(AglObj.MidStr(Topctrl1.Mode, 0, 1), AgCalcGrid1.PostingLedgAry, AglObj.GCn, AglObj.ECmd, mInternalCode, CDate(TxtV_Date.Text), AglObj.PubUserName, AglObj.PubLoginDate, .Narration, , AglObj.Gcn_ConnectionString)


    '            End With
    '            Call AgTemplate.ClsMain.ProcPostInDues(Conn, Cmd, StructDue)
    '        End If
    '    End If

    '    If AglObj.StrCmp(TxtBiltyType.Text, BiltyType_ToBeBilled) Then
    '        With StructToBeBilled
    '            .DocID = mInternalCode
    '            .V_Type = TxtV_Type.AgSelectedValue
    '            .V_Prefix = LblPrefix.Text
    '            .V_Date = TxtV_Date.Text
    '            .V_No = Val(TxtV_No.Text)
    '            .Div_Code = TxtDivision.AgSelectedValue
    '            .Site_Code = TxtSite_Code.AgSelectedValue
    '            .ReferenceNo = ""
    '            .SubCode = IIf(TxtTransporter.AgSelectedValue <> "", TxtTransporter.AgSelectedValue, TxtBillToParty.AgSelectedValue)
    '            .PartyName = IIf(TxtTransporter.Text <> "", TxtTransporter.Text, TxtBillToParty.Text)
    '            .PartyAddress = ""
    '            .PartyCity = ""
    '            .TotalQty = Val(LblTotalQty.Text)
    '            .ReceivableAmount = 0
    '            .ReceivableAmount = Val(AgCalcGrid1.AgChargesValue(AgCalc_TotalBookingAmt, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
    '            .AdjustedAmount = 0
    '            .BilledAmount = 0
    '            .PaidAmount = 0
    '            .EntryBy = AglObj.PubUserName
    '            .EntryDate = AglObj.GetDateTime(AglObj.GcnRead)
    '            .EntryType = Topctrl1.Mode
    '            .EntryStatus = LogStatus.LogOpen
    '            .IsDeleted = 0
    '            .Status = TxtStatus.Text
    '            .UID = mSearchCode
    '            Call ProcFillPartyDetails(.PartyAddress, .PartyCity, .SubCode)
    '            AgCalcGrid1.AgPostingPartyAc = .SubCode




    '            ' LedgAry = AglObj.LedgerPost(AglObj.MidStr(Topctrl1.Mode, 0, 1), AgCalcGrid1.PostingLedgAry, AglObj.GCn, AglObj.ECmd, mInternalCode, CDate(TxtV_Date.Text), AglObj.PubUserName, AglObj.PubLoginDate, "", , AglObj.Gcn_ConnectionString)

    '        End With
    '        LedgAry = AgCalcGrid1.PostingLedgAry()
    '        AglObj.LedgerPost(AglObj.MidStr(Topctrl1.Mode, 0, 1), AgCalcGrid1.PostingLedgAry, AglObj.GCn, AglObj.ECmd, mInternalCode, CDate(TxtV_Date.Text), AglObj.PubUserName, AglObj.PubLoginDate, "", , AglObj.Gcn_ConnectionString)
    '        Call AgTemplate.ClsMain.ProcPostInToBeBilled(Conn, Cmd, StructToBeBilled)
    '    End If

    '    If Val(ControlPayment1.TxtPaidAmount.Text) <> 0 Then
    '        If AglObj.StrCmp(TxtBiltyType.Text, BiltyType_Paid) Then
    '            With StructDuesPayment
    '                .DocID = mInternalCode
    '                .V_Type = TxtV_Type.AgSelectedValue
    '                .V_Prefix = LblPrefix.Text
    '                .V_Date = TxtV_Date.Text
    '                .V_No = Val(TxtV_No.Text)
    '                .Div_Code = TxtDivision.AgSelectedValue
    '                .Site_Code = TxtSite_Code.AgSelectedValue
    '                .SubCode = IIf(TxtTransporter.AgSelectedValue <> "", TxtTransporter.AgSelectedValue, "")
    '                .PartyName = IIf(TxtTransporter.Text <> "", TxtTransporter.Text, TxtConsigner.Text)
    '                .CurrBalance = 0
    '                .PaidAmount = 0
    '                .Discount = 0
    '                .NetAmount = 0
    '                .CashBank = ""
    '                .CashBankAc = ""
    '                .ChqNo = ""
    '                .ChqDate = ""
    '                .Remark = TxtRemarks.Text
    '                .EntryBy = AglObj.PubUserName
    '                .EntryDate = AglObj.GetDateTime(AglObj.GcnRead)
    '                .EntryType = Topctrl1.Mode
    '                .EntryStatus = LogStatus.LogOpen
    '                .IsDeleted = 0
    '                .Status = TxtStatus.Text
    '                .UID = mSearchCode
    '                .TransactionType = ControlPayment.TransactionType.Receipt
    '                Call ProcFillPartyDetails(.PartyAddress, .PartyCity, .SubCode)
    '                AgCalcGrid1.AgPostingPartyAc = .SubCode
    '                AglObj.LedgerPost(AglObj.MidStr(Topctrl1.Mode, 0, 1), AgCalcGrid1.PostingLedgAry, AglObj.GCn, AglObj.ECmd, mInternalCode, CDate(TxtV_Date.Text), AglObj.PubUserName, AglObj.PubLoginDate, "", , AglObj.Gcn_ConnectionString)

    '            End With

    '            With StructDuesPaymentDetail
    '                .DocID = mInternalCode
    '                .Sr = 1
    '                .ReferenceDocID = mInternalCode
    '                .Reference_Sr = 1
    '                .Amount = 0
    '                .UID = mSearchCode
    '            End With
    '            Call ControlPayment1.ProcSaveInTrans(StructDuesPayment, StructDuesPaymentDetail, Conn, Cmd)
    '        End If
    '    End If
    'End Sub

End Class
