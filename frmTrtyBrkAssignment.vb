Option Strict Off
Option Explicit On

Friend Class frmTrtyBrkAssignment
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub cboBrkTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboBrkTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        If Not AddTran And Not UpdateTran Then
            txtBrkTrtyNmbr.Text = Mid(Trim(cboBrkTrty.Text), 1, 2)
        End If
        TrtyKey = Mid(Trim(cboBrkTrtyMga.Text), 1, 3) & Mid(Trim(cboBrkTrty.Text), 1, 2)
        GetTrtyPrmRec()
        txtBrkMgaNmbr.ReadOnly = True
        txtBrkTrtyNmbr.ReadOnly = True
        txtBrkNmbrAssigned.Focus()
    End Sub

    Private Sub cboBrkTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboBrkTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboBrkName_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboBrkName.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        If Not AddTran And Not UpdateTran Then
            txtBrkTrtyNmbr.Text = Mid(Trim(cboBrkTrty.Text), 1, 2)
        End If
        TrtyKey = Mid(Trim(cboBrkTrtyMga.Text), 1, 3) & Mid(Trim(cboBrkTrty.Text), 1, 2)
        GetBrkTrtyRec()
        UpBrkTrtyFrmVar()
        txtBrkMgaNmbr.ReadOnly = True
        txtBrkTrtyNmbr.ReadOnly = True
        txtBrkNmbrAssigned.Focus()
    End Sub

    Private Sub cboBrkName_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboBrkName.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboBrkTrtyMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboBrkTrtyMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboBrkTrtyMga.Text), 1, 3)
        LoadCboPrm()

        ByPassCbo = True
        If cboBrkTrty.Items.Count > 1 Then
            cboBrkTrty.SelectedIndex = 1
        Else
            cboBrkTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then txtBrkMgaNmbr.Text = Mid(Trim(cboBrkTrtyMga.Text), 1, 3)
            txtBrkTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboBrkTrtyMga.Text), 1, 3)
            M1 = cboBrkTrtyMga.SelectedIndex
            InitBrkTrtyForm()
            txtBrkMgaNmbr.Text = M
            cboBrkTrtyMga.SelectedIndex = M1
            txtBrkTrtyNmbr.Text = ""
            txtBrkMgaNmbr.Focus()
        End If

    End Sub

    Private Sub cboBrkTrtyMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboBrkTrtyMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        Dim response As Short

        If AddTran Then
            response = MsgBox("Add Record", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Add Record")
        End If
        If UpdateTran Then
            response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
        End If
        If Not AddTran And Not UpdateTran Then MsgBox("No Record To Process")
        If response = MsgBoxResult.Yes Then ProcessBrkTrtyRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitBrkTrtyForm()
            txtBrkMgaNmbr.Focus()
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

    Private Sub frmTrtyBrkAssignment_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        OpenTrtyPrm()
        OpenBrkMst()
        OpenBrkTrty()

        AddTran = False
        UpdateTran = False
        InitBrkTrtyForm()
    End Sub

    Private Sub frmTrtyBrkAssignment_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Public Sub mnuOdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelBrkTrtyRec()
        InitBrkTrtyForm()
        txtBrkMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitBrkTrtyForm()
        txtBrkMgaNmbr.Focus()
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
        DelBrkTrtyRec()
        InitBrkTrtyForm()
        txtBrkMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitBrkTrtyForm()
        txtBrkMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtBrkMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkMgaNmbr.Enter
        Tobj = txtBrkMgaNmbr
    End Sub

    Private Sub txtbrkMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtBrkTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtBrkMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkMgaNmbr.KeyUp
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
                For X = 1 To cboBrkTrtyMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboBrkTrtyMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboBrkTrtyMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If

    End Sub

    Private Sub txtBrkMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkMgaNmbr.Leave
        Dim X As Integer

        Tobj = txtBrkMgaNmbr
        s = "   "
        s = RSet(Tobj.Text, Len(s))
        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next
        Tobj.Text = s

        If s = "000" Then Tobj.Text = ""

        MgaKey = s
        RdMgaMstRec()

        If Fstat <> 0 Then
            If Tobj.Text <> "" Then
                MsgBox("MGA Master Record Does Not Exist.")
                txtBrkMgaNmbr.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtBrkTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTrtyNmbr.Enter
        Dim X As Integer

        Tobj = txtBrkTrtyNmbr

        For X = 1 To cboBrkTrtyMga.Items.Count
            If MgaArray(X) = Trim(txtBrkMgaNmbr.Text) Then
                ByPassTxt = True
                cboBrkTrtyMga.SelectedIndex = X
                ByPassTxt = False
                Exit Sub
            End If
        Next X
        cboBrkTrtyMga.SelectedIndex = 0
    End Sub

    Private Sub txtBrkTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkMgaNmbr.Focus()
            Case Keys.Down
                txtBrkNmbrAssigned.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkNmbrAssigned.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtBrkTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkTrtyNmbr.KeyUp
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
                For X = 0 To cboBrkTrty.Items.Count
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboBrkTrty.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboBrkTrty.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtBrkTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTrtyNmbr.Leave
        Dim X As Integer

        Tobj = txtBrkTrtyNmbr

        s = "  "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 2
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s
    End Sub

    Private Sub txtBrkNmbrAssigned_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkNmbrAssigned.Enter
        Tobj = txtBrkNmbrAssigned
    End Sub

    Private Sub txtBrkNmbrAssigned_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkNmbrAssigned.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkTrtyNmbr.Focus()
            Case Keys.Down
                txtBrkTrtyEffDate.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkTrtyEffDate.Focus()
    End Sub

    Private Sub txtBrkNmbrAssigned_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkNmbrAssigned.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkNmbrAssigned.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkNmbrAssigned_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkNmbrAssigned.KeyUp
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

        If M = "000" Then M = ""
        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 0 To cboBrkName.Items.Count
                    If BrkArray(X) = M Then
                        ByPassCbo = True
                        cboBrkName.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboBrkName.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtBrkNmbrAssigned_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkNmbrAssigned.Leave
        Dim M, M1 As Object
        Dim M2 As String
        Dim W, W1 As Object
        Dim W2 As Short
        Dim X As Integer

        Tobj = txtBrkNmbrAssigned

        S1 = "   "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 3
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        If S1 = "000" Then
            Tobj.Text = ""
        End If

        If Len(Trim(txtBrkMgaNmbr.Text)) = 3 And Len(Trim(txtBrkTrtyNmbr.Text)) = 2 And Len(Trim(Tobj.Text)) = 3 Then
            BrkTrtyKey = Trim(txtBrkMgaNmbr.Text) & Trim(txtBrkTrtyNmbr.Text) & Trim(txtBrkNmbrAssigned.Text)
            GetBrkTrtyRec()
            If UpdateTran Then
                UpBrkTrtyFrmVar()
                txtBrkMgaNmbr.ReadOnly = True
                txtBrkTrtyNmbr.ReadOnly = True
                txtBrkNmbrAssigned.ReadOnly = True
            End If
            If AddTran Then
                M = txtBrkMgaNmbr.Text
                M1 = txtBrkTrtyNmbr.Text
                M2 = txtBrkNmbrAssigned.Text
                W = cboBrkTrtyMga.SelectedIndex
                W1 = cboBrkTrty.SelectedIndex
                W2 = cboBrkName.SelectedIndex
                AddTran = True
                ByPassCbo = True
                cboBrkTrtyMga.SelectedIndex = W
                cboBrkTrty.SelectedIndex = W1
                cboBrkName.SelectedIndex = W2
                txtBrkMgaNmbr.Text = M
                txtBrkTrtyNmbr.Text = M1
                txtBrkNmbrAssigned.Text = M2
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtBrkTrtyEffDate_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTrtyEffDate.Enter
        Tobj = txtBrkTrtyEffDate
        txtBrkTrtyEffDate.Text = txBrkTrtyEffDate
    End Sub

    Private Sub txtBrkTrtyEffDate_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkTrtyEffDate.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkNmbrAssigned.Focus()
            Case Keys.Down
                txtBrkCcDueDate.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkCcDueDate.Focus()
    End Sub

    Private Sub txtBrkTrtyEffDate_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkTrtyEffDate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkTrtyEffDate.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkTrtyEffDate_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTrtyEffDate.Leave
        Tobj = txtBrkTrtyEffDate
        txBrkTrtyEffDate = txtBrkTrtyEffDate.Text
        txtBrkTrtyEffDate.Text = Pdate(txBrkTrtyEffDate)
    End Sub

    Private Sub txtBrkCcDueDate_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkCcDueDate.Enter
        Tobj = txtBrkCcDueDate
        txtBrkCcDueDate.Text = txBrkCcDueDate
    End Sub

    Private Sub txtBrkCcDueDate_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkCcDueDate.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkTrtyEffDate.Focus()
            Case Keys.Down
                txtBrkStatus.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkStatus.Focus()
    End Sub

    Private Sub txtBrkCcDueDate_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkCcDueDate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkCcDueDate.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkCcDueDate_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkCcDueDate.Leave
        Tobj = txtBrkCcDueDate
        txBrkCcDueDate = txtBrkCcDueDate.Text
        txtBrkCcDueDate.Text = Pdate(txBrkCcDueDate)
    End Sub

    Private Sub txtBrkStatus_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkStatus.Enter
        Tobj = txtBrkStatus
    End Sub

    Private Sub txtBrkStatus_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkStatus.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkCcDueDate.Focus()
            Case Keys.Down
                txtBrkTrtyDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkTrtyDesc.Focus()
    End Sub

    Private Sub txtBrkStatus_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkStatus.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkStatus.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkStatus_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkStatus.Leave
        Tobj = txtBrkStatus
    End Sub

    Private Sub txtBrkTrtyDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTrtyDesc.Enter
        Tobj = txtBrkTrtyDesc
    End Sub

    Private Sub txtBrkTrtyDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkTrtyDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkStatus.Focus()
            Case Keys.Down
                txtBrkCcDueDate.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then
            If Len(Trim(txtBrkMgaNmbr.Text)) = 3 And Len(Trim(txtBrkTrtyNmbr.Text)) = 2 And Len(Trim(txtBrkNmbrAssigned.Text)) = 3 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If

    End Sub

    Private Sub txtBrkTrtyDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkTrtyDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkTrtyDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkTrtyDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTrtyDesc.Leave
        Tobj = txtBrkTrtyDesc

        If Len(Trim(txtBrkMgaNmbr.Text)) = 3 And Len(Trim(txtBrkTrtyNmbr.Text)) = 2 And Len(Trim(txtBrkNmbrAssigned.Text)) = 2 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If

    End Sub

    Private Sub ProcessBrkTrtyRec()
        UpBrkTrtyVars()
        If AddTran Then AddBrkTrtyRec()
        If UpdateTran Then UpBrkTrtyRec()

        InitBrkTrtyForm()
        txtBrkMgaNmbr.Focus()
    End Sub

    Private Sub LoadCboBrkMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboBrkTrtyMga.Items.Clear()
        cboBrkTrtyMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboBrkTrtyMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
            X = X + 1
            MgaArray(X) = Trim(f4str(Mp.MgaNmbr))
            rc = d4skip(f1, 1)
        Loop

        rc = d4bottom(f1)
        rc = d4unlock(f1)
    End Sub

    Private Sub LoadCboPrm()
        Dim X1 As Short
        X = 0
        ReDim TrtyArray(d4recCount(f4) + 1)
        rc = d4top(f4)

        Call d4tagSelect(f4, d4tag(f4, "K1"))
        rc = d4seek(f4, TrtyKey)

        cboBrkTrty.Items.Clear()
        cboBrkTrty.Items.Add("Treaty Parm Not Setup")
        For X1 = 0 To d4recCount(f4)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
                Exit For
            End If
            X = X + 1
            TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
            cboBrkTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmRptName)))
            rc = d4skip(f4, 1)
        Next X1

        rc = d4bottom(f4)
        rc = d4unlock(f4)
    End Sub

    Private Sub LoadCboBrk()
        X = 0
        rc = d4top(f35)
        ReDim BrkArray(d4recCount(f35) + 1)

        Call d4tagSelect(f35, d4tag(f35, "K1"))

        cboBrkName.Items.Clear()
        cboBrkName.Items.Add("Broker Not Setup")
        Do Until rc = r4eof
            cboBrkName.Items.Add(Trim(f4str(BKp.BrkNmbr)) & "   " & Trim(f4str(BKp.BrkName)))
            X = X + 1
            BrkArray(X) = Trim(f4str(BKp.BrkNmbr))
            rc = d4skip(f35, 1)
        Loop

        rc = d4bottom(f35)
        rc = d4unlock(f35)
    End Sub

    Private Sub InitBrkTrtyForm()

        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtBrkMgaNmbr.ReadOnly = False
        txtBrkTrtyNmbr.ReadOnly = False
        txtBrkNmbrAssigned.ReadOnly = False
        cmdRecAction.Visible = False

        txBrkMgaNmbr = ""
        txBrkTrtyNmbr = ""
        txBrkNmbrAssigned = ""
        txBrkTrtyEffDate = ""
        txBrkCcDueDate = ""
        txBrkStatus = ""
        txBrkTrtyDesc = ""

        txtBrkMgaNmbr.Text = ""
        txtBrkTrtyNmbr.Text = ""
        txtBrkNmbrAssigned.Text = ""
        txtBrkTrtyEffDate.Text = ""
        txtBrkCcDueDate.Text = ""
        txtBrkStatus.Text = ""
        txtBrkTrtyDesc.Text = ""


        'Load Mga Combo Box
        LoadCboBrkMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboPrm()

        'Load Broker Name
        LoadCboBrk()

        ByPassCbo = True
        cboBrkTrtyMga.SelectedIndex = 1
        cboBrkTrty.SelectedIndex = 1
        cboBrkName.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
        S1 = "  "
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitBrkTrtyForm()
            txtBrkMgaNmbr.Focus()
        End If
    End Sub

    Sub UpBrkTrtyFrmVar()
        txtBrkMgaNmbr.Text = txBrkMgaNmbr
        txtBrkTrtyNmbr.Text = txBrkTrtyNmbr
        txtBrkNmbrAssigned.Text = txBrkNmbrAssigned
        txtBrkTrtyEffDate.Text = Pdate(txBrkTrtyEffDate)
        txtBrkCcDueDate.Text = Pdate(txBrkCcDueDate)
        txtBrkStatus.Text = txBrkStatus
        txtBrkTrtyDesc.Text = txBrkTrtyDesc
    End Sub

    Sub UpBrkTrtyVars()
        Dim D As String

        txBrkMgaNmbr = txtBrkMgaNmbr.Text
        txBrkTrtyNmbr = txtBrkTrtyNmbr.Text
        txBrkNmbrAssigned = txtBrkNmbrAssigned.Text

        D = txtBrkTrtyEffDate.Text
        txBrkTrtyEffDate = Mid(D, 1, 2) & Mid(D, 4, 2) & Mid(D, 7, 4)
        D = txtBrkCcDueDate.Text
        txBrkCcDueDate = Mid(D, 1, 2) & Mid(D, 4, 2) & Mid(D, 7, 4)
        txBrkStatus = txtBrkStatus.Text
        txBrkTrtyDesc = txtBrkTrtyDesc.Text
    End Sub

End Class