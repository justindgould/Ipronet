Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmIbnrCalc
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
    Dim Wperiod As String

    Dim J2str As String
    Dim Kstr As String
    Dim Kstr1 As String
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim Astr As String
    Dim A1str As String
    Dim A2str As String
    Dim A4str As String

    Dim L0 As Integer
    Dim L1 As Integer
    Dim T(16) As Double
    Dim T1(16) As Double
    Dim T2(16) As Double
    Dim B(16, 24) As Double
    Dim A(24) As Double
    Dim A1 As Double
    Dim n As Double
    Dim D1(10) As Double
    Dim I0 As Double
    Dim I1 As Double
    Dim I2 As Double
    Dim C1 As Short

    Private Sub cmdCont_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCont.Click
        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Wperiod = txtPeriod.Text

        'IBNR Calc
        OpenIbnrPrm()
        OpenIbnrDir()
        OpenAyItd()

        ClearIbnrDir()
        ProcessIbnrDir()

        Me.Close()
    End Sub

    Private Sub frmIbnrCalc_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Public Sub mnuOprint_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprint.Click
        If Trim(txtPeriod.Text) = "" Then
            MsgBox("Enter Period Before Printing")
            Exit Sub
        End If

        J2str = Trim(txtPeriod.Text)
        Wperiod = txtPeriod.Text
        PrtIbnr()
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
        Dim n As Integer


        'Initialize
        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X
        L0 = 0 : Kstr = ""

        '==================================================================================
        '=Get AYITD
        '==================================================================================
        Call d4tagSelect(f22, d4tag(f22, "K2"))
        rc = d4top(f22)

        Do Until rc = r4eof
            DspCount()

            If Kstr = "" Then Kstr = Trim(f4str(AIp.AyiMgaNmbr)) & Trim(f4str(AIp.AyiTrtyNmbr)) & Trim(f4str(AIp.AyiYear))

            Kstr1 = Trim(f4str(AIp.AyiMgaNmbr)) & Trim(f4str(AIp.AyiTrtyNmbr)) & Trim(f4str(AIp.AyiYear))

            If Kstr <> Kstr1 Then
                CalcIbnr()
                Kstr = Kstr1
            End If

            CatCode = Trim(f4str(AIp.AyiCatCode))
            n = CDbl(CatCode)
            If n < 6 Or n > 10 Then GoTo nextrec

            GetAyItdVar()

            A1 = MLobt
            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
            Next X

