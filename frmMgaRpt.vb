Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Friend Class frmMgaRpt
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
    Dim Wyear As String
    Dim Wperiod As String
    Dim Wperiod1 As String
    Dim H As Short
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim Ystr As String
    Dim J2str As String
    Dim Astr As String
    Dim A1str As String
    Dim A2str As String
    Dim A4str As String
    Dim Dstr As String
    Dim J3str As String
    Dim J4str As String
    Dim Kstr As String
    Dim Kstr1 As String

    Dim Pcnt As Short
    Dim L0 As Short
    Dim T(16) As Double
    Dim T1(4) As Double
    Dim T2(4) As Double
    Dim B(15, 24) As Double
    Dim B1(15, 24) As Double
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

        If J2str = "01" Then J4str = "January 31"
        If J2str = "02" Then J4str = "February 28"
        If J2str = "03" Then J4str = "March 31"
        If J2str = "04" Then J4str = "April 30"
        If J2str = "05" Then J4str = "May 31"
        If J2str = "06" Then J4str = "June 30"
        If J2str = "07" Then J4str = "July 31"
        If J2str = "08" Then J4str = "August 31"
        If J2str = "09" Then J4str = "September 30"
        If J2str = "10" Then J4str = "October 31"
        If J2str = "11" Then J4str = "November 30"
        If J2str = "12" Then J4str = "December 31"
        J4str = J4str & ", " & Ystr

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next
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
        PrtMgaRpt()
        If Not RptCmplt Then Exit Sub

        'CEDDIR1
        If RptCmplt Then
            OpenRptCed1()
            OpenItdCed1()
            RptType = 2
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed1() : f6 = 0
            ClsItdCed1() : f12 = 0
        End If

        'CEDDIR2
        If RptCmplt Then
            OpenRptCed2()
            OpenItdCed2()
            RptType = 3
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed2() : f6 = 0
            ClsItdCed2() : f12 = 0
        End If

        'CEDDIR3
        If RptCmplt Then
            OpenRptCed3()
            OpenItdCed3()
            RptType = 4
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed3() : f6 = 0
            ClsItdCed3() : f12 = 0
        End If

        'CEDDIR4
        If RptCmplt Then
            OpenRptCed4()
            OpenItdCed4()
            RptType = 5
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed4() : f6 = 0
            ClsItdCed4() : f12 = 0
        End If

        'CEDDIR5
        If RptCmplt Then
            OpenRptCed5()
            OpenItdCed5()
            RptType = 6
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed5() : f6 = 0
            ClsItdCed5() : f12 = 0
        End If

        'Reinsurer
        If txPrmReiRptFlag = "1" Or txPrmReiRptFlag = "Y" Then
            OpenRptCed1()
            OpenItdCed1()
            RptType = 7
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed1() : f6 = 0
            ClsItdCed1() : f12 = 0
        End If

        'Reinsurer Rpt
        If txPrmReiRptFlag = "1" Or txPrmReiRptFlag = "Y" Then
            OpenRptCed1()
            OpenItdCed1()
            RptType = 8
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed1() : f6 = 0
            ClsItdCed1() : f12 = 0
        End If

        If txPrmReiRptFlag = "1" Or txPrmReiRptFlag = "Y" Then
            OpenRptCed2()
            OpenItdCed2()
            RptType = 9
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed2() : f6 = 0
            ClsItdCed2() : f12 = 0
        End If

        If txPrmReiRptFlag = "1" Or txPrmReiRptFlag = "Y" Then
            OpenRptCed3()
            OpenItdCed3()
            RptType = 10
            RptCmplt = False
            PrtCedRpt()
            ClsRptCed3() : f6 = 0
            ClsItdCed3() : f12 = 0
        End If

        'Report Edit List
        RptEditLst()

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

    Private Sub frmMgaRpt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

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
        Tobj = txtMgaNmbr
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
        Tobj = txtTrtyNmbr
        Dim X As Integer

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

    Public Sub PrtMgaRpt()

        Dim X As Short
        Dim C1(2) As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double
        Dim T3(15) As Double
        Dim t4 As Double
        Dim t5 As Double
        Dim N0 As Double
        Dim N2 As Double
        Dim N3 As Double

        'Initialize
        For X = 0 To 15
            T3(X) = 0
            For n = 0 To 24
                B(X, n) = 0
                B1(X, n) = 0
            Next n
        Next X

        For X = 0 To 16 : T(X) = 0 : Next X

        For X = 0 To 4
            T1(X) = 0
            T2(X) = 0
        Next X


        Kstr1 = "" : Pcnt = 0 : H = 0 : L0 = 0

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

        For X = 1 To 24 : C(X) = CovArry(X) : Next X

        '======================================================================================
        '= PROCESS MTD DIRECT
        '======================================================================================

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
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1
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
        '= Print MTD DIRECT
        '======================================================================================

        RptPageHeading()
        prtobj.Print("    Current Month", TAB(24), "Written", TAB(35), "Commission", TAB(56), "Net", TAB(65), "Unearned")
        prtobj.Print()

        'Premium, Commission, Net, Unearned
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(0, X) - B(2, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(3, X), "###,###,###.00"), 14))
                t4 = t4 + B(2, X)
                t5 = t5 + (B(0, X) - B(2, X))
            End If
        Next X

        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(45), RSet(Format(t5, "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(3), "###,###,###.00"), 14))
        prtobj.Print()
        prtobj.Print()

        Dstr = "    Current Month"
        prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(56), "LAE",
                           TAB(65), "O/S Loss", TAB(80), "O/S LAE",
                           TAB(92), "IBNR Loss", TAB(107), "IBNR LAE")
        prtobj.Print(TAB(27), "Paid", TAB(55), "Paid", TAB(66), "Reserve",
                     TAB(80), "Reserve", TAB(94), "Reserve", TAB(108), "Reserve")
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(7, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(8, X), "###,###,###.00"), 14),
                                   TAB(73), RSet(Format(B(9, X), "###,###,###.00"), 14),
                                   TAB(87), RSet(Format(B(12, X), "###,###,###.00"), 14),
                                   TAB(101), RSet(Format(B(13, X), "###,###,###.00"), 14))
            End If
        Next X

        'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T(7), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(8), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T(9), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T(12), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(T(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Current Month")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(17), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(17), RSet(Format(T(11), "###,###,###.00"), 14))

        '======================================================================================
        '= PROCESS YTD DIRECT
        '======================================================================================

        '==================================================================================
        '=Get ITDDIR PRIOR Periods
        '==================================================================================
        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)
        ItdDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f11, ItdDirKey)

        Do Until rc = r4eof Or (ItdDirKey <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))))
            GetItdDirVar()
            CatCode = Trim(f4str(IDp.ItdCatCode))
            Wyear = Trim(f4str(IDp.ItdYear))
            Wperiod = Trim(f4str(IDp.ItdPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1
            If n <> 3 And n <> 8 And n <> 9 And n <> 12 And n <> 13 Then GoTo nextrec1

            For X = 1 To 24
                B1(n, X) = B1(n, X) + A(X)
                T3(n) = T3(n) + A(X)
            Next X

nextrec1:
            rc = d4skip(f11, 1)
        Loop

        '==================================================================================
        '=Get RPTDIR YTD
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))))

            If Trim(f4str(RDp.RptPeriod)) >= Wperiod1 Then GoTo nextrec2

            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1

            If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec2

            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec2
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X
nextrec2:
            rc = d4skip(f5, 1)
        Loop

        '======================================================================================
        '= Print YTD DIRECT
        '======================================================================================
        t4 = 0
        t5 = 0
        RptPageHeading()
        prtobj.Print("    Year To Date", TAB(24), "Written", TAB(35), "Commission", TAB(57), "Net", TAB(69), "Earned")
        prtobj.Print()


        'Premium Commission Net Unearned
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                                   TAB(60), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15))
                t4 = t4 + B(2, X)
                t5 = t5 + (B(0, X) - B(2, X))
            End If
        Next X

        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(45), RSet(Format(t5, "####,###,###.00"), 15),
                           TAB(60), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15))
        prtobj.Print()
        prtobj.Print()
        prtobj.Print()


        Dstr = "    Year To Date"
        prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(57), "LAE",
                           TAB(67), "O/S Loss", TAB(82), "O/S LAE",
                           TAB(94), "IBNR Loss", TAB(109), "IBNR LAE")
        prtobj.Print(TAB(27), "Paid", TAB(56), "Paid", TAB(67), "Incurred",
                     TAB(81), "Incurred", TAB(95), "Incurred", TAB(109), "Incurred")
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(7, X), "####,###,###.00"), 15),
                                   TAB(60), RSet(Format(B(8, X) - B1(8, X), "####,###,###.00"), 15),
                                   TAB(75), RSet(Format(B(9, X) - B1(9, X), "###,###,###.00"), 14),
                                   TAB(89), RSet(Format(B(12, X) - B1(12, X), "###,###,###.00"), 14),
                                   TAB(103), RSet(Format(B(13, X) - B1(13, X), "###,###,###.00"), 14))
            End If
        Next X

        'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T(7), "####,###,###.00"), 15),
                           TAB(60), RSet(Format(T(8) - T3(8), "####,###,###.00"), 15),
                           TAB(75), RSet(Format(T(9) - T3(9), "###,###,###.00"), 14),
                           TAB(89), RSet(Format(T(12) - T3(12), "###,###,###.00"), 14),
                           TAB(103), RSet(Format(T(13) - T3(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Year To Date")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(17), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(17), RSet(Format(T(11), "###,###,###.00"), 14))


        '======================================================================================
        '= PROCESS ITD DIRECT
        '======================================================================================

        '==================================================================================
        '= Get ITDDIR
        '==================================================================================
        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)
        ItdDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f11, ItdDirKey)


        Do Until rc = r4eof Or (ItdDirKey <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))))
            GetItdDirVar()
            CatCode = Trim(f4str(IDp.ItdCatCode))
            Wyear = Trim(f4str(IDp.ItdYear))
            Wperiod = Trim(f4str(IDp.ItdPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1

            If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec3

            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec3
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X

nextrec3:
            rc = d4skip(f11, 1)
        Loop

        For n = 0 To 13
            For X = 1 To 24
                B1(n, X) = 0
            Next X
            T3(n) = 0
        Next n

        '======================================================================================
        '= Print ITD DIRECT
        '======================================================================================
        t4 = 0
        t5 = 0
        RptPageHeading()
        prtobj.Print("    Incept. To Date", TAB(25), "Written", TAB(37), "Commission", TAB(60), "Net", TAB(73), "Earned",
                                            TAB(83), "Loss Ratio", TAB(97), "Loss Ratio")
        prtobj.Print(TAB(85), "W/O IBNR", TAB(100), "W/ IBNR")
        prtobj.Print()
        prtobj.Print()

        'Premium Commission Net Eearned
        For X = 1 To 24
            If C(X) <> 0 Then
                N0 = B(0, X) + B1(3, X) - B(3, X)
                N2 = B1(5, X) + B(5, X) - B1(6, X) - B(6, X) + B1(7, X) + B(7, X) + B(8, X) - B1(8, X) + B(9, X) - B1(9, X)
                N3 = N2 + B(12, X) - B1(12, X) + B(13, X) - B1(13, X)
                If CDec(N0) = 0 Then
                    N0 = 1 : N2 = 0 : N3 = 0
                End If
                CovHeading((X))
                prtobj.Print(Dstr, TAB(18), RSet(Format(B(0, X), "####,###,###.00"), 14),
                                   TAB(33), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                   TAB(48), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                                   TAB(64), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15),
                                   TAB(79), RSet(Format(CInt((N2 / N0) * 10000) / 100, "###,###,###.00"), 14),
                                   TAB(93), RSet(Format(CInt((N3 / N0) * 10000) / 100, "###,###,###.00"), 14))
                t4 = t4 + B(2, X)
                t5 = t5 + (B(0, X) - B(2, X))
            End If
        Next X

        Dstr = "   Totals"
        N0 = T(0) + T3(3) - T(3)
        N2 = T3(5) + T(5) - T3(6) - T(6) + T3(7) + T(7) + T(8) - T3(8) + T(9) - T3(9)
        N3 = N2 + T(12) - T3(12) + T(13) - T3(13)
        If CDec(N0) = 0 Then
            N0 = 1 : N2 = 0 : N3 = 0
        End If
        prtobj.Print()
        prtobj.Print(Dstr, TAB(18), RSet(Format(T(0), "####,###,###.00"), 14),
                           TAB(33), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(48), RSet(Format(t5, "####,###,###.00"), 15),
                           TAB(64), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15),
                           TAB(79), RSet(Format(CInt((N2 / N0) * 10000) / 100, "###,###,###.00"), 14),
                           TAB(93), RSet(Format(CInt((N3 / N0) * 10000) / 100, "###,###,###.00"), 14))
        prtobj.Print()
        prtobj.Print()



        Dstr = "    Incept. To Date"
        prtobj.Print(Dstr, TAB(28), "Loss", TAB(36), "Sal & Subro", TAB(60), "LAE",
                           TAB(71), "O/S Loss", TAB(86), "O/S LAE",
                           TAB(98), "IBNR Loss", TAB(113), "IBNR LAE")
        prtobj.Print(TAB(28), "Paid", TAB(59), "Paid", TAB(72), "Incurred",
                     TAB(86), "Incurred", TAB(100), "Incurred", TAB(114), "Incurred")
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(18), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(33), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(48), RSet(Format(B(7, X), "####,###,###.00"), 15),
                                   TAB(64), RSet(Format(B(8, X), "####,###,###.00"), 15),
                                   TAB(79), RSet(Format(B(9, X), "###,###,###.00"), 14),
                                   TAB(93), RSet(Format(B(12, X), "###,###,###.00"), 14),
                                   TAB(107), RSet(Format(B(13, X), "###,###,###.00"), 14))
            End If
        Next X

        'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(18), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(33), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(47), RSet(Format(T(7), "####,###,###.00"), 15),
                           TAB(64), RSet(Format(T(8), "####,###,###.00"), 15),
                           TAB(79), RSet(Format(T(9), "###,###,###.00"), 14),
                           TAB(93), RSet(Format(T(12), "###,###,###.00"), 14),
                           TAB(107), RSet(Format(T(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Incept. To Date")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(18), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(18), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(18), RSet(Format(T(11), "###,###,###.00"), 14))

        '=====================================================================================
        '= Get Accident Year
        '=====================================================================================
        H = 1
        L0 = 45
        For n = 5 To 9
            For X = 1 To 24
                B(n, X) = 0
            Next X
        Next n

        Call d4tagSelect(f5, d4tag(f5, "K4"))
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4top(f5)
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))))

            CatCode = Trim(f4str(RDp.RptCatCode))
            If CatCode <= "05" Or CatCode >= "11" Then GoTo nextrec4
            J3str = Trim(f4str(RDp.RptPeriod))
            If J3str <> J2str Then GoTo nextrec4

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

            'Accumulate
            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T1(n - 5) = T1(n - 5) + A(X)
            Next X

