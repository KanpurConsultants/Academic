Imports CrystalDecisions.CrystalReports.Engine

Public Class TempStockAdjustment
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1IssueReceive As String = "Issue/ Receive"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1ItemDescription As String = "Item Description"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1BatchNo As String = "Batch No"
    Protected Const Col1DocQty As String = "Doc Qty"
    Protected Const Col1Qty_Rec As String = "Receive Qty"
    Protected Const Col1Qty_Iss As String = "Issue Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1Godown As String = "Godown"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"



    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Dim _eQuantityType As eQuantityType = eQuantityType.Receive

    Public Enum eQuantityType
        Issue
        Receive
    End Enum

    Class IssueReceive
        Public Const Issue As String = "Issue"
        Public Const Receive As String = "Receive"
    End Class

    Public Property QuantityType() As eQuantityType
        Get
            QuantityType = _eQuantityType
        End Get
        Set(ByVal value As eQuantityType)
            _eQuantityType = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel


    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblValTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalAmount As System.Windows.Forms.Label
    Friend WithEvents TxtAcCode As AgControls.AgTextBox
    Friend WithEvents LblAcCode As System.Windows.Forms.Label
    Protected WithEvents LblValTotalReceiveQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalReceiveQty As System.Windows.Forms.Label
    Protected WithEvents LblValTotalIssueQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalIssueQty As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalReceiveQty = New System.Windows.Forms.Label
        Me.LblTextTotalReceiveQty = New System.Windows.Forms.Label
        Me.LblValTotalIssueQty = New System.Windows.Forms.Label
        Me.LblTextTotalIssueQty = New System.Windows.Forms.Label
        Me.LblValTotalAmount = New System.Windows.Forms.Label
        Me.LblTextTotalAmount = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtAcCode = New AgControls.AgTextBox
        Me.LblAcCode = New System.Windows.Forms.Label
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
        Me.TxtDocId.Location = New System.Drawing.Point(922, 109)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(455, 48)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(558, 46)
        Me.TxtV_No.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(313, 52)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(199, 48)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(313, 32)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(328, 46)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(199, 27)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(328, 26)
        Me.TxtV_Type.Size = New System.Drawing.Size(350, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(313, 12)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(199, 7)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(328, 6)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(875, 111)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(520, 47)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 161)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtAcCode)
        Me.TP1.Controls.Add(Me.LblAcCode)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 133)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAcCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAcCode, 0)
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
        Me.TxtRemark.Location = New System.Drawing.Point(328, 106)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 14
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(199, 108)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 207)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(965, 315)
        Me.Pnl1.TabIndex = 1
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(313, 72)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(328, 66)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(120, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(199, 67)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalReceiveQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalReceiveQty)
        Me.PnlFooter.Controls.Add(Me.LblValTotalIssueQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalIssueQty)
        Me.PnlFooter.Controls.Add(Me.LblValTotalAmount)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalAmount)
        Me.PnlFooter.Location = New System.Drawing.Point(12, 521)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(965, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LblValTotalReceiveQty
        '
        Me.LblValTotalReceiveQty.AutoSize = True
        Me.LblValTotalReceiveQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalReceiveQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalReceiveQty.Location = New System.Drawing.Point(452, 4)
        Me.LblValTotalReceiveQty.Name = "LblValTotalReceiveQty"
        Me.LblValTotalReceiveQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalReceiveQty.TabIndex = 686
        Me.LblValTotalReceiveQty.Text = "."
        Me.LblValTotalReceiveQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalReceiveQty
        '
        Me.LblTextTotalReceiveQty.AutoSize = True
        Me.LblTextTotalReceiveQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalReceiveQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalReceiveQty.Location = New System.Drawing.Point(349, 4)
        Me.LblTextTotalReceiveQty.Name = "LblTextTotalReceiveQty"
        Me.LblTextTotalReceiveQty.Size = New System.Drawing.Size(103, 16)
        Me.LblTextTotalReceiveQty.TabIndex = 685
        Me.LblTextTotalReceiveQty.Text = "Total Receive :"
        '
        'LblValTotalIssueQty
        '
        Me.LblValTotalIssueQty.AutoSize = True
        Me.LblValTotalIssueQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalIssueQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalIssueQty.Location = New System.Drawing.Point(631, 4)
        Me.LblValTotalIssueQty.Name = "LblValTotalIssueQty"
        Me.LblValTotalIssueQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalIssueQty.TabIndex = 684
        Me.LblValTotalIssueQty.Text = "."
        Me.LblValTotalIssueQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalIssueQty
        '
        Me.LblTextTotalIssueQty.AutoSize = True
        Me.LblTextTotalIssueQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalIssueQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalIssueQty.Location = New System.Drawing.Point(542, 4)
        Me.LblTextTotalIssueQty.Name = "LblTextTotalIssueQty"
        Me.LblTextTotalIssueQty.Size = New System.Drawing.Size(84, 16)
        Me.LblTextTotalIssueQty.TabIndex = 683
        Me.LblTextTotalIssueQty.Text = "Total Issue :"
        '
        'LblValTotalAmount
        '
        Me.LblValTotalAmount.AutoSize = True
        Me.LblValTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalAmount.Location = New System.Drawing.Point(819, 4)
        Me.LblValTotalAmount.Name = "LblValTotalAmount"
        Me.LblValTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalAmount.TabIndex = 680
        Me.LblValTotalAmount.Text = "."
        Me.LblValTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalAmount
        '
        Me.LblTextTotalAmount.AutoSize = True
        Me.LblTextTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalAmount.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalAmount.Location = New System.Drawing.Point(717, 4)
        Me.LblTextTotalAmount.Name = "LblTextTotalAmount"
        Me.LblTextTotalAmount.Size = New System.Drawing.Size(101, 16)
        Me.LblTextTotalAmount.TabIndex = 679
        Me.LblTextTotalAmount.Text = "Total Amount :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 184)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(130, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "ADJUSTMENT DETAIL :"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtAcCode
        '
        Me.TxtAcCode.AgMandatory = False
        Me.TxtAcCode.AgMasterHelp = False
        Me.TxtAcCode.AgNumberLeftPlaces = 0
        Me.TxtAcCode.AgNumberNegetiveAllow = False
        Me.TxtAcCode.AgNumberRightPlaces = 0
        Me.TxtAcCode.AgPickFromLastValue = False
        Me.TxtAcCode.AgRowFilter = ""
        Me.TxtAcCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAcCode.AgSelectedValue = Nothing
        Me.TxtAcCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAcCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAcCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAcCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcCode.Location = New System.Drawing.Point(328, 86)
        Me.TxtAcCode.MaxLength = 0
        Me.TxtAcCode.Name = "TxtAcCode"
        Me.TxtAcCode.Size = New System.Drawing.Size(350, 18)
        Me.TxtAcCode.TabIndex = 13
        '
        'LblAcCode
        '
        Me.LblAcCode.AutoSize = True
        Me.LblAcCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcCode.Location = New System.Drawing.Point(199, 88)
        Me.LblAcCode.Name = "LblAcCode"
        Me.LblAcCode.Size = New System.Drawing.Size(34, 15)
        Me.LblAcCode.TabIndex = 780
        Me.LblAcCode.Text = "Party"
        '
        'TempStockAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "TempStockAdjustment"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
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

    Public Class HelpDataSet
        Public Shared Party As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing
        Public Shared IssueReceive As DataSet = Nothing

    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_StockAdjustment"

        LblV_Type.Text = "Tutorial Type"
        LblV_Date.Text = "Tutorial Date"
        LblV_No.Text = "Tutorial No."
        TP1.Text = "Tp1"

        AglObj.GridDesign(DGL1)
    End Sub

    Public Sub Form_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim mCondStr$ = ""

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
                " From Store_StockAdjustment H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$ = " Where 1=1 "

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


        AglObj.PubFindQry = "SELECT H.DocId AS SearchCode,  " & _
                            " " & AglObj.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " " & AglObj.V_No_Field("H.DocId") & " As [" & LblV_No.Text & "]," & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " Sg.Name As [" & LblAcCode.Text & "], " & _
                            " H.Amount As [" & LblTextTotalAmount.Text & "], " & _
                            " H.TotalReceiveQty As [" & LblTextTotalReceiveQty.Text & "], " & _
                            " H.TotalIssueQty As [" & LblTextTotalIssueQty.Text & "], " & _
                            " Sm.Name AS [" & LblSite_Code.Text & "], " & _
                            " H.Remark " & _
                            " FROM dbo.Store_StockAdjustment H WITH (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code  " & _
                            " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode " & mCondStr

        AglObj.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc"

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1IssueReceive, 60, 0, Col1IssueReceive, True, False, False)
            .AddAgTextColumn(DGL1, Col1Item, 150, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 120, 255, Col1ItemDescription, True, False, False)
            .AddAgTextColumn(DGL1, Col1Unit, 60, 0, Col1Unit, True, True, False)
            .AddAgTextColumn(DGL1, Col1BatchNo, 80, 0, Col1BatchNo, True, False, False)
            .AddAgTextColumn(DGL1, Col1Godown, 110, 0, Col1Godown, True, False, False)
            .AddAgNumberColumn(DGL1, Col1DocQty, 60, 8, 3, False, Col1DocQty, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Qty_Rec, 60, 8, 3, False, Col1Qty_Rec, False, True, True)
            .AddAgNumberColumn(DGL1, Col1Qty_Iss, 60, 8, 3, False, Col1Qty_Iss, False, True, True)
            .AddAgNumberColumn(DGL1, Col1Rate, 60, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Amount, 80, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(DGL1, Col1Remark, 120, 255, Col1Remark, True, False, False)
            .AddAgTextColumn(DGL1, Col1UID, 80, 0, Col1UID, False, True, False)
            .AddAgTextColumn(DGL1, Col1TempUID, 80, 0, Col1TempUID, False, True, False)
        End With
        AglObj.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        DGL1.Columns(Col1Remark).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Topctrl1.ChangeAgGridState(DGL1, Not AglObj.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""

        mQry = "UPDATE dbo.Store_StockAdjustment " & _
                " SET " & _
                " ReferenceNo = " & AglObj.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " AcCode = " & AglObj.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                " Amount = " & Val(LblValTotalAmount.Text) & ", " & _
                " TotalIssueQty = " & Val(LblValTotalIssueQty.Text) & ", " & _
                " TotalReceiveQty = " & Val(LblValTotalReceiveQty.Text) & ", " & _
                " Remark = " & AglObj.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AglObj.Chk_Text(SearchCode) & " "
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If AglObj.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = "INSERT INTO dbo.Store_StockHeader (DocId, PreparedBy, U_EntDt, U_AE)" & _
                    " VALUES (" & AglObj.Chk_Text(SearchCode) & ", " & _
                    " " & AglObj.Chk_Text(AglObj.PubUserName) & ", " & _
                    " " & AglObj.Chk_Text(AglObj.PubLoginDate) & ", " & _
                    " 'A') "
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        Else
            mQry = "Update dbo.Store_StockHeader " & _
                    " SET  " & _
                    " U_AE = 'E', " & _
                    " Edit_Date = " & AglObj.Chk_Text(AglObj.PubLoginDate) & ", " & _
                    " ModifiedBy = " & AglObj.Chk_Text(AglObj.PubUserName) & " " & _
                    " WHERE DocId = " & AglObj.Chk_Text(SearchCode) & " "
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        If AglObj.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_Stock WHERE DocId = '" & mSearchCode & "'"
            AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value.ToString.Trim <> "" _
                And DGL1.Item(Col1IssueReceive, bIntI).Value.ToString.Trim <> "" Then

                bIntSr += 1

                If AglObj.XNull(DGL1.Item(Col1TempUID, bIntI).Value).ToString.Trim = "" Then
                    If AglObj.XNull(DGL1.Item(Col1UID, bIntI).Value).ToString.Trim = "" Then
                        DGL1.Item(Col1UID, bIntI).Value = AglObj.GetGUID(GcnRead).ToString
                    End If
                End If

                bStrLineUid = DGL1.Item(Col1UID, bIntI).Value


                mQry = "INSERT INTO dbo.Store_Stock (DocId, Sr, UID, Div_Code, Site_Code, V_Type, V_Prefix, V_No, V_Date, " & _
                                " ReferenceNo, AcCode, Item, ItemDescription, Unit, BatchNo, Godown, IssueReceive, DocQty, Qty_Rec, Qty_Iss, " & _
                                " Rate, Amount, Remark) " & _
                                " VALUES (" & _
                                " " & AglObj.Chk_Text(mSearchCode) & ", " & bIntSr & ", " & AglObj.Chk_Text(bStrLineUid) & ", " & _
                                " " & AglObj.Chk_Text(TxtDivision.AgSelectedValue) & ",  " & _
                                " " & AglObj.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                                " " & AglObj.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                                " " & AglObj.Chk_Text(LblPrefix.Text) & ", " & _
                                " " & Val(TxtV_No.Text) & ", " & _
                                " " & AglObj.ConvertDate(TxtV_Date.Text) & ", " & _
                                " " & AglObj.Chk_Text(TxtReferenceNo.Text) & ", " & _
                                " " & AglObj.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Unit, bIntI)) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.Item(Col1BatchNo, bIntI).Value) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Godown, bIntI)) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.Item(Col1IssueReceive, bIntI).Value) & ", " & _
                                " " & Val(DGL1.Item(Col1DocQty, bIntI).Value) & ", " & _
                                " " & Val(DGL1.Item(Col1Qty_Rec, bIntI).Value) & ", " & _
                                " " & Val(DGL1.Item(Col1Qty_Iss, bIntI).Value) & ", " & _
                                " " & Val(DGL1.Item(Col1Rate, bIntI).Value) & ", " & _
                                " " & Val(DGL1.Item(Col1Amount, bIntI).Value) & ", " & _
                                " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & " " & _
                                " )"
                AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        mQry = "Delete From Store_Stock Where DocId = '" & SearchCode & "'"
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_StockHeader Where DocId = '" & SearchCode & "'"
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_StockAdjustment Where DocId = '" & SearchCode & "' "
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
            " From Store_StockAdjustment H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AglObj.FillData(mQry, AglObj.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AglObj.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AglObj.XNull(.Rows(0)("ReferenceNo"))
                TxtRemark.Text = AglObj.XNull(.Rows(0)("Remark"))

                TxtAcCode.AgSelectedValue = AglObj.XNull(.Rows(0)("AcCode"))
                LblValTotalAmount.Text = Format(AglObj.VNull(.Rows(0)("Amount")), "0.00")
                LblValTotalIssueQty.Text = Format(AglObj.VNull(.Rows(0)("TotalIssueQty")), "0.000")
                LblValTotalReceiveQty.Text = Format(AglObj.VNull(.Rows(0)("TotalReceiveQty")), "0.000")

                mQry = "Select L.* " & _
                        " From Store_Stock L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AglObj.FillData(mQry, AglObj.GcnRead).Tables(0)
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

                            If AglObj.XNull(.Rows(bIntI)("IssueReceive")).ToString.Trim = "" Then
                                If AglObj.VNull(.Rows(bIntI)("Qty_Rec")) > 0 Then
                                    DGL1.Item(Col1IssueReceive, bIntI).Value = IssueReceive.Receive
                                ElseIf AglObj.VNull(.Rows(bIntI)("Qty_Iss")) > 0 Then
                                    DGL1.Item(Col1IssueReceive, bIntI).Value = IssueReceive.Issue

                                End If
                            Else
                                DGL1.Item(Col1IssueReceive, bIntI).Value = AglObj.XNull(.Rows(bIntI)("IssueReceive"))
                            End If


                            DGL1.Item(Col1DocQty, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("DocQty")), "0.000")
                            DGL1.Item(Col1Qty_Rec, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Qty_Rec")), "0.000")
                            DGL1.Item(Col1Qty_Iss, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Qty_Iss")), "0.000")
                            DGL1.Item(Col1Rate, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Rate")), "0.00")
                            DGL1.Item(Col1Amount, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Amount")), "0.00")
                            DGL1.Item(Col1BatchNo, bIntI).Value = AglObj.XNull(.Rows(bIntI)("BatchNo"))
                            DGL1.Item(Col1Remark, bIntI).Value = AglObj.XNull(.Rows(bIntI)("Remark"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AglObj.VNull(.Rows(bIntI)("Sr")), bIntI)

                        Next bIntI
                    End If
                End With
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

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AglObj.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)

        Topctrl1.ChangeAgGridState(DGL1, False)
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AglObj.PubUserName

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AglObj.PubLoginDate
        End If
    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        '<Executbale Code>
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()

        Try
            mQry = " Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, " & _
                    " Sg.DispName AS PartyDispName, Sg.ManualCode, Sg.Nature, " & _
                    " IsNull(P.MasterType,'') As MasterType, " & _
                    " Sg.SalesTaxPostingGroup " & _
                    " From Party P With (NoLock) " & _
                    " Left Join SubGroup Sg With (NoLock) On P.SubCode = Sg.SubCode " & _
                    " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                    " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                    " Where 1=1 And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Sg.Site_Code", AglObj.PubSiteCode, "Sg.CommonAc") & " " & _
                    " Order By SG.Name "
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
                    " LEFT JOIN Store_ItemCategory C With (NoLock)  ON C.Code = G.ItemCategory " & _
                    " ORDER BY I.Nature, I.Description "
            HelpDataSet.Item = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT G.Code, G.Description AS Name FROM Store_Godown G  With (NoLock) ORDER BY G.Description "
            HelpDataSet.Godown = AglObj.FillData(mQry, GcnRead)

            mQry = " Select '" & IssueReceive.Issue & "' As Code, '" & IssueReceive.Issue & "' As Name " & _
                    " UNION ALL " & _
                    " Select '" & IssueReceive.Receive & "' As Code, '" & IssueReceive.Receive & "' As Name "
            HelpDataSet.IssueReceive = AglObj.FillData(mQry, GcnRead)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtAcCode.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Party.Copy
        DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Unit) = HelpDataSet.Unit.Copy
        DGL1.AgHelpDataSet(Col1Godown) = HelpDataSet.Godown.Copy
        DGL1.AgHelpDataSet(Col1IssueReceive) = HelpDataSet.IssueReceive.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AglObj.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer = 0

        LblValTotalAmount.Text = 0 : LblValTotalIssueQty.Text = 0 : LblValTotalReceiveQty.Text = 0

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
            If DGL1.Item(Col1DocQty, bIntI).Value Is Nothing Then DGL1.Item(Col1DocQty, bIntI).Value = ""
            If DGL1.Item(Col1Qty_Iss, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty_Iss, bIntI).Value = ""
            If DGL1.Item(Col1Qty_Rec, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty_Rec, bIntI).Value = ""
            If DGL1.Item(Col1Rate, bIntI).Value Is Nothing Then DGL1.Item(Col1Rate, bIntI).Value = ""
            If DGL1.Item(Col1Amount, bIntI).Value Is Nothing Then DGL1.Item(Col1Amount, bIntI).Value = ""
            If DGL1.Item(Col1IssueReceive, bIntI).Value Is Nothing Then DGL1.Item(Col1IssueReceive, bIntI).Value = ""


            Try
                If DGL1.Rows.Count = 1 Then
                    If AglObj.XNull(DGL1.Item(Col1IssueReceive, 0).Value).ToString.Trim = "" Then
                        If QuantityType = eQuantityType.Issue Then
                            DGL1.Item(Col1IssueReceive, 0).Value = IssueReceive.Issue
                        Else
                            DGL1.Item(Col1IssueReceive, 0).Value = IssueReceive.Receive
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try

            If DGL1.Item(Col1Item, bIntI).Value.ToString.Trim <> "" Then
                If AglObj.XNull(DGL1.Item(Col1IssueReceive, bIntI).Value).ToString.Trim = "" Then
                    If QuantityType = eQuantityType.Issue Then
                        DGL1.Item(Col1IssueReceive, bIntI).Value = IssueReceive.Issue
                    Else
                        DGL1.Item(Col1IssueReceive, bIntI).Value = IssueReceive.Receive
                    End If
                End If


                DGL1.Item(Col1Amount, bIntI).Value = Format(Val(DGL1.Item(Col1DocQty, bIntI).Value) * Val(DGL1.Item(Col1Rate, bIntI).Value), "0.00")

                DGL1.Item(Col1Qty_Rec, bIntI).Value = ""
                DGL1.Item(Col1Qty_Iss, bIntI).Value = ""

                If AglObj.StrCmp(DGL1.Item(Col1IssueReceive, bIntI).Value.ToString, IssueReceive.Issue) Then
                    DGL1.Item(Col1Qty_Iss, bIntI).Value = Val(DGL1.Item(Col1DocQty, bIntI).Value)

                ElseIf AglObj.StrCmp(DGL1.Item(Col1IssueReceive, bIntI).Value.ToString, IssueReceive.Receive) Then
                    DGL1.Item(Col1Qty_Rec, bIntI).Value = Val(DGL1.Item(Col1DocQty, bIntI).Value)
                End If

                LblValTotalAmount.Text = Val(LblValTotalAmount.Text) + Val(DGL1.Item(Col1Amount, bIntI).Value)
                LblValTotalIssueQty.Text = Val(LblValTotalIssueQty.Text) + Val(DGL1.Item(Col1Qty_Iss, bIntI).Value)
                LblValTotalReceiveQty.Text = Val(LblValTotalReceiveQty.Text) + Val(DGL1.Item(Col1Qty_Rec, bIntI).Value)
            End If
        Next

        LblValTotalAmount.Text = Format(Val(LblValTotalAmount.Text), "0.00")
        LblValTotalReceiveQty.Text = Format(Val(LblValTotalReceiveQty.Text), "0.000")
        LblValTotalIssueQty.Text = Format(Val(LblValTotalIssueQty.Text), "0.000")
    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function


            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1Item, bIntI).Value.ToString.Trim <> "" Then
                    If DGL1.Item(Col1IssueReceive, bIntI).Value.ToString.Trim = "" Then
                        MsgBox("Issue Receive is blank at Row No. : " & DGL1.Item(ColSNo, bIntI).Value & "!...", MsgBoxStyle.Information, "Validation Check")
                        DGL1.CurrentCell = DGL1(Col1IssueReceive, bIntI)
                        DGL1.Focus() : Exit Function
                    End If

                    If Val(DGL1.Item(Col1DocQty, bIntI).Value) <= 0 Then
                        MsgBox("" & Col1DocQty & " is required at Row No. : " & DGL1.Item(ColSNo, bIntI).Value & "!...", MsgBoxStyle.Information, "Validation Check")
                        DGL1.CurrentCell = DGL1(Col1DocQty, bIntI)
                        DGL1.Focus() : Exit Function
                    End If
                End If
            Next


            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_StockAdjustment H With (NoLock) " & _
                        " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                        " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                        " And H.ReferenceNo = " & AglObj.Chk_Text(TxtReferenceNo.Text) & " " & _
                        " AND H.Site_Code = " & AglObj.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
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
        LblValTotalAmount.Text = 0 : LblValTotalIssueQty.Text = 0 : LblValTotalReceiveQty.Text = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtDivision.Enter, TxtDocId.Enter, TxtReferenceNo.Enter, TxtSite_Code.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtRemark.Enter, TxtAcCode.Enter

        Try
            Select Case sender.name
                Case TxtAcCode.Name
                    'TxtAcCode.AgRowFilter = " IsActive = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtAcCode.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AglObj.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()

            End Select

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AglObj.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
                Call ProcFillReferenceNo()
            End If

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            'Case TxtSubject.Name
            '    If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
            '        Sender.AgSelectedValue = ""
            '        TxtSubjectManualCode.Text = ""
            '    Else
            '        If Sender.AgHelpDataSet IsNot Nothing Then
            '            DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
            '            TxtSubjectManualCode.Text = AglObj.XNull(DrTemp(0)("ManualCode"))
            '        End If
            '    End If
            '    DrTemp = Nothing

        End Select

    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.

        If Enb Then
            '<Executable Code>
        End If
    End Sub

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
    '                'Case <ColumnIndex>
    '                '<Executbale Code>
    '                Case Col1Item
    '                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
    '                        DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
    '                        DGL1.AgSelectedValue(Col1Unit, mRowIndex) = ""
    '                        DGL1.Item(Col1Rate, mRowIndex).Value = ""
    '                    Else
    '                        If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
    '                            DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AglObj.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
    '                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AglObj.XNull(DrTemp(0)("Unit"))
    '                            DGL1.Item(Col1Rate, mRowIndex).Value = Format(AglObj.VNull(DrTemp(0)("PurchaseRate")), "0.00")

    '                            If AglObj.XNull(DGL1.Item(Col1IssueReceive, mRowIndex).Value).ToString.Trim = "" Then
    '                                If QuantityType = eQuantityType.Issue Then
    '                                    DGL1.Item(Col1IssueReceive, mRowIndex).Value = IssueReceive.Issue
    '                                Else
    '                                    DGL1.Item(Col1IssueReceive, mRowIndex).Value = IssueReceive.Receive
    '                                End If
    '                            End If
    '                        End If
    '                        DrTemp = Nothing
    '                    End If

    '            End Select
    '        End With

    '        Call Calculation()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

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

End Class
