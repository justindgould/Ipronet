Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmRptTrtyInfo


    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim Astr As String
    Dim A1str As String
    Dim A2str As String
    Dim A4str As String

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
        GetTrtyReiVar()


        'Global Initial
        Astr = Trim(txtMgaNmbr.Text)
        A1str = txMgaName
        A2str = txTrtyDesc
        A4str = Trim(txtTrtyNmbr.Text)

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1
        BeginRun = True

        PrtTrtyRpt()

        prtobj.EndDoc()

        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cmdPrt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdPrt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub frmRptTrtyInfo_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        OpenReiMst()
        OpenStateRef()
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
                cmdPrt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdPrt.Focus()

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

    Public Sub PrtTrtyRpt()
        Dim cove(24) As String
        Dim Sdesc As String
        Dim X As Integer
        Dim wstr As String = " "
        Dim wstr1 As String = " "

        For X = 0 To 24 : cove(X) = " " : Next X

        '"Get State Description"
        rc = d4top(f90)
        Call d4tagSelect(f90, d4tag(f90, "K1"))
        rc = d4seek(f90, Trim(txPrmStateCode))
        Sdesc = " "
        If rc <> 0 Then Sdesc = "State Not Set UP"
        If rc = 0 Then Sdesc = Trim(f4str(STp.StateName))
        rc = d4unlock(f90)

        If chPPBI = 1 Then cove(1) = "X"
        If chPPPD = 1 Then cove(2) = "X"
        If chPPMED = 1 Then cove(3) = "X"
        If chPPUMBI = 1 Then cove(4) = "X"
        If chPPUMPD = 1 Then cove(5) = "X"
        If chPPPIP = 1 Then cove(6) = "X"
        If chPPCOMP = 1 Then cove(7) = "X"
        If chPPCOLL = 1 Then cove(8) = "X"
        If chPPRENT = 1 Then cove(9) = "X"
        If chPPTOW = 1 Then cove(10) = "X"
        If chCMBI = 1 Then cove(11) = "X"
        If chCMPD = 1 Then cove(12) = "X"
        If chCMMED = 1 Then cove(13) = "X"
        If chCMUMBI = 1 Then cove(14) = "X"
        If chCMUMPD = 1 Then cove(15) = "X"
        If chCMPIP = 1 Then cove(16) = "X"
        If chCMCOMP = 1 Then cove(17) = "X"
        If chCMCOLL = 1 Then cove(18) = "X"
        If chCMRENT = 1 Then cove(19) = "X"
        If chCMTOW = 1 Then cove(20) = "X"
        If chIM = 1 Then cove(21) = "X"
        If chALLIED = 1 Then cove(22) = "X"
        If chFIRE = 1 Then cove(23) = "X"
        If chMULTIP = 1 Then cove(24) = "X"

        '======================================================================================
        '= Print Treaty Master
        '======================================================================================

        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("Treaty Information Data")
        prtobj.Print(TAB(29), Astr & "  " & A1str)
        prtobj.Print(Z1str, TAB(30), A4str & "  " & Trim(A2str))
        prtobj.Print("___________________________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Description   " & txTrtyDesc)
        prtobj.Print("Front Fee %   " & txTrtyFFperc, TAB(30), "Direct Comm %    " & txDirCommPerc)
        prtobj.Print("Premium Tax % " & txTrtyPremTaxPerc, TAB(30), "Ceded Comm %     " & txCedCommPerc)
        prtobj.Print("Ceding %      " & txTrtyCedPerc)
        prtobj.Print()

        prtobj.Print("Priv Pass", TAB(15), "Commercial", TAB(30), "Other")
        prtobj.Print(cove(1) & " BI", TAB(15), cove(11) & " BI", TAB(30), cove(21) & " IM")
        prtobj.Print(cove(2) & " PD", TAB(15), cove(12) & " PD", TAB(30), cove(22) & " ALLIED")
        prtobj.Print(cove(3) & " MED", TAB(15), cove(13) & " MED", TAB(30), cove(23) & " FIRE")
        prtobj.Print(cove(4) & " UMBI", TAB(15), cove(14) & " UMBI", TAB(30), cove(24) & " MULTIP")
        prtobj.Print(cove(5) & " UMPD", TAB(15), cove(15) & " UMPD")
        prtobj.Print(cove(6) & " PIP", TAB(15), cove(16) & " PIP")
        prtobj.Print(cove(7) & " COMP", TAB(15), cove(17) & " COMP")
        prtobj.Print(cove(8) & " COLL", TAB(15), cove(18) & " COLL")
        prtobj.Print(cove(9) & " RENT", TAB(15), cove(19) & " RENT")
        prtobj.Print(cove(10) & " TOW", TAB(15), cove(20) & " TOW")

        prtobj.Print("___________________________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Allocations")
        prtobj.Print()
        prtobj.Print("Rein #", TAB(9), "Name", TAB(56), "%")
        If Trim(txTrtyReiNmbr1) <> "" Then prtobj.Print(txTrtyReiNmbr1, TAB(9), txTrtyReiName1, TAB(56), txTrtyReiPerc1)
        If Trim(txTrtyReiNmbr2) <> "" Then prtobj.Print(txTrtyReiNmbr2, TAB(9), txTrtyReiName2, TAB(56), txTrtyReiPerc2)
        If Trim(txTrtyReiNmbr3) <> "" Then prtobj.Print(txTrtyReiNmbr3, TAB(9), txTrtyReiName3, TAB(56), txTrtyReiPerc3)
        If Trim(txTrtyReiNmbr4) <> "" Then prtobj.Print(txTrtyReiNmbr4, TAB(9), txTrtyReiName4, TAB(56), txTrtyReiPerc4)
        If Trim(txTrtyReiNmbr5) <> "" Then prtobj.Print(txTrtyReiNmbr5, TAB(9), txTrtyReiName5, TAB(56), txTrtyReiPerc5)
        If Trim(txTrtyReiNmbr6) <> "" Then prtobj.Print(txTrtyReiNmbr6, TAB(9), txTrtyReiName6, TAB(56), txTrtyReiPerc6)
        If Trim(txTrtyReiNmbr7) <> "" Then prtobj.Print(txTrtyReiNmbr7, TAB(9), txTrtyReiName7, TAB(56), txTrtyReiPerc7)
        If Trim(txTrtyReiNmbr8) <> "" Then prtobj.Print(txTrtyReiNmbr8, TAB(9), txTrtyReiName8, TAB(56), txTrtyReiPerc8)
        If Trim(txTrtyReiNmbr9) <> "" Then prtobj.Print(txTrtyReiNmbr9, TAB(9), txTrtyReiName9, TAB(56), txTrtyReiPerc9)
        If Trim(txTrtyReiNmbr10) <> "" Then prtobj.Print(txTrtyReiNmbr10, TAB(9), txTrtyReiName10, TAB(56), txTrtyReiPerc10)

        prtobj.Print("___________________________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Report Name  " & txPrmRptName)
        prtobj.Print("Contract #   " & txPrmConNmbr, TAB(40), "Inception Date " & Mid(txPrmIncpDate, 1, 2) & "/" + Mid(txPrmIncpDate, 3, 4))

        If txPrmReiRptFlag = "N" Or txPrmReiRptFlag = "0" Then wstr = "No"
        If txPrmReiRptFlag = "Y" Or txPrmReiRptFlag = "1" Then wstr = "Yes"
        If txPrmStatus = "0" Then wstr1 = "Active"
        If txPrmStatus = "1" Then wstr1 = "Inactive"
        If txPrmStatus = "2" Then wstr1 = "Pending"
        prtobj.Print("Rein Report? ", wstr, TAB(40), "Status         ", wstr1)
        prtobj.Print()

        prtobj.Print("___________________________________________________________________________________")
        prtobj.Print()
        prtobj.Print(TAB(25), "General Ledger")
        prtobj.Print()
        prtobj.Print("Description         ", TAB(25), txPrmDesc)
        prtobj.Print("Agent Receivable    ", TAB(25), txPrmAgtRec)
        prtobj.Print("Reinsurance Payable ", TAB(25), txPrmReiPay)
        prtobj.Print("Loss Recoverable    ", TAB(25), txPrmLossRec)
        prtobj.Print("LAE Recoverable     ", TAB(25), txPrmLaeRec)
        prtobj.Print("Agent Bal Not Due   ", TAB(25), txPrmAgtBalNotDue, TAB(40), "State Code " & txPrmStateCode & " " & Sdesc)
        prtobj.Print("Rein Pay Not Due    ", TAB(25), txPrmReiPayNotDue, TAB(40), "Group ID   " & txPrmGrpID)
    End Sub
End Class