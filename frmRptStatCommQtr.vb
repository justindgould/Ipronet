Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmRptStatCommQtr
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim MgaOk As Boolean

    Dim CatCode As String
    Dim Wperiod As String
    Dim H As Short

    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim J2str As String
    Dim Astr As String
    Dim A1str As String
    Dim A2str As String
    Dim A4str As String
    Dim Dstr As String
    Dim J3str As String

    Dim Pcnt As Short
    Dim L0 As Short
    Dim T(16) As Double
    Dim T1(16) As Double
    Dim T2(16) As Double
    Dim B(15, 24) As Double
    Dim B1(15, 24) As Double
    Dim B2(15, 24) As Double
    Dim B3(15, 24) As Double

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

        If Not MgaOk Then Exit Sub
        If Trim(txtPeriod.Text) = "" Then Exit Sub

        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyPrmRec()
        GetTrtyPrmVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()
        GetTrtyMstVar()

        'Global Initial
        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        J2str = Trim(txtPeriod.Text)
        If Val(txtPeriod.Text) - 3 = 0 Then
            J3str = J2str
        Else
            J3str = Format(Val(txtPeriod.Text - 3), "0#")
        End If

        Astr = Trim(txtMgaNmbr.Text)
        A1str = txMgaName
        If Astr = "999" Then A1str = "All MGAs"
        If Astr = "991" Then A1str = "Front Fee Program"
        A2str = txTrtyDesc
        A4str = Trim(txtTrtyNmbr.Text)
        If A4str = "99" Then A2str = "All Treaties "

        Wperiod = txtPeriod.Text

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 9
        prtobj.FontBold = True
        prtobj.Orientation = 2

        'RPTDIR
        OpenRptDir()
        PrtCommQtrRpt()

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

    Private Sub frmRptStatCommQtr_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        cboTrty.SelectedIndex = 1
        ByPassCbo = False
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
                If CDbl(M) = 991 Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = Val(CStr(cboMga.Items.Count)) - 1
                    ByPassTxt = True
                    Exit Sub
                End If
                ByPassTxt = True
                cboMga.SelectedIndex = 0
                ByPassTxt = False
            End If
        End If

    End Sub

    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Tobj = txtMgaNmbr
        MgaOk = False
        Dim X As Integer

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()

        If s = "000" Then Tobj.Text = ""

        If s = "999" Or s = "991" Then Fstat = 0

        If Fstat <> 0 Then
            If Tobj.Text <> "" Then MsgBox("MGA Master Record Does Not Exist.")
            Exit Sub
        End If

        MgaOk = True
    End Sub

    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Tobj = txtTrtyNmbr
        Dim X As Integer

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
        Tobj = txtTrtyNmbr
        Dim X As Integer

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        If S1 = "00" Then Tobj.Text = ""
    End Sub

    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Tobj = txtPeriod
        Dim X As Integer

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
        ReDim MgaArray(d4recCount(f1) + 2)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboMga.Items.Clear()
        cboMga.Items.Add("999  All MGAs")

        Do Until rc = r4eof
            cboMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
            X = X + 1
            MgaArray(X) = Trim(f4str(Mp.MgaNmbr))
            rc = d4skip(f1, 1)
        Loop

        cboMga.Items.Add("991  Front Fee Program")

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
        cboTrty.Items.Add("99 All Treaties")
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

    Public Sub PrtCommQtrRpt()
        Dim X As Short
        Dim X1 As Short
        Dim C1(2) As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double

        'Initialize
        For X = 0 To 15
            For n = 0 To 24
                B(X, n) = 0
                B1(X, n) = 0
                B2(X, n) = 0
                B3(X, n) = 0
            Next n
        Next X

        For X = 0 To 16
            T(X) = 0
            T1(X) = 0
            T2(X) = 0
        Next X

        Pcnt = 0 : H = 0 : L0 = 0

        '======================================================================================
        '= Accumulate YTD
        '======================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof

            If Astr <> "991" And Astr <> "999" Then
                If Trim(f4str(RDp.RptMgaNmbr)) <> Astr Then GoTo nextrec
            End If

            If Astr <> "991" And Astr <> "999" And A4str <> "99" Then
                If Trim(f4str(RDp.RptTrtyNmbr)) <> A4str Then GoTo nextrec
            End If

            If Astr = "991" Then
                If Trim(f4str(RDp.RptMgaNmbr)) = "001" Or Trim(f4str(RDp.RptMgaNmbr)) = "015" Or Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                    GoTo nextrec
                End If
            End If

            If Trim(f4str(RDp.RptPeriod)) > Wperiod Then GoTo nextrec

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
            End If

            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = Val(CatCode)
            n = n - 1

            If n < 0 Then GoTo nextrec

            If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then
                If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec
            End If

            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X

