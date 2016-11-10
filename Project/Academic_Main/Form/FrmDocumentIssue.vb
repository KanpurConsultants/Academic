Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmDocumentIssue
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mDocumentType As String = ""

    Public DocumentType_RailwayPass As String = "Railway Pass"
    Public DocumentType_TransferCertificate As String = "Transfer Certificate"
    Public DocumentType_CharacterCertificate As String = "Character Certificate"
    Public DocumentType_FeeStructure As String = "Fee Structure"
    Public DocumentType_FeeStructureYearly As String = "Fee Structure Yearly"
    Public DocumentType_OtherDocument As String = "Other Document"
    Public DocumentType_ProvisionalCertificate As String = "Provisional Certificate"

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

            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 500, 880, 0, 0)
            IniGrid()
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String

        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("DI.IssueDate", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("DI.Site_Code", AgL.PubSiteCode) & " "

            mQry = " SELECT DI.GUID As SearchCode FROM Sch_DocumentIssue DI " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()

        mQry = " SELECT '" & DocumentType_RailwayPass & "' AS Code,'" & DocumentType_RailwayPass & "' AS Document " & _
                " UNION ALL " & _
                " SELECT '" & DocumentType_FeeStructure & "' AS Code,'" & DocumentType_FeeStructure & "' AS Document " & _
                " UNION ALL " & _
                " SELECT '" & DocumentType_FeeStructureYearly & "' AS Code,'" & DocumentType_FeeStructureYearly & "' AS Document " & _
                " UNION ALL " & _
                " SELECT '" & DocumentType_CharacterCertificate & "' AS Code,'" & DocumentType_CharacterCertificate & "' AS Document " & _
                " UNION ALL " & _
                " SELECT '" & DocumentType_TransferCertificate & "' AS Code,'" & DocumentType_TransferCertificate & "' AS Document " & _
                " UNION ALL " & _
                " SELECT '" & DocumentType_OtherDocument & "' AS Code,'" & DocumentType_OtherDocument & "' AS Document " & _
                " UNION ALL " & _
                " SELECT '" & DocumentType_ProvisionalCertificate & "' AS Code,'" & DocumentType_ProvisionalCertificate & "' AS Document "
        TxtDocumentType.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)



        mQry = "Select V1.DocId As Code, V1.StudentName, V1.AdmissionID, " & _
                " V1.Student As StudentCode, V1.StudentDispName, V1.V_Date As AdmissionDate, " & _
                " V1.Status, Vp.FromStreamYearSemester, S.SessionProgrammeStreamYear AS StreamYear, S.AcademicYearDesc " & _
                " FROM (SELECT P.* FROM Sch_AdmissionPromotion P Where P.PromotionDate IS NULL) vP " & _
                " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
                " LEFT JOIN ViewSch_StreamYearSemester S ON S.Code= vP.FromStreamYearSemester " & _
                " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " And " & _
                " V1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                " Order By V1.StudentName "
        TxtAdmissionID.AgHelpDataSet(6) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT VSem.Code , VSem.StreamYearSemesterDesc AS Semester, VSem.SessionProgrammeStreamYear AS StreamYear,VSem.SemesterStartDate , VYear.SessionProgrammeStreamCode,  " & _
                " VSem.SessionProgrammeCode, VSem.SemesterSerialNo, VSem.SessionStartDate, VSem.StreamCode, VSem.ProgrammeCode " & _
                " FROM ViewSch_StreamYearSemester VSem " & _
                " LEFT JOIN ViewSch_SessionProgrammeStreamYear VYear ON VSem.SessionProgrammeStreamYear = VYear.SessionProgrammeStreamYearCode " & _
                " Where " & AgL.PubSiteCondition("VSem.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By VYear.SessionProgrammeStreamCode, VSem.SemesterStartDate "
        TxtStreamYearSemester.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT D.Subject AS Code,D.Subject  FROM Sch_DocumentIssue D " & _
                " WHERE D.Subject IS NOT NULL " & _
                " GROUP BY D.Subject "
        TxtSubject.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT D.FooterRemark AS Code,D.FooterRemark  FROM Sch_DocumentIssue D " & _
                " WHERE D.FooterRemark IS NOT NULL " & _
                " GROUP BY D.FooterRemark "
        TxtFooterRemark.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT D.Purpose AS Code,D.Purpose  FROM Sch_DocumentIssue D " & _
                " WHERE D.Purpose IS NOT NULL " & _
                " GROUP BY D.Purpose "
        TxtPurpose.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry(" DELETE FROM Sch_DocumentIssue WHERE GUID='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl_tbRef()
                    Else
                        AgL.PubSearchRow = ""
                    End If
                    MoveRec()

                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtIssueDate.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("DI.IssueDate", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("DI.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = " SELECT DI.GUID AS SearchCode,DI.DocumentType,DI.IssueDate, " & _
                                " A.StudentName,Vsem.StreamYearSemesterDesc AS Semester,DI.Subject,DI.Purpose " & _
                                " FROM  Sch_DocumentIssue DI " & _
                                " LEFT JOIN ViewSch_StreamYearSemester VSem ON VSem.Code=DI.StreamYearSemester  " & _
                                " LEFT JOIN ViewSch_Admission A ON A.DocId=DI.AdmissionDocId  " & _
                                " " & mCondStr & ""

            AgL.PubFindQryOrdBy = "[SearchCode]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        PrintDocument(TxtDocumentType.Text, mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocumentType As String, ByVal mDocId As String)
        Select Case mDocumentType
            Case DocumentType_RailwayPass
                PrintDocument_RailwayPass(mDocId, mDocumentType)

            Case DocumentType_ProvisionalCertificate
                PrintDocument_ProvisionalCertificate(mDocId, mDocumentType)

            Case DocumentType_FeeStructureYearly
                PrintDocument_FeeStructureYearly(mDocId)

            Case DocumentType_FeeStructure
                PrintDocument_FeeStructure(mDocId)

            Case DocumentType_TransferCertificate
                PrintDocument_TransferCertificate(mDocId, mDocumentType)

            Case DocumentType_CharacterCertificate
                PrintDocument_TransferCertificate(mDocId, mDocumentType)

            Case DocumentType_OtherDocument
                PrintDocument_RailwayPass(mDocId, mDocumentType)
        End Select
    End Sub
    Private Sub PrintDocument_ProvisionalCertificate(ByVal mDocId As String, ByVal mDocumentType As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""


        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Railway Pass "
            RepName = "Academic_ProvisionalCertificate" : RepTitle = "Railway Pass"


            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT D.GUID ,D.DocumentType ,D.IssuedTo,D.IssueDate,isnull(D.AdmissionDocId,'0') AS AdmissionDocId, A.AdmissionID ," & _
                        " A.StudentName,A.StudentDispName,A.FatherName,Vsem.StreamYearSemesterDesc AS Semester,Vsem.SessionDescription," & _
                        " D.Subject,D.BodyText,D.FooterRemark,D.Purpose,D.Remark ," & _
                        " CASE WHEN S.Sex = 'Female' THEN 'D/o' ELSE 'S/o' END AS FatherRelation, VSem.AcademicYearDesc as YearString,VSem.ProgrammeManualCode,vsem.SemesterSerialNo,vsem.YearSerial,vsem.StreamManualCode,subgroup.FatherNamePrefix  " & _
                        " FROM Sch_DocumentIssue D" & _
                        " LEFT JOIN ViewSch_Admission A ON A.DocId=D.AdmissionDocId" & _
                        " LEFT JOIN ViewSch_StreamYearSemester VSem ON VSem.Code=D.StreamYearSemester" & _
                        " LEFT JOIN ViewSch_Student S ON S.SubCode =A.Student left join subgroup on a.student=subgroup.subcode " & _
                        " WHERE D.GUID='" & mDocId & "'"
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PrintDocument_RailwayPass(ByVal mDocId As String, ByVal mDocumentType As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            RepName = "Academic_DocumentIssue_RailwayPass" : RepTitle = "Railway Pass"


            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT D.GUID ,D.DocumentType ,D.IssuedTo,D.IssueDate,isnull(D.AdmissionDocId,'0') AS AdmissionDocId, A.AdmissionID ," & _
                        " A.StudentName,A.StudentDispName,A.FatherName,Vsem.StreamYearSemesterDesc AS Semester,Vsem.SessionDescription," & _
                        " D.Subject,D.BodyText,D.FooterRemark,D.Purpose,D.Remark ," & _
                        " CASE WHEN S.Sex = 'Female' THEN 'D/o' ELSE 'S/o' END AS FatherRelation, VSem.AcademicYearDesc as YearString ,VSem.ProgrammeManualCode,vsem.SemesterSerialNo,vsem.YearSerial,vsem.StreamManualCode,subgroup.FatherNamePrefix " & _
                        " FROM Sch_DocumentIssue D" & _
                        " LEFT JOIN ViewSch_Admission A ON A.DocId=D.AdmissionDocId" & _
                        " LEFT JOIN ViewSch_StreamYearSemester VSem ON VSem.Code=D.StreamYearSemester" & _
                        " LEFT JOIN ViewSch_Student S ON S.SubCode =A.Student left join subgroup on a.student=subgroup.subcode " & _
                        " WHERE D.GUID='" & mDocId & "'"
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PrintDocument_FeeStructureYearly(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Fee Structure Yearly"
            RepName = "Academic_DocumentIssue_FeeStructureYearly" : RepTitle = "Fee Structure Yearly"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT D.GUID ,D.DocumentType ,D.IssuedTo,D.IssueDate,isnull(D.AdmissionDocId,'0') AS AdmissionDocId, A.AdmissionID , " & _
                     "  A.StudentName,A.StudentDispName,A.FatherName,Vsem.StreamYearSemesterDesc AS Semester,Vsem.YearSerial, " & _
                     "  Vsem.SessionDescription, D.Subject,D.BodyText,D.FooterRemark,D.Purpose,D.Remark , CASE WHEN S.Sex = 'Female' THEN 'D/o' ELSE 'S/o' END AS FatherRelation , " & _
                     "  V1.Fee,F.DispName  AS FeeDisp,V1.SemesterSerialNo ,V1.FeeAmount, " & _
                     "  CASE WHEN Vsem.YearSerial =1 THEN 'st' " & _
                     " WHEN Vsem.YearSerial =2 THEN 'nd'  " & _
                     " WHEN Vsem.YearSerial =3 THEN 'rd'  " & _
                     " WHEN Vsem.YearSerial >3 THEN 'th'  " & _
                     " END AS YearComment,VSem.AcademicYearDesc as YearString ,VSem.ProgrammeManualCode,vsem.SemesterSerialNo,vsem.YearSerial,vsem.StreamManualCode,subgroup.FatherNamePrefix  " & _
                     "  FROM Sch_DocumentIssue D  " & _
                     "  LEFT JOIN ViewSch_Admission A ON A.DocId=D.AdmissionDocId  " & _
                     "  LEFT JOIN ViewSch_StreamYearSemester VSem ON VSem.Code=D.StreamYearSemester  " & _
                     "  LEFT JOIN ViewSch_Student S ON S.SubCode =A.Student   " & _
                     "  Left Join " & _
                     "  ( " & _
                     " SELECT AFD.DocId,S.SemesterSerialNo,AFD.Fee,sum(AFD.Amount) AS FeeAmount   " & _
                     " FROM Sch_AdmissionFeeDetail AFD " & _
                     " LEFT JOIN ViewSch_StreamYearSemester S ON S.Code=AFD.StreamYearSemester " & _
                     " WHERE S.SessionProgrammeStreamYear ='" & LblStreamYearSemester.Tag & "' " & _
                     " GROUP BY AFD.DocId,S.SemesterSerialNo,AFD.Fee   " & _
                     " ) V1 ON V1.DocId=D.AdmissionDocId " & _
                     " LEFT JOIN viewSch_Fee F ON F.Code=V1.Fee left join subgroup on a.student=subgroup.subcode " & _
                     " WHERE D.GUID='" & mDocId & "'"

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PrintDocument_FeeStructure(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Fee Structure"
            RepName = "Academic_DocumentIssue_FeeStructure" : RepTitle = "Fee Structure"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT D.GUID ,D.DocumentType ,D.IssuedTo,D.IssueDate,isnull(D.AdmissionDocId,'0') AS AdmissionDocId, A.AdmissionID , " & _
                     "  A.StudentName,A.StudentDispName,A.FatherName,Vsem.StreamYearSemesterDesc AS Semester, " & _
                     "  Vsem.SessionDescription, D.Subject,D.BodyText,D.FooterRemark,D.Purpose,D.Remark , CASE WHEN S.Sex = 'Female' THEN 'D/o' ELSE 'S/o' END AS FatherRelation , " & _
                     "  V1.YearSerial,V1.SemesterSerialNo,V1.Fee,F.DispName  AS FeeDisp,V1.FeeAmount, " & _
                     "  CASE WHEN V1.YearSerial =1 THEN 'st' " & _
                     " WHEN V1.YearSerial =2 THEN 'nd'  " & _
                     " WHEN V1.YearSerial =3 THEN 'rd'  " & _
                     " WHEN V1.YearSerial >3 THEN 'th'  " & _
                     " END AS YearComment, VSem.AcademicYearDesc as YearString ,VSem.ProgrammeManualCode,vsem.SemesterSerialNo,vsem.YearSerial,vsem.StreamManualCode,subgroup.FatherNamePrefix   " & _
                     "  FROM Sch_DocumentIssue D  " & _
                     "  LEFT JOIN ViewSch_Admission A ON A.DocId=D.AdmissionDocId  " & _
                     "  LEFT JOIN ViewSch_StreamYearSemester VSem ON VSem.Code=D.StreamYearSemester  " & _
                     "  LEFT JOIN ViewSch_Student S ON S.SubCode =A.Student   " & _
                     "  Left Join " & _
                     "  ( " & _
                     " SELECT AFD.DocId,S.YearSerial,S.SemesterSerialNo,AFD.Fee,sum(isnull(AFD.Amount,0)) AS FeeAmount    " & _
                     " FROM Sch_AdmissionFeeDetail AFD " & _
                     " LEFT JOIN ViewSch_StreamYearSemester S ON S.Code=AFD.StreamYearSemester " & _
                     " WHERE isnull(AFD.Amount,0) <>0 " & _
                     " GROUP BY AFD.DocId,S.YearSerial,S.SemesterSerialNo,AFD.Fee   " & _
                     " ) V1 ON V1.DocId=D.AdmissionDocId " & _
                     " LEFT JOIN viewSch_Fee F ON F.Code=V1.Fee left join subgroup on a.student=subgroup.subcode  " & _
                     " WHERE D.GUID='" & mDocId & "'"

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PrintDocument_TransferCertificate(ByVal mDocId As String, ByVal mDocumentType As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bConstr As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            If mDocumentType = DocumentType_TransferCertificate Then
                AgL.PubReportTitle = "TRANSFER CERTIFICATE"
                RepName = "Academic_Transfer_Certificate" : RepTitle = "TRANSFER CERTIFICATE"
            Else
                AgL.PubReportTitle = "CHARACTER CERTIFICATE"
                RepName = "Academic_Character_Certificate" : RepTitle = "CHARACTER CERTIFICATE"
            End If

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If Topctrl1.Mode = "Add" Then


                bConstr = " Where A.DocId ='" & mDocId & "'"
                strQry = ClsReportProcedures.QryTransferCertificate(bConstr, AgL.PubLoginDate)

            Else
                bConstr = " Where A.DocId ='" & TxtAdmissionID.AgSelectedValue & "'"
                strQry = ClsReportProcedures.QryTransferCertificate(bConstr, CDate(TxtIssueDate.Text).ToString)

            End If

          
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bAmount As Double = 0
        Dim bStrDocumentissueGuid$ = ""
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                bStrDocumentissueGuid = AgL.GetGUID(AgL.GcnRead).ToString
                mSearchCode = bStrDocumentissueGuid
                mQry = " INSERT INTO Sch_DocumentIssue	(GUID,DocumentType,IssueDate,AdmissionDocId,SubCode, " & _
                        " IssuedTo,StreamYearSemester,Subject,BodyText,FooterRemark,Purpose,Remark, " & _
                        " Div_Code,Site_Code,PreparedBy,U_EntDt,U_AE ) " & _
                        " VALUES (" & AgL.Chk_Text(bStrDocumentissueGuid) & "," & AgL.Chk_Text(TxtDocumentType.Text) & "," & AgL.ConvertDate(TxtIssueDate.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionID.AgSelectedValue) & "," & AgL.Chk_Text(LblAdmissionID.Tag) & "," & AgL.Chk_Text(TxtIssuedTo.Text) & "," & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSubject.Text) & "," & AgL.Chk_Text(TxtBodyText.Text) & "," & AgL.Chk_Text(TxtFooterRemark.Text) & "," & AgL.Chk_Text(TxtPurpose.Text) & "," & AgL.Chk_Text(TxtRemark.Text) & ",  " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "','" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else

                mQry = " UPDATE dbo.Sch_DocumentIssue " & _
                        " SET DocumentType = " & AgL.Chk_Text(TxtDocumentType.Text) & ", " & _
                        " IssueDate = " & AgL.ConvertDate(TxtIssueDate.Text) & ", " & _
                        " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionID.AgSelectedValue) & ", " & _
                        " SubCode = " & AgL.Chk_Text(LblAdmissionID.Tag) & ", " & _
                        " IssuedTo = " & AgL.Chk_Text(TxtIssuedTo.Text) & ", " & _
                        " StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " Subject = " & AgL.Chk_Text(TxtSubject.Text) & ", " & _
                        " BodyText = " & AgL.Chk_Text(TxtBodyText.Text) & ", " & _
                        " FooterRemark = " & AgL.Chk_Text(TxtFooterRemark.Text) & ", " & _
                        " Purpose = " & AgL.Chk_Text(TxtPurpose.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE GUID ='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Dim mTdocid As String = TxtAdmissionID.AgSelectedValue
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode
            Dim mDocumentType As String = TxtDocumentType.Text

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Document?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If mDocumentType = DocumentType_TransferCertificate Or mDocumentType = DocumentType_CharacterCertificate Then
                        Call PrintDocument(mDocumentType, mTdocid)
                    Else
                        Call PrintDocument(mDocumentType, mDocId)
                    End If

                End If

                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode").ToString
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = " SELECT DI.*,S.SessionProgrammeStreamYear AS StreamYear FROM Sch_DocumentIssue DI " & _
                        " LEFT JOIN ViewSch_StreamYearSemester S ON S.Code=DI.StreamYearSemester  " & _
                        " WHERE DI.GUID='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then

                        TxtDocumentType.Text = AgL.XNull(.Rows(0)("DocumentType"))
                        TxtIssueDate.Text = Format(AgL.XNull(.Rows(0)("IssueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtAdmissionID.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                        LblAdmissionID.Tag = AgL.XNull(.Rows(0)("Subcode"))
                        TxtIssuedTo.Text = AgL.XNull(.Rows(0)("IssuedTo"))
                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        TxtSubject.Text = AgL.XNull(.Rows(0)("Subject"))
                        TxtBodyText.Text = AgL.XNull(.Rows(0)("BodyText"))
                        TxtFooterRemark.Text = AgL.XNull(.Rows(0)("FooterRemark"))
                        TxtPurpose.Text = AgL.XNull(.Rows(0)("Purpose"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("StreamYear"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                        mDocumentType = TxtDocumentType.Text
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            'TxtAdmissionID.Enabled = False
            If TxtAdmissionID.AgSelectedValue <> "" Then
                TxtIssuedTo.Enabled = False
                TxtStreamYearSemester.Enabled = False
            Else
                TxtIssuedTo.Enabled = True
                TxtStreamYearSemester.Enabled = True
            End If
            '<Executable Code>
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
          TxtStreamYearSemester.Enter, TxtIssuedTo.Enter, _
        TxtRemark.Enter
        Try
            Select Case sender.name

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
            TxtRemark.Validating, TxtAdmissionID.Validating, _
           TxtDocumentType.Validating, TxtStreamYearSemester.Validating, TxtIssuedTo.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtIssueDate.Name
                    If sender.Text.Trim = "" Then sender.Text = AgL.PubLoginDate
                Case TxtDocumentType.Name
                    If TxtDocumentType.Text = DocumentType_ProvisionalCertificate Then
                        TxtSubject.Text = "PROVISIONAL CERTIFICATE"
                    End If
                Case TxtAdmissionID.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        TxtStreamYearSemester.AgSelectedValue = ""
                        TxtIssuedTo.Text = ""
                        LblStreamYearSemester.Tag = ""
                        LblAdmissionID.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")

                            TxtStreamYearSemester.AgSelectedValue = AgL.XNull(DrTemp(0)("FromStreamYearSemester"))
                            TxtIssuedTo.Text = AgL.XNull(DrTemp(0)("StudentDispName"))
                            LblStreamYearSemester.Tag = AgL.XNull(DrTemp(0)("StreamYear"))
                            LblAdmissionID.Tag = AgL.XNull(DrTemp(0)("StudentCode"))
                        End If
                    End If

                Case TxtStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        LblStreamYearSemester.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")

                            LblStreamYearSemester.Tag = AgL.XNull(DrTemp(0)("StreamYear"))
                        End If
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try

            If AgL.RequiredField(TxtDocumentType, "Document Type") Then Exit Function
            If AgL.RequiredField(TxtIssueDate, "Issue Date") Then Exit Function
            If Not AgL.IsValidDate(TxtIssueDate, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtIssuedTo, "Issued To") Then Exit Function

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtDocumentType.Focus()
        TxtSubject.Text = "TO WHOM IT MAY CONCERN"
    End Sub

End Class
