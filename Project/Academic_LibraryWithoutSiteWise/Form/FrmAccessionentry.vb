Imports CrystalDecisions.CrystalReports.Engine
Public Class frmaccessionentry
    Inherits AgTemplate.TempTransaction
    Public mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Book"
    Protected Const Col1BtnNewBook As String = "New Book"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"
    Protected Const Col1Series As String = "Series"
    Protected Const Col1Subject As String = "Subject"
    Protected Const Col1Volume As String = "Volume"
    Protected Const Col1Language As String = "Language"
    Protected Const Col1ISBN As String = "ISBN"
    Protected Const Col1Edition As String = "Edition"
    Protected Const Col1PublicationYear As String = "Publication Year"
    Protected Const Col1Pages As String = "Pages"
    Protected Const Col1Mrp As String = "MRP"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1WithCd As String = "With Cd"
    Protected Const Col1Godown As String = "Almira"
    Protected Const Col1GodownSection As String = "Shelf"
    Protected Const Col1Place As String = "Place"
    Protected Const Col1Remarks As String = "Remark"
    Protected Const Col1CdItemCode As String = "CdItemCode"
    Protected Const Col1AccessionNoPrefix As String = "Accession No Prefix"
    Protected Const Col1AccessionNo_Sr As String = "AccessionNo_Sr"
    Protected Const Col1AccessionNoSufix As String = "Accession No Sufix"
    Protected Const Col1BookIdPrefix As String = "Book Id Prefix"
    Protected Const Col1BookID_Sr As String = "BookID_Sr"
    Protected Const Col1BookIdSufix As String = "Book Id Sufix"
    Protected Const Col1ChallanDocId As String = "ChallanDocId"
    Protected Const Col1CallNo As String = "Call No."

    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2AccessionNo As String = "Accession No."
    Protected Const Col2Book_UID As String = "Book ID"
    Protected Const Col2Item As String = "Book"
    Protected Const Col2Writer As String = "Writer"
    Protected Const Col2Publisher As String = "Publisher"
    Protected Const Col2Series As String = "Series"
    Protected Const Col2Subject As String = "Subject"
    Protected Const Col2Volume As String = "Volume"
    Protected Const Col2Language As String = "Language"
    Protected Const Col2ISBN As String = "ISBN"
    Protected Const Col2Edition As String = "Edition"
    Protected Const Col2PublicationYear As String = "Publication Year"
    Protected Const Col2Pages As String = "Pages"
    Protected Const Col2Mrp As String = "MRP"
    Protected Const Col2Rate As String = "Rate"
    Protected Const Col2WithCd As String = "With Cd"
    Protected Const Col2Godown As String = "Almira"
    Protected Const Col2GodownSection As String = "Shelf"
    Protected Const Col2RefAccessionNo As String = "RefAccessionNo"
    Protected Const Col2Place As String = "Place"
    Protected Const Col2Remarks As String = "Remark"
    Protected Const Col2CdItemCode As String = "CdItemCode"
    Protected Const Col2AccessionNoPrefix As String = "AccessionNoPrefix"
    Protected Const Col2AccessionNo_Sr As String = "AccessionNo_Sr"
    Protected Const Col2AccessionNoSufix As String = "AccessionNoSufix"
    Protected Const Col2BookIDPrefix As String = "BookIDPrefix"
    Protected Const Col2BookID_Sr As String = "BookID_Sr"
    Protected Const Col2BookIDSufix As String = "BookIDSufix"
    Protected Const Col2CallNo As String = "Call No."



    Public WithEvents Dgl3 As New AgControls.AgDataGrid
    Protected Const Col3AccessionNo As String = "Accession No."
    Protected Const Col3Book_UID As String = "Book ID"
    Protected Const Col3Item As String = "CD"
    Protected Const Col3Writer As String = "Writer"
    Protected Const Col3Publisher As String = "Publisher"
    Protected Const Col3Series As String = "Series"
    Protected Const Col3Subject As String = "Subject"
    Protected Const Col3Volume As String = "Volume"
    Protected Const Col3Language As String = "Language"
    Protected Const Col3ISBN As String = "ISBN"
    Protected Const Col3Edition As String = "Edition"
    Protected Const Col3PublicationYear As String = "Publication Year"
    Protected Const Col3Pages As String = "Pages"
    Protected Const Col3Mrp As String = "MRP"
    Protected Const Col3Rate As String = "Rate"
    Protected Const Col3WithCd As String = "With Cd"
    Protected Const Col3Godown As String = "Almira"
    Protected Const Col3GodownSection As String = "Shelf"
    Protected Const Col3RefAccessionNo As String = "Ref Accession No"
    Protected Const Col3Place As String = "Place"
    Protected Const Col3Remarks As String = "Remark"
    Protected Const Col3AccessionNoPrefix As String = "AccessionNoPrefix"
    Protected Const Col3AccessionNo_Sr As String = "AccessionNo_Sr"
    Protected Const Col3AccessionNoSufix As String = "AccessionNoSufix"
    Protected Const Col3BookIDPrefix As String = "BookIDPrefix"
    Protected Const Col3BookID_Sr As String = "BookID_Sr"
    Protected Const Col3BookIDSufix As String = "BookIDSufix"
    Protected Const Col3CallNo As String = "Call No."

    Dim mBookUidSufix$ = "", mAccessionPrefix$ = ""
    Protected WithEvents BtnFillPendingGeneralsForAccession As System.Windows.Forms.Button
    Friend WithEvents BtnPrintBarcode As System.Windows.Forms.Button
    Public WithEvents GBoxImportFromExcel As System.Windows.Forms.GroupBox
    Public WithEvents BtnImprtFromExcel As System.Windows.Forms.Button
    Public mOkButtonPressed As Boolean
    Public mBlnImprtFromExcelFlag As Boolean = False

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.Accession
    End Sub


