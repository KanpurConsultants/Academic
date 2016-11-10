Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCarpetSaleOrder
    Inherits AgTemplate.TempSaleOrder

    Protected Const Col1Design As String = "Design"
    Protected Const Col1Colour As String = "Colour"
    Protected Const Col1Size As String = "Size"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.SaleOrder
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TpProductionDetail = New System.Windows.Forms.TabPage
        Me.TxtFactoryCancelDate = New AgControls.AgTextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.TxtFactoryDeliveryDate = New AgControls.AgTextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtExFactoryShipmentDate = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtShipmentDate = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtFactoryDate = New AgControls.AgTextBox
        Me.LblSize = New System.Windows.Forms.Label
        Me.TxtDeliveryMeasure = New AgControls.AgTextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TPExport.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TPShipping.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpProductionDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblStockTotalMeasure
        '
        Me.LblStockTotalMeasure.Location = New System.Drawing.Point(676, 3)
        '
        'LblTotalStockMeasureText
        '
        Me.LblTotalStockMeasureText.Location = New System.Drawing.Point(521, 3)
        Me.LblTotalStockMeasureText.Size = New System.Drawing.Size(149, 16)
        Me.LblTotalStockMeasureText.Text = "Total Area (Sqr.Yard) :"
        '
        'TxtOrderCancelDate
        '
        Me.TxtOrderCancelDate.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(755, 25)
        '
        'TxtDeliveryDate
        '
        Me.TxtDeliveryDate.Size = New System.Drawing.Size(123, 18)
        Me.TxtDeliveryDate.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(515, 25)
        '
        'TxtPartyOrderDate
        '
        Me.TxtPartyOrderDate.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(755, 5)
        '
        'TxtPartyOrderNo
        '
        Me.TxtPartyOrderNo.Size = New System.Drawing.Size(123, 18)
        Me.TxtPartyOrderNo.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(515, 5)
        '
        'TxtSaleToParty
        '
        Me.TxtSaleToParty.TabIndex = 4
        '
        'TxtSaleToPartyAdd1
        '
        Me.TxtSaleToPartyAdd1.TabIndex = 5
        '
        'TxtSaleToPartyAdd2
        '
        Me.TxtSaleToPartyAdd2.TabIndex = 6
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.TabIndex = 7
        '
        'TxtSaleToPartyState
        '
        Me.TxtSaleToPartyState.TabIndex = 8
        '
        'TxtSaleToPartyCountry
        '
        Me.TxtSaleToPartyCountry.TabIndex = 9
        '
        'TPExport
        '
        Me.TPExport.Size = New System.Drawing.Size(964, 150)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(2, 402)
        '
        'LblTotalQty
        '
        Me.LblTotalQty.ForeColor = System.Drawing.Color.Black
        Me.LblTotalQty.Location = New System.Drawing.Point(140, 3)
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.Location = New System.Drawing.Point(55, 3)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(2, 232)
        Me.Pnl1.Size = New System.Drawing.Size(972, 170)
        Me.Pnl1.TabIndex = 1000
        '
        'TxtDestinationCountry
        '
        Me.TxtDestinationCountry.TabIndex = 2
        '
        'TxtDestinationPort
        '
        Me.TxtDestinationPort.TabIndex = 1
        '
        'TxtFinalPlaceOfDelivery
        '
        Me.TxtFinalPlaceOfDelivery.TabIndex = 3
        '
        'TxtTermsAndConditions
        '
        Me.TxtTermsAndConditions.Location = New System.Drawing.Point(8, 449)
        Me.TxtTermsAndConditions.MaxLength = 0
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(465, 115)
        Me.TxtTermsAndConditions.TabIndex = 1001
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(593, 431)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(383, 133)
        Me.PnlCalcGrid.TabIndex = 1002
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(6, 430)
        '
        'TxtStructure
        '
        Me.TxtStructure.AgSelectedValue = ""
        Me.TxtStructure.Location = New System.Drawing.Point(853, 126)
        Me.TxtStructure.Size = New System.Drawing.Size(104, 18)
        Me.TxtStructure.TabIndex = 20
        Me.TxtStructure.Tag = ""
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(754, 127)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.TabIndex = 0
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(625, 126)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(126, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 19
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(515, 127)
        '
        'TPShipping
        '
        Me.TPShipping.Size = New System.Drawing.Size(964, 150)
        '
        'TxtShipToPartyCountry
        '
        Me.TxtShipToPartyCountry.TabIndex = 5
        '
        'TxtShipToPartyState
        '
        Me.TxtShipToPartyState.TabIndex = 4
        '
        'TxtShipToPartyCity
        '
        Me.TxtShipToPartyCity.TabIndex = 3
        '
        'TxtShipToPartyAdd2
        '
        Me.TxtShipToPartyAdd2.TabIndex = 2
        '
        'TxtShipToPartyAdd1
        '
        Me.TxtShipToPartyAdd1.TabIndex = 1
        '
        'TxtShipToParty
        '
        Me.TxtShipToParty.TabIndex = 0
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.ForeColor = System.Drawing.Color.Black
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.TabIndex = 17
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(515, 86)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Size = New System.Drawing.Size(123, 18)
        Me.TxtBillingType.TabIndex = 14
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(515, 45)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.ForeColor = System.Drawing.Color.Black
        Me.LblTotalMeasure.Location = New System.Drawing.Point(377, 3)
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(266, 3)
        Me.Label33.Size = New System.Drawing.Size(82, 16)
        Me.Label33.Text = "Total Area :"
        '
        'TxtAgent
        '
        Me.TxtAgent.TabIndex = 16
        '
        'LblAgent
        '
        Me.LblAgent.Location = New System.Drawing.Point(515, 65)
        '
        'TxtPreCarriageBy
        '
        Me.TxtPreCarriageBy.TabIndex = 4
        '
        'TxtBankAddressBuyer
        '
        Me.TxtBankAddressBuyer.TabIndex = 9
        '
        'TxtBankNameBuyer
        '
        Me.TxtBankNameBuyer.TabIndex = 8
        '
        'TxtBankAcNoBuyer
        '
        Me.TxtBankAcNoBuyer.TabIndex = 7
        '
        'TxtShipmentThrough
        '
        Me.TxtShipmentThrough.TabIndex = 6
        '
        'TxtPlaceOfReceipt
        '
        Me.TxtPlaceOfReceipt.TabIndex = 5
        '
        'TxtPriceMode
        '
        Me.TxtPriceMode.TabIndex = 10
        '
        'LblPriority
        '
        Me.LblPriority.Location = New System.Drawing.Point(755, 45)
        '
        'TxtPriority
        '
        Me.TxtPriority.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 582)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 582)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 582)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 582)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 582)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 570)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 582)
        '
        'TxtV_No
        '
        Me.TxtV_No.TabIndex = 3
        '
        'TxtV_Date
        '
        Me.TxtV_Date.TabIndex = 2
        '
        'TxtV_Type
        '
        Me.TxtV_Type.TabIndex = 1
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblPrefix
        '
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TpProductionDetail)
        Me.TabControl1.Size = New System.Drawing.Size(972, 176)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.Controls.SetChildIndex(Me.TPExport, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TPShipping, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TpProductionDetail, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TP1, 0)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtDeliveryMeasure)
        Me.TP1.Controls.Add(Me.Label29)
        Me.TP1.Size = New System.Drawing.Size(964, 150)
        Me.TP1.Controls.SetChildIndex(Me.LblAgent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAgent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPriority, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPriority, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.Label5, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToParty, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.Label9, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyOrderDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label11, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label10, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOrderCancelDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label13, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label29, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDeliveryMeasure, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        '
        'TpProductionDetail
        '
        Me.TpProductionDetail.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TpProductionDetail.Controls.Add(Me.TxtFactoryCancelDate)
        Me.TpProductionDetail.Controls.Add(Me.Label31)
        Me.TpProductionDetail.Controls.Add(Me.TxtFactoryDeliveryDate)
        Me.TpProductionDetail.Controls.Add(Me.Label23)
        Me.TpProductionDetail.Controls.Add(Me.TxtExFactoryShipmentDate)
        Me.TpProductionDetail.Controls.Add(Me.Label18)
        Me.TpProductionDetail.Controls.Add(Me.TxtShipmentDate)
        Me.TpProductionDetail.Controls.Add(Me.Label12)
        Me.TpProductionDetail.Controls.Add(Me.TxtFactoryDate)
        Me.TpProductionDetail.Controls.Add(Me.LblSize)
        Me.TpProductionDetail.Location = New System.Drawing.Point(4, 22)
        Me.TpProductionDetail.Name = "TpProductionDetail"
        Me.TpProductionDetail.Size = New System.Drawing.Size(964, 150)
        Me.TpProductionDetail.TabIndex = 3
        Me.TpProductionDetail.Text = "Delivery Detail"
        '
        'TxtFactoryCancelDate
        '
        Me.TxtFactoryCancelDate.AgMandatory = False
        Me.TxtFactoryCancelDate.AgMasterHelp = False
        Me.TxtFactoryCancelDate.AgNumberLeftPlaces = 0
        Me.TxtFactoryCancelDate.AgNumberNegetiveAllow = False
        Me.TxtFactoryCancelDate.AgNumberRightPlaces = 0
        Me.TxtFactoryCancelDate.AgPickFromLastValue = False
        Me.TxtFactoryCancelDate.AgRowFilter = ""
        Me.TxtFactoryCancelDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFactoryCancelDate.AgSelectedValue = Nothing
        Me.TxtFactoryCancelDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFactoryCancelDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFactoryCancelDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFactoryCancelDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactoryCancelDate.Location = New System.Drawing.Point(177, 89)
        Me.TxtFactoryCancelDate.MaxLength = 0
        Me.TxtFactoryCancelDate.Name = "TxtFactoryCancelDate"
        Me.TxtFactoryCancelDate.Size = New System.Drawing.Size(114, 18)
        Me.TxtFactoryCancelDate.TabIndex = 4
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 91)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(127, 16)
        Me.Label31.TabIndex = 708
        Me.Label31.Text = "Factory Cancel Date"
        '
        'TxtFactoryDeliveryDate
        '
        Me.TxtFactoryDeliveryDate.AgMandatory = False
        Me.TxtFactoryDeliveryDate.AgMasterHelp = False
        Me.TxtFactoryDeliveryDate.AgNumberLeftPlaces = 0
        Me.TxtFactoryDeliveryDate.AgNumberNegetiveAllow = False
        Me.TxtFactoryDeliveryDate.AgNumberRightPlaces = 0
        Me.TxtFactoryDeliveryDate.AgPickFromLastValue = False
        Me.TxtFactoryDeliveryDate.AgRowFilter = ""
        Me.TxtFactoryDeliveryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFactoryDeliveryDate.AgSelectedValue = Nothing
        Me.TxtFactoryDeliveryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFactoryDeliveryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFactoryDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFactoryDeliveryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactoryDeliveryDate.Location = New System.Drawing.Point(177, 70)
        Me.TxtFactoryDeliveryDate.MaxLength = 0
        Me.TxtFactoryDeliveryDate.Name = "TxtFactoryDeliveryDate"
        Me.TxtFactoryDeliveryDate.Size = New System.Drawing.Size(114, 18)
        Me.TxtFactoryDeliveryDate.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 72)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 16)
        Me.Label23.TabIndex = 706
        Me.Label23.Text = "Stuffing Date"
        '
        'TxtExFactoryShipmentDate
        '
        Me.TxtExFactoryShipmentDate.AgMandatory = False
        Me.TxtExFactoryShipmentDate.AgMasterHelp = False
        Me.TxtExFactoryShipmentDate.AgNumberLeftPlaces = 0
        Me.TxtExFactoryShipmentDate.AgNumberNegetiveAllow = False
        Me.TxtExFactoryShipmentDate.AgNumberRightPlaces = 0
        Me.TxtExFactoryShipmentDate.AgPickFromLastValue = False
        Me.TxtExFactoryShipmentDate.AgRowFilter = ""
        Me.TxtExFactoryShipmentDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtExFactoryShipmentDate.AgSelectedValue = Nothing
        Me.TxtExFactoryShipmentDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtExFactoryShipmentDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtExFactoryShipmentDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtExFactoryShipmentDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExFactoryShipmentDate.Location = New System.Drawing.Point(177, 51)
        Me.TxtExFactoryShipmentDate.MaxLength = 0
        Me.TxtExFactoryShipmentDate.Name = "TxtExFactoryShipmentDate"
        Me.TxtExFactoryShipmentDate.Size = New System.Drawing.Size(114, 18)
        Me.TxtExFactoryShipmentDate.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 53)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 16)
        Me.Label18.TabIndex = 704
        Me.Label18.Text = "Ex Factory Date"
        '
        'TxtShipmentDate
        '
        Me.TxtShipmentDate.AgMandatory = False
        Me.TxtShipmentDate.AgMasterHelp = False
        Me.TxtShipmentDate.AgNumberLeftPlaces = 0
        Me.TxtShipmentDate.AgNumberNegetiveAllow = False
        Me.TxtShipmentDate.AgNumberRightPlaces = 0
        Me.TxtShipmentDate.AgPickFromLastValue = False
        Me.TxtShipmentDate.AgRowFilter = ""
        Me.TxtShipmentDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipmentDate.AgSelectedValue = Nothing
        Me.TxtShipmentDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipmentDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtShipmentDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipmentDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipmentDate.Location = New System.Drawing.Point(177, 32)
        Me.TxtShipmentDate.MaxLength = 0
        Me.TxtShipmentDate.Name = "TxtShipmentDate"
        Me.TxtShipmentDate.Size = New System.Drawing.Size(114, 18)
        Me.TxtShipmentDate.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 16)
        Me.Label12.TabIndex = 702
        Me.Label12.Text = "Shipment Date"
        '
        'TxtFactoryDate
        '
        Me.TxtFactoryDate.AgMandatory = False
        Me.TxtFactoryDate.AgMasterHelp = False
        Me.TxtFactoryDate.AgNumberLeftPlaces = 0
        Me.TxtFactoryDate.AgNumberNegetiveAllow = False
        Me.TxtFactoryDate.AgNumberRightPlaces = 0
        Me.TxtFactoryDate.AgPickFromLastValue = False
        Me.TxtFactoryDate.AgRowFilter = ""
        Me.TxtFactoryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFactoryDate.AgSelectedValue = Nothing
        Me.TxtFactoryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFactoryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFactoryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFactoryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactoryDate.Location = New System.Drawing.Point(177, 13)
        Me.TxtFactoryDate.MaxLength = 0
        Me.TxtFactoryDate.Name = "TxtFactoryDate"
        Me.TxtFactoryDate.Size = New System.Drawing.Size(114, 18)
        Me.TxtFactoryDate.TabIndex = 0
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSize.Location = New System.Drawing.Point(12, 15)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(101, 16)
        Me.LblSize.TabIndex = 700
        Me.LblSize.Text = "Production Date"
        '
        'TxtDeliveryMeasure
        '
        Me.TxtDeliveryMeasure.AgMandatory = True
        Me.TxtDeliveryMeasure.AgMasterHelp = False
        Me.TxtDeliveryMeasure.AgNumberLeftPlaces = 0
        Me.TxtDeliveryMeasure.AgNumberNegetiveAllow = False
        Me.TxtDeliveryMeasure.AgNumberRightPlaces = 0
        Me.TxtDeliveryMeasure.AgPickFromLastValue = False
        Me.TxtDeliveryMeasure.AgRowFilter = ""
        Me.TxtDeliveryMeasure.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeliveryMeasure.AgSelectedValue = Nothing
        Me.TxtDeliveryMeasure.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeliveryMeasure.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDeliveryMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDeliveryMeasure.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeliveryMeasure.Location = New System.Drawing.Point(625, 104)
        Me.TxtDeliveryMeasure.MaxLength = 20
        Me.TxtDeliveryMeasure.Name = "TxtDeliveryMeasure"
        Me.TxtDeliveryMeasure.Size = New System.Drawing.Size(123, 18)
        Me.TxtDeliveryMeasure.TabIndex = 18
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(515, 105)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(107, 16)
        Me.Label29.TabIndex = 719
        Me.Label29.Text = "Delivery Measure"
        '
        'FrmCarpetSaleOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(984, 626)
        Me.EntryNCat = "SO"
        Me.LogLineTableCsv = "SaleOrderDetail_LOG"
        Me.LogTableName = "SaleOrder_Log"
        Me.MainLineTableCsv = "SaleOrderDetail"
        Me.MainTableName = "SaleOrder"
        Me.Name = "FrmCarpetSaleOrder"
        Me.TPExport.ResumeLayout(False)
        Me.TPExport.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TPShipping.ResumeLayout(False)
        Me.TPShipping.PerformLayout()
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
        Me.TpProductionDetail.ResumeLayout(False)
        Me.TpProductionDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents TxtDeliveryMeasure As AgControls.AgTextBox
    Protected WithEvents Label29 As System.Windows.Forms.Label
    Protected WithEvents TxtShipmentDate As AgControls.AgTextBox
    Protected WithEvents Label18 As System.Windows.Forms.Label
    Protected WithEvents TxtExFactoryShipmentDate As AgControls.AgTextBox
    Protected WithEvents Label23 As System.Windows.Forms.Label
    Protected WithEvents TxtFactoryDeliveryDate As AgControls.AgTextBox
    Protected WithEvents LblSize As System.Windows.Forms.Label
    Protected WithEvents TxtFactoryDate As AgControls.AgTextBox
    Protected WithEvents TxtFactoryCancelDate As AgControls.AgTextBox
    Protected WithEvents Label31 As System.Windows.Forms.Label
    Protected WithEvents TpProductionDetail As System.Windows.Forms.TabPage
