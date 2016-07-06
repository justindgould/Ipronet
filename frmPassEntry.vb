Option Strict Off
Option Explicit On
Friend Class frmPassEntry
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub cmdLogin_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdLogin.Click
        Me.Close()
    End Sub
	
    Private Sub cmdLogin_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles cmdLogin.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Me.Close()
    End Sub
	
    Private Sub frmPassEntry_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        txPword = ""
        txUserId = ""
    End Sub
	
    Private Sub frmPassEntry_FormClosed(ByVal eventSender As Object, ByVal eventArgs As FormClosedEventArgs) Handles Me.FormClosed
        txPword = txtPword.Text
        txUserId = txtUserId.Text
    End Sub
	
    Private Sub txtPword_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtPword.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                txtUserId.Focus()
            Case Keys.Down
                cmdLogin.Focus()
        End Select
        If KeyCode = 13 Or KeyCode = 114 Then Me.Close()
    End Sub
	
    Private Sub txtUserId_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles txtUserId.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case Keys.Up
                cmdLogin.Focus()
            Case Keys.Down
                txtPword.Focus()
        End Select

        If KeyCode = 13 Or KeyCode = 114 Then txtPword.Focus()
    End Sub
End Class