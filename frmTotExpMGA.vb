Option Strict Off
Option Explicit On
Friend Class frmTotExpMga
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Wperiod As String
    Dim Fname1 As String

    Dim J2str As String
    Dim Astr As String
    Dim A4str As String
    Dim Kstr As String

    Dim T(24) As Double
    Dim T1(24) As Double

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

    Private Sub cmdBld_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdBld.Click
        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Astr = Trim(txtMgaNmbr.Text)
        A4str = Trim(txtTrtyNmbr.Text)
        Wperiod = txtPeriod.Text

        If optMtd.Checked = False And optYtd.Checked = False And optItd.Checked = False Then
            MsgBox("Select MTD, YTD or ITD")
            Exit Sub
        End If

        OpenItdDir()
        OpenRptDir()

        If optMtd.Checked = True Then BldDirMtdTot()
        If optYtd.Checked = True Then BldDirYtdTot()
        If optItd.Checked = True Then BldDirItdTot()

        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtPeriod.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cmdBld_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdBld.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub frmTotExpMga_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 0
        cboTrty.SelectedIndex = 0
        ByPassCbo = False
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub optMtd_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles optMtd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then cmdBld.Focus()
        If KeyCode = 27 Or KeyCode = 110 Then txtMgaNmbr.Focus()
    End Sub

    Private Sub optYtd_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles optYtd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then cmdBld.Focus()
        If KeyCode = 27 Or KeyCode = 110 Then txtMgaNmbr.Focus()
    End Sub

    Private Sub optTotalOnly_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles optTotalOnly.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then cmdBld.Focus()
        If KeyCode = 27 Or KeyCode = 110 Then txtMgaNmbr.Focus()
    End Sub

    'UPGRADE_ISSUE: OptionButton event optTotalOnly.DblClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub optTotalOnly_DblClick()
        If optTotalOnly.Checked = False Then
            optTotalOnly.Checked = True
        Else
            optTotalOnly.Checked = False
        End If
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
        If KeyCode = 27 Or KeyCode = 110 Then txtMgaNmbr.Focus()

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
                If M = "999" Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = 0
                    ByPassTxt = False
                    Exit Sub
                End If
                If M = "991" Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = 1
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

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s
        If s = "999" Or s = "991" Then Fstat = 0
    End Sub

    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Tobj = txtTrtyNmbr

        If Len(txtTrtyNmbr.Text) > 0 Then
            ByPassCbo = True
            cboTrty.SelectedIndex = 0
            ByPassCbo = False
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
        Tobj = txtPeriod

        If Len(txtMgaNmbr.Text) > 0 Then
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
                optMtd.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then optMtd.Focus()
        If KeyCode = 27 Or KeyCode = 110 Then txtMgaNmbr.Focus()
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

    Private Sub LoadCboMga()
        cboMga.Items.Clear()
        cboMga.Items.Add("999  All MGAs")
        cboMga.Items.Add("991  Front Fee Program")
    End Sub

    Private Sub LoadCboTrty()
        cboTrty.Items.Clear()
        cboTrty.Items.Add("99 All Treaties")
    End Sub

    Public Sub BldDirMtdTot()
        Dim X As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double

        Fname1 = My.Application.Info.DirectoryPath & "\" & Wperiod & " TOTEXPMGAT " & "MTD.TXT"

        FileOpen(1, Fname1, OpenMode.Output)

        'Initialize
        For X = 0 To 24 : T(X) = 0 : Next X
        For X = 0 To 24 : T1(X) = 0 : Next X
        Kstr = ""

        '==================================================================================
        '=Get RPTDIR All MGAS
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof

            If optTotalOnly.Checked = False Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
                End If

                If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
                End If
            End If

            GetRptDirVar()
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = Val(f4str(RDp.RptCatCode)) - 1

            If n < 0 Then GoTo nextrec

            If n = 0 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec 'Premium
            If n = 1 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec 'Policy Fee
            If n = 2 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Commission
            If n = 5 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Paid Losses
            If n = 6 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Salvage
            If n = 7 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Paid LAE
            If n = 10 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Front Fee
            If n = 11 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Premium Tax
            If n = 14 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Collected Prem
            If n = 15 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Collected Pfee
            If n = 16 Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec ' Uncollected

            If n = 12 Then GoTo nextrec 'IBNR Loss
            If n = 13 Then GoTo nextrec 'IBNR LAE

            If n = 1 Or n = 10 Or n = 11 Or n = 12 Or n = 13 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec
            End If

            If Trim(f4str(RDp.RptPeriod)) <> Wperiod And Val(Trim(f4str(RDp.RptPeriod))) <> Val(Wperiod) - 1 Then
                If n = 3 Or n = 8 Or n = 9 Then GoTo nextrec
            End If

            If Trim(f4str(RDp.RptPeriod)) = Wperiod Then
                If n = 8 Or n = 9 Then
                    For X = 1 To 24
                        T(n) = T(n) + A(X)
                    Next X
                    GoTo nextrec
                End If
            End If

            If Trim(f4str(RDp.RptPeriod)) = Wperiod Then
                If n = 3 Then
                    For X = 1 To 24
                        T(4) = T(4) - A(X)
                    Next X
                    For X = 1 To 24
                        T(n) = T(n) + A(X)
                    Next X
                    GoTo nextrec
                End If
            End If

            If Val(Trim(f4str(RDp.RptPeriod))) = Val(Wperiod) - 1 Then 'Back Out Prior Period Reserves to Calc MTD Incurred
                If n = 8 Or n = 9 Then
                    For X = 1 To 24
                        T(n) = T(n) - A(X)
                    Next X
                    GoTo nextrec
                End If
            End If

            If Val(Trim(f4str(RDp.RptPeriod))) = Val(Wperiod) - 1 Then 'Earned Calc - Back out prior unearned
                If n = 3 Then
                    For X = 1 To 24
                        T(4) = T(4) + A(X)
                    Next X
                    GoTo nextrec
                End If
            End If

            For X = 1 To 24
                T(n) = T(n) + A(X)
                If n = 0 Then T(4) = T(4) + A(X)
            Next X

