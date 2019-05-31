<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MQFrm
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
        Me.Test = New System.Windows.Forms.Button()
        Me.QueueManagerNameTxt = New System.Windows.Forms.TextBox()
        Me.QueueNameTxt = New System.Windows.Forms.TextBox()
        Me.ChannelInfoTxt = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtWriteMessage = New System.Windows.Forms.TextBox()
        Me.txtReadMessage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Test
        '
        Me.Test.Location = New System.Drawing.Point(106, 142)
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(75, 23)
        Me.Test.TabIndex = 0
        Me.Test.Text = "LIXA Test"
        Me.Test.UseVisualStyleBackColor = True
        '
        'QueueManagerNameTxt
        '
        Me.QueueManagerNameTxt.Location = New System.Drawing.Point(106, 11)
        Me.QueueManagerNameTxt.Name = "QueueManagerNameTxt"
        Me.QueueManagerNameTxt.Size = New System.Drawing.Size(248, 20)
        Me.QueueManagerNameTxt.TabIndex = 1
        Me.QueueManagerNameTxt.Text = "CMS.REQUEST.MANAGER"
        '
        'QueueNameTxt
        '
        Me.QueueNameTxt.Location = New System.Drawing.Point(106, 37)
        Me.QueueNameTxt.Name = "QueueNameTxt"
        Me.QueueNameTxt.Size = New System.Drawing.Size(248, 20)
        Me.QueueNameTxt.TabIndex = 2
        Me.QueueNameTxt.Text = "PBIR.REQUEST.IN"
        '
        'ChannelInfoTxt
        '
        Me.ChannelInfoTxt.Location = New System.Drawing.Point(106, 63)
        Me.ChannelInfoTxt.Name = "ChannelInfoTxt"
        Me.ChannelInfoTxt.Size = New System.Drawing.Size(248, 20)
        Me.ChannelInfoTxt.TabIndex = 3
        Me.ChannelInfoTxt.Text = "PBIR.REQUEST.CHL/TCP/127.0.0.1/14027"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(187, 142)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Connect"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(268, 142)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Write"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(349, 142)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Read"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Queue Manager"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Queue Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Channel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Write Message:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Read Message:"
        '
        'txtWriteMessage
        '
        Me.txtWriteMessage.Location = New System.Drawing.Point(106, 90)
        Me.txtWriteMessage.Name = "txtWriteMessage"
        Me.txtWriteMessage.Size = New System.Drawing.Size(477, 20)
        Me.txtWriteMessage.TabIndex = 12
        '
        'txtReadMessage
        '
        Me.txtReadMessage.Location = New System.Drawing.Point(106, 116)
        Me.txtReadMessage.Name = "txtReadMessage"
        Me.txtReadMessage.Size = New System.Drawing.Size(477, 20)
        Me.txtReadMessage.TabIndex = 13
        '
        'MQFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 170)
        Me.Controls.Add(Me.txtReadMessage)
        Me.Controls.Add(Me.txtWriteMessage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ChannelInfoTxt)
        Me.Controls.Add(Me.QueueNameTxt)
        Me.Controls.Add(Me.QueueManagerNameTxt)
        Me.Controls.Add(Me.Test)
        Me.Name = "MQFrm"
        Me.Text = "MQFrm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Test As System.Windows.Forms.Button
    Friend WithEvents QueueManagerNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents QueueNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ChannelInfoTxt As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtWriteMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtReadMessage As System.Windows.Forms.TextBox
End Class
