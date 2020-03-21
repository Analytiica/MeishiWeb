Imports MeishiWeb.MeishiWeb
Imports MeishiWeb.MeishiWeb.Models
Imports System.ComponentModel.DataAnnotations
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Data.Entity
Imports ZXing
Imports ZXing.Common
Imports System.Text.RegularExpressions


Namespace Controllers
    Public Class AgentController
        Inherits Controller

        Dim db As CardDBEntities = New CardDBEntities

        <Authorize(Roles:="Agent,Administrator")>
        Function Index() As ActionResult
            Dim clients As List(Of CardInfo) = db.CardInfoes.ToList

            Dim result = Nothing

            If User.IsInRole("Administrator") Then
                result = From c In clients
            Else
                result = From c In clients Where c.AgentName = User.Identity.Name

            End If


            Return View(result)
        End Function

        Function EditCompany(ByVal id As String, ByVal company As String) As ActionResult


            Dim AgentData = New CardInfoView

            AgentData.CardInfoViews = db.CardInfoes.Find(id, company)
            AgentData.LinkInfoViews = db.CardLinks.Find(company, id)

            Return View(AgentData)


        End Function

        Function EditCard(ByVal company As String, ByVal id As String) As ActionResult

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


        <Authorize(Roles:="Agent,Administrator")>
        Function Create() As ActionResult
            If User.Identity.IsAuthenticated = True Then
                Return View()
            Else
                RedirectToAction("Login", "Account")
            End If
        End Function

        Function UploadFile()

            Return View()

        End Function


        <HttpPost>
        Function UploadFile(ByVal AgentData As CardInfo) As ActionResult



            For i As Integer = 0 To Request.Files.AllKeys.Length - 1
                Dim file As HttpPostedFileBase = TryCast(Request.Files(i), HttpPostedFileBase)

                Dim extension As String = IO.Path.GetExtension(file.FileName)
                If ValidateExtension(extension) = False Then



                End If


                If file.ContentLength = 0 Then Continue For


                If file.ContentLength > 0 Then
                    Dim imageUpload As ImageUpload


                    Dim imageResult As New ImageResult

                    Select Case i
                        Case = 0
                            imageUpload = New ImageUpload With {
                            .Width = 250,
                            .Height = 250}
                            imageResult = imageUpload.RenameUploadFile(file, AgentData, "profilepictures")
                            imageResult = imageUpload.RenameUploadFile(file, AgentData, "profilepicturesicons")
                            'vcardBuild.BuildCard(AgentData.DetailID, AgentData.CompanyID, file)
                        Case = 1
                            imageUpload = New ImageUpload With {
                            .Width = 1342,
                            .Height = 1000}
                            imageResult = imageUpload.RenameUploadFile(file, AgentData, "companypictures")
                    End Select



                    If imageResult.Success Then

                        Console.WriteLine(imageResult.ImageName)
                    Else
                        ViewBag.[Error] = imageResult.ErrorMessage
                    End If

                End If
            Next

            Return View()


        End Function



        Private Function GetCardData() As InsertView
            If Session("card") Is Nothing Then
                Session("card") = New InsertView
            End If

            Return CType(Session("card"), InsertView)

        End Function



        Private Sub RemoveCard()
            Session.Remove("card")
        End Sub


        Public Function EditLinks(ByVal id As String, ByVal company As String)
            Dim AgentData = New CardInfoView

            AgentData.CardInfoViews = db.CardInfoes.Find(id, company)
            AgentData.LinkInfoViews = db.CardLinks.Find(company, id)

            Return View(AgentData)


        End Function

        <HttpPost>
        Public Function EditLinks(ByVal linkdata As CardInfoView, ByVal company As String, ByVal id As String)


            Dim objLinks As CardInfoView = New CardInfoView

            If company IsNot Nothing Then

                objLinks.CardInfoViews = db.CardInfoes.Find(id, company)
                objLinks.LinkInfoViews = db.CardLinks.Find(company, id)

                objLinks.CardInfoViews.PersonBot = linkdata.CardInfoViews.PersonBot
                objLinks.CardInfoViews.CompanyBot = linkdata.CardInfoViews.CompanyBot



                If linkdata.LinkInfoViews.Title1 Is Nothing Then linkdata.LinkInfoViews.LinkName1 = Nothing
                If linkdata.LinkInfoViews.LinkName1 Is Nothing Then linkdata.LinkInfoViews.Title1 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title1, linkdata.LinkInfoViews.Title1, company, id)
                objLinks.LinkInfoViews.Title1 = linkdata.LinkInfoViews.Title1

                If linkdata.LinkInfoViews.Title2 Is Nothing Then linkdata.LinkInfoViews.LinkName2 = Nothing
                If linkdata.LinkInfoViews.LinkName2 Is Nothing Then linkdata.LinkInfoViews.Title2 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title2, linkdata.LinkInfoViews.Title2, company, id)
                objLinks.LinkInfoViews.Title2 = linkdata.LinkInfoViews.Title2

                If linkdata.LinkInfoViews.Title3 Is Nothing Then linkdata.LinkInfoViews.LinkName3 = Nothing
                If linkdata.LinkInfoViews.LinkName3 Is Nothing Then linkdata.LinkInfoViews.Title3 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title3, linkdata.LinkInfoViews.Title3, company, id)
                objLinks.LinkInfoViews.Title3 = linkdata.LinkInfoViews.Title3

                If linkdata.LinkInfoViews.Title4 Is Nothing Then linkdata.LinkInfoViews.LinkName4 = Nothing
                If linkdata.LinkInfoViews.LinkName4 Is Nothing Then linkdata.LinkInfoViews.Title4 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title4, linkdata.LinkInfoViews.Title4, company, id)
                objLinks.LinkInfoViews.Title4 = linkdata.LinkInfoViews.Title4

                If linkdata.LinkInfoViews.Title5 Is Nothing Then linkdata.LinkInfoViews.LinkName5 = Nothing
                If linkdata.LinkInfoViews.LinkName5 Is Nothing Then linkdata.LinkInfoViews.Title5 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title5, linkdata.LinkInfoViews.Title5, company, id)
                objLinks.LinkInfoViews.Title5 = linkdata.LinkInfoViews.Title5

                If linkdata.LinkInfoViews.Title6 Is Nothing Then linkdata.LinkInfoViews.LinkName6 = Nothing
                If linkdata.LinkInfoViews.LinkName6 Is Nothing Then linkdata.LinkInfoViews.Title6 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title6, linkdata.LinkInfoViews.Title6, company, id)
                objLinks.LinkInfoViews.Title6 = linkdata.LinkInfoViews.Title6

                If linkdata.LinkInfoViews.Title7 Is Nothing Then linkdata.LinkInfoViews.LinkName7 = Nothing
                If linkdata.LinkInfoViews.LinkName7 Is Nothing Then linkdata.LinkInfoViews.Title7 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title7, linkdata.LinkInfoViews.Title7, company, id)
                objLinks.LinkInfoViews.Title7 = linkdata.LinkInfoViews.Title7

                If linkdata.LinkInfoViews.Title8 Is Nothing Then linkdata.LinkInfoViews.LinkName8 = Nothing
                If linkdata.LinkInfoViews.LinkName8 Is Nothing Then linkdata.LinkInfoViews.Title8 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title8, linkdata.LinkInfoViews.Title8, company, id)
                objLinks.LinkInfoViews.Title8 = linkdata.LinkInfoViews.Title8

                If linkdata.LinkInfoViews.Title9 Is Nothing Then linkdata.LinkInfoViews.LinkName9 = Nothing
                If linkdata.LinkInfoViews.LinkName9 Is Nothing Then linkdata.LinkInfoViews.Title9 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title9, linkdata.LinkInfoViews.Title9, company, id)
                objLinks.LinkInfoViews.Title9 = linkdata.LinkInfoViews.Title9

                If linkdata.LinkInfoViews.Title10 Is Nothing Then linkdata.LinkInfoViews.LinkName10 = Nothing
                If linkdata.LinkInfoViews.LinkName10 Is Nothing Then linkdata.LinkInfoViews.Title10 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title10, linkdata.LinkInfoViews.Title10, company, id)
                objLinks.LinkInfoViews.Title10 = linkdata.LinkInfoViews.Title10

                If linkdata.LinkInfoViews.Title11 Is Nothing Then linkdata.LinkInfoViews.LinkName11 = Nothing
                If linkdata.LinkInfoViews.LinkName11 Is Nothing Then linkdata.LinkInfoViews.Title11 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title11, linkdata.LinkInfoViews.Title11, company, id)
                objLinks.LinkInfoViews.Title11 = linkdata.LinkInfoViews.Title11

                If linkdata.LinkInfoViews.Title12 Is Nothing Then linkdata.LinkInfoViews.LinkName12 = Nothing
                If linkdata.LinkInfoViews.LinkName12 Is Nothing Then linkdata.LinkInfoViews.Title12 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title12, linkdata.LinkInfoViews.Title12, company, id)
                objLinks.LinkInfoViews.Title12 = linkdata.LinkInfoViews.Title12

                If linkdata.LinkInfoViews.Title13 Is Nothing Then linkdata.LinkInfoViews.LinkName13 = Nothing
                If linkdata.LinkInfoViews.LinkName13 Is Nothing Then linkdata.LinkInfoViews.Title13 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title13, linkdata.LinkInfoViews.Title13, company, id)
                objLinks.LinkInfoViews.Title13 = linkdata.LinkInfoViews.Title13

                If linkdata.LinkInfoViews.Title14 Is Nothing Then linkdata.LinkInfoViews.LinkName14 = Nothing
                If linkdata.LinkInfoViews.LinkName14 Is Nothing Then linkdata.LinkInfoViews.Title14 = Nothing
                RenameorDeleteIMG(objLinks.LinkInfoViews.Title14, linkdata.LinkInfoViews.Title14, company, id)
                objLinks.LinkInfoViews.Title14 = linkdata.LinkInfoViews.Title14
                'RenameorDeleteIMG(objLinks.LinkInfoViews.Title15, linkdata.LinkInfoViews.Title15, company, id)
                'objLinks.LinkInfoViews.Title15 = linkdata.LinkInfoViews.Title15


                objLinks.LinkInfoViews.LinkName1 = linkdata.LinkInfoViews.LinkName1
                    objLinks.LinkInfoViews.LinkName2 = linkdata.LinkInfoViews.LinkName2
                    objLinks.LinkInfoViews.LinkName3 = linkdata.LinkInfoViews.LinkName3
                    objLinks.LinkInfoViews.LinkName4 = linkdata.LinkInfoViews.LinkName4
                    objLinks.LinkInfoViews.LinkName5 = linkdata.LinkInfoViews.LinkName5
                    objLinks.LinkInfoViews.LinkName6 = linkdata.LinkInfoViews.LinkName6
                    objLinks.LinkInfoViews.LinkName7 = linkdata.LinkInfoViews.LinkName7
                    objLinks.LinkInfoViews.LinkName8 = linkdata.LinkInfoViews.LinkName8
                    objLinks.LinkInfoViews.LinkName9 = linkdata.LinkInfoViews.LinkName9
                    objLinks.LinkInfoViews.LinkName10 = linkdata.LinkInfoViews.LinkName10
                    objLinks.LinkInfoViews.LinkName11 = linkdata.LinkInfoViews.LinkName11
                    objLinks.LinkInfoViews.LinkName12 = linkdata.LinkInfoViews.LinkName12
                    objLinks.LinkInfoViews.LinkName13 = linkdata.LinkInfoViews.LinkName13
                    objLinks.LinkInfoViews.LinkName14 = linkdata.LinkInfoViews.LinkName14
                    'objLinks.LinkInfoViews.LinkName15 = linkdata.LinkInfoViews.LinkName15





                    db.SaveChanges()



                    Return RedirectToAction("index", "Agent")




                End If



        End Function

        Sub RenameorDeleteIMG(ByVal oldtitle As String, ByVal linkTitle As String, ByVal company As String, ByVal id As String)


            If linkTitle <> oldtitle And linkTitle IsNot Nothing Then

                Dim oldPath As String = "/Views/card/uploads/" & company & "/" & id & "/templatepictures/" & oldtitle & ".png"
                Dim newPath As String = "/Views/card/uploads/" & company & "/" & id & "/templatepictures/" & linkTitle & ".png"

                IO.File.Move(Server.MapPath(oldPath), Server.MapPath(newPath))


            End If


            If oldtitle IsNot Nothing And linkTitle Is Nothing Then

                IO.File.Delete(Server.MapPath("/Views/card/uploads/" & company & "/" & id & "/templatepictures/" & oldtitle & ".png"))


            End If




            If oldtitle Is Nothing And linkTitle IsNot Nothing Then


                Dim newPath As String = "/Views/card/uploads/" & company & "/" & id & "/templatepictures/" & linkTitle & "png"
                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath(newPath))


            End If

        End Sub


        Public Function NormalizeString(ByVal value As String) As String

            If value IsNot Nothing Then

                Dim tmpByte() As Byte = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(value)

                Dim result As String = Encoding.UTF8.GetString(tmpByte)

                Dim returnstr As String = Replace(Regex.Replace(result, "[\W_-[\s]]+", ""), " ", "")

                Return returnstr

            Else

                value = ""

            End If

            Return value

        End Function



        <HttpPost()>
        Public Function Finish(ByVal AgentData As InsertView, ByVal btnFinish As String)

            Dim objAgent As InsertView = New InsertView
            Dim CheckData = New CardInfoView

            If btnFinish IsNot Nothing Then

                Dim CardInf As CardInfo = New CardInfo
                Dim CardLnk As CardLink = New CardLink


                CardInf.FirstName = AgentData.FirstName
                CardInf.MiddleName = AgentData.MiddleName
                CardInf.LastName = AgentData.LastName
                CardInf.DetailID = NormalizeString(AgentData.FirstName & AgentData.LastName)
                CardInf.DisplayName = AgentData.FirstName & " " & AgentData.LastName
                CardInf.CompanyName = AgentData.CompanyName
                CardInf.CompanyID = NormalizeString(AgentData.CompanyName)
                CardInf.ProfilePic = getProfileSaveLocation(CardInf.CompanyID, CardInf.DetailID)

                CardInf.AgentName = User.Identity.Name
                CardInf.Bio = AgentData.Bio
                CardInf.WebSite = AgentData.WebSite
                CardInf.StreetName = AgentData.StreetName
                CardInf.AddressLine = AgentData.AddressLine
                CardInf.Province = AgentData.Province
                CardInf.PostalCode = AgentData.PostalCode
                CardInf.Country = AgentData.Country
                CardInf.CompanyLogo = AgentData.CompanyLogo
                CardInf.Company_moto = AgentData.Company_moto
                CardInf.FaxNumber = AgentData.FaxNumber
                CardInf.LandLineNumber = AgentData.LandLineNumber
                CardInf.Introduction = AgentData.Introduction
                CardInf.Location = AgentData.Location
                CardInf.CompanyBot = AgentData.CompanyBot

                CardInf.Alias = AgentData.Alias
                CardInf.Bio = AgentData.Bio
                CardInf.JobTitle = AgentData.JobTitle
                CardInf.Location = AgentData.Location
                'CardInf.ProfilePic = AgentData.ProfilePic
                CardInf.email = AgentData.email
                CardInf.MobileNumber = AgentData.MobileNumber
                CardInf.Facebook = AgentData.Facebook
                CardInf.Instagram = AgentData.Instagram
                CardInf.Twitter = AgentData.Twitter
                CardInf.LinkedIn = AgentData.LinkedIn
                CardInf.YouTube = AgentData.YouTube
                CardInf.Introduction = AgentData.Introduction
                CardInf.PersonBot = AgentData.PersonBot

                db.CardInfoes.Add(CardInf)

                CardLnk.CardID = CardInf.DetailID
                CardLnk.LinkName1 = AgentData.LinkName1
                CardLnk.LinkName2 = AgentData.LinkName2
                CardLnk.LinkName3 = AgentData.LinkName3
                CardLnk.LinkName4 = AgentData.LinkName4
                CardLnk.LinkName5 = AgentData.LinkName5
                CardLnk.LinkName6 = AgentData.LinkName6
                CardLnk.LinkName7 = AgentData.LinkName7
                CardLnk.LinkName8 = AgentData.LinkName8
                CardLnk.LinkName9 = AgentData.LinkName9
                CardLnk.LinkName10 = AgentData.LinkName10
                CardLnk.LinkName11 = AgentData.LinkName11
                CardLnk.LinkName12 = AgentData.LinkName12
                CardLnk.LinkName13 = AgentData.LinkName13
                CardLnk.LinkName14 = AgentData.LinkName14
                CardLnk.LinkName15 = "https://meishi.me/Views/card/uploads/" & CardInf.CompanyID & "/" & CardInf.DetailID & "/templatepictures/Scan My Meishi.png"

                CardLnk.Title1 = AgentData.Title1
                CardLnk.Title2 = AgentData.Title2
                CardLnk.Title3 = AgentData.Title3
                CardLnk.Title4 = AgentData.Title4
                CardLnk.Title5 = AgentData.Title5
                CardLnk.Title6 = AgentData.Title6
                CardLnk.Title7 = AgentData.Title7
                CardLnk.Title8 = AgentData.Title8
                CardLnk.Title9 = AgentData.Title9
                CardLnk.Title10 = AgentData.Title10
                CardLnk.Title11 = AgentData.Title11
                CardLnk.Title12 = AgentData.Title12
                CardLnk.Title13 = AgentData.Title13
                CardLnk.Title14 = AgentData.Title14
                CardLnk.Title15 = "Scan my Meishi"

                CardLnk.CompanyID = CardInf.CompanyID


                db.CardLinks.Add(CardLnk)
                db.SaveChanges()

                UploadFile(CardInf)

                If IO.File.Exists(Server.MapPath("/Views/card/assets/css/style.css")) = True Then
                    IO.File.Copy(Server.MapPath("/Views/card/assets/css/style.css"), Server.MapPath("/Views/card/uploads/" & CardInf.CompanyID & "/" & CardInf.DetailID & "/css/style.css"))
                End If

                SaveLinkImages(CardLnk, CardInf)

                GenerateQRCode(CardInf.DetailID, CardInf.CompanyID)

                RemoveCard()

                Return RedirectToAction("Index")

            End If

        End Function


        Public Function CreateAnother(ByVal AgentData As InsertView)

            Return View(AgentData)

        End Function

        Private Function GenerateQRCode(ByVal id As String, ByVal company As String) As String


            Dim QRCodeText As String = "https://meishi.me/card/" & company & "/" & id
            Dim imagePath As String = "/Views/card/uploads/" & company & "/" & id & "/templatepictures/Scan My Meishi.png"


            Dim barcodeWriter = New BarcodeWriter()
            barcodeWriter.Format = BarcodeFormat.QR_CODE
            barcodeWriter.Options = New EncodingOptions() With {
                .Height = 134,
                .Width = 134,
                .Margin = 1
            }
            Dim result = barcodeWriter.Write(QRCodeText)
            Dim barcodePath As String = Server.MapPath(imagePath)
            Dim barcodeBitmap = New Bitmap(result)

            Using memory As MemoryStream = New MemoryStream()

                Using fs As FileStream = New FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite)
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg)
                    Dim bytes As Byte() = memory.ToArray()
                    fs.Write(bytes, 0, bytes.Length)
                End Using
            End Using


        End Function

        Private Function SaveLinkImages(ByVal cardlink As CardLink, ByVal cardInf As CardInfo)

            If cardlink.Title1 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title1 & ".png"))

            End If

            If cardlink.Title2 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title2 & ".png"))

            End If

            If cardlink.Title3 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title3 & ".png"))

            End If

            If cardlink.Title4 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title4 & ".png"))

            End If

            If cardlink.Title5 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title5 & ".png"))

            End If

            If cardlink.Title6 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title6 & ".png"))

            End If

            If cardlink.Title7 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title7 & ".png"))

            End If

            If cardlink.Title8 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title8 & ".png"))

            End If

            If cardlink.Title9 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title9 & ".png"))

            End If

            If cardlink.Title10 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title10 & ".png"))

            End If

            If cardlink.Title11 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title11 & ".png"))

            End If

            If cardlink.Title12 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title12 & ".png"))

            End If

            If cardlink.Title13 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title13 & ".png"))

            End If

            If cardlink.Title14 IsNot Nothing Then

                IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" & cardInf.DetailID & "/templatepictures/" & cardlink.Title14 & ".png"))

            End If

            If cardlink.Title15 IsNot Nothing Then

                'IO.File.Copy(Server.MapPath("/App_Data/tmp/default/default1.png"), Server.MapPath("/Views/card/uploads/" & cardlink.CompanyID & "/" &  cardinf.detailid & "/templatepictures/" & cardlink.Title15 & ".png"))


            End If


        End Function



        Private Function getProfileSaveLocation(ByVal cPath As String, ByVal pPath As String) As String

            Dim UploadPath As String = "/Views/card/uploads/" & cPath

            If cPath IsNot Nothing And pPath IsNot Nothing Then


                If IO.Directory.Exists(Server.MapPath(UploadPath)) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath)) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/contact")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/contact"))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/companypictures")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/companypictures"))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/profilepictures")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/profilepictures"))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/profilepicturesicons")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/profilepicturesicons"))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/templatepictures")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/templatepictures"))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/css")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/css"))
                If IO.Directory.Exists(Server.MapPath(UploadPath & "/" & pPath & "/custom")) = False Then IO.Directory.CreateDirectory(Server.MapPath(UploadPath & "/" & pPath & "/custom"))
                UploadPath = UploadPath & "/" & pPath

                Return UploadPath

            End If

            UploadPath = UploadPath & "/" & pPath

            Return UploadPath

        End Function

        Private Function ValidateExtension(ByVal extension As String) As Boolean
            extension = extension.ToLower()

            Select Case extension
                Case ".jpg"
                    Return True
                Case ".png"
                    Return True
                Case ".gif"
                    Return True
                Case ".jpeg"
                    Return True
                Case Else
                    Return False
            End Select
        End Function

        'Private Sub SaveImages(ByVal AgentData As InsertView, ByVal file As HttpPostedFileBase)

        '    For i As Integer = 0 To Request.Files.AllKeys.Length - 1
        '        Dim file1 As HttpPostedFileBase = TryCast(Request.Files(i), HttpPostedFileBase)

        '        Dim img As Image = Convert2png(file1)
        '        Dim filename As String = ""
        '        Select Case i
        '         Case = 0
        '                filename = Path.Combine(Server.MapPath("~/Views/card/uploads/" & AgentData.CompanyID & "/" & AgentData.FirstName & AgentData.LastName & "/profilepictures/"), AgentData.FirstName & AgentData.LastName & ".png")
        '            Case = 1
        '                filename = Path.Combine(Server.MapPath("~/Views/card/uploads/" & AgentData.CompanyID & "/" & AgentData.FirstName & AgentData.LastName & "/companypicture/"), AgentData.CompanyID & ".png")
        '        End Select

        '        file1.SaveAs(filename)

        '    Next



        'End Sub



        <Route("Agent/EditLeft/{company}/{id}")>
        Function EditLeft(ByVal id As String, ByVal company As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim AgentData = New CardInfoView

            AgentData.CardInfoViews = db.CardInfoes.Find(id, company)


            If IsNothing(AgentData) Then
                Return HttpNotFound()
                Exit Function
            End If
            Return View(AgentData)
        End Function
    End Class

    Public Class GreaterThanAttribute
        Inherits ValidationAttribute

        Public Property PropName As String

        Protected Overrides Function IsValid(ByVal value As Object, ByVal validationContext As ValidationContext) As ValidationResult
            Dim otherPropertyInfo As PropertyInfo = validationContext.ObjectType.GetProperty(PropName)
            Dim otherPropertyStringValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, Nothing).ToString()

            If Convert.ToUInt32(value) < Convert.ToUInt32(otherPropertyStringValue) Then
                Return New ValidationResult(FormatErrorMessage(validationContext.DisplayName))
            End If

            Return Nothing
        End Function
    End Class
End Namespace