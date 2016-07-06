Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmRptYtdMgaBrkDown
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
    Dim Wyear As String
    Dim Wperiod As String
    Dim Wperiod1 As String

    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim Ystr As String
    Dim J2str As String
    Dim Astr As String
    Dim A1str As String
    Dim A2str As String
    Dim A4str As String
    Dim J4str As String

    Dim Pcnt As Short
    Dim L0 As Short
    Dim n As Short
    Dim X As Short
    Dim C1 As Short
    Dim A1 As Double
    Dim T(11) As Double
    Dim T1(11) As Double
    Dim T2(11) As Double
    Dim Nstr1(11) As String
    Dim Skey As String
    Dim ChkTotal As Double
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

        rc = d4bottom(f1)
        rc = d4unlock(f1)
    End Sub


    Private Sub cmdPrt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdPrt.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        If Trim(txtPeriod.Text) = "" Then Exit Sub


        'Global Initial
        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next
        J2str = Trim(txtPeriod.Text)
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

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 8
        prtobj.FontBold = True
        prtobj.Orientation = 2
        BeginRun = True

        OpenRptDir()
        OpenItdDir()
        ProcessRpt()

        prtobj.EndDoc()
        prtobj.Orientation = 1
    End Sub

    Private Sub cboMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboMga.SelectedIndexChanged
        Dim M As String
        Dim M1 As Integer

        If ByPassCbo Then Exit Sub
        txtMgaNmbr.Text = Mid(Trim(cboMga.Text), 1, 3)
        M = Mid(Trim(cboMga.Text), 1, 3)
        M1 = cboMga.SelectedIndex
        txtMgaNmbr.Text = M
        cboMga.SelectedIndex = M1
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
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
                txtPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtPeriod.Focus()

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

        MgaKey = s
        RdMgaMstRec()

        If s = "000" Then Tobj.Text = ""

        If s = "999" Then Fstat = 0

        If Fstat <> 0 Then
            If Tobj.Text <> "" Then MsgBox("MGA Master Record Does Not Exist.")
            Exit Sub
        End If
    End Sub

    Private Sub frmRptYtdMgaBrkDown_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()

        'Load Mga Combo Box
        LoadCboMga()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        ByPassCbo = False
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
            Case Keys.Up
                cmdPrt.Focus()
            Case Keys.Down
                cmdPrt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cmdPrt.Focus()
        If KeyCode = 27 Or KeyCode = 110 Then cmdPrt.Focus()
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

    Sub ProcessRpt()
        Dim X As Integer

        'Initialize
        For X = 0 To 11
            T(X) = 0 : T1(X) = 0 : T2(X) = 0
        Next X

        Skey = "" : Pcnt = 0 : L0 = 0

        'Read Treaty Master
        Call d4tagSelect(f3, d4tag(f3, "K1"))
        rc = d4top(f3)

        'Start Processing  (YTD Data)
        Do Until rc = r4eof
            If BeginRun Then Skey = f4str(TMp.TrtyMgaNmbr)

            If txtMgaNmbr.Text <> "999" Then
                If f4str(TMp.TrtyMgaNmbr) <> txtMgaNmbr.Text Then GoTo ByPassRec
            End If

            GetTrtyMstVar()
            Astr = txTrtyMgaNmbr
            A2str = txTrtyDesc
            A4str = txTrtyNmbr

            MgaKey = Trim(txTrtyMgaNmbr)
            RdMgaMstRec()
            GetMgaMstVar()
            A1str = txMgaName

            'Get ITDDIR PRIOR Periods
            Call d4tagSelect(f11, d4tag(f11, "K1"))
            rc = d4top(f11)
            ItdDirKey = Astr & A4str
            rc = d4seek(f11, ItdDirKey)

            Do Until rc = r4eof Or (ItdDirKey <> (Trim(f4str(IDp.ItdMgaNmbr)) & Trim(f4str(IDp.ItdTrtyNmbr))))

                GetItdDirVar()
                CatCode = Trim(f4str(IDp.ItdCatCode))
                A1 = MLobt

                'Accumulate
                n = CShort(CatCode)
                n = n - 1
                If n <> 3 And n <> 8 And n <> 9 Then GoTo nextrec

                If n = 3 Then T(2) = T(2) + A1 'Earned Premium
                If n = 8 Then T(4) = T(4) - A1 'Loss Reserves
                If n = 9 Then T(5) = T(5) - A1 'LAE Reserves

                If n = 3 Then T(8) = T(8) + A1 'Retained Net Earned Premium
                If n = 8 Then T(10) = T(10) - A1 'Retained Net Loss Reserves
                If n = 9 Then T(11) = T(11) - A1 'Retained Net LAE Reserves

