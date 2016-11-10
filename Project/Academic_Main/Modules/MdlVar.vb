Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed    
    Public StrPath As String = Academic_Main.My.Application.Info.DirectoryPath & "\"
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
    Public PubRegistrationStatusStr$ = "" & Academic_ProjLib.ClsMain.RegistrationStatus_Registered & "," & Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedByManagement & "," & Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedBySeeUptu & "," & Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedByManagement & "," & Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedBySeeUptu & ""
End Module