nextrec4:
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

        RptCmplt = True
    End Sub

    Public Sub PrtCedRpt()
        Dim X As Short
        Dim C1(2) As Short
        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double
        Dim T3(15) As Double
        Dim t4 As Double
        Dim t5 As Double
        Dim N0 As Double
        Dim N2 As Double
        Dim N3 As Double

        Kstr1 = ""
        Pcnt = 0

        For X = 0 To 15
            T3(X) = 0
            For n = 0 To 24
                B(X, n) = 0
                B1(X, n) = 0
            Next n
        Next X

        For X = 0 To 16
            T(X) = 0
        Next X

        For X = 0 To 4
            T1(X) = 0
            T2(X) = 0
        Next X

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

        '======================================================================================
        '= PROCESS MTD Ceded
        '======================================================================================

        '==================================================================================
        '=Get CEDDIR Current Period
        '==================================================================================
        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        rc = d4seek(f6, RptDirKey)

        If RptDirKey = (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod))) Then
            GoTo Continue_Run
        End If

        Call d4tagSelect(f12, d4tag(f12, "K1"))
        rc = d4top(f12)
        ItdDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f12, ItdDirKey)
        If RptType <> 2 And RptType <> 7 And RptType <> 8 Then
            If Mid(ItdDirKey, 1, 5) <> (Trim(f4str(Ic1p.CedMgaNmbr)) & Trim(f4str(Ic1p.CedTrtyNmbr))) Then
                Exit Sub
            End If
        End If

