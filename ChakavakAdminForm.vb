Imports AjaxPro
Imports System.Threading
Imports log4net
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Net

Public Class ChakavakAdminForm
    Dim CounterTotal As Integer = 0
    Dim Counter As Integer = 0
    Private ReadOnly tmplog As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub ChakavakAdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblNextUpdateRequestIn.Text = "--:--:--"
            lblNextUpdateRequestOut.Text = "--:--:--"
            lblNextUpdateRequestOutAck.Text = "--:--:--"
            lblNextUpdateResponseIn.Text = "--:--:--"
            lblNextUpdateResponseOut.Text = "--:--:--"
            lblNextUpdateResponseOutAck.Text = "--:--:--"
            lblDate.Text = (New GlobalClass.FarsiDate).GetDate()
            Timer1.Interval = 1000
            Timer1.Enabled = True
            Timer1.Start()
            Dim FillMessageThread As New System.Threading.Thread(AddressOf FillMessage)
            FillMessageThread.Start()
            'ResponseOut()
            ' ResponseOutAck()
            'RequestOut()
            ' RequestIn()
            'ResponseIn()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Try
            Dim TimeNow As String = System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Minute.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Second.ToString.PadLeft(2, "0")
            lblTime.Text = TimeString
            If CheckTimeAccess(TimeNow) = False Then Return
            txtDurationRequestIn.Text = My.Settings.RequestInTime
            txtDurationRequestOut.Text = My.Settings.RequestOutTime
            txtDurationRequestOutAck.Text = My.Settings.RequestOutTime
            txtDurationResponseIn.Text = My.Settings.ResponseInTime
            txtDurationResponseOut.Text = My.Settings.ResponseOutTime
            txtDurationResponseOutAck.Text = My.Settings.ResponseOutAckTime

            Try
                If lblNextUpdateRequestIn.Text = TimeString Then
                    Dim RequestInThread As New System.Threading.Thread(AddressOf RequestIn)
                    RequestInThread.Start()
                ElseIf lblNextUpdateRequestIn.Text <> "--:--:--" Then
                    If DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateRequestIn.Text), DateTime.Parse(TimeString)) > 180 Or DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateRequestIn.Text), DateTime.Parse(TimeString)) < -7200 Then
                        lblLastUpdateTimeRequestIn.Text = TimeString
                        lblNextUpdateRequestIn.Text = CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Second.ToString.PadLeft(2, "0")
                    End If
                End If
            Catch ex As Exception
                Logger("RequestIn", "Error in RequestInThread")
            End Try
            Try
                If lblNextUpdateRequestOut.Text = TimeString Then
                    Dim RequestOutThread As New System.Threading.Thread(AddressOf RequestOut)
                    RequestOutThread.Start()
                ElseIf lblNextUpdateRequestOut.Text <> "--:--:--" Then
                    If DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateRequestOut.Text), DateTime.Parse(TimeString)) > 180 Or DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateRequestOut.Text), DateTime.Parse(TimeString)) < -7200 Then
                        lblLastUpdateTimeRequestOut.Text = TimeString
                        lblNextUpdateRequestOut.Text = CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Second.ToString.PadLeft(2, "0")
                    End If
                End If
            Catch ex As Exception
                Logger("RequestOut", "Error in RequestOutThread")
            End Try
            Try
                If lblNextUpdateRequestOutAck.Text = TimeString Then
                    Dim RequestOutAckThread As New System.Threading.Thread(AddressOf RequestOutAck)
                    RequestOutAckThread.Start()
                ElseIf lblNextUpdateRequestOutAck.Text <> "--:--:--" Then
                    If DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateRequestOutAck.Text), DateTime.Parse(TimeString)) > 60 Or DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateRequestOutAck.Text), DateTime.Parse(TimeString)) < -7200 Then
                        lblLastUpdateTimeRequestOutAck.Text = TimeString
                        lblNextUpdateRequestOutAck.Text = CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Second.ToString.PadLeft(2, "0")
                    End If
                End If
            Catch ex As Exception
                Logger("RequestOut", "Error in RequestOutAckThread")
            End Try
            Try
                If lblNextUpdateResponseIn.Text = TimeString Then
                    Dim ResponseInThread As New System.Threading.Thread(AddressOf ResponseIn)
                    ResponseInThread.Start()
                ElseIf lblNextUpdateResponseIn.Text <> "--:--:--" Then
                    If DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateResponseIn.Text), DateTime.Parse(TimeString)) > 180 Or DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateResponseIn.Text), DateTime.Parse(TimeString)) < -7200 Then
                        lblLastUpdateTimeResponseIn.Text = TimeString
                        lblNextUpdateResponseIn.Text = CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Second.ToString.PadLeft(2, "0")
                    End If
                End If
            Catch ex As Exception
                Logger("ResponseIn", "Error in ResponseInThread")
            End Try
            Try
                If lblNextUpdateResponseOut.Text = TimeString Then
                    Dim ResponseOutThread As New System.Threading.Thread(AddressOf ResponseOut)
                    ResponseOutThread.Start()
                ElseIf lblNextUpdateResponseOut.Text <> "--:--:--" Then
                    If DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateResponseOut.Text), DateTime.Parse(TimeString)) > 180 Or DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateResponseOut.Text), DateTime.Parse(TimeString)) < -7200 Then
                        lblLastUpdateTimeResponseOut.Text = TimeString
                        lblNextUpdateResponseOut.Text = CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Second.ToString.PadLeft(2, "0")
                    End If
                End If
            Catch ex As Exception
                Logger("ResponseOut", "Error in ResponseOutThread")
            End Try
            Try
                If lblNextUpdateResponseOutAck.Text = TimeString Then
                    Dim ResponseOutAckThread As New System.Threading.Thread(AddressOf ResponseOutAck)
                    ResponseOutAckThread.Start()
                ElseIf lblNextUpdateResponseOutAck.Text <> "--:--:--" Then
                    If DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateResponseOutAck.Text), DateTime.Parse(TimeString)) > 60 Or DateDiff(DateInterval.Second, DateTime.Parse(lblNextUpdateResponseOutAck.Text), DateTime.Parse(TimeString)) < -7200 Then
                        lblLastUpdateTimeResponseOutAck.Text = TimeString
                        lblNextUpdateResponseOutAck.Text = CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Second.ToString.PadLeft(2, "0")
                    End If
                End If
            Catch ex As Exception
                Logger("ResponseOut", "Error in ResponseOutThread")
            End Try
            Try

                If Date.Now.Second.ToString = "30" Or Date.Now.Second.ToString = "00" Then
                    Dim FillMessageThread As New System.Threading.Thread(AddressOf FillMessage)
                    FillMessageThread.Start()

                End If
            Catch ex As Exception

            End Try


            Application.DoEvents()

        Catch ex As Exception

        End Try
    End Sub
    Function RequestOut()
        Try

            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            'Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            'Dim AuthorisedInsertCmd = New System.Data.SqlClient.SqlCommand
            'Dim ExtractCommonIdCmd = New System.Data.SqlClient.SqlCommand

            'ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
            'ChakavakInsertCmd.CommandTimeout = 300
            'ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            'ChakavakInsertCmd.Connection = SqlConnection1
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_ChequeId", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_DepositDate", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_SettlementDate", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_Amount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_UserName", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Submitter", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Priority", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_Name", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BIC", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_Name", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BIC", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Front", System.Data.SqlDbType.VarBinary, 2147483647))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Back", System.Data.SqlDbType.VarBinary, 2147483647))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_AccountType", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_ReferTo", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Name", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OfficeCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_FatherName", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_NationalID", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode2", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address1", System.Data.SqlDbType.NVarChar, 500))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address2", System.Data.SqlDbType.NVarChar, 500))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel1", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel2", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChequeType", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransferDate", System.Data.SqlDbType.NVarChar, 10))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 10))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))

            ''ExtractCommonId
            ''
            'ExtractCommonIdCmd.CommandText = "dbo.[ChakavakExtractCommonId]"
            'ExtractCommonIdCmd.CommandTimeout = 300
            'ExtractCommonIdCmd.CommandType = System.Data.CommandType.StoredProcedure
            'ExtractCommonIdCmd.Connection = SqlConnection1
            'ExtractCommonIdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ExtractCommonIdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            'ExtractCommonIdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))


            'Dim list As New List(Of String)
            'Dim tmpChakavakServiceClient1 As New ChakavakServiceWS.ChakavakServiceClient
            'Try

            '    Dim data As String = tmpChakavakServiceClient1.GetRequestInAcknowledgeNotProcessed()
            '    Dim tmpCheque() As com.cbi.chakavak.chequeSchema.Cheque
            '    tmpCheque = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Cheque())(data)
            '    Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            '    SqlConnection1.ConnectionString = sqlConnectionString
            '    SqlConnection1.Open()
            '    For Each item In tmpCheque


            '        ' Dim id As Guid
            '        'id = Guid.NewGuid
            '        Dim tmpacknowledge As com.cbi.chakavak.chequeSchema.Acknowledge
            '        tmpacknowledge = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Acknowledge)(item.Body.Item.ToString)

            '        ChakavakInsertCmd.Parameters("@h_chequeid").Value = item.Header.ChequeID
            '        ' ChakavakInsertCmd.Parameters("@commonid").Value = id
            '        ChakavakInsertCmd.Parameters("@h_depositdate").Value = item.Header.DepositDate
            '        ChakavakInsertCmd.Parameters("@h_settlementdate").Value = item.Header.SettlementDate
            '        ChakavakInsertCmd.Parameters("@h_amount").Value = item.Header.Amount
            '        ChakavakInsertCmd.Parameters("@h_username").Value = item.Header.UserName
            '        ChakavakInsertCmd.Parameters("@res_trn").Value = tmpacknowledge.TRN
            '        ChakavakInsertCmd.Parameters("@rqs_seqno").Value = tmpacknowledge.TRN
            '        ChakavakInsertCmd.Parameters("@res_status").Value = tmpacknowledge.Status
            '        ChakavakInsertCmd.Parameters("@res_reason").Value = tmpacknowledge.Reason
            '        ChakavakInsertCmd.Parameters("@dbt_name").Value = tmpacknowledge.Debtor.Name
            '        ChakavakInsertCmd.Parameters("@dbt_iban").Value = tmpacknowledge.Debtor.IBAN
            '        ChakavakInsertCmd.Parameters("@dbt_bic").Value = tmpacknowledge.Debtor.BIC
            '        ChakavakInsertCmd.Parameters("@dbt_branchcode").Value = tmpacknowledge.Debtor.BranchCode
            '        ChakavakInsertCmd.Parameters("@crt_name").Value = tmpacknowledge.Creditor.Name
            '        ChakavakInsertCmd.Parameters("@crt_iban").Value = tmpacknowledge.Creditor.IBAN
            '        ChakavakInsertCmd.Parameters("@crt_nationalcode").Value = tmpacknowledge.Creditor.NationalCode
            '        ChakavakInsertCmd.Parameters("@crt_bic").Value = tmpacknowledge.Creditor.BIC
            '        ChakavakInsertCmd.Parameters("@crt_branchcode").Value = tmpacknowledge.Creditor.BranchCode
            '        ChakavakInsertCmd.Parameters("@userid").Value = 1
            '        ChakavakInsertCmd.Parameters("@chequetype").Value = 1
            '        ChakavakInsertCmd.Parameters("@branchid").Value = 517
            '        ChakavakInsertCmd.Parameters("@status").Value = 22 'ack
            '        ChakavakInsertCmd.Parameters("@transferdate").Value = item.Header.DepositDate '"" 'tmprequest.seqno
            '        If (tmpacknowledge.Status = "CANCEL") Then
            '            ChakavakInsertCmd.Parameters("@kelertype").Value = 2
            '        Else
            '            ChakavakInsertCmd.Parameters("@kelertype").Value = 1
            '        End If
            '        ExtractCommonIdCmd.Parameters("@RES_TRN").Value = tmpacknowledge.TRN
            '        ExtractCommonIdCmd.ExecuteNonQuery()
            '        ChakavakInsertCmd.Parameters("@CommonId").Value = ExtractCommonIdCmd.Parameters("@@CommonId").Value
            '        ChakavakInsertCmd.ExecuteNonQuery()
            '        If ChakavakInsertCmd.Parameters("@return_value").Value = 1 Then
            '            list.Add(tmpacknowledge.TRN)
            '        End If
            '    Next
            '    SqlConnection1.Close()
            'Catch ex As Exception
            '    Logger("requestout", "error insert acknowledge")
            'End Try
            'Dim WSResult As New Chakavak.ChakavakServiceWS.Result
            'WSResult = tmpChakavakServiceClient1.UpdateRequestInAcknowledgeItemsByTRN(list.ToArray)
            'If WSResult.Type.Success = ChakavakServiceWS.ResultType.Success Then Logger("RequestOut", list.Count.ToString + " Acknowledges Updated") Else Logger("RequestOut", "Acknowledges Not Updated")



            Counter = 0
            Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString
            Dim ChakavakRequestGetAllDataCmd = New System.Data.SqlClient.SqlCommand
            ChakavakRequestGetAllDataCmd.CommandText = "dbo.[ChakavakRequestGetAllDataNew]"
            ChakavakRequestGetAllDataCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakRequestGetAllDataCmd.CommandTimeout = 300
            ChakavakRequestGetAllDataCmd.Connection = SqlConnection1
            ChakavakRequestGetAllDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            SqlConnection1.Open()

            Dim Reader As SqlClient.SqlDataReader = ChakavakRequestGetAllDataCmd.ExecuteReader
            While Reader.Read()
                Counter = Counter + 1
                Dim tmpChequeRequest As New ChakavakServiceWS.ChequeRequest
                Dim tmpChequeRequestHeader As New ChakavakServiceWS.Header
                Dim tmpRequest As New ChakavakServiceWS.Request
                Dim tmpDebtor As New ChakavakServiceWS.Debtor
                Dim tmpCreditor As New ChakavakServiceWS.Creditor
                Dim tmpRequestData As New ChakavakServiceWS.RequestData

                tmpChequeRequestHeader.chequeIDField = Reader.Item(0)
                tmpChequeRequestHeader.depositDateField = Reader.Item(1)
                tmpChequeRequestHeader.settlementDateField = Reader.Item(2)
                tmpChequeRequestHeader.amountField = Reader.Item(3)
                tmpChequeRequestHeader.userNameField = Reader.Item(4)
                tmpChequeRequest.Header = tmpChequeRequestHeader

                tmpRequest.submitterField = Reader.Item(5)
                tmpRequest.priorityField = Reader.Item(6)
                tmpRequest.seqNoField = Reader.Item(7)
                tmpRequest.partialSettlementField = CType(Reader.Item(8), Boolean)
                tmpRequest.codedField = CType(Reader.Item(9), Boolean)
                tmpRequest.prominentStampField = CType(Reader.Item(10), Boolean)
                tmpRequest.regressiveField = Reader.Item(11)
                tmpRequest.instrIdField = Reader.Item(12)
                tmpChequeRequest.Request = tmpRequest

                If Not IsDBNull(Reader.Item(13)) Then tmpDebtor.nameField = Reader.Item(13) Else tmpDebtor.nameField = ""
                If Not IsDBNull(Reader.Item(14)) Then tmpDebtor.iBANField = Reader.Item(14) Else tmpDebtor.iBANField = ""
                If Not IsDBNull(Reader.Item(15)) Then tmpDebtor.bICField = Reader.Item(15) Else tmpDebtor.bICField = ""
                If Not IsDBNull(Reader.Item(16)) Then tmpDebtor.branchCodeField = Reader.Item(16) Else tmpDebtor.branchCodeField = ""
                tmpRequest.debtorField = tmpDebtor

                tmpCreditor.nameField = Reader.Item(17)
                tmpCreditor.iBANField = Reader.Item(18)
                tmpCreditor.nationalCodeField = Reader.Item(19)
                tmpCreditor.bICField = Reader.Item(20)
                tmpCreditor.branchCodeField = Reader.Item(21)
                tmpRequest.creditorField = tmpCreditor

                tmpRequestData.frontField = Reader.Item(22)
                tmpRequestData.backField = Reader.Item(23)
                tmpRequest.requestDataField = tmpRequestData

                Dim tmpChakavakServiceClient As New ChakavakServiceWS.ChakavakServiceClient
                Dim tmpResult As New ChakavakServiceWS.Result
                tmpResult = tmpChakavakServiceClient.PutRequestOutChequeRequest(tmpChequeRequest)
                If Not tmpResult.Type = ChakavakServiceWS.ResultType.Success Then Logger("RequestOut", tmpResult.Message)
            End While
            Reader.Close()
            'Dim ChakavakRequestupdateCmd = New System.Data.SqlClient.SqlCommand
            'ChakavakRequestupdateCmd.CommandText = "dbo.[ChakavakRequestupdate]"
            'ChakavakRequestupdateCmd.CommandType = System.Data.CommandType.StoredProcedure
            'ChakavakRequestupdateCmd.Connection = SqlConnection1
            'ChakavakRequestupdateCmd.CommandTimeout = 300
            'ChakavakRequestupdateCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakRequestupdateCmd.ExecuteNonQuery()
            SqlConnection1.Close()
            CounterTotal = CounterTotal + Counter
            
            Logger("RequestOut", Counter.ToString + " Succsess")
            lblLastUpdateTimeRequestOut.Text = lblTime.Text
            lblNextUpdateRequestOut.Text = CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Second.ToString.PadLeft(2, "0")

        Catch ex As Exception
            Logger("RequestOut", ex.ToString)
            lblLastUpdateTimeRequestOut.Text = lblTime.Text
            lblNextUpdateRequestOut.Text = CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Second.ToString.PadLeft(2, "0")

        End Try
    End Function
    Function RequestOutAck()
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim AuthorisedInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim ExtractCommonIdCmd = New System.Data.SqlClient.SqlCommand

            ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
            ChakavakInsertCmd.CommandTimeout = 300
            ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakInsertCmd.Connection = SqlConnection1
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_ChequeId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_DepositDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_SettlementDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_Amount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_UserName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Submitter", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Priority", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Front", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Back", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_AccountType", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_ReferTo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OfficeCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_FatherName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_NationalID", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address1", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address2", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChequeType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransferDate", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))

            'ExtractCommonId
            '
            ExtractCommonIdCmd.CommandText = "dbo.[ChakavakExtractCommonId]"
            ExtractCommonIdCmd.CommandTimeout = 300
            ExtractCommonIdCmd.CommandType = System.Data.CommandType.StoredProcedure
            ExtractCommonIdCmd.Connection = SqlConnection1
            ExtractCommonIdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ExtractCommonIdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ExtractCommonIdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))


            Dim list As New List(Of String)
            Dim tmpChakavakServiceClient1 As New ChakavakServiceWS.ChakavakServiceClient
            Try

                Dim data As String = tmpChakavakServiceClient1.GetRequestInAcknowledgeNotProcessed()
                Dim tmpCheque() As com.cbi.chakavak.chequeSchema.Cheque
                tmpCheque = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Cheque())(data)
                Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
                SqlConnection1.ConnectionString = sqlConnectionString
                SqlConnection1.Open()
                For Each item In tmpCheque


                    ' Dim id As Guid
                    'id = Guid.NewGuid
                    Dim tmpacknowledge As com.cbi.chakavak.chequeSchema.Acknowledge
                    tmpacknowledge = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Acknowledge)(item.Body.Item.ToString)

                    ChakavakInsertCmd.Parameters("@h_chequeid").Value = item.Header.ChequeID
                    ' ChakavakInsertCmd.Parameters("@commonid").Value = id
                    ChakavakInsertCmd.Parameters("@h_depositdate").Value = item.Header.DepositDate
                    ChakavakInsertCmd.Parameters("@h_settlementdate").Value = item.Header.SettlementDate
                    ChakavakInsertCmd.Parameters("@h_amount").Value = item.Header.Amount
                    ChakavakInsertCmd.Parameters("@h_username").Value = item.Header.UserName
                    ChakavakInsertCmd.Parameters("@res_trn").Value = tmpacknowledge.TRN
                    ChakavakInsertCmd.Parameters("@rqs_seqno").Value = tmpacknowledge.TRN
                    ChakavakInsertCmd.Parameters("@res_status").Value = tmpacknowledge.Status
                    ChakavakInsertCmd.Parameters("@res_reason").Value = tmpacknowledge.Reason
                    ChakavakInsertCmd.Parameters("@dbt_name").Value = tmpacknowledge.Debtor.Name
                    ChakavakInsertCmd.Parameters("@dbt_iban").Value = tmpacknowledge.Debtor.IBAN
                    ChakavakInsertCmd.Parameters("@dbt_bic").Value = tmpacknowledge.Debtor.BIC
                    ChakavakInsertCmd.Parameters("@dbt_branchcode").Value = tmpacknowledge.Debtor.BranchCode
                    ChakavakInsertCmd.Parameters("@crt_name").Value = tmpacknowledge.Creditor.Name
                    ChakavakInsertCmd.Parameters("@crt_iban").Value = tmpacknowledge.Creditor.IBAN
                    ChakavakInsertCmd.Parameters("@crt_nationalcode").Value = tmpacknowledge.Creditor.NationalCode
                    ChakavakInsertCmd.Parameters("@crt_bic").Value = tmpacknowledge.Creditor.BIC
                    ChakavakInsertCmd.Parameters("@crt_branchcode").Value = tmpacknowledge.Creditor.BranchCode
                    ChakavakInsertCmd.Parameters("@userid").Value = 1
                    ChakavakInsertCmd.Parameters("@chequetype").Value = 1
                    ChakavakInsertCmd.Parameters("@branchid").Value = 517
                    ChakavakInsertCmd.Parameters("@status").Value = 22 'ack
                    ChakavakInsertCmd.Parameters("@transferdate").Value = item.Header.DepositDate '"" 'tmprequest.seqno
                    If (tmpacknowledge.Status = "CANCEL") Then
                        ChakavakInsertCmd.Parameters("@kelertype").Value = 2
                    Else
                        ChakavakInsertCmd.Parameters("@kelertype").Value = 1
                    End If
                    ExtractCommonIdCmd.Parameters("@RES_TRN").Value = tmpacknowledge.TRN
                    ExtractCommonIdCmd.ExecuteNonQuery()
                    ChakavakInsertCmd.Parameters("@CommonId").Value = ExtractCommonIdCmd.Parameters("@@CommonId").Value
                    ChakavakInsertCmd.ExecuteNonQuery()
                    If ChakavakInsertCmd.Parameters("@return_value").Value = 1 Then
                        list.Add(tmpacknowledge.TRN)
                    End If
                Next
                SqlConnection1.Close()
            Catch ex As Exception
                Logger("requestout", "error insert acknowledge")
            End Try
            Dim WSResult As New Chakavak.ChakavakServiceWS.Result
            WSResult = tmpChakavakServiceClient1.UpdateRequestInAcknowledgeItemsByTRN(list.ToArray)
            If WSResult.Type.Success = ChakavakServiceWS.ResultType.Success Then Logger("RequestOut", list.Count.ToString + " Acknowledges Updated") Else Logger("RequestOut", "Acknowledges Not Updated")

            lblLastUpdateTimeRequestOutAck.Text = lblTime.Text
            lblNextUpdateRequestOutAck.Text = CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Second.ToString.PadLeft(2, "0")

        Catch ex As Exception
            Logger("RequestOut", "RequestOutAck " + ex.ToString)
            lblLastUpdateTimeRequestOutAck.Text = lblTime.Text
            lblNextUpdateRequestOutAck.Text = CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Second.ToString.PadLeft(2, "0")

        End Try
    End Function
    Function RequestIn()
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim AuthorisedInsertCmd = New System.Data.SqlClient.SqlCommand

            ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
            ChakavakInsertCmd.CommandTimeout = 300
            ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakInsertCmd.Connection = SqlConnection1
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_ChequeId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_DepositDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_SettlementDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_Amount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_UserName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Submitter", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Priority", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Front", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Back", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_AccountType", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_ReferTo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OfficeCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_FatherName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_NationalID", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address1", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address2", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChequeType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransferDate", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))

            Dim tmpChakavakServiceClient As New ChakavakServiceWS.ChakavakServiceClient
            Dim Data As String = tmpChakavakServiceClient.GetRequestInChequeRequest()

            Dim res As New AjaxPro.JavaScriptArray
            res = AjaxPro.JavaScriptDeserializer.DeserializeFromJson(Data, GetType(AjaxPro.JavaScriptArray))
            '--------------------------------------------
            Dim tmpChequeRequest() As com.cbi.chakavak.chequeSchema.Cheque
            Dim tmpRequest As com.cbi.chakavak.chequeSchema.Request
            tmpChequeRequest = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Cheque())(Data)
            Dim list As New List(Of String)
            
            Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString
            SqlConnection1.Open()

            For Each item In tmpChequeRequest
                tmpRequest = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Request)(item.Body.Item.ToString)
                Dim Id As Guid
                Id = Guid.NewGuid
                '----------------for cheque header ----------------
                ChakavakInsertCmd.Parameters("@H_ChequeId").Value = item.Header.ChequeID
                ChakavakInsertCmd.Parameters("@CommonId").Value = Id
                ChakavakInsertCmd.Parameters("@H_DepositDate").Value = item.Header.DepositDate
                ChakavakInsertCmd.Parameters("@H_SettlementDate").Value = item.Header.SettlementDate
                ChakavakInsertCmd.Parameters("@H_Amount").Value = item.Header.Amount
                ChakavakInsertCmd.Parameters("@H_UserName").Value = item.Header.UserName
                ChakavakInsertCmd.Parameters("@RQS_Submitter").Value = tmpRequest.Submitter
                ChakavakInsertCmd.Parameters("@RQS_Priority").Value = tmpRequest.Priority
                ChakavakInsertCmd.Parameters("@RQS_SeqNo").Value = tmpRequest.SeqNo
                ChakavakInsertCmd.Parameters("@RQS_PartialSettlement").Value = tmpRequest.PartialSettlement
                ChakavakInsertCmd.Parameters("@RQS_Coded").Value = tmpRequest.Coded
                ChakavakInsertCmd.Parameters("@RQS_ProminentStamp").Value = tmpRequest.ProminentStamp
                ChakavakInsertCmd.Parameters("@RQS_Regressive").Value = tmpRequest.Regressive
                ChakavakInsertCmd.Parameters("@RQS_InstrId").Value = tmpRequest.InstrId
                ChakavakInsertCmd.Parameters("@DBT_Name").Value = tmpRequest.Debtor.Name
                ChakavakInsertCmd.Parameters("@DBT_IBAN").Value = tmpRequest.Debtor.IBAN
                ChakavakInsertCmd.Parameters("@DBT_BIC").Value = tmpRequest.Debtor.BIC
                ChakavakInsertCmd.Parameters("@DBT_BranchCode").Value = tmpRequest.Debtor.BranchCode
                ChakavakInsertCmd.Parameters("@CRT_Name").Value = tmpRequest.Creditor.Name
                ChakavakInsertCmd.Parameters("@CRT_IBAN").Value = tmpRequest.Creditor.IBAN
                ChakavakInsertCmd.Parameters("@CRT_NationalCode").Value = tmpRequest.Creditor.NationalCode
                ChakavakInsertCmd.Parameters("@CRT_BIC").Value = tmpRequest.Creditor.BIC
                ChakavakInsertCmd.Parameters("@CRT_BranchCode").Value = tmpRequest.Creditor.BranchCode
                ChakavakInsertCmd.Parameters("@RQSD_Front").Value = tmpRequest.RequestData.Front
                ChakavakInsertCmd.Parameters("@RQSD_Back").Value = tmpRequest.RequestData.Back
                ChakavakInsertCmd.Parameters("@UserId").Value = 1
                ChakavakInsertCmd.Parameters("@BranchId").Value = 517
                ChakavakInsertCmd.Parameters("@Status").Value = 1
                ChakavakInsertCmd.Parameters("@TransferDate").Value = item.Header.DepositDate
                ChakavakInsertCmd.Parameters("@KelerType").Value = 2
                If tmpRequest.Coded = True Then
                    ChakavakInsertCmd.Parameters("@ChequeType").Value = 2
                Else
                    ChakavakInsertCmd.Parameters("@ChequeType").Value = 1
                End If
                'Logger("RequestIn", tmpRequest.SeqNo.ToString + " Success")
                ChakavakInsertCmd.ExecuteNonQuery()
                If ChakavakInsertCmd.Parameters("@RETURN_VALUE").Value = 1 Then
                    list.Add(tmpRequest.SeqNo)
                End If
            Next
            Dim WSResult As New Chakavak.ChakavakServiceWS.Result
            Try
                WSResult = tmpChakavakServiceClient.UpdateRequestInItemsBySeqNo(list.ToArray)

            Catch ex1 As Exception
                Logger("RequestIn", "Error in RequestInArray" + ex1.ToString)
            End Try




            '--------------------------------------------
            Logger("RequestIn", res.Count.ToString + " Success")
            
            lblLastUpdateTimeRequestIn.Text = lblTime.Text
            lblNextUpdateRequestIn.Text = CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Second.ToString.PadLeft(2, "0")

        Catch ex As Exception
            Logger("RequestIn", ex.ToString)

            lblLastUpdateTimeRequestIn.Text = lblTime.Text
            lblNextUpdateRequestIn.Text = CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Second.ToString.PadLeft(2, "0")

        End Try
    End Function
    Function ResponseIn()
        Try

            '------------------------------------------------------------------
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim AuthorisedInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim ChakavakExtractOldDataCmd = New System.Data.SqlClient.SqlCommand
            Dim list As New List(Of String)
            ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
            ChakavakInsertCmd.CommandTimeout = 300
            ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakInsertCmd.Connection = SqlConnection1
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_ChequeId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_DepositDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_SettlementDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_Amount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_UserName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Submitter", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Priority", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Front", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Back", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_AccountType", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_ReferTo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OfficeCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_FatherName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_NationalID", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address1", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address2", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChequeType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransferDate", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))



            'AuthorisedInsert()

            AuthorisedInsertCmd.CommandText = "dbo.[ChakavakNonPaymentCertificateAuthorisedInsert]"
            AuthorisedInsertCmd.CommandTimeout = 300
            AuthorisedInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            AuthorisedInsertCmd.Connection = SqlConnection1
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_FullName", System.Data.SqlDbType.NVarChar, 200))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_FatherName", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_NationalID", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_Address1", System.Data.SqlDbType.NVarChar, 500))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_Tel1", System.Data.SqlDbType.NVarChar, 50))
            AuthorisedInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCAth_ReferTo", System.Data.SqlDbType.NVarChar, 200))

            '
            'ChakavakExtractOldDataCmd
            '
            ChakavakExtractOldDataCmd.CommandText = "dbo.[ChakavakExtractOldData]"
            ChakavakExtractOldDataCmd.CommandTimeout = 300
            ChakavakExtractOldDataCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakExtractOldDataCmd.Connection = SqlConnection1
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@RQS_Coded", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@DBT_Name", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@DBT_BIC", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CRT_Name", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CRT_BIC", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@ChequeType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakExtractOldDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@@BranchId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            '------------------------------------------------------------------

            Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString
            SqlConnection1.Open()

            Dim tmpChakavakServiceClient As New ChakavakServiceWS.ChakavakServiceClient
            Dim Data As String = tmpChakavakServiceClient.GetResponseInChequeResponse()
            Dim tmpChequeResponse() As com.cbi.chakavak.chequeSchema.Cheque
            Dim tmpResponse() As com.cbi.chakavak.chequeSchema.Response
            Dim tmpNonPaymentCertificate As com.cbi.chakavak.chequeSchema.NonPaymentCertificate
            Dim tmpChequeIssuer As com.cbi.chakavak.chequeSchema.ChequeIssuer
            Dim tmpAuthorised() As com.cbi.chakavak.chequeSchema.Authorised
            tmpChequeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Cheque())(Data)
            Dim Id As Guid
            Id = Guid.NewGuid
            If tmpChequeResponse.Count > 0 Then
                For Each item In tmpChequeResponse
                    tmpResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Response())("[" + item.Body.Item.ToString + "]")
                    'Header

                    '----------------for cheque header ----------------
                    ChakavakInsertCmd.Parameters("@H_ChequeId").Value = item.Header.ChequeID
                    ChakavakInsertCmd.Parameters("@H_DepositDate").Value = item.Header.DepositDate
                    ChakavakInsertCmd.Parameters("@H_SettlementDate").Value = item.Header.SettlementDate
                    ChakavakInsertCmd.Parameters("@H_Amount").Value = item.Header.Amount
                    ChakavakInsertCmd.Parameters("@H_UserName").Value = item.Header.UserName

                    'Response
                    For Each tmpResponseitem In tmpResponse

                        ChakavakInsertCmd.Parameters("@RES_Status").Value = tmpResponseitem.Status
                        ChakavakInsertCmd.Parameters("@RQS_SeqNo").Value = tmpResponseitem.SeqNo
                        ChakavakInsertCmd.Parameters("@RES_TRN").Value = tmpResponseitem.TRN
                        ChakavakInsertCmd.Parameters("@RQS_Submitter").Value = tmpResponseitem.Submitter
                        ChakavakInsertCmd.Parameters("@RES_Amendatory").Value = tmpResponseitem.Amendatory
                        ChakavakInsertCmd.Parameters("@RES_Reason").Value = tmpResponseitem.Reason


                        'NonPaymentCertificate
                        tmpNonPaymentCertificate = tmpResponseitem.NonPaymentCertificate
                        If Not tmpNonPaymentCertificate Is Nothing Then
                            'ChequeIssuer
                            tmpChequeIssuer = tmpResponseitem.NonPaymentCertificate.ChequeIssuer

                            ChakavakInsertCmd.Parameters("@NPCCI_AccountType").Value = tmpChequeIssuer.AccountType
                            ChakavakInsertCmd.Parameters("@NPCCI_ReferTo").Value = tmpChequeIssuer.referTo
                            ChakavakInsertCmd.Parameters("@NPCCI_Name").Value = tmpChequeIssuer.Name
                            ChakavakInsertCmd.Parameters("@NPCCI_BirthCertNumOrRegNum").Value = tmpChequeIssuer.BirthCertNumOrRegNum
                            ChakavakInsertCmd.Parameters("@NPCCI_BirthDateOrRegDate").Value = tmpChequeIssuer.BirthDateOrRegDate
                            ChakavakInsertCmd.Parameters("@NPCCI_IssueLocationOrRegLocation").Value = tmpChequeIssuer.IssueLocationOrRegLocation
                            ChakavakInsertCmd.Parameters("@NPCCI_LocationCode").Value = tmpChequeIssuer.LocationCode
                            ChakavakInsertCmd.Parameters("@NPCCI_OfficeCode").Value = tmpChequeIssuer.OfficeCode
                            ChakavakInsertCmd.Parameters("@NPCCI_FatherName").Value = tmpChequeIssuer.FatherName
                            ChakavakInsertCmd.Parameters("@NPCCI_NationalID").Value = tmpChequeIssuer.NationalID
                            ChakavakInsertCmd.Parameters("@NPCCI_PostalCode1").Value = tmpChequeIssuer.PostalCode1
                            ChakavakInsertCmd.Parameters("@NPCCI_PostalCode2").Value = tmpChequeIssuer.PostalCode2
                            ChakavakInsertCmd.Parameters("@NPCCI_Address1").Value = tmpChequeIssuer.Address1
                            ChakavakInsertCmd.Parameters("@NPCCI_Address2").Value = tmpChequeIssuer.Address2
                            ChakavakInsertCmd.Parameters("@NPCCI_Tel1").Value = tmpChequeIssuer.Tel1
                            ChakavakInsertCmd.Parameters("@NPCCI_Tel2").Value = tmpChequeIssuer.Tel2
                            ChakavakInsertCmd.Parameters("@NPCCI_CurAccBal").Value = tmpChequeIssuer.CurAccBal
                            ChakavakInsertCmd.Parameters("@NPCCI_OnIssueDateAccBal").Value = tmpChequeIssuer.OnIssueDateAccBal
                            ChakavakInsertCmd.Parameters("@NPCCI_IsSettled").Value = tmpChequeIssuer.IsSettled
                            ChakavakInsertCmd.Parameters("@NPC_OtherAuthorise").Value = tmpNonPaymentCertificate.OtherAuthorised

                        End If

                        '------------------------------------------------
                        'call chakavak Insert
                        ChakavakExtractOldDataCmd.Parameters("@RES_TRN").Value = tmpResponseitem.TRN
                        ChakavakExtractOldDataCmd.ExecuteNonQuery()
                        ChakavakInsertCmd.Parameters("@RQS_Coded").Value = ChakavakExtractOldDataCmd.Parameters("@@RQS_Coded").Value
                        ChakavakInsertCmd.Parameters("@RQS_ProminentStamp").Value = ChakavakExtractOldDataCmd.Parameters("@@RQS_ProminentStamp").Value
                        ChakavakInsertCmd.Parameters("@DBT_Name").Value = ChakavakExtractOldDataCmd.Parameters("@@DBT_Name").Value
                        ChakavakInsertCmd.Parameters("@DBT_IBAN").Value = ChakavakExtractOldDataCmd.Parameters("@@DBT_IBAN").Value
                        ChakavakInsertCmd.Parameters("@DBT_BIC").Value = ChakavakExtractOldDataCmd.Parameters("@@DBT_BIC").Value
                        ChakavakInsertCmd.Parameters("@DBT_BranchCode").Value = ChakavakExtractOldDataCmd.Parameters("@@DBT_BranchCode").Value
                        ChakavakInsertCmd.Parameters("@CRT_Name").Value = ChakavakExtractOldDataCmd.Parameters("@@CRT_Name").Value
                        ChakavakInsertCmd.Parameters("@CRT_IBAN").Value = ChakavakExtractOldDataCmd.Parameters("@@CRT_IBAN").Value
                        ChakavakInsertCmd.Parameters("@CRT_NationalCode").Value = ChakavakExtractOldDataCmd.Parameters("@@CRT_NationalCode").Value
                        ChakavakInsertCmd.Parameters("@CRT_BIC").Value = ChakavakExtractOldDataCmd.Parameters("@@CRT_BIC").Value
                        ChakavakInsertCmd.Parameters("@CRT_BranchCode").Value = ChakavakExtractOldDataCmd.Parameters("@@CRT_BranchCode").Value

                        '----------------for cheque body request ----------------

                        ChakavakInsertCmd.Parameters("@UserId").Value = 1
                        ChakavakInsertCmd.Parameters("@BranchId").Value = 517

                        Select Case tmpResponseitem.Status
                            Case "REJECTED"
                                ChakavakInsertCmd.Parameters("@Status").Value = 4
                            Case "APPROVED"
                                ChakavakInsertCmd.Parameters("@Status").Value = 3

                            Case "CODED"
                                ChakavakInsertCmd.Parameters("@Status").Value = 3

                            Case "REJECT_WITHOUT_NONPAYMENT"
                                ChakavakInsertCmd.Parameters("@Status").Value = 11

                        End Select
                        ' ChakavakInsertCmd.Parameters("@Status").Value = 1
                        ChakavakInsertCmd.Parameters("@TransferDate").Value = item.Header.DepositDate
                        ChakavakInsertCmd.Parameters("@KelerType").Value = 1
                        ChakavakInsertCmd.Parameters("@CommonId").Value = Id
                        ChakavakInsertCmd.ExecuteNonQuery()
                        list.Add(tmpResponseitem.SeqNo)
                        If Not tmpNonPaymentCertificate Is Nothing Then
                            'tmpAuthorised
                            tmpAuthorised = tmpResponseitem.NonPaymentCertificate.Authorised
                            If Not tmpAuthorised Is Nothing Then
                                For Each Authoriseditem In tmpAuthorised
                                    AuthorisedInsertCmd.Parameters("@CommonId").Value = Id
                                    AuthorisedInsertCmd.ExecuteNonQuery()
                                    AuthorisedInsertCmd.Parameters("@NPCAth_FullName").Value = Authoriseditem.FullName
                                    AuthorisedInsertCmd.Parameters("@NPCAth_BirthCertNumOrRegNum").Value = Authoriseditem.BirthCertNumOrRegNum
                                    AuthorisedInsertCmd.Parameters("@NPCAth_BirthDateOrRegDate").Value = Authoriseditem.BirthDateOrRegDate
                                    AuthorisedInsertCmd.Parameters("@NPCAth_IssueLocationOrRegLocation").Value = Authoriseditem.IssueLocationOrRegLocation
                                    AuthorisedInsertCmd.Parameters("@NPCAth_LocationCode").Value = Authoriseditem.LocationCode
                                    AuthorisedInsertCmd.Parameters("@NPCAth_FatherName").Value = Authoriseditem.FatherName
                                    AuthorisedInsertCmd.Parameters("@NPCAth_NationalID").Value = Authoriseditem.NationalID
                                    AuthorisedInsertCmd.Parameters("@NPCAth_PostalCode1").Value = Authoriseditem.PostalCode1
                                    AuthorisedInsertCmd.Parameters("@NPCAth_Address1").Value = Authoriseditem.Address1
                                    AuthorisedInsertCmd.Parameters("@NPCAth_Tel1").Value = Authoriseditem.Tel1
                                    AuthorisedInsertCmd.Parameters("@NPCAth_ReferTo").Value = Authoriseditem.referTo

                                    AuthorisedInsertCmd.ExecuteNonQuery()

                                Next
                            End If
                        End If


                    Next
                Next
                Dim WSResult As New Chakavak.ChakavakServiceWS.Result
                WSResult = tmpChakavakServiceClient.UpdateResponseInItemsBySeqNo(list.ToArray)

            End If
            Logger("ResponseIn", tmpChequeResponse.Count.ToString + " Success")

            lblLastUpdateTimeResponseIn.Text = lblTime.Text
            lblNextUpdateResponseIn.Text = CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Second.ToString.PadLeft(2, "0")

            SqlConnection1.Close()
        Catch ex As Exception
            Logger("ResponseIn", ex.ToString)
            lblLastUpdateTimeResponseIn.Text = lblTime.Text
            lblNextUpdateResponseIn.Text = CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Second.ToString.PadLeft(2, "0")

        End Try
    End Function
    Function ResponseOut()
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            'Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"

            'ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
            'ChakavakInsertCmd.CommandTimeout = 300
            'ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            'ChakavakInsertCmd.Connection = SqlConnection1
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_ChequeId", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_DepositDate", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_SettlementDate", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_Amount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_UserName", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Submitter", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Priority", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_Name", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BIC", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_Name", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BIC", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Front", System.Data.SqlDbType.VarBinary, 2147483647))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Back", System.Data.SqlDbType.VarBinary, 2147483647))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_AccountType", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_ReferTo", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Name", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OfficeCode", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_FatherName", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_NationalID", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode2", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address1", System.Data.SqlDbType.NVarChar, 500))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address2", System.Data.SqlDbType.NVarChar, 500))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel1", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel2", System.Data.SqlDbType.NVarChar, 50))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.Bit, 1))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChequeType", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransferDate", System.Data.SqlDbType.NVarChar, 10))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 10))
            'ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))
            'Dim list As New List(Of String)
            'Dim tmpChakavakServiceClient1 As New ChakavakServiceWS.ChakavakServiceClient
            'Try

            '    Dim data As String = tmpChakavakServiceClient1.GetResponseInAcknowledgeNotProcessed
            '    Dim tmpCheque() As com.cbi.chakavak.chequeSchema.Cheque
            '    tmpCheque = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Cheque())(data)

            '    SqlConnection1.ConnectionString = sqlConnectionString1
            '    SqlConnection1.Open()
            '    For Each item In tmpCheque
            '        Dim Id As Guid
            '        Id = Guid.NewGuid
            '        Dim tmpAcknowledge As com.cbi.chakavak.chequeSchema.Acknowledge
            '        tmpAcknowledge = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Acknowledge)(item.Body.Item.ToString)
            '        ChakavakInsertCmd.Parameters("@H_ChequeId").Value = item.Header.ChequeID
            '        ChakavakInsertCmd.Parameters("@CommonId").Value = Id
            '        ChakavakInsertCmd.Parameters("@H_DepositDate").Value = item.Header.DepositDate
            '        ChakavakInsertCmd.Parameters("@H_SettlementDate").Value = item.Header.SettlementDate
            '        ChakavakInsertCmd.Parameters("@H_Amount").Value = item.Header.Amount
            '        ChakavakInsertCmd.Parameters("@H_UserName").Value = item.Header.UserName
            '        ChakavakInsertCmd.Parameters("@RES_TRN").Value = tmpAcknowledge.TRN
            '        ChakavakInsertCmd.Parameters("@RQS_SeqNo").Value = tmpAcknowledge.TRN
            '        ChakavakInsertCmd.Parameters("@RES_Status").Value = tmpAcknowledge.Status
            '        ChakavakInsertCmd.Parameters("@RES_Reason").Value = tmpAcknowledge.Reason
            '        ChakavakInsertCmd.Parameters("@DBT_Name").Value = tmpAcknowledge.Debtor.Name
            '        ChakavakInsertCmd.Parameters("@DBT_IBAN").Value = tmpAcknowledge.Debtor.IBAN
            '        ChakavakInsertCmd.Parameters("@DBT_BIC").Value = tmpAcknowledge.Debtor.BIC
            '        ChakavakInsertCmd.Parameters("@DBT_BranchCode").Value = tmpAcknowledge.Debtor.BranchCode
            '        ChakavakInsertCmd.Parameters("@CRT_Name").Value = tmpAcknowledge.Creditor.Name
            '        ChakavakInsertCmd.Parameters("@CRT_IBAN").Value = tmpAcknowledge.Creditor.IBAN
            '        ChakavakInsertCmd.Parameters("@CRT_NationalCode").Value = tmpAcknowledge.Creditor.NationalCode
            '        ChakavakInsertCmd.Parameters("@CRT_BIC").Value = tmpAcknowledge.Creditor.BIC
            '        ChakavakInsertCmd.Parameters("@CRT_BranchCode").Value = tmpAcknowledge.Creditor.BranchCode
            '        ChakavakInsertCmd.Parameters("@UserId").Value = 1

            '        'ChakavakInsertCmd.Parameters("@ChequeType").Value = 1
            '        ChakavakInsertCmd.Parameters("@BranchId").Value = 517
            '        ChakavakInsertCmd.Parameters("@Status").Value = 22
            '        ChakavakInsertCmd.Parameters("@TransferDate").Value = item.Header.SettlementDate '"" 'tmpRequest.SeqNo
            '        ChakavakInsertCmd.Parameters("@KelerType").Value = 2
            '        ChakavakInsertCmd.ExecuteNonQuery()
            '        If ChakavakInsertCmd.Parameters("@RETURN_VALUE").Value = 1 Then
            '            list.Add(tmpAcknowledge.TRN)
            '        End If
            '    Next
            '    SqlConnection1.Close()
            'Catch ex As Exception
            '    Logger("ResponseOut", "Error Insert Acknowledge")
            'End Try
            'Dim WSResult As New Chakavak.ChakavakServiceWS.Result
            'WSResult = tmpChakavakServiceClient1.UpdateResponseInAcknowledgeItemsByTRN(list.ToArray)
            'If WSResult.Type.Success = ChakavakServiceWS.ResultType.Success Then Logger("ResponseOut", list.Count.ToString + " Acknowledges Updated") Else Logger("ResponseOut", "Acknowledges Not Updated")





            Dim ChkReqPbDbtGetAllDataCmd = New System.Data.SqlClient.SqlCommand
            Dim ChkReqPbDbtGetAllDataCmd1 = New System.Data.SqlClient.SqlCommand


            Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString
            SqlConnection1.Open()
            ChkReqPbDbtGetAllDataCmd.CommandText = "dbo.[ChakavakRequestPbDebtorGetAllData]"
            ChkReqPbDbtGetAllDataCmd.CommandTimeout = 300
            ChkReqPbDbtGetAllDataCmd.Connection = SqlConnection1
            ChkReqPbDbtGetAllDataCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChkReqPbDbtGetAllDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            Dim AuthorisePbDebtorCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString2 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            Dim SqlConnection2 = New System.Data.SqlClient.SqlConnection
            SqlConnection2.ConnectionString = sqlConnectionString2

            'AuthoriseCmd
            '
            AuthorisePbDebtorCmd.CommandText = "dbo.[ChakavakAuthoriseRequestPbDebtorGetAllData]"
            AuthorisePbDebtorCmd.CommandTimeout = 300
            AuthorisePbDebtorCmd.CommandType = System.Data.CommandType.StoredProcedure
            AuthorisePbDebtorCmd.Connection = SqlConnection2
            AuthorisePbDebtorCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            AuthorisePbDebtorCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))



            Dim tmpChakavakServiceClient As New ChakavakServiceWS.ChakavakServiceClient
           
           
            Dim tmpResult As New ChakavakServiceWS.Result

            Counter = 0
            Dim Reader As SqlClient.SqlDataReader = ChkReqPbDbtGetAllDataCmd.ExecuteReader
            While Reader.Read()
                Dim tmpNonPaymentCertificate As New ChakavakServiceWS.NonPaymentCertificate
                Dim tmpAuthorised(0) As ChakavakServiceWS.Authorised
                Dim tmpChequeIssuer As New ChakavakServiceWS.ChequeIssuer
                Dim tmpChequeResponse As New ChakavakServiceWS.ChequeResponse
                Dim tmpHeader As New ChakavakServiceWS.Header
                Dim tmpResponse As New ChakavakServiceWS.Response
                Dim tmpDebtor As New ChakavakServiceWS.Debtor
                Dim tmpCreditor As New ChakavakServiceWS.Creditor

                tmpHeader.chequeIDField = Reader.Item(0)
                tmpHeader.amountField = Reader.Item(1)
                tmpHeader.depositDateField = Reader.Item(2)
                tmpHeader.settlementDateField = Reader.Item(3)
                tmpHeader.userNameField = Reader.Item(39) ' "isco999999924"

                tmpResponse.statusField = Reader.Item(4)
                tmpResponse.seqNoField = Reader.Item(5)
                tmpResponse.tRNField = Reader.Item(6)
                tmpResponse.submitterField = Reader.Item(7)
                tmpResponse.amendatoryField = Reader.Item(8)
                tmpResponse.reasonField = Reader.Item(9)

                tmpDebtor.nameField = Reader.Item(10)
                tmpDebtor.iBANField = Reader.Item(11)
                tmpDebtor.bICField = Reader.Item(12)
                tmpDebtor.branchCodeField = Reader.Item(13)

                tmpCreditor.nameField = Reader.Item(14)
                tmpCreditor.iBANField = Reader.Item(15)
                tmpCreditor.nationalCodeField = Reader.Item(16)
                tmpCreditor.bICField = Reader.Item(17)
                tmpCreditor.branchCodeField = Reader.Item(18)

                If Reader.Item(21).ToString.Length > 0 Then
                    tmpChequeIssuer.accountTypeField = Reader.Item(19)
                    tmpChequeIssuer.referToField = Reader.Item(20)
                    tmpChequeIssuer.nameField = Reader.Item(21)
                    tmpChequeIssuer.birthCertNumOrRegNumField = Reader.Item(22)
                    tmpChequeIssuer.birthDateOrRegDateField = Reader.Item(23)
                    tmpChequeIssuer.issueLocationOrRegLocationField = Reader.Item(24)
                    tmpChequeIssuer.locationCodeField = Reader.Item(25)
                    tmpChequeIssuer.officeCodeField = "1" 'Reader.Item(26)
                    tmpChequeIssuer.fatherNameField = Reader.Item(27)
                    tmpChequeIssuer.nationalIDField = Reader.Item(28)
                    tmpChequeIssuer.postalCode1Field = Reader.Item(29)
                    tmpChequeIssuer.postalCode2Field = Reader.Item(30)
                    tmpChequeIssuer.address1Field = Reader.Item(31)
                    tmpChequeIssuer.address2Field = Reader.Item(32)
                    tmpChequeIssuer.tel1Field = Reader.Item(33)
                    tmpChequeIssuer.tel2Field = Reader.Item(34)
                    tmpChequeIssuer.curAccBalField = CType(Reader.Item(35), Decimal)
                    tmpChequeIssuer.onIssueDateAccBalField = Reader.Item(36)
                    tmpChequeIssuer.isSettledField = Reader.Item(37)
                    tmpNonPaymentCertificate.otherAuthorisedField = Reader.Item(38)

                    SqlConnection2.Open()
                    AuthorisePbDebtorCmd.Parameters("@CommonId").Value = Reader.Item(40)

                    Dim ReaderAuth As SqlClient.SqlDataReader = AuthorisePbDebtorCmd.ExecuteReader
                    '  For Each itemAuth In ReaderAuth
                    Dim counterAuth As Integer = 0

                    While ReaderAuth.Read()
                        'Dim tmpAuthorised1 As New ChakavakServiceWS.Authorised
                        Dim tmpAuthorised_Row As New ChakavakServiceWS.Authorised
                        tmpAuthorised_Row.fullNameField = ReaderAuth.Item(0)
                        tmpAuthorised_Row.birthCertNumOrRegNumField = ReaderAuth.Item(1)
                        tmpAuthorised_Row.birthDateOrRegDateField = ReaderAuth.Item(2)
                        tmpAuthorised_Row.issueLocationOrRegLocationField = ReaderAuth.Item(3)
                        tmpAuthorised_Row.locationCodeField = ReaderAuth.Item(4)
                        tmpAuthorised_Row.fatherNameField = ReaderAuth.Item(5)
                        tmpAuthorised_Row.nationalIDField = ReaderAuth.Item(6)
                        tmpAuthorised_Row.postalCode1Field = ReaderAuth.Item(7)
                        tmpAuthorised_Row.address1Field = ReaderAuth.Item(8)
                        tmpAuthorised_Row.tel1Field = ReaderAuth.Item(9)
                        tmpAuthorised_Row.referToField = 1

                        tmpAuthorised_Row.officeCodeField = "1"

                        'Dim a As System.Runtime.Serialization.ExtensionDataObject
                        'a =
                        'If counterAuth > 0 Then ReDim tmpAuthorised(tmpAuthorised.Length + 1)
                        If counterAuth > 0 Then Array.Resize(tmpAuthorised, tmpAuthorised.Length + 1)


                        'tmpAuthorised_Row.ExtensionData = a
                        tmpAuthorised(counterAuth) = tmpAuthorised_Row
                        tmpAuthorised_Row = Nothing
                        counterAuth = counterAuth + 1
                    End While

                    ReaderAuth.Close()
                    SqlConnection2.Close()
                    tmpNonPaymentCertificate.chequeIssuerField = tmpChequeIssuer
                    If counterAuth > 0 Then tmpNonPaymentCertificate.authorisedField = tmpAuthorised 'AuthPer.OfType(Of Chakavak.ChakavakServiceWS.Authorised)() ' tmpAuthorised
                    tmpResponse.nonPaymentCertificateField = tmpNonPaymentCertificate
                End If

                tmpResponse.debtorField = tmpDebtor
                tmpResponse.creditorField = tmpCreditor
                tmpChequeResponse.Response = tmpResponse
                tmpChequeResponse.Header = tmpHeader
                tmpResult = tmpChakavakServiceClient.PutResponseOutChequeResponse(tmpChequeResponse)
                'tmpNonPaymentCertificate = Nothing
                'tmpChequeResponse = Nothing
                'tmpDebtor = Nothing
                'tmpCreditor = Nothing
                'tmpHeader = Nothing
                'tmpChequeIssuer=Nothing
                Counter += 1
                'If tmpResult.Type = ChakavakServiceWS.ResultType.Success Then Logger("ResponseOut", Counter.ToString + " Success") Else Logger("ResponseOut", tmpResult.Message + "0000")
            End While
            Reader.Close()
            Dim ChakavakResponseupdateCmd = New System.Data.SqlClient.SqlCommand
            ChakavakResponseupdateCmd.CommandText = "dbo.[ChakavakResponseupdate]"
            ChakavakResponseupdateCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakResponseupdateCmd.Connection = SqlConnection1
            ChakavakResponseupdateCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            'ChakavakResponseupdateCmd.ExecuteNonQuery()


            Logger("ResponseOut", Counter.ToString + " Success")
            lblLastUpdateTimeResponseOut.Text = lblTime.Text
            lblNextUpdateResponseOut.Text = CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Second.ToString.PadLeft(2, "0")
            SqlConnection1.Close()
        Catch ex As Exception
            Logger("ResponseOut", ex.ToString)
            lblLastUpdateTimeResponseOut.Text = lblTime.Text
            lblNextUpdateResponseOut.Text = CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Second.ToString.PadLeft(2, "0")

        End Try
    End Function
    Function ResponseOutAck()
        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=Accounting;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"

            ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
            ChakavakInsertCmd.CommandTimeout = 300
            ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakInsertCmd.Connection = SqlConnection1
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_ChequeId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_DepositDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_SettlementDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_Amount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@H_UserName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Submitter", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Priority", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DBT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_IBAN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_NationalCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BIC", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CRT_BranchCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Front", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQSD_Back", System.Data.SqlDbType.VarBinary, 2147483647))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_AccountType", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_ReferTo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Name", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OfficeCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_FatherName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_NationalID", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_PostalCode2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address1", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Address2", System.Data.SqlDbType.NVarChar, 500))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_Tel2", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(20, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.Bit, 1))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChequeType", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransferDate", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BranchId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 10))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CommonId", System.Data.SqlDbType.UniqueIdentifier, 16))
            Dim list As New List(Of String)
            Dim tmpChakavakServiceClient1 As New ChakavakServiceWS.ChakavakServiceClient
            Try

                Dim data As String = tmpChakavakServiceClient1.GetResponseInAcknowledgeNotProcessed
                Dim tmpCheque() As com.cbi.chakavak.chequeSchema.Cheque
                tmpCheque = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Cheque())(data)

                SqlConnection1.ConnectionString = sqlConnectionString1
                SqlConnection1.Open()
                For Each item In tmpCheque
                    Dim Id As Guid
                    Id = Guid.NewGuid
                    Dim tmpAcknowledge As com.cbi.chakavak.chequeSchema.Acknowledge
                    tmpAcknowledge = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.chequeSchema.Acknowledge)(item.Body.Item.ToString)
                    ChakavakInsertCmd.Parameters("@H_ChequeId").Value = item.Header.ChequeID
                    ChakavakInsertCmd.Parameters("@CommonId").Value = Id
                    ChakavakInsertCmd.Parameters("@H_DepositDate").Value = item.Header.DepositDate
                    ChakavakInsertCmd.Parameters("@H_SettlementDate").Value = item.Header.SettlementDate
                    ChakavakInsertCmd.Parameters("@H_Amount").Value = item.Header.Amount
                    ChakavakInsertCmd.Parameters("@H_UserName").Value = item.Header.UserName
                    ChakavakInsertCmd.Parameters("@RES_TRN").Value = tmpAcknowledge.TRN
                    ChakavakInsertCmd.Parameters("@RQS_SeqNo").Value = tmpAcknowledge.TRN
                    ChakavakInsertCmd.Parameters("@RES_Status").Value = tmpAcknowledge.Status
                    ChakavakInsertCmd.Parameters("@RES_Reason").Value = tmpAcknowledge.Reason
                    ChakavakInsertCmd.Parameters("@DBT_Name").Value = tmpAcknowledge.Debtor.Name
                    ChakavakInsertCmd.Parameters("@DBT_IBAN").Value = tmpAcknowledge.Debtor.IBAN
                    ChakavakInsertCmd.Parameters("@DBT_BIC").Value = tmpAcknowledge.Debtor.BIC
                    ChakavakInsertCmd.Parameters("@DBT_BranchCode").Value = tmpAcknowledge.Debtor.BranchCode
                    ChakavakInsertCmd.Parameters("@CRT_Name").Value = tmpAcknowledge.Creditor.Name
                    ChakavakInsertCmd.Parameters("@CRT_IBAN").Value = tmpAcknowledge.Creditor.IBAN
                    ChakavakInsertCmd.Parameters("@CRT_NationalCode").Value = tmpAcknowledge.Creditor.NationalCode
                    ChakavakInsertCmd.Parameters("@CRT_BIC").Value = tmpAcknowledge.Creditor.BIC
                    ChakavakInsertCmd.Parameters("@CRT_BranchCode").Value = tmpAcknowledge.Creditor.BranchCode
                    ChakavakInsertCmd.Parameters("@UserId").Value = 1

                    'ChakavakInsertCmd.Parameters("@ChequeType").Value = 1
                    ChakavakInsertCmd.Parameters("@BranchId").Value = 517
                    ChakavakInsertCmd.Parameters("@Status").Value = 22
                    ChakavakInsertCmd.Parameters("@TransferDate").Value = item.Header.SettlementDate '"" 'tmpRequest.SeqNo
                    ChakavakInsertCmd.Parameters("@KelerType").Value = 2
                    ChakavakInsertCmd.ExecuteNonQuery()
                    If ChakavakInsertCmd.Parameters("@RETURN_VALUE").Value = 1 Then
                        list.Add(tmpAcknowledge.TRN)
                    End If
                Next
                SqlConnection1.Close()
            Catch ex As Exception
                Logger("ResponseOut", "Error Insert Acknowledge")
            End Try
            Dim WSResult As New Chakavak.ChakavakServiceWS.Result
            WSResult = tmpChakavakServiceClient1.UpdateResponseInAcknowledgeItemsByTRN(list.ToArray)
            If WSResult.Type.Success = ChakavakServiceWS.ResultType.Success Then Logger("ResponseOut", list.Count.ToString + " Acknowledges Updated") Else Logger("ResponseOut", "Acknowledges Not Updated")


            lblLastUpdateTimeResponseOutAck.Text = lblTime.Text
            lblNextUpdateResponseOutAck.Text = CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Second.ToString.PadLeft(2, "0")


        Catch ex As Exception
            Logger("ResponseOut", ex.ToString)
            lblLastUpdateTimeResponseOutAck.Text = lblTime.Text
            lblNextUpdateResponseOutAck.Text = CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Second.ToString.PadLeft(2, "0")

        End Try
    End Function
    Function Logger(Type As String, Message As String)
        Try

            ''Set view property
            ListView1.View = View.Details
            ListView1.GridLines = True
            ListView1.FullRowSelect = True


            Dim arr As String() = New String(3) {}
            Dim itm As ListViewItem
            arr(0) = "Time:" + System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Minute.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Second.ToString.PadLeft(2, "0")
            arr(1) = Type
            arr(2) = Message
            itm = New ListViewItem(arr)
            itm.ForeColor = Color.Black


            Select Case Type
                Case "RequestOut"
                    'ListBoxRequestOut.Items.Insert(0, "[Time:" + System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Minute.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Second.ToString.PadLeft(2, "0") + "] " + Message)
                    itm.ForeColor = Color.Red
                Case "RequestIn"
                    'ListBoxRequestIn.Items.Insert(0, "[Time:" + System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Minute.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Second.ToString.PadLeft(2, "0") + "] " + Message)
                    itm.ForeColor = Color.Purple
                Case "ResponseOut"
                    'ListBoxResponseOut.Items.Insert(0, "[Time:" + System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Minute.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Second.ToString.PadLeft(2, "0") + "] " + Message)
                    itm.ForeColor = Color.Blue
                Case "ResponseIn"
                    'ListBoxResponseIn.Items.Insert(0, "[Time:" + System.DateTime.Now.Hour.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Minute.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.Second.ToString.PadLeft(2, "0") + "] " + Message)
                    itm.ForeColor = Color.Green
            End Select
            ListView1.Items.Insert(0, itm)
            tmplog.Info(Type + vbTab + Message)
        Catch ex As Exception

        End Try
    End Function
    Private Sub btnRequestOutStart_Click(sender As Object, e As EventArgs) Handles btnRequestOutStart.Click
        lblLastUpdateTimeRequestOut.Text = lblTime.Text
        lblNextUpdateRequestOut.Text = CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOut.Text, DateTime).AddMinutes(txtDurationRequestOut.Text).Second.ToString.PadLeft(2, "0")
        LblReqOutStatus.Text = "Active"
        LblReqOutStatus.ForeColor = Color.Green
    End Sub
    Private Sub btnRequestOutStop_Click(sender As Object, e As EventArgs) Handles btnRequestOutStop.Click
        lblNextUpdateRequestOut.Text = "--:--:--"
        lblLastUpdateTimeRequestOut.Text = "--:--:--"
        LblReqOutStatus.Text = "deActive"
        LblReqOutStatus.ForeColor = Color.Red
    End Sub
    Private Sub btnRequestOutAckStart_Click(sender As Object, e As EventArgs) Handles btnRequestOutAckStart.Click
        lblLastUpdateTimeRequestOutAck.Text = lblTime.Text
        lblNextUpdateRequestOutAck.Text = CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestOutAck.Text, DateTime).AddMinutes(txtDurationRequestOutAck.Text).Second.ToString.PadLeft(2, "0")
        LblReqOutAckStatus.Text = "Active"
        LblReqOutAckStatus.ForeColor = Color.Green
    End Sub

    Private Sub btnRequestOutAckStop_Click(sender As Object, e As EventArgs) Handles btnRequestOutAckStop.Click
        lblNextUpdateRequestOutAck.Text = "--:--:--"
        lblLastUpdateTimeRequestOutAck.Text = "--:--:--"
        LblReqOutAckStatus.Text = "deActive"
        LblReqOutAckStatus.ForeColor = Color.Red
    End Sub
    Private Sub btnRequestInStart_Click(sender As Object, e As EventArgs) Handles btnRequestInStart.Click
        lblLastUpdateTimeRequestIn.Text = lblTime.Text
        lblNextUpdateRequestIn.Text = CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeRequestIn.Text, DateTime).AddMinutes(txtDurationRequestIn.Text).Second.ToString.PadLeft(2, "0")
        LblReqInStatus.Text = "Active"
        LblReqInStatus.ForeColor = Color.Green
    End Sub
    Private Sub btnRequestInStop_Click(sender As Object, e As EventArgs) Handles btnRequestInStop.Click
        lblNextUpdateRequestIn.Text = "--:--:--"
        lblLastUpdateTimeRequestIn.Text = "--:--:--"
        LblReqInStatus.Text = "deActive"
        LblReqInStatus.ForeColor = Color.Red
    End Sub
    Private Sub btnResponseOutStart_Click(sender As Object, e As EventArgs) Handles btnResponseOutStart.Click
        lblLastUpdateTimeResponseOut.Text = lblTime.Text
        lblNextUpdateResponseOut.Text = CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOut.Text, DateTime).AddMinutes(txtDurationResponseOut.Text).Second.ToString.PadLeft(2, "0")
        LblResOutStatus.Text = "Active"
        LblResOutStatus.ForeColor = Color.Green
    End Sub
    Private Sub btnResponseOutStop_Click(sender As Object, e As EventArgs) Handles btnResponseOutStop.Click
        lblNextUpdateResponseOut.Text = "--:--:--"
        lblLastUpdateTimeResponseOut.Text = "--:--:--"
        LblResOutStatus.Text = "deActive"
        LblResOutStatus.ForeColor = Color.Red
    End Sub
    Private Sub btnResponseInStart_Click(sender As Object, e As EventArgs) Handles btnResponseInStart.Click
        lblLastUpdateTimeResponseIn.Text = lblTime.Text
        lblNextUpdateResponseIn.Text = CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseIn.Text, DateTime).AddMinutes(txtDurationResponseIn.Text).Second.ToString.PadLeft(2, "0")
        LblResInStatus.Text = "Active"
        LblResInStatus.ForeColor = Color.Green
    End Sub
    Private Sub btnResponseInStop_Click(sender As Object, e As EventArgs) Handles btnResponseInStop.Click
        lblNextUpdateResponseIn.Text = "--:--:--"
        lblLastUpdateTimeResponseIn.Text = "--:--:--"
        LblResInStatus.Text = "deActive"
        LblResInStatus.ForeColor = Color.Red
    End Sub
    Private Sub btnResponseOutAckStart_Click(sender As Object, e As EventArgs) Handles btnResponseOutAckStart.Click
        lblLastUpdateTimeResponseOutAck.Text = lblTime.Text
        lblNextUpdateResponseOutAck.Text = CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Hour.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Minute.ToString.PadLeft(2, "0") + ":" + CType(lblLastUpdateTimeResponseOutAck.Text, DateTime).AddMinutes(txtDurationResponseOutAck.Text).Second.ToString.PadLeft(2, "0")
        LblResOutAckStatus.Text = "Active"
        LblResOutAckStatus.ForeColor = Color.Green
    End Sub
    Private Sub btnResponseOutAckStop_Click(sender As Object, e As EventArgs) Handles btnResponseOutAckStop.Click
        lblNextUpdateResponseOutAck.Text = "--:--:--"
        lblLastUpdateTimeResponseOutAck.Text = "--:--:--"
        LblResOutAckStatus.Text = "deActive"
        LblResOutAckStatus.ForeColor = Color.Red
    End Sub
    Function CheckTimeAccess(Time As String) As Boolean
        If Time > My.Settings.StartTime And Time < My.Settings.EndTime Then Return True Else Return False
    End Function
    Private Sub خروجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles خروجToolStripMenuItem.Click
        If MsgBox("میخواهید از برنامه خارج شوید؟", MsgBoxStyle.YesNo) = 6 Then
            'If InputBox("کلمه عبور را وارد کنید", vbOKCancel, "", -1, -1) = "" Then
            Application.Exit()
            'End If
        End If
    End Sub
    Private Sub تنظیماتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تنظیماتToolStripMenuItem.Click
        Dim SettingFrm As New Settings
        SettingFrm.ShowDialog()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("میخواهید از برنامه خارج شوید؟", MsgBoxStyle.YesNo) = 6 Then
            If InputBox("کلمه عبور را وارد کنید", vbOKCancel, "", -1, -1) = "123" Then
                Application.Exit()
            End If
        End If
    End Sub
    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
    End Sub
    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
    End Sub
    Private Sub اتصالToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اتصالToolStripMenuItem.Click
        'Dim DemoAppFrm As New DemoApp
        'DemoAppFrm.ShowDialog()
    End Sub
    Function FillMessage()
        Try
            ''Set view property
            ListView2.View = View.Details
            ListView2.GridLines = True
            ListView2.FullRowSelect = True
            ListView2.Items.Clear()

            Dim arr As String() = New String(4) {}
            Dim itm As ListViewItem

            Dim tmpChakavakServiceClient As New ChakavakServiceWS.ChakavakServiceClient
            Dim data As String = tmpChakavakServiceClient.GetInformationSchemaNotProcessed
            Dim tmpCheque() As com.cbi.chakavak.InformationSchema.Information
            tmpCheque = Newtonsoft.Json.JsonConvert.DeserializeObject(Of com.cbi.chakavak.InformationSchema.Information())(data)

            For Each item In tmpCheque
                arr(0) = item.Header.InformationType
                arr(1) = item.Header.Publisher
                arr(2) = item.Header.Subscriber
                arr(3) = item.Body.Item
                itm = New ListViewItem(arr)
                itm.ForeColor = Color.Black
                ListView2.Items.Insert(0, itm)
                'Select Case item.Body.Item.ToUpper
                '    Case "STARTED".ToUpper
                '        LblReqInCBIStatus.Text = "Active"
                '        LblReqInCBIStatus.ForeColor = Color.Green
                '        btnRequestInStart.Enabled = True
                '        btnRequestInStop.Enabled = True

                '        LblReqOutCBIStatus.Text = "Active"
                '        LblReqOutCBIStatus.ForeColor = Color.Green
                '        btnRequestOutStart.Enabled = True
                '        btnRequestOutStop.Enabled = True

                '        LblResInCBIStatus.Text = "Active"
                '        LblResInCBIStatus.ForeColor = Color.Green
                '        btnResponseInStart.Enabled = True
                '        btnResponseInStop.Enabled = True

                '        LblResOutCBIStatus.Text = "Active"
                '        LblResOutCBIStatus.ForeColor = Color.Green
                '        btnResponseOutStart.Enabled = True
                '        btnResponseOutStop.Enabled = True
                '    Case "EndOfRequestTime".ToUpper Or "EndOfCodedRequestTime".ToUpper
                '        LblReqOutCBIStatus.Text = "deActive"
                '        LblReqOutCBIStatus.ForeColor = Color.Red
                '        LblReqInCBIStatus.Text = "deActive"
                '        LblReqInCBIStatus.ForeColor = Color.Red
                '    Case "EndOfResponseTime".ToUpper Or "EndOfCodedResponseTime".ToUpper
                '        LblResOutCBIStatus.Text = "deActive"
                '        LblResOutCBIStatus.ForeColor = Color.Red
                '        LblResInCBIStatus.Text = "deActive"
                '        LblResInCBIStatus.ForeColor = Color.Red
                '    Case "ALERT_END_CODED_RESPONSE_TIME".ToUpper

                '    Case "CutOff_Settlement".ToUpper
                '        LblReqOutCBIStatus.Text = "deActive"
                '        LblReqOutCBIStatus.ForeColor = Color.Red
                '        LblReqInCBIStatus.Text = "deActive"
                '        LblReqInCBIStatus.ForeColor = Color.Red
                '        LblResOutCBIStatus.Text = "deActive"
                '        LblResOutCBIStatus.ForeColor = Color.Red
                '        LblResInCBIStatus.Text = "deActive"
                '        LblResInCBIStatus.ForeColor = Color.Red
                '    Case "Finished".ToUpper
                '        LblReqOutCBIStatus.Text = "deActive"
                '        LblReqOutCBIStatus.ForeColor = Color.Red
                '        LblReqInCBIStatus.Text = "deActive"
                '        LblReqInCBIStatus.ForeColor = Color.Red
                '        LblResOutCBIStatus.Text = "deActive"
                '        LblResOutCBIStatus.ForeColor = Color.Red
                '        LblResInCBIStatus.Text = "deActive"
                '        LblResInCBIStatus.ForeColor = Color.Red
                '    Case Else
                '        LblReqOutCBIStatus.Text = "deActive"
                '        LblReqInCBIStatus.Text = "deActive"
                '        LblResOutCBIStatus.Text = "deActive"
                '        LblResInCBIStatus.Text = "deActive"
                'End Select

            Next
            Application.DoEvents()


        Catch ex As Exception
            Try
                ListView2.Items.Insert(0, ex.Message.ToString)
            Catch ex1 As Exception

            End Try

        End Try

    End Function
    Private Sub صدورسندToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles صدورسندToolStripMenuItem.Click
        Dim frmSTMT As New frmSTMT
        frmSTMT.ShowDialog()
    End Sub
    Private Sub بانکهاToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles بانکهاToolStripMenuItem.Click
        Dim frmBankList As New BankList
        frmBankList.ShowDialog()
    End Sub
    Private Sub شعبToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles شعبToolStripMenuItem.Click
        Dim frmBranchList As New BranchList
        frmBranchList.ShowDialog()
    End Sub

    Private Sub خلاصهوضعیتروزجاریToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles خلاصهوضعیتروزجاریToolStripMenuItem.Click
        Dim frmChakavakSummery As New ChakavakSummery
        frmChakavakSummery.Show()
    End Sub

    Private Sub DasdasdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DasdasdToolStripMenuItem.Click
        Dim frmChakavakSummery As New Document
        frmChakavakSummery.ShowDialog()
    End Sub

    Private Sub عملیاتروزانهToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles عملیاتروزانهToolStripMenuItem.Click
        If InputBox("کلمه عبور را وارد کنید", vbOKCancel, "", -1, -1) = "" Then
            Dim frmRetrunChakavak As New RetrunChakavak
            frmRetrunChakavak.ShowDialog()
        End If
    End Sub

    Private Sub واریزبهحسابToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles واریزبهحسابToolStripMenuItem.Click
        Dim frmDocumentRiser As New DocumentRiser
        frmDocumentRiser.ShowDialog()
    End Sub

    
   
    Private Sub گزارشعودتیToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles گزارشعودتیToolStripMenuItem.Click
        Dim frmRejectedReport As New RejectedReport
        frmRejectedReport.ShowDialog()
    End Sub

  

    Private Sub فایلواریزیسیمیاToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles فایلواریزیسیمیاToolStripMenuItem.Click
        Dim frm As New SimiaVarizReport
        frm.ShowDialog()
    End Sub

   
End Class
