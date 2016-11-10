Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmLecturePlan
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1LectureNo As String = "Lecture No"
    Protected Const Col1UnitCovered As String = "Unit Covered"
    Protected Const Col1TopicCovered As String = "Topic Covered"
    Protected Const Col1DeliveryDate As String = "Delivery Date"
    Protected Const Col1PresentStudent As String = "Present Students"
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
    Friend WithEvents TxtTeacher As AgControls.AgTextBox
    Friend WithEvents LblTeacherReq As System.Windows.Forms.Label
    Friend WithEvents LblTeacher As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectManualCode As AgControls.AgTextBox
    Friend WithEvents LblSubjectManualCodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSubjectManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeReq As System.Windows.Forms.Label
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents TXtEvaluationScheme As AgControls.AgTextBox
    Friend WithEvents LblEvaluationScheme As System.Windows.Forms.Label
    Friend WithEvents TxtYear As AgControls.AgTextBox
    Friend WithEvents TxtSemester As AgControls.AgTextBox
    Friend WithEvents TxtStream As AgControls.AgTextBox
    Friend WithEvents TxtProgramme As AgControls.AgTextBox
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents TxtLecturePerWeek As AgControls.AgTextBox
    Friend WithEvents LblLecturePerWeek As System.Windows.Forms.Label
    Friend WithEvents LblLecturePerWeekReq As System.Windows.Forms.Label
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
        Me.TxtTeacher = New AgControls.AgTextBox
        Me.LblTeacherReq = New System.Windows.Forms.Label
        Me.LblTeacher = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemesterReq = New System.Windows.Forms.Label
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgrammeReq = New System.Windows.Forms.Label
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubjectReq = New System.Windows.Forms.Label
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtSubjectManualCode = New AgControls.AgTextBox
        Me.LblSubjectManualCodeReq = New System.Windows.Forms.Label
        Me.LblSubjectManualCode = New System.Windows.Forms.Label
        Me.TXtEvaluationScheme = New AgControls.AgTextBox
        Me.LblEvaluationScheme = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.TxtProgramme = New AgControls.AgTextBox
        Me.TxtStream = New AgControls.AgTextBox
        Me.TxtSemester = New AgControls.AgTextBox
        Me.TxtYear = New AgControls.AgTextBox
        Me.TxtLecturePerWeek = New AgControls.AgTextBox
        Me.LblLecturePerWeek = New System.Windows.Forms.Label
        Me.LblLecturePerWeekReq = New System.Windows.Forms.Label
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
        Me.LblDocId.Location = New System.Drawing.Point(875, 111)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(335, 49)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 140)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.LblLecturePerWeekReq)
        Me.TP1.Controls.Add(Me.TxtLecturePerWeek)
        Me.TP1.Controls.Add(Me.LblLecturePerWeek)
        Me.TP1.Controls.Add(Me.TxtYear)
        Me.TP1.Controls.Add(Me.TxtSemester)
        Me.TP1.Controls.Add(Me.TxtStream)
        Me.TP1.Controls.Add(Me.TxtProgramme)
        Me.TP1.Controls.Add(Me.TxtSession)
        Me.TP1.Controls.Add(Me.TXtEvaluationScheme)
        Me.TP1.Controls.Add(Me.LblEvaluationScheme)
        Me.TP1.Controls.Add(Me.TxtSubjectManualCode)
        Me.TP1.Controls.Add(Me.LblSubjectManualCodeReq)
        Me.TP1.Controls.Add(Me.LblSubjectManualCode)
        Me.TP1.Controls.Add(Me.TxtSubject)
        Me.TP1.Controls.Add(Me.LblSubjectReq)
        Me.TP1.Controls.Add(Me.LblSubject)
        Me.TP1.Controls.Add(Me.TxtSessionProgramme)
        Me.TP1.Controls.Add(Me.LblSessionProgrammeReq)
        Me.TP1.Controls.Add(Me.LblSessionProgramme)
        Me.TP1.Controls.Add(Me.TxtStreamYearSemester)
        Me.TP1.Controls.Add(Me.LblStreamYearSemesterReq)
        Me.TP1.Controls.Add(Me.LblStreamYearSemester)
        Me.TP1.Controls.Add(Me.TxtTeacher)
        Me.TP1.Controls.Add(Me.LblTeacherReq)
        Me.TP1.Controls.Add(Me.LblTeacher)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(984, 112)
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
        Me.TP1.Controls.SetChildIndex(Me.LblTeacher, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTeacherReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTeacher, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblStreamYearSemesterReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSessionProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSessionProgrammeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSessionProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectManualCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectManualCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubjectManualCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblEvaluationScheme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TXtEvaluationScheme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSession, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStream, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtYear, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblLecturePerWeek, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtLecturePerWeek, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblLecturePerWeekReq, 0)
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
        Me.TxtRemark.Location = New System.Drawing.Point(626, 88)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 12
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(523, 90)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 184)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(965, 361)
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
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 161)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(77, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Plan Detail :"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTeacher
        '
        Me.TxtTeacher.AgMandatory = True
        Me.TxtTeacher.AgMasterHelp = False
        Me.TxtTeacher.AgNumberLeftPlaces = 0
        Me.TxtTeacher.AgNumberNegetiveAllow = False
        Me.TxtTeacher.AgNumberRightPlaces = 0
        Me.TxtTeacher.AgPickFromLastValue = False
        Me.TxtTeacher.AgRowFilter = ""
        Me.TxtTeacher.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTeacher.AgSelectedValue = Nothing
        Me.TxtTeacher.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTeacher.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTeacher.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeacher.Location = New System.Drawing.Point(626, 48)
        Me.TxtTeacher.MaxLength = 0
        Me.TxtTeacher.Name = "TxtTeacher"
        Me.TxtTeacher.Size = New System.Drawing.Size(350, 18)
        Me.TxtTeacher.TabIndex = 10
        '
        'LblTeacherReq
        '
        Me.LblTeacherReq.AutoSize = True
        Me.LblTeacherReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTeacherReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTeacherReq.Location = New System.Drawing.Point(611, 54)
        Me.LblTeacherReq.Name = "LblTeacherReq"
        Me.LblTeacherReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTeacherReq.TabIndex = 781
        Me.LblTeacherReq.Text = "Ä"
        '
        'LblTeacher
        '
        Me.LblTeacher.AutoSize = True
        Me.LblTeacher.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTeacher.Location = New System.Drawing.Point(523, 50)
        Me.LblTeacher.Name = "LblTeacher"
        Me.LblTeacher.Size = New System.Drawing.Size(52, 15)
        Me.LblTeacher.TabIndex = 780
        Me.LblTeacher.Text = "Teacher"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgMandatory = True
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(143, 88)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(350, 18)
        Me.TxtStreamYearSemester.TabIndex = 6
        '
        'LblStreamYearSemesterReq
        '
        Me.LblStreamYearSemesterReq.AutoSize = True
        Me.LblStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStreamYearSemesterReq.Location = New System.Drawing.Point(128, 93)
        Me.LblStreamYearSemesterReq.Name = "LblStreamYearSemesterReq"
        Me.LblStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStreamYearSemesterReq.TabIndex = 784
        Me.LblStreamYearSemesterReq.Text = "Ä"
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(14, 90)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamYearSemester.TabIndex = 783
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgMandatory = True
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
        'LblSessionProgrammeReq
        '
        Me.LblSessionProgrammeReq.AutoSize = True
        Me.LblSessionProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeReq.Location = New System.Drawing.Point(358, 74)
        Me.LblSessionProgrammeReq.Name = "LblSessionProgrammeReq"
        Me.LblSessionProgrammeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeReq.TabIndex = 787
        Me.LblSessionProgrammeReq.Text = "Ä"
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
        Me.TxtSubject.AgMandatory = True
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
        Me.TxtSubject.Location = New System.Drawing.Point(626, 8)
        Me.TxtSubject.MaxLength = 0
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(350, 18)
        Me.TxtSubject.TabIndex = 7
        '
        'LblSubjectReq
        '
        Me.LblSubjectReq.AutoSize = True
        Me.LblSubjectReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectReq.Location = New System.Drawing.Point(611, 14)
        Me.LblSubjectReq.Name = "LblSubjectReq"
        Me.LblSubjectReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectReq.TabIndex = 790
        Me.LblSubjectReq.Text = "Ä"
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(523, 10)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(48, 15)
        Me.LblSubject.TabIndex = 789
        Me.LblSubject.Text = "Subject"
        '
        'TxtSubjectManualCode
        '
        Me.TxtSubjectManualCode.AgMandatory = True
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
        Me.TxtSubjectManualCode.Location = New System.Drawing.Point(626, 28)
        Me.TxtSubjectManualCode.MaxLength = 0
        Me.TxtSubjectManualCode.Name = "TxtSubjectManualCode"
        Me.TxtSubjectManualCode.Size = New System.Drawing.Size(120, 18)
        Me.TxtSubjectManualCode.TabIndex = 8
        '
        'LblSubjectManualCodeReq
        '
        Me.LblSubjectManualCodeReq.AutoSize = True
        Me.LblSubjectManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectManualCodeReq.Location = New System.Drawing.Point(611, 34)
        Me.LblSubjectManualCodeReq.Name = "LblSubjectManualCodeReq"
        Me.LblSubjectManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectManualCodeReq.TabIndex = 793
        Me.LblSubjectManualCodeReq.Text = "Ä"
        '
        'LblSubjectManualCode
        '
        Me.LblSubjectManualCode.AutoSize = True
        Me.LblSubjectManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectManualCode.Location = New System.Drawing.Point(523, 30)
        Me.LblSubjectManualCode.Name = "LblSubjectManualCode"
        Me.LblSubjectManualCode.Size = New System.Drawing.Size(81, 15)
        Me.LblSubjectManualCode.TabIndex = 792
        Me.LblSubjectManualCode.Text = "Subject Code"
        '
        'TXtEvaluationScheme
        '
        Me.TXtEvaluationScheme.AgMandatory = False
        Me.TXtEvaluationScheme.AgMasterHelp = False
        Me.TXtEvaluationScheme.AgNumberLeftPlaces = 0
        Me.TXtEvaluationScheme.AgNumberNegetiveAllow = False
        Me.TXtEvaluationScheme.AgNumberRightPlaces = 0
        Me.TXtEvaluationScheme.AgPickFromLastValue = False
        Me.TXtEvaluationScheme.AgRowFilter = ""
        Me.TXtEvaluationScheme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TXtEvaluationScheme.AgSelectedValue = Nothing
        Me.TXtEvaluationScheme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TXtEvaluationScheme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TXtEvaluationScheme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXtEvaluationScheme.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXtEvaluationScheme.Location = New System.Drawing.Point(856, 28)
        Me.TXtEvaluationScheme.MaxLength = 20
        Me.TXtEvaluationScheme.Name = "TXtEvaluationScheme"
        Me.TXtEvaluationScheme.Size = New System.Drawing.Size(120, 18)
        Me.TXtEvaluationScheme.TabIndex = 9
        '
        'LblEvaluationScheme
        '
        Me.LblEvaluationScheme.AutoSize = True
        Me.LblEvaluationScheme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEvaluationScheme.Location = New System.Drawing.Point(768, 30)
        Me.LblEvaluationScheme.Name = "LblEvaluationScheme"
        Me.LblEvaluationScheme.Size = New System.Drawing.Size(82, 15)
        Me.LblEvaluationScheme.TabIndex = 802
        Me.LblEvaluationScheme.Text = "Eval. Scheme"
        '
        'TxtSession
        '
        Me.TxtSession.AgMandatory = False
        Me.TxtSession.AgMasterHelp = False
        Me.TxtSession.AgNumberLeftPlaces = 0
        Me.TxtSession.AgNumberNegetiveAllow = False
        Me.TxtSession.AgNumberRightPlaces = 0
        Me.TxtSession.AgPickFromLastValue = False
        Me.TxtSession.AgRowFilter = ""
        Me.TxtSession.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSession.AgSelectedValue = Nothing
        Me.TxtSession.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSession.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSession.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSession.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSession.Location = New System.Drawing.Point(143, 108)
        Me.TxtSession.MaxLength = 0
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(68, 18)
        Me.TxtSession.TabIndex = 803
        Me.TxtSession.Visible = False
        '
        'TxtProgramme
        '
        Me.TxtProgramme.AgMandatory = False
        Me.TxtProgramme.AgMasterHelp = False
        Me.TxtProgramme.AgNumberLeftPlaces = 0
        Me.TxtProgramme.AgNumberNegetiveAllow = False
        Me.TxtProgramme.AgNumberRightPlaces = 0
        Me.TxtProgramme.AgPickFromLastValue = False
        Me.TxtProgramme.AgRowFilter = ""
        Me.TxtProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProgramme.AgSelectedValue = Nothing
        Me.TxtProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProgramme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProgramme.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProgramme.Location = New System.Drawing.Point(214, 108)
        Me.TxtProgramme.MaxLength = 0
        Me.TxtProgramme.Name = "TxtProgramme"
        Me.TxtProgramme.Size = New System.Drawing.Size(68, 18)
        Me.TxtProgramme.TabIndex = 804
        Me.TxtProgramme.Visible = False
        '
        'TxtStream
        '
        Me.TxtStream.AgMandatory = False
        Me.TxtStream.AgMasterHelp = False
        Me.TxtStream.AgNumberLeftPlaces = 0
        Me.TxtStream.AgNumberNegetiveAllow = False
        Me.TxtStream.AgNumberRightPlaces = 0
        Me.TxtStream.AgPickFromLastValue = False
        Me.TxtStream.AgRowFilter = ""
        Me.TxtStream.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStream.AgSelectedValue = Nothing
        Me.TxtStream.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStream.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStream.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStream.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStream.Location = New System.Drawing.Point(285, 108)
        Me.TxtStream.MaxLength = 0
        Me.TxtStream.Name = "TxtStream"
        Me.TxtStream.Size = New System.Drawing.Size(68, 18)
        Me.TxtStream.TabIndex = 805
        Me.TxtStream.Visible = False
        '
        'TxtSemester
        '
        Me.TxtSemester.AgMandatory = False
        Me.TxtSemester.AgMasterHelp = False
        Me.TxtSemester.AgNumberLeftPlaces = 0
        Me.TxtSemester.AgNumberNegetiveAllow = False
        Me.TxtSemester.AgNumberRightPlaces = 0
        Me.TxtSemester.AgPickFromLastValue = False
        Me.TxtSemester.AgRowFilter = ""
        Me.TxtSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSemester.AgSelectedValue = Nothing
        Me.TxtSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemester.Location = New System.Drawing.Point(355, 108)
        Me.TxtSemester.MaxLength = 0
        Me.TxtSemester.Name = "TxtSemester"
        Me.TxtSemester.Size = New System.Drawing.Size(68, 18)
        Me.TxtSemester.TabIndex = 806
        Me.TxtSemester.Visible = False
        '
        'TxtYear
        '
        Me.TxtYear.AgMandatory = False
        Me.TxtYear.AgMasterHelp = False
        Me.TxtYear.AgNumberLeftPlaces = 3
        Me.TxtYear.AgNumberNegetiveAllow = False
        Me.TxtYear.AgNumberRightPlaces = 0
        Me.TxtYear.AgPickFromLastValue = False
        Me.TxtYear.AgRowFilter = ""
        Me.TxtYear.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtYear.AgSelectedValue = Nothing
        Me.TxtYear.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtYear.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtYear.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYear.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Location = New System.Drawing.Point(425, 108)
        Me.TxtYear.MaxLength = 0
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(68, 18)
        Me.TxtYear.TabIndex = 807
        Me.TxtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtYear.Visible = False
        '
        'TxtLecturePerWeek
        '
        Me.TxtLecturePerWeek.AgMandatory = True
        Me.TxtLecturePerWeek.AgMasterHelp = False
        Me.TxtLecturePerWeek.AgNumberLeftPlaces = 5
        Me.TxtLecturePerWeek.AgNumberNegetiveAllow = False
        Me.TxtLecturePerWeek.AgNumberRightPlaces = 0
        Me.TxtLecturePerWeek.AgPickFromLastValue = False
        Me.TxtLecturePerWeek.AgRowFilter = ""
        Me.TxtLecturePerWeek.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLecturePerWeek.AgSelectedValue = Nothing
        Me.TxtLecturePerWeek.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLecturePerWeek.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtLecturePerWeek.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLecturePerWeek.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLecturePerWeek.Location = New System.Drawing.Point(626, 68)
        Me.TxtLecturePerWeek.MaxLength = 20
        Me.TxtLecturePerWeek.Name = "TxtLecturePerWeek"
        Me.TxtLecturePerWeek.Size = New System.Drawing.Size(120, 18)
        Me.TxtLecturePerWeek.TabIndex = 11
        Me.TxtLecturePerWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblLecturePerWeek
        '
        Me.LblLecturePerWeek.AutoSize = True
        Me.LblLecturePerWeek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLecturePerWeek.Location = New System.Drawing.Point(523, 70)
        Me.LblLecturePerWeek.Name = "LblLecturePerWeek"
        Me.LblLecturePerWeek.Size = New System.Drawing.Size(88, 15)
        Me.LblLecturePerWeek.TabIndex = 809
        Me.LblLecturePerWeek.Text = "Lecture / Week"
        '
        'LblLecturePerWeekReq
        '
        Me.LblLecturePerWeekReq.AutoSize = True
        Me.LblLecturePerWeekReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblLecturePerWeekReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblLecturePerWeekReq.Location = New System.Drawing.Point(611, 76)
        Me.LblLecturePerWeekReq.Name = "LblLecturePerWeekReq"
        Me.LblLecturePerWeekReq.Size = New System.Drawing.Size(10, 7)
        Me.LblLecturePerWeekReq.TabIndex = 810
        Me.LblLecturePerWeekReq.Text = "Ä"
        '
        'FrmLecturePlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PnlFooter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmLecturePlan"
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

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.LecturePlan) & ""
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
        MainTableName = "Sch_LecturePlan"
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

        If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
            mCondStr += " And H.PreparedBy = '" & AgL.PubUserName & "' "
        End If


        mQry = " Select H.DocID As SearchCode " & _
                " From Sch_LecturePlan H With (NoLock) " & _
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

        If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
            mCondStr += " And H.PreparedBy = '" & AgL.PubUserName & "' "
        End If


        AgL.PubFindQry = "SELECT H.DocId AS SearchCode,  " & _
                            " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " vSp.SessionProgramme As [" & LblSessionProgramme.Text & "], " & _
                            " vSem.StreamYearSemesterDesc As [" & LblStreamYearSemester.Text & "], " & _
                            " S.DisplayName As [" & LblSubject.Text & "], " & _
                            " H.SubjectManualCode As [" & LblSubjectManualCode.Text & "], " & _
                            " H.EvaluationScheme As [" & LblEvaluationScheme.Text & "], " & _
                            " H.LecturePerWeek As [" & LblLecturePerWeek.Text & "], " & _
                            " Sg.Name As [" & LblTeacher.Text & "], " & _
                            " Sm.Name AS [" & LblSite_Code.Text & "], " & _
                            " H.Remark " & _
                            " FROM dbo.Sch_LecturePlan H WITH (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code  " & _
                            " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = H.SessionProgramme " & _
                            " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = H.StreamYearSemester " & _
                            " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject  " & _
                            " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.Teacher " & mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc"

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgNumberColumn(DGL1, Col1LectureNo, 50, 5, 0, False, Col1LectureNo, True, False, True)
            .AddAgTextColumn(DGL1, Col1UnitCovered, 110, 20, Col1UnitCovered, True, False, False)
            .AddAgTextColumn(DGL1, Col1TopicCovered, 300, 100, Col1TopicCovered, True, False, False)
            .AddAgDateColumn(DGL1, Col1DeliveryDate, 80, Col1DeliveryDate, True, False, False)
            .AddAgNumberColumn(DGL1, Col1PresentStudent, 60, 5, 0, False, Col1PresentStudent, True, False, True)
            .AddAgTextColumn(DGL1, Col1Remark, 150, 255, Col1Remark, True, False, False)
            .AddAgTextColumn(DGL1, Col1SeniorObservation, 150, 255, Col1SeniorObservation, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        DGL1.Columns(Col1TopicCovered).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0

        mQry = "UPDATE dbo.Sch_LecturePlan " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                " StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                " Session = " & AgL.Chk_Text(TxtSession.Text) & ", " & _
                " Programme = " & AgL.Chk_Text(TxtProgramme.Text) & ", " & _
                " Stream = " & AgL.Chk_Text(TxtStream.Text) & ", " & _
                " Semester = " & AgL.Chk_Text(TxtSemester.Text) & ", " & _
                " Year = " & AgL.Chk_Text(TxtYear.Text) & ", " & _
                " Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                " SubjectManualCode = " & AgL.Chk_Text(TxtSubjectManualCode.Text) & ", " & _
                " Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                " LecturePerWeek = " & Val(TxtLecturePerWeek.Text) & ", " & _
                " EvaluationScheme = " & AgL.Chk_Text(TXtEvaluationScheme.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Sch_LecturePlan1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1TopicCovered, bIntI).Value.ToString.Trim <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Sch_LecturePlan1 ( " & _
                        " DocId, Sr, LectureNo, UnitCovered, TopicCovered, DeliveryDate, PresentStudent, Remark, SeniorObservation) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & Val(DGL1.Item(Col1LectureNo, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1UnitCovered, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1TopicCovered, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1DeliveryDate, bIntI).Value) & ", " & _
                        " " & Val(DGL1.Item(Col1PresentStudent, bIntI).Value) & ", " & _
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
        mQry = "Delete From Sch_LecturePlan1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Sch_LecturePlan Where DocId = '" & SearchCode & "' "
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
            " From Sch_LecturePlan H With (NoLock) " & _
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
                TXtEvaluationScheme.Text = AgL.XNull(.Rows(0)("EvaluationScheme"))
                TxtTeacher.AgSelectedValue = AgL.XNull(.Rows(0)("Teacher"))


                TxtSession.Text = AgL.XNull(.Rows(0)("Session"))
                TxtProgramme.Text = AgL.XNull(.Rows(0)("Programme"))
                TxtStream.Text = AgL.XNull(.Rows(0)("Stream"))
                TxtSemester.Text = AgL.XNull(.Rows(0)("Semester"))
                TxtYear.Text = AgL.VNull(.Rows(0)("Year"))
                TxtLecturePerWeek.Text = AgL.VNull(.Rows(0)("LecturePerWeek"))

                mQry = "Select L.* " & _
                        " From Sch_LecturePlan1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.Item(Col1LectureNo, bIntI).Value = AgL.VNull(.Rows(bIntI)("LectureNo"))
                            DGL1.Item(Col1UnitCovered, bIntI).Value = AgL.XNull(.Rows(bIntI)("UnitCovered"))
                            DGL1.Item(Col1TopicCovered, bIntI).Value = AgL.XNull(.Rows(bIntI)("TopicCovered"))
                            DGL1.Item(Col1DeliveryDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("DeliveryDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1PresentStudent, bIntI).Value = AgL.VNull(.Rows(bIntI)("PresentStudent"))
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
        Dim DrTemp As DataRow() = Nothing
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AgL.PubUserName

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtTeacher.AgHelpDataSet IsNot Nothing Then
            DrTemp = TxtTeacher.AgHelpDataSet.Tables(0).Select("LogInUser = '" & AgL.PubUserName & "'")
            If DrTemp.Length > 0 Then
                TxtTeacher.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            Else
                If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                    MsgBox("Please Define Login User in Teacher Master!...")
                End If
            End If
            DrTemp = Nothing
        End If


        If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
            TxtTeacher.Enabled = False
        End If

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
                    " CASE WHEN E.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END IsActive , Sg.LogInUser" & _
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
        TxtStreamYearSemester.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.StreamYearSemester.Copy
        TxtTeacher.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Teacher.Copy
        TxtSubject.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Subject.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer = 0

        LblValTotal.Text = 0

        'For bIntI = 0 To DGL1.RowCount - 1
        '    If DGL1.Item(Col1TopicCovered, bIntI).Value Is Nothing Then DGL1.Item(Col1TopicCovered, bIntI).Value = ""

        '    If DGL1.Item(Col1TopicCovered, bIntI).Value <> "" Then
        '        'Footer Calculation

        '        LblValTotal.Text = Val(LblValTotal.Text) + 1
        '    End If
        'Next
    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtSessionProgramme, LblSessionProgramme.Text) Then Exit Function
            If AglObj.RequiredField(TxtStreamYearSemester, LblStreamYearSemester.Text) Then Exit Function
            If AglObj.RequiredField(TxtSubject, LblSubject.Text) Then Exit Function
            If AglObj.RequiredField(TxtSubjectManualCode, LblSubjectManualCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtTeacher, LblTeacher.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function
            If AglObj.RequiredField(TxtLecturePerWeek, LblLecturePerWeek.Text) Then Exit Function

            If AgL.XNull(LblStreamYearSemester.Tag).ToString <> "" Then
                If Not AgL.StrCmp(LblStreamYearSemester.Tag, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Please Check Semester!...")
                    TxtStreamYearSemester.Focus() : Exit Function
                End If
            End If

            If Val(TxtYear.Text) > 0 Then TxtYear.Text = ""

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1TopicCovered).Index) Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1TopicCovered, bIntI).Value Is Nothing Then DGL1.Item(Col1TopicCovered, bIntI).Value = ""

                If DGL1.Item(Col1TopicCovered, bIntI).Value <> "" Then
                    If DGL1.Item(Col1DeliveryDate, bIntI).Value <> "" Then
                        If CDate(DGL1.Item(Col1DeliveryDate, bIntI).Value) < CDate(TxtV_Date.Text) Then
                            MsgBox("Delivery Date < " & LblV_Date.Text & " At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                            DGL1.CurrentCell = DGL1(Col1DeliveryDate, bIntI) : DGL1.Focus() : Exit Function
                        End If
                    End If
                End If
            Next

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Sch_LecturePlan H With (NoLock) " & _
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
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtRemark.Enter, TxtDivision.Enter, TxtDocId.Enter, TxtReferenceNo.Enter, _
        TxtSite_Code.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtRemark.Enter, TxtSessionProgramme.Enter, _
        TxtStreamYearSemester.Enter, TxtSubject.Enter, TxtSubjectManualCode.Enter, TxtTeacher.Enter, _
        TXtEvaluationScheme.Enter, TxtLecturePerWeek.Enter
        Dim bStrFilter As String = ""
        Try
            Select Case sender.name
                Case TxtTeacher.Name
                    bStrFilter = " 1=1 "

                    If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                        bStrFilter += " And LogInUser = '" & AgL.PubUserName & "' "
                    End If

                    TxtTeacher.AgRowFilter = bStrFilter & " and IsActive = 'Yes' "

                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, _
        TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtSessionProgramme.Validating, _
        TxtStreamYearSemester.Validating, TxtSubject.Validating, TxtSubjectManualCode.Validating, TxtTeacher.Validating, _
        TXtEvaluationScheme.Validating, TxtLecturePerWeek.Validating

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
                    TxtSession.Text = ""
                    TxtProgramme.Text = ""
                    TxtStream.Text = ""
                    TxtSemester.Text = ""
                    TxtYear.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        LblStreamYearSemester.Tag = AgL.XNull(DrTemp(0)("SessionProgrammeCode"))

                        TxtSession.Text = AgL.XNull(DrTemp(0)("SessionCode"))
                        TxtProgramme.Text = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                        TxtStream.Text = AgL.XNull(DrTemp(0)("StreamCode"))
                        TxtSemester.Text = AgL.XNull(DrTemp(0)("SemesterCode"))

                        If AgL.VNull(DrTemp(0)("YearSerial")) > 0 Then
                            TxtYear.Text = AgL.VNull(DrTemp(0)("YearSerial"))
                        Else
                            TxtYear.Text = ""
                        End If
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

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.
        If Topctrl1.Mode = "Edit" Then
            TxtTeacher.Enabled = False
        End If
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
                'Case <ColumnIndex>
                '<Executbale Code>
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
                    'Case <ColumnIndex>
                    '<Executbale Code>
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
        If Topctrl1.Mode = "Browse" Then Exit Sub
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

            AgL.PubReportTitle = Me.Text.ToUpper
            RepName = "Academic_LecturePlan" : RepTitle = AgL.PubReportTitle

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT H.DocId, H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No, H.V_Date, H.ReferenceNo, " & AgL.V_No_Field("H.DocId") & " As VoucherNo, " & _
                        " H.Subject AS SubjectCode, S.DisplayName As SubjectDisplayName, H.SubjectManualCode,  " & _
                        " H.Teacher AS TeacherCode, Sg.Name As TeacherName, Sg.DispName As TeacherDispName, Sg.ManualCode As TeacherManualCode,   " & _
                        " H.LecturePerWeek, H.EvaluationScheme, H.Remark AS Header_Remark,  " & _
                        " H.PreparedBy, H.U_EntDt, H.Edit_Date, H.ModifiedBy, H.ApprovedBy, H.ApprovedDate, " & _
                        " Sm.Name AS Site_Name, Sm.ManualCode AS SiteManualCode, Sm.Photo As SitePhoho, " & _
                        " L.LectureNo, L.UnitCovered, L.TopicCovered, L.DeliveryDate, L.PresentStudent, L.Remark, L.SeniorObservation, " & _
                        " vSp.SessionProgramme As SessionProgrammeDesc, vSem.StreamYearSemesterDesc, " & _
                        " vSem.SessionManualCode, vSem.ProgrammeManualCode, vSem.StreamManualCode, vSem.SemesterSerialNo, vSem.SemesterDesc, H.Year " & _
                        " FROM (Select Header.* From Sch_LecturePlan Header WITH (NoLock) Where Header.DocId = " & AgL.Chk_Text(mDocId) & ") As H " & _
                        " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type    " & _
                        " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code    " & _
                        " Left Join Sch_LecturePlan1 L WITH (NoLock) On L.DocId = H.DocId   " & _
                        " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = H.SessionProgramme " & _
                        " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = H.StreamYearSemester " & _
                        " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject    " & _
                        " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.Teacher   " & _
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
