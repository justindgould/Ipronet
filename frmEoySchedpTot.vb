Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmEoySchedpTot
    Inherits DevExpress.XtraEditors.XtraForm


    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Dim CatCode As String
    Dim Wyear As String
    Dim Wperiod As String
    Dim X1 As Short
    Dim Y As Short
    Dim Fname1 As String
    Dim CaptLine As String

    Dim cove(24) As Short
    Dim Z1str As String = String.Format("{0:MMM d, yyyy HH:mm:ss tt}", DateTime.Now)
    Dim Ystr As String
    Dim J2str As String
    Dim Astr As String
    Dim A2str As String
    Dim A4str As String
    Dim J4str As String
    Dim Pstr As String
    Dim L As String
    Dim excl(11) As String

    Dim Pcnt As Short
    Dim X As Short
    Dim T(1) As Double

    Dim P1(10, 16) As Double
    Dim P2(10, 16) As Double
    Dim P3(10, 16) As Double
    Dim P4(10, 16) As Double
    Dim P5(10, 16) As Double
    Dim A(11, 16) As Double
    Dim B(11, 16) As Double
    Dim B1(11, 16) As Double

    Private Sub cmdContinue_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdContinue.Click

        'Global Initial
        J2str = Trim(txtPeriod.Text)
        Ystr = Trim(Str(Parry(1))) 'Curr Year

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

        findExcluded()
        cmdProcess()
    End Sub

    Private Sub findExcluded()
        If chk057.CheckState = 1 Then
            Dim cnt As Short
            Dim mga As String
            OpenIbnrPrm()
            rc = d4top(f25)
            Call d4tagSelect(f25, d4tag(f25, "K1"))
            Do Until rc = r4eof
                mga = Trim(f4str(IFp.IbnrMgaNmbr))
                If mga <> "999" Then
                    For Each e In excl
                        If e = mga Then GoTo nextexcl
                    Next
                    excl(cnt) = mga
                    cnt = cnt + 1
