Public Class RetrunChakavak
    Private Sub RetrunChakavak_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ReturnNormalChequeBtn_Click(sender As Object, e As EventArgs) Handles ReturnNormalChequeBtn.Click
        If MsgBox("از عودت چکهای عادی اطمینان دارید؟", MsgBoxStyle.YesNo) = 6 Then
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakReturnAllNormalCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            ChakavakReturnAllNormalCmd.CommandText = "dbo.[ChakavakReturnAllNormal]"
            ChakavakReturnAllNormalCmd.CommandTimeout = 300
            ChakavakReturnAllNormalCmd.Connection = SqlConnection1
            ChakavakReturnAllNormalCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakReturnAllNormalCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakReturnAllNormalCmd.ExecuteNonQuery()
            MsgBox("تعداد:" + ChakavakReturnAllNormalCmd.Parameters("@RETURN_VALUE").Value.ToString + " عودت شد")
            SqlConnection1.Close()
        End If
    End Sub

   

    Private Sub ReturnCodedChequeBtn_Click(sender As Object, e As EventArgs) Handles ReturnCodedChequeBtn.Click
        If MsgBox("از عودت چکهای عادی اطمینان دارید؟", MsgBoxStyle.YesNo) = 6 Then
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakReturnAllCodedCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            ChakavakReturnAllCodedCmd.CommandText = "dbo.[ChakavakReturnAllCoded]"
            ChakavakReturnAllCodedCmd.CommandTimeout = 300
            ChakavakReturnAllCodedCmd.Connection = SqlConnection1
            ChakavakReturnAllCodedCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakReturnAllCodedCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakReturnAllCodedCmd.ExecuteNonQuery()

            MsgBox("تعداد:" + ChakavakReturnAllCodedCmd.Parameters("@RETURN_VALUE").Value.ToString + " عودت شد")
        
        SqlConnection1.Close()
        End If
    End Sub

    Private Sub ReturnNormalRejectedChequeBtn_Click(sender As Object, e As EventArgs) Handles ReturnNormalRejectedChequeBtn.Click
        If MsgBox("از عودت چکهای عادی با خطای معنایی اطمینان دارید؟", MsgBoxStyle.YesNo) = 6 Then
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakReturnAllCodedCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            ChakavakReturnAllCodedCmd.CommandText = "dbo.[ChakavakReturnAllRejectedNormal]"
            ChakavakReturnAllCodedCmd.CommandTimeout = 300
            ChakavakReturnAllCodedCmd.Connection = SqlConnection1
            ChakavakReturnAllCodedCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakReturnAllCodedCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakReturnAllCodedCmd.ExecuteNonQuery()

            MsgBox("تعداد:" + ChakavakReturnAllCodedCmd.Parameters("@RETURN_VALUE").Value.ToString + " عودت شد")

            SqlConnection1.Close()
        End If
    End Sub
End Class