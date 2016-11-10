Public Class TempPurchInvoice
    Inherits AgTemplate.TempPurchInvoiceCommon

    Protected WithEvents Label1 As System.Windows.Forms.Label
    Dim mQry$

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
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
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgMandatory = True
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblChallans, 0)
        Me.TP1.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(111, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 738
        Me.Label1.Text = "Ä"
        '
        'TempPurchInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1012, 622)
        Me.LogLineTableCsv = "PurchInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchInvoice_Log"
        Me.MainLineTableCsv = "PurchInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchInvoice"
        Me.Name = "TempPurchInvoice"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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

    End Sub
#End Region

    Private Sub TempPurchInvoice_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim StructDue As ClsMain.Dues = Nothing
        Dim I As Integer = 0
        With StructDue
            .DocID = mInternalCode
            .Sr = 1
            .V_Type = TxtV_Type.AgSelectedValue
            .V_Prefix = LblPrefix.Text
            .V_Date = TxtV_Date.Text
            .V_No = Val(TxtV_No.Text)
            .Div_Code = TxtDivision.AgSelectedValue
            .Site_Code = TxtSite_Code.AgSelectedValue
            .SubCode = TxtVendor.AgSelectedValue
            .Narration = ""
            .ReferenceDocID = ""
            .PaybleAmount = LblTotalAmount.Text
            .AdjustedAmount = 0
            .EntryBy = AgL.PubUserName
            .EntryDate = AgL.GetDateTime(AgL.GcnRead)
            .EntryType = Topctrl1.Mode
            .EntryStatus = LogStatus.LogOpen
            .IsDeleted = 0
            .Status = TxtStatus.Text
            .UID = mSearchCode
        End With

        Call ClsMain.ProcPostInDues(Conn, Cmd, StructDue)

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE PurchChallanDetail " & _
                            " SET InvoicedQty = (SELECT IsNull(Sum(Id.Qty),0) " & _
                            " 				    FROM PurchInvoiceDetail Id With (NoLock) " & _
                            "                   LEFT JOIN PurchInvoice I With (NoLock) On I.DocId = Id.DocId " & _
                            " 				    WHERE Id.PurchChallan = '" & .AgSelectedValue(Col1PurchChallan, I) & "' " & _
                            " 				    AND Id.Item = '" & .AgSelectedValue(Col1Item, I) & "'  " & _
                            "                   AND IsNull(I.IsDeleted,0) = 0  ), " & _
                            " InvoicedMeasure = (SELECT IsNull(Sum(Id.TotalMeasure),0) " & _
                            " 				    FROM PurchInvoiceDetail Id With (NoLock) " & _
                            "                   LEFT JOIN PurchInvoice I With (NoLock) On I.DocId = Id.DocId " & _
                            " 				    WHERE Id.PurchChallan = '" & .AgSelectedValue(Col1PurchChallan, I) & "' " & _
                            " 				    AND Id.Item = '" & .AgSelectedValue(Col1Item, I) & "'  " & _
                            "                   AND IsNull(I.IsDeleted,0) = 0 ) " & _
                            " WHERE DocId = '" & .AgSelectedValue(Col1PurchChallan, I) & "' " & _
                            " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String
            '// Check for relational data in Purchase Return
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo From PurchInvoiceDetail  L LEFT JOIN PurchInvoice H ON L.DocId = H.DocID WHERE L.ReferenceDocID  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0) = 0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Return " & bRData & " created against Invoice No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Function Validate_PurchChallan(ByVal RowIndex As Integer) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If Dgl2.AgSelectedValue(Col2PurchChallan, RowIndex) <> "" Then
                DrTemp = Dgl2.AgHelpDataSet(Col2PurchChallan).Tables(0).Select("Code = '" & Dgl2.AgSelectedValue(Col2PurchChallan, RowIndex) & "' ")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Purchase Challan """ & Dgl2.Item(Col2PurchChallan, RowIndex).Value & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Purchase Challan """ & Dgl2.Item(Col2PurchChallan, RowIndex).Value & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        Exit Function
                    End If
                End If
            End If
            Validate_PurchChallan = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub DGL2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If Dgl2.Rows.Count = 0 Then Exit Sub
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub
        Try
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col2Select
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(Col2Select).Index)
                    End If
            End Select
        Catch ex As Exception
            If AgL.StrCmp(Dgl2.Item(Col2Select, Dgl2.CurrentCell.RowIndex).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                If Validate_PurchChallan(Dgl2.CurrentCell.RowIndex) = False Then
                    Dgl2.Item(Col2Select, Dgl2.CurrentCell.RowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                End If
            End If
        End Try
    End Sub

    Private Sub DGL2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl2.CellMouseUp
        If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            If Dgl2.Rows.Count = 0 Then Exit Sub

            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col2Select
                    Call AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(Col2Select).Index)
            End Select
        Catch ex As Exception
            If AgL.StrCmp(Dgl2.Item(Col2Select, Dgl2.CurrentCell.RowIndex).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                If Validate_PurchChallan(Dgl2.CurrentCell.RowIndex) = False Then
                    Dgl2.Item(Col2Select, Dgl2.CurrentCell.RowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                End If
            End If
        End Try
    End Sub

    Private Sub TempPurchInvoice_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then passed = False : Exit Sub
        Dim I As Integer = 0
        With Dgl2
            For I = 0 To .Rows.Count - 1
                If AgL.StrCmp(.Item(Col2Select, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                    If Validate_PurchChallan(I) = False Then passed = False : Exit Sub
                End If
            Next
        End With

        passed = FCheckDuplicateRefNo()
    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True

        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'   " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'  " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        End If

        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE VendorDocNo = '" & TxtVendorDocNo.Text & "' And Vendor = '" & TxtVendor.AgSelectedValue & "'  " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Vendor Doc. No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE VendorDocNo = '" & TxtVendorDocNo.Text & "'  And Vendor = '" & TxtVendor.AgSelectedValue & "'  " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Vendor Doc No. Already Exists") : TxtReferenceNo.Focus()
        End If
    End Function


    'Start Code By Satyam on 18/11/2011
    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text
            End If
        End If
    End Sub

    'Code End By Satyam on 18/11/2011

    Private Sub TempPurchInvoice_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        Call ProcFillReferenceNo()
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtReferenceNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    Call ProcFillReferenceNo()

                Case TxtReferenceNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempPurchInvoice_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim i As Integer
        mQry = "Update Dues Set IsDeleted=1 Where DocId = '" & mInternalCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE PurchChallanDetail " & _
                            " SET InvoicedQty = (SELECT IsNull(Sum(Id.Qty),0) " & _
                            " 				    FROM PurchInvoiceDetail Id With (NoLock) " & _
                            "                   LEFT JOIN PurchInvoice I With (NoLock) On I.DocId = Id.DocId " & _
                            " 				    WHERE Id.PurchChallan = '" & .AgSelectedValue(Col1PurchChallan, I) & "' " & _
                            " 				    AND Id.Item = '" & .AgSelectedValue(Col1Item, I) & "'  " & _
                            "                   AND IsNull(I.IsDeleted,0) = 0  ), " & _
                            " InvoicedMeasure = (SELECT IsNull(Sum(Id.TotalMeasure),0) " & _
                            " 				    FROM PurchInvoiceDetail Id With (NoLock) " & _
                            "                   LEFT JOIN PurchInvoice I With (NoLock) On I.DocId = Id.DocId " & _
                            " 				    WHERE Id.PurchChallan = '" & .AgSelectedValue(Col1PurchChallan, I) & "' " & _
                            " 				    AND Id.Item = '" & .AgSelectedValue(Col1Item, I) & "'  " & _
                            "                   AND IsNull(I.IsDeleted,0) = 0 ) " & _
                            " WHERE DocId = '" & .AgSelectedValue(Col1PurchChallan, I) & "' " & _
                            " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub
End Class
