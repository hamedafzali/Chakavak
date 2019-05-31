Imports IBM.WMQ

Namespace MQExampleRequest
    Public Class MQRequest
        Private queueManager As MQQueueManager
        Private queue As MQQueue
        Private queueMessage As MQMessage
        Private queuePutMessageOptions As MQPutMessageOptions
        Private queueGetMessageOptions As MQGetMessageOptions
        Shared QueueNameIn As String
        Shared QueueNameOut As String
        Shared QueueManagerName As String
        Shared ChannelInfo As String
        Private channelName As String
        Private transportType As String
        Private connectionName As String
        Private message As String
        Public Sub New()
            'Initialisation
        End Sub

        Public Function ConnectMQ(strQueueManagerName As String, strQueueNameIn As String, strQueueNameOut As String, strChannelInfo As String) As String
            Dim port As Integer
            Dim props As New System.Collections.Hashtable
            Dim strReturn As [String] = ""

            QueueManagerName = strQueueManagerName
            QueueNameIn = strQueueNameIn
            QueueNameOut = strQueueNameOut
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
                queue = queueManager.AccessQueue(QueueNameIn, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING)
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

                queue = queueManager.AccessQueue(QueueNameIn, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING)
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
Namespace MQExampleResponse
    Public Class MQResponse
        Private queueManager As MQQueueManager
        Private queue As MQQueue
        Private queueMessage As MQMessage
        Private queuePutMessageOptions As MQPutMessageOptions
        Private queueGetMessageOptions As MQGetMessageOptions
        Shared QueueNameIn As String
        Shared QueueNameOut As String
        Shared QueueManagerName As String
        Shared ChannelInfo As String
        Private channelName As String
        Private transportType As String
        Private connectionName As String
        Private message As String
        Public Sub New()
            'Initialisation
        End Sub

        Public Function ConnectMQ(strQueueManagerName As String, strQueueNameIn As String, strQueueNameOut As String, strChannelInfo As String) As String
            Dim port As Integer
            Dim props As New System.Collections.Hashtable
            Dim strReturn As [String] = ""

            QueueManagerName = strQueueManagerName
            QueueNameIn = strQueueNameIn
            QueueNameOut = strQueueNameOut
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
                queue = queueManager.AccessQueue(QueueNameOut, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING)
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

                queue = queueManager.AccessQueue(QueueNameIn, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING)
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
