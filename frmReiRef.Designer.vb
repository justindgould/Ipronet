<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmReiRef
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
    Public WithEvents mnuReiExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuReiFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Public WithEvents cboRei As System.Windows.Forms.ComboBox
    Public WithEvents _lblM_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReiRef))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuReiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboRei = New System.Windows.Forms.ComboBox()
        Me._lblM_0 = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReiFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(611, 25)
        Me.MainMenu1.TabIndex = 2
        '
        'mnuReiFile
        '
        Me.mnuReiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReiExit})
        Me.mnuReiFile.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuReiFile.Name = "mnuReiFile"
        Me.mnuReiFile.Size = New System.Drawing.Size(39, 21)
        Me.mnuReiFile.Text = "&File"
        '
        'mnuReiExit
        '
        Me.mnuReiExit.Name = "mnuReiExit"
        Me.mnuReiExit.Size = New System.Drawing.Size(152, 22)
        Me.mnuReiExit.Text = "E&xit"
        '
        'cboRei
        '
        Me.cboRei.BackColor = System.Drawing.SystemColors.Window
        Me.cboRei.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboRei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRei.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRei.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRei.Location = New System.Drawing.Point(160, 56)
        Me.cboRei.Name = "cboRei"
        Me.cboRei.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboRei.Size = New System.Drawing.Size(297, 24)
        Me.cboRei.TabIndex = 1
        '
        '_lblM_0
        '
        Me._lblM_0.BackColor = System.Drawing.Color.Transparent
        Me._lblM_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblM_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblM_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblM_0.Location = New System.Drawing.Point(40, 64)
        Me._lblM_0.Name = "_lblM_0"
        Me._lblM_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblM_0.Size = New System.Drawing.Size(97, 17)
        Me._lblM_0.TabIndex = 0
        Me._lblM_0.Text = "Rein Number"
        '
        'frmReiRef
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 117)
        Me.Controls.Add(Me.cboRei)
        Me.Controls.Add(Me._lblM_0)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 41)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReiRef"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reinsurer Lookup"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class