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

    Public Class RecordType
        Public Const InstallentCreate As String = "Installent Create"
    End Class

    Class SmsEvent
        Public Const FeeReceive As String = "Fee Receive"
    End Class

    Class FeeType
        Public Const Academic As String = "Academic"
        Public Const Hostel As String = "Hostel"
        Public Const Mess As String = "Mess"
        Public Const Library As String = "Library"
        Public Const Transport As String = "Transport"
    End Class


#Region "Update Table Structure"

    Public Sub UpdateTableStructure()
        Try
            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateView()

            Call InitializeTables()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub InitializeTables()
        TB_SMS_Event()
    End Sub

    Private Sub TB_SMS_Event()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Dim bIntI% = 0
        Try
            If AgL.IsTableExist("SMS_Event", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.FeeReceive & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.FeeReceive & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Dim bDtTemp1 As DataTable = Nothing, bDtTemp2 As DataTable = Nothing
        Dim bIntI% = 0, bIntJ% = 0
        Dim bDblRegistrationAmount As Double = 0, bDblBalanceAmt As Double = 0
        Try

            ''============================< Sch_Fee >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_Fee", "FeeType", "nVarChar(20)")
            ''============================< ************************* >=================================

            ''============================< Sch_Advance >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_Advance", "RefundAmount", "Float", 0, False)
            ''============================< ************************* >=====================================

            ''============================< Sch_FeeDue1 >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeDue1", "IsReversePostable", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_FeeDue1", "IsReversePosted", "bit", 0, False)
            ''============================< ************************* >=====================================

            ''============================< Sch_FeeReceive >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "ScholarShipAmount", "Float", 0, False)

            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "ScholarshipAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("ScholarshipAdjustmentAc", "Sch_FeeReceive", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceive_ScholarshipAdjustmentAc", "SubGroup", "Sch_FeeReceive", "SubCode", "ScholarshipAdjustmentAc")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "CounselingFeeAdjusted", "Float", 0, False)

            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "CounselingFeeAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("CounselingFeeAdjustmentAc", "Sch_FeeReceive", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceive_CounselingFeeAdjustmentAc", "SubGroup", "Sch_FeeReceive", "SubCode", "CounselingFeeAdjustmentAc")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_FeeRefund >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeRefund", "RegistrationAmountRefund", "Float", 0, False)
            If AgL.AddNewField(AgL.GCn, "Sch_FeeRefund", "TotalFeeRefund", "Float", 0, False) Then
                mQry = "Update Sch_FeeRefund " & _
                        " Set " & _
                        " TotalFeeRefund = TotalLineNetAmount " & _
                        " Where TotalFeeRefund = 0  " & _
                        " And IsNull(TotalLineNetAmount,0) <> 0 "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "Update Sch_FeeRefund " & _
                        " Set " & _
                        " TotalLineAmount = IsNull(TotalLineAmount,0) + ExcessRefund, " & _
                        " TotalLineNetAmount = IsNull(TotalLineNetAmount,0) + ExcessRefund " & _
                        " Where IsNull(ExcessRefund,0) > 0 "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Sch_FeeRefund", "AdmissionDocId", "nVarChar(21)")
            If AgL.IsFieldExist("AdmissionDocId", "Sch_FeeRefund", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeRefund_AdmissionDocId", "Sch_Admission", "Sch_FeeRefund", "DocId", "AdmissionDocId")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_FeeRefund1 >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeRefund1", "FeeReceiveDocId", "nVarChar(21)")

            If AgL.IsFieldExist("FeeReceiveDocId", "Sch_FeeRefund1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeRefund1_FeeReceiveDocId", "Sch_FeeReceive", "Sch_FeeRefund1", "DocId", "FeeReceiveDocId")

                mQry = "UPDATE Sch_FeeRefund1 " & _
                        " Set " & _
                        " Sch_FeeRefund1.FeeReceiveDocId = Sch_FeeReceive1.DocId " & _
                        " FROM Sch_FeeReceive1 " & _
                        " WHERE Sch_FeeRefund1.FeeReceive1 = Sch_FeeReceive1.Code " & _
                        " AND Sch_FeeRefund1.FeeReceiveDocId IS NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.AddNewField(AgL.GCn, "Sch_FeeRefund1", "ReturnHeadType", "nVarChar(50)") Then
                mQry = "Update Sch_FeeRefund1 " & _
                        " Set ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Fee & "' " & _
                        " Where ReturnHeadType Is Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.IsFieldExist("FeeReceiveDocId", "Sch_FeeRefund1", AgL.GCn) _
                And AgL.IsFieldExist("ReturnHeadType", "Sch_FeeRefund1", AgL.GCn) Then

                If AgL.IsConstraintExist("IX_Sch_FeeRefund1", "Sch_FeeRefund1", "DocId,FeeReceive1", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_FeeRefund1 DROP CONSTRAINT [IX_Sch_FeeRefund1]", AgL.GCn)
                End If

                AgL.AddUniqueKeyConstraint("IX_Sch_FeeRefund1", "Sch_FeeRefund1", "DocId,FeeReceiveDocId,FeeReceive1,ReturnHeadType", AgL.GCn)
            End If

            If AgL.AddNewField(AgL.GCn, "Sch_FeeRefund1", "RegistrationAmount", "float", 0) Then
                mQry = "SELECT FRef.*, vFRef1.RegistrationAmountLine " & _
                        " FROM Sch_FeeRefund FRef " & _
                        " INNER JOIN (SELECT FRef1.DocId, IsNull(Sum(FRef1.RegistrationAmount),0) RegistrationAmountLine FROM Sch_FeeRefund1 FRef1 WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Fee & "' GROUP BY FRef1.DocId) AS vFref1 ON vFRef1.DocId = FRef.DocId " & _
                        " WHERE IsNull(FRef.RegistrationAmountRefund,0) > 0 " & _
                        " AND IsNull(FRef.RegistrationAmountRefund,0) - IsNull(vFRef1.RegistrationAmountLine,0) <> 0 "
                bDtTemp1 = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtTemp1.Rows.Count > 0 Then
                    For bIntI = 0 To bDtTemp1.Rows.Count - 1
                        bDblBalanceAmt = AgL.VNull(bDtTemp1.Rows(bIntI)("RegistrationAmountRefund"))

                        mQry = "SELECT FRef1.* " & _
                                " FROM Sch_FeeRefund1 FRef1 WITH (NoLock) " & _
                                " WHERE FRef1.DocId = " & AgL.Chk_Text(bDtTemp1.Rows(bIntI)("DocId")) & " " & _
                                " And FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Fee & "'"
                        bDtTemp2 = AgL.FillData(mQry, AgL.GCn).Tables(0)
                        For bIntJ = 0 To bDtTemp2.Rows.Count - 1
                            If AgL.VNull(bDtTemp2.Rows(bIntJ)("NetAmount")) >= bDblBalanceAmt Then
                                bDblRegistrationAmount = bDblBalanceAmt
                            Else
                                bDblRegistrationAmount = AgL.VNull(bDtTemp2.Rows(bIntJ)("NetAmount"))
                            End If

                            mQry = "UPDATE Sch_FeeRefund1 " & _
                                    " SET RegistrationAmount = " & bDblRegistrationAmount & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(bDtTemp2.Rows(bIntJ)("Code")) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                            bDblBalanceAmt -= bDblRegistrationAmount
                            If bDblBalanceAmt <= 0 Then Exit For
                        Next

                    Next
                End If
            End If

            ''============================< ************************* >=====================================

            ''============================< Sch_ScholarShipReceive >============================================
            AgL.AddNewField(AgL.GCn, "Sch_ScholarShipReceive", "ScholarshipAc", "nVarChar(10)")
            If AgL.IsFieldExist("ScholarshipAc", "Sch_ScholarShipReceive", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_ScholarShipReceive_ScholarshipAc", "SubGroup", "Sch_ScholarShipReceive", "SubCode", "ScholarshipAc")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_ScholarShipParameter1 >============================================
            AgL.AddNewField(AgL.GCn, "Sch_ScholarShipParameter1", "Programme", "nVarChar(8)")
            If AgL.IsFieldExist("Programme", "Sch_ScholarShipParameter1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_ScholarShipParameter1_Programme", "Sch_Programme", "Sch_ScholarShipParameter1", "Code", "Programme")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_ScholarShipParameter1", "ProgrammeYear", "Int", 0, False)
            ''============================< ************************* >=====================================

            If AgL.IsFieldExist("Code", "Sch_ScholarShipParameter1", AgL.GCn) And _
                AgL.IsFieldExist("Category", "Sch_ScholarShipParameter1", AgL.GCn) And _
                AgL.IsFieldExist("Programme", "Sch_ScholarShipParameter1", AgL.GCn) And _
                AgL.IsFieldExist("ProgrammeYear", "Sch_ScholarShipParameter1", AgL.GCn) Then

                AgL.AddUniqueKeyConstraint("IX_Sch_ScholarShipParameter1_Code_Category_Programme_ProgrammeYear", "Sch_ScholarShipParameter1", "Code,Category,Programme,ProgrammeYear", AgL.GCn)
            End If
            ''============================< ************************* >=====================================

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If bDtTemp1 IsNot Nothing Then bDtTemp1.Dispose()
        End Try
    End Sub

    Sub DeleteField()
        Dim mQry$ = "", bStrConstraintName$ = ""
        Try
            '<Executable Code>
            If AgL.IsFieldExist("FeeReceiveDocId", "Sch_FeeRefund", AgL.GCn) _
                And AgL.IsFieldExist("AdmissionDocId", "Sch_FeeRefund", AgL.GCn) _
                And AgL.IsFieldExist("FeeReceiveDocId", "Sch_FeeRefund1", AgL.GCn) Then

                mQry = "SELECT IsNull(Count(*),0) As Cnt FROM Sch_FeeRefund WHERE AdmissionDocId IS NULL AND FeeReceiveDocId IS NOT NULL "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar = 0 Then
                    mQry = "SELECT IsNull(Count(*),0) As Cnt FROM Sch_FeeRefund1 WHERE FeeReceiveDocId IS NULL "
                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar = 0 Then
                        mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                                " FROM Sch_FeeRefund FRef " & _
                                " INNER JOIN " & _
                                " (SELECT FRef1.DocId, Sum(FRef1.NetAmount) AS ExcessRefund " & _
                                " FROM Sch_FeeRefund1 FRef1 " & _
                                " WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' " & _
                                " GROUP BY FRef1.DocId " & _
                                " ) vFref1 ON FRef.DocId = vFref1.DocId " & _
                                " WHERE FRef.FeeReceiveDocId IS NOT NULL AND FRef.ExcessRefund > 0 " & _
                                " AND IsNull(vFRef1.ExcessRefund,0) <> FRef.ExcessRefund "
                        If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar = 0 Then
                            mQry = "SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE C WHERE TABLE_NAME = 'Sch_FeeRefund' And COLUMN_NAME = 'FeeReceiveDocId'"
                            bStrConstraintName = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
                            AgL.DeleteForeignKey(AgL.GCn, bStrConstraintName, "Sch_FeeRefund")
                            AgL.DeleteField("Sch_FeeRefund", "FeeReceiveDocId", AgL.GCn)
                        End If
                    End If
                End If




            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Dim mQry$ = "", bStrFeeRefund1Code$ = ""
        Dim bDtTemp As DataTable = Nothing
        Dim bIntI As Integer = 0
        Try
            '<Executable Code>
            If AgL.IsFieldExist("AdmissionDocId", "Sch_FeeRefund", AgL.GCn) _
                And AgL.IsFieldExist("FeeReceiveDocId", "Sch_FeeRefund", AgL.GCn) Then
                mQry = "UPDATE Sch_FeeRefund  " & _
                        " SET  " & _
                        " Sch_FeeRefund.AdmissionDocId = Sch_FeeReceive.AdmissionDocId " & _
                        " FROM Sch_FeeReceive  " & _
                        " WHERE Sch_FeeRefund.FeeReceiveDocId = Sch_FeeReceive.DocId  " & _
                        " AND Sch_FeeRefund.AdmissionDocId IS NULL  " & _
                        " AND Sch_FeeRefund.FeeReceiveDocId IS NOT NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                If AgL.Dman_Execute("SELECT IsNull(Count(*),0) AS Cnt FROM Sch_FeeRefund FRef WHERE FRef.AdmissionDocId IS NULL", AgL.GCn).ExecuteScalar = 0 Then
                    AgL.EditField("Sch_FeeRefund", "AdmissionDocId", "nVarChar(21)", AgL.GCn, False)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try

            AgL.EditField("Sch_FeeRefund1", "FeeReceive1", "nVarChar(10)", AgL.GCn)
            If AgL.IsFieldExist("FeeReceiveDocId", "Sch_FeeRefund", AgL.GCn) Then
                AgL.EditField("Sch_FeeRefund", "FeeReceiveDocId", "nVarChar(21)", AgL.GCn)

                mQry = "SELECT FRef.Site_Code, FRef.Div_Code, FRef.DocId, FRef.ExcessRefund, FRef.FeeReceiveDocId " & _
                        " FROM Sch_FeeRefund FRef " & _
                        " WHERE FRef.ExcessRefund > 0 " & _
                        " And FRef.FeeReceiveDocId Is Not Null " & _
                        " And FRef.DocId Not In " & _
                        " (SELECT FRef1.DocId FROM Sch_FeeRefund1 FRef1 WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' AND FRef1.DocId = FRef.DocId)"
                bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtTemp.Rows.Count > 0 Then
                    For bIntI = 0 To bDtTemp.Rows.Count - 1
                        bStrFeeRefund1Code = AgL.GetMaxId("Sch_FeeRefund1", "Code", AgL.GcnRead, bDtTemp.Rows(bIntI)("Div_Code"), bDtTemp.Rows(bIntI)("Site_Code"), 8, True, True)

                        mQry = "INSERT INTO dbo.Sch_FeeRefund1 ( " & _
                                " Code, DocId, FeeReceive1, Amount, NetAmount, FeeReceiveDocId, ReturnHeadType) " & _
                                " VALUES (" & _
                                " " & AgL.Chk_Text(bStrFeeRefund1Code) & ", " & AgL.Chk_Text(bDtTemp.Rows(bIntI)("DocId")) & ", Null, " & _
                                " " & bDtTemp.Rows(bIntI)("ExcessRefund") & ", " & bDtTemp.Rows(bIntI)("ExcessRefund") & ", " & _
                                " " & AgL.Chk_Text(bDtTemp.Rows(bIntI)("FeeReceiveDocId")) & ", '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "')"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                    Next
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddNewTable()
        Dim mQry As String = ""

        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            mQry = "CREATE TABLE dbo.Sch_ReceiveDetail " & _
                        " ( " & _
                        " Guid          NVARCHAR (36) NOT NULL, " & _
                        " DocId         NVARCHAR (21) NOT NULL, " & _
                        " Fee           NVARCHAR (10) NOT NULL, " & _
                        " ReceiveAmount FLOAT CONSTRAINT DF_Sch_Advance1_ReceiveAmount DEFAULT ((0)) NOT NULL, " & _
                        " RefundAmount  FLOAT CONSTRAINT DF_Sch_Advance1_ReceiveAmount1 DEFAULT ((0)) NOT NULL, " & _
                        " Remark        NVARCHAR (255) NULL, " & _
                        " RowId         BIGINT IDENTITY NOT NULL, " & _
                        " UpLoadDate    SMALLDATETIME NULL, " & _
                        " ApprovedBy    NVARCHAR (10) NULL, " & _
                        " ApprovedDate  SMALLDATETIME NULL, " & _
                        " GPX1          NVARCHAR (255) NULL, " & _
                        " GPX2          NVARCHAR (255) NULL, " & _
                        " GPN1          FLOAT NULL, " & _
                        " GPN2          FLOAT NULL, " & _
                        " CONSTRAINT PK_Sch_Advance1 PRIMARY KEY (Guid), " & _
                        " CONSTRAINT IX_Sch_Advance1 UNIQUE (DocId,Fee), " & _
                        " CONSTRAINT FK_Sch_Advance1_Sch_Advance FOREIGN KEY (DocId) REFERENCES dbo.Sch_Advance (DocId), " & _
                        " CONSTRAINT FK_Sch_Advance1_Sch_Fee FOREIGN KEY (Fee) REFERENCES dbo.Sch_Fee (Code) " & _
                        " ) "

            If Not AgL.IsTableExist("Sch_ReceiveDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ReceiveDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ReverseFeeDue " & _
                    " ( " & _
                    " DocId                     NVARCHAR (21) NOT NULL, " & _
                    " Div_Code                  NVARCHAR (1) NOT NULL, " & _
                    " Site_Code                 NVARCHAR (2) NOT NULL, " & _
                    " V_Date                    SMALLDATETIME NOT NULL, " & _
                    " V_Type                    NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix                  NVARCHAR (5) NOT NULL, " & _
                    " V_No                      BIGINT NOT NULL, " & _
                    " AdmissionDocId            NVARCHAR (21) NOT NULL, " & _
                    " StreamYearSemester        NVARCHAR (10) NOT NULL, " & _
                    " TotalAmount               FLOAT NOT NULL, " & _
                    " Remark                    NVARCHAR (255) CONSTRAINT DF_Sch_ReverseFeeDue_Remark DEFAULT ('') NULL, " & _
                    " FeeReceiveAdjustmentDocId NVARCHAR (21) NULL, " & _
                    " PreparedBy                NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt                   DATETIME NOT NULL, " & _
                    " U_AE                      NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date                 DATETIME NULL, " & _
                    " ModifiedBy                NVARCHAR (10) NULL, " & _
                    " RowId                     BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate                SMALLDATETIME NULL, " & _
                    " ApprovedBy                NVARCHAR (10) NULL, " & _
                    " ApprovedDate              SMALLDATETIME NULL, " & _
                    " GPX1                      NVARCHAR (255) NULL, " & _
                    " GPX2                      NVARCHAR (255) NULL, " & _
                    " GPN1                      FLOAT NULL, " & _
                    " GPN2                      FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ReverseFeeDue PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_ReverseFeeDue UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue_Sch_FeeReceive FOREIGN KEY (FeeReceiveAdjustmentDocId) REFERENCES dbo.Sch_FeeReceive (DocId) " & _
                    " ) "

            If Not AgL.IsTableExist("Sch_ReverseFeeDue", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ReverseFeeDue", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ReverseFeeDue1 " & _
                    " ( " & _
                    " Guid         NVARCHAR (36) NOT NULL, " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " FeeDue1      NVARCHAR (10) NOT NULL, " & _
                    " Amount       FLOAT CONSTRAINT DF_Sch_ReverseFeeDue1_Amount DEFAULT ((0)) NOT NULL, " & _
                    " RowId        BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate   SMALLDATETIME NULL, " & _
                    " ApprovedBy   NVARCHAR (10) NULL, " & _
                    " ApprovedDate SMALLDATETIME NULL, " & _
                    " GPX1         NVARCHAR (255) NULL, " & _
                    " GPX2         NVARCHAR (255) NULL, " & _
                    " GPN1         FLOAT NULL, " & _
                    " GPN2         FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ReverseFeeDue1 PRIMARY KEY (Guid), " & _
                    " CONSTRAINT IX_Sch_ReverseFeeDue1 UNIQUE (DocId,FeeDue1), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue1_Sch_FeeDue1 FOREIGN KEY (FeeDue1) REFERENCES dbo.Sch_FeeDue1 (Code), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDue1_Sch_ReverseFeeDue FOREIGN KEY (DocId) REFERENCES dbo.Sch_ReverseFeeDue (DocId) " & _
                    " ) "

            If Not AgL.IsTableExist("Sch_ReverseFeeDue1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ReverseFeeDue1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ReverseFeeDueLedgerM " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " RowId        BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate   SMALLDATETIME NULL, " & _
                    " ApprovedBy   NVARCHAR (10) NULL, " & _
                    " ApprovedDate SMALLDATETIME NULL, " & _
                    " GPX1         NVARCHAR (255) NULL, " & _
                    " GPX2         NVARCHAR (255) NULL, " & _
                    " GPN1         FLOAT NULL, " & _
                    " GPN2         FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ReverseFeeDueLedgerM PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDueLedgerM_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDueLedgerM_Sch_ReverseFeeDue FOREIGN KEY (DocId) REFERENCES dbo.Sch_ReverseFeeDue (DocId), " & _
                    " CONSTRAINT FK_Sch_ReverseFeeDueLedgerM_Sch_ReverseFeeDue1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_ReverseFeeDue (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_ReverseFeeDueLedgerM", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ReverseFeeDueLedgerM", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipParameter " & _
                    " ( " & _
                    " Code           NVARCHAR (8) NOT NULL, " & _
                    " ModuleType     NVARCHAR (20) NOT NULL, " & _
                    " MasterType     NVARCHAR (20) NOT NULL, " & _
                    " ApplicableFrom SMALLDATETIME NOT NULL, " & _
                    " ApplicableUpto SMALLDATETIME NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy     NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        DATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date      DATETIME NULL, " & _
                    " ModifiedBy     NVARCHAR (10) NULL, " & _
                    " RowId          BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate     SMALLDATETIME NULL, " & _
                    " ApprovedBy     NVARCHAR (10) NULL, " & _
                    " ApprovedDate   SMALLDATETIME NULL, " & _
                    " GPX1           NVARCHAR (255) NULL, " & _
                    " GPX2           NVARCHAR (255) NULL, " & _
                    " GPN1           FLOAT NULL, " & _
                    " GPN2           FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipParameter PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_ScholarShipParameter UNIQUE (ModuleType,MasterType,ApplicableFrom), " & _
                    " CONSTRAINT FK_Sch_ScholarShipParameter_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_ScholarShipParameter", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipParameter", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipParameter " & _
                    " ( " & _
                    " Code           NVARCHAR (8) NOT NULL, " & _
                    " ModuleType     NVARCHAR (20) NOT NULL, " & _
                    " MasterType     NVARCHAR (20) NOT NULL, " & _
                    " ApplicableFrom SMALLDATETIME NOT NULL, " & _
                    " ApplicableUpto SMALLDATETIME NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy     NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        DATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date      DATETIME NULL, " & _
                    " ModifiedBy     NVARCHAR (10) NULL, " & _
                    " RowId          BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate     SMALLDATETIME NULL, " & _
                    " ApprovedBy     NVARCHAR (10) NULL, " & _
                    " ApprovedDate   SMALLDATETIME NULL, " & _
                    " GPX1           NVARCHAR (255) NULL, " & _
                    " GPX2           NVARCHAR (255) NULL, " & _
                    " GPN1           FLOAT NULL, " & _
                    " GPN2           FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipParameter PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_ScholarShipParameter UNIQUE (ModuleType,MasterType,ApplicableFrom), " & _
                    " CONSTRAINT FK_Sch_ScholarShipParameter_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_ScholarShipParameter", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipParameter", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipParameter1 " & _
                    " ( " & _
                    " Guid         NVARCHAR (36) NOT NULL, " & _
                    " Code         NVARCHAR (8) NOT NULL, " & _
                    " Sr           INT NOT NULL, " & _
                    " Category     NVARCHAR (8) NOT NULL, " & _
                    " FamilyIncome FLOAT CONSTRAINT DF_Sch_ScholarShipParameter1_Amount1 DEFAULT ((0)) NOT NULL, " & _
                    " ScholarShip  FLOAT CONSTRAINT DF_Sch_ScholarShipParameter1_Amount DEFAULT ((0)) NOT NULL, " & _
                    " RowId        BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate   SMALLDATETIME NULL, " & _
                    " ApprovedBy   NVARCHAR (10) NULL, " & _
                    " ApprovedDate SMALLDATETIME NULL, " & _
                    " GPX1         NVARCHAR (255) NULL, " & _
                    " GPX2         NVARCHAR (255) NULL, " & _
                    " GPN1         FLOAT NULL, " & _
                    " GPN2         FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipParameter1 PRIMARY KEY (Guid), " & _
                    " CONSTRAINT IX_Sch_ScholarShipParameter1_1 UNIQUE (Code,Sr), " & _
                    " CONSTRAINT FK_Sch_ScholarShipParameter1_Sch_Category FOREIGN KEY (Category) REFERENCES dbo.Sch_Category (Code), " & _
                    " CONSTRAINT FK_Sch_ScholarShipParameter1_Sch_ScholarShipParameter FOREIGN KEY (Code) REFERENCES dbo.Sch_ScholarShipParameter (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_ScholarShipParameter1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipParameter1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try

            mQry = "CREATE TABLE dbo.Sch_ScholarShipParameter2 " & _
            " ( " & _
            " Parameter1Guid NVARCHAR (36) NOT NULL, " & _
            " Sr             INT NOT NULL, " & _
            " Code           NVARCHAR (8) NOT NULL, " & _
            " Fee            NVARCHAR (10) NOT NULL, " & _
            " ScholarShip    FLOAT CONSTRAINT DF_Sch_ScholarShipParameter2_ScholarShip DEFAULT ((0)) NOT NULL, " & _
            " RowId          BIGINT IDENTITY NOT NULL, " & _
            " UpLoadDate     SMALLDATETIME NULL, " & _
            " ApprovedBy     NVARCHAR (10) NULL, " & _
            " ApprovedDate   SMALLDATETIME NULL, " & _
            " GPX1           NVARCHAR (255) NULL, " & _
            " GPX2           NVARCHAR (255) NULL, " & _
            " GPN1           FLOAT NULL, " & _
            " GPN2           FLOAT NULL, " & _
            " CONSTRAINT PK_Sch_ScholarShipParameter2 PRIMARY KEY (Parameter1Guid,Sr), " & _
            " CONSTRAINT IX_Sch_ScholarShipParameter2 UNIQUE (Parameter1Guid,Fee), " & _
            " CONSTRAINT FK_Sch_ScholarShipParameter2_Sch_Fee FOREIGN KEY (Fee) REFERENCES dbo.Sch_Fee (Code), " & _
            " CONSTRAINT FK_Sch_ScholarShipParameter2_Sch_ScholarShipParameter FOREIGN KEY (Code) REFERENCES dbo.Sch_ScholarShipParameter (Code), " & _
            " CONSTRAINT FK_Sch_ScholarShipParameter2_Sch_ScholarShipParameter1 FOREIGN KEY (Parameter1Guid) REFERENCES dbo.Sch_ScholarShipParameter1 (Guid) " & _
            " ) "

            If Not AgL.IsTableExist("Sch_ScholarShipParameter2", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipParameter2", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipDemand " & _
                    " ( " & _
                    " DocId             NVARCHAR (21) NOT NULL, " & _
                    " Div_Code          NVARCHAR (1) NOT NULL, " & _
                    " Site_Code         NVARCHAR (2) NOT NULL, " & _
                    " V_Date            SMALLDATETIME NOT NULL, " & _
                    " V_Type            NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix          NVARCHAR (5) NOT NULL, " & _
                    " V_No              BIGINT NOT NULL, " & _
                    " Category          NVARCHAR (8) NOT NULL, " & _
                    " Programme         NVARCHAR (8) NOT NULL, " & _
                    " TotalDemandAmount FLOAT CONSTRAINT DF_Table_1_SubTotal2_1 DEFAULT ((0)) NOT NULL, " & _
                    " Remark            NVARCHAR (255) CONSTRAINT DF_Sch_ScholarShipDemand_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy        NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt           DATETIME NOT NULL, " & _
                    " U_AE              NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date         DATETIME NULL, " & _
                    " ModifiedBy        NVARCHAR (10) NULL, " & _
                    " RowId             BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate        SMALLDATETIME NULL, " & _
                    " ApprovedBy        NVARCHAR (10) NULL, " & _
                    " ApprovedDate      SMALLDATETIME NULL, " & _
                    " GPX1              NVARCHAR (255) NULL, " & _
                    " GPX2              NVARCHAR (255) NULL, " & _
                    " GPN1              FLOAT NULL, " & _
                    " GPN2              FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipDemand PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_ScholarShipDemand UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand_Sch_Category FOREIGN KEY (Category) REFERENCES dbo.Sch_Category (Code), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand_Sch_Programme FOREIGN KEY (Programme) REFERENCES dbo.Sch_Programme (Code) " & _
                    " ) "

            If Not AgL.IsTableExist("Sch_ScholarShipDemand", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipDemand", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipDemand1 " & _
                    " ( " & _
                    " DocId                      NVARCHAR (21) NOT NULL, " & _
                    " Sr                         INT NOT NULL, " & _
                    " AdmissionDocId             NVARCHAR (21) NOT NULL, " & _
                    " SessionProgrammeStreamYear NVARCHAR (8) NOT NULL, " & _
                    " FamilyIncome               FLOAT CONSTRAINT DF_Sch_ScholarShipDemand1_FamilyIncome DEFAULT ((0)) NOT NULL, " & _
                    " DemandAmount               FLOAT NOT NULL, " & _
                    " RowId                      BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate                 SMALLDATETIME NULL, " & _
                    " ApprovedBy                 NVARCHAR (10) NULL, " & _
                    " ApprovedDate               SMALLDATETIME NULL, " & _
                    " GPX1                       NVARCHAR (255) NULL, " & _
                    " GPX2                       NVARCHAR (255) NULL, " & _
                    " GPN1                       FLOAT NULL, " & _
                    " GPN2                       FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipDemand1 PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT IX_Sch_ScholarShipDemand1_1 UNIQUE (DocId,AdmissionDocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand1_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand1_Sch_ScholarShipDemand FOREIGN KEY (DocId) REFERENCES dbo.Sch_ScholarShipDemand (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipDemand1_Sch_SessionProgrammeStreamYear FOREIGN KEY (SessionProgrammeStreamYear) REFERENCES dbo.Sch_SessionProgrammeStreamYear (Code) " & _
                    " ) "

            If Not AgL.IsTableExist("Sch_ScholarShipDemand1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipDemand1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipReceive " & _
                    " ( " & _
                    " DocId              NVARCHAR (21) NOT NULL, " & _
                    " Div_Code           NVARCHAR (1) NOT NULL, " & _
                    " Site_Code          NVARCHAR (2) NOT NULL, " & _
                    " V_Date             SMALLDATETIME NOT NULL, " & _
                    " V_Type             NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix           NVARCHAR (5) NOT NULL, " & _
                    " V_No               BIGINT NOT NULL, " & _
                    " DemandDocId        NVARCHAR (21) NOT NULL, " & _
                    " TotalReceiveAmount FLOAT CONSTRAINT DF_Table_1_TotalAmount DEFAULT ((0)) NOT NULL, " & _
                    " Remark             NVARCHAR (255) CONSTRAINT DF_Sch_ScholarShipReceive_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt            DATETIME NOT NULL, " & _
                    " U_AE               NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date          DATETIME NULL, " & _
                    " ModifiedBy         NVARCHAR (10) NULL, " & _
                    " RowId              BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate         SMALLDATETIME NULL, " & _
                    " ApprovedBy         NVARCHAR (10) NULL, " & _
                    " ApprovedDate       SMALLDATETIME NULL, " & _
                    " GPX1               NVARCHAR (255) NULL, " & _
                    " GPX2               NVARCHAR (255) NULL, " & _
                    " GPN1               FLOAT NULL, " & _
                    " GPN2               FLOAT NULL, " & _
                    " ScholarshipAc      NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipReceive PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_ScholarShipReceive UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive_ScholarshipAc FOREIGN KEY (ScholarshipAc) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive_Sch_ScholarShipDemand FOREIGN KEY (DemandDocId) REFERENCES dbo.Sch_ScholarShipDemand (DocId) " & _
                    " ) "

            If Not AgL.IsTableExist("Sch_ScholarShipReceive", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipReceive", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipReceive1 " & _
                    " ( " & _
                    " DocId            NVARCHAR (21) NOT NULL, " & _
                    " Sr               INT NOT NULL, " & _
                    " AdmissionDocId   NVARCHAR (21) NOT NULL, " & _
                    " DemandAmount     FLOAT NOT NULL, " & _
                    " ReceiveAmount    FLOAT CONSTRAINT DF_Table_1_FamilyIncome DEFAULT ((0)) NOT NULL, " & _
                    " DifferenceAmount FLOAT CONSTRAINT DF_Table_1_ReceiveAmount1 DEFAULT ((0)) NOT NULL, " & _
                    " FeeReceiveDocId  NVARCHAR (21) NULL, " & _
                    " RowId            BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate       SMALLDATETIME NULL, " & _
                    " ApprovedBy       NVARCHAR (10) NULL, " & _
                    " ApprovedDate     SMALLDATETIME NULL, " & _
                    " GPX1             NVARCHAR (255) NULL, " & _
                    " GPX2             NVARCHAR (255) NULL, " & _
                    " GPN1             FLOAT NULL, " & _
                    " GPN2             FLOAT NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipReceive1 PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT IX_Sch_ScholarShipReceive1 UNIQUE (DocId,Sr), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive1_Sch_ScholarShipReceive FOREIGN KEY (DocId) REFERENCES dbo.Sch_ScholarShipReceive (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive1_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceive1_Sch_FeeReceive FOREIGN KEY (FeeReceiveDocId) REFERENCES dbo.Sch_FeeReceive (DocId) " & _
                    " ) "

            If Not AgL.IsTableExist("Sch_ScholarShipReceive1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipReceive1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_ScholarShipReceiveDocIdDetail " & _
                    " ( " & _
                    " DocId              NVARCHAR (21) NOT NULL, " & _
                    " PaymentDetailDocId NVARCHAR (21) NULL, " & _
                    " LedgerMDocId       NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Sch_ScholarShipReceiveDocIdDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceiveDocIdDetail_Sch_ScholarShipReceive FOREIGN KEY (DocId) REFERENCES dbo.Sch_ScholarShipReceive (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceiveDocIdDetail_PaymentDetail FOREIGN KEY (PaymentDetailDocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceiveDocIdDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceiveDocIdDetail_Sch_ScholarShipReceive1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_ScholarShipReceive (DocId), " & _
                    " CONSTRAINT FK_Sch_ScholarShipReceiveDocIdDetail_Sch_ScholarShipReceive2 FOREIGN KEY (PaymentDetailDocId) REFERENCES dbo.Sch_ScholarShipReceive (DocId) " & _
                    " ) "
            If Not AgL.IsTableExist("Sch_ScholarShipReceiveDocIdDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ScholarShipReceiveDocIdDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try

            mQry = "CREATE TABLE dbo.Sch_DueInstallment " & _
                    " ( " & _
                    " UID                  UNIQUEIDENTIFIER NOT NULL,  " & _
                    " Div_Code             NVARCHAR (1) NULL,  " & _
                    " Site_Code            NVARCHAR (2) NULL,  " & _
                    " EntryDate            SMALLDATETIME NOT NULL,  " & _
                    " Prefix               NVARCHAR (10) NOT NULL,  " & _
                    " EntryNo              BIGINT NOT NULL,  " & _
                    " RecordType           NVARCHAR (35) NULL,  " & _
                    " Employee             NVARCHAR (10) NULL,  " & _
                    " SubCode              NVARCHAR (10) NULL,  " & _
                    " AdmissionDocId       NVARCHAR (21) NULL,  " & _
                    " DueAmount            FLOAT CONSTRAINT DF_Table_1_Installments1 DEFAULT ((0)) NULL,  " & _
                    " InstallmentAmount    FLOAT CONSTRAINT DF_Sch_DueInstallment_DueAmount1 DEFAULT ((0)) NULL,  " & _
                    " TotalInstallments    INT CONSTRAINT DF_Sch_DueInstallment_Installments DEFAULT ((0)) NULL,  " & _
                    " InstallmentStartDate SMALLDATETIME NULL,  " & _
                    " Remark               NVARCHAR (255) CONSTRAINT DF_Sch_DueInstallment_Remark DEFAULT ('') NULL,  " & _
                    " InActiveDate         SMALLDATETIME NULL,  " & _
                    " InActiveRemark       NVARCHAR (255) CONSTRAINT DF_Sch_DueInstallment_Remark1 DEFAULT ('') NULL,  " & _
                    " PreparedBy           NVARCHAR (10) NULL,  " & _
                    " U_EntDt              DATETIME NULL,  " & _
                    " U_AE                 NVARCHAR (1) NULL,  " & _
                    " Edit_Date            DATETIME NULL,  " & _
                    " ModifiedBy           NVARCHAR (10) NULL,  " & _
                    " ApprovedBy           NVARCHAR (10) NULL,  " & _
                    " ApprovedDate         SMALLDATETIME NULL,  " & _
                    " RowId                BIGINT IDENTITY NOT NULL,  " & _
                    " UpLoadDate           SMALLDATETIME NULL,  " & _
                    " CONSTRAINT PK_Sch_DueInstallment PRIMARY KEY (UID),  " & _
                    " CONSTRAINT IX_Sch_DueInstallment UNIQUE (Div_Code,Site_Code,Prefix,EntryNo),  " & _
                    " CONSTRAINT FK_Sch_DueInstallment_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code),  " & _
                    " CONSTRAINT FK_Sch_DueInstallment_SubGroup FOREIGN KEY (SubCode) REFERENCES dbo.SubGroup (SubCode),  " & _
                    " CONSTRAINT FK_Sch_DueInstallment_SubGroup1 FOREIGN KEY (Employee) REFERENCES dbo.SubGroup (SubCode),  " & _
                    " CONSTRAINT FK_Sch_DueInstallment_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_DueInstallment", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_DueInstallment", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_DueInstallment1 " & _
                    " ( " & _
                    " UID               UNIQUEIDENTIFIER NOT NULL, " & _
                    " Sr                INT NOT NULL,  " & _
                    " InstallmentDate   SMALLDATETIME NOT NULL,  " & _
                    " InstallmentAmount FLOAT CONSTRAINT DF_Sch_DueInstallment1_InstallmentAmount DEFAULT ((0)) NOT NULL,  " & _
                    " RemindBeforeDays  INT CONSTRAINT DF_Sch_DueInstallment1_RemindBeforeDays DEFAULT ((0)) NULL,  " & _
                    " RemindAfterDays   INT CONSTRAINT DF_Sch_DueInstallment1_RemindAfterDays DEFAULT ((0)) NULL,  " & _
                    " IsInActive        BIT CONSTRAINT DF_Sch_DueInstallment1_RemindAfterDays1 DEFAULT ((0)) NULL,  " & _
                    " RowId             BIGINT IDENTITY NOT NULL,  " & _
                    " UpLoadDate        SMALLDATETIME NULL,  " & _
                    " CONSTRAINT PK_Sch_DueInstallment1 PRIMARY KEY (UID,Sr),  " & _
                    " CONSTRAINT FK_Sch_DueInstallment1_Sch_DueInstallment FOREIGN KEY (UID) REFERENCES dbo.Sch_DueInstallment (UID) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_DueInstallment1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_DueInstallment1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub CreateView()
        Dim mQry As String = ""

        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            mQry = "CREATE VIEW dbo.ViewSch_FeeReceive As " & _
                    " SELECT ViewFr.*, Sem.SessionProgrammeStreamCode " & _
                    " FROM  (   " & _
                    " 	SELECT FRec.*, IsNull(VFref.RefundAmount,0) AS RefundAmount, IsNull(VFref.ExcessRefund,0) AS ExcessRefund,     " & _
                    " 	FRec.ReceiveAmount - IsNull(VFref.RefundAmount,0) AS ReceiveLessRefundAmount, IsNull(VFref.RegistrationAmountRefund,0) AS RegistrationAmountRefund,    " & _
                    " 	A.Student AS StudentCode, A.AdmissionID, A.Status, A.StudentName  , " & _
                    " 	CASE WHEN IsNull(Frec.IsAdjustableReceipt,0) <> 0 THEN FRec.TotalLineNetAmount - Frec.DiscountAmount ELSE 0 END  AS AdjustableFeeAmount , " & _
                    " 	Convert(BIT,CASE WHEN FAdj.AdjustableFeeReceiveDocId IS NULL THEN 0 ELSE 1 END) AS IsFeeReceiptAdjusted, " & _
                    " 	FAdj.FeeReceiveDocId AS FeeReceiptAdjustmentDocId, " & _
                    " 	(SELECT P.FromStreamYearSemester    FROM ViewSch_AdmissionPromotion P  WHERE P.AdmissionDocId =FRec.AdmissionDocId   AND FRec.V_Date >= P.AdmissionDate   AND P.Sr =   (SELECT Max(P.Sr)  FROM ViewSch_AdmissionPromotion P  WHERE P.AdmissionDocId = FRec.AdmissionDocId  AND FRec.V_Date >= P.AdmissionDate)) AS CurrentStreamYearSemesterCode " & _
                    " 	FROM Sch_FeeReceive FRec " & _
                    " 	LEFT JOIN ( " & _
                    " 	    		SELECT FRef1.FeeReceiveDocId, Sum(FRef1.NetAmount) AS RefundAmount, " & _
                    " 	    		Sum(CASE FRef1.ReturnHeadType WHEN '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' THEN 0 ELSE FRef1.NetAmount END) AS FeeRefund, " & _
                    " 	    		Sum(CASE FRef1.ReturnHeadType WHEN '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' THEN FRef1.NetAmount ELSE 0 END) AS ExcessRefund, " & _
                    " 	    		IsNull(Sum(FRef1.RegistrationAmount),0) AS RegistrationAmountRefund " & _
                    " 	    		FROM Sch_FeeRefund1 FRef1 " & _
                    " 	    		GROUP BY FRef1.FeeReceiveDocId " & _
                    " 	    	  ) VFref ON FRec.DocId = VFref.FeeReceiveDocId   " & _
                    " 	LEFT JOIN Sch_FeeReceiveAdjustableFeeReceive FAdj ON FRec.DocId = FAdj.AdjustableFeeReceiveDocId  " & _
                    " 	LEFT JOIN ViewSch_Admission A ON FRec.AdmissionDocId = A.DocId   " & _
                    " 	) ViewFr   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON ViewFr.CurrentStreamYearSemesterCode = Sem.Code "
            AgL.IsViewExist("ViewSch_FeeReceive", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_FeeReceive", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_FeeReceive1 As " & _
                    " SELECT FRec1.*, Fd1.Fee AS FeeCode,  IsNull(VFref1.RefundAmount,0) AS FeeRefundAmount," & _
                    " FRec1.NetAmount - IsNull(VFref1.RefundAmount,0) AS FeeReceiveLessRefundAmount," & _
                    " IsNull(VFref1.RegistrationAmountRefund,0) AS FeeRegistrationRefund, " & _
                    " FRec.Div_Code, FRec.Site_Code, FRec.V_Date, FRec.V_Type, FRec.V_Prefix, FRec.V_No," & _
                    " FRec.AdmissionDocId, Sem.SessionProgrammeStreamCode, FRec.StudentCode, FRec.AdmissionID," & _
                    " FRec.Status " & _
                    " FROM Sch_FeeReceive1 FRec1 " & _
                    " LEFT JOIN " & _
                    " (	  	SELECT Fref1.FeeReceive1, IsNull(Sum(FRef1.NetAmount),0) RefundAmount, IsNull(Sum(FRef1.RegistrationAmount),0) AS RegistrationAmountRefund " & _
                    " 		FROM Sch_FeeRefund1 FRef1 " & _
                    " 		Where FRef1.ReturnHeadType <> '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' " & _
                    "       GROUP BY Fref1.FeeReceive1 " & _
                    " ) VFref1 ON FRec1.Code = VFref1.FeeReceive1 " & _
                    " LEFT JOIN ViewSch_FeeReceive FRec ON FRec1.DocId = FRec.DocId " & _
                    " LEFT JOIN Sch_FeeDue1 Fd1 ON FRec1.FeeDue1 = Fd1.Code " & _
                    " LEFT JOIN Sch_FeeDue Fd ON Fd1.DocId = Fd.DocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Fd.StreamYearSemester  = Sem.Code "
            AgL.IsViewExist("ViewSch_FeeReceive1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_FeeReceive1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_FeeRefund As " & _
                    " SELECT FRef.*, Vt.NCat , Vt.Description AS V_TypeDesc , " & _
                    " A.Student AS StudentCode, A.StudentName , A.StudentDispName, " & _
                    " A.FatherName , A.MotherName , A.CityCode , A.CityName , A.PIN , A.CommonAc, S.Name As Site_Name  " & _
                    " ,(SELECT P.FromStreamYearSemester " & _
                    " FROM ViewSch_AdmissionPromotion P " & _
                    " WHERE P.AdmissionDocId = FRef.AdmissionDocId " & _
                    " AND FRef.V_Date >= P.AdmissionDate " & _
                    " AND P.Sr = " & _
                    " (SELECT Max(P.Sr) " & _
                    " FROM ViewSch_AdmissionPromotion P " & _
                    " WHERE P.AdmissionDocId = FRef.AdmissionDocId " & _
                    " AND FRef.V_Date >= P.AdmissionDate)) AS CurrentStreamYearSemesterCode " & _
                    " FROM Sch_FeeRefund FRef " & _
                    " LEFT JOIN SiteMast S ON FRef.Site_Code = S.Code " & _
                    " LEFT JOIN Voucher_Type Vt ON FRef.V_Type = Vt.V_Type  " & _
                    " LEFT JOIN ViewSch_Admission A ON FRef.AdmissionDocId = A.DocId "

            AgL.IsViewExist("ViewSch_FeeRefund", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_FeeRefund", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_FeeRefund1 As " & _
                    " SELECT FRef1.*,FRef.Div_Code , FRef.Site_Code , FRef.Site_Name , FRef.V_Date, FRef.V_Type, " & _
                    " FRef.V_Prefix, FRef.V_No , FRef.AdmissionDocId , FRef.StudentCode , " & _
                    " FRecv1.FeeDue1 AS FeeDue1Code, FRecv1.FeeCode, FRef.StudentName, FRef.StudentDispName, " & _
                    " FRef.FatherName , FRef.MotherName , FRef.CityCode , FRef.CityName , FRef.PIN , FRef.CommonAc " & _
                    " FROM ViewSch_FeeRefund As FRef " & _
                    " LEFT JOIN Sch_FeeRefund1 As FRef1 ON FRef.DocId = FRef1.DocId " & _
                    " LEFT JOIN ViewSch_FeeReceive1 AS FRecv1 ON FRef1.FeeReceive1 = FRecv1.Code "

            AgL.IsViewExist("ViewSch_FeeRefund1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_FeeRefund1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_FeeDue As " & _
                    " SELECT Fd.*, Fd1.Code AS FeeDue1Code, Fd1.Fee AS FeeCode, Fd1.Amount AS DueAmount, Fd1.AdmissionDocId, Fd1.IsReversePostable, Fd1.IsReversePosted, " & _
                    " IsNull(V1.ReceiveAmount,0) AS ReceiveAmount, IsNull(V1.Discount,0) AS Discount, IsNull(V1.NetReceiveAmount,0) AS NetReceiveAmount, " & _
                    " IsNull(Fd1.Amount,0) - IsNull(V1.ReceiveAmount,0) AS NetBalance " & _
                    " FROM Sch_FeeDue Fd " & _
                    " LEFT JOIN Sch_FeeDue1 Fd1 ON Fd.DocId = Fd1.DocId " & _
                    " LEFT JOIN (" & _
                    "               SELECT Fr1.FeeDue1 AS FeeDue1Code, IsNULL(Sum(Fr1.Amount),0) - IsNULL(Sum(Fr1.FeeRefundAmount),0) AS ReceiveAmount, " & _
                    "               IsNULL(Sum(Fr1.Discount),0) AS Discount, IsNULL(Sum(Fr1.FeeReceiveLessRefundAmount),0) AS NetReceiveAmount " & _
                    "               FROM dbo.ViewSch_FeeReceive1 Fr1 " & _
                    "               GROUP BY Fr1.FeeDue1) V1 ON Fd1.Code = V1.FeeDue1Code "


            AgL.IsViewExist("ViewSch_FeeDue", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_FeeDue", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdvanceReceive As  " & _
                    " SELECT ARec.*, A.AdmissionID, A.Student AS StudentCode, A.StudentName, " & _
                    " Fra.FeeReceiveDocId, Convert(BIT,CASE WHEN Fra.FeeReceiveDocId IS NULL THEN 0 ELSE 1 END) AS IsAdjusted, Vt.NCat, Vt.Description AS VoucherTypeDesc " & _
                    " ,(SELECT P.FromStreamYearSemester   " & _
                    " FROM ViewSch_AdmissionPromotion P " & _
                    " WHERE P.AdmissionDocId = ARec.AdmissionDocId  " & _
                    " AND ARec.V_Date >= P.AdmissionDate  " & _
                    " AND P.Sr =  " & _
                    " (SELECT Max(P.Sr) " & _
                    " FROM ViewSch_AdmissionPromotion P " & _
                    " WHERE P.AdmissionDocId = ARec.AdmissionDocId " & _
                    " AND ARec.V_Date >= P.AdmissionDate)) AS CurrentStreamYearSemesterCode  " & _
                    " FROM Sch_Advance ARec " & _
                    " LEFT JOIN Voucher_Type Vt ON ARec.V_Type = Vt.V_Type " & _
                    " LEFT JOIN Sch_FeeReceiveAdvance Fra ON ARec.DocId = Fra.AdvanceDocId " & _
                    " LEFT JOIN ViewSch_Admission A ON ARec.AdmissionDocId = A.DocId " & _
                    " WHERE Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_AdvanceReceive) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & ") "
            AgL.IsViewExist("ViewSch_AdvanceReceive", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_AdvanceReceive", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            '<Executable Code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            '===================================================< Reverse Fee Due Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ReverseFeeDue, Academic_ProjLib.ClsMain.Cat_ReverseFeeDue, "Reverse Fee Due", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ReverseFeeDue, Academic_ProjLib.ClsMain.Cat_ReverseFeeDue, Academic_ProjLib.ClsMain.NCat_ReverseFeeDue, "Reverse Fee Due", Academic_ProjLib.ClsMain.NCat_ReverseFeeDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

            '===================================================< Reverse Fee Due Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ReceiveEntry, Academic_ProjLib.ClsMain.Cat_ReceiveEntry, "Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ReceiveEntry, Academic_ProjLib.ClsMain.Cat_ReceiveEntry, Academic_ProjLib.ClsMain.NCat_ReceiveEntry, "Receive Entry", Academic_ProjLib.ClsMain.NCat_ReceiveEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

            '===================================================< Fee Receive Adjustment Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment, Academic_ProjLib.ClsMain.Cat_FeeReceive, "Fee Receive Adjustment", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment, Academic_ProjLib.ClsMain.Cat_FeeReceive, Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment, "Fee Receive Adjustment", Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

            '===================================================< Opening Advance Fee V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee, Academic_ProjLib.ClsMain.Cat_FeeReceive, "Opening Advance Fee", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee, Academic_ProjLib.ClsMain.Cat_FeeReceive, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee, "Opening Advance Fee", Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

            '===================================================< Scholarship Demand Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ScholarshipDemand, Academic_ProjLib.ClsMain.Cat_ScholarshipDemand, "Scholarship Demand", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ScholarshipDemand, Academic_ProjLib.ClsMain.Cat_ScholarshipDemand, Academic_ProjLib.ClsMain.NCat_ScholarshipDemand, "Scholarship Demand", Academic_ProjLib.ClsMain.NCat_ScholarshipDemand, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

            '===================================================< Scholarship Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ScholarshipReceive, Academic_ProjLib.ClsMain.Cat_ScholarshipReceive, "Scholarship Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ScholarshipReceive, Academic_ProjLib.ClsMain.Cat_ScholarshipReceive, Academic_ProjLib.ClsMain.NCat_ScholarshipReceive, "Scholarship Receive", Academic_ProjLib.ClsMain.NCat_ScholarshipReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

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

    'Public Structure Struct_FeeReceive
    '    Public DocId As String
    '    Public Div_Code As String
    '    Public Site_Code As String
    '    Public V_Date As String
    '    Public V_Type As String
    '    Public V_Prefix As String
    '    Public V_No As Long
    '    Public TotalLineAmount As Double
    '    Public TotalLineDiscount As Double
    '    Public TotalLineNetAmount As Double
    '    Public Advance As Double
    '    Public SubTotal1 As Double
    '    Public AdjustmentAmount As Double
    '    Public SubTotal2 As Double
    '    Public DiscountPer As Double
    '    Public DiscountAmount As Double
    '    Public TotalNetAmount As Double
    '    Public Remark As String
    '    Public PreparedBy As String
    '    Public U_EntDt As String
    '    Public U_AE As String
    '    Public Edit_Date As String
    '    Public ModifiedBy As String
    '    Public IsManageFee As String
    '    Public ReceiveAmount As Double
    '    Public AdvanceCarriedForward As Double
    '    Public AdmissionDocId As String
    '    Public TotalAdvanceAdjusted As String
    '    Public IsAdjustableReceipt As String
    '    Public TotalFeeReceiveAdjusted As String
    '    Public FeeAdjustmentAc As String
    '    Public FeeReceiptAdjustmentAc As String
    '    Public SubCode As String
    '    Public ScholarShipAmount As Double

    '    Public Sub Struct_FeeReceive()
    '        DocId = ""
    '        Div_Code = ""
    '        Site_Code = ""
    '        V_Date = ""
    '        V_Type = ""
    '        V_Prefix = ""
    '        V_No = ""
    '        TotalLineAmount = 0
    '        TotalLineDiscount = 0
    '        TotalLineNetAmount = 0
    '        Advance = 0
    '        SubTotal1 = 0
    '        AdjustmentAmount = 0
    '        SubTotal2 = 0
    '        DiscountPer = 0
    '        DiscountAmount = 0
    '        TotalNetAmount = 0
    '        Remark = ""
    '        PreparedBy = ""
    '        U_EntDt = ""
    '        U_AE = ""
    '        Edit_Date = ""
    '        ModifiedBy = ""
    '        IsManageFee = ""
    '        ReceiveAmount = 0
    '        AdvanceCarriedForward = 0
    '        AdmissionDocId = ""
    '        TotalAdvanceAdjusted = 0
    '        IsAdjustableReceipt = 0
    '        TotalFeeReceiveAdjusted = 0
    '        FeeAdjustmentAc = ""
    '        FeeReceiptAdjustmentAc = ""
    '        SubCode = ""
    '        ScholarShipAmount = 0
    '    End Sub
    'End Structure


    'Public Structure Struct_FeeReceive1
    '    Public Code As String
    '    Public DocId As String
    '    Public FeeDue1 As String
    '    Public Amount As Double
    '    Public Discount As Double
    '    Public NetAmount As Double

    '    Public Sub Struct_FeeReceive1()
    '        Code = ""
    '        DocId = ""
    '        FeeDue1 = ""
    '        Amount = 0
    '        Discount = 0
    '        NetAmount = 0
    '    End Sub
    'End Structure

#End Region

End Class