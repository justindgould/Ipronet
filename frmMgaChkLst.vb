Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmMgaChkLst
    Inherits DevExpress.XtraEditors.XtraForm

    Dim Pdlg As New PrintDialog
    Dim P As New Printer
    Dim atype As String


    Private Sub frmMgaChkLst_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenChkLst()
        OpenMgaMst()
        OpenTrtyPrm()
        OpenTrtyMst()
        OpenPeriod()
        DspStat = 0
        InitChkLstForm()
    End Sub

    Private Sub frmMgaChkLst_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Private Sub cboChkTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboChkTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        If Not AddTran And Not UpdateTran Then
            txtChkTrtyNmbr.Text = Mid(Trim(cboChkTrty.Text), 1, 2)
        End If
        TrtyKey = Mid(Trim(cboChkMga.Text), 1, 3) & Mid(Trim(cboChkTrty.Text), 1, 2)
        RdTrtyPrmRec()
        txtChkMgaNmbr.ReadOnly = True
        txtChkTrtyNmbr.ReadOnly = True
        txtChkPeriod.Focus()
        UpdateTran = True
    End Sub

    Private Sub cboChkTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboChkTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboChkMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboChkMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboChkMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboChkTrty.Items.Count > 1 Then
            cboChkTrty.SelectedIndex = 1
        Else
            cboChkTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then txtChkMgaNmbr.Text = Mid(Trim(cboChkMga.Text), 1, 3)
            txtChkTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboChkMga.Text), 1, 3)
            M1 = cboChkMga.SelectedIndex
            InitChkLstForm()
            txtChkMgaNmbr.Text = M
            cboChkMga.SelectedIndex = M1
            txtChkTrtyNmbr.Text = ""
            txtChkMgaNmbr.Focus()
        End If

    End Sub

    Private Sub cboChkMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboChkMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboOpt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboOpt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then txtOptPeriod.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub lstOptDsp_DoubleClick(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles lstOptDsp.DoubleClick
        Dim Wkey As String
        Dim X As Integer

        If lstOptDsp.SelectedIndex = 0 Then Exit Sub
        Wkey = lstOptDsp.Text
        ChkLstKey = Mid(Wkey, 1, 3) & Mid(Wkey, 6, 2) & Mid(Wkey, 44, 2)
        GetChkLstRec()

        ByPassCbo = True
        M = Mid(Wkey, 1, 3)
        For X = 1 To cboChkMga.Items.Count
            If MgaArray(X) = M Then
                cboChkMga.SelectedIndex = X
                Exit For
            End If
        Next X

        M1 = Mid(Wkey, 6, 2)
        TrtyKey = M & M1
        LoadCboTrty()
        For X = 0 To cboChkTrty.Items.Count
            If TrtyArray(X) = M1 Then
                cboChkTrty.SelectedIndex = X
                Exit For
            End If
        Next X
        ByPassCbo = False

        If AddTran Then
            txChkMgaNmbr = M
            txChkTrtyNmbr = M1
            UpChkLstFrmVar()
            txtChkPeriod.Focus()
            Exit Sub
        End If

        UpChkLstFrmVar()
        txtChkMgaNmbr.ReadOnly = True
        txtChkTrtyNmbr.ReadOnly = True
        txtChkPeriod.ReadOnly = True
        txtChkDate.Focus()
    End Sub

    Private Sub lstOptDsp_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstOptDsp.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Public Sub mnuChkExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuChkExit.Click
        Me.Close()
    End Sub

    Public Sub mnuOcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOcomments.Click
        TrtyKey = Trim(txtChkMgaNmbr.Text) & Trim(txtChkTrtyNmbr.Text)
        If Len(TrtyKey) <> 5 Then Exit Sub
        RdTrtyMstRec()
        If Fstat = 0 Then
            Cmga = txtChkMgaNmbr.Text
            Ctrty = txtChkTrtyNmbr.Text
            frmTrtyComments.ShowDialog()
            UpTrtyComments()
        End If
    End Sub

    Public Sub mnuOdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelChkLstRec()
        InitChkLstForm()
        txtChkMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitChkLstForm()
        txtChkMgaNmbr.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        ProcessChkLstRec()
    End Sub

    Public Sub mnuRMgaListActive_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuRMgaListActive.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        atype = "A"

        DspRptChkLst()
        PrtRptChkLst()
    End Sub

    Public Sub mnuRMgaListUnactive_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuRMgaListUnactive.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        atype = "U"

        DspRptChkLst()
        PrtRptChkLst()
    End Sub

    Public Sub mnuRMgaListPending_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuRMgaListPending.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        atype = "P"

        DspRptChkLst()
        PrtRptChkLst()
    End Sub

    Public Sub mnuRNoFinalChk_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuRNoFinalChk.Click
        Dim Wperiod As String

        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        Wperiod = "  "

        If Trim(txtOptPeriod.Text) = "" Then
            Wperiod = RSet(InputBox("Enter Period", "File Open"), Len(Wperiod))
            If Mid(Wperiod, 1, 1) = " " Then Mid(Wperiod, 1, 1) = "0"
            txtOptPeriod.Text = Wperiod
        End If

        If Trim(txtOptPeriod.Text) = "" Then Exit Sub

        txtOptMga.Text = ""
        DspOptNoFinalChk()
        RptOptNoFinalChk()
    End Sub

    Public Sub mnuRNotRecv_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuRNotRecv.Click
        Dim Wperiod As String

        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        Wperiod = "  "

        If Trim(txtOptPeriod.Text) = "" Then
            Wperiod = RSet(InputBox("Enter Period", "File Open"), Len(Wperiod))
            If Mid(Wperiod, 1, 1) = " " Then Mid(Wperiod, 1, 1) = "0"
            txtOptPeriod.Text = Wperiod
        End If

        If Trim(txtOptPeriod.Text) = "" Then Exit Sub

        txtOptMga.Text = ""
        DspOptNotRecv()
        RptOptNotRecv()
    End Sub

    Public Sub mnuRrecv_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuRrecv.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        txtOptPeriod.Text = ""
        txtOptMga.Text = ""
        DspAllChkLst()
        RptAllChkLst()
    End Sub

    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUcomments.Click
        TrtyKey = Trim(txtChkMgaNmbr.Text) & Trim(txtChkTrtyNmbr.Text)
        If Len(TrtyKey) <> 5 Then Exit Sub
        RdTrtyMstRec()
        If Fstat = 0 Then
            Cmga = txtChkMgaNmbr.Text
            Ctrty = txtChkTrtyNmbr.Text
            frmTrtyComments.ShowDialog()
            UpTrtyComments()
        End If
    End Sub

    Public Sub mnuUdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelChkLstRec()
        InitChkLstForm()
        txtChkMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitChkLstForm()
        txtChkMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        ProcessChkLstRec()
    End Sub

    Private Sub txtChkMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkMgaNmbr.Enter
        Tobj = txtChkMgaNmbr
    End Sub

    Private Sub txtChkMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtChkMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtChkTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtChkTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtChkMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtChkMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtChkMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtChkMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtChkMgaNmbr.KeyUp
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
                For X = 1 To cboChkMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboChkMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboChkMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If

    End Sub

    Private Sub txtChkMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkMgaNmbr.Leave
        Dim X As Integer

        Tobj = txtChkMgaNmbr

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()
        UpdateTran = False
        AddTran = False

        If s = "000" Then Tobj.Text = ""
        If Fstat <> 0 Then
            If Tobj.Text <> "" Then MsgBox("MGA Master Record Does Not Exist.")
        End If
    End Sub

    Private Sub txtChkTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkTrtyNmbr.Enter
        Dim X As Integer

        Tobj = txtChkTrtyNmbr

        If Len(txtChkMgaNmbr.Text) > 0 Then
            For X = 1 To cboChkMga.Items.Count
                If MgaArray(X) = Trim(txtChkMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboChkMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboChkMga.SelectedIndex = 0
        End If

    End Sub

    Private Sub txtChkTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtChkTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtChkMgaNmbr.Focus()
            Case Keys.Down
                txtChkPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtChkPeriod.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtChkTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtChkTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtChkTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtChkTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtChkTrtyNmbr.KeyUp
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
                For X = 0 To cboChkTrty.Items.Count
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboChkTrty.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboChkTrty.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtChkTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkTrtyNmbr.Leave
        Dim X As Integer

        Tobj = txtChkTrtyNmbr

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

    Private Sub txtChkPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkPeriod.Enter
        Dim X As Integer

        Tobj = txtChkPeriod

        If Len(txtChkMgaNmbr.Text) > 0 Then
            For X = 0 To cboChkTrty.Items.Count
                If TrtyArray(X) = Trim(txtChkTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboChkTrty.SelectedIndex = X
                    ByPassCbo = False
                    If Trim(txtChkPeriod.Text) = "" Then txtChkPeriod.Text = CurrPeriod
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboChkTrty.SelectedIndex = 0
            ByPassCbo = False
        End If
    End Sub

    Private Sub txtChkPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtChkPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtChkTrtyNmbr.Focus()
            Case Keys.Down
                txtChkDate.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtChkDate.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub txtChkPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtChkPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtChkPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtChkPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkPeriod.Leave
        Dim X As Integer
        Dim M, M1, M2 As String
        Dim W, W1 As Short

        Tobj = txtChkPeriod

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = S1
        If S1 = "00" Then Tobj.Text = ""

        If Len(Trim(txtChkMgaNmbr.Text)) = 3 And Len(Trim(txtChkTrtyNmbr.Text)) = 2 Then
            ChkLstKey = Trim(txtChkMgaNmbr.Text) & Trim(txtChkTrtyNmbr.Text) & Trim(txtChkPeriod.Text)
            GetChkLstRec()
            If UpdateTran Then
                UpChkLstFrmVar()
                txtChkMgaNmbr.ReadOnly = True
                txtChkTrtyNmbr.ReadOnly = True
                txtChkPeriod.ReadOnly = True
                '    chkFinal.SetFocus
            End If
            If AddTran Then
                M = txtChkMgaNmbr.Text
                M1 = txtChkTrtyNmbr.Text
                M2 = txtChkPeriod.Text
                W = cboChkMga.SelectedIndex
                W1 = cboChkTrty.SelectedIndex
                '     InitChkLstForm
                AddTran = True
                txtChkMgaNmbr.Text = M
                txtChkTrtyNmbr.Text = M1
                txtChkPeriod.Text = M2
                ByPassCbo = True

                cboChkMga.SelectedIndex = W
                cboChkTrty.SelectedIndex = W1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtChkDate_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkDate.Enter
        Dim W As String
        Tobj = txtChkDate
        If Trim(txtChkDate.Text) = "" Then txtChkDate.Text = String.Format("{0:MM/dd/yyyy}", Date.Now)
        W = txtChkDate.Text
        txtChkDate.Text = Mid(W, 1, 2) & Mid(W, 4, 2) & Mid(W, 7, 4)
    End Sub

    Private Sub txtChkDate_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtChkDate.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtChkPeriod.Focus()
            Case Keys.Down
                chkFinal.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then chkFinal.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub txtChkDate_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtChkDate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtChkDate.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtChkDate_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtChkDate.Leave
        Dim W As String
        Tobj = txtChkDate

        W = txtChkDate.Text
        If Trim(W) <> "" Then
            txtChkDate.Text = Mid(W, 1, 2) & "/" & Mid(W, 3, 2) & "/" & Mid(W, 5, 4)
        End If
    End Sub

    Private Sub chkFinal_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkFinal.Enter
        Chkobj = chkFinal
    End Sub

    Private Sub chkFinal_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkFinal.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkFinal.CheckState = CheckState.Unchecked
            Case 49, 97
                chkFinal.CheckState = CheckState.Checked
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then chkReiRpt.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub chkFinal_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkFinal.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chkFinal_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkFinal.Leave
        Chkobj = chkFinal
        Chkobj.BackColor = Hcol
    End Sub

    Private Sub chkReiRpt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkReiRpt.Enter
        Chkobj = chkReiRpt
    End Sub

    Private Sub chkReiRpt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkReiRpt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkReiRpt.CheckState = CheckState.Unchecked
            Case 49, 97
                chkReiRpt.CheckState = CheckState.Checked
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then cboOpt.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub chkReiRpt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkReiRpt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chkReiRpt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkReiRpt.Leave
        Dim response As Short

        Chkobj = chkReiRpt
        Chkobj.BackColor = Hcol

        If Len(Trim(txtChkMgaNmbr.Text)) = 3 And Len(Trim(txtChkTrtyNmbr.Text)) = 2 And Len(Trim(txtChkPeriod.Text)) = 2 Then
            If AddTran Then
                response = MsgBox("Add Record", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Add Record")
            End If
            If UpdateTran Then
                response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
            End If
            If response = MsgBoxResult.Yes Then ProcessChkLstRec()
            If response = MsgBoxResult.No Then
                InitChkLstForm()
                txtChkMgaNmbr.Focus()
            End If
        End If

    End Sub

    Private Sub txtOptPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOptPeriod.Enter
        Tobj = txtOptPeriod
    End Sub

    Private Sub txtOptPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtOptPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                cboOpt.Focus()
            Case Keys.Down
                txtOptMga.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtOptMga.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub txtOptPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtOptPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtOptPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtOptPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOptPeriod.Leave
        Dim X As Integer

        Tobj = txtOptPeriod

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = S1

        If S1 = "00" Then
            Tobj.Text = ""
        End If

    End Sub

    Private Sub txtOptMga_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOptMga.Enter
        Tobj = txtOptMga
    End Sub

    Private Sub txtOptMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtOptMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Left
                txtOptPeriod.Focus()
            Case Keys.Right
                cboOpt.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtChkMgaNmbr.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub txtOptMga_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtOptMga.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtOptMga.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtOptMga_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOptMga.Leave
        Tobj = txtOptMga
        If cboOpt.SelectedIndex = 0 Then DspOptNotRecv()
        If cboOpt.SelectedIndex = 1 Then DspOptNoFinalChk()
        If cboOpt.SelectedIndex = 2 Then DspRptChkLst()
        If cboOpt.SelectedIndex = 3 Then DspAllPeriod()
    End Sub

    Private Sub ProcessChkLstRec()
        UpChkLstVars()

        If Val(txChkPeriod) < 1 Or Val(txChkPeriod) > 12 Then
            MsgBox("Invalid Period")
            GoTo exitS
        End If

        If Warry(Val(txChkPeriod)) <> 1 Then
            MsgBox("Period is closed")
            GoTo exitS
        End If

        If AddTran And cboChkTrty.SelectedIndex <> 0 Then AddChkLstRec()
        If UpdateTran And cboChkTrty.SelectedIndex <> 0 Then UpChkLstRec()

        If Not AddTran And Not UpdateTran Then MsgBox("No Record To Process")
        If cboChkTrty.SelectedIndex = 0 Then MsgBox("Invalid Treaty Record")

exitS:
        InitChkLstForm()
        txtChkMgaNmbr.Focus()
    End Sub

    Private Sub LoadCboMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboChkMga.Items.Clear()
        cboChkMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboChkMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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

        cboChkTrty.Items.Clear()
        cboChkTrty.Items.Add("Treaty Inactive or Not Setup")
        For X1 = 0 To d4recCount(f4)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
                Exit For
            End If
            If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec
            X = X + 1
            TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
            cboChkTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmDesc)))
nextrec:
            rc = d4skip(f4, 1)
        Next X1

        rc = d4bottom(f4)
        rc = d4unlock(f4)
    End Sub

    Private Sub InitChkLstForm()
        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtChkMgaNmbr.ReadOnly = False
        txtChkTrtyNmbr.ReadOnly = False
        txtChkPeriod.ReadOnly = False
        cboChkMga.ResetText()
        cboChkTrty.ResetText()
        txChkMgaNmbr = ""
        txChkTrtyNmbr = ""
        txChkPeriod = ""
        txChkDate = ""
        chChkFinal = 0
        chChkReiRpt = 0

        txtChkMgaNmbr.Text = ""
        txtChkTrtyNmbr.Text = ""
        txtChkPeriod.Text = ""
        txtChkDate.Text = ""
        chkFinal.CheckState = CheckState.Unchecked
        chkReiRpt.CheckState = CheckState.Unchecked
        lstOptDsp.Items.Clear()

        If DspStat = 0 Then
            txtOptMga.Text = ""
            txtOptPeriod.Text = ""
            cboOpt.SelectedIndex = 0
        End If

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboChkMga.SelectedIndex = 1
        cboChkTrty.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
        S1 = "  "

        'Load Display with all received
        Ostat = 99
        GetPeriodData()

        If DspStat = 0 Then DspAllChkLst()
        If DspStat = 1 Then DspOptNotRecv()
        If DspStat = 2 Then DspOptNoFinalChk()
        If DspStat = 3 Then DspRptChkLst()
        If DspStat = 4 Then DspAllPeriod()
    End Sub

    Sub DspAllChkLst()
        Dim T As Object
        Dim T1 As String
        Dim T2 As String


        'Display All MGAs if period is open
        Call d4tagSelect(f40, d4tag(f40, "K2"))
        rc = d4top(f40)
        rc = d4seek(f40, Trim(txtOptPeriod.Text))
        lstOptDsp.Items.Clear()
        lstOptDsp.Items.Add("All MGAs Received for all open periods")

        'Read MGA Checklist File
        Do Until rc = r4eof
            T = " "
            T1 = " "
            If Warry(Val(f4str(CKp.ChkPeriod))) <> 1 Then GoTo nextrec
            Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
            rc4 = d4seek(f4, Trim(f4str(CKp.ChkMgaNmbr)) & Trim(f4str(CKp.ChkTrtyNmbr)))
            If f4int(CKp.CkFinal) = 1 Then T = "X"
            If f4int(CKp.CkReiRpt) = 1 Then T1 = "X"
            T2 = f4str(TPp.PrmDesc)
            T2 = T2 + Space(30 - Len(T2))
            lstOptDsp.Items.Add(f4str(CKp.ChkMgaNmbr) & "  " & f4str(CKp.ChkTrtyNmbr) & "    " & T2 & "  " & f4str(CKp.ChkPeriod) & "    " & Pdate(f4str(CKp.ChkDate)) & "    " + T + "         " + T1)
nextrec:
            rc = d4skip(f40, 1)
        Loop

        rc = d4unlock(f40)
        rc = d4bottom(f40)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)
    End Sub

    Sub DspOptNotRecv()
        Dim T2 As String = " "

        'Display All MGAs Not Received
        Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
        rc = d4top(f4)
        rc = d4seek(f4, Trim(txtOptMga.Text))

        lstOptDsp.Items.Clear()
        lstOptDsp.Items.Add("All MGAs Not Received for period " & txtOptPeriod.Text)

        'Read Treaty Parm File
        Do Until rc = r4eof
            If Val(Trim(f4str(TPp.PrmStatus))) = 1 Or Val(Trim(f4str(TPp.PrmStatus))) = 2 Or Val(Trim(f4str(TPp.PrmStatus))) = 3 Then GoTo nextrec
            Call d4tagSelect(f40, d4tag(f40, "K2"))
            rc4 = d4seek(f40, Trim(txtOptPeriod.Text) & Trim(f4str(TPp.PrmMgaNmbr)) & Trim(f4str(TPp.PrmTrtyNmbr)))
            If rc4 = 0 Then GoTo nextrec
            T2 = T2 + Space(30 - Len(T2))
            T2 = f4str(TPp.PrmDesc)
            lstOptDsp.Items.Add(f4str(TPp.PrmMgaNmbr) & "  " & f4str(TPp.PrmTrtyNmbr) & "    " & T2 & "  " & Trim(txtOptPeriod.Text) & "    " & "Not Received")
