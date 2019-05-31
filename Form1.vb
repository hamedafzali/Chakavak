Imports System.Xml
Imports System.Data
Imports System.IO
Imports IBM.WMQ
Imports System.Threading

Public Class Form1
    Dim tmp As New MQExample.MQTest()
    Private tmpThread As Threading.Thread



    Private Sub MqConnectBtn_Click(sender As Object, e As EventArgs) Handles RqsInMqConnectBtn.Click
        MsgBox(tmp.ConnectMQ(QueueManagerNameTxt.Text, RqsInQueueNameTxt.Text, RqsChannelInfoTxt.Text))
    End Sub

    Private Sub ReqReadBtn_Click(sender As Object, e As EventArgs) Handles ReqReadBtn.Click

        Dim CHQ As New Cheque
        Dim BDY As New Body
        Dim HDR As New Header
        Dim RQS As New Request
        Dim DBT As New Debtor
        Dim CRT As New Creditor
        Dim RQD As New RequestData

        'Dim stream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\Request.In.xml", FileMode.Open)
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\Users\Administrator\Desktop\MQ"
        fd.Filter = "All files (*.xml)|*.xml"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

        Dim stream As Stream = File.Open(strFileName, FileMode.Open)
        Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
        CHQ = CType(ser.Deserialize(stream), Cheque)

        HDR = CHQ.Header
        BDY = CHQ.Body
        RQS = BDY.Item
        DBT = RQS.Debtor
        CRT = RQS.Creditor
        RQD = RQS.RequestData

        Dim HDRChequeID As String = HDR.ChequeID
        Dim HDRDepositDate As String = HDR.DepositDate
        Dim HDRSettlementDate As String = HDR.SettlementDate
        Dim HDRAmount As String = HDR.Amount
        Dim HDRUserName As String = HDR.UserName

        Dim RQSSubmitter As String = RQS.Submitter
        Dim RQSPriority As String = RQS.Priority
        Dim RQSSeqNo As String = RQS.SeqNo
        Dim RQSPartialSettlement As Boolean = RQS.PartialSettlement
        Dim RQSCoded As Boolean = RQS.Coded
        Dim RQSProminentStamp As Boolean = RQS.ProminentStamp
        Dim RQSRegressive As String = RQS.Regressive
        Dim RQSInstrId As String = RQS.InstrId

        Dim DBTName As String = DBT.Name
        Dim DBTIBAN As String = DBT.IBAN
        Dim DBTBIC As String = DBT.BIC
        Dim DBTBranchCode As String = DBT.BranchCode

        Dim CRTName As String = CRT.Name
        Dim CRTIBAN As String = CRT.IBAN
        Dim CRTNationalCode As String = CRT.NationalCode
        Dim CRTBIC As String = CRT.BIC
        Dim CRTBranchCode As String = CRT.BranchCode

        Dim RQDFPic() As Byte = RQD.Front
        Dim RQDBPic() As Byte = RQD.Back


        Dim FBitmap, BBitmap As Bitmap
        FBitmap = New Bitmap(200, 150)
        BBitmap = New Bitmap(200, 150)
        Dim FSTRM As New MemoryStream(RQDFPic)
        Dim BSTRM As New MemoryStream(RQDBPic)
        FBitmap = Bitmap.FromStream(FSTRM)
        BBitmap = Bitmap.FromStream(BSTRM)
        PictureBox1.Image = FBitmap
        PictureBox2.Image = BBitmap
    End Sub

    Private Sub MQReqReadBtn_Click(sender As Object, e As EventArgs) Handles MQReqReadBtn.Click
        Dim str As String = tmp.ReadMsg()
        txtReadMessage.Text = str


        Dim CHQ As New Cheque
        Dim BDY As New Body
        Dim HDR As New Header
        Dim RQS As New Request
        Dim DBT As New Debtor
        Dim CRT As New Creditor
        Dim RQD As New RequestData

        'Dim stream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\Request.In.xml", FileMode.Open)
        Dim stream As StringReader = New StringReader(str)
        Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
        CHQ = CType(ser.Deserialize(stream), Cheque)
        SaveData(CHQ, "Request")
        'HDR = CHQ.Header
        'BDY = CHQ.Body
        'RQS = BDY.Item
        'DBT = RQS.Debtor
        'CRT = RQS.Creditor
        'RQD = RQS.RequestData

        'Dim HDRChequeID As String = HDR.ChequeID
        'Dim HDRDepositDate As String = HDR.DepositDate
        'Dim HDRSettlementDate As String = HDR.SettlementDate
        'Dim HDRAmount As String = HDR.Amount
        'Dim HDRUserName As String = HDR.UserName

        'Dim RQSSubmitter As String = RQS.Submitter
        'Dim RQSPriority As String = RQS.Priority
        'Dim RQSSeqNo As String = RQS.SeqNo
        'Dim RQSPartialSettlement As Boolean = RQS.PartialSettlement
        'Dim RQSCoded As Boolean = RQS.Coded
        'Dim RQSProminentStamp As Boolean = RQS.ProminentStamp
        'Dim RQSRegressive As String = RQS.Regressive
        'Dim RQSInstrId As String = RQS.InstrId

        'Dim DBTName As String = DBT.Name
        'Dim DBTIBAN As String = DBT.IBAN
        'Dim DBTBIC As String = DBT.BIC
        'Dim DBTBranchCode As String = DBT.BranchCode

        'Dim CRTName As String = CRT.Name
        'Dim CRTIBAN As String = CRT.IBAN
        'Dim CRTNationalCode As String = CRT.NationalCode
        'Dim CRTBIC As String = CRT.BIC
        'Dim CRTBranchCode As String = CRT.BranchCode

        'Dim RQDFPic() As Byte = RQD.Front
        'Dim RQDBPic() As Byte = RQD.Back


        'Dim FBitmap, BBitmap As Bitmap
        'FBitmap = New Bitmap(200, 150)
        'BBitmap = New Bitmap(200, 150)
        'Dim FSTRM As New MemoryStream(RQDFPic)
        'Dim BSTRM As New MemoryStream(RQDBPic)
        'FBitmap = Bitmap.FromStream(FSTRM)
        'BBitmap = Bitmap.FromStream(BSTRM)
        'PictureBox1.Image = FBitmap
        'PictureBox2.Image = BBitmap

    End Sub

    Private Sub ReqWriteBtn_Click(sender As Object, e As EventArgs) Handles ReqWriteBtn.Click
        MsgBox(tmp.WriteMsg(txtWriteMessage.Text))
        Return
        Dim CHQ As New Cheque
        Dim BDY As New Body

        'Set Header Values
        Dim HDR As New Header
        HDR.ChequeID() = "1234"
        HDR.DepositDate() = "1393/08/29"
        HDR.SettlementDate() = "1393/08/29"
        HDR.Amount() = "250000000"
        HDR.UserName() = "admin"

        'Set Request Values
        Dim RQS As New Request
        RQS.Submitter() = "PBIRIRTHXXX"
        RQS.Priority() = ""
        RQS.SeqNo() = "PBIR139308292109104999999"
        RQS.PartialSettlement() = False
        RQS.Coded() = False
        RQS.ProminentStamp() = False
        RQS.Regressive() = "NO_ACTION"
        RQS.InstrId() = ""

        Dim DBT As New Debtor
        DBT.Name() = "بهرام باقري"
        DBT.IBAN() = "IR230140040000013006878295"
        DBT.BIC() = "BKMNIRTHXXX"
        DBT.BranchCode() = "1429"
        RQS.Debtor = DBT

        Dim CRT As New Creditor
        CRT.Name() = "حامد افضلی نژاد"
        CRT.IBAN() = "IR710210363721319068661001"
        CRT.NationalCode() = "0060806923"
        CRT.BIC() = "PBIRIRTHXXX"
        CRT.BranchCode() = "3637"
        RQS.Creditor = CRT

        Dim RQD As New RequestData
        Dim Picstream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\New Bitmap Image.bmp", FileMode.Open)
        Dim FPic() As Byte = New Byte(Picstream.Length) {}
        Dim Picstream1 As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\New Bitmap Image1.bmp", FileMode.Open)
        Dim BPic() As Byte = New Byte(Picstream1.Length) {}


        Picstream.Read(FPic, 0, Picstream.Length)
        Picstream1.Read(BPic, 0, Picstream1.Length)
        RQD.Front() = FPic
        RQD.Back() = BPic
        RQS.RequestData = RQD

        'Assign Classes to ChequeClass
        CHQ.Header = HDR
        BDY.Item = RQS
        CHQ.Body = BDY
        Dim stream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\aaa.xml", FileMode.OpenOrCreate)
        Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
        ser.Serialize(stream, CHQ)
    End Sub

    Private Sub MQReqWriteBtn_Click(sender As Object, e As EventArgs) Handles MQReqWriteBtn.Click

        Dim CHQ As New Cheque
        Dim BDY As New Body

        'Set Header Values
        Dim HDR As New Header
        HDR.ChequeID() = "1111/1111111"
        HDR.DepositDate() = "1393/01/01"
        HDR.SettlementDate() = "1393/09/16"
        HDR.Amount() = "1000000"
        HDR.UserName() = "admin"

        'Set Request Values
        Dim RQS As New Request
        RQS.Submitter() = "PBIRIRTHXXX"
        RQS.Priority() = ""
        RQS.SeqNo() = "PBIR139309012109104999998"
        RQS.PartialSettlement() = False
        RQS.Coded() = False
        RQS.ProminentStamp() = False
        RQS.Regressive() = "NO_ACTION"
        RQS.InstrId() = ""

        Dim DBT As New Debtor
        DBT.Name() = "بهرام باقري"
        DBT.IBAN() = "IR170630351204200171424007"
        DBT.BIC() = "ANSBIRTHXXX"
        DBT.BranchCode() = "1429"
        RQS.Debtor = DBT

        Dim CRT As New Creditor
        CRT.Name() = "حامد افضلی نژاد"
        CRT.IBAN() = "IR710210363721319068661001"
        CRT.NationalCode() = "0060806923"
        CRT.BIC() = "PBIRIRTHXXX"
        CRT.BranchCode() = "3637"
        RQS.Creditor = CRT

        Dim RQD As New RequestData
        Dim Picstream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\New Bitmap Image.bmp", FileMode.Open)
        Dim FPic() As Byte = New Byte(Picstream.Length) {}
        Dim Picstream1 As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\New Bitmap Image1.bmp", FileMode.Open)
        Dim BPic() As Byte = New Byte(Picstream1.Length) {}

        Picstream.Read(FPic, 0, Picstream.Length)
        Picstream1.Read(BPic, 0, Picstream1.Length)
        RQD.Front() = FPic
        RQD.Back() = BPic
        RQS.RequestData = RQD

        Picstream.Close()
        Picstream.Dispose()
        Picstream = Nothing
        Picstream1.Close()
        Picstream1.Dispose()
        Picstream1 = Nothing
        'Assign Classes to ChequeClass
        CHQ.Header = HDR
        BDY.Item = RQS
        CHQ.Body = BDY
        Dim stream As Stream = File.Open("C:\Users\Administrator\Desktop\MQ\aaa.xml", FileMode.OpenOrCreate)
        Dim ser As New Xml.Serialization.XmlSerializer(GetType(Cheque))
        ser.Serialize(stream, CHQ)
        stream.Close()
        stream.Dispose()
        stream = Nothing
        Dim stream1 As StreamReader = New StreamReader("C:\Users\Administrator\Desktop\MQ\aaa.xml")
        Dim XMLStr As String = stream1.ReadToEnd()
        MsgBox(tmp.WriteMsg(XMLStr))
        stream1.Close()
        stream1.Dispose()
        stream1 = Nothing
    End Sub

    Private Sub MQFormBtn_Click(sender As Object, e As EventArgs) Handles MQFormBtn.Click
        Dim MQ As New MQFrm
        MQ.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConnectionStringDrop.SelectedIndexChanged

        Dim separator As Char() = {"/"c}
        Dim ChannelParams As String()
        ChannelParams = ConnectionStringDrop.Text.Split(separator)
        QueueManagerNameTxt.Text = ChannelParams(0)
        RqsInQueueNameTxt.Text = ChannelParams(1)
        RqsChannelInfoTxt.Text = ChannelParams(2) + "/" + ChannelParams(3) + "/" + ChannelParams(4) + "/" + ChannelParams(5)

    End Sub
    Function SaveData(Cheque As Cheque, Type As String)
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
        Select Case Type
            Case "Request"
                HDR = Cheque.Header
                BDY = Cheque.Body
                REQ = BDY.Item
                DBT = REQ.Debtor
                CRT = REQ.Creditor
                RD = REQ.RequestData
            Case "Response"
                HDR = Cheque.Header
                BDY = Cheque.Body
                RES = BDY.Item
                DBT = RES.Debtor
                CRT = RES.Creditor
                NPC = RES.NonPaymentCertificate
                CI = NPC.ChequeIssuer
                Ath = NPC.Authorised
            Case "Acknowledge"
                HDR = Cheque.Header
                BDY = Cheque.Body
                ACK = BDY.Item
                DBT = ACK.Debtor
                CRT = ACK.Creditor
            Case "Action"
                HDR = Cheque.Header
                BDY = Cheque.Body
                ACN = BDY.Item

        End Select




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


    End Function
    Function ReadData()
        Dim CHQ As New Cheque
        Dim BDY As New Body
        Dim RES As New Response
        RES.Status() = ""
        RES.SeqNo() = ""
        RES.TRN() = ""
        RES.Submitter() = ""
        RES.Reason() = ""
        Dim DBT As New Debtor
        DBT.Name() = ""
        DBT.IBAN() = ""
        DBT.BIC() = ""
        DBT.BranchCode() = ""
        Dim CRT As New Creditor
        CRT.Name() = ""
        CRT.IBAN() = ""
        CRT.NationalCode() = ""
        CRT.BIC() = ""
        CRT.BranchCode() = ""
        Dim NPL As New NonPaymentCertificate
        NPL.OtherAuthorised() = ""
        Dim NPCCI As New ChequeIssuer
        NPCCI.AccountType() = ""
        NPCCI.referTo() = ""
        NPCCI.Name() = ""
        NPCCI.BirthCertNumOrRegNum() = ""
        NPCCI.BirthDateOrRegDate() = ""
        NPCCI.IssueLocationOrRegLocation() = ""
        NPCCI.LocationCode() = ""
        NPCCI.OfficeCode() = ""
        NPCCI.FatherName() = ""
        NPCCI.NationalID() = ""
        NPCCI.PostalCode1() = ""
        NPCCI.PostalCode2() = ""
        NPCCI.Address1() = ""
        NPCCI.Address2() = ""
        NPCCI.Tel1() = ""
        NPCCI.Tel2() = ""
        NPCCI.CurAccBal() = ""
        NPCCI.OnIssueDateAccBal() = ""
        NPCCI.IsSettled() = ""
        Dim NPLA As New Authorised
        NPLA.FullName() = ""
        NPLA.BirthCertNumOrRegNum() = ""
        NPLA.BirthDateOrRegDate() = ""
        NPLA.IssueLocationOrRegLocation() = ""
        NPLA.LocationCode() = ""
        NPLA.FatherName() = ""
        NPLA.NationalID() = ""
        NPLA.PostalCode1() = ""
        NPLA.Address1() = ""
        NPLA.Tel1() = ""
        NPLA.referTo() = ""

    End Function


   
