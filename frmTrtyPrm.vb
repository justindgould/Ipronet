Option Strict Off
Option Explicit On

Friend Class frmTrtyPrm
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub cboPrmState_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboPrmState.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtPrmStateCode.Text = Mid(Trim(cboPrmState.Text), 1, 2)
    End Sub

    Private Sub cboTrtyPrm_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrtyPrm.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        If Not AddTran And Not UpdateTran Then
            txtPrmTrtyNmbr.Text = Mid(Trim(cboTrtyPrm.Text), 1, 2)
        End If
        TrtyKey = Mid(Trim(cboTrtyPrmMga.Text), 1, 3) & Mid(Trim(cboTrtyPrm.Text), 1, 2)
        GetTrtyPrmRec()
        UpTrtyPrmFrmVar()
        txtPrmMgaNmbr.ReadOnly = True
        txtPrmTrtyNmbr.ReadOnly = True
        txtPrmRptName.Focus()
        UpdateTran = True
    End Sub

    Private Sub cboTrtyPrm_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrtyPrm.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboTrtyPrmMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrtyPrmMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboTrtyPrmMga.Text), 1, 3)
        LoadCboPrm()

        ByPassCbo = True
        If cboTrtyPrm.Items.Count > 1 Then
            cboTrtyPrm.SelectedIndex = 1
        Else
            cboTrtyPrm.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then txtPrmMgaNmbr.Text = Mid(Trim(cboTrtyPrmMga.Text), 1, 3)
            txtPrmTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboTrtyPrmMga.Text), 1, 3)
            M1 = cboTrtyPrmMga.SelectedIndex
            InitTrtyPrmForm()
            txtPrmMgaNmbr.Text = M
            cboTrtyPrmMga.SelectedIndex = M1
            txtPrmTrtyNmbr.Text = ""
            txtPrmMgaNmbr.Focus()
        End If

    End Sub

    Private Sub cboTrtyPrmMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrtyPrmMga.KeyDown
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
        If response = MsgBoxResult.Yes Then ProcessTrtyPrmRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitTrtyPrmForm()
            txtPrmMgaNmbr.Focus()
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

    Private Sub frmTrtyPrm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenMgaMst()
        OpenReiMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        OpenGlMgaRef()

        OpenStateRef()
        ByPassCbo = True
        LoadCboState()
        ByPassCbo = False

        AddTran = False
        UpdateTran = False
        InitTrtyPrmForm()

    End Sub

    Private Sub frmTrtyPrm_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Public Sub mnuOcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOcomments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtPrmMgaNmbr.Text
            Ctrty = txtPrmTrtyNmbr.Text
            frmTrtyComments.ShowDialog()
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
        DelTrtyPrmRec()
        InitTrtyPrmForm()
        txtPrmMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitTrtyPrmForm()
        txtPrmMgaNmbr.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUComments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtPrmMgaNmbr.Text
            Ctrty = txtPrmTrtyNmbr.Text
            frmTrtyComments.ShowDialog()
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
        DelTrtyPrmRec()
        InitTrtyPrmForm()
        txtPrmMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitTrtyPrmForm()
        txtPrmMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtPrmMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmMgaNmbr.Enter
        Tobj = txtPrmMgaNmbr
    End Sub

    Private Sub txtPrmMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtPrmTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtPrmMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmMgaNmbr.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim X As Integer
        Dim M As String
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
                For X = 1 To cboTrtyPrmMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboTrtyPrmMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboTrtyPrmMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If

    End Sub

    Private Sub txtPrmMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmMgaNmbr.Leave
        Dim X As Integer
        Tobj = txtPrmMgaNmbr

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
                txtPrmMgaNmbr.Focus()
                Exit Sub
            End If
        End If

        GetGlRef()
    End Sub

    Private Sub txtPrmTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmTrtyNmbr.Enter
        Dim X As Integer
        Tobj = txtPrmTrtyNmbr

        For X = 1 To cboTrtyPrmMga.Items.Count
            If MgaArray(X) = Trim(txtPrmMgaNmbr.Text) Then
                ByPassTxt = True
                cboTrtyPrmMga.SelectedIndex = X
                ByPassTxt = False
                Exit Sub
            End If
        Next X
        cboTrtyPrmMga.SelectedIndex = 0
    End Sub

    Private Sub txtPrmTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmMgaNmbr.Focus()
            Case Keys.Down
                txtPrmRptName.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmRptName.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtPrmTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmTrtyNmbr.KeyUp
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
                For X = 0 To cboTrtyPrm.Items.Count
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboTrtyPrm.SelectedIndex = X
                        ByPassCbo = False
                        GetGlRef()
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboTrtyPrm.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtPrmTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmTrtyNmbr.Leave
        Dim M As String
        Dim M1 As String
        Dim W As Object
        Dim W1 As Short
        Dim X As Integer

        Tobj = txtPrmTrtyNmbr

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        If S1 = "00" Then
            Tobj.Text = ""
        End If

        If Len(Trim(txtPrmMgaNmbr.Text)) = 3 And Len(Trim(Tobj.Text)) = 2 Then
            TrtyKey = Trim(txtPrmMgaNmbr.Text) & Trim(txtPrmTrtyNmbr.Text)
            GetTrtyPrmRec()
            If UpdateTran Then
                UpTrtyPrmFrmVar()
                txtPrmMgaNmbr.ReadOnly = True
                txtPrmTrtyNmbr.ReadOnly = True
                Mobj = cboPrmState
                GetStateName((txtPrmStateCode.Text))
            End If
            If AddTran Then
                M = txtPrmMgaNmbr.Text
                M1 = txtPrmTrtyNmbr.Text
                W = cboTrtyPrmMga.SelectedIndex
                W1 = cboTrtyPrm.SelectedIndex
                InitTrtyPrmForm()
                AddTran = True
                ByPassCbo = True
                cboTrtyPrmMga.SelectedIndex = W
                cboTrtyPrm.SelectedIndex = 0
                txtPrmMgaNmbr.Text = M
                txtPrmTrtyNmbr.Text = M1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtPrmRptName_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmRptName.Enter
        Tobj = txtPrmRptName
        Dim X As Integer

        If UpdateTran Then
            If Len(txtPrmTrtyNmbr.Text) > 0 Then
                For X = 0 To cboTrtyPrm.Items.Count
                    If TrtyArray(X) = Trim(txtPrmTrtyNmbr.Text) Then
                        ByPassCbo = True
                        cboTrtyPrm.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboTrtyPrm.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtPrmRptName_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmRptName.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmTrtyNmbr.Focus()
            Case Keys.Down
                txtPrmConNmbr.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmConNmbr.Focus()
    End Sub

    Private Sub txtPrmRptName_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmRptName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmRptName.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmRptName_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmRptName.Leave
        Tobj = txtPrmRptName
    End Sub

    Private Sub txtPrmConNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmConNmbr.Enter
        Tobj = txtPrmConNmbr
    End Sub

    Private Sub txtPrmConNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmConNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmRptName.Focus()
            Case Keys.Down
                txtPrmReiRptFlag.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmReiRptFlag.Focus()
    End Sub

    Private Sub txtPrmConNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmConNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmConNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmConNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmConNmbr.Leave
        Tobj = txtPrmConNmbr
    End Sub

    Private Sub txtPrmReiRptFlag_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmReiRptFlag.Enter
        Tobj = txtPrmReiRptFlag
    End Sub

    Private Sub txtPrmReiRptFlag_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmReiRptFlag.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmConNmbr.Focus()
            Case Keys.Down
                txtPrmIncpDate.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmIncpDate.Focus()
    End Sub

    Private Sub txtPrmReiRptFlag_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmReiRptFlag.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmReiRptFlag.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmReiRptFlag_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmReiRptFlag.Leave
        Tobj = txtPrmReiRptFlag
    End Sub

    Private Sub txtPrmIncpDate_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmIncpDate.Enter
        Tobj = txtPrmIncpDate
        txtPrmIncpDate.Text = txPrmIncpDate
    End Sub

    Private Sub txtPrmIncpDate_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmIncpDate.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmReiRptFlag.Focus()
            Case Keys.Down
                txtPrmStatus.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmStatus.Focus()
    End Sub

    Private Sub txtPrmIncpDate_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmIncpDate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmIncpDate.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmIncpDate_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmIncpDate.Leave
        Tobj = txtPrmIncpDate
        txPrmIncpDate = txtPrmIncpDate.Text
        txtPrmIncpDate.Text = Mid(txPrmIncpDate, 1, 2) & "/" + Mid(txPrmIncpDate, 3, 4)
    End Sub

    Private Sub txtPrmStatus_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmStatus.Enter
        Tobj = txtPrmStatus
        If txtPrmStatus.Text = "Active" Then txtPrmStatus.Text = "0"
        If txtPrmStatus.Text = "Inactive" Then txtPrmStatus.Text = "1"
        If txtPrmStatus.Text = "Pending" Then txtPrmStatus.Text = "2"

    End Sub

    Private Sub txtPrmStatus_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmStatus.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmIncpDate.Focus()
            Case Keys.Down
                txtPrmDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmDesc.Focus()
    End Sub

    Private Sub txtPrmStatus_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmStatus.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmStatus.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmStatus_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmStatus.Leave
        Tobj = txtPrmStatus

        If Trim(txtPrmStatus.Text) = "0" Then txtPrmStatus.Text = "Active"
        If Trim(txtPrmStatus.Text) = "1" Then txtPrmStatus.Text = "Inactive"
        If Trim(txtPrmStatus.Text) = "2" Then txtPrmStatus.Text = "Pending"

    End Sub

    Private Sub txtPrmDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmDesc.Enter
        Tobj = txtPrmDesc
    End Sub

    Private Sub txtPrmDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmStatus.Focus()
            Case Keys.Down
                txtPrmAgtRec.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmAgtRec.Focus()
    End Sub

    Private Sub txtPrmDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmDesc_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmDesc.Leave
        Tobj = txtPrmDesc
    End Sub

    Private Sub txtPrmAgtRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmAgtRec.Enter
        Tobj = txtPrmAgtRec
        If Trim(txtPrmAgtRec.Text) = "" Then txtPrmAgtRec.Text = txAgtRec
    End Sub

    Private Sub txtPrmAgtRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmAgtRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmDesc.Focus()
            Case Keys.Down
                txtPrmReiPay.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmReiPay.Focus()
    End Sub

    Private Sub txtPrmAgtRec_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmAgtRec.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmAgtRec.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmAgtRec_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmAgtRec.Leave
        Tobj = txtPrmAgtRec
    End Sub

    Private Sub txtPrmReiPay_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmReiPay.Enter
        Tobj = txtPrmReiPay
        If Trim(txtPrmReiPay.Text) = "" Then txtPrmReiPay.Text = txReiPay
    End Sub

    Private Sub txtPrmReiPay_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmReiPay.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmAgtRec.Focus()
            Case Keys.Down
                txtPrmLossRec.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmLossRec.Focus()
    End Sub

    Private Sub txtPrmReiPay_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmReiPay.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmReiPay.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmReiPay_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmReiPay.Leave
        Tobj = txtPrmReiPay
    End Sub

    Private Sub txtPrmLossRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmLossRec.Enter
        Tobj = txtPrmLossRec
        If Trim(txtPrmLossRec.Text) = "" Then txtPrmLossRec.Text = txLossRec
    End Sub

    Private Sub txtPrmLossRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmLossRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmReiPay.Focus()
            Case Keys.Down
                txtPrmLaeRec.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmLaeRec.Focus()
    End Sub

    Private Sub txtPrmLossRec_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmLossRec.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmLossRec.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmLossRec_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmLossRec.Leave
        Tobj = txtPrmLossRec
    End Sub

    Private Sub txtPrmLaeRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmLaeRec.Enter
        Tobj = txtPrmLaeRec
        If Trim(txtPrmLaeRec.Text) = "" Then txtPrmLaeRec.Text = txLaeRec
    End Sub

    Private Sub txtPrmLaeRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmLaeRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmLossRec.Focus()
            Case Keys.Down
                txtPrmAgtBalNotDue.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmAgtBalNotDue.Focus()
    End Sub

    Private Sub txtPrmLaeRec_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmLaeRec.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmLaeRec.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmLaeRec_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmLaeRec.Leave
        Tobj = txtPrmLaeRec
    End Sub

    Private Sub txtPrmAgtBalNotDue_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmAgtBalNotDue.Enter
        Tobj = txtPrmAgtBalNotDue
        If Trim(txtPrmAgtBalNotDue.Text) = "" Then txtPrmAgtBalNotDue.Text = txAgtBalNotDue
    End Sub

    Private Sub txtPrmAgtBalNotDue_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmAgtBalNotDue.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmLaeRec.Focus()
            Case Keys.Down
                txtPrmReiPayNotDue.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmReiPayNotDue.Focus()
    End Sub

    Private Sub txtPrmAgtBalNotDue_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmAgtBalNotDue.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmAgtBalNotDue.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmAgtBalNotDue_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmAgtBalNotDue.Leave
        Tobj = txtPrmAgtBalNotDue
    End Sub

    Private Sub txtPrmReiPayNotDue_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmReiPayNotDue.Enter
        Tobj = txtPrmReiPayNotDue
        If Trim(txtPrmReiPayNotDue.Text) = "" Then txtPrmReiPayNotDue.Text = txReiPayNotDue
    End Sub

    Private Sub txtPrmReiPayNotDue_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmReiPayNotDue.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmAgtBalNotDue.Focus()
            Case Keys.Down
                txtPrmStateCode.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmStateCode.Focus()
    End Sub

    Private Sub txtPrmReiPayNotDue_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmReiPayNotDue.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmReiPayNotDue.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmReiPayNotDue_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmReiPayNotDue.Leave
        Tobj = txtPrmReiPayNotDue
    End Sub

    Private Sub txtPrmStateCode_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmStateCode.Enter
        Tobj = txtPrmStateCode
    End Sub

    Private Sub txtPrmStateCode_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmStateCode.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmReiPayNotDue.Focus()
            Case Keys.Down
                txtPrmGrpID.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmGrpID.Focus()
    End Sub

    Private Sub txtPrmStateCode_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmStateCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmStateCode.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmStateCode_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmStateCode.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim X As Integer

        M = "  "
        M = RSet(Tobj.Text, Len(M))

        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                Mobj = cboPrmState
                GetStateName((M))
                If cboPrmState.SelectedIndex = X <> 0 Then
                    Exit Sub
                End If
                Tobj.Text = ""
            End If
        End If

    End Sub

    Private Sub txtPrmStateCode_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmStateCode.Leave
        Tobj = txtPrmStateCode
    End Sub

    Private Sub txtPrmGrpID_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmGrpID.Enter
        Tobj = txtPrmGrpID
    End Sub

    Private Sub txtPrmGrpID_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPrmGrpID.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPrmStateCode.Focus()
            Case Keys.Down
                txtPrmDesc.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPrmDesc.Focus()
    End Sub

    Private Sub txtPrmGrpID_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPrmGrpID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPrmGrpID.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrmGrpID_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPrmGrpID.Leave
        Tobj = txtPrmGrpID

        If Len(Trim(txtPrmMgaNmbr.Text)) = 3 And Len(Trim(txtPrmTrtyNmbr.Text)) = 2 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If
    End Sub

    Private Sub ProcessTrtyPrmRec()
        UpTrtyPrmVars()
        If AddTran Then AddTrtyPrmRec()
        If UpdateTran Then UpTrtyPrmRec()

        InitTrtyPrmForm()
        txtPrmMgaNmbr.Focus()
    End Sub

    Private Sub LoadCboPrmMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboTrtyPrmMga.Items.Clear()
        cboTrtyPrmMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboTrtyPrmMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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

        cboTrtyPrm.Items.Clear()
        cboTrtyPrm.Items.Add("Treaty Parm Not Setup")
        For X1 = 0 To d4recCount(f4)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
                Exit For
            End If
            X = X + 1
            TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
            cboTrtyPrm.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmRptName)))
            rc = d4skip(f4, 1)
        Next X1

        rc = d4bottom(f4)
        rc = d4unlock(f4)
    End Sub

    Private Sub LoadCboState()
        X = 0
        rc = d4top(f90)
        ReDim StateArray(d4recCount(f90) + 1)

        Call d4tagSelect(f90, d4tag(f90, "K1"))

        cboPrmState.Items.Clear()
        cboPrmState.Items.Add("00  State Not Set UP")
        Do Until rc = r4eof
            cboPrmState.Items.Add(Trim(f4str(STp.StateCode)) & "   " & Trim(f4str(STp.StateName)))
            X = X + 1
            StateArray(X) = Trim(f4str(STp.StateCode))
            rc = d4skip(f90, 1)
        Loop

        rc = d4bottom(f90)
        rc = d4unlock(f90)
    End Sub

    Private Sub InitTrtyPrmForm()
        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtPrmMgaNmbr.ReadOnly = False
        txtPrmTrtyNmbr.ReadOnly = False
        cboTrtyPrmMga.ResetText()
        cboTrtyPrm.ResetText()
        cmdRecAction.Visible = False

        txPrmMgaNmbr = ""
        txPrmTrtyNmbr = ""
        txPrmRptName = ""
        txPrmConNmbr = ""
        txPrmReiRptFlag = ""
        txPrmDesc = ""
        txPrmAgtRec = ""
        txPrmReiPay = ""
        txPrmLossRec = ""
        txPrmLaeRec = ""
        txPrmAgtBalNotDue = ""
        txPrmReiPayNotDue = ""
        txPrmIncpDate = ""
        txPrmStatus = "0"
        txPrmGrpID = ""
        txtPrmStateCode.Text = "42"

        'Init GL Codes
        txAgtRec = ""
        txReiPay = ""
        txLossRec = ""
        txLaeRec = ""
        txAgtBalNotDue = ""
        txReiPayNotDue = ""



        txtPrmMgaNmbr.Text = ""
        txtPrmTrtyNmbr.Text = ""
        txtPrmRptName.Text = ""
        txtPrmConNmbr.Text = ""
        txtPrmReiRptFlag.Text = ""
        txtPrmDesc.Text = ""
        txtPrmAgtRec.Text = ""
        txtPrmReiPay.Text = ""
        txtPrmLossRec.Text = ""
        txtPrmLaeRec.Text = ""
        txtPrmAgtBalNotDue.Text = ""
        txtPrmReiPayNotDue.Text = ""
        txtPrmIncpDate.Text = ""
        txtPrmStatus.Text = "0"
        txtPrmGrpID.Text = ""
        txtPrmStateCode.Text = "42"

        If Trim(txtPrmStatus.Text) = "0" Then txtPrmStatus.Text = "Active"
        If Trim(txtPrmStatus.Text) = "1" Then txtPrmStatus.Text = "Inactive"
        If Trim(txtPrmStatus.Text) = "2" Then txtPrmStatus.Text = "Pending"


        'Load Mga Combo Box
        LoadCboPrmMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboPrm()

        ByPassCbo = True
        cboTrtyPrmMga.SelectedIndex = 1
        cboTrtyPrm.SelectedIndex = 1
        cboPrmState.SelectedIndex = 41
        ByPassCbo = False

        s = "   "
        S1 = "  "
    End Sub

    Private Sub GetStateName(ByRef Scode As String)
        M = "  "
        M = RSet(Scode, Len(M))
        Dim X As Integer

        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If Len(M) > 0 Then
            For X = 1 To Mobj.Items.Count
                If StateArray(X) = M Then
                    ByPassCbo = True
                    Mobj.SelectedIndex = X
                    ByPassCbo = False
                    Exit Sub
                End If
            Next X
            Mobj.SelectedIndex = 0
        End If

    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitTrtyPrmForm()
            txtPrmMgaNmbr.Focus()
        End If
    End Sub

    Sub GetGlRef()
        txAgtRec = ""
        txReiPay = ""
        txLossRec = ""
        txLaeRec = ""
        txAgtBalNotDue = ""
        txReiPayNotDue = ""
        Call d4tagSelect(f50, d4tag(f50, "K1"))
        rc = d4seek(f50, Trim(txtPrmMgaNmbr.Text))
        If rc = 0 Then GetGlMgaRefVar()
    End Sub

    Sub UpTrtyPrmFrmVar()
        txtPrmMgaNmbr.Text = txPrmMgaNmbr
        txtPrmTrtyNmbr.Text = txPrmTrtyNmbr
        txtPrmRptName.Text = txPrmRptName
        txtPrmConNmbr.Text = txPrmConNmbr
        txtPrmReiRptFlag.Text = txPrmReiRptFlag
        txtPrmDesc.Text = txPrmDesc
        txtPrmAgtRec.Text = txPrmAgtRec
        txtPrmReiPay.Text = txPrmReiPay
        txtPrmLossRec.Text = txPrmLossRec
        txtPrmLaeRec.Text = txPrmLaeRec
        txtPrmAgtBalNotDue.Text = txPrmAgtBalNotDue
        txtPrmReiPayNotDue.Text = txPrmReiPayNotDue
        txtPrmIncpDate.Text = Mid(txPrmIncpDate, 1, 2) & "/" + Mid(txPrmIncpDate, 3, 4)
        txtPrmStatus.Text = txPrmStatus
        txtPrmGrpID.Text = txPrmGrpID
        txtPrmStateCode.Text = txPrmStateCode

        If Trim(txtPrmStatus.Text) = "0" Then txtPrmStatus.Text = "Active"
        If Trim(txtPrmStatus.Text) = "1" Then txtPrmStatus.Text = "Inactive"
        If Trim(txtPrmStatus.Text) = "2" Then txtPrmStatus.Text = "Pending"
    End Sub

    Sub UpTrtyPrmVars()
        Dim D As String

        txPrmMgaNmbr = txtPrmMgaNmbr.Text
        txPrmTrtyNmbr = txtPrmTrtyNmbr.Text
        txPrmRptName = txtPrmRptName.Text
        txPrmConNmbr = txtPrmConNmbr.Text
        txPrmReiRptFlag = txtPrmReiRptFlag.Text
        txPrmDesc = txtPrmDesc.Text
        txPrmAgtRec = txtPrmAgtRec.Text
        txPrmReiPay = txtPrmReiPay.Text
        txPrmLossRec = txtPrmLossRec.Text
        txPrmLaeRec = txtPrmLaeRec.Text
        txPrmAgtBalNotDue = txtPrmAgtBalNotDue.Text
        txPrmReiPayNotDue = txtPrmReiPayNotDue.Text
        D = txtPrmIncpDate.Text
        txPrmIncpDate = Mid(D, 1, 2) & Mid(D, 4, 4)
        txPrmStatus = txtPrmStatus.Text
        txPrmGrpID = txtPrmGrpID.Text
        txPrmStateCode = txtPrmStateCode.Text

        If txPrmStatus = "Active" Then txPrmStatus = "0"
        If txPrmStatus = "Inactive" Then txPrmStatus = "1"
        If txPrmStatus = "Pending" Then txPrmStatus = "2"
    End Sub

End Class