#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmaccessionentry))
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtBookReceiveNo = New AgControls.AgTextBox
        Me.LblReciptNo = New System.Windows.Forms.Label
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.Pnl3 = New System.Windows.Forms.Panel
        Me.TxtTransactionBY = New AgControls.AgTextBox
        Me.LblTransactionBY = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.Tc = New System.Windows.Forms.TabControl
        Me.TpBook = New System.Windows.Forms.TabPage
        Me.TpCd = New System.Windows.Forms.TabPage
        Me.BtnPrintBarcode = New System.Windows.Forms.Button
        Me.BtnFillPendingGeneralsForAccession = New System.Windows.Forms.Button
        Me.GBoxImportFromExcel = New System.Windows.Forms.GroupBox
        Me.BtnImprtFromExcel = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tc.SuspendLayout()
        Me.TpBook.SuspendLayout()
        Me.TpCd.SuspendLayout()
        Me.GBoxImportFromExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(549, 585)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(29, 19)
        Me.TxtStatus.Tag = ""
        '
        'CmdStatus
        '
        Me.CmdStatus.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(596, 585)
        Me.GBoxMoveToLog.Size = New System.Drawing.Size(148, 40)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 19)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 585)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(29, 19)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Size = New System.Drawing.Size(26, 19)
        '
        'CmdApprove
        '
        Me.CmdApprove.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(195, 585)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 585)
        Me.GrpUP.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 581)
        Me.GroupBox1.Size = New System.Drawing.Size(897, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(375, 585)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
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
        Me.LblV_No.Location = New System.Drawing.Point(4, 52)
        Me.LblV_No.Tag = ""
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(107, 51)
        Me.TxtV_No.Size = New System.Drawing.Size(291, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(291, 16)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(192, 12)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(148, 38)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(307, 11)
        Me.TxtV_Date.Size = New System.Drawing.Size(91, 18)
        Me.TxtV_Date.TabIndex = 1
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(4, 33)
        Me.LblV_Type.Tag = ""
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(107, 31)
        Me.TxtV_Type.Size = New System.Drawing.Size(291, 18)
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(91, 18)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(4, 13)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(107, 11)
        Me.TxtSite_Code.Size = New System.Drawing.Size(92, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(13, 0)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 19)
        Me.TabControl1.Size = New System.Drawing.Size(886, 104)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtTransactionBY)
        Me.TP1.Controls.Add(Me.LblTransactionBY)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtBookReceiveNo)
        Me.TP1.Controls.Add(Me.LblReciptNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(878, 78)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReciptNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBookReceiveNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTransactionBY, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTransactionBY, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(879, 41)
        Me.Topctrl1.TabIndex = 3
        '
        'Dgl1
        '
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'TxtBookReceiveNo
        '
        Me.TxtBookReceiveNo.AgMandatory = False
        Me.TxtBookReceiveNo.AgMasterHelp = False
        Me.TxtBookReceiveNo.AgNumberLeftPlaces = 8
        Me.TxtBookReceiveNo.AgNumberNegetiveAllow = False
        Me.TxtBookReceiveNo.AgNumberRightPlaces = 2
        Me.TxtBookReceiveNo.AgPickFromLastValue = False
        Me.TxtBookReceiveNo.AgRowFilter = ""
        Me.TxtBookReceiveNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookReceiveNo.AgSelectedValue = Nothing
        Me.TxtBookReceiveNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookReceiveNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookReceiveNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBookReceiveNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookReceiveNo.Location = New System.Drawing.Point(558, 8)
        Me.TxtBookReceiveNo.MaxLength = 50
        Me.TxtBookReceiveNo.Name = "TxtBookReceiveNo"
        Me.TxtBookReceiveNo.Size = New System.Drawing.Size(291, 18)
        Me.TxtBookReceiveNo.TabIndex = 4
        '
        'LblReciptNo
        '
        Me.LblReciptNo.AutoSize = True
        Me.LblReciptNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReciptNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReciptNo.Location = New System.Drawing.Point(455, 9)
        Me.LblReciptNo.Name = "LblReciptNo"
        Me.LblReciptNo.Size = New System.Drawing.Size(77, 16)
        Me.LblReciptNo.TabIndex = 706
        Me.LblReciptNo.Text = "Receive No."
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl2.Location = New System.Drawing.Point(1, 8)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(852, 204)
        Me.Pnl2.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(455, 49)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(558, 48)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(291, 18)
        Me.TxtRemarks.TabIndex = 6
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(10, 148)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(859, 172)
        Me.Pnl1.TabIndex = 1
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(10, 128)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(106, 19)
        Me.LinkLabel2.TabIndex = 804
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "For Books"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl3
        '
        Me.Pnl3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl3.Location = New System.Drawing.Point(1, 8)
        Me.Pnl3.Name = "Pnl3"
        Me.Pnl3.Size = New System.Drawing.Size(852, 204)
        Me.Pnl3.TabIndex = 804
        '
        'TxtTransactionBY
        '
        Me.TxtTransactionBY.AgMandatory = False
        Me.TxtTransactionBY.AgMasterHelp = False
        Me.TxtTransactionBY.AgNumberLeftPlaces = 0
        Me.TxtTransactionBY.AgNumberNegetiveAllow = False
        Me.TxtTransactionBY.AgNumberRightPlaces = 0
        Me.TxtTransactionBY.AgPickFromLastValue = False
        Me.TxtTransactionBY.AgRowFilter = ""
        Me.TxtTransactionBY.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransactionBY.AgSelectedValue = Nothing
        Me.TxtTransactionBY.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransactionBY.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransactionBY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransactionBY.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransactionBY.Location = New System.Drawing.Point(558, 28)
        Me.TxtTransactionBY.MaxLength = 255
        Me.TxtTransactionBY.Name = "TxtTransactionBY"
        Me.TxtTransactionBY.Size = New System.Drawing.Size(291, 18)
        Me.TxtTransactionBY.TabIndex = 5
        '
        'LblTransactionBY
        '
        Me.LblTransactionBY.AutoSize = True
        Me.LblTransactionBY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransactionBY.Location = New System.Drawing.Point(455, 29)
        Me.LblTransactionBY.Name = "LblTransactionBY"
        Me.LblTransactionBY.Size = New System.Drawing.Size(95, 16)
        Me.LblTransactionBY.TabIndex = 806
        Me.LblTransactionBY.Text = "Transaction By"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(804, 327)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(60, 21)
        Me.BtnFill.TabIndex = 806
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'Tc
        '
        Me.Tc.Controls.Add(Me.TpBook)
        Me.Tc.Controls.Add(Me.TpCd)
        Me.Tc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tc.Location = New System.Drawing.Point(2, 330)
        Me.Tc.Name = "Tc"
        Me.Tc.SelectedIndex = 0
        Me.Tc.Size = New System.Drawing.Size(864, 246)
        Me.Tc.TabIndex = 2
        '
        'TpBook
        '
        Me.TpBook.Controls.Add(Me.Pnl2)
        Me.TpBook.Location = New System.Drawing.Point(4, 22)
        Me.TpBook.Name = "TpBook"
        Me.TpBook.Padding = New System.Windows.Forms.Padding(3)
        Me.TpBook.Size = New System.Drawing.Size(856, 220)
        Me.TpBook.TabIndex = 0
        Me.TpBook.Text = "Accession No. For Books"
        Me.TpBook.UseVisualStyleBackColor = True
        '
        'TpCd
        '
        Me.TpCd.Controls.Add(Me.Pnl3)
        Me.TpCd.Location = New System.Drawing.Point(4, 22)
        Me.TpCd.Name = "TpCd"
        Me.TpCd.Padding = New System.Windows.Forms.Padding(3)
        Me.TpCd.Size = New System.Drawing.Size(856, 220)
        Me.TpCd.TabIndex = 1
        Me.TpCd.Text = "Accession No. For CD's"
        Me.TpCd.UseVisualStyleBackColor = True
        '
        'BtnPrintBarcode
        '
        Me.BtnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrintBarcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintBarcode.Image = Global.Academic_Library.My.Resources.Resources.MYPrint
        Me.BtnPrintBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrintBarcode.Location = New System.Drawing.Point(774, 126)
        Me.BtnPrintBarcode.Name = "BtnPrintBarcode"
        Me.BtnPrintBarcode.Size = New System.Drawing.Size(90, 21)
        Me.BtnPrintBarcode.TabIndex = 807
        Me.BtnPrintBarcode.Text = "Barcode"
        Me.BtnPrintBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrintBarcode.UseVisualStyleBackColor = True
        '
        'BtnFillPendingGeneralsForAccession
        '
        Me.BtnFillPendingGeneralsForAccession.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillPendingGeneralsForAccession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillPendingGeneralsForAccession.Location = New System.Drawing.Point(505, 126)
        Me.BtnFillPendingGeneralsForAccession.Name = "BtnFillPendingGeneralsForAccession"
        Me.BtnFillPendingGeneralsForAccession.Size = New System.Drawing.Size(251, 21)
        Me.BtnFillPendingGeneralsForAccession.TabIndex = 807
        Me.BtnFillPendingGeneralsForAccession.Text = "Fill Pending Generals For Accession"
        Me.BtnFillPendingGeneralsForAccession.UseVisualStyleBackColor = True
        '
        'GBoxImportFromExcel
        '
        Me.GBoxImportFromExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxImportFromExcel.BackColor = System.Drawing.Color.Transparent
        Me.GBoxImportFromExcel.Controls.Add(Me.BtnImprtFromExcel)
        Me.GBoxImportFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxImportFromExcel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxImportFromExcel.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxImportFromExcel.Location = New System.Drawing.Point(762, 585)
        Me.GBoxImportFromExcel.Name = "GBoxImportFromExcel"
        Me.GBoxImportFromExcel.Size = New System.Drawing.Size(110, 40)
        Me.GBoxImportFromExcel.TabIndex = 903
        Me.GBoxImportFromExcel.TabStop = False
        Me.GBoxImportFromExcel.Tag = "UP"
        Me.GBoxImportFromExcel.Text = "Import From Excel"
        '
        'BtnImprtFromExcel
        '
        Me.BtnImprtFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprtFromExcel.Image = CType(resources.GetObject("BtnImprtFromExcel.Image"), System.Drawing.Image)
        Me.BtnImprtFromExcel.Location = New System.Drawing.Point(71, 16)
        Me.BtnImprtFromExcel.Name = "BtnImprtFromExcel"
        Me.BtnImprtFromExcel.Size = New System.Drawing.Size(24, 19)
        Me.BtnImprtFromExcel.TabIndex = 669
        Me.BtnImprtFromExcel.TabStop = False
        Me.BtnImprtFromExcel.UseVisualStyleBackColor = True
        '
        'frmaccessionentry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(879, 626)
        Me.Controls.Add(Me.GBoxImportFromExcel)
        Me.Controls.Add(Me.BtnFillPendingGeneralsForAccession)
        Me.Controls.Add(Me.BtnPrintBarcode)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.Tc)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "frmaccessionentry"
        Me.Text = "Accession Entry"
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
        Me.Controls.SetChildIndex(Me.Tc, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.Controls.SetChildIndex(Me.BtnPrintBarcode, 0)
        Me.Controls.SetChildIndex(Me.BtnFillPendingGeneralsForAccession, 0)
        Me.Controls.SetChildIndex(Me.GBoxImportFromExcel, 0)
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
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tc.ResumeLayout(False)
        Me.TpBook.ResumeLayout(False)
        Me.TpCd.ResumeLayout(False)
        Me.GBoxImportFromExcel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TxtBookReceiveNo As AgControls.AgTextBox
    Protected WithEvents LblReciptNo As System.Windows.Forms.Label
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Protected WithEvents Pnl3 As System.Windows.Forms.Panel
    Protected WithEvents TxtTransactionBY As AgControls.AgTextBox
    Protected WithEvents LblTransactionBY As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents Tc As System.Windows.Forms.TabControl
    Protected WithEvents TpBook As System.Windows.Forms.TabPage
    Protected WithEvents TpCd As System.Windows.Forms.TabPage
#End Region

    Private Sub TempLib_Accession_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_Accession"
        LogTableName = "Lib_Accession_Log"
        MainLineTableCsv = "Lib_AccessionDetail,Lib_AccessionHead,Stock"
        LogLineTableCsv = "Lib_AccessionDetail_Log,Lib_AccessionHead_Log,Stock_Log"
        AgL.GridDesign(Dgl1)
        AgL.GridDesign(Dgl2)
        AgL.GridDesign(Dgl3)
    End Sub

    Private Sub FrmTempLib_Accession_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
               " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select H.DocID As SearchCode " & _
                " From Lib_Accession H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr & "  Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempLib_Accession_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select H.UID As SearchCode " & _
               " From Lib_Accession_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where H.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By H.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempLib_Accession_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocID, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], " & _
                            " H.V_No AS [Entry No] " & _
                            " FROM Lib_Accession H " & _
                            " LEFT JOIN Voucher_type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmTempLib_Accession_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.UID as SearchCode, H.DocId, Vt.Description AS [Entry Type], " & _
                            " H.V_Date AS [Entry Date], H.V_No AS [Entry No]" & _
                            " FROM Lib_Accession_Log H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmTempLib_Accession_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 35, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 150, 20, Col1Item, True, False, False)
            .AddAgButtonColumn(Dgl1, Col1BtnNewBook, 30, " ", True, False, , , , "Webdings", 10, "6")
            .AddAgNumberColumn(Dgl1, Col1Qty, 60, 8, 0, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Writer, 150, 20, Col1Writer, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Publisher, 150, 20, Col1Publisher, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Series, 50, 20, Col1Series, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Subject, 70, 20, Col1Subject, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Volume, 70, 20, Col1Volume, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Language, 70, 20, Col1Language, True, False, False)
            .AddAgTextColumn(Dgl1, Col1ISBN, 70, 20, Col1ISBN, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Edition, 70, 20, Col1Edition, True, False, False)
            .AddAgTextColumn(Dgl1, Col1PublicationYear, 110, 50, Col1PublicationYear, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1Pages, 50, 8, 0, False, Col1Pages, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Mrp, 60, 8, 3, False, Col1Mrp, Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR"), False, True)
            .AddAgTextColumn(Dgl1, Col1Rate, 50, 0, Col1Rate, True, False)
            .AddAgListColumn(Dgl1, "Yes,No", Col1WithCd, 60, , Col1WithCd, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Godown, 150, 20, Col1Godown, True, False, False)
            .AddAgTextColumn(Dgl1, Col1GodownSection, 110, 20, Col1GodownSection, Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR"), False, False)
            .AddAgTextColumn(Dgl1, Col1Place, 100, 100, Col1Place, True, False, False)
            .AddAgTextColumn(Dgl1, Col1CallNo, 100, 35, Col1CallNo, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Remarks, 200, 255, Col1Remarks, True, False, False)
            .AddAgTextColumn(Dgl1, Col1CdItemCode, 50, 20, Col1CdItemCode, False, False, False)
            .AddAgTextColumn(Dgl1, Col1AccessionNoPrefix, 130, 20, Col1AccessionNoPrefix, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1AccessionNo_Sr, 105, 8, 0, False, Col1AccessionNo_Sr, True)
            .AddAgTextColumn(Dgl1, Col1AccessionNoSufix, 120, 20, Col1AccessionNoSufix, True, False, False)
            .AddAgTextColumn(Dgl1, Col1BookIdPrefix, 120, 20, Col1BookIdPrefix, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1BookID_Sr, 100, 8, 0, False, Col1BookID_Sr, True)
            .AddAgTextColumn(Dgl1, Col1BookIdSufix, 120, 20, Col1BookIdSufix, True, False, False)
            .AddAgTextColumn(Dgl1, Col1ChallanDocId, 120, 20, Col1ChallanDocId, True, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.Anchor = AnchorStyles.None
        Dgl1.ColumnHeadersHeight = 25

        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 35, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2AccessionNo, 100, 20, Col2AccessionNo, True, False, False)
            .AddAgTextColumn(Dgl2, Col2Book_UID, 100, 20, Col2Book_UID, True, False, False)
            .AddAgTextColumn(Dgl2, Col2Item, 150, 20, Col2Item, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Writer, 150, 20, Col2Writer, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Publisher, 150, 20, Col2Publisher, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Series, 50, 20, Col2Series, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Subject, 100, 20, Col2Subject, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Volume, 70, 20, Col2Volume, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Language, 80, 20, Col2Language, True, True, False)
            .AddAgTextColumn(Dgl2, Col2ISBN, 80, 20, Col2ISBN, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Edition, 80, 20, Col2Edition, True, True, False)
            .AddAgTextColumn(Dgl2, Col2PublicationYear, 110, 50, Col2PublicationYear, True, True, False)
            .AddAgNumberColumn(Dgl2, Col2Pages, 50, 8, 0, False, Col2Pages, True, True, True)
            .AddAgNumberColumn(Dgl2, Col2Mrp, 60, 8, 3, False, Col2Mrp, Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR"), True, True)
            .AddAgNumberColumn(Dgl2, Col2Rate, 60, 8, 3, False, Col2Rate, True, True, True)
            .AddAgListColumn(Dgl2, "Yes,No", Col2WithCd, 60, , Col2WithCd, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Godown, 100, 20, Col2Godown, True, True, False)
            .AddAgTextColumn(Dgl2, Col2GodownSection, 110, 20, Col2GodownSection, Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR"), True, False)
            .AddAgTextColumn(Dgl2, Col2RefAccessionNo, 100, 20, Col2RefAccessionNo, False, True, False)
            .AddAgTextColumn(Dgl2, Col2Place, 100, 20, Col2Place, True, True, False)
            .AddAgTextColumn(Dgl2, Col2CallNo, 100, 35, Col2CallNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Remarks, 200, 20, Col2Remarks, True, False, False)
            .AddAgTextColumn(Dgl2, Col2CdItemCode, 50, 20, Col2CdItemCode, False, False, False)
            .AddAgTextColumn(Dgl2, Col2AccessionNoPrefix, 200, 20, Col2AccessionNoPrefix, False, False, False)
            .AddAgNumberColumn(Dgl2, Col2AccessionNo_Sr, 60, 8, 0, False, Col2AccessionNo_Sr, False)
            .AddAgTextColumn(Dgl2, Col2AccessionNoSufix, 200, 20, Col2AccessionNoSufix, False, False, False)
            .AddAgTextColumn(Dgl2, Col2BookIDPrefix, 200, 20, Col2BookIDPrefix, False, False, False)
            .AddAgNumberColumn(Dgl2, Col2BookID_Sr, 60, 8, 0, False, Col2BookID_Sr, False)
            .AddAgTextColumn(Dgl2, Col2BookIDSufix, 200, 20, Col2BookIDSufix, False, False, False)


        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.Anchor = AnchorStyles.None
        Dgl2.ColumnHeadersHeight = 25
        Dgl2.AllowUserToAddRows = False

        Dgl3.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl3, ColSNo, 35, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl3, Col3AccessionNo, 100, 20, Col3AccessionNo, True, False, False)
            .AddAgTextColumn(Dgl3, Col3Book_UID, 100, 20, Col3Book_UID, True, False, False)
            .AddAgTextColumn(Dgl3, Col3Item, 150, 20, Col3Item, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Writer, 150, 20, Col3Writer, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Publisher, 150, 20, Col3Publisher, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Series, 50, 20, Col3Series, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Subject, 100, 20, Col3Subject, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Volume, 70, 20, Col3Volume, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Language, 80, 20, Col3Language, True, True, False)
            .AddAgTextColumn(Dgl3, Col3ISBN, 80, 20, Col3ISBN, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Edition, 80, 20, Col3Edition, True, True, False)
            .AddAgTextColumn(Dgl3, Col3PublicationYear, 110, 50, Col3PublicationYear, True, True, False)
            .AddAgNumberColumn(Dgl3, Col3Pages, 50, 8, 0, False, Col3Pages, True, True, True)
            .AddAgNumberColumn(Dgl3, Col3Mrp, 60, 8, 3, False, Col3Mrp, Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR"), True, True)
            .AddAgNumberColumn(Dgl3, Col3Rate, 60, 8, 3, False, Col3Rate, True, True, True)
            .AddAgListColumn(Dgl3, "Yes,No", Col3WithCd, 60, , Col3WithCd, False, True, False)
            .AddAgTextColumn(Dgl3, Col3Godown, 100, 20, Col3Godown, True, True, False)
            .AddAgTextColumn(Dgl3, Col3GodownSection, 110, 20, Col3GodownSection, Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR"), True, False)
            .AddAgTextColumn(Dgl3, Col3RefAccessionNo, 120, 20, Col3RefAccessionNo, True, False, False)
            .AddAgTextColumn(Dgl3, Col3Place, 100, 20, Col3Place, True, True, False)
            .AddAgTextColumn(Dgl3, Col3CallNo, 100, 35, Col3CallNo, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Remarks, 200, 20, Col3Remarks, True, False, False)
            .AddAgTextColumn(Dgl3, Col3AccessionNoPrefix, 200, 20, Col3AccessionNoPrefix, False, False, False)
            .AddAgNumberColumn(Dgl3, Col3AccessionNo_Sr, 60, 8, 0, False, Col3AccessionNo_Sr, False)
            .AddAgTextColumn(Dgl3, Col3AccessionNoSufix, 200, 20, Col3AccessionNoSufix, False, False, False)
            .AddAgTextColumn(Dgl3, Col3BookIDPrefix, 200, 20, Col3BookIDPrefix, False, False, False)
            .AddAgNumberColumn(Dgl3, Col3BookID_Sr, 60, 8, 0, False, Col3BookID_Sr, False)
            .AddAgTextColumn(Dgl3, Col3BookIDSufix, 200, 20, Col3BookIDSufix, False, False, False)
        End With
        AgL.AddAgDataGrid(Dgl3, Pnl3)
        Dgl3.EnableHeadersVisualStyles = False
        Dgl3.ColumnHeadersHeight = 35
        Dgl3.Anchor = AnchorStyles.None
        Dgl3.ColumnHeadersHeight = 25
        Dgl3.AllowUserToAddRows = False

        Call ProcAdjustGrid()
        Dgl1.AllowUserToOrderColumns = True
        Dgl2.AllowUserToOrderColumns = True
        Dgl3.AllowUserToOrderColumns = True

    End Sub

        Private Sub FrmTempLib_Accession_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        GridSetiingWriteXml(Me.Text & "_" & AgL.PubUserName & "_" & "DGL1", Dgl1)
        GridSetiingWriteXml(Me.Text & "_" & AgL.PubUserName & "_" & "DGL2", Dgl2)
        GridSetiingWriteXml(Me.Text & "_" & AgL.PubUserName & "_" & "DGL3", Dgl3)

        mQry = " UPDATE Lib_Accession_Log " & _
                " SET " & _
                " ReceiptNo = " & AgL.Chk_Text(TxtBookReceiveNo.AgSelectedValue) & " , " & _
                " TransactionBy = " & AgL.Chk_Text(TxtTransactionBY.AgSelectedValue) & " , " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Lib_AccessionHead_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Lib_AccessionDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1
                    mQry = "INSERT INTO Lib_AccessionHead_Log(UID, DocId, Sr, Book, Qty, Writer, Publisher,Series, " & _
                            " Subject, Volume, Language, " & _
                            " ISBN,	Edition, PublicationYear, Pages,	MRP, Rate, WithCD, Godown, " & _
                            " GodownSection, Remarks, ChallanDocId, Place, CallNo) " & _
                            " VALUES(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ",	" & _
                            " " & Val(.Item(Col1Qty, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Writer, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Publisher, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Series, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Subject, I)) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Volume, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Language, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1ISBN, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Edition, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1PublicationYear, I).Value) & ",	" & _
                            " " & Val(.Item(Col1Pages, I).Value) & ",	" & _
                            " " & Val(.Item(Col1Mrp, I).Value) & ",	" & _
                            " " & Val(.Item(Col1Rate, I).Value) & ",	" & _
                            " " & Val(IIf(AgL.StrCmp(.Item(Col1WithCd, I).Value, "No"), 0, 1)) & ",	" & _
                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Godown, I)) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1GodownSection, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(.Item(Col1Remarks, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1ChallanDocId, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1Place, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1CallNo, I).Value) & " " & _
                            " ) "

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    Call ProcPostInBookMaster(Conn, Cmd, I)

                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With


                    With Dgl2
                        For I = 0 To .RowCount - 1
                            If .Item(Col2Item, I).Value <> "" Then
                                mSr += 1
                                mQry = "INSERT INTO Lib_AccessionDetail_Log	(UID, DocId, Sr, AccessionNo, Book_UID, Book, " & _
                                        " Writer, Publisher, Series, Subject, Volume, Language, " & _
                                        " ISBN,	Edition, PublicationYear, Pages, MRP, Rate, WithCD, Godown, GodownSection, " & _
                                        " RefAccessionNo, Remarks, AccessionNoPrefix, AccessionNo_Sr, " & _
                                        " AccessionNoSufix, BookIDPrefix, BookID_Sr, BookIDSufix,IsInStock, Place, CallNo) " & _
                                        " VALUES(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                                        " " & mSr & ", " & AgL.Chk_Text(.Item(Col2AccessionNo, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.Item(Col2Book_UID, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Writer, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Publisher, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Series, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col2Subject, I)) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Volume, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Language, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2ISBN, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Edition, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2PublicationYear, I).Value) & ",	" & _
                                        " " & Val(.Item(Col2Pages, I).Value) & ",	" & _
                                        " " & Val(.Item(Col2Mrp, I).Value) & ",	" & _
                                        " " & Val(.Item(Col2Rate, I).Value) & ",	" & _
                                        " " & Val(IIf(AgL.StrCmp(.Item(Col2WithCd, I).Value, "No"), 0, 1)) & ",	" & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col2Godown, I)) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2GodownSection, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2RefAccessionNo, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2Remarks, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.Item(Col2AccessionNoPrefix, I).Value) & ",	" & _
                                        " " & Val(.Item(Col2AccessionNo_Sr, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2AccessionNoSufix, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2BookIDPrefix, I).Value) & ",	" & _
                                        " " & Val(.Item(Col2BookID_Sr, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col2BookIDSufix, I).Value) & ",1, " & _
                                        " " & AgL.Chk_Text(.Item(Col2Place, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.Item(Col2CallNo, I).Value) & " " & _
                                        " )"

                                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                                mQry = " update lib_enviro set LastAccssionNo=" & Val(.Item(Col3AccessionNo_Sr, I).Value) & " "

                                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                            End If
                        Next
                    End With

                    With Dgl3
                        For I = 0 To .RowCount - 1
                            If .Item(Col3Item, I).Value <> "" Then
                                mSr += 1
                                mQry = "INSERT INTO Lib_AccessionDetail_Log	(UID, DocId, Sr, AccessionNo, Book_UID, Book, " & _
                                        " Writer, Publisher, Series, Subject, Volume, Language, " & _
                                        " ISBN,	Edition, PublicationYear, Pages, MRP, Rate, WithCD, Godown, GodownSection, " & _
                                        " RefAccessionNo, Remarks, AccessionNoPrefix, AccessionNo_Sr, " & _
                                        " AccessionNoSufix, BookIDPrefix, BookID_Sr, BookIDSufix,IsInStock, Place, CallNo) " & _
                                        " VALUES(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                                        " " & mSr & ", " & AgL.Chk_Text(.Item(Col3AccessionNo, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.Item(Col3Book_UID, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Writer, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Publisher, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Series, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col3Subject, I)) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Volume, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Language, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3ISBN, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Edition, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3PublicationYear, I).Value) & ",	" & _
                                        " " & Val(.Item(Col3Pages, I).Value) & ",	" & _
                                        " " & Val(.Item(Col3Mrp, I).Value) & ",	" & _
                                        " " & Val(.Item(Col3Rate, I).Value) & ",	" & _
                                        " " & Val(IIf(AgL.StrCmp(.Item(Col3WithCd, I).Value, "No"), 0, 1)) & ",	" & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col3Godown, I)) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3GodownSection, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3RefAccessionNo, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3Remarks, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.Item(Col3AccessionNoPrefix, I).Value) & ",	" & _
                                        " " & Val(.Item(Col3AccessionNo_Sr, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3AccessionNoSufix, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3BookIDPrefix, I).Value) & ",	" & _
                                        " " & Val(.Item(Col3BookID_Sr, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3BookIDSufix, I).Value) & ", 1, " & _
                                        " " & AgL.Chk_Text(.Item(Col3Place, I).Value) & ",	" & _
                                        " " & AgL.Chk_Text(.Item(Col3CallNo, I).Value) & " " & _
                                        " )"

                                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)



                                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                            End If
                        Next
                    End With
                    Call ProcPostStock(Conn, Cmd)
    End Sub

    Private Sub FrmTempLib_Accession_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From Lib_Accession H " & _
                " Where H.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From Lib_Accession_Log H " & _
                " Where H.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtBookReceiveNo.AgSelectedValue = AgL.XNull(.Rows(0)("ReceiptNo"))
                TxtTransactionBY.AgSelectedValue = AgL.XNull(.Rows(0)("TransactionBY"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select H.*, B.CD_ItemCode from Lib_AccessionHead H " & _
                            " LEFT JOIN Lib_Book B On H.Book = B.Code " & _
                            " Where H.DocId = '" & SearchCode & "' " & _
                            " Order By H.Sr"
                Else
                    mQry = "Select H.*, B.CD_ItemCode from Lib_AccessionHead_Log H " & _
                            " LEFT JOIN Lib_Book B On H.Book = B.Code " & _
                            " Where H.UID = '" & SearchCode & "' " & _
                            " Order By H.Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Book"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.XNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                            Dgl1.Item(Col1Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                            Dgl1.Item(Col1Series, I).Value = AgL.XNull(.Rows(I)("Series"))
                            Dgl1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            Dgl1.Item(Col1Volume, I).Value = AgL.XNull(.Rows(I)("Volume"))
                            Dgl1.Item(Col1Language, I).Value = AgL.XNull(.Rows(I)("Language"))
                            Dgl1.Item(Col1ISBN, I).Value = AgL.XNull(.Rows(I)("ISBN"))
                            Dgl1.Item(Col1Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                            Dgl1.Item(Col1PublicationYear, I).Value = AgL.XNull(.Rows(I)("PublicationYear"))
                            Dgl1.Item(Col1Pages, I).Value = AgL.XNull(.Rows(I)("Pages"))
                            Dgl1.Item(Col1Mrp, I).Value = AgL.XNull(.Rows(I)("MRP"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.XNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1WithCd, I).Value = IIf(AgL.VNull(.Rows(I)("WithCD")) = 0, "No", "Yes")
                            Dgl1.AgSelectedValue(Col1Godown, I) = AgL.XNull(.Rows(I)("Godown"))
                            Dgl1.Item(Col1GodownSection, I).Value = AgL.XNull(.Rows(I)("GodownSection"))
                            Dgl1.Item(Col1Remarks, I).Value = AgL.XNull(.Rows(I)("Remarks"))
                            Dgl1.Item(Col1CdItemCode, I).Value = AgL.XNull(.Rows(I)("CD_ItemCode"))
                            Dgl1.Item(Col1ChallanDocId, I).Value = AgL.XNull(.Rows(I)("ChallanDocId"))
                            Dgl1.Item(Col1Place, I).Value = AgL.XNull(.Rows(I)("Place"))
                            Dgl1.Item(Col1CallNo, I).Value = AgL.XNull(.Rows(I)("CallNo"))
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select Ad.* from Lib_AccessionDetail Ad " & _
                            " LEFT JOIN Item I On Ad.Book = I.Code " & _
                            " Where Ad.DocId = '" & SearchCode & "'" & _
                            " And I.ItemType <> '" & ClsMain.ItemType.CD & "' " & _
                            " Order By Ad.Sr"
                Else
                    mQry = "Select Ad.* from Lib_AccessionDetail_Log Ad " & _
                            " LEFT JOIN Item I On Ad.Book = I.Code " & _
                            " Where Ad.UID = '" & SearchCode & "' " & _
                            " And I.ItemType <> '" & ClsMain.ItemType.CD & "' " & _
                            " Order By Ad.Sr "
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl2.RowCount = 1
                    Dgl2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl2.Rows.Add()
                            Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                            Dgl2.Item(Col2AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                            Dgl2.Item(Col2Book_UID, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                            Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(I)("Book"))
                            Dgl2.Item(Col2Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                            Dgl2.Item(Col2Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                            Dgl2.Item(Col2Series, I).Value = AgL.XNull(.Rows(I)("Series"))
                            Dgl2.AgSelectedValue(Col2Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            Dgl2.Item(Col2Volume, I).Value = AgL.XNull(.Rows(I)("Volume"))
                            Dgl2.Item(Col2Language, I).Value = AgL.XNull(.Rows(I)("Language"))
                            Dgl2.Item(Col2ISBN, I).Value = AgL.XNull(.Rows(I)("ISBN"))
                            Dgl2.Item(Col2Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                            Dgl2.Item(Col2PublicationYear, I).Value = AgL.XNull(.Rows(I)("PublicationYear"))
                            Dgl2.Item(Col2Pages, I).Value = AgL.XNull(.Rows(I)("Pages"))
                            Dgl2.Item(Col2Mrp, I).Value = AgL.XNull(.Rows(I)("MRP"))
                            Dgl2.Item(Col2Rate, I).Value = AgL.XNull(.Rows(I)("Rate"))
                            Dgl2.Item(Col2WithCd, I).Value = IIf(AgL.VNull(.Rows(I)("WithCD")) = 0, "No", "Yes")
                            Dgl2.AgSelectedValue(Col2Godown, I) = AgL.XNull(.Rows(I)("Godown"))
                            Dgl2.Item(Col2GodownSection, I).Value = AgL.XNull(.Rows(I)("GodownSection"))
                            Dgl2.Item(Col2RefAccessionNo, I).Value = AgL.XNull(.Rows(I)("RefAccessionNo"))
                            Dgl2.Item(Col2Place, I).Value = AgL.XNull(.Rows(I)("Place"))
                            Dgl2.Item(Col2CallNo, I).Value = AgL.XNull(.Rows(I)("CallNo"))
                            Dgl2.Item(Col2Remarks, I).Value = AgL.XNull(.Rows(I)("Remarks"))

                            Dgl2.Item(Col2AccessionNoPrefix, I).Value = AgL.XNull(.Rows(I)("AccessionNoPrefix"))
                            Dgl2.Item(Col2AccessionNo_Sr, I).Value = AgL.XNull(.Rows(I)("AccessionNo_Sr"))
                            Dgl2.Item(Col2AccessionNoSufix, I).Value = AgL.XNull(.Rows(I)("AccessionNoSufix"))
                            Dgl2.Item(Col2BookIDPrefix, I).Value = AgL.XNull(.Rows(I)("BookIDPrefix"))
                            Dgl2.Item(Col2BookID_Sr, I).Value = AgL.XNull(.Rows(I)("BookID_Sr"))
                            Dgl2.Item(Col2BookIDSufix, I).Value = AgL.XNull(.Rows(I)("BookIDSufix"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select Ad.* from Lib_AccessionDetail Ad " & _
                            " LEFT JOIN Item I On Ad.Book = I.Code " & _
                            " Where Ad.DocId = '" & SearchCode & "'" & _
                            " And I.ItemType = '" & ClsMain.ItemType.CD & "' " & _
                            " Order By Ad.Sr "
                Else
                    mQry = "Select Ad.* from Lib_AccessionDetail_log Ad " & _
                            " LEFT JOIN Item I On Ad.Book = I.Code " & _
                            " Where Ad.UID = '" & SearchCode & "'" & _
                            " And I.ItemType = '" & ClsMain.ItemType.CD & "' " & _
                            " Order By Ad.Sr "
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl3.RowCount = 1
                    Dgl3.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl3.Rows.Add()
                            Dgl3.Item(ColSNo, I).Value = Dgl3.Rows.Count
                            Dgl3.Item(Col3AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                            Dgl3.Item(Col3Book_UID, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                            Dgl3.AgSelectedValue(Col3Item, I) = AgL.XNull(.Rows(I)("Book"))
                            Dgl3.Item(Col3Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                            Dgl3.Item(Col3Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                            Dgl3.Item(Col3Series, I).Value = AgL.XNull(.Rows(I)("Series"))
                            Dgl3.AgSelectedValue(Col3Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            Dgl3.Item(Col3Volume, I).Value = AgL.XNull(.Rows(I)("Volume"))
                            Dgl3.Item(Col3Language, I).Value = AgL.XNull(.Rows(I)("Language"))
                            Dgl3.Item(Col3ISBN, I).Value = AgL.XNull(.Rows(I)("ISBN"))
                            Dgl3.Item(Col3Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                            Dgl3.Item(Col3PublicationYear, I).Value = AgL.XNull(.Rows(I)("PublicationYear"))
                            Dgl3.Item(Col3Pages, I).Value = AgL.XNull(.Rows(I)("Pages"))
                            Dgl3.Item(Col3Mrp, I).Value = AgL.XNull(.Rows(I)("MRP"))
                            Dgl3.Item(Col3Rate, I).Value = AgL.XNull(.Rows(I)("Rate"))
                            Dgl3.Item(Col3WithCd, I).Value = IIf(AgL.VNull(.Rows(I)("WithCD")) = 0, "No", "Yes")
                            Dgl3.AgSelectedValue(Col3Godown, I) = AgL.XNull(.Rows(I)("Godown"))
                            Dgl3.Item(Col3GodownSection, I).Value = AgL.XNull(.Rows(I)("GodownSection"))
                            Dgl3.Item(Col3RefAccessionNo, I).Value = AgL.XNull(.Rows(I)("RefAccessionNo"))
                            Dgl3.Item(Col3Place, I).Value = AgL.XNull(.Rows(I)("Place"))
                            Dgl3.Item(Col3CallNo, I).Value = AgL.XNull(.Rows(I)("CallNo"))
                            Dgl3.Item(Col3Remarks, I).Value = AgL.XNull(.Rows(I)("Remarks"))

                            Dgl3.Item(Col3AccessionNoPrefix, I).Value = AgL.XNull(.Rows(I)("AccessionNoPrefix"))
                            Dgl3.Item(Col3AccessionNo_Sr, I).Value = AgL.XNull(.Rows(I)("AccessionNo_Sr"))
                            Dgl3.Item(Col3AccessionNoSufix, I).Value = AgL.XNull(.Rows(I)("AccessionNoSufix"))
                            Dgl3.Item(Col3BookIDPrefix, I).Value = AgL.XNull(.Rows(I)("BookIDPrefix"))
                            Dgl3.Item(Col3BookID_Sr, I).Value = AgL.XNull(.Rows(I)("BookID_Sr"))
                            Dgl3.Item(Col3BookIDSufix, I).Value = AgL.XNull(.Rows(I)("BookIDSufix"))


                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmTempLib_Accession_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        Topctrl1.ChangeAgGridState(Dgl2, False)
        Topctrl1.ChangeAgGridState(Dgl3, False)
        AgL.WinSetting(Me, 658, 885, 0, 0)
        GridSetiingShowXml(Me.Text & "_" & AgL.PubUserName & "_" & "DGL1", Dgl1)
        GridSetiingShowXml(Me.Text & "_" & AgL.PubUserName & "_" & "DGL2", Dgl2)
        GridSetiingShowXml(Me.Text & "_" & AgL.PubUserName & "_" & "DGL3", Dgl3)

    End Sub

    Private Sub FrmTempLib_Accession_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList

        mQry = "SELECT I.Code, I.Description , B.Writer, B.Publisher, S.Description As SubjectName, I.Unit, " & _
                " I.DisplayName, I.ItemType, I.SalesTaxPostingGroup , " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                " B.Series, B.Subject, B.Volume, B.Language, B.ISBN, " & _
                " B.WithCD, B.GodownCD, B.GodownSectionCD, " & _
                " ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " I.Measure, i.MeasureUnit, B.Writer, B.Publisher, B.Series, B.WithCD, " & _
                " S.Prefix, B.CD_ItemCode As CdItemCode,B.rate,b.PlaceOfPub,b.PubYear,b.pages, " & _
                " B.BookType As BookTypeCode, Bt.Description AS BookTypeDesc " & _
                " FROM Item I " & _
                " LEFT JOIN Lib_Book B ON I.Code = B.Code " & _
                " LEFT JOIN Lib_Subject S On B.Subject  = S.Code " & _
                " Left Join Lib_BookType Bt On Bt.Code = B.BookType"

            Dgl1.AgHelpDataSet(Col1Item, 25) = AgL.FillData(mQry, AgL.GCn)
        Dgl2.AgHelpDataSet(Col2Item, 25) = AgL.FillData(mQry, AgL.GCn)
        Dgl3.AgHelpDataSet(Col3Item, 25) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.Docid As Code, C.V_Type + '-' + Convert(Nvarchar, C.V_no), Vt.NCat," & _
                " IsNull(C.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " IsNull(C.IsDeleted ,0) AS IsDeleted, C.Div_Code, V1.PendingQty  " & _
                " FROM PurchChallan C " & _
                " LEFT JOIN Voucher_Type Vt On C.V_Type = Vt.V_Type " & _
                " LEFT JOIN ( " & _
                " SELECT Cd.DocId, IsNull(Sum(Cd.Qty),0) - IsNull(Sum(Cd.AccessionQty),0) AS PendingQty  " & _
                " FROM PurchChallanDetail Cd " & _
                " GROUP BY Cd.DocId " & _
                " ) AS V1 ON C.DocId = V1.DocId	"
        TxtBookReceiveNo.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select Sg.SubCode As Code, Sg.DispName As Name, " & _
                " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " IsNull(Sg.IsDeleted ,0) AS IsDeleted " & _
                " From Pay_Employee E " & _
                " LEFT JOIN SubGroup Sg On E.SubCode = Sg.SubCode "
        TxtTransactionBY.AgHelpDataSet(2, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT G.Code AS Code, G.Description AS Godown, IsNull(G.IsDeleted,0) AS IsDeleted," & _
                " G.Div_Code, IsNull(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status " & _
                " FROM Godown G "
        Dgl1.AgHelpDataSet(Col1Godown, 3) = AgL.FillData(mQry, AgL.GCn)
        Dgl2.AgHelpDataSet(Col2Godown, 3) = Dgl1.AgHelpDataSet(Col1Godown, 8)
        Dgl3.AgHelpDataSet(Col3Godown, 3) = Dgl1.AgHelpDataSet(Col1Godown, 8)

        mQry = " SELECT GS.Section AS Code,GS.Section AS Shelf,GS.Code AS AlmiraCode " & _
                " FROM GodownSection GS " & _
                " ORDER BY GS.Section  "
        Dgl1.AgHelpDataSet(Col1GodownSection, 1) = AgL.FillData(mQry, AgL.GCn)
        Dgl2.AgHelpDataSet(Col2GodownSection, 1) = Dgl1.AgHelpDataSet(Col1GodownSection, 1)
        Dgl3.AgHelpDataSet(Col3GodownSection, 1) = Dgl1.AgHelpDataSet(Col1GodownSection, 1)

        mQry = " SELECT S.Code AS Code, S.Description AS Subject, S.Prefix, " & _
                " IsNull(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " IsNull(S.IsDeleted ,0) AS IsDeleted " & _
                " FROM Lib_Subject S "
        Dgl1.AgHelpDataSet(Col1Subject, 3) = AgL.FillData(mQry, AgL.GCn)
        Dgl2.AgHelpDataSet(Col2Subject, 3) = Dgl1.AgHelpDataSet(Col1Subject, 8)
        Dgl3.AgHelpDataSet(Col3Subject, 3) = Dgl1.AgHelpDataSet(Col1Subject, 8)

        mQry = " SELECT DISTINCT  L.Edition AS Code, L.Edition FROM Lib_AccessionDetail L WHERE L.Edition IS NOT NULL "
        Dgl1.AgHelpDataSet(Col1Edition, , , , , True) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Distinct L.Place AS Code, L.Place  FROM Lib_AccessionHead L WHERE L.Place IS NOT NULL "
        Dgl1.AgHelpDataSet(Col1Place, , , , , True) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Dgl1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellContentClick
        Dim FrmObj As Form = Nothing
        Dim bColumnIndex As Integer = 0
        Dim bRowIndex As Integer = 0
        Dim I As Integer = 0
        Try
            bColumnIndex = Dgl1.CurrentCell.ColumnIndex
            bRowIndex = Dgl1.CurrentCell.RowIndex

            Select Case Dgl1.Columns(e.ColumnIndex).Name
                Case Col1BtnNewBook
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        Call ProcCreateNewBook(bRowIndex)
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEndEdit
        'Try
        '    If Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then Exit Sub
        '    Select Case e.ColumnIndex
        '        Case Dgl1.Columns(Col1Remarks).Index
        '            SendKeys.Send("{DOWN}")
        '            SendKeys.Send("{HOME}")
        '            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
        '                Call ProcFillBookAccessionNo()
        '                Call ProcFillCdAccessionNo()
        '            ElseIf AgL.StrCmp(Topctrl1.Mode, "Edit") Then
        '                Call ProcUpdateBookAccession()
        '                Call ProcUpdateCdAccession()
        '            Else
        '                Exit Sub
        '            End If
        '    End Select
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

            Case Col1Godown
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Godown).Index) = " IsDeleted = 0 And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

            Case Col1Subject
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Subject).Index) = " IsDeleted = 0 And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

            Case Col1GodownSection
                Dgl1.AgRowFilter(Dgl1.Columns(Col1GodownSection).Index) = " AlmiraCode = '" & Dgl1.AgSelectedValue(Col1Godown, Dgl1.CurrentCell.RowIndex) & "' "

            Case ColSNo
                SendKeys.Send("{Tab}")

        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl2.RowsAdded, Dgl3.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmTempLib_Accession_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0, J As Integer = 0, K As Integer

        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1Item).Index & Dgl1.Columns(Col1Volume).Index) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        'If AgCL.AgIsBlankGrid(Dgl2, Dgl2.Columns(Col2Item).Index) Then passed = False : Exit Sub
        If Dgl2.Rows.Count = 0 Then MsgBox("No Records In Accession Detail...!", MsgBoxStyle.Information) : passed = False : Exit Sub

        If AgCL.AgIsDuplicate(Dgl2, Dgl2.Columns(Col2Book_UID).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl3, Dgl3.Columns(Col3Book_UID).Index) Then passed = False : Exit Sub

      
        ''******************************************
        mQry = " Select isnull(IsAutoBookID,0) From Lib_Enviro "
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) Then
            If MsgBox("Do You Want To Update Current Book ID No.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    With Dgl1
                    For I = 0 To .RowCount - 1
                        Dgl1.Item(Col1BookID_Sr, I).Value = FunRetMaxAccessionNo(Dgl1.Item(Col1BookIdPrefix, I).Value, I)
                    Next
                End With
                With Dgl1
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col1Item, I).Value <> "" Then
                            For J = 0 To Val(.Item(Col1Qty, I).Value) - 1
                                Dgl2.Item(Col2BookID_Sr, K).Value = .Item(Col1BookIdPrefix, I).Value + (Val(.Item(Col1BookID_Sr, I).Value) + J).ToString + .Item(Col1BookIdSufix, I).Value
                                K = K + 1
                            Next
                        End If
                    Next
                End With
                J = 0
                K = 0
                With Dgl2
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col2Item, I).Value <> "" And AgL.StrCmp(.Item(Col2WithCd, I).Value, "Yes") Then
                            Dgl3.Item(Col3Book_UID, K).Value = "CD-" & .Item(Col2BookIDPrefix, I).Value + (Val(.Item(Col2BookID_Sr, I).Value)).ToString + .Item(Col2BookIDSufix, I).Value
                            K = K + 1
                            End If
                    Next
                End With
            End If
        End If
        ''******************************************


        With Dgl2
            For I = 0 To .Rows.Count - 1
                If .Item(Col2Item, I).Value <> "" Then
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.AccessionNo = '" & .Item(Col2AccessionNo, I).Value & "' "
                    Else
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.AccessionNo = '" & .Item(Col2AccessionNo, I).Value & "' And Ad.UID <> '" & mSearchCode & "' "
                    End If
                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                        MsgBox("Accession No Already Exists At Row No " & .Item(ColSNo, I).Value & "", MsgBoxStyle.Information)
                        Dgl2.CurrentCell = Dgl2.Item(Col2AccessionNo, I) : Dgl2.Focus()
                        passed = False : Exit Sub
                    End If

                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.Book_UID = '" & .Item(Col2Book_UID, I).Value & "' "
                    Else
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.Book_UID = '" & .Item(Col2Book_UID, I).Value & "' And Ad.UID <> '" & mSearchCode & "' "
                    End If

                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                        MsgBox("Book Id Already Exists At Row No " & .Item(ColSNo, I).Value & "", MsgBoxStyle.Information)
                        Dgl2.CurrentCell = Dgl2.Item(Col2Book_UID, I) : Dgl2.Focus()
                        passed = False : Exit Sub
                    End If

                    'If AgL.XNull(.Item(Col2CallNo, I).Value).ToString.Trim <> "" Then
                    '    mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE IsNull(Ad.CallNo,'') = " & AgL.Chk_Text(.Item(Col2CallNo, I).Value) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Ad.UID <> '" & mSearchCode & "' ") & "  "

                    '    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                    '        MsgBox("Call No. Already Exists At Row No " & .Item(ColSNo, I).Value & "", MsgBoxStyle.Information)
                    '        Dgl2.CurrentCell = Dgl2.Item(Col2CallNo, I) : Dgl2.Focus()
                    '        passed = False : Exit Sub
                    '    End If
                    'End If

                End If
            Next
        End With




        With Dgl3
            For I = 0 To .Rows.Count - 1
                If .Item(Col3Item, I).Value <> "" Then
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.AccessionNo = '" & .Item(Col3AccessionNo, I).Value & "' "
                    Else
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.AccessionNo = '" & .Item(Col3AccessionNo, I).Value & "' And Ad.UID <> '" & mSearchCode & "' "
                    End If

                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                        MsgBox("Accession No Already Exists At Row No " & .Item(ColSNo, I).Value & "", MsgBoxStyle.Information)
                        Dgl3.CurrentCell = Dgl3.Item(Col3AccessionNo, I) : Dgl3.Focus()
                        passed = False : Exit Sub
                    End If

                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.Book_UID = '" & .Item(Col3Book_UID, I).Value & "' "
                    Else
                        mQry = " SELECT Count(*) FROM Lib_AccessionDetail Ad WHERE Ad.Book_UID = '" & .Item(Col3Book_UID, I).Value & "' And Ad.UID <> '" & mSearchCode & "' "
                    End If

                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                        MsgBox("Book Id Already Exists At Row No " & .Item(ColSNo, I).Value & "", MsgBoxStyle.Information)
                        Dgl3.CurrentCell = Dgl3.Item(Col3Book_UID, I) : Dgl3.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : .Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FrmTempLib_Accession_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        Dgl3.RowCount = 1 : Dgl3.Rows.Clear()
        mBookUidSufix = "" : mAccessionPrefix = ""
        mBlnImprtFromExcelFlag = False
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtBookReceiveNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtBookReceiveNo.Name
                    If TxtBookReceiveNo.Text <> "" Then
                        Call ProcRetReceiptTypePrefix()
                        Call ProcFillPendingGR()

                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ProcFillPendingGR()
        Dim DtTemp As DataTable = Nothing
        Dim mConStr$ = ""
        Dim I As Integer

        Try
            If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub
            If TxtBookReceiveNo.Text <> "" Then mConStr = " Where Cd.docid=" & AgL.Chk_Text(TxtBookReceiveNo.AgSelectedValue) & " "

            mQry = "SELECT Cd.Item, Cd.Qty, Cd.Edition, Cd.DocId As ChallanDocId  " & _
                    " FROM PurchChallanDetail Cd " & mConStr
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                        Dgl1.Item(Col1ChallanDocId, I).Value = AgL.XNull(.Rows(I)("ChallanDocId"))
                        Dgl1.Item(Col1BookIdSufix, I).Value = mBookUidSufix
                        Dgl1.Item(Col1AccessionNoPrefix, I).Value = mAccessionPrefix


                        Call Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)


                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBookReceiveNo.Enter
        Try
            Select Case sender.name
                Case TxtBookReceiveNo.Name
                    TxtBookReceiveNo.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & " And PendingQty > 0 And NCat In ('" & ClsMain.Temp_NCat.GRNewBooks & "','" & ClsMain.Temp_NCat.GROldBooks & "','" & ClsMain.Temp_NCat.GRDonatedBooks & "') "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
                Dgl1.AgSelectedValue(Col1Subject, mRow) = ""
                Dgl1.Item(Col1Volume, mRow).Value = ""
                Dgl1.Item(Col1Language, mRow).Value = ""
                Dgl1.Item(Col1ISBN, mRow).Value = ""
                Dgl1.Item(Col1WithCd, mRow).Value = ""
                Dgl1.AgSelectedValue(Col1Godown, mRow) = ""
                Dgl1.Item(Col1GodownSection, mRow).Value = ""
                Dgl1.Item(Col1Series, mRow).Value = ""
                Dgl1.Item(Col1BookIdPrefix, mRow).Value = ""
                Dgl1.Item(Col1CdItemCode, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DrTemp(0)("Writer"))
                    Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DrTemp(0)("Publisher"))
                    If Dgl1.AgSelectedValue(Col1Subject, mRow) = "" Then Dgl1.AgSelectedValue(Col1Subject, mRow) = AgL.XNull(DrTemp(0)("Subject"))
                    If Dgl1.Item(Col1Volume, mRow).Value = "" Then Dgl1.Item(Col1Volume, mRow).Value = AgL.XNull(DrTemp(0)("Volume"))
                    If Dgl1.Item(Col1Language, mRow).Value = "" Then Dgl1.Item(Col1Language, mRow).Value = AgL.XNull(DrTemp(0)("Language"))
                    If Dgl1.Item(Col1ISBN, mRow).Value = "" Then Dgl1.Item(Col1ISBN, mRow).Value = AgL.XNull(DrTemp(0)("ISBN"))
                    If Dgl1.Item(Col1WithCd, mRow).Value = "" Then Dgl1.Item(Col1WithCd, mRow).Value = IIf(AgL.VNull(DrTemp(0)("WithCD")) = 0, "No", "Yes")
                    If Dgl1.AgSelectedValue(Col1Godown, mRow) = "" Then Dgl1.AgSelectedValue(Col1Godown, mRow) = AgL.XNull(DrTemp(0)("GodownCD"))
                    If Dgl1.Item(Col1GodownSection, mRow).Value = "" Then Dgl1.Item(Col1GodownSection, mRow).Value = AgL.XNull(DrTemp(0)("GodownSectionCD"))
                    If Dgl1.Item(Col1Series, mRow).Value = "" Then Dgl1.Item(Col1Series, mRow).Value = AgL.XNull(DrTemp(0)("Series"))
                    Dgl1.Item(Col1CdItemCode, mRow).Value = AgL.XNull(DrTemp(0)("CdItemCode"))
                    Dgl1.Item(Col1BookIdPrefix, mRow).Value = AgL.XNull(DrTemp(0)("Prefix"))
                    Dgl1.Item(Col1BookID_Sr, mRow).Value = FunRetMaxBookUid(Dgl1.Item(Col1BookIdPrefix, mRow).Value, mRow)



                    'Dgl1.Item(Col1Place, mRow).Value = AgL.XNull(DrTemp(0)("PlaceOfPub"))
                    'Dgl1.Item(Col1PublicationYear, mRow).Value = AgL.XNull(DrTemp(0)("PubYear"))
                    'Dgl1.Item(Col1Pages, mRow).Value = AgL.VNull(DrTemp(0)("pages"))
                    'Dgl1.Item(Col1Rate, mRow).Value.Text = AgL.VNull(DrTemp(0)("Rate"))

                    If Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then
                        Dgl1.Item(Col1AccessionNo_Sr, mRow).Value = FunRetMaxAccessionNo(Dgl1.Item(Col1AccessionNoPrefix, mRow).Value, mRow)
                    Else
                        If Val(Dgl1.Item(Col1AccessionNo_Sr, mRow).Value) = 0 Then Dgl1.Item(Col1AccessionNo_Sr, mRow).Value = FunPDMAccessionNo(mRow)
                    End If
                    Call ProcGetAlmira(Dgl1.AgSelectedValue(Col1Subject, mRow), mRow)
            End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Dim FrmObj As Form = Nothing
        Dim bColumnIndex As Integer = 0
        Dim bRowIndex As Integer = 0
        Dim I As Integer = 0

        Try
            bColumnIndex = Dgl1.CurrentCell.ColumnIndex
            bRowIndex = Dgl1.CurrentCell.RowIndex


            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item, Col1AccessionNoPrefix, Col1AccessionNoSufix, Col1BookIdPrefix, Col1BookIdSufix
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)

                Case Col1Qty
                    Dgl1.Item(Col1BookID_Sr, mRowIndex).Value = FunRetMaxBookUid(Dgl1.Item(Col1BookIdPrefix, mRowIndex).Value, mRowIndex)
                    Dgl1.Item(Col1AccessionNo_Sr, mRowIndex).Value = FunRetMaxAccessionNo(Dgl1.Item(Col1AccessionNoPrefix, mRowIndex).Value, mRowIndex)

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            Call ProcFillBookAccessionNo()
            Call ProcFillCdAccessionNo()
        ElseIf AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            Call ProcUpdateBookAccession()
            Call ProcUpdateCdAccession()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmBookPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub ProcFillBookAccessionNo()
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0, bMaxBookUid As Integer = 0, bMaxAccessionNo As Integer = 0
        Try
            With Dgl1
                Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        For J = 0 To Val(.Item(Col1Qty, I).Value) - 1
                            Dgl2.Rows.Add()
                            Dgl2.Item(ColSNo, K).Value = Dgl2.Rows.Count
                            Dgl2.Item(Col2AccessionNo, K).Value = .Item(Col1AccessionNoPrefix, I).Value + (Val(.Item(Col1AccessionNo_Sr, I).Value) + J).ToString + .Item(Col1AccessionNoSufix, I).Value
                            Dgl2.Item(Col2Book_UID, K).Value = .Item(Col1BookIdPrefix, I).Value + (Val(.Item(Col1BookID_Sr, I).Value) + J).ToString + .Item(Col1BookIdSufix, I).Value
                            Dgl2.AgSelectedValue(Col2Item, K) = .AgSelectedValue(Col1Item, I)
                            Dgl2.Item(Col2Writer, K).Value = .Item(Col1Writer, I).Value
                            Dgl2.Item(Col2Publisher, K).Value = .Item(Col1Publisher, I).Value
                            Dgl2.Item(Col2Series, K).Value = .Item(Col1Series, I).Value
                            Dgl2.AgSelectedValue(Col2Subject, K) = .AgSelectedValue(Col1Subject, I)
                            Dgl2.Item(Col2Volume, K).Value = .Item(Col1Volume, I).Value
                            Dgl2.Item(Col2Language, K).Value = .Item(Col1Language, I).Value
                            Dgl2.Item(Col2ISBN, K).Value = .Item(Col1ISBN, I).Value
                            Dgl2.Item(Col2Edition, K).Value = .Item(Col1Edition, I).Value
                            Dgl2.Item(Col2PublicationYear, K).Value = .Item(Col1PublicationYear, I).Value
                            Dgl2.Item(Col2Pages, K).Value = .Item(Col1Pages, I).Value
                            Dgl2.Item(Col2Mrp, K).Value = .Item(Col1Mrp, I).Value
                            Dgl2.Item(Col2Rate, K).Value = .Item(Col1Rate, I).Value
                            Dgl2.Item(Col2WithCd, K).Value = .Item(Col1WithCd, I).Value
                            Dgl2.AgSelectedValue(Col2Godown, K) = .AgSelectedValue(Col1Godown, I)
                            Dgl2.Item(Col2GodownSection, K).Value = .Item(Col1GodownSection, I).Value
                            Dgl2.Item(Col2CdItemCode, K).Value = .Item(Col1CdItemCode, I).Value
                            Dgl2.Item(Col2BookIDPrefix, K).Value = .Item(Col1BookIdPrefix, I).Value
                            Dgl2.Item(Col2BookID_Sr, K).Value = Val(.Item(Col1BookID_Sr, I).Value) + J
                            Dgl2.Item(Col2BookIDSufix, K).Value = .Item(Col1BookIdSufix, I).Value
                            Dgl2.Item(Col2AccessionNoPrefix, K).Value = .Item(Col1AccessionNoPrefix, I).Value
                            Dgl2.Item(Col2AccessionNo_Sr, K).Value = Val(.Item(Col1AccessionNo_Sr, I).Value) + J
                            Dgl2.Item(Col2AccessionNoSufix, K).Value = .Item(Col1AccessionNoSufix, I).Value
                            Dgl2.Item(Col2Place, K).Value = .Item(Col1Place, I).Value
                            Dgl2.Item(Col2CallNo, K).Value = .Item(Col1CallNo, I).Value
                            Dgl2.Item(Col2Remarks, K).Value = .Item(Col1Remarks, I).Value
                            K = K + 1
                        Next
                    End If
                Next
            End With
            If Dgl2.Rows.Count > 0 Then
                Dgl2.CurrentCell = Dgl2(0, Dgl2.Rows.Count - 1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillCdAccessionNo()
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0, bMaxBookUid As Integer = 0, bMaxAccessionNo As Integer = 0
        Dim bPrefix$ = ""
        Dim bCdCode$ = ""
        Try
            With Dgl2
                Dgl3.RowCount = 1 : Dgl3.Rows.Clear()
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Item, I).Value <> "" And AgL.StrCmp(.Item(Col2WithCd, I).Value, "Yes") Then
                        Dgl3.Rows.Add()
                        Dgl3.Item(ColSNo, K).Value = Dgl3.Rows.Count
                        Dgl3.Item(Col3AccessionNo, K).Value = "CD-" & .Item(Col2AccessionNoPrefix, I).Value + (Val(.Item(Col2AccessionNo_Sr, I).Value)).ToString + .Item(Col2AccessionNoSufix, I).Value
                        Dgl3.Item(Col3Book_UID, K).Value = "CD-" & .Item(Col2BookIDPrefix, I).Value + (Val(.Item(Col2BookID_Sr, I).Value)).ToString + .Item(Col2BookIDSufix, I).Value
                        Dgl3.AgSelectedValue(Col3Item, K) = .Item(Col2CdItemCode, I).Value
                        Dgl3.Item(Col3Writer, K).Value = .Item(Col2Writer, I).Value
                        Dgl3.Item(Col3Publisher, K).Value = .Item(Col2Publisher, I).Value
                        Dgl3.Item(Col3Series, K).Value = .Item(Col2Series, I).Value
                        Dgl3.AgSelectedValue(Col3Subject, K) = .AgSelectedValue(Col3Subject, I)
                        Dgl3.Item(Col3Volume, K).Value = .Item(Col2Volume, I).Value
                        Dgl3.Item(Col3Language, K).Value = .Item(Col2Language, I).Value
                        Dgl3.Item(Col3ISBN, K).Value = .Item(Col2ISBN, I).Value
                        Dgl3.Item(Col3Edition, K).Value = .Item(Col2Edition, I).Value
                        Dgl3.Item(Col3PublicationYear, K).Value = .Item(Col2PublicationYear, I).Value
                        Dgl3.Item(Col3Pages, K).Value = .Item(Col2Pages, I).Value
                        Dgl3.Item(Col3Mrp, K).Value = .Item(Col2Mrp, I).Value
                        Dgl3.Item(Col3Rate, K).Value = .Item(Col2Rate, I).Value
                        Dgl3.Item(Col3WithCd, K).Value = .Item(Col2WithCd, I).Value
                        Dgl3.AgSelectedValue(Col3Godown, K) = .AgSelectedValue(Col2Godown, I)
                        Dgl3.Item(Col3GodownSection, K).Value = .Item(Col2GodownSection, I).Value
                        Dgl3.Item(Col3RefAccessionNo, K).Value = .Item(Col2AccessionNo, I).Value
                        Dgl3.Item(Col3BookIDPrefix, K).Value = .Item(Col2BookIDPrefix, I).Value
                        Dgl3.Item(Col3BookID_Sr, K).Value = Val(.Item(Col2BookID_Sr, I).Value)
                        Dgl3.Item(Col3BookIDSufix, K).Value = .Item(Col2BookIDSufix, I).Value
                        Dgl3.Item(Col3AccessionNoPrefix, K).Value = .Item(Col2AccessionNoPrefix, I).Value
                        Dgl3.Item(Col3AccessionNo_Sr, K).Value = Val(.Item(Col1AccessionNo_Sr, I).Value)
                        Dgl3.Item(Col3AccessionNoSufix, K).Value = .Item(Col2AccessionNoSufix, I).Value
                        Dgl3.Item(Col3Place, K).Value = .Item(Col2Place, I).Value
                        Dgl3.Item(Col3CallNo, K).Value = .Item(Col2CallNo, I).Value
                        Dgl3.Item(Col3Remarks, K).Value = .Item(Col2Remarks, I).Value
                        K = K + 1
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunRetMaxAccessionNo(ByVal bPrefix As String, ByVal ItemRowIndex As Integer) As Long
        Dim I As Integer = 0
        Try
            With Dgl1
                For I = 0 To ItemRowIndex - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        If AgL.StrCmp(.Item(Col1AccessionNoPrefix, I).Value, bPrefix) Then
                            FunRetMaxAccessionNo = Val(.Item(Col1Qty, I).Value) + Val(.Item(Col1AccessionNo_Sr, I).Value)
                        End If
                    End If
                Next
            End With

            If FunRetMaxAccessionNo = 0 Then
                mQry = " Select IsNull(Max(AccessionNo_Sr),0) + 1 " & _
                        " From Lib_AccessionDetail Ad With (NoLock) " & _
                        " LEFT JOIN Item I With (NoLock) On Ad.Book = I.Code " & _
                        " WHERE IsNull(Ad.AccessionNoPrefix,'') = '" & bPrefix & "' "
                FunRetMaxAccessionNo = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunPDMAccessionNo(ByVal ItemRowIndex As Integer) As Long
        Dim I As Integer = 0
        Try
            With Dgl1
                For I = 0 To ItemRowIndex - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        '   If AgL.StrCmp(.Item(Col1AccessionNoPrefix, I).Value, bPrefix) Then
                        FunPDMAccessionNo = Val(.Item(Col1Qty, I).Value) + Val(.Item(Col1AccessionNo_Sr, I).Value)
                        'End If
                    End If
                Next
            End With

            If FunPDMAccessionNo = 0 Then
                mQry = " Select IsNull(LastAccssionNO,0) + 1 " & _
                        " From Lib_Enviro Ad "
                FunPDMAccessionNo = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunRetMaxBookUid(ByVal bPrefix As String, ByVal ItemRowIndex As Integer) As Long
        Dim I As Integer = 0
        Try
            With Dgl1
                For I = 0 To ItemRowIndex - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        If AgL.StrCmp(.Item(Col1BookIdPrefix, I).Value, bPrefix) Then
                            FunRetMaxBookUid = Val(.Item(Col1Qty, I).Value) + Val(.Item(Col1BookID_Sr, I).Value)
                        End If
                    End If
                Next
            End With

            If FunRetMaxBookUid = 0 Then
                mQry = " Select IsNull(Max(BookID_Sr),0) + 1 " & _
                        " From Lib_AccessionDetail Ad " & _
                        " LEFT JOIN Item I On Ad.Book = I.Code " & _
                        " WHERE IsNull(Ad.BookIDPrefix,'') = '" & bPrefix & "' "
                FunRetMaxBookUid = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ProcRetReceiptTypePrefix()
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Dim bReceiptTypeNCat$ = ""
        Try
            If TxtBookReceiveNo.AgHelpDataSet IsNot Nothing Then
                DrTemp = TxtBookReceiveNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtBookReceiveNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    bReceiptTypeNCat = AgL.XNull(DrTemp(0)("NCat"))
                    mQry = " Select BookUidSufix, AccessionNoPrefix From Lib_ReceiptTypePrefix R Where R.ReceiptType = '" & bReceiptTypeNCat & "' "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    With DtTemp
                        If .Rows.Count > 0 Then
                            mBookUidSufix = AgL.XNull(.Rows(0)("BookUidSufix"))
                            mAccessionPrefix = AgL.XNull(.Rows(0)("AccessionNoPrefix"))
                        End If
                    End With
                Else
                    mBookUidSufix = ""
                    mAccessionPrefix = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcPostStock(ByVal bConn As SqlClient.SqlConnection, ByVal bCmd As SqlClient.SqlCommand)
        mQry = " Delete From Stock_Log Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, bConn, bCmd)

        mQry = "INSERT INTO Stock_Log(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                " SubCode, Item, Godown, Qty_Rec, Unit, Remarks, Edition,  Item_UID, UID) " & _
                " SELECT Ad.DocId, Ad.Sr, A.V_Type, A.V_Prefix, A.V_Date, A.V_No, A.Div_Code, A.Site_Code, " & _
                " A.TransactionBy, Ad.Book, Ad.Godown, 1, 'Pcs', Ad.Remarks, Ad.Edition, Ad.Book_UID, A.UID " & _
                " FROM Lib_AccessionDetail Ad With (NoLock)  " & _
                " LEFT JOIN Lib_Accession A  With (NoLock) ON Ad.DocId = A.DocID " & _
                " WHERE A.UID = '" & mSearchCode & "'  "
        AgL.Dman_ExecuteNonQry(mQry, bConn, bCmd)
    End Sub

    Private Sub TempGr_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer
        '------------------------------------------------------------------------
        'Updating Goods Received Qty In Purchase Order Detail
        '-------------------------------------------------------------------------
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE PurchChallanDetail " & _
                            " SET AccessionQty = (SELECT IsNull(Sum(L.Qty),0) " & _
                            " 				    FROM Lib_AccessionHead L With (NoLock) " & _
                            "                   LEFT JOIN Lib_Accession H With (NoLock) On L.DocId = H.DocId " & _
                            " 				    WHERE H.ReceiptNo = '" & TxtBookReceiveNo.AgSelectedValue & "' " & _
                            " 				    AND L.Book = '" & .AgSelectedValue(Col1Item, I) & "'  " & _
                            "                   AND IsNull(H.IsDeleted,0) = 0), " & _
                            " AccessionDocId = '" & mInternalCode & "' " & _
                            " WHERE DocId = '" & .Item(Col1ChallanDocId, I).Value & "' " & _
                            " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                        mQry = "UPDATE PurchChallanDetail " & _
                                    " SET " & _
                                    " AccessionDocId = NULL " & _
                                    " WHERE DocId = '" & .Item(Col1ChallanDocId, I).Value & "' " & _
                                    " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If

                End If
            Next


        End With
        '-------------------------------------------------------------------------
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        Dim FrmObj As Form
        Dim DTUP As New DataTable
        Dim StrUserPermission As String = ""
        Try
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
            If e.Control Or e.Shift Or e.Alt Then Exit Sub

            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            If AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then Exit Sub

            'If Dgl1.CurrentCell.ColumnIndex = Dgl1.Columns(Col1Item).Index Then
            '    If e.KeyCode = Keys.Insert Then
            '        StrUserPermission = "AEDP"
            '        mQry = "  Select 'Status' As UP "
            '        DTUP = AgL.FillData(mQry, AgL.GCn).Tables(0)
            '        FrmObj = New FrmBookItemGenerate(StrUserPermission, DTUP)


            '        FrmObj.ShowDialog()

            '        Ini_List()
            '        Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) = CType(FrmObj, FrmBookItemGenerate).mInternalCode

            '        Validating_Item(Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex), Dgl1.CurrentCell.RowIndex)
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmaccessionentry_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then
            TxtBookReceiveNo.Enabled = False

            Dgl1.Columns(Col1Item).ReadOnly = True
            Dgl1.Columns(Col1Qty).ReadOnly = True
            Dgl1.Columns(Col1WithCd).ReadOnly = True

            Dgl2.Columns(Col2AccessionNo).ReadOnly = True
            Dgl2.Columns(Col2Book_UID).ReadOnly = True

            Dgl3.Columns(Col3AccessionNo).ReadOnly = True
            Dgl3.Columns(Col3Book_UID).ReadOnly = True
            Dgl3.Columns(Col3RefAccessionNo).ReadOnly = True

        End If

        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            BtnFillPendingGeneralsForAccession.Enabled = True
        Else
            BtnFillPendingGeneralsForAccession.Enabled = False
        End If

    End Sub

    Private Sub ProcUpdateBookAccession()
        Dim I As Integer = 0, J As Integer = 0
        Try
            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        For J = 0 To Dgl2.Rows.Count - 1
                            If .Item(Col1Item, I).Value = Dgl2.Item(Col2Item, J).Value Then
                                Dgl2.Item(Col2Series, J).Value = .Item(Col1Series, I).Value
                                Dgl2.AgSelectedValue(Col2Subject, J) = .AgSelectedValue(Col1Subject, I)
                                Dgl2.Item(Col2Volume, J).Value = .Item(Col1Volume, I).Value
                                Dgl2.Item(Col2Language, J).Value = .Item(Col1Language, I).Value
                                Dgl2.Item(Col2ISBN, J).Value = .Item(Col1ISBN, I).Value
                                Dgl2.Item(Col2Edition, J).Value = .Item(Col1Edition, I).Value
                                Dgl2.Item(Col2PublicationYear, J).Value = .Item(Col1PublicationYear, I).Value
                                Dgl2.Item(Col2Pages, J).Value = .Item(Col1Pages, I).Value
                                Dgl2.Item(Col2Mrp, J).Value = .Item(Col1Mrp, I).Value
                                Dgl2.Item(Col2Rate, J).Value = .Item(Col1Rate, I).Value
                                Dgl2.AgSelectedValue(Col2Godown, J) = .AgSelectedValue(Col1Godown, I)
                                Dgl2.Item(Col2GodownSection, J).Value = .Item(Col1GodownSection, I).Value
                                Dgl2.Item(Col2Remarks, J).Value = .Item(Col1Remarks, I).Value
                                Dgl2.Item(Col2Place, J).Value = .Item(Col1Place, I).Value
                            End If
                        Next
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcUpdateCdAccession()
        Dim I As Integer = 0, J As Integer = 0
        Try
            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        For J = 0 To Dgl3.Rows.Count - 1
                            If .Item(Col1CdItemCode, I).Value = Dgl3.AgSelectedValue(Col3Item, J) Then
                                Dgl3.Item(Col3Series, J).Value = .Item(Col1Series, I).Value
                                Dgl3.AgSelectedValue(Col3Subject, J) = .AgSelectedValue(Col1Subject, I)
                                Dgl3.Item(Col3Volume, J).Value = .Item(Col1Volume, I).Value
                                Dgl3.Item(Col3Language, J).Value = .Item(Col1Language, I).Value
                                Dgl3.Item(Col3ISBN, J).Value = .Item(Col1ISBN, I).Value
                                Dgl3.Item(Col3Edition, J).Value = .Item(Col1Edition, I).Value
                                Dgl3.Item(Col3PublicationYear, J).Value = .Item(Col1PublicationYear, I).Value
                                Dgl3.Item(Col3Pages, J).Value = .Item(Col1Pages, I).Value
                                Dgl3.Item(Col3Mrp, J).Value = .Item(Col1Mrp, I).Value
                                Dgl3.Item(Col3Rate, J).Value = .Item(Col1Rate, I).Value
                                Dgl3.AgSelectedValue(Col3Godown, J) = .AgSelectedValue(Col1Godown, I)
                                Dgl3.Item(Col3GodownSection, J).Value = .Item(Col1GodownSection, I).Value
                                Dgl3.Item(Col3Remarks, J).Value = .Item(Col1Remarks, I).Value
                                Dgl3.Item(Col3Place, J).Value = .Item(Col1Place, I).Value
                            End If
                        Next
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnBarCodeFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintBarcode.Click
        Dim ObjFrmBarCodePrint As FrmBarCodePrint
        If Topctrl1.Mode <> "Browse" Then Exit Sub
        ObjFrmBarCodePrint = New FrmBarCodePrint

        ObjFrmBarCodePrint.BarCodeDocId = mInternalCode
        ObjFrmBarCodePrint.IsPackingBarCode = True

        ObjFrmBarCodePrint.ShowDialog()
        ObjFrmBarCodePrint = Nothing
    End Sub

    Private Sub BtnFillPendingGeneralsForAccession_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillPendingGeneralsForAccession.Click
        Dim I As Integer = 0
        Dim DtTemp As DataTable = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            mQry = " SELECT Cd.Item, IsNull(Cd.Qty,0) - IsNull(Cd.AccessionQty,0) As Qty, Cd.Edition, Cd.DocId As ChallanDocId " & _
                    " FROM PurchChallanDetail Cd " & _
                    " LEFT JOIN Item I On Cd.Item = I.Code " & _
                    " LEFT JOIN Lib_Generals G On I.Code = G.Code " & _
                    " WHERE AccessionDocId Is Null " & _
                    " And IsNull(Cd.Qty,0) - IsNull(Cd.AccessionQty,0) > 0 " & _
                    " And I.ItemType = '" & ClsMain.ItemType.Generals & "' " & _
                    " And G.Recurrance <> '" & ClsMain.Recurrance.Daily & "'"

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                        Dgl1.Item(Col1ChallanDocId, I).Value = AgL.XNull(.Rows(I)("ChallanDocId"))
                        Dgl1.Item(Col1BookIdSufix, I).Value = mBookUidSufix
                        Dgl1.Item(Col1AccessionNoPrefix, I).Value = mAccessionPrefix
                        Call Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Accession"
            RepName = "Lib_BookAccession_Print" : RepTitle = "Book Accession"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT  H.DocID, H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo,H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReceiptNo, H.TransactionBy, H.Remarks,SM.Name AS SiteName,PC.V_Type + ' - ' + Convert(NVARCHAR(5),PC.V_No) AS PCVoucherNo,PC.V_Type AS PCV_Type,PC.V_No AS PCV_No," & _
                    " L.Sr, L.AccessionNo, L.Book_UID, L.Book, L.Version,L.Writer, I.ItemType, " & _
                    " L.Publisher, L.Series, L.Subject, L.Volume, L.Language, L.ISBN, L.Edition,G.Description AS GodownDesc, " & _
                    " L.Pages, L.MRP,L.Rate, L.WithCD, L.Godown, L.GodownSection, L.RefAccessionNo, S.Description AS SubjectDesc," & _
                    " L.Remarks, L.IsInStock,I.Description AS BookDisp,SG.DispName AS TransactionByName, " & _
                    " SG.DispName AS TransactionByDispName " & _
                    " FROM  Lib_Accession H " & _
                    " LEFT JOIN Lib_AccessionDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.TransactionBy " & _
                    " LEFT JOIN Item I ON I.Code=L.Book " & _
                    " LEFT JOIN Lib_Subject S ON S.Code=L.Subject " & _
                    " LEFT JOIN Godown G ON G.Code=L.Godown " & _
                    " LEFT JOIN PurchChallan PC ON H.ReceiptNo =PC.DocID " & _
                    " " & bCondstr & " "


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ProcPostInBookMaster(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, ByVal bRow As Integer)
        Try
            With Dgl1
                mQry = " UPDATE Lib_Book_Log " & _
                         " SET  " & _
                         " Series = " & AgL.Chk_Text(.Item(Col1Series, bRow).Value) & ", " & _
                         " Subject = " & AgL.Chk_Text(.AgSelectedValue(Col1Subject, bRow)) & ", " & _
                         " Volume = " & AgL.Chk_Text(.Item(Col1Volume, bRow).Value) & ", " & _
                         " Language = " & AgL.Chk_Text(.Item(Col1Language, bRow).Value) & ", " & _
                         " ISBN = " & AgL.Chk_Text(.Item(Col1ISBN, bRow).Value) & " " & _
                         " WHERE Code = '" & .AgSelectedValue(Col1Item, bRow) & "'  "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                mQry = " UPDATE Lib_Book " & _
                         " SET  " & _
                         " Series = " & AgL.Chk_Text(.Item(Col1Series, bRow).Value) & ", " & _
                         " Subject = " & AgL.Chk_Text(.AgSelectedValue(Col1Subject, bRow)) & ", " & _
                         " Volume = " & AgL.Chk_Text(.Item(Col1Volume, bRow).Value) & ", " & _
                         " Language = " & AgL.Chk_Text(.Item(Col1Language, bRow).Value) & ", " & _
                         " ISBN = " & AgL.Chk_Text(.Item(Col1ISBN, bRow).Value) & " " & _
                         " WHERE Code = '" & .AgSelectedValue(Col1Item, bRow) & "'  "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcGetAlmira(ByVal Subject As String, ByVal RowIndex As Integer)
        Dim DtTemp As DataTable = Nothing
        Try
            If Subject = "" Then Exit Sub
            mQry = " SELECT Sd.Godown, Sd.GodownSection FROM Lib_SubjectDetail Sd WHERE Sd.Code = '" & Subject & "'  "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                If .Rows.Count > 0 Then
                    Dgl1.AgSelectedValue(Col1Godown, RowIndex) = AgL.XNull(.Rows(0)("Godown"))
                    Dgl1.Item(Col1GodownSection, RowIndex).Value = AgL.XNull(.Rows(0)("GodownSection"))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcRefreshItemList()
        Dim DtRow As DataRow() = Nothing
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcAdjustGrid()
        Try
            If Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then Exit Sub
            With Dgl1
                .Columns(Col1BtnNewBook).DisplayIndex = 2
                .Columns(Col1AccessionNo_Sr).DisplayIndex = 4
                .Columns(Col1Edition).DisplayIndex = 5
                .Columns(Col1PublicationYear).DisplayIndex = 6
                .Columns(Col1Pages).DisplayIndex = 7
                .Columns(Col1Mrp).DisplayIndex = 8
                .Columns(Col1Rate).DisplayIndex = 9
                .Columns(Col1Godown).DisplayIndex = 10
                .Columns(Col1GodownSection).DisplayIndex = 11
                .Columns(Col1Place).DisplayIndex = 12
                .Columns(Col1Remarks).DisplayIndex = 13
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellLeave
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            If Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then Exit Sub
            Select Case e.ColumnIndex
                Case Dgl1.Columns(Col1Remarks).Index
                    SendKeys.Send("{DOWN}")
                    SendKeys.Send("{HOME}")
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        Call ProcFillBookAccessionNo()
                        Call ProcFillCdAccessionNo()
                    ElseIf AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                        Call ProcUpdateBookAccession()
                        Call ProcUpdateCdAccession()
                    Else
                        Exit Sub
                    End If
                Case Dgl1.Columns(Col1Item).Index
                    Dgl1.Rows.Add()
                    SendKeys.Send("{Down}")
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dgl1.KeyPress
        Dim FrmObj As Form = Nothing
        Dim bColumnIndex As Integer = 0
        Dim bRowIndex As Integer = 0
        Dim I As Integer = 0
        Try
            If Not AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then Exit Sub

            bColumnIndex = Dgl1.CurrentCell.ColumnIndex
            bRowIndex = Dgl1.CurrentCell.RowIndex
            If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub

            Select Case Dgl1.Columns(bColumnIndex).Name
                Case Else
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        Call ProcCreateNewBook(bRowIndex)
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub


    Private Sub ProcCreateNewBook(ByVal bRowIndex As Integer)
        Dim FrmObj As Form = Nothing
        Try
            FrmObj = New AccessionEntry(Me)
            CType(FrmObj, AccessionEntry).EntryMode = Topctrl1.Mode

            CType(FrmObj, AccessionEntry).Book = Dgl1.AgSelectedValue(Col1Item, bRowIndex)
            CType(FrmObj, AccessionEntry).almira = Dgl1.AgSelectedValue(Col1Godown, bRowIndex)
            CType(FrmObj, AccessionEntry).Subject = Dgl1.AgSelectedValue(Col1Subject, bRowIndex)
            CType(FrmObj, AccessionEntry).Publisher = AgL.XNull(Dgl1.Item(Col1Publisher, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Writer = AgL.XNull(Dgl1.Item(Col1Writer, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Volume = AgL.XNull(Dgl1.Item(Col1Volume, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Language = AgL.XNull(Dgl1.Item(Col1Language, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).PublicationYear = AgL.XNull(Dgl1.Item(Col1PublicationYear, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).ISBN = AgL.XNull(Dgl1.Item(Col1ISBN, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Series = AgL.XNull(Dgl1.Item(Col1Series, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).WithCD = AgL.XNull(Dgl1.Item(Col1WithCd, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).CdItemCode = AgL.XNull(Dgl1.Item(Col1CdItemCode, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).qty = AgL.VNull(Dgl1.Item(Col1Qty, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Rate = AgL.VNull(Dgl1.Item(Col1Rate, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Mrp = AgL.VNull(Dgl1.Item(Col1Mrp, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).Pages = AgL.VNull(Dgl1.Item(Col1Pages, bRowIndex).Value)
            CType(FrmObj, AccessionEntry).place = AgL.XNull(Dgl1.Item(Col1Place, bRowIndex).Value)
            If Val(Dgl1.Item(Col1AccessionNo_Sr, bRowIndex).Value) = 0 Then
                CType(FrmObj, AccessionEntry).TxtAccno.Text = FunPDMAccessionNo(bRowIndex)
            Else
                CType(FrmObj, AccessionEntry).TxtAccno.Text = Dgl1.Item(Col1AccessionNo_Sr, bRowIndex).Value
            End If

            FrmObj.ShowDialog()

            If CType(FrmObj, AccessionEntry).mIsOkClicked Then

                Dgl1.Item(Col1Rate, bRowIndex).Value = 0
                Dgl1.Item(Col1Mrp, bRowIndex).Value = 0
                Dgl1.Item(Col1Pages, bRowIndex).Value = 0
                Dgl1.Item(Col1Item, bRowIndex).Value = ""
                Dgl1.Item(Col1Publisher, bRowIndex).Value = ""
                Dgl1.Item(Col1Writer, bRowIndex).Value = ""
                Dgl1.Item(Col1Volume, bRowIndex).Value = ""
                Dgl1.Item(Col1ISBN, bRowIndex).Value = ""
                Dgl1.Item(Col1Subject, bRowIndex).Value = ""
                Dgl1.Item(Col1Series, bRowIndex).Value = ""
                Dgl1.Item(Col1WithCd, bRowIndex).Value = ""
                Dgl1.Item(Col1CdItemCode, bRowIndex).Value = ""
                Dgl1.Item(Col1BookIdPrefix, bRowIndex).Value = ""
                Dgl1.Item(Col1Place, bRowIndex).Value = ""

                If CType(FrmObj, AccessionEntry).TxtBook.Text <> "" Then
                    Ini_List()

                    Dgl1.Item(Col1Qty, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtQty.Text
                    Dgl1.Item(Col1Rate, bRowIndex).Value = CType(FrmObj, AccessionEntry).TXtRate.Text
                    Dgl1.Item(Col1Pages, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtPages.Text
                    Dgl1.Item(Col1Mrp, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtMRP.Text
                    Dgl1.AgSelectedValue(Col1Item, bRowIndex) = CType(FrmObj, AccessionEntry).TxtBook.AgSelectedValue
                    Dgl1.Item(Col1Publisher, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtPublisher.Text
                    Dgl1.Item(Col1Writer, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtWriter.Text
                    Dgl1.Item(Col1Volume, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtVolume.Text

                    Dgl1.Item(Col1ISBN, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtIsbn.Text
                    Dgl1.Item(Col1Series, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtSeries.Text
                    Dgl1.Item(Col1WithCd, bRowIndex).Value = CType(FrmObj, AccessionEntry).TXtWithCD.Text
                    Dgl1.Item(Col1Place, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtPlace.Text

                    Dgl1.AgSelectedValue(Col1Subject, bRowIndex) = CType(FrmObj, AccessionEntry).TxtSubject.AgSelectedValue
                    Dgl1.AgSelectedValue(Col1Godown, bRowIndex) = CType(FrmObj, AccessionEntry).TXtAlmira.AgSelectedValue
                    Dgl1.Item(Col1AccessionNoPrefix, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtBookPrefix.Text
                    Dgl1.Item(Col1AccessionNo_Sr, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtAccno.Text

                    Dgl1.Item(Col1PublicationYear, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtPublicationYear.Text
                    Dgl1.Item(Col1Series, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtSeries.Text
                    Dgl1.Item(Col1Volume, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtVolume.Text
                    Dgl1.Item(Col1Language, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtLanguage.Text
                End If
            End If

            If CType(FrmObj, AccessionEntry).mIsOkClicked Then
                Validating_Item(Dgl1.AgSelectedValue(Col1Item, bRowIndex), bRowIndex)

                If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                    Call ProcFillBookAccessionNo()
                    Call ProcFillCdAccessionNo()

                ElseIf AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                    Call ProcUpdateBookAccession()
                    Call ProcUpdateCdAccession()
                Else
                    Exit Sub
                End If

                Call Calculation()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtnImprtFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromExcel.Click
        Dim DtVDate As DataTable, DtAccessationDetail As DataTable, DtAccessationHead As DataTable
        Dim I As Integer, J As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        Dim DrAccessationDetail As DataRow() = Nothing, DrAccessationHead As DataRow() = Nothing, DrTemp As DataRow() = Nothing

        mQry = "                  Select '' as Srl, 'Accessation Date' as [Field Name],'DATETIME' as [Data Type], 0 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No Prefix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No Sufix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Accession No Sr' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id Prefix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id Sufix' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Id Sr' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Name' as [Field Name],'Text' as [Data Type], 255 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Subject' as [Field Name],'Text' as [Data Type], 100 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Book Type' as [Field Name],'Text' as [Data Type], 50 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Series' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Volume' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'ISBN' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Language' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Writer' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Publisher' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Publication Year' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Pages' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'MRP' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Rate' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Call No' as [Field Name],'Text' as [Data Type], 35 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Place' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Almira' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Shelf' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "



        DtAccessationDetail = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportAccessationFromExcel
        ObjFrmImport.LblTitle.Text = "Accessation Import"
        ObjFrmImport.VDate_Column = "Accessation Date"
        ObjFrmImport.Dgl1.DataSource = DtAccessationDetail
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub

        DtAccessationDetail = ObjFrmImport.P_DsExcelData.Tables(0)
        DtAccessationHead = ObjFrmImport.P_DsExcelData.Tables(1)
        DtVDate = ObjFrmImport.P_DsExcelData.Tables(2)

        For J = 0 To DtVDate.Rows.Count - 1
            Topctrl1.FButtonClick(0)
            mBlnImprtFromExcelFlag = True



                DrAccessationHead = DtAccessationHead.Select("[" & ObjFrmImport.VDate_Column & "] = " & AgL.Chk_Text(AgL.XNull(DtVDate.Rows(J)(ObjFrmImport.VDate_Column))) & "")
            TxtV_Date.Text = Format(AgL.XNull(DrAccessationHead(0)("Accessation Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
            For I = 0 To DrAccessationHead.Length - 1
                Dgl1.Rows.Add()
                Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                Dgl1.Item(Col1Qty, I).Value = AgL.VNull(DrAccessationHead(I)("Qty"))
                Dgl1.Item(Col1Writer, I).Value = AgL.XNull(DrAccessationHead(I)("Writer"))
                Dgl1.Item(Col1Publisher, I).Value = AgL.XNull(DrAccessationHead(I)("Publisher"))
                Dgl1.Item(Col1Series, I).Value = AgL.XNull(DrAccessationHead(I)("Series"))
                Dgl1.Item(Col1Volume, I).Value = AgL.XNull(DrAccessationHead(I)("Volume"))
                Dgl1.Item(Col1Language, I).Value = AgL.XNull(DrAccessationHead(I)("Language"))
                Dgl1.Item(Col1ISBN, I).Value = AgL.XNull(DrAccessationHead(I)("ISBN"))
                Dgl1.Item(Col1PublicationYear, I).Value = AgL.XNull(DrAccessationHead(I)("Publication Year"))
                Dgl1.Item(Col1Pages, I).Value = AgL.XNull(DrAccessationHead(I)("Pages"))
                Dgl1.Item(Col1Mrp, I).Value = AgL.XNull(DrAccessationHead(I)("MRP"))
                Dgl1.Item(Col1Rate, I).Value = AgL.VNull(DrAccessationHead(I)("Rate"))
                Dgl1.Item(Col1CallNo, I).Value = AgL.XNull(DrAccessationHead(I)("Call No"))
                Dgl1.Item(Col1GodownSection, I).Value = AgL.XNull(DrAccessationHead(I)("Shelf"))


                If AgL.XNull(DrAccessationHead(I)("Almira")).ToString.Trim <> "" Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Godown).Tables(0).Select(" Godown = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Almira"))) & "")

                    If DrTemp.Length > 0 Then
                        Dgl1.AgSelectedValue(Col1Godown, I) = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If

                If AgL.XNull(DrAccessationHead(I)("Subject")).ToString.Trim <> "" Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Subject).Tables(0).Select(" Subject = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Subject"))) & "")
                    If DrTemp.Length > 0 Then
                        Dgl1.AgSelectedValue(Col1Subject, I) = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If

                If AgL.XNull(DrAccessationHead(I)("Book Name")).ToString.Trim <> "" Then
                    mQry = " DisplayName = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Book Name"))) & ""

                    If AgL.XNull(DrAccessationHead(I)("Book Type")).ToString.Trim <> "" Then
                        mQry += " And BookTypeDesc = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Book Type"))) & ""
                    End If

                    If AgL.XNull(DrAccessationHead(I)("Volume")).ToString.Trim <> "" Then
                        mQry += " And Volume = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Volume"))) & ""
                    End If

                    If AgL.XNull(DrAccessationHead(I)("Writer")).ToString.Trim <> "" Then
                        mQry += " And Writer = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Writer"))) & ""
                    End If

                    If AgL.XNull(DrAccessationHead(I)("Publisher")).ToString.Trim <> "" Then
                        mQry += " And Publisher = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Publisher"))) & ""
                    End If

                    If AgL.XNull(DrAccessationHead(I)("Series")).ToString.Trim <> "" Then
                        mQry += " And Series = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Series"))) & ""
                    End If

                    If AgL.XNull(DrAccessationHead(I)("ISBN")).ToString.Trim <> "" Then
                        mQry += " And ISBN = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("ISBN"))) & ""
                    End If

                    If AgL.XNull(DrAccessationHead(I)("Language")).ToString.Trim <> "" Then
                        mQry += " And Language = " & AgL.Chk_Text(AgL.XNull(DrAccessationHead(I)("Language"))) & ""
                    End If


                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select(mQry)
                    If DrTemp.Length > 0 Then
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If


            Next I


            DrAccessationDetail = DtAccessationDetail.Select("[" & ObjFrmImport.VDate_Column & "] = " & AgL.Chk_Text(AgL.XNull(DtVDate.Rows(J)(ObjFrmImport.VDate_Column))) & "")
            Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
            For I = 0 To DrAccessationDetail.Length - 1
                Dgl2.Rows.Add()
                Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count

                Dgl2.Item(Col2AccessionNo, I).Value = AgL.XNull(DrAccessationDetail(I)("Accession No"))
                Dgl2.Item(Col2Book_UID, I).Value = AgL.XNull(DrAccessationDetail(I)("Book Id"))

                Dgl2.Item(Col2AccessionNoPrefix, I).Value = AgL.XNull(DrAccessationDetail(I)("Accession No Prefix"))
                Dgl2.Item(Col2AccessionNo_Sr, I).Value = AgL.VNull(DrAccessationDetail(I)("Accession No Sr"))
                Dgl2.Item(Col2AccessionNoSufix, I).Value = AgL.XNull(DrAccessationDetail(I)("Accession No Sufix"))

                Dgl2.Item(Col2BookIDPrefix, I).Value = AgL.XNull(DrAccessationDetail(I)("Book Id Prefix"))
                Dgl2.Item(Col2BookID_Sr, I).Value = AgL.XNull(DrAccessationDetail(I)("Book Id Sr"))
                Dgl2.Item(Col2BookIDSufix, I).Value = AgL.XNull(DrAccessationDetail(I)("Book Id Sufix"))


                Dgl2.Item(Col2Writer, I).Value = AgL.XNull(DrAccessationDetail(I)("Writer"))
                Dgl2.Item(Col2Publisher, I).Value = AgL.XNull(DrAccessationDetail(I)("Publisher"))
                Dgl2.Item(Col2Series, I).Value = AgL.XNull(DrAccessationDetail(I)("Series"))
                Dgl2.Item(Col2Volume, I).Value = AgL.XNull(DrAccessationDetail(I)("Volume"))
                Dgl2.Item(Col2Language, I).Value = AgL.XNull(DrAccessationDetail(I)("Language"))
                Dgl2.Item(Col2ISBN, I).Value = AgL.XNull(DrAccessationDetail(I)("ISBN"))
                'Dgl2.Item(Col2Edition, I).Value = AgL.XNull(DrAccessationDetail(I)("Edition"))
                Dgl2.Item(Col2PublicationYear, I).Value = AgL.XNull(DrAccessationDetail(I)("Publication Year"))
                Dgl2.Item(Col2Pages, I).Value = AgL.XNull(DrAccessationDetail(I)("Pages"))
                Dgl2.Item(Col2Mrp, I).Value = AgL.VNull(DrAccessationDetail(I)("MRP"))
                Dgl2.Item(Col2Rate, I).Value = AgL.VNull(DrAccessationDetail(I)("Rate"))
                Dgl2.Item(Col2Place, I).Value = AgL.XNull(DrAccessationDetail(I)("Place"))
                Dgl2.Item(Col2CallNo, I).Value = AgL.XNull(DrAccessationDetail(I)("Call No"))
                Dgl2.Item(Col2GodownSection, I).Value = AgL.XNull(DrAccessationDetail(I)("Shelf"))

                If AgL.XNull(DrAccessationDetail(I)("Almira")).ToString.Trim <> "" Then
                    DrTemp = Dgl2.AgHelpDataSet(Col2Godown).Tables(0).Select(" Godown = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Almira"))) & "")

                    If DrTemp.Length > 0 Then
                        Dgl2.AgSelectedValue(Col2Godown, I) = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If

                If AgL.XNull(DrAccessationDetail(I)("Subject")).ToString.Trim <> "" Then
                    DrTemp = Dgl2.AgHelpDataSet(Col2Subject).Tables(0).Select(" Subject = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Subject"))) & "")
                    If DrTemp.Length > 0 Then
                        Dgl2.AgSelectedValue(Col2Subject, I) = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If

                If AgL.XNull(DrAccessationDetail(I)("Book Name")).ToString.Trim <> "" Then
                    mQry = " DisplayName = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Book Name"))) & ""

                    If AgL.XNull(DrAccessationDetail(I)("Book Type")).ToString.Trim <> "" Then
                        mQry += " And BookTypeDesc = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Book Type"))) & ""
                    End If

                    If AgL.XNull(DrAccessationDetail(I)("Volume")).ToString.Trim <> "" Then
                        mQry += " And Volume = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Volume"))) & ""
                    End If

                    If AgL.XNull(DrAccessationDetail(I)("Writer")).ToString.Trim <> "" Then
                        mQry += " And Writer = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Writer"))) & ""
                    End If

                    If AgL.XNull(DrAccessationDetail(I)("Publisher")).ToString.Trim <> "" Then
                        mQry += " And Publisher = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Publisher"))) & ""
                    End If

                    If AgL.XNull(DrAccessationDetail(I)("Series")).ToString.Trim <> "" Then
                        mQry += " And Series = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Series"))) & ""
                    End If

                    If AgL.XNull(DrAccessationDetail(I)("ISBN")).ToString.Trim <> "" Then
                        mQry += " And ISBN = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("ISBN"))) & ""
                    End If

                    If AgL.XNull(DrAccessationDetail(I)("Language")).ToString.Trim <> "" Then
                        mQry += " And Language = " & AgL.Chk_Text(AgL.XNull(DrAccessationDetail(I)("Language"))) & ""
                    End If


                    DrTemp = Dgl2.AgHelpDataSet(Col2Item).Tables(0).Select(mQry)
                    If DrTemp.Length > 0 Then
                        Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If
            Next

            ''===========< Finally >==============
            Topctrl1.FButtonClick(13)
            ''===========< ******* >==============
        Next


        If StrErrLog <> "" Then
            MsgBox(StrErrLog)
        Else
            MsgBox("Import Process Completed.", MsgBoxStyle.Information, Me.Text)
        End If


        FW.Close()

        mBlnImprtFromExcelFlag = False

        ''======< At Last Move To Browse Mode >=======
        Topctrl1.FButtonClick(14, True)
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            mQry = " Select Count(*) From Lib_BookIssue H Where H.AccessionDocId = '" & TxtDocId.Text & "'"
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                MsgBox("Accession Is Created For Replacement.Can't Modify Entry!", MsgBoxStyle.Exclamation)
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub TempPurchInvoiceCommon_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempPurchInvoiceCommon_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub
End Class

