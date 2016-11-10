Public Class FrmMember
    Inherits AgTemplate.TempSubGroup

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
        MainTable = "Lib_Member"
        LogTable = "Lib_Member_Log"
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtAdmissionNo = New AgControls.AgTextBox
        Me.LblAdmissionNo = New System.Windows.Forms.Label
        Me.TxtClass = New AgControls.AgTextBox
        Me.LblClass = New System.Windows.Forms.Label
        Me.TxtStudentCode = New AgControls.AgTextBox
        Me.LblStudentCode = New System.Windows.Forms.Label
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.LblMemberCardNo = New System.Windows.Forms.Label
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.LblFatherName = New System.Windows.Forms.Label
        Me.TxtMotherName = New AgControls.AgTextBox
        Me.LblMotherName = New System.Windows.Forms.Label
        Me.TxtMemberType = New AgControls.AgTextBox
        Me.LblMemberType = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.txtReminderRemark = New AgControls.AgTextBox
        Me.LblReminderRemark = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.MemberCardNoReq = New System.Windows.Forms.Label
        Me.TxtIssueLockReason = New AgControls.AgTextBox
        Me.LblIssueLockReason = New System.Windows.Forms.Label
        Me.TxtIssueLockFromDate = New AgControls.AgTextBox
        Me.LblIssueLockFromDate = New System.Windows.Forms.Label
        Me.TxtIssueLockTillDate = New AgControls.AgTextBox
        Me.LblIssueLockTillDate = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblAcGroupReq
        '
        Me.LblAcGroupReq.Location = New System.Drawing.Point(13, 318)
        Me.LblAcGroupReq.Visible = False
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(202, 105)
        Me.LblName.Size = New System.Drawing.Size(93, 16)
        Me.LblName.Text = "Member Name"
        '
        'TxtDispName
        '
        Me.TxtDispName.Location = New System.Drawing.Point(331, 104)
        Me.TxtDispName.Size = New System.Drawing.Size(350, 18)
        Me.TxtDispName.TabIndex = 3
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(202, 85)
        Me.LblManualCode.Size = New System.Drawing.Size(89, 16)
        Me.LblManualCode.Text = "Member Code"
        '
        'TxtManualCode
        '
        Me.TxtManualCode.Location = New System.Drawing.Point(331, 84)
        Me.TxtManualCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtManualCode.TabIndex = 1
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(315, 91)
        '
        'LblNameReq
        '
        Me.LblNameReq.Location = New System.Drawing.Point(315, 111)
        '
        'TxtAdd3
        '
        Me.TxtAdd3.Location = New System.Drawing.Point(331, 224)
        Me.TxtAdd3.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdd3.TabIndex = 9
        '
        'LblAddress
        '
        Me.LblAddress.Location = New System.Drawing.Point(202, 185)
        '
        'TxtAdd1
        '
        Me.TxtAdd1.Location = New System.Drawing.Point(331, 184)
        Me.TxtAdd1.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdd1.TabIndex = 7
        '
        'TxtAdd2
        '
        Me.TxtAdd2.Location = New System.Drawing.Point(331, 204)
        Me.TxtAdd2.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdd2.TabIndex = 8
        '
        'LblAddressReq
        '
        Me.LblAddressReq.Location = New System.Drawing.Point(315, 192)
        '
        'LblCity
        '
        Me.LblCity.Location = New System.Drawing.Point(202, 244)
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(331, 244)
        Me.TxtCity.TabIndex = 10
        '
        'LblCityReq
        '
        Me.LblCityReq.Location = New System.Drawing.Point(315, 251)
        '
        'LblPhone
        '
        Me.LblPhone.Location = New System.Drawing.Point(202, 264)
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(331, 264)
        Me.TxtPhone.Size = New System.Drawing.Size(350, 18)
        Me.TxtPhone.TabIndex = 12
        '
        'LblFax
        '
        Me.LblFax.Location = New System.Drawing.Point(202, 284)
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(331, 284)
        Me.TxtFax.Size = New System.Drawing.Size(350, 18)
        Me.TxtFax.TabIndex = 13
        '
        'LblEMail
        '
        Me.LblEMail.Location = New System.Drawing.Point(202, 304)
        '
        'TxtEMail
        '
        Me.TxtEMail.Location = New System.Drawing.Point(331, 304)
        Me.TxtEMail.Size = New System.Drawing.Size(350, 18)
        Me.TxtEMail.TabIndex = 14
        '
        'LblCountry
        '
        Me.LblCountry.Location = New System.Drawing.Point(469, 245)
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.Location = New System.Drawing.Point(32, 311)
        Me.TxtAcGroup.Size = New System.Drawing.Size(64, 18)
        Me.TxtAcGroup.Visible = False
        '
        'LblAcGroup
        '
        Me.LblAcGroup.Location = New System.Drawing.Point(29, 332)
        Me.LblAcGroup.Visible = False
        '
        'TxtCountry
        '
        Me.TxtCountry.Location = New System.Drawing.Point(580, 244)
        Me.TxtCountry.TabIndex = 11
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 470)
        Me.GroupBox1.Size = New System.Drawing.Size(919, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 474)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 474)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 474)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 474)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(702, 474)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 474)
        '
        'TxtAdmissionNo
        '
        Me.TxtAdmissionNo.AgMandatory = False
        Me.TxtAdmissionNo.AgMasterHelp = True
        Me.TxtAdmissionNo.AgNumberLeftPlaces = 0
        Me.TxtAdmissionNo.AgNumberNegetiveAllow = False
        Me.TxtAdmissionNo.AgNumberRightPlaces = 0
        Me.TxtAdmissionNo.AgPickFromLastValue = False
        Me.TxtAdmissionNo.AgRowFilter = ""
        Me.TxtAdmissionNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionNo.AgSelectedValue = Nothing
        Me.TxtAdmissionNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionNo.Location = New System.Drawing.Point(331, 344)
        Me.TxtAdmissionNo.MaxLength = 20
        Me.TxtAdmissionNo.Name = "TxtAdmissionNo"
        Me.TxtAdmissionNo.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdmissionNo.TabIndex = 16
        '
        'LblAdmissionNo
        '
        Me.LblAdmissionNo.AutoSize = True
        Me.LblAdmissionNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionNo.Location = New System.Drawing.Point(202, 345)
        Me.LblAdmissionNo.Name = "LblAdmissionNo"
        Me.LblAdmissionNo.Size = New System.Drawing.Size(89, 16)
        Me.LblAdmissionNo.TabIndex = 867
        Me.LblAdmissionNo.Text = "Admission No"
        '
        'TxtClass
        '
        Me.TxtClass.AgMandatory = False
        Me.TxtClass.AgMasterHelp = True
        Me.TxtClass.AgNumberLeftPlaces = 0
        Me.TxtClass.AgNumberNegetiveAllow = False
        Me.TxtClass.AgNumberRightPlaces = 0
        Me.TxtClass.AgPickFromLastValue = False
        Me.TxtClass.AgRowFilter = ""
        Me.TxtClass.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClass.AgSelectedValue = Nothing
        Me.TxtClass.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClass.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClass.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClass.Location = New System.Drawing.Point(331, 364)
        Me.TxtClass.MaxLength = 50
        Me.TxtClass.Name = "TxtClass"
        Me.TxtClass.Size = New System.Drawing.Size(132, 18)
        Me.TxtClass.TabIndex = 17
        '
        'LblClass
        '
        Me.LblClass.AutoSize = True
        Me.LblClass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClass.Location = New System.Drawing.Point(202, 365)
        Me.LblClass.Name = "LblClass"
        Me.LblClass.Size = New System.Drawing.Size(41, 16)
        Me.LblClass.TabIndex = 869
        Me.LblClass.Text = "Class"
        '
        'TxtStudentCode
        '
        Me.TxtStudentCode.AgMandatory = False
        Me.TxtStudentCode.AgMasterHelp = False
        Me.TxtStudentCode.AgNumberLeftPlaces = 0
        Me.TxtStudentCode.AgNumberNegetiveAllow = False
        Me.TxtStudentCode.AgNumberRightPlaces = 0
        Me.TxtStudentCode.AgPickFromLastValue = False
        Me.TxtStudentCode.AgRowFilter = ""
        Me.TxtStudentCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStudentCode.AgSelectedValue = Nothing
        Me.TxtStudentCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStudentCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStudentCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStudentCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStudentCode.Location = New System.Drawing.Point(331, 65)
        Me.TxtStudentCode.MaxLength = 20
        Me.TxtStudentCode.Name = "TxtStudentCode"
        Me.TxtStudentCode.Size = New System.Drawing.Size(350, 18)
        Me.TxtStudentCode.TabIndex = 0
        '
        'LblStudentCode
        '
        Me.LblStudentCode.AutoSize = True
        Me.LblStudentCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentCode.Location = New System.Drawing.Point(202, 66)
        Me.LblStudentCode.Name = "LblStudentCode"
        Me.LblStudentCode.Size = New System.Drawing.Size(87, 16)
        Me.LblStudentCode.TabIndex = 871
        Me.LblStudentCode.Text = "Student Code"
        '
        'TxtMemberCardNo
        '
        Me.TxtMemberCardNo.AgMandatory = True
        Me.TxtMemberCardNo.AgMasterHelp = False
        Me.TxtMemberCardNo.AgNumberLeftPlaces = 0
        Me.TxtMemberCardNo.AgNumberNegetiveAllow = False
        Me.TxtMemberCardNo.AgNumberRightPlaces = 0
        Me.TxtMemberCardNo.AgPickFromLastValue = False
        Me.TxtMemberCardNo.AgRowFilter = ""
        Me.TxtMemberCardNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberCardNo.AgSelectedValue = Nothing
        Me.TxtMemberCardNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberCardNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberCardNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(331, 124)
        Me.TxtMemberCardNo.MaxLength = 20
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(350, 18)
        Me.TxtMemberCardNo.TabIndex = 4
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.AutoSize = True
        Me.LblMemberCardNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberCardNo.Location = New System.Drawing.Point(203, 125)
        Me.LblMemberCardNo.Name = "LblMemberCardNo"
        Me.LblMemberCardNo.Size = New System.Drawing.Size(106, 16)
        Me.LblMemberCardNo.TabIndex = 875
        Me.LblMemberCardNo.Text = "Member Card No"
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
        Me.TxtFatherName.Location = New System.Drawing.Point(331, 144)
        Me.TxtFatherName.MaxLength = 100
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(350, 18)
        Me.TxtFatherName.TabIndex = 5
        '
        'LblFatherName
        '
        Me.LblFatherName.AutoSize = True
        Me.LblFatherName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFatherName.Location = New System.Drawing.Point(203, 145)
        Me.LblFatherName.Name = "LblFatherName"
        Me.LblFatherName.Size = New System.Drawing.Size(83, 16)
        Me.LblFatherName.TabIndex = 877
        Me.LblFatherName.Text = "Father Name"
        '
        'TxtMotherName
        '
        Me.TxtMotherName.AgMandatory = False
        Me.TxtMotherName.AgMasterHelp = False
        Me.TxtMotherName.AgNumberLeftPlaces = 0
        Me.TxtMotherName.AgNumberNegetiveAllow = False
        Me.TxtMotherName.AgNumberRightPlaces = 0
        Me.TxtMotherName.AgPickFromLastValue = False
        Me.TxtMotherName.AgRowFilter = ""
        Me.TxtMotherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherName.AgSelectedValue = Nothing
        Me.TxtMotherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMotherName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherName.Location = New System.Drawing.Point(331, 164)
        Me.TxtMotherName.MaxLength = 100
        Me.TxtMotherName.Name = "TxtMotherName"
        Me.TxtMotherName.Size = New System.Drawing.Size(350, 18)
        Me.TxtMotherName.TabIndex = 6
        '
        'LblMotherName
        '
        Me.LblMotherName.AutoSize = True
        Me.LblMotherName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMotherName.Location = New System.Drawing.Point(203, 165)
        Me.LblMotherName.Name = "LblMotherName"
        Me.LblMotherName.Size = New System.Drawing.Size(86, 16)
        Me.LblMotherName.TabIndex = 879
        Me.LblMotherName.Text = "Mother Name"
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
        Me.TxtMemberType.Location = New System.Drawing.Point(587, 84)
        Me.TxtMemberType.MaxLength = 20
        Me.TxtMemberType.Name = "TxtMemberType"
        Me.TxtMemberType.Size = New System.Drawing.Size(94, 18)
        Me.TxtMemberType.TabIndex = 2
        '
        'LblMemberType
        '
        Me.LblMemberType.AutoSize = True
        Me.LblMemberType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberType.Location = New System.Drawing.Point(469, 85)
        Me.LblMemberType.Name = "LblMemberType"
        Me.LblMemberType.Size = New System.Drawing.Size(87, 16)
        Me.LblMemberType.TabIndex = 881
        Me.LblMemberType.Text = "Member Type"
        '
        'TxtSession
        '
        Me.TxtSession.AgMandatory = False
        Me.TxtSession.AgMasterHelp = True
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
        Me.TxtSession.Location = New System.Drawing.Point(586, 364)
        Me.TxtSession.MaxLength = 10
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(95, 18)
        Me.TxtSession.TabIndex = 18
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(469, 364)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(55, 16)
        Me.LblSession.TabIndex = 883
        Me.LblSession.Text = "Session"
        '
        'txtReminderRemark
        '
        Me.txtReminderRemark.AgMandatory = False
        Me.txtReminderRemark.AgMasterHelp = True
        Me.txtReminderRemark.AgNumberLeftPlaces = 0
        Me.txtReminderRemark.AgNumberNegetiveAllow = False
        Me.txtReminderRemark.AgNumberRightPlaces = 0
        Me.txtReminderRemark.AgPickFromLastValue = False
        Me.txtReminderRemark.AgRowFilter = ""
        Me.txtReminderRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtReminderRemark.AgSelectedValue = Nothing
        Me.txtReminderRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtReminderRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.txtReminderRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReminderRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReminderRemark.Location = New System.Drawing.Point(331, 424)
        Me.txtReminderRemark.MaxLength = 255
        Me.txtReminderRemark.Name = "txtReminderRemark"
        Me.txtReminderRemark.Size = New System.Drawing.Size(350, 18)
        Me.txtReminderRemark.TabIndex = 22
        '
        'LblReminderRemark
        '
        Me.LblReminderRemark.AutoSize = True
        Me.LblReminderRemark.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReminderRemark.Location = New System.Drawing.Point(202, 425)
        Me.LblReminderRemark.Name = "LblReminderRemark"
        Me.LblReminderRemark.Size = New System.Drawing.Size(112, 16)
        Me.LblReminderRemark.TabIndex = 885
        Me.LblReminderRemark.Text = "Reminder Remark"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = False
        Me.TxtSubject.AgMasterHelp = True
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
        Me.TxtSubject.Location = New System.Drawing.Point(331, 324)
        Me.TxtSubject.MaxLength = 100
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(350, 18)
        Me.TxtSubject.TabIndex = 15
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(202, 325)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(52, 16)
        Me.LblSubject.TabIndex = 887
        Me.LblSubject.Text = "Subject"
        '
        'MemberCardNoReq
        '
        Me.MemberCardNoReq.AutoSize = True
        Me.MemberCardNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MemberCardNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MemberCardNoReq.Location = New System.Drawing.Point(315, 132)
        Me.MemberCardNoReq.Name = "MemberCardNoReq"
        Me.MemberCardNoReq.Size = New System.Drawing.Size(10, 7)
        Me.MemberCardNoReq.TabIndex = 888
        Me.MemberCardNoReq.Text = "Ä"
        '
        'TxtIssueLockReason
        '
        Me.TxtIssueLockReason.AgMandatory = False
        Me.TxtIssueLockReason.AgMasterHelp = True
        Me.TxtIssueLockReason.AgNumberLeftPlaces = 0
        Me.TxtIssueLockReason.AgNumberNegetiveAllow = False
        Me.TxtIssueLockReason.AgNumberRightPlaces = 0
        Me.TxtIssueLockReason.AgPickFromLastValue = False
        Me.TxtIssueLockReason.AgRowFilter = ""
        Me.TxtIssueLockReason.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssueLockReason.AgSelectedValue = Nothing
        Me.TxtIssueLockReason.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssueLockReason.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIssueLockReason.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIssueLockReason.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssueLockReason.Location = New System.Drawing.Point(331, 404)
        Me.TxtIssueLockReason.MaxLength = 255
        Me.TxtIssueLockReason.Name = "TxtIssueLockReason"
        Me.TxtIssueLockReason.Size = New System.Drawing.Size(350, 18)
        Me.TxtIssueLockReason.TabIndex = 21
        '
        'LblIssueLockReason
        '
        Me.LblIssueLockReason.AutoSize = True
        Me.LblIssueLockReason.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueLockReason.Location = New System.Drawing.Point(202, 405)
        Me.LblIssueLockReason.Name = "LblIssueLockReason"
        Me.LblIssueLockReason.Size = New System.Drawing.Size(119, 16)
        Me.LblIssueLockReason.TabIndex = 890
        Me.LblIssueLockReason.Text = "Issue Lock Reason"
        '
        'TxtIssueLockFromDate
        '
        Me.TxtIssueLockFromDate.AgMandatory = False
        Me.TxtIssueLockFromDate.AgMasterHelp = True
        Me.TxtIssueLockFromDate.AgNumberLeftPlaces = 0
        Me.TxtIssueLockFromDate.AgNumberNegetiveAllow = False
        Me.TxtIssueLockFromDate.AgNumberRightPlaces = 0
        Me.TxtIssueLockFromDate.AgPickFromLastValue = False
        Me.TxtIssueLockFromDate.AgRowFilter = ""
        Me.TxtIssueLockFromDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssueLockFromDate.AgSelectedValue = Nothing
        Me.TxtIssueLockFromDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssueLockFromDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtIssueLockFromDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIssueLockFromDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssueLockFromDate.Location = New System.Drawing.Point(331, 384)
        Me.TxtIssueLockFromDate.MaxLength = 11
        Me.TxtIssueLockFromDate.Name = "TxtIssueLockFromDate"
        Me.TxtIssueLockFromDate.Size = New System.Drawing.Size(132, 18)
        Me.TxtIssueLockFromDate.TabIndex = 19
        '
        'LblIssueLockFromDate
        '
        Me.LblIssueLockFromDate.AutoSize = True
        Me.LblIssueLockFromDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueLockFromDate.Location = New System.Drawing.Point(202, 384)
        Me.LblIssueLockFromDate.Name = "LblIssueLockFromDate"
        Me.LblIssueLockFromDate.Size = New System.Drawing.Size(126, 16)
        Me.LblIssueLockFromDate.TabIndex = 892
        Me.LblIssueLockFromDate.Text = "Issue Lock From Dt."
        '
        'TxtIssueLockTillDate
        '
        Me.TxtIssueLockTillDate.AgMandatory = False
        Me.TxtIssueLockTillDate.AgMasterHelp = True
        Me.TxtIssueLockTillDate.AgNumberLeftPlaces = 0
        Me.TxtIssueLockTillDate.AgNumberNegetiveAllow = False
        Me.TxtIssueLockTillDate.AgNumberRightPlaces = 0
        Me.TxtIssueLockTillDate.AgPickFromLastValue = False
        Me.TxtIssueLockTillDate.AgRowFilter = ""
        Me.TxtIssueLockTillDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssueLockTillDate.AgSelectedValue = Nothing
        Me.TxtIssueLockTillDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssueLockTillDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtIssueLockTillDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIssueLockTillDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssueLockTillDate.Location = New System.Drawing.Point(586, 384)
        Me.TxtIssueLockTillDate.MaxLength = 11
        Me.TxtIssueLockTillDate.Name = "TxtIssueLockTillDate"
        Me.TxtIssueLockTillDate.Size = New System.Drawing.Size(95, 18)
        Me.TxtIssueLockTillDate.TabIndex = 20
        '
        'LblIssueLockTillDate
        '
        Me.LblIssueLockTillDate.AutoSize = True
        Me.LblIssueLockTillDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueLockTillDate.Location = New System.Drawing.Point(469, 384)
        Me.LblIssueLockTillDate.Name = "LblIssueLockTillDate"
        Me.LblIssueLockTillDate.Size = New System.Drawing.Size(112, 16)
        Me.LblIssueLockTillDate.TabIndex = 894
        Me.LblIssueLockTillDate.Text = "Issue Lock Till Dt."
        '
        'FrmMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 518)
        Me.Controls.Add(Me.TxtIssueLockTillDate)
        Me.Controls.Add(Me.LblIssueLockTillDate)
        Me.Controls.Add(Me.TxtIssueLockFromDate)
        Me.Controls.Add(Me.LblIssueLockFromDate)
        Me.Controls.Add(Me.TxtIssueLockReason)
        Me.Controls.Add(Me.LblIssueLockReason)
        Me.Controls.Add(Me.MemberCardNoReq)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.txtReminderRemark)
        Me.Controls.Add(Me.LblReminderRemark)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.TxtMemberType)
        Me.Controls.Add(Me.LblMemberType)
        Me.Controls.Add(Me.TxtMotherName)
        Me.Controls.Add(Me.LblMotherName)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.LblFatherName)
        Me.Controls.Add(Me.TxtMemberCardNo)
        Me.Controls.Add(Me.LblMemberCardNo)
        Me.Controls.Add(Me.TxtStudentCode)
        Me.Controls.Add(Me.LblStudentCode)
        Me.Controls.Add(Me.TxtClass)
        Me.Controls.Add(Me.LblClass)
        Me.Controls.Add(Me.TxtAdmissionNo)
        Me.Controls.Add(Me.LblAdmissionNo)
        Me.LogLineTableCsv = ""
        Me.LogTableName = "SubGroup_LOG"
        Me.MainLineTableCsv = ","
        Me.MainTableName = "SubGroup"
        Me.Name = "FrmMember"
        Me.PrimaryField = "SubCode"
        Me.Text = "Member Master"
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.LblName, 0)
        Me.Controls.SetChildIndex(Me.TxtDispName, 0)
        Me.Controls.SetChildIndex(Me.LblManualCode, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblManualCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblNameReq, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd3, 0)
        Me.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd2, 0)
        Me.Controls.SetChildIndex(Me.LblAddressReq, 0)
        Me.Controls.SetChildIndex(Me.LblCity, 0)
        Me.Controls.SetChildIndex(Me.TxtCity, 0)
        Me.Controls.SetChildIndex(Me.LblCityReq, 0)
        Me.Controls.SetChildIndex(Me.LblPhone, 0)
        Me.Controls.SetChildIndex(Me.TxtPhone, 0)
        Me.Controls.SetChildIndex(Me.LblFax, 0)
        Me.Controls.SetChildIndex(Me.TxtFax, 0)
        Me.Controls.SetChildIndex(Me.LblEMail, 0)
        Me.Controls.SetChildIndex(Me.TxtEMail, 0)
        Me.Controls.SetChildIndex(Me.LblCountry, 0)
        Me.Controls.SetChildIndex(Me.TxtCountry, 0)
        Me.Controls.SetChildIndex(Me.LblAcGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtAcGroup, 0)
        Me.Controls.SetChildIndex(Me.LblAcGroupReq, 0)
        Me.Controls.SetChildIndex(Me.LblAdmissionNo, 0)
        Me.Controls.SetChildIndex(Me.TxtAdmissionNo, 0)
        Me.Controls.SetChildIndex(Me.LblClass, 0)
        Me.Controls.SetChildIndex(Me.TxtClass, 0)
        Me.Controls.SetChildIndex(Me.LblStudentCode, 0)
        Me.Controls.SetChildIndex(Me.TxtStudentCode, 0)
        Me.Controls.SetChildIndex(Me.LblMemberCardNo, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberCardNo, 0)
        Me.Controls.SetChildIndex(Me.LblFatherName, 0)
        Me.Controls.SetChildIndex(Me.TxtFatherName, 0)
        Me.Controls.SetChildIndex(Me.LblMotherName, 0)
        Me.Controls.SetChildIndex(Me.TxtMotherName, 0)
        Me.Controls.SetChildIndex(Me.LblMemberType, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberType, 0)
        Me.Controls.SetChildIndex(Me.LblSession, 0)
        Me.Controls.SetChildIndex(Me.TxtSession, 0)
        Me.Controls.SetChildIndex(Me.LblReminderRemark, 0)
        Me.Controls.SetChildIndex(Me.txtReminderRemark, 0)
        Me.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.Controls.SetChildIndex(Me.MemberCardNoReq, 0)
        Me.Controls.SetChildIndex(Me.LblIssueLockReason, 0)
        Me.Controls.SetChildIndex(Me.TxtIssueLockReason, 0)
        Me.Controls.SetChildIndex(Me.LblIssueLockFromDate, 0)
        Me.Controls.SetChildIndex(Me.TxtIssueLockFromDate, 0)
        Me.Controls.SetChildIndex(Me.LblIssueLockTillDate, 0)
        Me.Controls.SetChildIndex(Me.TxtIssueLockTillDate, 0)
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblAdmissionNo As System.Windows.Forms.Label
    Protected WithEvents TxtClass As AgControls.AgTextBox
    Protected WithEvents LblClass As System.Windows.Forms.Label
    Protected WithEvents TxtStudentCode As AgControls.AgTextBox
    Protected WithEvents LblStudentCode As System.Windows.Forms.Label
    Protected WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Protected WithEvents LblMemberCardNo As System.Windows.Forms.Label
    Protected WithEvents TxtFatherName As AgControls.AgTextBox
    Protected WithEvents LblFatherName As System.Windows.Forms.Label
    Protected WithEvents TxtMotherName As AgControls.AgTextBox
    Protected WithEvents LblMotherName As System.Windows.Forms.Label
    Protected WithEvents TxtMemberType As AgControls.AgTextBox
    Protected WithEvents LblMemberType As System.Windows.Forms.Label
    Protected WithEvents TxtSession As AgControls.AgTextBox
    Protected WithEvents LblSession As System.Windows.Forms.Label
    Protected WithEvents txtReminderRemark As AgControls.AgTextBox
    Protected WithEvents LblReminderRemark As System.Windows.Forms.Label
    Protected WithEvents TxtSubject As AgControls.AgTextBox
    Protected WithEvents LblSubject As System.Windows.Forms.Label
    Protected WithEvents MemberCardNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtIssueLockReason As AgControls.AgTextBox
    Protected WithEvents LblIssueLockReason As System.Windows.Forms.Label
    Protected WithEvents TxtIssueLockFromDate As AgControls.AgTextBox
    Protected WithEvents LblIssueLockFromDate As System.Windows.Forms.Label
    Protected WithEvents TxtIssueLockTillDate As AgControls.AgTextBox
    Protected WithEvents LblIssueLockTillDate As System.Windows.Forms.Label
    Protected WithEvents TxtAdmissionNo As AgControls.AgTextBox
