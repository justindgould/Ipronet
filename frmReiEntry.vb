Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Friend Class frmReiEntry
    Inherits DevExpress.XtraEditors.XtraForm

    Dim r1(10) As String
    Dim r2(10) As String

    Dim Pdlg As New PrintDialog
    Dim p As New Printer

    Private Sub cboRei_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRei.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        ReiKey = Mid(cboRei.Text, 1, 3)
        GetReiMstRec()
        UpReiMstFrmVar()
        fra1.Visible = False
        txtReiNmbr.ReadOnly = True
        txtReiNmbr.Focus()
        UpdateTran = True
    End Sub

    Private Sub cboRei_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cboRei.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
    End Sub

    Private Sub cmdDone_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs)
        fra1.Visible = False
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
        If response = MsgBoxResult.Yes Then ProcessReiMstRec()
        If response = MsgBoxResult.No Or (Not AddTran And Not UpdateTran) Then
            InitReiForm()
            txtReiNmbr.Focus()
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

    Private Sub frmReiEntry_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        fra1.Visible = False
        OpenReiMst()
        OpenTrtyMst()
        OpenTrtyPrm()
        InitReiForm()
    End Sub

    Private Sub frmReiEntry_MouseUp(ByVal eventSender As Object, ByVal eventArgs As MouseEventArgs) Handles MyBase.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    End Sub

    Public Sub mnuOdelrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOdelrec.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelReiMstRec()
        InitReiForm()
        txtReiNmbr.Focus()
    End Sub

    Public Sub mnuOnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOnewrec.Click
        InitReiForm()
        txtReiNmbr.Focus()
    End Sub

    Public Sub mnuOprtall_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprtAll.Click
        ReiPrtAll()
    End Sub

    Public Sub mnuOprtAllReinDetail_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprtAllReinDetail.Click
        ReiPrtAllDetail()
    End Sub

    Public Sub mnuOprtReinDetail_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOprtReinDetail.Click
        ReiPrtDetail()
        txtReiName.Focus()
    End Sub

    Public Sub mnuOtrtyprt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOtrtyprt.Click
        Dim X1 As Object
        Dim X2 As Integer
        Dim X As Integer


        If Trim(txtReiNmbr.Text) <> "" Then
            fra1.Visible = True
        Else
            Exit Sub
        End If

        If PrtRpt <> True Then Exit Sub

        X2 = 0

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        PageHeading()
        lstReiTrty.Items.Clear()


        rc = d4top(f3) 'Treaty Master
        Call d4tagSelect(f3, d4tag(f3, "K1"))

        For X1 = 0 To d4recCount(f3)
            r1(1) = f4str(TMp.TrtyReiNmbr1)
            r1(2) = f4str(TMp.TrtyReiNmbr2)
            r1(3) = f4str(TMp.TrtyReiNmbr3)
            r1(4) = f4str(TMp.TrtyReiNmbr4)
            r1(5) = f4str(TMp.TrtyReiNmbr5)
            r1(6) = f4str(TMp.TrtyReiNmbr6)
            r1(7) = f4str(TMp.TrtyReiNmbr7)
            r1(8) = f4str(TMp.TrtyReiNmbr8)
            r1(9) = f4str(TMp.TrtyReiNmbr9)
            r1(10) = f4str(TMp.TrtyReiNmbr10)

            r2(1) = Format(f4double(TMp.TrtyReiPerc1) * 100, "###.0000")
            r2(2) = Format(f4double(TMp.TrtyReiPerc2) * 100, "###.0000")
            r2(3) = Format(f4double(TMp.TrtyReiPerc3) * 100, "###.0000")
            r2(4) = Format(f4double(TMp.TrtyReiPerc4) * 100, "###.0000")
            r2(5) = Format(f4double(TMp.TrtyReiPerc5) * 100, "###.0000")
            r2(6) = Format(f4double(TMp.TrtyReiPerc6) * 100, "###.0000")
            r2(7) = Format(f4double(TMp.TrtyReiPerc7) * 100, "###.0000")
            r2(8) = Format(f4double(TMp.TrtyReiPerc8) * 100, "###.0000")
            r2(9) = Format(f4double(TMp.TrtyReiPerc9) * 100, "###.0000")
            r2(10) = Format(f4double(TMp.TrtyReiPerc10) * 100, "###.0000")

            For X = 1 To 10
                If Trim(r1(X)) = Trim(txtReiNmbr.Text) Then
                    X2 = X2 + 1
                    If X2 > 50 Then
                        prtobj.NewPage()
                        PageHeading()
                        X2 = 0
                    End If
                    prtobj.Print(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & "   " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & "  " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))

                    lstReiTrty.Items.Add(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & " " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & " " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))
                    GoTo nextrec
                End If
            Next X
