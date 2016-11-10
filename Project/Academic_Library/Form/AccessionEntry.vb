Public Class AccessionEntry
    Dim mCDSearchCode As String
    Public mQry$
    Public mIsOkClicked As Boolean = False
    Dim mBook$ = "", mEntryMode$ = "", mSubject = "", mWriter$ = "", mPublisher$ = "", mVolume$ = "", mLanguage$ = "", mIsbn$ = "", mWithCD$ = "", mSeries$ = "", mCdItemCode$ = ""
    Dim mPlace$ = ""
    Dim malmira$ = "", mPublicationYear$ = ""
   
    Dim mrate As Integer, mMrp As Integer, mPages As Integer, mqty As Integer
    Dim mObjAccessionEntry As frmaccessionentry
    Dim mBookSearchCode$ = "", mBookInternalCode$ = ""
    Dim mSubjectSearchCode$ = "", mSubjectInternalCode$ = ""


    Public Property PublicationYear() As String
        Get
            PublicationYear = mPublicationYear
        End Get
        Set(ByVal value As String)
            mPublicationYear = value
        End Set
    End Property

    Public Property EntryMode() As String
        Get
            EntryMode = mEntryMode
        End Get
        Set(ByVal value As String)
            mEntryMode = value
        End Set
    End Property
    Public Property place() As String
        Get
            place = mPlace
        End Get
        Set(ByVal value As String)
            mPlace = value
        End Set

    End Property
    Public Property almira() As String
        Get
            almira = malmira
        End Get
        Set(ByVal value As String)
            malmira = value
        End Set
    End Property

    Public Property qty() As Integer
        Get
            qty = mqty
        End Get

        Set(ByVal value As Integer)
            mqty = value
        End Set
    End Property

    ', mprefix& = ""
    Public Property Rate() As Integer
        Get
            Rate = mrate
        End Get
        Set(ByVal value As Integer)
            mrate = value
        End Set

    End Property
    Public Property Pages() As Integer
        Get
            Pages = mPages
        End Get
        Set(ByVal value As Integer)
            mPages = value
        End Set


    End Property
    Public Property Mrp() As Integer
        Get
            Mrp = mMrp
        End Get
        Set(ByVal value As Integer)
            mMrp = value
        End Set

    End Property

    Public Property CdItemCode() As String
        Get
            CdItemCode = mCdItemCode
        End Get
        Set(ByVal value As String)
            mCdItemCode = value
        End Set

    End Property


    Public Property Series() As String
        Get
            Series = mSeries
        End Get
        Set(ByVal value As String)
            mSeries = value
        End Set

    End Property

    'Public Property Prefix() As String
    '    Get
    '        Prefix = mprefix
    '    End Get
    '    Set(ByVal value As String)
    '        mprefix = value
    '    End Set
    'End Property


    Public Property WithCD() As String
        Get
            WithCD = mWithCD
        End Get
        Set(ByVal value As String)
            mWithCD = value
        End Set
    End Property

    Public Property ISBN() As String
        Get
            ISBN = mIsbn
        End Get
        Set(ByVal value As String)
            mIsbn = value
        End Set

    End Property

    Public Property Language() As String
        Get
            Language = mLanguage
        End Get
        Set(ByVal value As String)
            mLanguage = value
        End Set

    End Property

    Public Property Volume() As String
        Get
            Volume = mVolume
        End Get
        Set(ByVal value As String)
            mVolume = value
        End Set

    End Property

    Public Property Publisher() As String
        Get
            Publisher = mPublisher
        End Get
        Set(ByVal value As String)
            mPublisher = value
        End Set

    End Property

    Public Property Writer() As String
        Get
            Writer = mWriter
        End Get
        Set(ByVal value As String)
            mWriter = value
        End Set

    End Property


    Public Property Subject() As String
        Get
            Subject = mSubject
        End Get
        Set(ByVal value As String)
            mSubject = value
        End Set

    End Property


    Public Property Book() As String
        Get
            Book = mBook
        End Get
        Set(ByVal value As String)
            mBook = value
        End Set
    End Property

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
            If e.KeyCode = Keys.Escape Then
                mIsOkClicked = True


                Me.Close()
            End If

        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub AccessionEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If mObjAccessionEntry Is Nothing Then
                LblBook_UID.Visible = True
                TxtBook_UID.Visible = True
            Else
                LblBook_UID.Visible = False
                TxtBook_UID.Visible = False
            End If

            Ini_List()
            DispText()

            ProcFill()
            TxtBook.Focus()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ProcFill()
        Dim bTempAccessationNo$ = ""

        bTempAccessationNo = TxtAccno.Text

        AgL.BlankCtrl(Me)

        TxtAccno.Text = bTempAccessationNo
        'LblBook.Tag = ""
        'TxtBook.Text = ""
        'TxtBookDescription.Text = ""
        'TxtWriter.Text = ""
        'TxtPublisher.Text = ""

        'TxtSubject.Text = ""
        'TxtVolume.Text = ""
        'TxtLanguage.Text = ""
        'TxtIsbn.Text = ""
        'TXtWithCD.Text = ""
        'TxtSeries.Text = ""
        'TxtCdItemCode.Text = ""
        ''mprefix = TxtPrefix.Text
        'TXtRate.Text = ""
        'TxtMRP.Text = ""
        'TxtPages.Text = ""
        'TxtQty.Text = ""

        If mBook <> "" Then
            TxtBook.AgSelectedValue = mBook
            Validating_Controls(TxtBook)

            TxtSubject.AgSelectedValue = mSubject
            TxtWriter.Text = mWriter
            TxtPublisher.Text = mPublisher
            TxtPublicationYear.Text = mPublicationYear
            TxtSubject.AgSelectedValue = mSubject
            TxtVolume.Text = mVolume
            TxtPlace.Text = mPlace
            TxtLanguage.Text = mLanguage
            TxtIsbn.Text = mIsbn
            TXtWithCD.Text = mWithCD
            TxtSeries.Text = mSeries
            TxtCdItemCode.Text = mCdItemCode
            TXtRate.Text = mrate
            TxtQty.Text = mqty
            TxtMRP.Text = mMrp
            TxtPages.Text = mPages
        End If
        mBook = "" : mSubject = "" : mWriter = "" : mPublisher = "" : mPublicationYear = "" : mSubject = "" : mVolume = ""
        mPlace = "" : mLanguage = "" : mIsbn = "" : mWithCD = "" : mSeries = "" : mCdItemCode = ""
        mrate = 0 : mqty = 0 : mMrp = 0 : mPages = 0
    End Sub
    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Dgl1.ReadOnly = DataReadOnly
        ''Coding To Enable/Disable Controls
        If AgL.StrCmp(EntryMode, "Browse") Then
            'Dgl1.ReadOnly = True
            'BtnOK.Enabled = False
        End If

    End Sub
    Public Sub Ini_List()

        mQry = "SELECT I.Code, I.Description , B.Writer, B.Publisher, S.Description As SubjectName, " & _
                " I.Unit, I.ItemType, I.DisplayName, I.SalesTaxPostingGroup , " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                " B.Series, B.Subject, B.Volume, B.Language, B.ISBN, " & _
                " B.WithCD, B.GodownCD, B.GodownSectionCD, " & _
                " ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " I.Measure, i.MeasureUnit, B.Writer, B.Publisher, B.Series, B.WithCD, " & _
                " S.Prefix, B.CD_ItemCode As CdItemCode,b.BookType,b.PlaceOfPub,b.PubYear,b.pages,B.rate " & _
                " FROM Item I " & _
                " LEFT JOIN Lib_Book B ON I.Code = B.Code " & _
                " LEFT JOIN Lib_Subject S On B.Subject  = S.Code "
        TxtBook.AgHelpDataSet(30) = AgL.FillData(mQry, AgL.GCn)



        mQry = " SELECT DISTINCT B.Writer  AS Code,B.Writer  FROM Lib_Book B WHERE B.Writer IS NOT NULL "
        TxtWriter.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT B.Publisher  AS Code,B.Publisher  FROM Lib_Book B WHERE B.Publisher IS NOT NULL "
        TxtPublisher.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT BT.Code,BT.Description AS [Book Type],BT.Suffix, " & _
           " isnull(BT.IsDeleted,0) AS IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,BT.Div_Code " & _
           " FROM Lib_BookType BT "
        TxtBookType.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT G.Code AS Code, G.Description AS Godown, IsNull(G.IsDeleted,0) AS IsDeleted," & _
                " G.Div_Code, IsNull(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
                " FROM Godown G "
        TXtAlmira.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)


        mQry = " SELECT S.Code AS Code, S.Description AS Subject, S.Prefix, " & _
                " IsNull(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " IsNull(S.IsDeleted ,0) AS IsDeleted " & _
                " FROM Lib_Subject S "
        TxtSubject.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)



        mQry = " SELECT DISTINCT  L.Edition AS Code, L.Edition FROM Lib_AccessionDetail L WHERE L.Edition IS NOT NULL "
        TxtEdition.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Distinct L.Place AS Code, L.Place  FROM Lib_AccessionHead L WHERE L.Place IS NOT NULL "
        TxtPlace.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub TxtBook_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBook.KeyDown
        Dim FrmObj As Form
        Dim DTUP As New DataTable
        Dim StrUserPermission As String = ""
        Try
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
            If e.Control Or e.Shift Or e.Alt Then Exit Sub

            'If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            'If Dgl1.CurrentCell.ColumnIndex = Dgl1.Columns(Col1Item).Index Then
            If e.KeyCode = Keys.Insert Then
                StrUserPermission = "AEDP"
                mQry = "  Select 'Status' As UP "
                DTUP = AgL.FillData(mQry, AgL.GCn).Tables(0)
                FrmObj = New FrmBookItemGenerate(StrUserPermission, DTUP)


                FrmObj.ShowDialog()

                Ini_List()
                TxtBook.AgSelectedValue = CType(FrmObj, FrmBookItemGenerate).mInternalCode

                'Validating_Item(Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex), Dgl1.CurrentCell.RowIndex)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtBook_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBook.TextChanged

    End Sub

    Private Sub TxtBook_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBook.Validating, TxtSubject.Validating, TxtBookDescription.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.Name
                Case TxtSubject.Name
                    Call Validating_Controls(sender)

                Case TxtBook.Name, TxtBookDescription.Name
                    Call Validating_Controls(sender)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSaveBook(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Try
            If TxtBook.Text <> "" And TxtBook.AgSelectedValue = "" Then
                mBookSearchCode = AgL.GetGUID(AgL.GCn).ToString
                mBookInternalCode = AgL.GetMaxId("Item", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)
                LblBook.Tag = mBookInternalCode

                mQry = " INSERT INTO Item_Log (Code, ManualCode, Description, DisplayName, Unit, ItemType, EntryType, EntryStatus, Status,  UID,Div_Code)" & _
                       " VALUES ('" & mBookInternalCode & "', '" & mBookInternalCode & "', " & AgL.Chk_Text(TxtBookDescription.Text) & ", " & AgL.Chk_Text(TxtBook.Text.ToString) & ", 'PCS', 'Book', 'Add', 'Open', 'Active' , '" & mBookSearchCode & "','" & AgL.PubDivCode & "') "

                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                mQry = " INSERT INTO Item (Code, ManualCode, Description, DisplayName, Unit, ItemType, EntryType, EntryStatus, Status,  UID,Div_Code)" & _
                      " VALUES ('" & mBookInternalCode & "', '" & mBookInternalCode & "', " & AgL.Chk_Text(TxtBookDescription.Text.ToString) & ", " & AgL.Chk_Text(TxtBook.Text.ToString) & ", 'PCS', 'Book', 'Add', 'Open', 'Active' , '" & mBookSearchCode & "','" & AgL.PubDivCode & "' ) "

                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


                mQry = " INSERT INTO Lib_Book_Log(UID, Code, Writer, Publisher,Subject,  Volume,	" & _
                        " WithCD, BookType, BookDescription,PlaceOfPub,PubYear,pages, Series, ISBN, Rate) " & _
                        " VALUES('" & mBookSearchCode & "','" & mBookInternalCode & "'," & AgL.Chk_Text(TxtWriter.Text) & ",	 " & _
                        " " & AgL.Chk_Text(TxtPublisher.Text) & ", " & _
                        "  " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtVolume.Text) & ", " & IIf(TXtWithCD.Text = "Yes", 1, 0) & ", " & _
                        " " & AgL.Chk_Text(TxtBookType.AgSelectedValue) & " , " & _
                        " " & AgL.Chk_Text(TxtBook.Text.ToString) & "," & AgL.Chk_Text(TxtPlace.Text) & "," & AgL.Chk_Text(TxtPublicationYear.Text) & "," & Val(TxtPages.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtSeries.Text) & ", " & AgL.Chk_Text(TxtIsbn.Text) & ", " & Val(TXtRate.Text) & "  " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


                mQry = " INSERT INTO Lib_Book(UID, Code, Writer, Publisher,Subject,  Volume,	WithCD, BookType, BookDescription,PlaceOfPub,PubYear,pages, Series, ISBN, Rate) " & _
                       " VALUES('" & mBookSearchCode & "','" & mBookInternalCode & "'," & AgL.Chk_Text(TxtWriter.Text) & ",	 " & _
                       " " & AgL.Chk_Text(TxtPublisher.Text) & ", " & _
                       "  " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                       " " & AgL.Chk_Text(TxtVolume.Text) & ", " & IIf(TXtWithCD.Text = "Yes", 1, 0) & ", " & _
                       " " & AgL.Chk_Text(TxtBookType.AgSelectedValue) & " , " & _
                       " " & AgL.Chk_Text(TxtBook.Text.ToString) & " ," & AgL.Chk_Text(TxtPlace.Text) & "," & AgL.Chk_Text(TxtPublicationYear.Text) & "," & Val(TxtPages.Text) & ", " & _
                       " " & AgL.Chk_Text(TxtSeries.Text) & ", " & AgL.Chk_Text(TxtIsbn.Text) & ", " & Val(TXtRate.Text) & "  " & _
                       " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                If TXtWithCD.Text = "Yes" Then
                    Call ProcSaveCDItem(True, Conn, Cmd)
                Else
                    Call ProcSaveCDItem(False, Conn, Cmd)
                End If
            Else
                mQry = " Update Lib_Book_Log set Writer=" & AgL.Chk_Text(TxtWriter.Text) & ", Publisher=" & AgL.Chk_Text(TxtPublisher.Text) & ",  " & _
                        " Series = " & AgL.Chk_Text(TxtSeries.Text) & ", " & _
                        " ISBN = " & AgL.Chk_Text(TxtIsbn.Text) & ", " & _
                        " Language = " & AgL.Chk_Text(TxtLanguage.Text) & ", " & _
                        " Rate = " & Val(TXtRate.Text) & " " & _
                        "  where code=" & AgL.Chk_Text(TxtBook.AgSelectedValue) & "  "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                mQry = " Update Lib_Book set Writer=" & AgL.Chk_Text(TxtWriter.Text) & ", Publisher=" & AgL.Chk_Text(TxtPublisher.Text) & ", " & _
                        " Series = " & AgL.Chk_Text(TxtSeries.Text) & ", " & _
                        " ISBN = " & AgL.Chk_Text(TxtIsbn.Text) & ", " & _
                        " Language = " & AgL.Chk_Text(TxtLanguage.Text) & ", " & _
                        " Rate = " & Val(TXtRate.Text) & " " & _
                        " where code=" & AgL.Chk_Text(TxtBook.AgSelectedValue) & "  "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Click, BtnClose.Click
        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.Name

                Case BtnOK.Name
                    If AgL.RequiredField(TxtSubject, LblSubjectName.Text) Then Exit Sub
                    If AgL.RequiredField(TxtBook, LblBook.Text) Then Exit Sub
                    If AgL.RequiredField(TxtQty, LblQty.Text, True) Then Exit Sub

                    If mObjAccessionEntry Is Nothing Then
                        If AgL.RequiredField(TxtAccno, lblAccessionNo.Text) Then Exit Sub
                        If AgL.RequiredField(TxtBook_UID, LblBook_UID.Text) Then Exit Sub

                        mQry = "SELECT IsNull(COUNT(*),0) AS Cnt " & _
                                " FROM Lib_AccessionDetail L WITH (NoLock) " & _
                                " WHERE L.Book_UID = " & AgL.Chk_Text(TxtBook_UID.Text) & ""
                        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                            MsgBox("Book ID already exists!...")
                            TxtBook_UID.Focus()
                            Exit Sub
                        End If
                    End If


                    ProcSaveSubject(AgL.GCn, AgL.ECmd)
                    Ini_List()
                    TxtSubject.AgSelectedValue = LblSubjectName.Tag

                    If TxtBook.Text.Trim <> "" And TxtBook.AgSelectedValue = "" Then
                        mQry = "SELECT COUNT(*) FROM Item H WITH (NoLock) WHERE H.Description = '" & TxtBookDescription.Text & "'"
                        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                            MsgBox("Book Description Already Exists!...")
                            TxtBookDescription.Focus()
                            Exit Sub
                        End If
                    End If

                    ProcSaveBook(AgL.GCn, AgL.ECmd)
                    Ini_List()
                    TxtBook.AgSelectedValue = LblBook.Tag

                    mIsOkClicked = True

                    If mObjAccessionEntry IsNot Nothing Then
                        mObjAccessionEntry.Dgl1.Rows.Add("")
                    End If

                    Me.Close()

                Case BtnClose.Name
                    Me.Close()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSaveSubject(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

        Try
            If TxtSubject.Text <> "" And TxtSubject.AgSelectedValue = "" Then
                mSubjectSearchCode = AgL.GetGUID(AgL.GCn).ToString
                mSubjectInternalCode = AgL.GetMaxId("Lib_Subject_Log", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)
                LblSubjectName.Tag = mSubjectInternalCode

                mQry = " INSERT INTO Lib_Subject_Log(UID, Code, Description,  Prefix, " & _
                        " EntryBy, EntryDate, EntryType, EntryStatus, Status, Div_Code ) " & _
                        " VALUES (" & AgL.Chk_Text(mSubjectSearchCode) & ", " & AgL.Chk_Text(mSubjectInternalCode) & ",  " & _
                        " " & AgL.Chk_Text(TxtSubject.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtBookPrefix.Text) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ",  " & _
                        " 'Add',  'Open',  " & _
                        " 'Active' , " & AgL.Chk_Text(AgL.PubDivCode) & ") "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


                mQry = " INSERT INTO Lib_Subject SELECT * FROM Lib_Subject_Log WHERE Code = '" & mSubjectInternalCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            End If

            

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSaveCDItem(ByVal bWithCD As Boolean, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        If bWithCD = True Then
            If mCDSearchCode <> "" Then
                mQry = " UPDATE Item " & _
                        " SET ManualCode = " & AgL.Chk_Text(LblBook.Tag) & " + '-CD', " & _
                        " Description = " & AgL.Chk_Text(TxtBookDescription.Text) & " + '-CD', " & _
                        " DisplayName = " & AgL.Chk_Text(TxtBook.Text) & " + '-CD', " & _
                        " EntryType = 'ADD', " & _
                        " WHERE Code= '" & mCDSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            Else
                mCDSearchCode = AgL.GetMaxId("Item", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

                mQry = " INSERT INTO Item (Code, ManualCode, Description, DisplayName, ItemType, " & _
                        " EntryBy, EntryDate, EntryType, ApproveBy, ApproveDate, Status,  " & _
                        " Div_Code) " & _
                        " VALUES ('" & mCDSearchCode & "'," & AgL.Chk_Text(LblBook.Tag) & " + '-CD' , " & _
                        " " & AgL.Chk_Text(TxtBookDescription.Text) & " + '-CD', " & AgL.Chk_Text(TxtBook.Text) & " + '-CD'," & AgL.Chk_Text(ClsMain.ItemType.CD) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', 'Add',  " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', " & AgL.Chk_Text(ClsMain.LogStatus.LogOpen) & ", '" & AgL.PubDivCode & "') "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If

            mQry = " UPDATE Lib_Book_Log SET CD_ItemCode = " & AgL.Chk_Text(mCDSearchCode) & " " & _
                    " WHERE Code =" & AgL.Chk_Text(mBookInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Book SET CD_ItemCode = " & AgL.Chk_Text(mCDSearchCode) & " " & _
                    " WHERE Code =" & AgL.Chk_Text(mBookInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        Else
            mQry = " UPDATE Item " & _
                " SET IsDeleted = 1 " & _
                " WHERE Code= '" & mCDSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Book_Log SET CD_ItemCode = NULL " & _
                    " WHERE Code =" & AgL.Chk_Text(mBookInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Book SET CD_ItemCode = NULL " & _
                    " WHERE Code =" & AgL.Chk_Text(mBookInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

    End Sub

    Sub New(ByRef mobjAccEntry As frmaccessionentry)

        mObjAccessionEntry = mobjAccEntry
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mObjAccessionEntry = Nothing
    End Sub

    Public Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtSubject.Name
                If AgL.XNull(Sender.text).ToString.Trim <> "" Or AgL.XNull(Sender.AgSelectedValue).ToString.Trim = "" Then
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Subject = " & AgL.Chk_Text(Sender.Text) & "")
                    If DrTemp.Length > 0 Then
                        Sender.tag = AgL.XNull(DrTemp(0)("Code"))
                    Else
                        Sender.tag = ""
                    End If
                End If

                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    LblSubjectName.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblSubjectName.Tag = TxtSubject.AgSelectedValue
                        TxtBookPrefix.Text = AgL.XNull(DrTemp(0)("Prefix"))
                    End If
                End If

            Case TxtBook.Name, TxtBookDescription.Name
                If AgL.XNull(TxtBook.Text).ToString.Trim <> "" Or AgL.XNull(TxtBook.AgSelectedValue).ToString.Trim = "" Then

                    If TxtBookDescription.Text.Trim = "" Then TxtBookDescription.Text = TxtBook.Text

                    DrTemp = TxtBook.AgHelpDataSet.Tables(0).Select("Description = " & AgL.Chk_Text(TxtBookDescription.Text) & "")
                    If DrTemp.Length > 0 Then
                        TxtBook.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    Else
                        TxtBook.Tag = ""
                    End If
                    DrTemp = Nothing
                End If

                If TxtBook.Text.ToString.Trim = "" Or TxtBook.AgSelectedValue = "" Then
                    LblBook.Tag = ""

                    DrTemp = TxtBook.AgHelpDataSet.Tables(0).Select("Description = " & AgL.Chk_Text(TxtBook.Text) & "")
                    If DrTemp.Length = 0 Then
                        TxtWriter.Text = ""
                        TxtPublisher.Text = ""
                        TxtSubject.Text = "" : TxtSubject.Enabled = True : TxtSubject.BackColor = Color.White
                        TxtVolume.Text = ""
                        TxtLanguage.Tag = ""
                        TxtBookType.Text = ""
                        TxtIsbn.Text = ""
                        TXtWithCD.Text = ""
                        TxtSeries.Text = ""
                        TxtCdItemCode.Text = ""
                        TxtPrefix.Tag = ""
                    End If

                Else
                    If TxtBook.AgHelpDataSet IsNot Nothing Then
                        DrTemp = TxtBook.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtBook.AgSelectedValue) & "")
                        LblBook.Tag = TxtBook.AgSelectedValue
                        TxtBookDescription.Text = AgL.XNull(DrTemp(0)("DisplayName"))
                    End If
                End If

                If DrTemp IsNot Nothing Then
                    If DrTemp.Length > 0 Then
                        TxtWriter.Text = AgL.XNull(DrTemp(0)("Writer"))
                        TxtPublisher.Text = AgL.XNull(DrTemp(0)("Publisher"))
                        TxtBookType.AgSelectedValue = AgL.XNull(DrTemp(0)("BookType"))
                        TxtSubject.AgSelectedValue = AgL.XNull(DrTemp(0)("Subject")) : TxtSubject.Enabled = False : TxtSubject.BackColor = Color.White
                        LblSubjectName.Tag = TxtSubject.AgSelectedValue

                        TxtVolume.Text = AgL.XNull(DrTemp(0)("Volume"))
                        TxtLanguage.Text = AgL.XNull(DrTemp(0)("Language"))
                        TxtIsbn.Text = AgL.XNull(DrTemp(0)("ISBN"))
                        TXtWithCD.Text = IIf(AgL.VNull(DrTemp(0)("WithCD")) = 0, "No", "Yes")
                        TxtSeries.Text = AgL.XNull(DrTemp(0)("Series"))
                        TxtCdItemCode.Text = AgL.XNull(DrTemp(0)("CdItemCode"))
                        TxtPrefix.Text = AgL.XNull(DrTemp(0)("Prefix"))
                        TxtPlace.Text = AgL.XNull(DrTemp(0)("PlaceOfPub"))
                        TxtPublicationYear.Text = AgL.XNull(DrTemp(0)("PubYear"))
                        TxtPages.Text = AgL.VNull(DrTemp(0)("pages"))
                        TXtRate.Text = AgL.VNull(DrTemp(0)("Rate"))
                    End If
                End If
                DrTemp = Nothing
        End Select

        Validating_Controls = True
    End Function
  
End Class