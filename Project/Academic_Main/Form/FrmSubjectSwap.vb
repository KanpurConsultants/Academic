Public Class FrmSubjectSwap
    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1DocId As Byte = 1
    Private Const Col1Student As Byte = 2
    Private Const Col1Update As Byte = 3
    Dim mQry As String


    Sub Ini_List()
        mQry = "SELECT S.Code, S.StreamYearSemesterDesc, SessionProgrammeStreamYear " & _
                " FROM ViewSch_StreamYearSemester S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.StreamYearSemesterDesc  "
        TxtSemester.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT AD.DocId , Ad.AdmissionID  " & _
                " FROM ViewSch_Admission Ad " & _
                " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY Ad.AdmissionID  "
        DGL1.AgHelpDataSet(Col1DocId) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Ad.DocID, AD.StudentName " & _
                " FROM ViewSch_Admission AD " & _
                " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY AD.StudentName  "
        DGL1.AgHelpDataSet(Col1Student) = AgL.FillData(mQry, AgL.GCn)

    End Sub


    Private Sub IniGrid()
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1DocId", 180, 0, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Student", 180, 0, "Student", True, True, False)
            .AddAgCheckBoxColumn(DGL1, "DGL1Update", 80, "Update", True, False)

        End With
        DGL1.AllowUserToAddRows = False

    End Sub


    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing

        Dim I As Integer

        Try

            'BlankText()

            mQry = "SELECT Ads.DocID, Ad.Student, CONVERT(BIT,-1) AS [Update]   " & _
                   " FROM Sch_AdmissionSubject AdS  " & _
                   " LEFT JOIN Sch_Admission Ad ON Ads.DocId =Ad.DocId   " & _
                   " WHERE AdS.SemesterSubject = '" & TxtSubject.AgSelectedValue & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL1.RowCount = 1
                DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1DocId, I) = AgL.XNull(.Rows(I)("DocID"))
                        DGL1.AgSelectedValue(Col1Student, I) = AgL.XNull(.Rows(I)("DocID"))
                        DGL1.Item(Col1Update, I).Value = .Rows(I)("Update")
                    Next I
                End If
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AgL.FSetSNo(sender, Col_SNo)
    End Sub

    Private Sub FrmSubjectSwap_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
    End Sub


    Private Sub FrmSubjectSwap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 415, 525, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Ini_List()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSubject.Enter, TxtSemsterSwap.Enter, TxtSubjectSwap.Enter

        Select Case sender.name
            Case TxtSubject.Name
                mQry = "SELECT SS.Code, S.Description " & _
                        " FROM Sch_SemesterSubject SS " & _
                        " LEFT JOIN Sch_Subject S ON SS.Subject =S.Code " & _
                        " WHERE SS.StreamYearSemester ='" & TxtSemester.AgSelectedValue & "' " & _
                        " ORDER BY S.Description  "
                TxtSubject.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            Case TxtSemsterSwap.Name
                mQry = "SELECT S.Code, S.StreamYearSemesterDesc, SessionProgrammeStreamYear " & _
                        " FROM ViewSch_StreamYearSemester S  " & _
                        " Where S.SessionProgrammeStreamYear='" & LblSemester.Tag & "' And S.Code <> '" & TxtSemester.AgSelectedValue & "' " & _
                        "  ORDER BY S.StreamYearSemesterDesc  "
                TxtSemsterSwap.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            Case TxtSubjectSwap.Name
                mQry = "SELECT SS.Code, S.Description " & _
                        " FROM Sch_SemesterSubject SS " & _
                        " LEFT JOIN Sch_Subject S ON SS.Subject =S.Code " & _
                        " WHERE SS.StreamYearSemester ='" & TxtSemsterSwap.AgSelectedValue & "' " & _
                        " ORDER BY S.Description  "
                TxtSubjectSwap.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        End Select

    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click, BtnExit.Click
        Select Case sender.Name
            Case BtnFill.Name
                MoveRec()

            Case BtnExit.Name
                Me.Dispose()
        End Select

    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSemester.Validating
        Select Case sender.Name
            Case TxtSemester.Name, TxtSemsterSwap.Name
                If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                    LblSemester.Tag = ""
                Else
                    If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                        With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                            LblSemester.Tag = AgL.XNull(.Item("SessionProgrammeStreamYear", .CurrentCell.RowIndex).Value)
                        End With
                    End If
                End If

        End Select
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim I As Integer = 0
        Dim bCountAdmissionDocID As String = 0
        Dim bStrAdmissionDocID As String = ""
        Dim mTrans As Boolean


        Try


            For I = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1Update, I).Value Then
                    bCountAdmissionDocID += 1
                    If bStrAdmissionDocID.Trim = "" Then
                        bStrAdmissionDocID = "'" + DGL1.AgSelectedValue(Col1DocId, I) + "'"
                    Else
                        bStrAdmissionDocID += ",'" + DGL1.AgSelectedValue(Col1DocId, I) + "'"
                    End If
                    'bStrAdmissionDocID += "'" + DGL1.AgSelectedValue(Col1DocId, I) + "'" + IIf(I < DGL1.RowCount - 1, ",", "")
                End If
            Next
            If MsgBox("Sure to Swap Subjects of " & bCountAdmissionDocID & " Students", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True



            mQry = "UPDATE Sch_AdmissionSubject  " & _
                  " SET OtherSemesterSubject ='" & TxtSubjectSwap.AgSelectedValue & "' " & _
                  " WHERE SemesterSubject ='" & TxtSubject.AgSelectedValue & "' " & _
                  " AND DocId IN (" & bStrAdmissionDocID & ") "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "Update Sch_AdmissionSubject " & _
                   " SET OtherSemesterSubject ='" & TxtSubject.AgSelectedValue & "' " & _
                   " WHERE SemesterSubject ='" & TxtSubjectSwap.AgSelectedValue & "' " & _
                   " AND DocId IN (" & bStrAdmissionDocID & ") "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)



            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False

            MsgBox("Subject Swaped Successfully! ")

            BlankText()
        Catch ex As Exception
            If mTrans Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try

    End Sub
End Class