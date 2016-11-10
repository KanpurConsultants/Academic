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


    Protected WithEvents DGL7 As New AgControls.AgDataGrid
    Protected Const Col7Description As String = "Item Entry Tax Group"
    Protected Const Col7Active As String = "Active"

    Protected WithEvents DGL8 As New AgControls.AgDataGrid
    Protected Const Col8Description As String = "Party Entry Tax Group"
    Protected Const Col8Active As String = "Active"

    Protected WithEvents DGL9 As New AgControls.AgDataGrid
    Protected Const Col9PostingGroupEntryTaxItem As String = "Item Entry Tax Group"
    Protected Const Col9PostingGroupEntryTaxParty As String = "Party Entry Tax Group"
    Protected Const Col9EntryTax As String = "Entry Tax"
    Protected Const Col9EntryTaxAc As String = "Entry Tax Ac"

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
            .AddAgTextColumn(DGL2, Col2Description, 400, 20, Col2Description, True, True)
            .AddAgCheckColumn(DGL2, Col2Active, 50, Col2Active, True)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 30
        DGL2.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL3, Col3PostingGroupSalesTaxItem, 150, 20, Col3PostingGroupSalesTaxItem, True, True)
            .AddAgTextColumn(DGL3, Col3PostingGroupSalesTaxParty, 150, 20, Col3PostingGroupSalesTaxParty, True, True)
            .AddAgTextColumn(DGL3, Col3PurchaseSaleAc, 150, 20, Col3PurchaseSaleAc, True, False)
            .AddAgNumberColumn(DGL3, Col3SalesTax, 70, 8, 2, False, Col3SalesTax, True, False)
            .AddAgTextColumn(DGL3, Col3SalesTaxAc, 150, 20, Col3SalesTaxAc, True, False)
            .AddAgNumberColumn(DGL3, Col3VAT, 50, 8, 2, False, Col3VAT, True, False)
            .AddAgTextColumn(DGL3, Col3VatAc, 150, 20, Col3VatAc, True, False)
            .AddAgNumberColumn(DGL3, Col3AdditionalTax, 70, 8, 2, False, Col3AdditionalTax, True, False)
            .AddAgTextColumn(DGL3, Col3AdditionalTaxAc, 150, 20, Col3AdditionalTaxAc, True, False)
            .AddAgNumberColumn(DGL3, Col3Cst, 70, 8, 2, False, Col3Cst, True, False)
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
            .AddAgTextColumn(DGL6, Col6PostingGroupExciseItem, 150, 20, Col6PostingGroupExciseItem, True, True)
            .AddAgTextColumn(DGL6, Col6PostingGroupExciseParty, 150, 20, Col6PostingGroupExciseParty, True, True)
            .AddAgNumberColumn(DGL6, Col6Excise, 70, 8, 2, False, Col6Excise, True, False)
            .AddAgTextColumn(DGL6, Col6ExciseAc, 150, 20, Col6ExciseAc, True, False)
            .AddAgNumberColumn(DGL6, Col6Cess, 70, 8, 2, False, Col6Cess, True, False)
            .AddAgTextColumn(DGL6, Col6CessAc, 150, 20, Col6CessAc, True, False)
            .AddAgNumberColumn(DGL6, Col6ECess, 70, 8, 2, False, Col6ECess, True, False)
            .AddAgTextColumn(DGL6, Col6ECessAc, 150, 20, Col6ECessAc, True, False)
            .AddAgNumberColumn(DGL6, Col6HECess, 70, 8, 2, False, Col6HECess, True, False)
            .AddAgTextColumn(DGL6, Col6HECessAc, 150, 20, Col6HECessAc, True, False)
        End With
        AgL.AddAgDataGrid(DGL6, Pnl6)
        DGL6.ColumnHeadersHeight = 40
        DGL6.EnableHeadersVisualStyles = False
        DGL6.AllowUserToAddRows = False

        With AgCL
            .AddAgTextColumn(DGL7, Col7Description, 400, 20, Col7Description, True, False)
            .AddAgCheckColumn(DGL7, Col7Active, 50, Col7Active, True)
        End With
        AgL.AddAgDataGrid(DGL7, Pnl7)
        DGL7.ColumnHeadersHeight = 30
        DGL7.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL8, Col8Description, 400, 20, Col8Description, True, False)
            .AddAgCheckColumn(DGL8, Col8Active, 50, Col8Active, True)
        End With
        AgL.AddAgDataGrid(DGL8, Pnl8)
        DGL8.ColumnHeadersHeight = 30
        DGL8.EnableHeadersVisualStyles = False

        With AgCL
            .AddAgTextColumn(DGL9, Col9PostingGroupEntryTaxItem, 150, 20, Col9PostingGroupEntryTaxItem, True, True)
            .AddAgTextColumn(DGL9, Col9PostingGroupEntryTaxParty, 150, 20, Col9PostingGroupEntryTaxParty, True, True)
            .AddAgNumberColumn(DGL9, Col9EntryTax, 70, 8, 2, False, Col9EntryTax, True, False)
            .AddAgTextColumn(DGL9, Col9EntryTaxAc, 150, 20, Col9EntryTaxAc, True, False)
        End With
        AgL.AddAgDataGrid(DGL9, Pnl9)
        DGL9.ColumnHeadersHeight = 40
        DGL9.EnableHeadersVisualStyles = False
        DGL9.AllowUserToAddRows = False
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
            AgL.WinSetting(Me, 478, 992)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            AgL.GridDesign(DGL4)
            AgL.GridDesign(DGL5)
            AgL.GridDesign(DGL6)
            AgL.GridDesign(DGL7)
            AgL.GridDesign(DGL8)
            AgL.GridDesign(DGL9)
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

            DGL9.AgHelpDataSet(Col9EntryTaxAc) = TxtServiceTaxAc.AgHelpDataSet.Copy

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupSalesTaxItem "
            DGL1.AgHelpDataSet(Col1Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupSalesTaxParty "
            DGL2.AgHelpDataSet(Col2Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupExciseItem "
            DGL4.AgHelpDataSet(Col4Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupExciseParty "
            DGL5.AgHelpDataSet(Col5Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupEntryTaxParty "
            DGL7.AgHelpDataSet(Col7Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT Description AS Code, Description  FROM PostingGroupEntryTaxItem "
            DGL8.AgHelpDataSet(Col8Description, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left, , True) = AgL.FillData(mQry, AgL.GCn)
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

    'Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
    '    If e.Control And e.KeyCode = Keys.D Then
    '        sender.CurrentRow.Selected = True
    '    End If
    '    If e.Control Or e.Shift Or e.Alt Then Exit Sub
    'End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded, DGL4.RowsAdded, DGL5.RowsAdded, DGL7.RowsAdded, DGL8.RowsAdded
        Try
            If sender.Columns.Contains(Col1Active) Then
                sender.Item(Col1Active, sender.Rows.Count - 1).Value = AgLibrary.ClsConstant.StrUnCheckedValue
            End If
        Catch ex As Exception
        End Try
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
            If AgCL.AgIsDuplicate(DGL2, "" & Col2Description & "") Then Exit Function

            If AgCL.AgIsDuplicate(DGL4, "" & Col4Description & "") Then Exit Function
            If AgCL.AgIsDuplicate(DGL5, "" & Col5Description & "") Then Exit Function

            If AgCL.AgIsDuplicate(DGL7, "" & Col7Description & "") Then Exit Function
            If AgCL.AgIsDuplicate(DGL8, "" & Col8Description & "") Then Exit Function

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

            mQry = "DELETE From PostingGroupSalesTax "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupSalesTaxItem "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupSalesTaxParty "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupServiceTax "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupExcise "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupExciseItem "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupExciseParty "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupEntryTax "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupEntryTaxItem "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "DELETE From PostingGroupEntryTaxParty "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With DGL1
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col1Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupSalesTaxItem(Description, Active) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col1Description, I).Value) & ", " & _
                                " " & IIf(.Item(Col1Active, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue, 0, 1) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL2
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col2Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupSalesTaxParty(Description, Active) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col2Description, I).Value) & ", " & _
                                " " & IIf(.Item(Col2Active, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue, 0, 1) & ") "
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
                        mQry = " INSERT INTO PostingGroupExciseItem(Description, Active) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col4Description, I).Value) & ", " & _
                                " " & IIf(.Item(Col4Active, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue, 0, 1) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL5
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col5Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupExciseParty(Description, Active) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col5Description, I).Value) & ", " & _
                                " " & IIf(.Item(Col5Active, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue, 0, 1) & ") "
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

            With DGL7
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col7Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupEntryTaxItem(Description, Active) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col7Description, I).Value) & ", " & _
                                " " & IIf(.Item(Col7Active, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue, 0, 1) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL8
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col8Description, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupEntryTaxParty(Description, Active) " & _
                                " VALUES (" & AgL.Chk_Text(.Item(Col8Description, I).Value) & ", " & _
                                " " & IIf(.Item(Col8Active, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue, 0, 1) & ") "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            With DGL9
                For I = 0 To .RowCount - 1
                    If AgL.XNull(.Item(Col9PostingGroupEntryTaxItem, I).Value) <> "" And AgL.XNull(.Item(Col9PostingGroupEntryTaxParty, I).Value) <> "" Then
                        mQry = " INSERT INTO PostingGroupEntryTax(Div_Code, Site_Code, " & _
                                " PostingGroupEntryTaxItem, PostingGroupEntryTaxParty, EntryTax, EntryTaxAc) " & _
                                " VALUES (" & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(AgL.PubSiteCode) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col9PostingGroupEntryTaxItem, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col9PostingGroupEntryTaxParty, I).Value) & ", " & _
                                " " & Val(.Item(Col9EntryTax, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col9EntryTaxAc, I)) & ") "

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
                        DGL1.Item(Col1Active, I).Value = IIf(AgL.VNull(.Rows(I)("Active")) = 0, AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL1.Item(Col1Description, I).ReadOnly = True
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
                        DGL2.Item(Col2Active, I).Value = IIf(AgL.VNull(.Rows(I)("Active")) = 0, AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL2.Item(Col2Description, I).ReadOnly = True
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
                        DGL3.AgSelectedValue(Col3PurchaseSaleAc, I) = AgL.XNull(.Rows(I)("PurchaseSaleAc"))
                        DGL3.Item(Col3SalesTax, I).Value = Format(AgL.VNull(.Rows(I)("SalesTax")), "0.00")
                        DGL3.AgSelectedValue(Col3SalesTaxAc, I) = AgL.XNull(.Rows(I)("SalesTaxAc"))
                        DGL3.Item(Col3VAT, I).Value = Format(AgL.VNull(.Rows(I)("VAT")), "0.00")
                        DGL3.AgSelectedValue(Col3VatAc, I) = AgL.XNull(.Rows(I)("VatAc"))
                        DGL3.Item(Col3AdditionalTax, I).Value = Format(AgL.VNull(.Rows(I)("AdditionalTax")), "0.00")
                        DGL3.AgSelectedValue(Col3AdditionalTaxAc, I) = AgL.XNull(.Rows(I)("AdditionalTaxAc"))
                        DGL3.Item(Col3Cst, I).Value = Format(AgL.VNull(.Rows(I)("Cst")), "0.00")
                        DGL3.AgSelectedValue(Col3CstAc, I) = AgL.XNull(.Rows(I)("CstAc"))
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
                        DGL4.Item(Col4Active, I).Value = IIf(AgL.VNull(.Rows(I)("Active")) = 0, AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL4.Item(Col4Description, I).ReadOnly = True
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
                        DGL5.Item(Col5Active, I).Value = IIf(AgL.VNull(.Rows(I)("Active")) = 0, AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL5.Item(Col5Description, I).ReadOnly = True
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
                        DGL6.Item(Col6Excise, I).Value = Format(AgL.VNull(.Rows(I)("Excise")), "0.00")
                        DGL6.AgSelectedValue(Col6ExciseAc, I) = AgL.XNull(.Rows(I)("ExciseAc"))
                        DGL6.Item(Col6Cess, I).Value = Format(AgL.VNull(.Rows(I)("Cess")), "0.00")
                        DGL6.AgSelectedValue(Col6CessAc, I) = AgL.XNull(.Rows(I)("CessAc"))
                        DGL6.Item(Col6ECess, I).Value = Format(AgL.VNull(.Rows(I)("ECess")), "0.00")
                        DGL6.AgSelectedValue(Col6ECessAc, I) = AgL.XNull(.Rows(I)("ECessAc"))
                        DGL6.Item(Col6HECess, I).Value = Format(AgL.VNull(.Rows(I)("HECess")), "0.00")
                        DGL6.AgSelectedValue(Col6HECessAc, I) = AgL.XNull(.Rows(I)("HECessAc"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupEntryTaxItem.* From PostingGroupEntryTaxItem "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL7.RowCount = 1
                DGL7.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL7.Rows.Add()
                        DGL7.Item(Col7Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                        DGL7.Item(Col7Active, I).Value = IIf(AgL.VNull(.Rows(I)("Active")) = 0, AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL7.Item(Col7Description, I).ReadOnly = True
                    Next
                End If
            End With

            mQry = "Select PostingGroupEntryTaxParty.* From PostingGroupEntryTaxParty "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL8.RowCount = 1
                DGL8.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL8.Rows.Add()
                        DGL8.Item(Col8Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                        DGL8.Item(Col8Active, I).Value = IIf(AgL.VNull(.Rows(I)("Active")) = 0, AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL8.Item(Col8Description, I).ReadOnly = True
                    Next
                End If
            End With

            mQry = "Select PostingGroupEntryTax.* From PostingGroupEntryTax "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL9.RowCount = 1
                DGL9.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL9.Rows.Add()
                        DGL9.Item(Col9PostingGroupEntryTaxItem, I).Value = AgL.XNull(.Rows(I)("PostingGroupEntryTaxItem"))
                        DGL9.Item(Col9PostingGroupEntryTaxParty, I).Value = AgL.XNull(.Rows(I)("PostingGroupEntryTaxParty"))
                        DGL9.Item(Col9EntryTax, I).Value = Format(AgL.VNull(.Rows(I)("EntryTax")), "0.00")
                        DGL9.AgSelectedValue(Col9EntryTaxAc, I) = AgL.XNull(.Rows(I)("EntryTaxAc"))
                    Next
                End If
            End With

            mQry = "Select PostingGroupServiceTax.* From PostingGroupServiceTax "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    TxtServiceTax.Text = Format(AgL.VNull(.Rows(0)("ServiceTax")), "0.00")
                    TxtServiceTaxAc.AgSelectedValue = AgL.XNull(.Rows(0)("ServiceTaxAc"))
                    TxtECess.Text = Format(AgL.VNull(.Rows(0)("ECess")), "0.00")
                    TxtECessAc.AgSelectedValue = AgL.XNull(.Rows(0)("ECessAc"))
                    TxtHECess.Text = Format(AgL.VNull(.Rows(0)("HECess")), "0.00")
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
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Try

            mQry = "Declare @TmpTable as Table (" & _
                      " PostingGroupSalesTaxItem nVarchar(255), " & _
                      " PostingGroupSalesTaxParty nVarchar(255), " & _
                      " PurchaseSaleAc nVarchar(255), " & _
                      " SalesTax Float, " & _
                      " SalesTaxAc nVarchar(255), " & _
                      " VAT Float, " & _
                      " VatAc nVarchar(255), " & _
                      " AdditionalTax Float, " & _
                      " AdditionalTaxAc nVarchar(255), " & _
                      " CST Float, " & _
                      " CstAc nVarchar(255) " & _
                      " )"

            For I = 0 To DGL3.RowCount - 1
                mQry += " Insert Into @TmpTable(  " & _
                       " PostingGroupSalesTaxItem , " & _
                       " PostingGroupSalesTaxParty , " & _
                       " PurchaseSaleAc , " & _
                       " SalesTax , " & _
                       " SalesTaxAc , " & _
                       " VAT , " & _
                       " VatAc , " & _
                       " AdditionalTax , " & _
                       " AdditionalTaxAc , " & _
                       " CST , " & _
                       " CstAc) " & _
                       " Values ( " & _
                       " " & AgL.Chk_Text(DGL3.Item(Col3PostingGroupSalesTaxItem, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL3.Item(Col3PostingGroupSalesTaxParty, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL3.AgSelectedValue(Col3PurchaseSaleAc, I)) & ", " & _
                       " " & Val(DGL3.Item(Col3SalesTax, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL3.AgSelectedValue(Col3SalesTaxAc, I)) & ", " & _
                       " " & Val(DGL3.Item(Col3VAT, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL3.AgSelectedValue(Col3VatAc, I)) & ", " & _
                       " " & Val(DGL3.Item(Col3AdditionalTax, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL3.AgSelectedValue(Col3AdditionalTaxAc, I)) & ", " & _
                       " " & Val(DGL3.Item(Col3Cst, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL3.AgSelectedValue(Col3CstAc, I)) & " " & _
                       " )"
            Next

            DGL3.RowCount = 1
            DGL3.Rows.Clear()
            For I = 0 To DGL1.Rows.Count - 1
                For J = 0 To DGL2.Rows.Count - 1
                    If DGL1.Item(Col1Description, I).Value <> "" And AgL.StrCmp(DGL1.Item(Col1Active, I).Value, AgLibrary.ClsConstant.StrCheckedValue) And DGL2.Item(Col2Description, J).Value <> "" And AgL.StrCmp(DGL2.Item(Col2Active, J).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        DGL3.Rows.Add()
                        DGL3.Item(Col3PostingGroupSalesTaxItem, K).Value = DGL1.Item(Col1Description, I).Value
                        DGL3.Item(Col3PostingGroupSalesTaxParty, K).Value = DGL2.Item(Col2Description, J).Value
                        K = K + 1
                    End If
                Next
            Next

            mQry += " Select * from @TmpTable "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        For J = 0 To DGL3.Rows.Count - 1
                            If AgL.XNull(.Rows(I)("PostingGroupSalesTaxItem")) = DGL3.Item(Col3PostingGroupSalesTaxItem, J).Value And AgL.XNull(.Rows(I)("PostingGroupSalesTaxParty")) = DGL3.Item(Col3PostingGroupSalesTaxParty, J).Value Then
                                DGL3.AgSelectedValue(Col3PurchaseSaleAc, J) = AgL.XNull(.Rows(I)("PurchaseSaleAc"))
                                DGL3.Item(Col3SalesTax, J).Value = AgL.VNull(.Rows(I)("SalesTax"))
                                DGL3.AgSelectedValue(Col3SalesTaxAc, J) = AgL.XNull(.Rows(I)("SalesTaxAc"))
                                DGL3.Item(Col3VAT, J).Value = AgL.VNull(.Rows(I)("VAT"))
                                DGL3.AgSelectedValue(Col3VatAc, J) = AgL.XNull(.Rows(I)("VatAc"))
                                DGL3.Item(Col3AdditionalTax, J).Value = AgL.VNull(.Rows(I)("AdditionalTax"))
                                DGL3.AgSelectedValue(Col3AdditionalTaxAc, J) = AgL.XNull(.Rows(I)("AdditionalTaxAc"))
                                DGL3.Item(Col3Cst, J).Value = AgL.VNull(.Rows(I)("Cst"))
                                DGL3.AgSelectedValue(Col3CstAc, J) = AgL.XNull(.Rows(I)("CstAc"))
                            End If
                        Next
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillExciseTaxGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillExciseTaxGroup.Click
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Try

            mQry = "Declare @TmpTable as Table (" & _
                      " PostingGroupExciseItem nVarchar(255), " & _
                      " PostingGroupExciseParty nVarchar(255), " & _
                      " Excise Float, " & _
                      " ExciseAc nVarchar(255), " & _
                      " Cess Float, " & _
                      " CessAc nVarchar(255), " & _
                      " ECess Float, " & _
                      " ECessAc nVarchar(255), " & _
                      " HECess Float, " & _
                      " HECessAc nVarchar(255) " & _
                      " )"

            For I = 0 To DGL6.RowCount - 1
                mQry += " Insert Into @TmpTable(  " & _
                       " PostingGroupExciseItem , " & _
                       " PostingGroupExciseParty , " & _
                       " Excise , " & _
                       " ExciseAc , " & _
                       " Cess , " & _
                       " CessAc , " & _
                       " ECess , " & _
                       " ECessAc , " & _
                       " HECess , " & _
                       " HECessAc) " & _
                       " Values ( " & _
                       " " & AgL.Chk_Text(DGL6.Item(Col6PostingGroupExciseItem, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL6.Item(Col6PostingGroupExciseParty, I).Value) & ", " & _
                       " " & Val(DGL6.Item(Col6Excise, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL6.AgSelectedValue(Col6ExciseAc, I)) & ", " & _
                       " " & Val(DGL6.Item(Col6Cess, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL6.AgSelectedValue(Col6CessAc, I)) & ", " & _
                       " " & Val(DGL6.Item(Col6ECess, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL6.AgSelectedValue(Col6ECessAc, I)) & ", " & _
                       " " & Val(DGL6.Item(Col6HECess, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL6.AgSelectedValue(Col6HECessAc, I)) & " " & _
                       " )"
            Next

            DGL6.RowCount = 1
            DGL6.Rows.Clear()
            For I = 0 To DGL4.Rows.Count - 1
                For J = 0 To DGL5.Rows.Count - 1
                    If DGL4.Item(Col4Description, I).Value <> "" And AgL.StrCmp(DGL4.Item(Col4Active, I).Value, AgLibrary.ClsConstant.StrCheckedValue) And DGL5.Item(Col5Description, J).Value <> "" And AgL.StrCmp(DGL5.Item(Col5Active, J).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        DGL6.Rows.Add()
                        DGL6.Item(Col6PostingGroupExciseItem, K).Value = DGL4.Item(Col4Description, I).Value
                        DGL6.Item(Col6PostingGroupExciseParty, K).Value = DGL5.Item(Col5Description, J).Value
                        K = K + 1
                    End If
                Next
            Next

            mQry += " Select * from @TmpTable "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        For J = 0 To DGL6.Rows.Count - 1
                            If AgL.XNull(.Rows(I)("PostingGroupExciseItem")) = DGL6.Item(Col6PostingGroupExciseItem, J).Value And AgL.XNull(.Rows(I)("PostingGroupExciseParty")) = DGL6.Item(Col6PostingGroupExciseParty, J).Value Then
                                DGL6.Item(Col6Excise, J).Value = AgL.VNull(.Rows(I)("Excise"))
                                DGL6.AgSelectedValue(Col6ExciseAc, J) = AgL.XNull(.Rows(I)("ExciseAc"))
                                DGL6.Item(Col6Cess, J).Value = AgL.VNull(.Rows(I)("Cess"))
                                DGL6.AgSelectedValue(Col6CessAc, J) = AgL.XNull(.Rows(I)("CessAc"))
                                DGL6.Item(Col6ECess, J).Value = AgL.VNull(.Rows(I)("ECess"))
                                DGL6.AgSelectedValue(Col6ECessAc, J) = AgL.XNull(.Rows(I)("ECessAc"))
                                DGL6.Item(Col6HECess, J).Value = AgL.VNull(.Rows(I)("HECess"))
                                DGL6.AgSelectedValue(Col6HECessAc, J) = AgL.XNull(.Rows(I)("HECessAc"))
                            End If
                        Next
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillEntryTaxGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEntryTaxGroup.Click
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Try

            mQry = "Declare @TmpTable as Table (" & _
                      " PostingGroupEntryTaxItem nVarchar(255), " & _
                      " PostingGroupEntryTaxParty nVarchar(255), " & _
                      " EntryTax Float, " & _
                      " EntryTaxAc nVarchar(255) " & _
                      " )"

            For I = 0 To DGL9.RowCount - 1
                mQry += " Insert Into @TmpTable(  " & _
                       " PostingGroupEntryTaxItem , " & _
                       " PostingGroupEntryTaxParty , " & _
                       " EntryTax , " & _
                       " EntryTaxAc) " & _
                       " Values ( " & _
                       " " & AgL.Chk_Text(DGL9.Item(Col9PostingGroupEntryTaxItem, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL9.Item(Col9PostingGroupEntryTaxParty, I).Value) & ", " & _
                       " " & Val(DGL9.Item(Col9EntryTax, I).Value) & ", " & _
                       " " & AgL.Chk_Text(DGL9.AgSelectedValue(Col9EntryTaxAc, I)) & " " & _
                       " )"
            Next

            DGL9.RowCount = 1
            DGL9.Rows.Clear()
            For I = 0 To DGL7.Rows.Count - 1
                For J = 0 To DGL8.Rows.Count - 1
                    If DGL7.Item(Col7Description, I).Value <> "" And AgL.StrCmp(DGL7.Item(Col7Active, I).Value, AgLibrary.ClsConstant.StrCheckedValue) And DGL8.Item(Col8Description, J).Value <> "" And AgL.StrCmp(DGL8.Item(Col8Active, J).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        DGL9.Rows.Add()
                        DGL9.Item(Col9PostingGroupEntryTaxItem, K).Value = DGL7.Item(Col7Description, I).Value
                        DGL9.Item(Col9PostingGroupEntryTaxParty, K).Value = DGL8.Item(Col8Description, J).Value
                        K = K + 1
                    End If
                Next
            Next

            mQry += " Select * from @TmpTable "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        For J = 0 To DGL9.Rows.Count - 1
                            If AgL.XNull(.Rows(I)("PostingGroupEntryTaxItem")) = DGL9.Item(Col9PostingGroupEntryTaxItem, J).Value And AgL.XNull(.Rows(I)("PostingGroupEntryTaxParty")) = DGL9.Item(Col9PostingGroupEntryTaxParty, J).Value Then
                                DGL9.Item(Col9EntryTax, J).Value = AgL.VNull(.Rows(I)("EntryTax"))
                                DGL9.AgSelectedValue(Col9EntryTaxAc, J) = AgL.XNull(.Rows(I)("EntryTaxAc"))
                            End If
                        Next
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown, DGL4.KeyDown, DGL5.KeyDown, DGL7.KeyDown, DGL8.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Active
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(Col1Active).Index)
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp, DGL2.CellMouseUp, DGL4.CellMouseUp, DGL5.CellMouseUp, DGL7.CellMouseUp, DGL8.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Active
                    Call AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(Col1Active).Index)
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class