'Public Class FrmParty

'End Class
Public Class FrmSupplier
    Inherits Academic_ProjLib.TempParty

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.AglObj = AgL

        If DtMess_Enviro.Rows.Count > 0 Then
            Me.SalesTaxPostingGroup = AglObj.XNull(DtMess_Enviro.Rows(0)("SalesTaxGroupParty"))
        End If

    End Sub

#Region "Form Designer"
    Private Sub InitializeComponent()
        Me.GBoxModified.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.SuspendLayout()
        '
        'FrmSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 466)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmSupplier"
        Me.GBoxModified.ResumeLayout(False)
        Me.GBoxModified.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxApproved.ResumeLayout(False)
        Me.GBoxApproved.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Sub Form_BaseEvent_Form_PreLoad()
        '<Executable code>
    End Sub

    Private Sub FrmParty_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim bCondStr$ = " Where 1=1 "

        bCondStr += " And IsNull(H.Party_Type,0) = " & Party_Type & " "
        bCondStr += " And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Site_Code", AglObj.PubSiteCode, "CommonAc") & " "

        If MasterType.Trim <> "" Then
            bCondStr += " And IsNull(P.MasterType,'') = '" & MasterType & "' "
        End If

        AglObj.PubFindQry = "Select  H.SubCode As SearchCode, H.ManualCode As [" & LblManualCode.Text & "], H.Name As [" & LblName.Text & "],  H.DispName As [" & LblDispName.Text & "], " & _
                            " IsNull(H.Add1,'') + Space(1) +  IsNull(H.Add2,'') + Space(1) + IsNull(H.Add3,'') As [" & LblAdd1.Text & "],  City.CityName As [" & LblCityCode.Text & "], " & _
                            " H.Phone As [Phone No.],  H.Mobile As [Mobile No.] " & _
                            " From Party P With (NoLock) " & _
                            " Left Join SubGroup H With (NoLock) On H.SubCode = P.SubCode " & _
                            " Left Join  City  With (NoLock) On City.CityCode = H.CityCode " & _
                            " " & bCondStr & " "
        AglObj.PubFindQryOrdBy = "[" & LblName.Text & "]"
    End Sub

End Class