nextrec:
            rc = d4skip(f5, 1)
        Loop


        '======================================================================================
        '= Accumulate Prior Quarter
        '======================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof

            If Astr <> "991" And Astr <> "999" Then
                If Trim(f4str(RDp.RptMgaNmbr)) <> Astr Then GoTo nextrec1
            End If

            If Astr <> "991" And Astr <> "999" And A4str <> "99" Then
                If Trim(f4str(RDp.RptTrtyNmbr)) <> A4str Then GoTo nextrec1
            End If

            If Astr = "991" Then
                If Trim(f4str(RDp.RptMgaNmbr)) = "001" Or Trim(f4str(RDp.RptMgaNmbr)) = "015" Or Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                    GoTo nextrec1
                End If
            End If

            If CDbl(Trim(f4str(RDp.RptPeriod))) > (CDbl(Wperiod) - 3) Then GoTo nextrec1

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If CDbl(Trim(f4str(RDp.RptPeriod))) <> (CDbl(Wperiod) - 3) Then GoTo nextrec1
            End If

            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = Val(CatCode)
            n = n - 1

            If n < 0 Then GoTo nextrec1

            If CDbl(Trim(f4str(RDp.RptPeriod))) <> (CDbl(Wperiod) - 3) Then
                If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec1
            End If

            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T1(n) = T1(n) + A1
                GoTo nextrec1
            End If

            For X = 1 To 24
                B1(n, X) = B1(n, X) + A(X)
                T1(n) = T1(n) + A(X)
            Next X

