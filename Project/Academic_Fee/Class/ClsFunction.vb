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
            StrUserPermission = AgIniVar.FunGetUserPermission(Academic_Objects.ClsConstant.Module_Academic_Fee, StrSender, StrSenderText, DTUP)
        End If

        ''For User Permission End 
        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuFmFeeMaster.Name
                    FrmObj = New FrmFee(StrUserPermission, DTUP)
                    'FrmObj = New FrmAdvanceReminder()

                Case MDI.MnuFmFeeGroupMaster.Name
                    FrmObj = New FrmFeeGroup(StrUserPermission, DTUP)

                Case MDI.MnuFmStreamYearSemesterFeeMaster.Name
                    FrmObj = New FrmStreamYearSemesterFee(StrUserPermission, DTUP)

                Case MDI.MnuFmFeeRefundEntry.Name
                    FrmObj = New FrmFeeRefundEntry(StrUserPermission, DTUP)

                Case MDI.MnuFmReceiveEntry.Name
                    FrmObj = New FrmAdvance(StrUserPermission, DTUP)

                Case MDI.MnuFmFeeDueEntry.Name
                    FrmObj = New FrmFeeDueEntry(StrUserPermission, DTUP)

                Case MDI.MnuFeeReAssignEntry.Name
                    FrmObj = New FrmSemesterFeeAssign(StrUserPermission, DTUP)

                Case MDI.MnuFmFeeReceiveEntry.Name
                    FrmObj = New FrmFeeReceiveEntry(StrUserPermission, DTUP)

                Case MDI.MnuFmEnvironmentSettings.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_EnvironmentSettings, Academic_Objects.ClsConstant.MenuText_Main_EnvironmentSettings, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmSessionProgrammeMaster.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_SessionProgrammeMaster, Academic_Objects.ClsConstant.MenuText_Main_SessionProgrammeMaster, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmStreamYearSemesterSubjectMaster.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StreamYearSemesterSubjectMaster, Academic_Objects.ClsConstant.MenuText_Main_StreamYearSemesterSubjectMaster, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmRegistrationEntry.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_RegistrationEntry, Academic_Objects.ClsConstant.MenuText_Main_RegistrationEntry, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuRegistrationEntryAuthenticated.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_RegistrationEntry, Academic_Objects.ClsConstant.MenuText_Main_RegistrationEntry, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmRegistrationCancelEntry.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_RegistrationCancelEntry, Academic_Objects.ClsConstant.MenuText_Main_RegistrationCancelEntry, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmStudentMaster.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StudentMaster, Academic_Objects.ClsConstant.MenuText_Main_StudentMaster, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmAdmissionEntry.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_AdmissionEntry, Academic_Objects.ClsConstant.MenuText_Main_AdmissionEntry, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmStudentLeftEntry.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StudentLeftEntry, Academic_Objects.ClsConstant.MenuText_Main_StudentLeftEntry, MDI, StrUserPermission, DTUP)
                    If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                Case MDI.MnuFmStudentPromotionEntry.Name
                    If AgLibrary.ClsConstant.BlnManageUserControl Then
                        FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StudentPromotionEntry, Academic_Objects.ClsConstant.MenuText_Main_StudentPromotionEntry, MDI, StrUserPermission, DTUP)
                    Else
                        If MsgBox("This Is A Very Critical Section!..." & vbCrLf & "It Is Suggested To Take Backup Before Proceeding!..." & vbCrLf & "Want To Continue?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                            FrmObj = Nothing
                        Else
                            PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StudentPromotionEntry, Academic_Objects.ClsConstant.MenuText_Main_StudentPromotionEntry, MDI, StrUserPermission, DTUP)
                            FrmObj = Nothing
                        End If
                    End If

                    'Case MDI.MnuReverseFeeDue.Name
                    '    FrmObj = New FrmReverseFeeDue(StrUserPermission, DTUP)

                Case MDI.MnuAdvanceReminder.Name
                    FrmObj = New FrmAdvanceReminder()

                Case MDI.MnuScholarshipParameter.Name
                    FrmObj = New FrmScholarShipParameter(StrUserPermission, DTUP)

                Case MDI.MnuScholarshipDemandEntry.Name
                    FrmObj = New FrmScholarshipDemand(StrUserPermission, DTUP)

                Case MDI.MnuScholarshipReceiveEntry.Name, MDI.MnuScholarshipAdjustmentEntry.Name
                    FrmObj = New FrmScholarshipReceive(StrUserPermission, DTUP)

                    If AgL.StrCmp(StrSender, MDI.MnuScholarshipReceiveEntry.Name) Then
                        CType(FrmObj, FrmScholarshipReceive).FormType = FrmScholarshipReceive.eFormType.ScholarshipReceiveEntry

                    ElseIf AgL.StrCmp(StrSender, MDI.MnuScholarshipAdjustmentEntry.Name) Then
                        CType(FrmObj, FrmScholarshipReceive).FormType = FrmScholarshipReceive.eFormType.ScholarshipAdjustmentEntry
                    End If

                Case MDI.MnuFeeStructureChangeEntry.Name
                    FrmObj = New FrmStudentFeeChange(StrUserPermission, DTUP)

                Case MDI.MnuInstallmentCreateEntry.Name
                    FrmObj = New FrmInstallmentCreate(StrUserPermission, DTUP)

                Case MDI.MnuInstallmentReminder.Name
                    FrmObj = New FrmInstallmentReminder()

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

