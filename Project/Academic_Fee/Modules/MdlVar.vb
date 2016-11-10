Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed    
    Public StrPath As String = Academic_Fee.My.Application.Info.DirectoryPath & "\"
    Public IniName As String = "Academic.ini"
    Public StrDBPasswordSQL As String = ""
    Public StrDBPasswordAccess As String = "jai"
    Public AgL As AgLibrary.ClsMain
    Public AgCL As New AgControls.AgLib()
    Public AgPL As AgLibrary.ClsPrinting
    Public PLib As Academic_ProjLib.ClsMain
    Public AgIniVar As AgLibrary.ClsIniVariables
    Public PObj As Academic_Objects.ClsMain

    Public DtCommon_Enviro As DataTable = Nothing
    Public DtSch_Enviro As DataTable = Nothing

    Public PubAdmissionStatusStr$ = "" & Academic_ProjLib.ClsMain.AdmissionStatus_Regular & "," & Academic_ProjLib.ClsMain.AdmissionStatus_ReAdmit & "," & Academic_ProjLib.ClsMain.AdmissionStatus_Ex & ""


    Public Structure Struct_FeeReceive
        Public DocId As String
        Public Div_Code As String
        Public Site_Code As String
        Public V_Date As String
        Public V_Type As String
        Public V_Prefix As String
        Public V_No As Long
        Public TotalLineAmount As Double
        Public TotalLineDiscount As Double
        Public TotalLineNetAmount As Double
        Public Advance As Double
        Public SubTotal1 As Double
        Public AdjustmentAmount As Double
        Public SubTotal2 As Double
        Public DiscountPer As Double
        Public DiscountAmount As Double
        Public TotalNetAmount As Double
        Public Remark As String
        Public PreparedBy As String
        Public U_EntDt As String
        Public U_AE As String
        Public Edit_Date As String
        Public ModifiedBy As String
        Public IsManageFee As String
        Public ReceiveAmount As Double
        Public AdvanceCarriedForward As Double
        Public AdmissionDocId As String
        Public TotalAdvanceAdjusted As String
        Public IsAdjustableReceipt As String
        Public TotalFeeReceiveAdjusted As String
        Public FeeAdjustmentAc As String
        Public FeeReceiptAdjustmentAc As String
        Public SubCode As String
        Public ScholarShipAmount As Double

        Public Sub Struct_FeeReceive()
            DocId = ""
            Div_Code = ""
            Site_Code = ""
            V_Date = ""
            V_Type = ""
            V_Prefix = ""
            V_No = ""
            TotalLineAmount = 0
            TotalLineDiscount = 0
            TotalLineNetAmount = 0
            Advance = 0
            SubTotal1 = 0
            AdjustmentAmount = 0
            SubTotal2 = 0
            DiscountPer = 0
            DiscountAmount = 0
            TotalNetAmount = 0
            Remark = ""
            PreparedBy = ""
            U_EntDt = ""
            U_AE = ""
            Edit_Date = ""
            ModifiedBy = ""
            IsManageFee = ""
            ReceiveAmount = 0
            AdvanceCarriedForward = 0
            AdmissionDocId = ""
            TotalAdvanceAdjusted = 0
            IsAdjustableReceipt = 0
            TotalFeeReceiveAdjusted = 0
            FeeAdjustmentAc = ""
            FeeReceiptAdjustmentAc = ""
            SubCode = ""
            ScholarShipAmount = 0
        End Sub
    End Structure

    Public Structure Struct_FeeReceive1
        Public Code As String
        Public DocId As String
        Public FeeDue1 As String
        Public Amount As Double
        Public Discount As Double
        Public NetAmount As Double

        Public Sub Struct_FeeReceive1()
            Code = ""
            DocId = ""
            FeeDue1 = ""
            Amount = 0
            Discount = 0
            NetAmount = 0
        End Sub
    End Structure
End Module
