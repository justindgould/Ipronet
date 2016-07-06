Option Strict Off
Option Explicit On
Friend Class frmIbnrMerge
    Inherits DevExpress.XtraEditors.XtraForm
	
    Dim Kstr As String
	
	Dim L0 As Integer
	Dim A(24) As Double
	Dim A1 As Double
	Dim n As Double
	
    Private Sub cmdCont_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCont.Click
        'IBNR Calc
        OpenIbnrDir()
        OpenIbnrCed()
        OpenRptDir()
        OpenRptCed1()

        ProcessIbnrDir()
        ProcessIbnrCed()

        Me.Close()
    End Sub
	
    Private Sub frmIbnrMerge_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
    End Sub
	
    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
	
    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Tobj = txtPeriod
    End Sub
	
    Private Sub txtPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                cmdCont.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdCont.Focus()
    End Sub
	
    Private Sub txtPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Leave
        Dim X As Integer

        Tobj = txtPeriod

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next
        Tobj.Text = S1

        If S1 = "00" Then Tobj.Text = ""
    End Sub
	
	Sub ProcessIbnrDir()
		Dim X As Short
		
		L0 = 0 : Kstr = ""
		
		'==================================================================================
		'=Get INBR DIR
		'==================================================================================
		Call d4tagSelect(f24, d4tag(f24, "K1"))
		rc = d4top(f24)
		
		Do Until rc = r4eof
			DspCount()
			
			If Trim(f4str(IBp.IbdMgaNmbr)) = "016" Then GoTo nextrec
			
			Kstr = Trim(f4str(IBp.IbdMgaNmbr)) & Trim(f4str(IBp.IbdTrtyNmbr)) & Trim(f4str(IBp.IbdPeriod)) & Trim(f4str(IBp.IbdCatCode)) & Trim(f4str(IBp.IbdYear))
			
			GetIbnrDirVar()
			
			A1 = MLobt
			For X = 1 To 24 : A(X) = MLobp(X) : Next X
			
			'Add Direct Tran
			If d4appendStart(f5, 0) <> r4success Then GoTo nextrec
			Call f4assign(RDp.RptMgaNmbr, Mid(Kstr, 1, 3))
			Call f4assign(RDp.RptTrtyNmbr, Mid(Kstr, 4, 2))
			Call f4assign(RDp.RptPeriod, Mid(Kstr, 6, 2))
			Call f4assign(RDp.RptCatCode, Mid(Kstr, 8, 2))
			Call f4assign(RDp.RptYear, Mid(Kstr, 10, 4))
			Call f4assignDouble(RDp.RptTotal, A1)
			Call f4assignDouble(RDp.RptPPbi, A(1))
			Call f4assignDouble(RDp.RptPPpd, A(2))
			Call f4assignDouble(RDp.RptPPmed, A(3))
			Call f4assignDouble(RDp.RptPPumbi, A(4))
			Call f4assignDouble(RDp.RptPPumpd, A(5))
			Call f4assignDouble(RDp.RptPPpip, A(6))
			Call f4assignDouble(RDp.RptPPcomp, A(7))
			Call f4assignDouble(RDp.RptPPcoll, A(8))
			Call f4assignDouble(RDp.RptPPrent, A(9))
			Call f4assignDouble(RDp.RptPPtow, A(10))
			Call f4assignDouble(RDp.RptCMbi, A(11))
			Call f4assignDouble(RDp.RptCMpd, A(12))
			Call f4assignDouble(RDp.RptCMmed, A(13))
			Call f4assignDouble(RDp.RptCMumbi, A(14))
			Call f4assignDouble(RDp.RptCMumpd, A(15))
			Call f4assignDouble(RDp.RptCMpip, A(16))
			Call f4assignDouble(RDp.RptCMcomp, A(17))
			Call f4assignDouble(RDp.RptCMcoll, A(18))
			Call f4assignDouble(RDp.RptCMrent, A(19))
			Call f4assignDouble(RDp.RptCMtow, A(20))
			Call f4assignDouble(RDp.RptOTim, A(21))
			Call f4assignDouble(RDp.RptOTallied, A(22))
			Call f4assignDouble(RDp.RptOTfire, A(23))
			Call f4assignDouble(RDp.RptOTmulti, A(24))
			rc = d4append(f5)
			rc = d4unlock(f5)
			
