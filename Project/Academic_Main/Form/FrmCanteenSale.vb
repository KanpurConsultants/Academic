Public Class FrmCanteenSale
    Inherits FrmSessionProgramme

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        MyBase.New(StrUPVar, DTUP)
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        MsgBox("Canteen Sale")
    End Sub

End Class
