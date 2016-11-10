<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMain))
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TbcMain = New System.Windows.Forms.TabControl
        Me.Tbp1 = New System.Windows.Forms.TabPage
        Me.TspMenu = New System.Windows.Forms.ToolStrip
        Me.TsbComnMast = New System.Windows.Forms.ToolStripButton
        Me.TsbFA = New System.Windows.Forms.ToolStripButton
        Me.TsbUtility = New System.Windows.Forms.ToolStripButton
        Me.SSrpMain = New System.Windows.Forms.StatusStrip
        Me.TSSL_Company = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_CurrentYear = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_Site = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_User = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_Student = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_OnlineOffLine = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.TSSL_Btn_UpdateTableStructure = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSL_UpdateTableStructureWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.TSSL_Btn_ManageMDI = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSL_Btn_ManageUserControl = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSSL_Btn_ReconnectDatabase = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSL_ChangeMDIImage = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSL_SendSMS = New System.Windows.Forms.ToolStripMenuItem
        Me.TbcMain.SuspendLayout()
        Me.Tbp1.SuspendLayout()
        Me.TspMenu.SuspendLayout()
        Me.SSrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(169, 276)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TbcMain
        '
        Me.TbcMain.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TbcMain.Controls.Add(Me.Tbp1)
        Me.TbcMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.TbcMain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbcMain.ItemSize = New System.Drawing.Size(100, 20)
        Me.TbcMain.Location = New System.Drawing.Point(0, 0)
        Me.TbcMain.Multiline = True
        Me.TbcMain.Name = "TbcMain"
        Me.TbcMain.SelectedIndex = 0
        Me.TbcMain.Size = New System.Drawing.Size(161, 427)
        Me.TbcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TbcMain.TabIndex = 2
        Me.TbcMain.Visible = False
        '
        'Tbp1
        '
        Me.Tbp1.AutoScroll = True
        Me.Tbp1.BackgroundImage = CType(resources.GetObject("Tbp1.BackgroundImage"), System.Drawing.Image)
        Me.Tbp1.Controls.Add(Me.TspMenu)
        Me.Tbp1.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbp1.ForeColor = System.Drawing.Color.Black
        Me.Tbp1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Tbp1.Location = New System.Drawing.Point(24, 4)
        Me.Tbp1.Name = "Tbp1"
        Me.Tbp1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tbp1.Size = New System.Drawing.Size(133, 419)
        Me.Tbp1.TabIndex = 1
        Me.Tbp1.Text = "Menu"
        Me.Tbp1.UseVisualStyleBackColor = True
        '
        'TspMenu
        '
        Me.TspMenu.AllowMerge = False
        Me.TspMenu.AutoSize = False
        Me.TspMenu.BackColor = System.Drawing.Color.Transparent
        Me.TspMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TspMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.TspMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TspMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbComnMast, Me.TsbFA, Me.TsbUtility})
        Me.TspMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.TspMenu.Location = New System.Drawing.Point(3, 3)
        Me.TspMenu.Name = "TspMenu"
        Me.TspMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TspMenu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TspMenu.Size = New System.Drawing.Size(251, 394)
        Me.TspMenu.Stretch = True
        Me.TspMenu.TabIndex = 1
        Me.TspMenu.Visible = False
        '
        'TsbComnMast
        '
        Me.TsbComnMast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsbComnMast.Image = Global.Library_Login.My.Resources.Resources.Folder
        Me.TsbComnMast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TsbComnMast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbComnMast.Name = "TsbComnMast"
        Me.TsbComnMast.Size = New System.Drawing.Size(249, 20)
        Me.TsbComnMast.Text = "Common Master"
        Me.TsbComnMast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TsbComnMast.ToolTipText = "Common Master"
        '
        'TsbFA
        '
        Me.TsbFA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TsbFA.Image = CType(resources.GetObject("TsbFA.Image"), System.Drawing.Image)
        Me.TsbFA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TsbFA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbFA.Name = "TsbFA"
        Me.TsbFA.Size = New System.Drawing.Size(249, 20)
        Me.TsbFA.Text = "Financial Accounts"
        Me.TsbFA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TsbUtility
        '
        Me.TsbUtility.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TsbUtility.Image = CType(resources.GetObject("TsbUtility.Image"), System.Drawing.Image)
        Me.TsbUtility.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TsbUtility.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbUtility.Name = "TsbUtility"
        Me.TsbUtility.Size = New System.Drawing.Size(249, 20)
        Me.TsbUtility.Text = "Utility"
        '
        'SSrpMain
        '
        Me.SSrpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_Company, Me.TSSL_CurrentYear, Me.TSSL_Site, Me.TSSL_User, Me.TSSL_Student, Me.TSSL_OnlineOffLine, Me.ToolStripSplitButton1})
        Me.SSrpMain.Location = New System.Drawing.Point(0, 427)
        Me.SSrpMain.Name = "SSrpMain"
        Me.SSrpMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.SSrpMain.Size = New System.Drawing.Size(864, 22)
        Me.SSrpMain.TabIndex = 4
        Me.SSrpMain.Text = "StatusStrip1"
        '
        'TSSL_Company
        '
        Me.TSSL_Company.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.TSSL_Company.Name = "TSSL_Company"
        Me.TSSL_Company.Size = New System.Drawing.Size(86, 17)
        Me.TSSL_Company.Text = "Company Name"
        Me.TSSL_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSL_CurrentYear
        '
        Me.TSSL_CurrentYear.Name = "TSSL_CurrentYear"
        Me.TSSL_CurrentYear.Size = New System.Drawing.Size(40, 17)
        Me.TSSL_CurrentYear.Text = "C-Year"
        '
        'TSSL_Site
        '
        Me.TSSL_Site.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TSSL_Site.Name = "TSSL_Site"
        Me.TSSL_Site.Size = New System.Drawing.Size(59, 17)
        Me.TSSL_Site.Text = "Site Name"
        Me.TSSL_Site.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSL_User
        '
        Me.TSSL_User.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.TSSL_User.Name = "TSSL_User"
        Me.TSSL_User.Size = New System.Drawing.Size(63, 17)
        Me.TSSL_User.Text = "User Name"
        Me.TSSL_User.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSL_Student
        '
        Me.TSSL_Student.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.TSSL_Student.Name = "TSSL_Student"
        Me.TSSL_Student.Size = New System.Drawing.Size(85, 17)
        Me.TSSL_Student.Text = "Student Master"
        '
        'TSSL_OnlineOffLine
        '
        Me.TSSL_OnlineOffLine.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.TSSL_OnlineOffLine.Name = "TSSL_OnlineOffLine"
        Me.TSSL_OnlineOffLine.Size = New System.Drawing.Size(432, 17)
        Me.TSSL_OnlineOffLine.Spring = True
        Me.TSSL_OnlineOffLine.Text = "[Online]"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_Btn_UpdateTableStructure, Me.TSSL_UpdateTableStructureWebToolStripMenuItem, Me.ToolStripMenuItem1, Me.TSSL_Btn_ManageMDI, Me.TSSL_Btn_ManageUserControl, Me.ToolStripMenuItem2, Me.TSSL_Btn_ReconnectDatabase, Me.TSSL_ChangeMDIImage, Me.TSSL_SendSMS})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(84, 20)
        Me.ToolStripSplitButton1.Text = "Master Tools"
        '
        'TSSL_Btn_UpdateTableStructure
        '
        Me.TSSL_Btn_UpdateTableStructure.Name = "TSSL_Btn_UpdateTableStructure"
        Me.TSSL_Btn_UpdateTableStructure.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_Btn_UpdateTableStructure.Text = "Update Table Structure"
        '
        'TSSL_UpdateTableStructureWebToolStripMenuItem
        '
        Me.TSSL_UpdateTableStructureWebToolStripMenuItem.Name = "TSSL_UpdateTableStructureWebToolStripMenuItem"
        Me.TSSL_UpdateTableStructureWebToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_UpdateTableStructureWebToolStripMenuItem.Text = "Update Table Structure Web"
        Me.TSSL_UpdateTableStructureWebToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(219, 6)
        '
        'TSSL_Btn_ManageMDI
        '
        Me.TSSL_Btn_ManageMDI.Name = "TSSL_Btn_ManageMDI"
        Me.TSSL_Btn_ManageMDI.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_Btn_ManageMDI.Text = "Manage MDI"
        '
        'TSSL_Btn_ManageUserControl
        '
        Me.TSSL_Btn_ManageUserControl.Name = "TSSL_Btn_ManageUserControl"
        Me.TSSL_Btn_ManageUserControl.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_Btn_ManageUserControl.Text = "Manage User Control"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(219, 6)
        '
        'TSSL_Btn_ReconnectDatabase
        '
        Me.TSSL_Btn_ReconnectDatabase.Name = "TSSL_Btn_ReconnectDatabase"
        Me.TSSL_Btn_ReconnectDatabase.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_Btn_ReconnectDatabase.Text = "Reconnect Database"
        '
        'TSSL_ChangeMDIImage
        '
        Me.TSSL_ChangeMDIImage.Name = "TSSL_ChangeMDIImage"
        Me.TSSL_ChangeMDIImage.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_ChangeMDIImage.Text = "Change MDI Image"
        '
        'TSSL_SendSMS
        '
        Me.TSSL_SendSMS.Name = "TSSL_SendSMS"
        Me.TSSL_SendSMS.Size = New System.Drawing.Size(222, 22)
        Me.TSSL_SendSMS.Text = "Send SMS"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(864, 449)
        Me.Controls.Add(Me.TbcMain)
        Me.Controls.Add(Me.SSrpMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "MDIMain"
        Me.Text = "Academic.ERP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TbcMain.ResumeLayout(False)
        Me.Tbp1.ResumeLayout(False)
        Me.TspMenu.ResumeLayout(False)
        Me.TspMenu.PerformLayout()
        Me.SSrpMain.ResumeLayout(False)
        Me.SSrpMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Tbp1 As System.Windows.Forms.TabPage
    Friend WithEvents TbcMain As System.Windows.Forms.TabControl
    Friend WithEvents SSrpMain As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSL_Company As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_User As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents TSSL_Btn_ManageMDI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSL_Btn_ManageUserControl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TspMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents TsbFA As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbUtility As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSSL_Btn_UpdateTableStructure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSL_UpdateTableStructureWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsbComnMast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSSL_Site As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSSL_Btn_ReconnectDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSL_OnlineOffLine As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_CurrentYear As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_Student As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_ChangeMDIImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSL_SendSMS As System.Windows.Forms.ToolStripMenuItem

End Class
