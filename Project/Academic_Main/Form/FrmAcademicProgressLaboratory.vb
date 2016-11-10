'Public Class FrmAcademicProgressTheory

'End Class
Public Class FrmAcademicProgressTheory
    Inherits TempAcademicProgress

    Protected Const Col1T_Qty As String = "Total Lectures"
    Protected Const Col1T_CumulativeQty As String = "Cumulative Total"
    Protected Const Col1T_CoveredPer_Course_Lab As String = "Course Covered %"
    Protected Const Col1T_CoveredUnit As String = "Units Covered"
    Protected Const Col1T_Checked_Assignment_Practical As String = "Checked Assignment"
    Protected Const Col1T_Checked_Tutorial_Quiz As String = "Tutorial Checked"


    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.AcademicProgressTheory) & ""
        Me.AcademicProgressType = ClsMain.eAcademicProgressType.Theory
    End Sub

    Private Sub FrmAcademicProgressTheory_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        LblV_Type.Text = "Progress Type"
        LblV_Date.Text = "Progress Date"
        LblV_No.Text = "Progress No."
    End Sub

    Private Sub FrmPurchase_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Try
            With DGL1
                .Columns(Col1CoveredUnit).Visible = True
                .Columns(Col1Qty).HeaderText = Col1T_Qty
                .Columns(Col1T_CumulativeQty).HeaderText = Col1T_CumulativeQty
                .Columns(Col1T_CoveredPer_Course_Lab).HeaderText = Col1T_CoveredPer_Course_Lab
                .Columns(Col1T_CoveredUnit).HeaderText = Col1T_CoveredUnit
                .Columns(Col1T_Checked_Assignment_Practical).HeaderText = Col1T_Checked_Assignment_Practical
                .Columns(Col1T_Checked_Tutorial_Quiz).HeaderText = Col1T_Checked_Tutorial_Quiz
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class