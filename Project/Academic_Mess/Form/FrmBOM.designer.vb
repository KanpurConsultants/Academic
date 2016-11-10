<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBOM
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtForItem = New AgControls.AgTextBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.TxtForUnit = New AgControls.AgTextBox
        Me.LblForUnit = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalQty = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.GBoxDivision = New System.Windows.Forms.GroupBox
        Me.TxtDivision = New AgControls.AgTextBox
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblForQty = New System.Windows.Forms.Label
        Me.TxtForQty = New AgControls.AgTextBox
        Me.LblForItemReq = New System.Windows.Forms.Label
        Me.LblForItem = New System.Windows.Forms.Label
        Me.LblForWeight = New System.Windows.Forms.Label
        Me.TxtForWeight = New AgControls.AgTextBox
        Me.LblForQtyReq = New System.Windows.Forms.Label
        Me.LblForWeightReq = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.PnlFooter.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(796, 505)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 294
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 505)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 293
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(994, 41)
        Me.Topctrl1.TabIndex = 5
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 491)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(998, 4)
        Me.GroupBox2.TabIndex = 295
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(148, 158)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(611, 299)
        Me.Pnl1.TabIndex = 4
        '
        'TxtForItem
        '
        Me.TxtForItem.AgMandatory = True
        Me.TxtForItem.AgMasterHelp = False
        Me.TxtForItem.AgNumberLeftPlaces = 0
        Me.TxtForItem.AgNumberNegetiveAllow = False
        Me.TxtForItem.AgNumberRightPlaces = 0
        Me.TxtForItem.AgPickFromLastValue = False
        Me.TxtForItem.AgRowFilter = ""
        Me.TxtForItem.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForItem.AgSelectedValue = Nothing
        Me.TxtForItem.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForItem.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForItem.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForItem.Location = New System.Drawing.Point(310, 88)
        Me.TxtForItem.MaxLength = 100
        Me.TxtForItem.Name = "TxtForItem"
        Me.TxtForItem.Size = New System.Drawing.Size(372, 18)
        Me.TxtForItem.TabIndex = 1
        Me.TxtForItem.Text = "TxtItem"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(297, 74)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 1
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(154, 70)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 402
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = False
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(310, 68)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(372, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'TxtForUnit
        '
        Me.TxtForUnit.AgMandatory = True
        Me.TxtForUnit.AgMasterHelp = False
        Me.TxtForUnit.AgNumberLeftPlaces = 0
        Me.TxtForUnit.AgNumberNegetiveAllow = False
        Me.TxtForUnit.AgNumberRightPlaces = 0
        Me.TxtForUnit.AgPickFromLastValue = False
        Me.TxtForUnit.AgRowFilter = ""
        Me.TxtForUnit.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForUnit.AgSelectedValue = Nothing
        Me.TxtForUnit.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForUnit.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForUnit.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForUnit.Location = New System.Drawing.Point(882, 89)
        Me.TxtForUnit.MaxLength = 45
        Me.TxtForUnit.Name = "TxtForUnit"
        Me.TxtForUnit.Size = New System.Drawing.Size(100, 18)
        Me.TxtForUnit.TabIndex = 6
        Me.TxtForUnit.Visible = False
        '
        'LblForUnit
        '
        Me.LblForUnit.AutoSize = True
        Me.LblForUnit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForUnit.Location = New System.Drawing.Point(831, 91)
        Me.LblForUnit.Name = "LblForUnit"
        Me.LblForUnit.Size = New System.Drawing.Size(50, 15)
        Me.LblForUnit.TabIndex = 404
        Me.LblForUnit.Text = "For Unit"
        Me.LblForUnit.Visible = False
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalQty)
        Me.PnlFooter.Location = New System.Drawing.Point(148, 457)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(611, 24)
        Me.PnlFooter.TabIndex = 696
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(506, 3)
        Me.LblValTotalQty.Name = "LblValTotalQty"
        Me.LblValTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQty.TabIndex = 668
        Me.LblValTotalQty.Text = "."
        Me.LblValTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalQty
        '
        Me.LblTextTotalQty.AutoSize = True
        Me.LblTextTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalQty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalQty.Location = New System.Drawing.Point(425, 3)
        Me.LblTextTotalQty.Name = "LblTextTotalQty"
        Me.LblTextTotalQty.Size = New System.Drawing.Size(77, 16)
        Me.LblTextTotalQty.TabIndex = 667
        Me.LblTextTotalQty.Text = "Total Qty. :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(145, 135)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(79, 20)
        Me.LinkLabel1.TabIndex = 740
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "BOM Detail:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxDivision.BackColor = System.Drawing.Color.Transparent
        Me.GBoxDivision.Controls.Add(Me.TxtDivision)
        Me.GBoxDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxDivision.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxDivision.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxDivision.Location = New System.Drawing.Point(204, 505)
        Me.GBoxDivision.Name = "GBoxDivision"
        Me.GBoxDivision.Size = New System.Drawing.Size(186, 51)
        Me.GBoxDivision.TabIndex = 741
        Me.GBoxDivision.TabStop = False
        Me.GBoxDivision.Tag = "TR"
        Me.GBoxDivision.Text = "Division"
        Me.GBoxDivision.Visible = False
        '
        'TxtDivision
        '
        Me.TxtDivision.AgMandatory = False
        Me.TxtDivision.AgMasterHelp = False
        Me.TxtDivision.AgNumberLeftPlaces = 0
        Me.TxtDivision.AgNumberNegetiveAllow = False
        Me.TxtDivision.AgNumberRightPlaces = 0
        Me.TxtDivision.AgPickFromLastValue = False
        Me.TxtDivision.AgRowFilter = ""
        Me.TxtDivision.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDivision.AgSelectedValue = Nothing
        Me.TxtDivision.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDivision.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDivision.BackColor = System.Drawing.Color.White
        Me.TxtDivision.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDivision.Enabled = False
        Me.TxtDivision.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDivision.Location = New System.Drawing.Point(13, 23)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.ReadOnly = True
        Me.TxtDivision.Size = New System.Drawing.Size(158, 18)
        Me.TxtDivision.TabIndex = 0
        Me.TxtDivision.TabStop = False
        Me.TxtDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtDescription
        '
        Me.TxtDescription.AgMandatory = True
        Me.TxtDescription.AgMasterHelp = True
        Me.TxtDescription.AgNumberLeftPlaces = 0
        Me.TxtDescription.AgNumberNegetiveAllow = False
        Me.TxtDescription.AgNumberRightPlaces = 0
        Me.TxtDescription.AgPickFromLastValue = False
        Me.TxtDescription.AgRowFilter = ""
        Me.TxtDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDescription.AgSelectedValue = Nothing
        Me.TxtDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(902, 68)
        Me.TxtDescription.MaxLength = 100
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(80, 18)
        Me.TxtDescription.TabIndex = 742
        Me.TxtDescription.Visible = False
        '
        'LblForQty
        '
        Me.LblForQty.AutoSize = True
        Me.LblForQty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForQty.Location = New System.Drawing.Point(154, 110)
        Me.LblForQty.Name = "LblForQty"
        Me.LblForQty.Size = New System.Drawing.Size(72, 15)
        Me.LblForQty.TabIndex = 744
        Me.LblForQty.Text = "For Quantity"
        '
        'TxtForQty
        '
        Me.TxtForQty.AgMandatory = False
        Me.TxtForQty.AgMasterHelp = False
        Me.TxtForQty.AgNumberLeftPlaces = 8
        Me.TxtForQty.AgNumberNegetiveAllow = False
        Me.TxtForQty.AgNumberRightPlaces = 3
        Me.TxtForQty.AgPickFromLastValue = False
        Me.TxtForQty.AgRowFilter = ""
        Me.TxtForQty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForQty.AgSelectedValue = Nothing
        Me.TxtForQty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForQty.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtForQty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForQty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForQty.Location = New System.Drawing.Point(310, 108)
        Me.TxtForQty.MaxLength = 0
        Me.TxtForQty.Name = "TxtForQty"
        Me.TxtForQty.Size = New System.Drawing.Size(100, 18)
        Me.TxtForQty.TabIndex = 2
        Me.TxtForQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblForItemReq
        '
        Me.LblForItemReq.AutoSize = True
        Me.LblForItemReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblForItemReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblForItemReq.Location = New System.Drawing.Point(297, 95)
        Me.LblForItemReq.Name = "LblForItemReq"
        Me.LblForItemReq.Size = New System.Drawing.Size(10, 7)
        Me.LblForItemReq.TabIndex = 745
        Me.LblForItemReq.Text = "Ä"
        '
        'LblForItem
        '
        Me.LblForItem.AutoSize = True
        Me.LblForItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForItem.Location = New System.Drawing.Point(154, 91)
        Me.LblForItem.Name = "LblForItem"
        Me.LblForItem.Size = New System.Drawing.Size(52, 15)
        Me.LblForItem.TabIndex = 746
        Me.LblForItem.Text = "For Item"
        '
        'LblForWeight
        '
        Me.LblForWeight.AutoSize = True
        Me.LblForWeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForWeight.Location = New System.Drawing.Point(479, 110)
        Me.LblForWeight.Name = "LblForWeight"
        Me.LblForWeight.Size = New System.Drawing.Size(66, 15)
        Me.LblForWeight.TabIndex = 748
        Me.LblForWeight.Text = "For Weight"
        '
        'TxtForWeight
        '
        Me.TxtForWeight.AgMandatory = False
        Me.TxtForWeight.AgMasterHelp = False
        Me.TxtForWeight.AgNumberLeftPlaces = 8
        Me.TxtForWeight.AgNumberNegetiveAllow = False
        Me.TxtForWeight.AgNumberRightPlaces = 3
        Me.TxtForWeight.AgPickFromLastValue = False
        Me.TxtForWeight.AgRowFilter = ""
        Me.TxtForWeight.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForWeight.AgSelectedValue = Nothing
        Me.TxtForWeight.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForWeight.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtForWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForWeight.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForWeight.Location = New System.Drawing.Point(582, 108)
        Me.TxtForWeight.MaxLength = 0
        Me.TxtForWeight.Name = "TxtForWeight"
        Me.TxtForWeight.Size = New System.Drawing.Size(100, 18)
        Me.TxtForWeight.TabIndex = 3
        Me.TxtForWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblForQtyReq
        '
        Me.LblForQtyReq.AutoSize = True
        Me.LblForQtyReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblForQtyReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblForQtyReq.Location = New System.Drawing.Point(297, 114)
        Me.LblForQtyReq.Name = "LblForQtyReq"
        Me.LblForQtyReq.Size = New System.Drawing.Size(10, 7)
        Me.LblForQtyReq.TabIndex = 749
        Me.LblForQtyReq.Text = "Ä"
        '
        'LblForWeightReq
        '
        Me.LblForWeightReq.AutoSize = True
        Me.LblForWeightReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblForWeightReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblForWeightReq.Location = New System.Drawing.Point(566, 114)
        Me.LblForWeightReq.Name = "LblForWeightReq"
        Me.LblForWeightReq.Size = New System.Drawing.Size(10, 7)
        Me.LblForWeightReq.TabIndex = 750
        Me.LblForWeightReq.Text = "Ä"
        '
        'FrmBOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 568)
        Me.Controls.Add(Me.LblForWeightReq)
        Me.Controls.Add(Me.LblForQtyReq)
        Me.Controls.Add(Me.LblForWeight)
        Me.Controls.Add(Me.TxtForWeight)
        Me.Controls.Add(Me.LblForItemReq)
        Me.Controls.Add(Me.LblForItem)
        Me.Controls.Add(Me.LblForQty)
        Me.Controls.Add(Me.TxtForQty)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.GBoxDivision)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.TxtForUnit)
        Me.Controls.Add(Me.LblForUnit)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtForItem)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Pnl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmBOM"
        Me.Text = "Item Master"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Protected WithEvents TxtModified As System.Windows.Forms.TextBox
    Protected WithEvents GrpUP As System.Windows.Forms.GroupBox
    Protected WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Protected WithEvents Topctrl1 As Topctrl.Topctrl
    Protected WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Protected WithEvents LblSite_Code As System.Windows.Forms.Label
    Protected WithEvents LblForUnit As System.Windows.Forms.Label
    Protected WithEvents TxtForItem As AgControls.AgTextBox
    Protected WithEvents TxtSite_Code As AgControls.AgTextBox
    Protected WithEvents TxtForUnit As AgControls.AgTextBox
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalQty As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Public WithEvents GBoxDivision As System.Windows.Forms.GroupBox
    Public WithEvents TxtDivision As AgControls.AgTextBox
    Protected WithEvents TxtDescription As AgControls.AgTextBox
    Protected WithEvents LblForQty As System.Windows.Forms.Label
    Protected WithEvents TxtForQty As AgControls.AgTextBox
    Protected WithEvents LblForItemReq As System.Windows.Forms.Label
    Protected WithEvents LblForItem As System.Windows.Forms.Label
    Protected WithEvents LblForWeight As System.Windows.Forms.Label
    Protected WithEvents TxtForWeight As AgControls.AgTextBox
    Protected WithEvents LblForQtyReq As System.Windows.Forms.Label
    Protected WithEvents LblForWeightReq As System.Windows.Forms.Label

End Class
