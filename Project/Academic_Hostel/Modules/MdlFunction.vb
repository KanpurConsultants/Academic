Imports System.Data.SqlClient
Module MdlFunction
    Public Function FOpenIni(ByVal StrIniPath As String, ByVal StrUserName As String, ByVal StrPassword As String) As Boolean
        Dim OLECmd As New OleDb.OleDbCommand
        Dim BlnRtn As Boolean = False
        Dim ECmd As SqlClient.SqlCommand

        Try
            AgL = New AgLibrary.ClsMain
            AgL.AglObj = AgL

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
            PLib.PubReportPath_Hostel = AgL.INIRead(StrIniPath, "Reports", "Hostel", AgL.PubReportPath)
            FOpenIni = BlnRtn            
        End Try
    End Function

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtHt_Enviro()
    End Sub

    Public Sub IniDtCommon_Enviro()
        DtCommon_Enviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtHt_Enviro()
        If AgL.IsTableExist("Ht_Enviro", AgL.GCn) Then
            DtHt_Enviro = AgL.FillData("SELECT E.* FROM Ht_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
        End If
    End Sub

    'Code By Akash on date 17-10-10

    Public Sub ProcSaveChargeDueDetail(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                    ByVal bChargeDueObj As Struct_ChargeDue, ByVal bChargeDue1Obj() As Struct_ChargeDue1, Optional ByVal bAllotmentDocId As String = "")
        Dim bQry$ = "", bChargeDue1Code$ = "", bChargeDue1CodeList$ = ""
        Dim mSr As Integer, I As Integer

        If AgL.StrCmp(bEntryMode, "Add") Then
            bQry = "INSERT INTO Ht_ChargeDue " & _
                " (DocId,Div_Code,Site_Code,V_Type,V_Prefix, " & _
                " V_No,V_Date,remark,TotalAmount, MonthStartDate,PreparedBy,U_EntDt,U_AE) " & _
                " VALUES " & _
                " (" & AgL.Chk_Text(bChargeDueObj.DocId) & ", " & AgL.Chk_Text(bChargeDueObj.Div_Code) & ", " & AgL.Chk_Text(bChargeDueObj.Site_Code) & ", " & AgL.Chk_Text(bChargeDueObj.V_Type) & ", " & AgL.Chk_Text(bChargeDueObj.V_Prefix) & ", " & _
                " " & bChargeDueObj.V_No & "," & AgL.ConvertDate(bChargeDueObj.V_Date) & ", " & _
                " " & AgL.Chk_Text(bChargeDueObj.Remark) & "," & Val(bChargeDueObj.TotalAmount) & ", " & AgL.Chk_Text(bChargeDueObj.MonthStartDate) & "," & _
                " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'" & AgL.MidStr(bEntryMode, 0, 1) & "')"

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

        Else
            bQry = "UPDATE Ht_ChargeDue " & _
                    " SET V_Date = " & AgL.ConvertDate(bChargeDueObj.V_Date) & ", " & _
                    " Remark=" & AgL.Chk_Text(bChargeDueObj.Remark) & ",TotalAmount=" & Val(bChargeDueObj.TotalAmount) & ", MonthStartDate =  " & AgL.Chk_Text(bChargeDueObj.MonthStartDate) & " , " & _
                    " U_AE = 'E',	Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ",	ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                    " Where DocId = '" & bChargeDueObj.DocId & "' "

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If



        mSr = 0 : bChargeDue1CodeList = ""
        For I = 0 To UBound(bChargeDue1Obj)
            If bChargeDue1Obj(I).Code = "" Then
                If bChargeDue1Obj(I).AllotmentDocId <> "" And bChargeDue1Obj(I).Charge <> "" Then
                    bChargeDue1Code = AgL.GetMaxId("Ht_ChargeDue1", "Code", bConn, bChargeDueObj.Div_Code, bChargeDueObj.Site_Code, 8, True, True, , bConnectionString)
                    bQry = "INSERT INTO dbo.Ht_ChargeDue1(Code,DocId,AllotmentDocId,Charge,Amount) " & _
                           "VALUES (" & AgL.Chk_Text(bChargeDue1Code) & "," & AgL.Chk_Text(bChargeDue1Obj(I).DocId) & "," & AgL.Chk_Text(bChargeDue1Obj(I).AllotmentDocId) & "," & AgL.Chk_Text(bChargeDue1Obj(I).Charge) & "," & Val(bChargeDue1Obj(I).Amount) & ") "

                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

                    bChargeDue1CodeList += IIf(bChargeDue1CodeList.Trim = "", "", ", ") + "'" & bChargeDue1Code & "'"
                End If
            Else
                If bChargeDue1Obj(I).AllotmentDocId <> "" And bChargeDue1Obj(I).Charge <> "" Then
                    bQry = "UPDATE dbo.Ht_ChargeDue1 " & _
                            " SET AllotmentDocId = " & AgL.Chk_Text(bChargeDue1Obj(I).AllotmentDocId) & ", " & _
                            " Charge = " & AgL.Chk_Text(bChargeDue1Obj(I).Charge) & ", " & _
                            " Amount = " & bChargeDue1Obj(I).Amount & " " & _
                            " WHERE Code = '" & bChargeDue1Obj(I).Code & "' "
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

                    bChargeDue1CodeList += IIf(bChargeDue1CodeList.Trim = "", "", ", ") + "'" & bChargeDue1Obj(I).Code & "'"

                Else
                    bQry = "Delete From Ht_ChargeDue1 Where Code = '" & bChargeDue1Obj(I).Code & "'"
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                End If
            End If
        Next I

        If AgL.StrCmp(bEntryMode, "Edit") And bAllotmentDocId.Trim <> "" Then
            bQry = "DELETE FROM Ht_ChargeDue1 " & _
                    " Where DocId = " & AgL.Chk_Text(bChargeDueObj.DocId) & "    " & _
                    " And AllotmentDocId = " & AgL.Chk_Text(bAllotmentDocId) & "  " & _
                    " And Code Not In (" & bChargeDue1CodeList & ") "
            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If

    End Sub


    Public Function FunChargeDueAccountPosting(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                    ByVal bChargeDueObj As Struct_ChargeDue, Optional ByVal bIsOpeningChargeDue As Boolean = False) As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, J As Integer
        Dim DtTemp As DataTable
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(bChargeDueObj.DocId, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim bQry$ = ""

        bQry = "SELECT D1.DocId, D1.AllotmentDocId, D1.Charge, SUM(D1.Amount) AS Amount,  " & _
             " Max(HRt.SubCode) as MemberName, Max(SgF.DispName) As ChargeName   " & _
             " FROM Ht_ChargeDue1 D1 With (NoLock)  " & _
             " LEFT JOIN Ht_RoomAllotment HRA With (NoLock) ON D1.AllotmentDocId=HRA.DocId  " & _
             " LEFT JOIN Ht_RoomTransfer HRT With (NoLock) ON HRA.DocId=HRT.AllotmentDocId  " & _
             " LEFT JOIN SubGroup SgF With (NoLock) ON D1.Charge=Sgf.SubCode  " & _
             " WHERE D1.DocId = '" & bChargeDueObj.DocId & "' " & _
             " Group By D1.DocID, D1.AllotmentDocId,D1.Charge  "

        DtTemp = AgL.FillData(bQry, bConnRead).Tables(0)


        Dim bMember As String
        Dim bMemberCharge As Double
        Dim bMemberChangeFlag As Boolean

        I = 0
        ReDim Preserve LedgAry(I)

        For J = 0 To DtTemp.Rows.Count - 1
            If Not bIsOpeningChargeDue Then
                mNarr = "Being " & AgL.XNull(DtTemp.Rows(J)("ChargeName")) & " of Rs. " & Format(AgL.VNull(DtTemp.Rows(J)("Amount")), "0.00") & " Due For " & bChargeDueObj.MonthStartDate
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                I = UBound(LedgAry) + 1
                ReDim Preserve LedgAry(I)

                LedgAry(I).SubCode = DtTemp.Rows(J)("Charge")
                LedgAry(I).ContraSub = DtTemp.Rows(J)("MemberName")
                LedgAry(I).AmtCr = AgL.VNull(DtTemp.Rows(J)("Amount"))
                LedgAry(I).AmtDr = 0
                LedgAry(I).Narration = mNarr
            End If

            bMember = DtTemp.Rows(J)("MemberName")
            bMemberCharge = bMemberCharge + AgL.VNull(DtTemp.Rows(J)("Amount"))
            If bContraSub.Trim = "" And bIsOpeningChargeDue = False Then bContraSub = DtTemp.Rows(J)("Charge")

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            If J < DtTemp.Rows.Count - 1 Then
                If Not AgL.StrCmp(bMember, DtTemp.Rows(J + 1)("MemberName")) Then
                    bMemberChangeFlag = True
                Else
                    bMemberChangeFlag = False
                End If
            Else
                bMemberChangeFlag = True
            End If

            If bMemberChangeFlag Then
                mNarr = "Being Total Charge of Rs. " & Format(AgL.VNull(DtTemp.Rows(J)("Amount")), "0.00") & " Due For " & bChargeDueObj.MonthStartDate
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                LedgAry(I).SubCode = bMember
                LedgAry(I).ContraSub = bContraSub
                LedgAry(I).AmtCr = 0
                LedgAry(I).AmtDr = bMemberCharge
                LedgAry(I).Narration = mNarr

                bMemberCharge = 0
                bMemberChangeFlag = False
                bContraSub = ""

                I = UBound(LedgAry) + 1
                ReDim Preserve LedgAry(I)
            End If
        Next

        mCommonNarr = bChargeDueObj.Remark
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeDueLedgerM Where DocId = '" & bChargeDueObj.DocId & "'", bConn, bCmd)
        If AgL.LedgerPost(AgL.MidStr(bEntryMode, 0, 1), LedgAry, bConn, bCmd, bChargeDueObj.DocId, CDate(bChargeDueObj.V_Date), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, bIsOpeningChargeDue, bConnectionString) = False Then
            FunChargeDueAccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        bQry = "INSERT INTO Ht_ChargeDueLedgerM ( DocId ) VALUES ( " & _
                " '" & bChargeDueObj.DocId & "' )"
        AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

    End Function

    Public Function FunGetMemberOutstandingQry(ByVal FromDate As String, ByVal ToDate As String, ByVal CondStr As String) As String
        Dim bQry As String = ""

        Try

            bQry = " SELECT RAlt.DocId AS AllotmentDocid, RAlt.Site_Code,SM.Name AS Site_Name,RT.HostelCode,RT.HostelDesc,RAlt.MemberName AS MemberName,RAlt.FatherName, " & _
                    " RAlt.Phone, RAlt.Mobile, RAlt.Fax, RAlt.EMail,VHSG.Sex,VHSG.Category,VHSG.CategoryDesc,Sc.ManualCode as CategoryManualCode, " & _
                    " IsNull(vCd.OpeningDueAmount,0) - IsNull(vCRecv.OpeningReceiveAmount,0) + IsNull(vCRef.OpeningRefundAmount,0) AS OpeningBalance, " & _
                    " IsNull(vCd.CurrentDueAmount,0) AS CurrentDueAmount, " & _
                    " IsNull(vCRecv.CurrentReceiveAmount,0) AS CurrentReceiveAmount, " & _
                    " IsNull(vCRef.CurrentRefundAmount,0) AS CurrentRefundAmount, " & _
                    " (IsNull(vCd.OpeningDueAmount,0) - IsNull(vCRecv.OpeningReceiveAmount,0) + IsNull(vCRef.OpeningRefundAmount,0)) + " & _
                    " (IsNull(vCd.CurrentDueAmount,0) - IsNull(vCRecv.CurrentReceiveAmount,0) + IsNull(vCRef.CurrentRefundAmount,0)) AS NetBalance, " & _
                    " IsNull(vARecv.NetAdvanceTillDate,0) AS NetAdvanceTillDate, " & _
                    " vRt.CurrentBuildingFloorRoomDesc, vRt.CurrentRoomCode , vRt.LeftDate, " & _
                    " RAlt.MemberType, A.AdmissionID, " & _
                    " CASE RAlt.MemberType WHEN 'Student' THEN " & _
                    " ( " & _
                    "  SELECT P.FromStreamYearSemester AS CurrentStramYearSemester " & _
                    "  FROM ViewSch_AdmissionPromotion P " & _
                    "  WHERE P.AdmissionDocId = A.DocId  " & _
                    "  AND " & AgL.ConvertDate(ToDate) & " >= P.AdmissionDate  " & _
                    "  AND P.Sr =    " & _
                    "	( " & _
                    "		SELECT Max(P1.Sr)   " & _
                    "		FROM ViewSch_AdmissionPromotion P1   " & _
                    "		WHERE P1.AdmissionDocId = P.AdmissionDocId  AND  " & _
                    "       " & AgL.ConvertDate(ToDate) & " >= P1.AdmissionDate " & _
                    "	) " & _
                    " )  " & _
                    " ELSE  " & _
                    "	NULL " & _
                    " END AS CurrentStramYearSemesterCode " & _
                    " FROM ViewHt_RoomAllotment RAlt " & _
                    " LEFT JOIN Sch_Admission A ON A.Student=RAlt.MemberCode  " & _
                    " Left Join " & _
                    " ( " & _
                    " SELECT Cd.AllotmentDocId, " & _
                    " SUM(CASE WHEN Cd.V_Date < " & AgL.ConvertDate(FromDate) & " THEN Cd.DueAmount ELSE 0 END) AS OpeningDueAmount, " & _
                    " SUM(CASE WHEN Cd.V_Date < " & AgL.ConvertDate(FromDate) & " THEN 0 ELSE Cd.DueAmount END) AS CurrentDueAmount " & _
                    " FROM ViewHt_ChargeDue Cd " & _
                    " WHERE Cd.V_Date <= " & AgL.ConvertDate(ToDate) & " " & _
                    " GROUP BY Cd.AllotmentDocId  " & _
                    " ) vCd ON RAlt.DocId = vCd.AllotmentDocId " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT CRecv1.AllotmentDocId, " & _
                    " SUM(CASE WHEN CRecv1.V_Date < " & AgL.ConvertDate(FromDate) & " THEN CRecv1.Amount ELSE 0 END) AS OpeningReceiveAmount, " & _
                    " SUM(CASE WHEN CRecv1.V_Date < " & AgL.ConvertDate(FromDate) & " THEN 0 ELSE CRecv1.Amount END) AS CurrentReceiveAmount " & _
                    " FROM ViewHt_ChargeReceive1 CRecv1 " & _
                    " WHERE CRecv1.V_Date <= " & AgL.ConvertDate(ToDate) & " " & _
                    " GROUP BY CRecv1.AllotmentDocId  " & _
                    " ) vCRecv ON RAlt.DocId = vCRecv.AllotmentDocId " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT CRef1.AllotmentDocId, " & _
                    " SUM(CASE WHEN CRef1.V_Date < " & AgL.ConvertDate(FromDate) & " THEN CRef1.NetAmount ELSE 0 END) AS OpeningRefundAmount, " & _
                    " SUM(CASE WHEN CRef1.V_Date < " & AgL.ConvertDate(FromDate) & " THEN 0 ELSE CRef1.NetAmount END) AS CurrentRefundAmount " & _
                    " FROM ViewHt_ChargeRefund1 CRef1 " & _
                    " WHERE CRef1.V_Date <= " & AgL.ConvertDate(ToDate) & " " & _
                    " GROUP BY CRef1.AllotmentDocId  " & _
                    " ) vCRef ON RAlt.DocId = vCref.AllotmentDocId " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT ARecv.AllotmentDocId,  " & _
                    " SUM(CASE WHEN CRecv.V_Date <= " & AgL.ConvertDate(ToDate) & " THEN 0 ELSE ARecv.ReceiveAmount END) AS NetAdvanceTillDate  " & _
                    " FROM ViewHt_AdvanceReceive ARecv " & _
                    " LEFT JOIN Ht_ChargeReceive CRecv ON ARecv.ChargeReceiveDocId = CRecv.DocId  " & _
                    " WHERE ARecv.V_Date <= " & AgL.ConvertDate(ToDate) & " " & _
                    " GROUP BY ARecv.AllotmentDocId  " & _
                    " ) vARecv ON RAlt.DocId = vARecv.AllotmentDocId " & _
                    " LEFT JOIN  " & _
                    " ( " & _
                    " SELECT Rt.AllotmentDocId,  " & _
                    " CASE WHEN Rt.LeftDate IS NULL THEN Rt.BuildingFloorRoomDesc Else CASE WHEN Rt.LeftDate > " & AgL.ConvertDate(ToDate) & " THEN Rt.BuildingFloorRoomDesc ELSE NULL END  END AS CurrentBuildingFloorRoomDesc, " & _
                    " CASE WHEN Rt.LeftDate IS NULL THEN Rt.Room Else CASE WHEN Rt.LeftDate > " & AgL.Chk_Text(FromDate) & " THEN Rt.Room ELSE NULL END  END AS CurrentRoomCode , " & _
                    "                                     Rt.LeftDate " & _
                    " FROM ViewHt_RoomTransfer Rt " & _
                    " WHERE Rt.AllotmentDate =	 " & _
                    " 	( " & _
                    " 		SELECT Max(VHRT.AllotmentDate) AS RoomJoinDate " & _
                    " 		FROM ViewHt_RoomTransfer VHRT " & _
                    " 		WHERE VHRT.AllotmentDate <=" & AgL.ConvertDate(ToDate) & " AND VHRT.AllotmentDocId = Rt.AllotmentDocId " & _
                    " 		GROUP BY VHRT.AllotmentDocId " & _
                    " 	) " & _
                    " ) vRt ON RAlt.DocId = vRt.AllotmentDocId " & _
                    " LEFT JOIN ViewHt_RoomTransfer RT ON RT.AllotmentDocId=RAlt.DocId AND Rt.AllotmentType='" & AllotmentType_Allotment & "'" & _
                    " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode=RT.SubCode " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=RAlt.Site_Code  " & _
                    " Left join Sch_Category Sc on Sc.Code =VHSG.Category " & _
                    " " & CondStr & " "


            

        Catch ex As Exception
            MsgBox(ex.Message)
            bQry = ""
        Finally
            FunGetMemberOutstandingQry = bQry
        End Try
    End Function
End Module