nextrec1:
            rc = d4skip(f5, 1)
        Loop


        '======================================================================================
        '= Print YTD DIRECT
        '======================================================================================

        For X = 0 To 16
            T(X) = 0
            T1(X) = 0
            T2(X) = 0
        Next X

        RptPageHeading()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        For X = 11 To 21
            CovHeading((X))
            prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(B(4, X), "##,###,###.00"), 13),
                               TAB(44), RSet(Format(B(3, X), "####,###,###.00"), 15),
                               TAB(59), RSet(Format(B(5, X), "###,###,###.00"), 14),
                               TAB(73), RSet(Format(B(6, X), "###,###,###.00"), 14),
                               TAB(87), RSet(Format(B(7, X), "##,###,###.00"), 13),
                               TAB(100), RSet(Format(B(8, X), "####,###,###.00"), 15),
                               TAB(115), RSet(Format(B(9, X), "###,###,###.00"), 14))
            T(0) = T(0) + B(0, X) : T(3) = T(3) + B(3, X) : T(4) = T(4) + B(4, X) : T(5) = T(5) + B(5, X)
            T(6) = T(6) + B(6, X) : T(7) = T(7) + B(7, X) : T(8) = T(8) + B(8, X) : T(9) = T(9) + B(9, X)
        Next X

        'Print Totals
        prtobj.Print()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(4), "##,###,###.00"), 13),
                           TAB(44), RSet(Format(T(3), "####,###,###.00"), 15),
                           TAB(59), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T(7), "##,###,###.00"), 13),
                           TAB(100), RSet(Format(T(8), "####,###,###.00"), 15),
                           TAB(115), RSet(Format(T(9), "###,###,###.00"), 14))

        '======================================================================================
        '= Print Prior YTD DIRECT
        '======================================================================================
        For X = 0 To 16
            T(X) = 0
            T1(X) = 0
            T2(X) = 0
        Next X

        prtobj.Print()
        prtobj.Print()

        RptPageHeading()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        For X = 11 To 21
            CovHeading((X))
            prtobj.Print(Dstr, TAB(17), RSet(Format(B1(0, X), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(B1(4, X), "##,###,###.00"), 13),
                               TAB(44), RSet(Format(B1(3, X), "####,###,###.00"), 15),
                               TAB(59), RSet(Format(B1(5, X), "###,###,###.00"), 14),
                               TAB(73), RSet(Format(B1(6, X), "###,###,###.00"), 14),
                               TAB(87), RSet(Format(B1(7, X), "##,###,###.00"), 13),
                               TAB(100), RSet(Format(B1(8, X), "####,###,###.00"), 15),
                               TAB(115), RSet(Format(B1(9, X), "###,###,###.00"), 14))
            T1(0) = T1(0) + B1(0, X) : T1(3) = T1(3) + B1(3, X) : T1(4) = T1(4) + B1(4, X) : T1(5) = T1(5) + B1(5, X)
            T1(6) = T1(6) + B1(6, X) : T1(7) = T1(7) + B1(7, X) : T1(8) = T1(8) + B1(8, X) : T1(9) = T1(9) + B1(9, X)
        Next X

        'Print Totals
        prtobj.Print()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T1(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T1(4), "##,###,###.00"), 13),
                           TAB(44), RSet(Format(T1(3), "####,###,###.00"), 15),
                           TAB(59), RSet(Format(T1(5), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T1(6), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T1(7), "##,###,###.00"), 13),
                           TAB(100), RSet(Format(T1(8), "####,###,###.00"), 15),
                           TAB(115), RSet(Format(T1(9), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()

        If Astr = "999" Then prtobj.Print("Includes All MGAs")
        If Astr = "991" Then prtobj.Print("Excludes Direct(001), Transcomm(015), MIC(016)")
        If Astr <> "991" And Astr <> "999" Then
            prtobj.Print("Includes " & Trim(Astr) & " " & Trim(A1str) & " " & A4str & " " & A2str)
        End If

        'Calc Quarter Totals
        For X = 0 To 11
            For X1 = 11 To 21
                If X <> 3 And X <> 8 And X <> 9 Then B2(X, X1) = B(X, X1) - B1(X, X1)
                If X = 3 Or X = 8 Or X = 9 Then B2(X, X1) = B(X, X1)
                T2(X) = T2(X) + B2(X, X1)
            Next X1
        Next X

        '======================================================================================
        '= Print Current Quarter DIRECT
        '======================================================================================
        prtobj.NewPage()
        RptPageHeading()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        For X = 11 To 21
            CovHeading((X))
            prtobj.Print(Dstr, TAB(17), RSet(Format(B2(0, X), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(B2(4, X), "##,###,###.00"), 13),
                               TAB(44), RSet(Format(B2(3, X), "####,###,###.00"), 15),
                               TAB(59), RSet(Format(B2(5, X), "###,###,###.00"), 14),
                               TAB(73), RSet(Format(B2(6, X), "###,###,###.00"), 14),
                               TAB(87), RSet(Format(B2(7, X), "##,###,###.00"), 13),
                               TAB(100), RSet(Format(B2(8, X), "####,###,###.00"), 15),
                               TAB(115), RSet(Format(B2(9, X), "###,###,###.00"), 14))
        Next X

        'Print Totals
        prtobj.Print()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T2(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T2(4), "##,###,###.00"), 13),
                           TAB(44), RSet(Format(T2(3), "####,###,###.00"), 15),
                           TAB(59), RSet(Format(T2(5), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T2(6), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T2(7), "##,###,###.00"), 13),
                           TAB(100), RSet(Format(T2(8), "####,###,###.00"), 15),
                           TAB(115), RSet(Format(T2(9), "###,###,###.00"), 14))


        'Calc Quarter Summary
        For X = 0 To 11
            For X1 = 11 To 21
                If X1 < 16 Then B3(X, 0) = B3(X, 0) + B2(X, X1)
                If X1 = 16 Then B3(X, 1) = B3(X, 1) + B2(X, X1)
                If X1 > 16 And X1 < 21 Then B3(X, 2) = B3(X, 2) + B2(X, X1)
                If X1 < 21 Then B3(X, 3) = B3(X, 3) + B2(X, X1)
                If X1 = 21 Then B3(X, 4) = B3(X, 4) + B2(X, X1)
                B3(X, 5) = B3(X, 5) + B2(X, X1)
            Next X1
        Next X

        '======================================================================================
        '= Print Quarterly Summary
        '======================================================================================
        prtobj.Print()
        prtobj.Print()
        RptPageHeading()

        'Premium 'Inforce 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        For X = 0 To 5
            If X = 0 Then Dstr = "Total Liability"
            If X = 1 Then Dstr = "PIP"
            If X = 2 Then Dstr = "Total Phy Dam"
            If X = 3 Then Dstr = "Sub-Total"
            If X = 4 Then Dstr = "Inland Marine"
            If X = 5 Then Dstr = "Grand Total"
            prtobj.Print(Dstr, TAB(17), RSet(Format(B3(0, X), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(B3(4, X), "##,###,###.00"), 13),
                               TAB(44), RSet(Format(B3(3, X), "####,###,###.00"), 15),
                               TAB(59), RSet(Format(B3(5, X), "###,###,###.00"), 14),
                               TAB(73), RSet(Format(B3(6, X), "###,###,###.00"), 14),
                               TAB(87), RSet(Format(B3(7, X), "##,###,###.00"), 13),
                               TAB(100), RSet(Format(B3(8, X), "####,###,###.00"), 15),
                               TAB(115), RSet(Format(B3(9, X), "###,###,###.00"), 14))
            prtobj.Print()
        Next X

    End Sub

    Sub RptPageHeading()
        Dim H1 As String = " "
        Dim H2 As String = " "

        If J2str = "03" Then H1 = "1st Qtr "
        If J2str = "06" Then H1 = "2nd Qtr "
        If J2str = "09" Then H1 = "3rd Qtr "
        If J2str = "12" Then H1 = "4th Qtr "

        'Heading
        If H = 0 Or H = 2 Then
            Pcnt = Pcnt + 1
            prtobj.Print()
            prtobj.Print()
            prtobj.Print(C0str)
            prtobj.Print("Qrtly Commercial Report - Direct", TAB(45), Astr & "  " & A1str, TAB(121), "Page " & Pcnt)
            prtobj.Print(Z1str, TAB(45), A4str & "   " & Trim(A2str) & " thru " & J2str)
            prtobj.Print()
        End If

        If H = 0 Then H2 = "Period " & J2str & " YTD"
        If H = 1 Then H2 = "Period " & J3str & " YTD"
        If H = 2 Then H2 = H1
        If H = 3 Then H2 = H1 & "Summary"

        prtobj.Print(H2, TAB(24), "Written", TAB(37), "Premium", TAB(51), "Unearned",
                         TAB(69), "Loss", TAB(80), "Salvage", TAB(97), "LAE",
                         TAB(107), "O/S Loss", TAB(122), "O/S LAE")

        prtobj.Print(TAB(24), "Premium", TAB(36), "In Force", TAB(52), "Premium",
                     TAB(69), "Paid", TAB(96), "Paid", TAB(108), "Reserve", TAB(122), "Reserve")

        prtobj.Print()

        L0 = 9
        H = H + 1
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
End Class