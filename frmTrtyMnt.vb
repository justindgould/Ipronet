Option Strict Off
Option Explicit On

Friend Class frmTrtyMnt

    Private Sub cboTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        If Not AddTran And Not UpdateTran Then
            txtTrtyNmbr.Text = Mid(Trim(cboTrty.Text), 1, 2)
        End If
        TrtyKey = Mid(Trim(cboTrtyMga.Text), 1, 3) & Mid(Trim(cboTrty.Text), 1, 2)
        GetTrtyMstRec()
        UpTrtyMstFrmVar()
        txtTrtyMgaNmbr.ReadOnly = True
        txtTrtyNmbr.ReadOnly = True
        txtTrtyDesc.Focus()
        UpdateTran = True
    End Sub

    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboTrtyMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrtyMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboTrtyMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboTrty.Items.Count > 1 Then
            cboTrty.SelectedIndex = 1
        Else
            cboTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then txtTrtyMgaNmbr.Text = Mid(Trim(cboTrtyMga.Text), 1, 3)
            txtTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboTrtyMga.Text), 1, 3)
            M1 = cboTrtyMga.SelectedIndex
            InitTrtyMntForm()
            txtTrtyMgaNmbr.Text = M
            cboTrtyMga.SelectedIndex = M1
            txtTrtyNmbr.Text = ""
            txtTrtyMgaNmbr.Focus()
        End If

    End Sub

    Private Sub cboTrtyMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrtyMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub chkMULTIP_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkMULTIP.Enter
        Chkobj = chkMULTIP
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkMULTIP_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkMULTIP.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkMULTIP.CheckState = CheckState.Unchecked
            Case 49, 97
                chkMULTIP.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyDesc.Focus()
    End Sub

    Private Sub chkMULTIP_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkMULTIP.KeyPress
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

    Private Sub chkMULTIP_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkMULTIP.Leave
        Chkobj = chkMULTIP
        Chkobj.BackColor = Color.Transparent

        If Len(Trim(txtTrtyMgaNmbr.Text)) = 3 And Len(Trim(txtTrtyNmbr.Text)) = 2 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If

    End Sub

    Private Sub chkPPBI_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPBI.Enter
        Chkobj = chkPPBI
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPBI_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPBI.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedCommPerc.Focus()
            Case 48, 96
                chkPPBI.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPBI.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPPD.Focus()
    End Sub

    Private Sub chkPPBI_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPBI.KeyPress
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

    Private Sub chkPPBI_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPBI.Leave
        Chkobj = chkPPBI
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPPD_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPPD.Enter
        Chkobj = chkPPPD
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPPD_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPPD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPPD.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPPD.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPMED.Focus()
    End Sub

    Private Sub chkPPPD_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPPD.KeyPress
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

    Private Sub chkPPPD_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPPD.Leave
        Chkobj = chkPPPD
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPMED_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPMED.Enter
        Chkobj = chkPPMED
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPMED_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPMED.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPMED.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPMED.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPUMBI.Focus()
    End Sub

    Private Sub chkPPMED_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPMED.KeyPress
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

    Private Sub chkPPMED_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPMED.Leave
        Chkobj = chkPPMED
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPUMBI_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPUMBI.Enter
        Chkobj = chkPPUMBI
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPUMBI_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPUMBI.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPUMBI.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPUMBI.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPUMPD.Focus()
    End Sub

    Private Sub chkPPUMBI_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPUMBI.KeyPress
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

    Private Sub chkPPUMBI_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPUMBI.Leave
        Chkobj = chkPPUMBI
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPUMPD_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPUMPD.Enter
        Chkobj = chkPPUMPD
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPUMPD_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPUMPD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPUMPD.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPUMPD.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPPIP.Focus()
    End Sub

    Private Sub chkPPUMPD_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPUMPD.KeyPress
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

    Private Sub chkPPUMPD_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPUMPD.Leave
        Chkobj = chkPPUMPD
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPPIP_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPPIP.Enter
        Chkobj = chkPPPIP
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPPIP_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPPIP.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPPIP.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPPIP.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPCOMP.Focus()
    End Sub

    Private Sub chkPPPIP_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPPIP.KeyPress
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

    Private Sub chkPPPIP_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPPIP.Leave
        Chkobj = chkPPPIP
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPCOMP_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPCOMP.Enter
        Chkobj = chkPPCOMP
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPCOMP_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPCOMP.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPCOMP.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPCOMP.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPCOLL.Focus()
    End Sub

    Private Sub chkPPCOMP_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPCOMP.KeyPress
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

    Private Sub chkPPCOMP_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPCOMP.Leave
        Chkobj = chkPPCOMP
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPCOLL_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPCOLL.Enter
        Chkobj = chkPPCOLL
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPCOLL_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPCOLL.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPCOLL.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPCOLL.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPRENT.Focus()
    End Sub

    Private Sub chkPPCOLL_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPCOLL.KeyPress
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

    Private Sub chkPPCOLL_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPCOLL.Leave
        Chkobj = chkPPCOLL
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPRENT_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPRENT.Enter
        Chkobj = chkPPRENT
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPRENT_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPRENT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPRENT.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPRENT.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPTOW.Focus()
    End Sub

    Private Sub chkPPRENT_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPRENT.KeyPress
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

    Private Sub chkPPRENT_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPRENT.Leave
        Chkobj = chkPPRENT
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkPPTOW_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPTOW.Enter
        Chkobj = chkPPTOW
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkPPTOW_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkPPTOW.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkPPTOW.CheckState = CheckState.Unchecked
            Case 49, 97
                chkPPTOW.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMBI.Focus()
    End Sub

    Private Sub chkPPTOW_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkPPTOW.KeyPress
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

    Private Sub chkPPTOW_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkPPTOW.Leave
        Chkobj = chkPPTOW
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMBI_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMBI.Enter
        Chkobj = chkCMBI
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMBI_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMBI.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMBI.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMBI.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMPD.Focus()
    End Sub

    Private Sub chkCMBI_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMBI.KeyPress
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

    Private Sub chkCMBI_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMBI.Leave
        Chkobj = chkCMBI
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMPD_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMPD.Enter
        Chkobj = chkCMPD
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMPD_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMPD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMPD.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMPD.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMMED.Focus()
    End Sub

    Private Sub chkCMPD_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMPD.KeyPress
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

    Private Sub chkCMPD_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMPD.Leave
        Chkobj = chkCMPD
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMMED_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMMED.Enter
        Chkobj = chkCMMED
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMMED_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMMED.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMMED.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMMED.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMUMBI.Focus()
    End Sub

    Private Sub chkCMMED_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMMED.KeyPress
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

    Private Sub chkCMMED_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMMED.Leave
        Chkobj = chkCMMED
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMUMBI_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMUMBI.Enter
        Chkobj = chkCMUMBI
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMUMBI_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMUMBI.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMUMBI.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMUMBI.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMUMPD.Focus()
    End Sub

    Private Sub chkCMUMBI_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMUMBI.KeyPress
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

    Private Sub chkCMUMBI_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMUMBI.Leave
        Chkobj = chkCMUMBI
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMUMPD_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMUMPD.Enter
        Chkobj = chkCMUMPD
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMUMPD_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMUMPD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMUMPD.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMUMPD.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMPIP.Focus()
    End Sub

    Private Sub chkCMUMPD_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMUMPD.KeyPress
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

    Private Sub chkCMUMPD_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMUMPD.Leave
        Chkobj = chkCMUMPD
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMPIP_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMPIP.Enter
        Chkobj = chkCMPIP
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMPIP_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMPIP.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMPIP.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMPIP.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMCOMP.Focus()
    End Sub

    Private Sub chkCMPIP_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMPIP.KeyPress
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

    Private Sub chkCMPIP_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMPIP.Leave
        Chkobj = chkCMPIP
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMCOMP_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMCOMP.Enter
        Chkobj = chkCMCOMP
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMCOMP_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMCOMP.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMCOMP.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMCOMP.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMCOLL.Focus()
    End Sub

    Private Sub chkCMCOMP_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMCOMP.KeyPress
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

    Private Sub chkCMCOMP_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMCOMP.Leave
        Chkobj = chkCMCOMP
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMCOLL_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMCOLL.Enter
        Chkobj = chkCMCOLL
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMCOLL_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMCOLL.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMCOLL.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMCOLL.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMRENT.Focus()
    End Sub

    Private Sub chkCMCOLL_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMCOLL.KeyPress
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

    Private Sub chkCMCOLL_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMCOLL.Leave
        Chkobj = chkCMCOLL
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMRENT_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMRENT.Enter
        Chkobj = chkCMRENT
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMRENT_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMRENT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMRENT.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMRENT.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkCMTOW.Focus()
    End Sub

    Private Sub chkCMRENT_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMRENT.KeyPress
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

    Private Sub chkCMRENT_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMRENT.Leave
        Chkobj = chkCMRENT
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkCMTOW_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMTOW.Enter
        Chkobj = chkCMTOW
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkCMTOW_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkCMTOW.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkCMTOW.CheckState = CheckState.Unchecked
            Case 49, 97
                chkCMTOW.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkIM.Focus()
    End Sub

    Private Sub chkCMTOW_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkCMTOW.KeyPress
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

    Private Sub chkCMTOW_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkCMTOW.Leave
        Chkobj = chkCMTOW
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkIM_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkIM.Enter
        Chkobj = chkIM
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkIM_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkIM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkIM.CheckState = CheckState.Unchecked
            Case 49, 97
                chkIM.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkALLIED.Focus()
    End Sub

    Private Sub chkIM_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkIM.KeyPress
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

    Private Sub chkIM_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkIM.Leave
        Chkobj = chkIM
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkALLIED_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkALLIED.Enter
        Chkobj = chkALLIED
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkALLIED_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkALLIED.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkALLIED.CheckState = CheckState.Unchecked
            Case 49, 97
                chkALLIED.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkFIRE.Focus()
    End Sub

    Private Sub chkALLIED_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkALLIED.KeyPress
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

    Private Sub chkALLIED_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkALLIED.Leave
        Chkobj = chkALLIED
        Chkobj.BackColor = Color.Transparent
    End Sub

    Private Sub chkFIRE_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkFIRE.Enter
        Chkobj = chkFIRE
        Chkobj.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chkFIRE_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles chkFIRE.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 48, 96
                chkFIRE.CheckState = CheckState.Unchecked
            Case 49, 97
                chkFIRE.CheckState = CheckState.Checked
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkMULTIP.Focus()
    End Sub

    Private Sub chkFIRE_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles chkFIRE.KeyPress
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

    Private Sub chkFIRE_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles chkFIRE.Leave
        Chkobj = chkFIRE
        Chkobj.BackColor = Color.Transparent
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
        If response = MsgBoxResult.Yes Then ProcessTrtyMstRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitTrtyMntForm()
            txtTrtyMgaNmbr.Focus()
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

    Private Sub frmTrtyMnt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        OpenReiMst()
        OpenTrtyMst()
        AddTran = False
        UpdateTran = False
        InitTrtyMntForm()
    End Sub

    Private Sub frmTrtyMnt_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = Control.ModifierKeys \ &H10000
    End Sub

    Public Sub mnuOdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelTrtyMstRec()
        InitTrtyMntForm()
        txtTrtyMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitTrtyMntForm()
        txtTrtyMgaNmbr.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuTrtyComments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuTrtyComments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtTrtyMgaNmbr.Text
            Ctrty = txtTrtyNmbr.Text
            'frmTrtyComments.ShowDialog()
        End If
    End Sub

    Public Sub mnuTrtyExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuTrtyExit.Click
        Me.Close()
    End Sub

    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUcomments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtTrtyMgaNmbr.Text
            Ctrty = txtTrtyNmbr.Text
            'frmTrtyComments.ShowDialog()
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
        DelTrtyMstRec()
        InitTrtyMntForm()
        txtTrtyMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitTrtyMntForm()
        txtTrtyMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtCedCommPerc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedCommPerc.Enter
        Tobj = txtCedCommPerc
    End Sub

    Private Sub txtCedCommPerc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedCommPerc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtDirCommPerc.Focus()
            Case Keys.Down
                chkPPBI.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then chkPPBI.Focus()
    End Sub

    Private Sub txtCedCommPerc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedCommPerc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedCommPerc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedCommPerc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedCommPerc.Leave
        Tobj = txtCedCommPerc
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
    End Sub

    Private Sub txtDirCommPerc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtDirCommPerc.Enter
        Tobj = txtDirCommPerc
    End Sub

    Private Sub txtDirCommPerc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtDirCommPerc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyCedPerc.Focus()
            Case Keys.Down
                txtCedCommPerc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCedCommPerc.Focus()
    End Sub

    Private Sub txtDirCommPerc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtDirCommPerc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtDirCommPerc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtDirCommPerc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtDirCommPerc.Leave
        Tobj = txtDirCommPerc
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
    End Sub

    Private Sub txtTrtyCedPerc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyCedPerc.Enter
        Tobj = txtTrtyCedPerc
    End Sub

    Private Sub txtTrtyCedPerc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyCedPerc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyPremTaxPerc.Focus()
            Case Keys.Down
                txtDirCommPerc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtDirCommPerc.Focus()
    End Sub

    Private Sub txtTrtyCedPerc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyCedPerc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyCedPerc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyCedPerc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyCedPerc.Leave
        Tobj = txtTrtyCedPerc
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")

        If Val(Tobj.Text) > 100 Then
            MsgBox("Amount > 100%")
            txtTrtyCedPerc.Text = Format(Val(CStr(0)), "###.0000")
        End If
    End Sub

    Private Sub txtTrtyDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyDesc.Enter
        Dim X As Short
        Tobj = txtTrtyDesc

        If UpdateTran Then
            If Len(txtTrtyMgaNmbr.Text) > 0 Then
                For X = 0 To cboTrty.Items.Count
                    If TrtyArray(X) = Trim(txtTrtyNmbr.Text) Then
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

    Private Sub txtTrtyDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyNmbr.Focus()
            Case Keys.Down
                txtTrtyFFperc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyFFperc.Focus()
    End Sub

    Private Sub txtTrtyDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyDesc.Leave
        Tobj = txtTrtyDesc
    End Sub

    Private Sub txtTrtyFFperc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyFFperc.Enter
        Tobj = txtTrtyFFperc
    End Sub

    Private Sub txtTrtyFFperc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyFFperc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyDesc.Focus()
            Case Keys.Down
                txtTrtyPremTaxPerc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyPremTaxPerc.Focus()
    End Sub

    Private Sub txtTrtyFFperc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyFFperc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyFFperc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyFFperc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyFFperc.Leave
        Tobj = txtTrtyFFperc
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
    End Sub

    Private Sub txtTrtyMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyMgaNmbr.Enter
        Tobj = txtTrtyMgaNmbr
    End Sub

    Private Sub txtTrtyMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtTrtyMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyMgaNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String
        Dim X As Short

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
                For X = 1 To cboTrtyMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboTrtyMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboTrtyMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If
    End Sub

    Private Sub txtTrtyMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyMgaNmbr.Leave
        Dim X As Short

        Tobj = txtTrtyMgaNmbr
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
                txtTrtyMgaNmbr.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Dim X As Short

        Tobj = txtTrtyNmbr

        For X = 1 To cboTrtyMga.Items.Count
            If MgaArray(X) = Trim(txtTrtyMgaNmbr.Text) Then
                ByPassTxt = True
                cboTrtyMga.SelectedIndex = X
                ByPassTxt = False
                Exit Sub
            End If
        Next X
        cboTrtyMga.SelectedIndex = 0
    End Sub

    Private Sub txtTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyMgaNmbr.Focus()
            Case Keys.Down
                txtTrtyDesc.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyDesc.Focus()

        ResetForm((KeyCode))
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
        Dim X As Short

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

    Private Sub txtTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Leave
        Dim M As String
        Dim M1 As String
        Dim W As Object
        Dim W1 As Short
        Dim X As Short

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

        If Len(Trim(txtTrtyMgaNmbr.Text)) = 3 And Len(Trim(Tobj.Text)) = 2 Then
            TrtyKey = Trim(txtTrtyMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
            GetTrtyMstRec()
            If UpdateTran Then
                UpTrtyMstFrmVar()
                txtTrtyMgaNmbr.ReadOnly = True
                txtTrtyNmbr.ReadOnly = True
            End If
            If AddTran Then
                M = txtTrtyMgaNmbr.Text
                M1 = txtTrtyNmbr.Text
                W = cboTrtyMga.SelectedIndex
                W1 = cboTrty.SelectedIndex
                InitTrtyMntForm()
                AddTran = True
                ByPassCbo = True
                cboTrtyMga.SelectedIndex = W
                cboTrty.SelectedIndex = 0
                txtTrtyMgaNmbr.Text = M
                txtTrtyNmbr.Text = M1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtTrtyPremTaxPerc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyPremTaxPerc.Enter
        Tobj = txtTrtyPremTaxPerc
    End Sub

    Private Sub txtTrtyPremTaxPerc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyPremTaxPerc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyFFperc.Focus()
            Case Keys.Down
                txtTrtyCedPerc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyCedPerc.Focus()
    End Sub

    Private Sub txtTrtyPremTaxPerc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyPremTaxPerc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyPremTaxPerc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyPremTaxPerc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyPremTaxPerc.Leave
        Tobj = txtTrtyPremTaxPerc
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
    End Sub

    Private Sub InitTrtyMntForm()

        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        Utrtymst = True
        Utrtyrei = False
        txtTrtyMgaNmbr.ReadOnly = False
        txtTrtyNmbr.ReadOnly = False
        cboTrtyMga.ResetText()
        cboTrty.ResetText()
        cmdRecAction.Visible = False

        txTrtyMgaNmbr = ""
        txTrtyNmbr = ""
        txTrtyDesc = ""
        txTrtyFFperc = ""
        txTrtyPremTaxPerc = ""
        txTrtyCedPerc = ""
        txDirCommPerc = ""
        txCedCommPerc = ""
        chPPBI = 0
        chPPPD = 0
        chPPMED = 0
        chPPUMBI = 0
        chPPUMPD = 0
        chPPPIP = 0
        chPPCOMP = 0
        chPPCOLL = 0
        chPPRENT = 0
        chPPTOW = 0
        chCMBI = 0
        chCMPD = 0
        chCMMED = 0
        chCMUMBI = 0
        chCMUMPD = 0
        chCMPIP = 0
        chCMCOMP = 0
        chCMCOLL = 0
        chCMRENT = 0
        chCMTOW = 0
        chIM = 0
        chALLIED = 0
        chFIRE = 0
        chMULTIP = 0

        txtTrtyMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtTrtyDesc.Text = ""
        txtTrtyFFperc.Text = ""
        txtTrtyPremTaxPerc.Text = ""
        txtTrtyCedPerc.Text = ""
        txtDirCommPerc.Text = ""
        txtCedCommPerc.Text = ""
        chkPPBI.CheckState = CheckState.Unchecked
        chkPPPD.CheckState = CheckState.Unchecked
        chkPPMED.CheckState = CheckState.Unchecked
        chkPPUMBI.CheckState = CheckState.Unchecked
        chkPPUMPD.CheckState = CheckState.Unchecked
        chkPPPIP.CheckState = CheckState.Unchecked
        chkPPCOMP.CheckState = CheckState.Unchecked
        chkPPCOLL.CheckState = CheckState.Unchecked
        chkPPRENT.CheckState = CheckState.Unchecked
        chkPPTOW.CheckState = CheckState.Unchecked
        chkCMBI.CheckState = CheckState.Unchecked
        chkCMPD.CheckState = CheckState.Unchecked
        chkCMMED.CheckState = CheckState.Unchecked
        chkCMUMBI.CheckState = CheckState.Unchecked
        chkCMUMPD.CheckState = CheckState.Unchecked
        chkCMPIP.CheckState = CheckState.Unchecked
        chkCMCOMP.CheckState = CheckState.Unchecked
        chkCMCOLL.CheckState = CheckState.Unchecked
        chkCMRENT.CheckState = CheckState.Unchecked
        chkCMTOW.CheckState = CheckState.Unchecked
        chkIM.CheckState = CheckState.Unchecked
        chkALLIED.CheckState = CheckState.Unchecked
        chkFIRE.CheckState = CheckState.Unchecked
        chkMULTIP.CheckState = CheckState.Unchecked

        'Load Mga Combo Box
        LoadCboTrtyMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboTrtyMga.SelectedIndex = 1
        cboTrty.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
        S1 = "  "
    End Sub

    Private Sub ProcessTrtyMstRec()
        UpTrtyMstVars()
        If AddTran Then AddTrtyMstRec()
        If UpdateTran Then UpTrtyMstRec()

        InitTrtyMntForm()
        txtTrtyMgaNmbr.Focus()
    End Sub

    Private Sub LoadCboTrtyMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboTrtyMga.Items.Clear()
        cboTrtyMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboTrtyMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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
        cboTrty.Items.Add("Treaty Not Setup")
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

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitTrtyMntForm()
            txtTrtyMgaNmbr.Focus()
        End If
    End Sub

    Sub UpTrtyMstFrmVar()
        txtTrtyMgaNmbr.Text = txTrtyMgaNmbr
        txtTrtyNmbr.Text = txTrtyNmbr
        txtTrtyDesc.Text = txTrtyDesc
        txtTrtyFFperc.Text = txTrtyFFperc
        txtTrtyPremTaxPerc.Text = txTrtyPremTaxPerc
        txtTrtyCedPerc.Text = txTrtyCedPerc
        txtDirCommPerc.Text = txDirCommPerc
        txtCedCommPerc.Text = txCedCommPerc
        chkPPBI.CheckState = chPPBI
        chkPPPD.CheckState = chPPPD
        chkPPMED.CheckState = chPPMED
        chkPPUMBI.CheckState = chPPUMBI
        chkPPUMPD.CheckState = chPPUMPD
        chkPPPIP.CheckState = chPPPIP
        chkPPCOMP.CheckState = chPPCOMP
        chkPPCOLL.CheckState = chPPCOLL
        chkPPRENT.CheckState = chPPRENT
        chkPPTOW.CheckState = chPPTOW
        chkCMBI.CheckState = chCMBI
        chkCMPD.CheckState = chCMPD
        chkCMMED.CheckState = chCMMED
        chkCMUMBI.CheckState = chCMUMBI
        chkCMUMPD.CheckState = chCMUMPD
        chkCMPIP.CheckState = chCMPIP
        chkCMCOMP.CheckState = chCMCOMP
        chkCMCOLL.CheckState = chCMCOLL
        chkCMRENT.CheckState = chCMRENT
        chkCMTOW.CheckState = chCMTOW
        chkIM.CheckState = chIM
        chkALLIED.CheckState = chALLIED
        chkFIRE.CheckState = chFIRE
        chkMULTIP.CheckState = chMULTIP
    End Sub

    Public Sub UpTrtyMstVars()
        txTrtyMgaNmbr = txtTrtyMgaNmbr.Text
        txTrtyNmbr = txtTrtyNmbr.Text
        txTrtyDesc = txtTrtyDesc.Text
        txTrtyFFperc = txtTrtyFFperc.Text
        txTrtyPremTaxPerc = txtTrtyPremTaxPerc.Text
        txTrtyCedPerc = txtTrtyCedPerc.Text
        txDirCommPerc = txtDirCommPerc.Text
        txCedCommPerc = txtCedCommPerc.Text
        chPPBI = chkPPBI.CheckState
        chPPPD = chkPPPD.CheckState
        chPPMED = chkPPMED.CheckState
        chPPUMBI = chkPPUMBI.CheckState
        chPPUMPD = chkPPUMPD.CheckState
        chPPPIP = chkPPPIP.CheckState
        chPPCOMP = chkPPCOMP.CheckState
        chPPCOLL = chkPPCOLL.CheckState
        chPPRENT = chkPPRENT.CheckState
        chPPTOW = chkPPTOW.CheckState
        chCMBI = chkCMBI.CheckState
        chCMPD = chkCMPD.CheckState
        chCMMED = chkCMMED.CheckState
        chCMUMBI = chkCMUMBI.CheckState
        chCMUMPD = chkCMUMPD.CheckState
        chCMPIP = chkCMPIP.CheckState
        chCMCOMP = chkCMCOMP.CheckState
        chCMCOLL = chkCMCOLL.CheckState
        chCMRENT = chkCMRENT.CheckState
        chCMTOW = chkCMTOW.CheckState
        chIM = chkIM.CheckState
        chALLIED = chkALLIED.CheckState
        chFIRE = chkFIRE.CheckState
        chMULTIP = chkMULTIP.CheckState
    End Sub

End Class