nextrec: 
			rc = d4skip(f24, 1)
		Loop 
		
	End Sub
	
	Sub ProcessIbnrCed()
		Dim X As Short
		
		L0 = 0 : Kstr = ""
		
		'==================================================================================
		'=Get INBR Ceded
		'==================================================================================
		Call d4tagSelect(f23, d4tag(f23, "K1"))
		rc = d4top(f23)
		
		Do Until rc = r4eof
			DspCount()
			
			If Trim(f4str(ICp.IbcMgaNmbr)) = "016" Then GoTo nextrec
			
			Kstr = Trim(f4str(ICp.IbcMgaNmbr)) & Trim(f4str(ICp.IbcTrtyNmbr)) & Trim(f4str(ICp.IbcPeriod)) & Trim(f4str(ICp.IbcCatCode)) & Trim(f4str(ICp.IbcYear))
			
			GetIbnrCedVar()
			
			A1 = MLobt
			For X = 1 To 24 : A(X) = MLobp(X) : Next X
			
			'Add Direct Tran
			If d4appendStart(f6, 0) <> r4success Then GoTo nextrec
			Call f4assign(Rc1p.CedMgaNmbr, Mid(Kstr, 1, 3))
			Call f4assign(Rc1p.CedTrtyNmbr, Mid(Kstr, 4, 2))
			Call f4assign(Rc1p.CedPeriod, Mid(Kstr, 6, 2))
			Call f4assign(Rc1p.CedCatCode, Mid(Kstr, 8, 2))
			Call f4assign(Rc1p.CedYear, Mid(Kstr, 10, 4))
			Call f4assignDouble(Rc1p.CedTotal, A1)
			Call f4assignDouble(Rc1p.CedPPbi, A(1))
			Call f4assignDouble(Rc1p.CedPPpd, A(2))
			Call f4assignDouble(Rc1p.CedPPmed, A(3))
			Call f4assignDouble(Rc1p.CedPPumbi, A(4))
			Call f4assignDouble(Rc1p.CedPPumpd, A(5))
			Call f4assignDouble(Rc1p.CedPPpip, A(6))
			Call f4assignDouble(Rc1p.CedPPcomp, A(7))
			Call f4assignDouble(Rc1p.CedPPcoll, A(8))
			Call f4assignDouble(Rc1p.CedPPrent, A(9))
			Call f4assignDouble(Rc1p.CedPPtow, A(10))
			Call f4assignDouble(Rc1p.CedCMbi, A(11))
			Call f4assignDouble(Rc1p.CedCMpd, A(12))
			Call f4assignDouble(Rc1p.CedCMmed, A(13))
			Call f4assignDouble(Rc1p.CedCMumbi, A(14))
			Call f4assignDouble(Rc1p.CedCMumpd, A(15))
			Call f4assignDouble(Rc1p.CedCMpip, A(16))
			Call f4assignDouble(Rc1p.CedCMcomp, A(17))
			Call f4assignDouble(Rc1p.CedCMcoll, A(18))
			Call f4assignDouble(Rc1p.CedCMrent, A(19))
			Call f4assignDouble(Rc1p.CedCMtow, A(20))
			Call f4assignDouble(Rc1p.CedOTim, A(21))
			Call f4assignDouble(Rc1p.CedOTallied, A(22))
			Call f4assignDouble(Rc1p.CedOTfire, A(23))
			Call f4assignDouble(Rc1p.CedOTmulti, A(24))
			rc = d4append(f6)
			rc = d4unlock(f6)
			
nextrec: 
			rc = d4skip(f23, 1)
		Loop 
		
	End Sub
	
    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub
End Class