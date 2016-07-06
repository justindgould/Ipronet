Option Strict Off
Option Explicit On

Friend Class frmRptEntry
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
	
    Private Sub cboRptMga_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboRptMga.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub
	
    Private Sub cboRptTrty_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboRptTrty.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub
	
    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        ProcessRptTrans()
        cmdRecAction.Visible = False
    End Sub
	
    Private Sub cmdRecAction_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdRecAction.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtRptTotal.Focus()
            Case Keys.Down
                txtRptTotal.Focus()
        End Select

        ResetForm((KeyCode))
    End Sub
	
    Private Sub cmdRecAction_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Leave
        cmdRecAction.Visible = False
    End Sub
	
    Private Sub frmRptEntry_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        OpenCatMst()
        OpenPeriod()
        OpenRptDir()
        AddTran = False
        UpdateTran = False
        InitRptEntryForm()
    End Sub
	
    Private Sub frmRptEntry_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub
	
    Private Sub LoadCboMga()
        X = 0
        rc = d4top(f1)
        ReDim MgaArray(d4recCount(f1) + 1)

        Call d4tagSelect(f1, d4tag(f1, "K1"))

        cboRptMga.Items.Clear()
        cboRptMga.Items.Add("MGA Not Setup")
        Do Until rc = r4eof
            cboRptMga.Items.Add(Trim(f4str(Mp.MgaNmbr)) & "   " & Trim(f4str(Mp.MgaName)))
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
		
		cboRptTrty.Items.Clear()
		cboRptTrty.Items.Add("Treaty Inactive or Not Setup")
		For X1 = 0 To d4recCount(f4)
			If Mid(TrtyKey, 1, 3) <> Mid(Trim(f4str(TPp.PrmMgaNmbr)), 1, 3) Then
				Exit For
			End If
			If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec
			X = X + 1
			TrtyArray(X) = Trim(f4str(TPp.PrmTrtyNmbr))
			cboRptTrty.Items.Add(Trim(f4str(TPp.PrmTrtyNmbr)) & "   " & Trim(f4str(TPp.PrmDesc)))
