Option Strict Off
Option Explicit On

Friend Class frmTrtyComments

    Private Sub frmTrtyComments_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        lblComments.Text = "Trty: " & Cmga & " " & Ctrty & " History/Comments"
        txtTrtyHist.Text = txTrtyHist
    End Sub

    Private Sub frmTrtyComments_FormClosed(ByVal eventSender As Object, ByVal eventArgs As FormClosedEventArgs) Handles Me.FormClosed
        txTrtyHist = txtTrtyHist.Text
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
End Class