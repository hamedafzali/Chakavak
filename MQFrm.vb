Imports IBM.WMQ
Public Class MQFrm

 

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Test.Click
        Const MESSAGE As String = "Hello world"

        Dim mqQMgr As MQQueueManager                '* MQQueueManager instance
        Dim mqQueue As MQQueue                      '* MQQueue instance
        Dim queueName As String                     '* Name of queue to use
        Dim mqMsg As MQMessage                      '* MQMessage instance
        Dim mqPutMsgOpts As MQPutMessageOptions     '* MQPutMessageOptions instance
        Dim mqGetMsgOpts As MQGetMessageOptions     '* MQGetMessageOptions instance

        '*
        '* Try to create an MQQueueManager instance 
        '* 
        Try
            Dim props As New System.Collections.Hashtable
            Dim channelName As String
            Dim transportType As String
            Dim connectionName As String

            Dim queueManagerName As String = "LIXA"
            Dim host As String = "127.0.0.1"
            Dim port As Integer = 1414
            Dim channel As String = "LIXA.CHANNEL"
            queueName = "LIXA.QLOCAL"


            props.Add(MQC.HOST_NAME_PROPERTY, host)
            props.Add(MQC.CHANNEL_PROPERTY, channel)
            props.Add(MQC.PORT_PROPERTY, port)
            'props.Add(MQC.USER_ID_PROPERTY, "test@F-RPTSERVER")
            'props.Add(MQC.PASSWORD_PROPERTY, "11")
            'MQEnvironment.properties.(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_BINDINGS)
            'props.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_BINDINGS)
            mqQMgr = New MQQueueManager(queueManagerName, props)
            'host = "127.0.0.1(1414)"
            'mqQMgr = New MQQueueManager(queueManagerName, channel, host)

            MsgBox("it's Connected successfully")
        Catch mqe As IBM.WMQ.MQException
            '* stop if failed
            MsgBox(mqe.Reason)
            MsgBox("Exception: " + mqe.Message + vbCrLf + mqe.StackTrace)
        End Try
    End Sub

    Dim tmp As New MQExample.MQTest()
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(tmp.ConnectMQ(QueueManagerNameTxt.Text, QueueNameTxt.Text, ChannelInfoTxt.Text))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(tmp.WriteMsg(txtWriteMessage.Text))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim str As String = tmp.ReadMsg()
        txtReadMessage.Text = str
        MsgBox(str)
    End Sub
End Class


Namespace MQExample
    Public Class MQTest
        Private queueManager As MQQueueManager
        Private queue As MQQueue
        Private queueMessage As MQMessage
        Private queuePutMessageOptions As MQPutMessageOptions
        Private queueGetMessageOptions As MQGetMessageOptions
        Shared QueueName As String
        Shared QueueManagerName As String
        Shared ChannelInfo As String
        Private channelName As String
        Private transportType As String
        Private connectionName As String
        Private message As String
        Public Sub New()
            'Initialisation
        End Sub

        Public Function ConnectMQ(strQueueManagerName As String, strQueueName As String, strChannelInfo As String) As String
            Dim port As Integer
            Dim props As New System.Collections.Hashtable
            Dim strReturn As [String] = ""

            QueueManagerName = strQueueManagerName
            QueueName = strQueueName
            ChannelInfo = strChannelInfo
            Dim separator As Char() = {"/"c}
            Dim ChannelParams As String()
            ChannelParams = ChannelInfo.Split(separator)

            channelName = ChannelParams(0)
            transportType = ChannelParams(1)
            connectionName = ChannelParams(2)
            port = ChannelParams(3)
            Try
                props.Add(MQC.HOST_NAME_PROPERTY, connectionName)
                props.Add(MQC.CHANNEL_PROPERTY, channelName)
                props.Add(MQC.PORT_PROPERTY, port)
                'props.Add(MQC.USER_ID_PROPERTY, "mqm")
                'props.Add(MQC.PASSWORD_PROPERTY, "11")
                'props.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES)

                queueManager = New MQQueueManager(QueueManagerName, props)

                strReturn = "Connected Successfully"
                

            Catch exp As IBM.WMQ.MQException
                strReturn = "Exception: " + exp.Message + vbCrLf + exp.StackTrace
            End Try
            Return strReturn
        End Function

        Public Function WriteMsg(strInputMsg As String) As String
            Dim strReturn As String = ""
            Try
                queue = queueManager.AccessQueue(QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING)
                message = strInputMsg
                queueMessage = New MQMessage()
                queueMessage.WriteString(message)
                queueMessage.Format = MQC.MQFMT_STRING
                queuePutMessageOptions = New MQPutMessageOptions()
                queue.Put(queueMessage, queuePutMessageOptions)
                strReturn = "Message sent to the queue successfully"
            Catch MQexp As MQException
                strReturn = "Exception: " + MQexp.Message
            Catch exp As Exception
                strReturn = "Exception: " & exp.Message
            End Try
            Return strReturn



        End Function
        Public Function ReadMsg() As String
            Dim strReturn As [String] = ""
            Try

                queue = queueManager.AccessQueue(QueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING)
                queueMessage = New MQMessage()
                queueMessage.Format = MQC.MQFMT_STRING
                queueGetMessageOptions = New MQGetMessageOptions()
                queue.[Get](queueMessage, queueGetMessageOptions)
                strReturn = queueMessage.ReadString(queueMessage.MessageLength)
            Catch MQexp As MQException
                strReturn = "Exception : " + MQexp.Message
            Catch exp As Exception
                strReturn = "Exception: " & exp.Message
            End Try
            Return strReturn
        End Function

    End Class
