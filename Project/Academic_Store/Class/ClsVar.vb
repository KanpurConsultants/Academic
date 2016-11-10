Public Class ClsVar
    Public Shared PurchaseAddition_Text = "Addition"
    Public Shared PurchaseAddition_H_Text = "Addition"
    Public Shared PurchaseDeduction_Text = "Deduction"
    Public Shared PurchaseDeduction_H_Text = "Deduction"
    Public Shared SaleAddition_Text = "Addition"
    Public Shared SaleAddition_H_Text = "Addition"
    Public Shared SaleDeduction_Text = "Deduction"
    Public Shared SaleDeduction_H_Text = "Deduction"

    Public Shared Item_Nature1_Description = "Item Nature1"
    Public Shared Item_Nature2_Description = "Item Nature2"
    Public Shared Item_Batch_Description = "Batch No"


#Region "Enviro Variables Constants"

#End Region
    ''==================================================================================
    ''====================< ENVIRO VARIABLES >==========================================
    ''==================================================================================
    Public Shared PurchaseAc As String
    Public Shared PurchaseAdditionAc As String
    Public Shared PurchaseDeductionAc As String
    Public Shared PurchaseAddition_HAc As String
    Public Shared PurchaseDeduction_HAc As String
    Public Shared SaleAc As String
    Public Shared SaleAdditionAc As String
    Public Shared SaleDeductionAc As String
    Public Shared SaleAddition_HAc As String
    Public Shared SaleDeduction_HAc As String

#Region "Voucher Type Settings Constants"
#Region "<Voucher NCat> Constants"
    '<Voucher NCat> Constants For Store ==============================
    Public Shared NCat_StorePurchase As String = "STPUR"
    Public Shared NCat_StoreSale As String = "STSAL"
    Public Shared NCat_StoreSaleOld As String = "STSLO"
    Public Shared NCat_StoreIssue As String = "STISS"
    Public Shared NCat_StoreReceive As String = "STREC"
    Public Shared NCat_StoreIssueReceive As String = "STIR"
    Public Shared NCat_StoreOpening As String = "STOP"
    Public Shared NCat_StoreSupplierBill As String = "STSB"
#End Region

#Region "<Voucher Category> Constants"
    '<Voucher Category> Constants For Store ==============================
    Public Shared Cat_StorePurchase As String = "STPUR"
    Public Shared Cat_StoreSale As String = "STSAL"
    Public Shared Cat_StoreIssue As String = "STISS"
    Public Shared Cat_StoreReceive As String = "STREC"
    Public Shared Cat_StoreIssueReceive As String = "STIR"    
    Public Shared Cat_StoreSupplierBill As String = "STSB"
#End Region
#End Region
End Class