nextrec:
            rc = d4skip(f3, 1)
        Next X1

        rc = d4bottom(f3)
        rc = d4unlock(f3)

        prtobj.EndDoc()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuOview_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOview.Click
        Dim X1 As Integer
        Dim X As Integer

        If Trim(txtReiNmbr.Text) <> "" Then
            fra1.Visible = True
        Else
            Exit Sub
        End If

        lstReiTrty.Items.Clear()

        rc = d4top(f3) ' Treaty Master
        Call d4tagSelect(f3, d4tag(f3, "K1"))

        For X1 = 0 To d4recCount(f3)
            r1(1) = f4str(TMp.TrtyReiNmbr1)
            r1(2) = f4str(TMp.TrtyReiNmbr2)
            r1(3) = f4str(TMp.TrtyReiNmbr3)
            r1(4) = f4str(TMp.TrtyReiNmbr4)
            r1(5) = f4str(TMp.TrtyReiNmbr5)
            r1(6) = f4str(TMp.TrtyReiNmbr6)
            r1(7) = f4str(TMp.TrtyReiNmbr7)
            r1(8) = f4str(TMp.TrtyReiNmbr8)
            r1(9) = f4str(TMp.TrtyReiNmbr9)
            r1(10) = f4str(TMp.TrtyReiNmbr10)

            r2(1) = Format(f4double(TMp.TrtyReiPerc1) * 100, "###.0000")
            r2(2) = Format(f4double(TMp.TrtyReiPerc2) * 100, "###.0000")
            r2(3) = Format(f4double(TMp.TrtyReiPerc3) * 100, "###.0000")
            r2(4) = Format(f4double(TMp.TrtyReiPerc4) * 100, "###.0000")
            r2(5) = Format(f4double(TMp.TrtyReiPerc5) * 100, "###.0000")
            r2(6) = Format(f4double(TMp.TrtyReiPerc6) * 100, "###.0000")
            r2(7) = Format(f4double(TMp.TrtyReiPerc7) * 100, "###.0000")
            r2(8) = Format(f4double(TMp.TrtyReiPerc8) * 100, "###.0000")
            r2(9) = Format(f4double(TMp.TrtyReiPerc9) * 100, "###.0000")
            r2(10) = Format(f4double(TMp.TrtyReiPerc10) * 100, "###.0000")

            For X = 1 To 10
                If Trim(r1(X)) = Trim(txtReiNmbr.Text) Then
                    lstReiTrty.Items.Add(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & " " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & " " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))
                    GoTo nextrec
                End If
            Next X
nextrec:
            rc = d4skip(f3, 1)
        Next X1

        rc = d4bottom(f3)
        rc = d4unlock(f3)
    End Sub

    Public Sub mnuReiComments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuReiComments.Click
        If AddTran Or UpdateTran Then frmReiComments.ShowDialog()
    End Sub

    Public Sub mnuReiExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuReiExit.Click
        Me.Close()
    End Sub

    Private Sub mnuMgaExit_Click()

    End Sub

    Public Sub mnuUcomments_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUcomments.Click
        If AddTran Or UpdateTran Then frmReiComments.ShowDialog()
    End Sub

    Public Sub mnuUdel_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUdel.Click
        Dim response As Short

        If Not UpdateTran Then
            MsgBox("No Record To Process")
            Exit Sub
        End If
        response = MsgBox("!!!Delete Record!!!", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete Record")
        If response = MsgBoxResult.No Then Exit Sub
        DelReiMstRec()
        InitReiForm()
        txtReiNmbr.Focus()
    End Sub

    Public Sub mnuUnewrec_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUnewrec.Click
        InitReiForm()
        txtReiNmbr.Focus()
    End Sub

    Public Sub mnuUtrtyprt_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUtrtyprt.Click
        Dim X1 As Integer
        Dim X2 As Integer
        Dim X As Integer

        If Trim(txtReiNmbr.Text) <> "" Then
            fra1.Visible = True
        Else
            Exit Sub
        End If

        X2 = 0

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        PageHeading()

        lstReiTrty.Items.Clear()

        rc = d4top(f3) 'Treaty Master
        Call d4tagSelect(f3, d4tag(f3, "K1"))

        For X1 = 0 To d4recCount(f3)
            r1(1) = f4str(TMp.TrtyReiNmbr1)
            r1(2) = f4str(TMp.TrtyReiNmbr2)
            r1(3) = f4str(TMp.TrtyReiNmbr3)
            r1(4) = f4str(TMp.TrtyReiNmbr4)
            r1(5) = f4str(TMp.TrtyReiNmbr5)
            r1(6) = f4str(TMp.TrtyReiNmbr6)
            r1(7) = f4str(TMp.TrtyReiNmbr7)
            r1(8) = f4str(TMp.TrtyReiNmbr8)
            r1(9) = f4str(TMp.TrtyReiNmbr9)
            r1(10) = f4str(TMp.TrtyReiNmbr10)

            r2(1) = Format(f4double(TMp.TrtyReiPerc1) * 100, "###.0000")
            r2(2) = Format(f4double(TMp.TrtyReiPerc2) * 100, "###.0000")
            r2(3) = Format(f4double(TMp.TrtyReiPerc3) * 100, "###.0000")
            r2(4) = Format(f4double(TMp.TrtyReiPerc4) * 100, "###.0000")
            r2(5) = Format(f4double(TMp.TrtyReiPerc5) * 100, "###.0000")
            r2(6) = Format(f4double(TMp.TrtyReiPerc6) * 100, "###.0000")
            r2(7) = Format(f4double(TMp.TrtyReiPerc7) * 100, "###.0000")
            r2(8) = Format(f4double(TMp.TrtyReiPerc8) * 100, "###.0000")
            r2(9) = Format(f4double(TMp.TrtyReiPerc9) * 100, "###.0000")
            r2(10) = Format(f4double(TMp.TrtyReiPerc10) * 100, "###.0000")

            For X = 1 To 10
                If Trim(r1(X)) = Trim(txtReiNmbr.Text) Then
                    X2 = X2 + 1
                    If X2 > 50 Then
                        prtobj.NewPage()
                        PageHeading()
                        X2 = 0
                    End If
                    prtobj.Print(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & "   " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & "  " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))

                    lstReiTrty.Items.Add(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & " " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & " " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))
                    GoTo nextrec
                End If
            Next X
