Public Class FrmDesignConsumption
    Inherits AgTemplate_Common.TempBom
    Public Const Col1Shade As Byte = 5
    Public Const Col1Colour As Byte = 6
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtDesign As AgControls.AgTextBox
    Friend WithEvents LblBuyerCity As System.Windows.Forms.Label
    Dim mQry As String = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmDesignConsumption_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        TxtDescription.Text = TxtDesign.Text
    End Sub

    Private Sub FrmDesignConsumption_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans

        mQry = "Update BOM_Log Set Design = " & AgL.Chk_Text(TxtDesign.AgSelectedValue) & " Where UID='" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


    End Sub

    Private Sub FrmDesignConsumption_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        With DGL1
            .Columns(Col1Shade).DisplayIndex = Col1Item + 1
            .Columns(Col1Colour).DisplayIndex = Col1Item + 2
            .Columns(Col1Item).HeaderText = "Yarn Sku"
        End With

        TxtForWeight.Enabled = False
    End Sub

    Private Sub FrmDesignConsumption_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(DGL1, "Pantone", 80, 0, "Pantone", True, True, False)
            .AddAgTextColumn(Dgl1, "Colour", 80, 0, "Colour", True, True, False)
        End With
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtDesign = New AgControls.AgTextBox
        Me.LblBuyerCity = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
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
        Me.LblDescription.Location = New System.Drawing.Point(554, 47)
        Me.LblDescription.Size = New System.Drawing.Size(153, 16)
        Me.LblDescription.Text = "Consumption Description"
        Me.LblDescription.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(14, 376)
        Me.Panel1.Size = New System.Drawing.Size(820, 23)
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Location = New System.Drawing.Point(706, 2)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(627, 2)
        '
        'TxtDescription
        '
        Me.TxtDescription.AgMandatory = False
        Me.TxtDescription.Location = New System.Drawing.Point(729, 47)
        Me.TxtDescription.Size = New System.Drawing.Size(128, 20)
        Me.TxtDescription.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(713, 53)
        Me.Label1.Visible = False
        '
        'TxtForQty
        '
        Me.TxtForQty.AgMandatory = False
        Me.TxtForQty.Location = New System.Drawing.Point(728, 70)
        Me.TxtForQty.Visible = False
        '
        'LblForQuantity
        '
        Me.LblForQuantity.Location = New System.Drawing.Point(641, 73)
        Me.LblForQuantity.Visible = False
        '
        'LblForWeight
        '
        Me.LblForWeight.Location = New System.Drawing.Point(191, 127)
        Me.LblForWeight.Size = New System.Drawing.Size(162, 16)
        Me.LblForWeight.Text = "Pile Weight (Per Sq. Yard)"
        '
        'TxtForWeight
        '
        Me.TxtForWeight.Location = New System.Drawing.Point(370, 123)
        Me.TxtForWeight.TabIndex = 1
        '
        'TxtForUnit
        '
        Me.TxtForUnit.AgMandatory = False
        Me.TxtForUnit.Location = New System.Drawing.Point(728, 93)
        Me.TxtForUnit.Visible = False
        '
        'LblUnit
        '
        Me.LblUnit.Location = New System.Drawing.Point(691, 96)
        Me.LblUnit.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(14, 178)
        Me.Pnl1.Size = New System.Drawing.Size(820, 197)
        Me.Pnl1.TabIndex = 2
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(355, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 702
        Me.Label2.Text = "Ä"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(355, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 794
        Me.Label13.Text = "Ä"
        '
        'TxtDesign
        '
        Me.TxtDesign.AgMandatory = True
        Me.TxtDesign.AgMasterHelp = False
        Me.TxtDesign.AgNumberLeftPlaces = 0
        Me.TxtDesign.AgNumberNegetiveAllow = False
        Me.TxtDesign.AgNumberRightPlaces = 0
        Me.TxtDesign.AgPickFromLastValue = False
        Me.TxtDesign.AgRowFilter = ""
        Me.TxtDesign.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDesign.AgSelectedValue = Nothing
        Me.TxtDesign.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDesign.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDesign.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDesign.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesign.Location = New System.Drawing.Point(370, 101)
        Me.TxtDesign.MaxLength = 0
        Me.TxtDesign.Multiline = True
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(255, 19)
        Me.TxtDesign.TabIndex = 792
        '
        'LblBuyerCity
        '
        Me.LblBuyerCity.AutoSize = True
        Me.LblBuyerCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerCity.Location = New System.Drawing.Point(191, 101)
        Me.LblBuyerCity.Name = "LblBuyerCity"
        Me.LblBuyerCity.Size = New System.Drawing.Size(82, 16)
        Me.LblBuyerCity.TabIndex = 793
        Me.LblBuyerCity.Text = "Design Code"
        '
        'FrmDesignConsumption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(857, 469)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtDesign)
        Me.Controls.Add(Me.LblBuyerCity)
        Me.Controls.Add(Me.Label2)
        Me.LogLineTableCsv = "BomDetail_Log"
        Me.LogTableName = "BOM_Log"
        Me.MainLineTableCsv = "BomDetail"
        Me.MainTableName = "BOM"
        Me.Name = "FrmDesignConsumption"
        Me.Text = "Design Consumption Master"
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
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerCity, 0)
        Me.Controls.SetChildIndex(Me.TxtDesign, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    
    Private Sub FrmDesignConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.GridDesign(Dgl1)
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgL.WinSetting(Me, 503, 865, 0, 0)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter
        Try
            Select Case sender.name
                Case TxtDescription.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter

        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.CurrentCell.ColumnIndex
                Case Col1Item
                    Dgl1.AgRowFilter(Col1Item) = " IsNull(IsDeleted,0) = 0 And ItemType = '" & ClsMain.ItemType.YarnSKU & "' And " & ClsMain.RetDivFilterStr & ""
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProcGetShade(ByVal bRowIndex As Integer)

        Dim DsTemp As DataSet = Nothing
        Try
            mQry = "SELECT S.Description As SHADE, S.Colour, S.Pantone " & _
                    " FROM RUG_YarnSKU Ys " & _
                    " LEFT JOIN RUG_SHADE S ON Ys.SHADE = S.Code " & _
                    " WHERE Ys.Code = '" & DGL1.AgSelectedValue(Col1Item, bRowIndex) & "'"
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    DGL1.Item(Col1Shade, bRowIndex).Value = AgL.XNull(.Rows(0)("Pantone"))
                    Dgl1.Item(Col1Colour, bRowIndex).Value = AgL.XNull(.Rows(0)("Colour"))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex
            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Item
                    If DGL1.Item(Col1Item, mRowIndex).Value <> "" Then
                        ProcGetShade(mRowIndex)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmDesignConsumption_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        Dim DsTemp As DataSet


        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select Design " & _
                " From BOM Where Code='" & SearchCode & "'"
        Else
            mQry = "Select Design " & _
                " From BOM_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If DsTemp.Tables(0).Rows.Count > 0 Then
                TxtDesign.AgSelectedValue = AgL.XNull(.Rows(0)("Design"))
            End If
        End With

        With DGL1
            For I = 0 To .Rows.Count - 1
                ProcGetShade(I)
            Next
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub FrmDesignConsumption_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT D.Code, D.ManualCode AS [Design Code], D.Construction, q.ManualCode AS [Quality], D.Carpet_Colour AS Colour, D.Carpet_Collection AS Collection, D.Carpet_Style AS [Style], D.Div_Code, D.PileWeight, D.Status, IsNull(D.IsDeleted,0) as IsDeleted  " & _
             "FROM RUG_Design D " & _
             "LEFT JOIN RUG_Quality q ON D.QualityCode = Q.Code " & _
             "Order By D.ManualCode "
        TxtDesign.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT 'Ground' AS Code,'Ground' AS [Apply IN] UNION ALL SELECT 'Design' AS Code,'Design' AS [Apply IN] "
        DGL1.AgHelpDataSet(Col1ApplyIn) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TxtDesign_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDesign.Enter
        Select Case sender.name
            Case TxtDesign.Name
                TxtDesign.AgRowFilter = "Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "'  And IsDeleted = 0 And " & ClsMain.RetDivFilterStr & ""
        End Select
    End Sub


    Private Sub TxtDesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDesign.Validating
        Dim DrTemp As DataRow()
        Select Case sender.name
            Case TxtDesign.Name
                If sender.text.ToString.Trim <> "" Then
                    If sender.AgHelpDataSet IsNot Nothing Then
                        TxtDescription.Text = TxtDesign.Text
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                        TxtForWeight.Text = AgL.VNull(DrTemp(0)("PileWeight"))
                    End If
                End If
        End Select

    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtDesign.Focus()
    End Sub

    Private Sub FrmDesignConsumption_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        mQry = "Select Code As SearchCode " & _
                " From BOM " & _
                " WHERE IsNull(IsDeleted,0)=0 And Design Is Not Null " & _
                " Order By Description "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)

    End Sub



    Private Sub FrmDesignConsumption_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        mQry = "Select UID As SearchCode " & _
                " From BOM_Log " & _
                " WHERE IsNull(IsDeleted,0)=0 And Design Is Not Null " & _
                " Order By Description "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)

    End Sub
End Class
