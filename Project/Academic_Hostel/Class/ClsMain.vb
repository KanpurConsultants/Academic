Public Class ClsMain    
    Public CFOpen As New ClsFunction

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        PObj = New Academic_Objects.ClsMain(AgL, PLib)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Public Class MemberType
        Public Const Student As String = "Student"
        Public Const Employee As String = "Employee"
    End Class


    Public Sub UpdateTableStructure()
        Try
            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateView()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< TableName >=====================================            
            'AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PCityCode", "nVarChar(6)")
            'If AgL.IsFieldExist("PCityCode", "Sch_RegistrationStudentDetail", AgL.GCn) Then
            '    AgL.AddForeignKey(AgL.GCn, "FK_Sch_RegistrationStudentDetail_PCityCode", "City", "Sch_RegistrationStudentDetail", "CityCode", "PCityCode")
            'End If
            ''============================< ************************* >=====================================


            ''============================< Ht_RoomAllotment >=====================================            
            AgL.AddNewField(AgL.GCn, "Ht_RoomAllotment", "SubCode", "nVarChar(10)")
            If AgL.IsFieldExist("SubCode", "Ht_RoomAllotment", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Ht_RoomAllotment_SubCode", "SubGroup", "Ht_RoomAllotment", "SubCode", "SubCode")

                mQry = "UPDATE Ht_RoomAllotment " & _
                        " SET Ht_RoomAllotment.SubCode = v.SubCode " & _
                        " FROM (SELECT T.AllotmentDocId, T.SubCode FROM Ht_RoomTransfer T WITH (NoLock) WHERE T.AllotmentType = '" & AllotmentType_Allotment & "') AS V " & _
                        " WHERE Ht_RoomAllotment.DocId = v.AllotmentDocId " & _
                        " AND IsNull(Ht_RoomAllotment.SubCode,'') <> IsNull(v.SubCode,'') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Ht_RoomAllotment", "MemberType", "nVarChar(20)")
            If AgL.IsFieldExist("SubCode", "Ht_RoomAllotment", AgL.GCn) _
                And AgL.IsFieldExist("MemberType", "Ht_RoomAllotment", AgL.GCn) Then

                mQry = "UPDATE Ht_RoomAllotment " & _
                        " SET Ht_RoomAllotment.MemberType = ViewHt_SubGroup.MemberType " & _
                        " FROM ViewHt_SubGroup " & _
                        " WHERE Ht_RoomAllotment.SubCode = ViewHt_SubGroup.SubCode "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If


            AgL.AddNewField(AgL.GCn, "Ht_RoomAllotment", "CurrentRoom", "nVarChar(10)")
            If AgL.IsFieldExist("CurrentRoom", "Ht_RoomAllotment", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Ht_RoomAllotment_CurrentRoom", "Ht_Room", "Ht_RoomAllotment", "Code", "CurrentRoom")

                Call FunUpdateCurrentRoom(AgL.GCn)
            End If

            ''============================< ************************* >=====================================

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

    Sub EditField()
        Try
            'AgL.EditField("Sch_Admission", "AdmissionID", "nVarChar(61)", AgL.GCn, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub AddNewTable()
        Dim mQry$ = "", mQry1$ = ""


        Try
            mQry = "CREATE TABLE dbo.Ht_Hostel " & _
                    " ( " & _
                    " Code          NVARCHAR (8) NOT NULL, " & _
                    " Description   NVARCHAR (50) NOT NULL, " & _
                    " ManualCode    NVARCHAR (20) NOT NULL, " & _
                    " ContactPerson NVARCHAR (100) NOT NULL, " & _
                    " Add1          NVARCHAR (50) NULL, " & _
                    " Add2          NVARCHAR (50) NULL, " & _
                    " Add3          NVARCHAR (50) NULL, " & _
                    " CityCode      NVARCHAR (6) NULL, " & _
                    " Pin           NVARCHAR (6) NULL, " & _
                    " Phone         NVARCHAR (35) NULL, " & _
                    " Mobile        NVARCHAR (35) NULL, " & _
                    " Fax           NVARCHAR (35) NULL, " & _
                    " Email         NVARCHAR (100) NULL, " & _
                    " Div_Code      NVARCHAR (1) NOT NULL, " & _
                    " Site_Code     NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy    NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt       DATETIME NOT NULL, " & _
                    " U_AE          NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date     DATETIME NULL, " & _
                    " ModifiedBy    NVARCHAR (50) NULL, " & _
                    " CONSTRAINT PK_Ht_Hostel PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_Hostel UNIQUE (Description), " & _
                    " CONSTRAINT IX_Ht_Hostel_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Ht_Hostel_City FOREIGN KEY (CityCode) REFERENCES dbo.City (CityCode), " & _
                    " CONSTRAINT FK_Ht_Hostel_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Ht_Hostel", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Hostel", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_Building " & _
                    " ( " & _
                    " Code          NVARCHAR (8) NOT NULL, " & _
                    " Description   NVARCHAR (50) NOT NULL, " & _
                    " ManualCode    NVARCHAR (20) NOT NULL, " & _
                    " Hostel        NVARCHAR (8) NOT NULL, " & _
                    " Nature        NVARCHAR (20) NOT NULL, " & _
                    " Location      NVARCHAR (100) NULL, " & _
                    " ContactPerson NVARCHAR (100) NOT NULL, " & _
                    " Phone         NVARCHAR (35) NULL, " & _
                    " Mobile        NVARCHAR (35) NULL, " & _
                    " Fax           NVARCHAR (35) NULL, " & _
                    " Email         NVARCHAR (100) NULL, " & _
                    " Div_Code      NVARCHAR (1) NOT NULL, " & _
                    " Site_Code     NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy    NVARCHAR (10) NOT NULL, " & _
                    " U_EntDate     DATETIME NOT NULL, " & _
                    " U_AE          NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date     DATETIME NULL, " & _
                    " ModifiedBy    NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_Building PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_Building UNIQUE (Description), " & _
                    " CONSTRAINT IX_Ht_Building_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Ht_Building_Ht_Hostel FOREIGN KEY (Hostel) REFERENCES dbo.Ht_Hostel (Code), " & _
                    " CONSTRAINT FK_Ht_Building_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " ) "
            If Not AgL.IsTableExist("Ht_Building", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Building", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_Floor " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (20) NOT NULL, " & _
                    " FloorNo     INT NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (50) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_Floor PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_Floor UNIQUE (Description), " & _
                    " CONSTRAINT IX_Ht_Floor_1 UNIQUE (FloorNo), " & _
                    " CONSTRAINT FK_Ht_Floor_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " ) "
            If Not AgL.IsTableExist("Ht_Floor", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Floor", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_BuildingFloor " & _
                    " ( " & _
                    " Code       NVARCHAR (10) NOT NULL, " & _
                    " Building   NVARCHAR (8) NOT NULL, " & _
                    " Floor      NVARCHAR (8) NOT NULL, " & _
                    " TotalRooms INT CONSTRAINT DF_Ht_BuildingFloor_TotalRooms DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_BuildingFloor PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_BuildingFloor UNIQUE (Building,Floor), " & _
                    " CONSTRAINT FK_Ht_BuildingFloor_Ht_Building FOREIGN KEY (Building) REFERENCES dbo.Ht_Building (Code), " & _
                    " CONSTRAINT FK_Ht_BuildingFloor_Ht_Floor FOREIGN KEY (Floor) REFERENCES dbo.Ht_Floor (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_BuildingFloor", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_BuildingFloor", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeGroup " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " ManualCode  NVARCHAR (20) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeGroup PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_ChargeGroup UNIQUE (Description), " & _
                    " CONSTRAINT IX_Ht_ChargeGroup_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Ht_ChargeGroup_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeGroup", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeGroup", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_Charge " & _
                    " ( " & _
                    " SubCode      NVARCHAR (10) NOT NULL, " & _
                    " ChargeGroup  NVARCHAR (8) NOT NULL, " & _
                    " ChargeNature NVARCHAR (20) NOT NULL, " & _
                    " Div_Code     NVARCHAR (1) NOT NULL, " & _
                    " Site_Code    NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy   NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt      DATETIME NOT NULL, " & _
                    " U_AE         NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date    DATETIME NULL, " & _
                    " ModifiedBy   NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_Charge PRIMARY KEY (SubCode), " & _
                    " CONSTRAINT FK_Ht_Charge_SubGroup FOREIGN KEY (SubCode) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_Ht_Charge_Ht_ChargeGroup FOREIGN KEY (ChargeGroup) REFERENCES dbo.Ht_ChargeGroup (Code), " & _
                    " CONSTRAINT FK_Ht_Charge_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_Charge", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Charge", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomType " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " ManualCode  NVARCHAR (20) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_RoomType PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_RoomType UNIQUE (Description), " & _
                    " CONSTRAINT IX_Ht_RoomType_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Ht_RoomType_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " ) "
            If Not AgL.IsTableExist("Ht_RoomType", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomType", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomType1 " & _
                    " ( " & _
                    " Code       NVARCHAR (8) NOT NULL, " & _
                    " Sr         INT NOT NULL, " & _
                    " Facilities NVARCHAR (100) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_RoomType1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_Ht_RoomType1 UNIQUE (Code,Facilities), " & _
                    " CONSTRAINT FK_Ht_RoomType1_Ht_RoomType FOREIGN KEY (Code) REFERENCES dbo.Ht_RoomType (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_RoomType1", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomType1", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomTypeCharge " & _
                    " ( " & _
                    " Code                NVARCHAR (8) NOT NULL, " & _
                    " Sr                  INT NOT NULL, " & _
                    " Charge              NVARCHAR (10) NOT NULL, " & _
                    " Amount              FLOAT CONSTRAINT DF_Ht_RoomTypeCharge_Amount DEFAULT ((0)) NOT NULL, " & _
                    " ChargeType          NVARCHAR (20) NOT NULL, " & _
                    " DueMonth            NVARCHAR (3) NOT NULL, " & _
                    " IsOnceInLife        BIT CONSTRAINT DF_Ht_RoomTypeCharge_IsOnceInLife DEFAULT ((0)) NOT NULL, " & _
                    " IsFirstTimeRequired BIT NOT NULL, " & _
                    " CONSTRAINT PK_Ht_RoomTypeCharge PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_Ht_RoomTypeCharge UNIQUE (Code,Charge), " & _
                    " CONSTRAINT FK_Ht_RoomTypeCharge_Ht_RoomType FOREIGN KEY (Code) REFERENCES dbo.Ht_RoomType (Code), " & _
                    " CONSTRAINT FK_Ht_RoomTypeCharge_Ht_Charge FOREIGN KEY (Charge) REFERENCES dbo.Ht_Charge (SubCode), " & _
                    " CONSTRAINT FK_Ht_RoomTypeCharge_Sch_FeeType FOREIGN KEY (ChargeType) REFERENCES dbo.Sch_FeeType (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_RoomTypeCharge", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomTypeCharge", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_Room " & _
                    " ( " & _
                    " Code              NVARCHAR (10) NOT NULL, " & _
                    " Description       NVARCHAR (20) NOT NULL, " & _
                    " RoomNoPrefix      NVARCHAR (15) NOT NULL, " & _
                    " RoomNoSuffix      INT NOT NULL, " & _
                    " BuildingFloor     NVARCHAR (10) NOT NULL, " & _
                    " RoomType          NVARCHAR (8) NOT NULL, " & _
                    " Location          NVARCHAR (100) NULL, " & _
                    " TotalBed          INT CONSTRAINT DF_Ht_Room_TotalBed DEFAULT ((0)) NOT NULL, " & _
                    " IsRoomAllocatable BIT CONSTRAINT DF_Ht_Room_IsRoomAllocatable DEFAULT ((1)) NOT NULL, " & _
                    " Div_Code          NVARCHAR (1) NOT NULL, " & _
                    " Site_Code         NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy        NVARCHAR (50) NOT NULL, " & _
                    " U_EntDt           DATETIME NOT NULL, " & _
                    " U_AE              NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date         DATETIME NULL, " & _
                    " ModifiedBy        NVARCHAR (10) NULL, " & _
                    " RowId             BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate        SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Ht_Room PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_Room UNIQUE (Description,BuildingFloor), " & _
                    " CONSTRAINT IX_Ht_Room_1 UNIQUE (RoomNoPrefix,RoomNoSuffix,BuildingFloor), " & _
                    " CONSTRAINT FK_Ht_Room_Ht_BuildingFloor FOREIGN KEY (BuildingFloor) REFERENCES dbo.Ht_BuildingFloor (Code), " & _
                    " CONSTRAINT FK_Ht_Room_Ht_RoomType FOREIGN KEY (RoomType) REFERENCES dbo.Ht_RoomType (Code), " & _
                    " CONSTRAINT FK_Ht_Room_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            mQry1 = "EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RoomNoPrefix + RoomNoSuffix' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Ht_Room', @level2type=N'COLUMN', @level2name=N'Description'	"

            If Not AgL.IsTableExist("Ht_Room", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                AgL.Dman_ExecuteNonQry(mQry1, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Room", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                    AgL.Dman_ExecuteNonQry(mQry1, AgL.GcnSite)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomAllotment " & _
                    " ( " & _
                    " DocId      NVARCHAR (21) NOT NULL, " & _
                    " Div_Code   NVARCHAR (1) NOT NULL, " & _
                    " Site_Code  NVARCHAR (2) NOT NULL, " & _
                    " V_Date     SMALLDATETIME NOT NULL, " & _
                    " V_Type     NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix   NVARCHAR (5) NOT NULL, " & _
                    " V_No       BIGINT NOT NULL, " & _
                    " Remark     NVARCHAR (255) NULL, " & _
                    " PreparedBy NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt    DATETIME NOT NULL, " & _
                    " U_AE       NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date  DATETIME NULL, " & _
                    " ModifiedBy NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_RoomAllotment PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Ht_RoomAllotment UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Ht_RoomAllotment_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Ht_RoomAllotment_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Ht_RoomAllotment_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_RoomAllotment", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomAllotment", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Ht_RoomTransfer " & _
                    " ( " & _
                    " Code            NVARCHAR (10) NOT NULL, " & _
                    " AllotmentDocId  NVARCHAR (21) NOT NULL, " & _
                    " SubCode         NVARCHAR (10) NOT NULL, " & _
                    " Room            NVARCHAR (10) NOT NULL, " & _
                    " AllotmentDate   SMALLDATETIME NOT NULL, " & _
                    " AllotmentType   NVARCHAR (20) NOT NULL, " & _
                    " TransferDate    SMALLDATETIME NULL, " & _
                    " TransferRemark  NVARCHAR (255) NULL, " & _
                    " ChargeStartDate SMALLDATETIME NOT NULL, " & _
                    " Div_Code        NVARCHAR (1) NOT NULL, " & _
                    " Site_Code       NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy      NVARCHAR (50) NOT NULL, " & _
                    " U_EntDt         DATETIME NOT NULL, " & _
                    " U_AE            NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date       DATETIME NULL, " & _
                    " ModifiedBy      NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_RoomTransfer PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_RoomTransfer UNIQUE (AllotmentDocId,AllotmentDate), " & _
                    " CONSTRAINT FK_Ht_RoomTransfer_Ht_RoomAllotment FOREIGN KEY (AllotmentDocId) REFERENCES dbo.Ht_RoomAllotment (DocId), " & _
                    " CONSTRAINT FK_Ht_RoomTransfer_SubGroup FOREIGN KEY (SubCode) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_Ht_RoomTransfer_Ht_Room FOREIGN KEY (Room) REFERENCES dbo.Ht_Room (Code), " & _
                    " CONSTRAINT FK_Ht_RoomTransfer_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_RoomTransfer", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomTransfer", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomTransferCharge " & _
                    " ( " & _
                    " RoomTransfer        NVARCHAR (10) NOT NULL, " & _
                    " Sr                  INT NOT NULL, " & _
                    " Charge              NVARCHAR (10) NOT NULL, " & _
                    " Amount              FLOAT CONSTRAINT DF_Ht_RoomTransferCharge_Amount DEFAULT ((0)) NOT NULL, " & _
                    " ChargeType          NVARCHAR (20) NOT NULL, " & _
                    " DueMonth            NVARCHAR (3) NOT NULL, " & _
                    " IsOnceInLife        BIT CONSTRAINT DF_Ht_RoomTransferCharge_IsOnceInLife DEFAULT ((0)) NOT NULL, " & _
                    " IsFirstTimeRequired BIT NOT NULL, " & _
                    " CONSTRAINT PK_Ht_RoomTransferCharge PRIMARY KEY (RoomTransfer,Sr), " & _
                    " CONSTRAINT IX_Ht_RoomTransferCharge UNIQUE (RoomTransfer,Charge), " & _
                    " CONSTRAINT FK_Ht_RoomTransferCharge_Ht_RoomTransfer FOREIGN KEY (RoomTransfer) REFERENCES dbo.Ht_RoomTransfer (Code), " & _
                    " CONSTRAINT FK_Ht_RoomTransferCharge_Ht_Charge FOREIGN KEY (Charge) REFERENCES dbo.Ht_Charge (SubCode), " & _
                    " CONSTRAINT FK_Ht_RoomTransferCharge_Sch_FeeType FOREIGN KEY (ChargeType) REFERENCES dbo.Sch_FeeType (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_RoomTransferCharge", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomTransferCharge", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomLeft " & _
                    " ( " & _
                    " AllotmentDocId NVARCHAR (21) NOT NULL, " & _
                    " Room           NVARCHAR (10) NOT NULL, " & _
                    " LeftDate       SMALLDATETIME NOT NULL, " & _
                    " LeftRemark     NVARCHAR (255) CONSTRAINT DF_Table_1_LeftRemark DEFAULT ('') NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy     NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        DATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date      DATETIME NULL, " & _
                    " ModifiedBy     NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_RoomLeft PRIMARY KEY (AllotmentDocId), " & _
                    " CONSTRAINT FK_Ht_RoomLeft_Ht_Room FOREIGN KEY (Room) REFERENCES dbo.Ht_Room (Code), " & _
                    " CONSTRAINT FK_Ht_RoomLeft_Ht_RoomAllotment FOREIGN KEY (AllotmentDocId) REFERENCES dbo.Ht_RoomAllotment (DocId), " & _
                    " CONSTRAINT FK_Ht_RoomLeft_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " ) "
            If Not AgL.IsTableExist("Ht_RoomLeft", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomLeft", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_Advance " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix       NVARCHAR (5) NOT NULL, " & _
                    " V_No           BIGINT NOT NULL, " & _
                    " AllotmentDocId NVARCHAR (21) NOT NULL, " & _
                    " ReceiveAmount  FLOAT CONSTRAINT DF_Ht_Advance_ReceiveAmount DEFAULT ((0)) NOT NULL, " & _
                    " Remark         NVARCHAR (255) CONSTRAINT DF_Ht_Advance_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy     NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        DATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date      DATETIME NULL, " & _
                    " ModifiedBy     NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_Advance PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Ht_Advance UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Ht_Advance_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Ht_Advance_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Ht_Advance_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Ht_Advance_Ht_RoomAllotment FOREIGN KEY (AllotmentDocId) REFERENCES dbo.Ht_RoomAllotment (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_Advance", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Advance", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_AdvanceOpeningLedgerM " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Ht_AdvanceOpeningLedgerM PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvanceOpeningLedgerM_Ht_Advance FOREIGN KEY (DocId) REFERENCES dbo.Ht_Advance (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvanceOpeningLedgerM_Ht_Advance1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Ht_Advance (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvanceOpeningLedgerM_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_AdvanceOpeningLedgerM", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_AdvanceOpeningLedgerM", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_AdvancePaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Ht_AdvancePaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvancePaymentDetail_Ht_Advance FOREIGN KEY (DocId) REFERENCES dbo.Ht_Advance (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvancePaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvancePaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Ht_AdvancePaymentDetail_Ht_Advance1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Ht_Advance (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_AdvancePaymentDetail", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_AdvancePaymentDetail", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeDue " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix       NVARCHAR (5) NOT NULL, " & _
                    " V_No           BIGINT NOT NULL, " & _
                    " MonthStartDate SMALLDATETIME NOT NULL, " & _
                    " TotalAmount    FLOAT NOT NULL, " & _
                    " Remark         NVARCHAR (255) CONSTRAINT DF_Ht_ChargeDue_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy     NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        DATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date      DATETIME NULL, " & _
                    " ModifiedBy     NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeDue PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Ht_ChargeDue UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Ht_ChargeDue_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Ht_ChargeDue_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Ht_ChargeDue_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeDue", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeDue", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeDue1 " & _
                    " ( " & _
                    " Code           NVARCHAR (10) NOT NULL, " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " AllotmentDocId NVARCHAR (21) NOT NULL, " & _
                    " Charge         NVARCHAR (10) NOT NULL, " & _
                    " Amount         FLOAT NOT NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeDue1 PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_ChargeDue1 UNIQUE (DocId,AllotmentDocId,Charge), " & _
                    " CONSTRAINT FK_Ht_ChargeDue1_Ht_ChargeDue FOREIGN KEY (DocId) REFERENCES dbo.Ht_ChargeDue (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeDue1_Ht_RoomAllotment FOREIGN KEY (AllotmentDocId) REFERENCES dbo.Ht_RoomAllotment (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeDue1_Ht_Charge FOREIGN KEY (Charge) REFERENCES dbo.Ht_Charge (SubCode) " & _
                    " ) "
            If Not AgL.IsTableExist("Ht_ChargeDue1", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeDue1", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeDueLedgerM " & _
                    " ( " & _
                    " DocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeDueLedgerM PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeDueLedgerM_Ht_ChargeDue FOREIGN KEY (DocId) REFERENCES dbo.Ht_ChargeDue (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeDueLedgerM_LedgerM FOREIGN KEY (DocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeDueLedgerM", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeDueLedgerM", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_RoomAllotmentChargeDue " & _
                    " ( " & _
                    " AllotmentDocId NVARCHAR (21) NOT NULL, " & _
                    " ChargeDueDocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_RoomAllotmentChargeDue PRIMARY KEY (AllotmentDocId,ChargeDueDocId), " & _
                    " CONSTRAINT FK_Ht_RoomAllotmentChargeDue_Ht_RoomAllotment FOREIGN KEY (AllotmentDocId) REFERENCES dbo.Ht_RoomAllotment (DocId), " & _
                    " CONSTRAINT FK_Ht_RoomAllotmentChargeDue_Ht_ChargeDue FOREIGN KEY (ChargeDueDocId) REFERENCES dbo.Ht_ChargeDue (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_RoomAllotmentChargeDue", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_RoomAllotmentChargeDue", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeReceive " & _
                    " ( " & _
                    " DocId                 NVARCHAR (21) NOT NULL, " & _
                    " Div_Code              NVARCHAR (1) NOT NULL, " & _
                    " Site_Code             NVARCHAR (2) NOT NULL, " & _
                    " V_Date                SMALLDATETIME NOT NULL, " & _
                    " V_Type                NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix              NVARCHAR (5) NOT NULL, " & _
                    " V_No                  BIGINT NOT NULL, " & _
                    " AllotmentDocId        NVARCHAR (21) NOT NULL, " & _
                    " TotalLineAmount       FLOAT CONSTRAINT DF_Ht_ChargeReceive_TotalLineAmount DEFAULT ((0)) NOT NULL, " & _
                    " TotalLineDiscount     FLOAT CONSTRAINT DF_Ht_ChargeReceive_TotalLineDiscount DEFAULT ((0)) NOT NULL, " & _
                    " TotalLineNetAmount    FLOAT NOT NULL, " & _
                    " AdvanceBroughtForward FLOAT CONSTRAINT DF_Table_2_Advance DEFAULT ((0)) NOT NULL, " & _
                    " TotalAdvanceAdjusted  FLOAT CONSTRAINT DF_Ht_ChargeReceive_TotalAdvanceAdjusted DEFAULT ((0)) NOT NULL, " & _
                    " SubTotal1             FLOAT CONSTRAINT DF_Ht_ChargeReceive_SubTotal1 DEFAULT ((0)) NOT NULL, " & _
                    " DiscountPer           FLOAT CONSTRAINT DF_Ht_ChargeReceive_DiscountPer DEFAULT ((0)) NOT NULL, " & _
                    " DiscountAmount        FLOAT CONSTRAINT DF_Ht_ChargeReceive_DiscountAmount DEFAULT ((0)) NOT NULL, " & _
                    " TotalNetAmount        FLOAT NOT NULL, " & _
                    " IsManageCharge        BIT CONSTRAINT DF_Table_2_IsManageFee DEFAULT ((0)) NOT NULL, " & _
                    " ReceiveAmount         FLOAT CONSTRAINT DF_Ht_ChargeReceive_ReceiveAmount DEFAULT ((0)) NOT NULL, " & _
                    " AdvanceCarriedForward FLOAT CONSTRAINT DF_Ht_ChargeReceive_AdvanceCarriedForward DEFAULT ((0)) NOT NULL, " & _
                    " Remark                NVARCHAR (255) CONSTRAINT DF_Ht_ChargeReceive_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy            NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt               DATETIME NOT NULL, " & _
                    " U_AE                  NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date             DATETIME NULL, " & _
                    " ModifiedBy            NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeReceive PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Ht_ChargeReceive UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Ht_ChargeReceive_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Ht_ChargeReceive_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Ht_ChargeReceive_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Ht_ChargeReceive_Ht_RoomAllotment FOREIGN KEY (AllotmentDocId) REFERENCES dbo.Ht_RoomAllotment (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeReceive", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeReceive", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeReceive1 " & _
                    " ( " & _
                    " Code       NVARCHAR (10) NOT NULL, " & _
                    " DocId      NVARCHAR (21) NOT NULL, " & _
                    " ChargeDue1 NVARCHAR (10) NOT NULL, " & _
                    " Amount     FLOAT CONSTRAINT DF_Ht_ChargeReceive1_Amount DEFAULT ((0)) NOT NULL, " & _
                    " Discount   FLOAT CONSTRAINT DF_Ht_ChargeReceive1_Discount DEFAULT ((0)) NOT NULL, " & _
                    " NetAmount  FLOAT CONSTRAINT DF_Ht_ChargeReceive1_NetAmount DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeReceive1 PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_ChargeReceive1 UNIQUE (DocId,ChargeDue1), " & _
                    " CONSTRAINT FK_Ht_ChargeReceive1_Ht_ChargeDue1 FOREIGN KEY (ChargeDue1) REFERENCES dbo.Ht_ChargeDue1 (Code), " & _
                    " CONSTRAINT FK_Ht_ChargeReceive1_Ht_ChargeReceive FOREIGN KEY (DocId) REFERENCES dbo.Ht_ChargeReceive (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeReceive1", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeReceive1", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeReceiveAdvance " & _
                    " ( " & _
                    " ChargeReceiveDocId NVARCHAR (21) NOT NULL, " & _
                    " Sr                 INT NOT NULL, " & _
                    " ChargeAdvanceDocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeReceiveAdvance PRIMARY KEY (ChargeReceiveDocId,Sr), " & _
                    " CONSTRAINT FK_Ht_ChargeReceiveAdvance_Ht_ChargeReceive FOREIGN KEY (ChargeReceiveDocId) REFERENCES dbo.Ht_ChargeReceive (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeReceiveAdvance_Ht_Advance FOREIGN KEY (ChargeAdvanceDocId) REFERENCES dbo.Ht_Advance (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeReceiveAdvance", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeReceiveAdvance", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeReceivePaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeReceivePaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeReceivePaymentDetail_Ht_ChargeReceive FOREIGN KEY (DocId) REFERENCES dbo.Ht_ChargeReceive (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeReceivePaymentDetail_Ht_ChargeReceive1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Ht_ChargeReceive (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeReceivePaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeReceivePaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeReceivePaymentDetail", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeReceivePaymentDetail", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeRefund " & _
                    " ( " & _
                    " DocId              NVARCHAR (21) NOT NULL, " & _
                    " Div_Code           NVARCHAR (1) NOT NULL, " & _
                    " Site_Code          NVARCHAR (2) NOT NULL, " & _
                    " V_Date             SMALLDATETIME NOT NULL, " & _
                    " V_Type             NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix           NVARCHAR (5) NOT NULL, " & _
                    " V_No               BIGINT NOT NULL, " & _
                    " ChargeReceiveDocId NVARCHAR (21) NOT NULL, " & _
                    " TotalLineAmount    FLOAT NOT NULL, " & _
                    " TotalLineNetAmount FLOAT NOT NULL, " & _
                    " IsManageCharge     BIT CONSTRAINT DF_Table_1_IsManageFee DEFAULT ((0)) NOT NULL, " & _
                    " RefundAmount       FLOAT CONSTRAINT DF_Ht_ChargeRefund_RefundAmount DEFAULT ((0)) NOT NULL, " & _
                    " ExcessRefund       FLOAT CONSTRAINT DF_Ht_ChargeRefund_ExcessRefund DEFAULT ((0)) NOT NULL, " & _
                    " Remark             NVARCHAR (255) CONSTRAINT DF_Ht_ChargeRefund_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt            DATETIME NOT NULL, " & _
                    " U_AE               NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date          DATETIME NULL, " & _
                    " ModifiedBy         NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeRefund PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Ht_ChargeRefund UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Ht_ChargeRefund_Ht_ChargeReceive FOREIGN KEY (ChargeReceiveDocId) REFERENCES dbo.Ht_ChargeReceive (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeRefund_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Ht_ChargeRefund_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Ht_ChargeRefund_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeRefund", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeRefund", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeRefund1 " & _
                    " ( " & _
                    " Code           NVARCHAR (10) NOT NULL, " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " ChargeReceive1 NVARCHAR (10) NOT NULL, " & _
                    " Amount         FLOAT CONSTRAINT DF_Ht_ChargeRefund1_Amount DEFAULT ((0)) NOT NULL, " & _
                    " NetAmount      FLOAT CONSTRAINT DF_Ht_ChargeRefund1_NetAmount DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeRefund1 PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Ht_ChargeRefund1 UNIQUE (DocId,ChargeReceive1), " & _
                    " CONSTRAINT FK_Ht_ChargeRefund1_Ht_ChargeRefund FOREIGN KEY (DocId) REFERENCES dbo.Ht_ChargeRefund (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeRefund1_Ht_ChargeReceive1 FOREIGN KEY (ChargeReceive1) REFERENCES dbo.Ht_ChargeReceive1 (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeRefund1", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeRefund1", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Ht_ChargeRefundPaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Ht_ChargeRefundPaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeRefundPaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeRefundPaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeRefundPaymentDetail_Ht_ChargeRefund1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Ht_ChargeRefund (DocId), " & _
                    " CONSTRAINT FK_Ht_ChargeRefundPaymentDetail_Ht_ChargeRefund FOREIGN KEY (DocId) REFERENCES dbo.Ht_ChargeRefund (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_ChargeRefundPaymentDetail", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_ChargeRefundPaymentDetail", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Ht_Enviro " & _
                    " ( " & _
                    " Site_Code  NVARCHAR (2) NOT NULL, " & _
                    " DiscountAc NVARCHAR (10) NULL, " & _
                    " Div_Code   NVARCHAR (1) NOT NULL, " & _
                    " PreparedBy NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt    DATETIME NOT NULL, " & _
                    " U_AE       NVARCHAR (1) NULL, " & _
                    " Edit_Date  DATETIME NULL, " & _
                    " ModifiedBy NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Ht_Enviro PRIMARY KEY (Site_Code), " & _
                    " CONSTRAINT FK_Ht_Enviro_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Ht_Enviro_SubGroup FOREIGN KEY (DiscountAc) REFERENCES dbo.SubGroup (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("Ht_Enviro", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Ht_Enviro", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            mQry = "Create View [dbo].[ViewHt_SubGroup] As " & _
                    " SELECT 'Student' AS MemberType, Sg.*, " & _
                    " St.BloodGroup,St.Religion,Sr.Description AS ReligionDesc, " & _
                    " St.Category,Sc.Description AS CategoryDesc " & _
                    " FROM Sch_Student St " & _
                    " LEFT JOIN SubGroup Sg ON St.SubCode = Sg.SubCode  " & _
                    " LEFT JOIN City ON Sg.CityCode = City.CityCode  " & _
                    " LEFT JOIN Sch_Religion Sr ON St.Religion=Sr.Code " & _
                    " LEFT JOIN Sch_Category Sc ON St.Category=Sc.Code " & _
                    " UNION ALL  " & _
                    " SELECT 'Employee' AS MemberType, Sg.*, Emp.BloodGroup, " & _
                    " Emp.Religion,Sr.Description AS ReligionDesc, " & _
                    " Emp.Category,Sc.Description AS CategoryDesc " & _
                    " FROM Pay_Employee Emp " & _
                    " LEFT JOIN SubGroup Sg ON Emp.SubCode = Sg.SubCode  " & _
                    " LEFT JOIN City ON Sg.CityCode = City.CityCode " & _
                    " LEFT JOIN Sch_Religion Sr ON Emp.Religion=Sr.Code " & _
                    " LEFT JOIN Sch_Category Sc ON Emp.Category=Sc.Code "

            AgL.IsViewExist("ViewHt_SubGroup", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_SubGroup", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW Dbo.ViewHt_BuildingFloor As " & _
                    " SELECT Bf.*, " & _
                    " B.Description AS BuildingDesc, B.ManualCode AS  BuildingManualCode, B.Nature AS BuildingNature, " & _
                    " F.Description AS FloorDesc, F.FloorNo , B.ManualCode + '/' + F.Description AS BuildingFloorDesc, " & _
                    " B.Hostel AS HostelCode, H.Description AS HostelDesc, H.ManualCode AS HostelManualCode, H.Site_Code, H.Div_Code  " & _
                    " FROM Ht_BuildingFloor Bf " & _
                    " LEFT JOIN Ht_Building B ON Bf.Building = B.Code  " & _
                    " LEFT JOIN Ht_Floor F ON Bf.Floor = F.Code  " & _
                    " LEFT JOIN Ht_Hostel H ON B.Hostel = H.Code "

            AgL.IsViewExist("ViewHt_BuildingFloor", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_BuildingFloor", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_Room AS " & _
                    " SELECT R.*, Bf.BuildingFloorDesc + '/' + R.Description AS BuildingFloorRoomDesc, " & _
                    " Bf.Building AS BuildingCode, Bf.Floor AS FloorCode, " & _
                    " Bf.BuildingDesc, Bf.BuildingManualCode, Bf.BuildingNature, Bf.FloorDesc,  " & _
                    " Bf.FloorNo, Bf.BuildingFloorDesc, Bf.HostelCode, Bf.HostelDesc, Bf.HostelManualCode, " & _
                    " RType.Description AS RoomTypeDesc, RType.ManualCode AS RoomTypeManualCode " & _
                    " FROM Ht_Room R " & _
                    " LEFT JOIN ViewHt_BuildingFloor Bf ON R.BuildingFloor = Bf.Code " & _
                    " LEFT JOIN Ht_RoomType RType ON R.RoomType = Rtype.Code "

            AgL.IsViewExist("ViewHt_Room", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_Room", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_Charge AS " & _
                    " SELECT C.*, Sg.Name AS ChargeName, Sg.ManualCode AS ChargeManualCode, Sg.DispName AS ChargeDispName, Sg.GroupCode AS ChargeAcGroupCode, " & _
                    " Cg.Description AS ChargeGroupDesc, Cg.ManualCode AS ChargeGroupManualCode " & _
                    " FROM Ht_Charge C " & _
                    " LEFT JOIN SubGroup Sg ON C.SubCode = Sg.SubCode " & _
                    " LEFT JOIN Ht_ChargeGroup Cg ON C.ChargeGroup = Cg.Code "

            AgL.IsViewExist("ViewHt_Charge", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_Charge", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_RoomAllotment As " & _
                    " SELECT A.*, T.SubCode AS MemberCode, T.Room AS RoomCode, T.TransferDate AS FirstTransferDate, T.TransferRemark AS FirstTransferRemark, T.AllotmentType, " & _
                    " L.LeftDate , L.LeftRemark , L.Room AS LeftRoomCode,  " & _
                    " Hsg.Name AS MemberName, Hsg.DispName AS MemberDispName, Hsg.ManualCode AS MemberManualCode,  " & _
                    " Hsg.FatherName, hsg.Phone , Hsg.Mobile , Hsg.FAX , Hsg.EMail , " & _
                    " Hsg.Add1 , Hsg.Add2, Hsg.Add3, Hsg.PIN, City.CityName , state.State_Desc , state.ShortName AS StateShortName, Country.Name AS Country  " & _
                    " FROM Ht_RoomAllotment A " & _
                    " LEFT JOIN Ht_RoomTransfer T ON A.DocId = T.AllotmentDocId AND T.AllotmentType = '" & AllotmentType_Allotment & "' " & _
                    " LEFT JOIN Ht_RoomLeft L ON A.DocId = L.AllotmentDocId  " & _
                    " LEFT JOIN ViewHt_SubGroup Hsg ON T.SubCode = Hsg.SubCode  " & _
                    " LEFT JOIN City ON Hsg.CityCode = City.CityCode  " & _
                    " LEFT JOIN State ON City.State_Code = State.State_Code " & _
                    " LEFT JOIN Country ON State.CountryCode = Country.Code "

            AgL.IsViewExist("ViewHt_RoomAllotment", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_RoomAllotment", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_RoomTransfer As " & _
                    " SELECT Rt.* , " & _
                    " CASE WHEN Rt.TransferDate IS NULL THEN Rl.LeftDate ELSE NULL END AS LeftDate,  " & _
                    " CASE WHEN Rt.TransferDate IS NULL THEN Rl.LeftRemark ELSE NULL END AS LeftRemark, " & _
                    " Hsg.Name AS MemberName, Hsg.DispName AS MemberDispName, Hsg.MemberType , Hsg.ManualCode AS MemberManualCode,  " & _
                    " Hsg.FatherName, hsg.Phone , Hsg.Mobile , Hsg.FAX , Hsg.EMail, " & _
                    " R.Description AS RoomDesc, R.BuildingFloor AS BuildingFloorCode, R.RoomType as RoomTypeCode, R.Location, R.TotalBed, " & _
                    " R.BuildingFloorRoomDesc, R.BuildingCode, R.FloorCode, R.BuildingDesc, R.BuildingManualCode, R.BuildingNature, " & _
                    " R.FloorDesc, R.FloorNo, R.BuildingFloorDesc, R.HostelCode, R.HostelDesc, R.HostelManualCode, R.RoomTypeDesc, R.RoomTypeManualCode, Hsg.SubCode AS MemberCode     " & _
                    " FROM Ht_RoomTransfer Rt  " & _
                    " LEFT JOIN ViewHt_Room R ON Rt.Room = R.Code   " & _
                    " LEFT JOIN ViewHt_SubGroup Hsg ON Rt.SubCode = Hsg.SubCode " & _
                    " LEFT JOIN Ht_RoomLeft Rl ON Rt.AllotmentDocId = Rl.AllotmentDocId  AND Rt.Room = Rl.Room "

            AgL.IsViewExist("ViewHt_RoomTransfer", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_RoomTransfer", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_ChargeDue AS " & _
                    " SELECT Cd.* , Cd1.Code AS ChargeDue1Code, Cd1.AllotmentDocId , Cd1.Charge AS ChargeCode, Cd1.Amount AS DueAmount ,  " & _
                    " C.ChargeName, C.ChargeManualCode, C.ChargeDispName " & _
                    " FROM Ht_ChargeDue Cd " & _
                    " LEFT JOIN Ht_ChargeDue1 Cd1 ON Cd.DocId = Cd1.DocId  " & _
                    " LEFT JOIN ViewHt_Charge C ON Cd1.Charge = C.SubCode "

            AgL.IsViewExist("ViewHt_ChargeDue", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_ChargeDue", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW ViewHt_ChargeReceive1 AS " & _
                    " SELECT CRec1.*,Cd1.Charge AS ChargeCode,IsNull(VCRef1.RefundAmount,0) AS  ChargeRefundAmount, " & _
                    " CRec1.NetAmount- IsNull(VCRef1.RefundAmount,0) AS ChargeReceiveLessRefundAmount, " & _
                    " CRec.Div_Code, CRec.Site_Code, CRec.V_Date, CRec.V_Type, CRec.V_Prefix, " & _
                    " CRec.V_No, CRec.AllotmentDocId,Vra.MemberCode,Vra.MemberName " & _
                    " FROM Ht_ChargeReceive1 CRec1 " & _
                    " LEFT JOIN  " & _
                    " 	(SELECT CRef1.ChargeReceive1,IsNull(Sum(CRef1.NetAmount),0) RefundAmount " & _
                    " 	FROM Ht_ChargeRefund1 CRef1 " & _
                    " 	GROUP BY CRef1.ChargeReceive1 ) VCRef1 ON CRec1.Code = VCRef1.ChargeReceive1 " & _
                    " LEFT JOIN Ht_ChargeReceive CRec ON CRec.DocId = CRec1.DocId " & _
                    " LEFT JOIN Ht_ChargeDue1 Cd1 ON CRec1.ChargeDue1=Cd1.Code " & _
                    " LEFT JOIN Ht_ChargeDue Cd ON Cd1.DocId = Cd.DocId " & _
                    " LEFT JOIN ViewHt_RoomAllotment Vra ON CRec.AllotmentDocId=Vra.DocId "

            AgL.IsViewExist("ViewHt_ChargeReceive1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_ChargeReceive1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_AdvanceReceive As " & _
                    " SELECT ARec.*, A.MemberCode, A.MemberName, " & _
                    " Cra.ChargeReceiveDocId, " & _
                    " Convert(BIT,CASE WHEN Cra.ChargeReceiveDocId IS NULL THEN 0 ELSE 1 END) AS IsAdjusted, " & _
                    " Vt.NCat, Vt.Description AS VoucherTypeDesc " & _
                    " FROM Ht_Advance ARec " & _
                    " LEFT JOIN Voucher_Type Vt ON ARec.V_Type = Vt.V_Type " & _
                    " LEFT JOIN Ht_ChargeReceiveAdvance Cra ON ARec.DocId = Cra.ChargeAdvanceDocId " & _
                    " LEFT JOIN ViewHt_RoomAllotment A ON ARec.AllotmentDocId = A.DocId " & _
                    " WHERE Vt.NCat In ('" & Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceReceive & "', '" & Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceOpening & "')"

            AgL.IsViewExist("ViewHt_AdvanceReceive", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_AdvanceReceive", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_ChargeRefund As " & _
                    " SELECT  Cref.*, Vt.NCat , Sm.Name AS Site_Name, Sm.ManualCode AS Site_ManualCode, D.Div_Name , " & _
                    " CRecv.AllotmentDocId, Ra.MemberCode , Ra.MemberName , Ra.MemberDispName , Ra.MemberManualCode , " & _
                    " Ra.MemberType , Ra.Phone , Ra.Mobile , Ra.FAX , Ra.EMail, Ra.Add1 , Ra.Add2 , Ra.Add3, Ra.CityName, Ra.PIN , " & _
                    " Ra.State_Desc , Ra.StateShortName , Ra.Country " & _
                    " FROM Ht_ChargeRefund CRef " & _
                    " LEFT JOIN Voucher_Type Vt ON CRef.V_Type = Vt.V_Type " & _
                    " LEFT JOIN SiteMast Sm ON CRef.Site_Code = Sm.Code  " & _
                    " LEFT JOIN Division D ON Cref.Div_Code = D.Div_Code  " & _
                    " LEFT JOIN Ht_ChargeReceive CRecv ON CRef.ChargeReceiveDocId = CRecv.DocId  " & _
                    " LEFT JOIN ViewHt_RoomAllotment Ra ON CRecv.AllotmentDocId = Ra.DocId  "

            AgL.IsViewExist("ViewHt_ChargeRefund", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_ChargeRefund", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_ChargeRefund1 As " & _
                    " SELECT CRef1.*,  CRef.Div_Code, CRef.Site_Code, CRef.V_Date, CRef.V_Type, CRef.V_Prefix, " & _
                    " CRef.V_No, CRef.AllotmentDocId, CRef.ChargeReceiveDocId, CRef.NCat, CRef.Site_Name, CRef.Site_ManualCode, " & _
                    " CRef.Div_Name, Cref.MemberCode, CRef.MemberName, CRef.MemberDispName, CRef.MemberManualCode,  " & _
                    " CRef.MemberType, CRef.Phone, CRef.Mobile, " & _
                    " CRef.FAX, CRef.EMail, CRef.Add1, CRef.Add2, CRef.Add3, CRef.CityName, CRef.PIN,  " & _
                    " CRef.State_Desc, CRef.StateShortName, CRef.Country " & _
                    " FROM ViewHt_ChargeRefund CRef " & _
                    " LEFT JOIN Ht_ChargeRefund1 CRef1 ON CRef.DocId = CRef1.DocId "

            AgL.IsViewExist("ViewHt_ChargeRefund1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_ChargeRefund1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewHt_RoomLeft AS " & _
                    " SELECT Rl.*, IsNull(vCd.DueAmount,0) - IsNull(vCr1.ReceiveAmount,0) + IsNull(vCref.RefundAmount,0) AS BalanceAsOnLeftDate " & _
                    " FROM Ht_RoomLeft Rl " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT Cd.AllotmentDocId, Sum(Cd.DueAmount) AS DueAmount " & _
                    " FROM ViewHt_ChargeDue Cd " & _
                    " INNER JOIN Ht_RoomLeft Rl1 ON Cd.AllotmentDocId = Rl1.AllotmentDocId AND Cd.V_Date <= Rl1.LeftDate " & _
                    " GROUP BY Cd.AllotmentDocId  " & _
                    " ) vCd ON Rl.AllotmentDocId = vCd.AllotmentDocId " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT Cr1.AllotmentDocId, Sum(Cr1.Amount) AS ReceiveAmount " & _
                    " FROM ViewHt_ChargeReceive1 Cr1 " & _
                    " INNER JOIN Ht_RoomLeft Rl1 ON Cr1.AllotmentDocId = Rl1.AllotmentDocId AND Cr1.V_Date <= Rl1.LeftDate " & _
                    " GROUP BY Cr1.AllotmentDocId  " & _
                    " ) vCr1 ON Rl.AllotmentDocId = vCr1.AllotmentDocId " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT CRef1.AllotmentDocId, Sum(CRef1.NetAmount) AS RefundAmount " & _
                    " FROM ViewHt_ChargeRefund1 CRef1 " & _
                    " INNER JOIN Ht_RoomLeft Rl1 ON CRef1.AllotmentDocId = Rl1.AllotmentDocId AND CRef1.V_Date <= Rl1.LeftDate " & _
                    " GROUP BY CRef1.AllotmentDocId  " & _
                    " ) vCRef ON Rl.AllotmentDocId = vCRef.AllotmentDocId "

            AgL.IsViewExist("ViewHt_RoomLeft", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewHt_RoomLeft", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CreateVType()
        Try
            '===================================================< Room Allotment V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomAllotment, Academic_ProjLib.ClsMain.Cat_RoomAllotment, "Room Allotment", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomAllotment, Academic_ProjLib.ClsMain.Cat_RoomAllotment, Academic_ProjLib.ClsMain.NCat_RoomAllotment, "Room Allotment", Academic_ProjLib.ClsMain.NCat_RoomAllotment, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ********************* >===================================================

            '===================================================< Room Charge Due V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeDue, Academic_ProjLib.ClsMain.Cat_RoomChargeDue, "Room Charge Due", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeDue, Academic_ProjLib.ClsMain.Cat_RoomChargeDue, Academic_ProjLib.ClsMain.NCat_RoomChargeDue, "Room Charge Due", Academic_ProjLib.ClsMain.NCat_RoomChargeDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue, Academic_ProjLib.ClsMain.Cat_RoomChargeDue, "Opening Room Charge Due", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue, Academic_ProjLib.ClsMain.Cat_RoomChargeDue, Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue, "Opening Room Charge Due", Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue, Academic_ProjLib.ClsMain.Cat_RoomChargeDue, "Room Charge Monthly Due", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue, Academic_ProjLib.ClsMain.Cat_RoomChargeDue, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue, "Room Charge Monthly Due", Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ********************* >===================================================

            '===================================================< Room Charge Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeReceive, Academic_ProjLib.ClsMain.Cat_RoomChargeReceive, "Room Charge Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeReceive, Academic_ProjLib.ClsMain.Cat_RoomChargeReceive, Academic_ProjLib.ClsMain.NCat_RoomChargeReceive, "Room Charge Receive", Academic_ProjLib.ClsMain.NCat_RoomChargeReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ********************* >===================================================

            '===================================================< Room Charge Refund V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeRefund, Academic_ProjLib.ClsMain.Cat_RoomChargeRefund, "Room Charge Refund", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeRefund, Academic_ProjLib.ClsMain.Cat_RoomChargeRefund, Academic_ProjLib.ClsMain.NCat_RoomChargeRefund, "Room Charge Refund", Academic_ProjLib.ClsMain.NCat_RoomChargeRefund, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ********************* >===================================================

            '===================================================< Advance Room Charge V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceReceive, Academic_ProjLib.ClsMain.Cat_RoomChargeAdvanceReceive, "Room Charge Advance Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceReceive, Academic_ProjLib.ClsMain.Cat_RoomChargeAdvanceReceive, Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceReceive, "Room Charge Advance Receive", Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceOpening, Academic_ProjLib.ClsMain.Cat_RoomChargeAdvanceReceive, "Opening Room Charge Advance", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceOpening, Academic_ProjLib.ClsMain.Cat_RoomChargeAdvanceReceive, Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceOpening, "Opening Room Charge Advance", Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ********************* >===================================================

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewVoucherReference()
        Try
            Dim VRefObj As New Academic_ProjLib.ClsMain.VRef_ReferenceTable

            'VRefObj.VRef_VehicleInsuranceClaimPayment()
            'AgL.AddNewVoucherReference(AgL.GCn, VRefObj.Code, VRefObj.Description, VRefObj.BoundField, VRefObj.DisplayField, VRefObj.IsDocId_DisplayField, VRefObj.HelpQuery, VRefObj.FilterField, VRefObj.SiteField, VRefObj.LastHiddenColumns)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Function FunUpdateCurrentRoom(ByVal StrAllotmentDocId As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            mQry = "UPDATE Ht_RoomAllotment " & _
                    " SET Ht_RoomAllotment.CurrentRoom = v.Room " & _
                    " FROM ( " & _
                    "       SELECT T.AllotmentDocId, T.Room FROM Ht_RoomTransfer T WITH (NoLock) " & _
                    "       WHERE 1=1 " & _
                    "       And T.AllotmentDocId = " & AgL.Chk_Text(StrAllotmentDocId) & " " & _
                    "       And T.TransferDate IS NULL " & _
                    "       ) AS V " & _
                    " WHERE 1=1 " & _
                    " And Ht_RoomAllotment.DocId = " & AgL.Chk_Text(StrAllotmentDocId) & " " & _
                    " And Ht_RoomAllotment.DocId = V.AllotmentDocId " & _
                    " And IsNull(Ht_RoomAllotment.CurrentRoom,'') <> IsNull(V.Room,'') "


            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentRoom = bBlnReturn
        End Try
    End Function

    Public Function FunUpdateCurrentRoom(ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            mQry = "UPDATE Ht_RoomAllotment " & _
                    " SET Ht_RoomAllotment.CurrentRoom = v.Room " & _
                    " FROM ( " & _
                    "       SELECT T.AllotmentDocId, T.Room FROM Ht_RoomTransfer T WITH (NoLock) " & _
                    "       WHERE 1=1 " & _
                    "       And T.TransferDate IS NULL " & _
                    "       ) AS V " & _
                    " WHERE 1=1 " & _
                    " And Ht_RoomAllotment.DocId = V.AllotmentDocId " & _
                    " And IsNull(Ht_RoomAllotment.CurrentRoom,'') <> IsNull(V.Room,'') "


            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentRoom = bBlnReturn
        End Try
    End Function
End Class