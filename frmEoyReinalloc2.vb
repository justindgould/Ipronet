Option Strict Off
Option Explicit On

Imports DevExpress.XtraTreeList.Nodes

Friend Class frmEoyReinalloc2
    Inherits DevExpress.XtraEditors.XtraForm

    Dim AcctDate As String
    Dim Ystr As String
    Dim Y As Short

    Dim Nstr As String
    Dim Nstr1 As String

    Dim A1 As Double
    Dim D(10) As Double
    Dim D1(10, 17) As Double
    Dim D2(3) As Double
    Dim N1 As Double
    Dim T As Double
    Dim RcedPerc(10) As Double

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

        If ByPassTxt Then Exit Sub

        If Not ByPassTxt Then txtMgaNmbr.Text = Mid(Trim(cboMga.Text), 1, 3)
        txtTrtyNmbr.Text = ""
        M = Mid(Trim(cboMga.Text), 1, 3)
        M1 = cboMga.SelectedIndex
        txtMgaNmbr.Text = M
        cboMga.SelectedIndex = M1
        txtTrtyNmbr.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cboMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cboTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtTrtyNmbr.Text = Mid(Trim(cboTrty.Text), 1, 2)
        TrtyKey = Mid(Trim(cboMga.Text), 1, 3) & Mid(Trim(cboTrty.Text), 1, 2)
        RdTrtyPrmRec()
    End Sub

    Private Sub cboTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 27 Or KeyCode = 110 Then
            txtMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cmdContinue_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdContinue.Click
        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()

        If rc <> 0 Then
            MsgBox("Invalid MGA Treaty")
            txtMgaNmbr.Text = ""
            txtTrtyNmbr.Text = ""
            txtMgaNmbr.Focus()
            Exit Sub
        End If

        'Treaty Master Info
        GetTrtyMstVar()
        GetTrtyReiVar()

        Rnmbr(1) = f4str(TMp.TrtyReiNmbr1)
        Rnmbr(2) = f4str(TMp.TrtyReiNmbr2)
        Rnmbr(3) = f4str(TMp.TrtyReiNmbr3)
        Rnmbr(4) = f4str(TMp.TrtyReiNmbr4)
        Rnmbr(5) = f4str(TMp.TrtyReiNmbr5)
        Rnmbr(6) = f4str(TMp.TrtyReiNmbr6)
        Rnmbr(7) = f4str(TMp.TrtyReiNmbr7)
        Rnmbr(8) = f4str(TMp.TrtyReiNmbr8)
        Rnmbr(9) = f4str(TMp.TrtyReiNmbr9)
        Rnmbr(10) = f4str(TMp.TrtyReiNmbr10)

        RcedPerc(1) = f4double(TMp.TrtyReiPerc1)
        RcedPerc(2) = f4double(TMp.TrtyReiPerc2)
        RcedPerc(3) = f4double(TMp.TrtyReiPerc3)
        RcedPerc(4) = f4double(TMp.TrtyReiPerc4)
        RcedPerc(5) = f4double(TMp.TrtyReiPerc5)
        RcedPerc(6) = f4double(TMp.TrtyReiPerc6)
        RcedPerc(7) = f4double(TMp.TrtyReiPerc7)
        RcedPerc(8) = f4double(TMp.TrtyReiPerc8)
        RcedPerc(9) = f4double(TMp.TrtyReiPerc9)
        RcedPerc(10) = f4double(TMp.TrtyReiPerc10)

        RptCedKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        AcctDate = Trim(Str(Parry(1))) & cboPeriod.Text

        CedTran()

        TreeList1.ClearNodes()

        txtMgaNmbr.Text = ""
        txtTrtyNmbr.Text = ""
        txtReiPay.Text = ""
        txtLossRec.Text = ""
        txtLaeRec.Text = ""
        txtMgaTotal.Text = ""
        txtMgaNmbr.Focus()
    End Sub

    Private Sub cmdContinue_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdContinue.Enter
        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()

        If rc <> 0 Then
            MsgBox("Invalid MGA Treaty")
            txtMgaNmbr.Text = ""
            txtTrtyNmbr.Text = ""
            txtMgaNmbr.Focus()
            Exit Sub
        End If

        'Treaty Master Info
        GetTrtyMstVar()
        GetTrtyReiVar()

        Rnmbr(1) = f4str(TMp.TrtyReiNmbr1)
        Rnmbr(2) = f4str(TMp.TrtyReiNmbr2)
        Rnmbr(3) = f4str(TMp.TrtyReiNmbr3)
        Rnmbr(4) = f4str(TMp.TrtyReiNmbr4)
        Rnmbr(5) = f4str(TMp.TrtyReiNmbr5)
        Rnmbr(6) = f4str(TMp.TrtyReiNmbr6)
        Rnmbr(7) = f4str(TMp.TrtyReiNmbr7)
        Rnmbr(8) = f4str(TMp.TrtyReiNmbr8)
        Rnmbr(9) = f4str(TMp.TrtyReiNmbr9)
        Rnmbr(10) = f4str(TMp.TrtyReiNmbr10)

        RcedPerc(1) = f4double(TMp.TrtyReiPerc1)
        RcedPerc(2) = f4double(TMp.TrtyReiPerc2)
        RcedPerc(3) = f4double(TMp.TrtyReiPerc3)
        RcedPerc(4) = f4double(TMp.TrtyReiPerc4)
        RcedPerc(5) = f4double(TMp.TrtyReiPerc5)
        RcedPerc(6) = f4double(TMp.TrtyReiPerc6)
        RcedPerc(7) = f4double(TMp.TrtyReiPerc7)
        RcedPerc(8) = f4double(TMp.TrtyReiPerc8)
        RcedPerc(9) = f4double(TMp.TrtyReiPerc9)
        RcedPerc(10) = f4double(TMp.TrtyReiPerc10)


        Dim parentForRootNodes As TreeListNode = Nothing
        Dim X As Integer

        TreeList1.ClearNodes()
        TreeList1.BeginUnboundLoad()

        For X = 1 To 10
            If CDbl(Rnmbr(X)) <> 0 Then TreeList1.AppendNode(New Object() {Rnmbr(X), Format(RcedPerc(X), "0.0000"), Trim(Rname(X))}, parentForRootNodes)
        Next

        TreeList1.EndUnboundLoad()

    End Sub

    Private Sub frmEoyReinalloc2_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        GetPeriodData()

        Ystr = Trim(Str(Parry(1))) 'Curr Year

        OpenRptCed1()
        OpenReinAlloc()

        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        OpenReiMst()

        'Load Mga Combo Box
        LoadCboMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        cboTrty.SelectedIndex = 1
        ByPassCbo = False

        TreeList1.BeginUpdate()
        TreeList1.Columns.Add()
        TreeList1.Columns(0).Caption = "Rein Number"
        TreeList1.Columns(0).VisibleIndex = 0
        TreeList1.Columns.Add()
        TreeList1.Columns(1).Caption = "%"
        TreeList1.Columns(1).VisibleIndex = 1
        TreeList1.Columns.Add()
        TreeList1.Columns(2).Caption = "Rein Name"
        TreeList1.Columns(2).VisibleIndex = 2
        TreeList1.EndUpdate()
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub txtMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Enter
        Dim X As Integer

        Tobj = txtMgaNmbr

        For X = 1 To 3
            D2(X) = 0
        Next X
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

    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Dim X As Integer

        Tobj = txtMgaNmbr
        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()

        If s = "000" Then Tobj.Text = ""
        If Fstat <> 0 Then
            If Tobj.Text <> "" Then MsgBox("MGA Master Record Does Not Exist.")
        End If
    End Sub

    Private Sub txtTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyNmbr.Enter
        Dim X As Integer

        Tobj = txtTrtyNmbr

        If Len(txtTrtyNmbr.Text) > 0 Then
            For X = 1 To cboMga.Items.Count
                If MgaArray(X) = Trim(txtMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboMga.SelectedIndex = 0
        End If

    End Sub

    Private Sub txtTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaNmbr.Focus()
            Case Keys.Down
                txtReiPay.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtReiPay.Focus()

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
        Dim X As Integer

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

    End Sub

    Private Sub txtReiPay_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPay.Enter
        txtReiPay.TextAlign = HorizontalAlignment.Left
        txtReiPay.Text = Format(D2(1), "########.00")
        Tobj = txtReiPay


        MgaKey = Trim(txtMgaNmbr.Text)
        RdMgaMstRec()
        GetMgaMstVar()

        TrtyKey = Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text)
        RdTrtyMstRec()

        If rc <> 0 Then
            MsgBox("Invalid MGA Treaty")
            txtMgaNmbr.Text = ""
            txtTrtyNmbr.Text = ""
            txtMgaNmbr.Focus()
            Exit Sub
        End If

        'Treaty Master Info
        GetTrtyMstVar()
        GetTrtyReiVar()

        Rnmbr(1) = f4str(TMp.TrtyReiNmbr1)
        Rnmbr(2) = f4str(TMp.TrtyReiNmbr2)
        Rnmbr(3) = f4str(TMp.TrtyReiNmbr3)
        Rnmbr(4) = f4str(TMp.TrtyReiNmbr4)
        Rnmbr(5) = f4str(TMp.TrtyReiNmbr5)
        Rnmbr(6) = f4str(TMp.TrtyReiNmbr6)
        Rnmbr(7) = f4str(TMp.TrtyReiNmbr7)
        Rnmbr(8) = f4str(TMp.TrtyReiNmbr8)
        Rnmbr(9) = f4str(TMp.TrtyReiNmbr9)
        Rnmbr(10) = f4str(TMp.TrtyReiNmbr10)

        RcedPerc(1) = f4double(TMp.TrtyReiPerc1)
        RcedPerc(2) = f4double(TMp.TrtyReiPerc2)
        RcedPerc(3) = f4double(TMp.TrtyReiPerc3)
        RcedPerc(4) = f4double(TMp.TrtyReiPerc4)
        RcedPerc(5) = f4double(TMp.TrtyReiPerc5)
        RcedPerc(6) = f4double(TMp.TrtyReiPerc6)
        RcedPerc(7) = f4double(TMp.TrtyReiPerc7)
        RcedPerc(8) = f4double(TMp.TrtyReiPerc8)
        RcedPerc(9) = f4double(TMp.TrtyReiPerc9)
        RcedPerc(10) = f4double(TMp.TrtyReiPerc10)


        Dim parentForRootNodes As TreeListNode = Nothing
        Dim X As Integer

        TreeList1.ClearNodes()
        TreeList1.BeginUnboundLoad()

        For X = 1 To 10
            If CDbl(Rnmbr(X)) <> 0 Then TreeList1.AppendNode(New Object() {Rnmbr(X), Format(RcedPerc(X), "0.0000"), Trim(Rname(X))}, parentForRootNodes)
        Next

        TreeList1.EndUnboundLoad()
    End Sub

    Private Sub txtReiPay_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiPay.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyNmbr.Focus()
            Case Keys.Down
                txtLossRec.Focus()
        End Select
        If KeyCode = 13 Or KeyCode = 114 Then txtLossRec.Focus()
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

        txtReiPay.TextAlign = HorizontalAlignment.Right
        D2(1) = Val(txtReiPay.Text)
        txtReiPay.Text = Format(D2(1), "##,###,###.00")
        txtMgaTotal.Text = Format(D2(1) + D2(2) + D2(3), "##,###,###.00")
    End Sub


    Private Sub txtLossRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLossRec.Enter
        txtLossRec.TextAlign = HorizontalAlignment.Left
        txtLossRec.Text = Format(D2(2), "########.00")
        Tobj = txtLossRec
    End Sub

    Private Sub txtLossRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtLossRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiPay.Focus()
            Case Keys.Down
                txtLaeRec.Focus()
        End Select
        If KeyCode = 13 Or KeyCode = 114 Then txtLaeRec.Focus()
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

        txtLossRec.TextAlign = HorizontalAlignment.Right
        D2(2) = Val(txtLossRec.Text)
        txtLossRec.Text = Format(D2(2), "##,###,###.00")
        txtMgaTotal.Text = Format(D2(1) + D2(2) + D2(3), "##,###,###.00")
    End Sub

    Private Sub txtLaeRec_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtLaeRec.Enter
        txtLaeRec.TextAlign = HorizontalAlignment.Left
        txtLaeRec.Text = Format(D2(3), "########.00")
        Tobj = txtLaeRec
    End Sub

    Private Sub txtLaeRec_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtLaeRec.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtLossRec.Focus()
            Case Keys.Down
                cmdContinue.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then
            cmdContinue.Focus()
        End If
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

        txtLaeRec.TextAlign = HorizontalAlignment.Right
        D2(3) = Val(txtLaeRec.Text)
        txtLaeRec.Text = Format(D2(3), "##,###,###.00")
        txtMgaTotal.Text = Format(D2(1) + D2(2) + D2(3), "##,###,###.00")
    End Sub

    Private Sub LoadCboMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboMga.Items.Clear()
        cboMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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

        cboTrty.Items.Clear()
        cboTrty.Items.Add("Treaty Inactive or Not Setup")
        For X1 = 0 To d4recCount(f4)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
                Exit For
            End If
            If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec
            X = X + 1
            TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
            cboTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmDesc)))
