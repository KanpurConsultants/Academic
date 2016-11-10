Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmLabStatus

    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False
    Protected mBlnIsLockSessionProgramme As Boolean = False, mBlnIsLockStreamYearSemester As Boolean = False, mBlnIsLockSubject As Boolean = False, mBlnIsLockSubjectManualCode As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1ExperimentDate As String = "Experiment Date"
    Protected Const Col1ExperimentName As String = "Experiment Name"
    Protected Const Col1SessionProgramme As String = "Session Programme"
    Protected Const Col1StreamYearSemester As String = "Semester"
    Protected Const Col1Session As String = "Session Code"
    Protected Const Col1Programme As String = "Programme Code"
    Protected Const Col1Stream As String = "Stream Code"
    Protected Const Col1Semester As String = "Semester Code"
    Protected Const Col1Year As String = "Year"
    Protected Const Col1Subject As String = "Subject"
    Protected Const Col1SubjectManualCode As String = "Subject Code"
    Protected Const Col1Teacher As String = "Teacher"
    Protected Const Col1StatusOfManuals As String = "Status Of Manuals"
    Protected Const Col1StatusOfExperimentalSetup As String = "Status Of Experimental Setup"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1SeniorObservation As String = "Senior Observation"

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
    Protected WithEvents LblValTotal As System.Windows.Forms.Label
    Protected WithEvents LblTextTotal As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectManualCode As AgControls.AgTextBox
    Friend WithEvents LblSubjectManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotal = New System.Windows.Forms.Label
        Me.LblTextTotal = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtSubjectManualCode = New AgControls.AgTextBox
        Me.LblSubjectManualCode = New System.Windows.Forms.Label
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
        Me.TxtDocId.Location = New System.Drawing.Point(922, 88)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(270, 50)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(373, 48)
        Me.TxtV_No.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(128, 54)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(14, 50)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(128, 34)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(143, 48)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(14, 29)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(143, 28)
        Me.TxtV_Type.Size = New System.Drawing.Size(350, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(128, 14)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(14, 9)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(143, 8)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(875, 90)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(335, 49)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 121)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtSubjectManualCode)
        Me.TP1.Controls.Add(Me.LblSubjectManualCode)
        Me.TP1.Controls.Add(Me.TxtSubject)
        Me.TP1.Controls.Add(Me.LblSubject)
        Me.TP1.Controls.Add(Me.TxtSessionProgramme)
        Me.TP1.Controls.Add(Me.LblSessionProgramme)
        Me.TP1.Controls.Add(Me.TxtStreamYearSemester)
        Me.TP1.Controls.Add(Me.LblStreamYearSemester)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 93)
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
        Me.TP1.Controls.SetChildIndex(Me.LblStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSessionProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSessionProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectManualCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubjectManualCode, 0)
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
        Me.TxtRemark.Location = New System.Drawing.Point(626, 68)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 9
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(523, 70)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 164)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(965, 381)
        Me.Pnl1.TabIndex = 1
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(128, 74)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(143, 68)
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
        Me.LblReferenceNo.Location = New System.Drawing.Point(14, 69)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotal)
        Me.PnlFooter.Controls.Add(Me.LblTextTotal)
        Me.PnlFooter.Location = New System.Drawing.Point(636, 582)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(144, 24)
        Me.PnlFooter.TabIndex = 695
        Me.PnlFooter.Visible = False
        '
        'LblValTotal
        '
        Me.LblValTotal.AutoSize = True
        Me.LblValTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotal.Location = New System.Drawing.Point(120, 4)
        Me.LblValTotal.Name = "LblValTotal"
        Me.LblValTotal.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotal.TabIndex = 680
        Me.LblValTotal.Text = "."
        Me.LblValTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotal
        '
        Me.LblTextTotal.AutoSize = True
        Me.LblTextTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotal.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotal.Location = New System.Drawing.Point(3, 4)
        Me.LblTextTotal.Name = "LblTextTotal"
        Me.LblTextTotal.Size = New System.Drawing.Size(118, 16)
        Me.LblTextTotal.TabIndex = 679
        Me.LblTextTotal.Text = "Total Questions  :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 141)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(77, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Plan Detail :"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgMandatory = False
        Me.TxtStreamYearSemester.AgMasterHelp = False
        Me.TxtStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtStreamYearSemester.AgPickFromLastValue = False
        Me.TxtStreamYearSemester.AgRowFilter = ""
        Me.TxtStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStreamYearSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(626, 8)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(350, 18)
        Me.TxtStreamYearSemester.TabIndex = 6
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(523, 10)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamYearSemester.TabIndex = 783
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgMandatory = False
        Me.TxtSessionProgramme.AgMasterHelp = False
        Me.TxtSessionProgramme.AgNumberLeftPlaces = 0
        Me.TxtSessionProgramme.AgNumberNegetiveAllow = False
        Me.TxtSessionProgramme.AgNumberRightPlaces = 0
        Me.TxtSessionProgramme.AgPickFromLastValue = False
        Me.TxtSessionProgramme.AgRowFilter = ""
        Me.TxtSessionProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSessionProgramme.AgSelectedValue = Nothing
        Me.TxtSessionProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgramme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSessionProgramme.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(373, 68)
        Me.TxtSessionProgramme.MaxLength = 0
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(120, 18)
        Me.TxtSessionProgramme.TabIndex = 5
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(270, 70)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(73, 15)
        Me.LblSessionProgramme.TabIndex = 786
        Me.LblSessionProgramme.Text = "Programme"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = False
        Me.TxtSubject.AgMasterHelp = False
        Me.TxtSubject.AgNumberLeftPlaces = 0
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 0
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubject.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(626, 28)
        Me.TxtSubject.MaxLength = 0
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(350, 18)
        Me.TxtSubject.TabIndex = 7
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(523, 30)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(48, 15)
        Me.LblSubject.TabIndex = 789
        Me.LblSubject.Text = "Subject"
        '
        'TxtSubjectManualCode
        '
        Me.TxtSubjectManualCode.AgMandatory = False
        Me.TxtSubjectManualCode.AgMasterHelp = False
        Me.TxtSubjectManualCode.AgNumberLeftPlaces = 0
        Me.TxtSubjectManualCode.AgNumberNegetiveAllow = False
        Me.TxtSubjectManualCode.AgNumberRightPlaces = 0
        Me.TxtSubjectManualCode.AgPickFromLastValue = False
        Me.TxtSubjectManualCode.AgRowFilter = ""
        Me.TxtSubjectManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubjectManualCode.AgSelectedValue = Nothing
        Me.TxtSubjectManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectManualCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubjectManualCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectManualCode.Location = New System.Drawing.Point(626, 48)
        Me.TxtSubjectManualCode.MaxLength = 0
        Me.TxtSubjectManualCode.Name = "TxtSubjectManualCode"
        Me.TxtSubjectManualCode.Size = New System.Drawing.Size(120, 18)
        Me.TxtSubjectManualCode.TabIndex = 8
        '
        'LblSubjectManualCode
        '
        Me.LblSubjectManualCode.AutoSize = True
        Me.LblSubjectManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectManualCode.Location = New System.Drawing.Point(523, 50)
        Me.LblSubjectManualCode.Name = "LblSubjectManualCode"
        Me.LblSubjectManualCode.Size = New System.Drawing.Size(81, 15)
        Me.LblSubjectManualCode.TabIndex = 792
        Me.LblSubjectManualCode.Text = "Subject Code"
        '
        'FrmLabStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PnlFooter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmLabStatus"
        Me.Text = "Lecture Plan"
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
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

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.LabStatus) & ""
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
        Public Shared Teacher As DataSet = Nothing
        Public Shared SessionProgramme As DataSet = Nothing
        Public Shared StreamYearSemester As DataSet = Nothing
        Public Shared Subject As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Sch_LabStatus"
        AglObj = AgL

        LblV_Type.Text = "Plan Type"
        LblV_Date.Text = "Plan Date"
        LblV_No.Text = "Plan No."
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
                " From Sch_LabStatus H With (NoLock) " & _
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


        AgL.PubFindQry = "SELECT H.DocId AS SearchCode,  " & _
                            " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " vSp.SessionProgramme As [" & LblSessionProgramme.Text & "], " & _
                            " vSem.StreamYearSemesterDesc As [" & LblStreamYearSemester.Text & "], " & _
                            " S.DisplayName As [" & LblSubject.Text & "], " & _
                            " H.SubjectManualCode As [" & LblSubjectManualCode.Text & "], " & _
                            " Sm.Name AS [" & LblSite_Code.Text & "], " & _
                            " H.Remark " & _
                            " FROM dbo.Sch_LabStatus H WITH (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code  " & _
                            " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = H.SessionProgramme " & _
                            " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = H.StreamYearSemester " & _
                            " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject  " & mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc"

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgDateColumn(DGL1, Col1ExperimentDate, 80, Col1ExperimentDate, True, False, False)
            .AddAgTextColumn(DGL1, Col1Subject, 150, 0, Col1Subject, True, False, False)
            .AddAgTextColumn(DGL1, Col1SubjectManualCode, 80, 20, Col1SubjectManualCode, True, False, False)
            .AddAgTextColumn(DGL1, Col1ExperimentName, 150, 100, Col1ExperimentName, True, False, False)
            .AddAgTextColumn(DGL1, Col1SessionProgramme, 80, 0, Col1SessionProgramme, True, False, False)
            .AddAgTextColumn(DGL1, Col1StreamYearSemester, 80, 0, Col1StreamYearSemester, True, False, False)
            .AddAgTextColumn(DGL1, Col1Session, 80, 0, Col1Session, False, True, False)
            .AddAgTextColumn(DGL1, Col1Programme, 80, 0, Col1Programme, False, True, False)
            .AddAgTextColumn(DGL1, Col1Stream, 80, 0, Col1Stream, False, True, False)
            .AddAgTextColumn(DGL1, Col1Semester, 80, 0, Col1Semester, False, True, False)
            .AddAgTextColumn(DGL1, Col1Year, 80, 0, Col1Year, False, True, True)
            .AddAgTextColumn(DGL1, Col1Teacher, 150, 0, Col1Teacher, True, False, False)
            .AddAgTextColumn(DGL1, Col1StatusOfManuals, 80, 20, Col1StatusOfManuals, True, False, False)
            .AddAgTextColumn(DGL1, Col1StatusOfExperimentalSetup, 80, 20, Col1StatusOfExperimentalSetup, True, False, False)
            .AddAgTextColumn(DGL1, Col1Remark, 120, 255, Col1Remark, True, False, False)
            .AddAgTextColumn(DGL1, Col1SeniorObservation, 120, 255, Col1SeniorObservation, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 50
        DGL1.Columns(Col1ExperimentName).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0

        mQry = "UPDATE dbo.Sch_LabStatus " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                " StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                " Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                " SubjectManualCode = " & AgL.Chk_Text(TxtSubjectManualCode.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Sch_LabStatus1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1ExperimentDate, bIntI).Value.ToString.Trim <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Sch_LabStatus1 ( " & _
                        " DocId, Sr, ExperimentDate, ExperimentName, SessionProgramme, StreamYearSemester, " & _
                        " Session, Programme, Stream, Semester, Year, Subject, SubjectManualCode, Teacher, " & _
                        " StatusOfManuals, StatusOfExperimentalSetup, Remark, SeniorObservation)" & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1ExperimentDate, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1ExperimentName, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1SessionProgramme, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1StreamYearSemester, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Session, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Programme, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Stream, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Semester, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Year, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Subject, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1SubjectManualCode, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Teacher, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1StatusOfManuals, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1StatusOfExperimentalSetup, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1SeniorObservation, bIntI).Value) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        mQry = "Delete From Sch_LabStatus1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Sch_LabStatus Where DocId = '" & SearchCode & "' "
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
            " From Sch_LabStatus H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgramme"))
                TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("SessionProgramme"))

                TxtSubject.AgSelectedValue = AgL.XNull(.Rows(0)("Subject"))
                TxtSubjectManualCode.Text = AgL.XNull(.Rows(0)("SubjectManualCode"))

                mQry = "Select L.* " & _
                        " From Sch_LabStatus1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.Item(Col1ExperimentDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("ExperimentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1ExperimentName, bIntI).Value = AgL.XNull(.Rows(bIntI)("ExperimentName"))
                            DGL1.AgSelectedValue(Col1SessionProgramme, bIntI) = AgL.XNull(.Rows(bIntI)("SessionProgramme"))
                            DGL1.AgSelectedValue(Col1StreamYearSemester, bIntI) = AgL.XNull(.Rows(bIntI)("StreamYearSemester"))
                            DGL1.Item(Col1Session, bIntI).Value = AgL.XNull(.Rows(bIntI)("Session"))
                            DGL1.Item(Col1Programme, bIntI).Value = AgL.XNull(.Rows(bIntI)("Programme"))
                            DGL1.Item(Col1Stream, bIntI).Value = AgL.XNull(.Rows(bIntI)("Stream"))
                            DGL1.Item(Col1Semester, bIntI).Value = AgL.XNull(.Rows(bIntI)("Semester"))
                            DGL1.Item(Col1Year, bIntI).Value = AgL.XNull(.Rows(bIntI)("Year"))
                            DGL1.AgSelectedValue(Col1Subject, bIntI) = AgL.XNull(.Rows(bIntI)("Subject"))
                            DGL1.Item(Col1SubjectManualCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("SubjectManualCode"))
                            DGL1.AgSelectedValue(Col1Teacher, bIntI) = AgL.XNull(.Rows(bIntI)("Teacher"))
                            DGL1.Item(Col1StatusOfManuals, bIntI).Value = AgL.XNull(.Rows(bIntI)("StatusOfManuals"))
                            DGL1.Item(Col1StatusOfExperimentalSetup, bIntI).Value = AgL.XNull(.Rows(bIntI)("StatusOfExperimentalSetup"))
                            DGL1.Item(Col1Remark, bIntI).Value = AgL.XNull(.Rows(bIntI)("Remark"))
                            DGL1.Item(Col1SeniorObservation, bIntI).Value = AgL.XNull(.Rows(bIntI)("SeniorObservation"))

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
            mQry = "SELECT E.SubCode AS Code, Sg.Name, " & _
                    " CASE WHEN E.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END IsActive " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                    " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                    " ORDER BY Sg.Name "
            HelpDataSet.Teacher = AgL.FillData(mQry, AgL.GcnRead)


            mQry = "SELECT P.Code, P.SessionProgramme AS Name " & _
                    " FROM ViewSch_SessionProgramme P With (NoLock) " & _
                    " ORDER BY P.SessionProgramme "
            HelpDataSet.SessionProgramme = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.StreamYearSemesterDesc AS Semester, S.SessionProgrammeCode, " & _
                    " S.StreamCode, S.ProgrammeCode, S.SessionCode, S.Semester As SemesterCode, S.YearSerial " & _
                    " FROM ViewSch_StreamYearSemester S WITH (NoLock) " & _
                    " ORDER BY S.StreamYearSemesterDesc "
            HelpDataSet.StreamYearSemester = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.Description AS Name, S.SubjectType, S.DisplayName AS Subject, S.ManualCode " & _
                    " FROM Sch_Subject S With (NoLock) " & _
                    " Order By S.Description "
            HelpDataSet.Subject = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSessionProgramme.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.SessionProgramme.Copy
        DGL1.AgHelpDataSet(Col1SessionProgramme, 0) = HelpDataSet.SessionProgramme.Copy

        TxtStreamYearSemester.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.StreamYearSemester.Copy
        DGL1.AgHelpDataSet(Col1StreamYearSemester, 6) = HelpDataSet.StreamYearSemester.Copy

        DGL1.AgHelpDataSet(Col1Teacher, 1) = HelpDataSet.Teacher.Copy

        TxtSubject.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Subject.Copy
        DGL1.AgHelpDataSet(Col1Subject, 2) = HelpDataSet.Subject.Copy
    End Sub


    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer = 0

        LblValTotal.Text = 0

        mBlnIsLockSessionProgramme = False : mBlnIsLockStreamYearSemester = False : mBlnIsLockSubject = False : mBlnIsLockSubjectManualCode = False

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1ExperimentDate, bIntI).Value Is Nothing Then DGL1.Item(Col1ExperimentDate, bIntI).Value = ""
            If DGL1.Item(Col1Teacher, bIntI).Value Is Nothing Then DGL1.Item(Col1Teacher, bIntI).Value = ""
            If DGL1.Item(Col1SessionProgramme, bIntI).Value Is Nothing Then DGL1.Item(Col1SessionProgramme, bIntI).Value = ""
            If DGL1.Item(Col1StreamYearSemester, bIntI).Value Is Nothing Then DGL1.Item(Col1StreamYearSemester, bIntI).Value = ""
            If DGL1.Item(Col1Subject, bIntI).Value Is Nothing Then DGL1.Item(Col1Subject, bIntI).Value = ""
            If DGL1.Item(Col1SubjectManualCode, bIntI).Value Is Nothing Then DGL1.Item(Col1SubjectManualCode, bIntI).Value = ""

            If DGL1.Item(Col1ExperimentDate, bIntI).Value <> "" Then
                If TxtSessionProgramme.Text.Trim <> "" Then
                    mBlnIsLockSessionProgramme = True

                    If AgL.XNull(DGL1.Item(Col1SessionProgramme, bIntI).Value).ToString.Trim = "" Then
                        Call Validating_Columns(DGL1.Columns(Col1SessionProgramme).Index, bIntI)
                    End If
                End If

                If TxtStreamYearSemester.Text.Trim <> "" Then
                    mBlnIsLockStreamYearSemester = True

                    If AgL.XNull(DGL1.Item(Col1StreamYearSemester, bIntI).Value).ToString.Trim = "" Then
                        Call Validating_Columns(DGL1.Columns(Col1StreamYearSemester).Index, bIntI)
                    End If
                End If

                If TxtSubject.Text.Trim <> "" Then
                    mBlnIsLockSubject = True

                    If AgL.XNull(DGL1.Item(Col1Subject, bIntI).Value).ToString.Trim = "" Then
                        Call Validating_Columns(DGL1.Columns(Col1Subject).Index, bIntI)
                    End If
                End If

                If TxtSubjectManualCode.Text.Trim <> "" Then
                    mBlnIsLockSubjectManualCode = True

                    If AgL.XNull(DGL1.Item(Col1SubjectManualCode, bIntI).Value).ToString.Trim = "" Then
                        DGL1.Item(Col1SubjectManualCode, bIntI).Value = TxtSubjectManualCode.Text
                    End If
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
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            If AgL.XNull(LblStreamYearSemester.Tag).ToString <> "" Then
                If Not AgL.StrCmp(LblStreamYearSemester.Tag, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Please Check Semester!...")
                    TxtStreamYearSemester.Focus() : Exit Function
                End If
            End If


            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1ExperimentDate).Index) Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1ExperimentName, bIntI).Value Is Nothing Then DGL1.Item(Col1ExperimentName, bIntI).Value = ""

                If DGL1.Item(Col1ExperimentDate, bIntI).Value <> "" Then
                    If AgL.XNull(DGL1.Item(Col1Subject, bIntI).Value).ToString.Trim = "" Then
                        MsgBox("Subject Is Blank At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1Subject, bIntI) : DGL1.Focus() : Exit Function
                    End If

                    If AgL.XNull(DGL1.Item(Col1SubjectManualCode, bIntI).Value).ToString.Trim = "" Then
                        MsgBox("Subject Code Is Blank At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1SubjectManualCode, bIntI) : DGL1.Focus() : Exit Function
                    End If

                    If AgL.XNull(DGL1.Item(Col1ExperimentName, bIntI).Value).ToString.Trim = "" Then
                        MsgBox("Experiment Name Is Blank At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1ExperimentName, bIntI) : DGL1.Focus() : Exit Function
                    End If

                    If AgL.XNull(DGL1.Item(Col1Teacher, bIntI).Value).ToString.Trim = "" Then
                        MsgBox("Teacher Is Blank At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1Teacher, bIntI) : DGL1.Focus() : Exit Function
                    End If

                    If AgL.XNull(DGL1.Item(Col1SessionProgramme, bIntI).Value).ToString.Trim = "" Then
                        MsgBox("Session/Programme Is Blank At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1SessionProgramme, bIntI) : DGL1.Focus() : Exit Function
                    End If

                    If AgL.XNull(DGL1.Item(Col1StreamYearSemester, bIntI).Value).ToString.Trim = "" Then
                        MsgBox("Semester Is Blank At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1StreamYearSemester, bIntI) : DGL1.Focus() : Exit Function
                    End If

                    If Val(DGL1.Item(Col1Year, bIntI).Value) > 0 Then DGL1.Item(Col1Year, bIntI).Value = ""
                End If
            Next

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Sch_LabStatus H With (NoLock) " & _
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
        LblValTotal.Text = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        mBlnIsApproved = False
        mBlnIsLockSessionProgramme = False : mBlnIsLockStreamYearSemester = False : mBlnIsLockSubject = False : mBlnIsLockSubjectManualCode = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtDivision.Enter, TxtDocId.Enter, TxtReferenceNo.Enter, TxtSite_Code.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtRemark.Enter, TxtSessionProgramme.Enter, TxtStreamYearSemester.Enter, TxtSubject.Enter, TxtSubjectManualCode.Enter
        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                Case TxtSubject.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And SubjectType = " & AgL.Chk_Text(ClsMain.SubjectType.Practical) & ""
                    TxtSubject.AgRowFilter = bStrFilter

                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtSessionProgramme.Validating, TxtStreamYearSemester.Validating, TxtSubject.Validating, TxtSubjectManualCode.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()

                Case TxtStreamYearSemester.Name
                    Call Validating_Controls(sender)

                Case TxtSubject.Name
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
            Case TxtStreamYearSemester.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblStreamYearSemester.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        LblStreamYearSemester.Tag = AgL.XNull(DrTemp(0)("SessionProgrammeCode"))
                    End If
                    DrTemp = Nothing
                End If

            Case TxtSubject.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtSubjectManualCode.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        TxtSubjectManualCode.Text = AgL.XNull(DrTemp(0)("ManualCode"))
                    End If
                End If
                DrTemp = Nothing

        End Select

    End Sub

    Public Sub Validating_Columns(ByVal IntColumnIndex As Integer, ByVal IntRowIndex As Integer)
        Dim DrTemp As DataRow() = Nothing

        With DGL1
            Select Case .Columns(IntColumnIndex).Name
                Case Col1SessionProgramme
                    If AgL.XNull(DGL1.Item(IntColumnIndex, IntRowIndex).Value).ToString.Trim = "" Or AgL.XNull(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)).ToString.Trim = "" Then
                        If TxtSessionProgramme.Text.Trim <> "" Then
                            DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex) = TxtSessionProgramme.AgSelectedValue
                        End If
                    End If

                Case Col1StreamYearSemester
                    If AgL.XNull(DGL1.Item(IntColumnIndex, IntRowIndex).Value).ToString.Trim = "" Or AgL.XNull(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)).ToString.Trim = "" Then
                        If TxtStreamYearSemester.Text.Trim <> "" Then
                            DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex) = TxtStreamYearSemester.AgSelectedValue
                        End If
                    End If

                    If AgL.XNull(DGL1.Item(IntColumnIndex, IntRowIndex).Value).ToString.Trim = "" Or AgL.XNull(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)).ToString.Trim = "" Then
                        DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex) = ""
                        DGL1.Item(Col1Session, IntRowIndex).Value = ""
                        DGL1.Item(Col1Programme, IntRowIndex).Value = ""
                        DGL1.Item(Col1Stream, IntRowIndex).Value = ""
                        DGL1.Item(Col1Semester, IntRowIndex).Value = ""
                        DGL1.Item(Col1Year, IntRowIndex).Value = ""
                    Else
                        If DGL1.AgHelpDataSet(IntColumnIndex) IsNot Nothing Then
                            DrTemp = DGL1.AgHelpDataSet(IntColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)) & "")

                            DGL1.Item(Col1Session, IntRowIndex).Value = AgL.XNull(DrTemp(0)("SessionCode"))
                            DGL1.Item(Col1Programme, IntRowIndex).Value = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                            DGL1.Item(Col1Stream, IntRowIndex).Value = AgL.XNull(DrTemp(0)("StreamCode"))
                            DGL1.Item(Col1Semester, IntRowIndex).Value = AgL.XNull(DrTemp(0)("SemesterCode"))

                            If AgL.VNull(DrTemp(0)("YearSerial")) > 0 Then
                                DGL1.Item(Col1Year, IntRowIndex).Value = AgL.VNull(DrTemp(0)("YearSerial"))
                            Else
                                DGL1.Item(Col1Year, IntRowIndex).Value = ""
                            End If
                        End If
                        DrTemp = Nothing
                    End If

                Case Col1Subject
                    If AgL.XNull(DGL1.Item(IntColumnIndex, IntRowIndex).Value).ToString.Trim = "" Or AgL.XNull(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)).ToString.Trim = "" Then
                        If TxtSubject.Text.Trim <> "" Then
                            DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex) = TxtSubject.AgSelectedValue
                        End If
                    End If

                    If AgL.XNull(DGL1.Item(IntColumnIndex, IntRowIndex).Value).ToString.Trim = "" Or AgL.XNull(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)).ToString.Trim = "" Then
                        DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex) = ""
                        DGL1.Item(Col1SubjectManualCode, IntRowIndex).Value = ""
                    Else
                        If DGL1.AgHelpDataSet(IntColumnIndex) IsNot Nothing Then
                            DrTemp = DGL1.AgHelpDataSet(IntColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(IntColumnIndex, IntRowIndex)) & "")

                            DGL1.Item(Col1SubjectManualCode, IntRowIndex).Value = AgL.XNull(DrTemp(0)("ManualCode"))
                        End If
                        DrTemp = Nothing
                    End If
            End Select
        End With
    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtSessionProgramme.Enabled = False
            TxtStreamYearSemester.Enabled = False
            TxtSubject.Enabled = False
            TxtSubjectManualCode.Enabled = False
        End If
    End Sub

    Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim bStrFilter$ = ""

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Teacher
                    DGL1.AgRowFilter(mColumnIndex) = " IsActive = 'Yes' "

                Case Col1SessionProgramme
                    bStrFilter = " 1=1 "

                    If TxtSessionProgramme.Text.Trim <> "" Then
                        bStrFilter += " And Code = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
                    End If

                    DGL1.AgRowFilter(mColumnIndex) = bStrFilter

                Case Col1StreamYearSemester
                    bStrFilter = " 1=1 "

                    If TxtStreamYearSemester.Text.Trim <> "" Then
                        bStrFilter += " And Code = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
                    Else
                        bStrFilter += " And SessionProgrammeCode = " & AgL.Chk_Text(AgL.XNull(DGL1.AgSelectedValue(Col1SessionProgramme, mRowIndex))) & " "
                    End If
                    DGL1.AgRowFilter(mColumnIndex) = bStrFilter

                Case Col1Subject
                    bStrFilter = " 1=1 "

                    bStrFilter = " 1=1 "

                    If TxtSubject.Text.Trim <> "" Then
                        bStrFilter += " And Code = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " "
                    Else
                        bStrFilter += " And SubjectType = " & AgL.Chk_Text(ClsMain.SubjectType.Practical) & ""
                    End If

                    DGL1.AgRowFilter(mColumnIndex) = bStrFilter

                Case Col1Teacher
                    DGL1.AgRowFilter(mColumnIndex) = " IsActive = 'Yes' "

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
                    Case Col1SessionProgramme
                        Call Validating_Columns(mColumnIndex, mRowIndex)

                    Case Col1StreamYearSemester
                        Call Validating_Columns(mColumnIndex, mRowIndex)

                    Case Col1Subject
                        Call Validating_Columns(mColumnIndex, mRowIndex)

                    Case Col1SubjectManualCode
                        If AgL.XNull(DGL1.Item(Col1Subject, mRowIndex).Value).ToString.Trim = "" Then
                            DGL1.Item(Col1SubjectManualCode, mRowIndex).Value = ""
                        End If

                End Select
            End With

            Call Calculation()

            Call ProcManageControls()
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
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AgL.FSetSNo(sender, 0)

        Call Calculation()

        Try
            Call ProcManageControls()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProcManageControls()
        If Not AgL.StrCmp(Topctrl1.Mode, "Browse") Then
            If TxtSessionProgramme.Text.Trim <> "" Then
                TxtSessionProgramme.Enabled = Not mBlnIsLockSessionProgramme
            End If

            If TxtStreamYearSemester.Text.Trim <> "" Then
                TxtStreamYearSemester.Enabled = Not mBlnIsLockStreamYearSemester
            End If

            If TxtSubject.Text.Trim <> "" Then
                TxtSubject.Enabled = Not mBlnIsLockSubject
            End If

            If TxtSubjectManualCode.Text.Trim <> "" Then
                TxtSubjectManualCode.Enabled = Not mBlnIsLockSubjectManualCode
            End If

        End If
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

    Private Sub FrmAssignmentSheet_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Call PrintDocument(SearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet, DsRep1 As DataSet = Nothing
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Lab Status Report".ToUpper
            RepName = "Academic_LabStatus" : RepTitle = AgL.PubReportTitle

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT H.DocId, H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No, H.V_Date, H.ReferenceNo, " & AgL.V_No_Field("H.DocId") & " As VoucherNo, " & _
                    " H.Remark AS Header_Remark,   H.PreparedBy, H.U_EntDt, H.Edit_Date, H.ModifiedBy, H.ApprovedBy, H.ApprovedDate,  " & _
                    " Sm.Name AS Site_Name, Sm.ManualCode AS SiteManualCode, Sm.Photo As SitePhoho,   " & _
                    " L.ExperimentDate, L.ExperimentName, L.Year, L.Subject AS SubjectCode, L.SubjectManualCode, S.DisplayName As SubjectDisplayName, " & _
                    " L.StatusOfManuals, L.StatusOfExperimentalSetup, L.Remark AS Line_Remark, L.SeniorObservation, " & _
                    " L.Teacher AS TeacherCode, Sg.Name As TeacherName, Sg.DispName As TeacherDispName, Sg.ManualCode As TeacherManualCode,     " & _
                    " vSp.SessionProgramme As SessionProgrammeDesc, vSem.StreamYearSemesterDesc,  vSem.SessionManualCode, vSem.ProgrammeManualCode, vSem.StreamManualCode, vSem.SemesterSerialNo, vSem.SemesterDesc " & _
                    " FROM (Select Header.* From Sch_LabStatus Header WITH (NoLock) Where Header.DocId = " & AgL.Chk_Text(mDocId) & ") As H " & _
                    " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type      " & _
                    " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code      " & _
                    " Left Join Sch_LabStatus1 L WITH (NoLock) On L.DocId = H.DocId     " & _
                    " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = L.SessionProgramme   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = L.StreamYearSemester   " & _
                    " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = L.Subject      " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = L.Teacher     " & _
                    " Where 1=1 "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GcnRead)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)


            ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            RepName = AgPL.GetRepNameCustomize(RepName, AgL.PubReportPath)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            AgPL.ReportCommonInformation(AgL, mCrd, AgL.PubReportPath)


            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            If DsRep IsNot Nothing Then DsRep.Dispose()
            If DsRep1 IsNot Nothing Then DsRep1.Dispose()

            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class
