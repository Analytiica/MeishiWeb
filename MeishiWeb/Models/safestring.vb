Imports System.Runtime.CompilerServices

Namespace MeishiWeb.CheckString
    Public Module safestring

        <Extension>
        Public Function SafeGetString(ByVal value As String) As String
            If Not value Is DBNull.Value Then Return value
            Return String.Empty
        End Function

        Public Function SafeGetArray(ByVal value() As Object) As String()
            Dim i As Integer = 0
            Dim newString(i) As String
            For Each values In value
                If Not values Is DBNull.Value Then
                    newString(i) = values
                    i += 1
                    ReDim Preserve newString(i)

                End If
            Next
            ReDim Preserve newString(i - 1)
            Return newString
        End Function

        Public Function SafeGetInteger(ByVal value() As Integer) As Integer()
            Dim newInteger(value.Count) As Integer

            newInteger = value
            Return newInteger
        End Function


    End Module

End Namespace