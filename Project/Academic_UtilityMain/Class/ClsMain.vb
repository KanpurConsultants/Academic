Public Class ClsMain    
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Academic Utility"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)
        ClsVar_Utility = New Utility.ClsMain(AgL)
        ClsVar_AgStructure = New AgStructure.ClsMain(AgL)
        ClsVar_CommonMaster = New Common_Master.ClsMain(AgL)
        'Call IniDtEnviro()
    End Sub

    Public Enum EntryPointType
        Main
        Log
    End Enum

    Public Class LogStatus
        Public Const LogOpen As String = "Open"
        Public Const LogDiscard As String = "Discard"
        Public Const LogApproved As String = "Approved"
    End Class

#Region "Public Help Queries"

    Public Const PubStrHlpQryWashingType As String = "Select 'Normal' as Code, 'Normal' as Description " & _
                                                     " Union All Select 'Antique' as Code, 'Antique' as Description " & _
                                                     " Union All Select 'Herbal' as Code, 'Herbal' as Description " & _
                                                     " Union All Select 'N.A.' as Code, 'N.A.' as Description "



    Public Const PubStrHlpQryClippingType As String = "Select 'High Low' as Code, 'High Low' as Description " & _
                                                      " Union All Select 'Embossing' as Code, 'Embossing' as Description " & _
                                                      " Union All Select 'N.A.' as Code, 'N.A.' as Description "



    Public Const PubStrHlpQryFringesType As String = "Select 'Dyed' as Code, 'Dyed' as Description " & _
                                                      " Union All Select 'Undyed' as Code, 'Undyed' as Description " & _
                                                      " Union All Select 'N.A.' as Code, 'N.A.' as Description "
#End Region

#Region " Structure Update Code "


    Public Sub UpdateTableStructure(ByVal MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            ClsVar_Utility.UpdateTableStructure()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub UpdateTableInitialiser()
        Try

            Call DeleteField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateView()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub DeleteField()
        Try
            'If AgL.IsFieldExist("Student", "Sch_FeeDue1", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_FeeDue1 DROP CONSTRAINT [IX_Sch_FeeDue1]", AgL.GCn)
            '    AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeDue1_Sch_Student", "Sch_FeeDue1")
            '    AgL.DeleteField("Sch_FeeDue1", "Student", AgL.GCn)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            'mQry = "CREATE VIEW dbo.ViewSch_SessionProgramme AS " & _
            '        " SELECT  SP.*, S.ManualCode AS SessionManualCode, S.Description AS SessionDescription, S.StartDate AS SessionStartDate, S.EndDate AS SessionEndDate, P.Description AS ProgrammeDescription, P.ManualCode AS ProgrammeManualCode, P.ProgrammeDuration, P.Semesters AS ProgrammeSemesters, P.SemesterDuration AS ProgrammeSemesterDuration, P.ProgrammeNature , PN.Description AS ProgrammeNatureDescription  , P.ManualCode  +'/' + S.ManualCode   AS SessionProgramme " & _
            '        " FROM Sch_SessionProgramme SP " & _
            '        " LEFT JOIN Sch_Session S ON sp.Session =S.Code  " & _
            '        " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
            '        " LEFT JOIN Sch_ProgrammeNature PN ON P.ProgrammeNature =PN.Code "

            'AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GCn, True)
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GcnSite, True)
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            '===================================================< Sale Order V_Type >===================================================
            'AgL.CreateNCat(AgL.GCn, Carpet_ProjLib.ClsMain.NCat_CarpetSaleOrder, Carpet_ProjLib.ClsMain.Cat_CarpetSaleOrder, "Sale Order", AgL.PubSiteCode)
            'AgL.CreateVType(AgL.GCn, Carpet_ProjLib.ClsMain.NCat_CarpetSaleOrder, Carpet_ProjLib.ClsMain.Cat_CarpetSaleOrder, Carpet_ProjLib.ClsMain.NCat_CarpetSaleOrder, "Sale Order", Carpet_ProjLib.ClsMain.NCat_CarpetSaleOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddNewVoucherReference()
        Try
            'Dim VRefObj As New Carpet_ProjLib.ClsMain.VRef_ReferenceTable

            'VRefObj.VRef_VehicleInsuranceClaimPayment()
            'AgL.AddNewVoucherReference(AgL.GCn, VRefObj.Code, VRefObj.Description, VRefObj.BoundField, VRefObj.DisplayField, VRefObj.IsDocId_DisplayField, VRefObj.HelpQuery, VRefObj.FilterField, VRefObj.SiteField, VRefObj.LastHiddenColumns)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region



End Class