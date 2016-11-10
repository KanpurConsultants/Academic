Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPeriodicalRecdX
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = ""
    Public mSearchCode As String = ""
    Dim ClsRep As ClsReportProcedures

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Daily General & Periodical"
    Protected Const Col1SubscribedQty As String = "Subs Qty"
    'Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Date1 As String = "1"
    Protected Const Col1Date2 As String = "2"
    Protected Const Col1Date3 As String = "3"
    Protected Const Col1Date4 As String = "4"
    Protected Const Col1Date5 As String = "5"
    Protected Const Col1Date6 As String = "6"
    Protected Const Col1Date7 As String = "7"
    Protected Const Col1Date8 As String = "8"
    Protected Const Col1Date9 As String = "9"
    Protected Const Col1Date10 As String = "10"
    Protected Const Col1Date11 As String = "11"
    Protected Const Col1Date12 As String = "12"
    Protected Const Col1Date13 As String = "13"
    Protected Const Col1Date14 As String = "14"
    Protected Const Col1Date15 As String = "15"
    Protected Const Col1Date16 As String = "16"
    Protected Const Col1Date17 As String = "17"
    Protected Const Col1Date18 As String = "18"
    Protected Const Col1Date19 As String = "19"
    Protected Const Col1Date20 As String = "20"
    Protected Const Col1Date21 As String = "21"
    Protected Const Col1Date22 As String = "22"
    Protected Const Col1Date23 As String = "23"
    Protected Const Col1Date24 As String = "24"
    Protected Const Col1Date25 As String = "25"
    Protected Const Col1Date26 As String = "26"
    Protected Const Col1Date27 As String = "27"
    Protected Const Col1Date28 As String = "28"
    Protected Const Col1Date29 As String = "29"
    Protected Const Col1Date30 As String = "30"
    Protected Const Col1Date31 As String = "31"

    'Temp Columns For DGL1
    'Protected Const Col1XQty As String = "XQty"
    Protected Const Col1XDate1 As String = "X1"
    Protected Const Col1XDate2 As String = "X2"
    Protected Const Col1XDate3 As String = "X3"
    Protected Const Col1XDate4 As String = "X4"
    Protected Const Col1XDate5 As String = "X5"
    Protected Const Col1XDate6 As String = "X6"
    Protected Const Col1XDate7 As String = "X7"
    Protected Const Col1XDate8 As String = "X8"
    Protected Const Col1XDate9 As String = "X9"
    Protected Const Col1XDate10 As String = "X10"
    Protected Const Col1XDate11 As String = "X11"
    Protected Const Col1XDate12 As String = "X12"
    Protected Const Col1XDate13 As String = "X13"
    Protected Const Col1XDate14 As String = "X14"
    Protected Const Col1XDate15 As String = "X15"
    Protected Const Col1XDate16 As String = "X16"
    Protected Const Col1XDate17 As String = "X17"
    Protected Const Col1XDate18 As String = "X18"
    Protected Const Col1XDate19 As String = "X19"
    Protected Const Col1XDate20 As String = "X20"
    Protected Const Col1XDate21 As String = "X21"
    Protected Const Col1XDate22 As String = "X22"
    Protected Const Col1XDate23 As String = "X23"
    Protected Const Col1XDate24 As String = "X24"
    Protected Const Col1XDate25 As String = "X25"
    Protected Const Col1XDate26 As String = "X26"
    Protected Const Col1XDate27 As String = "X27"
    Protected Const Col1XDate28 As String = "X28"
    Protected Const Col1XDate29 As String = "X29"
    Protected Const Col1XDate30 As String = "X30"
    Protected Const Col1XDate31 As String = "X31"
    'End DGL1


    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2Item As String = "Weekly General & Periodical"
    Protected Const Col2SubscribedQty As String = "Subs Qty"
    Protected Const Col2Week1 As String = "Week1"
    Protected Const Col2Week2 As String = "Week2"
    Protected Const Col2Week3 As String = "Week3"
    Protected Const Col2Week4 As String = "Week4"

    Protected Const Col2QtyWeek1 As String = "QtyWeek1"
    Protected Const Col2QtyWeek2 As String = "QtyWeek2"
    Protected Const Col2QtyWeek3 As String = "QtyWeek3"
    Protected Const Col2QtyWeek4 As String = "QtyWeek4"

    Protected Const Col2XWeek1 As String = "XWeek1"
    Protected Const Col2XWeek2 As String = "XWeek2"
    Protected Const Col2XWeek3 As String = "XWeek3"
    Protected Const Col2XWeek4 As String = "XWeek4"

    Protected Const Col2XQtyWeek1 As String = "XQtyWeek1"
    Protected Const Col2XQtyWeek2 As String = "XQtyWeek2"
    Protected Const Col2XQtyWeek3 As String = "XQtyWeek3"
    Protected Const Col2XQtyWeek4 As String = "XQtyWeek4"

    Public WithEvents Dgl3 As New AgControls.AgDataGrid
    Protected Const Col3Item As String = "Fortnightly General & Periodical"
    Protected Const Col3SubscribedQty As String = "Subs Qty"
    Protected Const Col3Fortnight1 As String = "Fortnight1"
    Protected Const Col3Fortnight2 As String = "Fortnight2"

    Protected Const Col3QtyFortnight1 As String = "QtyFortnight1"
    Protected Const Col3QtyFortnight2 As String = "QtyFortnight2"

    Protected Const Col3XFortnight1 As String = "XFortnight1"
    Protected Const Col3XFortnight2 As String = "XFortnight2"

    Protected Const Col3XQtyFortnight1 As String = "XQtyFortnight1"
    Protected Const Col3XQtyFortnight2 As String = "XQtyFortnight2"

    Public WithEvents Dgl4 As New AgControls.AgDataGrid
    Protected Const Col4Item As String = "Monthly General & Periodical"
    Protected Const Col4SubscribedQty As String = "Subs Qty"
    Protected Const Col4ReceiveDate As String = "Receive Date"
    Protected Const Col4XReceiveDate As String = "XReceive Date"
    Protected Const Col4Qty As String = "Qty"
    Protected Const Col4XQty As String = "XQty"

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
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 140, 0, Col1Item, True, True)
            .AddAgNumberColumn(Dgl1, Col1SubscribedQty, 40, 4, 0, False, Col1SubscribedQty, True, True)
            '.AddAgNumberColumn(Dgl1, Col1Qty, 40, 4, 0, False, Col1Qty)
            .AddAgCheckColumn(Dgl1, Col1Date1, 23, Col1Date1, True)
            .AddAgCheckColumn(Dgl1, Col1Date2, 23, Col1Date2, True)
            .AddAgCheckColumn(Dgl1, Col1Date3, 23, Col1Date3, True)
            .AddAgCheckColumn(Dgl1, Col1Date4, 23, Col1Date4, True)
            .AddAgCheckColumn(Dgl1, Col1Date5, 23, Col1Date5, True)
            .AddAgCheckColumn(Dgl1, Col1Date6, 23, Col1Date6, True)
            .AddAgCheckColumn(Dgl1, Col1Date7, 23, Col1Date7, True)
            .AddAgCheckColumn(Dgl1, Col1Date8, 23, Col1Date8, True)
            .AddAgCheckColumn(Dgl1, Col1Date9, 23, Col1Date9, True)
            .AddAgCheckColumn(Dgl1, Col1Date10, 23, Col1Date10, True)
            .AddAgCheckColumn(Dgl1, Col1Date11, 23, Col1Date11, True)
            .AddAgCheckColumn(Dgl1, Col1Date12, 23, Col1Date12, True)
            .AddAgCheckColumn(Dgl1, Col1Date13, 23, Col1Date13, True)
            .AddAgCheckColumn(Dgl1, Col1Date14, 23, Col1Date14, True)
            .AddAgCheckColumn(Dgl1, Col1Date15, 23, Col1Date15, True)
            .AddAgCheckColumn(Dgl1, Col1Date16, 23, Col1Date16, True)
            .AddAgCheckColumn(Dgl1, Col1Date17, 23, Col1Date17, True)
            .AddAgCheckColumn(Dgl1, Col1Date18, 23, Col1Date18, True)
            .AddAgCheckColumn(Dgl1, Col1Date19, 23, Col1Date19, True)
            .AddAgCheckColumn(Dgl1, Col1Date20, 23, Col1Date20, True)
            .AddAgCheckColumn(Dgl1, Col1Date21, 23, Col1Date21, True)
            .AddAgCheckColumn(Dgl1, Col1Date22, 23, Col1Date22, True)
            .AddAgCheckColumn(Dgl1, Col1Date23, 23, Col1Date23, True)
            .AddAgCheckColumn(Dgl1, Col1Date24, 23, Col1Date24, True)
            .AddAgCheckColumn(Dgl1, Col1Date25, 23, Col1Date25, True)
            .AddAgCheckColumn(Dgl1, Col1Date26, 23, Col1Date26, True)
            .AddAgCheckColumn(Dgl1, Col1Date27, 23, Col1Date27, True)
            .AddAgCheckColumn(Dgl1, Col1Date28, 23, Col1Date28, True)
            .AddAgCheckColumn(Dgl1, Col1Date29, 23, Col1Date23, True)
            .AddAgCheckColumn(Dgl1, Col1Date30, 23, Col1Date30, True)
            .AddAgCheckColumn(Dgl1, Col1Date31, 23, Col1Date31, True)


            '.AddAgNumberColumn(Dgl1, Col1XQty, 40, 4, 0, False, Col1XQty, False)
            .AddAgCheckColumn(Dgl1, Col1XDate1, 23, Col1XDate1, False)
            .AddAgCheckColumn(Dgl1, Col1XDate2, 23, Col1XDate2, False)
            .AddAgCheckColumn(Dgl1, Col1XDate3, 23, Col1XDate3, False)
            .AddAgCheckColumn(Dgl1, Col1XDate4, 23, Col1XDate4, False)
            .AddAgCheckColumn(Dgl1, Col1XDate5, 23, Col1XDate5, False)
            .AddAgCheckColumn(Dgl1, Col1XDate6, 23, Col1XDate6, False)
            .AddAgCheckColumn(Dgl1, Col1XDate7, 23, Col1XDate7, False)
            .AddAgCheckColumn(Dgl1, Col1XDate8, 23, Col1XDate8, False)
            .AddAgCheckColumn(Dgl1, Col1XDate9, 23, Col1XDate9, False)
            .AddAgCheckColumn(Dgl1, Col1XDate10, 23, Col1XDate10, False)
            .AddAgCheckColumn(Dgl1, Col1XDate11, 23, Col1XDate11, False)
            .AddAgCheckColumn(Dgl1, Col1XDate12, 23, Col1XDate12, False)
            .AddAgCheckColumn(Dgl1, Col1XDate13, 23, Col1XDate13, False)
            .AddAgCheckColumn(Dgl1, Col1XDate14, 23, Col1XDate14, False)
            .AddAgCheckColumn(Dgl1, Col1XDate15, 23, Col1XDate15, False)
            .AddAgCheckColumn(Dgl1, Col1XDate16, 23, Col1XDate16, False)
            .AddAgCheckColumn(Dgl1, Col1XDate17, 23, Col1XDate17, False)
            .AddAgCheckColumn(Dgl1, Col1XDate18, 23, Col1XDate18, False)
            .AddAgCheckColumn(Dgl1, Col1XDate19, 23, Col1XDate19, False)
            .AddAgCheckColumn(Dgl1, Col1XDate20, 23, Col1XDate20, False)
            .AddAgCheckColumn(Dgl1, Col1XDate21, 23, Col1XDate21, False)
            .AddAgCheckColumn(Dgl1, Col1XDate22, 23, Col1XDate22, False)
            .AddAgCheckColumn(Dgl1, Col1XDate23, 23, Col1XDate23, False)
            .AddAgCheckColumn(Dgl1, Col1XDate24, 23, Col1XDate24, False)
            .AddAgCheckColumn(Dgl1, Col1XDate25, 23, Col1XDate25, False)
            .AddAgCheckColumn(Dgl1, Col1XDate26, 23, Col1XDate26, False)
            .AddAgCheckColumn(Dgl1, Col1XDate27, 23, Col1XDate27, False)
            .AddAgCheckColumn(Dgl1, Col1XDate28, 23, Col1XDate28, False)
            .AddAgCheckColumn(Dgl1, Col1XDate29, 23, Col1XDate23, False)
            .AddAgCheckColumn(Dgl1, Col1XDate30, 23, Col1XDate30, False)
            .AddAgCheckColumn(Dgl1, Col1XDate31, 23, Col1XDate31, False)

        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Pnl1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AllowUserToAddRows = False
        Dgl1.AlternatingRowsDefaultCellStyle.BackColor = Color.Cornsilk
        'Dgl1.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)
        'Dgl1.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 5)

        Dgl1.Columns(Col1Date1).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date2).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date3).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date4).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date5).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date6).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date7).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date8).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date9).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date10).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date11).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date12).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date13).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date14).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date15).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date16).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date17).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date18).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date19).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date20).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date21).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date22).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date23).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date24).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date25).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date26).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date27).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date28).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date29).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date30).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1Date31).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)


        Dgl1.Columns(Col1XDate1).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate2).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate3).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate4).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate5).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate6).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate7).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate8).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate9).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate10).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate11).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate12).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate13).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate14).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate15).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate16).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate17).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate18).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate19).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate20).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate21).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate22).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate23).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate24).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate25).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate26).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate27).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate28).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate29).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate30).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)
        Dgl1.Columns(Col1XDate31).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)



        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Item, 110, 0, Col2Item, True, True)
            .AddAgNumberColumn(Dgl2, Col2SubscribedQty, 40, 4, 0, False, Col2SubscribedQty, True, True)
            .AddAgDateColumn(Dgl2, Col2Week1, 78, Col2Week1, True, False)
            .AddAgDateColumn(Dgl2, Col2Week2, 78, Col2Week2, True, False)
            .AddAgDateColumn(Dgl2, Col2Week3, 78, Col2Week3, True, False)
            .AddAgDateColumn(Dgl2, Col2Week4, 78, Col2Week4, True, False)

            .AddAgNumberColumn(Dgl2, Col2QtyWeek1, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl2, Col2QtyWeek2, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl2, Col2QtyWeek3, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl2, Col2QtyWeek4, 40, 4, 0, False, "Qty")


            .AddAgDateColumn(Dgl2, Col2XWeek1, 80, Col2XWeek1, False, False)
            .AddAgDateColumn(Dgl2, Col2XWeek2, 80, Col2XWeek2, False, False)
            .AddAgDateColumn(Dgl2, Col2XWeek3, 80, Col2XWeek3, False, False)
            .AddAgDateColumn(Dgl2, Col2XWeek4, 80, Col2XWeek4, False, False)

            .AddAgNumberColumn(Dgl2, Col2XQtyWeek1, 40, 4, 0, False, Col2XQtyWeek1, False)
            .AddAgNumberColumn(Dgl2, Col2XQtyWeek2, 40, 4, 0, False, Col2XQtyWeek2, False)
            .AddAgNumberColumn(Dgl2, Col2XQtyWeek3, 40, 4, 0, False, Col2XQtyWeek3, False)
            .AddAgNumberColumn(Dgl2, Col2XQtyWeek4, 40, 4, 0, False, Col2XQtyWeek4, False)

        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.Anchor = AnchorStyles.None
        Pnl2.Anchor = Dgl2.Anchor
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.AllowUserToAddRows = False


        With AgCL
            .AddAgTextColumn(Dgl3, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Item, 190, 0, Col3Item, True, True)
            .AddAgNumberColumn(Dgl3, Col3SubscribedQty, 65, 4, 0, False, Col3SubscribedQty, True, True)
            .AddAgDateColumn(Dgl3, Col3Fortnight1, 140, Col3Fortnight1, True, False)
            .AddAgDateColumn(Dgl3, Col3Fortnight2, 140, Col3Fortnight2, True, False)

            .AddAgNumberColumn(Dgl3, Col3QtyFortnight1, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl3, Col3QtyFortnight2, 40, 4, 0, False, "Qty")

            .AddAgDateColumn(Dgl3, Col3XFortnight1, 125, Col3XFortnight1, False, False)
            .AddAgDateColumn(Dgl3, Col3XFortnight2, 125, Col3XFortnight2, False, False)

            .AddAgNumberColumn(Dgl3, Col3XQtyFortnight1, 40, 4, 0, False, Col3XQtyFortnight1, False)
            .AddAgNumberColumn(Dgl3, Col3XQtyFortnight2, 40, 4, 0, False, Col3XQtyFortnight2, False)
        End With
        AgL.AddAgDataGrid(Dgl3, Pnl3)
        Dgl3.EnableHeadersVisualStyles = False
        Dgl3.Anchor = AnchorStyles.None
        Pnl3.Anchor = Dgl3.Anchor
        Dgl3.ColumnHeadersHeight = 25
        Dgl3.AllowUserToAddRows = False

        With AgCL
            .AddAgTextColumn(Dgl4, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl4, Col4Item, 105, 0, Col4Item, True, True)
            .AddAgNumberColumn(Dgl4, Col4SubscribedQty, 40, 4, 0, False, Col4SubscribedQty, True, True)
            .AddAgDateColumn(Dgl4, Col4ReceiveDate, 78, Col4ReceiveDate, True, False)
            .AddAgDateColumn(Dgl4, Col4XReceiveDate, 105, Col4XReceiveDate, False, False)

            .AddAgNumberColumn(Dgl4, Col4Qty, 30, 4, 0, False, Col4Qty)
            .AddAgNumberColumn(Dgl4, Col4XQty, 40, 4, 0, False, Col4XQty, False)
        End With
        AgL.AddAgDataGrid(Dgl4, Pnl4)
        Dgl4.EnableHeadersVisualStyles = False
        Dgl4.Anchor = AnchorStyles.None
        Pnl4.Anchor = Dgl4.Anchor
        Dgl4.ColumnHeadersHeight = 35
        Dgl4.AllowUserToAddRows = False

        Call ProcSetDispIndex()
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = (Keys.S And e.Control) Then
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
            AgL.WinSetting(Me, 660, 1020, 0, 0)
            AgL.GridDesign(Dgl1)
            AgL.GridDesign(Dgl2)
            AgL.GridDesign(Dgl3)
            AgL.GridDesign(Dgl4)
            IniGrid()
            Topctrl1.ChangeAgGridState(Dgl1, False)
            Topctrl1.ChangeAgGridState(Dgl2, False)
            Topctrl1.ChangeAgGridState(Dgl3, False)
            Topctrl1.ChangeAgGridState(Dgl4, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            'DispText()
            ProcInitializeDate()
            FindMove(FunGetSearchCode(LblV_Date.Tag))
            'MoveRec()
            TxtV_Date.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("C.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("C.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalMonthlyRecd) & ""

            mQry = "Select C.DocId As SearchCode " & _
                    " From PurchChallan C " & _
                    " LEFT JOIN Voucher_Type Vt ON C.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalMonthlyRecd) & ""
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                     " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                     " I.MeasureUnit, I.Measure As MeasurePerPcs, 0 As Rate, 1 As PendingQty, I.Status " & _
                     " FROM Item I"
            Dgl1.AgHelpDataSet(Col1Item, 8) = AgL.FillData(mQry, AgL.GCn)
            Dgl2.AgHelpDataSet(Col2Item, 8) = AgL.FillData(mQry, AgL.GCn)
            Dgl3.AgHelpDataSet(Col3Item, 8) = AgL.FillData(mQry, AgL.GCn)
            Dgl4.AgHelpDataSet(Col4Item, 8) = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        'DispText(True)
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, J As Integer, bSr As Integer
        Dim mTrans As Boolean = False
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO PurchChallan(DocID,	V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                        " Site_Code, EntryBy, EntryDate) " & _
                        " VALUES(" & AgL.Chk_Text(mSearchCode) & ",  " & _
                        " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.Chk_Text(LblV_Date.Tag) & ", " & _
                        " " & Val(TxtV_No.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ") "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "SELECT IsNull(Max(Sr),0)  FROM PurchChallanDetail With (NoLock) WHERE DocId = '" & mSearchCode & "'"
            bSr = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        For J = .Columns(Col1Date1).Index To .Columns(Col1Date31).Index
                            If Not AgL.StrCmp(.Item(.Columns(J).Name, I).Value, .Item("X" & .Columns(J).Name, I).Value) Then
                                If .Item("X" & .Columns(J).Name, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue Then
                                    bSr += 1
                                    mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, Unit, " & _
                                            " V_Date, Edition, SysEdition) " & _
                                            " VALUES ( " & _
                                            " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ", " & _
                                            " " & Val(.Item(Col1Qty, I).Value) & ", 'pcs', " & _
                                            " " & AgL.Chk_Text(FunGetReceiptDate(.Columns(J).Name)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetEdition(.Columns(J).Name, ClsMain.Recurrance.Daily)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Daily)) & " " & _
                                            " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    If .Item(.Columns(J).Name, I).Value <> AgLibrary.ClsConstant.StrUnCheckedValue Then
                                        mQry = "UPDATE PurchChallanDetail " & _
                                                " SET V_Date = " & AgL.Chk_Text(FunGetReceiptDate(.Columns(J).Name)) & ", " & _
                                                " Qty = " & Val(.Item(Col1Qty, I).Value) & " " & _
                                                " WHERE DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Daily)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    Else
                                        mQry = "Delete From PurchChallanDetail " & _
                                                " Where DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Daily)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                End If
                            Else
                                If Val(.Item(Col1Qty, I).Value) <> Val(.Item(Col1XQty, I).Value) Then
                                    mQry = "UPDATE PurchChallanDetail " & _
                                            " SET Qty = " & Val(.Item(Col1Qty, I).Value) & " " & _
                                            " WHERE DocId = '" & mSearchCode & "' " & _
                                            " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & " " & _
                                            " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Daily)) & "  "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                End If
                            End If
                        Next
                    End If
                Next I
            End With

            With Dgl2
                For I = 0 To .Rows.Count - 1
                    For J = .Columns(Col2Week1).Index To .Columns(Col2Week4).Index
                        If .Item(Col2Item, I).Value <> "" Then
                            If (Not AgL.StrCmp(.Item(.Columns(J).Name, I).Value, .Item("X" & .Columns(J).Name, I).Value) _
                                Or Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) <> Val(.Item("X" & FunGetQtyColName(.Columns(J).Name), I).Value)) Then
                                If .Item("X" & .Columns(J).Name, I).Value = "" Then
                                    bSr += 1
                                    mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, " & _
                                            " Unit, V_Date, Edition, SysEdition) " & _
                                            " VALUES ( " & _
                                            " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & ", " & _
                                            " " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & ", 'pcs', " & _
                                            " " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                            " " & AgL.Chk_Text(FunGetEdition(.Columns(J).Name, ClsMain.Recurrance.Weekly)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Weekly)) & " " & _
                                            " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    If .Item(.Columns(J).Name, I).Value <> "" Then
                                        mQry = "UPDATE PurchChallanDetail " & _
                                                " SET V_Date = " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                                " Qty = " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & " " & _
                                                " WHERE DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Weekly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    Else
                                        mQry = "Delete From PurchChallanDetail " & _
                                                " Where DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Weekly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next I
            End With

            With Dgl3
                For I = 0 To .Rows.Count - 1
                    For J = .Columns(Col3Fortnight1).Index To .Columns(Col3Fortnight2).Index
                        If .Item(Col3Item, I).Value <> "" Then
                            If (Not AgL.StrCmp(.Item(.Columns(J).Name, I).Value, .Item("X" & .Columns(J).Name, I).Value) _
                                Or Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) <> Val(.Item("X" & FunGetQtyColName(.Columns(J).Name), I).Value)) Then
                                If .Item("X" & .Columns(J).Name, I).Value = "" Then
                                    bSr += 1
                                    mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, Unit, V_Date, Edition, SysEdition) " & _
                                            " VALUES ( " & _
                                            " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & ", " & _
                                            " " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & ", 'pcs', " & _
                                            " " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                            " " & AgL.Chk_Text(FunGetEdition(.Columns(J).Name, ClsMain.Recurrance.Fortnightly)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Fortnightly)) & " " & _
                                            " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    If .Item(.Columns(J).Name, I).Value <> "" Then
                                        mQry = "UPDATE PurchChallanDetail " & _
                                                " SET V_Date = " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                                " Qty = " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & " " & _
                                                " WHERE DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Fortnightly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    Else
                                        mQry = "Delete From PurchChallanDetail " & _
                                                " Where DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Fortnightly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next I
            End With

            With Dgl4
                For I = 0 To .Rows.Count - 1
                    If .Item(Col4Item, I).Value <> "" Then
                        If (Not AgL.StrCmp(.Item(Col4ReceiveDate, I).Value, .Item(Col4XReceiveDate, I).Value) _
                            Or Val(.Item(Col4Qty, I).Value) <> Val(.Item(Col4XQty, I).Value)) Then
                            If .Item(Col4XReceiveDate, I).Value = "" Then
                                bSr += 1
                                mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, Unit, V_Date, Edition, SysEdition) " & _
                                        " VALUES ( " & _
                                        " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col4Item, I)) & ", " & _
                                        " " & Val(.Item(Col4Qty, I).Value) & ", 'pcs', " & _
                                        " " & AgL.Chk_Text(.Item(Col4ReceiveDate, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(FunGetEdition(Col4ReceiveDate, ClsMain.Recurrance.Monthly)) & ", " & _
                                        " " & AgL.Chk_Text(FunGetSysEdition(Col4ReceiveDate, ClsMain.Recurrance.Monthly)) & " " & _
                                        " )"
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Else
                                If .Item(Col4ReceiveDate, I).Value <> "" Then
                                    mQry = "UPDATE PurchChallanDetail " & _
                                            " SET V_Date = " & AgL.Chk_Text(.Item(Col4ReceiveDate, I).Value) & ",  " & _
                                            " Qty = " & Val(.Item(Col4Qty, I).Value) & " " & _
                                            " WHERE DocId = '" & mSearchCode & "' " & _
                                            " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col4Item, I)) & " " & _
                                            " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(Col4ReceiveDate, ClsMain.Recurrance.Monthly)) & "  "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    mQry = "Delete From PurchChallanDetail " & _
                                            " Where DocId = '" & mSearchCode & "' " & _
                                            " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col4Item, I)) & " " & _
                                            " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(Col4ReceiveDate, ClsMain.Recurrance.Monthly)) & "  "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                End If
                            End If
                        End If
                    End If
                Next I
            End With

            Call ProcPostStock(AgL.GCn, AgL.ECmd)

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

            Topctrl1.SetDisp(True)
            If AgL.PubMoveRecApplicable Then MoveRec()

            'If Topctrl1.Mode = "Add" Then
            '    Topctrl1.LblDocId.Text = mSearchCode

            '    mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

            '    Topctrl1.FButtonClick(0)
            '    Exit Sub
            'Else
            '    mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

            '    Topctrl1.SetDisp(True)
            '    If AgL.PubMoveRecApplicable Then MoveRec()
            'End If

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
        Dim bStreamYearSemester$ = ""
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Dim ColName$ = "", XColName$ = "", QtyColName$ = "", XQtyColName$ = ""

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            'mSearchCode = FunGetSearchCode(LblV_Date.Tag)
            If mSearchCode <> "" Then
                mQry = "Select C.*, Vt.NCat " & _
                          " From PurchChallan C " & _
                          " Left Join Voucher_Type Vt On C.V_Type = Vt.V_Type " & _
                          " Where C.DocId = '" & mSearchCode & "' "

                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtV_Date.Text = CDate(LblV_Date.Tag).ToString("MMM/yyyy")
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                    End If
                End With

                'mQry = "Select Cd.* " & _
                '        " from PurchChallanDetail Cd " & _
                '        " LEFT JOIN Lib_Generals G On Cd.Item = G.Code" & _
                '        " Where Cd.DocId = '" & mSearchCode & "' " & _
                '        " And G.Recurrance = '" & ClsMain.Recurrance.Daily & "' " & _
                '        " Order By Cd.Item "

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Daily & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE ('" & LblV_Date.Tag & "' BETWEEN S.FromDate AND S.ToDate Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Daily & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If K < .Rows.Count Then
                                Dgl1.Rows.Add()
                                Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                                Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(K)("Item"))
                                Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(K)("Qty"))
                                Dgl1.Item(Col1XQty, I).Value = AgL.VNull(.Rows(K)("Qty"))
                                Dgl1.Item(Col1SubscribedQty, I).Value = AgL.VNull(.Rows(K)("SubscribedQty"))
                                For J = 0 To .Rows.Count - 1
                                    If Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(J)("Item")) Then
                                        If AgL.XNull(.Rows(J)("V_Date")) <> "" Then
                                            ColName = CDate(AgL.XNull(.Rows(J)("V_Date"))).Day.ToString
                                            XColName = "X" & ColName
                                            Dgl1.Item(ColName, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                                            Dgl1.Item(XColName, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                                        End If
                                        K = K + 1
                                    End If
                                Next
                            End If
                        Next I
                    End If
                End With


                'mQry = "Select Cd.* " & _
                '        " from PurchChallanDetail Cd " & _
                '        " LEFT JOIN Lib_Generals G On Cd.Item = G.Code" & _
                '        " Where Cd.DocId = '" & mSearchCode & "' " & _
                '        " And G.Recurrance = '" & ClsMain.Recurrance.Weekly & "' " & _
                '        " Order By Cd.Item "

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty   " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Weekly & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE ('" & LblV_Date.Tag & "' BETWEEN S.FromDate AND S.ToDate Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Weekly & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl2.RowCount = 1
                    Dgl2.Rows.Clear()
                    K = 0
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If K < .Rows.Count Then
                                Dgl2.Rows.Add()
                                Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                                Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(K)("Item"))
                                Dgl2.Item(Col2SubscribedQty, I).Value = AgL.VNull(.Rows(K)("SubscribedQty"))
                                For J = 0 To .Rows.Count - 1
                                    If Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(J)("Item")) Then
                                        If AgL.XNull(.Rows(J)("SysEdition")) <> "" Then
                                            ColName = FunGetColumnName(AgL.XNull(.Rows(J)("SysEdition")), ClsMain.Recurrance.Weekly)
                                            XColName = "X" & ColName
                                            QtyColName = FunGetQtyColName(ColName)
                                            XQtyColName = "X" & QtyColName
                                            Dgl2.Item(ColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl2.Item(XColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl2.Item(QtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                            Dgl2.Item(XQtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                        End If
                                        K = K + 1
                                    End If
                                Next
                            End If
                        Next I
                    End If
                End With

                'mQry = "Select Cd.* " & _
                '        " from PurchChallanDetail Cd " & _
                '        " LEFT JOIN Lib_Generals G On Cd.Item = G.Code" & _
                '        " Where Cd.DocId = '" & mSearchCode & "' " & _
                '        " And G.Recurrance = '" & ClsMain.Recurrance.Fortnightly & "' " & _
                '        " Order By Cd.Item "

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Fortnightly & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE ('" & LblV_Date.Tag & "' BETWEEN S.FromDate AND S.ToDate Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Fortnightly & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl3.RowCount = 1
                    Dgl3.Rows.Clear()
                    K = 0
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If K < .Rows.Count Then
                                Dgl3.Rows.Add()
                                Dgl3.Item(ColSNo, I).Value = Dgl3.Rows.Count
                                Dgl3.AgSelectedValue(Col3Item, I) = AgL.XNull(.Rows(K)("Item"))
                                Dgl3.Item(Col3SubscribedQty, I).Value = AgL.VNull(.Rows(K)("SubscribedQty"))
                                For J = 0 To .Rows.Count - 1
                                    If Dgl3.AgSelectedValue(Col3Item, I) = AgL.XNull(.Rows(J)("Item")) Then
                                        If AgL.XNull(.Rows(J)("SysEdition")) <> "" Then
                                            ColName = FunGetColumnName(AgL.XNull(.Rows(J)("SysEdition")), ClsMain.Recurrance.Fortnightly)
                                            XColName = "X" & ColName
                                            QtyColName = FunGetQtyColName(ColName)
                                            XQtyColName = "X" & QtyColName
                                            Dgl3.Item(ColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl3.Item(XColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl3.Item(QtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                            Dgl3.Item(XQtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                        End If
                                        K = K + 1
                                    End If
                                Next
                            End If
                        Next I
                    End If
                End With

                'mQry = "Select Cd.* " & _
                '       " from PurchChallanDetail Cd " & _
                '       " LEFT JOIN Lib_Generals G On Cd.Item = G.Code" & _
                '       " Where Cd.DocId = '" & mSearchCode & "' " & _
                '       " And G.Recurrance = '" & ClsMain.Recurrance.Monthly & "' "

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty   " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Monthly & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE ('" & LblV_Date.Tag & "' BETWEEN S.FromDate AND S.ToDate Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Monthly & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl4.RowCount = 1
                    Dgl4.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgl4.Rows.Add()
                            Dgl4.Item(ColSNo, I).Value = Dgl4.Rows.Count
                            Dgl4.AgSelectedValue(Col4Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl4.Item(Col4ReceiveDate, I).Value = AgL.XNull(.Rows(I)("V_Date"))
                            Dgl4.Item(Col4XReceiveDate, I).Value = AgL.XNull(.Rows(I)("V_Date"))
                            Dgl4.Item(Col4Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl4.Item(Col4XQty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl4.Item(Col4SubscribedQty, I).Value = AgL.VNull(.Rows(I)("SubscribedQty"))
                        Next I
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
            If Strings.Mid(Topctrl1.Tag, 2, 1) = "E" Then Topctrl1.FButtonClick(1)
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        Dgl3.RowCount = 1 : Dgl3.Rows.Clear()
        Dgl4.RowCount = 1 : Dgl4.Rows.Clear()
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.CurrentCell.ColumnIndex

                'Case Col1PurjaDocId
                '    Call IniPurjaHelp(False, TxtJobWorker.AgSelectedValue)

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl1
                Select Case .CurrentCell.ColumnIndex
                    'Case Col1Purja1GUID

                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        Dim I As Integer = 0
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
        Try
            With Dgl1
                For I = .Columns(Col1Date1).Index To .Columns(Col1XDate31).Index
                    If .Columns(I).Name <> ColSNo And .Columns(I).Name <> Col1Item Then
                        sender.Item(I, sender.Rows.Count - 1).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                    End If
                Next
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl2.RowsAdded, Dgl3.RowsAdded, Dgl4.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_Date.Validating, TxtV_No.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                        End If
                    End If

                Case TxtV_Date.Name
                    ProcInitializeDate()
                    If FunGetSearchCode(LblV_Date.Tag) = "" Then
                        If Strings.Mid(Topctrl1.Tag, 1, 1) = "A" Then
                            Topctrl1.FButtonClick(0, True)
                            ProcInitializeForm()
                        Else
                            MsgBox("Permission Denied...!", MsgBoxStyle.Information)
                            MoveRec()
                        End If
                    Else
                        FindMove(FunGetSearchCode(LblV_Date.Tag))
                        'Topctrl1.FButtonClick(1, True)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bFlag As Boolean = False
        Dim bStudentCode$ = ""
        Try

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type, LblV_Type.Text) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            'If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function

            AgCL.AgBlankNothingCells(Dgl1)


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        For J = .Columns(Col1Date1).Index To .Columns(Col1Date31).Index
                            If AgL.StrCmp(.Item(J, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                                bFlag = True : Exit For
                            End If
                        Next
                        If bFlag = True Then
                            MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                            .CurrentCell = .Item(Col1Qty, I) : .Focus()
                            Exit Function
                        End If
                    End If
                Next
            End With

            With Dgl2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Week1, I).Value <> "" And Val(.Item(Col2QtyWeek1, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyWeek1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week1, I).Value = "" And Val(.Item(Col2QtyWeek1, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Week1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week2, I).Value <> "" And Val(.Item(Col2QtyWeek2, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyWeek2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week2, I).Value = "" And Val(.Item(Col2QtyWeek2, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Week2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week3, I).Value <> "" And Val(.Item(Col2QtyWeek3, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyWeek3, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week3, I).Value = "" And Val(.Item(Col2QtyWeek3, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Week3, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week4, I).Value <> "" And Val(.Item(Col2QtyWeek4, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyWeek4, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Week4, I).Value = "" And Val(.Item(Col2QtyWeek4, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Week4, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With

            With Dgl3
                For I = 0 To .Rows.Count - 1
                    If .Item(Col3Fortnight1, I).Value <> "" And Val(.Item(Col3QtyFortnight1, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3QtyFortnight1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col3Fortnight1, I).Value = "" And Val(.Item(Col3QtyFortnight1, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3Fortnight1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col3Fortnight2, I).Value <> "" And Val(.Item(Col3QtyFortnight2, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3QtyFortnight2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col3Fortnight2, I).Value = "" And Val(.Item(Col3QtyFortnight2, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3Fortnight2, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With

            With Dgl4
                For I = 0 To .Rows.Count - 1
                    If .Item(Col4ReceiveDate, I).Value <> "" And Val(.Item(Col4Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col4Qty, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col4ReceiveDate, I).Value = "" And Val(.Item(Col4Qty, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col4ReceiveDate, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If
            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If


        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus()
        End If

        If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
            mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            TxtDocId.Text = mSearchCode
            TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
            LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
        End If

    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Try
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Item, ColSNo, Col1Qty, Col1SubscribedQty, Col1XQty


                Case Else
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(sender.Columns(sender.CurrentCell.ColumnIndex).Name).Index)
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl1.CellMouseUp
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Item, ColSNo, Col1Qty, Col1SubscribedQty, Col1XQty

                Case Else
                    Call AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(sender.Columns(sender.CurrentCell.ColumnIndex).Name).Index)

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProcInitializeForm()
        If TxtV_Date.Text <> "" Then
            LblV_Date.Tag = AgL.RetMonthStartDate(TxtV_Date.Text)
            TxtV_Date.Text = CDate(TxtV_Date.Text).ToString("MMM/yyyy")
        End If
        Call ProcFillItems(Dgl1, Col1Item, Col1SubscribedQty, ClsMain.Recurrance.Daily)
        Call ProcFillItems(Dgl2, Col2Item, Col2SubscribedQty, ClsMain.Recurrance.Weekly)
        Call ProcFillItems(Dgl3, Col3Item, Col3SubscribedQty, ClsMain.Recurrance.Fortnightly)
        Call ProcFillItems(Dgl4, Col4Item, Col4SubscribedQty, ClsMain.Recurrance.Monthly)
    End Sub

    Private Sub ProcFillItems(ByVal DGL As AgControls.AgDataGrid, ByVal ColIndexItem As String, ByVal ColIndexSubscribedQty As String, ByVal Recurrance As String)
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer
        Try
            mQry = "SELECT S.General AS Item, S.Qty As SubscribedQty " & _
                    " FROM Lib_Subscription S " & _
                    " WHERE ('" & LblV_Date.Tag & "' BETWEEN S.FromDate AND S.ToDate " & _
                    " Or S.ToDate Is Null) " & _
                    " AND S.Recurrance = '" & Recurrance & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL.RowCount = 1
                DGL.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        DGL.Rows.Add()
                        DGL.Item(ColSNo, I).Value = DGL.Rows.Count
                        DGL.AgSelectedValue(ColIndexItem, I) = AgL.XNull(.Rows(I)("Item"))
                        DGL.Item(ColIndexSubscribedQty, I).Value = AgL.XNull(.Rows(I)("SubscribedQty"))
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunGetReceiptDate(ByVal ColName As String) As String
        Dim ReceiptDate$ = ""
        Try
            ReceiptDate = ColName + "/" + TxtV_Date.Text
            FunGetReceiptDate = ReceiptDate
        Catch ex As Exception
            FunGetReceiptDate = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunGetEdition(ByVal ColName As String, ByVal Recurrance As String) As String
        Dim Edition$ = ""
        Try
            Select Case Recurrance
                Case ClsMain.Recurrance.Daily
                    Edition = ColName + "/" + TxtV_Date.Text

                Case ClsMain.Recurrance.Weekly
                    Select Case ColName
                        Case Col2Week1
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Week1

                        Case Col2Week2
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Week2

                        Case Col2Week3
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Week3

                        Case Col2Week4
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Week4
                    End Select

                Case ClsMain.Recurrance.Fortnightly
                    Select Case ColName
                        Case Col3Fortnight1
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Fortnight1

                        Case Col3Fortnight2
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Fortnight2
                    End Select

                Case ClsMain.Recurrance.Monthly
                    Edition = TxtV_Date.Text


            End Select
            FunGetEdition = Edition
        Catch ex As Exception
            FunGetEdition = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunGetSysEdition(ByVal ColName As String, ByVal Recurrance As String) As String
        Dim SysEdition$ = ""
        Try
            Select Case Recurrance
                Case ClsMain.Recurrance.Daily
                    SysEdition = ColName

                Case ClsMain.Recurrance.Weekly
                    Select Case ColName
                        Case Col2Week1
                            SysEdition = ClsMain.Temp_SysEdition.Week1

                        Case Col2Week2
                            SysEdition = ClsMain.Temp_SysEdition.Week2

                        Case Col2Week3
                            SysEdition = ClsMain.Temp_SysEdition.Week3

                        Case Col2Week4
                            SysEdition = ClsMain.Temp_SysEdition.Week4
                    End Select

                Case ClsMain.Recurrance.Fortnightly
                    Select Case ColName
                        Case Col3Fortnight1
                            SysEdition = ClsMain.Temp_SysEdition.Fortnight1

                        Case Col3Fortnight2
                            SysEdition = ClsMain.Temp_SysEdition.Fortnight2
                    End Select

                Case ClsMain.Recurrance.Monthly
                    SysEdition = TxtV_Date.Text


            End Select
            FunGetSysEdition = SysEdition
        Catch ex As Exception
            FunGetSysEdition = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunGetColumnName(ByVal SysEdition As String, ByVal Recurrance As String) As String
        Dim ColumnName$ = ""
        Try
            Select Case Recurrance
                Case ClsMain.Recurrance.Weekly
                    Select Case SysEdition
                        Case ClsMain.Temp_SysEdition.Week1
                            ColumnName = Col2Week1

                        Case ClsMain.Temp_SysEdition.Week2
                            ColumnName = Col2Week2

                        Case ClsMain.Temp_SysEdition.Week3
                            ColumnName = Col2Week3

                        Case ClsMain.Temp_SysEdition.Week4
                            ColumnName = Col2Week4
                    End Select

                Case ClsMain.Recurrance.Fortnightly
                    Select Case SysEdition
                        Case ClsMain.Temp_SysEdition.Fortnight1
                            ColumnName = Col3Fortnight1

                        Case ClsMain.Temp_SysEdition.Fortnight2
                            ColumnName = Col3Fortnight2
                    End Select
            End Select
            FunGetColumnName = ColumnName
        Catch ex As Exception
            FunGetColumnName = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call Topctrl_tbSave()
    End Sub

    Private Function FunGetSearchCode(ByVal VDate As String) As String
        Dim bSearchCode$ = ""
        Try
            mQry = "SELECT C.DocID " & _
                    " FROM PurchChallan C " & _
                    " LEFT JOIN Voucher_Type Vt ON C.V_Type = Vt.V_Type " & _
                    " WHERE C.V_Date = '" & VDate & "' " & _
                    " And Vt.NCat = '" & ClsMain.Temp_NCat.GeneralPeriodicalMonthlyRecd & "' "
            bSearchCode = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar
            FunGetSearchCode = bSearchCode
        Catch ex As Exception
            FunGetSearchCode = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub FindMove(ByVal bDocId As String)
        Dim Cnt As Integer = 0
        Try
            If bDocId <> "" Then
                AgL.PubSearchRow = bDocId
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                Call MoveRec()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcInitializeDate()
        Try
            If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
            If TxtV_Date.Text <> "" Then
                LblV_Date.Tag = AgL.RetMonthStartDate(TxtV_Date.Text)
                TxtV_Date.Text = CDate(TxtV_Date.Text).ToString("MMM/yyyy")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcPostStock(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Try
            mQry = "DELETE From Stock Where DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "INSERT INTO Stock(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, Item, Qty_Rec, Unit, Edition) " & _
                    " SELECT Cd.DocId, Cd.Sr, C.V_Type, C.V_Prefix, Cd.V_Date, C.V_No, C.Div_Code, C.Site_Code, Cd.Item, Cd.Qty, Cd.Unit, Cd.Edition " & _
                    " FROM PurchChallan C With (NoLock)" & _
                    " LEFT JOIN PurchChallanDetail Cd  With (NoLock) ON C.DocID = Cd.DocId " & _
                    " WHERE Cd.DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunGetQtyColName(ByVal ColName As String)
        Try
            FunGetQtyColName = "Qty" & ColName
        Catch ex As Exception
            FunGetQtyColName = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ProcSetDispIndex()
        Try
            With Dgl2
                .Columns(Col2QtyWeek1).DisplayIndex = .Columns(Col2Week1).DisplayIndex + 1
                .Columns(Col2QtyWeek2).DisplayIndex = .Columns(Col2Week2).DisplayIndex + 1
                .Columns(Col2QtyWeek3).DisplayIndex = .Columns(Col2Week3).DisplayIndex + 1
                .Columns(Col2QtyWeek4).DisplayIndex = .Columns(Col2Week4).DisplayIndex + 1
            End With

            With Dgl3
                .Columns(Col3QtyFortnight1).DisplayIndex = .Columns(Col3Fortnight1).DisplayIndex + 1
                .Columns(Col3QtyFortnight2).DisplayIndex = .Columns(Col3Fortnight2).DisplayIndex + 1
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl2.CurrentCell.RowIndex
            mColumnIndex = Dgl2.CurrentCell.ColumnIndex

            If Dgl2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl2.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl2
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col2Week1
                        .Item(Col2QtyWeek1, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)

                    Case Col2Week2
                        .Item(Col2QtyWeek2, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)

                    Case Col2Week3
                        .Item(Col2QtyWeek3, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)

                    Case Col2Week4
                        .Item(Col2QtyWeek4, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Dgl3_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl3.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl3.CurrentCell.RowIndex
            mColumnIndex = Dgl3.CurrentCell.ColumnIndex

            If Dgl3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl3.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl3
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col3Fortnight1
                        .Item(Col3QtyFortnight1, mRowIndex).Value = Val(.Item(Col3SubscribedQty, mRowIndex).Value)

                    Case Col3Fortnight2
                        .Item(Col3QtyFortnight2, mRowIndex).Value = Val(.Item(Col3SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl4_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl4.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl4.CurrentCell.RowIndex
            mColumnIndex = Dgl4.CurrentCell.ColumnIndex

            If Dgl4.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl4.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl4
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col4ReceiveDate
                        .Item(Col4Qty, mRowIndex).Value = Val(.Item(Col4SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class