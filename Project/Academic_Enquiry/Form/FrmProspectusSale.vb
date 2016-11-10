Public Class FrmProspectusSale
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1Item As String = "Item"
    Protected Const Col1ItemDescription As String = "Item Description"
    Protected Const Col1Session As String = "Session"
    Protected Const Col1Program As String = "Program"
    Protected Const Col1ProcpectusNo As String = "Procpectus No"
    Protected Const Col1Godown As String = "Godown"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1SalesTaxGroupItem As String = "Sales Tax Group"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"
    Dim _BlnManageStock As Boolean = True, _BlnManageAccount As Boolean = True
    Dim _eQuantityType As eQuantityType = eQuantityType.Issue
    Dim mObjFrmPaymentDetail As AgLibrary.FrmPaymentDetail = Nothing
    Dim mMaxFeeAc$ = ""
    Dim mBlnIsUserCanApprove As Boolean = False, mBlnIsAutoApproved As Boolean = False



    Public Enum eQuantityType
        Issue
        Receive
    End Enum

#Region "Form Designer Code"

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel


    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents TxtParty As AgControls.AgTextBox
    Protected WithEvents LblParty As System.Windows.Forms.Label
    Protected WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblValNetAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextNetAmount As System.Windows.Forms.Label
    Friend WithEvents TxtReceiveAmount As AgControls.AgTextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As AgControls.AgTextBox
    Friend WithEvents lblMobile As System.Windows.Forms.Label
    Friend WithEvents TxtPhone As AgControls.AgTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents TxtCityCode As AgControls.AgTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents TxtAdd1 As AgControls.AgTextBox
    Friend WithEvents TxtAdd2 As AgControls.AgTextBox
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents TxtSalesAc As AgControls.AgTextBox
    Friend WithEvents LblSalesAc As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtParty = New AgControls.AgTextBox
        Me.LblParty = New System.Windows.Forms.Label
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalQty = New System.Windows.Forms.Label
        Me.LblValNetAmount = New System.Windows.Forms.Label
        Me.LblTextNetAmount = New System.Windows.Forms.Label
        Me.TxtReceiveAmount = New AgControls.AgTextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblCity = New System.Windows.Forms.Label
        Me.TxtCityCode = New AgControls.AgTextBox
        Me.lblAddress = New System.Windows.Forms.Label
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.TxtMobile = New AgControls.AgTextBox
        Me.lblMobile = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.lblPhone = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtSalesAc = New AgControls.AgTextBox
        Me.LblSalesAc = New System.Windows.Forms.Label
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
        Me.TxtDocId.Location = New System.Drawing.Point(948, 105)
        Me.TxtDocId.TabIndex = 13
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(310, 49)
        Me.LblV_No.TabIndex = 20
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(416, 47)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(126, 53)
        Me.Label2.TabIndex = 23
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(17, 49)
        Me.LblV_Date.TabIndex = 28
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(126, 33)
        Me.LblV_TypeReq.TabIndex = 22
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(141, 47)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(17, 29)
        Me.LblV_Type.TabIndex = 29
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(141, 27)
        Me.TxtV_Type.Size = New System.Drawing.Size(370, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(126, 13)
        Me.LblSite_CodeReq.TabIndex = 21
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(17, 9)
        Me.LblSite_Code.TabIndex = 30
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(141, 7)
        Me.TxtSite_Code.Size = New System.Drawing.Size(370, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(901, 107)
        Me.LblDocId.TabIndex = 12
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(377, 48)
        Me.LblPrefix.TabIndex = 19
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 162)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtSalesAc)
        Me.TP1.Controls.Add(Me.LblSalesAc)
        Me.TP1.Controls.Add(Me.TxtMobile)
        Me.TP1.Controls.Add(Me.lblMobile)
        Me.TP1.Controls.Add(Me.TxtPhone)
        Me.TP1.Controls.Add(Me.lblPhone)
        Me.TP1.Controls.Add(Me.Label36)
        Me.TP1.Controls.Add(Me.Label35)
        Me.TP1.Controls.Add(Me.lblCity)
        Me.TP1.Controls.Add(Me.TxtCityCode)
        Me.TP1.Controls.Add(Me.lblAddress)
        Me.TP1.Controls.Add(Me.TxtAdd1)
        Me.TP1.Controls.Add(Me.TxtAdd2)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.TxtParty)
        Me.TP1.Controls.Add(Me.LblParty)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 134)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAdd2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAdd1, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblAddress, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCityCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label35, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label36, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblPhone, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPhone, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSalesAc, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesAc, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 5
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(16, 205)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(964, 285)
        Me.Pnl1.TabIndex = 1
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(126, 73)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 24
        Me.LblReferenceNoReq.Text = "Ä"
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(141, 67)
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
        Me.LblReferenceNo.Location = New System.Drawing.Point(17, 68)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 27
        Me.LblReferenceNo.Text = "Reference No."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(17, 182)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(130, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Prospectus Detail :"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtParty
        '
        Me.TxtParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtParty.AgMandatory = True
        Me.TxtParty.AgMasterHelp = False
        Me.TxtParty.AgNumberLeftPlaces = 0
        Me.TxtParty.AgNumberNegetiveAllow = False
        Me.TxtParty.AgNumberRightPlaces = 0
        Me.TxtParty.AgPickFromLastValue = False
        Me.TxtParty.AgRowFilter = ""
        Me.TxtParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtParty.AgSelectedValue = Nothing
        Me.TxtParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParty.Location = New System.Drawing.Point(141, 87)
        Me.TxtParty.MaxLength = 20
        Me.TxtParty.Name = "TxtParty"
        Me.TxtParty.Size = New System.Drawing.Size(370, 18)
        Me.TxtParty.TabIndex = 5
        '
        'LblParty
        '
        Me.LblParty.AutoSize = True
        Me.LblParty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParty.Location = New System.Drawing.Point(17, 89)
        Me.LblParty.Name = "LblParty"
        Me.LblParty.Size = New System.Drawing.Size(49, 15)
        Me.LblParty.TabIndex = 26
        Me.LblParty.Text = "Student"
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(126, 93)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 25
        Me.LblSubCodeReq.Text = "Ä"
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblValNetAmount)
        Me.PnlFooter.Controls.Add(Me.LblTextNetAmount)
        Me.PnlFooter.Location = New System.Drawing.Point(16, 491)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(964, 24)
        Me.PnlFooter.TabIndex = 740
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
        'TxtReceiveAmount
        '
        Me.TxtReceiveAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtReceiveAmount.AgMandatory = False
        Me.TxtReceiveAmount.AgMasterHelp = False
        Me.TxtReceiveAmount.AgNumberLeftPlaces = 8
        Me.TxtReceiveAmount.AgNumberNegetiveAllow = False
        Me.TxtReceiveAmount.AgNumberRightPlaces = 2
        Me.TxtReceiveAmount.AgPickFromLastValue = False
        Me.TxtReceiveAmount.AgRowFilter = ""
        Me.TxtReceiveAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReceiveAmount.AgSelectedValue = Nothing
        Me.TxtReceiveAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReceiveAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtReceiveAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReceiveAmount.ForeColor = System.Drawing.Color.Blue
        Me.TxtReceiveAmount.Location = New System.Drawing.Point(879, 525)
        Me.TxtReceiveAmount.Name = "TxtReceiveAmount"
        Me.TxtReceiveAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtReceiveAmount.TabIndex = 3
        Me.TxtReceiveAmount.Text = "Receive Amount"
        Me.TxtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(767, 529)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(100, 13)
        Me.Label39.TabIndex = 741
        Me.Label39.Text = "Receive &Amount"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(657, 13)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(10, 7)
        Me.Label36.TabIndex = 14
        Me.Label36.Text = "Ä"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(657, 53)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(10, 7)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Ä"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCity.Location = New System.Drawing.Point(551, 49)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(27, 15)
        Me.lblCity.TabIndex = 16
        Me.lblCity.Text = "City"
        '
        'TxtCityCode
        '
        Me.TxtCityCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtCityCode.AgMandatory = True
        Me.TxtCityCode.AgMasterHelp = False
        Me.TxtCityCode.AgNumberLeftPlaces = 0
        Me.TxtCityCode.AgNumberNegetiveAllow = False
        Me.TxtCityCode.AgNumberRightPlaces = 0
        Me.TxtCityCode.AgPickFromLastValue = False
        Me.TxtCityCode.AgRowFilter = ""
        Me.TxtCityCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCityCode.AgSelectedValue = Nothing
        Me.TxtCityCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCityCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCityCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCityCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCityCode.Location = New System.Drawing.Point(670, 47)
        Me.TxtCityCode.MaxLength = 100
        Me.TxtCityCode.Name = "TxtCityCode"
        Me.TxtCityCode.Size = New System.Drawing.Size(204, 18)
        Me.TxtCityCode.TabIndex = 9
        Me.TxtCityCode.Text = "AgTextBox5"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(551, 9)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(53, 15)
        Me.lblAddress.TabIndex = 15
        Me.lblAddress.Text = "Address"
        '
        'TxtAdd1
        '
        Me.TxtAdd1.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdd1.AgMandatory = True
        Me.TxtAdd1.AgMasterHelp = False
        Me.TxtAdd1.AgNumberLeftPlaces = 0
        Me.TxtAdd1.AgNumberNegetiveAllow = False
        Me.TxtAdd1.AgNumberRightPlaces = 0
        Me.TxtAdd1.AgPickFromLastValue = False
        Me.TxtAdd1.AgRowFilter = ""
        Me.TxtAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd1.AgSelectedValue = Nothing
        Me.TxtAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd1.Location = New System.Drawing.Point(670, 7)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(293, 18)
        Me.TxtAdd1.TabIndex = 7
        Me.TxtAdd1.Text = "TxtAdd1"
        '
        'TxtAdd2
        '
        Me.TxtAdd2.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdd2.AgMandatory = False
        Me.TxtAdd2.AgMasterHelp = False
        Me.TxtAdd2.AgNumberLeftPlaces = 0
        Me.TxtAdd2.AgNumberNegetiveAllow = False
        Me.TxtAdd2.AgNumberRightPlaces = 0
        Me.TxtAdd2.AgPickFromLastValue = False
        Me.TxtAdd2.AgRowFilter = ""
        Me.TxtAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd2.AgSelectedValue = Nothing
        Me.TxtAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd2.Location = New System.Drawing.Point(670, 27)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(293, 18)
        Me.TxtAdd2.TabIndex = 8
        Me.TxtAdd2.Text = "TxtAdd2"
        '
        'TxtMobile
        '
        Me.TxtMobile.AgAllowUserToEnableMasterHelp = False
        Me.TxtMobile.AgMandatory = False
        Me.TxtMobile.AgMasterHelp = False
        Me.TxtMobile.AgNumberLeftPlaces = 0
        Me.TxtMobile.AgNumberNegetiveAllow = False
        Me.TxtMobile.AgNumberRightPlaces = 0
        Me.TxtMobile.AgPickFromLastValue = False
        Me.TxtMobile.AgRowFilter = ""
        Me.TxtMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMobile.AgSelectedValue = Nothing
        Me.TxtMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMobile.Location = New System.Drawing.Point(670, 87)
        Me.TxtMobile.MaxLength = 35
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(204, 18)
        Me.TxtMobile.TabIndex = 11
        Me.TxtMobile.Text = "AgTextBox3"
        '
        'lblMobile
        '
        Me.lblMobile.AutoSize = True
        Me.lblMobile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMobile.Location = New System.Drawing.Point(551, 89)
        Me.lblMobile.Name = "lblMobile"
        Me.lblMobile.Size = New System.Drawing.Size(43, 15)
        Me.lblMobile.TabIndex = 18
        Me.lblMobile.Text = "Mobile"
        '
        'TxtPhone
        '
        Me.TxtPhone.AgAllowUserToEnableMasterHelp = False
        Me.TxtPhone.AgMandatory = False
        Me.TxtPhone.AgMasterHelp = False
        Me.TxtPhone.AgNumberLeftPlaces = 0
        Me.TxtPhone.AgNumberNegetiveAllow = False
        Me.TxtPhone.AgNumberRightPlaces = 0
        Me.TxtPhone.AgPickFromLastValue = False
        Me.TxtPhone.AgRowFilter = ""
        Me.TxtPhone.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPhone.AgSelectedValue = Nothing
        Me.TxtPhone.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPhone.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPhone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPhone.Location = New System.Drawing.Point(670, 67)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(204, 18)
        Me.TxtPhone.TabIndex = 10
        Me.TxtPhone.Text = "AgTextBox4"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhone.Location = New System.Drawing.Point(551, 69)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(43, 15)
        Me.lblPhone.TabIndex = 17
        Me.lblPhone.Text = "Phone"
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
        Me.TxtRemark.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(90, 525)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(492, 19)
        Me.TxtRemark.TabIndex = 2
        Me.TxtRemark.Text = "AgTextBox4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 529)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 1029
        Me.Label12.Text = "&Remark"
        '
        'TxtSalesAc
        '
        Me.TxtSalesAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtSalesAc.AgMandatory = False
        Me.TxtSalesAc.AgMasterHelp = False
        Me.TxtSalesAc.AgNumberLeftPlaces = 0
        Me.TxtSalesAc.AgNumberNegetiveAllow = False
        Me.TxtSalesAc.AgNumberRightPlaces = 0
        Me.TxtSalesAc.AgPickFromLastValue = False
        Me.TxtSalesAc.AgRowFilter = ""
        Me.TxtSalesAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesAc.AgSelectedValue = Nothing
        Me.TxtSalesAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesAc.Location = New System.Drawing.Point(141, 107)
        Me.TxtSalesAc.MaxLength = 0
        Me.TxtSalesAc.Name = "TxtSalesAc"
        Me.TxtSalesAc.Size = New System.Drawing.Size(370, 18)
        Me.TxtSalesAc.TabIndex = 6
        '
        'LblSalesAc
        '
        Me.LblSalesAc.AutoSize = True
        Me.LblSalesAc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalesAc.Location = New System.Drawing.Point(17, 109)
        Me.LblSalesAc.Name = "LblSalesAc"
        Me.LblSalesAc.Size = New System.Drawing.Size(58, 15)
        Me.LblSalesAc.TabIndex = 775
        Me.LblSalesAc.Text = "Sales A/c"
        '
        'FrmProspectusSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtReceiveAmount)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmProspectusSale"
        Me.Text = "Prospectus Sale Entry"
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.TxtReceiveAmount, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.TxtRemark, 0)
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
        Me.PerformLayout()

    End Sub
