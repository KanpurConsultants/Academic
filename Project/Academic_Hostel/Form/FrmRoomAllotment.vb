Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomAllotment

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Dim mChargeDueDocId$ = "", mTransferCode$ = ""
    Dim mChargeType$ = "", mRoomType$ = "", mBuildingNature$ = ""
    Dim mAmount As Double

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Charge As Byte = 1
    Private Const Col1Amount As Byte = 2
    Private Const Col1ActualAmount As Byte = 3
    Private Const Col1ChargeType As Byte = 4
    Private Const Col1ActualChargeType As Byte = 5
    Private Const Col1ChargeTypeMonths As Byte = 6
    Private Const Col1ActualChargeTypeMonths As Byte = 7
    Private Const Col1DueMonth As Byte = 8
    Private Const Col1IsOnceInLife As Byte = 9
    Private Const Col1IsFirstTimeRequired As Byte = 10

    Dim mRoomCode$ = ""

    Public Property RoomCode() As String
        Get
            RoomCode = mRoomCode
        End Get
        Set(ByVal value As String)
            mRoomCode = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Room Charge Data Grid >====================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Charge", 200, 50, "Charge", True, True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Amount", 100, 5, 0, False, "Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "Dgl1ActualAmount", 100, 5, 0, False, "ActualAmount", False)
            .AddAgTextColumn(DGL1, "DGL1ChargeType", 100, 20, "Charge Type", True, False, False, True)
            .AddAgTextColumn(DGL1, "DGL1ActualChargeType", 100, 20, "Actual Charge Type", False)
            .AddAgNumberColumn(DGL1, "DGL1ChargeTypeMonths", 100, 5, 0, False, "ChargeTypeMonths", False)
            .AddAgNumberColumn(DGL1, "DGL1ActualChargeTypeMonths", 100, 5, 0, False, "ActualChargeTypeMonths", False)
            .AddAgListColumn(DGL1, "JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,NA", "DGL1DueMonth", 100, "JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,NA", "Due Month", True, False)
            .AddAgCheckBoxColumn(DGL1, "Dgl1IsOnceInLife", 70, "Once In Life", False)
            .AddAgCheckBoxColumn(DGL1, "Dgl1IsFirstTimeRequired", 70, "First Time Required", False)

        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False


    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If

        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If

            ' Call Calculation()
            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        'Dim FrmObj As Form
        Try
            'Me.Cursor = Cursors.WaitCursor
            'If Topctrl1.Mode = "Browse" Then Exit Sub
            'Select Case Sender.name
            '    'Case <Sender>.Name
            '    'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
            '    Case TxtMemberName.Name
            '        Dim MDI As New MDIMain
            '        FrmObj = PObj.FOpen_LinkForm_Academic_Main(MDI.MnuStudentMaster.Name, MDI.MnuStudentMaster.Text, Me.MdiParent)
            '        If FrmObj IsNot Nothing Then
            '            CType(FrmObj, FrmStudentMaster).RegistrationDocId = TxtRegistrationDocId.AgSelectedValue
            '        End If
            '        MDI = Nothing
            'End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 584, 956, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("A.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select A.DocId As SearchCode " & _
                    " From Ht_RoomAllotment A " & _
                    " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()

        mQry = "Select Code As Code, Name As Name " & _
                " From SiteMast " & _
                " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " " & _
                " Order By Name "
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat " & _
                  " From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomAllotment) & "" & _
                  " Order By Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT H.Code AS Code,H.ManualCode AS Description " & _
                " FROM Ht_Hostel H " & _
                " Where " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "
        TxtHostel.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        'mQry = "SELECT VHR.Code,VHR.BuildingFloorRoomDesc AS RoomDescription,VHR.TotalBed,VHR.HostelCode, VHR.RoomType  " & _
        '        " FROM ViewHt_Room VHR  " & _
        '        " Where " & AgL.PubSiteCondition("VHR.Site_Code", AgL.PubSiteCode) & " "


        mQry = "SELECT Vhr.Code,Vhr.BuildingFloorRoomDesc AS RoomDescription,Vhr.TotalBed, " & _
                " Vhr.RoomTypeDesc, Vhr.RoomType, Vhr.HostelCode, isnull(V1.MembersInRoom,0) AS TotalMembers, Vhr.BuildingNature ,  " & _
                " (IsNull(Vhr.TotalBed,0) - isnull(V1.MembersInRoom,0)) AS RoomStatus,VHR.IsRoomAllocatable  " & _
                " FROM ViewHt_Room Vhr " & _
                " LEFT JOIN (SELECT Vhr.Room,count(Vhr.AllotmentDocId) AS MembersInRoom " & _
                " 			FROM ViewHt_RoomTransfer Vhr " & _
                "           WHERE(Vhr.TransferDate Is NULL And Vhr.LeftDate Is NULL) " & _
                " 			GROUP BY Vhr.Room) AS  V1 " & _
                " ON Vhr.Code=V1.Room  " & _
                " Where " & AgL.PubSiteCondition("Vhr.Site_Code", AgL.PubSiteCode) & " "
        TxtRoom.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vsg.SubCode, Vsg.Name as Name, Vsg.FatherName, vSg.MemberType, Vsg.DispName, Vsg.Sex ,  " & _
                " CASE WHEN V1.MemberCode IS NULL THEN 0 ELSE 1 END AS IsHostelMember " & _
                " FROM ViewHt_SubGroup Vsg " & _
                " LEFT JOIN (SELECT Vra.MemberCode FROM ViewHt_RoomAllotment Vra WHERE Vra.LeftDate IS NULL) AS V1 ON Vsg.SubCode = V1.MemberCode " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Vsg.Site_Code", AgL.PubSiteCode, "Vsg.CommonAc") & "" & _
                " ORDER BY Vsg.DispName "
        TxtMemberName.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT HC.SubCode AS Code,Sg. Name  as Description" & _
               " FROM Ht_Charge HC " & _
               " LEFT JOIN SubGroup Sg ON HC.SubCode=Sg.SubCode " & _
               " Where " & AgL.PubSiteCondition("HC.Site_Code", AgL.PubSiteCode) & " "
        DGL1.AgHelpDataSet(Col1Charge) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT FT.Code AS Code,FT.Code AS Description,FT.Months" & _
               " FROM Sch_FeeType FT "
        DGL1.AgHelpDataSet(Col1ChargeType) = AgL.FillData(mQry, AgL.GCn)


    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Ht_RoomAllotmentChargeDue WHERE AllotmentDocId= '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeDueLedgerM Where DocId = '" & mChargeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mChargeDueDocId)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeDue1 Where DocId = '" & mChargeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeDue Where DocId = '" & mChargeDueDocId & "'", AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Ht_RoomTransferCharge Where RoomTransfer='" & mTransferCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_RoomTransfer Where AllotmentDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_RoomAllotment Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, TxtMemberName.AgSelectedValue, TxtMemberName.Text, , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl_tbRef()
                    Else
                        AgL.PubSearchRow = ""
                    End If
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("HRA.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("HRA.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = " SELECT HRA.DocId As SearchCode, " & AgL.V_No_Field("HRA.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], HRA.V_Date, " & _
                                " Sg.DispName as [Member Name],HR.BuildingFloorRoomDesc as [Room]   " & _
                                " FROM Ht_RoomAllotment HRA " & _
                                " LEFT JOIN Voucher_Type Vt ON HRA.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON HRA.Site_Code = S.Code " & _
                                " LEFT JOIN Ht_RoomTransfer HRT ON HRA.DocId=HRT.AllotmentDocId " & _
                                " AND HRT.AllotmentType = '" & AllotmentType_Allotment & "'" & _
                                " LEFT JOIN ViewHt_SubGroup Sg ON Sg.SubCode=HRT.SubCode " & _
                                " LEFT JOIN ViewHt_Room HR ON HR.Code=HRT.Room " & _
                                " " & mCondStr

            AgL.PubFindQryOrdBy = "[Voucher No]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Room Allotment"
            RepName = "Hostel_RoomAllotment" : RepTitle = "Room Allotment"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT Vra.DocId, " & AgL.V_No_Field("VRA.DocId") & " AS VoucherNo,Vra.Div_Code, Vra.Site_Code, Vra.V_Date, Vra.V_Type, Vra.V_Prefix, " & _
                        " Vra.V_No, Vra.Remark, Vra.PreparedBy, Vra.U_EntDt, Vra.U_AE, Vra.Edit_Date, Vra.ModifiedBy, " & _
                        " Vra.MemberCode, Vra.RoomCode, Vra.FirstTransferDate, Vra.FirstTransferRemark, Vra.AllotmentType, " & _
                        " Vra.LeftDate, Vra.LeftRemark, Vra.LeftRoomCode, Vra.MemberName,Vra.MemberDispName, " & _
                        " Vra.MemberType, Vra.MemberManualCode, Vra.FatherName, Vra.Phone, Vra.Mobile, Vra.FAX, " & _
                        " Vra.EMail, Vra.Add1, Vra.Add2, Vra.Add3, Vra.PIN, Vra.CityName, Vra.State_Desc, " & _
                        " Vra.StateShortName, Vra.Country, Vr.BuildingFloorRoomDesc, Vr.HostelDesc , " & _
                        " Rtc.Sr, Vc.ChargeDispName, Vc.ChargeGroup, Vc.ChargeNature, Rtc.Amount, " & _
                        " Rtc.DueMonth, Rtc.IsOnceInLife, Rtc.IsFirstTimeRequired, Rtc.ChargeType " & _
                        " FROM ViewHt_RoomAllotment Vra " & _
                        " LEFT JOIN ViewHt_Room Vr ON Vra.RoomCode = Vr.Code " & _
                        " LEFT JOIN Ht_RoomTransfer Rt ON Vra.DocId=Rt.AllotmentDocId AND Rt.AllotmentType='" & AllotmentType_Allotment & "' " & _
                        " LEFT JOIN Ht_RoomTransferCharge Rtc ON Rt.Code=Rtc.RoomTransfer " & _
                        " LEFT JOIN ViewHt_Charge Vc ON Rtc.Charge=Vc.SubCode " & _
                        " WHERE Vra.DocId='" & mSearchCode & "'"


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Hostel & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Hostel & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim bChargeDueObj As New Struct_ChargeDue, bChargeDue1Obj() As Struct_ChargeDue1 = Nothing

        Dim GcnRead As SqlClient.SqlConnection

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then

                mQry = "INSERT INTO dbo.Ht_RoomAllotment(DocId,Div_Code,Site_Code, " & _
                     " V_Date,V_Type,V_Prefix,V_No, SubCode, MemberType, " & _
                     " Remark,PreparedBy,U_EntDt,U_AE) " & _
                     " VALUES('" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ",  " & _
                     " " & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                     " " & AgL.Chk_Text(LblPrefix.Text) & "," & Val(TxtV_No.Text) & ", " & _
                     " " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & ", " & _
                     " " & AgL.Chk_Text(TxtMemberType.Text) & ", " & _
                     " " & AgL.Chk_Text(TxtRemark.Text) & ",'" & AgL.PubUserName & "', " & _
                     " '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "','A') "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


                mQry = " INSERT INTO dbo.Ht_RoomTransfer(Code,AllotmentDocId,SubCode,Room,Div_Code,Site_Code," & _
                     " AllotmentDate,AllotmentType,ChargeStartDate,PreparedBy,U_EntDt,U_AE)  " & _
                     " VALUES('" & mTransferCode & "','" & mSearchCode & "'," & _
                     " " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & " , " & _
                     " " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & " ," & _
                     " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & "," & _
                     " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                     " '" & AllotmentType_Allotment & "'," & AgL.ConvertDate(TxtV_Date.Text) & "," & _
                     " '" & AgL.PubUserName & "', " & _
                     " '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "','A') "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else
                mQry = "UPDATE dbo.Ht_RoomAllotment " & _
                      " SET " & _
                      " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                      " SubCode = " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & ", " & _
                      " MemberType = " & AgL.Chk_Text(TxtMemberType.Text) & ", " & _
                      " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                      " U_AE = 'E', " & _
                      " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                      " ModifiedBy = '" & AgL.PubUserName & "' " & _
                      " WHERE DocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = " UPDATE dbo.Ht_RoomTransfer " & _
                         " SET " & _
                         " SubCode = " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & " , " & _
                         " Room = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & " , " & _
                         " AllotmentDate = " & AgL.ConvertDate(TxtV_Date.Text) & " ," & _
                         " ChargeStartDate = " & AgL.ConvertDate(TxtV_Date.Text) & " ," & _
                         " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                         " ModifiedBy = '" & AgL.PubUserName & "' " & _
                         " WHERE Code='" & mTransferCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            End If

            '===============================================================================================================================================
            '==================< Update Current Room >==================================================================================================
            '===========================< Start >===========================================================================================================
            '===============================================================================================================================================
            If Not mObjClsMain.FunUpdateCurrentRoom(mSearchCode, AgL.GCn, AgL.ECmd) Then
                Err.Raise(1, , "Error In Current Room Updating!...")
            End If
            '===============================================================================================================================================
            '==================< Update Current Room >==================================================================================================
            '===========================< End >=============================================================================================================
            '===============================================================================================================================================


            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Ht_RoomTransferCharge WHERE RoomTransfer = '" & mTransferCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Charge, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = "INSERT INTO dbo.Ht_RoomTransferCharge(RoomTransfer, Sr, Charge, Amount, ChargeType, " & _
                                " DueMonth, IsOnceInLife, IsFirstTimeRequired ) " & _
                                " VALUES ('" & mTransferCode & "'," & mSr & "," & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1Charge, I)) & "," & _
                                " " & Val(.Item(Col1Amount, I).Value) & " , " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1ChargeType, I)) & "," & _
                                " " & AgL.Chk_Text(.Item(Col1DueMonth, I).Value) & "," & _
                                " " & IIf(.Item(Col1IsOnceInLife, I).Value, 1, 0) & " , " & _
                                " " & IIf(.Item(Col1IsFirstTimeRequired, I).Value, 1, 0) & ") "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            Call ProcCreateChargeDueStructure(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, mSearchCode, bChargeDueObj, bChargeDue1Obj, mChargeDueDocId)

            Call ProcSaveChargeDueDetail(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bChargeDueObj, bChargeDue1Obj, mSearchCode)
            Call FunChargeDueAccountPosting(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bChargeDueObj)

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Ht_RoomAllotmentChargeDue Where AllotmentDocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            mQry = " INSERT INTO dbo.Ht_RoomAllotmentChargeDue (AllotmentDocId, ChargeDueDocId) " & _
                    " VALUES(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mChargeDueDocId) & " )  "

            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)




            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, TxtMemberName.AgSelectedValue, TxtMemberName.Text, , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

            AgL.UpdateVoucherCounter(mChargeDueDocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mChargeDueDocId, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                mRoomCode = ""
                Topctrl1.LblDocId.Text = mSearchCode

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim bStreamYearSemester$ = "", bToStreamYearSemester$ = "", bLastSessionProgrammeStreamCode$ = ""
        Dim mTransFlag As Boolean = False, bIsStatusChanged As Boolean = False

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = "Select HRA.*, Vt.NCat, Hrt.Room, Hrt.AllotmentDate," & _
                       " Hrt.TransferDate, Hrt.AllotmentType, CD.ChargeDueDocId,Hrt.Code AS TransferCode " & _
                       " From Ht_RoomAllotment HRA  " & _
                       " Left Join Voucher_Type Vt On HRA.V_Type = Vt.V_Type  " & _
                       " LEFT JOIN (SELECT T.* FROM Ht_RoomTransfer T With (NoLock) WHERE T.AllotmentType = '" & AllotmentType_Allotment & "') As Hrt ON HRA.DocId=Hrt.AllotmentDocId " & _
                       " LEFT JOIN Ht_RoomAllotmentChargeDue CD ON HRA.DocId=CD.AllotmentDocId " & _
                       " Where HRA.DocId='" & mSearchCode & "' "

                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtMemberName.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                        TxtRoom.AgSelectedValue = AgL.XNull(.Rows(0)("Room"))
                        TxtMemberType.Text = AgL.XNull(.Rows(0)("MemberType"))

                        If TxtMemberName.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtMemberName.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & "")
                            If DrTemp.Length > 0 Then
                                LblMemberName.Tag = AgL.XNull(DrTemp(0)("Sex"))

                            End If
                        End If

                        If TxtRoom.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtRoom.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & "")
                            If DrTemp.Length > 0 Then
                                LblRoom.Tag = AgL.XNull(DrTemp(0)("TotalBed"))
                                LblRoomRequired.Tag = AgL.XNull(DrTemp(0)("Code"))
                                TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
                                LblHostel.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
                                mRoomType = AgL.XNull(DrTemp(0)("RoomType"))
                                mBuildingNature = AgL.XNull(DrTemp(0)("BuildingNature"))
                            End If
                        End If

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                        mChargeDueDocId = AgL.XNull(.Rows(0)("ChargeDueDocId"))
                        mTransferCode = AgL.XNull(.Rows(0)("TransferCode"))

                    End If
                End With


                mQry = "SELECT RTC.* " & _
                        " FROM Ht_RoomTransferCharge RTC " & _
                        " WHERE RTC.RoomTransfer = '" & mTransferCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1Charge, I) = AgL.XNull(.Rows(I)("Charge"))
                            DGL1.Item(Col1Amount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                            DGL1.Item(Col1ActualAmount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                            DGL1.AgSelectedValue(Col1ChargeType, I) = AgL.XNull(.Rows(I)("ChargeType"))
                            DGL1.Item(Col1ActualChargeType, I).Value = AgL.XNull(.Rows(I)("ChargeType"))
                            DGL1.Item(Col1DueMonth, I).Value = AgL.XNull(.Rows(I)("DueMonth"))
                            DGL1.Item(Col1IsOnceInLife, I).Value = AgL.XNull(.Rows(I)("IsOnceInLife"))
                            DGL1.Item(Col1IsFirstTimeRequired, I).Value = AgL.XNull(.Rows(I)("IsFirstTimeRequired"))

                            If DGL1.AgHelpDataSet(Col1ChargeType) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(Col1ChargeType).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1ChargeType, I)) & "")
                                DGL1.Item(Col1ChargeTypeMonths, I).Value = AgL.XNull(DrTemp(0)("Months"))
                                DGL1.Item(Col1ActualChargeTypeMonths, I).Value = AgL.XNull(DrTemp(0)("Months"))
                            End If

                        Next I
                    End If
                End With

            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                mQry = "SELECT isnull(count(HRT.AllotmentDocId),0) AS Cnt  " & _
                        " FROM Ht_RoomLeft HRT " & _
                        " WHERE HRT.AllotmentDocId = '" & mSearchCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                    mTransFlag = True
                Else
                    mQry = "SELECT count(HRT.AllotmentDocId) AS Cnt " & _
                            " FROM Ht_RoomTransfer HRT " & _
                            " WHERE HRT.AllotmentDocId='" & mSearchCode & "'  "
                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 1 Then mTransFlag = True
                End If


                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            'Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        mChargeDueDocId = "" : mTransferCode$ = "" : mChargeType = "" : mRoomType = "" : mBuildingNature = ""
        LblMemberName.Tag = "" : LblRoom.Tag = "" : LblRoomRequired.Tag = "" : LblHostel.Tag = ""

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFillCharges.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
        End If
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Charge
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim DrTemp As DataRow() = Nothing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""


            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1ChargeType

                    If CBool(DGL1.Item(Col1IsOnceInLife, mRowIndex).Value) And Not AgL.StrCmp(DGL1.Item(Col1ChargeType, mRowIndex).Value.ToString, "Yearly") Then
                        MsgBox("""Once In Life"" Type Charges Are Yearly Type.........!", MsgBoxStyle.Information)
                        DGL1.AgSelectedValue(Col1ChargeType, mRowIndex) = DGL1.Item(Col1ActualChargeType, mRowIndex).Value
                    Else
                        If CBool(DGL1.Item(Col1IsFirstTimeRequired, mRowIndex).Value) And AgL.StrCmp(DGL1.Item(Col1ChargeType, mRowIndex).Value.ToString, "Monthly") Then
                            MsgBox("""First Time Required"" Type Charges Are Not Monthly type.........!", MsgBoxStyle.Information)
                            DGL1.AgSelectedValue(Col1ChargeType, mRowIndex) = DGL1.Item(Col1ActualChargeType, mRowIndex).Value
                            DGL1.Item(Col1ChargeTypeMonths, mRowIndex).Value = DGL1.Item(Col1ActualChargeTypeMonths, mRowIndex).Value
                        Else
                            If DGL1.AgHelpDataSet(Col1ChargeType) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(Col1ChargeType).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1ChargeType, mRowIndex)) & "")
                                DGL1.Item(Col1ChargeTypeMonths, mRowIndex).Value = AgL.XNull(DrTemp(0)("Months"))
                            End If
                        End If
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)

        Call Calculation()
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
          TxtMemberName.Enter, TxtRoom.Enter, TxtRemark.Enter
        Try
            Select Case sender.name

                Case TxtMemberName.Name
                    TxtMemberName.AgRowFilter = " IsHostelMember = 0 "

                Case TxtRoom.Name
                    If TxtHostel.AgSelectedValue Is Nothing Then TxtHostel.AgSelectedValue = ""
                    TxtRoom.AgRowFilter = " HostelCode = " & AgL.Chk_Text(TxtHostel.AgSelectedValue) & " AND RoomStatus > 0 AND IsRoomAllocatable = 1"

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDocId.Validating, TxtModified.Validating, TxtMemberName.Validating, _
       TxtPrepared.Validating, TxtRemark.Validating, TxtRoom.Validating, TxtSite_Code.Validating, TxtV_Date.Validating, _
       TxtV_Type.Validating, TxtV_No.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME

                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate


                Case TxtMemberName.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                        TxtMemberType.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtMemberName.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & "")
                            LblMemberName.Tag = AgL.XNull(DrTemp(0)("Sex"))
                            TxtMemberType.Text = AgL.XNull(DrTemp(0)("MemberType"))
                        End If
                    End If

                Case TxtRoom.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblRoom.Tag = "" : LblRoomRequired.Tag = "" : mRoomType = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtRoom.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & "")
                            LblRoom.Tag = AgL.XNull(DrTemp(0)("TotalBed"))
                            LblHostel.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
                            mRoomType = AgL.XNull(DrTemp(0)("RoomType"))
                            mBuildingNature = AgL.XNull(DrTemp(0)("BuildingNature"))
                        End If
                    End If


            End Select

            Call Calculation()

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub


    Private Function Data_Validation() As Boolean

        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try

            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtMemberName, "Member Name") Then Exit Function
            If AgL.RequiredField(TxtRoom, "Room") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)


            If Not AgL.StrCmp(LblMemberName.Tag, mBuildingNature) And Not AgL.StrCmp(mBuildingNature, "Both") Then
                MsgBox("" & TxtRoom.Text & " Can't Be Alloted To """ & TxtMemberName.Text & """" + vbCrLf + "Because Its a " & mBuildingNature & " Nature Building Room.....!", MsgBoxStyle.Information) : TxtRoom.Focus()
                Exit Function
            End If

            mQry = " SELECT count(HRT.SubCode) AS PersonInRoom " & _
                        " FROM Ht_RoomTransfer HRT " & _
                        " LEFT JOIN Ht_RoomLeft HRL ON HRT.AllotmentDocId=HRL.AllotmentDocId " & _
                        " WHERE HRT.Room=" & AgL.Chk_Text(TxtRoom.AgSelectedValue) & " " & _
                        " AND HRT.TransferDate Is NULL " & _
                        " AND HRL.LeftDate IS NULL "

            If Topctrl1.Mode = "Add" Then
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() >= Val(LblRoom.Tag) Then MsgBox("'" & TxtRoom.Text & "' is Already Full.....!", MsgBoxStyle.Information) : TxtRoom.Focus() : Exit Function
            End If

            If Topctrl1.Mode = "Edit" And (Not AgL.StrCmp(TxtRoom.AgSelectedValue, LblRoomRequired.Tag)) Then
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() >= Val(LblRoom.Tag) Then MsgBox("'" & TxtRoom.Text & "' is Already Full.....!", MsgBoxStyle.Information) : TxtRoom.Focus() : Exit Function
            End If

            'mQry = "SELECT count(HRT.SubCode)  " & _
            '        " FROM Ht_RoomAllotment HRA  " & _
            '        " LEFT JOIN Ht_RoomTransfer HRT ON HRA.DocId=HRT.AllotmentDocId  " & _
            '        " WHERE HRT.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " AND HRT.SubCode='" & TxtMemberName.AgSelectedValue & "' AND " & _
            '        " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " HRT.AllotmentDocId <> '" & mSearchCode & "' ") & " "

            'If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then MsgBox(TxtMemberName.Text & " has Already got the room!...") : TxtMemberName.Focus() : Exit Function

            If AgCL.AgIsBlankGrid(DGL1, Col1ChargeType) Then Exit Function
            If Not AgCL.AgCheckMandatory(Me) Then Exit Function
            If TxtHostel.AgSelectedValue <> LblHostel.Tag Then MsgBox("Room is not Valid  !........", MsgBoxStyle.Information) : Exit Function

            With DGL1
                For I = 0 To DGL1.RowCount - 1
                    If .Item(Col1Charge, I).Value IsNot Nothing Then
                        If CBool(.Item(Col1IsOnceInLife, I).Value) And Not AgL.StrCmp(.Item(Col1ChargeType, I).Value.ToString, "Yearly") Then
                            MsgBox("""Once In Life"" Type Charges Are Yearly Type.........!", MsgBoxStyle.Information) : .CurrentCell = DGL1(Col1ChargeType, I) : DGL1.Focus()
                            Exit Function
                        End If

                        If CBool(.Item(Col1IsFirstTimeRequired, I).Value) And AgL.StrCmp(.Item(Col1ChargeType, I).Value.ToString, "Monthly") Then
                            MsgBox("""First Time Required"" Type Charges Are Not Monthly type.........!", MsgBoxStyle.Information) : .CurrentCell = DGL1(Col1ChargeType, I) : DGL1.Focus()
                            Exit Function
                        End If

                        If .Item(Col1Amount, I).Value <> Val(.Item(Col1ActualAmount, I).Value) * Val(.Item(Col1ChargeTypeMonths, I).Value) / Val(.Item(Col1ActualChargeTypeMonths, I).Value) Then
                            MsgBox("Calculated Amount Is Not Right.........!", MsgBoxStyle.Information) : .CurrentCell = DGL1(Col1Amount, I) : DGL1.Focus()
                            Exit Function
                        End If

                    End If
                Next
            End With


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If

                mTransferCode = AgL.GetMaxId("Ht_RoomTransfer", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function


    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If

        If mRoomCode.Trim <> "" Then
            Dim DrTemp As DataRow() = Nothing
            TxtRoom.Focus()
            TxtRoom.AgSelectedValue = mRoomCode
            TxtMemberName.Focus()
            If TxtRoom.AgHelpDataSet IsNot Nothing Then
                DrTemp = TxtRoom.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & "")
                TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
            End If
            Call ProcFillCharges()

        End If
    End Sub


    Private Sub BtnFillCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillCharges.Click
        Try
            Select Case sender.name
                Case BtnFillCharges.Name
                    Call ProcFillCharges()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillCharges()
        Dim DtTemp As DataTable
        Dim DrTemp As DataRow() = Nothing
        Dim I As Integer
        Dim bCondStr$ = "", bNewSemesterStartDate$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            mQry = "SELECT HRTC.Charge, HRTC.Amount, HRTC.ChargeType,HRTC.DueMonth,HRTC.IsOnceInLife, " & _
                    " HRTC.IsFirstTimeRequired " & _
                    " FROM Ht_RoomType HRT  " & _
                    " LEFT JOIN Ht_RoomTypeCharge HRTC ON HRT.Code=HRTC.Code  " & _
                    " LEFT JOIN Sch_FeeType FT ON HRTC.ChargeType = FT.Code " & _
                    " WHERE HRT.Code='" & mRoomType & "'  " & _
                    " AND (HRTC.DueMonth='" & CDate(TxtV_Date.Text).ToString("MMM") & "' OR " & _
                    " FT.Months = 1 OR " & _
                    " IsNull(HRTC.IsFirstTimeRequired,0) <> 0 ) "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp

                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1Charge, I) = AgL.XNull(.Rows(I)("Charge"))
                        DGL1.Item(Col1Amount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                        DGL1.Item(Col1ActualAmount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                        DGL1.AgSelectedValue(Col1ChargeType, I) = AgL.XNull(.Rows(I)("ChargeType"))
                        DGL1.Item(Col1ActualChargeType, I).Value = AgL.XNull(.Rows(I)("ChargeType"))
                        DGL1.Item(Col1DueMonth, I).Value = AgL.XNull(.Rows(I)("DueMonth"))
                        DGL1.Item(Col1IsOnceInLife, I).Value = AgL.XNull(.Rows(I)("IsOnceInLife"))
                        DGL1.Item(Col1IsFirstTimeRequired, I).Value = AgL.XNull(.Rows(I)("IsFirstTimeRequired"))

                        If DGL1.AgHelpDataSet(Col1ChargeType) IsNot Nothing Then
                            DrTemp = DGL1.AgHelpDataSet(Col1ChargeType).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1ChargeType, I)) & "")
                            DGL1.Item(Col1ChargeTypeMonths, I).Value = AgL.XNull(DrTemp(0)("Months"))
                            DGL1.Item(Col1ActualChargeTypeMonths, I).Value = AgL.XNull(DrTemp(0)("Months"))
                        End If
                    Next I
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcCreateChargeDueStructure(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, ByVal bAllotmentDocId As String, _
                                                ByRef bChargeDueObj As Struct_ChargeDue, ByRef bChargeDue1Obj() As Struct_ChargeDue1, ByRef bChargeDueDocId As String)

        Dim I As Integer, J As Integer, mFlagBln As Boolean = False
        Dim bSite_Code$ = "", bDiv_Code$ = "", bV_Type$ = "", bV_Prefix$ = "", bV_No As Long = 0, bV_Date$ = "", bSearchCode$ = ""
        Dim bDtTable As DataTable
        Dim bQry$ = ""
        Dim bTotalAmount As Double = 0


        bQry = "SELECT HRA.DocId AS AllotmentDocId,HRA.Site_Code,HRA.Div_Code,HRT.SubCode AS Member, " & _
                " HRA.V_Date,HRTC.*,CD1.Code AS ChargeDueCode,FT.Months " & _
                " FROM Ht_RoomAllotment HRA WITH (NoLock) " & _
                " LEFT JOIN Ht_RoomTransfer HRT WITH (NoLock) ON HRA.DocId = HRT.AllotmentDocId And Hrt.AllotmentType = '" & AllotmentType_Allotment & "' " & _
                " LEFT JOIN Ht_RoomTransferCharge HRTC WITH (NoLock) ON HRT.Code = HRTC.RoomTransfer  " & _
                " LEFT JOIN Ht_RoomAllotmentChargeDue RCD WITH (NoLock) ON HRA.DocId = RCD.AllotmentDocId  " & _
                " LEFT JOIN Ht_ChargeDue1 CD1 WITH (NoLock) ON RCD.ChargeDueDocId = CD1.DocId   " & _
                "           AND CD1.AllotmentDocId = RCD.AllotmentDocId AND CD1.Charge = HRTC.Charge  " & _
                " LEFT JOIN Sch_FeeType FT ON HRTC.ChargeType=FT.Code " & _
                " WHERE HRA.DocId='" & bAllotmentDocId & "' AND   " & _
                " (HRTC.DueMonth='" & CDate(TxtV_Date.Text).ToString("MMM") & "' OR " & _
                " FT.Months = 1 OR " & _
                " IsNull(HRTC.IsFirstTimeRequired,0) <> 0 ) "
        bDtTable = AgL.FillData(bQry, bConnRead).Tables(0)


        With bDtTable
            If .Rows.Count > 0 Then
                bSite_Code = AgL.XNull(.Rows(0)("Site_Code"))
                bDiv_Code = AgL.XNull(.Rows(0)("Div_Code"))
                bV_Date = Format(AgL.XNull(.Rows(0)("V_Date")), "Short Date")

                If Topctrl1.Mode = "Add" And bV_Date.Trim <> "" And bSite_Code.Trim <> "" Then
                    bQry = "Select Vt.V_Type From Voucher_Type Vt With (NoLock) " & _
                            " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_RoomChargeDue & "' "
                    bV_Type = AgL.XNull(AgL.Dman_Execute(bQry, bConnRead).ExecuteScalar)

                    bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), bConnRead, bDiv_Code, bSite_Code)
                    mChargeDueDocId = bSearchCode
                Else
                    bSearchCode = mChargeDueDocId
                    bV_Type = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherType)
                End If


                If bSearchCode.Trim = "" Then Err.Raise(1, , "Error in Charge Due Search Code Generation!...")

                bV_No = Val(AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                bV_Prefix = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                For I = 0 To .Rows.Count - 1
                    If mFlagBln = False Then
                        J = 0
                        mFlagBln = True
                    Else
                        J = UBound(bChargeDue1Obj) + 1
                    End If
                    ReDim Preserve bChargeDue1Obj(J)

                    bChargeDue1Obj(J).Code = AgL.XNull(.Rows(I)("ChargeDueCode"))
                    bChargeDue1Obj(J).DocId = bSearchCode
                    bChargeDue1Obj(J).AllotmentDocId = bAllotmentDocId
                    bChargeDue1Obj(J).Charge = AgL.XNull(.Rows(I)("Charge"))
                    bChargeDue1Obj(J).Amount = AgL.VNull(.Rows(I)("Amount"))

                    bTotalAmount += AgL.VNull(.Rows(I)("Amount"))
                Next


                bChargeDueObj.DocId = bSearchCode
                bChargeDueObj.Div_Code = bDiv_Code
                bChargeDueObj.Site_Code = bSite_Code
                bChargeDueObj.V_Type = bV_Type
                bChargeDueObj.V_Prefix = bV_Prefix
                bChargeDueObj.V_No = bV_No
                bChargeDueObj.V_Date = bV_Date
                bChargeDueObj.Remark = ""
                bChargeDueObj.TotalAmount = bTotalAmount
                bChargeDueObj.MonthStartDate = bV_Date
            End If
        End With
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0, J As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""
                If .Item(Col1ChargeType, I).Value Is Nothing Then .Item(Col1ChargeType, I).Value = ""
                If .Item(Col1DueMonth, I).Value Is Nothing Then .Item(Col1DueMonth, I).Value = ""

                If .Item(Col1ChargeTypeMonths, I).Value IsNot Nothing Then
                    If .Item(Col1ActualAmount, I).Value IsNot Nothing Then
                        .Item(Col1Amount, I).Value = Val(.Item(Col1ActualAmount, I).Value) * Val(.Item(Col1ChargeTypeMonths, I).Value) / Val(.Item(Col1ActualChargeTypeMonths, I).Value)
                    End If
                End If
            Next
        End With
    End Sub

    'Private Sub ProcFillRoomAllotmentDetail()
    '    Dim DrTemp As DataRow() = Nothing
    '    If Topctrl1.Mode = "Browse" Then Exit Sub
    '    If mRoomCode.Trim = "" Then Exit Sub
    '    Dim DtTemp As DataTable = Nothing

    '    Try
    '        TxtRoom.AgSelectedValue = mRoomCode
    '        If TxtRoom.AgHelpDataSet IsNot Nothing Then
    '            DrTemp = TxtRoom.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & "")
    '            LblRoom.Tag = AgL.XNull(DrTemp(0)("TotalBed"))
    '            LblHostel.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
    '            TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
    '            mRoomType = AgL.XNull(DrTemp(0)("RoomType"))
    '            mBuildingNature = AgL.XNull(DrTemp(0)("BuildingNature"))
    '        End If
    '        Call ProcFillCharges()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        DtTemp = Nothing
    '    End Try
    'End Sub
End Class