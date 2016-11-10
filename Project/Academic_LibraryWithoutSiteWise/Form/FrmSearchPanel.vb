Public Class FrmSearchPanel
    Dim mQry$ = ""

    Dim FrmObj As Form = Nothing
    Dim DTMaster As DataTable = Nothing
    Dim DtView As DataView = Nothing

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Me.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If e.KeyCode = Keys.Return Then
                Select Case Me.ActiveControl.Name
                    Case TxtMemberCardNo.Name
                        ProcOpenBookIssue()

                    Case TxtBookID.Name, TxtAccessionNo.Name
                        ProcFillBookIdTable()

                    Case TxtSubjectClassification.Name
                        ProcShowSubjectClassifica(TxtSubjectClassification.AgSelectedValue)

                    Case Else
                        ProcOpenResult()
                End Select
                SendKeys.Send("{Tab}")
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
            AgL.WinSetting(Me, 660, 135, 0, Me.MdiParent.Right - (Me.Width + 10))
            Ini_List()
            DispText()
            FrmObj = New FrmSearchResult()
            Call ProcFillMainDataTable()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Ini_List()
        Try
            ClsMain.ProcFillSearchDataSet()
            TxtSubject.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.SubjectHelpDataSet
            TxtSubjectClassification.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.SubjectHelpDataSet
            TxtBookType.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.BookTypeHelpDataSet
            TxtBookCode.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.BookCodeHelpDataSet
            TxtBookTitle.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.BookTitleHelpDataSet
            TxtISBN.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.ISBNHelpDataSet
            TxtWriter.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.WriterHelpDataSet
            TxtPublisher.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.PublisherHelpDataSet
            TxtAccessionNo.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.AccessionNoHelpDataSet
            TxtCallNo.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.CallNoHelpDataSet
            TxtBookID.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.BookIDHelpDataSet
            TxtMemberCardNo.AgHelpDataSet(0) = ClsMain.Temp_HelpDataSet.MemberCardNoHelpDataSet

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BlankText()
        TxtBookCode.Text = ""
        TxtBookTitle.Text = ""
        TxtBookType.Text = ""
        TxtISBN.Text = ""
        TxtPublisher.Text = ""
        TxtSearchKeyword.Text = ""
        TxtSubject.Text = ""
        TxtWriter.Text = ""
        TxtAccessionNo.Text = ""
        TxtCallNo.Text = ""
        TxtBookID.Text = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        RbtAnd.Checked = True
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    TxtSubject.Enter, TxtBookType.Enter, TxtBookCode.Enter, TxtBookTitle.Enter, TxtISBN.Enter, TxtBookType.Enter, _
    TxtPublisher.Enter, TxtWriter.Enter
        Try
            Select Case sender.name
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click, BtnClear.Click, BtnRefresh.Click
        Select Case sender.Name
            Case BtnOk.Name
                ProcOpenResult()

            Case BtnClear.Name
                BlankText()

            Case BtnRefresh.Name
                ProcFillMainDataTable()
                Ini_List()
        End Select
    End Sub

    Private Function FunRetConStr() As String
        Dim bConStr$ = "", bAndOr$ = ""
        Try
            If RbtOr.Checked Then
                bAndOr = "Or"
                bConStr = "1=2"
            Else
                bAndOr = "And"
                bConStr = "1=1"
            End If

            'If TxtSubject.Text <> "" Then bConStr = bConStr & " " & bAndOr & " SubString(MsCode,1,Len('" & LblSubject.Tag & "')) = '" & LblSubject.Tag & "' "
            If TxtSubject.Text <> "" Then bConStr = bConStr & " " & bAndOr & FunRetSubjectConStr()
            If TxtBookType.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  BookTypeCode = '" & TxtBookType.AgSelectedValue & "'"
            If TxtBookCode.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  BookCode = '" & TxtBookCode.Text & "'"
            If TxtBookTitle.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  BookTitle = '" & TxtBookTitle.Text & "'"
            If TxtISBN.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  ISBN = '" & TxtISBN.Text & "'"
            If TxtWriter.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  Writer = '" & TxtWriter.Text & "'"
            If TxtPublisher.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  Publisher = '" & TxtPublisher.Text & "'"
            If TxtSearchKeyword.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  SearchKeywords LIKE '%" & TxtSearchKeyword.Text & "%'"
            If TxtCallNo.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  IsNull([Call No],'') = '" & TxtCallNo.Text & "'"
                
            FunRetConStr = bConStr
        Catch ex As Exception
            FunRetConStr = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ProcOpenResult()
        Dim I As Integer = 0
        Dim bIsOpen As Boolean = False
        For I = 0 To Me.MdiParent.MdiChildren.Length - 1
            If Me.MdiParent.MdiChildren(I).Text = FrmObj.Text Then
                bIsOpen = True
            End If
        Next
        If bIsOpen = False Then
            FrmObj = New FrmSearchResult()
            FrmObj.MdiParent = Me.MdiParent
            FrmObj.Show()
        End If
            CType(FrmObj, FrmSearchResult).ProcShowResult(FunRetDataTable())
    End Sub

    Private Sub ProcFillMainDataTable()
        Try
            mQry = "SELECT Distinct S.Description AS Subject, Bt.Description AS BookType,  I.ManualCode AS BookCode, " & _
                " I.Description AS BookTitle, Ad.ISBN, Ad.Writer,  Ad.Publisher, B.SearchKeyWords,  " & _
                " Ad.Subject As SubjectCode,  " & _
                " Bt.Code As BookTypeCode , Ad.Edition, Ad.Book As ItemCode, S.MsCode, " & _
                " G.Description As Almira, I.GodownSection As Shelf,  " & _
                " isnull(Ad.CallNo,0) AS [Call No], " & _
                " IsNull(VMain.BookSCount,0) AS [No Of Books], " & _
                " IsNull(VMain.CurrentStock,0) AS [Current Stock],  " & _
                " isnull(VReq.ReqQty,0) AS [Required Qty] " & _
                " FROM Lib_AccessionDetail Ad   " & _
                " LEFT JOIN Lib_Subject S ON Ad.Subject = S.Code   " & _
                " LEFT JOIN Item I ON Ad.Book = I.Code  " & _
                " LEFT JOIN Lib_Book B ON I.Code = B.Code   " & _
                " LEFT JOIN Lib_BookType Bt ON B.BookType = Bt.Code " & _
                " LEFT JOIN Godown G On I.Godown = G.Code " & _
                " LEFT JOIN (   " & _
                " 	SELECT L.Book ,Count(*) BookSCount ,  " & _
                " 	Sum(CASE WHEN l.IsInStock = 1 THEN 1 ELSE 0 END ) AS CurrentStock   " & _
                " 	FROM Lib_AccessionDetail L   " & _
                " 	LEFT JOIN Lib_Accession H ON L.DocID=H.DocId    " & _
                " 	AND  ISNULL(L.WriteOff,0) = 0   " & _
                " 	GROUP BY L.Book    " & _
                " )  AS VMain ON Ad.Book = VMain.Book " & _
                " LEFT JOIN (  " & _
                " 	SELECT RD.Item, Sum(Isnull(RD.Qty,0)) AS ReqQty   " & _
                " 	FROM RequisitionDetail RD   " & _
                " 	LEFT JOIN Requisition R ON R.DocID=RD.DocId    " & _
                " 	WHERE Rd.IssueDocId IS NULL AND ISNULL(R.IsDeleted,0)=0    " & _
                " 	GROUP BY Rd.Item  " & _
                " ) VReq ON VReq.Item = VMain.Book  "


            DTMaster = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillBookIdTable()
        Dim DtTemp As DataTable = Nothing
        Dim bConStr$ = "", bAndOr$ = ""
        Try
            If TxtBookID.Text = "" And TxtAccessionNo.Text = "" Then Exit Sub

            If RbtOr.Checked Then
                bAndOr = "Or"
                bConStr = " WHERE  1=2 "
            Else
                bAndOr = "And"
                bConStr = " WHERE  1=1 "
            End If

            If TxtAccessionNo.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  AccessionNo = '" & TxtAccessionNo.Text & "'"
            If TxtBookID.Text <> "" Then bConStr = bConStr & " " & bAndOr & "  Book_UID = '" & TxtBookID.Text & "'"


            mQry = "SELECT S.Description AS Subject, Bt.Description AS BookType,  I.ManualCode AS BookCode, " & _
                    " I.Description AS BookTitle, Ad.ISBN, Ad.Writer,  Ad.Publisher, B.SearchKeyWords,  " & _
                    " Ad.Subject As SubjectCode,  " & _
                    " Bt.Code As BookTypeCode , Ad.Edition, Ad.Book As ItemCode, S.MsCode,    " & _
                    " IsNull(VMain.BookSCount,0) AS [No Of Books],  " & _
                    " IsNull(VMain.CurrentStock,0) AS [Current Stock],  " & _
                    " isnull(VReq.ReqQty,0) AS [Required Qty]   " & _
                    " FROM Lib_AccessionDetail Ad   " & _
                    " LEFT JOIN Lib_Subject S ON Ad.Subject = S.Code   " & _
                    " LEFT JOIN Item I ON Ad.Book = I.Code  " & _
                    " LEFT JOIN Lib_Book B ON I.Code = B.Code   " & _
                    " LEFT JOIN Lib_BookType Bt ON B.BookType = Bt.Code   " & _
                    " LEFT JOIN (   " & _
                    " 	SELECT L.Book ,Count(*) BookSCount ,  " & _
                    " 	Sum(CASE WHEN IsNull(l.IsInStock,0) <> 0 THEN 1 ELSE 0 END ) AS CurrentStock   " & _
                    " 	FROM Lib_AccessionDetail L   " & _
                    " 	LEFT JOIN Lib_Accession H ON L.DocID=H.DocId    " & _
                    " 	AND  ISNULL(L.WriteOff,0) = 0   " & _
                    " 	GROUP BY L.Book    " & _
                    " )  AS VMain ON Ad.Book = VMain.Book " & _
                    " LEFT JOIN (  " & _
                    " 	SELECT RD.Item, Sum(Isnull(RD.Qty,0)) AS ReqQty   " & _
                    " 	FROM RequisitionDetail RD   " & _
                    " 	LEFT JOIN Requisition R ON R.DocID=RD.DocId    " & _
                    " 	WHERE Rd.IssueDocId IS NULL AND ISNULL(R.IsDeleted,0)=0 " & _
                    " 	GROUP BY Rd.Item  " & _
                    " ) VReq ON VReq.Item = VMain.Book  " & bConStr
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)


            Dim I As Integer = 0
            Dim bIsOpen As Boolean = False
            For I = 0 To Me.MdiParent.MdiChildren.Length - 1
                If Me.MdiParent.MdiChildren(I).Text = FrmObj.Text Then
                    bIsOpen = True
                End If
            Next
            If bIsOpen = False Then
                FrmObj = New FrmSearchResult()
                FrmObj.MdiParent = Me.MdiParent
                FrmObj.Show()
            End If
            CType(FrmObj, FrmSearchResult).ProcShowResult(DtTemp)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function FunRetDataTable() As DataTable
        Try
            DTMaster.DefaultView.RowFilter = FunRetConStr()
            FunRetDataTable = DTMaster.DefaultView.Table
        Catch ex As Exception
            FunRetDataTable = Nothing
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ProcOpenBookIssue()
        Dim FrmObj As Form
        Dim Mdi As MDIMain = New MDIMain
        Dim StrUserPermission As String = ""
        Dim DTUP As New DataTable
        Try
            If TxtMemberCardNo.Text = "" Then Exit Sub
            StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, Mdi.MnuBookIndentEntry.Name, Mdi.MnuBookIndentEntry.Text, DTUP)
            FrmObj = New FrmBookIssueOld(StrUserPermission, DTUP)
            If FrmObj IsNot Nothing Then
                CType(FrmObj, FrmBookIssueOld).MemberCardNo = TxtMemberCardNo.AgSelectedValue
                FrmObj.MdiParent = Me.MdiParent
                FrmObj.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunRetSubjectConStr() As String
        Dim DrTemp As DataRow() = Nothing
        Dim bSubjectList$ = ""
        Try
            If TxtSubject.Text = "" Then FunRetSubjectConStr = "" : Exit Function
            If ChkClassificationWise.Checked Then
                mQry = " DECLARE @bColumnStr1 NVARCHAR(MAX)  " & _
                    " SET @bColumnStr1 = ''; " & _
                    " With CTE(UnderSubject, Code, Title, Level) " & _
                    " AS " & _
                    " ( " & _
                    "     SELECT H.UnderSubject, H.Code, H.Description ,  " & _
                    " 	       0 AS Level " & _
                    "     FROM Lib_Subject H  " & _
                    "     WHERE H.Code = '" & TxtSubject.AgSelectedValue & "' " & _
                    "     UNION ALL " & _
                    "     SELECT H.UnderSubject, H.Code, H.Description ,  " & _
                    "          Level + 1 " & _
                    "     FROM Lib_Subject H  " & _
                    "     INNER JOIN CTE E ON H.UnderSubject = E.Code " & _
                    " ) " & _
                    " SELECT @bColumnStr1 = @bColumnStr1 +      " & _
                    " CASE WHEN  V1.Code IS NULL THEN  '' ELSE ',' + V1.Code END   " & _
                    " FROM CTE  V1 " & _
                    " SELECT CASE WHEN IsNull(@bColumnStr1,'') <> ''     " & _
                    " THEN SubString(@bColumnStr1,2, Len(@bColumnStr1)-1) Else '' END  AS SubjectList  "
                bSubjectList = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar
                FunRetSubjectConStr = " SubjectCode In ('" & Replace(bSubjectList, ",", "','") & "') "
            Else
                FunRetSubjectConStr = " SubjectCode = '" & TxtSubject.AgSelectedValue & "' "
            End If
        Catch ex As Exception
            FunRetSubjectConStr = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ChkClassificationWise_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkClassificationWise.Click
        ProcOpenResult()
    End Sub

    Private Sub ProcShowSubjectClassifica(ByVal SubjectCode As String)
        Dim FrmObj As Form = Nothing
        FrmObj = New FrmSubjectClassificationDisplay()
        CType(FrmObj, FrmSubjectClassificationDisplay).SubjectCode = SubjectCode
        FrmObj.MdiParent = Me.MdiParent
        FrmObj.Show()
        CType(FrmObj, FrmSubjectClassificationDisplay).TreeView1.Nodes.Clear()
        CType(FrmObj, FrmSubjectClassificationDisplay).ProcFillMasterData(SubjectCode)
        CType(FrmObj, FrmSubjectClassificationDisplay).ProcFillRootNodes(SubjectCode)
        CType(FrmObj, FrmSubjectClassificationDisplay).TreeView1.ExpandAll()
        CType(FrmObj, FrmSubjectClassificationDisplay).TreeView1.Focus()
    End Sub
End Class