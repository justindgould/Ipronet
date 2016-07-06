Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Friend Class frmIbnrPrmMnt
    Inherits DevExpress.XtraEditors.XtraForm

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

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then
                txtIbnrMgaNmbr.Text = Mid(Trim(cboMga.Text), 1, 3)
            End If
            txtIbnrTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboMga.Text), 1, 3)
            M1 = cboMga.SelectedIndex
            InitIbnrForm()
            txtIbnrMgaNmbr.Text = M
            cboMga.SelectedIndex = M1
            txtIbnrMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub
	
    Private Sub cboTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtIbnrTrtyNmbr.Text = Mid(Trim(cboTrty.Text), 1, 2)
        TrtyKey = Mid(Trim(cboMga.Text), 1, 3) & Mid(Trim(cboTrty.Text), 1, 2)
        txtIbnrTrtyNmbr.Focus()
    End Sub
	
    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub
	
    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        Dim response As Short

        If AddTran Then response = MsgBox("Add Record", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Add Record")
        If UpdateTran Then response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")

        If Not AddTran And Not UpdateTran Then MsgBox("No Record To Process")

        If response = MsgBoxResult.Yes Then
            ProcessIbnrRec()
            Exit Sub
        End If

        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitIbnrForm()
            txtIbnrMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cmdRecAction_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdRecAction.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub
	
    Private Sub cmdRecAction_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Leave
        cmdRecAction.Visible = False
    End Sub
	
    Private Sub frmIbnrPrmMnt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        OpenTrtyMst()
        OpenIbnrPrm()
        AddTran = False
        UpdateTran = False
        InitIbnrForm()
    End Sub
	
    Private Sub frmIbnrPrmMnt_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub
	

    Private Sub lstIbnrPrm_DoubleClick(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles lstIbnrPrm.DoubleClick
        IbnrPrmKey = Trim(txtIbnrPeriod.Text) & Trim(Mid(lstIbnrPrm.Text, 1, 9)) & Trim(txtIbnrMgaNmbr.Text) & Trim(txtIbnrTrtyNmbr.Text)

        GetIbnrPrmRec()

        If Fstat = r4locked Then
            AddTran = False
            UpdateTran = False
            InitIbnrForm()
            txtIbnrMgaNmbr.Focus()
            Exit Sub
        End If

        If UpdateTran Then
            UpIbnrPrmFrmVars()
            txtIbnrMgaNmbr.ReadOnly = True
            txtIbnrTrtyNmbr.ReadOnly = True
            txtIbnrPeriod.ReadOnly = True
            txtIbnrYear.ReadOnly = True
            txtIbnrPBfact.Focus()
            Exit Sub
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
        DelIbnrPrmRec()
        InitIbnrForm()
        txtIbnrMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuOexit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOexit.Click
        Me.Close()
    End Sub
	
    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitIbnrForm()
        txtIbnrMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuOprtibnr_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprtibnr.Click

        If Len(Trim(txtIbnrMgaNmbr.Text)) = 3 And Len(Trim(txtIbnrTrtyNmbr.Text)) = 2 And (Val(txtIbnrPeriod.Text) = 3 Or Val(txtIbnrPeriod.Text) = 6 Or Val(txtIbnrPeriod.Text) = 9 Or Val(txtIbnrPeriod.Text) = 12) Then
            PrtIbnrPrm()
        End If
    End Sub
	
    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub
	
    Public Sub mnuUdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelIbnrPrmRec()
        InitIbnrForm()
        txtIbnrMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitIbnrForm()
        txtIbnrMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub
	
    Private Sub txtIbnrMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrMgaNmbr.Enter
        Tobj = txtIbnrMgaNmbr
    End Sub
	
    Private Sub txtIbnrMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtIbnrTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtIbnrMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtIbnrMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrMgaNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String
        Dim X As Integer

        M = "   "

        If Tobj.Text = "000" Then
            Me.Close()
            Exit Sub
        End If

        M = RSet(Tobj.Text, Len(M))
        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If M = "000" Then M = ""
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
	
    Private Sub txtIbnrMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrMgaNmbr.Leave
        Dim X As Integer

        Tobj = txtIbnrMgaNmbr

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()
        If Fstat <> 0 Then
            If Tobj.Text <> "" And Tobj.Text <> "000" And Tobj.Text <> "999" Then
                MsgBox("MGA Master Record Does Not Exist.")
                txtIbnrMgaNmbr.Focus()
                Exit Sub
            End If
        End If

        If Tobj.Text = "000" Then Exit Sub
    End Sub
	
    Private Sub txtIbnrTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrTrtyNmbr.Enter
        Dim X As Integer

        Tobj = txtIbnrTrtyNmbr

        If Len(txtIbnrMgaNmbr.Text) > 0 Then
            For X = 1 To cboMga.Items.Count
                If MgaArray(X) = Trim(txtIbnrMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboMga.SelectedIndex = 0
        End If

    End Sub
	
    Private Sub txtIbnrTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrMgaNmbr.Focus()
            Case Keys.Down
                txtIbnrPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrPeriod.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtIbnrTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtIbnrTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrTrtyNmbr.KeyUp
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
                    If Len(Tobj.Text) > 2 Then Exit For
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
	
    Private Sub txtIbnrTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrTrtyNmbr.Leave
        Dim X As Integer

        Tobj = txtIbnrTrtyNmbr

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        TrtyKey = Trim(txtIbnrMgaNmbr.Text) & Trim(txtIbnrTrtyNmbr.Text)
        RdTrtyMstRec()
        If Fstat <> 0 Then
            If Tobj.Text <> "" And Tobj.Text <> "99" And Tobj.Text <> "00" Then
                MsgBox("Treaty Record Does Not Exist.")
                Exit Sub
            End If
        End If

        If Tobj.Text = "00" Then
            txtIbnrMgaNmbr.Focus()
            Tobj.Text = ""
            Exit Sub
        End If
    End Sub
	
    Private Sub txtIbnrPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrPeriod.Enter
        Dim X As Integer

        ByPassTxt = False
        Tobj = txtIbnrPeriod

        If Len(txtIbnrMgaNmbr.Text) > 0 Then
            For X = 0 To cboTrty.Items.Count
                If TrtyArray(X) = Trim(txtIbnrTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboTrty.SelectedIndex = X
                    ByPassCbo = False
                    If Trim(txtIbnrPeriod.Text) = "" Then txtIbnrPeriod.Text = CurrPeriod
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboTrty.SelectedIndex = 0
            ByPassCbo = False
        End If

    End Sub
	
    Private Sub txtIbnrPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrTrtyNmbr.Focus()
            Case Keys.Down
                txtIbnrYear.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrYear.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtIbnrPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtIbnrPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrPeriod.Leave
        Dim X As Integer

        Tobj = txtIbnrPeriod

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = S1

        If S1 = "00" Then Tobj.Text = ""

        'Check for Valid Period
        If Not ByPassTxt Then
            If Val(S1) <> 3 And Val(S1) <> 6 And Val(S1) <> 9 And Val(S1) <> 12 And Val(S1) <> 0 Then
                MsgBox("Invalid Period")
                Exit Sub
            End If
        End If

        If Len(Trim(txtIbnrMgaNmbr.Text)) = 3 And Len(Trim(txtIbnrTrtyNmbr.Text)) = 2 And (Val(S1) = 3 Or Val(S1) = 6 Or Val(S1) = 9 Or Val(S1) = 12) Then
            If optLossFactors.Checked Then LoadIbnrLossLst()
            If optLaeFactors.Checked Then LoadIbnrLaeLst()
        End If

    End Sub
	
    Private Sub txtIbnrYear_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrYear.Enter
        Tobj = txtIbnrYear
    End Sub
	
    Private Sub txtIbnrYear_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrYear.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrPeriod.Focus()
            Case Keys.Down
                txtIbnrCBfact.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrPBfact.Focus()
        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtIbnrYear_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrYear.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrYear.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtIbnrYear_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrYear.Leave
        Dim M2, M, M1 As Object
        Dim M4 As String
        Dim W, W1 As Object

        Tobj = txtIbnrYear

        'Continue
        IbnrPrmKey = Trim(txtIbnrPeriod.Text) & Trim(txtIbnrYear.Text) & Trim(txtIbnrMgaNmbr.Text) & Trim(txtIbnrTrtyNmbr.Text)

        If Trim(IbnrPrmKey) <> "" Then GetIbnrPrmRec()
        If Trim(IbnrPrmKey) = "" Then Exit Sub

        If Fstat = r4locked Then
            AddTran = False
            UpdateTran = False
            InitIbnrForm()
            txtIbnrMgaNmbr.Focus()
            Exit Sub
        End If

        If UpdateTran Then
            UpIbnrPrmFrmVars()
            txtIbnrMgaNmbr.ReadOnly = True
            txtIbnrTrtyNmbr.ReadOnly = True
            txtIbnrPeriod.ReadOnly = True
            txtIbnrYear.ReadOnly = True
            txtIbnrPBfact.Focus()
            Exit Sub
        End If

        If AddTran Then
            M = txtIbnrMgaNmbr.Text
            M1 = txtIbnrTrtyNmbr.Text
            M2 = txtIbnrPeriod.Text
            M4 = txtIbnrYear.Text
            W = cboMga.SelectedIndex
            W1 = cboTrty.SelectedIndex
            AddTran = True
            txtIbnrMgaNmbr.Text = M
            txtIbnrTrtyNmbr.Text = M1
            txtIbnrPeriod.Text = M2
            txtIbnrYear.Text = M4
            ByPassCbo = True
            cboMga.SelectedIndex = W
            cboTrty.SelectedIndex = W1
            ByPassCbo = False
        End If
    End Sub
	
    Private Sub txtIbnrPBfact_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrPBfact.Enter
        Tobj = txtIbnrPBfact
    End Sub

    Private Sub txtIbnrPBfact_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrPBfact.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrYear.Focus()
            Case Keys.Down
                txtIbnrPMfact.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrPMfact.Focus()
    End Sub

    Private Sub txtIbnrPBfact_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrPBfact.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrPBfact.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtIbnrPBfact_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrPBfact.Leave
        Tobj = txtIbnrPBfact
        Tobj.Text = Format(Val(Tobj.Text), "#.000000")
    End Sub

    Private Sub txtIbnrPMfact_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrPMfact.Enter
        Tobj = txtIbnrPMfact
    End Sub

    Private Sub txtIbnrPMfact_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrPMfact.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrPBfact.Focus()
            Case Keys.Down
                txtIbnrCBfact.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrCBfact.Focus()
    End Sub

    Private Sub txtIbnrPMfact_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrPMfact.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrPMfact.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtIbnrPMfact_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrPMfact.Leave
        Tobj = txtIbnrPMfact
        Tobj.Text = Format(Val(Tobj.Text), "#.000000")
    End Sub

    Private Sub txtIbnrCBfact_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrCBfact.Enter
        Tobj = txtIbnrCBfact
    End Sub

    Private Sub txtIbnrCBfact_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrCBfact.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrPMfact.Focus()
            Case Keys.Down
                txtIbnrCMfact.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrCMfact.Focus()
    End Sub

    Private Sub txtIbnrCBfact_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrCBfact.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrCBfact.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtIbnrCBfact_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrCBfact.Leave
        Tobj = txtIbnrCBfact
        Tobj.Text = Format(Val(Tobj.Text), "#.000000")
    End Sub

    Private Sub txtIbnrCMfact_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrCMfact.Enter
        Tobj = txtIbnrCMfact
    End Sub

    Private Sub txtIbnrCMfact_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrCMfact.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrCBfact.Focus()
            Case Keys.Down
                txtIbnrOTfact.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtIbnrOTfact.Focus()
    End Sub

    Private Sub txtIbnrCMfact_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrCMfact.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrCMfact.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtIbnrCMfact_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrCMfact.Leave
        Tobj = txtIbnrCMfact
        Tobj.Text = Format(Val(Tobj.Text), "#.000000")
    End Sub

    Private Sub txtIbnrOTfact_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrOTfact.Enter
        Tobj = txtIbnrOTfact
    End Sub

    Private Sub txtIbnrOTfact_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtIbnrOTfact.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtIbnrCMfact.Focus()
            Case Keys.Down
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If
    End Sub

    Private Sub txtIbnrOTfact_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtIbnrOTfact.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtIbnrOTfact.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtIbnrOTfact_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtIbnrOTfact.Leave
        Tobj = txtIbnrOTfact
        Tobj.Text = Format(Val(Tobj.Text), "#.000000")
    End Sub

    Private Sub InitIbnrForm()

        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        Utrtymst = True
        Utrtyrei = False
        txtIbnrMgaNmbr.ReadOnly = False
        txtIbnrTrtyNmbr.ReadOnly = False
        txtIbnrPeriod.ReadOnly = False
        txtIbnrYear.ReadOnly = False
        cboMga.ResetText()
        cboTrty.ResetText()
        cmdRecAction.Visible = False

        txIbnrMgaNmbr = ""
        txIbnrTrtyNmbr = ""
        txIbnrPeriod = ""
        txIbnrYear = ""
        txIbnrLossPBfact = ""
        txIbnrLossPMfact = ""
        txIbnrLossCBfact = ""
        txIbnrLossCMfact = ""
        txIbnrLossOTfact = ""
        txIbnrLaePBfact = ""
        txIbnrLaePMfact = ""
        txIbnrLaeCBfact = ""
        txIbnrLaeCMfact = ""
        txIbnrLaeOTfact = ""


        txtIbnrMgaNmbr.Text = ""
        txtIbnrTrtyNmbr.Text = ""
        txtIbnrPeriod.Text = ""
        txtIbnrYear.Text = ""
        txtIbnrPBfact.Text = ""
        txtIbnrPMfact.Text = ""
        txtIbnrCBfact.Text = ""
        txtIbnrCMfact.Text = ""
        txtIbnrOTfact.Text = ""

        lstIbnrPrm.Items.Clear()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 0
        cboTrty.SelectedIndex = 0
        ByPassCbo = False

        s = "   "
        S1 = "  "
    End Sub

    Private Sub LoadCboMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboMga.Items.Clear()
        cboMga.Items.Add("999  All MGAs")

        Do Until rc = r4eof
            cboMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
            X = X + 1
            If Trim(f4str(Mp.MgaNmbr)) <> "" Then MgaArray(X) = Trim(f4str(Mp.MgaNmbr))
            rc = d4skip(f1, 1)
        Loop

        rc = d4bottom(f1)
        rc = d4unlock(f1)
    End Sub

    Private Sub LoadCboTrty()
        Dim X1 As Short
        X = 0
        ReDim TrtyArray(d4recCount(f3) + 1)
        rc = d4top(f3)

        Call d4tagSelect(f3, d4tag(f3, "K1"))
        rc = d4seek(f3, TrtyKey)

        cboTrty.Items.Clear()
        cboTrty.Items.Add("99 All Treaties")

        For X1 = 0 To d4recCount(f3)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TMp.TrtyMgaNmbr)), 1, 3) Then
                Exit For
            End If
            X = X + 1
            If Trim(f4str(TMp.TrtyNmbr)) <> "" Then TrtyArray(X) = Trim(f4str(TMp.TrtyNmbr))
            cboTrty.Items.Add(Trim(f4str(TMp.TrtyNmbr)) & "   " & Trim(f4str(TMp.TrtyDesc)))
            rc = d4skip(f3, 1)
        Next X1

        rc = d4bottom(f3)
        rc = d4unlock(f3)
    End Sub

    Private Sub ProcessIbnrRec()
        Dim Y2, Y, Y1 As Object
        Dim U, U1 As Object

        UpIbnrPrmVars()
        If AddTran Then AddIbnrPrmRec()
        If UpdateTran Then UpIbnrPrmRec()


        Y = txtIbnrMgaNmbr.Text
        Y1 = txtIbnrTrtyNmbr.Text
        Y2 = txtIbnrPeriod.Text
        U = cboMga.SelectedIndex
        U1 = cboTrty.SelectedIndex

        InitIbnrForm()

        ByPassTxt = True
        txtIbnrMgaNmbr.Text = Y
        txtIbnrTrtyNmbr.Text = Y1
        txtIbnrPeriod.Text = Y2
        ByPassCbo = True
        cboMga.SelectedIndex = U
        cboTrty.SelectedIndex = U1
        ByPassCbo = False
        ByPassTxt = False

        If Len(Trim(txtIbnrMgaNmbr.Text)) = 3 And Len(Trim(txtIbnrTrtyNmbr.Text)) = 2 And (Val(Y2) = 3 Or Val(Y2) = 6 Or Val(Y2) = 9 Or Val(Y2) = 12) Then
            If optLossFactors.Checked Then LoadIbnrLossLst()
            If optLaeFactors.Checked Then LoadIbnrLaeLst()
        End If

        txtIbnrYear.Focus()
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitIbnrForm()
            txtIbnrMgaNmbr.Focus()
        End If
    End Sub

    Private Sub LoadIbnrLossLst()
        Dim X1 As Short

        Call d4tagSelect(f25, d4tag(f25, "K2"))
        rc = d4top(f25)

        lstIbnrPrm.Items.Clear()

        For X1 = 0 To d4recCount(f25)
            If (Trim(f4str(IFp.IbnrPeriod)) & Trim(f4str(IFp.IbnrMgaNmbr))) <> (Trim(txtIbnrPeriod.Text) & Trim(txtIbnrMgaNmbr.Text)) Then GoTo nextrec
            lstIbnrPrm.Items.Add("    " & Trim(f4str(IFp.IbnrYear)) & "    " & Format(f4double(IFp.IbnrLossPBfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLossPMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLossCBfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLossCMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLossOTfact), "0.000000"))

nextrec:
            rc = d4skip(f25, 1)
        Next X1

        rc = d4bottom(f25)
        rc = d4unlock(f25)
    End Sub

    Private Sub LoadIbnrLaeLst()
        Dim X1 As Short

        Call d4tagSelect(f25, d4tag(f25, "K2"))
        rc = d4top(f25)

        lstIbnrPrm.Items.Clear()

        For X1 = 0 To d4recCount(f25)
            If (Trim(f4str(IFp.IbnrPeriod)) & Trim(f4str(IFp.IbnrMgaNmbr))) <> (Trim(txtIbnrPeriod.Text) & Trim(txtIbnrMgaNmbr.Text)) Then GoTo nextrec
            lstIbnrPrm.Items.Add("    " & Trim(f4str(IFp.IbnrYear)) & "    " & Format(f4double(IFp.IbnrLaePBfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLaePMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLaeCBfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLaeCMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLaeOTfact), "0.000000"))

nextrec:
            rc = d4skip(f25, 1)
        Next X1

        rc = d4bottom(f25)
        rc = d4unlock(f25)
    End Sub

    Private Sub PrtIbnrPrm()
        Dim X1 As Short
        Dim J4str As String

        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.P
        Next

        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True

        J4str = " "
        If txtIbnrPeriod.Text = "03" Then J4str = "March 31"
        If txtIbnrPeriod.Text = "06" Then J4str = "June 30"
        If txtIbnrPeriod.Text = "09" Then J4str = "September 30"
        If txtIbnrPeriod.Text = "12" Then J4str = "December 31"

        'Print Loss IBNR Factors
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("LOSS IBNR Parameter Factors For MGA: " & Trim(txtIbnrMgaNmbr.Text))
        prtobj.Print("Quarter " & Trim(Str(Val(txtIbnrPeriod.Text) / 3)) & " - Period Ending " & J4str & " " & Format(Parry(1), "000#"))
        prtobj.Print()
        prtobj.Print("Year " & "   PP Liab" & "   PP Phydam" & "    CM Liab" & "   CM Phydam" & "      Other")

        Call d4tagSelect(f25, d4tag(f25, "K2"))
        rc = d4top(f25)

        lstIbnrPrm.Items.Clear()

        For X1 = 0 To d4recCount(f25)
            If (Trim(f4str(IFp.IbnrPeriod)) & Trim(f4str(IFp.IbnrMgaNmbr))) <> (Trim(txtIbnrPeriod.Text) & Trim(txtIbnrMgaNmbr.Text)) Then GoTo nextrec
            prtobj.Print(Trim(f4str(IFp.IbnrYear)) & "   " & Format(f4double(IFp.IbnrLossPBfact), "0.000000") & "    " & Format(f4double(IFp.IbnrLossPMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLossCBfact), "0.000000") & "    " & Format(f4double(IFp.IbnrLossCMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLossOTfact), "0.000000"))
nextrec:
            rc = d4skip(f25, 1)
        Next X1

        'Print LAE IBNR Factors
        prtobj.NewPage()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("LAE IBNR Parameter Factors For MGA: " & Trim(txtIbnrMgaNmbr.Text))
        prtobj.Print("Quarter " & Trim(Str(Val(txtIbnrPeriod.Text) / 3)) & " - Period Ending " & J4str & " " & Format(Parry(1), "000#"))
        prtobj.Print()
        prtobj.Print("Year " & "   PP Liab" & "   PP Phydam" & "    CM Liab" & "   CM Phydam" & "      Other")

        Call d4tagSelect(f25, d4tag(f25, "K2"))
        rc = d4top(f25)

        For X1 = 0 To d4recCount(f25)

            If (Trim(f4str(IFp.IbnrPeriod)) & Trim(f4str(IFp.IbnrMgaNmbr))) <> (Trim(txtIbnrPeriod.Text) & Trim(txtIbnrMgaNmbr.Text)) Then GoTo nextrec1

            prtobj.Print(Trim(f4str(IFp.IbnrYear)) & "   " & Format(f4double(IFp.IbnrLaePBfact), "0.000000") & "    " & Format(f4double(IFp.IbnrLaePMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLaeCBfact), "0.000000") & "    " & Format(f4double(IFp.IbnrLaeCMfact), "0.000000") & "   " & Format(f4double(IFp.IbnrLaeOTfact), "0.000000"))
nextrec1:
            rc = d4skip(f25, 1)
        Next X1

        prtobj.EndDoc()
        prtobj.FontBold = False

        rc = d4bottom(f25)
        rc = d4unlock(f25)

        If optLossFactors.Checked Then LoadIbnrLossLst()
        If optLaeFactors.Checked Then LoadIbnrLaeLst()
    End Sub

    Sub UpIbnrPrmVars()
        txIbnrMgaNmbr = txtIbnrMgaNmbr.Text
        txIbnrTrtyNmbr = txtIbnrTrtyNmbr.Text
        txIbnrPeriod = txtIbnrPeriod.Text
        txIbnrYear = txtIbnrYear.Text

        If optLossFactors.Checked Then
            txIbnrLossPBfact = txtIbnrPBfact.Text
            txIbnrLossPMfact = txtIbnrPMfact.Text
            txIbnrLossCBfact = txtIbnrCBfact.Text
            txIbnrLossCMfact = txtIbnrCMfact.Text
            txIbnrLossOTfact = txtIbnrOTfact.Text
        End If

        If optLaeFactors.Checked Then
            txIbnrLaePBfact = txtIbnrPBfact.Text
            txIbnrLaePMfact = txtIbnrPMfact.Text
            txIbnrLaeCBfact = txtIbnrCBfact.Text
            txIbnrLaeCMfact = txtIbnrCMfact.Text
            txIbnrLaeOTfact = txtIbnrOTfact.Text
        End If

    End Sub

    Public Sub UpIbnrPrmFrmVars()
        txtIbnrMgaNmbr.Text = txIbnrMgaNmbr
        txtIbnrTrtyNmbr.Text = txIbnrTrtyNmbr
        txtIbnrPeriod.Text = txIbnrPeriod
        txtIbnrYear.Text = txIbnrYear

        If optLossFactors.Checked Then
            txtIbnrPBfact.Text = txIbnrLossPBfact
            txtIbnrPMfact.Text = txIbnrLossPMfact
            txtIbnrCBfact.Text = txIbnrLossCBfact
            txtIbnrCMfact.Text = txIbnrLossCMfact
            txtIbnrOTfact.Text = txIbnrLossOTfact
        End If

        If optLaeFactors.Checked Then
            txtIbnrPBfact.Text = txIbnrLaePBfact
            txtIbnrPMfact.Text = txIbnrLaePMfact
            txtIbnrCBfact.Text = txIbnrLaeCBfact
            txtIbnrCMfact.Text = txIbnrLaeCMfact
            txtIbnrOTfact.Text = txIbnrLaeOTfact
        End If

    End Sub
End Class