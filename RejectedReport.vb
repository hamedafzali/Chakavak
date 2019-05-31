Public Class RejectedReport

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FillGrid()
    End Sub
    Function FillGrid()
        Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Dim GetDataCmd = New System.Data.SqlClient.SqlCommand
        Dim sqlConnectionString1 As String
        If TextBox1.Text = (New GlobalClass.FarsiDate).GetDate Then
            sqlConnectionString1 = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        Else
            sqlConnectionString1 = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.225;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        End If

        SqlConnection1.ConnectionString = sqlConnectionString1
        SqlConnection1.Open()
        GetDataCmd.CommandText = "dbo.[ChakavakBranchReturnsByTime]"
        GetDataCmd.CommandTimeout = 300
        GetDataCmd.Connection = SqlConnection1
        GetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
        GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
        GetDataCmd.Parameters("@Date").Value = TextBox1.Text
        Dim TmpReader As SqlClient.SqlDataReader = GetDataCmd.ExecuteReader
        Dim CXml As New ConvertXML.ConvertXML
        Dim Info = New DataSet
        Info = ConvertXML.ConvertXML.convertDataReaderToDataSet(TmpReader)
        ''Set view property
        DataGridView1.DataSource = Info.Tables(0)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        TmpReader.Close()
        SqlConnection1.Close()
    End Function

    Private Sub RejectedReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = (New GlobalClass.FarsiDate).GetDate
    End Sub
End Class