nextrec:
            rc = d4skip(f4, 1)
        Loop

        rc = d4unlock(f4)
        rc = d4bottom(f4)
        rc4 = d4unlock(f40)
        rc4 = d4bottom(f40)
        DspStat = 1
    End Sub

    Sub DspOptNoFinalChk()
        Dim T, T1 As String
        Dim T2 As String = " "

        'Display All MGAs No Final Check
        Call d4tagSelect(f40, d4tag(f40, "K2"))
        rc = d4top(f40)
        rc = d4seek(f40, Trim(txtOptPeriod.Text) & Trim(txtOptMga.Text))

        lstOptDsp.Items.Clear()
        lstOptDsp.Items.Add("All MGAs wth no final check for period " & txtOptPeriod.Text)

        'Read MGA Checklist File
        Do Until rc = r4eof Or f4str(CKp.ChkPeriod) <> Trim(txtOptPeriod.Text)
            Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
            rc4 = d4seek(f4, Trim(f4str(CKp.ChkMgaNmbr)) & Trim(f4str(CKp.ChkTrtyNmbr)))
            T = " "
            T1 = " "
            If f4int(CKp.CkFinal) = 1 Then GoTo nextrec
            If f4int(CKp.CkReiRpt) = 1 Then T1 = "X"
            T2 = f4str(TPp.PrmDesc)
            lstOptDsp.Items.Add(f4str(CKp.ChkMgaNmbr) & "  " & f4str(CKp.ChkTrtyNmbr) & "   " & T2 & "  " & f4str(CKp.ChkPeriod) & "    " & Pdate(f4str(CKp.ChkDate)) & "    " + T + "         " + T1)
