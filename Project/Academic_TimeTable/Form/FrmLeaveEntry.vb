Public Class FrmLeaveEntry
    Inherits Academic_ProjLib.TempTransaction

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)


    Dim mQry$

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

#Region "Form Designer Code"
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox



    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Friend WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtSubCode As AgControls.AgTextBox
    Protected WithEvents LblSubCode As System.Windows.Forms.Label
    Protected WithEvents TxtTotalDays As AgControls.AgTextBox
    Protected WithEvents LblTotalDaysReq As System.Windows.Forms.Label
    Protected WithEvents TxtToDate As AgControls.AgTextBox
    Protected WithEvents LblToDate As System.Windows.Forms.Label
    Protected WithEvents LblFromDateReq As System.Windows.Forms.Label
    Protected WithEvents TxtFromDate As AgControls.AgTextBox
    Protected WithEvents LblFromDate As System.Windows.Forms.Label
    Protected WithEvents LblTotalDays As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub InitializeComponent()
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.TxtSubCode = New AgControls.AgTextBox
        Me.LblSubCode = New System.Windows.Forms.Label
        Me.LblFromDateReq = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.LblFromDate = New System.Windows.Forms.Label
        Me.LblTotalDaysReq = New System.Windows.Forms.Label
        Me.TxtToDate = New AgControls.AgTextBox
        Me.LblToDate = New System.Windows.Forms.Label
        Me.TxtTotalDays = New AgControls.AgTextBox
        Me.LblTotalDays = New System.Windows.Forms.Label
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 303)
        Me.GroupBox1.Size = New System.Drawing.Size(1012, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(219, 313)
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
        Me.LblV_No.Location = New System.Drawing.Point(489, 53)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(598, 52)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(307, 53)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(183, 51)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(307, 38)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(322, 52)
        Me.TxtV_Date.Size = New System.Drawing.Size(138, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(183, 33)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(322, 32)
        Me.TxtV_Type.Size = New System.Drawing.Size(370, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(307, 18)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(183, 13)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(322, 12)
        Me.TxtSite_Code.Size = New System.Drawing.Size(370, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(881, 87)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(552, 53)
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(-3, 18)
        Me.Tc1.Size = New System.Drawing.Size(994, 284)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.LblTotalDays)
        Me.TP1.Controls.Add(Me.TxtTotalDays)
        Me.TP1.Controls.Add(Me.LblTotalDaysReq)
        Me.TP1.Controls.Add(Me.TxtToDate)
        Me.TP1.Controls.Add(Me.LblToDate)
        Me.TP1.Controls.Add(Me.LblFromDateReq)
        Me.TP1.Controls.Add(Me.TxtFromDate)
        Me.TP1.Controls.Add(Me.LblFromDate)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.TxtSubCode)
        Me.TP1.Controls.Add(Me.LblSubCode)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Size = New System.Drawing.Size(986, 256)
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
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromDateReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtToDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTotalDaysReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTotalDays, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTotalDays, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(994, 41)
        Me.Topctrl1.TabIndex = 1
        '
        'GBoxApproved
        '
        Me.GBoxApproved.Location = New System.Drawing.Point(797, 313)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(12, 313)
        '
        'GBoxModified
        '
        Me.GBoxModified.Location = New System.Drawing.Point(424, 313)
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
        Me.TxtRemark.Location = New System.Drawing.Point(322, 132)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Multiline = True
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(370, 80)
        Me.TxtRemark.TabIndex = 9
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(183, 134)
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
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(307, 78)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(322, 72)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(138, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(183, 73)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 770
        Me.LblReferenceNo.Text = "Reference No."
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(307, 98)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 998
        Me.LblSubCodeReq.Text = "Ä"
        '
        'TxtSubCode
        '
        Me.TxtSubCode.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSubCode.Location = New System.Drawing.Point(322, 92)
        Me.TxtSubCode.MaxLength = 20
        Me.TxtSubCode.Name = "TxtSubCode"
        Me.TxtSubCode.Size = New System.Drawing.Size(370, 18)
        Me.TxtSubCode.TabIndex = 5
        '
        'LblSubCode
        '
        Me.LblSubCode.AutoSize = True
        Me.LblSubCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubCode.Location = New System.Drawing.Point(183, 94)
        Me.LblSubCode.Name = "LblSubCode"
        Me.LblSubCode.Size = New System.Drawing.Size(89, 15)
        Me.LblSubCode.TabIndex = 997
        Me.LblSubCode.Text = "Teacher Name"
        '
        'LblFromDateReq
        '
        Me.LblFromDateReq.AutoSize = True
        Me.LblFromDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblFromDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblFromDateReq.Location = New System.Drawing.Point(444, 118)
        Me.LblFromDateReq.Name = "LblFromDateReq"
        Me.LblFromDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblFromDateReq.TabIndex = 1001
        Me.LblFromDateReq.Text = "Ä"
        '
        'TxtFromDate
        '
        Me.TxtFromDate.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtFromDate.Location = New System.Drawing.Point(459, 112)
        Me.TxtFromDate.MaxLength = 0
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(95, 18)
        Me.TxtFromDate.TabIndex = 7
        '
        'LblFromDate
        '
        Me.LblFromDate.AutoSize = True
        Me.LblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.LblFromDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromDate.Location = New System.Drawing.Point(376, 113)
        Me.LblFromDate.Name = "LblFromDate"
        Me.LblFromDate.Size = New System.Drawing.Size(69, 16)
        Me.LblFromDate.TabIndex = 1000
        Me.LblFromDate.Text = "From Date"
        '
        'LblTotalDaysReq
        '
        Me.LblTotalDaysReq.AutoSize = True
        Me.LblTotalDaysReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTotalDaysReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTotalDaysReq.Location = New System.Drawing.Point(307, 118)
        Me.LblTotalDaysReq.Name = "LblTotalDaysReq"
        Me.LblTotalDaysReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTotalDaysReq.TabIndex = 1004
        Me.LblTotalDaysReq.Text = "Ä"
        '
        'TxtToDate
        '
        Me.TxtToDate.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtToDate.Location = New System.Drawing.Point(597, 112)
        Me.TxtToDate.MaxLength = 0
        Me.TxtToDate.Name = "TxtToDate"
        Me.TxtToDate.ReadOnly = True
        Me.TxtToDate.Size = New System.Drawing.Size(95, 18)
        Me.TxtToDate.TabIndex = 8
        Me.TxtToDate.TabStop = False
        '
        'LblToDate
        '
        Me.LblToDate.AutoSize = True
        Me.LblToDate.BackColor = System.Drawing.Color.Transparent
        Me.LblToDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToDate.Location = New System.Drawing.Point(556, 114)
        Me.LblToDate.Name = "LblToDate"
        Me.LblToDate.Size = New System.Drawing.Size(35, 16)
        Me.LblToDate.TabIndex = 1003
        Me.LblToDate.Text = "Upto"
        '
        'TxtTotalDays
        '
        Me.TxtTotalDays.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtTotalDays.Location = New System.Drawing.Point(322, 112)
        Me.TxtTotalDays.MaxLength = 0
        Me.TxtTotalDays.Name = "TxtTotalDays"
        Me.TxtTotalDays.Size = New System.Drawing.Size(47, 18)
        Me.TxtTotalDays.TabIndex = 6
        Me.TxtTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalDays
        '
        Me.LblTotalDays.AutoSize = True
        Me.LblTotalDays.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalDays.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDays.Location = New System.Drawing.Point(183, 113)
        Me.LblTotalDays.Name = "LblTotalDays"
        Me.LblTotalDays.Size = New System.Drawing.Size(61, 16)
        Me.LblTotalDays.TabIndex = 1006
        Me.LblTotalDays.Text = "For Days"
        '
        'FrmLeaveEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(994, 368)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmLeaveEntry"
        Me.Text = "Member Leave Entry"
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
        Public Shared SubCode As DataSet = Nothing
    End Class


    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Pay_Leave"
        AglObj = AgL

        LblV_Type.Text = "Leave Type"
        LblV_Date.Text = "Leave Date"
        LblV_No.Text = "Leave No."
        TP1.Text = "Leave Detail"
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

        mQry = " Select H.DocID As SearchCode " & _
                " From Pay_Leave H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$ = " Where 1=1 "
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

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
                            " Sg.Name As [" & LblSubCode.Text & "], " & _
                            " " & AgL.V_No_Field("H.DocId") & " As [" & LblV_No.Text & "], " & _
                            " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " " & AgL.ConvertDateField("H.FromDate") & " As [" & LblFromDate.Text & "], " & _
                            " " & AgL.ConvertDateField("H.ToDate") & " As [" & LblToDate.Text & "], " & _
                            " Convert(Varchar,H.TotalDays) As [" & LblTotalDays.Text & "], " & _
                            " S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Pay_Leave H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & _
                            " Left JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode " & mCondStr

        AgL.PubFindQryOrdBy = "Convert(SmallDateTime,[" & LblV_Date.Text & "]) Desc, [" & LblSubCode.Text & "] "

        If GcnRead IsNot Nothing Then GcnRead.Dispose()

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        '<Executable Code>
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim bIntI As Integer = 0, bIntSr As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        mQry = "UPDATE dbo.Pay_Leave " & _
                " SET  " & _
                " 	ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " 	SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                " 	FromDate = " & AgL.Chk_Text(TxtFromDate.Text) & ", " & _
                " 	ToDate = " & AgL.Chk_Text(TxtToDate.Text) & ", " & _
                " 	TotalDays = " & Val(TxtTotalDays.Text) & ", " & _
                "   Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " WHERE DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        mQry = "Delete From Pay_Leave Where DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
                " From Pay_Leave H With (NoLock) " & _
                " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                TxtFromDate.Text = Format(AgL.XNull(.Rows(0)("FromDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtToDate.Text = Format(AgL.XNull(.Rows(0)("ToDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtTotalDays.Text = AgL.VNull(.Rows(0)("TotalDays"))


            End If
        End With
        If DsTemp IsNot Nothing Then DsTemp.Dispose()

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
        AgL.WinSetting(Me, 400, 1000, _FormLocation.Y, _FormLocation.X)
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AgL.PubUserName

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AgL.PubLoginDate
        End If

        If TxtFromDate.Text.Trim = "" Then
            TxtFromDate.Text = TxtV_Date.Text
        End If

    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        TxtV_Date.Focus()
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            mQry = "SELECT H.SubCode AS Code, Sg.Name, Sg.ManualCode AS [Manual Code] , Sg.DispName AS [Display Name], " & _
                    " H.DateOfJoin, H.DateOfResign, Right(IsNull(Sg.Mobile,''),10) AS Mobile, " & _
                    " CASE WHEN (IsNull(H.IsTeachingStaff,0)<>0 or IsNull(H.CanTakeClass,0)<>0) THEN 'Yes' ELSE 'No' END AS [Teaching Staff],  " & _
                    " CASE WHEN H.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END AS [Is Active]  " & _
                    " FROM Pay_Employee H With (NoLock)   " & _
                    " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode  " & _
                    " ORDER BY Sg.Name "
            HelpDataSet.SubCode = AgL.FillData(mQry, GcnRead)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSubCode.AgHelpDataSet(4, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.SubCode.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        Dim bIntTotalDays As Integer = 0

        TxtToDate.Text = ""

        If Val(TxtTotalDays.Text) > 0 Then
            bIntTotalDays = Val(Format(Val(TxtTotalDays.Text), "0"))
        End If

        If TxtFromDate.Text.Trim <> "" And bIntTotalDays > 0 Then
            TxtToDate.Text = DateAdd(DateInterval.Day, bIntTotalDays - 1, CDate(TxtFromDate.Text))
        End If

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

            If CDate(TxtToDate.Text) < CDate(TxtFromDate.Text) Then
                MsgBox("From Date < To Date!...", MsgBoxStyle.Information, "Validtion Check")
                TxtToDate.Focus() : Exit Function
            End If

            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM Pay_Leave H With (NoLock) " & _
                    " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                    " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                    " AND (" & AgL.ConvertDate(TxtFromDate.Text) & " BETWEEN H.FromDate And H.ToDate " & _
                    "      Or " & AgL.ConvertDate(TxtToDate.Text) & " BETWEEN H.FromDate And H.ToDate) " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
            If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                MsgBox("Leave Already Exists For Selected Period!...")
                TxtFromDate.Focus() : Exit Function
            End If

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Pay_Leave H With (NoLock) " & _
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
        '<Executable Code>
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtSubCode.Enter
        Try
            Select Case sender.name
                Case TxtSubCode.Name
                    TxtSubCode.AgRowFilter = " [Is Active] = 'Yes' And [Teaching Staff] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtFromDate.Validating, TxtToDate.Validating, TxtSubCode.Validating, TxtTotalDays.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()
            End Select

            If TxtDocId.Text.Trim <> "" And AgL.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
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

    Private Sub FrmLeaveEntry_BaseEvent_Approve_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Approve_PostTrans
        Try
            If AgLibrary.ClsConstant.IsSmsActive Then
                Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = "", bStrSubCode$ = ""
                Dim bBlnActiveEvent As Boolean = False
                Dim bDtSmsEvent As DataTable = Nothing
                Dim DrTemp As DataRow() = Nothing
                Dim bDtTemp As DataTable = Nothing

                mQry = "SELECT Sg.SubCode, Right(IsNull(Sg.Mobile,''),10) AS Mobile " & _
                        " FROM SubGroup Sg WITH (NoLock) " & _
                        " WHERE Sg.LogInUser = '" & AgL.PubUserName & "'"
                bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                If bDtTemp.Rows.Count > 0 Then
                    bStrSubCode = AgL.XNull(bDtTemp.Rows(0)("SubCode")).ToString
                    bStrMobileNo = AgL.XNull(bDtTemp.Rows(0)("Mobile")).ToString
                End If
                If bDtTemp IsNot Nothing Then bDtTemp.Dispose()

                mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & ClsMain.SmsEvent.TeacherLeave & "'"
                bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

                If bDtSmsEvent.Rows.Count > 0 Then
                    bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString

                    bBlnActiveEvent = IIf(AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString.Trim <> "", True, False)
                End If
                If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()

                If bBlnActiveEvent Then
                    bStrSMS = TxtSubCode.Text + " is on leave from " & TxtFromDate.Text & " To " & TxtToDate.Text & "."

                    If bStrSMS.Trim <> "" Then
                        'SMS To Approved By Peron
                        If bStrMobileNo.Trim <> "" Then
                            AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, bStrSubCode, bStrMobileNo, TxtV_Date.Text, bStrSMS)                            
                        End If


                        'SMS To Peron on leave
                        bStrSMS = "Your leave is approved from " & TxtFromDate.Text & " To " & TxtToDate.Text & "."
                        DrTemp = TxtSubCode.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(TxtSubCode.AgSelectedValue) & "")
                        If DrTemp.Length > 0 Then
                            bStrSubCode = AgL.XNull(DrTemp(0)("Code"))
                            bStrMobileNo = AgL.XNull(DrTemp(0)("Mobile"))
                        End If

                        If bStrSubCode.Trim <> "" And bStrSMS.Trim <> "" And bStrMobileNo.Trim <> "" Then
                            AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, bStrSubCode, bStrMobileNo, TxtV_Date.Text, bStrSMS)
                        End If

                        Call AgL.SendSms(AgL)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ProcFillReferenceNo()
        If AgL.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
            And AgL.XNull(LblPrefix.Text).ToString.Trim <> "" _
            And Val(TxtV_No.Text) > 0 Then

            TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
            LblReferenceNo.Tag = TxtReferenceNo.Text
        End If
    End Sub

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.EmployeeLeaveEntry) & ""
    End Sub


End Class
