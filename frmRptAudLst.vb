Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Friend Class frmRptAudLst
    Dim Pdlg As New PrintDialog
    Dim P As New Printer
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)

    Dim CatCode As String
    Dim Wyear As String
    Dim Wperiod As String
    Dim Wperiod1 As String
    Dim H As Short

    Dim Ystr As String
    Dim J2str As String
    Dim Astr As String
    Dim A1str As String
    Dim A2str As String
    Dim A4str As String
    Dim Dstr As String
    Dim J3str As String
    Dim Kstr As String
    Dim Kstr1 As String

    Dim Pcnt As Short
    Dim L0 As Short
    Dim T(16) As Double
    Dim T1(4) As Double
    Dim T2(4) As Double
    Dim B(11, 29) As Double
    Dim C(29) As Short

    Private Sub cboMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboTrty.Items.Count > 1 Then
            cboTrty.SelectedIndex = 1
        Else
            cboTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If ByPassTxt Then Exit Sub

        If Not ByPassTxt Then txtMgaNmbr.Text = Mid(Trim(cboMga.Text), 1, 3)
        txtTrtyNmbr.Text = ""
        M = Mid(Trim(cboMga.Text), 1, 3)
        M1 = cboMga.SelectedIndex
        txtMgaNmbr.Text = M
        cboMga.SelectedIndex = M1
        txtTrtyNmbr.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cboTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtTrtyNmbr.Text = Mid(Trim(cboTrty.Text), 1, 2)
        TrtyKey = Mid(Trim(cboMga.Text), 1, 3) & Mid(Trim(cboTrty.Text), 1, 2)
        RdTrtyPrmRec()
        txtPeriod.Focus()
    End Sub

    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cmdPrt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdPrt.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub
        If Trim(txtPeriod.Text) = "" Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyPrmRec()
        GetTrtyPrmVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()
        GetTrtyMstVar()

        PrtAudlst()
        prtobj.EndDoc()
        prtobj.Orientation = 1
        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtPeriod.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cmdPrt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdPrt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub frmRptAudLst_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenRptDir()
        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "006"
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        cboTrty.SelectedIndex = 1
        ByPassCbo = False
    End Sub

    Private Sub frmRptAudLst_FormClosing(ByVal eventSender As Object, ByVal eventArgs As FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As CloseReason = eventArgs.CloseReason
        eventArgs.Cancel = Cancel
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub txtMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Enter
        Tobj = txtMgaNmbr
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
        Dim X As Integer

        If Tobj.Text = "000" Then
            Me.Close()
            Exit Sub
        End If

        M = "   "
        M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 1 To cboMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If

    End Sub

    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Dim X As Integer
        Tobj = txtMgaNmbr
        s = "   "
        s = RSet(Tobj.Text, Len(s))
        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()

        If s = "000" Then Tobj.Text = ""
        If Fstat <> 0 Then
            If Tobj.Text <> "" Then MsgBox("MGA Master Record Does Not Exist.")
        End If
    End Sub

    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Dim X As Integer
        Tobj = txtTrtyNmbr

        If Len(txtTrtyNmbr.Text) > 0 Then
            For X = 1 To cboMga.Items.Count
                If MgaArray(X) = Trim(txtMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboMga.SelectedIndex = 0
        End If

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
        Dim X As Integer

        If Tobj.Text = "00" Then
            Me.Close()
            Exit Sub
        End If

        M = "  "
        M = RSet(Tobj.Text, Len(M))

        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If M = "00" Then M = ""
        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 0 To cboTrty.Items.Count
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboTrty.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboTrty.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Leave
        Dim X As Integer
        Tobj = txtTrtyNmbr

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        If S1 = "00" Then
            Tobj.Text = ""
        End If

    End Sub

    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Dim X As Integer
        Tobj = txtPeriod

        If Len(txtMgaNmbr.Text) > 0 Then
            For X = 0 To cboTrty.Items.Count
                If TrtyArray(X) = Trim(txtTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboTrty.SelectedIndex = X
                    ByPassCbo = False
                    If Trim(txtPeriod.Text) = "" Then txtPeriod.Text = CurrPeriod
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboTrty.SelectedIndex = 0
            ByPassCbo = False
        End If
    End Sub

    Private Sub txtPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyNmbr.Focus()
            Case Keys.Down
                cmdPrt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdPrt.Focus()

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

        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
    End Sub

    Private Sub LoadCboMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboMga.Items.Clear()
        cboMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
            X = X + 1
            MgaArray(X) = Trim(f4str(Mp.MgaNmbr))
            rc = d4skip(f1, 1)
        Loop

        rc = d4bottom(f1)
        rc = d4unlock(f1)
    End Sub

    Private Sub LoadCboTrty()
        Dim X1 As Short
        X = 0
        ReDim TrtyArray(d4recCount(f4) + 1)
        rc = d4top(f4)

        Call d4tagSelect(f4, d4tag(f4, "K1"))
        rc = d4seek(f4, TrtyKey)

        cboTrty.Items.Clear()
        cboTrty.Items.Add("Treaty Inactive or Not Setup")
        For X1 = 0 To d4recCount(f4)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
                Exit For
            End If
            If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec
            X = X + 1
            TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
            cboTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmDesc)))