nextrec:
            rc = d4skip(f22, 1)
        Loop

        CalcIbnr()

    End Sub

    Sub CalcIbnr()
        Dim wtot As Double
        Dim n As Integer
        Dim X As Integer

        'IBNR PRM Factors
        ' Some MGAs like Safeco (057) need separate factors
        IbnrPrmKey = Wperiod & Mid(Kstr, 6, 4) & Mid(Kstr, 1, 3) & "99"
        rc = d4seek(f25, IbnrPrmKey)
        If rc <> 0 Then
            If Mid(Kstr, 1, 3) = "001" Then
                IbnrPrmKey = Wperiod & Mid(Kstr, 6, 4) & "00199"
            Else
                IbnrPrmKey = Wperiod & Mid(Kstr, 6, 4) & "99999"
            End If
            rc = d4seek(f25, IbnrPrmKey)
        End If

        If rc = 0 Then
            D1(1) = f4double(IFp.IbnrLossPBfact)
            D1(2) = f4double(IFp.IbnrLossPMfact)
            D1(3) = f4double(IFp.IbnrLossCBfact)
            D1(4) = f4double(IFp.IbnrLossCMfact)
            D1(5) = f4double(IFp.IbnrLossOTfact)
            D1(6) = f4double(IFp.IbnrLaePBfact)
            D1(7) = f4double(IFp.IbnrLaePMfact)
            D1(8) = f4double(IFp.IbnrLaeCBfact)
            D1(9) = f4double(IFp.IbnrLaeCMfact)
            D1(10) = f4double(IFp.IbnrLaeOTfact)
        Else
            D1(1) = 1
            D1(2) = 1
            D1(3) = 1
            D1(4) = 1
            D1(5) = 1
            D1(6) = 1
            D1(7) = 1
            D1(8) = 1
            D1(9) = 1
            D1(10) = 1
        End If

        'Calc IBNR
        For X = 1 To 24
            I0 = 0
            I1 = B(6, X) + B(9, X)
            I2 = B(8, X) + B(10, X)
            If I1 <> 0 Or I2 <> 0 Then
                If X < 7 Then I0 = D1(1)
                If X > 6 And X < 11 Then I0 = D1(2)
                If X > 10 And X < 17 Then I0 = D1(3)
                If X > 16 And X < 21 Then I0 = D1(4)
                If X > 20 Then I0 = D1(5)
                If I1 <> 0 And I0 <> 1 Then
                    wtot = I1 / I0
                    B(13, X) = Math.Round(wtot - I1, 2)
                End If
                If X < 7 Then I0 = D1(6)
                If X > 6 And X < 11 Then I0 = D1(7)
                If X > 10 And X < 17 Then I0 = D1(8)
                If X > 16 And X < 21 Then I0 = D1(9)
                If X > 20 Then I0 = D1(10)
                If I2 <> 0 And I0 <> 1 Then
                    wtot = I2 / I0
                    B(14, X) = Math.Round(wtot - I2, 2)
                End If
                T(13) = T(13) + B(13, X)
                T(14) = T(14) + B(14, X)
            End If
        Next X

        'IBNR Losses
        If T(13) <> 0 Then
            C1 = 13
            WriteIbnrDirRec()
        End If

        'IBNR Lae
        If T(14) <> 0 Then
            C1 = 14
            WriteIbnrDirRec()
        End If

        'Initialize
        For X = 0 To 16
            T(X) = 0
            For n = 0 To 24 : B(X, n) = 0 : Next n
        Next X
    End Sub

    Sub WriteIbnrDirRec()

        If d4appendStart(f24, 0) <> r4success Then Exit Sub


        TrtyKey = Mid(Kstr, 1, 5)
        RdTrtyPrmRec()

        Call f4assign(IBp.IbdMgaNmbr, Mid(Kstr, 1, 3))
        Call f4assign(IBp.IbdTrtyNmbr, Mid(Kstr, 4, 2))
        Call f4assign(IBp.IbdPeriod, (txtPeriod.Text))
        Call f4assign(IBp.IbdCatCode, Format(C1, "##"))
        Call f4assign(IBp.IbdYear, Mid(Kstr, 6, 4))
        Call f4assignDouble(IBp.IbdTotal, T(C1))
        Call f4assignDouble(IBp.IbdPPbi, B(C1, 1))
        Call f4assignDouble(IBp.IbdPPpd, B(C1, 2))
        Call f4assignDouble(IBp.IbdPPmed, B(C1, 3))
        Call f4assignDouble(IBp.IbdPPumbi, B(C1, 4))
        Call f4assignDouble(IBp.IbdPPumpd, B(C1, 5))
        Call f4assignDouble(IBp.IbdPPpip, B(C1, 6))
        Call f4assignDouble(IBp.IbdPPcomp, B(C1, 7))
        Call f4assignDouble(IBp.IbdPPcoll, B(C1, 8))
        Call f4assignDouble(IBp.IbdPPrent, B(C1, 9))
        Call f4assignDouble(IBp.IbdPPtow, B(C1, 10))
        Call f4assignDouble(IBp.IbdCMbi, B(C1, 11))
        Call f4assignDouble(IBp.IbdCMpd, B(C1, 12))
        Call f4assignDouble(IBp.IbdCMmed, B(C1, 13))
        Call f4assignDouble(IBp.IbdCMumbi, B(C1, 14))
        Call f4assignDouble(IBp.IbdCMumpd, B(C1, 15))
        Call f4assignDouble(IBp.IbdCMpip, B(C1, 16))
        Call f4assignDouble(IBp.IbdCMcomp, B(C1, 17))
        Call f4assignDouble(IBp.IbdCMcoll, B(C1, 18))
        Call f4assignDouble(IBp.IbdCMrent, B(C1, 19))
        Call f4assignDouble(IBp.IbdCMtow, B(C1, 20))
        Call f4assignDouble(IBp.IbdOTim, B(C1, 21))
        Call f4assignDouble(IBp.IbdOTallied, B(C1, 22))
        Call f4assignDouble(IBp.IbdOTfire, B(C1, 23))
        Call f4assignDouble(IBp.IbdOTmulti, B(C1, 24))

        rc = d4append(f24)
        rc = d4unlock(f24)
    End Sub

    Sub ClearIbnrDir()
        Call d4tagSelect(f24, 0)
        rc = d4top(f24)
        d4lockFile(f24)

        Do While rc = r4success
            Call d4delete(f24)
            rc = d4skip(f24, 1)
        Loop

        d4pack(f24)
        d4unlock(f24)
    End Sub

    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub

    Sub PrtIbnr()
        Dim X As Integer

        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        'Global Initial
        Astr = "999"
        A1str = "All MGAs"
        A2str = "All Treaties ITD thru " & J2str & "/" & Format(Parry(1), "0000")
        A4str = "99"

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        OpenIbnrDir()

        Kstr = "" : L0 = 0 : L1 = 0
        If L1 = 0 Then PgeHeading()

        Call d4tagSelect(f24, d4tag(f24, "K1"))
        rc = d4top(f24)

        Do Until rc = r4eof
            DspCount()

            If Kstr = "" Then Kstr = Trim(f4str(IBp.IbdMgaNmbr))

            If Kstr <> Trim(f4str(IBp.IbdMgaNmbr)) Then
                If L1 > 50 Then PgeHeading()
                PrtIbnrLn()
                Kstr = Trim(f4str(IBp.IbdMgaNmbr))
                'Initialize
                For X = 0 To 16
                    T(X) = 0
                Next X
            End If

            GetIbnrDirVar()
            CatCode = Trim(f4str(IBp.IbdCatCode))
            n = CDbl(CatCode)
            A1 = MLobt

            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            ' ACCUMULATE
            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
            Next X
            T(n) = T(n) + A1