End Namespace



'public MQAdapter(string mqManager,string channel, string ipAddress,string putQueue, 
'                 string getQueue,int timeout, int charSet, int port)
'{
'    try
'    {
'        // IBM MQ Series server address
'        MQEnvironment.Hostname = ipAddress;
'        // server channel name
'        MQEnvironment.Channel = channel;
'        MQEnvironment.Port = 1000;
'        mqQueueManagerName = mqManager;
'        mqRequestQueueName = putQueue;
'        mqResponseQueueName = getQueue;
'        characterSet = charSet;
'        pollingTimeout = timeout;
'        // Connect to an MQ Manager, and share the connection handle with other threads
'        mqQueueManager = new MQQueueManager(mqManager,channel, ipAddress);
'        // Open Queue for Inquiry, Put Message in, and fail if Queue Manager is stopping
'        mqPutQueue = mqQueueManager.AccessQueue(putQueue, MQC.MQOO_INQUIRE | 
'        MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING|MQC.MQOO_SET_IDENTITY_CONTEXT);
'        mqGetQueue = mqQueueManager.AccessQueue(getQueue,MQC.MQOO_INPUT_AS_Q_DEF + 
'                                                MQC.MQOO_FAIL_IF_QUIESCING);
'    }
'    catch (MQException mqe)
'    {
'        throw new MQAdapterException("Error Code: " + 
'              MQAdapterErrorReasons.GetMQFailureReasonErrorCode(mqe.Reason));
'    }
'}

'public string PushMQRequestMessage(string message)
'{
'    try
'    {
'        MQMessage requestMessage = new MQMessage();

'        requestMessage.Persistence = 0;

'        requestMessage.ReplyToQueueName = mqResponseQueueName;
'        requestMessage.ReplyToQueueManagerName = mqQueueManagerName;

'        requestMessage.Format = MQC.MQFMT_STRING;
'        requestMessage.CharacterSet = characterSet;
'        requestMessage.MessageType = MQC.MQMT_REQUEST;
'        requestMessage.MessageId = HexaDecimalUtility.ConvertToBinary(GenerateMQMsgId());
'        requestMessage.CorrelationId = requestMessage.MessageId;

'        MQPutMessageOptions pmo = new MQPutMessageOptions();
'        pmo.Options = MQC.MQPMO_SET_IDENTITY_CONTEXT;

'        requestMessage.WriteString(message);

'        mqPutQueue.Put(requestMessage, pmo);
'        string _msgId = BinaryUtility.ConvertToHexaDecimal(requestMessage.MessageId);

'        return _msgId;

'    }
'    catch (MQException mqe)
'    {
'        // Close request Queue if still opened
'        if(mqPutQueue.OpenStatus)
'            mqPutQueue.Close();
'        // Close Queue manager if still opened
'        if(mqQueueManager.OpenStatus)
'            mqQueueManager.Close();

'        throw new MQAdapterException("Error Code: " + 
'                    MQAdapterErrorReasons.GetMQFailureReasonErrorCode(mqe.Reason));
'    }
'}

'public string GetMQResponseMessage(string correlationId)
'{
'    MQMessage rsMsg = new MQMessage();
'    rsMsg.CorrelationId = HexaDecimalUtility.ConvertToBinary(correlationId);

'    MQGetMessageOptions gmo = new MQGetMessageOptions();
'    gmo.Options = MQC.MQGMO_WAIT;
'    gmo.MatchOptions = MQC.MQMO_MATCH_CORREL_ID;
'    gmo.WaitInterval = pollingTimeout;

'    try
'    {
'        mqGetQueue.Get(rsMsg,gmo);
'        return rsMsg.ReadString(rsMsg.DataLength);
'    }
'    catch(MQException mqe)
'    {
'        // Close Reponse Queue if still opened
'        if(mqGetQueue.OpenStatus)
'            mqGetQueue.Close();
'        // Close Queue manager if still opened
'        if(mqQueueManager.OpenStatus)
'            mqQueueManager.Close();

'        // Check if it a timeout exception
'        if(MQAdapterErrorReasons.GetMQFailureReasonErrorCode(mqe.Reason) == 
'                      "MQRC_NO_MSG_AVAILABLE")
'            throw new MQAdapterTimeoutException("Message with correlation Id " + 
'                      correlationId + " Timed out");

'        // MQ Exception
'        throw new MQAdapterException("Error Code: " + 
'             MQAdapterErrorReasons.GetMQFailureReasonErrorCode(mqe.Reason));
'    }
'}