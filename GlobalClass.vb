Public Class GlobalClass
#Region "Farsi date class"
    Public Class FarsiDate
        Private Gdays() As String = {"31", "28", "31", "30", "31", "30", "31", "31", "30", "31", "30", "31"}
        Private Jdays() As String = {"31", "31", "31", "31", "31", "31", "30", "30", "30", "30", "30", "30"}
        Private JMonth() As String = {"", "Farvardin", "Ordibehesht", "Khordad", "Tir", "Mordad", "Shahrivar", "Mehr", "Aban", "Azar", "Day", "Bahman", "Esfand"}
        '
        Public Function G_To_J(ByVal g_y As String, ByVal g_m As String, ByVal g_d As String)
            Dim gy As Integer
            Dim gm As Integer
            Dim gd As Integer

            gy = CInt(g_y) - 1600
            gm = CInt(g_m) - 1
            gd = CInt(g_d) - 1

            Dim gd_no As Integer
            Dim gd_no1 As Integer
            gd_no1 = 0

            gd_no1 = Int(365 * gy)
            gd_no1 += Int((gy + 3) / 4)
            gd_no1 -= Int((gy + 99) / 100)
            gd_no1 += Int((gy + 399) / 400)

            gd_no = Int(gd_no1)

            For j As Integer = 0 To (gm - 1)
                gd_no += Gdays(j)
            Next

            If (gm > 1 And (((gy Mod 4) = 0 And (gy Mod 100) <> 0) Or ((gy Mod 400) = 0))) Then
                gd_no += 1
            End If

            gd_no += gd
            Dim jd_no As Integer
            Dim jd_np As Integer
            jd_no = gd_no - 79
            jd_np = Int(jd_no / 12053)
            jd_no = jd_no Mod 12053

            Dim jy As Integer
            Dim jm As Integer
            Dim jd As Integer

            jy = 979 + 33 * jd_np + 4 * Int((jd_no) / 1461)
            jd_no = (jd_no Mod 1461)
            If (jd_no >= 366) Then
                jy += Int((jd_no - 1) / 365)
                jd_no = (jd_no - 1) Mod 365
            End If

            Dim I As Integer
            I = 0
            While (I < 11 And jd_no >= Jdays(I))
                jd_no -= Jdays(I)
                I += 1
            End While

            jm = I + 1
            jd = jd_no + 1

            Dim str() As String = {jy, jm, jd}
            Return str
        End Function
        '
        Public Function GetDate() As String
            Dim year As String
            Dim month As String
            Dim day As String
            Dim str(3) As String
            Dim d(3) As String

            year = Date.Today.Year
            month = Date.Today.Month
            day = Date.Today.Day
            str = G_To_J(year, month, day)
            year = str(0)
            month = str(1)
            day = str(2)

            'd = farsinum(CInt(year) - 1300) + "/" + farsinum(month) + "/" + farsinum(day)
            d(0) = farsinum(CInt(year) - 1300)
            d(1) = farsinum(month)
            d(2) = farsinum(day)

            Return "13" + d(0) + "/" + d(1) + "/" + d(2)
        End Function
        '
        Public Function farsinum(ByVal c As String)
            If (c.Length = 1) Then
                c = "0" + c
            End If
            Return c
        End Function
        '
        Public Function lastDate(ByVal dateValue As String) As String
            lastDate = ""
            Dim year As Integer = Int(dateValue.Substring(0, 4))
            Dim month As Integer = Int(dateValue.Substring(5, 2))
            Dim day As Integer = Int(dateValue.Substring(8, 2))
            day -= 1
            If day = 0 Then
                If month > 6 Then
                    day = 30
                ElseIf month = 1 Then
                    day = 29
                Else
                    day = 31
                End If
                month -= 1
                If month = 0 Then
                    month = 12
                    year -= 1
                End If
            End If
            Return year.ToString.PadLeft(4, "0") + "/" + month.ToString.PadLeft(2, "0") + "/" + day.ToString.PadLeft(2, "0")
        End Function
    End Class

#End Region
End Class
