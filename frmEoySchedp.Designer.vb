<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEoySchedp
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
	Public WithEvents optToPrinter As System.Windows.Forms.RadioButton
	Public WithEvents optToFile As System.Windows.Forms.RadioButton
	Public WithEvents fraTo As System.Windows.Forms.GroupBox
	Public WithEvents optITD As System.Windows.Forms.RadioButton
	Public WithEvents optYTD As System.Windows.Forms.RadioButton
	Public WithEvents fraFileType As System.Windows.Forms.GroupBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents txtMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtPeriod As System.Windows.Forms.TextBox
	Public WithEvents txtTrtyNmbr As System.Windows.Forms.TextBox
	Public WithEvents cmdContinue As System.Windows.Forms.Button
	Public WithEvents _lbl1_2 As System.Windows.Forms.Label
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEoySchedp))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraTo = New System.Windows.Forms.GroupBox()
        Me.optToPrinter = New System.Windows.Forms.RadioButton()
        Me.optToFile = New System.Windows.Forms.RadioButton()
        Me.fraFileType = New System.Windows.Forms.GroupBox()
        Me.optITD = New System.Windows.Forms.RadioButton()
        Me.optYTD = New System.Windows.Forms.RadioButton()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.txtMgaNmbr = New System.Windows.Forms.TextBox()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.txtTrtyNmbr = New System.Windows.Forms.TextBox()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me._lbl1_2 = New System.Windows.Forms.Label()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me.btnCreateAll = New System.Windows.Forms.Button()
        Me.MainMenu1.SuspendLayout()
        Me.fraTo.SuspendLayout()
        Me.fraFileType.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(645, 28)
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
        'fraTo
        '
        Me.fraTo.BackColor = System.Drawing.Color.Transparent
        Me.fraTo.Controls.Add(Me.optToPrinter)
        Me.fraTo.Controls.Add(Me.optToFile)
        Me.fraTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fraTo.Location = New System.Drawing.Point(289, 119)
        Me.fraTo.Name = "fraTo"
        Me.fraTo.Padding = New System.Windows.Forms.Padding(0)
        Me.fraTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraTo.Size = New System.Drawing.Size(85, 74)
        Me.fraTo.TabIndex = 9
        Me.fraTo.TabStop = False
        Me.fraTo.Text = "Send To"
        '
        'optToPrinter
        '
        Me.optToPrinter.BackColor = System.Drawing.Color.Transparent
        Me.optToPrinter.Cursor = System.Windows.Forms.Cursors.Default
        Me.optToPrinter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optToPrinter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optToPrinter.Location = New System.Drawing.Point(9, 18)
        Me.optToPrinter.Name = "optToPrinter"
        Me.optToPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optToPrinter.Size = New System.Drawing.Size(66, 19)
        Me.optToPrinter.TabIndex = 5
        Me.optToPrinter.TabStop = True
        Me.optToPrinter.Text = "Printer"
        Me.optToPrinter.UseVisualStyleBackColor = False
        '
        'optToFile
        '
        Me.optToFile.BackColor = System.Drawing.Color.Transparent
        Me.optToFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.optToFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optToFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optToFile.Location = New System.Drawing.Point(9, 46)
        Me.optToFile.Name = "optToFile"
        Me.optToFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optToFile.Size = New System.Drawing.Size(48, 19)
        Me.optToFile.TabIndex = 6
        Me.optToFile.TabStop = True
        Me.optToFile.Text = "File"
        Me.optToFile.UseVisualStyleBackColor = False
        '
        'fraFileType
        '
        Me.fraFileType.BackColor = System.Drawing.Color.Transparent
        Me.fraFileType.Controls.Add(Me.optITD)
        Me.fraFileType.Controls.Add(Me.optYTD)
        Me.fraFileType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFileType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fraFileType.Location = New System.Drawing.Point(159, 119)
        Me.fraFileType.Name = "fraFileType"
        Me.fraFileType.Padding = New System.Windows.Forms.Padding(0)
        Me.fraFileType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraFileType.Size = New System.Drawing.Size(85, 74)
        Me.fraFileType.TabIndex = 8
        Me.fraFileType.TabStop = False
        Me.fraFileType.Text = "Type"
        '
        'optITD
        '
        Me.optITD.BackColor = System.Drawing.Color.Transparent
        Me.optITD.Cursor = System.Windows.Forms.Cursors.Default
        Me.optITD.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optITD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optITD.Location = New System.Drawing.Point(9, 46)
        Me.optITD.Name = "optITD"
        Me.optITD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optITD.Size = New System.Drawing.Size(66, 19)
        Me.optITD.TabIndex = 4
        Me.optITD.TabStop = True
        Me.optITD.Text = "ITD"
        Me.optITD.UseVisualStyleBackColor = False
        '
        'optYTD
        '
        Me.optYTD.BackColor = System.Drawing.Color.Transparent
        Me.optYTD.Cursor = System.Windows.Forms.Cursors.Default
        Me.optYTD.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optYTD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optYTD.Location = New System.Drawing.Point(9, 18)
        Me.optYTD.Name = "optYTD"
        Me.optYTD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optYTD.Size = New System.Drawing.Size(57, 19)
        Me.optYTD.TabIndex = 3
        Me.optYTD.TabStop = True
        Me.optYTD.Text = "YTD"
        Me.optYTD.UseVisualStyleBackColor = False
        '
        'cboMga
        '
        Me.cboMga.BackColor = System.Drawing.Color.White
        Me.cboMga.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMga.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMga.Location = New System.Drawing.Point(149, 46)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 11
        '
        'cboTrty
        '
        Me.cboTrty.BackColor = System.Drawing.Color.White
        Me.cboTrty.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboTrty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTrty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTrty.Location = New System.Drawing.Point(150, 83)
        Me.cboTrty.Name = "cboTrty"
        Me.cboTrty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTrty.Size = New System.Drawing.Size(392, 24)
        Me.cboTrty.TabIndex = 10
        '
        'txtMgaNmbr
        '
        Me.txtMgaNmbr.AcceptsReturn = True
        Me.txtMgaNmbr.BackColor = System.Drawing.Color.White
        Me.txtMgaNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMgaNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgaNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgaNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgaNmbr.Location = New System.Drawing.Point(84, 49)
        Me.txtMgaNmbr.MaxLength = 0
        Me.txtMgaNmbr.Name = "txtMgaNmbr"
        Me.txtMgaNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgaNmbr.Size = New System.Drawing.Size(57, 22)
        Me.txtMgaNmbr.TabIndex = 0
        Me.txtMgaNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeriod
        '
        Me.txtPeriod.AcceptsReturn = True
        Me.txtPeriod.BackColor = System.Drawing.Color.White
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeriod.Location = New System.Drawing.Point(84, 146)
        Me.txtPeriod.MaxLength = 0
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeriod.Size = New System.Drawing.Size(57, 22)
        Me.txtPeriod.TabIndex = 2
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTrtyNmbr
        '
        Me.txtTrtyNmbr.AcceptsReturn = True
        Me.txtTrtyNmbr.BackColor = System.Drawing.Color.White
        Me.txtTrtyNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrtyNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrtyNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrtyNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrtyNmbr.Location = New System.Drawing.Point(84, 86)
        Me.txtTrtyNmbr.MaxLength = 0
        Me.txtTrtyNmbr.Name = "txtTrtyNmbr"
        Me.txtTrtyNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrtyNmbr.Size = New System.Drawing.Size(57, 22)
        Me.txtTrtyNmbr.TabIndex = 1
        Me.txtTrtyNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdContinue
        '
        Me.cmdContinue.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinue.Location = New System.Drawing.Point(401, 124)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdContinue.Size = New System.Drawing.Size(141, 29)
        Me.cmdContinue.TabIndex = 7
        Me.cmdContinue.Text = "&Continue"
        Me.cmdContinue.UseVisualStyleBackColor = False
        '
        '_lbl1_2
        '
        Me._lbl1_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_2.Location = New System.Drawing.Point(19, 146)
        Me._lbl1_2.Name = "_lbl1_2"
        Me._lbl1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_2.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_2.TabIndex = 14
        Me._lbl1_2.Text = "Period"
        '
        '_lbl1_1
        '
        Me._lbl1_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_1.Location = New System.Drawing.Point(19, 82)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 13
        Me._lbl1_1.Text = "Treaty"
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(19, 49)
        Me._lbl1_0.Name = "_lbl1_0"
        Me._lbl1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_0.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_0.TabIndex = 12
        Me._lbl1_0.Text = "MGA "
        '
        'btnCreateAll
        '
        Me.btnCreateAll.Location = New System.Drawing.Point(401, 162)
        Me.btnCreateAll.Name = "btnCreateAll"
        Me.btnCreateAll.Size = New System.Drawing.Size(142, 30)
        Me.btnCreateAll.TabIndex = 16
        Me.btnCreateAll.Text = "Create All Text Files"
        Me.btnCreateAll.UseVisualStyleBackColor = True
        '
        'frmEoySchedp
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 209)
        Me.Controls.Add(Me.btnCreateAll)
        Me.Controls.Add(Me.fraTo)
        Me.Controls.Add(Me.fraFileType)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.txtMgaNmbr)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.txtTrtyNmbr)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me._lbl1_2)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(450, 45)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEoySchedp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Print Schedp"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.fraTo.ResumeLayout(False)
        Me.fraFileType.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreateAll As System.Windows.Forms.Button
#End Region 
End Class