Imports CrystalDecisions.CrystalReports.Engine
Public Class TempPaymentMultipleParty
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1SubCode As String = "Party"
    Protected Const Col1DueNo As String = "Dues No."
    Protected Const Col1DueSr As String = "Due Sr"
    Protected Const Col1DueReferenceNo As String = "Dues Reference No"
    Protected Const Col1PartyAddress As String = "Party Address"
    Protected Const Col1PartyCity As String = "Party City"
    Protected Const Col1CurrBalance As String = "Curr Balance"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Discount As String = "Discount"
    Protected Const Col1NetAmount As String = "Net Amount"
    Protected Const Col1CashBank As String = "Cash/Bank"
    Protected Const Col1CashBankAc As String = "Cash/Bank Ac"
    Protected Const Col1ChqNo As String = "Chq No"
    Protected Const Col1ChqDate As String = "Chq Date"
    Protected Const Col1Remark As String = "Remark"

    Dim mToatlAdjustedAmt As Double = 0
    Dim mTransactionType As TransactionType = TransactionType.Payment
    Dim mDuesAmtFieldName As String = "PaybleAmount"

    Public Class HelpDataSet
        Public Shared SubCode As DataSet = Nothing
        Public Shared SubCodeFromDues As DataSet = Nothing
        Public Shared Dues As DataSet = Nothing
        Public Shared CashBank As DataSet = Nothing
        Public Shared CashBankAc As DataSet = Nothing
    End Class

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Enum TransactionType
        Receipt = 0
        Payment = 1
    End Enum

    Public Property TransType() As TransactionType
        Get
            Return mTransactionType
        End Get
        Set(ByVal value As TransactionType)
            mTransactionType = value
            mDuesAmtFieldName = IIf(TransType = TransactionType.Payment, "PaybleAmount", "ReceivableAmount")
        End Set
    End Property