Continue_Run:
        rc = d4seek(f6, RptDirKey)
        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod))))
            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            Wyear = Trim(f4str(Rc1p.CedYear))
            Wperiod = Trim(f4str(Rc1p.CedPeriod))
            A1 = MLobt

            Array.Clear(A, 0, A.Length)

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1
            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X
nextrec:
            rc = d4skip(f6, 1)
        Loop

        '======================================================================================
        '= Print MTD CEDED
        '======================================================================================
        RptPageHeading()
        prtobj.Print("    Current Month", TAB(24), "Written", TAB(35), "Commission", TAB(56), "Net", TAB(65), "Unearned")
        prtobj.Print()

        'Premium, Commission, Net, Unearned
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(0, X) - B(2, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(3, X), "###,###,###.00"), 14))
                t4 = t4 + B(2, X)
                t5 = t5 + (B(0, X) - B(2, X))
            End If
        Next X

        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(45), RSet(Format(t5, "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(3), "###,###,###.00"), 14))
        prtobj.Print()
        prtobj.Print()

        Dstr = "    Current Month"
        prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(56), "LAE",
                           TAB(65), "O/S Loss", TAB(80), "O/S LAE",
                           TAB(92), "IBNR Loss", TAB(107), "IBNR LAE")
        prtobj.Print(TAB(27), "Paid", TAB(55), "Paid", TAB(66), "Reserve",
                     TAB(80), "Reserve", TAB(94), "Reserve", TAB(108), "Reserve")
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(7, X), "###,###,###.00"), 14),
                                   TAB(59), RSet(Format(B(8, X), "###,###,###.00"), 14),
                                   TAB(73), RSet(Format(B(9, X), "###,###,###.00"), 14),
                                   TAB(87), RSet(Format(B(12, X), "###,###,###.00"), 14),
                                   TAB(101), RSet(Format(B(13, X), "###,###,###.00"), 14))
            End If
        Next X

        'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T(7), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T(8), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T(9), "###,###,###.00"), 14),
                           TAB(87), RSet(Format(T(12), "###,###,###.00"), 14),
                           TAB(101), RSet(Format(T(13), "###,###,###.00"), 14))

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Current Month")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(17), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(17), RSet(Format(T(11), "###,###,###.00"), 14))


        '======================================================================================
        '= PROCESS YTD CEDED
        '======================================================================================

        '==================================================================================
        '=Get ITDCED PRIOR Periods
        '==================================================================================
        Call d4tagSelect(f12, d4tag(f12, "K1"))
        rc = d4top(f12)
        ItdDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f12, ItdDirKey)

        Do Until rc = r4eof Or (ItdDirKey <> (Trim(f4str(Ic1p.CedMgaNmbr)) & Trim(f4str(Ic1p.CedTrtyNmbr))))
            GetItdCedVar()
            CatCode = Trim(f4str(Ic1p.CedCatCode))
            Wyear = Trim(f4str(Ic1p.CedYear))
            Wperiod = Trim(f4str(Ic1p.CedPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1
            If n <> 3 And n <> 8 And n <> 9 And n <> 12 And n <> 13 Then GoTo nextrec1

            For X = 1 To 24
                B1(n, X) = B1(n, X) + A(X)
                T3(n) = T3(n) + A(X)
            Next X

nextrec1:
            rc = d4skip(f12, 1)
        Loop


        '==================================================================================
        '=Get RPTCED YTD
        '==================================================================================
        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f6, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr))))

            If Trim(f4str(Rc1p.CedPeriod)) >= Wperiod1 Then GoTo nextrec2

            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            Wyear = Trim(f4str(Rc1p.CedYear))
            Wperiod = Trim(f4str(Rc1p.CedPeriod))
            A1 = MLobt

            Array.Clear(A, 0, A.Length)
            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1

            If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec2

            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec2
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X
nextrec2:
            rc = d4skip(f6, 1)
        Loop

        '======================================================================================
        '= Print YTD CEDED
        '======================================================================================
        t4 = 0
        t5 = 0
        RptPageHeading()

        prtobj.Print("    Year To Date", TAB(24), "Written", TAB(35), "Commission", TAB(57), "Net", TAB(69), "Earned")
        prtobj.Print()


        'Premium Commission Net Unearned
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                prtobj.Print(Dstr, TAB(17), RSet(Format(B(0, X), "###,###,###.00"), 14),
                                   TAB(31), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                   TAB(45), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                                   TAB(60), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15))
                t4 = t4 + B(2, X)
                t5 = t5 + (B(0, X) - B(2, X))
            End If
        Next X

        prtobj.Print()
        Dstr = "   Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(t4, "###,###,###.00"), 14),
                           TAB(45), RSet(Format(t5, "####,###,###.00"), 15),
                           TAB(60), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15))


        prtobj.Print()
        prtobj.Print()

        Dstr = "    Year To Date"
        If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
            prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(57), "LAE",
                               TAB(67), "O/S Loss", TAB(82), "O/S LAE",
                               TAB(94), "IBNR Loss", TAB(109), "IBNR LAE")
            prtobj.Print(TAB(27), "Paid", TAB(56), "Paid", TAB(67), "Incurred",
                         TAB(81), "Incurred", TAB(95), "Incurred", TAB(109), "Incurred")
        End If
        If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            prtobj.Print(Dstr, TAB(27), "Loss", TAB(34), "Sal & Subro", TAB(57), "LAE",
                               TAB(67), "O/S Loss", TAB(82), "O/S LAE")
            prtobj.Print(TAB(27), "Paid", TAB(56), "Paid", TAB(67), "Incurred",
                         TAB(81), "Incurred")
        End If
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
                    prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                       TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                       TAB(45), RSet(Format(B(7, X), "####,###,###.00"), 15),
                                       TAB(60), RSet(Format(B(8, X) - B1(8, X), "####,###,###.00"), 15),
                                       TAB(75), RSet(Format(B(9, X) - B1(9, X), "###,###,###.00"), 14),
                                       TAB(89), RSet(Format(B(12, X) - B1(12, X), "###,###,###.00"), 14),
                                       TAB(103), RSet(Format(B(13, X) - B1(13, X), "###,###,###.00"), 14))
                End If
                If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
                    prtobj.Print(Dstr, TAB(17), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                       TAB(31), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                       TAB(45), RSet(Format(B(7, X), "####,###,###.00"), 15),
                                       TAB(60), RSet(Format(B(8, X) - B1(8, X), "####,###,###.00"), 15),
                                       TAB(75), RSet(Format(B(9, X) - B1(9, X), "###,###,###.00"), 14))
                End If
            End If
        Next X

        'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"

        If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
            prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                               TAB(45), RSet(Format(T(7), "####,###,###.00"), 15),
                               TAB(60), RSet(Format(T(8) - T3(8), "####,###,###.00"), 15),
                               TAB(75), RSet(Format(T(9) - T3(9), "###,###,###.00"), 14),
                               TAB(89), RSet(Format(T(12) - T3(12), "###,###,###.00"), 14),
                               TAB(103), RSet(Format(T(13) - T3(13), "###,###,###.00"), 14))
        End If

        If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            prtobj.Print(Dstr, TAB(17), RSet(Format(T(5), "###,###,###.00"), 14),
                               TAB(31), RSet(Format(T(6), "###,###,###.00"), 14),
                               TAB(45), RSet(Format(T(7), "####,###,###.00"), 15),
                               TAB(60), RSet(Format(T(8) - T3(8), "####,###,###.00"), 15),
                               TAB(75), RSet(Format(T(9) - T3(9), "###,###,###.00"), 14))
        End If

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Year To Date")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(17), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(17), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(17), RSet(Format(T(11), "###,###,###.00"), 14))
        '======================================================================================
        '= PROCESS ITD CEDED
        '======================================================================================

        '==================================================================================
        '= Get ITDCED
        '==================================================================================
        Call d4tagSelect(f12, d4tag(f12, "K1"))
        rc = d4top(f12)
        ItdDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4seek(f12, ItdDirKey)


        Do Until rc = r4eof Or (ItdDirKey <> (Trim(f4str(Ic1p.CedMgaNmbr)) & Trim(f4str(Ic1p.CedTrtyNmbr))))
            GetItdCedVar()
            CatCode = Trim(f4str(Ic1p.CedCatCode))
            Wyear = Trim(f4str(Ic1p.CedYear))
            Wperiod = Trim(f4str(Ic1p.CedPeriod))
            A1 = MLobt

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X

            ' ACCUMULATE
            n = CDbl(CatCode)
            n = n - 1

            If n = 3 Or n = 8 Or n = 9 Or n = 12 Or n = 13 Then GoTo nextrec3

            If n = 1 Or n = 10 Or n = 11 Or n = 14 Or n = 15 Or n = 16 Then
                T(n) = T(n) + A1
                GoTo nextrec3
            End If

            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T(n) = T(n) + A(X)
            Next X

