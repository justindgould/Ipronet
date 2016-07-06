Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmQdirtot
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

    Dim Pcnt As Short
    Dim L0 As Short
    Dim T(16) As Double
    Dim B(15, 24) As Double
    Dim B1(15, 24) As Double

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
        BeginRun = True

        'RPTDIR
        OpenRptDir()
        OpenItdDir()
        RptType = 1
        RptCmplt = False
        PrtDirTotRpt()
        If Not RptCmplt Then Exit Sub

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

    Private Sub frmQdirtot_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

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
        Dim X As Integer

        Tobj = txtMgaNmbr
        MgaOk = False
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
        Dim X As Integer

        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

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

        If S1 = "00" Then Tobj.Text = ""
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
        Dim X As Integer

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

    Public Sub PrtDirTotRpt()
        Dim X As Short
        Dim C1(2) As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double

        'Initialize
        For X = 0 To 15
            For n = 0 To 24
                B(X, n) = 0
                B1(X, n) = 0
            Next n
        Next X

        For X = 0 To 16 : T(X) = 0 : Next X
        Pcnt = 0 : H = 0 : L0 = 0

        '======================================================================================
        '= PROCESS YTD DIRECT
        '======================================================================================

        '==================================================================================
        '=Get RPTDIR All MGAS
        '==================================================================================
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

            For X = 1 To 24 : A(X) = MLobp(X) : Next X

            ' ACCUMULATE
            n = Val(CatCode) : n = n - 1

            If n < 0 Then GoTo nextrec

            If n = 1 Or n = 10 Or n = 11 Or n = 12 Or n = 13 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec
            End If

            If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then
                If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec
            End If

            If Trim(f4str(RDp.RptPeriod)) = Wperiod Then
                If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then
                    For X = 1 To 24
                        B(n, X) = B(n, X) + A(X)
                        T(n) = T(n) + A(X)
                        If n = 3 Then
                            B(4, X) = B(4, X) - A(X)
                            T(4) = T(4) - A(X)
                        End If
                    Next X
                    GoTo nextrec
                End If
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
                If n = 0 Then
                    B(4, X) = B(4, X) + A(X)
                    T(4) = T(4) + A(X)
                End If
            Next X

nextrec:
            rc = d4skip(f5, 1)
        Loop


        '==================================================================================
        '=Get Prior Unearned
        '==================================================================================
        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)

        Do Until rc = r4eof
            If Astr <> "991" And Astr <> "999" Then
                If Trim(f4str(IDp.ItdMgaNmbr)) <> Astr Then GoTo nextrec1
            End If

            If Astr <> "991" And Astr <> "999" And A4str <> "99" Then
                If Trim(f4str(IDp.ItdTrtyNmbr)) <> A4str Then GoTo nextrec1
            End If

            If Astr = "991" Then
                If Trim(f4str(IDp.ItdMgaNmbr)) = "001" Or Trim(f4str(IDp.ItdMgaNmbr)) = "015" Or Trim(f4str(IDp.ItdMgaNmbr)) = "016" Then
                    GoTo nextrec1
                End If
            End If

            If Val(Trim(f4str(IDp.ItdCatCode))) <> 4 Then GoTo nextrec1

            GetItdDirVar()
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            For X = 1 To 24
                B(4, X) = B(4, X) + A(X)
                T(4) = T(4) + A(X)
            Next X

nextrec1:
            rc = d4skip(f11, 1)
        Loop

        '======================================================================================
        '= Print YTD DIRECT
        '======================================================================================
        RptPageHeading()

        'Premium 'Earned 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        For X = 1 To 24
            CovHeading((X))
            prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(B(4, X), "####,###,###.00"), 15),
                               TAB(46), RSet(Format(B(3, X), "####,###,###.00"), 15),
                               TAB(61), RSet(Format(B(5, X), "###,###,###.00"), 14),
                               TAB(75), RSet(Format(B(6, X), "###,###,###.00"), 14),
                               TAB(89), RSet(Format(B(7, X), "##,###,###.00"), 13),
                               TAB(102), RSet(Format(B(8, X), "####,###,###.00"), 15),
                               TAB(117), RSet(Format(B(9, X), "###,###,###.00"), 14))
        Next X

        'Total Losses

        'Premium 'Earned 'Unearned 'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(4), "####,###,###.00"), 15),
                           TAB(46), RSet(Format(T(3), "####,###,###.00"), 15),
                           TAB(61), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(75), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(89), RSet(Format(T(7), "##,###,###.00"), 13),
                           TAB(102), RSet(Format(T(8), "####,###,###.00"), 15),
                           TAB(117), RSet(Format(T(9), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14),
                                   TAB(34), "Commission " & RSet(Format(T(2), "###,###,###.00"), 14))
        prtobj.Print("Policy Count", TAB(17), RSet(Format(0, "###,###,###.00"), 14),
                                     TAB(34), "Front Fee  " & RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print(TAB(34), "Premium Tax" & RSet(Format(T(11), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        If Astr = "999" Then prtobj.Print("Includes All MGAs")
        If Astr = "991" Then prtobj.Print("Excludes Direct(001), Transcomm(015), MIC(016)")
        If Astr <> "991" And Astr <> "999" Then
            prtobj.Print("Includes " & Trim(Astr) & " " & Trim(A1str) & " " & A4str & " " & A2str)
        End If

        RptCmplt = True
    End Sub

    Sub RptPageHeading()

        'Heading
        Pcnt = Pcnt + 1
        If Not BeginRun Then prtobj.NewPage()
        BeginRun = False

        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("QTR YTD Accumulation Report - Direct", TAB(45), Astr & "  " & A1str, TAB(121), "Page " & Pcnt)
        prtobj.Print(Z1str, TAB(45), A4str & "   " & Trim(A2str) & " thru " & J2str)
        prtobj.Print()

        If H = 0 Then
            prtobj.Print(TAB(24), "Written", TAB(40), "Earned", TAB(53), "Unearned",
                         TAB(71), "Loss", TAB(82), "Salvage", TAB(99), "LAE",
                         TAB(109), "O/S Loss", TAB(124), "O/S LAE")
            prtobj.Print(TAB(24), "Premium", TAB(39), "Premium", TAB(54), "Premium",
                         TAB(71), "Paid", TAB(98), "Paid", TAB(110), "Reserve",
                         TAB(124), "Reserve")
            prtobj.Print()
        End If

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
End Class