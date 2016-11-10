Public Class FrmSubject1
    Inherits AgTemplate.TempMaster
    Dim mQry$
    Protected WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Almira As String = "Almira"
    Protected Const Col1Shelf As String = "Shelf"
    Public WithEvents GBoxImportFromExcel As System.Windows.Forms.GroupBox
    Public WithEvents BtnImprtFromExcel As System.Windows.Forms.Button

    Public mMainStreamCode As String = ""
    Public mBlnImprtFromExcelFlag As Boolean = False

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSubject1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.TxtUnderSubject = New AgControls.AgTextBox
        Me.LblUnderSubject = New System.Windows.Forms.Label
        Me.TxtPrefix = New AgControls.AgTextBox
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.GBoxImportFromExcel = New System.Windows.Forms.GroupBox
        Me.BtnImprtFromExcel = New System.Windows.Forms.Button
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxImportFromExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(862, 41)
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 418)
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 422)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 422)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 422)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 422)
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
        Me.GroupBox2.Location = New System.Drawing.Point(702, 422)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 422)
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
        Me.Label1.Location = New System.Drawing.Point(299, 95)
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
        Me.TxtDescription.Location = New System.Drawing.Point(320, 87)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(345, 18)
        Me.TxtDescription.TabIndex = 665
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(198, 88)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(73, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Description"
        '
        'TxtUnderSubject
        '
        Me.TxtUnderSubject.AgMandatory = False
        Me.TxtUnderSubject.AgMasterHelp = False
        Me.TxtUnderSubject.AgNumberLeftPlaces = 0
        Me.TxtUnderSubject.AgNumberNegetiveAllow = False
        Me.TxtUnderSubject.AgNumberRightPlaces = 0
        Me.TxtUnderSubject.AgPickFromLastValue = False
        Me.TxtUnderSubject.AgRowFilter = ""
        Me.TxtUnderSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUnderSubject.AgSelectedValue = Nothing
        Me.TxtUnderSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUnderSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtUnderSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUnderSubject.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnderSubject.Location = New System.Drawing.Point(320, 107)
        Me.TxtUnderSubject.MaxLength = 50
        Me.TxtUnderSubject.Name = "TxtUnderSubject"
        Me.TxtUnderSubject.Size = New System.Drawing.Size(345, 18)
        Me.TxtUnderSubject.TabIndex = 673
        '
        'LblUnderSubject
        '
        Me.LblUnderSubject.AutoSize = True
        Me.LblUnderSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnderSubject.Location = New System.Drawing.Point(198, 108)
        Me.LblUnderSubject.Name = "LblUnderSubject"
        Me.LblUnderSubject.Size = New System.Drawing.Size(90, 16)
        Me.LblUnderSubject.TabIndex = 672
        Me.LblUnderSubject.Text = "Under Subject"
        '
        'TxtPrefix
        '
        Me.TxtPrefix.AgMandatory = False
        Me.TxtPrefix.AgMasterHelp = True
        Me.TxtPrefix.AgNumberLeftPlaces = 0
        Me.TxtPrefix.AgNumberNegetiveAllow = False
        Me.TxtPrefix.AgNumberRightPlaces = 0
        Me.TxtPrefix.AgPickFromLastValue = False
        Me.TxtPrefix.AgRowFilter = ""
        Me.TxtPrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPrefix.AgSelectedValue = Nothing
        Me.TxtPrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrefix.Location = New System.Drawing.Point(320, 127)
        Me.TxtPrefix.MaxLength = 5
        Me.TxtPrefix.Name = "TxtPrefix"
        Me.TxtPrefix.Size = New System.Drawing.Size(100, 18)
        Me.TxtPrefix.TabIndex = 674
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.Location = New System.Drawing.Point(198, 128)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(41, 16)
        Me.LblPrefix.TabIndex = 675
        Me.LblPrefix.Text = "Prefix"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(201, 177)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(464, 187)
        Me.Pnl1.TabIndex = 676
        '
        'GBoxImportFromExcel
        '
        Me.GBoxImportFromExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxImportFromExcel.BackColor = System.Drawing.Color.Transparent
        Me.GBoxImportFromExcel.Controls.Add(Me.BtnImprtFromExcel)
        Me.GBoxImportFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxImportFromExcel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxImportFromExcel.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxImportFromExcel.Location = New System.Drawing.Point(671, 85)
        Me.GBoxImportFromExcel.Name = "GBoxImportFromExcel"
        Me.GBoxImportFromExcel.Size = New System.Drawing.Size(99, 49)
        Me.GBoxImportFromExcel.TabIndex = 686
        Me.GBoxImportFromExcel.TabStop = False
        Me.GBoxImportFromExcel.Tag = "UP"
        Me.GBoxImportFromExcel.Text = "Import From Excel"
        '
        'BtnImprtFromExcel
        '
        Me.BtnImprtFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprtFromExcel.Image = CType(resources.GetObject("BtnImprtFromExcel.Image"), System.Drawing.Image)
        Me.BtnImprtFromExcel.Location = New System.Drawing.Point(59, 11)
        Me.BtnImprtFromExcel.Name = "BtnImprtFromExcel"
        Me.BtnImprtFromExcel.Size = New System.Drawing.Size(36, 34)
        Me.BtnImprtFromExcel.TabIndex = 669
        Me.BtnImprtFromExcel.TabStop = False
        Me.BtnImprtFromExcel.UseVisualStyleBackColor = True
        '
        'FrmSubject1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 466)
        Me.Controls.Add(Me.GBoxImportFromExcel)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtPrefix)
        Me.Controls.Add(Me.LblPrefix)
        Me.Controls.Add(Me.TxtUnderSubject)
        Me.Controls.Add(Me.LblUnderSubject)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmSubject1"
        Me.Text = "Subject  Master"
        Me.Controls.SetChildIndex(Me.LblDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtDescription, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblUnderSubject, 0)
        Me.Controls.SetChildIndex(Me.TxtUnderSubject, 0)
        Me.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.Controls.SetChildIndex(Me.TxtPrefix, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GBoxImportFromExcel, 0)
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
        Me.GBoxImportFromExcel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents TxtUnderSubject As AgControls.AgTextBox
    Friend WithEvents LblUnderSubject As System.Windows.Forms.Label
    Friend WithEvents TxtPrefix As AgControls.AgTextBox
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label