End Class


'Dim SR As New StreamReader("C:\Users\Administrator\Desktop\MQ\Request.In.xml")
''Dim dataStr As String = SR.ReadToEnd
'Dim XMLDataSet As New DataSet
'XMLDataSet.ReadXml(SR, XmlReadMode.InferSchema)
''Dim a As String = XMLDataSet.Tables(0).Rows(0).Item(0)
''DataGridView1.DataSource = XMLDataSet.Tables(0)
'For i As Integer = 0 To XMLDataSet.Tables.Count
'    MessageBox.Show(XMLDataSet.Tables(i - 1).TableName)
'Next
'Dim ChequeID, DepositDate, SettlementDate, Amount, UserName, Submitter, Priority, SeqNo, PartialSettlement, Coded, ProminentStamp, Regressive As String
'Dim DebtorName, DebtorIBAN, DebtorBIC, DebtorBranchCode, CreditorName, CreditorIBAN, CreditorNationalCode, CreditorBIC, CreditorBranchCode, RequestDataFront, RequestDataBack As String
'Dim doc As New XmlDocument()
'Dim Header, Request, Response, Acknowledge As XmlNodeList

'doc.Load(SR)
'Header = doc.DocumentElement.SelectNodes("/Cheque/Header")
'Request = doc.DocumentElement.SelectNodes("/Cheque/Body/Request")
'Response = doc.DocumentElement.SelectNodes("/Cheque/Body/Response")
'Acknowledge = doc.DocumentElement.SelectNodes("/Cheque/Body/Acknowledge")

