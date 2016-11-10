Public Class TempPurchaseOrderConfirmation
    Inherits AgTemplate.TempPurchaseOrder

    Dim mQry$ = ""

    Public Shadows Class HelpDataSet
        Inherits TempPurchInvoiceCommon.HelpDataSet
        Public Shared PurchOrder As DataSet = Nothing
    End Class

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtPurchaseOrder = New AgControls.AgTextBox
        Me.LblPurchaseOrder = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TPShipping.SuspendLayout()
        Me.PnlSettings.SuspendLayout()
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
        Me.LblVendor.Location = New System.Drawing.Point(5, 58)
        '
        'TxtVendorOrderCancelDate
        '
        Me.TxtVendorOrderCancelDate.Location = New System.Drawing.Point(884, 75)
        Me.TxtVendorOrderCancelDate.Size = New System.Drawing.Size(92, 18)
        '
        'LblVendorCancelDate
        '
        Me.LblVendorCancelDate.Location = New System.Drawing.Point(768, 76)
        '
        'TxtVendorDeliveryDate
        '
        Me.TxtVendorDeliveryDate.Location = New System.Drawing.Point(669, 76)
        Me.TxtVendorDeliveryDate.Size = New System.Drawing.Size(91, 18)
        '
        'LblVendorDeliveryDate
        '
        Me.LblVendorDeliveryDate.Location = New System.Drawing.Point(536, 77)
        '
        'TxtVendorOrderDate
        '
        Me.TxtVendorOrderDate.Location = New System.Drawing.Point(884, 56)
        Me.TxtVendorOrderDate.Size = New System.Drawing.Size(92, 18)
        '
        'LvlVendoOrdDate
        '
        Me.LvlVendoOrdDate.Location = New System.Drawing.Point(768, 57)
        '
        'TxtVendorOrdNo
        '
        Me.TxtVendorOrdNo.Location = New System.Drawing.Point(669, 57)
        Me.TxtVendorOrdNo.Size = New System.Drawing.Size(91, 18)
        '
        'LblVendorOrdNo
        '
        Me.LblVendorOrdNo.Location = New System.Drawing.Point(536, 58)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(115, 58)
        Me.TxtVendor.Size = New System.Drawing.Size(328, 18)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(101, 65)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 78)
        '
        'TxtSaleToPartyAdd1
        '
        Me.TxtSaleToPartyAdd1.Location = New System.Drawing.Point(115, 78)
        Me.TxtSaleToPartyAdd1.Size = New System.Drawing.Size(328, 18)
        '
        'TxtSaleToPartyAdd2
        '
        Me.TxtSaleToPartyAdd2.Location = New System.Drawing.Point(115, 98)
        Me.TxtSaleToPartyAdd2.Size = New System.Drawing.Size(328, 18)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 119)
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(115, 118)
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(122, 18)
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 167)
        Me.Label7.Visible = False
        '
        'TxtSaleToPartyState
        '
        Me.TxtSaleToPartyState.Location = New System.Drawing.Point(120, 167)
        Me.TxtSaleToPartyState.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(257, 168)
        Me.Label8.Visible = False
        '
        'TxtSaleToPartyCountry
        '
        Me.TxtSaleToPartyCountry.Location = New System.Drawing.Point(351, 167)
        Me.TxtSaleToPartyCountry.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(9, 386)
        Me.Panel1.Size = New System.Drawing.Size(974, 23)
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Size = New System.Drawing.Size(33, 16)
        Me.LblTotalQty.Text = "0.00"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(9, 240)
        Me.Pnl1.Size = New System.Drawing.Size(974, 146)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(101, 125)
        '
        'TxtTermsAndConditions
        '
        Me.TxtTermsAndConditions.Location = New System.Drawing.Point(8, 437)
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(303, 60)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(613, 423)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(370, 156)
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(5, 417)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(882, 166)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(815, 167)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(884, 94)
        Me.TxtCurrency.Size = New System.Drawing.Size(92, 18)
        Me.TxtCurrency.TabIndex = 18
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(768, 95)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(669, 95)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(91, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 17
        Me.TxtSalesTaxGroupParty.Visible = True
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(536, 97)
        Me.Label27.Visible = True
        '
        'TPShipping
        '
        Me.TPShipping.Size = New System.Drawing.Size(987, 149)
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.Location = New System.Drawing.Point(627, 3)
        Me.LblTotalAmount.Size = New System.Drawing.Size(33, 16)
        Me.LblTotalAmount.Text = "0.00"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.Location = New System.Drawing.Point(523, 3)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(669, 114)
        Me.TxtRemarks.Size = New System.Drawing.Size(307, 18)
        Me.TxtRemarks.TabIndex = 19
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(536, 116)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(619, 165)
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(503, 165)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(382, 39)
        Me.LblTotalMeasure.Size = New System.Drawing.Size(47, 16)
        Me.LblTotalMeasure.Text = "0.0000"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(398, 41)
        '
        'TxtAgent
        '
        Me.TxtAgent.Location = New System.Drawing.Point(956, 145)
        '
        'LblAgent
        '
        Me.LblAgent.Location = New System.Drawing.Point(908, 145)
        '
        'TxtPriceMode
        '
        Me.TxtPriceMode.Location = New System.Drawing.Point(884, 18)
        Me.TxtPriceMode.Size = New System.Drawing.Size(92, 18)
        Me.TxtPriceMode.TabIndex = 10
        '
        'LblPriceMode
        '
        Me.LblPriceMode.Location = New System.Drawing.Point(769, 20)
        '
        'LblStockTotalMeasure
        '
        Me.LblStockTotalMeasure.Location = New System.Drawing.Point(565, 37)
        Me.LblStockTotalMeasure.Size = New System.Drawing.Size(47, 16)
        Me.LblStockTotalMeasure.Text = "0.0000"
        '
        'LblTotalStockMeasureText
        '
        Me.LblTotalStockMeasureText.Location = New System.Drawing.Point(382, 38)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(339, 118)
        Me.TxtReferenceNo.Size = New System.Drawing.Size(104, 18)
        Me.TxtReferenceNo.TabIndex = 8
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(243, 120)
        '
        'TxtIndentNo
        '
        Me.TxtIndentNo.Location = New System.Drawing.Point(884, 37)
        Me.TxtIndentNo.Size = New System.Drawing.Size(92, 18)
        '
        'LblIndentNo
        '
        Me.LblIndentNo.Location = New System.Drawing.Point(769, 38)
        '
        'TxtQutationNo
        '
        Me.TxtQutationNo.Location = New System.Drawing.Point(669, 38)
        Me.TxtQutationNo.Size = New System.Drawing.Size(91, 18)
        '
        'LblQutationNo
        '
        Me.LblQutationNo.Location = New System.Drawing.Point(536, 39)
        '
        'PnlSettings
        '
        Me.PnlSettings.Location = New System.Drawing.Point(350, 446)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 219)
        Me.LinkLabel1.Size = New System.Drawing.Size(252, 20)
        Me.LinkLabel1.Text = "Order Confirmation For Following Items"
        '
        'TxtPaymentTerms
        '
        Me.TxtPaymentTerms.Location = New System.Drawing.Point(8, 520)
        Me.TxtPaymentTerms.Size = New System.Drawing.Size(303, 56)
        Me.TxtPaymentTerms.TabIndex = 3
        Me.TxtPaymentTerms.Visible = True
        '
        'LblPaymentTerms
        '
        Me.LblPaymentTerms.Location = New System.Drawing.Point(5, 501)
        Me.LblPaymentTerms.Visible = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 591)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 591)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 591)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 591)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 591)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 587)
        Me.GroupBox1.Size = New System.Drawing.Size(1010, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 591)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(221, 39)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(329, 38)
        Me.TxtV_No.Size = New System.Drawing.Size(114, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(99, 44)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(5, 39)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(299, 24)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(115, 38)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(221, 20)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(329, 18)
        Me.TxtV_Type.Size = New System.Drawing.Size(114, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(99, 24)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(5, 19)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(115, 18)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(281, 39)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 39)
        Me.TabControl1.Size = New System.Drawing.Size(995, 175)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtPurchaseOrder)
        Me.TP1.Controls.Add(Me.LblPurchaseOrder)
        Me.TP1.Size = New System.Drawing.Size(987, 149)
        Me.TP1.Controls.SetChildIndex(Me.LblPriceMode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPriceMode, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label28, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtQutationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIndentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIndentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblQutationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorOrderCancelDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorCancelDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorOrderDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlVendoOrdDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorOrdNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorOrdNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPurchaseOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPurchaseOrder, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyAdd1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyAdd2, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label6, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label7, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyState, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label8, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyCountry, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label13, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAgent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAgent, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
        Me.Topctrl1.TabIndex = 4
        '
        'TxtPurchaseOrder
        '
        Me.TxtPurchaseOrder.AgMandatory = False
        Me.TxtPurchaseOrder.AgMasterHelp = False
        Me.TxtPurchaseOrder.AgNumberLeftPlaces = 0
        Me.TxtPurchaseOrder.AgNumberNegetiveAllow = False
        Me.TxtPurchaseOrder.AgNumberRightPlaces = 0
        Me.TxtPurchaseOrder.AgPickFromLastValue = False
        Me.TxtPurchaseOrder.AgRowFilter = ""
        Me.TxtPurchaseOrder.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurchaseOrder.AgSelectedValue = Nothing
        Me.TxtPurchaseOrder.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurchaseOrder.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPurchaseOrder.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurchaseOrder.Location = New System.Drawing.Point(669, 18)
        Me.TxtPurchaseOrder.MaxLength = 255
        Me.TxtPurchaseOrder.Name = "TxtPurchaseOrder"
        Me.TxtPurchaseOrder.Size = New System.Drawing.Size(91, 18)
        Me.TxtPurchaseOrder.TabIndex = 9
        '
        'LblPurchaseOrder
        '
        Me.LblPurchaseOrder.AutoSize = True
        Me.LblPurchaseOrder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurchaseOrder.Location = New System.Drawing.Point(536, 19)
        Me.LblPurchaseOrder.Name = "LblPurchaseOrder"
        Me.LblPurchaseOrder.Size = New System.Drawing.Size(99, 16)
        Me.LblPurchaseOrder.TabIndex = 739
        Me.LblPurchaseOrder.Text = "Purchase Order"
        '
        'FrmPurchaseOrderConfirmation_Wool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 626)
        Me.LogLineTableCsv = "PurchOrderDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchOrder_Log"
        Me.MainLineTableCsv = "PurchOrderDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchOrder"
        Me.Name = "FrmPurchaseOrderConfirmation_Wool"
        Me.Text = "FrmPurchaseOrder_Wool"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TPShipping.ResumeLayout(False)
        Me.TPShipping.PerformLayout()
        Me.PnlSettings.ResumeLayout(False)
        Me.PnlSettings.PerformLayout()
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
        Me.PerformLayout()
    End Sub
    Protected WithEvents LblPurchaseOrder As System.Windows.Forms.Label
    Protected WithEvents TxtPurchaseOrder As AgControls.AgTextBox
#End Region

    Private Sub FrmPurchOrderConfirmation_Wool_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        mQry = " UPDATE PurchOrder " & _
                " SET PurchOrder = '" & mInternalCode & "'" & _
                " WHERE DocId = '" & TxtPurchaseOrder.AgSelectedValue & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmPurchaseOrderConfirmation_Wool_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = " UPDATE PurchOrder_Log " & _
                " SET PurchOrder = " & AgL.Chk_Text(TxtPurchaseOrder.AgSelectedValue) & " " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub ProcFill()
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            mQry = " SELECT Pod.*, " & _
                    " Po.PurchQuotaion, Po.PurchIndent, Po.VendorOrderNo, Po.VendorOrderDate, " & _
                    " Po.VendorDeliveryDate, Po.SalesTaxGroupParty, Po.VendorOrderCancelDate, " & _
                    " Po.TermsAndConditions, Po.PaymentTerms " & _
                    " FROM  PurchOrder Po " & _
                    " LEFT JOIN PurchOrderDetail Pod ON Po.DocID = Pod.DocId " & _
                    " Where Po.DocId = '" & TxtPurchaseOrder.AgSelectedValue & "'"
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    TxtQutationNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchQuotaion"))
                    TxtIndentNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchIndent"))
                    TxtVendorOrdNo.Text = AgL.XNull(.Rows(0)("VendorOrderNo"))
                    TxtVendorOrderDate.Text = AgL.XNull(.Rows(0)("VendorOrderDate"))
                    TxtVendorDeliveryDate.Text = AgL.XNull(.Rows(0)("VendorDeliveryDate"))
                    TxtVendorOrderCancelDate.Text = AgL.XNull(.Rows(0)("VendorOrderCancelDate"))
                    TxtSalesTaxGroupParty.Text = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                    TxtTermsAndConditions.Text = AgL.XNull(.Rows(0)("TermsAndConditions"))
                    TxtPaymentTerms.Text = AgL.XNull(.Rows(0)("PaymentTerms"))



                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1IndentNo, I) = AgL.XNull(.Rows(I)("PurchIndent"))
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1PartySKU, I).Value = AgL.XNull(.Rows(I)("VendorSKU"))
                        Dgl1.Item(Col1PartyUPC, I).Value = AgL.XNull(.Rows(I)("VendorUPC"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1Amount, I).Value = AgL.VNull(.Rows(I)("Amount"))
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))

                        Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                        Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1ShippedQty, I).Value = AgL.VNull(.Rows(I)("ShippedQty"))
                        Dgl1.Item(Col1ShippedMeasure, I).Value = AgL.VNull(.Rows(I)("ShippedMeasure"))
                        AgCalcGrid1.FCopyStructureLine(AgL.XNull(.Rows(I)("DocId")), Dgl1, I, AgL.VNull(.Rows(I)("Sr")))
                    Next I
                End If
            End With
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmPurchaseOrderConfirmation_Wool_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtPurchaseOrder.AgHelpDataSet(8, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.PurchOrder
    End Sub

    Private Sub TxtPurchaseOrder_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPurchaseOrder.Validating
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtPurchaseOrder.Name
                    e.Cancel = Not Validate_PurchOrder()
                    If e.Cancel = False Then
                        Call ProcFill()
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmPurchaseOrderConfirmation_Wool_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtQutationNo.Enabled = False
        TxtIndentNo.Enabled = False
        TxtVendorDeliveryDate.Enabled = False
        TxtVendorOrderCancelDate.Enabled = False
        TxtVendorOrderCancelDate.Enabled = False
        TxtVendorOrdNo.Enabled = False
        TxtVendorOrderDate.Enabled = False
    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtShipToPartyCity.Enter, TxtQutationNo.Enter, TxtIndentNo.Enter, TxtPurchaseOrder.Enter
        Try
            Select Case sender.name
                Case TxtShipToPartyCity.Name
                    TxtShipToPartyCity.AgRowFilter = " IsDeleted = 0 "

                Case TxtPurchaseOrder.Name
                    TxtPurchaseOrder.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And " & ClsMain.RetDivFilterStr & " " & _
                        " And Vendor = '" & TxtVendor.AgSelectedValue & "' " & _
                        " And V_Date <= '" & TxtV_Date.Text & "' " & _
                        " And PurchOrder Is Null  "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmPurchaseOrderConfirmation_Wool_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.PurchOrder " & _
                " From PurchOrder H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.PurchOrder " & _
                " From PurchOrder_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtPurchaseOrder.AgSelectedValue = AgL.XNull(.Rows(0)("PurchOrder"))
            End If
        End With
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        mRowIndex = Dgl1.CurrentCell.RowIndex
        mColumnIndex = Dgl1.CurrentCell.ColumnIndex

        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Call IniItemHelp()
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                    " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " And " & ClsMain.RetDivFilterStr & " "
        End Select
    End Sub

    Private Sub TempPurchaseOrderConfirmation_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1IndentNo).ReadOnly = True
        Dgl1.Columns(Col1Item).ReadOnly = True
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub TempPurchaseOrderConfirmation_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        'Start Code Change By Satyam on 18/11/2011
        mQry = " SELECT Po.DocID AS Code, Po.V_Type + '-' + Convert(NVARCHAR,Po.V_No) AS [PO No],Po.V_Date AS [PO Date], " & _
                  " PO.ReferenceNo AS [Manual No],Po.VendorOrderNo AS [Vender Ord. No], Po.Vendor, " & _
                  " IsNull(Po.IsDeleted,0) As IsDeleted, " & _
                  " IsNull(Po.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) As Status, " & _
                  " Po.Div_Code, Po.MoveToLog, " & _
                  " Po.V_Date, Vt.NCat, Po.PurchOrder " & _
                  " FROM PurchOrder Po " & _
                  " LEFT JOIN Voucher_Type Vt On Po.V_Type = Vt.V_Type "
        HelpDataSet.PurchOrder = AgL.FillData(mQry, AgL.GCn)
        'End Code Change By Satyam on 18/11/2011
    End Sub

    Private Function Validate_PurchOrder() As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If TxtPurchaseOrder.Text <> "" Then
                DrTemp = TxtPurchaseOrder.AgHelpDataSet.Tables(0).Select("Code = '" & TxtPurchaseOrder.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Purchase Order """ & TxtPurchaseOrder.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtPurchaseOrder.AgSelectedValue = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Purchase Order """ & TxtPurchaseOrder.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtPurchaseOrder.AgSelectedValue = ""
                        Exit Function
                    End If
                End If
            End If
            Validate_PurchOrder = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub TempPurchaseOrderConfirmation_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Validate_PurchOrder() = False Then passed = False : Exit Sub
    End Sub

    Private Sub TempPurchaseOrderConfirmation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BtnFill.Visible = False
    End Sub
End Class
