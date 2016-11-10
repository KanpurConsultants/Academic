Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAssignmentSheet
    Inherits TempTutorialAssignment

    Dim mQry$ = ""


    Protected Const Col1Question_Assignment As String = "Assignment"

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.AssignmentSheet) & ""
    End Sub


#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.PnlFooter.SuspendLayout()
        Me.PnlFooter2.SuspendLayout()
        Me.PnlFooter3.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle1
        '
        Me.LblTitle1.Size = New System.Drawing.Size(128, 20)
        Me.LblTitle1.Text = "ASSIGNMENT LIST"
        '
        'PnlFooter3
        '
        Me.PnlFooter3.Location = New System.Drawing.Point(586, 344)
        '
        'LblV_No
        '
        Me.LblV_No.Size = New System.Drawing.Size(70, 15)
        Me.LblV_No.Text = "Tutorial No."
        '
        'LblV_Date
        '
        Me.LblV_Date.Size = New System.Drawing.Size(77, 15)
        Me.LblV_Date.Text = "Tutorial Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.Size = New System.Drawing.Size(77, 15)
        Me.LblV_Type.Text = "Tutorial Type"
        '
        'TP1
        '
        Me.TP1.Text = "Tp1"
        '
        'FrmAssignmentSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.MainTableName = "Sch_TutorialAssignment"
        Me.Name = "FrmAssignmentSheet"
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.PnlFooter2.ResumeLayout(False)
        Me.PnlFooter2.PerformLayout()
        Me.PnlFooter3.ResumeLayout(False)
        Me.PnlFooter3.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.Tc1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.GBoxApproved.ResumeLayout(False)
        Me.GBoxApproved.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxModified.ResumeLayout(False)
        Me.GBoxModified.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region


    Private Sub FrmAssignmentSheet_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        LblV_Type.Text = "Assignment Type"
        LblV_Date.Text = "Assignment Date"
        LblV_No.Text = "Assignment No."
    End Sub

    Private Sub FrmAssignmentSheet_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Call PrintDocument(SearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet, DsRep1 As DataSet = Nothing
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = Me.Text.ToUpper
            RepName = "Academic_AssignmentSheet" : RepTitle = AgL.PubReportTitle

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT H.DocId, H.V_Date, H.CompletionDate, H.ReferenceNo, " & _
                        " vSp.SessionProgramme As SessionProgrammeDesc, vSem.StreamYearSemesterDesc, " & _
                        " S.DisplayName As SubjectDisplayName, H.SubjectManualCode, H.Unit, H.Topic, " & _
                        " Sg.Name As TeacherName, Sg.DispName As TeacherDispName, Sg.ManualCode As TeacherManualCode, " & _
                        " H.TotalQuestion, H.TotalReference, H.Remark, Sm.Name As Site_Name, H.Site_Code, H.Div_Code, " & _
                        " H.PreparedBy, H.U_EntDt, H.Edit_Date, H.ModifiedBy, H.ApprovedBy, H.ApprovedDate, " & _
                        " L1.Question, Sm.ManualCode AS SiteManualCode, Sm.Photo As SitePhoho " & _
                        " FROM (Select Header.* From Sch_TutorialAssignment Header WITH (NoLock) Where Header.DocId = " & AgL.Chk_Text(mDocId) & ") As H " & _
                        " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                        " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code  " & _
                        " Left Join dbo.Sch_TutorialAssignment1 L1 WITH (NoLock) On L1.DocId = H.DocId " & _
                        " LEFT JOIN ViewSch_SessionProgramme vSp WITH (NoLock) ON vSp.Code = H.SessionProgramme " & _
                        " LEFT JOIN ViewSch_StreamYearSemester vSem WITH (NoLock) ON vSem.Code = H.StreamYearSemester " & _
                        " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject  " & _
                        " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.Teacher " & _
                        " Where 1=1 "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GcnRead)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)


            ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            RepName = AgPL.GetRepNameCustomize(RepName, AgL.PubReportPath)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")


            mQry = "SELECT L2.DocId, L2.Reference " & _
                    " FROM dbo.Sch_TutorialAssignment2 L2 With (NoLock) " & _
                    " WHERE L2.DocId = " & AgL.Chk_Text(mDocId) & ""
            DsRep1 = AgL.FillData(mQry, AgL.GcnRead)
            AgPL.CreateFieldDefFile1(DsRep1, AgL.PubReportPath & "\" & RepName & "1.ttx", True)

            mCrd.SetDataSource(DsRep.Tables(0))

            AgPL.ReportCommonInformation(AgL, mCrd, AgL.PubReportPath)

            mCrd.OpenSubreport("SUBREP1").Database.Tables(0).SetDataSource(DsRep1.Tables(0))


            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            If DsRep IsNot Nothing Then DsRep.Dispose()
            If DsRep1 IsNot Nothing Then DsRep1.Dispose()

            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub FrmAssignmentSheet_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With DGL1
            .Columns(Col1Question).HeaderText = Col1Question_Assignment
        End With
    End Sub
End Class