nextrec:
            rc = d4skip(f3, 1)
        Next X1

        rc = d4bottom(f3)
        rc = d4unlock(f3)

        prtobj.EndDoc()
    End Sub

    Public Sub mnuUupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Public Sub mnuUview_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuUview.Click
        Dim X1 As Integer
        Dim X As Integer

        If Trim(txtReiNmbr.Text) <> "" Then
            fra1.Visible = True
        Else
            Exit Sub
        End If

        lstReiTrty.Items.Clear()

        rc = d4top(f3) ' Treaty Master
        Call d4tagSelect(f3, d4tag(f3, "K1"))

        For X1 = 0 To d4recCount(f3)
            r1(1) = f4str(TMp.TrtyReiNmbr1)
            r1(2) = f4str(TMp.TrtyReiNmbr2)
            r1(3) = f4str(TMp.TrtyReiNmbr3)
            r1(4) = f4str(TMp.TrtyReiNmbr4)
            r1(5) = f4str(TMp.TrtyReiNmbr5)
            r1(6) = f4str(TMp.TrtyReiNmbr6)
            r1(7) = f4str(TMp.TrtyReiNmbr7)
            r1(8) = f4str(TMp.TrtyReiNmbr8)
            r1(9) = f4str(TMp.TrtyReiNmbr9)
            r1(10) = f4str(TMp.TrtyReiNmbr10)

            r2(1) = Format(f4double(TMp.TrtyReiPerc1) * 100, "###.0000")
            r2(2) = Format(f4double(TMp.TrtyReiPerc2) * 100, "###.0000")
            r2(3) = Format(f4double(TMp.TrtyReiPerc3) * 100, "###.0000")
            r2(4) = Format(f4double(TMp.TrtyReiPerc4) * 100, "###.0000")
            r2(5) = Format(f4double(TMp.TrtyReiPerc5) * 100, "###.0000")
            r2(6) = Format(f4double(TMp.TrtyReiPerc6) * 100, "###.0000")
            r2(7) = Format(f4double(TMp.TrtyReiPerc7) * 100, "###.0000")
            r2(8) = Format(f4double(TMp.TrtyReiPerc8) * 100, "###.0000")
            r2(9) = Format(f4double(TMp.TrtyReiPerc9) * 100, "###.0000")
            r2(10) = Format(f4double(TMp.TrtyReiPerc10) * 100, "###.0000")

            For X = 1 To 10
                If Trim(r1(X)) = Trim(txtReiNmbr.Text) Then
                    lstReiTrty.Items.Add(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & " " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & " " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))
                    GoTo nextrec
                End If
            Next X
