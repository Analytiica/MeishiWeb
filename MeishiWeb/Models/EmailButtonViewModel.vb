
Namespace MeishiWeb.Models
    Public Class EmailButtonViewModel
        Public Sub New(ByVal strText As String, ByVal strUrl As String)
            Text = strText
            Url = strUrl
        End Sub

        Public Property Text As String
        Public Property Url As String
    End Class

End Namespace
