Module MdlVar
    Public StrDocID As String       'Holds DocId Or Key Field On Save And Is Free After Save Is Executed    
    Public StrPath As String = Academic_Exam.My.Application.Info.DirectoryPath + "\"
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

    ''============< Exam Nature Constants >=============================
    Public Const ExamNature_Exam As String = "Exam"
    Public Const ExamNature_Test As String = "Test"
    Public Const ExamNature_Assignment As String = "Assignment"
    '-============< *************** >==================================
    Public PubExamNatureStr As String = "" & ExamNature_Exam & "," & ExamNature_Test & "," & ExamNature_Assignment & ""

    ''============< Result Constants >==================================
    Public Const ResultStr_Pass As String = "Pass"
    Public Const ResultStr_Fail As String = "Fail"
    Public Const ResultStr_PassWithGrace As String = "Pass With Grace"
    ''============< *************** >==================================




    Public Structure Struct_FeeDue
        Public DocId As String
        Public Div_Code As String
        Public Site_Code As String
        Public V_Date As String
        Public V_Type As String
        Public V_Prefix As String
        Public V_No As Long
        Public StreamYearSemester As String
        Public StreamYearSemesterDesc As String
        Public TotalAmount As Double
        Public Remark As String
        Public PreparedBy As String
        Public U_EntDt As String
        Public U_AE As String
        Public Edit_Date As String
        Public ModifiedBy As String
        Public UpLoadDate As String
        Public RowId As Long

        Public Sub FeeDue()
            DocId = ""
            Div_Code = ""
            Site_Code = ""
            V_Date = ""
            V_Type = ""
            V_Prefix = ""
            V_No = 0
            StreamYearSemester = ""
            StreamYearSemesterDesc = ""
            TotalAmount = 0
            Remark = ""
            PreparedBy = ""
            U_EntDt = ""
            U_AE = ""
            Edit_Date = ""
            ModifiedBy = ""
            UpLoadDate = ""
            RowId = 0
        End Sub
    End Structure

    Public Structure Struct_FeeDue1
        Public Code As String
        Public DocId As String
        Public Fee As String
        Public Amount As Double
        Public AdmissionDocId As String
        Public UpLoadDate As String
        Public RowId As Long

        Public Sub FeeDue1()
            Code = ""
            DocId = ""
            Fee = ""
            Amount = 0
            AdmissionDocId = ""
            UpLoadDate = ""
            RowId = 0
        End Sub
    End Structure

End Module
