Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Mess"
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
        Call IniDtMess_Enviro()
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
        Public Const VehicleMaintenanceExpenseEntry As String = "VME"

        Public Const StorePurchase As String = "STPUR"
        Public Const StoreSale As String = "STSAL"
        Public Const StoreSaleOld As String = "STSLO"
        Public Const StoreIssue As String = "STISS"
        Public Const StoreReceive As String = "STREC"
        Public Const StoreIssueReceive As String = "STIR"
        Public Const StoreOpening As String = "STOP"
        Public Const StoreSupplierBill As String = "STSB"

        Public Const MessPurchase As String = "MPUR"
        Public Const MessPurchaseReturn As String = "MPRT"

        Public Const MessStockAdjustment As String = "MSADJ"
        Public Const MessStockOpening As String = "MSOP"

        Public Const MessMenu As String = "MENU"
        Public Const MessMemberLeaveEntry As String = "MLEV"
        Public Const MessMemberAttendance As String = "MMA"
        Public Const MessExtraPersonEntry As String = "MEP"

        Public Const MessConsumption As String = "CONS"
    End Class

    Class Temp_Cat
        Public Const StorePurchase As String = "STPUR"
        Public Const StoreSale As String = "STSAL"
        Public Const StoreIssue As String = "STISS"
        Public Const StoreReceive As String = "STREC"
        Public Const StoreIssueReceive As String = "STIR"
        Public Const StoreSupplierBill As String = "STSB"
    End Class

    Class Temp_Structure
        Public Const MessPurchase As String = "MessPur"
        Public Const MessPurchaseReturn As String = "MPRT"
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


    Public Class InOut
        Public Const GateIn As String = "IN"
        Public Const GateOut As String = "OUT"
    End Class


    Public Class Shift
        Public Const BreakFast As String = "Break Fast"
        Public Const Lunch As String = "Lunch"
        Public Const Tiffin As String = "Tiffin"
        Public Const Dinner As String = "Dinner"
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
            '==================< Set Item Unit Field Size To nvarchar(20)  >============================================================================================
            '===================================< Start  >==============================================================================================================
            '===========================================================================================================================================================
            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM INFORMATION_SCHEMA.COLUMNS T With (NoLock) " & _
                    " WHERE T.COLUMN_NAME = 'Unit' " & _
                    " AND T.TABLE_NAME = 'Store_Item' " & _
                    " AND T.CHARACTER_MAXIMUM_LENGTH = 8 "
            If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Item' AND CONSTRAINT_NAME = 'FK_Store_Item_Store_Unit' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Item DROP CONSTRAINT [FK_Store_Item_Store_Unit]", AgL.GCn)

                    AgL.EditField("Store_Item", "Unit", "nvarchar(20)", GcnRead)
                End If
            End If

            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM INFORMATION_SCHEMA.COLUMNS T With (NoLock) " & _
                    " WHERE T.COLUMN_NAME = 'Code' " & _
                    " AND T.TABLE_NAME = 'Store_Unit' " & _
                    " AND T.CHARACTER_MAXIMUM_LENGTH = 8 "
            If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                AgL.EditField("Store_Unit", "Code", "nvarchar(20)", GcnRead, False)
            End If

            '===========================================================================================================================================================
            '==================< Set Item Unit Field Size To nvarchar(20)  >============================================================================================
            '=====================================< End  >==============================================================================================================
            '===========================================================================================================================================================

            '===========================================================================================================================================================
            '==================< Set Item Code Field Size To nvarchar(10)  >============================================================================================
            '===================================< Start  >==============================================================================================================
            '===========================================================================================================================================================
            If FunFindField(GcnRead, "Item", "Sch_ProspectusSale", 8) Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Sch_ProspectusSale' AND CONSTRAINT_NAME = 'FK_Sch_ProspectusSale_Store_Item' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_ProspectusSale DROP CONSTRAINT [FK_Sch_ProspectusSale_Store_Item]", AgL.GCn)
                End If

                AgL.EditField("Sch_ProspectusSale", "Item", "nvarchar(10)", GcnRead)
            End If

            If FunFindField(GcnRead, "Item", "Store_Item_Nature1", 8) Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Item_Nature1' AND CONSTRAINT_NAME = 'FK_Store_Item_Nature1_Store_Item' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Item_Nature1 DROP CONSTRAINT [FK_Store_Item_Nature1_Store_Item]", AgL.GCn)
                End If

                AgL.EditField("Store_Item_Nature1", "Item", "nvarchar(10)", GcnRead)
            End If


            If FunFindField(GcnRead, "Item", "Store_Item_Nature2", 8) Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Item_Nature2' AND CONSTRAINT_NAME = 'FK_Store_Item_Nature2_Store_Item' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Item_Nature2 DROP CONSTRAINT [FK_Store_Item_Nature2_Store_Item]", AgL.GCn)
                End If

                AgL.EditField("Store_Item_Nature2", "Item", "nvarchar(10)", GcnRead)
            End If

            If FunFindField(GcnRead, "Item", "Store_Stock", 8) Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Stock' AND CONSTRAINT_NAME = 'FK_Store_Stock_Store_Item' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Stock DROP CONSTRAINT [FK_Store_Stock_Store_Item]", AgL.GCn)
                End If

                AgL.EditField("Store_Stock", "Item", "nvarchar(10)", GcnRead)
            End If

            If FunFindField(GcnRead, "Code", "Store_Item", 8) Then
                AgL.EditField("Store_Item", "Code", "nvarchar(10)", GcnRead)
            End If
            '===========================================================================================================================================================
            '==================< Set Item Code Field Size To nvarchar(10)  >============================================================================================
            '===================================< End  >==============================================================================================================
            '===========================================================================================================================================================


            '===========================================================================================================================================================
            '==================< Set Godown Code Field Size To nvarchar(10)  >============================================================================================
            '===================================< Start  >==============================================================================================================
            '===========================================================================================================================================================
            If FunFindField(GcnRead, "Godown", "Store_Enviro", 8) Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Enviro' AND CONSTRAINT_NAME = 'FK_Store_Enviro_Godown' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Enviro DROP CONSTRAINT [FK_Store_Enviro_Godown]", AgL.GCn)
                End If

                AgL.EditField("Store_Enviro", "Godown", "nvarchar(10)", GcnRead)
            End If

            If FunFindField(GcnRead, "Godown", "Store_Stock", 8) Then
                mQry = "SELECT Isnull(count(*),0) Cnt FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS With (NoLock) WHERE CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'Store_Stock' AND CONSTRAINT_NAME = 'FK_Store_Stock_Godown' "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Store_Stock DROP CONSTRAINT [FK_Store_Stock_Godown]", AgL.GCn)
                End If

                AgL.EditField("Store_Stock", "Godown", "nvarchar(10)", GcnRead)
            End If

            If FunFindField(GcnRead, "Code", "Store_Godown", 8) Then
                AgL.EditField("Store_Godown", "Code", "nvarchar(10)", GcnRead)
            End If
            '===========================================================================================================================================================
            '==================< Set Godown Code Field Size To nvarchar(10)  >============================================================================================
            '===================================< End  >==============================================================================================================
            '===========================================================================================================================================================

            'If AgL.IsFieldExist("ScholarshipApplied", "Sch_Student", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP CONSTRAINT [DF_Sch_Student_EnglishProficiency_TOEFL1]", AgL.GCn)
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP COLUMN ScholarshipApplied", AgL.GCn)
            'End If
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
            ''===================================================< Mess Purchase Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessPurchase, ClsMain.Temp_NCat.MessPurchase, "Mess Purchase", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessPurchase, ClsMain.Temp_NCat.MessPurchase, ClsMain.Temp_NCat.MessPurchase, "Mess Purchase", ClsMain.Temp_NCat.MessPurchase, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Purchase Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessPurchaseReturn, ClsMain.Temp_NCat.MessPurchaseReturn, "Mess Purchase Return", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessPurchaseReturn, ClsMain.Temp_NCat.MessPurchaseReturn, ClsMain.Temp_NCat.MessPurchaseReturn, "Mess Purchase Return", ClsMain.Temp_NCat.MessPurchaseReturn, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Menu V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessMenu, ClsMain.Temp_NCat.MessMenu, "Mess Menu", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessMenu, ClsMain.Temp_NCat.MessMenu, ClsMain.Temp_NCat.MessMenu, "Mess Menu", ClsMain.Temp_NCat.MessMenu, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Member Leave Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessMemberLeaveEntry, ClsMain.Temp_NCat.MessMemberLeaveEntry, "Mess Member Leave Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessMemberLeaveEntry, ClsMain.Temp_NCat.MessMemberLeaveEntry, ClsMain.Temp_NCat.MessMemberLeaveEntry, "Mess Member Leave Entry", ClsMain.Temp_NCat.MessMemberLeaveEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Member Attendance Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessMemberAttendance, ClsMain.Temp_NCat.MessMemberAttendance, "Mess Member Attendance Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessMemberAttendance, ClsMain.Temp_NCat.MessMemberAttendance, ClsMain.Temp_NCat.MessMemberAttendance, "Mess Member Attendance Entry", ClsMain.Temp_NCat.MessMemberAttendance, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Extra Person Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessExtraPersonEntry, ClsMain.Temp_NCat.MessExtraPersonEntry, "Mess Extra Person Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessExtraPersonEntry, ClsMain.Temp_NCat.MessExtraPersonEntry, ClsMain.Temp_NCat.MessExtraPersonEntry, "Mess Extra Person Entry", ClsMain.Temp_NCat.MessExtraPersonEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Consumption Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessConsumption, ClsMain.Temp_NCat.MessConsumption, "Mess Consumption Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessConsumption, ClsMain.Temp_NCat.MessConsumption, ClsMain.Temp_NCat.MessConsumption, "Mess Consumption Entry", ClsMain.Temp_NCat.MessConsumption, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Stock Opening Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessStockOpening, ClsMain.Temp_NCat.MessStockOpening, "Mess Stock Opening", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessStockOpening, ClsMain.Temp_NCat.MessStockOpening, ClsMain.Temp_NCat.MessStockOpening, "Mess Stock Opening", ClsMain.Temp_NCat.MessStockOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

            ''===================================================< Mess Stock Adjustment Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.MessStockAdjustment, ClsMain.Temp_NCat.MessStockAdjustment, "Mess Stock Adjustment", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.MessStockAdjustment, ClsMain.Temp_NCat.MessStockAdjustment, ClsMain.Temp_NCat.MessStockAdjustment, "Mess Stock Adjustment", ClsMain.Temp_NCat.MessStockAdjustment, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
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

    Private Sub TB_Shift()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            If AgL.IsTableExist("Mess_Shift", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM Mess_Shift WHERE Code = '" & Shift.BreakFast & "') " & _
                            " INSERT INTO dbo.Mess_Shift (Code) VALUES ('" & Shift.BreakFast & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Mess_Shift WHERE Code = '" & Shift.Lunch & "') " & _
                            " INSERT INTO dbo.Mess_Shift (Code) VALUES ('" & Shift.Lunch & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Mess_Shift WHERE Code = '" & Shift.Tiffin & "') " & _
                            " INSERT INTO dbo.Mess_Shift (Code) VALUES ('" & Shift.Tiffin & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Mess_Shift WHERE Code = '" & Shift.Dinner & "') " & _
                            " INSERT INTO dbo.Mess_Shift (Code) VALUES ('" & Shift.Dinner & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Call ChangeFieldSize_BeforeCreateDatabase()

        FParty(MdlTable, "Party")

        FStore_Godown(MdlTable, "Store_Godown")
        FStore_Unit(MdlTable, "Store_Unit")
        FStore_ItemCategory(MdlTable, "Store_ItemCategory")
        FStore_ItemGroup(MdlTable, "Store_ItemGroup")
        FStore_Item(MdlTable, "Store_Item")
        FStore_Item_Nature1(MdlTable, "Store_Item_Nature1")
        FStore_Item_Nature2(MdlTable, "Store_Item_Nature2")

        FStore_BOM(MdlTable, "Store_BOM")
        FStore_BomDetail(MdlTable, "Store_BomDetail")

        FStore_Purchase(MdlTable, "Store_Purchase")
        FStore_PurchaseDetail(MdlTable, "Store_PurchaseDetail")

        FStore_StockAdjustment(MdlTable, "Store_StockAdjustment")

        FStore_StockHeader(MdlTable, "Store_StockHeader")
        FStore_Stock(MdlTable, "Store_Stock")

        FMess_Shift(MdlTable, "Mess_Shift")

        FMess_Menu(MdlTable, "Mess_Menu")
        FMess_Menu1(MdlTable, "Mess_Menu1")

        FMess_Member(MdlTable, "Mess_Member")

        FMess_Leave(MdlTable, "Mess_Leave")

        FMess_Attendance(MdlTable, "Mess_Attendance")
        FMess_Attendance1(MdlTable, "Mess_Attendance1")


        FMess_ExtraPerson(MdlTable, "Mess_ExtraPerson")
        FMess_ExtraPerson1(MdlTable, "Mess_ExtraPerson1")

        FMess_Consumption(MdlTable, "Mess_Consumption")
        FMess_Consumption1(MdlTable, "Mess_Consumption1")
        FMess_Consumption2(MdlTable, "Mess_Consumption2")

        FMess_Enviro(MdlTable, "Mess_Enviro")
    End Sub

    Private Sub FParty(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PartyNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "InActiveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    End Sub

    Private Sub FMess_Enviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True, False)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "IsShiftAttendance", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)
        AgL.FSetColumnValue(MdlTable, "AttendanceDbName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "AttendanceServer", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "AttendanceUser", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "AttendancePassword", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)

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

    Private Sub FStore_Unit(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
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

    Private Sub FStore_Godown(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
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

    Private Sub FStore_ItemCategory(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

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

    Private Sub FStore_ItemGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

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
        AgL.FSetFKeyValue(MdlTable, "ItemCategory", "Code", "Store_ItemCategory")
    End Sub

    Private Sub FStore_Item(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "DisplayName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ItemGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PcsPerCase", AgLibrary.ClsMain.SQLDataType.Float, , , , 1)
        AgL.FSetColumnValue(MdlTable, "ReOrderLevel", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "MRP", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PurchaseRate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "SalesTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ExcisePostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "EntryTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)


        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "SaleRate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)



        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "ItemGroup", "Code", "Store_ItemGroup")
        AgL.FSetFKeyValue(MdlTable, "ItemCategory", "Code", "Store_ItemCategory")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
    End Sub

    Private Sub FStore_Item_Nature1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
    End Sub

    Private Sub FStore_Item_Nature2(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
    End Sub


    Private Sub FStore_BOM(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ForItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ForUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ForQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ForWeight", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
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
        AgL.FSetFKeyValue(MdlTable, "ForItem", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "ForUnit", "Code", "Store_Unit")

    End Sub

    Private Sub FStore_BomDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ConsumptionPer", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Store_Bom")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
    End Sub

    Private Sub FStore_Purchase(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PartyBillNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PartyBillDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "AcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)


        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Addition", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Deduction", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Addition_H", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Deduction_H", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "NetSubTotal", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RoundOff", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "InvoiceAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "AcCode", "SubCode", "SubGroup")

    End Sub

    Private Sub FStore_PurchaseDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BatchNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Addition", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Deduction", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Addition_H", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Deduction_H", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "LandedAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ReferenceUId", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_Purchase")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Store_Godown")
    End Sub

    Private Sub FStore_StockAdjustment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "AcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Department2", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalIssueQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalReceiveQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

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

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "AcCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AcCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Sch_Department")
        AgL.FSetFKeyValue(MdlTable, "Department2", "Code", "Sch_Department")
    End Sub

    Private Sub FStore_StockHeader(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)

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
    End Sub

    Private Sub FStore_Stock(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "AcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Item_Nature1", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item_Nature2", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BatchNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "IssueReceive", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Qty_Rec", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Qty_Iss", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Addition", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Deduction", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Addition_H", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Deduction_H", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "LandedAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ReferenceUId", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_StockHeader")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "AcCode", "SubCode", "SubGroup")

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Store_Godown")
    End Sub

    Private Sub FMess_Shift(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
    End Sub

    Private Sub FMess_Menu(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "WeekDay", AgLibrary.ClsMain.SQLDataType.SmallInt)
        AgL.FSetColumnValue(MdlTable, "Shift", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)

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
        AgL.FSetFKeyValue(MdlTable, "WeekDay", "Code", "Sch_WeekDay")
        AgL.FSetFKeyValue(MdlTable, "Shift", "Code", "Mess_Shift")
    End Sub

    Private Sub FMess_Menu1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Mess_Menu")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
    End Sub

    Private Sub FMess_Member(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Student", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Employee", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MemberType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ReminderRemark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "JoiningDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "InActiveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MessAttendanceCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Student", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Employee", "SubCode", "SubGroup")
    End Sub

    Private Sub FMess_Leave(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Member", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ToDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalDays", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

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
        AgL.FSetFKeyValue(MdlTable, "Member", "SubCode", "SubGroup")
    End Sub

    Private Sub FMess_Attendance(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RefNoPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RefNoSr", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Shift", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "TotalMember", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalPresent", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalAbsent", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

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
        AgL.FSetFKeyValue(MdlTable, "Shift", "Code", "Mess_Shift")
    End Sub

    Private Sub FMess_Attendance1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Member", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsPresent", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Mess_Attendance")
        AgL.FSetFKeyValue(MdlTable, "Member", "SubCode", "SubGroup")
    End Sub

    Private Sub FMess_ExtraPerson(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ToDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalDays", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalPerson", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

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
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    End Sub

    Private Sub FMess_ExtraPerson1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "PersonName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Relation", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Mess_ExtraPerson")
    End Sub

    Private Sub FMess_Consumption(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "TotalMember", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalExtra", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalPerson", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)

        AgL.FSetColumnValue(MdlTable, "GrossAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

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

    End Sub

    Private Sub FMess_Consumption1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BatchNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Mess_Consumption")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Store_Godown")
    End Sub

    Private Sub FMess_Consumption2(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Shift", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Member", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Extra", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Total", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Mess_Consumption")
        AgL.FSetFKeyValue(MdlTable, "Shift", "Code", "Mess_Shift")
    End Sub

    Public Sub InitializeTables()
        TB_PostingGroupSalesTaxParty()

        TB_Shift()

    End Sub

    Public Sub InitializeStructure()
        Call ST_MessPurchase()
        Call ST_MessPurchaseReturn()
    End Sub

    Private Sub ST_MessPurchase()
        Dim mQry$ = "", bStrCode$ = Temp_Structure.MessPurchase, bStrNCat$ = Temp_NCat.MessPurchase
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

    Private Sub ST_MessPurchaseReturn()
        Dim mQry$ = "", bStrCode$ = Temp_Structure.MessPurchaseReturn, bStrNCat$ = Temp_NCat.MessPurchaseReturn
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

#Region "Purchase Register Query"
    Public Function FunQueryPurchaseRegister(ByVal StrNCat As String, ByVal StrFromDate As String, ByVal StrToDate As String, _
                                           Optional ByVal CondStrSite As String = "", _
                                           Optional ByVal CondStrVoucherType As String = "", _
                                           Optional ByVal CondStrParty As String = "", _
                                           Optional ByVal CondStrItemCategory As String = "", _
                                           Optional ByVal CondStrItemGroup As String = "", _
                                           Optional ByVal CondStrItem As String = "" _
                                           ) As String
        Dim StrReturn$ = ""
        Dim mCondStr$ = ""
        Try

            mCondStr = " Where H.V_Date Between " & AgL.ConvertDate(StrFromDate) & " And " & AgL.ConvertDate(StrToDate) & " "

            mCondStr += " And Vt.NCat = '" & StrNCat & "' "


            mCondStr += CondStrSite
            mCondStr += CondStrVoucherType
            mCondStr += CondStrParty
            mCondStr += CondStrItemCategory
            mCondStr += CondStrItemGroup
            mCondStr += CondStrItem

            StrReturn = "SELECT H.DocId, " & AgL.V_No_Field("H.DocId") & " As VoucherNo, H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No, H.V_Date, " & _
                        " H.PartyBillNo, H.PartyBillDate, H.AcCode As PartyCode, " & _
                        " H.Amount AS Header_Amount, H.Addition AS Header_Addition, H.Deduction AS Header_Deduction, " & _
                        " H.NetAmount AS Header_NetAmount, H.Addition_H, H.Deduction_H, H.InvoiceAmount,  " & _
                        " H.PreparedBy, H.U_EntDt, H.Edit_Date, H.ModifiedBy, H.Remark AS Header_Remark,  " & _
                        " H.ReferenceNo, H.NetSubTotal, H.RoundOff,  " & _
                        " H.TotalQty, H.SalesTaxGroupParty, " & _
                        " L.Item AS ItemCode, L.ItemDescription, L.Unit, L.BatchNo, L.Godown, L.DocQty, L.Qty,  " & _
                        " L.Rate, L.Amount, L.Addition AS Line_Addition, L.Deduction AS Line_Deduction,  " & _
                        " L.NetAmount AS Line_NetAmount, L.Remark AS Line_Remark, L.SalesTaxGroupItem, " & _
                        " Vt.Description AS VoucherType, Site.Name AS Site_Name, Site.ManualCode AS SiteManualCode, " & _
                        " Sg.Name AS PartyName, Sg.DispName AS PartyDispName, Sg.ManualCode AS PartyManualCode, " & _
                        " Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, City.CityName, Sg.Phone, Sg.Mobile, Sg.FAX,  " & _
                        " Sg.LSTNo, Sg.CSTNo, Sg.TINNo, Sg.PAN, Sg.EMail, " & _
                        " Item.Description AS ItemName, Item.ManualCode AS ItemManualCode, " & _
                        " Ic.Description AS ItemCategory, Ig.Description AS ItemGroup ,SF.*,SL.* " & _
                        " FROM dbo.Store_Purchase H WITH (NoLock) " & _
                        " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                        " LEFT JOIN SiteMast Site ON Site.Code = H.Site_Code  " & _
                        " LEFT JOIN Store_PurchaseDetail L WITH (NoLock) ON L.DocId = H.DocId  " & _
                        " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode  " & _
                        " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                        " LEFT JOIN Store_Item AS Item  WITH (NoLock) ON Item.Code = L.Item  " & _
                        " LEFT JOIN Store_ItemCategory Ic WITH (NoLock) ON Ic.Code = Item.ItemCategory  " & _
                        " LEFT JOIN Store_ItemGroup Ig WITH (NoLock) ON Ig.Code = Item.ItemGroup  " & _
                        " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, StrNCat) & ") As SF On H.DocId = SF.DocId " & _
                        " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, StrNCat) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr "

            StrReturn += mCondStr

        Catch ex As Exception
            MsgBox(ex.Message)
            StrReturn = ""
        Finally
            FunQueryPurchaseRegister = StrReturn
        End Try
    End Function
#End Region

#Region "Stock Register Query"
    Public Function FunQueryStockRegister(ByVal StrFromDate As String, ByVal StrToDate As String, _
                                           Optional ByVal CondStrSite As String = "", _
                                           Optional ByVal CondStrParty As String = "", _
                                           Optional ByVal CondStrGodown As String = "", _
                                           Optional ByVal CondStrItemCategory As String = "", _
                                           Optional ByVal CondStrItemGroup As String = "", _
                                           Optional ByVal CondStrItem As String = "", _
                                           Optional ByVal CondStrNature As String = "" _
                                           ) As String
        Dim StrReturn$ = ""
        Try

            Dim mCondStr$ = "", mCondStr1$ = "", bStrOpeningStockQry$ = "", bStrCurrentStockQry$ = ""


            mCondStr = " Where 1=1 "

            mCondStr += CondStrSite
            mCondStr += CondStrParty
            mCondStr += CondStrGodown
            mCondStr += CondStrItemCategory
            mCondStr += CondStrItemGroup
            mCondStr += CondStrItem
            mCondStr += CondStrNature

            mCondStr1 = mCondStr
            mCondStr1 += " And H.V_Date < " & AgL.ConvertDate(StrFromDate) & "  "
            mCondStr += " And H.V_Date Between " & AgL.ConvertDate(StrFromDate) & " And " & AgL.ConvertDate(StrToDate) & " "

            bStrOpeningStockQry = " SELECT 'Opening' As DocId," & _
                                     " 0 As Sr, " & _
                                     " Null As VoucherNo," & _
                                     " H.Div_Code," & _
                                     " H.Site_Code," & _
                                     " 'Opening' as V_Type," & _
                                     " 'Opening' As V_Prefix," & _
                                     " -1 As V_No, " & _
                                     " " & AgL.Chk_Text(StrFromDate) & " As V_Date," & _
                                     " H.Item," & _
                                     " H.BatchNo, " & _
                                     " Case When Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) >= 0 Then 'Receive'  Else 'Issue' End  As IssueReceive, " & _
                                     " 0 As DocQty, " & _
                                     " Case When Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) >= 0 Then  Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) Else 0 End As Qty_Rec, " & _
                                     " Case When Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) < 0 Then  Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) Else 0 End As Qty_Iss, " & _
                                     " 0 As Rate," & _
                                     " 0 As Amount," & _
                                     " Null As Remark, " & _
                                     " H.Godown, " & _
                                     " H.ItemDescription," & _
                                     " Null as ReferenceNo," & _
                                     " Null AS PartyCode," & _
                                     " Max(H.Unit) as Unit," & _
                                     " Null As Uid," & _
                                     " Null As ReferenceDocId," & _
                                     " Null As ReferenceUId, " & _
                                     " Null as SalesTaxGroupParty," & _
                                     " Null as SalesTaxGroupItem," & _
                                     " Null AS VoucherDescription," & _
                                     " Null AS VoucherType," & _
                                     " max(SITE.Name) AS Site_Name, " & _
                                     " max(Site.ManualCode) AS SiteManualCode," & _
                                     " Max(Sg.Name) AS PartyName, " & _
                                     " Null AS PartyDispName, " & _
                                     " Null AS PartyManualCode, " & _
                                     " Null as Add1, " & _
                                     " Null as Add2, " & _
                                     " Null as Add3," & _
                                     " Null as PIN, " & _
                                     " Null as CityName," & _
                                     " Null as Phone,  " & _
                                     " Null as Mobile," & _
                                     " Null as FAX,  " & _
                                     " Null as LSTNo," & _
                                     " Null as CSTNo," & _
                                     " Null as TINNo," & _
                                     " Null as PAN," & _
                                     " Null as EMail, " & _
                                     " max(Item.Description) AS ItemName," & _
                                     " max(Item.ManualCode) AS ItemManualCode," & _
                                     " max(Ic.Description) AS ItemCategory, " & _
                                     " max(Ig.Description) AS ItemGroup," & _
                                     " max(Godown.Description) as GodownName " & _
                                     " FROM dbo.Store_Stock H WITH (NoLock)" & _
                                     " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type " & _
                                     " LEFT JOIN SiteMast Site ON Site.Code = H.Site_Code  " & _
                                     " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode" & _
                                     " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                                     " LEFT JOIN Store_Item AS Item  WITH (NoLock) ON Item.Code = H.Item " & _
                                     " LEFT JOIN Store_ItemCategory Ic WITH (NoLock) ON Ic.Code = Item.ItemCategory" & _
                                     " LEFT JOIN Store_ItemGroup Ig WITH (NoLock) ON Ig.Code = Item.ItemGroup  " & _
                                     " LEFT JOIN Store_Godown Godown WITH (NoLock) ON Godown.Code = H.Godown  " & mCondStr1 & _
                                     " Group By H.Div_Code, H.Site_Code, H.Item, H.BatchNo, H.ItemDescription, H.Godown "

            bStrCurrentStockQry = " SELECT H.DocId, H.Sr, " & AgL.V_No_Field("H.DocId") & " As VoucherNo,H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No, H.V_Date," & _
                                 " H.Item, H.BatchNo, H.IssueReceive, H.DocQty, H.Qty_Rec, H.Qty_Iss, " & _
                                 " H.Rate, H.Amount, H.Remark, H.Godown, " & _
                                 " H.ItemDescription, H.ReferenceNo, H.AcCode AS PartyCode, H.Unit," & _
                                 " Convert(varchar(36),H.UID) As Uid, H.ReferenceDocId, convert(varchar(36),H.ReferenceUId) as ReferenceUId, " & _
                                 " H.SalesTaxGroupParty, H.SalesTaxGroupItem," & _
                                 " Vt.Description AS VoucherDescription," & _
                                 " Vt.Description AS VoucherType, Site.Name AS Site_Name, Site.ManualCode AS SiteManualCode," & _
                                 " Sg.Name AS PartyName, Sg.DispName AS PartyDispName, Sg.ManualCode AS PartyManualCode, " & _
                                 " Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, City.CityName, Sg.Phone, Sg.Mobile, Sg.FAX,  " & _
                                 " Sg.LSTNo, Sg.CSTNo, Sg.TINNo, Sg.PAN, Sg.EMail, " & _
                                 " Item.Description AS ItemName, Item.ManualCode AS ItemManualCode," & _
                                 " Ic.Description AS ItemCategory, Ig.Description AS ItemGroup,Godown.Description as GodownName" & _
                                 " FROM dbo.Store_Stock H WITH (NoLock)" & _
                                 " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type " & _
                                 " LEFT JOIN SiteMast Site ON Site.Code = H.Site_Code  " & _
                                 " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode" & _
                                 " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                                 " LEFT JOIN Store_Item AS Item  WITH (NoLock) ON Item.Code = H.Item " & _
                                 " LEFT JOIN Store_ItemCategory Ic WITH (NoLock) ON Ic.Code = Item.ItemCategory" & _
                                 " LEFT JOIN Store_ItemGroup Ig WITH (NoLock) ON Ig.Code = Item.ItemGroup  " & _
                                 " LEFT JOIN Store_Godown Godown WITH (NoLock) ON Godown.Code = H.Godown  "

            bStrCurrentStockQry += mCondStr

            StrReturn = bStrOpeningStockQry + " UNION ALL " + bStrCurrentStockQry
        Catch ex As Exception
            MsgBox(ex.Message)
            StrReturn = ""
        Finally
            FunQueryStockRegister = StrReturn
        End Try
    End Function
#End Region
End Class