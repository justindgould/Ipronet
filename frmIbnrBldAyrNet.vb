Option Strict Off
Option Explicit On
Friend Class frmIbnrBldAyrNet
    Inherits DevExpress.XtraEditors.XtraForm

    Dim CatCode As String
    Dim Wperiod As String
    Dim J2str As String
    Dim Kstr As String
    Dim Kstr1 As String
    Dim Kstr2 As String
    Dim Ayrec As Boolean

    Dim L0 As Integer
    Dim T(16) As Double
    Dim B(16, 24) As Double
    Dim A(24) As Double
    Dim A1 As Double
    Dim n As Double

    Private Sub cmdCont_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCont.Click
        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Wperiod = txtPeriod.Text
        OpenItdAccyr()
        ClearItdAccyr()

        'RPTDIR
        ProcessDirData()

        'RPTCED
        ProcessCedData()

        'IBNRDIR
        ProcessIbnrDirData()

        'IBNRCED
        ProcessIbnrCedData()

        Me.Close()
    End Sub

    Private Sub frmIbnrBldAyrNet_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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
        Dim X As Short
        Tobj = txtPeriod

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = S1
        If S1 = "00" Then Tobj.Text = ""
    End Sub

    Sub ProcessDirData()
        Dim X, n As Short

        'Initialize
        OpenRptDir()

        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X

        '==================================================================================
        '=Get RPTDIR
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K3"))
        rc = d4top(f5)

        Do Until rc = r4eof
            DspCount()

            'Bypass Record If
            If Trim(f4str(RDp.RptPeriod)) > Wperiod Then GoTo nextrec

            CatCode = Trim(f4str(RDp.RptCatCode))
            n = CDbl(CatCode)
            If Trim(f4str(RDp.RptMgaNmbr)) <> "016" Then
                If n < 6 Or n > 10 Then GoTo nextrec
            End If

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
                If n < 6 Then GoTo nextrec
                If n > 10 Then
                    If n <> 13 And n <> 14 Then GoTo nextrec
                End If
            End If
            If Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) = "" Then GoTo nextrec

            If Kstr = "" Then Kstr = Trim(f4str(RDp.RptCatCode)) & Trim(f4str(RDp.RptYear))
            Kstr1 = Trim(f4str(RDp.RptCatCode)) & Trim(f4str(RDp.RptYear))

            'Write Record
            If Kstr <> Kstr1 Then
                GetItdAccyr()
                WriteItdAccyrRec()
                Kstr = Kstr1

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    For n = 0 To 24 : B(X, n) = 0 : Next n
                Next X
            End If

            GetRptDirVar()
            A1 = MLobt
            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            n = CDbl(Mid(Kstr, 1, 2))
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

        GetItdAccyr()
        WriteItdAccyrRec()

    End Sub

    Sub ProcessCedData()
        Dim X, n As Short
        Dim X1 As Short
        Dim Fct As Short

        '==================================================================================
        '=Get RPTCED
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

            Call d4tagSelect(f6, d4tag(f6, "K3"))
            rc = d4top(f6)

            Do Until rc = r4eof
                DspCount()

                'Bypass Record If
                CatCode = Trim(f4str(Rc1p.CedCatCode))
                n = CDbl(CatCode)
                If n > 16 Then GoTo nextrec
                If Trim(f4str(Rc1p.CedPeriod)) > Wperiod Then GoTo nextrec

                If Trim(f4str(Rc1p.CedMgaNmbr)) <> "016" Then
                    If n < 6 Or n > 10 Then GoTo nextrec
                End If

                If Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Then
                    If Trim(f4str(Rc1p.CedPeriod)) <> Wperiod Then GoTo nextrec
                    If n < 6 Then GoTo nextrec
                    If n > 10 Then
                        If n <> 13 And n <> 14 Then GoTo nextrec
                    End If
                End If

                If Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) = "" Then GoTo nextrec

                If Kstr = "" Then Kstr = Trim(f4str(Rc1p.CedCatCode)) & Trim(f4str(Rc1p.CedYear))
                Kstr1 = Trim(f4str(Rc1p.CedCatCode)) & Trim(f4str(Rc1p.CedYear))

                If Kstr <> Kstr1 Then
                    GetItdAccyr()
                    WriteItdAccyrRec()
                    Kstr = Kstr1

                    'Initialize
                    For X = 0 To 16
                        T(X) = 0
                        For n = 0 To 24 : B(X, n) = 0 : Next n
                    Next X
                End If

                GetRptCedVar()
                A1 = MLobt * -1
                For X = 1 To 24 : A(X) = MLobp(X) * -1 : Next X
                n = CDbl(Mid(Kstr, 1, 2))

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

            GetItdAccyr()
            WriteItdAccyrRec()

            If Fct = 1 Then ClsRptCed1() : f6 = 0
            If Fct = 2 Then ClsRptCed2() : f6 = 0
            If Fct = 3 Then ClsRptCed3() : f6 = 0
            If Fct = 4 Then ClsRptCed4() : f6 = 0
            If Fct = 5 Then ClsRptCed5() : f6 = 0
        Next X1

    End Sub

    Sub ProcessIbnrDirData()
        Dim X, n As Short

        'Initialize
        OpenIbnrDir()

        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X

        Kstr = "" : L0 = 0
        '==================================================================================
        '=Get IBNRDIR
        '==================================================================================
        Call d4tagSelect(f24, d4tag(f24, "K3"))
        rc = d4top(f24)

        Do Until rc = r4eof
            DspCount()

            If Trim(f4str(IBp.IbdMgaNmbr)) & Trim(f4str(IBp.IbdTrtyNmbr)) = "" Then GoTo nextrec

            If Kstr = "" Then Kstr = Trim(f4str(IBp.IbdCatCode)) & Trim(f4str(IBp.IbdYear))
            Kstr1 = Trim(f4str(IBp.IbdCatCode)) & Trim(f4str(IBp.IbdYear))

            If Kstr <> Kstr1 Then
                GetItdAccyr()
                WriteItdAccyrRec()
                Kstr = Kstr1

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    For n = 0 To 24 : B(X, n) = 0 : Next n
                Next X
            End If

            If Trim(f4str(IBp.IbdMgaNmbr)) = "016" Then
                If Trim(f4str(IBp.IbdPeriod)) <> Wperiod Then GoTo nextrec
            End If

            If Trim(f4str(IBp.IbdPeriod)) > Wperiod Then GoTo nextrec

            CatCode = Trim(f4str(IBp.IbdCatCode))
            n = CDbl(CatCode)

            GetIbnrDirVar()

            A1 = MLobt
            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            'Earned and Reserves
            If n = 9 Or n = 10 Then
                If Trim(f4str(IBp.IbdPeriod)) = Wperiod Then
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
            rc = d4skip(f24, 1)
        Loop

        GetItdAccyr()
        WriteItdAccyrRec()

    End Sub

    Sub ProcessIbnrCedData()
        Dim X, n As Short

        'Initialize
        OpenIbnrCed()

        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X

        Kstr = "" : L0 = 0
        '==================================================================================
        '=Get IBNRCED
        '==================================================================================
        Call d4tagSelect(f23, d4tag(f23, "K3"))
        rc = d4top(f23)

        Do Until rc = r4eof
            DspCount()

            If Trim(f4str(ICp.IbcMgaNmbr)) & Trim(f4str(ICp.IbcTrtyNmbr)) = "" Then GoTo nextrec

            If Kstr = "" Then Kstr = Trim(f4str(ICp.IbcCatCode)) & Trim(f4str(ICp.IbcYear))
            Kstr1 = Trim(f4str(ICp.IbcCatCode)) & Trim(f4str(ICp.IbcYear))

            If Kstr <> Kstr1 Then
                GetItdAccyr()
                WriteItdAccyrRec()
                Kstr = Kstr1

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    For n = 0 To 24 : B(X, n) = 0 : Next n
                Next X
            End If

            If Trim(f4str(ICp.IbcMgaNmbr)) = "016" Then
                If Trim(f4str(ICp.IbcPeriod)) <> Wperiod Then GoTo nextrec
            End If

            If Trim(f4str(ICp.IbcPeriod)) > Wperiod Then GoTo nextrec

            CatCode = Trim(f4str(ICp.IbcCatCode))
            n = CDbl(CatCode)

            GetIbnrCedVar()

            A1 = MLobt * -1
            For X = 1 To 24 : A(X) = MLobp(X) * -1 : Next X

            'Earned and Reserves
            If n = 9 Or n = 10 Then
                If Trim(f4str(ICp.IbcPeriod)) = Wperiod Then
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
            rc = d4skip(f23, 1)
        Loop

        GetItdAccyr()
        WriteItdAccyrRec()

    End Sub

    Sub GetItdAccyr()
        Dim X As Integer

        Kstr2 = "00101" & Trim(txtPeriod.Text) & Kstr
        Call d4tagSelect(f26, d4tag(f26, "K1"))
        rc = d4top(f26)
        rc = d4seek(f26, Kstr2)

        Do Until Kstr2 <> (Trim(f4str(IAp.IayMgaNmbr)) & Trim(f4str(IAp.IayTrtyNmbr)) & Trim(f4str(IAp.IayPeriod)) & Trim(f4str(IAp.IayCatCode)) & Trim(f4str(IAp.IayYear)))

            If Kstr2 <> (Trim(f4str(IAp.IayMgaNmbr)) & Trim(f4str(IAp.IayTrtyNmbr)) & Trim(f4str(IAp.IayPeriod)) & Trim(f4str(IAp.IayCatCode)) & Trim(f4str(IAp.IayYear))) Then
                GoTo nextrec1
            End If

            GetItdAccyrVar()
            CatCode = Trim(f4str(IAp.IayCatCode))
            n = CDbl(CatCode)
            A1 = MLobt

            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
            Next X
            T(n) = T(n) + A1
            Ayrec = True

