Imports System.ComponentModel.DataAnnotations

Public Class QRCodeModel
    <Display(Name:="QRCode Text")>
    Public Property QRCodeText As String
    <Display(Name:="QRCode Image")>
    Public Property QRCodeImagePath As String
End Class