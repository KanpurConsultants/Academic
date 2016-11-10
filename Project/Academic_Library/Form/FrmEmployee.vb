Public Class FrmEmployee
    Inherits AgTemplate.TempSubGroup

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.MainTable = "Pay_Employee"
        Me.LogTable = "Pay_Employee_Log"
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtDesignation = New AgControls.AgTextBox
        Me.LblDesignation = New System.Windows.Forms.Label
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
        Me.LblAcGroupReq.Location = New System.Drawing.Point(338, 311)
        Me.LblAcGroupReq.Visible = False
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(228, 92)
        Me.LblName.Size = New System.Drawing.Size(104, 16)
        Me.LblName.Text = "Employee Name"
        '
        'TxtDispName
        '
        Me.TxtDispName.Location = New System.Drawing.Point(357, 91)
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(228, 72)
        Me.LblManualCode.Size = New System.Drawing.Size(100, 16)
        Me.LblManualCode.Text = "Employee Code"
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
        Me.TxtAdd3.Location = New System.Drawing.Point(357, 151)
        '
        'LblAddress
        '
        Me.LblAddress.Location = New System.Drawing.Point(228, 112)
        '
        'TxtAdd1
        '
        Me.TxtAdd1.Location = New System.Drawing.Point(357, 111)
        '
        'TxtAdd2
        '
        Me.TxtAdd2.Location = New System.Drawing.Point(357, 131)
        '
        'LblAddressReq
        '
        Me.LblAddressReq.Location = New System.Drawing.Point(338, 119)
        '
        'LblCity
        '
        Me.LblCity.Location = New System.Drawing.Point(228, 171)
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(357, 171)
        '
        'LblCityReq
        '
        Me.LblCityReq.Location = New System.Drawing.Point(338, 178)
        '
        'LblPhone
        '
        Me.LblPhone.Location = New System.Drawing.Point(228, 191)
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(357, 191)
        '
        'LblFax
        '
        Me.LblFax.Location = New System.Drawing.Point(228, 211)
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(357, 211)
        '
        'LblEMail
        '
        Me.LblEMail.Location = New System.Drawing.Point(228, 231)
        '
        'TxtEMail
        '
        Me.TxtEMail.Location = New System.Drawing.Point(357, 231)
        '
        'LblCountry
        '
        Me.LblCountry.Location = New System.Drawing.Point(495, 172)
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.Location = New System.Drawing.Point(357, 304)
        Me.TxtAcGroup.Visible = False
        '
        'LblAcGroup
        '
        Me.LblAcGroup.Location = New System.Drawing.Point(228, 305)
        Me.LblAcGroup.Visible = False
        '
        'TxtCountry
        '
        Me.TxtCountry.Location = New System.Drawing.Point(548, 171)
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
        'TxtDesignation
        '
        Me.TxtDesignation.AgMandatory = False
        Me.TxtDesignation.AgMasterHelp = True
        Me.TxtDesignation.AgNumberLeftPlaces = 0
        Me.TxtDesignation.AgNumberNegetiveAllow = False
        Me.TxtDesignation.AgNumberRightPlaces = 0
        Me.TxtDesignation.AgPickFromLastValue = False
        Me.TxtDesignation.AgRowFilter = ""
        Me.TxtDesignation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDesignation.AgSelectedValue = Nothing
        Me.TxtDesignation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDesignation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDesignation.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesignation.Location = New System.Drawing.Point(357, 251)
        Me.TxtDesignation.MaxLength = 20
        Me.TxtDesignation.Name = "TxtDesignation"
        Me.TxtDesignation.Size = New System.Drawing.Size(292, 18)
        Me.TxtDesignation.TabIndex = 11
        '
        'LblDesignation
        '
        Me.LblDesignation.AutoSize = True
        Me.LblDesignation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesignation.Location = New System.Drawing.Point(228, 252)
        Me.LblDesignation.Name = "LblDesignation"
        Me.LblDesignation.Size = New System.Drawing.Size(76, 16)
        Me.LblDesignation.TabIndex = 867
        Me.LblDesignation.Text = "Designation"
        '
        'FrmEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 486)
        Me.Controls.Add(Me.TxtDesignation)
        Me.Controls.Add(Me.LblDesignation)
        Me.LogLineTableCsv = ""
        Me.LogTableName = "SubGroup_LOG"
        Me.MainTableName = "SubGroup"
        Me.Name = "FrmEmployee"
        Me.PrimaryField = "SubCode"
        Me.Text = "Employee Master"
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.LblName, 0)
        Me.Controls.SetChildIndex(Me.TxtDispName, 0)
        Me.Controls.SetChildIndex(Me.LblManualCode, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblManualCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblNameReq, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd3, 0)
        Me.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd2, 0)
        Me.Controls.SetChildIndex(Me.LblAddressReq, 0)
        Me.Controls.SetChildIndex(Me.LblCity, 0)
        Me.Controls.SetChildIndex(Me.TxtCity, 0)
        Me.Controls.SetChildIndex(Me.LblCityReq, 0)
        Me.Controls.SetChildIndex(Me.LblPhone, 0)
        Me.Controls.SetChildIndex(Me.TxtPhone, 0)
        Me.Controls.SetChildIndex(Me.LblFax, 0)
        Me.Controls.SetChildIndex(Me.TxtFax, 0)
        Me.Controls.SetChildIndex(Me.LblEMail, 0)
        Me.Controls.SetChildIndex(Me.TxtEMail, 0)
        Me.Controls.SetChildIndex(Me.LblCountry, 0)
        Me.Controls.SetChildIndex(Me.TxtCountry, 0)
        Me.Controls.SetChildIndex(Me.LblAcGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtAcGroup, 0)
        Me.Controls.SetChildIndex(Me.LblAcGroupReq, 0)
        Me.Controls.SetChildIndex(Me.LblDesignation, 0)
        Me.Controls.SetChildIndex(Me.TxtDesignation, 0)
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
    Protected WithEvents LblDesignation As System.Windows.Forms.Label
    Protected WithEvents TxtDesignation As AgControls.AgTextBox
