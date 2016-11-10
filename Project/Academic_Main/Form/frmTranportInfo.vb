Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTransportInfo
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim _EntryMode As String = "Browse"
    'Dim StrMemberCardNo$ = "", StrCardPrefix$ = "", StrValidTillDate$ = "", StrVehicle$ = "", StrSeatNo$ = "", StrRoute$ = "", StrPickupPoint$ = ""
    'Dim StrCardSrNo% = 0
    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim mfrmobj As Form = Nothing
    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FrmObj() As Form
        Get
            FrmObj = mFrmObj
        End Get
        Set(ByVal value As Form)
            mFrmObj = value
        End Set
    End Property
    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim StrUPVar As String = "A***", DTUP As DataTable = Nothing
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub
    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
       TxtRoute.Validating, TxtPickUpPoint.Validating, TxtVehicle.Validating, TxtSeatNo.Validating, _
        TxtCardPrefix.Validating, TxtCardSrNo.Validating, TxtMemberCardNo.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

            Select Case sender.NAME

                Case TxtMemberCardNo.Name, TxtCardPrefix.Name, TxtCardSrNo.Name
                    TxtMemberCardNo.Text = TxtCardPrefix.Text + "-" + TxtCardSrNo.Text
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        '<Executable Code>
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 Then
            Topctrl1.TopKey_Down(e)
        End If

        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 273, 500, _FormLocation.Y, _FormLocation.X)
            Me.StartPosition = FormStartPosition.CenterScreen
            FIniMaster()
            Ini_List()
            DispText()
            ProcFill()
            DispText()
            TxtCardPrefix.Focus()
            If AgL.StrCmp(_EntryMode, "Add") Then
                Topctrl1.FButtonClick(0)
                TxtCardSrNo.Enabled = False
                TxtCardPrefix.Text = Year(AgL.PubStartDate)
                Call MemberCardNo()
            Else
                'MoveRec()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        'Dim bCondStr$ = " WHERE 1=2 "
      
    End Sub
    Private Sub ProcFill()
        Dim I As Integer = 0
        Try
            If FrmObj Is Nothing Then Exit Sub
            'With CType(frmobj, FrmTransportInfo)
            TxtMemberCardNo.Text = CType(FrmObj, FrmTransportInfo).TxtMemberCardNo.Text
            TxtCardPrefix.Text = CType(FrmObj, FrmTransportInfo).TxtCardPrefix.Text
            TxtCardSrNo.Text = CType(FrmObj, FrmTransportInfo).TxtCardSrNo.Text
            TxtRoute.AgSelectedValue = CType(FrmObj, FrmTransportInfo).TxtRoute.AgSelectedValue
            TxtPickUpPoint.AgSelectedValue = CType(FrmObj, FrmTransportInfo).TxtPickUpPoint.AgSelectedValue
            TxtSeatNo.Text = CType(FrmObj, FrmTransportInfo).TxtSeatNo.Text
            TxtVehicle.AgSelectedValue = CType(FrmObj, FrmTransportInfo).TxtVehicle.AgSelectedValue
            TxtValidTillDate.Text = CType(FrmObj, FrmTransportInfo).TxtValidTillDate.Text
            'End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Ini_List()
        Try
            mQry = "SELECT R.Code, R.Description AS Name FROM Sch_Route R ORDER BY R.Description "
            TxtRoute.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V.Code  As Code, V.RegistrationNo As [Vehicle No], V.Description As [Vehicle Name] " & _
              " From Tp_Vehicle V " & _
              " Order By V.RegistrationNo "
            TxtVehicle.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select S.Code  As Code, S.Description As Name, S.ManualCode As [Short Name] " & _
             " From Sch_Area S " & _
             " Order By S.ManualCode "
            TxtPickUpPoint.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        DispText(True)
        TxtCardPrefix.Focus()
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        '<Executable code>
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
        DispText(False)
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        '<Executable code>
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        '<Executable code>
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        '<Executblae Code>
    End Sub
    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, bDtTemp As DataTable = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False

        Try
            FClear()
            'BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If

            If mSearchCode <> "" Then
                '<Executable Code>
            Else
                'BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            Topctrl1.tPrn = False
        End Try
    End Sub
    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
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

    Private Function Data_Validation() As Boolean
        Try
            'Call Calculation()

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
    Private Sub Calculation()
        '<Executbale code>
    End Sub
    Public Function MemberCardNo() As Integer
        Dim SrNo% = 0
        Try
            mQry = "select isnull(max(CardSrNo),0) From Tp_Member where CardPrefix=" & AgL.Chk_Text(TxtCardPrefix.Text) & ""
            SrNo = Val(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)
            If SrNo = 0 Then
                SrNo = 1
            Else
                SrNo = Val(SrNo%) + 1
            End If
            TxtCardSrNo.Text = Val(SrNo)
        Catch ex As Exception
            SrNo = ""
        Finally
            MemberCardNo = SrNo
        End Try
    End Function

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Select Case sender.name
                'Case TxtCostCenter.Name
                '    sender.AgRowFilter = " IsActive = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name

        End Select
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
End Class