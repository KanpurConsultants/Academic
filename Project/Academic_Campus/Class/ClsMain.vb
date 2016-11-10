Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Campus"
    'Public MdlTable As AgLibrary.ClsMain.LITable()

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        ObjAgTemplate = New AgTemplate.ClsMain(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        'Call IniDtMess_Enviro()
    End Sub

    Public Shared PurchaseAddition_Text = "Addition"
    Public Shared PurchaseAddition_H_Text = "Addition"
    Public Shared PurchaseDeduction_Text = "Deduction"
    Public Shared PurchaseDeduction_H_Text = "Deduction"
    Public Shared SaleAddition_Text = "Addition"
    Public Shared SaleAddition_H_Text = "Addition"
    Public Shared SaleDeduction_Text = "Deduction"
    Public Shared SaleDeduction_H_Text = "Deduction"

    Public Shared Item_Nature1_Description = "Item Nature1"
    Public Shared Item_Nature2_Description = "Item Nature2"
    Public Shared Item_Batch_Description = "Batch No"

    Class OwnRental
        Public Const Own As String = "Own"
        Public Const Rental As String = "Rental"
    End Class

    Class MemberType
        Public Const Student As String = "Student"
        Public Const Employee As String = "Employee"
    End Class

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

    Public Class PostingGroupSalesTaxParty
        Public Const Local As String = "Local"
        Public Const Central As String = "Central"
        Public Const LocalWithFormH As String = "Local {Form `H`}"
        Public Const CentralWithFormC As String = "Central {Form `C`}"
        Public Const Export As String = "Export"
    End Class

    Class Temp_NCat
        Public Const CampusSessionCompany As String = "SCMP"
        Public Const CampusPlacement As String = "CPLC"
    End Class

    Class Temp_Cat
        'Public Const StorePurchase As String = "STPUR"
    End Class

    Class Temp_Structure
        'Public Const MessPurchase As String = "MessPur"
    End Class

    Public Class Temp_Charges
        Public Const GrossAmount As String = "GAMT"
        Public Const LineAddition As String = "LAdd"
        Public Const LineDeduction As String = "LDed"
        Public Const LineNetAmount As String = "LNAmt"
        Public Const HeaderAddition As String = "HAdd"
        Public Const HeaderDeduction As String = "HDed"
        Public Const NetSubTotal As String = "NSTot"
        Public Const RoundOff As String = "ROff"
        Public Const NetAmount As String = "NAMT"
    End Class

    Public Class ItemType
        Public Const Book As String = "Book"
        Public Const Stationary As String = "Stationary"
        Public Const Generals As String = "Generals"
        Public Const CD As String = "CD"
        Public Const Mess As String = "Mess"
        Public Const Store As String = "Store"
    End Class

    Public Class ItemNature
        Public Const RawMaterial As String = "Raw Material"
        Public Const SemiFinished As String = "Semi Finished"
        Public Const Finished As String = "Finished"

        Public Const Consumable As String = "Consumable"
        Public Const NonConsumable As String = "Non Consumable"
    End Class

    Public Class PartyMasterType
        Public Const Cash As String = "Cash"
        Public Const Party As String = "Party"
        Public Const Supplier As String = "Supplier"
        Public Const Customer As String = "Customer"
        Public Const Transport As String = "Transport"
        Public Const Agent As String = "Agent"
    End Class

#Region "Structure Update Code "
    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableInitialiser()
        Call EditField()
        Call DeleteField()
        Call CreateVType()
        Call CreateView()
        Call InitializeTables()
        Call InitializeStructure()
    End Sub

    Sub ChangeFieldSize_BeforeCreateDatabase()
        Dim mQry$ = ""
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            '===========================================================================================================================================================
            '==================< Set Godown Code Field Size To nvarchar(10)  >============================================================================================
            '===================================< Start  >==============================================================================================================
            '===========================================================================================================================================================
            'If FunFindField(GcnRead, "Godown", "Store_Enviro", 8) Then
            '    mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Enviro' AND CONSTRAINT_NAME = 'FK_Store_Enviro_Godown' "
            '    If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
            '        AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Enviro DROP CONSTRAINT [FK_Store_Enviro_Godown]", AgL.GCn)
            '    End If

            '    AgL.EditField("Store_Enviro", "Godown", "nvarchar(10)", GcnRead)
            'End If

            'If FunFindField(GcnRead, "Godown", "Store_Stock", 8) Then
            '    mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Stock' AND CONSTRAINT_NAME = 'FK_Store_Stock_Godown' "
            '    If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
            '        AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Stock DROP CONSTRAINT [FK_Store_Stock_Godown]", AgL.GCn)
            '    End If

            '    AgL.EditField("Store_Stock", "Godown", "nvarchar(10)", GcnRead)
            'End If

            'If FunFindField(GcnRead, "Code", "Store_Godown", 8) Then
            '    AgL.EditField("Store_Godown", "Code", "nvarchar(10)", GcnRead)
            'End If
            '===========================================================================================================================================================
            '==================< Set Godown Code Field Size To nvarchar(10)  >============================================================================================
            '===================================< End  >==============================================================================================================
            '===========================================================================================================================================================

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Dim mQry$ = ""
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            'AgL.EditField("Store_Item", "Unit", "nvarchar(20)", GcnRead)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            'If AgL.IsFieldExist("ScholarshipApplied", "Sch_Student", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP CONSTRAINT [DF_Sch_Student_EnglishProficiency_TOEFL1]", AgL.GCn)
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP COLUMN ScholarshipApplied", AgL.GCn)
            'End If

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
           
            ''===================================================< Mess Stock Adjustment Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.CampusSessionCompany, ClsMain.Temp_NCat.CampusSessionCompany, "Session Company Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.CampusSessionCompany, ClsMain.Temp_NCat.CampusSessionCompany, ClsMain.Temp_NCat.CampusSessionCompany, "Session Company Entry", ClsMain.Temp_NCat.CampusSessionCompany, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Placement Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.CampusPlacement, ClsMain.Temp_NCat.CampusPlacement, "Placement Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.CampusPlacement, ClsMain.Temp_NCat.CampusPlacement, ClsMain.Temp_NCat.CampusPlacement, "Placement Entry", ClsMain.Temp_NCat.CampusPlacement, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_PostingGroupSalesTaxParty()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Local & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Local & "',1)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Call ChangeFieldSize_BeforeCreateDatabase()

        FCampus_Company(MdlTable, "Campus_Company")
        FCampus_Company1(MdlTable, "Campus_Company1")

        FCampus_SessionCompany(MdlTable, "Campus_SessionCompany")
        FCampus_SessionCompany1(MdlTable, "Campus_SessionCompany1")

        FCampus_Placement(MdlTable, "Campus_Placement")

    End Sub

    Private Sub FCampus_Company(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Add1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PIN", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WebSite", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Email", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Rank", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Segment", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)


        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "CityCode", "CityCode", "City")
    End Sub

    Private Sub FCampus_Company1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
      
        AgL.FSetColumnValue(MdlTable, "Person", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Designation", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Email", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Hierarchy", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Campus_Company")

    End Sub

    Private Sub FCampus_SessionCompany(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Sch_Session")
    End Sub

    Private Sub FCampus_SessionCompany1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "Company", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Campus_SessionCompany")
        AgL.FSetFKeyValue(MdlTable, "Company", "Code", "Campus_Company")

    End Sub

    Private Sub FCampus_Placement(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Company", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Student", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AdmissionDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "JoiningDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Package", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Desigantion", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)


        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Sch_Session")
        AgL.FSetFKeyValue(MdlTable, "Company", "Code", "Campus_Company")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Student", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AdmissionDocId", "DocId", "Sch_Admission")

    End Sub

    Public Sub InitializeTables()
        TB_PostingGroupSalesTaxParty()
    End Sub

    Public Sub InitializeStructure()
        'Call ST_MessPurchase()
    End Sub

    Private Function FunFindField(ByVal SqlConn As SqlClient.SqlConnection, ByVal StrColumnName As String, ByVal StrTableName As String, Optional ByVal IntFieldSize As Integer = 0) As Boolean
        Dim mQry$ = "", bCondStr$ = "Where 1=1 "
        Dim bBlnReturn As Boolean = False
        Try
            bCondStr += " And T.COLUMN_NAME = '" & StrColumnName & "' " & _
                            " AND T.TABLE_NAME = '" & StrTableName & "' "

            If IntFieldSize > 0 Then
                bCondStr += " AND T.CHARACTER_MAXIMUM_LENGTH = " & IntFieldSize & " "
            End If

            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM INFORMATION_SCHEMA.COLUMNS T With (NoLock) " & bCondStr
            If AgL.Dman_Execute(mQry, SqlConn).ExecuteScalar > 0 Then
                bBlnReturn = True
            End If
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunFindField = bBlnReturn
        End Try
    End Function
#End Region

End Class