Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures
   
    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)

        Dim FrmObj As Form
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(Academic_Objects.ClsConstant.Module_Academic_TimeTable, StrSender, StrSenderText, DTUP)
        End If
        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuTimeTableMaster.Name
                    FrmObj = New FrmTimeTable(StrUserPermission, DTUP)

                Case MDI.MnuTeacherAttendance.Name
                    FrmObj = New FrmEmployeeDayAttendance(StrUserPermission, DTUP)

                Case MDI.MnuReallocateTeacherEntry.Name
                    FrmObj = New FrmReallocateTeacher(StrUserPermission, DTUP)

                Case MDI.MnuLeaveEntry.Name
                    FrmObj = New FrmLeaveEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmLeaveEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main
                    CType(FrmObj, FrmLeaveEntry).BlnIsApprovalApply = True

                Case MDI.MnuLeaveEntryAuthenticated.Name
                    FrmObj = New FrmLeaveEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmLeaveEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Approved

                Case Else
                    FrmObj = Nothing
            End Select
        Else
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)
            CRepProc.GRepFormName = Replace(Replace(StrSenderText, "&", ""), " ", "")
            CRepProc.Ini_Grid()
            FrmObj = ObjRepFormGlobal
        End If
        If FrmObj IsNot Nothing Then
            FrmObj.Text = StrSenderText
        End If
        Return FrmObj
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

