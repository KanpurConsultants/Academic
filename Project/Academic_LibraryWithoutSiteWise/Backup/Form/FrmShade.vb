Public Class FrmShade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShade))
        Me.TxtPantone = New AgControls.AgTextBox
        Me.LblPantone = New System.Windows.Forms.Label
        Me.TxtColour = New AgControls.AgTextBox
        Me.LblColour = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
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
        'TxtPantone
        '
        Me.TxtPantone.AgMandatory = False
        Me.TxtPantone.AgMasterHelp = True
        Me.TxtPantone.AgNumberLeftPlaces = 0
        Me.TxtPantone.AgNumberNegetiveAllow = False
        Me.TxtPantone.AgNumberRightPlaces = 0
        Me.TxtPantone.AgPickFromLastValue = False
        Me.TxtPantone.AgRowFilter = ""
        Me.TxtPantone.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPantone.AgSelectedValue = Nothing
        Me.TxtPantone.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPantone.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPantone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPantone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPantone.Location = New System.Drawing.Point(530, 156)
        Me.TxtPantone.MaxLength = 20
        Me.TxtPantone.Name = "TxtPantone"
        Me.TxtPantone.Size = New System.Drawing.Size(129, 18)
        Me.TxtPantone.TabIndex = 673
        '
        'LblPantone
        '
        Me.LblPantone.AutoSize = True
        Me.LblPantone.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPantone.Location = New System.Drawing.Point(456, 160)
        Me.LblPantone.Name = "LblPantone"
        Me.LblPantone.Size = New System.Drawing.Size(56, 16)
        Me.LblPantone.TabIndex = 682
        Me.LblPantone.Text = "Pantone"
        '
        'TxtColour
        '
        Me.TxtColour.AgMandatory = False
        Me.TxtColour.AgMasterHelp = True
        Me.TxtColour.AgNumberLeftPlaces = 0
        Me.TxtColour.AgNumberNegetiveAllow = False
        Me.TxtColour.AgNumberRightPlaces = 0
        Me.TxtColour.AgPickFromLastValue = False
        Me.TxtColour.AgRowFilter = ""
        Me.TxtColour.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtColour.AgSelectedValue = Nothing
        Me.TxtColour.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtColour.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtColour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtColour.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtColour.Location = New System.Drawing.Point(314, 156)
        Me.TxtColour.MaxLength = 20
        Me.TxtColour.Name = "TxtColour"
        Me.TxtColour.Size = New System.Drawing.Size(129, 18)
        Me.TxtColour.TabIndex = 672
        '
        'LblColour
        '
        Me.LblColour.AutoSize = True
        Me.LblColour.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColour.Location = New System.Drawing.Point(181, 159)
        Me.LblColour.Name = "LblColour"
        Me.LblColour.Size = New System.Drawing.Size(45, 16)
        Me.LblColour.TabIndex = 681
        Me.LblColour.Text = "Colour"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(298, 144)
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
        Me.TxtDescription.Location = New System.Drawing.Point(314, 136)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(345, 18)
        Me.TxtDescription.TabIndex = 665
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(181, 139)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(114, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Shade Description"
        '
        'GBoxImportFromExcel
        '
        Me.GBoxImportFromExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxImportFromExcel.BackColor = System.Drawing.Color.Transparent
        Me.GBoxImportFromExcel.Controls.Add(Me.BtnImprtFromExcel)
        Me.GBoxImportFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxImportFromExcel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxImportFromExcel.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxImportFromExcel.Location = New System.Drawing.Point(751, 136)
        Me.GBoxImportFromExcel.Name = "GBoxImportFromExcel"
        Me.GBoxImportFromExcel.Size = New System.Drawing.Size(99, 49)
        Me.GBoxImportFromExcel.TabIndex = 683
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
        'FrmShade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 352)
        Me.Controls.Add(Me.GBoxImportFromExcel)
        Me.Controls.Add(Me.TxtPantone)
        Me.Controls.Add(Me.LblPantone)
        Me.Controls.Add(Me.TxtColour)
        Me.Controls.Add(Me.LblColour)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmShade"
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
        Me.Controls.SetChildIndex(Me.LblColour, 0)
        Me.Controls.SetChildIndex(Me.TxtColour, 0)
        Me.Controls.SetChildIndex(Me.LblPantone, 0)
        Me.Controls.SetChildIndex(Me.TxtPantone, 0)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblColour As System.Windows.Forms.Label
    Friend WithEvents TxtColour As AgControls.AgTextBox
    Friend WithEvents LblPantone As System.Windows.Forms.Label
    Public WithEvents GBoxImportFromExcel As System.Windows.Forms.GroupBox
    Public WithEvents BtnImprtFromExcel As System.Windows.Forms.Button
    Friend WithEvents TxtPantone As AgControls.AgTextBox


#End Region

    Private Sub FrmShade_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtDescription, "Description") Then Exit Sub

        If TxtDescription.Text.Trim = "" Then Err.Raise(1, , "Description Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From RUG_Shade Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & ""
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Shade Description Already Exists")

            mQry = "Select count(*) From RUG_Shade_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Shade Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From RUG_Shade Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & ""
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Shade Description Already Exists")

            mQry = "Select count(*) From RUG_Shade_Log Where Description='" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Shade Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmShade_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT UID, Description [Shade Description], Colour, Pantone " & _
                        " FROM RUG_Shade_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Shade Description]"
    End Sub

    Private Sub FrmShade_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT Code, Description [Shade Description], Colour, Pantone  " & _
                        " FROM RUG_Shade " & mConStr & _
                        " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Shade Description]"
    End Sub

    Private Sub FrmShade_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "RUG_Shade"
        LogTableName = "RUG_Shade_LOG"
    End Sub

    Private Sub FrmShade_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "Update RUG_Shade_Log " & _
                "   SET  " & _
                "	Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                "	Colour = " & AgL.Chk_Text(TxtColour.Text) & ", " & _
                "	Pantone = " & AgL.Chk_Text(TxtPantone.Text) & " " & _
                "   Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText

    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Description As Name , Div_Code " & _
            " From Rug_Shade  " & _
            " Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Distinct Colour  as Code, Colour as Name, Div_Code " & _
                "  From Rug_Shade  " & _
                "  WHERE Colour Is Not Null" & _
                "  Order By Colour"
        TxtColour.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Distinct Pantone  as Code, Pantone as Name, Div_Code " & _
                "  From Rug_Shade " & _
                "  WHERE Pantone Is Not Null" & _
                "  Order By Pantone"
        TxtPantone.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmShade_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select Code As SearchCode " & _
            " From RUG_Shade " & mConStr & _
            " And IsNull(IsDeleted,0)=0 Order By Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmShade_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select UID As SearchCode " & _
               " From RUG_Shade_log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' Order By Description"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From RUG_Shade Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From RUG_Shade_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtColour.Text = AgL.XNull(.Rows(0)("Colour"))
                TxtPantone.Text = AgL.XNull(.Rows(0)("Pantone"))
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

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 382, 870, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter, TxtColour.Enter, TxtPantone.Enter
        Try
            Select Case sender.name
                Case TxtDescription.Name, TxtColour.Name, TxtPantone.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnImprtFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromExcel.Click
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        mQry = "Select '' as Srl, 'Shade Description' as [Field Name], 'Text' as [Data Type], 50 as [Length] "
        mQry = mQry + "Union All Select  '' as Srl,'Colour' as [Field Name], 'Text' as [Data Type], 20 as [Length] "
        mQry = mQry + "Union All Select  '' as Srl,'Pantone' as [Field Name], 'Text' as [Data Type], 20 as [Length] "
        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportFromExcel
        ObjFrmImport.LblTitle.Text = "Shade Master Import"
        ObjFrmImport.Dgl1.DataSource = DtTemp
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub
        'If Not ObjFrmImport.P_DsExcelData Is Nothing Then Exit Sub

        DtTemp = ObjFrmImport.P_DsExcelData.Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            Topctrl1.FButtonClick(0)
            TxtDescription.Text = AgL.XNull(DtTemp.Rows(I)("Shade Description"))
            TxtColour.Text = AgL.XNull(DtTemp.Rows(I)("Colour"))
            TxtPantone.Text = AgL.XNull(DtTemp.Rows(I)("Pantone"))

            Topctrl1.FButtonClick(13)

        Next

        If StrErrLog <> "" Then MsgBox(StrErrLog)
        'DGL1.RowCount = 1
        'DGL1.Rows.Clear()
        'With DsTemp.Tables(0)
        '    If .Rows.Count > 0 Then
        '        j = 0
        '        For i = 0 To .Rows.Count - 1
        '            mCaseDocId = "" : mInstallment_No = -1

        '            DtCase = AgL.FillData("Select DocId From CaseEntry Where PolicyNO = '" & AgL.XNull(.Rows(i)("Policy Number")).ToString.Trim & "' And Isnull(ApprovedBy,'') <>'' ", AgL.GCn).Tables(0)
        '            If DtCase.Rows.Count > 0 Then mCaseDocId = DtCase.Rows(0)(0)
        '            If AgL.VNull(.Rows(i)("Commission")) < 0 Then
        '                mCond = " And PremiumPostingDocId Is Not Null  "
        '            Else
        '                mCond = " And PremiumPostingDocId Is Null  "
        '            End If

        '            If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '                mQry = "Select Installment_No From Case_Installment Where CaseDocId = '" & mCaseDocId & "'  And DatePart(Month,Installment_Date) = Convert(Numeric,Right('" & AgL.XNull(.Rows(i)("Due Date")).ToString.Trim & "',2)) And DatePart(Year,Installment_Date) = Convert(Numeric,Left('" & AgL.XNull(.Rows(i)("Due Date")).ToString.Trim & "',4))    " & mCond
        '            Else
        '                mQry = "Select Installment_No From Case_Installment Where CaseDocId = '" & mCaseDocId & "'  And Installment_Date = '" & AgL.RetDate(AgL.XNull(.Rows(i)("Due Date"))).ToString.Trim & "'  " & mCond
        '            End If
        '            DtInstallment = AgL.FillData(mQry, AgL.GCn).Tables(0)
        '            If DtCase.Rows.Count > 0 And DtInstallment.Rows.Count > 0 Then
        '                DGL1.Rows.Add()
        '                DGL1.Item(Col_SNo, j).Value = DGL1.Rows.Count - 1
        '                mCaseDocId = DtCase.Rows(0)(0)
        '                mInstallment_No = DtInstallment.Rows(0)(0)
        '                DGL1.AgSelectedValue(Col1Policy_No, j) = mCaseDocId
        '                Fill_PolicyDetail(mCaseDocId, j)
        '                DGL1.Item(Col1PaymentMode, j).Value = "Cheque"
        '                If AgL.VNull(.Rows(i)("Commission")) > 0 Then
        '                    DGL1.Item(Col1TransactionType, j).Value = "Post"
        '                Else
        '                    DGL1.Item(Col1TransactionType, j).Value = "Cancel"
        '                End If
        '                InstallmentNo_CellEnter(j)
        '                DGL1.Item(Col1PremiumDueDate_InsComp, j).Value = AgL.XNull(.Rows(i)("Due Date")).ToString.Trim
        '                If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '                    DGL1.Item(Col1CollectingBranch, j).Value = AgL.XNull(.Rows(i)("Coll_Branch")).ToString.Trim
        '                    DGL1.Item(Col1LastAccountDate, j).Value = Format(AgL.MidStr(AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim, 6, 2) + "/" + AgL.MidStr(AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim, 4, 2) + "/" + AgL.MidStr(AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim, 0, 4), AgLibrary.ClsConstant.DateFormat_ShortDate)
        '                Else
        '                    DGL1.Item(Col1LastAccountDate, j).Value = AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim
        '                End If


        '                DGL1.Item(Col1CommissionAmt, j).Value = PLib.Get_Commission(mCaseDocId, mInstallment_No)
        '                DGL1.AgSelectedValue(Col1Installment_No, j) = mInstallment_No

        '                If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '                    DGL1.Item(Col1PremiumDueDate_InsComp, j).Value = DGL1.Item(Col1Installment_No, j).Value
        '                End If
        '                DGL1.Item(Col1CommissionAmt_InsComp, j).Value = AgL.VNull(.Rows(i)("Commission"))
        '                j += 1
        '            Else
        '                FW.WriteLine("Policy No " & AgL.XNull(DsTemp.Tables(0).Rows(i)("Policy Number")).ToString.Trim & "  -  Installment #" & AgL.XNull(DsTemp.Tables(0).Rows(i)("Due Date")).ToString.Trim & "#  Not Found in Records Or Already Received Or Case Not Approved")
        '            End If
        '        Next i
        '    End If
        'End With


    End Sub

    Private Sub BtnExcelImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim i As Integer, j As Integer
        'Dim MyConnection As System.Data.OleDb.OleDbConnection
        'Dim MyCommand As System.Data.OleDb.OleDbDataAdapter = Nothing
        'Dim myExcelFilePath$
        'Dim DsTemp As New DataSet
        'Dim DtCase As New DataTable
        'Dim DtInstallment As New DataTable
        'Dim DtCaseInstallmentPending As New DataTable
        'Dim mCond$
        'Dim mCaseDocId$ = "", mInstallment_No% = -1


        'If TxtInsuranceCompany.Text = "" Then
        '    MsgBox("Please Select Insurance Company.")
        '    TxtInsuranceCompany.Focus()
        '    Exit Sub
        'End If

        'Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\PendingPolicyInstallment.Txt", False, System.Text.Encoding.Default)

        'Try
        '    Opn.Filter = "Excel Files (*.xls)|*.xls"
        '    Opn.ShowDialog()
        '    myExcelFilePath = Opn.FileName
        '    TxtExcelPath.Text = myExcelFilePath
        '    MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " & _
        '                   "data source='" & myExcelFilePath & " '; " & "Extended Properties=Excel 8.0;")
        '    If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select Policy as [Policy Number], Commission, [Prem Due] as [Due Date], [Colln Brn ] AS Coll_Branch, [Adjustd Date] As [Last Account Date]  from [sheet1$]", MyConnection)
        '    ElseIf AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "SBI") Then
        '        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select [Policy Number], Commission, [Due Date], Null AS Coll_Branch, [CASHIERED DATE] As [Last Account Date]  from [sheet1$]", MyConnection)
        '    End If
        '    MyCommand.Fill(DsTemp)




        '    DGL1.RowCount = 1
        '    DGL1.Rows.Clear()
        '    With DsTemp.Tables(0)
        '        If .Rows.Count > 0 Then
        '            j = 0
        '            For i = 0 To .Rows.Count - 1
        '                mCaseDocId = "" : mInstallment_No = -1

        '                DtCase = AgL.FillData("Select DocId From CaseEntry Where PolicyNO = '" & AgL.XNull(.Rows(i)("Policy Number")).ToString.Trim & "' And Isnull(ApprovedBy,'') <>'' ", AgL.GCn).Tables(0)
        '                If DtCase.Rows.Count > 0 Then mCaseDocId = DtCase.Rows(0)(0)
        '                If AgL.VNull(.Rows(i)("Commission")) < 0 Then
        '                    mCond = " And PremiumPostingDocId Is Not Null  "
        '                Else
        '                    mCond = " And PremiumPostingDocId Is Null  "
        '                End If

        '                If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '                    mQry = "Select Installment_No From Case_Installment Where CaseDocId = '" & mCaseDocId & "'  And DatePart(Month,Installment_Date) = Convert(Numeric,Right('" & AgL.XNull(.Rows(i)("Due Date")).ToString.Trim & "',2)) And DatePart(Year,Installment_Date) = Convert(Numeric,Left('" & AgL.XNull(.Rows(i)("Due Date")).ToString.Trim & "',4))    " & mCond
        '                Else
        '                    mQry = "Select Installment_No From Case_Installment Where CaseDocId = '" & mCaseDocId & "'  And Installment_Date = '" & AgL.RetDate(AgL.XNull(.Rows(i)("Due Date"))).ToString.Trim & "'  " & mCond
        '                End If
        '                DtInstallment = AgL.FillData(mQry, AgL.GCn).Tables(0)
        '                If DtCase.Rows.Count > 0 And DtInstallment.Rows.Count > 0 Then
        '                    DGL1.Rows.Add()
        '                    DGL1.Item(Col_SNo, j).Value = DGL1.Rows.Count - 1
        '                    mCaseDocId = DtCase.Rows(0)(0)
        '                    mInstallment_No = DtInstallment.Rows(0)(0)
        '                    DGL1.AgSelectedValue(Col1Policy_No, j) = mCaseDocId
        '                    Fill_PolicyDetail(mCaseDocId, j)
        '                    DGL1.Item(Col1PaymentMode, j).Value = "Cheque"
        '                    If AgL.VNull(.Rows(i)("Commission")) > 0 Then
        '                        DGL1.Item(Col1TransactionType, j).Value = "Post"
        '                    Else
        '                        DGL1.Item(Col1TransactionType, j).Value = "Cancel"
        '                    End If
        '                    InstallmentNo_CellEnter(j)
        '                    DGL1.Item(Col1PremiumDueDate_InsComp, j).Value = AgL.XNull(.Rows(i)("Due Date")).ToString.Trim
        '                    If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '                        DGL1.Item(Col1CollectingBranch, j).Value = AgL.XNull(.Rows(i)("Coll_Branch")).ToString.Trim
        '                        DGL1.Item(Col1LastAccountDate, j).Value = Format(AgL.MidStr(AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim, 6, 2) + "/" + AgL.MidStr(AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim, 4, 2) + "/" + AgL.MidStr(AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim, 0, 4), AgLibrary.ClsConstant.DateFormat_ShortDate)
        '                    Else
        '                        DGL1.Item(Col1LastAccountDate, j).Value = AgL.XNull(.Rows(i)("Last Account Date")).ToString.Trim
        '                    End If


        '                    DGL1.Item(Col1CommissionAmt, j).Value = PLib.Get_Commission(mCaseDocId, mInstallment_No)
        '                    DGL1.AgSelectedValue(Col1Installment_No, j) = mInstallment_No

        '                    If AgL.StrCmp(TxtInsuranceCompany.AgSelectedValue, "LIC") Then
        '                        DGL1.Item(Col1PremiumDueDate_InsComp, j).Value = DGL1.Item(Col1Installment_No, j).Value
        '                    End If
        '                    DGL1.Item(Col1CommissionAmt_InsComp, j).Value = AgL.VNull(.Rows(i)("Commission"))
        '                    j += 1
        '                Else
        '                    FW.WriteLine("Policy No " & AgL.XNull(DsTemp.Tables(0).Rows(i)("Policy Number")).ToString.Trim & "  -  Installment #" & AgL.XNull(DsTemp.Tables(0).Rows(i)("Due Date")).ToString.Trim & "#  Not Found in Records Or Already Received Or Case Not Approved")
        '                End If
        '            Next i
        '        End If
        '    End With
        '    '            FW.Close()
        'Catch Ex As Exception
        '    If Ex.Message = "There is no row at position 0." Then
        '        If mCaseDocId = "" Then
        '            MsgBox("Policy No " & AgL.XNull(DsTemp.Tables(0).Rows(i)("Policy Number  ")).ToString.Trim & "  Not Found in Records")
        '        Else
        '            MsgBox("Policy No " & AgL.XNull(DsTemp.Tables(0).Rows(i)("Policy Number  ")).ToString.Trim & "  -  Installment #" & AgL.XNull(DsTemp.Tables(0).Rows(i)("Due Date       ")).ToString.Trim & "#  Not Found in Records Or Already Received")
        '        End If
        '        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        '    Else
        '        MsgBox(Ex.Message)
        '    End If
        'Finally
        '    FW.Close()
        'End Try
    End Sub


End Class
