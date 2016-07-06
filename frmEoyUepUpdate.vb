Option Strict Off
Option Explicit On
Friend Class frmEoyUepUpdate
    Inherits DevExpress.XtraEditors.XtraForm

	Dim CatCode As String
	Dim Wyear As String
	Dim Wperiod As String
    Dim CaptLine As String
	
    Dim Ystr As String
	Dim J2str As String
    Dim J4str As String

    Dim A(24) As Double
	
    Private Sub cmdContinue_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdContinue.Click

        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Ystr = Trim(Str(Parry(1))) 'Curr Year

        If J2str = "01" Then J4str = "January 31"
        If J2str = "02" Then J4str = "February 28"
        If J2str = "03" Then J4str = "March 31"
        If J2str = "04" Then J4str = "April 30"
        If J2str = "05" Then J4str = "May 31"
        If J2str = "06" Then J4str = "June 30"
        If J2str = "07" Then J4str = "July 31"
        If J2str = "08" Then J4str = "August 31"
        If J2str = "09" Then J4str = "September 30"
        If J2str = "10" Then J4str = "October 31"
        If J2str = "11" Then J4str = "November 30"
        If J2str = "12" Then J4str = "December 31"
        J4str = J4str & ", " & Ystr

        cmdProcess()
    End Sub
	
    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub txtMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Enter
        Tobj = txtMgaNmbr
        txtMgaNmbr.Text = "999"
        Me.Text = CaptLine
    End Sub
	
    Private Sub txtMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyNmbr.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub txtMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Tobj.Text = "000" Then
            Me.Close()
            Exit Sub
        End If

    End Sub
	
    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Tobj = txtMgaNmbr
    End Sub
	
    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Tobj = txtTrtyNmbr
        txtTrtyNmbr.Text = "99"
    End Sub
	
    Private Sub txtTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaNmbr.Focus()
            Case Keys.Down
                txtPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtPeriod.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Tobj.Text = "00" Then
            Me.Close()
            Exit Sub
        End If
    End Sub
	
    Private Sub txtTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Leave
        Tobj = txtTrtyNmbr
    End Sub
	
    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Tobj = txtPeriod
    End Sub
	
    Private Sub txtPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyNmbr.Focus()
            Case Keys.Down
                cmdContinue.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdContinue.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
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

        RptDirKey = ""
    End Sub
	
    Private Sub frmEoyUepUpdate_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        cboMga.SelectedIndex = 0
        cboTrty.SelectedIndex = 0

        CaptLine = Me.Text

    End Sub
	
    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
	
	Private Sub cmdProcess()
		Me.Text = CaptLine & "          " & "Status: Program Processing"
		If Trim(txtPeriod.Text) = "" Then Exit Sub
		
		'Increment year before running
        Nwdir = Dpath & "YTDDIR12.DBF"
        Nwced1 = Dpath & "YTDCED112.DBF"
        Nwced2 = Dpath & "YTDCED212.DBF"
        Nwced3 = Dpath & "YTDCED312.DBF"
        Nwced4 = Dpath & "YTDCED412.DBF"
        Nwced5 = Dpath & "YTDCED512.DBF"
		
		'Write UEP Dir
		OpenUepDir()
		OpenWorkDir()
		TotalUepDir()
        ClsWorkDir() : f13 = 0
        ClsUepDir() : f7 = 0
		
		'Write UEP Ced1
		OpenUepCed1()
		OpenWorkCed1()
		TotalUepCed()
        ClsWorkCed1() : f14 = 0
        ClsUepCed1() : f8 = 0
		
		'Write UEP Ced2
		OpenUepCed2()
		OpenWorkCed2()
		TotalUepCed()
        ClsWorkCed2() : f14 = 0
        ClsUepCed2() : f8 = 0
		
		'Write UEP Ced3
		OpenUepCed3()
		OpenWorkCed3()
		TotalUepCed()
        ClsWorkCed3() : f14 = 0
        ClsUepCed3() : f8 = 0
		
		'Write UEP Ced4
		OpenUepCed4()
		OpenWorkCed4()
		TotalUepCed()
        ClsWorkCed4() : f14 = 0
        ClsUepCed4() : f8 = 0
		
		'Write UEP Ced5
		OpenUepCed5()
		OpenWorkCed5()
		TotalUepCed()
        ClsWorkCed5() : f14 = 0
        ClsUepCed5() : f8 = 0
		
		Me.Text = CaptLine & "          " & "Status: End Processing"
	End Sub
	
    Sub TotalUepDir()
        Dim X As Integer

        Call d4tagSelect(f13, d4tag(f13, "K1"))
        rc = d4top(f13)
        WorkDirKey = ""
        rc = d4seek(f13, WorkDirKey)

        Do Until rc = r4eof
            If Trim(f4str(WDp.WorkMgaNmbr)) = "016" Then
                If Trim(f4str(WDp.WorkPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(WDp.WorkCatCode))
            Wyear = Trim(f4str(WDp.WorkYear))
            Wperiod = Trim(f4str(WDp.WorkPeriod))

            If CDbl(CatCode) <> 4 Then GoTo nextrec
            If txtPeriod.Text <> Wperiod Then GoTo nextrec


            'Write To UEP Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetWorkDirVar()

            UepDirKey = Trim(f4str(WDp.WorkMgaNmbr)) & Trim(f4str(WDp.WorkTrtyNmbr)) & "12" & Trim(f4str(WDp.WorkCatCode)) & Trim(f4str(WDp.WorkYear))

            Call d4tagSelect(f7, d4tag(f7, "K1"))
            rc = d4top(f7)
            rc = d4seek(f7, UepDirKey)

            AddTran = False
            If UepDirKey <> Trim(f4str(UEp.UepMgaNmbr)) & Trim(f4str(UEp.UepTrtyNmbr)) & "12" & Trim(f4str(UEp.UepCatCode)) & Trim(f4str(UEp.UepYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f7, 0) <> r4success Then Exit Sub
                Call f4assign(UEp.UepMgaNmbr, Trim(f4str(WDp.WorkMgaNmbr)))
                Call f4assign(UEp.UepTrtyNmbr, Trim(f4str(WDp.WorkTrtyNmbr)))
                Call f4assign(UEp.UepPeriod, "12")
                Call f4assign(UEp.UepCatCode, Trim(f4str(WDp.WorkCatCode)))
                Call f4assign(UEp.UepYear, Trim(f4str(WDp.WorkYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(UEp.UepTotal) : A(1) = f4double(UEp.UepPPbi)
                A(2) = f4double(UEp.UepPPpd) : A(3) = f4double(UEp.UepPPmed)
                A(4) = f4double(UEp.UepPPumbi) : A(5) = f4double(UEp.UepPPumpd)
                A(6) = f4double(UEp.UepPPpip) : A(7) = f4double(UEp.UepPPcomp)
                A(8) = f4double(UEp.UepPPcoll) : A(9) = f4double(UEp.UepPPrent)
                A(10) = f4double(UEp.UepPPtow) : A(11) = f4double(UEp.UepCMbi)
                A(12) = f4double(UEp.UepCMpd) : A(13) = f4double(UEp.UepCMmed)
                A(14) = f4double(UEp.UepCMumbi) : A(15) = f4double(UEp.UepCMumpd)
                A(16) = f4double(UEp.UepCMpip) : A(17) = f4double(UEp.UepCMcomp)
                A(18) = f4double(UEp.UepCMcoll) : A(19) = f4double(UEp.UepCMrent)
                A(20) = f4double(UEp.UepCMtow) : A(21) = f4double(UEp.UepOTim)
                A(22) = f4double(UEp.UepOTallied) : A(23) = f4double(UEp.UepOTfire)
                A(24) = f4double(UEp.UepOTmulti)
            End If

            Call f4assignDouble(UEp.UepTotal, A(0) + MLobt)
            Call f4assignDouble(UEp.UepPPbi, A(1) + MLobp(1))
            Call f4assignDouble(UEp.UepPPpd, A(2) + MLobp(2))
            Call f4assignDouble(UEp.UepPPmed, A(3) + MLobp(3))
            Call f4assignDouble(UEp.UepPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(UEp.UepPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(UEp.UepPPpip, A(6) + MLobp(6))
            Call f4assignDouble(UEp.UepPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(UEp.UepPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(UEp.UepPPrent, A(9) + MLobp(9))
            Call f4assignDouble(UEp.UepPPtow, A(10) + MLobp(10))
            Call f4assignDouble(UEp.UepCMbi, A(11) + MLobp(11))
            Call f4assignDouble(UEp.UepCMpd, A(12) + MLobp(12))
            Call f4assignDouble(UEp.UepCMmed, A(13) + MLobp(13))
            Call f4assignDouble(UEp.UepCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(UEp.UepCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(UEp.UepCMpip, A(16) + MLobp(16))
            Call f4assignDouble(UEp.UepCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(UEp.UepCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(UEp.UepCMrent, A(19) + MLobp(19))
            Call f4assignDouble(UEp.UepCMtow, A(20) + MLobp(20))
            Call f4assignDouble(UEp.UepOTim, A(21) + MLobp(21))
            Call f4assignDouble(UEp.UepOTallied, A(22) + MLobp(22))
            Call f4assignDouble(UEp.UepOTfire, A(23) + MLobp(23))
            Call f4assignDouble(UEp.UepOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f7)
                rc = d4unlock(f7)
            End If

nextrec:
            rc = d4skip(f13, 1)
        Loop
    End Sub
	
    Sub TotalUepCed()
        Dim X As Integer

        Call d4tagSelect(f14, d4tag(f14, "K1"))
        rc = d4top(f14)
        WorkCedKey = ""
        rc = d4seek(f14, WorkCedKey)

        Do Until rc = r4eof

            If Trim(f4str(Wc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Wc1p.CedPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Wc1p.CedCatCode))
            Wyear = Trim(f4str(Wc1p.CedYear))
            Wperiod = Trim(f4str(Wc1p.CedPeriod))

            If CDbl(CatCode) <> 4 Then GoTo nextrec
            If txtPeriod.Text <> Wperiod Then GoTo nextrec

            'Write To UEP Ced File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetWorkCedVar()

            UepCedKey = Trim(f4str(Wc1p.CedMgaNmbr)) & Trim(f4str(Wc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Wc1p.CedCatCode)) & Trim(f4str(Wc1p.CedYear))

            Call d4tagSelect(f8, d4tag(f8, "K1"))
            rc = d4top(f8)
            rc = d4seek(f8, UepCedKey)

            AddTran = False
            If UepCedKey <> Trim(f4str(Uc1p.CedMgaNmbr)) & Trim(f4str(Uc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Uc1p.CedCatCode)) & Trim(f4str(Uc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f8, 0) <> r4success Then Exit Sub
                Call f4assign(Uc1p.CedMgaNmbr, Trim(f4str(Wc1p.CedMgaNmbr)))
                Call f4assign(Uc1p.CedTrtyNmbr, Trim(f4str(Wc1p.CedTrtyNmbr)))
                Call f4assign(Uc1p.CedPeriod, "12")
                Call f4assign(Uc1p.CedCatCode, Trim(f4str(Wc1p.CedCatCode)))
                Call f4assign(Uc1p.CedYear, Trim(f4str(Wc1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(Uc1p.CedTotal) : A(1) = f4double(Uc1p.CedPPbi)
                A(2) = f4double(Uc1p.CedPPpd) : A(3) = f4double(Uc1p.CedPPmed)
                A(4) = f4double(Uc1p.CedPPumbi) : A(5) = f4double(Uc1p.CedPPumpd)
                A(6) = f4double(Uc1p.CedPPpip) : A(7) = f4double(Uc1p.CedPPcomp)
                A(8) = f4double(Uc1p.CedPPcoll) : A(9) = f4double(Uc1p.CedPPrent)
                A(10) = f4double(Uc1p.CedPPtow) : A(11) = f4double(Uc1p.CedCMbi)
                A(12) = f4double(Uc1p.CedCMpd) : A(13) = f4double(Uc1p.CedCMmed)
                A(14) = f4double(Uc1p.CedCMumbi) : A(15) = f4double(Uc1p.CedCMumpd)
                A(16) = f4double(Uc1p.CedCMpip) : A(17) = f4double(Uc1p.CedCMcomp)
                A(18) = f4double(Uc1p.CedCMcoll) : A(19) = f4double(Uc1p.CedCMrent)
                A(20) = f4double(Uc1p.CedCMtow) : A(21) = f4double(Uc1p.CedOTim)
                A(22) = f4double(Uc1p.CedOTallied) : A(23) = f4double(Uc1p.CedOTfire)
                A(24) = f4double(Uc1p.CedOTmulti)
            End If

            Call f4assignDouble(Uc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(Uc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(Uc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(Uc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(Uc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(Uc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(Uc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(Uc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(Uc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(Uc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(Uc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(Uc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(Uc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(Uc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(Uc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(Uc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(Uc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(Uc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(Uc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(Uc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(Uc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(Uc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(Uc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(Uc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(Uc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f8)
                rc = d4unlock(f8)
            End If

nextrec:
            rc = d4skip(f14, 1)
        Loop

    End Sub
End Class