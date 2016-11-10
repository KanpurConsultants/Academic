Public Class FrmBookType
    Inherits AgTemplate.TempMaster
    Dim mQry$

    Protected WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1MemberType As String = "Member Type"
    Protected Const Col1Issuance As String = "Issuance"
    Protected Const Col1Days As String = "Days"
    Protected Const Col1FinePerDay As String = "Fine Per Day"

    Public Const Issuance_NotAllowed As String = "Not Allowed"
    Public Const Issuance_DayIssue As String = "Day Issue"
    Friend WithEvents TxtSuffix As AgControls.AgTextBox
    Friend WithEvents LblSuffix As System.Windows.Forms.Label
    Public Const Issuance_NightIssue As String = "Night Issue"


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
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtSuffix = New AgControls.AgTextBox
        Me.LblSuffix = New System.Windows.Forms.Label
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
        Me.Topctrl1.TabIndex = 3
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 318)
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 322)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 322)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 322)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 322)
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
        Me.GroupBox2.Location = New System.Drawing.Point(702, 322)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 322)
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
        Me.Label1.Location = New System.Drawing.Point(299, 70)
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
        Me.TxtDescription.Location = New System.Drawing.Point(320, 62)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(345, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(198, 63)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(73, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Description"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(184, 112)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(495, 187)
        Me.Pnl1.TabIndex = 2
        '
        'TxtSuffix
        '
        Me.TxtSuffix.AgMandatory = False
        Me.TxtSuffix.AgMasterHelp = True
        Me.TxtSuffix.AgNumberLeftPlaces = 0
        Me.TxtSuffix.AgNumberNegetiveAllow = False
        Me.TxtSuffix.AgNumberRightPlaces = 0
        Me.TxtSuffix.AgPickFromLastValue = False
        Me.TxtSuffix.AgRowFilter = ""
        Me.TxtSuffix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSuffix.AgSelectedValue = Nothing
        Me.TxtSuffix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSuffix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSuffix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSuffix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSuffix.Location = New System.Drawing.Point(320, 82)
        Me.TxtSuffix.MaxLength = 5
        Me.TxtSuffix.Name = "TxtSuffix"
        Me.TxtSuffix.Size = New System.Drawing.Size(100, 18)
        Me.TxtSuffix.TabIndex = 1
        '
        'LblSuffix
        '
        Me.LblSuffix.AutoSize = True
        Me.LblSuffix.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSuffix.Location = New System.Drawing.Point(198, 83)
        Me.LblSuffix.Name = "LblSuffix"
        Me.LblSuffix.Size = New System.Drawing.Size(40, 16)
        Me.LblSuffix.TabIndex = 673
        Me.LblSuffix.Text = "Suffix"
        '
        'FrmBookType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 366)
        Me.Controls.Add(Me.TxtSuffix)
        Me.Controls.Add(Me.LblSuffix)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmBookType"
        Me.Text = "Book Type  Master"
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
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.LblSuffix, 0)
        Me.Controls.SetChildIndex(Me.TxtSuffix, 0)
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
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label


#End Region

    Private Sub FrmBookType_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtDescription, "Description") Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1MemberType).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1MemberType).Index) Then passed = False : Exit Sub

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Lib_BookType Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Book Type Already Exists") : passed = False : Exit Sub

            mQry = "Select count(*) From Lib_BookType_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Book Type Already Exists in Log File") : passed = False : Exit Sub
        Else
            mQry = "Select count(*) From Lib_BookType Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & " and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Book Type Already Exists") : passed = False : Exit Sub

            mQry = "Select count(*) From Lib_BookType_Log Where Description='" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Book Type Already Exists in Log File") : passed = False : Exit Sub
        End If
    End Sub

    Private Sub FrmBookType_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        AgL.PubFindQry = "SELECT UID, Description [Book Type],Suffix" & _
                        " FROM Lib_BookType_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Book Type]"
    End Sub

    Private Sub FrmMemberType_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        AgL.PubFindQry = "SELECT Code, Description [Book Type],Suffix " & _
                        " FROM Lib_BookType " & mConStr & _
                        " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Book Type]"
    End Sub

    Private Sub FrmMemberType_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_BookType"
        LogTableName = "Lib_BookType_LOG"
        MainLineTableCsv = "Lib_BookTypeDetail"
        LogLineTableCsv = "Lib_BookTypeDetail_LOG"
        AgL.GridDesign(Dgl1)

    End Sub

    Private Sub FrmMemberType_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        mQry = "Update Lib_BookType_LOG " & _
                "   SET  " & _
                "	Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                "	Suffix = " & AgL.Chk_Text(TxtSuffix.Text) & ", " & _
                "   Site_Code = '" & AgL.PubSiteCode & "' " & _
                "   Where UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Delete From Lib_BookTypeDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1MemberType, I).Value <> "" Then
                mSr += 1
                mQry = " INSERT INTO Lib_BookTypeDetail_Log	(	Code,	Sr,	MemberType,	Issuance,	Days,	FinePerDay,	UID	) " & _
                        " VALUES 	( " & AgL.Chk_Text(mInternalCode) & "," & mSr & "," & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1MemberType, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Issuance, I).Value) & "," & Val(Dgl1.Item(Col1Days, I).Value) & ",	" & Val(Dgl1.Item(Col1FinePerDay, I).Value) & ",	" & AgL.Chk_Text(mSearchCode) & "	) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next

    End Sub

    Private Sub FrmBookType_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Description As Name , Div_Code,IsNull( IsDeleted,0) as IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
            " From Lib_BookType " & _
            " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " " & _
            " Order By Description"
        TxtDescription.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT MT.Code, MT.Description, MT.BooksAllowed,MT.Div_Code,IsNull(MT.IsDeleted ,0) AS IsDeleted, ISNULL(MT.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
                " FROM Lib_MemberType MT " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        Dgl1.AgHelpDataSet(Col1MemberType, 4) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT '" & Issuance_NotAllowed & "' AS Code,'" & Issuance_NotAllowed & "' AS Issuance " & _
                " UNION ALL " & _
                " SELECT '" & Issuance_DayIssue & "' AS Code,'" & Issuance_DayIssue & "' AS Issuance " & _
                " UNION ALL " & _
                " SELECT '" & Issuance_NightIssue & "' AS Code,'" & Issuance_NightIssue & "' AS Issuance "
        Dgl1.AgHelpDataSet(Col1Issuance, 0) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  "
        mQry = "Select Code As SearchCode " & _
            " From Lib_BookType " & mConStr & _
            " And IsNull(IsDeleted,0)=0 Order By Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  "
        mQry = "Select UID As SearchCode " & _
               " From Lib_BookType_log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' Order By Description"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmBookType_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1MemberType, 150, 0, Col1MemberType, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Issuance, 120, 0, Col1Issuance, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1Days, 80, 3, 0, False, Col1Days, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1FinePerDay, 80, 5, 2, False, Col1FinePerDay, True, False, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Pnl1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AllowUserToAddRows = False
        Ini_List()
    End Sub

    Private Sub FrmMemberType_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From Lib_BookType Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From Lib_BookType_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtSuffix.Text = AgL.XNull(.Rows(0)("Suffix"))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = " SELECT MT.Code AS MemberType ,MT.Description,V1.Issuance,isnull(V1.Days,0) AS Days,isnull(V1.FinePerDay,0) AS FinePerDay,V1.UID,V1.Sr   " & _
                            " FROM Lib_MemberType MT " & _
                            " LEFT JOIN ( " & _
                            " SELECT BT.Sr,BT.MemberType ,BT.Issuance,BT.Days,BT.FinePerDay,BT.UID  " & _
                            " FROM Lib_BookTypeDetail  BT WHERE BT.Code='" & SearchCode & "' " & _
                            " ) V1 ON V1.MemberType=MT.Code " & _
                            " WHERE isnull(MT.IsDeleted,0) = 0 AND isnull(MT.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')= '" & AgTemplate.ClsMain.EntryStatus.Active & "' and " & AgL.PubSiteCondition("MT.Site_Code", AgL.PubSiteCode) & "  " & _
                            " Order By V1.Sr "
                Else

                    mQry = " SELECT MT.Code AS MemberType,MT.Description,V1.Issuance,isnull(V1.Days,0) AS Days,isnull(V1.FinePerDay,0) AS FinePerDay,V1.UID,V1.Sr " & _
                            " FROM Lib_MemberType MT " & _
                            " LEFT JOIN ( " & _
                            " SELECT BT.Sr,BT.MemberType ,BT.Issuance,BT.Days,BT.FinePerDay,BT.UID    " & _
                            " FROM Lib_BookTypeDetail_Log   BT WHERE BT.UID ='" & SearchCode & "' " & _
                            " ) V1 ON V1.MemberType=MT.Code " & _
                            " WHERE isnull(MT.IsDeleted,0) = 0 AND isnull(MT.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')= '" & AgTemplate.ClsMain.EntryStatus.Active & "' and " & AgL.PubSiteCondition("MT.Site_Code", AgL.PubSiteCode) & " " & _
                            " Order By V1.Sr "

                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                            Dgl1.AgSelectedValue(Col1MemberType, I) = AgL.XNull(.Rows(I)("MemberType"))
                            Dgl1.Item(Col1Issuance, I).Value = AgL.XNull(.Rows(I)("Issuance"))
                            Dgl1.Item(Col1Days, I).Value = AgL.VNull(.Rows(I)("Days"))
                            Dgl1.Item(Col1FinePerDay, I).Value = AgL.XNull(.Rows(I)("FinePerDay"))

                        Next I
                    End If
                End With

            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtDescription.Focus()
        ProcFillMemberType()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmDepartment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 400, 870, 0, 0)
        AgL.GridDesign(Dgl1)
        Topctrl1.ChangeAgGridState(Dgl1, False)
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

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1MemberType
                Dgl1.AgRowFilter(Dgl1.Columns(Col1MemberType).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

        End Select
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

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub ProcFillMemberType()
        Dim DtTemp As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then Exit Sub

            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
            mQry = " SELECT MT.Code AS MemberType  FROM Lib_MemberType MT " & _
                    " WHERE isnull(MT.IsDeleted,0)=0 " & _
                    " AND isnull(MT.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' and " & AgL.PubSiteCondition("MT.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY MT.Description "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                        Dgl1.AgSelectedValue(Col1MemberType, I) = AgL.XNull(.Rows(I)("MemberType"))
                    Next I
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub
End Class
