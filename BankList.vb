Public Class BankList
    Function FillGrid()
        Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Dim BankListGetDataCmd = New System.Data.SqlClient.SqlCommand
        Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        SqlConnection1.ConnectionString = sqlConnectionString1
        SqlConnection1.Open()
        BankListGetDataCmd.CommandText = "dbo.[BankNameGetAllData]"
        BankListGetDataCmd.CommandTimeout = 300
        BankListGetDataCmd.Connection = SqlConnection1
        BankListGetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
        BankListGetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        Dim TmpReader As SqlClient.SqlDataReader = BankListGetDataCmd.ExecuteReader
        ''Set view property
        AllBankListview.View = View.Details
        AllBankListview.GridLines = True
        AllBankListview.FullRowSelect = True
        AllBankListview.Items.Clear()
        Dim arr As String() = New String(1) {}
        Dim itm As ListViewItem
        While TmpReader.Read()
            arr(0) = TmpReader.Item(1)
            itm = New ListViewItem(arr)
            itm.ForeColor = Color.Black
            AllBankListview.Items.Insert(0, itm)
        End While

        TmpReader.Close()
        SqlConnection1.Close()
    End Function
    Function FillActiveGrid()
        Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Dim BankListGetDataCmd = New System.Data.SqlClient.SqlCommand
        Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        SqlConnection1.ConnectionString = sqlConnectionString1
        SqlConnection1.Open()
        BankListGetDataCmd.CommandText = "dbo.[BankNameGetData]"
        BankListGetDataCmd.CommandTimeout = 300
        BankListGetDataCmd.Connection = SqlConnection1
        BankListGetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
        BankListGetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        Dim TmpReader As SqlClient.SqlDataReader = BankListGetDataCmd.ExecuteReader
        ''Set view property
        ActiveBankListView.View = View.Details
        ActiveBankListView.GridLines = True
        ActiveBankListView.FullRowSelect = True
        ActiveBankListView.Items.Clear()
        Dim arr As String() = New String(1) {}
        Dim itm As ListViewItem
        While TmpReader.Read()
            arr(0) = TmpReader.Item(1)
            itm = New ListViewItem(arr)
            itm.ForeColor = Color.Black
            ActiveBankListView.Items.Insert(0, itm)
        End While

        TmpReader.Close()
        SqlConnection1.Close()
    End Function

    Private Sub BankList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillGrid()
        FillActiveGrid()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            ChakavakCmd.CommandText = "dbo.[InsertChakavakBank]"
            ChakavakCmd.CommandTimeout = 300
            ChakavakCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakCmd.Connection = SqlConnection1
            ChakavakCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BankCode", System.Data.SqlDbType.NVarChar, 10))

            ChakavakCmd.Parameters("@BankCode").Value = AllBankListview.SelectedItems.Item(0).Text.Substring(0, 2)
            ChakavakCmd.ExecuteNonQuery()
            SqlConnection1.Close()
            FillActiveGrid()
        Catch ex As Exception
            MsgBox("ردیفی برای اضافه شدن انتخاب نشده است")
        End Try
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            ChakavakCmd.CommandText = "dbo.[DeleteChakavakBank]"
            ChakavakCmd.CommandTimeout = 300
            ChakavakCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakCmd.Connection = SqlConnection1
            ChakavakCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BankCode", System.Data.SqlDbType.NVarChar, 10))

            ChakavakCmd.Parameters("@BankCode").Value = ActiveBankListView.SelectedItems.Item(0).Text.Substring(0, 2)
            ChakavakCmd.ExecuteNonQuery()
            SqlConnection1.Close()
            FillActiveGrid()
        Catch ex As Exception
            MsgBox("ردیفی برای حذف انتخاب نشده است")
        End Try
        
    End Sub
End Class