nextrec:
            rc = d4skip(f4, 1)
        Next X1

        rc = d4bottom(f4)
        rc = d4unlock(f4)
    End Sub

    Private Sub CedTran()
        Dim A(24) As Double
        Dim N2 As Double
        Dim X2 As Short
        Dim X As Integer

        For X = 1 To 10
            For X1 = 1 To 17
                D1(X, X1) = 0
            Next X1
        Next X

        X2 = 0
        Do Until X2 > 2
            X2 = X2 + 1

            'Calc Reinsurer Cession Totals

            A1 = D2(X2)
            T = 0 : N1 = 0 : Y = 0
            For X = 1 To 10
                D(X) = 0

                If CDbl(RcedPerc(X)) = 0 Then Exit For

                'Compute Ceded Rei Total
                N2 = A1 * CDbl(RcedPerc(X))
                Nstr = ".00" : Nstr1 = ""

                'Rounding Adjustment
                If N2 >= 0 Then N2 = N2 + 0.005
                If N2 < 0 Then N2 = N2 - 0.005

                If InStr(1, Str(N2), ".", 1) <> 0 Then
                    If A1 <> 0 Then Nstr = Mid(Str(N2), InStr(1, Str(N2), ".", 1), 3)
                    If A1 <> 0 Then Nstr1 = Microsoft.VisualBasic.Left(Str(N2), InStr(1, Str(N2), ".", 1) - 1)
                End If

                If InStr(1, Str(N2), ".", 1) = 0 Then
                    If A1 <> 0 Then Nstr1 = Str(N2)
                End If

                D(X) = Val(Trim(Nstr1) & Trim(Nstr))
                T = T + D(X)

                'Rounding Logic
                If D(X) > 0 Then
                    If D(X) > N1 Then
                        N1 = D(X)
                        Y = X
                    End If
                End If

                If D(X) < 0 Then
                    If D(X) < N1 Then
                        N1 = D(X)
                        Y = X
                    End If
                End If
            Next X

            'Adjust for Rounding Cession Total
            N2 = A1 - T
            D(Y) = D(Y) + N2

            'Accumulate
            For X = 1 To 10
                If X2 = 1 Then D1(X, 12) = D1(X, 12) + D(X)
                If X2 = 2 Then D1(X, 13) = D1(X, 13) + D(X)
                If X2 = 3 Then D1(X, 14) = D1(X, 14) + D(X)
            Next X

