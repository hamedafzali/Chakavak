<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChakavakForm
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblResponse = New System.Windows.Forms.Label()
        Me.lblRequest = New System.Windows.Forms.Label()
        Me.btnRequest = New System.Windows.Forms.Button()
        Me.btnResponse = New System.Windows.Forms.Button()
        Me.lboxLog = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnResponseReceive = New System.Windows.Forms.Button()
        Me.btnResponseSend = New System.Windows.Forms.Button()
        Me.Request = New System.Windows.Forms.GroupBox()
        Me.btnRequestReceive = New System.Windows.Forms.Button()
        Me.btnRequestSend = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Request.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblResponse)
        Me.GroupBox4.Controls.Add(Me.lblRequest)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(803, 53)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Connection Info"
        '
        'lblResponse
        '
        Me.lblResponse.AutoSize = True
        Me.lblResponse.Location = New System.Drawing.Point(6, 30)
        Me.lblResponse.Name = "lblResponse"
        Me.lblResponse.Size = New System.Drawing.Size(11, 13)
        Me.lblResponse.TabIndex = 6
        Me.lblResponse.Text = "-"
        '
        'lblRequest
        '
        Me.lblRequest.AutoSize = True
        Me.lblRequest.Location = New System.Drawing.Point(6, 17)
        Me.lblRequest.Name = "lblRequest"
        Me.lblRequest.Size = New System.Drawing.Size(11, 13)
        Me.lblRequest.TabIndex = 4
        Me.lblRequest.Text = "-"
        '
        'btnRequest
        '
        Me.btnRequest.Location = New System.Drawing.Point(9, 13)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(70, 23)
        Me.btnRequest.TabIndex = 13
        Me.btnRequest.Text = "Connect"
        Me.btnRequest.UseVisualStyleBackColor = True
        '
        'btnResponse
        '
        Me.btnResponse.Location = New System.Drawing.Point(6, 13)
        Me.btnResponse.Name = "btnResponse"
        Me.btnResponse.Size = New System.Drawing.Size(70, 23)
        Me.btnResponse.TabIndex = 14
        Me.btnResponse.Text = "Connect"
        Me.btnResponse.UseVisualStyleBackColor = True
        '
        'lboxLog
        '
        Me.lboxLog.FormattingEnabled = True
        Me.lboxLog.Location = New System.Drawing.Point(12, 191)
        Me.lboxLog.Name = "lboxLog"
        Me.lboxLog.Size = New System.Drawing.Size(803, 277)
        Me.lboxLog.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnResponseReceive)
        Me.GroupBox1.Controls.Add(Me.btnResponseSend)
        Me.GroupBox1.Controls.Add(Me.btnResponse)
        Me.GroupBox1.Location = New System.Drawing.Point(435, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 42)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Response"
        '
        'btnResponseReceive
        '
        Me.btnResponseReceive.Location = New System.Drawing.Point(163, 13)
        Me.btnResponseReceive.Name = "btnResponseReceive"
        Me.btnResponseReceive.Size = New System.Drawing.Size(75, 23)
        Me.btnResponseReceive.TabIndex = 16
        Me.btnResponseReceive.Text = "Receive"
        Me.btnResponseReceive.UseVisualStyleBackColor = True
        '
        'btnResponseSend
        '
        Me.btnResponseSend.Location = New System.Drawing.Point(82, 13)
        Me.btnResponseSend.Name = "btnResponseSend"
        Me.btnResponseSend.Size = New System.Drawing.Size(75, 23)
        Me.btnResponseSend.TabIndex = 15
        Me.btnResponseSend.Text = "Send"
        Me.btnResponseSend.UseVisualStyleBackColor = True
        '
        'Request
        '
        Me.Request.Controls.Add(Me.btnRequestReceive)
        Me.Request.Controls.Add(Me.btnRequestSend)
        Me.Request.Controls.Add(Me.btnRequest)
        Me.Request.Location = New System.Drawing.Point(12, 71)
        Me.Request.Name = "Request"
        Me.Request.Size = New System.Drawing.Size(417, 42)
        Me.Request.TabIndex = 0
        Me.Request.TabStop = False
        Me.Request.Text = "Request"
        '
        'btnRequestReceive
        '
        Me.btnRequestReceive.Location = New System.Drawing.Point(166, 13)
        Me.btnRequestReceive.Name = "btnRequestReceive"
        Me.btnRequestReceive.Size = New System.Drawing.Size(75, 23)
        Me.btnRequestReceive.TabIndex = 15
        Me.btnRequestReceive.Text = "Receive"
        Me.btnRequestReceive.UseVisualStyleBackColor = True
        '
        'btnRequestSend
        '
        Me.btnRequestSend.Location = New System.Drawing.Point(85, 13)
        Me.btnRequestSend.Name = "btnRequestSend"
        Me.btnRequestSend.Size = New System.Drawing.Size(75, 23)
        Me.btnRequestSend.TabIndex = 14
        Me.btnRequestSend.Text = "Send"
        Me.btnRequestSend.UseVisualStyleBackColor = True
        '
        'ChakavakForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 477)
        Me.Controls.Add(Me.Request)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lboxLog)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "ChakavakForm"
        Me.Text = "ChakavakForm"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Request.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRequest As System.Windows.Forms.Label
    Friend WithEvents lblResponse As System.Windows.Forms.Label
    Friend WithEvents btnRequest As System.Windows.Forms.Button
    Friend WithEvents btnResponse As System.Windows.Forms.Button
    Friend WithEvents lboxLog As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnResponseReceive As System.Windows.Forms.Button
    Friend WithEvents btnResponseSend As System.Windows.Forms.Button
    Friend WithEvents Request As System.Windows.Forms.GroupBox
    Friend WithEvents btnRequestReceive As System.Windows.Forms.Button
    Friend WithEvents btnRequestSend As System.Windows.Forms.Button
End Class
