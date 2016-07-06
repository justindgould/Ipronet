Option Strict Off
Option Explicit On
Friend Class frmGlMgaRef

    Private Sub cboMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboMga.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        AddTran = False
        UpdateTran = False
        MgaKey = Mid(cboMga.Text, 1, 3)
        GetGlMgaRefRec()
        UpGlMgaRefFrmVar()
        txtGlMgaNmbr.ReadOnly = True
        txtAgtRec.Focus()
    End Sub

    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
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

        If response = MsgBoxResult.Yes Then ProcessGlMgaRefRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitGlMgaRefForm()
            txtGlMgaNmbr.Focus()
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

    Private Sub frmGlMgaRef_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenGlMgaRef()
        InitGlMgaRefForm()
    End Sub

    Private Sub frmGlMgaRef_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = Control.ModifierKeys \ &H10000
        'Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        'Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    End Sub

    Public Sub mnuComments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuComments.Click
        frmMgaComments.ShowDialog()
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
        DelGlMgaRefRec()
        InitGlMgaRefForm()
        txtGlMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitGlMgaRefForm()
        txtGlMgaNmbr.Focus()
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
        DelGlMgaRefRec()
        InitGlMgaRefForm()
        txtGlMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitGlMgaRefForm()
        txtGlMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub


    Private Sub txtGlMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtGlMgaNmbr.Enter
        Tobj = txtGlMgaNmbr
    End Sub

    Private Sub txtGlMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtGlMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtAgtRec.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtAgtRec.Focus()
        ResetForm((KeyCode))
    End Sub

    Private Sub txtGlMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtGlMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtGlMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtGlMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtGlMgaNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String
        Dim X As Short

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
                For X = 0 To cboMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassCbo = True
                        cboMga.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboMga.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtGlMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtGlMgaNmbr.Leave
        Dim M As String
        Dim M1 As Short
        Dim X As Short
        Tobj = txtGlMgaNmbr

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        If s = "000" Then s = ""
        Tobj.Text = s

        If Len(Trim(txtGlMgaNmbr.Text)) = 3 Then
            MgaKey = txtGlMgaNmbr.Text
            GetGlMgaRefRec()
            If UpdateTran Then
                UpGlMgaRefFrmVar()
                txtGlMgaNmbr.ReadOnly = True
            End If
            If AddTran Then
                M = txtGlMgaNmbr.Text
                M1 = cboMga.SelectedIndex
                InitGlMgaRefForm()
                AddTran = True
                txtGlMgaNmbr.Text = M
                ByPassCbo = True
                cboMga.SelectedIndex = M1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtAgtRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtRec.Enter
        Dim X As Short
        Tobj = txtAgtRec

        If Len(txtGlMgaNmbr.Text) > 0 Then
            For X = 0 To cboMga.Items.Count
                If MgaArray(X) = txtGlMgaNmbr.Text Then
                    ByPassCbo = True
                    cboMga.SelectedIndex = X
                    ByPassCbo = False
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboMga.SelectedIndex = 0
            ByPassCbo = False
        End If

    End Sub

    Private Sub txtAgtRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtAgtRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtGlMgaNmbr.Focus()
            Case Keys.Down
                txtAgtRecDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtAgtRecDesc.Focus()
    End Sub

    Private Sub txtAgtRec_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtAgtRec.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtAgtRec.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtAgtRec_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtRec.Leave
        Tobj = txtAgtRec
    End Sub

    Private Sub txtAgtRecDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtRecDesc.Enter
        Tobj = txtAgtRecDesc
    End Sub

    Private Sub txtAgtRecDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtAgtRecDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtAgtRec.Focus()
            Case Keys.Down
                txtReiPay.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiPay.Focus()
    End Sub

    Private Sub txtAgtRecDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtAgtRecDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtAgtRecDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtAgtRecDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtRecDesc.Leave
        Tobj = txtAgtRecDesc
    End Sub

    Private Sub txtReiPay_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPay.Enter
        Tobj = txtReiPay
    End Sub

    Private Sub txtReiPay_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiPay.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtAgtRecDesc.Focus()
            Case Keys.Down
                txtReiPayDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiPayDesc.Focus()
    End Sub

    Private Sub txtReiPay_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiPay.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiPay.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiPay_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPay.Leave
        Tobj = txtReiPay
    End Sub

    Private Sub txtReiPayDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPayDesc.Enter
        Tobj = txtReiPayDesc
    End Sub

    Private Sub txtReiPayDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiPayDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiPay.Focus()
            Case Keys.Down
                txtLossRec.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtLossRec.Focus()
    End Sub

    Private Sub txtReiPayDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiPayDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiPayDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiPayDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPayDesc.Leave
        Tobj = txtReiPayDesc
    End Sub


    Private Sub txtLossRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLossRec.Enter
        Tobj = txtLossRec
    End Sub

    Private Sub txtLossRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtLossRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiPayDesc.Focus()
            Case Keys.Down
                txtLossRecDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtLossRecDesc.Focus()
    End Sub

    Private Sub txtLossRec_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtLossRec.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtLossRec.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtLossRec_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLossRec.Leave
        Tobj = txtLossRec
    End Sub

    Private Sub txtLossRecDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLossRecDesc.Enter
        Tobj = txtLossRecDesc
    End Sub

    Private Sub txtLossRecDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtLossRecDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtLossRec.Focus()
            Case Keys.Down
                txtLaeRec.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtLaeRec.Focus()
    End Sub

    Private Sub txtLossRecDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtLossRecDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtLossRecDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtLossRecDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLossRecDesc.Leave
        Tobj = txtLossRecDesc
    End Sub

    Private Sub txtLaeRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLaeRec.Enter
        Tobj = txtLaeRec
    End Sub

    Private Sub txtLaeRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtLaeRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtLossRecDesc.Focus()
            Case Keys.Down
                txtLaeRecDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtLaeRecDesc.Focus()
    End Sub

    Private Sub txtLaeRec_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtLaeRec.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtLaeRec.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtLaeRec_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLaeRec.Leave
        Tobj = txtLaeRec
    End Sub

    Private Sub txtLaeRecDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLaeRecDesc.Enter
        Tobj = txtLaeRecDesc
    End Sub

    Private Sub txtLaeRecDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtLaeRecDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtLaeRec.Focus()
            Case Keys.Down
                txtAgtBalNotDue.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtAgtBalNotDue.Focus()
    End Sub

    Private Sub txtLaeRecDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtLaeRecDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtLaeRecDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtLaeRecDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLaeRecDesc.Leave
        Tobj = txtLaeRecDesc
    End Sub

    Private Sub txtAgtBalNotDue_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtBalNotDue.Enter
        Tobj = txtAgtBalNotDue
    End Sub

    Private Sub txtAgtBalNotDue_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtAgtBalNotDue.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtLaeRecDesc.Focus()
            Case Keys.Down
                txtAgtBalNotDueDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtAgtBalNotDueDesc.Focus()
    End Sub

    Private Sub txtAgtBalNotDue_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtAgtBalNotDue.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtAgtBalNotDue.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtAgtBalNotDue_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtBalNotDue.Leave
        Tobj = txtAgtBalNotDue
    End Sub

    Private Sub txtAgtBalNotDueDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtBalNotDueDesc.Enter
        Tobj = txtAgtBalNotDueDesc
    End Sub

    Private Sub txtAgtBalNotDueDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtAgtBalNotDueDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtAgtBalNotDue.Focus()
            Case Keys.Down
                txtReiPayNotDue.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiPayNotDue.Focus()
    End Sub

    Private Sub txtAgtBalNotDueDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtAgtBalNotDueDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtAgtBalNotDueDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtAgtBalNotDueDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAgtBalNotDueDesc.Leave
        Tobj = txtAgtBalNotDueDesc
    End Sub

    Private Sub txtReiPayNotDue_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPayNotDue.Enter
        Tobj = txtReiPayNotDue
    End Sub

    Private Sub txtReiPayNotDue_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiPayNotDue.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtAgtBalNotDueDesc.Focus()
            Case Keys.Down
                txtReiPayNotDueDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiPayNotDueDesc.Focus()
    End Sub

    Private Sub txtReiPayNotDue_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiPayNotDue.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiPayNotDue.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiPayNotDue_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPayNotDue.Leave
        Tobj = txtReiPayNotDue
    End Sub

    Private Sub txtReiPayNotDueDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPayNotDueDesc.Enter
        Tobj = txtReiPayNotDueDesc
    End Sub

    Private Sub txtReiPayNotDueDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiPayNotDueDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiPayNotDue.Focus()
            Case Keys.Down
                txtAgtRec.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Then
            If Len(Trim(txtGlMgaNmbr.Text)) = 3 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If
    End Sub

    Private Sub txtReiPayNotDueDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiPayNotDueDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiPayNotDueDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiPayNotDueDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPayNotDueDesc.Leave
        Tobj = txtReiPayNotDueDesc
    End Sub

    Private Sub ProcessGlMgaRefRec()
        UpGlMgaRefVars()
        If AddTran Then AddGlMgaRefRec()
        If UpdateTran Then UpGlMgaRefRec()
        InitGlMgaRefForm()
        txtGlMgaNmbr.Focus()
    End Sub

    Private Sub InitGlMgaRefForm()
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtGlMgaNmbr.ReadOnly = False
        cmdRecAction.Visible = False

        txGlMgaNmbr = ""
        txAgtRec = ""
        txAgtRecDesc = ""
        txReiPay = ""
        txReiPayDesc = ""
        txLossRec = ""
        txLossRecDesc = ""
        txLaeRec = ""
        txLaeRecDesc = ""
        txAgtBalNotDue = ""
        txAgtBalNotDueDesc = ""
        txReiPayNotDue = ""
        txReiPayNotDueDesc = ""

        txtGlMgaNmbr.Text = ""
        txtAgtRec.Text = ""
        txtReiPay.Text = ""
        txtLossRec.Text = ""
        txtLaeRec.Text = ""
        txtAgtBalNotDue.Text = ""
        txtReiPayNotDue.Text = ""
        txtAgtRecDesc.Text = ""
        txtReiPayDesc.Text = ""
        txtLossRecDesc.Text = ""
        txtLaeRecDesc.Text = ""
        txtAgtBalNotDueDesc.Text = ""
        txtReiPayNotDueDesc.Text = ""

        LoadCboGLMga()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitGlMgaRefForm()
            txtGlMgaNmbr.Focus()
        End If
    End Sub

    Sub LoadCboGLMga()
        OpenMgaMst()
        X = 0
        ReDim MgaArray(d4recCount(f1) + 1)

        cboMga.Items.Clear()
        cboMga.Items.Add("MGA Not Setup")

        rc = d4top(f1)
        Call d4tagSelect(f1, d4tag(f1, "K1"))
        Do Until rc = r4eof
            cboMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
            X = X + 1
            MgaArray(X) = Trim(f4str(Mp.MgaNmbr))
            rc = d4skip(f1, 1)
        Loop
        If cboMga.SelectedIndex > -1 Then cboMga.SelectedIndex = 0
        rc = d4bottom(f1)
        rc = d4unlock(f1)
    End Sub

    Sub UpGlMgaRefFrmVar()
        txtGlMgaNmbr.Text = txGlMgaNmbr
        txtAgtRec.Text = txAgtRec
        txtReiPay.Text = txReiPay
        txtLossRec.Text = txLossRec
        txtLaeRec.Text = txLaeRec
        txtAgtBalNotDue.Text = txAgtBalNotDue
        txtReiPayNotDue.Text = txReiPayNotDue
        txtAgtRecDesc.Text = txAgtRecDesc
        txtReiPayDesc.Text = txReiPayDesc
        txtLossRecDesc.Text = txLossRecDesc
        txtLaeRecDesc.Text = txLaeRecDesc
        txtAgtBalNotDueDesc.Text = txAgtBalNotDueDesc
        txtReiPayNotDueDesc.Text = txReiPayNotDueDesc
    End Sub

    Sub UpGlMgaRefVars()
        txGlMgaNmbr = txtGlMgaNmbr.Text
        txAgtRec = txtAgtRec.Text
        txReiPay = txtReiPay.Text
        txLossRec = txtLossRec.Text
        txLaeRec = txtLaeRec.Text
        txAgtBalNotDue = txtAgtBalNotDue.Text
        txReiPayNotDue = txtReiPayNotDue.Text
        txAgtRecDesc = txtAgtRecDesc.Text
        txReiPayDesc = txtReiPayDesc.Text
        txLossRecDesc = txtLossRecDesc.Text
        txLaeRecDesc = txtLaeRecDesc.Text
        txAgtBalNotDueDesc = txtAgtBalNotDueDesc.Text
        txReiPayNotDueDesc = txtReiPayNotDueDesc.Text
    End Sub

End Class