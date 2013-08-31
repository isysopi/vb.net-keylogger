<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm))
        Me.cmdBegin = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdEnd = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblAbout = New System.Windows.Forms.Label()
        Me.chkFile = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.logEdit = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdBegin
        '
        Me.cmdBegin.Location = New System.Drawing.Point(9, 19)
        Me.cmdBegin.Name = "cmdBegin"
        Me.cmdBegin.Size = New System.Drawing.Size(75, 23)
        Me.cmdBegin.TabIndex = 0
        Me.cmdBegin.Text = "Button1"
        Me.cmdBegin.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(19, 84)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(259, 110)
        Me.txtOutput.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdEnd)
        Me.GroupBox1.Controls.Add(Me.cmdBegin)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 49)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(178, 19)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Button2"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnd
        '
        Me.cmdEnd.Location = New System.Drawing.Point(87, 19)
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.Size = New System.Drawing.Size(75, 23)
        Me.cmdEnd.TabIndex = 1
        Me.cmdEnd.Text = "Button1"
        Me.cmdEnd.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 222)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(289, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(121, 17)
        Me.status.Text = "ToolStripStatusLabel1"
        '
        'lblAbout
        '
        Me.lblAbout.AutoSize = True
        Me.lblAbout.Location = New System.Drawing.Point(16, 68)
        Me.lblAbout.Name = "lblAbout"
        Me.lblAbout.Size = New System.Drawing.Size(39, 13)
        Me.lblAbout.TabIndex = 5
        Me.lblAbout.Text = "Label1"
        '
        'chkFile
        '
        Me.chkFile.AutoSize = True
        Me.chkFile.Checked = True
        Me.chkFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFile.Location = New System.Drawing.Point(19, 200)
        Me.chkFile.Name = "chkFile"
        Me.chkFile.Size = New System.Drawing.Size(84, 17)
        Me.chkFile.TabIndex = 8
        Me.chkFile.Text = "Save to Log"
        Me.chkFile.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.CheckFileExists = False
        Me.OpenFileDialog.CheckPathExists = False
        Me.OpenFileDialog.FileName = "C:\ntklr.sys"
        Me.OpenFileDialog.ValidateNames = False
        '
        'logEdit
        '
        Me.logEdit.Location = New System.Drawing.Point(40, 129)
        Me.logEdit.Name = "logEdit"
        Me.logEdit.Size = New System.Drawing.Size(187, 51)
        Me.logEdit.TabIndex = 10
        Me.logEdit.Text = ""
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 12000
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(106, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 34)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "dec"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 244)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.logEdit)
        Me.Controls.Add(Me.chkFile)
        Me.Controls.Add(Me.lblAbout)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.GroupBox1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdBegin As System.Windows.Forms.Button
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnd As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblAbout As System.Windows.Forms.Label
    Friend WithEvents chkFile As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents logEdit As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
