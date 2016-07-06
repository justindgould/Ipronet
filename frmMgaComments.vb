Option Strict Off
Option Explicit On
Friend Class frmMgaComments
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub frmMgaComments_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        lblComments.Text = "MGA: " & Trim(frmMgaEntry.txtMgaNmbr.Text) & " " & "History/Comments"
        txtMgaHist.Text = txMgaHist
    End Sub

    Private Sub frmMgaComments_FormClosed(ByVal eventSender As Object, ByVal eventArgs As FormClosedEventArgs) Handles Me.FormClosed
        txMgaHist = txtMgaHist.Text
    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
End Class