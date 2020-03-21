Imports Ardalis.GuardClauses
Imports MeishiWeb.SiteMetaModel

Public Class SiteMetaModel
    Public Const OGImage As String = "og:image"
    Public Const OGSiteName As String = "og:site_name"

    Public ReadOnly Metas As Dictionary(Of String, String)

    Public ReadOnly Property Title As String = ""



    Public Sub New(ByVal _title As String, ByVal Optional metas As Dictionary(Of String, String) = Nothing)

        Guard.Against.NullOrWhiteSpace(_title, NameOf(_title))
        Title = _title

        Me.Metas = If(metas Is Nothing, New Dictionary(Of String, String), metas)



    End Sub

    Public Sub SetOGImage(ByVal value As String)
        Guard.Against.NullOrWhiteSpace(value, NameOf(value))
        Metas(OGImage) = value
    End Sub

    Public Sub AddMeta(ByVal key As String, ByVal value As String)
        Guard.Against.NullOrWhiteSpace(key, NameOf(key))
        Guard.Against.NullOrWhiteSpace(value, NameOf(value))
        Metas(key) = value
    End Sub

    Public Interface ISiteMetaService
        Function [Get]() As SiteMetaModel
        Sub [Set](ByVal siteMeta As SiteMetaModel)
    End Interface



End Class
Public Class SiteMetaService
    Implements ISiteMetaService

    Private currentSiteMeta As SiteMetaModel

    Public Function [Get]() As SiteMetaModel Implements ISiteMetaService.Get
        Return If(currentSiteMeta, New SiteMetaModel("Default"))
    End Function

    Public Sub [Set](ByVal siteMeta As SiteMetaModel) Implements ISiteMetaService.Set
        Guard.Against.Null(siteMeta, NameOf(siteMeta))
        currentSiteMeta = siteMeta
    End Sub
End Class

Public Class SiteMetaActionFilterAttribute
    Inherits ActionFilterAttribute

    Public Property SiteMetaService As ISiteMetaService

    Public Overrides Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext)
        filterContext.Controller.ViewBag.SiteMeta = SiteMetaService.[Get]()
        MyBase.OnActionExecuted(filterContext)
    End Sub
End Class