nextrec3:
            rc = d4skip(f12, 1)
        Loop

        For n = 0 To 13
            For X = 1 To 24
                B1(n, X) = 0
            Next X
            T3(n) = 0
        Next n

        '======================================================================================
        '= Print ITD CEDED
        '======================================================================================
        t4 = 0
        t5 = 0
        RptPageHeading()
        If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
            prtobj.Print("    Incept. To Date", TAB(25), "Written", TAB(37), "Commission", TAB(60), "Net", TAB(73), "Earned",
                                                TAB(83), "Loss Ratio", TAB(97), "Loss Ratio")
            prtobj.Print(TAB(85), "W/O IBNR", TAB(100), "W/ IBNR")
        End If
        If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            prtobj.Print("    Incept. To Date", TAB(25), "Written", TAB(37), "Commission", TAB(60), "Net", TAB(73), "Earned",
                                                TAB(83), "Loss Ratio", TAB(97), "Loss Ratio")
        End If
        prtobj.Print()

        'Premium Commission Net Eearned
        For X = 1 To 24
            If C(X) <> 0 Then
                N0 = B(0, X) + B1(3, X) - B(3, X)
                N2 = B1(5, X) + B(5, X) - B1(6, X) - B(6, X) + B1(7, X) + B(7, X) + B(8, X) - B1(8, X) + B(9, X) - B1(9, X)
                N3 = N2 + B(12, X) - B1(12, X) + B(13, X) - B1(13, X)

                If CDec(N0) = 0 And Math.Abs(N0) < 0.01 Then
                    N0 = 1 : N2 = 0 : N3 = 0
                End If
                CovHeading((X))
                If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
                    prtobj.Print(Dstr, TAB(18), RSet(Format(B(0, X), "####,###,###.00"), 14),
                                       TAB(33), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                       TAB(48), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                                       TAB(64), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15),
                                       TAB(79), RSet(Format(CInt((N2 / N0) * 10000) / 100, "###,###,###.00"), 14),
                                       TAB(93), RSet(Format(CInt((N3 / N0) * 10000) / 100, "###,###,###.00"), 14))
                End If
                If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
                    prtobj.Print(Dstr, TAB(18), RSet(Format(B(0, X), "####,###,###.00"), 14),
                                       TAB(33), RSet(Format(B(2, X), "###,###,###.00"), 14),
                                       TAB(48), RSet(Format(B(0, X) - B(2, X), "####,###,###.00"), 15),
                                       TAB(64), RSet(Format(B(0, X) + B1(3, X) - B(3, X), "####,###,###.00"), 15))
                End If
                t4 = t4 + B(2, X)
                t5 = t5 + (B(0, X) - B(2, X))
            End If
        Next X

        Dstr = "   Totals"
        N0 = T(0) + T3(3) - T(3)
        N2 = T3(5) + T(5) - T3(6) - T(6) + T3(7) + T(7) + T(8) - T3(8) + T(9) - T3(9)
        N3 = N2 + T(12) - T3(12) + T(13) - T3(13)
        If CDec(N0) = 0 And Math.Abs(N0) < 0.01 Then
            N0 = 1 : N2 = 0 : N3 = 0
        End If
        prtobj.Print()
        If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
            prtobj.Print(Dstr, TAB(18), RSet(Format(T(0), "####,###,###.00"), 14),
                               TAB(33), RSet(Format(t4, "###,###,###.00"), 14),
                               TAB(48), RSet(Format(t5, "####,###,###.00"), 15),
                               TAB(64), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15),
                               TAB(79), RSet(Format(CInt((N2 / N0) * 10000) / 100, "###,###,###.00"), 14),
                               TAB(93), RSet(Format(CInt((N3 / N0) * 10000) / 100, "###,###,###.00"), 14))
        End If
        If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            prtobj.Print(Dstr, TAB(18), RSet(Format(T(0), "####,###,###.00"), 14),
                               TAB(33), RSet(Format(t4, "###,###,###.00"), 14),
                               TAB(48), RSet(Format(t5, "####,###,###.00"), 15),
                               TAB(64), RSet(Format(T(0) + T3(3) - T(3), "####,###,###.00"), 15))
        End If
        prtobj.Print()
        prtobj.Print()

        Dstr = "    Incept. To Date"
        If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
            prtobj.Print(Dstr, TAB(28), "Loss", TAB(36), "Sal & Subro", TAB(60), "LAE",
                                       TAB(71), "O/S Loss", TAB(86), "O/S LAE",
                                       TAB(98), "IBNR Loss", TAB(113), "IBNR LAE")
            prtobj.Print(TAB(28), "Paid", TAB(59), "Paid", TAB(72), "Reserve",
                         TAB(86), "Reserve", TAB(100), "Reserve", TAB(114), "Reserve")
        End If
        If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            prtobj.Print(Dstr, TAB(28), "Loss", TAB(36), "Sal & Subro", TAB(60), "LAE",
                                       TAB(71), "O/S Loss", TAB(86), "O/S LAE")
            prtobj.Print(TAB(28), "Paid", TAB(59), "Paid", TAB(72), "Reserve", TAB(86), "Reserve")
        End If
        prtobj.Print()

        'Losses Paid 'Salvage and Sub 'Paid LAE 'O/S Loss Reserves 'O/S LAE Reserves 'IBNR Loss Reserves 'IBNR LAE Reserves
        For X = 1 To 24
            If C(X) <> 0 Then
                CovHeading((X))
                If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
                    prtobj.Print(Dstr, TAB(18), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                       TAB(33), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                       TAB(48), RSet(Format(B(7, X), "####,###,###.00"), 15),
                                       TAB(64), RSet(Format(B(8, X), "####,###,###.00"), 15),
                                       TAB(79), RSet(Format(B(9, X), "###,###,###.00"), 14),
                                       TAB(93), RSet(Format(B(12, X), "###,###,###.00"), 14),
                                       TAB(107), RSet(Format(B(13, X), "###,###,###.00"), 14))
                End If
                If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
                    prtobj.Print(Dstr, TAB(18), RSet(Format(B(5, X), "###,###,###.00"), 14),
                                       TAB(33), RSet(Format(B(6, X), "###,###,###.00"), 14),
                                       TAB(48), RSet(Format(B(7, X), "####,###,###.00"), 15),
                                       TAB(64), RSet(Format(B(8, X), "####,###,###.00"), 15),
                                       TAB(79), RSet(Format(B(9, X), "###,###,###.00"), 14))
                End If

            End If
        Next X

        'Total Losses
        prtobj.Print()
        prtobj.Print()
        Dstr = "   Totals"
        If RptType <> 7 And RptType <> 8 And RptType <> 9 And RptType <> 10 Then
            prtobj.Print(Dstr, TAB(18), RSet(Format(T(5), "###,###,###.00"), 14),
                               TAB(33), RSet(Format(T(6), "###,###,###.00"), 14),
                               TAB(47), RSet(Format(T(7), "####,###,###.00"), 15),
                               TAB(64), RSet(Format(T(8), "####,###,###.00"), 15),
                               TAB(79), RSet(Format(T(9), "###,###,###.00"), 14),
                               TAB(93), RSet(Format(T(12), "###,###,###.00"), 14),
                               TAB(107), RSet(Format(T(13), "###,###,###.00"), 14))
        End If
        If RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            prtobj.Print(Dstr, TAB(18), RSet(Format(T(5), "###,###,###.00"), 14),
                               TAB(33), RSet(Format(T(6), "###,###,###.00"), 14),
                               TAB(47), RSet(Format(T(7), "####,###,###.00"), 15),
                               TAB(64), RSet(Format(T(8), "####,###,###.00"), 15),
                               TAB(79), RSet(Format(T(9), "###,###,###.00"), 14))
        End If

        prtobj.Print()
        prtobj.Print()
        prtobj.Print("    Incept. To Date")
        prtobj.Print()
        prtobj.Print("Policy Fee", TAB(18), RSet(Format(T(1), "###,###,###.00"), 14))
        prtobj.Print("Front Fee", TAB(18), RSet(Format(T(10), "###,###,###.00"), 14))
        prtobj.Print("Premium Tax", TAB(18), RSet(Format(T(11), "###,###,###.00"), 14))



        '=====================================================================================
        '= Get Accident Year
        '=====================================================================================
        H = 1
        L0 = 45
        For n = 5 To 9
            For X = 1 To 24
                B(n, X) = 0
            Next X
        Next n

        Call d4tagSelect(f6, d4tag(f6, "K4"))
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        rc = d4top(f6)
        rc = d4seek(f6, RptDirKey)

        Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr))))

            CatCode = Trim(f4str(Rc1p.CedCatCode))
            If CatCode <= "05" Or CatCode >= "11" Then GoTo nextrec4
            J3str = Trim(f4str(Rc1p.CedPeriod))
            If J3str <> J2str Then GoTo nextrec4

            Kstr = Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedYear))

            If Kstr1 = "" Then Kstr1 = Kstr

            If Kstr <> Kstr1 Then
                If Trim(Mid(Kstr1, 6, 4)) <> "" Then
                    PrtAccYr()
                Else
                    Kstr1 = Kstr
                End If
            End If

            Wyear = Trim(f4str(Rc1p.CedYear))
            GetRptCedVar()

            For X = 1 To 24
                A(X) = MLobp(X)
            Next X
            n = Val(CatCode)
            n = n - 1

            'Accumulate
            For X = 1 To 24
                B(n, X) = B(n, X) + A(X)
                T1(n - 5) = T1(n - 5) + A(X)
            Next X

