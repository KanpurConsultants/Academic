Public Class ClsMain    
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Rug Prod Plan"
    'Public MdlTable As AgLibrary.ClsMain.LITable()

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        ObjAgTemplate = New AgTemplate.ClsMain(AgL)
        ObjAgTemplate_Common = New AgTemplate_Common.ClsMain(AgL)
        ObjAgTemplate_Sale = New AgTemplate_Sale.ClsMain(AgL)
        ObjAgTemplate_Production = New AgTemplate_Production.ClsMain(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Public Enum EntryPointType
        Main
        Log
    End Enum

    Public Enum ReportType
        Main
        Log
    End Enum

    Public Class LogStatus
        Public Const LogOpen As String = "Open"
        Public Const LogDiscard As String = "Discard"
        Public Const LogApproved As String = "Approved"
    End Class

    Class Temp_NCat
        Public Const OtherMaterialStockOpening As String = "MOSTK"
        Public Const YarnSkuStockOpening As String = "YOSTK"
        Public Const YarnSkuAdjustmentIssue As String = "YAISS"
        Public Const YarnSkuAdjustmentReceive As String = "YAREC"
        Public Const OtherMaterialPlan As String = "OMP"
        Public Const UndyedYarnPlan As String = "UMP"
        Public Const OtherMaterialTransferIssue As String = "OTRFI"
        Public Const YarnSkuTransferIssue As String = "YTRFI"
        Public Const OtherMaterialTransferReceive As String = "OTRFR"
        Public Const YarnSkuTransferReceive As String = "YTRFR"
    End Class

    Public Class ItemType
        Public Const YarnSKU As String = "Yarn SKU"
        Public Const CarpetSKU As String = "Carpet SKU"
        Public Const OtherMaterial As String = "Other"
    End Class

#Region "Public Help Queries"
    Public Class HelpQueries
        Public Const FringesType As String = "Select 'DYED' as Code, 'DYED' as Description " & _
                                              " Union All Select 'UNDYED' as Code, 'UNDYED' as Description " & _
                                              " Union All Select 'NATURAL' as Code, 'NATURAL' as Description " & _
                                              " Union All Select 'N.A.' as Code, 'N.A.' as Description "

        Public Const DeliveryMeasure As String = "Select 'Feet' as Code, 'Feet' as Description " & _
                                                 " Union All Select 'Meter' as Code, 'Meter' as Description " & _
                                                 " Union All Select 'Yard' as Code, 'Yard' as Description "

    End Class
#End Region


#Region " Structure Update Code "
    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableInitialiser()
        Call DeleteField()
        Call CreateVType()
        Call CreateView()
        InitializeTables()
    End Sub

    Sub DeleteField()
        Try
            'If AgL.IsFieldExist("ScholarshipApplied", "Sch_Student", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP CONSTRAINT [DF_Sch_Student_EnglishProficiency_TOEFL1]", AgL.GCn)
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP COLUMN ScholarshipApplied", AgL.GCn)
            'End If

            If AgL.IsFieldExist("Design", "RUG_DesignImage", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE RUG_DesignImage DROP COLUMN Design", AgL.GCn)
            End If

            If AgL.IsFieldExist("Design", "RUG_DesignImage_log", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE RUG_DesignImage_log DROP COLUMN Design", AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function RetDivFilterStr() As String
        Try
            RetDivFilterStr = "IsNull(Div_Code,'" & AgL.PubDivCode & "') = '" & AgL.PubDivCode & "'"
        Catch ex As Exception
            RetDivFilterStr = ""
            MsgBox(ex.Message)
        End Try
    End Function

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

            '===================================================< Other Material Stock Opening V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.OtherMaterialStockOpening, Temp_NCat.OtherMaterialStockOpening, "Other Material Stock Opening", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.OtherMaterialStockOpening, Temp_NCat.OtherMaterialStockOpening, Temp_NCat.OtherMaterialStockOpening, "Other Material Stock Opening", Temp_NCat.OtherMaterialStockOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Yarn Sku Stock Opening V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.YarnSkuStockOpening, Temp_NCat.YarnSkuStockOpening, "YarnSku Stock Opening", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.YarnSkuStockOpening, Temp_NCat.YarnSkuStockOpening, Temp_NCat.YarnSkuStockOpening, "YarnSku Stock Opening", Temp_NCat.YarnSkuStockOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Adjustment Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.YarnSkuAdjustmentIssue, Temp_NCat.YarnSkuAdjustmentIssue, "YarnSku Stock Adjustment Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.YarnSkuAdjustmentIssue, Temp_NCat.YarnSkuAdjustmentIssue, Temp_NCat.YarnSkuAdjustmentIssue, "YarnSku Stock Adjustment Issue", Temp_NCat.YarnSkuAdjustmentIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Adjustment Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.YarnSkuAdjustmentReceive, Temp_NCat.YarnSkuAdjustmentReceive, "YarnSku Stock Adjustment Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.YarnSkuAdjustmentReceive, Temp_NCat.YarnSkuAdjustmentReceive, Temp_NCat.YarnSkuAdjustmentReceive, "YarnSku Stock Adjustment Receive", Temp_NCat.YarnSkuAdjustmentReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Other Material Plan V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.OtherMaterialPlan, Temp_NCat.OtherMaterialPlan, "Other Material Plan", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.OtherMaterialPlan, Temp_NCat.OtherMaterialPlan, Temp_NCat.OtherMaterialPlan, "Other Material Plan", Temp_NCat.OtherMaterialPlan, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Undyed Yarn Material Plan V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.UndyedYarnPlan, Temp_NCat.UndyedYarnPlan, "Undyed Yarn Plan", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.UndyedYarnPlan, Temp_NCat.UndyedYarnPlan, Temp_NCat.UndyedYarnPlan, "Undyed Yarn Plan", Temp_NCat.UndyedYarnPlan, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Other Material Transfer Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.OtherMaterialTransferIssue, Temp_NCat.OtherMaterialTransferIssue, "Other Material Transfer Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.OtherMaterialTransferIssue, Temp_NCat.OtherMaterialTransferIssue, Temp_NCat.OtherMaterialTransferIssue, "Other Material Transfer Issue", Temp_NCat.OtherMaterialTransferIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Yarn Sku Transfer Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.YarnSkuTransferIssue, Temp_NCat.YarnSkuTransferIssue, "YarnSku Transfer Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.YarnSkuTransferIssue, Temp_NCat.YarnSkuTransferIssue, Temp_NCat.YarnSkuTransferIssue, "YarnSku Transfer Issue", Temp_NCat.YarnSkuTransferIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Other Material Transfer Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.OtherMaterialTransferReceive, Temp_NCat.OtherMaterialTransferReceive, "Other Material Transfer Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.OtherMaterialTransferReceive, Temp_NCat.OtherMaterialTransferReceive, Temp_NCat.OtherMaterialTransferReceive, "Other Material Transfer Receive", Temp_NCat.OtherMaterialTransferReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Yarn Sku Transfer Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.YarnSkuTransferReceive, Temp_NCat.YarnSkuTransferReceive, "YarnSku Transfer Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.YarnSkuTransferReceive, Temp_NCat.YarnSkuTransferReceive, Temp_NCat.YarnSkuTransferReceive, "YarnSku Transfer Receive", Temp_NCat.YarnSkuTransferReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_Unit()
        Dim mQry$
        Dim mTableName As String = "Unit"

        AddField(AgL.GCn, mTableName, "Code", "NVARCHAR(10)", , False)
        AddPrimaryKey(AgL.GCn, mTableName, "Code")

        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = 'Pcs'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('PCS')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = 'KG'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('KG')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = 'Meter'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('METER')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

    End Sub

    Private Sub TB_WashingType()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'NORMAL' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('NORMAL','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'NORMAL' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('NORMAL','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'NORMAL' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('NORMAL','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'HIGH WASH' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('HIGH WASH','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'HIGH WASH' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('HIGH WASH','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'HIGH WASH' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('HIGH WASH','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'ANTIQUE' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('ANTIQUE','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'ANTIQUE' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('ANTIQUE','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'ANTIQUE' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('ANTIQUE','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'HERBAL' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('HERBAL','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'HERBAL' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('HERBAL','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'HERBAL' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('HERBAL','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'N.A.' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('N.A.','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'N.A.' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('N.A.','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'N.A.' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('N.A.','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'DOUBLE WASH HERBAL' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('DOUBLE WASH HERBAL','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'SUN WASH SINGLE' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('SUN WASH SINGLE','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'SINGLE WASH ANTIQUE' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('SINGLE WASH ANTIQUE','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From WashingType Where Code = 'DOUBLE WASH ANTIQUE' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into WashingType (Code,Div_Code) Values ('DOUBLE WASH ANTIQUE','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Private Sub TB_ClippingType()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'HIGH LOW' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('HIGH LOW','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'HIGH LOW' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('HIGH LOW','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'CLIPPING' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('CLIPPING','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'CLIPPING' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('CLIPPING','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'EMBOSSING' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('EMBOSSING','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'EMBOSSING' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('EMBOSSING','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'CLIPPING + EMBOSSING' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('CLIPPING + EMBOSSING','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'CLIPPING + EMBOSSING' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('CLIPPING + EMBOSSING','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'N.A.' And Div_Code = 'D'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('N.A.','D')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'N.A.' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('N.A.','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'N.A.' And Div_Code = 'R'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('N.A.','R')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'TRIPLE CLIPPING' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('TRIPLE CLIPPING','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'DOUBLE CLIPPING' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('DOUBLE CLIPPING','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ClippingType Where Code = 'DOUBLE CLIPPING + ONETIME EMBOSSING' And Div_Code = 'K'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ClippingType (Code,Div_Code) Values ('DOUBLE CLIPPING + ONETIME EMBOSSING','K')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Private Sub TB_Priority()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From Priority Where Description = 'LOW' ", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Priority (Code,Description) Values (10,'LOW')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Priority Where Description = 'MEDIUM' ", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Priority (Code,Description) Values (20,'MEDIUM')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Priority Where Description = 'HIGH' ", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Priority (Code,Description) Values (30,'HIGH')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub



    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FAcGroup(MdlTable, "AcGroup")

        FCompany(MdlTable, "Company")

        FCurrency(MdlTable, "Currency")

        FDivision(MdlTable, "Division")

        FEntryPointPermission(MdlTable, "EntryPointPermission")

        FEnviro(MdlTable, "Enviro")

        FLog_TablePermission(MdlTable, "Log_TablePermission")

        FLog_TableRecords(MdlTable, "Log_TableRecords")

        FLogin_Log(MdlTable, "Login_Log")

        FLogTable(MdlTable, "LogTable")

        FPostingGroupSalesTax(MdlTable, "PostingGroupSalesTax")

        FPostingGroupSalesTaxItem(MdlTable, "PostingGroupSalesTaxItem")

        FPostingGroupSalesTaxParty(MdlTable, "PostingGroupSalesTaxParty")

        FRUG_CarpetSku(MdlTable, "RUG_CarpetSku", EntryPointType.Main)
        FRUG_CarpetSku(MdlTable, "RUG_CarpetSku_Log", EntryPointType.Log)

        FRug_CarpetSKUConsumption(MdlTable, "BOM", EntryPointType.Main)
        FRug_CarpetSKUConsumption(MdlTable, "BOM_Log", EntryPointType.Log)

        FRUG_Construction(MdlTable, "RUG_Construction")

        FRUG_Design(MdlTable, "RUG_Design", EntryPointType.Main)
        FRUG_Design(MdlTable, "RUG_Design_Log", EntryPointType.Log)

        FRUG_DesignImage(MdlTable, "RUG_DesignImage", EntryPointType.Main)
        FRUG_DesignImage(MdlTable, "RUG_DesignImage_Log", EntryPointType.Log)

        FRug_DesignConsumption(MdlTable, "BOM", EntryPointType.Main)
        FRug_DesignConsumption(MdlTable, "BOM_Log", EntryPointType.Log)


        FRUG_Quality(MdlTable, "RUG_Quality", EntryPointType.Main)
        FRUG_Quality(MdlTable, "RUG_Quality_Log", EntryPointType.Log)

        FRUG_QualityDetail(MdlTable, "RUG_QualityDetail", EntryPointType.Main)
        FRUG_QualityDetail(MdlTable, "RUG_QualityDetail_Log", EntryPointType.Log)

        FRUG_Shade(MdlTable, "RUG_SHADE", EntryPointType.Main)
        FRUG_Shade(MdlTable, "RUG_SHADE_Log", EntryPointType.Log)

        FRug_Size(MdlTable, "Rug_Size", EntryPointType.Main)
        FRug_Size(MdlTable, "Rug_Size_Log", EntryPointType.Log)

        FRUG_Yarn(MdlTable, "RUG_Yarn", EntryPointType.Main)
        FRUG_Yarn(MdlTable, "RUG_Yarn_Log", EntryPointType.Log)

        FRUG_YarnSku(MdlTable, "RUG_YarnSKU", EntryPointType.Main)
        FRUG_YarnSku(MdlTable, "RUG_YarnSku_Log", EntryPointType.Log)

        FSeaPort(MdlTable, "SeaPort", EntryPointType.Main)
        FSeaPort(MdlTable, "SeaPort_Log", EntryPointType.Log)

        FSiteMast(MdlTable, "SiteMast")

        FSubGroup(MdlTable, "SubGroup", EntryPointType.Main)
        FSubGroup(MdlTable, "SubGroup_Log", EntryPointType.Log)

        FSaleOrder(MdlTable, "SaleOrder", EntryPointType.Main)
        FSaleOrder(MdlTable, "SaleOrder_Log", EntryPointType.Log)


        FSubGroupType(MdlTable, "SubGroupType")

        FSynchronise_Error(MdlTable, "Synchronise_Error")

        FTable_SearchField(MdlTable, "Table_SearchField")

        FUnit(MdlTable, "Unit")

        FPriority(MdlTable, "Priority")

        FUser_Control_Permission(MdlTable, "User_Control_Permission")

        FUser_Permission(MdlTable, "User_Permission")

        FUserMast(MdlTable, "UserMast")

        FUserSite(MdlTable, "UserSite")

        FVoucher_Exclude(MdlTable, "Voucher_Exclude")

        FVoucher_Include(MdlTable, "Voucher_Include")

        FVoucher_Prefix(MdlTable, "Voucher_Prefix")

        FVoucher_Prefix_Type(MdlTable, "Voucher_Prefix_Type")

        FVoucher_Type(MdlTable, "Voucher_Type")

        FVoucherCat(MdlTable, "VoucherCat")

        FWashingType(MdlTable, "WashingType")

        FClippingType(MdlTable, "ClippingType")

        FRug_Enviro(MdlTable, "Rug_Enviro")
    End Sub


    Private Sub FSaleOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        'Table
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        'Columns
        AgL.FSetColumnValue(MdlTable, "DeliveryMeasure", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipmentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ShipmentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "FactoryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "FactoryDeliveryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ExFactoryShipmentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "FactoryCancelDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Priority", AgLibrary.ClsMain.SQLDataType.Int)
    End Sub

    Private Sub FSaleOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        'Table
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        'Columns
    End Sub


    Private Sub FAcGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4, True)
        AgL.FSetColumnValue(MdlTable, "SNo", AgLibrary.ClsMain.SQLDataType.TinyInt)
        AgL.FSetColumnValue(MdlTable, "GroupName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ContraGroupName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "GroupUnder", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "GroupNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "SysGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "TradingYn", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "MainGrCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "BlOrd", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MainGrLen", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "ID", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "GroupNameBiLang", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "GroupLevel", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CurrentCount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CurrentBalance", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SubLedYn", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "AliasYn", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "GroupHelp", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "LastYearBalance", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "GroupUnder", "GroupCode", "AcGroup")
    End Sub


    Private Sub FRug_DesignConsumption(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        'Table
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        'Columns
        AgL.FSetColumnValue(MdlTable, "Design", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        'Foreign Key
        AgL.FSetFKeyValue(MdlTable, "Design", "Code", "Rug_Design")
    End Sub


    Private Sub FRug_CarpetSKUConsumption(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        'Table
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        'Columns
        AgL.FSetColumnValue(MdlTable, "CarpetSKU", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        'Foreign Key
        AgL.FSetFKeyValue(MdlTable, "CarpetSKU", "Code", "Rug_CarpetSKU")
    End Sub

    Private Sub FCompany(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Comp_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Comp_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CentralData_Path", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PrevDBName", AgLibrary.ClsMain.SQLDataType.VarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DbPrefix", AgLibrary.ClsMain.SQLDataType.VarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Repo_Path", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Start_Dt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "End_Dt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "address1", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "address2", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "city", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "pin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "fax", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "lstno", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "lstdate", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "cstno", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "cstdate", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "cyear", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "pyear", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "SerialKeyNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "SName", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "EMail", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Gram", AgLibrary.ClsMain.SQLDataType.VarChar, 15)
        AgL.FSetColumnValue(MdlTable, "Desc1", AgLibrary.ClsMain.SQLDataType.VarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Desc2", AgLibrary.ClsMain.SQLDataType.VarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Desc3", AgLibrary.ClsMain.SQLDataType.VarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ECCCode", AgLibrary.ClsMain.SQLDataType.VarChar, 15)
        AgL.FSetColumnValue(MdlTable, "ExDivision", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ExRegNo", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ExColl", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ExRange", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Desc4", AgLibrary.ClsMain.SQLDataType.VarChar, 150)
        AgL.FSetColumnValue(MdlTable, "VatNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VatDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TinNo", AgLibrary.ClsMain.SQLDataType.VarChar, 12)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.VarChar, 2)
        AgL.FSetColumnValue(MdlTable, "LogSiteCode", AgLibrary.ClsMain.SQLDataType.VarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PANNo", AgLibrary.ClsMain.SQLDataType.VarChar, 25)
        AgL.FSetColumnValue(MdlTable, "State", AgLibrary.ClsMain.SQLDataType.VarChar, 35)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.VarChar, 35)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DeletedYN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Country", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "NotificationNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "WorkAddress1", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WorkAddress2", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WorkCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WorkCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "WorkPin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "WorkPhone", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "WorkFax", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "WebServer", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "WebUser", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "WebPassword", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Webdatabase", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UseSiteNameAsCompanyName", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FCurrency(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FDivision(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "Div_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "DataPath", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "address1", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "address2", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "address3", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "city", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "pin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SitewiseV_No", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
    End Sub

    Private Sub FEntryPointPermission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "MnuModule", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "IsOnLineEntry", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "IsOffLineEntry", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FEnviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "ID", AgLibrary.ClsMain.SQLDataType.nVarChar, 4, True)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "CashAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BankAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TdsAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AdditionAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DeductionAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ServiceTaxAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ECessAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RoundOffAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "HECessAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ServiceTaxPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ECessPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "HECessPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "CashAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "BankAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AdditionAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "DeductionAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "TdsAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ServiceTaxAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ECessAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "HECessAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "RoundOffAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FRug_Enviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "DefaultUndyedShade", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "DefaultUndyedShade", "Code", "RUG_SHADE")
    End Sub

    Private Sub FLog_TablePermission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "CreateLogYn", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FLog_TableRecords(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "SearchKey", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "AED", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "UpdateDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, , True)
        AgL.FSetColumnValue(MdlTable, "TableName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Site", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FLogin_Log(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "User_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "MachineName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Comp_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime, , True)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FLogTable(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 36)
        AgL.FSetColumnValue(MdlTable, "EntryPoint", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MachineName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyDetail", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FRUG_CarpetSku(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Design", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Size", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Item")
        Else
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Item_Log")
        End If

        AgL.FSetFKeyValue(MdlTable, "Design", "Code", "RUG_Design")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Size", "Code", "Rug_Size")
    End Sub

    Private Sub FRUG_Construction(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FRUG_Design(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Carpet_Collection", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Carpet_Style", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Carpet_Colour", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "QualityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StdRugWeight", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PileWeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Bom", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "QualityCode", "Code", "RUG_Quality")
        AgL.FSetFKeyValue(MdlTable, "Construction", "Code", "RUG_Construction")
        AgL.FSetFKeyValue(MdlTable, "Bom", "Code", "Bom")
    End Sub

    Private Sub FRUG_DesignImage(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        'Agl.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Photo", AgLibrary.ClsMain.SQLDataType.image)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "RUG_Design_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "RUG_Design")
        End If
    End Sub

    Private Sub FRUG_Quality(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "StdRugWeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PileWeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PileHeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TuftPerSqrInch", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "WashingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Clipping", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Fringes", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Construction", "Code", "RUG_Construction")
    End Sub

    Private Sub FRUG_QualityDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "OtherMaterial", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "QtyPerSqrYard", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "RUG_Quality_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "RUG_Quality")
        End If
        AgL.FSetFKeyValue(MdlTable, "OtherMaterial", "Code", "Item")
    End Sub

    Private Sub FRUG_Shade(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Colour", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Pantone", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRug_Size(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Shape", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "FeetLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FeetWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FeetArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeterLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeterWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeterArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "YardLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "YardWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "YardArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KFeetLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KFeetWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KFeetArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KMeterLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KMeterWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KMeterArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KYardLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KYardWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "KYardArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "KhapSizeDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "StencilSizeDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SFeetLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SFeetWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SFeetArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SMeterLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SMeterWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SMeterArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SYardLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SYardWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SYardArea", AgLibrary.ClsMain.SQLDataType.Float)

    End Sub

    Private Sub FRUG_Yarn(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "YarnGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Twist", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Ply", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Count", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UNIT", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRUG_YarnSku(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Yarn", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "SHADE", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Item")
        Else
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Item_Log")
        End If

        AgL.FSetFKeyValue(MdlTable, "YARN", "Code", "RUG_Yarn")
        AgL.FSetFKeyValue(MdlTable, "SHADE", "Code", "RUG_SHADE")
    End Sub

    Private Sub FSeaPort(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "City", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "City", "CityCode", "City")
    End Sub

    Private Sub FSiteMast(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True)
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "HO_YN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Add1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "City_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 7)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PinNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Active", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FSubGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "SiteList", AgLibrary.ClsMain.SQLDataType.nVarChar, 500)
        AgL.FSetColumnValue(MdlTable, "NamePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 123)
        AgL.FSetColumnValue(MdlTable, "DispName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "GroupNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 11)
        AgL.FSetColumnValue(MdlTable, "Add1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "CountryCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PIN", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "FAX", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "EMail", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CSTNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 40)
        AgL.FSetColumnValue(MdlTable, "LSTNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 40)
        AgL.FSetColumnValue(MdlTable, "TINNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PAN", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TDS_Catg", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "ActiveYN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "CreditLimit", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CreditDays", AgLibrary.ClsMain.SQLDataType.SmallInt)
        AgL.FSetColumnValue(MdlTable, "DueDays", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "ContactPerson", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Party_Type", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "PAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PAdd3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PCityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PCountryCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 7)
        AgL.FSetColumnValue(MdlTable, "PPin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PPhone", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "PMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "PFax", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Curr_Bal", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OpBal_DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "FatherName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "FatherNamePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "HusbandName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "HusbandNamePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DOB", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "Location", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "SiteStr", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "STRegNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "ECCNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "EXREGNO", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "CEXRANGE", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "CEXDIV", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "COMMRATE", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "VATNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "CommonAc", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ChequeReport", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SisterConcernYn", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetFKeyValue(MdlTable, "City", "CityCode", "City")
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "SalesTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ExcisePostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "EntryTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetFKeyValue(MdlTable, "CityCode", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "PCityCode", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FSubGroupType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Party_Type", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FSynchronise_Error(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , True)
        AgL.FSetColumnValue(MdlTable, "Message", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
    End Sub

    Private Sub FTable_SearchField(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "TABLE_NAME", AgLibrary.ClsMain.SQLDataType.nVarChar, 128)
        AgL.FSetColumnValue(MdlTable, "SEARCH_FIELD", AgLibrary.ClsMain.SQLDataType.nVarChar, 128)
    End Sub

    Private Sub FUnit(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
    End Sub

    Private Sub FPriority(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
    End Sub

    Private Sub FUser_Control_Permission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "UserName", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "MnuModule", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "MnuText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "GroupText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "GroupName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FUser_Permission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "UserName", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "MnuModule", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "MnuText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SNo", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "MnuLevel", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Parent", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Permission", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "ReportFor", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Active", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MainStreamCode", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "GroupLevel", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ControlPermissionGroups", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
    End Sub

    Private Sub FUserMast(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "USER_NAME", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "PASSWD", AgLibrary.ClsMain.SQLDataType.nVarChar, 16)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Admin", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FUserSite(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "User_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "CompCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Sitelist", AgLibrary.ClsMain.SQLDataType.nVarChar, 250)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "DivisionList", AgLibrary.ClsMain.SQLDataType.nVarChar, 250)

        AgL.FSetFKeyValue(MdlTable, "CompCode", "Comp_Code", "Company")
    End Sub

    Private Sub FVoucher_Exclude(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "Dr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Cr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FVoucher_Include(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "Dr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Cr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "SITE_CODE", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FVoucher_Prefix(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Date_From", AgLibrary.ClsMain.SQLDataType.SmallDateTime, , True)
        AgL.FSetColumnValue(MdlTable, "Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Start_Srl_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Date_To", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Prefix", "V_Prefix", "Voucher_Prefix_Type")
    End Sub

    Private Sub FVoucher_Prefix_Type(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FVoucher_Type(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "NCat", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Short_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SystemDefine", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DivisionWise", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "SiteWise", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IssRec", AgLibrary.ClsMain.SQLDataType.nVarChar, 3)
        AgL.FSetColumnValue(MdlTable, "Description_Help", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Description_BiLang", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Short_Name_BiLang", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Report_Index", AgLibrary.ClsMain.SQLDataType.nVarChar, 3)
        AgL.FSetColumnValue(MdlTable, "Number_Method", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "Start_No", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Last_Ent_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Form_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "Saperate_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Common_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Print_VNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Header_Desc", AgLibrary.ClsMain.SQLDataType.nVarChar, 80)
        AgL.FSetColumnValue(MdlTable, "Term_Desc", AgLibrary.ClsMain.SQLDataType.nVarChar, 150)
        AgL.FSetColumnValue(MdlTable, "Footer_Desc", AgLibrary.ClsMain.SQLDataType.nVarChar, 150)
        AgL.FSetColumnValue(MdlTable, "Exclude_Ac_Grp", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SerialNo_From_Table", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ChqNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ChqDt", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ClgDt", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DefaultCrAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DefaultDrAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FirstDrCr", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TrnType", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "TdsDed", AgLibrary.ClsMain.SQLDataType.nVarChar, 3)
        AgL.FSetColumnValue(MdlTable, "ContraNarr", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TdsOnAmt", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Contra_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Separate_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Affect_FA", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "IsShowVoucherReference", AgLibrary.ClsMain.SQLDataType.Bit)

    End Sub

    Private Sub FVoucherCat(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "NCat", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "NCatDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "SITE_CODE", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "UserTypeYN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FPostingGroupSalesTax(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "PostingGroupSalesTaxItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
        AgL.FSetColumnValue(MdlTable, "PostingGroupSalesTaxParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
        AgL.FSetColumnValue(MdlTable, "PurchaseSaleAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTax", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SalesTaxAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VAT", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "VatAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AdditionalTax", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AdditionalTaxAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Cst", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CstAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)

        AgL.FSetFKeyValue(MdlTable, "PostingGroupSalesTaxItem", "Description", "PostingGroupSalesTaxItem")
        AgL.FSetFKeyValue(MdlTable, "PostingGroupSalesTaxParty", "Description", "PostingGroupSalesTaxParty")
        AgL.FSetFKeyValue(MdlTable, "PurchaseSaleAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SalesTaxAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AdditionalTaxAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "VatAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "CstAc", "SubCode", "SubGroup")
    End Sub


    Private Sub FPostingGroupSalesTaxItem(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
        AgL.FSetColumnValue(MdlTable, "Active", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FPostingGroupSalesTaxParty(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 30, True)
        AgL.FSetColumnValue(MdlTable, "Active", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FWashingType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)

        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
    End Sub

    Private Sub FClippingType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)

        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
    End Sub

    Private Sub AddCommonFieldsForSurya(ByVal mConn As SqlClient.SqlConnection, ByVal TableName As String)
        AddField(mConn, TableName, "EntryBy", "NVARCHAR(10)")
        AddField(mConn, TableName, "EntryDate", "SmallDateTime")
        AddField(mConn, TableName, "EntryType", "NVARCHAR(10)")
        AddField(mConn, TableName, "EntryStatus", "NVARCHAR(10)")
        AddField(mConn, TableName, "ApproveBy", "NVARCHAR(10)")
        AddField(mConn, TableName, "ApproveDate", "SmallDateTime")
        AddField(mConn, TableName, "MoveToLog", "NVARCHAR(10)")
        AddField(mConn, TableName, "MoveToLogDate", "SmallDateTime")
        AddField(mConn, TableName, "Status", "NVARCHAR(10)")
        AddField(mConn, TableName, "Div_Code", "NVARCHAR(1)")

    End Sub

    Public Sub DropConstraints(ByVal mConn As SqlClient.SqlConnection, ByVal mTable As String)
        Dim mQry As String
        Dim DtTemp As DataTable
        Dim I As Integer

        'mQry = "SELECT C.CONSTRAINT_NAME AS CName, C.TABLE_NAME AS TName FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS C WHERE TABLE_NAME ='" & mTable & "' And Constraint_Type = 'FOREIGN KEY' "

        'mQry = mQry + " Union All SELECT D.name AS CName , O.name  AS TName FROM sys.default_constraints D " & _
        '       "LEFT JOIN sys.objects O ON D.parent_object_id  = O.object_id  " & _
        '       "WHERE O.name ='" & mTable & "' "
        'mQry = mQry + " Union all SELECT C.CONSTRAINT_NAME AS CName, C.TABLE_NAME AS TName FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS C WHERE TABLE_NAME ='" & mTable & "' And Constraint_Type <> 'FOREIGN KEY' "
        mQry = "SELECT C.CONSTRAINT_NAME AS CName, C.TABLE_NAME AS TName FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS C WHERE TABLE_NAME Like 'Rug_%' And Constraint_Type = 'FOREIGN KEY' "

        mQry = mQry + " Union All SELECT D.name AS CName , O.name  AS TName FROM sys.default_constraints D " & _
               "LEFT JOIN sys.objects O ON D.parent_object_id  = O.object_id  " & _
               "WHERE O.name  Like 'Rug_%' "
        mQry = mQry + " Union all SELECT C.CONSTRAINT_NAME AS CName, C.TABLE_NAME AS TName FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS C WHERE TABLE_NAME  Like 'Rug_%' And Constraint_Type <> 'FOREIGN KEY' "

        DtTemp = AgL.FillData(mQry, mConn).Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            mQry = "Alter Table " & DtTemp.Rows(I)("TName") & " Drop Constraint " & DtTemp.Rows(I)("CName") & "  "
            AgL.Dman_ExecuteNonQry(mQry, mConn)
        Next
    End Sub

    Public Sub AddReferentialKey(ByVal mConn As SqlClient.SqlConnection, ByVal PrimaryKeyTable As String, ByVal ForeignKeyTable As String, _
                                    ByVal PrimaryKeyField As String, ByVal ForeignKeyField As String)
        Dim mQry As String
        Dim mName As String

        mName = "FK_" + PrimaryKeyTable + "_" + PrimaryKeyField + "_" + ForeignKeyTable + "_" + ForeignKeyField
        Try
            mQry = "ALTER TABLE [" & ForeignKeyTable & "]  WITH CHECK ADD  CONSTRAINT [" & mName & "] FOREIGN KEY([" & ForeignKeyField & "]) REFERENCES [" & PrimaryKeyTable & "] ([" & PrimaryKeyField & "])"
            AgL.Dman_ExecuteNonQry(mQry, mConn)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AddPrimaryKey(ByVal mConn As SqlClient.SqlConnection, ByVal TableName As String, ByVal FieldList As String)
        Dim mQry$
        Try
            mQry = "ALTER TABLE " & TableName & " Add CONSTRAINT [PK_" & TableName & "] PRIMARY KEY (" & FieldList & ")"
            AgL.Dman_ExecuteNonQry(mQry, mConn)
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddField(ByVal mConn As SqlClient.SqlConnection, ByVal mTable As String, ByVal mColumn As String, ByVal mDataType As String, Optional ByVal mDefault_Value As String = "", Optional ByVal AllowNull As Boolean = True) As Boolean
        Dim mQry As String
        Dim mNullClause$
        Try
            Dim mDefault_Caluse As String = ""
            If mDefault_Value.Trim <> "" Then
                mDefault_Caluse = " Default " & mDefault_Value
            End If

            If AllowNull Then
                mNullClause = " Null "
            Else
                mNullClause = " Not Null "
            End If

            mQry = "Select Count(*) From Information_Schema.Tables Where Table_Name = '" & mTable & "'"
            If AgL.Dman_Execute(mQry, mConn).ExecuteScalar = 0 Then
                mQry = "Create Table " & mTable & " (" & mColumn & " " & mDataType & " " & mNullClause & " " & mDefault_Caluse & ")"
                AgL.Dman_ExecuteNonQry(mQry, mConn)
            Else
                mQry = "Select Count(*) From Information_Schema.Columns Where Table_Name = '" & mTable & "' And Column_Name = '" & mColumn & "' "
                If AgL.Dman_Execute(mQry, mConn).ExecuteScalar = 0 Then
                    mQry = ("ALTER TABLE " & mTable & " Add " & mColumn & " " & mDataType & mNullClause & "  " & mDefault_Caluse)
                    AgL.Dman_ExecuteNonQry(mQry, mConn)
                    If mDefault_Value.Trim <> "" Then
                        mQry = ("Update " & mTable & " Set " & mColumn & "=" & mDefault_Value & " Where " & mColumn & " Is Null")
                        AgL.Dman_ExecuteNonQry(mQry, mConn)
                    End If

                Else
                    mQry = "ALTER TABLE " & mTable & " ALter Column " & mColumn & " " & mDataType & " " & mNullClause & ""
                    AgL.Dman_ExecuteNonQry(mQry, mConn)
                    If mDefault_Value.Trim <> "" Then
                        mQry = ("Update " & mTable & " Set " & mColumn & "=" & mDefault_Value & " Where " & mColumn & " Is Null")
                        AgL.Dman_ExecuteNonQry(mQry, mConn)
                    End If

                End If
            End If

            AddField = True
        Catch ex As Exception
            AddField = False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub InitializeTables()
        TB_Unit()

        TB_WashingType()

        TB_ClippingType()

        TB_Priority()
    End Sub
#End Region


End Class