nextrec: 
			rc = d4skip(f4, 1)
		Next X1
		
		rc = d4bottom(f4)
		rc = d4unlock(f4)
	End Sub
	
	Private Sub LoadCboCat()
		X = 0
		ReDim CatArray(d4recCount(f91) + 1)
		
		cboRptCatDesc.Items.Clear()
		cboRptCatDesc.Items.Add("Cat Code Not Setup")
		
		Call d4tagSelect(f91, d4tag(f91, "K1"))
		rc = d4seek(f91, "00")
		
		Do Until rc = r4eof
			cboRptCatDesc.Items.Add(Trim(f4str(CMp.CatCode)) & "   " & Trim(f4str(CMp.CatDesc)))
			X = X + 1
			CatArray(X) = Trim(f4str(CMp.CatCode))
			rc = d4skip(f91, 1)
		Loop 
		rc = d4bottom(f91)
		rc = d4unlock(f91)
	End Sub
	
    Private Sub cboRptTrty_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRptTrty.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtRptTrtyNmbr.Text = Mid(Trim(cboRptTrty.Text), 1, 2)
        TrtyKey = Mid(Trim(cboRptMga.Text), 1, 3) & Mid(Trim(cboRptTrty.Text), 1, 2)
        RdTrtyPrmRec()
        RdTrtyMstRec()
        LdCovArry()
        txtRptTrtyNmbr.Focus()
    End Sub
	
    Private Sub cboRptMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRptMga.SelectedIndexChanged
        Dim M As Object
        Dim M1 As Short

        If ByPassCbo Then Exit Sub
        TrtyKey = Mid(Trim(cboRptMga.Text), 1, 3)
        LoadCboTrty()

        ByPassCbo = True
        If cboRptTrty.Items.Count > 1 Then
            cboRptTrty.SelectedIndex = 1
        Else
            cboRptTrty.SelectedIndex = 0
        End If
        ByPassCbo = False

        If Not AddTran And Not UpdateTran Then
            If Not ByPassTxt Then
                txtRptMgaNmbr.Text = Mid(Trim(cboRptMga.Text), 1, 3)
                MgaOk = True
            End If
            txtRptTrtyNmbr.Text = ""
        End If

        If AddTran Or UpdateTran Then
            M = Mid(Trim(cboRptMga.Text), 1, 3)
            M1 = cboRptMga.SelectedIndex
            InitRptEntryForm()
            txtRptMgaNmbr.Text = M
            cboRptMga.SelectedIndex = M1
            txtRptMgaNmbr.Focus()
        End If
    End Sub
	
    Private Sub cboRptCatDesc_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRptCatDesc.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        txtRptCatCode.Text = Mid(cboRptCatDesc.Text, 1, 2)
        txtRptCatCode.Focus()
    End Sub
	
    Private Sub cboRptCatDesc_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboRptCatDesc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub
	
    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
	
    Public Sub mnuOcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOcomments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtRptMgaNmbr.Text
            Ctrty = txtRptTrtyNmbr.Text
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
        DelRptDirRec()
        AddTran = False
        UpdateTran = False
        InitRptEntryForm()
        txtRptMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        AddTran = False
        UpdateTran = False
        InitRptEntryForm()
        txtRptMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        If Not ValRec() Then Exit Sub
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub
	
    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUcomments.Click
        If AddTran Or UpdateTran Then
            Cmga = txtRptMgaNmbr.Text
            Ctrty = txtRptTrtyNmbr.Text
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
        DelRptDirRec()
        AddTran = False
        UpdateTran = False
        InitRptEntryForm()
        txtRptMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        AddTran = False
        UpdateTran = False
        InitRptEntryForm()
        txtRptMgaNmbr.Focus()
    End Sub
	
    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        If Not ValRec() Then Exit Sub
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub
	
    Private Sub txtRptMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptMgaNmbr.Enter
        Tobj = txtRptMgaNmbr
    End Sub
	
    Private Sub txtRptMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtRptTrtyNmbr.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtRptTrtyNmbr.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtRptMgaNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtRptMgaNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtRptMgaNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtRptMgaNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptMgaNmbr.KeyUp
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
                For X = 1 To cboRptMga.Items.Count
                    If MgaArray(X) = M Then
                        ByPassTxt = True
                        cboRptMga.SelectedIndex = X
                        ByPassTxt = False
                        Exit Sub
                    End If
                Next X
                ByPassTxt = True
                cboRptMga.SelectedIndex = 0
                ByPassTxt = True
            End If
        End If
    End Sub
	
    Private Sub txtRptMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptMgaNmbr.Leave
        Dim X As Integer
        Tobj = txtRptMgaNmbr
        MgaOk = False

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        If Tobj.Text <> "" Then
            For X = 1 To 3
                If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
            Next
        End If

        Tobj.Text = s

        MgaKey = s
        RdMgaMstRec()
        If Fstat <> 0 Then
            If Tobj.Text <> "" And Tobj.Text <> "000" And Tobj.Text <> "   " Then
                MsgBox("MGA Master Record Does Not Exist.")
                txtRptMgaNmbr.Focus()
                Exit Sub
            End If
        End If

        If Tobj.Text = "000" Then Exit Sub
        MgaOk = True
    End Sub
	
    Private Sub txtRptTranTotal_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptTranTotal.Enter
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
	
    Private Sub txtRptTrtyNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptTrtyNmbr.Enter
        Dim X As Integer

        If Not MgaOk Then Exit Sub

        Tobj = txtRptTrtyNmbr

        If Len(txtRptMgaNmbr.Text) > 0 Then
            For X = 1 To cboRptMga.Items.Count
                If MgaArray(X) = Trim(txtRptMgaNmbr.Text) Then
                    ByPassTxt = True
                    cboRptMga.SelectedIndex = X
                    ByPassTxt = False
                    Exit Sub
                End If
            Next X
            cboRptMga.SelectedIndex = 0
        End If

    End Sub
	
    Private Sub txtRptTrtyNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptTrtyNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtRptMgaNmbr.Focus()
            Case Keys.Down
                txtRptPeriod.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtRptPeriod.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtRptTrtyNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtRptTrtyNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtRptTrtyNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtRptTrtyNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptTrtyNmbr.KeyUp
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
                For X = 0 To cboRptTrty.Items.Count
                    If Len(Tobj.Text) > 2 Then Exit For
                    If TrtyArray(X) = M Then
                        ByPassCbo = True
                        cboRptTrty.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboRptTrty.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub
	
    Private Sub txtRptTrtyNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptTrtyNmbr.Leave
        Dim X As Integer
        Tobj = txtRptTrtyNmbr
        TrtyOk = False

        S1 = "  "
        S1 = RSet(Tobj.Text, Len(S1))
        For X = 1 To 2
            If Mid(S1, X, 1) = " " Then Mid(S1, X, 1) = "0"
        Next

        Tobj.Text = UCase(S1)

        TrtyKey = Trim(txtRptMgaNmbr.Text) & Trim(txtRptTrtyNmbr.Text)
        RdTrtyMstRec()
        If Fstat <> 0 Then
            If Tobj.Text <> "" And Tobj.Text <> "00" Then
                MsgBox("Treaty Record Does Not Exist.")
                Exit Sub
            End If
        End If

        If Tobj.Text = "00" Then
            txtRptMgaNmbr.Focus()
            Tobj.Text = ""
            Exit Sub
        End If

        LdCovArry()
        TrtyOk = True
    End Sub
	
    Private Sub txtRptPeriod_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptPeriod.Enter
        Dim X As Integer
        ByPassTxt = False
        Tobj = txtRptPeriod

        If Len(txtRptMgaNmbr.Text) > 0 Then
            For X = 0 To cboRptTrty.Items.Count
                If TrtyArray(X) = Trim(txtRptTrtyNmbr.Text) Then
                    ByPassCbo = True
                    cboRptTrty.SelectedIndex = X
                    ByPassCbo = False
                    If Trim(txtRptPeriod.Text) = "" Then txtRptPeriod.Text = CurrPeriod
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboRptTrty.SelectedIndex = 0
            ByPassCbo = False
        End If

        If cboRptTrty.SelectedIndex = 0 Then
            MsgBox("Invalid Treaty")
            txtRptTrtyNmbr.Focus()
        End If

    End Sub
	
    Private Sub txtRptPeriod_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptPeriod.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtRptTrtyNmbr.Focus()
            Case Keys.Down
                txtRptCatCode.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtRptCatCode.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtRptPeriod_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtRptPeriod.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtRptPeriod.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtRptPeriod_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptPeriod.Leave
        Dim X As Integer
        Tobj = txtRptPeriod

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
	
    Private Sub txtRptCatCode_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptCatCode.Enter
        Tobj = txtRptCatCode
    End Sub
	
    Private Sub txtRptCatCode_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptCatCode.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtRptPeriod.Focus()
            Case Keys.Down
                txtRptYear.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtRptYear.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtRptCatCode_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtRptCatCode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtRptCatCode.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtRptCatCode_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptCatCode.KeyUp
        Dim X As Integer
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim M As String

        M = "  "
        M = RSet(txtRptCatCode.Text, Len(M))
        For X = 1 To 2
            If Mid(M, X, 1) = " " Then Mid(M, X, 1) = "0"
        Next

        If (KeyCode > 47 And KeyCode < 58) Or (KeyCode > 96 And KeyCode < 105) Then
            If Len(M) > 0 Then
                For X = 0 To cboRptCatDesc.Items.Count
                    If CatArray(X) = M Then
                        ByPassCbo = True
                        cboRptCatDesc.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboRptCatDesc.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub
	
    Private Sub txtRptCatCode_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptCatCode.Leave
        Dim X As Integer

        Tobj = txtRptCatCode

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
                cboRptCatDesc.SelectedIndex = 0
                ByPassCbo = False
                txtRptCatCode.Focus()
                Exit Sub
            End If
        End If
        CatOk = True
    End Sub
	
    Private Sub txtRptYear_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptYear.Enter
        Dim X As Integer
        If Len(txtRptCatCode.Text) > 0 Then
            For X = 0 To cboRptCatDesc.Items.Count
                If CatArray(X) = txtRptCatCode.Text Then
                    ByPassCbo = True
                    cboRptCatDesc.SelectedIndex = X
                    ByPassCbo = False
                    Exit For
                End If
                ByPassCbo = True
                cboRptCatDesc.SelectedIndex = 0
                ByPassCbo = False
            Next X
        End If
        Tobj = txtRptYear
        If txtRptCatCode.Text = "01" Or txtRptCatCode.Text = "02" Or txtRptCatCode.Text = "03" Or txtRptCatCode.Text = "04" Or txtRptCatCode.Text = "05" Or txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Or txtRptCatCode.Text = "15" Or txtRptCatCode.Text = "16" Or txtRptCatCode.Text = "17" Then
            If Trim(txtRptYear.Text) = "" Then txtRptYear.Text = Trim(Str(Parry(1)))
        End If
    End Sub
	
    Private Sub txtRptYear_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptYear.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtRptCatCode.Focus()
            Case Keys.Down
                txtRptTotal.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtRptTotal.Focus()

        ResetForm((KeyCode))
    End Sub
	
    Private Sub txtRptYear_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtRptYear.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtRptYear.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtRptYear_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptYear.Leave
        Dim M2, M, M1, M3 As Object
        Dim M4 As String
        Dim W, W1 As Object
        Dim W2 As Short
        Dim X As Integer

        YearOk = False
        Tobj = txtRptYear

        If Len(Trim(txtRptMgaNmbr.Text)) = 3 And Len(Trim(txtRptTrtyNmbr.Text)) = 2 And Len(Trim(txtRptPeriod.Text)) = 2 And Len(Trim(txtRptCatCode.Text)) = 2 And Len(Trim(txtRptYear.Text)) = 4 Then

            PremRec = False
            'Check for Prem Rec before processing Comm,Tax,FF
            If txtRptCatCode.Text = "03" Or txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Then
                RptDirKey = Trim(txtRptMgaNmbr.Text) & Trim(txtRptTrtyNmbr.Text) & Trim(txtRptPeriod.Text) & "01" & Trim(txtRptYear.Text)
                Call d4tagSelect(f5, d4tag(f5, "K1"))
                rc = d4seek(f5, RptDirKey)

                If rc = 0 Then
                    PremRec = True
                    Tot = f4double(RDp.RptTotal)
                    Wlobt = f4double(RDp.RptTotal)
                    WLobp(1) = f4double(RDp.RptPPbi)
                    WLobp(2) = f4double(RDp.RptPPpd)
                    WLobp(3) = f4double(RDp.RptPPmed)
                    WLobp(4) = f4double(RDp.RptPPumbi)
                    WLobp(5) = f4double(RDp.RptPPumpd)
                    WLobp(6) = f4double(RDp.RptPPpip)
                    WLobp(7) = f4double(RDp.RptPPcomp)
                    WLobp(8) = f4double(RDp.RptPPcoll)
                    WLobp(9) = f4double(RDp.RptPPrent)
                    WLobp(10) = f4double(RDp.RptPPtow)
                    WLobp(11) = f4double(RDp.RptCMbi)
                    WLobp(12) = f4double(RDp.RptCMpd)
                    WLobp(13) = f4double(RDp.RptCMmed)
                    WLobp(14) = f4double(RDp.RptCMumbi)
                    WLobp(15) = f4double(RDp.RptCMumpd)
                    WLobp(16) = f4double(RDp.RptCMpip)
                    WLobp(17) = f4double(RDp.RptCMcomp)
                    WLobp(18) = f4double(RDp.RptCMcoll)
                    WLobp(19) = f4double(RDp.RptCMrent)
                    WLobp(20) = f4double(RDp.RptCMtow)
                    WLobp(21) = f4double(RDp.RptOTim)
                    WLobp(22) = f4double(RDp.RptOTallied)
                    WLobp(23) = f4double(RDp.RptOTfire)
                    WLobp(24) = f4double(RDp.RptOTmulti)
                End If
            End If

            'Check for valid year other than losses
            If txtRptCatCode.Text = "01" Or txtRptCatCode.Text = "02" Or txtRptCatCode.Text = "03" Or txtRptCatCode.Text = "04" Or txtRptCatCode.Text = "05" Or txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Or txtRptCatCode.Text = "15" Or txtRptCatCode.Text = "16" Or txtRptCatCode.Text = "17" Then
                If Parry(1) <> Val(txtRptYear.Text) Then
                    MsgBox("Invalid Year")
                    txtRptYear.Focus()
                    Exit Sub
                End If
            End If

            'Check for valid year losses
            If txtRptCatCode.Text = "06" Or txtRptCatCode.Text = "07" Or txtRptCatCode.Text = "08" Or txtRptCatCode.Text = "09" Or txtRptCatCode.Text = "10" Or txtRptCatCode.Text = "13" Or txtRptCatCode.Text = "14" Then
                If Val(txtRptYear.Text) < 1990 Or Val(txtRptYear.Text) > Parry(1) Then
                    MsgBox("Invalid Year")
                    txtRptYear.Focus()
                    Exit Sub
                End If
            End If

            'Continue
            RptDirKey = Trim(txtRptMgaNmbr.Text) & Trim(txtRptTrtyNmbr.Text) & Trim(txtRptPeriod.Text) & Trim(txtRptCatCode.Text) & Trim(txtRptYear.Text)
            GetRptDirRec()

            If Fstat = r4locked Then
                AddTran = False
                UpdateTran = False
                InitRptEntryForm()
                txtRptMgaNmbr.Focus()
                Exit Sub
            End If

            If UpdateTran Then
                UpRptDirFrmVar()
                txtRptMgaNmbr.ReadOnly = True
                txtRptTrtyNmbr.ReadOnly = True
                txtRptPeriod.ReadOnly = True
                txtRptCatCode.ReadOnly = True
                txtRptYear.ReadOnly = True
                txtRptTotal.Text = Trim(Str(MLobt))
                TotalTran()
                txtRptTotal.Focus()
                YearOk = True
                Exit Sub
            End If

            If AddTran Then
                MLobt = 0
                For X = 1 To 24
                    MLobp(X) = 0
                Next X
                M = txtRptMgaNmbr.Text
                M1 = txtRptTrtyNmbr.Text
                M2 = txtRptPeriod.Text
                M3 = txtRptCatCode.Text
                M4 = txtRptYear.Text
                W = cboRptMga.SelectedIndex
                W1 = cboRptTrty.SelectedIndex
                W2 = cboRptCatDesc.SelectedIndex
                AddTran = True
                txtRptMgaNmbr.Text = M
                txtRptTrtyNmbr.Text = M1
                txtRptPeriod.Text = M2
                txtRptCatCode.Text = M3
                txtRptYear.Text = M4
                ByPassCbo = True
                cboRptMga.SelectedIndex = W
                cboRptTrty.SelectedIndex = W1
                cboRptCatDesc.SelectedIndex = W2
                ByPassCbo = False
            End If
        End If

        If Len(Trim(txtRptYear.Text)) <> 4 Then Exit Sub

        'Compute Commisison Total
        If txtRptCatCode.Text = "03" Then
            Tot1 = CInt((Tot * f4double(TMp.DirCommPerc)) * 100) / 100
            lblRecAction.Visible = True
            lblRecAction.Text = Format(Tot1, "###,###,###.00") & " - Computed Commission"
            MLobt = 0
        End If

        'Compute Front Fee and Tax
        If txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Then
            RptDirKey = Trim(txtRptMgaNmbr.Text) & Trim(txtRptTrtyNmbr.Text) & Trim(txtRptPeriod.Text) & "02" & Trim(txtRptYear.Text)
            Call d4tagSelect(f5, d4tag(f5, "K1"))
            rc = d4seek(f5, RptDirKey)
            If rc = 0 Then Tot = Tot + f4double(RDp.RptTotal) ' Add Policy Fee
            If txtRptCatCode.Text = "11" Then
                Tot1 = CInt((Tot * f4double(TMp.TrtyFFperc)) * 100) / 100
                lblRecAction.Visible = True
                lblRecAction.Text = Format(Tot1, "###,###,###.00") & " - Computed Front Fee"
            End If
            If txtRptCatCode.Text = "12" Then
                Tot1 = CInt((Tot * f4double(TMp.TrtyPremTaxPerc)) * 100) / 100
                lblRecAction.Visible = True
                lblRecAction.Text = Format(Tot1, "###,###,###.00") & " - Computed Premium Tax"
            End If
            MLobt = 0
        End If

        YearOk = True
    End Sub
	
    Private Sub txtRptTotal_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptTotal.Enter
        If Fstat = r4locked Then Exit Sub
        If Not ValRec() Then Exit Sub
        txtRptTotal.TextAlign = HorizontalAlignment.Left
        txtRptTotal.Text = Trim(Str(MLobt))
        Tobj = txtRptTotal
    End Sub
	
    Private Sub txtRptTotal_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtRptTotal.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtRptYear.Focus()
            Case Keys.Down
                If ValPP Then txtPPbi.Focus()
                If ValCM Then txtCMbi.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then
            If txtRptCatCode.Text = "02" Or txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Or txtRptCatCode.Text = "15" Or txtRptCatCode.Text = "16" Or txtRptCatCode.Text = "17" Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            Else
                If ValPP Then txtPPbi.Focus()
                If ValCM Then txtCMbi.Focus()
            End If
        End If
    End Sub
	
    Private Sub txtRptTotal_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtRptTotal.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtRptTotal.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtRptTotal_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRptTotal.Leave
        Tobj = txtRptTotal

        If Not ValRec() Then Exit Sub

        txtRptTotal.TextAlign = HorizontalAlignment.Right
        MLobt = Val(Trim(txtRptTotal.Text))
        txtRptTotal.Text = Format(MLobt, "###,###,###.00")

        If txtRptCatCode.Text = "03" Then
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
                txtRptTotal.Focus()
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

        If CovArry(1) = 0 Or IvalCat() Then Exit Sub

        txtPPbi.TextAlign = HorizontalAlignment.Right
        MLobp(1) = Val(txtPPbi.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(1) = False And Tot <> 0 Then
            If MLobp(1) = 0 Then MLobp(1) = CInt(Tot1 * WLobp(1) / Tot * 100) / 100
        End If
        Wcomm(1) = True
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

        If CovArry(2) = 0 Or IvalCat() Then Exit Sub

        txtPPpd.TextAlign = HorizontalAlignment.Right
        MLobp(2) = Val(txtPPpd.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(2) = False And Tot <> 0 Then
            If MLobp(2) = 0 Then MLobp(2) = CInt(Tot1 * WLobp(2) / Tot * 100) / 100
        End If
        Wcomm(2) = True
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

        If CovArry(3) = 0 Or IvalCat() Then Exit Sub

        txtPPmed.TextAlign = HorizontalAlignment.Right
        MLobp(3) = Val(txtPPmed.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(3) = False And Tot <> 0 Then
            If MLobp(3) = 0 Then MLobp(3) = CInt(Tot1 * WLobp(3) / Tot * 100) / 100
        End If
        Wcomm(3) = True
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

        If CovArry(4) = 0 Or IvalCat() Then Exit Sub

        txtPPumbi.TextAlign = HorizontalAlignment.Right
        MLobp(4) = Val(txtPPumbi.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(4) = False And Tot <> 0 Then
            If MLobp(4) = 0 Then MLobp(4) = CInt(Tot1 * WLobp(4) / Tot * 100) / 100
        End If
        Wcomm(4) = True
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

        If CovArry(5) = 0 Or IvalCat() Then Exit Sub

        txtPPumpd.TextAlign = HorizontalAlignment.Right
        MLobp(5) = Val(txtPPumpd.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(5) = False And Tot <> 0 Then
            If MLobp(5) = 0 Then MLobp(5) = CInt(Tot1 * WLobp(5) / Tot * 100) / 100
        End If
        Wcomm(5) = True
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

        If CovArry(6) = 0 Or IvalCat() Then Exit Sub

        txtPPpip.TextAlign = HorizontalAlignment.Right
        MLobp(6) = Val(txtPPpip.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(6) = False And Tot <> 0 Then
            If MLobp(6) = 0 Then MLobp(6) = CInt(Tot1 * WLobp(6) / Tot * 100) / 100
        End If
        Wcomm(6) = True
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

        If CovArry(7) = 0 Or IvalCat() Then Exit Sub

        txtPPcomp.TextAlign = HorizontalAlignment.Right
        MLobp(7) = Val(txtPPcomp.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(7) = False And Tot <> 0 Then
            If MLobp(7) = 0 Then MLobp(7) = CInt(Tot1 * WLobp(7) / Tot * 100) / 100
        End If
        Wcomm(7) = True
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

        If Not ValRec() Then Exit Sub
        If CovArry(8) = 0 Or IvalCat() Then Exit Sub

        txtPPcoll.TextAlign = HorizontalAlignment.Right
        MLobp(8) = Val(txtPPcoll.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(8) = False And Tot <> 0 Then
            If MLobp(8) = 0 Then MLobp(8) = CInt(Tot1 * WLobp(8) / Tot * 100) / 100
        End If
        Wcomm(8) = True
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

        If CovArry(9) = 0 Or IvalCat() Then Exit Sub

        txtPPrent.TextAlign = HorizontalAlignment.Right
        MLobp(9) = Val(txtPPrent.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(9) = False And Tot <> 0 Then
            If MLobp(9) = 0 Then MLobp(9) = CInt(Tot1 * WLobp(9) / Tot * 100) / 100
        End If
        Wcomm(9) = True
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

        If CovArry(10) = 0 Or IvalCat() Then Exit Sub

        txtPPtow.TextAlign = HorizontalAlignment.Right
        MLobp(10) = Val(txtPPtow.Text)
        If Not ValPP Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(10) = False And Tot <> 0 Then
            If MLobp(10) = 0 Then MLobp(10) = CInt(Tot1 * WLobp(10) / Tot * 100) / 100
        End If
        Wcomm(10) = True
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

        If CovArry(11) = 0 Or IvalCat() Then Exit Sub

        txtCMbi.TextAlign = HorizontalAlignment.Right
        MLobp(11) = Val(txtCMbi.Text)
        If Not ValCM Then Exit Sub
        If txtRptCatCode.Text = "03" And Wcomm(11) = False And Tot <> 0 Then
            If MLobp(11) = 0 Then MLobp(11) = CInt(Tot1 * WLobp(11) / Tot * 100) / 100
        End If
        Wcomm(11) = True
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
        If CovArry(12) = 0 Or IvalCat() Then Exit Sub

        txtCMpd.TextAlign = HorizontalAlignment.Right
        MLobp(12) = Val(txtCMpd.Text)
        If txtRptCatCode.Text = "03" And Wcomm(12) = False And Tot <> 0 Then
            If MLobp(12) = 0 Then MLobp(12) = CInt(Tot1 * WLobp(12) / Tot * 100) / 100
        End If
        Wcomm(12) = True
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

        If CovArry(13) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMmed.TextAlign = HorizontalAlignment.Right
        MLobp(13) = Val(txtCMmed.Text)
        If txtRptCatCode.Text = "03" And Wcomm(13) = False And Tot <> 0 Then
            If MLobp(13) = 0 Then MLobp(13) = CInt(Tot1 * WLobp(13) / Tot * 100) / 100
        End If
        Wcomm(13) = True
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

        If CovArry(14) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        MLobp(14) = Val(txtCMumbi.Text)
        If txtRptCatCode.Text = "03" And Wcomm(14) = False And Tot <> 0 Then
            If MLobp(14) = 0 Then MLobp(14) = CInt(Tot1 * WLobp(14) / Tot * 100) / 100
        End If
        Wcomm(14) = True
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
        Tobj = txtCMumpd

        If CovArry(15) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMumpd.TextAlign = HorizontalAlignment.Right
        MLobp(15) = Val(txtCMumpd.Text)
        If txtRptCatCode.Text = "03" And Wcomm(15) = False And Tot <> 0 Then
            If MLobp(15) = 0 Then MLobp(15) = CInt(Tot1 * WLobp(15) / Tot * 100) / 100
        End If
        Wcomm(15) = True
        txtCMumpd.Text = Format(MLobp(15), "###,###,###.00")
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
        Tobj = txtCMpip

        If CovArry(16) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMpip.TextAlign = HorizontalAlignment.Right
        MLobp(16) = Val(txtCMpip.Text)
        If txtRptCatCode.Text = "03" And Wcomm(16) = False And Tot <> 0 Then
            If MLobp(16) = 0 Then MLobp(16) = CInt(Tot1 * WLobp(16) / Tot * 100) / 100
        End If
        Wcomm(16) = True
        txtCMpip.Text = Format(MLobp(16), "###,###,###.00")
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
        Tobj = txtCMcomp

        If CovArry(17) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMcomp.TextAlign = HorizontalAlignment.Right
        MLobp(17) = Val(txtCMcomp.Text)
        If txtRptCatCode.Text = "03" And Wcomm(17) = False And Tot <> 0 Then
            If MLobp(17) = 0 Then MLobp(17) = CInt(Tot1 * WLobp(17) / Tot * 100) / 100
        End If
        Wcomm(17) = True
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
        Tobj = txtCMcoll

        If CovArry(18) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMcoll.TextAlign = HorizontalAlignment.Right
        MLobp(18) = Val(txtCMcoll.Text)
        If txtRptCatCode.Text = "03" And Wcomm(18) = False And Tot <> 0 Then
            If MLobp(18) = 0 Then MLobp(18) = CInt(Tot1 * WLobp(18) / Tot * 100) / 100
        End If
        Wcomm(18) = True
        txtCMcoll.Text = Format(MLobp(18), "###,###,###.00")
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
        If CovArry(19) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMrent.TextAlign = HorizontalAlignment.Right
        MLobp(19) = Val(txtCMrent.Text)
        If txtRptCatCode.Text = "03" And Wcomm(19) = False And Tot <> 0 Then
            If MLobp(19) = 0 Then MLobp(19) = CInt(Tot1 * WLobp(19) / Tot * 100) / 100
        End If
        Wcomm(19) = True
        txtCMrent.Text = Format(MLobp(19), "###,###,###.00")
        Tobj = txtCMrent
        TotalTran()
    End Sub
	
    Private Sub txtCMtow_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtCMtow.Enter
        If Not ValRec() Then Exit Sub
        If CovArry(20) = 0 Or IvalCat() Then
            txtPPbi.Focus()
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

        If CovArry(20) = 0 Or IvalCat() Then Exit Sub
        If Not ValCM Then Exit Sub

        txtCMtow.TextAlign = HorizontalAlignment.Right
        MLobp(20) = Val(txtCMtow.Text)
        If txtRptCatCode.Text = "03" And Wcomm(20) = False And Tot <> 0 Then
            If MLobp(20) = 0 Then MLobp(20) = CInt(Tot1 * WLobp(20) / Tot * 100) / 100
        End If
        Wcomm(20) = True
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

        If CovArry(21) = 0 Or IvalCat() Then Exit Sub
        If Not ValOT Then Exit Sub

        txtOTim.TextAlign = HorizontalAlignment.Right
        MLobp(21) = Val(txtOTim.Text)
        If txtRptCatCode.Text = "03" And Wcomm(21) = False And Tot <> 0 Then
            If MLobp(21) = 0 Then MLobp(21) = CInt(Tot1 * WLobp(21) / Tot * 100) / 100
        End If
        Wcomm(21) = True
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

        If CovArry(22) = 0 Or IvalCat() Then Exit Sub
        If Not ValOT Then Exit Sub

        txtOTallied.TextAlign = HorizontalAlignment.Right
        MLobp(22) = Val(txtOTallied.Text)
        If txtRptCatCode.Text = "03" And Wcomm(22) = False And Tot <> 0 Then
            If MLobp(22) = 0 Then MLobp(22) = CInt(Tot1 * WLobp(22) / Tot * 100) / 100
        End If
        Wcomm(22) = True
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

        If CovArry(23) = 0 Or IvalCat() Then Exit Sub
        If Not ValOT Then Exit Sub

        txtOTfire.TextAlign = HorizontalAlignment.Right
        MLobp(23) = Val(txtOTfire.Text)
        If txtRptCatCode.Text = "03" And Wcomm(23) = False And Tot <> 0 Then
            If MLobp(23) = 0 Then MLobp(23) = CInt(Tot1 * WLobp(23) / Tot * 100) / 100
        End If
        Wcomm(23) = True
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

        If CovArry(24) = 1 Then
            If KeyCode = 13 Or KeyCode = 114 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
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

        If CovArry(24) = 0 Or IvalCat() Then Exit Sub

        If Not ValOT Then Exit Sub

        txtOTmulti.TextAlign = HorizontalAlignment.Right
        MLobp(24) = Val(txtOTmulti.Text)
        If txtRptCatCode.Text = "03" And Wcomm(24) = False And Tot <> 0 Then
            If MLobp(24) = 0 Then MLobp(24) = CInt(Tot1 * WLobp(24) / Tot * 100) / 100
        End If
        Wcomm(24) = True
        txtOTmulti.Text = Format(MLobp(24), "###,###,###.00")
        TotalTran()
    End Sub
	
    Private Sub InitRptEntryForm()
        Dim X As Integer

        Array.Clear(WLobp, 0, WLobp.Length)
        Array.Clear(MLobp, 0, MLobp.Length)
        Array.Clear(Wcomm, 0, Wcomm.Length)

        rc = d4unlock(f5) ' RPTDIR
        ByPassCbo = True
        DelTran = False
        InqTran = False
        RecChanged = False
        YearOk = False
        CatOk = False
        CovCnt = 0
        PremRec = False
        For X = 0 To 24
            MLobp(X) = 0
            Wcomm(X) = False
        Next X
        MLobt = 0


        txtRptCatCode.ReadOnly = False
        txtRptYear.ReadOnly = False
        cboRptCatDesc.ResetText()
        lblRecAction.Visible = False
        cmdRecAction.Visible = False

        If Not AddTran And Not UpdateTran Then
            txtRptMgaNmbr.ReadOnly = False
            txtRptTrtyNmbr.ReadOnly = False
            txtRptPeriod.ReadOnly = False
            MgaOk = False
            TrtyOk = False
            PeriodOk = False
            txRptMgaNmbr = ""
            txRptTrtyNmbr = ""
            txRptPeriod = ""

            txtRptMgaNmbr.Text = ""
            txtRptTrtyNmbr.Text = ""
            txtRptPeriod.Text = ""

            For X = 0 To 24
                CovArry(X) = 0
            Next X
        End If

        txRptCatCode = ""
        txRptYear = ""

        txtRptCatCode.Text = ""
        txtRptYear.Text = ""
        txtRptTotal.Text = ""
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
        txtRptTranTotal.Text = ""

        'This code handles keeping default entry data loaded
        If Not AddTran And Not UpdateTran Then
            'Load Mga Combo Box
            LoadCboMga()

            'Load Trty Combo Box
            TrtyKey = "001" & "06"
            LoadCboTrty()

            'Load Categoray Desc
            LoadCboCat()

            ByPassCbo = True
            cboRptMga.SelectedIndex = 1
            cboRptTrty.SelectedIndex = 1
            cboRptCatDesc.SelectedIndex = 1
            ByPassCbo = False
            txtRptMgaNmbr.Text = ""
        End If

        s = "   "
        S1 = "  "

        GetPeriodData()
    End Sub
	
	Private Sub TotalTran()
        Dim X As Integer
        Wtotal = 0
		For X = 1 To 24
			If MLobp(X) <> 0 Then
				Wtotal = Wtotal + MLobp(X)
			End If
		Next 
        txtRptTranTotal.Text = Format(Wtotal, "###,###,###.00")
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
	
	Private Sub ProcessRptTrans()
		Dim response As Object
		
		If Not MgaOk Or Not TrtyOk Or Not PeriodOk Or Not CatOk Or Not YearOk Then
			InitRptEntryForm()
			txtRptMgaNmbr.Focus()
			Exit Sub
		End If
		
		TotalTran()
		If txtRptCatCode.Text <> "02" And txtRptCatCode.Text <> "11" And txtRptCatCode.Text <> "12" And txtRptCatCode.Text <> "15" And txtRptCatCode.Text <> "16" And txtRptCatCode.Text <> "17" Then
            If Math.Round(CDec(Wtotal), 2) <> Math.Round(CDec(MLobt), 2) Then
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

        response = 0
		If AddTran Then
            response = MsgBox("Add Record", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Add Record")
		End If
		If UpdateTran Then
            response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
		End If
		If response = MsgBoxResult.No Then
			If txtRptCatCode.Text <> "02" And txtRptCatCode.Text <> "11" And txtRptCatCode.Text <> "12" And txtRptCatCode.Text <> "15" And txtRptCatCode.Text <> "16" And txtRptCatCode.Text <> "17" Then
				If ValPP Then txtPPbi.Focus()
				If ValCM Then txtCMbi.Focus()
				If ValOT Then txtOTim.Focus()
			Else
				txtRptTotal.Focus()
			End If
			Exit Sub
		End If
		
		UpRptDirVars()
		If AddTran Then AddRptDirRec()
		If UpdateTran Then UpRptDirRec()
		
		If AddTran Or UpdateTran Then
			Call f4memoAssign(TMp.TrtyHist, txTrtyHist)
		End If
		
		If Not AddTran And Not UpdateTran Then MsgBox("No Record To Process")
		InitRptEntryForm()
		
		If AddTran Or UpdateTran Then
			txtRptCatCode.Focus()
		Else
			txtRptMgaNmbr.Focus()
		End If
	End Sub
	
	Function ValRec() As Object
		Dim response As Object
		
        ValRec = False
		
		If (Not MgaOk) Or (Not TrtyOk) Or (Not PeriodOk) Or (Not CatOk) Or (Not YearOk) Then
			MsgBox("Not enough info to process")
			InitRptEntryForm()
			txtRptMgaNmbr.Focus()
			Exit Function
		End If
		
        If txtRptCatCode.Text = "03" Or txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Then
            If PremRec = False Then
                MsgBox("Premium Record Must Be Entered First")
                response = MsgBox("Override", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "")
                If response = MsgBoxResult.No Then
                    AddTran = False
                    UpdateTran = False
                    InitRptEntryForm()
                    txtRptMgaNmbr.Focus()
                    Exit Function
                End If
                PremRec = True
            End If
        End If
		
        ValRec = True
	End Function
	
	Function IvalCat() As Object
        IvalCat = False
		If txtRptCatCode.Text = "02" Or txtRptCatCode.Text = "11" Or txtRptCatCode.Text = "12" Or txtRptCatCode.Text = "15" Or txtRptCatCode.Text = "16" Or txtRptCatCode.Text = "17" Then
            IvalCat = True
		End If
	End Function
	
	Sub ResetForm(ByRef KeyCode As Short)
		If KeyCode = 27 Then
			AddTran = False
			UpdateTran = False
			InitRptEntryForm()
			txtRptMgaNmbr.Focus()
		End If
	End Sub
	
	Private Sub UpRptDirFrmVar()
		txtRptMgaNmbr.Text = txRptMgaNmbr
		txtRptTrtyNmbr.Text = txRptTrtyNmbr
		txtRptPeriod.Text = txRptPeriod
		txtRptCatCode.Text = txRptCatCode
		txtRptYear.Text = txRptYear
        txtRptTotal.Text = Format(MLobt, "##,###,###.00")
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
	
	Private Sub UpRptDirVars()
		txRptMgaNmbr = txtRptMgaNmbr.Text
		txRptTrtyNmbr = txtRptTrtyNmbr.Text
		txRptPeriod = txtRptPeriod.Text
		txRptCatCode = txtRptCatCode.Text
		txRptYear = txtRptYear.Text
	End Sub
End Class