nextrec:
                rc = d4skip(f11, 1)
            Loop

            'Get RPTDIR YTD numbers
            Call d4tagSelect(f5, d4tag(f5, "K1"))
            rc = d4top(f5)
            RptDirKey = Astr & A4str
            rc = d4seek(f5, RptDirKey)

            Do Until rc = r4eof Or (RptDirKey <> (Trim(f4str(RDp.RptMgaNmbr)) & Trim(f4str(RDp.RptTrtyNmbr))))

                If Trim(f4str(RDp.RptPeriod)) > Wperiod1 Then GoTo nextrec1

                If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                    If Trim(f4str(RDp.RptPeriod)) <> Wperiod1 Then GoTo nextrec1
                End If

                GetRptDirVar()
                CatCode = Trim(f4str(RDp.RptCatCode))
                Wyear = Trim(f4str(RDp.RptYear))
                Wperiod = Trim(f4str(RDp.RptPeriod))
                A1 = MLobt

                'Accumulate
                n = CShort(CatCode)
                n = n - 1

                If n = 12 Or n = 13 Then GoTo nextrec1 'Bypass IBNR

                If n = 3 Or n = 8 Or n = 9 Then
                    If Trim(f4str(RDp.RptPeriod)) <> Wperiod1 Then GoTo nextrec1
                End If

                If n = 0 Then T(1) = T(1) + A1 'Written Premium
                If n = 0 Then T(2) = T(2) + A1 'Earned Premium Calc
                If n = 3 Then T(2) = T(2) - A1 'Earned Premium Calc
                If n = 1 Then T(3) = T(3) + A1 'Policy Fee
                If n = 5 Then T(4) = T(4) + A1 'Incurred Losses + Paid Losses
                If n = 6 Then T(4) = T(4) - A1 'Incurred Losses - Salvage
                If n = 7 Then T(5) = T(5) + A1 'Incurred LAE + Paid LAE
                If n = 8 Then T(4) = T(4) + A1 'Incurred Losses + Loss Reserves
                If n = 9 Then T(5) = T(5) + A1 'Incurred LAE + LAE Reserves
                If n = 10 Then T(6) = T(6) + A1 'Front Fee

                If n = 0 Then T(7) = T(7) + A1 'Retained Net Written Premium
                If n = 0 Then T(8) = T(8) + A1 'Retained Net Earned Premium Calc
                If n = 3 Then T(8) = T(8) - A1 'Retained Net Earned Premium Calc
                If n = 1 Then T(9) = T(9) + A1 'Retained Net Policy Fee
                If n = 5 Then T(10) = T(10) + A1 'Retained Net Incurred Losses + Paid Losses
                If n = 6 Then T(10) = T(10) - A1 'Retained Net Incurred Losses - Salvage
                If n = 7 Then T(11) = T(11) + A1 'Retained Net Incurred LAE + Paid LAE
                If n = 8 Then T(10) = T(10) + A1 'Retained Net Incurred Losses + Loss Reserves
                If n = 9 Then T(11) = T(11) + A1 'Retained Net Incurred LAE + LAE Reserves

nextrec1:
                rc = d4skip(f5, 1)
            Loop

