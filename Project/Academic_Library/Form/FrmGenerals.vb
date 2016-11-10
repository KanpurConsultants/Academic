Public Class FrmGenerals
    Inherits AgTemplate.TempItem

    Protected WithEvents LblSubject As System.Windows.Forms.Label
    Protected WithEvents TxtLanguage As AgControls.AgTextBox
    Protected WithEvents LblLanguage As System.Windows.Forms.Label
    Protected WithEvents TxtRecurrance As AgControls.AgTextBox
    Protected WithEvents LblRecurrance As System.Windows.Forms.Label
    Protected WithEvents TxtReminder As AgControls.AgTextBox
    Protected WithEvents LblReminder As System.Windows.Forms.Label
    Protected WithEvents TxtAlmira As AgControls.AgTextBox
    Protected WithEvents LblAlmira As System.Windows.Forms.Label
    Protected WithEvents TxtShelf As AgControls.AgTextBox
    Protected WithEvents LblShelf As System.Windows.Forms.Label
    Protected WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtScrapCategory As AgControls.AgTextBox
    Protected WithEvents LblScrapCategory As System.Windows.Forms.Label
    Dim mQry$ = ""


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtSubject, LblSubject.Text) Then passed = False : Exit Sub

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Item Where ManualCode ='" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exist!") : passed = False : Exit Sub

            mQry = "Select count(*) From Item_Log Where ManualCode = '" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exists in Log File") : passed = False : Exit Sub
        Else
            mQry = "Select count(*) From Item Where ManualCode ='" & TxtManualCode.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exist!") : passed = False : Exit Sub

            mQry = "Select count(*) From Item_Log Where ManualCode = '" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exists in Log File") : passed = False : Exit Sub
        End If
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Generals & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.UID, I.ManualCode as [Item Code], I.Description [Item Description], " & _
                        " I.Unit , S.Description AS Subject,G.Language,G.Recurrance  " & _
                        " FROM Item_Log I " & _
                        " LEFT JOIN Lib_Generals_Log G ON G.UID=I.UID " & _
                        " LEFT JOIN Lib_Subject S ON S.Code=G.Subject  " & mConStr & _
                        " And I.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Item Description]"
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Generals & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.Code, I.ManualCode as [Item Code], I.Description [Item Description], " & _
                        " I.Unit, S.Description AS Subject,G.Language,G.Recurrance  " & _
                        " FROM Item I " & _
                        " LEFT JOIN Lib_Generals G ON G.Code=I.Code " & _
                        " LEFT JOIN Lib_Subject S ON S.Code=G.Subject  " & mConStr & _
                        " And IsNull(I.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Item Description]"
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Generals & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.Code As SearchCode " & _
            " From Item I " & mConStr & _
            " And IsNull(I.IsDeleted,0)=0 Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Generals & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.UID As SearchCode " & _
               " From Item_log I " & mConStr & _
               " And I.EntryStatus='" & LogStatus.LogOpen & "' Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE Item_Log " & _
                " SET " & _
                " ItemType = " & AgL.Chk_Text(ClsMain.ItemType.Generals) & ", " & _
                " Godown = " & AgL.Chk_Text(TxtAlmira.AgSelectedValue) & " , " & _
                " GodownSection = " & AgL.Chk_Text(TxtShelf.Text) & "  " & _
                " Where UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        If Topctrl1.Mode = "Add" Then
            mQry = " INSERT INTO Lib_Generals_Log (Code,	Subject, Language, ScrapCategory, Recurrance, Reminder,	UID	) " & _
                    " VALUES 	('" & mInternalCode & "'," & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "," & AgL.Chk_Text(TxtLanguage.Text) & "," & AgL.Chk_Text(TxtScrapCategory.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtRecurrance.Text) & ",	" & IIf(TxtReminder.Text = "Yes", 1, 0) & ",	'" & SearchCode & "'	)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        Else
            mQry = " UPDATE Lib_Generals_Log " & _
                    " SET Code = '" & mInternalCode & "' , " & _
                    " Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                    " ScrapCategory = " & AgL.Chk_Text(TxtScrapCategory.AgSelectedValue) & ", " & _
                    " Language = " & AgL.Chk_Text(TxtLanguage.Text) & ", " & _
                    " Recurrance = " & AgL.Chk_Text(TxtRecurrance.Text) & ", " & _
                    " Reminder = " & IIf(TxtReminder.Text = "Yes", 1, 0) & " " & _
                    " WHERE UID = '" & SearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        End If

    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmDesignConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 382, 870, 0, 0)
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        Dgl1.Visible = False
        TxtUnit.Enabled = False
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtLanguage = New AgControls.AgTextBox
        Me.LblLanguage = New System.Windows.Forms.Label
        Me.TxtRecurrance = New AgControls.AgTextBox
        Me.LblRecurrance = New System.Windows.Forms.Label
        Me.TxtReminder = New AgControls.AgTextBox
        Me.LblReminder = New System.Windows.Forms.Label
        Me.TxtAlmira = New AgControls.AgTextBox
        Me.LblAlmira = New System.Windows.Forms.Label
        Me.TxtShelf = New AgControls.AgTextBox
        Me.LblShelf = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.TxtScrapCategory = New AgControls.AgTextBox
        Me.LblScrapCategory = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblDescription
        '
        Me.LblDescription.Location = New System.Drawing.Point(170, 109)
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(296, 108)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(279, 116)
        '
        'TxtUnit
        '
        Me.TxtUnit.Location = New System.Drawing.Point(548, 128)
        Me.TxtUnit.Size = New System.Drawing.Size(132, 18)
        Me.TxtUnit.TabIndex = 3
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(279, 96)
        '
        'TxtManualCode
        '
        Me.TxtManualCode.Location = New System.Drawing.Point(296, 88)
        Me.TxtManualCode.Size = New System.Drawing.Size(135, 18)
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(170, 89)
        '
        'TxtUPCCode
        '
        Me.TxtUPCCode.Location = New System.Drawing.Point(104, 122)
        Me.TxtUPCCode.Size = New System.Drawing.Size(53, 18)
        Me.TxtUPCCode.Visible = False
        '
        'LblUPCCode
        '
        Me.LblUPCCode.Location = New System.Drawing.Point(-9, 125)
        Me.LblUPCCode.Visible = False
        '
        'TxtSalesTaxPostingGroup
        '
        Me.TxtSalesTaxPostingGroup.Location = New System.Drawing.Point(113, 82)
        Me.TxtSalesTaxPostingGroup.Size = New System.Drawing.Size(34, 18)
        Me.TxtSalesTaxPostingGroup.Visible = False
        '
        'LblSalesTaxPostingGroup
        '
        Me.LblSalesTaxPostingGroup.Location = New System.Drawing.Point(0, 83)
        Me.LblSalesTaxPostingGroup.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(38, 241)
        Me.Pnl1.Size = New System.Drawing.Size(97, 53)
        '
        'LblUnit
        '
        Me.LblUnit.Location = New System.Drawing.Point(440, 128)
        '
        'TxtItemGroup
        '
        Me.TxtItemGroup.Location = New System.Drawing.Point(296, 128)
        Me.TxtItemGroup.MaxLength = 50
        Me.TxtItemGroup.Size = New System.Drawing.Size(135, 18)
        Me.TxtItemGroup.TabIndex = 2
        Me.TxtItemGroup.Visible = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(170, 129)
        Me.Label2.Visible = True
        '
        'TxtExciseGroup
        '
        Me.TxtExciseGroup.Location = New System.Drawing.Point(104, 62)
        Me.TxtExciseGroup.Size = New System.Drawing.Size(31, 18)
        '
        'LblExciseGroup
        '
        Me.LblExciseGroup.Location = New System.Drawing.Point(11, 62)
        '
        'TxtEntryTaxGroup
        '
        Me.TxtEntryTaxGroup.Location = New System.Drawing.Point(113, 102)
        Me.TxtEntryTaxGroup.Size = New System.Drawing.Size(44, 18)
        '
        'LblEntryTaxGroup
        '
        Me.LblEntryTaxGroup.Location = New System.Drawing.Point(0, 103)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 334)
        Me.GroupBox1.Size = New System.Drawing.Size(862, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 344)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(148, 344)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(554, 344)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(401, 344)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(704, 344)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(278, 344)
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = True
        Me.TxtSubject.AgMasterHelp = False
        Me.TxtSubject.AgNumberLeftPlaces = 8
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 2
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubject.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(296, 148)
        Me.TxtSubject.MaxLength = 10
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(385, 18)
        Me.TxtSubject.TabIndex = 4
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(170, 149)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(52, 16)
        Me.LblSubject.TabIndex = 871
        Me.LblSubject.Text = "Subject"
        '
        'TxtLanguage
        '
        Me.TxtLanguage.AgMandatory = False
        Me.TxtLanguage.AgMasterHelp = True
        Me.TxtLanguage.AgNumberLeftPlaces = 8
        Me.TxtLanguage.AgNumberNegetiveAllow = False
        Me.TxtLanguage.AgNumberRightPlaces = 2
        Me.TxtLanguage.AgPickFromLastValue = False
        Me.TxtLanguage.AgRowFilter = ""
        Me.TxtLanguage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLanguage.AgSelectedValue = Nothing
        Me.TxtLanguage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLanguage.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLanguage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLanguage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLanguage.Location = New System.Drawing.Point(296, 188)
        Me.TxtLanguage.MaxLength = 50
        Me.TxtLanguage.Name = "TxtLanguage"
        Me.TxtLanguage.Size = New System.Drawing.Size(132, 18)
        Me.TxtLanguage.TabIndex = 6
        '
        'LblLanguage
        '
        Me.LblLanguage.AutoSize = True
        Me.LblLanguage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLanguage.Location = New System.Drawing.Point(170, 189)
        Me.LblLanguage.Name = "LblLanguage"
        Me.LblLanguage.Size = New System.Drawing.Size(64, 16)
        Me.LblLanguage.TabIndex = 875
        Me.LblLanguage.Text = "Language"
        '
        'TxtRecurrance
        '
        Me.TxtRecurrance.AgMandatory = False
        Me.TxtRecurrance.AgMasterHelp = False
        Me.TxtRecurrance.AgNumberLeftPlaces = 8
        Me.TxtRecurrance.AgNumberNegetiveAllow = False
        Me.TxtRecurrance.AgNumberRightPlaces = 2
        Me.TxtRecurrance.AgPickFromLastValue = False
        Me.TxtRecurrance.AgRowFilter = ""
        Me.TxtRecurrance.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRecurrance.AgSelectedValue = Nothing
        Me.TxtRecurrance.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRecurrance.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRecurrance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRecurrance.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecurrance.Location = New System.Drawing.Point(548, 188)
        Me.TxtRecurrance.MaxLength = 20
        Me.TxtRecurrance.Name = "TxtRecurrance"
        Me.TxtRecurrance.Size = New System.Drawing.Size(132, 18)
        Me.TxtRecurrance.TabIndex = 7
        '
        'LblRecurrance
        '
        Me.LblRecurrance.AutoSize = True
        Me.LblRecurrance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecurrance.Location = New System.Drawing.Point(440, 188)
        Me.LblRecurrance.Name = "LblRecurrance"
        Me.LblRecurrance.Size = New System.Drawing.Size(74, 16)
        Me.LblRecurrance.TabIndex = 877
        Me.LblRecurrance.Text = "Recurrance"
        '
        'TxtReminder
        '
        Me.TxtReminder.AgMandatory = False
        Me.TxtReminder.AgMasterHelp = True
        Me.TxtReminder.AgNumberLeftPlaces = 8
        Me.TxtReminder.AgNumberNegetiveAllow = False
        Me.TxtReminder.AgNumberRightPlaces = 2
        Me.TxtReminder.AgPickFromLastValue = False
        Me.TxtReminder.AgRowFilter = ""
        Me.TxtReminder.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReminder.AgSelectedValue = Nothing
        Me.TxtReminder.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReminder.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtReminder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReminder.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReminder.Location = New System.Drawing.Point(296, 208)
        Me.TxtReminder.MaxLength = 100
        Me.TxtReminder.Name = "TxtReminder"
        Me.TxtReminder.Size = New System.Drawing.Size(132, 18)
        Me.TxtReminder.TabIndex = 8
        '
        'LblReminder
        '
        Me.LblReminder.AutoSize = True
        Me.LblReminder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReminder.Location = New System.Drawing.Point(170, 209)
        Me.LblReminder.Name = "LblReminder"
        Me.LblReminder.Size = New System.Drawing.Size(63, 16)
        Me.LblReminder.TabIndex = 888
        Me.LblReminder.Text = "Reminder"
        '
        'TxtAlmira
        '
        Me.TxtAlmira.AgMandatory = False
        Me.TxtAlmira.AgMasterHelp = False
        Me.TxtAlmira.AgNumberLeftPlaces = 0
        Me.TxtAlmira.AgNumberNegetiveAllow = False
        Me.TxtAlmira.AgNumberRightPlaces = 0
        Me.TxtAlmira.AgPickFromLastValue = False
        Me.TxtAlmira.AgRowFilter = ""
        Me.TxtAlmira.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAlmira.AgSelectedValue = Nothing
        Me.TxtAlmira.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAlmira.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAlmira.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAlmira.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlmira.Location = New System.Drawing.Point(296, 228)
        Me.TxtAlmira.MaxLength = 20
        Me.TxtAlmira.Name = "TxtAlmira"
        Me.TxtAlmira.Size = New System.Drawing.Size(132, 18)
        Me.TxtAlmira.TabIndex = 9
        '
        'LblAlmira
        '
        Me.LblAlmira.AutoSize = True
        Me.LblAlmira.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlmira.Location = New System.Drawing.Point(170, 229)
        Me.LblAlmira.Name = "LblAlmira"
        Me.LblAlmira.Size = New System.Drawing.Size(45, 16)
        Me.LblAlmira.TabIndex = 894
        Me.LblAlmira.Text = "Almira"
        '
        'TxtShelf
        '
        Me.TxtShelf.AgMandatory = False
        Me.TxtShelf.AgMasterHelp = False
        Me.TxtShelf.AgNumberLeftPlaces = 8
        Me.TxtShelf.AgNumberNegetiveAllow = False
        Me.TxtShelf.AgNumberRightPlaces = 2
        Me.TxtShelf.AgPickFromLastValue = False
        Me.TxtShelf.AgRowFilter = ""
        Me.TxtShelf.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShelf.AgSelectedValue = Nothing
        Me.TxtShelf.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShelf.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShelf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShelf.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShelf.Location = New System.Drawing.Point(548, 228)
        Me.TxtShelf.MaxLength = 100
        Me.TxtShelf.Name = "TxtShelf"
        Me.TxtShelf.Size = New System.Drawing.Size(132, 18)
        Me.TxtShelf.TabIndex = 10
        '
        'LblShelf
        '
        Me.LblShelf.AutoSize = True
        Me.LblShelf.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShelf.Location = New System.Drawing.Point(440, 228)
        Me.LblShelf.Name = "LblShelf"
        Me.LblShelf.Size = New System.Drawing.Size(37, 16)
        Me.LblShelf.TabIndex = 893
        Me.LblShelf.Text = "Shelf"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(279, 156)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 895
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'TxtScrapCategory
        '
        Me.TxtScrapCategory.AgMandatory = False
        Me.TxtScrapCategory.AgMasterHelp = False
        Me.TxtScrapCategory.AgNumberLeftPlaces = 0
        Me.TxtScrapCategory.AgNumberNegetiveAllow = False
        Me.TxtScrapCategory.AgNumberRightPlaces = 0
        Me.TxtScrapCategory.AgPickFromLastValue = False
        Me.TxtScrapCategory.AgRowFilter = ""
        Me.TxtScrapCategory.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtScrapCategory.AgSelectedValue = Nothing
        Me.TxtScrapCategory.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtScrapCategory.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtScrapCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtScrapCategory.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScrapCategory.Location = New System.Drawing.Point(296, 168)
        Me.TxtScrapCategory.MaxLength = 20
        Me.TxtScrapCategory.Name = "TxtScrapCategory"
        Me.TxtScrapCategory.Size = New System.Drawing.Size(385, 18)
        Me.TxtScrapCategory.TabIndex = 5
        '
        'LblScrapCategory
        '
        Me.LblScrapCategory.AutoSize = True
        Me.LblScrapCategory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScrapCategory.Location = New System.Drawing.Point(170, 169)
        Me.LblScrapCategory.Name = "LblScrapCategory"
        Me.LblScrapCategory.Size = New System.Drawing.Size(98, 16)
        Me.LblScrapCategory.TabIndex = 900
        Me.LblScrapCategory.Text = "Scrap Category"
        '
        'FrmGenerals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 391)
        Me.Controls.Add(Me.TxtScrapCategory)
        Me.Controls.Add(Me.LblScrapCategory)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtAlmira)
        Me.Controls.Add(Me.LblAlmira)
        Me.Controls.Add(Me.TxtShelf)
        Me.Controls.Add(Me.LblShelf)
        Me.Controls.Add(Me.TxtReminder)
        Me.Controls.Add(Me.LblReminder)
        Me.Controls.Add(Me.TxtRecurrance)
        Me.Controls.Add(Me.LblRecurrance)
        Me.Controls.Add(Me.TxtLanguage)
        Me.Controls.Add(Me.LblLanguage)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.LogLineTableCsv = "ItemBuyer_Log"
        Me.LogTableName = "Item_LOG"
        Me.MainLineTableCsv = "ItemBuyer"
        Me.MainTableName = "Item"
        Me.Name = "FrmGenerals"
        Me.Text = "Other Material Master"
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
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
        Me.Controls.SetChildIndex(Me.LblUnit, 0)
        Me.Controls.SetChildIndex(Me.TxtUnit, 0)
        Me.Controls.SetChildIndex(Me.LblManualCode, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblManualCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblUPCCode, 0)
        Me.Controls.SetChildIndex(Me.TxtUPCCode, 0)
        Me.Controls.SetChildIndex(Me.LblSalesTaxPostingGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtSalesTaxPostingGroup, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtItemGroup, 0)
        Me.Controls.SetChildIndex(Me.LblExciseGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtExciseGroup, 0)
        Me.Controls.SetChildIndex(Me.LblEntryTaxGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtEntryTaxGroup, 0)
        Me.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.Controls.SetChildIndex(Me.LblLanguage, 0)
        Me.Controls.SetChildIndex(Me.TxtLanguage, 0)
        Me.Controls.SetChildIndex(Me.LblRecurrance, 0)
        Me.Controls.SetChildIndex(Me.TxtRecurrance, 0)
        Me.Controls.SetChildIndex(Me.LblReminder, 0)
        Me.Controls.SetChildIndex(Me.TxtReminder, 0)
        Me.Controls.SetChildIndex(Me.LblShelf, 0)
        Me.Controls.SetChildIndex(Me.TxtShelf, 0)
        Me.Controls.SetChildIndex(Me.LblAlmira, 0)
        Me.Controls.SetChildIndex(Me.TxtAlmira, 0)
        Me.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblScrapCategory, 0)
        Me.Controls.SetChildIndex(Me.TxtScrapCategory, 0)
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
#End Region

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    TxtDescription.Enter, TxtManualCode.Enter, TxtShelf.Enter, TxtAlmira.Enter, TxtSubject.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name
                    sender.AgRowFilter = " ItemType =  '" & ClsMain.ItemType.Generals & "' And " & ClsMain.RetDivFilterStr & "  "

                Case TxtSubject.Name, TxtAlmira.Name, TxtScrapCategory.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""

                Case TxtShelf.Name
                    If TxtAlmira.AgSelectedValue <> "" Then
                        sender.AgRowFilter = " GodownCode = " & AgL.Chk_Text(TxtAlmira.AgSelectedValue) & " "
                    End If

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = " SELECT G.* ,I.Godown ,I.GodownSection " & _
                    " FROM Lib_Generals G " & _
                    " LEFT JOIN Item I ON I.Code =G.Code  " & _
                    " Where G.Code='" & SearchCode & "' "
        Else
            mQry = " SELECT G.* ,I.Godown ,I.GodownSection " & _
                    " FROM Lib_Generals_Log G " & _
                    " LEFT JOIN Item_Log I ON I.UID =G.UID " & _
                    " Where G.UID='" & SearchCode & "' "
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtSubject.AgSelectedValue = AgL.XNull(.Rows(0)("Subject"))
                TxtScrapCategory.AgSelectedValue = AgL.XNull(.Rows(0)("ScrapCategory"))
                TxtLanguage.Text = AgL.XNull(.Rows(0)("Language"))
                TxtRecurrance.Text = AgL.XNull(.Rows(0)("Recurrance"))
                TxtReminder.Text = IIf(AgL.VNull(.Rows(0)("Reminder")) = 0, "No", "Yes")
                TxtAlmira.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                TxtShelf.Text = AgL.XNull(.Rows(0)("GodownSection"))
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub FrmGenerals_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT S.Code,S.Description AS Subject,S.Prefix,S.Div_Code,IsNull( S.IsDeleted,0) as IsDeleted, " & _
            " ISNULL(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
            " FROM Lib_Subject S " & _
            " Order By S.Description"
        TxtSubject.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT B.Language AS Code,B.Language  FROM Lib_Generals B " & _
                " WHERE B.Language IS NOT NULL"
        TxtLanguage.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT '" & ClsMain.Recurrance.Daily & "' AS Code ,'" & ClsMain.Recurrance.Daily & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Weekly & "' AS Code ,'" & ClsMain.Recurrance.Weekly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Fortnightly & "' AS Code ,'" & ClsMain.Recurrance.Fortnightly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Monthly & "' AS Code ,'" & ClsMain.Recurrance.Monthly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Bimonthly & "' AS Code ,'" & ClsMain.Recurrance.Bimonthly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Quarterly & "' AS Code ,'" & ClsMain.Recurrance.Quarterly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.HalfYearly & "' AS Code ,'" & ClsMain.Recurrance.HalfYearly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Annually & "' AS Code ,'" & ClsMain.Recurrance.Annually & "' AS Recurrance " 
        TxtRecurrance.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT BT.Code,BT.Description AS [Book Type], " & _
               " isnull(BT.IsDeleted,0) AS IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,BT.Div_Code " & _
               " FROM Lib_ScrapCategory BT "
        TxtScrapCategory.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT G.Code ,G.Description AS Godown,G.Div_Code,IsNull( G.IsDeleted,0) as IsDeleted, " & _
                " ISNULL(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
                " FROM Godown G " & _
                " Order By G.Description"
        TxtAlmira.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Section AS Code , Section , Code AS GodownCode  FROM GodownSection "
        TxtShelf.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmGenerals_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainLineTableCsv = "Lib_Generals"
        LogLineTableCsv = "Lib_Generals_Log"
    End Sub

    Private Sub FrmGenerals_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        If DtLib_Enviro.Rows.Count > 0 Then
            TxtUnit.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultUnit"))
            TxtLanguage.Text = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultLanguage"))
        End If
    End Sub
End Class
