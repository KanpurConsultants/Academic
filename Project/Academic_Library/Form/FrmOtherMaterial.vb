Public Class FrmOtherMaterial
    Inherits AgTemplate.TempItem

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If TxtManualCode.Text.Trim = "" Then Err.Raise(1, , "Item Code Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Item Where ManualCode ='" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Item Code Already Exist!")

            mQry = "Select count(*) From Item_Log Where ManualCode = '" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Item Code Already Exists in Log File")
        Else
            mQry = "Select count(*) From Item Where ManualCode ='" & TxtManualCode.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Item Code Already Exist!")

            mQry = "Select count(*) From Item_Log Where ManualCode = '" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Item Code Already Exists in Log File")
        End If
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Stationary & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.UID, I.ManualCode as [Item Code], I.Description [Item Description], " & _
                        " I.Unit " & _
                        " FROM Item_Log I " & mConStr & _
                        " And I.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Item Description]"
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Stationary & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.Code, I.ManualCode as [Item Code], I.Description [Item Description], " & _
                        " I.Unit " & _
                        " FROM Item I " & mConStr & _
                        " And IsNull(I.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Item Description]"
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Stationary & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.Code As SearchCode " & _
            " From Item I " & mConStr & _
            " And IsNull(I.IsDeleted,0)=0 Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Stationary & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.UID As SearchCode " & _
               " From Item_log I " & mConStr & _
               " And I.EntryStatus='" & LogStatus.LogOpen & "' Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE Item_Log " & _
                " SET " & _
                " ItemType = " & AgL.Chk_Text(ClsMain.ItemType.Stationary) & "  " & _
                " Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmDesignConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 382, 870, 0, 0)
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        Dgl1.Visible = False
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtDescription
        '
        '
        'TxtManualCode
        '
        '
        'TxtUPCCode
        '
        Me.TxtUPCCode.Location = New System.Drawing.Point(104, 122)
        Me.TxtUPCCode.Size = New System.Drawing.Size(66, 18)
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
        Me.TxtSalesTaxPostingGroup.Size = New System.Drawing.Size(77, 18)
        Me.TxtSalesTaxPostingGroup.Visible = False
        '
        'LblSalesTaxPostingGroup
        '
        Me.LblSalesTaxPostingGroup.Location = New System.Drawing.Point(0, 83)
        Me.LblSalesTaxPostingGroup.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(165, 249)
        Me.Pnl1.Size = New System.Drawing.Size(545, 53)
        '
        'TxtItemGroup
        '
        Me.TxtItemGroup.Visible = True
        '
        'Label2
        '
        Me.Label2.Visible = True
        '
        'TxtExciseGroup
        '
        Me.TxtExciseGroup.Location = New System.Drawing.Point(104, 62)
        Me.TxtExciseGroup.Size = New System.Drawing.Size(62, 18)
        '
        'LblExciseGroup
        '
        Me.LblExciseGroup.Location = New System.Drawing.Point(11, 62)
        '
        'TxtEntryTaxGroup
        '
        Me.TxtEntryTaxGroup.Location = New System.Drawing.Point(113, 102)
        Me.TxtEntryTaxGroup.Size = New System.Drawing.Size(77, 18)
        '
        'LblEntryTaxGroup
        '
        Me.LblEntryTaxGroup.Location = New System.Drawing.Point(0, 103)
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
        'FrmOtherMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 391)
        Me.LogLineTableCsv = "ItemBuyer_Log"
        Me.LogTableName = "Item_LOG"
        Me.MainLineTableCsv = "ItemBuyer"
        Me.MainTableName = "Item"
        Me.Name = "FrmOtherMaterial"
        Me.Text = "Other Material Master"
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter, TxtManualCode.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name
                    sender.AgRowFilter = " ItemType =  '" & ClsMain.ItemType.Stationary & "' And " & ClsMain.RetDivFilterStr & "  "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Topctrl1.tPrn = False
    End Sub

End Class
