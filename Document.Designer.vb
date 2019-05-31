<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Document
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
        Me.Fileuptxt = New System.Windows.Forms.TextBox()
        Me.Browsebtn = New System.Windows.Forms.Button()
        Me.ListDGrid = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ResultGrid = New System.Windows.Forms.DataGridView()
        Me.CheckFileBtn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.DocumentBtn = New System.Windows.Forms.Button()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFarazCount = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSimiaCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ListDGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResultGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fileuptxt
        '
        Me.Fileuptxt.Location = New System.Drawing.Point(12, 12)
        Me.Fileuptxt.Name = "Fileuptxt"
        Me.Fileuptxt.ReadOnly = True
        Me.Fileuptxt.Size = New System.Drawing.Size(255, 20)
        Me.Fileuptxt.TabIndex = 30
        '
        'Browsebtn
        '
        Me.Browsebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Browsebtn.Location = New System.Drawing.Point(272, 12)
        Me.Browsebtn.Name = "Browsebtn"
        Me.Browsebtn.Size = New System.Drawing.Size(95, 22)
        Me.Browsebtn.TabIndex = 29
        Me.Browsebtn.Text = "Browse"
        Me.Browsebtn.UseVisualStyleBackColor = True
        '
        'ListDGrid
        '
        Me.ListDGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListDGrid.Location = New System.Drawing.Point(12, 42)
        Me.ListDGrid.Name = "ListDGrid"
        Me.ListDGrid.Size = New System.Drawing.Size(626, 396)
        Me.ListDGrid.TabIndex = 31
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ResultGrid
        '
        Me.ResultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultGrid.Location = New System.Drawing.Point(644, 42)
        Me.ResultGrid.Name = "ResultGrid"
        Me.ResultGrid.Size = New System.Drawing.Size(587, 396)
        Me.ResultGrid.TabIndex = 32
        '
        'CheckFileBtn
        '
        Me.CheckFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckFileBtn.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckFileBtn.Location = New System.Drawing.Point(404, 13)
        Me.CheckFileBtn.Name = "CheckFileBtn"
        Me.CheckFileBtn.Size = New System.Drawing.Size(126, 22)
        Me.CheckFileBtn.TabIndex = 33
        Me.CheckFileBtn.Text = "بررسی فایل"
        Me.CheckFileBtn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(536, 13)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(615, 23)
        Me.ProgressBar1.TabIndex = 34
        '
        'DocumentBtn
        '
        Me.DocumentBtn.Enabled = False
        Me.DocumentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DocumentBtn.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocumentBtn.Location = New System.Drawing.Point(1157, 14)
        Me.DocumentBtn.Name = "DocumentBtn"
        Me.DocumentBtn.Size = New System.Drawing.Size(81, 22)
        Me.DocumentBtn.TabIndex = 35
        Me.DocumentBtn.Text = "واریز"
        Me.DocumentBtn.UseVisualStyleBackColor = True
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblPercent.Location = New System.Drawing.Point(853, 19)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(21, 13)
        Me.lblPercent.TabIndex = 36
        Me.lblPercent.Text = "0%"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Faraz"
        '
        'lblFarazCount
        '
        Me.lblFarazCount.AutoSize = True
        Me.lblFarazCount.Location = New System.Drawing.Point(45, 16)
        Me.lblFarazCount.Name = "lblFarazCount"
        Me.lblFarazCount.Size = New System.Drawing.Size(13, 13)
        Me.lblFarazCount.TabIndex = 38
        Me.lblFarazCount.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSimiaCount)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblFarazCount)
        Me.GroupBox1.Location = New System.Drawing.Point(674, 444)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 40)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'lblSimiaCount
        '
        Me.lblSimiaCount.AutoSize = True
        Me.lblSimiaCount.Location = New System.Drawing.Point(142, 16)
        Me.lblSimiaCount.Name = "lblSimiaCount"
        Me.lblSimiaCount.Size = New System.Drawing.Size(13, 13)
        Me.lblSimiaCount.TabIndex = 40
        Me.lblSimiaCount.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(103, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Simia"
        '
        'Document
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1243, 487)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.DocumentBtn)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CheckFileBtn)
        Me.Controls.Add(Me.ResultGrid)
        Me.Controls.Add(Me.ListDGrid)
        Me.Controls.Add(Me.Fileuptxt)
        Me.Controls.Add(Me.Browsebtn)
        Me.Name = "Document"
        Me.Text = "Document"
        CType(Me.ListDGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResultGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fileuptxt As System.Windows.Forms.TextBox
    Friend WithEvents Browsebtn As System.Windows.Forms.Button
    Friend WithEvents ListDGrid As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ResultGrid As System.Windows.Forms.DataGridView
    Friend WithEvents CheckFileBtn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DocumentBtn As System.Windows.Forms.Button
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFarazCount As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSimiaCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