nextexcl:
                End If
                rc = d4skip(f25, 1)
            Loop
        End If
    End Sub

    Private Sub cmdProcess()
        Dim X As Integer
        Dim X1 As Integer

        Me.Text = CaptLine & "          " & "Status: Program Processing"

        If Trim(txtPeriod.Text) = "" Then Exit Sub

        If optToPrinter.Checked Then
            If Pdlg.ShowDialog() <> DialogResult.OK Then
                Me.Text = CaptLine & "          " & "Processing Cancelled"
                Exit Sub
            End If

            For Each Me.P In Printers
                If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
            Next

            prtobj.FontName = "Courier New"
            prtobj.FontSize = 8
            prtobj.FontBold = True
            prtobj.Orientation = 2
            BeginRun = True
            Pcnt = 0
        End If

        'Treaty Master
        Astr = txtMgaNmbr.Text
        A4str = "99"
        If txtMgaNmbr.Text = "991" Then A2str = "Front Fee Program Only (Excludes 001, 015, 016 and 017  MGAs)"
        'If txtMgaNmbr = "999" Then A2str = "Direct Program Only MGAs 001 and 015 "
        'If txtMgaNmbr = "999" Then A2str = "MIC Program Only MGA 016"
        If txtMgaNmbr.Text = "999" Then A2str = "All MGAs and Treaties"

        For X = 1 To 24
            cove(X) = 0
        Next X

        If txtMgaNmbr.Text = "999" Or txtMgaNmbr.Text = "991" Then
            For X = 1 To 24
                cove(X) = 1
            Next X
        End If

        For X = 0 To 10
            For X1 = 0 To 16
                P1(X, X1) = 0
                P2(X, X1) = 0
                P3(X, X1) = 0
                P4(X, X1) = 0
                P5(X, X1) = 0
                A(X, X1) = 0
                B(X, X1) = 0
                B1(X, X1) = 0
            Next X1
        Next X

        If txtMgaNmbr.Text <> "999" And txtMgaNmbr.Text <> "991" Then
            If chPPBI = 1 Then cove(1) = 1
            If chPPPD = 1 Then cove(2) = 1
            If chPPMED = 1 Then cove(3) = 1
            If chPPUMBI = 1 Then cove(4) = 1
            If chPPUMPD = 1 Then cove(5) = 1
            If chPPPIP = 1 Then cove(6) = 1
            If chPPCOMP = 1 Then cove(7) = 1
            If chPPCOLL = 1 Then cove(8) = 1
            If chPPRENT = 1 Then cove(9) = 1
            If chPPTOW = 1 Then cove(10) = 1
            If chCMBI = 1 Then cove(11) = 1
            If chCMPD = 1 Then cove(12) = 1
            If chCMMED = 1 Then cove(13) = 1
            If chCMUMBI = 1 Then cove(14) = 1
            If chCMUMPD = 1 Then cove(15) = 1
            If chCMPIP = 1 Then cove(16) = 1
            If chCMCOMP = 1 Then cove(17) = 1
            If chCMCOLL = 1 Then cove(18) = 1
            If chCMRENT = 1 Then cove(19) = 1
            If chCMTOW = 1 Then cove(20) = 1
            If chIM = 1 Then cove(21) = 1
            If chALLIED = 1 Then cove(22) = 1
            If chFIRE = 1 Then cove(23) = 1
            If chMULTIP = 1 Then cove(24) = 1
        End If

        'ITD Dir
        OpenItdDir()
        ItdDirTotal()

        'RPT Dir
        OpenRptDir()
        RptDirTotal()

        'ITD Ced1
        OpenItdCed1()
        ItdCedTotal()
        ClsItdCed1() : f12 = 0

        'ITD Ced2
        OpenItdCed2()
        ItdCedTotal()
        ClsItdCed2() : f12 = 0

        'ITD Ced3
        OpenItdCed3()
        ItdCedTotal()
        ClsItdCed3() : f12 = 0

        'ITD Ced4
        OpenItdCed4()
        ItdCedTotal()
        ClsItdCed4() : f12 = 0

        'ITD Ced5
        OpenItdCed5()
        ItdCedTotal()
        ClsItdCed5() : f12 = 0

        'RPT Ced1
        OpenRptCed1()
        RptCedTotal()
        ClsRptCed1() : f6 = 0

        'RPT Ced2
        OpenRptCed2()
        RptCedTotal()
        ClsRptCed2() : f6 = 0

        'RPT Ced3
        OpenRptCed3()
        RptCedTotal()
        ClsRptCed3() : f6 = 0

        'RPT Ced4
        OpenRptCed4()
        RptCedTotal()
        ClsRptCed4() : f6 = 0

        'RPT Ced5
        OpenRptCed5()
        RptCedTotal()
        ClsRptCed5() : f6 = 0

        'UEP Dir
        OpenUepDir()
        UepDirTotal()

        'UEP Ced1
        OpenUepCed1()
        UepCedTotal()
        ClsUepCed1() : f8 = 0

        'UEP Ced2
        OpenUepCed2()
        UepCedTotal()
        ClsUepCed2() : f8 = 0

        'UEP Ced3
        OpenUepCed3()
        UepCedTotal()
        ClsUepCed3() : f8 = 0

        'UEP Ced4
        OpenUepCed4()
        UepCedTotal()
        ClsUepCed4() : f8 = 0

        'UEP Ced5
        OpenUepCed5()
        UepCedTotal()
        ClsUepCed5() : f8 = 0

        If optToFile.Checked Then
            Fname1 = My.Application.Info.DirectoryPath & "\mga" & Astr & A4str & ".txt"
            FileOpen(1, Fname1, OpenMode.Output)
        End If

        Schedp()

        If optToPrinter.Checked Then
            prtobj.EndDoc()
            prtobj.Orientation = 1
        End If

        If optToFile.Checked Then FileClose(1)

        Me.Text = CaptLine & "          " & "Status: End Processing"
    End Sub

    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub txtMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Enter
        Tobj = txtMgaNmbr
        txtMgaNmbr.Text = "999"
        Me.Text = CaptLine
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

        If Tobj.Text = "000" Then
            Me.Close()
            Exit Sub
        End If

    End Sub

    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Tobj = txtMgaNmbr
    End Sub

    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Tobj = txtTrtyNmbr
        txtTrtyNmbr.Text = "99"
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

        If Tobj.Text = "00" Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub txtTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Leave
        Tobj = txtTrtyNmbr
    End Sub

    Private Sub txtPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPeriod.Enter
        Tobj = txtPeriod
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

        RptDirKey = ""
    End Sub

    Private Sub frmEoySchedpTot_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        cboMga.SelectedIndex = 0
        cboTrty.SelectedIndex = 0

        optYTD.Checked = True
        optToPrinter.Checked = True
        CaptLine = Me.Text
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Sub RptDirTotal()
        Call d4tagSelect(f5, d4tag(f5, "K1"))
        rc = d4top(f5)
        RptDirKey = ""
        rc = d4seek(f5, RptDirKey)

        Do Until rc = r4eof
            'If Trim(f4str(RDp.RptMgaNmbr)) <> "016" Then GoTo nextrec

            'If Trim(f4str(RDp.RptMgaNmbr)) <> "001" And _
            ''   Trim(f4str(RDp.RptMgaNmbr)) <> "015" Then GoTo nextrec

            'If Trim(f4str(RDp.RptMgaNmbr)) = "057" And chk057.CheckState = 1 Then
            '   GoTo nextrec
            'End If

            If chk057.CheckState = 1 Then
                For Each e In excl
                    If e = Trim(f4str(RDp.RptMgaNmbr)) Then GoTo nextrec
                Next
            End If

            If Trim(txtMgaNmbr.Text) = "991" Then
                If Trim(f4str(RDp.RptMgaNmbr)) = "001" Or Trim(f4str(RDp.RptMgaNmbr)) = "015" Or Trim(f4str(RDp.RptMgaNmbr)) = "016" Or Trim(f4str(RDp.RptMgaNmbr)) = "017" Then
                    GoTo nextrec
                End If
            End If

            If Trim(f4str(RDp.RptMgaNmbr)) = "016" Then
                If Trim(f4str(RDp.RptPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(RDp.RptCatCode))
            Wyear = Trim(f4str(RDp.RptYear))
            Wperiod = Trim(f4str(RDp.RptPeriod))

            If CDbl(CatCode) = 2 Then GoTo nextrec
            If CDbl(CatCode) = 3 Then GoTo nextrec
            If CDbl(CatCode) = 5 Then GoTo nextrec
            If CDbl(CatCode) = 11 Then GoTo nextrec
            If CDbl(CatCode) = 12 Then GoTo nextrec
            If CDbl(CatCode) > 14 Then GoTo nextrec

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Then
                If txtPeriod.Text <> Wperiod Then GoTo nextrec
            End If

            X = (CDbl(Wyear) - (Parry(1) - 9)) + 1 'Calculate Year
            If X > 10 Then GoTo nextrec 'By Pass If Older Than 10 Years
            If X < 0 Then X = 0

            GetRptDirVar()

            If CDbl(CatCode) = 1 Then X1 = 0 'Premium

            If CDbl(CatCode) = 4 Then 'Unearned
                X1 = 0
                For X2 = 1 To 24 : MLobp(X2) = MLobp(X2) * -1 : Next X2
            End If

            If CDbl(CatCode) = 6 Then X1 = 2 'Paid Losses

            If CDbl(CatCode) = 7 Then 'Back Out Salvage
                X1 = 2
                P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)
                P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)
                P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)
                P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)
                P5(X, X1) = P5(X, X1) - MLobp(24)
            End If

            If CDbl(CatCode) = 7 Then X1 = 6 'Salvage
            If CDbl(CatCode) = 8 Then X1 = 4 'Paid LAE
            If CDbl(CatCode) = 9 Then X1 = 8 'Loss Reserve
            If CDbl(CatCode) = 10 Then X1 = 12 'LAE Reserve
            If CDbl(CatCode) = 13 Then X1 = 10 'IBNR Loss Reserve
            If CDbl(CatCode) = 14 Then X1 = 14 'IBNR Loss Reserve

            P1(X, X1) = P1(X, X1) + MLobp(1) + MLobp(2) + MLobp(3) + MLobp(4) + MLobp(5) + MLobp(6)

            P2(X, X1) = P2(X, X1) + MLobp(7) + MLobp(8) + MLobp(9) + MLobp(10) + MLobp(17) + MLobp(18) + MLobp(19) + MLobp(20)

            P3(X, X1) = P3(X, X1) + MLobp(11) + MLobp(12) + MLobp(13) + MLobp(14) + MLobp(15) + MLobp(16)

            P4(X, X1) = P4(X, X1) + MLobp(21) + MLobp(22) + MLobp(23)

            P5(X, X1) = P5(X, X1) + MLobp(24)

