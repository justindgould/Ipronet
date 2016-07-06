Option Strict Off
Option Explicit On
Friend Class frmRptSpc1
    Inherits DevExpress.XtraEditors.XtraForm

    Dim CatCode As String
    Dim Wperiod As String
    Dim Fname1 As String

    Dim J2str As String
    Dim Kstr As String
    Dim Pstr As String

    Dim L0 As Integer
    Dim T(16) As Double
    Dim B(15, 24) As Double
    Dim B1(15, 24) As Double
    Dim A(24) As Double
    Dim A1 As Double
    Dim A2 As Double
    Dim n As Double
    Dim T3(16) As Double
    Dim t6 As Double

    Private Sub cmdCont_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCont.Click
        'Global Initial
        If Trim(txtPeriod.Text) = "" Then Exit Sub

        J2str = Trim(txtPeriod.Text)
        Wperiod = txtPeriod.Text

        'RPTDIR
        OpenRptDir()
        OpenItdDir()
        RptType = 1
        RptCmplt = False
        PcommData()

        Me.Close()
    End Sub

    Private Sub frmRptSpc1_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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

    Public Sub PcommData()
        Dim X As Short
        Dim n As Integer

        Fname1 = My.Application.Info.DirectoryPath & "\06COMMFILE.TXT"
        FileOpen(1, Fname1, OpenMode.Output)

        'Initialize
        For X = 0 To 15
            T3(X) = 0
            For n = 0 To 24
                B(X, n) = 0
                B1(X, n) = 0
            Next n
        Next X

        For X = 0 To 16 : T(X) = 0 : Next X

        '==================================================================================
        '=Get RPTDIR YTD
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof
            DspCount()

            If Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) = "" Then GoTo nextrec

            If Kstr = "" Then Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))

            If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) Then
                GetItd()
                WriteRec()
                Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    T3(X) = 0
                    MLobp(X) = 0
                Next X

                For X = 0 To 15
                    For n = 0 To 24
                        B(X, n) = 0
                        B1(X, n) = 0
                    Next n
                Next X
            End If

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
            End If

            If Trim(f4str(RDp.RptPeriod)) > Wperiod Then GoTo nextrec

            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt
            n = CDbl(CatCode)
            n = n - 1

            If n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then GoTo nextrec

            For X = 11 To 16
                A(X) = MLobp(X)
            Next X

            'Earned and Reserves
            If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then
                If Trim(f4str(RDp.RptPeriod)) = Wperiod Then
                    For X = 11 To 16
                        B(n, X) = B(n, X) + A(X)
                    Next X
                    T3(n) = T3(n) + A1
                    GoTo nextrec
                Else
                    GoTo nextrec
                End If
            End If

            For X = 11 To 16
                B(n, X) = B(n, X) + A(X)
            Next X
            T3(n) = T3(n) + A1

nextrec:
            rc = d4skip(f5, 1)
        Loop

        GetItd()
        WriteRec()

        FinalItdCheck()

        RptCmplt = True
        FileClose(1)
    End Sub

    Sub GetItd()
        Dim X As Integer

        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)
        ItdDirKey = Kstr
        rc = d4seek(f11, ItdDirKey)

        Do Until ItdDirKey <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)))

            If ItdDirKey <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))) Then
                GoTo nextrec1
            End If

            GetItdDirVar()
            CatCode = Trim(f4str(IDp.ItdCatCode))
            A1 = MLobt

            t6 = 0
            For X = 11 To 16
                A(X) = MLobp(X)
                t6 = t6 + MLobp(X)
            Next X
            If t6 = 0 Then GoTo nextrec1

            ' ACCUMULATE
            n = CDbl(CatCode) : n = n - 1
            If n <> 3 And n <> 8 And n <> 9 And n <> 12 And n <> 13 Then GoTo nextrec1

            For X = 11 To 16
                B1(n, X) = B1(n, X) + A(X)
            Next X

nextrec1:
            rc = d4skip(f11, 1)
        Loop

    End Sub

    Sub FinalItdCheck()
        Dim X As Integer
        Dim n As Integer


        Kstr = "" : L0 = 0
        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)

        Do Until rc = r4eof
            DspCount()

            If Kstr = "" Then Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))

            If Kstr <> Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) Then
                'Bypass if current year activity
                rc = d4top(f5)
                rc = d4seek(f5, Kstr)
                If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) Then
                    If A2 <> 0 Then
                        WriteRec()
                    End If
                End If

                Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))

                'Initialize
                For X = 0 To 16
                    T(X) = 0
                    T3(X) = 0
                    MLobp(X) = 0
                Next X

                For X = 0 To 15
                    For n = 0 To 24
                        B(X, n) = 0
                        B1(X, n) = 0
                    Next n
                Next X

                A2 = 0
            End If

            GetItdDirVar()
            CatCode = Trim(f4str(IDp.ItdCatCode))
            A1 = MLobt

            t6 = 0
            For X = 11 To 16
                A(X) = MLobp(X)
                t6 = t6 + MLobp(X)
            Next X
            If t6 = 0 Then GoTo nextrec1

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1
            If n <> 8 Then GoTo nextrec1

            For X = 11 To 16
                B1(n, X) = B1(n, X) + A(X)
                A2 = A2 + A(X)
            Next X

