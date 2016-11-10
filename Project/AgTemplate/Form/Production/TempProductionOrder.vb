Imports CrystalDecisions.CrystalReports.Engine
Public Class TempProductionOrder
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "MeasureUnit"
    Protected Const Col1ProdPlanQty As String = "ProdPlanQty"
    Protected WithEvents TxtManualOrderNo As AgControls.AgTextBox
    Protected WithEvents LblManualOrderNo As System.Windows.Forms.Label
    Protected WithEvents LblManualOrderNoReq As System.Windows.Forms.Label
    Protected WithEvents LblProductionOrderDetail As System.Windows.Forms.LinkLabel
    Protected Const Col1ProdPlanMeasure As String = "ProdPlanMeasure"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub TempProductionOrder_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE SaleOrderDetail " & _
                           " SET ProdOrdQty = ProdOrdQty - " & Val(.Item(Col1Qty, I).Value) & "," & _
                           " ProdOrdMeasure = ProdOrdMeasure - " & Val(.Item(Col1TotalMeasure, I).Value) & " " & _
                           " Where DocId = '" & TxtSaleOrderNo.AgSelectedValue & "' And Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = " SELECT Po.UID, Po.V_Date AS [Entry Date], " & _
        '                    " PO.V_Type + '-' + Convert(NVARCHAR,Po.V_No) AS [Entry No], PO.ManualRefNo AS [Manual No]," & _
        '                    " SO.V_Type + '-' + Convert(nVarChar,So.V_No) As [Sale Order No], SO.PartyOrderNo as [Sale Order - Party Doc No], Po.DueDate  " & _
        '                    " FROM ProdOrder Po " & _
        '                    " LEFT JOIN Voucher_type Vt ON Po.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN SaleOrder So On Po.SaleOrder  = So.DocId " & _
        '                    " LEFT JOIN Voucher_type V ON So.V_Type = V.V_Type " & _
        '                    " Where Po.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [ORDER Type], H.V_Prefix AS [Prefix], H.V_Date AS [ORDER Date], H.V_No AS [ORDER No], " & _
            " H.DueDate AS [Due Date], H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.Remarks, H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date],  " & _
            " H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date],  " & _
            " H.Status,  H.ManualRefNo AS [Manual No], " & _
            " D.Div_Name AS Division,SM.Name AS [Site Name], SO.V_Type + '-' + convert(NVARCHAR,SO.V_No) AS [Sale ORDER No] " & _
            " FROM  ProdOrder_Log H " & _
            " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
            " LEFT JOIN SaleOrder SO ON SO.DocID=H.SaleOrder  " & _
             " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And IsNull(H.IsDeleted,0)=0  And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT Po.DocID, Po.V_Date AS [Entry Date], " & _
        '                    " PO.V_Type + '-' + Convert(NVARCHAR,Po.V_No) AS [Entry No], PO.ManualRefNo AS [Manual No]," & _
        '                    " SO.V_Type + '-' + Convert(nVarChar,So.V_No) As [Sale Order No], SO.PartyOrderNo as [Sale Order - Party Doc No], Po.DueDate  " & _
        '                    " FROM ProdOrder Po " & _
        '                    " LEFT JOIN Voucher_type Vt ON Po.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN SaleOrder So On Po.SaleOrder  = So.DocId " & _
        '                    " LEFT JOIN Voucher_type V ON So.V_Type = V.V_Type " & _
        '                    " Where 1=1 " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Prod.Order Type], H.V_Prefix AS [Prefix], H.V_Date AS [Prod.Order Date], H.V_No AS [Prod.Order No], " & _
                            " H.DueDate AS [Due Date], H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.Remarks, " & _
                            " H.Status,  H.ManualRefNo AS [Prod.Order Manual No], " & _
                            " D.Div_Name AS Division,SM.Name AS [Site Name], SO.V_Type + '-' + convert(NVARCHAR,SO.V_No) AS [Sale ORDER No], SO.PartyOrderNo AS [Sale Party Order No] " & _
                            " FROM  ProdOrder H " & _
                            " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
                            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SaleOrder SO ON SO.DocID=H.SaleOrder  " & _
                            " Where 1=1 " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "ProdOrder"
        LogTableName = "ProdOrder_Log"
        MainLineTableCsv = "ProdOrderDetail"
        LogLineTableCsv = "ProdOrderDetail_LOG"

        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("Po.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("Po.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "Po.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select Po.DocID As SearchCode " & _
            " From ProdOrder Po " & _
            " Left Join Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
            " Where IsNull(IsDeleted,0) = 0  " & mCondStr & "  Order By Po.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("Po.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("Po.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "Po.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select Po.UID As SearchCode " & _
               " From ProdOrder_Log Po " & _
               " Left Join Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
               " Where Po.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    

#Region "Form Designer Code"


    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtDueDate = New AgControls.AgTextBox
        Me.LblDueDate = New System.Windows.Forms.Label
        Me.TxtSaleOrderNo = New AgControls.AgTextBox
        Me.LblSaleOrderNo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblDueDateReq = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.TxtDeliveryDate = New AgControls.AgTextBox
        Me.LblDeliveryDate = New System.Windows.Forms.Label
        Me.TxtManualOrderNo = New AgControls.AgTextBox
        Me.LblManualOrderNo = New System.Windows.Forms.Label
        Me.LblManualOrderNoReq = New System.Windows.Forms.Label
        Me.LblProductionOrderDetail = New System.Windows.Forms.LinkLabel
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 482)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(29, 19)
        Me.TxtStatus.Tag = ""
        '
        'CmdStatus
        '
        Me.CmdStatus.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 482)
        Me.GBoxMoveToLog.Size = New System.Drawing.Size(148, 40)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 19)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 482)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(29, 19)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Size = New System.Drawing.Size(26, 19)
        '
        'CmdApprove
        '
        Me.CmdApprove.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 482)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 482)
        Me.GrpUP.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 478)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 482)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
        Me.TxtDivision.Tag = ""
        '
        'TxtDocId
        '
        Me.TxtDocId.AgSelectedValue = ""
        Me.TxtDocId.BackColor = System.Drawing.Color.White
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(465, 36)
        Me.LblV_No.Size = New System.Drawing.Size(64, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Order No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(587, 35)
        Me.TxtV_No.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(343, 41)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(247, 36)
        Me.LblV_Date.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Order Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(571, 21)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(359, 35)
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(465, 17)
        Me.LblV_Type.Size = New System.Drawing.Size(72, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Order Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(587, 15)
        Me.TxtV_Type.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(343, 21)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(247, 16)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(359, 15)
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(525, 36)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 19)
        Me.TabControl1.Size = New System.Drawing.Size(990, 154)
        Me.TabControl1.TabIndex = 22
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.LblManualOrderNoReq)
        Me.TP1.Controls.Add(Me.TxtManualOrderNo)
        Me.TP1.Controls.Add(Me.LblManualOrderNo)
        Me.TP1.Controls.Add(Me.TxtDeliveryDate)
        Me.TP1.Controls.Add(Me.LblDeliveryDate)
        Me.TP1.Controls.Add(Me.LblDueDateReq)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtDueDate)
        Me.TP1.Controls.Add(Me.LblDueDate)
        Me.TP1.Controls.Add(Me.TxtSaleOrderNo)
        Me.TP1.Controls.Add(Me.LblSaleOrderNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(982, 128)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDueDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDueDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDueDateReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualOrderNoReq, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        '
        'Dgl1
        '
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'TxtDueDate
        '
        Me.TxtDueDate.AgMandatory = False
        Me.TxtDueDate.AgMasterHelp = True
        Me.TxtDueDate.AgNumberLeftPlaces = 8
        Me.TxtDueDate.AgNumberNegetiveAllow = False
        Me.TxtDueDate.AgNumberRightPlaces = 2
        Me.TxtDueDate.AgPickFromLastValue = False
        Me.TxtDueDate.AgRowFilter = ""
        Me.TxtDueDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDueDate.AgSelectedValue = Nothing
        Me.TxtDueDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDueDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDueDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDueDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDueDate.Location = New System.Drawing.Point(359, 75)
        Me.TxtDueDate.MaxLength = 20
        Me.TxtDueDate.Name = "TxtDueDate"
        Me.TxtDueDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtDueDate.TabIndex = 12
        '
        'LblDueDate
        '
        Me.LblDueDate.AutoSize = True
        Me.LblDueDate.BackColor = System.Drawing.Color.Transparent
        Me.LblDueDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDueDate.Location = New System.Drawing.Point(247, 76)
        Me.LblDueDate.Name = "LblDueDate"
        Me.LblDueDate.Size = New System.Drawing.Size(62, 16)
        Me.LblDueDate.TabIndex = 708
        Me.LblDueDate.Text = "Due Date"
        '
        'TxtSaleOrderNo
        '
        Me.TxtSaleOrderNo.AgMandatory = False
        Me.TxtSaleOrderNo.AgMasterHelp = False
        Me.TxtSaleOrderNo.AgNumberLeftPlaces = 8
        Me.TxtSaleOrderNo.AgNumberNegetiveAllow = False
        Me.TxtSaleOrderNo.AgNumberRightPlaces = 2
        Me.TxtSaleOrderNo.AgPickFromLastValue = False
        Me.TxtSaleOrderNo.AgRowFilter = ""
        Me.TxtSaleOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleOrderNo.AgSelectedValue = Nothing
        Me.TxtSaleOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleOrderNo.Location = New System.Drawing.Point(359, 55)
        Me.TxtSaleOrderNo.MaxLength = 20
        Me.TxtSaleOrderNo.Name = "TxtSaleOrderNo"
        Me.TxtSaleOrderNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtSaleOrderNo.TabIndex = 11
        '
        'LblSaleOrderNo
        '
        Me.LblSaleOrderNo.AutoSize = True
        Me.LblSaleOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblSaleOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleOrderNo.Location = New System.Drawing.Point(247, 57)
        Me.LblSaleOrderNo.Name = "LblSaleOrderNo"
        Me.LblSaleOrderNo.Size = New System.Drawing.Size(94, 16)
        Me.LblSaleOrderNo.TabIndex = 706
        Me.LblSaleOrderNo.Text = "Sale Order No."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(8, 449)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(968, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(490, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 666
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(379, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(116, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(31, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(8, 202)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(968, 247)
        Me.Pnl1.TabIndex = 28
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(247, 97)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(359, 95)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.TabIndex = 15
        '
        'LblDueDateReq
        '
        Me.LblDueDateReq.AutoSize = True
        Me.LblDueDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDueDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDueDateReq.Location = New System.Drawing.Point(343, 81)
        Me.LblDueDateReq.Name = "LblDueDateReq"
        Me.LblDueDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDueDateReq.TabIndex = 725
        Me.LblDueDateReq.Text = "Ä"
        '
        'BtnFill
        '
        Me.BtnFill.BackColor = System.Drawing.Color.Transparent
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(922, 178)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(54, 23)
        Me.BtnFill.TabIndex = 726
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = False
        '
        'TxtDeliveryDate
        '
        Me.TxtDeliveryDate.AgMandatory = False
        Me.TxtDeliveryDate.AgMasterHelp = True
        Me.TxtDeliveryDate.AgNumberLeftPlaces = 8
        Me.TxtDeliveryDate.AgNumberNegetiveAllow = False
        Me.TxtDeliveryDate.AgNumberRightPlaces = 2
        Me.TxtDeliveryDate.AgPickFromLastValue = False
        Me.TxtDeliveryDate.AgRowFilter = ""
        Me.TxtDeliveryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeliveryDate.AgSelectedValue = Nothing
        Me.TxtDeliveryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeliveryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDeliveryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeliveryDate.Location = New System.Drawing.Point(587, 55)
        Me.TxtDeliveryDate.MaxLength = 20
        Me.TxtDeliveryDate.Name = "TxtDeliveryDate"
        Me.TxtDeliveryDate.Size = New System.Drawing.Size(149, 18)
        Me.TxtDeliveryDate.TabIndex = 727
        '
        'LblDeliveryDate
        '
        Me.LblDeliveryDate.AutoSize = True
        Me.LblDeliveryDate.BackColor = System.Drawing.Color.Transparent
        Me.LblDeliveryDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeliveryDate.Location = New System.Drawing.Point(465, 56)
        Me.LblDeliveryDate.Name = "LblDeliveryDate"
        Me.LblDeliveryDate.Size = New System.Drawing.Size(110, 16)
        Me.LblDeliveryDate.TabIndex = 728
        Me.LblDeliveryDate.Text = "Order Delivery Dt."
        '
        'TxtManualOrderNo
        '
        Me.TxtManualOrderNo.AgMandatory = True
        Me.TxtManualOrderNo.AgMasterHelp = True
        Me.TxtManualOrderNo.AgNumberLeftPlaces = 8
        Me.TxtManualOrderNo.AgNumberNegetiveAllow = False
        Me.TxtManualOrderNo.AgNumberRightPlaces = 2
        Me.TxtManualOrderNo.AgPickFromLastValue = False
        Me.TxtManualOrderNo.AgRowFilter = ""
        Me.TxtManualOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualOrderNo.AgSelectedValue = Nothing
        Me.TxtManualOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualOrderNo.Location = New System.Drawing.Point(587, 75)
        Me.TxtManualOrderNo.MaxLength = 50
        Me.TxtManualOrderNo.Name = "TxtManualOrderNo"
        Me.TxtManualOrderNo.Size = New System.Drawing.Size(149, 18)
        Me.TxtManualOrderNo.TabIndex = 729
        '
        'LblManualOrderNo
        '
        Me.LblManualOrderNo.AutoSize = True
        Me.LblManualOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualOrderNo.Location = New System.Drawing.Point(465, 76)
        Me.LblManualOrderNo.Name = "LblManualOrderNo"
        Me.LblManualOrderNo.Size = New System.Drawing.Size(110, 16)
        Me.LblManualOrderNo.TabIndex = 730
        Me.LblManualOrderNo.Text = "Manual Order No."
        '
        'LblManualOrderNoReq
        '
        Me.LblManualOrderNoReq.AutoSize = True
        Me.LblManualOrderNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualOrderNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualOrderNoReq.Location = New System.Drawing.Point(573, 81)
        Me.LblManualOrderNoReq.Name = "LblManualOrderNoReq"
        Me.LblManualOrderNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualOrderNoReq.TabIndex = 731
        Me.LblManualOrderNoReq.Text = "Ä"
        '
        'LblProductionOrderDetail
        '
        Me.LblProductionOrderDetail.BackColor = System.Drawing.Color.SteelBlue
        Me.LblProductionOrderDetail.DisabledLinkColor = System.Drawing.Color.White
        Me.LblProductionOrderDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductionOrderDetail.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblProductionOrderDetail.LinkColor = System.Drawing.Color.White
        Me.LblProductionOrderDetail.Location = New System.Drawing.Point(8, 181)
        Me.LblProductionOrderDetail.Name = "LblProductionOrderDetail"
        Me.LblProductionOrderDetail.Size = New System.Drawing.Size(153, 20)
        Me.LblProductionOrderDetail.TabIndex = 734
        Me.LblProductionOrderDetail.TabStop = True
        Me.LblProductionOrderDetail.Text = "Production Order Detail"
        Me.LblProductionOrderDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TempProductionOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 523)
        Me.Controls.Add(Me.LblProductionOrderDetail)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.BtnFill)
        Me.Name = "TempProductionOrder"
        Me.Text = "Template Production Order"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LblProductionOrderDetail, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TxtDueDate As AgControls.AgTextBox
    Protected WithEvents LblDueDate As System.Windows.Forms.Label
    Protected WithEvents TxtSaleOrderNo As AgControls.AgTextBox
    Protected WithEvents LblSaleOrderNo As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblDueDateReq As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents TxtDeliveryDate As AgControls.AgTextBox
    Protected WithEvents LblDeliveryDate As System.Windows.Forms.Label
#End Region

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 100, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 100, 50, Col1MeasureUnit, False, False, False)
            .AddAgNumberColumn(Dgl1, Col1ProdPlanQty, 100, 8, 4, False, Col1ProdPlanQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdPlanMeasure, 100, 8, 4, False, Col1ProdPlanMeasure, False, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.AgSkipReadOnlyColumns = True
        FrmProductionOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub


    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "UPDATE ProdOrder_Log " & _
                " SET " & _
                " SaleOrder = " & AgL.Chk_Text(TxtSaleOrderNo.AgSelectedValue) & ", " & _
                " DueDate = " & AgL.Chk_Text(TxtDueDate.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtManualOrderNo.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From ProdOrderDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "INSERT INTO ProdOrderDetail_Log (UID, DocId, Sr, Item, Qty, Unit, " & _
                        " MeasurePerPcs, TotalMeasure, MeasureUnit, ProdPlanQty, ProdPlanMeasure) " & _
                        " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdPlanQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdPlanMeasure, I).Value) & ")"

                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select Po.* " & _
                " From ProdOrder Po " & _
                " Where Po.DocID='" & SearchCode & "'"
        Else
            mQry = "Select Po.* " & _
                " From ProdOrder_Log Po " & _
                " Where Po.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()
                TxtSaleOrderNo.AgSelectedValue = AgL.XNull(.Rows(0)("SaleOrder"))
                TxtDueDate.Text = AgL.XNull(.Rows(0)("DueDate"))
                TxtManualOrderNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))
                Dgl1.Tag = AgL.XNull(.Rows(0)("SaleOrder"))

                DrTemp = TxtSaleOrderNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtSaleOrderNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    TxtDeliveryDate.Text = AgL.XNull(DrTemp(0)("DeliveryDate"))
                End If



                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from ProdOrderDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from ProdOrderDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1ProdPlanQty, I).Value = AgL.VNull(.Rows(I)("ProdPlanQty"))
                            Dgl1.Item(Col1ProdPlanMeasure, I).Value = AgL.VNull(.Rows(I)("ProdPlanMeasure"))
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmProductionOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        ProcFillReferenceNo()
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, I.Measure, MeasureUnit " & _
                " FROM Item I"
        Dgl1.AgHelpDataSet(Col1Item, 5) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT SO.DocID AS Code, SO.PartyOrderNo as [Party Order No], Vt.V_Type + '-' + convert(NVARCHAR,SO.V_No) AS [Sale Order No], SO.SaleToPartyName,SO.V_Date AS [Order Date],So.Status, " & _
                " SD.Div_Code, SD.ProdOrdQty, SO.MoveToLog, IsNull(So.IsDeleted ,0) AS IsDeleted, " & _
                " SO.V_Date As SaleOrderDate, SO.PartyDeliveryDate As DeliveryDate  " & _
                " FROM SaleOrder SO " & _
                " Left Join  " & _
                "   (SELECT SOD.DocId, I.Div_Code, IsNull(Sum(SOD.ProdOrdQty),0)  AS ProdOrdQty " & _
                "   FROM SaleOrderDetail SOD " & _
                "   LEFT JOIN Item I ON SOD.Item = I.Code   " & _
                "   GROUP BY SOD.DocId, I.Div_Code) " & _
                " AS SD ON SO.DocID = SD.DocID " & _
                " LEFT JOIN Voucher_Type Vt ON So.V_Type = Vt.V_Type " & _
                " WHERE So.DocId Is Not Null "

        TxtSaleOrderNo.AgHelpDataSet(7, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub FrmProductionOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.0000")
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
            End If
        Next
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.0000")
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtManualOrderNo, LblManualOrderNo.Text) Then passed = False : Exit Sub

        If TxtDueDate.Text <> "" And TxtV_Date.Text <> "" Then
            If CDate(TxtDueDate.Text) < CDate(TxtV_Date.Text) Then
                MsgBox("Due date Can't be Less Than Production Order Date", MsgBoxStyle.Information)
                TxtDueDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If TxtDueDate.Text <> "" And TxtDeliveryDate.Text <> "" Then
            If CDate(TxtDueDate.Text) > CDate(TxtDeliveryDate.Text) Then
                MsgBox("Due date Can't be Greater Than Party Delivery Date", MsgBoxStyle.Information)
                TxtDueDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If TxtSaleOrderNo.AgSelectedValue <> "" Then
            If TxtSaleOrderNo.AgSelectedValue <> Dgl1.Tag Then
                MsgBox("Data In Grid Does Not Belong To " & TxtSaleOrderNo.Text & "", MsgBoxStyle.Information)
                TxtSaleOrderNo.Focus()
                passed = False : Exit Sub
            End If
        End If

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With

        passed = FCheckDuplicateRefNo()
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl1.Tag = ""
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            mQry = "SELECT S.Item, S.Qty, S.Unit, S.MeasurePerPcs, S.TotalMeasure, S.MeasureUnit," & _
                    " S.ProdPlanQty, S.ProdPlanMeasure " & _
                    " FROM SaleOrderDetail S " & _
                    " LEFT JOIN Item I On S.Item = I.Code " & _
                    " WHERE S.DocId = '" & TxtSaleOrderNo.AgSelectedValue & "' " & _
                    " And I.Div_Code = '" & AgL.PubDivCode & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                        Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1ProdPlanQty, I).Value = AgL.VNull(.Rows(I)("ProdPlanQty"))
                        Dgl1.Item(Col1ProdPlanMeasure, I).Value = AgL.VNull(.Rows(I)("ProdPlanMeasure"))
                    Next I
                End If
            End With
            Dgl1.Tag = TxtSaleOrderNo.AgSelectedValue
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Validate_SaleOrder() As Boolean
        Dim DrTemp As DataRow() = Nothing

        Try
            If TxtSaleOrderNo.Text <> "" Then
                DrTemp = TxtSaleOrderNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtSaleOrderNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    TxtDeliveryDate.Text = AgL.XNull(DrTemp(0)("DeliveryDate"))

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Sale Order """ & TxtSaleOrderNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtSaleOrderNo.Text = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Sale Order """ & TxtSaleOrderNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtSaleOrderNo.Text = ""
                        Exit Function
                    End If
                End If
            End If
            Validate_SaleOrder = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtSaleOrderNo.Validating, TxtDueDate.Validating, TxtManualOrderNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    IniGrid()
                    ProcFillReferenceNo()

                Case TxtSaleOrderNo.Name
                    e.Cancel = Not Validate_SaleOrder()
                Case TxtManualOrderNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True
        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM ProdOrder WHERE ManualRefNo = '" & TxtManualOrderNo.Text & "'   " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtManualOrderNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM ProdOrder WHERE ManualRefNo = '" & TxtManualOrderNo.Text & "'  " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtManualOrderNo.Focus()
        End If
    End Function


    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSaleOrderNo.Enter
        Try
            Select Case sender.name
                Case TxtSaleOrderNo.Name
                    If TxtV_Date.Text <> "" Then
                        'TxtSaleOrderNo.AgRowFilter = " IsDeleted = 0 And SaleOrderDate <= '" & TxtV_Date.Text & "' And Div_Code = '" & AgL.PubDivCode & "' And (ProdOrdQty = 0   Or Code = '" & Dgl1.Tag & "')  "
                        'TxtSaleOrderNo.AgRowFilter = " IsDeleted = 0 And SaleOrderDate <= '" & TxtV_Date.Text & "' And Div_Code = '" & AgL.PubDivCode & "' And ProdOrdQty = 0  " & IIf(AgL.StrCmp(Topctrl1.Mode, "Edit"), "Or Code = '" & Dgl1.Tag & "'", "And 1=1") & ""
                        'TxtSaleOrderNo.AgRowFilter = " IsDeleted = 0 And ProdOrdQty = 0  And Div_Code = '" & AgL.PubDivCode & "' And SaleOrderDate <= '" & TxtV_Date.Text & "' "
                        TxtSaleOrderNo.AgRowFilter = " IsDeleted = 0 And SaleOrderDate <= '" & TxtV_Date.Text & "' And Div_Code = '" & AgL.PubDivCode & "' And ProdOrdQty = 0  "
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempProductionOrder_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtDeliveryDate.Enabled = False
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
            BtnFill.Enabled = False
        Else
            BtnFill.Enabled = True
        End If
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("Measure"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub


    Protected Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer

        '------------------------------------------------------------------------
        'Updating Production Order Qty In Sale Order Detail
        '-------------------------------------------------------------------------
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE SaleOrderDetail " & _
                           " SET ProdOrdQty = " & Val(.Item(Col1Qty, I).Value) & "," & _
                           " ProdOrdMeasure = " & Val(.Item(Col1TotalMeasure, I).Value) & " " & _
                           " Where DocId = '" & TxtSaleOrderNo.AgSelectedValue & "' And Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
        '-------------------------------------------------------------------------

    End Sub
    ' Start Code By Satyam on 26/11/2011
    Private Sub ProcFillReferenceNo()
        If TxtManualOrderNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtManualOrderNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text
            End If
        End If
    End Sub
    ' End Code By Satyam on 26/11/2011
    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' " & _
                    " FROM ( " & _
                    "   SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo " & _
                    "   FROM MaterialPlanDetail L " & _
                    "   LEFT JOIN MaterialPlan H ON L.DocId = H.DocID " & _
                    "   WHERE L.ProdOrder = '" & mInternalCode & "' " & _
                    "   And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Material Plan " & bRData & " created against Prod Order No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        'Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        'Passed = Not FGetRelationalData()
    End Sub
End Class
