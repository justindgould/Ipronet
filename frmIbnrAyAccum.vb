Option Strict Off
Option Explicit On
Friend Class frmIbnrAyAccum
    Inherits DevExpress.XtraEditors.XtraForm

    Dim CatCode As String
    Dim Wperiod As String
    Dim J2str As String
    Dim Kstr As String
    Dim Kstr1 As String

    Dim L0 As Integer
    Dim T(16) As Double
    Dim B(16, 24) As Double
    Dim A(24) As Double
    Dim A1 As Double
    Dim A2 As Double
    Dim n As Double

    Private Sub cmdCont_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCont.Click
        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Wperiod = txtPeriod.Text

        'RPTDIR
        ProcessDirAyData()

        'RPTCED
        ProcessCedAyData()

        'ITDDIR
        ProcessItdAyData()

        'Final Check
        FinalAyDirCheck()

        Me.Close()
    End Sub

    Private Sub frmIbnrAyAccum_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

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

    Sub ProcessDirAyData()
        Dim X As Integer
        Dim n As Integer

        'Initialize
        OpenRptDir()
        OpenAyDir()
        ClearAyDir()

        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X

        '==================================================================================
        '=Get RPTDIR YTD
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K5"))
        rc = d4top(f5)

        Do Until rc = r4eof
            DspCount()

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then GoTo nextrec
            If Trim(f4str(RDp.RptMgaNmbr)) = "017" Then GoTo nextrec
            'If Trim(f4str(RDp.RptMgaNmbr)) = "057" Then GoTo nextrec

            If Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) = "" Then GoTo nextrec

            If Kstr = "" Then
                Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptYear)) & Trim(f4str(RDp.RptCatCode))
            End If

            Kstr1 = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptYear)) & Trim(f4str(RDp.RptCatCode))

            If Kstr <> Kstr1 Then
                WriteAyDirRec()
                Kstr = Kstr1

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    For n = 0 To 24 : B(X, n) = 0 : Next n
                Next X
            End If

            If Trim(f4str(RDp.RptPeriod)) > Wperiod Then GoTo nextrec

            CatCode = Trim(f4str(RDp.RptCatCode))
            n = CDbl(CatCode)
            If n < 6 Or n > 10 Then GoTo nextrec

            GetRptDirVar()

            A1 = MLobt
            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            'Earned and Reserves
            If n = 9 Or n = 10 Then
                If Trim(f4str(RDp.RptPeriod)) = Wperiod Then
                    For X = 1 To 24
                        B(n, X) = B(n, X) + A(X)
                    Next X
                    T(n) = T(n) + A1
                    GoTo nextrec
                Else
                    GoTo nextrec
                End If
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
            Next X
            T(n) = T(n) + A1

nextrec:
            rc = d4skip(f5, 1)
        Loop

        WriteAyDirRec()

    End Sub

    Sub ProcessCedAyData()
        Dim X As Short
        Dim X1 As Short
        Dim Fct As Short
        Dim n As Integer


        'Initialize
        OpenAyCed()
        ClearAyCed()

        '==================================================================================
        '=Get RPTCED YTD
        '==================================================================================
        For X1 = 1 To 5
            L0 = 0
            For X = 0 To 16
                T(X) = 0
                For n = 0 To 24 : B(X, n) = 0 : Next n
            Next X

            Fct = Fct + 1
            If Fct = 1 Then OpenRptCed1()
            If Fct = 2 Then OpenRptCed2()
            If Fct = 3 Then OpenRptCed3()
            If Fct = 4 Then OpenRptCed4()
            If Fct = 5 Then OpenRptCed5()

            Kstr = ""

            Call d4tagSelect(f6, d4tag(f6, "K5"))
            rc = d4top(f6)

            Do Until rc = r4eof
                DspCount()

                If Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Then GoTo nextrec
                If Trim(f4str(Rc1p.CedMgaNmbr)) = "017" Then GoTo nextrec
                'If Trim(f4str(Rc1p.CedMgaNmbr)) = "057" Then GoTo nextrec

                If Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) = "" Then GoTo nextrec

                If Kstr = "" Then
                    Kstr = Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedYear)) & Trim(f4str(Rc1p.CedCatCode))
                End If

                Kstr1 = Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedYear)) & Trim(f4str(Rc1p.CedCatCode))

                If Kstr <> Kstr1 Then
                    WriteAyCedRec()
                    Kstr = Kstr1

                    'Initialize
                    For X = 0 To 16
                        T(X) = 0
                        For n = 0 To 24 : B(X, n) = 0 : Next n
                    Next X
                End If

                If Trim(f4str(Rc1p.CedPeriod)) > Wperiod Then GoTo nextrec

                CatCode = Trim(f4str(Rc1p.CedCatCode))
                n = CDbl(CatCode)
                If n < 6 Or n > 10 Then GoTo nextrec

                GetRptCedVar()

                A1 = MLobt
                For X = 1 To 24 : A(X) = MLobp(X) : Next X

                'Earned and Reserves
                If n = 9 Or n = 10 Then
                    If Trim(f4str(Rc1p.CedPeriod)) = Wperiod Then
                        For X = 1 To 24
                            B(n, X) = B(n, X) + A(X)
                        Next X
                        T(n) = T(n) + A1
                        GoTo nextrec
                    Else
                        GoTo nextrec
                    End If
                End If

                For X = 1 To 24
                    B(n, X) = B(n, X) + A(X)
                Next X
                T(n) = T(n) + A1