nextrec:
            rc = d4skip(f5, 1)
        Loop

    End Sub

    Sub RptCedTotal()
        Call d4tagSelect(f6, d4tag(f6, "K1"))
        rc = d4top(f6)
        RptCedKey = ""
        rc = d4seek(f6, RptCedKey)

        Do Until rc = r4eof
            'If Trim(f4str(Rc1p.CedMgaNmbr)) <> "016" Then GoTo nextrec

            'If Trim(f4str(Rc1p.CedMgaNmbr)) <> "001" And _
            ''   Trim(f4str(Rc1p.CedMgaNmbr)) <> "015" Then GoTo nextrec

            If chk057.CheckState = 1 Then
                For Each e In excl
                    If e = Trim(f4str(Rc1p.CedMgaNmbr)) Then GoTo nextrec
                Next
            End If

            If Trim(txtMgaNmbr.Text) = "991" Then
                If Trim(f4str(Rc1p.CedMgaNmbr)) = "001" Or Trim(f4str(Rc1p.CedMgaNmbr)) = "015" Or Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Or Trim(f4str(Rc1p.CedMgaNmbr)) = "017" Then
                    GoTo nextrec
                End If
            End If

            If Trim(f4str(Rc1p.CedMgaNmbr)) = "016" Then
                If Trim(f4str(Rc1p.CedPeriod)) <> txtPeriod.Text Then GoTo nextrec
            End If

            CatCode = Trim(f4str(Rc1p.CedCatCode))
            Wyear = Trim(f4str(Rc1p.CedYear))
            Wperiod = Trim(f4str(Rc1p.CedPeriod))

            If CDbl(CatCode) = 2 Then GoTo nextrec
            If CDbl(CatCode) = 3 Then GoTo nextrec
            If CDbl(CatCode) = 5 Then GoTo nextrec
            If CDbl(CatCode) = 11 Then GoTo nextrec
            If CDbl(CatCode) = 12 Then GoTo nextrec
            If CDbl(CatCode) > 14 Then GoTo nextrec

            If CDbl(CatCode) = 4 Or CDbl(CatCode) = 9 Or CDbl(CatCode) = 10 Or CDbl(CatCode) = 13 Or CDbl(CatCode) = 14 Then
                If txtPeriod.Text <> Wperiod Then GoTo nextrec
            End If

            X = (CDbl(Wyear) - (Parry(1) - 9)) + 1 'Calculate Year
            If X > 10 Then GoTo nextrec 'By Pass If Older Than 10 Years
            If X < 0 Then X = 0

            GetRptCedVar()

            If CDbl(CatCode) = 1 Then X1 = 1 'Premium

            If CDbl(CatCode) = 4 Then 'Unearned
                X1 = 1
                For X2 = 1 To 24 : MLobp(X2) = MLobp(X2) * -1 : Next X2
            End If

            If CDbl(CatCode) = 6 Then X1 = 3 'Paid Losses

            If CDbl(CatCode) = 7 Then 'Back Out Salvage
                X1 = 3
                P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)
                P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)
                P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)
                P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)
                P5(X, X1) = P5(X, X1) - MLobp(24)
                GoTo nextrec
            End If

            If CDbl(CatCode) = 8 Then X1 = 5 'Paid LAE
            If CDbl(CatCode) = 9 Then X1 = 9 'Loss Reserve
            If CDbl(CatCode) = 10 Then X1 = 13 'LAE Reserve
            If CDbl(CatCode) = 13 Then X1 = 11 'IBNR Loss Reserve
            If CDbl(CatCode) = 14 Then X1 = 15 'IBNR Loss Reserve

            P1(X, X1) = P1(X, X1) + MLobp(1) + MLobp(2) + MLobp(3) + MLobp(4) + MLobp(5) + MLobp(6)

            P2(X, X1) = P2(X, X1) + MLobp(7) + MLobp(8) + MLobp(9) + MLobp(10) + MLobp(17) + MLobp(18) + MLobp(19) + MLobp(20)

            P3(X, X1) = P3(X, X1) + MLobp(11) + MLobp(12) + MLobp(13) + MLobp(14) + MLobp(15) + MLobp(16)

            P4(X, X1) = P4(X, X1) + MLobp(21) + MLobp(22) + MLobp(23)

            P5(X, X1) = P5(X, X1) + MLobp(24)

