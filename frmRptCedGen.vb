Option Strict Off
Option Explicit On
Friend Class frmRptCedGen
    Inherits DevExpress.XtraEditors.XtraForm

    Dim CatCode As String
    Dim Wperiod1 As String


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

    Private Sub cmdContinue_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdContinue.Click
        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()

        If rc <> 0 Then
            MsgBox("Invalid MGA Treaty")
            txtMgaNmbr.Text = ""
            txtTrtyNmbr.Text = ""
            txtPeriod.Text = ""
            txtMgaNmbr.Focus()
            Exit Sub
        End If

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyPrmRec()

        If rc <> 0 Then
            MsgBox("Invalid MGA Treaty")
            txtMgaNmbr.Text = ""
            txtTrtyNmbr.Text = ""
            txtPeriod.Text = ""
            txtMgaNmbr.Focus()
            Exit Sub
        End If

        If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then
            MsgBox("Inactive Treaty")
            txtMgaNmbr.Text = ""
            txtTrtyNmbr.Text = ""
            txtPeriod.Text = ""
            txtMgaNmbr.Focus()
            Exit Sub
        End If

        GetTrtyMstVar()
        CedTran()

        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtPeriod.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub frmRptCedGen_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenRptDir()
        OpenRptCed1()
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
                cmdContinue.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdContinue.Focus()

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

    Private Sub CedTran()
        Dim Nstr As String
        Dim Nstr1 As String

        Dim X As Short
        Dim E(10) As Short
        Dim C1(2) As Short

        Dim A(24) As Double
        Dim A1 As Double
        Dim B(24) As Double
        Dim B1 As Double
        Dim N0 As Double
        Dim N1 As Double
        Dim T As Double

        Dim Y As Short
        Dim CedPerc As Double

        Dim T3(3) As Double

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

        CedPerc = f4double(TMp.TrtyCedPerc)

        '==================================================================================
        '=Get RPTDIR
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        rc = d4seek(f5, RptDirKey)


        Wperiod1 = txtPeriod.Text

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))))
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))

            'Skip Pol Fee, Prem Tax, Front Fee
            If CatCode = "02" Or CatCode = "11" Or CatCode = "12" Or CatCode = "15" Or CatCode = "16" Then
                GoTo nextrec
            End If

            A1 = MLobt

            For X = 1 To 24
                B(X) = 0
                A(X) = MLobp(X)
            Next X

            T = 0
            N1 = 0
            Y = 0

            N0 = A1 * CedPerc
            Nstr = ".00"
            Nstr1 = ""

            'Rounding Adjustment
            If N0 >= 0 Then N0 = N0 + 0.005
            If N0 < 0 Then N0 = N0 - 0.005

            If InStr(1, Str(N0), ".", 1) <> 0 Then
                If A1 <> 0 Then Nstr = Mid(Str(N0), InStr(1, Str(N0), ".", 1), 3)
                If A1 <> 0 Then Nstr1 = Microsoft.VisualBasic.Strings.Left(Str(N0), InStr(1, Str(N0), ".", 1) - 1)
            End If

            If InStr(1, Str(N0), ".", 1) = 0 Then
                If A1 <> 0 Then Nstr1 = Str(N0)
            End If

            B1 = Val(Trim(Nstr1) & Trim(Nstr))

            'Compute Ceding Coverages
            For X = 1 To 24
                N0 = A(X) * CedPerc
                Nstr = ".00"
                Nstr1 = ""

                'Rounding Adjustment
                If N0 >= 0 Then N0 = N0 + 0.005
                If N0 < 0 Then N0 = N0 - 0.005

                If InStr(1, Str(N0), ".", 1) <> 0 Then
                    If A(X) <> 0 Then Nstr = Mid(Str(N0), InStr(1, Str(N0), ".", 1), 3)
                    If A(X) <> 0 Then Nstr1 = Microsoft.VisualBasic.Strings.Left(Str(N0), InStr(1, Str(N0), ".", 1) - 1)
                End If

                If InStr(1, Str(N0), ".", 1) = 0 Then
                    If A(X) <> 0 Then Nstr1 = Str(N0)
                End If

                B(X) = Val(Trim(Nstr1) & Trim(Nstr))

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
            If CatCode <> "17" Then B(Y) = B(Y) + N0

            'Write Ceded Record
            RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text) & Trim(CatCode) & Trim(txRptYear)
            GetRptCedRec()

            If UpdateTran Then
                MsgBox("MGA Already Ceded.   Notify Supervisor")
                GoTo nextrec
            End If

            If Not AddTran Then
                MsgBox("Ceded Processing Error.   Notify Supervisor")
                GoTo nextrec
            End If

            If d4appendStart(f6, 0) <> r4success Then
                MsgBox("Ceded Processing Error.   Notify Supervisor")
                GoTo nextrec
            End If

            Call f4assign(Rc1p.CedMgaNmbr, txtMgaNmbr.Text)
            Call f4assign(Rc1p.CedTrtyNmbr, txtTrtyNmbr.Text)
            Call f4assign(Rc1p.CedPeriod, txtPeriod.Text)
            Call f4assign(Rc1p.CedCatCode, CatCode)
            Call f4assign(Rc1p.CedYear, txRptYear)
            Call f4assignDouble(Rc1p.CedTotal, B1)
            Call f4assignDouble(Rc1p.CedPPbi, B(1))
            Call f4assignDouble(Rc1p.CedPPpd, B(2))
            Call f4assignDouble(Rc1p.CedPPmed, B(3))
            Call f4assignDouble(Rc1p.CedPPumbi, B(4))
            Call f4assignDouble(Rc1p.CedPPumpd, B(5))
            Call f4assignDouble(Rc1p.CedPPpip, B(6))
            Call f4assignDouble(Rc1p.CedPPcomp, B(7))
            Call f4assignDouble(Rc1p.CedPPcoll, B(8))
            Call f4assignDouble(Rc1p.CedPPrent, B(9))
            Call f4assignDouble(Rc1p.CedPPtow, B(10))
            Call f4assignDouble(Rc1p.CedCMbi, B(11))
            Call f4assignDouble(Rc1p.CedCMpd, B(12))
            Call f4assignDouble(Rc1p.CedCMmed, B(13))
            Call f4assignDouble(Rc1p.CedCMumbi, B(14))
            Call f4assignDouble(Rc1p.CedCMumpd, B(15))
            Call f4assignDouble(Rc1p.CedCMpip, B(16))
            Call f4assignDouble(Rc1p.CedCMcomp, B(17))
            Call f4assignDouble(Rc1p.CedCMcoll, B(18))
            Call f4assignDouble(Rc1p.CedCMrent, B(19))
            Call f4assignDouble(Rc1p.CedCMtow, B(20))
            Call f4assignDouble(Rc1p.CedOTim, B(21))
            Call f4assignDouble(Rc1p.CedOTallied, B(22))
            Call f4assignDouble(Rc1p.CedOTfire, B(23))
            Call f4assignDouble(Rc1p.CedOTmulti, B(24))
            rc = d4append(f6)
            rc = d4unlock(f6)

nextrec:
            rc = d4skip(f5, 1)
        Loop

        MsgBox("Ceded Processing Complete")
    End Sub
End Class