nextrec:
            rc = d4skip(f3, 1)
        Next X1

        rc = d4bottom(f3)
        rc = d4unlock(f3)
    End Sub

    Private Sub txtReiNmbr_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiNmbr.Enter
        Tobj = txtReiNmbr
    End Sub

    Private Sub txtReiNmbr_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiNmbr.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Down
                txtReiName.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtReiName.Focus()

        ResetForm((KeyCode))
    End Sub

    Private Sub txtReiNmbr_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiNmbr.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiNmbr.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiNmbr_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiNmbr.KeyUp
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
                For X = 0 To cboRei.Items.Count
                    If ReiArray(X) = M Then
                        ByPassCbo = True
                        cboRei.SelectedIndex = X
                        ByPassCbo = False
                        Exit Sub
                    End If
                Next X
                ByPassCbo = True
                cboRei.SelectedIndex = 0
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtReiNmbr_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiNmbr.Leave
        Dim M As String
        Dim M1 As Short
        Dim X As Integer

        s = "   "
        Tobj = txtReiNmbr
        s = RSet(txtReiNmbr.Text, Len(s))
        For X = 1 To 3
            If Mid(s, X, 1) = " " Then Mid(s, X, 1) = "0"
        Next
        If s = "000" Then s = ""

        Tobj.Text = s
        If Len(Trim(txtReiNmbr.Text)) = 3 Then
            ReiKey = txtReiNmbr.Text
            GetReiMstRec()
            If UpdateTran Then
                UpReiMstFrmVar()
                txtReiNmbr.ReadOnly = True
            End If
            If AddTran Then
                M = txtReiNmbr.Text
                M1 = cboRei.SelectedIndex
                InitReiForm()
                AddTran = True
                txtReiNmbr.Text = M
                ByPassCbo = True
                cboRei.SelectedIndex = M1
                ByPassCbo = False
            End If
        End If
    End Sub

    Private Sub txtReiName_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiName.Enter
        Dim X As Integer

        Tobj = txtReiName


        If Len(txtReiNmbr.Text) > 0 Then
            For X = 0 To cboRei.Items.Count
                If ReiArray(X) = txtReiNmbr.Text Then
                    ByPassCbo = True
                    cboRei.SelectedIndex = X
                    ByPassCbo = False
                    Exit Sub
                End If
            Next X
            ByPassCbo = True
            cboRei.SelectedIndex = 0
            ByPassCbo = False
        End If

    End Sub

    Private Sub txtReiName_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiName.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiNmbr.Focus()
            Case Keys.Down
                txtReiAddr1.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiAddr1.Focus()
    End Sub

    Private Sub txtReiName_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiName.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiName_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiName.Leave
        Tobj = txtReiName
    End Sub

    Private Sub txtReiAddr1_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiAddr1.Enter
        Tobj = txtReiAddr1
    End Sub

    Private Sub txtReiAddr1_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiAddr1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiName.Focus()
            Case Keys.Down
                txtReiAddr2.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiAddr2.Focus()
    End Sub

    Private Sub txtReiAddr1_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiAddr1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiAddr1.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiAddr1_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiAddr1.Leave
        Tobj = txtReiAddr1
    End Sub

    Private Sub txtReiAddr2_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiAddr2.Enter
        Tobj = txtReiAddr2
    End Sub

    Private Sub txtReiAddr2_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiAddr2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiAddr1.Focus()
            Case Keys.Down
                txtReiAddr3.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiAddr3.Focus()
    End Sub

    Private Sub txtReiAddr2_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiAddr2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiAddr2.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiAddr2_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiAddr2.Leave
        Tobj = txtReiAddr2
    End Sub

    Private Sub txtReiAddr3_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiAddr3.Enter
        Tobj = txtReiAddr3
    End Sub

    Private Sub txtReiAddr3_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiAddr3.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiAddr2.Focus()
            Case Keys.Down
                txtReiPhone.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiPhone.Focus()
    End Sub

    Private Sub txtReiAddr3_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiAddr3.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiAddr3.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiAddr3_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiAddr3.Leave
        Tobj = txtReiAddr3
    End Sub

    Private Sub txtReiPhone_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPhone.Enter
        Tobj = txtReiPhone
    End Sub

    Private Sub txtReiPhone_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiPhone.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiAddr3.Focus()
            Case Keys.Down
                txtReiFax.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiFax.Focus()
    End Sub

    Private Sub txtReiPhone_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiPhone.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiPhone.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiPhone_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiPhone.Leave
        Tobj = txtReiPhone
    End Sub

    Private Sub txtReiFax_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiFax.Enter
        Tobj = txtReiFax
    End Sub

    Private Sub txtReiFax_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiFax.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtReiPhone.Focus()
            Case Keys.Down
                txtReiFein.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiFein.Focus()
    End Sub

    Private Sub txtReiFax_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiFax.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiFax.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiFax_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiFax.Leave
        Tobj = txtReiFax
    End Sub

    Private Sub txtReiFein_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiFein.Enter
        Tobj = txtReiFein
    End Sub

    Private Sub txtReiFein_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiFein.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtReiFax.Focus()
            Case Keys.Down
                txtReiNaic.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiNaic.Focus()
    End Sub

    Private Sub txtReiFein_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiFein.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiFein.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiFein_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiFein.Leave
        Tobj = txtReiFein
    End Sub

    Private Sub txtReiNaic_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiNaic.Enter
        Tobj = txtReiNaic
    End Sub

    Private Sub txtReiNaic_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiNaic.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtReiFein.Focus()
            Case Keys.Down
                txtReiLicTX.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiLicTX.Focus()
    End Sub

    Private Sub txtReiNaic_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiNaic.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiNaic.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiNaic_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiNaic.Leave
        Tobj = txtReiNaic
    End Sub

    Private Sub txtReiLicTX_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiLicTX.Enter
        Tobj = txtReiLicTX
    End Sub

    Private Sub txtReiLicTX_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiLicTX.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtReiNaic.Focus()
            Case Keys.Down
                txtReiStatus.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiStatus.Focus()
    End Sub

    Private Sub txtReiLicTX_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiLicTX.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiLicTX.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiLicTX_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiLicTX.Leave
        Tobj = txtReiLicTX
    End Sub

    Private Sub txtReiStatus_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiStatus.Enter
        Tobj = txtReiStatus
    End Sub

    Private Sub txtReiStatus_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiStatus.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtReiLicTX.Focus()
            Case Keys.Down
                txtReiDomiciled.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Or KeyCode = 114 Then txtReiDomiciled.Focus()
    End Sub

    Private Sub txtReiStatus_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiStatus.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiStatus.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiStatus_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiStatus.Leave
        Tobj = txtReiStatus
    End Sub

    Private Sub txtReiDomiciled_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiDomiciled.Enter
        Tobj = txtReiDomiciled
    End Sub

    Private Sub txtReiDomiciled_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtReiDomiciled.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            Case Keys.Up
                txtReiStatus.Focus()
            Case Keys.Down
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
        End Select

        ResetForm((KeyCode))

        If KeyCode = 13 Then
            If Len(Trim(txtReiNmbr.Text)) = 3 Then
                cmdRecAction.Visible = True
                cmdRecAction.Focus()
            End If
        End If
    End Sub

    Private Sub txtReiDomiciled_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtReiDomiciled.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtReiDomiciled.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtReiDomiciled_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtReiDomiciled.Leave
        Tobj = txtReiDomiciled
    End Sub

    Private Sub ProcessReiMstRec()
        UpReiMstVars()
        If AddTran Then AddReiMstRec()
        If UpdateTran Then UpReiMstRec()
        InitReiForm()
        txtReiNmbr.Focus()
    End Sub

    Private Sub InitReiForm()
        AddTran = False
        UpdateTran = False
        DelTran = False
        InqTran = False
        RecChanged = False
        txtReiNmbr.ReadOnly = False
        cmdRecAction.Visible = False
        fra1.Visible = False

        txReiNmbr = ""
        txReiName = ""
        txReiAddr1 = ""
        txReiAddr2 = ""
        txReiAddr3 = ""
        txReiPhone = ""
        txReiFax = ""
        txReiFein = ""
        txReiNaic = ""
        txReiDomiciled = ""
        txReiLicTX = ""
        txReiStatus = ""
        txReiHist = ""

        txtReiNmbr.Text = ""
        txtReiName.Text = ""
        txtReiAddr1.Text = ""
        txtReiAddr2.Text = ""
        txtReiAddr3.Text = ""
        txtReiPhone.Text = ""
        txtReiFax.Text = ""
        txtReiFein.Text = ""
        txtReiNaic.Text = ""
        txtReiDomiciled.Text = ""
        txtReiLicTX.Text = ""
        txtReiStatus.Text = ""
        LoadCboRei()

        ByPassCbo = True
        cboRei.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            InitReiForm()
            txtReiNmbr.Focus()
        End If
    End Sub

    Sub PageHeading()

        prtobj.Print()
        prtobj.Print()
        prtobj.Print()
        prtobj.Print(C0str)
        prtobj.Print("Reinsurer Treaty Allocation")
        prtobj.Print(Format(Today, "mmm d, yyyy") & "  " & Format(TimeOfDay, "hh:mm:ss AMPM"))
        prtobj.Print(TAB(30), Trim(txtReiNmbr.Text) & "  " & Trim(txtReiName.Text))
        prtobj.Print()

        prtobj.Print("MGA", TAB(5), "Trty", TAB(10), "Description")
        prtobj.Print(TAB(65), "Ced%", TAB(75), "Rei%")
    End Sub

    Sub PageHeading2()
        prtobj.Print(C0str)
        prtobj.Print("Reinsurer Treaty Allocation (All Reinsurers)")
        prtobj.Print(Format(Today, "mmm d, yyyy") & "  " & Format(TimeOfDay, "hh:mm:ss AMPM"))
    End Sub

    Public Sub UpReiMstFrmVar()
        txtReiNmbr.Text = txReiNmbr
        txtReiName.Text = txReiName
        txtReiAddr1.Text = txReiAddr1
        txtReiAddr2.Text = txReiAddr2
        txtReiAddr3.Text = txReiAddr3
        txtReiPhone.Text = txReiPhone
        txtReiFax.Text = txReiFax
        txtReiFein.Text = txReiFein
        txtReiNaic.Text = txReiNaic
        txtReiDomiciled.Text = txReiDomiciled
        txtReiLicTX.Text = txReiLicTX
        txtReiStatus.Text = txReiStatus
    End Sub

    Public Sub UpReiMstVars()
        txReiNmbr = txtReiNmbr.Text
        txReiName = txtReiName.Text
        txReiAddr1 = txtReiAddr1.Text
        txReiAddr2 = txtReiAddr2.Text
        txReiAddr3 = txtReiAddr3.Text
        txReiPhone = txtReiPhone.Text
        txReiFax = txtReiFax.Text
        txReiNaic = txtReiNaic.Text
        txReiDomiciled = txtReiDomiciled.Text
        txReiFein = txtReiFein.Text
        txReiLicTX = txtReiLicTX.Text
        txReiStatus = txtReiStatus.Text
    End Sub

    Sub LoadCboRei()
        X = 0
        ReDim ReiArray(d4recCount(f2) + 1)

        cboRei.Items.Clear()
        cboRei.Items.Add("Reinsurer Not Setup")

        rc = d4top(f2)
        Call d4tagSelect(f2, d4tag(f2, "K1"))
        Do Until rc = r4eof
            cboRei.Items.Add(Trim(f4str(Rp.ReiNmbr)) & "   " & Trim(f4str(Rp.ReiName)))
            X = X + 1
            ReiArray(X) = Trim(f4str(Rp.ReiNmbr))
            rc = d4skip(f2, 1)
        Loop
        If cboRei.SelectedIndex > -1 Then cboRei.SelectedIndex = 0
        rc = d4bottom(f2)
        rc = d4unlock(f2)
    End Sub

    Private Sub ReiPrtAll()
        Dim X1 As Integer
        Dim X2 As Integer
        Dim X As Integer
        Dim ReiActive As Boolean

        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub
        For Each Me.p In Printers
            If Me.p.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.p
        Next

        X2 = 3
        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        PageHeading2()

        'Pass 1 all active reinsurers
        Call d4tagSelect(f2, d4tag(f2, "K1"))
        rc = d4top(f2) 'Rei Mst

        Do Until rc = r4eof
            Call d4tagSelect(f3, d4tag(f3, "K1")) 'Treaty Master
            rc = d4top(f3)

            ReiActive = False

            For X1 = 0 To d4recCount(f3)
                Call d4tagSelect(f4, d4tag(f4, "K1"))
                rc = d4top(f4) ' Treaty Parameter
                rc = d4seek(f4, Trim(f4str(TMp.TrtyMgaNmbr)) & Trim(f4str(TMp.TrtyNmbr)))
                If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec 'Bypass Inactive

                r1(1) = Trim(f4str(TMp.TrtyReiNmbr1))
                r1(2) = Trim(f4str(TMp.TrtyReiNmbr2))
                r1(3) = Trim(f4str(TMp.TrtyReiNmbr3))
                r1(4) = Trim(f4str(TMp.TrtyReiNmbr4))
                r1(5) = Trim(f4str(TMp.TrtyReiNmbr5))
                r1(6) = Trim(f4str(TMp.TrtyReiNmbr6))
                r1(7) = Trim(f4str(TMp.TrtyReiNmbr7))
                r1(8) = Trim(f4str(TMp.TrtyReiNmbr8))
                r1(9) = Trim(f4str(TMp.TrtyReiNmbr9))
                r1(10) = Trim(f4str(TMp.TrtyReiNmbr10))

                r2(1) = Format(f4double(TMp.TrtyReiPerc1) * 100, "###.0000")
                r2(2) = Format(f4double(TMp.TrtyReiPerc2) * 100, "###.0000")
                r2(3) = Format(f4double(TMp.TrtyReiPerc3) * 100, "###.0000")
                r2(4) = Format(f4double(TMp.TrtyReiPerc4) * 100, "###.0000")
                r2(5) = Format(f4double(TMp.TrtyReiPerc5) * 100, "###.0000")
                r2(6) = Format(f4double(TMp.TrtyReiPerc6) * 100, "###.0000")
                r2(7) = Format(f4double(TMp.TrtyReiPerc7) * 100, "###.0000")
                r2(8) = Format(f4double(TMp.TrtyReiPerc8) * 100, "###.0000")
                r2(9) = Format(f4double(TMp.TrtyReiPerc9) * 100, "###.0000")
                r2(10) = Format(f4double(TMp.TrtyReiPerc10) * 100, "###.0000")

                For X = 1 To 10
                    If Trim(r1(X)) = Trim(f4str(Rp.ReiNmbr)) Then

                        If Not ReiActive Then
                            prtobj.Print()
                            prtobj.Print("Reinsurer:  " & Trim(f4str(Rp.ReiNmbr)) & " " & Trim(f4str(Rp.ReiName)))
                            prtobj.Print("MGA", TAB(5), "Trty", TAB(10), "Description")
                            prtobj.Print(TAB(65), "Ced%", TAB(75), "Rei%")
                            X2 = X2 + 3
                            ReiActive = True
                        End If

                        X2 = X2 + 1
                        If X2 > 55 Then
                            prtobj.NewPage()
                            PageHeading2()
                            prtobj.Print()
                            X2 = 4
                        End If
                        prtobj.Print(Trim(f4str(TMp.TrtyMgaNmbr)) & " " & Trim(f4str(TMp.TrtyNmbr)) & "   " & Trim(f4str(TMp.TrtyDesc)) & Space(49 - Len(Trim(f4str(TMp.TrtyDesc)))) & "  " & Space(8 - Len(Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000"))) & Format(f4double(TMp.TrtyCedPerc) * 100, "###.0000") & "  " & Space(8 - Len(r2(X))) & r2(X))

                        GoTo nextrec
                    End If
                Next X
nextrec:
                rc = d4skip(f3, 1)
            Next X1
            rc = d4skip(f2, 1)
        Loop

        rc = d4bottom(f3)
        rc = d4unlock(f3)

        'Pass 2  All Inactive Reinsurers
        prtobj.NewPage()
        PageHeading2()
        prtobj.Print()
        X2 = 4

        Call d4tagSelect(f2, d4tag(f2, "K1"))
        rc = d4top(f2) 'Rei Mst

        Do Until rc = r4eof
            Call d4tagSelect(f3, d4tag(f3, "K1")) 'Treaty Master
            rc = d4top(f3)

            ReiActive = False

            For X1 = 0 To d4recCount(f3)
                Call d4tagSelect(f4, d4tag(f4, "K1"))
                rc = d4top(f4) ' Treaty Parameter
                rc = d4seek(f4, Trim(f4str(TMp.TrtyMgaNmbr)) & Trim(f4str(TMp.TrtyNmbr)))
                If Val(Trim(f4str(TPp.PrmStatus))) = 1 Then GoTo nextrec1 'Bypass Inactive

                r1(1) = Trim(f4str(TMp.TrtyReiNmbr1))
                r1(2) = Trim(f4str(TMp.TrtyReiNmbr2))
                r1(3) = Trim(f4str(TMp.TrtyReiNmbr3))
                r1(4) = Trim(f4str(TMp.TrtyReiNmbr4))
                r1(5) = Trim(f4str(TMp.TrtyReiNmbr5))
                r1(6) = Trim(f4str(TMp.TrtyReiNmbr6))
                r1(7) = Trim(f4str(TMp.TrtyReiNmbr7))
                r1(8) = Trim(f4str(TMp.TrtyReiNmbr8))
                r1(9) = Trim(f4str(TMp.TrtyReiNmbr9))
                r1(10) = Trim(f4str(TMp.TrtyReiNmbr10))

                For X = 1 To 10
                    If Trim(r1(X)) = Trim(f4str(Rp.ReiNmbr)) Then
                        If Not ReiActive Then ReiActive = True
                        GoTo nextrec1
                    End If
                Next X
nextrec1:
                rc = d4skip(f3, 1)
            Next X1

            If Not ReiActive Then
                X2 = X2 + 1
                If X2 > 60 Then
                    prtobj.NewPage()
                    PageHeading2()
                    prtobj.Print()
                    X2 = 4
                End If

                prtobj.Print("Reinsurer:  " & Trim(f4str(Rp.ReiNmbr)) & " ")
                prtobj.Print(Trim(f4str(Rp.ReiName)) & " **Inactive Reinsurer**")
            End If

            rc = d4skip(f2, 1)
        Loop

        rc = d4bottom(f3)
        rc = d4unlock(f3)

        prtobj.EndDoc()
    End Sub

    Private Sub ReiPrtDetail()
        If Not UpdateTran Then Exit Sub

        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.p In Printers
            If Me.p.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.p
        Next

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 1

        prtobj.Print(C0str)
        prtobj.Print("Reinsurer Detail")
        prtobj.Print(Format(Today, "mmm d, yyyy") & "  " & Format(TimeOfDay, "hh:mm:ss AMPM"))
        prtobj.Print()

        prtobj.Print("Rein Number ", TAB(15), Trim(f4str(Rp.ReiNmbr)))
        prtobj.Print()
        prtobj.Print("Rein Name   ", TAB(15), Trim(f4str(Rp.ReiName)))
        prtobj.Print("___________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Address 1   ", TAB(15), Trim(f4str(Rp.ReiAddr1)))
        prtobj.Print()
        prtobj.Print("Address 2   ", TAB(15), Trim(f4str(Rp.ReiAddr2)))
        prtobj.Print()
        prtobj.Print("Address 3   ", TAB(15), Trim(f4str(Rp.ReiAddr3)))
        prtobj.Print("___________________________________________________________________")
        prtobj.Print()
        prtobj.Print("Phone #     ", TAB(15), Trim(f4str(Rp.ReiPhone)))
        prtobj.Print()
        prtobj.Print("Fax #       ", TAB(15), Trim(f4str(Rp.ReiFax)))
        prtobj.Print()
        prtobj.Print("FEIN        ", TAB(15), Trim(f4str(Rp.ReiFein)))
        prtobj.Print("___________________________________________________________________")
        prtobj.Print()
        prtobj.Print("NAIC ", TAB(8), Trim(f4str(Rp.ReiNaic)))
        prtobj.Print(TAB(15), "Licensed In Texas?", TAB(35), Trim(f4str(Rp.ReiLicTX)))
        prtobj.Print(TAB(41), "Status", TAB(51), Trim(f4str(Rp.ReiStatus)))
        prtobj.Print()
        prtobj.Print("Domiciled    ", TAB(15), Trim(f4str(Rp.ReiDomiciled)))
        prtobj.Print("___________________________________________________________________")

        prtobj.EndDoc()
    End Sub

    Sub ReiPrtAllDetail()
        If Pdlg.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each Me.p In Printers
            If Me.p.DeviceName = Pdlg.PrinterSettings.PrinterName Then prtobj = Me.p
        Next

        prtobj.FontName = "Courier New"
        prtobj.FontSize = 10
        prtobj.FontBold = True
        prtobj.Orientation = 2


        X = 0
        PrtReiDetHd()

        rc = d4top(f2)
        Call d4tagSelect(f2, d4tag(f2, "K1"))

        Do Until rc = r4eof
            prtobj.Print(Trim(f4str(Rp.ReiNmbr)))
            prtobj.Print(TAB(5), Trim(f4str(Rp.ReiName)))
            prtobj.Print(TAB(39), Trim(f4str(Rp.ReiPhone)))
            prtobj.Print(TAB(52), Trim(f4str(Rp.ReiFax)))
            prtobj.Print(TAB(65), Trim(f4str(Rp.ReiFein)))
            prtobj.Print(TAB(77), Trim(f4str(Rp.ReiNaic)))
            prtobj.Print(TAB(89), Trim(f4str(Rp.ReiLicTX)))
            prtobj.Print(TAB(99), Trim(f4str(Rp.ReiStatus)))
            prtobj.Print(TAB(103), Trim(f4str(Rp.ReiDomiciled)))
            prtobj.Print(TAB(5), Trim(f4str(Rp.ReiAddr1)))
            prtobj.Print(TAB(5), Trim(f4str(Rp.ReiAddr2)))
            prtobj.Print(TAB(5), Trim(f4str(Rp.ReiAddr3)))
            X = X + 4
            If X > 40 Then PrtReiDetHd()
            rc = d4skip(f2, 1)
        Loop

        rc = d4bottom(f2)
        rc = d4unlock(f2)

        prtobj.EndDoc()
        prtobj.Orientation = 1

    End Sub

    Sub PrtReiDetHd()
        If X <> 0 Then prtobj.NewPage()
        prtobj.Print(C0str)
        prtobj.Print("Reinsurers Listing")
        prtobj.Print(Format(Today, "mmm d, yyyy") & "  " & Format(TimeOfDay, "hh:mm:ss AMPM"))
        prtobj.Print()
        prtobj.Print("__________________________________________________________________________________________________________________")
        prtobj.Print("Rei", TAB(5), "Name", TAB(46), "Phone", TAB(61), "Fax", TAB(71), "FEIN")
        prtobj.Print(TAB(78), "NAIC", TAB(85), "Licensed", TAB(95), "Status", TAB(103), "Place Of")
        prtobj.Print("#", TAB(5), "Address", TAB(45), "Number", TAB(58), "Number", TAB(69), "Number")
        prtobj.Print(TAB(85), "In Texas", TAB(103), "Domicile")
        prtobj.Print("__________________________________________________________________________________________________________________")
        X = 0
    End Sub

    Private Sub cmdDone_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDone.Click
        fra1.Visible = False
    End Sub
End Class