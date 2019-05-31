<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardOperation
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
        Me.GetCardNoByAccNobtn = New System.Windows.Forms.Button()
        Me.ActivateCardbtn = New System.Windows.Forms.Button()
        Me.GetNationalCodeByCardNobtn = New System.Windows.Forms.Button()
        Me.GetCardNoByNationalCodebtn = New System.Windows.Forms.Button()
        Me.ChangeCustomerInfobtn = New System.Windows.Forms.Button()
        Me.ChangeAccNobtn = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ListDGrid = New System.Windows.Forms.DataGridView()
        Me.ResultGrid = New System.Windows.Forms.DataGridView()
        Me.Browsebtn = New System.Windows.Forms.Button()
        Me.Fileuptxt = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BtnChangeNationalCode = New System.Windows.Forms.Button()
        Me.BtnGetAcc = New System.Windows.Forms.Button()
        CType(Me.ListDGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResultGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GetCardNoByAccNobtn
        '
        Me.GetCardNoByAccNobtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GetCardNoByAccNobtn.Location = New System.Drawing.Point(771, 211)
        Me.GetCardNoByAccNobtn.Name = "GetCardNoByAccNobtn"
        Me.GetCardNoByAccNobtn.Size = New System.Drawing.Size(126, 28)
        Me.GetCardNoByAccNobtn.TabIndex = 6
        Me.GetCardNoByAccNobtn.Text = "GetCardNoByAccNo"
        Me.GetCardNoByAccNobtn.UseVisualStyleBackColor = True
        '
        'ActivateCardbtn
        '
        Me.ActivateCardbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ActivateCardbtn.Location = New System.Drawing.Point(771, 12)
        Me.ActivateCardbtn.Name = "ActivateCardbtn"
        Me.ActivateCardbtn.Size = New System.Drawing.Size(126, 40)
        Me.ActivateCardbtn.TabIndex = 7
        Me.ActivateCardbtn.Text = "Activate/Deactive Card"
        Me.ActivateCardbtn.UseVisualStyleBackColor = True
        '
        'GetNationalCodeByCardNobtn
        '
        Me.GetNationalCodeByCardNobtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GetNationalCodeByCardNobtn.Location = New System.Drawing.Point(771, 163)
        Me.GetNationalCodeByCardNobtn.Name = "GetNationalCodeByCardNobtn"
        Me.GetNationalCodeByCardNobtn.Size = New System.Drawing.Size(126, 44)
        Me.GetNationalCodeByCardNobtn.TabIndex = 8
        Me.GetNationalCodeByCardNobtn.Text = "GetNationalCodeByCardNo"
        Me.GetNationalCodeByCardNobtn.UseVisualStyleBackColor = True
        '
        'GetCardNoByNationalCodebtn
        '
        Me.GetCardNoByNationalCodebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GetCardNoByNationalCodebtn.Location = New System.Drawing.Point(771, 122)
        Me.GetCardNoByNationalCodebtn.Name = "GetCardNoByNationalCodebtn"
        Me.GetCardNoByNationalCodebtn.Size = New System.Drawing.Size(126, 38)
        Me.GetCardNoByNationalCodebtn.TabIndex = 9
        Me.GetCardNoByNationalCodebtn.Text = "GetCardNoByNationalCode"
        Me.GetCardNoByNationalCodebtn.UseVisualStyleBackColor = True
        '
        'ChangeCustomerInfobtn
        '
        Me.ChangeCustomerInfobtn.Enabled = False
        Me.ChangeCustomerInfobtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangeCustomerInfobtn.Location = New System.Drawing.Point(771, 93)
        Me.ChangeCustomerInfobtn.Name = "ChangeCustomerInfobtn"
        Me.ChangeCustomerInfobtn.Size = New System.Drawing.Size(126, 27)
        Me.ChangeCustomerInfobtn.TabIndex = 10
        Me.ChangeCustomerInfobtn.Text = "ChangeCustomerInfo"
        Me.ChangeCustomerInfobtn.UseVisualStyleBackColor = True
        '
        'ChangeAccNobtn
        '
        Me.ChangeAccNobtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangeAccNobtn.Location = New System.Drawing.Point(771, 57)
        Me.ChangeAccNobtn.Name = "ChangeAccNobtn"
        Me.ChangeAccNobtn.Size = New System.Drawing.Size(126, 33)
        Me.ChangeAccNobtn.TabIndex = 11
        Me.ChangeAccNobtn.Text = "ChangeAccNo"
        Me.ChangeAccNobtn.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ListDGrid
        '
        Me.ListDGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListDGrid.Location = New System.Drawing.Point(12, 58)
        Me.ListDGrid.Name = "ListDGrid"
        Me.ListDGrid.Size = New System.Drawing.Size(386, 379)
        Me.ListDGrid.TabIndex = 12
        '
        'ResultGrid
        '
        Me.ResultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultGrid.Location = New System.Drawing.Point(404, 58)
        Me.ResultGrid.Name = "ResultGrid"
        Me.ResultGrid.Size = New System.Drawing.Size(361, 379)
        Me.ResultGrid.TabIndex = 13
        '
        'Browsebtn
        '
        Me.Browsebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Browsebtn.Location = New System.Drawing.Point(272, 3)
        Me.Browsebtn.Name = "Browsebtn"
        Me.Browsebtn.Size = New System.Drawing.Size(126, 22)
        Me.Browsebtn.TabIndex = 14
        Me.Browsebtn.Text = "Browse"
        Me.Browsebtn.UseVisualStyleBackColor = True
        '
        'Fileuptxt
        '
        Me.Fileuptxt.Location = New System.Drawing.Point(12, 3)
        Me.Fileuptxt.Name = "Fileuptxt"
        Me.Fileuptxt.Size = New System.Drawing.Size(255, 20)
        Me.Fileuptxt.TabIndex = 15
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 29)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(753, 23)
        Me.ProgressBar1.TabIndex = 16
        '
        'BtnChangeNationalCode
        '
        Me.BtnChangeNationalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChangeNationalCode.Location = New System.Drawing.Point(771, 245)
        Me.BtnChangeNationalCode.Name = "BtnChangeNationalCode"
        Me.BtnChangeNationalCode.Size = New System.Drawing.Size(126, 28)
        Me.BtnChangeNationalCode.TabIndex = 17
        Me.BtnChangeNationalCode.Text = "ChangeNationalCodeBy CardNo"
        Me.BtnChangeNationalCode.UseVisualStyleBackColor = True
        '
        'BtnGetAcc
        '
        Me.BtnGetAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGetAcc.Location = New System.Drawing.Point(771, 279)
        Me.BtnGetAcc.Name = "BtnGetAcc"
        Me.BtnGetAcc.Size = New System.Drawing.Size(126, 28)
        Me.BtnGetAcc.TabIndex = 18
        Me.BtnGetAcc.Text = "GetAccountByCardNo"
        Me.BtnGetAcc.UseVisualStyleBackColor = True
        '
        'frmCardOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 449)
        Me.Controls.Add(Me.BtnGetAcc)
        Me.Controls.Add(Me.BtnChangeNationalCode)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Fileuptxt)
        Me.Controls.Add(Me.Browsebtn)
        Me.Controls.Add(Me.ResultGrid)
        Me.Controls.Add(Me.ListDGrid)
        Me.Controls.Add(Me.ChangeAccNobtn)
        Me.Controls.Add(Me.ChangeCustomerInfobtn)
        Me.Controls.Add(Me.GetCardNoByNationalCodebtn)
        Me.Controls.Add(Me.GetNationalCodeByCardNobtn)
        Me.Controls.Add(Me.ActivateCardbtn)
        Me.Controls.Add(Me.GetCardNoByAccNobtn)
        Me.Name = "frmCardOperation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CardOperation"
        CType(Me.ListDGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResultGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GetCardNoByAccNobtn As System.Windows.Forms.Button
    Friend WithEvents ActivateCardbtn As System.Windows.Forms.Button
    Friend WithEvents GetNationalCodeByCardNobtn As System.Windows.Forms.Button
    Friend WithEvents GetCardNoByNationalCodebtn As System.Windows.Forms.Button
    Friend WithEvents ChangeCustomerInfobtn As System.Windows.Forms.Button
    Friend WithEvents ChangeAccNobtn As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ListDGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ResultGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Browsebtn As System.Windows.Forms.Button
    Friend WithEvents Fileuptxt As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnChangeNationalCode As System.Windows.Forms.Button
    Friend WithEvents BtnGetAcc As System.Windows.Forms.Button
End Class
