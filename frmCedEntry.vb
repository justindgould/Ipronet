Option Strict Off
Option Explicit On

Friend Class frmCedEntry
    Inherits DevExpress.XtraEditors.XtraForm

    Private MgaOk As Boolean
    Private TrtyOk As Boolean
    Private PeriodOk As Boolean
    Private CatOk As Boolean
    Private YearOk As Boolean
    Private ValPP As Boolean
    Private ValCM As Boolean
    Private ValOT As Boolean
    Private Tot As Double
    Private Tot1 As Double

    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        ProcessCedTrans()
        cmdRecAction.Visible = False
    End Sub

    Private Sub cmdRecAction_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdRecAction.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedTotal.Focus()
            Case Keys.Down
                txtCedTotal.Focus()
        End Select

        ResetForm((KeyCode))
    End Sub

    Private Sub cmdRecAction_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Leave
        cmdRecAction.Visible = False
    End Sub

    Private Sub frmCedEntry_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        OpenCatMst()
        OpenPeriod()
        If CedFileNmbr = 1 Then OpenRptCed1()
        If CedFileNmbr = 2 Then OpenRptCed2()
        If CedFileNmbr = 3 Then OpenRptCed3()
        If CedFileNmbr = 4 Then OpenRptCed4()
        If CedFileNmbr = 5 Then OpenRptCed5()

        If CedFileNmbr = 1 Then Me.Text = Me.Text & " Session 1"
        If CedFileNmbr = 2 Then Me.Text = Me.Text & " Excess Session 1"
        If CedFileNmbr = 3 Then Me.Text = Me.Text & " Excess Session 2"
        If CedFileNmbr = 4 Then Me.Text = Me.Text & " Excess Session 3"
        If CedFileNmbr = 5 Then Me.Text = Me.Text & " Excess Session 4"

        AddTran = False
        UpdateTran = False
        InitCedForm()
    End Sub

    Private Sub frmCedEntry_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Private Sub LoadCboMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboCedMga.Items.Clear()
        cboCedMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboCedMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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

        cboCedTrty.Items.Clear()
        cboCedTrty.Items.Add("Treaty Inactive or Not Setup")
        For X1 = 0 To d4recCount(f4)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
                Exit For
            End If
            If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec
            X = X + 1
            TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
            cboCedTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmDesc)))
