Imports System

Public Class FrmLogin
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click, BtnCancel.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim DtTemp As DataTable = Nothing
            Select Case sender.Name
                Case BtnOk.Name
                    If FOpenIniChkPwd() Then
                        If ConnectDb(AgL.PubServerName, AgL.PubCompanyDBName, AgL.PubDBUserSQL, AgL.PubDBPasswordSQL).Trim <> "" Then
                            FrmServerNotFound.Show()
                        Else
                            If FOpenIni(StrPath + "\" + IniName, TxtUserName.Text, TxtPassword.Text) Then
                                If AgL.PubDivisionApplicable Then
                                    DtTemp = AgL.FillData("SELECT D.* FROM Division D", AgL.GcnMain).Tables(0)
                                    If DtTemp.Rows.Count = 1 Then
                                        AgL.PubDivCode = AgL.XNull(DtTemp.Rows(0)("Div_Code"))
                                        AgL.PubDivisionDBName = AgL.XNull(DtTemp.Rows(0)("DataPath"))

                                        FrmCompany.Show()
                                    Else
                                        FrmDivisionSelection.Show()
                                    End If
                                    DtTemp = Nothing
                                Else
                                    FrmCompany.Show()
                                End If

                                Me.Hide()
                            Else
                                TxtPassword.Focus()
                            End If
                        End If
                    End If

                Case BtnCancel.Name
                    Me.Dispose()
                    End
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If System.IO.File.Exists(StrPath + "\" + "SetDate.Exe") Then
            Shell(StrPath + "\" + "SetDate.Exe", AppWinStyle.Hide, True)
        End If

        AgL = New AgLibrary.ClsMain()
        AgL.AglObj = AgL
        AgL.PubIsLogInProjectActive = True
        AgL.PubDivisionApplicable = True

    End Sub

    Private Sub FrmLogin_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'AgL.FPaintForm(Me, e, 0)
        'LogoPictureBox.BackColor = Color.Transparent
    End Sub
    Private Sub TxtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles TxtPassword.KeyPress, TxtUserName.KeyPress

        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If e.KeyChar = Chr(Keys.Enter) And Not (TypeOf sender Is ComboBox) Then SendKeys.Send("{Tab}") : Exit Sub

        Try
            AgL.CheckQuote(e)
        Catch Ex As Exception
            MsgBox("System Exception : " & vbCrLf & Ex.Message, MsgBoxStyle.Exclamation, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
