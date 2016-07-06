Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Friend Class frmMgaEntry
    Dim Pdlg As New PrintDialog
    Dim P As New Printer

    Private Sub cboMga_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboMga.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        MgaKey = Mid(cboMga.Text, 1, 3)
        GetMgaMstRec()
        UpMgaMstFrmVar()
        txtMgaNmbr.ReadOnly = True
        txtMgaNmbr.Focus()
        UpdateTran = True
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

        If response = MsgBoxResult.Yes Then ProcessMgaMstRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitMgaForm()
            txtMgaNmbr.Focus()
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

    Private Sub frmMgaEntry_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenMgaMst()
        InitMgaForm()
    End Sub

    Public Sub mnuMgaExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuMgaExit.Click
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
        DelMgaMstRec()
        InitMgaForm()
        txtMgaNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitMgaForm()
        txtMgaNmbr.Focus()
    End Sub

    Public Sub mnuOprtMgaDetail_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprtMgaDetail.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub
        PrtMgaDetail()
        txtMgaName.Focus()
    End Sub

    Public Sub mnuOprtMgaList_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprtMgaList.Click
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub
        PrtMgaAllDetail()
        txtMgaNmbr.Focus()
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
        DelMgaMstRec()
        InitMgaForm()
        txtMgaNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitMgaForm()
        txtMgaNmbr.Focus()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtMgaNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Enter
        Tobj = txtMgaNmbr
    End Sub

    Private Sub txtMgaNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtMgaName.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaName.Focus()

        ResetForm((KeyCode))
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

    Private Sub txtMgaNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaNmbr.Leave
        Dim M As String
        Dim M1 As Short
        Dim X As Short

        Tobj = txtMgaNmbr

        s = "   "
        s = RSet(Tobj.Text, Len(s))

        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next

        If s = "000" Then s = ""
        Tobj.Text = s

        If Len(Trim(txtMgaNmbr.Text)) = 3 Then
            MgaKey = txtMgaNmbr.Text
            GetMgaMstRec()
            If UpdateTran Then
                UpMgaMstFrmVar()
                txtMgaNmbr.ReadOnly = True
            End If
            If AddTran Then
                M = txtMgaNmbr.Text
                M1 = cboMga.SelectedIndex
                InitMgaForm()
                AddTran = True
                txtMgaNmbr.Text = M
                ByPassCbo = True
                cboMga.SelectedIndex = M1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtMgaName_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaName.Enter
        Dim X As Short

        Tobj = txtMgaName

        If Len(txtMgaNmbr.Text) > 0 Then
            For X = 0 To cboMga.Items.Count
                If MgaArray(X) = txtMgaNmbr.Text Then
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

    Private Sub txtMgaName_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaName.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaNmbr.Focus()
            Case Keys.Down
                txtMgaAddr1.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaAddr1.Focus()
    End Sub

    Private Sub txtMgaName_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaName.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaName_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaName.Leave
        Tobj = txtMgaName
    End Sub

    Private Sub txtMgaAddr1_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaAddr1.Enter
        Tobj = txtMgaAddr1
    End Sub

    Private Sub txtMgaAddr1_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaAddr1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaName.Focus()
            Case Keys.Down
                txtMgaAddr2.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaAddr2.Focus()
    End Sub

    Private Sub txtMgaAddr1_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaAddr1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaAddr1.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaAddr1_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaAddr1.Leave
        Tobj = txtMgaAddr1
    End Sub

    Private Sub txtMgaAddr2_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaAddr2.Enter
        Tobj = txtMgaAddr2
    End Sub

    Private Sub txtMgaAddr2_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaAddr2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaAddr1.Focus()
            Case Keys.Down
                txtMgaAddr3.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaAddr3.Focus()
    End Sub

    Private Sub txtMgaAddr2_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaAddr2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaAddr2.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaAddr2_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaAddr2.Leave
        Tobj = txtMgaAddr2
    End Sub

    Private Sub txtMgaAddr3_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaAddr3.Enter
        Tobj = txtMgaAddr3
    End Sub

    Private Sub txtMgaAddr3_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaAddr3.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaAddr2.Focus()
            Case Keys.Down
                txtMgaPhone.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaPhone.Focus()
    End Sub

    Private Sub txtMgaAddr3_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaAddr3.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaAddr3.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaAddr3_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaAddr3.Leave
        Tobj = txtMgaAddr3
    End Sub

    Private Sub txtMgaPhone_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaPhone.Enter
        Tobj = txtMgaPhone
    End Sub

    Private Sub txtMgaPhone_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaPhone.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaAddr3.Focus()
            Case Keys.Down
                txtMgaFax.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaFax.Focus()
    End Sub

    Private Sub txtMgaPhone_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaPhone.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaPhone.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaPhone_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaPhone.Leave
        Tobj = txtMgaPhone
    End Sub

    Private Sub txtMgaFax_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaFax.Enter
        Tobj = txtMgaFax
    End Sub

    Private Sub txtMgaFax_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaFax.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtMgaPhone.Focus()
            Case Keys.Down
                txtMgaFein.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtMgaFein.Focus()
    End Sub

    Private Sub txtMgaFax_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaFax.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaFax.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaFax_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaFax.Leave
        Tobj = txtMgaFax
    End Sub

    Private Sub txtMgaFein_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaFein.Enter
        Tobj = txtMgaFein
    End Sub

    Private Sub txtMgaFein_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtMgaFein.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtMgaFax.Focus()
            Case Keys.Down
                txtMgaNmbr.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Then
            If Len(Trim(txtMgaNmbr.Text)) = 3 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If
    End Sub

    Private Sub txtMgaFein_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtMgaFein.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtMgaFein.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMgaFein_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtMgaFein.Leave
        Tobj = txtMgaFein
    End Sub

    Private Sub ProcessMgaMstRec()
        UpMgaMstVars()
        If AddTran Then AddMgaMstRec()
        If UpdateTran Then UpMgaMstRec()
        InitMgaForm()
        txtMgaNmbr.Focus()
    End Sub

    Private Sub InitMgaForm()
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtMgaNmbr.ReadOnly = False
        cmdRecAction.Visible = False

        txMgaNmbr = ""
        txMgaName = ""
        txMgaAddr1 = ""
        txMgaAddr2 = ""
        txMgaAddr3 = ""
        txMgaPhone = ""
        txMgaFax = ""
        txMgaFein = ""
        txMgaHist = ""

        txtMgaNmbr.Text = ""
        txtMgaName.Text = ""
        txtMgaAddr1.Text = ""
        txtMgaAddr2.Text = ""
        txtMgaAddr3.Text = ""
        txtMgaPhone.Text = ""
        txtMgaFax.Text = ""
        txtMgaFein.Text = ""
        LoadCboMga()

        ByPassCbo = True
        cboMga.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitMgaForm()
            txtMgaNmbr.Focus()
        End If
    End Sub

    Sub UpMgaMstFrmVar()
        txtMgaNmbr.Text = txMgaNmbr
        txtMgaName.Text = txMgaName
        txtMgaAddr1.Text = txMgaAddr1
        txtMgaAddr2.Text = txMgaAddr2
        txtMgaAddr3.Text = txMgaAddr3
        txtMgaPhone.Text = txMgaPhone
        txtMgaFax.Text = txMgaFax
        txtMgaFein.Text = txMgaFein
    End Sub

    Sub UpMgaMstVars()
        txMgaNmbr = txtMgaNmbr.Text
        txMgaName = txtMgaName.Text
        txMgaAddr1 = txtMgaAddr1.Text
        txMgaAddr2 = txtMgaAddr2.Text
        txMgaAddr3 = txtMgaAddr3.Text
        txMgaPhone = txtMgaPhone.Text
        txMgaFax = txtMgaFax.Text
        txMgaFein = txtMgaFein.Text
    End Sub

    Sub LoadCboMga()
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

    Private Sub PrtMgaDetail()
        If Not UpdateTran Then Exit Sub

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then
                prtobj = Me.P
            End If
        Next


        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        prtobj.Print(C0str)
        prtobj.Print("MGA Detail")
        prtobj.Print()

        prtobj.Print("MGA Number ", TAB(15), Trim(f4str(Mp.MgaNmbr)))
        prtobj.Print()
        prtobj.Print("MGA Name   ", TAB(15), Trim(f4str(Mp.MgaName)))
        prtobj.Print("___________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Address 1   ", TAB(15), Trim(f4str(Mp.MgaAddr1)))
        prtobj.Print()
        prtobj.Print("Address 2   ", TAB(15), Trim(f4str(Mp.MgaAddr2)))
        prtobj.Print()
        prtobj.Print("Address 3   ", TAB(15), Trim(f4str(Mp.MgaAddr3)))
        prtobj.Print("___________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Phone #     ", TAB(15), Trim(f4str(Mp.MgaPhone)))
        prtobj.Print()
        prtobj.Print("Fax #       ", TAB(15), Trim(f4str(Mp.MgaFax)))
        prtobj.Print()
        prtobj.Print("FEIN        ", TAB(15), Trim(f4str(Mp.MgaFein)))
        prtobj.Print("___________________________________________________________________")

        prtobj.EndDoc()
    End Sub

    Sub PrtMgaAllDetail()

        For Each Me.P In Printers
            If Me.P.DeviceName = Pdlg.PrinterSettings.PrinterName Then
                prtobj = Me.P
            End If
        Next

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        X = 0
        PrtMgaDetHd()

        rc = d4top(f1)
        Call d4tagSelect(f1, d4tag(f1, "K1"))

        Do Until rc = r4eof
            prtobj.Print(Trim(f4str(Mp.MgaNmbr)))
            prtobj.Print(TAB(5), Trim(f4str(Mp.MgaName)))
            prtobj.Print(TAB(39), Trim(f4str(Mp.MgaPhone)))
            prtobj.Print(TAB(52), Trim(f4str(Mp.MgaFax)))
            prtobj.Print(TAB(65), Trim(f4str(Mp.MgaFein)))
            prtobj.Print(TAB(5), Trim(f4str(Mp.MgaAddr1)))
            prtobj.Print(TAB(5), Trim(f4str(Mp.MgaAddr2)))
            prtobj.Print(TAB(5), Trim(f4str(Mp.MgaAddr3)))
            X = X + 4
            If X > 55 Then PrtMgaDetHd()
            rc = d4skip(f1, 1)
        Loop

        rc = d4bottom(f1)
        rc = d4unlock(f1)

        prtobj.EndDoc()
    End Sub

    Sub PrtMgaDetHd()
        If X <> 0 Then prtobj.NewPage()
        prtobj.Print(C0str)
        prtobj.Print("MGA Listing")
        prtobj.Print()
        prtobj.Print("________________________________________________________________________________")
        prtobj.Print("MGA", TAB(5), "Name", TAB(46), "Phone", TAB(61), "Fax", TAB(71), "FEIN")
        prtobj.Print("#", TAB(5), "Address", TAB(45), "Number", TAB(58), "Number", TAB(69), "Number")
        prtobj.Print("________________________________________________________________________________")
        X = 0
    End Sub

    Private Sub mnuMgaComments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuMgaComments.Click
        frmMgaComments.ShowDialog()
    End Sub

End Class