#End Region

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 440, 885, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmEmployee_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select E.* " & _
                " From Pay_Employee E " & _
                " Where E.SubCode ='" & SearchCode & "'"
        Else
            mQry = "Select E.* " & _
                " From Pay_Employee_Log E " & _
                " Where E.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtDesignation.Text = AgL.XNull(.Rows(0)("Designation"))
            End If
        End With
    End Sub

    Private Sub FrmEmployee_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Distinct E.Designation As Code, E.Designation From Pay_Employee E Where Designation Is Not Null "
        TxtDesignation.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmEmployee_BaseEvent_Save_SubGroupInTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_SubGroupInTrans
        mQry = "UPDATE Pay_Employee_Log " & _
              " SET " & _
              " Designation = " & AgL.Chk_Text(TxtDesignation.Text) & " " & _
              " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub Topctrl_Add() Handles Topctrl1.tbAdd
        If DtLib_Enviro.Rows.Count > 0 Then
            If AgL.XNull(DtLib_Enviro.Rows(0)("EmployeeACGroup")) <> "" Then
                TxtAcGroup.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("EmployeeACGroup"))
            Else
                MsgBox("Fill Employee A/c Group In Enviro...!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Fill Enviro...!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub FrmMember_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1 and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  And IsNull(SG.IsDeleted,0) = 0 "

        AgL.PubFindQry = "SELECT M.Uid AS SearchCode, Sg.DispName AS [" & LblName.Text & "], " & _
                            " Sg.ManualCode AS [" & LblManualCode.Text & "], M.Designation,  " & _
                            " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                            " City.CityName AS City, Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail " & _
                            " FROM Pay_Employee_Log M " & _
                            " LEFT JOIN SubGroup_Log Sg ON Sg.Uid = M.Uid " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr & _
                            " And SG.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "

        AgL.PubFindQryOrdBy = "[" & LblName.Text & "]"
    End Sub

    Private Sub FrmMember_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1  and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  And IsNull(Sg.IsDeleted,0) = 0  "

        AgL.PubFindQry = "SELECT M.SubCode AS SearchCode, Sg.DispName AS [" & LblName.Text & "], " & _
                            " Sg.ManualCode AS [" & LblManualCode.Text & "], M.Designation,  " & _
                            " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                            " City.CityName AS City, Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail " & _
                            " FROM Pay_Employee M " & _
                            " LEFT JOIN SubGroup Sg ON Sg.SubCode = M.SubCode  " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr

        AgL.PubFindQryOrdBy = "[" & LblName.Text & "]"
    End Sub
End Class
