Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPurchaseOrder
    Inherits Academic_ProjLib.TempTransaction
    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$


    'Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2Term As String = "Term & Condition"


    Public Const ColSNo As String = "S.No."
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1IndentNo As String = "Indent No."
    Protected Const Col1TempItem As String = "Temp Item"
    Protected Const Col1Indentuid As String = "Indent Uid"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1ItemDescription As String = "Item Description"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"


    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"
#Region "Form Designer Code"
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblSubCode As System.Windows.Forms.Label
    Protected WithEvents TxtSubCode As AgControls.AgTextBox
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalOty As System.Windows.Forms.Label
    Protected WithEvents Panel3 As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtIndentNo As AgControls.AgTextBox
    Protected WithEvents LblIndentNo As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents RbtPODirect As System.Windows.Forms.RadioButton
    Protected WithEvents RbtPOForIndent As System.Windows.Forms.RadioButton
    Protected WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Private Sub InitializeComponent()
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.TxtSubCode = New AgControls.AgTextBox
        Me.LblSubCode = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalOty = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TxtIndentNo = New AgControls.AgTextBox
        Me.LblIndentNo = New System.Windows.Forms.Label
        Me.RbtPODirect = New System.Windows.Forms.RadioButton
        Me.RbtPOForIndent = New System.Windows.Forms.RadioButton
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.Label2.Location = New System.Drawing.Point(140, 73)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(32, 68)
        Me.LblV_Date.Size = New System.Drawing.Size(67, 15)
        Me.LblV_Date.Text = "Order Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(140, 53)
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
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(140, 33)
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
        Me.Tc1.Size = New System.Drawing.Size(992, 154)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.RbtPODirect)
        Me.TP1.Controls.Add(Me.RbtPOForIndent)
        Me.TP1.Controls.Add(Me.TxtIndentNo)
        Me.TP1.Controls.Add(Me.LblIndentNo)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtSubCode)
        Me.TP1.Controls.Add(Me.LblSubCode)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Size = New System.Drawing.Size(984, 126)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubCode, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblIndentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIndentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtPOForIndent, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtPODirect, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(596, 34)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 1023
        Me.LblSubCodeReq.Text = "Ä"
        '
        'TxtSubCode
        '
        Me.TxtSubCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtSubCode.AgMandatory = True
        Me.TxtSubCode.AgMasterHelp = False
        Me.TxtSubCode.AgNumberLeftPlaces = 0
        Me.TxtSubCode.AgNumberNegetiveAllow = False
        Me.TxtSubCode.AgNumberRightPlaces = 0
        Me.TxtSubCode.AgPickFromLastValue = False
        Me.TxtSubCode.AgRowFilter = ""
        Me.TxtSubCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubCode.AgSelectedValue = Nothing
        Me.TxtSubCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubCode.Location = New System.Drawing.Point(618, 28)
        Me.TxtSubCode.MaxLength = 20
        Me.TxtSubCode.Name = "TxtSubCode"
        Me.TxtSubCode.Size = New System.Drawing.Size(304, 18)
        Me.TxtSubCode.TabIndex = 5
        '
        'LblSubCode
        '
        Me.LblSubCode.AutoSize = True
        Me.LblSubCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubCode.Location = New System.Drawing.Point(504, 30)
        Me.LblSubCode.Name = "LblSubCode"
        Me.LblSubCode.Size = New System.Drawing.Size(53, 15)
        Me.LblSubCode.TabIndex = 1022
        Me.LblSubCode.Text = "Supplier"
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
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(141, 93)
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
        Me.TxtRemark.Location = New System.Drawing.Point(618, 68)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(304, 18)
        Me.TxtRemark.TabIndex = 7
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(504, 70)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 1024
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 431)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(379, 119)
        Me.Pnl1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTextTotalOty)
        Me.Panel1.Location = New System.Drawing.Point(12, 381)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 21)
        Me.Panel1.TabIndex = 795
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(831, 2)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 670
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(727, 2)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 669
        Me.LblTotalAmountText.Text = "Total Amount :"
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
        'LblTextTotalOty
        '
        Me.LblTextTotalOty.AutoSize = True
        Me.LblTextTotalOty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalOty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalOty.Location = New System.Drawing.Point(9, 3)
        Me.LblTextTotalOty.Name = "LblTextTotalOty"
        Me.LblTextTotalOty.Size = New System.Drawing.Size(73, 16)
        Me.LblTextTotalOty.TabIndex = 667
        Me.LblTextTotalOty.Text = "Total Qty :"
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel3.Location = New System.Drawing.Point(12, 184)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(973, 196)
        Me.Panel3.TabIndex = 1
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 162)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 798
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Purchase Order For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 408)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(164, 20)
        Me.LinkLabel2.TabIndex = 799
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Terms && Condition"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtIndentNo
        '
        Me.TxtIndentNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtIndentNo.AgMandatory = False
        Me.TxtIndentNo.AgMasterHelp = False
        Me.TxtIndentNo.AgNumberLeftPlaces = 8
        Me.TxtIndentNo.AgNumberNegetiveAllow = False
        Me.TxtIndentNo.AgNumberRightPlaces = 2
        Me.TxtIndentNo.AgPickFromLastValue = False
        Me.TxtIndentNo.AgRowFilter = ""
        Me.TxtIndentNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIndentNo.AgSelectedValue = Nothing
        Me.TxtIndentNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIndentNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIndentNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIndentNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIndentNo.Location = New System.Drawing.Point(618, 48)
        Me.TxtIndentNo.MaxLength = 20
        Me.TxtIndentNo.Name = "TxtIndentNo"
        Me.TxtIndentNo.Size = New System.Drawing.Size(109, 18)
        Me.TxtIndentNo.TabIndex = 6
        '
        'LblIndentNo
        '
        Me.LblIndentNo.AutoSize = True
        Me.LblIndentNo.BackColor = System.Drawing.Color.Transparent
        Me.LblIndentNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIndentNo.Location = New System.Drawing.Point(504, 49)
        Me.LblIndentNo.Name = "LblIndentNo"
        Me.LblIndentNo.Size = New System.Drawing.Size(71, 16)
        Me.LblIndentNo.TabIndex = 1026
        Me.LblIndentNo.Text = "Indent No. "
        '
        'RbtPODirect
        '
        Me.RbtPODirect.AutoSize = True
        Me.RbtPODirect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtPODirect.Location = New System.Drawing.Point(728, 103)
        Me.RbtPODirect.Name = "RbtPODirect"
        Me.RbtPODirect.Size = New System.Drawing.Size(79, 17)
        Me.RbtPODirect.TabIndex = 9
        Me.RbtPODirect.TabStop = True
        Me.RbtPODirect.Text = "PO Direct"
        Me.RbtPODirect.UseVisualStyleBackColor = True
        '
        'RbtPOForIndent
        '
        Me.RbtPOForIndent.AutoSize = True
        Me.RbtPOForIndent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtPOForIndent.Location = New System.Drawing.Point(615, 103)
        Me.RbtPOForIndent.Name = "RbtPOForIndent"
        Me.RbtPOForIndent.Size = New System.Drawing.Size(104, 17)
        Me.RbtPOForIndent.TabIndex = 8
        Me.RbtPOForIndent.TabStop = True
        Me.RbtPOForIndent.Text = "PO For Indent"
        Me.RbtPOForIndent.UseVisualStyleBackColor = True
        '
        'FrmPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Pnl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmPurchaseOrder"
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region


    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.StorePurchaseOrder) & ""
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
    Public Class HelpDataSet
        Public Shared Party As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing
        Public Shared Vendor As DataSet = Nothing
        Public Shared IndentNo As DataSet = Nothing
        Public Shared ItemFromIndent As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_PurchOrder"
        AglObj = AgL

        LblV_Type.Text = "Order Type"
        LblV_Date.Text = "Order Date"
        LblV_No.Text = "Order No."
        TP1.Text = "Tp1"

        AgL.GridDesign(DGL1)
        AgL.GridDesign(Dgl2)
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
                " From Store_PurchOrder H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                      " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " "
        mCondStr += " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And P.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And P.ApprovedDate Is Not Null "
            End If
        End If

        AgL.PubFindQry = "SELECT P.DocID, Vt.Description AS [Order Type], P.V_Date AS [Order Date], " & _
                           " P.V_No AS [Order No], Sg.DispName As Supplier " & _
                           " FROM Store_PurchOrder P With (NoLock) " & _
                           " LEFT JOIN Voucher_type Vt ON p.V_Type = Vt.V_Type " & _
                           " Left Join SubGroup Sg With (NoLock) On P.SubCode = Sg.SubCode " & _
                           " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Order Date]"
    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1IndentNo, 110, 0, Col1IndentNo, False, False, False)
            .AddAgTextColumn(DGL1, Col1Indentuid, 110, 0, Col1Indentuid, False, False, False)
            .AddAgTextColumn(DGL1, Col1TempItem, 200, 0, Col1TempItem, False, False, False)
            .AddAgTextColumn(DGL1, Col1Item, 190, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 190, 0, Col1ItemDescription, True, False, False)
            .AddAgNumberColumn(DGL1, Col1Qty, 80, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(DGL1, Col1Unit, 60, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(DGL1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(DGL1, Col1Remark, 200, 255, Col1Remark, True, False, False)
            .AddAgTextColumn(DGL1, Col1UID, 80, 0, Col1UID, False, True, False)
            .AddAgTextColumn(DGL1, Col1TempUID, 80, 0, Col1TempUID, False, True, False)

        End With
        AgL.AddAgDataGrid(DGL1, Panel3)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.ColumnHeadersHeight = 35


        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Term, 300, 0, Col2Term, True, False)
        End With
        AgL.AddAgDataGrid(Dgl2, Pnl1)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.AgSkipReadOnlyColumns = True
        Dgl2.Anchor = AnchorStyles.None
        'PnlFooter.Anchor = DGL2.Anchor
        Dgl2.ColumnHeadersHeight = 35


        Topctrl1.ChangeAgGridState(Dgl2, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""
        Dim I As Integer, mSr As Integer


        mQry = "UPDATE dbo.Store_PurchOrder " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                " PurchIndentDocId = " & AgL.Chk_Text(TxtIndentNo.AgSelectedValue) & ", " & _
                " IsAgainstIndent=  " & IIf(RbtPOForIndent.Checked, 1, 0) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_PurchOrderTerms WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If
        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2Term, I).Value <> "" Then
                    mSr += 1

                    mQry = "Insert Into Store_PurchOrderTerms(DocId, Sr, Terms) " & _
                            " Values(" & AgL.Chk_Text(mSearchCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(Dgl2.Item(Col2Term, I).Value) & " )"

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With


        mQry = "Delete From Store_PurchOrderDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                bIntSr += 1

                If AglObj.XNull(DGL1.Item(Col1TempUID, bIntI).Value).ToString.Trim = "" Then
                    If AglObj.XNull(DGL1.Item(Col1UID, bIntI).Value).ToString.Trim = "" Then
                        DGL1.Item(Col1UID, bIntI).Value = AglObj.GetGUID(AgL.Gcn_ConnectionString).ToString
                    End If
                End If

                bStrLineUid = DGL1.Item(Col1UID, bIntI).Value

                mQry = "INSERT INTO dbo.Store_PurchOrderDetail ( " & _
                        " DocId, Sr,PurchIndentDocId,PurchIndentUID, Item, ItemDescription,Unit,Qty,Rate,Amount,Remark,UID) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & "," & AgL.Chk_Text(DGL1.AgSelectedValue(Col1IndentNo, bIntI)) & "," & AglObj.Chk_Text(DGL1.Item(Col1Indentuid, bIntI).Value) & ", " & _
                       " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Unit, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Qty, bIntI).Value) & ", " & _
                          " " & Val(DGL1.Item(Col1Rate, bIntI).Value) & ", " & _
                            " " & Val(DGL1.Item(Col1Amount, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & " , " & AglObj.Chk_Text(bStrLineUid) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next

    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        If FGetRelationalData() = True Then
            Exit Sub
        End If


        mQry = "Delete From Store_PurchOrderTerms Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_PurchOrderDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_PurchOrder Where DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub
    Private Function FGetRelationalData() As Boolean
        Try

            Dim bRData As String
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT @Temp=@Temp+ X.VNo + ',' FROM (Select Distinct H.V_Type + '-' + Convert(VARCHAR,H.V_No) as VNo From Store_GrnDetail L LEFT JOIN Store_GRN H ON L.DocId = H.DocID WHERE L.PurchOrderDocID = '" & TxtDocId.Text & "') As X "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" GRN " & bRData & " created against Order No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
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
            " From Store_PurchOrder H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))
                If AgL.VNull(.Rows(0)("IsAgainstIndent")) Then
                    RbtPOForIndent.Checked = True
                    RbtPODirect.Checked = False
                Else
                    RbtPOForIndent.Checked = False
                    RbtPODirect.Checked = True
                End If

                TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                Call Validating_Controls(TxtSubCode)
                TxtIndentNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchIndentDocId"))
                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                LblTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")
                LblTotalAmount.Text = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.000")

                mQry = "Select L.* " & _
                        " From Store_PurchOrderTerms L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    Dgl2.RowCount = 1 : Dgl2.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            Dgl2.Rows.Add()

                            Dgl2.Item(ColSNo, bIntI).Value = Dgl2.Rows.Count - 1
                            Dgl2.Item(Col2Term, bIntI).Value = AgL.XNull(.Rows(bIntI)("Terms"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                        Next bIntI

                    End If
                End With

                mQry = "Select L.* " & _
                         " From Store_PurchOrderDetail L With (NoLock) " & _
                         " Where L.DocId = '" & SearchCode & "' " & _
                         " Order By L.Sr"
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1IndentNo, I) = AgL.XNull(.Rows(I)("PurchIndentDocId"))
                            DGL1.Item(Col1Indentuid, I).Value = AglObj.XNull(.Rows(I)("PurchIndentUID").ToString)
                            DGL1.AgSelectedValue(Col1TempItem, I) = AgL.XNull(.Rows(I)("Item"))
                            DGL1.AgSelectedValue(Col1TempItem, I) = AgL.XNull(.Rows(I)("Item"))
                            DGL1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            DGL1.Item(Col1ItemDescription, I).Value = AglObj.XNull(.Rows(I)("ItemDescription"))
                            DGL1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.000")
                            DGL1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.000")
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.000")
                            DGL1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            DGL1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                            DGL1.Item(Col1UID, I).Value = AglObj.XNull(.Rows(I)("UID").ToString)
                            DGL1.Item(Col1TempUID, I).Value = AglObj.XNull(.Rows(I)("UID").ToString)

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                Calculation()
            End If
        End With

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

        'Topctrl1.tPrn = False


        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtSubCode.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        'txtDepartment.Text = AgL.XNull(DrTemp(0)("Department"))

                    End If
                End If
                DrTemp = Nothing
        End Select

    End Sub

    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)
        Topctrl1.ChangeAgGridState(DGL1, False)
        Topctrl1.ChangeAgGridState(Dgl2, False)
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        Tc1.SelectedTab = TP1
        RbtPODirect.Checked = True
        TxtPrepared.Text = AgL.PubUserName

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AgL.PubLoginDate
        End If

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
                    " Where I.MasterType = '" & ClsMain.ItemType.Store & "'" & _
                    " ORDER BY I.Nature, I.Description "
            HelpDataSet.Item = AglObj.FillData(mQry, GcnRead)

            mQry = " SELECT P.DocID AS Code,P.V_Type + '-' +convert(NVARCHAR(5),P.V_No) AS [Indent No] , " & _
                " SG.DispName AS [Indent By],P.V_Date AS [Indent Date], " & _
                " P.Div_Code , " & _
                " isnull(V1.BalItem,0) AS BalItem, Vt.NCat " & _
                " FROM Store_PurchIndent P  With (NoLock) " & _
                " LEFT JOIN  " & _
                " (  " & _
                " SELECT PD.DocId,count(PD.item) BalItem  " & _
                " FROM Store_PurchIndentDetail PD  With (NoLock) " & _
                " WHERE PD.IndentQty > 0 " & _
                " GROUP BY PD.DocId " & _
                " ) V1 ON V1.DocId = P.DocID " & _
                " LEFT JOIN SubGroup SG  With (NoLock) On SG.SubCode = P.SubCode " & _
                " LEFT JOIN Voucher_Type Vt On P.V_Type = Vt.V_Type where Vt.NCat in ('" & ClsMain.Temp_NCat.StorePurchaseIndent & "')"
            HelpDataSet.IndentNo = AgL.FillData(mQry, AgL.GcnRead)

            mQry = " SELECT RD.Item AS Code,I.Description AS [Item Name], RD.IndentQty AS Qty ,  " & _
               " RD.IndentQty  As BalanceQty, RD.DocId AS IndentDocId,RD.Uid as IndentUID,RD.ItemDescription as IndentItemDescription, " & _
               " RD.Unit, I.SalesTaxPostingGroup ," & _
               " H.Div_Code " & _
               " FROM Store_PurchIndentDetail RD With (NoLock) " & _
               " LEFT JOIN Store_PurchIndent H  With (NoLock) On Rd.DocId = H.DocId " & _
               " LEFT JOIN Store_Item I With (NoLock) ON I.Code=RD.Item " & _
               " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type  where Vt.NCat in ('" & ClsMain.Temp_NCat.StorePurchaseIndent & "') and I.MasterType = '" & ClsMain.ItemType.Store & "'  "
            HelpDataSet.ItemFromIndent = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSubCode.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Party.Copy
        TxtIndentNo.AgHelpDataSet(3, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.IndentNo

        DGL1.AgHelpDataSet(Col1IndentNo, 3) = HelpDataSet.IndentNo
        DGL1.AgHelpDataSet(Col1TempItem, 11) = HelpDataSet.Item

        IniItemHelp()
    End Sub
    Public Sub IniItemHelp(Optional ByVal All_Records As Boolean = True, Optional ByVal bRequisitionDocId As String = "")
        If All_Records = True Then
            DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item
        Else
            DGL1.AgHelpDataSet(Col1Item, 7) = HelpDataSet.ItemFromIndent
        End If
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, I).Value <> "" Then
                'Footer Calculation
                DGL1.Item(Col1Amount, I).Value = Format(Val(DGL1.Item(Col1Qty, I).Value) * Val(DGL1.Item(Col1Rate, I).Value), "0.".PadRight(CType(DGL1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(DGL1.Item(Col1Qty, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(DGL1.Item(Col1Amount, I).Value)
            End If
        Next
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.000")

    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim I As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtSubCode, LblSubCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(Dgl2)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & DGL1.Columns(Col1IndentNo).Index & "," & DGL1.Columns(Col1Item).Index & "") Then Exit Function

       

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        If Val(.Item(Col1Qty, I).Value) = 0 Then
                            MsgBox("Qty Is 0 At Row No " & DGL1.Item(ColSNo, I).Value & "")
                            .CurrentCell = .Item(Col1Qty, I) : DGL1.Focus()
                            Exit Function
                        End If
                    End If

                    If .Item(Col1IndentNo, I).Value <> "" Then
                        If Validate_PurchIndent(DGL1, I) = False Then Exit Function
                    End If
                Next
            End With

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_PurchIndent H With (NoLock) " & _
                        " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                        " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                        " And H.ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & " " & _
                        " AND H.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
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

    Private Function Validate_PurchIndent(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case DGL1.Name
                    If DGL1.AgSelectedValue(Col1IndentNo, RowIndex) <> "" Then
                        DrTemp = DGL1.AgHelpDataSet(Col1IndentNo).Tables(0).Select("Code = '" & DGL1.AgSelectedValue(Col1IndentNo, RowIndex) & "' ")
                    End If
                    Validate_PurchIndent = True

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Public Sub Form_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        LblTotalQty.Text = 0
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        LblTotalQty.Text = 0
        LblTotalAmount.Text = 0
        LblPrefix.Text = ""
        mBlnIsApproved = False
    End Sub
    Private Sub TxtIndentNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtIndentNo.Validating
        Try
            Select Case sender.Name
                Case TxtIndentNo.Name
                    If TxtIndentNo.Text.ToString.Trim = "" Then
                        RbtPODirect.Checked = True
                    Else
                        RbtPOForIndent.Checked = True
                    End If

            End Select
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtSubCode.Enter, TxtIndentNo.Enter
        Try
            Select Case sender.name
                Case TxtSubCode.Name
                    'TxtSubCode.AgRowFilter = " [Is Active] = 'Yes' "


                Case TxtIndentNo.Name
                    TxtIndentNo.AgRowFilter = " (BalItem > 0 OR Code = " & AgL.Chk_Text(TxtIndentNo.AgSelectedValue) & " ) "

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtSubCode.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()

                Case TxtSubCode.Name
                    Call Validating_Controls(sender)
            End Select

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AgL.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
                LblPrefix.Text = AgL.DeCodeDocID(TxtDocId.Text.Trim, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
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

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.

        If Enb Then
            '<Executable Code>
        End If
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If DGL1.CurrentCell Is Nothing Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
            Case Col1IndentNo
                DGL1.AgRowFilter(DGL1.Columns(Col1IndentNo).Index) = "  (BalItem > 0 " & _
                            " OR Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex)) & " ) "

            Case Col1Item
                If TxtIndentNo.AgSelectedValue <> "" Then
                    Call IniItemHelp(False)
                    DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " BalanceQty > 0 " & _
                            " And IndentDocId = '" & TxtIndentNo.AgSelectedValue & "' "
                ElseIf RbtPOForIndent.Checked Then
                    Call IniItemHelp(False)
                    DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " BalanceQty > 0 " & _
                     " And IndentDocId = '" & DGL1.AgSelectedValue(Col1IndentNo, mRowIndex) & "' "
                Else
                    Call IniItemHelp()

                End If
        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
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
                    Validating_Item(DGL1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)

                Case Col1IndentNo
                    e.Cancel = Not Validate_PurchIndent(DGL1, DGL1.CurrentCell.RowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl2.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            'If DGL1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
            '    DGL1.Item(Col1Unit, mRow).Value = ""
            '    DGL1.Item(Col1Qty, mRow).Value = 0
            '    DGL1.Item(Col1Rate, mRow).Value = ""
            '    DGL1.Item(Col1Amount, mRow).Value = ""
            '    DGL1.Item(Col1ItemDescription, mRow).Value = ""
            '    DGL1.Item(Col1Remark, mRow).Value = ""
            'Else
            '    If DGL1.AgHelpDataSet(Col1Item) IsNot Nothing Then
            '        DrTemp = DGL1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
            '        DGL1.Item(Col1Qty, mRow).Value = AgL.VNull(DrTemp(0)("Qty"))
            '        DGL1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
            '        DGL1.Item(Col1ItemDescription, mRow).Value = AgL.XNull(DrTemp(0)("IndentItemDescription"))
            '        DGL1.Item(Col1Indentuid, mRow).Value = AglObj.XNull(DrTemp(0)("IndentUID").ToString)
            '        DGL1.AgSelectedValue(Col1IndentNo, mRow) = AgL.XNull(DrTemp(0)("IndentDocId"))

            '    End If
            'End If

            If DGL1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                DGL1.Item(Col1Unit, mRow).Value = ""
                DGL1.Item(Col1Qty, mRow).Value = 0
                DGL1.Item(Col1ItemDescription, mRow).Value = ""
                DGL1.AgSelectedValue(Col1IndentNo, mRow) = ""
                DGL1.AgSelectedValue(Col1Item, mRow) = ""
                DGL1.Item(Col1Indentuid, mRow).Value = ""
            Else
                If DGL1.AgDataRow IsNot Nothing Then
                    If RbtPOForIndent.Checked Then
                        DGL1.AgSelectedValue(Col1IndentNo, mRow) = AgL.XNull(DGL1.AgDataRow.Cells("IndentDocId").Value)
                        DGL1.Item(Col1Qty, mRow).Value = AgL.VNull(DGL1.AgDataRow.Cells("Qty").Value)
                        DGL1.Item(Col1Indentuid, mRow).Value = AglObj.XNull(DGL1.AgDataRow.Cells("IndentUID").Value.ToString)
                        DGL1.Item(Col1ItemDescription, mRow).Value = AgL.XNull(DGL1.AgDataRow.Cells("IndentItemDescription").Value)
                    End If
                    DGL1.Item(Col1Unit, mRow).Value = AgL.XNull(DGL1.AgDataRow.Cells("Unit").Value)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
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
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Purchase Order"
            RepName = "Store_PurchOrder_Print" : RepTitle = AgL.PubReportTitle
            bTableName = "Store_PurchOrder" : bSecTableName = "Store_PurchOrderDetail P1 ON P1.DocID =P.DocID"
            bCondstr = "WHERE P.DocID='" & SearchCode & "' and Vt.NCat in (" & EntryNCatList & ")"


            strQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
                    " P.Remark AS RemarkHeader,  P.ReferenceNo,P.TotalAmount,P.TotalQty, " & _
                    " P.subcode, P1.Remark, P1.Sr,P1.Item, Qty,P1.Rate,P1.Amount, " & _
                    " P1.Unit,  SM.Name AS SiteName,(ID.V_Type + '-' +convert(NVARCHAR(5),ID.V_No)) AS [Indent No],     " & _
                    " I.Description AS ItemName,Sg.Name AS Supplier,P1.ItemDescription " & _
                    " FROM " & bTableName & " P " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " LEFT JOIN Store_PurchIndent ID ON ID.DocID =P.PurchIndentDocId   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=P1.Item " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=P.Subcode " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type  " & _
                    " " & bCondstr & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

End Class
