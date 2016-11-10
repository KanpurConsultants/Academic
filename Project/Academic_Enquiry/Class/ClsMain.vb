Public Class ClsMain
    Public CFOpen As New ClsFunction

    Public Const ModuleName As String = "Enquiry"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        PObj = New Academic_Objects.ClsMain(AgL, PLib)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()

    End Sub
    Public Class PartyMasterType
        Public Const Cash As String = "Cash"
        Public Const Party As String = "Party"
        Public Const Supplier As String = "Supplier"
        Public Const Customer As String = "Customer"
        Public Const Transport As String = "Transport"
        Public Const Agent As String = "Agent"
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
    Public Shared Item_Nature1_Description = "Item Nature1"
    Public Shared Item_Nature2_Description = "Item Nature2"
    Public Shared Item_Batch_Description = "Batch No"
    Class Temp_NCat
        Public Const Enquiry As String = "ENQ"
        Public Const EnquiryFollowUp As String = "EFUP"
        Public Const ProspectusPurchase As String = "PPUR"
        Public Const ProspectusSale As String = "PSAL"
        Public Const ProspectusAdjustment As String = "PSTK"
    End Class

    Class Temp_Cat
        Public Const Enquiry As String = "ENQ"
        Public Const EnquiryFollowUp As String = "EFUP"
    End Class

    Class EnquiryMode
        Public Const Phone As String = "Phone"
        Public Const EMail As String = "E-Mail"
        Public Const SMS As String = "SMS"
        Public Const WalkingAtOffice As String = "Walking At Office"
    End Class

    Class EnquiryStatus
        Public Const NewEnquiry As String = "New"
        Public Const FollowUp As String = "Follow Up"
        Public Const Closed As String = "Closed"
    End Class
    Class Temp_Structure
        Public Const ProspectusPurchase As String = "PPUR"
    End Class
    Public Class ItemNature
        Public Const RawMaterial As String = "Raw Material"
        Public Const SemiFinished As String = "Semi Finished"
        Public Const Finished As String = "Finished"

        Public Const Consumable As String = "Consumable"
        Public Const NonConsumable As String = "Non Consumable"
    End Class
    Public Class ItemType
        Public Const Prospectus As String = "Prospectus"
    End Class

#Region " Structure Update Code "
    Public Sub UpdateTableStructure()
        Try
            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call CreateView()

            Call InitializeTables()

            Call InitializeStructure()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FSch_Experiment(MdlTable, "Sch_EnquiryMode")
        FEnquiry_Prospectus(MdlTable, "Enquiry_Prospectus")
        'FEnquiry_ProspectusStock(MdlTable, "Enquiry_ProspectusStock")
        FEnquiry_Enviro(MdlTable, "Enquiry_Enviro")

    End Sub
    Private Sub FSch_Experiment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
    End Sub

    Private Sub FEnquiry_Prospectus(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Suffix", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Sch_Session")
        AgL.FSetFKeyValue(MdlTable, "Programme", "Code", "Sch_Programme")
    End Sub

    'Private Sub FEnquiry_ProspectusStock(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
    '    AgL.FAddTable(MdlTable, StrTableName, ModuleName)

    '    AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
    '    AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
    '    AgL.FSetColumnValue(MdlTable, "PurchaseDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
    '    AgL.FSetColumnValue(MdlTable, "PurchaseUID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
    '    AgL.FSetColumnValue(MdlTable, "Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
    '    AgL.FSetColumnValue(MdlTable, "Suffix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
    '    AgL.FSetColumnValue(MdlTable, "ProspectusSR", AgLibrary.ClsMain.SQLDataType.BigInt, , , , 0)
    '    AgL.FSetColumnValue(MdlTable, "ProspectusNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
    '    AgL.FSetColumnValue(MdlTable, "IsInStock", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)

    '    AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
    '    AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

    '    AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Store_Item")
    '    AgL.FSetFKeyValue(MdlTable, "PurchaseDocId", "DocID", "Store_Purchase")
    '    AgL.FSetFKeyValue(MdlTable, "PurchaseUID", "Uid", "Store_PurchaseDetail")


    'End Sub
    Private Sub FEnquiry_Enviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True, False)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
       
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

