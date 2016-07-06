<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEoyReinalloc3
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
	Public WithEvents txt30Day As System.Windows.Forms.TextBox
	Public WithEvents txt90Day As System.Windows.Forms.TextBox
	Public WithEvents txt120Day As System.Windows.Forms.TextBox
    Public WithEvents cmdContinue As System.Windows.Forms.Button
	Public WithEvents txtTrtyNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents _lbl1_2 As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEoyReinalloc3))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtMgaTotal = New System.Windows.Forms.TextBox()
        Me.txt30Day = New System.Windows.Forms.TextBox()
        Me.txt90Day = New System.Windows.Forms.TextBox()
        Me.txt120Day = New System.Windows.Forms.TextBox()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.txtTrtyNmbr = New System.Windows.Forms.TextBox()
        Me.txtMgaNmbr = New System.Windows.Forms.TextBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me._lbl1_2 = New System.Windows.Forms.Label()
        Me._lbl1_4 = New System.Windows.Forms.Label()
        Me._lbl1_5 = New System.Windows.Forms.Label()
        Me._lbl1_6 = New System.Windows.Forms.Label()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.MainMenu1.Size = New System.Drawing.Size(674, 28)
        Me.MainMenu1.TabIndex = 17
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
        'txtMgaTotal
        '
        Me.txtMgaTotal.AcceptsReturn = True
        Me.txtMgaTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtMgaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMgaTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgaTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgaTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgaTotal.Location = New System.Drawing.Point(159, 448)
        Me.txtMgaTotal.MaxLength = 0
        Me.txtMgaTotal.Name = "txtMgaTotal"
        Me.txtMgaTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgaTotal.Size = New System.Drawing.Size(122, 22)
        Me.txtMgaTotal.TabIndex = 11
        Me.txtMgaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt30Day
        '
        Me.txt30Day.AcceptsReturn = True
        Me.txt30Day.BackColor = System.Drawing.SystemColors.Window
        Me.txt30Day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt30Day.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt30Day.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt30Day.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt30Day.Location = New System.Drawing.Point(159, 338)
        Me.txt30Day.MaxLength = 0
        Me.txt30Day.Name = "txt30Day"
        Me.txt30Day.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt30Day.Size = New System.Drawing.Size(122, 22)
        Me.txt30Day.TabIndex = 10
        Me.txt30Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt90Day
        '
        Me.txt90Day.AcceptsReturn = True
        Me.txt90Day.BackColor = System.Drawing.SystemColors.Window
        Me.txt90Day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt90Day.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt90Day.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt90Day.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt90Day.Location = New System.Drawing.Point(159, 375)
        Me.txt90Day.MaxLength = 0
        Me.txt90Day.Name = "txt90Day"
        Me.txt90Day.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt90Day.Size = New System.Drawing.Size(122, 22)
        Me.txt90Day.TabIndex = 9
        Me.txt90Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt120Day
        '
        Me.txt120Day.AcceptsReturn = True
        Me.txt120Day.BackColor = System.Drawing.SystemColors.Window
        Me.txt120Day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt120Day.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt120Day.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt120Day.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt120Day.Location = New System.Drawing.Point(159, 411)
        Me.txt120Day.MaxLength = 0
        Me.txt120Day.Name = "txt120Day"
        Me.txt120Day.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt120Day.Size = New System.Drawing.Size(122, 22)
        Me.txt120Day.TabIndex = 8
        Me.txt120Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdContinue
        '
        Me.cmdContinue.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinue.Location = New System.Drawing.Point(364, 384)
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
        Me.txtTrtyNmbr.Location = New System.Drawing.Point(140, 77)
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
        Me.txtMgaNmbr.Location = New System.Drawing.Point(140, 40)
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
        Me.cboTrty.Location = New System.Drawing.Point(205, 76)
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
        Me.cboMga.Location = New System.Drawing.Point(205, 39)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 3
        '
        '_lbl1_2
        '
        Me._lbl1_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_2.Location = New System.Drawing.Point(75, 320)
        Me._lbl1_2.Name = "_lbl1_2"
        Me._lbl1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_2.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_2.TabIndex = 16
        Me._lbl1_2.Text = "Days"
        '
        '_lbl1_4
        '
        Me._lbl1_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_4.Location = New System.Drawing.Point(75, 340)
        Me._lbl1_4.Name = "_lbl1_4"
        Me._lbl1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_4.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_4.TabIndex = 14
        Me._lbl1_4.Text = "0 - 29 Days"
        '
        '_lbl1_5
        '
        Me._lbl1_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_5.Location = New System.Drawing.Point(75, 377)
        Me._lbl1_5.Name = "_lbl1_5"
        Me._lbl1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_5.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_5.TabIndex = 13
        Me._lbl1_5.Text = "30 - 90"
        '
        '_lbl1_6
        '
        Me._lbl1_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_6.Location = New System.Drawing.Point(75, 413)
        Me._lbl1_6.Name = "_lbl1_6"
        Me._lbl1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_6.Size = New System.Drawing.Size(66, 19)
        Me._lbl1_6.TabIndex = 12
        Me._lbl1_6.Text = "91 - 120"
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(75, 40)
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
        Me._lbl1_1.Location = New System.Drawing.Point(75, 77)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 5
        Me._lbl1_1.Text = "Treaty"
        '
        'TreeList1
        '
        Me.TreeList1.Location = New System.Drawing.Point(62, 126)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsPrint.UsePrintStyles = True
        Me.TreeList1.Size = New System.Drawing.Size(549, 191)
        Me.TreeList1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(75, 450)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Total"
        '
        'frmEoyReinalloc3
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 481)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.txtMgaTotal)
        Me.Controls.Add(Me.txt30Day)
        Me.Controls.Add(Me.txt90Day)
        Me.Controls.Add(Me.txt120Day)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.txtTrtyNmbr)
        Me.Controls.Add(Me.txtMgaNmbr)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me._lbl1_2)
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
        Me.Name = "frmEoyReinalloc3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "(Year End) Reinsurer Aging Allocation"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Public WithEvents Label1 As System.Windows.Forms.Label
#End Region 
End Class