<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransportInfo
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
        Me.LinkLblTitle = New System.Windows.Forms.LinkLabel
        Me.TxtSeatNo = New AgControls.AgTextBox
        Me.LblSeatNo = New System.Windows.Forms.Label
        Me.TxtVehicle = New AgControls.AgTextBox
        Me.LblVehicle = New System.Windows.Forms.Label
        Me.TxtRoute = New AgControls.AgTextBox
        Me.LblRoute = New System.Windows.Forms.Label
        Me.TxtPickUpPoint = New AgControls.AgTextBox
        Me.LblPickUpPoint = New System.Windows.Forms.Label
        Me.TxtValidTillDate = New AgControls.AgTextBox
        Me.LblValidTillDate = New System.Windows.Forms.Label
        Me.TxtCardSrNo = New AgControls.AgTextBox
        Me.LblCardSrNo = New System.Windows.Forms.Label
        Me.TxtCardPrefix = New AgControls.AgTextBox
        Me.LblCardPrefix = New System.Windows.Forms.Label
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.LblMemberCardNo = New System.Windows.Forms.Label
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.SuspendLayout()
        '
        'LinkLblTitle
        '
        Me.LinkLblTitle.AutoSize = True
        Me.LinkLblTitle.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLblTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLblTitle.LinkColor = System.Drawing.Color.White
        Me.LinkLblTitle.Location = New System.Drawing.Point(23, 26)
        Me.LinkLblTitle.Name = "LinkLblTitle"
        Me.LinkLblTitle.Size = New System.Drawing.Size(166, 18)
        Me.LinkLblTitle.TabIndex = 11
        Me.LinkLblTitle.TabStop = True
        Me.LinkLblTitle.Text = "Transport Information:"
        '
        'TxtSeatNo
        '
        Me.TxtSeatNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtSeatNo.AgMandatory = False
        Me.TxtSeatNo.AgMasterHelp = False
        Me.TxtSeatNo.AgNumberLeftPlaces = 0
        Me.TxtSeatNo.AgNumberNegetiveAllow = False
        Me.TxtSeatNo.AgNumberRightPlaces = 0
        Me.TxtSeatNo.AgPickFromLastValue = False
        Me.TxtSeatNo.AgRowFilter = ""
        Me.TxtSeatNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSeatNo.AgSelectedValue = Nothing
        Me.TxtSeatNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSeatNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSeatNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSeatNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeatNo.Location = New System.Drawing.Point(346, 148)
        Me.TxtSeatNo.MaxLength = 0
        Me.TxtSeatNo.Name = "TxtSeatNo"
        Me.TxtSeatNo.Size = New System.Drawing.Size(92, 18)
        Me.TxtSeatNo.TabIndex = 7
        '
        'LblSeatNo
        '
        Me.LblSeatNo.AutoSize = True
        Me.LblSeatNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeatNo.Location = New System.Drawing.Point(259, 150)
        Me.LblSeatNo.Name = "LblSeatNo"
        Me.LblSeatNo.Size = New System.Drawing.Size(54, 15)
        Me.LblSeatNo.TabIndex = 1004
        Me.LblSeatNo.Text = "Seat No."
        '
        'TxtVehicle
        '
        Me.TxtVehicle.AgAllowUserToEnableMasterHelp = False
        Me.TxtVehicle.AgMandatory = False
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
        Me.TxtVehicle.Location = New System.Drawing.Point(146, 148)
        Me.TxtVehicle.MaxLength = 0
        Me.TxtVehicle.Name = "TxtVehicle"
        Me.TxtVehicle.Size = New System.Drawing.Size(100, 18)
        Me.TxtVehicle.TabIndex = 6
        '
        'LblVehicle
        '
        Me.LblVehicle.AutoSize = True
        Me.LblVehicle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicle.Location = New System.Drawing.Point(23, 150)
        Me.LblVehicle.Name = "LblVehicle"
        Me.LblVehicle.Size = New System.Drawing.Size(84, 15)
        Me.LblVehicle.TabIndex = 1003
        Me.LblVehicle.Text = "Vehicle Name"
        '
        'TxtRoute
        '
        Me.TxtRoute.AgAllowUserToEnableMasterHelp = False
        Me.TxtRoute.AgMandatory = False
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
        Me.TxtRoute.Location = New System.Drawing.Point(146, 128)
        Me.TxtRoute.MaxLength = 0
        Me.TxtRoute.Name = "TxtRoute"
        Me.TxtRoute.Size = New System.Drawing.Size(292, 18)
        Me.TxtRoute.TabIndex = 5
        '
        'LblRoute
        '
        Me.LblRoute.AutoSize = True
        Me.LblRoute.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoute.Location = New System.Drawing.Point(23, 130)
        Me.LblRoute.Name = "LblRoute"
        Me.LblRoute.Size = New System.Drawing.Size(40, 15)
        Me.LblRoute.TabIndex = 1002
        Me.LblRoute.Text = "Route"
        '
        'TxtPickUpPoint
        '
        Me.TxtPickUpPoint.AgAllowUserToEnableMasterHelp = False
        Me.TxtPickUpPoint.AgMandatory = False
        Me.TxtPickUpPoint.AgMasterHelp = False
        Me.TxtPickUpPoint.AgNumberLeftPlaces = 0
        Me.TxtPickUpPoint.AgNumberNegetiveAllow = False
        Me.TxtPickUpPoint.AgNumberRightPlaces = 0
        Me.TxtPickUpPoint.AgPickFromLastValue = False
        Me.TxtPickUpPoint.AgRowFilter = ""
        Me.TxtPickUpPoint.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPickUpPoint.AgSelectedValue = Nothing
        Me.TxtPickUpPoint.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPickUpPoint.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPickUpPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPickUpPoint.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPickUpPoint.Location = New System.Drawing.Point(146, 108)
        Me.TxtPickUpPoint.MaxLength = 0
        Me.TxtPickUpPoint.Name = "TxtPickUpPoint"
        Me.TxtPickUpPoint.Size = New System.Drawing.Size(292, 18)
        Me.TxtPickUpPoint.TabIndex = 4
        '
        'LblPickUpPoint
        '
        Me.LblPickUpPoint.AutoSize = True
        Me.LblPickUpPoint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPickUpPoint.Location = New System.Drawing.Point(23, 110)
        Me.LblPickUpPoint.Name = "LblPickUpPoint"
        Me.LblPickUpPoint.Size = New System.Drawing.Size(75, 15)
        Me.LblPickUpPoint.TabIndex = 1001
        Me.LblPickUpPoint.Text = "Pickup Point"
        '
        'TxtValidTillDate
        '
        Me.TxtValidTillDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtValidTillDate.AgMandatory = False
        Me.TxtValidTillDate.AgMasterHelp = False
        Me.TxtValidTillDate.AgNumberLeftPlaces = 0
        Me.TxtValidTillDate.AgNumberNegetiveAllow = False
        Me.TxtValidTillDate.AgNumberRightPlaces = 0
        Me.TxtValidTillDate.AgPickFromLastValue = False
        Me.TxtValidTillDate.AgRowFilter = ""
        Me.TxtValidTillDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtValidTillDate.AgSelectedValue = Nothing
        Me.TxtValidTillDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtValidTillDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtValidTillDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValidTillDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValidTillDate.Location = New System.Drawing.Point(346, 88)
        Me.TxtValidTillDate.MaxLength = 20
        Me.TxtValidTillDate.Name = "TxtValidTillDate"
        Me.TxtValidTillDate.Size = New System.Drawing.Size(92, 18)
        Me.TxtValidTillDate.TabIndex = 3
        Me.TxtValidTillDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblValidTillDate
        '
        Me.LblValidTillDate.AutoSize = True
        Me.LblValidTillDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValidTillDate.Location = New System.Drawing.Point(257, 90)
        Me.LblValidTillDate.Name = "LblValidTillDate"
        Me.LblValidTillDate.Size = New System.Drawing.Size(83, 15)
        Me.LblValidTillDate.TabIndex = 1000
        Me.LblValidTillDate.Text = "Card Valid Till"
        '
        'TxtCardSrNo
        '
        Me.TxtCardSrNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtCardSrNo.AgMandatory = False
        Me.TxtCardSrNo.AgMasterHelp = False
        Me.TxtCardSrNo.AgNumberLeftPlaces = 8
        Me.TxtCardSrNo.AgNumberNegetiveAllow = False
        Me.TxtCardSrNo.AgNumberRightPlaces = 0
        Me.TxtCardSrNo.AgPickFromLastValue = False
        Me.TxtCardSrNo.AgRowFilter = ""
        Me.TxtCardSrNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCardSrNo.AgSelectedValue = Nothing
        Me.TxtCardSrNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCardSrNo.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtCardSrNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCardSrNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCardSrNo.Location = New System.Drawing.Point(346, 68)
        Me.TxtCardSrNo.MaxLength = 20
        Me.TxtCardSrNo.Name = "TxtCardSrNo"
        Me.TxtCardSrNo.Size = New System.Drawing.Size(92, 18)
        Me.TxtCardSrNo.TabIndex = 1
        Me.TxtCardSrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblCardSrNo
        '
        Me.LblCardSrNo.AutoSize = True
        Me.LblCardSrNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardSrNo.Location = New System.Drawing.Point(257, 70)
        Me.LblCardSrNo.Name = "LblCardSrNo"
        Me.LblCardSrNo.Size = New System.Drawing.Size(74, 15)
        Me.LblCardSrNo.TabIndex = 999
        Me.LblCardSrNo.Text = "Card Sr. No."
        '
        'TxtCardPrefix
        '
        Me.TxtCardPrefix.AgAllowUserToEnableMasterHelp = False
        Me.TxtCardPrefix.AgMandatory = False
        Me.TxtCardPrefix.AgMasterHelp = False
        Me.TxtCardPrefix.AgNumberLeftPlaces = 0
        Me.TxtCardPrefix.AgNumberNegetiveAllow = False
        Me.TxtCardPrefix.AgNumberRightPlaces = 0
        Me.TxtCardPrefix.AgPickFromLastValue = False
        Me.TxtCardPrefix.AgRowFilter = ""
        Me.TxtCardPrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCardPrefix.AgSelectedValue = Nothing
        Me.TxtCardPrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCardPrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCardPrefix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCardPrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCardPrefix.Location = New System.Drawing.Point(146, 68)
        Me.TxtCardPrefix.MaxLength = 20
        Me.TxtCardPrefix.Name = "TxtCardPrefix"
        Me.TxtCardPrefix.Size = New System.Drawing.Size(100, 18)
        Me.TxtCardPrefix.TabIndex = 0
        '
        'LblCardPrefix
        '
        Me.LblCardPrefix.AutoSize = True
        Me.LblCardPrefix.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardPrefix.Location = New System.Drawing.Point(23, 70)
        Me.LblCardPrefix.Name = "LblCardPrefix"
        Me.LblCardPrefix.Size = New System.Drawing.Size(67, 15)
        Me.LblCardPrefix.TabIndex = 998
        Me.LblCardPrefix.Text = "Card Prefix"
        '
        'TxtMemberCardNo
        '
        Me.TxtMemberCardNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtMemberCardNo.AgMandatory = False
        Me.TxtMemberCardNo.AgMasterHelp = False
        Me.TxtMemberCardNo.AgNumberLeftPlaces = 0
        Me.TxtMemberCardNo.AgNumberNegetiveAllow = False
        Me.TxtMemberCardNo.AgNumberRightPlaces = 0
        Me.TxtMemberCardNo.AgPickFromLastValue = False
        Me.TxtMemberCardNo.AgRowFilter = ""
        Me.TxtMemberCardNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberCardNo.AgSelectedValue = Nothing
        Me.TxtMemberCardNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberCardNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberCardNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(146, 88)
        Me.TxtMemberCardNo.MaxLength = 50
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtMemberCardNo.TabIndex = 2
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.AutoSize = True
        Me.LblMemberCardNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberCardNo.Location = New System.Drawing.Point(23, 90)
        Me.LblMemberCardNo.Name = "LblMemberCardNo"
        Me.LblMemberCardNo.Size = New System.Drawing.Size(101, 15)
        Me.LblMemberCardNo.TabIndex = 997
        Me.LblMemberCardNo.Text = "Member Card No"
        '
        'BtnOk
        '
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(353, 203)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 8
        Me.BtnOk.Text = "OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(394, -7)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(100, 41)
        Me.Topctrl1.TabIndex = 10
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
        'FrmTransportInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 241)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.LinkLblTitle)
        Me.Controls.Add(Me.TxtSeatNo)
        Me.Controls.Add(Me.LblSeatNo)
        Me.Controls.Add(Me.TxtVehicle)
        Me.Controls.Add(Me.LblVehicle)
        Me.Controls.Add(Me.TxtRoute)
        Me.Controls.Add(Me.LblRoute)
        Me.Controls.Add(Me.TxtPickUpPoint)
        Me.Controls.Add(Me.LblPickUpPoint)
        Me.Controls.Add(Me.TxtValidTillDate)
        Me.Controls.Add(Me.LblValidTillDate)
        Me.Controls.Add(Me.TxtCardSrNo)
        Me.Controls.Add(Me.LblCardSrNo)
        Me.Controls.Add(Me.TxtCardPrefix)
        Me.Controls.Add(Me.LblCardPrefix)
        Me.Controls.Add(Me.TxtMemberCardNo)
        Me.Controls.Add(Me.LblMemberCardNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTransportInfo"
        Me.Text = "Transport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLblTitle As System.Windows.Forms.LinkLabel
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Public WithEvents TxtSeatNo As AgControls.AgTextBox
    Public WithEvents LblSeatNo As System.Windows.Forms.Label
    Public WithEvents TxtVehicle As AgControls.AgTextBox
    Public WithEvents LblVehicle As System.Windows.Forms.Label
    Public WithEvents TxtRoute As AgControls.AgTextBox
    Public WithEvents LblRoute As System.Windows.Forms.Label
    Public WithEvents TxtPickUpPoint As AgControls.AgTextBox
    Public WithEvents LblPickUpPoint As System.Windows.Forms.Label
    Public WithEvents TxtValidTillDate As AgControls.AgTextBox
    Public WithEvents LblValidTillDate As System.Windows.Forms.Label
    Public WithEvents TxtCardSrNo As AgControls.AgTextBox
    Public WithEvents LblCardSrNo As System.Windows.Forms.Label
    Public WithEvents TxtCardPrefix As AgControls.AgTextBox
    Public WithEvents LblCardPrefix As System.Windows.Forms.Label
    Public WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Public WithEvents LblMemberCardNo As System.Windows.Forms.Label
    Public WithEvents BtnOk As System.Windows.Forms.Button
End Class