nextrec:
            rc = d4skip(f5, 1)
        Loop

        WriteRec()

        'Total Rec
        PrintLine(1, " ")
        Kstr = " "
        For X = 0 To 24
            T(X) = T1(X)
        Next X
        WriteRec()

        FileClose(1)
    End Sub

    Public Sub BldDirYtdTot()
        Dim X As Integer
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double
        Dim RdItd As Short

        Fname1 = My.Application.Info.DirectoryPath & "\" & Wperiod & " TOTEXPMGAT " & "YTD.TXT"

        FileOpen(1, Fname1, OpenMode.Output)

        'Initialize
        For X = 0 To 24 : T(X) = 0 : Next X
        For X = 0 To 24 : T1(X) = 0 : Next X
        Kstr = ""
        RdItd = 0

        '==================================================================================
        '=Get RPTDIR All MGAS
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof

            'Bypass inactive MGAs
            If Trim(f4str(RDp.RptMgaNmbr)) = "002" Or Trim(f4str(RDp.RptMgaNmbr)) = "004" Or Trim(f4str(RDp.RptMgaNmbr)) = "005" Or Trim(f4str(RDp.RptMgaNmbr)) = "006" Or Trim(f4str(RDp.RptMgaNmbr)) = "007" Or Trim(f4str(RDp.RptMgaNmbr)) = "008" Or Trim(f4str(RDp.RptMgaNmbr)) = "009" Or Trim(f4str(RDp.RptMgaNmbr)) = "010" Or Trim(f4str(RDp.RptMgaNmbr)) = "011" Or Trim(f4str(RDp.RptMgaNmbr)) = "012" Or Trim(f4str(RDp.RptMgaNmbr)) = "014" Or Trim(f4str(RDp.RptMgaNmbr)) = "015" Or Trim(f4str(RDp.RptMgaNmbr)) = "016" Or Trim(f4str(RDp.RptMgaNmbr)) = "036" Or Trim(f4str(RDp.RptMgaNmbr)) = "019" Or Trim(f4str(RDp.RptMgaNmbr)) = "020" Or Trim(f4str(RDp.RptMgaNmbr)) = "021" Or Trim(f4str(RDp.RptMgaNmbr)) = "022" Or Trim(f4str(RDp.RptMgaNmbr)) = "023" Or Trim(f4str(RDp.RptMgaNmbr)) = "025" Or Trim(f4str(RDp.RptMgaNmbr)) = "024" Or Trim(f4str(RDp.RptMgaNmbr)) = "036" Or Trim(f4str(RDp.RptMgaNmbr)) = "026" Or Trim(f4str(RDp.RptMgaNmbr)) = "027" Or Trim(f4str(RDp.RptMgaNmbr)) = "028" Or Trim(f4str(RDp.RptMgaNmbr)) = "029" Or Trim(f4str(RDp.RptMgaNmbr)) = "031" Or Trim(f4str(RDp.RptMgaNmbr)) = "032" Or Trim(f4str(RDp.RptMgaNmbr)) = "033" Or Trim(f4str(RDp.RptMgaNmbr)) = "034" Or Trim(f4str(RDp.RptMgaNmbr)) = "038" Or Trim(f4str(RDp.RptMgaNmbr)) = "041" Or Trim(f4str(RDp.RptMgaNmbr)) = "042" Or Trim(f4str(RDp.RptMgaNmbr)) = "052" Or Trim(f4str(RDp.RptMgaNmbr)) = "043" Or Trim(f4str(RDp.RptMgaNmbr)) = "045" Or Trim(f4str(RDp.RptMgaNmbr)) = "047" Or Trim(f4str(RDp.RptMgaNmbr)) = "048" Or Trim(f4str(RDp.RptMgaNmbr)) = "049" Or Trim(f4str(RDp.RptMgaNmbr)) = "050" Or Trim(f4str(RDp.RptMgaNmbr)) = "053" Or Trim(f4str(RDp.RptMgaNmbr)) = "058" Or Trim(f4str(RDp.RptMgaNmbr)) = "059" Or Trim(f4str(RDp.RptMgaNmbr)) = "062" Or Trim(f4str(RDp.RptMgaNmbr)) = "063" Or Trim(f4str(RDp.RptMgaNmbr)) = "001" Then
                GoTo nextrec
            End If

            If optTotalOnly.Checked = False Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
                End If

                If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
                    RdItd = 0
                End If
            End If

            If optTotalOnly.Checked = True Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(RDp.RptMgaNmbr))
                End If

                If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(RDp.RptMgaNmbr))
                    RdItd = 0
                End If
            End If

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
            End If

            If RdItd = 0 Then
                Call d4tagSelect(f11, d4tag(f11, "K1"))
                rc = d4top(f11)
                ItdDirKey = Kstr
                rc = d4seek(f11, ItdDirKey)

                Do Until rc = r4eof
                    If optTotalOnly.Checked = True Then
                        If Trim(f4str(IDp.ItdMgaNmbr)) <> Kstr Then GoTo nxtitdrec
                    Else
                        If Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) <> Kstr Then GoTo nxtitdrec
                    End If

                    n = Val(Trim(f4str(IDp.ItdCatCode))) - 1
                    If n <> 3 And n <> 8 And n <> 9 Then GoTo nxtitdrec

                    GetItdDirVar()
                    A1 = MLobt

                    For X = 1 To 24
                        A(X) = MLobp(X)
                    Next X

                    ' ACCUMULATE
                    If n = 3 Then
                        For X = 1 To 24
                            T(4) = T(4) + A(X)
                        Next X
                    Else
                        For X = 1 To 24
                            T(n) = T(n) - A(X)
                        Next X
                    End If
