Imports ADOX
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports log4net
Imports System.Net
Imports System.IO


Public Class DocumentRiser

    Private Sub Browsebtn_Click(sender As Object, e As EventArgs) Handles Browsebtn.Click
        UploadFile()
    End Sub
    Function UploadFile()
        OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Filter = "Microsoft Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog Then
            Fileuptxt.Text = OpenFileDialog1.FileName
            ListDGrid.DataSource = ""
        End If
        Dim resultStr As String = ""
        Try
            Dim connection As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Fileuptxt.Text + "; Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
            connection.Open()
            Dim SysDate As String = "Date" + System.DateTime.Now.Month.ToString.PadLeft(2, "0") + System.DateTime.Now.Day.ToString.PadLeft(2, "0") + "-" + System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + System.DateTime.Now.Minute.ToString.PadLeft(2, "0")
            Dim oFile As System.IO.File
            Dim oWrite As System.IO.StreamWriter
            Dim RecordCounter As Integer = 0
            Dim ds As New DataSet
            Dim Url As String = GetUrl(ListDGrid.Text)
            Dim dr1 As OleDb.OleDbDataReader
            Dim DrCount As Integer
            '..............

            Dim newRow As DataRow

            Dim cmdExcel As New OleDbCommand

            Dim oda As New OleDbDataAdapter

            Dim dt As New DataTable
            dt.Clear()

            cmdExcel.Connection = connection

            Dim dtExcelSchema As DataTable

            dtExcelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()

            connection.Close()

            connection.Open()

            cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"

            oda.SelectCommand = cmdExcel

            oda.Fill(dt)

            connection.Close()

            ListDGrid.DataSource = dt
            RecordCounter = ListDGrid.DataSource.rows.count - 1
            If True Then
                MsgBox("فایل بارگذاری شد", MsgBoxStyle.OkOnly, "Message")
                'Fileuptxt.Text = ""
                DocumentBtn.Enabled = True
            Else
                MsgBox("", MsgBoxStyle.OkOnly, "Error Message")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Function GetUrl(ByVal TmpStr As String)
        Dim Url As String = ""
        Dim tmp As String = ""
        For i As Integer = 1 To TmpStr.Length
            If Mid(TmpStr, i, 1) = "\" Then
                tmp = tmp + Mid(TmpStr, i, 1)
                Url = Url + tmp
                tmp = ""
            Else
                tmp = tmp + Mid(TmpStr, i, 1)
            End If
        Next
        Return Url
    End Function

    Private Sub DocumentBtn_Click(sender As Object, e As EventArgs) Handles DocumentBtn.Click

        Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Dim ChakavakDocumentRiserCmd = New System.Data.SqlClient.SqlCommand
        ChakavakDocumentRiserCmd.CommandText = "dbo.[ChakavakDocumentRiser]"
        ChakavakDocumentRiserCmd.CommandTimeout = 300
        ChakavakDocumentRiserCmd.CommandType = System.Data.CommandType.StoredProcedure
        ChakavakDocumentRiserCmd.Connection = SqlConnection1
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 50))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AccountNo", System.Data.SqlDbType.NVarChar, 20))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchNo", System.Data.SqlDbType.NVarChar, 10))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 20))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SessionId", System.Data.SqlDbType.NVarChar, 50))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 50))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@ErrorMessage", System.Data.SqlDbType.NVarChar, 100, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.242;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        SqlConnection1.ConnectionString = sqlConnectionString
        SqlConnection1.Open()

        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count

        For i As Integer = 0 To RecordCounter - 1


            Dim AccountNo As String
            Dim Amount As String
            Dim ChequeNo As String
            Dim SimiaCounter, FarazCounter As Integer
            SimiaCounter = 0
            FarazCounter = 0
            AccountNo = ListDGrid.Item(0, i).Value
            Amount = ListDGrid.Item(1, i).Value.ToString.Replace(",", "")
            ChequeNo = ListDGrid.Item(2, i).Value
            If AccountNo.Length = 20 Then
                Try
                    ChakavakDocumentRiserCmd.Parameters("@UserId").Value = 1
                    ChakavakDocumentRiserCmd.Parameters("@BranchId").Value = 517
                    ChakavakDocumentRiserCmd.Parameters("@Username").Value = "asgarizade"
                    ChakavakDocumentRiserCmd.Parameters("@AccountNo").Value = AccountNo
                    ChakavakDocumentRiserCmd.Parameters("@BranchNo").Value = "9988"
                    ChakavakDocumentRiserCmd.Parameters("@Amount").Value = Amount
                    ChakavakDocumentRiserCmd.Parameters("@Date").Value = (New GlobalClass.FarsiDate).GetDate
                    ChakavakDocumentRiserCmd.Parameters("@SessionId").Value = AccountNo + ChequeNo
                    ChakavakDocumentRiserCmd.Parameters("@Description").Value = ChequeNo
                    ChakavakDocumentRiserCmd.ExecuteNonQuery()
                    FarazCounter += 1
                Catch ex As Exception

                End Try


                ListDGrid.Item(4, i).Value = ChakavakDocumentRiserCmd.Parameters("@@ErrorMessage").Value
                Insert2Excel(AccountNo, Amount, ChequeNo, "FARAZ", ChakavakDocumentRiserCmd.Parameters("@@ErrorMessage").Value)

            Else
                Try
                    Dim Daftar As String = "9988"
                    Dim client As WebClient = New WebClient
                    client.Headers("Content-type") = "application/json"
                    Dim FarsiDate As String = (New GlobalClass.FarsiDate).GetDate
                    Dim code As String = (Mid(FarsiDate, 1, 4) * 13) + (Mid(FarsiDate, 6, 2) * 12) + (Mid(FarsiDate, 9, 2) * 11)
                    Dim res As New AjaxPro.JavaScriptObject
                    Dim Str As String
                    Dim url As String
                    If ComboBox1.SelectedItem.ToString.Substring(0, 1) = "1" Then
                        url = AccountNo & "," & "10582354701" & "," & CType(Amount, String) & "," & "1" & "," & Daftar & "," & Daftar & "," & "1" & ",واریز " & ChequeNo.Replace("/", ".")
                        Str = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regVaariz_new/" & System.Uri.EscapeDataString(url) & "," & code
                    Else
                        url = AccountNo & "," & "10582354701" & "," & CType(Amount, String) & "," & "1" & "," & Daftar & "," & Daftar & "," & "1" & ",برداشت " & ChequeNo.Replace("/", ".")
                        Str = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regBardaasht_new/" & System.Uri.EscapeDataString(url) & "," & code
                    End If
                    'url = "55299961718653.11,10582354701,1,1,9988,9988,1,واریز به/ بانک" ' + ChequeNo
                    'Str = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regVaariz_new/546128223335.04,10582340326,100000,1,46128,46128,1,واریز به بانک,18275"
                    'Dim Str As String = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regVaariz/" & AccountNo & "," & "10582354701" & "," & CType(Amount, String) & "," & Daftar & "," & Daftar & "," & Daftar & "," & "1" & "," & code
                    'Dim Str As String = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regBardaasht/" & AccountNo & "," & "10582354701" & "," & CType(Amount, String) & "," & Daftar & "," & Daftar & "," & Daftar & "," & "1" & "," & code
                    Dim data As Byte() = client.DownloadData(Str)
                    res = AjaxPro.JavaScriptDeserializer.DeserializeFromJson(System.Text.Encoding.UTF8.GetString(data), GetType(AjaxPro.JavaScriptArray))

                    ListDGrid.Item(3, i).Value = res.Item("message_")
                    Insert2Excel(AccountNo, Amount, ChequeNo, "SIMIA", res.Item("message_").Value.ToString + " " + res.Item("sequence").Value.ToString)
                    SimiaCounter += 1
                Catch ex As Exception

                    ListDGrid.Item(3, i).Value = ex.Message
                End Try
            End If

            Application.DoEvents()
        Next
        SqlConnection1.Close()

    End Sub
    Function Insert2Excel(AccountNo As String, Amount As String, ChequeNo As String, CoreType As String, Stat As String)
        Try
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim myCommand As New System.Data.OleDb.OleDbCommand
            Dim sql As String

            Dim filename As String = Path.GetDirectoryName(Fileuptxt.Text) + "\ChakavakResult" + (New GlobalClass.FarsiDate).GetDate().Replace("/", "") + ".mdb"
            If Not File.Exists(filename) Then
                Dim cat As Catalog = New Catalog()
                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Jet OLEDB:Engine Type=5")
                cat = Nothing
                MyConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Persist Security Info=False;")
                MyConnection.Open()
                myCommand.Connection = MyConnection
                sql = "Create Table Result(AccountNo VARCHAR,Amount VARCHAR,ChequeNo VARCHAR,CoreType VARCHAR,Stat VARCHAR)"
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
                MyConnection.Close()
            End If



            MyConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Persist Security Info=False;")
            'MyConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + "; Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
            MyConnection.Open()
            myCommand.Connection = MyConnection
            sql = "Insert into Result (AccountNo,Amount,ChequeNo,CoreType,Stat) values('" + AccountNo + "','" + Amount + "','" + ChequeNo + "','" + CoreType + "','" + Stat + "')"
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
            MyConnection.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        'MsgBox("Row Added ")
    End Function

   
    
End Class