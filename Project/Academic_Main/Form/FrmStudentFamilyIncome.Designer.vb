<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentFamilyIncome
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
        Me.TxtStudent = New AgControls.AgTextBox
        Me.LblStudent = New System.Windows.Forms.Label
        Me.LblStudentReq = New System.Windows.Forms.Label
        Me.LblAsOnDateReq = New System.Windows.Forms.Label
        Me.LblAsOnDate = New System.Windows.Forms.Label
        Me.TxtAsOnDate = New AgControls.AgTextBox
        Me.TxtMotherOccupation = New AgControls.AgTextBox
        Me.LblMotherOccupation = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.TxtMotherIncome = New AgControls.AgTextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.TxtFatherIncome = New AgControls.AgTextBox
        Me.TxtFatherDesignation = New AgControls.AgTextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.TxtMotherDesignation = New AgControls.AgTextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.TxtMotherCompanyAddress = New AgControls.AgTextBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.TxtMotherCompany = New AgControls.AgTextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.TxtFatherCompanyAddress = New AgControls.AgTextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.TxtFatherCompany = New AgControls.AgTextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.TxtFatherOccupation = New AgControls.AgTextBox
        Me.TxtFamilyIncome = New AgControls.AgTextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtCategory = New AgControls.AgTextBox
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtMotherName = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(864, 41)
        Me.Topctrl1.TabIndex = 17
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
        'TxtStudent
        '
        Me.TxtStudent.AgMandatory = False
        Me.TxtStudent.AgMasterHelp = False
        Me.TxtStudent.AgNumberLeftPlaces = 0
        Me.TxtStudent.AgNumberNegetiveAllow = False
        Me.TxtStudent.AgNumberRightPlaces = 0
        Me.TxtStudent.AgPickFromLastValue = False
        Me.TxtStudent.AgRowFilter = ""
        Me.TxtStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStudent.AgSelectedValue = Nothing
        Me.TxtStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStudent.Location = New System.Drawing.Point(333, 112)
        Me.TxtStudent.MaxLength = 123
        Me.TxtStudent.Name = "TxtStudent"
        Me.TxtStudent.Size = New System.Drawing.Size(325, 21)
        Me.TxtStudent.TabIndex = 1
        '
        'LblStudent
        '
        Me.LblStudent.AutoSize = True
        Me.LblStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudent.Location = New System.Drawing.Point(198, 116)
        Me.LblStudent.Name = "LblStudent"
        Me.LblStudent.Size = New System.Drawing.Size(51, 13)
        Me.LblStudent.TabIndex = 507
        Me.LblStudent.Text = "Student"
        '
        'LblStudentReq
        '
        Me.LblStudentReq.AutoSize = True
        Me.LblStudentReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStudentReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStudentReq.Location = New System.Drawing.Point(317, 119)
        Me.LblStudentReq.Name = "LblStudentReq"
        Me.LblStudentReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStudentReq.TabIndex = 510
        Me.LblStudentReq.Text = "Ä"
        '
        'LblAsOnDateReq
        '
        Me.LblAsOnDateReq.AutoSize = True
        Me.LblAsOnDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAsOnDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAsOnDateReq.Location = New System.Drawing.Point(317, 141)
        Me.LblAsOnDateReq.Name = "LblAsOnDateReq"
        Me.LblAsOnDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAsOnDateReq.TabIndex = 519
        Me.LblAsOnDateReq.Text = "Ä"
        '
        'LblAsOnDate
        '
        Me.LblAsOnDate.AutoSize = True
        Me.LblAsOnDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAsOnDate.Location = New System.Drawing.Point(198, 138)
        Me.LblAsOnDate.Name = "LblAsOnDate"
        Me.LblAsOnDate.Size = New System.Drawing.Size(72, 13)
        Me.LblAsOnDate.TabIndex = 518
        Me.LblAsOnDate.Text = "As On Date"
        '
        'TxtAsOnDate
        '
        Me.TxtAsOnDate.AgMandatory = True
        Me.TxtAsOnDate.AgMasterHelp = False
        Me.TxtAsOnDate.AgNumberLeftPlaces = 0
        Me.TxtAsOnDate.AgNumberNegetiveAllow = False
        Me.TxtAsOnDate.AgNumberRightPlaces = 0
        Me.TxtAsOnDate.AgPickFromLastValue = False
        Me.TxtAsOnDate.AgRowFilter = ""
        Me.TxtAsOnDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAsOnDate.AgSelectedValue = Nothing
        Me.TxtAsOnDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAsOnDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtAsOnDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAsOnDate.Location = New System.Drawing.Point(333, 134)
        Me.TxtAsOnDate.MaxLength = 11
        Me.TxtAsOnDate.Name = "TxtAsOnDate"
        Me.TxtAsOnDate.Size = New System.Drawing.Size(100, 21)
        Me.TxtAsOnDate.TabIndex = 2
        Me.TxtAsOnDate.Text = "AgTextBox1"
        '
        'TxtMotherOccupation
        '
        Me.TxtMotherOccupation.AgMandatory = False
        Me.TxtMotherOccupation.AgMasterHelp = False
        Me.TxtMotherOccupation.AgNumberLeftPlaces = 0
        Me.TxtMotherOccupation.AgNumberNegetiveAllow = False
        Me.TxtMotherOccupation.AgNumberRightPlaces = 0
        Me.TxtMotherOccupation.AgPickFromLastValue = False
        Me.TxtMotherOccupation.AgRowFilter = ""
        Me.TxtMotherOccupation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherOccupation.AgSelectedValue = Nothing
        Me.TxtMotherOccupation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherOccupation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherOccupation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherOccupation.Location = New System.Drawing.Point(333, 331)
        Me.TxtMotherOccupation.MaxLength = 50
        Me.TxtMotherOccupation.Name = "TxtMotherOccupation"
        Me.TxtMotherOccupation.Size = New System.Drawing.Size(325, 21)
        Me.TxtMotherOccupation.TabIndex = 13
        Me.TxtMotherOccupation.Text = "TxtMotherOccupation"
        '
        'LblMotherOccupation
        '
        Me.LblMotherOccupation.AutoSize = True
        Me.LblMotherOccupation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMotherOccupation.Location = New System.Drawing.Point(198, 335)
        Me.LblMotherOccupation.Name = "LblMotherOccupation"
        Me.LblMotherOccupation.Size = New System.Drawing.Size(113, 13)
        Me.LblMotherOccupation.TabIndex = 565
        Me.LblMotherOccupation.Text = "Mother Occupation"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(444, 204)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(93, 13)
        Me.Label58.TabIndex = 564
        Me.Label58.Text = "Mother Income"
        '
        'TxtMotherIncome
        '
        Me.TxtMotherIncome.AgMandatory = False
        Me.TxtMotherIncome.AgMasterHelp = False
        Me.TxtMotherIncome.AgNumberLeftPlaces = 8
        Me.TxtMotherIncome.AgNumberNegetiveAllow = False
        Me.TxtMotherIncome.AgNumberRightPlaces = 2
        Me.TxtMotherIncome.AgPickFromLastValue = False
        Me.TxtMotherIncome.AgRowFilter = ""
        Me.TxtMotherIncome.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherIncome.AgSelectedValue = Nothing
        Me.TxtMotherIncome.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherIncome.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMotherIncome.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherIncome.Location = New System.Drawing.Point(558, 200)
        Me.TxtMotherIncome.Name = "TxtMotherIncome"
        Me.TxtMotherIncome.Size = New System.Drawing.Size(100, 21)
        Me.TxtMotherIncome.TabIndex = 7
        Me.TxtMotherIncome.Text = "AgTextBox5"
        Me.TxtMotherIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(198, 204)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(90, 13)
        Me.Label57.TabIndex = 563
        Me.Label57.Text = "Father Income"
        '
        'TxtFatherIncome
        '
        Me.TxtFatherIncome.AgMandatory = False
        Me.TxtFatherIncome.AgMasterHelp = False
        Me.TxtFatherIncome.AgNumberLeftPlaces = 8
        Me.TxtFatherIncome.AgNumberNegetiveAllow = False
        Me.TxtFatherIncome.AgNumberRightPlaces = 2
        Me.TxtFatherIncome.AgPickFromLastValue = False
        Me.TxtFatherIncome.AgRowFilter = ""
        Me.TxtFatherIncome.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherIncome.AgSelectedValue = Nothing
        Me.TxtFatherIncome.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherIncome.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFatherIncome.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherIncome.Location = New System.Drawing.Point(333, 200)
        Me.TxtFatherIncome.Name = "TxtFatherIncome"
        Me.TxtFatherIncome.Size = New System.Drawing.Size(100, 21)
        Me.TxtFatherIncome.TabIndex = 6
        Me.TxtFatherIncome.Text = "AgTextBox5"
        Me.TxtFatherIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFatherDesignation
        '
        Me.TxtFatherDesignation.AgMandatory = False
        Me.TxtFatherDesignation.AgMasterHelp = True
        Me.TxtFatherDesignation.AgNumberLeftPlaces = 0
        Me.TxtFatherDesignation.AgNumberNegetiveAllow = False
        Me.TxtFatherDesignation.AgNumberRightPlaces = 0
        Me.TxtFatherDesignation.AgPickFromLastValue = False
        Me.TxtFatherDesignation.AgRowFilter = ""
        Me.TxtFatherDesignation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherDesignation.AgSelectedValue = Nothing
        Me.TxtFatherDesignation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherDesignation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherDesignation.Location = New System.Drawing.Point(333, 309)
        Me.TxtFatherDesignation.MaxLength = 50
        Me.TxtFatherDesignation.Name = "TxtFatherDesignation"
        Me.TxtFatherDesignation.Size = New System.Drawing.Size(325, 21)
        Me.TxtFatherDesignation.TabIndex = 12
        Me.TxtFatherDesignation.Text = "FatherDesignation"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(198, 313)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(74, 13)
        Me.Label56.TabIndex = 562
        Me.Label56.Text = "Designation"
        '
        'TxtMotherDesignation
        '
        Me.TxtMotherDesignation.AgMandatory = False
        Me.TxtMotherDesignation.AgMasterHelp = True
        Me.TxtMotherDesignation.AgNumberLeftPlaces = 0
        Me.TxtMotherDesignation.AgNumberNegetiveAllow = False
        Me.TxtMotherDesignation.AgNumberRightPlaces = 0
        Me.TxtMotherDesignation.AgPickFromLastValue = False
        Me.TxtMotherDesignation.AgRowFilter = ""
        Me.TxtMotherDesignation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherDesignation.AgSelectedValue = Nothing
        Me.TxtMotherDesignation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherDesignation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherDesignation.Location = New System.Drawing.Point(333, 397)
        Me.TxtMotherDesignation.MaxLength = 50
        Me.TxtMotherDesignation.Name = "TxtMotherDesignation"
        Me.TxtMotherDesignation.Size = New System.Drawing.Size(325, 21)
        Me.TxtMotherDesignation.TabIndex = 16
        Me.TxtMotherDesignation.Text = "TxtMotherDesignation"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(198, 401)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(74, 13)
        Me.Label55.TabIndex = 561
        Me.Label55.Text = "Designation"
        '
        'TxtMotherCompanyAddress
        '
        Me.TxtMotherCompanyAddress.AgMandatory = False
        Me.TxtMotherCompanyAddress.AgMasterHelp = False
        Me.TxtMotherCompanyAddress.AgNumberLeftPlaces = 0
        Me.TxtMotherCompanyAddress.AgNumberNegetiveAllow = False
        Me.TxtMotherCompanyAddress.AgNumberRightPlaces = 0
        Me.TxtMotherCompanyAddress.AgPickFromLastValue = False
        Me.TxtMotherCompanyAddress.AgRowFilter = ""
        Me.TxtMotherCompanyAddress.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherCompanyAddress.AgSelectedValue = Nothing
        Me.TxtMotherCompanyAddress.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherCompanyAddress.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherCompanyAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherCompanyAddress.Location = New System.Drawing.Point(333, 375)
        Me.TxtMotherCompanyAddress.MaxLength = 100
        Me.TxtMotherCompanyAddress.Name = "TxtMotherCompanyAddress"
        Me.TxtMotherCompanyAddress.Size = New System.Drawing.Size(325, 21)
        Me.TxtMotherCompanyAddress.TabIndex = 15
        Me.TxtMotherCompanyAddress.Text = "AgTextBox4"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(198, 379)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(53, 13)
        Me.Label54.TabIndex = 560
        Me.Label54.Text = "Address"
        '
        'TxtMotherCompany
        '
        Me.TxtMotherCompany.AgMandatory = False
        Me.TxtMotherCompany.AgMasterHelp = False
        Me.TxtMotherCompany.AgNumberLeftPlaces = 0
        Me.TxtMotherCompany.AgNumberNegetiveAllow = False
        Me.TxtMotherCompany.AgNumberRightPlaces = 0
        Me.TxtMotherCompany.AgPickFromLastValue = False
        Me.TxtMotherCompany.AgRowFilter = ""
        Me.TxtMotherCompany.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherCompany.AgSelectedValue = Nothing
        Me.TxtMotherCompany.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherCompany.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherCompany.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherCompany.Location = New System.Drawing.Point(333, 353)
        Me.TxtMotherCompany.MaxLength = 100
        Me.TxtMotherCompany.Name = "TxtMotherCompany"
        Me.TxtMotherCompany.Size = New System.Drawing.Size(325, 21)
        Me.TxtMotherCompany.TabIndex = 14
        Me.TxtMotherCompany.Text = "AgTextBox3"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(198, 358)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(99, 13)
        Me.Label53.TabIndex = 559
        Me.Label53.Text = "Company Name"
        '
        'TxtFatherCompanyAddress
        '
        Me.TxtFatherCompanyAddress.AgMandatory = False
        Me.TxtFatherCompanyAddress.AgMasterHelp = False
        Me.TxtFatherCompanyAddress.AgNumberLeftPlaces = 0
        Me.TxtFatherCompanyAddress.AgNumberNegetiveAllow = False
        Me.TxtFatherCompanyAddress.AgNumberRightPlaces = 0
        Me.TxtFatherCompanyAddress.AgPickFromLastValue = False
        Me.TxtFatherCompanyAddress.AgRowFilter = ""
        Me.TxtFatherCompanyAddress.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherCompanyAddress.AgSelectedValue = Nothing
        Me.TxtFatherCompanyAddress.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherCompanyAddress.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherCompanyAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherCompanyAddress.Location = New System.Drawing.Point(333, 287)
        Me.TxtFatherCompanyAddress.MaxLength = 100
        Me.TxtFatherCompanyAddress.Name = "TxtFatherCompanyAddress"
        Me.TxtFatherCompanyAddress.Size = New System.Drawing.Size(325, 21)
        Me.TxtFatherCompanyAddress.TabIndex = 11
        Me.TxtFatherCompanyAddress.Text = "AgTextBox2"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(198, 292)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(53, 13)
        Me.Label52.TabIndex = 558
        Me.Label52.Text = "Address"
        '
        'TxtFatherCompany
        '
        Me.TxtFatherCompany.AgMandatory = False
        Me.TxtFatherCompany.AgMasterHelp = False
        Me.TxtFatherCompany.AgNumberLeftPlaces = 0
        Me.TxtFatherCompany.AgNumberNegetiveAllow = False
        Me.TxtFatherCompany.AgNumberRightPlaces = 0
        Me.TxtFatherCompany.AgPickFromLastValue = False
        Me.TxtFatherCompany.AgRowFilter = ""
        Me.TxtFatherCompany.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherCompany.AgSelectedValue = Nothing
        Me.TxtFatherCompany.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherCompany.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherCompany.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherCompany.Location = New System.Drawing.Point(333, 265)
        Me.TxtFatherCompany.MaxLength = 100
        Me.TxtFatherCompany.Name = "TxtFatherCompany"
        Me.TxtFatherCompany.Size = New System.Drawing.Size(325, 21)
        Me.TxtFatherCompany.TabIndex = 10
        Me.TxtFatherCompany.Text = "AgTextBox1"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(198, 269)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(95, 13)
        Me.Label51.TabIndex = 557
        Me.Label51.Text = "CompanyName"
        '
        'TxtFatherOccupation
        '
        Me.TxtFatherOccupation.AgMandatory = False
        Me.TxtFatherOccupation.AgMasterHelp = False
        Me.TxtFatherOccupation.AgNumberLeftPlaces = 0
        Me.TxtFatherOccupation.AgNumberNegetiveAllow = False
        Me.TxtFatherOccupation.AgNumberRightPlaces = 0
        Me.TxtFatherOccupation.AgPickFromLastValue = False
        Me.TxtFatherOccupation.AgRowFilter = ""
        Me.TxtFatherOccupation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherOccupation.AgSelectedValue = Nothing
        Me.TxtFatherOccupation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherOccupation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherOccupation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherOccupation.Location = New System.Drawing.Point(333, 243)
        Me.TxtFatherOccupation.MaxLength = 50
        Me.TxtFatherOccupation.Name = "TxtFatherOccupation"
        Me.TxtFatherOccupation.Size = New System.Drawing.Size(325, 21)
        Me.TxtFatherOccupation.TabIndex = 9
        Me.TxtFatherOccupation.Text = "AgTextBox4"
        '
        'TxtFamilyIncome
        '
        Me.TxtFamilyIncome.AgMandatory = False
        Me.TxtFamilyIncome.AgMasterHelp = False
        Me.TxtFamilyIncome.AgNumberLeftPlaces = 8
        Me.TxtFamilyIncome.AgNumberNegetiveAllow = False
        Me.TxtFamilyIncome.AgNumberRightPlaces = 2
        Me.TxtFamilyIncome.AgPickFromLastValue = False
        Me.TxtFamilyIncome.AgRowFilter = ""
        Me.TxtFamilyIncome.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFamilyIncome.AgSelectedValue = Nothing
        Me.TxtFamilyIncome.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFamilyIncome.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFamilyIncome.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFamilyIncome.Location = New System.Drawing.Point(333, 222)
        Me.TxtFamilyIncome.Name = "TxtFamilyIncome"
        Me.TxtFamilyIncome.ReadOnly = True
        Me.TxtFamilyIncome.Size = New System.Drawing.Size(100, 21)
        Me.TxtFamilyIncome.TabIndex = 8
        Me.TxtFamilyIncome.TabStop = False
        Me.TxtFamilyIncome.Text = "AgTextBox5"
        Me.TxtFamilyIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(198, 247)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(110, 13)
        Me.Label29.TabIndex = 556
        Me.Label29.Text = "Father Occupation"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(198, 226)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 555
        Me.Label17.Text = "Family Income"
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
        Me.TxtSite_Code.BackColor = System.Drawing.SystemColors.Control
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(333, 90)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(444, 138)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 570
        Me.Label18.Text = "Category"
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
        Me.TxtCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCategory.Location = New System.Drawing.Point(558, 134)
        Me.TxtCategory.MaxLength = 20
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(100, 21)
        Me.TxtCategory.TabIndex = 3
        Me.TxtCategory.Text = "AgTextBox1"
        '
        'TxtFatherName
        '
        Me.TxtFatherName.AgMandatory = False
        Me.TxtFatherName.AgMasterHelp = False
        Me.TxtFatherName.AgNumberLeftPlaces = 0
        Me.TxtFatherName.AgNumberNegetiveAllow = False
        Me.TxtFatherName.AgNumberRightPlaces = 0
        Me.TxtFatherName.AgPickFromLastValue = False
        Me.TxtFatherName.AgRowFilter = ""
        Me.TxtFatherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherName.AgSelectedValue = Nothing
        Me.TxtFatherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherName.Location = New System.Drawing.Point(333, 156)
        Me.TxtFatherName.MaxLength = 50
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(325, 21)
        Me.TxtFatherName.TabIndex = 4
        Me.TxtFatherName.Text = "AgTextBox4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 572
        Me.Label1.Text = "Father Name"
        '
        'TxtMotherName
        '
        Me.TxtMotherName.AgMandatory = False
        Me.TxtMotherName.AgMasterHelp = False
        Me.TxtMotherName.AgNumberLeftPlaces = 0
        Me.TxtMotherName.AgNumberNegetiveAllow = False
        Me.TxtMotherName.AgNumberRightPlaces = 0
        Me.TxtMotherName.AgPickFromLastValue = False
        Me.TxtMotherName.AgRowFilter = ""
        Me.TxtMotherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherName.AgSelectedValue = Nothing
        Me.TxtMotherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherName.Location = New System.Drawing.Point(333, 178)
        Me.TxtMotherName.MaxLength = 50
        Me.TxtMotherName.Name = "TxtMotherName"
        Me.TxtMotherName.Size = New System.Drawing.Size(325, 21)
        Me.TxtMotherName.TabIndex = 5
        Me.TxtMotherName.Text = "AgTextBox4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(198, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 574
        Me.Label2.Text = "Mother Name"
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 499)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 576
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
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(666, 499)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 577
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
        Me.TxtModified.Location = New System.Drawing.Point(13, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 489)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(864, 4)
        Me.GroupBox2.TabIndex = 575
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(198, 94)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 578
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'FrmStudentFamilyIncome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 562)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtMotherName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtMotherOccupation)
        Me.Controls.Add(Me.LblMotherOccupation)
        Me.Controls.Add(Me.TxtMotherIncome)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.TxtFatherIncome)
        Me.Controls.Add(Me.TxtFatherDesignation)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.TxtMotherDesignation)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.TxtMotherCompanyAddress)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.TxtMotherCompany)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.TxtFatherCompanyAddress)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.TxtFatherCompany)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.TxtFatherOccupation)
        Me.Controls.Add(Me.TxtFamilyIncome)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LblAsOnDateReq)
        Me.Controls.Add(Me.LblAsOnDate)
        Me.Controls.Add(Me.TxtAsOnDate)
        Me.Controls.Add(Me.LblStudentReq)
        Me.Controls.Add(Me.TxtStudent)
        Me.Controls.Add(Me.LblStudent)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.Label58)
        Me.KeyPreview = True
        Me.Name = "FrmStudentFamilyIncome"
        Me.Text = "Student Family Income"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtStudent As AgControls.AgTextBox
    Friend WithEvents LblStudent As System.Windows.Forms.Label
    Friend WithEvents LblStudentReq As System.Windows.Forms.Label
    Friend WithEvents LblAsOnDateReq As System.Windows.Forms.Label
    Friend WithEvents LblAsOnDate As System.Windows.Forms.Label
    Friend WithEvents TxtAsOnDate As AgControls.AgTextBox
    Friend WithEvents TxtMotherOccupation As AgControls.AgTextBox
    Friend WithEvents LblMotherOccupation As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TxtMotherIncome As AgControls.AgTextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents TxtFatherIncome As AgControls.AgTextBox
    Friend WithEvents TxtFatherDesignation As AgControls.AgTextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TxtMotherDesignation As AgControls.AgTextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents TxtMotherCompanyAddress As AgControls.AgTextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents TxtMotherCompany As AgControls.AgTextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents TxtFatherCompanyAddress As AgControls.AgTextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents TxtFatherCompany As AgControls.AgTextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TxtFatherOccupation As AgControls.AgTextBox
    Friend WithEvents TxtFamilyIncome As AgControls.AgTextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtCategory As AgControls.AgTextBox
    Friend WithEvents TxtFatherName As AgControls.AgTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMotherName As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
End Class
