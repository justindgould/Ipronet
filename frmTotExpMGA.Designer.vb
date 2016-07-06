<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTotExpMga
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
	Public WithEvents optItd As System.Windows.Forms.RadioButton
	Public WithEvents optMtd As System.Windows.Forms.RadioButton
	Public WithEvents optYtd As System.Windows.Forms.RadioButton
	Public WithEvents fraOpt As System.Windows.Forms.Panel
	Public WithEvents optTotalOnly As System.Windows.Forms.RadioButton
	Public WithEvents cmdBld As System.Windows.Forms.Button
	Public WithEvents txtTrtyNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtPeriod As System.Windows.Forms.TextBox
	Public WithEvents txtMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
	Public WithEvents _lbl1_2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTotExpMga))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraOpt = New System.Windows.Forms.Panel()
        Me.optItd = New System.Windows.Forms.RadioButton()
        Me.optMtd = New System.Windows.Forms.RadioButton()
        Me.optYtd = New System.Windows.Forms.RadioButton()
        Me.optTotalOnly = New System.Windows.Forms.RadioButton()
        Me.cmdBld = New System.Windows.Forms.Button()
        Me.txtTrtyNmbr = New System.Windows.Forms.TextBox()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.txtMgaNmbr = New System.Windows.Forms.TextBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me._lbl1_2 = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.fraOpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(548, 28)
        Me.MainMenu1.TabIndex = 13
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
        Me.mnuExit.Size = New System.Drawing.Size(152, 24)
        Me.mnuExit.Text = "E&xit"
        '
        'fraOpt
        '
        Me.fraOpt.BackColor = System.Drawing.Color.Transparent
        Me.fraOpt.Controls.Add(Me.optItd)
        Me.fraOpt.Controls.Add(Me.optMtd)
        Me.fraOpt.Controls.Add(Me.optYtd)
        Me.fraOpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraOpt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOpt.Location = New System.Drawing.Point(167, 113)
        Me.fraOpt.Name = "fraOpt"
        Me.fraOpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOpt.Size = New System.Drawing.Size(83, 74)
        Me.fraOpt.TabIndex = 12
        '
        'optItd
        '
        Me.optItd.BackColor = System.Drawing.Color.Transparent
        Me.optItd.Cursor = System.Windows.Forms.Cursors.Default
        Me.optItd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optItd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optItd.Location = New System.Drawing.Point(9, 42)
        Me.optItd.Name = "optItd"
        Me.optItd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optItd.Size = New System.Drawing.Size(57, 29)
        Me.optItd.TabIndex = 13
        Me.optItd.TabStop = True
        Me.optItd.Text = "&ITD"
        Me.optItd.UseVisualStyleBackColor = False
        '
        'optMtd
        '
        Me.optMtd.BackColor = System.Drawing.Color.Transparent
        Me.optMtd.Cursor = System.Windows.Forms.Cursors.Default
        Me.optMtd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMtd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optMtd.Location = New System.Drawing.Point(9, 0)
        Me.optMtd.Name = "optMtd"
        Me.optMtd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optMtd.Size = New System.Drawing.Size(57, 19)
        Me.optMtd.TabIndex = 3
        Me.optMtd.TabStop = True
        Me.optMtd.Text = "&MTD"
        Me.optMtd.UseVisualStyleBackColor = False
        '
        'optYtd
        '
        Me.optYtd.BackColor = System.Drawing.Color.Transparent
        Me.optYtd.Cursor = System.Windows.Forms.Cursors.Default
        Me.optYtd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optYtd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optYtd.Location = New System.Drawing.Point(9, 18)
        Me.optYtd.Name = "optYtd"
        Me.optYtd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optYtd.Size = New System.Drawing.Size(57, 29)
        Me.optYtd.TabIndex = 4
        Me.optYtd.TabStop = True
        Me.optYtd.Text = "&YTD"
        Me.optYtd.UseVisualStyleBackColor = False
        '
        'optTotalOnly
        '
        Me.optTotalOnly.BackColor = System.Drawing.Color.Transparent
        Me.optTotalOnly.Cursor = System.Windows.Forms.Cursors.Default
        Me.optTotalOnly.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTotalOnly.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optTotalOnly.Location = New System.Drawing.Point(289, 110)
        Me.optTotalOnly.Name = "optTotalOnly"
        Me.optTotalOnly.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optTotalOnly.Size = New System.Drawing.Size(63, 57)
        Me.optTotalOnly.TabIndex = 5
        Me.optTotalOnly.TabStop = True
        Me.optTotalOnly.Text = "MGA &Totals Only"
        Me.optTotalOnly.UseVisualStyleBackColor = False
        '
        'cmdBld
        '
        Me.cmdBld.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBld.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBld.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBld.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBld.Location = New System.Drawing.Point(380, 138)
        Me.cmdBld.Name = "cmdBld"
        Me.cmdBld.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBld.Size = New System.Drawing.Size(141, 29)
        Me.cmdBld.TabIndex = 6
        Me.cmdBld.Text = "&Build File"
        Me.cmdBld.UseVisualStyleBackColor = False
        '
        'txtTrtyNmbr
        '
        Me.txtTrtyNmbr.AcceptsReturn = True
        Me.txtTrtyNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtTrtyNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrtyNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrtyNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrtyNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrtyNmbr.Location = New System.Drawing.Point(75, 77)
        Me.txtTrtyNmbr.MaxLength = 0
        Me.txtTrtyNmbr.Name = "txtTrtyNmbr"
        Me.txtTrtyNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrtyNmbr.Size = New System.Drawing.Size(57, 21)
        Me.txtTrtyNmbr.TabIndex = 1
        Me.txtTrtyNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeriod
        '
        Me.txtPeriod.AcceptsReturn = True
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeriod.Location = New System.Drawing.Point(75, 113)
        Me.txtPeriod.MaxLength = 0
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeriod.Size = New System.Drawing.Size(57, 21)
        Me.txtPeriod.TabIndex = 2
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMgaNmbr
        '
        Me.txtMgaNmbr.AcceptsReturn = True
        Me.txtMgaNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtMgaNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMgaNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgaNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgaNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgaNmbr.Location = New System.Drawing.Point(75, 40)
        Me.txtMgaNmbr.MaxLength = 0
        Me.txtMgaNmbr.Name = "txtMgaNmbr"
        Me.txtMgaNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgaNmbr.Size = New System.Drawing.Size(57, 21)
        Me.txtMgaNmbr.TabIndex = 0
        Me.txtMgaNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTrty
        '
        Me.cboTrty.BackColor = System.Drawing.SystemColors.Window
        Me.cboTrty.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboTrty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTrty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTrty.Location = New System.Drawing.Point(140, 76)
        Me.cboTrty.Name = "cboTrty"
        Me.cboTrty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTrty.Size = New System.Drawing.Size(392, 24)
        Me.cboTrty.TabIndex = 8
        '
        'cboMga
        '
        Me.cboMga.BackColor = System.Drawing.SystemColors.Window
        Me.cboMga.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMga.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMga.Location = New System.Drawing.Point(140, 39)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 7
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(12, 42)
        Me._lbl1_0.Name = "_lbl1_0"
        Me._lbl1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_0.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_0.TabIndex = 11
        Me._lbl1_0.Text = "MGA "
        '
        '_lbl1_1
        '
        Me._lbl1_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_1.Location = New System.Drawing.Point(12, 79)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 10
        Me._lbl1_1.Text = "Treaty"
        '
        '_lbl1_2
        '
        Me._lbl1_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_2.Location = New System.Drawing.Point(12, 115)
        Me._lbl1_2.Name = "_lbl1_2"
        Me._lbl1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_2.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_2.TabIndex = 9
        Me._lbl1_2.Text = "Period"
        '
        'frmTotExpMga
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 219)
        Me.Controls.Add(Me.fraOpt)
        Me.Controls.Add(Me.optTotalOnly)
        Me.Controls.Add(Me.cmdBld)
        Me.Controls.Add(Me.txtTrtyNmbr)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.txtMgaNmbr)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me._lbl1_2)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(26, 299)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTotExpMga"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create TotExpMga Dir Text File"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.fraOpt.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class