nextrec1:
            rc = d4skip(f24, 1)
        Loop

        PrtIbnrLn()

        prtobj.Print()

        'Total IBNR Losses 'Total IBNR LAE
        prtobj.Print(" Grand Totals", TAB(35), RSet(Format(T1(13), "####,###,###.00"), 15),
                                      TAB(50), RSet(Format(T1(14), "####,###,###.00"), 15))
        prtobj.Print()

        For X = 0 To 16
            T1(X) = 0 : T2(X) = 0
        Next X

        For X = 1 To 24
            If X < 7 Then T1(0) = T1(0) + B(13, X)
            If X > 10 And X < 17 Then T1(0) = T1(0) + B(13, X)
            If X < 7 Then T2(0) = T2(0) + B(14, X)
            If X > 10 And X < 17 Then T2(0) = T2(0) + B(14, X)

            If X > 6 And X < 11 Then T1(1) = T1(1) + B(13, X)
            If X > 16 And X < 21 Then T1(1) = T1(1) + B(13, X)
            If X > 6 And X < 11 Then T2(1) = T2(1) + B(14, X)
            If X > 16 And X < 21 Then T2(1) = T2(1) + B(14, X)

            If X = 21 Then T1(2) = T1(2) + B(13, X)
            If X = 21 Then T2(2) = T2(2) + B(14, X)

            If X = 22 Then T1(3) = T1(3) + B(13, X)
            If X = 22 Then T2(3) = T2(3) + B(14, X)

            If X = 23 Then T1(4) = T1(4) + B(13, X)
            If X = 23 Then T2(4) = T2(4) + B(14, X)

            If X = 24 Then T1(5) = T1(5) + B(13, X)
            If X = 24 Then T2(5) = T2(5) + B(14, X)
        Next X

        prtobj.Print()
        prtobj.Print(" Total Liab", TAB(35), RSet(Format(T1(0), "####,###,###.00"), 15), TAB(50), RSet(Format(T2(0), "####,###,###.00"), 15))
        prtobj.Print(" Total Phydam", TAB(35), RSet(Format(T1(1), "####,###,###.00"), 15), TAB(50), RSet(Format(T2(1), "####,###,###.00"), 15))
        prtobj.Print(" Total IM", TAB(35), RSet(Format(T1(2), "####,###,###.00"), 15), TAB(50), RSet(Format(T2(2), "####,###,###.00"), 15))
        prtobj.Print(" Total Allied", TAB(35), RSet(Format(T1(3), "####,###,###.00"), 15), TAB(50), RSet(Format(T2(3), "####,###,###.00"), 15))
        prtobj.Print(" Total Fire", TAB(35), RSet(Format(T1(4), "####,###,###.00"), 15), TAB(50), RSet(Format(T2(4), "####,###,###.00"), 15))
        prtobj.Print(" Total Multi", TAB(35), RSet(Format(T1(5), "####,###,###.00"), 15), TAB(50), RSet(Format(T2(5), "####,###,###.00"), 15))

        prtobj.EndDoc()
    End Sub

    Sub PgeHeading()
        'Heading
        If L1 <> 0 Then prtobj.NewPage()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("Ibnr Computations", TAB(29), Astr & "  " & A1str)
        prtobj.Print(Z1str, TAB(30), A4str & "  " & Trim(A2str))
        prtobj.Print()
        prtobj.Print(TAB(35), "          IBNR", TAB(50), "          IBNR")
        prtobj.Print(TAB(35), "        Losses", TAB(50), "           LAE")
        prtobj.Print()
        L1 = 10
    End Sub

    Sub PrtIbnrLn()
        MgaKey = Kstr
        RdMgaMstRec()

        'Ibnr Losses, Ibnr LAE
        prtobj.Print(Mid(f4str(Mp.MgaName), 1, 29) & " " & MgaKey, TAB(35), RSet(Format(T(13), "####,###,###.00"), 15), TAB(50), RSet(Format(T(14), "####,###,###.00"), 15))
        T1(13) = T1(13) + T(13) : T1(14) = T1(14) + T(14)
        L1 = L1 + 1
    End Sub
End Class
