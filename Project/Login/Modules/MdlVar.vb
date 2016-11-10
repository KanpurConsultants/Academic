Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed
    Public StrPath As String = Vidya.My.Application.Info.DirectoryPath
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

    Public mScholar_Main As String = Scholar_Main.ClsMain.ModuleName
    Public mScholar_TimeTable As String = Scholar_TimeTable.ClsMain.ModuleName
    Public mAcademic_Exam As String = Scholar_Exam.ClsMain.ModuleName
    Public mAcademic_Store As String = Scholar_Store.ClsMain.ModuleName
    Public mScholar_Hostel As String = Academic_Hostel.ClsMain.ModuleName



End Module
