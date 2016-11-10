Imports System.Data.SqlClient
Module MdlFunction
    Public Function FOpenIni(ByVal StrIniPath As String, ByVal StrUserName As String, ByVal StrPassword As String) As Boolean
        Dim OLECmd As New OleDb.OleDbCommand
        Dim BlnRtn As Boolean = False
        Dim ECmd As SqlClient.SqlCommand

        Try
            AgL = New AgLibrary.ClsMain : AgL.AglObj = AgL

            AgL.PubDBUserSQL = "sa"
            AgL.PubDBPasswordSQL = ""
            AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Name", "")
            AgL.PubReportPath = AgL.INIRead(StrIniPath, "Reports", "Path", "")
            AgL.PubCompanyDBName = AgL.INIRead(StrIniPath, "CompanyInfo", "Path", "")
            AgL.PubChkPasswordSQL = AgL.INIRead(StrIniPath, "Security", "PasswordSQL", "")
            AgL.PubChkPasswordAccess = AgL.INIRead(StrIniPath, "Security", "PasswordAccess", "")

            AgL.PubReportPath_CommonData = AgL.INIRead(StrIniPath, "Reports", "CommonData", AgL.PubReportPath)
            AgL.PubReportPath_Utility = AgL.INIRead(StrIniPath, "Reports", "Utility", AgL.PubReportPath)

            AgIniVar = New AgLibrary.ClsIniVariables(AgL)

            BlnRtn = AgIniVar.FOpenIni(StrUserName, StrPassword)

            OLECmd = Nothing
        Catch Ex As Exception
            BlnRtn = False
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        Finally
            ECmd = Nothing
            PLib = New Academic_ProjLib.ClsMain(AgL)
            AgPL = New AgLibrary.ClsPrinting(AgL)
            PObj = New Academic_Objects.ClsMain(AgL, PLib)
            PLib.PubReportPath_Academic_Main = AgL.INIRead(StrIniPath, "Reports", "Academic_Main", AgL.PubReportPath)

            Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain = True
            Academic_ProjLib.ClsMain.IsModuleActive_FeeModule = True

            FOpenIni = BlnRtn
        End Try
    End Function

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtSch_Enviro()
    End Sub

    Public Sub IniDtCommon_Enviro()
        DtCommon_Enviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtSch_Enviro()
        DtSch_Enviro = AgL.FillData("SELECT E.* FROM Sch_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub ProcSaveFeeReceiveDetail(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, _
                                        ByVal bConnRead As SqlClient.SqlConnection, _
                                        ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                        ByRef bFeeReceiveObj As Struct_FeeReceive, _
                                        ByRef bFeeReceive1Obj() As Struct_FeeReceive1, _
                                        ByVal bRowIndex As Integer, ByVal bFeeReceiveDocId As String, _
                                        ByVal bIsFeeAdjusted As String)

        Dim bQry$ = "", bFeeReceive1Code$ = ""
        Dim mSr As Integer, I As Integer

        If bFeeReceiveDocId = "" Then
            If AgL.StrCmp(bIsFeeAdjusted, "Yes") Then
                bQry = "INSERT INTO dbo.Sch_FeeReceive ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                    " TotalLineAmount, TotalLineDiscount, TotalLineNetAmount, Advance, SubTotal1, AdjustmentAmount, " & _
                    " SubTotal2, DiscountPer, DiscountAmount, TotalNetAmount, IsManageFee, ReceiveAmount, " & _
                    " AdvanceCarriedForward, AdmissionDocId, Remark, TotalAdvanceAdjusted, ScholarShipAmount, ScholarshipAdjustmentAc, " & _
                    " PreparedBy, U_EntDt, U_AE) " & _
                    " VALUES ( " & _
                    " " & AgL.Chk_Text(bFeeReceiveObj.DocId) & ", " & AgL.Chk_Text(bFeeReceiveObj.Div_Code) & ", " & _
                    " " & AgL.Chk_Text(bFeeReceiveObj.Site_Code) & ", " & _
                    " " & AgL.ConvertDate(bFeeReceiveObj.V_Date) & ", " & AgL.Chk_Text(bFeeReceiveObj.V_Type) & ", " & _
                    " " & AgL.Chk_Text(bFeeReceiveObj.V_Prefix) & ", " & bFeeReceiveObj.V_No & ", " & _
                    " " & Val(bFeeReceiveObj.TotalLineAmount) & ", " & Val(bFeeReceiveObj.TotalLineDiscount) & ", " & _
                    " " & Val(bFeeReceiveObj.TotalLineNetAmount) & ", " & Val(bFeeReceiveObj.Advance) & ", " & _
                    " " & Val(bFeeReceiveObj.SubTotal1) & ", " & Val(bFeeReceiveObj.AdjustmentAmount) & ", " & _
                    " " & Val(bFeeReceiveObj.SubTotal2) & ", " & Val(bFeeReceiveObj.DiscountPer) & ", " & _
                    " " & Val(bFeeReceiveObj.DiscountAmount) & ", " & Val(bFeeReceiveObj.TotalNetAmount) & ", " & _
                    " " & Val(bFeeReceiveObj.IsManageFee) & ", " & Val(bFeeReceiveObj.ReceiveAmount) & ", " & _
                    " " & Val(bFeeReceiveObj.AdvanceCarriedForward) & ", " & _
                    " " & AgL.Chk_Text(bFeeReceiveObj.AdmissionDocId) & ", " & AgL.Chk_Text(bFeeReceiveObj.Remark) & ", " & _
                    " " & Val(bFeeReceiveObj.TotalAdvanceAdjusted) & ", " & Val(bFeeReceiveObj.ScholarShipAmount) & ", " & _
                    " " & AgL.Chk_Text(AgL.XNull(DtSch_Enviro.Rows(0)("ScholarshipAdjustmentAc"))) & ", " & _
                    " '" & AgL.PubUserName & "', " & _
                    " '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' )"

                AgL.Dman_ExecuteNonQry(bQry, AgL.GCn, AgL.ECmd)
            End If
        Else
            If AgL.StrCmp(bIsFeeAdjusted, "Yes") Then
                bQry = "Update Sch_FeeReceive " & _
                        " SET  " & _
                        " V_Date = " & AgL.ConvertDate(bFeeReceiveObj.V_Date) & ", " & _
                        " TotalLineAmount = " & Val(bFeeReceiveObj.TotalLineAmount) & ", " & _
                        " TotalLineDiscount =  " & Val(bFeeReceiveObj.TotalLineDiscount) & ", " & _
                        " TotalLineNetAmount = " & Val(bFeeReceiveObj.TotalLineNetAmount) & ", " & _
                        " TotalAdvanceAdjusted = " & Val(bFeeReceiveObj.TotalAdvanceAdjusted) & ", " & _
                        " Advance = " & Val(bFeeReceiveObj.Advance) & ", " & _
                        " SubTotal1 = " & Val(bFeeReceiveObj.SubTotal1) & ", " & _
                        " AdjustmentAmount = " & Val(bFeeReceiveObj.AdjustmentAmount) & ", " & _
                        " SubTotal2 = " & Val(bFeeReceiveObj.SubTotal2) & ", " & _
                        " DiscountPer = " & Val(bFeeReceiveObj.DiscountPer) & ", " & _
                        " DiscountAmount = " & Val(bFeeReceiveObj.DiscountAmount) & ", " & _
                        " TotalNetAmount = " & Val(bFeeReceiveObj.TotalNetAmount) & ", " & _
                        " Remark = " & AgL.Chk_Text(bFeeReceiveObj.Remark) & ", " & _
                        " IsManageFee = " & Val(bFeeReceiveObj.IsManageFee) & ", " & _
                        " ReceiveAmount = " & Val(bFeeReceiveObj.ReceiveAmount) & ", " & _
                        " AdvanceCarriedForward = " & Val(bFeeReceiveObj.AdvanceCarriedForward) & ", " & _
                        " AdmissionDocId = " & AgL.Chk_Text(bFeeReceiveObj.AdmissionDocId) & ", " & _
                        " ScholarShipAmount = " & Val(bFeeReceiveObj.ScholarShipAmount) & ", " & _
                        " ScholarshipAdjustmentAc = " & AgL.Chk_Text(AgL.XNull(DtSch_Enviro.Rows(0)("ScholarshipAdjustmentAc"))) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & bFeeReceiveObj.DocId & "' "

                AgL.Dman_ExecuteNonQry(bQry, AgL.GCn, AgL.ECmd)
            Else
                AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, bFeeReceiveDocId)

                bQry = "Delete From Sch_FeeReceive1 Where DocId  = '" & bFeeReceiveDocId & "'"
                AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

                bQry = "Delete From Sch_FeeReceive Where DocId  = '" & bFeeReceiveDocId & "'"
                AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                bFeeReceiveObj.DocId = ""
            End If
        End If

        If bFeeReceive1Obj IsNot Nothing Then
            mSr = 0
            For I = 0 To UBound(bFeeReceive1Obj)
                If bFeeReceive1Obj(I).Code = "" Then
                    If bFeeReceive1Obj(I).FeeDue1 <> "" And Val(bFeeReceive1Obj(I).Amount) <> 0 Then
                        bFeeReceive1Code = AgL.GetMaxId("Sch_FeeReceive1", "Code", bConn, bFeeReceiveObj.Div_Code, bFeeReceiveObj.Site_Code, 8, True, True, , bConnectionString)

                        bQry = "INSERT INTO Sch_FeeReceive1 ( " & _
                                " Code, DocId, FeeDue1, Amount, Discount, NetAmount	) " & _
                                " VALUES ( " & _
                                " '" & bFeeReceive1Code & "', '" & bFeeReceiveObj.DocId & "', " & _
                                " " & AgL.Chk_Text(bFeeReceive1Obj(I).FeeDue1) & ", " & _
                                " " & Val(bFeeReceive1Obj(I).Amount) & ", " & Val(bFeeReceive1Obj(I).Discount) & ", " & _
                                " " & Val(bFeeReceive1Obj(I).NetAmount) & ")"

                        AgL.Dman_ExecuteNonQry(bQry, AgL.GCn, AgL.ECmd)
                    End If
                Else
                    If bFeeReceive1Obj(I).FeeDue1 <> "" And Val(bFeeReceive1Obj(I).Amount) <> 0 Then

                        bQry = "UPDATE Sch_FeeReceive1 SET " & _
                                " FeeDue1 = " & AgL.Chk_Text(bFeeReceive1Obj(I).FeeDue1) & ", " & _
                                " Amount = " & Val(bFeeReceive1Obj(I).Amount) & ", " & _
                                " Discount = " & Val(bFeeReceive1Obj(I).Discount) & ", " & _
                                " NetAmount = " & Val(bFeeReceive1Obj(I).NetAmount) & " " & _
                                " WHERE Code = " & AgL.Chk_Text(bFeeReceive1Obj(I).Code) & " "

                        AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                    Else
                        bQry = "Delete From Sch_FeeReceive1 Where Code = '" & bFeeReceive1Obj(I).Code & "'"
                        AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                    End If
                End If
            Next I
        End If
    End Sub

    Public Function FunFeeReceiveAccountPosting(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, _
                                                ByVal bConnRead As SqlClient.SqlConnection, _
                                                ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                                ByRef bFeeReceiveObj As Struct_FeeReceive, _
                                                ByVal bIsFeeAdjusted As String) As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer
        Dim mNarr As String = "", mCommonNarr$ = "", bQry$ = ""
        Dim GcnRead As SqlClient.SqlConnection

        If AgL.StrCmp(bIsFeeAdjusted, "No") Then AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, bFeeReceiveObj.DocId) : Exit Function

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        I = 0
        ReDim Preserve LedgAry(I)

        If Val(bFeeReceiveObj.ScholarShipAmount) > 0 Then
            mNarr = "Being Scholarship Adjusted Of Rs. " & Format(Val(" & Val(bFeeReceiveObj.ScholarShipAmount) & "), "0.00") & "!..."
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = AgL.XNull(DtSch_Enviro.Rows(0)("ScholarshipAdjustmentAc"))
            LedgAry(I).ContraSub = bFeeReceiveObj.SubCode
            LedgAry(I).AmtDr = Val(bFeeReceiveObj.ScholarShipAmount)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = mNarr

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = bFeeReceiveObj.SubCode
            LedgAry(I).ContraSub = AgL.XNull(DtSch_Enviro.Rows(0)("ScholarshipAdjustmentAc"))
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(bFeeReceiveObj.ScholarShipAmount)
            LedgAry(I).Narration = mNarr
        End If

        mCommonNarr = bFeeReceiveObj.Remark
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.LedgerPost(AgL.MidStr(bEntryMode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, bFeeReceiveObj.DocId, CDate(bFeeReceiveObj.V_Date), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            FunFeeReceiveAccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        GcnRead.Close()
        GcnRead.Dispose()
    End Function

    Public Function FunGetEntryNo(ByVal StrTableName As String, ByVal StrPrefix As String, _
                                    ByVal StrSite_Code As String, ByVal StrDiv_Code As String _
                                    ) As Long
        Dim bLongEntryNo As Long = 0
        Dim bCondStr$ = "", mQry$ = ""

        Try

            bCondStr = " Where 1=1 "

            bCondStr += " And H.Site_Code = " & AgL.Chk_Text(StrSite_Code) & " "
            bCondStr += " And H.Div_Code = " & AgL.Chk_Text(StrDiv_Code) & " "
            bCondStr += " And H.Prefix = " & AgL.Chk_Text(StrPrefix) & " "

            mQry = "SELECT IsNull(Max(H.EntryNo),0) + 1 AS MaxId " & _
                    " FROM " & StrTableName & " H With (NoLock) " & bCondStr

            bLongEntryNo = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
        Catch ex As Exception
            bLongEntryNo = 0
            MsgBox(ex.Message)
        End Try

        Return bLongEntryNo
    End Function

    Public Function FunGetEntryNoDisplayField(ByVal StrTableAlias As String) As String
        Dim bStrReturn$ = ""

        Try
            bStrReturn = "Convert(VARCHAR," & StrTableAlias & ".EntryNo)"

            bStrReturn += " + '-' + " & StrTableAlias & ".Prefix "
            bStrReturn += " + '-' + " & StrTableAlias & ".Site_Code "
            bStrReturn += " + '-' + " & StrTableAlias & ".Div_Code "

        Catch ex As Exception
            bStrReturn = ""
            MsgBox(ex.Message)
        End Try

        Return bStrReturn
    End Function

    Public Function FunGetEntryNoDisplayValue(ByVal LongEntryNo As Long, ByVal StrPrefix As String, _
                                            ByVal StrSite_Code As String, ByVal StrDiv_Code As String) As String
        Dim bStrReturn$ = ""

        Try
            bStrReturn = LongEntryNo.ToString

            bStrReturn += "-" + StrPrefix
            bStrReturn += "-" + StrSite_Code
            bStrReturn += "-" + StrDiv_Code

        Catch ex As Exception
            bStrReturn = ""
            MsgBox(ex.Message)
        End Try

        Return bStrReturn
    End Function

End Module