nextrec:
            rc = d4skip(f6, 1)
        Loop

    End Sub

    Sub ItdDirTotal()
        Call d4tagSelect(f11, d4tag(f11, "K1"))
        rc = d4top(f11)
        ItdDirKey = ""
        rc = d4seek(f11, ItdDirKey)

        Do Until rc = r4eof
            If chk057.CheckState = 1 Then
                For Each e In excl
                    If e = Trim(f4str(IDp.ItdMgaNmbr)) Then GoTo nextrec
                Next
            End If

            If Trim(txtMgaNmbr.Text) = "991" Then
                If Trim(f4str(IDp.ItdMgaNmbr)) = "001" Or Trim(f4str(IDp.ItdMgaNmbr)) = "015" Or Trim(f4str(IDp.ItdMgaNmbr)) = "016" Or Trim(f4str(IDp.ItdMgaNmbr)) = "017" Then
                    GoTo nextrec
                End If
            End If

            CatCode = Trim(f4str(IDp.ItdCatCode))
            Wyear = Trim(f4str(IDp.ItdYear))
            Wperiod = Trim(f4str(IDp.ItdPeriod))

            If CDbl(CatCode) = 2 Then GoTo nextrec
            If CDbl(CatCode) = 3 Then GoTo nextrec
            If CDbl(CatCode) = 5 Then GoTo nextrec
            If CDbl(CatCode) > 8 Then GoTo nextrec

            If Not optITD.Checked Then
                If CDbl(CatCode) <> 4 Then GoTo nextrec 'Unearned Only On YTD Option
            End If

            X = (CDbl(Wyear) - (Parry(1) - 9)) + 1 'Calculate Year
            If X > 10 Then GoTo nextrec 'By Pass If Older Than 10 Years
            If X < 0 Then X = 0

            GetItdDirVar()

            If CDbl(CatCode) = 1 Then X1 = 0 'Premium

            If optITD.Checked Then
                If CDbl(CatCode) = 4 Then 'Unearned ITD Logic
                    X1 = 0

                    P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)

                    P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)

                    P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)

                    P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)

                    P5(X, X1) = P5(X, X1) - MLobp(24)
                End If
            End If

            If CDbl(CatCode) = 4 Then 'Unearned
                X = 10
                X1 = 0
            End If

            If CDbl(CatCode) = 6 Then X1 = 2 'Paid Losses

            If CDbl(CatCode) = 7 Then 'Back Out Salvage
                X1 = 2
                P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)
                P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)
                P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)
                P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)
                P5(X, X1) = P5(X, X1) - MLobp(24)
            End If

            If CDbl(CatCode) = 7 Then X1 = 6 'Salvage
            If CDbl(CatCode) = 8 Then X1 = 4 'Paid LAE

            P1(X, X1) = P1(X, X1) + MLobp(1) + MLobp(2) + MLobp(3) + MLobp(4) + MLobp(5) + MLobp(6)

            P2(X, X1) = P2(X, X1) + MLobp(7) + MLobp(8) + MLobp(9) + MLobp(10) + MLobp(17) + MLobp(18) + MLobp(19) + MLobp(20)

            P3(X, X1) = P3(X, X1) + MLobp(11) + MLobp(12) + MLobp(13) + MLobp(14) + MLobp(15) + MLobp(16)

            P4(X, X1) = P4(X, X1) + MLobp(21) + MLobp(22) + MLobp(23)

            P5(X, X1) = P5(X, X1) + MLobp(24)
nextrec:
            rc = d4skip(f11, 1)
        Loop
    End Sub

    Sub ItdCedTotal()
        Call d4tagSelect(f12, d4tag(f12, "K1"))
        rc = d4top(f12)
        ItdCedKey = ""
        rc = d4seek(f12, ItdCedKey)

        Do Until rc = r4eof
            'If Trim(f4str(Ic1p.CedMgaNmbr)) <> "016" Then GoTo nextrec

            'If Trim(f4str(Ic1p.CedMgaNmbr)) <> "001" And _
            ''   Trim(f4str(Ic1p.CedMgaNmbr)) <> "015" Then GoTo nextrec

            If chk057.CheckState = 1 Then
                For Each e In excl
                    If e = Trim(f4str(Ic1p.CedMgaNmbr)) Then GoTo nextrec
                Next
            End If


            If Trim(txtMgaNmbr.Text) = "991" Then
                If Trim(f4str(Ic1p.CedMgaNmbr)) = "001" Or Trim(f4str(Ic1p.CedMgaNmbr)) = "015" Or Trim(f4str(Ic1p.CedMgaNmbr)) = "016" Or Trim(f4str(Ic1p.CedMgaNmbr)) = "017" Then
                    GoTo nextrec
                End If
            End If

            CatCode = Trim(f4str(Ic1p.CedCatCode))
            Wyear = Trim(f4str(Ic1p.CedYear))
            Wperiod = Trim(f4str(Ic1p.CedPeriod))

            If CDbl(CatCode) = 2 Then GoTo nextrec
            If CDbl(CatCode) = 3 Then GoTo nextrec
            If CDbl(CatCode) = 5 Then GoTo nextrec
            If CDbl(CatCode) > 8 Then GoTo nextrec

            If Not optITD.Checked Then
                If CDbl(CatCode) <> 4 Then GoTo nextrec 'Unearned Only On YTD Option
            End If

            X = (CDbl(Wyear) - (Parry(1) - 9)) + 1 'Calculate Year
            If X > 10 Then GoTo nextrec 'By Pass If Older Than 10 Years
            If X < 0 Then X = 0

            GetItdCedVar()

            If CDbl(CatCode) = 1 Then X1 = 1 'Premium

            If optITD.Checked Then
                If CDbl(CatCode) = 4 Then 'Unearned ITD Logic
                    X1 = 1

                    P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)

                    P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)

                    P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)

                    P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)

                    P5(X, X1) = P5(X, X1) - MLobp(24)
                End If
            End If

            If CDbl(CatCode) = 4 Then 'Unearned
                X = 10
                X1 = 1
            End If

            If CDbl(CatCode) = 6 Then X1 = 3 'Paid Losses

            If CDbl(CatCode) = 7 Then 'Back Out Salvage
                X1 = 3
                P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)
                P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)
                P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)
                P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)
                P5(X, X1) = P5(X, X1) - MLobp(24)
                GoTo nextrec
            End If

            If CDbl(CatCode) = 8 Then X1 = 5 'Paid LAE

            P1(X, X1) = P1(X, X1) + MLobp(1) + MLobp(2) + MLobp(3) + MLobp(4) + MLobp(5) + MLobp(6)

            P2(X, X1) = P2(X, X1) + MLobp(7) + MLobp(8) + MLobp(9) + MLobp(10) + MLobp(17) + MLobp(18) + MLobp(19) + MLobp(20)

            P3(X, X1) = P3(X, X1) + MLobp(11) + MLobp(12) + MLobp(13) + MLobp(14) + MLobp(15) + MLobp(16)

            P4(X, X1) = P4(X, X1) + MLobp(21) + MLobp(22) + MLobp(23)

            P5(X, X1) = P5(X, X1) + MLobp(24)

