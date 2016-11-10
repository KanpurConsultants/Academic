Imports System.Data.SqlClient

Public Class TempTutorialAssignment
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1Question As String = "Question"

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Protected Const Col2Reference As String = "Reference"

    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Protected Const Col3Description As String = "Document"
    Protected Const Col3BtnAttachment As String = ""
    Protected Const Col3ByteArray As String = "Byte Array"
    Protected Const Col3FileName As String = "File Name"


    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"


#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox

    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel


    Protected WithEvents LblTitle1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblValTotalQuestion As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalQuestion As System.Windows.Forms.Label
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents LblTitle2 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlFooter2 As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalReference As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalReference As System.Windows.Forms.Label
    Friend WithEvents TxtTeacher As AgControls.AgTextBox
    Friend WithEvents LblTeacherReq As System.Windows.Forms.Label
    Friend WithEvents LblTeacher As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtTopic As AgControls.AgTextBox
    Friend WithEvents LblTopic As System.Windows.Forms.Label
    Friend WithEvents TxtGroup As AgControls.AgTextBox
    Friend WithEvents LblGroup As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectManualCode As AgControls.AgTextBox
    Friend WithEvents LblSubjectManualCodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSubjectManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeReq As System.Windows.Forms.Label
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents TxtCompletionDate As AgControls.AgTextBox
    Friend WithEvents LblCompletionDate As System.Windows.Forms.Label
    Friend WithEvents TxtUnit As AgControls.AgTextBox
    Friend WithEvents LblUnit As System.Windows.Forms.Label
    Protected WithEvents Pnl3 As System.Windows.Forms.Panel
    Protected WithEvents LblTitle3 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlFooter3 As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalDocuments As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalDocuments As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalQuestion = New System.Windows.Forms.Label
        Me.LblTextTotalQuestion = New System.Windows.Forms.Label
        Me.LblTitle1 = New System.Windows.Forms.LinkLabel
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.LblTitle2 = New System.Windows.Forms.LinkLabel
        Me.PnlFooter2 = New System.Windows.Forms.Panel
        Me.LblValTotalReference = New System.Windows.Forms.Label
        Me.LblTextTotalReference = New System.Windows.Forms.Label
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
        Me.TxtGroup = New AgControls.AgTextBox
        Me.LblGroup = New System.Windows.Forms.Label
        Me.TxtTopic = New AgControls.AgTextBox
        Me.LblTopic = New System.Windows.Forms.Label
        Me.TxtCompletionDate = New AgControls.AgTextBox
        Me.LblCompletionDate = New System.Windows.Forms.Label
        Me.TxtUnit = New AgControls.AgTextBox
        Me.LblUnit = New System.Windows.Forms.Label
        Me.Pnl3 = New System.Windows.Forms.Panel
        Me.LblTitle3 = New System.Windows.Forms.LinkLabel
        Me.PnlFooter3 = New System.Windows.Forms.Panel
        Me.LblValTotalDocuments = New System.Windows.Forms.Label
        Me.LblTextTotalDocuments = New System.Windows.Forms.Label
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        Me.PnlFooter2.SuspendLayout()
        Me.PnlFooter3.SuspendLayout()
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
        Me.Tc1.Size = New System.Drawing.Size(992, 161)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtUnit)
        Me.TP1.Controls.Add(Me.LblUnit)
        Me.TP1.Controls.Add(Me.TxtCompletionDate)
        Me.TP1.Controls.Add(Me.LblCompletionDate)
        Me.TP1.Controls.Add(Me.TxtTopic)
        Me.TP1.Controls.Add(Me.LblTopic)
        Me.TP1.Controls.Add(Me.TxtGroup)
        Me.TP1.Controls.Add(Me.LblGroup)
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
        Me.TP1.Size = New System.Drawing.Size(984, 133)
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
        Me.TP1.Controls.SetChildIndex(Me.LblGroup, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGroup, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTopic, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTopic, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCompletionDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCompletionDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblUnit, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtUnit, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
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
        Me.TxtRemark.TabIndex = 14
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
        Me.Pnl1.Location = New System.Drawing.Point(12, 207)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(556, 315)
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
        Me.PnlFooter.Controls.Add(Me.LblValTotalQuestion)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalQuestion)
        Me.PnlFooter.Location = New System.Drawing.Point(12, 521)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(556, 24)
        Me.PnlFooter.TabIndex = 695
        '
        'LblValTotalQuestion
        '
        Me.LblValTotalQuestion.AutoSize = True
        Me.LblValTotalQuestion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQuestion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQuestion.Location = New System.Drawing.Point(496, 4)
        Me.LblValTotalQuestion.Name = "LblValTotalQuestion"
        Me.LblValTotalQuestion.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQuestion.TabIndex = 680
        Me.LblValTotalQuestion.Text = "."
        Me.LblValTotalQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalQuestion
        '
        Me.LblTextTotalQuestion.AutoSize = True
        Me.LblTextTotalQuestion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalQuestion.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalQuestion.Location = New System.Drawing.Point(379, 4)
        Me.LblTextTotalQuestion.Name = "LblTextTotalQuestion"
        Me.LblTextTotalQuestion.Size = New System.Drawing.Size(118, 16)
        Me.LblTextTotalQuestion.TabIndex = 679
        Me.LblTextTotalQuestion.Text = "Total Questions  :"
        '
        'LblTitle1
        '
        Me.LblTitle1.BackColor = System.Drawing.Color.SteelBlue
        Me.LblTitle1.DisabledLinkColor = System.Drawing.Color.White
        Me.LblTitle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblTitle1.LinkColor = System.Drawing.Color.White
        Me.LblTitle1.Location = New System.Drawing.Point(11, 184)
        Me.LblTitle1.Name = "LblTitle1"
        Me.LblTitle1.Size = New System.Drawing.Size(101, 20)
        Me.LblTitle1.TabIndex = 739
        Me.LblTitle1.TabStop = True
        Me.LblTitle1.Text = "QUESTION LIST"
        Me.LblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(586, 399)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(391, 125)
        Me.Pnl2.TabIndex = 2
        '
        'LblTitle2
        '
        Me.LblTitle2.BackColor = System.Drawing.Color.SteelBlue
        Me.LblTitle2.DisabledLinkColor = System.Drawing.Color.White
        Me.LblTitle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblTitle2.LinkColor = System.Drawing.Color.White
        Me.LblTitle2.Location = New System.Drawing.Point(583, 373)
        Me.LblTitle2.Name = "LblTitle2"
        Me.LblTitle2.Size = New System.Drawing.Size(83, 20)
        Me.LblTitle2.TabIndex = 741
        Me.LblTitle2.TabStop = True
        Me.LblTitle2.Text = "REFERENCES:"
        Me.LblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlFooter2
        '
        Me.PnlFooter2.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter2.Controls.Add(Me.LblValTotalReference)
        Me.PnlFooter2.Controls.Add(Me.LblTextTotalReference)
        Me.PnlFooter2.Location = New System.Drawing.Point(586, 521)
        Me.PnlFooter2.Name = "PnlFooter2"
        Me.PnlFooter2.Size = New System.Drawing.Size(391, 24)
        Me.PnlFooter2.TabIndex = 696
        '
        'LblValTotalReference
        '
        Me.LblValTotalReference.AutoSize = True
        Me.LblValTotalReference.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalReference.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalReference.Location = New System.Drawing.Point(334, 4)
        Me.LblValTotalReference.Name = "LblValTotalReference"
        Me.LblValTotalReference.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalReference.TabIndex = 680
        Me.LblValTotalReference.Text = "."
        Me.LblValTotalReference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalReference
        '
        Me.LblTextTotalReference.AutoSize = True
        Me.LblTextTotalReference.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalReference.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalReference.Location = New System.Drawing.Point(208, 4)
        Me.LblTextTotalReference.Name = "LblTextTotalReference"
        Me.LblTextTotalReference.Size = New System.Drawing.Size(123, 16)
        Me.LblTextTotalReference.TabIndex = 679
        Me.LblTextTotalReference.Text = "Total References :"
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
        Me.TxtTeacher.Location = New System.Drawing.Point(626, 68)
        Me.TxtTeacher.MaxLength = 0
        Me.TxtTeacher.Name = "TxtTeacher"
        Me.TxtTeacher.Size = New System.Drawing.Size(350, 18)
        Me.TxtTeacher.TabIndex = 13
        '
        'LblTeacherReq
        '
        Me.LblTeacherReq.AutoSize = True
        Me.LblTeacherReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTeacherReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTeacherReq.Location = New System.Drawing.Point(611, 74)
        Me.LblTeacherReq.Name = "LblTeacherReq"
        Me.LblTeacherReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTeacherReq.TabIndex = 781
        Me.LblTeacherReq.Text = "Ä"
        '
        'LblTeacher
        '
        Me.LblTeacher.AutoSize = True
        Me.LblTeacher.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTeacher.Location = New System.Drawing.Point(523, 70)
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(143, 108)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(350, 18)
        Me.TxtStreamYearSemester.TabIndex = 8
        '
        'LblStreamYearSemesterReq
        '
        Me.LblStreamYearSemesterReq.AutoSize = True
        Me.LblStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStreamYearSemesterReq.Location = New System.Drawing.Point(128, 113)
        Me.LblStreamYearSemesterReq.Name = "LblStreamYearSemesterReq"
        Me.LblStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStreamYearSemesterReq.TabIndex = 784
        Me.LblStreamYearSemesterReq.Text = "Ä"
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(14, 110)
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
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(143, 88)
        Me.TxtSessionProgramme.MaxLength = 0
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(120, 18)
        Me.TxtSessionProgramme.TabIndex = 6
        '
        'LblSessionProgrammeReq
        '
        Me.LblSessionProgrammeReq.AutoSize = True
        Me.LblSessionProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeReq.Location = New System.Drawing.Point(128, 94)
        Me.LblSessionProgrammeReq.Name = "LblSessionProgrammeReq"
        Me.LblSessionProgrammeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeReq.TabIndex = 787
        Me.LblSessionProgrammeReq.Text = "Ä"
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(14, 90)
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
        Me.TxtSubject.TabIndex = 9
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
        Me.TxtSubjectManualCode.TabIndex = 10
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
        Me.LblSubjectManualCode.Size = New System.Drawing.Size(84, 15)
        Me.LblSubjectManualCode.TabIndex = 792
        Me.LblSubjectManualCode.Text = "Subject lCode"
        '
        'TxtGroup
        '
        Me.TxtGroup.AgMandatory = False
        Me.TxtGroup.AgMasterHelp = False
        Me.TxtGroup.AgNumberLeftPlaces = 0
        Me.TxtGroup.AgNumberNegetiveAllow = False
        Me.TxtGroup.AgNumberRightPlaces = 0
        Me.TxtGroup.AgPickFromLastValue = False
        Me.TxtGroup.AgRowFilter = ""
        Me.TxtGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGroup.AgSelectedValue = Nothing
        Me.TxtGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGroup.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGroup.Location = New System.Drawing.Point(373, 88)
        Me.TxtGroup.MaxLength = 0
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.Size = New System.Drawing.Size(120, 18)
        Me.TxtGroup.TabIndex = 7
        '
        'LblGroup
        '
        Me.LblGroup.AutoSize = True
        Me.LblGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGroup.Location = New System.Drawing.Point(270, 90)
        Me.LblGroup.Name = "LblGroup"
        Me.LblGroup.Size = New System.Drawing.Size(41, 15)
        Me.LblGroup.TabIndex = 795
        Me.LblGroup.Text = "Group"
        '
        'TxtTopic
        '
        Me.TxtTopic.AgMandatory = False
        Me.TxtTopic.AgMasterHelp = False
        Me.TxtTopic.AgNumberLeftPlaces = 0
        Me.TxtTopic.AgNumberNegetiveAllow = False
        Me.TxtTopic.AgNumberRightPlaces = 0
        Me.TxtTopic.AgPickFromLastValue = False
        Me.TxtTopic.AgRowFilter = ""
        Me.TxtTopic.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTopic.AgSelectedValue = Nothing
        Me.TxtTopic.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTopic.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTopic.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTopic.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTopic.Location = New System.Drawing.Point(626, 48)
        Me.TxtTopic.MaxLength = 100
        Me.TxtTopic.Name = "TxtTopic"
        Me.TxtTopic.Size = New System.Drawing.Size(350, 18)
        Me.TxtTopic.TabIndex = 12
        '
        'LblTopic
        '
        Me.LblTopic.AutoSize = True
        Me.LblTopic.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTopic.Location = New System.Drawing.Point(523, 50)
        Me.LblTopic.Name = "LblTopic"
        Me.LblTopic.Size = New System.Drawing.Size(37, 15)
        Me.LblTopic.TabIndex = 797
        Me.LblTopic.Text = "Topic"
        '
        'TxtCompletionDate
        '
        Me.TxtCompletionDate.AgMandatory = False
        Me.TxtCompletionDate.AgMasterHelp = False
        Me.TxtCompletionDate.AgNumberLeftPlaces = 0
        Me.TxtCompletionDate.AgNumberNegetiveAllow = False
        Me.TxtCompletionDate.AgNumberRightPlaces = 0
        Me.TxtCompletionDate.AgPickFromLastValue = False
        Me.TxtCompletionDate.AgRowFilter = ""
        Me.TxtCompletionDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCompletionDate.AgSelectedValue = Nothing
        Me.TxtCompletionDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCompletionDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtCompletionDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCompletionDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompletionDate.Location = New System.Drawing.Point(373, 68)
        Me.TxtCompletionDate.MaxLength = 0
        Me.TxtCompletionDate.Name = "TxtCompletionDate"
        Me.TxtCompletionDate.Size = New System.Drawing.Size(120, 18)
        Me.TxtCompletionDate.TabIndex = 5
        '
        'LblCompletionDate
        '
        Me.LblCompletionDate.AutoSize = True
        Me.LblCompletionDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompletionDate.Location = New System.Drawing.Point(270, 70)
        Me.LblCompletionDate.Name = "LblCompletionDate"
        Me.LblCompletionDate.Size = New System.Drawing.Size(89, 15)
        Me.LblCompletionDate.TabIndex = 800
        Me.LblCompletionDate.Text = "Completion Dt."
        '
        'TxtUnit
        '
        Me.TxtUnit.AgMandatory = False
        Me.TxtUnit.AgMasterHelp = False
        Me.TxtUnit.AgNumberLeftPlaces = 0
        Me.TxtUnit.AgNumberNegetiveAllow = False
        Me.TxtUnit.AgNumberRightPlaces = 0
        Me.TxtUnit.AgPickFromLastValue = False
        Me.TxtUnit.AgRowFilter = ""
        Me.TxtUnit.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUnit.AgSelectedValue = Nothing
        Me.TxtUnit.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUnit.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUnit.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnit.Location = New System.Drawing.Point(856, 28)
        Me.TxtUnit.MaxLength = 20
        Me.TxtUnit.Name = "TxtUnit"
        Me.TxtUnit.Size = New System.Drawing.Size(120, 18)
        Me.TxtUnit.TabIndex = 11
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnit.Location = New System.Drawing.Point(800, 30)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(29, 15)
        Me.LblUnit.TabIndex = 802
        Me.LblUnit.Text = "Unit"
        '
        'Pnl3
        '
        Me.Pnl3.Location = New System.Drawing.Point(586, 207)
        Me.Pnl3.Name = "Pnl3"
        Me.Pnl3.Size = New System.Drawing.Size(391, 139)
        Me.Pnl3.TabIndex = 742
        '
        'LblTitle3
        '
        Me.LblTitle3.BackColor = System.Drawing.Color.SteelBlue
        Me.LblTitle3.DisabledLinkColor = System.Drawing.Color.White
        Me.LblTitle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblTitle3.LinkColor = System.Drawing.Color.White
        Me.LblTitle3.Location = New System.Drawing.Point(583, 184)
        Me.LblTitle3.Name = "LblTitle3"
        Me.LblTitle3.Size = New System.Drawing.Size(83, 20)
        Me.LblTitle3.TabIndex = 743
        Me.LblTitle3.TabStop = True
        Me.LblTitle3.Text = "DOCUMENTS:"
        Me.LblTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlFooter3
        '
        Me.PnlFooter3.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter3.Controls.Add(Me.LblValTotalDocuments)
        Me.PnlFooter3.Controls.Add(Me.LblTextTotalDocuments)
        Me.PnlFooter3.Location = New System.Drawing.Point(586, 345)
        Me.PnlFooter3.Name = "PnlFooter3"
        Me.PnlFooter3.Size = New System.Drawing.Size(391, 24)
        Me.PnlFooter3.TabIndex = 697
        '
        'LblValTotalDocuments
        '
        Me.LblValTotalDocuments.AutoSize = True
        Me.LblValTotalDocuments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalDocuments.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalDocuments.Location = New System.Drawing.Point(334, 4)
        Me.LblValTotalDocuments.Name = "LblValTotalDocuments"
        Me.LblValTotalDocuments.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalDocuments.TabIndex = 680
        Me.LblValTotalDocuments.Text = "."
        Me.LblValTotalDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalDocuments
        '
        Me.LblTextTotalDocuments.AutoSize = True
        Me.LblTextTotalDocuments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalDocuments.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalDocuments.Location = New System.Drawing.Point(208, 4)
        Me.LblTextTotalDocuments.Name = "LblTextTotalDocuments"
        Me.LblTextTotalDocuments.Size = New System.Drawing.Size(122, 16)
        Me.LblTextTotalDocuments.TabIndex = 679
        Me.LblTextTotalDocuments.Text = "Total Documents :"
        '
        'FrmTutorialSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.PnlFooter3)
        Me.Controls.Add(Me.Pnl3)
        Me.Controls.Add(Me.LblTitle3)
        Me.Controls.Add(Me.PnlFooter2)
        Me.Controls.Add(Me.Pnl2)
        Me.Controls.Add(Me.LblTitle2)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblTitle1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmTutorialSheet"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.LblTitle1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.LblTitle2, 0)
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter2, 0)
        Me.Controls.SetChildIndex(Me.LblTitle3, 0)
        Me.Controls.SetChildIndex(Me.Pnl3, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter3, 0)
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
        Me.PnlFooter2.ResumeLayout(False)
        Me.PnlFooter2.PerformLayout()
        Me.PnlFooter3.ResumeLayout(False)
        Me.PnlFooter3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.        
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

    Private Sub FrmTutorialSheet_BaseEvent_Delete_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Delete_PostTrans
        If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
            mQry = "Delete From TutorialAssignment_BLOB " & _
                    " Where Docid = " & AgL.Chk_Text(SearchCode) & " "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
        End If
    End Sub

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Sch_TutorialAssignment"
        AglObj = AgL

        TP1.Text = "Tp1"

        AgL.GridDesign(DGL1)
        AgL.GridDesign(DGL2)
        AgL.GridDesign(DGL3)
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
                " From Sch_TutorialAssignment H With (NoLock) " & _
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
                            " " & AgL.ConvertDateField("H.CompletionDate") & " As [" & LblCompletionDate.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " vSp.SessionProgramme As [" & LblSessionProgramme.Text & "], " & _
                            " vSem.StreamYearSemesterDesc As [" & LblStreamYearSemester.Text & "], " & _
                            " S.DisplayName As [" & LblSubject.Text & "], " & _
                            " H.SubjectManualCode As [" & LblSubjectManualCode.Text & "], " & _
                            " H.Unit As [" & LblUnit.Text & "], " & _
                            " H.Topic As [" & LblTopic.Text & "], " & _
                            " Sg.Name As [" & LblTeacher.Text & "], " & _
                            " H.TotalQuestion As [" & LblTextTotalQuestion.Text & "], " & _
                            " H.TotalReference As [" & LblTextTotalReference.Text & "], " & _
                            " Sm.Name AS [" & LblSite_Code.Text & "], " & _
                            " H.Remark " & _
                            " FROM dbo.Sch_TutorialAssignment H WITH (NoLock) " & _
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
            .AddAgTextColumn(DGL1, Col1Question, 500, 0, Col1Question, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        DGL1.Columns(Col1Question).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))


        DGL2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL2, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL2, Col2Reference, 330, 0, Col2Reference, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.EnableHeadersVisualStyles = False
        DGL2.AgSkipReadOnlyColumns = True
        DGL2.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL2.Anchor
        DGL2.ColumnHeadersHeight = 40
        DGL2.Columns(Col2Reference).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DGL2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Topctrl1.ChangeAgGridState(DGL2, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))


        ''==============================================================================
        ''================< Document Data Grid >=============================================
        ''==============================================================================
        DGL3.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL3, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL3, Col3Description, 190, 255, Col3Description, True, False, False)
            .AddAgButtonColumn(DGL3, Col3BtnAttachment, 40, Col3BtnAttachment, True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(DGL3, Col3FileName, 100, 255, Col3FileName, True, True, False)
            .AddAgImageColumn(DGL3, Col3ByteArray, 100, Col3ByteArray, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)
        DGL3.EnableHeadersVisualStyles = False
        DGL3.AgSkipReadOnlyColumns = True
        DGL3.Anchor = AnchorStyles.None
        DGL3.AgSkipReadOnlyColumns = True
        DGL3.ColumnHeadersHeight = 40
        Topctrl1.ChangeAgGridState(DGL3, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0

        mQry = "UPDATE dbo.Sch_TutorialAssignment " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                " StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                " Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                " SubjectManualCode = " & AgL.Chk_Text(TxtSubjectManualCode.Text) & ", " & _
                " Unit = " & AgL.Chk_Text(TxtUnit.Text) & ", " & _
                " Topic = " & AgL.Chk_Text(TxtTopic.Text) & ", " & _
                " Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                " CompletionDate = " & AgL.Chk_Text(TxtCompletionDate.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                " TotalQuestion = " & Val(LblValTotalQuestion.Text) & ", " & _
                " TotalReference = " & Val(LblValTotalReference.Text) & ", " & _
                " TotalDocuments = " & Val(LblValTotalDocuments.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Sch_TutorialAssignment1 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Question, bIntI).Value.ToString.Trim <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Sch_TutorialAssignment1 ( " & _
                        " DocId, Sr, Question) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL1.Item(Col1Question, bIntI).Value) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Sch_TutorialAssignment2 WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bIntSr = 0
        For bIntI = 0 To DGL2.RowCount - 1
            If DGL2.Item(Col2Reference, bIntI).Value.ToString.Trim <> "" Then
                bIntSr += 1

                mQry = "INSERT INTO dbo.Sch_TutorialAssignment2 ( " & _
                        " DocId, Sr, Reference) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                        " " & AgL.Chk_Text(DGL2.Item(Col2Reference, bIntI).Value) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        mQry = "Delete From Sch_TutorialAssignment2 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Sch_TutorialAssignment1 Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Sch_TutorialAssignment Where DocId = '" & SearchCode & "' "
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
            " From Sch_TutorialAssignment H With (NoLock) " & _
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
                TxtUnit.Text = AgL.XNull(.Rows(0)("Unit"))
                TxtTopic.Text = AgL.XNull(.Rows(0)("Topic"))
                TxtTeacher.AgSelectedValue = AgL.XNull(.Rows(0)("Teacher"))
                TxtCompletionDate.Text = Format(AgL.XNull(.Rows(0)("CompletionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                LblValTotalQuestion.Text = AgL.VNull(.Rows(0)("TotalQuestion"))
                LblValTotalReference.Text = AgL.VNull(.Rows(0)("TotalReference"))
                LblValTotalDocuments.Text = AgL.VNull(.Rows(0)("TotalDocuments"))


                mQry = "Select L.* " & _
                        " From Sch_TutorialAssignment1 L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.Item(Col1Question, bIntI).Value = AgL.XNull(.Rows(bIntI)("Question"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)

                        Next bIntI
                    End If
                End With

                mQry = "Select L2.* " & _
                        " From Sch_TutorialAssignment2 L2 With (NoLock) " & _
                        " Where L2.DocId = '" & SearchCode & "' " & _
                        " Order By L2.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(ColSNo, bIntI).Value = DGL2.Rows.Count - 1

                            DGL2.Item(Col2Reference, bIntI).Value = AgL.XNull(.Rows(bIntI)("Reference"))
                        Next bIntI
                    End If
                End With


                If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                    mQry = "SELECT B.* " & _
                            " FROM TutorialAssignment_BLOB B With (NoLock) " & _
                            " WHERE B.DocId = " & AgL.Chk_Text(SearchCode) & " " & _
                            " Order By B.Sr "
                    DsTemp = AgL.FillData(mQry, AgL.GcnImage)
                    With DsTemp.Tables(0)
                        DGL3.RowCount = 1 : DGL3.Rows.Clear()
                        If .Rows.Count > 0 Then
                            For bIntI = 0 To DsTemp.Tables(0).Rows.Count - 1
                                DGL3.Rows.Add()
                                DGL3.Item(ColSNo, bIntI).Value = DGL3.Rows.Count - 1
                                DGL3.Item(Col3Description, bIntI).Value = AgL.XNull(.Rows(bIntI)("Description"))
                                If Not IsDBNull(.Rows(bIntI)("BLOB")) Then
                                    DGL3.Item(Col3ByteArray, bIntI).Value = .Rows(bIntI)("BLOB")
                                    DGL3.Item(Col3FileName, bIntI).Value = AgL.XNull(.Rows(bIntI)("FileName"))
                                End If
                            Next bIntI
                        End If
                    End With
                End If


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
                    " CASE WHEN E.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END IsActive, Sg.LogInUser " & _
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

            mQry = "SELECT S.Code, S.StreamYearSemesterDesc AS Semester, S.SessionProgrammeCode " & _
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
        TxtStreamYearSemester.AgHelpDataSet(1, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.StreamYearSemester.Copy
        TxtTeacher.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Teacher.Copy
        TxtSubject.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Subject.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer = 0
        Dim ByteArr As Byte() = Nothing

        LblValTotalQuestion.Text = 0
        LblValTotalReference.Text = 0
        LblValTotalDocuments.Text = 0

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Question, bIntI).Value Is Nothing Then DGL1.Item(Col1Question, bIntI).Value = ""

            If DGL1.Item(Col1Question, bIntI).Value <> "" Then
                'Footer Calculation

                LblValTotalQuestion.Text = Val(LblValTotalQuestion.Text) + 1
            End If
        Next

        For bIntI = 0 To DGL2.RowCount - 1
            If DGL2.Item(Col2Reference, bIntI).Value Is Nothing Then DGL2.Item(Col2Reference, bIntI).Value = ""

            If DGL2.Item(Col2Reference, bIntI).Value <> "" Then
                'Footer Calculation

                LblValTotalReference.Text = Val(LblValTotalReference.Text) + 1
            End If
        Next

        For bIntI = 0 To DGL3.RowCount - 1
            If DGL3.Item(Col3Description, bIntI).Value Is Nothing Then DGL3.Item(Col3Description, bIntI).Value = ""
            If DGL3.Item(Col3FileName, bIntI).Value Is Nothing Then DGL3.Item(Col3FileName, bIntI).Value = ""

            Try
                ByteArr = DGL3.Item(Col3ByteArray, bIntI).Value
            Catch ex As Exception

            End Try

            If AgL.XNull(DGL3.Item(Col3Description, bIntI).Value).ToString.Trim <> "" _
                And AgL.XNull(DGL3.Item(Col3FileName, bIntI).Value).ToString.Trim <> "" _
                And ByteArr IsNot Nothing Then
                'Footer Calculation

                LblValTotalDocuments.Text = Val(LblValTotalDocuments.Text) + 1
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
            If AglObj.RequiredField(TxtSessionProgramme, LblSessionProgramme.Text) Then Exit Function
            If AglObj.RequiredField(TxtStreamYearSemester, LblStreamYearSemester.Text) Then Exit Function
            If AglObj.RequiredField(TxtSubject, LblSubject.Text) Then Exit Function
            If AglObj.RequiredField(TxtSubjectManualCode, LblSubjectManualCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtTeacher, LblTeacher.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            If TxtCompletionDate.Text.Trim <> "" And TxtV_Date.Text.Trim <> "" Then
                If CDate(TxtCompletionDate.Text) < CDate(TxtV_Date.Text) Then
                    MsgBox("Completion Date < " & LblV_Date.Text & "!...")
                    TxtCompletionDate.Focus() : Exit Function
                End If
            End If

            If AgL.XNull(LblStreamYearSemester.Tag).ToString <> "" Then
                If Not AgL.StrCmp(LblStreamYearSemester.Tag, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Please Check Semester!...")
                    TxtStreamYearSemester.Focus() : Exit Function
                End If
            End If

            AgCL.AgBlankNothingCells(DGL1)
            AgCL.AgBlankNothingCells(DGL2)
            AgCL.AgBlankNothingCells(DGL3)

            If Val(LblValTotalQuestion.Text) + Val(LblValTotalDocuments.Text) = 0 Then
                MsgBox("" & LblTitle1.Text & " not exists!...")
                DGL1.CurrentCell = DGL1(Col1Question, 0) : DGL1.Focus() : Exit Function
            End If

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Sch_TutorialAssignment H With (NoLock) " & _
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
        LblValTotalQuestion.Text = 0 : LblValTotalReference.Text = 0 : LblValTotalDocuments.Text = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()

        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtRemark.Enter, TxtDivision.Enter, TxtDocId.Enter, TxtReferenceNo.Enter, _
        TxtSite_Code.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtRemark.Enter, TxtCompletionDate.Enter, _
        TxtSessionProgramme.Enter, TxtStreamYearSemester.Enter, TxtSubject.Enter, TxtSubjectManualCode.Enter, _
        TxtTeacher.Enter, TxtUnit.Enter

        Dim bStrFilter As String = ""
        Try
            Select Case sender.name
                Case TxtSubject.Name
                    'TxtSubject.AgRowFilter = " SubjectType = " & AgL.Chk_Text(ClsMain.SubjectType.Practical) & ""

                Case TxtTeacher.Name
                    bStrFilter = " 1=1 "

                    If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                        bStrFilter += " And LogInUser = '" & AgL.PubUserName & "' "
                    End If

                    TxtTeacher.AgRowFilter = bStrFilter & " and IsActive = 'Yes' "

                Case TxtTeacher.Name
                    TxtTeacher.AgRowFilter = "  "

                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, _
        TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtCompletionDate.Validating, _
        TxtSessionProgramme.Validating, TxtStreamYearSemester.Validating, TxtSubject.Validating, TxtSubjectManualCode.Validating, _
        TxtTeacher.Validating, TxtUnit.Validating

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
                End If
                DrTemp = Nothing

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

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded, DGL3.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved, DGL3.RowsRemoved
        AgL.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Public Sub Dgl2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellEndEdit
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
                    '<Executbale Code>
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Dgl3_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL3
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

    Private Sub DGL3_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellContentClick
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim OpenPicDialogBox As OpenFileDialog
        Dim ImagePath$ = "", sFilePath As String = ""
        Dim bBlnNewImageFlag As Boolean = False
        Dim fByte As Byte() = Nothing
        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            Select Case DGL3.Columns(DGL3.CurrentCell.ColumnIndex).Name
                Case Col3BtnAttachment
                    If DGL3.Item(Col3ByteArray, mRowIndex).Value Is Nothing Then DGL3.Item(Col3ByteArray, mRowIndex).Value = ""
                    If DGL3.Item(Col3FileName, mRowIndex).Value Is Nothing Then DGL3.Item(Col3FileName, mRowIndex).Value = ""

                    If DGL3.Item(Col3ByteArray, mRowIndex).Value.ToString.Trim <> "" Then
                        bBlnNewImageFlag = False
                        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                            If AgL.XNull(DGL3.Item(Col3FileName, mRowIndex).Value).ToString.Trim <> "" Then
                                sFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + "\" + DGL3.Item(Col3FileName, mRowIndex).Value.ToString
                                Call SaveToFile(sFilePath, DGL3.Item(Col3ByteArray, mRowIndex).Value)
                                System.Diagnostics.Process.Start(sFilePath)
                            End If

                        Else
                            If MsgBox("Want To Change Image?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                bBlnNewImageFlag = True
                            End If
                        End If
                    Else
                        If Not AgL.StrCmp(Topctrl1.Mode, "Browse") Then bBlnNewImageFlag = True
                    End If

                    If bBlnNewImageFlag Then
                        OpenPicDialogBox = New OpenFileDialog

                        OpenPicDialogBox.Title = "Set Image File"
                        OpenPicDialogBox.Filter = "PDF Files(*.pdf)|*.pdf"

                        ImagePath = My.Application.Info.DirectoryPath
                        OpenPicDialogBox.InitialDirectory = ImagePath
                        OpenPicDialogBox.DefaultExt = "*.pdf"
                        OpenPicDialogBox.FilterIndex = 1

                        OpenPicDialogBox.FileName = ""

                        If OpenPicDialogBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub


                        sFilePath = OpenPicDialogBox.FileName
                        If OpenPicDialogBox.FileName.ToString.Trim = "" Then
                            DGL3.Item(Col3FileName, mRowIndex).Value = ""
                        Else
                            DGL3.Item(Col3FileName, mRowIndex).Value = AgL.MidStr(OpenPicDialogBox.FileName, InStrRev(OpenPicDialogBox.FileName, "\"), OpenPicDialogBox.FileName.Length - InStrRev(OpenPicDialogBox.FileName, "\"))
                        End If

                    End If

                    If bBlnNewImageFlag = True Then
                        If sFilePath = "" Then Exit Sub

                        fByte = GetFromFile(sFilePath)
                        DGL3.Item(Col3ByteArray, mRowIndex).Value = fByte
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Public Function GetFromFile(ByVal filePath As String) As Byte()

        If Not System.IO.File.Exists(filePath) Then Return Nothing

        Dim fs As New System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        Dim br As New System.IO.BinaryReader(fs)

        Dim fByte As Byte() = br.ReadBytes(CInt(fs.Length))

        br.Close() : fs.Close()

        Return fByte

    End Function

    Public Sub SaveToFile(ByVal filePath As String, ByVal bFile As Byte())
        Dim fs As New System.IO.FileStream(filePath, System.IO.FileMode.Create)

        Dim bw As New System.IO.BinaryWriter(fs)

        bw.Write(bFile)

        bw.Flush() : bw.Close() : bw = Nothing

        fs.Close() : fs = Nothing

    End Sub

    Private Sub FrmTutorialSheet_BaseEvent_Save_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Save_PostTrans
        Call ProcTutorialAssignment_BLOB(SearchCode)
    End Sub

    Sub ProcTutorialAssignment_BLOB(ByVal SearchCode As String)
        Dim ByteArr As Byte() = Nothing
        Dim bCondStr$ = " Where 1=1 "
        Dim GcnRead As SqlConnection = Nothing
        Dim bIntSr% = 0, bIntI% = 0

        Try
            If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                GcnRead = AgL.FunGetReadConnection(AgL.GCnImage_ConnectionString)

                mQry = "Delete From TutorialAssignment_BLOB " & _
                        " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)

                With DGL3
                    For bIntI = 0 To .Rows.Count - 1
                        Try
                            ByteArr = DGL3.Item(Col3ByteArray, bIntI).Value
                        Catch ex As Exception

                        End Try


                        If AgL.XNull(DGL3.Item(Col3Description, bIntI).Value).ToString.Trim <> "" _
                            And AgL.XNull(DGL3.Item(Col3FileName, bIntI).Value).ToString.Trim <> "" _
                            And ByteArr IsNot Nothing Then

                            bIntSr += 1

                            bCondStr = " Where 1=1 "
                            bCondStr += " And DocId = " & AgL.Chk_Text(SearchCode) & " "
                            bCondStr += " And Sr = " & bIntSr & " "

                            mQry = "INSERT INTO dbo.TutorialAssignment_BLOB (DocId, Sr, Description, FileName) " & _
                                    " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                                    " " & AgL.Chk_Text(DGL3.Item(Col3Description, bIntI).Value) & ", " & _
                                    " " & AgL.Chk_Text(DGL3.Item(Col3FileName, bIntI).Value) & " " & _
                                    " )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)

                            mQry = "Update TutorialAssignment_BLOB Set BLOB=@pic " & bCondStr

                            Dim cmd As SqlCommand = New SqlCommand(mQry, AgL.GcnImage)
                            Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
                            Pic.Value = ByteArr
                            cmd.Parameters.Add(Pic)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Sub
End Class