nextrec4:
            rc = d4skip(f6, 1)
        Loop

        If Trim(Mid(Kstr1, 6, 4)) <> "" Then PrtAccYr()

        'Print TOTALS
        If L0 >= 50 Then RptPageHeading()
        Dstr = "   Grand Totals"
        prtobj.Print(Dstr, TAB(17), RSet(Format(T2(0), "###,###,###.00"), 14),
                           TAB(31), RSet(Format(T2(1), "###,###,###.00"), 14),
                           TAB(45), RSet(Format(T2(2), "###,###,###.00"), 14),
                           TAB(59), RSet(Format(T2(3), "###,###,###.00"), 14),
                           TAB(73), RSet(Format(T2(4), "###,###,###.00"), 14))
        RptCmplt = True

    End Sub

    Sub RptPageHeading()
        Dim H1 As String
        Dim H2 As String
        Dim H3 As String
        Dim H4 As String
        Dim H5 As String

        'Heading
        Pcnt = Pcnt + 1
        If Not toScreen Then
            If Not BeginRun Then prtobj.NewPage()
        End If
        BeginRun = False

        If RptType = 1 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Direct")
        If RptType = 2 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Ceded")
        If RptType = 3 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Excess Cession 1")
        If RptType = 4 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Excess Cession 2")
        If RptType = 5 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Excess Cession 3")
        If RptType = 6 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Excess Cession 4")
        If RptType = 7 Then prtobj.Print(TAB(102), "REINSURER")
        If RptType = 8 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Rein Rpt Ceded")
        If RptType = 9 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Rein Rpt Excess Cession 1")
        If RptType = 10 Then prtobj.Print(TAB(102), "MGA BINDER" & " - Rein Rpt Excess Cession 2")

        If RptType = 1 Or RptType = 3 Or RptType = 4 Or RptType = 5 Then
            H1 = Trim(txPrmRptName)
            H2 = "Premium & Loss Report To"
            H3 = C0str
            H5 = "For Period Ending " & J4str
            prtobj.Print(TAB(40 - Len(H1) / 2), H1, TAB(102), "Page" & Str(Pcnt) & " " & Z1str)
            prtobj.Print(TAB(40 - Len(H2) / 2), H2, TAB(102), Astr & " - " & A4str)
            prtobj.Print(TAB(40 - Len(H3) / 2), H3, TAB(102), A2str)
            prtobj.Print(TAB(40 - Len(H5) / 2), H5)
            prtobj.Print()
        End If

        If RptType = 2 Or RptType = 6 Or RptType = 7 Or RptType = 8 Or RptType = 9 Or RptType = 10 Then
            H1 = Trim(txPrmRptName)
            H2 = "Premium & Loss Report To"
            H3 = C0str
            H4 = Trim(Format(f4double(TMp.TrtyCedPerc) * 100, "###.00")) & "% Quota Share Reinsurance Agreement No. " & Trim(f4str(TPp.PrmConNmbr))
            H5 = "For Period Ending " & J4str
            prtobj.Print(TAB(40 - Len(H1) / 2), H1, TAB(102), "Page" & Str(Pcnt) & " " & Z1str)
            prtobj.Print(TAB(40 - Len(H2) / 2), H2, TAB(102), Astr & " - " & A4str)
            prtobj.Print(TAB(40 - Len(H3) / 2), H3, TAB(102), A2str)
            prtobj.Print(TAB(40 - Len(H4) / 2), H4)
            prtobj.Print(TAB(40 - Len(H5) / 2), H5)
            prtobj.Print()
        End If

        If H = 1 Then
            prtobj.Print(TAB(27), "Loss", TAB(38), "Salvage", TAB(56), "LAE", TAB(65), "O/S Loss", TAB(80), "O/S LAE")
            prtobj.Print(TAB(27), "Paid", TAB(55), "Paid", TAB(66), "Reserve", TAB(80), "Reserve")
        End If
    
        L0 = 9
    End Sub

    Friend Sub CovHeading(ByRef X As Short)
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

    Public Sub RptEditLst()
        Dim D As Short
        Dim D1 As Short
        Dim D2 As Short
        Dim D3 As Short
        Dim d4 As Short
        Dim D5 As Short
        Dim W1 As Short

        Dim X As Short
        Dim E(11) As Short
        Dim C1 As Short
        Dim C2(3) As Double
        Dim C3(2) As Short
        Dim P1 As Short

        Dim A(24) As Double
        Dim A1 As Double
        Dim n As Double
        Dim A2 As Double
        Dim A3 As Double
        Dim A4 As Double
        Dim A5 As Double
        Dim A6 As Double

        Dim T(17, 5) As Double
        Dim T1(17, 2) As Double
        Dim T2(1, 5) As Double
        Dim T3(4, 5) As Double
        Dim t4(10, 3) As Double
        Dim t5(10, 3) As Double
        Dim t6 As Double
        Dim t7 As Double

        Dim Hstr As String
        Dim D1str As String = " "
        Dim D3str As String
        Dim C1str As String
        Dim C2str As String

        Dim pn(5) As Short

        'Initialize
        D = CShort(J2str)
        D5 = Parry(1)
        D3str = Format(Parry(1), "####")

        C1str = Trim(txPrmAgtBalNotDue)
        C2str = Trim(txPrmReiPayNotDue)

        A2 = f4double(TMp.TrtyFFperc)
        A3 = f4double(TMp.TrtyPremTaxPerc)
        A4 = f4double(TMp.DirCommPerc)
        A5 = f4double(TMp.CedCommPerc)
        A6 = f4double(TMp.TrtyCedPerc)

        Kstr1 = ""
        Pcnt = 0
        H = 0
        C1 = 0
        L0 = 0

        ' FETCH 1 DIRECT
        D1 = D - 5
        If D1 > 0 Then D1str = Format(D1, "00")
        If D1 < 1 Then D1str = "01"

        '==================================================================================
        '=Get RPTDIR Current Period
        '==================================================================================
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & D1str
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof Or (Mid(RptDirKey, 1, 5) <> Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))) Or (Trim(f4str(RDp.RptPeriod)) > J2str)
            GetRptDirVar()
            CatCode = Trim(f4str(RDp.RptCatCode))
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))
            A1 = MLobt

            W1 = Val(Mid(txPrmIncpDate, 5, 2))
            If W1 < 50 Then
                W1 = W1 + 2000
            Else
                W1 = W1 + 1900
            End If

            'ACCUMULATE 1 DIRECT
            D1 = Val(Wperiod)
            n = Val(CatCode)
            X = D - D1
            T(n, X) = T(n, X) + A1

            ' ERROR CHECK
            If n > 0 And n < 5 Then
                If Parry(1) <> Val(Wyear) Then E(5) = 1
            End If

            If (n > 5 And n < 11) Or n = 13 Or n = 14 Then
                If Val(Wyear) > Parry(1) Then E(6) = 1
                If Val(Wyear) < W1 Then E(7) = 1
            End If

            'ACCUMULATE 1 ACCIDENT YEAR
            If n < 6 Or n > 10 Then GoTo nextrec

            D2 = Year(Today)
            D3 = Val(Wyear)
            d4 = (10 - (D2 - D3))
            If d4 < 0 Then d4 = 0
            If D <> D1 Then
                If D - 1 <> D1 Then GoTo nextrec
            End If

            'ERROR CHECK
            If Val(Wyear) > Parry(1) Then E(6) = 1
            If Val(Wyear) < W1 Then E(7) = 1

            t4(d4, 0) = D3
            If n = 9 Then
                If D <> D1 Then t4(d4, 1) = t4(d4, 1) + A1
            End If

            If n = 9 Then
                If D = D1 Then t4(d4, 2) = t4(d4, 2) + A1
            End If

            If D <> D1 Then GoTo nextrec
            If n = 6 Then t4(d4, 3) = t4(d4, 3) + A1
            If n = 7 Then t4(d4, 3) = t4(d4, 3) - A1
            If n = 8 Then t4(d4, 3) = t4(d4, 3) + A1

