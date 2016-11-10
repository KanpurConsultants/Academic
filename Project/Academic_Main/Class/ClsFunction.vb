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
        End If
        ''For User Permission End

        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuAmSessionProgrammeMaster.Name
                    FrmObj = New FrmSessionProgramme(StrUserPermission, DTUP)

                Case MDI.MnuAmStreamYearSemesterSubjectMaster.Name
                    FrmObj = New FrmStreamYearSemesterSubject(StrUserPermission, DTUP)

                Case MDI.MnuAmRegistrationEntry.Name, MDI.MnuRegistrationEntryAuthenticated.Name
                    FrmObj = New FrmRegistrationEntry(StrUserPermission, DTUP)

                    If AgL.StrCmp(StrSender, MDI.MnuAmRegistrationEntry.Name) Then
                        CType(FrmObj, FrmRegistrationEntry).FormType = FrmRegistrationEntry.eFormType.RegistrationEntry

                    ElseIf AgL.StrCmp(StrSender, MDI.MnuRegistrationEntryAuthenticated.Name) Then
                        CType(FrmObj, FrmRegistrationEntry).FormType = FrmRegistrationEntry.eFormType.RegistrationEntryAuthenticated
                    End If

                Case MDI.MnuAmRegistrationCancelEntry.Name, MDI.MnuRegistrationCancelEntryAuthenticated.Name
                    FrmObj = New FrmRegistrationCancelEntry(StrUserPermission, DTUP)

                    If AgL.StrCmp(StrSender, MDI.MnuAmRegistrationCancelEntry.Name) Then
                        CType(FrmObj, FrmRegistrationCancelEntry).FormType = FrmRegistrationCancelEntry.eFormType.RegistrationCancelEntry

                    ElseIf AgL.StrCmp(StrSender, MDI.MnuRegistrationCancelEntryAuthenticated.Name) Then
                        CType(FrmObj, FrmRegistrationCancelEntry).FormType = FrmRegistrationCancelEntry.eFormType.RegistrationCancelEntryAuthenticated
                    End If

                Case MDI.MnuAmStudentMaster.Name
                    FrmObj = New FrmStudentMaster(StrUserPermission, DTUP)
                    'FrmObj = New FrmCanteenSale(StrUserPermission, DTUP)

                Case MDI.MnuAmAdmissionEntry.Name, MDI.MnuAdmissionEntryAuthenticated.Name
                    FrmObj = New FrmAdmissionEntry(StrUserPermission, DTUP)

                    If AgL.StrCmp(StrSender, MDI.MnuAmAdmissionEntry.Name) Then
                        CType(FrmObj, FrmAdmissionEntry).FormType = FrmAdmissionEntry.eFormType.AdmissionEntry

                    ElseIf AgL.StrCmp(StrSender, MDI.MnuAdmissionEntryAuthenticated.Name) Then
                        CType(FrmObj, FrmAdmissionEntry).FormType = FrmAdmissionEntry.eFormType.AdmissionEntryAuthenticated
                    End If

                Case MDI.MnuAmSectionMaster.Name
                    FrmObj = New FrmClassSection(StrUserPermission, DTUP)

                Case MDI.MnuAmSectionAssignEntry.Name
                    FrmObj = New FrmSectionAssignEntry(StrUserPermission, DTUP)

                Case MDI.MnuAmOpenElectiveSectionAssignEntry.Name
                    FrmObj = New FrmOpenElectiveSectionAssignEntry(StrUserPermission, DTUP)

                Case MDI.MnuAmTeacherMaster.Name
                    FrmObj = New FrmTeacher(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentAttendanceEntry.Name
                    FrmObj = New FrmStudentAttendance(StrUserPermission, DTUP)

                Case MDI.MnuAmSubjectSwapEntry.Name
                    FrmObj = New FrmSubjectSwap

                Case MDI.MnuAmEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuAmSubSectionAssignEntry.Name
                    FrmObj = New FrmSubSectionAssignEntry(StrUserPermission, DTUP)

                Case MDI.MnuAmOpenElectiveSubSectionAssignEntry.Name
                    FrmObj = New FrmOpenElectiveSubSectionAssignEntry(StrUserPermission, DTUP)

                Case MDI.MnuAmEnrollmentNoAssignEntry.Name
                    FrmObj = New FrmEnrollmentNoAssign(StrUserPermission, DTUP)

                Case MDI.MnuAmRollNoAssignEntry.Name
                    FrmObj = New FrmRollNoAssign(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentLeftEntry.Name
                    FrmObj = New FrmStudentLeft(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentPromotionEntry.Name
                    If AgLibrary.ClsConstant.BlnManageUserControl Then
                        FrmObj = New FrmStudentPromotion()
                    Else
                        If MsgBox("This Is A Very Critical Section!..." & vbCrLf & "It Is Suggested To Take Backup Before Proceeding!..." & vbCrLf & "Want To Continue?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                            FrmObj = Nothing
                        Else
                            FrmObj = New FrmStudentPromotion()
                        End If
                    End If

                Case MDI.MnuAmOCAssignEntry.Name
                    FrmObj = New FrmSessionProgrammeStreamOC(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentLeaveEntry.Name
                    FrmObj = New FrmStudentLeave(StrUserPermission, DTUP)

                Case MDI.MnuStatusChangeEntry.Name, MDI.MnuStatusChangeEntryAuthenticated.Name
                    FrmObj = New FrmStatusChange(StrUserPermission, DTUP)

                    If AgL.StrCmp(StrSender, MDI.MnuStatusChangeEntry.Name) Then
                        CType(FrmObj, FrmStatusChange).FormType = FrmStatusChange.eFormType.StatusChange

                    ElseIf AgL.StrCmp(StrSender, MDI.MnuStatusChangeEntryAuthenticated.Name) Then
                        CType(FrmObj, FrmStatusChange).FormType = FrmStatusChange.eFormType.StatusChangeAuthenticated
                    End If

                Case MDI.MnuStudentFamilyIncomeEntry.Name
                    FrmObj = New FrmStudentFamilyIncome(StrUserPermission, DTUP)

                Case MDI.MnuSubjectChangeEntry.Name
                    FrmObj = New FrmStudentSubjectChange(StrUserPermission, DTUP)

                Case MDI.MnuDocumentIssueEntry.Name
                    FrmObj = New FrmDocumentIssue(StrUserPermission, DTUP)

                Case MDI.MnuTeacherAssessmentEntry.Name
                    FrmObj = New FrmTeacherAssessmentEntry(StrUserPermission, DTUP)

                Case MDI.MnuElectiveSubjectAssignEntry.Name
                    FrmObj = New FrmElectiveSubjectAssign(StrUserPermission, DTUP)
                    CType(FrmObj, FrmElectiveSubjectAssign).FormType = FrmElectiveSubjectAssign.eFormType.ElectiveSubjectAssign

                Case MDI.MnuSemesterSubjectAssignEntry.Name
                    FrmObj = New FrmSemesterSubjectAssign(StrUserPermission, DTUP)

                Case MDI.MnuTutorialSheetEntry.Name
                    FrmObj = New FrmTutorialSheet(StrUserPermission, DTUP)
                    CType(FrmObj, FrmTutorialSheet).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuAssignmentSheetEntry.Name
                    FrmObj = New FrmAssignmentSheet(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAssignmentSheet).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuAcademicProgressTheory.Name
                    FrmObj = New FrmAcademicProgressTheory(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAcademicProgressTheory).FormType = Academic_ProjLib.TempTransaction.eFormType.Main                    

                Case MDI.MnuAcademicProgressLaboratory.Name
                    FrmObj = New FrmAcademicProgressLaboratory(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAcademicProgressLaboratory).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuLecturePlanEntry.Name
                    FrmObj = New FrmLecturePlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmLecturePlan).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuLabStautsEntry.Name
                    FrmObj = New FrmLabStatus(StrUserPermission, DTUP)
                    CType(FrmObj, FrmLabStatus).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuLabWorkEntry.Name
                    FrmObj = New FrmLabWork(StrUserPermission, DTUP)
                    CType(FrmObj, FrmLabWork).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuYearEndUpdaton.Name
                    FrmObj = New FrmYearEnd

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

