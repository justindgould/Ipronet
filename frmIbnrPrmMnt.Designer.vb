<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmIbnrPrmMnt
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
	Public WithEvents mnuUnewrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUln1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuUupdate As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUln2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuUln3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUdelrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUmenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOexit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOfile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOprtibnr As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOrpt As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOnewrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOln1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuOupdate As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOln2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuOln3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOdelrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOoptions As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents optLaeFactors As System.Windows.Forms.RadioButton
	Public WithEvents optLossFactors As System.Windows.Forms.RadioButton
	Public WithEvents cmdRecAction As System.Windows.Forms.Button
	Public WithEvents lstIbnrPrm As System.Windows.Forms.ListBox
	Public WithEvents txtIbnrOTfact As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrCMfact As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrCBfact As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrPMfact As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrPBfact As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrYear As System.Windows.Forms.TextBox
	Public WithEvents cboMga As System.Windows.Forms.ComboBox
	Public WithEvents cboTrty As System.Windows.Forms.ComboBox
	Public WithEvents txtIbnrMgaNmbr As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrPeriod As System.Windows.Forms.TextBox
	Public WithEvents txtIbnrTrtyNmbr As System.Windows.Forms.TextBox
    Public WithEvents _lbl1_8 As System.Windows.Forms.Label
	Public WithEvents _lbl1_7 As System.Windows.Forms.Label
	Public WithEvents _lbl1_6 As System.Windows.Forms.Label
	Public WithEvents _lbl1_5 As System.Windows.Forms.Label
	Public WithEvents _lbl1_4 As System.Windows.Forms.Label
	Public WithEvents _lbl1_3 As System.Windows.Forms.Label
	Public WithEvents _lbl1_2 As System.Windows.Forms.Label
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIbnrPrmMnt))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuUmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUnewrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUln1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUupdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUln2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUln3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUdelrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOexit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrpt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOprtibnr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOoptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOnewrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOln1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOupdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOln2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOln3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOdelrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.optLaeFactors = New System.Windows.Forms.RadioButton()
        Me.optLossFactors = New System.Windows.Forms.RadioButton()
        Me.cmdRecAction = New System.Windows.Forms.Button()
        Me.lstIbnrPrm = New System.Windows.Forms.ListBox()
        Me.txtIbnrOTfact = New System.Windows.Forms.TextBox()
        Me.txtIbnrCMfact = New System.Windows.Forms.TextBox()
        Me.txtIbnrCBfact = New System.Windows.Forms.TextBox()
        Me.txtIbnrPMfact = New System.Windows.Forms.TextBox()
        Me.txtIbnrPBfact = New System.Windows.Forms.TextBox()
        Me.txtIbnrYear = New System.Windows.Forms.TextBox()
        Me.cboMga = New System.Windows.Forms.ComboBox()
        Me.cboTrty = New System.Windows.Forms.ComboBox()
        Me.txtIbnrMgaNmbr = New System.Windows.Forms.TextBox()
        Me.txtIbnrPeriod = New System.Windows.Forms.TextBox()
        Me.txtIbnrTrtyNmbr = New System.Windows.Forms.TextBox()
        Me._lbl1_8 = New System.Windows.Forms.Label()
        Me._lbl1_7 = New System.Windows.Forms.Label()
        Me._lbl1_6 = New System.Windows.Forms.Label()
        Me._lbl1_5 = New System.Windows.Forms.Label()
        Me._lbl1_4 = New System.Windows.Forms.Label()
        Me._lbl1_3 = New System.Windows.Forms.Label()
        Me._lbl1_2 = New System.Windows.Forms.Label()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUmenu, Me.mnuOfile, Me.mnuOrpt, Me.mnuOoptions})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(860, 28)
        Me.MainMenu1.TabIndex = 25
        '
        'mnuUmenu
        '
        Me.mnuUmenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUnewrec, Me.mnuUln1, Me.mnuUupdate, Me.mnuUln2, Me.mnuUln3, Me.mnuUdelrec})
        Me.mnuUmenu.Enabled = False
        Me.mnuUmenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuUmenu.Name = "mnuUmenu"
        Me.mnuUmenu.Size = New System.Drawing.Size(61, 24)
        Me.mnuUmenu.Text = "Umenu"
        Me.mnuUmenu.Visible = False
        '
        'mnuUnewrec
        '
        Me.mnuUnewrec.Name = "mnuUnewrec"
        Me.mnuUnewrec.Size = New System.Drawing.Size(159, 22)
        Me.mnuUnewrec.Text = "New Record"
        '
        'mnuUln1
        '
        Me.mnuUln1.Name = "mnuUln1"
        Me.mnuUln1.Size = New System.Drawing.Size(156, 6)
        '
        'mnuUupdate
        '
        Me.mnuUupdate.Name = "mnuUupdate"
        Me.mnuUupdate.Size = New System.Drawing.Size(159, 22)
        Me.mnuUupdate.Text = "Save Record"
        '
        'mnuUln2
        '
        Me.mnuUln2.Name = "mnuUln2"
        Me.mnuUln2.Size = New System.Drawing.Size(156, 6)
        '
        'mnuUln3
        '
        Me.mnuUln3.Name = "mnuUln3"
        Me.mnuUln3.Size = New System.Drawing.Size(159, 22)
        '
        'mnuUdelrec
        '
        Me.mnuUdelrec.Name = "mnuUdelrec"
        Me.mnuUdelrec.Size = New System.Drawing.Size(159, 22)
        Me.mnuUdelrec.Text = "Delete Record"
        '
        'mnuOfile
        '
        Me.mnuOfile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOexit})
        Me.mnuOfile.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOfile.Name = "mnuOfile"
        Me.mnuOfile.Size = New System.Drawing.Size(44, 24)
        Me.mnuOfile.Text = "&File"
        '
        'mnuOexit
        '
        Me.mnuOexit.Name = "mnuOexit"
        Me.mnuOexit.Size = New System.Drawing.Size(102, 24)
        Me.mnuOexit.Text = "E&xit"
        '
        'mnuOrpt
        '
        Me.mnuOrpt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOprtibnr})
        Me.mnuOrpt.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOrpt.Name = "mnuOrpt"
        Me.mnuOrpt.Size = New System.Drawing.Size(72, 24)
        Me.mnuOrpt.Text = "&Reports"
        '
        'mnuOprtibnr
        '
        Me.mnuOprtibnr.Name = "mnuOprtibnr"
        Me.mnuOprtibnr.Size = New System.Drawing.Size(178, 24)
        Me.mnuOprtibnr.Text = "Print Qrtly Ibnr "
        '
        'mnuOoptions
        '
        Me.mnuOoptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOnewrec, Me.mnuOln1, Me.mnuOupdate, Me.mnuOln2, Me.mnuOln3, Me.mnuOdelrec})
        Me.mnuOoptions.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOoptions.Name = "mnuOoptions"
        Me.mnuOoptions.Size = New System.Drawing.Size(73, 24)
        Me.mnuOoptions.Text = "&Options"
        '
        'mnuOnewrec
        '
        Me.mnuOnewrec.Name = "mnuOnewrec"
        Me.mnuOnewrec.Size = New System.Drawing.Size(173, 24)
        Me.mnuOnewrec.Text = "New Record"
        '
        'mnuOln1
        '
        Me.mnuOln1.Name = "mnuOln1"
        Me.mnuOln1.Size = New System.Drawing.Size(170, 6)
        '
        'mnuOupdate
        '
        Me.mnuOupdate.Name = "mnuOupdate"
        Me.mnuOupdate.Size = New System.Drawing.Size(173, 24)
        Me.mnuOupdate.Text = "Save Record"
        '
        'mnuOln2
        '
        Me.mnuOln2.Name = "mnuOln2"
        Me.mnuOln2.Size = New System.Drawing.Size(170, 6)
        '
        'mnuOln3
        '
        Me.mnuOln3.Name = "mnuOln3"
        Me.mnuOln3.Size = New System.Drawing.Size(173, 24)
        '
        'mnuOdelrec
        '
        Me.mnuOdelrec.Name = "mnuOdelrec"
        Me.mnuOdelrec.Size = New System.Drawing.Size(173, 24)
        Me.mnuOdelrec.Text = "Delete Record"
        '
        'optLaeFactors
        '
        Me.optLaeFactors.BackColor = System.Drawing.Color.Transparent
        Me.optLaeFactors.Cursor = System.Windows.Forms.Cursors.Default
        Me.optLaeFactors.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optLaeFactors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optLaeFactors.Location = New System.Drawing.Point(457, 137)
        Me.optLaeFactors.Name = "optLaeFactors"
        Me.optLaeFactors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optLaeFactors.Size = New System.Drawing.Size(132, 19)
        Me.optLaeFactors.TabIndex = 23
        Me.optLaeFactors.TabStop = True
        Me.optLaeFactors.Text = "LAE Factors"
        Me.optLaeFactors.UseVisualStyleBackColor = False
        '
        'optLossFactors
        '
        Me.optLossFactors.BackColor = System.Drawing.Color.Transparent
        Me.optLossFactors.Cursor = System.Windows.Forms.Cursors.Default
        Me.optLossFactors.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optLossFactors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optLossFactors.Location = New System.Drawing.Point(261, 137)
        Me.optLossFactors.Name = "optLossFactors"
        Me.optLossFactors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optLossFactors.Size = New System.Drawing.Size(132, 19)
        Me.optLossFactors.TabIndex = 22
        Me.optLossFactors.TabStop = True
        Me.optLossFactors.Text = "Loss Factors"
        Me.optLossFactors.UseVisualStyleBackColor = False
        '
        'cmdRecAction
        '
        Me.cmdRecAction.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRecAction.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRecAction.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecAction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRecAction.Location = New System.Drawing.Point(681, 110)
        Me.cmdRecAction.Name = "cmdRecAction"
        Me.cmdRecAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecAction.Size = New System.Drawing.Size(132, 29)
        Me.cmdRecAction.TabIndex = 9
        Me.cmdRecAction.Text = "Update Record"
        Me.cmdRecAction.UseVisualStyleBackColor = False
        '
        'lstIbnrPrm
        '
        Me.lstIbnrPrm.BackColor = System.Drawing.SystemColors.Window
        Me.lstIbnrPrm.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstIbnrPrm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstIbnrPrm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstIbnrPrm.ItemHeight = 16
        Me.lstIbnrPrm.Location = New System.Drawing.Point(121, 247)
        Me.lstIbnrPrm.Name = "lstIbnrPrm"
        Me.lstIbnrPrm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstIbnrPrm.Size = New System.Drawing.Size(626, 228)
        Me.lstIbnrPrm.TabIndex = 10
        '
        'txtIbnrOTfact
        '
        Me.txtIbnrOTfact.AcceptsReturn = True
        Me.txtIbnrOTfact.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrOTfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrOTfact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrOTfact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrOTfact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrOTfact.Location = New System.Drawing.Point(635, 219)
        Me.txtIbnrOTfact.MaxLength = 0
        Me.txtIbnrOTfact.Name = "txtIbnrOTfact"
        Me.txtIbnrOTfact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrOTfact.Size = New System.Drawing.Size(94, 22)
        Me.txtIbnrOTfact.TabIndex = 8
        Me.txtIbnrOTfact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrCMfact
        '
        Me.txtIbnrCMfact.AcceptsReturn = True
        Me.txtIbnrCMfact.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrCMfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrCMfact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrCMfact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrCMfact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrCMfact.Location = New System.Drawing.Point(532, 219)
        Me.txtIbnrCMfact.MaxLength = 0
        Me.txtIbnrCMfact.Name = "txtIbnrCMfact"
        Me.txtIbnrCMfact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrCMfact.Size = New System.Drawing.Size(94, 22)
        Me.txtIbnrCMfact.TabIndex = 7
        Me.txtIbnrCMfact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrCBfact
        '
        Me.txtIbnrCBfact.AcceptsReturn = True
        Me.txtIbnrCBfact.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrCBfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrCBfact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrCBfact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrCBfact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrCBfact.Location = New System.Drawing.Point(429, 219)
        Me.txtIbnrCBfact.MaxLength = 0
        Me.txtIbnrCBfact.Name = "txtIbnrCBfact"
        Me.txtIbnrCBfact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrCBfact.Size = New System.Drawing.Size(94, 22)
        Me.txtIbnrCBfact.TabIndex = 6
        Me.txtIbnrCBfact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrPMfact
        '
        Me.txtIbnrPMfact.AcceptsReturn = True
        Me.txtIbnrPMfact.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrPMfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrPMfact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrPMfact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrPMfact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrPMfact.Location = New System.Drawing.Point(327, 219)
        Me.txtIbnrPMfact.MaxLength = 0
        Me.txtIbnrPMfact.Name = "txtIbnrPMfact"
        Me.txtIbnrPMfact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrPMfact.Size = New System.Drawing.Size(94, 22)
        Me.txtIbnrPMfact.TabIndex = 5
        Me.txtIbnrPMfact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrPBfact
        '
        Me.txtIbnrPBfact.AcceptsReturn = True
        Me.txtIbnrPBfact.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrPBfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrPBfact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrPBfact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrPBfact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrPBfact.Location = New System.Drawing.Point(224, 219)
        Me.txtIbnrPBfact.MaxLength = 0
        Me.txtIbnrPBfact.Name = "txtIbnrPBfact"
        Me.txtIbnrPBfact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrPBfact.Size = New System.Drawing.Size(94, 22)
        Me.txtIbnrPBfact.TabIndex = 4
        Me.txtIbnrPBfact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrYear
        '
        Me.txtIbnrYear.AcceptsReturn = True
        Me.txtIbnrYear.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrYear.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrYear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrYear.Location = New System.Drawing.Point(121, 219)
        Me.txtIbnrYear.MaxLength = 0
        Me.txtIbnrYear.Name = "txtIbnrYear"
        Me.txtIbnrYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrYear.Size = New System.Drawing.Size(94, 22)
        Me.txtIbnrYear.TabIndex = 3
        Me.txtIbnrYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboMga
        '
        Me.cboMga.BackColor = System.Drawing.SystemColors.Window
        Me.cboMga.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMga.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMga.Location = New System.Drawing.Point(187, 60)
        Me.cboMga.Name = "cboMga"
        Me.cboMga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMga.Size = New System.Drawing.Size(392, 24)
        Me.cboMga.TabIndex = 11
        '
        'cboTrty
        '
        Me.cboTrty.BackColor = System.Drawing.SystemColors.Window
        Me.cboTrty.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboTrty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTrty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTrty.Location = New System.Drawing.Point(187, 94)
        Me.cboTrty.Name = "cboTrty"
        Me.cboTrty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTrty.Size = New System.Drawing.Size(392, 24)
        Me.cboTrty.TabIndex = 13
        '
        'txtIbnrMgaNmbr
        '
        Me.txtIbnrMgaNmbr.AcceptsReturn = True
        Me.txtIbnrMgaNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrMgaNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrMgaNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrMgaNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrMgaNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrMgaNmbr.Location = New System.Drawing.Point(121, 61)
        Me.txtIbnrMgaNmbr.MaxLength = 0
        Me.txtIbnrMgaNmbr.Name = "txtIbnrMgaNmbr"
        Me.txtIbnrMgaNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrMgaNmbr.Size = New System.Drawing.Size(57, 22)
        Me.txtIbnrMgaNmbr.TabIndex = 0
        Me.txtIbnrMgaNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrPeriod
        '
        Me.txtIbnrPeriod.AcceptsReturn = True
        Me.txtIbnrPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrPeriod.Location = New System.Drawing.Point(121, 134)
        Me.txtIbnrPeriod.MaxLength = 0
        Me.txtIbnrPeriod.Name = "txtIbnrPeriod"
        Me.txtIbnrPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrPeriod.Size = New System.Drawing.Size(57, 22)
        Me.txtIbnrPeriod.TabIndex = 2
        Me.txtIbnrPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIbnrTrtyNmbr
        '
        Me.txtIbnrTrtyNmbr.AcceptsReturn = True
        Me.txtIbnrTrtyNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtIbnrTrtyNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIbnrTrtyNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIbnrTrtyNmbr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIbnrTrtyNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIbnrTrtyNmbr.Location = New System.Drawing.Point(121, 97)
        Me.txtIbnrTrtyNmbr.MaxLength = 0
        Me.txtIbnrTrtyNmbr.Name = "txtIbnrTrtyNmbr"
        Me.txtIbnrTrtyNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIbnrTrtyNmbr.Size = New System.Drawing.Size(57, 22)
        Me.txtIbnrTrtyNmbr.TabIndex = 1
        Me.txtIbnrTrtyNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_lbl1_8
        '
        Me._lbl1_8.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_8.Location = New System.Drawing.Point(658, 188)
        Me._lbl1_8.Name = "_lbl1_8"
        Me._lbl1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_8.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_8.TabIndex = 21
        Me._lbl1_8.Text = "Other"
        '
        '_lbl1_7
        '
        Me._lbl1_7.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_7.Location = New System.Drawing.Point(551, 178)
        Me._lbl1_7.Name = "_lbl1_7"
        Me._lbl1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_7.Size = New System.Drawing.Size(66, 38)
        Me._lbl1_7.TabIndex = 20
        Me._lbl1_7.Text = "   CM Phydam"
        '
        '_lbl1_6
        '
        Me._lbl1_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_6.Location = New System.Drawing.Point(454, 178)
        Me._lbl1_6.Name = "_lbl1_6"
        Me._lbl1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_6.Size = New System.Drawing.Size(48, 38)
        Me._lbl1_6.TabIndex = 19
        Me._lbl1_6.Text = " CM Liab"
        '
        '_lbl1_5
        '
        Me._lbl1_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_5.Location = New System.Drawing.Point(345, 178)
        Me._lbl1_5.Name = "_lbl1_5"
        Me._lbl1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_5.Size = New System.Drawing.Size(66, 38)
        Me._lbl1_5.TabIndex = 18
        Me._lbl1_5.Text = "    PP Phydam"
        '
        '_lbl1_4
        '
        Me._lbl1_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_4.Location = New System.Drawing.Point(247, 178)
        Me._lbl1_4.Name = "_lbl1_4"
        Me._lbl1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_4.Size = New System.Drawing.Size(48, 38)
        Me._lbl1_4.TabIndex = 17
        Me._lbl1_4.Text = " PP Liab"
        '
        '_lbl1_3
        '
        Me._lbl1_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_3.Location = New System.Drawing.Point(146, 188)
        Me._lbl1_3.Name = "_lbl1_3"
        Me._lbl1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_3.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_3.TabIndex = 16
        Me._lbl1_3.Text = "Year"
        '
        '_lbl1_2
        '
        Me._lbl1_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_2.Location = New System.Drawing.Point(56, 138)
        Me._lbl1_2.Name = "_lbl1_2"
        Me._lbl1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_2.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_2.TabIndex = 15
        Me._lbl1_2.Text = "Period"
        '
        '_lbl1_1
        '
        Me._lbl1_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_1.Location = New System.Drawing.Point(56, 99)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 14
        Me._lbl1_1.Text = "Treaty"
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(56, 63)
        Me._lbl1_0.Name = "_lbl1_0"
        Me._lbl1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_0.Size = New System.Drawing.Size(48, 19)
        Me._lbl1_0.TabIndex = 12
        Me._lbl1_0.Text = "MGA "
        '
        'frmIbnrPrmMnt
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 527)
        Me.Controls.Add(Me.optLaeFactors)
        Me.Controls.Add(Me.optLossFactors)
        Me.Controls.Add(Me.cmdRecAction)
        Me.Controls.Add(Me.lstIbnrPrm)
        Me.Controls.Add(Me.txtIbnrOTfact)
        Me.Controls.Add(Me.txtIbnrCMfact)
        Me.Controls.Add(Me.txtIbnrCBfact)
        Me.Controls.Add(Me.txtIbnrPMfact)
        Me.Controls.Add(Me.txtIbnrPBfact)
        Me.Controls.Add(Me.txtIbnrYear)
        Me.Controls.Add(Me.cboMga)
        Me.Controls.Add(Me.cboTrty)
        Me.Controls.Add(Me.txtIbnrMgaNmbr)
        Me.Controls.Add(Me.txtIbnrPeriod)
        Me.Controls.Add(Me.txtIbnrTrtyNmbr)
        Me.Controls.Add(Me._lbl1_8)
        Me.Controls.Add(Me._lbl1_7)
        Me.Controls.Add(Me._lbl1_6)
        Me.Controls.Add(Me._lbl1_5)
        Me.Controls.Add(Me._lbl1_4)
        Me.Controls.Add(Me._lbl1_3)
        Me.Controls.Add(Me._lbl1_2)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(450, 45)
        Me.MaximizeBox = False
        Me.Name = "frmIbnrPrmMnt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ibnr Parameter Maintenance"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class