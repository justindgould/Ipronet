<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBrkEntry
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
	Public WithEvents mnuUcomments As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuL1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuUnewrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuL2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuUupdate As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuL3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuB1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUdel As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUmenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuBrkExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuBrkFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOnewrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOl2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuOupdate As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOl3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuOl4 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOdelrec As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuBrkOption As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents txtBrkEmail As System.Windows.Forms.TextBox
	Public WithEvents cmdRecAction As System.Windows.Forms.Button
	Public WithEvents txtBrkTaxId As System.Windows.Forms.TextBox
	Public WithEvents txtBrkDesc As System.Windows.Forms.TextBox
	Public WithEvents txtBrkPhone As System.Windows.Forms.TextBox
	Public WithEvents txtBrkContact As System.Windows.Forms.TextBox
	Public WithEvents txtBrkAddr2 As System.Windows.Forms.TextBox
	Public WithEvents txtBrkAddr1 As System.Windows.Forms.TextBox
	Public WithEvents txtBrkName As System.Windows.Forms.TextBox
	Public WithEvents cboBrk As System.Windows.Forms.ComboBox
	Public WithEvents txtBrkNmbr As System.Windows.Forms.TextBox
	Public WithEvents _lblB_9 As System.Windows.Forms.Label
    Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Shape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lblB_7 As System.Windows.Forms.Label
	Public WithEvents _lblB_6 As System.Windows.Forms.Label
	Public WithEvents _lblB_5 As System.Windows.Forms.Label
	Public WithEvents _lblB_4 As System.Windows.Forms.Label
	Public WithEvents _lblB_3 As System.Windows.Forms.Label
	Public WithEvents _lblB_2 As System.Windows.Forms.Label
	Public WithEvents _lblB_1 As System.Windows.Forms.Label
	Public WithEvents _lblB_0 As System.Windows.Forms.Label
    Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrkEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Shape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuUmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUcomments = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuL1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUnewrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuL2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUupdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuL3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuB1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUdel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBrkFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBrkExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBrkOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOnewrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOl2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOupdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOl3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOl4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOdelrec = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtBrkEmail = New System.Windows.Forms.TextBox()
        Me.cmdRecAction = New System.Windows.Forms.Button()
        Me.txtBrkTaxId = New System.Windows.Forms.TextBox()
        Me.txtBrkDesc = New System.Windows.Forms.TextBox()
        Me.txtBrkPhone = New System.Windows.Forms.TextBox()
        Me.txtBrkContact = New System.Windows.Forms.TextBox()
        Me.txtBrkAddr2 = New System.Windows.Forms.TextBox()
        Me.txtBrkAddr1 = New System.Windows.Forms.TextBox()
        Me.txtBrkName = New System.Windows.Forms.TextBox()
        Me.cboBrk = New System.Windows.Forms.ComboBox()
        Me.txtBrkNmbr = New System.Windows.Forms.TextBox()
        Me._lblB_9 = New System.Windows.Forms.Label()
        Me._lblB_7 = New System.Windows.Forms.Label()
        Me._lblB_6 = New System.Windows.Forms.Label()
        Me._lblB_5 = New System.Windows.Forms.Label()
        Me._lblB_4 = New System.Windows.Forms.Label()
        Me._lblB_3 = New System.Windows.Forms.Label()
        Me._lblB_2 = New System.Windows.Forms.Label()
        Me._lblB_1 = New System.Windows.Forms.Label()
        Me._lblB_0 = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line1, Me.Shape2, Me._Shape1_0})
        Me.ShapeContainer1.Size = New System.Drawing.Size(611, 454)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line1.BorderWidth = 2
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0
        Me.Line1.X2 = 608
        Me.Line1.Y1 = 0
        Me.Line1.Y2 = 0
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.SystemColors.Window
        Me.Shape2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Shape2.FillColor = System.Drawing.Color.Black
        Me.Shape2.Location = New System.Drawing.Point(8, 40)
        Me.Shape2.Name = "Shape2"
        Me.Shape2.Size = New System.Drawing.Size(593, 409)
        '
        '_Shape1_0
        '
        Me._Shape1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_0.FillColor = System.Drawing.Color.Black
        Me._Shape1_0.Location = New System.Drawing.Point(16, 48)
        Me._Shape1_0.Name = "_Shape1_0"
        Me._Shape1_0.Size = New System.Drawing.Size(577, 393)
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUmenu, Me.mnuBrkFile, Me.mnuBrkOption})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(611, 25)
        Me.MainMenu1.TabIndex = 21
        '
        'mnuUmenu
        '
        Me.mnuUmenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUcomments, Me.mnuL1, Me.mnuUnewrec, Me.mnuL2, Me.mnuUupdate, Me.mnuL3, Me.mnuB1, Me.mnuUdel})
        Me.mnuUmenu.Enabled = False
        Me.mnuUmenu.Name = "mnuUmenu"
        Me.mnuUmenu.Size = New System.Drawing.Size(58, 21)
        Me.mnuUmenu.Text = "Umenu"
        Me.mnuUmenu.Visible = False
        '
        'mnuUcomments
        '
        Me.mnuUcomments.Name = "mnuUcomments"
        Me.mnuUcomments.Size = New System.Drawing.Size(176, 22)
        Me.mnuUcomments.Text = "History/Comments"
        '
        'mnuL1
        '
        Me.mnuL1.Name = "mnuL1"
        Me.mnuL1.Size = New System.Drawing.Size(173, 6)
        '
        'mnuUnewrec
        '
        Me.mnuUnewrec.Name = "mnuUnewrec"
        Me.mnuUnewrec.Size = New System.Drawing.Size(176, 22)
        Me.mnuUnewrec.Text = "New Record"
        '
        'mnuL2
        '
        Me.mnuL2.Name = "mnuL2"
        Me.mnuL2.Size = New System.Drawing.Size(173, 6)
        '
        'mnuUupdate
        '
        Me.mnuUupdate.Name = "mnuUupdate"
        Me.mnuUupdate.Size = New System.Drawing.Size(176, 22)
        Me.mnuUupdate.Text = "Save Record"
        '
        'mnuL3
        '
        Me.mnuL3.Name = "mnuL3"
        Me.mnuL3.Size = New System.Drawing.Size(173, 6)
        '
        'mnuB1
        '
        Me.mnuB1.Name = "mnuB1"
        Me.mnuB1.Size = New System.Drawing.Size(176, 22)
        Me.mnuB1.Text = " "
        '
        'mnuUdel
        '
        Me.mnuUdel.Name = "mnuUdel"
        Me.mnuUdel.Size = New System.Drawing.Size(176, 22)
        Me.mnuUdel.Text = "Delete Record"
        '
        'mnuBrkFile
        '
        Me.mnuBrkFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBrkExit})
        Me.mnuBrkFile.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBrkFile.Name = "mnuBrkFile"
        Me.mnuBrkFile.Size = New System.Drawing.Size(39, 21)
        Me.mnuBrkFile.Text = "&File"
        '
        'mnuBrkExit
        '
        Me.mnuBrkExit.Name = "mnuBrkExit"
        Me.mnuBrkExit.Size = New System.Drawing.Size(96, 22)
        Me.mnuBrkExit.Text = "E&xit"
        '
        'mnuBrkOption
        '
        Me.mnuBrkOption.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOnewrec, Me.mnuOl2, Me.mnuOupdate, Me.mnuOl3, Me.mnuOl4, Me.mnuOdelrec})
        Me.mnuBrkOption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBrkOption.Name = "mnuBrkOption"
        Me.mnuBrkOption.Size = New System.Drawing.Size(66, 21)
        Me.mnuBrkOption.Text = "&Options"
        '
        'mnuOnewrec
        '
        Me.mnuOnewrec.Name = "mnuOnewrec"
        Me.mnuOnewrec.Size = New System.Drawing.Size(159, 22)
        Me.mnuOnewrec.Text = "&New Record"
        '
        'mnuOl2
        '
        Me.mnuOl2.Name = "mnuOl2"
        Me.mnuOl2.Size = New System.Drawing.Size(156, 6)
        '
        'mnuOupdate
        '
        Me.mnuOupdate.Name = "mnuOupdate"
        Me.mnuOupdate.Size = New System.Drawing.Size(159, 22)
        Me.mnuOupdate.Text = "&Save Record"
        '
        'mnuOl3
        '
        Me.mnuOl3.Name = "mnuOl3"
        Me.mnuOl3.Size = New System.Drawing.Size(156, 6)
        '
        'mnuOl4
        '
        Me.mnuOl4.Name = "mnuOl4"
        Me.mnuOl4.Size = New System.Drawing.Size(159, 22)
        '
        'mnuOdelrec
        '
        Me.mnuOdelrec.Name = "mnuOdelrec"
        Me.mnuOdelrec.Size = New System.Drawing.Size(159, 22)
        Me.mnuOdelrec.Text = "&Delete Record"
        '
        'txtBrkEmail
        '
        Me.txtBrkEmail.AcceptsReturn = True
        Me.txtBrkEmail.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkEmail.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkEmail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkEmail.Location = New System.Drawing.Point(152, 304)
        Me.txtBrkEmail.MaxLength = 0
        Me.txtBrkEmail.Name = "txtBrkEmail"
        Me.txtBrkEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkEmail.Size = New System.Drawing.Size(249, 26)
        Me.txtBrkEmail.TabIndex = 8
        '
        'cmdRecAction
        '
        Me.cmdRecAction.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRecAction.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRecAction.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecAction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRecAction.Location = New System.Drawing.Point(240, 384)
        Me.cmdRecAction.Name = "cmdRecAction"
        Me.cmdRecAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecAction.Size = New System.Drawing.Size(137, 25)
        Me.cmdRecAction.TabIndex = 10
        Me.cmdRecAction.Text = "Update Record"
        Me.cmdRecAction.UseVisualStyleBackColor = False
        '
        'txtBrkTaxId
        '
        Me.txtBrkTaxId.AcceptsReturn = True
        Me.txtBrkTaxId.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkTaxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkTaxId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkTaxId.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkTaxId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkTaxId.Location = New System.Drawing.Point(152, 336)
        Me.txtBrkTaxId.MaxLength = 0
        Me.txtBrkTaxId.Name = "txtBrkTaxId"
        Me.txtBrkTaxId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkTaxId.Size = New System.Drawing.Size(249, 26)
        Me.txtBrkTaxId.TabIndex = 9
        '
        'txtBrkDesc
        '
        Me.txtBrkDesc.AcceptsReturn = True
        Me.txtBrkDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkDesc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkDesc.Location = New System.Drawing.Point(152, 128)
        Me.txtBrkDesc.MaxLength = 0
        Me.txtBrkDesc.Name = "txtBrkDesc"
        Me.txtBrkDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkDesc.Size = New System.Drawing.Size(305, 26)
        Me.txtBrkDesc.TabIndex = 3
        '
        'txtBrkPhone
        '
        Me.txtBrkPhone.AcceptsReturn = True
        Me.txtBrkPhone.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkPhone.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkPhone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkPhone.Location = New System.Drawing.Point(152, 272)
        Me.txtBrkPhone.MaxLength = 0
        Me.txtBrkPhone.Name = "txtBrkPhone"
        Me.txtBrkPhone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkPhone.Size = New System.Drawing.Size(249, 26)
        Me.txtBrkPhone.TabIndex = 7
        '
        'txtBrkContact
        '
        Me.txtBrkContact.AcceptsReturn = True
        Me.txtBrkContact.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkContact.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkContact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkContact.Location = New System.Drawing.Point(152, 232)
        Me.txtBrkContact.MaxLength = 0
        Me.txtBrkContact.Name = "txtBrkContact"
        Me.txtBrkContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkContact.Size = New System.Drawing.Size(305, 26)
        Me.txtBrkContact.TabIndex = 6
        '
        'txtBrkAddr2
        '
        Me.txtBrkAddr2.AcceptsReturn = True
        Me.txtBrkAddr2.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkAddr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkAddr2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkAddr2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkAddr2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkAddr2.Location = New System.Drawing.Point(152, 200)
        Me.txtBrkAddr2.MaxLength = 0
        Me.txtBrkAddr2.Name = "txtBrkAddr2"
        Me.txtBrkAddr2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkAddr2.Size = New System.Drawing.Size(305, 26)
        Me.txtBrkAddr2.TabIndex = 5
        '
        'txtBrkAddr1
        '
        Me.txtBrkAddr1.AcceptsReturn = True
        Me.txtBrkAddr1.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkAddr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkAddr1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkAddr1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkAddr1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkAddr1.Location = New System.Drawing.Point(152, 168)
        Me.txtBrkAddr1.MaxLength = 0
        Me.txtBrkAddr1.Name = "txtBrkAddr1"
        Me.txtBrkAddr1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkAddr1.Size = New System.Drawing.Size(305, 26)
        Me.txtBrkAddr1.TabIndex = 4
        '
        'txtBrkName
        '
        Me.txtBrkName.AcceptsReturn = True
        Me.txtBrkName.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkName.Location = New System.Drawing.Point(152, 88)
        Me.txtBrkName.MaxLength = 0
        Me.txtBrkName.Name = "txtBrkName"
        Me.txtBrkName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkName.Size = New System.Drawing.Size(305, 26)
        Me.txtBrkName.TabIndex = 2
        '
        'cboBrk
        '
        Me.cboBrk.BackColor = System.Drawing.SystemColors.Window
        Me.cboBrk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboBrk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBrk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBrk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBrk.Location = New System.Drawing.Point(224, 56)
        Me.cboBrk.Name = "cboBrk"
        Me.cboBrk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboBrk.Size = New System.Drawing.Size(297, 24)
        Me.cboBrk.TabIndex = 11
        '
        'txtBrkNmbr
        '
        Me.txtBrkNmbr.AcceptsReturn = True
        Me.txtBrkNmbr.BackColor = System.Drawing.SystemColors.Window
        Me.txtBrkNmbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrkNmbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBrkNmbr.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrkNmbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBrkNmbr.Location = New System.Drawing.Point(152, 56)
        Me.txtBrkNmbr.MaxLength = 0
        Me.txtBrkNmbr.Name = "txtBrkNmbr"
        Me.txtBrkNmbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBrkNmbr.Size = New System.Drawing.Size(57, 26)
        Me.txtBrkNmbr.TabIndex = 1
        Me.txtBrkNmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_lblB_9
        '
        Me._lblB_9.BackColor = System.Drawing.Color.Transparent
        Me._lblB_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_9.Location = New System.Drawing.Point(40, 308)
        Me._lblB_9.Name = "_lblB_9"
        Me._lblB_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_9.Size = New System.Drawing.Size(81, 17)
        Me._lblB_9.TabIndex = 19
        Me._lblB_9.Text = "Email Addr"
        '
        '_lblB_7
        '
        Me._lblB_7.BackColor = System.Drawing.Color.Transparent
        Me._lblB_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_7.Location = New System.Drawing.Point(40, 340)
        Me._lblB_7.Name = "_lblB_7"
        Me._lblB_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_7.Size = New System.Drawing.Size(57, 17)
        Me._lblB_7.TabIndex = 18
        Me._lblB_7.Text = "Tax ID"
        '
        '_lblB_6
        '
        Me._lblB_6.BackColor = System.Drawing.Color.Transparent
        Me._lblB_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_6.Location = New System.Drawing.Point(40, 132)
        Me._lblB_6.Name = "_lblB_6"
        Me._lblB_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_6.Size = New System.Drawing.Size(49, 17)
        Me._lblB_6.TabIndex = 17
        Me._lblB_6.Text = "Desc"
        '
        '_lblB_5
        '
        Me._lblB_5.BackColor = System.Drawing.Color.Transparent
        Me._lblB_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_5.Location = New System.Drawing.Point(40, 276)
        Me._lblB_5.Name = "_lblB_5"
        Me._lblB_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_5.Size = New System.Drawing.Size(73, 17)
        Me._lblB_5.TabIndex = 16
        Me._lblB_5.Text = "Phone #"
        '
        '_lblB_4
        '
        Me._lblB_4.BackColor = System.Drawing.Color.Transparent
        Me._lblB_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_4.Location = New System.Drawing.Point(40, 236)
        Me._lblB_4.Name = "_lblB_4"
        Me._lblB_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_4.Size = New System.Drawing.Size(73, 17)
        Me._lblB_4.TabIndex = 15
        Me._lblB_4.Text = "Contact"
        '
        '_lblB_3
        '
        Me._lblB_3.BackColor = System.Drawing.Color.Transparent
        Me._lblB_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_3.Location = New System.Drawing.Point(40, 204)
        Me._lblB_3.Name = "_lblB_3"
        Me._lblB_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_3.Size = New System.Drawing.Size(73, 17)
        Me._lblB_3.TabIndex = 14
        Me._lblB_3.Text = "Address 2"
        '
        '_lblB_2
        '
        Me._lblB_2.BackColor = System.Drawing.Color.Transparent
        Me._lblB_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_2.Location = New System.Drawing.Point(40, 172)
        Me._lblB_2.Name = "_lblB_2"
        Me._lblB_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_2.Size = New System.Drawing.Size(73, 17)
        Me._lblB_2.TabIndex = 13
        Me._lblB_2.Text = "Address 1"
        '
        '_lblB_1
        '
        Me._lblB_1.BackColor = System.Drawing.Color.Transparent
        Me._lblB_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_1.Location = New System.Drawing.Point(40, 92)
        Me._lblB_1.Name = "_lblB_1"
        Me._lblB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_1.Size = New System.Drawing.Size(49, 17)
        Me._lblB_1.TabIndex = 12
        Me._lblB_1.Text = "Name"
        '
        '_lblB_0
        '
        Me._lblB_0.BackColor = System.Drawing.Color.Transparent
        Me._lblB_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblB_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblB_0.Location = New System.Drawing.Point(40, 60)
        Me._lblB_0.Name = "_lblB_0"
        Me._lblB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblB_0.Size = New System.Drawing.Size(113, 17)
        Me._lblB_0.TabIndex = 0
        Me._lblB_0.Text = "Broker Number"
        '
        'frmBrkEntry
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 454)
        Me.Controls.Add(Me.txtBrkEmail)
        Me.Controls.Add(Me.cmdRecAction)
        Me.Controls.Add(Me.txtBrkTaxId)
        Me.Controls.Add(Me.txtBrkDesc)
        Me.Controls.Add(Me.txtBrkPhone)
        Me.Controls.Add(Me.txtBrkContact)
        Me.Controls.Add(Me.txtBrkAddr2)
        Me.Controls.Add(Me.txtBrkAddr1)
        Me.Controls.Add(Me.txtBrkName)
        Me.Controls.Add(Me.cboBrk)
        Me.Controls.Add(Me.txtBrkNmbr)
        Me.Controls.Add(Me._lblB_9)
        Me.Controls.Add(Me._lblB_7)
        Me.Controls.Add(Me._lblB_6)
        Me.Controls.Add(Me._lblB_5)
        Me.Controls.Add(Me._lblB_4)
        Me.Controls.Add(Me._lblB_3)
        Me.Controls.Add(Me._lblB_2)
        Me.Controls.Add(Me._lblB_1)
        Me.Controls.Add(Me._lblB_0)
        Me.Controls.Add(Me.MainMenu1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(360, 35)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(627, 492)
        Me.Name = "frmBrkEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Broker Maintenance"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class