'For index As Integer = 0 To Header.Count - 1
'    ChequeID = Header.Item(index).ChildNodes.Item(0).InnerText
'    DepositDate = Header.Item(index).ChildNodes.Item(1).InnerText
'    SettlementDate = Header.Item(index).ChildNodes.Item(2).InnerText
'    Amount = Header.Item(index).ChildNodes.Item(3).InnerText
'    UserName = Header.Item(index).ChildNodes.Item(4).InnerText

'Next

'If Request.Count = 1 Then
'    For Each item As XmlNode In Header
'        Submitter = item.ChildNodes.Item(0).Name
'    Next
'    Submitter = Request.Item(0).ChildNodes.Item(0).InnerText
'    Priority = Request.Item(0).ChildNodes.Item(1).InnerText
'    SeqNo = Request.Item(0).ChildNodes.Item(2).InnerText
'    PartialSettlement = Request.Item(0).ChildNodes.Item(3).InnerText
'    Coded = Request.Item(0).ChildNodes.Item(4).InnerText
'    ProminentStamp = Request.Item(0).ChildNodes.Item(5).InnerText
'    Regressive = Request.Item(0).ChildNodes.Item(6).InnerText

'    DebtorName = Request.Item(0).ChildNodes.Item(7).ChildNodes.Item(0).InnerText
'    DebtorIBAN = Request.Item(0).ChildNodes.Item(7).ChildNodes.Item(1).InnerText
'    DebtorBIC = Request.Item(0).ChildNodes.Item(7).ChildNodes.Item(2).InnerText
'    DebtorBranchCode = Request.Item(0).ChildNodes.Item(7).ChildNodes.Item(3).InnerText

'    CreditorName = Request.Item(0).ChildNodes.Item(8).ChildNodes.Item(0).InnerText
'    CreditorIBAN = Request.Item(0).ChildNodes.Item(8).ChildNodes.Item(1).InnerText
'    CreditorNationalCode = Request.Item(0).ChildNodes.Item(8).ChildNodes.Item(2).InnerText
'    CreditorBIC = Request.Item(0).ChildNodes.Item(8).ChildNodes.Item(3).InnerText
'    CreditorBranchCode = Request.Item(0).ChildNodes.Item(8).ChildNodes.Item(4).InnerText


'    RequestDataFront = Request.Item(0).ChildNodes.Item(9).ChildNodes.Item(0).InnerText
'    RequestDataBack = Request.Item(0).ChildNodes.Item(9).ChildNodes.Item(1).InnerText

'ElseIf Response.Count = 1 Then

'ElseIf Acknowledge.Count = 1 Then

'End If
