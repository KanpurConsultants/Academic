Public Class ClsMain
    Public CFOpen As New ClsFunction

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        PObj = New Academic_Objects.ClsMain(AgL, PLib)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Public Sub UpdateTableStructure()
        Try
            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateView()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< SiteMast >===================================================
            AgL.AddNewField(AgL.GCn, "SiteMast", "WebSite", "nvarchar(100)")
            AgL.AddNewField(AgL.GCn, "SiteMast", "EMail", "nvarchar(100)")
            AgL.AddNewField(AgL.GCn, "SiteMast", "IsLibrary", "bit", 0)
            ''============================< ************************* >=====================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            '<Executable Code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Try
            '<Executable Code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewTable()
        Dim mQry As String = ""

        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            mQry = "CREATE TABLE dbo.Sch_Document1 " & _
                    " ( " & _
                    " Code   NVARCHAR (8) NOT NULL, " & _
                    " Sr     INT NOT NULL, " & _
                    " UsedIn NVARCHAR (50) NULL, " & _
                    " CONSTRAINT PK_Sch_Document1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT FK_Sch_Document1_Sch_Document FOREIGN KEY (Code) REFERENCES dbo.Sch_Document (Code) " & _
                    " ) "
            If Not AgL.IsTableExist("Sch_Document1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_Document1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            '<Executable Code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateView()
        Dim mQry As String = ""

        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            '<Executable Code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            '===================================================< Fee Receive Entry V_Type >===================================================
            'AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceive, Academic_ProjLib.ClsMain.Cat_FeeReceive, "Fee Receive Entry", AgL.PubSiteCode)
            'AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceive, Academic_ProjLib.ClsMain.Cat_FeeReceive, Academic_ProjLib.ClsMain.NCat_FeeReceive, "Fee Receive Entry", Academic_ProjLib.ClsMain.NCat_FeeReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewVoucherReference()
        Try
            Dim VRefObj As New Academic_ProjLib.ClsMain.VRef_ReferenceTable

            'VRefObj.VRef_VehicleInsuranceClaimPayment()
            'AgL.AddNewVoucherReference(AgL.GCn, VRefObj.Code, VRefObj.Description, VRefObj.BoundField, VRefObj.DisplayField, VRefObj.IsDocId_DisplayField, VRefObj.HelpQuery, VRefObj.FilterField, VRefObj.SiteField, VRefObj.LastHiddenColumns)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class