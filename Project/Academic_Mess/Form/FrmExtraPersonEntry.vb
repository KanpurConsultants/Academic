Public Class FrmExtraPersonEntry
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1PersonName As String = "Person Name"
    Protected Const Col1Relation As String = "Relation"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"


#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel


    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblValTotalPerson As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalPerson As System.Windows.Forms.Label
    Protected WithEvents LblTotalDays As System.Windows.Forms.Label
    Protected WithEvents TxtTotalDays As AgControls.AgTextBox
    Protected WithEvents LblTotalDaysReq As System.Windows.Forms.Label
    Protected WithEvents TxtToDate As AgControls.AgTextBox
    Protected WithEvents LblToDate As System.Windows.Forms.Label
    Protected WithEvents LblFromDateReq As System.Windows.Forms.Label
    Protected WithEvents TxtFromDate As AgControls.AgTextBox
    Protected WithEvents LblFromDate As System.Windows.Forms.Label
    Protected WithEvents TxtSubCode As AgControls.AgTextBox
    Protected WithEvents LblSubCode As System.Windows.Forms.Label
    Protected WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtFatherName As AgControls.AgTextBox
    Protected WithEvents LblFatherName As System.Windows.Forms.Label
    Protected WithEvents TxtCurrentSemester As AgControls.AgTextBox
    Protected WithEvents LblCurrentSemester As System.Windows.Forms.Label
    Protected WithEvents TxtMobile As AgControls.AgTextBox
    Protected WithEvents LblMobile As System.Windows.Forms.Label
    Protected WithEvents TxtMemberType As AgControls.AgTextBox
    Protected WithEvents LblMemberType As System.Windows.Forms.Label
    Protected WithEvents TxtDesignation As AgControls.AgTextBox
    Protected WithEvents LblDesignation As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalPerson = New System.Windows.Forms.Label
        Me.LblTextTotalPerson = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblTotalDays = New System.Windows.Forms.Label
        Me.TxtTotalDays = New AgControls.AgTextBox
        Me.LblTotalDaysReq = New System.Windows.Forms.Label
        Me.TxtToDate = New AgControls.AgTextBox
        Me.LblToDate = New System.Windows.Forms.Label
        Me.LblFromDateReq = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.LblFromDate = New System.Windows.Forms.Label
        Me.TxtSubCode = New AgControls.AgTextBox
        Me.LblSubCode = New System.Windows.Forms.Label
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.LblFatherName = New System.Windows.Forms.Label
        Me.TxtMemberType = New AgControls.AgTextBox
        Me.LblMemberType = New System.Windows.Forms.Label
        Me.TxtMobile = New AgControls.AgTextBox
        Me.LblMobile = New System.Windows.Forms.Label
        Me.TxtCurrentSemester = New AgControls.AgTextBox
        Me.LblCurrentSemester = New System.Windows.Forms.Label
        Me.TxtDesignation = New AgControls.AgTextBox
        Me.LblDesignation = New System.Windows.Forms.Label
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
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(310, 49)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(416, 47)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(126, 53)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(12, 49)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(126, 33)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(141, 47)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(12, 28)
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
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(12, 8)
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
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(377, 48)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 146)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtDesignation)
        Me.TP1.Controls.Add(Me.LblDesignation)
        Me.TP1.Controls.Add(Me.TxtCurrentSemester)
        Me.TP1.Controls.Add(Me.LblCurrentSemester)
        Me.TP1.Controls.Add(Me.TxtMobile)
        Me.TP1.Controls.Add(Me.LblMobile)
        Me.TP1.Controls.Add(Me.TxtMemberType)
        Me.TP1.Controls.Add(Me.LblMemberType)
        Me.TP1.Controls.Add(Me.TxtFatherName)
        Me.TP1.Controls.Add(Me.LblFatherName)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.LblTotalDays)
        Me.TP1.Controls.Add(Me.TxtTotalDays)
        Me.TP1.Controls.Add(Me.LblTotalDaysReq)
        Me.TP1.Controls.Add(Me.TxtToDate)
        Me.TP1.Controls.Add(Me.LblToDate)
        Me.TP1.Controls.Add(Me.LblFromDateReq)
        Me.TP1.Controls.Add(Me.TxtFromDate)
        Me.TP1.Controls.Add(Me.LblFromDate)
        Me.TP1.Controls.Add(Me.TxtSubCode)
        Me.TP1.Controls.Add(Me.LblSubCode)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 118)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromDateReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtToDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTotalDaysReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTotalDays, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTotalDays, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFatherName, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtFatherName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberType, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrentSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrentSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDesignation, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDesignation, 0)
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
        Me.TxtRemark.Location = New System.Drawing.Point(605, 87)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(370, 18)
        Me.TxtRemark.TabIndex = 16
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(526, 89)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(54, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Purpose"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(285, 200)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(414, 321)
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
        Me.LblReferenceNo.Location = New System.Drawing.Point(12, 68)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalPerson)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalPerson)
        Me.PnlFooter.Location = New System.Drawing.Point(285, 521)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(414, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LblValTotalPerson
        '
        Me.LblValTotalPerson.AutoSize = True
        Me.LblValTotalPerson.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalPerson.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalPerson.Location = New System.Drawing.Point(331, 4)
        Me.LblValTotalPerson.Name = "LblValTotalPerson"
        Me.LblValTotalPerson.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalPerson.TabIndex = 680
        Me.LblValTotalPerson.Text = "."
        Me.LblValTotalPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalPerson
        '
        Me.LblTextTotalPerson.AutoSize = True
        Me.LblTextTotalPerson.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalPerson.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalPerson.Location = New System.Drawing.Point(234, 4)
        Me.LblTextTotalPerson.Name = "LblTextTotalPerson"
        Me.LblTextTotalPerson.Size = New System.Drawing.Size(96, 16)
        Me.LblTextTotalPerson.TabIndex = 679
        Me.LblTextTotalPerson.Text = "Total Person :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(282, 177)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(130, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "EXTRA PERSON LIST :"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTotalDays
        '
        Me.LblTotalDays.AutoSize = True
        Me.LblTotalDays.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalDays.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDays.Location = New System.Drawing.Point(526, 68)
        Me.LblTotalDays.Name = "LblTotalDays"
        Me.LblTotalDays.Size = New System.Drawing.Size(61, 16)
        Me.LblTotalDays.TabIndex = 1016
        Me.LblTotalDays.Text = "For Days"
        '
        'TxtTotalDays
        '
        Me.TxtTotalDays.AgMandatory = True
        Me.TxtTotalDays.AgMasterHelp = False
        Me.TxtTotalDays.AgNumberLeftPlaces = 8
        Me.TxtTotalDays.AgNumberNegetiveAllow = False
        Me.TxtTotalDays.AgNumberRightPlaces = 0
        Me.TxtTotalDays.AgPickFromLastValue = False
        Me.TxtTotalDays.AgRowFilter = ""
        Me.TxtTotalDays.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalDays.AgSelectedValue = Nothing
        Me.TxtTotalDays.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalDays.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalDays.BackColor = System.Drawing.Color.White
        Me.TxtTotalDays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalDays.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDays.Location = New System.Drawing.Point(605, 67)
        Me.TxtTotalDays.MaxLength = 0
        Me.TxtTotalDays.Name = "TxtTotalDays"
        Me.TxtTotalDays.Size = New System.Drawing.Size(47, 18)
        Me.TxtTotalDays.TabIndex = 13
        Me.TxtTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalDaysReq
        '
        Me.LblTotalDaysReq.AutoSize = True
        Me.LblTotalDaysReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTotalDaysReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTotalDaysReq.Location = New System.Drawing.Point(590, 73)
        Me.LblTotalDaysReq.Name = "LblTotalDaysReq"
        Me.LblTotalDaysReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTotalDaysReq.TabIndex = 11
        Me.LblTotalDaysReq.Text = "Ä"
        '
        'TxtToDate
        '
        Me.TxtToDate.AgMandatory = False
        Me.TxtToDate.AgMasterHelp = False
        Me.TxtToDate.AgNumberLeftPlaces = 8
        Me.TxtToDate.AgNumberNegetiveAllow = False
        Me.TxtToDate.AgNumberRightPlaces = 2
        Me.TxtToDate.AgPickFromLastValue = False
        Me.TxtToDate.AgRowFilter = ""
        Me.TxtToDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToDate.AgSelectedValue = Nothing
        Me.TxtToDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtToDate.BackColor = System.Drawing.Color.White
        Me.TxtToDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToDate.Location = New System.Drawing.Point(880, 67)
        Me.TxtToDate.MaxLength = 0
        Me.TxtToDate.Name = "TxtToDate"
        Me.TxtToDate.ReadOnly = True
        Me.TxtToDate.Size = New System.Drawing.Size(95, 18)
        Me.TxtToDate.TabIndex = 15
        Me.TxtToDate.TabStop = False
        '
        'LblToDate
        '
        Me.LblToDate.AutoSize = True
        Me.LblToDate.BackColor = System.Drawing.Color.Transparent
        Me.LblToDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToDate.Location = New System.Drawing.Point(839, 69)
        Me.LblToDate.Name = "LblToDate"
        Me.LblToDate.Size = New System.Drawing.Size(35, 16)
        Me.LblToDate.TabIndex = 1014
        Me.LblToDate.Text = "Upto"
        '
        'LblFromDateReq
        '
        Me.LblFromDateReq.AutoSize = True
        Me.LblFromDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblFromDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblFromDateReq.Location = New System.Drawing.Point(727, 73)
        Me.LblFromDateReq.Name = "LblFromDateReq"
        Me.LblFromDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblFromDateReq.TabIndex = 1013
        Me.LblFromDateReq.Text = "Ä"
        '
        'TxtFromDate
        '
        Me.TxtFromDate.AgMandatory = True
        Me.TxtFromDate.AgMasterHelp = False
        Me.TxtFromDate.AgNumberLeftPlaces = 8
        Me.TxtFromDate.AgNumberNegetiveAllow = False
        Me.TxtFromDate.AgNumberRightPlaces = 2
        Me.TxtFromDate.AgPickFromLastValue = False
        Me.TxtFromDate.AgRowFilter = ""
        Me.TxtFromDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFromDate.AgSelectedValue = Nothing
        Me.TxtFromDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFromDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFromDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromDate.Location = New System.Drawing.Point(742, 67)
        Me.TxtFromDate.MaxLength = 0
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(95, 18)
        Me.TxtFromDate.TabIndex = 14
        '
        'LblFromDate
        '
        Me.LblFromDate.AutoSize = True
        Me.LblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.LblFromDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromDate.Location = New System.Drawing.Point(659, 68)
        Me.LblFromDate.Name = "LblFromDate"
        Me.LblFromDate.Size = New System.Drawing.Size(69, 16)
        Me.LblFromDate.TabIndex = 1012
        Me.LblFromDate.Text = "From Date"
        '
        'TxtSubCode
        '
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
        Me.TxtSubCode.Location = New System.Drawing.Point(141, 87)
        Me.TxtSubCode.MaxLength = 20
        Me.TxtSubCode.Name = "TxtSubCode"
        Me.TxtSubCode.Size = New System.Drawing.Size(370, 18)
        Me.TxtSubCode.TabIndex = 5
        '
        'LblSubCode
        '
        Me.LblSubCode.AutoSize = True
        Me.LblSubCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubCode.Location = New System.Drawing.Point(12, 89)
        Me.LblSubCode.Name = "LblSubCode"
        Me.LblSubCode.Size = New System.Drawing.Size(71, 15)
        Me.LblSubCode.TabIndex = 1011
        Me.LblSubCode.Text = "Referred By"
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(126, 93)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 1017
        Me.LblSubCodeReq.Text = "Ä"
        '
        'TxtFatherName
        '
        Me.TxtFatherName.AgMandatory = False
        Me.TxtFatherName.AgMasterHelp = False
        Me.TxtFatherName.AgNumberLeftPlaces = 0
        Me.TxtFatherName.AgNumberNegetiveAllow = False
        Me.TxtFatherName.AgNumberRightPlaces = 0
        Me.TxtFatherName.AgPickFromLastValue = False
        Me.TxtFatherName.AgRowFilter = ""
        Me.TxtFatherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherName.AgSelectedValue = Nothing
        Me.TxtFatherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFatherName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherName.Location = New System.Drawing.Point(605, 27)
        Me.TxtFatherName.MaxLength = 0
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(370, 18)
        Me.TxtFatherName.TabIndex = 8
        '
        'LblFatherName
        '
        Me.LblFatherName.AutoSize = True
        Me.LblFatherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFatherName.Location = New System.Drawing.Point(526, 29)
        Me.LblFatherName.Name = "LblFatherName"
        Me.LblFatherName.Size = New System.Drawing.Size(79, 15)
        Me.LblFatherName.TabIndex = 1018
        Me.LblFatherName.Text = "Father Name"
        '
        'TxtMemberType
        '
        Me.TxtMemberType.AgMandatory = False
        Me.TxtMemberType.AgMasterHelp = False
        Me.TxtMemberType.AgNumberLeftPlaces = 0
        Me.TxtMemberType.AgNumberNegetiveAllow = False
        Me.TxtMemberType.AgNumberRightPlaces = 0
        Me.TxtMemberType.AgPickFromLastValue = False
        Me.TxtMemberType.AgRowFilter = ""
        Me.TxtMemberType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberType.AgSelectedValue = Nothing
        Me.TxtMemberType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberType.Location = New System.Drawing.Point(605, 7)
        Me.TxtMemberType.MaxLength = 0
        Me.TxtMemberType.Name = "TxtMemberType"
        Me.TxtMemberType.Size = New System.Drawing.Size(120, 18)
        Me.TxtMemberType.TabIndex = 6
        '
        'LblMemberType
        '
        Me.LblMemberType.AutoSize = True
        Me.LblMemberType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberType.Location = New System.Drawing.Point(526, 9)
        Me.LblMemberType.Name = "LblMemberType"
        Me.LblMemberType.Size = New System.Drawing.Size(81, 15)
        Me.LblMemberType.TabIndex = 1021
        Me.LblMemberType.Text = "Member Type"
        '
        'TxtMobile
        '
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
        Me.TxtMobile.Location = New System.Drawing.Point(880, 47)
        Me.TxtMobile.MaxLength = 0
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(95, 18)
        Me.TxtMobile.TabIndex = 10
        '
        'LblMobile
        '
        Me.LblMobile.AutoSize = True
        Me.LblMobile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMobile.Location = New System.Drawing.Point(839, 49)
        Me.LblMobile.Name = "LblMobile"
        Me.LblMobile.Size = New System.Drawing.Size(43, 15)
        Me.LblMobile.TabIndex = 1023
        Me.LblMobile.Text = "Mobile"
        '
        'TxtCurrentSemester
        '
        Me.TxtCurrentSemester.AgMandatory = False
        Me.TxtCurrentSemester.AgMasterHelp = False
        Me.TxtCurrentSemester.AgNumberLeftPlaces = 0
        Me.TxtCurrentSemester.AgNumberNegetiveAllow = False
        Me.TxtCurrentSemester.AgNumberRightPlaces = 0
        Me.TxtCurrentSemester.AgPickFromLastValue = False
        Me.TxtCurrentSemester.AgRowFilter = ""
        Me.TxtCurrentSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrentSemester.AgSelectedValue = Nothing
        Me.TxtCurrentSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrentSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrentSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrentSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrentSemester.Location = New System.Drawing.Point(605, 47)
        Me.TxtCurrentSemester.MaxLength = 0
        Me.TxtCurrentSemester.Name = "TxtCurrentSemester"
        Me.TxtCurrentSemester.Size = New System.Drawing.Size(232, 18)
        Me.TxtCurrentSemester.TabIndex = 9
        '
        'LblCurrentSemester
        '
        Me.LblCurrentSemester.AutoSize = True
        Me.LblCurrentSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentSemester.Location = New System.Drawing.Point(526, 49)
        Me.LblCurrentSemester.Name = "LblCurrentSemester"
        Me.LblCurrentSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblCurrentSemester.TabIndex = 1024
        Me.LblCurrentSemester.Text = "Semester"
        '
        'TxtDesignation
        '
        Me.TxtDesignation.AgMandatory = False
        Me.TxtDesignation.AgMasterHelp = False
        Me.TxtDesignation.AgNumberLeftPlaces = 0
        Me.TxtDesignation.AgNumberNegetiveAllow = False
        Me.TxtDesignation.AgNumberRightPlaces = 0
        Me.TxtDesignation.AgPickFromLastValue = False
        Me.TxtDesignation.AgRowFilter = ""
        Me.TxtDesignation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDesignation.AgSelectedValue = Nothing
        Me.TxtDesignation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDesignation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDesignation.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesignation.Location = New System.Drawing.Point(855, 7)
        Me.TxtDesignation.MaxLength = 0
        Me.TxtDesignation.Name = "TxtDesignation"
        Me.TxtDesignation.Size = New System.Drawing.Size(120, 18)
        Me.TxtDesignation.TabIndex = 7
        '
        'LblDesignation
        '
        Me.LblDesignation.AutoSize = True
        Me.LblDesignation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesignation.Location = New System.Drawing.Point(776, 9)
        Me.LblDesignation.Name = "LblDesignation"
        Me.LblDesignation.Size = New System.Drawing.Size(74, 15)
        Me.LblDesignation.TabIndex = 1026
        Me.LblDesignation.Text = "Designation"
        '
        'FrmExtraPersonEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmExtraPersonEntry"
        Me.Text = "Extra Person Entry"
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

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.MessExtraPersonEntry) & ""
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
        Public Shared Relation As DataSet = Nothing
        Public Shared Member As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Mess_ExtraPerson"
        AglObj = AgL

        LblV_Type.Text = "Extra Person Type"
        LblV_Date.Text = "Extra Person Date"
        LblV_No.Text = "Extra Person No."
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
                " From Mess_ExtraPerson H With (NoLock) " & _
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
                            " Sg.Name As [" & LblSubCode.Text & "], " & _
                            " M.MemberType As [" & LblMemberType.Text & "], " & _
                            " Sg.FatherName As [" & LblFatherName.Text & "], " & _
                            " Sg.Mobile As [" & LblMobile.Text & "], " & _
                            " " & AgL.ConvertDateField("H.FromDate") & " As [" & LblFromDate.Text & "], " & _
                            " " & AgL.ConvertDateField("H.ToDate") & " As [" & LblToDate.Text & "], " & _
                            " Convert(Varchar,H.TotalPerson) As [" & LblTextTotalPerson.Text & "], " & _
                            " Convert(Varchar,H.TotalDays) As [" & LblTotalDays.Text & "], " & _
                            " S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Mess_ExtraPerson H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & _
                            " Left Join SubGroup Sg With (NoLock) On H.SubCode = Sg.SubCode " & _
                            " Left Join Mess_Member M With (NoLock) On M.SubCode = H.SubCode " & _
                            mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, [" & LblSubCode.Text & "] "

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1PersonName, 250, 100, Col1PersonName, True, False, False)
            .AddAgTextColumn(DGL1, Col1Relation, 100, 20, Col1Relation, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0



        mQry = "UPDATE dbo.Mess_ExtraPerson " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                " FromDate = " & AgL.Chk_Text(TxtFromDate.Text) & ", " & _
                " ToDate = " & AgL.Chk_Text(TxtToDate.Text) & ", " & _
                " TotalDays = " & Val(TxtTotalDays.Text) & ", " & _
                " TotalPerson = " & Val(LblValTotalPerson.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Mess_ExtraPerson1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1PersonName, bIntI).Value <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Mess_ExtraPerson1 ( " & _
                        " DocId, Sr, PersonName, Relation) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1PersonName, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Relation, bIntI).Value) & " " & _
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
        mQry = "Delete From Mess_ExtraPerson1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Mess_ExtraPerson Where DocId = '" & SearchCode & "' "
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
            " From Mess_ExtraPerson H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                Call Validating_Controls(TxtSubCode)

                TxtFromDate.Text = Format(AgL.XNull(.Rows(0)("FromDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtToDate.Text = Format(AgL.XNull(.Rows(0)("ToDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtTotalDays.Text = AgL.VNull(.Rows(0)("TotalDays"))
                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                LblValTotalPerson.Text = AgL.VNull(.Rows(0)("TotalPerson"))

                mQry = "Select L.* " & _
                        " From Mess_ExtraPerson1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.Item(Col1PersonName, bIntI).Value = AgL.XNull(.Rows(bIntI)("PersonName"))
                            DGL1.Item(Col1Relation, bIntI).Value = AgL.XNull(.Rows(bIntI)("Relation"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)

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

        TxtFromDate.Text = TxtV_Date.Text
    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        '<Executbale Code>
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            mQry = "SELECT Distinct L.Relation AS Code, L.Relation AS Name FROM Mess_ExtraPerson1 L WITH (NoLock) WHERE IsNull(L.Relation,'') <> '' ORDER BY L.Relation "
            HelpDataSet.Relation = AgL.FillData(mQry, GcnRead)

            mQry = " SELECT H.SubCode AS Code, Sg.Name, H.MemberType AS [Member Type], " & _
                        " Sg.FatherName AS [Father Name], Sg.Mobile, " & _
                        " Sem.StreamYearSemesterDesc AS Semester, '' AS Designation,  " & _
                        " Sg.ManualCode AS [Member Code] , Sg.DispName AS [Display Name],  H.JoiningDate, H.InActiveDate, H.Student, H.Employee,  CASE WHEN H.InActiveDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS [Is Active]   " & _
                        " FROM (SELECT * FROM Mess_Member With (NoLock) WHERE Student IS NOT NULL) H   " & _
                        " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode   " & _
                        " LEFT JOIN Sch_Admission A WITH (NoLock) ON A.Student = H.Subcode  " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sem.Code = A.CurrentSemester " & _
                        " UNION ALL   " & _
                        " SELECT H.SubCode AS Code, Sg.Name, H.MemberType AS [Member Type],  " & _
                        " Sg.FatherName AS [Father Name], Sg.Mobile, " & _
                        " '' AS Semester, E.Designation, " & _
                        " Sg.ManualCode AS [Member Code] , Sg.DispName AS [Display Name],  H.JoiningDate, H.InActiveDate, H.Student, H.Employee,  CASE WHEN H.InActiveDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS [Is Active]   " & _
                        " FROM (SELECT * FROM Mess_Member With (NoLock) WHERE Employee IS NOT NULL) H   " & _
                        " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode   " & _
                        " LEFT JOIN Pay_Employee E With (NoLock) ON H.SubCode = E.SubCode " & _
                        " UNION ALL   " & _
                        " SELECT E.SubCode AS Code, Sg.Name, H.MemberType AS [Member Type],  " & _
                        " Sg.FatherName AS [Father Name], Sg.Mobile, " & _
                        " '' AS Semester, E.Designation, " & _
                        " Sg.ManualCode AS [Member Code], Sg.DispName AS [Display Name],  H.JoiningDate, H.InActiveDate, H.Student, H.Employee,  CASE WHEN E.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END AS [Is Active]  FROM Pay_Employee E With (NoLock)  LEFT JOIN (SELECT * FROM Mess_Member With (NoLock) WHERE Employee IS NOT NULL) As H ON H.SubCode = E.SubCode  LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = E.SubCode  " & _
                        " Where H.SubCode IS NULL "
            HelpDataSet.Member = AgL.FillData(mQry, GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSubCode.AgHelpDataSet(7, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Member.Copy

        DGL1.AgHelpDataSet(Col1Relation, 0, , , , True) = HelpDataSet.Relation.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer, bIntTotalDays As Integer = 0

        LblValTotalPerson.Text = 0
        TxtToDate.Text = ""

        If Val(TxtTotalDays.Text) > 0 Then
            bIntTotalDays = Val(Format(Val(TxtTotalDays.Text), "0"))
        End If

        If TxtFromDate.Text.Trim <> "" And bIntTotalDays > 0 Then
            TxtToDate.Text = DateAdd(DateInterval.Day, bIntTotalDays - 1, CDate(TxtFromDate.Text))
        End If

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1PersonName, bIntI).Value Is Nothing Then DGL1.Item(Col1PersonName, bIntI).Value = ""
            If DGL1.Item(Col1Relation, bIntI).Value Is Nothing Then DGL1.Item(Col1Relation, bIntI).Value = ""

            If DGL1.Item(Col1PersonName, bIntI).Value <> "" Then
                'Footer Calculation
                LblValTotalPerson.Text = Val(LblValTotalPerson.Text) + 1
            End If
        Next
    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtSubCode, LblSubCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtTotalDays, LblTotalDays.Text, True) Then Exit Function
            If AglObj.RequiredField(TxtFromDate, LblFromDate.Text) Then Exit Function
            If AglObj.RequiredField(TxtToDate, LblToDate.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1PersonName).Index) Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1PersonName, bIntI).Value Is Nothing Then DGL1.Item(Col1PersonName, bIntI).Value = ""
                If DGL1.Item(Col1Relation, bIntI).Value Is Nothing Then DGL1.Item(Col1Relation, bIntI).Value = ""

                If DGL1.Item(Col1PersonName, bIntI).Value <> "" Then
                    If DGL1.Item(Col1Relation, bIntI).Value.ToString.Trim = "" Then
                        MsgBox("Relation Is Required At Row No. : " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1Relation, bIntI) : DGL1.Focus() : Exit Function
                    End If
                End If
            Next

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Mess_ExtraPerson H With (NoLock) " & _
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

    Public Sub Form_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        LblValTotalPerson.Text = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtRemark.Enter, TxtSubCode.Enter
        Try
            Select Case sender.name
                Case TxtSubCode.Name
                    TxtSubCode.AgRowFilter = " [Is Active] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, _
        TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, _
        TxtFromDate.Validating, TxtToDate.Validating, TxtTotalDays.Validating, TxtSubCode.Validating

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
            Case TxtSubCode.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtMemberType.Text = ""
                    TxtFatherName.Text = ""
                    TxtMobile.Text = ""
                    TxtCurrentSemester.Text = ""
                    TxtDesignation.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        TxtMemberType.Text = AgL.XNull(DrTemp(0)("Member Type"))
                        TxtFatherName.Text = AgL.XNull(DrTemp(0)("Father Name"))
                        TxtMobile.Text = AgL.XNull(DrTemp(0)("Mobile"))
                        TxtCurrentSemester.Text = AgL.XNull(DrTemp(0)("Semester"))
                        TxtDesignation.Text = AgL.XNull(DrTemp(0)("Designation"))
                    End If
                End If
                DrTemp = Nothing
        End Select

    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.
        TxtMemberType.Enabled = False
        TxtFatherName.Enabled = False
        TxtMobile.Enabled = False
        TxtCurrentSemester.Enabled = False
        TxtDesignation.Enabled = False


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
                'Case ColumnIndex
                '<Executable Code>
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
                    'Case ColumnIndex
                    '<Executable Code>
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
End Class