nextrec:
            rc = d4skip(f5, 1)
        Loop

StartCed:
        C1 = C1 + 1
        If C1 = 1 Then OpenRptCed1()
        If C1 = 2 Then OpenRptCed2()
        If C1 = 3 Then OpenRptCed3()
        If C1 = 4 Then OpenRptCed4()
        If C1 = 5 Then OpenRptCed5()

        '==================================================================================
        '=Fetch Ceded
        '==================================================================================
        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & Trim(txtPeriod.Text)
        rc = d4seek(f6, RptCedKey)
        If RptCedKey <> Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod)) Then
            GoTo NextCed
        End If

        Do Until rc = r4eof Or (RptCedKey <> Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr)) & Trim(f4str(Rc1p.CedPeriod)))
            GetRptCedVar()
            CatCode = Trim(f4str(Rc1p.CedCatCode))
            Wyear = Trim(f4str(Rc1p.CedYear))
            Wperiod = Trim(f4str(Rc1p.CedPeriod))
            A1 = MLobt

            W1 = Val(Mid(txPrmIncpDate, 1, 2))

            'ACCUMULATE 3 CEDED
            D1 = Val(Wperiod)
            n = Val(CatCode)
            X = D - D1
            T1(n, X) = T1(n, X) + A1

            'CHECK FOR CEDED POL FEES, COLL PREM, COLL FEE PRIOR PERIODS
            If n = 2 Then
                If A1 <> 0 Then C3(0) = 1
            End If

            If n = 15 Then
                If A1 <> 0 Then C3(1) = 1
            End If

            If n = 16 Then
                If A1 <> 0 Then C3(2) = 1
            End If

            'ERROR CHECK
            If n > 0 And n < 5 Then
                If Parry(1) <> Val(Wyear) Then E(8) = 1
            End If

            If (n > 5 And n < 11) Or n = 13 Or n = 14 Then
                If Val(Wyear) > Parry(1) Then E(9) = 1
                If Val(Wyear) < W1 Then E(10) = 1
            End If

            'ACCUMULATE 1 ACCIDENT YEAR
            If n < 6 Or n > 10 Then GoTo nextrec1

            D2 = Year(Today)
            D3 = Val(Wyear)
            d4 = (10 - (D2 - D3))
            If d4 < 0 Then d4 = 0
            If D <> D1 Then
                If D - 1 <> D1 Then GoTo nextrec1
            End If

            'ERROR CHECK
            If Val(Wyear) > Parry(1) Then E(9) = 1
            If Val(Wyear) < W1 Then E(10) = 1


            t5(d4, 0) = D3
            If n = 9 Then
                If D <> D1 Then t5(d4, 1) = t5(d4, 1) + A1
            End If

            If n = 9 Then
                If D = D1 Then t5(d4, 2) = t5(d4, 2) + A1
            End If

            If D <> D1 Then GoTo nextrec1
            If n = 6 Then t5(d4, 3) = t5(d4, 3) + A1
            If n = 7 Then t5(d4, 3) = t5(d4, 3) - A1
            If n = 8 Then t5(d4, 3) = t5(d4, 3) + A1