StartCed:
            C1 = C1 + 1
            If C1 = 1 Then
                OpenRptCed1()
                OpenItdCed1()
            End If

            If C1 = 2 Then
                OpenRptCed2()
                OpenItdCed2()
            End If

            If C1 = 3 Then
                OpenRptCed3()
                OpenItdCed3()
            End If

            If C1 = 4 Then
                OpenRptCed4()
                OpenItdCed4()
            End If

            If C1 = 5 Then
                OpenRptCed5()
                OpenItdCed5()
            End If

            'Get ITDCed PRIOR Periods
            Call d4tagSelect(f12, d4tag(f12, "K1"))
            rc = d4top(f12)
            ItdCedKey = Astr & A4str
            rc = d4seek(f12, ItdCedKey)

            Do Until rc = r4eof Or (ItdCedKey <> (Trim(f4str(Ic1p.CedMgaNmbr)) & Trim(f4str(Ic1p.CedTrtyNmbr))))
                GetItdCedVar()
                CatCode = Trim(f4str(Ic1p.CedCatCode))
                A1 = MLobt

                'Accumulate
                n = CShort(CatCode)
                n = n - 1
                If n <> 3 And n <> 8 And n <> 9 Then GoTo nextrec2

                If n = 3 Then T(8) = T(8) - A1 'Ceded Retained Net Earned Premium
                If n = 8 Then T(10) = T(10) + A1 'Ceded Retained Net Loss Reserves
                If n = 9 Then T(11) = T(11) + A1 'Ceded Retained Net LAE Reserves

nextrec2:
                rc = d4skip(f12, 1)
            Loop

            'Get RPTCED YTD numbers
            Call d4tagSelect(f6, d4tag(f6, "K1"))
            rc = d4top(f6)
            RptCedKey = Astr & A4str
            rc = d4seek(f6, RptCedKey)

            Do Until rc = r4eof Or (RptCedKey <> (Trim(f4str(Rc1p.CedMgaNmbr)) & Trim(f4str(Rc1p.CedTrtyNmbr))))

                If Trim(f4str(Rc1p.CedPeriod)) > Wperiod1 Then GoTo nextrec3

                If Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Then
                    If Trim(f4str(Rc1p.CedPeriod)) <> Wperiod1 Then GoTo nextrec3
                End If

                GetRptCedVar()
                CatCode = Trim(f4str(Rc1p.CedCatCode))
                Wyear = Trim(f4str(Rc1p.CedYear))
                Wperiod = Trim(f4str(Rc1p.CedPeriod))
                A1 = MLobt

                'Accumulate
                n = CShort(CatCode)
                n = n - 1

                If n = 12 Or n = 13 Then GoTo nextrec3 'Bypass IBNR

                If n = 3 Or n = 8 Or n = 9 Then
                    If Trim(f4str(Rc1p.CedPeriod)) <> Wperiod1 Then GoTo nextrec3
                End If

                If n = 0 Then T(7) = T(7) - A1 'Retained Net Written Premium
                If n = 0 Then T(8) = T(8) - A1 'Retained Net Earned Premium Calc
                If n = 3 Then T(8) = T(8) + A1 'Retained Net Earned Premium Calc
                If n = 1 Then T(9) = T(9) - A1 'Retained Net Policy Fee
                If n = 5 Then T(10) = T(10) - A1 'Retained Net Incurred Losses + Paid Losses
                If n = 6 Then T(10) = T(10) + A1 'Retained Net Incurred Losses - Salvage
                If n = 7 Then T(11) = T(11) - A1 'Retained Net Incurred LAE + Paid LAE
                If n = 8 Then T(10) = T(10) - A1 'Retained Net Incurred Losses + Loss Reserves
                If n = 9 Then T(11) = T(11) - A1 'Retained Net Incurred LAE + LAE Reserves

nextrec3:
                rc = d4skip(f6, 1)
            Loop

NextCed:
            If C1 = 1 Then
                ClsRptCed1() : f6 = 0
                ClsItdCed1() : f12 = 0
            End If

            If C1 = 2 Then
                ClsRptCed2() : f6 = 0
                ClsItdCed2() : f12 = 0
            End If

            If C1 = 3 Then
                ClsRptCed3() : f6 = 0
                ClsItdCed3() : f12 = 0
            End If

            If C1 = 4 Then
                ClsRptCed4() : f6 = 0
                ClsItdCed4() : f12 = 0
            End If

            If C1 = 5 Then
                ClsRptCed5() : f6 = 0
                ClsItdCed5() : f12 = 0
            End If

            If C1 > 0 And C1 < 5 Then GoTo StartCed

            PrtDetailRec()

