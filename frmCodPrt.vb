Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6


Friend Class frmCodPrt
    Inherits DevExpress.XtraEditors.XtraForm

    Dim CatCode As String
    Dim Wperiod1 As String
    Dim H As Short

    Dim Ystr As String
    Dim J2str, J1str, Astr As String
    Dim A4str, A1str, A2str, Dstr As String
    Dim Tstr As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)

    Dim Pcnt As Short
    Dim L0 As Short

    Dim Pdlg As New PrintDialog
    Dim P As New Printer

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

        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Astr = Trim(txtMgaNmbr.Text)
        A1str = txMgaName
        A2str = txTrtyDesc
        A4str = Trim(txtTrtyNmbr.Text)
        Ystr = Trim(Str(Parry(1))) 'Curr Year
        Wperiod1 = txtPeriod.Text

        'RPTDIR
        OpenRptDir()
        OpenRptCed1()

        If Trim(txtMgaNmbr.Text) <> "001" And Trim(txtMgaNmbr.Text) <> "015" Then
            PrtCode()
        Else
            PrtCode1()
        End If

        prtobj.EndDoc()
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

    Private Sub frmCodPrt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
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

    Public Sub PrtCode()
        Dim Hstr As String = " "
        Dim CNstr, X3str, C1str As String
        Dim C4str, C2str, C3str, C5str As String

        Dim X As Short
        Dim N0 As Double
        Dim N1 As Double
        Dim A(17) As Double
        Dim B(17) As Double
        Dim A1 As Double
        Dim C(17) As Double
        Dim D(17) As Double

        'INITIALIZE
        Pcnt = 0 : L0 = 0

        For X = 0 To 16
            A(X) = 0 : B(X) = 0 : C(X) = 0 : D(X) = 0
        Next

        J1str = Format(Val(Trim(J2str)) - 1, "00")

        CNstr = Trim(f4str(TPp.PrmAgtRec))
        C1str = Trim(f4str(TPp.PrmReiPay))
        C2str = Trim(f4str(TPp.PrmLossRec))
        C3str = Trim(f4str(TPp.PrmLaeRec))
        C4str = Trim(f4str(TPp.PrmAgtBalNotDue))
        C5str = Trim(f4str(TPp.PrmReiPayNotDue))

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True

        '==================================================================================
        '=Get RPTDIR Current Period
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))))
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt
            X = Val(CatCode)
            A(X) = A(X) + A1

            rc = d4skip(f5, 1)
        Loop

        '==================================================================================
        '=Get RPTDIR Prior Period
        '==================================================================================

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptDir() : f5 = 0
            Nrptdir = Dpath & "RPTDIR" & Format(Int(CDbl(Mid(Ystr, 3, 2)) - 1), "00") & ".DBF"
            OpenRptDir()
            Hstr = J1str
            J1str = "12"
        End If

        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & J1str
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))))
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt
            X = Val(CatCode)
            C(X) = C(X) + A1

            rc = d4skip(f5, 1)
        Loop

        'Process Code For Jan Period

        If Trim(txtPeriod.Text) = "01" Then
            ClsRptDir() : f5 = 0
            Nrptdir = Dpath & "RPTDIR.DBF"
            OpenRptDir()
            J1str = Hstr
        End If

        '==================================================================================
        '=Get RPTCED Current Period
        '==================================================================================
        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof Or (RptCedKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod))))
            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            A1 = MLobt
            X = Val(CatCode)
            B(X) = B(X) + A1
            rc = d4skip(f6, 1)
        Loop

        '==================================================================================
        '=Get RPTCED Prior Period
        '==================================================================================

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptCed1() : f6 = 0
            Nrptced1 = Dpath & "RPTCED1" & Format(Int(CDbl(Mid(Ystr, 3, 2)) - 1), "00") & ".DBF"
            OpenRptCed1()
            Hstr = J1str
            J1str = "12"
        End If

        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & J1str
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof Or (RptCedKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod))))
            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            A1 = MLobt
            X = Val(CatCode)
            D(X) = D(X) + A1
            rc = d4skip(f6, 1)
        Loop

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptCed1() : f6 = 0
            Nrptced1 = Dpath & "RPTCED1.DBF"
            OpenRptCed1()
            J1str = Hstr
        End If

        'PRINT
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(Tstr)
        prtobj.Print()
        prtobj.Print(Astr & " " & A1str)
        prtobj.Print(Trim(A4str) & "  " & Trim(A2str) & " for " & J2str & "/" & Mid(Ystr, 3, 2))
        prtobj.Print()
        prtobj.Print(TAB(57), "DEBIT", TAB(71), "CREDIT")

        prtobj.Print("Agent Receivable")
        prtobj.Print("----------------")
        Call NormalCredit("401-01-001  Written Premium", 0, A(1))
        Call NormalCredit("401-02-001  Policy Fee", 0, A(2))
        Call NormalCredit("606-21-001  Front Fee", 0, A(11))
        Call NormalCredit("606-31-001  Premium Tax", 0, A(12))
        Call NormalDebit("501-01-001  Losses Paid", 0, A(6))
        Call NormalCredit("502-01-001  Salvage", 0, A(7))
        Call NormalDebit("531-01-001  LAE Paid", 0, A(8))
        Call NormalDebit("601-01-001  Commissions", 0, A(3))
        Call NormalDebit("611-01-001  Policy Fees", 0, A(2))

        N0 = A(1) + A(2) + A(11) + A(12) - A(6) + A(7) - A(8) - A(3) - A(2)
        X3str = Mid(CNstr, 1, 3) & "-" & Mid(CNstr, 4, 2) & "-" & Mid(CNstr, 6, 3)
        Call NormalDebit(X3str & "  Agent Receivable", 0, N0)
        prtobj.Print() : prtobj.Print()

        prtobj.Print("Reinsurance Payable")
        prtobj.Print("-------------------")
        If A(1) <> 0 Then N1 = B(1) / A(1) * 100
        Call NormalDebit("406-01-001  Written Premium", N1, B(1))
        If A(3) <> 0 Then N1 = B(3) / A(3) * 100
        Call NormalCredit("606-01-001  Commissions", N1, B(3))
        X3str = Mid(C1str, 1, 3) & "-" & Mid(C1str, 4, 2) & "-" & Mid(C1str, 6, 3)
        Call NormalCredit(X3str & "  Reinsurance Payable", 0, B(1) - B(3))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("Reinsurance Loss Recoverable")
        prtobj.Print("----------------------------")
        If (A(6) - A(7)) <> 0 Then N1 = (B(6) - B(7)) / (A(6) - A(7)) * 100
        X3str = Mid(C2str, 1, 3) & "-" & Mid(C2str, 4, 2) & "-" & Mid(C2str, 6, 3)
        Call NormalDebit(X3str & "  Losses Paid less Salvage", N1, B(6) - B(7))
        Call NormalCredit("513-01-001  Ceded Losses Paid", 0, B(6) - B(7))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("Reinsurance LAE Recoverable")
        prtobj.Print("---------------------------")
        If A(8) <> 0 Then N1 = B(8) / A(8) * 100
        X3str = Mid(C3str, 1, 3) & "-" & Mid(C3str, 4, 2) & "-" & Mid(C3str, 6, 3)
        Call NormalDebit(X3str & "  LAE Paid", N1, B(8))
        Call NormalCredit("543-01-001  Ceded LAE Paid", 0, B(8))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("Unearned Premium Change DIRECT")
        prtobj.Print("------------------------------")
        Call NormalDebit("209-01-001  Last Month", 0, C(4))
        Call NormalCredit("209-01-001  This Month", 0, A(4))
        Call NormalCredit("402-01-001  Difference", 0, C(4) - A(4))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("Unearned Premium Change CEDED")
        prtobj.Print("-----------------------------")
        Call NormalCredit("209-11-001  Last Month", 0, D(4))
        If A(4) <> 0 Then N1 = B(4) / A(4) * 100
        Call NormalDebit("209-11-001  This Month", N1, B(4))
        Call NormalDebit("407-01-001  Difference", 0, D(4) - B(4))

        prtobj.NewPage()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(Tstr)
        prtobj.Print()
        prtobj.Print(Astr & " " & A1str)
        prtobj.Print(Trim(A4str) & "  " & Trim(A2str) & " for " & J2str & "/" & Mid(Ystr, 3, 2))
        prtobj.Print()
        prtobj.Print(TAB(57), "DEBIT", TAB(71), "CREDIT")

        'BOOKED NOT DUE
        If C4str <> "" Or C5str <> "" Then
            prtobj.Print("Uncollected Balance Change DIRECT")
            prtobj.Print("---------------------------------")
            X3str = Mid(C4str, 1, 3) & "-" & Mid(C4str, 4, 2) & "-" & Mid(C4str, 6, 3)
            Call NormalCredit(X3str & "  Last Month", 0, C(17))
            Call NormalDebit(X3str & "  This Month", 0, A(17))
            X3str = Mid(CNstr, 1, 3) & "-" & Mid(CNstr, 4, 2) & "-" & Mid(CNstr, 6, 3)
            N0 = C(17) - A(17)
            Call NormalDebit(X3str & "  Difference", 0, N0)
            prtobj.Print() : prtobj.Print()

            prtobj.Print("Uncollected Balance Change CEDED")
            prtobj.Print("--------------------------------")
            X3str = Mid(C5str, 1, 3) & "-" & Mid(C5str, 4, 2) & "-" & Mid(C5str, 6, 3)
            Call NormalDebit(X3str & "  Last Month", 0, D(17))
            If A(17) <> 0 Then N1 = B(17) / A(17) * 100
            Call NormalCredit(X3str & "  This Month", N1, B(17))
            X3str = Mid(C1str, 1, 3) & "-" & Mid(C1str, 4, 2) & "-" & Mid(C1str, 6, 3)
            Call NormalCredit(X3str & "  Difference", 0, D(17) - B(17))
            prtobj.Print() : prtobj.Print()
        End If

        'O/S LOSSES AND LAE
        prtobj.Print("O/S Loss Reserve Change DIRECT")
        prtobj.Print("------------------------------")
        Call NormalDebit("201-01-001  Last Month", 0, C(9))
        Call NormalCredit("201-01-001  This Month", 0, A(9))
        Call NormalCredit("503-01-001  Difference", 0, C(9) - A(9))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("O/S Loss Reserve Change CEDED")
        prtobj.Print("-----------------------------")
        If A(9) <> 0 Then N1 = B(9) / A(9) * 100
        Call NormalCredit("201-11-001  Last Month", 0, D(9))
        Call NormalDebit("201-11-001  This Month", N1, B(9))
        Call NormalDebit("514-01-001  Difference", 0, D(9) - B(9))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("O/S LAE Reserve Change DIRECT")
        prtobj.Print("-----------------------------")
        Call NormalDebit("202-01-001  Last Month", 0, C(10))
        Call NormalCredit("202-01-001  This Month", 0, A(10))
        Call NormalCredit("533-01-001  Difference", 0, C(10) - A(10))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("O/S LAE Reserve Change CEDED")
        prtobj.Print("----------------------------")
        If A(10) <> 0 Then N1 = B(10) / A(10) * 100
        Call NormalCredit("202-11-001  Last Month", 0, D(10))
        Call NormalDebit("202-11-001  This Month", N1, B(10))
        Call NormalDebit("544-01-001  Difference", 0, D(10) - B(10))
    End Sub

    Public Sub PrtCode1()
        Dim Hstr As String = " "
        Dim CNstr, X3str, C1str As String
        Dim C4str, C2str, C3str, C5str As String

        Dim X As Short
        Dim N0 As Double
        Dim N1 As Double
        Dim A(17) As Double
        Dim B(17) As Double
        Dim A1 As Double
        Dim C(17) As Double
        Dim D(17) As Double

        'INITIALIZE
        Pcnt = 0 : L0 = 0

        For X = 0 To 16
            A(X) = 0 : B(X) = 0 : C(X) = 0 : D(X) = 0
        Next

        J1str = Format(Val(Trim(J2str)) - 1, "00")

        CNstr = Trim(f4str(TPp.PrmAgtRec))
        C1str = Trim(f4str(TPp.PrmReiPay))
        C2str = Trim(f4str(TPp.PrmLossRec))
        C3str = Trim(f4str(TPp.PrmLaeRec))
        C4str = Trim(f4str(TPp.PrmAgtBalNotDue))
        C5str = Trim(f4str(TPp.PrmReiPayNotDue))

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True

        '==================================================================================
        '=Get RPTDIR Current Period
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))))
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt
            X = Val(CatCode)
            A(X) = A(X) + A1

            rc = d4skip(f5, 1)
        Loop

        '==================================================================================
        '=Get RPTDIR Prior Period
        '==================================================================================

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptDir() : f5 = 0
            Nrptdir = Dpath & "RPTDIR" & Format(Int(CDbl(Mid(Ystr, 3, 2)) - 1), "00") & ".DBF"
            OpenRptDir()
            Hstr = J1str
            J1str = "12"
        End If

        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & J1str
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr)) & Trim(f4str(RDp.RptPeriod))))
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            A1 = MLobt
            X = Val(CatCode)
            C(X) = C(X) + A1

            rc = d4skip(f5, 1)
        Loop

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptDir() : f5 = 0
            Nrptdir = Dpath & "RPTDIR.DBF"
            OpenRptDir()
            J1str = Hstr
        End If

        '==================================================================================
        '=Get RPTCED Current Period
        '==================================================================================
        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof Or (RptCedKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod))))
            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            A1 = MLobt
            X = Val(CatCode)
            B(X) = B(X) + A1
            rc = d4skip(f6, 1)
        Loop


        '==================================================================================
        '=Get RPTCED Prior Period
        '==================================================================================

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptCed1() : f6 = 0
            Nrptced1 = Dpath & "RPTCED1" & Format(Int(CDbl(Mid(Ystr, 3, 2)) - 1), "00") & ".DBF"
            OpenRptCed1()
            Hstr = J1str
            J1str = "12"
        End If

        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & J1str
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof Or (RptCedKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod))))
            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            A1 = MLobt
            X = Val(CatCode)
            D(X) = D(X) + A1
            rc = d4skip(f6, 1)
        Loop

        'Process Code For Jan Period
        If Trim(txtPeriod.Text) = "01" Then
            ClsRptCed1() : f6 = 0
            Nrptced1 = Dpath & "RPTCED1.DBF"
            OpenRptCed1()
            J1str = Hstr
        End If

        'PRINT
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(Tstr)
        prtobj.Print()
        prtobj.Print(Astr & " " & A1str)
        prtobj.Print(Trim(A4str) & "  " & Trim(A2str) & " for " & J2str & "/" & Mid(Ystr, 3, 2))
        prtobj.Print()
        prtobj.Print(TAB(57), "DEBIT", TAB(71), "CREDIT")

        prtobj.Print("Agent Receivable")
        prtobj.Print("----------------")
        Call NormalCredit("401-01-002  Written Premium", 0, A(1))
        Call NormalCredit("401-02-002  Policy Fee", 0, A(2))
        prtobj.Print("621-02-005  Service Fees")
        PrtLn()
        Call NormalDebit("601-01-002  Commissions", 0, A(3))
        prtobj.Print("109-02-001  Agent Receivable")
        PrtLn()
        prtobj.Print() : prtobj.Print()


        prtobj.Print("Cash Clearing Adjustment")
        prtobj.Print("------------------------")
        prtobj.Print("109-02-002  Cash Clearing")
        PrtLn()
        prtobj.Print("109-02-001  Agent Receivable")
        PrtLn()
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        If A(1) + A(2) <> 0 Then
            N0 = (A(1) + A(2)) * 0.0175
            N0 = N0 * 100
            N0 = CInt(N0)
            N0 = N0 / 100
            N1 = N0 / (A(1) + A(2)) * 100
        End If

        prtobj.Print("Premium Tax Accural")
        prtobj.Print("-------------------")
        Call NormalDebit("625-01-022  Premium Tax", N1, N0)
        Call NormalCredit("205-00-002  Premium tax payable", 0, N0)
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        If A(1) <> 0 Then
            N0 = A(1) * 0.05
            N0 = N0 * 100
            N0 = CInt(N0)
            N0 = N0 / 100
            N1 = N0 / A(1) * 100
        End If

        prtobj.Print("Service Fee 5% of written")
        prtobj.Print("-------------------------")
        Call NormalDebit("621-02-003  Program Admin Fee", N1, N0)
        Call NormalCredit("212-02-001  A/P General DP Admin Fee", 0, N0)
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        prtobj.Print("Reinsurance Payable")
        prtobj.Print("-------------------")
        If A(1) <> 0 Then N1 = B(1) / A(1) * 100
        Call NormalDebit("406-01-002  Written Premium", N1, B(1))
        N0 = 0 : N1 = 0
        If A(3) <> 0 Then N1 = B(3) / A(3) * 100
        Call NormalCredit("606-01-002  Commissions", N1, B(3))
        Call NormalCredit("110-02-001  Reinsurance Payable", 0, B(1) - B(3))
        prtobj.Print() : prtobj.Print()

        'New Page
        prtobj.NewPage()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(Tstr)
        prtobj.Print()
        prtobj.Print(Astr & " " & A1str)
        prtobj.Print(Trim(A4str) & "  " & Trim(A2str) & " for " & J2str & "/" & Mid(Ystr, 3, 2))
        prtobj.Print()
        prtobj.Print(TAB(57), "DEBIT", TAB(71), "CREDIT")

        'BOOKED NOT DUE
        If C4str <> "" Or C5str <> "" Then
            prtobj.Print("Uncollected Balance Change DIRECT")
            prtobj.Print("---------------------------------")
            Call NormalCredit("109-02-099   Last Month", 0, C(17))
            Call NormalDebit("109-02-099   This Month", 0, A(17))
            prtobj.Print("109-02-001  Difference")
            Call NormalDebit("109-02-001   Difference", 0, C(17) - A(17))
            prtobj.Print() : prtobj.Print()

            prtobj.Print("Uncollected Balance Change CEDED")
            prtobj.Print("--------------------------------")
            Call NormalDebit("110-02-099   Last Month", 0, D(17))
            If A(17) <> 0 Then N1 = B(17) / A(17) * 100
            Call NormalCredit("110-02-099   This Month", N1, B(17))
            Call NormalCredit("110-02-001   Difference", 0, D(17) - B(17))
            prtobj.Print() : prtobj.Print()
        End If

        prtobj.Print("Direct Losses")
        prtobj.Print("-------------------")
        Call NormalDebit("501-01-002  Losses Paid", 0, A(6))
        Call NormalCredit("212-02-004  A/P Claims Funding", 0, A(6))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("Salvage")
        prtobj.Print("-------")
        Call NormalDebit("221-00-002  Exchange", 0, A(7))
        Call NormalCredit("502-01-002  Salvage DP", 0, A(7))
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        prtobj.Print("Reinsurance Loss Recoverable")
        prtobj.Print("----------------------------")
        If (A(6) - A(7)) <> 0 Then N1 = (B(6) - B(7)) / (A(6) - A(7)) * 100
        Call NormalDebit("111-02-001  Losses Paid less Salvage", N1, B(6) - B(7))
        prtobj.Print("513-01-002  Ceded Losses Paid")
        Call NormalCredit("513-01-002  Ceded Losses Paid", 0, B(6) - B(7))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("LAE Paid DIRECT (8% of earned premium)")
        prtobj.Print("--------------------------------------")
        Call NormalDebit("531-01-002  LAE Paid", 0, A(8))
        Call NormalCredit("212-02-002  A/P Claim Fees", 0, A(8))
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        prtobj.Print("Reinsurance LAE Recoverable")
        prtobj.Print("---------------------------")
        If A(8) <> 0 Then N1 = B(8) / A(8) * 100
        X3str = Mid(C3str, 1, 3) & "-" & Mid(C3str, 4, 2) & "-" & Mid(C3str, 6, 3)
        Call NormalDebit("112-02-001  LAE Paid", N1, B(8))
        Call NormalCredit("543-01-002  Ceded LAE Paid", 0, B(8))


        'New Page
        prtobj.NewPage()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(Tstr)
        prtobj.Print()
        prtobj.Print(Astr & " " & A1str)
        prtobj.Print(Trim(A4str) & "  " & Trim(A2str) & " for " & J2str & "/" & Mid(Ystr, 3, 2))
        prtobj.Print()
        prtobj.Print(TAB(57), "DEBIT", TAB(71), "CREDIT")

        prtobj.Print("Unearned Premium Change DIRECT")
        prtobj.Print("------------------------------")
        Call NormalDebit("209-01-002  Last Month", 0, C(4))
        Call NormalCredit("209-01-002  This Month", 0, A(4))
        Call NormalCredit("402-01-002  Difference", 0, C(4) - A(4))
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        prtobj.Print("Unearned Premium Change CEDED")
        prtobj.Print("-----------------------------")
        Call NormalCredit("209-11-002  Last Month", 0, D(4))
        If A(4) <> 0 Then N1 = B(4) / A(4) * 100
        Call NormalDebit("209-11-002  This Month", N1, B(4))
        Call NormalDebit("407-01-002  Difference", 0, D(4) - B(4))
        prtobj.Print() : prtobj.Print()

        'O/S LOSSES AND LAE
        prtobj.Print("O/S Loss Reserve Change DIRECT")
        prtobj.Print("------------------------------")
        Call NormalDebit("201-01-002  Last Month", 0, C(9))
        Call NormalCredit("201-01-002  This Month", 0, A(9))
        Call NormalCredit("503-01-002  Difference", 0, C(9) - A(9))
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        prtobj.Print("O/S Loss Reserve Change CEDED")
        prtobj.Print("-----------------------------")
        If A(9) <> 0 Then N1 = B(9) / A(9) * 100
        Call NormalCredit("201-11-002  Last Month", 0, D(9))
        Call NormalDebit("201-11-002  This Month", N1, B(9))
        Call NormalDebit("514-01-002  Difference", 0, D(9) - B(9))
        prtobj.Print() : prtobj.Print()

        prtobj.Print("O/S LAE Reserve Change DIRECT")
        prtobj.Print("-----------------------------")
        Call NormalDebit("202-01-002  Last Month", 0, C(10))
        Call NormalCredit("202-01-002  This Month", 0, A(10))
        Call NormalCredit("533-01-002  Difference", 0, C(10) - A(10))
        prtobj.Print() : prtobj.Print()

        N0 = 0 : N1 = 0
        prtobj.Print("O/S LAE Reserve Change CEDED")
        prtobj.Print("----------------------------")
        If A(10) <> 0 Then N1 = B(10) / A(10) * 100
        Call NormalCredit("202-11-002  Last Month", 0, D(10))
        Call NormalDebit("202-11-002  This Month", N1, B(10))
        Call NormalDebit("544-01-002  Difference", 0, D(10) - B(10))

    End Sub

    Public Sub PrtLn()
        prtobj.Print(TAB(50), "------------")
        prtobj.Print(TAB(65), "------------")
    End Sub

    Public Sub NormalCredit(ByRef NCstr As String, ByRef N1 As Double, ByRef N0 As Double)
        Dim Fstr As String

        N1 = N1 * 100
        N1 = CInt(N1)
        N1 = N1 / 100

        If N1 <> 0 Then
            Fstr = RSet(Format(N1, "##0.00"), 6) & "%"
        Else
            Fstr = " "
        End If

        If N0 < 0 Then
            prtobj.Print(NCstr, TAB(40), Fstr, TAB(49), RSet(Format(N0 * -1, "###,###,##0.00"), 14))
        End If

        If N0 >= 0 Then
            prtobj.Print(NCstr, TAB(40), Fstr, TAB(63), RSet(Format(N0, "###,###,##0.00"), 14))
        End If

    End Sub

    Sub NormalDebit(ByRef NDstr As String, ByRef N1 As Double, ByRef N0 As Double)
        Dim Fstr As String

        N1 = N1 * 100
        N1 = CInt(N1)
        N1 = N1 / 100

        If N1 <> 0 Then
            Fstr = RSet(Format(N1, "##0.00"), 6) & "%"
        Else
            Fstr = " "
        End If

        If N0 >= 0 Then
            prtobj.Print(NDstr, TAB(40), Fstr, TAB(49), RSet(Format(N0, "###,###,##0.00"), 14))
        End If

        If N0 < 0 Then
            prtobj.Print(NDstr, Fstr, TAB(63), RSet(Format(N0 * -1, "###,###,##0.00"), 14))
        End If

    End Sub

End Class