nextrec:
                rc = d4skip(f6, 1)
            Loop

            WriteAyCedRec()

            If Fct = 1 Then ClsRptCed1() : f6 = 0
            If Fct = 2 Then ClsRptCed2() : f6 = 0
            If Fct = 3 Then ClsRptCed3() : f6 = 0
            If Fct = 4 Then ClsRptCed4() : f6 = 0
            If Fct = 5 Then ClsRptCed5() : f6 = 0
        Next X1

        ClsAyCed() : f20 = 0
    End Sub

    Sub ProcessItdAyData()
        Dim X As Short
        Dim n As Integer

        'Initialize
        OpenItdDir()
        OpenAyDir()
        OpenAyItd()
        ClearAyItd()

        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X

        L0 = 0 : Kstr = ""
        '==================================================================================
        '=Get ITDDIR
        '==================================================================================
        Call d4tagSelect(f11, d4tag(f11, "K5"))
        rc = d4top(f11)

        Do Until rc = r4eof
            DspCount()

            If Trim(f4str(IDp.ItdMgaNmbr)) = "016" Then GoTo nextrec
            If Trim(f4str(IDp.ItdMgaNmbr)) = "017" Then GoTo nextrec

            If Kstr = "" Then
                Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) & Trim(f4str(IDp.ItdYear)) & Trim(f4str(IDp.ItdCatCode))
            End If

            Kstr1 = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) & Trim(f4str(IDp.ItdYear)) & Trim(f4str(IDp.ItdCatCode))

            If Kstr <> Kstr1 Then
                GetAyDir()
                WriteAyItdRec()
                Kstr = Kstr1

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    For n = 0 To 24 : B(X, n) = 0 : Next n
                Next X
            End If

            CatCode = Trim(f4str(IDp.ItdCatCode))
            n = CDbl(CatCode)
            If n < 6 Or n > 8 Then GoTo nextrec

            GetItdDirVar()

            A1 = MLobt
            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            'Earned and Reserves
            If n = 9 Or n = 10 Then
                If Trim(f4str(IDp.ItdPeriod)) = Wperiod Then
                    For X = 1 To 24
                        B(n, X) = B(n, X) + A(X)
                    Next X
                    T(n) = T(n) + A1
                    GoTo nextrec
                Else
                    GoTo nextrec
                End If
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
            Next X
            T(n) = T(n) + A1

nextrec:
            rc = d4skip(f11, 1)
        Loop

        WriteAyItdRec()

        ClsItdDir() : f11 = 0
        ClsAyItd() : f22 = 0
        ClsAyDir() : f21 = 0
    End Sub

    Sub GetAyDir()
        Dim X As Integer

        Call d4tagSelect(f21, d4tag(f21, "K5"))
        rc = d4top(f21)
        rc = d4seek(f21, Kstr)

        Do Until Kstr <> (Trim(f4str(ADp.AydMgaNmbr)) & Trim(f4str(ADp.AydTrtyNmbr)) & Trim(f4str(ADp.AydYear)) & Trim(f4str(ADp.AydCatCode)))

            If Kstr <> (Trim(f4str(ADp.AydMgaNmbr)) & Trim(f4str(ADp.AydTrtyNmbr)) & Trim(f4str(ADp.AydYear)) & Trim(f4str(ADp.AydCatCode))) Then
                GoTo nextrec1
            End If

            GetAyDirVar()
            CatCode = Trim(f4str(ADp.AydCatCode))
            n = CDbl(CatCode)
            A1 = MLobt

            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            'Earned and Reserves
            If n = 9 Or n = 10 Then
                If Trim(f4str(ADp.AydPeriod)) = Wperiod Then
                    For X = 1 To 24
                        B(n, X) = B(n, X) + A(X)
                    Next X
                    T(n) = T(n) + A1
                    GoTo nextrec1
                Else
                    GoTo nextrec1
                End If
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
            Next X
            T(n) = T(n) + A1