nextrec:
            rc = d4skip(f4, 1)
        Next X1

        rc = d4bottom(f4)
        rc = d4unlock(f4)
    End Sub

    Public Sub PrtAudlst()

        Dim C1str As String
        Dim C2str As String
        Dim D As Short
        Dim D1 As Short
        Dim X As Short
        Dim E(10) As Short
        Dim C1(2) As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim t4(16, 6) As Double
        Dim n As Double
        Dim A2 As Double
        Dim A3 As Double
        Dim A4 As Double
        Dim T3(3) As Double
        Dim N1 As Short
        Dim N2 As Short

        Pcnt = 0 : L0 = 0

        For X = 0 To 16 : T(X) = 0 : Next X

        For X = 0 To 4
            T1(X) = 0 : T2(X) = 0
        Next X

        For X = 0 To 11
            For n = 0 To 29
                B(X, n) = 0
            Next n
        Next X


        Ystr = Format(Parry(1), "####")

        H = 0
        CovArry(1) = f4int(TMp.PPBI)
        CovArry(2) = f4int(TMp.PPPD)
        CovArry(3) = f4int(TMp.PPMED)
        CovArry(4) = f4int(TMp.PPUMBI)
        CovArry(5) = f4int(TMp.PPUMPD)
        CovArry(6) = f4int(TMp.PPPIP)
        CovArry(7) = f4int(TMp.PPCOMP)
        CovArry(8) = f4int(TMp.PPCOLL)
        CovArry(9) = f4int(TMp.PPRENT)
        CovArry(10) = f4int(TMp.PPTOW)
        CovArry(11) = f4int(TMp.CMBI)
        CovArry(12) = f4int(TMp.CMPD)
        CovArry(13) = f4int(TMp.CMMED)
        CovArry(14) = f4int(TMp.CMUMBI)
        CovArry(15) = f4int(TMp.CMUMPD)
        CovArry(16) = f4int(TMp.CMPIP)
        CovArry(17) = f4int(TMp.CMCOMP)
        CovArry(18) = f4int(TMp.CMCOLL)
        CovArry(19) = f4int(TMp.CMRENT)
        CovArry(20) = f4int(TMp.CMTOW)
        CovArry(21) = f4int(TMp.IM)
        CovArry(22) = f4int(TMp.ALLIED)
        CovArry(23) = f4int(TMp.FIRE)
        CovArry(24) = f4int(TMp.MULTIP)

        For X = 1 To 24
            C(X) = CovArry(X)
        Next X

        C1str = Trim(txPrmAgtBalNotDue)
        C2str = Trim(txPrmReiPayNotDue)

        If Not toScreen Then
            prtobj.FontName = "Courier New"
            prtobj.FontSize = 9
            prtobj.FontBold = True
            prtobj.Orientation = 2
        End If

        If toScreen Then
            prtobj.FontName = "Courier New"
            prtobj.FontSize = 7.6
            prtobj.FontBold = True
        End If

        '==================================================================================
        '=Get RPTDIR Pass 1
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        rc = d4seek(f5, RptDirKey)


        Ystr = Trim(Str(Parry(1))) 'Curr Year
        Wperiod1 = txtPeriod.Text

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))))
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            If CatCode = "13" Or CatCode = "14" Then GoTo nextrec
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            n = CDbl(CatCode)
            n = n - 1
            If n = 1 Or n = 2 Or n = 10 Or n = 11 Then
                If Wyear <> Ystr Then E(6) = 1 ' ERROR CHECK
                T(n) = A1 ' ACCUMULATE
                GoTo nextrec
            End If

            If n = 14 Or n = 15 Or n = 16 Then
                If Wyear & Wperiod < Ystr & Wperiod1 Then E(0) = 1 ' ERROR CHECK
                If Wyear <> Ystr Then E(6) = 1 ' ERROR CHECK
                T(n) = A1 ' ACCUMULATE
                GoTo nextrec
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X
nextrec:
            rc = d4skip(f5, 1)
        Loop

        '=====================================================================================
        '= Get RPTDIR Prior Periods Pass 2
        '=====================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))

        D = Val(txtPeriod.Text)
        D1 = D - 5
        Dstr = Format(D1, "00")
        If D1 < 0 Then Dstr = "01"
        If Mid(Dstr, 1, 1) = " " Then Mid(Dstr, 1, 1) = "0"
        rc = d4top(f5)
        rc = d4seek(f5, Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Dstr)

        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        Do Until rc = r4eof Or ((Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))) > RptDirKey)
            GetRptDirVar()
            A1 = MLobt
            Wperiod = Trim(f4str(RDp.RptPeriod))

            ' ACCUMULATE PRIOR PERIODS
            CatCode = Trim(f4str(RDp.RptCatCode))
            n = Val(CatCode)
            If n <> 1 And n <> 2 And n <> 3 And n <> 11 And n <> 15 And n <> 16 Then
                GoTo nextrec1
            End If
            D1 = CShort(Wperiod)
            X = D - D1
            t4(n, X) = t4(n, X) + A1
