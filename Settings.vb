Public Class Settings

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.RequestInTime = txtRequestIn.Text
        My.Settings.RequestOutTime = txtRequestOut.Text
        My.Settings.ResponseInTime = txtResponseIn.Text
        My.Settings.ResponseOutTime = txtResponseOut.Text
        My.Settings.ResponseOutAckTime = txtResponseOutAck.Text
        My.Settings.StartTime = txtNormalDayStartTimeOut.Text
        My.Settings.EndTime = txtNormalDayEndTimeOut.Text
        
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRequestIn.Text = My.Settings.RequestInTime
        txtRequestOut.Text = My.Settings.RequestOutTime
        txtResponseIn.Text = My.Settings.ResponseInTime
        txtResponseOut.Text = My.Settings.ResponseOutTime
        txtResponseOutAck.Text = My.Settings.ResponseOutAckTime
        txtNormalDayStartTimeOut.Text = My.Settings.StartTime
        txtNormalDayEndTimeOut.Text = My.Settings.EndTime
    End Sub
End Class