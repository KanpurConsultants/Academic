Public Class FrmMemberType
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.LblBooksAllowedReq = New System.Windows.Forms.Label
        Me.TxtBooksAllowed = New AgControls.AgTextBox
        Me.LblBooksAllowed = New System.Windows.Forms.Label
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
        Me.Topctrl1.TabIndex = 2
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 304)
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 308)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 308)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 308)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 308)
        Me.GBoxApprove.Size = New System.Drawing.Size(147, 44)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Size = New System.Drawing.Size(89, 18)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Location = New System.Drawing.Point(118, 18)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(702, 308)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 308)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Tag = ""
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(299, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 666
        Me.Label1.Text = "Ä"
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
        Me.TxtDescription.Location = New System.Drawing.Point(320, 122)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(345, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(198, 123)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(73, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Description"
        '
        'LblBooksAllowedReq
        '
        Me.LblBooksAllowedReq.AutoSize = True
        Me.LblBooksAllowedReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBooksAllowedReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBooksAllowedReq.Location = New System.Drawing.Point(299, 147)
        Me.LblBooksAllowedReq.Name = "LblBooksAllowedReq"
        Me.LblBooksAllowedReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBooksAllowedReq.TabIndex = 674
        Me.LblBooksAllowedReq.Text = "Ä"
        '
        'TxtBooksAllowed
        '
        Me.TxtBooksAllowed.AgMandatory = True
        Me.TxtBooksAllowed.AgMasterHelp = True
        Me.TxtBooksAllowed.AgNumberLeftPlaces = 3
        Me.TxtBooksAllowed.AgNumberNegetiveAllow = False
        Me.TxtBooksAllowed.AgNumberRightPlaces = 0
        Me.TxtBooksAllowed.AgPickFromLastValue = False
        Me.TxtBooksAllowed.AgRowFilter = ""
        Me.TxtBooksAllowed.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBooksAllowed.AgSelectedValue = Nothing
        Me.TxtBooksAllowed.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBooksAllowed.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtBooksAllowed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBooksAllowed.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBooksAllowed.Location = New System.Drawing.Point(320, 142)
        Me.TxtBooksAllowed.MaxLength = 3
        Me.TxtBooksAllowed.Name = "TxtBooksAllowed"
        Me.TxtBooksAllowed.Size = New System.Drawing.Size(100, 18)
        Me.TxtBooksAllowed.TabIndex = 1
        '
        'LblBooksAllowed
        '
        Me.LblBooksAllowed.AutoSize = True
        Me.LblBooksAllowed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBooksAllowed.Location = New System.Drawing.Point(198, 143)
        Me.LblBooksAllowed.Name = "LblBooksAllowed"
        Me.LblBooksAllowed.Size = New System.Drawing.Size(94, 16)
        Me.LblBooksAllowed.TabIndex = 672
        Me.LblBooksAllowed.Text = "Books Allowed"
        '
        'FrmMemberType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 352)
        Me.Controls.Add(Me.LblBooksAllowedReq)
        Me.Controls.Add(Me.TxtBooksAllowed)
        Me.Controls.Add(Me.LblBooksAllowed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmMemberType"
        Me.Text = "Member Type  Master"
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
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblBooksAllowed, 0)
        Me.Controls.SetChildIndex(Me.TxtBooksAllowed, 0)
        Me.Controls.SetChildIndex(Me.LblBooksAllowedReq, 0)
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
    Friend WithEvents LblBooksAllowedReq As System.Windows.Forms.Label
    Friend WithEvents TxtBooksAllowed As AgControls.AgTextBox
    Friend WithEvents LblBooksAllowed As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label


#End Region

    Private Sub FrmMemberType_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation

        If AgL.RequiredField(TxtDescription, "Description") Then passed = False : Exit Sub

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Lib_MemberType Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " aND IsNull(IsDeleted,0)=0  and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Member Type Already Exists") : passed = False : Exit Sub
            mQry = "Select count(*) From Lib_MemberType_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Member Type Already Exists in Log File") : passed = False : Exit Sub
        Else
            mQry = "Select count(*) From Lib_MemberType Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  aND IsNull(IsDeleted,0)=0 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Member Type Already Exists") : passed = False : Exit Sub

            mQry = "Select count(*) From Lib_MemberType_Log Where Description='" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Member Type Already Exists in Log File") : passed = False : Exit Sub
        End If


    End Sub

    Private Sub FrmMemberType_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        AgL.PubFindQry = "SELECT UID, Description [Member Type], BooksAllowed AS [Books Allowed]" & _
                        " FROM Lib_MemberType_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Member Type]"
    End Sub

    Private Sub FrmMemberType_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        AgL.PubFindQry = "SELECT Code, Description [Member Type], BooksAllowed AS [Books Allowed]" & _
                        " FROM Lib_MemberType " & mConStr & _
                        " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Member Type]"
    End Sub

    Private Sub FrmMemberType_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_MemberType"
        LogTableName = "Lib_MemberType_LOG"
    End Sub

    Private Sub FrmMemberType_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "Update Lib_MemberType_LOG " & _
                "   SET  " & _
                "	Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                "	BooksAllowed = " & Val(TxtBooksAllowed.Text) & ", " & _
                "   Site_Code = '" & AgL.PubSiteCode & "' " & _
                "   Where UID = '" & SearchCode & "' "


        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Description As Name , Div_Code ,IsNull( IsDeleted,0) as IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
            " From Lib_MemberType " & _
            " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " " & _
            " Order By Description"
        TxtDescription.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        mQry = "Select Code As SearchCode " & _
            " From Lib_MemberType " & mConStr & _
            " And IsNull(IsDeleted,0)=0 Order By Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        mQry = "Select UID As SearchCode " & _
               " From Lib_MemberType_log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' Order By Description"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmMemberType_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From Lib_MemberType Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From Lib_MemberType_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtBooksAllowed.Text = AgL.VNull(.Rows(0)("BooksAllowed"))
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmDepartment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 320, 870, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter
        Try
            Select Case sender.name
                Case TxtDescription.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  " & ClsMain.RetDivFilterStr & ""
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
