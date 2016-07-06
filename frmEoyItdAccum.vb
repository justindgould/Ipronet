Option Strict Off
Option Explicit On
Friend Class frmEoyItdAccum
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

    Private Sub frmEoyItdAccum_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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

        'New ITD Files - Changes year to reflect close out year
        'After All Eoy Steps Run - Rename Current Active ITD files to prior close out year
        'Rename New ITD to current year (Ex ITDDIR12 > ITDDIR)

        Nwdir = Dpath & "ITDDIR13.DBF"
        Nwced1 = Dpath & "ITDCED113.DBF"
        Nwced2 = Dpath & "ITDCED213.DBF"
        Nwced3 = Dpath & "ITDCED313.DBF"
        Nwced4 = Dpath & "ITDCED413.DBF"
        Nwced5 = Dpath & "ITDCED513.DBF"

        'Write ITD Dir
        OpenWorkDir()
        OpenItdDir()
        OpenYtdDir()
        TotalItdDir()
        TotalYtdDir()
        ClsYtdDir() : f9 = 0
        ClsItdDir() : f11 = 0
        ClsWorkDir() : f13 = 0

        'Write ITD Ced1
        OpenWorkCed1()
        OpenItdCed1()
        OpenYtdCed1()
        TotalItdCed()
        TotalYtdCed()
        ClsYtdCed1() : f10 = 0
        ClsItdCed1() : f12 = 0
        ClsWorkCed1() : f14 = 0

        'Write ITD Ced2
        OpenWorkCed2()
        OpenItdCed2()
        OpenYtdCed2()
        TotalItdCed()
        TotalYtdCed()
        ClsYtdCed2() : f10 = 0
        ClsItdCed2() : f12 = 0
        ClsWorkCed2() : f14 = 0

        'Write ITD Ced3
        OpenWorkCed3()
        OpenItdCed3()
        OpenYtdCed3()
        TotalItdCed()
        TotalYtdCed()
        ClsYtdCed3() : f10 = 0
        ClsItdCed3() : f12 = 0
        ClsWorkCed3() : f14 = 0

        'Write ITD Ced4
        OpenWorkCed4()
        OpenItdCed4()
        OpenYtdCed4()
        TotalItdCed()
        TotalYtdCed()
        ClsYtdCed4() : f10 = 0
        ClsItdCed4() : f12 = 0
        ClsWorkCed4() : f14 = 0

        'Write ITD Ced5
        OpenWorkCed5()
        OpenItdCed5()
        OpenYtdCed5()
        TotalItdCed()
        TotalYtdCed()
        ClsYtdCed5() : f10 = 0
        ClsItdCed5() : f12 = 0
        ClsWorkCed5() : f14 = 0

        Me.Text = CaptLine & "          " & "Status: End Processing"
    End Sub

    Sub TotalItdDir()
        Dim X As Integer

        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)
        ItdDirKey = ""
        rc = d4seek(f11, ItdDirKey)

        Do Until rc = r4eof
            If Trim(f4str(IDp.ItdMgaNmbr)) = "016" Then
                If Trim(f4str(IDp.ItdPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(IDp.ItdCatCode))
            Wyear = Trim(f4str(IDp.ItdYear))
            Wperiod = Trim(f4str(IDp.ItdPeriod))

            If CDbl(CatCode) = 4 Then GoTo nextrec
            If CDbl(CatCode) = 9 Then GoTo nextrec
            If CDbl(CatCode) = 10 Then GoTo nextrec
            If CDbl(CatCode) = 13 Then GoTo nextrec
            If CDbl(CatCode) = 14 Then GoTo nextrec
            If CDbl(CatCode) = 15 Then GoTo nextrec
            If CDbl(CatCode) = 16 Then GoTo nextrec
            If CDbl(CatCode) = 17 Then GoTo nextrec

            'Write To ITD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetItdDirVar()

            WorkDirKey = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) & "12" & Trim(f4str(IDp.ItdCatCode)) & Trim(f4str(IDp.ItdYear))

            Call d4tagSelect(f13, d4tag(f13, "K1"))
            rc = d4top(f13)
            rc = d4seek(f13, WorkDirKey)

            AddTran = False
            If WorkDirKey <> Trim(f4str(WDp.WorkMgaNmbr)) & Trim(f4str(WDp.WorkTrtyNmbr)) & "12" & Trim(f4str(WDp.WorkCatCode)) & Trim(f4str(WDp.WorkYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f13, 0) <> r4success Then Exit Sub
                Call f4assign(WDp.WorkMgaNmbr, Trim(f4str(IDp.ItdMgaNmbr)))
                Call f4assign(WDp.WorkTrtyNmbr, Trim(f4str(IDp.ItdTrtyNmbr)))
                Call f4assign(WDp.WorkPeriod, "12")
                Call f4assign(WDp.WorkCatCode, Trim(f4str(IDp.ItdCatCode)))
                Call f4assign(WDp.WorkYear, Trim(f4str(IDp.ItdYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(WDp.WorkTotal) : A(1) = f4double(WDp.WorkPPbi)
                A(2) = f4double(WDp.WorkPPpd) : A(3) = f4double(WDp.WorkPPmed)
                A(4) = f4double(WDp.WorkPPumbi) : A(5) = f4double(WDp.WorkPPumpd)
                A(6) = f4double(WDp.WorkPPpip) : A(7) = f4double(WDp.WorkPPcomp)
                A(8) = f4double(WDp.WorkPPcoll) : A(9) = f4double(WDp.WorkPPrent)
                A(10) = f4double(WDp.WorkPPtow) : A(11) = f4double(WDp.WorkCMbi)
                A(12) = f4double(WDp.WorkCMpd) : A(13) = f4double(WDp.WorkCMmed)
                A(14) = f4double(WDp.WorkCMumbi) : A(15) = f4double(WDp.WorkCMumpd)
                A(16) = f4double(WDp.WorkCMpip) : A(17) = f4double(WDp.WorkCMcomp)
                A(18) = f4double(WDp.WorkCMcoll) : A(19) = f4double(WDp.WorkCMrent)
                A(20) = f4double(WDp.WorkCMtow) : A(21) = f4double(WDp.WorkOTim)
                A(22) = f4double(WDp.WorkOTallied) : A(23) = f4double(WDp.WorkOTfire)
                A(24) = f4double(WDp.WorkOTmulti)
            End If

            Call f4assignDouble(WDp.WorkTotal, A(0) + MLobt)
            Call f4assignDouble(WDp.WorkPPbi, A(1) + MLobp(1))
            Call f4assignDouble(WDp.WorkPPpd, A(2) + MLobp(2))
            Call f4assignDouble(WDp.WorkPPmed, A(3) + MLobp(3))
            Call f4assignDouble(WDp.WorkPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(WDp.WorkPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(WDp.WorkPPpip, A(6) + MLobp(6))
            Call f4assignDouble(WDp.WorkPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(WDp.WorkPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(WDp.WorkPPrent, A(9) + MLobp(9))
            Call f4assignDouble(WDp.WorkPPtow, A(10) + MLobp(10))
            Call f4assignDouble(WDp.WorkCMbi, A(11) + MLobp(11))
            Call f4assignDouble(WDp.WorkCMpd, A(12) + MLobp(12))
            Call f4assignDouble(WDp.WorkCMmed, A(13) + MLobp(13))
            Call f4assignDouble(WDp.WorkCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(WDp.WorkCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(WDp.WorkCMpip, A(16) + MLobp(16))
            Call f4assignDouble(WDp.WorkCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(WDp.WorkCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(WDp.WorkCMrent, A(19) + MLobp(19))
            Call f4assignDouble(WDp.WorkCMtow, A(20) + MLobp(20))
            Call f4assignDouble(WDp.WorkOTim, A(21) + MLobp(21))
            Call f4assignDouble(WDp.WorkOTallied, A(22) + MLobp(22))
            Call f4assignDouble(WDp.WorkOTfire, A(23) + MLobp(23))
            Call f4assignDouble(WDp.WorkOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f13)
                rc = d4unlock(f13)
            End If

nextrec:
            rc = d4skip(f11, 1)
        Loop

    End Sub

    Sub TotalYtdDir()
        Dim X As Integer

        Call d4tagSelect(f9, d4tag(f9, "K1"))
        rc = d4top(f9)
        YtdDirKey = ""
        rc = d4seek(f9, YtdDirKey)

        Do Until rc = r4eof
            If Trim(f4str(YDp.YtdMgaNmbr)) = "016" Then
                If Trim(f4str(YDp.YtdPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(YDp.YtdCatCode))
            Wyear = Trim(f4str(YDp.YtdYear))
            Wperiod = Trim(f4str(YDp.YtdPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If txtPeriod.Text <> Wperiod Then GoTo nextrec
            End If

            'Write To ITD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetYtdDirVar()

            WorkDirKey = Trim(f4str(YDp.YtdMgaNmbr)) & Trim(f4str(YDp.YtdTrtyNmbr)) & "12" & Trim(f4str(YDp.YtdCatCode)) & Trim(f4str(YDp.YtdYear))

            Call d4tagSelect(f13, d4tag(f13, "K1"))
            rc = d4top(f13)
            rc = d4seek(f13, WorkDirKey)

            AddTran = False
            If WorkDirKey <> Trim(f4str(WDp.WorkMgaNmbr)) & Trim(f4str(WDp.WorkTrtyNmbr)) & "12" & Trim(f4str(WDp.WorkCatCode)) & Trim(f4str(WDp.WorkYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f13, 0) <> r4success Then Exit Sub
                Call f4assign(WDp.WorkMgaNmbr, Trim(f4str(YDp.YtdMgaNmbr)))
                Call f4assign(WDp.WorkTrtyNmbr, Trim(f4str(YDp.YtdTrtyNmbr)))
                Call f4assign(WDp.WorkPeriod, "12")
                Call f4assign(WDp.WorkCatCode, Trim(f4str(YDp.YtdCatCode)))
                Call f4assign(WDp.WorkYear, Trim(f4str(YDp.YtdYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(WDp.WorkTotal) : A(1) = f4double(WDp.WorkPPbi)
                A(2) = f4double(WDp.WorkPPpd) : A(3) = f4double(WDp.WorkPPmed)
                A(4) = f4double(WDp.WorkPPumbi) : A(5) = f4double(WDp.WorkPPumpd)
                A(6) = f4double(WDp.WorkPPpip) : A(7) = f4double(WDp.WorkPPcomp)
                A(8) = f4double(WDp.WorkPPcoll) : A(9) = f4double(WDp.WorkPPrent)
                A(10) = f4double(WDp.WorkPPtow) : A(11) = f4double(WDp.WorkCMbi)
                A(12) = f4double(WDp.WorkCMpd) : A(13) = f4double(WDp.WorkCMmed)
                A(14) = f4double(WDp.WorkCMumbi) : A(15) = f4double(WDp.WorkCMumpd)
                A(16) = f4double(WDp.WorkCMpip) : A(17) = f4double(WDp.WorkCMcomp)
                A(18) = f4double(WDp.WorkCMcoll) : A(19) = f4double(WDp.WorkCMrent)
                A(20) = f4double(WDp.WorkCMtow) : A(21) = f4double(WDp.WorkOTim)
                A(22) = f4double(WDp.WorkOTallied) : A(23) = f4double(WDp.WorkOTfire)
                A(24) = f4double(WDp.WorkOTmulti)
            End If

            Call f4assignDouble(WDp.WorkTotal, A(0) + MLobt)
            Call f4assignDouble(WDp.WorkPPbi, A(1) + MLobp(1))
            Call f4assignDouble(WDp.WorkPPpd, A(2) + MLobp(2))
            Call f4assignDouble(WDp.WorkPPmed, A(3) + MLobp(3))
            Call f4assignDouble(WDp.WorkPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(WDp.WorkPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(WDp.WorkPPpip, A(6) + MLobp(6))
            Call f4assignDouble(WDp.WorkPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(WDp.WorkPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(WDp.WorkPPrent, A(9) + MLobp(9))
            Call f4assignDouble(WDp.WorkPPtow, A(10) + MLobp(10))
            Call f4assignDouble(WDp.WorkCMbi, A(11) + MLobp(11))
            Call f4assignDouble(WDp.WorkCMpd, A(12) + MLobp(12))
            Call f4assignDouble(WDp.WorkCMmed, A(13) + MLobp(13))
            Call f4assignDouble(WDp.WorkCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(WDp.WorkCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(WDp.WorkCMpip, A(16) + MLobp(16))
            Call f4assignDouble(WDp.WorkCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(WDp.WorkCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(WDp.WorkCMrent, A(19) + MLobp(19))
            Call f4assignDouble(WDp.WorkCMtow, A(20) + MLobp(20))
            Call f4assignDouble(WDp.WorkOTim, A(21) + MLobp(21))
            Call f4assignDouble(WDp.WorkOTallied, A(22) + MLobp(22))
            Call f4assignDouble(WDp.WorkOTfire, A(23) + MLobp(23))
            Call f4assignDouble(WDp.WorkOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f13)
                rc = d4unlock(f13)
            End If

nextrec:
            rc = d4skip(f9, 1)
        Loop
    End Sub

    Sub TotalItdCed()
        Dim X As Integer

        Call d4tagSelect(f12, d4tag(f12, "K1"))
        rc = d4top(f12)
        ItdCedKey = ""
        rc = d4seek(f12, ItdCedKey)

        Do Until rc = r4eof
            If Trim(f4str(Ic1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Ic1p.CedPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Ic1p.CedCatCode))
            Wyear = Trim(f4str(Ic1p.CedYear))
            Wperiod = Trim(f4str(Ic1p.CedPeriod))

            If CDbl(CatCode) = 4 Then GoTo nextrec
            If CDbl(CatCode) = 9 Then GoTo nextrec
            If CDbl(CatCode) = 10 Then GoTo nextrec
            If CDbl(CatCode) = 13 Then GoTo nextrec
            If CDbl(CatCode) = 14 Then GoTo nextrec
            If CDbl(CatCode) = 15 Then GoTo nextrec
            If CDbl(CatCode) = 16 Then GoTo nextrec
            If CDbl(CatCode) = 17 Then GoTo nextrec

            'Write To ITD Ced File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetItdCedVar()

            WorkCedKey = Trim(f4str(Ic1p.CedMgaNmbr)) & Trim(f4str(Ic1p.CedTrtyNmbr)) & "12" & Trim(f4str(Ic1p.CedCatCode)) & Trim(f4str(Ic1p.CedYear))

            Call d4tagSelect(f14, d4tag(f14, "K1"))
            rc = d4top(f14)
            rc = d4seek(f14, WorkCedKey)

            AddTran = False
            If WorkCedKey <> Trim(f4str(Wc1p.CedMgaNmbr)) & Trim(f4str(Wc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Wc1p.CedCatCode)) & Trim(f4str(Wc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f14, 0) <> r4success Then Exit Sub
                Call f4assign(Wc1p.CedMgaNmbr, Trim(f4str(Ic1p.CedMgaNmbr)))
                Call f4assign(Wc1p.CedTrtyNmbr, Trim(f4str(Ic1p.CedTrtyNmbr)))
                Call f4assign(Wc1p.CedPeriod, "12")
                Call f4assign(Wc1p.CedCatCode, Trim(f4str(Ic1p.CedCatCode)))
                Call f4assign(Wc1p.CedYear, Trim(f4str(Ic1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(Wc1p.CedTotal) : A(1) = f4double(Wc1p.CedPPbi)
                A(2) = f4double(Wc1p.CedPPpd) : A(3) = f4double(Wc1p.CedPPmed)
                A(4) = f4double(Wc1p.CedPPumbi) : A(5) = f4double(Wc1p.CedPPumpd)
                A(6) = f4double(Wc1p.CedPPpip) : A(7) = f4double(Wc1p.CedPPcomp)
                A(8) = f4double(Wc1p.CedPPcoll) : A(9) = f4double(Wc1p.CedPPrent)
                A(10) = f4double(Wc1p.CedPPtow) : A(11) = f4double(Wc1p.CedCMbi)
                A(12) = f4double(Wc1p.CedCMpd) : A(13) = f4double(Wc1p.CedCMmed)
                A(14) = f4double(Wc1p.CedCMumbi) : A(15) = f4double(Wc1p.CedCMumpd)
                A(16) = f4double(Wc1p.CedCMpip) : A(17) = f4double(Wc1p.CedCMcomp)
                A(18) = f4double(Wc1p.CedCMcoll) : A(19) = f4double(Wc1p.CedCMrent)
                A(20) = f4double(Wc1p.CedCMtow) : A(21) = f4double(Wc1p.CedOTim)
                A(22) = f4double(Wc1p.CedOTallied) : A(23) = f4double(Wc1p.CedOTfire)
                A(24) = f4double(Wc1p.CedOTmulti)
            End If

            Call f4assignDouble(Wc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(Wc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(Wc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(Wc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(Wc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(Wc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(Wc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(Wc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(Wc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(Wc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(Wc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(Wc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(Wc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(Wc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(Wc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(Wc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(Wc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(Wc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(Wc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(Wc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(Wc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(Wc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(Wc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(Wc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(Wc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f14)
                rc = d4unlock(f14)
            End If

nextrec:
            rc = d4skip(f12, 1)
        Loop

    End Sub

    Sub TotalYtdCed()
        Dim X As Integer

        Call d4tagSelect(f10, d4tag(f10, "K1"))
        rc = d4top(f10)
        YtdCedKey = ""
        rc = d4seek(f10, YtdCedKey)

        Do Until rc = r4eof
            If Trim(f4str(YDc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(YDc1p.CedPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(YDc1p.CedCatCode))
            Wyear = Trim(f4str(YDc1p.CedYear))
            Wperiod = Trim(f4str(YDc1p.CedPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If txtPeriod.Text <> Wperiod Then GoTo nextrec
            End If

            'Write To ITD Ced File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetYtdCedVar()

            WorkCedKey = Trim(f4str(YDc1p.CedMgaNmbr)) & Trim(f4str(YDc1p.CedTrtyNmbr)) & "12" & Trim(f4str(YDc1p.CedCatCode)) & Trim(f4str(YDc1p.CedYear))

            Call d4tagSelect(f14, d4tag(f14, "K1"))
            rc = d4top(f14)
            rc = d4seek(f14, WorkCedKey)

            AddTran = False
            If WorkCedKey <> Trim(f4str(Wc1p.CedMgaNmbr)) & Trim(f4str(Wc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Wc1p.CedCatCode)) & Trim(f4str(Wc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f14, 0) <> r4success Then Exit Sub
                Call f4assign(Wc1p.CedMgaNmbr, Trim(f4str(YDc1p.CedMgaNmbr)))
                Call f4assign(Wc1p.CedTrtyNmbr, Trim(f4str(YDc1p.CedTrtyNmbr)))
                Call f4assign(Wc1p.CedPeriod, "12")
                Call f4assign(Wc1p.CedCatCode, Trim(f4str(YDc1p.CedCatCode)))
                Call f4assign(Wc1p.CedYear, Trim(f4str(YDc1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(Wc1p.CedTotal) : A(1) = f4double(Wc1p.CedPPbi)
                A(2) = f4double(Wc1p.CedPPpd) : A(3) = f4double(Wc1p.CedPPmed)
                A(4) = f4double(Wc1p.CedPPumbi) : A(5) = f4double(Wc1p.CedPPumpd)
                A(6) = f4double(Wc1p.CedPPpip) : A(7) = f4double(Wc1p.CedPPcomp)
                A(8) = f4double(Wc1p.CedPPcoll) : A(9) = f4double(Wc1p.CedPPrent)
                A(10) = f4double(Wc1p.CedPPtow) : A(11) = f4double(Wc1p.CedCMbi)
                A(12) = f4double(Wc1p.CedCMpd) : A(13) = f4double(Wc1p.CedCMmed)
                A(14) = f4double(Wc1p.CedCMumbi) : A(15) = f4double(Wc1p.CedCMumpd)
                A(16) = f4double(Wc1p.CedCMpip) : A(17) = f4double(Wc1p.CedCMcomp)
                A(18) = f4double(Wc1p.CedCMcoll) : A(19) = f4double(Wc1p.CedCMrent)
                A(20) = f4double(Wc1p.CedCMtow) : A(21) = f4double(Wc1p.CedOTim)
                A(22) = f4double(Wc1p.CedOTallied) : A(23) = f4double(Wc1p.CedOTfire)
                A(24) = f4double(Wc1p.CedOTmulti)
            End If

            Call f4assignDouble(Wc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(Wc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(Wc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(Wc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(Wc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(Wc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(Wc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(Wc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(Wc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(Wc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(Wc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(Wc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(Wc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(Wc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(Wc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(Wc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(Wc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(Wc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(Wc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(Wc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(Wc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(Wc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(Wc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(Wc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(Wc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f14)
                rc = d4unlock(f14)
            End If

nextrec:
            rc = d4skip(f10, 1)
        Loop

    End Sub
End Class