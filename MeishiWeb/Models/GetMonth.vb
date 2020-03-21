Namespace MeishiWeb.MonthData

    Public Class GetMonth

        Public Function ReturnMonth(ByVal month As String) As String()

            Dim sDate() As String = Split(month, "/")

            Dim days As Integer = DateTime.DaysInMonth(sDate(0), sDate(1))

            Dim MonthData(days) As String

            For i As Integer = 1 To days

                Dim dt As New DateTime(sDate(0), sDate(1))

                MonthData(i) = dt.ToString


            Next

            Return MonthData
        End Function




    End Class

End Namespace