nextrec:
            rc = d4skip(f12, 1)
        Loop

    End Sub

    Sub UepDirTotal()
        Call d4tagSelect(f7, d4tag(f7, "K1"))
        rc = d4top(f7)
        UepDirKey = ""
        rc = d4seek(f7, UepDirKey)

        Do Until rc = r4eof
            'If Trim(f4str(UEp.UepMgaNmbr)) <> "016" Then GoTo nextrec

            'If Trim(f4str(UEp.UepMgaNmbr)) <> "001" And _
            ''   Trim(f4str(UEp.UepMgaNmbr)) <> "015" Then GoTo nextrec

            'If Trim(f4str(UEp.UepMgaNmbr)) = "057" And chk057.CheckState = 1 Then
            'GoTo nextrec
            'End If

            If chk057.CheckState = 1 Then
                For Each e In excl
                    If e = Trim(f4str(UEp.UepMgaNmbr)) Then GoTo nextrec
                Next
            End If

            If Trim(txtMgaNmbr.Text) = "991" Then
                If Trim(f4str(UEp.UepMgaNmbr)) = "001" Or Trim(f4str(UEp.UepMgaNmbr)) = "015" Or Trim(f4str(UEp.UepMgaNmbr)) = "016" Or Trim(f4str(UEp.UepMgaNmbr)) = "017" Then
                    GoTo nextrec
                End If
            End If

            CatCode = Trim(f4str(UEp.UepCatCode))
            Wyear = Trim(f4str(UEp.UepYear))
            Wperiod = Trim(f4str(UEp.UepPeriod))

            If (Parry(1) - CDbl(Wyear)) < 2 Then GoTo nextrec

            If Not optITD.Checked Then GoTo nextrec 'Unearned Only On ITD Option

            X = (CDbl(Wyear) - (Parry(1) - 9)) + 1 'Calculate Year
            If X > 10 Then GoTo nextrec 'By Pass If Older Than 10 Years
            If X < 0 Then X = 0

            GetUepDirVar()

            If CDbl(CatCode) = 4 Then 'Unearned
                X1 = 0

                P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)

                P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)

                P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)

                P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)

                P5(X, X1) = P5(X, X1) - MLobp(24)
            End If

            If CDbl(CatCode) = 4 And X < 9 Then 'Unearned
                X1 = 0

                P1(X + 1, X1) = P1(X + 1, X1) + MLobp(1) + MLobp(2) + MLobp(3) + MLobp(4) + MLobp(5) + MLobp(6)

                P2(X + 1, X1) = P2(X + 1, X1) + MLobp(7) + MLobp(8) + MLobp(9) + MLobp(10) + MLobp(17) + MLobp(18) + MLobp(19) + MLobp(20)

                P3(X + 1, X1) = P3(X + 1, X1) + MLobp(11) + MLobp(12) + MLobp(13) + MLobp(14) + MLobp(15) + MLobp(16)

                P4(X + 1, X1) = P4(X + 1, X1) + MLobp(21) + MLobp(22) + MLobp(23)

                P5(X + 1, X1) = P5(X + 1, X1) + MLobp(24)
            End If

nextrec:
            rc = d4skip(f7, 1)
        Loop

    End Sub

    Sub UepCedTotal()
        Call d4tagSelect(f8, d4tag(f8, "K1"))
        rc = d4top(f8)
        UepCedKey = ""
        rc = d4seek(f8, UepCedKey)

        Do Until rc = r4eof
            'If Trim(f4str(Uc1p.CedMgaNmbr)) <> "016" Then GoTo nextrec

            'If Trim(f4str(Uc1p.CedMgaNmbr)) <> "001" And _
            ''   Trim(f4str(Uc1p.CedMgaNmbr)) <> "015" Then GoTo nextrec

            'If Trim(f4str(Uc1p.CedMgaNmbr)) = "057" And chk057.CheckState = 1 Then
            '   GoTo nextrec
            'End If

            If chk057.CheckState = 1 Then
                For Each e In excl
                    If e = Trim(f4str(Uc1p.CedMgaNmbr)) Then GoTo nextrec
                Next
            End If

            If Trim(txtMgaNmbr.Text) = "991" Then
                If Trim(f4str(Uc1p.CedMgaNmbr)) = "001" Or Trim(f4str(Uc1p.CedMgaNmbr)) = "015" Or Trim(f4str(Uc1p.CedMgaNmbr)) = "016" Or Trim(f4str(Uc1p.CedMgaNmbr)) = "017" Then
                    GoTo nextrec
                End If
            End If

            CatCode = Trim(f4str(Uc1p.CedCatCode))
            Wyear = Trim(f4str(Uc1p.CedYear))
            Wperiod = Trim(f4str(Uc1p.CedPeriod))

            If (Parry(1) - CDbl(Wyear)) < 2 Then GoTo nextrec

            If Not optITD.Checked Then GoTo nextrec 'Unearned Only On ITD Option

            X = (CDbl(Wyear) - (Parry(1) - 9)) + 1 'Calculate Year
            If X > 10 Then GoTo nextrec 'By Pass If Older Than 10 Years
            If X < 0 Then X = 0

            GetUepCedVar()

            If CDbl(CatCode) = 4 Then 'Unearned
                X1 = 1

                P1(X, X1) = P1(X, X1) - MLobp(1) - MLobp(2) - MLobp(3) - MLobp(4) - MLobp(5) - MLobp(6)

                P2(X, X1) = P2(X, X1) - MLobp(7) - MLobp(8) - MLobp(9) - MLobp(10) - MLobp(17) - MLobp(18) - MLobp(19) - MLobp(20)

                P3(X, X1) = P3(X, X1) - MLobp(11) - MLobp(12) - MLobp(13) - MLobp(14) - MLobp(15) - MLobp(16)

                P4(X, X1) = P4(X, X1) - MLobp(21) - MLobp(22) - MLobp(23)

                P5(X, X1) = P5(X, X1) - MLobp(24)
            End If

            If CDbl(CatCode) = 4 And X < 9 Then 'Unearned
                X1 = 1

                P1(X + 1, X1) = P1(X + 1, X1) + MLobp(1) + MLobp(2) + MLobp(3) + MLobp(4) + MLobp(5) + MLobp(6)

                P2(X + 1, X1) = P2(X + 1, X1) + MLobp(7) + MLobp(8) + MLobp(9) + MLobp(10) + MLobp(17) + MLobp(18) + MLobp(19) + MLobp(20)

                P3(X + 1, X1) = P3(X + 1, X1) + MLobp(11) + MLobp(12) + MLobp(13) + MLobp(14) + MLobp(15) + MLobp(16)

                P4(X + 1, X1) = P4(X + 1, X1) + MLobp(21) + MLobp(22) + MLobp(23)

                P5(X + 1, X1) = P5(X + 1, X1) + MLobp(24)
            End If