#End Region

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.ProspectusSale) & ""
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
        Public Shared City As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Session As DataSet = Nothing
        Public Shared Program As DataSet = Nothing
        Public Shared ProcpectusNo As DataSet = Nothing

        Public Shared SalesTaxGroupItem As DataSet = Nothing
        Public Shared SalesAc As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_Sale"

        AglObj = AgL


        LblV_Type.Text = "Sale Type"
        LblV_Date.Text = "Sale Date"
        LblV_No.Text = "Sale No."
        TP1.Text = "Tp1"

        AgL.GridDesign(DGL1)
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
                " From Store_Sale H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$ = " Where 1=1 "

        mCondStr += " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "
        mCondStr += " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        AgL.PubFindQry = "SELECT H.DocId AS SearchCode, " & _
                            " " & AgL.V_No_Field("H.DocId") & " As [" & LblV_No.Text & "], " & _
                            " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " H.PartyName As [" & LblParty.Text & "], " & _
                            " H.PartyMobile As [" & lblMobile.Text & "], " & _
                            " S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Store_Sale H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & _
                            mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, [" & LblParty.Text & "] "

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Item, 120, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 120, 255, Col1ItemDescription, True, False, False)
            .AddAgTextColumn(DGL1, Col1Session, 90, 0, Col1Session, True, True, False)
            .AddAgTextColumn(DGL1, Col1Program, 90, 0, Col1Program, True, True, False)
            .AddAgTextColumn(DGL1, Col1ProcpectusNo, 100, 50, Col1ProcpectusNo, True, False, False)
            .AddAgTextColumn(DGL1, Col1Godown, 80, 0, Col1Godown, True, False, False)
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


        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""
        Dim bStrApprovedDate$ = ""


        mQry = "Update Store_Sale " & _
                " SET " & _
                " 	V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                " 	PartyName = " & AgL.Chk_Text(TxtParty.Text) & ", " & _
                "   PartyAdd1 = " & AgL.Chk_Text(TxtAdd1.Text) & ", " & _
                "   PartyAdd2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", " & _
                "   PartyCityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & "," & _
                "   PartyPhone = " & AgL.Chk_Text(TxtPhone.Text) & ", " & _
                "   PartyMobile = " & AgL.Chk_Text(TxtMobile.Text) & "," & _
                " 	Amount = " & Val(LblValNetAmount.Text) & ", " & _
                " 	NetAmount = " & Val(LblValNetAmount.Text) & ", " & _
                " 	InvoiceAmount = " & Val(LblValNetAmount.Text) & ", " & _
                " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                "   U_AE = 'E', " & _
                "   SaleAc = " & AglObj.Chk_Text(TxtSalesAc.AgSelectedValue) & ", " & _
                " 	Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                " 	ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & " ," & _
                "   ReferenceNo=" & AgL.Chk_Text(TxtReferenceNo.Text) & " " & _
                " WHERE DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


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
            mQry = "DELETE FROM Store_SaleDetail WHERE DocId = '" & mSearchCode & "'"
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

                mQry = "INSERT INTO dbo.Store_SaleDetail (" & _
                        " DocId, Sr, Uid, Item, ItemDescription,  Godown,  Qty, Rate, Amount, NetAmount," & _
                        " SalesTaxGroupItem, Remark, Session, Programme,ProspectusNo) " & _
                        " VALUES (" & AglObj.Chk_Text(mSearchCode) & ", " & bIntSr & ", " & AglObj.Chk_Text(bStrLineUid) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Godown, bIntI)) & ", " & _
                        " " & Val(DGL1.Item(Col1Qty, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, bIntI).Value) & ", " & _
                        " " & Val(LblValNetAmount.Text) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1SalesTaxGroupItem, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & "," & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Session, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Program, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ProcpectusNo, bIntI).Value) & " " & _
                        " )"
                AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)


                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next


        '============================================================================================
        '========================< Save Data in Account >============================================
        '===============================< Start >====================================================
        '============================================================================================
        AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtSalesAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
        AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
        If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")

        If ManageAccount Then Call AccountPosting()

        AgL.PubObjFrmPaymentDetail = Nothing



        '============================================================================================
        '========================< Save Data in Account >============================================
        '===============================< Edn >======================================================
        '============================================================================================


    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer = 0, J As Integer = 0
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim GcnRead As SqlClient.SqlConnection


        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        mCommonNarr = "Being Amount Received From " & TxtParty.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)


        I = 0
        ReDim Preserve LedgAry(I)
        With PaymentRec
            If .CashAmount > 0 Then
                bContraSub = .CashAc

            ElseIf .BankAmount > 0 Then
                bContraSub = .BankAc

            ElseIf .BankAmount2 > 0 Then
                bContraSub = .BankAc2

            ElseIf .BankAmount3 > 0 Then
                bContraSub = .BankAc3

            ElseIf .CardAmount > 0 Then
                bContraSub = .CardAc

            ElseIf .AcTransferAmount > 0 Then
                bContraSub = .AcTransferBankAc
            End If
        End With


        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = TxtSalesAc.AgSelectedValue
        LedgAry(I).ContraSub = bContraSub
        LedgAry(I).AmtDr = 0
        LedgAry(I).AmtCr = Val(LblValNetAmount.Text)
        LedgAry(I).Narration = mNarr


        mCommonNarr = ""
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr, False) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If


        GcnRead.Close()
        GcnRead.Dispose()
    End Function

    Private Sub ProcSaveStockHeader(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        If AglObj.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = "INSERT INTO dbo.Store_StockHeader (DocId,  PreparedBy, U_EntDt, U_AE)" & _
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
                        " ReferenceNo,  Item, ItemDescription, ProspectusNo, Godown, Qty_Rec, Qty_Iss, " & _
                        " Rate, Amount, NetAmount, Remark, SalesTaxGroupItem,Session,Programme) " & _
                        " VALUES (" & _
                        " " & AglObj.Chk_Text(mSearchCode) & ", " & Sr & ", " & AglObj.Chk_Text(bStrLineUid) & ", " & _
                        " " & AglObj.Chk_Text(TxtDivision.AgSelectedValue) & ",  " & _
                        " " & AglObj.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AglObj.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AglObj.Chk_Text(LblPrefix.Text) & ", " & _
                        " " & Val(TxtV_No.Text) & ", " & _
                        " " & AglObj.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AglObj.Chk_Text(TxtReferenceNo.Text) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, mGridRow)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, mGridRow).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ProcpectusNo, mGridRow).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Godown, mGridRow)) & ", " & _
                        " " & bDblQty_Rec & ", " & _
                        " " & bDblQty_Iss & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, mGridRow).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, mGridRow).Value) & ", " & _
                        " " & Val(LblValNetAmount.Text) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, mGridRow).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mGridRow)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Session, mGridRow)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Program, mGridRow)) & " " & _
                        " )"

        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
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
        Dim bIntI As Integer = 0
        '============================================================================================
        '======================< Delete Account Data >=================================================
        '============================< Start >=======================================================
        '============================================================================================
        AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtSalesAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
        AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
        AgL.PubObjFrmPaymentDetail = Nothing

        AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)
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
        mQry = "Delete From Store_SaleDetail Where DocId = '" & SearchCode & "'"
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_Sale Where DocId = '" & SearchCode & "' "
        AglObj.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet
        Dim DtTemp As DataTable = Nothing

        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
            " From Store_Sale H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtParty.Text = AgL.XNull(.Rows(0)("PartyName"))
                TxtAdd1.Text = AgL.XNull(.Rows(0)("PartyAdd1"))
                TxtAdd2.Text = AgL.XNull(.Rows(0)("PartyAdd2"))
                TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("PartyCityCode"))
                TxtPhone.Text = AgL.XNull(.Rows(0)("PartyPhone"))
                TxtMobile.Text = AgL.XNull(.Rows(0)("PartyMobile"))

                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("NetAmount")), "0.00")
                TxtSalesAc.AgSelectedValue = AglObj.XNull(.Rows(0)("SaleAc"))

                ''Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtSalesAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                AgL.PubObjFrmPaymentDetail = Nothing

                mQry = "Select L.* " & _
                        " From Store_SaleDetail L With (NoLock) " & _
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
                            DGL1.AgSelectedValue(Col1SalesTaxGroupItem, bIntI) = AglObj.XNull(.Rows(bIntI)("SalesTaxGroupItem"))

                            DGL1.Item(Col1Qty, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Qty")), "0.000")
                            DGL1.Item(Col1Rate, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Rate")), "0.00")
                            DGL1.Item(Col1Amount, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Amount")), "0.00")

                            DGL1.Item(Col1Remark, bIntI).Value = AglObj.XNull(.Rows(bIntI)("Remark"))
                            DGL1.AgSelectedValue(Col1Session, bIntI) = AglObj.XNull(.Rows(bIntI)("Session"))
                            DGL1.AgSelectedValue(Col1Program, bIntI) = AglObj.XNull(.Rows(bIntI)("Programme"))
                            DGL1.Item(Col1ProcpectusNo, bIntI).Value = AglObj.XNull(.Rows(bIntI)("ProspectusNo"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AglObj.VNull(.Rows(bIntI)("Sr")), bIntI)

                        Next bIntI
                    End If
                End With
            End If
        End With
        Call Calculation()
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

        Topctrl1.tPrn = False


        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)

        Topctrl1.ChangeAgGridState(DGL1, False)
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AgL.PubUserName

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AgL.PubLoginDate
        End If

    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        '<Executbale Code>
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            mQry = "SELECT I.Code, I.Description AS [Item Name], I.Unit, " & _
                    " I.DisplayName AS [Display Name], I.ManualCode, " & _
                    " P.Prefix AS [Prefix], P.Suffix AS [Suffix], " & _
                    " I.MasterType,P.Session,P.Programme, " & _
                    " I.PurchaseRate,I.SaleRate , " & _
                    " I.SalesTaxPostingGroup " & _
                    " FROM Store_Item I  With (NoLock) " & _
                    " LEFT JOIN Enquiry_Prospectus P  With (NoLock) ON P.Code = I.Code  " & _
                    " Where I.MasterType = '" & ClsMain.ItemType.Prospectus & "'" & _
                    " ORDER BY I.Description "
            HelpDataSet.Item = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT G.Code, G.Description AS Name FROM Store_Godown G  With (NoLock) ORDER BY G.Description "
            HelpDataSet.Godown = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                    " IsNull(P.Active,0) AS Active " & _
                    " FROM PostingGroupSalesTaxItem P With (NoLock)" & _
                    " Order By P.Description "
            HelpDataSet.SalesTaxGroupItem = AglObj.FillData(mQry, AglObj.GcnRead)


            mQry = "Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, " & _
                             " Sg.DispName AS PartyDispName, Sg.ManualCode, Sg.Nature, " & _
                             " IsNull(MasterType,'') As MasterType ,  " & _
                             " Sg.SalesTaxPostingGroup " & _
                             " From SubGroup Sg With (NoLock) " & _
                             " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                             " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                             " Where 1=1 And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Sg.Site_Code", AglObj.PubSiteCode, "Sg.CommonAc") & " " & _
                             " And Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSales & ") = " & AglObj.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSales) & " " & _
                             " Order By Name "
            HelpDataSet.SalesAc = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT C.CityCode Code, C.CityName AS City, S.ShortName AS State, C1.Name AS Country " & _
             " FROM City C With (NoLock) " & _
             " LEFT JOIN State S With (NoLock) ON C.State_Code = S.State_Code " & _
             " LEFT JOIN Country C1 With (NoLock) ON S.CountryCode = C1.Code " & _
             " ORDER BY C1.Name, C.CityName "
            HelpDataSet.City = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "SELECT S.Code, S.ManualCode AS Session " & _
               " FROM Sch_Session S With (NoLock) " & _
               " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
               " Order By S.ManualCode "
            HelpDataSet.Session = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "SELECT P.Code, P.ManualCode AS Programme " & _
                    " FROM Sch_Programme P With (NoLock) " & _
                    " WHERE " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By P.ManualCode "
            HelpDataSet.Program = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "SELECT Distinct P.ProspectusNo AS Code, P.ProspectusNo AS ProspectusNo" & _
                 " FROM Store_Stock P With (NoLock) where P.ProspectusNo IS Not Null " & _
                 " Order By P.ProspectusNo "
            HelpDataSet.ProcpectusNo = AglObj.FillData(mQry, AglObj.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtCityCode.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.City.Copy
        TxtSalesAc.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.SalesAc.Copy

        DGL1.AgHelpDataSet(Col1SalesTaxGroupItem, 1) = HelpDataSet.SalesTaxGroupItem.Copy

        DGL1.AgHelpDataSet(Col1Item, 11) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Session) = HelpDataSet.Session.Copy
        DGL1.AgHelpDataSet(Col1Program) = HelpDataSet.Program.Copy
        DGL1.AgHelpDataSet(Col1Godown) = HelpDataSet.Godown.Copy
        'DGL1.AgHelpDataSet(Col1ProcpectusNo) = HelpDataSet.ProcpectusNo.Copy

    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim bIntI As Integer = 0

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
                LblValNetAmount.Text = Val(LblValNetAmount.Text) + Val(DGL1.Item(Col1Amount, bIntI).Value)
            End If
        Next


        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")
        LblValNetAmount.Text = Format(Val(LblValNetAmount.Text), "0.000")

    End Sub
    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtParty, LblParty.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function

            If Val(TxtReceiveAmount.Text) <> Val(LblValNetAmount.Text) Then
                MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(LblValNetAmount.Text) & """")
                TxtReceiveAmount.Focus() : Exit Function
            End If

            I = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1ProcpectusNo, I).Value.ToString.Trim <> "" Then
                        mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                         " FROM Store_SaleDetail H With (NoLock) " & _
                         " WHERE H.Session=" & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Session, I)) & " and  H.ProspectusNo = " & AglObj.Chk_Text(DGL1.Item(Col1ProcpectusNo, I).Value) & " " & _
                         " AND " & IIf(AglObj.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AglObj.Chk_Text(mSearchCode) & " ") & " "
                        If AglObj.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                            MsgBox(DGL1.Item(Col1ProcpectusNo, I).Value & " Already Sold !...")
                            DGL1.CurrentCell = DGL1(Col1ProcpectusNo, I) : DGL1.Focus() : Exit Function
                        End If
                    End If
                Next
            End With

          

            If AgL.RequiredField(TxtReceiveAmount, "Receive Amount", True) Then Exit Function

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_Sale H With (NoLock) " & _
                        " WHERE H.ReferenceNo = " & AglObj.Chk_Text(TxtReferenceNo.Text) & " " & _
                        " And H.V_Type in (" & EntryNCatList & ")" & _
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
        PaymentRec = Nothing
        mBlnIsApproved = False
        mSearchCode = ""
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtParty.Enter
        Try
            Select Case sender.name
                Case TxtParty.Name
                    TxtParty.AgRowFilter = " [Is Active] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtParty.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()

            End Select


            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AgL.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
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

        End Select

    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtReceiveAmount.Enabled = False
        End If
    End Sub
    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1SalesTaxGroupItem
                    DGL1.AgRowFilter(mColumnIndex) = " Active <> 0 "

                Case Col1Item
                    DGL1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Prospectus & "' "

             
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                    Case Col1Item
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            DGL1.Item(Col1Rate, mRowIndex).Value = ""
                            DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AglObj.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.Item(Col1Rate, mRowIndex).Value = Format(AglObj.VNull(DrTemp(0)("SaleRate")), "0.00")
                                DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = AglObj.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                            End If
                            DrTemp = Nothing
                        End If

                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Try
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                'Case ColumnIndex
                '<Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AgL.FSetSNo(sender, 0)

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
            If AgL.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
                And AgL.XNull(LblPrefix.Text).ToString.Trim <> "" _
                And Val(TxtV_No.Text) > 0 Then

                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
                LblReferenceNo.Tag = TxtReferenceNo.Text
            End If
        End If
    End Sub

    Private Sub FrmProspectusSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If Me.ActiveControl IsNot Nothing Then

            If e.KeyCode <> Keys.Return And Me.ActiveControl.Name = TxtReceiveAmount.Name Then
                If AgL.StrCmp(LblV_Type.Tag, ClsMain.Temp_NCat.ProspectusSale) And LblV_Type.Tag.ToString.Trim <> "" Then
                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtSalesAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    'End Code
                    AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                    AgL.PubObjFrmPaymentDetail.ShowDialog()
                    PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                    TxtReceiveAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

                    If Val(TxtReceiveAmount.Text) <> Val(LblValNetAmount.Text) Then
                        MsgBox("Receive Amount Is Not Equal To '" & Val(LblValNetAmount.Text) & "' ")
                    End If

                    Call Calculation()
                    AgL.PubObjFrmPaymentDetail = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim DrTemp As DataRow() = Nothing
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection

        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name

                Case Col1ProcpectusNo
                    mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                         " FROM Store_SaleDetail H With (NoLock) " & _
                         " WHERE H.Session=" & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Session, mRowIndex)) & " and  H.ProspectusNo = " & AglObj.Chk_Text(DGL1.Item(Col1ProcpectusNo, mRowIndex).Value) & " " & _
                         " AND " & IIf(AglObj.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AglObj.Chk_Text(mSearchCode) & " ") & " "
                    If AglObj.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                        MsgBox(DGL1.Item(Col1ProcpectusNo, mRowIndex).Value & " Already Sold !...")
                        DGL1.CurrentCell = DGL1(Col1ProcpectusNo, mRowIndex) : DGL1.Focus()
                        Exit Sub
                    End If

                Case Col1Item

                    DrTemp = DGL1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Item, mRowIndex)) & "")
                    If DrTemp.Length > 0 Then
                        DGL1.AgSelectedValue(Col1Session, mRowIndex) = AgL.XNull(DrTemp(0)("Session"))
                        DGL1.AgSelectedValue(Col1Program, mRowIndex) = AgL.XNull(DrTemp(0)("Programme"))
                    End If


            End Select
         
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
