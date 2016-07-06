Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Friend Class frmTotByMgaDir
    Inherits DevExpress.XtraEditors.XtraForm

    Dim CatCode As String
    Dim Wperiod As String
    Dim Fname1 As String

    Dim J2str As String
    Dim Astr As String
    Dim A4str As String
    Dim Kstr As String
    Dim Pstr As String

    Dim T(24) As Double

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

        If optMtd.Checked = False And optYtd.Checked = False Then
            MsgBox("Select MTD or YTD")
        Else
            'RPTDIR
            OpenRptDir()
            BldDirTot()
        End If

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

    Private Sub frmTotByMgaDir_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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

    Public Sub BldDirTot()
        Dim X As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double


        Fname1 = My.Application.Info.DirectoryPath & "\" & Wperiod & " TOTBYMGAT "
        If optMtd.Checked = True Then Fname1 = Fname1 & "MTD.TXT"
        If optYtd.Checked = True Then Fname1 = Fname1 & "YTD.TXT"

        FileOpen(1, Fname1, OpenMode.Output)

        'Initialize
        For X = 0 To 24 : T(X) = 0 : Next X
        Kstr = ""

        '==================================================================================
        '=Get RPTDIR All MGAS
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)

        Do Until rc = r4eof
            If Astr = "991" Then
                If Trim(f4str(RDp.RptMgaNmbr)) = "001" Or Trim(f4str(RDp.RptMgaNmbr)) = "015" Or Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                    GoTo nextrec
                End If
            End If

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

            If optMtd.Checked = True Then If Trim(f4str(RDp.RptPeriod)) <> Wperiod Then GoTo nextrec
            If optYtd.Checked = True Then If Trim(f4str(RDp.RptPeriod)) > Wperiod Then GoTo nextrec

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
                        T(n) = T(n) + A(X)
                    Next X
                    GoTo nextrec
                End If
            End If

            For X = 1 To 24
                T(n) = T(n) + A(X)
            Next X

nextrec:
            rc = d4skip(f5, 1)
        Loop

        WriteRec()
        FileClose(1)
    End Sub

    Sub WriteRec()
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
        Dim X As Integer

        'Write Record

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

        Pstr = "               "
        Pstr = RSet(Format(T(0), "####,###,###.00"), Len(Pstr))
        f4 = Pstr
        Pstr = RSet(Format(T(1), "####,###,###.00"), Len(Pstr))
        f5 = Pstr
        Pstr = RSet(Format(T(2), "####,###,###.00"), Len(Pstr))
        f6 = Pstr
        Pstr = RSet(Format(T(3), "####,###,###.00"), Len(Pstr))
        f7 = Pstr
        Pstr = RSet(Format(T(5), "####,###,###.00"), Len(Pstr))
        f8 = Pstr
        Pstr = RSet(Format(T(6), "####,###,###.00"), Len(Pstr))
        f9 = Pstr
        Pstr = RSet(Format(T(7), "####,###,###.00"), Len(Pstr))
        f10 = Pstr
        Pstr = RSet(Format(T(8), "####,###,###.00"), Len(Pstr))
        f11 = Pstr
        Pstr = RSet(Format(T(9), "####,###,###.00"), Len(Pstr))
        f12 = Pstr
        Pstr = RSet(Format(T(10), "####,###,###.00"), Len(Pstr))
        f13 = Pstr
        Pstr = RSet(Format(T(11), "####,###,###.00"), Len(Pstr))
        f14 = Pstr

        PrintLine(1, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14)

        'Initialize
        For X = 0 To 24 : T(X) = 0 : Next X
    End Sub
End Class