#End Region

    Private Sub FrmSubject_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtDescription, "Description") Then passed = False : Exit Sub

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Lib_Subject Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Subject Already Exists") : passed = False : Exit Sub

            mQry = "Select count(*) From Lib_Subject_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Subject Already Exists in Log File") : passed = False : Exit Sub

            mMainStreamCode = GetMainStreamCode(TxtUnderSubject.AgSelectedValue)
        Else
            mQry = "Select count(*) From Lib_Subject Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Subject Already Exists") : passed = False : Exit Sub

            mQry = "Select count(*) From Lib_Subject_Log Where Description='" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Subject Already Exists in Log File") : passed = False : Exit Sub
        End If
    End Sub

    Private Sub FrmSubject_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 "
        AgL.PubFindQry = "SELECT SL.UID,SL.Description AS Subject,SL.Prefix, S.Description AS [Under Subject] " & _
                        " FROM Lib_Subject_Log SL " & _
                        " LEFT JOIN Lib_Subject S ON S.Code=SL.UnderSubject  " & mConStr & _
                        " And SL.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Subject]"
    End Sub

    Private Sub FrmSubject_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1  "
        AgL.PubFindQry = " SELECT SL.UID,SL.Description AS Subject,SL.Prefix, S.Description AS [Under Subject] " & _
                        " FROM Lib_Subject SL " & _
                        " LEFT JOIN Lib_Subject S ON S.Code=SL.UnderSubject  " & mConStr & _
                        " And IsNull(SL.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Subject]"
    End Sub

    Private Sub FrmSubject_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_Subject"
        LogTableName = "Lib_Subject_LOG"
        MainLineTableCsv = "Lib_SubjectDetail"
        LogLineTableCsv = "Lib_SubjectDetail_LOG"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmSubject_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        mQry = "Update Lib_Subject_LOG " & _
                "   SET  " & _
                "	Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                "	Prefix = " & AgL.Chk_Text(TxtPrefix.Text) & ", " & _
                "	MsCode = " & AgL.Chk_Text(mMainStreamCode) & ", " & _
                "	UnderSubject = " & AgL.Chk_Text(TxtUnderSubject.AgSelectedValue) & "" & _
                "   Where UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Delete From Lib_SubjectDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Almira, I).Value <> "" Then
                mSr += 1
                mQry = " INSERT INTO Lib_SubjectDetail_Log (	Code, Sr, Godown, GodownSection,UID	) " & _
                        " VALUES ( " & AgL.Chk_Text(mInternalCode) & "," & mSr & ",	" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Almira, I)) & ",	" & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Shelf, I).Value) & ",	" & AgL.Chk_Text(mSearchCode) & "	)"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next

    End Sub

    Private Sub FrmSubject1_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        mMainStreamCode = ""

        mBlnImprtFromExcelFlag = False

    End Sub

    Private Sub FrmSubject1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtUnderSubject.Enabled = False
        End If
    End Sub

    Private Sub FrmSubject_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Description As Name , Div_Code,IsNull( IsDeleted,0) as IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
            " From Lib_Subject " & _
            " Order By Description"
        TxtDescription.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
        TxtUnderSubject.AgHelpDataSet(3) = TxtDescription.AgHelpDataSet.Copy()

        mQry = " SELECT G.Code,G.Description AS Almira,G.Div_Code,IsNull(G.IsDeleted ,0) AS IsDeleted,	IsNull(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
                " FROM Godown G " & _
                 " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " " & _
                " Order By G.Description "
        Dgl1.AgHelpDataSet(Col1Almira, 3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT GS.Section AS Code,GS.Section AS Shelf,GS.Code AS AlmiraCode " & _
                " FROM GodownSection GS " & _
                " ORDER BY GS.Section  "
        Dgl1.AgHelpDataSet(Col1Shelf, 1) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmSubject_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 "
        mQry = "Select Code As SearchCode " & _
            " From Lib_Subject " & mConStr & _
            " And IsNull(IsDeleted,0)=0 Order By Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmMemberType_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1  "
        mQry = "Select UID As SearchCode " & _
               " From Lib_Subject_log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' Order By Description"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSubject1_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Almira, 225, 0, Col1Almira, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Shelf, 125, 0, Col1Shelf, True, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Pnl1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35

        Ini_List()
    End Sub

    Private Sub FrmMemberType_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        Dim I As Integer

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From Lib_Subject Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From Lib_Subject_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtPrefix.Text = AgL.XNull(.Rows(0)("Prefix"))
                mMainStreamCode = AgL.XNull(.Rows(0)("MsCode"))
                TxtUnderSubject.AgSelectedValue = AgL.XNull(.Rows(0)("UnderSubject"))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from Lib_SubjectDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from Lib_SubjectDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Almira, I) = AgL.XNull(.Rows(I)("Godown"))
                            Dgl1.Item(Col1Shelf, I).Value = AgL.XNull(.Rows(I)("GodownSection"))
                        Next I
                    End If
                End With

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
        AgL.WinSetting(Me, 500, 870, 0, 0)
        AgL.GridDesign(Dgl1)
        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtDescription.Enter, TxtUnderSubject.Enter
        Try
            Select Case sender.name
                Case TxtDescription.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  " & ClsMain.RetDivFilterStr & ""

                Case TxtUnderSubject.Name
                    sender.AgRowFilter = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' And Name <> '" & TxtDescription.Text & "'"

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Almira
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Almira).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

                Case Col1Shelf
                    If Dgl1.Item(Col1Almira, mRowIndex).Value Is Nothing Then Dgl1.Item(Col1Almira, mRowIndex).Value = ""
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Shelf).Index) = " AlmiraCode = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Almira, mRowIndex)) & "  "
            End Select

        Catch ex As Exception

        End Try

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
                'Case Col1Item
                '    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
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

    Private Function GetMainStreamCode(Optional ByVal mParentSubject As String = "") As String
        Dim PubIniMainStreamCode$ = "001"
        Dim TmMainStreamCode As String = "", mParentMainStreamCode As String = ""
        Dim DsTemp As DataSet
        Dim I As Integer = 0, J As Integer = 0

        Try
            If DTMaster.Rows.Count = 0 Then
                TmMainStreamCode = PubIniMainStreamCode
            Else
                If mParentSubject = "" Then
                    TmMainStreamCode = ""
                    mQry = "Select IsNull(Max(Convert(VarChar,MSCode)),0)+1 From Lib_Subject where Len(MSCode)<=5"
                    TmMainStreamCode = Format(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar, "000")
                    'AgL.ECmd = AgL.Dman_Execute("Select Convert(Numeric,Right(MsCode,3))  From Lib_Subject Where UnderSubject Is Null ", AgL.GCn)
                    'TmMainStreamCode = AgL.XNull(AgL.ECmd.ExecuteScalar())
                    'TmMainStreamCode = TmMainStreamCode + "001"
                Else
                    AgL.ECmd = AgL.Dman_Execute("Select MsCode From Lib_Subject Where Code = '" & mParentSubject & "' ", AgL.GCn)
                    mParentMainStreamCode = AgL.XNull(AgL.ECmd.ExecuteScalar())
                    If mParentMainStreamCode.Trim <> "" Then
                        mQry = "Select Convert(Numeric,Right(MsCode,3)) As Cnt From Lib_Subject " & _
                                " Where Left(MsCode," & mParentMainStreamCode.Length & ")='" & mParentMainStreamCode & "' " & _
                                " And Len(MsCode)=" & mParentMainStreamCode.Length + 3 & " " & _
                                " Order By Convert(Numeric,Right(MsCode,3)) "
                        DsTemp = AgL.FillData(mQry, AgL.GCn)

                        With DsTemp.Tables(0)
                            If .Rows.Count = 0 Then
                                TmMainStreamCode = mParentMainStreamCode + "001"
                            ElseIf .Rows.Count = 999 Then
                                TmMainStreamCode = ""
                            Else
                                For I = 0 To .Rows.Count - 1
                                    J = I + 1
                                    If J <> .Rows(I)("Cnt") Then
                                        TmMainStreamCode = mParentMainStreamCode + J.ToString.PadLeft(3, "0")
                                        Exit For
                                    Else
                                        If TmMainStreamCode.Trim = "" And I = .Rows.Count - 1 Then
                                            J = J + 1
                                            TmMainStreamCode = mParentMainStreamCode + J.ToString.PadLeft(3, "0")
                                        End If
                                    End If
                                Next
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            TmMainStreamCode = ""
        Finally
            DsTemp = Nothing
            GetMainStreamCode = TmMainStreamCode
        End Try
    End Function

    

    Private Sub BtnImprtFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromExcel.Click
        If 1 = 1 Then
            Call ProcImportFromExcelAccessationFile()
        Else
            Call ProcImportFromExcelSubjectFile()
        End If
    End Sub

    Private Sub ProcImportFromExcelSubjectFile()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        Dim DrTemp As DataRow() = Nothing


        mQry = "                  Select '' as Srl, 'Description' as [Field Name],'Text' as [Data Type], 100 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Under Subject' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Prefix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "


        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportFromExcel
        ObjFrmImport.LblTitle.Text = "Subject Import"
        ObjFrmImport.Dgl1.DataSource = DtTemp
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub

        DtTemp = ObjFrmImport.P_DsExcelData.Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            Topctrl1.FButtonClick(0)

            mBlnImprtFromExcelFlag = True

            TxtDescription.Text = AgL.XNull(DtTemp.Rows(I)("Description"))
            TxtPrefix.Text = AgL.XNull(DtTemp.Rows(I)("Prefix"))

            If AgL.XNull(DtTemp.Rows(I)("Under Subject")).ToString.Trim <> "" Then
                DrTemp = TxtUnderSubject.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Under Subject"))) & "")
                If DrTemp.Length > 0 Then
                    TxtUnderSubject.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If

            ''===========< Finally >==============
            Topctrl1.FButtonClick(13)
            ''===========< ******* >==============
        Next
        If StrErrLog <> "" Then
            MsgBox(StrErrLog)
        Else
            MsgBox("Import Process Completed.", MsgBoxStyle.Information, Me.Text)
        End If


        FW.Close()

        mBlnImprtFromExcelFlag = False

        ''======< At Last Move To Browse Mode >=======
        Topctrl1.FButtonClick(14, True)
    End Sub

    Private Sub ProcImportFromExcelAccessationFile()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        Dim DrTemp As DataRow() = Nothing


        mQry = "                  Select '' as Srl, 'Accessation Date' as [Field Name],'DATETIME' as [Data Type], 0 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No Prefix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No Sufix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No Sr' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id Prefix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id Sufix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id Sr' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Name' as [Field Name],'Text' as [Data Type], 255 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Subject' as [Field Name],'Text' as [Data Type], 100 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Type' as [Field Name],'Text' as [Data Type], 50 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Series' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Volume' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'ISBN' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Language' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Writer' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Publisher' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Publication Year' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Pages' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'MRP' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Rate' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Call No' as [Field Name],'Text' as [Data Type], 35 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Place' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Almira' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Shelf' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "


        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportSubjectFromExcel
        ObjFrmImport.LblTitle.Text = "Subject Import"

        Dim ObjStructSubject As New FrmImportSubjectFromExcel.StructSubject()
        With ObjStructSubject
            .ProcBlankStruct()
            .StrSubject = "Subject"
        End With

        ObjFrmImport.ObjStructSubject = ObjStructSubject
        ObjFrmImport.Dgl1.DataSource = DtTemp
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub

        DtTemp = ObjFrmImport.P_DsExcelData.Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            Topctrl1.FButtonClick(0)

            mBlnImprtFromExcelFlag = True

            TxtDescription.Text = AgL.XNull(DtTemp.Rows(I)("Subject"))

            ''===========< Finally >==============
            Topctrl1.FButtonClick(13)
            ''===========< ******* >==============
        Next
        If StrErrLog <> "" Then
            MsgBox(StrErrLog)
        Else
            MsgBox("Import Process Completed.", MsgBoxStyle.Information, Me.Text)
        End If


        FW.Close()

        mBlnImprtFromExcelFlag = False

        ''======< At Last Move To Browse Mode >=======
        Topctrl1.FButtonClick(14, True)
    End Sub
End Class
