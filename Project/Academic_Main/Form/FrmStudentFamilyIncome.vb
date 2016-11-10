Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmStudentFamilyIncome
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()

    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If


        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 600, 880, 0, 0)
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "SELECT GUID AS SearchCode " & _
                " FROM Sch_StudentFamilyIncome Si " & _
                " Left Join SubGroup Sg On Sg.SubCode = Si.Student " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where 1=1  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)


            mQry = "SELECT S.SubCode As Code, Sg.Name AS Student, C.ManualCode AS Category, Sg.FatherName AS [Father Name], S.MotherName AS [Mother Name], C.Code AS CategoryCode " & _
                    " FROM Sch_Student S " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = S.SubCode  " & _
                    " LEFT JOIN Sch_Category C ON C.Code = S.Category " & _
                    " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "" & _
                    " Order By Sg.Name"
            TxtStudent.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select  Code  As Code, ManualCode As Name From Sch_Category " & _
              "  Order By Description"
            TxtCategory.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select  Code  As Code, Description As Name From Sch_Occupation " & _
                "  Order By Description"
            TxtFatherOccupation.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
            TxtMotherOccupation.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT V.Designation AS Code, V.Designation AS Name " & _
                    " FROM (" & _
                    " SELECT DISTINCT S.FatherDesignation AS Designation FROM Sch_Student S WHERE IsNull(S.FatherDesignation,'') <> '' " & _
                    " UNION ALL " & _
                    " SELECT DISTINCT S.MotherDesignation AS Designation FROM Sch_Student S WHERE IsNull(S.MotherDesignation,'') <> '' " & _
                    " ) As V ORDER BY V.Designation "
            TxtFatherDesignation.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
            TxtMotherDesignation.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtStudent.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            MastPos = BMBMaster.Position

            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentFamilyIncome Where Guid='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False


                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtAsOnDate.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "SELECT Si.GUID AS SearchCode, Sg.Name As Student, " & AgL.ConvertDateField("Si.AsOnDate") & " As [As on Date], Si.FatherIncome, Si.MotherIncome, Si.FamilyIncome, " & _
                                " Fo.Description As [Father Occupation], Si.FatherCompany, Si.FatherCompanyAddress, Si.FatherDesignation,  " & _
                                " Mo.Description As [Mother Occupation], Si.MotherCompany, Si.MotherCompanyAddress, Si.MotherDesignation " & _
                                " FROM dbo.Sch_StudentFamilyIncome Si " & _
                                " LEFT JOIN SubGroup Sg ON Sg.SubCode = Si.Student  " & _
                                " LEFT JOIN Sch_Occupation Fo ON Si.FatherOccupation = Fo.Code  " & _
                                " LEFT JOIN Sch_Occupation Mo ON Si.MotherOccupation = Mo.Code  " & _
                                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "


            AgL.PubFindQryOrdBy = "[Student]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Student Family Income List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "SELECT Sg.Name As Student, " & AgL.ConvertDateField("Si.AsOnDate") & " As [As on Date], " & _
                        " Si.FatherIncome As [Father Income], Si.MotherIncome As [Mother Income], Si.FamilyIncome As [Family Income], C.ManualCode AS Category " & _
                        " FROM dbo.Sch_StudentFamilyIncome Si " & _
                        " LEFT JOIN Sch_Student S ON S.SubCode = Si.Student" & _
                        " LEFT JOIN SubGroup Sg ON Sg.SubCode = Si.Student " & _
                        " LEFT JOIN Sch_Category C ON C.Code = S.Category " & _
                        " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                        " Order By C.ManualCode, Sg.Name, Si.AsOnDate "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = AgL.PubReportTitle
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bIncomeDueObj As New Academic_ProjLib.ClsMain.Struct_StudentFamilyIncome
        Dim bLastDate$ = ""

        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            'Code By Akash On Date 26-3-11
            With bIncomeDueObj
                .GUID = mSearchCode
                .Student = TxtStudent.AgSelectedValue
                .AsOnDate = TxtAsOnDate.Text
                .FatherIncome = TxtFatherIncome.Text
                .MotherIncome = TxtMotherIncome.Text
                .FamilyIncome = TxtFamilyIncome.Text
                .FatherOccupation = TxtFatherOccupation.AgSelectedValue
                .FatherCompany = TxtFatherCompany.Text
                .FatherCompanyAddress = TxtFatherCompanyAddress.Text
                .FatherDesignation = TxtFatherDesignation.Text
                .MotherOccupation = TxtMotherOccupation.AgSelectedValue
                .MotherCompany = TxtMotherCompany.Text
                .MotherCompanyAddress = TxtMotherCompanyAddress.Text
                .MotherDesignation = TxtMotherDesignation.Text
                .Div_Code = AgL.PubDivCode
                .Site_Code = TxtSite_Code.AgSelectedValue
            End With

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            Call PLib.ProcSaveFamilyIncome(AgL.GCn, AgL.ECmd, Topctrl1.Mode, bIncomeDueObj, True)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False

            FIniMaster(0, 1)
            Topctrl1_tbRef()
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select Si.*, F.MotherName, F.Category, S.FatherName " & _
                        " From Sch_StudentFamilyIncome Si " & _
                        " Left Join Sch_Student F On F.SubCode =  Si.Student " & _
                        " Left join SubGroup S On F.SubCode = S.SubCode " & _
                        " Where Si.Guid = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_code"))


                        TxtStudent.AgSelectedValue = AgL.XNull(.Rows(0)("Student"))
                        TxtAsOnDate.Text = Format(AgL.XNull(.Rows(0)("AsOnDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                        TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))

                        TxtFatherOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("FatherOccupation"))
                        TxtMotherOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("MotherOccupation"))
                        TxtFatherCompany.Text = AgL.XNull(.Rows(0)("FatherCompany"))
                        TxtFatherCompanyAddress.Text = AgL.XNull(.Rows(0)("FatherCompanyAddress"))
                        TxtFatherDesignation.Text = AgL.XNull(.Rows(0)("FatherDesignation"))
                        TxtMotherCompany.Text = AgL.XNull(.Rows(0)("MotherCompany"))
                        TxtMotherCompanyAddress.Text = AgL.XNull(.Rows(0)("MotherCompanyAddress"))
                        TxtMotherDesignation.Text = AgL.XNull(.Rows(0)("MotherDesignation"))

                        TxtFatherIncome.Text = Format(AgL.VNull(.Rows(0)("FatherIncome")), "0.00")
                        TxtMotherIncome.Text = Format(AgL.VNull(.Rows(0)("MotherIncome")), "0.00")
                        TxtFamilyIncome.Text = Format(AgL.VNull(.Rows(0)("FamilyIncome")), "0.00")

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If Not AgL.StrCmp(TxtSite_Code.AgSelectedValue, AgL.PubSiteCode) Then mTransFlag = True

                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls

        TxtSite_Code.Enabled = False
        TxtFatherName.Enabled = False
        TxtMotherName.Enabled = False
        TxtCategory.Enabled = False
        TxtFamilyIncome.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtStudent.Enabled = False
        End If
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtStudent, "Student") Then Exit Function
            If AgL.RequiredField(TxtAsOnDate, "As On Date") Then Exit Function
            If AgL.RequiredField(TxtFamilyIncome, "Family Income") Then TxtFatherIncome.Focus() : Exit Function

            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM Sch_StudentFamilyIncome Si " & _
                    " WHERE Si.Student = '" & TxtStudent.AgSelectedValue & "' " & _
                    " AND Si.AsOnDate = " & AgL.ConvertDate(TxtAsOnDate.Text) & " " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Si.GUID <> '" & mSearchCode & "' ") & " "
            If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then MsgBox("Record Already Exists For This Date!...") : TxtAsOnDate.Focus() : Exit Function

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetGUID(AgL.GCn).ToString
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtFamilyIncome.Text = Format(Val(TxtFatherIncome.Text) + Val(TxtMotherIncome.Text), "0.00")

    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
            TxtStudent.Validating, TxtAsOnDate.Validating, TxtFatherIncome.Validating, TxtMotherIncome.Validating, TxtFamilyIncome.Validating, _
            TxtFatherCompany.Validating, TxtFatherCompanyAddress.Validating, TxtFatherDesignation.Validating, TxtFatherOccupation.Validating, _
            TxtMotherCompany.Validating, TxtMotherCompanyAddress.Validating, TxtMotherDesignation.Validating, TxtMotherOccupation.Validating

        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.name
                Case TxtStudent.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtCategory.AgSelectedValue = ""
                        TxtFatherName.Text = ""
                        TxtMotherName.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtCategory.AgSelectedValue = AgL.XNull(DrTemp(0)("CategoryCode"))
                            TxtFatherName.Text = AgL.XNull(DrTemp(0)("Father Name"))
                            TxtMotherName.Text = AgL.XNull(DrTemp(0)("Mother Name"))
                        End If
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DrTemp IsNot Nothing Then DrTemp = Nothing
        End Try
    End Sub

End Class