nextrec1:
            rc = d4skip(f21, 1)
        Loop

    End Sub

    Sub FinalAyDirCheck()
        Dim n As Integer
        Dim X As Integer

        OpenItdDir()
        OpenAyDir()
        OpenAyItd()

        Kstr = "" : L0 = 0
        Call d4tagSelect(f21, d4tag(f21, "K5"))
        rc = d4top(f21)

        Do Until rc = r4eof
            DspCount()

            If Kstr = "" Then Kstr = Trim(f4str(ADp.AydMgaNmbr)) & Trim(f4str(ADp.AydTrtyNmbr)) & Trim(f4str(ADp.AydYear)) & Trim(f4str(ADp.AydCatCode))

            If Kstr <> (Trim(f4str(ADp.AydMgaNmbr)) & Trim(f4str(ADp.AydTrtyNmbr)) & Trim(f4str(ADp.AydYear)) & Trim(f4str(ADp.AydCatCode))) Then

                'Bypass if current year activity
                Call d4tagSelect(f11, d4tag(f11, "K5"))
                rc = d4top(f11)
                rc = d4seek(f11, Kstr)
                If Kstr <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) & Trim(f4str(IDp.ItdYear)) & Trim(f4str(IDp.ItdCatCode))) Then
                    If A2 <> 0 Then WriteAyItdRec()
                End If

                Kstr = Trim(f4str(ADp.AydMgaNmbr)) & Trim(f4str(ADp.AydTrtyNmbr)) & Trim(f4str(ADp.AydYear)) & Trim(f4str(ADp.AydCatCode))

                'Initialize
                For X = 0 To 16
                    T(X) = 0 : MLobp(X) = 0
                    For n = 0 To 24 : B(X, n) = 0 : Next n
                Next X
                A2 = 0
            End If

            GetAyDirVar()
            CatCode = Trim(f4str(ADp.AydCatCode))
            n = CDbl(CatCode)
            If n < 6 Or n > 10 Then GoTo nextrec1
            A1 = MLobt

            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            ' ACCUMULATE
            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                A2 = A2 + A(X)
            Next X
            T(n) = T(n) + A1

