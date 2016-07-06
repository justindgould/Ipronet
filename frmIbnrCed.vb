Option Strict Off
Option Explicit On
Friend Class frmIbnrCed
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Wperiod As String

    Dim J2str As String
    Dim Kstr As String

    Dim L0 As Integer
    Dim B(24) As Double
    Dim B1 As Double
    Dim A(24) As Double
    Dim A1 As Double

    Private Sub cmdCont_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCont.Click
        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Wperiod = txtPeriod.Text

        'IBNR Calc
        OpenIbnrDir()
        OpenIbnrCed()

        ClearIbnrCed()
        ProcessIbnrCed()

        Me.Close()
    End Sub

    Private Sub frmIbnrCed_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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

    Sub ProcessIbnrCed()
        Dim X As Short
        Dim CedPerc As Double
        Dim N0 As Double
        Dim N1 As Double
        Dim T As Double
        Dim Y As Short

        L0 = 0 : Kstr = ""

        '==================================================================================
        '=Get INBR DIR
        '==================================================================================
        Call d4tagSelect(f24, d4tag(f24, "K1"))
        rc = d4top(f24)

        Do Until rc = r4eof
            DspCount()
            Kstr = Trim(f4str(IBp.IbdMgaNmbr)) & Trim(f4str(IBp.IbdTrtyNmbr)) & Trim(f4str(IBp.IbdPeriod)) & Trim(f4str(IBp.IbdCatCode)) & Trim(f4str(IBp.IbdYear))

            'Get Ced Percentage
            TrtyKey = Mid(Kstr, 1, 5)
            RdTrtyMstRec()
            CedPerc = f4double(TMp.TrtyCedPerc)

            GetIbnrDirVar()

            A1 = MLobt
            For X = 1 To 24
                B(X) = 0
                A(X) = MLobp(X)
            Next X

            T = 0 : N1 = 0 : Y = 0
            B1 = Math.Round(A1 * CedPerc, 2)

            'Compute Ceding Coverages
            For X = 1 To 24
                B(X) = Math.Round(A(X) * CedPerc, 2)

                'Rounding Logic
                If B(X) > 0 Then
                    If B(X) > N1 Then
                        N1 = B(X)
                        Y = X
                    End If
                    T = T + B(X)
                End If

                If B(X) < 0 Then
                    If B(X) < N1 Then
                        N1 = B(X)
                        Y = X
                    End If
                    T = T + B(X)
                End If
            Next X

            'Adjust for Rounding Error
            N0 = B1 - T
            B(Y) = B(Y) + N0

            WriteIbnrCedRec()

nextrec:
            rc = d4skip(f24, 1)
        Loop

    End Sub

    Sub WriteIbnrCedRec()
        If d4appendStart(f23, 0) <> r4success Then Exit Sub

        Call f4assign(ICp.IbcMgaNmbr, Mid(Kstr, 1, 3))
        Call f4assign(ICp.IbcTrtyNmbr, Mid(Kstr, 4, 2))
        Call f4assign(ICp.IbcPeriod, Mid(Kstr, 6, 2))
        Call f4assign(ICp.IbcCatCode, Mid(Kstr, 8, 2))
        Call f4assign(ICp.IbcYear, Mid(Kstr, 10, 4))
        Call f4assignDouble(ICp.IbcTotal, B1)
        Call f4assignDouble(ICp.IbcPPbi, B(1))
        Call f4assignDouble(ICp.IbcPPpd, B(2))
        Call f4assignDouble(ICp.IbcPPmed, B(3))
        Call f4assignDouble(ICp.IbcPPumbi, B(4))
        Call f4assignDouble(ICp.IbcPPumpd, B(5))
        Call f4assignDouble(ICp.IbcPPpip, B(6))
        Call f4assignDouble(ICp.IbcPPcomp, B(7))
        Call f4assignDouble(ICp.IbcPPcoll, B(8))
        Call f4assignDouble(ICp.IbcPPrent, B(9))
        Call f4assignDouble(ICp.IbcPPtow, B(10))
        Call f4assignDouble(ICp.IbcCMbi, B(11))
        Call f4assignDouble(ICp.IbcCMpd, B(12))
        Call f4assignDouble(ICp.IbcCMmed, B(13))
        Call f4assignDouble(ICp.IbcCMumbi, B(14))
        Call f4assignDouble(ICp.IbcCMumpd, B(15))
        Call f4assignDouble(ICp.IbcCMpip, B(16))
        Call f4assignDouble(ICp.IbcCMcomp, B(17))
        Call f4assignDouble(ICp.IbcCMcoll, B(18))
        Call f4assignDouble(ICp.IbcCMrent, B(19))
        Call f4assignDouble(ICp.IbcCMtow, B(20))
        Call f4assignDouble(ICp.IbcOTim, B(21))
        Call f4assignDouble(ICp.IbcOTallied, B(22))
        Call f4assignDouble(ICp.IbcOTfire, B(23))
        Call f4assignDouble(ICp.IbcOTmulti, B(24))

        rc = d4append(f23)
        rc = d4unlock(f23)
    End Sub

    Sub ClearIbnrCed()
        Call d4tagSelect(f23, 0)
        rc = d4top(f23)
        d4lockFile(f23)

        Do While rc = r4success
            Call d4delete(f23)
            rc = d4skip(f23, 1)
        Loop

        d4pack(f23)
        d4unlock(f23)
    End Sub

    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub
End Class