Public Class FrmGeneralSubscription
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents TxtVendor As AgControls.AgTextBox
    Protected WithEvents LblGeneral As System.Windows.Forms.Label
    Protected WithEvents TxtGeneral As AgControls.AgTextBox
    Protected WithEvents LblFromDate As System.Windows.Forms.Label
    Protected WithEvents TxtDateFrom As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents TxtDateUpto As AgControls.AgTextBox
    Protected WithEvents LblRecurrance As System.Windows.Forms.Label
    Protected WithEvents TxtRecurrance As AgControls.AgTextBox
    Protected WithEvents LblPaymentType As System.Windows.Forms.Label
    Protected WithEvents TxtPaymentType As AgControls.AgTextBox
    Protected WithEvents LblAmount As System.Windows.Forms.Label
    Protected WithEvents TxtAmount As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents LblRequisitionBYReq As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtQty As AgControls.AgTextBox
    Protected WithEvents LblQty As System.Windows.Forms.Label
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents LblQtyReq As System.Windows.Forms.Label
    Protected WithEvents LblPaymentTypeReq As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.GeneralSubscription
    End Sub


    Private Sub InitializeComponent()
        Me.TxtVendor = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
        Me.TxtGeneral = New AgControls.AgTextBox
        Me.LblGeneral = New System.Windows.Forms.Label
        Me.TxtDateFrom = New AgControls.AgTextBox
        Me.LblFromDate = New System.Windows.Forms.Label
        Me.TxtDateUpto = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtRecurrance = New AgControls.AgTextBox
        Me.LblRecurrance = New System.Windows.Forms.Label
        Me.TxtPaymentType = New AgControls.AgTextBox
        Me.LblPaymentType = New System.Windows.Forms.Label
        Me.TxtAmount = New AgControls.AgTextBox
        Me.LblAmount = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblRequisitionBYReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtQty = New AgControls.AgTextBox
        Me.LblQty = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblQtyReq = New System.Windows.Forms.Label
        Me.LblPaymentTypeReq = New System.Windows.Forms.Label
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
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(729, 321)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(569, 321)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(410, 321)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(240, 321)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 321)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 315)
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(470, 321)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Tag = ""
        '
        'TxtDocId
        '
        Me.TxtDocId.AgSelectedValue = ""
        Me.TxtDocId.BackColor = System.Drawing.Color.White
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(448, 74)
        Me.LblV_No.Tag = ""
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(562, 73)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(333, 79)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(206, 74)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(333, 59)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(348, 73)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(206, 54)
        Me.LblV_Type.Tag = ""
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(348, 53)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(333, 39)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(206, 34)
        Me.LblSite_Code.Tag = ""
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(348, 33)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(510, 74)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 16)
        Me.TabControl1.Size = New System.Drawing.Size(877, 299)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Gainsboro
        Me.TP1.Controls.Add(Me.LblPaymentTypeReq)
        Me.TP1.Controls.Add(Me.LblQtyReq)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.TxtQty)
        Me.TP1.Controls.Add(Me.LblQty)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.LblRequisitionBYReq)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtAmount)
        Me.TP1.Controls.Add(Me.LblAmount)
        Me.TP1.Controls.Add(Me.TxtPaymentType)
        Me.TP1.Controls.Add(Me.LblPaymentType)
        Me.TP1.Controls.Add(Me.TxtRecurrance)
        Me.TP1.Controls.Add(Me.LblRecurrance)
        Me.TP1.Controls.Add(Me.TxtDateUpto)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtDateFrom)
        Me.TP1.Controls.Add(Me.LblFromDate)
        Me.TP1.Controls.Add(Me.TxtGeneral)
        Me.TP1.Controls.Add(Me.LblGeneral)
        Me.TP1.Controls.Add(Me.TxtVendor)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Size = New System.Drawing.Size(869, 270)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGeneral, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGeneral, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDateFrom, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDateUpto, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRecurrance, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRecurrance, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPaymentType, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPaymentType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRequisitionBYReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblQty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtQty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblQtyReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPaymentTypeReq, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 1
        '
        'TxtVendor
        '
        Me.TxtVendor.AgMandatory = False
        Me.TxtVendor.AgMasterHelp = False
        Me.TxtVendor.AgNumberLeftPlaces = 8
        Me.TxtVendor.AgNumberNegetiveAllow = False
        Me.TxtVendor.AgNumberRightPlaces = 2
        Me.TxtVendor.AgPickFromLastValue = False
        Me.TxtVendor.AgRowFilter = ""
        Me.TxtVendor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendor.AgSelectedValue = Nothing
        Me.TxtVendor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendor.Location = New System.Drawing.Point(348, 93)
        Me.TxtVendor.MaxLength = 50
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(308, 18)
        Me.TxtVendor.TabIndex = 4
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(207, 93)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(49, 16)
        Me.LblVendor.TabIndex = 708
        Me.LblVendor.Text = "Vendor"
        '
        'TxtGeneral
        '
        Me.TxtGeneral.AgMandatory = True
        Me.TxtGeneral.AgMasterHelp = False
        Me.TxtGeneral.AgNumberLeftPlaces = 8
        Me.TxtGeneral.AgNumberNegetiveAllow = False
        Me.TxtGeneral.AgNumberRightPlaces = 2
        Me.TxtGeneral.AgPickFromLastValue = False
        Me.TxtGeneral.AgRowFilter = ""
        Me.TxtGeneral.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGeneral.AgSelectedValue = Nothing
        Me.TxtGeneral.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGeneral.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGeneral.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGeneral.Location = New System.Drawing.Point(348, 113)
        Me.TxtGeneral.MaxLength = 50
        Me.TxtGeneral.Name = "TxtGeneral"
        Me.TxtGeneral.Size = New System.Drawing.Size(308, 18)
        Me.TxtGeneral.TabIndex = 5
        '
        'LblGeneral
        '
        Me.LblGeneral.AutoSize = True
        Me.LblGeneral.BackColor = System.Drawing.Color.Transparent
        Me.LblGeneral.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGeneral.Location = New System.Drawing.Point(207, 113)
        Me.LblGeneral.Name = "LblGeneral"
        Me.LblGeneral.Size = New System.Drawing.Size(122, 16)
        Me.LblGeneral.TabIndex = 710
        Me.LblGeneral.Text = "Journals / Periodical"
        '
        'TxtDateFrom
        '
        Me.TxtDateFrom.AgMandatory = True
        Me.TxtDateFrom.AgMasterHelp = False
        Me.TxtDateFrom.AgNumberLeftPlaces = 8
        Me.TxtDateFrom.AgNumberNegetiveAllow = False
        Me.TxtDateFrom.AgNumberRightPlaces = 2
        Me.TxtDateFrom.AgPickFromLastValue = False
        Me.TxtDateFrom.AgRowFilter = ""
        Me.TxtDateFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDateFrom.AgSelectedValue = Nothing
        Me.TxtDateFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDateFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDateFrom.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDateFrom.Location = New System.Drawing.Point(348, 133)
        Me.TxtDateFrom.MaxLength = 50
        Me.TxtDateFrom.Name = "TxtDateFrom"
        Me.TxtDateFrom.Size = New System.Drawing.Size(100, 18)
        Me.TxtDateFrom.TabIndex = 6
        '
        'LblFromDate
        '
        Me.LblFromDate.AutoSize = True
        Me.LblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.LblFromDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromDate.Location = New System.Drawing.Point(207, 133)
        Me.LblFromDate.Name = "LblFromDate"
        Me.LblFromDate.Size = New System.Drawing.Size(114, 16)
        Me.LblFromDate.TabIndex = 712
        Me.LblFromDate.Text = "Subscription From"
        '
        'TxtDateUpto
        '
        Me.TxtDateUpto.AgMandatory = False
        Me.TxtDateUpto.AgMasterHelp = False
        Me.TxtDateUpto.AgNumberLeftPlaces = 8
        Me.TxtDateUpto.AgNumberNegetiveAllow = False
        Me.TxtDateUpto.AgNumberRightPlaces = 2
        Me.TxtDateUpto.AgPickFromLastValue = False
        Me.TxtDateUpto.AgRowFilter = ""
        Me.TxtDateUpto.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDateUpto.AgSelectedValue = Nothing
        Me.TxtDateUpto.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDateUpto.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDateUpto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDateUpto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDateUpto.Location = New System.Drawing.Point(556, 133)
        Me.TxtDateUpto.MaxLength = 50
        Me.TxtDateUpto.Name = "TxtDateUpto"
        Me.TxtDateUpto.Size = New System.Drawing.Size(100, 18)
        Me.TxtDateUpto.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(449, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 714
        Me.Label4.Text = "Subscription Upto"
        '
        'TxtRecurrance
        '
        Me.TxtRecurrance.AgMandatory = False
        Me.TxtRecurrance.AgMasterHelp = False
        Me.TxtRecurrance.AgNumberLeftPlaces = 8
        Me.TxtRecurrance.AgNumberNegetiveAllow = False
        Me.TxtRecurrance.AgNumberRightPlaces = 2
        Me.TxtRecurrance.AgPickFromLastValue = False
        Me.TxtRecurrance.AgRowFilter = ""
        Me.TxtRecurrance.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRecurrance.AgSelectedValue = Nothing
        Me.TxtRecurrance.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRecurrance.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRecurrance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRecurrance.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecurrance.Location = New System.Drawing.Point(348, 153)
        Me.TxtRecurrance.MaxLength = 50
        Me.TxtRecurrance.Name = "TxtRecurrance"
        Me.TxtRecurrance.Size = New System.Drawing.Size(100, 18)
        Me.TxtRecurrance.TabIndex = 8
        '
        'LblRecurrance
        '
        Me.LblRecurrance.AutoSize = True
        Me.LblRecurrance.BackColor = System.Drawing.Color.Transparent
        Me.LblRecurrance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecurrance.Location = New System.Drawing.Point(207, 153)
        Me.LblRecurrance.Name = "LblRecurrance"
        Me.LblRecurrance.Size = New System.Drawing.Size(74, 16)
        Me.LblRecurrance.TabIndex = 716
        Me.LblRecurrance.Text = "Recurrance"
        '
        'TxtPaymentType
        '
        Me.TxtPaymentType.AgMandatory = True
        Me.TxtPaymentType.AgMasterHelp = False
        Me.TxtPaymentType.AgNumberLeftPlaces = 8
        Me.TxtPaymentType.AgNumberNegetiveAllow = False
        Me.TxtPaymentType.AgNumberRightPlaces = 2
        Me.TxtPaymentType.AgPickFromLastValue = False
        Me.TxtPaymentType.AgRowFilter = ""
        Me.TxtPaymentType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPaymentType.AgSelectedValue = Nothing
        Me.TxtPaymentType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPaymentType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPaymentType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPaymentType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaymentType.Location = New System.Drawing.Point(556, 153)
        Me.TxtPaymentType.MaxLength = 50
        Me.TxtPaymentType.Name = "TxtPaymentType"
        Me.TxtPaymentType.Size = New System.Drawing.Size(100, 18)
        Me.TxtPaymentType.TabIndex = 9
        '
        'LblPaymentType
        '
        Me.LblPaymentType.AutoSize = True
        Me.LblPaymentType.BackColor = System.Drawing.Color.Transparent
        Me.LblPaymentType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaymentType.Location = New System.Drawing.Point(451, 155)
        Me.LblPaymentType.Name = "LblPaymentType"
        Me.LblPaymentType.Size = New System.Drawing.Size(92, 16)
        Me.LblPaymentType.TabIndex = 718
        Me.LblPaymentType.Text = "Payment Type"
        '
        'TxtAmount
        '
        Me.TxtAmount.AgMandatory = False
        Me.TxtAmount.AgMasterHelp = False
        Me.TxtAmount.AgNumberLeftPlaces = 8
        Me.TxtAmount.AgNumberNegetiveAllow = False
        Me.TxtAmount.AgNumberRightPlaces = 2
        Me.TxtAmount.AgPickFromLastValue = False
        Me.TxtAmount.AgRowFilter = ""
        Me.TxtAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAmount.AgSelectedValue = Nothing
        Me.TxtAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Location = New System.Drawing.Point(556, 173)
        Me.TxtAmount.MaxLength = 8
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(100, 18)
        Me.TxtAmount.TabIndex = 11
        '
        'LblAmount
        '
        Me.LblAmount.AutoSize = True
        Me.LblAmount.BackColor = System.Drawing.Color.Transparent
        Me.LblAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmount.Location = New System.Drawing.Point(451, 174)
        Me.LblAmount.Name = "LblAmount"
        Me.LblAmount.Size = New System.Drawing.Size(53, 16)
        Me.LblAmount.TabIndex = 720
        Me.LblAmount.Text = "Amount"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 8
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 2
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(348, 193)
        Me.TxtRemarks.MaxLength = 50
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(308, 45)
        Me.TxtRemarks.TabIndex = 12
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.BackColor = System.Drawing.Color.Transparent
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(207, 195)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(60, 16)
        Me.LblRemark.TabIndex = 722
        Me.LblRemark.Text = "Remarks"
        '
        'LblRequisitionBYReq
        '
        Me.LblRequisitionBYReq.AutoSize = True
        Me.LblRequisitionBYReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblRequisitionBYReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblRequisitionBYReq.Location = New System.Drawing.Point(333, 100)
        Me.LblRequisitionBYReq.Name = "LblRequisitionBYReq"
        Me.LblRequisitionBYReq.Size = New System.Drawing.Size(10, 7)
        Me.LblRequisitionBYReq.TabIndex = 733
        Me.LblRequisitionBYReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(333, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 734
        Me.Label1.Text = "Ä"
        '
        'TxtQty
        '
        Me.TxtQty.AgMandatory = True
        Me.TxtQty.AgMasterHelp = False
        Me.TxtQty.AgNumberLeftPlaces = 5
        Me.TxtQty.AgNumberNegetiveAllow = False
        Me.TxtQty.AgNumberRightPlaces = 0
        Me.TxtQty.AgPickFromLastValue = False
        Me.TxtQty.AgRowFilter = ""
        Me.TxtQty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtQty.AgSelectedValue = Nothing
        Me.TxtQty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtQty.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtQty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtQty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(348, 173)
        Me.TxtQty.MaxLength = 8
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(100, 18)
        Me.TxtQty.TabIndex = 10
        '
        'LblQty
        '
        Me.LblQty.AutoSize = True
        Me.LblQty.BackColor = System.Drawing.Color.Transparent
        Me.LblQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQty.Location = New System.Drawing.Point(207, 174)
        Me.LblQty.Name = "LblQty"
        Me.LblQty.Size = New System.Drawing.Size(57, 16)
        Me.LblQty.TabIndex = 736
        Me.LblQty.Text = "Quantity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(333, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 737
        Me.Label3.Text = "Ä"
        '
        'LblQtyReq
        '
        Me.LblQtyReq.AutoSize = True
        Me.LblQtyReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblQtyReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblQtyReq.Location = New System.Drawing.Point(333, 181)
        Me.LblQtyReq.Name = "LblQtyReq"
        Me.LblQtyReq.Size = New System.Drawing.Size(10, 7)
        Me.LblQtyReq.TabIndex = 738
        Me.LblQtyReq.Text = "Ä"
        '
        'LblPaymentTypeReq
        '
        Me.LblPaymentTypeReq.AutoSize = True
        Me.LblPaymentTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPaymentTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPaymentTypeReq.Location = New System.Drawing.Point(542, 160)
        Me.LblPaymentTypeReq.Name = "LblPaymentTypeReq"
        Me.LblPaymentTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPaymentTypeReq.TabIndex = 739
        Me.LblPaymentTypeReq.Text = "Ä"
        '
        'FrmGeneralSubscription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 366)
        Me.Name = "FrmGeneralSubscription"
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

    Private Sub FrmGeneralSubscription_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        If TxtPaymentType.Text = "Prepaid" Then
            AccountPosting(mInternalCode, Conn, Cmd)
        End If
    End Sub
    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
    Private Sub FrmGeneralSubscription_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If AgL.RequiredField(TxtVendor, LblVendor.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtGeneral, LblGeneral.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtDateFrom, LblFromDate.Text) Then passed = False : Exit Sub
        'If AgL.RequiredField(TxtQty, LblQty.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtPaymentType, LblPaymentType.Text) Then passed = False : Exit Sub

        If Val(TxtQty.Text) = 0 Then MsgBox("Qty Is Required Field") : TxtQty.Focus() : passed = False : Exit Sub

        If TxtDateFrom.Text <> "" And TxtDateUpto.Text <> "" Then
            If CDate(TxtDateFrom.Text) > CDate(TxtDateUpto.Text) Then
                MsgBox("Subscription From can not greater than Subscription Upto !")
                passed = False : Exit Sub
                TxtDateFrom.Focus()
            End If
        End If
    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT R.UID as SearchCode, R.DocId, Vt.Description AS [Entry Type], " & _
                            " R.V_Date AS [Entry Date], R.V_No AS [Entry No], V.Name AS [Vendor Name],  " & _
                            " I.Description as [General / Periodical], R.FromDate as [Subscription From], R.ToDate as [Subscription Upto], R.Qty, R.Amount, R.PaymentType, R.Remarks  " & _
                            " FROM Lib_Subscription_Log R " & _
                            " LEFT JOIN Voucher_Type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup V ON R.Vendor = V.SubCode " & _
                            " LEFT JOIN Item I ON R.General = I.Code " & _
                            " Where R.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"

    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.DocID, Vt.Description AS [Entry Type], R.V_Date AS [Entry Date], " & _
                            " R.V_No AS [Entry No], V.Name AS [Vendor Name], I.Description as [General / Periodical], R.FromDate as [Subscription From], R.Todate as [Subscription Upto], R.Qty, R.Amount, R.PaymentType, R.Remarks " & _
                            " FROM Subscription R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup V ON R.Vendor = V.SubCode " & _
                            " LEFT JOIN Item I ON R.General = I.Code " & _
                            " Where 1=1 " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"

    End Sub


    Private Sub FrmGeneralSubscription_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_Subscription"
        LogTableName = "Lib_Subscription_Log"
    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE dbo.Lib_Subscription_Log " & _
                "SET " & _
                "Vendor = " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                "General = " & AgL.Chk_Text(TxtGeneral.AgSelectedValue) & ", " & _
                "FromDate = " & AgL.Chk_Text(TxtDateFrom.Text) & ", " & _
                "ToDate = " & AgL.Chk_Text(TxtDateUpto.Text) & ", " & _
                "Recurrance = " & AgL.Chk_Text(TxtRecurrance.Text) & ", " & _
                "PaymentType = " & AgL.Chk_Text(TxtPaymentType.AgSelectedValue) & ", " & _
                "Qty = " & Val(TxtQty.Text) & ", " & _
                "Amount = " & Val(TxtAmount.Text) & ", " & _
                "Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                "Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtRecurrance.Enabled = False
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList

        mQry = " SELECT V.SubCode, S.Name, isnull(S.IsDeleted,0) AS IsDeleted, S.Div_Code , " & _
               " isnull(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
               " FROM Vendor V " & _
               " LEFT JOIN SubGroup S ON v.SubCode = S.SubCode " & _
               " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "S.Site_Code", AgL.PubSiteCode, "S.CommonAc") & " " & _
               " ORDER BY Name "
        TxtVendor.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT G.Code, I.Description, S.Description AS Subject, G.Recurrance, " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
                " FROM Lib_Generals G  " & _
                " LEFT JOIN Item I ON G.Code =I.Code  " & _
                " LEFT JOIN Lib_Subject S ON G.Subject = S.Code"
        TxtGeneral.AgHelpDataSet(4, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = " SELECT '" & ClsMain.Recurrance.Daily & "' AS Code ,'" & ClsMain.Recurrance.Daily & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Weekly & "' AS Code ,'" & ClsMain.Recurrance.Weekly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Fortnightly & "' AS Code ,'" & ClsMain.Recurrance.Fortnightly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Monthly & "' AS Code ,'" & ClsMain.Recurrance.Monthly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Bimonthly & "' AS Code ,'" & ClsMain.Recurrance.Bimonthly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Quarterly & "' AS Code ,'" & ClsMain.Recurrance.Quarterly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.HalfYearly & "' AS Code ,'" & ClsMain.Recurrance.HalfYearly & "' AS Recurrance " & _
                " Union ALL " & _
                " SELECT '" & ClsMain.Recurrance.Annually & "' AS Code ,'" & ClsMain.Recurrance.Annually & "' AS Recurrance " 
        TxtRecurrance.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select 'PrePaid' as Code, 'Prepaid' as Name " & _
             "Union All " & _
             "Select 'Postpaid' as Code, 'Postpaid' as Name "
        TxtPaymentType.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
               " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select R.DocID As SearchCode " & _
            " From Lib_Subscription R " & _
            " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
            " Where IsNull(R.IsDeleted,0) = 0  " & mCondStr & "  Order By R.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGeneral.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtGeneral.Name
                    Validating_MemberCard(TxtGeneral.AgSelectedValue)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_MemberCard(ByVal Code As String)
        Dim DrTemp As DataRow() = Nothing
        If TxtGeneral.Text <> "" Then
            DrTemp = TxtGeneral.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
            If DrTemp.Length > 0 Then
                TxtRecurrance.Text = AgL.XNull(DrTemp(0)("Recurrance"))
            Else
                TxtRecurrance.Text = ""

            End If
        End If
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select R.UID As SearchCode " & _
               " From Lib_Subscription_Log R " & _
               " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
               " Where R.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By R.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DtTemp As DataTable

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * From Lib_Subscription Where DocID = '" & SearchCode & "'"
        Else
            mQry = "Select * From Lib_Subscription_Log Where UId = '" & SearchCode & "'"
        End If
        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        With DtTemp
            If .Rows.Count > 0 Then
                TxtVendor.AgSelectedValue = AgL.XNull(.Rows(0)("Vendor"))
                TxtGeneral.AgSelectedValue = AgL.XNull(.Rows(0)("General"))
                TxtRecurrance.Text = AgL.XNull(.Rows(0)("Recurrance"))
                TxtPaymentType.AgSelectedValue = AgL.XNull(.Rows(0)("PaymentType"))
                TxtDateFrom.Text = AgL.XNull(.Rows(0)("FromDate"))
                TxtDateUpto.Text = AgL.XNull(.Rows(0)("ToDate"))
                TxtQty.Text = AgL.VNull(.Rows(0)("Qty"))
                TxtAmount.Text = AgL.VNull(.Rows(0)("Amount"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
            End If
        End With
    End Sub

    Private Sub FrmGeneralSubscription_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.BringToFront()
        AgL.WinSetting(Me, 400, 885, 0, 0)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVendor.Enter, TxtGeneral.Enter
        Try
            Select Case sender.name

                Case TxtVendor.Name, TxtGeneral.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Function AccountPosting(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand) As Boolean
        'Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        'Dim PurchaseAC = AgL.XNull(DtLib_Enviro.Rows(0)("PurchaseAC"))
        'Dim I As Integer
        'Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        'Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))

        'mNarr = "Being " & TxtGeneral.Text & " is Subscribed From Date " & TxtDateFrom.Text
        'If TxtDateUpto.Text <> "" Then
        '    mNarr += " Upto Date " + TxtDateUpto.Text
        'End If


        'I = 0
        'ReDim Preserve LedgAry(I)
        'LedgAry(I).SubCode = PurchaseAC
        'LedgAry(I).ContraSub = TxtVendor.AgSelectedValue
        'LedgAry(I).AmtDr = Val(TxtAmount.Text)
        'LedgAry(I).AmtCr = 0
        'LedgAry(I).Narration = mNarr

        'I = I + 1
        'ReDim Preserve LedgAry(I)
        'LedgAry(I).SubCode = TxtVendor.AgSelectedValue
        'LedgAry(I).ContraSub = PurchaseAC
        'LedgAry(I).AmtDr = 0
        'LedgAry(I).AmtCr = Val(TxtAmount.Text)
        'LedgAry(I).Narration = mNarr


        'If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)


        'If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, Conn, Cmd, SearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mNarr, , AgL.Gcn_ConnectionString) = False Then
        '    AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        'End If

    End Function

End Class