#Region "Update Table Structure"
    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< Enquiry_Enquiry >===================================================
            AgL.AddNewField(AgL.GCn, "Enquiry_Enquiry", "AssignedTo", "nVarchar(10)")
            If AgL.IsFieldExist("AssignedTo", "Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Enquiry_Enquiry_AssignedTo", "SubGroup", "Enquiry_Enquiry", "SubCode", "AssignedTo")
            End If

            AgL.AddNewField(AgL.GCn, "Enquiry_Enquiry", "Session", "nVarchar(8)")
            If AgL.IsFieldExist("Session", "Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Enquiry_Enquiry_Session", "Sch_Session", "Enquiry_Enquiry", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Enquiry_Enquiry", "Programme", "nVarchar(8)")
            If AgL.IsFieldExist("Programme", "Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Enquiry_Enquiry_Programme", "Sch_Programme", "Enquiry_Enquiry", "Code", "Programme")
            End If


            AgL.AddNewField(AgL.GCn, "Enquiry_Enquiry", "Stream", "nVarchar(8)")
            If AgL.IsFieldExist("Stream", "Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Enquiry_Enquiry_Stream", "Sch_Stream", "Enquiry_Enquiry", "Code", "Stream")
            End If

            If AgL.AddNewField(AgL.GCn, "Enquiry_Enquiry", "Nationality", "nVarchar(50)") Then
                If AgL.IsFieldExist("NationalityCode", "Enquiry_Enquiry", AgL.GCn) Then
                    mQry = "UPDATE Enquiry_Enquiry SET Enquiry_Enquiry.Nationality = Nationality.Nationaliy " & _
                            " FROM Nationality " & _
                            " WHERE Enquiry_Enquiry.NationalityCode = Nationality.NationalityCode "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If
            End If

            mQry = "UPDATE Enquiry_Enquiry SET " & _
                    " Enquiry_Enquiry.Session = vE.Session, " & _
                    " Enquiry_Enquiry.Programme = vE.Programme " & _
                    " FROM  " & _
                    " ( " & _
                    " SELECT E.DocId, E.SessionProgramme, Sp.Programme, Sp.Session  " & _
                    " FROM Enquiry_Enquiry E " & _
                    " INNER JOIN Sch_SessionProgramme Sp ON Sp.Code = E.SessionProgramme   " & _
                    " WHERE E.SessionProgramme IS NOT NULL  " & _
                    " And (E.Session IS NULL Or E.Programme IS NULL)  " & _
                    " ) AS vE " & _
                    " WHERE Enquiry_Enquiry.DocId = vE.DocId "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            mQry = "UPDATE Enquiry_Enquiry SET " & _
                    " Enquiry_Enquiry.Stream = vE.Stream " & _
                    " FROM  " & _
                    " ( " & _
                    " SELECT E.DocId, E.SessionProgrammeStream, Sps.Stream  " & _
                    " FROM Enquiry_Enquiry E " & _
                    " INNER JOIN Sch_SessionProgrammeStream AS Sps ON Sps.Code = E.SessionProgrammeStream " & _
                    " WHERE E.SessionProgrammeStream IS NOT NULL  " & _
                    " AND E.Stream IS NULL  " & _
                    " ) AS vE " & _
                    " WHERE Enquiry_Enquiry.DocId = vE.DocId "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            AgL.AddNewField(AgL.GCn, "Enquiry_Enquiry", "ReferenceNo", "nVarChar(20)")

            ''============================< ************************* >=====================================


            ''============================< <Enquiry_FollowUp> >===================================================
            AgL.AddNewField(AgL.GCn, "Enquiry_FollowUp", "RemindBeforeDays", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Enquiry_FollowUp", "RemindAfterDays", "int", 0, False)
            ''============================< ************************* >=====================================

            ''============================< ***********Store_PurchaseDetail************** >=====================================
            AgL.AddNewField(AgL.GCn, "Store_PurchaseDetail", "Prefix", "nVarchar(5)")
            AgL.AddNewField(AgL.GCn, "Store_PurchaseDetail", "Suffix", "nVarchar(5)")

            AgL.AddNewField(AgL.GCn, "Store_PurchaseDetail", "StartSrNo", "int", 0)
            AgL.AddNewField(AgL.GCn, "Store_PurchaseDetail", "EndSrNo", "int", 0)

            AgL.AddNewField(AgL.GCn, "Store_PurchaseDetail", "Session", "nVarchar(8)")
            If AgL.IsFieldExist("Session", "Store_PurchaseDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_PurchaseDetail_Session", "Sch_Session", "Store_PurchaseDetail", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Store_PurchaseDetail", "Programme", "nVarchar(8)")
            If AgL.IsFieldExist("Program", "Store_PurchaseDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_PurchaseDetail_Programme", "Sch_Programme", "Store_PurchaseDetail", "Code", "Programme")
            End If

            ''============================< ***********Store_Sale************** >=====================================
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyName", "nVarchar(100)")
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyAdd1", "nVarchar(50)")
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyAdd2", "nVarchar(50)")
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyAdd3", "nVarchar(50)")
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyCityCode", "nVarChar(6)")
            If AgL.IsFieldExist("PartyCityCode", "Store_Sale", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_Sale_PartyCityCode", "City", "Store_Sale", "CityCode", "PartyCityCode")
            End If
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyPhone", "nVarChar(35)")
            AgL.AddNewField(AgL.GCn, "Store_Sale", "PartyMobile", "nVarChar(35)")

            AgL.AddNewField(AgL.GCn, "Store_Sale", "SaleAc", "nVarchar(10)")

            ''============================< ***********Store_SaleDetail************** >=====================================
            AgL.AddNewField(AgL.GCn, "Store_SaleDetail", "Session", "nVarchar(8)")
            If AgL.IsFieldExist("Session", "Store_SaleDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_SaleDetail_Session", "Sch_Session", "Store_SaleDetail", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Store_SaleDetail", "Programme", "nVarchar(8)")
            If AgL.IsFieldExist("Program", "Store_SaleDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_SaleDetail_Programme", "Sch_Programme", "Store_SaleDetail", "Code", "Programme")
            End If
            AgL.AddNewField(AgL.GCn, "Store_SaleDetail", "ProspectusNo", "nVarchar(20)")

           

            ''============================< ***********Store_Stock************** >=====================================
            AgL.AddNewField(AgL.GCn, "Store_Stock", "ProspectusNo", "nVarchar(20)")
            AgL.AddNewField(AgL.GCn, "Store_Stock", "Session", "nVarchar(8)")
            If AgL.IsFieldExist("Session", "Store_Stock", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_Stock_Session", "Sch_Session", "Store_Stock", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Store_Stock", "Programme", "nVarchar(8)")
            If AgL.IsFieldExist("Program", "Store_Stock", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Store_Stock_Programme", "Sch_Programme", "Store_Stock", "Code", "Programme")
            End If
          

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Dim mQry$ = "", bStrConstraintName$ = ""
        Try
            '<Executable Code>
            ''AgL.Dman_ExecuteNonQry("ALTER TABLE Enquiry_Enquiry DROP CONSTRAINT [IX_Sch_FeeDue1]", AgL.GCn)

            If AgL.IsFieldExist("NationalityCode", "Enquiry_Enquiry", AgL.GCn) Then
                AgL.DeleteForeignKey(AgL.GCn, "FK_Enquiry_Enquiry_City", "Enquiry_Enquiry")
                AgL.DeleteField("Enquiry_Enquiry", "NationalityCode", AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Dim mQry$ = ""
        Try
            '<Executable Code>            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewTable()
        Dim mQry As String = ""

        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            mQry = "CREATE TABLE dbo.Enquiry_Enquiry " & _
                    " ( " & _
                    " DocId                  NVARCHAR (21) NOT NULL, " & _
                    " Div_Code               NVARCHAR (1) NOT NULL, " & _
                    " Site_Code              NVARCHAR (2) NOT NULL, " & _
                    " V_Date                 SMALLDATETIME NOT NULL, " & _
                    " V_Type                 NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix               NVARCHAR (5) NOT NULL, " & _
                    " V_No                   BIGINT NOT NULL, " & _
                    " EnquiryMode            NVARCHAR (20) NULL, " & _
                    " Employee               NVARCHAR (10) NULL,  " & _
                    " SessionProgramme       NVARCHAR (8) NULL,  " & _
                    " SessionProgrammeStream NVARCHAR (8) NULL,  " & _
                    " FirstName              NVARCHAR (100) NOT NULL,  " & _
                    " MiddleName             NVARCHAR (100) NULL,  " & _
                    " LastName               NVARCHAR (100) NULL,  " & _
                    " Add1                   NVARCHAR (50) NULL,  " & _
                    " Add2                   NVARCHAR (50) NULL,  " & _
                    " Add3                   NVARCHAR (50) NULL,  " & _
                    " CityCode               NVARCHAR (6) NULL,  " & _
                    " PIN                    NVARCHAR (6) NULL,  " & _
                    " Phone                  NVARCHAR (35) NULL,  " & _
                    " Mobile                 NVARCHAR (35) NULL,  " & _
                    " EMail                  NVARCHAR (40) NULL,  " & _
                    " Sex                    NVARCHAR (6) NULL,  " & _
                    " DOB                    SMALLDATETIME NULL,  " & _
                    " NationalityCode        NVARCHAR (7) NULL,  " & _
                    " Religion               NVARCHAR (8) NULL,  " & _
                    " Category               NVARCHAR (8) NULL,  " & _
                    " FatherName             NVARCHAR (100) CONSTRAINT DF_Enquiry_Enquiry_FatherName DEFAULT ('') NULL,  " & _
                    " FatherNamePrefix       NVARCHAR (10) CONSTRAINT DF_Enquiry_Enquiry_FatherNamePrefix DEFAULT ('') NULL,  " & _
                    " MotherName             NVARCHAR (100) CONSTRAINT DF_Enquiry_Enquiry_MotherName DEFAULT ('') NULL,  " & _
                    " MotherNamePrefix       NVARCHAR (10) CONSTRAINT DF_Enquiry_Enquiry_MotherNamePrefix DEFAULT ('') NULL,  " & _
                    " FatherOccupation       NVARCHAR (8) NULL,  " & _
                    " MotherOccupation       NVARCHAR (8) NULL,  " & _
                    " FatherIncome           FLOAT CONSTRAINT DF_Enquiry_Enquiry_FamilyIncome1 DEFAULT ((0)) NOT NULL,  " & _
                    " MotherIncome           FLOAT CONSTRAINT DF_Enquiry_Enquiry_MotherIncome DEFAULT ((0)) NOT NULL,  " & _
                    " FamilyIncome           FLOAT CONSTRAINT DF_Enquiry_Enquiry_FamilyIncome DEFAULT ((0)) NOT NULL,  " & _
                    " Status                 NVARCHAR (20) NULL,  " & _
                    " IsClosed               BIT CONSTRAINT DF_Enquiry_Enquiry_IsClosed DEFAULT ((0)) NOT NULL,  " & _
                    " Remark                 NVARCHAR (255) CONSTRAINT DF_Enquiry_Enquiry_Remark DEFAULT ('') NULL,  " & _
                    " PreparedBy             NVARCHAR (10) NOT NULL,  " & _
                    " U_EntDt                DATETIME NOT NULL,  " & _
                    " U_AE                   NVARCHAR (1) NOT NULL,  " & _
                    " Edit_Date              DATETIME NULL,  " & _
                    " ModifiedBy             NVARCHAR (10) NULL,  " & _
                    " RowId                  BIGINT IDENTITY NOT NULL,  " & _
                    " UpLoadDate             SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Enquiry_Enquiry PRIMARY KEY (DocId),  " & _
                    " CONSTRAINT IX_Enquiry_Enquiry UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Division FOREIGN KEY (Div_Code) REFERENCES dbo.Division (Div_Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Sch_SessionProgramme FOREIGN KEY (SessionProgramme) REFERENCES dbo.Sch_SessionProgramme (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Sch_SessionProgrammeStream FOREIGN KEY (SessionProgrammeStream) REFERENCES dbo.Sch_SessionProgrammeStream (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_City FOREIGN KEY (NationalityCode) REFERENCES dbo.Nationality (NationalityCode),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Sch_Religion FOREIGN KEY (Religion) REFERENCES dbo.Sch_Religion (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Sch_Category FOREIGN KEY (Category) REFERENCES dbo.Sch_Category (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Sch_Occupation FOREIGN KEY (FatherOccupation) REFERENCES dbo.Sch_Occupation (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Sch_Occupation1 FOREIGN KEY (MotherOccupation) REFERENCES dbo.Sch_Occupation (Code),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix),  " & _
                    " CONSTRAINT FK_Enquiry_Enquiry_Pay_Employee FOREIGN KEY (Employee) REFERENCES dbo.Pay_Employee (SubCode) " & _
                    " ) "

            If Not AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Enquiry_Enquiry", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Enquiry_AcademicDetail " & _
                    " ( " & _
                    " DocId           NVARCHAR (21) NOT NULL, " & _
                    " Sr              INT NOT NULL, " & _
                    " Class           NVARCHAR (50) NOT NULL, " & _
                    " University      NVARCHAR (8) NULL, " & _
                    " EnrollmentNo    NVARCHAR (20) NULL, " & _
                    " YearOfPassing   SMALLINT NULL, " & _
                    " Subjects        NVARCHAR (255) NULL, " & _
                    " Result          NVARCHAR (20) NULL, " & _
                    " TotalPercentage FLOAT CONSTRAINT DF_Enquiry_Enquiry1_TotalPercentage DEFAULT ((0)) NOT NULL, " & _
                    " MeritPercentage FLOAT CONSTRAINT DF_Table_1_MarksObtained1 DEFAULT ((0)) NOT NULL, " & _
                    " Remark          NVARCHAR (255) CONSTRAINT DF_Enquiry_Enquiry1_Remark DEFAULT ('') NULL, " & _
                    " UpLoadDate      SMALLDATETIME NULL, " & _
                    " RowId           BIGINT IDENTITY NOT NULL, " & _
                    " CONSTRAINT PK_Enquiry_Enquiry1 PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT IX_Enquiry_Enquiry1 UNIQUE (DocId,Class), " & _
                    " CONSTRAINT FK_Enquiry_Enquiry1_Sch_University FOREIGN KEY (University) REFERENCES dbo.Sch_University (Code), " & _
                    " CONSTRAINT FK_Enquiry_Enquiry1_Enquiry_Enquiry FOREIGN KEY (DocId) REFERENCES dbo.Enquiry_Enquiry (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Enquiry_AcademicDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Enquiry_AcademicDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Enquiry_MeritMarks " & _
                    " ( " & _
                    " DocId      NVARCHAR (21) NOT NULL,  " & _
                    " ClassSr    INT NOT NULL,  " & _
                    " Sr         INT NOT NULL,  " & _
                    " Subject    NVARCHAR (100) CONSTRAINT DF_Enquiry_MeritMarks_Subject DEFAULT ('') NOT NULL,  " & _
                    " Marks      FLOAT CONSTRAINT DF_Enquiry_MeritMarks_Marks DEFAULT ((0)) NOT NULL,  " & _
                    " Percentage FLOAT CONSTRAINT DF_Enquiry_MeritMarks_Percentage DEFAULT ((0)) NOT NULL,  " & _
                    " CONSTRAINT PK_Enquiry_MeritMarks PRIMARY KEY (DocId,ClassSr,Sr), " & _
                    " CONSTRAINT IX_Enquiry_MeritMarks UNIQUE (DocId,ClassSr,Subject), " & _
                    " CONSTRAINT FK_Enquiry_MeritMarks_Enquiry_AcademicDetail FOREIGN KEY (DocId,ClassSr) REFERENCES dbo.Enquiry_AcademicDetail (DocId,Sr) " & _
                    " )"
            If Not AgL.IsTableExist("Enquiry_MeritMarks", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Enquiry_MeritMarks", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Enquiry_FollowUp " & _
                    " ( " & _
                    " DocId            NVARCHAR (21) NOT NULL, " & _
                    " Div_Code         NVARCHAR (1) NOT NULL, " & _
                    " Site_Code        NVARCHAR (2) NOT NULL, " & _
                    " V_Date           SMALLDATETIME NOT NULL, " & _
                    " V_Type           NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix         NVARCHAR (5) NOT NULL, " & _
                    " V_No             BIGINT NOT NULL, " & _
                    " Employee         NVARCHAR (10) NULL, " & _
                    " EnquiryDocId     NVARCHAR (21) NULL, " & _
                    " FollowupMode     NVARCHAR (20) NULL, " & _
                    " PersonMet        NVARCHAR (100) NULL, " & _
                    " Remark           NVARCHAR (255) CONSTRAINT DF_Enquiry_FollowUp_Remark DEFAULT ('') NULL, " & _
                    " NextFollowUpDate SMALLDATETIME NULL, " & _
                    " IsClosed         BIT CONSTRAINT DF_Enquiry_FollowUp_IsClosed DEFAULT ((0)) NOT NULL, " & _
                    " PreparedBy       NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt          DATETIME NOT NULL, " & _
                    " U_AE             NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date        DATETIME NULL, " & _
                    " ModifiedBy       NVARCHAR (10) NULL, " & _
                    " RowId            BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate       SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Enquiry_FollowUp PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Enquiry_FollowUp UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp_Division FOREIGN KEY (Div_Code) REFERENCES dbo.Division (Div_Code), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp_Pay_Employee FOREIGN KEY (Employee) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp_Enquiry_Enquiry FOREIGN KEY (EnquiryDocId) REFERENCES dbo.Enquiry_Enquiry (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Enquiry_FollowUp", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Enquiry_FollowUp", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Enquiry_FollowUp1 " & _
                    " ( " & _
                    " DocId      NVARCHAR (21) NOT NULL, " & _
                    " Sr         INT NOT NULL, " & _
                    " Remark     NVARCHAR (255) CONSTRAINT DF_Enquiry_FollowUp1_Remark DEFAULT ('') NULL, " & _
                    " UpLoadDate SMALLDATETIME NULL, " & _
                    " RowId      BIGINT IDENTITY NOT NULL, " & _
                    " CONSTRAINT PK_Enquiry_FollowUp1 PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT FK_Enquiry_FollowUp1_Enquiry_FollowUp FOREIGN KEY (DocId) REFERENCES dbo.Enquiry_FollowUp (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Enquiry_FollowUp1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Enquiry_FollowUp1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
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
            '===================================================< Enquiry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.Enquiry, ClsMain.Temp_Cat.Enquiry, "Enquiry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.Enquiry, ClsMain.Temp_Cat.Enquiry, ClsMain.Temp_NCat.Enquiry, "Enquiry", ClsMain.Temp_NCat.Enquiry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Enquiry FollowUp V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.EnquiryFollowUp, ClsMain.Temp_Cat.EnquiryFollowUp, "Enquiry Followup", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.EnquiryFollowUp, ClsMain.Temp_Cat.EnquiryFollowUp, ClsMain.Temp_NCat.EnquiryFollowUp, "Enquiry Followup", ClsMain.Temp_NCat.EnquiryFollowUp, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Prospectus Purchase V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.ProspectusPurchase, ClsMain.Temp_NCat.ProspectusPurchase, "Prospectus Purchase", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.ProspectusPurchase, ClsMain.Temp_NCat.ProspectusPurchase, ClsMain.Temp_NCat.ProspectusPurchase, "Prospectus Purchase", ClsMain.Temp_NCat.ProspectusPurchase, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Prospectus Sale V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.ProspectusSale, ClsMain.Temp_NCat.ProspectusSale, "Prospectus Sale", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.ProspectusSale, ClsMain.Temp_NCat.ProspectusSale, ClsMain.Temp_NCat.ProspectusSale, "Prospectus Sale", ClsMain.Temp_NCat.ProspectusSale, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Prospectus Stock Adjustment V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.ProspectusAdjustment, ClsMain.Temp_NCat.ProspectusAdjustment, "Prospectus Stock Adjustment", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.ProspectusAdjustment, ClsMain.Temp_NCat.ProspectusAdjustment, ClsMain.Temp_NCat.ProspectusAdjustment, "Prospectus Stock Adjustment", ClsMain.Temp_NCat.ProspectusAdjustment, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)



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

    Public Function FunCreateCity(ByVal StrCityName As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As String
        Dim bStrCode$ = "", mQry$ = ""
        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            SqlCmd = AgL.Dman_Execute("Select CityCode From City With (NoLock) Where CityName='" & StrCityName & "' ", AgL.GcnRead)
            bStrCode = AgL.XNull(SqlCmd.ExecuteScalar())

            If bStrCode.Trim = "" Then
                bStrCode = AgL.GetMaxId("City", "CityCode", AgL.GcnRead, AgL.PubDivCode, AgL.PubSiteCode, 4, True, True, , AgL.Gcn_ConnectionString)

                mQry = "Insert Into City (CityCode, CityName, U_EntDt, U_Name, U_AE) Values(" & _
                        " '" & bStrCode & "', '" & StrCityName & "', " & _
                        " '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)
            End If
        Catch ex As Exception
            bStrCode = ""
        Finally
            FunCreateCity = bStrCode
        End Try
    End Function
#End Region

    Public Function FunCreateEnquiryMode(ByVal StrEnquiryMode As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim mQry$ = ""
        Dim bBlnRetun As Boolean = False, bBlnCmdFlag As Boolean = False
        Dim mTrans As Boolean = False
        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = SqlConn.CreateCommand
                bBlnCmdFlag = False
            Else
                bBlnCmdFlag = True
            End If

            If StrEnquiryMode.Trim <> "" Then
                If Not bBlnCmdFlag Then
                    SqlCmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    SqlCmd.Transaction = AgL.ETrans

                    mTrans = True
                End If

                mQry = "If Not EXISTS(SELECT * FROM Sch_EnquiryMode WHERE Code = '" & StrEnquiryMode & "') " & _
                            " INSERT INTO dbo.Sch_EnquiryMode (Code) VALUES ('" & StrEnquiryMode & "')"
                AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

                If Not bBlnCmdFlag Then
                    AgL.ETrans.Commit()
                    mTrans = False
                End If

                bBlnRetun = True
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            bBlnRetun = False
            If Not bBlnCmdFlag Then
                If mTrans = True Then AgL.ETrans.Rollback()
            End If
        Finally
            FunCreateEnquiryMode = bBlnRetun
        End Try
    End Function
    Public Sub InitializeTables()
        TB_EnquiryMode()
        TB_ChargesType()
    End Sub
    Private Sub TB_ChargesType()
        Dim mQry As String = ""

        Try

            If AgL.IsTableExist("Charges", AgL.GCn) Then

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'GAMT') " & _
                            " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                            " VALUES ('GAMT', 'GAMT', 'GAMT','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'LAdd') " & _
                            " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                            " VALUES ('LAdd', 'LAdd', 'LAdd','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'LDed') " & _
                          " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                          " VALUES ('LDed', 'LDed', 'LDed','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'LNAmt') " & _
                        " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                        " VALUES ('LNAmt', 'LNAmt', 'LNAmt','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'HAdd') " & _
                        " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                        " VALUES ('HAdd', 'HAdd', 'HAdd','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'HDed') " & _
                       " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                       " VALUES ('HDed', 'HDed', 'HDed','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'NSTot') " & _
                     " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                     " VALUES ('NSTot', 'NSTot', 'NSTot','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'ROff') " & _
                   " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                   " VALUES ('ROff', 'ROff', 'ROff','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'NAMT') " & _
                  " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                  " VALUES ('NAMT', 'NAMT', 'NAMT','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TB_EnquiryMode()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Dim bIntI% = 0
        Try
            If AgL.IsTableExist("Sch_EnquiryMode", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM Sch_EnquiryMode WHERE Code = '" & EnquiryMode.Phone & "') " & _
                            " INSERT INTO dbo.Sch_EnquiryMode (Code) VALUES ('" & EnquiryMode.Phone & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.IsTableExist("Sch_EnquiryMode", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM Sch_EnquiryMode WHERE Code = '" & EnquiryMode.EMail & "') " & _
                            " INSERT INTO dbo.Sch_EnquiryMode (Code) VALUES ('" & EnquiryMode.EMail & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.IsTableExist("Sch_EnquiryMode", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM Sch_EnquiryMode WHERE Code = '" & EnquiryMode.SMS & "') " & _
                            " INSERT INTO dbo.Sch_EnquiryMode (Code) VALUES ('" & EnquiryMode.SMS & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.IsTableExist("Sch_EnquiryMode", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM Sch_EnquiryMode WHERE Code = '" & EnquiryMode.WalkingAtOffice & "') " & _
                            " INSERT INTO dbo.Sch_EnquiryMode (Code) VALUES ('" & EnquiryMode.WalkingAtOffice & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub InitializeStructure()
        Call ST_ProspectusPurchase()
    End Sub
    Private Sub ST_ProspectusPurchase()
        Dim mQry$ = "", bStrCode$ = Temp_Structure.ProspectusPurchase, bStrNCat$ = Temp_NCat.ProspectusPurchase
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

End Class