Imports System.Web.Mvc
Imports MeishiWeb.MeishiWeb
Imports MeishiWeb.MeishiWeb.Models


Namespace Controllers
    Public Class SaveController
        Inherits Controller


        Dim db As CardDBEntities = New CardDBEntities

        ' GET: Save
        Function Index() As ActionResult
            Return View()
        End Function
        <HttpPost>
        Function SaveLeft(ByVal EditData As CardInfoView) As ActionResult

            Dim objEditData = New CardInfo

            Dim objIntro = db.CardInfoes.Where(Function(i) i.DetailID = EditData.CardInfoViews.DetailID).First()
            Dim objTitle = db.CardInfoes.Where(Function(t) t.DetailID = EditData.CardInfoViews.DetailID).First()

            objIntro.Introduction = EditData.CardInfoViews.Introduction
            objTitle.JobTitle = EditData.CardInfoViews.JobTitle


            db.SaveChanges()

            'Return Redirect(Request.UrlReferrer.ToString)
            'Return View()
            Return Content("<script>location.reload()</script>")


        End Function
    End Class
End Namespace