nextrec:
            rc = d4skip(f40, 1)
        Loop

        rc = d4unlock(f40)
        rc = d4bottom(f40)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)
        DspStat = 2
    End Sub

    Sub DspAllPeriod()
        Dim T, T1 As String
        Dim T2 As String = " "

        'Display All MGAs for specified period
        Call d4tagSelect(f40, d4tag(f40, "K2"))
        rc = d4top(f40)
        rc = d4seek(f40, Trim(txtOptPeriod.Text))
        lstOptDsp.Items.Clear()
        lstOptDsp.Items.Add("All MGAs Received for period " & txtOptPeriod.Text)

        'Read MGA Checklist File
        Do Until rc = r4eof
            T = " "
            T1 = " "
            If Warry(Val(txtOptPeriod.Text)) <> 1 Then GoTo nextrec
            Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
            rc4 = d4seek(f4, Trim(f4str(CKp.ChkMgaNmbr)) & Trim(f4str(CKp.ChkTrtyNmbr)))
            If f4int(CKp.CkFinal) = 1 Then T = "X"
            If f4int(CKp.CkReiRpt) = 1 Then T1 = "X"
            T2 = f4str(TPp.PrmDesc)
            T2 = T2 + Space(30 - Len(T2))
            lstOptDsp.Items.Add(f4str(CKp.ChkMgaNmbr) & "  " & f4str(CKp.ChkTrtyNmbr) & "   " & T2 & "   " & f4str(CKp.ChkPeriod) & "    " & Pdate(f4str(CKp.ChkDate)) & "    " + T + "         " + T1)