nextrec1:
            rc = d4skip(f5, 1)
        Loop

        '======================================================================================
        '= Print Audlst LOB Summary
        '======================================================================================

        Astr = Trim(txtMgaNmbr.Text)
        A1str = txMgaName
        A2str = txTrtyDesc
        A4str = Trim(txtTrtyNmbr.Text)
        J2str = Trim(txtPeriod.Text)
        A2 = f4double(TMp.TrtyFFperc)
        A3 = f4double(TMp.TrtyPremTaxPerc)
        A4 = f4double(TMp.DirCommPerc)
        RptPageHeading()

        'Premium Inforce Unearned Premium Paid Losses Salvage Paid Lae OS Loss Resv OS Lae Reserve
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(4, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(3, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(73), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(87), RSet(Format(B(7, X), "###,###,###.00"), 14),
                                   TAB(101), RSet(Format(B(8, X), "###,###,###.00"), 14),
                                   TAB(115), RSet(Format(B(9, X), "#####,###.00"), 12))
            End If
        Next X
        prtobj.Print()

        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(4), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T(3), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T(7), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(T(8), "###,###,###.00"), 14),
                           TAB(115), RSet(Format(T(9), "#####,###.00"), 12))
        prtobj.Print()

        ' Error Checks
        A2 = A2 * 100
        A3 = A3 * 100
        A4 = A4 * 100

        If T(15) + T(16) <> 0 Then
            For X = 0 To 5
                If t4(15, X) + t4(16, X) <> 0 Then
                    T3(1) = CInt((t4(11, X) / (t4(15, X) + t4(16, X))) * 10000) / 100
                    If T3(1) = A2 Then C1(1) = 1
                End If
                If t4(15, X) <> 0 Then
                    T3(3) = CInt((t4(3, X) / t4(15, X)) * 10000) / 100
                    If T3(3) = A4 Then C1(2) = 1
                End If
            Next X
        End If

        If T(0) + T(1) <> 0 Then
            For X = 0 To 5
                If t4(1, X) + t4(2, X) <> 0 Then
                    If C1(1) <> 1 Then
                        T3(1) = CInt((t4(11, X) / (t4(1, X) + t4(2, X))) * 10000) / 100
                    End If
                End If
                If C1(2) <> 1 Or t4(1, X) <> 0 Then
                    If t4(1, X) <> 0 And t4(3, X) <> 0 Then
                        T3(3) = CInt((t4(3, X) / t4(1, X)) * 10000) / 100
                    End If
                End If
            Next X
        End If

        If T(0) + T(1) + T(14) + T(15) <> 0 Then
            If T3(1) <> A2 Then E(4) = 1
            If T3(3) <> A4 Then E(5) = 1
            ' Error Check Tax / Commission
            If T(0) + T(1) <> 0 Then
                T3(2) = CInt((T(11) / (T(0) + T(1))) * 10000) / 100
                If Trim(Str(T3(2))) <> Trim(Str(A3)) Then E(3) = 1
            End If
            ' Error Check Uncollected Balance
            If C1str <> " " Or C2str <> " " Then
                If T(16) = 0 Then E(8) = 1
            End If
        End If

        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14),
                                   TAB(34), "Commission " & RSet(Format(T(2), "###,###,###.00"), 14),
                                   TAB(60), " Commission% " & RSet(Format(A4, "###,###,###.00"), 14),
                                   TAB(87), RSet(Format(T3(3), "###,###,###.00"), 14))

        prtobj.Print("Policy Count", TAB(17), RSet(Format(0, "###,###,###.00"), 14),
                                   TAB(34), "Front Fee  " & RSet(Format(T(10), "###,###,###.00"), 14),
                                   TAB(60), " Front Fee%  " & RSet(Format(A2, "###,###,###.00"), 14),
                                   TAB(87), RSet(Format(T3(1), "###,###,###.00"), 14))

        prtobj.Print(TAB(34), "Premium Tax" & RSet(Format(T(11), "###,###,###.00"), 14),
                     TAB(60), " Premium%    " & RSet(Format(A3, "###,###,###.00"), 14),
                     TAB(87), RSet(Format(T3(2), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("Collected Prem", TAB(17), RSet(Format(T(14), "###,###,###.00"), 14))
        prtobj.Print("Collected Pfee", TAB(17), RSet(Format(T(15), "###,###,###.00"), 14))
        prtobj.Print("Uncollected Bal", TAB(17), RSet(Format(T(16), "###,###,###.00"), 14))

        'Print Error Messages
        prtobj.Print()
        prtobj.Print()
        If E(0) Then prtobj.Print("***Direct Accounting Period < Treaty Inception Date")
        If E(3) Then prtobj.Print("***Premium Tax % Out of Balance")
        If E(4) Then prtobj.Print("***Front Fee % Out of Balance")
        If E(5) Then prtobj.Print("***Commission % Out of Balance")
        If E(6) Then prtobj.Print("***Direct Accounting Year <> Current Year")
        If E(8) Then prtobj.Print("***Uncollected Bal Not Entered")

        '=====================================================================================
        '= Get Accident Year Pass 3
        '=====================================================================================
        H = 1
        L0 = 45
        For n = 5 To 9
            For X = 1 To 24
                B(n, X) = 0
            Next X
        Next n
        Kstr1 = ""

        Call d4tagSelect(f5, d4tag(f5, "K4"))
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4top(f5)
        rc = d4seek(f5, RptDirKey)


        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))))

            CatCode = Trim(f4str(RDp.RptCatCode))
            If CatCode <= "05" Or CatCode >= "11" Then GoTo nextrec2
            J3str = Trim(f4str(RDp.RptPeriod))
            If J3str <> J2str Then GoTo nextrec2

            Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptYear))

            If Kstr1 = "" Then Kstr1 = Kstr
            If Kstr <> Kstr1 Then
                If Trim(Mid(Kstr1, 6, 4)) <> "" Then
                    PrtAccYr()
                Else
                    Kstr1 = Kstr
                End If
            End If

            Wyear = Trim(f4str(RDp.RptYear))
            GetRptDirVar()

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X
            n = Val(CatCode)
            n = n - 1

            ' ERROR CHECK
            If Wyear < Mid(Trim(f4str(TPp.PrmIncpDate)), 3, 4) Then E(1) = 1
            If Wyear > Ystr Then E(2) = 1
            N1 = Val(Wyear)
            N2 = Val(Ystr)
            N2 = N2 - 10
            If N1 < N2 Then E(7) = 1

            'Accumulate
            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T1(n - 5) = T1(n - 5) + A(X)
            Next X

