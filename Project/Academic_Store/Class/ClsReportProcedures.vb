Public Class ClsReportProcedures

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

#Region "Danger Zone"
    Dim StrArr1() As String = Nothing, StrArr2() As String = Nothing, StrArr3() As String = Nothing, StrArr4() As String = Nothing, StrArr5() As String = Nothing

    Dim mGRepFormName As String = ""
    Dim WithEvents ObjRFG As AgLibrary.RepFormGlobal

    Public Property GRepFormName() As String
        Get
            GRepFormName = mGRepFormName
        End Get
        Set(ByVal value As String)
            mGRepFormName = value
        End Set
    End Property

#End Region

    Dim DsRep As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Reports Constant"
    Private Const SaleRegister As String = "SaleRegister"
    Private Const SaleSummary As String = "SaleSummary"
    Private Const PurchaseRegister As String = "PurchaseRegister"
    Private Const PurchaseSummary As String = "PurchaseSummary"
    Private Const StockRegister As String = "StockRegister"
    Private Const StockSummary As String = "StockSummary"
    Private Const IssueRegister As String = "IssueRegister"
    Private Const FixedAssetsRegister As String = "FixedAssetsRegister"
    Private Const RequisitionRegister As String = "RequisitionRegister"
    Private Const PurchaseIndentRegister As String = "PurchaseIndentRegister"
    Private Const PurchaseOrderRegister As String = "PurchaseOrderRegister"
    Private Const GRNRegister As String = "GRNRegister"

#End Region

#Region "Queries Definition"

    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "

    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "

    'changed by akash on date 20-9-10
    'Dim mHelpDepartmentQry$ = "Select Convert(BIT,0) As [Select], D.Code, D.Description As [Department Name], D.ManualCode As [Department Short Name], D.MainStreamCode From Sch_Department D  "
    Dim mHelpDepartmentQry$ = "Select Convert(BIT,0) As [Select], D.Code, D.Description As [Department Name] From Sch_Department D With (NoLock)  "

    Dim mHelpIndentorQry$ = "Select Convert(BIT,0) As [Select], H.SubCode AS Code, Sg.Name as [Indentor]  FROM Pay_Employee H With (NoLock) LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode  Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""

    Dim mHelpSupplierQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Supplier Name] " & _
                            " From ViewSubGroup Sg " & _
                            " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And (Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & " Or " & _
                            "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") "

    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] " & _
                            " From ViewSubGroup Sg " & _
                            " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And (Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & " Or " & _
                            "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") "

    Dim mHelpPartyQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Party Name] " & _
                            " From ViewSubGroup Sg " & _
                            " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And (Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & " Or " & _
                            "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & "Or " & _
                            "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") "

    Dim mHelpItemQry$ = "Select Convert(BIT,0) As [Select], Code, Description As [Item Name] From store_Item Where  Store_Item.MasterType = '" & ClsMain.ItemType.Store & "'"

    'Code by Akash on date 18-9-10

    Dim mHelpItemCatagoryQry$ = "SELECT convert(BIT,0) AS [SELECT],code,Description As [Item Catagory] FROM Store_ItemCategory Where  MasterType = '" & ClsMain.ItemType.Store & "' "

    Dim mHelpItemGroupQry$ = "SELECT convert(BIT,0) AS [SELECT],code,Description As [Item Group] FROM Store_ItemGroup Where  MasterType = '" & ClsMain.ItemType.Store & "'  "

    Dim mHelpItemCategoryQry$ = "SELECT Convert(BIT,0) As [Select], C.Code, C.Description AS [Item Category] " & _
                               " From Store_ItemCategory C With (NoLock) " & _
                               " Where IsNull(C.MasterType,'') = '" & ClsMain.ItemType.Store & "' "

    'Dim mHelpItemNature1Qry$ = "SELECT Convert(BIT,0) As [Select],'" & ClsVar.Item_Nature1_Description & "' AS Code,'" & ClsVar.Item_Nature1_Description & "' AS  Description  " & _
    '                           "FROM Store_Item_Nature1 n GROUP BY n.Description  "

    Dim mHelpItemNature1Qry$ = "SELECT Convert(BIT,0) As [Select],n.Description AS code,n.Description AS Description  " & _
                               "FROM Store_Item_Nature1 n GROUP BY n.Description  "

    Dim mHelpItemNature2Qry$ = "SELECT Convert(BIT,0) As [Select],n.Description AS code,n.Description AS Description   " & _
                               "FROM Store_Item_Nature2 n GROUP BY n.Description  "


    Dim mHelpbatchQry$ = "SELECT Convert(BIT,0) As [Select], Batchno As Code, Batchno As [Tyre No]   " & _
                         "FROM Store_Stock Where BatchNo Is Not Null GROUP BY BatchNo"

    Dim mHelpReqNoQry$ = "Select Convert(BIT,0) As [Select], S.DocID as Code,S.V_No as VrNo, S.V_Date As [Date],SG.Name As [Requisition By],S.ReferenceNo From Store_Requisition S with (NoLock) left Join Subgroup SG With (NoLock) on S.SubCode=SG.SubCode Where  S.V_Type = '" & ClsMain.Temp_NCat.Requistion & "'"

    Dim mHelpGRNNoQry$ = "Select Convert(BIT,0) As [Select], S.DocID as Code,S.V_No as VrNo, S.V_Date As [Date],SG.Name As [Party Name],S.ReferenceNo From Store_GRN S with (NoLock) left Join Subgroup SG With (NoLock) on S.AcCode=SG.SubCode Where  S.V_Type = '" & ClsMain.Temp_NCat.StoreGRN & "'"

    Dim mHelpOrderNoQry$ = "Select Convert(BIT,0) As [Select], S.DocID as Code,S.V_No as VrNo, S.V_Date As [Date],SG.Name As [Party Name],S.ReferenceNo From Store_PurchOrder S with (NoLock) left Join Subgroup SG With (NoLock) on S.SubCode=SG.SubCode Where  S.V_Type = '" & ClsMain.Temp_NCat.StorePurchaseOrder & "'"

    Dim mHelpIndentNoQry$ = "Select Convert(BIT,0) As [Select], S.DocID as Code,S.V_No as VrNo, S.V_Date As [Date],SG.Name As [Indentor],S.ReferenceNo From Store_PurchIndent S with (NoLock) left Join Subgroup SG With (NoLock) on S.SubCode=SG.SubCode Where  S.V_Type = '" & ClsMain.Temp_NCat.StorePurchaseIndent & "'"

    Dim mHelpGatePassNoQry$ = "Select Convert(BIT,0) As [Select], S.DocID as Code,S.V_No as VrNo, S.V_Date As [Date],S.VehicleNo,S.Manual_RefNo From GateInOut S Where  S.V_Type = '" & ClsMain.Temp_NCat.StoreGatePass & "'"

    'End Change

    'Dim mHelpbatchQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Batchno As Code, Batchno As [Tyre No] From store_Stock Where BatchNo Is Not Null "
