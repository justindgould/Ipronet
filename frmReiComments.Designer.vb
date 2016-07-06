<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmReiComments
    Inherits DevExpress.XtraEditors.XtraForm
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Public WithEvents txtReiHist As System.Windows.Forms.TextBox
    Public WithEvents lblComments As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtReiHist = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(747, 28)
        Me.MainMenu1.TabIndex = 2
        '
        'mnuOptions
        '
        Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.mnuOptions.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(73, 24)
        Me.mnuOptions.Text = "&Options"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(102, 24)
        Me.mnuExit.Text = "E&xit"
        '
        'txtReiHist
        '
        Me.txtReiHist.AcceptsReturn = True
        Me.txtReiHist.BackColor = System.Drawing.SystemColors.Window
        Me.txtReiHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReiHist.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReiHist.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReiHist.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReiHist.Location = New System.Drawing.Point(34, 63)
        Me.txtReiHist.MaxLength = 0
        Me.txtReiHist.Multiline = True
        Me.txtReiHist.Name = "txtReiHist"
        Me.txtReiHist.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReiHist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReiHist.Size = New System.Drawing.Size(669, 305)
        Me.txtReiHist.TabIndex = 0
        '
        'lblComments
        '
        Me.lblComments.BackColor = System.Drawing.Color.Transparent
        Me.lblComments.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComments.Location = New System.Drawing.Point(34, 49)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblComments.Size = New System.Drawing.Size(323, 15)
        Me.lblComments.TabIndex = 1
        Me.lblComments.Text = "History / Comments"
        '
        'frmReiComments
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 404)
        Me.Controls.Add(Me.txtReiHist)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(360, 35)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReiComments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reinsuer  History / Comments"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class