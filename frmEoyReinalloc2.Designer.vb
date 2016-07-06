<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEoyReinalloc2
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
	Public WithEvents txtMgaTotal As System.Windows.Forms.TextBox
	Public WithEvents txtReiPay As System.Windows.Forms.TextBox
	Public WithEvents txtLossRec As System.Windows.Forms.TextBox
	Public WithEvents txtLaeRec As System.Windows.Forms.TextBox
    Public WithEvents cmdContinue As System.Windows.Forms.Button
	Public WithEvents txtTrtyNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents _lbl1_3 As System.Windows.Forms.Label
	Public WithEvents _lbl1_4 As System.Windows.Forms.Label
	Public WithEvents _lbl1_5 As System.Windows.Forms.Label
	Public WithEvents _lbl1_6 As System.Windows.Forms.Label
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEoyReinalloc2))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtMgaTotal = New System.Windows.Forms.TextBox()
        Me.txtReiPay = New System.Windows.Forms.TextBox()
        Me.txtLossRec = New System.Windows.Forms.TextBox()
        Me.txtLaeRec = New System.Windows.Forms.TextBox()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.txtTrtyNmbr = New System.Windows.Forms.TextBox()
        Me.txtMgaNmbr = New System.Windows.Forms.TextBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me._lbl1_3 = New System.Windows.Forms.Label()
        Me._lbl1_4 = New System.Windows.Forms.Label()
        Me._lbl1_5 = New System.Windows.Forms.Label()
        Me._lbl1_6 = New System.Windows.Forms.Label()
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
        Me.MainMenu1.TabIndex = 16
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
        'txtMgaTotal
        '
        Me.txtMgaTotal.AcceptsReturn = True
        Me.txtMgaTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtMgaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMgaTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgaTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgaTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgaTotal.Location = New System.Drawing.Point(215, 481)
        Me.txtMgaTotal.MaxLength = 0
        Me.txtMgaTotal.Name = "txtMgaTotal"
        Me.txtMgaTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgaTotal.Size = New System.Drawing.Size(122, 22)
        Me.txtMgaTotal.TabIndex = 11
        Me.txtMgaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReiPay
        '
        Me.txtReiPay.AcceptsReturn = True
        Me.txtReiPay.BackColor = System.Drawing.SystemColors.Window
        Me.txtReiPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReiPay.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReiPay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReiPay.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReiPay.Location = New System.Drawing.Point(215, 371)
        Me.txtReiPay.MaxLength = 0
        Me.txtReiPay.Name = "txtReiPay"
        Me.txtReiPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReiPay.Size = New System.Drawing.Size(122, 22)
        Me.txtReiPay.TabIndex = 10
        Me.txtReiPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLossRec
        '
        Me.txtLossRec.AcceptsReturn = True
        Me.txtLossRec.BackColor = System.Drawing.SystemColors.Window
        Me.txtLossRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLossRec.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLossRec.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLossRec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLossRec.Location = New System.Drawing.Point(215, 408)
        Me.txtLossRec.MaxLength = 0
        Me.txtLossRec.Name = "txtLossRec"
        Me.txtLossRec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLossRec.Size = New System.Drawing.Size(122, 22)
        Me.txtLossRec.TabIndex = 9
        Me.txtLossRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLaeRec
        '
        Me.txtLaeRec.AcceptsReturn = True
        Me.txtLaeRec.BackColor = System.Drawing.SystemColors.Window
        Me.txtLaeRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLaeRec.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLaeRec.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaeRec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLaeRec.Location = New System.Drawing.Point(215, 444)
        Me.txtLaeRec.MaxLength = 0
        Me.txtLaeRec.Name = "txtLaeRec"
        Me.txtLaeRec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLaeRec.Size = New System.Drawing.Size(122, 22)
        Me.txtLaeRec.TabIndex = 8
        Me.txtLaeRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdContinue
        '
        Me.cmdContinue.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinue.Location = New System.Drawing.Point(420, 417)
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
        Me.txtTrtyNmbr.Location = New System.Drawing.Point(140, 86)
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
        Me.txtMgaNmbr.Location = New System.Drawing.Point(140, 49)
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
        Me.cboTrty.Location = New System.Drawing.Point(205, 85)
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
        Me.cboMga.Location = New System.Drawing.Point(205, 48)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 3
        '
        '_lbl1_3
        '
        Me._lbl1_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_3.Location = New System.Drawing.Point(159, 483)
        Me._lbl1_3.Name = "_lbl1_3"
        Me._lbl1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_3.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_3.TabIndex = 15
        Me._lbl1_3.Text = "Total"
        '
        '_lbl1_4
        '
        Me._lbl1_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_4.Location = New System.Drawing.Point(75, 373)
        Me._lbl1_4.Name = "_lbl1_4"
        Me._lbl1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_4.Size = New System.Drawing.Size(113, 19)
        Me._lbl1_4.TabIndex = 14
        Me._lbl1_4.Text = "Rein Payable"
        '
        '_lbl1_5
        '
        Me._lbl1_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_5.Location = New System.Drawing.Point(75, 410)
        Me._lbl1_5.Name = "_lbl1_5"
        Me._lbl1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_5.Size = New System.Drawing.Size(141, 19)
        Me._lbl1_5.TabIndex = 13
        Me._lbl1_5.Text = "Loss Receivable"
        '
        '_lbl1_6
        '
        Me._lbl1_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_6.Location = New System.Drawing.Point(75, 446)
        Me._lbl1_6.Name = "_lbl1_6"
        Me._lbl1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_6.Size = New System.Drawing.Size(132, 19)
        Me._lbl1_6.TabIndex = 12
        Me._lbl1_6.Text = "LAE Receivable"
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(75, 51)
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
        Me._lbl1_1.Location = New System.Drawing.Point(75, 88)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 5
        Me._lbl1_1.Text = "Treaty"
        '
        'TreeList1
        '
        Me.TreeList1.Location = New System.Drawing.Point(60, 162)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.Size = New System.Drawing.Size(551, 195)
        Me.TreeList1.TabIndex = 17
        '
        'lblPeriod
        '
        Me.lblPeriod.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriod.Location = New System.Drawing.Point(75, 123)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPeriod.Size = New System.Drawing.Size(57, 19)
        Me.lblPeriod.TabIndex = 18
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
        Me.cboPeriod.Location = New System.Drawing.Point(140, 123)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPeriod.Size = New System.Drawing.Size(57, 24)
        Me.cboPeriod.TabIndex = 19
        '
        'frmEoyReinalloc2
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 522)
        Me.Controls.Add(Me.cboPeriod)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.txtMgaTotal)
        Me.Controls.Add(Me.txtReiPay)
        Me.Controls.Add(Me.txtLossRec)
        Me.Controls.Add(Me.txtLaeRec)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.txtTrtyNmbr)
        Me.Controls.Add(Me.txtMgaNmbr)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me._lbl1_3)
        Me.Controls.Add(Me._lbl1_4)
        Me.Controls.Add(Me._lbl1_5)
        Me.Controls.Add(Me._lbl1_6)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(26, 299)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEoyReinalloc2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "(Year End) Reinsurer Payable Allocation"
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