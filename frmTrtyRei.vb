Option Strict Off
Option Explicit On

Friend Class frmTrtyRei
    Inherits DevExpress.XtraEditors.XtraForm

    Private Oarry1() As Object
    Private Oarry2() As Object
    Private Oarry3() As Object

    Private ShiftTest As Short
    Private Ced2TranExists As Boolean
    Private Ced3TranExists As Boolean
    Private ProcessCessionRec As Boolean
    Private AddCessionRec As Boolean
    Private UpdateCessionRec As Boolean

    Private CedNmbr As String

    Private Sub cboTrtyRei_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrtyRei.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        If Not AddTran And Not UpdateTran Then
            txtTrtyReiTrtyNmbr.Text = Mid(Trim(cboTrtyRei.Text), 1, 2)
        End If
        TrtyKey = Mid(Trim(cboTrtyReiMga.Text), 1, 3) & Mid(Trim(cboTrtyRei.Text), 1, 2)
        GetTrtyMstRec()
        UpTrtyReiFrmVar()
        txtTrtyReiMgaNmbr.ReadOnly = True
        txtTrtyReiTrtyNmbr.ReadOnly = True
        txtTrtyReiNmbr1.Focus()
        UpdateTran = True
    End Sub

    Private Sub cboTrtyRei_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrtyRei.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cboTrtyReiMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboTrtyReiMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboTrtyReiMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboTrtyRei.Items.Count > 1 Then
            cboTrtyRei.SelectedIndex = 1
        Else
            cboTrtyRei.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then txtTrtyReiMgaNmbr.Text = Mid(Trim(cboTrtyReiMga.Text), 1, 3)
            txtTrtyReiTrtyNmbr.Text = ""
        End If

        If UpdateTran Then
            M = Mid(Trim(cboTrtyReiMga.Text), 1, 3)
            M1 = cboTrtyReiMga.SelectedIndex
            InitTrtyReiForm()
            txtTrtyReiMgaNmbr.Text = M
            cboTrtyReiMga.SelectedIndex = M1
            txtTrtyReiTrtyNmbr.Text = ""
            txtTrtyReiMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cboTrtyReiMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboTrtyReiMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        Dim response As Short

        If UpdateTran Then
            response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
        End If
        If Not UpdateTran Then MsgBox("No Record To Process")

        If response = MsgBoxResult.Yes Then
            If ProcessCessionRec Then
                ProcessXTrtyReiRec()
                Exit Sub
            Else
                ProcessTrtyReiRec()
                Exit Sub
            End If
        End If

        If response = MsgBoxResult.No Or (Not UpdateTran) Then
            InitTrtyReiForm()
            txtTrtyReiMgaNmbr.Focus()
        End If
    End Sub

    Private Sub cmdRecAction_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdRecAction.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cmdRecAction_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Leave
        cmdRecAction.Visible = True
    End Sub

    Private Sub frmTrtyRei_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        OpenReiMst()
        OpenTrtyMst()
        OpenXTrtyMst()
        AddTran = False
        UpdateTran = False
        InitTrtyReiForm()
    End Sub

    Private Sub frmTrtyRei_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitTrtyReiForm()
        txtTrtyReiMgaNmbr.Focus()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuTrtyComments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuTrtyComments.Click
        If UpdateTran Then frmTrtyComments.ShowDialog()
    End Sub

    Public Sub mnuTrtyExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuTrtyExit.Click
        Me.Close()
    End Sub

    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUcomments.Click
        If UpdateTran Then frmTrtyComments.ShowDialog()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitTrtyReiForm()
        txtTrtyReiMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuXaddrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuXaddrec.Click
        If Not UpdateTran Then Exit Sub
        ProcessCessionRec = False
        AddCessionRec = False
        UpdateCessionRec = False

        If Ced2TranExists And Ced3TranExists Then
            MsgBox("Ced Records exist. Select Get Ced Record Option")
        End If

        CedNmbr = InputBox("Enter Excess Cession Number")

        If CedNmbr <> "2" And CedNmbr <> "3" Then Exit Sub

        TrtyXKey = Trim(txtTrtyReiMgaNmbr.Text) & Trim(txtTrtyReiTrtyNmbr.Text) & CedNmbr

        If CedNmbr = "2" Then
            If Ced2TranExists Then
                MsgBox("Cession " & CedNmbr & " Exists Already")
                Exit Sub
            End If
        End If

        If CedNmbr = "3" Then
            If Ced3TranExists Then
                MsgBox("Cession " & CedNmbr & " Exists Already")
                Exit Sub
            End If
        End If

        GetTrtyMstVar()
        txXTrtyEffDate = InputBox("Enter Cession Effdate YYYYMMDD", , txXTrtyEffDate)
        txXTrtyCession = CedNmbr
        ProcessCessionRec = True
        AddCessionRec = True

        Me.Text = "Treaty Reinsurers Adding Cession " & CedNmbr
    End Sub

    Public Sub mnuXgetrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuXgetrec.Click
        If Not UpdateTran Then Exit Sub
        ProcessCessionRec = False
        AddCessionRec = False
        UpdateCessionRec = False

        CedNmbr = txXTrtyCession
        CedNmbr = InputBox("Enter Excess Cession Number", , CedNmbr)
        txXTrtyCession = CedNmbr

        If CedNmbr <> "2" And CedNmbr <> "3" Then Exit Sub

        'Check For Valid Cession
        If CedNmbr = "2" Then
            If Not Ced2TranExists Then
                MsgBox("Ced Record do not exist. Select Add Ced Record Option")
                CedNmbr = ""
                txXTrtyCession = ""
                Exit Sub
            End If
        End If

        If CedNmbr = "3" Then
            If Not Ced3TranExists Then
                MsgBox("Ced Record do not exist. Select Add Ced Record Option")
                CedNmbr = ""
                txXTrtyCession = ""
                Exit Sub
            End If
        End If

        'Get Cession Master
        TrtyXKey = Trim(txtTrtyReiMgaNmbr.Text) & Trim(txtTrtyReiTrtyNmbr.Text) & CedNmbr

        If CedNmbr = "2" Then
            If Ced2TranExists Then GetXTrtyMstRec()
        End If

        If CedNmbr = "3" Then
            If Ced3TranExists Then GetXTrtyMstRec()
        End If

        ProcessCessionRec = True

        txXTrtyEffDate = InputBox("Enter Cession Effdate YYYYMMDD", , txXTrtyEffDate)
        txXTrtyCession = CedNmbr
        UpTrtyReiFrmVar()
        Me.Text = "Treaty Reinsurers Updating Cession " & CedNmbr
        UpdateCessionRec = True
        txtTrtyReiMgaNmbr.ReadOnly = True
        txtTrtyReiTrtyNmbr.ReadOnly = True
        txtTrtyReiNmbr1.Focus()
    End Sub

    Public Sub mnuXsaverec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuXsaverec.Click
        If Not UpdateTran And Not AddTran Then Exit Sub
    End Sub

    Private Sub txtTrtyReiMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiMgaNmbr.Enter
        Tobj = txtTrtyReiMgaNmbr
    End Sub

    Private Sub txtTrtyReiMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtTrtyReiTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtTrtyReiMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiMgaNmbr.KeyUp
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
                For X = 1 To cboTrtyReiMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboTrtyReiMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboTrtyReiMga.SelectedIndex = 0
                ByPassTxt = False
            End If
        End If

    End Sub

    Private Sub txtTrtyReiMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiMgaNmbr.Leave
        Dim X As Integer
        Tobj = txtTrtyReiMgaNmbr

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

    Private Sub txtTrtyReiNmbr1_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr1.Enter
        Dim X As Integer

        Tobj = txtTrtyReiNmbr1

        If Len(txtTrtyReiTrtyNmbr.Text) > 0 Then
            For X = 0 To cboTrtyRei.Items.Count
                If TrtyArray(X) = Trim(txtTrtyReiTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboTrtyRei.SelectedIndex = X
                    ByPassCbo = False
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboTrtyRei.SelectedIndex = 0
            ByPassCbo = False
        End If

    End Sub

    Private Sub txtTrtyReiNmbr1_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiTrtyNmbr.Focus()
            Case Keys.Down
                txtTrtyReiNmbr2.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc1.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr1.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(1)
    End Sub

    Private Sub txtTrtyReiNmbr1_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr1.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr1_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr1.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName1 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr2_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr2.Enter
        Tobj = txtTrtyReiNmbr2
    End Sub

    Private Sub txtTrtyReiNmbr2_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr1.Focus()
            Case Keys.Down
                txtTrtyReiNmbr3.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc2.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr2.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(2)
    End Sub

    Private Sub txtTrtyReiNmbr2_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr2.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr2_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr2.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName2 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr3_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr3.Enter
        Tobj = txtTrtyReiNmbr3
    End Sub

    Private Sub txtTrtyReiNmbr3_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr3.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr2.Focus()
            Case Keys.Down
                txtTrtyReiNmbr4.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc3.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr3.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(3)
    End Sub

    Private Sub txtTrtyReiNmbr3_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr3.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr3.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr3_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr3.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName3 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr4_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr4.Enter
        Tobj = txtTrtyReiNmbr4
    End Sub

    Private Sub txtTrtyReiNmbr4_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr4.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr3.Focus()
            Case Keys.Down
                txtTrtyReiNmbr5.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc4.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr4.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(4)
    End Sub

    Private Sub txtTrtyReiNmbr4_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr4.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr4.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr4_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr4.Leave
        Dim X As Integer

        M = "   "
        M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName4 : Tobj.Text = ""

        If M = "000" Then Tobj.Text = ""
        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr5_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr5.Enter
        Tobj = txtTrtyReiNmbr5
    End Sub

    Private Sub txtTrtyReiNmbr5_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr5.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr4.Focus()
            Case Keys.Down
                txtTrtyReiNmbr6.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc5.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr5.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(5)
    End Sub

    Private Sub txtTrtyReiNmbr5_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr5.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr5.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr5_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr5.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName5 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr6_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr6.Enter
        Tobj = txtTrtyReiNmbr6
    End Sub

    Private Sub txtTrtyReiNmbr6_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr6.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr5.Focus()
            Case Keys.Down
                txtTrtyReiNmbr7.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc6.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr6.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(6)
    End Sub

    Private Sub txtTrtyReiNmbr6_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr6.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr6.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr6_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr6.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName6 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr7_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr7.Enter
        Tobj = txtTrtyReiNmbr7
    End Sub

    Private Sub txtTrtyReiNmbr7_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr7.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr6.Focus()
            Case Keys.Down
                txtTrtyReiNmbr8.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr7.Text = ReiKey
        End If

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc7.Focus()

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(7)
    End Sub

    Private Sub txtTrtyReiNmbr7_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr7.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr7.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr7_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr7.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName7 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr8_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr8.Enter
        Tobj = txtTrtyReiNmbr8
    End Sub

    Private Sub txtTrtyReiNmbr8_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr8.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr7.Focus()
            Case Keys.Down
                txtTrtyReiNmbr9.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc8.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr8.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(8)
    End Sub

    Private Sub txtTrtyReiNmbr8_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr8.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr8.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr8_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr8.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName8 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr9_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr9.Enter
        Tobj = txtTrtyReiNmbr9
    End Sub

    Private Sub txtTrtyReiNmbr9_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr9.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr8.Focus()
            Case Keys.Down
                txtTrtyReiNmbr10.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc9.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr9.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(9)
    End Sub

    Private Sub txtTrtyReiNmbr9_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr9.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr9.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr9_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr9.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName9 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiNmbr10_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr10.Enter
        Tobj = txtTrtyReiNmbr10
    End Sub

    Private Sub txtTrtyReiNmbr10_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiNmbr10.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiNmbr9.Focus()
            Case Keys.Down
                txtTrtyReiNmbr1.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiPerc10.Focus()

        If KeyCode = 113 Or (Shift = 4 And KeyCode = Keys.L) Then
            frmReiRef.ShowDialog()
            If Trim(ReiKey) <> "" Then txtTrtyReiNmbr10.Text = ReiKey
        End If

        If Shift = 4 And KeyCode = Keys.D Then Call DelReiRow(10)
    End Sub

    Private Sub txtTrtyReiNmbr10_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiNmbr10.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiNmbr10.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiNmbr10_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiNmbr10.Leave
        Dim X As Integer

        M = "   " : M = RSet(Tobj.Text, Len(M))

        For X = 1 To 3
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next
        Tobj.Text = M

        ReiKey = M : RdReiMstRec()
        Tobj = txtTrtyReiName10 : Tobj.Text = ""

        If Fstat <> 0 Then Exit Sub
        Tobj.Text = f4str(Rp.ReiName)
    End Sub

    Private Sub txtTrtyReiPerc1_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc1.Enter
        Tobj = txtTrtyReiPerc1
    End Sub

    Private Sub txtTrtyReiPerc1_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiTrtyNmbr.Focus()
            Case Keys.Down
                txtTrtyReiPerc2.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr2.Focus()
    End Sub

    Private Sub txtTrtyReiPerc1_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc1.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc1_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc1.Leave
        Tobj = txtTrtyReiPerc1
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc2_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc2.Enter
        Tobj = txtTrtyReiPerc2
    End Sub

    Private Sub txtTrtyReiPerc2_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc1.Focus()
            Case Keys.Down
                txtTrtyReiPerc3.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr3.Focus()
    End Sub

    Private Sub txtTrtyReiPerc2_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc2.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc2_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc2.Leave
        Tobj = txtTrtyReiPerc2
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc3_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc3.Enter
        Tobj = txtTrtyReiPerc3
    End Sub

    Private Sub txtTrtyReiPerc3_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc3.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc2.Focus()
            Case Keys.Down
                txtTrtyReiPerc4.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr4.Focus()
    End Sub

    Private Sub txtTrtyReiPerc3_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc3.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc3.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc3_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc3.Leave
        Tobj = txtTrtyReiPerc3
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc4_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc4.Enter
        Tobj = txtTrtyReiPerc4
    End Sub

    Private Sub txtTrtyReiPerc4_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc4.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc3.Focus()
            Case Keys.Down
                txtTrtyReiPerc5.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr5.Focus()
    End Sub

    Private Sub txtTrtyReiPerc4_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc4.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc4.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc4_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc4.Leave
        Tobj = txtTrtyReiPerc4
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc5_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc5.Enter
        Tobj = txtTrtyReiPerc5
    End Sub

    Private Sub txtTrtyReiPerc5_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc5.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc4.Focus()
            Case Keys.Down
                txtTrtyReiPerc6.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr6.Focus()
    End Sub

    Private Sub txtTrtyReiPerc5_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc5.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc5.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc5_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc5.Leave
        Tobj = txtTrtyReiPerc5
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc6_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc6.Enter
        Tobj = txtTrtyReiPerc6
    End Sub

    Private Sub txtTrtyReiPerc6_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc6.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc5.Focus()
            Case Keys.Down
                txtTrtyReiPerc7.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr7.Focus()
    End Sub

    Private Sub txtTrtyReiPerc6_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc6.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc6.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc6_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc6.Leave
        Tobj = txtTrtyReiPerc6
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc7_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc7.Enter
        Tobj = txtTrtyReiPerc7
    End Sub

    Private Sub txtTrtyReiPerc7_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc7.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc6.Focus()
            Case Keys.Down
                txtTrtyReiPerc8.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr8.Focus()
    End Sub

    Private Sub txtTrtyReiPerc7_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc7.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc7.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc7_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc7.Leave
        Tobj = txtTrtyReiPerc7
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc8_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc8.Enter
        Tobj = txtTrtyReiPerc8
    End Sub

    Private Sub txtTrtyReiPerc8_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc8.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc7.Focus()
            Case Keys.Down
                txtTrtyReiPerc9.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr9.Focus()
    End Sub

    Private Sub txtTrtyReiPerc8_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc8.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc8.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc8_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc8.Leave
        Tobj = txtTrtyReiPerc8
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub

    Private Sub txtTrtyReiPerc9_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc9.Enter
        Tobj = txtTrtyReiPerc9
    End Sub

    Private Sub txtTrtyReiPerc9_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc9.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc8.Focus()
            Case Keys.Down
                txtTrtyReiPerc10.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr10.Focus()
    End Sub

    Private Sub txtTrtyReiPerc9_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc9.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc9.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc9_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc9.Leave
        Tobj = txtTrtyReiPerc9
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()
    End Sub


    Private Sub txtTrtyReiPerc10_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc10.Enter
        Tobj = txtTrtyReiPerc10
    End Sub

    Private Sub txtTrtyReiPerc10_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiPerc10.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiPerc9.Focus()
            Case Keys.Down
                txtTrtyReiPerc1.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiMgaNmbr.Focus()
    End Sub

    Private Sub txtTrtyReiPerc10_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiPerc10.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiPerc10.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiPerc10_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiPerc10.Leave
        Tobj = txtTrtyReiPerc10
        Tobj.Text = Format(Val(Tobj.Text), "###.0000")
        CalcPerc()

        If Len(Trim(txtTrtyReiMgaNmbr.Text)) = 3 And Len(Trim(txtTrtyReiTrtyNmbr.Text)) = 2 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If
    End Sub

    Private Sub txtTrtyReiTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiTrtyNmbr.Enter
        Dim X As Integer

        Tobj = txtTrtyReiTrtyNmbr

        If Len(txtTrtyReiMgaNmbr.Text) > 0 Then
            For X = 1 To cboTrtyReiMga.Items.Count
                If MgaArray(X) = Trim(txtTrtyReiMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboTrtyReiMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboTrtyReiMga.SelectedIndex = 0
        End If

    End Sub

    Private Sub txtTrtyReiTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtTrtyReiMgaNmbr.Focus()
            Case Keys.Down
                txtTrtyReiNmbr1.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtTrtyReiNmbr1.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtTrtyReiTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtTrtyReiTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtTrtyReiTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtTrtyReiTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtTrtyReiTrtyNmbr.KeyUp
        Dim X As Integer

        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

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
                TrtyKey = Trim(Tobj.Text) & M
                For X = 0 To cboTrtyRei.Items.Count
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboTrtyRei.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboTrtyRei.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If

    End Sub

    Private Sub txtTrtyReiTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtTrtyReiTrtyNmbr.Leave
        Dim X As Integer

        Tobj = txtTrtyReiTrtyNmbr

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        If S1 = "00" Then
            Tobj.Text = ""
        End If

        If Len(Trim(txtTrtyReiMgaNmbr.Text)) = 3 And Len(Trim(Tobj.Text)) = 2 Then
            TrtyKey = Trim(txtTrtyReiMgaNmbr.Text) & Trim(txtTrtyReiTrtyNmbr.Text)
            GetTrtyMstRec()
            If UpdateTran Then
                UpTrtyReiFrmVar()
                txtTrtyReiMgaNmbr.ReadOnly = True
                txtTrtyReiTrtyNmbr.ReadOnly = True
                CheckForExcessCessions()
                txtTrtyReiNmbr1.Focus()
            End If
            If Not UpdateTran Then
                MsgBox("Setup treaty before continuing Opton 104. Unable to continue")
                InitTrtyReiForm()
                txtTrtyReiMgaNmbr.Focus()
            End If
        End If
    End Sub

    Private Sub ProcessTrtyReiRec()
        Dim response As Short

        UpTrtyMstVars1()
        If TotPerc <> 100 Then
            response = MsgBox("Ceding Totals Out of Balance. Do you want to override?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Out Of Bal Error")
            If response = MsgBoxResult.No Then
                txtTrtyReiMgaNmbr.Focus()
                Exit Sub
            End If
        End If

        If UpdateTran Then UpTrtyMstRec()

        InitTrtyReiForm()
        txtTrtyReiMgaNmbr.Focus()
    End Sub

    Private Sub ProcessXTrtyReiRec()
        Dim response As Short

        UpTrtyMstVars1()
        If TotPerc <> 100 Then
            response = MsgBox("Ceding Totals Out of Balance. Do you want to override?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Out Of Bal Error")
            If response = MsgBoxResult.No Then
                txtTrtyReiMgaNmbr.Focus()
                Exit Sub
            End If
        End If

        If AddCessionRec Then AddXTrtyMstRec()
        If UpdateCessionRec Then UpXTrtyMstRec()

        InitTrtyReiForm()
        txtTrtyReiMgaNmbr.Focus()
    End Sub

    Private Sub InitTrtyReiForm()

        ByPassCbo = True
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        ProcessCessionRec = False
        AddCessionRec = False
        UpdateCessionRec = False
        txtTrtyReiMgaNmbr.ReadOnly = False
        txtTrtyReiTrtyNmbr.ReadOnly = False
        cmdRecAction.Visible = False

        Utrtymst = False
        Utrtyrei = True

        CedNmbr = ""
        txXTrtyCession = ""
        txXTrtyEffDate = ""

        txTrtyReiMgaNmbr = ""
        txTrtyReiTrtyNmbr = ""
        txTrtyReiCedPerc = ""
        txTrtyReiNmbr1 = ""
        txTrtyReiNmbr2 = ""
        txTrtyReiNmbr3 = ""
        txTrtyReiNmbr4 = ""
        txTrtyReiNmbr5 = ""
        txTrtyReiNmbr6 = ""
        txTrtyReiNmbr7 = ""
        txTrtyReiNmbr8 = ""
        txTrtyReiNmbr9 = ""
        txTrtyReiNmbr10 = ""

        txTrtyReiName1 = ""
        txTrtyReiName2 = ""
        txTrtyReiName3 = ""
        txTrtyReiName4 = ""
        txTrtyReiName5 = ""
        txTrtyReiName6 = ""
        txTrtyReiName7 = ""
        txTrtyReiName8 = ""
        txTrtyReiName9 = ""
        txTrtyReiName10 = ""

        txTrtyReiPerc1 = ""
        txTrtyReiPerc2 = ""
        txTrtyReiPerc3 = ""
        txTrtyReiPerc4 = ""
        txTrtyReiPerc5 = ""
        txTrtyReiPerc6 = ""
        txTrtyReiPerc7 = ""
        txTrtyReiPerc8 = ""
        txTrtyReiPerc9 = ""
        txTrtyReiPerc10 = ""

        txtTrtyReiPercTot.Text = ""

        txtTrtyReiMgaNmbr.Text = ""
        txtTrtyReiTrtyNmbr.Text = ""
        txtTrtyReiCedPerc.Text = ""
        txtTrtyReiNmbr1.Text = ""
        txtTrtyReiNmbr2.Text = ""
        txtTrtyReiNmbr3.Text = ""
        txtTrtyReiNmbr4.Text = ""
        txtTrtyReiNmbr5.Text = ""
        txtTrtyReiNmbr6.Text = ""
        txtTrtyReiNmbr7.Text = ""
        txtTrtyReiNmbr8.Text = ""
        txtTrtyReiNmbr9.Text = ""
        txtTrtyReiNmbr10.Text = ""

        txtTrtyReiName1.Text = ""
        txtTrtyReiName2.Text = ""
        txtTrtyReiName3.Text = ""
        txtTrtyReiName4.Text = ""
        txtTrtyReiName5.Text = ""
        txtTrtyReiName6.Text = ""
        txtTrtyReiName7.Text = ""
        txtTrtyReiName8.Text = ""
        txtTrtyReiName9.Text = ""
        txtTrtyReiName10.Text = ""

        txtTrtyReiPerc1.Text = ""
        txtTrtyReiPerc2.Text = ""
        txtTrtyReiPerc3.Text = ""
        txtTrtyReiPerc4.Text = ""
        txtTrtyReiPerc5.Text = ""
        txtTrtyReiPerc6.Text = ""
        txtTrtyReiPerc7.Text = ""
        txtTrtyReiPerc8.Text = ""
        txtTrtyReiPerc9.Text = ""
        txtTrtyReiPerc10.Text = ""

        'Load Mga Combo Box
        LoadCboTrtyMga()

        'Load Trty Combo Box
        TrtyKey = "001" & "06"
        LoadCboTrty()


        cboTrtyReiMga.SelectedIndex = 1
        cboTrtyRei.SelectedIndex = 1

        s = "   "
        S1 = "  "
        ByPassCbo = False

        Me.Text = "Treaty Reinsurers"
    End Sub

    Private Sub CalcPerc()
        TotPerc = 0
        TotPerc = Val(txtTrtyReiPerc1.Text) + Val(txtTrtyReiPerc2.Text) + Val(txtTrtyReiPerc3.Text) + Val(txtTrtyReiPerc4.Text) + Val(txtTrtyReiPerc5.Text) + Val(txtTrtyReiPerc6.Text) + Val(txtTrtyReiPerc7.Text) + Val(txtTrtyReiPerc8.Text) + Val(txtTrtyReiPerc9.Text) + Val(txtTrtyReiPerc10.Text)

        txtTrtyReiPercTot.Text = Format(TotPerc, "###.0000")
        If TotPerc = 0 Then txtTrtyReiPercTot.Text = ""

    End Sub

    Private Sub LoadCboTrtyMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboTrtyReiMga.Items.Clear()
        cboTrtyReiMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboTrtyReiMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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
        ReDim TrtyArray(d4recCount(f3) + 1)
        rc = d4top(f3)

        Call d4tagSelect(f3, d4tag(f3, "K1"))
        rc = d4seek(f3, TrtyKey)

        cboTrtyRei.Items.Clear()
        cboTrtyRei.Items.Add("Treaty Not Setup")
        For X1 = 0 To d4recCount(f3)
            If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TMp.TrtyMgaNmbr)), 1, 3) Then
                Exit For
            End If
            X = X + 1
            TrtyArray(X) = Trim(f4str(TMp.TrtyNmbr))
            cboTrtyRei.Items.Add(Trim(f4str(TMp.TrtyNmbr)) & "   " & Trim(f4str(TMp.TrtyDesc)))
            rc = d4skip(f3, 1)
        Next X1

        rc = d4bottom(f3)
        rc = d4unlock(f3)
    End Sub

    Private Sub DelReiRow(ByRef p As Short)
        Dim X As Integer

        ReDim Oarry1(10)
        ReDim Oarry2(10)
        ReDim Oarry3(10)

        Oarry1(1) = txtTrtyReiNmbr1
        Oarry1(2) = txtTrtyReiNmbr2
        Oarry1(3) = txtTrtyReiNmbr3
        Oarry1(4) = txtTrtyReiNmbr4
        Oarry1(5) = txtTrtyReiNmbr5
        Oarry1(6) = txtTrtyReiNmbr6
        Oarry1(7) = txtTrtyReiNmbr7
        Oarry1(8) = txtTrtyReiNmbr8
        Oarry1(9) = txtTrtyReiNmbr9
        Oarry1(10) = txtTrtyReiNmbr10

        Oarry2(1) = txtTrtyReiName1
        Oarry2(2) = txtTrtyReiName2
        Oarry2(3) = txtTrtyReiName3
        Oarry2(4) = txtTrtyReiName4
        Oarry2(5) = txtTrtyReiName5
        Oarry2(6) = txtTrtyReiName6
        Oarry2(7) = txtTrtyReiName7
        Oarry2(8) = txtTrtyReiName8
        Oarry2(9) = txtTrtyReiName9
        Oarry2(10) = txtTrtyReiName10

        Oarry3(1) = txtTrtyReiPerc1
        Oarry3(2) = txtTrtyReiPerc2
        Oarry3(3) = txtTrtyReiPerc3
        Oarry3(4) = txtTrtyReiPerc4
        Oarry3(5) = txtTrtyReiPerc5
        Oarry3(6) = txtTrtyReiPerc6
        Oarry3(7) = txtTrtyReiPerc7
        Oarry3(8) = txtTrtyReiPerc8
        Oarry3(9) = txtTrtyReiPerc9
        Oarry3(10) = txtTrtyReiPerc10

        For X = p To 10
            If X <> 10 Then
                Oarry1(X).Text = Oarry1(X + 1).Text
                Oarry2(X).Text = Oarry2(X + 1).Text
                Oarry3(X).Text = Oarry3(X + 1).Text
            End If
        Next X

        Oarry1(10).Text = ""
        Oarry2(10).Text = ""
        Oarry3(10).Text = ""

        ReDim Oarry1(1)
        ReDim Oarry2(1)
        ReDim Oarry3(1)

        CalcPerc()
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitTrtyReiForm()
            txtTrtyReiMgaNmbr.Focus()
        End If
    End Sub

    Sub UpTrtyReiFrmVar()
        txtTrtyReiMgaNmbr.Text = txTrtyReiMgaNmbr
        txtTrtyReiTrtyNmbr.Text = txTrtyReiTrtyNmbr
        txtTrtyReiCedPerc.Text = txTrtyReiCedPerc
        txtTrtyReiNmbr1.Text = txTrtyReiNmbr1
        txtTrtyReiNmbr2.Text = txTrtyReiNmbr2
        txtTrtyReiNmbr3.Text = txTrtyReiNmbr3
        txtTrtyReiNmbr4.Text = txTrtyReiNmbr4
        txtTrtyReiNmbr5.Text = txTrtyReiNmbr5
        txtTrtyReiNmbr6.Text = txTrtyReiNmbr6
        txtTrtyReiNmbr7.Text = txTrtyReiNmbr7
        txtTrtyReiNmbr8.Text = txTrtyReiNmbr8
        txtTrtyReiNmbr9.Text = txTrtyReiNmbr9
        txtTrtyReiNmbr10.Text = txTrtyReiNmbr10

        txtTrtyReiName1.Text = txTrtyReiName1
        txtTrtyReiName2.Text = txTrtyReiName2
        txtTrtyReiName3.Text = txTrtyReiName3
        txtTrtyReiName4.Text = txTrtyReiName4
        txtTrtyReiName5.Text = txTrtyReiName5
        txtTrtyReiName6.Text = txTrtyReiName6
        txtTrtyReiName7.Text = txTrtyReiName7
        txtTrtyReiName8.Text = txTrtyReiName8
        txtTrtyReiName9.Text = txTrtyReiName9
        txtTrtyReiName10.Text = txTrtyReiName10

        If Val(txTrtyReiPerc1) = 0 Then txTrtyReiPerc1 = ""
        If Val(txTrtyReiPerc2) = 0 Then txTrtyReiPerc2 = ""
        If Val(txTrtyReiPerc3) = 0 Then txTrtyReiPerc3 = ""
        If Val(txTrtyReiPerc4) = 0 Then txTrtyReiPerc4 = ""
        If Val(txTrtyReiPerc5) = 0 Then txTrtyReiPerc5 = ""
        If Val(txTrtyReiPerc6) = 0 Then txTrtyReiPerc6 = ""
        If Val(txTrtyReiPerc7) = 0 Then txTrtyReiPerc7 = ""
        If Val(txTrtyReiPerc8) = 0 Then txTrtyReiPerc8 = ""
        If Val(txTrtyReiPerc9) = 0 Then txTrtyReiPerc9 = ""
        If Val(txTrtyReiPerc10) = 0 Then txTrtyReiPerc10 = ""

        txtTrtyReiPerc1.Text = txTrtyReiPerc1
        txtTrtyReiPerc2.Text = txTrtyReiPerc2
        txtTrtyReiPerc3.Text = txTrtyReiPerc3
        txtTrtyReiPerc4.Text = txTrtyReiPerc4
        txtTrtyReiPerc5.Text = txTrtyReiPerc5
        txtTrtyReiPerc6.Text = txTrtyReiPerc6
        txtTrtyReiPerc7.Text = txTrtyReiPerc7
        txtTrtyReiPerc8.Text = txTrtyReiPerc8
        txtTrtyReiPerc9.Text = txTrtyReiPerc9
        txtTrtyReiPerc10.Text = txTrtyReiPerc10

        txtTrtyReiPercTot.Text = txTrtyReiPercTot
    End Sub

    Public Sub UpTrtyMstVars1()
        txTrtyReiNmbr1 = txtTrtyReiNmbr1.Text
        txTrtyReiNmbr2 = txtTrtyReiNmbr2.Text
        txTrtyReiNmbr3 = txtTrtyReiNmbr3.Text
        txTrtyReiNmbr4 = txtTrtyReiNmbr4.Text
        txTrtyReiNmbr5 = txtTrtyReiNmbr5.Text
        txTrtyReiNmbr6 = txtTrtyReiNmbr6.Text
        txTrtyReiNmbr7 = txtTrtyReiNmbr7.Text
        txTrtyReiNmbr8 = txtTrtyReiNmbr8.Text
        txTrtyReiNmbr9 = txtTrtyReiNmbr9.Text
        txTrtyReiNmbr10 = txtTrtyReiNmbr10.Text

        txTrtyReiPerc1 = txtTrtyReiPerc1.Text
        txTrtyReiPerc2 = txtTrtyReiPerc2.Text
        txTrtyReiPerc3 = txtTrtyReiPerc3.Text
        txTrtyReiPerc4 = txtTrtyReiPerc4.Text
        txTrtyReiPerc5 = txtTrtyReiPerc5.Text
        txTrtyReiPerc6 = txtTrtyReiPerc6.Text
        txTrtyReiPerc7 = txtTrtyReiPerc7.Text
        txTrtyReiPerc8 = txtTrtyReiPerc8.Text
        txTrtyReiPerc9 = txtTrtyReiPerc9.Text
        txTrtyReiPerc10 = txtTrtyReiPerc10.Text
    End Sub

    Sub CheckForExcessCessions()
        Ced2TranExists = False
        Ced3TranExists = False

        'Check For Cession 2
        TrtyXKey = Trim(txtTrtyReiMgaNmbr.Text) & Trim(txtTrtyReiTrtyNmbr.Text) & "2"
        Call d4tagSelect(f3X, d4tag(f3X, "K1"))
        rc = d4seek(f3X, TrtyXKey)
        If rc = 0 Then Ced2TranExists = True

        'Check For Cession 3
        TrtyXKey = Trim(txtTrtyReiMgaNmbr.Text) & Trim(txtTrtyReiTrtyNmbr.Text) & "3"
        Call d4tagSelect(f3X, d4tag(f3X, "K1"))
        rc = d4seek(f3X, TrtyXKey)
        If rc = 0 Then Ced3TranExists = True

        If Ced2TranExists Or Ced3TranExists Then
            Me.Text = "Treaty Reinsurers Includes Excess Cessions"
            MsgBox("Treaty Includes Excess Cessions")
        End If

    End Sub
End Class