nextrec1:
            rc = d4skip(f26, 1)
        Loop

    End Sub

    Sub WriteItdAccyrRec()
        Dim C1 As Short

        C1 = Val(Mid(Kstr, 1, 2))
        If C1 < 6 Then Exit Sub
        If C1 > 10 Then
            If C1 <> 13 And C1 <> 14 Then Exit Sub
        End If

        If Not Ayrec Then
            If T(C1) = 0 Then Exit Sub
        End If

        If Ayrec Then
            Kstr2 = "00101" & Trim(txtPeriod.Text) & Kstr
            Call d4tagSelect(f26, d4tag(f26, "K1"))
            rc = d4top(f26)
            rc = d4seek(f26, Kstr2)
        End If

        If Not Ayrec Then
            If d4appendStart(f26, 0) <> r4success Then Exit Sub
        End If

        Call f4assign(IAp.IayMgaNmbr, "001")
        Call f4assign(IAp.IayTrtyNmbr, "01")
        Call f4assign(IAp.IayPeriod, (txtPeriod.Text))
        Call f4assign(IAp.IayCatCode, Mid(Kstr, 1, 2))
        Call f4assign(IAp.IayYear, Mid(Kstr, 3, 4))
        Call f4assignDouble(IAp.IayTotal, T(C1))
        Call f4assignDouble(IAp.IayPPbi, B(C1, 1))
        Call f4assignDouble(IAp.IayPPpd, B(C1, 2))
        Call f4assignDouble(IAp.IayPPmed, B(C1, 3))
        Call f4assignDouble(IAp.IayPPumbi, B(C1, 4))
        Call f4assignDouble(IAp.IayPPumpd, B(C1, 5))
        Call f4assignDouble(IAp.IayPPpip, B(C1, 6))
        Call f4assignDouble(IAp.IayPPcomp, B(C1, 7))
        Call f4assignDouble(IAp.IayPPcoll, B(C1, 8))
        Call f4assignDouble(IAp.IayPPrent, B(C1, 9))
        Call f4assignDouble(IAp.IayPPtow, B(C1, 10))
        Call f4assignDouble(IAp.IayCMbi, B(C1, 11))
        Call f4assignDouble(IAp.IayCMpd, B(C1, 12))
        Call f4assignDouble(IAp.IayCMmed, B(C1, 13))
        Call f4assignDouble(IAp.IayCMumbi, B(C1, 14))
        Call f4assignDouble(IAp.IayCMumpd, B(C1, 15))
        Call f4assignDouble(IAp.IayCMpip, B(C1, 16))
        Call f4assignDouble(IAp.IayCMcomp, B(C1, 17))
        Call f4assignDouble(IAp.IayCMcoll, B(C1, 18))
        Call f4assignDouble(IAp.IayCMrent, B(C1, 19))
        Call f4assignDouble(IAp.IayCMtow, B(C1, 20))
        Call f4assignDouble(IAp.IayOTim, B(C1, 21))
        Call f4assignDouble(IAp.IayOTallied, B(C1, 22))
        Call f4assignDouble(IAp.IayOTfire, B(C1, 23))
        Call f4assignDouble(IAp.IayOTmulti, B(C1, 24))

        If Not Ayrec Then
            rc = d4append(f26)
        End If
        rc = d4unlock(f26)
        Ayrec = False
    End Sub

    Sub ClearItdAccyr()
        Call d4tagSelect(f26, 0)
        rc = d4top(f26)
        d4lockFile(f26)

        Do While rc = r4success
            Call d4delete(f26)
            rc = d4skip(f26, 1)
        Loop

        d4pack(f26)
        d4unlock(f26)
    End Sub

    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub
End Class