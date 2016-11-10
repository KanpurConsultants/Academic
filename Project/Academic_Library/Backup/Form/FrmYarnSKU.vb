Public Class FrmYarnSKU
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
        Me.TxtShade = New AgControls.AgTextBox
        Me.LblShade = New System.Windows.Forms.Label
        Me.TxtYarn = New AgControls.AgTextBox
        Me.LblYarn = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.TxtUnit = New AgControls.AgTextBox
        Me.LblUnit = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.Topctrl1.TabIndex = 5
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 295)
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 299)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(148, 299)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(554, 299)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(401, 299)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(704, 299)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(278, 299)
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
        'TxtShade
        '
        Me.TxtShade.AgMandatory = True
        Me.TxtShade.AgMasterHelp = False
        Me.TxtShade.AgNumberLeftPlaces = 0
        Me.TxtShade.AgNumberNegetiveAllow = False
        Me.TxtShade.AgNumberRightPlaces = 0
        Me.TxtShade.AgPickFromLastValue = False
        Me.TxtShade.AgRowFilter = ""
        Me.TxtShade.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShade.AgSelectedValue = Nothing
        Me.TxtShade.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShade.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShade.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShade.Location = New System.Drawing.Point(546, 98)
        Me.TxtShade.MaxLength = 20
        Me.TxtShade.Name = "TxtShade"
        Me.TxtShade.Size = New System.Drawing.Size(133, 18)
        Me.TxtShade.TabIndex = 3
        '
        'LblShade
        '
        Me.LblShade.AutoSize = True
        Me.LblShade.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShade.Location = New System.Drawing.Point(475, 99)
        Me.LblShade.Name = "LblShade"
        Me.LblShade.Size = New System.Drawing.Size(45, 16)
        Me.LblShade.TabIndex = 683
        Me.LblShade.Text = "Shade"
        '
        'TxtYarn
        '
        Me.TxtYarn.AgMandatory = True
        Me.TxtYarn.AgMasterHelp = False
        Me.TxtYarn.AgNumberLeftPlaces = 0
        Me.TxtYarn.AgNumberNegetiveAllow = False
        Me.TxtYarn.AgNumberRightPlaces = 0
        Me.TxtYarn.AgPickFromLastValue = False
        Me.TxtYarn.AgRowFilter = ""
        Me.TxtYarn.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtYarn.AgSelectedValue = Nothing
        Me.TxtYarn.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtYarn.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtYarn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYarn.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYarn.Location = New System.Drawing.Point(334, 98)
        Me.TxtYarn.MaxLength = 20
        Me.TxtYarn.Name = "TxtYarn"
        Me.TxtYarn.Size = New System.Drawing.Size(129, 18)
        Me.TxtYarn.TabIndex = 1
        '
        'LblYarn
        '
        Me.LblYarn.AutoSize = True
        Me.LblYarn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYarn.Location = New System.Drawing.Point(183, 99)
        Me.LblYarn.Name = "LblYarn"
        Me.LblYarn.Size = New System.Drawing.Size(35, 16)
        Me.LblYarn.TabIndex = 681
        Me.LblYarn.Text = "Yarn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(318, 126)
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
        Me.TxtDescription.Location = New System.Drawing.Point(334, 118)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(345, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(183, 121)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(131, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Yarn Sku Description"
        '
        'TxtUnit
        '
        Me.TxtUnit.AgMandatory = False
        Me.TxtUnit.AgMasterHelp = True
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
        Me.TxtUnit.Location = New System.Drawing.Point(334, 138)
        Me.TxtUnit.MaxLength = 20
        Me.TxtUnit.Name = "TxtUnit"
        Me.TxtUnit.Size = New System.Drawing.Size(129, 18)
        Me.TxtUnit.TabIndex = 2
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnit.Location = New System.Drawing.Point(184, 140)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(31, 16)
        Me.LblUnit.TabIndex = 685
        Me.LblUnit.Text = "Unit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(318, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 686
        Me.Label2.Text = "Ä"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(530, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 687
        Me.Label3.Text = "Ä"
        '
        'FrmYarnSKU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 343)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUnit)
        Me.Controls.Add(Me.LblUnit)
        Me.Controls.Add(Me.TxtShade)
        Me.Controls.Add(Me.LblShade)
        Me.Controls.Add(Me.TxtYarn)
        Me.Controls.Add(Me.LblYarn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmYarnSKU"
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
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblYarn, 0)
        Me.Controls.SetChildIndex(Me.TxtYarn, 0)
        Me.Controls.SetChildIndex(Me.LblShade, 0)
        Me.Controls.SetChildIndex(Me.TxtShade, 0)
        Me.Controls.SetChildIndex(Me.LblUnit, 0)
        Me.Controls.SetChildIndex(Me.TxtUnit, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblYarn As System.Windows.Forms.Label
    Friend WithEvents TxtYarn As AgControls.AgTextBox
    Friend WithEvents LblShade As System.Windows.Forms.Label
    Friend WithEvents TxtUnit As AgControls.AgTextBox
    Friend WithEvents LblUnit As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtShade As AgControls.AgTextBox


#End Region

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtDescription, "Description") Then Exit Sub
        'If AgL.RequiredField(TxtYarn, "Yarn") Then Exit Sub
        'If AgL.RequiredField(TxtShade, "Shade") Then Exit Sub

        If TxtDescription.Text.Trim = "" Then Err.Raise(1, , "Yarn Sku Description Is Required!")
        If TxtYarn.Text.Trim = "" Then Err.Raise(1, , "Yarn Is Required!")
        If TxtShade.Text.Trim = "" Then Err.Raise(1, , "Shade Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Item Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Sku Description Already Exist!")

            mQry = "Select count(*) From Item_log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Sku Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From Item Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Sku Description Already Exist!")

            mQry = "Select count(*) From Item_log Where Description = '" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Yarn Sku Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.UID, I.Description [YarnSku Description], I.Unit, " & _
                        " Y.Description As Yarn, S.Description As Shade " & _
                        " FROM Rug_YarnSKU_Log Ys " & _
                        " LEFT JOIN Item_Log I On I.Code = Ys.Code " & _
                        " LEFT JOIN Rug_Yarn_Log Y On Ys.Yarn = Y.Code " & _
                        " LEFT JOIN Rug_Shade_Log S On Ys.Shade = S.Code " & mConStr & _
                        " And I.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[YarnSku Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.Code, I.Description [YarnSku Description], I.Unit, " & _
                        " Y.Description As Yarn, S.Description As Shade " & _
                        " FROM Rug_YarnSKU Ys " & _
                        " LEFT JOIN Item I On I.Code = Ys.Code " & _
                        " LEFT JOIN Rug_Yarn Y On Ys.Yarn = Y.Code " & _
                        " LEFT JOIN Rug_Shade S On Ys.Shade = S.Code " & mConStr & _
                        " And IsNull(I.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[YarnSku Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Item"
        LogTableName = "Item_LOG"
        MainLineTableCsv = "RUG_YarnSKU"
        LogLineTableCsv = "RUG_YarnSKU_LOG"
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE Item_Log " & _
                " SET " & _
                " Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                " Unit = " & AgL.Chk_Text(TxtUnit.Text) & ", " & _
                " ItemType = '" & ClsMain.ItemType.YarnSKU & "' " & _
                " Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Delete From RUG_YarnSku_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "INSERT INTO RUG_YarnSku_Log ( UID, Code, YARN, SHADE) " & _
                " VALUES (" & AgL.Chk_Text(SearchCode) & ",	" & AgL.Chk_Text(mInternalCode) & ", " & _
                " " & AgL.Chk_Text(TxtYarn.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtShade.AgSelectedValue) & ")"

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtUnit.Enabled = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Description As Name , Div_Code From Item " & _
            " WHERE ItemType = '" & ClsMain.ItemType.YarnSKU & "'  " & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code as Code, Description as Yarn,  Unit, " & _
                " IsNull(IsDeleted,0) As IsDeleted, Status , Div_Code " & _
                " From Rug_Yarn  " & _
                " Order By Description"
        TxtYarn.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code as Code, Description as Shade, Pantone, " & _
                "  IsNull(IsDeleted,0) As IsDeleted, IsNull(Status,'Active') As Status , Div_Code " & _
                "  From Rug_Shade  " & _
                "  Order By Description"
        TxtShade.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.Code As SearchCode " & _
            " From Rug_YarnSku Ys " & _
            " LEFT JOIN Item I On Ys.Code = I.Code " & mConStr & _
            " And IsNull(I.IsDeleted,0)=0 Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.UID As SearchCode " & _
               " From Rug_YarnSku_log Ys " & _
               " LEFT JOIN Item_log I On Ys.UID = I.UID " & mConStr & _
               " And I.EntryStatus='" & LogStatus.LogOpen & "' Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select I.*, Ys.Yarn, Ys.SHADE " & _
                " From Item I " & _
                " LEFT JOIN RUG_YarnSKU Ys On I.Code = Ys.Code " & _
                " Where I.Code='" & SearchCode & "'"
        Else
            mQry = "Select I.*, Ys.Yarn, Ys.SHADE  " & _
                " From Item_Log I " & _
                " LEFT JOIN RUG_YarnSKU_Log Ys On I.Code = Ys.Code " & _
                " Where I.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtYarn.AgSelectedValue = AgL.XNull(.Rows(0)("Yarn"))
                TxtShade.AgSelectedValue = AgL.XNull(.Rows(0)("Shade"))
                TxtUnit.Text = AgL.XNull(.Rows(0)("Unit"))
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtYarn.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtYarn.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmYarn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 382, 870, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYarn.Enter, TxtShade.Enter, TxtDescription.Enter
        Try
            Select Case sender.name
                Case TxtYarn.Name
                    sender.AgRowFilter = "IsDeleted = 0 And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And " & ClsMain.RetDivFilterStr & ""

                Case TxtShade.Name
                    TxtShade.AgRowFilter = "IsDeleted = 0 And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "'  And " & ClsMain.RetDivFilterStr & ""

                Case TxtDescription.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtShade.Validating, TxtYarn.Validating, TxtDescription.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtYarn.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtUnit.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtUnit.Text = AgL.XNull(DrTemp(0)("Unit"))
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtShade_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShade.TextChanged
        TxtDescription.Text = TxtYarn.Text + " \ " + TxtShade.Text
    End Sub
End Class
