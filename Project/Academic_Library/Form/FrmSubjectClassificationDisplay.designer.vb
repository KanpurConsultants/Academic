<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubjectClassificationDisplay
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.          [Ag]
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSubjectClassificationDisplay))
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtForSubject = New AgControls.AgTextBox
        Me.LblForSubject = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxtPath = New AgControls.AgTextBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuVIewThisOnly = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuBrowseBooks = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuBrowseBooksHirarichal = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(811, 585)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(54, 34)
        Me.BtnClose.TabIndex = 818
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(5, 577)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 4)
        Me.GroupBox1.TabIndex = 819
        Me.GroupBox1.TabStop = False
        '
        'TxtForSubject
        '
        Me.TxtForSubject.AgMandatory = False
        Me.TxtForSubject.AgMasterHelp = False
        Me.TxtForSubject.AgNumberLeftPlaces = 8
        Me.TxtForSubject.AgNumberNegetiveAllow = False
        Me.TxtForSubject.AgNumberRightPlaces = 2
        Me.TxtForSubject.AgPickFromLastValue = False
        Me.TxtForSubject.AgRowFilter = ""
        Me.TxtForSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForSubject.AgSelectedValue = Nothing
        Me.TxtForSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForSubject.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForSubject.Location = New System.Drawing.Point(156, 9)
        Me.TxtForSubject.MaxLength = 50
        Me.TxtForSubject.Name = "TxtForSubject"
        Me.TxtForSubject.Size = New System.Drawing.Size(312, 20)
        Me.TxtForSubject.TabIndex = 820
        '
        'LblForSubject
        '
        Me.LblForSubject.AutoSize = True
        Me.LblForSubject.BackColor = System.Drawing.Color.Transparent
        Me.LblForSubject.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForSubject.Location = New System.Drawing.Point(10, 9)
        Me.LblForSubject.Name = "LblForSubject"
        Me.LblForSubject.Size = New System.Drawing.Size(140, 18)
        Me.LblForSubject.TabIndex = 821
        Me.LblForSubject.Text = "Search Subject"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(2, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(869, 4)
        Me.GroupBox2.TabIndex = 822
        Me.GroupBox2.TabStop = False
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HideSelection = False
        Me.TreeView1.HotTracking = True
        Me.TreeView1.ImageKey = "Picture1.png"
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.TreeView1.Indent = 30
        Me.TreeView1.ItemHeight = 20
        Me.TreeView1.LineColor = System.Drawing.Color.DarkRed
        Me.TreeView1.Location = New System.Drawing.Point(10, 44)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(2)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.PathSeparator = " -> "
        Me.TreeView1.SelectedImageKey = "Picture1.png"
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(857, 526)
        Me.TreeView1.TabIndex = 823
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "One.png")
        Me.ImageList1.Images.SetKeyName(1, "Picture4.png")
        Me.ImageList1.Images.SetKeyName(2, "Picture5.png")
        Me.ImageList1.Images.SetKeyName(3, "Picture6.png")
        Me.ImageList1.Images.SetKeyName(4, "Picture7.png")
        Me.ImageList1.Images.SetKeyName(5, "Picture8.png")
        Me.ImageList1.Images.SetKeyName(6, "Picture9.png")
        Me.ImageList1.Images.SetKeyName(7, "Picture10.png")
        Me.ImageList1.Images.SetKeyName(8, "Picture11.png")
        Me.ImageList1.Images.SetKeyName(9, "Picture12.png")
        Me.ImageList1.Images.SetKeyName(10, "Picture1.png")
        '
        'TxtPath
        '
        Me.TxtPath.AgMandatory = False
        Me.TxtPath.AgMasterHelp = False
        Me.TxtPath.AgNumberLeftPlaces = 8
        Me.TxtPath.AgNumberNegetiveAllow = False
        Me.TxtPath.AgNumberRightPlaces = 2
        Me.TxtPath.AgPickFromLastValue = False
        Me.TxtPath.AgRowFilter = ""
        Me.TxtPath.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPath.AgSelectedValue = Nothing
        Me.TxtPath.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPath.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPath.BackColor = System.Drawing.Color.White
        Me.TxtPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPath.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPath.ForeColor = System.Drawing.Color.Black
        Me.TxtPath.Location = New System.Drawing.Point(12, 585)
        Me.TxtPath.MaxLength = 50
        Me.TxtPath.Multiline = True
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.ReadOnly = True
        Me.TxtPath.Size = New System.Drawing.Size(790, 34)
        Me.TxtPath.TabIndex = 824
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuVIewThisOnly, Me.MnuBrowseBooks, Me.MnuBrowseBooksHirarichal})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(213, 70)
        '
        'MnuVIewThisOnly
        '
        Me.MnuVIewThisOnly.Name = "MnuVIewThisOnly"
        Me.MnuVIewThisOnly.Size = New System.Drawing.Size(212, 22)
        Me.MnuVIewThisOnly.Text = "VIew This Only"
        '
        'MnuBrowseBooks
        '
        Me.MnuBrowseBooks.Name = "MnuBrowseBooks"
        Me.MnuBrowseBooks.Size = New System.Drawing.Size(212, 22)
        Me.MnuBrowseBooks.Text = "Browse Books"
        '
        'MnuBrowseBooksHirarichal
        '
        Me.MnuBrowseBooksHirarichal.Name = "MnuBrowseBooksHirarichal"
        Me.MnuBrowseBooksHirarichal.Size = New System.Drawing.Size(212, 22)
        Me.MnuBrowseBooksHirarichal.Text = "Browse Books (Hierarichal)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(598, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 14)
        Me.Label1.TabIndex = 827
        Me.Label1.Text = "Right Click On Subject For Filter Criteria"
        '
        'FrmSubjectClassificationDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 624)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPath)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtForSubject)
        Me.Controls.Add(Me.LblForSubject)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnClose)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSubjectClassificationDisplay"
        Me.Text = "Define Subject Classification"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected WithEvents TxtForSubject As AgControls.AgTextBox
    Protected WithEvents LblForSubject As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Protected WithEvents TxtPath As AgControls.AgTextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuVIewThisOnly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBrowseBooks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBrowseBooksHirarichal As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
