<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ReqReadBtn = New System.Windows.Forms.Button()
        Me.ReqWriteBtn = New System.Windows.Forms.Button()
        Me.MQFormBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.RqsInMqConnectBtn = New System.Windows.Forms.Button()
        Me.txtReadMessage = New System.Windows.Forms.TextBox()
        Me.txtWriteMessage = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RqsChannelInfoTxt = New System.Windows.Forms.TextBox()
        Me.RqsInQueueNameTxt = New System.Windows.Forms.TextBox()
        Me.QueueManagerNameTxt = New System.Windows.Forms.TextBox()
        Me.MQReqWriteBtn = New System.Windows.Forms.Button()
        Me.MQReqReadBtn = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ConnectionStringDrop = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReqReadBtn
        '
        Me.ReqReadBtn.Location = New System.Drawing.Point(176, 123)
        Me.ReqReadBtn.Name = "ReqReadBtn"
        Me.ReqReadBtn.Size = New System.Drawing.Size(75, 23)
        Me.ReqReadBtn.TabIndex = 0
        Me.ReqReadBtn.Text = "Read"
        Me.ReqReadBtn.UseVisualStyleBackColor = True
        '
        'ReqWriteBtn
        '
        Me.ReqWriteBtn.Location = New System.Drawing.Point(337, 123)
        Me.ReqWriteBtn.Name = "ReqWriteBtn"
        Me.ReqWriteBtn.Size = New System.Drawing.Size(75, 23)
        Me.ReqWriteBtn.TabIndex = 2
        Me.ReqWriteBtn.Text = "Write"
        Me.ReqWriteBtn.UseVisualStyleBackColor = True
        '
        'MQFormBtn
        '
        Me.MQFormBtn.Location = New System.Drawing.Point(499, 123)
        Me.MQFormBtn.Name = "MQFormBtn"
        Me.MQFormBtn.Size = New System.Drawing.Size(75, 23)
        Me.MQFormBtn.TabIndex = 3
        Me.MQFormBtn.Text = "MQForm"
        Me.MQFormBtn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(630, 211)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(437, 170)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(630, 42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(437, 167)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'RqsInMqConnectBtn
        '
        Me.RqsInMqConnectBtn.Location = New System.Drawing.Point(99, 123)
        Me.RqsInMqConnectBtn.Name = "RqsInMqConnectBtn"
        Me.RqsInMqConnectBtn.Size = New System.Drawing.Size(75, 23)
        Me.RqsInMqConnectBtn.TabIndex = 6
        Me.RqsInMqConnectBtn.Text = "MQConnect"
        Me.RqsInMqConnectBtn.UseVisualStyleBackColor = True
        '
        'txtReadMessage
        '
        Me.txtReadMessage.Location = New System.Drawing.Point(99, 283)
        Me.txtReadMessage.Multiline = True
        Me.txtReadMessage.Name = "txtReadMessage"
        Me.txtReadMessage.Size = New System.Drawing.Size(525, 102)
        Me.txtReadMessage.TabIndex = 23
        '
        'txtWriteMessage
        '
        Me.txtWriteMessage.Location = New System.Drawing.Point(99, 165)
        Me.txtWriteMessage.Multiline = True
        Me.txtWriteMessage.Name = "txtWriteMessage"
        Me.txtWriteMessage.Size = New System.Drawing.Size(525, 96)
        Me.txtWriteMessage.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 312)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Read Message:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Write Message:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Queue Manager"
        '
        'RqsChannelInfoTxt
        '
        Me.RqsChannelInfoTxt.Location = New System.Drawing.Point(99, 97)
        Me.RqsChannelInfoTxt.Name = "RqsChannelInfoTxt"
        Me.RqsChannelInfoTxt.ReadOnly = True
        Me.RqsChannelInfoTxt.Size = New System.Drawing.Size(248, 20)
        Me.RqsChannelInfoTxt.TabIndex = 16
        '
        'RqsInQueueNameTxt
        '
        Me.RqsInQueueNameTxt.Location = New System.Drawing.Point(99, 74)
        Me.RqsInQueueNameTxt.Name = "RqsInQueueNameTxt"
        Me.RqsInQueueNameTxt.ReadOnly = True
        Me.RqsInQueueNameTxt.Size = New System.Drawing.Size(248, 20)
        Me.RqsInQueueNameTxt.TabIndex = 15
        '
        'QueueManagerNameTxt
        '
        Me.QueueManagerNameTxt.Location = New System.Drawing.Point(99, 51)
        Me.QueueManagerNameTxt.Name = "QueueManagerNameTxt"
        Me.QueueManagerNameTxt.ReadOnly = True
        Me.QueueManagerNameTxt.Size = New System.Drawing.Size(248, 20)
        Me.QueueManagerNameTxt.TabIndex = 14
        '
        'MQReqWriteBtn
        '
        Me.MQReqWriteBtn.Location = New System.Drawing.Point(418, 123)
        Me.MQReqWriteBtn.Name = "MQReqWriteBtn"
        Me.MQReqWriteBtn.Size = New System.Drawing.Size(75, 23)
        Me.MQReqWriteBtn.TabIndex = 25
        Me.MQReqWriteBtn.Text = "MQWrite"
        Me.MQReqWriteBtn.UseVisualStyleBackColor = True
        '
        'MQReqReadBtn
        '
        Me.MQReqReadBtn.Location = New System.Drawing.Point(257, 123)
        Me.MQReqReadBtn.Name = "MQReqReadBtn"
        Me.MQReqReadBtn.Size = New System.Drawing.Size(75, 23)
        Me.MQReqReadBtn.TabIndex = 24
        Me.MQReqReadBtn.Text = "MQRead"
        Me.MQReqReadBtn.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Queue Name"
        '
        'ConnectionStringDrop
        '
        Me.ConnectionStringDrop.AllowDrop = True
        Me.ConnectionStringDrop.DropDownWidth = 500
        Me.ConnectionStringDrop.FormattingEnabled = True
        Me.ConnectionStringDrop.Items.AddRange(New Object() {"CMS.REQUEST.MANAGER/PBIR.REQUEST.IN/PBIR.REQUEST.CHL/TCP/127.0.0.1/14027", "CMS.REQUEST.MANAGER/PBIR.REQUEST.OUT/PBIR.REQUEST.CHL/TCP/127.0.0.1/14027", "CMS.RESPONSE.MANAGER/PBIR.RESPONSE.IN/PBIR.RESPONSE.CHL/TCP/127.0.0.1/15027", "CMS.RESPONSE.MANAGER/PBIR.RESPONSE.OUT/PBIR.RESPONSE.CHL/TCP/127.0.0.1/15027"})
        Me.ConnectionStringDrop.Location = New System.Drawing.Point(99, 12)
        Me.ConnectionStringDrop.Name = "ConnectionStringDrop"
        Me.ConnectionStringDrop.Size = New System.Drawing.Size(475, 21)
        Me.ConnectionStringDrop.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Channel"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 396)
        Me.Controls.Add(Me.ConnectionStringDrop)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.MQReqWriteBtn)
        Me.Controls.Add(Me.MQReqReadBtn)
        Me.Controls.Add(Me.txtReadMessage)
        Me.Controls.Add(Me.txtWriteMessage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RqsChannelInfoTxt)
        Me.Controls.Add(Me.RqsInQueueNameTxt)
        Me.Controls.Add(Me.QueueManagerNameTxt)
        Me.Controls.Add(Me.RqsInMqConnectBtn)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MQFormBtn)
        Me.Controls.Add(Me.ReqWriteBtn)
        Me.Controls.Add(Me.ReqReadBtn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReqReadBtn As System.Windows.Forms.Button
    Friend WithEvents ReqWriteBtn As System.Windows.Forms.Button
    Friend WithEvents MQFormBtn As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents RqsInMqConnectBtn As System.Windows.Forms.Button
    Friend WithEvents txtReadMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtWriteMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RqsChannelInfoTxt As System.Windows.Forms.TextBox
    Friend WithEvents RqsInQueueNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents QueueManagerNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents MQReqWriteBtn As System.Windows.Forms.Button
    Friend WithEvents MQReqReadBtn As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ConnectionStringDrop As System.Windows.Forms.ComboBox

End Class