nxtitdrec:
                    rc = d4skip(f11, 1)
                Loop
                RdItd = 1
            End If

            GetRptDirVar()
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = Val(f4str(RDp.RptCatCode)) - 1
            If n < 0 Then GoTo nextrec

            If n = 12 Then GoTo nextrec 'IBNR Loss
            If n = 13 Then GoTo nextrec 'IBNR LAE
            If n = 14 Then GoTo nextrec 'Collected Prem
            If n = 15 Then GoTo nextrec 'Collected Pfee

            If n = 3 Or n = 8 Or n = 9 Then
                If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
            End If

            If n = 1 Or n = 10 Or n = 11 Or n = 12 Or n = 13 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec
            End If

            If n = 3 Or n = 8 Or n = 9 Then
                For X = 1 To 24
                    T(n) = T(n) + A(X)
                Next X
                If n = 3 Then
                    For X = 1 To 24
                        T(4) = T(4) - A(X)
                    Next X
                End If
                GoTo nextrec
            End If

            For X = 1 To 24
                T(n) = T(n) + A(X)
                If n = 0 Then T(4) = T(4) + A(X)
            Next X

nextrec:
            rc = d4skip(f5, 1)
        Loop

        WriteRec()


        'Total Rec
        PrintLine(1, " ")
        Kstr = " "
        For X = 0 To 24
            T(X) = T1(X)
        Next X
        WriteRec()


        FileClose(1)
    End Sub

    Public Sub BldDirItdTot()
        Dim X As Integer
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double
        Dim RdRptDir As Short

        Fname1 = My.Application.Info.DirectoryPath & "\" & Wperiod & " TOTEXPMGAT " & "ITD.TXT"

        FileOpen(1, Fname1, OpenMode.Output)

        'Pass 1
        'Initialize
        For X = 0 To 24 : T(X) = 0 : Next X
        For X = 0 To 24 : T1(X) = 0 : Next X
        Kstr = ""
        RdRptDir = 0

        '==================================================================================
        '=Get ITDDIR All MGAS
        '==================================================================================
        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)

        Do Until rc = r4eof

            'Bypass inactive MGAs
            If Trim(f4str(IDp.ItdMgaNmbr)) = "002" Or Trim(f4str(IDp.ItdMgaNmbr)) = "004" Or Trim(f4str(IDp.ItdMgaNmbr)) = "005" Or Trim(f4str(IDp.ItdMgaNmbr)) = "006" Or Trim(f4str(IDp.ItdMgaNmbr)) = "007" Or Trim(f4str(IDp.ItdMgaNmbr)) = "008" Or Trim(f4str(IDp.ItdMgaNmbr)) = "009" Or Trim(f4str(IDp.ItdMgaNmbr)) = "010" Or Trim(f4str(IDp.ItdMgaNmbr)) = "011" Or Trim(f4str(IDp.ItdMgaNmbr)) = "012" Or Trim(f4str(IDp.ItdMgaNmbr)) = "014" Or Trim(f4str(IDp.ItdMgaNmbr)) = "015" Or Trim(f4str(IDp.ItdMgaNmbr)) = "016" Or Trim(f4str(IDp.ItdMgaNmbr)) = "036" Or Trim(f4str(IDp.ItdMgaNmbr)) = "019" Or Trim(f4str(IDp.ItdMgaNmbr)) = "020" Or Trim(f4str(IDp.ItdMgaNmbr)) = "021" Or Trim(f4str(IDp.ItdMgaNmbr)) = "022" Or Trim(f4str(IDp.ItdMgaNmbr)) = "023" Or Trim(f4str(IDp.ItdMgaNmbr)) = "024" Or Trim(f4str(IDp.ItdMgaNmbr)) = "025" Or Trim(f4str(IDp.ItdMgaNmbr)) = "036" Or Trim(f4str(IDp.ItdMgaNmbr)) = "026" Or Trim(f4str(IDp.ItdMgaNmbr)) = "027" Or Trim(f4str(IDp.ItdMgaNmbr)) = "028" Or Trim(f4str(IDp.ItdMgaNmbr)) = "029" Or Trim(f4str(IDp.ItdMgaNmbr)) = "031" Or Trim(f4str(IDp.ItdMgaNmbr)) = "032" Or Trim(f4str(IDp.ItdMgaNmbr)) = "033" Or Trim(f4str(IDp.ItdMgaNmbr)) = "034" Or Trim(f4str(IDp.ItdMgaNmbr)) = "038" Or Trim(f4str(IDp.ItdMgaNmbr)) = "041" Or Trim(f4str(IDp.ItdMgaNmbr)) = "042" Or Trim(f4str(IDp.ItdMgaNmbr)) = "052" Or Trim(f4str(IDp.ItdMgaNmbr)) = "043" Or Trim(f4str(IDp.ItdMgaNmbr)) = "045" Or Trim(f4str(IDp.ItdMgaNmbr)) = "047" Or Trim(f4str(IDp.ItdMgaNmbr)) = "048" Or Trim(f4str(IDp.ItdMgaNmbr)) = "049" Or Trim(f4str(IDp.ItdMgaNmbr)) = "050" Or Trim(f4str(IDp.ItdMgaNmbr)) = "053" Or Trim(f4str(IDp.ItdMgaNmbr)) = "058" Or Trim(f4str(IDp.ItdMgaNmbr)) = "059" Or Trim(f4str(IDp.ItdMgaNmbr)) = "062" Or Trim(f4str(IDp.ItdMgaNmbr)) = "063" Or Trim(f4str(IDp.ItdMgaNmbr)) = "001" Then
                GoTo nextrec
            End If

            If optTotalOnly.Checked = False Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))
                End If

                If Kstr <> Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))
                    RdRptDir = 0
                End If
            End If

            If optTotalOnly.Checked = True Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(IDp.ItdMgaNmbr))
                End If

                If Kstr <> Trim(f4str(IDp.ItdMgaNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(IDp.ItdMgaNmbr))
                    RdRptDir = 0
                End If
            End If

            If RdRptDir = 0 Then
                Call d4tagSelect(f5, d4tag(f5, "K1"))
                rc = d4top(f5)
                RptDirKey = Kstr
                rc = d4seek(f5, RptDirKey)

                Do Until rc = r4eof
                    If optTotalOnly.Checked = True Then
                        If Trim(f4str(RDp.RptMgaNmbr)) <> Kstr Then GoTo nxtrptrec
                    Else
                        If Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) <> Kstr Then GoTo nxtrptrec
                    End If

                    If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                        If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nxtrptrec
                    End If

                    n = Val(Trim(f4str(RDp.RptCatCode))) - 1

                    If n = 12 Then GoTo nxtrptrec
                    If n = 13 Then GoTo nxtrptrec
                    If n = 14 Then GoTo nxtrptrec
                    If n = 15 Then GoTo nxtrptrec
                    If n = 16 Then GoTo nxtrptrec

                    GetRptDirVar()
                    A1 = MLobt

                    For X = 1 To 24
                        A(X) = MLobp(X)
                    Next X

                    ' ACCUMULATE
                    If n = 3 Or n = 8 Or n = 9 Then
                        If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nxtrptrec
                    End If

                    If n = 1 Or n = 2 Or n = 10 Or n = 11 Or n = 12 Or n = 13 Or n = 14 Or n = 15 Or n = 16 Then
                        T(n) = T(n) + A1
                        GoTo nxtrptrec
                    End If

                    If n = 3 Or n = 8 Or n = 9 Then
                        For X = 1 To 24
                            T(n) = T(n) + A(X)
                        Next X
                        If n = 3 Then
                            For X = 1 To 24
                                T(4) = T(4) - A(X)
                            Next X
                        End If
                        GoTo nxtrptrec
                    End If

                    For X = 1 To 24
                        T(n) = T(n) + A(X)
                        If n = 0 Then T(4) = T(4) + A(X)
                    Next X
