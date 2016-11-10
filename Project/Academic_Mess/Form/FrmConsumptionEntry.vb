Public Class FrmConsumptionEntry
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
    Protected Const Col1Qty As String = "Quantity"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"


    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Protected Const Col2Tick As String = "Tick"
    Protected Const Col2Shift As String = "Shift"
    Protected Const Col2Member As String = "Member"
    Protected Const Col2Extra As String = "Extra"
    Protected Const Col2Total As String = "Total"
    Protected Const Col2TempExtra As String = "Temp Extra"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Dim _BlnManageStock As Boolean = True
    Dim _eQuantityType As eQuantityType = eQuantityType.Issue

    Public Enum eQuantityType
        Issue
        Receive
    End Enum

    Public Class AgCalGridCharges
        Public Const GrossAmount As String = "GAMT"
        Public Const TotalLineNetAmount As String = "LNAmt"
        Public Const NetSubTotal As String = "NSTot"
        Public Const RoundOff As String = "ROff"
    End Class

#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel


    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter2 As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalMember As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalMember As System.Windows.Forms.Label
    Protected WithEvents LblValTotalExtra As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalExtra As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblTextTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Friend WithEvents BtnFillShitData As System.Windows.Forms.Button
    Protected WithEvents LblValTotalPerson As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalPerson As System.Windows.Forms.Label
    Protected WithEvents LblValGrossAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextGrossAmount As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.PnlFooter2 = New System.Windows.Forms.Panel
        Me.LblValTotalPerson = New System.Windows.Forms.Label
        Me.LblTextTotalPerson = New System.Windows.Forms.Label
        Me.LblValTotalMember = New System.Windows.Forms.Label
        Me.LblTextTotalMember = New System.Windows.Forms.Label
        Me.LblValTotalExtra = New System.Windows.Forms.Label
        Me.LblTextTotalExtra = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblTextTotalQty = New System.Windows.Forms.Label
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.BtnFillShitData = New System.Windows.Forms.Button
        Me.LblValGrossAmount = New System.Windows.Forms.Label
        Me.LblTextGrossAmount = New System.Windows.Forms.Label
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter2.SuspendLayout()
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
        Me.TxtDocId.Location = New System.Drawing.Point(934, 3)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(495, 50)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(601, 49)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(329, 55)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(221, 50)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(329, 35)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(345, 49)
        Me.TxtV_Date.Size = New System.Drawing.Size(129, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(221, 30)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(345, 29)
        Me.TxtV_Type.Size = New System.Drawing.Size(350, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(329, 15)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(221, 10)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(345, 9)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(887, 5)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(562, 50)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 155)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 127)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 5
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
        Me.TxtRemark.Location = New System.Drawing.Point(345, 89)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 6
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(221, 91)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(437, 205)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(473, 318)
        Me.Pnl1.TabIndex = 4
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(329, 76)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(345, 69)
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
        Me.LblReferenceNo.Location = New System.Drawing.Point(221, 69)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(74, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Manual No."
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(654, 577)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(22, 23)
        Me.PnlCShowGrid2.TabIndex = 939
        Me.PnlCShowGrid2.Visible = False
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(682, 577)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(22, 23)
        Me.PnlCShowGrid.TabIndex = 2
        Me.PnlCShowGrid.Visible = False
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(626, 577)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(22, 23)
        Me.PnlCalcGrid.TabIndex = 938
        Me.PnlCalcGrid.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(434, 182)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(121, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Consumption Detail:"
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
        Me.TxtStructure.Location = New System.Drawing.Point(595, 69)
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
        Me.Label25.Location = New System.Drawing.Point(528, 69)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 769
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(87, 208)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(301, 174)
        Me.Pnl2.TabIndex = 2
        '
        'PnlFooter2
        '
        Me.PnlFooter2.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter2.Controls.Add(Me.LblValTotalPerson)
        Me.PnlFooter2.Controls.Add(Me.LblTextTotalPerson)
        Me.PnlFooter2.Controls.Add(Me.LblValTotalMember)
        Me.PnlFooter2.Controls.Add(Me.LblTextTotalMember)
        Me.PnlFooter2.Controls.Add(Me.LblValTotalExtra)
        Me.PnlFooter2.Controls.Add(Me.LblTextTotalExtra)
        Me.PnlFooter2.Location = New System.Drawing.Point(87, 380)
        Me.PnlFooter2.Name = "PnlFooter2"
        Me.PnlFooter2.Size = New System.Drawing.Size(301, 24)
        Me.PnlFooter2.TabIndex = 696
        '
        'LblValTotalPerson
        '
        Me.LblValTotalPerson.AutoSize = True
        Me.LblValTotalPerson.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalPerson.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalPerson.Location = New System.Drawing.Point(265, 4)
        Me.LblValTotalPerson.Name = "LblValTotalPerson"
        Me.LblValTotalPerson.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalPerson.TabIndex = 670
        Me.LblValTotalPerson.Text = "."
        Me.LblValTotalPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalPerson
        '
        Me.LblTextTotalPerson.AutoSize = True
        Me.LblTextTotalPerson.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalPerson.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalPerson.Location = New System.Drawing.Point(217, 5)
        Me.LblTextTotalPerson.Name = "LblTextTotalPerson"
        Me.LblTextTotalPerson.Size = New System.Drawing.Size(48, 16)
        Me.LblTextTotalPerson.TabIndex = 669
        Me.LblTextTotalPerson.Text = "Total :"
        '
        'LblValTotalMember
        '
        Me.LblValTotalMember.AutoSize = True
        Me.LblValTotalMember.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalMember.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalMember.Location = New System.Drawing.Point(75, 3)
        Me.LblValTotalMember.Name = "LblValTotalMember"
        Me.LblValTotalMember.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalMember.TabIndex = 668
        Me.LblValTotalMember.Text = "."
        Me.LblValTotalMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalMember
        '
        Me.LblTextTotalMember.AutoSize = True
        Me.LblTextTotalMember.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalMember.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalMember.Location = New System.Drawing.Point(5, 3)
        Me.LblTextTotalMember.Name = "LblTextTotalMember"
        Me.LblTextTotalMember.Size = New System.Drawing.Size(72, 16)
        Me.LblTextTotalMember.TabIndex = 667
        Me.LblTextTotalMember.Text = "Member  :"
        '
        'LblValTotalExtra
        '
        Me.LblValTotalExtra.AutoSize = True
        Me.LblValTotalExtra.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalExtra.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalExtra.Location = New System.Drawing.Point(170, 3)
        Me.LblValTotalExtra.Name = "LblValTotalExtra"
        Me.LblValTotalExtra.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalExtra.TabIndex = 662
        Me.LblValTotalExtra.Text = "."
        Me.LblValTotalExtra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalExtra
        '
        Me.LblTextTotalExtra.AutoSize = True
        Me.LblTextTotalExtra.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalExtra.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalExtra.Location = New System.Drawing.Point(119, 4)
        Me.LblTextTotalExtra.Name = "LblTextTotalExtra"
        Me.LblTextTotalExtra.Size = New System.Drawing.Size(53, 16)
        Me.LblTextTotalExtra.TabIndex = 661
        Me.LblTextTotalExtra.Text = "Exttra :"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnFill.Location = New System.Drawing.Point(807, 180)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 25)
        Me.BtnFill.TabIndex = 3
        Me.BtnFill.TabStop = False
        Me.BtnFill.Text = "Fill Data"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblTextTotalQty
        '
        Me.LblTextTotalQty.AutoSize = True
        Me.LblTextTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalQty.Location = New System.Drawing.Point(292, 4)
        Me.LblTextTotalQty.Name = "LblTextTotalQty"
        Me.LblTextTotalQty.Size = New System.Drawing.Size(89, 16)
        Me.LblTextTotalQty.TabIndex = 667
        Me.LblTextTotalQty.Text = "Total Qty.    :"
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(381, 4)
        Me.LblValTotalQty.Name = "LblValTotalQty"
        Me.LblValTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQty.TabIndex = 668
        Me.LblValTotalQty.Text = "."
        Me.LblValTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValGrossAmount)
        Me.PnlFooter.Controls.Add(Me.LblTextGrossAmount)
        Me.PnlFooter.Controls.Add(Me.LblValTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalQty)
        Me.PnlFooter.Location = New System.Drawing.Point(437, 522)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(473, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(87, 185)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(97, 20)
        Me.LinkLabel2.TabIndex = 941
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Shift Detail :"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFillShitData
        '
        Me.BtnFillShitData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillShitData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillShitData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnFillShitData.Location = New System.Drawing.Point(288, 182)
        Me.BtnFillShitData.Name = "BtnFillShitData"
        Me.BtnFillShitData.Size = New System.Drawing.Size(100, 25)
        Me.BtnFillShitData.TabIndex = 1
        Me.BtnFillShitData.TabStop = False
        Me.BtnFillShitData.Text = "Fill Person"
        Me.BtnFillShitData.UseVisualStyleBackColor = True
        '
        'LblValGrossAmount
        '
        Me.LblValGrossAmount.AutoSize = True
        Me.LblValGrossAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValGrossAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValGrossAmount.Location = New System.Drawing.Point(169, 4)
        Me.LblValGrossAmount.Name = "LblValGrossAmount"
        Me.LblValGrossAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblValGrossAmount.TabIndex = 670
        Me.LblValGrossAmount.Text = "."
        Me.LblValGrossAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblValGrossAmount.Visible = False
        '
        'LblTextGrossAmount
        '
        Me.LblTextGrossAmount.AutoSize = True
        Me.LblTextGrossAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextGrossAmount.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextGrossAmount.Location = New System.Drawing.Point(67, 4)
        Me.LblTextGrossAmount.Name = "LblTextGrossAmount"
        Me.LblTextGrossAmount.Size = New System.Drawing.Size(101, 16)
        Me.LblTextGrossAmount.TabIndex = 669
        Me.LblTextGrossAmount.Text = "Total Amount :"
        Me.LblTextGrossAmount.Visible = False
        '
        'FrmConsumptionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.BtnFillShitData)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Pnl2)
        Me.Controls.Add(Me.PnlFooter2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmConsumptionEntry"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.PnlFooter2, 0)
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
        Me.Controls.SetChildIndex(Me.BtnFillShitData, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.BtnFill, 0)
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
        Me.PnlFooter2.ResumeLayout(False)
        Me.PnlFooter2.PerformLayout()
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.MessConsumption) & ""
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


    Public Class HelpDataSet
        Public Shared Shift As DataSet = Nothing

        Public Shared Item As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing

        Public Shared AgStructure As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Mess_Consumption"
        AglObj = AgL

        LblV_Type.Text = "Consumption Type"
        LblV_Date.Text = "Consumption Date"
        LblV_No.Text = "Consumption No."
        TP1.Text = "Consumption Detail"

        AgL.GridDesign(DGL1)
        AgL.GridDesign(DGL2)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)

        AgCShowGrid1.Visible = False
        AgCShowGrid2.Visible = False

        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False

    End Sub

    Public Sub Form_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim mCondStr$

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
                " From Mess_Consumption H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$ = " Where 1=1 "
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

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

        AgL.PubFindQry = "SELECT H.DocId AS SearchCode, H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " " & AgL.V_No_Field("H.DocId") & " As [" & LblV_No.Text & "]," & _
                            " Vt.Description  As [" & LblV_Type.Text & "], " & _
                            " " & AgL.ConvertDateTimeField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.TotalQty, H.InvoiceAmount, H.Remark, S.Name AS [Site Name], H.Div_Code, " & _
                            " H.PreparedBy As [Entry By], " & AgL.ConvertDateTimeField("H.U_EntDt") & " As [Entry Date], " & _
                            " H.ModifiedBy As [Edit By], " & AgL.ConvertDateTimeField("H.Edit_Date") & " As [Edit Date] " & _
                            " FROM dbo.Mess_Consumption H WITH (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S WITH (NoLock) ON S.Code = H.Site_Code  " & mCondStr

        AgL.PubFindQryOrdBy = "Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, SearchCode "

        If GcnRead IsNot Nothing Then GcnRead.Dispose()

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Item, 250, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 120, 255, Col1ItemDescription, False, False, False)
            .AddAgTextColumn(DGL1, Col1Unit, 80, 0, Col1Unit, True, True, False)
            .AddAgTextColumn(DGL1, Col1BatchNo, 80, 0, Col1BatchNo, False, False, False)
            .AddAgTextColumn(DGL1, Col1Godown, 80, 0, Col1Godown, False, False, False)
            .AddAgNumberColumn(DGL1, Col1Qty, 80, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Rate, 60, 8, 2, False, Col1Rate, False, False, True)
            .AddAgNumberColumn(DGL1, Col1Amount, 80, 8, 2, False, Col1Amount, False, True, True)
            .AddAgTextColumn(DGL1, Col1Remark, 80, 255, Col1Remark, False, False, False)
            .AddAgTextColumn(DGL1, Col1UID, 80, 0, Col1UID, False, True, False)
            .AddAgTextColumn(DGL1, Col1TempUID, 80, 0, Col1TempUID, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))


        DGL2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL2, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgCheckColumn(DGL2, Col2Tick, 50, Col2Tick, True)
            .AddAgTextColumn(DGL2, Col2Shift, 120, 0, Col2Shift, True, True, False)
            .AddAgNumberColumn(DGL2, Col2Member, 60, 8, 0, False, Col2Member, True, True, True)
            .AddAgNumberColumn(DGL2, Col2Extra, 60, 8, 0, False, Col2Extra, True, False, True)
            .AddAgNumberColumn(DGL2, Col2Total, 70, 8, 0, False, Col2Total, True, True, True)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.EnableHeadersVisualStyles = False
        DGL2.AgSkipReadOnlyColumns = True
        DGL2.Anchor = AnchorStyles.None
        PnlFooter2.Anchor = DGL2.Anchor
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False
        Topctrl1.ChangeAgGridState(DGL2, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        If AgL.VNull(DtMess_Enviro.Rows(0)("IsShiftAttendance")) Then
            DGL2.Columns(Col2Shift).Visible = True
            DGL2.Columns(Col2Shift).Width = 120
        Else
            DGL2.Columns(Col2Shift).Visible = False
            DGL2.Columns(Col2Shift).Width = 170
        End If


        AgCalcGrid1.Ini_Grid(mSearchCode)

        AgCalcGrid1.AgFixedRows = 0

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
        AgCalcGrid1.Visible = False

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""

        mQry = "UPDATE dbo.Mess_Consumption " & _
                " SET " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " TotalMember = " & Val(LblValTotalMember.Text) & ", " & _
                " TotalExtra = " & Val(LblValTotalExtra.Text) & ", " & _
                " TotalPerson = " & Val(LblValTotalPerson.Text) & ", " & _
                " TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                " GrossAmount = " & Val(LblValGrossAmount.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " WHERE DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(SearchCode, Conn, Cmd)

        '============================================================================================
        '===================< Save Data in Stock Header Table >======================================
        '===============================< Start >====================================================
        '============================================================================================
        If ManageStock Then Call ProcSaveStockHeader(SearchCode, Conn, Cmd)
        '============================================================================================
        '===================< Save Data in Stock Header Table >======================================
        '===============================< Edn >======================================================
        '============================================================================================

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Mess_Consumption1 WHERE DocId = '" & SearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                bIntSr += 1

                If AgL.XNull(DGL1.Item(Col1TempUID, bIntI).Value).ToString.Trim = "" Then
                    If AgL.XNull(DGL1.Item(Col1UID, bIntI).Value).ToString.Trim = "" Then
                        DGL1.Item(Col1UID, bIntI).Value = AgL.GetGUID(GcnRead).ToString
                    End If
                End If

                bStrLineUid = DGL1.Item(Col1UID, bIntI).Value


                mQry = "INSERT INTO dbo.Mess_Consumption1 (" & _
                        " DocId, Sr, UID, Item, ItemDescription, Unit, BatchNo, Godown, Qty, Rate, Amount, Remark) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & AgL.Chk_Text(bStrLineUid) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Unit, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1BatchNo, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Godown, bIntI)) & ", " & _
                        " " & Val(DGL1.Item(Col1Qty, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Mess_Consumption2 WHERE DocId = '" & SearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL2.RowCount - 1
            If DGL2.Item(Col2Shift, bIntI).Value <> "" _
                And AgL.StrCmp(DGL2.Item(Col2Tick, bIntI).Value, AgLibrary.ClsConstant.StrCheckedValue) Then

                bIntSr += 1

                mQry = "INSERT INTO dbo.Mess_Consumption2 (" & _
                        " DocId, Sr, Shift, Member, Extra, Total) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL2.AgSelectedValue(Col2Shift, bIntI)) & ", " & _
                        " " & Val(DGL2.Item(Col2Member, bIntI).Value) & ", " & _
                        " " & Val(DGL2.Item(Col2Extra, bIntI).Value) & ", " & _
                        " " & Val(DGL2.Item(Col2Total, bIntI).Value) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next

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
        AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, SearchCode)
        '============================================================================================
        '======================< Delete Account Data >=================================================
        '============================< End >=======================================================
        '============================================================================================

        '============================================================================================
        '======================< Delete Stock Data >=================================================
        '============================< Start >=======================================================
        '============================================================================================
        mQry = "DELETE FROM Store_Stock WHERE DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "DELETE FROM Store_StockHeader WHERE DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '============================================================================================
        '======================< Delete Stock Data >=================================================
        '============================< End >=======================================================
        '============================================================================================

        mQry = "Delete From Mess_Consumption1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Mess_Consumption Where DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet
        Dim DtTemp As DataTable = Nothing

        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
            " From Mess_Consumption H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = AgStructure.ClsMain.EntryPointType.Main
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                LblValTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")
                LblValTotalMember.Text = AgL.VNull(.Rows(0)("TotalMember"))
                LblValTotalExtra.Text = AgL.VNull(.Rows(0)("TotalExtra"))
                LblValTotalPerson.Text = AgL.VNull(.Rows(0)("TotalPerson"))
                BtnFill.Tag = AgL.VNull(.Rows(0)("TotalPerson"))

                LblValGrossAmount.Text = AgL.VNull(.Rows(0)("GrossAmount"))


                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                mQry = "Select L.* " & _
                        " From Mess_Consumption1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.Item(Col1UID, bIntI).Value = AgL.XNull(.Rows(bIntI)("UID").ToString)
                            DGL1.Item(Col1TempUID, bIntI).Value = AgL.XNull(.Rows(bIntI)("UID").ToString)

                            DGL1.AgSelectedValue(Col1Item, bIntI) = AgL.XNull(.Rows(bIntI)("Item"))
                            DGL1.Item(Col1ItemDescription, bIntI).Value = AgL.XNull(.Rows(bIntI)("ItemDescription"))
                            DGL1.AgSelectedValue(Col1Godown, bIntI) = AgL.XNull(.Rows(bIntI)("Godown"))
                            DGL1.AgSelectedValue(Col1Unit, bIntI) = AgL.XNull(.Rows(bIntI)("Unit"))

                            DGL1.Item(Col1Qty, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Qty")), "0.000")
                            DGL1.Item(Col1Rate, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Rate")), "0.00")
                            DGL1.Item(Col1Amount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Amount")), "0.00")
                            DGL1.Item(Col1BatchNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("BatchNo"))
                            DGL1.Item(Col1Remark, bIntI).Value = AgL.XNull(.Rows(bIntI)("Remark"))


                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)

                        Next bIntI
                    End If
                End With
                If DtTemp IsNot Nothing Then DtTemp.Dispose()


                mQry = "Select L.* " & _
                        " From Mess_Consumption2 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                With DtTemp
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(ColSNo, bIntI).Value = DGL2.Rows.Count


                            DGL2.Item(Col2Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue
                            DGL2.AgSelectedValue(Col2Shift, bIntI) = AgL.XNull(.Rows(bIntI)("Shift"))
                            DGL2.Item(Col2Member, bIntI).Value = AgL.VNull(.Rows(bIntI)("Member"))
                            DGL2.Item(Col2Extra, bIntI).Value = AgL.VNull(.Rows(bIntI)("Extra"))
                            DGL2.Item(Col2Total, bIntI).Value = AgL.VNull(.Rows(bIntI)("Total"))

                        Next bIntI
                    End If
                End With
                If DtTemp IsNot Nothing Then DtTemp.Dispose()


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

        Topctrl1.tPrn = False


        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)

        Topctrl1.ChangeAgGridState(DGL1, False)
        AgCalcGrid1.FrmType = AgStructure.ClsMain.EntryPointType.Main
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AgL.PubUserName
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            mQry = "SELECT Code, Description  FROM Structure With (NoLock)  ORDER BY Description "
            HelpDataSet.AgStructure = AgL.FillData(mQry, GcnRead)

            mQry = "SELECT U.Code AS Code, U.Code AS Name FROM Store_Unit U With (NoLock)  ORDER BY U.Code"
            HelpDataSet.Unit = AgL.FillData(mQry, GcnRead)

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
            HelpDataSet.Item = AgL.FillData(mQry, GcnRead)

            mQry = "SELECT G.Code, G.Description AS Name FROM Store_Godown G  With (NoLock) ORDER BY G.Description "
            HelpDataSet.Godown = AgL.FillData(mQry, GcnRead)

            mQry = "SELECT W.Code , W.Code  FROM Mess_Shift W ORDER BY W.Code "
            HelpDataSet.Shift = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtStructure.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.AgStructure.Copy

        DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Unit) = HelpDataSet.Unit.Copy
        DGL1.AgHelpDataSet(Col1Godown) = HelpDataSet.Godown.Copy


        DGL2.AgHelpDataSet(Col2Shift, 0) = HelpDataSet.Shift.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim bIntI As Integer = 0

        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        LblValTotalQty.Text = "" : LblValGrossAmount.Text = ""
        LblValTotalMember.Text = "" : LblValTotalExtra.Text = "" : LblValTotalPerson.Text = ""

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
            If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""
            If DGL1.Item(Col1Rate, bIntI).Value Is Nothing Then DGL1.Item(Col1Rate, bIntI).Value = ""
            If DGL1.Item(Col1Amount, bIntI).Value Is Nothing Then DGL1.Item(Col1Amount, bIntI).Value = ""

            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                DGL1.Item(Col1Amount, bIntI).Value = Format(Val(DGL1.Item(Col1Qty, bIntI).Value) * Val(DGL1.Item(Col1Rate, bIntI).Value), "0.00")


                LblValTotalQty.Text = Val(LblValTotalQty.Text) + Val(DGL1.Item(Col1Qty, bIntI).Value)
                LblValGrossAmount.Text = Val(LblValGrossAmount.Text) + Val(DGL1.Item(Col1Amount, bIntI).Value)
            End If
        Next


        For bIntI = 0 To DGL2.RowCount - 1
            If DGL2.Item(Col2Shift, bIntI).Value Is Nothing Then DGL2.Item(Col2Shift, bIntI).Value = ""
            If DGL2.Item(Col2Member, bIntI).Value Is Nothing Then DGL2.Item(Col2Member, bIntI).Value = ""
            If DGL2.Item(Col2Extra, bIntI).Value Is Nothing Then DGL2.Item(Col2Extra, bIntI).Value = ""
            If DGL2.Item(Col2Total, bIntI).Value Is Nothing Then DGL2.Item(Col2Total, bIntI).Value = ""

            If DGL2.Item(Col2Tick, bIntI).Value Is Nothing Then DGL2.Item(Col2Tick, bIntI).Value = ""
            If DGL2.Item(Col2Tick, bIntI).Value.ToString.Trim = "" Then DGL2.Item(Col2Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

            If DGL2.Item(Col2Shift, bIntI).Value <> "" Then
                'Footer Calculation

                DGL2.Item(Col2Total, bIntI).Value = Val(DGL2.Item(Col2Member, bIntI).Value) + Val(DGL2.Item(Col2Extra, bIntI).Value)

                If AgL.StrCmp(DGL2.Item(Col2Tick, bIntI).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                    LblValTotalMember.Text = Val(LblValTotalMember.Text) + Val(DGL2.Item(Col2Member, bIntI).Value)
                    LblValTotalExtra.Text = Val(LblValTotalExtra.Text) + Val(DGL2.Item(Col2Extra, bIntI).Value)
                    LblValTotalPerson.Text = Val(LblValTotalPerson.Text) + Val(DGL2.Item(Col2Total, bIntI).Value)
                End If
            End If
        Next

        AgCalcGrid1.Calculation()

        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")
        LblValGrossAmount.Text = Format(Val(LblValGrossAmount.Text), "0.00")
    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function

            AgCL.AgBlankNothingCells(DGL2)

            If Val(BtnFill.Tag) <> Val(LblValTotalPerson.Text) Then
                MsgBox("Please fill Consumption Detail...")
                BtnFill.Focus() : Exit Function
            End If

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Mess_Consumption H With (NoLock) " & _
                        " WHERE H.ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & " " & _
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

    Public Sub Form_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        mBlnIsApproved = False

        LblValTotalQty.Text = "" : LblValGrossAmount.Text = ""
        LblValTotalMember.Text = "" : LblValTotalExtra.Text = "" : LblValTotalPerson.Text = ""
        BtnFill.Tag = ""
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter
        Try
            Select Case sender.name
                'Case TxtSalesTaxGroupParty.Name
                '    sender.AgRowFilter = "  Active <> 0 "

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtStructure.Validating, TxtV_Date.Validating, TxtV_No.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    Call IniGrid()

            End Select

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AgL.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
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
                'Case TxtAcCode.Name
                '    If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                '        Sender.AgSelectedValue = ""
                '        TxtSalesTaxGroupParty.AgSelectedValue = ""
                '    Else
                '        If Sender.AgHelpDataSet IsNot Nothing Then
                '            DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                '            TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                '        End If
                '    End If
                '    DrTemp = Nothing
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
        If Enb Then
            'DGLFooter2.CurrentCell = DGLFooter2(DFC_Percentage, DF2R_Addition) : DGLFooter2.CurrentCell.ReadOnly = False
            'DGLFooter2.CurrentCell = DGLFooter2(DFC_Amount, DF2R_Addition) : DGLFooter2.CurrentCell.ReadOnly = False

            'DGLFooter2.CurrentCell = DGLFooter2(DFC_Percentage, DF2R_Deduction) : DGLFooter2.CurrentCell.ReadOnly = False
            'DGLFooter2.CurrentCell = DGLFooter2(DFC_Amount, DF2R_Deduction) : DGLFooter2.CurrentCell.ReadOnly = False
        End If
    End Sub

    Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    DGL1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Mess & "' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
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
                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = ""
                            DGL1.Item(Col1Rate, mRowIndex).Value = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AgL.XNull(DrTemp(0)("Unit"))
                                DGL1.Item(Col1Rate, mRowIndex).Value = Format(AgL.VNull(DrTemp(0)("PurchaseRate")), "0.00")
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

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved
        AgL.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Private Sub Dgl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

    Private Sub Dgl2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellValueChanged
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL2
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col2Tick
                        Call Calculation()
                End Select
            End With


        Catch ex As Exception

        End Try
    End Sub


    Public Sub DGL2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL2
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    'Case <ColumnIndex>
                    '<Executable code>
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL2.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            Select Case DGL2.Columns(DGL2.CurrentCell.ColumnIndex).Name
                Case Col2Tick
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL2, DGL2.Columns(Col2Tick).Index)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL2.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL2.Columns(DGL2.CurrentCell.ColumnIndex).Name
                Case Col2Tick
                    Call AgL.ProcSetCheckColumnCellValue(DGL2, DGL2.Columns(Col2Tick).Index)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
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
            If AgL.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
                And AgL.XNull(LblPrefix.Text).ToString.Trim <> "" _
                And Val(TxtV_No.Text) > 0 Then

                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
                LblReferenceNo.Tag = TxtReferenceNo.Text
            End If
        End If
    End Sub

    Private Sub ProcSaveStockHeader(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = "INSERT INTO dbo.Store_StockHeader (DocId, Structure, PreparedBy, U_EntDt, U_AE)" & _
                    " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & _
                    " " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                    " " & AgL.Chk_Text(AgL.PubLoginDate) & ", " & _
                    " 'A') "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        Else
            mQry = "Update dbo.Store_StockHeader " & _
                    " SET  " & _
                    " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                    " U_AE = 'E', " & _
                    " Edit_Date = " & AgL.Chk_Text(AgL.PubLoginDate) & ", " & _
                    " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & " " & _
                    " WHERE DocId = " & AgL.Chk_Text(SearchCode) & " "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_Stock WHERE DocId = " & AgL.Chk_Text(SearchCode) & " "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
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
                        " ReferenceNo, Item, ItemDescription, Unit, BatchNo, Godown, Qty_Rec, Qty_Iss, " & _
                        " Rate, Amount, Remark) " & _
                        " VALUES (" & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & Sr & ", " & AgL.Chk_Text(bStrLineUid) & ", " & _
                        " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ",  " & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(LblPrefix.Text) & ", " & _
                        " " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Item, mGridRow)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1ItemDescription, mGridRow).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Unit, mGridRow)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1BatchNo, mGridRow).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Godown, mGridRow)) & ", " & _
                        " " & bDblQty_Rec & ", " & _
                        " " & bDblQty_Iss & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, mGridRow).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, mGridRow).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Remark, mGridRow).Value) & " " & _
                        " )"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click, BtnFillShitData.Click
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        Try
            Select Case sender.Name
                Case BtnFill.Name
                    Call ProcFillData()

                Case BtnFillShitData.Name
                    Call ProcFillShiftData()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillShiftData()
        Dim bIntI As Integer = 0
        Dim bDtTemp As DataTable = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor

            mQry = "SELECT V.Shift, IsNull(Sum(V.Member),0) AS Member, IsNull(Sum(V.Extra),0) AS Extra " & _
                    " FROM ( " & _
                    " 	SELECT A.Shift, A.TotalPresent AS Member, 0 AS Extra " & _
                    " 	FROM Mess_Attendance A WITH (NoLock) " & _
                    " 	WHERE A.V_Date = " & AgL.Chk_Text(TxtV_Date.Text) & " " & _
                    "   AND A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    " 	UNION ALL  " & _
                    " 	SELECT S.Code, 0 AS Person, E.TotalPerson AS Extra " & _
                    " 	FROM Mess_ExtraPerson E WITH (NoLock), Mess_Shift S WITH (NoLock) " & _
                    " 	WHERE " & AgL.Chk_Text(TxtV_Date.Text) & " BETWEEN E.FromDate AND E.ToDate " & _
                    "   AND E.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    " ) AS V " & _
                    " GROUP BY V.Shift "
            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            With bDtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()

                If bDtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To bDtTemp.Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(ColSNo, bIntI).Value = DGL2.Rows.Count

                        DGL2.AgSelectedValue(Col2Shift, bIntI) = AgL.XNull(.Rows(bIntI)("Shift"))
                        DGL2.Item(Col2Member, bIntI).Value = AgL.VNull(.Rows(bIntI)("Member"))
                        DGL2.Item(Col2Extra, bIntI).Value = AgL.VNull(.Rows(bIntI)("Extra"))

                        If AgL.VNull(DtMess_Enviro.Rows(0)("IsShiftAttendance")) Then
                            DGL2.Item(Col2Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        Else
                            DGL2.Item(Col2Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue
                        End If

                    Next bIntI
                End If
            End With

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ProcFillData()
        Dim bIntI As Integer = 0, bIntWeekDay% = 0
        Dim bDtTemp As DataTable = Nothing
        Dim bCondStr$ = " Where 1=1 ", bStrShiftList$ = "", bStrGroupBy$ = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AglObj.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Sub

            BtnFill.Tag = Val(LblValTotalPerson.Text)

            If AgL.VNull(DtMess_Enviro.Rows(0)("IsShiftAttendance")) Then            
                For bIntI = 0 To DGL2.Rows.Count - 1
                    If DGL2.Item(Col2Shift, bIntI).Value Is Nothing Then DGL2.Item(Col2Shift, bIntI).Value = ""
                    If DGL2.Item(Col2Tick, bIntI).Value Is Nothing Then DGL2.Item(Col2Tick, bIntI).Value = ""
                    If DGL2.Item(Col2Tick, bIntI).Value.ToString.Trim = "" Then DGL2.Item(Col2Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                    If AgL.StrCmp(DGL2.Item(Col2Tick, bIntI).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        If bStrShiftList.Trim = "" Then
                            bStrShiftList = AgL.Chk_Text(DGL2.AgSelectedValue(Col2Shift, bIntI))
                        Else
                            bStrShiftList += ", " + AgL.Chk_Text(DGL2.AgSelectedValue(Col2Shift, bIntI))
                        End If
                    End If
                Next

                bStrGroupBy = " GROUP BY v.Shift, v.Item "
            Else
                bStrGroupBy = " GROUP BY v.Item "
            End If

            bIntWeekDay = AgL.Dman_Execute("Select Datepart(WeekDay," & AgL.Chk_Text(TxtV_Date.Text) & ") ", AgL.GcnRead).ExecuteScalar

            bCondStr += " And M.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " "
            bCondStr += " And M.WeekDay = " & bIntWeekDay & " "
            If bStrShiftList.Trim <> "" Then
                bCondStr += " And M.Shift In (" & bStrShiftList & ") "
            End If


            mQry = "SELECT v.Item, Max(v.Unit) AS Unit, " & _
                    " IsNull(Sum(v.Qty),0) * " & Val(LblValTotalPerson.Text) & " AS Qty " & _
                    " FROM ( " & _
                    " 	SELECT M.Shift, B1.Item, B1.Unit, IsNull(B1.Qty,0) AS Qty " & _
                    " 	FROM Mess_Menu M With (NoLock)  " & _
                    " 	INNER JOIN Mess_Menu1 M1 With (NoLock)  ON M1.DocId = M.DocId " & _
                    " 	INNER JOIN Store_BOM B With (NoLock)  ON B.ForItem = M1.Item  " & _
                    " 	INNER JOIN Store_BomDetail B1 With (NoLock)  ON B1.Code = B.Code " & _
                    " 	" & bCondStr & " " & _
                    " 	UNION ALL  " & _
                    " 	SELECT M.Shift, M1.Item, M1.Unit, IsNull(M1.Qty,0) AS Qty " & _
                    " 	FROM (Mess_Menu M With (NoLock)  " & _
                    " 	INNER JOIN Mess_Menu1 M1 With (NoLock)  ON M1.DocId = M.DocId) " & _
                    " 	LEFT JOIN Store_BOM B With (NoLock)  ON B.ForItem = M1.Item  " & _
                    " 	" & bCondStr & " AND B.ForItem IS NULL  " & _
                    " 	) AS V " & _
                    " " & bStrGroupBy & " "
            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            With bDtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If bDtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To bDtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                        DGL1.AgSelectedValue(Col1Item, bIntI) = AgL.XNull(.Rows(bIntI)("Item"))
                        DGL1.AgSelectedValue(Col1Unit, bIntI) = AgL.XNull(.Rows(bIntI)("Unit"))

                        DGL1.Item(Col1Qty, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Qty")), "0.000")
                    Next bIntI
                End If
            End With

            Call Calculation()

        Catch ex As Exception
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            MsgBox(ex.Message)
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
