Imports MeishiWeb.MeishiWeb

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        Dim myConext As New CardDBEntities
        myConext.Database.CreateIfNotExists()

        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
