Imports MeishiWeb.MeishiWeb.Models
Imports System.Data.Entity.Migrations
Imports System.Runtime.CompilerServices
Imports System.Web.Mvc.Html
Imports System.Web.Mvc
Imports System.Net
Imports System.Linq.Expressions

Namespace MeishiWeb.Extentions



    Public Module MyHelpers



        <Extension()>
        Public Function NoEncodeActionLink(ByVal htmlHelper As HtmlHelper, ByVal text As String, ByVal title As String, ByVal action As String, ByVal controller As String, ByVal Optional routeValues As Object = Nothing, ByVal Optional htmlAttributes As Object = Nothing) As MvcHtmlString
            Dim urlHelper As UrlHelper = New UrlHelper(htmlHelper.ViewContext.RequestContext)
            Dim builder As TagBuilder = New TagBuilder("a")
            builder.InnerHtml = text
            builder.Attributes("title") = title
            builder.Attributes("href") = urlHelper.Action(action, controller, routeValues)
            builder.MergeAttributes(New RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)))
            Return MvcHtmlString.Create(builder.ToString())
        End Function




        <Extension()>
        Public Function BuildLinks(ByVal htmlHemlper As HtmlHelper, ByVal company As String, ByVal path As String) As String

            Dim db As CardDBEntities = New CardDBEntities

            Dim Linkdata = New CardInfoView

            Linkdata.LinkInfoViews = db.CardLinks.Find(company)

            Dim LinkName As List(Of String) = New List(Of String)

            Dim LinkTitle As List(Of String) = New List(Of String)

            'LinkView = db.CardLinks.Where(Function(m) m.CompanyID = company).ToList

            If Linkdata IsNot Nothing Then


                LinkName.Add(Linkdata.LinkInfoViews.LinkName1)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName2)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName3)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName4)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName5)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName6)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName7)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName8)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName9)
                LinkName.Add(Linkdata.LinkInfoViews.LinkName10)

                LinkTitle.Add(Linkdata.LinkInfoViews.Title1)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title2)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title3)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title4)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title5)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title6)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title7)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title8)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title9)
                LinkTitle.Add(Linkdata.LinkInfoViews.Title10)

            Else

                Exit Function


            End If

            Dim htmlBuilder As New Text.StringBuilder
            For i As Integer = 0 To 1 - 1


                'Return JavaScript("window.alert('Hello';)")

                'ViewBag.calljavascriptfunction = "create(" + i + ");"

                'Dim outerDiv = New TagBuilder("div")
                'outerDiv.AddCssClass("col-lg-4 col-xs-6")
                'Dim outerFigure = New TagBuilder("figure")
                'outerFigure.AddCssClass("effect-apollo")
                'Dim outerImg = New TagBuilder("img")
                'outerImg.MergeAttribute("src", "@String.Format({0}/templatepictures/{1}.png," & path & ", " & LinkTitle(i) & ")")
                'Dim outerH As New TagBuilder("h4")
                'outerH.SetInnerText(LinkTitle(i))
                'Dim outerP As New TagBuilder("p")
                'Dim outerFigCaption As New TagBuilder("figcaption")
                'Dim outerA As New TagBuilder("a")
                'outerA.AddCssClass("fancybox")
                'outerA.MergeAttribute("href", LinkName(i))
                'outerA.MergeAttribute("data-fancybox-group", "gallery")

                'outerFigure.ToString(TagRenderMode.EndTag)
                'outerDiv.InnerHtml += outerFigure.ToString

                'outerImg.ToString(TagRenderMode.EndTag)
                'outerDiv.InnerHtml += outerImg.ToString

                'outerH.ToString(TagRenderMode.EndTag)
                'outerDiv.InnerHtml += outerH.ToString

                'outerP.ToString(TagRenderMode.EndTag)
                'outerDiv.InnerHtml += outerP.ToString

                'outerFigCaption.ToString(TagRenderMode.EndTag)
                'outerDiv.InnerHtml += outerFigCaption.ToString

                'outerA.ToString(TagRenderMode.EndTag)
                'outerDiv.InnerHtml += outerA.ToString













                'outerDiv.InnerHtml
                'htmlBuilder.Append(outerDiv.ToString & vbCrLf)
                'htmlBuilder.Append(outerA.ToString & vbCrLf)
                'htmlBuilder.Append(outerFigCaption.ToString & vbCrLf)
                'htmlBuilder.Append(outerH.ToString & vbCrLf)
                'htmlBuilder.Append(outerP.ToString & vbCrLf)
                'htmlBuilder.Append(outerImg.ToString & vbCrLf)
                'htmlBuilder.Append(outerFigure.ToString & vbCrLf)

                'htmlBuilder.Append("<div Class=""""col-lg-4 col-xs-6"""">" & vbCrLf)
                'htmlBuilder.Append("<figure Class=""""effect-apollo"""">" & vbCrLf)
                'htmlBuilder.Append("<img src = """"@String.Format(""{0}/templatepictures/{1}.png,""" & path & "," & LinkTitle(i) & " />" & vbCrLf)
                'htmlBuilder.Append("<h4>" & LinkTitle(i) & "</h4>" & vbCrLf)
                'htmlBuilder.Append("<p></p>" & vbCrLf)
                'htmlBuilder.Append("<figcaption> <a Class=""""fancybox"""" href=" & LinkName(i) & " data-fancybox-group=""""gallery""""></a></figcaption>" & vbCrLf)
                'htmlBuilder.Append("</figure>" & vbCrLf)
                'htmlBuilder.Append("</div>" & vbCrLf)


                'Return outerDiv.ToString




            Next





        End Function


        ' <div Class="col-lg-4 col-xs-6">
        '    <figure Class="effect-apollo">
        '        <img src = "@String.Format("{0}/templatepictures/{1}.png", Model.CardInfoViews.ProfilePic, Model.LinkInfoViews.Title1)" />
        '        <h4> Model.CardInfoView.Title1</h4>
        '        <p></p>
        '        <figcaption> <a Class="fancybox" href="@Model.LinkInfoViews.LinkName1" data-fancybox-group="gallery"></a></figcaption>
        '    </figure>
        '</div>



    End Module

End Namespace
