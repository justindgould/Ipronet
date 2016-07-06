Option Strict Off
Option Explicit On

Friend Class frmCatMnt
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub cboCatDesc_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboCatDesc.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        CatKey = Mid(cboCatDesc.Text, 1, 2)
        GetCatMstRec()
        UpCatMntFrmVar()
        If Fstat = 0 Then
            txtCatCode.ReadOnly = True
            txtCatDesc.Focus()
            UpdateTran = True
        Else
            txtCatDesc.Text = ""
            txtCatCode.Text = ""
            txtCatCode.Focus()
        End If
    End Sub

    Private Sub cboCatDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboCatDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            InitCatForm()
            txtCatCode.Focus()
        End If
    End Sub

    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        Dim response As Object

        response = 0

        If AddTran Then
            response = MsgBox("Add Record", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Add Record")
        End If

        If UpdateTran Then
            response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
        End If

        If Not AddTran And Not UpdateTran Then MsgBox("No Record To Process")

        If response = MsgBoxResult.Yes Then ProcessCatMstRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitCatForm()
            txtCatCode.Focus()
        End If
    End Sub

    Private Sub cmdRecAction_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdRecAction.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            InitCatForm()
            txtCatCode.Focus()
        End If
    End Sub

    Private Sub cmdRecAction_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Leave
        cmdRecAction.Visible = False
    End Sub

    Private Sub frmCatMnt_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        OpenCatMst()
        InitCatForm()
    End Sub

    Private Sub frmCatMnt_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
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
        DelCatMstRec()
        InitCatForm()
        txtCatCode.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitCatForm()
        txtCatCode.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub mnuMgaExit_Click()
        Me.Close()
    End Sub

    Public Sub mnuUdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelCatMstRec()
        InitCatForm()
        txtCatCode.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitCatForm()
        txtCatCode.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtCatCode_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCatCode.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtCatDesc.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtCatDesc.Focus()

        If KeyCode = 27 Or KeyCode = 110 Then
            InitCatForm()
            txtCatCode.Focus()
        End If

    End Sub

    Private Sub txtCatCode_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCatCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If


        If KeyAscii <> BACK_KEY Then txtCatCode.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCatCode_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCatCode.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String
        Dim X As Integer

        If txtCatCode.Text = "00" Then
            Me.Close()
            Exit Sub
        End If

        M = "  "
        M = RSet(txtCatCode.Text, Len(M))

        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 0 To cboCatDesc.Items.Count
                    If CatArray(X) = M Then
                        ByPassCbo = True
                        cboCatDesc.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboCatDesc.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtCatCode_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCatCode.Leave
        Dim M As String
        Dim M1 As Short
        Dim X As Integer

        Tobj = txtCatCode

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        If S1 = "00" Then S1 = ""
        Tobj.Text = S1

        If Len(Trim(Tobj.Text)) = 2 Then
            CatKey = Tobj.Text
            GetCatMstRec()
            If Fstat = r4locked Then
                txtCatCode.Focus()
                Exit Sub
            End If
            If UpdateTran Then
                UpCatMntFrmVar()
                txtCatCode.ReadOnly = True
            End If
            If AddTran Then
                M = Tobj.Text
                M1 = cboCatDesc.SelectedIndex
                InitCatForm()
                AddTran = True
                Tobj.Text = M
                ByPassCbo = True
                cboCatDesc.SelectedIndex = M1
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtCatDesc_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCatDesc.Enter
        Dim X As Integer

        If Len(txtCatCode.Text) > 0 Then
            For X = 0 To cboCatDesc.Items.Count
                If CatArray(X) = txtCatCode.Text Then
                    ByPassCbo = True
                    cboCatDesc.SelectedIndex = X
                    ByPassCbo = False
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboCatDesc.SelectedIndex = 0
            ByPassCbo = False
        End If

    End Sub

    Private Sub txtCatDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCatDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtCatCode.Focus()
            Case Keys.Down
                txtCatCode.Focus()
        End Select

        If KeyCode = 27 Or KeyCode = 110 Then
            InitCatForm()
            txtCatCode.Focus()
            Exit Sub
        End If

        If KeyCode = 13 Then
            If Len(Trim(txtCatCode.Text)) = 2 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If
    End Sub

    Private Sub txtCatDesc_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCatDesc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCatDesc.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub ProcessCatMstRec()
        UpCatMstVars()
        If AddTran Then AddCatMstRec()
        If UpdateTran Then UpCatMstRec()
        InitCatForm()
        txtCatCode.Focus()
    End Sub

    Private Sub InitCatForm()
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtCatCode.ReadOnly = False
        cmdRecAction.Visible = False

        txCatCode = ""
        txCatDesc = ""

        txtCatCode.Text = ""
        txtCatDesc.Text = ""

        LoadCboCat()

        ByPassCbo = True
        cboCatDesc.SelectedIndex = 1
        ByPassCbo = False

        S1 = "  "
    End Sub

    Private Sub LoadCboCat()
        X = 0
        ReDim CatArray(d4recCount(f91) + 1)

        cboCatDesc.Items.Clear()
        cboCatDesc.Items.Add("Cat Code Not Setup")

        Call d4tagSelect(f91, d4tag(f91, "K1"))
        rc = d4seek(f91, "00")

        Do Until rc = r4eof
            cboCatDesc.Items.Add(Trim(f4str(CMp.CatCode)) & "   " & Trim(f4str(CMp.CatDesc)))
            X = X + 1
            CatArray(X) = Trim(f4str(CMp.CatCode))
            rc = d4skip(f91, 1)
        Loop
        rc = d4bottom(f91)
        rc = d4unlock(f91)
    End Sub

    Sub UpCatMntFrmVar()
        txtCatCode.Text = txCatCode
        txtCatDesc.Text = txCatDesc
    End Sub

    Sub UpCatMstVars()
        txCatCode = txtCatCode.Text
        txCatDesc = txtCatDesc.Text
    End Sub

End Class