nextrec:
            rc = d4skip(f40, 1)
        Loop

        rc = d4unlock(f40)
        rc = d4bottom(f40)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)
        DspStat = 4
    End Sub

    Sub DspRptChkLst()
        Dim T2 As String

        'MGA Report Check List
        Call d4tagSelect(f3, d4tag(f3, "K2")) 'TREATY MASTER


        'Display Treaties
        lstOptDsp.Items.Clear()
        If atype = "A" Then lstOptDsp.Items.Add("Active MGA Report Check List")
        If atype = "U" Then lstOptDsp.Items.Add("Unactive MGA Report Check List")
        If atype = "P" Then lstOptDsp.Items.Add("Pending MGA Report Check List")
        lstOptDsp.Items.Add("____________________________________________________________")
        rc = d4top(f3)

        'Read Treaty Master File
        Do Until rc = r4eof
            Call d4tagSelect(f4, d4tag(f4, "K1"))
            rc4 = d4seek(f4, Trim(f4str(TMp.TrtyMgaNmbr)) & Trim(f4str(TMp.TrtyNmbr)))
            If atype = "A" Then If Val(Trim(f4str(TPp.PrmStatus))) <> 0 Then GoTo nextrec 'Active 
            If atype = "U" Then If Val(Trim(f4str(TPp.PrmStatus))) <> 1 And Val(Trim(f4str(TPp.PrmStatus))) <> 3 Then GoTo nextrec 'Inactive 
            If atype = "P" Then If Val(Trim(f4str(TPp.PrmStatus))) <> 2 Then GoTo nextrec 'Pending 
            T2 = f4str(TMp.TrtyDesc)
            T2 = T2 + Space(30 - Len(T2))
            lstOptDsp.Items.Add(T2 & " " & f4str(TMp.TrtyMgaNmbr) & "-" & f4str(TMp.TrtyNmbr))
