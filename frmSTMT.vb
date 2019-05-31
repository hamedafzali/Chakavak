Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class frmSTMT
    Function fillResultGrid()
        Try

            If ComboBox1.SelectedItem.ToString.Substring(0, 1) = "1" Then
                Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
                Dim GetDataCmd = New System.Data.SqlClient.SqlCommand
                Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.225;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
                SqlConnection1.ConnectionString = sqlConnectionString1
                SqlConnection1.Open()
                GetDataCmd.CommandText = "dbo.[STMTGetAllData]"
                GetDataCmd.CommandTimeout = 300
                GetDataCmd.Connection = SqlConnection1
                GetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
                GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
                GetDataCmd.Parameters("@Date").Value = txtDate.Text
                Dim TmpReader As SqlClient.SqlDataReader = GetDataCmd.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(TmpReader)
                ResultDataGrid.AutoGenerateColumns = True
                ResultDataGrid.DataSource = dt

                TmpReader.Close()
                SqlConnection1.Close()
            Else
                Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
                Dim GetDataCmd = New System.Data.SqlClient.SqlCommand
                Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.225;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
                SqlConnection1.ConnectionString = sqlConnectionString1
                SqlConnection1.Open()
                GetDataCmd.CommandText = "dbo.[ChakavakSTMTCompare]"
                GetDataCmd.CommandTimeout = 300
                GetDataCmd.Connection = SqlConnection1
                GetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
                GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
                GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SW", System.Data.SqlDbType.Int, 4))
                GetDataCmd.Parameters("@Date").Value = txtDate.Text
                GetDataCmd.Parameters("@SW").Value = ComboBox1.SelectedItem.ToString.Substring(0, 1) - 1
                Dim TmpReader As SqlClient.SqlDataReader = GetDataCmd.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(TmpReader)
                ResultDataGrid.AutoGenerateColumns = True
                ResultDataGrid.DataSource = dt

                TmpReader.Close()
                SqlConnection1.Close()
            End If

        Catch ex As Exception

        End Try
    End Function
    Private Sub frmSTMT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDate.Text = (New GlobalClass.FarsiDate).GetDate


    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim GetDataCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.225;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            GetDataCmd.CommandText = "dbo.[STMTDelete]"
            GetDataCmd.CommandTimeout = 300
            GetDataCmd.Connection = SqlConnection1
            GetDataCmd.CommandType = System.Data.CommandType.StoredProcedure
            GetDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            GetDataCmd.ExecuteNonQuery()
            SqlConnection1.Close()

            Dim STMTInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim Counter As Integer = 0

            STMTInsertCmd.CommandText = "dbo.[InsertSTMT]"
            STMTInsertCmd.CommandTimeout = 300
            STMTInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            STMTInsertCmd.Connection = SqlConnection1
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BkToCstmrStmtV01_GrpHdr_MsgPgntn_LastPgInd", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BkToCstmrStmtV01_GrpHdr_MsgPgntn_PgNb", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BkToCstmrStmtV01_GrpHdr_MsgId", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BkToCstmrStmtV01_GrpHdr_CreDtTm", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BkToCstmrStmtV01_GrpHdr_AddtlInf", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Acct_Id_PrtryAcct_Id", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Acct_Svcr_FinInstnId_PrtryId_Id", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Bal_Amt_Ccy", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Bal_Amt_Value", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Bal_CdtDbtInd", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Bal_Dt_DtTm", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Bal_Tp_Cd", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_CreDtTm", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item_Id", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_Amt_Ccy", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_Amt_Value", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_BkTxCd_Prtry_Cd", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_BookgDt_DtTm", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_CdtDbtInd", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_RvslInd", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_Sts", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_Refs_ChqNb", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_Refs_EndToEndId", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_Refs_InstrId", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdAgts_CdtrAgt_BrnchId_Id", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdAgts_CdtrAgt_FinInstnId_BIC", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdAgts_DbtrAgt_BrnchId_Id", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdAgts_DbtrAgt_FinInstnId_BIC", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdPties_Cdtr_Id_PrvtId_IdntyCardNb", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdPties_Cdtr_Nm", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdPties_CdtrAcct_Id_IBAN", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdPties_Dbtr_Nm", System.Data.SqlDbType.NVarChar, 100))
            STMTInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@item1_TxDtls_RltdPties_DbtrAcct_Id_IBAN", System.Data.SqlDbType.NVarChar, 100))


            Dim fd As OpenFileDialog = New OpenFileDialog()
            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\Users\Administrator\Desktop\مستندات کامل پیمانکاران - افزودن پیام متنی 17-10-93\مستندات پیمانکاران - افزودن پیام متنی 17-10-93\مستندات ارسالی برای پیمان کاران\مستند فایل STMT"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                txtFileName.Text = fd.FileName
            End If
            ' Create an instance of the XmlSerializer.
            Dim serializer As New XmlSerializer(GetType(com.cbi.chakavak.stmt.Document))

            ' Declare an object variable of the type to be deserialized.
            Dim tmpDocument As com.cbi.chakavak.stmt.Document

            Using reader As New FileStream(txtFileName.Text, FileMode.Open)

                ' Call the Deserialize method to restore the object's state.
                tmpDocument = CType(serializer.Deserialize(reader), com.cbi.chakavak.stmt.Document)
            End Using
            If tmpDocument.BkToCstmrStmtV01.Stmt.Count > 0 Then
                Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.225;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
                SqlConnection1.ConnectionString = sqlConnectionString
                SqlConnection1.Open()
                STMTInsertCmd.Parameters("@BkToCstmrStmtV01_GrpHdr_MsgPgntn_LastPgInd").Value = tmpDocument.BkToCstmrStmtV01.GrpHdr.MsgPgntn.LastPgInd 'مشخص می کند که آیا فایل آخرین قسمت یک فایل چند تکه می باشد یا خیر
                STMTInsertCmd.Parameters("@BkToCstmrStmtV01_GrpHdr_MsgPgntn_PgNb").Value = tmpDocument.BkToCstmrStmtV01.GrpHdr.MsgPgntn.PgNb 'در صورتی که فایل شامل چند قسمت باشد دراین فیلد شماره آن قسمت مشخص می گردد. لازم به ذکر است در صورت چند تکه بودن فایل MsgId هر فایل یکتا می باشد.
                STMTInsertCmd.Parameters("@BkToCstmrStmtV01_GrpHdr_MsgId").Value = tmpDocument.BkToCstmrStmtV01.GrpHdr.MsgId 'شناسه پیام که در هر روز کاری یکتا می باشد.
                STMTInsertCmd.Parameters("@BkToCstmrStmtV01_GrpHdr_CreDtTm").Value = tmpDocument.BkToCstmrStmtV01.GrpHdr.CreDtTm 'تاریخ تولید فایل می باشد.
                STMTInsertCmd.Parameters("@BkToCstmrStmtV01_GrpHdr_AddtlInf").Value = tmpDocument.BkToCstmrStmtV01.GrpHdr.AddtlInf 'توضیحات مربوط به فایل تولید شده می باشد

                For Each item In tmpDocument.BkToCstmrStmtV01.Stmt
                    STMTInsertCmd.Parameters("@item_Acct_Id_PrtryAcct_Id").Value = item.Acct.Id.PrtryAcct.Id 'BIC بانک دریافت کننده می باشد.
                    STMTInsertCmd.Parameters("@item_Acct_Svcr_FinInstnId_PrtryId_Id").Value = item.Acct.Svcr.FinInstnId.PrtryId.Id 'به صورت پیش فرض شناسه CIS می باشد.
                    'مبلغ جبری صورتحساب می باشد و بدهکاری یا بستانکاری آن توسط فیلد بعدی آن مشخص می گردد.
                    STMTInsertCmd.Parameters("@item_Bal_Amt_Ccy").Value = item.Bal.Amt.Ccy 'واحد پول که به صورت پیش فرض IRR می باشد
                    STMTInsertCmd.Parameters("@item_Bal_Amt_Value").Value = item.Bal.Amt.Value 'مبلغ جبری صورتحساب می باشد و بدهکاری یا بستانکاری آن توسط فیلد بعدی آن مشخص می گردد.
                    STMTInsertCmd.Parameters("@item_Bal_CdtDbtInd").Value = item.Bal.CdtDbtInd 'مشخص کننده بدهکاری یا بدهکاری مبلغ صورتحساب می باشد. مقادیر مجاز: CRDT : بستانکارDBIT : بدهکار
                    STMTInsertCmd.Parameters("@item_Bal_Dt_DtTm").Value = item.Bal.Dt.DtTm 'زمان ایجاد این صورتحساب را نشان می دهد
                    STMTInsertCmd.Parameters("@item_Bal_Tp_Cd").Value = item.Bal.Tp.Cd 'به صورت پیش فرض شناسه CLBD می باشد.
                    STMTInsertCmd.Parameters("@item_CreDtTm").Value = item.CreDtTm 'تاریخ تولید این صورتحساب می باشد
                    STMTInsertCmd.Parameters("@item_Id").Value = item.Id 'شناسه صورتحساب، که در یک فایل یکتا میباشد

                    For Each item1 In item.Ntry
                        STMTInsertCmd.Parameters("@item1_Amt_Ccy").Value = item1.Amt.Ccy 'واحد پول که به صورت پیش فرض IRR می باشد.
                        STMTInsertCmd.Parameters("@item1_Amt_Value").Value = item1.Amt.Value 'مبلغ جبری صورتحساب می باشد و بدهکاری یا بستانکاری آن توسط فیلد بعدی آن مشخص می گردد.
                        STMTInsertCmd.Parameters("@item1_BkTxCd_Prtry_Cd").Value = item1.BkTxCd.Prtry.Cd 'کد تراکنش که به صورت پیش فرض pacs.008.001.01 می باشد.
                        STMTInsertCmd.Parameters("@item1_BookgDt_DtTm").Value = item1.BookgDt.DtTm 'تاریخ موثر چک می باشد.
                        STMTInsertCmd.Parameters("@item1_CdtDbtInd").Value = item1.CdtDbtInd 'مشخص کننده بدهکاری یا بدهکاری مبلغ صورتحساب می باشد. مقادیر مجاز: CRDT : بستانکار DBIT : بدهکار
                        STMTInsertCmd.Parameters("@item1_RvslInd").Value = item1.RvslInd 'به صورت پیش فرض True می باشد
                        STMTInsertCmd.Parameters("@item1_Sts").Value = item1.Sts 'به صورت پیش فرض Book می باشد
                        STMTInsertCmd.Parameters("@item1_TxDtls_Refs_ChqNb").Value = item1.TxDtls.Refs.ChqNb 'شماره چک می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_Refs_EndToEndId").Value = item1.TxDtls.Refs.EndToEndId 'کد رهگیری تراکنش می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_Refs_InstrId").Value = item1.TxDtls.Refs.InstrId 'شناسه واریز می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdAgts_CdtrAgt_BrnchId_Id").Value = item1.TxDtls.RltdAgts.CdtrAgt.BrnchId.Id 'کد شعبه می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdAgts_CdtrAgt_FinInstnId_BIC").Value = item1.TxDtls.RltdAgts.CdtrAgt.FinInstnId.BIC 'شناسه بانک بستانکار می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdAgts_DbtrAgt_BrnchId_Id").Value = item1.TxDtls.RltdAgts.DbtrAgt.BrnchId.Id 'کد شعبه می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdAgts_DbtrAgt_FinInstnId_BIC").Value = item1.TxDtls.RltdAgts.DbtrAgt.FinInstnId.BIC 'شناسه بانک بدهکار می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdPties_Cdtr_Id_PrvtId_IdntyCardNb").Value = item1.TxDtls.RltdPties.Cdtr.Id.PrvtId.IdntyCardNb 'شناسه کارت ملی شخص بسانکار می باشد
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdPties_Cdtr_Nm").Value = item1.TxDtls.RltdPties.Cdtr.Nm 'نام و نام خانوادگی شخص بستانکار می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdPties_CdtrAcct_Id_IBAN").Value = item1.TxDtls.RltdPties.CdtrAcct.Id.IBAN 'شبا حساب شخص بستانکار می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdPties_Dbtr_Nm").Value = item1.TxDtls.RltdPties.Dbtr.Nm 'نام و نام خانوادگی شخص بدهکار می باشد.
                        STMTInsertCmd.Parameters("@item1_TxDtls_RltdPties_DbtrAcct_Id_IBAN").Value = item1.TxDtls.RltdPties.DbtrAcct.Id.IBAN 'شبا حساب شخص بدهکار می باشد.
                        STMTInsertCmd.ExecuteNonQuery()
                        Counter += 1
                    Next
                Next
                SqlConnection1.Close()
                MsgBox(Counter.ToString + " Row Inserted")
            Else
                MsgBox("There are't any row's for Inserted")
            End If

        Catch ex As Exception
            MsgBox("Error in File")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fillResultGrid()
    End Sub
End Class