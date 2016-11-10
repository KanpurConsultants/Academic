Public Class FrmGodown
    Inherits AgTemplate.TempGodown

    Protected WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Shelf As String = "Shelf"

    Friend WithEvents Pnl1 As System.Windows.Forms.Panel

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Pnl1 = New System.Windows.Forms.Panel
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
        Me.LblDescription.Size = New System.Drawing.Size(83, 16)
        Me.LblDescription.Text = "Almira Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 345)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 349)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 349)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 349)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 349)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(702, 349)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 349)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(229, 163)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(408, 164)
        Me.Pnl1.TabIndex = 683
        '
        'FrmGodown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 393)
        Me.Controls.Add(Me.Pnl1)
        Me.LogTableName = "Godown_LOG"
        Me.MainTableName = "Godown"
        Me.Name = "FrmGodown"
        Me.Controls.SetChildIndex(Me.LblDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtDescription, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
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

    Private Sub FrmGodown_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AgL.WinSetting(Me, 300, 870, 0, 0)
    End Sub

    Private Sub FrmGodown_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        AgL.PubFindQry = " SELECT G.UID As Code, Sm.Name As BranchName , G.Description AS Almira " & _
                        " FROM Godown_Log G " & _
                        " LEFT JOIN SiteMast Sm On G.Site_Code = Sm.Code " & mConStr
        AgL.PubFindQryOrdBy = "[Code]"
    End Sub

    Private Sub FrmGodown_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
        AgL.PubFindQry = " SELECT G.Code, Sm.Name As BranchName  ,  G.Description AS Almira " & _
                        " FROM Godown G " & _
                        " LEFT JOIN SiteMast Sm On G.Site_Code = Sm.Code  " & mConStr
        AgL.PubFindQryOrdBy = "[Code]"
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmGodown_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainLineTableCsv = "GodownSection"
        LogLineTableCsv = "GodownSection_LOG"
        AgL.GridDesign(Dgl1)

        'LblDescription.Text = "Almira Name"


    End Sub

    Private Sub FrmGodown_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        If Topctrl1.Mode = "Edit" Then
            mQry = " DELETE FROM GodownSection_Log WHERE UID= " & AgL.Chk_Text(mSearchCode) & " "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Shelf, I).Value <> "" Then
                mSr += 1
                mQry = " INSERT INTO GodownSection_Log	(	Code,	Section,	UID	) " & _
                        " VALUES ('" & mInternalCode & "'," & AgL.Chk_Text(Dgl1.Item(Col1Shelf, I).Value) & "," & AgL.Chk_Text(mSearchCode) & ") "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmGodown_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        'Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub FrmGodown_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Shelf, 300, 20, Col1Shelf, True, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Pnl1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35

        Ini_List()
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            'Case Col1MemberType
            '    Dgl1.AgRowFilter(Dgl1.Columns(Col1MemberType).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

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

    Private Sub FrmGodown_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * from GodownSection where DocId = '" & SearchCode & "' "
        Else
            mQry = "Select * from GodownSection_Log where UID = '" & SearchCode & "'"
        End If

        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            Dgl1.RowCount = 1
            Dgl1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    Dgl1.Rows.Add()
                    Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                    Dgl1.Item(Col1Shelf, I).Value = AgL.XNull(.Rows(I)("Section"))
                Next I
            End If
        End With
    End Sub

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 427, 870, 0, 0)
    End Sub


End Class