nextrec:
            rc = d4skip(f3, 1)
        Loop

        rc = d4unlock(f3)
        rc = d4bottom(f3)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)

        DspStat = 0
    End Sub

    Sub PrtRptChkLst()
        'Print MGA Checklist Form
        Dim R As Single
        Dim T2 As String

        'Initialize
        T2 = "                              "
        PgCt = 0
        LnCt = 0
        R = 0

        prtobj.FontName = "Arial"

        'Print All Active Treaties
        Call d4tagSelect(f3, d4tag(f3, "K2")) 'TREATY MASTER
        rc = d4top(f3)

        'Read Treaty Master File
        Do Until rc = r4eof
            'Print Heading
            If PgCt = 0 Or LnCt > 58 Then
                prtobj.FontBold = True
                prtobj.FontSize = 10
                prtobj.FontUnderline = True
                SetPrtPos(5, 2)
                If atype = "A" Then prtobj.Print("HSCM Active MGA Report Check List")
                If atype = "U" Then prtobj.Print("HSCM Inactive MGA Report Check List")
                If atype = "P" Then prtobj.Print("HSCM Pending MGA Report Check List")
                prtobj.FontSize = 8
                SetPrtPos(5, 3.5)
                prtobj.Print("MGA NAME")
                SetPrtPos(32, 3.5)
                prtobj.Print("Number")
                SetPrtPos(43, 3.5)
                prtobj.Print("CTD")
                SetPrtPos(53, 3.5)
                prtobj.Print("REIN")
                prtobj.FontBold = False
                prtobj.FontUnderline = False
                R = 0.9
                PgCt = PgCt + 1
                LnCt = 0
            End If

            Call d4tagSelect(f4, d4tag(f4, "K1"))
            rc4 = d4seek(f4, Trim(f4str(TMp.TrtyMgaNmbr)) & Trim(f4str(TMp.TrtyNmbr)))
            If atype = "A" Then If Val(Trim(f4str(TPp.PrmStatus))) <> 0 Then GoTo nextrec 'Active 
            If atype = "U" Then If Val(Trim(f4str(TPp.PrmStatus))) <> 1 And Val(Trim(f4str(TPp.PrmStatus))) <> 3 Then GoTo nextrec 'Inactive 
            If atype = "P" Then If Val(Trim(f4str(TPp.PrmStatus))) <> 2 Then GoTo nextrec 'Pending 
            T2 = f4str(TMp.TrtyDesc)
            SetPrtPos(5, (4.1 + R))
            prtobj.Print(T2)
            SetPrtPos(33, (4.1 + R))
            prtobj.Print(f4str(TMp.TrtyMgaNmbr) & "-" & f4str(TMp.TrtyNmbr))
            SetPrtPos(43, (4.1 + R))
            prtobj.Print("_______")
            SetPrtPos(53, (4.1 + R))
            prtobj.Print("_______")
            SetPrtPos(63, (4.1 + R))
            prtobj.Print("_______")
            R = R + 0.9
            LnCt = CInt(R) + 4.1
            If LnCt > 58 Then PrtRptFooting()
