Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)
        Dim FrmObj As Form
        Dim MDI As New MDIMain

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(Academic_Objects.ClsConstant.Module_Academic_Hostel, StrSender, StrSenderText, DTUP)
        End If
        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuBuildingMaster.Name
                    FrmObj = New FrmBuildingMaster(StrUserPermission, DTUP)

                Case MDI.MnuRoomType.Name
                    FrmObj = New FrmRoomType(StrUserPermission, DTUP)

                Case MDI.MnuRoomMaster.Name
                    FrmObj = New FrmRoom(StrUserPermission, DTUP)

                Case MDI.MnuRoomAllotment.Name
                    FrmObj = New FrmRoomAllotment(StrUserPermission, DTUP)

                Case MDI.MnuHostelMaster.Name
                    FrmObj = New FrmHostelMaster(StrUserPermission, DTUP)

                Case MDI.MnuFloorMaster.Name
                    FrmObj = New FrmFloorMaster(StrUserPermission, DTUP)

                Case MDI.MnuBuildingFloorMaster.Name
                    FrmObj = New FrmBuildingFloorMaster(StrUserPermission, DTUP)

                Case MDI.MnuRoomLeft.Name
                    FrmObj = New FrmRoomLeft(StrUserPermission, DTUP)

                Case MDI.MnuRoomTransfer.Name
                    FrmObj = New FrmRoomTransfer(StrUserPermission, DTUP)

                Case MDI.MnuChargeGroupMaster.Name
                    FrmObj = New FrmChargeGroupMaster(StrUserPermission, DTUP)

                Case MDI.MnuChargeMaster.Name
                    FrmObj = New FrmChargeMaster(StrUserPermission, DTUP)

                Case MDI.MnuRoomChargeDueEntry.Name
                    FrmObj = New FrmRoomChargeDue(StrUserPermission, DTUP)

                Case MDI.MnuRoomChargeReceive.Name
                    FrmObj = New FrmRoomChargeReceive(StrUserPermission, DTUP)

                Case MDI.MnuRoomCbargeRefundEntry.Name
                    FrmObj = New FrmRoomChargeRefund(StrUserPermission, DTUP)

                Case MDI.MnuAdvanceReceiveEntry.Name
                    FrmObj = New FrmRoomChargeAdvance(StrUserPermission, DTUP)

                Case MDI.MnuEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuRoomStatusDisplay.Name
                    FrmObj = New FrmRoomStatusDisplay(StrUserPermission, DTUP)

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