nextrec:
            rc = d4skip(f8, 1)
        Loop

    End Sub

    Sub Schedp()
        Dim X As Integer
        Dim X1 As Integer

Sec1bLiab:
        If cove(1) + cove(2) + cove(3) + cove(4) + cove(5) + cove(6) = 0 Then GoTo Sec1cLiabCM

        L = "1B Liab"
        For X = 0 To 10
            For X1 = 0 To 16
                B(X, X1) = P1(X, X1)
                If optYTD.Checked Then
                    If X < 10 Then
                        If X1 < 2 Then B(X, X1) = 0
                    End If
                End If
                A(X, X1) = A(X, X1) + B(X, X1)
            Next X1
        Next X

        If optToPrinter.Checked Then
            PrtPgeHd()
            PrtSec1()
            PrtSec2()
            PrtSec3()
        End If

        If optToFile.Checked Then WriteMgaRec()

Sec1cLiabCM:
        If cove(10) + cove(11) + cove(12) + cove(13) + cove(14) + cove(15) = 0 Then GoTo Sec1e

        L = "1C CMLiab"
        For X = 0 To 10
            For X1 = 0 To 16
                B(X, X1) = P3(X, X1)
                If optYTD.Checked Then
                    If X < 10 Then
                        If X1 < 2 Then B(X, X1) = 0
                    End If
                End If
                A(X, X1) = A(X, X1) + B(X, X1)
            Next X1
        Next X
        If optToPrinter.Checked Then
            PrtPgeHd()
            PrtSec1()
            PrtSec2()
            PrtSec3()
        End If

        If optToFile.Checked Then WriteMgaRec()

Sec1e:
        If cove(23) = 0 Then GoTo Sec1i

        L = "1E MuPeril"
        For X = 0 To 10
            For X1 = 0 To 16
                B(X, X1) = P5(X, X1)
                If optYTD.Checked Then
                    If X < 10 Then
                        If X1 < 2 Then B(X, X1) = 0
                    End If
                End If
                A(X, X1) = A(X, X1) + B(X, X1)
            Next X1
        Next X
        If optToPrinter.Checked Then
            PrtPgeHd()
            PrtSec1()
            PrtSec2()
            PrtSec3()
        End If

        If optToFile.Checked Then WriteMgaRec()

Sec1i:
        If cove(20) + cove(21) + cove(22) = 0 Then GoTo Sec1j

        L = "1I Allied"
        For X = 0 To 10
            For X1 = 0 To 16
                B(X, X1) = P4(X, X1)
                If optYTD.Checked Then
                    If X < 10 Then
                        If X1 < 2 Then B(X, X1) = 0
                    End If
                End If
                A(X, X1) = A(X, X1) + B(X, X1)
            Next X1
        Next X
        If optToPrinter.Checked Then
            PrtPgeHd()
            PrtSec1()
            PrtSec2()
            PrtSec3()
        End If

        If optToFile.Checked Then WriteMgaRec()

Sec1j:
        If cove(6) + cove(7) + cove(8) + cove(9) + cove(16) + cove(17) + cove(18) + cove(19) = 0 Then GoTo Total

        L = "1J PhysDam"
        For X = 0 To 10
            For X1 = 0 To 16
                B(X, X1) = P2(X, X1)
                If optYTD.Checked Then
                    If X < 10 Then
                        If X1 < 2 Then B(X, X1) = 0
                    End If
                End If
                A(X, X1) = A(X, X1) + B(X, X1)
            Next X1
        Next X
        If optToPrinter.Checked Then
            PrtPgeHd()
            PrtSec1()
            PrtSec2()
            PrtSec3()
        End If

        If optToFile.Checked Then WriteMgaRec()