nextrec:
            rc = d4skip(f4, 1)
        Next X1

        rc = d4bottom(f4)
        rc = d4unlock(f4)
    End Sub

    Private Sub LoadCboCat()
        X = 0
        ReDim CatArray(d4recCount(f91) + 1)

        cboCedCatDesc.Items.Clear()
        cboCedCatDesc.Items.Add("Cat Code Not Setup")

        Call d4tagSelect(f91, d4tag(f91, "K1"))
        rc = d4seek(f91, "00")

        Do Until rc = r4eof
            cboCedCatDesc.Items.Add(Trim(f4str(CMp.CatCode)) & "   " & Trim(f4str(CMp.CatDesc)))
            X = X + 1
            CatArray(X) = Trim(f4str(CMp.CatCode))
            rc = d4skip(f91, 1)
        Loop
        rc = d4bottom(f91)
        rc = d4unlock(f91)
    End Sub

    Private Sub cboCedTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboCedTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtCedTrtyNmbr.Text = Mid(Trim(cboCedTrty.Text), 1, 2)
        TrtyKey = Mid(Trim(cboCedMga.Text), 1, 3) & Mid(Trim(cboCedTrty.Text), 1, 2)
        RdTrtyPrmRec()
        RdTrtyMstRec()
        LdCovArry()
        txtCedTrtyNmbr.Focus()
    End Sub

    Private Sub cboCedTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboCedTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboCedMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboCedMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboCedMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboCedTrty.Items.Count > 1 Then
            cboCedTrty.SelectedIndex = 1
        Else
            cboCedTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then
                txtCedMgaNmbr.Text = Mid(Trim(cboCedMga.Text), 1, 3)
                MgaOk = True
            End If
            txtCedTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboCedMga.Text), 1, 3)
            M1 = cboCedMga.SelectedIndex
            InitCedForm()
            txtCedMgaNmbr.Text = M
            cboCedMga.SelectedIndex = M1
            txtCedMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cboCedMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboCedMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboCedCatDesc_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboCedCatDesc.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtCedCatCode.Text = Mid(cboCedCatDesc.Text, 1, 2)
        txtCedCatCode.Focus()
    End Sub

    Private Sub cboCedCatDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboCedCatDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Public Sub mnuOcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOcomments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtCedMgaNmbr.Text
            Ctrty = txtCedTrtyNmbr.Text
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
        DelRptCedRec()
        InitCedForm()
        txtCedMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitCedForm()
        txtCedMgaNmbr.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        If Not ValRec() Then Exit Sub
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUcomments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtCedMgaNmbr.Text
            Ctrty = txtCedTrtyNmbr.Text
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
        DelRptCedRec()
        InitCedForm()
        txtCedMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitCedForm()
        txtCedMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        If Not ValRec() Then Exit Sub
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtCedMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedMgaNmbr.Enter
        CovCnt = 0
        Tobj = txtCedMgaNmbr
    End Sub

    Private Sub txtCedMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtCedTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtCedTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtCedMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedMgaNmbr.KeyUp
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
                For X = 1 To cboCedMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboCedMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboCedMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If
    End Sub

    Private Sub txtCedMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedMgaNmbr.Leave
        Dim X As Integer
        Tobj = txtCedMgaNmbr
        MgaOk = False

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s
        MgaKey = s
        RdMgaMstRec()
        If Fstat <> 0 Then
            If Tobj.Text <> "" And Tobj.Text <> "000" Then
                MsgBox("MGA Master Record Does Not Exist.")
                txtCedMgaNmbr.Focus()
                Exit Sub
            End If
        End If

        If Tobj.Text = "000" Then
            Exit Sub
        End If
        MgaOk = True
    End Sub

    Private Sub txtCedTranTotal_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedTranTotal.Enter
        If Not ValRec() Then Exit Sub
        If ValPP Then
            txtPPbi.Focus()
            Exit Sub
        End If

        If ValCM Then
            txtCMbi.Focus()
            Exit Sub
        End If

        If ValOT Then
            txtOTim.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtCedTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedTrtyNmbr.Enter
        Dim X As Integer
        Tobj = txtCedTrtyNmbr

        If Not MgaOk Then
            txtCedMgaNmbr.Focus()
            Exit Sub
        End If

        If Len(txtCedMgaNmbr.Text) > 0 Then
            For X = 1 To cboCedMga.Items.Count
                If MgaArray(X) = Trim(txtCedMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboCedMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboCedMga.SelectedIndex = 0
        End If

    End Sub

    Private Sub txtCedTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedMgaNmbr.Focus()
            Case Keys.Down
                txtCedPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtCedPeriod.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtCedTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedTrtyNmbr.KeyUp
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
                For X = 0 To cboCedTrty.Items.Count
                    If Len(Tobj.Text) > 2 Then Exit For
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboCedTrty.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboCedTrty.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtCedTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedTrtyNmbr.Leave
        Dim X As Integer
        Tobj = txtCedTrtyNmbr
        TrtyOk = False

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        TrtyKey = Trim(txtCedMgaNmbr.Text) & Trim(txtCedTrtyNmbr.Text)
        RdTrtyMstRec()
        If Fstat <> 0 Then
            If Tobj.Text <> "" And Tobj.Text <> "00" Then
                MsgBox("Treaty Record Does Not Exist.")
                Exit Sub
            End If
        End If

        If Tobj.Text = "00" Then
            txtCedMgaNmbr.Focus()
            Tobj.Text = ""
            Exit Sub
        End If

        LdCovArry()
        TrtyOk = True
    End Sub

    Private Sub txtCedPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedPeriod.Enter
        Dim X As Integer
        ByPassTxt = False
        Tobj = txtCedPeriod

        If Len(txtCedTrtyNmbr.Text) > 0 Then
            For X = 0 To cboCedTrty.Items.Count
                If TrtyArray(X) = Trim(txtCedTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboCedTrty.SelectedIndex = X
                    ByPassCbo = False
                    If Trim(txtCedPeriod.Text) = "" Then txtCedPeriod.Text = CurrPeriod
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboCedTrty.SelectedIndex = 0
            ByPassCbo = False
        End If

        If cboCedTrty.SelectedIndex = 0 Then
            MsgBox("Invalid Treaty")
            txtCedTrtyNmbr.Focus()
        End If

    End Sub

    Private Sub txtCedPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedTrtyNmbr.Focus()
            Case Keys.Down
                txtCedCatCode.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtCedCatCode.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtCedPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedPeriod.Leave
        Dim X As Integer
        Tobj = txtCedPeriod

        PeriodOk = False

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))

        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = S1

        If S1 = "00" Then Tobj.Text = ""


        'Check for Valid Period
        If Not ByPassTxt Then
            If Val(S1) < 1 Or Val(S1) > 12 Then
                MsgBox("Invalid Period")
                Exit Sub
            End If
            If Warry(Val(S1)) <> 1 Then
                MsgBox("Invalid Period")
                Exit Sub
            End If
        End If

        PeriodOk = True
    End Sub

    Private Sub txtCedCatCode_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedCatCode.Enter
        Tobj = txtCedCatCode
    End Sub

    Private Sub txtCedCatCode_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedCatCode.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedPeriod.Focus()
            Case Keys.Down
                txtCedYear.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtCedYear.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtCedCatCode_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedCatCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedCatCode.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedCatCode_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedCatCode.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String
        Dim X As Integer

        M = "  "
        M = RSet(txtCedCatCode.Text, Len(M))
        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 0 To cboCedCatDesc.Items.Count
                    If CatArray(X) = M Then
                        ByPassCbo = True
                        cboCedCatDesc.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboCedCatDesc.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtCedCatCode_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedCatCode.Leave
        Dim X As Integer
        Tobj = txtCedCatCode

        CatOk = False

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = S1
        CatKey = S1
        RdCatMstRec()
        If Fstat <> 0 And S1 <> "00" Then
            If Tobj.Text <> "" Then
                MsgBox("Cat Record Does Not Exist.")
                ByPassCbo = True
                cboCedCatDesc.SelectedIndex = 0
                ByPassCbo = False
                txtCedCatCode.Focus()
                Exit Sub
            End If
        End If
        CatOk = True
    End Sub

    Private Sub txtCedYear_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedYear.Enter
        Dim X As Integer
        If Len(txtCedCatCode.Text) > 0 Then
            For X = 0 To cboCedCatDesc.Items.Count
                If CatArray(X) = txtCedCatCode.Text Then
                    ByPassCbo = True
                    cboCedCatDesc.SelectedIndex = X
                    ByPassCbo = False
                    Exit For
                End If
                ByPassCbo = True
                cboCedCatDesc.SelectedIndex = 0
                ByPassCbo = False
            Next X
        End If
        Tobj = txtCedYear
    End Sub

    Private Sub txtCedYear_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedYear.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedCatCode.Focus()
            Case Keys.Down
                txtCedTotal.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtCedTotal.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtCedYear_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedYear.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedYear.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedYear_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedYear.Leave
        Dim M2, M, M1, M3 As Object
        Dim M4 As String
        Dim W, W1 As Object
        Dim W2 As Short
        Dim X As Integer

        YearOk = False
        Tobj = txtCedYear

        If Len(Trim(txtCedMgaNmbr.Text)) = 3 And Len(Trim(txtCedTrtyNmbr.Text)) = 2 And Len(Trim(txtCedPeriod.Text)) = 2 And Len(Trim(txtCedCatCode.Text)) = 2 And Len(Trim(txtCedYear.Text)) = 4 Then

            'Check for valid year other than losses
            If txtCedCatCode.Text = "01" Or txtCedCatCode.Text = "02" Or txtCedCatCode.Text = "03" Or txtCedCatCode.Text = "04" Or txtCedCatCode.Text = "05" Or txtCedCatCode.Text = "11" Or txtCedCatCode.Text = "12" Or txtCedCatCode.Text = "15" Or txtCedCatCode.Text = "16" Then
                If Parry(1) <> Val(txtCedYear.Text) Then
                    MsgBox("Invalid Year")
                    txtCedYear.Focus()
                    Exit Sub
                End If
            End If

            'Check for valid year losses
            If txtCedCatCode.Text = "06" Or txtCedCatCode.Text = "07" Or txtCedCatCode.Text = "08" Or txtCedCatCode.Text = "09" Or txtCedCatCode.Text = "10" Or txtCedCatCode.Text = "13" Or txtCedCatCode.Text = "14" Then
                If Val(txtCedYear.Text) < 1990 Or Val(txtCedYear.Text) > Parry(1) Then
                    MsgBox("Invalid Year")
                    txtCedYear.Focus()
                    Exit Sub
                End If
            End If

            'Continue
            RptCedKey = Trim(txtCedMgaNmbr.Text) & Trim(txtCedTrtyNmbr.Text) & Trim(txtCedPeriod.Text) & Trim(txtCedCatCode.Text) & Trim(txtCedYear.Text)
            GetRptCedRec()

            If Fstat = r4locked Then
                InitCedForm()
                txtCedMgaNmbr.Focus()
                Exit Sub
            End If

            If UpdateTran Then
                txCedMgaNmbr = Trim(txtCedMgaNmbr.Text)
                txCedTrtyNmbr = Trim(txtCedTrtyNmbr.Text)
                txCedPeriod = Trim(txtCedPeriod.Text)
                txCedCatCode = (txtCedCatCode).Text
                txCedYear = Trim(txtCedYear.Text)
                UpRptCedFrmVar()
                txtCedMgaNmbr.ReadOnly = True
                txtCedTrtyNmbr.ReadOnly = True
                txtCedPeriod.ReadOnly = True
                txtCedCatCode.ReadOnly = True
                txtCedYear.ReadOnly = True
                txtCedTotal.Text = Trim(Str(MLobt))
                TotalTran()
                txtCedTotal.Focus()
                YearOk = True
                Exit Sub
            End If

            If AddTran Then
                MLobt = 0
                For X = 1 To 24
                    MLobp(X) = 0
                Next X

                M = txtCedMgaNmbr.Text
                M1 = txtCedTrtyNmbr.Text
                M2 = txtCedPeriod.Text
                M3 = txtCedCatCode.Text
                M4 = txtCedYear.Text
                W = cboCedMga.SelectedIndex
                W1 = cboCedTrty.SelectedIndex
                W2 = cboCedCatDesc.SelectedIndex
                AddTran = True
                txtCedMgaNmbr.Text = M
                txtCedTrtyNmbr.Text = M1
                txtCedPeriod.Text = M2
                txtCedCatCode.Text = M3
                txtCedYear.Text = M4
                ByPassCbo = True
                cboCedMga.SelectedIndex = W
                cboCedTrty.SelectedIndex = W1
                cboCedCatDesc.SelectedIndex = W2
                ByPassCbo = False
            End If
        End If

        If Len(Trim(txtCedYear.Text)) <> 4 Then Exit Sub

        'Compute Commisison Total
        If txtCedCatCode.Text = "03" Then
            Tot1 = CInt(Tot * f4double(TMp.DirCommPerc) * 100) / 100
            lblRecAction.Visible = True
            lblRecAction.Text = Format(Tot1, "###,###,###.00") & " - Computed Commission"
            MLobt = 0
        End If

        'Compute Front Fee and Tax
        If txtCedCatCode.Text = "11" Or txtCedCatCode.Text = "12" Then
            RptCedKey = Trim(txtCedMgaNmbr.Text) & Trim(txtCedTrtyNmbr.Text) & Trim(txtCedPeriod.Text) & "02" & Trim(txtCedYear.Text)
            Call d4tagSelect(f6, d4tag(f6, "K1"))
            rc = d4seek(f6, RptCedKey)
            If rc = 0 Then Tot = Tot + f4double(Rc1p.CedTotal) ' Add Policy Fee
            If txtCedCatCode.Text = "11" Then
                Tot1 = CInt(Tot * f4double(TMp.TrtyFFperc) * 100) / 100
                lblRecAction.Visible = True
                lblRecAction.Text = Format(Tot1, "###,###,###.00") & " - Computed Front Fee"
            End If
            If txtCedCatCode.Text = "12" Then
                Tot1 = CInt(Tot * f4double(TMp.TrtyPremTaxPerc) * 100) / 100
                lblRecAction.Visible = True
                lblRecAction.Text = Format(Tot1, "###,###,###.00") & " - Computed Premium Tax"
            End If
            MLobt = 0
        End If

        YearOk = True
    End Sub

    Private Sub txtCedTotal_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedTotal.Enter
        If Fstat = r4locked Then Exit Sub
        If Not ValRec() Then Exit Sub
        txtCedTotal.TextAlign = HorizontalAlignment.Left
        txtCedTotal.Text = Trim(Str(MLobt))
        Tobj = txtCedTotal
    End Sub

    Private Sub txtCedTotal_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCedTotal.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedYear.Focus()
            Case Keys.Down
                If ValPP Then txtPPbi.Focus()
                If ValCM Then txtCMbi.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then
            If txtCedCatCode.Text = "02" Or txtCedCatCode.Text = "11" Or txtCedCatCode.Text = "12" Or txtCedCatCode.Text = "15" Or txtCedCatCode.Text = "16" Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            Else
                If ValPP Then txtPPbi.Focus()
                If ValCM Then txtCMbi.Focus()
            End If
        End If
    End Sub

    Private Sub txtCedTotal_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCedTotal.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCedTotal.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCedTotal_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCedTotal.Leave
        Tobj = txtCedTotal

        If (Not MgaOk) Or (Not TrtyOk) Or (Not PeriodOk) Or (Not CatOk) Or (Not YearOk) Then
            Exit Sub
        End If

        txtCedTotal.TextAlign = HorizontalAlignment.Right
        MLobt = Val(txtCedTotal.Text)
        txtCedTotal.Text = Format(MLobt, "###,###,###.00")

        If txtCedCatCode.Text = "03" Then
            If MLobt <> Tot1 Then Tot1 = MLobt
        End If
    End Sub

    Private Sub txtPPbi_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPbi.Enter
        If Not ValRec() Then Exit Sub

        If CovArry(1) = 0 Or IvalCat() Then
            txtPPpd.Focus()
            Exit Sub
        End If

        If Not ValPP Then
            CovCnt = CovCnt + 1
            txtCMbi.Focus()
            Exit Sub
        End If

        txtPPbi.TextAlign = HorizontalAlignment.Left
        txtPPbi.Text = Trim(Str(MLobp(1)))
        Tobj = txtPPbi
        If CovArry(1) = 1 Then txtPPbi.Focus()
    End Sub

    Private Sub txtPPbi_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPbi.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCedTotal.Focus()
            Case Keys.Down
                txtPPpd.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPpd.Focus()
    End Sub

    Private Sub txtPPbi_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPbi.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPbi.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPbi_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPbi.Leave
        Tobj = txtPPbi

        If CovCnt > 6 Or (Not MgaOk) Or (Not TrtyOk) Or (Not PeriodOk) Or (Not CatOk) Or (Not YearOk) Or (Not ValPP) Then
            Exit Sub
        End If

        If Not ValPP Then Exit Sub

        txtPPbi.TextAlign = HorizontalAlignment.Right
        MLobp(1) = Val(txtPPbi.Text)
        txtPPbi.Text = Format(MLobp(1), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPpd_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPpd.Enter
        If Not ValRec() Then Exit Sub

        If CovArry(2) = 0 Or IvalCat() Then
            txtPPmed.Focus()
            Exit Sub
        End If

        txtPPpd.TextAlign = HorizontalAlignment.Left
        txtPPpd.Text = Trim(Str(MLobp(2)))
        Tobj = txtPPpd
    End Sub

    Private Sub txtPPpd_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPpd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPbi.Focus()
            Case Keys.Down
                txtPPmed.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPmed.Focus()
    End Sub

    Private Sub txtPPpd_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPpd.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPpd.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPpd_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPpd.Leave
        Tobj = txtPPpd
        txtPPpd.TextAlign = HorizontalAlignment.Right
        MLobp(2) = Val(txtPPpd.Text)
        txtPPpd.Text = Format(MLobp(2), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPmed_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPmed.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(3) = 0 Or IvalCat() Then
            txtPPumbi.Focus()
            Exit Sub
        End If
        If Not ValPP Then
            txtCMbi.Focus()
            Exit Sub
        End If
        txtPPmed.TextAlign = HorizontalAlignment.Left
        txtPPmed.Text = Trim(Str(MLobp(3)))
        Tobj = txtPPmed
    End Sub

    Private Sub txtPPmed_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPmed.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPpd.Focus()
            Case Keys.Down
                txtPPumbi.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPumbi.Focus()
    End Sub

    Private Sub txtPPmed_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPmed.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPmed.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPmed_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPmed.Leave
        Tobj = txtPPmed
        txtPPmed.TextAlign = HorizontalAlignment.Right
        MLobp(3) = Val(txtPPmed.Text)
        If Not ValPP Then Exit Sub
        txtPPmed.Text = Format(MLobp(3), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPumbi_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPumbi.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(4) = 0 Or IvalCat() Then
            txtPPumpd.Focus()
            Exit Sub
        End If
        txtPPumbi.TextAlign = HorizontalAlignment.Left
        txtPPumbi.Text = Trim(Str(MLobp(4)))
        Tobj = txtPPumbi
    End Sub

    Private Sub txtPPumbi_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPumbi.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPmed.Focus()
            Case Keys.Down
                txtPPumpd.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPumpd.Focus()
    End Sub

    Private Sub txtPPumbi_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPumbi.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPumbi.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPumbi_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPumbi.Leave
        Tobj = txtPPumbi
        txtPPumbi.TextAlign = HorizontalAlignment.Right
        MLobp(4) = Val(txtPPumbi.Text)
        If Not ValPP Then Exit Sub
        txtPPumbi.Text = Format(MLobp(4), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPumpd_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPumpd.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(5) = 0 Or IvalCat() Then
            txtPPpip.Focus()
            Exit Sub
        End If
        txtPPumpd.TextAlign = HorizontalAlignment.Left
        txtPPumpd.Text = Trim(Str(MLobp(5)))
        Tobj = txtPPumpd
    End Sub

    Private Sub txtPPumpd_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPumpd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPumbi.Focus()
            Case Keys.Down
                txtPPpip.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPpip.Focus()
    End Sub

    Private Sub txtPPumpd_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPumpd.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPumpd.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPumpd_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPumpd.Leave
        Tobj = txtPPumpd
        txtPPumpd.TextAlign = HorizontalAlignment.Right
        MLobp(5) = Val(txtPPumpd.Text)
        If Not ValPP Then Exit Sub
        txtPPumpd.Text = Format(MLobp(5), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPpip_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPpip.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(6) = 0 Or IvalCat() Then
            txtPPcomp.Focus()
            Exit Sub
        End If
        txtPPpip.TextAlign = HorizontalAlignment.Left
        txtPPpip.Text = Trim(Str(MLobp(6)))
        Tobj = txtPPpip
    End Sub

    Private Sub txtPPpip_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPpip.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPumpd.Focus()
            Case Keys.Down
                txtPPcomp.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPcomp.Focus()
    End Sub

    Private Sub txtPPpip_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPpip.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPpip.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPpip_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPpip.Leave
        Tobj = txtPPpip
        txtPPpip.TextAlign = HorizontalAlignment.Right
        MLobp(6) = Val(txtPPpip.Text)
        If Not ValPP Then Exit Sub
        txtPPpip.Text = Format(MLobp(6), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPcomp_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPcomp.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(7) = 0 Or IvalCat() Then
            txtPPcoll.Focus()
            Exit Sub
        End If
        txtPPcomp.TextAlign = HorizontalAlignment.Left
        txtPPcomp.Text = Trim(Str(MLobp(7)))
        Tobj = txtPPcomp
    End Sub

    Private Sub txtPPcomp_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPcomp.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPpip.Focus()
            Case Keys.Down
                txtPPcoll.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPcoll.Focus()
    End Sub

    Private Sub txtPPcomp_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPcomp.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPcomp.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPcomp_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPcomp.Leave
        Tobj = txtPPcomp
        txtPPcomp.TextAlign = HorizontalAlignment.Right
        MLobp(7) = Val(txtPPcomp.Text)
        If Not ValPP Then Exit Sub
        txtPPcomp.Text = Format(MLobp(7), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPcoll_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPcoll.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(8) = 0 Or IvalCat() Then
            txtPPrent.Focus()
            Exit Sub
        End If
        txtPPcoll.TextAlign = HorizontalAlignment.Left
        txtPPcoll.Text = Trim(Str(MLobp(8)))
        Tobj = txtPPcoll
    End Sub

    Private Sub txtPPcoll_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPcoll.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPcomp.Focus()
            Case Keys.Down
                txtPPrent.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPrent.Focus()
    End Sub

    Private Sub txtPPcoll_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPcoll.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPcoll.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPcoll_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPcoll.Leave
        Tobj = txtPPcoll
        txtPPcoll.TextAlign = HorizontalAlignment.Right
        MLobp(8) = Val(txtPPcoll.Text)
        If Not ValPP Then Exit Sub
        txtPPcoll.Text = Format(MLobp(8), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPrent_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPrent.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(9) = 0 Or IvalCat() Then
            txtPPtow.Focus()
            Exit Sub
        End If
        txtPPrent.TextAlign = HorizontalAlignment.Left
        txtPPrent.Text = Trim(Str(MLobp(9)))
        Tobj = txtPPrent
    End Sub

    Private Sub txtPPrent_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPrent.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPcoll.Focus()
            Case Keys.Down
                txtPPtow.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtPPtow.Focus()
    End Sub

    Private Sub txtPPrent_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPrent.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPrent.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPrent_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPrent.Leave
        Tobj = txtPPrent
        txtPPrent.TextAlign = HorizontalAlignment.Right
        MLobp(9) = Val(txtPPrent.Text)
        If Not ValPP Then Exit Sub
        txtPPrent.Text = Format(MLobp(9), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtPPtow_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPtow.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(10) = 0 Or IvalCat() Then
            txtCMbi.Focus()
            Exit Sub
        End If
        txtPPtow.TextAlign = HorizontalAlignment.Left
        txtPPtow.Text = Trim(Str(MLobp(10)))
        Tobj = txtPPtow
    End Sub

    Private Sub txtPPtow_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPPtow.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPrent.Focus()
            Case Keys.Down
                txtPPbi.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If
    End Sub

    Private Sub txtPPtow_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtPPtow.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtPPtow.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPPtow_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtPPtow.Leave
        Tobj = txtPPtow

        If Not ValPP Then Exit Sub

        txtPPtow.TextAlign = HorizontalAlignment.Right
        MLobp(10) = Val(txtPPtow.Text)
        txtPPtow.Text = Format(MLobp(10), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtCMbi_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMbi.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(11) = 0 Or IvalCat() Then
            txtPPbi.Focus()
            Exit Sub
        End If

        txtCMbi.TextAlign = HorizontalAlignment.Left
        txtCMbi.Text = Trim(Str(MLobp(11)))
        Tobj = txtCMbi
    End Sub

    Private Sub txtCMbi_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMbi.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtPPtow.Focus()
            Case Keys.Down
                txtCMpd.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMpd.Focus()
    End Sub

    Private Sub txtCMbi_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMbi.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMbi.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMbi_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMbi.Leave
        Tobj = txtCMbi

        If CovCnt > 6 Or (Not MgaOk) Or (Not TrtyOk) Or (Not PeriodOk) Or (Not CatOk) Or (Not YearOk) Or (Not ValCM) Then
            Exit Sub
        End If

        If Not ValCM Then Exit Sub

        txtCMbi.TextAlign = HorizontalAlignment.Right
        MLobp(11) = Val(txtCMbi.Text)
        txtCMbi.Text = Format(MLobp(11), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtCMpd_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMpd.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(12) = 0 Or IvalCat() Then
            txtCMmed.Focus()
            Exit Sub
        End If
        txtCMpd.TextAlign = HorizontalAlignment.Left
        txtCMpd.Text = Trim(Str(MLobp(12)))
        Tobj = txtCMpd
    End Sub

    Private Sub txtCMpd_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMpd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMbi.Focus()
            Case Keys.Down
                txtCMmed.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMmed.Focus()
    End Sub

    Private Sub txtCMpd_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMpd.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMpd.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMpd_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMpd.Leave
        Tobj = txtCMpd
        If Not ValCM Then Exit Sub
        txtCMpd.TextAlign = HorizontalAlignment.Right
        MLobp(12) = Val(txtCMpd.Text)
        txtCMpd.Text = Format(MLobp(12), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtCMmed_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMmed.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(13) = 0 Or IvalCat() Then
            txtCMumbi.Focus()
            Exit Sub
        End If
        txtCMmed.TextAlign = HorizontalAlignment.Left
        txtCMmed.Text = Trim(Str(MLobp(13)))
        Tobj = txtCMmed
    End Sub

    Private Sub txtCMmed_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMmed.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMpd.Focus()
            Case Keys.Down
                txtCMumbi.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMumbi.Focus()
    End Sub

    Private Sub txtCMmed_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMmed.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMmed.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMmed_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMmed.Leave
        Tobj = txtCMmed
        txtCMmed.TextAlign = HorizontalAlignment.Right
        MLobp(13) = Val(txtCMmed.Text)
        txtCMmed.Text = Format(MLobp(13), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtCMumbi_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMumbi.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(14) = 0 Or IvalCat() Then
            txtCMumpd.Focus()
            Exit Sub
        End If
        txtCMumbi.TextAlign = HorizontalAlignment.Left
        txtCMumbi.Text = Trim(Str(MLobp(14)))
        Tobj = txtCMumbi
    End Sub

    Private Sub txtCMumbi_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMumbi.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMmed.Focus()
            Case Keys.Down
                txtCMumpd.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMumpd.Focus()
    End Sub

    Private Sub txtCMumbi_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMumbi.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMumbi.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMumbi_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMumbi.Leave
        txtCMumbi.TextAlign = HorizontalAlignment.Right
        MLobp(14) = Val(txtCMumbi.Text)
        txtCMumbi.Text = Format(MLobp(14), "###,###,###.00")
        Tobj = txtCMumbi
        TotalTran()
    End Sub

    Private Sub txtCMumpd_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMumpd.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(15) = 0 Or IvalCat() Then
            txtCMpip.Focus()
            Exit Sub
        End If
        txtCMumpd.TextAlign = HorizontalAlignment.Left
        txtCMumpd.Text = Trim(Str(MLobp(15)))
        Tobj = txtCMumpd
    End Sub

    Private Sub txtCMumpd_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMumpd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMumbi.Focus()
            Case Keys.Down
                txtCMpip.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMpip.Focus()
    End Sub

    Private Sub txtCMumpd_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMumpd.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMumpd.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMumpd_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMumpd.Leave
        txtCMumpd.TextAlign = HorizontalAlignment.Right
        MLobp(15) = Val(txtCMumpd.Text)
        txtCMumpd.Text = Format(MLobp(15), "###,###,###.00")
        Tobj = txtCMumpd
        TotalTran()
    End Sub

    Private Sub txtCMpip_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMpip.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(16) = 0 Or IvalCat() Then
            txtCMcomp.Focus()
            Exit Sub
        End If
        txtCMpip.TextAlign = HorizontalAlignment.Left
        txtCMpip.Text = Trim(Str(MLobp(16)))
        Tobj = txtCMpip
    End Sub

    Private Sub txtCMpip_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMpip.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMumpd.Focus()
            Case Keys.Down
                txtCMcomp.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMcomp.Focus()
    End Sub

    Private Sub txtCMpip_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMpip.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMpip.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMpip_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMpip.Leave
        txtCMpip.TextAlign = HorizontalAlignment.Right
        MLobp(16) = Val(txtCMpip.Text)
        txtCMpip.Text = Format(MLobp(16), "###,###,###.00")
        Tobj = txtCMpip
        TotalTran()
    End Sub

    Private Sub txtCMcomp_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMcomp.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(17) = 0 Or IvalCat() Then
            txtCMcoll.Focus()
            Exit Sub
        End If
        txtCMcomp.TextAlign = HorizontalAlignment.Left
        txtCMcomp.Text = Trim(Str(MLobp(17)))
        Tobj = txtCMcomp
    End Sub

    Private Sub txtCMcomp_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMcomp.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMpip.Focus()
            Case Keys.Down
                txtCMcoll.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMcoll.Focus()
    End Sub

    Private Sub txtCMcomp_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMcomp.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMcomp.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMcomp_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMcomp.Leave
        txtCMcomp.TextAlign = HorizontalAlignment.Right
        MLobp(17) = Val(txtCMcomp.Text)
        txtCMcomp.Text = Format(MLobp(17), "###,###,###.00")
        Tobj = txtCMcomp
        TotalTran()
    End Sub

    Private Sub txtCMcoll_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMcoll.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(18) = 0 Or IvalCat() Then
            txtCMrent.Focus()
            Exit Sub
        End If
        txtCMcoll.TextAlign = HorizontalAlignment.Left
        txtCMcoll.Text = Trim(Str(MLobp(18)))
        Tobj = txtCMcoll
    End Sub

    Private Sub txtCMcoll_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMcoll.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMcomp.Focus()
            Case Keys.Down
                txtCMrent.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMrent.Focus()
    End Sub

    Private Sub txtCMcoll_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMcoll.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMcoll.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMcoll_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMcoll.Leave
        txtCMcoll.TextAlign = HorizontalAlignment.Right
        MLobp(18) = Val(txtCMcoll.Text)
        txtCMcoll.Text = Format(MLobp(18), "###,###,###.00")
        Tobj = txtCMcoll
        TotalTran()
    End Sub

    Private Sub txtCMrent_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMrent.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(19) = 0 Or IvalCat() Then
            txtCMtow.Focus()
            Exit Sub
        End If
        txtCMrent.TextAlign = HorizontalAlignment.Left
        txtCMrent.Text = Trim(Str(MLobp(19)))
        Tobj = txtCMrent
    End Sub

    Private Sub txtCMrent_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMrent.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMcoll.Focus()
            Case Keys.Down
                txtCMtow.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtCMtow.Focus()
    End Sub

    Private Sub txtCMrent_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMrent.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMrent.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMrent_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMrent.Leave
        txtCMrent.TextAlign = HorizontalAlignment.Right
        MLobp(19) = Val(txtCMrent.Text)
        txtCMrent.Text = Format(MLobp(19), "###,###,###.00")
        Tobj = txtCMrent
        TotalTran()
    End Sub

    Private Sub txtCMtow_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMtow.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(20) = 0 Or IvalCat() Then
            txtOTim.Focus()
            Exit Sub
        End If
        txtCMtow.TextAlign = HorizontalAlignment.Left
        txtCMtow.Text = Trim(Str(MLobp(20)))
        Tobj = txtCMtow
    End Sub

    Private Sub txtCMtow_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtCMtow.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMrent.Focus()
            Case Keys.Down
                txtOTim.Focus()
        End Select

        ResetForm((KeyCode))

        If CovArry(21) = 1 Then
            If KeyCode = 13 Or KeyCode = 114 Then txtOTim.Focus()
        End If

        If CovArry(21) = 0 Then
            If KeyCode = 13 Or KeyCode = 114 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If

    End Sub

    Private Sub txtCMtow_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtCMtow.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtCMtow.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCMtow_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMtow.Leave
        Tobj = txtCMtow

        If Not ValCM Then Exit Sub

        txtCMtow.TextAlign = HorizontalAlignment.Right
        MLobp(20) = Val(txtCMtow.Text)
        txtCMtow.Text = Format(MLobp(20), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtOTim_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTim.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(21) = 0 Or IvalCat() Then
            txtCMbi.Focus()
            Exit Sub
        End If
        txtOTim.TextAlign = HorizontalAlignment.Left
        txtOTim.Text = Trim(Str(MLobp(21)))
        Tobj = txtOTim
    End Sub

    Private Sub txtOTim_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtOTim.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtCMtow.Focus()
            Case Keys.Down
                txtOTallied.Focus()
        End Select

        ResetForm((KeyCode))

        If CovArry(22) = 1 Then
            If KeyCode = 13 Or KeyCode = 114 Then txtOTallied.Focus()
        End If

        If CovArry(22) = 0 Then
            If KeyCode = 13 Or KeyCode = 114 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If

    End Sub

    Private Sub txtOTim_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtOTim.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtOTim.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtOTim_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTim.Leave
        Tobj = txtOTim

        If Not ValOT Then Exit Sub

        If CovCnt > 6 Or (Not MgaOk) Or (Not TrtyOk) Or (Not PeriodOk) Or (Not CatOk) Or (Not YearOk) Or (Not ValOT) Then
            Exit Sub
        End If
        txtOTim.TextAlign = HorizontalAlignment.Right
        MLobp(21) = Val(txtOTim.Text)
        txtOTim.Text = Format(MLobp(21), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtOTallied_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTallied.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(22) = 0 Or IvalCat() Then
            txtOTfire.Focus()
            Exit Sub
        End If
        txtOTallied.TextAlign = HorizontalAlignment.Left
        txtOTallied.Text = Trim(Str(MLobp(22)))
        Tobj = txtOTallied
    End Sub

    Private Sub txtOTallied_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtOTallied.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtOTim.Focus()
            Case Keys.Down
                txtOTfire.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtOTfire.Focus()
    End Sub

    Private Sub txtOTallied_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtOTallied.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtOTallied.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtOTallied_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTallied.Leave
        Tobj = txtOTallied

        If Not ValOT Then Exit Sub

        txtOTallied.TextAlign = HorizontalAlignment.Right
        MLobp(22) = Val(txtOTallied.Text)
        txtOTallied.Text = Format(MLobp(22), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtOTfire_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTfire.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(23) = 0 Or IvalCat() Then
            txtOTmulti.Focus()
            Exit Sub
        End If
        txtOTfire.TextAlign = HorizontalAlignment.Left
        txtOTfire.Text = Trim(Str(MLobp(23)))
        Tobj = txtOTfire
    End Sub

    Private Sub txtOTfire_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtOTfire.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtOTallied.Focus()
            Case Keys.Down
                txtOTmulti.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtOTmulti.Focus()
    End Sub

    Private Sub txtOTfire_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtOTfire.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtOTfire.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtOTfire_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTfire.Leave
        Tobj = txtOTfire

        If Not ValOT Then Exit Sub

        txtOTfire.TextAlign = HorizontalAlignment.Right
        MLobp(23) = Val(txtOTfire.Text)
        txtOTfire.Text = Format(MLobp(23), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub txtOTmulti_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTmulti.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(24) = 0 Or IvalCat() Then
            txtOTim.Focus()
            Exit Sub
        End If
        txtOTmulti.TextAlign = HorizontalAlignment.Left
        txtOTmulti.Text = Trim(Str(MLobp(24)))
        Tobj = txtOTmulti
    End Sub

    Private Sub txtOTmulti_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtOTmulti.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtOTfire.Focus()
            Case Keys.Down
                txtCMbi.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If
    End Sub

    Private Sub txtOTmulti_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtOTmulti.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtOTmulti.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtOTmulti_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtOTmulti.Leave
        Tobj = txtOTmulti

        If Not ValOT Then Exit Sub

        txtOTmulti.TextAlign = HorizontalAlignment.Right
        MLobp(24) = Val(txtOTmulti.Text)
        txtOTmulti.Text = Format(MLobp(24), "###,###,###.00")
        TotalTran()
    End Sub

    Private Sub InitCedForm()
        Dim X As Integer

        rc = d4unlock(f6) ' CedDIR
        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        MgaOk = False
        TrtyOk = False
        PeriodOk = False
        CatOk = False
        YearOk = False
        CovCnt = 0

        txtCedMgaNmbr.ReadOnly = False
        txtCedTrtyNmbr.ReadOnly = False
        txtCedPeriod.ReadOnly = False
        txtCedCatCode.ReadOnly = False
        txtCedYear.ReadOnly = False
        cboCedMga.ResetText()
        cboCedTrty.ResetText()
        cboCedCatDesc.ResetText()
        lblRecAction.Visible = False
        cmdRecAction.Visible = False

        txCedMgaNmbr = ""
        txCedTrtyNmbr = ""
        txCedPeriod = ""
        txCedCatCode = ""
        txCedYear = ""

        MLobt = 0
        For X = 0 To 24
            MLobp(X) = 0
            CovArry(X) = 0
            Wcomm(X) = False
        Next X

        txtCedMgaNmbr.Text = ""
        txtCedTrtyNmbr.Text = ""
        txtCedPeriod.Text = ""
        txtCedCatCode.Text = ""
        txtCedYear.Text = ""
        txtCedTotal.Text = ""
        txtPPbi.Text = ""
        txtPPpd.Text = ""
        txtPPmed.Text = ""
        txtPPumbi.Text = ""
        txtPPumpd.Text = ""
        txtPPpip.Text = ""
        txtPPcomp.Text = ""
        txtPPcoll.Text = ""
        txtPPrent.Text = ""
        txtPPtow.Text = ""
        txtCMbi.Text = ""
        txtCMpd.Text = ""
        txtCMmed.Text = ""
        txtCMumbi.Text = ""
        txtCMumpd.Text = ""
        txtCMpip.Text = ""
        txtCMcomp.Text = ""
        txtCMcoll.Text = ""
        txtCMrent.Text = ""
        txtCMtow.Text = ""
        txtOTim.Text = ""
        txtOTallied.Text = ""
        txtOTfire.Text = ""
        txtOTmulti.Text = ""
        txtCedTranTotal.Text = ""

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        'Load Categoray Desc
        LoadCboCat()


        ByPassCbo = True
        cboCedMga.SelectedIndex = 1
        cboCedTrty.SelectedIndex = 1
        cboCedCatDesc.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
        S1 = "  "

        GetPeriodData()
    End Sub

    Private Sub TotalTran()
        Dim X As Integer
        Wtotal = 0

        For X = 1 To 24
            Wtotal = Wtotal + MLobp(X)
        Next

        txtCedTranTotal.Text = Format(Wtotal, "###,###,###.00")
    End Sub

    Private Sub LdCovArry()
        Dim X As Integer
        ValPP = False
        ValCM = False
        ValOT = False

        CovArry(1) = f4int(TMp.PPBI)
        CovArry(2) = f4int(TMp.PPPD)
        CovArry(3) = f4int(TMp.PPMED)
        CovArry(4) = f4int(TMp.PPUMBI)
        CovArry(5) = f4int(TMp.PPUMPD)
        CovArry(6) = f4int(TMp.PPPIP)
        CovArry(7) = f4int(TMp.PPCOMP)
        CovArry(8) = f4int(TMp.PPCOLL)
        CovArry(9) = f4int(TMp.PPRENT)
        CovArry(10) = f4int(TMp.PPTOW)
        CovArry(11) = f4int(TMp.CMBI)
        CovArry(12) = f4int(TMp.CMPD)
        CovArry(13) = f4int(TMp.CMMED)
        CovArry(14) = f4int(TMp.CMUMBI)
        CovArry(15) = f4int(TMp.CMUMPD)
        CovArry(16) = f4int(TMp.CMPIP)
        CovArry(17) = f4int(TMp.CMCOMP)
        CovArry(18) = f4int(TMp.CMCOLL)
        CovArry(19) = f4int(TMp.CMRENT)
        CovArry(20) = f4int(TMp.CMTOW)
        CovArry(21) = f4int(TMp.IM)
        CovArry(22) = f4int(TMp.ALLIED)
        CovArry(23) = f4int(TMp.FIRE)
        CovArry(24) = f4int(TMp.MULTIP)

        For X = 0 To 24
            If X > 0 And X < 11 Then
                If CovArry(X) = 1 Then ValPP = True
            End If
            If X > 10 And X < 21 Then
                If CovArry(X) = 1 Then ValCM = True
            End If
            If X > 20 Then
                If CovArry(X) = 1 Then ValOT = True
            End If
        Next

    End Sub

    Private Sub ProcessCedTrans()
        Dim response As Object

        response = 0
        If Not MgaOk Or Not TrtyOk Or Not PeriodOk Or Not CatOk Or Not YearOk Then
            InitCedForm()
            txtCedMgaNmbr.Focus()
            Exit Sub
        End If

        TotalTran()
        If txtCedCatCode.Text <> "02" And txtCedCatCode.Text <> "11" And txtCedCatCode.Text <> "12" And txtCedCatCode.Text <> "15" And txtCedCatCode.Text <> "16" And txtCedCatCode.Text <> "17" Then
            If CDec(Wtotal) <> CDec(MLobt) Then
                MsgBox("Record Total Out Of Balance", MsgBoxStyle.Exclamation, "Balance Error")
                If ValPP Then
                    txtPPbi.Focus()
                    Exit Sub
                End If
                If ValCM Then
                    txtCMbi.Focus()
                    Exit Sub
                End If
                If ValOT Then
                    txtOTim.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Not ValUser() Then Exit Sub
        If AddTran Then
            response = MsgBox("Add Record", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Add Record")
        End If
        If UpdateTran Then
            response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
        End If
        If response = MsgBoxResult.No Then
            If txtCedCatCode.Text <> "02" And txtCedCatCode.Text <> "11" And txtCedCatCode.Text <> "12" And txtCedCatCode.Text <> "15" And txtCedCatCode.Text <> "16" Then
                If ValPP Then txtPPbi.Focus()
                If ValCM Then txtCMbi.Focus()
                If ValOT Then txtOTim.Focus()
            Else
                txtCedTotal.Focus()
            End If
            Exit Sub
        End If

        UpRptCedVars()
        If AddTran Then AddRptCedRec()
        If UpdateTran Then UpRptCedRec()
        If Not AddTran And Not UpdateTran Then MsgBox("No Record To Process")

        InitCedForm()
        txtCedMgaNmbr.Focus()
    End Sub

    Function ValRec() As Object
        ValRec = False
        If CovCnt > 6 Or (Not MgaOk) Or (Not TrtyOk) Or (Not PeriodOk) Or (Not CatOk) Or (Not YearOk) Then
            MsgBox("Not enough info to process")
            InitCedForm()
            txtCedMgaNmbr.Focus()
            Exit Function
        End If
        ValRec = True
    End Function

    Function IvalCat() As Object
        IvalCat = False
        If txtCedCatCode.Text = "02" Or txtCedCatCode.Text = "11" Or txtCedCatCode.Text = "12" Or txtCedCatCode.Text = "15" Or txtCedCatCode.Text = "16" Then
            IvalCat = True
        End If
    End Function

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitCedForm()
            txtCedMgaNmbr.Focus()
        End If
    End Sub

    Sub UpRptCedFrmVar()
        txtCedMgaNmbr.Text = txCedMgaNmbr
        txtCedTrtyNmbr.Text = txCedTrtyNmbr
        txtCedPeriod.Text = txCedPeriod
        txtCedCatCode.Text = txCedCatCode
        txtCedYear.Text = txCedYear
        txtCedTotal.Text = Format(MLobt, "##,###,###.00")
        txtPPbi.Text = Format(MLobp(1), "##,###,###.00")
        txtPPpd.Text = Format(MLobp(2), "##,###,###.00")
        txtPPmed.Text = Format(MLobp(3), "##,###,###.00")
        txtPPumbi.Text = Format(MLobp(4), "##,###,###.00")
        txtPPumpd.Text = Format(MLobp(5), "##,###,###.00")
        txtPPpip.Text = Format(MLobp(6), "##,###,###.00")
        txtPPcomp.Text = Format(MLobp(7), "##,###,###.00")
        txtPPcoll.Text = Format(MLobp(8), "##,###,###.00")
        txtPPrent.Text = Format(MLobp(9), "##,###,###.00")
        txtPPtow.Text = Format(MLobp(10), "##,###,###.00")
        txtCMbi.Text = Format(MLobp(11), "##,###,###.00")
        txtCMpd.Text = Format(MLobp(12), "##,###,###.00")
        txtCMmed.Text = Format(MLobp(13), "##,###,###.00")
        txtCMumbi.Text = Format(MLobp(14), "##,###,###.00")
        txtCMumpd.Text = Format(MLobp(15), "##,###,###.00")
        txtCMpip.Text = Format(MLobp(16), "##,###,###.00")
        txtCMcomp.Text = Format(MLobp(17), "##,###,###.00")
        txtCMcoll.Text = Format(MLobp(18), "##,###,###.00")
        txtCMrent.Text = Format(MLobp(19), "##,###,###.00")
        txtCMtow.Text = Format(MLobp(20), "##,###,###.00")
        txtOTim.Text = Format(MLobp(21), "##,###,###.00")
        txtOTallied.Text = Format(MLobp(22), "##,###,###.00")
        txtOTfire.Text = Format(MLobp(23), "##,###,###.00")
        txtOTmulti.Text = Format(MLobp(24), "##,###,###.00")
    End Sub

    Sub UpRptCedVars()
        txCedMgaNmbr = txtCedMgaNmbr.Text
        txCedTrtyNmbr = txtCedTrtyNmbr.Text
        txCedPeriod = txtCedPeriod.Text
        txCedCatCode = txtCedCatCode.Text
        txCedYear = txtCedYear.Text
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class