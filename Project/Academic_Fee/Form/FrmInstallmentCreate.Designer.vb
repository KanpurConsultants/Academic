<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInstallmentCreate
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
        Me.TxtDiv_Code = New AgControls.AgTextBox
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtRecordType = New AgControls.AgTextBox
        Me.LblEntryNo = New System.Windows.Forms.Label
        Me.LblEntryDateReq = New System.Windows.Forms.Label
        Me.LblEntryDate = New System.Windows.Forms.Label
        Me.TxtEntryDate = New AgControls.AgTextBox
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.TxtSubCode = New AgControls.AgTextBox
        Me.TxtEmployee = New AgControls.AgTextBox
        Me.LblInstallmentStartDate = New System.Windows.Forms.Label
        Me.TxtInstallmentStartDate = New AgControls.AgTextBox
        Me.TxtEntryNo = New AgControls.AgTextBox
        Me.TxtDueAmount = New AgControls.AgTextBox
        Me.LblDueAmount = New System.Windows.Forms.Label
        Me.TxtInstallmentAmount = New AgControls.AgTextBox
        Me.LblInstallmentAmount = New System.Windows.Forms.Label
        Me.TxtTotalInstallments = New AgControls.AgTextBox
        Me.LblTotalInstallments = New System.Windows.Forms.Label
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GrpModified = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LinkLblTitle = New System.Windows.Forms.LinkLabel
        Me.LblRemark = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblDueAmountReq = New System.Windows.Forms.Label
        Me.LblTotalInstallmentsReq = New System.Windows.Forms.Label
        Me.LblInstallmentStartDateReq = New System.Windows.Forms.Label
        Me.LblInActiveDate = New System.Windows.Forms.Label
        Me.TxtInActiveDate = New AgControls.AgTextBox
        Me.LblInActiveRemark = New System.Windows.Forms.Label
        Me.TxtInActiveRemark = New AgControls.AgTextBox
        Me.TxtRemindBeforeDays = New AgControls.AgTextBox
        Me.LblRemindBeforeDays = New System.Windows.Forms.Label
        Me.TxtRemindAfterDays = New AgControls.AgTextBox
        Me.LblRemindAfterDays = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblValTotalAmount = New System.Windows.Forms.Label
        Me.LbltextTotalAmount = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblAdmissionDocId = New System.Windows.Forms.Label
        Me.TxtAdmissionId = New AgControls.AgTextBox
        Me.LblAdmissionId = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GrpModified.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDiv_Code
        '
        Me.TxtDiv_Code.AgMandatory = False
        Me.TxtDiv_Code.AgMasterHelp = False
        Me.TxtDiv_Code.AgNumberLeftPlaces = 0
        Me.TxtDiv_Code.AgNumberNegetiveAllow = False
        Me.TxtDiv_Code.AgNumberRightPlaces = 0
        Me.TxtDiv_Code.AgPickFromLastValue = False
        Me.TxtDiv_Code.AgRowFilter = ""
        Me.TxtDiv_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDiv_Code.AgSelectedValue = Nothing
        Me.TxtDiv_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDiv_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDiv_Code.BackColor = System.Drawing.Color.White
        Me.TxtDiv_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiv_Code.Enabled = False
        Me.TxtDiv_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiv_Code.Location = New System.Drawing.Point(271, 582)
        Me.TxtDiv_Code.MaxLength = 100
        Me.TxtDiv_Code.Name = "TxtDiv_Code"
        Me.TxtDiv_Code.ReadOnly = True
        Me.TxtDiv_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtDiv_Code.TabIndex = 736
        Me.TxtDiv_Code.TabStop = False
        Me.TxtDiv_Code.Text = "TxtDiv_Code"
        Me.TxtDiv_Code.Visible = False
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(271, 562)
        Me.TxtSite_Code.MaxLength = 50
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.TabIndex = 735
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(327, 178)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(403, 329)
        Me.Pnl1.TabIndex = 14
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
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
        Me.Topctrl1.TabIndex = 15
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
        'TxtRecordType
        '
        Me.TxtRecordType.AgMandatory = False
        Me.TxtRecordType.AgMasterHelp = False
        Me.TxtRecordType.AgNumberLeftPlaces = 0
        Me.TxtRecordType.AgNumberNegetiveAllow = False
        Me.TxtRecordType.AgNumberRightPlaces = 0
        Me.TxtRecordType.AgPickFromLastValue = False
        Me.TxtRecordType.AgRowFilter = ""
        Me.TxtRecordType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRecordType.AgSelectedValue = Nothing
        Me.TxtRecordType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRecordType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRecordType.BackColor = System.Drawing.Color.White
        Me.TxtRecordType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRecordType.Enabled = False
        Me.TxtRecordType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecordType.Location = New System.Drawing.Point(377, 581)
        Me.TxtRecordType.MaxLength = 100
        Me.TxtRecordType.Name = "TxtRecordType"
        Me.TxtRecordType.ReadOnly = True
        Me.TxtRecordType.Size = New System.Drawing.Size(100, 18)
        Me.TxtRecordType.TabIndex = 784
        Me.TxtRecordType.TabStop = False
        Me.TxtRecordType.Text = "TxtRecordType"
        Me.TxtRecordType.Visible = False
        '
        'LblEntryNo
        '
        Me.LblEntryNo.AutoSize = True
        Me.LblEntryNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEntryNo.Location = New System.Drawing.Point(282, 64)
        Me.LblEntryNo.Name = "LblEntryNo"
        Me.LblEntryNo.Size = New System.Drawing.Size(53, 15)
        Me.LblEntryNo.TabIndex = 790
        Me.LblEntryNo.Text = "Entry No"
        '
        'LblEntryDateReq
        '
        Me.LblEntryDateReq.AutoSize = True
        Me.LblEntryDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblEntryDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblEntryDateReq.Location = New System.Drawing.Point(117, 69)
        Me.LblEntryDateReq.Name = "LblEntryDateReq"
        Me.LblEntryDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblEntryDateReq.TabIndex = 789
        Me.LblEntryDateReq.Text = "Ä"
        '
        'LblEntryDate
        '
        Me.LblEntryDate.AutoSize = True
        Me.LblEntryDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEntryDate.Location = New System.Drawing.Point(13, 65)
        Me.LblEntryDate.Name = "LblEntryDate"
        Me.LblEntryDate.Size = New System.Drawing.Size(63, 15)
        Me.LblEntryDate.TabIndex = 788
        Me.LblEntryDate.Text = "Entry Date"
        '
        'TxtEntryDate
        '
        Me.TxtEntryDate.AgMandatory = True
        Me.TxtEntryDate.AgMasterHelp = False
        Me.TxtEntryDate.AgNumberLeftPlaces = 0
        Me.TxtEntryDate.AgNumberNegetiveAllow = False
        Me.TxtEntryDate.AgNumberRightPlaces = 0
        Me.TxtEntryDate.AgPickFromLastValue = False
        Me.TxtEntryDate.AgRowFilter = ""
        Me.TxtEntryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEntryDate.AgSelectedValue = Nothing
        Me.TxtEntryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEntryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtEntryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEntryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEntryDate.Location = New System.Drawing.Point(129, 63)
        Me.TxtEntryDate.MaxLength = 25
        Me.TxtEntryDate.Name = "TxtEntryDate"
        Me.TxtEntryDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtEntryDate.TabIndex = 0
        Me.TxtEntryDate.Text = "TxtTaskDate"
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(331, 64)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(58, 16)
        Me.LblPrefix.TabIndex = 787
        Me.LblPrefix.Text = "LblPrefix"
        Me.LblPrefix.Visible = False
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(117, 89)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 796
        Me.LblSubCodeReq.Text = "Ä"
        '
        'TxtSubCode
        '
        Me.TxtSubCode.AgMandatory = False
        Me.TxtSubCode.AgMasterHelp = False
        Me.TxtSubCode.AgNumberLeftPlaces = 0
        Me.TxtSubCode.AgNumberNegetiveAllow = False
        Me.TxtSubCode.AgNumberRightPlaces = 0
        Me.TxtSubCode.AgPickFromLastValue = False
        Me.TxtSubCode.AgRowFilter = ""
        Me.TxtSubCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubCode.AgSelectedValue = Nothing
        Me.TxtSubCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubCode.Location = New System.Drawing.Point(483, 562)
        Me.TxtSubCode.MaxLength = 123
        Me.TxtSubCode.Name = "TxtSubCode"
        Me.TxtSubCode.Size = New System.Drawing.Size(100, 18)
        Me.TxtSubCode.TabIndex = 2
        Me.TxtSubCode.Text = "TxtSubCode"
        Me.TxtSubCode.Visible = False
        '
        'TxtEmployee
        '
        Me.TxtEmployee.AgMandatory = False
        Me.TxtEmployee.AgMasterHelp = False
        Me.TxtEmployee.AgNumberLeftPlaces = 0
        Me.TxtEmployee.AgNumberNegetiveAllow = False
        Me.TxtEmployee.AgNumberRightPlaces = 0
        Me.TxtEmployee.AgPickFromLastValue = False
        Me.TxtEmployee.AgRowFilter = ""
        Me.TxtEmployee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmployee.AgSelectedValue = Nothing
        Me.TxtEmployee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmployee.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmployee.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployee.Location = New System.Drawing.Point(377, 562)
        Me.TxtEmployee.MaxLength = 123
        Me.TxtEmployee.Name = "TxtEmployee"
        Me.TxtEmployee.Size = New System.Drawing.Size(100, 18)
        Me.TxtEmployee.TabIndex = 791
        Me.TxtEmployee.Text = "Employee"
        Me.TxtEmployee.Visible = False
        '
        'LblInstallmentStartDate
        '
        Me.LblInstallmentStartDate.AutoSize = True
        Me.LblInstallmentStartDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstallmentStartDate.Location = New System.Drawing.Point(779, 63)
        Me.LblInstallmentStartDate.Name = "LblInstallmentStartDate"
        Me.LblInstallmentStartDate.Size = New System.Drawing.Size(61, 15)
        Me.LblInstallmentStartDate.TabIndex = 798
        Me.LblInstallmentStartDate.Text = "Start Date"
        '
        'TxtInstallmentStartDate
        '
        Me.TxtInstallmentStartDate.AgMandatory = True
        Me.TxtInstallmentStartDate.AgMasterHelp = False
        Me.TxtInstallmentStartDate.AgNumberLeftPlaces = 0
        Me.TxtInstallmentStartDate.AgNumberNegetiveAllow = False
        Me.TxtInstallmentStartDate.AgNumberRightPlaces = 0
        Me.TxtInstallmentStartDate.AgPickFromLastValue = False
        Me.TxtInstallmentStartDate.AgRowFilter = ""
        Me.TxtInstallmentStartDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInstallmentStartDate.AgSelectedValue = Nothing
        Me.TxtInstallmentStartDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInstallmentStartDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtInstallmentStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInstallmentStartDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInstallmentStartDate.Location = New System.Drawing.Point(880, 61)
        Me.TxtInstallmentStartDate.MaxLength = 25
        Me.TxtInstallmentStartDate.Name = "TxtInstallmentStartDate"
        Me.TxtInstallmentStartDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtInstallmentStartDate.TabIndex = 7
        '
        'TxtEntryNo
        '
        Me.TxtEntryNo.AgMandatory = False
        Me.TxtEntryNo.AgMasterHelp = False
        Me.TxtEntryNo.AgNumberLeftPlaces = 0
        Me.TxtEntryNo.AgNumberNegetiveAllow = False
        Me.TxtEntryNo.AgNumberRightPlaces = 0
        Me.TxtEntryNo.AgPickFromLastValue = False
        Me.TxtEntryNo.AgRowFilter = ""
        Me.TxtEntryNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEntryNo.AgSelectedValue = Nothing
        Me.TxtEntryNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEntryNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEntryNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEntryNo.Location = New System.Drawing.Point(379, 63)
        Me.TxtEntryNo.MaxLength = 25
        Me.TxtEntryNo.Name = "TxtEntryNo"
        Me.TxtEntryNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtEntryNo.TabIndex = 1
        '
        'TxtDueAmount
        '
        Me.TxtDueAmount.AgMandatory = True
        Me.TxtDueAmount.AgMasterHelp = False
        Me.TxtDueAmount.AgNumberLeftPlaces = 8
        Me.TxtDueAmount.AgNumberNegetiveAllow = False
        Me.TxtDueAmount.AgNumberRightPlaces = 2
        Me.TxtDueAmount.AgPickFromLastValue = False
        Me.TxtDueAmount.AgRowFilter = ""
        Me.TxtDueAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDueAmount.AgSelectedValue = Nothing
        Me.TxtDueAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDueAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtDueAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDueAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDueAmount.Location = New System.Drawing.Point(129, 123)
        Me.TxtDueAmount.MaxLength = 25
        Me.TxtDueAmount.Name = "TxtDueAmount"
        Me.TxtDueAmount.Size = New System.Drawing.Size(100, 18)
        Me.TxtDueAmount.TabIndex = 4
        '
        'LblDueAmount
        '
        Me.LblDueAmount.AutoSize = True
        Me.LblDueAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDueAmount.Location = New System.Drawing.Point(14, 125)
        Me.LblDueAmount.Name = "LblDueAmount"
        Me.LblDueAmount.Size = New System.Drawing.Size(49, 15)
        Me.LblDueAmount.TabIndex = 800
        Me.LblDueAmount.Text = "Amount"
        '
        'TxtInstallmentAmount
        '
        Me.TxtInstallmentAmount.AgMandatory = False
        Me.TxtInstallmentAmount.AgMasterHelp = False
        Me.TxtInstallmentAmount.AgNumberLeftPlaces = 8
        Me.TxtInstallmentAmount.AgNumberNegetiveAllow = False
        Me.TxtInstallmentAmount.AgNumberRightPlaces = 2
        Me.TxtInstallmentAmount.AgPickFromLastValue = False
        Me.TxtInstallmentAmount.AgRowFilter = ""
        Me.TxtInstallmentAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInstallmentAmount.AgSelectedValue = Nothing
        Me.TxtInstallmentAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInstallmentAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtInstallmentAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInstallmentAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInstallmentAmount.Location = New System.Drawing.Point(379, 123)
        Me.TxtInstallmentAmount.MaxLength = 25
        Me.TxtInstallmentAmount.Name = "TxtInstallmentAmount"
        Me.TxtInstallmentAmount.Size = New System.Drawing.Size(100, 18)
        Me.TxtInstallmentAmount.TabIndex = 5
        '
        'LblInstallmentAmount
        '
        Me.LblInstallmentAmount.AutoSize = True
        Me.LblInstallmentAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstallmentAmount.Location = New System.Drawing.Point(278, 125)
        Me.LblInstallmentAmount.Name = "LblInstallmentAmount"
        Me.LblInstallmentAmount.Size = New System.Drawing.Size(68, 15)
        Me.LblInstallmentAmount.TabIndex = 802
        Me.LblInstallmentAmount.Text = "Installment"
        '
        'TxtTotalInstallments
        '
        Me.TxtTotalInstallments.AgMandatory = True
        Me.TxtTotalInstallments.AgMasterHelp = False
        Me.TxtTotalInstallments.AgNumberLeftPlaces = 8
        Me.TxtTotalInstallments.AgNumberNegetiveAllow = False
        Me.TxtTotalInstallments.AgNumberRightPlaces = 0
        Me.TxtTotalInstallments.AgPickFromLastValue = False
        Me.TxtTotalInstallments.AgRowFilter = ""
        Me.TxtTotalInstallments.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalInstallments.AgSelectedValue = Nothing
        Me.TxtTotalInstallments.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalInstallments.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalInstallments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalInstallments.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalInstallments.Location = New System.Drawing.Point(630, 61)
        Me.TxtTotalInstallments.MaxLength = 25
        Me.TxtTotalInstallments.Name = "TxtTotalInstallments"
        Me.TxtTotalInstallments.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalInstallments.TabIndex = 6
        '
        'LblTotalInstallments
        '
        Me.LblTotalInstallments.AutoSize = True
        Me.LblTotalInstallments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalInstallments.Location = New System.Drawing.Point(515, 63)
        Me.LblTotalInstallments.Name = "LblTotalInstallments"
        Me.LblTotalInstallments.Size = New System.Drawing.Size(105, 15)
        Me.LblTotalInstallments.TabIndex = 804
        Me.LblTotalInstallments.Text = "Total Installments"
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 553)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 807
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
        'GrpModified
        '
        Me.GrpModified.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpModified.Controls.Add(Me.TxtModified)
        Me.GrpModified.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpModified.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpModified.ForeColor = System.Drawing.Color.Maroon
        Me.GrpModified.Location = New System.Drawing.Point(794, 553)
        Me.GrpModified.Name = "GrpModified"
        Me.GrpModified.Size = New System.Drawing.Size(186, 51)
        Me.GrpModified.TabIndex = 808
        Me.GrpModified.TabStop = False
        Me.GrpModified.Tag = "TR"
        Me.GrpModified.Text = "Modified By "
        Me.GrpModified.Visible = False
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 543)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1000, 4)
        Me.GroupBox2.TabIndex = 806
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LinkLblTitle
        '
        Me.LinkLblTitle.AutoSize = True
        Me.LinkLblTitle.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLblTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLblTitle.LinkColor = System.Drawing.Color.White
        Me.LinkLblTitle.Location = New System.Drawing.Point(324, 159)
        Me.LinkLblTitle.Name = "LinkLblTitle"
        Me.LinkLblTitle.Size = New System.Drawing.Size(134, 18)
        Me.LinkLblTitle.TabIndex = 935
        Me.LinkLblTitle.TabStop = True
        Me.LinkLblTitle.Text = "Installment Detail:"
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(515, 123)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 12
        Me.LblRemark.Text = "&Remark"
        '
        'TxtRemark
        '
        Me.TxtRemark.AgMandatory = False
        Me.TxtRemark.AgMasterHelp = False
        Me.TxtRemark.AgNumberLeftPlaces = 0
        Me.TxtRemark.AgNumberNegetiveAllow = False
        Me.TxtRemark.AgNumberRightPlaces = 0
        Me.TxtRemark.AgPickFromLastValue = False
        Me.TxtRemark.AgRowFilter = ""
        Me.TxtRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemark.AgSelectedValue = Nothing
        Me.TxtRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(630, 121)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 13
        '
        'LblDueAmountReq
        '
        Me.LblDueAmountReq.AutoSize = True
        Me.LblDueAmountReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDueAmountReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDueAmountReq.Location = New System.Drawing.Point(117, 129)
        Me.LblDueAmountReq.Name = "LblDueAmountReq"
        Me.LblDueAmountReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDueAmountReq.TabIndex = 938
        Me.LblDueAmountReq.Text = "Ä"
        '
        'LblTotalInstallmentsReq
        '
        Me.LblTotalInstallmentsReq.AutoSize = True
        Me.LblTotalInstallmentsReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTotalInstallmentsReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTotalInstallmentsReq.Location = New System.Drawing.Point(619, 67)
        Me.LblTotalInstallmentsReq.Name = "LblTotalInstallmentsReq"
        Me.LblTotalInstallmentsReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTotalInstallmentsReq.TabIndex = 940
        Me.LblTotalInstallmentsReq.Text = "Ä"
        '
        'LblInstallmentStartDateReq
        '
        Me.LblInstallmentStartDateReq.AutoSize = True
        Me.LblInstallmentStartDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblInstallmentStartDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblInstallmentStartDateReq.Location = New System.Drawing.Point(868, 68)
        Me.LblInstallmentStartDateReq.Name = "LblInstallmentStartDateReq"
        Me.LblInstallmentStartDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblInstallmentStartDateReq.TabIndex = 941
        Me.LblInstallmentStartDateReq.Text = "Ä"
        '
        'LblInActiveDate
        '
        Me.LblInActiveDate.AutoSize = True
        Me.LblInActiveDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInActiveDate.Location = New System.Drawing.Point(515, 103)
        Me.LblInActiveDate.Name = "LblInActiveDate"
        Me.LblInActiveDate.Size = New System.Drawing.Size(81, 15)
        Me.LblInActiveDate.TabIndex = 943
        Me.LblInActiveDate.Text = "In-Active Date"
        '
        'TxtInActiveDate
        '
        Me.TxtInActiveDate.AgMandatory = False
        Me.TxtInActiveDate.AgMasterHelp = False
        Me.TxtInActiveDate.AgNumberLeftPlaces = 0
        Me.TxtInActiveDate.AgNumberNegetiveAllow = False
        Me.TxtInActiveDate.AgNumberRightPlaces = 0
        Me.TxtInActiveDate.AgPickFromLastValue = False
        Me.TxtInActiveDate.AgRowFilter = ""
        Me.TxtInActiveDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInActiveDate.AgSelectedValue = Nothing
        Me.TxtInActiveDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInActiveDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtInActiveDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInActiveDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInActiveDate.Location = New System.Drawing.Point(630, 101)
        Me.TxtInActiveDate.MaxLength = 25
        Me.TxtInActiveDate.Name = "TxtInActiveDate"
        Me.TxtInActiveDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtInActiveDate.TabIndex = 10
        '
        'LblInActiveRemark
        '
        Me.LblInActiveRemark.AutoSize = True
        Me.LblInActiveRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInActiveRemark.Location = New System.Drawing.Point(779, 103)
        Me.LblInActiveRemark.Name = "LblInActiveRemark"
        Me.LblInActiveRemark.Size = New System.Drawing.Size(99, 15)
        Me.LblInActiveRemark.TabIndex = 945
        Me.LblInActiveRemark.Text = "In-Active Remark"
        Me.LblInActiveRemark.Visible = False
        '
        'TxtInActiveRemark
        '
        Me.TxtInActiveRemark.AgMandatory = False
        Me.TxtInActiveRemark.AgMasterHelp = False
        Me.TxtInActiveRemark.AgNumberLeftPlaces = 0
        Me.TxtInActiveRemark.AgNumberNegetiveAllow = False
        Me.TxtInActiveRemark.AgNumberRightPlaces = 0
        Me.TxtInActiveRemark.AgPickFromLastValue = False
        Me.TxtInActiveRemark.AgRowFilter = ""
        Me.TxtInActiveRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInActiveRemark.AgSelectedValue = Nothing
        Me.TxtInActiveRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInActiveRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtInActiveRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInActiveRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInActiveRemark.Location = New System.Drawing.Point(880, 101)
        Me.TxtInActiveRemark.MaxLength = 255
        Me.TxtInActiveRemark.Name = "TxtInActiveRemark"
        Me.TxtInActiveRemark.Size = New System.Drawing.Size(100, 18)
        Me.TxtInActiveRemark.TabIndex = 11
        Me.TxtInActiveRemark.Visible = False
        '
        'TxtRemindBeforeDays
        '
        Me.TxtRemindBeforeDays.AgMandatory = False
        Me.TxtRemindBeforeDays.AgMasterHelp = False
        Me.TxtRemindBeforeDays.AgNumberLeftPlaces = 8
        Me.TxtRemindBeforeDays.AgNumberNegetiveAllow = False
        Me.TxtRemindBeforeDays.AgNumberRightPlaces = 0
        Me.TxtRemindBeforeDays.AgPickFromLastValue = False
        Me.TxtRemindBeforeDays.AgRowFilter = ""
        Me.TxtRemindBeforeDays.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemindBeforeDays.AgSelectedValue = Nothing
        Me.TxtRemindBeforeDays.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemindBeforeDays.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtRemindBeforeDays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemindBeforeDays.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemindBeforeDays.Location = New System.Drawing.Point(630, 81)
        Me.TxtRemindBeforeDays.MaxLength = 25
        Me.TxtRemindBeforeDays.Name = "TxtRemindBeforeDays"
        Me.TxtRemindBeforeDays.Size = New System.Drawing.Size(100, 18)
        Me.TxtRemindBeforeDays.TabIndex = 8
        '
        'LblRemindBeforeDays
        '
        Me.LblRemindBeforeDays.AutoSize = True
        Me.LblRemindBeforeDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemindBeforeDays.Location = New System.Drawing.Point(515, 83)
        Me.LblRemindBeforeDays.Name = "LblRemindBeforeDays"
        Me.LblRemindBeforeDays.Size = New System.Drawing.Size(90, 15)
        Me.LblRemindBeforeDays.TabIndex = 947
        Me.LblRemindBeforeDays.Text = "Remind Before"
        '
        'TxtRemindAfterDays
        '
        Me.TxtRemindAfterDays.AgMandatory = False
        Me.TxtRemindAfterDays.AgMasterHelp = False
        Me.TxtRemindAfterDays.AgNumberLeftPlaces = 8
        Me.TxtRemindAfterDays.AgNumberNegetiveAllow = False
        Me.TxtRemindAfterDays.AgNumberRightPlaces = 0
        Me.TxtRemindAfterDays.AgPickFromLastValue = False
        Me.TxtRemindAfterDays.AgRowFilter = ""
        Me.TxtRemindAfterDays.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemindAfterDays.AgSelectedValue = Nothing
        Me.TxtRemindAfterDays.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemindAfterDays.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtRemindAfterDays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemindAfterDays.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemindAfterDays.Location = New System.Drawing.Point(880, 81)
        Me.TxtRemindAfterDays.MaxLength = 25
        Me.TxtRemindAfterDays.Name = "TxtRemindAfterDays"
        Me.TxtRemindAfterDays.Size = New System.Drawing.Size(100, 18)
        Me.TxtRemindAfterDays.TabIndex = 9
        '
        'LblRemindAfterDays
        '
        Me.LblRemindAfterDays.AutoSize = True
        Me.LblRemindAfterDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemindAfterDays.Location = New System.Drawing.Point(779, 83)
        Me.LblRemindAfterDays.Name = "LblRemindAfterDays"
        Me.LblRemindAfterDays.Size = New System.Drawing.Size(78, 15)
        Me.LblRemindAfterDays.TabIndex = 949
        Me.LblRemindAfterDays.Text = "Remind After"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(624, 153)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(106, 25)
        Me.BtnFill.TabIndex = 950
        Me.BtnFill.Text = "&Fill Installents"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LemonChiffon
        Me.Panel1.Controls.Add(Me.LblValTotalAmount)
        Me.Panel1.Controls.Add(Me.LbltextTotalAmount)
        Me.Panel1.Location = New System.Drawing.Point(327, 506)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(403, 25)
        Me.Panel1.TabIndex = 951
        '
        'LblValTotalAmount
        '
        Me.LblValTotalAmount.AutoSize = True
        Me.LblValTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalAmount.Location = New System.Drawing.Point(254, 4)
        Me.LblValTotalAmount.Name = "LblValTotalAmount"
        Me.LblValTotalAmount.Size = New System.Drawing.Size(10, 13)
        Me.LblValTotalAmount.TabIndex = 887
        Me.LblValTotalAmount.Text = "."
        '
        'LbltextTotalAmount
        '
        Me.LbltextTotalAmount.AutoSize = True
        Me.LbltextTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbltextTotalAmount.ForeColor = System.Drawing.Color.Maroon
        Me.LbltextTotalAmount.Location = New System.Drawing.Point(202, 4)
        Me.LbltextTotalAmount.Name = "LbltextTotalAmount"
        Me.LbltextTotalAmount.Size = New System.Drawing.Size(46, 14)
        Me.LbltextTotalAmount.TabIndex = 886
        Me.LbltextTotalAmount.Text = "Total :"
        '
        'TxtAdmissionDocId
        '
        Me.TxtAdmissionDocId.AgMandatory = True
        Me.TxtAdmissionDocId.AgMasterHelp = False
        Me.TxtAdmissionDocId.AgNumberLeftPlaces = 0
        Me.TxtAdmissionDocId.AgNumberNegetiveAllow = False
        Me.TxtAdmissionDocId.AgNumberRightPlaces = 0
        Me.TxtAdmissionDocId.AgPickFromLastValue = False
        Me.TxtAdmissionDocId.AgRowFilter = ""
        Me.TxtAdmissionDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionDocId.AgSelectedValue = Nothing
        Me.TxtAdmissionDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionDocId.BackColor = System.Drawing.Color.White
        Me.TxtAdmissionDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(129, 83)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdmissionDocId.TabIndex = 2
        '
        'LblAdmissionDocId
        '
        Me.LblAdmissionDocId.AutoSize = True
        Me.LblAdmissionDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionDocId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblAdmissionDocId.Location = New System.Drawing.Point(13, 86)
        Me.LblAdmissionDocId.Name = "LblAdmissionDocId"
        Me.LblAdmissionDocId.Size = New System.Drawing.Size(51, 13)
        Me.LblAdmissionDocId.TabIndex = 953
        Me.LblAdmissionDocId.Text = "Student"
        '
        'TxtAdmissionId
        '
        Me.TxtAdmissionId.AgMandatory = False
        Me.TxtAdmissionId.AgMasterHelp = False
        Me.TxtAdmissionId.AgNumberLeftPlaces = 0
        Me.TxtAdmissionId.AgNumberNegetiveAllow = False
        Me.TxtAdmissionId.AgNumberRightPlaces = 0
        Me.TxtAdmissionId.AgPickFromLastValue = False
        Me.TxtAdmissionId.AgRowFilter = ""
        Me.TxtAdmissionId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionId.AgSelectedValue = Nothing
        Me.TxtAdmissionId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionId.BackColor = System.Drawing.Color.White
        Me.TxtAdmissionId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionId.Location = New System.Drawing.Point(129, 103)
        Me.TxtAdmissionId.MaxLength = 123
        Me.TxtAdmissionId.Name = "TxtAdmissionId"
        Me.TxtAdmissionId.ReadOnly = True
        Me.TxtAdmissionId.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdmissionId.TabIndex = 3
        Me.TxtAdmissionId.TabStop = False
        '
        'LblAdmissionId
        '
        Me.LblAdmissionId.AutoSize = True
        Me.LblAdmissionId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionId.ForeColor = System.Drawing.Color.Blue
        Me.LblAdmissionId.Location = New System.Drawing.Point(13, 106)
        Me.LblAdmissionId.Name = "LblAdmissionId"
        Me.LblAdmissionId.Size = New System.Drawing.Size(83, 13)
        Me.LblAdmissionId.TabIndex = 955
        Me.LblAdmissionId.Text = "Admission ID"
        '
        'FrmInstallmentCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.LblAdmissionId)
        Me.Controls.Add(Me.TxtAdmissionId)
        Me.Controls.Add(Me.LblAdmissionDocId)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.TxtRemindAfterDays)
        Me.Controls.Add(Me.LblRemindAfterDays)
        Me.Controls.Add(Me.TxtRemindBeforeDays)
        Me.Controls.Add(Me.LblRemindBeforeDays)
        Me.Controls.Add(Me.LblInActiveRemark)
        Me.Controls.Add(Me.TxtInActiveRemark)
        Me.Controls.Add(Me.LblInActiveDate)
        Me.Controls.Add(Me.TxtInActiveDate)
        Me.Controls.Add(Me.LblInstallmentStartDateReq)
        Me.Controls.Add(Me.LblTotalInstallmentsReq)
        Me.Controls.Add(Me.LblDueAmountReq)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.LinkLblTitle)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GrpModified)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtTotalInstallments)
        Me.Controls.Add(Me.LblTotalInstallments)
        Me.Controls.Add(Me.TxtInstallmentAmount)
        Me.Controls.Add(Me.LblInstallmentAmount)
        Me.Controls.Add(Me.TxtDueAmount)
        Me.Controls.Add(Me.LblDueAmount)
        Me.Controls.Add(Me.TxtEntryNo)
        Me.Controls.Add(Me.LblInstallmentStartDate)
        Me.Controls.Add(Me.TxtInstallmentStartDate)
        Me.Controls.Add(Me.LblSubCodeReq)
        Me.Controls.Add(Me.TxtSubCode)
        Me.Controls.Add(Me.TxtEmployee)
        Me.Controls.Add(Me.LblEntryNo)
        Me.Controls.Add(Me.LblEntryDateReq)
        Me.Controls.Add(Me.LblEntryDate)
        Me.Controls.Add(Me.TxtEntryDate)
        Me.Controls.Add(Me.LblPrefix)
        Me.Controls.Add(Me.TxtRecordType)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtDiv_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmInstallmentCreate"
        Me.Text = "Installment Create"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GrpModified.ResumeLayout(False)
        Me.GrpModified.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtDiv_Code As AgControls.AgTextBox
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Public WithEvents TxtRecordType As AgControls.AgTextBox
    Friend WithEvents LblEntryNo As System.Windows.Forms.Label
    Public WithEvents LblEntryDateReq As System.Windows.Forms.Label
    Friend WithEvents LblEntryDate As System.Windows.Forms.Label
    Friend WithEvents TxtEntryDate As AgControls.AgTextBox
    Public WithEvents LblPrefix As System.Windows.Forms.Label
    Public WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Public WithEvents TxtSubCode As AgControls.AgTextBox
    Public WithEvents TxtEmployee As AgControls.AgTextBox
    Friend WithEvents LblInstallmentStartDate As System.Windows.Forms.Label
    Friend WithEvents TxtInstallmentStartDate As AgControls.AgTextBox
    Friend WithEvents TxtEntryNo As AgControls.AgTextBox
    Friend WithEvents TxtDueAmount As AgControls.AgTextBox
    Friend WithEvents LblDueAmount As System.Windows.Forms.Label
    Friend WithEvents TxtInstallmentAmount As AgControls.AgTextBox
    Friend WithEvents LblInstallmentAmount As System.Windows.Forms.Label
    Friend WithEvents TxtTotalInstallments As AgControls.AgTextBox
    Friend WithEvents LblTotalInstallments As System.Windows.Forms.Label
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GrpModified As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLblTitle As System.Windows.Forms.LinkLabel
    Public WithEvents LblRemark As System.Windows.Forms.Label
    Public WithEvents TxtRemark As AgControls.AgTextBox
    Public WithEvents LblDueAmountReq As System.Windows.Forms.Label
    Public WithEvents LblTotalInstallmentsReq As System.Windows.Forms.Label
    Public WithEvents LblInstallmentStartDateReq As System.Windows.Forms.Label
    Friend WithEvents LblInActiveDate As System.Windows.Forms.Label
    Friend WithEvents TxtInActiveDate As AgControls.AgTextBox
    Public WithEvents LblInActiveRemark As System.Windows.Forms.Label
    Public WithEvents TxtInActiveRemark As AgControls.AgTextBox
    Friend WithEvents TxtRemindBeforeDays As AgControls.AgTextBox
    Friend WithEvents LblRemindBeforeDays As System.Windows.Forms.Label
    Friend WithEvents TxtRemindAfterDays As AgControls.AgTextBox
    Friend WithEvents LblRemindAfterDays As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents LblValTotalAmount As System.Windows.Forms.Label
    Public WithEvents LbltextTotalAmount As System.Windows.Forms.Label
    Public WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblAdmissionDocId As System.Windows.Forms.Label
    Public WithEvents TxtAdmissionId As AgControls.AgTextBox
    Friend WithEvents LblAdmissionId As System.Windows.Forms.Label
End Class