nextrec:
        Loop

        'Write Reinalloc Record
        For X = 1 To 10
            If CDbl(RcedPerc(X)) = 0 Then Exit For
            ReinAllocKey = Trim(Rnmbr(X)) & Trim(txtMgaNmbr.Text) & Trim(txtTrtyNmbr.Text) & "1"

            GetReinAllocRec()
            If AddTran Then
                If d4appendStart(f30, 0) <> r4success Then
                    MsgBox("Reinalloc Processing Error.   Notify Supervisor")
                    GoTo nextrec
                End If
            End If

            If AddTran Then
                Call f4assign(RAp.MgaNmbr, txtMgaNmbr.Text)
                Call f4assign(RAp.TrtyNmbr, txtTrtyNmbr.Text)
                Call f4assign(RAp.ReiNmbr, Trim(Rnmbr(X)))
                Call f4assign(RAp.Cession, "1")
                Call f4assignDouble(RAp.Premium, D1(X, 1))
                Call f4assignDouble(RAp.PolFee, D1(X, 2))
                Call f4assignDouble(RAp.Commision, D1(X, 3))
                Call f4assignDouble(RAp.Unearned, D1(X, 4))
                Call f4assignDouble(RAp.PaidLoss, D1(X, 5))
                Call f4assignDouble(RAp.Salvage, D1(X, 6))
                Call f4assignDouble(RAp.PaidLae, D1(X, 7))
                Call f4assignDouble(RAp.OsLoss, D1(X, 8))
                Call f4assignDouble(RAp.OsLAE, D1(X, 9))
                Call f4assignDouble(RAp.IbnrLoss, D1(X, 10))
                Call f4assignDouble(RAp.IbnrLAE, D1(X, 11))
                Call f4assignDouble(RAp.D30, D1(X, 15))
                Call f4assignDouble(RAp.D90, D1(X, 16))
                Call f4assignDouble(RAp.D120, D1(X, 17))
            End If

            Call f4assignDouble(RAp.Perc, RcedPerc(X))
            Call f4assignDouble(RAp.ReinPay, D1(X, 12))
            Call f4assignDouble(RAp.LossRec, D1(X, 13))
            Call f4assignDouble(RAp.LaeRec, D1(X, 14))

            If AddTran Then rc = d4append(f30)
            rc = d4unlock(f30)
        Next X
    End Sub
End Class