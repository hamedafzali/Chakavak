<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankList
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AllBankListview = New System.Windows.Forms.ListView()
        Me.BankName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ActiveBankListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(241, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "======>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(241, 202)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "<======"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AllBankListview
        '
        Me.AllBankListview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.BankName})
        Me.AllBankListview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllBankListview.FullRowSelect = True
        Me.AllBankListview.GridLines = True
        Me.AllBankListview.Location = New System.Drawing.Point(12, 12)
        Me.AllBankListview.Name = "AllBankListview"
        Me.AllBankListview.RightToLeftLayout = True
        Me.AllBankListview.Size = New System.Drawing.Size(209, 402)
        Me.AllBankListview.TabIndex = 27
        Me.AllBankListview.UseCompatibleStateImageBehavior = False
        '
        'BankName
        '
        Me.BankName.Text = "BankName"
        Me.BankName.Width = 300
        '
        'ActiveBankListView
        '
        Me.ActiveBankListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ActiveBankListView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActiveBankListView.FullRowSelect = True
        Me.ActiveBankListView.GridLines = True
        Me.ActiveBankListView.Location = New System.Drawing.Point(333, 12)
        Me.ActiveBankListView.Name = "ActiveBankListView"
        Me.ActiveBankListView.RightToLeftLayout = True
        Me.ActiveBankListView.Size = New System.Drawing.Size(209, 402)
        Me.ActiveBankListView.TabIndex = 28
        Me.ActiveBankListView.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "BankName"
        Me.ColumnHeader1.Width = 300
        '
        'BankList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 426)
        Me.Controls.Add(Me.ActiveBankListView)
        Me.Controls.Add(Me.AllBankListview)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "BankList"
        Me.Text = "BankList"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents AllBankListview As System.Windows.Forms.ListView
    Friend WithEvents BankName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ActiveBankListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class
