Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed    
    Public StrPath As String = My.Application.Info.DirectoryPath + "\"
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
    Public DtHt_Enviro As DataTable = Nothing

    ''============< Allotment Type Constants >==================================
    Public Const AllotmentType_Allotment As String = "Allotment"
    Public Const AllotmentType_Transfer As String = "Transfer"
    ''============< *************** >==================================h

    ''============< Charge Nature Constants >==================================
    Public Const ChargeNature_Security As String = "Security"
    Public Const ChargeNature_Fine As String = "Fine"
    Public Const ChargeNature_Charge As String = "Charge"

    Public PubChargeNatureStr$ = "" & ChargeNature_Charge & "," & ChargeNature_Fine & "," & ChargeNature_Security & ""
    ''============< *************** >==================================

    '***********Code By Akash on date 27-10-10
    Public Structure Struct_ChargeDue
        Public DocId As String
        Public Div_Code As String
        Public Site_Code As String
        Public V_Date As String
        Public V_Type As String
        Public V_Prefix As String
        Public V_No As Long
        Public MonthStartDate As String
        Public TotalAmount As Double
        Public Remark As String
        Public PreparedBy As String
        Public U_EntDt As String
        Public U_AE As String
        Public Edit_Date As String
        Public ModifiedBy As String
       
        Public Sub Struct_ChargeDue()
            DocId = ""
            Div_Code = ""
            Site_Code = ""
            V_Date = ""
            V_Type = ""
            V_Prefix = ""
            V_No = 0
            MonthStartDate = ""
            TotalAmount = 0
            Remark = ""
            PreparedBy = ""
            U_EntDt = ""
            U_AE = ""
            Edit_Date = ""
            ModifiedBy = ""
        End Sub
    End Structure

    Public Structure Struct_ChargeDue1
        Public Code As String
        Public DocId As String
        Public AllotmentDocId As String
        Public Charge As String
        Public Amount As Double

        Public Sub Struct_ChargeDue1()
            Code = ""
            DocId = ""
            AllotmentDocId = ""
            Charge = ""
            Amount = 0
        End Sub
    End Structure
End Module
