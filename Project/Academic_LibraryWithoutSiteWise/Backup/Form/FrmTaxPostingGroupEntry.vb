Imports System.Data.SqlClient
Public Class FrmTaxPostingGroupEntry
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Protected WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1Description As String = "Item Sales Tax Group"
    Protected Const Col1Active As String = "Active"

    Protected WithEvents DGL2 As New AgControls.AgDataGrid
    Protected Const Col2Description As String = "Party Sales Tax Group"
    Protected Const Col2Active As String = "Active"

    Protected WithEvents DGL3 As New AgControls.AgDataGrid
    Protected Const Col3PostingGroupSalesTaxItem As String = "Item Sales Tax Group"
    Protected Const Col3PostingGroupSalesTaxParty As String = "Party Sales Tax Group"
    Protected Const Col3PurchaseSaleAc As String = "Purchase Sale Ac"
    Protected Const Col3SalesTax As String = "Sales Tax"
    Protected Const Col3SalesTaxAc As String = "Sales Tax Ac"
    Protected Const Col3VAT As String = "Vat"
    Protected Const Col3VatAc As String = "Vat Ac"
    Protected Const Col3AdditionalTax As String = "Additional Tax"
    Protected Const Col3AdditionalTaxAc As String = "Additional Tax Ac"
    Protected Const Col3Cst As String = "Cst"
    Protected Const Col3CstAc As String = "Cst Ac"

    Protected WithEvents DGL4 As New AgControls.AgDataGrid
    Protected Const Col4Description As String = "Item Excise Tax Group"
    Protected Const Col4Active As String = "Active"

    Protected WithEvents DGL5 As New AgControls.AgDataGrid
    Protected Const Col5Description As String = "Party Excise Tax Group"
    Protected Const Col5Active As String = "Active"

    Protected WithEvents DGL6 As New AgControls.AgDataGrid
    Protected Const Col6PostingGroupExciseItem As String = "Item Excise Group"
    Protected Const Col6PostingGroupExciseParty As String = "Party Excise Group"
    Protected Const Col6Excise As String = "Excise"
    Protected Const Col6ExciseAc As String = "ExciseAc"
    Protected Const Col6Cess As String = "Cess"
    Protected Const Col6CessAc As String = "CessAc"
    Protected Const Col6ECess As String = "ECess"
    Protected Const Col6ECessAc As String = "ECessAc"
    Protected Const Col6HECess As String = "HECess"
    Protected Const Col6HECessAc As String = "HECessAc"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        With AgCL
            .AddAgTextColumn(DGL1, Col1Description, 400, 20, Col1Description, True, False)
            .AddAgCheckColumn(DGL1, Col1Active, 50, Col1Active, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 30
        DGL1.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL2, Col2Description, 400, 20, Col2Description, True, False)
            .AddAgCheckColumn(DGL2, Col2Active, 50, Col2Active, True)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 30
        DGL2.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL3, Col3PostingGroupSalesTaxItem, 100, 20, Col3PostingGroupSalesTaxItem, True, True)
            .AddAgTextColumn(DGL3, Col3PostingGroupSalesTaxParty, 100, 20, Col3PostingGroupSalesTaxParty, True, True)
            .AddAgTextColumn(DGL3, Col3PurchaseSaleAc, 150, 20, Col3PurchaseSaleAc, True, False)
            .AddAgNumberColumn(DGL3, Col3SalesTax, 70, 8, 3, False, Col3SalesTax, True, False)
            .AddAgTextColumn(DGL3, Col3SalesTaxAc, 150, 20, Col3SalesTaxAc, True, False)
            .AddAgNumberColumn(DGL3, Col3VAT, 50, 8, 3, False, Col3VAT, True, False)
            .AddAgTextColumn(DGL3, Col3VatAc, 150, 20, Col3VatAc, True, False)
            .AddAgNumberColumn(DGL3, Col3AdditionalTax, 70, 8, 3, False, Col3AdditionalTax, True, False)
            .AddAgTextColumn(DGL3, Col3AdditionalTaxAc, 150, 20, Col3AdditionalTaxAc, True, False)
            .AddAgNumberColumn(DGL3, Col3Cst, 70, 8, 3, False, Col3Cst, True, False)
            .AddAgTextColumn(DGL3, Col3CstAc, 150, 20, Col3CstAc, True, False)

        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)
        DGL3.ColumnHeadersHeight = 40
        DGL3.EnableHeadersVisualStyles = False
        DGL3.AllowUserToAddRows = False

        With AgCL
            .AddAgTextColumn(DGL4, Col4Description, 400, 20, Col4Description, True, False)
            .AddAgCheckColumn(DGL4, Col4Active, 50, Col4Active, True)
        End With
        AgL.AddAgDataGrid(DGL4, Pnl4)
        DGL4.ColumnHeadersHeight = 30
        DGL4.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL5, Col5Description, 400, 20, Col5Description, True, False)
            .AddAgCheckColumn(DGL5, Col5Active, 50, Col5Active, True)
        End With
        AgL.AddAgDataGrid(DGL5, Pnl5)
        DGL5.ColumnHeadersHeight = 30
        DGL5.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL6, Col6PostingGroupExciseItem, 100, 20, Col6PostingGroupExciseItem, True, True)
            .AddAgTextColumn(DGL6, Col6PostingGroupExciseParty, 100, 20, Col6PostingGroupExciseParty, True, True)
            .AddAgNumberColumn(DGL6, Col6Excise, 70, 8, 3, False, Col6Excise, True, False)
            .AddAgTextColumn(DGL6, Col6ExciseAc, 150, 20, Col6ExciseAc, True, False)
            .AddAgNumberColumn(DGL6, Col6Cess, 70, 8, 3, False, Col6Cess, True, False)
            .AddAgTextColumn(DGL6, Col6CessAc, 150, 20, Col6CessAc, True, False)
            .AddAgNumberColumn(DGL6, Col6ECess, 70, 8, 3, False, Col6ECess, True, False)
            .AddAgTextColumn(DGL6, Col6ECessAc, 150, 20, Col6ECessAc, True, False)
            .AddAgNumberColumn(DGL6, Col6HECess, 70, 8, 3, False, Col6HECess, True, False)
            .AddAgTextColumn(DGL6, Col6HECessAc, 150, 20, Col6HECessAc, True, False)
        End With
        AgL.AddAgDataGrid(DGL6, Pnl6)
        DGL6.ColumnHeadersHeight = 40
        DGL6.EnableHeadersVisualStyles = False
        DGL6.AllowUserToAddRows = False
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Topctrl1.TopKey_Down(e)
        End If
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Try
            Me.Cursor = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Me.Close()
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            AgL.GridDesign(DGL4)
            AgL.GridDesign(DGL5)
            AgL.GridDesign(DGL6)
            IniGrid()
            Ini_List()
            DispText()
            MoveRec()
            Topctrl1.Mode = "Add"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try
            mQry = "SELECT  S.SubCode As Code, S.Name " & _
                      " From SubGroup S" & _
                      " Order By S.Name "
            TxtServiceTaxAc.AgHelpDataSet(Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
            TxtECessAc.AgHelpDataSet = TxtServiceTaxAc.AgHelpDataSet.Copy
            TxtServiceTaxAc.AgHelpDataSet = TxtServiceTaxAc.AgHelpDataSet.Copy
            TxtHECessAc.AgHelpDataSet = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL3.AgHelpDataSet(Col3PurchaseSaleAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL3.AgHelpDataSet(Col3SalesTaxAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL3.AgHelpDataSet(Col3VatAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL3.AgHelpDataSet(Col3AdditionalTaxAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL3.AgHelpDataSet(Col3CstAc) = TxtServiceTaxAc.AgHelpDataSet.Copy

            DGL6.AgHelpDataSet(Col6CessAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL6.AgHelpDataSet(Col6ECessAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL6.AgHelpDataSet(Col6HECessAc) = TxtServiceTaxAc.AgHelpDataSet.Copy
            DGL6.AgHelpDataSet(Col6ExciseAc) = TxtServiceTaxAc.AgHelpDataSet.Copy

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupSalesTaxItem "
            DGL1.AgHelpDataSet(Col1Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupSalesTaxParty "
            DGL2.AgHelpDataSet(Col2Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupExciseItem "
            DGL4.AgHelpDataSet(Col4Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupExciseParty "
            DGL5.AgHelpDataSet(Col5Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded

    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case sender.name
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Description & "") Then Exit Function
            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim mTrans As Boolean = False
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer
        Try
            If Not Data_Validation() Then Exit Sub
            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            If AgL.PubManageOfflineData Then
                AgL.ECmdSite = AgL.GcnSite.CreateCommand
                AgL.ETransSite = AgL.GcnSite.BeginTransaction(IsolationLevel.ReadCommitted)
                AgL.ECmdSite.Transaction = AgL.ETransSite
            End If
            mTrans = True

            mQry = "DELETE From PostingGroupSalesTaxItem "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupSalesTaxParty "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupSalesTax "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupServiceTax "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupExciseItem "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupExciseParty "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupExcise "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With DGL1
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col1Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupSalesTaxItem(Description) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col1Description, I).Value) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL2
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col2Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupSalesTaxParty(Description) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col2Description, I).Value) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL3
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col3PostingGroupSalesTaxItem, I).Value) <> "" And AgL.XNull(.Item(Col3PostingGroupSalesTaxParty, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupSalesTax(PostingGroupSalesTaxItem, PostingGroupSalesTaxParty, " & _
                                " PurchaseSaleAc, SalesTax, SalesTaxAc, VAT, VatAc, AdditionalTax, AdditionalTaxAc, " & _
                                " Cst, CstAc, Site_Code, Div_Code) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col3PostingGroupSalesTaxItem, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col3PostingGroupSalesTaxParty, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col3PurchaseSaleAc, I)) & ", " & _
                                " " & Val(.Item(Col3SalesTax, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col3SalesTaxAc, I)) & ", " & _
                                " " & Val(.Item(Col3VAT, I).Value) & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col3VatAc, I)) & ",	" & _
                                " " & Val(.Item(Col3AdditionalTax, I).Value) & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col3AdditionalTaxAc, I)) & ", " & _
                                " " & Val(.Item(Col3Cst, I).Value) & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col3CstAc, I)) & ",	" & _
                                " " & AgL.Chk_Text(AgL.PubSiteCode) & ", " & AgL.Chk_Text(AgL.PubDivCode) & ") "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            mQry = "INSERT INTO PostingGroupServiceTax(Div_Code, Site_Code, ServiceTax, ServiceTaxAc, ECess, " & _
                    " ECessAc, HECess, HECessAc) " & _
                    " VALUES (" & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(AgL.PubSiteCode) & ", " & _
                    " " & Val(TxtServiceTax.Text) & ", " & AgL.Chk_Text(TxtServiceTaxAc.AgSelectedValue) & ",	" & _
                    " " & Val(TxtECess.Text) & ", " & AgL.Chk_Text(TxtECessAc.AgSelectedValue) & ",	" & _
                    " " & Val(TxtHECess.Text) & ", " & AgL.Chk_Text(TxtHECessAc.AgSelectedValue) & ")"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With DGL4
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col4Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupExciseItem(Description) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col4Description, I).Value) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL5
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col5Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupExciseParty(Description) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col5Description, I).Value) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL6
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col6PostingGroupExciseItem, I).Value) <> "" And AgL.XNull(.Item(Col6PostingGroupExciseParty, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupExcise(Div_Code, Site_Code, " & _
                                " PostingGroupExciseItem, PostingGroupExciseParty, Excise, " & _
                                " ExciseAc, Cess, CessAc, ECess, ECessAc, HECess, HECessAc) " & _
                                " VALUES (" & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(AgL.PubSiteCode) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col6PostingGroupExciseItem, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col6PostingGroupExciseParty, I).Value) & ", " & _
                                " " & Val(.Item(Col6Excise, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col6ExciseAc, I)) & ", " & _
                                " " & Val(.Item(Col6Cess, I).Value) & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col6CessAc, I)) & ",	" & _
                                " " & Val(.Item(Col6ECess, I).Value) & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col6ECessAc, I)) & ",	" & _
                                " " & Val(.Item(Col6HECess, I).Value) & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col6HECessAc, I)) & ") "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            If AgL.PubManageOfflineData Then Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GcnSite, AgL.ECmdSite)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            If AgL.PubManageOfflineData Then AgL.ETransSite.Commit()
            AgL.ETrans.Commit()
            mTrans = False

            Me.Close()
        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback() : If AgL.PubManageOfflineData Then AgL.ETransSite.Rollback()
            End If
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            With DGL1
                Select Case .CurrentCell.ColumnIndex

                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim I As Integer = 0
        Dim DsTemp As DataSet = Nothing
        Try
            FClear()
            BlankText()
            mQry = "Select PostingGroupSalesTaxItem.* From PostingGroupSalesTaxItem "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL1.RowCount = 1
                DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col1Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupSalesTaxParty.* From PostingGroupSalesTaxParty "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL2.RowCount = 2
                DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col2Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupSalesTax.* From PostingGroupSalesTax "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL3.RowCount = 1
                DGL3.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL3.Rows.Add()
                        DGL3.Item(Col3PostingGroupSalesTaxItem, I).Value = AgL.XNull(.Rows(I)("PostingGroupSalesTaxItem"))
                        DGL3.Item(Col3PostingGroupSalesTaxParty, I).Value = AgL.XNull(.Rows(I)("PostingGroupSalesTaxParty"))
                        DGL3.Item(Col3PurchaseSaleAc, I).Value = AgL.XNull(.Rows(I)("PurchaseSaleAc"))
                        DGL3.Item(Col3SalesTax, I).Value = AgL.VNull(.Rows(I)("SalesTax"))
                        DGL3.Item(Col3SalesTaxAc, I).Value = AgL.XNull(.Rows(I)("SalesTaxAc"))
                        DGL3.Item(Col3VAT, I).Value = AgL.VNull(.Rows(I)("VAT"))
                        DGL3.Item(Col3VatAc, I).Value = AgL.XNull(.Rows(I)("VatAc"))
                        DGL3.Item(Col3AdditionalTax, I).Value = AgL.VNull(.Rows(I)("AdditionalTax"))
                        DGL3.Item(Col3AdditionalTaxAc, I).Value = AgL.XNull(.Rows(I)("AdditionalTaxAc"))
                        DGL3.Item(Col3Cst, I).Value = AgL.VNull(.Rows(I)("Cst"))
                        DGL3.Item(Col3CstAc, I).Value = AgL.XNull(.Rows(I)("CstAc"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupExciseItem.* From PostingGroupExciseItem "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL4.RowCount = 1
                DGL4.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL4.Rows.Add()
                        DGL4.Item(Col4Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupExciseParty.* From PostingGroupExciseParty "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL5.RowCount = 1
                DGL5.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL5.Rows.Add()
                        DGL5.Item(Col5Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupExcise.* From PostingGroupExcise "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL6.RowCount = 1
                DGL6.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL6.Rows.Add()
                        DGL6.Item(Col6PostingGroupExciseItem, I).Value = AgL.XNull(.Rows(I)("PostingGroupExciseItem"))
                        DGL6.Item(Col6PostingGroupExciseParty, I).Value = AgL.XNull(.Rows(I)("PostingGroupExciseParty"))
                        DGL6.Item(Col6Excise, I).Value = AgL.VNull(.Rows(I)("Excise"))
                        DGL6.Item(Col6ExciseAc, I).Value = AgL.VNull(.Rows(I)("ExciseAc"))
                        DGL6.Item(Col6Cess, I).Value = AgL.VNull(.Rows(I)("Cess"))
                        DGL6.Item(Col6CessAc, I).Value = AgL.VNull(.Rows(I)("CessAc"))
                        DGL6.Item(Col6ECess, I).Value = AgL.VNull(.Rows(I)("ECess"))
                        DGL6.Item(Col6ECessAc, I).Value = AgL.VNull(.Rows(I)("ECessAc"))
                        DGL6.Item(Col6HECess, I).Value = AgL.VNull(.Rows(I)("HECess"))
                        DGL6.Item(Col6HECessAc, I).Value = AgL.VNull(.Rows(I)("HECessAc"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupServiceTax.* From PostingGroupServiceTax "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    TxtServiceTax.Text = AgL.VNull(.Rows(0)("ServiceTax"))
                    TxtServiceTaxAc.AgSelectedValue = AgL.XNull(.Rows(0)("ServiceTaxAc"))
                    TxtECess.Text = AgL.VNull(.Rows(0)("ECess"))
                    TxtECessAc.AgSelectedValue = AgL.XNull(.Rows(0)("ECessAc"))
                    TxtHECess.Text = AgL.VNull(.Rows(0)("HECess"))
                    TxtHECessAc.AgSelectedValue = AgL.XNull(.Rows(0)("HECessAc"))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BtnFillSaleTaxGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillSaleTaxGroup.Click
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Try
            DGL3.RowCount = 1
            DGL3.Rows.Clear()
            For I = 0 To DGL1.Rows.Count - 1
                For J = 0 To DGL2.Rows.Count - 1
                    If DGL1.Item(Col1Description, I).Value <> "" And DGL2.Item(Col2Description, J).Value <> "" Then
                        DGL3.Rows.Add()
                        DGL3.Item(Col3PostingGroupSalesTaxItem, K).Value = DGL1.Item(Col1Description, I).Value
                        DGL3.Item(Col3PostingGroupSalesTaxParty, K).Value = DGL2.Item(Col2Description, J).Value
                        K = K + 1
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillExciseTaxGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillExciseTaxGroup.Click
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Try
            DGL6.RowCount = 1
            DGL6.Rows.Clear()
            For I = 0 To DGL4.Rows.Count - 1
                For J = 0 To DGL5.Rows.Count - 1
                    If DGL4.Item(Col4Description, I).Value <> "" And DGL5.Item(Col5Description, J).Value <> "" Then
                        DGL6.Rows.Add()
                        DGL6.Item(Col6PostingGroupExciseItem, K).Value = DGL4.Item(Col4Description, I).Value
                        DGL6.Item(Col6PostingGroupExciseParty, K).Value = DGL5.Item(Col5Description, J).Value
                        K = K + 1
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class