#End Region

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName

                Case SaleRegister, SaleSummary
                    StrArr1 = New String() {"Both", "Yes", "No"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Authenticated", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site Name")
                    ObjRFG.CreateHelpGrid(mHelpCustomerQry, "Customer Name")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name")

                Case PurchaseIndentRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpIndentorQry, "Indenter")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")

                Case PurchaseRegister
                    StrArr1 = New String() {"Both", "Yes", "No"}
                    StrArr2 = New String() {"All", "Consumable", "Non Consumable"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Authenticated", StrArr1, , "Nature", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site Name")
                    ObjRFG.CreateHelpGrid(mHelpSupplierQry, "Supplier Name")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name")
                    ObjRFG.CreateHelpGrid(mHelpOrderNoQry, "Order No.")
                    ObjRFG.CreateHelpGrid(mHelpGRNNoQry, "GRN No.")


                Case PurchaseOrderRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpPartyQry$, "Supplier Name")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpIndentNoQry, "Indent No.")

                Case GRNRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpPartyQry$, "Supplier Name")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpOrderNoQry, "Order No.")
                    ObjRFG.CreateHelpGrid(mHelpGatePassNoQry, "Gate Pass No.")

                Case RequisitionRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpIndentorQry, "Requisition By")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")



                Case PurchaseSummary
                    StrArr1 = New String() {"Both", "Yes", "No"}

                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Authenticated", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site Name")
                    ObjRFG.CreateHelpGrid(mHelpSupplierQry, "Supplier Name")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name")
                    ObjRFG.CreateHelpGrid(mHelpOrderNoQry, "Order No.")
                    ObjRFG.CreateHelpGrid(mHelpGRNNoQry, "GRN No.")

                Case FixedAssetsRegister

                    StrArr1 = New String() {"All", "Consumable", "Non Consumable"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Nature", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site Name")
                    ObjRFG.CreateHelpGrid(mHelpSupplierQry, "Supplier Name")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name")

                Case StockRegister, StockSummary


                    StrArr1 = New String() {"All", "Consumable", "Non Consumable"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Nature", StrArr1)


                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site Name")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpbatchQry, "Batch No")

                    'Code by Akash on date 18-9-10
                Case IssueRegister
                    StrArr1 = New String() {"All", "Consumable", "Non Consumable"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Nature", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site Name")
                    ObjRFG.CreateHelpGrid(mHelpPartyQry$, "Party Name")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name[From]")
                    ObjRFG.CreateHelpGrid(mHelpDepartmentQry, "Department Name[Reciever]")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpItemCatagoryQry, "Item Category")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Group")
                    ObjRFG.CreateHelpGrid(mHelpItemNature1Qry, "Nature1")
                    ObjRFG.CreateHelpGrid(mHelpItemNature2Qry, "Nature2")
                    ObjRFG.CreateHelpGrid(mHelpbatchQry, "Batch No")



            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case SaleRegister
                ProcSaleRegister()

            Case PurchaseRegister
                ProcPurchaseRegister()

            Case RequisitionRegister
                ProcRequisitionRegister()

            Case PurchaseIndentRegister
                ProcPurchaseIndentRegister()

            Case PurchaseOrderRegister
                ProcPurchaseOrderRegister()


            Case GRNRegister
                ProcGRNRegister()

            Case SaleSummary
                ProcSaleSummary()

            Case PurchaseSummary
                procPurchaseSummary()

            Case StockRegister
                procStockRegister()

            Case StockSummary
                ProcStockSummary()

            Case IssueRegister
                ProcIssueRegister()
            Case FixedAssetsRegister
                procFixedAssetsRegister()


        End Select
    End Sub

