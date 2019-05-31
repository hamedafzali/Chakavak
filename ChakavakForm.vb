Imports System.Xml
Imports System.Data
Imports System.IO
Imports IBM.WMQ
Imports System.Threading
Public Class ChakavakForm
    Private ThreadRequestIn As Threading.Thread
    Private ThreadRequestOut As Threading.Thread
    Private ThreadResponseIn As Threading.Thread
    Private ThreadResponseOut As Threading.Thread
    Private Sub ChakavakForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblRequest.Text = "CMS.REQUEST.MANAGER/PBIR.REQUEST.IN/PBIR.REQUEST.OUT/PBIR.REQUEST.CHL/TCP/127.0.0.1/14027"
        lblResponse.Text = "CMS.RESPONSE.MANAGER/PBIR.RESPONSE.IN/PBIR.RESPONSE.OUT/PBIR.RESPONSE.CHL/TCP/127.0.0.1/15027"
    End Sub
    Dim MQReq As New MQExampleRequest.MQRequest
    Dim MQRes As New MQExampleResponse.MQResponse

    Sub RequestConnect()
        lboxLog.Items.Insert(0, "Connecting Request Channel ..." + vbCrLf)
        Application.DoEvents()

        Dim separator As Char() = {"/"c}
        Dim ChannelParams As String()
        ChannelParams = lblRequest.Text.Split(separator)
        lboxLog.Items.Insert(0, "Request Channel : " + MQReq.ConnectMQ(ChannelParams(0), ChannelParams(1), ChannelParams(2), ChannelParams(3) + "/" + ChannelParams(4) + "/" + ChannelParams(5) + "/" + ChannelParams(6)) + vbCrLf)
        Application.DoEvents()
        'Dim queueManager As New MQQueueManager
        'Dim channelName As String
        'Dim transportType As String
        'Dim connectionName As String
        'Dim port As Integer
        'Dim separator As Char() = {"/"c}
        'Dim ChannelParams As String()
        'ChannelParams = lblRequest.Text.Split(separator)
        'Dim QueueManagerName As String = ChannelParams(0)
        'Dim RqsInQueueName As String = ChannelParams(1)
        ''Dim RqsChannelInfo As String = ChannelParams(2) + "/" + ChannelParams(3) + "/" + ChannelParams(4) + "/" + ChannelParams(5)
        'Dim props As New System.Collections.Hashtable
        'channelName = ChannelParams(2)
        'transportType = ChannelParams(3)
        'connectionName = ChannelParams(4)
        'port = ChannelParams(5)
        'props.Add(MQC.HOST_NAME_PROPERTY, connectionName)
        'props.Add(MQC.CHANNEL_PROPERTY, channelName)
        'props.Add(MQC.PORT_PROPERTY, port)
        'props.Add(MQC.USER_ID_PROPERTY, "mqm")
        'props.Add(MQC.PASSWORD_PROPERTY, "11")
        'props.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES)

        'queueManager = New MQQueueManager(QueueManagerName, props)
        'lblRequestStat.Text = queueManager.IsConnected
    End Sub
    'Sub RequestOutConnect()
    '    Dim separator As Char() = {"/"c}
    '    Dim ChannelParams As String()
    '    ChannelParams = lblRequestOut.Text.Split(separator)
    '    Dim QueueManagerName As String = ChannelParams(0)
    '    Dim RqsInQueueName As String = ChannelParams(1)
    '    Dim RqsChannelInfo As String = ChannelParams(2) + "/" + ChannelParams(3) + "/" + ChannelParams(4) + "/" + ChannelParams(5)
    '    lblRequestInStat.Text = tmp.ConnectMQ(QueueManagerName, RqsInQueueName, RqsChannelInfo)
    'End Sub
    Sub ResponseConnect()
        lboxLog.Items.Insert(0, "Connecting Response Channel ..." + vbCrLf)
        Application.DoEvents()

        Dim separator As Char() = {"/"c}
        Dim ChannelParams As String()
        ChannelParams = lblResponse.Text.Split(separator)
        lboxLog.Items.Insert(0, "Response Channel : " + MQRes.ConnectMQ(ChannelParams(0), ChannelParams(1), ChannelParams(2), ChannelParams(3) + "/" + ChannelParams(4) + "/" + ChannelParams(5) + "/" + ChannelParams(6)) + vbCrLf)
        Application.DoEvents()
        'Dim queueManager As New MQQueueManager
        'Dim channelName As String
        'Dim transportType As String
        'Dim connectionName As String
        'Dim port As Integer
        'Dim separator As Char() = {"/"c}
        'Dim ChannelParams As String()
        'ChannelParams = lblResponseIn.Text.Split(separator)
        'Dim QueueManagerName As String = ChannelParams(0)
        'Dim RqsInQueueName As String = ChannelParams(1)
        ''Dim RqsChannelInfo As String = ChannelParams(2) + "/" + ChannelParams(3) + "/" + ChannelParams(4) + "/" + ChannelParams(5)
        'Dim props As New System.Collections.Hashtable
        'channelName = ChannelParams(2)
        'transportType = ChannelParams(3)
        'connectionName = ChannelParams(4)
        'port = ChannelParams(5)
        'props.Add(MQC.HOST_NAME_PROPERTY, connectionName)
        'props.Add(MQC.CHANNEL_PROPERTY, channelName)
        'props.Add(MQC.PORT_PROPERTY, port)
        ''props.Add(MQC.USER_ID_PROPERTY, "mqm")
        ''props.Add(MQC.PASSWORD_PROPERTY, "11")
        ''props.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES)

        'queueManager = New MQQueueManager(QueueManagerName, props)
        'lblResponseInStat.Text = queueManager.IsConnected
    End Sub
    

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        'ThreadRequestIn = New Thread(AddressOf RequestConnect)
        'ThreadRequestIn.Start()
        RequestConnect()
    End Sub

    Private Sub btnResponse_Click(sender As Object, e As EventArgs) Handles btnResponse.Click
        'ThreadResponseIn = New Thread(AddressOf ResponseConnect)
        'ThreadResponseIn.Start()
        ResponseConnect()
    End Sub

    Private Sub btnRequestReceive_Click(sender As Object, e As EventArgs) Handles btnRequestReceive.Click
        Dim Status As Boolean = True
        Dim Counter As Integer = 0
        'While Status = True
        '    Try

        '        Dim str As String = MQReq.ReadMsg()
        '        Dim CHQ As New Cheque
        '        Dim stream As StringReader = New StringReader(str)
        '        Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
        '        CHQ = CType(ser.Deserialize(stream), Cheque)
        '        SaveData(CHQ)
        '        Status = True
        '        Counter += 1
        '    Catch ex As Exception
        '        lboxLog.Items.Insert(0, ex.ToString + vbCrLf)
        '        Status = False
        '        Counter += 1
        '    End Try

        'End While
        lboxLog.Items.Insert(0, Counter.ToString + " item" + vbCrLf)
    End Sub
    

    Private Sub btnResponseReceive_Click(sender As Object, e As EventArgs) Handles btnResponseReceive.Click
        Dim Status As Boolean = True
        While Status = True
            Try
                Dim str As String = MQRes.ReadMsg()
                Dim CHQ As New Cheque
                Dim stream As StringReader = New StringReader(str)
                Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
                CHQ = CType(ser.Deserialize(stream), Cheque)
                If SaveData(CHQ) = 1 Then
                    lboxLog.Items.Insert(0, "Data Saved" + vbCrLf)
                End If
                Status = True
            Catch ex As Exception
                lboxLog.Items.Insert(0, ex.ToString + vbCrLf)
                Status = False
            End Try

        End While
    End Sub
    Function SaveData(Cheque As Cheque) As Integer
        Dim BDY As New Chakavak.Body
        Dim HDR As New Chakavak.Header
        Dim REQ As New Chakavak.Request
        Dim RES As New Chakavak.Response
        Dim DBT As New Chakavak.Debtor
        Dim CRT As New Chakavak.Creditor
        Dim RD As New Chakavak.RequestData
        Dim NPC As New Chakavak.NonPaymentCertificate
        Dim CI As New Chakavak.ChequeIssuer
        Dim Ath() As Chakavak.Authorised
        Dim ACK As New Chakavak.Acknowledge
        Dim ACN As New Chakavak.Action
        Dim Type As String
        HDR = Cheque.Header
        BDY = Cheque.Body
        Try
            REQ = BDY.Item
            Type = "Request"
        Catch ex As Exception
            Try
                RES = BDY.Item
                Type = "Response"
            Catch ex1 As Exception
                Try
                    ACK = BDY.Item
                    Type = "Acknowledge"
                Catch ex2 As Exception
                    Try
                        ACN = BDY.Item
                        Type = "Action"
                    Catch ex3 As Exception
                        lboxLog.Items.Insert(0, "item is not supported : " + HDR.ChequeID.ToString + vbCrLf)
                        Return 0
                    End Try
                End Try
            End Try
        End Try
        lboxLog.Items.Insert(0, "Message Type : " + Type + vbCrLf)
        Try
            Select Case Type
                Case "Request"
                    DBT = REQ.Debtor
                    CRT = REQ.Creditor
                    RD = REQ.RequestData
                Case "Response"
                    DBT = RES.Debtor
                    CRT = RES.Creditor
                    NPC = RES.NonPaymentCertificate
                    CI = NPC.ChequeIssuer
                    Ath = NPC.Authorised
                Case "Acknowledge"
                    DBT = ACK.Debtor
                    CRT = ACK.Creditor
            End Select
            
        Catch ex As Exception
            lboxLog.Items.Insert(0, "Error in Identifying Classes" + vbCrLf)
            Return -1
        End Try
       



        Try
            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakInsertCmd = New System.Data.SqlClient.SqlCommand
            ChakavakInsertCmd.CommandText = "dbo.[ChakavakInsert]"
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
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_PartialSettlement", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Coded", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_ProminentStamp", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_Regressive", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RQS_InstrId", System.Data.SqlDbType.NVarChar, 50))
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
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Status", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Submitter", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Amendatory", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RES_Reason", System.Data.SqlDbType.NVarChar, 50))
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
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_CurAccBal", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_OnIssueDateAccBal", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCCI_IsSettled", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPC_OtherAuthorise", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACK_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACK_Status", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACK_Reason", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_SeqNo", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_Event", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_DebtorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_CreditorBic", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ACN_TRN", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@MessageType", System.Data.SqlDbType.NVarChar, 50))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ChakavakStatusId", System.Data.SqlDbType.Int, 4))
            ChakavakInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KelerType", System.Data.SqlDbType.Int, 4))


            Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=MICRDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=50"
            SqlConnection1.ConnectionString = sqlConnectionString
            SqlConnection1.Open()
            ChakavakInsertCmd.Parameters("@H_ChequeId").Value = HDR.ChequeID
            ChakavakInsertCmd.Parameters("@H_DepositDate").Value = HDR.DepositDate
            ChakavakInsertCmd.Parameters("@H_SettlementDate").Value = HDR.SettlementDate
            ChakavakInsertCmd.Parameters("@H_Amount").Value = HDR.Amount
            ChakavakInsertCmd.Parameters("@H_UserName").Value = HDR.UserName
            ChakavakInsertCmd.Parameters("@RQS_Submitter").Value = REQ.Submitter
            ChakavakInsertCmd.Parameters("@RQS_Priority").Value = REQ.Priority
            ChakavakInsertCmd.Parameters("@RQS_SeqNo").Value = REQ.SeqNo
            ChakavakInsertCmd.Parameters("@RQS_PartialSettlement").Value = REQ.PartialSettlement
            ChakavakInsertCmd.Parameters("@RQS_Coded").Value = REQ.Coded
            ChakavakInsertCmd.Parameters("@RQS_ProminentStamp").Value = REQ.ProminentStamp
            ChakavakInsertCmd.Parameters("@RQS_Regressive").Value = REQ.Regressive
            ChakavakInsertCmd.Parameters("@RQS_InstrId").Value = REQ.InstrId
            ChakavakInsertCmd.Parameters("@DBT_Name").Value = DBT.Name
            ChakavakInsertCmd.Parameters("@DBT_IBAN").Value = DBT.IBAN
            ChakavakInsertCmd.Parameters("@DBT_BIC").Value = DBT.BIC
            ChakavakInsertCmd.Parameters("@DBT_BranchCode").Value = DBT.BranchCode
            ChakavakInsertCmd.Parameters("@CRT_Name").Value = CRT.Name
            ChakavakInsertCmd.Parameters("@CRT_IBAN").Value = CRT.IBAN
            ChakavakInsertCmd.Parameters("@CRT_NationalCode").Value = CRT.NationalCode
            ChakavakInsertCmd.Parameters("@CRT_BIC").Value = CRT.BIC
            ChakavakInsertCmd.Parameters("@CRT_BranchCode").Value = CRT.BranchCode
            ChakavakInsertCmd.Parameters("@RQSD_Front").Value = RD.Front
            ChakavakInsertCmd.Parameters("@RQSD_Back").Value = RD.Back
            ChakavakInsertCmd.Parameters("@RES_Status").Value = RES.Status
            ChakavakInsertCmd.Parameters("@RES_SeqNo").Value = RES.SeqNo
            ChakavakInsertCmd.Parameters("@RES_TRN").Value = RES.TRN
            ChakavakInsertCmd.Parameters("@RES_Submitter").Value = RES.Submitter
            ChakavakInsertCmd.Parameters("@RES_Amendatory").Value = RES.Amendatory
            ChakavakInsertCmd.Parameters("@RES_Reason").Value = RES.Reason
            ChakavakInsertCmd.Parameters("@NPCCI_AccountType").Value = CI.AccountType
            ChakavakInsertCmd.Parameters("@NPCCI_ReferTo").Value = CI.referTo
            ChakavakInsertCmd.Parameters("@NPCCI_Name").Value = CI.Name
            ChakavakInsertCmd.Parameters("@NPCCI_BirthCertNumOrRegNum").Value = CI.BirthCertNumOrRegNum
            ChakavakInsertCmd.Parameters("@NPCCI_BirthDateOrRegDate").Value = CI.BirthDateOrRegDate
            ChakavakInsertCmd.Parameters("@NPCCI_IssueLocationOrRegLocation").Value = CI.IssueLocationOrRegLocation
            ChakavakInsertCmd.Parameters("@NPCCI_LocationCode").Value = CI.LocationCode
            ChakavakInsertCmd.Parameters("@NPCCI_OfficeCode").Value = CI.OfficeCode
            ChakavakInsertCmd.Parameters("@NPCCI_FatherName").Value = CI.FatherName
            ChakavakInsertCmd.Parameters("@NPCCI_NationalID").Value = CI.NationalID
            ChakavakInsertCmd.Parameters("@NPCCI_PostalCode1").Value = CI.PostalCode1
            ChakavakInsertCmd.Parameters("@NPCCI_PostalCode2").Value = CI.PostalCode2
            ChakavakInsertCmd.Parameters("@NPCCI_Address1").Value = CI.Address1
            ChakavakInsertCmd.Parameters("@NPCCI_Address2").Value = CI.Address2
            ChakavakInsertCmd.Parameters("@NPCCI_Tel1").Value = CI.Tel1
            ChakavakInsertCmd.Parameters("@NPCCI_Tel2").Value = CI.Tel2
            ChakavakInsertCmd.Parameters("@NPCCI_CurAccBal").Value = CI.CurAccBal
            ChakavakInsertCmd.Parameters("@NPCCI_OnIssueDateAccBal").Value = CI.OnIssueDateAccBal
            ChakavakInsertCmd.Parameters("@NPCCI_IsSettled").Value = CI.IsSettled
            ChakavakInsertCmd.Parameters("@NPC_OtherAuthorise").Value = NPC.OtherAuthorised
            ChakavakInsertCmd.Parameters("@ACK_TRN").Value = ACK.TRN
            ChakavakInsertCmd.Parameters("@ACK_Status").Value = ACK.Status
            ChakavakInsertCmd.Parameters("@ACK_Reason").Value = ACK.Reason
            ChakavakInsertCmd.Parameters("@ACN_SeqNo").Value = ACN.SeqNo
            ChakavakInsertCmd.Parameters("@ACN_Event").Value = ACN.Event
            ChakavakInsertCmd.Parameters("@ACN_DebtorBic").Value = ACN.DebtorBic
            ChakavakInsertCmd.Parameters("@ACN_CreditorBic").Value = ACN.CreditorBic
            ChakavakInsertCmd.Parameters("@ACN_TRN").Value = ACN.TRN
            ChakavakInsertCmd.Parameters("@MessageType").Value = Type
            ChakavakInsertCmd.Parameters("@ChakavakStatusId").Value = 5
            ChakavakInsertCmd.Parameters("@KelerType").Value = 2

            ChakavakInsertCmd.ExecuteNonQuery()




            Dim ChakavakAthInsertCmd = New System.Data.SqlClient.SqlCommand
            ChakavakInsertCmd.CommandText = "dbo.[ChakavakAthInsert]"
            ChakavakInsertCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakInsertCmd.Connection = SqlConnection1
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_FullName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_BirthCertNumOrRegNum", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_BirthDateOrRegDate", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_IssueLocationOrRegLocation", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_LocationCode", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_FatherName", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_NationalID", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_PostalCode1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_Address1", System.Data.SqlDbType.NVarChar, 500))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_Tel1", System.Data.SqlDbType.NVarChar, 50))
            ChakavakAthInsertCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NPCA_ReferTo", System.Data.SqlDbType.NVarChar, 50))


            If Not Ath Is Nothing Then
                If Ath.Length > 0 Then
                    For Each item In Ath
                        ChakavakInsertCmd.Parameters("@NPCA_FullName").Value = item.FullName
                        ChakavakInsertCmd.Parameters("@NPCA_BirthCertNumOrRegNum").Value = item.BirthCertNumOrRegNum
                        ChakavakInsertCmd.Parameters("@NPCA_BirthDateOrRegDate").Value = item.BirthDateOrRegDate
                        ChakavakInsertCmd.Parameters("@NPCA_IssueLocationOrRegLocation").Value = item.IssueLocationOrRegLocation
                        ChakavakInsertCmd.Parameters("@NPCA_LocationCode").Value = item.LocationCode
                        ChakavakInsertCmd.Parameters("@NPCA_FatherName").Value = item.FatherName
                        ChakavakInsertCmd.Parameters("@NPCA_NationalID").Value = item.NationalID
                        ChakavakInsertCmd.Parameters("@NPCA_PostalCode1").Value = item.PostalCode1
                        ChakavakInsertCmd.Parameters("@NPCA_Address1").Value = item.Address1
                        ChakavakInsertCmd.Parameters("@NPCA_Tel1").Value = item.Tel1
                        ChakavakInsertCmd.Parameters("@NPCA_ReferTo").Value = item.referTo
                        ChakavakAthInsertCmd.ExecuteNonQuery()
                    Next
                End If
            End If
        Catch ex As Exception
            lboxLog.Items.Insert(0, "Error in Saving Data" + vbCrLf)
            Return -1
        End Try
        lboxLog.Items.Insert(0, "-----------------------------------------" + vbCrLf)
        Application.DoEvents()


    End Function

    Private Sub btnRequestSend_Click(sender As Object, e As EventArgs) Handles btnRequestSend.Click

        Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Dim ChakavakRequestGetAllDataCmd = New System.Data.SqlClient.SqlCommand
        ChakavakRequestGetAllDataCmd.CommandText = "dbo.[ChakavakRequestGetAllData]"
        ChakavakRequestGetAllDataCmd.CommandType = System.Data.CommandType.StoredProcedure
        ChakavakRequestGetAllDataCmd.Connection = SqlConnection1
        ChakavakRequestGetAllDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        ChakavakRequestGetAllDataCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.NVarChar, 10))
        Dim sqlConnectionString As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=MICRDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=50"
        SqlConnection1.ConnectionString = sqlConnectionString
        SqlConnection1.Open()
        ChakavakRequestGetAllDataCmd.Parameters("@Date").Value = "1393/11/04"
        Dim res As SqlClient.SqlDataReader = ChakavakRequestGetAllDataCmd.ExecuteReader
        While res.Read
            Dim CHQ As New Cheque
            Dim BDY As New Body

            'Set Header Values
            Dim HDR As New Header
            HDR.ChequeID() = res.Item("H_ChequeId")
            HDR.DepositDate() = res.Item("H_DepositDate")
            HDR.SettlementDate() = res.Item("H_SettlementDate")
            HDR.Amount() = res.Item("H_Amount")
            HDR.UserName() = res.Item("H_UserName")

            'Set Request Values
            Dim RQS As New Request
            RQS.Submitter() = res.Item("RQS_Submitter")
            RQS.Priority() = res.Item("RQS_Priority")
            RQS.SeqNo() = res.Item("RQS_SeqNo")
            RQS.PartialSettlement() = res.Item("RQS_PartialSettlement")
            RQS.Coded() = res.Item("RQS_Coded")
            RQS.ProminentStamp() = res.Item("RQS_ProminentStamp")
            RQS.Regressive() = res.Item("RQS_Regressive")
            RQS.InstrId() = res.Item("RQS_InstrId")

            Dim DBT As New Debtor
            DBT.Name() = res.Item("DBT_Name")
            DBT.IBAN() = res.Item("DBT_IBAN")
            DBT.BIC() = res.Item("DBT_BIC")
            DBT.BranchCode() = res.Item("DBT_BranchCode")
            RQS.Debtor() = DBT

            Dim CRT As New Creditor
            CRT.Name() = res.Item("CRT_Name")
            CRT.IBAN() = res.Item("CRT_IBAN")
            CRT.NationalCode() = res.Item("CRT_NationalCode")
            CRT.BIC() = res.Item("CRT_BIC")
            CRT.BranchCode() = res.Item("CRT_BranchCode")
            RQS.Creditor() = CRT

            Dim RQD As New RequestData
            Dim Picstream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\New Bitmap Image.bmp", FileMode.Open)
            Dim FPic() As Byte = New Byte(Picstream.Length) {}
            Dim Picstream1 As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\New Bitmap Image1.bmp", FileMode.Open)
            Dim BPic() As Byte = New Byte(Picstream1.Length) {}

            Picstream.Read(FPic, 0, Picstream.Length)
            Picstream1.Read(BPic, 0, Picstream1.Length)
            RQD.Front() = FPic
            RQD.Back() = BPic
            RQS.RequestData() = RQD

            Picstream.Close()
            Picstream.Dispose()
            Picstream = Nothing
            Picstream1.Close()
            Picstream1.Dispose()
            Picstream1 = Nothing
            'Assign Classes to ChequeClass
            CHQ.Header() = HDR
            BDY.Item() = RQS
            CHQ.Body() = BDY


            Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
            Dim stream As MemoryStream = New MemoryStream()
            ser.Serialize(stream, CHQ)
            Dim XMLStr As String
            stream.Position = 0
            Dim stream1 As StreamReader = New StreamReader(stream)
            XMLStr = stream1.ReadToEnd()

            'File.Delete("C:\Users\Administrator\Desktop\MQ\aaa.xml")
            'Dim stream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\aaa.xml", FileMode.OpenOrCreate)
            'Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
            'ser.Serialize(stream, CHQ)
            'stream.Close()
            'stream.Dispose()
            'stream = Nothing
            'Dim stream1 As StreamReader = New StreamReader("C:\Users\Administrator\Desktop\MQ\aaa.xml")
            'Dim XMLStr As String = stream1.ReadToEnd()
            XMLStr = XMLStr.Replace(vbCrLf, "")
            lboxLog.Items.Insert(0, MQReq.WriteMsg(XMLStr))
            stream1.Close()
            stream1.Dispose()
            stream1 = Nothing
            stream.Close()
            stream.Dispose()
            stream = Nothing
        End While
       
    End Sub
End Class
