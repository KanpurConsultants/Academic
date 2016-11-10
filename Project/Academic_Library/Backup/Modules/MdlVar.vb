Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed    
    Public StrPath As String = My.Application.Info.DirectoryPath + "\" '+ "D:\Active Projects\RUG CARE\Release\"
    Public IniName As String = "RugCare.ini"
    Public StrDBPasswordSQL As String = ""
    Public StrDBPasswordAccess As String = "jai"
    Public AgL As AgLibrary.ClsMain
    Public AgCL As New AgControls.AgLib()
    Public AgPL As AgLibrary.ClsPrinting
    Public ObjAgTemplate As AgTemplate.ClsMain
    Public ObjAgTemplate_Common As AgTemplate_Common.ClsMain
    Public ObjAgTemplate_Sale As AgTemplate_Sale.ClsMain
    Public ObjAgTemplate_Production As AgTemplate_Production.ClsMain
    Public AgIniVar As AgLibrary.ClsIniVariables


    Public DtCommon_Enviro As DataTable = Nothing
    Public DtRug_Enviro As DataTable = Nothing


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