nextrec:
            rc = d4skip(f3, 1)
        Loop

        If rc = r4eof Then PrtRptFooting()

        rc = d4unlock(f3)
        rc = d4bottom(f3)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)

        prtobj.EndDoc()
        DspStat = 0
    End Sub

    Sub RptOptNotRecv()
        Dim R As Single
        Dim T As Object
        Dim T1 As String
        Dim T2 As String

        'Initialize
        T2 = "                              "
        PgCt = 0
        LnCt = 0
        R = 0

        'Print All MGAs Not Received
        Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
        rc = d4top(f4)

        'Read Treaty Parm File
        Do Until rc = r4eof
            If Val(Trim(f4str(TPp.PrmStatus))) = 1 Or Val(Trim(f4str(TPp.PrmStatus))) = 2 Or Val(Trim(f4str(TPp.PrmStatus))) = 3 Then GoTo nextrec
            T = " "
            T1 = " "
            Call d4tagSelect(f40, d4tag(f40, "K2"))
            rc4 = d4seek(f40, Trim(txtOptPeriod.Text) & Trim(f4str(TPp.PrmMgaNmbr)) & Trim(f4str(TPp.PrmTrtyNmbr)))
            If rc4 = 0 Then GoTo nextrec

            'Print Heading
            If PgCt = 0 Or LnCt > 58 Then
                prtobj.FontBold = True
                prtobj.FontSize = 10
                SetPrtPos(5, 2)
                prtobj.Print("HSCM Monthly Reports Not Recieved for PERIOD: " & Trim(txtOptPeriod.Text) & "/" & Mid(Trim(Str(Parry(1))), 3, 2))
                prtobj.FontSize = 8
                prtobj.FontUnderline = True
                SetPrtPos(5, 3.5)
                prtobj.Print("MGA")
                SetPrtPos(9, 3.5)
                prtobj.Print("Treaty")
                SetPrtPos(15, 3.5)
                prtobj.Print("Treaty Name")
                SetPrtPos(47, 3.5)
                prtobj.Print("Period")
                SetPrtPos(53, 3.5)
                prtobj.Print("Received")
                SetPrtPos(64, 3.5)
                prtobj.Print("Final Check")
                SetPrtPos(75, 3.5)
                prtobj.Print("Reins Rpt")
                prtobj.FontBold = False
                prtobj.FontUnderline = False
                R = 0.9
                PgCt = PgCt + 1
                LnCt = 0
            End If
            T2 = f4str(TPp.PrmDesc)
            SetPrtPos(5, (3.5 + R))
            prtobj.Print(f4str(TPp.PrmMgaNmbr))
            SetPrtPos(9, (3.5 + R))
            prtobj.Print(f4str(TPp.PrmTrtyNmbr))
            SetPrtPos(15, (3.5 + R))
            prtobj.Print(T2)
            SetPrtPos(47, (3.5 + R))
            prtobj.Print(Trim(txtOptPeriod.Text))
            SetPrtPos(53, (3.5 + R))
            prtobj.Print("Not Received")
            LnCt = CInt(R) + 3.5
            R = R + 0.9
            If LnCt > 58 Then PrtRptFooting()
