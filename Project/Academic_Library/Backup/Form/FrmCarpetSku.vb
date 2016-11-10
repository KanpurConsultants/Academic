Public Class FrmCarpetSku
    Inherits AgTemplate_Common.TempItem

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmCarpetSku_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation

    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainLineTableCsv = "ItemBuyer,RUG_CarpetSku"
        LogLineTableCsv = "ItemBuyer_Log,RUG_CarpetSku_Log"
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.CarpetSKU & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.UID, I.Description [Sku Description], " & _
                        " D.Description as Design , S.Description AS Size " & _
                        " FROM RUG_CarpetSku_Log Cs " & _
                        " LEFT JOIN Item_Log I ON Cs.UID = I.UID" & _
                        " LEFT JOIN Rug_Design D On Cs.Design = D.Code " & _
                        " LEFT JOIN Rug_Size S On Cs.Size = S.Code " & mConStr & _
                        " And I.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Sku Description]"
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.CarpetSKU & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.Code, I.Description [Sku Description], " & _
                        " D.Description as Design , S.Description AS Size " & _
                        " FROM Rug_CarpetSku CS " & _
                        " LEFT JOIN Item I On Cs.Code = I.Code " & _
                        " LEFT JOIN Rug_Design D On Cs.Design = D.Code " & _
                        " LEFT JOIN Rug_Size S On Cs.Size = S.Code " & mConStr & _
                        " And IsNull(I.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Sku Description]"
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code as Code, ManualCode as Design_Code,  " & _
                " IsNull(IsDeleted,0) As IsDeleted, Status, Div_Code " & _
                " From Rug_Design  " & _
                " Order By Description"
        TxtDesign.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code as Code, Description as Size, " & _
                "  IsNull(IsDeleted,0) As IsDeleted, IsNull(Status,'Active') As Status , Div_Code " & _
                "  From Rug_Size  " & _
                "  Order By Description"
        TxtSize.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.CarpetSKU & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.Code As SearchCode " & _
            " From Item I " & mConStr & _
            " And IsNull(I.IsDeleted,0)=0 Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.CarpetSKU & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.UID As SearchCode " & _
               " From Item_log I " & mConStr & _
               " And I.EntryStatus='" & LogStatus.LogOpen & "' Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE Item_Log " & _
                " SET " & _
                " ItemType = " & AgL.Chk_Text(ClsMain.ItemType.CarpetSKU) & " , " & _
                " Unit = 'Pcs'  " & _
                " Where UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "DELETE FROM RUG_CarpetSku_Log Where Uid = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = " INSERT INTO RUG_CarpetSku_Log(UID, Code, Design, Size) " & _
                " VALUES (" & AgL.Chk_Text(mSearchCode) & "," & AgL.Chk_Text(mInternalCode) & ", " & _
                " " & AgL.Chk_Text(TxtDesign.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtSize.AgSelectedValue) & ")"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmDesignConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.GridDesign(Dgl1)
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgL.WinSetting(Me, 481, 870, 0, 0)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter, TxtManualCode.Enter, TxtDesign.Enter, TxtSize.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name
                    sender.AgRowFilter = " ItemType =  '" & ClsMain.ItemType.CarpetSKU & "' And " & ClsMain.RetDivFilterStr & "  "
                Case TxtDesign.Name
                    sender.AgRowFilter = " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And IsDeleted=0 And " & ClsMain.RetDivFilterStr & "  "
                Case TxtSize.Name
                    sender.AgRowFilter = " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And IsDeleted=0 And " & ClsMain.RetDivFilterStr & "  "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select Cs.* " & _
                " From Rug_CarpetSku Cs " & _
                " Where Cs.Code='" & SearchCode & "'"
        Else
            mQry = "Select Cs.* " & _
                " From Rug_CarpetSku_Log Cs " & _
                " Where Cs.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDesign.AgSelectedValue = AgL.XNull(.Rows(0)("Design"))
                TxtSize.AgSelectedValue = AgL.XNull(.Rows(0)("Size"))
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtDesign.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtDesign.Focus()
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.LblSizeReq = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSize = New AgControls.AgTextBox
        Me.LblSize = New System.Windows.Forms.Label
        Me.TxtDesign = New AgControls.AgTextBox
        Me.LblDesign = New System.Windows.Forms.Label
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
        Me.LblDescription.Location = New System.Drawing.Point(195, 96)
        Me.LblDescription.Size = New System.Drawing.Size(35, 16)
        Me.LblDescription.Text = "SKU"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(292, 95)
        Me.TxtDescription.Size = New System.Drawing.Size(375, 20)
        Me.TxtDescription.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(276, 103)
        '
        'TxtUnit
        '
        Me.TxtUnit.Location = New System.Drawing.Point(101, 74)
        Me.TxtUnit.Size = New System.Drawing.Size(22, 20)
        Me.TxtUnit.Visible = False
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(92, 64)
        Me.LblManualCodeReq.Visible = False
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = False
        Me.TxtManualCode.Location = New System.Drawing.Point(108, 56)
        Me.TxtManualCode.Size = New System.Drawing.Size(27, 20)
        Me.TxtManualCode.Visible = False
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(28, 60)
        Me.LblManualCode.Visible = False
        '
        'TxtUPCCode
        '
        Me.TxtUPCCode.Location = New System.Drawing.Point(292, 117)
        Me.TxtUPCCode.TabIndex = 4
        '
        'LblUPCCode
        '
        Me.LblUPCCode.Location = New System.Drawing.Point(195, 120)
        '
        'TxtSalesTaxPostingGroup
        '
        Me.TxtSalesTaxPostingGroup.Location = New System.Drawing.Point(534, 117)
        Me.TxtSalesTaxPostingGroup.Size = New System.Drawing.Size(133, 20)
        Me.TxtSalesTaxPostingGroup.TabIndex = 5
        '
        'LblSalesTaxPostingGroup
        '
        Me.LblSalesTaxPostingGroup.Location = New System.Drawing.Point(427, 118)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(126, 176)
        Me.Pnl1.Size = New System.Drawing.Size(611, 171)
        Me.Pnl1.TabIndex = 6
        Me.Pnl1.Visible = True
        '
        'LblUnit
        '
        Me.LblUnit.Location = New System.Drawing.Point(64, 78)
        Me.LblUnit.Visible = False
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(862, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 400)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(148, 400)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(554, 400)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(401, 400)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(704, 400)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(278, 400)
        '
        'LblSizeReq
        '
        Me.LblSizeReq.AutoSize = True
        Me.LblSizeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSizeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSizeReq.Location = New System.Drawing.Point(518, 82)
        Me.LblSizeReq.Name = "LblSizeReq"
        Me.LblSizeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSizeReq.TabIndex = 700
        Me.LblSizeReq.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(276, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 699
        Me.Label2.Text = "Ä"
        '
        'TxtSize
        '
        Me.TxtSize.AgMandatory = True
        Me.TxtSize.AgMasterHelp = False
        Me.TxtSize.AgNumberLeftPlaces = 0
        Me.TxtSize.AgNumberNegetiveAllow = False
        Me.TxtSize.AgNumberRightPlaces = 0
        Me.TxtSize.AgPickFromLastValue = False
        Me.TxtSize.AgRowFilter = ""
        Me.TxtSize.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSize.AgSelectedValue = Nothing
        Me.TxtSize.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSize.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSize.Location = New System.Drawing.Point(534, 73)
        Me.TxtSize.MaxLength = 20
        Me.TxtSize.Multiline = True
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(133, 20)
        Me.TxtSize.TabIndex = 2
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSize.Location = New System.Drawing.Point(427, 76)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(34, 16)
        Me.LblSize.TabIndex = 698
        Me.LblSize.Text = "Size"
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
        Me.TxtDesign.Location = New System.Drawing.Point(292, 73)
        Me.TxtDesign.MaxLength = 20
        Me.TxtDesign.Multiline = True
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(129, 20)
        Me.TxtDesign.TabIndex = 1
        '
        'LblDesign
        '
        Me.LblDesign.AutoSize = True
        Me.LblDesign.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesign.Location = New System.Drawing.Point(195, 73)
        Me.LblDesign.Name = "LblDesign"
        Me.LblDesign.Size = New System.Drawing.Size(48, 16)
        Me.LblDesign.TabIndex = 697
        Me.LblDesign.Text = "Design"
        '
        'FrmCarpetSku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 447)
        Me.Controls.Add(Me.LblSizeReq)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.LblSize)
        Me.Controls.Add(Me.TxtDesign)
        Me.Controls.Add(Me.LblDesign)
        Me.LogLineTableCsv = "ItemBuyer_Log"
        Me.LogTableName = "Item_LOG"
        Me.MainLineTableCsv = "ItemBuyer"
        Me.MainTableName = "Item"
        Me.Name = "FrmCarpetSku"
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
        Me.Controls.SetChildIndex(Me.LblDesign, 0)
        Me.Controls.SetChildIndex(Me.TxtDesign, 0)
        Me.Controls.SetChildIndex(Me.LblSize, 0)
        Me.Controls.SetChildIndex(Me.TxtSize, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.LblSizeReq, 0)
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
    Friend WithEvents LblDesign As System.Windows.Forms.Label
    Friend WithEvents TxtDesign As AgControls.AgTextBox
    Friend WithEvents LblSize As System.Windows.Forms.Label
    Friend WithEvents TxtSize As AgControls.AgTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents LblSizeReq As System.Windows.Forms.Label
#End Region

    Private Sub TxtSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSize.Validating
        Try
            Select Case sender.NAME
                Case TxtSize.Name
                    TxtDescription.Text = Replace(Replace(TxtDesign.Text, "-", ""), " ", "") + "-" + Replace(Replace(Replace(TxtSize.Text, " ", ""), ".", ""), "X", "")
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