nxtrptrec:
                    rc = d4skip(f5, 1)
                Loop
                RdRptDir = 1
            End If

            GetItdDirVar()
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = Val(f4str(IDp.ItdCatCode)) - 1

            If n < 0 Then GoTo nextrec

            If n = 3 Then GoTo nextrec
            If n = 8 Then GoTo nextrec
            If n = 9 Then GoTo nextrec
            If n = 12 Then GoTo nextrec
            If n = 13 Then GoTo nextrec
            If n = 14 Then GoTo nextrec
            If n = 15 Then GoTo nextrec
            If n = 16 Then GoTo nextrec

            If n = 1 Or n = 2 Or n = 10 Or n = 11 Or n = 12 Or n = 13 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec
            End If

            If n = 3 Then
                For X = 1 To 24
                    T(4) = T(4) + A(X)
                Next X
                GoTo nextrec
            End If

            For X = 1 To 24
                T(n) = T(n) + A(X)
                If n = 0 Then T(4) = T(4) + A(X)
            Next X

nextrec:
            rc = d4skip(f11, 1)
        Loop

        WriteRec()

        'Pass 2 Get New MGA
        For X = 0 To 24 : T(X) = 0 : Next X
        Kstr = ""

        '==================================================================================
        '=Get RPTDIR All MGAS
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof

            If optTotalOnly.Checked = False Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
                End If

                If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))
                End If
            End If

            If optTotalOnly.Checked = True Then
                If Kstr = "" Then
                    Kstr = Trim(f4str(RDp.RptMgaNmbr))
                End If

                If Kstr <> Trim(f4str(RDp.RptMgaNmbr)) Then
                    WriteRec()
                    Kstr = Trim(f4str(RDp.RptMgaNmbr))
                End If
            End If

            Call d4tagSelect(f11, d4tag(f11, "K1"))
            rc = d4top(f11)
            ItdDirKey = Kstr
            rc = d4seek(f11, ItdDirKey)

            If Mid(Kstr, 1, 5) = Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr)) Then
                GoTo nextrec1
            End If

            GetRptDirVar()
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = Val(f4str(RDp.RptCatCode)) - 1
            If n < 0 Then GoTo nextrec1

            If n = 12 Then GoTo nextrec1 'IBNR Loss
            If n = 13 Then GoTo nextrec1 'IBNR LAE
            If n = 14 Then GoTo nextrec1 'Collected Prem
            If n = 15 Then GoTo nextrec1 'Collected Pfee

            If n = 3 Or n = 8 Or n = 9 Then
                If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec1
            End If

            If n = 1 Or n = 2 Or n = 10 Or n = 11 Or n = 12 Or n = 13 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec1
            End If

            If n = 3 Or n = 8 Or n = 9 Then
                For X = 1 To 24
                    T(n) = T(n) + A(X)
                Next X
                If n = 3 Then
                    For X = 1 To 24
                        T(4) = T(4) - A(X)
                    Next X
                End If
                GoTo nextrec1
            End If

            For X = 1 To 24
                T(n) = T(n) + A(X)
                If n = 0 Then T(4) = T(4) + A(X)
            Next X