ByPassRec:

            rc = d4skip(f3, 1)
        Loop

        'Final MGA Total
        ChkTotal = 0
        For X = 0 To 11
            ChkTotal = ChkTotal + T1(X)
        Next

        If ChkTotal = 0 Then GoTo SkipTotal

        'Written Prem 'Earned Prem 'Policy Fee 'Incurred Losses 'Incurred LAE 'Front Fee 'Net Written Prem 'Net Earned Prem 'Net Incurred Losses 'Net Incurred LAE
        Nstr1(1) = RSet(Format(T1(1), "######,###.00"), 13)
        Nstr1(2) = RSet(Format(T1(2), "######,###.00"), 13)
        Nstr1(3) = RSet(Format(T1(3), "######,###.00"), 12)
        Nstr1(4) = RSet(Format(T1(4), "######,###.00"), 13)
        Nstr1(5) = RSet(Format(T1(5), "######,###.00"), 12)
        Nstr1(6) = RSet(Format(T1(6), "######,###.00"), 11)
        Nstr1(7) = RSet(Format(T1(7), "######,###.00"), 12)
        Nstr1(8) = RSet(Format(T1(8), "######,###.00"), 12)
        Nstr1(10) = RSet(Format(T1(10), "######,###.00"), 12)
        Nstr1(11) = RSet(Format(T1(11), "######,###.00"), 11)

        prtobj.Print()
        prtobj.Print("MGA " & Skey & " Total", TAB(33), Nstr1(1), TAB(48), Nstr1(2), TAB(61), Nstr1(3),
                                               TAB(74), Nstr1(4), TAB(88), Nstr1(5), TAB(100), Nstr1(6), TAB(111), Nstr1(7),
                                               TAB(123), Nstr1(8), TAB(135), Nstr1(10), TAB(147), Nstr1(11))


        For X = 0 To 11
            T2(X) = T2(X) + T1(X)
            T1(X) = 0
        Next X

SkipTotal:

        'Written Prem 'Earned Prem 'Policy Fee 'Incurred Losses 'Incurred LAE 'Front Fee 'Net Written Prem 'Net Earned Prem 'Net Incurred Losses 'Net Incurred LAE
        Nstr1(1) = RSet(Format(T2(1), "######,###.00"), 14)
        Nstr1(2) = RSet(Format(T2(2), "######,###.00"), 14)
        Nstr1(3) = RSet(Format(T2(3), "######,###.00"), 13)
        Nstr1(4) = RSet(Format(T2(4), "######,###.00"), 14)
        Nstr1(5) = RSet(Format(T2(5), "######,###.00"), 13)
        Nstr1(6) = RSet(Format(T2(6), "######,###.00"), 12)
        Nstr1(7) = RSet(Format(T2(7), "######,###.00"), 12)
        Nstr1(8) = RSet(Format(T2(8), "######,###.00"), 12)
        Nstr1(10) = RSet(Format(T2(10), "######,###.00"), 12)
        Nstr1(11) = RSet(Format(T2(11), "######,###.00"), 11)


        prtobj.Print()
        prtobj.Print("Run Total", TAB(32), Nstr1(1), TAB(60), Nstr1(3),
                                  TAB(87), Nstr1(5), TAB(111), Nstr1(7),
                                  TAB(135), Nstr1(10))

        prtobj.Print(TAB(47), Nstr1(2), TAB(73), Nstr1(4),
                     TAB(99), Nstr1(6), TAB(123), Nstr1(8),
                     TAB(147), Nstr1(11))


    End Sub

    Sub PrtDetailRec()
        Dim X As Integer

        ChkTotal = 0
        For X = 0 To 11
            ChkTotal = ChkTotal + T(X)
        Next

        If ChkTotal = 0 Then GoTo SkipReport

        'Heading
        If Pcnt = 0 Or L0 > 55 Then
            If Not BeginRun Then prtobj.NewPage()
            Pcnt = Pcnt + 1
            prtobj.Print()
            prtobj.Print(C0str)
            prtobj.Print("YTD Net/Retained MGA Report Period 01 thru " & J2str, TAB(146), "Page " & Str(Pcnt))
            prtobj.Print(Z1str)

            prtobj.Print()
            prtobj.Print("MGA/Trty", TAB(39), "Written", TAB(55), "Earned", TAB(67), "Policy", TAB(78), "YTD Incur",
                                     TAB(91), "YTD Incur", TAB(106), "Front", TAB(112), "Net Written", TAB(125), "Net Earned",
                                     TAB(138), "Net Incur", TAB(149), "Net Incur")
            prtobj.Print(TAB(39), "Premium", TAB(54), "Premium", TAB(70), "Fee", TAB(81), "Losses",
                         TAB(97), "Lae", TAB(108), "Fee", TAB(116), "Premium", TAB(128), "Premium",
                         TAB(142), "Losses", TAB(155), "LAE")
            prtobj.Print()
            L0 = 10
        End If

        'Print Detail
        If BeginRun Then
            prtobj.Print(Astr, TAB(5), A1str)
            BeginRun = False
        End If

        'Break on MGA number
        If Skey <> Astr Then

            ChkTotal = 0
            For X = 0 To 11
                ChkTotal = ChkTotal + T1(X)
            Next
            If ChkTotal = 0 Then GoTo SkipTotal

            'Written Prem 'Earned Prem 'Policy Fee 'Incurred Losses 'Incurred LAE 'Front Fee 'Net Written Prem 'Net Earned Prem 'Net Incurred Losses 'Net Incurred LAE
            Nstr1(1) = RSet(Format(T1(1), "######,###.00"), 13)
            Nstr1(2) = RSet(Format(T1(2), "######,###.00"), 13)
            Nstr1(3) = RSet(Format(T1(3), "######,###.00"), 12)
            Nstr1(4) = RSet(Format(T1(4), "######,###.00"), 13)
            Nstr1(5) = RSet(Format(T1(5), "######,###.00"), 12)
            Nstr1(6) = RSet(Format(T1(6), "######,###.00"), 11)
            Nstr1(7) = RSet(Format(T1(7), "######,###.00"), 12)
            Nstr1(8) = RSet(Format(T1(8), "######,###.00"), 12)
            Nstr1(10) = RSet(Format(T1(10), "######,###.00"), 12)
            Nstr1(11) = RSet(Format(T1(11), "######,###.00"), 11)

            prtobj.Print()
            prtobj.Print("MGA " & Skey & " Total", TAB(33), Nstr1(1), TAB(48), Nstr1(2), TAB(61), Nstr1(3),
                                TAB(74), Nstr1(4), TAB(88), Nstr1(5), TAB(100), Nstr1(6), TAB(111), Nstr1(7),
                                TAB(123), Nstr1(8), TAB(135), Nstr1(10), TAB(147), Nstr1(11))

            L0 = L0 + 4

