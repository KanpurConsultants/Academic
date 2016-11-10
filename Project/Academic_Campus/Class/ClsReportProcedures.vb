Public Class ClsReportProcedures
    Public ObjClsMain As New ClsMain(AgL)

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

#Region "Common Reports Constant"
    Private Const CityList As String = "CityList"
    Private Const UserWiseEntryReport As String = "UserWiseEntryReport"
    Private Const UserWiseEntryTargetReport As String = "UserWiseEntryTargetReport"
#End Region

#Region "Reports Constant"
    Private Const StudentSelectedList As String = "StudentSelectedList"
    Private Const SessionWiseStudentSelectedList As String = "SessionWiseStudentSelectedList"
    Private Const CompanyWiseStudentSelectedList As String = "CompanyWiseStudentSelectedList"
    Private Const PlacementGraphSessionWise As String = "PlacementGraphSessionWise"
    Private Const SemesterWiseStudentSelectedList As String = "SemesterWiseStudentSelectedList"
    Private Const DateWiseStudentSelectedList As String = "DateWiseStudentSelectedList"
    Private Const CompanyInformationRegister As String = "CompanyInformationRegister"

#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpCategaryQry$ = "Select Convert(BIT,0) As [Select],Code, ManualCode As [Category Short Name], Description As Category From Sch_Category "
    Dim mHelpEmployeeQry$ = "Select Convert(BIT,0) As [Select],  v.subcode AS Code,Sg.DispName AS Name FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  AND IsNull(v.IsTeachingStaff,0) = 0 "

    Dim mHelpSessionQry$ = "Select Convert(BIT,0) As [Select], S.Code , S.ManualCode AS Session, S.Description AS [Session Name] FROM Sch_Session S "
    Dim mHelpSemesterQry$ = "Select Convert(BIT,0) As [Select], Code, StreamYearSemesterDesc AS Semester, V.SessionProgrammeDesc As [Session Programme], V.StreamManualCode FROM ViewSch_StreamYearSemester V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpAdmissionIdQry$ = "Select Convert(BIT,0) As [Select], V.DocId as Code, V.AdmissionID, V.StudentName AS [Student Name] FROM ViewSch_Admission V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
    Dim mHelpCompanyQry$ = "Select Distinct Convert(BIT,0) As [Select], S.Code , S.Description AS [Company],C.CityName as City,S.Segment FROM Campus_Company S  With  (NoLock) left Join City C With (NoLock) on S.CityCode=C.CityCode "

    Dim mHelpSegmentQry$ = "Select Distinct Convert(BIT,0) As [Select], S.Segment as Code , S.Segment AS [Segment] FROM Campus_Company S  With  (NoLock) Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " and isnull(Segment,'')<>'' "

#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = "", mQry1$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName

                Case StudentSelectedList, SessionWiseStudentSelectedList, CompanyWiseStudentSelectedList, PlacementGraphSessionWise, SemesterWiseStudentSelectedList, DateWiseStudentSelectedList
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpCompanyQry$, "Company")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry$, "Admission Id")

                Case CompanyInformationRegister
                    StrArr1 = New String() {"No", "Yes"}
                    Call ObjRFG.Ini_Grp(, , , , "Person Detail", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCompanyQry$, "Company")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpSegmentQry, "Segment")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case StudentSelectedList, SessionWiseStudentSelectedList, CompanyWiseStudentSelectedList, PlacementGraphSessionWise, SemesterWiseStudentSelectedList, DateWiseStudentSelectedList
                Call ProcStudentSelectedList()

            Case CompanyInformationRegister
                Call ProcCompanyInformationRegister()

        End Select
    End Sub
#Region "Student Selected List"
    Private Sub ProcStudentSelectedList()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub


            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Session", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Company", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.StreamYearSemester", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.AdmissionDocID", 4)


            mQry = " SELECT H.DocId,H.Div_Code,H.Site_Code,H.V_Type,H.V_Prefix,H.V_No,H.V_Date,H.ReferenceNo, " & _
                    " H.JoiningDate,H.Package,H.Desigantion,C.Description AS CompanyName,SS.ManualCode AS Session,S.Name As Site_Name, " & _
                    " Sg.Name AS Student,sg.DispName AS DispStudentName,Sem.StreamYearSemesterDesc AS Semester, " & _
                    " Sg.Add1,Sg.Add2,sg.Add3,sg.Phone,sg.Mobile,sg.FatherName,sg.MotherName,CT.CityName " & _
                    " FROM dbo.Campus_Placement H WITH (NoLock) " & _
                    " left join SiteMast S WITH (NoLock) on H.Site_Code=S.Code  " & _
                    " LEFT JOIN Campus_Company C WITH (NoLock) ON C.Code = H.Company  " & _
                    " LEFT JOIN Sch_Session SS WITH (NoLock) ON SS.Code = H.Session  " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode = H.Student " & _
                    " LEFT JOIN City CT WITH (NoLock) ON CT.CityCode = SG.CityCode " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem WITH (NoLock) ON Sem.Code=H.StreamYearSemester   " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type  "




            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If mGRepFormName = SessionWiseStudentSelectedList Then
                RepName = "Campus_SessionWiseStudentSelectedList" : RepTitle = "Session Wise Student Selected List"

            ElseIf mGRepFormName = CompanyWiseStudentSelectedList Then
                RepName = "Campus_CompanyWiseStudentSelectedList" : RepTitle = "Company Wise Student Selected List"

            ElseIf mGRepFormName = PlacementGraphSessionWise Then
                RepName = "Campus_PlacementGraphSessionWise" : RepTitle = "Placement Graph Session Wise"

            ElseIf mGRepFormName = SemesterWiseStudentSelectedList Then
                RepName = "Campus_SemesterWiseStudentSelectedList" : RepTitle = "Semester Wise Student Selected List"

            ElseIf mGRepFormName = DateWiseStudentSelectedList Then
                RepName = "Campus_DateWiseStudentSelectedList" : RepTitle = "Date Wise Student Selected List"

            Else
                RepName = "Campus_StudentSelectedList" : RepTitle = "Student Selected List"
            End If


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Company Information Register"
    Private Sub ProcCompanyInformationRegister()
        Try


            Dim mCondStr$ = "Where 1=1 ", bView1Str$ = ""

           
            Call ObjRFG.FillGridString()

          
            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.CityCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Segment", 3)

            mQry = "SELECT H.Code,H.Div_Code,H.Site_Code,H.Description,H.ManualCode,H.Add1,H.Add2,H.Add3,H.CityCode, " & _
                    " H.PIN,H.Phone,H.Mobile,H.WebSite,H.Email,H.Rank,H.Segment,S.Name AS SiteName,C.CityName AS City, " & _
                    " L.Person AS ContactPerson,L.Designation,L.Phone AS ContactPhone,L.Mobile AS ContactMobile,L.Email AS ContactEmail,L.Hierarchy, " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM dbo.Campus_Company H WITH (NoLock)  " & _
                    " LEFT JOIN  Campus_Company1 L WITH (NoLock) ON L.Code=H.Code " & _
                    " LEFT JOIN SiteMast S WITH (NoLock) on H.Site_Code=S.Code " & _
                    " LEFT JOIN City C WITH (NoLock) on H.CityCode=C.CityCode  " & _
                    " " & mCondStr & " "

            RepName = "Campus_CompanyInformationRegister" : RepTitle = "Company Information Register"
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub
End Class