nextrec2:
            rc = d4skip(f5, 1)
        Loop

        If Trim(Mid(Kstr1, 6, 4)) <> "" Then PrtAccYr()

        'Print TOTALS
        If L0 > 50 Then RptPageHeading()
        prtobj.Print()
        Dstr = "   Grand Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T2(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T2(1), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T2(2), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T2(3), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T2(4), "###,###,###.00"), 14))

        'PRINT EDIT ERRORS
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        If E(1) <> 0 Then prtobj.Print("***Direct Accident Year < Treaty Year")
        If E(2) <> 0 Then prtobj.Print("***Accident Year > Accounting Year")

    End Sub

    Sub RptPageHeading()

        'Heading
        Pcnt = Pcnt + 1
        If Pcnt <> 1 Then
            If Not toScreen Then prtobj.NewPage()
        End If

        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("MGA Report Audit List", TAB(29), Astr & "  " & A1str, TAB(121), "Page " & Pcnt)
        prtobj.Print(Z1str, TAB(30), A4str & "  " & Trim(A2str) & " for " & J2str & "/" & Trim(Ystr))
        prtobj.Print()

        If H = 0 Then
            prtobj.Print(TAB(24), "Written", TAB(38), "Premium", TAB(51), "Unearned",
                         TAB(69), "Loss", TAB(80), "Salvage", TAB(98), "LAE",
                         TAB(107), "O/S Loss", TAB(120), "O/S LAE")
            prtobj.Print(TAB(24), "Premium", TAB(37), "In Force", TAB(52), "Premium",
                         TAB(69), "Paid", TAB(97), "Paid", TAB(108), "Reserve",
                         TAB(120), "Reserve")
        End If

        If H = 1 Then
            prtobj.Print(TAB(27), "Loss", TAB(38), "Salvage", TAB(56), "LAE",
                         TAB(65), "O/S Loss", TAB(80), "O/S LAE")
            prtobj.Print(TAB(27), "Paid", TAB(55), "Paid", TAB(66), "Reserve",
                         TAB(80), "Reserve")
        End If

        prtobj.Print()
        L0 = 9
    End Sub

    Public Sub CovHeading(ByRef X As Short)
        Dstr = "PP "
        If X = 1 Then Dstr = "PP " & "Bodily Inj."
        If X = 2 Then Dstr = "PP " & "Property Dam."
        If X = 3 Then Dstr = "PP " & "Medical"
        If X = 4 Then Dstr = "PP " & "UM/IUM"
        If X = 5 Then Dstr = "PP " & "UMPD"
        If X = 6 Then Dstr = "PP " & "PIP"
        If X = 7 Then Dstr = "PP " & "Comprehensive"
        If X = 8 Then Dstr = "PP " & "Collision"
        If X = 9 Then Dstr = "PP " & "Rental"
        If X = 10 Then Dstr = "PP " & "Towing"
        If X = 11 Then Dstr = "CM " & "Bodily Inj."
        If X = 12 Then Dstr = "CM " & "Property Dam."
        If X = 13 Then Dstr = "CM " & "Medical"
        If X = 14 Then Dstr = "CM " & "UM/IUM"
        If X = 15 Then Dstr = "CM " & "UMPD"
        If X = 16 Then Dstr = "CM " & "PIP"
        If X = 17 Then Dstr = "CM " & "Comprehensive"
        If X = 18 Then Dstr = "CM " & "Collision"
        If X = 19 Then Dstr = "CM " & "Rental"
        If X = 20 Then Dstr = "CM " & "Towing"
        If X = 21 Then Dstr = "Inland Marine"
        If X = 22 Then Dstr = "Allied"
        If X = 23 Then Dstr = "Fire"
        If X = 24 Then Dstr = "CM Multi Peril"
    End Sub

    Public Sub PrtAccYr()
        Dim n As Short
        Dim X As Integer

        If L0 >= 42 Then RptPageHeading()

        prtobj.Print("Accident Year " & Mid(Kstr1, 6, 4))
        prtobj.Print("------------------")

        L0 = L0 + 2
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(7, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(8, X), "###,###,###.00"), 14),
                                   TAB(73), RSet(Format(B(9, X), "###,###,###.00"), 14))
                L0 = L0 + 1
            End If
        Next X

        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T1(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T1(1), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T1(2), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T1(3), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T1(4), "###,###,###.00"), 14))

        For X = 0 To 4
            T2(X) = T2(X) + T1(X)
            T1(X) = 0
        Next X

        prtobj.Print()
        prtobj.Print()
        L0 = L0 + 2

        For n = 1 To 11
            For X = 1 To 24
                B(n, X) = 0
            Next X
        Next n

        Kstr1 = Kstr
    End Sub
End Class