#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.LblPaymentDetail = New System.Windows.Forms.LinkLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalCurrentBalance = New System.Windows.Forms.Label
        Me.LblTotalCurrentBalanceText = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.LblNetAmount = New System.Windows.Forms.Label
        Me.LblNetAmtText = New System.Windows.Forms.Label
        Me.LblTotalDiscount = New System.Windows.Forms.Label
        Me.LblTotalDiscountText = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(807, 573)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(638, 573)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(469, 573)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(160, 573)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(20, 573)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 565)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 573)
        Me.GBoxDivision.Size = New System.Drawing.Size(148, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
        Me.TxtDivision.Size = New System.Drawing.Size(142, 18)
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
        Me.LblV_No.Location = New System.Drawing.Point(493, 34)
        Me.LblV_No.Size = New System.Drawing.Size(84, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Payment No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(601, 33)
        Me.TxtV_No.Size = New System.Drawing.Size(123, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(371, 39)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(268, 34)
        Me.LblV_Date.Size = New System.Drawing.Size(91, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Payment Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(585, 19)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(387, 33)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(493, 15)
        Me.LblV_Type.Size = New System.Drawing.Size(91, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Payment Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(601, 13)
        Me.TxtV_Type.Size = New System.Drawing.Size(123, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(371, 19)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(268, 14)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(387, 13)
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
        Me.LblPrefix.Location = New System.Drawing.Point(553, 34)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 18)
        Me.TabControl1.Size = New System.Drawing.Size(991, 107)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(983, 81)
        Me.TP1.Text = "Document Detail"
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
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        Me.Topctrl1.TabIndex = 2
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl2.Location = New System.Drawing.Point(7, 153)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(969, 385)
        Me.Pnl2.TabIndex = 1
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
        Me.TxtRemarks.Location = New System.Drawing.Point(387, 53)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(337, 18)
        Me.TxtRemarks.TabIndex = 4
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(268, 54)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 744
        Me.Label30.Text = "Remarks"
        '
        'LblPaymentDetail
        '
        Me.LblPaymentDetail.BackColor = System.Drawing.Color.SteelBlue
        Me.LblPaymentDetail.DisabledLinkColor = System.Drawing.Color.White
        Me.LblPaymentDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaymentDetail.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblPaymentDetail.LinkColor = System.Drawing.Color.White
        Me.LblPaymentDetail.Location = New System.Drawing.Point(7, 132)
        Me.LblPaymentDetail.Name = "LblPaymentDetail"
        Me.LblPaymentDetail.Size = New System.Drawing.Size(119, 20)
        Me.LblPaymentDetail.TabIndex = 733
        Me.LblPaymentDetail.TabStop = True
        Me.LblPaymentDetail.Text = "Payment Detail"
        Me.LblPaymentDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalCurrentBalance)
        Me.Panel1.Controls.Add(Me.LblTotalCurrentBalanceText)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Controls.Add(Me.LblNetAmount)
        Me.Panel1.Controls.Add(Me.LblNetAmtText)
        Me.Panel1.Controls.Add(Me.LblTotalDiscount)
        Me.Panel1.Controls.Add(Me.LblTotalDiscountText)
        Me.Panel1.Location = New System.Drawing.Point(7, 539)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(969, 23)
        Me.Panel1.TabIndex = 734
        '
        'LblTotalCurrentBalance
        '
        Me.LblTotalCurrentBalance.AutoSize = True
        Me.LblTotalCurrentBalance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCurrentBalance.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalCurrentBalance.Location = New System.Drawing.Point(135, 4)
        Me.LblTotalCurrentBalance.Name = "LblTotalCurrentBalance"
        Me.LblTotalCurrentBalance.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalCurrentBalance.TabIndex = 675
        Me.LblTotalCurrentBalance.Text = "."
        Me.LblTotalCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalCurrentBalanceText
        '
        Me.LblTotalCurrentBalanceText.AutoSize = True
        Me.LblTotalCurrentBalanceText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCurrentBalanceText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalCurrentBalanceText.Location = New System.Drawing.Point(10, 4)
        Me.LblTotalCurrentBalanceText.Name = "LblTotalCurrentBalanceText"
        Me.LblTotalCurrentBalanceText.Size = New System.Drawing.Size(119, 16)
        Me.LblTotalCurrentBalanceText.TabIndex = 674
        Me.LblTotalCurrentBalanceText.Text = "Current Balance :"
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(397, 3)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 673
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(291, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(100, 16)
        Me.LblTotalAmountText.TabIndex = 672
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'LblNetAmount
        '
        Me.LblNetAmount.AutoSize = True
        Me.LblNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNetAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblNetAmount.Location = New System.Drawing.Point(879, 3)
        Me.LblNetAmount.Name = "LblNetAmount"
        Me.LblNetAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblNetAmount.TabIndex = 671
        Me.LblNetAmount.Text = "."
        Me.LblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNetAmtText
        '
        Me.LblNetAmtText.AutoSize = True
        Me.LblNetAmtText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNetAmtText.ForeColor = System.Drawing.Color.Maroon
        Me.LblNetAmtText.Location = New System.Drawing.Point(774, 3)
        Me.LblNetAmtText.Name = "LblNetAmtText"
        Me.LblNetAmtText.Size = New System.Drawing.Size(90, 16)
        Me.LblNetAmtText.TabIndex = 669
        Me.LblNetAmtText.Text = "Net Amount :"
        '
        'LblTotalDiscount
        '
        Me.LblTotalDiscount.AutoSize = True
        Me.LblTotalDiscount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDiscount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalDiscount.Location = New System.Drawing.Point(647, 3)
        Me.LblTotalDiscount.Name = "LblTotalDiscount"
        Me.LblTotalDiscount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalDiscount.TabIndex = 668
        Me.LblTotalDiscount.Text = "."
        Me.LblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalDiscountText
        '
        Me.LblTotalDiscountText.AutoSize = True
        Me.LblTotalDiscountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDiscountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalDiscountText.Location = New System.Drawing.Point(534, 3)
        Me.LblTotalDiscountText.Name = "LblTotalDiscountText"
        Me.LblTotalDiscountText.Size = New System.Drawing.Size(105, 16)
        Me.LblTotalDiscountText.TabIndex = 667
        Me.LblTotalDiscountText.Text = "Total Discount :"
        '
        'TempPaymentMultipleParty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 622)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblPaymentDetail)
        Me.Controls.Add(Me.Pnl2)
        Me.Name = "TempPaymentMultipleParty"
        Me.Text = "Template Goods Receive"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.LblPaymentDetail, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblPaymentDetail As System.Windows.Forms.LinkLabel
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblNetAmount As System.Windows.Forms.Label
    Protected WithEvents LblNetAmtText As System.Windows.Forms.Label
    Protected WithEvents LblTotalDiscount As System.Windows.Forms.Label
    Protected WithEvents LblTotalDiscountText As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents LblTotalCurrentBalance As System.Windows.Forms.Label
    Protected WithEvents LblTotalCurrentBalanceText As System.Windows.Forms.Label
#End Region

    Private Sub FrmBillEntry_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1DueNo, I).Value <> "" Then
                    mQry = "UPDATE Dues " & _
                            " SET AdjustedAmount = (SELECT Sum(Amount) " & _
                            "                       FROM DuesPaymentDetail With (NoLock)  " & _
                            "                       WHERE ReferenceDocID = '" & .AgSelectedValue(Col1DueNo, I) & "' " & _
                            "                       And Reference_Sr = " & Val(.Item(Col1DueSr, I).Value) & "" & _
                            "                       GROUP BY ReferenceDocID) " & _
                            " WHERE DocID = '" & .AgSelectedValue(Col1DueNo, I) & "' " & _
                            " And Sr = " & Val(.Item(Col1DueSr, I).Value) & ""
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnRead, AgL.ECmd)
                End If
            Next
        End With
    End Sub

    Private Sub TempPaymentMultipleParty_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1DueNo, I).Value <> "" Then
                    mQry = "UPDATE Dues " & _
                            " SET AdjustedAmount = (SELECT Sum(Amount) " & _
                            "                       FROM DuesPaymentDetail With (NoLock)  " & _
                            "                       WHERE ReferenceDocID = '" & .AgSelectedValue(Col1DueNo, I) & "' " & _
                            "                       And Reference_Sr = " & Val(.Item(Col1DueSr, I).Value) & "" & _
                            "                       GROUP BY ReferenceDocID) " & _
                            " WHERE DocID = '" & .AgSelectedValue(Col1DueNo, I) & "' " & _
                            " And Sr = " & Val(.Item(Col1DueSr, I).Value) & ""
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnRead, AgL.ECmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "DuesPayment"
        LogTableName = "DuesPayment_Log"
        MainLineTableCsv = "DuesPaymentDetail"
        LogLineTableCsv = "DuesPaymentDetail_Log"

        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From DuesPayment H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0) = 0 " & _
                " And IsNull(H.TransactionType,'Payment') = '" & IIf(mTransactionType = TransactionType.Payment, "Payment", "Receipt") & "'  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select UID As SearchCode " & _
               " From DuesPayment_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "'  " & _
               " And IsNull(H.TransactionType,'Payment')='" & IIf(mTransactionType = TransactionType.Payment, "Payment", "Receipt") & "'   " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], " & _
        '                 " H.V_No AS [Entry No], Sg.DispName As VendorName  " & _
        '                 " FROM DuesPayment H " & _
        '                 " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
        '                 " LEFT JOIN SubGroup Sg On H.SubCode = Sg.SubCode " & _
        '                 " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.DocId AS SearchCode, H.V_Type AS [Payment Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [Payment No], " & _
                    " H.TransactionType AS [TRANSACTION Type], H.PartyName AS [Party Name], H.PartyAddress AS [Party Address], H.PartyCity AS [Party City],  " & _
                    " H.CurrBalance AS [Currunt Balance], H.PaidAmount AS [Paid Amount], H.Discount, H.NetAmount AS [Net Amount], H.CashBank AS [Cash/Bank],  " & _
                    " H.CashBankAc AS [Cash/Bank A/c], H.ChqNo AS [Cheque No], H.ChqDate AS [Cheque Date], H.Remark, H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date],  " & _
                    " H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log],  " & _
                    " H.MoveToLogDate AS [Move To Log Date], H.Status, H.TDSPer AS [TDS %], H.TDSAmt AS [TDS Amount], " & _
                    " D.Div_Name AS Division, SM.Name AS [Site Name]  " & _
                    " FROM  DuesPayment H " & _
                    " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                    " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                    " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], " & _
        '                    " H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                    " Sg.DispName As VendorName  " & _
        '                    " FROM DuesPayment H " & _
        '                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN SubGroup Sg On H.SubCode = Sg.SubCode " & _
        '                    " Where 1=1 " & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Payment Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [Payment No], " & _
                    " H.TransactionType AS [TRANSACTION Type], H.PartyName AS [Party Name], H.PartyAddress AS [Party Address], H.PartyCity AS [Party City],  " & _
                    " H.CurrBalance AS [Currunt Balance], H.PaidAmount AS [Paid Amount], H.Discount, H.NetAmount AS [Net Amount], H.CashBank AS [Cash/Bank],  " & _
                    " H.CashBankAc AS [Cash/Bank A/c], H.ChqNo AS [Cheque No], H.ChqDate AS [Cheque Date], H.Remark, H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date],  " & _
                    " H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log],  " & _
                    " H.MoveToLogDate AS [Move To Log Date], H.Status, H.TDSPer AS [TDS %], H.TDSAmt AS [TDS Amount], " & _
                    " D.Div_Name AS Division, SM.Name AS [Site Name]  " & _
                    " FROM  DuesPayment_Log H " & _
                    " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                    " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                    " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1SubCode, 250, 5, Col1SubCode, True, False)
            .AddAgTextColumn(Dgl1, Col1DueNo, 80, 5, Col1DueNo, True, True)
            .AddAgTextColumn(Dgl1, Col1DueSr, 100, 5, Col1DueSr, False, True)
            .AddAgTextColumn(Dgl1, Col1DueReferenceNo, 90, 5, Col1DueReferenceNo, True, True)
            .AddAgTextColumn(Dgl1, Col1PartyAddress, 100, 5, Col1PartyAddress, False, True)
            .AddAgTextColumn(Dgl1, Col1PartyCity, 100, 5, Col1PartyCity, False, True)
            .AddAgNumberColumn(Dgl1, Col1CurrBalance, 100, 5, 2, False, Col1CurrBalance, True, False)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, False)
            .AddAgNumberColumn(Dgl1, Col1Discount, 100, 5, 2, False, Col1Discount, True, False)
            .AddAgNumberColumn(Dgl1, Col1NetAmount, 100, 5, 2, False, Col1NetAmount, True, True)
            .AddAgTextColumn(Dgl1, Col1CashBank, 100, 5, Col1CashBank, True, False)
            .AddAgTextColumn(Dgl1, Col1CashBankAc, 100, 5, Col1CashBankAc, False, False)
            .AddAgTextColumn(Dgl1, Col1ChqNo, 100, 10, Col1ChqNo, True, False)
            .AddAgDateColumn(Dgl1, Col1ChqDate, 100, Col1ChqDate, True, False)
            .AddAgTextColumn(Dgl1, Col1Remark, 200, 255, Col1Remark, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl2)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True

        'Dgl1.Columns(Col1CashBank).ReadOnly = True

        FrmSaleOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = " Update DuesPayment_Log " & _
                " SET  " & _
                " TransactionType = " & AgL.Chk_Text(IIf(TransType = TransactionType.Payment, "Payment", "Receipt")) & ", " & _
                " CurrBalance = " & Val(LblTotalCurrentBalance.Text) & " , " & _
                " PaidAmount = " & Val(LblTotalAmount.Text) & " , " & _
                " Discount = " & Val(LblTotalDiscount.Text) & " , " & _
                " NetAmount = " & Val(LblNetAmount.Text) & " , " & _
                " Remark = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From DuesPaymentDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1SubCode, I).Value <> "" Then
                    mSr += 1
                    mQry = "Insert Into DuesPaymentDetail_Log(UID, DocId, Sr, ReferenceDocID, Amount, Reference_Sr, " & _
                            " SubCode, PartyName, PartyAddress, PartyCity, CurrBalance, " & _
                            " Discount, NetAmount, CashBank, CashBankAc, " & _
                            " ChqNo, ChqDate, Remark) " & _
                            " Values( " & _
                            " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                            " " & AgL.Chk_Text(.AgSelectedValue(Col1DueNo, I)) & ", " & _
                            " " & Val(.Item(Col1Amount, I).Value) & ", " & .Item(Col1DueSr, I).Value & ", " & _
                            " " & AgL.Chk_Text(.AgSelectedValue(Col1SubCode, I)) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1SubCode, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1PartyAddress, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1PartyCity, I).Value) & ", " & _
                            " " & Val(.Item(Col1CurrBalance, I).Value) & ", " & _
                            " " & Val(.Item(Col1Discount, I).Value) & ", " & _
                            " " & Val(.Item(Col1NetAmount, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1CashBank, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1CashBankAc, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1ChqNo, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1ChqDate, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1Remark, I).Value) & ")"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From DuesPayment H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From DuesPayment_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remark"))
                LblTotalCurrentBalance.Text = AgL.VNull(.Rows(0)("CurrBalance"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("PaidAmount"))
                LblTotalDiscount.Text = AgL.VNull(.Rows(0)("Discount"))
                LblNetAmount.Text = AgL.VNull(.Rows(0)("NetAmount"))

                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select L.*, D.RefV_Type + '-' + Convert(nVarChar,D.RefV_No) As DueReferenceNo " & _
                            " from DuesPaymentDetail L " & _
                            " LEFT JOIN Dues D On L.ReferenceDocID + Convert(nVarChar,L.Reference_Sr) = D.DocId + Convert(nVarChar,D.Sr) " & _
                            " Where L.DocId = '" & SearchCode & "' " & _
                            " Order By L.Sr"
                Else
                    mQry = "Select L.*, D.RefV_Type + '-' + Convert(nVarChar,D.RefV_No)  As DueReferenceNo " & _
                            " from DuesPaymentDetail_Log L " & _
                            " LEFT JOIN Dues D On L.ReferenceDocID + Convert(nVarChar,L.Reference_Sr) = D.DocId + Convert(nVarChar,D.Sr) " & _
                            " Where L.UID = '" & SearchCode & "' " & _
                            " Order By L.Sr"
                    'mQry = "Select * from DuesPaymentDetail_Log Where UID = '" & SearchCode & "' Order By Sr"
                End If
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1DueNo, I) = AgL.XNull(.Rows(I)("ReferenceDocID"))
                            Dgl1.Item(Col1DueSr, I).Value = AgL.VNull(.Rows(I)("Reference_Sr"))
                            Dgl1.Item(Col1DueReferenceNo, I).Value = AgL.XNull(.Rows(I)("DueReferenceNo"))
                            Dgl1.AgSelectedValue(Col1SubCode, I) = AgL.XNull(.Rows(I)("SubCode"))
                            Dgl1.Item(Col1PartyAddress, I).Value = AgL.XNull(.Rows(I)("PartyAddress"))
                            Dgl1.Item(Col1PartyCity, I).Value = AgL.XNull(.Rows(I)("PartyCity"))
                            Dgl1.Item(Col1CurrBalance, I).Value = AgL.XNull(.Rows(I)("CurrBalance"))
                            Dgl1.Item(Col1Amount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                            Dgl1.Item(Col1Discount, I).Value = AgL.XNull(.Rows(I)("Discount"))
                            Dgl1.Item(Col1NetAmount, I).Value = AgL.XNull(.Rows(I)("NetAmount"))
                            Dgl1.Item(Col1CashBank, I).Value = AgL.XNull(.Rows(I)("CashBank"))
                            Dgl1.Item(Col1CashBankAc, I).Value = AgL.XNull(.Rows(I)("CashBankAc"))
                            Dgl1.Item(Col1ChqNo, I).Value = AgL.XNull(.Rows(I)("ChqNo"))
                            Dgl1.Item(Col1ChqDate, I).Value = AgL.XNull(.Rows(I)("ChqDate"))
                            Dgl1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With

    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Dgl1.AgHelpDataSet(Col1SubCode, 9) = HelpDataSet.SubCodeFromDues
        Dgl1.AgHelpDataSet(Col1DueNo) = HelpDataSet.Dues
        Dgl1.AgHelpDataSet(Col1CashBank) = HelpDataSet.CashBank
        Dgl1.AgHelpDataSet(Col1CashBankAc) = HelpDataSet.CashBankAc
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
                Case Col1SubCode
                    If Dgl1.Item(Col1SubCode, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1SubCode, mRowIndex).ToString.Trim = "" Then
                        Dgl1.AgSelectedValue(Col1DueNo, mRowIndex) = ""
                        Dgl1.Item(Col1DueSr, mRowIndex).Value = ""
                        Dgl1.Item(Col1DueNo, mRowIndex).Value = ""
                        Dgl1.Item(Col1PartyAddress, mRowIndex).Value = ""
                        Dgl1.Item(Col1PartyCity, mRowIndex).Value = ""
                        Dgl1.Item(Col1CurrBalance, mRowIndex).Value = 0
                    Else
                        If Dgl1.AgDataRow IsNot Nothing Then
                            Dgl1.AgSelectedValue(Col1DueNo, mRowIndex) = AgL.XNull(Dgl1.AgDataRow.Cells("ReferenceDocID").Value)
                            Dgl1.Item(Col1DueSr, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Reference_Sr").Value)
                            Dgl1.Item(Col1DueReferenceNo, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("DueReferenceNo").Value)
                            Dgl1.Item(Col1PartyAddress, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("PartyAddress").Value)
                            Dgl1.Item(Col1PartyCity, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("PartyCity").Value)
                            Dgl1.Item(Col1CurrBalance, mRowIndex).Value = AgL.XNull(Dgl1.AgDataRow.Cells("CurrBalance").Value)
                        End If
                    End If

                Case Col1CashBank
                    If AgL.StrCmp(Dgl1.Item(Col1CashBank, mRowIndex).Value, "Cash") Then
                        Dgl1.Item(Col1ChqNo, mRowIndex).ReadOnly = True
                        Dgl1.Item(Col1ChqDate, mRowIndex).ReadOnly = True
                    Else
                        Dgl1.Item(Col1ChqNo, mRowIndex).ReadOnly = False
                        Dgl1.Item(Col1ChqDate, mRowIndex).ReadOnly = False
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer = 0

        LblTotalCurrentBalance.Text = 0 : LblTotalAmount.Text = 0
        LblTotalDiscount.Text = 0 : LblNetAmount.Text = 0

        With Dgl1
            For I = 0 To Dgl1.RowCount - 1
                If .Item(Col1SubCode, I).Value <> "" Then
                    .Item(Col1NetAmount, I).Value = Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value)

                    'Footer Calculation
                    LblTotalCurrentBalance.Text = Val(LblTotalCurrentBalance.Text) + Val(Dgl1.Item(Col1CurrBalance, I).Value)
                    LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
                    LblTotalDiscount.Text = Val(LblTotalDiscount.Text) + Val(Dgl1.Item(Col1Discount, I).Value)
                    LblNetAmount.Text = Val(LblNetAmount.Text) + Val(Dgl1.Item(Col1NetAmount, I).Value)
                End If
            Next
        End With

        LblTotalCurrentBalance.Text = Format(Val(LblTotalCurrentBalance.Text), "0.00")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
        LblTotalDiscount.Text = Format(Val(LblTotalDiscount.Text), "0.00")
        LblNetAmount.Text = Format(Val(LblNetAmount.Text), "0.00")
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1SubCode).Index) Then passed = False : Exit Sub

        With Dgl1
            If .Item(Col1SubCode, I).Value <> "" Then
                If Val(.Item(Col1Amount, I).Value) = 0 Then
                    MsgBox("Paid Amount Is 0 At Row No. " & .Item(ColSNo, I).Value & "", MsgBoxStyle.Information + MsgBoxStyle.Exclamation)
                    Dgl1.CurrentCell = Dgl1.Item(Col1Amount, I) : Dgl1.Focus()
                    passed = False : Exit Sub
                End If
            End If
        End With
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalCurrentBalance.Text = 0 : LblTotalAmount.Text = 0
        LblTotalDiscount.Text = 0 : LblNetAmount.Text = 0
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Try
            If Dgl1.CurrentCell Is Nothing Then Exit Sub
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1SubCode
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1SubCode).Index) = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And " & AgTemplate.ClsMain.RetDivFilterStr & ""

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    'Private Sub ProcFillPendingBills(ByVal bSubCode As String, ByVal bV_Date As String)
    '    Dim DtTemp As DataTable = Nothing
    '    Dim bConStr$ = ""
    '    Dim I As Integer = 0

    '    Try
    '        mQry = "SELECT H.DocID, H." & mDuesAmtFieldName & ", H.Sr  , " & _
    '                " IsNull(H.AdjustedAmount,0) - IsNull(Dp.Amount,0) AS PaidAmt, " & _
    '                " IsNull(H." & mDuesAmtFieldName & ",0) - (IsNull(H.AdjustedAmount,0) - IsNull(Dp.Amount,0)) As Balance " & _
    '                " FROM Dues H   " & _
    '                " LEFT JOIN DuesPaymentDetail Dp ON H.DocID + Convert(Nvarchar, H.Sr) = Dp.ReferenceDocID  + Convert(Nvarchar, Dp.Reference_Sr ) " & _
    '                " AND Dp.DocID = '" & mInternalCode & "' " & _
    '                " WHERE H.SubCode = '" & bSubCode & "'    " & _
    '                " And H.V_Date <= '" & bV_Date & "' " & _
    '                " And (IsNull(H." & mDuesAmtFieldName & ",0) - IsNull(H.AdjustedAmount,0) > 0 OR  Dp.DocID = '" & mInternalCode & "') "

    '        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
    '        With DtTemp
    '            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    '            If .Rows.Count > 0 Then
    '                For I = 0 To .Rows.Count - 1
    '                    Dgl1.Rows.Add()
    '                    Dgl1.AgSelectedValue(Col1DueNo, I) = AgL.XNull(.Rows(I)("DocId"))
    '                    Dgl1.Item(Col1Amount, I).Value = AgL.VNull(.Rows(I)(mDuesAmtFieldName))
    '                    Dgl1.Item(Col1PaidAmount, I).Value = AgL.VNull(.Rows(I)("PaidAmt"))
    '                    Dgl1.Item(Col1Balance, I).Value = AgL.VNull(.Rows(I)("Balance"))
    '                    Dgl1.Item(Col1Ref_Sr, I).Value = AgL.VNull(.Rows(I)("Sr"))
    '                Next I
    '            End If
    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub TempPaymentMultipleParty_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = " SELECT Sg.SubCode AS Code, Sg.DispName AS Name, " & _
                " IsNull(Sg.IsDeleted,0) As IsDeleted, Sg.Div_Code, " & _
                " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM SubGroup Sg  "
        HelpDataSet.SubCode = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Sg.SubCode AS Code, Sg.DispName AS Name, " & _
                " H.V_Type + '-' + Convert(nVarChar,H.V_No) As DueNo, " & _
                " H.RefV_Type + '-' + Convert(nVarChar,H.RefV_No) As DueReferenceNo, " & _
                " H.DocID AS ReferenceDocID, H.Sr AS Reference_Sr, " & _
                " IsNull(Sg.Add1,'') + IsNull(Sg.Add2 ,'') AS PartyAddress, " & _
                " Sg.CityCode AS PartyCity,  " & _
                " H." & mDuesAmtFieldName & " - H.AdjustedAmount AS CurrBalance, Vt.NCat, " & _
                " IsNull(H.IsDeleted,0) As IsDeleted, H.Div_Code, " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM Dues H " & _
                " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode " & _
                " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type "
        HelpDataSet.SubCodeFromDues = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT H.DocID AS Code, H.V_Type  + '-' + Convert(NVARCHAR, H.V_No), " & _
                " IsNull(H.IsDeleted,0) As IsDeleted, H.Div_Code, " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM Dues H " & _
                " Where " & mDuesAmtFieldName & " > 0  "
        HelpDataSet.Dues = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Sg.SubCode AS Code , Sg.DispName AS Name, Sg.Nature, " & _
                " IsNull(Sg.IsDeleted,0) As IsDeleted, Sg.Div_Code, " & _
                " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM SubGroup Sg " & _
                " WHERE Sg.Nature IN ('Cash','Bank')"
        HelpDataSet.CashBankAc = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT 'Cash' AS Code, 'Cash' AS Description " & _
                " UNION ALL " & _
                " SELECT 'Bank' AS Code, 'Bank' AS Description "
        HelpDataSet.CashBank = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
