Public Class SimiaVarizReport

    Private Sub SimiaVarizReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDate.Text = (New GlobalClass.FarsiDate).GetDate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Excel|*.xls"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim BankListGetDataCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.225;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            BankListGetDataCmd.CommandText = "dbo.[ChakavakSimiaVarizReport]"
            BankListGetDataCmd.CommandTimeout = 300
            BankListGetDataCmd.Connection = SqlConnection1
            BankListGetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
            BankListGetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            BankListGetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
            BankListGetDataCmd.Parameters("@Date").Value = txtDate.Text
            Dim TmpReader As SqlClient.SqlDataReader = BankListGetDataCmd.ExecuteReader
            ''Set view property
            Dim Output As String = ""
            Dim counter As Integer = 0
            While TmpReader.Read()
                Output += """" + TmpReader.Item(0) + """," + vbTab
                Output += """" + TmpReader.Item(1) + """," + vbTab
                Output += """" + TmpReader.Item(2) + """," + vbTab
                Output += """" + TmpReader.Item(3) + """," + vbTab
                Output += """" + TmpReader.Item(4) + """" + vbTab + vbCrLf
                counter += 1
            End While
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(saveFileDialog1.FileName, True)
            file.WriteLine(Output)
            file.Close()
            MsgBox("تعداد: " + counter.ToString + "رکورد ذخیره شد")
        End If
        

    End Sub
End Class