nextrec1:
            rc = d4skip(f5, 1)
        Loop

        WriteRec()

        'Total Rec
        PrintLine(1, " ")
        Kstr = " "
        For X = 0 To 24
            T(X) = T1(X)
        Next X
        WriteRec()

        FileClose(1)
    End Sub

    Sub WriteRec()
        Dim Rtot As Double
        Dim X As Integer


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
        Dim f15 As String

        'Write Record

        'Bypass zero record
        Rtot = 0
        For X = 0 To 11
            Rtot = Rtot + T(X)
        Next X

        If Rtot = 0 Then Exit Sub

        f1 = Mid(Kstr, 1, 3)
        f2 = Mid(Kstr, 4, 2)
        f3 = " "

        If optTotalOnly.Checked = False Then
            TrtyKey = Kstr
            RdTrtyMstRec()
            f3 = f4str(TMp.TrtyDesc)
        End If

        If optTotalOnly.Checked = True Then
            MgaKey = Kstr
            RdMgaMstRec()
            f3 = f4str(Mp.MgaName)
        End If

        f4 = RSet(Format(T(0), "####,###,###.00"), 15)
        f5 = RSet(Format(T(1), "####,###,###.00"), 15)
        f6 = RSet(Format(T(2), "####,###,###.00"), 15)
        f7 = RSet(Format(T(3), "####,###,###.00"), 15)
        f8 = RSet(Format(T(4), "####,###,###.00"), 15)
        f9 = RSet(Format(T(5), "####,###,###.00"), 15)
        f10 = RSet(Format(T(6), "####,###,###.00"), 15)
        f11 = RSet(Format(T(7), "####,###,###.00"), 15)
        f12 = RSet(Format(T(8), "####,###,###.00"), 15)
        f13 = RSet(Format(T(9), "####,###,###.00"), 15)
        f14 = RSet(Format(T(10), "####,###,###.00"), 15)
        f15 = RSet(Format(T(11), "####,###,###.00"), 15)

        PrintLine(1, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15)

        'Initialize
        For X = 0 To 24
            T1(X) = T1(X) + T(X)
            T(X) = 0
        Next X
    End Sub
End Class