nextrec1:
            rc = d4skip(f21, 1)
        Loop

        If A2 <> 0 Then WriteAyItdRec()

        ClsItdDir() : f11 = 0
        ClsAyItd() : f22 = 0
        ClsAyDir() : f21 = 0
    End Sub

    Sub WriteAyDirRec()
        Dim C1 As Short

        C1 = Val(Mid(Kstr, 10, 2))
        If C1 < 6 Or C1 > 10 Then Exit Sub
        If T(C1) = 0 Then Exit Sub

        'Bypass inactive
        TrtyKey = Mid(Kstr, 1, 5)
        RdTrtyPrmRec()
        If Trim(f4str(TPp.PrmStatus)) = "1" Then Exit Sub

        If d4appendStart(f21, 0) <> r4success Then Exit Sub

        Call f4assign(ADp.AydMgaNmbr, Mid(Kstr, 1, 3))
        Call f4assign(ADp.AydTrtyNmbr, Mid(Kstr, 4, 2))
        Call f4assign(ADp.AydPeriod, (txtPeriod.Text))
        Call f4assign(ADp.AydCatCode, Mid(Kstr, 10, 2))
        Call f4assign(ADp.AydYear, Mid(Kstr, 6, 4))
        Call f4assignDouble(ADp.AydTotal, T(C1))
        Call f4assignDouble(ADp.AydPPbi, B(C1, 1))
        Call f4assignDouble(ADp.AydPPpd, B(C1, 2))
        Call f4assignDouble(ADp.AydPPmed, B(C1, 3))
        Call f4assignDouble(ADp.AydPPumbi, B(C1, 4))
        Call f4assignDouble(ADp.AydPPumpd, B(C1, 5))
        Call f4assignDouble(ADp.AydPPpip, B(C1, 6))
        Call f4assignDouble(ADp.AydPPcomp, B(C1, 7))
        Call f4assignDouble(ADp.AydPPcoll, B(C1, 8))
        Call f4assignDouble(ADp.AydPPrent, B(C1, 9))
        Call f4assignDouble(ADp.AydPPtow, B(C1, 10))
        Call f4assignDouble(ADp.AydCMbi, B(C1, 11))
        Call f4assignDouble(ADp.AydCMpd, B(C1, 12))
        Call f4assignDouble(ADp.AydCMmed, B(C1, 13))
        Call f4assignDouble(ADp.AydCMumbi, B(C1, 14))
        Call f4assignDouble(ADp.AydCMumpd, B(C1, 15))
        Call f4assignDouble(ADp.AydCMpip, B(C1, 16))
        Call f4assignDouble(ADp.AydCMcomp, B(C1, 17))
        Call f4assignDouble(ADp.AydCMcoll, B(C1, 18))
        Call f4assignDouble(ADp.AydCMrent, B(C1, 19))
        Call f4assignDouble(ADp.AydCMtow, B(C1, 20))
        Call f4assignDouble(ADp.AydOTim, B(C1, 21))
        Call f4assignDouble(ADp.AydOTallied, B(C1, 22))
        Call f4assignDouble(ADp.AydOTfire, B(C1, 23))
        Call f4assignDouble(ADp.AydOTmulti, B(C1, 24))

        rc = d4append(f21)
        rc = d4unlock(f21)
    End Sub

    Sub WriteAyCedRec()
        Dim C1 As Short

        C1 = Val(Mid(Kstr, 10, 2))
        If C1 < 6 Or C1 > 10 Then Exit Sub
        If T(C1) = 0 Then Exit Sub

        'Bypass inactive
        TrtyKey = Mid(Kstr, 1, 5)
        RdTrtyPrmRec()
        If Trim(f4str(TPp.PrmStatus)) = "1" Then Exit Sub

        If d4appendStart(f20, 0) <> r4success Then Exit Sub

        Call f4assign(ACp.AycMgaNmbr, Mid(Kstr, 1, 3))
        Call f4assign(ACp.AycTrtyNmbr, Mid(Kstr, 4, 2))
        Call f4assign(ACp.AycPeriod, (txtPeriod.Text))
        Call f4assign(ACp.AycCatCode, Mid(Kstr, 10, 2))
        Call f4assign(ACp.AycYear, Mid(Kstr, 6, 4))
        Call f4assignDouble(ACp.AycTotal, T(C1))
        Call f4assignDouble(ACp.AycPPbi, B(C1, 1))
        Call f4assignDouble(ACp.AycPPpd, B(C1, 2))
        Call f4assignDouble(ACp.AycPPmed, B(C1, 3))
        Call f4assignDouble(ACp.AycPPumbi, B(C1, 4))
        Call f4assignDouble(ACp.AycPPumpd, B(C1, 5))
        Call f4assignDouble(ACp.AycPPpip, B(C1, 6))
        Call f4assignDouble(ACp.AycPPcomp, B(C1, 7))
        Call f4assignDouble(ACp.AycPPcoll, B(C1, 8))
        Call f4assignDouble(ACp.AycPPrent, B(C1, 9))
        Call f4assignDouble(ACp.AycPPtow, B(C1, 10))
        Call f4assignDouble(ACp.AycCMbi, B(C1, 11))
        Call f4assignDouble(ACp.AycCMpd, B(C1, 12))
        Call f4assignDouble(ACp.AycCMmed, B(C1, 13))
        Call f4assignDouble(ACp.AycCMumbi, B(C1, 14))
        Call f4assignDouble(ACp.AycCMumpd, B(C1, 15))
        Call f4assignDouble(ACp.AycCMpip, B(C1, 16))
        Call f4assignDouble(ACp.AycCMcomp, B(C1, 17))
        Call f4assignDouble(ACp.AycCMcoll, B(C1, 18))
        Call f4assignDouble(ACp.AycCMrent, B(C1, 19))
        Call f4assignDouble(ACp.AycCMtow, B(C1, 20))
        Call f4assignDouble(ACp.AycOTim, B(C1, 21))
        Call f4assignDouble(ACp.AycOTallied, B(C1, 22))
        Call f4assignDouble(ACp.AycOTfire, B(C1, 23))
        Call f4assignDouble(ACp.AycOTmulti, B(C1, 24))

        rc = d4append(f20)
        rc = d4unlock(f20)
    End Sub

    Sub WriteAyItdRec()
        Dim C1 As Short

        'Bypass inactive
        TrtyKey = Mid(Kstr, 1, 5)
        RdTrtyPrmRec()
        If Trim(f4str(TPp.PrmStatus)) = "1" Then Exit Sub

        C1 = Val(Mid(Kstr, 10, 2))
        If C1 < 6 Or C1 > 10 Then Exit Sub
        If T(C1) = 0 Then Exit Sub

        If d4appendStart(f22, 0) <> r4success Then Exit Sub

        Call f4assign(AIp.AyiMgaNmbr, Mid(Kstr, 1, 3))
        Call f4assign(AIp.AyiTrtyNmbr, Mid(Kstr, 4, 2))
        Call f4assign(AIp.AyiPeriod, (txtPeriod.Text))
        Call f4assign(AIp.AyiCatCode, Mid(Kstr, 10, 2))
        Call f4assign(AIp.AyiYear, Mid(Kstr, 6, 4))
        Call f4assignDouble(AIp.AyiTotal, T(C1))
        Call f4assignDouble(AIp.AyiPPbi, B(C1, 1))
        Call f4assignDouble(AIp.AyiPPpd, B(C1, 2))
        Call f4assignDouble(AIp.AyiPPmed, B(C1, 3))
        Call f4assignDouble(AIp.AyiPPumbi, B(C1, 4))
        Call f4assignDouble(AIp.AyiPPumpd, B(C1, 5))
        Call f4assignDouble(AIp.AyiPPpip, B(C1, 6))
        Call f4assignDouble(AIp.AyiPPcomp, B(C1, 7))
        Call f4assignDouble(AIp.AyiPPcoll, B(C1, 8))
        Call f4assignDouble(AIp.AyiPPrent, B(C1, 9))
        Call f4assignDouble(AIp.AyiPPtow, B(C1, 10))
        Call f4assignDouble(AIp.AyiCMbi, B(C1, 11))
        Call f4assignDouble(AIp.AyiCMpd, B(C1, 12))
        Call f4assignDouble(AIp.AyiCMmed, B(C1, 13))
        Call f4assignDouble(AIp.AyiCMumbi, B(C1, 14))
        Call f4assignDouble(AIp.AyiCMumpd, B(C1, 15))
        Call f4assignDouble(AIp.AyiCMpip, B(C1, 16))
        Call f4assignDouble(AIp.AyiCMcomp, B(C1, 17))
        Call f4assignDouble(AIp.AyiCMcoll, B(C1, 18))
        Call f4assignDouble(AIp.AyiCMrent, B(C1, 19))
        Call f4assignDouble(AIp.AyiCMtow, B(C1, 20))
        Call f4assignDouble(AIp.AyiOTim, B(C1, 21))
        Call f4assignDouble(AIp.AyiOTallied, B(C1, 22))
        Call f4assignDouble(AIp.AyiOTfire, B(C1, 23))
        Call f4assignDouble(AIp.AyiOTmulti, B(C1, 24))

        rc = d4append(f22)
        rc = d4unlock(f22)
    End Sub

    Sub ClearAyDir()
        Call d4tagSelect(f21, 0)
        rc = d4top(f21)
        d4lockFile(f21)

        Do While rc = r4success
            Call d4delete(f21)
            rc = d4skip(f21, 1)
        Loop

        d4pack(f21)
        d4unlock(f21)
    End Sub

    Sub ClearAyCed()
        Call d4tagSelect(f20, 0)
        rc = d4top(f20)
        d4lockFile(f20)

        Do While rc = r4success
            Call d4delete(f20)
            rc = d4skip(f20, 1)
        Loop

        d4pack(f20)
        d4unlock(f20)
    End Sub

    Sub ClearAyItd()
        Call d4tagSelect(f22, 0)
        rc = d4top(f22)
        d4lockFile(f22)

        Do While rc = r4success
            Call d4delete(f22)
            rc = d4skip(f22, 1)
        Loop

        d4pack(f22)
        d4unlock(f22)
    End Sub

    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub
End Class