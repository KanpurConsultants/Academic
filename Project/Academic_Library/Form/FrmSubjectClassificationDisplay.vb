Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Graphics

Public Class FrmSubjectClassificationDisplay
    Dim mQry$ = ""
    Dim DtMaster As DataTable = Nothing
    Dim DtMasterBookDetail As DataTable = Nothing

    Dim mSubjectCode$ = ""

    Public Property SubjectCode() As String
        Get
            SubjectCode = mSubjectCode
        End Get
        Set(ByVal value As String)
            mSubjectCode = value
        End Set
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub



    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'AgL.FPaintForm(Me, e, 0)
        'Me.BackColor = Color.White
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Me.Close()
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 658, 885, 0, 0)
            IniList()
            ProcFillMasterData()
            ProcFillRootNodes()
            ProcFillBooksDataTable()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniList()
        Try
            mQry = " SELECT H.Code AS Code, H.Description AS Subject FROM Lib_Subject H "
            TxtForSubject.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ProcFillMasterData(Optional ByVal SubjectCode As String = "")
        Dim DtTemp As DataTable = Nothing
        Dim bConStr$ = ""
        Try
            If SubjectCode = "" Then
                bConStr = " WHERE H.UnderSubject IS NULL "
            Else
                bConStr = " WHERE H.Code = '" & SubjectCode & "' "
            End If

            mQry = " With CTE(UnderSubject, Code, Title, Level) " & _
                " AS " & _
                " ( " & _
                "     SELECT H.UnderSubject, H.Code, H.Description ,  " & _
                "         0 AS Level " & _
                "     FROM Lib_Subject H  " & bConStr & _
                "     UNION ALL " & _
                "     SELECT H.UnderSubject, H.Code, H.Description ,  " & _
                "          Level + 1 " & _
                "     FROM Lib_Subject H  " & _
                "     INNER JOIN CTE E ON H.UnderSubject = E.Code " & _
                " ) " & _
                " SELECT CTE.*, S.Description AS UnderSub " & _
                " FROM CTE " & _
                " LEFT JOIN Lib_Subject S ON CTE.UnderSubject = S.Code "

            DtMaster = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Fill_PermissionTree(ByVal SubjectCode As String, ByVal Level As Integer, Optional ByVal TNode As TreeNode = Nothing)
        Dim DtTemp As DataTable
        Dim I As Integer
        DtTemp = DtMaster.Copy
        Dim mTNode As New TreeNode

        DtTemp.DefaultView.RowFilter = " UnderSubject = '" & SubjectCode & "' "
        For I = 0 To DtTemp.DefaultView.Count - 1
            TNode.Nodes.Add(DtTemp.DefaultView.Item(I)("Title"))
            TNode.Nodes(TNode.Nodes.Count - 1).Name = DtTemp.DefaultView.Item(I)("Code")

            If AgL.VNull(DtTemp.DefaultView.Item(I)("LEVEL")) <= 9 Then
                TNode.Nodes(TNode.Nodes.Count - 1).ImageIndex = DtTemp.DefaultView.Item(I)("LEVEL")
                'Else
                '    TreeView1.Nodes(TreeView1.Nodes.Count - 1).ImageIndex = 9
            End If

            'TNode.Nodes(TNode.Nodes.Count - 1).ImageIndex = DtTemp.DefaultView.Item(I)("LEVEL")
            TNode.Nodes(TNode.Nodes.Count - 1).ContextMenuStrip = ContextMenuStrip1
            TNode.Nodes(TNode.Nodes.Count - 1).SelectedImageIndex = TNode.Nodes(TNode.Nodes.Count - 1).ImageIndex
            mTNode = TNode.Nodes(TNode.Nodes.Count - 1)
            Fill_PermissionTree(DtTemp.DefaultView.Item(I)("Code"), DtTemp.DefaultView.Item(I)("LEVEL"), mTNode)
        Next
    End Sub

    Private Sub TxtForSubject_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtForSubject.Validating
        TreeView1.Nodes.Clear()
        ProcFillMasterData(TxtForSubject.AgSelectedValue)
        ProcFillRootNodes(TxtForSubject.AgSelectedValue)
    End Sub

    Public Sub ProcFillRootNodes(Optional ByVal SubjectCode As String = "")
        Dim DtTemp As DataTable
        Dim I As Integer
        DtTemp = DtMaster.Copy
        Dim mTNode As New TreeNode
        If SubjectCode = "" Then
            DtTemp.DefaultView.RowFilter = " UnderSubject Is Null "
        Else
            DtTemp.DefaultView.RowFilter = " Code  = '" & SubjectCode & "' "
        End If

        For I = 0 To DtTemp.DefaultView.Count - 1
            TreeView1.Nodes.Add(DtTemp.DefaultView.Item(I)("Title"))
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Name = DtTemp.DefaultView.Item(I)("Code")
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).ImageIndex = DtTemp.DefaultView.Item(I)("LEVEL")
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).SelectedImageIndex = TreeView1.Nodes(TreeView1.Nodes.Count - 1).ImageIndex
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).ContextMenuStrip = ContextMenuStrip1
            mTNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1)
            Fill_PermissionTree(DtTemp.DefaultView.Item(I)("Code"), DtTemp.DefaultView.Item(I)("LEVEL"), mTNode)
        Next
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        TxtPath.Text = e.Node.FullPath
    End Sub

    Private Sub MnuVIewThisOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuVIewThisOnly.Click, MnuBrowseBooks.Click, MnuBrowseBooksHirarichal.Click
        Dim SubjectCode$ = ""
        Try
            SubjectCode = TreeView1.SelectedNode.Name
            Select Case sender.Name
                Case MnuVIewThisOnly.Name
                    TreeView1.Nodes.Clear()
                    ProcFillMasterData(SubjectCode)
                    ProcFillRootNodes(SubjectCode)
                    TreeView1.ExpandAll()

                Case MnuBrowseBooks.Name
                    Call ProcOpenResult(SubjectCode, False)

                Case MnuBrowseBooksHirarichal.Name
                    Call ProcOpenResult(SubjectCode, True)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        TreeView1.SelectedNode = e.Node
    End Sub

    Private Sub ProcOpenResult(ByVal SubjectCode As String, ByVal Hirarichal As Boolean)
        Dim FrmObj As Form = Nothing
        Try
            DtMasterBookDetail.DefaultView.RowFilter = FunRetSubjectConStr(SubjectCode, Hirarichal)
            FrmObj = New FrmSearchResult()
            FrmObj.MdiParent = Me.MdiParent
            FrmObj.Show()
            CType(FrmObj, FrmSearchResult).ProcShowResult(DtMasterBookDetail.DefaultView.Table)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillBooksDataTable()
        Try
            mQry = "SELECT Distinct S.Description AS Subject, Bt.Description AS BookType,  I.ManualCode AS BookCode, " & _
                " I.Description AS BookTitle, Ad.ISBN, Ad.Writer,  Ad.Publisher, B.SearchKeyWords,  " & _
                " Ad.Subject As SubjectCode,  " & _
                " Bt.Code As BookTypeCode , Ad.Edition, Ad.Book As ItemCode, S.MsCode, " & _
                " G.Description As Almira, I.GodownSection As Shelf,  " & _
                " IsNull(VMain.BookSCount,0) AS [No Of Books], " & _
                " IsNull(VMain.CurrentStock,0) AS [Current Stock],  " & _
                " isnull(VReq.ReqQty,0) AS [Required Qty]   " & _
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

            DtMasterBookDetail = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunRetSubjectConStr(ByVal SubjectCode As String, ByVal Hirarichal As Boolean) As String
        Dim DrTemp As DataRow() = Nothing
        Dim bSubjectList$ = ""
        Try
            If SubjectCode = "" Then FunRetSubjectConStr = "" : Exit Function
            If Hirarichal Then
                mQry = " DECLARE @bColumnStr1 NVARCHAR(MAX)  " & _
                    " SET @bColumnStr1 = ''; " & _
                    " With CTE(UnderSubject, Code, Title, Level) " & _
                    " AS " & _
                    " ( " & _
                    "     SELECT H.UnderSubject, H.Code, H.Description ,  " & _
                    " 	       0 AS Level " & _
                    "     FROM Lib_Subject H  " & _
                    "     WHERE H.Code = '" & SubjectCode & "' " & _
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
                FunRetSubjectConStr = " SubjectCode = '" & SubjectCode & "' "
            End If
        Catch ex As Exception
            FunRetSubjectConStr = ""
            MsgBox(ex.Message)
        End Try
    End Function

    'Private Sub myTreeView_DrawNode(ByVal sender As Object, ByVal e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode
    '    Try
    '        Dim bNode As New TreeNode
    '        If e.Node.IsSelected Then
    '            'While e.Node.Parent IsNot Nothing And Not e.Node.Equals(bNode)
    '            'bNode = e.Node
    '            e.Graphics.DrawLine(Pens.Black, e.Node.Bounds.X - 45, e.Node.Bounds.Y + 10, e.Node.Bounds.X - 45, e.Node.Parent.Bounds.Y + 10)
    '            e.Graphics.DrawLine(Pens.Red, e.Node.Bounds.X, e.Node.Bounds.Y + 10, e.Node.Bounds.X - 45, e.Node.Bounds.Y + 10)
    '            'e.Graphics.DrawBezier(Pens.Black, e.Node.Bounds.X - 45, e.Node.Bounds.Y + 10, e.Node.Bounds.X - 45, e.Node.Parent.Bounds.Y + 10)
    '            'End While
    '        End If

    '        Dim X As System.Drawing.Point
    '        X = New System.Drawing.Point(e.Node.Bounds.X, e.Node.Bounds.Y)

    '        Dim Y As System.Drawing.Point
    '        Y = New System.Drawing.Point(e.Node.Bounds.X, e.Node.Bounds.Y + 200)

    '        Dim StrArr1() As System.Drawing.Point = Nothing
    '        StrArr1 = New System.Drawing.Point() {X, Y}







    '        e.Graphics.DrawLines(Pens.Black, StrArr1)

    '        e.DrawDefault = True
    '    Catch ex As Exception
    '    End Try
    'End Sub
End Class
