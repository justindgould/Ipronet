<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEoyReinallocPrt
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
	Public WithEvents optPrtSumYes As System.Windows.Forms.RadioButton
	Public WithEvents optPrtSumNo As System.Windows.Forms.RadioButton
	Public WithEvents fra3 As System.Windows.Forms.Panel
	Public WithEvents optByRein As System.Windows.Forms.RadioButton
	Public WithEvents optByMga As System.Windows.Forms.RadioButton
	Public WithEvents fra2 As System.Windows.Forms.Panel
	Public WithEvents optSuppa As System.Windows.Forms.RadioButton
	Public WithEvents optPrtAging As System.Windows.Forms.RadioButton
	Public WithEvents optPrtReinRpts As System.Windows.Forms.RadioButton
	Public WithEvents optPrtReinBals As System.Windows.Forms.RadioButton
	Public WithEvents optPrtCeded As System.Windows.Forms.RadioButton
	Public WithEvents fra1 As System.Windows.Forms.Panel
	Public WithEvents cmdPrt As System.Windows.Forms.Button
	Public WithEvents txtTrtyNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents _lbl1_2 As System.Windows.Forms.Label
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEoyReinallocPrt))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.fra3 = New System.Windows.Forms.Panel()
        Me.optPrtSumYes = New System.Windows.Forms.RadioButton()
        Me.optPrtSumNo = New System.Windows.Forms.RadioButton()
        Me.fra2 = New System.Windows.Forms.Panel()
        Me.optByRein = New System.Windows.Forms.RadioButton()
        Me.optByMga = New System.Windows.Forms.RadioButton()
        Me.fra1 = New System.Windows.Forms.Panel()
        Me.optSuppa = New System.Windows.Forms.RadioButton()
        Me.optPrtAging = New System.Windows.Forms.RadioButton()
        Me.optPrtReinRpts = New System.Windows.Forms.RadioButton()
        Me.optPrtReinBals = New System.Windows.Forms.RadioButton()
        Me.optPrtCeded = New System.Windows.Forms.RadioButton()
        Me.cmdPrt = New System.Windows.Forms.Button()
        Me.txtTrtyNmbr = New System.Windows.Forms.TextBox()
        Me.txtMgaNmbr = New System.Windows.Forms.TextBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me._lbl1_2 = New System.Windows.Forms.Label()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.fra3.SuspendLayout()
        Me.fra2.SuspendLayout()
        Me.fra1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(639, 28)
        Me.MainMenu1.TabIndex = 18
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
        'fra3
        '
        Me.fra3.BackColor = System.Drawing.Color.Transparent
        Me.fra3.Controls.Add(Me.optPrtSumYes)
        Me.fra3.Controls.Add(Me.optPrtSumNo)
        Me.fra3.Cursor = System.Windows.Forms.Cursors.Default
        Me.fra3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra3.Location = New System.Drawing.Point(457, 183)
        Me.fra3.Name = "fra3"
        Me.fra3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra3.Size = New System.Drawing.Size(122, 29)
        Me.fra3.TabIndex = 17
        '
        'optPrtSumYes
        '
        Me.optPrtSumYes.BackColor = System.Drawing.Color.Transparent
        Me.optPrtSumYes.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPrtSumYes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPrtSumYes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPrtSumYes.Location = New System.Drawing.Point(9, 9)
        Me.optPrtSumYes.Name = "optPrtSumYes"
        Me.optPrtSumYes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPrtSumYes.Size = New System.Drawing.Size(48, 19)
        Me.optPrtSumYes.TabIndex = 19
        Me.optPrtSumYes.TabStop = True
        Me.optPrtSumYes.Text = "Yes"
        Me.optPrtSumYes.UseVisualStyleBackColor = False
        '
        'optPrtSumNo
        '
        Me.optPrtSumNo.BackColor = System.Drawing.Color.Transparent
        Me.optPrtSumNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPrtSumNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPrtSumNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPrtSumNo.Location = New System.Drawing.Point(75, 9)
        Me.optPrtSumNo.Name = "optPrtSumNo"
        Me.optPrtSumNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPrtSumNo.Size = New System.Drawing.Size(48, 19)
        Me.optPrtSumNo.TabIndex = 18
        Me.optPrtSumNo.TabStop = True
        Me.optPrtSumNo.Text = "No"
        Me.optPrtSumNo.UseVisualStyleBackColor = False
        '
        'fra2
        '
        Me.fra2.BackColor = System.Drawing.Color.Transparent
        Me.fra2.Controls.Add(Me.optByRein)
        Me.fra2.Controls.Add(Me.optByMga)
        Me.fra2.Cursor = System.Windows.Forms.Cursors.Default
        Me.fra2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra2.Location = New System.Drawing.Point(28, 119)
        Me.fra2.Name = "fra2"
        Me.fra2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra2.Size = New System.Drawing.Size(160, 83)
        Me.fra2.TabIndex = 11
        '
        'optByRein
        '
        Me.optByRein.BackColor = System.Drawing.Color.Transparent
        Me.optByRein.Cursor = System.Windows.Forms.Cursors.Default
        Me.optByRein.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optByRein.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optByRein.Location = New System.Drawing.Point(9, 46)
        Me.optByRein.Name = "optByRein"
        Me.optByRein.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optByRein.Size = New System.Drawing.Size(132, 19)
        Me.optByRein.TabIndex = 13
        Me.optByRein.TabStop = True
        Me.optByRein.Text = "Print By Reinsurer"
        Me.optByRein.UseVisualStyleBackColor = False
        '
        'optByMga
        '
        Me.optByMga.BackColor = System.Drawing.Color.Transparent
        Me.optByMga.Cursor = System.Windows.Forms.Cursors.Default
        Me.optByMga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optByMga.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optByMga.Location = New System.Drawing.Point(9, 18)
        Me.optByMga.Name = "optByMga"
        Me.optByMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optByMga.Size = New System.Drawing.Size(120, 19)
        Me.optByMga.TabIndex = 12
        Me.optByMga.TabStop = True
        Me.optByMga.Text = "Print By MGA"
        Me.optByMga.UseVisualStyleBackColor = False
        '
        'fra1
        '
        Me.fra1.BackColor = System.Drawing.Color.Transparent
        Me.fra1.Controls.Add(Me.optSuppa)
        Me.fra1.Controls.Add(Me.optPrtAging)
        Me.fra1.Controls.Add(Me.optPrtReinRpts)
        Me.fra1.Controls.Add(Me.optPrtReinBals)
        Me.fra1.Controls.Add(Me.optPrtCeded)
        Me.fra1.Cursor = System.Windows.Forms.Cursors.Default
        Me.fra1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra1.Location = New System.Drawing.Point(216, 119)
        Me.fra1.Name = "fra1"
        Me.fra1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra1.Size = New System.Drawing.Size(205, 138)
        Me.fra1.TabIndex = 7
        '
        'optSuppa
        '
        Me.optSuppa.BackColor = System.Drawing.Color.Transparent
        Me.optSuppa.Cursor = System.Windows.Forms.Cursors.Default
        Me.optSuppa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSuppa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optSuppa.Location = New System.Drawing.Point(0, 110)
        Me.optSuppa.Name = "optSuppa"
        Me.optSuppa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optSuppa.Size = New System.Drawing.Size(178, 19)
        Me.optSuppa.TabIndex = 15
        Me.optSuppa.TabStop = True
        Me.optSuppa.Text = "Create Suppa Data"
        Me.optSuppa.UseVisualStyleBackColor = False
        '
        'optPrtAging
        '
        Me.optPrtAging.BackColor = System.Drawing.Color.Transparent
        Me.optPrtAging.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPrtAging.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPrtAging.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPrtAging.Location = New System.Drawing.Point(0, 82)
        Me.optPrtAging.Name = "optPrtAging"
        Me.optPrtAging.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPrtAging.Size = New System.Drawing.Size(141, 22)
        Me.optPrtAging.TabIndex = 14
        Me.optPrtAging.TabStop = True
        Me.optPrtAging.Text = "Print Aging Reports"
        Me.optPrtAging.UseVisualStyleBackColor = False
        '
        'optPrtReinRpts
        '
        Me.optPrtReinRpts.BackColor = System.Drawing.Color.Transparent
        Me.optPrtReinRpts.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPrtReinRpts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPrtReinRpts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPrtReinRpts.Location = New System.Drawing.Point(0, 55)
        Me.optPrtReinRpts.Name = "optPrtReinRpts"
        Me.optPrtReinRpts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPrtReinRpts.Size = New System.Drawing.Size(178, 19)
        Me.optPrtReinRpts.TabIndex = 10
        Me.optPrtReinRpts.TabStop = True
        Me.optPrtReinRpts.Text = "Print Reinsurance Reports"
        Me.optPrtReinRpts.UseVisualStyleBackColor = False
        '
        'optPrtReinBals
        '
        Me.optPrtReinBals.BackColor = System.Drawing.Color.Transparent
        Me.optPrtReinBals.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPrtReinBals.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPrtReinBals.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPrtReinBals.Location = New System.Drawing.Point(0, 27)
        Me.optPrtReinBals.Name = "optPrtReinBals"
        Me.optPrtReinBals.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPrtReinBals.Size = New System.Drawing.Size(178, 19)
        Me.optPrtReinBals.TabIndex = 9
        Me.optPrtReinBals.TabStop = True
        Me.optPrtReinBals.Text = "Print Payable Balances"
        Me.optPrtReinBals.UseVisualStyleBackColor = False
        '
        'optPrtCeded
        '
        Me.optPrtCeded.BackColor = System.Drawing.Color.Transparent
        Me.optPrtCeded.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPrtCeded.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPrtCeded.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPrtCeded.Location = New System.Drawing.Point(0, 0)
        Me.optPrtCeded.Name = "optPrtCeded"
        Me.optPrtCeded.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPrtCeded.Size = New System.Drawing.Size(132, 19)
        Me.optPrtCeded.TabIndex = 8
        Me.optPrtCeded.TabStop = True
        Me.optPrtCeded.Text = "Print Ceded Totals"
        Me.optPrtCeded.UseVisualStyleBackColor = False
        '
        'cmdPrt
        '
        Me.cmdPrt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrt.Location = New System.Drawing.Point(467, 229)
        Me.cmdPrt.Name = "cmdPrt"
        Me.cmdPrt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrt.Size = New System.Drawing.Size(141, 29)
        Me.cmdPrt.TabIndex = 2
        Me.cmdPrt.Text = "&Print"
        Me.cmdPrt.UseVisualStyleBackColor = False
        '
        'txtTrtyNmbr
        '
        Me.txtTrtyNmbr.AcceptsReturn = True
        Me.txtTrtyNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtTrtyNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrtyNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrtyNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrtyNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrtyNmbr.Location = New System.Drawing.Point(93, 86)
        Me.txtTrtyNmbr.MaxLength = 0
        Me.txtTrtyNmbr.Name = "txtTrtyNmbr"
        Me.txtTrtyNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrtyNmbr.Size = New System.Drawing.Size(57, 21)
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
        Me.txtMgaNmbr.Location = New System.Drawing.Point(93, 49)
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
        Me.cboTrty.Location = New System.Drawing.Point(159, 83)
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
        Me.cboMga.Location = New System.Drawing.Point(159, 46)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 3
        '
        '_lbl1_2
        '
        Me._lbl1_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_2.Location = New System.Drawing.Point(464, 142)
        Me._lbl1_2.Name = "_lbl1_2"
        Me._lbl1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_2.Size = New System.Drawing.Size(109, 38)
        Me._lbl1_2.TabIndex = 16
        Me._lbl1_2.Text = "Print Summary Totals Only"
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(28, 51)
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
        Me._lbl1_1.Location = New System.Drawing.Point(28, 88)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 5
        Me._lbl1_1.Text = "Treaty"
        '
        'frmEoyReinallocPrt
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 274)
        Me.Controls.Add(Me.fra3)
        Me.Controls.Add(Me.fra2)
        Me.Controls.Add(Me.fra1)
        Me.Controls.Add(Me.cmdPrt)
        Me.Controls.Add(Me.txtTrtyNmbr)
        Me.Controls.Add(Me.txtMgaNmbr)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me._lbl1_2)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(450, 45)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEoyReinallocPrt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Print EOY Schedule F Reinsurance Balances"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.fra3.ResumeLayout(False)
        Me.fra2.ResumeLayout(False)
        Me.fra1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class