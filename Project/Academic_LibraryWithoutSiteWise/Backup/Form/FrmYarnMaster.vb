Public Class FrmYarnMaster
    Inherits AgTemplate.TempMaster
    Dim mQry$

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtPly = New AgControls.AgTextBox
        Me.LblPly = New System.Windows.Forms.Label
        Me.TxtTwist = New AgControls.AgTextBox
        Me.LblTwist = New System.Windows.Forms.Label
        Me.TxtYarnGroup = New AgControls.AgTextBox
        Me.LblYarnGroup = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblShortName = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.TxtCount = New AgControls.AgTextBox
        Me.LblCount = New System.Windows.Forms.Label
        Me.TxtUnit = New AgControls.AgTextBox
        Me.LblUnit = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(862, 41)
        Me.Topctrl1.TabIndex = 7
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 300)
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 304)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(143, 304)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(553, 304)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(399, 304)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(703, 304)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(275, 304)
        '
        'TxtPly
        '
        Me.TxtPly.AgMandatory = False
        Me.TxtPly.AgMasterHelp = True
        Me.TxtPly.AgNumberLeftPlaces = 0
        Me.TxtPly.AgNumberNegetiveAllow = False
        Me.TxtPly.AgNumberRightPlaces = 0
        Me.TxtPly.AgPickFromLastValue = False
        Me.TxtPly.AgRowFilter = ""
        Me.TxtPly.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPly.AgSelectedValue = Nothing
        Me.TxtPly.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPly.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPly.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPly.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPly.Location = New System.Drawing.Point(550, 154)
        Me.TxtPly.MaxLength = 20
        Me.TxtPly.Name = "TxtPly"
        Me.TxtPly.Size = New System.Drawing.Size(129, 18)
        Me.TxtPly.TabIndex = 5
        '
        'LblPly
        '
        Me.LblPly.AutoSize = True
        Me.LblPly.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPly.Location = New System.Drawing.Point(471, 157)
        Me.LblPly.Name = "LblPly"
        Me.LblPly.Size = New System.Drawing.Size(27, 16)
        Me.LblPly.TabIndex = 683
        Me.LblPly.Text = "Ply"
        '
        'TxtTwist
        '
        Me.TxtTwist.AgMandatory = False
        Me.TxtTwist.AgMasterHelp = True
        Me.TxtTwist.AgNumberLeftPlaces = 0
        Me.TxtTwist.AgNumberNegetiveAllow = False
        Me.TxtTwist.AgNumberRightPlaces = 0
        Me.TxtTwist.AgPickFromLastValue = False
        Me.TxtTwist.AgRowFilter = ""
        Me.TxtTwist.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTwist.AgSelectedValue = Nothing
        Me.TxtTwist.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTwist.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTwist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTwist.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTwist.Location = New System.Drawing.Point(334, 154)
        Me.TxtTwist.MaxLength = 20
        Me.TxtTwist.Name = "TxtTwist"
        Me.TxtTwist.Size = New System.Drawing.Size(129, 18)
        Me.TxtTwist.TabIndex = 4
        '
        'LblTwist
        '
        Me.LblTwist.AutoSize = True
        Me.LblTwist.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTwist.Location = New System.Drawing.Point(183, 158)
        Me.LblTwist.Name = "LblTwist"
        Me.LblTwist.Size = New System.Drawing.Size(38, 16)
        Me.LblTwist.TabIndex = 682
        Me.LblTwist.Text = "Twist"
        '
        'TxtYarnGroup
        '
        Me.TxtYarnGroup.AgMandatory = False
        Me.TxtYarnGroup.AgMasterHelp = True
        Me.TxtYarnGroup.AgNumberLeftPlaces = 0
        Me.TxtYarnGroup.AgNumberNegetiveAllow = False
        Me.TxtYarnGroup.AgNumberRightPlaces = 0
        Me.TxtYarnGroup.AgPickFromLastValue = False
        Me.TxtYarnGroup.AgRowFilter = ""
        Me.TxtYarnGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtYarnGroup.AgSelectedValue = Nothing
        Me.TxtYarnGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtYarnGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtYarnGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYarnGroup.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYarnGroup.Location = New System.Drawing.Point(550, 134)
        Me.TxtYarnGroup.MaxLength = 20
        Me.TxtYarnGroup.Name = "TxtYarnGroup"
        Me.TxtYarnGroup.Size = New System.Drawing.Size(129, 18)
        Me.TxtYarnGroup.TabIndex = 3
        '
        'LblYarnGroup
        '
        Me.LblYarnGroup.AutoSize = True
        Me.LblYarnGroup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYarnGroup.Location = New System.Drawing.Point(471, 135)
        Me.LblYarnGroup.Name = "LblYarnGroup"
        Me.LblYarnGroup.Size = New System.Drawing.Size(74, 16)
        Me.LblYarnGroup.TabIndex = 681
        Me.LblYarnGroup.Text = "Yarn Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(318, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 666
        Me.Label1.Text = "Ä"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(318, 99)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 664
        Me.LblBank_NameReq.Text = "Ä"
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = True
        Me.TxtManualCode.AgMasterHelp = True
        Me.TxtManualCode.AgNumberLeftPlaces = 0
        Me.TxtManualCode.AgNumberNegetiveAllow = False
        Me.TxtManualCode.AgNumberRightPlaces = 0
        Me.TxtManualCode.AgPickFromLastValue = False
        Me.TxtManualCode.AgRowFilter = ""
        Me.TxtManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualCode.AgSelectedValue = Nothing
        Me.TxtManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualCode.Location = New System.Drawing.Point(334, 94)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(129, 18)
        Me.TxtManualCode.TabIndex = 0
        '
        'LblShortName
        '
        Me.LblShortName.AutoSize = True
        Me.LblShortName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShortName.Location = New System.Drawing.Point(183, 97)
        Me.LblShortName.Name = "LblShortName"
        Me.LblShortName.Size = New System.Drawing.Size(69, 16)
        Me.LblShortName.TabIndex = 660
        Me.LblShortName.Text = "Yarn Code"
        '
        'TxtDescription
        '
        Me.TxtDescription.AgMandatory = True
        Me.TxtDescription.AgMasterHelp = True
        Me.TxtDescription.AgNumberLeftPlaces = 0
        Me.TxtDescription.AgNumberNegetiveAllow = False
        Me.TxtDescription.AgNumberRightPlaces = 0
        Me.TxtDescription.AgPickFromLastValue = False
        Me.TxtDescription.AgRowFilter = ""
        Me.TxtDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDescription.AgSelectedValue = Nothing
        Me.TxtDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(334, 114)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(345, 18)
        Me.TxtDescription.TabIndex = 1
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(183, 117)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(104, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Yarn Description"
        '
        'TxtCount
        '
        Me.TxtCount.AgMandatory = False
        Me.TxtCount.AgMasterHelp = True
        Me.TxtCount.AgNumberLeftPlaces = 0
        Me.TxtCount.AgNumberNegetiveAllow = False
        Me.TxtCount.AgNumberRightPlaces = 0
        Me.TxtCount.AgPickFromLastValue = False
        Me.TxtCount.AgRowFilter = ""
        Me.TxtCount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCount.AgSelectedValue = Nothing
        Me.TxtCount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCount.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCount.Location = New System.Drawing.Point(334, 174)
        Me.TxtCount.MaxLength = 20
        Me.TxtCount.Name = "TxtCount"
        Me.TxtCount.Size = New System.Drawing.Size(129, 18)
        Me.TxtCount.TabIndex = 6
        '
        'LblCount
        '
        Me.LblCount.AutoSize = True
        Me.LblCount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCount.Location = New System.Drawing.Point(183, 178)
        Me.LblCount.Name = "LblCount"
        Me.LblCount.Size = New System.Drawing.Size(42, 16)
        Me.LblCount.TabIndex = 685
        Me.LblCount.Text = "Count"
        '
        'TxtUnit
        '
        Me.TxtUnit.AgMandatory = True
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
        Me.TxtUnit.Location = New System.Drawing.Point(334, 134)
        Me.TxtUnit.MaxLength = 20
        Me.TxtUnit.Name = "TxtUnit"
        Me.TxtUnit.Size = New System.Drawing.Size(129, 18)
        Me.TxtUnit.TabIndex = 2
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnit.Location = New System.Drawing.Point(183, 138)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(31, 16)
        Me.LblUnit.TabIndex = 687
        Me.LblUnit.Text = "Unit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(318, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 688
        Me.Label2.Text = "Ä"
        '
        'FrmYarnMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 348)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUnit)
        Me.Controls.Add(Me.LblUnit)
        Me.Controls.Add(Me.TxtCount)
        Me.Controls.Add(Me.LblCount)
        Me.Controls.Add(Me.TxtPly)
        Me.Controls.Add(Me.LblPly)
        Me.Controls.Add(Me.TxtTwist)
        Me.Controls.Add(Me.LblTwist)
        Me.Controls.Add(Me.TxtYarnGroup)
        Me.Controls.Add(Me.LblYarnGroup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblShortName)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmYarnMaster"
        Me.Text = "Quality Master"
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.LblDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtDescription, 0)
        Me.Controls.SetChildIndex(Me.LblShortName, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblBank_NameReq, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblYarnGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtYarnGroup, 0)
        Me.Controls.SetChildIndex(Me.LblTwist, 0)
        Me.Controls.SetChildIndex(Me.TxtTwist, 0)
        Me.Controls.SetChildIndex(Me.LblPly, 0)
        Me.Controls.SetChildIndex(Me.TxtPly, 0)
        Me.Controls.SetChildIndex(Me.LblCount, 0)
        Me.Controls.SetChildIndex(Me.TxtCount, 0)
        Me.Controls.SetChildIndex(Me.LblUnit, 0)
        Me.Controls.SetChildIndex(Me.TxtUnit, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
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

    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblShortName As System.Windows.Forms.Label
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblYarnGroup As System.Windows.Forms.Label
    Friend WithEvents TxtYarnGroup As AgControls.AgTextBox
    Friend WithEvents LblTwist As System.Windows.Forms.Label
    Friend WithEvents TxtTwist As AgControls.AgTextBox
    Friend WithEvents LblPly As System.Windows.Forms.Label
    Friend WithEvents TxtCount As AgControls.AgTextBox
    Friend WithEvents LblCount As System.Windows.Forms.Label
    Friend WithEvents TxtUnit As AgControls.AgTextBox
    Friend WithEvents LblUnit As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPly As AgControls.AgTextBox


#End Region

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtManualCode, "Short Name") Then passed = False : Exit Sub
        If AgL.RequiredField(TxtDescription, "Description") Then passed = False : Exit Sub
        If AgL.RequiredField(TxtUnit, "Unit") Then passed = False : Exit Sub

        'If TxtManualCode.Text.Trim = "" Then TxtManualCode.Focus() : Err.Raise(1, , "Short Name Is Required!")
        'If TxtDescription.Text.Trim = "" Then TxtDescription.Focus() : Err.Raise(1, , "Description Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From RUG_Yarn Where ManualCode='" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Code Already Exist!")

            mQry = "Select count(*) From RUG_Yarn Where Description='" & TxtDescription.Text & "' And Div_Code = '" & AgL.PubDivCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Description Already Exist!")

            mQry = "Select count(*) From RUG_Yarn_Log Where ManualCode = '" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Code Already Exists in Log File")

            mQry = "Select count(*) From RUG_Yarn_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From RUG_Yarn Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mInternalCode & "' And Div_Code = '" & AgL.PubDivCode & "'   "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Code Already Exist!")

            mQry = "Select count(*) From RUG_Yarn Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "'  And Div_Code = '" & AgL.PubDivCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Description Already Exist!")

            mQry = "Select count(*) From Rug_Yarn_Log Where ManualCode = '" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Code Already Exists in Log File")

            mQry = "Select count(*) From Rug_Yarn_Log Where Description = '" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT UID, ManualCode as [Yarn Code], Description [Yarn Description], " & _
                        " YarnGroup, Twist, Ply, Count, Unit " & _
                        " FROM RUG_Yarn_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Yarn Code]"
    End Sub

    Private Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT Code, ManualCode as [Yarn Code], Description [Yarn Description], " & _
                            " YarnGroup, Twist, Ply, Count , Unit " & _
                            " FROM RUG_Yarn " & mConStr & _
                            " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Yarn Code]"
    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "RUG_Yarn"
        LogTableName = "RUG_Yarn_LOG"
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "Update RUG_Yarn_Log " & _
                "   SET  " & _
                "	ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                "	Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                "	YarnGroup = " & AgL.Chk_Text(TxtYarnGroup.Text) & ", " & _
                "	Twist = " & AgL.Chk_Text(TxtTwist.Text) & ", " & _
                "	Ply = " & AgL.Chk_Text(TxtPly.Text) & ", " & _
                "	Count = " & AgL.Chk_Text(TxtCount.Text) & ", " & _
                "	Unit = " & AgL.Chk_Text(TxtUnit.Text) & " " & _
                "   Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText

    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select  Code, ManualCode As [Yarn Code], Div_Code " & _
                " From Rug_Yarn " & _
                " Order By ManualCode"
        TxtManualCode.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Description As Name , Div_Code From Rug_Yarn  " & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Distinct YarnGroup  as Code, YarnGroup as Name, Div_Code " & _
                "  From Rug_Yarn  " & _
                "  WHERE YarnGroup Is Not Null" & _
                "  Order By YarnGroup"
        TxtYarnGroup.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Distinct Twist  as Code, Twist as Name, Div_Code " & _
                "  From Rug_Yarn " & _
                "  WHERE Twist Is Not Null" & _
                "  Order By Twist"
        TxtTwist.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Distinct Ply  as Code, Ply as Name, Div_Code " & _
                "  From Rug_Yarn " & _
                "  WHERE Ply Is Not Null" & _
                "  Order By Ply"
        TxtPly.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Distinct Count  as Code, Count as Name, Div_Code " & _
                "  From Rug_Yarn " & _
                "  WHERE Count Is Not Null" & _
                "  Order By Count"
        TxtCount.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code as Code, Code As Unit From Unit " & _
            "  Order By Code"
        TxtUnit.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select Code As SearchCode " & _
                " From RUG_Yarn " & mConStr & _
                " And IsNull(IsDeleted,0)=0 " & _
                " Order By ManualCode "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select UID As SearchCode " & _
               " From RUG_Yarn_log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' " & _
               " Order By ManualCode"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From RUG_Yarn Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From RUG_Yarn_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtYarnGroup.Text = AgL.XNull(.Rows(0)("YarnGroup"))
                TxtTwist.Text = AgL.XNull(.Rows(0)("Twist"))
                TxtPly.Text = AgL.XNull(.Rows(0)("Ply"))
                TxtCount.Text = AgL.XNull(.Rows(0)("Count"))
                TxtUnit.Text = AgL.XNull(.Rows(0)("Unit"))
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmYarn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 382, 870, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtManualCode.Enter, _
        TxtDescription.Enter, TxtYarnGroup.Enter, TxtTwist.Enter, TxtPly.Enter, TxtCount.Enter, TxtUnit.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name, TxtYarnGroup.Name, TxtTwist.Name, TxtPly.Name, TxtCount.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
