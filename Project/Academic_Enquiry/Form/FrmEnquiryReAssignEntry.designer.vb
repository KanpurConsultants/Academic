<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnquiryReAssignEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.BtnFillGrid = New System.Windows.Forms.Button
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.CMnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuFilterSame = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFilterNotSame = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRemoveFilter = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.LblEnquiryMode = New System.Windows.Forms.Label
        Me.TxtEnquiryMode = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtTransferFrom = New AgControls.AgTextBox
        Me.LblAssignedTo = New System.Windows.Forms.Label
        Me.TxtAssignedTo = New AgControls.AgTextBox
        Me.BtnExit = New System.Windows.Forms.Button
        Me.LblSelectAll = New System.Windows.Forms.Label
        Me.TxtSelectAll = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSelectTopRows = New AgControls.AgTextBox
        Me.CMnu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(0, -29)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(10, 41)
        Me.Topctrl1.TabIndex = 935
        Me.Topctrl1.tAdd = True
        Me.Topctrl1.tCancel = True
        Me.Topctrl1.tDel = True
        Me.Topctrl1.tDiscard = False
        Me.Topctrl1.tEdit = True
        Me.Topctrl1.tExit = True
        Me.Topctrl1.tFind = True
        Me.Topctrl1.tFirst = True
        Me.Topctrl1.tLast = True
        Me.Topctrl1.tNext = True
        Me.Topctrl1.tPrev = True
        Me.Topctrl1.tPrn = True
        Me.Topctrl1.tRef = True
        Me.Topctrl1.tSave = False
        Me.Topctrl1.tSite = True
        Me.Topctrl1.Visible = False
        '
        'BtnFillGrid
        '
        Me.BtnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillGrid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillGrid.Location = New System.Drawing.Point(782, 45)
        Me.BtnFillGrid.Name = "BtnFillGrid"
        Me.BtnFillGrid.Size = New System.Drawing.Size(65, 26)
        Me.BtnFillGrid.TabIndex = 5
        Me.BtnFillGrid.Text = "&Fill"
        Me.BtnFillGrid.UseVisualStyleBackColor = True
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(8, 70)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(979, 538)
        Me.Pnl1.TabIndex = 6
        '
        'CMnu
        '
        Me.CMnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFilterSame, Me.mnuFilterNotSame, Me.mnuRemoveFilter, Me.MnuExportToExcel})
        Me.CMnu.Name = "CMnu"
        Me.CMnu.Size = New System.Drawing.Size(198, 92)
        '
        'mnuFilterSame
        '
        Me.mnuFilterSame.Name = "mnuFilterSame"
        Me.mnuFilterSame.Size = New System.Drawing.Size(197, 22)
        Me.mnuFilterSame.Text = "Filter Similar Records"
        '
        'mnuFilterNotSame
        '
        Me.mnuFilterNotSame.Name = "mnuFilterNotSame"
        Me.mnuFilterNotSame.Size = New System.Drawing.Size(197, 22)
        Me.mnuFilterNotSame.Text = "Filter Dissimilar Records"
        '
        'mnuRemoveFilter
        '
        Me.mnuRemoveFilter.Name = "mnuRemoveFilter"
        Me.mnuRemoveFilter.Size = New System.Drawing.Size(197, 22)
        Me.mnuRemoveFilter.Text = "Remove All Filter"
        '
        'MnuExportToExcel
        '
        Me.MnuExportToExcel.Name = "MnuExportToExcel"
        Me.MnuExportToExcel.Size = New System.Drawing.Size(197, 22)
        Me.MnuExportToExcel.Text = "Export To Excel"
        '
        'BtnUpdate
        '
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.Location = New System.Drawing.Point(854, 45)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(65, 26)
        Me.BtnUpdate.TabIndex = 7
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'LblEnquiryMode
        '
        Me.LblEnquiryMode.AutoSize = True
        Me.LblEnquiryMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEnquiryMode.Location = New System.Drawing.Point(5, 16)
        Me.LblEnquiryMode.Name = "LblEnquiryMode"
        Me.LblEnquiryMode.Size = New System.Drawing.Size(81, 15)
        Me.LblEnquiryMode.TabIndex = 972
        Me.LblEnquiryMode.Text = "Enquiry Mode"
        '
        'TxtEnquiryMode
        '
        Me.TxtEnquiryMode.AgAllowUserToEnableMasterHelp = False
        Me.TxtEnquiryMode.AgMandatory = False
        Me.TxtEnquiryMode.AgMasterHelp = False
        Me.TxtEnquiryMode.AgNumberLeftPlaces = 0
        Me.TxtEnquiryMode.AgNumberNegetiveAllow = False
        Me.TxtEnquiryMode.AgNumberRightPlaces = 0
        Me.TxtEnquiryMode.AgPickFromLastValue = False
        Me.TxtEnquiryMode.AgRowFilter = ""
        Me.TxtEnquiryMode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEnquiryMode.AgSelectedValue = Nothing
        Me.TxtEnquiryMode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEnquiryMode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEnquiryMode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEnquiryMode.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEnquiryMode.Location = New System.Drawing.Point(88, 14)
        Me.TxtEnquiryMode.MaxLength = 25
        Me.TxtEnquiryMode.Name = "TxtEnquiryMode"
        Me.TxtEnquiryMode.Size = New System.Drawing.Size(100, 19)
        Me.TxtEnquiryMode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(193, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 974
        Me.Label1.Text = "Transfer From"
        '
        'TxtTransferFrom
        '
        Me.TxtTransferFrom.AgAllowUserToEnableMasterHelp = False
        Me.TxtTransferFrom.AgMandatory = False
        Me.TxtTransferFrom.AgMasterHelp = False
        Me.TxtTransferFrom.AgNumberLeftPlaces = 0
        Me.TxtTransferFrom.AgNumberNegetiveAllow = False
        Me.TxtTransferFrom.AgNumberRightPlaces = 0
        Me.TxtTransferFrom.AgPickFromLastValue = False
        Me.TxtTransferFrom.AgRowFilter = ""
        Me.TxtTransferFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransferFrom.AgSelectedValue = Nothing
        Me.TxtTransferFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransferFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransferFrom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransferFrom.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransferFrom.Location = New System.Drawing.Point(282, 14)
        Me.TxtTransferFrom.MaxLength = 50
        Me.TxtTransferFrom.Name = "TxtTransferFrom"
        Me.TxtTransferFrom.Size = New System.Drawing.Size(178, 19)
        Me.TxtTransferFrom.TabIndex = 1
        '
        'LblAssignedTo
        '
        Me.LblAssignedTo.AutoSize = True
        Me.LblAssignedTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAssignedTo.Location = New System.Drawing.Point(466, 16)
        Me.LblAssignedTo.Name = "LblAssignedTo"
        Me.LblAssignedTo.Size = New System.Drawing.Size(76, 15)
        Me.LblAssignedTo.TabIndex = 976
        Me.LblAssignedTo.Text = "Assigned To"
        '
        'TxtAssignedTo
        '
        Me.TxtAssignedTo.AgAllowUserToEnableMasterHelp = False
        Me.TxtAssignedTo.AgMandatory = False
        Me.TxtAssignedTo.AgMasterHelp = False
        Me.TxtAssignedTo.AgNumberLeftPlaces = 0
        Me.TxtAssignedTo.AgNumberNegetiveAllow = False
        Me.TxtAssignedTo.AgNumberRightPlaces = 0
        Me.TxtAssignedTo.AgPickFromLastValue = False
        Me.TxtAssignedTo.AgRowFilter = ""
        Me.TxtAssignedTo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAssignedTo.AgSelectedValue = Nothing
        Me.TxtAssignedTo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAssignedTo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAssignedTo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAssignedTo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssignedTo.Location = New System.Drawing.Point(544, 14)
        Me.TxtAssignedTo.MaxLength = 50
        Me.TxtAssignedTo.Name = "TxtAssignedTo"
        Me.TxtAssignedTo.Size = New System.Drawing.Size(178, 19)
        Me.TxtAssignedTo.TabIndex = 2
        '
        'BtnExit
        '
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(922, 45)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(65, 26)
        Me.BtnExit.TabIndex = 8
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'LblSelectAll
        '
        Me.LblSelectAll.AutoSize = True
        Me.LblSelectAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectAll.Location = New System.Drawing.Point(731, 16)
        Me.LblSelectAll.Name = "LblSelectAll"
        Me.LblSelectAll.Size = New System.Drawing.Size(57, 15)
        Me.LblSelectAll.TabIndex = 978
        Me.LblSelectAll.Text = "Select All"
        '
        'TxtSelectAll
        '
        Me.TxtSelectAll.AgAllowUserToEnableMasterHelp = False
        Me.TxtSelectAll.AgMandatory = False
        Me.TxtSelectAll.AgMasterHelp = False
        Me.TxtSelectAll.AgNumberLeftPlaces = 0
        Me.TxtSelectAll.AgNumberNegetiveAllow = False
        Me.TxtSelectAll.AgNumberRightPlaces = 0
        Me.TxtSelectAll.AgPickFromLastValue = False
        Me.TxtSelectAll.AgRowFilter = ""
        Me.TxtSelectAll.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectAll.AgSelectedValue = Nothing
        Me.TxtSelectAll.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectAll.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtSelectAll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSelectAll.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectAll.Location = New System.Drawing.Point(794, 14)
        Me.TxtSelectAll.MaxLength = 0
        Me.TxtSelectAll.Name = "TxtSelectAll"
        Me.TxtSelectAll.Size = New System.Drawing.Size(46, 19)
        Me.TxtSelectAll.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(845, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 980
        Me.Label2.Text = "Selct Top Rows"
        '
        'TxtSelectTopRows
        '
        Me.TxtSelectTopRows.AgAllowUserToEnableMasterHelp = False
        Me.TxtSelectTopRows.AgMandatory = False
        Me.TxtSelectTopRows.AgMasterHelp = False
        Me.TxtSelectTopRows.AgNumberLeftPlaces = 5
        Me.TxtSelectTopRows.AgNumberNegetiveAllow = False
        Me.TxtSelectTopRows.AgNumberRightPlaces = 0
        Me.TxtSelectTopRows.AgPickFromLastValue = False
        Me.TxtSelectTopRows.AgRowFilter = ""
        Me.TxtSelectTopRows.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectTopRows.AgSelectedValue = Nothing
        Me.TxtSelectTopRows.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectTopRows.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSelectTopRows.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSelectTopRows.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectTopRows.Location = New System.Drawing.Point(941, 14)
        Me.TxtSelectTopRows.MaxLength = 0
        Me.TxtSelectTopRows.Name = "TxtSelectTopRows"
        Me.TxtSelectTopRows.Size = New System.Drawing.Size(46, 19)
        Me.TxtSelectTopRows.TabIndex = 4
        '
        'FrmEnquiryReAssignEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 618)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSelectTopRows)
        Me.Controls.Add(Me.LblSelectAll)
        Me.Controls.Add(Me.TxtSelectAll)
        Me.Controls.Add(Me.LblAssignedTo)
        Me.Controls.Add(Me.BtnFillGrid)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.TxtAssignedTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTransferFrom)
        Me.Controls.Add(Me.LblEnquiryMode)
        Me.Controls.Add(Me.TxtEnquiryMode)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.Topctrl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEnquiryReAssignEntry"
        Me.Text = "Enquiry Assign Entry"
        Me.CMnu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents BtnFillGrid As System.Windows.Forms.Button
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents CMnu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuFilterSame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFilterNotSame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents MnuExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblEnquiryMode As System.Windows.Forms.Label
    Friend WithEvents TxtEnquiryMode As AgControls.AgTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTransferFrom As AgControls.AgTextBox
    Friend WithEvents LblAssignedTo As System.Windows.Forms.Label
    Friend WithEvents TxtAssignedTo As AgControls.AgTextBox
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents LblSelectAll As System.Windows.Forms.Label
    Friend WithEvents TxtSelectAll As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSelectTopRows As AgControls.AgTextBox
End Class
