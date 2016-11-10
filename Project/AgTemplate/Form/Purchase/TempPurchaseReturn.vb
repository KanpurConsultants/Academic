Public Class TempPurchaseReturn 
    Inherits AgTemplate.TempPurchInvoiceCommon

    Protected Const Col1PurchInvoice As String = "Invoice No"
    Protected Const Col1LotNo As String = "Lot No"
    Dim mQry$ = ""

    Public Shadows Class HelpDataSet
        Inherits TempPurchInvoiceCommon.HelpDataSet
        Public Shared PurchInvoice As DataSet = Nothing
        Public Shared LotNo As DataSet = Nothing
    End Class

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtPurchInvoice = New AgControls.AgTextBox
        Me.LblInvoiceNo = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblVendor
        '
        Me.LblVendor.Location = New System.Drawing.Point(7, 55)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(127, 55)
        Me.TxtVendor.Size = New System.Drawing.Size(354, 18)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(111, 62)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(10, 369)
        Me.Panel1.Size = New System.Drawing.Size(973, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(10, 180)
        Me.Pnl1.Size = New System.Drawing.Size(973, 189)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(601, 398)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(382, 177)
        Me.PnlCalcGrid.TabIndex = 2
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(1068, 28)
        Me.TxtStructure.Size = New System.Drawing.Size(18, 18)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(1003, 29)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(621, 33)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(124, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 9
        Me.TxtSalesTaxGroupParty.Visible = True
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(501, 34)
        Me.Label27.Visible = True
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(621, 53)
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Size = New System.Drawing.Size(353, 38)
        Me.TxtRemarks.TabIndex = 11
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(501, 53)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(1064, 48)
        Me.TxtBillingType.Size = New System.Drawing.Size(31, 18)
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(995, 48)
        Me.Label32.Visible = False
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(719, 3)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(381, 75)
        Me.TxtReferenceNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtReferenceNo.TabIndex = 6
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(261, 75)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(854, 33)
        Me.TxtCurrency.Size = New System.Drawing.Size(120, 18)
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(751, 34)
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(854, 13)
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(751, 14)
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(621, 13)
        Me.TxtVendorDocNo.Size = New System.Drawing.Size(124, 18)
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.Location = New System.Drawing.Point(501, 13)
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(997, 84)
        Me.Pnl2.Size = New System.Drawing.Size(42, 13)
        Me.Pnl2.TabIndex = 11
        Me.Pnl2.Visible = False
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(997, 3)
        Me.BtnFill.Size = New System.Drawing.Size(62, 20)
        Me.BtnFill.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFill.Visible = False
        '
        'LblChallans
        '
        Me.LblChallans.Location = New System.Drawing.Point(971, 90)
        Me.LblChallans.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(10, 159)
        Me.LinkLabel1.Text = "Purchase Return For Following Items"
        '
        'BtnImportDetails
        '
        Me.BtnImportDetails.Location = New System.Drawing.Point(8, 542)
        Me.BtnImportDetails.Size = New System.Drawing.Size(87, 25)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(612, 585)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(304, 585)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(164, 585)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(1010, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(475, 585)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(233, 36)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(341, 35)
        Me.TxtV_No.Size = New System.Drawing.Size(140, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 41)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(7, 36)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(311, 21)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(127, 35)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(233, 17)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(341, 15)
        Me.TxtV_Type.Size = New System.Drawing.Size(140, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 21)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(7, 16)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(127, 15)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(293, 36)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 19)
        Me.TabControl1.Size = New System.Drawing.Size(995, 133)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.LblInvoiceNo)
        Me.TP1.Controls.Add(Me.TxtPurchInvoice)
        Me.TP1.Size = New System.Drawing.Size(987, 107)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblChallans, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPurchInvoice, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblInvoiceNo, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
        '
        'TxtPurchInvoice
        '
        Me.TxtPurchInvoice.AgMandatory = False
        Me.TxtPurchInvoice.AgMasterHelp = False
        Me.TxtPurchInvoice.AgNumberLeftPlaces = 8
        Me.TxtPurchInvoice.AgNumberNegetiveAllow = False
        Me.TxtPurchInvoice.AgNumberRightPlaces = 2
        Me.TxtPurchInvoice.AgPickFromLastValue = False
        Me.TxtPurchInvoice.AgRowFilter = ""
        Me.TxtPurchInvoice.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurchInvoice.AgSelectedValue = Nothing
        Me.TxtPurchInvoice.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurchInvoice.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPurchInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPurchInvoice.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurchInvoice.Location = New System.Drawing.Point(127, 75)
        Me.TxtPurchInvoice.MaxLength = 20
        Me.TxtPurchInvoice.Name = "TxtPurchInvoice"
        Me.TxtPurchInvoice.Size = New System.Drawing.Size(127, 18)
        Me.TxtPurchInvoice.TabIndex = 5
        '
        'LblInvoiceNo
        '
        Me.LblInvoiceNo.AutoSize = True
        Me.LblInvoiceNo.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.LblInvoiceNo.Location = New System.Drawing.Point(7, 76)
        Me.LblInvoiceNo.Name = "LblInvoiceNo"
        Me.LblInvoiceNo.Size = New System.Drawing.Size(71, 16)
        Me.LblInvoiceNo.TabIndex = 738
        Me.LblInvoiceNo.Text = "Invoice No."
        '
        'FrmPurchReturn_Wool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 626)
        Me.LogLineTableCsv = "PurchInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchInvoice_Log"
        Me.MainLineTableCsv = "PurchInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchInvoice"
        Me.Name = "FrmPurchReturn_Wool"
        Me.Text = "Purchase Return"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TxtPurchInvoice As AgControls.AgTextBox
    Protected WithEvents LblInvoiceNo As System.Windows.Forms.Label
#End Region

    Private Sub FrmPurchOrderConfirmation_Wool_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim Stock As ClsMain.StructStock = Nothing
        Dim I As Integer = 0

        mQry = " UPDATE PurchInvoice " & _
                " SET ReferenceDocId = NULL " & _
                " WHERE ReferenceDocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " UPDATE PurchInvoice " & _
                " SET ReferenceDocId = '" & mInternalCode & "'" & _
                " WHERE DocId = '" & TxtPurchInvoice.AgSelectedValue & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Stock Where DocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = " UPDATE PurchInvoiceDetail " & _
                            " SET ReferenceDocId = '" & mInternalCode & "'" & _
                            " WHERE DocId = '" & Dgl1.AgSelectedValue(Col1PurchInvoice, I) & "'"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    With Stock
                        .UID = mSearchCode
                        .DocID = mInternalCode
                        .Sr = I + 1
                        .V_Type = TxtV_Type.AgSelectedValue
                        .V_Prefix = LblPrefix.Text
                        .V_Date = TxtV_Date.Text
                        .V_No = TxtV_No.Text
                        .Div_Code = TxtDivision.AgSelectedValue
                        .Site_Code = TxtSite_Code.AgSelectedValue
                        .Item = Dgl1.AgSelectedValue(Col1Item, I)
                        .Qty_Iss = Dgl1.Item(Col1Qty, I).Value
                        .Unit = Dgl1.Item(Col1Unit, I).Value
                        .LotNo = Dgl1.Item(Col1LotNo, I).Value
                        .MeasurePerPcs = Dgl1.Item(Col1MeasurePerPcs, I).Value
                        .Measure_Iss = Dgl1.Item(Col1TotalMeasure, I).Value
                        .MeasureUnit = Dgl1.Item(Col1MeasureUnit, I).Value
                        .Status = ClsMain.StockStatus.Standard
                    End With
                    Call ClsMain.ProcStockPost("Stock", Stock, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmPurchReturn_Wool_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = " UPDATE PurchInvoice_Log " & _
                " SET ReferenceDocId = " & AgL.Chk_Text(TxtPurchInvoice.AgSelectedValue) & " " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmPurchReturn_Wool_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtPurchInvoice.AgHelpDataSet(8, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.PurchInvoice
        Dgl1.AgHelpDataSet(Col1PurchInvoice, 8) = HelpDataSet.PurchInvoice
        Dgl1.AgHelpDataSet(Col1Item, 11) = HelpDataSet.Item
        Dgl1.AgHelpDataSet(Col1LotNo) = HelpDataSet.LotNo
    End Sub

    Private Sub ProcFill()
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            mQry = " SELECT Id.*, I.VendorDocNo, I.VendorDocDate, I.SalesTaxGroupParty, I.Currency, I.ReferenceNo " & _
                    " FROM PurchInvoice I " & _
                    " LEFT JOIN PurchInvoiceDetail Id ON I.DocID = Id.DocId " & _
                    " WHERE Id.DocId = '" & TxtPurchInvoice.AgSelectedValue & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then

                    TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                    TxtVendorDocNo.Text = AgL.XNull(.Rows(0)("VendorDocNo"))
                    TxtVendorDocDate.Text = AgL.XNull(.Rows(0)("VendorDocDate"))
                    TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))

                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1PurchInvoice, I) = AgL.XNull(.Rows(I)("DocId"))
                        Dgl1.AgSelectedValue(Col1PurchChallan, I) = AgL.XNull(.Rows(I)("PurchChallan"))
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                        Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("DocQty"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.000")
                        Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.000")
                        Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                        Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                        AgCalcGrid1.FCopyStructureLine(AgL.XNull(.Rows(I)("DocId")), Dgl1, I, AgL.VNull(.Rows(I)("Sr")))
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtPurchInvoice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPurchInvoice.Validating
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtPurchInvoice.Name
                    e.Cancel = Not Validate_PurchInvoice()
                    If e.Cancel = False Then
                        Call ProcFill()
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmPurchaseOrderConfirmation_Wool_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.ReferenceDocId " & _
                " From PurchInvoice H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.ReferenceDocId " & _
                " From PurchInvoice_Log H " & _
                " Where H.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtPurchInvoice.AgSelectedValue = AgL.XNull(.Rows(0)("ReferenceDocId"))
            End If
        End With
    End Sub

    Private Sub FrmPurchReturn_Wool_BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer) Handles Me.BaseFunction_MoveRecLine
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select L.* " & _
                " From PurchInvoiceDetail L " & _
                " Where L.DocID='" & SearchCode & "' " & _
                " And L.Sr = " & Val(Sr) & " "
        Else
            mQry = "Select L.* " & _
                " From PurchInvoiceDetail_Log L " & _
                " Where L.UID='" & SearchCode & "'" & _
                " And L.Sr = " & Val(Sr) & " "
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                Dgl1.AgSelectedValue(Col1PurchInvoice, mGridRow) = AgL.XNull(.Rows(0)("ReferenceDocId"))
                Dgl1.Item(Col1LotNo, mGridRow).Value = AgL.XNull(.Rows(0)("LotNo"))
            End If
        End With
    End Sub

    Private Sub FrmPurchReturn_Wool_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        mQry = " UPDATE PurchInvoiceDetail_Log " & _
                " SET ReferenceDocId = '" & Dgl1.AgSelectedValue(Col1PurchInvoice, mGridRow) & "', " & _
                " LotNo = '" & Dgl1.Item(Col1LotNo, mGridRow).Value & "' " & _
                " WHERE UID = '" & SearchCode & "' " & _
                " And Sr = " & Val(Sr) & ""
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPurchInvoice.Enter
        Try
            Select Case sender.name
                Case TxtPurchInvoice.Name
                    TxtPurchInvoice.AgRowFilter = " IsDeleted = 0 " & _
                                                    " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & _
                                                    " And " & ClsMain.RetDivFilterStr & " " & _
                                                    " And Vendor = '" & TxtVendor.AgSelectedValue & "' " & _
                                                    " And V_Date <= '" & TxtV_Date.Text & "'  " & _
                                                    " And ReferenceDocId Is Null "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        mRowIndex = Dgl1.CurrentCell.RowIndex
        mColumnIndex = Dgl1.CurrentCell.ColumnIndex

        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " InvoiceDocId = '" & Dgl1.AgSelectedValue(Col1PurchInvoice, mRowIndex) & "' "

                Case Col1PurchInvoice
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1PurchInvoice).Index) = " IsDeleted = 0 And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And Vendor = '" & TxtVendor.AgSelectedValue & "' And V_Date <= '" & TxtV_Date.Text & "' And ReferenceDocId Is Null "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    If Dgl1.Item(Col1Item, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRowIndex).ToString.Trim = "" Then
                        Dgl1.Item(Col1DocQty, mRowIndex).Value = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1Item, mRowIndex) & "'")
                            Dgl1.Item(Col1DocQty, mRowIndex).Value = AgL.VNull(DrTemp(0)("DocQty"))
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempPurchReturn_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(Dgl1, Col1PurchInvoice, 120, 0, Col1PurchInvoice, True, False)
            .AddAgTextColumn(Dgl1, Col1LotNo, 100, 20, Col1LotNo, True, False)
        End With
        Dgl1.Columns(Col1PurchInvoice).DisplayIndex = 1
        Dgl1.Columns(Col1LotNo).DisplayIndex = 4
        FrmPurchReturn_Wool_BaseFunction_FIniList()
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub TempPurchaseReturn_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = " SELECT I.DocID AS  Code, I.V_Type + '-' + Convert(NVARCHAR, I.V_No) As [Invoice No], I.V_Date AS [Invoice Date], " & _
               " I.ReferenceNo AS [Manual No],I.VendorDocNo AS [Vendor Doc No], I.VendorDocDate AS [Vendor Doc, date]," & _
               " IsNull(I.IsDeleted,0) AS IsDeleted, " & _
               " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
               " I.Vendor, I.V_Date, Vt.NCat, I.ReferenceDocId, I.MoveToLog, I.Div_Code  " & _
               " FROM PurchInvoice I " & _
               " LEFT JOIN Voucher_Type Vt On I.V_Type = Vt.V_Type "
        HelpDataSet.PurchInvoice = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Id.Item AS Code, It.Description AS Item, Id.DocId AS InvoiceDocId, " & _
                   " It.Unit, It.ItemType, It.SalesTaxPostingGroup , " & _
                   " IsNull(It.IsDeleted ,0) AS IsDeleted, It.Div_Code, " & _
                   " It.MeasureUnit, It.Measure As MeasurePerPcs, IsNull(It.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "'), " & _
                   " Id.Rate As Rate, Id.DocQty As DocQty " & _
                   " FROM PurchInvoiceDetail Id " & _
                   " LEFT JOIN Item It ON Id.Item = It.Code "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT S.LotNo AS Code, S.LotNo FROM Stock S WHERE S.LotNo IS NOT NULL  "
        HelpDataSet.LotNo = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function Validate_PurchInvoice() As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If TxtPurchInvoice.Text <> "" Then
                DrTemp = TxtPurchInvoice.AgHelpDataSet.Tables(0).Select("Code = '" & TxtPurchInvoice.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Purchase Invoice """ & TxtPurchInvoice.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtPurchInvoice.Text = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Purchase Invoice """ & TxtPurchInvoice.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtPurchInvoice.Text = ""
                        Exit Function
                    End If
                End If
            End If
            Validate_PurchInvoice = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub TempPurchaseReturn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Validate_PurchInvoice() = False Then passed = False : Exit Sub
    End Sub

    Private Sub TempPurchaseReturn_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        mQry = " UPDATE PurchInvoiceDetail " & _
           " SET ReferenceDocId = NULL " & _
           " WHERE ReferenceDocId = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub
End Class
