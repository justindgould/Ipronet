Option Strict Off
Option Explicit On
Friend Class frmPeriod

    Private Sub cmdRecAction_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Click
        Dim response As Object


        If Val(Mid(txtQuarter.Text, 1, 1)) <> 1 And Val(Mid(txtQuarter.Text, 1, 1)) <> 2 And Val(Mid(txtQuarter.Text, 1, 1)) <> 3 And Val(Mid(txtQuarter.Text, 1, 1)) <> 4 Then
            MsgBox("Invalid Quarter")
            txtQuarter.Focus()
            Exit Sub
        End If

        response = MsgBox("Save Record Changes", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Save Record")
        If response = MsgBoxResult.Yes Then
            UpPeriodVars()
            UpPeriodRec()
        End If

        Me.Close()
    End Sub

    Private Sub cmdRecAction_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdRecAction.Leave
        cmdRecAction.Visible = False
    End Sub

    Private Sub frmPeriod_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        OpenPeriod()
        GetPeriodRec()
        UpPeriodFrmVar()
        cmdRecAction.Visible = False
    End Sub

    Private Sub lstP1_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP2.Focus()
    End Sub

    Private Sub lstP1_Scroll()
        lstP1.SelectedIndex = lstP1.TopIndex
    End Sub

    Private Sub lstP10_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP10.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP11.Focus()
    End Sub

    Private Sub lstP11_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP11.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP12.Focus()
    End Sub

    Private Sub lstP12_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP12.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then txtYear.Focus()
    End Sub

    Private Sub lstP2_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP2.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP3.Focus()
    End Sub

    Private Sub lstP2_Scroll()
        lstP2.SelectedIndex = lstP2.TopIndex
    End Sub

    Private Sub lstP3_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP3.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP4.Focus()
    End Sub

    Private Sub lstP3_Scroll()
        lstP3.SelectedIndex = lstP3.TopIndex
    End Sub

    Private Sub lstP4_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP4.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP5.Focus()
    End Sub

    Private Sub lstP4_Scroll()
        lstP4.SelectedIndex = lstP4.TopIndex
    End Sub

    Private Sub lstP5_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP5.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP6.Focus()
    End Sub

    Private Sub lstP5_Scroll()
        lstP5.SelectedIndex = lstP5.TopIndex
    End Sub

    Private Sub lstP6_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP6.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP7.Focus()
    End Sub

    Private Sub lstP6_Scroll()
        lstP6.SelectedIndex = lstP6.TopIndex
    End Sub

    Private Sub lstP7_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP7.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP8.Focus()
    End Sub

    Private Sub lstP7_Scroll()
        lstP7.SelectedIndex = lstP7.TopIndex
    End Sub

    Private Sub lstP8_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP8.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP9.Focus()
    End Sub

    Private Sub lstP8_Scroll()
        lstP8.SelectedIndex = lstP8.TopIndex
    End Sub

    Private Sub lstP9_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles lstP9.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Or KeyCode = 114 Then lstP10.Focus()
    End Sub

    Private Sub lstP9_Scroll()
        lstP9.SelectedIndex = lstP9.TopIndex
    End Sub

    Private Sub lstP10_Scroll()
        lstP10.SelectedIndex = lstP10.TopIndex
    End Sub

    Private Sub lstP11_Scroll()
        lstP11.SelectedIndex = lstP11.TopIndex
    End Sub

    Private Sub lstP12_Scroll()
        lstP12.SelectedIndex = lstP12.TopIndex
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Public Sub mnuOupdate_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuOupdate.Click
        cmdRecAction.Visible = True
        cmdRecAction.Focus()
    End Sub

    Private Sub txtYear_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtYear.Enter
        Tobj = txtYear
    End Sub

    Private Sub txtYear_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtYear.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                lstP12.Focus()
            Case Keys.Down
                txtQuarter.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtQuarter.Focus()
    End Sub

    Private Sub txtYear_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtYear.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtYear.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtYear_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtYear.Leave
        Parry(1) = Val(txtYear.Text)
        Tobj = txtYear
    End Sub

    Private Sub txtQuarter_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtQuarter.Enter
        Tobj = txtQuarter
    End Sub

    Private Sub txtQuarter_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtQuarter.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtYear.Focus()
            Case Keys.Down
                lstP1.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then
            cmdRecAction.Visible = True
            cmdRecAction.Focus()
        End If

    End Sub

    Private Sub txtQuarter_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles txtQuarter.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If KeyAscii <> BACK_KEY Then txtQuarter.SelectionLength = 1
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtQuarter_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtQuarter.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        If Mid(txtQuarter.Text, 1, 2) <> "03" And Mid(txtQuarter.Text, 1, 2) <> "06" And Mid(txtQuarter.Text, 1, 2) <> "09" And Mid(txtQuarter.Text, 1, 2) <> "12" Then
            Exit Sub
        End If

        If Val(Mid(txtQuarter.Text, 1, 2)) = 3 Or Val(Mid(txtQuarter.Text, 1, 2)) = 6 Or Val(Mid(txtQuarter.Text, 1, 2)) = 9 Or Val(Mid(txtQuarter.Text, 1, 2)) = 12 Then
            Parry(2) = Val(Mid(txtQuarter.Text, 1, 2))
            Me.txtQuarter.Text = Trim(Str(Parry(2) / 3) & " - Period Ending " & Format(Parry(2), "0#"))
        End If
    End Sub

    Private Sub txtQuarter_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtQuarter.Leave
        Tobj = txtQuarter
    End Sub

    Sub UpPeriodVars()
        lsP1 = lstP1.SelectedIndex
        lsP2 = lstP2.SelectedIndex
        lsP3 = lstP3.SelectedIndex
        lsP4 = lstP4.SelectedIndex
        lsP5 = lstP5.SelectedIndex
        lsP6 = lstP6.SelectedIndex
        lsP7 = lstP7.SelectedIndex
        lsP8 = lstP8.SelectedIndex
        lsP9 = lstP9.SelectedIndex
        lsP10 = lstP10.SelectedIndex
        lsP11 = lstP11.SelectedIndex
        lsP12 = lstP12.SelectedIndex
        txYear = Trim(Str(Parry(1)))
        txQuarter = Trim(Str(Parry(2) / 3) & " - Period Ending " & Format(Parry(2), "0#"))
        Parry(1) = Val(txYear)
        Parry(2) = Val(Mid(txQuarter, Len(txQuarter) - 2, 3))
    End Sub

    Sub UpPeriodFrmVar()
        lstP1.SelectedIndex = lsP1
        lstP2.SelectedIndex = lsP2
        lstP3.SelectedIndex = lsP3
        lstP4.SelectedIndex = lsP4
        lstP5.SelectedIndex = lsP5
        lstP6.SelectedIndex = lsP6
        lstP7.SelectedIndex = lsP7
        lstP8.SelectedIndex = lsP8
        lstP9.SelectedIndex = lsP9
        lstP10.SelectedIndex = lsP10
        lstP11.SelectedIndex = lsP11
        lstP12.SelectedIndex = lsP12
        txtYear.Text = Format(Parry(1), "000#")
        txtQuarter.Text = Trim(Str(Parry(2) / 3) & " - Period Ending " & Format(Parry(2), "0#"))
    End Sub
End Class