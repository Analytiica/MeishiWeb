Imports System.Web.Mvc
Imports MeishiWeb.MeishiWeb
Imports MeishiWeb.MeishiWeb.Models
Imports MeishiWeb.MeishiWeb.CheckString.safestring
Imports System.Data.Entity
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Globalization

Namespace Controllers
    Public Class chartController
        Inherits Controller

        ' GET: chart
        <Route("chart/{company}/{id}")>
        Function Index(ByVal company As String, ByVal id As String) As ActionResult

            If id Is Nothing Then
                Return View()
            End If
            Dim mfi As DateTimeFormatInfo = New DateTimeFormatInfo()
            Dim strMonthName As String = mfi.GetMonthName(DateTime.Now.AddMonths(-1).Month).ToString()
            Dim MonthYear As String = Now.Year.ToString & "/" & DateTime.Now.AddMonths(-1).Month.ToString.PadLeft(2, "0")


            If SQLCMD.sqlConnect = True Then

                Dim SQL As String = "SELECT meishi.dbo.cardinfo.email, meishi.dbo.cardinfo.StreetName,meishi.dbo.cardinfo.AddressLine,meishi.dbo.cardinfo.Province,meishi.dbo.cardinfo.PostalCode,meishi.dbo.cardinfo.Country,meishi.dbo.cardinfo.DisplayName,meishi.dbo.cardinfo.JobTitle,meishi.dbo.cardinfo.ProfilePic,meishi.dbo.cardinfo.WebSite,meishi.dbo.cardinfo.Facebook,meishi.dbo.cardinfo.Instagram,meishi.dbo.cardinfo.Twitter,meishi.dbo.cardinfo.LinkedIn,meishi.dbo.cardinfo.YouTube,meishi.dbo.cardinfo.MobileNumber,meishi.dbo.cardinfo.CompanyName,meishi.dbo.cardlinks.Title1,meishi.dbo.cardlinks.Title2,meishi.dbo.cardlinks.Title3,meishi.dbo.cardlinks.Title4,meishi.dbo.cardlinks.Title5,meishi.dbo.cardlinks.Title6,meishi.dbo.cardlinks.Title7,meishi.dbo.cardlinks.Title8,meishi.dbo.cardlinks.Title9,meishi.dbo.cardlinks.Title10,meishi.dbo.cardlinks.Title11,meishi.dbo.cardlinks.Title12,meishi.dbo.cardlinks.Title13,meishi.dbo.cardlinks.Title14 FROM CardInfo, CardLinks WHERE cardinfo.DetailID='" & id & "' AND cardinfo.CompanyID='" & company & "' AND cardlinks.CardID='" & id & "' AND cardlinks.CompanyID='" & company & "'"
                Dim dt As DataTable = SQLCMD.SelectAll(SQL)

                If dt.Rows.Count > 0 Then
                    Dim dtAnalytic As DataTable = SQLCMD.SelectAll("SELECT * FROM Analytiics WHERE meishi.dbo.analytiics.email='" & dt.Rows(0).ItemArray(0) & "' AND DateCreated LIKE '" & MonthYear & "%' ORDER BY DateCreated")
                    Dim dtProfile As DataTable = SQLCMD.SelectAll("SELECT DateCreated, area, SUM([count]) FROM Analytiics WHERE meishi.dbo.analytiics.email='" & dt.Rows(0).ItemArray(0) & "' AND DateCreated LIKE '" & MonthYear & "%' GROUP BY DateCreated, area")


                    If dtAnalytic.Rows.Count > 0 Then

                        Dim Profiles() As String = {"Facebook", "Maps", "SendMail", "MapMarker", "ContactSave", "WhatsApp", "WebSite", "LinkedIn", "Twitter", "Instagram", "YouTube", "WhatsAppText"}
                        Dim Services() As Object = {dt.Rows(0).ItemArray(17), dt.Rows(0).ItemArray(18), dt.Rows(0).ItemArray(19), dt.Rows(0).ItemArray(20), dt.Rows(0).ItemArray(21), dt.Rows(0).ItemArray(22), dt.Rows(0).ItemArray(23), dt.Rows(0).ItemArray(24), dt.Rows(0).ItemArray(25), dt.Rows(0).ItemArray(26), dt.Rows(0).ItemArray(27), dt.Rows(0).ItemArray(28), dt.Rows(0).ItemArray(29), dt.Rows(0).ItemArray(30)}
                        Dim profileList(Profiles.Length) As Integer
                        Dim serviceList(Services.Length) As Integer


                        For Each row As DataRow In dtAnalytic.Rows

                            Select Case row.ItemArray(3)
                                Case = "Profile"

                                    For p As Integer = 0 To Profiles.Length - 1

                                        If Profiles(p) IsNot DBNull.Value Then

                                            If LCase(Profiles(p)) = LCase(row.ItemArray(4)) Then

                                                profileList(p) += row.ItemArray(5)

                                            End If
                                        End If

                                    Next



                                Case = "Services"

                                    For s As Integer = 0 To Services.Length - 1

                                        If Services(s) IsNot DBNull.Value Then

                                            If LCase(Services(s)) = LCase(row.ItemArray(4)) Then

                                                serviceList(s) += row.ItemArray(5)

                                            End If
                                        End If

                                    Next

                            End Select




                        Next


                        Dim strBuilder As New List(Of String)

                        For Each row As DataRow In dtProfile.Rows

                            Select Case row.ItemArray(1)
                                Case = "Services"
                                    For Each srow As DataRow In dtProfile.Select("area='Profile'")

                                        If srow.ItemArray(0) = row.ItemArray(0) Then

                                            strBuilder.Add(String.Format("{0},{1},{2}", srow.ItemArray(0), srow.ItemArray(2), row.ItemArray(2)))
                                            srow.Delete()


                                        End If


                                    Next

                            End Select

                        Next

                        dtProfile.AcceptChanges()
                        For Each value As String In strBuilder



                            For Each orow As DataRow In dtProfile.Select("area='Services'")

                                If value.Contains(orow.ItemArray(0)) Then

                                    orow.Delete()

                                End If

                            Next

                        Next

                        dtProfile.AcceptChanges()

                        For Each row In dtProfile.Select("area='Services'")

                            strBuilder.Add(String.Format("{0},{1},{2}", row.ItemArray(0), 0, row.ItemArray(2)))

                        Next

                        For Each row In dtProfile.Select("area='Profile'")

                            strBuilder.Add(String.Format("{0},{1},{2}", row.ItemArray(0), row.ItemArray(2), 0))

                        Next


                        strBuilder.Sort()

                        Dim rdate(strBuilder.Count - 1) As String
                        Dim rPrf(strBuilder.Count - 1) As Integer
                        Dim rSrv(strBuilder.Count - 1) As Integer

                        For sr As Integer = 0 To strBuilder.Count - 1

                            Dim sp() As String = Split(strBuilder(sr), ",")
                            rdate(sr) = sp(0)
                            rPrf(sr) = sp(1)
                            rSrv(sr) = sp(2)

                        Next






                        Dim model As ChartView = New ChartView
                        model.DetailID = id
                        model.email = SafeGetString(dt.Rows(0).ItemArray(0).ToString)
                        model.StreetName = SafeGetString(dt.Rows(0).ItemArray(1).ToString)
                        model.AddressLine = SafeGetString(dt.Rows(0).ItemArray(2).ToString)
                        model.Province = SafeGetString(dt.Rows(0).ItemArray(3).ToString)
                        model.PostalCode = SafeGetString(dt.Rows(0).ItemArray(4).ToString)
                        model.Country = SafeGetString(dt.Rows(0).ItemArray(5).ToString)
                        model.DisplayName = SafeGetString(dt.Rows(0).ItemArray(6).ToString)
                        model.JobTitle = SafeGetString(dt.Rows(0).ItemArray(7).ToString)
                        model.ProfilePic = SafeGetString(dt.Rows(0).ItemArray(8).ToString)
                        model.WebSite = SafeGetString(dt.Rows(0).ItemArray(9).ToString)
                        model.Facebook = SafeGetString(dt.Rows(0).ItemArray(10).ToString)
                        model.Instagram = SafeGetString(dt.Rows(0).ItemArray(11).ToString)
                        model.Twitter = SafeGetString(dt.Rows(0).ItemArray(12).ToString)
                        model.LinkedIn = SafeGetString(dt.Rows(0).ItemArray(13).ToString)
                        model.YouTube = SafeGetString(dt.Rows(0).ItemArray(14).ToString)
                        model.MobileNumber = SafeGetString(dt.Rows(0).ItemArray(15).ToString)
                        model.CompanyName = SafeGetString(dt.Rows(0).ItemArray(16).ToString)
                        model.Title1 = SafeGetString(dt.Rows(0).ItemArray(17).ToString)
                        model.Title2 = SafeGetString(dt.Rows(0).ItemArray(18).ToString)
                        model.Title3 = SafeGetString(dt.Rows(0).ItemArray(19).ToString)
                        model.Title4 = SafeGetString(dt.Rows(0).ItemArray(20).ToString)
                        model.Title5 = SafeGetString(dt.Rows(0).ItemArray(21).ToString)
                        model.Title6 = SafeGetString(dt.Rows(0).ItemArray(22).ToString)
                        model.Title7 = SafeGetString(dt.Rows(0).ItemArray(23).ToString)
                        model.Title8 = SafeGetString(dt.Rows(0).ItemArray(24).ToString)
                        model.Title9 = SafeGetString(dt.Rows(0).ItemArray(25).ToString)
                        model.Title10 = SafeGetString(dt.Rows(0).ItemArray(26).ToString)
                        model.Title11 = SafeGetString(dt.Rows(0).ItemArray(27).ToString)
                        model.Title12 = SafeGetString(dt.Rows(0).ItemArray(28).ToString)
                        model.Title13 = SafeGetString(dt.Rows(0).ItemArray(29).ToString)
                        model.Title14 = SafeGetString(dt.Rows(0).ItemArray(30).ToString)
                        model.AllProfiles = SafeGetArray(Profiles)
                        model.AllServices = SafeGetArray(Services)
                        model.ProfileCount = SafeGetInteger(profileList)
                        model.ServiceCount = SafeGetInteger(serviceList)
                        model.rDate = rdate
                        model.rPrf = rPrf
                        model.rSrv = rSrv
                        model.CurrentMonth = strMonthName
                        SQLCMD.CloseSQLConnection()
                        Return View("Index", model)
                    End If

                End If

            End If

            'Return View()


        End Function



        Function EmailButton() As ActionResult

            Return View()

        End Function



        Public Function RenderViewToString(ByVal context As ControllerContext, ByVal viewPath As String, ByVal Optional model As Object = Nothing, ByVal Optional [partial] As Boolean = False) As String
            Dim viewEngineResult As ViewEngineResult = Nothing

            If [partial] Then
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath)
            Else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, Nothing)
            End If

            If viewEngineResult Is Nothing Then Throw New FileNotFoundException("View cannot be found.")
            Dim view = viewEngineResult.View
            context.Controller.ViewData.Model = model
            Dim result As String = Nothing

            Using sw = New StringWriter()
                Dim ctx = New ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw)
                view.Render(ctx, sw)
                result = sw.ToString()
            End Using

            Return result
        End Function


        Public Shared Sub sendMail(ByVal tomail As String, ByVal firstname As String, ByVal message As String)
            Try
                Dim body As String = message
                Dim message_mail = New MailMessage
                message_mail.To.Add(New MailAddress(tomail, firstname))
                message_mail.From = New MailAddress("contact@meishi.me", "Meishi")
                message_mail.Subject = "Monthly Analytics from Meishi"
                message_mail.Body = body
                message_mail.IsBodyHtml = True

                Using smtp As New SmtpClient

                    Dim credential = New NetworkCredential With {
                            .UserName = "contact@meishi.me",
                            .Password = "Contact!2020"
                        }

                    smtp.Credentials = credential
                    smtp.Host = "smtp.meishi.me"
                    smtp.Port = 25
                    smtp.EnableSsl = False
                    smtp.Send(message_mail)





                End Using



            Catch ex As Exception

            End Try


        End Sub

        Public Function ViewChart(ByVal user As String, ByVal company As String, ByVal email As String)

            Dim emails As String = email.Replace("@", "%40")
            Dim model As New EmailButtonViewModel("View Analytics", "http://meishiweb.ddns.net/chart/" & "/" & company & "/" & user)


            Dim HtmlMessage As String = RenderViewToString(ControllerContext, "/Views/chart/ViewChart.vbhtml", model, True)

            If HtmlMessage <> "" Then

                sendMail("shaheed@analytiica.com", user, HtmlMessage)
            End If

            'Return View()

        End Function

        Public Sub Deploy(ByVal email As String)


            If SQLCMD.sqlConnect = True Then


                Dim dtDeploy As DataTable = SQLCMD.SelectAll("SELECT email, DetailID, companyid FROM CardInfo WHERE email='" & email & "'")

                For Each row As DataRow In dtDeploy.Rows

                    ViewChart(row.ItemArray(1), row.ItemArray(2), row.ItemArray(0))

                Next

            End If



        End Sub
    End Class
End Namespace