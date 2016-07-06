<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEoyReinalloc
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
    Public WithEvents cmdContinue As System.Windows.Forms.Button
	Public WithEvents txtTrtyNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEoyReinalloc))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.txtTrtyNmbr = New System.Windows.Forms.TextBox()
        Me.txtMgaNmbr = New System.Windows.Forms.TextBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.cboPeriod = New System.Windows.Forms.ComboBox()
        Me.MainMenu1.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(676, 28)
        Me.MainMenu1.TabIndex = 7
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
        'cmdContinue
        '
        Me.cmdContinue.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinue.Location = New System.Drawing.Point(265, 357)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdContinue.Size = New System.Drawing.Size(141, 29)
        Me.cmdContinue.TabIndex = 2
        Me.cmdContinue.Text = "&Continue"
        Me.cmdContinue.UseVisualStyleBackColor = False
        '
        'txtTrtyNmbr
        '
        Me.txtTrtyNmbr.AcceptsReturn = True
        Me.txtTrtyNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtTrtyNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrtyNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrtyNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrtyNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrtyNmbr.Location = New System.Drawing.Point(140, 79)
        Me.txtTrtyNmbr.MaxLength = 0
        Me.txtTrtyNmbr.Name = "txtTrtyNmbr"
        Me.txtTrtyNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrtyNmbr.Size = New System.Drawing.Size(57, 22)
        Me.txtTrtyNmbr.TabIndex = 1
        Me.txtTrtyNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMgaNmbr
        '
        Me.txtMgaNmbr.AcceptsReturn = True
        Me.txtMgaNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtMgaNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMgaNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgaNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgaNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgaNmbr.Location = New System.Drawing.Point(140, 42)
        Me.txtMgaNmbr.MaxLength = 0
        Me.txtMgaNmbr.Name = "txtMgaNmbr"
        Me.txtMgaNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgaNmbr.Size = New System.Drawing.Size(57, 22)
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
        Me.cboTrty.Location = New System.Drawing.Point(205, 78)
        Me.cboTrty.Name = "cboTrty"
        Me.cboTrty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTrty.Size = New System.Drawing.Size(392, 24)
        Me.cboTrty.TabIndex = 4
        '
        'cboMga
        '
        Me.cboMga.BackColor = System.Drawing.SystemColors.Window
        Me.cboMga.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMga.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMga.Location = New System.Drawing.Point(205, 42)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 3
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(74, 45)
        Me._lbl1_0.Name = "_lbl1_0"
        Me._lbl1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_0.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_0.TabIndex = 6
        Me._lbl1_0.Text = "MGA "
        '
        '_lbl1_1
        '
        Me._lbl1_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_1.Location = New System.Drawing.Point(74, 82)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 5
        Me._lbl1_1.Text = "Treaty"
        '
        'TreeList1
        '
        Me.TreeList1.Location = New System.Drawing.Point(60, 155)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.Size = New System.Drawing.Size(560, 191)
        Me.TreeList1.TabIndex = 8
        '
        'lblPeriod
        '
        Me.lblPeriod.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriod.Location = New System.Drawing.Point(74, 116)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPeriod.Size = New System.Drawing.Size(57, 19)
        Me.lblPeriod.TabIndex = 9
        Me.lblPeriod.Text = "Period"
        '
        'cboPeriod
        '
        Me.cboPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cboPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPeriod.Items.AddRange(New Object() {"03", "06", "09", "12"})
        Me.cboPeriod.Location = New System.Drawing.Point(137, 113)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPeriod.Size = New System.Drawing.Size(60, 24)
        Me.cboPeriod.TabIndex = 10
        '
        'frmEoyReinalloc
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 405)
        Me.Controls.Add(Me.cboPeriod)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.txtTrtyNmbr)
        Me.Controls.Add(Me.txtMgaNmbr)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(26, 299)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEoyReinalloc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "(Year End) Reinsurer Ceded Allocation"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Public WithEvents lblPeriod As System.Windows.Forms.Label
    Public WithEvents cboPeriod As System.Windows.Forms.ComboBox
#End Region
End Class