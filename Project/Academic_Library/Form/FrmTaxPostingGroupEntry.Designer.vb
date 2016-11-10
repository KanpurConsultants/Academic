<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTaxPostingGroupEntry
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
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.BtnOk = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.Tc1 = New System.Windows.Forms.TabControl
        Me.Tp1 = New System.Windows.Forms.TabPage
        Me.BtnFillSaleTaxGroup = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl3 = New System.Windows.Forms.Panel
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Tp2 = New System.Windows.Forms.TabPage
        Me.BtnFillExciseTaxGroup = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Pnl6 = New System.Windows.Forms.Panel
        Me.Pnl5 = New System.Windows.Forms.Panel
        Me.Pnl4 = New System.Windows.Forms.Panel
        Me.Tp3 = New System.Windows.Forms.TabPage
        Me.TxtHECess = New AgControls.AgTextBox
        Me.LblHECess = New System.Windows.Forms.Label
        Me.TxtECess = New AgControls.AgTextBox
        Me.LblECess = New System.Windows.Forms.Label
        Me.TxtServiceTax = New AgControls.AgTextBox
        Me.LblServiceTax = New System.Windows.Forms.Label
        Me.TxtHECessAc = New AgControls.AgTextBox
        Me.LblHECessAc = New System.Windows.Forms.Label
        Me.TxtECessAc = New AgControls.AgTextBox
        Me.LblECessAc = New System.Windows.Forms.Label
        Me.TxtServiceTaxAc = New AgControls.AgTextBox
        Me.LblServiceTaxAc = New System.Windows.Forms.Label
        Me.Tp4 = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnEntryTaxGroup = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Pnl9 = New System.Windows.Forms.Panel
        Me.Pnl8 = New System.Windows.Forms.Panel
        Me.Pnl7 = New System.Windows.Forms.Panel
        Me.Tc1.SuspendLayout()
        Me.Tp1.SuspendLayout()
        Me.Tp2.SuspendLayout()
        Me.Tp3.SuspendLayout()
        Me.Tp4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(6, 24)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(474, 147)
        Me.Pnl1.TabIndex = 10
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(283, 183)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(16, 41)
        Me.Topctrl1.TabIndex = 712
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
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.Color.Transparent
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(785, 422)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(100, 21)
        Me.BtnOk.TabIndex = 11
        Me.BtnOk.Text = "Save"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(890, 422)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(100, 21)
        Me.BtnClose.TabIndex = 714
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Tc1
        '
        Me.Tc1.Controls.Add(Me.Tp1)
        Me.Tc1.Controls.Add(Me.Tp2)
        Me.Tc1.Controls.Add(Me.Tp3)
        Me.Tc1.Controls.Add(Me.Tp4)
        Me.Tc1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tc1.Location = New System.Drawing.Point(3, 4)
        Me.Tc1.Name = "Tc1"
        Me.Tc1.SelectedIndex = 0
        Me.Tc1.Size = New System.Drawing.Size(982, 418)
        Me.Tc1.TabIndex = 715
        '
        'Tp1
        '
        Me.Tp1.Controls.Add(Me.BtnFillSaleTaxGroup)
        Me.Tp1.Controls.Add(Me.Label3)
        Me.Tp1.Controls.Add(Me.Topctrl1)
        Me.Tp1.Controls.Add(Me.Label2)
        Me.Tp1.Controls.Add(Me.Label1)
        Me.Tp1.Controls.Add(Me.Pnl3)
        Me.Tp1.Controls.Add(Me.Pnl2)
        Me.Tp1.Controls.Add(Me.Pnl1)
        Me.Tp1.Location = New System.Drawing.Point(4, 22)
        Me.Tp1.Name = "Tp1"
        Me.Tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp1.Size = New System.Drawing.Size(974, 392)
        Me.Tp1.TabIndex = 0
        Me.Tp1.Text = "Sales Tax Posting Group"
        Me.Tp1.UseVisualStyleBackColor = True
        '
        'BtnFillSaleTaxGroup
        '
        Me.BtnFillSaleTaxGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillSaleTaxGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillSaleTaxGroup.Location = New System.Drawing.Point(845, 183)
        Me.BtnFillSaleTaxGroup.Name = "BtnFillSaleTaxGroup"
        Me.BtnFillSaleTaxGroup.Size = New System.Drawing.Size(123, 21)
        Me.BtnFillSaleTaxGroup.TabIndex = 22
        Me.BtnFillSaleTaxGroup.Text = "Fill"
        Me.BtnFillSaleTaxGroup.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sales Tax Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(483, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Party Sales Tax Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Sales Tax Group"
        '
        'Pnl3
        '
        Me.Pnl3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl3.Location = New System.Drawing.Point(6, 205)
        Me.Pnl3.Name = "Pnl3"
        Me.Pnl3.Size = New System.Drawing.Size(962, 183)
        Me.Pnl3.TabIndex = 12
        '
        'Pnl2
        '
        Me.Pnl2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl2.Location = New System.Drawing.Point(486, 24)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(482, 147)
        Me.Pnl2.TabIndex = 11
        '
        'Tp2
        '
        Me.Tp2.Controls.Add(Me.BtnFillExciseTaxGroup)
        Me.Tp2.Controls.Add(Me.Label7)
        Me.Tp2.Controls.Add(Me.Label8)
        Me.Tp2.Controls.Add(Me.Label9)
        Me.Tp2.Controls.Add(Me.Pnl6)
        Me.Tp2.Controls.Add(Me.Pnl5)
        Me.Tp2.Controls.Add(Me.Pnl4)
        Me.Tp2.Location = New System.Drawing.Point(4, 22)
        Me.Tp2.Name = "Tp2"
        Me.Tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp2.Size = New System.Drawing.Size(974, 392)
        Me.Tp2.TabIndex = 2
        Me.Tp2.Text = "Excise Posting Group"
        Me.Tp2.UseVisualStyleBackColor = True
        '
        'BtnFillExciseTaxGroup
        '
        Me.BtnFillExciseTaxGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillExciseTaxGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillExciseTaxGroup.Location = New System.Drawing.Point(853, 158)
        Me.BtnFillExciseTaxGroup.Name = "BtnFillExciseTaxGroup"
        Me.BtnFillExciseTaxGroup.Size = New System.Drawing.Size(115, 21)
        Me.BtnFillExciseTaxGroup.TabIndex = 23
        Me.BtnFillExciseTaxGroup.Text = "Fill"
        Me.BtnFillExciseTaxGroup.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Excise Group"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(486, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Party Excise Group"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Item Excise Group"
        '
        'Pnl6
        '
        Me.Pnl6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl6.Location = New System.Drawing.Point(7, 181)
        Me.Pnl6.Name = "Pnl6"
        Me.Pnl6.Size = New System.Drawing.Size(961, 205)
        Me.Pnl6.TabIndex = 18
        '
        'Pnl5
        '
        Me.Pnl5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl5.Location = New System.Drawing.Point(489, 23)
        Me.Pnl5.Name = "Pnl5"
        Me.Pnl5.Size = New System.Drawing.Size(479, 127)
        Me.Pnl5.TabIndex = 17
        '
        'Pnl4
        '
        Me.Pnl4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl4.Location = New System.Drawing.Point(7, 23)
        Me.Pnl4.Name = "Pnl4"
        Me.Pnl4.Size = New System.Drawing.Size(477, 127)
        Me.Pnl4.TabIndex = 16
        '
        'Tp3
        '
        Me.Tp3.Controls.Add(Me.TxtHECess)
        Me.Tp3.Controls.Add(Me.LblHECess)
        Me.Tp3.Controls.Add(Me.TxtECess)
        Me.Tp3.Controls.Add(Me.LblECess)
        Me.Tp3.Controls.Add(Me.TxtServiceTax)
        Me.Tp3.Controls.Add(Me.LblServiceTax)
        Me.Tp3.Controls.Add(Me.TxtHECessAc)
        Me.Tp3.Controls.Add(Me.LblHECessAc)
        Me.Tp3.Controls.Add(Me.TxtECessAc)
        Me.Tp3.Controls.Add(Me.LblECessAc)
        Me.Tp3.Controls.Add(Me.TxtServiceTaxAc)
        Me.Tp3.Controls.Add(Me.LblServiceTaxAc)
        Me.Tp3.Location = New System.Drawing.Point(4, 22)
        Me.Tp3.Name = "Tp3"
        Me.Tp3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp3.Size = New System.Drawing.Size(974, 392)
        Me.Tp3.TabIndex = 3
        Me.Tp3.Text = "Service Tax Posting Group"
        Me.Tp3.UseVisualStyleBackColor = True
        '
        'TxtHECess
        '
        Me.TxtHECess.AgMandatory = False
        Me.TxtHECess.AgMasterHelp = False
        Me.TxtHECess.AgNumberLeftPlaces = 0
        Me.TxtHECess.AgNumberNegetiveAllow = False
        Me.TxtHECess.AgNumberRightPlaces = 2
        Me.TxtHECess.AgPickFromLastValue = False
        Me.TxtHECess.AgRowFilter = ""
        Me.TxtHECess.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtHECess.AgSelectedValue = Nothing
        Me.TxtHECess.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtHECess.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtHECess.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHECess.Location = New System.Drawing.Point(248, 110)
        Me.TxtHECess.MaxLength = 35
        Me.TxtHECess.Name = "TxtHECess"
        Me.TxtHECess.Size = New System.Drawing.Size(81, 25)
        Me.TxtHECess.TabIndex = 4
        '
        'LblHECess
        '
        Me.LblHECess.AutoSize = True
        Me.LblHECess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHECess.Location = New System.Drawing.Point(165, 114)
        Me.LblHECess.Name = "LblHECess"
        Me.LblHECess.Size = New System.Drawing.Size(56, 16)
        Me.LblHECess.TabIndex = 888
        Me.LblHECess.Text = "HECess"
        '
        'TxtECess
        '
        Me.TxtECess.AgMandatory = False
        Me.TxtECess.AgMasterHelp = False
        Me.TxtECess.AgNumberLeftPlaces = 0
        Me.TxtECess.AgNumberNegetiveAllow = False
        Me.TxtECess.AgNumberRightPlaces = 2
        Me.TxtECess.AgPickFromLastValue = False
        Me.TxtECess.AgRowFilter = ""
        Me.TxtECess.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtECess.AgSelectedValue = Nothing
        Me.TxtECess.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtECess.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtECess.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtECess.Location = New System.Drawing.Point(248, 84)
        Me.TxtECess.MaxLength = 35
        Me.TxtECess.Name = "TxtECess"
        Me.TxtECess.Size = New System.Drawing.Size(81, 25)
        Me.TxtECess.TabIndex = 2
        '
        'LblECess
        '
        Me.LblECess.AutoSize = True
        Me.LblECess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblECess.Location = New System.Drawing.Point(165, 88)
        Me.LblECess.Name = "LblECess"
        Me.LblECess.Size = New System.Drawing.Size(47, 16)
        Me.LblECess.TabIndex = 886
        Me.LblECess.Text = "ECess"
        '
        'TxtServiceTax
        '
        Me.TxtServiceTax.AgMandatory = False
        Me.TxtServiceTax.AgMasterHelp = False
        Me.TxtServiceTax.AgNumberLeftPlaces = 0
        Me.TxtServiceTax.AgNumberNegetiveAllow = False
        Me.TxtServiceTax.AgNumberRightPlaces = 2
        Me.TxtServiceTax.AgPickFromLastValue = False
        Me.TxtServiceTax.AgRowFilter = ""
        Me.TxtServiceTax.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtServiceTax.AgSelectedValue = Nothing
        Me.TxtServiceTax.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtServiceTax.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtServiceTax.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServiceTax.Location = New System.Drawing.Point(248, 58)
        Me.TxtServiceTax.MaxLength = 35
        Me.TxtServiceTax.Name = "TxtServiceTax"
        Me.TxtServiceTax.Size = New System.Drawing.Size(81, 25)
        Me.TxtServiceTax.TabIndex = 0
        '
        'LblServiceTax
        '
        Me.LblServiceTax.AutoSize = True
        Me.LblServiceTax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblServiceTax.Location = New System.Drawing.Point(165, 59)
        Me.LblServiceTax.Name = "LblServiceTax"
        Me.LblServiceTax.Size = New System.Drawing.Size(75, 16)
        Me.LblServiceTax.TabIndex = 884
        Me.LblServiceTax.Text = "Service Tax"
        '
        'TxtHECessAc
        '
        Me.TxtHECessAc.AgMandatory = True
        Me.TxtHECessAc.AgMasterHelp = False
        Me.TxtHECessAc.AgNumberLeftPlaces = 0
        Me.TxtHECessAc.AgNumberNegetiveAllow = False
        Me.TxtHECessAc.AgNumberRightPlaces = 0
        Me.TxtHECessAc.AgPickFromLastValue = False
        Me.TxtHECessAc.AgRowFilter = ""
        Me.TxtHECessAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtHECessAc.AgSelectedValue = Nothing
        Me.TxtHECessAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtHECessAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtHECessAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHECessAc.Location = New System.Drawing.Point(465, 110)
        Me.TxtHECessAc.MaxLength = 100
        Me.TxtHECessAc.Name = "TxtHECessAc"
        Me.TxtHECessAc.Size = New System.Drawing.Size(292, 25)
        Me.TxtHECessAc.TabIndex = 5
        '
        'LblHECessAc
        '
        Me.LblHECessAc.AutoSize = True
        Me.LblHECessAc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHECessAc.Location = New System.Drawing.Point(347, 114)
        Me.LblHECessAc.Name = "LblHECessAc"
        Me.LblHECessAc.Size = New System.Drawing.Size(80, 16)
        Me.LblHECessAc.TabIndex = 882
        Me.LblHECessAc.Text = "HECess A/c"
        '
        'TxtECessAc
        '
        Me.TxtECessAc.AgMandatory = True
        Me.TxtECessAc.AgMasterHelp = False
        Me.TxtECessAc.AgNumberLeftPlaces = 0
        Me.TxtECessAc.AgNumberNegetiveAllow = False
        Me.TxtECessAc.AgNumberRightPlaces = 0
        Me.TxtECessAc.AgPickFromLastValue = False
        Me.TxtECessAc.AgRowFilter = ""
        Me.TxtECessAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtECessAc.AgSelectedValue = Nothing
        Me.TxtECessAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtECessAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtECessAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtECessAc.Location = New System.Drawing.Point(465, 84)
        Me.TxtECessAc.MaxLength = 100
        Me.TxtECessAc.Name = "TxtECessAc"
        Me.TxtECessAc.Size = New System.Drawing.Size(292, 25)
        Me.TxtECessAc.TabIndex = 3
        '
        'LblECessAc
        '
        Me.LblECessAc.AutoSize = True
        Me.LblECessAc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblECessAc.Location = New System.Drawing.Point(347, 88)
        Me.LblECessAc.Name = "LblECessAc"
        Me.LblECessAc.Size = New System.Drawing.Size(71, 16)
        Me.LblECessAc.TabIndex = 880
        Me.LblECessAc.Text = "ECess A/c"
        '
        'TxtServiceTaxAc
        '
        Me.TxtServiceTaxAc.AgMandatory = True
        Me.TxtServiceTaxAc.AgMasterHelp = False
        Me.TxtServiceTaxAc.AgNumberLeftPlaces = 0
        Me.TxtServiceTaxAc.AgNumberNegetiveAllow = False
        Me.TxtServiceTaxAc.AgNumberRightPlaces = 0
        Me.TxtServiceTaxAc.AgPickFromLastValue = False
        Me.TxtServiceTaxAc.AgRowFilter = ""
        Me.TxtServiceTaxAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtServiceTaxAc.AgSelectedValue = Nothing
        Me.TxtServiceTaxAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtServiceTaxAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtServiceTaxAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServiceTaxAc.Location = New System.Drawing.Point(465, 58)
        Me.TxtServiceTaxAc.MaxLength = 100
        Me.TxtServiceTaxAc.Name = "TxtServiceTaxAc"
        Me.TxtServiceTaxAc.Size = New System.Drawing.Size(292, 25)
        Me.TxtServiceTaxAc.TabIndex = 1
        '
        'LblServiceTaxAc
        '
        Me.LblServiceTaxAc.AutoSize = True
        Me.LblServiceTaxAc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblServiceTaxAc.Location = New System.Drawing.Point(347, 59)
        Me.LblServiceTaxAc.Name = "LblServiceTaxAc"
        Me.LblServiceTaxAc.Size = New System.Drawing.Size(99, 16)
        Me.LblServiceTaxAc.TabIndex = 878
        Me.LblServiceTaxAc.Text = "Service Tax A/c"
        '
        'Tp4
        '
        Me.Tp4.Controls.Add(Me.Label5)
        Me.Tp4.Controls.Add(Me.Label6)
        Me.Tp4.Controls.Add(Me.BtnEntryTaxGroup)
        Me.Tp4.Controls.Add(Me.Label4)
        Me.Tp4.Controls.Add(Me.Pnl9)
        Me.Tp4.Controls.Add(Me.Pnl8)
        Me.Tp4.Controls.Add(Me.Pnl7)
        Me.Tp4.Location = New System.Drawing.Point(4, 22)
        Me.Tp4.Name = "Tp4"
        Me.Tp4.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp4.Size = New System.Drawing.Size(974, 392)
        Me.Tp4.TabIndex = 4
        Me.Tp4.Text = "Entry Tax Posting Group"
        Me.Tp4.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Entry Tax Group"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Item Entry Tax Group"
        '
        'BtnEntryTaxGroup
        '
        Me.BtnEntryTaxGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEntryTaxGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEntryTaxGroup.Location = New System.Drawing.Point(845, 181)
        Me.BtnEntryTaxGroup.Name = "BtnEntryTaxGroup"
        Me.BtnEntryTaxGroup.Size = New System.Drawing.Size(123, 21)
        Me.BtnEntryTaxGroup.TabIndex = 717
        Me.BtnEntryTaxGroup.Text = "Fill"
        Me.BtnEntryTaxGroup.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(483, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 13)
        Me.Label4.TabIndex = 716
        Me.Label4.Text = "Party Entry Tax Group"
        '
        'Pnl9
        '
        Me.Pnl9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl9.Location = New System.Drawing.Point(6, 203)
        Me.Pnl9.Name = "Pnl9"
        Me.Pnl9.Size = New System.Drawing.Size(962, 183)
        Me.Pnl9.TabIndex = 715
        '
        'Pnl8
        '
        Me.Pnl8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl8.Location = New System.Drawing.Point(486, 22)
        Me.Pnl8.Name = "Pnl8"
        Me.Pnl8.Size = New System.Drawing.Size(482, 147)
        Me.Pnl8.TabIndex = 714
        '
        'Pnl7
        '
        Me.Pnl7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl7.Location = New System.Drawing.Point(6, 22)
        Me.Pnl7.Name = "Pnl7"
        Me.Pnl7.Size = New System.Drawing.Size(474, 147)
        Me.Pnl7.TabIndex = 713
        '
        'FrmTaxPostingGroupEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 444)
        Me.Controls.Add(Me.Tc1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnOk)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(300, 300)
        Me.MaximizeBox = False
        Me.Name = "FrmTaxPostingGroupEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax Posting Group"
        Me.Tc1.ResumeLayout(False)
        Me.Tp1.ResumeLayout(False)
        Me.Tp1.PerformLayout()
        Me.Tp2.ResumeLayout(False)
        Me.Tp2.PerformLayout()
        Me.Tp3.ResumeLayout(False)
        Me.Tp3.PerformLayout()
        Me.Tp4.ResumeLayout(False)
        Me.Tp4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Tc1 As System.Windows.Forms.TabControl
    Friend WithEvents Tp1 As System.Windows.Forms.TabPage
    Friend WithEvents Pnl3 As System.Windows.Forms.Panel
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tp2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pnl6 As System.Windows.Forms.Panel
    Friend WithEvents Pnl5 As System.Windows.Forms.Panel
    Friend WithEvents Pnl4 As System.Windows.Forms.Panel
    Friend WithEvents Tp3 As System.Windows.Forms.TabPage
    Protected WithEvents TxtHECess As AgControls.AgTextBox
    Protected WithEvents LblHECess As System.Windows.Forms.Label
    Protected WithEvents TxtECess As AgControls.AgTextBox
    Protected WithEvents LblECess As System.Windows.Forms.Label
    Protected WithEvents TxtServiceTax As AgControls.AgTextBox
    Protected WithEvents LblServiceTax As System.Windows.Forms.Label
    Protected WithEvents TxtHECessAc As AgControls.AgTextBox
    Protected WithEvents LblHECessAc As System.Windows.Forms.Label
    Protected WithEvents TxtECessAc As AgControls.AgTextBox
    Protected WithEvents LblECessAc As System.Windows.Forms.Label
    Protected WithEvents TxtServiceTaxAc As AgControls.AgTextBox
    Protected WithEvents LblServiceTaxAc As System.Windows.Forms.Label
    Friend WithEvents BtnFillSaleTaxGroup As System.Windows.Forms.Button
    Friend WithEvents BtnFillExciseTaxGroup As System.Windows.Forms.Button
    Friend WithEvents Tp4 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnEntryTaxGroup As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Pnl9 As System.Windows.Forms.Panel
    Friend WithEvents Pnl8 As System.Windows.Forms.Panel
    Friend WithEvents Pnl7 As System.Windows.Forms.Panel
End Class