nextrec:
            rc = d4skip(f4, 1)
        Loop

        If rc = r4eof Then PrtRptFooting()

        prtobj.EndDoc()
        rc = d4unlock(f4)
        rc = d4bottom(f4)
        rc4 = d4unlock(f40)
        rc4 = d4bottom(f40)
        DspStat = 1

    End Sub

    Sub RptOptNoFinalChk()
        Dim R As Single
        Dim T As Object
        Dim T1 As String
        Dim T2 As String

        'Initialize
        T2 = "                              "
        PgCt = 0
        LnCt = 0
        R = 0

        'Display All MGAs No Final Check
        Call d4tagSelect(f40, d4tag(f40, "K2"))
        rc = d4top(f40)
        rc = d4seek(f40, Trim(txtOptPeriod.Text) & Trim(txtOptMga.Text))

        'Read MGA Checklist File
        Do Until rc = r4eof Or f4str(CKp.ChkPeriod) <> Trim(txtOptPeriod.Text)
            T = " "
            T1 = " "
            Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
            rc4 = d4seek(f4, Trim(f4str(CKp.ChkMgaNmbr)) & Trim(f4str(CKp.ChkTrtyNmbr)))
            If f4int(CKp.CkFinal) = 1 Then GoTo nextrec
            If f4int(CKp.CkReiRpt) = 1 Then T1 = "X"

            'Print Heading
            If PgCt = 0 Or LnCt > 58 Then
                prtobj.FontBold = True
                prtobj.FontSize = 10
                SetPrtPos(5, 2)
                prtobj.Print("HSCM Monthly Reports Received With No Final Check for PERIOD: " & Trim(txtOptPeriod.Text) & "/" & Mid(Trim(Str(Parry(1))), 3, 2))
                prtobj.FontSize = 8
                prtobj.FontUnderline = True
                SetPrtPos(5, 3.5)
                prtobj.Print("MGA")
                SetPrtPos(9, 3.5)
                prtobj.Print("Treaty")
                SetPrtPos(15, 3.5)
                prtobj.Print("Treaty Name")
                SetPrtPos(47, 3.5)
                prtobj.Print("Period")
                SetPrtPos(53, 3.5)
                prtobj.Print("Received")
                SetPrtPos(64, 3.5)
                prtobj.Print("Final Check")
                SetPrtPos(75, 3.5)
                prtobj.Print("Reins Rpt")
                prtobj.FontBold = False
                prtobj.FontUnderline = False
                R = 0.9
                PgCt = PgCt + 1
                LnCt = 0
            End If

            T2 = f4str(TPp.PrmDesc)
            SetPrtPos(5, (3.5 + R))
            prtobj.Print(f4str(CKp.ChkMgaNmbr))
            SetPrtPos(9, (3.5 + R))
            prtobj.Print(f4str(CKp.ChkTrtyNmbr))
            SetPrtPos(15, (3.5 + R))
            prtobj.Print(T2)
            SetPrtPos(47, (3.5 + R))
            prtobj.Print(f4str(CKp.ChkPeriod))
            SetPrtPos(53, (3.5 + R))
            prtobj.Print(Pdate(f4str(CKp.ChkDate)))
            SetPrtPos(67, (3.5 + R))
            prtobj.Print(T)
            SetPrtPos(77, (3.5 + R))
            prtobj.Print(T1)
            LnCt = CInt(R) + 3.5
            R = R + 0.9
            If LnCt > 58 Then PrtRptFooting()
