Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed
    Public StrPath As String = Library_Login.My.Application.Info.DirectoryPath
    Public IniName As String = "Academic.ini"
    Public StrDBPasswordSQL As String = ""
    Public StrDBPasswordAccess As String = "jai"
    Public AgL As AgLibrary.ClsMain
    Public StrModuleName As String = "Login"
    Public PLib As Academic_ProjLib.ClsMain
    Public AgPL As AgLibrary.ClsPrinting
    Public AgIniVar As AgLibrary.ClsIniVariables
    Public AgCL As New AgControls.AgLib()

    Public BaseTableList = "'Company', 'Division', 'UserMast', 'Login_Log', 'User_Permission', 'User_Control_Permission'"

    Public mCommon_Master As String = AgLibrary.ClsConstant.Module_Common_Master
    Public mFinancial_Accounts As String = AgLibrary.ClsConstant.Module_Financial_Accounts
    Public mUtility As String = AgLibrary.ClsConstant.Module_Utility
End Module