#End Region

    Private Sub FrmMember_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtMemberCardNo, LblMemberCardNo.Text) Then passed = False : Exit Sub
        If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then passed = False : Exit Sub

        If TxtIssueLockFromDate.Text.Trim <> "" _
            Or TxtIssueLockTillDate.Text.Trim <> "" _
            Or TxtIssueLockReason.Text.Trim <> "" Then

            If AgL.RequiredField(TxtIssueLockFromDate, LblIssueLockFromDate.Text) Then passed = False : Exit Sub
            If AgL.RequiredField(TxtIssueLockTillDate, LblIssueLockTillDate.Text) Then passed = False : Exit Sub
            If AgL.RequiredField(TxtIssueLockReason, LblIssueLockReason.Text) Then passed = False : Exit Sub

            If CDate(TxtIssueLockTillDate.Text) < CDate(TxtIssueLockFromDate.Text) Then
                MsgBox("Issue Lock Till Date < Issue Lock From Date!...")
                TxtIssueLockTillDate.Focus() : passed = False : Exit Sub
            End If
        End If

    End Sub

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 520, 885, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmEmployee_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select M.*,SG.FatherName " & _
                " From Lib_Member M " & _
                " LEFT JOIN SubGroup_Log SG ON SG.SubCode=M.SubCode " & _
                " Where M.SubCode ='" & SearchCode & "'"
        Else
            mQry = "Select M.* ,SG.FatherName " & _
                " From Lib_Member_Log M " & _
                " LEFT JOIN SubGroup_Log SG ON SG.UID=M.UID " & _
                " Where M.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStudentCode.AgSelectedValue = AgL.XNull(.Rows(0)("Student"))
                TxtMemberCardNo.Text = AgL.XNull(.Rows(0)("MemberCardNo"))
                TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                TxtMemberType.AgSelectedValue = AgL.XNull(.Rows(0)("MemberType"))
                TxtSubject.Text = AgL.XNull(.Rows(0)("Subject"))
                TxtAdmissionNo.Text = AgL.XNull(.Rows(0)("AdmissionNo"))
                TxtClass.Text = AgL.XNull(.Rows(0)("Class"))
                TxtSession.Text = AgL.XNull(.Rows(0)("Session"))
                TxtIssueLockFromDate.Text = Format(AgL.XNull(.Rows(0)("IssueLockFromDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtIssueLockTillDate.Text = Format(AgL.XNull(.Rows(0)("IssueLockTillDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtIssueLockReason.Text = AgL.XNull(.Rows(0)("IssueLockReason"))
                txtReminderRemark.Text = AgL.XNull(.Rows(0)("ReminderRemark"))
            End If
        End With
    End Sub

    Private Sub FrmEmployee_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        If DtLib_Enviro.Rows.Count > 0 Then
            If AgL.VNull(DtLib_Enviro.Rows(0)("IsLinkWithAcademic")) <> 0 Then
                mQry = " SELECT S.Subcode AS Code,SG.DispName AS Student,SG.DispName AS Name,SG.ManualCode, " & _
                        " SG.FatherName, S.MotherName,SG.Add1,SG.Add2,SG.Add3,SG.CityCode,SG.CountryCode, " & _
                        " SG.Mobile, SG.FAX, SG.EMail " & _
                        " FROM Sch_Student S  " & _
                        " LEFT JOIN SubGroup Sg ON Sg.SubCode=S.SubCode  "
                TxtStudentCode.AgHelpDataSet(12) = AgL.FillData(mQry, AgL.GCn)
            End If
        End If


        mQry = " SELECT MT.Code, MT.Description, MT.BooksAllowed,MT.Div_Code,IsNull(MT.IsDeleted ,0) AS IsDeleted,	IsNull(MT.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
                " FROM Lib_MemberType MT " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        TxtMemberType.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT Class AS Code, Class FROM Lib_Member WHERE Class IS NOT NULL and  " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        TxtClass.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT Session AS Code, Session FROM Lib_Member WHERE Session IS NOT NULL and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT S.Code,S.Description AS Subject,S.Prefix,S.Div_Code,IsNull( S.IsDeleted,0) as IsDeleted, " & _
                 " ISNULL(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
                 " FROM Lib_Subject S " & _
                 " Order By S.Description"

        mQry = " SELECT DISTINCT  M.Subject AS Code,M.Subject ,SG.Div_Code,IsNull( SG.IsDeleted,0) as IsDeleted, " & _
                 " ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
                 " FROM Lib_Member M  " & _
                 " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                 " WHERE M.Subject IS NOT NULL and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " "
        TxtSubject.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmEmployee_BaseEvent_Save_SubGroupInTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_SubGroupInTrans
        mQry = " UPDATE SubGroup_Log SET " & _
                " FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & " " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " UPDATE Lib_Member_Log " & _
                " SET Student = " & AgL.Chk_Text(TxtStudentCode.AgSelectedValue) & ", " & _
                " MemberCardNo = " & AgL.Chk_Text(TxtMemberCardNo.Text) & " , " & _
                " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & ", " & _
                " MemberType = " & AgL.Chk_Text(TxtMemberType.AgSelectedValue) & ", " & _
                " Subject = " & AgL.Chk_Text(TxtSubject.Text) & ", " & _
                " AdmissionNo = " & AgL.Chk_Text(TxtAdmissionNo.Text) & ", " & _
                " Class = " & AgL.Chk_Text(TxtClass.Text) & ", " & _
                " Session = " & AgL.Chk_Text(TxtSession.Text) & ", " & _
                " IssueLockFromDate = " & AgL.Chk_Text(TxtIssueLockFromDate.Text) & ", " & _
                " IssueLockTillDate = " & AgL.Chk_Text(TxtIssueLockTillDate.Text) & ", " & _
                " IssueLockReason = " & AgL.Chk_Text(TxtIssueLockReason.Text) & ", " & _
                " ReminderRemark = " & AgL.Chk_Text(txtReminderRemark.Text) & ", " & _
                " Site_Code = '" & AgL.PubSiteCode & "' " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtSubject.Enter, TxtManualCode.Enter, TxtMemberType.Enter
        Try
            Select Case sender.name
                Case TxtSubject.Name, TxtMemberType.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtStudentCode.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtStudentCode.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtManualCode.Text = ""
                        TxtDispName.Text = ""
                        TxtFatherName.Text = ""
                        TxtMotherName.Text = ""
                        TxtAdd1.Text = ""
                        TxtAdd2.Text = ""
                        TxtAdd3.Text = ""
                        TxtCity.AgSelectedValue = ""

                        TxtEMail.Text = ""
                        TxtFax.Text = ""
                        TxtPhone.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtStudentCode.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtStudentCode.AgSelectedValue) & "")
                            TxtManualCode.Text = AgL.XNull(DrTemp(0)("ManualCode"))
                            TxtDispName.Text = AgL.XNull(DrTemp(0)("Name"))
                            TxtFatherName.Text = AgL.XNull(DrTemp(0)("FatherName"))
                            TxtMotherName.Text = AgL.XNull(DrTemp(0)("MotherName"))
                            TxtAdd1.Text = AgL.XNull(DrTemp(0)("Add1"))
                            TxtAdd2.Text = AgL.XNull(DrTemp(0)("Add2"))
                            TxtAdd3.Text = AgL.XNull(DrTemp(0)("Add3"))
                            TxtCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                            TxtEMail.Text = AgL.XNull(DrTemp(0)("EMail"))
                            TxtFax.Text = AgL.XNull(DrTemp(0)("FAX"))
                            TxtPhone.Text = AgL.XNull(DrTemp(0)("Mobile"))
                        End If
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmMember_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1 and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & "  And IsNull(SG.IsDeleted,0) = 0 "
        AgL.PubFindQry = " SELECT M.UID AS SearchCode,SG.DispName AS [Member Name],MT.Description AS [Member Type], " & _
                    " M.MemberCardNo AS [Member Card No.],SG.FatherName ,M.MotherName ,S.Description AS Subject, " & _
                    " Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail, " & _
                    " M.AdmissionNo as [Admission No], M.Class, M.Session, M.ReminderRemark As [Reminder Remark],  " & _
                    " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                    " City.CityName AS City " & _
                    " FROM Lib_Member_Log M " & _
                    " LEFT JOIN SubGroup_Log SG ON SG.UID=M.UID  " & _
                    " LEFT JOIN Lib_Subject S ON S.Code=M.Subject " & _
                    " LEFT JOIN Lib_MemberType MT ON MT.Code=M.MemberType " & _
                    " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr & _
                    " And SG.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Member Name]"
    End Sub

    Private Sub FrmMember_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1  and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & "  And IsNull(Sg.IsDeleted,0) = 0  "
        AgL.PubFindQry = " SELECT M.SubCode AS SearchCode,SG.DispName AS [Member Name],MT.Description AS [Member Type], " & _
                    " M.MemberCardNo AS [Member Card No.],SG.FatherName ,M.MotherName ,S.Description AS Subject, " & _
                    " Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail, " & _
                    " M.AdmissionNo as [Admission No], M.Class, M.Session, M.ReminderRemark As [Reminder Remark], " & _
                    " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                    " City.CityName AS City " & _
                    " FROM Lib_Member M " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode  " & _
                    " LEFT JOIN Lib_Subject S ON S.Code=M.Subject " & _
                    " LEFT JOIN Lib_MemberType MT ON MT.Code=M.MemberType " & _
                    " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr
        AgL.PubFindQryOrdBy = "[Member Name]"
    End Sub

    Private Sub FrmMember_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        If DtLib_Enviro.Rows.Count > 0 Then
            TxtAcGroup.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("MemberACGroup"))
        End If
    End Sub

    Private Sub FrmMember_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If DtLib_Enviro.Rows.Count > 0 Then
            If AgL.VNull(DtLib_Enviro.Rows(0)("IsLinkWithAcademic")) = 0 Then
                TxtStudentCode.Visible = False
                LblStudentCode.Visible = False
            End If
        End If
    End Sub
    Private Sub FrmMemberType_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        mQry = "SelectB.SubCode As SearchCode " & _
            " From Lib_Member " & mConStr & _
            " And IsNull(IsDeleted,0)=0 "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("B.Site_Code", AgL.PubSiteCode) & " "
        mQry = "Select B.UID As SearchCode " & _
               " From Lib_Member_log B " & _
               " LEFT JOIN SubGroup_Log S On B.UID = S.UID " & _
               " " & mConStr & _
               " and  S.EntryStatus = '" & LogStatus.LogOpen & "' "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub
End Class
