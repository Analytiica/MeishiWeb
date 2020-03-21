Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Mvc
Imports Ardalis.GuardClauses
Imports MeishiWeb.MeishiWeb
Imports MeishiWeb.MeishiWeb.Models
Imports Microsoft.AspNetCore.Http

Namespace Controllers
    Public Class cardController
        Inherits Controller


        ' GET: card
        Dim db As CardDBEntities = New CardDBEntities

        Function Chart() As ActionResult


            Return View()
        End Function


        ' GET: card
        <Route("card/{company}/{id}")>
        Function Index(ByVal company As String, ByVal id As String) As ActionResult

            If company IsNot Nothing Then


                Dim dvModel = New CardInfoView

                dvModel.CardInfoViews = db.CardInfoes.Find(id, company)
                dvModel.LinkInfoViews = db.CardLinks.Find(company, id)

                If IsNothing(dvModel.CardInfoViews) Then

                    Return HttpNotFound()

                End If
                Return View(dvModel)




            End If

            Return View("{controller}/{id}")

        End Function
        <Authorize>
        <Route("card/Edit/{company}/{id}")>
        Function Edit(ByVal company As String, ByVal id As String) As ActionResult

            If company IsNot Nothing Then

                Dim dvModel = New CardInfoView

                dvModel.CardInfoViews = db.CardInfoes.Find(id, company)
                dvModel.LinkInfoViews = db.CardLinks.Find(company, id)

                If IsNothing(dvModel) Then
                    Return HttpNotFound()
                End If
                Return View(dvModel)
                'Return View("_index")



            End If

            Return View("{controller}/{id}")

        End Function
        <Authorize(Roles:="Administrator")>
        <Route("card/Delete/{company}/{id}")>
        Function Delete(ByVal company As String, ByVal id As String) As ActionResult

            If company IsNot Nothing Then
                Dim dvModel = New CardInfoView

                dvModel.CardInfoViews = db.CardInfoes.Find(id, company)
                dvModel.LinkInfoViews = db.CardLinks.Find(company, id)

                If IsNothing(dvModel) Then
                    Return HttpNotFound()
                End If

                If IO.Directory.Exists(Server.MapPath(dvModel.CardInfoViews.ProfilePic)) Then

                    IO.Directory.Delete(Server.MapPath(dvModel.CardInfoViews.ProfilePic), True)

                    If Not IO.Directory.EnumerateFileSystemEntries(Server.MapPath("/Views/card/uploads/" & company)).Any = True Then

                        IO.Directory.Delete(Server.MapPath("/Views/card/uploads/" & company), True)

                    End If


                    db.CardInfoes.Attach(dvModel.CardInfoViews)
                    db.CardLinks.Attach(dvModel.LinkInfoViews)
                    db.CardInfoes.Remove(dvModel.CardInfoViews)
                    db.CardLinks.Remove(dvModel.LinkInfoViews)
                    db.SaveChanges()

                End If

                Return RedirectToAction("Index", "Agent")

            End If

        End Function

        <HttpPost>
        Function sendMail(ByVal tomail As String, ByVal company As String, ByVal name As String, ByVal phone As String, ByVal email As String, ByVal firstname As String, ByVal lastname As String, ByVal message As String) As ActionResult
            Try
                Dim body As String = "<p><strong>From:</strong> " & email & " <br></br><strong>To:</strong> " & tomail & "<br></br><br></br>" & "Dear " & firstname & "<br></br><br></br>" & name & " has sent a contact request via your Meishi Digital Business card.<br></br><br></br><strong>Message:</strong><br></br><br></br>" & message & "<br></br><h2>Contact details for request</h2><br></br>Email Address:" & tomail & "<br></br>Phone Number:" & phone & "<br></br><br></br><br></br><br></br>Kind Regards,<br></br>Your Meishi Form</p>"
                Dim message_mail = New MailMessage
                message_mail.To.Add(New MailAddress(tomail, firstname))
                message_mail.From = New MailAddress("contact@meishi.me", "Meishi")
                message_mail.Subject = "Client contact from your Meishi"
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


        End Function

        <HttpPost>
        Function Analytics(ByVal names As String, ByVal email As String, ByVal area As String) As ActionResult

            Dim anaDB As New CardDBEntities
            Dim ana As New analytiic
            Dim aData As analytiic = anaDB.analytiics.Find(Today.ToShortDateString, email, names)

            If aData IsNot Nothing Then

                aData.count += 1


            Else
                ana.name = names
                ana.email = email
                ana.area = area
                ana.count = 1
                ana.DateCreated = Today.ToShortDateString
                anaDB.analytiics.Add(ana)

            End If

            anaDB.SaveChanges()

        End Function
        Public Function GetCard(ByVal dvModel As CardInfoView) As String

            Dim builder = New StringBuilder()
            builder.AppendLine("BEGIN:VCARD")
            builder.AppendLine("VERSION:3.0")
            builder.AppendLine("REV:2020-01-21T10:20:05Zc")
            builder.AppendLine("N;CHARSET=utf-8:" & dvModel.CardInfoViews.LastName & ";" & dvModel.CardInfoViews.FirstName & ";;;")
            builder.AppendLine("FN;CHARSET=utf-8:" & dvModel.CardInfoViews.FirstName & " " & dvModel.CardInfoViews.LastName)
            builder.AppendLine("ORG;CHARSET=utf-8:" & dvModel.CardInfoViews.CompanyName)
            builder.AppendLine("TITLE;CHARSET=utf-8:" & dvModel.CardInfoViews.JobTitle)
            builder.AppendLine("ROLE;CHARSET=utf-8:" & dvModel.CardInfoViews.JobTitle)
            builder.AppendLine("EMAIL;Email:" & dvModel.CardInfoViews.email)
            builder.AppendLine("TEL;WORK:" & dvModel.CardInfoViews.LandLineNumber)
            builder.AppendLine("TEL;TYPE=cell:" & dvModel.CardInfoViews.MobileNumber)
            builder.AppendLine("ADR;WORK;POSTAL;CHARSET=utf-8:" & dvModel.CardInfoViews.StreetName & ";" & dvModel.CardInfoViews.AddressLine & ";" & dvModel.CardInfoViews.Province & ";" & dvModel.CardInfoViews.PostalCode & ";" & dvModel.CardInfoViews.Country & ";;")
            builder.AppendLine("LABEL:" & dvModel.CardInfoViews.StreetName & ";" & dvModel.CardInfoViews.AddressLine & ";" & dvModel.CardInfoViews.Province & ";" & dvModel.CardInfoViews.PostalCode & ";" & dvModel.CardInfoViews.Country & ";;")
            builder.AppendLine("URL:" & dvModel.CardInfoViews.WebSite)
            builder.AppendLine("URL;Homepage:https://meishi.me/card/" & dvModel.CardInfoViews.CompanyID & "/" & dvModel.CardInfoViews.DetailID)

            If IO.File.Exists(Server.MapPath(dvModel.CardInfoViews.ProfilePic & "/profilepictures/" & dvModel.CardInfoViews.DetailID & ".png")) = True Then
                builder.AppendLine("PHOTO;ENCODING=b;TYPE=JPEG:" & Convert.ToBase64String(IO.File.ReadAllBytes(Server.MapPath(dvModel.CardInfoViews.ProfilePic & "/profilepictures/" & dvModel.CardInfoViews.DetailID & ".png"))))
            End If

            builder.AppendLine("END:VCARD")
            Return builder.ToString
        End Function

        'Public Function GetCard(ByVal dvModel As CardInfoView) As String

        '    Dim builder = New StringBuilder()
        '    builder.AppendLine("BEGIN:VCARD")
        '    builder.AppendLine("VERSION:4.0")
        '    builder.AppendLine("N:" & dvModel.CardInfoViews.LastName & ";" & dvModel.CardInfoViews.FirstName & ";;;")
        '    builder.AppendLine("FN:" & dvModel.CardInfoViews.FirstName & " " & dvModel.CardInfoViews.LastName)
        '    builder.AppendLine("ORG:" & dvModel.CardInfoViews.CompanyName & ";;")
        '    builder.AppendLine("TITLE:" & dvModel.CardInfoViews.JobTitle)
        '    builder.AppendLine("ROLE:" & dvModel.CardInfoViews.JobTitle)
        '    builder.AppendLine("EMAIL:" & dvModel.CardInfoViews.email)
        '    builder.AppendLine("TEL;TYPE=cell:" & dvModel.CardInfoViews.MobileNumber)
        '    builder.AppendLine("ADR;TYPE=work:" & dvModel.CardInfoViews.AddressLine & ";" & dvModel.CardInfoViews.Province & ";" & dvModel.CardInfoViews.PostalCode & ";" & dvModel.CardInfoViews.Country & ";;;")
        '    builder.AppendLine("URL:" & dvModel.CardInfoViews.WebSite)


        '    If IO.File.Exists(Server.MapPath(dvModel.CardInfoViews.ProfilePic & "/profilepictures/" & dvModel.CardInfoViews.DetailID & ".png")) = True Then
        '        builder.AppendLine("PHOTO;MEDIATYPE=image/jpeg:https://meishi.me" & dvModel.CardInfoViews.ProfilePic & "/profilepictures/" & dvModel.CardInfoViews.DetailID & ".png")
        '    End If

        '    builder.AppendLine("END:VCARD")
        '    Return builder.ToString
        'End Function



        <Route("card/contact/{company}/{id}")>
        Public Sub contact(ByVal id As String, ByVal company As String)
            Dim dvModel As CardInfoView = New CardInfoView
            dvModel.CardInfoViews = db.CardInfoes.Find(id, company)

            Dim response = ControllerContext.HttpContext.Response
            response.ContentType = "text/vcard"
            response.AddHeader("Content-Disposition", "attachment; fileName=" & dvModel.CardInfoViews.FirstName & " " + dvModel.CardInfoViews.LastName & ".vcf")
            Dim cardString = GetCard(dvModel).ToString()
            Dim inputEncoding = Encoding.[Default]
            Dim outputEncoding = Encoding.GetEncoding("windows-1257")
            Dim cardBytes = inputEncoding.GetBytes(cardString)
            Dim outputBytes = Encoding.Convert(inputEncoding, outputEncoding, cardBytes)
            response.OutputStream.Write(outputBytes, 0, outputBytes.Length)
        End Sub



    End Class







End Namespace