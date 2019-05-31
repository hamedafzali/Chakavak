Public Class ChakavakSummery
    Function FillGrid()
        Try

            Dim SqlConnection1 = New System.Data.SqlClient.SqlConnection
            Dim ChakavakSummeryCmd = New System.Data.SqlClient.SqlCommand
            Dim ChakavakGetLastDaySummeryCmd = New System.Data.SqlClient.SqlCommand
            Dim sqlConnectionString1 As String = "workstation id=PBI-FARAZ;packet size=4096;user id=sa;data source=200.200.200.222;persist security info=True;initial catalog=ChakavakDatabase;password=12;POOLING=FALSE;Enlist = false;Connect Timeout=500"
            SqlConnection1.ConnectionString = sqlConnectionString1
            SqlConnection1.Open()
            ChakavakSummeryCmd.CommandText = "dbo.[ChakavakGetDaySummery]"
            ChakavakSummeryCmd.CommandTimeout = 300
            ChakavakSummeryCmd.Connection = SqlConnection1
            ChakavakSummeryCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakSummeryCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            ChakavakGetLastDaySummeryCmd.CommandText = "dbo.[ChakavakGetLastDaySummery]"
            ChakavakGetLastDaySummeryCmd.CommandTimeout = 300
            ChakavakGetLastDaySummeryCmd.Connection = SqlConnection1
            ChakavakGetLastDaySummeryCmd.CommandType = System.Data.CommandType.StoredProcedure
            ChakavakGetLastDaySummeryCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            Dim TmpReader As SqlClient.SqlDataReader = ChakavakSummeryCmd.ExecuteReader
            ''Set view property
            ListView1.View = View.Details
            ListView1.GridLines = True
            ListView1.FullRowSelect = True
            ListView1.Items.Clear()
            Dim arr As String() = New String(5) {}
            Dim itm As ListViewItem
            While TmpReader.Read()
                arr(0) = TmpReader.Item(0)
                arr(1) = TmpReader.Item(1)
                arr(2) = TmpReader.Item(2)
                arr(3) = TmpReader.Item(3)
                arr(4) = TmpReader.Item(4)
                itm = New ListViewItem(arr)
                itm.ForeColor = Color.Black
                If arr(2) = "ارسال شده" And Int(arr(3)) < 10 Then
                    itm.ForeColor = Color.Black
                ElseIf arr(2) = "ارسال شده" And Int(arr(3)) < 50 Then
                    itm.ForeColor = Color.DarkViolet
                ElseIf arr(2) = "ارسال شده" And Int(arr(3)) >= 50 Then
                    itm.ForeColor = Color.Red
                End If

                ListView1.Items.Insert(0, itm)
            End While
            TmpReader.Close()
            Dim TmpReader1 As SqlClient.SqlDataReader = ChakavakGetLastDaySummeryCmd.ExecuteReader
            ''Set view property
            ListView2.View = View.Details
            ListView2.GridLines = True
            ListView2.FullRowSelect = True
            ListView2.Items.Clear()
            Dim arr1 As String() = New String(5) {}
            Dim itm1 As ListViewItem
            lblVosol.Text = "0"
            lblVosolPercent.Text = "0"
            lblBargasht.Text = "0"
            lblBargashtPercent.Text = "0"
            lblOdat.Text = "0"
            lblOdatPercent.Text = "0"
            lblSabti.Text = "0"
            lblSabtiPercent.Text = "0"
            lblTotal.Text = "0"

            lblVosolV.Text = "0"
            lblVosolPercentV.Text = "0"
            lblBargashtV.Text = "0"
            lblBargashtPercentV.Text = "0"
            lblOdatV.Text = "0"
            lblOdatPercentV.Text = "0"
            lblSabtiV.Text = "0"
            lblSabtiPercentV.Text = "0"
            lblTotalV.Text = "0"
            While TmpReader1.Read()
                arr1(0) = TmpReader1.Item(0)
                arr1(1) = TmpReader1.Item(1)
                arr1(2) = TmpReader1.Item(2)
                arr1(3) = TmpReader1.Item(3)
                arr1(4) = TmpReader1.Item(4)
                itm1 = New ListViewItem(arr1)
                itm1.ForeColor = Color.Black
                ListView2.Items.Insert(0, itm1)
                If arr1(0) = "عهده" Then
                    lblTotal.Text += TmpReader1.Item(3)
                    Select Case TmpReader1.Item(2)
                        Case "ثبت"
                            lblSabti.Text = CType(lblSabti.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "وصولي"
                            lblVosol.Text = CType(lblVosol.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "وصولي رفع سوء نشده"
                            lblVosol.Text = CType(lblVosol.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "برگشتي"
                            lblBargasht.Text = CType(lblBargasht.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "عودتي"
                            lblOdat.Text = CType(lblOdat.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                    End Select
                End If
                If arr1(0) = "واگذاري" Then
                    lblTotalV.Text += TmpReader1.Item(3)
                    Select Case TmpReader1.Item(2)
                        Case "واگذاري"
                            lblSabtiV.Text = CType(lblSabtiV.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "ثبت"
                            lblSabtiV.Text = CType(lblSabtiV.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "وصولي"
                            lblVosolV.Text = CType(lblVosolV.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "برگشتي"
                            lblBargashtV.Text = CType(lblBargashtV.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                        Case "عودتي"
                            lblOdatV.Text = CType(lblOdatV.Text, Integer) + CType(TmpReader1.Item(3), Integer)
                    End Select
                End If
            End While
            lblSabtiPercent.Text = CType((lblSabti.Text / lblTotal.Text) * 100, Integer)
            lblVosolPercent.Text = CType((lblVosol.Text / lblTotal.Text) * 100, Integer)
            lblBargashtPercent.Text = CType((lblBargasht.Text / lblTotal.Text) * 100, Integer)
            lblOdatPercent.Text = CType((lblOdat.Text / lblTotal.Text) * 100, Integer)
            lblSabtiPercentV.Text = CType((lblSabtiV.Text / lblTotalV.Text) * 100, Integer)
            lblVosolPercentV.Text = CType((lblVosolV.Text / lblTotalV.Text) * 100, Integer)
            lblBargashtPercentV.Text = CType((lblBargashtV.Text / lblTotalV.Text) * 100, Integer)
            lblOdatPercentV.Text = CType((lblOdatV.Text / lblTotalV.Text) * 100, Integer)
            TmpReader1.Close()
            SqlConnection1.Close()
            FillMessageCBI()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Function
    Private Sub ChakavakSummery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FillGrid()
        Dim FillGridThread As New System.Threading.Thread(AddressOf FillGrid)
        FillGridThread.Start()

        Timer1.Interval = 15000
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim FillGridThread As New System.Threading.Thread(AddressOf FillGrid)
        FillGridThread.Start()
    End Sub
    Function FillMessageCBI()
        Try
            ''Set view property
            ListView3.View = View.Details
            ListView3.GridLines = True
            ListView3.FullRowSelect = True
            ListView3.Items.Clear()

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
                ListView3.Items.Insert(0, itm)

            Next
            Application.DoEvents()


        Catch ex As Exception
            Try
                ListView2.Items.Insert(0, ex.Message.ToString)
            Catch ex1 As Exception

            End Try

        End Try

    End Function
End Class