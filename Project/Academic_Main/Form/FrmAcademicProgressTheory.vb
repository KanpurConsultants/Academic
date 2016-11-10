Public Class FrmAcademicProgressLaboratory
    Inherits TempAcademicProgress

    Protected Const Col1L_Qty As String = "Total Practicals"
    Protected Const Col1L_CumulativeQty As String = "Cumulative Total"
    Protected Const Col1L_CoveredPer_Course_Lab As String = "Lab Covered %"
    Protected Const Col1L_Checked_Assignment_Practical As String = "Checked Practicals"
    Protected Const Col1L_Checked_Tutorial_Quiz As String = "Quiz Checked"


    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.AcademicProgressLaboratory) & ""
        Me.AcademicProgressType = ClsMain.eAcademicProgressType.Laboratory
    End Sub

    Private Sub FrmAcademicProgressTheory_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        LblV_Type.Text = "Progress Type"
        LblV_Date.Text = "Progress Date"
        LblV_No.Text = "Progress No."
    End Sub

    Private Sub FrmPurchase_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Try
            With DGL1
                .Columns(Col1CoveredUnit).Visible = False

                .Columns(Col1Qty).HeaderText = Col1L_Qty
                .Columns(Col1CumulativeQty).HeaderText = Col1L_CumulativeQty
                .Columns(Col1CoveredPer_Course_Lab).HeaderText = Col1L_CoveredPer_Course_Lab
                .Columns(Col1Checked_Assignment_Practical).HeaderText = Col1L_Checked_Assignment_Practical
                .Columns(Col1Checked_Tutorial_Quiz).HeaderText = Col1L_Checked_Tutorial_Quiz
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class