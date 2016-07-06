Option Strict Off
Option Explicit On
Friend Class frmEoyYtdAccum
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

    Private Sub frmEoyYtdAccum_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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

        'RPT Dir
        OpenRptDir()
        OpenYtdDir()
        TotalYtdDir()
        ClsRptDir() : f5 = 0
        ClsYtdDir() : f9 = 0

        'RPT Ced1
        OpenRptCed1()
        OpenYtdCed1()
        TotalYtdCed()
        ClsRptCed1() : f6 = 0
        ClsYtdCed1() : f10 = 0

        'RPT Ced2
        OpenRptCed2()
        OpenYtdCed2()
        TotalYtdCed()
        ClsRptCed2() : f6 = 0
        ClsYtdCed2() : f10 = 0

        'RPT Ced3
        OpenRptCed3()
        OpenYtdCed3()
        TotalYtdCed()
        ClsRptCed3() : f6 = 0
        ClsYtdCed3() : f10 = 0

        'RPT Ced4
        OpenRptCed4()
        OpenYtdCed4()
        TotalYtdCed()
        ClsRptCed4() : f6 = 0
        ClsYtdCed4() : f10 = 0

        'RPT Ced5
        OpenRptCed5()
        OpenYtdCed5()
        TotalYtdCed()
        ClsRptCed5() : f6 = 0
        ClsYtdCed5() : f10 = 0

        Me.Text = CaptLine & "          " & "Status: End Processing"
    End Sub

    Sub TotalYtdDir()
        Dim X As Integer

        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = ""
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof
            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(RDp.RptCatCode))
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If txtPeriod.Text <> Wperiod Then GoTo nextrec
            End If

            'Write To YTD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetRptDirVar()

            YtdDirKey = txRptMgaNmbr & txRptTrtyNmbr & "12" & txRptCatCode & txRptYear
            Call d4tagSelect(f9, d4tag(f9, "K1"))
            rc = d4top(f9)
            rc = d4seek(f9, YtdDirKey)

            AddTran = False
            If YtdDirKey <> Trim(f4str(YDp.YtdMgaNmbr)) & Trim(f4str(YDp.YtdTrtyNmbr)) & "12" & Trim(f4str(YDp.YtdCatCode)) & Trim(f4str(YDp.YtdYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f9, 0) <> r4success Then Exit Sub
                Call f4assign(YDp.YtdMgaNmbr, txRptMgaNmbr)
                Call f4assign(YDp.YtdTrtyNmbr, txRptTrtyNmbr)
                Call f4assign(YDp.YtdPeriod, "12")
                Call f4assign(YDp.YtdCatCode, txRptCatCode)
                Call f4assign(YDp.YtdYear, txRptYear)
            End If

            If Not AddTran Then
                A(0) = f4double(YDp.YtdTotal) : A(1) = f4double(YDp.YtdPPbi)
                A(2) = f4double(YDp.YtdPPpd) : A(3) = f4double(YDp.YtdPPmed)
                A(4) = f4double(YDp.YtdPPumbi) : A(5) = f4double(YDp.YtdPPumpd)
                A(6) = f4double(YDp.YtdPPpip) : A(7) = f4double(YDp.YtdPPcomp)
                A(8) = f4double(YDp.YtdPPcoll) : A(9) = f4double(YDp.YtdPPrent)
                A(10) = f4double(YDp.YtdPPtow) : A(11) = f4double(YDp.YtdCMbi)
                A(12) = f4double(YDp.YtdCMpd) : A(13) = f4double(YDp.YtdCMmed)
                A(14) = f4double(YDp.YtdCMumbi) : A(15) = f4double(YDp.YtdCMumpd)
                A(16) = f4double(YDp.YtdCMpip) : A(17) = f4double(YDp.YtdCMcomp)
                A(18) = f4double(YDp.YtdCMcoll) : A(19) = f4double(YDp.YtdCMrent)
                A(20) = f4double(YDp.YtdCMtow) : A(21) = f4double(YDp.YtdOTim)
                A(22) = f4double(YDp.YtdOTallied) : A(23) = f4double(YDp.YtdOTfire)
                A(24) = f4double(YDp.YtdOTmulti)
            End If

            Call f4assignDouble(YDp.YtdTotal, A(0) + MLobt)
            Call f4assignDouble(YDp.YtdPPbi, A(1) + MLobp(1))
            Call f4assignDouble(YDp.YtdPPpd, A(2) + MLobp(2))
            Call f4assignDouble(YDp.YtdPPmed, A(3) + MLobp(3))
            Call f4assignDouble(YDp.YtdPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(YDp.YtdPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(YDp.YtdPPpip, A(6) + MLobp(6))
            Call f4assignDouble(YDp.YtdPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(YDp.YtdPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(YDp.YtdPPrent, A(9) + MLobp(9))
            Call f4assignDouble(YDp.YtdPPtow, A(10) + MLobp(10))
            Call f4assignDouble(YDp.YtdCMbi, A(11) + MLobp(11))
            Call f4assignDouble(YDp.YtdCMpd, A(12) + MLobp(12))
            Call f4assignDouble(YDp.YtdCMmed, A(13) + MLobp(13))
            Call f4assignDouble(YDp.YtdCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(YDp.YtdCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(YDp.YtdCMpip, A(16) + MLobp(16))
            Call f4assignDouble(YDp.YtdCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(YDp.YtdCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(YDp.YtdCMrent, A(19) + MLobp(19))
            Call f4assignDouble(YDp.YtdCMtow, A(20) + MLobp(20))
            Call f4assignDouble(YDp.YtdOTim, A(21) + MLobp(21))
            Call f4assignDouble(YDp.YtdOTallied, A(22) + MLobp(22))
            Call f4assignDouble(YDp.YtdOTfire, A(23) + MLobp(23))
            Call f4assignDouble(YDp.YtdOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f9)
                rc = d4unlock(f9)
            End If

nextrec:
            rc = d4skip(f5, 1)
        Loop

    End Sub

    Sub TotalYtdCed()
        Dim X As Integer

        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = ""
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof
            If Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Rc1p.CedPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Rc1p.CedCatCode))
            Wyear = Trim(f4str(Rc1p.CedYear))
            Wperiod = Trim(f4str(Rc1p.CedPeriod))

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Or CDbl(CatCode) = 15 Or CDbl(CatCode) = 16 Or CDbl(CatCode) = 17 Then
                If txtPeriod.Text <> Wperiod Then GoTo nextrec
            End If

            'Write To YTD Dir File
            For X = 0 To 24
                A(X) = 0
            Next X

            GetRptCedVar()

            YtdCedKey = Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & "12" & Trim(f4str(Rc1p.CedCatCode)) & Trim(f4str(Rc1p.CedYear))
            Call d4tagSelect(f10, d4tag(f10, "K1"))
            rc = d4top(f10)
            rc = d4seek(f10, YtdCedKey)

            AddTran = False
            If YtdCedKey <> Trim(f4str(YDc1p.CedMgaNmbr)) & Trim(f4str(YDc1p.CedTrtyNmbr)) & "12" & Trim(f4str(YDc1p.CedCatCode)) & Trim(f4str(YDc1p.CedYear)) Then
                AddTran = True
            End If

            If AddTran Then
                If d4appendStart(f10, 0) <> r4success Then Exit Sub
                Call f4assign(YDc1p.CedMgaNmbr, Trim(f4str(Rc1p.CedMgaNmbr)))
                Call f4assign(YDc1p.CedTrtyNmbr, Trim(f4str(Rc1p.CedTrtyNmbr)))
                Call f4assign(YDc1p.CedPeriod, "12")
                Call f4assign(YDc1p.CedCatCode, Trim(f4str(Rc1p.CedCatCode)))
                Call f4assign(YDc1p.CedYear, Trim(f4str(Rc1p.CedYear)))
            End If

            If Not AddTran Then
                A(0) = f4double(YDc1p.CedTotal) : A(1) = f4double(YDc1p.CedPPbi)
                A(2) = f4double(YDc1p.CedPPpd) : A(3) = f4double(YDc1p.CedPPmed)
                A(4) = f4double(YDc1p.CedPPumbi) : A(5) = f4double(YDc1p.CedPPumpd)
                A(6) = f4double(YDc1p.CedPPpip) : A(7) = f4double(YDc1p.CedPPcomp)
                A(8) = f4double(YDc1p.CedPPcoll) : A(9) = f4double(YDc1p.CedPPrent)
                A(10) = f4double(YDc1p.CedPPtow) : A(11) = f4double(YDc1p.CedCMbi)
                A(12) = f4double(YDc1p.CedCMpd) : A(13) = f4double(YDc1p.CedCMmed)
                A(14) = f4double(YDc1p.CedCMumbi) : A(15) = f4double(YDc1p.CedCMumpd)
                A(16) = f4double(YDc1p.CedCMpip) : A(17) = f4double(YDc1p.CedCMcomp)
                A(18) = f4double(YDc1p.CedCMcoll) : A(19) = f4double(YDc1p.CedCMrent)
                A(20) = f4double(YDc1p.CedCMtow) : A(21) = f4double(YDc1p.CedOTim)
                A(22) = f4double(YDc1p.CedOTallied) : A(23) = f4double(YDc1p.CedOTfire)
                A(24) = f4double(YDc1p.CedOTmulti)
            End If

            Call f4assignDouble(YDc1p.CedTotal, A(0) + MLobt)
            Call f4assignDouble(YDc1p.CedPPbi, A(1) + MLobp(1))
            Call f4assignDouble(YDc1p.CedPPpd, A(2) + MLobp(2))
            Call f4assignDouble(YDc1p.CedPPmed, A(3) + MLobp(3))
            Call f4assignDouble(YDc1p.CedPPumbi, A(4) + MLobp(4))
            Call f4assignDouble(YDc1p.CedPPumpd, A(5) + MLobp(5))
            Call f4assignDouble(YDc1p.CedPPpip, A(6) + MLobp(6))
            Call f4assignDouble(YDc1p.CedPPcomp, A(7) + MLobp(7))
            Call f4assignDouble(YDc1p.CedPPcoll, A(8) + MLobp(8))
            Call f4assignDouble(YDc1p.CedPPrent, A(9) + MLobp(9))
            Call f4assignDouble(YDc1p.CedPPtow, A(10) + MLobp(10))
            Call f4assignDouble(YDc1p.CedCMbi, A(11) + MLobp(11))
            Call f4assignDouble(YDc1p.CedCMpd, A(12) + MLobp(12))
            Call f4assignDouble(YDc1p.CedCMmed, A(13) + MLobp(13))
            Call f4assignDouble(YDc1p.CedCMumbi, A(14) + MLobp(14))
            Call f4assignDouble(YDc1p.CedCMumpd, A(15) + MLobp(15))
            Call f4assignDouble(YDc1p.CedCMpip, A(16) + MLobp(16))
            Call f4assignDouble(YDc1p.CedCMcomp, A(17) + MLobp(17))
            Call f4assignDouble(YDc1p.CedCMcoll, A(18) + MLobp(18))
            Call f4assignDouble(YDc1p.CedCMrent, A(19) + MLobp(19))
            Call f4assignDouble(YDc1p.CedCMtow, A(20) + MLobp(20))
            Call f4assignDouble(YDc1p.CedOTim, A(21) + MLobp(21))
            Call f4assignDouble(YDc1p.CedOTallied, A(22) + MLobp(22))
            Call f4assignDouble(YDc1p.CedOTfire, A(23) + MLobp(23))
            Call f4assignDouble(YDc1p.CedOTmulti, A(24) + MLobp(24))

            If AddTran Then
                rc = d4append(f10)
                rc = d4unlock(f10)
            End If

nextrec:
            rc = d4skip(f6, 1)
        Loop

    End Sub
End Class