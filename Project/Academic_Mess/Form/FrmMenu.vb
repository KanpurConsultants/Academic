Public Class FrmMenu
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
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remark As String = "Remark"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Public Class AgCalGridCharges
        Public Const GrossAmount As String = "GAMT"
    End Class

#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents LblValNetAmount As System.Windows.Forms.Label
    Protected WithEvents LblTextNetAmount As System.Windows.Forms.Label


    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Friend WithEvents LblWeekDayReq As System.Windows.Forms.Label
    Friend WithEvents TxtWeekDay As AgControls.AgTextBox
    Friend WithEvents LblWeekDay As System.Windows.Forms.Label
    Friend WithEvents LblShiftReq As System.Windows.Forms.Label
    Friend WithEvents TxtShift As AgControls.AgTextBox
    Friend WithEvents LblShift As System.Windows.Forms.Label
    Friend WithEvents BtnCopy As System.Windows.Forms.Button
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValNetAmount = New System.Windows.Forms.Label
        Me.LblTextNetAmount = New System.Windows.Forms.Label
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.LblWeekDayReq = New System.Windows.Forms.Label
        Me.TxtWeekDay = New AgControls.AgTextBox
        Me.LblWeekDay = New System.Windows.Forms.Label
        Me.LblShiftReq = New System.Windows.Forms.Label
        Me.TxtShift = New AgControls.AgTextBox
        Me.LblShift = New System.Windows.Forms.Label
        Me.BtnCopy = New System.Windows.Forms.Button
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
        Me.TxtDocId.Location = New System.Drawing.Point(928, 85)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(779, 27)
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(885, 26)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(74, 14)
        Me.Label2.Visible = False
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(11, 12)
        Me.LblV_Date.Visible = False
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(868, 12)
        Me.LblV_TypeReq.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(89, 13)
        Me.TxtV_Date.Size = New System.Drawing.Size(94, 18)
        Me.TxtV_Date.TabIndex = 1
        Me.TxtV_Date.Visible = False
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(779, 7)
        Me.LblV_Type.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(884, 6)
        Me.TxtV_Type.Size = New System.Drawing.Size(94, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(306, 18)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(198, 13)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(322, 12)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(881, 87)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(846, 27)
        Me.LblPrefix.Visible = False
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 131)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.BtnCopy)
        Me.TP1.Controls.Add(Me.LblShiftReq)
        Me.TP1.Controls.Add(Me.TxtShift)
        Me.TP1.Controls.Add(Me.LblShift)
        Me.TP1.Controls.Add(Me.LblWeekDayReq)
        Me.TP1.Controls.Add(Me.TxtWeekDay)
        Me.TP1.Controls.Add(Me.LblWeekDay)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Size = New System.Drawing.Size(984, 103)
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
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblWeekDay, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtWeekDay, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblWeekDayReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblShift, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShift, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblShiftReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnCopy, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 2
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
        Me.TxtRemark.Location = New System.Drawing.Point(322, 52)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 5
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(198, 54)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(105, 180)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(774, 341)
        Me.Pnl1.TabIndex = 1
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(76, 39)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 771
        Me.LblReferenceNoReq.Text = "Ä"
        Me.LblReferenceNoReq.Visible = False
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(89, 33)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(94, 18)
        Me.TxtReferenceNo.TabIndex = 2
        Me.TxtReferenceNo.Visible = False
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(8, 34)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(64, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Menu No."
        Me.LblReferenceNo.Visible = False
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValNetAmount)
        Me.PnlFooter.Controls.Add(Me.LblTextNetAmount)
        Me.PnlFooter.Location = New System.Drawing.Point(105, 521)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(774, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LblValNetAmount
        '
        Me.LblValNetAmount.AutoSize = True
        Me.LblValNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValNetAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValNetAmount.Location = New System.Drawing.Point(711, 3)
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
        Me.LblTextNetAmount.Location = New System.Drawing.Point(609, 4)
        Me.LblTextNetAmount.Name = "LblTextNetAmount"
        Me.LblTextNetAmount.Size = New System.Drawing.Size(101, 16)
        Me.LblTextNetAmount.TabIndex = 661
        Me.LblTextNetAmount.Text = "Total Amount :"
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(673, 580)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(21, 23)
        Me.PnlCShowGrid2.TabIndex = 939
        Me.PnlCShowGrid2.Visible = False
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(694, 580)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(21, 23)
        Me.PnlCShowGrid.TabIndex = 2
        Me.PnlCShowGrid.Visible = False
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(652, 580)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(21, 23)
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
        Me.LinkLabel1.Location = New System.Drawing.Point(102, 159)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(83, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Menu Detail:"
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
        Me.TxtStructure.Location = New System.Drawing.Point(881, 46)
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
        Me.Label25.Location = New System.Drawing.Point(814, 46)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 769
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'LblWeekDayReq
        '
        Me.LblWeekDayReq.AutoSize = True
        Me.LblWeekDayReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblWeekDayReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblWeekDayReq.Location = New System.Drawing.Point(309, 36)
        Me.LblWeekDayReq.Name = "LblWeekDayReq"
        Me.LblWeekDayReq.Size = New System.Drawing.Size(10, 7)
        Me.LblWeekDayReq.TabIndex = 774
        Me.LblWeekDayReq.Text = "Ä"
        '
        'TxtWeekDay
        '
        Me.TxtWeekDay.AgMandatory = True
        Me.TxtWeekDay.AgMasterHelp = False
        Me.TxtWeekDay.AgNumberLeftPlaces = 0
        Me.TxtWeekDay.AgNumberNegetiveAllow = False
        Me.TxtWeekDay.AgNumberRightPlaces = 0
        Me.TxtWeekDay.AgPickFromLastValue = False
        Me.TxtWeekDay.AgRowFilter = ""
        Me.TxtWeekDay.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWeekDay.AgSelectedValue = Nothing
        Me.TxtWeekDay.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWeekDay.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWeekDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWeekDay.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWeekDay.Location = New System.Drawing.Point(322, 32)
        Me.TxtWeekDay.MaxLength = 0
        Me.TxtWeekDay.Name = "TxtWeekDay"
        Me.TxtWeekDay.Size = New System.Drawing.Size(94, 18)
        Me.TxtWeekDay.TabIndex = 3
        '
        'LblWeekDay
        '
        Me.LblWeekDay.AutoSize = True
        Me.LblWeekDay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWeekDay.Location = New System.Drawing.Point(198, 32)
        Me.LblWeekDay.Name = "LblWeekDay"
        Me.LblWeekDay.Size = New System.Drawing.Size(62, 15)
        Me.LblWeekDay.TabIndex = 773
        Me.LblWeekDay.Text = "Week Day"
        '
        'LblShiftReq
        '
        Me.LblShiftReq.AutoSize = True
        Me.LblShiftReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblShiftReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblShiftReq.Location = New System.Drawing.Point(530, 38)
        Me.LblShiftReq.Name = "LblShiftReq"
        Me.LblShiftReq.Size = New System.Drawing.Size(10, 7)
        Me.LblShiftReq.TabIndex = 777
        Me.LblShiftReq.Text = "Ä"
        '
        'TxtShift
        '
        Me.TxtShift.AgMandatory = True
        Me.TxtShift.AgMasterHelp = False
        Me.TxtShift.AgNumberLeftPlaces = 0
        Me.TxtShift.AgNumberNegetiveAllow = False
        Me.TxtShift.AgNumberRightPlaces = 0
        Me.TxtShift.AgPickFromLastValue = False
        Me.TxtShift.AgRowFilter = ""
        Me.TxtShift.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShift.AgSelectedValue = Nothing
        Me.TxtShift.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShift.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShift.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShift.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShift.Location = New System.Drawing.Point(543, 32)
        Me.TxtShift.MaxLength = 0
        Me.TxtShift.Name = "TxtShift"
        Me.TxtShift.Size = New System.Drawing.Size(129, 18)
        Me.TxtShift.TabIndex = 4
        '
        'LblShift
        '
        Me.LblShift.AutoSize = True
        Me.LblShift.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShift.Location = New System.Drawing.Point(462, 34)
        Me.LblShift.Name = "LblShift"
        Me.LblShift.Size = New System.Drawing.Size(31, 15)
        Me.LblShift.TabIndex = 776
        Me.LblShift.Text = "Shift"
        '
        'BtnCopy
        '
        Me.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopy.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnCopy.Image = Global.Academic_Mess.My.Resources.Resources.Copy1
        Me.BtnCopy.Location = New System.Drawing.Point(675, 51)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(23, 21)
        Me.BtnCopy.TabIndex = 778
        Me.BtnCopy.TabStop = False
        Me.BtnCopy.UseVisualStyleBackColor = True
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmMenu"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
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
        Public Shared WeekDay As DataSet = Nothing
        Public Shared Shift As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Mess_Menu"
        AglObj = AgL

        LblV_Type.Text = "Menu Type"
        LblV_Date.Text = "Apply Date"
        LblV_No.Text = "Menu No."
        TP1.Text = "Menu Detail"

        AgL.GridDesign(DGL1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)

        AgCShowGrid1.Visible = True
        AgCShowGrid2.Visible = True

        AgCalcGrid1.AgLibVar = AgL
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
                " From Mess_Menu H With (NoLock) " & _
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

        AgL.PubFindQry = "SELECT H.DocId AS SearchCode, W.Description As [" & LblWeekDay.Text & "], H.Shift As [" & LblShift.Text & "], S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Mess_Menu H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & _
                            " Left JOIN Sch_WeekDay W With (NoLock) ON W.Code = H.WeekDay " & mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], [" & LblWeekDay.Text & "], [" & LblShift.Text & "]"
    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Item, 200, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 270, 255, Col1ItemDescription, True, False, False)
            .AddAgTextColumn(DGL1, Col1Unit, 60, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(DGL1, Col1Qty, 60, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Rate, 60, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(DGL1, Col1Amount, 80, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(DGL1, Col1Remark, 100, 255, Col1Remark, False, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        AgCalcGrid1.Ini_Grid(mSearchCode)

        AgCalcGrid1.AgFixedRows = 1

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

        AgCShowGrid1.Visible = False
        AgCShowGrid2.Visible = False

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0


        mQry = "UPDATE dbo.Mess_Menu " & _
                " SET  " & _
                "   Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " 	ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " 	WeekDay = " & AgL.Chk_Text(TxtWeekDay.AgSelectedValue) & ", " & _
                " 	Shift = " & AgL.Chk_Text(TxtShift.AgSelectedValue) & ", " & _
                " 	TotalAmount = " & Val(LblValNetAmount.Text) & ", " & _
                "   Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " WHERE DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mSearchCode, Conn, Cmd)

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Mess_Menu1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Mess_Menu1 (" & _
                        " DocId, Sr, Item, ItemDescription, Unit, Qty, Rate, Amount, Remark) " & _
                        " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Unit, bIntI)) & ", " & _
                        " " & Val(DGL1.Item(Col1Qty, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Rate, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1Amount, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(mSearchCode, bIntSr, bIntI, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)

            End If
        Next
    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        mQry = "Delete From Mess_Menu1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Mess_Menu Where DocId = '" & SearchCode & "' "
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
            " From Mess_Menu H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

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

                TxtWeekDay.AgSelectedValue = AgL.XNull(.Rows(0)("WeekDay"))
                TxtShift.AgSelectedValue = AgL.XNull(.Rows(0)("Shift"))

                LblValNetAmount.Text = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.00")

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                mQry = "Select L.* " & _
                        " From Mess_Menu1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.AgSelectedValue(Col1Item, bIntI) = AgL.XNull(.Rows(bIntI)("Item"))
                            DGL1.Item(Col1ItemDescription, bIntI).Value = AgL.XNull(.Rows(bIntI)("ItemDescription"))
                            DGL1.AgSelectedValue(Col1Unit, bIntI) = AgL.XNull(.Rows(bIntI)("Unit"))

                            DGL1.Item(Col1Qty, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Qty")), "0.000")
                            DGL1.Item(Col1Rate, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Rate")), "0.00")
                            DGL1.Item(Col1Amount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Amount")), "0.00")
                            DGL1.Item(Col1Remark, bIntI).Value = AgL.XNull(.Rows(bIntI)("Remark"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)

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

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AgL.PubLoginDate
        End If

        TxtWeekDay.Focus()
    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        TxtWeekDay.Focus()
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            mQry = "SELECT Code, Description  FROM Structure With (NoLock)  ORDER BY Description "
            HelpDataSet.AgStructure = AgL.FillData(mQry, GcnRead)

            mQry = "SELECT W.Code , W.ManualCode  FROM Sch_WeekDay W ORDER BY W.Code "
            HelpDataSet.WeekDay = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT W.Code , W.Code  FROM Mess_Shift W ORDER BY W.Code "
            HelpDataSet.Shift = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT U.Code AS Code, U.Code AS Name FROM Store_Unit U With (NoLock)  ORDER BY U.Code"
            HelpDataSet.Unit = AgL.FillData(mQry, GcnRead)

            mQry = "SELECT I.Code, I.Description AS [Item Name], I.Unit, " & _
                    " I.DisplayName AS [Display Name], I.ManualCode, " & _
                    " C.Description AS [Item Category], G.Description AS [Item Group], " & _
                    " I.Nature, I.MasterType, " & _
                    " I.SaleRate, I.PurchaseRate, I.MRP, I.PcsPerCase, " & _
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

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtStructure.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.AgStructure.Copy

        TxtWeekDay.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.WeekDay.Copy
        TxtShift.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Shift.Copy

        DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Unit) = HelpDataSet.Unit.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        Dim bIntI As Integer = 0

        LblValNetAmount.Text = ""

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
            If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""
            If DGL1.Item(Col1Rate, bIntI).Value Is Nothing Then DGL1.Item(Col1Rate, bIntI).Value = ""
            If DGL1.Item(Col1Amount, bIntI).Value Is Nothing Then DGL1.Item(Col1Amount, bIntI).Value = ""

            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                DGL1.Item(Col1Amount, bIntI).Value = Format(Val(DGL1.Item(Col1Qty, bIntI).Value) * Val(DGL1.Item(Col1Rate, bIntI).Value), "0.00")

                'Footer Total
                LblValNetAmount.Text = Val(LblValNetAmount.Text) + Val(DGL1.Item(Col1Amount, bIntI).Value)
            End If
        Next

        AgCalcGrid1.Calculation()

        LblValNetAmount.Text = Format(Val(LblValNetAmount.Text), "0.00")

    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtWeekDay, LblWeekDay.Text) Then Exit Function
            If AglObj.RequiredField(TxtShift, LblShift.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function


            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM Mess_Menu H " & _
                    " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                    " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                    " And H.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    " AND H.WeekDay = " & AgL.Chk_Text(TxtWeekDay.AgSelectedValue) & " " & _
                    " AND H.Shift = " & AgL.Chk_Text(TxtShift.AgSelectedValue) & " " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
            If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                MsgBox("Menu Already Exists!...")
                TxtWeekDay.Focus() : Exit Function
            End If

            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                Call ProcFillReferenceNo()
            End If

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Mess_Menu H With (NoLock) " & _
                        " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                        " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                        " And H.ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & " " & _
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

        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter
        Try
            Select Case sender.name
                'Case <sender>.Name
                '<Executbale Code>
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtStructure.Validating, TxtV_Date.Validating, TxtV_No.Validating, _
        TxtWeekDay.Validating, TxtShift.Validating, TxtRemark.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    Call IniGrid()
            End Select

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" Then
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

    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.

        TxtReferenceNo.Enabled = False
        BtnCopy.Enabled = Enb

        If Enb Then
            '<Executable Code>
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
                            DGL1.Item(Col1ItemDescription, mRowIndex).Value = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AgL.XNull(DrTemp(0)("Unit"))
                                DGL1.Item(Col1Rate, mRowIndex).Value = Format(AgL.VNull(DrTemp(0)("SaleRate")), "0.00")

                                If AgL.XNull(DGL1.Item(Col1ItemDescription, mRowIndex).Value).ToString.Trim = "" Then
                                    DGL1.Item(Col1ItemDescription, mRowIndex).Value = AgL.XNull(DrTemp(0)("Display Name"))
                                End If


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
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
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

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Sub ProcFillReferenceNo()
        If Topctrl1.Mode = "Add" Then
            If AgL.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
                And AgL.XNull(LblPrefix.Text).ToString.Trim <> "" _
                And Val(TxtV_No.Text) > 0 Then

                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
                LblReferenceNo.Tag = TxtReferenceNo.Text
            End If
        End If
    End Sub

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.MessMenu) & ""
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Dim mCondStr$ = "  Where 1=1  "
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

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

            If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then
                mCondStr += " And H.DocId <> '" & mSearchCode & "' "
            End If

            mQry = "SELECT H.DocId AS SearchCode, W.Description As [" & LblWeekDay.Text & "], H.Shift As [" & LblShift.Text & "] " & _
                    " FROM Mess_Menu H With (NoLock) " & _
                    " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                    " Left JOIN Sch_WeekDay W With (NoLock) ON W.Code = H.WeekDay "

            AgL.PubFindQry = mQry & mCondStr
            AgL.PubFindQryOrdBy = "[" & LblWeekDay.Text & "], [" & LblShift.Text & "]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing

            If AgL.PubSearchRow <> "" Then
                Call ProcCopyMenu(AgL.PubSearchRow)
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub ProcCopyMenu(ByVal StrDocId As String)
        Dim bIntI As Integer = 0
        Dim bDtTemp As DataTable = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor

            If AgL.XNull(StrDocId).ToString.Trim = "" Then Exit Sub

            mQry = "Select L.* " & _
                    " From Mess_Menu1 L With (NoLock) " & _
                    " Where L.DocId = '" & StrDocId & "' " & _
                    " Order By L.Sr"
            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            With bDtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If bDtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To bDtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                        DGL1.AgSelectedValue(Col1Item, bIntI) = AgL.XNull(.Rows(bIntI)("Item"))
                        DGL1.Item(Col1ItemDescription, bIntI).Value = AgL.XNull(.Rows(bIntI)("ItemDescription"))
                        DGL1.AgSelectedValue(Col1Unit, bIntI) = AgL.XNull(.Rows(bIntI)("Unit"))

                        DGL1.Item(Col1Qty, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Qty")), "0.000")
                        DGL1.Item(Col1Rate, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Rate")), "0.00")
                        DGL1.Item(Col1Amount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Amount")), "0.00")
                        DGL1.Item(Col1Remark, bIntI).Value = AgL.XNull(.Rows(bIntI)("Remark"))
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

End Class
