Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports log4net

Public Class frmCardOperation


    Private Sub Browsebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browsebtn.Click
        UploadFile()
    End Sub

#Region "Fields"
    Private Shared tmplog As log4net.ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private tmpThread As Threading.Thread
    Private OperationStatus As Boolean = False
    Private sqlConnection As Data.SqlClient.SqlConnection
    Private PageName As String = "frmCardOperation"

    Dim tmpCardManagment As New CardService.CardService
#End Region

#Region "Functions"
    Public Function HaveAccess() As Boolean
        sqlConnection = dbConnection.getConnection
        Dim accessHandler As New GlobalBusiness.AccessControl
        Dim result As New GlobalBusiness.AccessControl.AccessResult
        result = accessHandler.HaveAccess(sqlConnection, UserId, PageName)
        If Not result.finalResult Then
            MessageBox.Show(result.Message)
        End If
        Return result.finalResult
    End Function
    Function UploadFile()
        OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Filter = "Microsoft Excel 2003 files (*.xls)|*.xls"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog Then
            Fileuptxt.Text = OpenFileDialog1.FileName
            ListDGrid.DataSource = ""
            ResultGrid.DataSource = ""
        End If
        Dim resultStr As String = ""
        Try
            Dim connection As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Fileuptxt.Text + "; Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
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
                Fileuptxt.Text = ""
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
#End Region

    Private Sub ActivateCardbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivateCardbtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow
        Dim CardNo As String

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "HotReason"
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
        column.ColumnName = "UserId"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ' ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try
                CardNo = ""

                ProgressBar1.PerformStep()
                If ListDGrid.Item(0, counter).Value.ToString.Length = 16 Then

                    Dim HotResoan As String
                    Dim Status As Integer
                    Dim CurrentDate As String
                    Status = ListDGrid.Item(1, counter).Value
                    HotResoan = ListDGrid.Item(2, counter).Value
                    CurrentDate = (New GlobalClass.FarsiDate).lastDate((New GlobalClass.FarsiDate).GetDate())
                    CardNo = ListDGrid.Item(0, counter).Value
                    Authentication()
                    res = tmpCardManagment.ChangeCardStatus(CardNo, Status, HotResoan, "9104", "9104", CurrentDate, "1")
                    If res = 1 Then
                        row = dt.NewRow()
                        row("CardNo") = CardNo
                        row("Status") = Status
                        ' row("HotResoan") = HotResoan
                        row("Status") = "Done"

                        dt.Rows.Add(row)
                    Else
                        row = dt.NewRow()
                        row("CardNo") = CardNo
                        row("Status") = Status
                        ' row("HotResoan") = ""
                        row("Status") = "Not Found"
                        dt.Rows.Add(row)
                    End If
                Else
                    row = dt.NewRow()
                    row("CardNo") = CardNo
                    row("Status") = ListDGrid.Item(1, counter).Value
                    row("HotResoan") = ListDGrid.Item(2, counter).Value
                    row("Status") = "CardNo is not valid"
                    dt.Rows.Add(row)
                End If

                Application.DoEvents()

            Catch ex As Exception

            End Try

        Next
        ResultGrid.DataSource = dt
    End Sub

    Private Sub frmCardOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not HaveAccess() Then
            Me.Close()
            Return
        End If
    End Sub

    Private Sub ChangeAccNobtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeAccNobtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow
       
        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "NationalCode"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "OldAccNo"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "NewAccNo"
        dt.Columns.Add(column)
        dt.Clear()

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try
                
                ProgressBar1.PerformStep()
                'If ListDGrid.Item(0, counter).Value.ToString.Length = 10 Then


                Dim NationalCode As String = ""
                Dim NewAccNo As String = ""
                Dim OldAccNo As String = ""
                OldAccNo = ListDGrid.Item(1, counter).Value
                NationalCode = ListDGrid.Item(0, counter).Value
                NewAccNo = ListDGrid.Item(2, counter).Value
                Authentication()
                res = tmpCardManagment.ChangeAccNo_Map_ByNationalCode(NationalCode, OldAccNo, NewAccNo)
                If res = 1 Then
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("OldAccNo") = OldAccNo
                    row("NewAccNo") = NewAccNo
                    row("Status") = "Success"
                    dt.Rows.Add(row)
                Else
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("OldAccNo") = OldAccNo
                    row("NewAccNo") = NewAccNo
                    row("Status") = "Not Found"
                    dt.Rows.Add(row)
                End If
                ' Else
                'row = dt.NewRow()
                'row("NationalCode") = ListDGrid.Item(0, counter).Value
                'row("OldAccNo") = ListDGrid.Item(1, counter).Value
                'row("NewAccNo") = ListDGrid.Item(2, counter).Value
                'row("Status") = "NationalCode is not valid"
                'dt.Rows.Add(row)
                'End If
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub

    Private Sub ChangeCustomerInfobtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCustomerInfobtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "NationalCode"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Name"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "LastName"
        dt.Columns.Add(column)
        dt.Clear()

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try

                ProgressBar1.PerformStep()
                '  If ListDGrid.Item(0, counter).Value.ToString.Length = 10 Then


                Dim NationalCode As String = ""
                Dim Name As String = ""
                Dim LastName As String = ""
                Name = ListDGrid.Item(1, counter).Value
                NationalCode = ListDGrid.Item(0, counter).Value
                LastName = ListDGrid.Item(2, counter).Value
                Authentication()
                res = tmpCardManagment.ChangeCustomerInfo(NationalCode, Name, LastName)
                If res = 1 Then
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("Name") = Name
                    row("LastName") = LastName
                    row("Status") = "Success"
                    dt.Rows.Add(row)
                Else
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("Name") = Name
                    row("LastName") = LastName
                    row("Status") = "Not Found"
                    dt.Rows.Add(row)
                End If
                ' Else
                'row = dt.NewRow()
                'row("NationalCode") = ListDGrid.Item(0, counter).Value
                'row("Name") = ListDGrid.Item(1, counter).Value
                'row("LastName") = ListDGrid.Item(2, counter).Value
                'row("Status") = "NationalCode is not valid"
                'dt.Rows.Add(row)
                'End If
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub

    Private Sub GetCardNoByNationalCodebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetCardNoByNationalCodebtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "NationalCode"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)
        dt.Clear()
      
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try

                ProgressBar1.PerformStep()
                ' If ListDGrid.Item(0, counter).Value.ToString.Length = 10 Then

                Dim NationalCode As String = ""
                Dim CardNo As String = ""
                NationalCode = ListDGrid.Item(0, counter).Value
                Authentication()
                tmpCardManagment.Get_CardNo_ByNationalCode(NationalCode, CardNo)
                If CardNo.Length <> 0 Then
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("CardNo") = CardNo

                    row("Status") = "Success"
                    dt.Rows.Add(row)
                Else
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("CardNo") = CardNo

                    row("Status") = "Not Found"
                    dt.Rows.Add(row)
                End If
                'Else
                'row = dt.NewRow()
                'row("NationalCode") = ListDGrid.Item(0, counter).Value
                'row("CardNo") = ""
                'row("Status") = "NationalCode is not valid"
                'dt.Rows.Add(row)
                'End If
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub

    Private Sub GetNationalCodeByCardNobtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetNationalCodeByCardNobtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "NationalCode"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)
        dt.Clear()

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try

                ProgressBar1.PerformStep()
                If ListDGrid.Item(0, counter).Value.ToString.Length = 16 Then

                    Dim NationalCode As String = ""
                    Dim CardNo As String = ""
                    CardNo = ListDGrid.Item(0, counter).Value
                    Authentication()
                    tmpCardManagment.Get_NationalCode_ByCardNo(CardNo, NationalCode)
                    '  If NationalCode.Length = 10 Then
                    row = dt.NewRow()
                    row("NationalCode") = NationalCode
                    row("CardNo") = CardNo

                    row("Status") = "Success"
                    dt.Rows.Add(row)
                    'Else
                    '    row = dt.NewRow()
                    '    row("NationalCode") = NationalCode
                    '    row("CardNo") = CardNo

                    '    row("Status") = "Not Found"
                    '    dt.Rows.Add(row)
                    'End If
                Else
                row = dt.NewRow()
                row("CardNo") = ListDGrid.Item(0, counter).Value
                row("NationalCode") = ""
                row("Status") = "CardNo is not valid"
                dt.Rows.Add(row)
                End If
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub

    Private Sub GetCardNoByAccNobtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetCardNoByAccNobtn.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "AccNo"
        dt.Columns.Add(column)
        dt.Clear()

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try

                ProgressBar1.PerformStep()

                Dim AccNo As String = ""
                Dim CardNo As String = ""
                AccNo = ListDGrid.Item(0, counter).Value
                Authentication()
                res = tmpCardManagment.GetCardNoByAccNo(AccNo, CardNo)
                If res = 1 Then
                    row = dt.NewRow()
                    row("AccNo") = AccNo
                    row("CardNo") = CardNo
                    row("Status") = "Success"
                    dt.Rows.Add(row)
                Else
                    row = dt.NewRow()
                    row("AccNo") = AccNo
                    row("CardNo") = CardNo
                    row("Status") = "Not Found"
                    dt.Rows.Add(row)
                End If
              
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub

    Function Authentication()
        Dim auth As New CardService.Authentication
        auth.User = "dml"
        auth.Password = "dmlco"
        tmpCardManagment.AuthenticationValue = auth
    End Function
    Function BuildTables(ByVal columns As Dictionary)
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow
        ' For i As Integer = 0 To columns.Len
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)
        ' Next

        Return dt
    End Function

    Private Sub BtnChangeNationalCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeNationalCode.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "OldNationalCode"
        dt.Columns.Add(column)
        dt.Clear()
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "NewNationalCode"
        dt.Columns.Add(column)
        dt.Clear()

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try

                ProgressBar1.PerformStep()
                ' If ListDGrid.Item(0, counter).Value.ToString.Length = 10 Then


                Dim NationalCode As String = ""
                Dim NewAccNo As String = ""
                Dim OldAccNo As String = ""
                OldAccNo = ListDGrid.Item(1, counter).Value
                NationalCode = ListDGrid.Item(0, counter).Value
                NewAccNo = ListDGrid.Item(2, counter).Value
                Authentication()
                res = tmpCardManagment.UpdateCustomerNationalCodeByCardNo(NationalCode, OldAccNo, NewAccNo)
                If res = 1 Then
                    row = dt.NewRow()
                    row("CardNo") = NationalCode
                    row("OldNationalCode") = OldAccNo
                    row("NewNationalCode") = NewAccNo
                    row("Status") = "Success"
                    dt.Rows.Add(row)
                Else
                    row = dt.NewRow()
                    row("CardNo") = NationalCode
                    row("OldNationalCode") = OldAccNo
                    row("NewNationalCode") = NewAccNo
                    row("Status") = "Not Found"
                    dt.Rows.Add(row)
                End If
                'Else
                'row = dt.NewRow()
                'row("CardNo") = ListDGrid.Item(0, counter).Value
                'row("OldNationalCode") = ListDGrid.Item(1, counter).Value
                'row("NewNationalCode") = ListDGrid.Item(2, counter).Value
                'row("Status") = "CardNo is not valid"
                'dt.Rows.Add(row)
                'End If
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub

    Private Sub BtnGetAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAcc.Click
        If ListDGrid.RowCount = 0 Then
            MsgBox("Please Select File", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim dt As DataTable = New DataTable()
        Dim column As DataColumn
        Dim row As DataRow

        Dim res As Integer = 0
        Dim OldAccount As String = ""
        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "CardNo"
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Account"
        dt.Columns.Add(column)
        dt.Clear()
       
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Status"
        dt.Columns.Add(column)
        dt.Clear()


        Dim RecordCounter As Integer = ListDGrid.DataSource.rows.count - 1
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = RecordCounter
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        For counter As Integer = 1 To RecordCounter
            Try
                ProgressBar1.PerformStep()
                If ListDGrid.Item(0, counter).Value.ToString.Length = 16 Then
                    Dim CardNo As String = ""
                    Dim Account As String = ""
                    CardNo = ListDGrid.Item(0, counter).Value
                    Authentication()
                    res = tmpCardManagment.GetAccNo_Map(Account, CardNo)
                    If res = 1 Then
                        row = dt.NewRow()
                        row("CardNo") = CardNo
                        row("Account") = Account
                        row("Status") = "Success"
                        dt.Rows.Add(row)
                    Else
                        row = dt.NewRow()
                        row("CardNo") = CardNo
                        row("Account") = Account
                        row("Status") = "Not Found"
                        dt.Rows.Add(row)
                    End If
                Else
                    row = dt.NewRow()
                    row("CardNo") = ListDGrid.Item(0, counter).Value
                    row("Account") = ListDGrid.Item(1, counter).Value
                    row("Status") = "CardNo is not valid"
                    dt.Rows.Add(row)
                End If
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
        ResultGrid.DataSource = dt
    End Sub
End Class