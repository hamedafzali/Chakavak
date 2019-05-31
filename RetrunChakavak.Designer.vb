<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RetrunChakavak
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
        Me.ReturnNormalChequeBtn = New System.Windows.Forms.Button()
        Me.ReturnCodedChequeBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ReturnNormalRejectedChequeBtn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReturnNormalChequeBtn
        '
        Me.ReturnNormalChequeBtn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnNormalChequeBtn.Location = New System.Drawing.Point(158, 18)
        Me.ReturnNormalChequeBtn.Name = "ReturnNormalChequeBtn"
        Me.ReturnNormalChequeBtn.Size = New System.Drawing.Size(112, 23)
        Me.ReturnNormalChequeBtn.TabIndex = 0
        Me.ReturnNormalChequeBtn.Text = "عودت چکهای عادی"
        Me.ReturnNormalChequeBtn.UseVisualStyleBackColor = True
        '
        'ReturnCodedChequeBtn
        '
        Me.ReturnCodedChequeBtn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnCodedChequeBtn.Location = New System.Drawing.Point(15, 18)
        Me.ReturnCodedChequeBtn.Name = "ReturnCodedChequeBtn"
        Me.ReturnCodedChequeBtn.Size = New System.Drawing.Size(112, 23)
        Me.ReturnCodedChequeBtn.TabIndex = 1
        Me.ReturnCodedChequeBtn.Text = "عودت چکهای رمزدار"
        Me.ReturnCodedChequeBtn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ReturnNormalRejectedChequeBtn)
        Me.GroupBox1.Controls.Add(Me.ReturnNormalChequeBtn)
        Me.GroupBox1.Controls.Add(Me.ReturnCodedChequeBtn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 91)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'ReturnNormalRejectedChequeBtn
        '
        Me.ReturnNormalRejectedChequeBtn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnNormalRejectedChequeBtn.Location = New System.Drawing.Point(65, 62)
        Me.ReturnNormalRejectedChequeBtn.Name = "ReturnNormalRejectedChequeBtn"
        Me.ReturnNormalRejectedChequeBtn.Size = New System.Drawing.Size(144, 23)
        Me.ReturnNormalRejectedChequeBtn.TabIndex = 2
        Me.ReturnNormalRejectedChequeBtn.Text = "عودت چکهای خطای معنایی"
        Me.ReturnNormalRejectedChequeBtn.UseVisualStyleBackColor = True
        '
        'RetrunChakavak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 104)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "RetrunChakavak"
        Me.Text = "RetrunChakavak"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReturnNormalChequeBtn As System.Windows.Forms.Button
    Friend WithEvents ReturnCodedChequeBtn As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ReturnNormalRejectedChequeBtn As System.Windows.Forms.Button
End Class