nextrec:
            rc = d4skip(f40, 1)
        Loop

        If rc = r4eof Then PrtRptFooting()

        prtobj.EndDoc()

        rc = d4unlock(f40)
        rc = d4bottom(f40)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)
        DspStat = 2
    End Sub

    Sub RptAllChkLst()
        Dim R As Single
        Dim T As Object
        Dim T1 As String
        Dim T2 As String

        'Initialize
        PgCt = 0
        LnCt = 0
        R = 0

        'Display All MGAs if period is open
        Call d4tagSelect(f40, d4tag(f40, "K2"))
        rc = d4top(f40)
        rc = d4seek(f40, Trim(txtOptPeriod.Text))

        'Read MGA Checklist File
        Do Until rc = r4eof
            T = " "
            T1 = " "
            If Warry(Val(f4str(CKp.ChkPeriod))) <> 1 Then GoTo nextrec
            Call d4tagSelect(f4, d4tag(f4, "K1")) 'TREATY PARM
            rc4 = d4seek(f4, Trim(f4str(CKp.ChkMgaNmbr)) & Trim(f4str(CKp.ChkTrtyNmbr)))
            'Print Heading
            If PgCt = 0 Or LnCt > 58 Then
                prtobj.FontBold = True
                prtobj.FontSize = 10
                SetPrtPos(5, 2)
                prtobj.Print("HSCM All Monthly Reports Received For All Open Periods")
                prtobj.FontSize = 8
                prtobj.FontUnderline = True
                SetPrtPos(5, 3.5)
                prtobj.Print("MGA")
                SetPrtPos(9, 3.5)
                prtobj.Print("Treaty")
                SetPrtPos(15, 3.5)
                prtobj.Print("Treaty Name")
                SetPrtPos(47, 3.5)
                prtobj.Print("Period")
                SetPrtPos(53, 3.5)
                prtobj.Print("Received")
                SetPrtPos(64, 3.5)
                prtobj.Print("Final Check")
                SetPrtPos(75, 3.5)
                prtobj.Print("Reins Rpt")
                prtobj.FontBold = False
                prtobj.FontUnderline = False
                R = 0.9
                PgCt = PgCt + 1
                LnCt = 0
            End If

            If f4int(CKp.CkFinal) = 1 Then T = "X"
            If f4int(CKp.CkReiRpt) = 1 Then T1 = "X"
            T2 = f4str(TPp.PrmDesc)
            SetPrtPos(5, (3.5 + R))
            prtobj.Print(f4str(CKp.ChkMgaNmbr))
            SetPrtPos(9, (3.5 + R))
            prtobj.Print(f4str(CKp.ChkTrtyNmbr))
            SetPrtPos(15, (3.5 + R))
            prtobj.Print(T2)
            SetPrtPos(47, (3.5 + R))
            prtobj.Print(f4str(CKp.ChkPeriod))
            SetPrtPos(53, (3.5 + R))
            prtobj.Print(Pdate(f4str(CKp.ChkDate)))
            SetPrtPos(67, (3.5 + R))
            prtobj.Print(T)
            SetPrtPos(77, (3.5 + R))
            prtobj.Print(T1)
            LnCt = CInt(R) + 3.5
            R = R + 0.9
            If LnCt > 58 Then PrtRptFooting()
nextrec:
            rc = d4skip(f40, 1)
        Loop
        If rc = r4eof Then PrtRptFooting()

        prtobj.EndDoc()

        rc = d4unlock(f40)
        rc = d4bottom(f40)
        rc4 = d4unlock(f4)
        rc4 = d4bottom(f4)
    End Sub

    Private Sub PrtRptFooting()
        SetPrtPos(5, 62)
        prtobj.Print(DateTime.Now)
        SetPrtPos(48, 62)
        prtobj.Print(Format(PgCt, "##"))
        SetPrtPos(81, 62)
        prtobj.Print("Period : " & CurrPeriod & "/" & Mid(Trim(Str(Parry(1))), 3, 2))
        prtobj.NewPage()
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            DspStat = 0
            InitChkLstForm()
            txtChkMgaNmbr.Focus()
        End If
    End Sub

    Sub UpChkLstVars()
        txChkMgaNmbr = txtChkMgaNmbr.Text
        txChkTrtyNmbr = txtChkTrtyNmbr.Text
        txChkPeriod = txtChkPeriod.Text
        txChkDate = txtChkDate.Text
        chChkFinal = chkFinal.CheckState
        chChkReiRpt = chkReiRpt.CheckState
    End Sub

    Sub UpChkLstFrmVar()
        txtChkMgaNmbr.Text = txChkMgaNmbr
        txtChkTrtyNmbr.Text = txChkTrtyNmbr
        txtChkPeriod.Text = txChkPeriod
        txtChkDate.Text = txChkDate
        chkFinal.CheckState = chChkFinal
        chkReiRpt.CheckState = chChkReiRpt
    End Sub

End Class