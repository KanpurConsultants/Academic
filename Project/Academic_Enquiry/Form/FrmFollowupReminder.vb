Imports System.Data.SqlClient
Public Class FrmFollowupReminder
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1BtnFollowupEntry As String = "FollowupEntry"
    Protected Const Col1FollowUpDocId As String = "FollowUpDocId"
    Protected Const Col1FollowupNo As String = "Followup No"
    Protected Const Col1FollowupDate As String = "Followup Date"
    Protected Const Col1FollowupBy As String = "Followup By"
    Protected Const Col1NextFollowupDate As String = "Next Followup Date"
    Protected Const Col1EnquiryNo As String = "Enquiry No"
    Protected Const Col1EnquiryBy As String = "Enquiry By"
    Protected Const Col1PersonMet As String = "Person Met"
    Protected Const Col1FollowerRemark As String = "Follower Remark"
    Protected Const Col1FollowupMode As String = "Followup Mode"
    Protected Const Col1EnquiryDocId As String = "EnquiryDocId"

    Dim mBlnRefreshFlag As Boolean = False

    Private Enum FilterType
        Similer
        Dissimilar
        Remove
    End Enum

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FrmFollowupReminder_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If mBlnRefreshFlag Then
                Call ProcFillGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Fee Due Data Grid >====================================
        ''==============================================================================

        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 30
        DGL1.AllowUserToAddRows = False
        DGL1.ContextMenuStrip = CMnu
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Topctrl1.TopKey_Down(e)
        End If
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If

            'If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)

        Try
            Me.Cursor = Cursors.WaitCursor
            'If Topctrl1.Mode = "Browse" Then Exit Sub

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.GridDesign(DGL1)
            IniGrid()
            Ini_List()
            DispText()
            Topctrl1.Mode = "Add"
            Call ProcFillGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                'Case Col1AdmissionDocId
                '<Executable Code>
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            'sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim DrTemp As DataRow() = Nothing
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                '<Executable Code>
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        'sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        'AgL.FSetSNo(sender, Col_SNo)
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSite_Code.Enter
        Try
            Select Case sender.name
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSite_Code.Validating, TxtV_Date.Validating
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    Call ProcFillGrid()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        DGL1.DataSource = Nothing
        DGL1.Columns.Clear()
        Me.Visible = False
    End Sub

    Private Sub ProcFillGrid(Optional ByVal StrFilterField As String = "", _
                                        Optional ByVal StrFilterValue As String = "", _
                                        Optional ByVal eFilterType As FilterType = FilterType.Remove)
        Dim DsTemp As DataSet = Nothing
        Dim bStrHeaderQry$ = "", bStrLastFollowupQry$ = ""
        Dim bCondStrMain$ = " Where 1=1 ", bCondStr$ = " Where 1=1 "

        Dim I As Integer = 0
        Dim ObjRepFormGlobal As AgLibrary.RepFormGlobal
        Dim CRepProc As ClsReportProcedures
        Try
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)

            If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

            DGL1.DataSource = Nothing
            DGL1.Columns.Clear()

            If eFilterType = FilterType.Similer Then
                If StrFilterField.Trim <> "" Then
                    bCondStr += " And vH.[" & StrFilterField & "] = " & AgL.Chk_Text(StrFilterValue) & " "
                End If
            ElseIf eFilterType = FilterType.Dissimilar Then
                If StrFilterField.Trim <> "" Then
                    bCondStr += " And vH.[" & StrFilterField & "] <> " & AgL.Chk_Text(StrFilterValue) & " "
                End If
            End If


            bCondStrMain += " And IsNull(H.IsClosed,0) = 0 " & _
                                " AND H.NextFollowUpDate IS NOT NULL  " & _
                                " AND " & AgL.ConvertDate(TxtV_Date.Text) & " BETWEEN  Dateadd(day, H.RemindBeforeDays * -1, H.NextFollowUpDate) AND Dateadd(day, H.RemindAfterDays , H.NextFollowUpDate) "

            bStrLastFollowupQry = "SELECT F.EnquiryDocId, Max(F.V_Date) AS LastFollowupDate, Max(F.RowId) AS LastFollowupRowId " & _
                                    " FROM Enquiry_FollowUp F " & _
                                    " Where 1=1   " & _
                                    " And IsNull(F.IsClosed,0) = 0 " & _
                                    " AND F.NextFollowUpDate IS NOT NULL " & _
                                    " AND F.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                                    " GROUP BY F.EnquiryDocId  "

            bStrHeaderQry = " SELECT H.DocId AS FollowUpDocId, " & _
                                " " & AgL.V_No_Field("H.EnquiryDocId") & " As [" & Col1EnquiryNo & "], " & _
                                " isnull(E.FirstName,'') +' '+ isnull(E.MiddleName,'') +' '+ isnull(E.LastName,'') AS [" & Col1EnquiryBy & "], " & _
                                " " & AgL.V_No_Field("H.DocId") & " As [" & Col1FollowupNo & "], " & _
                                " " & AgL.ConvertDateField("H.V_Date") & " AS [" & Col1FollowupDate & "], " & _
                                " SG.DispName AS [" & Col1FollowupBy & "], " & _
                                " " & AgL.ConvertDateField("H.NextFollowUpDate") & " As [" & Col1NextFollowupDate & "], " & _
                                " H.Remark AS [" & Col1FollowerRemark & "], " & _
                                " H.PersonMet AS [" & Col1PersonMet & "]," & _
                                " H.FollowupMode As [" & Col1FollowupMode & "], " & _
                                " H.EnquiryDocId As [" & Col1EnquiryDocId & "]" & _
                                " FROM (Enquiry_FollowUp H " & _
                                " INNER JOIN (" & bStrLastFollowupQry & ") AS vF ON vF.LastFollowupRowId = H.RowId) " & _
                                " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee  " & _
                                " LEFT JOIN Enquiry_Enquiry E ON E.DocId=H.EnquiryDocId " & _
                                " " & bCondStrMain & " "

            mQry = "Select vH.* " & _
                    " From (" & bStrHeaderQry & ") as vH " & _
                    " " & bCondStr & " Order By Convert(SmallDateTime,[" & Col1FollowupDate & "]) "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            DGL1.DataSource = DsTemp.Tables(0)
            Call AdjustGrid()
        Catch ex As Exception
            DGL1.DataSource = Nothing
            MsgBox(ex.Message)
        Finally
            CRepProc = Nothing : ObjRepFormGlobal = Nothing
            mBlnRefreshFlag = False
        End Try
    End Sub

    Private Sub DGL1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        Dim FrmObj As Form = Nothing
        Dim MdiObj As New MDIMain
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1BtnFollowupEntry
                    StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, MdiObj.MnuEnquiryFollowup.Name, MdiObj.MnuEnquiryFollowup.Text, DTUP)
                    If StrUserPermission.IndexOf("A") >= 0 Then
                        FrmObj = New FrmFollowupEntry(StrUserPermission, DTUP)
                    End If
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmFollowupEntry).EnquiryDocId = AgL.XNull(DGL1.Item(Col1EnquiryDocId, DGL1.CurrentRow.Index).Value)
                        CType(FrmObj, FrmFollowupEntry).EntryMode = "Add"

                        FrmObj.Text = MdiObj.MnuEnquiryFollowup.Text
                        FrmObj.MdiParent = Me.MdiParent
                        FrmObj.Show()

                        mBlnRefreshFlag = True
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AdjustGrid()
        Dim bObjCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Try
            With DGL1
                .Columns(Col1FollowUpDocId).Visible = False : .Columns(Col1FollowUpDocId).Width = 0
                .Columns(Col1FollowupNo).Visible = False : .Columns(Col1FollowupNo).Width = 120
                .Columns(Col1FollowupDate).Visible = True : .Columns(Col1FollowupDate).Width = 80
                .Columns(Col1FollowupBy).Visible = True : .Columns(Col1FollowupBy).Width = 120
                .Columns(Col1NextFollowupDate).Visible = True : .Columns(Col1NextFollowupDate).Width = 80
                .Columns(Col1EnquiryNo).Visible = True : .Columns(Col1EnquiryNo).Width = 120
                .Columns(Col1EnquiryBy).Visible = True : .Columns(Col1EnquiryBy).Width = 120
                .Columns(Col1PersonMet).Visible = True : .Columns(Col1PersonMet).Width = 150
                .Columns(Col1FollowerRemark).Visible = True : .Columns(Col1FollowerRemark).Width = 180
                .Columns(Col1FollowupMode).Visible = True : .Columns(Col1FollowupMode).Width = 80
                .Columns(Col1EnquiryDocId).Visible = False : .Columns(Col1FollowupMode).Width = 80

                AgCL.AddAgButtonColumn(DGL1, Col1BtnFollowupEntry, 30, " ", True, False, , , , "Webdings", 10, "6")
                bObjCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                bObjCellStyle = Nothing


                DGL1.ColumnHeadersHeight = 50
                DGL1.AllowUserToAddRows = False
                DGL1.EnableHeadersVisualStyles = False

                DGL1.Columns(Col1FollowerRemark).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders

                DGL1.ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CMnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                mnuFilterSame.Click, mnuFilterNotSame.Click, mnuRemoveFilter.Click
        Dim bStrFilterField$ = "", bStrFilterValue$ = ""
        Try

            If DGL1.DataSource IsNot Nothing Then
                If DGL1.CurrentCell Is Nothing Then
                    If DGL1.Rows.Count > 0 Then
                        DGL1.CurrentCell = DGL1(Col1FollowupDate, 0)
                    End If
                End If
            End If

            If DGL1.CurrentCell IsNot Nothing Then
                bStrFilterField = DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                bStrFilterValue = AgL.XNull(DGL1.Item(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex).Value)
            End If

            Select Case sender.name
                Case mnuFilterSame.Name
                    Call ProcFillGrid(bStrFilterField, bStrFilterValue, FilterType.Similer)

                Case mnuFilterNotSame.Name
                    Call ProcFillGrid(bStrFilterField, bStrFilterValue, FilterType.Dissimilar)

                Case mnuRemoveFilter.Name
                    Call ProcFillGrid("", "", FilterType.Remove)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class