Total:
        If optToFile.Checked Then Exit Sub

        L = "Total"
        For X = 0 To 10
            For X1 = 0 To 16
                B(X, X1) = A(X, X1)
            Next X1
        Next X
        If optToPrinter.Checked Then
            PrtPgeHd()
            PrtSec1()
            PrtSec2()
            PrtSec3()
        End If
    End Sub

    Sub PrtPgeHd()
        Pcnt = Pcnt + 1
        prtobj.Print()
        prtobj.Print(Astr, TAB(5), A4str & " " & A2str)
        If optYTD.Checked = True Then prtobj.Print("YTD " & Format(Parry(1), "0000") & " SCHEDP", TAB(136), "Page " & Str(Pcnt))
        If optITD.Checked = True Then prtobj.Print("ITD " & Format(Parry(1), "0000") & " SCHEDP", TAB(136), "Page " & Str(Pcnt))
        prtobj.Print(Z1str)
        prtobj.Print("For Period: " + J4str)
    End Sub

    Sub PrtSec1()
        Dim X As Integer
        Dim X1 As Integer
        Dim Lstr As String


        'PRINT SEC 1

        'SEC 1 Headings
        prtobj.Print()
        prtobj.Print(TAB(6), "Line", TAB(20), "Earned Prem", TAB(35), "Earned Prem", TAB(57), "Net", TAB(69), "Losses",
                                     TAB(84), "Losses", TAB(101), "LAE", TAB(116), "LAE", TAB(122), "Sal & Subro",
                                     TAB(134), "Unallocated", TAB(151), "Total Net")

        prtobj.Print(TAB(25), "Direct", TAB(41), "Ceded", TAB(69), "Direct", TAB(85), "Ceded", TAB(98), "Direct",
                     TAB(114), "Ceded", TAB(125), "Received", TAB(136), "Loss Pmts", TAB(156), "Paid")

        'SEC 1 Detail
        For X = 0 To 10
            If X = 0 Then Ystr = "Prior"

            If X = 0 Then
                Lstr = L
            Else
                Lstr = " "
            End If

            If X > 0 Then
                Y = (Parry(1) - 10) + X
                Ystr = Str(Y)
            End If
            T(0) = B(X, 0) - B(X, 1)
            T(1) = B(X, 2) - B(X, 3) + B(X, 4) - B(X, 5) + B(X, 7)

            prtobj.Print(Lstr, TAB(11), Ystr,
                               TAB(16), RSet(Format(B(X, 0), "####,###,###.00"), 15),
                               TAB(31), RSet(Format(B(X, 1), "####,###,###.00"), 15),
                               TAB(46), RSet(Format(T(0), "###,###,###.00"), 14),
                               TAB(60), RSet(Format(B(X, 2), "####,###,###.00"), 15),
                               TAB(75), RSet(Format(B(X, 3), "####,###,###.00"), 15),
                               TAB(90), RSet(Format(B(X, 4), "###,###,###.00"), 14),
                               TAB(104), RSet(Format(B(X, 5), "####,###,###.00"), 15),
                               TAB(119), RSet(Format(B(X, 6), "###,###,###.00"), 14),
                               TAB(133), RSet(Format(B(X, 7), "#,###,###.00"), 12),
                               TAB(145), RSet(Format(T(1), "####,###,###.00"), 15))
        Next X

        prtobj.Print()

        'SEC 1 Total
        For X = 0 To 7
            B(11, X) = 0
        Next X

        For X = 0 To 10
            For X1 = 0 To 7
                B(11, X1) = B(11, X1) + B(X, X1)
            Next X1
        Next X

        T(0) = B(11, 0) - B(11, 1)
        T(1) = B(11, 2) - B(11, 3) + B(11, 4) - B(11, 5) + B(11, 7)


        prtobj.Print(TAB(11), "Total", TAB(16), RSet(Format(B(11, 0), "####,###,###.00"), 15),
                                       TAB(31), RSet(Format(B(11, 1), "####,###,###.00"), 15),
                                       TAB(46), RSet(Format(T(0), "###,###,###.00"), 14),
                                       TAB(60), RSet(Format(B(X, 2), "####,###,###.00"), 15),
                                       TAB(75), RSet(Format(B(X, 3), "####,###,###.00"), 15),
                                       TAB(90), RSet(Format(B(X, 4), "###,###,###.00"), 14),
                                       TAB(104), RSet(Format(B(X, 5), "####,###,###.00"), 15),
                                       TAB(119), RSet(Format(B(X, 6), "###,###,###.00"), 14),
                                       TAB(133), RSet(Format(B(X, 7), "#,###,###.00"), 12),
                                       TAB(145), RSet(Format(T(1), "####,###,###.00"), 15))

        prtobj.Print()
    End Sub

    Sub PrtSec2()
        Dim X As Integer
        Dim X1 As Integer
        Dim Lstr As String

        'PRINT SEC 2

        'SEC 2 Headings
        prtobj.Print()
        prtobj.Print(TAB(6), "Line", TAB(20), "Losses Unpd", TAB(35), "Losses Unpd",
                     TAB(49), "Losses IBNR", TAB(64), "Losses IBNR", TAB(80), "LAE Unpaid",
                     TAB(94), "LAE Unpaid", TAB(111), "LAE IBNR", TAB(125), "LAE IBNR",
                     TAB(134), "Unallocated", TAB(146), "Total Net Loss")
        prtobj.Print(TAB(25), "Direct", TAB(41), "Ceded", TAB(49), "Direct", TAB(70), "Ceded",
                     TAB(84), "Direct", TAB(99), "Ceded", TAB(113), "Direct", TAB(128), "Ceded",
                     TAB(135), "LAE Unpaid", TAB(150), "& LAE Unpd")

        'SEC 2 Detail
        For X = 0 To 10
            If X = 0 Then Ystr = "Prior"

            If X = 0 Then
                Lstr = L
            Else
                Lstr = " "
            End If

            If X > 0 Then
                Y = (Parry(1) - 10) + X
                Ystr = Str(Y)
            End If
            T(0) = B(X, 8) - B(X, 9) + B(X, 10) - B(X, 11)
            T(0) = T(0) + B(X, 12) - B(X, 13) + B(X, 14) - B(X, 15) + B(X, 16)

            prtobj.Print(Lstr, TAB(11), Ystr,
                         TAB(16), RSet(Format(B(X, 8), "####,###,###.00"), 15),
                         TAB(31), RSet(Format(B(X, 9), "####,###,###.00"), 15),
                         TAB(46), RSet(Format(B(X, 10), "###,###,###.00"), 14),
                         TAB(60), RSet(Format(B(X, 11), "####,###,###.00"), 15),
                         TAB(75), RSet(Format(B(X, 12), "####,###,###.00"), 15),
                         TAB(90), RSet(Format(B(X, 13), "###,###,###.00"), 14),
                         TAB(104), RSet(Format(B(X, 14), "####,###,###.00"), 15),
                         TAB(119), RSet(Format(B(X, 15), "###,###,###.00"), 14),
                         TAB(133), RSet(Format(B(X, 16), "#,###,###.00"), 12),
                         TAB(145), RSet(Format(T(0), "####,###,###.00"), 15))
        Next X

        prtobj.Print()

        'SEC 2 Total
        For X = 8 To 16
            B(11, X) = 0
        Next X

        For X = 0 To 10
            For X1 = 8 To 16
                B(11, X1) = B(11, X1) + B(X, X1)
            Next X1
        Next X

        T(0) = B(11, 8) - B(11, 9) + B(11, 10) - B(11, 11)
        T(0) = T(0) + B(11, 12) - B(11, 13) + B(11, 14) - B(11, 15) + B(11, 16)

        prtobj.Print(TAB(11), "Total",
                     TAB(16), RSet(Format(B(11, 8), "####,###,###.00"), 15),
                     TAB(31), RSet(Format(B(11, 9), "####,###,###.00"), 15),
                     TAB(46), RSet(Format(B(11, 10), "###,###,###.00"), 14),
                     TAB(60), RSet(Format(B(11, 11), "####,###,###.00"), 15),
                     TAB(75), RSet(Format(B(11, 12), "####,###,###.00"), 15),
                     TAB(90), RSet(Format(B(11, 13), "###,###,###.00"), 14),
                     TAB(104), RSet(Format(B(11, 14), "####,###,###.00"), 15),
                     TAB(119), RSet(Format(B(11, 15), "###,###,###.00"), 14),
                     TAB(133), RSet(Format(B(11, 16), "#,###,###.00"), 12),
                     TAB(145), RSet(Format(T(0), "####,###,###.00"), 15))
        prtobj.Print()
    End Sub

    Sub PrtSec3()
        Dim X As Integer
        Dim X1 As Integer
        Dim Lstr As String

        'PRINT SEC 3

        'SEC 3 Headings
        prtobj.Print()
        prtobj.Print(TAB(6), "Line", TAB(23), "Incurred", TAB(38), "Incurred", TAB(52), "Incurred",
                     TAB(65), "Loss Ratio", TAB(80), "Loss Ratio", TAB(94), "Loss Ratio",
                     TAB(108), "Net Bal Sht", TAB(122), "Net Bal Sht", TAB(134), "Unallocated")
        prtobj.Print(TAB(25), "Direct", TAB(41), "Ceded", TAB(57), "Net", TAB(69), "Direct",
                     TAB(85), "Ceded", TAB(101), "Net", TAB(108), "Losses Unpd",
                     TAB(125), "LAE Unpd", TAB(137), "LAE Unpd")

        For X = 0 To 11
            For X1 = 0 To 8
                B1(X, X1) = 0
            Next X1
        Next X

        'SEC 3 Detail (Includes Total Also)
        For X = 0 To 11
            If X = 0 Then Ystr = "Prior"

            If X = 0 Then
                Lstr = L
            Else
                Lstr = " "
            End If

            If X > 0 Then
                Y = (Parry(1) - 10) + X
                Ystr = Str(Y)
            End If
            If X = 11 Then
                prtobj.Print()
                Ystr = "Total"
            End If

            B1(X, 0) = B(X, 2) + B(X, 4) + B(X, 8) + B(X, 10) + B(X, 12) + B(X, 14)
            B1(X, 1) = B(X, 3) + B(X, 5) + B(X, 9) + B(X, 11) + B(X, 13) + B(X, 15)
            B1(X, 2) = B1(X, 0) - B1(X, 1)
            If B(X, 1) <> 0 Then B1(X, 4) = (B1(X, 1) / B(X, 1)) * 100
            If B(X, 0) <> 0 Then B1(X, 3) = (B1(X, 0) / B(X, 0)) * 100
            If B(X, 0) - B(X, 1) <> 0 Then B1(X, 5) = (B1(X, 2) / (B(X, 0) - B(X, 1))) * 100
            B1(X, 6) = B(X, 8) - B(X, 9) + B(X, 10) - B(X, 11)
            prtobj.Print(Lstr, TAB(11), Ystr,
                         TAB(16), RSet(Format(B1(X, 0), "####,###,###.00"), 15),
                         TAB(31), RSet(Format(B1(X, 1), "####,###,###.00"), 15),
                         TAB(46), RSet(Format(B1(X, 2), "###,###,###.00"), 14),
                         TAB(60), RSet(Format(B1(X, 3), "####,###,###.00"), 15),
                         TAB(75), RSet(Format(B1(X, 4), "####,###,###.00"), 15),
                         TAB(90), RSet(Format(B1(X, 5), "###,###,###.00"), 14),
                         TAB(104), RSet(Format(B1(X, 6), "####,###,###.00"), 15),
                         TAB(119), RSet(Format(B1(X, 7), "###,###,###.00"), 14),
                         TAB(133), RSet(Format(B1(X, 8), "#,###,###.00"), 12))
        Next X

        prtobj.Print()
        prtobj.NewPage()
    End Sub

    Public Sub WriteMgaRec()
        Dim X As Integer

        Dim f0 As String
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
        Dim f16 As String
        Dim f17 As String
        Dim f18 As String
        Dim f19 As String

        For X = 0 To 10
            If X = 0 Then Ystr = "Prior"
            If X > 0 Then
                Y = (Parry(1) - 10) + X
                Ystr = Str(Y)
            End If

            f0 = ","
            f1 = Astr
            f2 = A4str
            f3 = Mid(L, 1, 2)
            f4 = Ystr

            Pstr = "          "
            Pstr = RSet(Format(B(X, 0), "#########0"), Len(Pstr))
            f5 = Pstr
            Pstr = RSet(Format(B(X, 1), "#########0"), Len(Pstr))
            f6 = Pstr
            Pstr = RSet(Format(B(X, 2), "#########0"), Len(Pstr))
            f7 = Pstr
            Pstr = RSet(Format(B(X, 3), "#########0"), Len(Pstr))
            f8 = Pstr
            Pstr = RSet(Format(B(X, 4), "#########0"), Len(Pstr))
            f9 = Pstr
            Pstr = RSet(Format(B(X, 5), "#########0"), Len(Pstr))
            f10 = Pstr
            Pstr = RSet(Format(B(X, 6), "#########0"), Len(Pstr))
            f11 = Pstr
            Pstr = RSet(Format(B(X, 8), "#########0"), Len(Pstr))
            f12 = Pstr
            Pstr = RSet(Format(B(X, 9), "#########0"), Len(Pstr))
            f13 = Pstr
            Pstr = RSet(Format(B(X, 10), "#########0"), Len(Pstr))
            f14 = Pstr
            Pstr = RSet(Format(B(X, 11), "#########0"), Len(Pstr))
            f15 = Pstr
            Pstr = RSet(Format(B(X, 12), "#########0"), Len(Pstr))
            f16 = Pstr
            Pstr = RSet(Format(B(X, 13), "#########0"), Len(Pstr))
            f17 = Pstr
            Pstr = RSet(Format(B(X, 14), "#########0"), Len(Pstr))
            f18 = Pstr
            Pstr = RSet(Format(B(X, 15), "#########0"), Len(Pstr))
            f19 = Pstr

            PrintLine(1, f1 & f0 & f2 & f0 & f3 & f0 & f4 & f0 & f5 & f0 & f6 & f0 & f7 & f0 & f8 & f0 & f9 & f0 & f10 & f0 & f11 & f0 & f12 & f0 & f13 & f0 & f14 & f0 & f15 & f0 & f16 & f0 & f17 & f0 & f18 & f0 & f19)
        Next X

    End Sub

End Class