nextrec1:
            rc = d4skip(f11, 1)
        Loop

    End Sub

    Sub WriteRec()
        Dim X As Integer
        Dim n As Integer

        Dim prte As Double

        Dim f1 As String
        Dim f2 As String
        Dim f3 As String
        Dim f4 As String
        Dim f5 As String
        Dim f6 As String
        Dim f7 As String
        Dim f8 As String
        Dim f9 As String
        Dim f10 As String
        Dim f11 As String
        Dim f12 As String
        Dim f13 As String
        Dim f14 As String

        '======================================================================================
        '= Calc YTD
        '======================================================================================
        For X = 11 To 16
            T(0) = T(0) + B(0, X) 'Premium
            T(3) = T(3) + (B(0, X) + B1(3, X) - B(3, X)) 'Earned
            T(5) = T(5) + (B(5, X) - B(6, X)) 'Total Losses Paid
            T(6) = T(6) + B1(8, X) 'O/S Loss Reserves End Of Last Year
            T(7) = T(7) + B(8, X) 'O/S Loss Reserves Current Year
        Next X
        If (T(0) + T(3) + T(5) + T(6) + T(7)) = 0 Then Exit Sub

        prte = 0 : If T3(0) <> 0 Then prte = T(0) / T3(0) 'Calc Pfee Alloc Factor
        T(1) = T(1) + Int(T3(1) * prte) 'Allocated Earned Policy Fee

        T(2) = T(0) + T(1) 'Total Written + Policy
        T(4) = T(1) + T(3) 'Total Earned Includes Policy Fee
        T(8) = T(7) - T(6) 'YTD Loss Reserves
        T(9) = T(5) + T(8) 'YTD Incurred
        T(10) = 100 - (f4double(TMp.TrtyCedPerc) * 100) 'Retained Commission

        'Write Record
        f1 = Mid(Kstr, 1, 3)
        f2 = Mid(Kstr, 4, 2)
        TrtyKey = Kstr
        RdTrtyMstRec()
        f3 = f4str(TMp.TrtyDesc)

        Pstr = "               "
        Pstr = RSet(Format(T(0), "####,###,###.00"), Len(Pstr))
        f4 = Pstr
        Pstr = RSet(Format(T(1), "####,###,###.00"), Len(Pstr))
        f5 = Pstr
        Pstr = RSet(Format(T(2), "####,###,###.00"), Len(Pstr))
        f6 = Pstr
        Pstr = RSet(Format(T(3), "####,###,###.00"), Len(Pstr))
        f7 = Pstr
        Pstr = RSet(Format(T(4), "####,###,###.00"), Len(Pstr))
        f8 = Pstr
        Pstr = RSet(Format(T(5), "####,###,###.00"), Len(Pstr))
        f9 = Pstr
        Pstr = RSet(Format(T(6), "####,###,###.00"), Len(Pstr))
        f10 = Pstr
        Pstr = RSet(Format(T(7), "####,###,###.00"), Len(Pstr))
        f11 = Pstr
        Pstr = RSet(Format(T(8), "####,###,###.00"), Len(Pstr))
        f12 = Pstr
        Pstr = RSet(Format(T(9), "####,###,###.00"), Len(Pstr))
        f13 = Pstr
        Pstr = RSet(Format(T(10), "###.0000") & "%", 9)
        f14 = Pstr

        PrintLine(1, f1, f2, f3, f14, f4, f5, f6, f7, f8, f10, f9, f11, f12, f13)

        'Initialize
        For X = 0 To 16
            T(X) = 0
            T3(X) = 0
            MLobp(X) = 0
        Next X

        For X = 0 To 15
            For n = 0 To 24
                B(X, n) = 0
                B1(X, n) = 0
            Next n
        Next X

    End Sub

    Sub DspCount()
        L0 = L0 + 1
        txtRecCnt.Text = Format(L0, "######")
        Application.DoEvents()
    End Sub
End Class