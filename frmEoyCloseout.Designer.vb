<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEoyCloseout
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
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEoyCloseout))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Stage1 = New System.Windows.Forms.Button()
        Me.CloseoutYear = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(426, 28)
        Me.MainMenu1.TabIndex = 15
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.mnuFile.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(44, 24)
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(102, 24)
        Me.mnuExit.Text = "E&xit"
        '
        'Stage1
        '
        Me.Stage1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Stage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Stage1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.Stage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Stage1.Location = New System.Drawing.Point(269, 56)
        Me.Stage1.Name = "Stage1"
        Me.Stage1.Size = New System.Drawing.Size(103, 37)
        Me.Stage1.TabIndex = 19
        Me.Stage1.Text = "Run Closeout"
        Me.Stage1.UseVisualStyleBackColor = False
        '
        'CloseoutYear
        '
        Me.CloseoutYear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CloseoutYear.AutoSize = True
        Me.CloseoutYear.Location = New System.Drawing.Point(56, 66)
        Me.CloseoutYear.Name = "CloseoutYear"
        Me.CloseoutYear.Size = New System.Drawing.Size(89, 16)
        Me.CloseoutYear.TabIndex = 18
        Me.CloseoutYear.Text = "Closeout Year"
        '
        'txtYear
        '
        Me.txtYear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtYear.Location = New System.Drawing.Point(164, 66)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(60, 22)
        Me.txtYear.TabIndex = 17
        '
        'frmEoyCloseout
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 148)
        Me.Controls.Add(Me.Stage1)
        Me.Controls.Add(Me.CloseoutYear)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(450, 45)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEoyCloseout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Print Schedp"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Stage1 As System.Windows.Forms.Button
	Friend WithEvents CloseoutYear As System.Windows.Forms.Label
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
#End Region
End Class