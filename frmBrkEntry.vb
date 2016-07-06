Option Strict Off
Option Explicit On

Friend Class frmBrkEntry
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub cboBrk_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboBrk.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        BrkKey = Mid(cboBrk.Text, 1, 3)
        GetBrkMstRec()
        UpBrkMstFrmVar()
        txtBrkNmbr.ReadOnly = True
        txtBrkNmbr.Focus()
        UpdateTran = True
    End Sub

    Private Sub cboBrk_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboBrk.KeyDown
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

        If response = MsgBoxResult.Yes Then ProcessBrkMstRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitBrkForm()
            txtBrkNmbr.Focus()
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

    Private Sub frmBrkEntry_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenBrkMst()
        InitBrkForm()
    End Sub

    Private Sub frmBrkEntry_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Public Sub mnuBrkExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuBrkExit.Click
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
        DelBrkMstRec()
        InitBrkForm()
        txtBrkNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitBrkForm()
        txtBrkNmbr.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuUdel_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUdel.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelBrkMstRec()
        InitBrkForm()
        txtBrkNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitBrkForm()
        txtBrkNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtBrkNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkNmbr.Enter
        Tobj = txtBrkNmbr
    End Sub

    Private Sub txtBrkNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtBrkName.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkName.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtBrkNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String
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
                For X = 0 To cboBrk.Items.Count
                    If BrkArray(X) = M Then
                        ByPassCbo = True
                        cboBrk.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboBrk.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtBrkNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkNmbr.Leave
        Dim M As String
        Dim M1 As Short
        Dim X As Integer

        Tobj = txtBrkNmbr

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next
        If s = "000" Then s = ""

        Tobj.Text = s

        If Len(Trim(txtBrkNmbr.Text)) = 3 Then
            BrkKey = txtBrkNmbr.Text
            GetBrkMstRec()
            If UpdateTran Then
                UpBrkMstFrmVar()
                txtBrkNmbr.ReadOnly = True
            End If
            If AddTran Then
                M = txtBrkNmbr.Text
                M1 = cboBrk.SelectedIndex
                InitBrkForm()
                AddTran = True
                txtBrkNmbr.Text = M
                ByPassCbo = True
                cboBrk.SelectedIndex = M1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtBrkName_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkName.Enter
        Dim X As Integer

        Tobj = txtBrkName

        If Len(txtBrkNmbr.Text) > 0 Then
            For X = 0 To cboBrk.Items.Count
                If BrkArray(X) = txtBrkNmbr.Text Then
                    ByPassCbo = True
                    cboBrk.SelectedIndex = X
                    ByPassCbo = False
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboBrk.SelectedIndex = 0
            ByPassCbo = False
        End If

    End Sub

    Private Sub txtBrkName_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkName.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkNmbr.Focus()
            Case Keys.Down
                txtBrkDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkDesc.Focus()
    End Sub

    Private Sub txtBrkName_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkName.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkName_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkName.Leave
        Tobj = txtBrkName
    End Sub

    Private Sub txtBrkDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkDesc.Enter
        Tobj = txtBrkDesc
    End Sub

    Private Sub txtBrkDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkName.Focus()
            Case Keys.Down
                txtBrkAddr1.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkAddr1.Focus()
    End Sub

    Private Sub txtBrkDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkDesc.Leave
        Tobj = txtBrkDesc
    End Sub

    Private Sub txtBrkAddr1_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkAddr1.Enter
        Tobj = txtBrkAddr1
    End Sub

    Private Sub txtBrkAddr1_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkAddr1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkDesc.Focus()
            Case Keys.Down
                txtBrkAddr2.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkAddr2.Focus()
    End Sub

    Private Sub txtBrkAddr1_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkAddr1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkAddr1.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkAddr1_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkAddr1.Leave
        Tobj = txtBrkAddr1
    End Sub

    Private Sub txtBrkAddr2_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkAddr2.Enter
        Tobj = txtBrkAddr2
    End Sub

    Private Sub txtBrkAddr2_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkAddr2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkAddr1.Focus()
            Case Keys.Down
                txtBrkContact.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkContact.Focus()
    End Sub

    Private Sub txtBrkAddr2_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkAddr2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkAddr2.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkAddr2_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkAddr2.Leave
        Tobj = txtBrkAddr2
    End Sub

    Private Sub txtBrkContact_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkContact.Enter
        Tobj = txtBrkContact
    End Sub

    Private Sub txtBrkContact_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkContact.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkAddr2.Focus()
            Case Keys.Down
                txtBrkPhone.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkPhone.Focus()
    End Sub

    Private Sub txtBrkContact_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkContact.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkContact.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkContact_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkContact.Leave
        Tobj = txtBrkContact
    End Sub

    Private Sub txtBrkPhone_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkPhone.Enter
        Tobj = txtBrkPhone
    End Sub

    Private Sub txtBrkPhone_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkPhone.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkContact.Focus()
            Case Keys.Down
                txtBrkEmail.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkEmail.Focus()
    End Sub

    Private Sub txtBrkPhone_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkPhone.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkPhone.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkPhone_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkPhone.Leave
        Tobj = txtBrkPhone
    End Sub

    Private Sub txtBrkEmail_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkEmail.Enter
        Tobj = txtBrkEmail
    End Sub

    Private Sub txtBrkEmail_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkEmail.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtBrkPhone.Focus()
            Case Keys.Down
                txtBrkTaxId.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtBrkTaxId.Focus()
    End Sub

    Private Sub txtBrkEmail_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkEmail.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkEmail.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkEmail_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkEmail.Leave
        Tobj = txtBrkEmail
    End Sub

    Private Sub txtBrkTaxId_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTaxId.Enter
        Tobj = txtBrkTaxId
    End Sub

    Private Sub txtBrkTaxId_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtBrkTaxId.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtBrkEmail.Focus()
            Case Keys.Down
                txtBrkNmbr.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Then
            If Len(Trim(txtBrkNmbr.Text)) = 3 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If
    End Sub

    Private Sub txtBrkTaxId_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtBrkTaxId.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtBrkTaxId.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBrkTaxId_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtBrkTaxId.Leave
        Tobj = txtBrkTaxId
    End Sub

    Private Sub ProcessBrkMstRec()
        UpBrkMstVars()
        If AddTran Then AddBrkMstRec()
        If UpdateTran Then UpBrkMstRec()
        InitBrkForm()
        txtBrkNmbr.Focus()
    End Sub

    Private Sub InitBrkForm()
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtBrkNmbr.ReadOnly = False
        cmdRecAction.Visible = False

        txBrkNmbr = ""
        chBrkType = 0
        txBrkTaxId = ""
        txBrkName = ""
        txBrkContact = ""
        txBrkDesc = ""
        txBrkPhone = ""
        txBrkEmail = ""
        txBrkAddr1 = ""
        txBrkAddr2 = ""

        txtBrkNmbr.Text = ""
        txtBrkTaxId.Text = ""
        txtBrkName.Text = ""
        txtBrkContact.Text = ""
        txtBrkDesc.Text = ""
        txtBrkPhone.Text = ""
        txtBrkEmail.Text = ""
        txtBrkAddr1.Text = ""
        txtBrkAddr2.Text = ""

        LoadCboBrk()

        ByPassCbo = True
        'cboBrk.ListIndex = 2
        ByPassCbo = False

        s = "   "
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitBrkForm()
            txtBrkNmbr.Focus()
        End If
    End Sub

    Public Sub UpBrkMstFrmVar()
        txtBrkNmbr.Text = txBrkNmbr
        txtBrkTaxId.Text = txBrkTaxId
        txtBrkDesc.Text = txBrkDesc
        txtBrkName.Text = txBrkName
        txtBrkContact.Text = txBrkContact
        txtBrkEmail.Text = txBrkEmail
        txtBrkPhone.Text = txBrkPhone
        txtBrkAddr1.Text = txBrkAddr1
        txtBrkAddr2.Text = txBrkAddr2
    End Sub

    Public Sub UpBrkMstVars()
        txBrkNmbr = txtBrkNmbr.Text
        chBrkType = 0
        txBrkTaxId = txtBrkTaxId.Text
        txBrkDesc = txtBrkDesc.Text
        txBrkName = txtBrkName.Text
        txBrkContact = txtBrkContact.Text
        txBrkEmail = txtBrkEmail.Text
        txBrkPhone = txtBrkPhone.Text
        txBrkAddr1 = txtBrkAddr1.Text
        txBrkAddr2 = txtBrkAddr2.Text
    End Sub

    Sub LoadCboBrk()
        X = 0
        ReDim BrkArray(d4recCount(f35) + 1)

        cboBrk.Items.Clear()
        cboBrk.Items.Add("Broker Not Setup")

        rc = d4top(f35)
        Call d4tagSelect(f35, d4tag(f35, "K1"))
        Do Until rc = r4eof
            cboBrk.Items.Add(Trim(f4str(BKp.BrkNmbr)) & "   " & Trim(f4str(BKp.BrkName)))
            X = X + 1
            BrkArray(X) = Trim(f4str(BKp.BrkNmbr))
            rc = d4skip(f35, 1)
        Loop
        If cboBrk.SelectedIndex > -1 Then cboBrk.SelectedIndex = 0
        rc = d4bottom(f35)
        rc = d4unlock(f35)
    End Sub
End Class