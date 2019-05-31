<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentRiser
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
        Me.DocumentBtn = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.ListDGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fileuptxt
        '
        Me.Fileuptxt.Location = New System.Drawing.Point(12, 12)
        Me.Fileuptxt.Name = "Fileuptxt"
        Me.Fileuptxt.ReadOnly = True
        Me.Fileuptxt.Size = New System.Drawing.Size(218, 20)
        Me.Fileuptxt.TabIndex = 32
        '
        'Browsebtn
        '
        Me.Browsebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Browsebtn.Location = New System.Drawing.Point(236, 12)
        Me.Browsebtn.Name = "Browsebtn"
        Me.Browsebtn.Size = New System.Drawing.Size(70, 22)
        Me.Browsebtn.TabIndex = 31
        Me.Browsebtn.Text = "Browse"
        Me.Browsebtn.UseVisualStyleBackColor = True
        '
        'ListDGrid
        '
        Me.ListDGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListDGrid.Location = New System.Drawing.Point(12, 51)
        Me.ListDGrid.Name = "ListDGrid"
        Me.ListDGrid.Size = New System.Drawing.Size(452, 342)
        Me.ListDGrid.TabIndex = 33
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DocumentBtn
        '
        Me.DocumentBtn.Enabled = False
        Me.DocumentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DocumentBtn.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocumentBtn.Location = New System.Drawing.Point(415, 13)
        Me.DocumentBtn.Name = "DocumentBtn"
        Me.DocumentBtn.Size = New System.Drawing.Size(49, 22)
        Me.DocumentBtn.TabIndex = 36
        Me.DocumentBtn.Text = "اجرا"
        Me.DocumentBtn.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1-واریز", "2-برداشت"})
        Me.ComboBox1.Location = New System.Drawing.Point(312, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(97, 21)
        Me.ComboBox1.TabIndex = 37
        '
        'DocumentRiser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 440)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DocumentBtn)
        Me.Controls.Add(Me.ListDGrid)
        Me.Controls.Add(Me.Fileuptxt)
        Me.Controls.Add(Me.Browsebtn)
        Me.Name = "DocumentRiser"
        Me.Text = "DonumentRiser"
        CType(Me.ListDGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fileuptxt As System.Windows.Forms.TextBox
    Friend WithEvents Browsebtn As System.Windows.Forms.Button
    Friend WithEvents ListDGrid As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DocumentBtn As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
