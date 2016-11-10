Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Transport"
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
        Call IniDtTp_Enviro()
    End Sub

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
        Public Const VehicleMaintenanceExpenseEntry As String = "VME"
        Public Const VehicleGate As String = "VGATE"
        Public Const VisitorGate As String = "PGATE"
        Public Const TransportMemberAttendance As String = "TMA"
    End Class


    Class Temp_Structure
        Public Const VehicleMaintenanceExpense As String = "VehExp"
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
    End Class

    Public Class InOut
        Public Const GateIn As String = "IN"
        Public Const GateOut As String = "OUT"
    End Class

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
        Call InitializeTables()
        Call InitializeStructure()

        'Try
        '    If AgL.IsFieldExist("Description", "Item", AgL.GCn) Then
        '        AgL.Dman_ExecuteNonQry("ALTER TABLE Item ALTER COLUMN Description NVARCHAR(100) NULL ", AgL.GCn)
        '    End If

        '    If AgL.IsFieldExist("Description", "Item_Log", AgL.GCn) Then
        '        AgL.Dman_ExecuteNonQry("ALTER TABLE Item_Log ALTER COLUMN Description NVARCHAR(100) NULL ", AgL.GCn)
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
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
            '===================================================< Vehicle Maintenance/Expense Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry, "Vehicle Maintenance/Expense Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry, "Vehicle Maintenance/Expense Entry", ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Transport Member Attendance Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.TransportMemberAttendance, ClsMain.Temp_NCat.TransportMemberAttendance, "Transport Member Attendance", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.TransportMemberAttendance, ClsMain.Temp_NCat.TransportMemberAttendance, ClsMain.Temp_NCat.TransportMemberAttendance, "Transport Member Attendance", ClsMain.Temp_NCat.TransportMemberAttendance, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_PostingGroupSalesTaxParty()
        'Dim mQry$

        'If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Local & "'", AgL.GCn).ExecuteScalar = 0 Then
        '    mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Local & "',1)"
        '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        'End If
    End Sub

    Private Sub TB_ExpenseType()
        Dim mQry As String = ""

        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            'mQry = "CREATE TABLE dbo.Tp_ExpenseType " & _
            '        " ( " & _
            '        " Code NVARCHAR (20) NOT NULL, " & _
            '        " CONSTRAINT PK_Tp_ExpenseType PRIMARY KEY (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Tp_ExpenseType", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Tp_ExpenseType", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
            If AgL.IsTableExist("Tp_ExpenseType", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Expense') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Expense')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Permit') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Permit')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Fitness') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Fitness')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Registration') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Registration')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Road Tax') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Road Tax')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Insurance') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Insurance')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Tp_ExpenseType WHERE Code = 'Service') " & _
                            " INSERT INTO dbo.Tp_ExpenseType (Code) VALUES ('Service')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FSch_Area(MdlTable, "Sch_Area")
        FSch_Route(MdlTable, "Sch_Route")
        FSch_Route1(MdlTable, "Sch_Route1")

        FTp_ExpenseType(MdlTable, "Tp_ExpenseType")
        FTp_Expense(MdlTable, "Tp_Expense")

        FTp_Vehicle(MdlTable, "Tp_Vehicle")
        FTp_Vehicle1(MdlTable, "Tp_Vehicle1")

        FTp_VehicleRoute(MdlTable, "Tp_VehicleRoute")

        'FTp_TransportAllotment(MdlTable, "Tp_TransportAllotment")

        FTp_Member(MdlTable, "Tp_Member", EntryPointType.Main)
        FTp_Member(MdlTable, "Tp_Member_Log", EntryPointType.Log)

        FTp_MaintenanceExpenseEntry(MdlTable, "Tp_MaintenanceExpenseEntry", EntryPointType.Main)
        FTp_MaintenanceExpenseEntry(MdlTable, "Tp_MaintenanceExpenseEntry_Log", EntryPointType.Log)

        FTp_MaintenanceExpenseEntry1(MdlTable, "Tp_MaintenanceExpenseEntry1", EntryPointType.Main)
        FTp_MaintenanceExpenseEntry1(MdlTable, "Tp_MaintenanceExpenseEntry1_Log", EntryPointType.Log)

        FTp_MemberAttendance(MdlTable, "Tp_MemberAttendance", EntryPointType.Main)
        FTp_MemberAttendance(MdlTable, "Tp_MemberAttendance_Log", EntryPointType.Log)

        FTp_MemberAttendance1(MdlTable, "Tp_MemberAttendance1", EntryPointType.Main)
        FTp_MemberAttendance1(MdlTable, "Tp_MemberAttendance1_Log", EntryPointType.Log)

        FTp_Enviro(MdlTable, "Tp_Enviro")
    End Sub

    Private Sub FSch_Route(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FSch_Route1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Area", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Sch_Route")
        AgL.FSetFKeyValue(MdlTable, "Area", "Code", "Sch_Area")
    End Sub

    Private Sub FSch_Area(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FTp_ExpenseType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
    End Sub

    Private Sub FTp_Vehicle(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "RegistrationNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, , False)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "VehicleType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VehicleModel", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ChassisNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "EngineNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "SeatingCapacity", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Mileage", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OwnRented", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "OwnerName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "OwnerAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "OwnerAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "OwnerAdd3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "OwnerCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "MeterReading", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Route", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Route", "Code", "Sch_Route")
    End Sub

    Private Sub FTp_Vehicle1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Expense", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ExpenseType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DueOnDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "DueOnMeterReading", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Tp_Vehicle")
        AgL.FSetFKeyValue(MdlTable, "Expense", "Code", "Tp_Expense")

    End Sub

    Private Sub FTp_VehicleRoute(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Route", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "AllotmentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "InActiveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vehicle", "Code", "Tp_Vehicle")
        AgL.FSetFKeyValue(MdlTable, "Route", "Code", "Sch_Route")

    End Sub

    Private Sub FTp_Expense(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ExpenseType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "OnEveryKms", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OnEveryDays", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    'Private Sub FTp_TransportAllotment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
    '    AgL.FAddTable(MdlTable, StrTableName, ModuleName)

    '    AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
    '    AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
    '    AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
    '    AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    '    AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
    '    AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
    '    AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
    '    AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    '    AgL.FSetColumnValue(MdlTable, "SubCodeType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
    '    AgL.FSetColumnValue(MdlTable, "ValidTillDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    '    AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
    '    AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
    '    AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
    '    AgL.FSetColumnValue(MdlTable, "ProgrammeYear", AgLibrary.ClsMain.SQLDataType.Int)
    '    AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    '    AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    '    AgL.FSetColumnValue(MdlTable, "Area", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
    '    AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    '    AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    '    AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
    '    AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    '    AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    '    AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    '    AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    '    AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
    '    AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

    '    AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    '    AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")

    '    AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    '    AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    '    AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")

    'End Sub

    Private Sub FTp_Member(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Student", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Employee", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MemberCardNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CardPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CardSrNo", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "ValidTillDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SeatNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Route", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "PickUpPoint", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ReminderRemark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "InActiveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Student", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Employee", "SubCode", "SubGroup")

        AgL.FSetFKeyValue(MdlTable, "Vehicle", "Code", "Tp_Vehicle")
        AgL.FSetFKeyValue(MdlTable, "Route", "Code", "Sch_Route")
        AgL.FSetFKeyValue(MdlTable, "PickUpPoint", "Code", "Sch_Area")

    End Sub

    Private Sub FTp_MaintenanceExpenseEntry(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Party", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyDocumentNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "PartyDocumentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalLineAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalLineNetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetSubTotal", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RoundOff", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)

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
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")

        AgL.FSetFKeyValue(MdlTable, "Party", "SubCode", "SubGroup")
    End Sub

    Private Sub FTp_MaintenanceExpenseEntry1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)


        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Expense", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ExpenseDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeterReading", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NextAfterKm", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NextMeterReading", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NextAfterDays", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NextDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        If EntryType = EntryPointType.Log Then     'In Case of line file
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Tp_MaintenanceExpenseEntry_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Tp_MaintenanceExpenseEntry")
        End If

        AgL.FSetFKeyValue(MdlTable, "Expense", "Code", "Tp_Expense")
        AgL.FSetFKeyValue(MdlTable, "Vehicle", "Code", "Tp_Vehicle")

    End Sub

    Private Sub FTp_Enviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True, False)
        AgL.FSetColumnValue(MdlTable, "MemberACGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "EmployeeACGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "IsLinkWithAcademic", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")

    End Sub

    Private Sub FTp_MemberAttendance(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nvarchar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nvarchar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nvarchar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nvarchar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.bigint)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nvarchar, 20)
        AgL.FSetColumnValue(MdlTable, "InOut", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "GateInOutDocID", AgLibrary.ClsMain.SQLDataType.nvarchar, 21)
        AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "Driver", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMember", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "TotalPresent", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "TotalAbsent", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nvarchar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nvarchar, 8)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")

        AgL.FSetFKeyValue(MdlTable, "GateInOutDocID", "DocId", "GateInOut")
        AgL.FSetFKeyValue(MdlTable, "Vehicle", "Code", "Tp_Vehicle")
        AgL.FSetFKeyValue(MdlTable, "Driver", "SubCode", "SubGroup")
    End Sub

    Private Sub FTp_MemberAttendance1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Member", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Route", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "PickUpPoint", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "IsPresent", AgLibrary.ClsMain.SQLDataType.bit)
        AgL.FSetColumnValue(MdlTable, "IsUnRegistered", AgLibrary.ClsMain.SQLDataType.bit)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        If EntryType = EntryPointType.Log Then     'In Case of line file
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Tp_MemberAttendance_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Tp_MemberAttendance")
        End If

        AgL.FSetFKeyValue(MdlTable, "Member", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Route", "Code", "Sch_Route")
        AgL.FSetFKeyValue(MdlTable, "PickUpPoint", "Code", "Sch_Area")
    End Sub
    
    Public Sub InitializeTables()
        TB_PostingGroupSalesTaxParty()

        TB_ExpenseType()

    End Sub

    Public Sub InitializeStructure()
        Call ST_VehicleMaintenanceExpense()
    End Sub

    Private Sub ST_VehicleMaintenanceExpense()
        Dim mQry$ = "", bStrCode$ = Temp_Structure.VehicleMaintenanceExpense, bStrNCat$ = Temp_NCat.VehicleMaintenanceExpenseEntry
        Try
            If AgL.Dman_Execute("Select IsNull(Count(*),0) As Cnt From Structure With (NoLock) Where Code = '" & bStrCode & "'", AgL.GcnRead).ExecuteScalar = 0 Then
                mQry = "INSERT INTO dbo.Structure (Code, Description, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                                " VALUES ('" & bStrCode & "', '" & bStrCode & "', " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                If AgL.Dman_Execute("Select IsNull(Count(*),0) As Cnt From StructureDetail With (NoLock) Where Code = '" & bStrCode & "'", AgL.GcnRead).ExecuteScalar = 0 Then
                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 10, '" & Temp_Charges.GrossAmount & "', 'Charges', 'FixedValue', NULL, '|Amount|', NULL, Null, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 20, '" & Temp_Charges.LineAddition & "', 'Charges', 'Percentage Or Amount', NULL, '{GAMT}*{LAdd}/100', NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 1, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 30, '" & Temp_Charges.LineDeduction & "', 'Charges', 'Percentage Or Amount', NULL, '{GAMT}*{LDed}/100', NULL, NULL, NULL, NULL, 1, 0, 1, 0, 0, 0, 1, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 40, '" & Temp_Charges.LineNetAmount & "', 'Charges', 'FixedValue', NULL, '{GAMT}+{LAdd}-{LDed}', NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 1, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 50, '" & Temp_Charges.HeaderAddition & "', 'Charges', 'Percentage Or Amount', NULL, '{LNAmt}*{HAdd}/100', 'Line Net Amount', NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 60, '" & Temp_Charges.HeaderDeduction & "', 'Charges', 'Percentage Or Amount', NULL, '{LNAmt}*{HDed}/100', 'Line Net Amount', NULL, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 70, '" & Temp_Charges.NetSubTotal & "', 'Charges', 'FixedValue', NULL, '{LNAmt}+{HAdd}-{HDed}', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 80, '" & Temp_Charges.RoundOff & "', 'Charges', 'FixedValue', NULL, 'ROUND({NSTot},0)-{NSTot}', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 90, '" & Temp_Charges.NetAmount & "', 'Charges', 'FixedValue', NULL, '{NSTot}+{ROff}', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If

                '=====================================================================================================================================================================
                '====================< Update Structure Code In VoucherCat Table >====================================================================================================
                '=======================================< Start >=====================================================================================================================
                '=====================================================================================================================================================================
                mQry = "UPDATE VoucherCat SET Structure = " & AgL.Chk_Text(bStrCode) & " WHERE NCat = " & AgL.Chk_Text(bStrNCat) & " AND IsNull(Structure,'') <> " & AgL.Chk_Text(bStrCode) & ""
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                '=====================================================================================================================================================================
                '====================< Update Structure Code In VoucherCat Table >====================================================================================================
                '=======================================< End >=====================================================================================================================
                '=====================================================================================================================================================================

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
End Class