Imports System.Data.SqlClient

Public Class FrmAttendanceEntry
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1Member As String = "Member Name"
    Protected Const Col1MemberType As String = "Member Type"
    Protected Const Col1IsPresent As String = "Is Present"
    Protected Const Col1OnLeaveYesNo As String = "On Leave"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Dim EconAtt As New SqlConnection
    Dim StrTblParam As String = ""
    Dim StrTblParamIni As String = " Declare @TblParm AS Table(AttendanceDate SmallDateTime, " & _
                                 " AttendanceCode nvarchar(20) )"

    Dim mBlnImportFlag As Boolean = False

#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel


    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Friend WithEvents LblShiftReq As System.Windows.Forms.Label
    Friend WithEvents TxtShift As AgControls.AgTextBox
    Friend WithEvents LblShift As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LblValTotalMember As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalMember As System.Windows.Forms.Label
    Protected WithEvents LblValTotalPresent As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalPresent As System.Windows.Forms.Label
    Protected WithEvents LblValTotalAbsent As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalAbsent As System.Windows.Forms.Label
    Protected WithEvents LblRefNoPrefix As System.Windows.Forms.Label
    Public WithEvents GBoxImportFromExcel As System.Windows.Forms.GroupBox
    Friend WithEvents TxtToDate As AgControls.AgTextBox
    Public WithEvents BtnImprtFromDB As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFromDate As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalMember = New System.Windows.Forms.Label
        Me.LblTextTotalMember = New System.Windows.Forms.Label
        Me.LblValTotalPresent = New System.Windows.Forms.Label
        Me.LblTextTotalPresent = New System.Windows.Forms.Label
        Me.LblValTotalAbsent = New System.Windows.Forms.Label
        Me.LblTextTotalAbsent = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblShiftReq = New System.Windows.Forms.Label
        Me.TxtShift = New AgControls.AgTextBox
        Me.LblShift = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblRefNoPrefix = New System.Windows.Forms.Label
        Me.GBoxImportFromExcel = New System.Windows.Forms.GroupBox
        Me.TxtToDate = New AgControls.AgTextBox
        Me.BtnImprtFromDB = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        Me.GBoxImportFromExcel.SuspendLayout()
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
        Me.TxtDocId.Location = New System.Drawing.Point(790, 0)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(851, 8)
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(957, 6)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(365, 54)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(252, 50)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(364, 34)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(381, 48)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(252, 29)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(381, 28)
        Me.TxtV_Type.Size = New System.Drawing.Size(350, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(365, 14)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(252, 9)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(381, 8)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(743, 2)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(918, 7)
        Me.LblPrefix.Visible = False
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 142)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.LblRefNoPrefix)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.TxtShift)
        Me.TP1.Controls.Add(Me.LblShiftReq)
        Me.TP1.Controls.Add(Me.LblShift)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 114)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblShift, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblShiftReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShift, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRefNoPrefix, 0)
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
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
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
        Me.TxtRemark.Location = New System.Drawing.Point(381, 88)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 5
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(252, 90)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(198, 186)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(556, 335)
        Me.Pnl1.TabIndex = 2
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(598, 54)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 771
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(611, 48)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(120, 18)
        Me.TxtReferenceNo.TabIndex = 3
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(506, 49)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalMember)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalMember)
        Me.PnlFooter.Controls.Add(Me.LblValTotalPresent)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalPresent)
        Me.PnlFooter.Controls.Add(Me.LblValTotalAbsent)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalAbsent)
        Me.PnlFooter.Location = New System.Drawing.Point(198, 521)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(556, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LblValTotalMember
        '
        Me.LblValTotalMember.AutoSize = True
        Me.LblValTotalMember.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalMember.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalMember.Location = New System.Drawing.Point(122, 4)
        Me.LblValTotalMember.Name = "LblValTotalMember"
        Me.LblValTotalMember.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalMember.TabIndex = 680
        Me.LblValTotalMember.Text = "."
        Me.LblValTotalMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalMember
        '
        Me.LblTextTotalMember.AutoSize = True
        Me.LblTextTotalMember.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalMember.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalMember.Location = New System.Drawing.Point(13, 4)
        Me.LblTextTotalMember.Name = "LblTextTotalMember"
        Me.LblTextTotalMember.Size = New System.Drawing.Size(108, 16)
        Me.LblTextTotalMember.TabIndex = 679
        Me.LblTextTotalMember.Text = "Total Member  :"
        '
        'LblValTotalPresent
        '
        Me.LblValTotalPresent.AutoSize = True
        Me.LblValTotalPresent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalPresent.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalPresent.Location = New System.Drawing.Point(329, 4)
        Me.LblValTotalPresent.Name = "LblValTotalPresent"
        Me.LblValTotalPresent.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalPresent.TabIndex = 678
        Me.LblValTotalPresent.Text = "."
        Me.LblValTotalPresent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalPresent
        '
        Me.LblTextTotalPresent.AutoSize = True
        Me.LblTextTotalPresent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalPresent.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalPresent.Location = New System.Drawing.Point(219, 4)
        Me.LblTextTotalPresent.Name = "LblTextTotalPresent"
        Me.LblTextTotalPresent.Size = New System.Drawing.Size(104, 16)
        Me.LblTextTotalPresent.TabIndex = 677
        Me.LblTextTotalPresent.Text = "Total Present  :"
        '
        'LblValTotalAbsent
        '
        Me.LblValTotalAbsent.AutoSize = True
        Me.LblValTotalAbsent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalAbsent.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalAbsent.Location = New System.Drawing.Point(504, 4)
        Me.LblValTotalAbsent.Name = "LblValTotalAbsent"
        Me.LblValTotalAbsent.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalAbsent.TabIndex = 676
        Me.LblValTotalAbsent.Text = "."
        Me.LblValTotalAbsent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalAbsent
        '
        Me.LblTextTotalAbsent.AutoSize = True
        Me.LblTextTotalAbsent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalAbsent.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalAbsent.Location = New System.Drawing.Point(411, 5)
        Me.LblTextTotalAbsent.Name = "LblTextTotalAbsent"
        Me.LblTextTotalAbsent.Size = New System.Drawing.Size(95, 16)
        Me.LblTextTotalAbsent.TabIndex = 675
        Me.LblTextTotalAbsent.Text = "Total Absent :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(197, 163)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(83, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Member List:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblShiftReq
        '
        Me.LblShiftReq.AutoSize = True
        Me.LblShiftReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblShiftReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblShiftReq.Location = New System.Drawing.Point(365, 74)
        Me.LblShiftReq.Name = "LblShiftReq"
        Me.LblShiftReq.Size = New System.Drawing.Size(10, 7)
        Me.LblShiftReq.TabIndex = 777
        Me.LblShiftReq.Text = "Ä"
        '
        'TxtShift
        '
        Me.TxtShift.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtShift.Location = New System.Drawing.Point(381, 68)
        Me.TxtShift.MaxLength = 0
        Me.TxtShift.Name = "TxtShift"
        Me.TxtShift.Size = New System.Drawing.Size(120, 18)
        Me.TxtShift.TabIndex = 4
        '
        'LblShift
        '
        Me.LblShift.AutoSize = True
        Me.LblShift.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShift.Location = New System.Drawing.Point(252, 70)
        Me.LblShift.Name = "LblShift"
        Me.LblShift.Size = New System.Drawing.Size(31, 15)
        Me.LblShift.TabIndex = 776
        Me.LblShift.Text = "Shift"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnFill.Location = New System.Drawing.Point(654, 160)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 25)
        Me.BtnFill.TabIndex = 1
        Me.BtnFill.TabStop = False
        Me.BtnFill.Text = "Fill Data"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblRefNoPrefix
        '
        Me.LblRefNoPrefix.AutoSize = True
        Me.LblRefNoPrefix.BackColor = System.Drawing.Color.Transparent
        Me.LblRefNoPrefix.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefNoPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblRefNoPrefix.Location = New System.Drawing.Point(737, 50)
        Me.LblRefNoPrefix.Name = "LblRefNoPrefix"
        Me.LblRefNoPrefix.Size = New System.Drawing.Size(76, 16)
        Me.LblRefNoPrefix.TabIndex = 778
        Me.LblRefNoPrefix.Text = "RefNoPrefix"
        Me.LblRefNoPrefix.Visible = False
        '
        'GBoxImportFromExcel
        '
        Me.GBoxImportFromExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxImportFromExcel.BackColor = System.Drawing.Color.Transparent
        Me.GBoxImportFromExcel.Controls.Add(Me.TxtToDate)
        Me.GBoxImportFromExcel.Controls.Add(Me.BtnImprtFromDB)
        Me.GBoxImportFromExcel.Controls.Add(Me.Label1)
        Me.GBoxImportFromExcel.Controls.Add(Me.TxtFromDate)
        Me.GBoxImportFromExcel.Controls.Add(Me.Label3)
        Me.GBoxImportFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxImportFromExcel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxImportFromExcel.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxImportFromExcel.Location = New System.Drawing.Point(760, 186)
        Me.GBoxImportFromExcel.Name = "GBoxImportFromExcel"
        Me.GBoxImportFromExcel.Size = New System.Drawing.Size(221, 64)
        Me.GBoxImportFromExcel.TabIndex = 904
        Me.GBoxImportFromExcel.TabStop = False
        Me.GBoxImportFromExcel.Tag = "UP"
        Me.GBoxImportFromExcel.Text = "Import"
        '
        'TxtToDate
        '
        Me.TxtToDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtToDate.AgMandatory = True
        Me.TxtToDate.AgMasterHelp = False
        Me.TxtToDate.AgNumberLeftPlaces = 0
        Me.TxtToDate.AgNumberNegetiveAllow = False
        Me.TxtToDate.AgNumberRightPlaces = 0
        Me.TxtToDate.AgPickFromLastValue = False
        Me.TxtToDate.AgRowFilter = ""
        Me.TxtToDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToDate.AgSelectedValue = Nothing
        Me.TxtToDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtToDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToDate.Location = New System.Drawing.Point(69, 38)
        Me.TxtToDate.MaxLength = 11
        Me.TxtToDate.Name = "TxtToDate"
        Me.TxtToDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtToDate.TabIndex = 1
        '
        'BtnImprtFromDB
        '
        Me.BtnImprtFromDB.BackColor = System.Drawing.Color.White
        Me.BtnImprtFromDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprtFromDB.Image = Global.Academic_Mess.My.Resources.Resources.update_database
        Me.BtnImprtFromDB.Location = New System.Drawing.Point(176, 19)
        Me.BtnImprtFromDB.Name = "BtnImprtFromDB"
        Me.BtnImprtFromDB.Size = New System.Drawing.Size(36, 34)
        Me.BtnImprtFromDB.TabIndex = 2
        Me.BtnImprtFromDB.TabStop = False
        Me.BtnImprtFromDB.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 907
        Me.Label1.Text = "To Date "
        '
        'TxtFromDate
        '
        Me.TxtFromDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtFromDate.AgMandatory = True
        Me.TxtFromDate.AgMasterHelp = False
        Me.TxtFromDate.AgNumberLeftPlaces = 0
        Me.TxtFromDate.AgNumberNegetiveAllow = False
        Me.TxtFromDate.AgNumberRightPlaces = 0
        Me.TxtFromDate.AgPickFromLastValue = False
        Me.TxtFromDate.AgRowFilter = ""
        Me.TxtFromDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFromDate.AgSelectedValue = Nothing
        Me.TxtFromDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFromDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFromDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromDate.Location = New System.Drawing.Point(69, 18)
        Me.TxtFromDate.MaxLength = 11
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtFromDate.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 905
        Me.Label3.Text = "From Date"
        '
        'FrmAttendanceEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.GBoxImportFromExcel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmAttendanceEntry"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.GBoxImportFromExcel, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
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
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.GBoxImportFromExcel.ResumeLayout(False)
        Me.GBoxImportFromExcel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.MessMemberAttendance) & ""
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
        Public Shared Shift As DataSet = Nothing
        Public Shared Member As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Mess_Attendance"
        AglObj = AgL

        LblV_Type.Text = "Attendance Type"
        LblV_Date.Text = "Attendance Date"
        LblV_No.Text = "Entry No."
        TP1.Text = "Attendance Detail"

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
                " From Mess_Attendance H With (NoLock) " & _
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
                            " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " H.Shift As [" & LblShift.Text & "], " & _
                            " S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Mess_Attendance H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, [" & LblShift.Text & "]"

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Member, 300, 0, Col1Member, True, True, False)
            .AddAgTextColumn(DGL1, Col1MemberType, 100, 0, Col1MemberType, True, True, False)
            .AddAgCheckColumn(DGL1, Col1IsPresent, 50, Col1IsPresent, True)
            .AddAgTextColumn(DGL1, Col1OnLeaveYesNo, 40, 3, Col1OnLeaveYesNo, True, True, False)
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

        mQry = "UPDATE dbo.Mess_Attendance " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " RefNoPrefix = " & AgL.Chk_Text(LblRefNoPrefix.Text) & ", " & _
                " RefNoSr = " & AgL.Chk_Text(LblRefNoPrefix.Tag) & ", " & _
                " Shift = " & AgL.Chk_Text(TxtShift.AgSelectedValue) & ", " & _
                " TotalMember =" & Val(LblValTotalMember.Text) & ", " & _
                " TotalPresent = " & Val(LblValTotalPresent.Text) & ", " & _
                " TotalAbsent = " & Val(LblValTotalAbsent.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Mess_Attendance1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Member, bIntI).Value <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Mess_Attendance1 ( " & _
                        " DocId, Sr, Member, IsPresent) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Member, bIntI)) & ", " & _
                        " " & IIf(AgL.StrCmp(DGL1.Item(Col1IsPresent, bIntI).Value.ToString, AgLibrary.ClsConstant.StrCheckedValue), 1, 0) & " " & _
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
        mQry = "Delete From Mess_Attendance1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Mess_Attendance Where DocId = '" & SearchCode & "' "
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
            " From Mess_Attendance H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtShift.AgSelectedValue = AgL.XNull(.Rows(0)("Shift"))
                LblRefNoPrefix.Text = AgL.XNull(.Rows(0)("RefNoPrefix"))
                LblRefNoPrefix.Tag = AgL.VNull(.Rows(0)("RefNoSr"))

                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                LblValTotalMember.Text = AgL.VNull(.Rows(0)("TotalMember"))
                LblValTotalPresent.Text = AgL.VNull(.Rows(0)("TotalPresent"))
                LblValTotalAbsent.Text = AgL.VNull(.Rows(0)("TotalAbsent"))


                mQry = "Select L.* " & _
                        " From Mess_Attendance1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.AgSelectedValue(Col1Member, bIntI) = AgL.XNull(.Rows(bIntI)("Member"))
                            DrTemp = DGL1.AgHelpDataSet(Col1Member).Tables(0).Select("Code = " & AglObj.Chk_Text(AgL.XNull(.Rows(bIntI)("Member"))) & "")
                            If DrTemp.Length > 0 Then
                                DGL1.Item(Col1MemberType, bIntI).Value = AgL.XNull(DrTemp(0)("MemberType"))
                            End If

                            DGL1.Item(Col1IsPresent, bIntI).Value = IIf(AgL.VNull(.Rows(bIntI)("IsPresent")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)
                            DGL1.Item(Col1OnLeaveYesNo, bIntI).Value = IIf(FunIsMemberOnLeave(AgL.XNull(.Rows(bIntI)("Member")), TxtV_Date.Text), "Yes", "No")

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

    Private Sub FrmAttendanceEntry_BaseFunction_PostMoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_PostMoveRec
        TxtFromDate.Enabled = BtnImprtFromDB.Enabled
        TxtToDate.Enabled = BtnImprtFromDB.Enabled
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
            mQry = "SELECT W.Code , W.Code  FROM Mess_Shift W ORDER BY W.Code "
            HelpDataSet.Shift = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT H.SubCode AS Code, Sg.Name, Sg.ManualCode AS [Member Code] , Sg.DispName AS [Display Name], " & _
                    " H.JoiningDate, H.InActiveDate, H.MemberType, H.Student, H.Employee, " & _
                    " CASE WHEN H.InActiveDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS [Is Active] " & _
                    " FROM Mess_Member H With (NoLock)  " & _
                    " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode " & _
                    " ORDER BY Sg.Name "
            HelpDataSet.Member = AgL.FillData(mQry, GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtShift.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Shift.Copy

        DGL1.AgHelpDataSet(Col1Member, 8) = HelpDataSet.Member.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer

        LblValTotalMember.Text = 0
        LblValTotalPresent.Text = 0
        LblValTotalAbsent.Text = 0

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Member, bIntI).Value Is Nothing Then DGL1.Item(Col1Member, bIntI).Value = ""
            If DGL1.Item(Col1IsPresent, bIntI).Value Is Nothing Then DGL1.Item(Col1IsPresent, bIntI).Value = ""
            If DGL1.Item(Col1IsPresent, bIntI).Value.ToString.Trim = "" Then DGL1.Item(Col1IsPresent, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

            If DGL1.Item(Col1Member, bIntI).Value <> "" Then
                'Footer Calculation

                LblValTotalMember.Text = Val(LblValTotalMember.Text) + 1

                If AgL.StrCmp(DGL1.Item(Col1IsPresent, bIntI).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                    LblValTotalPresent.Text = Val(LblValTotalPresent.Text) + 1
                Else
                    LblValTotalAbsent.Text = Val(LblValTotalAbsent.Text) + 1
                End If
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
            If AglObj.RequiredField(TxtShift, LblShift.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Member).Index) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, DGL1.Columns(Col1Member).Index) Then Exit Function
            With DGL1
                For bIntI = 0 To .Rows.Count - 1
                    If .Item(Col1Member, bIntI).Value.ToString.Trim <> "" Then

                        If AgL.StrCmp(.Item(Col1OnLeaveYesNo, bIntI).Value.ToString, "Yes") And _
                            AgL.StrCmp(.Item(Col1IsPresent, bIntI).Value, AgLibrary.ClsConstant.StrCheckedValue) Then

                            If MsgBox("" & .Item(Col1Member, bIntI).Value & " Is On Leave!..." & vbCrLf & "Want To Check Attendance?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Validation Check") = MsgBoxResult.No Then
                                DGL1.CurrentCell = DGL1(Col1IsPresent, bIntI)
                                DGL1.Focus() : Exit Function
                            End If
                        End If
                    End If
                Next
            End With

            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM Mess_Attendance H " & _
                    " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                    " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                    " And H.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    " AND " & IIf(AgL.VNull(DtMess_Enviro.Rows(0)("IsShiftAttendance")), " H.Shift = " & AgL.Chk_Text(TxtShift.AgSelectedValue) & "", " 1=1 ") & " " & _
                    " AND H.V_Date = " & AgL.Chk_Text(TxtV_Date.Text) & " " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
            If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                MsgBox("Attendance Already Exists!...")
                TxtV_Date.Focus() : Exit Function
            End If

            Call ProcFillReferenceNo() : If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Mess_Attendance H With (NoLock) " & _
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
        LblValTotalMember.Text = 0 : LblValTotalPresent.Text = 0 : LblValTotalAbsent.Text = 0

        LblRefNoPrefix.Text = "" : LblRefNoPrefix.Tag = ""

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

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtShift.Validating, TxtRemark.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
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
        BtnFill.Enabled = Enb

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
                Case Col1Member
                    DGL1.AgRowFilter(mColumnIndex) = " [Is Active] = 'Yes' "
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
                    Case Col1Member
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            DGL1.Item(Col1MemberType, mRowIndex).Value = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.Item(Col1MemberType, mRowIndex).Value = AgL.XNull(DrTemp(0)("MemberType"))
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

    Private Sub DGL1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            If DGL1.CurrentCell Is Nothing Then Exit Sub

            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1IsPresent
                        Call Calculation()
                End Select
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Try
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1IsPresent
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, DGL1.Columns(Col1IsPresent).Index)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1IsPresent
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, DGL1.Columns(Col1IsPresent).Index)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGL1.CellFormatting
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = e.RowIndex
            mColumnIndex = e.ColumnIndex

            If DGL1.Item(Col1IsPresent, mRowIndex).Value Is Nothing Then DGL1.Item(Col1IsPresent, mRowIndex).Value = ""
            If DGL1.Item(Col1IsPresent, mRowIndex).Value.ToString.Trim = "" Then DGL1.Item(Col1IsPresent, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue


            DGL1.Item(Col1IsPresent, mRowIndex).Style.BackColor = Color.White
            If DGL1.Item(Col1IsPresent, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                DGL1.Item(Col1IsPresent, mRowIndex).Style.ForeColor = Color.Blue
            Else
                DGL1.Item(Col1IsPresent, mRowIndex).Style.ForeColor = Color.Red
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        Try
            sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
        Catch ex As Exception

        End Try
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
        Dim bLongMaxId As Long = 0

        If AgL.XNull(TxtSite_Code.AgSelectedValue).ToString.Trim <> "" _
                 And AgL.XNull(TxtV_Date.Text).ToString.Trim <> "" Then

            LblRefNoPrefix.Text = CDate(TxtV_Date.Text).ToString("ddMMyyyy")

            mQry = "SELECT IsNull(Max(H.RefNoSr),0) + 1 As MaxId " & _
                    " FROM Mess_Attendance H WITH (NoLock) " & _
                    " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                    " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                    " And H.RefNoPrefix = " & AgL.Chk_Text(LblRefNoPrefix.Text) & " " & _
                    " AND H.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
            bLongMaxId = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

            TxtReferenceNo.Text = LblRefNoPrefix.Text + "-" + bLongMaxId.ToString
            LblReferenceNo.Tag = TxtReferenceNo.Text
            LblRefNoPrefix.Tag = bLongMaxId
        End If
    End Sub


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        Try
            Select Case sender.Name
                Case BtnFill.Name
                    Call ProcFillData()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillData()
        Dim bIntI As Integer = 0
        Dim bDtTemp As DataTable = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor

            mQry = "SELECT M.SubCode As Member, M.MemberType " & _
                    " FROM Mess_Member M With (NoLock) " & _
                    " WHERE " & AgL.Chk_Text(TxtV_Date.Text) & " >= M.JoiningDate " & _
                    " AND IsNull(M.InActiveDate, " & AgL.Chk_Text(TxtV_Date.Text) & ") <= " & AgL.Chk_Text(TxtV_Date.Text) & ""
            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            With bDtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If bDtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To bDtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                        DGL1.AgSelectedValue(Col1Member, bIntI) = AgL.XNull(.Rows(bIntI)("Member"))
                        DGL1.Item(Col1MemberType, bIntI).Value = AgL.XNull(.Rows(bIntI)("MemberType"))


                        If FunIsMemberOnLeave(AgL.XNull(.Rows(bIntI)("Member")), TxtV_Date.Text) Then
                            DGL1.Item(Col1IsPresent, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                            DGL1.Item(Col1OnLeaveYesNo, bIntI).Value = "Yes"
                        Else
                            DGL1.Item(Col1IsPresent, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue
                            DGL1.Item(Col1OnLeaveYesNo, bIntI).Value = "No"
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

    Private Function FunIsMemberOnLeave(ByVal StrMemberCode As String, ByVal StrDate As String) As Boolean
        Dim bBlnReturn As Boolean = False
        Try
            mQry = "SELECT IsNull(COUNT(*),0) AS Cnt " & _
                    " FROM Mess_Leave L WITH (NoLock) " & _
                    " WHERE 1=1 " & _
                    " AND L.Member = " & AgL.Chk_Text(StrMemberCode) & " " & _
                    " AND " & AgL.Chk_Text(StrDate) & " BETWEEN L.FromDate AND L.ToDate  "
            If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                bBlnReturn = True
            Else
                bBlnReturn = False
            End If
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunIsMemberOnLeave = bBlnReturn
        End Try
    End Function


    Private Sub BtnImprtFromDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromDB.Click
        Dim DsHeader As New DataSet
        Dim DsLine As New DataSet
        Dim DsAtt As New DataSet
        Dim J As Integer = 0
        Dim I As Integer = 0
        Dim Ds1 As New DataSet
        Dim DrTemp As DataRow() = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            mBlnImportFlag = True

            If Not FunConnectDB(AgL.XNull(DtMess_Enviro.Rows(0)("AttendanceUser")), _
                      AgL.XNull(DtMess_Enviro.Rows(0)("AttendancePassword")), _
                      AgL.XNull(DtMess_Enviro.Rows(0)("AttendanceDbName")), _
                      AgL.XNull(DtMess_Enviro.Rows(0)("AttendanceServer"))) Then

                Err.Raise(1, , "Error in establishing Connection With Attendance Database!...")
            End If

            If AgL.RequiredField(TxtFromDate, "From Date") Then Exit Sub
            If AgL.RequiredField(TxtToDate, "To Date") Then Exit Sub


            'Fetch Data**************
            mQry = "SELECT A.EmployeeId AS AttendanceCode , " & _
                    " Convert(SMALLDATETIME,Convert(VARCHAR,convert(SMALLDATETIME,A.InTime),106)) AS AttendanceDate" & _
                    " FROM AttendanceLogs A" & _
                    " WHERE(A.InTime Is Not NULL) AND Convert(SMALLDATETIME,Convert(VARCHAR,convert(SMALLDATETIME,A.InTime),106)) BETWEEN '" & TxtFromDate.Text & "' AND '" & TxtToDate.Text & "'"
            DsAtt = AgL.FillData(mQry, EconAtt)
            If DsAtt.Tables(0).Rows.Count > 0 Then

                'Insert Temp Table*****************
                StrTblParam = StrTblParamIni
                For I = 0 To DsAtt.Tables(0).Rows.Count - 1
                    StrTblParam += " INSERT INTO @TblParm  ( AttendanceDate, AttendanceCode) " & _
                                    " VALUES ( '" & Format(DsAtt.Tables(0).Rows(I).Item("AttendanceDate"), AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                                    " " & AgL.Chk_Text(DsAtt.Tables(0).Rows(I).Item("AttendanceCode")) & " " & _
                                    " ) "

                Next

                'Fetch Header Data*****************
                mQry = StrTblParam & _
                        " SELECT Sg.Site_Code, T.AttendanceDate " & _
                        " " & _
                        " FROM Mess_Member E " & _
                        " LEFT JOIN SubGroup Sg WITH (NoLock) ON E.SubCode = Sg.SubCode " & _
                        " LEFT JOIN @TblParm T  ON E.MessAttendanceCode = T.AttendanceCode " & _
                        " Where sg.site_Code='" & AgL.PubSiteCode & "' AND T.AttendanceDate IS NOT NULL " & _
                        " Group By Sg.Site_Code, T.AttendanceDate " & _
                        " Order By Sg.Site_Code, T.AttendanceDate "
                DsHeader = AgL.FillData(mQry, AgL.GCn)
                If DsHeader.Tables(0).Rows.Count > 0 Then
                    For J = 0 To DsHeader.Tables(0).Rows.Count - 1
                        ''===========< Add >=======
                        Topctrl1.FButtonClick(0)
                        ''=========================

                        TxtSite_Code.AgSelectedValue = AgL.XNull(DsHeader.Tables(0).Rows(J)("Site_Code"))
                        TxtV_Date.Text = Format(AgL.XNull(DsHeader.Tables(0).Rows(J)("AttendanceDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        If TxtShift.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtShift.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtShift.AgHelpDataSet.Tables(0).Rows(0)("Code")) & "")
                            If DrTemp.Length > 0 Then
                                TxtShift.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                            End If
                        End If

                        'Fetch Line Data*****************
                        mQry = StrTblParam & _
                                " SELECT E.SubCode As Member, Max(E.MemberType) As MemberType, Sg.Site_Code, T.AttendanceCode, T.AttendanceDate, " & _
                                " Convert(bit,Case When T.AttendanceCode Is Null Then 0 Else 1 End) As IsPresent " & _
                                " FROM Mess_Member E " & _
                                " LEFT JOIN SubGroup Sg WITH (NoLock) ON E.SubCode = Sg.SubCode " & _
                                " LEFT JOIN @TblParm T ON E.MessAttendanceCode = T.AttendanceCode " & _
                                " Where sg.site_Code='" & AgL.XNull(DsHeader.Tables(0).Rows(J)("Site_Code")) & "' " & _
                                " and T.AttendanceDate='" & Format(AgL.XNull(DsHeader.Tables(0).Rows(J)("AttendanceDate")), AgLibrary.ClsConstant.DateFormat_ShortDate) & "' " & _
                                " Group By Sg.Site_Code, T.AttendanceDate, E.SubCode, T.AttendanceCode "
                        DsLine = AgL.FillData(mQry, AgL.GCn)
                        DGL1.RowCount = 1 : DGL1.Rows.Clear()
                        If DsLine.Tables(0).Rows.Count > 0 Then
                            For I = 0 To DsLine.Tables(0).Rows.Count - 1
                                DGL1.Rows.Add()

                                DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count - 1

                                DGL1.AgSelectedValue(Col1Member, I) = AgL.XNull(DsLine.Tables(0).Rows(I)("Member"))
                                DGL1.Item(Col1MemberType, I).Value = AgL.XNull(DsLine.Tables(0).Rows(I)("MemberType"))

                                If AgL.VNull(DsLine.Tables(0).Rows(I)("IsPresent")) Then
                                    DGL1.Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                                Else
                                    DGL1.Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                                End If

                                If FunIsMemberOnLeave(AgL.XNull(DsLine.Tables(0).Rows(I)("Member")), TxtV_Date.Text) Then
                                    DGL1.Item(Col1OnLeaveYesNo, I).Value = "Yes"
                                Else
                                    DGL1.Item(Col1OnLeaveYesNo, I).Value = "No"
                                End If
                            Next I
                        End If

                        ''===========< Finally >==============
                        Topctrl1.FButtonClick(13)
                        ''===========< ******* >==============
                    Next
                End If
                MsgBox("Data Import Successfully...! ")
            Else
                MsgBox("No Record For Import...! ")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)            
        Finally
            mBlnImportFlag = False
            If EconAtt IsNot Nothing Then EconAtt.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function FunConnectDB(ByVal AttDBUserSQL As String, ByVal AttDBPasswordSQL As String, ByVal AttDBName As String, ByVal AttServerName As String) As Boolean
        Dim bBlnReturn As Boolean = False
        Try
            EconAtt.ConnectionString = "Persist Security Info=False;User ID='" & AttDBUserSQL & "';pwd=" & AttDBPasswordSQL & ";Initial Catalog=" & AttDBName & ";Data Source=" & AttServerName
            EconAtt.Open()

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunConnectDB = bBlnReturn
        End Try
    End Function

End Class