SkipTotal:
            For X = 0 To 11
                T2(X) = T2(X) + T1(X)
                T1(X) = 0
            Next X

            Skey = Astr
            prtobj.Print()
            prtobj.Print(Astr, TAB(5), A1str)
        End If

        'Written Prem 'Earned Prem 'Policy Fee 'Incurred Losses 'Incurred LAE 'Front Fee 'Net Written Prem 'Net Earned Prem 'Net Incurred Losses 'Net Incurred LAE
        Nstr1(1) = RSet(Format(T(1), "######,###.00"), 13)
        Nstr1(2) = RSet(Format(T(2), "######,###.00"), 13)
        Nstr1(3) = RSet(Format(T(3), "######,###.00"), 12)
        Nstr1(4) = RSet(Format(T(4), "######,###.00"), 13)
        Nstr1(5) = RSet(Format(T(5), "######,###.00"), 12)
        Nstr1(6) = RSet(Format(T(6), "######,###.00"), 11)
        Nstr1(7) = RSet(Format(T(7), "######,###.00"), 12)
        Nstr1(8) = RSet(Format(T(8), "######,###.00"), 12)
        Nstr1(10) = RSet(Format(T(10), "#####,####.00"), 12)
        Nstr1(11) = RSet(Format(T(11), "######,###.00"), 11)

        prtobj.Print(A4str, TAB(5), Mid(A2str, 1, 25), TAB(33), Nstr1(1), TAB(48), Nstr1(2), TAB(61), Nstr1(3),
                                                       TAB(74), Nstr1(4), TAB(88), Nstr1(5), TAB(100), Nstr1(6), TAB(111), Nstr1(7),
                                                       TAB(123), Nstr1(8), TAB(135), Nstr1(10), TAB(147), Nstr1(11))

        L0 = L0 + 1

SkipReport:
        For X = 0 To 11
            T1(X) = T1(X) + T(X)
            T(X) = 0
        Next X
        C1 = 0
    End Sub
End Class