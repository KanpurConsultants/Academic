Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmLabWork
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1RollNo As String = "RollNo"
    Protected Const Col1Student As String = "Student"
    Protected Const Col1AdmissionDocId As String = "AdmissionDocId"
    Protected Const Col1StreamYearSemester As String = "StreamYearSemester"
    Protected Const Col1Experiment As String = "Experiment"
    Protected Const Col1BtnNewExperiment As String = "New Experiment"
    Protected Const Col1PerformedDate As String = "Performed Date"
    Protected Const Col1SubmissionDate As String = "Submission Date"
    Protected Const Col1Session As String = "Session"
    Protected Const Col1Program As String = "Program"
    Protected Const Col1Stream As String = "Stream"
    Protected Const Col1Semester As String = "Semester"
    Protected Const Col1Year As String = "Year"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"


#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox



    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Friend WithEvents TxtTeacher As AgControls.AgTextBox
    Friend WithEvents LblTeacherReq As System.Windows.Forms.Label
    Friend WithEvents LblTeacher As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectManualCode As AgControls.AgTextBox
    Friend WithEvents LblSubjectManualCodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSubjectManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents TxtYear As AgControls.AgTextBox
    Friend WithEvents TxtSemester As AgControls.AgTextBox
    Friend WithEvents TxtStream As AgControls.AgTextBox
    Friend WithEvents TxtProgramme As AgControls.AgTextBox
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblAdmissionDocId As System.Windows.Forms.Label
    Friend WithEvents TxtHOD As AgControls.AgTextBox
    Friend WithEvents LblHOD As System.Windows.Forms.Label
    Friend WithEvents TxtStudent As AgControls.AgTextBox
    Friend WithEvents TxtRollNo As AgControls.AgTextBox
    Friend WithEvents LblRollNo As System.Windows.Forms.Label
    Friend WithEvents TxtSubmissionDate As AgControls.AgTextBox
    Friend WithEvents LblSubmissionDate As System.Windows.Forms.Label
    Friend WithEvents TxtExperiment As AgControls.AgTextBox
    Friend WithEvents LblExperimentReq As System.Windows.Forms.Label
    Friend WithEvents LblExperiment As System.Windows.Forms.Label
    Friend WithEvents LblAdmissionDocIdReq As System.Windows.Forms.Label
    Friend WithEvents TxtClassSectionSubSection As AgControls.AgTextBox
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSection As System.Windows.Forms.Label
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
    Friend WithEvents BtnFillStudent As System.Windows.Forms.Button
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtTeacher = New AgControls.AgTextBox
        Me.LblTeacherReq = New System.Windows.Forms.Label
        Me.LblTeacher = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubjectReq = New System.Windows.Forms.Label
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtSubjectManualCode = New AgControls.AgTextBox
        Me.LblSubjectManualCodeReq = New System.Windows.Forms.Label
        Me.LblSubjectManualCode = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.TxtProgramme = New AgControls.AgTextBox
        Me.TxtStream = New AgControls.AgTextBox
        Me.TxtSemester = New AgControls.AgTextBox
        Me.TxtYear = New AgControls.AgTextBox
        Me.TxtHOD = New AgControls.AgTextBox
        Me.LblHOD = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblAdmissionDocId = New System.Windows.Forms.Label
        Me.TxtRollNo = New AgControls.AgTextBox
        Me.LblRollNo = New System.Windows.Forms.Label
        Me.TxtStudent = New AgControls.AgTextBox
        Me.TxtSubmissionDate = New AgControls.AgTextBox
        Me.LblSubmissionDate = New System.Windows.Forms.Label
        Me.TxtExperiment = New AgControls.AgTextBox
        Me.LblExperimentReq = New System.Windows.Forms.Label
        Me.LblExperiment = New System.Windows.Forms.Label
        Me.LblAdmissionDocIdReq = New System.Windows.Forms.Label
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.LblClassSectionSubSection = New System.Windows.Forms.Label
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.TxtClassSectionSubSection = New AgControls.AgTextBox
        Me.BtnFillStudent = New System.Windows.Forms.Button
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 461)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(219, 470)
        '
        'TxtDivision
        '
        '
        'TxtDocId
        '
        Me.TxtDocId.Location = New System.Drawing.Point(948, 23)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(245, 58)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(352, 56)
        Me.TxtV_No.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(106, 62)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(11, 58)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(106, 42)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(122, 56)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(11, 37)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(122, 36)
        Me.TxtV_Type.Size = New System.Drawing.Size(350, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(106, 22)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(11, 17)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(122, 16)
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(901, 25)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(318, 57)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 17)
        Me.Tc1.Size = New System.Drawing.Size(992, 200)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtClassSectionSubSection)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.TxtClassSection)
        Me.TP1.Controls.Add(Me.LblTeacher)
        Me.TP1.Controls.Add(Me.LblTeacherReq)
        Me.TP1.Controls.Add(Me.BtnFillStudent)
        Me.TP1.Controls.Add(Me.TxtTeacher)
        Me.TP1.Controls.Add(Me.LblSubject)
        Me.TP1.Controls.Add(Me.LblSubjectReq)
        Me.TP1.Controls.Add(Me.TxtSubject)
        Me.TP1.Controls.Add(Me.LblSubjectManualCode)
        Me.TP1.Controls.Add(Me.LblSubjectManualCodeReq)
        Me.TP1.Controls.Add(Me.TxtSubjectManualCode)
        Me.TP1.Controls.Add(Me.LblHOD)
        Me.TP1.Controls.Add(Me.TxtHOD)
        Me.TP1.Controls.Add(Me.LblClassSection)
        Me.TP1.Controls.Add(Me.LblClassSectionSubSection)
        Me.TP1.Controls.Add(Me.LblAdmissionDocIdReq)
        Me.TP1.Controls.Add(Me.TxtExperiment)
        Me.TP1.Controls.Add(Me.LblExperimentReq)
        Me.TP1.Controls.Add(Me.LblExperiment)
        Me.TP1.Controls.Add(Me.TxtSubmissionDate)
        Me.TP1.Controls.Add(Me.TxtStudent)
        Me.TP1.Controls.Add(Me.TxtRollNo)
        Me.TP1.Controls.Add(Me.LblRollNo)
        Me.TP1.Controls.Add(Me.TxtAdmissionDocId)
        Me.TP1.Controls.Add(Me.LblAdmissionDocId)
        Me.TP1.Controls.Add(Me.TxtYear)
        Me.TP1.Controls.Add(Me.TxtSemester)
        Me.TP1.Controls.Add(Me.TxtStream)
        Me.TP1.Controls.Add(Me.TxtProgramme)
        Me.TP1.Controls.Add(Me.TxtSession)
        Me.TP1.Controls.Add(Me.TxtSessionProgramme)
        Me.TP1.Controls.Add(Me.LblSessionProgramme)
        Me.TP1.Controls.Add(Me.TxtStreamYearSemester)
        Me.TP1.Controls.Add(Me.LblStreamYearSemester)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.LblSubmissionDate)
        Me.TP1.Size = New System.Drawing.Size(984, 172)
        Me.TP1.Controls.SetChildIndex(Me.LblSubmissionDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSessionProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSessionProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSession, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtProgramme, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStream, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtYear, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAdmissionDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAdmissionDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRollNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRollNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStudent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubmissionDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblExperiment, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblExperimentReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtExperiment, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAdmissionDocIdReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblClassSectionSubSection, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblClassSection, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtHOD, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblHOD, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubjectManualCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectManualCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectManualCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTeacher, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFillStudent, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTeacherReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTeacher, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtClassSection, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtClassSectionSubSection, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 1
        '
        'GBoxApproved
        '
        Me.GBoxApproved.Location = New System.Drawing.Point(799, 470)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(12, 470)
        '
        'GBoxModified
        '
        Me.GBoxModified.Location = New System.Drawing.Point(424, 470)
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
        Me.TxtRemark.Location = New System.Drawing.Point(612, 113)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 13
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(506, 115)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 2
        Me.LblRemark.Text = "Remark"
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(106, 82)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(122, 76)
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
        Me.LblReferenceNo.Location = New System.Drawing.Point(11, 77)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'TxtTeacher
        '
        Me.TxtTeacher.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtTeacher.Location = New System.Drawing.Point(612, 73)
        Me.TxtTeacher.MaxLength = 0
        Me.TxtTeacher.Name = "TxtTeacher"
        Me.TxtTeacher.Size = New System.Drawing.Size(350, 18)
        Me.TxtTeacher.TabIndex = 11
        '
        'LblTeacherReq
        '
        Me.LblTeacherReq.AutoSize = True
        Me.LblTeacherReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTeacherReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTeacherReq.Location = New System.Drawing.Point(591, 79)
        Me.LblTeacherReq.Name = "LblTeacherReq"
        Me.LblTeacherReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTeacherReq.TabIndex = 781
        Me.LblTeacherReq.Text = "Ä"
        '
        'LblTeacher
        '
        Me.LblTeacher.AutoSize = True
        Me.LblTeacher.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTeacher.Location = New System.Drawing.Point(506, 75)
        Me.LblTeacher.Name = "LblTeacher"
        Me.LblTeacher.Size = New System.Drawing.Size(52, 15)
        Me.LblTeacher.TabIndex = 780
        Me.LblTeacher.Text = "Teacher"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(122, 96)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(350, 18)
        Me.TxtStreamYearSemester.TabIndex = 6
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(11, 98)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamYearSemester.TabIndex = 783
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(352, 76)
        Me.TxtSessionProgramme.MaxLength = 0
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(120, 18)
        Me.TxtSessionProgramme.TabIndex = 5
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(245, 78)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(73, 15)
        Me.LblSessionProgramme.TabIndex = 786
        Me.LblSessionProgramme.Text = "Programme"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSubject.Location = New System.Drawing.Point(612, 33)
        Me.TxtSubject.MaxLength = 0
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(350, 18)
        Me.TxtSubject.TabIndex = 9
        '
        'LblSubjectReq
        '
        Me.LblSubjectReq.AutoSize = True
        Me.LblSubjectReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectReq.Location = New System.Drawing.Point(591, 39)
        Me.LblSubjectReq.Name = "LblSubjectReq"
        Me.LblSubjectReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectReq.TabIndex = 790
        Me.LblSubjectReq.Text = "Ä"
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(506, 35)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(48, 15)
        Me.LblSubject.TabIndex = 789
        Me.LblSubject.Text = "Subject"
        '
        'TxtSubjectManualCode
        '
        Me.TxtSubjectManualCode.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSubjectManualCode.Location = New System.Drawing.Point(612, 53)
        Me.TxtSubjectManualCode.MaxLength = 0
        Me.TxtSubjectManualCode.Name = "TxtSubjectManualCode"
        Me.TxtSubjectManualCode.Size = New System.Drawing.Size(350, 18)
        Me.TxtSubjectManualCode.TabIndex = 10
        '
        'LblSubjectManualCodeReq
        '
        Me.LblSubjectManualCodeReq.AutoSize = True
        Me.LblSubjectManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectManualCodeReq.Location = New System.Drawing.Point(591, 59)
        Me.LblSubjectManualCodeReq.Name = "LblSubjectManualCodeReq"
        Me.LblSubjectManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectManualCodeReq.TabIndex = 793
        Me.LblSubjectManualCodeReq.Text = "Ä"
        '
        'LblSubjectManualCode
        '
        Me.LblSubjectManualCode.AutoSize = True
        Me.LblSubjectManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectManualCode.Location = New System.Drawing.Point(506, 55)
        Me.LblSubjectManualCode.Name = "LblSubjectManualCode"
        Me.LblSubjectManualCode.Size = New System.Drawing.Size(81, 15)
        Me.LblSubjectManualCode.TabIndex = 792
        Me.LblSubjectManualCode.Text = "Subject Code"
        '
        'TxtSession
        '
        Me.TxtSession.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSession.Location = New System.Drawing.Point(845, 75)
        Me.TxtSession.MaxLength = 0
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(68, 18)
        Me.TxtSession.TabIndex = 803
        Me.TxtSession.Visible = False
        '
        'TxtProgramme
        '
        Me.TxtProgramme.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtProgramme.Location = New System.Drawing.Point(916, 75)
        Me.TxtProgramme.MaxLength = 0
        Me.TxtProgramme.Name = "TxtProgramme"
        Me.TxtProgramme.Size = New System.Drawing.Size(68, 18)
        Me.TxtProgramme.TabIndex = 804
        Me.TxtProgramme.Visible = False
        '
        'TxtStream
        '
        Me.TxtStream.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStream.Location = New System.Drawing.Point(846, 55)
        Me.TxtStream.MaxLength = 0
        Me.TxtStream.Name = "TxtStream"
        Me.TxtStream.Size = New System.Drawing.Size(68, 18)
        Me.TxtStream.TabIndex = 805
        Me.TxtStream.Visible = False
        '
        'TxtSemester
        '
        Me.TxtSemester.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSemester.Location = New System.Drawing.Point(916, 55)
        Me.TxtSemester.MaxLength = 0
        Me.TxtSemester.Name = "TxtSemester"
        Me.TxtSemester.Size = New System.Drawing.Size(68, 18)
        Me.TxtSemester.TabIndex = 806
        Me.TxtSemester.Visible = False
        '
        'TxtYear
        '
        Me.TxtYear.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtYear.Location = New System.Drawing.Point(896, 3)
        Me.TxtYear.MaxLength = 0
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(68, 18)
        Me.TxtYear.TabIndex = 807
        Me.TxtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtYear.Visible = False
        '
        'TxtHOD
        '
        Me.TxtHOD.AgAllowUserToEnableMasterHelp = False
        Me.TxtHOD.AgMandatory = False
        Me.TxtHOD.AgMasterHelp = False
        Me.TxtHOD.AgNumberLeftPlaces = 0
        Me.TxtHOD.AgNumberNegetiveAllow = False
        Me.TxtHOD.AgNumberRightPlaces = 0
        Me.TxtHOD.AgPickFromLastValue = False
        Me.TxtHOD.AgRowFilter = ""
        Me.TxtHOD.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtHOD.AgSelectedValue = Nothing
        Me.TxtHOD.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtHOD.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtHOD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtHOD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHOD.Location = New System.Drawing.Point(612, 93)
        Me.TxtHOD.MaxLength = 0
        Me.TxtHOD.Name = "TxtHOD"
        Me.TxtHOD.Size = New System.Drawing.Size(350, 18)
        Me.TxtHOD.TabIndex = 12
        '
        'LblHOD
        '
        Me.LblHOD.AutoSize = True
        Me.LblHOD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHOD.Location = New System.Drawing.Point(506, 95)
        Me.LblHOD.Name = "LblHOD"
        Me.LblHOD.Size = New System.Drawing.Size(34, 15)
        Me.LblHOD.TabIndex = 811
        Me.LblHOD.Text = "HOD"
        '
        'TxtAdmissionDocId
        '
        Me.TxtAdmissionDocId.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdmissionDocId.AgMandatory = True
        Me.TxtAdmissionDocId.AgMasterHelp = False
        Me.TxtAdmissionDocId.AgNumberLeftPlaces = 0
        Me.TxtAdmissionDocId.AgNumberNegetiveAllow = False
        Me.TxtAdmissionDocId.AgNumberRightPlaces = 0
        Me.TxtAdmissionDocId.AgPickFromLastValue = False
        Me.TxtAdmissionDocId.AgRowFilter = ""
        Me.TxtAdmissionDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionDocId.AgSelectedValue = Nothing
        Me.TxtAdmissionDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(951, 123)
        Me.TxtAdmissionDocId.MaxLength = 0
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(28, 18)
        Me.TxtAdmissionDocId.TabIndex = 12
        Me.TxtAdmissionDocId.Visible = False
        '
        'LblAdmissionDocId
        '
        Me.LblAdmissionDocId.AutoSize = True
        Me.LblAdmissionDocId.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionDocId.Location = New System.Drawing.Point(893, 129)
        Me.LblAdmissionDocId.Name = "LblAdmissionDocId"
        Me.LblAdmissionDocId.Size = New System.Drawing.Size(49, 15)
        Me.LblAdmissionDocId.TabIndex = 813
        Me.LblAdmissionDocId.Text = "Student"
        Me.LblAdmissionDocId.Visible = False
        '
        'TxtRollNo
        '
        Me.TxtRollNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtRollNo.AgMandatory = False
        Me.TxtRollNo.AgMasterHelp = False
        Me.TxtRollNo.AgNumberLeftPlaces = 0
        Me.TxtRollNo.AgNumberNegetiveAllow = False
        Me.TxtRollNo.AgNumberRightPlaces = 0
        Me.TxtRollNo.AgPickFromLastValue = False
        Me.TxtRollNo.AgRowFilter = ""
        Me.TxtRollNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRollNo.AgSelectedValue = Nothing
        Me.TxtRollNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRollNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRollNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRollNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRollNo.Location = New System.Drawing.Point(951, 143)
        Me.TxtRollNo.MaxLength = 0
        Me.TxtRollNo.Name = "TxtRollNo"
        Me.TxtRollNo.Size = New System.Drawing.Size(28, 18)
        Me.TxtRollNo.TabIndex = 13
        Me.TxtRollNo.Visible = False
        '
        'LblRollNo
        '
        Me.LblRollNo.AutoSize = True
        Me.LblRollNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRollNo.Location = New System.Drawing.Point(893, 149)
        Me.LblRollNo.Name = "LblRollNo"
        Me.LblRollNo.Size = New System.Drawing.Size(51, 15)
        Me.LblRollNo.TabIndex = 815
        Me.LblRollNo.Text = "Roll No."
        Me.LblRollNo.Visible = False
        '
        'TxtStudent
        '
        Me.TxtStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtStudent.AgMandatory = False
        Me.TxtStudent.AgMasterHelp = False
        Me.TxtStudent.AgNumberLeftPlaces = 0
        Me.TxtStudent.AgNumberNegetiveAllow = False
        Me.TxtStudent.AgNumberRightPlaces = 0
        Me.TxtStudent.AgPickFromLastValue = False
        Me.TxtStudent.AgRowFilter = ""
        Me.TxtStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStudent.AgSelectedValue = Nothing
        Me.TxtStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStudent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStudent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStudent.Location = New System.Drawing.Point(848, 99)
        Me.TxtStudent.MaxLength = 0
        Me.TxtStudent.Name = "TxtStudent"
        Me.TxtStudent.Size = New System.Drawing.Size(120, 18)
        Me.TxtStudent.TabIndex = 816
        Me.TxtStudent.Visible = False
        '
        'TxtSubmissionDate
        '
        Me.TxtSubmissionDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtSubmissionDate.AgMandatory = False
        Me.TxtSubmissionDate.AgMasterHelp = False
        Me.TxtSubmissionDate.AgNumberLeftPlaces = 0
        Me.TxtSubmissionDate.AgNumberNegetiveAllow = False
        Me.TxtSubmissionDate.AgNumberRightPlaces = 0
        Me.TxtSubmissionDate.AgPickFromLastValue = False
        Me.TxtSubmissionDate.AgRowFilter = ""
        Me.TxtSubmissionDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubmissionDate.AgSelectedValue = Nothing
        Me.TxtSubmissionDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubmissionDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtSubmissionDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubmissionDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubmissionDate.Location = New System.Drawing.Point(949, 164)
        Me.TxtSubmissionDate.MaxLength = 0
        Me.TxtSubmissionDate.Name = "TxtSubmissionDate"
        Me.TxtSubmissionDate.Size = New System.Drawing.Size(30, 18)
        Me.TxtSubmissionDate.TabIndex = 14
        Me.TxtSubmissionDate.Visible = False
        '
        'LblSubmissionDate
        '
        Me.LblSubmissionDate.AutoSize = True
        Me.LblSubmissionDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubmissionDate.Location = New System.Drawing.Point(885, 164)
        Me.LblSubmissionDate.Name = "LblSubmissionDate"
        Me.LblSubmissionDate.Size = New System.Drawing.Size(103, 15)
        Me.LblSubmissionDate.TabIndex = 818
        Me.LblSubmissionDate.Text = "Submission Date"
        Me.LblSubmissionDate.Visible = False
        '
        'TxtExperiment
        '
        Me.TxtExperiment.AgAllowUserToEnableMasterHelp = False
        Me.TxtExperiment.AgMandatory = True
        Me.TxtExperiment.AgMasterHelp = False
        Me.TxtExperiment.AgNumberLeftPlaces = 0
        Me.TxtExperiment.AgNumberNegetiveAllow = False
        Me.TxtExperiment.AgNumberRightPlaces = 0
        Me.TxtExperiment.AgPickFromLastValue = False
        Me.TxtExperiment.AgRowFilter = ""
        Me.TxtExperiment.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtExperiment.AgSelectedValue = Nothing
        Me.TxtExperiment.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtExperiment.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtExperiment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtExperiment.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExperiment.Location = New System.Drawing.Point(951, 185)
        Me.TxtExperiment.MaxLength = 0
        Me.TxtExperiment.Name = "TxtExperiment"
        Me.TxtExperiment.Size = New System.Drawing.Size(22, 18)
        Me.TxtExperiment.TabIndex = 9
        Me.TxtExperiment.Visible = False
        '
        'LblExperimentReq
        '
        Me.LblExperimentReq.AutoSize = True
        Me.LblExperimentReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblExperimentReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblExperimentReq.Location = New System.Drawing.Point(914, 143)
        Me.LblExperimentReq.Name = "LblExperimentReq"
        Me.LblExperimentReq.Size = New System.Drawing.Size(10, 7)
        Me.LblExperimentReq.TabIndex = 821
        Me.LblExperimentReq.Text = "Ä"
        Me.LblExperimentReq.Visible = False
        '
        'LblExperiment
        '
        Me.LblExperiment.AutoSize = True
        Me.LblExperiment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExperiment.Location = New System.Drawing.Point(892, 186)
        Me.LblExperiment.Name = "LblExperiment"
        Me.LblExperiment.Size = New System.Drawing.Size(69, 15)
        Me.LblExperiment.TabIndex = 820
        Me.LblExperiment.Text = "Experiment"
        Me.LblExperiment.Visible = False
        '
        'LblAdmissionDocIdReq
        '
        Me.LblAdmissionDocIdReq.AutoSize = True
        Me.LblAdmissionDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAdmissionDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAdmissionDocIdReq.Location = New System.Drawing.Point(936, 129)
        Me.LblAdmissionDocIdReq.Name = "LblAdmissionDocIdReq"
        Me.LblAdmissionDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAdmissionDocIdReq.TabIndex = 822
        Me.LblAdmissionDocIdReq.Text = "Ä"
        Me.LblAdmissionDocIdReq.Visible = False
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(506, 17)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
        Me.LblClassSection.TabIndex = 826
        Me.LblClassSection.Text = "Class/Section"
        '
        'LblClassSectionSubSection
        '
        Me.LblClassSectionSubSection.AutoSize = True
        Me.LblClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSectionSubSection.Location = New System.Drawing.Point(739, 17)
        Me.LblClassSectionSubSection.Name = "LblClassSectionSubSection"
        Me.LblClassSectionSubSection.Size = New System.Drawing.Size(75, 13)
        Me.LblClassSectionSubSection.TabIndex = 828
        Me.LblClassSectionSubSection.Text = "Sub Section"
        '
        'TxtClassSection
        '
        Me.TxtClassSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSection.AgMandatory = False
        Me.TxtClassSection.AgMasterHelp = False
        Me.TxtClassSection.AgNumberLeftPlaces = 0
        Me.TxtClassSection.AgNumberNegetiveAllow = False
        Me.TxtClassSection.AgNumberRightPlaces = 0
        Me.TxtClassSection.AgPickFromLastValue = False
        Me.TxtClassSection.AgRowFilter = ""
        Me.TxtClassSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSection.AgSelectedValue = Nothing
        Me.TxtClassSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClassSection.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSection.Location = New System.Drawing.Point(612, 14)
        Me.TxtClassSection.MaxLength = 0
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(120, 18)
        Me.TxtClassSection.TabIndex = 7
        '
        'TxtClassSectionSubSection
        '
        Me.TxtClassSectionSubSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSectionSubSection.AgMandatory = False
        Me.TxtClassSectionSubSection.AgMasterHelp = False
        Me.TxtClassSectionSubSection.AgNumberLeftPlaces = 0
        Me.TxtClassSectionSubSection.AgNumberNegetiveAllow = False
        Me.TxtClassSectionSubSection.AgNumberRightPlaces = 0
        Me.TxtClassSectionSubSection.AgPickFromLastValue = False
        Me.TxtClassSectionSubSection.AgRowFilter = ""
        Me.TxtClassSectionSubSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSectionSubSection.AgSelectedValue = Nothing
        Me.TxtClassSectionSubSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSectionSubSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSectionSubSection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClassSectionSubSection.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSectionSubSection.Location = New System.Drawing.Point(842, 14)
        Me.TxtClassSectionSubSection.MaxLength = 0
        Me.TxtClassSectionSubSection.Name = "TxtClassSectionSubSection"
        Me.TxtClassSectionSubSection.Size = New System.Drawing.Size(120, 18)
        Me.TxtClassSectionSubSection.TabIndex = 8
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(857, 143)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(110, 24)
        Me.BtnFillStudent.TabIndex = 14
        Me.BtnFillStudent.Text = "&Fill Student"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(10, 214)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(965, 241)
        Me.Pnl1.TabIndex = 824
        '
        'FrmLabWork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 526)
        Me.Controls.Add(Me.Pnl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmLabWork"
        Me.Text = "Lab Work Entry"
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
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
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.LabWork) & ""
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
        Public Shared AdmissionDocId As DataSet = Nothing
        Public Shared Student As DataSet = Nothing
        Public Shared Experiment As DataSet = Nothing
        Public Shared ClassSection As DataSet = Nothing
        Public Shared ClassSectionSubSection As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Sch_LabWork"
        AglObj = AgL

        LblV_Type.Text = "Lab Work Type"
        LblV_Date.Text = "Lab Work Date"
        LblV_No.Text = "Lab Work No."
        TP1.Text = "Tp1"
        AgL.GridDesign(DGL1)
        Tc1.SendToBack()
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
                " From Sch_LabWork H With (NoLock) " & _
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
                            " vSem.StreamYearSemesterDesc As [" & LblStreamYearSemester.Text & "], Cs.ClassSectionDesc [Class/Section], Ss.SubSection As [Sub-Section], " & _
                            " S.DisplayName As [" & LblSubject.Text & "], " & _
                            " H.SubjectManualCode As [" & LblSubjectManualCode.Text & "], " & _
                            " SgT.Name As [" & LblTeacher.Text & "], " & _
                            " SgH.Name As [" & LblHOD.Text & "], " & _
                            " Sm.Name AS [" & LblSite_Code.Text & "], " & _
                            " H.Remark " & _
                            " FROM dbo.Sch_LabWork H WITH (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code  " & _
                            " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = H.SessionProgramme " & _
                            " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = H.StreamYearSemester " & _
                            " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject  " & _
                            " LEFT JOIN ViewSch_ClassSection Cs ON H.ClassSection = Cs.Code  " & _
                            " LEFT JOIN Sch_ClassSectionSubSection SS On H.ClassSectionSubSection = Ss.Code " & _
                            " LEFT JOIN SubGroup SgT WITH (NoLock) ON SgT.SubCode = H.Teacher " & _
                            " LEFT JOIN Sch_AdmissionRollNo R WITH (NoLock) ON R.DocId = H.AdmissionDocId " & _
                            " LEFT JOIN SubGroup SgH WITH (NoLock) ON SgH.SubCode = H.HOD " & _
                            " LEFT JOIN SubGroup SgS WITH (NoLock) ON SgS.SubCode = H.Student " & mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc"

    End Sub
    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1RollNo, 80, 50, Col1RollNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Student, 140, 20, Col1Student, True, True, False)
            .AddAgTextColumn(DGL1, Col1AdmissionDocId, 160, 100, Col1AdmissionDocId, True, True, False)
            .AddAgTextColumn(DGL1, Col1StreamYearSemester, 180, 20, Col1StreamYearSemester, True, True, False)
            .AddAgTextColumn(DGL1, Col1Experiment, 100, 100, Col1Experiment, True, False, False)
            .AddAgButtonColumn(DGL1, Col1BtnNewExperiment, 30, " ", True, False, , , , "Webdings", 9, "6")
            .AddAgDateColumn(DGL1, Col1PerformedDate, 100, Col1PerformedDate, True, False, False)
            .AddAgDateColumn(DGL1, Col1SubmissionDate, 100, Col1SubmissionDate, True, False, False)
            .AddAgTextColumn(DGL1, Col1Session, 100, 20, Col1Session, False, True, False)
            .AddAgTextColumn(DGL1, Col1Program, 100, 20, Col1Program, False, True, False)
            .AddAgTextColumn(DGL1, Col1Stream, 100, 20, Col1Stream, False, True, False)
            .AddAgTextColumn(DGL1, Col1Semester, 100, 20, Col1Semester, False, True, False)
            .AddAgTextColumn(DGL1, Col1Year, 100, 20, Col1Year, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        DGL1.ColumnHeadersHeight = 40
        DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))
        DGL1.AllowUserToAddRows = False
        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0

        mQry = "UPDATE dbo.Sch_LabWork " & _
                " SET  " & _
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
                " Student = " & AgL.Chk_Text(TxtStudent.Text) & ", " & _
                " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                " Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                " HOD = " & AgL.Chk_Text(TxtHOD.AgSelectedValue) & ", " & _
                " Experiment = " & AgL.Chk_Text(TxtExperiment.Text) & ", " & _
                " SubmissionDate = " & AgL.Chk_Text(TxtSubmissionDate.Text) & ", " & _
                " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                " ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Sch_LabWork1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Student, bIntI).Value.ToString.Trim <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Sch_LabWork1 ( " & _
                        " DocId, Sr, Student, AdmissionDocId, Experiment, PerformedDate, SubmissionDate,StreamYearSemester,Session,Programme,Stream,Semester,Year) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Student, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1AdmissionDocId, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Experiment, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1PerformedDate, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1SubmissionDate, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1StreamYearSemester, bIntI)) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Session, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Program, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Stream, bIntI).Value) & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Semester, bIntI).Value) & " ," & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Year, bIntI).Value) & " " & _
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
        mQry = "Delete From Sch_LabWork1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Sch_LabWork Where DocId = '" & SearchCode & "' "
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
            " From Sch_LabWork H With (NoLock) " & _
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
                TxtSession.Text = AgL.XNull(.Rows(0)("Session"))
                TxtProgramme.Text = AgL.XNull(.Rows(0)("Programme"))
                TxtStream.Text = AgL.XNull(.Rows(0)("Stream"))
                TxtSemester.Text = AgL.XNull(.Rows(0)("Semester"))
                TxtYear.Text = AgL.VNull(.Rows(0)("Year"))
                TxtStudent.Text = AgL.XNull(.Rows(0)("Student"))
                '********* Rati **********************
                TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                TxtClassSectionSubSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSectionSubSection"))

                TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                DrTemp = TxtAdmissionDocId.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(AgL.XNull(.Rows(0)("AdmissionDocId"))) & "")
                If DrTemp.Length > 0 Then
                    TxtRollNo.Text = AgL.XNull(DrTemp(0)("RollNo"))
                End If




                TxtTeacher.AgSelectedValue = AgL.XNull(.Rows(0)("Teacher"))
                TxtHOD.AgSelectedValue = AgL.XNull(.Rows(0)("HOD"))
                TxtExperiment.AgSelectedValue = AgL.XNull(.Rows(0)("Experiment"))
                TxtSubmissionDate.Text = Format(AgL.XNull(.Rows(0)("SubmissionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                mQry = "Select L.* " & _
                      " From Sch_LabWork1 L With (NoLock) " & _
                      " Where L.DocId = '" & SearchCode & "' " & _
                      " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count

                            DGL1.AgSelectedValue(Col1Student, bIntI) = AgL.XNull(.Rows(bIntI)("Student"))
                            DGL1.AgSelectedValue(Col1AdmissionDocId, bIntI) = AgL.XNull(.Rows(bIntI)("AdmissionDocId"))
                            DrTemp = DGL1.AgHelpDataSet(Col1AdmissionDocId).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1AdmissionDocId, bIntI)) & "")
                            If DrTemp.Length > 0 Then
                                DGL1.Item(Col1RollNo, bIntI).Value = AgL.XNull(DrTemp(0)("RollNo"))
                            End If
                            DGL1.AgSelectedValue(Col1StreamYearSemester, bIntI) = AgL.XNull(.Rows(bIntI)("StreamYearSemester"))
                            DGL1.Item(Col1Session, bIntI).Value = AgL.XNull(.Rows(bIntI)("Session"))
                            DGL1.Item(Col1Program, bIntI).Value = AgL.XNull(.Rows(bIntI)("Programme"))
                            DGL1.Item(Col1Stream, bIntI).Value = AgL.XNull(.Rows(bIntI)("Stream"))
                            DGL1.Item(Col1Semester, bIntI).Value = AgL.XNull(.Rows(bIntI)("Semester"))
                            DGL1.Item(Col1Year, bIntI).Value = AgL.XNull(.Rows(bIntI)("Year"))
                            DGL1.Item(Col1Experiment, bIntI).Value = AgL.XNull(.Rows(bIntI)("Experiment"))
                            DGL1.Item(Col1PerformedDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("PerformedDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1SubmissionDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("SubmissionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

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
        AgL.WinSetting(Me, 570, 984, _FormLocation.Y, _FormLocation.X)
        IniGrid()
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
                    " CASE WHEN E.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END IsActive , Sg.LogInUser " & _
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

            mQry = "SELECT A.DocId AS Code, A.AdmissionID as Name, R.RollNo, Sg.ManualCode, " & _
                    " A.Student As StudentCode, A.CurrentSemester, A.Status, " & _
                    " CASE WHEN A.LeavingDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS IsActive " & _
                    " FROM ViewSch_Admission A WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionRollNo R  WITH (NoLock) ON R.DocId = A.DocId  " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON A.Student = Sg.SubCode  " & _
                    " ORDER BY Sg.Name"
            HelpDataSet.AdmissionDocId = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT A.Student As Code, Sg.Name, Sg.ManualCode, " & _
                " A.DocID as  AdmissionDocID, A.CurrentSemester, A.Status, " & _
                " CASE WHEN A.LeavingDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS IsActive " & _
                " FROM ViewSch_Admission A WITH (NoLock) " & _
                " LEFT JOIN SubGroup Sg WITH (NoLock) ON A.Student = Sg.SubCode  " & _
                " ORDER BY Sg.Name"
            HelpDataSet.Student = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.ClassSectionDesc " & _
                   " FROM ViewSch_ClassSection S " & _
                   " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                   " ORDER BY S.ClassSectionDesc "
            HelpDataSet.ClassSection = AgL.FillData(mQry, AgL.GcnRead)


            mQry = "SELECT S.Code , S.SubSection, S.ClassSection " & _
                    " FROM ViewSch_ClassSectionSubSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionSubSectionDesc"
            HelpDataSet.ClassSectionSubSection = AgL.FillData(mQry, AgL.GcnRead)


            Call IniDataSet_Experiment()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub IniDataSet_Experiment()
        Try
            mQry = "SELECT H.Code, H.Code AS Name FROM Sch_Experiment H With (NoLock) ORDER BY H.Code"
            HelpDataSet.Experiment = AgL.FillData(mQry, AgL.GcnRead)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub IniHelp_Experiment(Optional ByVal BlnMasterHelp As Boolean = False)
        Try
            DGL1.AgHelpDataSet(Col1Experiment, 0, , , , BlnMasterHelp) = HelpDataSet.Experiment.Copy
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSessionProgramme.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.SessionProgramme.Copy
        TxtStreamYearSemester.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.StreamYearSemester.Copy
        TxtTeacher.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Teacher.Copy
        TxtHOD.AgHelpDataSet(1, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Teacher.Copy
        TxtSubject.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Subject.Copy
        TxtAdmissionDocId.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.AdmissionDocId.Copy

        TxtClassSection.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.ClassSection.Copy
        TxtClassSectionSubSection.AgHelpDataSet(1, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.ClassSectionSubSection.Copy
        DGL1.AgHelpDataSet(Col1StreamYearSemester, 6) = HelpDataSet.StreamYearSemester.Copy

        DGL1.AgHelpDataSet(Col1RollNo, 6) = HelpDataSet.AdmissionDocId.Copy()
        DGL1.AgHelpDataSet(Col1Student, 5) = HelpDataSet.Student.Copy()
        DGL1.AgHelpDataSet(Col1AdmissionDocId, 6) = HelpDataSet.AdmissionDocId.Copy()

        Call IniHelp_Experiment()
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            'If AglObj.RequiredField(TxtSessionProgramme, LblSessionProgramme.Text) Then Exit Function
            'If AglObj.RequiredField(TxtStreamYearSemester, LblStreamYearSemester.Text) Then Exit Function
            If AglObj.RequiredField(TxtSubject, LblSubject.Text) Then Exit Function
            If AglObj.RequiredField(TxtSubjectManualCode, LblSubjectManualCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtTeacher, LblTeacher.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function
            'If AglObj.RequiredField(TxtExperiment, LblExperiment.Text) Then Exit Function
            'If AglObj.RequiredField(TxtAdmissionDocId, LblAdmissionDocId.Text) Then Exit Function

            If AgL.XNull(LblStreamYearSemester.Tag).ToString <> "" Then
                If Not AgL.StrCmp(LblStreamYearSemester.Tag, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Please Check Semester!...")
                    TxtStreamYearSemester.Focus() : Exit Function
                End If
            End If

            If Val(TxtYear.Text) > 0 Then TxtYear.Text = ""

            'If TxtSubmissionDate.Text.Trim <> "" Then
            '    If CDate(TxtSubmissionDate.Text) < CDate(TxtV_Date.Text) Then
            '        MsgBox("" & LblSubmissionDate.Text & " < " & LblV_Date.Text & "!...")
            '        TxtSubmissionDate.Focus() : Exit Function
            '    End If
            'End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1AdmissionDocId).Index) Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1AdmissionDocId, bIntI).Value Is Nothing Then DGL1.Item(Col1AdmissionDocId, bIntI).Value = ""

                If DGL1.Item(Col1AdmissionDocId, bIntI).Value <> "" Then
                    If DGL1.Item(Col1SubmissionDate, bIntI).Value <> "" Then
                        If CDate(DGL1.Item(Col1SubmissionDate, bIntI).Value) < CDate(DGL1.Item(Col1PerformedDate, bIntI).Value) Then
                            MsgBox("Submission Date < " & CDate(DGL1.Item(Col1PerformedDate, bIntI).Value) & " At Row No. " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                            DGL1.CurrentCell = DGL1(Col1SubmissionDate, bIntI) : DGL1.Focus() : Exit Function
                        End If
                    End If
                End If
            Next

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Sch_LabWork H With (NoLock) " & _
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
        mBlnIsApproved = False
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtDivision.Enter, TxtDocId.Enter, TxtReferenceNo.Enter, TxtSite_Code.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtRemark.Enter, TxtSessionProgramme.Enter, TxtStreamYearSemester.Enter, TxtSubject.Enter, TxtSubjectManualCode.Enter, TxtTeacher.Enter, TxtHOD.Enter, TxtAdmissionDocId.Enter, TxtExperiment.Enter, TxtSubmissionDate.Enter, TxtRollNo.Enter, TxtTeacher.Enter, TxtYear.Enter, TxtClassSection.Enter, TxtClassSectionSubSection.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                Case TxtAdmissionDocId.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And IsActive = 'Yes' "
                    bStrFilter += " And CurrentSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "

                    TxtAdmissionDocId.AgRowFilter = bStrFilter

                Case TxtTeacher.Name
                    bStrFilter = " 1=1 "

                    If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                        bStrFilter += " And LogInUser = '" & AgL.PubUserName & "' "
                    End If

                    TxtTeacher.AgRowFilter = bStrFilter & " and IsActive = 'Yes' "

                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtSubject.Name
                    TxtSubject.AgRowFilter = " SubjectType = '" & ClsMain.SubjectType.Practical & "' "

                Case TxtClassSectionSubSection.Name
                    TxtClassSectionSubSection.AgRowFilter = " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "

                Case TxtClassSection.Name
                    If TxtStreamYearSemester.Text.Trim <> "" Then
                        sender.AgRowFilter = " 1=2 "
                    Else
                        sender.AgRowFilter = ""
                    End If

                Case TxtSessionProgramme.Name
                    If TxtClassSection.Text.Trim <> "" Then
                        sender.AgRowFilter = " 1=2 "
                    Else
                        sender.AgRowFilter = ""
                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtSessionProgramme.Validating, TxtStreamYearSemester.Validating, TxtSubject.Validating, TxtSubjectManualCode.Validating, TxtTeacher.Validating, TxtHOD.Validating, TxtAdmissionDocId.Validating, TxtExperiment.Validating, TxtSubmissionDate.Validating, TxtRollNo.Validating, TxtTeacher.Validating, TxtYear.Validating

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

                Case TxtAdmissionDocId.Name
                    Call Validating_Controls(sender)

                Case TxtExperiment.Name
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
                        TxtClassSection.AgSelectedValue = ""
                        TxtClassSectionSubSection.AgSelectedValue = ""
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

            Case TxtAdmissionDocId.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtRollNo.Text = ""
                    TxtStudent.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        TxtRollNo.Text = AgL.XNull(DrTemp(0)("RollNo"))
                        TxtStudent.Text = AgL.XNull(DrTemp(0)("StudentCode"))
                    End If
                End If
                DrTemp = Nothing

            Case TxtClassSection.Name, TxtClassSectionSubSection.Name
                If TxtClassSection.Text.ToString.Trim <> "" Or TxtClassSectionSubSection.Text.ToString.Trim <> "" Then
                    TxtSessionProgramme.AgSelectedValue = ""
                    TxtStreamYearSemester.AgSelectedValue = ""
                End If

            Case TxtExperiment.Name
                If TxtExperiment.AgMasterHelp Then
                    If AgL.XNull(TxtExperiment.Text).ToString.Trim <> "" Then
                        DrTemp = TxtExperiment.AgHelpDataSet.Tables(0).Select("Name = " & AglObj.Chk_Text(TxtExperiment.Text) & "")
                        If DrTemp.Length > 0 Then
                            TxtExperiment.Tag = AgL.XNull(DrTemp(0)("Code"))
                        Else
                            TxtExperiment.Tag = ""
                            If MsgBox("Are You Sure To Create " & LblExperiment.Text & " : """ & TxtExperiment.Text & """?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
                                If mObjClsMain.FunCreateExperiment(TxtExperiment.Text, GcnRead) Then
                                    TxtExperiment.Tag = TxtExperiment.Text
                                    Call IniDataSet_Experiment() : Call IniHelp_Experiment()
                                End If
                                If GcnRead IsNot Nothing Then GcnRead.Dispose()
                            Else
                                TxtExperiment.AgSelectedValue = ""
                            End If
                        End If

                        If AgL.XNull(TxtExperiment.Tag).ToString.Trim <> "" Then
                            TxtExperiment.AgMasterHelp = False
                        End If
                    End If
                End If
        End Select
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
    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.
        If Topctrl1.Mode = "Edit" Then
            TxtTeacher.Enabled = False
        End If
        TxtRollNo.Enabled = False
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
        Dim strQry As String = "", RepName As String = "", RepTitle As String = "", strHeaderQry$ = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Summary of Lab Work".ToUpper
            RepName = "Academic_SummaryOfLabWork" : RepTitle = AgL.PubReportTitle

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strHeaderQry = "Select Header.* " & _
                            " From Sch_LabWork Header WITH (NoLock)  " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = Header.V_Type " & _
                            " Where 1=1 " & _
                            " And Vt.NCat in (" & EntryNCatList & ") " & _
                            " AND Header.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " " & _
                            " AND Header.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " " & _
                            " AND Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & " "

            strQry = "SELECT H.DocId, H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No,  L.PerformedDate as V_Date, H.ReferenceNo, " & AgL.V_No_Field("H.DocId") & " As VoucherNo, " & _
                        " H.Subject AS SubjectCode, S.DisplayName As SubjectDisplayName, H.SubjectManualCode,    " & _
                        " H.Teacher AS TeacherCode, SgT.Name As TeacherName, SgT.DispName As TeacherDispName, SgT.ManualCode As TeacherManualCode,     " & _
                        " H.HOD AS HodCode, SgH.Name As HodName, SgH.DispName As HodDispName, SgH.ManualCode As HodManualCode,     " & _
                        " L.Student AS StudentCode, SgS.Name As StudentName, SgS.DispName As StudentDispName, SgS.ManualCode As StudentManualCode,     " & _
                        " H.Remark AS Remark,  L.Experiment, L.SubmissionDate, R.RollNo, " & _
                        " H.PreparedBy, H.U_EntDt, H.Edit_Date, H.ModifiedBy, H.ApprovedBy, H.ApprovedDate,   " & _
                        " Sm.Name AS Site_Name, Sm.ManualCode AS SiteManualCode, Sm.Photo As SitePhoho,   " & _
                        " vSp.SessionProgramme As SessionProgrammeDesc, vSem.StreamYearSemesterDesc,  vSem.SessionManualCode, vSem.ProgrammeManualCode, vSem.StreamManualCode, vSem.SemesterSerialNo, vSem.SemesterDesc, H.Year   " & _
                        " FROM (" & strHeaderQry & ") As H " & _
                        " LEFT JOIN Sch_LabWork1  L WITH (NoLock) ON L.DocID = H.DocID " & _
                        " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code      " & _
                        " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = H.SessionProgramme   " & _
                        " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = H.StreamYearSemester   " & _
                        " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject      " & _
                        " LEFT JOIN SubGroup SgT WITH (NoLock) ON SgT.SubCode = H.Teacher     " & _
                        " LEFT JOIN SubGroup SgH WITH (NoLock) ON SgH.SubCode = H.Hod " & _
                        " LEFT JOIN SubGroup SgS WITH (NoLock) ON SgS.SubCode = L.Student " & _
                        " LEFT JOIN Sch_AdmissionRollNo R WITH (NoLock) ON R.DocId = L.AdmissionDocId " & _
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
    Private Sub BtnFillStudent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillStudent.Click
        Try
            Call ProcFillStudent()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillStudent()
        Dim DtTemp As DataTable
        Dim DrTemp As DataRow() = Nothing
        Dim I As Integer
        Dim mCondStr$ = "", bStrViewClassSectionSemesterAdmission$ = "", bStrViewOpenElectiveSemesterAdmission$ = "", bStrTempViewSectionAdmission$ = ""
        Dim bBlnIsOpenElectiveSection As Boolean = False
        Dim bCondQry$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub

            If TxtClassSection.Text.Trim <> "" Then
                bStrViewClassSectionSemesterAdmission = "SELECT vCsa3.* " & _
                                                  " FROM (SELECT vCsa1.* FROM ViewSch_ClassSectionSemesterAdmission vCsa1 " & _
                                                  " INNER JOIN " & _
                                                  " (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                  " FROM ViewSch_ClassSectionSemesterAdmission vCsa  " & _
                                                  " GROUP BY vCsa.ClassSection  " & _
                                                  " ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3 " & _
                                                  " WHERE vCsa3.SectionLeftOnDate IS NULL "

                bStrViewOpenElectiveSemesterAdmission = "SELECT vOCsa3.* " & _
                                                        " FROM (SELECT vOCsa1.* FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa1 " & _
                                                        " INNER JOIN " & _
                                                        " (SELECT vOCsa.ClassSection , Max(vOCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                        " FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa  " & _
                                                        " GROUP BY vOCsa.ClassSection  " & _
                                                        " ) vOCsa2 ON vOCsa1.ClassSection = vOCsa2.ClassSection AND vOCsa1.SemesterStartDate = vOCsa2.SemesterStartDate) vOCsa3 " & _
                                                        " WHERE vOCsa3.SectionLeftOnDate IS NULL "



                mQry = "SELECT S.IsOpenElectiveSection FROM Sch_ClassSection S WHERE S.Code = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & "  "
                bBlnIsOpenElectiveSection = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

                If bBlnIsOpenElectiveSection Then
                    bStrTempViewSectionAdmission = bStrViewOpenElectiveSemesterAdmission
                Else
                    bStrTempViewSectionAdmission = bStrViewClassSectionSemesterAdmission
                End If

                mCondStr = "   " & AgL.PubSiteCondition("Csa.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                       " Csa.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ""


                If TxtClassSectionSubSection.Text.Trim <> "" Then
                    mCondStr += " And Csa.ClassSectionSubSectionCode = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
                End If

            End If

            If TxtClassSection.Text.Trim <> "" Then
                mQry = "SELECT V1.DocId as AdmissionDocId, V1.AdmissionID, V1.StudentName As StudentName,V1.CurrentSemester,V1.Student " & _
                       " FROM ((" & bStrTempViewSectionAdmission & ") Csa " & _
                       " Inner Join (Select A.* From ViewSch_Admission A With (NoLock) ) V1 ON V1.DocId = Csa.AdmissionDocId)  " & _
                       " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                       " " & mCondStr & "  " & _
                       " And V1.LeavingDate IS NULL " & _
                       " Order By StudentName "
            Else
                If TxtStreamYearSemester.Text.Trim <> "" Then
                    mQry = "SELECT V1.DocId as AdmissionDocId, V1.AdmissionID, V1.StudentName As StudentName ,V1.CurrentSemester,V1.Student " & _
                           " FROM (SELECT A.* FROM ViewSch_Admission A WITH (NoLock) WHERE A.CurrentSemester =  " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ") AS V1  " & _
                           " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & "  " & _
                           " And V1.LeavingDate IS NULL " & _
                           " Order By StudentName "
                End If
            End If
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1Student, I) = AgL.XNull(.Rows(I)("Student"))
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DrTemp = DGL1.AgHelpDataSet(Col1AdmissionDocId).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1AdmissionDocId, I)) & "")
                        If DrTemp.Length > 0 Then
                            DGL1.Item(Col1RollNo, I).Value = AgL.XNull(DrTemp(0)("RollNo"))
                        End If
                        DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("CurrentSemester"))
                        DrTemp = DGL1.AgHelpDataSet(Col1StreamYearSemester).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1StreamYearSemester, I)) & "")
                        DGL1.Item(Col1Session, I).Value = AgL.XNull(DrTemp(0)("SessionCode"))
                        DGL1.Item(Col1Program, I).Value = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                        DGL1.Item(Col1Stream, I).Value = AgL.XNull(DrTemp(0)("StreamCode"))
                        DGL1.Item(Col1Semester, I).Value = AgL.XNull(DrTemp(0)("SemesterCode"))
                        DGL1.Item(Col1Year, I).Value = AgL.XNull(DrTemp(0)("YearSerial"))
                    Next I
                    DGL1.CurrentCell = DGL1(Col1Experiment, 0) : DGL1.Focus()
                Else

                    MsgBox("No Student Record Exists!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim DrTemp As DataRow() = Nothing

        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name

                Case Col1Experiment


                    If DGL1.Item(Col1Experiment, mRowIndex).Value.ToString.Trim <> "" Then
                        IniHelp_Experiment(True)
                        DrTemp = DGL1.AgHelpDataSet(Col1Experiment).Tables(0).Select("Name = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1Experiment, mRowIndex)) & "")
                        If DrTemp.Length > 0 Then
                            DGL1.AgSelectedValue(Col1Experiment, mRowIndex) = AgL.XNull(DrTemp(0)("Code"))
                        Else
                            If MsgBox("Are You Sure To Create " & DGL1.Item(Col1Experiment, mRowIndex).Value & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
                                If mObjClsMain.FunCreateExperiment(DGL1.Item(Col1Experiment, mRowIndex).Value, GcnRead) Then
                                    Call IniDataSet_Experiment() : Call IniHelp_Experiment()
                                    DGL1.AgSelectedValue(Col1Experiment, mRowIndex) = DGL1.Item(Col1Experiment, mRowIndex).Value
                                End If
                                If GcnRead IsNot Nothing Then GcnRead.Dispose()
                            Else
                                DGL1.AgSelectedValue(Col1Experiment, mRowIndex) = ""
                            End If
                        End If

                        If AgL.XNull(DGL1.AgSelectedValue(Col1Experiment, mRowIndex)).ToString.Trim <> "" Then
                            IniHelp_Experiment()
                        End If
                    End If


            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub Dgl1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        Dim FrmObj As Form = Nothing
        Dim bColumnIndex As Integer = 0
        Dim bRowIndex As Integer = 0
        Dim I As Integer = 0
        Try
            bColumnIndex = Dgl1.CurrentCell.ColumnIndex
            bRowIndex = Dgl1.CurrentCell.RowIndex

            Select Case Dgl1.Columns(e.ColumnIndex).Name
                Case Col1BtnNewExperiment
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        IniHelp_Experiment(True)
                        DGL1.CurrentCell = DGL1(Col1Experiment, DGL1.CurrentCell.RowIndex) : DGL1.Focus()
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub
End Class
