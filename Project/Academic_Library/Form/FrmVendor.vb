Public Class FrmVendor
    Inherits AgTemplate.TempSubGroup

    Protected WithEvents LblCategory As System.Windows.Forms.Label
    Protected WithEvents TxtCategory As AgControls.AgTextBox
    Protected WithEvents LblCategoryReq As System.Windows.Forms.Label
    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        '  This call is required by the Windows Form Designer.
        InitializeComponent()
        '  Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.MainTable = "Vendor"
        Me.LogTable = "Vendor_Log"
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtCategory = New AgControls.AgTextBox
        Me.LblCategory = New System.Windows.Forms.Label
        Me.LblCategoryReq = New System.Windows.Forms.Label
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
        Me.LblAcGroupReq.Location = New System.Drawing.Point(338, 138)
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(186, 92)
        Me.LblName.Size = New System.Drawing.Size(147, 16)
        Me.LblName.Text = "Vendor/Customer Name"
        '
        'TxtDispName
        '
        Me.TxtDispName.Location = New System.Drawing.Point(357, 91)
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(186, 72)
        Me.LblManualCode.Size = New System.Drawing.Size(143, 16)
        Me.LblManualCode.Text = "Vendor/Customer Code"
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
        Me.TxtAdd3.Location = New System.Drawing.Point(357, 191)
        Me.TxtAdd3.TabIndex = 6
        '
        'LblAddress
        '
        Me.LblAddress.Location = New System.Drawing.Point(186, 152)
        '
        'TxtAdd1
        '
        Me.TxtAdd1.Location = New System.Drawing.Point(357, 151)
        Me.TxtAdd1.TabIndex = 4
        '
        'TxtAdd2
        '
        Me.TxtAdd2.Location = New System.Drawing.Point(357, 171)
        Me.TxtAdd2.TabIndex = 5
        '
        'LblAddressReq
        '
        Me.LblAddressReq.Location = New System.Drawing.Point(338, 159)
        '
        'LblCity
        '
        Me.LblCity.Location = New System.Drawing.Point(186, 211)
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(357, 211)
        Me.TxtCity.TabIndex = 7
        '
        'LblCityReq
        '
        Me.LblCityReq.Location = New System.Drawing.Point(338, 218)
        '
        'LblPhone
        '
        Me.LblPhone.Location = New System.Drawing.Point(186, 231)
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(357, 231)
        Me.TxtPhone.TabIndex = 9
        '
        'LblFax
        '
        Me.LblFax.Location = New System.Drawing.Point(186, 251)
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(357, 251)
        Me.TxtFax.TabIndex = 10
        '
        'LblEMail
        '
        Me.LblEMail.Location = New System.Drawing.Point(186, 271)
        '
        'TxtEMail
        '
        Me.TxtEMail.Location = New System.Drawing.Point(357, 271)
        Me.TxtEMail.TabIndex = 11
        '
        'LblCountry
        '
        Me.LblCountry.Location = New System.Drawing.Point(495, 212)
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.Location = New System.Drawing.Point(357, 131)
        Me.TxtAcGroup.TabIndex = 3
        '
        'LblAcGroup
        '
        Me.LblAcGroup.Location = New System.Drawing.Point(186, 132)
        '
        'TxtCountry
        '
        Me.TxtCountry.Location = New System.Drawing.Point(548, 211)
        Me.TxtCountry.TabIndex = 8
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(919, 4)
        '
        'TxtCategory
        '
        Me.TxtCategory.AgMandatory = True
        Me.TxtCategory.AgMasterHelp = False
        Me.TxtCategory.AgNumberLeftPlaces = 0
        Me.TxtCategory.AgNumberNegetiveAllow = False
        Me.TxtCategory.AgNumberRightPlaces = 0
        Me.TxtCategory.AgPickFromLastValue = False
        Me.TxtCategory.AgRowFilter = ""
        Me.TxtCategory.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCategory.AgSelectedValue = Nothing
        Me.TxtCategory.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCategory.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCategory.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCategory.Location = New System.Drawing.Point(357, 111)
        Me.TxtCategory.MaxLength = 20
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(292, 18)
        Me.TxtCategory.TabIndex = 2
        '
        'LblCategory
        '
        Me.LblCategory.AutoSize = True
        Me.LblCategory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategory.Location = New System.Drawing.Point(186, 112)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.Size = New System.Drawing.Size(60, 16)
        Me.LblCategory.TabIndex = 892
        Me.LblCategory.Text = "Category"
        '
        'LblCategoryReq
        '
        Me.LblCategoryReq.AutoSize = True
        Me.LblCategoryReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblCategoryReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCategoryReq.Location = New System.Drawing.Point(338, 119)
        Me.LblCategoryReq.Name = "LblCategoryReq"
        Me.LblCategoryReq.Size = New System.Drawing.Size(10, 7)
        Me.LblCategoryReq.TabIndex = 893
        Me.LblCategoryReq.Text = "Ä"
        '
        'FrmVendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 486)
        Me.Controls.Add(Me.LblCategoryReq)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.LblCategory)
        Me.LogLineTableCsv = ""
        Me.LogTableName = "SubGroup_LOG"
        Me.MainLineTableCsv = ","
        Me.MainTableName = "SubGroup"
        Me.Name = "FrmVendor"
        Me.PrimaryField = "SubCode"
        Me.Text = "Vendor/Customer Master"
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
        Me.Controls.SetChildIndex(Me.LblCategory, 0)
        Me.Controls.SetChildIndex(Me.TxtCategory, 0)
        Me.Controls.SetChildIndex(Me.LblCategoryReq, 0)
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

    Private Sub FrmVendor_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtCategory, LblCategory.Text) Then passed = False : Exit Sub
    End Sub

    Private Sub FrmVendor_BaseEvent_Save_SubGroupInTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_SubGroupInTrans
        mQry = " UPDATE Vendor_Log " & _
                " Set Category = '" & TxtCategory.AgSelectedValue & "' " & _
                " Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmVendor_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If DtLib_Enviro.Rows.Count > 0 Then
            If AgL.VNull(DtLib_Enviro.Rows(0)("IsLinkWithAcademic")) <> 0 Then
                TxtAcGroup.Enabled = True
            Else
                TxtAcGroup.Enabled = False
            End If
        End If
    End Sub

    Private Sub FrmVendor_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " Select 'Supplier' As Code, 'Vendor' As Description " & _
                " UNION ALL " & _
                " Select 'Customer' As Code, 'Customer' As Description "
        TxtCategory.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmVendor_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet = Nothing
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From Vendot H " & _
                " Where H.SubCode ='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                    " From Vendor_Log H " & _
                    " Where H.UID ='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
            End If
        End With
    End Sub

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 440, 885, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAcGroup.Enter
        Try
            Select Case sender.name
                Case TxtAcGroup.Name
                    TxtAcGroup.AgRowFilter = " Nature = '" & TxtCategory.AgSelectedValue & "' "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCategory.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtCategory.Name
                    If TxtCategory.Text <> "" Then
                        If AgL.StrCmp(TxtCategory.AgSelectedValue, "Supplier") Then
                            TxtAcGroup.AgSelectedValue = "0016"
                        ElseIf AgL.StrCmp(TxtCategory.AgSelectedValue, "Customer") Then
                            TxtAcGroup.AgSelectedValue = "0020"
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmMember_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1 and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  And IsNull(SG.IsDeleted,0) = 0 "

        AgL.PubFindQry = "SELECT M.Uid AS SearchCode, Sg.DispName AS [Vendor Name], " & _
                            " Sg.ManualCode AS [Vendor Code], M.Category,  " & _
                            " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                            " City.CityName AS City, Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail " & _
                            " FROM Vendor_Log M " & _
                            " LEFT JOIN SubGroup_Log Sg ON Sg.Uid = M.Uid " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr & _
                            " And SG.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "

        AgL.PubFindQryOrdBy = "[Vendor Name]"
    End Sub

    Private Sub FrmMember_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1  and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  And IsNull(Sg.IsDeleted,0) = 0  "

        AgL.PubFindQry = "SELECT M.SubCode AS SearchCode, Sg.DispName AS [Vendor Name], " & _
                            " Sg.ManualCode AS [Vendor Code], M.Category,  " & _
                            " IsNull(Sg.Add1,'')+ Space(1) +IsNull(Sg.Add2,'')+ Space(1) +IsNull(Sg.Add3,'') AS Address, " & _
                            " City.CityName AS City, Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail " & _
                            " FROM Vendor M " & _
                            " LEFT JOIN SubGroup Sg ON Sg.SubCode = M.SubCode  " & _
                            " LEFT JOIN City ON City.CityCode = Sg.CityCode " & mConStr

        AgL.PubFindQryOrdBy = "[Vendor Name]"
    End Sub

End Class
