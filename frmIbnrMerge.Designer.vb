<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmIbnrMerge
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
	Public WithEvents txtRecCnt As System.Windows.Forms.TextBox
	Public WithEvents cmdCont As System.Windows.Forms.Button
	Public WithEvents txtPeriod As System.Windows.Forms.TextBox
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
	Public WithEvents _lbl1_2 As System.Windows.Forms.Label
    	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIbnrMerge))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtRecCnt = New System.Windows.Forms.TextBox()
        Me.cmdCont = New System.Windows.Forms.Button()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me._lbl1_2 = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MainMenu1.Size = New System.Drawing.Size(496, 28)
        Me.MainMenu1.TabIndex = 5
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
        'txtRecCnt
        '
        Me.txtRecCnt.AcceptsReturn = True
        Me.txtRecCnt.BackColor = System.Drawing.SystemColors.Window
        Me.txtRecCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecCnt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRecCnt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRecCnt.Location = New System.Drawing.Point(159, 74)
        Me.txtRecCnt.MaxLength = 0
        Me.txtRecCnt.Name = "txtRecCnt"
        Me.txtRecCnt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRecCnt.Size = New System.Drawing.Size(57, 22)
        Me.txtRecCnt.TabIndex = 3
        Me.txtRecCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdCont
        '
        Me.cmdCont.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCont.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCont.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCont.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCont.Location = New System.Drawing.Point(274, 58)
        Me.cmdCont.Name = "cmdCont"
        Me.cmdCont.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCont.Size = New System.Drawing.Size(141, 29)
        Me.cmdCont.TabIndex = 1
        Me.cmdCont.Text = "&Continue"
        Me.cmdCont.UseVisualStyleBackColor = False
        '
        'txtPeriod
        '
        Me.txtPeriod.AcceptsReturn = True
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeriod.Location = New System.Drawing.Point(159, 46)
        Me.txtPeriod.MaxLength = 0
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeriod.Size = New System.Drawing.Size(57, 22)
        Me.txtPeriod.TabIndex = 0
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(37, 77)
        Me._lbl1_0.Name = "_lbl1_0"
        Me._lbl1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_0.Size = New System.Drawing.Size(94, 19)
        Me._lbl1_0.TabIndex = 4
        Me._lbl1_0.Text = "Rec Count"
        '
        '_lbl1_2
        '
        Me._lbl1_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_2.Location = New System.Drawing.Point(37, 49)
        Me._lbl1_2.Name = "_lbl1_2"
        Me._lbl1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_2.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_2.TabIndex = 2
        Me._lbl1_2.Text = "Period"
        '
        'frmIbnrMerge
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 119)
        Me.Controls.Add(Me.txtRecCnt)
        Me.Controls.Add(Me.cmdCont)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me._lbl1_0)
        Me.Controls.Add(Me._lbl1_2)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(450, 45)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIbnrMerge"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Merge IBNR Dir and Ceded Into Direct Files"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class