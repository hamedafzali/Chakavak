<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BranchList
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
        Me.AllBankListview = New System.Windows.Forms.ListView()
        Me.BranchName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ActiveBankListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtAllBranch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtActiveBranch = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'AllBankListview
        '
        Me.AllBankListview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.BranchName})
        Me.AllBankListview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllBankListview.FullRowSelect = True
        Me.AllBankListview.GridLines = True
        Me.AllBankListview.Location = New System.Drawing.Point(12, 58)
        Me.AllBankListview.Name = "AllBankListview"
        Me.AllBankListview.RightToLeftLayout = True
        Me.AllBankListview.Size = New System.Drawing.Size(335, 402)
        Me.AllBankListview.TabIndex = 31
        Me.AllBankListview.UseCompatibleStateImageBehavior = False
        '
        'BranchName
        '
        Me.BranchName.Text = "BranchName"
        Me.BranchName.Width = 300
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(352, 229)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 23)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "<======"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(352, 179)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "======>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ActiveBankListView
        '
        Me.ActiveBankListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ActiveBankListView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActiveBankListView.FullRowSelect = True
        Me.ActiveBankListView.GridLines = True
        Me.ActiveBankListView.Location = New System.Drawing.Point(430, 58)
        Me.ActiveBankListView.Name = "ActiveBankListView"
        Me.ActiveBankListView.RightToLeftLayout = True
        Me.ActiveBankListView.Size = New System.Drawing.Size(335, 402)
        Me.ActiveBankListView.TabIndex = 32
        Me.ActiveBankListView.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "BranchName"
        Me.ColumnHeader1.Width = 300
        '
        'txtAllBranch
        '
        Me.txtAllBranch.Location = New System.Drawing.Point(66, 32)
        Me.txtAllBranch.Name = "txtAllBranch"
        Me.txtAllBranch.Size = New System.Drawing.Size(281, 20)
        Me.txtAllBranch.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Keyword"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(430, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Keyword"
        '
        'txtActiveBranch
        '
        Me.txtActiveBranch.Location = New System.Drawing.Point(484, 32)
        Me.txtActiveBranch.Name = "txtActiveBranch"
        Me.txtActiveBranch.Size = New System.Drawing.Size(281, 20)
        Me.txtActiveBranch.TabIndex = 35
        '
        'BranchList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 470)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActiveBranch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAllBranch)
        Me.Controls.Add(Me.AllBankListview)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ActiveBankListView)
        Me.Name = "BranchList"
        Me.Text = "BranchList"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AllBankListview As System.Windows.Forms.ListView
    Friend WithEvents BranchName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ActiveBankListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtAllBranch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtActiveBranch As System.Windows.Forms.TextBox
End Class
