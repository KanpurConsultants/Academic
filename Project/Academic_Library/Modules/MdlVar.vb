Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed    
    Public StrPath As String = My.Application.Info.DirectoryPath + "\" '+ "D:\Active Projects\RUG CARE\Release\"
    Public IniName As String = "Academic.ini"
    Public StrDBPasswordSQL As String = ""
    Public StrDBPasswordAccess As String = "jai"
    Public AgL As AgLibrary.ClsMain
    Public AgCL As New AgControls.AgLib()
    Public AgPL As AgLibrary.ClsPrinting
    Public ObjAgTemplate As AgTemplate.ClsMain
    Public ObjAgStructure As AgStructure.ClsMain
    Public ObjCommon_Master As Common_Master.ClsMain
    Public AgIniVar As AgLibrary.ClsIniVariables

    Public DtCommon_Enviro As DataTable = Nothing
    Public DtLib_Enviro As DataTable = Nothing


    Public Enum StockFormType
        Opening = 0
        Transfer_Issue = 1
        Transfer_Receive = 2
    End Enum

    Public Enum StockTransferType
        Transfer_Issue = 0
        Transfer_Receive = 1
    End Enum
End Module