nextrec1:
            rc = d4skip(f6, 1)
        Loop

NextCed:
        If C1 = 1 Then ClsRptCed1() : f6 = 0
        If C1 = 2 Then ClsRptCed2() : f6 = 0
        If C1 = 3 Then ClsRptCed3() : f6 = 0
        If C1 = 4 Then ClsRptCed4() : f6 = 0
        If C1 = 5 Then ClsRptCed5() : f6 = 0
        If C1 > 0 And C1 < 5 Then GoTo StartCed

        'PRINT

        'HEADING
        P1 = P1 + 1
        If Not toScreen Then
            If Not BeginRun Then prtobj.NewPage()
        End If

        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("MGA Edit Report - Direct", TAB(40), Astr & "  " & A1str, TAB(122), "Page " & Str(P1))

        D1 = D - 5
        If D1 < 1 Then D1 = 1
        D1str = Format(D1, "00")
        prtobj.Print(Z1str, TAB(41), A4str & "  " & Trim(A2str) & " period " & D1str & " thru " & J2str)
        prtobj.Print()

        ' SUMMARY PAGE
        pn(0) = D
        For X = 1 To 5
            pn(X) = D - X
            If pn(X) < 0 Then pn(X) = 0
        Next

        Hstr = "Period "
        prtobj.Print("Line", TAB(20), Hstr & Format(pn(0), "00"), TAB(33), "Q/S %", TAB(49), "Ceded",
                             TAB(60), Hstr & Format(pn(1), "00"),
                             TAB(75), Hstr & Format(pn(2), "00"),
                             TAB(90), Hstr & Format(pn(3), "00"),
                             TAB(105), Hstr & Format(pn(4), "00"),
                             TAB(120), Hstr & Format(pn(5), "00"))
        prtobj.Print()
        L0 = 8

        'Print Detail
        Dstr = "Premium"
        X = 1
        PrtEdtLn(X, T, T1, E)

        Dstr = "Policy Fee"
        X = 2
        PrtEdtLn(X, T, T1, E)

        prtobj.Print()


        Dstr = "Collected Prem"
        X = 15
        PrtEdtLn(X, T, T1, E)

        Dstr = "Collected Pfee"
        X = 16
        PrtEdtLn(X, T, T1, E)

        Dstr = "UncollectedBal"
        X = 17
        PrtEdtLn(X, T, T1, E)

        prtobj.Print()
        If X = 17 Then
            If C1str <> " " Or C2str <> " " Then
                If T(X, 0) = 0 Then E(11) = 1
            End If
        End If

        Dstr = "Commission"
        X = 3
        PrtEdtLn(X, T, T1, E)

        Dstr = "Unearned Prem"
        X = 4
        PrtEdtLn(X, T, T1, E)
        prtobj.Print()

        Dstr = "Paid Losses"
        X = 6
        PrtEdtLn(X, T, T1, E)

        Dstr = "Subro/Salvage"
        X = 7
        PrtEdtLn(X, T, T1, E)

        Dstr = "Paid LAE"
        X = 8
        PrtEdtLn(X, T, T1, E)
        prtobj.Print()

        Dstr = "Loss Res"
        X = 9
        PrtEdtLn(X, T, T1, E)

        Dstr = "LAE Res"
        X = 10
        PrtEdtLn(X, T, T1, E)

        Dstr = "IBNR Loss Res"
        X = 13
        PrtEdtLn(X, T, T1, E)

        Dstr = "IBNR LAE Res"
        X = 14
        PrtEdtLn(X, T, T1, E)
        prtobj.Print()

        Dstr = "Front Fee"
        X = 11
        PrtEdtLn(X, T, T1, E)

        Dstr = "Premium Tax"
        X = 12
        PrtEdtLn(X, T, T1, E)
        prtobj.Print()

        'COMPUTE %
        For X = 0 To 5
            If T(1, X) + T(2, X) <> 0 Then
                T3(0, X) = CInt((T(11, X) / (T(1, X) + T(2, X))) * 10000) / 100
            End If

            If T(15, X) + T(16, X) <> 0 Then
                T3(3, X) = CInt((T(11, X) / (T(15, X) + T(16, X))) * 10000) / 100
            End If

            If T(1, X) <> 0 Then
                T3(2, X) = CInt((T(3, X) / T(1, X)) * 10000) / 100
            End If

            If T(15, X) <> 0 Then
                T3(4, X) = CInt((T(3, X) / T(15, X)) * 10000) / 100
            End If

            If T(1, X) + T(2, X) <> 0 Then
                T3(1, X) = CInt((T(12, X) / (T(1, X) + T(2, X))) * 10000) / 100
            End If
        Next X

        'ERROR CHECK FRONT% ON WRITTEN OR COLLECTED
        If T(1, 0) <> 0 Or T(2, 0) <> 0 Or T(15, 0) <> 0 Or T(16, 0) = 0 Then
            For X = 0 To 5
                If T3(0, X) = A2 * 100 Then C2(2) = 1
            Next X
            If C2(2) <> 1 Then
                For X = 0 To 5
                    If T3(3, X) = A2 * 100 Then C2(3) = 1
                Next X
            End If
            If C2(2) <> 1 And C2(3) <> 0 Then
                For X = 0 To 5
                    T3(0, X) = T3(3, X)
                Next X
            End If

            If T3(0, 0) <> 0 Then
                If T3(0, 0) <> (A2 * 100) Then E(2) = 1
            End If

            'ERROR CHECK COMM% ON WRITTEN OR COLLECTED
            C2(2) = 0
            C2(3) = 0
            For X = 0 To 5
                If T3(2, X) = A4 * 100 Then C2(2) = 1
            Next X
            If C2(2) <> 1 Then
                For X = 0 To 5
                    If T3(4, X) = A4 * 100 Then C2(3) = 1
                Next X
            End If
            If C2(2) <> 1 And C2(3) <> 0 Then
                For X = 0 To 5
                    T3(2, X) = T3(4, X)
                Next X
            End If
            If T3(2, 0) <> 0 Then
                If T3(2, 0) <> (A4 * 100) Then E(4) = 1
            End If
        End If

        'ERROR CHECK PREM TAX%
        If T(1, 0) + T(2, 0) <> 0 Then
            If Trim(Str(T3(1, 0))) <> Trim(Str(A3 * 100)) Then E(3) = 1
        End If

        'PRINT %
        Dstr = "Front Fee %"
        prtobj.Print(Dstr, TAB(15), RSet(Format(T3(0, 0), "###,###,###.00"), 14),
                           TAB(32), RSet(Format(A2 * 100, "###.00"), 6),
                           TAB(55), RSet(Format(T3(0, 1), "###,###,###.00"), 14),
                           TAB(70), RSet(Format(T3(0, 2), "###,###,###.00"), 14),
                           TAB(85), RSet(Format(T3(0, 3), "###,###,###.00"), 14),
                           TAB(100), RSet(Format(T3(0, 4), "###,###,###.00"), 14),
                           TAB(115), RSet(Format(T3(0, 5), "###,###,###.00"), 14))

        Dstr = "Premium Tax %"
        prtobj.Print(Dstr, TAB(15), RSet(Format(T3(1, 0), "###,###,###.00"), 14),
                           TAB(32), RSet(Format(A3 * 100, "###.00"), 6),
                           TAB(55), RSet(Format(T3(1, 1), "###,###,###.00"), 14),
                           TAB(70), RSet(Format(T3(1, 2), "###,###,###.00"), 14),
                           TAB(85), RSet(Format(T3(1, 3), "###,###,###.00"), 14),
                           TAB(100), RSet(Format(T3(1, 4), "###,###,###.00"), 14),
                           TAB(115), RSet(Format(T3(1, 5), "###,###,###.00"), 14))

        Dstr = "Commission %"
        prtobj.Print(Dstr, TAB(15), RSet(Format(T3(2, 0), "###,###,###.00"), 14),
                           TAB(32), RSet(Format(A4 * 100, "###.00"), 6),
                           TAB(55), RSet(Format(T3(2, 1), "###,###,###.00"), 14),
                           TAB(70), RSet(Format(T3(2, 2), "###,###,###.00"), 14),
                           TAB(85), RSet(Format(T3(2, 3), "###,###,###.00"), 14),
                           TAB(100), RSet(Format(T3(2, 4), "###,###,###.00"), 14),
                           TAB(115), RSet(Format(T3(2, 5), "###,###,###.00"), 14))

        Dstr = "Ceded Comm %"
        prtobj.Print(Dstr, TAB(32), RSet(Format(A5 * 100, "###.00"), 6))

        Dstr = "Ceding %"
        prtobj.Print(Dstr, TAB(32), RSet(Format(A6 * 100, "###.00"), 6))


        'PRINT ACCIDENT YEAR
        prtobj.Print()
        prtobj.Print("A/Y", TAB(18), "Paid Losses", TAB(33), "Q/S %", TAB(49), "Ceded",
                            TAB(57), "Loss Reserve", TAB(79), "Q/S %", TAB(94), "Ceded")
        prtobj.Print()

        Dim v, v1 As Double
        For X = 0 To 10
            If t4(X, 0) <> 0 Or t5(X, 0) <> 0 Then
                If X = 0 Then E(0) = 1
                t6 = t4(X, 3)
                t7 = t5(X, 3)
                If t6 = 0 Then v = 0
                If t6 <> 0 Then v = CInt((t7 / t6) * 10000) / 100
                If t4(X, 2) = 0 Then v1 = 0
                If t4(X, 2) <> 0 Then v1 = CInt((t5(X, 2) / t4(X, 2)) * 10000) / 100
                prtobj.Print(Format(t4(X, 0), "####"),
                             TAB(15), RSet(Format(t6, "###,###,###.00"), 14),
                             TAB(32), RSet(Format(v, "###.00"), 6),
                             TAB(40), RSet(Format(t7, "###,###,###.00"), 14),
                             TAB(55), RSet(Format(t4(X, 2), "###,###,###.00"), 14),
                             TAB(70), RSet(Format(v1, "###,###,###.00"), 14),
                             TAB(85), RSet(Format(t5(X, 2), "###,###,###.00"), 14))
            End If
        Next X

        'PRINT EDIT ERRORS
        prtobj.Print()
        If E(0) <> 0 Then prtobj.Print("*** Loss Activity Exceeds 10 years")
        If E(1) <> 0 Then prtobj.Print("*** Quota Share % Out of Balance")
        If E(2) <> 0 Then prtobj.Print("*** Front Fee % Out of Balance")
        If E(3) <> 0 Then prtobj.Print("*** Premium Tax % Out of Balance")
        If E(4) <> 0 Then prtobj.Print("*** Commission % Out of Balance")
        If E(5) <> 0 Then prtobj.Print("*** DIRECT Accounting Year <> Current Year")
        If E(6) <> 0 Then prtobj.Print("*** DIRECT Accident Year > Current Year")
        If E(7) <> 0 Then prtobj.Print("*** DIRECT Accident Year < Treaty Year")
        If E(8) <> 0 Then prtobj.Print("*** CEDED Accounting Year <> Current Year")
        If E(9) <> 0 Then prtobj.Print("*** CEDED Accident Year > Current Year")
        If E(10) <> 0 Then prtobj.Print("*** CEDED Accident Year < Treaty Year")
        If E(11) <> 0 Then prtobj.Print("*** Uncollected Bal Not Entered")

        'PRINT AGENT BALANCE
        If T(15, 0) <> 0 Then C2(0) = C2(0) + T(15, 0)
        If T(15, 0) = 0 Then C2(0) = C2(0) + T(1, 0)
        C2(0) = C2(0) - T(3, 0) - T(6, 0) + T(7, 0) - T(8, 0) + T(11, 0) + T(12, 0)
        prtobj.Print()
        prtobj.Print("Agt Due", TAB(15), RSet(Format(C2(0), "###,###,###.00"), 14))

        'PRINT REIN BALANCE
        If T(15, 0) = 0 Then C2(1) = C2(1) + T1(1, 0)
        If T1(15, 0) <> 0 And T(15, 0) <> 0 Then C2(1) = C2(1) + T1(15, 0)
        If T(15, 0) <> 0 And T1(15, 0) = 0 Then
            C2(1) = C2(1) + Math.Round(T(15, 0) * A6)
        End If
        C2(1) = C2(1) - T1(3, 0) - T1(6, 0) + T1(7, 0) - T1(8, 0) + T1(11, 0) + T1(12, 0)
        prtobj.Print("Rein Due", TAB(15), RSet(Format(C2(1), "###,###,###.00"), 14))

        'PRINT BAL DUE
        prtobj.Print(TAB(15), "--------------")
        prtobj.Print("Bal Due", TAB(15), RSet(Format(C2(0) - C2(1), "###,###,###.00"), 14))

    End Sub

    Public Sub PrtEdtLn(ByRef Y As Short, ByRef L As Object, ByRef L1 As Object, ByRef L2 As Object)

        If L(Y, 0) <> 0 Then
            L1(Y, 1) = CInt((L1(Y, 0) / L(Y, 0)) * 10000) / 100
            If Y <> 2 And Y <> 11 And Y <> 12 And Y <> 15 And Y <> 16 Then
                If Trim(Str(L1(Y, 1))) <> Trim(Str(f4double(TMp.TrtyCedPerc) * 100)) Then L2(1) = 1
            End If
        End If

        If L(Y, 0) = 0 Then L1(Y, 1) = 0
        If Y <> 11 And Y <> 12 Then
            prtobj.Print(Dstr, TAB(15), RSet(Format(L(Y, 0), "###,###,###.00"), 14),
                               TAB(32), RSet(Format(L1(Y, 1), "###.00"), 6),
                               TAB(40), RSet(Format(L1(Y, 0), "###,###,###.00"), 14),
                               TAB(55), RSet(Format(L(Y, 1), "###,###,###.00"), 14),
                               TAB(70), RSet(Format(L(Y, 2), "###,###,###.00"), 14),
                               TAB(85), RSet(Format(L(Y, 3), "###,###,###.00"), 14),
                               TAB(100), RSet(Format(L(Y, 4), "###,###,###.00"), 14),
                               TAB(115), RSet(Format(L(Y, 5), "###,###,###.00"), 14))
        Else
            prtobj.Print(Dstr, TAB(15), RSet(Format(L(Y, 0), "###,###,###.00"), 14),
                               TAB(55), RSet(Format(L(Y, 1), "###,###,###.00"), 14),
                               TAB(70), RSet(Format(L(Y, 2), "###,###,###.00"), 14),
                               TAB(85), RSet(Format(L(Y, 3), "###,###,###.00"), 14),
                               TAB(100), RSet(Format(L(Y, 4), "###,###,###.00"), 14),
                               TAB(115), RSet(Format(L(Y, 5), "###,###,###.00"), 14))
        End If

    End Sub
End Class