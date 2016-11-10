Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmMemberAttendance
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S. No."
    Protected Const Col1Member As String = "Member"
    Protected Const Col1MemberCardNo As String = "Card No"
    Protected Const Col1IsPresent As String = "Is Present"
    Protected Const Col1IsUnRegistered As String = "Un-Reg."
    Protected Const Col1PickUpPoint As String = "Pick-Up Point"
    Protected Const Col1RouteCode As String = "Route Code"

    'Header Total From AgStructure
    Protected Const AgCalc_TotalLineAmount As String = "Gross Amount"
    Protected Const AgCalc_TotalLineAddition As String = "Addition"
    Protected Const AgCalc_TotalLineDeduction As String = "Deduction"
    Protected Const AgCalc_TotalLineNetAmount As String = "Net Amount"
    Protected Const AgCalc_NetSubTotal As String = "Sub Total"

    Protected WithEvents TxtRemark As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents LblValTotalAbsent As System.Windows.Forms.Label
    Protected WithEvents TxtRoute As AgControls.AgTextBox
    Protected WithEvents LblRoute As System.Windows.Forms.Label
    Protected WithEvents LblVehicleNoReq As System.Windows.Forms.Label
    Protected WithEvents LblVehicleName As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleName As AgControls.AgTextBox
    Protected WithEvents LblVehicleNo As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleNo As AgControls.AgTextBox
    Protected WithEvents LblDriver As System.Windows.Forms.Label
    Protected WithEvents TxtDriver As AgControls.AgTextBox
    Protected WithEvents LblDriverReq As System.Windows.Forms.Label
    Protected WithEvents LblValTotalPresent As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalPresent As System.Windows.Forms.Label
    Protected WithEvents LblValTotalMember As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalMember As System.Windows.Forms.Label
    Protected WithEvents LblGateInOutDocIdReq As System.Windows.Forms.Label
    Protected WithEvents TxtInOut As AgControls.AgTextBox
    Protected WithEvents LblGateInOutDocId As System.Windows.Forms.Label
    Protected WithEvents LblInOut As System.Windows.Forms.Label
    Protected WithEvents TxtGateInOutDocId As AgControls.AgTextBox
    Protected WithEvents LblInOutReq As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents TxtDateValue As AgControls.AgTextBox
    Protected WithEvents LblTextTotalAbsent As System.Windows.Forms.Label


    Public Class HelpDataSet
        Public Shared Driver As DataSet = Nothing
        Public Shared Route As DataSet = Nothing
        Public Shared PickupPoint As DataSet = Nothing
        Public Shared Member As DataSet = Nothing
        Public Shared Vehicle As DataSet = Nothing
        Public Shared GateDocInOutDocId As DataSet = Nothing
        Public Shared InOut As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
    End Class

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.TransportMemberAttendance
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblValTotalMember = New System.Windows.Forms.Label
        Me.LblTextTotalMember = New System.Windows.Forms.Label
        Me.LblValTotalPresent = New System.Windows.Forms.Label
        Me.LblTextTotalPresent = New System.Windows.Forms.Label
        Me.LblValTotalAbsent = New System.Windows.Forms.Label
        Me.LblTextTotalAbsent = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.TxtRoute = New AgControls.AgTextBox
        Me.LblRoute = New System.Windows.Forms.Label
        Me.LblVehicleNoReq = New System.Windows.Forms.Label
        Me.LblVehicleName = New System.Windows.Forms.Label
        Me.TxtVehicleName = New AgControls.AgTextBox
        Me.LblVehicleNo = New System.Windows.Forms.Label
        Me.TxtVehicleNo = New AgControls.AgTextBox
        Me.LblDriver = New System.Windows.Forms.Label
        Me.TxtDriver = New AgControls.AgTextBox
        Me.LblDriverReq = New System.Windows.Forms.Label
        Me.LblGateInOutDocIdReq = New System.Windows.Forms.Label
        Me.LblGateInOutDocId = New System.Windows.Forms.Label
        Me.TxtGateInOutDocId = New AgControls.AgTextBox
        Me.LblInOutReq = New System.Windows.Forms.Label
        Me.TxtInOut = New AgControls.AgTextBox
        Me.LblInOut = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.TxtDateValue = New AgControls.AgTextBox
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(830, 558)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 558)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 558)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(289, 558)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 558)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 554)
        Me.GroupBox1.Size = New System.Drawing.Size(1022, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(562, 558)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
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
        Me.LblV_No.Location = New System.Drawing.Point(743, 101)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(851, 100)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 34)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(15, 29)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(821, 86)
        Me.LblV_TypeReq.Tag = ""
        Me.LblV_TypeReq.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(127, 28)
        Me.TxtV_Date.Size = New System.Drawing.Size(131, 18)
        Me.TxtV_Date.TabIndex = 1
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(743, 82)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(851, 80)
        Me.TxtV_Type.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        Me.TxtV_Type.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 14)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(15, 9)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(127, 8)
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(803, 101)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(4, 19)
        Me.TabControl1.Size = New System.Drawing.Size(992, 119)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtDateValue)
        Me.TP1.Controls.Add(Me.LblGateInOutDocIdReq)
        Me.TP1.Controls.Add(Me.LblDriver)
        Me.TP1.Controls.Add(Me.LblGateInOutDocId)
        Me.TP1.Controls.Add(Me.TxtInOut)
        Me.TP1.Controls.Add(Me.TxtGateInOutDocId)
        Me.TP1.Controls.Add(Me.TxtDriver)
        Me.TP1.Controls.Add(Me.LblInOut)
        Me.TP1.Controls.Add(Me.LblDriverReq)
        Me.TP1.Controls.Add(Me.TxtRoute)
        Me.TP1.Controls.Add(Me.LblInOutReq)
        Me.TP1.Controls.Add(Me.LblRoute)
        Me.TP1.Controls.Add(Me.LblVehicleNoReq)
        Me.TP1.Controls.Add(Me.LblVehicleName)
        Me.TP1.Controls.Add(Me.TxtVehicleName)
        Me.TP1.Controls.Add(Me.LblVehicleNo)
        Me.TP1.Controls.Add(Me.TxtVehicleNo)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(984, 93)
        Me.TP1.Text = "Tp1"
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVehicleNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVehicleNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVehicleName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVehicleName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVehicleNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRoute, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblInOutReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRoute, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDriverReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblInOut, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDriver, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGateInOutDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtInOut, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGateInOutDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDriver, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGateInOutDocIdReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDateValue, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1004, 41)
        Me.Topctrl1.TabIndex = 3
        '
        'Dgl1
        '
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblValTotalMember)
        Me.Panel1.Controls.Add(Me.LblTextTotalMember)
        Me.Panel1.Controls.Add(Me.LblValTotalPresent)
        Me.Panel1.Controls.Add(Me.LblTextTotalPresent)
        Me.Panel1.Controls.Add(Me.LblValTotalAbsent)
        Me.Panel1.Controls.Add(Me.LblTextTotalAbsent)
        Me.Panel1.Location = New System.Drawing.Point(191, 520)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(628, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblValTotalMember
        '
        Me.LblValTotalMember.AutoSize = True
        Me.LblValTotalMember.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalMember.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalMember.Location = New System.Drawing.Point(166, 3)
        Me.LblValTotalMember.Name = "LblValTotalMember"
        Me.LblValTotalMember.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalMember.TabIndex = 674
        Me.LblValTotalMember.Text = "."
        Me.LblValTotalMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalMember
        '
        Me.LblTextTotalMember.AutoSize = True
        Me.LblTextTotalMember.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalMember.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalMember.Location = New System.Drawing.Point(55, 3)
        Me.LblTextTotalMember.Name = "LblTextTotalMember"
        Me.LblTextTotalMember.Size = New System.Drawing.Size(112, 16)
        Me.LblTextTotalMember.TabIndex = 673
        Me.LblTextTotalMember.Text = "Total Member   :"
        '
        'LblValTotalPresent
        '
        Me.LblValTotalPresent.AutoSize = True
        Me.LblValTotalPresent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalPresent.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalPresent.Location = New System.Drawing.Point(372, 3)
        Me.LblValTotalPresent.Name = "LblValTotalPresent"
        Me.LblValTotalPresent.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalPresent.TabIndex = 672
        Me.LblValTotalPresent.Text = "."
        Me.LblValTotalPresent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalPresent
        '
        Me.LblTextTotalPresent.AutoSize = True
        Me.LblTextTotalPresent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalPresent.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalPresent.Location = New System.Drawing.Point(261, 3)
        Me.LblTextTotalPresent.Name = "LblTextTotalPresent"
        Me.LblTextTotalPresent.Size = New System.Drawing.Size(108, 16)
        Me.LblTextTotalPresent.TabIndex = 671
        Me.LblTextTotalPresent.Text = "Total Present   :"
        '
        'LblValTotalAbsent
        '
        Me.LblValTotalAbsent.AutoSize = True
        Me.LblValTotalAbsent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalAbsent.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalAbsent.Location = New System.Drawing.Point(586, 3)
        Me.LblValTotalAbsent.Name = "LblValTotalAbsent"
        Me.LblValTotalAbsent.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalAbsent.TabIndex = 670
        Me.LblValTotalAbsent.Text = "."
        Me.LblValTotalAbsent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalAbsent
        '
        Me.LblTextTotalAbsent.AutoSize = True
        Me.LblTextTotalAbsent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalAbsent.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalAbsent.Location = New System.Drawing.Point(485, 4)
        Me.LblTextTotalAbsent.Name = "LblTextTotalAbsent"
        Me.LblTextTotalAbsent.Size = New System.Drawing.Size(95, 16)
        Me.LblTextTotalAbsent.TabIndex = 669
        Me.LblTextTotalAbsent.Text = "Total Absent :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(191, 168)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(628, 352)
        Me.Pnl1.TabIndex = 2
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(352, 68)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtReferenceNo.TabIndex = 6
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(264, 68)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(55, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Ref. No."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(188, 145)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(103, 20)
        Me.LinkLabel1.TabIndex = 738
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Member List :"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(339, 75)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 738
        Me.LblReferenceNoReq.Text = "Ä"
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
        Me.TxtRemark.Location = New System.Drawing.Point(601, 48)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemark.TabIndex = 9
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(514, 49)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 767
        Me.LblRemark.Text = "Remark"
        '
        'TxtRoute
        '
        Me.TxtRoute.AgMandatory = False
        Me.TxtRoute.AgMasterHelp = False
        Me.TxtRoute.AgNumberLeftPlaces = 0
        Me.TxtRoute.AgNumberNegetiveAllow = False
        Me.TxtRoute.AgNumberRightPlaces = 0
        Me.TxtRoute.AgPickFromLastValue = False
        Me.TxtRoute.AgRowFilter = ""
        Me.TxtRoute.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoute.AgSelectedValue = Nothing
        Me.TxtRoute.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoute.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoute.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRoute.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoute.Location = New System.Drawing.Point(601, 8)
        Me.TxtRoute.MaxLength = 0
        Me.TxtRoute.Name = "TxtRoute"
        Me.TxtRoute.Size = New System.Drawing.Size(377, 18)
        Me.TxtRoute.TabIndex = 7
        '
        'LblRoute
        '
        Me.LblRoute.AutoSize = True
        Me.LblRoute.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoute.Location = New System.Drawing.Point(514, 10)
        Me.LblRoute.Name = "LblRoute"
        Me.LblRoute.Size = New System.Drawing.Size(40, 15)
        Me.LblRoute.TabIndex = 908
        Me.LblRoute.Text = "Route"
        '
        'LblVehicleNoReq
        '
        Me.LblVehicleNoReq.AutoSize = True
        Me.LblVehicleNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblVehicleNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblVehicleNoReq.Location = New System.Drawing.Point(339, 34)
        Me.LblVehicleNoReq.Name = "LblVehicleNoReq"
        Me.LblVehicleNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblVehicleNoReq.TabIndex = 906
        Me.LblVehicleNoReq.Text = "Ä"
        '
        'LblVehicleName
        '
        Me.LblVehicleName.AutoSize = True
        Me.LblVehicleName.BackColor = System.Drawing.Color.Transparent
        Me.LblVehicleName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleName.Location = New System.Drawing.Point(15, 50)
        Me.LblVehicleName.Name = "LblVehicleName"
        Me.LblVehicleName.Size = New System.Drawing.Size(84, 15)
        Me.LblVehicleName.TabIndex = 905
        Me.LblVehicleName.Text = "Vehicle Name"
        '
        'TxtVehicleName
        '
        Me.TxtVehicleName.AgMandatory = False
        Me.TxtVehicleName.AgMasterHelp = True
        Me.TxtVehicleName.AgNumberLeftPlaces = 8
        Me.TxtVehicleName.AgNumberNegetiveAllow = False
        Me.TxtVehicleName.AgNumberRightPlaces = 2
        Me.TxtVehicleName.AgPickFromLastValue = False
        Me.TxtVehicleName.AgRowFilter = ""
        Me.TxtVehicleName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleName.AgSelectedValue = Nothing
        Me.TxtVehicleName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleName.Location = New System.Drawing.Point(127, 48)
        Me.TxtVehicleName.MaxLength = 20
        Me.TxtVehicleName.Name = "TxtVehicleName"
        Me.TxtVehicleName.Size = New System.Drawing.Size(131, 18)
        Me.TxtVehicleName.TabIndex = 3
        '
        'LblVehicleNo
        '
        Me.LblVehicleNo.AutoSize = True
        Me.LblVehicleNo.BackColor = System.Drawing.Color.Transparent
        Me.LblVehicleNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleNo.Location = New System.Drawing.Point(264, 30)
        Me.LblVehicleNo.Name = "LblVehicleNo"
        Me.LblVehicleNo.Size = New System.Drawing.Size(69, 15)
        Me.LblVehicleNo.TabIndex = 904
        Me.LblVehicleNo.Text = "Vehicle No."
        '
        'TxtVehicleNo
        '
        Me.TxtVehicleNo.AgMandatory = True
        Me.TxtVehicleNo.AgMasterHelp = False
        Me.TxtVehicleNo.AgNumberLeftPlaces = 8
        Me.TxtVehicleNo.AgNumberNegetiveAllow = False
        Me.TxtVehicleNo.AgNumberRightPlaces = 2
        Me.TxtVehicleNo.AgPickFromLastValue = False
        Me.TxtVehicleNo.AgRowFilter = ""
        Me.TxtVehicleNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleNo.AgSelectedValue = Nothing
        Me.TxtVehicleNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleNo.Location = New System.Drawing.Point(352, 28)
        Me.TxtVehicleNo.MaxLength = 20
        Me.TxtVehicleNo.Name = "TxtVehicleNo"
        Me.TxtVehicleNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtVehicleNo.TabIndex = 2
        '
        'LblDriver
        '
        Me.LblDriver.AutoSize = True
        Me.LblDriver.BackColor = System.Drawing.Color.Transparent
        Me.LblDriver.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDriver.Location = New System.Drawing.Point(514, 30)
        Me.LblDriver.Name = "LblDriver"
        Me.LblDriver.Size = New System.Drawing.Size(39, 15)
        Me.LblDriver.TabIndex = 910
        Me.LblDriver.Text = "Driver"
        '
        'TxtDriver
        '
        Me.TxtDriver.AgMandatory = True
        Me.TxtDriver.AgMasterHelp = False
        Me.TxtDriver.AgNumberLeftPlaces = 8
        Me.TxtDriver.AgNumberNegetiveAllow = False
        Me.TxtDriver.AgNumberRightPlaces = 2
        Me.TxtDriver.AgPickFromLastValue = False
        Me.TxtDriver.AgRowFilter = ""
        Me.TxtDriver.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDriver.AgSelectedValue = Nothing
        Me.TxtDriver.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDriver.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDriver.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDriver.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDriver.Location = New System.Drawing.Point(601, 28)
        Me.TxtDriver.MaxLength = 50
        Me.TxtDriver.Name = "TxtDriver"
        Me.TxtDriver.Size = New System.Drawing.Size(377, 18)
        Me.TxtDriver.TabIndex = 8
        '
        'LblDriverReq
        '
        Me.LblDriverReq.AutoSize = True
        Me.LblDriverReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDriverReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDriverReq.Location = New System.Drawing.Point(585, 34)
        Me.LblDriverReq.Name = "LblDriverReq"
        Me.LblDriverReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDriverReq.TabIndex = 911
        Me.LblDriverReq.Text = "Ä"
        '
        'LblGateInOutDocIdReq
        '
        Me.LblGateInOutDocIdReq.AutoSize = True
        Me.LblGateInOutDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblGateInOutDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblGateInOutDocIdReq.Location = New System.Drawing.Point(111, 74)
        Me.LblGateInOutDocIdReq.Name = "LblGateInOutDocIdReq"
        Me.LblGateInOutDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblGateInOutDocIdReq.TabIndex = 917
        Me.LblGateInOutDocIdReq.Text = "Ä"
        '
        'LblGateInOutDocId
        '
        Me.LblGateInOutDocId.AutoSize = True
        Me.LblGateInOutDocId.BackColor = System.Drawing.Color.Transparent
        Me.LblGateInOutDocId.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGateInOutDocId.Location = New System.Drawing.Point(15, 69)
        Me.LblGateInOutDocId.Name = "LblGateInOutDocId"
        Me.LblGateInOutDocId.Size = New System.Drawing.Size(85, 15)
        Me.LblGateInOutDocId.TabIndex = 916
        Me.LblGateInOutDocId.Text = "Gate Entry No."
        '
        'TxtGateInOutDocId
        '
        Me.TxtGateInOutDocId.AgMandatory = True
        Me.TxtGateInOutDocId.AgMasterHelp = False
        Me.TxtGateInOutDocId.AgNumberLeftPlaces = 8
        Me.TxtGateInOutDocId.AgNumberNegetiveAllow = False
        Me.TxtGateInOutDocId.AgNumberRightPlaces = 2
        Me.TxtGateInOutDocId.AgPickFromLastValue = False
        Me.TxtGateInOutDocId.AgRowFilter = ""
        Me.TxtGateInOutDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGateInOutDocId.AgSelectedValue = Nothing
        Me.TxtGateInOutDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGateInOutDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGateInOutDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGateInOutDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGateInOutDocId.Location = New System.Drawing.Point(127, 68)
        Me.TxtGateInOutDocId.MaxLength = 20
        Me.TxtGateInOutDocId.Name = "TxtGateInOutDocId"
        Me.TxtGateInOutDocId.Size = New System.Drawing.Size(131, 18)
        Me.TxtGateInOutDocId.TabIndex = 5
        '
        'LblInOutReq
        '
        Me.LblInOutReq.AutoSize = True
        Me.LblInOutReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblInOutReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblInOutReq.Location = New System.Drawing.Point(339, 54)
        Me.LblInOutReq.Name = "LblInOutReq"
        Me.LblInOutReq.Size = New System.Drawing.Size(10, 7)
        Me.LblInOutReq.TabIndex = 915
        Me.LblInOutReq.Text = "Ä"
        '
        'TxtInOut
        '
        Me.TxtInOut.AgMandatory = True
        Me.TxtInOut.AgMasterHelp = False
        Me.TxtInOut.AgNumberLeftPlaces = 8
        Me.TxtInOut.AgNumberNegetiveAllow = False
        Me.TxtInOut.AgNumberRightPlaces = 2
        Me.TxtInOut.AgPickFromLastValue = False
        Me.TxtInOut.AgRowFilter = ""
        Me.TxtInOut.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInOut.AgSelectedValue = Nothing
        Me.TxtInOut.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInOut.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtInOut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInOut.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInOut.Location = New System.Drawing.Point(352, 48)
        Me.TxtInOut.MaxLength = 20
        Me.TxtInOut.Name = "TxtInOut"
        Me.TxtInOut.Size = New System.Drawing.Size(100, 18)
        Me.TxtInOut.TabIndex = 4
        '
        'LblInOut
        '
        Me.LblInOut.AutoSize = True
        Me.LblInOut.BackColor = System.Drawing.Color.Transparent
        Me.LblInOut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInOut.Location = New System.Drawing.Point(264, 50)
        Me.LblInOut.Name = "LblInOut"
        Me.LblInOut.Size = New System.Drawing.Size(45, 15)
        Me.LblInOut.TabIndex = 914
        Me.LblInOut.Text = "In / Out"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(716, 141)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(103, 26)
        Me.BtnFill.TabIndex = 1
        Me.BtnFill.Text = "&Fill Detail"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'TxtDateValue
        '
        Me.TxtDateValue.AgMandatory = True
        Me.TxtDateValue.AgMasterHelp = False
        Me.TxtDateValue.AgNumberLeftPlaces = 8
        Me.TxtDateValue.AgNumberNegetiveAllow = False
        Me.TxtDateValue.AgNumberRightPlaces = 2
        Me.TxtDateValue.AgPickFromLastValue = False
        Me.TxtDateValue.AgRowFilter = ""
        Me.TxtDateValue.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDateValue.AgSelectedValue = Nothing
        Me.TxtDateValue.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDateValue.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDateValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDateValue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDateValue.Location = New System.Drawing.Point(593, 72)
        Me.TxtDateValue.MaxLength = 20
        Me.TxtDateValue.Name = "TxtDateValue"
        Me.TxtDateValue.Size = New System.Drawing.Size(103, 18)
        Me.TxtDateValue.TabIndex = 918
        Me.TxtDateValue.Visible = False
        '
        'FrmMemberAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1004, 599)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmMemberAttendance"
        Me.Text = "Member Attendance"
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.BtnFill, 0)
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
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Tp_MemberAttendance"
        LogTableName = "Tp_MemberAttendance_Log"
        MainLineTableCsv = "Tp_MemberAttendance1"
        LogLineTableCsv = "Tp_MemberAttendance1_Log"

        LblV_Type.Text = "Attendance Type"
        LblV_Date.Text = "Attendance Date"
        LblV_No.Text = "Attendance No."
        TP1.Text = "Member Attendance"

        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From Tp_MemberAttendance H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select Convert(Varchar(36),UID) As SearchCode " & _
               " From Tp_MemberAttendance_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT Convert(varchar(36),H.Uid) as SearchCode, Vt.Description AS [" & LblV_Type.Text & "], " & _
                            " H.V_Date AS [" & LblV_Date.Text & "], " & _
                            " H.V_No AS [" & LblV_No.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " Sg.DispName As [" & LblDriver.Text & "],  " & _
                            " FROM Tp_MaintenanceExpenseEntry_Log H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg On H.Party = Sg.SubCode " & _
                            " Where H.EntryStatus = '" & AgTemplate.ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [" & LblV_Type.Text & "], " & _
                            " H.V_Date AS [" & LblV_Date.Text & "], " & _
                            " H.V_No AS [" & LblV_No.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " Sg.DispName As [" & LblDriver.Text & "],  " & _
                            " FROM Tp_MemberAttendance H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg On H.Party = Sg.SubCode " & _
                            " Where IsNull(H.IsDeleted,0)=0  " & mCondStr

        AgL.PubFindQryOrdBy = "Convert(SmallDateTime,[" & LblV_Date.Text & "])"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Member, 200, 0, Col1Member, True, False, False)
            .AddAgTextColumn(Dgl1, Col1MemberCardNo, 100, 0, Col1MemberCardNo, True, True, False)
            .AddAgCheckColumn(Dgl1, Col1IsPresent, 60, Col1IsPresent, True)
            .AddAgTextColumn(Dgl1, Col1IsUnRegistered, 60, 0, Col1IsUnRegistered, True, True, False)
            .AddAgTextColumn(Dgl1, Col1PickUpPoint, 150, 0, Col1PickUpPoint, True, False, False)
            .AddAgTextColumn(Dgl1, Col1RouteCode, 80, 0, Col1RouteCode, False, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 40
        Dgl1.AgSkipReadOnlyColumns = True


        FrmSaleOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI%, bIntSr%

        mQry = "UPDATE dbo.Tp_MemberAttendance_Log " & _
                " SET ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " InOut = " & AgL.Chk_Text(TxtInOut.Text) & ", " & _
                " GateInOutDocID = " & AgL.Chk_Text(LblGateInOutDocId.Tag) & ", " & _
                " Vehicle = " & AgL.Chk_Text(TxtVehicleNo.AgSelectedValue) & ", " & _
                " Driver = " & AgL.Chk_Text(TxtDriver.AgSelectedValue) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                " TotalMember = " & Val(LblValTotalMember.Text) & ", " & _
                " TotalPresent = " & Val(LblValTotalPresent.Text) & ", " & _
                " TotalAbsent = " & Val(LblValTotalAbsent.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        'AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)


        ''Never Try to Serialise Sr in Line Items 
        ''As Some other Entry points may updating values to this Search code and Sr
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Tp_MemberAttendance1_Log WHERE UID = " & AgL.Chk_Text(mSearchCode) & " "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Member, bIntI).Value <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Tp_MemberAttendance1_Log ( " & _
                        " UID, DocId, Sr, Member, IsPresent, IsUnRegistered, Route, PickUpPoint) " & _
                         " VALUES (" & _
                         " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & bIntSr & ", " & _
                         " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Member, bIntI)) & ", " & _
                         " " & IIf(AgL.StrCmp(Dgl1.Item(Col1IsPresent, bIntI).Value.ToString, AgLibrary.ClsConstant.StrCheckedValue), 1, 0) & ", " & _
                         " " & IIf(AgL.StrCmp(Dgl1.Item(Col1IsUnRegistered, bIntI).Value.ToString, "Yes"), 1, 0) & ", " & _
                         " " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & ", " & _
                         " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1PickUpPoint, bIntI)) & " " & _
                         " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim bIntI As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Dim DtTemp As DataTable = Nothing

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From Tp_MemberAttendance H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From Tp_MemberAttendance_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        If DsTemp.Tables(0).Rows.Count > 0 Then
            With DsTemp.Tables(0)
                IniGrid()


                TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))
                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtInOut.Text = AgL.XNull(.Rows(0)("InOut"))

                LblGateInOutDocId.Tag = AgL.XNull(.Rows(0)("GateInOutDocID"))
                DrTemp = TxtGateInOutDocId.AgHelpDataSet.Tables(0).Select("GateInOutDocID = " & AgL.Chk_Text(LblGateInOutDocId.Tag) & " And [In/Out] = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("InOut"))) & " ")
                If DrTemp.Length > 0 Then
                    TxtGateInOutDocId.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                Else
                    TxtGateInOutDocId.AgSelectedValue = ""
                    LblGateInOutDocId.Tag = ""
                End If
                DrTemp = Nothing

                TxtVehicleNo.AgSelectedValue = AgL.XNull(.Rows(0)("Vehicle"))
                DrTemp = TxtVehicleNo.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtVehicleNo.AgSelectedValue) & " ")
                If DrTemp.Length > 0 Then
                    TxtVehicleName.Text = AgL.XNull(DrTemp(0)("Vehicle Name"))
                End If

                TxtDriver.AgSelectedValue = AgL.XNull(.Rows(0)("Driver"))
                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                LblValTotalMember.Text = AgL.VNull(.Rows(0)("TotalMember"))
                LblValTotalPresent.Text = AgL.VNull(.Rows(0)("TotalPresent"))
                LblValTotalAbsent.Text = AgL.VNull(.Rows(0)("TotalAbsent"))

            End With

            '-------------------------------------------------------------
            'Line Records are showing in Grid
            '-------------------------------------------------------------
            If FrmType = ClsMain.EntryPointType.Main Then
                mQry = "Select L.*, M.MemberCardNo " & _
                        " from Tp_MemberAttendance1 L " & _
                        " Left Join Tp_Member M On M.SubCode = L.Member " & _
                        " where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
            Else
                mQry = "Select L.*, M.MemberCardNo " & _
                        " from Tp_MemberAttendance1_Log L " & _
                        " Left Join Tp_Member M On M.SubCode = L.Member " & _
                        " where L.UID = '" & SearchCode & "' " & _
                        " Order By L.Sr"
            End If
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()

                If DtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To DtTemp.Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, bIntI).Value = Dgl1.Rows.Count - 1

                        Dgl1.AgSelectedValue(Col1Member, bIntI) = AgL.XNull(.Rows(bIntI)("Member"))
                        Dgl1.Item(Col1MemberCardNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("MemberCardNo"))
                        Dgl1.Item(Col1IsPresent, bIntI).Value = IIf(AgL.VNull(.Rows(bIntI)("IsPresent")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)
                        Dgl1.Item(Col1IsUnRegistered, bIntI).Value = IIf(AgL.VNull(.Rows(bIntI)("IsUnRegistered")), "Yes", "No")                        
                        Dgl1.AgSelectedValue(Col1PickUpPoint, bIntI) = AgL.XNull(.Rows(bIntI)("PickUpPoint"))

                        Dgl1.Item(Col1RouteCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("Route"))
                        If TxtRoute.Text.Trim = "" Then
                            TxtRoute.AgSelectedValue = AgL.XNull(.Rows(bIntI)("Route"))
                        End If

                        RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                    Next bIntI
                End If
            End With
            '-------------------------------------------------------------
        End If
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 630, 1010)

        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtVehicleNo.Enter, TxtVehicleName.Enter, TxtDriver.Enter, TxtDateValue.Enter, _
        TxtGateInOutDocId.Enter, TxtInOut.Enter, TxtReferenceNo.Enter, TxtRemark.Enter, TxtRoute.Enter, _
        TxtV_Date.Enter

        Dim bStrRowFilter$ = ""
        Try
            Select Case sender.name
                Case TxtGateInOutDocId.Name
                    bStrRowFilter = " 1=1 "
                    bStrRowFilter += " And [Vehicle No] = " & AgL.Chk_Text(TxtVehicleNo.Text) & " "
                    bStrRowFilter += " And [In/Out] = " & AgL.Chk_Text(TxtInOut.Text) & " "
                    bStrRowFilter += " And EntryDate = " & AgL.Chk_Text(TxtV_Date.Text) & " "
                    TxtGateInOutDocId.AgRowFilter = bStrRowFilter

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtV_Type.Validating, TxtVehicleNo.Validating, TxtVehicleName.Validating, TxtDriver.Validating, TxtDateValue.Validating, _
        TxtGateInOutDocId.Validating, TxtInOut.Validating, TxtReferenceNo.Validating, TxtRemark.Validating, TxtRoute.Validating, _
        TxtV_Date.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    Call IniGrid()
                    Call ProcFillReferenceNo()

                Case TxtGateInOutDocId.Name
                    Validating_Controls(sender)

                Case TxtVehicleNo.Name
                    Validating_Controls(sender)

                Case TxtDriver.Name
                    'e.Cancel = Not Validating_Controls(sender)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        Dim bStrDateTime$ = ""

        ProcFillReferenceNo()
        IniGrid()
        TabControl1.SelectedTab = TP1

        If TxtV_Date.Text.Trim = "" Then
            mQry = " SELECT getdate()"
            bStrDateTime = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar().ToString
            TxtV_Date.Text = Format(bStrDateTime, AgLibrary.ClsConstant.DateFormat_ShortDate)
        End If
        TxtDateValue.Text = CDate(TxtV_Date.Text).Year.ToString.Substring(2, 2) + CDate(TxtV_Date.Text).Month.ToString.PadLeft(2, "0") + CDate(TxtV_Date.Text).Date.ToString.Substring(0, 2).PadLeft(2, "0")

        mQry = " SELECT ISNULL(Max(substring(ReferenceNo,7,4)),0) + 1 FROM Tp_MemberAttendance " & _
                " WHERE substring(ReferenceNo,1,6)='" & TxtDateValue.Text & "' "
        TxtReferenceNo.Text = TxtDateValue.Text + AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar().ToString.PadLeft(4, "0")

    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtDriver.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Driver.Copy
        TxtVehicleNo.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Vehicle.Copy
        TxtRoute.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Route.Copy
        TxtGateInOutDocId.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.GateDocInOutDocId.Copy
        TxtInOut.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.InOut.Copy

        Dgl1.AgHelpDataSet(Col1Member, 3) = HelpDataSet.Member.Copy
        Dgl1.AgHelpDataSet(Col1PickUpPoint) = HelpDataSet.PickupPoint.Copy


    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim bIntI As Integer

        LblValTotalMember.Text = 0
        LblValTotalPresent.Text = 0
        LblValTotalAbsent.Text = 0

        For bIntI = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Member, bIntI).Value Is Nothing Then Dgl1.Item(Col1Member, bIntI).Value = ""
            If Dgl1.Item(Col1IsPresent, bIntI).Value Is Nothing Then Dgl1.Item(Col1IsPresent, bIntI).Value = ""
            If Dgl1.Item(Col1IsPresent, bIntI).Value.ToString.Trim = "" Then Dgl1.Item(Col1IsPresent, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

            If Dgl1.Item(Col1Member, bIntI).Value <> "" Then
                'Footer Calculation

                LblValTotalMember.Text = Val(LblValTotalMember.Text) + 1

                If AgL.StrCmp(Dgl1.Item(Col1IsPresent, bIntI).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                    LblValTotalPresent.Text = Val(LblValTotalPresent.Text) + 1
                Else
                    LblValTotalAbsent.Text = Val(LblValTotalAbsent.Text) + 1
                End If
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then passed = False : Exit Sub
    End Sub

    Public Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Try
            If AgL.RequiredField(TxtDriver, LblDriver.Text) Then Exit Function

            If Not CommonData_Validation() Then Exit Function

            AgCL.AgBlankNothingCells(Dgl1)
            If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Member).Index) Then Exit Function
            If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1Member).Index) Then Exit Function

            mQry = "SELECT IsNull(count(*),0) Cnt " & _
                    " FROM Tp_MemberAttendance H " & _
                    " WHERE H.InOut = " & AgL.Chk_Text(TxtInOut.Text) & " " & _
                    " AND H.GateInOutDocID = " & AgL.Chk_Text(LblGateInOutDocId.Tag) & " " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mInternalCode) & " ") & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Record Already Exists") : TxtInOut.Focus() : Exit Function

            'Start Code ReferenceNo Validation
            If Topctrl1.Mode = "Add" Then
                TxtDateValue.Text = CDate(TxtV_Date.Text).Year.ToString.Substring(2, 2) + CDate(TxtV_Date.Text).Month.ToString.PadLeft(2, "0") + CDate(TxtV_Date.Text).Date.ToString.Substring(0, 2).PadLeft(2, "0")

                mQry = " SELECT ISNULL(Max(substring(ReferenceNo,7,4)),0) + 1 FROM Tp_MemberAttendance " & _
                        " WHERE substring(ReferenceNo,1,6)='" & TxtDateValue.Text & "' "
                TxtReferenceNo.Text = TxtDateValue.Text + AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar().ToString.PadLeft(4, "0")

                mQry = " SELECT COUNT(*) FROM Tp_MemberAttendance WHERE ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
                        " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'"
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Reference No. Already Exists") : Exit Function
            Else
                mQry = " SELECT COUNT(*) FROM Tp_MemberAttendance WHERE ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
                        " AND V_Type ='" & TxtV_Type.AgSelectedValue & "' AND DocID <>'" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Reference No. Already Exists") : Exit Function
            End If
            'End Code By ReferenceNo Validation


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Function CommonData_Validation() As Boolean
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            If AgL.RequiredField(TxtVehicleNo, LblVehicleNo.Text) Then Exit Function
            If AgL.RequiredField(TxtInOut, LblInOut.Text) Then Exit Function
            If AgL.RequiredField(TxtGateInOutDocId, LblGateInOutDocId.Text) Then Exit Function
            If AgL.RequiredField(TxtRoute, LblRoute.Text) Then Exit Function


            CommonData_Validation = True
        Catch ex As Exception
            CommonData_Validation = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub TempGr_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        '------------------------------------------------------------------------
        'Updating Goods Received Qty In Purchase Order Detail
        '-------------------------------------------------------------------------
        'With Dgl1
        '    For I = 0 To .RowCount - 1
        '        If .Item(Col1Item, I).Value <> "" Then
        '            mQry = "UPDATE PurchOrderDetail " & _
        '                    " SET ShippedQty = (SELECT IsNull(Sum(Cd.Qty),0) " & _
        '                    " 				    FROM PurchChallanDetail Cd With (NoLock) " & _
        '                    "                   LEFT JOIN PurchChallan C With (NoLock) On Cd.DocId = C.DocId " & _
        '                    " 				    WHERE Cd.PurchOrder = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
        '                    " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
        '                    "                   AND IsNull(C.IsDeleted,0) = 0 ), " & _
        '                    " ShippedMeasure = (SELECT IsNull(Sum(Cd.TotalMeasure),0) " & _
        '                    " 				    FROM PurchChallanDetail Cd With (NoLock) " & _
        '                    "                   LEFT JOIN PurchChallan C With (NoLock) On Cd.DocId = C.DocId " & _
        '                    " 				    WHERE Cd.PurchOrder = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
        '                    " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
        '                    "                   AND IsNull(C.IsDeleted,0) = 0 ) " & _
        '                    " WHERE DocId = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
        '                    " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
        '            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '        End If
        '    Next
        'End With

        'mQry = " UPDATE Form_ReceiveDetail " & _
        '        " SET IsUtilised = (SELECT Count(*) FROM PurchChallan WITH (NoLock) WHERE FormNo = '" & TxtFormNo.Text & "') " & _
        '        " WHERE FormNo = '" & TxtFormNo.Text & "' "
        'AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '-------------------------------------------------------------------------
    End Sub

    Private Sub TempGr_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtReferenceNo.Enabled = False
        TxtVehicleName.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            '<Executable Code>
            TxtV_Date.Enabled = False
            TxtVehicleNo.Enabled = False
            TxtRoute.Enabled = False
        End If
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM QCDetail   L LEFT JOIN QC  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Quality Checking " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If


            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM PurchInvoiceDetail   L LEFT JOIN PurchInvoice  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Invoice " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT M.SubCode As Code, Sg.Name As Name, " & _
                " CASE WHEN M.InActiveDate IS NOT NULL THEN 'No' ELSE 'Yes' END As [Active Member], " & _
                " Sg.DispName AS DispName, Sg.ManualCode, M.MemberCardNo, M.Route, M.PickUpPoint " & _
                " FROM Tp_Member M " & _
                " LEFT JOIN SubGroup Sg ON M.SubCode = Sg.SubCode " & _
                " UNION ALL " & _
                " Select Sg.SubCode As Code, Sg.Name As Name, 'No' As [Active Member], " & _
                " Sg.DispName AS DispName, Sg.ManualCode, Null As MemberCardNo, Null As Route, Null As PickUpPoint " & _
                " From SubGroup Sg " & _
                " LEFT JOIN Tp_Member M ON M.SubCode = Sg.SubCode " & _
                " LEFT JOIN AcGroup Ag ON Ag.GroupCode = Sg.GroupCode " & _
                " Left Join City On Sg.CityCode = City.CityCode " & _
                " Where M.SubCode IS NULL  " & _
                " And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " And (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & " Or " & _
                "       Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & ") " & _
                " Order By Name "
        HelpDataSet.Member = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT E.SubCode As Code, Sg.Name As Name, " & _
                " CASE WHEN E.DateOfResign IS NOT Null THEN 'No' ELSE 'Yes' END AS Active, " & _
                " Sg.DispName AS DispName, Sg.ManualCode " & _
                " FROM Pay_Employee E " & _
                " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                " WHERE E.MasterType = '" & Academic_ProjLib.ClsMain.MasterType.Driver & "' "
        HelpDataSet.Driver = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT R.Code, R.Description AS Name FROM Sch_Route R ORDER BY R.Description "
        HelpDataSet.Route = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT R.Code, R.Description AS Name FROM Sch_Area R ORDER BY R.Description "
        HelpDataSet.PickupPoint = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select H.Code  As Code, H.RegistrationNo As [Vehicle No], " & _
                " H.Description As [Vehicle Name], H.VehicleType [Vehicle Type], " & _
                " H.MeterReading, H.Code As VehicleCode " & _
                " From Tp_Vehicle H " & _
                " Order By H.RegistrationNo "
        HelpDataSet.Vehicle = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT H.DocID  + '1' AS Code, H.Manual_RefNo AS [Open Entry No], " & _
                " H.InOut As [In/Out], H.VehicleNo AS [Vehicle No], H.VehicleType [Vehicle Type], " & _
                " H.V_Date AS EntryDate, H.SubCode As Driver, " & _
                " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS [Is Closed], " & _
                " H.DocID As GateInOutDocId  " & _
                " FROM dbo.GateInOut H " & _
                " Left Join Voucher_Type Vt On Vt.V_Type = H.V_Type " & _
                " Where Vt.NCat = '" & ClsMain.Temp_NCat.VehicleGate & "' " & _
                " And H.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & "" & _
                " UNION ALL  " & _
                " SELECT H.DocID  + '2' AS Code, " & _
                " H.Manual_RefNo AS [Open Entry No],  " & _
                " CASE IsNull(H.InOut,'') WHEN '" & ClsMain.InOut.GateOut & "' THEN '" & ClsMain.InOut.GateIn & "' WHEN '" & ClsMain.InOut.GateIn & "' THEN '" & ClsMain.InOut.GateOut & "' END AS [In/Out], " & _
                " H.VehicleNo AS [Vehicle No], H.VehicleType [Vehicle Type], " & _
                " H.Close_Date AS EntryDate, H.SubCode As Driver, " & _
                " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS [Is Closed], " & _
                " H.DocID As GateInOutDocId " & _
                " FROM dbo.GateInOut H " & _
                " Left Join Voucher_Type Vt On Vt.V_Type = H.V_Type " & _
                " Where Vt.NCat = '" & ClsMain.Temp_NCat.VehicleGate & "' " & _
                " And H.Close_Date IS NOT NULL " & _
                " And H.Close_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & "" & _
                " Order By EntryDate DESC, Code "
        HelpDataSet.GateDocInOutDocId = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select '" & ClsMain.InOut.GateIn & "' As Code, '" & ClsMain.InOut.GateIn & "' As Name " & _
                " UNION ALL " & _
                " Select '" & ClsMain.InOut.GateOut & "' As Code, '" & ClsMain.InOut.GateOut & "' As Name "
        HelpDataSet.InOut = AgL.FillData(mQry, AgL.GCn)


    End Sub

    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
            End If
        End If
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            If Dgl1.CurrentCell Is Nothing Then Exit Sub

            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1PickUpPoint
                    'Dgl1.AgRowFilter(mColumnIndex) = " RouteCode = " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & " "
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""


            With Dgl1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1Member
                        Call Validating_Member(mRowIndex)

                    Case Col1PickUpPoint

                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                'Case <ColumnIndex>
                'e.Cancel = Not Validate_PurchOrder(Dgl1, Dgl1.CurrentCell.RowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = Dgl1.CurrentCell.RowIndex
        mColumnIndex = Dgl1.CurrentCell.ColumnIndex

        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1IsPresent
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(Dgl1, Dgl1.Columns(Col1IsPresent).Index)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1IsPresent
                    Call AgL.ProcSetCheckColumnCellValue(Dgl1, Dgl1.Columns(Col1IsPresent).Index)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgl1.CellFormatting
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = e.RowIndex
            mColumnIndex = e.ColumnIndex

            If Dgl1.Item(Col1IsPresent, mRowIndex).Value Is Nothing Then Dgl1.Item(Col1IsPresent, mRowIndex).Value = ""
            If Dgl1.Item(Col1IsPresent, mRowIndex).Value.ToString.Trim = "" Then Dgl1.Item(Col1IsPresent, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue


            Dgl1.Item(Col1IsPresent, mRowIndex).Style.BackColor = Color.White
            If Dgl1.Item(Col1IsPresent, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                Dgl1.Item(Col1IsPresent, mRowIndex).Style.ForeColor = Color.Blue
            Else
                Dgl1.Item(Col1IsPresent, mRowIndex).Style.ForeColor = Color.Red
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtGateInOutDocId.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblGateInOutDocId.Tag = ""
                    TxtDriver.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblGateInOutDocId.Tag = AgL.XNull(DrTemp(0)("GateInOutDocId"))
                        TxtDriver.AgSelectedValue = AgL.XNull(DrTemp(0)("Driver"))
                    End If
                End If
                DrTemp = Nothing

            Case TxtVehicleNo.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtVehicleName.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        TxtVehicleName.Text = AgL.XNull(DrTemp(0)("Vehicle Name"))
                    End If
                End If
                DrTemp = Nothing
        End Select

        Validating_Controls = True
    End Function

    Public Function Validating_Member(ByVal IntRowIndex As Integer) As Boolean
        Dim DrTemp As DataRow() = Nothing

        If Dgl1.Item(Col1Member, IntRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Member, IntRowIndex).Trim = "" Then
            Dgl1.AgSelectedValue(Col1Member, IntRowIndex) = ""
            Dgl1.Item(Col1IsPresent, IntRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
            Dgl1.Item(Col1IsUnRegistered, IntRowIndex).Value = ""
            Dgl1.AgSelectedValue(Col1PickUpPoint, IntRowIndex) = ""
            Dgl1.Item(Col1MemberCardNo, IntRowIndex).Value = ""
        Else
            If Dgl1.AgHelpDataSet(Col1Member) IsNot Nothing Then
                DrTemp = Dgl1.AgHelpDataSet(Col1Member).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Member, IntRowIndex)) & "")
                If DrTemp.Length > 0 Then
                    Dgl1.Item(Col1IsPresent, IntRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue
                    Dgl1.Item(Col1IsUnRegistered, IntRowIndex).Value = AgL.XNull(DrTemp(0)("Active Member"))
                    Dgl1.AgSelectedValue(Col1PickUpPoint, IntRowIndex) = AgL.XNull(DrTemp(0)("PickUpPoint"))
                    Dgl1.Item(Col1MemberCardNo, IntRowIndex).Value = AgL.XNull(DrTemp(0)("MemberCardNo"))
                End If
            End If
            DrTemp = Nothing
        End If

        Validating_Member = True
    End Function


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Try
            Select Case sender.name
                Case BtnFill.Name
                    Call ProcFillMember()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillMember()
        Dim DtTemp As DataTable
        Dim bIntI As Integer
        Dim bCondStr$ = " Where 1=1 "
        Dim bBlnIsOpenElectiveSection As Boolean = False
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()

            If Not CommonData_Validation() Then Exit Sub

            bCondStr += " And M.Vehicle = " & AgL.Chk_Text(TxtVehicleNo.AgSelectedValue) & " "
            bCondStr += " And M.Route = " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & " "

            bCondStr += " AND CASE WHEN M.InActiveDate IS NULL THEN " & AgL.ConvertDate(TxtV_Date.Text) & " ELSE M.InActiveDate END <= " & AgL.ConvertDate(TxtV_Date.Text) & " "
            bCondStr += " AND CASE WHEN M.ValidTillDate IS NULL THEN " & AgL.ConvertDate(TxtV_Date.Text) & " ELSE M.ValidTillDate END >= " & AgL.ConvertDate(TxtV_Date.Text) & " "

            mQry = "SELECT M.SubCode, M.Route, M.PickUpPoint, M.MemberCardNo, " & _
                    " CASE WHEN M.InActiveDate IS NOT NULL THEN 'No' ELSE 'Yes' END As [Active Member], " & _
                    " 'No' As IsUnRegistered " & _
                    " FROM Tp_Member M " & _
                    " Left Join SubGroup Sg On Sg.SubCode = M.SubCode " & _
                    " " & bCondStr & " Order By Sg.Name "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()

                If .Rows.Count > 0 Then
                    TxtV_Date.Enabled = False
                    TxtVehicleNo.Enabled = False
                    TxtRoute.Enabled = False


                    For bIntI = 0 To DtTemp.Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, bIntI).Value = Dgl1.Rows.Count
                        Dgl1.AgSelectedValue(Col1Member, bIntI) = AgL.XNull(.Rows(bIntI)("SubCode"))
                        Dgl1.Item(Col1MemberCardNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("MemberCardNo"))
                        Dgl1.Item(Col1IsPresent, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue
                        Dgl1.Item(Col1IsUnRegistered, bIntI).Value = AgL.XNull(.Rows(bIntI)("IsUnRegistered"))
                        Dgl1.Item(Col1RouteCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("Route"))
                        Dgl1.AgSelectedValue(Col1PickUpPoint, bIntI) = AgL.XNull(.Rows(bIntI)("PickUpPoint"))
                    Next bIntI
                Else
                    TxtVehicleNo.Enabled = True
                    TxtRoute.Enabled = True
                    TxtV_Date.Enabled = True

                    MsgBox("No Student Record Exists For Attendance!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

End Class
