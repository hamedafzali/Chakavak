Imports ADOX
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports log4net
Imports System.Net
Imports System.IO

Public Class Document
    Private ReadOnly tmplog As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

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

    Function removeLeftZero(Str As String) As String
        Dim counter As Integer
        For counter = 1 To Str.Length
            If Mid(Str, counter, 1) <> "0" Then
                removeLeftZero = Mid(Str, counter, Str.Length - counter + 1)
                Exit For
            End If
        Next
        Return removeLeftZero
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CheckFileBtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow
        Dim CardNo As String

        'Dim tmpPublicServiceSoapClient As New FarazService.PublicServiceSoapClient



        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "AccountNo"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Amount"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "ChequeNo"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "CoreType"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "BranchCode"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()
        Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.242;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        SqlConnection1.ConnectionString = sqlConnectionString
        Dim ChakavakDocumentRiserCmd = New System.Data.SqlClient.SqlCommand
        ChakavakDocumentRiserCmd.CommandText = "dbo.[IBANtoAccount]"
        ChakavakDocumentRiserCmd.CommandTimeout = 300
        ChakavakDocumentRiserCmd.CommandType = System.Data.CommandType.StoredProcedure
        ChakavakDocumentRiserCmd.Connection = SqlConnection1
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AccountNo", System.Data.SqlDbType.NVarChar, 26))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@ReturnAccount", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        Try
            ProgressBar1.Value = 1
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = RecordCounter
            ProgressBar1.Value = 1
            ProgressBar1.Step = 1
        Catch ex As Exception

        End Try

        SqlConnection1.Open()
        For counter As Integer = 1 To RecordCounter
            Try
                CardNo = ""

                ProgressBar1.PerformStep()
                lblPercent.Text = String.Format("{0}%", ((ProgressBar1.Value / ProgressBar1.Maximum) * 100).ToString("F2"))
                If ListDGrid.Item(3, counter).Value.ToString.Length = 26 Then


                    Dim IBAN As String = ""
                    Dim AccountNo As String = ""
                    Dim Amount As String = ""
                    Dim ChequeNo As String = ""
                    Dim CoreType As String = ""
                    Dim BranchNo As String = ""
                    IBAN = ListDGrid.Item(3, counter).Value
                    Amount = ListDGrid.Item(14, counter).Value
                    ChequeNo = ListDGrid.Item(15, counter).Value
                    BranchNo = ListDGrid.Item(2, counter).Value
                    'AccountNo = tmpPublicServiceSoapClient.GetAccountByIBAN(IBAN)


                    ChakavakDocumentRiserCmd.Parameters("@AccountNo").Value = IBAN
                    ChakavakDocumentRiserCmd.ExecuteNonQuery()
                    AccountNo = ChakavakDocumentRiserCmd.Parameters("@@ReturnAccount").Value



                    If AccountNo.Length = 20 Then
                        CoreType = "Faraz"
                        lblFarazCount.Text += 1
                    Else
                        CoreType = "Simia"
                        lblSimiaCount.Text += 1
                    End If

                    Dim strAccount As String = removeLeftZero(Mid(AccountNo, 9, 18))
                    'If strAccount.Length < 18 And strAccount.Length > 10 And strAccount.Substring(strAccount.Length - 2, 2) <> "00" And strAccount.Substring(0, 1) < "6" Then
                    row = dt.NewRow()
                    row("AccountNo") = AccountNo
                    row("Amount") = Amount.Replace(",", "")
                    row("ChequeNo") = ChequeNo
                    row("CoreType") = CoreType
                    row("BranchCode") = BranchNo
                    row("Status") = "Done"
                    dt.Rows.Add(row)
                    tmplog.Info("ChakavakInsert:" + AccountNo + "," + ChequeNo + "," + Amount.ToString)
                    IBAN = ""
                    AccountNo = ""
                    Amount = ""
                    ChequeNo = ""
                    CoreType = ""
                    BranchNo = ""
                    'End If
                End If

                Application.DoEvents()
                DocumentBtn.Enabled = True


            Catch ex As Exception

            End Try

        Next
        SqlConnection1.Close()
        ResultGrid.DataSource = dt
    End Sub

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
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RegBranchNo", System.Data.SqlDbType.NVarChar, 10))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Amount", System.Data.SqlDbType.Decimal, 20))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SessionId", System.Data.SqlDbType.NVarChar, 50))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 50))
        ChakavakDocumentRiserCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@ErrorMessage", System.Data.SqlDbType.NVarChar, 100, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.242;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
        SqlConnection1.ConnectionString = sqlConnectionString
        SqlConnection1.Open()

        Dim RecordCounter As Integer = ResultGrid.DataSource.rows.count
        Try
            ProgressBar1.Value = 1
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = RecordCounter
            ProgressBar1.Value = 1
            ProgressBar1.Step = 1
        Catch ex As Exception

        End Try
        For i As Integer = 0 To RecordCounter - 1
            Try
                ProgressBar1.PerformStep()
                lblPercent.Text = String.Format("{0}%", ((ProgressBar1.Value / ProgressBar1.Maximum) * 100).ToString("F2"))
            Catch ex As Exception

            End Try
            Dim BranchNo As String
            Dim AccountNo As String
            Dim Amount As String
            Dim ChequeNo As String
            'Dim SimiaCounter, FarazCounter As Integer
            Dim ErrMessage As String
            'SimiaCounter = 0
            'FarazCounter = 0
            AccountNo = ResultGrid.Item(0, i).Value
            Amount = ResultGrid.Item(1, i).Value.ToString.Replace(",", "")
            ChequeNo = ResultGrid.Item(2, i).Value
            BranchNo = ResultGrid.Item(4, i).Value
            tmplog.Info("ChakavakInsert:" + AccountNo + "," + ChequeNo + "," + Amount.ToString)

            If AccountNo.Length = 20 Then
                Try
                    ChakavakDocumentRiserCmd.Parameters("@UserId").Value = 1
                    ChakavakDocumentRiserCmd.Parameters("@BranchId").Value = 517
                    ChakavakDocumentRiserCmd.Parameters("@Username").Value = "asgarizade"
                    ChakavakDocumentRiserCmd.Parameters("@AccountNo").Value = AccountNo
                    ChakavakDocumentRiserCmd.Parameters("@BranchNo").Value = "9988"
                    ChakavakDocumentRiserCmd.Parameters("@RegBranchNo").Value = BranchNo
                    ChakavakDocumentRiserCmd.Parameters("@Amount").Value = Amount
                    ChakavakDocumentRiserCmd.Parameters("@Date").Value = (New GlobalClass.FarsiDate).GetDate
                    ChakavakDocumentRiserCmd.Parameters("@SessionId").Value = AccountNo + ChequeNo
                    ChakavakDocumentRiserCmd.Parameters("@Description").Value = ChequeNo
                    ChakavakDocumentRiserCmd.ExecuteNonQuery()
                    'FarazCounter += 1

                    ErrMessage = ChakavakDocumentRiserCmd.Parameters("@@ErrorMessage").Value
                    tmplog.Info("ChakavakFarazInserted:" + AccountNo + "," + ChequeNo + "," + Amount.ToString + "," + ErrMessage)
                    Insert2Excel(AccountNo, Amount, ChequeNo, "FARAZ", ErrMessage)
                    ResultGrid.Item(5, i).Value = ErrMessage

                    ErrMessage = ""
                Catch ex As Exception
                    tmplog.Info("ChakavakFarazNotInserted:" + AccountNo + "," + ChequeNo + "," + Amount.ToString + "," + "Error in Proccessing File")
                    Insert2Excel(AccountNo, Amount, ChequeNo, "FARAZ", "Error in Proccessing File")
                End Try

                AccountNo = ""
                Amount = ""
                ChequeNo = ""
                BranchNo = ""

               
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

                    url = AccountNo & "," & "10582354701" & "," & CType(Amount, String) & "," & "1" & "," & Daftar & "," & Daftar & "," & "1" & ",واریز " & ChequeNo.Replace("/", ".")
                    Str = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regVaariz_new/" & System.Uri.EscapeDataString(url) & "," & code
                    Dim data As Byte() = client.DownloadData(Str)
                    res = AjaxPro.JavaScriptDeserializer.DeserializeFromJson(System.Text.Encoding.UTF8.GetString(data), GetType(AjaxPro.JavaScriptArray))

                    ErrMessage = res.Item("message_").Value.ToString + " " + res.Item("sequence").Value.ToString
                    tmplog.Info(url)
                    tmplog.Info("ChakavakSimiaInserted:" + AccountNo + "," + ChequeNo + "," + Amount.ToString + "," + ErrMessage)
                    Insert2Excel(AccountNo, Amount, ChequeNo, "SIMIA", ErrMessage)
                    ResultGrid.Item(5, i).Value = ErrMessage

                    url = AccountNo & "," & "11362309201" & "," & "10000" & "," & "1" & "," & BranchNo & "," & BranchNo & "," & "1" & ",  کارمزد" & ChequeNo.Replace("/", ".")
                    Str = "http://192.168.15.17:8080/SimiaWebServiceRest/rest/regBardaasht_new/" & System.Uri.EscapeDataString(url) & "," & code
                    Dim data1 As Byte() = client.DownloadData(Str)
                    res = AjaxPro.JavaScriptDeserializer.DeserializeFromJson(System.Text.Encoding.UTF8.GetString(data1), GetType(AjaxPro.JavaScriptArray))
                    ErrMessage = res.Item("message_").Value.ToString + " " + res.Item("sequence").Value.ToString
                    tmplog.Info(url)
                    tmplog.Info("ChakavakSimiaKarmozdInserted:" + AccountNo + "," + ChequeNo + "," + Amount.ToString + "," + ErrMessage)


                    ErrMessage = ""
                    'SimiaCounter += 1
                Catch ex As Exception
                    tmplog.Info("ChakavakSimiaNotInserted:" + AccountNo + "," + ChequeNo + "," + Amount.ToString + "," + "Error in Proccessing File")
                    tmplog.Info("ChakavakSimiaNotInserted:" + ex.Message)
                    Insert2Excel(AccountNo, Amount, ChequeNo, "SIMIA", "Error in Proccessing File")
                End Try
                AccountNo = ""
                Amount = ""
                ChequeNo = ""
                BranchNo = ""
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
            tmplog.Info("ChakavakInsert2Access:" + AccountNo + "," + ChequeNo + "," + Amount.ToString + "," + ex.ToString)
        End Try
        'MsgBox("Row Added ")
    End Function

    
  
   
End Class