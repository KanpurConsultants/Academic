Public Class FrmBuyerMaster
    Inherits AgTemplate.TempSubGroup

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.MainTable = "Buyer"
        Me.LogTable = "Buyer_Log"
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblAcGroupReq
        '
        Me.LblAcGroupReq.Location = New System.Drawing.Point(338, 118)
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(228, 92)
        Me.LblName.Size = New System.Drawing.Size(80, 16)
        Me.LblName.Text = "Buyer Name"
        '
        'TxtDispName
        '
        Me.TxtDispName.Location = New System.Drawing.Point(357, 91)
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(228, 72)
        Me.LblManualCode.Size = New System.Drawing.Size(76, 16)
        Me.LblManualCode.Text = "Buyer Code"
        '
        'TxtManualCode
        '
        Me.TxtManualCode.Location = New System.Drawing.Point(357, 71)
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(338, 78)
        '
        'LblNameReq
        '
        Me.LblNameReq.Location = New System.Drawing.Point(338, 98)
        '
        'TxtAdd3
        '
        Me.TxtAdd3.Location = New System.Drawing.Point(357, 171)
        '
        'LblAddress
        '
        Me.LblAddress.Location = New System.Drawing.Point(228, 132)
        '
        'TxtAdd1
        '
        Me.TxtAdd1.Location = New System.Drawing.Point(357, 131)
        '
        'TxtAdd2
        '
        Me.TxtAdd2.Location = New System.Drawing.Point(357, 151)
        '
        'LblAddressReq
        '
        Me.LblAddressReq.Location = New System.Drawing.Point(338, 139)
        '
        'LblCity
        '
        Me.LblCity.Location = New System.Drawing.Point(228, 191)
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(357, 191)
        '
        'LblCityReq
        '
        Me.LblCityReq.Location = New System.Drawing.Point(338, 198)
        '
        'LblPhone
        '
        Me.LblPhone.Location = New System.Drawing.Point(228, 211)
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(357, 211)
        '
        'LblFax
        '
        Me.LblFax.Location = New System.Drawing.Point(228, 231)
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(357, 231)
        '
        'LblEMail
        '
        Me.LblEMail.Location = New System.Drawing.Point(228, 251)
        '
        'TxtEMail
        '
        Me.TxtEMail.Location = New System.Drawing.Point(357, 251)
        '
        'LblCountry
        '
        Me.LblCountry.Location = New System.Drawing.Point(495, 192)
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.Location = New System.Drawing.Point(357, 111)
        '
        'LblAcGroup
        '
        Me.LblAcGroup.Location = New System.Drawing.Point(228, 112)
        '
        'TxtCountry
        '
        Me.TxtCountry.Location = New System.Drawing.Point(548, 191)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(919, 4)
        '
        'FrmBuyerMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 486)
        Me.LogLineTableCsv = ""
        Me.LogTableName = "SubGroup_LOG"
        Me.MainTableName = "SubGroup"
        Me.Name = "FrmBuyerMaster"
        Me.PrimaryField = "SubCode"
        Me.Text = "Employee Master"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
  
    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 440, 885, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub


    Private Sub FrmMember_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1 and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  And IsNull(SG.IsDeleted,0) = 0 "

        AgL.PubFindQry = "SELECT M.Uid AS SearchCode, Sg.DispName AS [Buyer Name], " & _
                            " Sg.ManualCode AS [Buyer Code],  " & _
                            " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                            " City.CityName AS City, Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail " & _
                            " FROM Buyer_Log M " & _
                            " LEFT JOIN SubGroup_Log Sg ON Sg.Uid = M.Uid " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr & _
                            " And SG.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "

        AgL.PubFindQryOrdBy = "[Buyer Name]"
    End Sub

    Private Sub FrmMember_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1  and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  And IsNull(Sg.IsDeleted,0) = 0  "

        AgL.PubFindQry = "SELECT M.SubCode AS SearchCode, Sg.DispName AS [Buyer Name], " & _
                            " Sg.ManualCode AS [Buyer Code],  " & _
                            " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                            " City.CityName AS City, Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail " & _
                            " FROM Buyer M " & _
                            " LEFT JOIN SubGroup Sg ON Sg.SubCode = M.SubCode  " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr

        AgL.PubFindQryOrdBy = "[Buyer Name]"
    End Sub
End Class