#Region "Purchase Summary"
    Private Sub procPurchaseSummary()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""
            Call ObjRFG.FillGridString()
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            'Code by Akash on date 22-9-10
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NOT NULL"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NULL"
            'End Change 



            If ObjRFG.GetWhereCondition("SS.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SS.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.ACCODE", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Department", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.OrderDocId", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.GRNDocID", 4)

            mCondStr = mCondStr & " And ss.V_Type in (" & AgL.Chk_Text(ClsVar.NCat_StorePurchase) & ")"

            mQry = " SELECT ss.DocId,ss.Div_Code,ss.Site_Code,ss.V_Type AS [Type],ss.V_Prefix,ss.V_No AS [Bill NO]," & _
                   " " & AgL.ConvertDateField("ss.V_Date") & " AS [Bill DATE],ss.AcCode,ss.Amount,ss.Addition AS [Line ADD],ss.Deduction AS [Line Ded],ss.NetAmount AS [Net Amt]," & _
                   " ss.Addition_H AS Addtion,ss.Deduction_H AS [Dedustion],ss.InvoiceAmount, " & _
                   " ss.PreparedBy,ss.U_EntDt AS [Entry DATE],ss.U_AE,ss.Edit_Date,ss.ModifiedBy , " & _
                   " SubGroup.Name AS [Party Name], " & _
                   " SubGroup.Add1 AS Address, SubGroup.Add2 AS address1,'" & ClsVar.PurchaseAddition_Text & "' as LineAddtion_Cap, " & _
                   " '" & ClsVar.PurchaseDeduction_Text & "' as LineDedu_Cap,'" & ClsVar.PurchaseDeduction_H_Text & "' as Deduct_Cap,'" & ClsVar.PurchaseAddition_H_Text & "' as Ad_cap, " & _
                   " S.Name As Site_Name, Ss.Department As DepartmentCode, Dept.Description As DepartmentDesc , Dept.ManualCode As DepartmentManualCode," & AgL.V_No_Field("ss.DocId") & " As purchaseVoucherNo, ss.V_Date " & _
                   " FROM Store_Purchase ss " & _
                   " Left Join SiteMast S On Ss.Site_Code = S.Code " & _
                   " LEFT JOIN SubGroup ON ss.AcCode=SubGroup.SubCode " & _
                   " Left Join Sch_Department Dept On Ss.Department = Dept.Code "


            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_PurchaseSummary" : RepTitle = "Purchase Summary"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stock Register"
    Private Sub procStockRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = "", mCondStr1$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            If ObjRFG.GetWhereCondition("Ss.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Ss.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.DepartmentCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ss.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ss.BatchNo", 3)


            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Consumable'"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Non Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Non Consumable'"

            mCondStr1 = mCondStr

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr1 = mCondStr1 & " And SS.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & "  "

            mCondStr = mCondStr & " And SS.V_Type in (" & AgL.Chk_Text(ClsMain.Temp_NCat.StoreGRN) & "," & AgL.Chk_Text(ClsVar.NCat_StorePurchase) & "," & AgL.Chk_Text(ClsVar.NCat_StoreSale) & "," & AgL.Chk_Text(ClsVar.NCat_StoreIssue) & "," & AgL.Chk_Text(ClsVar.NCat_StoreReceive) & "," & AgL.Chk_Text(ClsVar.NCat_StoreOpening) & "," & AgL.Chk_Text(ClsVar.NCat_StoreIssueReceive) & ")"



            mQry = " SELECT " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " as V_Date,'Opening' as v_type,0 as V_No,case when sum(ss.Qty_Rec)-sum(ss.Qty_Iss)> 0 then 0 else sum(ss.Qty_Rec)-sum(ss.Qty_Iss) end as Qty_Iss,case when sum(ss.Qty_Rec)-sum(ss.Qty_Iss)< 0 then 0 else sum(ss.Qty_Rec)-sum(ss.Qty_Iss) end as Qty_Rec,Si.Description AS ItemName,ss.batchno as BatchNo, " & _
                  " Ss.Site_Name, ss.DepartmentCode, Max(Ss.DepartmentDesc) As DepartmentDesc , Max(Ss.DepartmentManualCode) As DepartmentManualCode, " & _
                  " " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " AS [VDate_Formated], 'Opening' As StockVoucherNo, '" & ClsVar.Item_Batch_Description & "' as Item_Batch_Description, 0 As RowId,max(store_unit.Manualcode) as Unit " & _
                  " FROM ViewStore_Stock SS " & _
                  " LEFT JOIN Store_Item Si ON ss.Item=Si.Code left join store_unit on si.Unit=store_unit.code " & _
                  " Where 1=1  " & mCondStr1 & " " & _
                  " Group By Ss.Site_Name, Ss.DepartmentCode, Si.Description, ss.batchno "

            mQry = mQry & " union all " & _
                   " SELECT SS.V_Date,SS.v_type,ss.V_No,ss.Qty_Iss,ss.Qty_Rec,Si.Description AS ItemName,ss.batchno as Batchno, " & _
                   " Ss.Site_Name, Ss.DepartmentCode, Ss.DepartmentDesc , SS.DepartmentManualCode, " & _
                   " " & AgL.ConvertDateField("ss.V_Date") & " AS [VDate_Formated]," & AgL.V_No_Field("ss.DocId") & " As StockVoucherNo,  '" & ClsVar.Item_Batch_Description & "' as Item_Batch_Description, ss.RowId,store_unit.Manualcode as Unit " & _
                   " FROM ViewStore_Stock SS " & _
                   " LEFT JOIN Store_Item Si ON ss.Item=Si.Code left join store_unit on si.Unit=store_unit.code " & _
                   " Where 1=1  " & mCondStr


            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_NewItemStockRegister" : RepTitle = "Stock Register"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stock Summary"
    Private Sub ProcStockSummary()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = "", mCondStr1$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "

            If ObjRFG.GetWhereCondition("SS.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SS.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Site_Code", 0)
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Consumable'"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Non Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Non Consumable'"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.DepartmentCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ss.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ss.BatchNo", 3)

            mCondStr = mCondStr

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr1 = mCondStr1 & " And SS.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & "  "
            mCondStr = mCondStr & " And SS.V_Type in (" & AgL.Chk_Text(ClsMain.Temp_NCat.StoreGRN) & "," & AgL.Chk_Text(ClsVar.NCat_StorePurchase) & "," & AgL.Chk_Text(ClsVar.NCat_StoreSale) & "," & AgL.Chk_Text(ClsVar.NCat_StoreIssue) & "," & AgL.Chk_Text(ClsVar.NCat_StoreReceive) & "," & AgL.Chk_Text(ClsVar.NCat_StoreOpening) & "," & AgL.Chk_Text(ClsVar.NCat_StoreIssueReceive) & ")"


            mQry = " SELECT sum(ss.Qty_Rec)-sum(ss.Qty_Iss)as Opening ,0 as Qty_Iss,0 as Qty_Rec,Si.Description AS ItemName,ss.batchno as BatchNo, " & _
                   " Ss.Site_Name, ss.DepartmentCode, Max(Ss.DepartmentDesc) As DepartmentDesc , Max(Ss.DepartmentManualCode) As DepartmentManualCode, " & _
                   " '" & ClsVar.Item_Batch_Description & "' as Item_Batch_Description,max(store_unit.Manualcode) as Unit  " & _
                   " FROM ViewStore_Stock SS  " & _
                   " LEFT JOIN Store_Item Si ON ss.Item=Si.Code left join store_unit on si.Unit=store_unit.code" & _
                   " Where 1=1 " & mCondStr1 & " " & _
                   " Group By Ss.Site_Name, Ss.DepartmentCode, Si.Description, ss.batchno "

            mQry = mQry & "union all " & _
                    " SELECT 0 as Opening,sum(ss.Qty_Iss) as Qty_iss,sum(ss.Qty_Rec) as Qty_rec,Si.Description AS ItemName,ss.batchno as BatchNo, " & _
                    " Ss.Site_Name, ss.DepartmentCode, Max(Ss.DepartmentDesc) As DepartmentDesc , Max(Ss.DepartmentManualCode) As DepartmentManualCode, " & _
                    " '" & ClsVar.Item_Batch_Description & "' as Item_Batch_Description,max(store_unit.Manualcode) as Unit  " & _
                    " FROM ViewStore_Stock SS " & _
                    " LEFT JOIN Store_Item Si ON ss.Item=Si.Code left join store_unit on si.Unit=store_unit.code" & _
                    " Where 1=1  " & mCondStr & " " & _
                    " Group By Ss.Site_Name, Ss.DepartmentCode, Si.Description, ss.batchno "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_NewItemStockSummary" : RepTitle = "Stock Summary"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Fixed Assets Register"
    Private Sub procFixedAssetsRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()
            Dim mYearString As String
            mYearString = DatePart("yyyy", AgL.PubStartDate) & "-" & DatePart("yyyy", AgL.PubEndDate)


            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            'Code by Akash on date 22-9-10
            'End Change 


            If ObjRFG.GetWhereCondition("Ss.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Ss.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Site_Code", 0)
            End If



            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Consumable'"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Non Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Non Consumable'"


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Department", 2)
            mCondStr = mCondStr & " And ss.V_Type in (" & AgL.Chk_Text(ClsVar.NCat_StorePurchase) & ")"



            mQry = " SELECT ss.DocId,ss.Div_Code,ss.Site_Code,ss.V_Type AS [Type],ss.V_Prefix,ss.V_No AS [Bill NO]," & _
                   " " & AgL.ConvertDateField("ss.V_Date") & " AS [Bill DATE],ss.AcCode,ss.Amount,ss.Addition AS [Line ADD],ss.Deduction AS [Line Ded],ss.NetAmount AS [Net Amt]," & _
                   " ss.Addition_H AS Addtion,ss.Deduction_H AS [Dedustion],ss.InvoiceAmount, " & _
                   " ss.PreparedBy,ss.U_EntDt AS [Entry DATE],ss.U_AE,ss.Edit_Date,ss.ModifiedBy , " & _
                   " Si.Description as Item, v.mstock as  Qty,sst.Rate,v.mstock *sst.rate ItemAmount,sst.BatchNo,SubGroup.Name AS [Party Name], " & _
                   " SubGroup.Add1 AS Address, SubGroup.Add2 AS address1,'" & ClsVar.PurchaseAddition_Text & "' as LineAddtion_Cap, " & _
                   " '" & ClsVar.PurchaseDeduction_Text & "' as LineDedu_Cap,'" & ClsVar.PurchaseDeduction_H_Text & "' as Deduct_Cap,'" & ClsVar.PurchaseAddition_H_Text & "' as Ad_cap ," & _
                   " S.Name As Site_Name, Ss.Department As DepartmentCode, Sst.DepartmentDesc , Sst.DepartmentManualCode," & AgL.V_No_Field("ss.DocId") & " As purchaseVoucherNo, ss.V_Date,'" & mYearString & "' as myear " & _
                   " FROM Store_Purchase ss " & _
                   " Left Join SiteMast S On Ss.Site_Code = S.Code " & _
                   " LEFT JOIN SubGroup ON ss.AcCode=SubGroup.SubCode " & _
                   " LEFT JOIN ViewStore_Stock SSt ON ss.DocId=sst.DocId " & _
                   " left join (SELECT sum(isnull(qty_rec,0))-sum(isnull(qty_iss,0)) AS mstock,batchno FROM Store_Stock GROUP BY BatchNo) v ON sst.batchno=v.batchno " & _
                   " LEFT JOIN Store_Item Si ON sst.Item=Si.Code "



            mQry = mQry & " Where 1=1 and sst.qty_rec>0 and v.mstock>0" & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_AssetsRegister" : RepTitle = "Fixed Assets Register"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Purchase Register"
    Private Sub ProcPurchaseRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            'Code by Akash on date 22-9-10
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NOT NULL"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NULL"
            'End Change 


            If ObjRFG.GetWhereCondition("Ss.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Ss.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Site_Code", 0)
            End If


            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Consumable'"
            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Non Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Non Consumable'"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Department", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.OrderDocId", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.GRNDocID", 4)

            mCondStr = mCondStr & " And ss.V_Type in (" & AgL.Chk_Text(ClsVar.NCat_StorePurchase) & ")"

            mQry = " SELECT ss.DocId,ss.Div_Code,ss.Site_Code,ss.V_Type AS [Type],ss.V_Prefix,ss.V_No AS [Bill NO]," & _
                   " " & AgL.ConvertDateField("ss.V_Date") & " AS [Bill DATE],ss.AcCode,ss.Amount,ss.Addition AS [Line ADD],ss.Deduction AS [Line Ded],ss.NetAmount AS [Net Amt]," & _
                   " ss.Addition_H AS Addtion,ss.Deduction_H AS [Dedustion],ss.InvoiceAmount, " & _
                   " ss.PreparedBy,ss.U_EntDt AS [Entry DATE],ss.U_AE,ss.Edit_Date,ss.ModifiedBy , " & _
                   " Si.Description as Item, sst.Qty_Rec as Qty,sst.Rate,sst.Amount as ItemAmount,sst.BatchNo,SubGroup.Name AS [Party Name], " & _
                   " SubGroup.Add1 AS Address, SubGroup.Add2 AS address1,'" & ClsVar.PurchaseAddition_Text & "' as LineAddtion_Cap, " & _
                   " '" & ClsVar.PurchaseDeduction_Text & "' as LineDedu_Cap,'" & ClsVar.PurchaseDeduction_H_Text & "' as Deduct_Cap,'" & ClsVar.PurchaseAddition_H_Text & "' as Ad_cap ," & _
                   " S.Name As Site_Name, Ss.Department As DepartmentCode, Sst.DepartmentDesc , Sst.DepartmentManualCode," & AgL.V_No_Field("ss.DocId") & " As purchaseVoucherNo, ss.V_Date " & _
                   " FROM Store_Purchase ss " & _
                   " Left Join SiteMast S On Ss.Site_Code = S.Code " & _
                   " LEFT JOIN SubGroup ON ss.AcCode=SubGroup.SubCode " & _
                   " LEFT JOIN ViewStore_Stock SSt ON ss.DocId=sst.DocId " & _
                   " LEFT JOIN Store_Item Si ON sst.Item=Si.Code "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_PurchaseRegister" : RepTitle = "Purchase Register"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Requisition Register"
    Private Sub ProcRequisitionRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And R.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("R.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.SubCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.Department", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.ItemGroup", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R1.Item", 4)
            mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.Requistion) & ")"

            mQry = " SELECT  R.DocID, R.V_Type, R.V_Prefix, R.V_Date, R.V_No, R.Div_Code, R.Site_Code, " & _
                    " R.Department, SG.DispName AS RequisitionBy, R1.Remark, R.TotalQty, " & _
                    " R1.Sr, R1.Item, R1.Qty, R1.Unit,R1.ItemDescription, " & _
                    " R1.RequireDate, R1.UID,  " & _
                    " SM.Name AS SiteName,I.Description AS ItemName, D.Description as DepName,R.ReferenceNo " & _
                    " FROM Store_Requisition R " & _
                    " LEFT JOIN Store_RequisitionDetail R1 ON R1.DocID =R.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=R.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=R1.Item  " & _
                    " LEFT JOIN SUBGROUP SG ON SG.SubCode=R.Subcode   " & _
                    " LEFT JOIN Sch_Department D ON R.Department=D.code   " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=R.V_Type  "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Store_RequisitionRegisterSummary" : RepTitle = "Requisition Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Store_RequisitionRegister" : RepTitle = "Requisition Register"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


