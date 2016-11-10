Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPurchaseIndent
    Inherits Academic_ProjLib.TempTransaction
    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$


    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Item"
    Protected Const Col1ItemDescription As String = "Item Description"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1ReqQty As String = "Requisition Qty"
    Protected Const Col1IndentQty As String = "Indent Qty"
    Protected Const Col1ReqDate As String = "Require Date"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"

    'Public Const ColSNo As String = "S.No."
    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Protected Const Col2RequisionNo As String = "Requisitiion No."
    Protected Const Col2Requid As String = "Requisitiion Uid"
    Protected Const Col2Item As String = "Item"
    Protected Const Col2ItemDescription As String = "Item Description"
    Protected Const Col2Unit As String = "Unit"
    Protected Const Col2ReqQty As String = "Req. Qty"
    Protected Const Col2ReqDate As String = "Require Date"
    Protected Const Col2Remark As String = "Remark"
    Protected Const Col2UID As String = "UID"
    Protected Const Col2TempUID As String = "TempUID"

    Dim mRequistionNCat$ = ""

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"
#Region "Form Designer Code"
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemark As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblSubCode As System.Windows.Forms.Label
    Protected WithEvents TxtSubCode As AgControls.AgTextBox
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents Panel2 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalReqQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalReqText As System.Windows.Forms.Label
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalOty As System.Windows.Forms.Label
    Protected WithEvents Panel3 As System.Windows.Forms.Panel
    Protected WithEvents BtnFillRequisition As System.Windows.Forms.Button
    Protected WithEvents BtnFillIndentDetail As System.Windows.Forms.Button
    Protected WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Private Sub InitializeComponent()
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.TxtSubCode = New AgControls.AgTextBox
        Me.LblSubCode = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LblTotalReqQty = New System.Windows.Forms.Label
        Me.LblTotalReqText = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalOty = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BtnFillRequisition = New System.Windows.Forms.Button
        Me.BtnFillIndentDetail = New System.Windows.Forms.Button
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDivision
        '
        '
        'TxtDocId
        '
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(273, 68)
        '
        'TxtV_No
        '
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(140, 73)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(32, 68)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(140, 53)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(162, 67)
        Me.TxtV_Date.Size = New System.Drawing.Size(105, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(32, 48)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(162, 47)
        Me.TxtV_Type.Size = New System.Drawing.Size(304, 18)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(140, 33)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(32, 28)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(162, 27)
        Me.TxtSite_Code.Size = New System.Drawing.Size(304, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'Tc1
        '
        Me.Tc1.Location = New System.Drawing.Point(0, 3)
        Me.Tc1.Size = New System.Drawing.Size(992, 154)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtSubCode)
        Me.TP1.Controls.Add(Me.LblSubCode)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.LblRemark)
        Me.TP1.Controls.Add(Me.TxtRemark)
        Me.TP1.Size = New System.Drawing.Size(984, 126)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 3
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(596, 34)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 1023
        Me.LblSubCodeReq.Text = "Ä"
        '
        'TxtSubCode
        '
        Me.TxtSubCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtSubCode.AgMandatory = True
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
        Me.TxtSubCode.Location = New System.Drawing.Point(617, 28)
        Me.TxtSubCode.MaxLength = 20
        Me.TxtSubCode.Name = "TxtSubCode"
        Me.TxtSubCode.Size = New System.Drawing.Size(304, 18)
        Me.TxtSubCode.TabIndex = 5
        '
        'LblSubCode
        '
        Me.LblSubCode.AutoSize = True
        Me.LblSubCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubCode.Location = New System.Drawing.Point(487, 30)
        Me.LblSubCode.Name = "LblSubCode"
        Me.LblSubCode.Size = New System.Drawing.Size(52, 15)
        Me.LblSubCode.TabIndex = 1022
        Me.LblSubCode.Text = "Indenter"
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtReferenceNo.AgMandatory = True
        Me.TxtReferenceNo.AgMasterHelp = True
        Me.TxtReferenceNo.AgNumberLeftPlaces = 8
        Me.TxtReferenceNo.AgNumberNegetiveAllow = False
        Me.TxtReferenceNo.AgNumberRightPlaces = 2
        Me.TxtReferenceNo.AgPickFromLastValue = False
        Me.TxtReferenceNo.AgRowFilter = ""
        Me.TxtReferenceNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReferenceNo.AgSelectedValue = Nothing
        Me.TxtReferenceNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReferenceNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReferenceNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReferenceNo.Location = New System.Drawing.Point(162, 87)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(105, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(32, 88)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 1020
        Me.LblReferenceNo.Text = "Reference No."
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(141, 93)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 1021
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtRemark
        '
        Me.TxtRemark.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtRemark.Location = New System.Drawing.Point(617, 47)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(304, 18)
        Me.TxtRemark.TabIndex = 6
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(487, 49)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 1024
        Me.LblRemark.Text = "Remark"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 182)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(973, 161)
        Me.Pnl1.TabIndex = 4
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 159)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(160, 20)
        Me.LinkLabel1.TabIndex = 742
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "REQUISITION DETAILS:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel2.Controls.Add(Me.LblTotalReqQty)
        Me.Panel2.Controls.Add(Me.LblTotalReqText)
        Me.Panel2.Location = New System.Drawing.Point(12, 343)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(986, 21)
        Me.Panel2.TabIndex = 797
        '
        'LblTotalReqQty
        '
        Me.LblTotalReqQty.AutoSize = True
        Me.LblTotalReqQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalReqQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalReqQty.Location = New System.Drawing.Point(94, 3)
        Me.LblTotalReqQty.Name = "LblTotalReqQty"
        Me.LblTotalReqQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalReqQty.TabIndex = 668
        Me.LblTotalReqQty.Text = "."
        Me.LblTotalReqQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalReqText
        '
        Me.LblTotalReqText.AutoSize = True
        Me.LblTotalReqText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalReqText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalReqText.Location = New System.Drawing.Point(9, 3)
        Me.LblTotalReqText.Name = "LblTotalReqText"
        Me.LblTotalReqText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalReqText.TabIndex = 667
        Me.LblTotalReqText.Text = "Total Qty :"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 367)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(248, 20)
        Me.LinkLabel2.TabIndex = 796
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Purchase Indent For Following Items"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblValTotalQty)
        Me.Panel1.Controls.Add(Me.LblTextTotalOty)
        Me.Panel1.Location = New System.Drawing.Point(12, 532)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 21)
        Me.Panel1.TabIndex = 795
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(94, 3)
        Me.LblValTotalQty.Name = "LblValTotalQty"
        Me.LblValTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQty.TabIndex = 668
        Me.LblValTotalQty.Text = "."
        Me.LblValTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalOty
        '
        Me.LblTextTotalOty.AutoSize = True
        Me.LblTextTotalOty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalOty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalOty.Location = New System.Drawing.Point(9, 3)
        Me.LblTextTotalOty.Name = "LblTextTotalOty"
        Me.LblTextTotalOty.Size = New System.Drawing.Size(73, 16)
        Me.LblTextTotalOty.TabIndex = 667
        Me.LblTextTotalOty.Text = "Total Qty :"
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel3.Location = New System.Drawing.Point(12, 391)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(986, 140)
        Me.Panel3.TabIndex = 5
        '
        'BtnFillRequisition
        '
        Me.BtnFillRequisition.BackColor = System.Drawing.Color.Silver
        Me.BtnFillRequisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillRequisition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillRequisition.ForeColor = System.Drawing.Color.Black
        Me.BtnFillRequisition.Location = New System.Drawing.Point(845, 158)
        Me.BtnFillRequisition.Name = "BtnFillRequisition"
        Me.BtnFillRequisition.Size = New System.Drawing.Size(140, 23)
        Me.BtnFillRequisition.TabIndex = 1
        Me.BtnFillRequisition.Text = "Fill Requisition Detail"
        Me.BtnFillRequisition.UseVisualStyleBackColor = False
        '
        'BtnFillIndentDetail
        '
        Me.BtnFillIndentDetail.BackColor = System.Drawing.Color.Silver
        Me.BtnFillIndentDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillIndentDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillIndentDetail.ForeColor = System.Drawing.Color.Black
        Me.BtnFillIndentDetail.Location = New System.Drawing.Point(845, 367)
        Me.BtnFillIndentDetail.Name = "BtnFillIndentDetail"
        Me.BtnFillIndentDetail.Size = New System.Drawing.Size(140, 21)
        Me.BtnFillIndentDetail.TabIndex = 2
        Me.BtnFillIndentDetail.Text = "Fill Indent Detail"
        Me.BtnFillIndentDetail.UseVisualStyleBackColor = False
        '
        'FrmPurchaseIndent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.BtnFillIndentDetail)
        Me.Controls.Add(Me.BtnFillRequisition)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmPurchaseIndent"
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.BtnFillRequisition, 0)
        Me.Controls.SetChildIndex(Me.BtnFillIndentDetail, 0)
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.Tc1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.GBoxApproved.ResumeLayout(False)
        Me.GBoxApproved.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxModified.ResumeLayout(False)
        Me.GBoxModified.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region
    Public Property RequistionNCat() As String
        Get
            RequistionNCat = mRequistionNCat
        End Get
        Set(ByVal value As String)
            mRequistionNCat = value
        End Set
    End Property

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.StorePurchaseIndent) & ""
    End Sub

    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property
    Public Class HelpDataSet
        Public Shared Party As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_PurchIndent"
        AglObj = AgL

        LblV_Type.Text = "Indent Type"
        LblV_Date.Text = "Indent Date"
        LblV_No.Text = "Indent No."
        TP1.Text = "Tp1"

        AgL.GridDesign(Dgl1)
        AgL.GridDesign(DGL2)
    End Sub

    Public Sub Form_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim mCondStr$ = ""

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "
        mCondStr = mCondStr & " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        mQry = " Select H.DocID As SearchCode " & _
                " From Store_PurchIndent H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                      " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " "
        mCondStr += " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And P.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And P.ApprovedDate Is Not Null "
            End If
        End If

        AgL.PubFindQry = "SELECT P.DocID, Vt.Description AS [Indent Type], P.V_Date AS [Indent Date], " & _
                           " P.V_No AS [Indent No], Sg.DispName As Indentor " & _
                           " FROM Store_PurchIndent P With (NoLock)" & _
                           " LEFT JOIN Voucher_type Vt ON p.V_Type = Vt.V_Type " & _
                           " Left Join SubGroup Sg With (NoLock) On P.SubCode = Sg.SubCode " & _
                           " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Indent Date]"
    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, True)
            .AddAgTextColumn(Dgl1, Col1ItemDescription, 180, 255, Col1ItemDescription, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Unit, 70, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1ReqQty, 80, 8, 4, False, Col1ReqQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1IndentQty, 80, 8, 4, False, Col1IndentQty, True, False, True)
            .AddAgDateColumn(Dgl1, Col1ReqDate, 100, Col1ReqDate, True, False)
            .AddAgTextColumn(Dgl1, Col1Remark, 200, 255, Col1Remark, True, False, False)
            .AddAgTextColumn(Dgl1, Col1UID, 80, 0, Col1UID, False, True, False)
            .AddAgTextColumn(Dgl1, Col1TempUID, 80, 0, Col1TempUID, False, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Panel3)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35


        DGL2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL2, Col2RequisionNo, 80, 0, Col2RequisionNo, True, False)
            .AddAgTextColumn(DGL2, Col2Requid, 80, 0, Col2Requid, False, True, False)
            .AddAgTextColumn(DGL2, Col2Item, 230, 0, Col2Item, True, False, False)
            .AddAgTextColumn(DGL2, Col2ItemDescription, 140, 255, Col2ItemDescription, True, False, False)
            .AddAgTextColumn(DGL2, Col2Unit, 70, 0, Col2Unit, True, True, False)
            .AddAgNumberColumn(DGL2, Col2ReqQty, 90, 8, 3, False, Col2ReqQty, True, False, True)
            .AddAgDateColumn(DGL2, Col2ReqDate, 90, Col2ReqDate, True, False, False)
            .AddAgTextColumn(DGL2, Col2Remark, 200, 255, Col2Remark, True, False, False)
            .AddAgTextColumn(DGL2, Col2UID, 80, 0, Col2UID, False, True, False)
            .AddAgTextColumn(DGL2, Col2TempUID, 80, 0, Col2TempUID, False, True, False)

        End With
        AgL.AddAgDataGrid(DGL2, Pnl1)
        DGL2.EnableHeadersVisualStyles = False
        DGL2.AgSkipReadOnlyColumns = True
        DGL2.Anchor = AnchorStyles.None
        'PnlFooter.Anchor = DGL2.Anchor
        DGL2.ColumnHeadersHeight = 35

        Dgl1.Columns(Col1ReqQty).Visible = True
        Dgl1.Columns(Col1Item).ReadOnly = True
        Dgl1.Columns(Col1ItemDescription).ReadOnly = True
        Dgl1.Columns(Col1Unit).ReadOnly = True
        Dgl1.Columns(Col1ReqDate).ReadOnly = True
        Dgl1.Columns(Col1ReqQty).ReadOnly = True
        'Dgl1.Columns(Col1IndentQty).HeaderText = "Approved Qty."

        Topctrl1.ChangeAgGridState(DGL2, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""
        Dim I As Integer, mSr As Integer


        mQry = "UPDATE dbo.Store_PurchIndent " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                " TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_PurchIndentDetail WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1

                    If AglObj.XNull(Dgl1.Item(Col1TempUID, I).Value).ToString.Trim = "" Then
                        If AglObj.XNull(Dgl1.Item(Col1UID, I).Value).ToString.Trim = "" Then
                            Dgl1.Item(Col1UID, I).Value = AglObj.GetGUID(AgL.Gcn_ConnectionString).ToString
                        End If
                    End If

                    bStrLineUid = Dgl1.Item(Col1UID, I).Value

                    mQry = "Insert Into Store_PurchIndentDetail(DocId, Sr, Item,ItemDescription, RequireQty, IndentQty, " & _
                            " Unit,RequireDate,Remark,Uid) " & _
                            " Values(" & AgL.Chk_Text(mSearchCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                           " " & AglObj.Chk_Text(Dgl1.Item(Col1ItemDescription, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1ReqQty, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1IndentQty, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                            " " & AgL.ConvertDate(Dgl1.Item(Col1ReqDate, I).Value.ToString) & ", " & AglObj.Chk_Text(Dgl1.Item(Col1Remark, bIntI).Value) & "," & AglObj.Chk_Text(bStrLineUid) & " )"

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With


        mQry = "Delete From Store_PurchIndentReq Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        bIntSr = 0
        For bIntI = 0 To DGL2.RowCount - 1
            If DGL2.Item(Col2Item, bIntI).Value <> "" Then
                bIntSr += 1

                If AglObj.XNull(DGL2.Item(Col2TempUID, bIntI).Value).ToString.Trim = "" Then
                    If AglObj.XNull(DGL2.Item(Col2UID, bIntI).Value).ToString.Trim = "" Then
                        DGL2.Item(Col2UID, bIntI).Value = AglObj.GetGUID(AgL.Gcn_ConnectionString).ToString
                    End If
                End If

                bStrLineUid = DGL2.Item(Col2UID, bIntI).Value

                mQry = "INSERT INTO dbo.Store_PurchIndentReq ( " & _
                        " DocId, Sr,RequisitionDocId,RequireUid, Item, ItemDescription,Unit,RequireQty,Remark,RequireDate,UID) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & "," & AgL.Chk_Text(DGL2.AgSelectedValue(Col2RequisionNo, bIntI)) & "," & AglObj.Chk_Text(DGL2.Item(Col2Requid, bIntI).Value) & ", " & _
                       " " & AglObj.Chk_Text(DGL2.AgSelectedValue(Col2Item, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL2.Item(Col2ItemDescription, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL2.Item(Col2Unit, bIntI).Value) & ", " & _
                        " " & Val(DGL2.Item(Col2ReqQty, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL2.Item(Col2Remark, bIntI).Value) & " ," & AgL.ConvertDate(DGL2.Item(Col2ReqDate, bIntI).Value.ToString) & ", " & AglObj.Chk_Text(bStrLineUid) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next

    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        If FGetRelationalData() = True Then
            Exit Sub
        End If
        mQry = "Delete From Store_PurchIndentReq Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_PurchIndentDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_PurchIndent Where DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer
        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
            " From Store_PurchIndent H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                Call Validating_Controls(TxtSubCode)

                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                LblValTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")

                mQry = "Select L.* " & _
                        " From Store_PurchIndentReq L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL2.Rows.Add()

                            DGL2.Item(ColSNo, bIntI).Value = DGL2.Rows.Count - 1
                            DGL2.AgSelectedValue(Col2RequisionNo, bIntI) = AgL.XNull(.Rows(bIntI)("RequisitionDocId"))
                            DGL2.Item(Col2Requid, bIntI).Value = AglObj.XNull(.Rows(bIntI)("RequireUid").ToString)
                            DGL2.Item(Col2UID, bIntI).Value = AglObj.XNull(.Rows(bIntI)("UID").ToString)
                            DGL2.Item(Col2TempUID, bIntI).Value = AglObj.XNull(.Rows(bIntI)("UID").ToString)
                            DGL2.AgSelectedValue(Col2Item, bIntI) = AglObj.XNull(.Rows(bIntI)("Item"))
                            DGL2.Item(Col2ItemDescription, bIntI).Value = AglObj.XNull(.Rows(bIntI)("ItemDescription"))
                            DGL2.Item(Col2Unit, bIntI).Value = AglObj.XNull(.Rows(bIntI)("Unit"))
                            DGL2.Item(Col2ReqQty, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("RequireQty")), "0.000")
                            DGL2.Item(Col2Remark, bIntI).Value = AglObj.XNull(.Rows(bIntI)("Remark"))
                            DGL2.Item(Col2ReqDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("RequireDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                        Next bIntI

                    End If
                End With

                mQry = "Select L.* " & _
                         " From Store_PurchIndentDetail L With (NoLock) " & _
                         " Where L.DocId = '" & SearchCode & "' " & _
                         " Order By L.Sr"
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1ItemDescription, I).Value = AglObj.XNull(.Rows(I)("ItemDescription"))
                            Dgl1.Item(Col1ReqQty, I).Value = Format(AgL.VNull(.Rows(I)("RequireQty")), "0.000")
                            Dgl1.Item(Col1IndentQty, I).Value = Format(AgL.VNull(.Rows(I)("IndentQty")), "0.000")
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1ReqDate, I).Value = AgL.XNull(.Rows(I)("RequireDate"))
                            Dgl1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                            Dgl1.Item(Col1UID, I).Value = AglObj.XNull(.Rows(I)("UID").ToString)
                            Dgl1.Item(Col1TempUID, I).Value = AglObj.XNull(.Rows(I)("UID").ToString)

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                Calculation()
            End If
        End With

        '-------------------------------------------------------------

        If SearchCode.Trim <> "" Then
            If mTransFlag Then
                Topctrl1.tEdit = False
                Topctrl1.tDel = False
            Else
                If Me.FormType = eFormType.Main Then
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                End If
                If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
            End If
        End If

        'Topctrl1.tPrn = False


        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub

    Public Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtSubCode.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        'txtDepartment.Text = AgL.XNull(DrTemp(0)("Department"))

                    End If
                End If
                DrTemp = Nothing
        End Select

    End Sub

    Public Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)
        Topctrl1.ChangeAgGridState(Dgl1, False)
        Topctrl1.ChangeAgGridState(DGL2, False)
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AgL.PubUserName

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AgL.PubLoginDate
        End If

    End Sub

    Private Sub FrmMenu_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        '<Executbale Code>
        If FGetRelationalData() = True Then
            Exit Sub
        End If
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()

        Try
            mQry = "SELECT H.SubCode AS Code, Sg.Name, Sg.ManualCode AS [Manual Code] , Sg.DispName AS [Display Name], " & _
                   " H.DateOfJoin, H.DateOfResign, Right(IsNull(Sg.Mobile,''),10) AS Mobile, " & _
                   " CASE WHEN (IsNull(H.IsTeachingStaff,0)<>0 or IsNull(H.CanTakeClass,0)<>0) THEN 'Yes' ELSE 'No' END AS [Teaching Staff],  " & _
                   " CASE WHEN H.DateOfResign IS NOT NULL THEN 'No' ELSE 'Yes' END AS [Is Active]  " & _
                   " FROM Pay_Employee H With (NoLock)   " & _
                   " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode  " & _
                   " ORDER BY Sg.Name "
            HelpDataSet.Party = AglObj.FillData(mQry, GcnRead)


            mQry = "SELECT U.Code AS Code, U.Code AS Name FROM Store_Unit U With (NoLock)  ORDER BY U.Code"
            HelpDataSet.Unit = AglObj.FillData(mQry, GcnRead)

            mQry = "SELECT I.Code, I.Description AS [Item Name], I.Unit, " & _
                    " I.DisplayName AS [Display Name], I.ManualCode, " & _
                    " C.Description AS [Item Category], G.Description AS [Item Group], " & _
                    " I.Nature, I.MasterType, " & _
                    " I.PurchaseRate, I.SaleRate , I.MRP, I.PcsPerCase, " & _
                    " I.SalesTaxPostingGroup, " & _
                    " I.ItemCategory AS ItemCategoryCode, " & _
                    " I.ItemGroup AS ItemGroupCode " & _
                    " FROM Store_Item I  With (NoLock) " & _
                    " LEFT JOIN Store_ItemGroup G  With (NoLock) ON G.Code = I.ItemGroup  " & _
                    " LEFT JOIN Store_ItemCategory C With (NoLock)  ON C.Code = I.ItemCategory " & _
                    " Where I.MasterType = '" & ClsMain.ItemType.Store & "'" & _
                    " ORDER BY I.Nature, I.Description "
            HelpDataSet.Item = AglObj.FillData(mQry, GcnRead)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try

    End Sub

    Public Sub Form_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSubCode.AgHelpDataSet(7, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Party.Copy

        Dgl1.AgHelpDataSet(Col2Item, 13) = HelpDataSet.Item.Copy
        'Dgl1.AgHelpDataSet(Col2Unit) = HelpDataSet.Unit.Copy

        IniRequisitionHelp(True)
        IniItemHelp(True)
    End Sub
    Public Sub IniItemHelp(Optional ByVal All_Records As Boolean = True, Optional ByVal bRequisitionDocId As String = "")
        If All_Records = True Then
            mQry = " SELECT I.Code, I.Description, I.Unit, I.SalesTaxPostingGroup , " & _
                    "  I.Div_Code,  " & _
                    "  0 AS Qty,0 AS TotalMeasure,'' AS RequireDate,'' as ItemDescription ,'' as UID,'' as Remark " & _
                    " FROM Store_Item I With (NoLock) "
            DGL2.AgHelpDataSet(Col2Item, 9) = AgL.FillData(mQry, AgL.GcnRead)
        Else
            If bRequisitionDocId <> "" Then
                mQry = " SELECT RD.Item AS Code,I.Description AS [Item Name],RD.Qty ,RD.Unit, " & _
                        "  RD.RequireDate ,RD.ItemDescription,RD.UID,RD.Remark, " & _
                        " '" & TxtDivision.AgSelectedValue & "' AS Div_Code " & _
                        " FROM Store_RequisitionDetail RD With (NoLock) " & _
                        " LEFT JOIN Store_Item I With (NoLock) ON I.Code=RD.Item " & _
                        " WHERE RD.DocId = '" & bRequisitionDocId & "' "
                DGL2.AgHelpDataSet(Col2Item, 7) = AgL.FillData(mQry, AgL.GcnRead)
            End If
        End If
    End Sub

    Public Sub IniRequisitionHelp(Optional ByVal All_Records As Boolean = True, Optional ByVal bIndentDocId As String = "")
        If All_Records = True Then
            mQry = " SELECT R.DocID AS Code,R.V_Type + '-' +convert(NVARCHAR(5),R.V_No) AS Requisition ," & _
                    " R.Div_Code ," & _
                    " 1 AS CountItem, Vt.NCat " & _
                    " FROM Store_Requisition R With (NoLock) " & _
                    " LEFT JOIN Voucher_Type Vt With (NoLock) On R.V_Type = Vt.V_Type where Vt.NCat in ('" & ClsMain.Temp_NCat.Requistion & "')"
            DGL2.AgHelpDataSet(Col2RequisionNo, 3) = AgL.FillData(mQry, AgL.GcnRead)
        Else
            If bIndentDocId <> "" Then
                mQry = " SELECT R.DocID AS Code,R.V_Type + '-' +convert(NVARCHAR(5),R.V_No) AS Requisition ," & _
                        " R.Div_Code ," & _
                        " V1.CountItem, Vt.NCat  " & _
                        " FROM Store_Requisition R With (NoLock) " & _
                        " LEFT JOIN  " & _
                        " ( " & _
                        " SELECT COUNT(RD.Item) AS CountItem ,RD.DocId " & _
                        " FROM Store_RequisitionDetail RD With (NoLock) " & _
                        " GROUP BY RD.DocId " & _
                        " ) V1 ON V1.DocId = R.DocID " & _
                        " LEFT JOIN Voucher_Type Vt With (NoLock) On R.V_Type = Vt.V_Type where Vt.NCat in ('" & ClsMain.Temp_NCat.Requistion & "')"
                DGL2.AgHelpDataSet(Col2RequisionNo, 3) = AgL.FillData(mQry, AgL.GcnRead)
            End If
        End If
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblValTotalQty.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                'Footer Calculation
                LblValTotalQty.Text = Val(LblValTotalQty.Text) + Val(Dgl1.Item(Col1IndentQty, I).Value)
            End If
        Next
        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")


        LblTotalReqQty.Text = 0
        For I = 0 To DGL2.RowCount - 1
            If DGL2.Item(Col2Item, I).Value <> "" Then
                'Footer Calculation
                LblTotalReqQty.Text = Val(LblTotalReqQty.Text) + Val(DGL2.Item(Col2ReqQty, I).Value)
            End If
        Next
        LblTotalReqQty.Text = Format(Val(LblTotalReqQty.Text), "0.000")

    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim I As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtSubCode, LblSubCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL2)
            If AgCL.AgIsBlankGrid(DGL2, DGL2.Columns(Col2Item).Index) Then Exit Function
            If AgCL.AgIsDuplicate(DGL2, " " & DGL2.Columns(Col2Item).Index & " , " & DGL2.Columns(Col2RequisionNo).Index & " ") Then Exit Function

            With DGL2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Item, I).Value <> "" Then
                        If Val(.Item(Col2ReqQty, I).Value) = 0 Then
                            MsgBox("Qty Is 0 At Row No " & DGL2.Item(ColSNo, I).Value & "")
                            .CurrentCell = .Item(Col2ReqQty, I) : DGL2.Focus()
                            Exit Function
                        End If
                    End If
                Next
            End With

            If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then Exit Function
            If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1Item).Index) Then Exit Function

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        If Val(.Item(Col1IndentQty, I).Value) = 0 Then
                            MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                            .CurrentCell = .Item(Col1IndentQty, I) : Dgl1.Focus()
                            Exit Function
                        End If
                    End If
                Next
            End With

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_PurchIndent H With (NoLock) " & _
                        " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type " & _
                        " WHERE Vt.NCat In (" & Me.EntryNCatList & ") " & _
                        " And H.ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & " " & _
                        " AND H.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar > 0 Then
                    MsgBox(LblReferenceNo.Text & " Already Exists!...")
                    TxtReferenceNo.Focus() : Exit Function
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Function

    Public Sub Form_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        LblValTotalQty.Text = 0
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        LblTotalReqQty.Text = 0
        LblPrefix.Text = ""
        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtV_Type.Enter, TxtRemark.Enter, TxtSubCode.Enter
        Try
            Select Case sender.name
                Case TxtSubCode.Name
                    TxtSubCode.AgRowFilter = " [Is Active] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, TxtSubCode.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtV_Type.Name
                    Call IniGrid()

                Case TxtSubCode.Name
                    Call Validating_Controls(sender)
            End Select

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AgL.XNull(LblReferenceNo.Tag).ToString.Trim = "" Then
                LblPrefix.Text = AgL.DeCodeDocID(TxtDocId.Text.Trim, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
                Call ProcFillReferenceNo()
            End If


            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If AgL.XNull(TxtV_Type.AgSelectedValue).ToString.Trim <> "" _
                And AgL.XNull(LblPrefix.Text).ToString.Trim <> "" _
                And Val(TxtV_No.Text) > 0 Then

                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + LblPrefix.Text + "-" + TxtV_No.Text
                LblReferenceNo.Tag = TxtReferenceNo.Text
            End If
        End If
    End Sub

    Public Sub Form_BaseFunction_DispText(ByVal Enb As Boolean) Handles Me.BaseFunction_DispText
        'Coding To Enable/Disable Controls.

        If Enb Then
            '<Executable Code>
        End If
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer
        mRowIndex = DGL2.CurrentCell.RowIndex
        mColumnIndex = DGL2.CurrentCell.ColumnIndex

        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Store & "' "
        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
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
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillRequisitionDetail()
        IniItemHelp()
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim I As Integer = 0
        Dim DsTemp As DataSet
        Dim bConStr$ = ""


        bConStr = " Vt.NCat In ('" & ClsMain.Temp_NCat.Requistion & "') "



        mQry = " SELECT R.DocID, RD.Item ,RD.ItemDescription,RD.Remark,RD.UID,RD.Unit,RD.Qty , " & _
                " RD.RequireDate  " & _
                " FROM Store_Requisition R WITH (noLock) " & _
                " LEFT JOIN Store_RequisitionDetail RD WITH (noLock) ON RD.DocId=R.DocID  " & _
                " LEFT JOIN Voucher_Type Vt On R.V_Type = VT.V_Type " & _
                " WHERE " & bConStr & " And R.V_Date <='" & TxtV_Date.Text & "'  " & _
                " AND RD.UID NOT IN(SELECT RequireUID FROM  Store_PurchIndentReq P WITH (noLock) Where 1=1 and RequireUID IS NOT null And " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " P.DocId <> '" & mSearchCode & "' ") & " ) "

        DsTemp = AgL.FillData(mQry, AgL.GcnRead)
        With DsTemp.Tables(0)
            DGL2.RowCount = 1
            DGL2.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    DGL2.Rows.Add()
                    DGL2.Item(ColSNo, I).Value = DGL2.Rows.Count - 1
                    DGL2.AgSelectedValue(DGL2.Columns(Col2RequisionNo).Index, I) = AgL.XNull(.Rows(I)("DocID"))
                    DGL2.AgSelectedValue(DGL2.Columns(Col2Item).Index, I) = AgL.XNull(.Rows(I)("Item"))
                    DGL2.Item(DGL2.Columns(Col2ItemDescription).Index, I).Value = AgL.XNull(.Rows(I)("ItemDescription"))
                    DGL2.Item(DGL2.Columns(Col2ReqQty).Index, I).Value = AgL.VNull(.Rows(I)("Qty"))
                    DGL2.Item(DGL2.Columns(Col2Unit).Index, I).Value = AgL.XNull(.Rows(I)("Unit"))
                    DGL2.Item(DGL2.Columns(Col2ReqDate).Index, I).Value = AgL.XNull(.Rows(I)("RequireDate"))
                    DGL2.Item(DGL2.Columns(Col2Remark).Index, I).Value = AgL.XNull(.Rows(I)("Remark"))
                    DGL2.Item(DGL2.Columns(Col2Requid).Index, I).Value = AglObj.XNull(.Rows(I)("UID").ToString)


                Next I
            End If
        End With
    End Sub

    Private Sub BtnFillRequisition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillRequisition.Click
        If TxtV_Date.Text <> "" Then
            Call ProcFillRequisitionDetail()
        Else
            MsgBox("Please fill Indent date to proceed.")
        End If
    End Sub


    Private Sub Dgl2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        mRowIndex = DGL2.CurrentCell.RowIndex
        mColumnIndex = DGL2.CurrentCell.ColumnIndex

        Select Case DGL2.Columns(DGL2.CurrentCell.ColumnIndex).Name
            Case Col2RequisionNo
                Call IniRequisitionHelp(False)
                DGL2.AgRowFilter(DGL2.Columns(Col2RequisionNo).Index) = "  Div_Code = '" & TxtDivision.AgSelectedValue & "'  AND CountItem IS NOT NULL "
            Case Col2Item
                If DGL2.AgSelectedValue(Col2RequisionNo, mRowIndex) <> "" Then
                    Call IniItemHelp(False, DGL2.AgSelectedValue(Col2RequisionNo, mRowIndex))
                Else
                    Call IniItemHelp()
                    'Dgl2.AgRowFilter(Dgl2.Columns(Col2Item).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                End If
        End Select
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL2.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Dgl2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex
            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL2.Columns(DGL2.CurrentCell.ColumnIndex).Name
                Case Col2Item
                    Validating_ReqItem(DGL2.AgSelectedValue(Col2Item, mRowIndex), mRowIndex)
                Case Col2RequisionNo
                    If DGL2.AgSelectedValue(Col2RequisionNo, mRowIndex) <> "" Then
                        DGL2.AgSelectedValue(Col2Item, mRowIndex) = ""
                        Validating_ReqItem(DGL2.AgSelectedValue(Col2Item, mRowIndex), mRowIndex)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_ReqItem(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If DGL2.Item(Col2Item, mRow).Value.ToString.Trim = "" Or DGL2.AgSelectedValue(Col2Item, mRow).ToString.Trim = "" Then
                DGL2.Item(Col2Unit, mRow).Value = ""
                DGL2.Item(Col2ReqQty, mRow).Value = 0
                DGL2.Item(Col2ReqDate, mRow).Value = ""
                DGL2.Item(Col2Requid, mRow).Value = ""
                DGL2.Item(Col2ItemDescription, mRow).Value = ""
                DGL2.Item(Col2Remark, mRow).Value = ""
            Else
                If DGL2.AgHelpDataSet(Col2Item) IsNot Nothing Then
                    DrTemp = DGL2.AgHelpDataSet(Col2Item).Tables(0).Select("Code = '" & Code & "'")
                    DGL2.Item(Col2ReqQty, mRow).Value = AgL.VNull(DrTemp(0)("Qty"))
                    DGL2.Item(Col2Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    DGL2.Item(Col2ReqDate, mRow).Value = AgL.XNull(DrTemp(0)("RequireDate"))
                    DGL2.Item(Col2ItemDescription, mRow).Value = AgL.XNull(DrTemp(0)("ItemDescription"))
                    DGL2.Item(Col2Requid, mRow).Value = AglObj.XNull(DrTemp(0)("UID").ToString)
                    DGL2.Item(Col2Remark, mRow).Value = AgL.XNull(DrTemp(0)("Remark"))

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_ReqItem Function ")
        End Try
    End Sub

    Private Sub ProcFillIndentDetail()
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim I As Integer = 0
        Dim DsTemp As DataSet

        mQry = "  Declare @TmpTable as Table " & _
                    " ( " & _
                    " RequisionNo nVarchar(21), " & _
                    " Item nVarchar(10), " & _
                      " ItemDescription nVarchar(255), " & _
                    " Qty Float, " & _
                    " Unit nVarchar(10), " & _
                    " ReqDate SmallDateTime " & _
                    " )"

        For I = 0 To DGL2.RowCount - 1
            mQry += " Insert Into @TmpTable(  " & _
                " RequisionNo, " & _
                " Item,   " & _
                " ItemDescription,   " & _
                " Qty,   " & _
                " Unit,   " & _
                " ReqDate " & _
                " ) " & _
                " Values ( " & _
                " " & AgL.Chk_Text(DGL2.AgSelectedValue(Col2RequisionNo, I)) & ", " & _
                " " & AgL.Chk_Text(DGL2.AgSelectedValue(Col2Item, I)) & ", " & _
                 " " & AgL.Chk_Text(DGL2.Item(Col2ItemDescription, I).Value) & ", " & _
                " " & Val(DGL2.Item(Col2ReqQty, I).Value) & ", " & _
                " " & AgL.Chk_Text(DGL2.Item(Col2Unit, I).Value) & ", " & _
                " " & AgL.Chk_Text(DGL2.Item(Col2ReqDate, I).Value) & " " & _
                ")"
        Next

        mQry += " Select Item,sum(isnull(Qty,0)) AS Qty,max(ItemDescription) AS ItemDescription,max(unit) AS Unit, " & _
                " min(ReqDate) AS ReqDate " & _
                " from @TmpTable " & _
                " WHERE Item IS NOT NULL " & _
                " GROUP BY Item "

        DsTemp = AgL.FillData(mQry, AgL.GcnRead)
        With DsTemp.Tables(0)
            Dgl1.RowCount = 1
            Dgl1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    Dgl1.Rows.Add()
                    Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                    Dgl1.AgSelectedValue(Dgl1.Columns(Col1Item).Index, I) = AgL.XNull(.Rows(I)("Item"))
                    Dgl1.Item(Dgl1.Columns(Col1IndentQty).Index, I).Value = AgL.VNull(.Rows(I)("Qty"))
                    Dgl1.Item(Dgl1.Columns(Col1ReqQty).Index, I).Value = AgL.VNull(.Rows(I)("Qty"))
                    Dgl1.Item(Dgl1.Columns(Col1Unit).Index, I).Value = AgL.XNull(.Rows(I)("Unit"))
                    Dgl1.Item(Dgl1.Columns(Col1ItemDescription).Index, I).Value = AgL.XNull(.Rows(I)("ItemDescription"))
                    Dgl1.Item(Dgl1.Columns(Col1ReqDate).Index, I).Value = AgL.XNull(.Rows(I)("ReqDate"))



                Next I
            End If
        End With
        Call Calculation()
    End Sub

    Private Sub BtnFillIndentDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillIndentDetail.Click
        Call ProcFillIndentDetail()
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Public Sub FrmMaterialVerification_BaseEvent_Approve_PreTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Approve_PreTrans
        '------------------------------------------------------------------------
        '<Executable Code For Before Record Apporval>
        '-------------------------------------------------------------------------  
    End Sub

    Public Sub Form_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        '------------------------------------------------------------------------
        '<Executable Code For Record Apporval>
        '-------------------------------------------------------------------------        
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try

            Dim bRData As String
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT @Temp=@Temp+ X.VNo + ',' FROM (Select Distinct H.V_Type + '-' + Convert(VARCHAR,H.V_No) as VNo From Store_PurchOrderDetail L LEFT JOIN Store_PurchOrder H ON L.DocId = H.DocID WHERE L.PurchIndentDocID = '" & TxtDocId.Text & "') As X "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Order " & bRData & " created against Indent No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Purchase Indent"
            RepName = "Store_PurchIndent_Print" : RepTitle = AgL.PubReportTitle
            bTableName = "Store_PurchIndent" : bSecTableName = "Store_PurchIndentDetail P1 ON P1.DocID =P.DocID"
            bCondstr = "WHERE P.DocID='" & SearchCode & "' and Vt.NCat in (" & EntryNCatList & ")"


            strQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
                    " P.subcode, P1.Remark, P.TotalQty,P.ReferenceNo,P.Remark as Remarkheader, " & _
                    " P1.Sr, P1.Item,  P1.RequireQty, P1.IndentQty, P1.Unit, " & _
                    " P1.RequireDate,SM.Name AS SiteName,  " & _
                    " I.Description AS ItemName,Sg.Name AS Indentor,P1.ItemDescription " & _
                    " FROM " & bTableName & " P " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=P1.Item " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=P.Subcode " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type  " & _
                    " " & bCondstr & ""

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

End Class
