Option Strict Off
Option Explicit On
Friend Class frmReiComments
    Private Sub frmReiComments_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        lblComments.Text = "Rein: " & Trim(frmReiEntry.txtReiNmbr.Text) & " " & "History/Comments"
        UpReiCommentFrmVar()
    End Sub

    Private Sub frmReiComments_FormClosed(ByVal eventSender As Object, ByVal eventArgs As FormClosedEventArgs) Handles Me.FormClosed
        UpReiCommentVars()
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
End Class