#Region "Purchase Indent Register"
    Private Sub ProcPurchaseIndentRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And P.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("P.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.SubCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.ItemGroup", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P1.Item", 3)

            mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.StorePurchaseIndent) & ")"

            mQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
                    " P.subcode, P1.Remark, P.TotalQty,P.ReferenceNo,P.Remark as Remarkheader, " & _
                    " P1.Sr, P1.Item,  P1.RequireQty, P1.IndentQty, P1.Unit, " & _
                    " P1.RequireDate,SM.Name AS SiteName,  " & _
                    " I.Description AS ItemName,Sg.Name AS Indentor,P1.ItemDescription " & _
                    " FROM Store_PurchIndent P " & _
                    " LEFT JOIN Store_PurchIndentDetail P1 ON P1.DocID =P.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=P1.Item " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=P.Subcode " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type  "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Store_PurchaseIndentRegisterSummary" : RepTitle = "Purchase Indent Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Store_PurchaseIndentRegister" : RepTitle = "Purchase Indent Register"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


#Region "Purchase Order Register"
    Private Sub ProcPurchaseOrderRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And P.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("P.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.SubCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.ItemGroup", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P1.Item", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.PurchIndentDocID", 4)

            mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.StorePurchaseOrder) & ")"

            mQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
                    " P.Remark AS RemarkHeader,  P.ReferenceNo,P.TotalAmount,P.TotalQty, " & _
                    " P.subcode, P1.Remark, P1.Sr,P1.Item, Qty,P1.Rate,P1.Amount, " & _
                    " P1.Unit,  SM.Name AS SiteName,(ID.V_Type + '-' +convert(NVARCHAR(5),ID.V_No)) AS [Indent No],     " & _
                    " I.Description AS ItemName,Sg.Name AS Supplier,P1.ItemDescription " & _
                    " FROM Store_PurchOrder P " & _
                    " LEFT JOIN Store_PurchOrderDetail P1 ON P1.DocID =P.DocID " & _
                    " LEFT JOIN Store_PurchIndent ID ON ID.DocID =P.PurchIndentDocId   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=P1.Item " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=P.Subcode " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type  "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Store_PurchaseOrderRegisterSummary" : RepTitle = "Purchase Order Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Store_PurchaseOrderRegister" : RepTitle = "Purchase Order Register"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "GRN Register"
    Private Sub ProcGRNRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And P.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("P.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.ItemGroup", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P1.Item", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.PurchOrderDocID", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.GatePassDocID", 5)

            mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.StoreGRN) & ")"

            mQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code,   " & _
                    " P.Remark AS RemarkHeader,  P.ReferenceNo,P.DocumentNo,P.DocumentDate,P.SalesTaxGroupParty, " & _
                    " P.Amount,P.NetAmount,P.NetSubTotal,P.RoundOff,P.InvoiceAmount,P.TotalQty,  P.ACcode,  " & _
                    " P1.Remark, P1.Sr,P1.Item, Qty,P1.Rate,P1.Amount AS LineAmount,  P1.Unit,P1.BatchNo,P1.DocQty,  " & _
                    " P1.NetAmount AS LineNetAmount,P1.LandedAmount,SM.Name AS SiteName,G.Description AS Godown,(ID.V_Type + '-' +convert(NVARCHAR(5),ID.V_No)) AS [Order No],I.Description AS ItemName,Sg.Name AS Supplier,P1.ItemDescription , " & _
                    " SF.*,SL.*,Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, City.CityName, Sg.Phone, Sg.Mobile  " & _
                    " FROM Store_GRN P " & _
                    " LEFT JOIN Store_GrnDetail P1 ON P1.DocID =P.DocID " & _
                    " LEFT JOIN Store_PurchOrder ID ON ID.DocID =P.PurchOrderDocId   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=P1.Item " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=P.Accode " & _
                    " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                    " LEFT JOIN Store_Godown G WITH (NoLock) ON P1.Godown=G.Code " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.StoreGRN) & ") As SF On P.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.StoreGRN) & ") As SL On P1.DocId = SL.DocId And P1.Sr = Sl.TSr "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Store_GRNRegisterSummary" : RepTitle = "GRN Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Store_GRNRegister" : RepTitle = "GRN Register"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale summary"
    Private Sub ProcSaleSummary()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            'Code by Akash on date 22-9-10
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NOT NULL"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NULL"
            'End Change 


            If ObjRFG.GetWhereCondition("Ss.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Ss.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.ACCODE", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Department", 2)
            mCondStr = mCondStr & " And ss.V_Type in (" & AgL.Chk_Text(ClsVar.NCat_StoreSale) & ")"


            mQry = " SELECT ss.DocId,ss.Div_Code,ss.Site_Code,ss.V_Type AS [Type],ss.V_Prefix,ss.V_No AS [Bill NO]," & _
                   " " & AgL.ConvertDateField("ss.V_Date") & " AS [Bill DATE],ss.AcCode,ss.Amount,ss.Addition AS [Line ADD],ss.Deduction AS [Line Ded],ss.NetAmount AS [Net Amt]," & _
                   " ss.Addition_H AS Addtion,ss.Deduction_H AS [Dedustion],ss.InvoiceAmount, " & _
                   " ss.PreparedBy,ss.U_EntDt AS [Entry DATE],ss.U_AE,ss.Edit_Date,ss.ModifiedBy , " & _
                   " SubGroup.Name AS [Party Name], " & _
                   " SubGroup.Add1 AS Address, SubGroup.Add2 AS address1,'" & ClsVar.SaleAddition_Text & "' as LineAddtion_Cap, " & _
                   " '" & ClsVar.SaleDeduction_Text & "' as LineDedu_Cap,'" & ClsVar.SaleAddition_H_Text & "' as Deduct_Cap,'" & ClsVar.SaleAddition_H_Text & "' as Ad_cap, " & _
                   " S.Name As Site_Name, Ss.Department As DepartmentCode, Dept.Description As DepartmentDesc , Dept.ManualCode As DepartmentManualCode, " & AgL.V_No_Field("ss.DocId") & " As SaleVoucherNo, ss.V_Date " & _
                   " FROM Store_Sale ss " & _
                   " Left Join SiteMast S On Ss.Site_Code = S.Code " & _
                   " LEFT JOIN SubGroup ON ss.AcCode=SubGroup.SubCode " & _
                   " Left Join Sch_Department Dept On Ss.Department = Dept.Code "

            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            RepName = "Store_SaleSummary" : RepTitle = "Sale Summary"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale Register"
    Private Sub ProcSaleRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            'Code by Akash on date 22-9-10
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NOT NULL"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then mCondStr = mCondStr & "AND ss.ApprovedDate IS NULL"
            'End Change 


            If ObjRFG.GetWhereCondition("Ss.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Ss.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Department", 2)
            mCondStr = mCondStr & " And ss.V_Type in (" & AgL.Chk_Text(ClsVar.NCat_StoreSale) & ")"

            mQry = " SELECT ss.DocId,ss.Div_Code,ss.Site_Code,ss.V_Type AS [Type],ss.V_Prefix,ss.V_No AS [Bill NO]," & _
                   " " & AgL.ConvertDateField("ss.V_Date") & " AS [Bill DATE],ss.AcCode,ss.Amount,ss.Addition AS [Line ADD],ss.Deduction AS [Line Ded],ss.NetAmount AS [Net Amt]," & _
                   " ss.Addition_H AS Addtion,ss.Deduction_H AS [Dedustion],ss.InvoiceAmount, " & _
                   " ss.PreparedBy,ss.U_EntDt AS [Entry DATE],ss.U_AE,ss.Edit_Date,ss.ModifiedBy , " & _
                   " Si.Description as Item, sst.Qty_Iss as Qty,sst.Rate,sst.Amount as ItemAmount,sst.BatchNo,SubGroup.Name AS [Party Name], " & _
                   " SubGroup.Add1 AS Address, SubGroup.Add2 AS address1,'" & ClsVar.SaleAddition_Text & "' as LineAddtion_Cap, " & _
                   " '" & ClsVar.SaleDeduction_Text & "' as LineDedu_Cap,'" & ClsVar.SaleAddition_H_Text & "' as Deduct_Cap,'" & ClsVar.SaleAddition_H_Text & "' as Ad_cap, " & _
                   " S.Name As Site_Name, Ss.Department As DepartmentCode, Sst.DepartmentDesc , Sst.DepartmentManualCode, " & AgL.V_No_Field("ss.DocId") & " As SaleVoucherNo, ss.V_Date " & _
                   " FROM Store_Sale ss " & _
                   " Left Join SiteMast S On Ss.Site_Code = S.Code " & _
                   " LEFT JOIN SubGroup ON ss.AcCode=SubGroup.SubCode " & _
                   " LEFT JOIN ViewStore_Stock SSt ON ss.DocId=sst.DocId " & _
                   " LEFT JOIN Store_Item Si ON sst.Item=Si.Code "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_SaleRegister" : RepTitle = "Sale Register"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


    'Code by Akash on date 18-9-10
#Region "Issue Register"
    Private Sub ProcIssueRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Bill Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "

            mCondStr = mCondStr & " And SS.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            If ObjRFG.GetWhereCondition("Ss.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Ss.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Site_Code", 0)
            End If


            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Consumable'"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Non Consumable") Then mCondStr = mCondStr & "AND Si.Nature ='Non Consumable'"


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Department", 2)

            mCondStr = mCondStr & ObjRFG.FillMainStreamCode(3, 3, "sd.MainStreamCode")

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sst.Item", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sst.ItemCategoryCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sst.ItemGroupCode", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sn1.Description", 7)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sn2.Description", 8)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sst.BatchNo", 9)
            mCondStr = mCondStr & " And ss.V_Type in (" & AgL.Chk_Text(ClsVar.NCat_StoreIssue) & ")"



            mQry = "SELECT sst.DocId,sst.Div_Code,sst.Site_Code,sst.V_Type,sst.V_Prefix,sst.V_No,   " & _
                    "Replace(Convert(VARCHAR,sst.V_Date,106),' ','/') AS [Bill DATE],sst.Item,sst.Item_Nature1,sst.Item_Nature2,sst.BatchNo,sst.IssueReceive,   " & _
                    "sst.Qty_Iss,sst.Rate,sst.Amount,sst.Addition,sst.Deduction,sst.NetAmount,   " & _
                    "sst.Addition_H,sst.Deduction_H,sst.LandedAmount,sst.Remark,sst.RowId,sst.UpLoadDate,   " & _
                    "sst.Godown,sst.Div_Name,sst.Site_Name,sst.GodownDesc,sst.GodownManualCode,   " & _
                    "sst.StockAdjustmentDocId,sst.DepartmentCode,sst.DepartmentDesc,sst.DepartmentManualCode,   " & _
                    "sst.PartyCode,sst.PartyName,sst.PartyDispName,sst.PartyManualCode,sst.PartyNature,   " & _
                    "sst.PartyGroupCode,sst.PartyGroupName,sst.PartyAdd1,sst.PartyAdd2,sst.PartyAdd3,  " & _
                    "sst.CityCode,sst.CityName,sst.District,sst.StateName,sst.StateShortName,sst.Country,   " & _
                    "sst.PIN,sst.VoucherTypeDesc,sst.NCat,sst.ItemDesc,sst.ItemManualCode,sst.UnitDesc,   " & _
                    "sst.ItemGroupCode,sst.ItemGroupDesc,sst.ItemCategoryManualCode,sd.Description AS [Department2],  " & _
                    "Convert(nVarChar, Convert(Numeric, Right(ss.DocId, 8))) +    " & _
                    "'/' + RTrim(LTrim(SubString(ss.DocId, 9, 5))) + '/' +   " & _
                    "RTrim(LTrim(SubString(ss.DocId, 4, 5))) + '/' +   " & _
                    "RTrim(LTrim(SubString(ss.DocId, 2, 2))) + '/' + Left(ss.DocId, 1)    " & _
                    "As IssueVoucherNo,sn1.Description,sn2.Description  FROM Store_StockAdjustment ss    " & _
                    "LEFT JOIN ViewStore_Stock sst ON ss.DocId=sst.DocId left join store_item si on sst.item=si.code  " & _
                    "LEFT JOIN Sch_Department sd ON ss.Department2=sd.Code  " & _
                    "LEFT JOIN Store_Item_Nature1 sn1 ON sst.Item_Nature1=sn1.Code  " & _
                    "LEFT JOIN Store_Item_Nature2 sn2 ON sst.Item_Nature2=sn2.Code  "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "Store_IssueRegister" : RepTitle = "Issue Register"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Store)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region



End Class
