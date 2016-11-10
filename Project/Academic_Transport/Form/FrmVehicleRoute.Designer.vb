<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleRoute
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblVehicleReq = New System.Windows.Forms.Label
        Me.TxtVehicle = New AgControls.AgTextBox
        Me.LblVehicle = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LblRouteReq = New System.Windows.Forms.Label
        Me.TxtRoute = New AgControls.AgTextBox
        Me.LblRoute = New System.Windows.Forms.Label
        Me.LblAllotmentDate = New System.Windows.Forms.Label
        Me.TxtAllotmentDate = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.LinkLblTitle = New System.Windows.Forms.LinkLabel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(872, 41)
        Me.Topctrl1.TabIndex = 4
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
        '
        'LblVehicleReq
        '
        Me.LblVehicleReq.AutoSize = True
        Me.LblVehicleReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblVehicleReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblVehicleReq.Location = New System.Drawing.Point(301, 99)
        Me.LblVehicleReq.Name = "LblVehicleReq"
        Me.LblVehicleReq.Size = New System.Drawing.Size(10, 7)
        Me.LblVehicleReq.TabIndex = 37
        Me.LblVehicleReq.Text = "Ä"
        '
        'TxtVehicle
        '
        Me.TxtVehicle.AgMandatory = True
        Me.TxtVehicle.AgMasterHelp = False
        Me.TxtVehicle.AgNumberLeftPlaces = 0
        Me.TxtVehicle.AgNumberNegetiveAllow = False
        Me.TxtVehicle.AgNumberRightPlaces = 0
        Me.TxtVehicle.AgPickFromLastValue = False
        Me.TxtVehicle.AgRowFilter = ""
        Me.TxtVehicle.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicle.AgSelectedValue = Nothing
        Me.TxtVehicle.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicle.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicle.Location = New System.Drawing.Point(316, 94)
        Me.TxtVehicle.MaxLength = 20
        Me.TxtVehicle.Name = "TxtVehicle"
        Me.TxtVehicle.Size = New System.Drawing.Size(100, 18)
        Me.TxtVehicle.TabIndex = 1
        '
        'LblVehicle
        '
        Me.LblVehicle.AutoSize = True
        Me.LblVehicle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicle.Location = New System.Drawing.Point(195, 96)
        Me.LblVehicle.Name = "LblVehicle"
        Me.LblVehicle.Size = New System.Drawing.Size(47, 15)
        Me.LblVehicle.TabIndex = 35
        Me.LblVehicle.Text = "Vehicle"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = True
        Me.TxtSite_Code.AgMasterHelp = False
        Me.TxtSite_Code.AgNumberLeftPlaces = 0
        Me.TxtSite_Code.AgNumberNegetiveAllow = False
        Me.TxtSite_Code.AgNumberRightPlaces = 0
        Me.TxtSite_Code.AgPickFromLastValue = False
        Me.TxtSite_Code.AgRowFilter = ""
        Me.TxtSite_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSite_Code.AgSelectedValue = Nothing
        Me.TxtSite_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSite_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(316, 74)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(195, 77)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(107, 15)
        Me.LblSite_Code.TabIndex = 38
        Me.LblSite_Code.Text = "Site/Branch Name"
        Me.LblSite_Code.Visible = False
        '
        'LblRouteReq
        '
        Me.LblRouteReq.AutoSize = True
        Me.LblRouteReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblRouteReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblRouteReq.Location = New System.Drawing.Point(301, 119)
        Me.LblRouteReq.Name = "LblRouteReq"
        Me.LblRouteReq.Size = New System.Drawing.Size(10, 7)
        Me.LblRouteReq.TabIndex = 42
        Me.LblRouteReq.Text = "Ä"
        '
        'TxtRoute
        '
        Me.TxtRoute.AgMandatory = True
        Me.TxtRoute.AgMasterHelp = False
        Me.TxtRoute.AgNumberLeftPlaces = 0
        Me.TxtRoute.AgNumberNegetiveAllow = False
        Me.TxtRoute.AgNumberRightPlaces = 0
        Me.TxtRoute.AgPickFromLastValue = False
        Me.TxtRoute.AgRowFilter = ""
        Me.TxtRoute.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoute.AgSelectedValue = Nothing
        Me.TxtRoute.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoute.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoute.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRoute.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoute.Location = New System.Drawing.Point(316, 114)
        Me.TxtRoute.MaxLength = 0
        Me.TxtRoute.Name = "TxtRoute"
        Me.TxtRoute.Size = New System.Drawing.Size(300, 18)
        Me.TxtRoute.TabIndex = 2
        '
        'LblRoute
        '
        Me.LblRoute.AutoSize = True
        Me.LblRoute.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoute.Location = New System.Drawing.Point(195, 116)
        Me.LblRoute.Name = "LblRoute"
        Me.LblRoute.Size = New System.Drawing.Size(40, 15)
        Me.LblRoute.TabIndex = 40
        Me.LblRoute.Text = "Route"
        '
        'LblAllotmentDate
        '
        Me.LblAllotmentDate.AutoSize = True
        Me.LblAllotmentDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAllotmentDate.Location = New System.Drawing.Point(195, 136)
        Me.LblAllotmentDate.Name = "LblAllotmentDate"
        Me.LblAllotmentDate.Size = New System.Drawing.Size(87, 15)
        Me.LblAllotmentDate.TabIndex = 705
        Me.LblAllotmentDate.Text = "Allotment Date"
        '
        'TxtAllotmentDate
        '
        Me.TxtAllotmentDate.AgMandatory = True
        Me.TxtAllotmentDate.AgMasterHelp = False
        Me.TxtAllotmentDate.AgNumberLeftPlaces = 0
        Me.TxtAllotmentDate.AgNumberNegetiveAllow = False
        Me.TxtAllotmentDate.AgNumberRightPlaces = 0
        Me.TxtAllotmentDate.AgPickFromLastValue = False
        Me.TxtAllotmentDate.AgRowFilter = ""
        Me.TxtAllotmentDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAllotmentDate.AgSelectedValue = Nothing
        Me.TxtAllotmentDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAllotmentDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtAllotmentDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAllotmentDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllotmentDate.Location = New System.Drawing.Point(316, 134)
        Me.TxtAllotmentDate.MaxLength = 25
        Me.TxtAllotmentDate.Name = "TxtAllotmentDate"
        Me.TxtAllotmentDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtAllotmentDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(301, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 706
        Me.Label1.Text = "Ä"
        '
        'Dgl1
        '
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgl1.Location = New System.Drawing.Point(188, 198)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(459, 271)
        Me.Dgl1.TabIndex = 708
        '
        'LinkLblTitle
        '
        Me.LinkLblTitle.AutoSize = True
        Me.LinkLblTitle.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLblTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLblTitle.LinkColor = System.Drawing.Color.White
        Me.LinkLblTitle.Location = New System.Drawing.Point(188, 177)
        Me.LinkLblTitle.Name = "LinkLblTitle"
        Me.LinkLblTitle.Size = New System.Drawing.Size(138, 18)
        Me.LinkLblTitle.TabIndex = 935
        Me.LinkLblTitle.TabStop = True
        Me.LinkLblTitle.Text = "Route Allotement :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 506)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 937
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BackColor = System.Drawing.Color.White
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(7, 506)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 936
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BackColor = System.Drawing.Color.White
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 495)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 938
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'FrmVehicleRoute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 566)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LinkLblTitle)
        Me.Controls.Add(Me.Dgl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblAllotmentDate)
        Me.Controls.Add(Me.TxtAllotmentDate)
        Me.Controls.Add(Me.LblRouteReq)
        Me.Controls.Add(Me.TxtRoute)
        Me.Controls.Add(Me.LblRoute)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblVehicleReq)
        Me.Controls.Add(Me.TxtVehicle)
        Me.Controls.Add(Me.LblVehicle)
        Me.Controls.Add(Me.Topctrl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmVehicleRoute"
        Me.Text = "FrmVehicleRoute"
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblVehicleReq As System.Windows.Forms.Label
    Friend WithEvents TxtVehicle As AgControls.AgTextBox
    Friend WithEvents LblVehicle As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents LblRouteReq As System.Windows.Forms.Label
    Friend WithEvents TxtRoute As AgControls.AgTextBox
    Friend WithEvents LblRoute As System.Windows.Forms.Label
    Friend WithEvents LblAllotmentDate As System.Windows.Forms.Label
    Friend WithEvents TxtAllotmentDate As AgControls.AgTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dgl1 As AgControls.AgDataGrid
    Friend WithEvents LinkLblTitle As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