#End Region

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Book & "' "
        End Select
    End Sub

    Protected Shadows Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex, True)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shadows Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer, ByVal bFillArea As Boolean)
        Dim mQry As String
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = "SELECT Cs.Design, D.Carpet_Colour, CS.Size, S.FeetArea, S.MeterArea, S.YardArea     " & _
                   "FROM RUG_CarpetSku CS  " & _
                   "LEFT JOIN RUG_Design D ON Cs.Design = D.Code    " & _
                   "LEFT JOIN Rug_Size S ON Cs.Size = S.Code  " & _
                   "WHERE CS.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.AgSelectedValue(Col1Design, mRow) = AgL.XNull(DtTemp.Rows(0)("Design"))
                Dgl1.Item(Col1Colour, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Carpet_Colour"))
                Dgl1.AgSelectedValue(Col1Size, mRow) = AgL.XNull(DtTemp.Rows(0)("Size"))

                If bFillArea Then
                    If AgL.StrCmp(TxtDeliveryMeasure.Text, "Feet") Then
                        Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(DtTemp.Rows(0)("FeetArea"))
                    ElseIf AgL.StrCmp(TxtDeliveryMeasure.Text, "Meter") Then
                        Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(DtTemp.Rows(0)("MeterArea"))
                    Else
                        Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(DtTemp.Rows(0)("YardArea"))
                    End If
                    Dgl1.Item(Col1StockMeasurePerPcs, mRow).Value = AgL.XNull(DtTemp.Rows(0)("YardArea"))
                End If
            Else
                Dgl1.AgSelectedValue(Col1Design, mRow) = ""
                Dgl1.AgSelectedValue(Col1Colour, mRow) = ""
                Dgl1.AgSelectedValue(Col1Size, mRow) = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = ""
                Dgl1.Item(Col1StockMeasurePerPcs, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans

    End Sub


    Private Sub FrmCarpetSaleOrder_BaseEvent_Data_Validation1(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation

        If TxtFactoryDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtFactoryDate.Text) Then
                MsgBox("Factory date can't be less than order date")
                TxtFactoryDate.Focus()
                passed = False : Exit Sub
            End If
        End If


        If TxtExFactoryShipmentDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtExFactoryShipmentDate.Text) Then
                MsgBox("Ex factory shipment date can't be less than order date")
                TxtExFactoryShipmentDate.Focus()
                passed = False : Exit Sub
            End If
        End If


        If TxtFactoryCancelDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtFactoryCancelDate.Text) Then
                MsgBox("Factory cancel date can't be less than order date")
                TxtFactoryCancelDate.Focus()
                passed = False : Exit Sub
            End If
        End If


        If TxtShipmentDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtShipmentDate.Text) Then
                MsgBox("Shipment date can't be less than order date")
                TxtShipmentDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If TxtFactoryDeliveryDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtFactoryDeliveryDate.Text) Then
                MsgBox("Factory delivery date can't be less than order date")
                TxtFactoryDeliveryDate.Focus()
                passed = False : Exit Sub
            End If
        End If
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim mQry$
        mQry = "UPDATE dbo.SaleOrder_Log " & _
               " Set DeliveryMeasure = " & AgL.Chk_Text(TxtDeliveryMeasure.AgSelectedValue) & " " & _
               ", ShipmentDate = " & AgL.Chk_Text(TxtShipmentDate.Text) & " " & _
               ", FactoryDate = " & AgL.Chk_Text(TxtFactoryDate.Text) & " " & _
               ", FactoryDeliveryDate = " & AgL.Chk_Text(TxtFactoryDeliveryDate.Text) & " " & _
               ", ExFactoryShipmentDate = " & AgL.Chk_Text(TxtExFactoryShipmentDate.Text) & " " & _
               ", FactoryCancelDate = " & AgL.Chk_Text(TxtFactoryCancelDate.Text) & " " & _
               " WHERE UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub

    Private Sub FrmCarpetSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    .Item(Col1Qty, I).Value = Format(Val(.Item(Col1Qty, I).Value), "0")
                End If
            Next
        End With

        'SetTotalAreaSqrYard()
    End Sub

    'Sub SetTotalAreaSqrYard()
    '    If AgL.StrCmp(TxtDeliveryMeasure.Text, "Feet") Then
    '        LblTotalAreaSqrYard.Text = Format(Val(LblTotalMeasure.Text) * 0.111111111, "0.00")
    '    ElseIf AgL.StrCmp(TxtDeliveryMeasure.Text, "Meter") Then
    '        LblTotalAreaSqrYard.Text = Format(Val(LblTotalMeasure.Text) * 1.19599005, "0.00")
    '    Else
    '        LblTotalAreaSqrYard.Text = Format(Val(LblTotalMeasure.Text), "0.00")
    '    End If
    'End Sub


    Private Sub FrmCarpetSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Dim mQry As String
        TxtDeliveryMeasure.AgHelpDataSet = AgL.FillData(ClsMain.HelpQueries.DeliveryMeasure, AgL.GCn)

        mQry = "SELECT D.Code, D.ManualCode FROM RUG_Design D ORDER BY D.ManualCode "
        Dgl1.AgHelpDataSet(Col1Design) = AgL.FillData(mQry, AgL.GCn)
        mQry = "SELECT S.Code, S.Description  FROM Rug_Size S ORDER BY S.Description "
        Dgl1.AgHelpDataSet(Col1Size) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(Dgl1, Col1Design, 100, 0, Col1Design, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Colour, 100, 0, Col1Colour, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Size, 100, 0, Col1Size, True, True, False)
            '.AddAgTextColumn(Dgl1, Col1MeasurePerPcs, 100, 0, Col1MeasurePerPcs, True, True, True)
            '.AddAgTextColumn(Dgl1, Col1TotalMeasure, 100, 0, Col1TotalMeasure, True, True, True)
        End With

        Dgl1.Columns(Col1Item).HeaderText = "Carpet SKU"
        Dgl1.Columns(Col1MeasurePerPcs).HeaderText = "Area Per Pcs"
        Dgl1.Columns(Col1TotalMeasure).HeaderText = "Total Area"
        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0

        Dgl1.Columns(Col1Design).DisplayIndex = 4
        Dgl1.Columns(Col1Colour).DisplayIndex = 5
        Dgl1.Columns(Col1Size).DisplayIndex = 6

        Dgl1.Columns(Col1Design).DisplayIndex = 2
        Dgl1.Columns(Col1Colour).DisplayIndex = 3
        Dgl1.Columns(Col1Size).DisplayIndex = 4
        Dgl1.Columns(Col1Qty).DisplayIndex = 5
        Dgl1.Columns(Col1Unit).DisplayIndex = 6
        Dgl1.Columns(Col1PartyUPC).DisplayIndex = 7
        Dgl1.Columns(Col1PartySKU).DisplayIndex = 8
        Dgl1.Columns(Col1MeasurePerPcs).DisplayIndex = 9
        Dgl1.Columns(Col1TotalMeasure).DisplayIndex = 10
        Dgl1.Columns(Col1Rate).DisplayIndex = 11
        Dgl1.Columns(Col1Amount).DisplayIndex = 12

        AgCalcGrid1.SetGridDisplayIndex()
        FrmCarpetSaleOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim mQry As String
        Dim I As Integer = 0
        Dim DtTemp As DataTable

        If Me.FrmType = EntryPointType.Main Then
            mQry = "SELECT S.DeliveryMeasure, S.ShipmentDate , S.FactoryDate , S.FactoryDeliveryDate , S.ExFactoryShipmentDate , S.FactoryCancelDate  " & _
                   "FROM SaleOrder S WHERE S.DocID ='" & SearchCode & "' "
        Else
            mQry = "SELECT S.DeliveryMeasure, S.ShipmentDate , S.FactoryDate , S.FactoryDeliveryDate , S.ExFactoryShipmentDate , S.FactoryCancelDate  " & _
                   "FROM SaleOrder_Log S WHERE S.UID ='" & SearchCode & "' "
        End If

        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        If DtTemp.Rows.Count > 0 Then
            TxtDeliveryMeasure.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("DeliveryMeasure"))
            TxtShipmentDate.Text = AgL.XNull(DtTemp.Rows(0)("ShipmentDate"))
            TxtFactoryDate.Text = AgL.XNull(DtTemp.Rows(0)("FactoryDate"))
            TxtFactoryDeliveryDate.Text = AgL.XNull(DtTemp.Rows(0)("FactoryDeliveryDate"))
            TxtExFactoryShipmentDate.Text = AgL.XNull(DtTemp.Rows(0)("ExFactoryShipmentDate"))
            TxtFactoryCancelDate.Text = AgL.XNull(DtTemp.Rows(0)("FactoryCancelDate"))
        End If

        For I = 0 To Dgl1.Rows.Count - 1
            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I, False)
            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(ConvertAreaForMovRec(Val(Dgl1.Item(Col1MeasurePerPcs, I).Value)), "0.000")
            Dgl1.Item(Col1TotalMeasure, I).Value = Format(ConvertAreaForMovRec(Val(Dgl1.Item(Col1TotalMeasure, I).Value)), "0.00")
        Next
        'SetTotalAreaSqrYard()
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtDeliveryMeasure.AgSelectedValue = "Feet"
        TxtBillingType.AgSelectedValue = "Area"
    End Sub

    Private Sub TxtOrderCancelDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtShipToPartyCity.LostFocus
        Select Case sender.NAME
            Case TxtShipToPartyCity.Name
                TabControl1.SelectedTab = TpProductionDetail
        End Select
    End Sub



    Private Sub FrmCarpetSaleOrder_BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer) Handles Me.BaseFunction_MoveRecLine

    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDeliveryMeasure.Validating
        Dim I As Integer
        Try
            Select Case sender.name
                Case TxtDeliveryMeasure.Name
                    For I = 0 To Dgl1.RowCount - 1
                        If Dgl1.Item(Col1Item, I).Value <> "" Then
                            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I, True)
                        End If
                    Next
            End Select
        Catch ex As Exception
            MsgBox(ex.Message + " in Txt_Validating ")
        End Try
    End Sub

    Private Function GetYardFromFeet(ByVal Value As Double) As Double
        GetYardFromFeet = Value * 0.111111111
    End Function

    Private Function GetYardFromMeter(ByVal Value As Double) As Double
        GetYardFromMeter = Value * 1.19599005
    End Function

    Private Function GetFeetFromYard(ByVal Value As Double) As Double
        GetFeetFromYard = Value * 9
    End Function

    Private Function GetMeterFromYard(ByVal Value As Double) As Double
        GetMeterFromYard = Value * 0.83612736
    End Function

    Private Function ConvertAreaForSave(ByVal bValue As Double) As Double
        Try
            If AgL.StrCmp(TxtDeliveryMeasure.Text, "Feet") Then
                ConvertAreaForSave = GetYardFromFeet(bValue)
            ElseIf AgL.StrCmp(TxtDeliveryMeasure.Text, "Meter") Then
                ConvertAreaForSave = GetYardFromMeter(bValue)
            Else
                ConvertAreaForSave = bValue
            End If
        Catch ex As Exception
            ConvertAreaForSave = 0
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function ConvertAreaForMovRec(ByVal bValue As Double) As Double
        Try
            If AgL.StrCmp(TxtDeliveryMeasure.Text, "Feet") Then
                ConvertAreaForMovRec = GetFeetFromYard(bValue)
            ElseIf AgL.StrCmp(TxtDeliveryMeasure.Text, "Meter") Then
                ConvertAreaForMovRec = GetMeterFromYard(bValue)
            Else
                ConvertAreaForMovRec = bValue
            End If
        Catch ex As Exception
            ConvertAreaForMovRec = 0
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub FrmCarpetSaleOrder_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        Dim mQry$ = ""
        Try
            With Dgl1
                mQry = "Update SaleOrderDetail_Log " & _
                           " Set " & _
                           " MeasurePerPcs = " & Val(ConvertAreaForSave(.Item(Col1MeasurePerPcs, mGridRow).Value)) & ", " & _
                           " TotalMeasure = " & Val(ConvertAreaForSave(.Item(Col1TotalMeasure, mGridRow).Value)) & " " & _
                           " Where UID = '" & SearchCode & "' " & _
                           " And Sr = " & Sr & "  "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmCarpetMaterialPlan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 660, 992, 0, 0)
    End Sub

    Public Overrides Sub PrintDocument(ByVal SearchCode As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Export Order"
                RepName = "Rug_ExportOrder_Print" : RepTitle = "Export Order"
                bTableName = "SaleOrder" : bSecTableName = "SaleOrderDetail SO1 ON SO1.DocID =SO.DocID"
                bCondstr = "WHERE SO.DocID='" & SearchCode & "'"
            Else
                AgL.PubReportTitle = "Export Order Log"
                RepName = "Rug_ExportOrder_Print" : RepTitle = "Export Order Log"
                bTableName = "SaleOrder_Log" : bSecTableName = "SaleOrderDetail_Log  SO1 ON SO1.UID =SO.UID "
                bCondstr = "WHERE SO.UID='" & SearchCode & "'"
            End If

            strQry = " SELECT SO.DocID, SO.V_Type, SO.V_Prefix, SO.V_Date, SO.V_No, SO.Div_Code, SO.Site_Code, " & _
                        " SO.SaleToParty, SO.SaleToPartyName, SO.SaleToPartyAdd1, SO.SaleToPartyAdd2, SO.SaleToPartyCity, " & _
                        " SO.SaleToPartyCityName, SO.SaleToPartyState, SO.SaleToPartyCountry, SO.ShipToPartyName, " & _
                        " SO.ShipToPartyAdd1, SO.ShipToPartyAdd2, SO.ShipToPartyCity, SO.ShipToPartyCityName, " & _
                        " SO.ShipToPartyState, SO.ShipToPartyCountry, SO.Currency, SO.SalesTaxGroupParty, " & _
                        " SO.Structure, SO.BillingType, SO.PartyOrderNo, SO.PartyOrderDate, SO.PartyDeliveryDate, " & _
                        " SO.PartyOrderCancelDate, SO.DestinationPort, SO.FinalPlaceOfDelivery, SO.TermsAndConditions, " & _
                        " SO.Remarks, SO.TotalQty, SO.TotalMeasure, SO.TotalAmount, SO.EntryBy, SO.EntryDate, " & _
                        " SO.EntryType, SO.EntryStatus, SO.ApproveBy, SO.ApproveDate, SO.MoveToLog, SO.MoveToLogDate, " & _
                        " SO.IsDeleted, SO.Status, SO.UID, SO.DeliveryMeasure, SO.ShipmentDate, SO.FactoryDate, " & _
                        " SO.FactoryDeliveryDate, SO.ExFactoryShipmentDate, SO.FactoryCancelDate, SO.Priority, " & _
                        " SO.ShipToParty, SO.PreCarriageBy, SO.PlaceOfReceipt, SO.ShipmentThrough, SO.BankAcNoBuyer, " & _
                        " SO.BankNameBuyer, SO.BankAddressBuyer, SO.PriceMode, SO.Agent, " & _
                        " SO1.Sr, SO1.Item, SO1.SalesTaxGroupItem, SO1.Qty, SO1.Unit, SO1.Rate, SO1.Amount, " & _
                        " SO1.UID, SO1.PartySKU, SO1.PartyUPC, " & _
                        " SO1.MeasurePerPcs, SO1.TotalMeasure AS LineTotalMeasure, " & _
                        " D.Div_Name,SM.Name AS SiteName,SD.Description AS DestinationPortName, " & _
                        " C.Country AS DestinationPortCountry, " & _
                        " I.Description AS ItemDesc,Vt.Description AS OrderTypeDesc, " & _
                        " RD.Description AS DesignDesc,RS.Description AS SizeDesc,  " & _
                        " Case When SO.DeliveryMeasure = 'Feet' Then MeasurePerPcs * 9 ELSE " & _
                        " Case When SO.DeliveryMeasure = 'Meter' Then MeasurePerPcs * 0.83612736 ELSE " & _
                        " SO1.MeasurePerPcs End End As AreaPerPcs, " & _
                        " Case When SO.DeliveryMeasure = 'Feet' Then SO1.TotalMeasure * 9 ELSE " & _
                        " Case When SO.DeliveryMeasure = 'Meter' Then SO1.TotalMeasure * 0.83612736 ELSE " & _
                        " SO1.TotalMeasure End End As LineTotalArea, P.Description As PriorityDesc " & _
                        " FROM " & bTableName & " SO " & _
                        " LEFT JOIN " & bSecTableName & "" & _
                        " LEFT JOIN Division D ON D.Div_Code=SO.Div_Code  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=SO.Site_Code  " & _
                        " LEFT JOIN SeaPort SD ON SD.Code=SO.DestinationPort  " & _
                        " LEFT JOIN City C ON C.CityCode=SD.City  " & _
                        " LEFT JOIN Item I ON I.Code=SO1.Item  " & _
                        " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =SO.V_Type " & _
                        " LEFT JOIN RUG_CarpetSku CS ON CS.Code=SO1.Item " & _
                        " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design " & _
                        " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size " & _
                        " LEFT JOIN Priority P On SO.Priority = P.Code " & _
                        " " & bCondstr & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
