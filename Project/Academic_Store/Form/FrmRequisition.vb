Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRequisition
    Inherits Academic_ProjLib.TempTransaction
    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Private mBlnIsApproved As Boolean = False

    Dim mQry$

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1Item As String = "Item"
    Protected Const Col1ItemDescription As String = "Item Description"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1RequireDate As String = "Require Date"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1UID As String = "UID"
    Protected Const Col1TempUID As String = "TempUID"


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
    Protected WithEvents txtDepartment As AgControls.AgTextBox
    Protected WithEvents lblDepartment As System.Windows.Forms.Label
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalOty As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
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
        Me.txtDepartment = New AgControls.AgTextBox
        Me.lblDepartment = New System.Windows.Forms.Label
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalQty = New System.Windows.Forms.Label
        Me.LblTextTotalOty = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
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
        Me.TP1.Controls.Add(Me.lblDepartment)
        Me.TP1.Controls.Add(Me.txtDepartment)
        Me.TP1.Size = New System.Drawing.Size(984, 126)
        Me.TP1.Controls.SetChildIndex(Me.txtDepartment, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblDepartment, 0)
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
        Me.Topctrl1.TabIndex = 2
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
        Me.LblSubCode.Size = New System.Drawing.Size(86, 15)
        Me.LblSubCode.TabIndex = 1022
        Me.LblSubCode.Text = "Requisition By"
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
        Me.TxtRemark.Location = New System.Drawing.Point(617, 68)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(304, 18)
        Me.TxtRemark.TabIndex = 7
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(487, 70)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(51, 15)
        Me.LblRemark.TabIndex = 1024
        Me.LblRemark.Text = "Remark"
        '
        'txtDepartment
        '
        Me.txtDepartment.AgAllowUserToEnableMasterHelp = False
        Me.txtDepartment.AgMandatory = True
        Me.txtDepartment.AgMasterHelp = False
        Me.txtDepartment.AgNumberLeftPlaces = 0
        Me.txtDepartment.AgNumberNegetiveAllow = False
        Me.txtDepartment.AgNumberRightPlaces = 0
        Me.txtDepartment.AgPickFromLastValue = False
        Me.txtDepartment.AgRowFilter = ""
        Me.txtDepartment.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtDepartment.AgSelectedValue = Nothing
        Me.txtDepartment.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtDepartment.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDepartment.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(617, 48)
        Me.txtDepartment.MaxLength = 20
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(304, 18)
        Me.txtDepartment.TabIndex = 6
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.Location = New System.Drawing.Point(487, 50)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(72, 15)
        Me.lblDepartment.TabIndex = 1027
        Me.lblDepartment.Text = "Department"
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalQty)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalOty)
        Me.PnlFooter.Location = New System.Drawing.Point(12, 513)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(965, 24)
        Me.PnlFooter.TabIndex = 741
        '
        'LblValTotalQty
        '
        Me.LblValTotalQty.AutoSize = True
        Me.LblValTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalQty.Location = New System.Drawing.Point(613, 4)
        Me.LblValTotalQty.Name = "LblValTotalQty"
        Me.LblValTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalQty.TabIndex = 680
        Me.LblValTotalQty.Text = "."
        Me.LblValTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalOty
        '
        Me.LblTextTotalOty.AutoSize = True
        Me.LblTextTotalOty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalOty.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalOty.Location = New System.Drawing.Point(516, 4)
        Me.LblTextTotalOty.Name = "LblTextTotalOty"
        Me.LblTextTotalOty.Size = New System.Drawing.Size(73, 16)
        Me.LblTextTotalOty.TabIndex = 679
        Me.LblTextTotalOty.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 192)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(973, 321)
        Me.Pnl1.TabIndex = 1
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 169)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(160, 20)
        Me.LinkLabel1.TabIndex = 742
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "REQUISITION DETAILS:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmRequisition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmRequisition"
        Me.Controls.SetChildIndex(Me.Tc1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GBoxModified, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxApproved, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.PnlFooter, 0)
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
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.Requistion) & ""
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
        Public Shared Department As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared Unit As DataSet = Nothing
    End Class

    Public Sub Form_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Store_Requisition"
        AglObj = AgL

        LblV_Type.Text = "Entry Type"
        LblV_Date.Text = "Entry Date"
        LblV_No.Text = "Entry No."
        TP1.Text = "Tp1"

        AgL.GridDesign(DGL1)
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
                " From Store_Requisition H With (NoLock) " & _
                " Left Join Voucher_Type Vt With (NoLock) On H.V_Type = Vt.V_Type  " & _
                " Where 1=1 " & mCondStr & " " & _
                " Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, GcnRead, mQry, , , , , BytDel, BytRefresh)

        If GcnRead IsNot Nothing Then GcnRead.Dispose()
    End Sub
    Public Sub Form_BaseEvent_Find() Handles Me.BaseEvent_Find
        Dim mCondStr$ = " Where 1=1 "

        mCondStr += " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "
        mCondStr += " And Vt.NCat in (" & EntryNCatList & ")"

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                mCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                mCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        AgL.PubFindQry = "SELECT H.DocId AS SearchCode, " & _
                            " " & AgL.V_No_Field("H.DocId") & " As [" & LblV_No.Text & "], " & _
                            " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                            " H.ReferenceNo As [" & LblReferenceNo.Text & "], " & _
                            " Sg.Name As [" & LblSubCode.Text & "], " & _
                            " D.Description As [" & lblDepartment.Text & "], " & _
                            " H.Remark As [" & LblRemark.Text & "], " & _
                            " Convert(Varchar,H.TotalQty) As [" & LblTextTotalOty.Text & "], " & _
                            " S.Name AS [" & LblSite_Code.Text & "] " & _
                            " FROM Store_Requisition H With (NoLock) " & _
                            " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                            " LEFT JOIN SiteMast S ON S.Code = H.Site_Code " & _
                            " Left Join SubGroup Sg With (NoLock) On H.SubCode = Sg.SubCode " & _
                            " Left Join Sch_Department D With (NoLock) On D.Code = H.Department " & _
                            mCondStr

        AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc, [" & LblSubCode.Text & "] "

    End Sub

    Public Sub Form_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        DGL1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 50, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Item, 230, 0, Col1Item, True, False, False)
            .AddAgTextColumn(DGL1, Col1ItemDescription, 200, 255, Col1ItemDescription, True, False, False)
            .AddAgTextColumn(DGL1, Col1Unit, 70, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(DGL1, Col1Qty, 90, 8, 3, False, Col1Qty, True, False, True)
            .AddAgDateColumn(DGL1, Col1RequireDate, 100, Col1RequireDate, True, False, False)
            .AddAgTextColumn(DGL1, Col1Remark, 200, 255, Col1Remark, True, False, False)
            .AddAgTextColumn(DGL1, Col1UID, 80, 0, Col1UID, False, True, False)
            .AddAgTextColumn(DGL1, Col1TempUID, 80, 0, Col1TempUID, False, True, False)

        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.Anchor = AnchorStyles.None
        PnlFooter.Anchor = DGL1.Anchor
        DGL1.ColumnHeadersHeight = 40
        Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

        Form_BaseFunction_FIniList()
    End Sub

    Public Sub Form_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Dim bIntI As Integer = 0, bIntSr As Integer = 0, bStrLineUid$ = ""



        mQry = "UPDATE dbo.Store_Requisition " & _
                " SET " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                " Department = " & AgL.Chk_Text(txtDepartment.AgSelectedValue) & ", " & _
                " TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemark.Text) & " " & _
                " Where DocId = " & AgL.Chk_Text(SearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Store_RequisitionDetail WHERE DocId = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If


        bIntSr = 0
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                bIntSr += 1

                If AglObj.XNull(DGL1.Item(Col1TempUID, bIntI).Value).ToString.Trim = "" Then
                    If AglObj.XNull(DGL1.Item(Col1UID, bIntI).Value).ToString.Trim = "" Then
                        DGL1.Item(Col1UID, bIntI).Value = AglObj.GetGUID(AgL.Gcn_ConnectionString).ToString
                    End If
                End If

                bStrLineUid = DGL1.Item(Col1UID, bIntI).Value

                mQry = "INSERT INTO dbo.Store_RequisitionDetail ( " & _
                        " DocId, Sr, Item, ItemDescription,Unit,Qty,Remark,Uid,RequireDate) " & _
                        " VALUES (" & AgL.Chk_Text(SearchCode) & ", " & bIntSr & ", " & _
                       " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1ItemDescription, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.AgSelectedValue(Col1Unit, bIntI)) & ", " & _
                        " " & Val(DGL1.Item(Col1Qty, bIntI).Value) & ", " & _
                        " " & AglObj.Chk_Text(DGL1.Item(Col1Remark, bIntI).Value) & " , " & AglObj.Chk_Text(bStrLineUid) & " ," & AgL.ConvertDate(DGL1.Item(Col1RequireDate, bIntI).Value.ToString) & "" & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, bIntSr, bIntI, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmPurchaseInvoice_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        '<Executable code>
    End Sub


    Public Sub Form_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
        Dim bIntI As Integer = 0
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet
        Dim DtTemp As DataTable = Nothing

        Dim mTransFlag As Boolean = False

        mQry = "Select H.* " & _
            " From Store_Requisition H With (NoLock) " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GcnRead)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                LblReferenceNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                Call Validating_Controls(TxtSubCode)
                txtDepartment.AgSelectedValue = AgL.XNull(.Rows(0)("Department"))

                TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                LblValTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")

                mQry = "Select L.* " & _
                        " From Store_RequisitionDetail L With (NoLock) " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr"
                DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtTemp
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If DtTemp.Rows.Count > 0 Then
                        For bIntI = 0 To DtTemp.Rows.Count - 1
                            DGL1.Rows.Add()

                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1UID, bIntI).Value = AglObj.XNull(.Rows(bIntI)("UID").ToString)
                            DGL1.Item(Col1TempUID, bIntI).Value = AglObj.XNull(.Rows(bIntI)("UID").ToString)
                            DGL1.AgSelectedValue(Col1Item, bIntI) = AglObj.XNull(.Rows(bIntI)("Item"))
                            DGL1.Item(Col1ItemDescription, bIntI).Value = AglObj.XNull(.Rows(bIntI)("ItemDescription"))
                            DGL1.AgSelectedValue(Col1Unit, bIntI) = AglObj.XNull(.Rows(bIntI)("Unit"))
                            DGL1.Item(Col1Qty, bIntI).Value = Format(AglObj.VNull(.Rows(bIntI)("Qty")), "0.000")
                            DGL1.Item(Col1Remark, bIntI).Value = AglObj.XNull(.Rows(bIntI)("Remark"))
                            DGL1.Item(Col1RequireDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("RequireDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)



                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                        Next bIntI
                    End If
                End With
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
                    txtDepartment.Text = ""
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

        Topctrl1.ChangeAgGridState(DGL1, False)
    End Sub

    Public Sub Form_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        IniGrid()
        Tc1.SelectedTab = TP1

        TxtPrepared.Text = AgL.PubUserName

        If TxtV_Date.Text.Trim = "" Then
            TxtV_Date.Text = AgL.PubLoginDate
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


            mQry = "SELECT D.Code AS Code, D.Description AS Name FROM Sch_Department D With (NoLock)  ORDER BY D.Code"
            HelpDataSet.Department = AglObj.FillData(mQry, GcnRead)

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
        txtDepartment.AgHelpDataSet(0, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = HelpDataSet.Department.Copy

        DGL1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.Item.Copy
        DGL1.AgHelpDataSet(Col1Unit) = HelpDataSet.Unit.Copy
    End Sub

    Public Sub Form_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim bIntI As Integer, bIntTotalDays As Integer = 0

        LblValTotalQty.Text = 0

        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
            If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""

            If DGL1.Item(Col1Qty, bIntI).Value <> "" Then
                'Footer Calculation
                LblValTotalQty.Text = Val(LblValTotalQty.Text) + Val(DGL1.Item(Col1Qty, bIntI).Value)
            End If
        Next
        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")

    End Sub

    Public Sub Form_BaseEvent_Data_Validation(ByRef Passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Not Data_Validation() Then Passed = False : Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection

        Try
            If AglObj.RequiredField(TxtSubCode, LblSubCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
                If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""

                If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                    If Val(DGL1.Item(Col1Qty, bIntI).Value) = 0 Then
                        MsgBox("Item Quantity Is Required At Row No. : " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1Qty, bIntI) : DGL1.Focus() : Exit Function
                    End If
                End If
            Next

            If TxtReferenceNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_Requisition H With (NoLock) " & _
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

        LblPrefix.Text = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        mBlnIsApproved = False
    End Sub

    Public Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
      TxtV_Type.Enter, TxtRemark.Enter, TxtSubCode.Enter
        Try
            Select Case sender.name
                Case TxtSubCode.Name
                    TxtSubCode.AgRowFilter = " [Is Active] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
      TxtV_Type.Validating, TxtRemark.Validating, TxtDivision.Validating, TxtDocId.Validating, TxtReferenceNo.Validating, _
      TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_No.Validating, TxtRemark.Validating, _
      TxtSubCode.Validating

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

    Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    DGL1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Store & "' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AglObj.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1Item
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AgL.XNull(DrTemp(0)("Unit"))
                            End If
                            DrTemp = Nothing
                        End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Try
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                'Case ColumnIndex
                '<Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
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
            mQry += " SELECT @Temp=@Temp+ X.VNo + ',' FROM (Select Distinct H.V_Type + '-' + Convert(VARCHAR,H.V_No) as VNo From Store_PurchIndentReq L LEFT JOIN Store_PurchIndent H ON L.DocId = H.DocID WHERE RequisitionDocID = '" & TxtDocId.Text & "') As X "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Indent " & bRData & " created against Requisition No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function
    Private Sub FrmRequisition_BaseEvent_Topctrl_tbEdit() Handles Me.BaseEvent_Topctrl_tbEdit
        If FGetRelationalData() = True Then
            Exit Sub
        End If
    End Sub

    Private Sub FrmRequisition_BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Topctrl_tbDel
        If FGetRelationalData() = True Then
            Exit Sub
        End If
        mQry = "Delete From Store_RequisitionDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Store_Requisition Where DocId = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub


    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Requisition"
            RepName = "Store_Requisition_Print" : RepTitle = AgL.PubReportTitle
            bTableName = "Store_Requisition" : bSecTableName = "Store_RequisitionDetail R1 ON R1.DocID =R.DocID"
            bCondstr = "WHERE R.DocID='" & SearchCode & "' and Vt.NCat in (" & EntryNCatList & ")"

            strQry = " SELECT  R.DocID, R.V_Type, R.V_Prefix, R.V_Date, R.V_No, R.Div_Code, R.Site_Code, " & _
                    " R.Department, SG.DispName AS RequisitionBy, R1.Remark, R.TotalQty, " & _
                    " R1.Sr, R1.Item, R1.Qty, R1.Unit,R1.ItemDescription, " & _
                    " R1.RequireDate, R1.UID,  " & _
                    " SM.Name AS SiteName,I.Description AS ItemName, D.Description as DepName,R.ReferenceNo " & _
                    " FROM " & bTableName & " R " & _
                    " LEFT JOIN " & bSecTableName & " " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=R.Site_Code  " & _
                    " LEFT JOIN Store_Item I ON I.Code=R1.Item  " & _
                    " LEFT JOIN SUBGROUP SG ON SG.SubCode=R.Subcode   " & _
                    " LEFT JOIN Sch_Department D ON R.Department=D.code   " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=R.V_Type  " & _
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
