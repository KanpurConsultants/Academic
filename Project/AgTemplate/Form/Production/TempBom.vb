Public Class TempBom
    Inherits AgTemplate.TempMaster

    Public Const ColSNo As String = "SNo"
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Public Const Col1Process As String = "Process"
    Public Const Col1Item As String = "Item"
    Public Const Col1Qty As String = "Qty"
    Public Const Col1ConsumptionPer As String = "Consumption %"
    Public Const Col1ApplyIn As String = "Apply In"
    
    Dim mQry$


#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtForQty = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.LblForQuantity = New System.Windows.Forms.Label
        Me.LblForWeight = New System.Windows.Forms.Label
        Me.TxtForWeight = New AgControls.AgTextBox
        Me.TxtForUnit = New AgControls.AgTextBox
        Me.LblUnit = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtCopyFrom = New AgControls.AgTextBox
        Me.GrpCopyFrom = New System.Windows.Forms.GroupBox
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GrpCopyFrom.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 5
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(899, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 425)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(553, 425)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(399, 425)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(703, 425)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(275, 425)
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
        'TxtForQty
        '
        Me.TxtForQty.AgMandatory = True
        Me.TxtForQty.AgMasterHelp = True
        Me.TxtForQty.AgNumberLeftPlaces = 8
        Me.TxtForQty.AgNumberNegetiveAllow = False
        Me.TxtForQty.AgNumberRightPlaces = 3
        Me.TxtForQty.AgPickFromLastValue = False
        Me.TxtForQty.AgRowFilter = ""
        Me.TxtForQty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForQty.AgSelectedValue = Nothing
        Me.TxtForQty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForQty.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtForQty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForQty.Location = New System.Drawing.Point(350, 105)
        Me.TxtForQty.MaxLength = 0
        Me.TxtForQty.Multiline = True
        Me.TxtForQty.Name = "TxtForQty"
        Me.TxtForQty.Size = New System.Drawing.Size(129, 20)
        Me.TxtForQty.TabIndex = 1
        Me.TxtForQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(335, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 679
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
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(350, 83)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Multiline = True
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(306, 20)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(200, 86)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(104, 16)
        Me.LblDescription.TabIndex = 674
        Me.LblDescription.Text = "Bom Description"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LemonChiffon
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(95, 376)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(667, 23)
        Me.Panel1.TabIndex = 697
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQty.Location = New System.Drawing.Point(582, 2)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(503, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 16)
        Me.Label11.TabIndex = 659
        Me.Label11.Text = "Total Qty :"
        '
        'LblForQuantity
        '
        Me.LblForQuantity.AutoSize = True
        Me.LblForQuantity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForQuantity.Location = New System.Drawing.Point(200, 108)
        Me.LblForQuantity.Name = "LblForQuantity"
        Me.LblForQuantity.Size = New System.Drawing.Size(80, 16)
        Me.LblForQuantity.TabIndex = 698
        Me.LblForQuantity.Text = "For Quantity"
        '
        'LblForWeight
        '
        Me.LblForWeight.AutoSize = True
        Me.LblForWeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForWeight.Location = New System.Drawing.Point(200, 130)
        Me.LblForWeight.Name = "LblForWeight"
        Me.LblForWeight.Size = New System.Drawing.Size(72, 16)
        Me.LblForWeight.TabIndex = 700
        Me.LblForWeight.Text = "For Weight"
        '
        'TxtForWeight
        '
        Me.TxtForWeight.AgMandatory = True
        Me.TxtForWeight.AgMasterHelp = True
        Me.TxtForWeight.AgNumberLeftPlaces = 8
        Me.TxtForWeight.AgNumberNegetiveAllow = False
        Me.TxtForWeight.AgNumberRightPlaces = 3
        Me.TxtForWeight.AgPickFromLastValue = False
        Me.TxtForWeight.AgRowFilter = ""
        Me.TxtForWeight.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForWeight.AgSelectedValue = Nothing
        Me.TxtForWeight.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForWeight.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtForWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForWeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForWeight.Location = New System.Drawing.Point(350, 127)
        Me.TxtForWeight.MaxLength = 0
        Me.TxtForWeight.Multiline = True
        Me.TxtForWeight.Name = "TxtForWeight"
        Me.TxtForWeight.Size = New System.Drawing.Size(129, 20)
        Me.TxtForWeight.TabIndex = 2
        Me.TxtForWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtForUnit
        '
        Me.TxtForUnit.AgMandatory = True
        Me.TxtForUnit.AgMasterHelp = False
        Me.TxtForUnit.AgNumberLeftPlaces = 0
        Me.TxtForUnit.AgNumberNegetiveAllow = False
        Me.TxtForUnit.AgNumberRightPlaces = 0
        Me.TxtForUnit.AgPickFromLastValue = False
        Me.TxtForUnit.AgRowFilter = ""
        Me.TxtForUnit.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForUnit.AgSelectedValue = Nothing
        Me.TxtForUnit.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForUnit.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForUnit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForUnit.Location = New System.Drawing.Point(527, 105)
        Me.TxtForUnit.MaxLength = 50
        Me.TxtForUnit.Multiline = True
        Me.TxtForUnit.Name = "TxtForUnit"
        Me.TxtForUnit.Size = New System.Drawing.Size(129, 20)
        Me.TxtForUnit.TabIndex = 3
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnit.Location = New System.Drawing.Point(490, 108)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(31, 16)
        Me.LblUnit.TabIndex = 701
        Me.LblUnit.Text = "Unit"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(95, 178)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(667, 197)
        Me.Pnl1.TabIndex = 702
        '
        'TxtCopyFrom
        '
        Me.TxtCopyFrom.AgMandatory = True
        Me.TxtCopyFrom.AgMasterHelp = False
        Me.TxtCopyFrom.AgNumberLeftPlaces = 0
        Me.TxtCopyFrom.AgNumberNegetiveAllow = False
        Me.TxtCopyFrom.AgNumberRightPlaces = 0
        Me.TxtCopyFrom.AgPickFromLastValue = False
        Me.TxtCopyFrom.AgRowFilter = ""
        Me.TxtCopyFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCopyFrom.AgSelectedValue = Nothing
        Me.TxtCopyFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCopyFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCopyFrom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCopyFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCopyFrom.Location = New System.Drawing.Point(6, 19)
        Me.TxtCopyFrom.MaxLength = 50
        Me.TxtCopyFrom.Name = "TxtCopyFrom"
        Me.TxtCopyFrom.Size = New System.Drawing.Size(164, 15)
        Me.TxtCopyFrom.TabIndex = 703
        '
        'GrpCopyFrom
        '
        Me.GrpCopyFrom.Controls.Add(Me.TxtCopyFrom)
        Me.GrpCopyFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpCopyFrom.ForeColor = System.Drawing.Color.DarkRed
        Me.GrpCopyFrom.Location = New System.Drawing.Point(669, 99)
        Me.GrpCopyFrom.Name = "GrpCopyFrom"
        Me.GrpCopyFrom.Size = New System.Drawing.Size(176, 48)
        Me.GrpCopyFrom.TabIndex = 705
        Me.GrpCopyFrom.TabStop = False
        Me.GrpCopyFrom.Text = "Copy From"
        '
        'TempBom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(857, 469)
        Me.Controls.Add(Me.GrpCopyFrom)
        Me.Controls.Add(Me.TxtForUnit)
        Me.Controls.Add(Me.LblUnit)
        Me.Controls.Add(Me.LblForWeight)
        Me.Controls.Add(Me.TxtForWeight)
        Me.Controls.Add(Me.LblForQuantity)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtForQty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "TempBom"
        Me.Text = "BOM Master"
        Me.Controls.SetChildIndex(Me.LblDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtDescription, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtForQty, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LblForQuantity, 0)
        Me.Controls.SetChildIndex(Me.TxtForWeight, 0)
        Me.Controls.SetChildIndex(Me.LblForWeight, 0)
        Me.Controls.SetChildIndex(Me.LblUnit, 0)
        Me.Controls.SetChildIndex(Me.TxtForUnit, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GrpCopyFrom, 0)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GrpCopyFrom.ResumeLayout(False)
        Me.GrpCopyFrom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblDescription As System.Windows.Forms.Label
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents LblTotalQty As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents TxtDescription As AgControls.AgTextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TxtForQty As AgControls.AgTextBox
    Public WithEvents LblForQuantity As System.Windows.Forms.Label
    Public WithEvents LblForWeight As System.Windows.Forms.Label
    Public WithEvents TxtForWeight As AgControls.AgTextBox
    Public WithEvents TxtForUnit As AgControls.AgTextBox
    Public WithEvents LblUnit As System.Windows.Forms.Label
    Public WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtCopyFrom As AgControls.AgTextBox
    Protected WithEvents GrpCopyFrom As System.Windows.Forms.GroupBox
#End Region

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtDescription, "Description") Then Exit Sub

        If TxtDescription.Text.Trim = "" Then Err.Raise(1, , "Description Is Required!")


        If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Sub
        If AgCL.AgIsDuplicate(DGL1, "" & DGL1.Columns(Col1Item).Index & "," & DGL1.Columns(Col1Process).Index & "") Then Exit Sub
        Dim I As Integer = 0
        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        DGL1.CurrentCell = DGL1.Item(Col1Qty, I) : DGL1.Focus()
                        Err.Raise(1, , "Qty Is Blank At Row No. " & DGL1.Item(ColSNo, I).Value & " ")
                    End If
                End If
            Next
        End With

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Bom Where Description='" & TxtDescription.Text & "' "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Description Already Exist!")

            mQry = "Select count(*) From Bom_Log Where Description='" & TxtDescription.Text & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From Bom Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Description Already Exist!")

            mQry = "Select count(*) From Bom_Log Where Description = '" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        AgL.PubFindQry = "SELECT UID, Description [BOM Description], " & _
                        " ForQty, ForWeight, ForUnit " & _
                        " FROM BOM_Log " & _
                        " WHERE EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[BOM Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        AgL.PubFindQry = "SELECT Code, Description [BOM Description], " & _
                            " ForQty, ForWeight, ForUnit " & _
                            " FROM Bom " & _
                            " WHERE IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[BOM Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "BOM"
        LogTableName = "BOM_Log"
        MainLineTableCsv = "BomDetail"
        LogLineTableCsv = "BomDetail_Log"
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = " UPDATE Bom_Log SET " & _
                " Description = " & AgL.Chk_Text(TxtDescription.Text) & ", 	" & _
                " ForQty = " & Val(TxtForQty.Text) & ", " & _
                " ForWeight = " & Val(TxtForWeight.Text) & ", 	" & _
                " ForUnit = " & AgL.Chk_Text(TxtForUnit.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & " " & _
                " Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Delete From BomDetail_Log Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        Dim I As Integer
        With DGL1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = " INSERT INTO BomDetail_Log(UID, Code, Sr, Process, Item,  Qty, ConsumptionPer, ApplyIn) " & _
                            " VALUES (" & AgL.Chk_Text(mSearchCode) & "," & AgL.Chk_Text(mInternalCode) & ", " & _
                            " " & Val(I) & "," & AgL.Chk_Text(.AgSelectedValue(Col1Process, I)) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ", " & _
                            " " & Val(.Item(Col1Qty, I).Value) & ", " & _
                            " " & Val(.Item(Col1ConsumptionPer, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1ApplyIn, I).Value) & ")"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmQuality1_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        LblTotalQty.Text = 0
    End Sub

    'Private Sub FrmQuality1_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
    '    Dim i As Integer
    '    LblTotalQty.Text = "0"
    '    With DGL1
    '        For i = 0 To DGL1.RowCount - 1
    '            If .Item(Col1Item, i).Value <> "" Then
    '                .Item(Col1ConsumptionPer, i).Value = Format((Val(.Item(Col1Qty, i).Value) / Val(TxtForWeight.Text)) * 100, "0.00")
    '                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(.Item(Col1Qty, i).Value)
    '            End If

    '            If .Item(Col1Item, i).Value <> "" Then
    '                .Item(Col1Qty, i).Value = Format((Val(.Item(Col1ConsumptionPer, i).Value) * Val(TxtForWeight.Text)) / 100, "0.000")
    '                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(.Item(Col1Qty, i).Value)
    '            End If
    '        Next
    '        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
    '    End With
    'End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            GrpCopyFrom.Visible = True
        Else
            GrpCopyFrom.Visible = False
        End If
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT H.NCat, V.NCatDescription  " & _
               "FROM Process H " & _
               "LEFT JOIN VoucherCat V ON H.NCat = V.NCat "
        DGL1.AgHelpDataSet(Col1Process) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Description As Name, Div_Code  " & _
            " From BOM " & _
            " Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Code as Code, Code as  Unit " & _
                " FROM Unit " & _
                " ORDER BY Code "
        TxtForUnit.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code AS Code, I.Description AS Item, I.ItemType, IsDeleted, I.Div_Code, I.ItemGroup " & _
                " FROM Item I  " & _
                " Order By I.Description"
        DGL1.AgHelpDataSet(Col1Item, 3) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description FROM BOM "
        TxtCopyFrom.AgHelpDataSet(0, GrpCopyFrom.Top, GrpCopyFrom.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        mQry = "Select Code As SearchCode " & _
                " From BOM " & _
                " WHERE IsNull(IsDeleted,0)=0 " & _
                " Order By Description "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        mQry = "Select UID As SearchCode " & _
               " From BOM_Log " & _
               " WHERE EntryStatus='" & LogStatus.LogOpen & "' " & _
               " Order By Description"
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Process, 250, 0, Col1Process, False, False, False)
            .AddAgTextColumn(DGL1, Col1Item, 250, 0, Col1Item, True, False, False)
            .AddAgNumberColumn(DGL1, Col1Qty, 100, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(DGL1, Col1ConsumptionPer, 120, 8, 2, False, Col1ConsumptionPer, True, True, True)
            .AddAgTextColumn(DGL1, Col1ApplyIn, 120, 20, Col1ApplyIn, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.EnableHeadersVisualStyles = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        Dim DrTemp As DataRow() = Nothing

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From BOM Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From BOM_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtForUnit.AgSelectedValue = AgL.XNull(.Rows(0)("ForUnit"))
                TxtForQty.Text = Format(AgL.VNull(.Rows(0)("ForQty")), "0.000")
                TxtForWeight.Text = Format(AgL.VNull(.Rows(0)("ForWeight")), "0.000")
                LblTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")
                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                Dim I As Integer
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from BomDetail where Code = '" & mSearchCode & "'"
                Else
                    mQry = "Select * from BomDetail_Log where UID = '" & mSearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1Process, I) = AgL.XNull(.Rows(I)("Process"))
                            DGL1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            DGL1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.000")
                            DGL1.Item(Col1ConsumptionPer, I).Value = Format(AgL.VNull(.Rows(I)("ConsumptionPer")), "0.00")
                            DGL1.Item(Col1ApplyIn, I).Value = AgL.XNull(.Rows(I)("ApplyIn"))
                        Next I
                    End If
                End With
            End If
        End With
        GrpCopyFrom.Visible = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Public Overridable Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter

    End Sub

    Public Overridable Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex
            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Item

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter
        Try
            Select Case sender.name

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtQualityCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtForQty.Validating
        Dim DrTemp As DataRow() = Nothing
        Select Case sender.name

        End Select
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TxtCopyFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCopyFrom.Validating
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            mQry = "SELECT * FROM BomDetail Bd WHERE Bd.Code = '" & TxtCopyFrom.AgSelectedValue & "' "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL1.RowCount = 1
                DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1Process, I) = AgL.XNull(.Rows(I)("Process"))
                        DGL1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        DGL1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.000")
                        DGL1.Item(Col1ConsumptionPer, I).Value = Format(AgL.VNull(.Rows(I)("ConsumptionPer")), "0.00")
                        DGL1.Item(Col1ApplyIn, I).Value = AgL.XNull(.Rows(I)("ApplyIn"))
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmQuality1_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim i As Integer
        LblTotalQty.Text = "0"
        With DGL1
            For i = 0 To DGL1.RowCount - 1
                If .Item(Col1Item, i).Value <> "" Then
                    If .CurrentCell.ColumnIndex = DGL1.Columns(Col1Qty).Index Then
                        .Item(Col1ConsumptionPer, i).Value = Format((Val(.Item(Col1Qty, i).Value) / Val(TxtForWeight.Text)) * 100, "0.00")
                    End If

                    If .CurrentCell.ColumnIndex = DGL1.Columns(Col1ConsumptionPer).Index Then
                        .Item(Col1Qty, i).Value = Format((Val(.Item(Col1ConsumptionPer, i).Value) * Val(TxtForWeight.Text)) / 100, "0.000")
                    End If
                    LblTotalQty.Text = Val(LblTotalQty.Text) + Val(.Item(Col1Qty, i).Value)
                End If
            Next
            LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
        End With
    End Sub
End Class
