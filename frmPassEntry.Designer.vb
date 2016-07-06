<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPassEntry
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
	Public WithEvents txtUserId As System.Windows.Forms.TextBox
	Public WithEvents cmdLogin As System.Windows.Forms.Button
	Public WithEvents txtPword As System.Windows.Forms.TextBox
	Public WithEvents _lbl1_1 As System.Windows.Forms.Label
	Public WithEvents _lbl1_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPassEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.txtPword = New System.Windows.Forms.TextBox()
        Me._lbl1_1 = New System.Windows.Forms.Label()
        Me._lbl1_0 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUserId
        '
        Me.txtUserId.AcceptsReturn = True
        Me.txtUserId.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUserId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUserId.Location = New System.Drawing.Point(177, 18)
        Me.txtUserId.MaxLength = 0
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUserId.Size = New System.Drawing.Size(169, 22)
        Me.txtUserId.TabIndex = 0
        '
        'cmdLogin
        '
        Me.cmdLogin.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLogin.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLogin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLogin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLogin.Location = New System.Drawing.Point(159, 101)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLogin.Size = New System.Drawing.Size(104, 29)
        Me.cmdLogin.TabIndex = 2
        Me.cmdLogin.Text = "&Login"
        Me.cmdLogin.UseVisualStyleBackColor = False
        '
        'txtPword
        '
        Me.txtPword.AcceptsReturn = True
        Me.txtPword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPword.Location = New System.Drawing.Point(177, 55)
        Me.txtPword.MaxLength = 10
        Me.txtPword.Name = "txtPword"
        Me.txtPword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPword.Size = New System.Drawing.Size(169, 22)
        Me.txtPword.TabIndex = 1
        '
        '_lbl1_1
        '
        Me._lbl1_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_1.Location = New System.Drawing.Point(37, 27)
        Me._lbl1_1.Name = "_lbl1_1"
        Me._lbl1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_1.Size = New System.Drawing.Size(57, 19)
        Me._lbl1_1.TabIndex = 4
        Me._lbl1_1.Text = "User ID"
        '
        '_lbl1_0
        '
        Me._lbl1_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbl1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lbl1_0.Location = New System.Drawing.Point(37, 64)
        Me._lbl1_0.Name = "_lbl1_0"
        Me._lbl1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl1_0.Size = New System.Drawing.Size(132, 19)
        Me._lbl1_0.TabIndex = 3
        Me._lbl1_0.Text = "User Password"
        '
        'frmPassEntry
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 143)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.txtPword)
        Me.Controls.Add(Me._lbl1_1)
        Me.Controls.Add(Me._lbl1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(250, 245)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPassEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MGA Report System Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class