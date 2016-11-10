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

            AgL.PubReportPath_CommonData = AgL.INIRead(StrIniPath, "Reports", "CommonData", "")
            AgL.PubReportPath_Utility = AgL.INIRead(StrIniPath, "Reports", "Utility", "")

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
            PLib.PubReportPath_Academic_Main = AgL.INIRead(StrIniPath, "Reports", "Academic_Main", "")
            PLib.PubReportPath_TimeTable = AgL.INIRead(StrIniPath, "Reports", "TimeTable", "")
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

    Public Sub ProcSaveFeeDueDetail(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                    ByVal bFeeDueObj As Struct_FeeDue, ByVal bFeeDue1Obj() As Struct_FeeDue1, Optional ByVal bAdmissionDocId As String = "")
        Dim bQry$ = "", bFeeDue1Code$ = ""
        Dim mSr As Integer, I As Integer

        If AgL.StrCmp(bEntryMode, "Add") Then
            bQry = "INSERT INTO Sch_FeeDue " & _
                " (DocId,Div_Code,Site_Code,V_Type,V_Prefix, " & _
                " V_No,V_Date,remark,TotalAmount, StreamYearSemester,PreparedBy,U_EntDt,U_AE) " & _
                " VALUES " & _
                " (" & AgL.Chk_Text(bFeeDueObj.DocId) & ", " & AgL.Chk_Text(bFeeDueObj.Div_Code) & ", " & AgL.Chk_Text(bFeeDueObj.Site_Code) & ", " & AgL.Chk_Text(bFeeDueObj.V_Type) & ", " & AgL.Chk_Text(bFeeDueObj.V_Prefix) & ", " & _
                " " & bFeeDueObj.V_No & "," & AgL.ConvertDate(bFeeDueObj.V_Date) & ", " & _
                " " & AgL.Chk_Text(bFeeDueObj.Remark) & "," & Val(bFeeDueObj.TotalAmount) & ", " & AgL.Chk_Text(bFeeDueObj.StreamYearSemester) & "," & _
                " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'" & AgL.MidStr(bEntryMode, 0, 1) & "')"

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

        Else
            bQry = "UPDATE Sch_FeeDue " & _
                    " SET V_Date = " & AgL.ConvertDate(bFeeDueObj.V_Date) & ", " & _
                    " Remark=" & AgL.Chk_Text(bFeeDueObj.Remark) & ",TotalAmount=" & Val(bFeeDueObj.TotalAmount) & ", StreamYearSemester =  " & AgL.Chk_Text(bFeeDueObj.StreamYearSemester) & " , " & _
                    " U_AE = 'E',	Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ",	ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                    " Where DocId = '" & bFeeDueObj.DocId & "' "

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If



        mSr = 0
        For I = 0 To UBound(bFeeDue1Obj)
            If bFeeDue1Obj(I).Code = "" Then
                If bFeeDue1Obj(I).AdmissionDocId <> "" And bFeeDue1Obj(I).Fee <> "" Then
                    bFeeDue1Code = AgL.GetMaxId("Sch_FeeDue1", "Code", bConn, bFeeDueObj.Div_Code, bFeeDueObj.Site_Code, 8, True, True, , bConnectionString)
                    bQry = "INSERT INTO dbo.Sch_FeeDue1(Code,DocId,AdmissionDocId,Fee,Amount) " & _
                           "VALUES (" & AgL.Chk_Text(bFeeDue1Code) & "," & AgL.Chk_Text(bFeeDue1Obj(I).DocId) & "," & AgL.Chk_Text(bFeeDue1Obj(I).AdmissionDocId) & "," & AgL.Chk_Text(bFeeDue1Obj(I).Fee) & "," & Val(bFeeDue1Obj(I).Amount) & ") "
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                End If
            Else
                If bFeeDue1Obj(I).AdmissionDocId <> "" And bFeeDue1Obj(I).Fee <> "" Then
                    bQry = "UPDATE dbo.Sch_FeeDue1 " & _
                            "SET AdmissionDocId = " & AgL.Chk_Text(bFeeDue1Obj(I).AdmissionDocId) & ", " & _
                            "	Fee = " & AgL.Chk_Text(bFeeDue1Obj(I).Fee) & ", " & _
                            "	Amount = " & bFeeDue1Obj(I).Amount & " " & _
                            "WHERE Code = '" & bFeeDue1Obj(I).Code & "' "
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                Else
                    bQry = "Delete From Sch_feeDue1 Where Code = '" & bFeeDue1Obj(I).Code & "'"
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                End If
            End If
        Next I

        If AgL.StrCmp(bEntryMode, "Edit") And bAdmissionDocId.Trim <> "" Then
            bQry = "Delete From Sch_FeeDue1 " & _
                    " Where DocId = " & AgL.Chk_Text(bFeeDueObj.DocId) & " And " & _
                    " AdmissionDocId = " & AgL.Chk_Text(bAdmissionDocId) & " And " & _
                    " Fee Not In (SELECT Afd.Fee FROM Sch_AdmissionFeeDetail Afd " & _
                    "               WHERE Afd.DocId = " & AgL.Chk_Text(bAdmissionDocId) & " AND " & _
                    "               Afd.StreamYearSemester = " & AgL.Chk_Text(bFeeDueObj.StreamYearSemester) & ") "
            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If

    End Sub


    Public Function FunFeeDueAccountPosting(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                    ByVal bFeeDueObj As Struct_FeeDue) As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, J As Integer
        Dim DtTemp As DataTable
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(bFeeDueObj.DocId, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim bQry$ = ""
        Dim mFlagBln As Boolean = False

        bQry = "SELECT D1.DocId, D1.AdmissionDocId, D1.Fee, SUM(D1.Amount) AS Amount, Max(A.Student) as Student, Max(SgF.DispName) As FeeName " & _
               " FROM Sch_FeeDue1 D1  With (NoLock) " & _
               " Left Join Sch_Admission A With (NoLock) On D1.AdmissionDocId = A.DocId " & _
               " Left Join SubGroup SgF With (NoLock) On D1.Fee = SgF.SubCode " & _
               " Where D1.DocID = '" & bFeeDueObj.DocId & "' " & _
               " Group By D1.DocID, D1.AdmissionDocId, D1.Fee " & _
               "   "
        DtTemp = AgL.FillData(bQry, bConnRead).Tables(0)


        Dim bStudent As String
        Dim bStudentFee As Double
        Dim bStudentChangeFlag As Boolean

        For J = 0 To DtTemp.Rows.Count - 1
            mNarr = "Being " & AgL.XNull(DtTemp.Rows(J)("FeeName")) & " of Rs. " & Format(AgL.VNull(DtTemp.Rows(J)("Amount")), "0.00") & " Due For " & bFeeDueObj.StreamYearSemesterDesc
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)


            If mFlagBln = False Then
                I = 0
                mFlagBln = True
            Else
                I = UBound(LedgAry) + 1
            End If
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = DtTemp.Rows(J)("Fee")
            LedgAry(I).ContraSub = DtTemp.Rows(J)("Student")
            LedgAry(I).AmtCr = AgL.VNull(DtTemp.Rows(J)("Amount"))
            LedgAry(I).AmtDr = 0
            LedgAry(I).Narration = mNarr

            bStudent = DtTemp.Rows(J)("Student")
            bStudentFee = bStudentFee + AgL.VNull(DtTemp.Rows(J)("Amount"))


            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            If J < DtTemp.Rows.Count - 1 Then
                If Not AgL.StrCmp(bStudent, DtTemp.Rows(J + 1)("Student")) Then
                    bStudentChangeFlag = True
                Else
                    bStudentChangeFlag = False
                End If
            Else
                bStudentChangeFlag = True
            End If

            If bStudentChangeFlag Then
                mNarr = "Being Total Fee of Rs. " & Format(AgL.VNull(DtTemp.Rows(J)("Amount")), "0.00") & " Due For " & bFeeDueObj.StreamYearSemesterDesc
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                LedgAry(I).SubCode = bStudent
                LedgAry(I).AmtCr = 0
                LedgAry(I).AmtDr = bStudentFee
                LedgAry(I).Narration = mNarr

                bStudentFee = 0
                bStudentChangeFlag = False

                I = UBound(LedgAry) + 1
                ReDim Preserve LedgAry(I)
            End If
        Next

        mCommonNarr = bFeeDueObj.Remark
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)
        If AgL.LedgerPost(AgL.MidStr(bEntryMode, 0, 1), LedgAry, bConn, bCmd, bFeeDueObj.DocId, CDate(bFeeDueObj.V_Date), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , bConnectionString) = False Then
            FunFeeDueAccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        If bEntryMode = "Add" Then
            bQry = "INSERT INTO Sch_FeeDueLedgerM ( DocId ) VALUES ( " & _
                    " '" & bFeeDueObj.DocId & "' )"
            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If

    End Function

    Public Function FunGetTimeTableQuery(ByVal bAllocationDate As String, Optional ByVal bWeekDay As Byte = 0, Optional ByVal bClassSection As String = "") As String
        Dim bView1Qry$ = "", bCondStr$ = ""
        If bWeekDay > 0 Then bCondStr = " And T.WeekDay = " & bWeekDay & " "
        If bClassSection.Trim <> "" Then bCondStr = " And T.ClassSection = " & AgL.Chk_Text(bClassSection) & " "

        bView1Qry = "SELECT T.* FROM  (  " & _
                    " 	SELECT T.ClassSection + Convert(VARCHAR, T.WeekDay) AS Code,    " & _
                    " 	Max(T.ClassSection) AS ClassSection ,  Max(T.WeekDay) AS WeekDay, Max(T.ApplyDate) AS ApplyDate   " & _
                    " 	FROM TT_TimeTable T   " & _
                    " 	WHERE T.ApplyDate <= " & AgL.ConvertDate(bAllocationDate) & " " & _
                    " 	GROUP BY T.ClassSection + Convert(VARCHAR, T.WeekDay)  " & _
                    " ) AS V1   " & _
                    " INNER JOIN TT_TimeTable T ON V1.ClassSection = T.ClassSection AND V1.ApplyDate = T.ApplyDate And T.WeekDay = V1.WeekDay " & _
                    " WHERE 1 = 1 " & bCondStr
        FunGetTimeTableQuery = bView1Qry
    End Function
End Module