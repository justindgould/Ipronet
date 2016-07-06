Option Strict Off
Option Explicit On
Friend Class frmReiRef

    Private Sub cboRei_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRei.SelectedIndexChanged
        If ByPassCbo Then Exit Sub
        ReiKey = Mid(cboRei.Text, 1, 3)
    End Sub

    Private Sub cboRei_KeyDown(ByVal eventSender As Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboRei.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ResetForm((KeyCode))
        If KeyCode = 13 Or KeyCode = 114 Then Close()
    End Sub

    Private Sub frmReiRef_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        ReiKey = ""

        X = 0
        ReDim ReiArray(d4recCount(f2) + 1)

        Me.cboRei.Items.Clear()
        Me.cboRei.Items.Add("Reinsurer Not Setup")

        rc = d4top(f2)
        Call d4tagSelect(f2, d4tag(f2, "K1"))
        Do Until rc = r4eof
            Me.cboRei.Items.Add(Trim(f4str(Rp.ReiNmbr)) & "   " & Trim(f4str(Rp.ReiName)))
            X = X + 1
            ReiArray(X) = Trim(f4str(Rp.ReiNmbr))
            rc = d4skip(f2, 1)
        Loop
        If Me.cboRei.SelectedIndex > -1 Then cboRei.SelectedIndex = 0
        rc = d4bottom(f2)
        rc = d4unlock(f2)

        ByPassCbo = True
        cboRei.SelectedIndex = 1
        ByPassCbo = False

        s = "   "
    End Sub

    Public Sub mnuReiExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuReiExit.Click
        Close()
    End Sub

    Sub ResetForm(ByRef KeyCode As Short)
        If KeyCode = 27 Then
            Close()
        End If
    End Sub
End Class