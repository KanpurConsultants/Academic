Public Class ClsMain    
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Library"
    'Public MdlTable As AgLibrary.ClsMain.LITable()

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        ObjAgTemplate = New AgTemplate.ClsMain(AgL)
        ObjCommon_Master = New Common_Master.ClsMain(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtLib_Enviro()
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


    Public Class PostingGroupSalesTaxParty
        Public Const Local As String = "Local"
        Public Const Central As String = "Central"
        Public Const LocalWithFormH As String = "Local {Form `H`}"
        Public Const CentralWithFormC As String = "Central {Form `C`}"
        Public Const Export As String = "Export"
    End Class

    Public Class InOut
        Public Const GateIn As String = "IN"
        Public Const GateOut As String = "OUT"
    End Class

    Class Temp_HelpDataSet
        Public Shared SubjectHelpDataSet As DataSet = Nothing
        Public Shared BookTypeHelpDataSet As DataSet = Nothing
        Public Shared BookCodeHelpDataSet As DataSet = Nothing
        Public Shared BookTitleHelpDataSet As DataSet = Nothing
        Public Shared ISBNHelpDataSet As DataSet = Nothing
        Public Shared WriterHelpDataSet As DataSet = Nothing
        Public Shared PublisherHelpDataSet As DataSet = Nothing
        Public Shared SearchKeywordHelpDataSet As DataSet = Nothing
        Public Shared AccessionNoHelpDataSet As DataSet = Nothing
        Public Shared CallNoHelpDataSet As DataSet = Nothing
        Public Shared BookIDHelpDataSet As DataSet = Nothing
        Public Shared MemberCardNoHelpDataSet As DataSet = Nothing
    End Class

    Class Temp_SysEdition
        Public Const Week1 As String = "Week1"
        Public Const Week2 As String = "Week2"
        Public Const Week3 As String = "Week3"
        Public Const Week4 As String = "Week4"
        Public Const Fortnight1 As String = "Fortnight1"
        Public Const Fortnight2 As String = "Fortnight2"

        Public Const BiMonth1 As String = "BiMonth1"
        Public Const BiMonth2 As String = "BiMonth2"
        Public Const BiMonth3 As String = "BiMonth3"
        Public Const BiMonth4 As String = "BiMonth4"
        Public Const BiMonth5 As String = "BiMonth5"
        Public Const BiMonth6 As String = "BiMonth6"

        Public Const Quarter1 As String = "Quarter1"
        Public Const Quarter2 As String = "Quarter2"
        Public Const Quarter3 As String = "Quarter3"
        Public Const Quarter4 As String = "Quarter4"

        Public Const HalfYear1 As String = "HalfYear1"
        Public Const HalfYear2 As String = "HalfYear2"
    End Class


    Class Temp_NCat
        Public Const StationaryStockOpening As String = "SOSTK"
        Public Const StationaryAdjustmentIssue As String = "YAISS"
        Public Const BookTransferIssue As String = "BTRFI"
        Public Const BookTransferReceive As String = "OTRFR"
        Public Const BookRequisition As String = "BREQ"
        Public Const NewBookRequisition As String = "NBREQ"
        Public Const BookIndent As String = "BPIND"
        Public Const BookPurchaseQuotation As String = "BPQUT"
        Public Const BookPurchaseOrder As String = "BPORD"
        Public Const StationaryPurchaseOrder As String = "SPORD"
        Public Const BookGoodsReceive As String = "BGR"
        Public Const BookPurchaseInvoice As String = "BPINV"
        Public Const Generalsubscription As String = "GSUBS"
        Public Const GRNewBooks As String = "GRNEW"
        Public Const GROldBooks As String = "GROLD"
        Public Const GRDonatedBooks As String = "GRDON"
        Public Const GRRareBooks As String = "GRRAR"
        Public Const GRStationary As String = "GRSTN"
        Public Const InvoiceBooks As String = "BINV"
        Public Const InvoiceStationary As String = "SINV"
        Public Const DonatedBookIssue As String = "DBISS"
        Public Const ScrapQuotation As String = "SQOUT"
        Public Const ScrapSale As String = "SSALE"
        Public Const GeneralPeriodicalRecd As String = "GPRCD"
        Public Const BookIssueReceive As String = "B_ISR"
        Public Const GeneralPeriodicalMonthlyRecd As String = "GMRCD"
        Public Const GeneralPeriodicalYearlyRecd As String = "GYRCD"
        Public Const WriteOffBooks As String = "ADISS"
        Public Const WriteOffGenerals As String = "WOGEN"
        Public Const Accession As String = "ACESS"
        Public Const BranchTransfer As String = "BRTRF"
        Public Const BookIssueReceiveToBinder As String = "BISRB"
        Public Const BillEntry As String = "BILL"
        Public Const Payment As String = "PMNT"
        Public Const ScrapSaleRequisition As String = "SSREQ"
        Public Const StationaryQuotation As String = "STQUT"
        Public Const MemberVisit As String = "VISIT"
    End Class

    Public Class ItemType
        Public Const Book As String = "Book"
        Public Const Stationary As String = "Stationary"
        Public Const Generals As String = "Generals"
        Public Const CD As String = "CD"
    End Class

    Public Class Recurrance
        Public Const Daily As String = "Daily"
        Public Const Weekly As String = "Weekly"
        Public Const Fortnightly As String = "Fortnightly"
        Public Const Monthly As String = "Monthly"
        Public Const Bimonthly As String = "Bimonthly"
        Public Const Quarterly As String = "Quarterly"
        Public Const HalfYearly As String = "Half Yearly"
        Public Const Annually As String = "Annually"
        'Public Const LifeTime As String = "Life Time"
    End Class

    Public Class SmsEvent
        Public Const BookReturn_Reminder As String = "Book Return Reminder"
    End Class


    Public Shared Sub ProcFillSearchDataSet()
        Dim mQry$ = ""
        Dim ClsObj As New ClsMain(AgL)
        Try
            mQry = " SELECT S.Code AS Code, S.Description AS Subject, S.MsCode FROM Lib_Subject S  "
            Temp_HelpDataSet.SubjectHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT B.Code AS Code, B.Description AS BookType FROM Lib_BookType B  "
            Temp_HelpDataSet.BookTypeHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT I.ManualCode AS Code, I.ManualCode AS BookCode FROM Item I WHERE I.ManualCode IS NOT NULL AND I.ItemType = '" & ClsMain.ItemType.Book & "' "
            Temp_HelpDataSet.BookCodeHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT I.Description AS Code, I.Description AS BookTitle FROM Item I WHERE I.ManualCode IS NOT NULL AND I.ItemType = '" & ClsMain.ItemType.Book & "' "
            Temp_HelpDataSet.BookTitleHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT DISTINCT ISBN AS Code, ISBN  FROM Lib_Book WHERE ISBN IS NOT NULL "
            Temp_HelpDataSet.ISBNHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT DISTINCT Writer AS Code, Writer AS Writer   FROM Lib_Book WHERE Writer IS NOT NULL "
            Temp_HelpDataSet.WriterHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT DISTINCT Publisher AS Code, Publisher AS Publisher   FROM Lib_Book WHERE Publisher IS NOT NULL "
            Temp_HelpDataSet.PublisherHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT DISTINCT SearchKeyWords AS Code, SearchKeyWords AS SearchKeyWord FROM Lib_Book WHERE SearchKeyWords IS NOT NULL "
            Temp_HelpDataSet.SearchKeywordHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT Ad.AccessionNo AS Code, Ad.AccessionNo   FROM Lib_AccessionDetail Ad "
            Temp_HelpDataSet.AccessionNoHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT Distinct Ad.CallNo AS Code, Ad.CallNo FROM Lib_AccessionDetail Ad WHERE IsNull(Ad.CallNo,'') <> '' "
            Temp_HelpDataSet.CallNoHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT Ad.Book_UID AS Code, Ad.Book_UID FROM Lib_AccessionDetail Ad "
            Temp_HelpDataSet.BookIDHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT M.SubCode AS Code,M.MemberCardNo AS [Member Card No],SG.DispName AS MemberName  " & _
                      " FROM Lib_Member M " & _
                      " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode "
            Temp_HelpDataSet.MemberCardNoHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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
        Dim mQry$ = ""
        Try
            Call CreateDatabase(MdlTable)

            If AgL.IsFieldExist("DisplayName", "Item", AgL.GCn) Then
                mQry = "UPDATE Item SET Item.DisplayName = Lib_Book.BookDescription FROM Lib_Book WHERE Lib_Book.Code = Item.Code "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableInitialiser()
        Call DeleteField()
        Call CreateVType()
        Call CreateView()
        Call AddNewField()
        InitializeTables()

        Try
            If AgL.IsFieldExist("Description", "Item", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Item ALTER COLUMN Description NVARCHAR(100) NULL ", AgL.GCn)
            End If

            If AgL.IsFieldExist("Description", "Item_Log", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Item_Log ALTER COLUMN Description NVARCHAR(100) NULL ", AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''================================<< Lib_Enviro >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_Enviro", "IsAutoBookID", "bit", 0, False)

            ''================================<< Lib_MemberType >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_MemberType", "Site_Code", "nVarChar(2)")

            ''================================<< Lib_MemberType_Log >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_MemberType_Log", "Site_Code", "nVarChar(2)")
          
            ''================================<< Lib_Member >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_Member", "Site_Code", "nVarChar(2)")
          
            ''================================<< Lib_Member_Log >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_Member_Log", "Site_Code", "nVarChar(2)")

            ''================================<< Lib_BookType >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_BookType", "Site_Code", "nVarChar(2)")

            ''================================<< Lib_BookType_Log >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_BookType_Log", "Site_Code", "nVarChar(2)")

            ''================================<< Lib_ScrapCategory >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_ScrapCategory", "Site_Code", "nVarChar(2)")

            ''================================<< Lib_ScrapCategory_Log >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_ScrapCategory_Log", "Site_Code", "nVarChar(2)")

            ''================================<< Pay_Employee_Log >>====================================================================
            AgL.AddNewField(AgL.GCn, "Pay_Employee_Log", "MasterType", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee_Log", "CanTakeClass", "bit", 0)

        Catch ex As Exception

        End Try
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

            '===================================================< BranchTransfer V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BranchTransfer, Temp_NCat.BranchTransfer, "Branch Transfer", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BranchTransfer, Temp_NCat.BranchTransfer, Temp_NCat.BranchTransfer, "Branch Transfer", Temp_NCat.BranchTransfer, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Write Off Generals V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.WriteOffGenerals, Temp_NCat.WriteOffGenerals, "Write Off Generals", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.WriteOffGenerals, Temp_NCat.WriteOffGenerals, Temp_NCat.WriteOffGenerals, "Write Off Generals", Temp_NCat.WriteOffGenerals, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Accession V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.Accession, Temp_NCat.Accession, "Accession", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.Accession, Temp_NCat.Accession, Temp_NCat.Accession, "Accession", Temp_NCat.Accession, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Write Off Books V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.WriteOffBooks, Temp_NCat.WriteOffBooks, "Write Off Books", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.WriteOffBooks, Temp_NCat.WriteOffBooks, Temp_NCat.WriteOffBooks, "Write Off Books", Temp_NCat.WriteOffBooks, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Generals Monthly Recd V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GeneralPeriodicalMonthlyRecd, Temp_NCat.GeneralPeriodicalMonthlyRecd, "Generals Monthly Recd", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GeneralPeriodicalMonthlyRecd, Temp_NCat.GeneralPeriodicalMonthlyRecd, Temp_NCat.GeneralPeriodicalMonthlyRecd, "Generals Monthly Recd", Temp_NCat.GeneralPeriodicalMonthlyRecd, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Generals Yearly Recd V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GeneralPeriodicalYearlyRecd, Temp_NCat.GeneralPeriodicalYearlyRecd, "Generals Yealy Recd", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GeneralPeriodicalYearlyRecd, Temp_NCat.GeneralPeriodicalYearlyRecd, Temp_NCat.GeneralPeriodicalYearlyRecd, "Generals Yealy Recd", Temp_NCat.GeneralPeriodicalYearlyRecd, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)


            '===================================================< Other Material Stock Opening V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StationaryStockOpening, Temp_NCat.StationaryStockOpening, "Stationary Stock Opening", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StationaryStockOpening, Temp_NCat.StationaryStockOpening, Temp_NCat.StationaryStockOpening, "Stationary Stock Opening", Temp_NCat.StationaryStockOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Adjustment Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StationaryAdjustmentIssue, Temp_NCat.StationaryAdjustmentIssue, "Stationry Stock Adjustment Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StationaryAdjustmentIssue, Temp_NCat.StationaryAdjustmentIssue, Temp_NCat.StationaryAdjustmentIssue, "Stationary Stock Adjustment Issue", Temp_NCat.StationaryAdjustmentIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Book Purchase Indent V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookIndent, Temp_NCat.BookIndent, "Book Indent", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookIndent, Temp_NCat.BookIndent, Temp_NCat.BookIndent, "Book Indent", Temp_NCat.BookIndent, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Book Purchase Quotation V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookPurchaseQuotation, Temp_NCat.BookPurchaseQuotation, "Book Purchase Quotation", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookPurchaseQuotation, Temp_NCat.BookPurchaseQuotation, Temp_NCat.BookPurchaseQuotation, "Book Purchase Quotation", Temp_NCat.BookPurchaseQuotation, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Book Purchase Order V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookPurchaseOrder, Temp_NCat.BookPurchaseOrder, "Book Purchase Order", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookPurchaseOrder, Temp_NCat.BookPurchaseOrder, Temp_NCat.BookPurchaseOrder, "Book Purchase Order", Temp_NCat.BookPurchaseOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Book Goods Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookGoodsReceive, Temp_NCat.BookGoodsReceive, "Book Goods Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookGoodsReceive, Temp_NCat.BookGoodsReceive, Temp_NCat.BookGoodsReceive, "Book Goods Receive", Temp_NCat.BookGoodsReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Book Requisition Indent V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookRequisition, Temp_NCat.BookRequisition, "Book Requisition", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookRequisition, Temp_NCat.BookRequisition, Temp_NCat.BookRequisition, "Book Requisition", Temp_NCat.BookRequisition, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< New Book Requisition Indent V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.NewBookRequisition, Temp_NCat.NewBookRequisition, "New Book Requisition", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.NewBookRequisition, Temp_NCat.NewBookRequisition, Temp_NCat.NewBookRequisition, "New Book Requisition", Temp_NCat.NewBookRequisition, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Generals Subscription V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.Generalsubscription, Temp_NCat.Generalsubscription, "General Subscription", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.Generalsubscription, Temp_NCat.Generalsubscription, Temp_NCat.Generalsubscription, "General Subscription", Temp_NCat.Generalsubscription, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Stationary Purchase Order V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StationaryPurchaseOrder, Temp_NCat.StationaryPurchaseOrder, "Stationary Purchase Order", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StationaryPurchaseOrder, Temp_NCat.StationaryPurchaseOrder, Temp_NCat.StationaryPurchaseOrder, "Stationary Purchase Order", Temp_NCat.StationaryPurchaseOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)


            '===================================================<Good Receive New Book V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GRNewBooks, Temp_NCat.GRNewBooks, "New Book Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GRNewBooks, Temp_NCat.GRNewBooks, Temp_NCat.GRNewBooks, "New Book Receive", Temp_NCat.GRNewBooks, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Good Receive Old Book V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GROldBooks, Temp_NCat.GROldBooks, "Old Book Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GROldBooks, Temp_NCat.GROldBooks, Temp_NCat.GROldBooks, "Old Book Receive", Temp_NCat.GROldBooks, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Good Receive Donated Book V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GRDonatedBooks, Temp_NCat.GRDonatedBooks, "Donated Book Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GRDonatedBooks, Temp_NCat.GRDonatedBooks, Temp_NCat.GRDonatedBooks, "Donated Book Receive", Temp_NCat.GRDonatedBooks, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Good Receive Rare Book V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GRRareBooks, Temp_NCat.GRRareBooks, "Rare Book Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GRRareBooks, Temp_NCat.GRRareBooks, Temp_NCat.GRRareBooks, "Rare Book Receive", Temp_NCat.GRRareBooks, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Good Receive Stationary V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.GRStationary, Temp_NCat.GRStationary, "Stationary Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GRStationary, Temp_NCat.GRStationary, Temp_NCat.GRStationary, "Stationary Receive", Temp_NCat.GRStationary, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Book Invoice V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.InvoiceBooks, Temp_NCat.InvoiceBooks, "Book Invoice", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.InvoiceBooks, Temp_NCat.InvoiceBooks, Temp_NCat.InvoiceBooks, "Book Invoice", Temp_NCat.InvoiceBooks, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Stationary Invoice V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.InvoiceStationary, Temp_NCat.InvoiceStationary, "Stationary Invoice", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.InvoiceStationary, Temp_NCat.InvoiceStationary, Temp_NCat.InvoiceStationary, "Stationary Invoice", Temp_NCat.InvoiceStationary, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Donated Book Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.DonatedBookIssue, Temp_NCat.DonatedBookIssue, "Donated Book Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.DonatedBookIssue, Temp_NCat.DonatedBookIssue, Temp_NCat.DonatedBookIssue, "Donated Book Issue", Temp_NCat.DonatedBookIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Scrap Quotation V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.ScrapQuotation, Temp_NCat.ScrapQuotation, "Scrap Quotation", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.ScrapQuotation, Temp_NCat.ScrapQuotation, Temp_NCat.ScrapQuotation, "Scrap Quotation", Temp_NCat.ScrapQuotation, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Scrap Sale V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.ScrapSale, Temp_NCat.ScrapSale, "Scrap Sale", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.ScrapSale, Temp_NCat.ScrapSale, Temp_NCat.ScrapSale, "Scrap Sale", Temp_NCat.ScrapSale, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            ''===================================================<Generals & Periodical Recd V_Type >===================================================
            'AgL.CreateNCat(AgL.GCn, Temp_NCat.GeneralPeriodicalRecd, Temp_NCat.GeneralPeriodicalRecd, "Generals & Periodical Recd", AgL.PubSiteCode)
            'AgL.CreateVType(AgL.GCn, Temp_NCat.GeneralPeriodicalRecd, Temp_NCat.GeneralPeriodicalRecd, Temp_NCat.GeneralPeriodicalRecd, "Generals & Periodical Recd", Temp_NCat.GeneralPeriodicalRecd, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Book Issue Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookIssueReceive, Temp_NCat.BookIssueReceive, "Book Issue Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookIssueReceive, Temp_NCat.BookIssueReceive, Temp_NCat.BookIssueReceive, "Book Issue Receive", Temp_NCat.BookIssueReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Book Issue Receive To Binder V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BookIssueReceiveToBinder, Temp_NCat.BookIssueReceiveToBinder, "Book Issue Receive To Binder", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BookIssueReceiveToBinder, Temp_NCat.BookIssueReceiveToBinder, Temp_NCat.BookIssueReceiveToBinder, "Book Issue Receive To Binder", Temp_NCat.BookIssueReceiveToBinder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Bill Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.BillEntry, Temp_NCat.BillEntry, "Bill Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.BillEntry, Temp_NCat.BillEntry, Temp_NCat.BillEntry, "Bill Entry", Temp_NCat.BillEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Payment Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.Payment, Temp_NCat.Payment, "Payment", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.Payment, Temp_NCat.Payment, Temp_NCat.Payment, "Payment", Temp_NCat.Payment, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Scrap Sale Order>===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.ScrapSaleRequisition, Temp_NCat.ScrapSaleRequisition, "Scrap Sale Requisition", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.ScrapSaleRequisition, Temp_NCat.ScrapSaleRequisition, Temp_NCat.ScrapSaleRequisition, "Scrap Sale Requisition", Temp_NCat.ScrapSaleRequisition, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Stationary Quotation>===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StationaryQuotation, Temp_NCat.StationaryQuotation, "Stationary Quotation", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StationaryQuotation, Temp_NCat.StationaryQuotation, Temp_NCat.StationaryQuotation, "Stationary Quotation", Temp_NCat.StationaryQuotation, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Member Visit>===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.MemberVisit, Temp_NCat.MemberVisit, "Member Visit", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.MemberVisit, Temp_NCat.MemberVisit, Temp_NCat.MemberVisit, "Member Visit", Temp_NCat.MemberVisit, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_Unit()
        Dim mQry$
        Dim mTableName As String = "Unit"

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

    Private Sub TB_PurchaseEnviro()
        Dim mQry$

        'If AgL.Dman_Execute("Select Count(*) From PurchaseEnviro Where Site_Code = '" & AgL.PubSiteCode & "'", AgL.GCn).ExecuteScalar = 0 Then
        '    mQry = "INSERT INTO dbo.PurchaseEnviro(V_Type, Site_Code, ShowLastPoRates, ShowRecordCount) " & _
        '            " VALUES ('" & ClsMain.Temp_NCat.BookPurchaseOrder & "', '" & AgL.PubSiteCode & "', 1, 5)"
        '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

        '    mQry = "INSERT INTO dbo.PurchaseEnviro(V_Type, Site_Code, ShowLastPoRates, ShowRecordCount) " & _
        '            " VALUES ('" & ClsMain.Temp_NCat.StationaryPurchaseOrder & "', '" & AgL.PubSiteCode & "', 1, 5)"
        '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        'End If
    End Sub

    Private Sub TB_AcGroup()
        Dim mQry$
        Dim mTableName As String = "Unit"

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupCode = '0016'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                    " VALUES ('0016', NULL, 'Sundry Creditors', 'Sundry Creditors', NULL, 'L', 'Supplier', 'Y', 'SA', '2008-07-02', 'E', 'N', '030003', 160, 6, 17, '1', 'Sundry Creditors', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupCode = '0020'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                    " VALUES ('0020', NULL, 'Sundry Debtors', 'Sundry Debtors', NULL, 'A', 'Customer', 'Y', 'SA', '2008-07-07', 'E', 'N', '060004', 200, 6, 21, '1', 'Sundry Debtors', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub



    Private Sub TB_PostingGroupSalesTaxParty()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Local & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Local & "',1)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Central & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Central & "',1)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.LocalWithFormH & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.LocalWithFormH & "',1)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.CentralWithFormC & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.CentralWithFormC & "',1)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Export & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Export & "',1)"
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
        Try
            FLedger(MdlTable, "Ledger")
        Catch ex As Exception

        End Try

        FSeaPort(MdlTable, "SeaPort", EntryPointType.Main)
        FSeaPort(MdlTable, "SeaPort_Log", EntryPointType.Log)

        FLib_MemberType(MdlTable, "Lib_MemberType", EntryPointType.Main)
        FLib_MemberType(MdlTable, "Lib_MemberType_Log", EntryPointType.Log)

        FLib_ScrapCategory(MdlTable, "Lib_ScrapCategory", EntryPointType.Main)
        FLib_ScrapCategory(MdlTable, "Lib_ScrapCategory_Log", EntryPointType.Log)

        FLib_BookType(MdlTable, "Lib_BookType", EntryPointType.Main)
        FLib_BookType(MdlTable, "Lib_BookType_Log", EntryPointType.Log)

        FLib_BookTypeDetail(MdlTable, "Lib_BookTypeDetail", EntryPointType.Main)
        FLib_BookTypeDetail(MdlTable, "Lib_BookTypeDetail_Log", EntryPointType.Log)

        FLib_Subject(MdlTable, "Lib_Subject", EntryPointType.Main)
        FLib_Subject(MdlTable, "Lib_Subject_Log", EntryPointType.Log)

        FLib_SubjectDetail(MdlTable, "Lib_SubjectDetail", EntryPointType.Main)
        FLib_SubjectDetail(MdlTable, "Lib_SubjectDetail_Log", EntryPointType.Log)

        FLib_Book(MdlTable, "Lib_Book", EntryPointType.Main)
        FLib_Book(MdlTable, "Lib_Book_Log", EntryPointType.Log)

        FLib_Member(MdlTable, "Lib_Member", EntryPointType.Main)
        FLib_Member(MdlTable, "Lib_Member_Log", EntryPointType.Log)


        FLib_Generals(MdlTable, "Lib_Generals", EntryPointType.Main)
        FLib_Generals(MdlTable, "Lib_Generals_Log", EntryPointType.Log)

        FSubscription(MdlTable, "Lib_Subscription", EntryPointType.Main)
        FSubscription(MdlTable, "Lib_Subscription_Log", EntryPointType.Log)


        FLib_DonationApp(MdlTable, "Lib_DonationApp", EntryPointType.Main)
        FLib_DonationApp(MdlTable, "Lib_DonationApp_Log", EntryPointType.Log)

        FLib_DonationAppDetail(MdlTable, "Lib_DonationAppDetail", EntryPointType.Main)
        FLib_DonationAppDetail(MdlTable, "Lib_DonationAppDetail_Log", EntryPointType.Log)

        FLib_BookIssue(MdlTable, "Lib_BookIssue", EntryPointType.Main)
        FLib_BookIssue(MdlTable, "Lib_BookIssue_Log", EntryPointType.Log)

        FLib_BookIssueDetail(MdlTable, "Lib_BookIssueDetail", EntryPointType.Main)
        FLib_BookIssueDetail(MdlTable, "Lib_BookIssueDetail_Log", EntryPointType.Log)

        FLib_Accession(MdlTable, "Lib_Accession", EntryPointType.Main)
        FLib_Accession(MdlTable, "Lib_Accession_Log", EntryPointType.Log)

        FLib_AccessionHead(MdlTable, "Lib_AccessionHead", EntryPointType.Main)
        FLib_AccessionHead(MdlTable, "Lib_AccessionHead_Log", EntryPointType.Log)

        FLib_AccessionDetail(MdlTable, "Lib_AccessionDetail", EntryPointType.Main)
        FLib_AccessionDetail(MdlTable, "Lib_AccessionDetail_Log", EntryPointType.Log)

        FStock(MdlTable, "Stock", EntryPointType.Main)
        FStock(MdlTable, "Stock_Log", EntryPointType.Log)

        FStock(MdlTable, "StockProcess", EntryPointType.Main)
        FStock(MdlTable, "StockProcess_Log", EntryPointType.Log)

        FRequisitionDetail(MdlTable, "RequisitionDetail", EntryPointType.Main)
        FRequisitionDetail(MdlTable, "RequisitionDetail_Log", EntryPointType.Log)

        FPurchChallanDetail(MdlTable, "PurchChallanDetail", EntryPointType.Main)
        FPurchChallanDetail(MdlTable, "PurchChallanDetail_Log", EntryPointType.Log)

        FLib_SaleQuot(MdlTable, "Lib_SaleQuot", EntryPointType.Main)
        FLib_SaleQuot(MdlTable, "Lib_SaleQuot_Log", EntryPointType.Log)

        FLib_SaleQuotDetail(MdlTable, "Lib_SaleQuotDetail", EntryPointType.Main)
        FLib_SaleQuotDetail(MdlTable, "Lib_SaleQuotDetail_Log", EntryPointType.Log)

        FLib_Sale(MdlTable, "Lib_Sale", EntryPointType.Main)
        FLib_Sale(MdlTable, "Lib_Sale_Log", EntryPointType.Log)

        FLib_SaleDetail(MdlTable, "Lib_SaleDetail", EntryPointType.Main)
        FLib_SaleDetail(MdlTable, "Lib_SaleDetail_Log", EntryPointType.Log)

        FLib_SaleStockHead(MdlTable, "Lib_SaleStockHead", EntryPointType.Main)
        FLib_SaleStockHead(MdlTable, "Lib_SaleStockHead_Log", EntryPointType.Log)

        FLib_SaleStockOut(MdlTable, "Lib_SaleStockOut", EntryPointType.Main)
        FLib_SaleStockOut(MdlTable, "Lib_SaleStockOut_Log", EntryPointType.Log)

        FPay_Employee(MdlTable, "Pay_Employee", EntryPointType.Main)
        FPay_Employee(MdlTable, "Pay_Employee_Log", EntryPointType.Log)

        FBill(MdlTable, "Bill", EntryPointType.Main)
        FBill(MdlTable, "Bill_Log", EntryPointType.Log)

        FVendot(MdlTable, "Vendor", EntryPointType.Main)
        FVendot(MdlTable, "Vendor_Log", EntryPointType.Log)

        FPriority(MdlTable, "Priority")
        FLib_Enviro(MdlTable, "Lib_Enviro")

        FLib_ReceiptTypePrefix(MdlTable, "Lib_ReceiptTypePrefix")

        FStockHead(MdlTable, "StockHead", EntryPointType.Main)
        FStockHead(MdlTable, "StockHead_Log", EntryPointType.Log)

        FLib_ScrapSaleRequisition(MdlTable, "Lib_ScrapSaleRequisition", EntryPointType.Main)
        FLib_ScrapSaleRequisition(MdlTable, "Lib_ScrapSaleRequisition_Log", EntryPointType.Log)

        FLib_ScrapSaleRequisitionDetail(MdlTable, "Lib_ScrapSaleRequisitionDetail", EntryPointType.Main)
        FLib_ScrapSaleRequisitionDetail(MdlTable, "Lib_ScrapSaleRequisitionDetail_Log", EntryPointType.Log)
    End Sub

    Private Sub FLedger(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "V_SNo", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "LedgerM")
    End Sub

    Private Sub FBook(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Designation", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Department")
    End Sub

    Private Sub FLib_MemberType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "BooksAllowed", AgLibrary.ClsMain.SQLDataType.Int)
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

    Private Sub FLib_ScrapCategory(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, )
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

    Private Sub FLib_BookType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Suffix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
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

    Private Sub FLib_BookTypeDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "MemberType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Issuance", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Days", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "FinePerDay", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_BookType_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Lib_BookType")
        End If

        AgL.FSetFKeyValue(MdlTable, "MemberType", "Code", "Lib_MemberType")
    End Sub


    Private Sub FLib_Subject(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "UnderSubject", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "MsCode", AgLibrary.ClsMain.SQLDataType.VarCharMax)
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


        AgL.FSetFKeyValue(MdlTable, "UnderSubject", "Code", "Lib_Subject")
    End Sub

    Private Sub FLib_SubjectDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GodownSection", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_Subject_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Lib_Subject")
        End If

        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
    End Sub

    Private Sub FLib_Generals(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))

        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Language", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Recurrance", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Reminder", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "ScrapCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Item_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Item")
        End If

        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Lib_Subject")
        AgL.FSetFKeyValue(MdlTable, "ScrapCategory", "Code", "ScrapCategory")
    End Sub



    Private Sub FLib_Book(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))

        AgL.FSetColumnValue(MdlTable, "BookCodeValue", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "BookCodePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "BookCodeSuffix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "Writer", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Publisher", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Series", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Volume", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PlaceOfPub", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "PubYear", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Pages", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BookDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Language", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ISBN", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BookType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ScrapCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SearchKeyWords", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "WithCD", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "GodownCD", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GodownSectionCD", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "CD_ItemCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Item_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Item")
        End If

        AgL.FSetFKeyValue(MdlTable, "BookType", "Code", "Lib_BookType")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Lib_Subject")
        AgL.FSetFKeyValue(MdlTable, "GodownCD", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "ScrapCategory", "Code", "ScrapCategory")
        AgL.FSetFKeyValue(MdlTable, "CD_ItemCode", "Code", "Item")
    End Sub


    Private Sub FLib_Member(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Student", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Employee", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CardSrNo", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "MemberCardNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "MotherName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MemberType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "AdmissionNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Class", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ReminderRemark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "IssueLockFromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IssueLockTillDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IssueLockReason", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Subgroup_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        End If

        AgL.FSetFKeyValue(MdlTable, "MemberType", "Code", "Lib_MemberType")
        AgL.FSetFKeyValue(MdlTable, "Student", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "Employee", "SubCode", "Subgroup")
    End Sub

    Private Sub FPay_Employee(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "FirstName", AgLibrary.ClsMain.SQLDataType.nVarChar, 49)
        AgL.FSetColumnValue(MdlTable, "MiddleName", AgLibrary.ClsMain.SQLDataType.nVarChar, 24)
        AgL.FSetColumnValue(MdlTable, "LastName", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "DateOfJoin", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "DateOfResign", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "ResignRemark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Sex", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "BloodGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "Religion", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "IsTeachingStaff", AgLibrary.ClsMain.SQLDataType.Bit, 0)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt, 0)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "MotherName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Designation", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Shift", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "AppointmentType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalaryMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "PayScale", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "WorkExperience", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "TeachingExperience", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "ResearchExperience", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "IndustryExperience", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "BankAcNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BankName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankBranch", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "IfscCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TotalPGProjectsGuided", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalDoctorateProjectsGuided", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalBooksPublished", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "IsCommonSubjectTeacher", AgLibrary.ClsMain.SQLDataType.Bit, 0)
        AgL.FSetColumnValue(MdlTable, "IsCommonSubjectBeingTaught", AgLibrary.ClsMain.SQLDataType.Bit, 0)
        AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ProgrammeNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "TotalPapersPublishedInNationalJournals", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalPapersPublishedInInternationalJournals", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalInternationalConferencesAttended", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalNationalConferencesAttended", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalPapersInNationalConference", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalPapersInInternationalConference", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalShortTermCoursesAttended", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalWorkshopsAttended", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "TotalSeminarsAttended", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "CommonSubject", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Title", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Subgroup_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        End If
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



    Private Sub FPriority(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
    End Sub

    Private Sub FLib_Enviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True, False)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "MemberACGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "EmployeeACGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "DefaultBookType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, )
        AgL.FSetColumnValue(MdlTable, "DefaultLanguage", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, )
        AgL.FSetColumnValue(MdlTable, "DefaultUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, )
        AgL.FSetColumnValue(MdlTable, "PurchaseAC", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, )
        AgL.FSetColumnValue(MdlTable, "LastAccssionNo", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "IsLinkWithAcademic", AgLibrary.ClsMain.SQLDataType.Bit)

        AgL.FSetColumnValue(MdlTable, "ReturnReminderBefore", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "PurchaseAC", "SubCode", "SubGroup")

    End Sub

    Private Sub FLib_ReceiptTypePrefix(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True, False)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ReceiptType", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "AccessionNoPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "BookUidSufix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FSubscription(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "General", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ToDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Recurrance", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PaymentType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "Vendor")
        AgL.FSetFKeyValue(MdlTable, "General", "Code", "Generals")
    End Sub

    Private Sub FLib_DonationApp(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Member", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MonthlyIncome", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "AttestedByStaff", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Member", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "AttestedByStaff", "SubCode", "SubGroup")
    End Sub

    Private Sub FLib_DonationAppDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Book", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BookIssueDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_DonationApp_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_DonationApp")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
    End Sub

    Private Sub FLib_BookIssue(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Member", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "DonationApp", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "TransactionBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MemberRemarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "AccessionDocId", AgLibrary.ClsMain.SQLDataType.VarChar, 21)
        AgL.FSetColumnValue(MdlTable, "WriteOffDocId", AgLibrary.ClsMain.SQLDataType.VarChar, 21)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "DonationApp", "DocID", "Lib_DonationApp")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Member", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "TransactionBy", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "Subgroup")
    End Sub

    Private Sub FLib_BookIssueDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "AccessionNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Book_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Book", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "ForDays", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ToReturnDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReturnDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ReturnDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "FinePerDay", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FineAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.VarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "ReplacementBookId", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ReplacementAccessionNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ReplacementBook", AgLibrary.ClsMain.SQLDataType.VarChar, 10)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_BookIssue_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_BookIssue")
        End If
    End Sub

    Private Sub FRequisitionDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
    End Sub

    Private Sub FStock(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
    End Sub

    Private Sub FPurchChallanDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SysEdition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "AccessionQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AccessionDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
    End Sub

    Private Sub FLib_Replacement(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
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
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FLib_ReplacementDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ScrapCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_ScrapSaleOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_ScrapSaleOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "ScrapCategory", "Code", "ScrapCategory")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FLib_ScrapSaleRequisition(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
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
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FLib_ScrapSaleRequisitionDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ScrapCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_ScrapSaleOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_ScrapSaleOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "ScrapCategory", "Code", "ScrapCategory")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FLib_Accession(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ReceiptNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "TransactionBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "ReceiptNo", "DocID", "PurchChallan")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "TransactionBy", "SubCode", "SubGroup")
    End Sub

    Private Sub FLib_AccessionHead(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Book", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Writer", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Publisher", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Series", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Volume", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Language", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ISBN", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PublicationYear", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Pages", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MRP", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "WithCD", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GodownSection", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Place", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CallNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "ChallanDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_Accession_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_Accession")
        End If

        AgL.FSetFKeyValue(MdlTable, "Book", "Code", "Item")
    End Sub

    Private Sub FStockHead(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)
        AgL.FSetColumnValue(MdlTable, "ToSite_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
    End Sub


    Private Sub FLib_AccessionDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "AccessionNoPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "AccessionNo_Sr", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AccessionNoSufix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "AccessionNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BookIDPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "BookID_Sr", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BookIDSufix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)

        AgL.FSetColumnValue(MdlTable, "Book_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Book", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Writer", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Publisher", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Series", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Volume", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Language", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ISBN", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PublicationYear", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Pages", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MRP", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "WithCD", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GodownSection", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RefAccessionNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Place", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CallNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "IsInStock", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "WriteOff", AgLibrary.ClsMain.SQLDataType.Bit)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_Accession_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_Accession")
        End If

        AgL.FSetFKeyValue(MdlTable, "Book", "Code", "Item")
    End Sub

    Private Sub FLib_SaleQuot(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Buyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BuyerDocNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BuyerDocDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Buyer", "SubCode", "SubGroup")
    End Sub

    Private Sub FLib_SaleQuotDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ScrapCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_SaleQuot_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_SaleQuot")
        End If
        AgL.FSetFKeyValue(MdlTable, "ScrapCategory", "Code", "ScrapCategory")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FLib_Sale(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Quotation", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Buyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BuyerDocNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BuyerDocDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SaleRequisitionNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Buyer", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Quotation", "DocID", "Lib_Quotation")
    End Sub

    Private Sub FLib_SaleDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ScrapCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_Sale_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_Sale")
        End If
        AgL.FSetFKeyValue(MdlTable, "ScrapCategory", "Code", "ScrapCategory")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FLib_SaleStockHead(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Date_From", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Date_Upto", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Lib_Sale_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Lib_Sale")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub


    Private Sub FLib_SaleStockOut(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Book_ID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edition", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchChallan_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "PurchChallan")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FVendot(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
    End Sub

    Public Sub InitializeTables()
        TB_Unit()

        TB_Priority()

        TB_PostingGroupSalesTaxParty()

        TB_AcGroup()

        TB_PurchaseEnviro()

        TB_SMS_Event()

    End Sub
#End Region


    Private Sub TB_SMS_Event()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Dim bIntI% = 0
        Try
            If AgL.IsTableExist("SMS_Event", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.BookReturn_Reminder & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.BookReturn_Reminder & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Structure StructStock
        Dim DocID As String
        Dim Sr As String
        Dim V_Type As String
        Dim V_Prefix As String
        Dim V_Date As String
        Dim V_No As String
        Dim Div_Code As String
        Dim Site_Code As String
        Dim SubCode As String
        Dim Currency As String
        Dim SalesTaxGroupParty As String
        Dim Structure1 As String
        Dim BillingType As String
        Dim Item As String
        Dim ProcessGroup As String
        Dim Godown As String
        Dim Qty_Iss As Double
        Dim Qty_Rec As Double
        Dim Unit As String
        Dim MeasurePerPcs As Double
        Dim Measure_Iss As Double
        Dim Measure_Rec As Double
        Dim MeasureUnit As String
        Dim Rate As Double
        Dim Amount As Double
        Dim Addition As Double
        Dim Deduction As Double
        Dim NetAmount As Double
        Dim Remarks As String
        Dim Status As String
        Dim UID As String
        Dim Process As String
        Dim FIFORate As Double
        Dim FIFOAmt As Double
        Dim AVGRate As Double
        Dim AVGAmt As Double
        Dim Cost As Double
        Dim Doc_Qty As Double
        Dim ReferenceDocID As String
    End Structure

    Private Sub FBill(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)

        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IssuedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceivedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PendingQty", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OtherCharges", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Discount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "Vendor")
    End Sub

    Public Structure Dues
        Dim DocID As String
        Dim Sr As Integer
        Dim V_Type As String
        Dim V_Prefix As String
        Dim V_Date As String
        Dim V_No As Long
        Dim Div_Code As String
        Dim Site_Code As String
        Dim SubCode As String
        Dim Narration As String
        Dim ReferenceDocID As String
        Dim PaybleAmount As Double
        Dim ReceivableAmount As Double
        Dim AdjustedAmount As Double
        Dim EntryBy As String
        Dim EntryDate As String
        Dim EntryType As String
        Dim EntryStatus As String
        Dim ApproveBy As String
        Dim ApproveDate As String
        Dim MoveToLog As String
        Dim MoveToLogDate As String
        Dim IsDeleted As String
        Dim Status As String
        Dim UID As String
    End Structure

    Public Shared Sub ProcPostInDues(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, _
                              ByVal StructDue As ClsMain.Dues)
        Dim mQry$ = ""

        mQry = " Delete From Dues Where UID = '" & StructDue.UID & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "INSERT INTO Dues(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                    " Site_Code, SubCode, Narration, ReferenceDocID, PaybleAmount, ReceivableAmount, AdjustedAmount, " & _
                    " EntryBy, EntryDate, EntryType, EntryStatus, ApproveBy, " & _
                    " ApproveDate, MoveToLog, MoveToLogDate, IsDeleted, Status,	UID	) " & _
                    " VALUES(" & AgL.Chk_Text(StructDue.DocID) & ", " & Val(StructDue.Sr) & ", " & _
                    " " & AgL.Chk_Text(StructDue.V_Type) & " , " & _
                    " " & AgL.Chk_Text(StructDue.V_Prefix) & ", " & AgL.Chk_Text(StructDue.V_Date) & ", " & _
                    " " & Val(StructDue.V_No) & ", " & _
                    " " & AgL.Chk_Text(StructDue.Div_Code) & ", " & AgL.Chk_Text(StructDue.Site_Code) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.SubCode) & ", " & AgL.Chk_Text(StructDue.Narration) & ", " & _
                    " " & AgL.Chk_Text(StructDue.ReferenceDocID) & ",  " & _
                    " " & Val(StructDue.PaybleAmount) & ", " & _
                    " " & Val(StructDue.ReceivableAmount) & ", " & Val(StructDue.AdjustedAmount) & ", " & _
                    " " & AgL.Chk_Text(StructDue.EntryBy) & ", " & AgL.Chk_Text(StructDue.EntryDate) & ", " & _
                    " " & AgL.Chk_Text(StructDue.EntryType) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.EntryStatus) & ", " & AgL.Chk_Text(StructDue.ApproveBy) & ", " & _
                    " " & AgL.Chk_Text(StructDue.ApproveDate) & ", " & AgL.Chk_Text(StructDue.MoveToLog) & ", " & _
                    " " & AgL.Chk_Text(StructDue.MoveToLogDate) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.IsDeleted) & ", " & AgL.Chk_Text(StructDue.Status) & ", " & _
                    " " & AgL.Chk_Text(StructDue.UID) & ") "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub
End Class