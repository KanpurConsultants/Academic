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
            StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
            If AgL.PubDivisionList = "('')" Then AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"
        End If
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuPickupPointMaster.Name
                    FrmObj = New FrmAreamast(StrUserPermission, DTUP)

                Case MDI.MnuRouteMaster.Name
                    FrmObj = New FrmRouteMast(StrUserPermission, DTUP)

                Case MDI.MnuVehicleMaster.Name
                    FrmObj = New FrmVehicle(StrUserPermission, DTUP)

                Case MDI.MnuExpenseMaster.Name
                    FrmObj = New FrmExpense(StrUserPermission, DTUP)

                Case MDI.MnuDriverMaster.Name
                    FrmObj = New FrmDriver(StrUserPermission, DTUP)

                Case MDI.MnuVehicleRouteAllotmentEntry.Name
                    FrmObj = New FrmVehicleRoute(StrUserPermission, DTUP)

                Case MDI.MnuMaintenanceExpenseReminder.Name
                    FrmObj = New FrmMaintinanceReminder()

                Case MDI.MnuMemberMaster.Name
                    FrmObj = New FrmBuyerMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBuyerMaster).FrmType = AgTemplate.TempMaster.EntryPointType.Log

                Case MDI.MnuVehicleMaintenanceExpenseEntry.Name
                    FrmObj = New FrmVehicleMaintenanceExpense(StrUserPermission, DTUP)
                    CType(FrmObj, FrmVehicleMaintenanceExpense).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuVehicleGateEntry.Name
                    FrmObj = New FrmVehicleGateInOut(StrUserPermission, DTUP)

                Case MDI.MnuAttendanceEntry.Name
                    FrmObj = New FrmMemberAttendance(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMemberAttendance).FrmType = ClsMain.EntryPointType.Log

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

