Public Class FrmPlacementEntry
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"


#Region "Form Designer Code"
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents TxtSession As AgControls.AgTextBox
    Protected WithEvents LblSession As System.Windows.Forms.Label
    Protected WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtCompany As AgControls.AgTextBox
    Protected WithEvents lblCompany As System.Windows.Forms.Label
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Protected WithEvents lblStreamYearSemester As System.Windows.Forms.Label
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Protected WithEvents lblStudent As System.Windows.Forms.Label
    Protected WithEvents TxtJoiningDate As AgControls.AgTextBox
    Protected WithEvents lblJoiningDate As System.Windows.Forms.Label
    Protected WithEvents TxtPackage As AgControls.AgTextBox
    Protected WithEvents lblPackage As System.Windows.Forms.Label
    Protected WithEvents lblDesignation As System.Windows.Forms.Label
    Protected WithEvents TxtDesignation As AgControls.AgTextBox
    Protected WithEvents TxtStudent As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCompany = New AgControls.AgTextBox
        Me.lblCompany = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.lblStudent = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.lblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtJoiningDate = New AgControls.AgTextBox
        Me.lblJoiningDate = New System.Windows.Forms.Label
        Me.TxtPackage = New AgControls.AgTextBox
        Me.lblPackage = New System.Windows.Forms.Label
        Me.lblDesignation = New System.Windows.Forms.Label
        Me.TxtDesignation = New AgControls.AgTextBox
        Me.TxtStudent = New AgControls.AgTextBox
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 399)
        Me.GroupBox1.Size = New System.Drawing.Size(992, 10)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(220, 410)
        '
        'TxtDivision
        '
        '
        'TxtDocId
        '
        Me.TxtDocId.Location = New System.Drawing.Point(638, 4)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(547, 64)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(642, 62)
        Me.TxtV_No.Size = New System.Drawing.Size(113, 18)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(367, 68)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(203, 64)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(794, 36)
        Me.LblV_TypeReq.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(386, 62)
        Me.TxtV_Date.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(719, 25)
        Me.LblV_Type.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(813, 30)
        Me.TxtV_Type.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(367, 49)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(203, 45)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(386, 43)
        Me.TxtSite_Code.Size = New System.Drawing.Size(370, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(607, 6)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(602, 63)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-4, 17)
        Me.Tc1.Size = New System.Drawing.Size(993, 381)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtStudent)
        Me.TP1.Controls.Add(Me.lblDesignation)
        Me.TP1.Controls.Add(Me.TxtDesignation)
        Me.TP1.Controls.Add(Me.TxtPackage)
        Me.TP1.Controls.Add(Me.lblPackage)
        Me.TP1.Controls.Add(Me.TxtJoiningDate)
        Me.TP1.Controls.Add(Me.lblJoiningDate)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.TxtStreamYearSemester)
        Me.TP1.Controls.Add(Me.lblStreamYearSemester)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtAdmissionDocId)
        Me.TP1.Controls.Add(Me.lblStudent)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.TxtCompany)
        Me.TP1.Controls.Add(Me.lblCompany)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.TxtSession)
        Me.TP1.Controls.Add(Me.LblSession)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Size = New System.Drawing.Size(985, 353)
        Me.TP1.Text = ""
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSession, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSession, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.lblCompany, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCompany, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblStudent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAdmissionDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStreamYearSemester, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label6, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblJoiningDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJoiningDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblPackage, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPackage, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDesignation, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblDesignation, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStudent, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(994, 42)
        Me.Topctrl1.TabIndex = 1
        '
        'GBoxApproved
        '
        Me.GBoxApproved.Location = New System.Drawing.Point(799, 414)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(12, 410)
        '
        'GBoxModified
        '
        Me.GBoxModified.Location = New System.Drawing.Point(424, 410)
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(367, 88)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(386, 82)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(149, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(203, 83)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'TxtSession
        '
        Me.TxtSession.AgAllowUserToEnableMasterHelp = False
        Me.TxtSession.AgMandatory = True
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
        Me.TxtSession.Location = New System.Drawing.Point(386, 102)
        Me.TxtSession.MaxLength = 20
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(370, 18)
        Me.TxtSession.TabIndex = 5
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(203, 104)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(53, 15)
        Me.LblSession.TabIndex = 1011
        Me.LblSession.Text = "Session"
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(367, 108)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 1017
        Me.LblSubCodeReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(367, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 1020
        Me.Label1.Text = "Ä"
        '
        'TxtCompany
        '
        Me.TxtCompany.AgAllowUserToEnableMasterHelp = False
        Me.TxtCompany.AgMandatory = True
        Me.TxtCompany.AgMasterHelp = False
        Me.TxtCompany.AgNumberLeftPlaces = 0
        Me.TxtCompany.AgNumberNegetiveAllow = False
        Me.TxtCompany.AgNumberRightPlaces = 0
        Me.TxtCompany.AgPickFromLastValue = False
        Me.TxtCompany.AgRowFilter = ""
        Me.TxtCompany.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCompany.AgSelectedValue = Nothing
        Me.TxtCompany.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCompany.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCompany.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompany.Location = New System.Drawing.Point(386, 122)
        Me.TxtCompany.MaxLength = 20
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.Size = New System.Drawing.Size(370, 18)
        Me.TxtCompany.TabIndex = 6
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(203, 124)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(60, 15)
        Me.lblCompany.TabIndex = 1019
        Me.lblCompany.Text = "Company"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(367, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 1023
        Me.Label4.Text = "Ä"
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
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(386, 142)
        Me.TxtAdmissionDocId.MaxLength = 20
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(370, 18)
        Me.TxtAdmissionDocId.TabIndex = 7
        '
        'lblStudent
        '
        Me.lblStudent.AutoSize = True
        Me.lblStudent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudent.Location = New System.Drawing.Point(203, 144)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Size = New System.Drawing.Size(49, 15)
        Me.lblStudent.TabIndex = 1022
        Me.lblStudent.Text = "Student"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(367, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 7)
        Me.Label6.TabIndex = 1026
        Me.Label6.Text = "Ä"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(386, 162)
        Me.TxtStreamYearSemester.MaxLength = 20
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(370, 18)
        Me.TxtStreamYearSemester.TabIndex = 8
        '
        'lblStreamYearSemester
        '
        Me.lblStreamYearSemester.AutoSize = True
        Me.lblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStreamYearSemester.Location = New System.Drawing.Point(203, 164)
        Me.lblStreamYearSemester.Name = "lblStreamYearSemester"
        Me.lblStreamYearSemester.Size = New System.Drawing.Size(125, 15)
        Me.lblStreamYearSemester.TabIndex = 1025
        Me.lblStreamYearSemester.Text = "Stream Year Semster"
        '
        'TxtJoiningDate
        '
        Me.TxtJoiningDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtJoiningDate.AgMandatory = False
        Me.TxtJoiningDate.AgMasterHelp = False
        Me.TxtJoiningDate.AgNumberLeftPlaces = 0
        Me.TxtJoiningDate.AgNumberNegetiveAllow = False
        Me.TxtJoiningDate.AgNumberRightPlaces = 0
        Me.TxtJoiningDate.AgPickFromLastValue = False
        Me.TxtJoiningDate.AgRowFilter = ""
        Me.TxtJoiningDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtJoiningDate.AgSelectedValue = Nothing
        Me.TxtJoiningDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtJoiningDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtJoiningDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtJoiningDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJoiningDate.Location = New System.Drawing.Point(386, 182)
        Me.TxtJoiningDate.MaxLength = 6
        Me.TxtJoiningDate.Name = "TxtJoiningDate"
        Me.TxtJoiningDate.Size = New System.Drawing.Size(149, 18)
        Me.TxtJoiningDate.TabIndex = 9
        '
        'lblJoiningDate
        '
        Me.lblJoiningDate.AutoSize = True
        Me.lblJoiningDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJoiningDate.Location = New System.Drawing.Point(203, 184)
        Me.lblJoiningDate.Name = "lblJoiningDate"
        Me.lblJoiningDate.Size = New System.Drawing.Size(76, 15)
        Me.lblJoiningDate.TabIndex = 1028
        Me.lblJoiningDate.Text = "Joining Date"
        '
        'TxtPackage
        '
        Me.TxtPackage.AgAllowUserToEnableMasterHelp = False
        Me.TxtPackage.AgMandatory = False
        Me.TxtPackage.AgMasterHelp = False
        Me.TxtPackage.AgNumberLeftPlaces = 0
        Me.TxtPackage.AgNumberNegetiveAllow = False
        Me.TxtPackage.AgNumberRightPlaces = 0
        Me.TxtPackage.AgPickFromLastValue = False
        Me.TxtPackage.AgRowFilter = ""
        Me.TxtPackage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPackage.AgSelectedValue = Nothing
        Me.TxtPackage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPackage.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPackage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPackage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPackage.Location = New System.Drawing.Point(642, 182)
        Me.TxtPackage.MaxLength = 15
        Me.TxtPackage.Name = "TxtPackage"
        Me.TxtPackage.Size = New System.Drawing.Size(114, 18)
        Me.TxtPackage.TabIndex = 10
        '
        'lblPackage
        '
        Me.lblPackage.AutoSize = True
        Me.lblPackage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackage.Location = New System.Drawing.Point(547, 184)
        Me.lblPackage.Name = "lblPackage"
        Me.lblPackage.Size = New System.Drawing.Size(55, 15)
        Me.lblPackage.TabIndex = 1030
        Me.lblPackage.Text = "Package"
        '
        'lblDesignation
        '
        Me.lblDesignation.AutoSize = True
        Me.lblDesignation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.Location = New System.Drawing.Point(203, 204)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(74, 15)
        Me.lblDesignation.TabIndex = 1032
        Me.lblDesignation.Text = "Designation"
        '
        'TxtDesignation
        '
        Me.TxtDesignation.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtDesignation.Location = New System.Drawing.Point(386, 202)
        Me.TxtDesignation.MaxLength = 50
        Me.TxtDesignation.Name = "TxtDesignation"
        Me.TxtDesignation.Size = New System.Drawing.Size(149, 18)
        Me.TxtDesignation.TabIndex = 11
        '
        'TxtStudent
        '
        Me.TxtStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtStudent.AgMandatory = True
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
        Me.TxtStudent.Location = New System.Drawing.Point(793, 9)
        Me.TxtStudent.MaxLength = 20
        Me.TxtStudent.Name = "TxtStudent"
        Me.TxtStudent.Size = New System.Drawing.Size(75, 18)
        Me.TxtStudent.TabIndex = 1033
        Me.TxtStudent.Visible = False
        '
        'FrmPlacementEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(994, 468)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmPlacementEntry"
        Me.Text = "Placement Entry"
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

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.CampusPlacement) & ""
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
        Public Shared Session As DataSet = Nothing
        Public Shared Company As DataSet = Nothing
        Public Shared AdmissionDocId As DataSet = Nothing
        Public Shared Student As DataSet = Nothing
        Public Shared StreamYearSemester As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Campus_Placement"
        AglObj = AgL

        LblV_Type.Text = "Entry Type"
        LblV_Date.Text = "Entry Date"
        LblV_No.Text = "Entry No."
        TP1.Text = "Tp1"

        Topctrl1.BringToFront()

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
                " From Campus_Placement H With (NoLock) " & _
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
                            " SS.ManualCode As [" & LblSession.Text & "], " & _
                            " C.Description As [" & lblCompany.Text & "], " & _
                            " SG.Name As [" & lblStudent.Text & "], " & _
                            " S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Campus_Placement H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & _
                            " Left Join Sch_Session SS With (NoLock) On H.Session = SS.Code " & _
                            " Left Join Campus_Company C With (NoLock) On H.Company = C.Code " & _
                            " Left Join Subgroup SG With (NoLock) On H.Student = SG.SubCode " & _
                            mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, [" & LblSession.Text & "] "

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0



        mQry = "UPDATE dbo.Campus_Placement " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                " Company = " & AgL.Chk_Text(TxtCompany.AgSelectedValue) & ", " & _
                " StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                " Student = " & AgL.Chk_Text(TxtStudent.Tag) & ", " & _
                " JoiningDate = " & AgL.ConvertDate(TxtJoiningDate.Text) & ", " & _
                " Package = " & AgL.VNull(TxtPackage.Text) & ", " & _
                " Desigantion = " & AgL.Chk_Text(TxtDesignation.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        mQry = "Delete From Campus_Placement Where DocId = '" & SearchCode & "' "
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
            " From Campus_Placement H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                TxtCompany.AgSelectedValue = AgL.XNull(.Rows(0)("Company"))
                TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                TxtStudent.Tag = AgL.XNull(.Rows(0)("Student"))
                TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                TxtJoiningDate.Text = Format(AgL.XNull(.Rows(0)("JoiningDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtPackage.Text = AgL.VNull(.Rows(0)("Package"))
                TxtDesignation.Text = AgL.XNull(.Rows(0)("Desigantion"))


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
        AgL.WinSetting(Me, 500, 1000, _FormLocation.Y, _FormLocation.X)

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

            mQry = "SELECT S.Code,S.Description as Name,C.CityName, S.ManualCode AS ManualCode,S.Phone,S.Mobile  " & _
                    " FROM Campus_Company S  With (NoLock) " & _
                    " Left Join City C With (NoLock) on S.CityCode=C.CityCode " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.ManualCode "
            HelpDataSet.Company = AgL.FillData(mQry, GcnRead)

            mQry = "SELECT S.Code, S.ManualCode AS Session " & _
                    " FROM Sch_Session S  With (NoLock) " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.ManualCode "
            HelpDataSet.Session = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT A.DocId AS Code, Sg.Name,A.Student As StudentCode, A.AdmissionID as Name," & _
                           "  Sg.ManualCode, A.CurrentSemester, A.Status, " & _
                           " CASE WHEN A.LeavingDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS IsActive " & _
                           " FROM ViewSch_Admission A WITH (NoLock) " & _
                           " LEFT JOIN SubGroup Sg WITH (NoLock) ON A.Student = Sg.SubCode  " & _
                           " ORDER BY Sg.Name"
            HelpDataSet.AdmissionDocId = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.StreamYearSemesterDesc AS Semester, S.SessionProgrammeCode, " & _
                    " S.StreamCode, S.ProgrammeCode, S.SessionCode, S.Semester As SemesterCode, S.YearSerial " & _
                    " FROM ViewSch_StreamYearSemester S WITH (NoLock) " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.StreamYearSemesterDesc "
            HelpDataSet.StreamYearSemester = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSession.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Session.Copy
        TxtStreamYearSemester.AgHelpDataSet(6, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.StreamYearSemester.Copy
        TxtCompany.AgHelpDataSet(3, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Company.Copy
        TxtAdmissionDocId.AgHelpDataSet(5, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.AdmissionDocId.Copy


        'DGL1.AgHelpDataSet(Col1Company, 3) = HelpDataSet.Company.Copy

    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        'Dim bIntI As Integer, bIntTotalDays As Integer = 0

        'For bIntI = 0 To DGL1.RowCount - 1
        '    If DGL1.Item(Col1Company, bIntI).Value Is Nothing Then DGL1.Item(Col1Company, bIntI).Value = ""

        'Next
    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtSession, LblSession.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function
            If AglObj.RequiredField(TxtAdmissionDocId, lblStudent.Text) Then Exit Function

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Campus_Placement H With (NoLock) " & _
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

        'DGL1.RowCount = 1 : DGL1.Rows.Clear()
        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtSession.Enter
        Try
            Select Case sender.name
                'Case TxtSession.Name
                '    TxtSession.AgRowFilter = " [Is Active] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtSession.Validating, TxtCompany.Validating, TxtAdmissionDocId.Validating, TxtDesignation.Validating, TxtJoiningDate.Validating, TxtPackage.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()

                Case TxtAdmissionDocId.Name
                    DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                    TxtStudent.Tag = AgL.XNull(DrTemp(0)("StudentCode"))

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
            'Case TxtSession.Name

            '    DrTemp = Nothing
        End Select

    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.
        If Enb Then
            '<Executable Code>
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
End Class
