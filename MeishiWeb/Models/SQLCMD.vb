Imports System.Data.SqlClient

Namespace MeishiWeb
    Public Class SQLCMD


        Public Shared slCommand As New SqlCommand
        Public Shared slConnection As SqlConnection

        Public Shared Function sqlConnect() As Boolean


            slConnection = New SqlConnection("Server=156.38.224.15;Database=Meishi;User Id=ymivdnll_dbadmin;Password=*Me1sh1*")
            'slConnection = New Npgsql.NpgsqlConnection("host=10.10.10.203;Username=rpdreports;Password=testpassword;Database=history;")

            Try


                slConnection.Open()


                Return True


            Catch ex As Exception

                Return False


            End Try


        End Function




        Public Shared Function SelectAll(ByVal SqlCommandString As String)

            Dim pgDatatable As New DataTable
            Dim pgSQLAdapter As New SqlDataAdapter

            slCommand.CommandText = SqlCommandString
            pgSQLAdapter.SelectCommand = slCommand
            slCommand.Connection = slConnection
            slCommand.ExecuteNonQuery()
            pgSQLAdapter.Fill(pgDatatable)

            Return pgDatatable

        End Function

        Public Shared Function GetColumns(ByVal table As String) As DataTable

            Dim pgDatatable As New DataTable
            Dim pgSQLAdapter As New SqlDataAdapter

            slCommand.CommandText = "SELECT column_name, is_nullable, data_type FROM information_schema.columns WHERE table_schema = 'public' AND table_name = '" & table & "'"
            pgSQLAdapter.SelectCommand = slCommand
            slCommand.Connection = slConnection
            slCommand.ExecuteNonQuery()
            pgSQLAdapter.Fill(pgDatatable)

            Return pgDatatable

        End Function




        Public Shared Sub CloseSQLConnection()

            If slConnection.State = ConnectionState.Open Then

                slConnection.Close()

            End If

        End Sub
    End Class
End Namespace

