Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports MeishiWeb.MeishiWeb
Imports MeishiWeb.MeishiWeb.Models

Public Class ImageUpload
    Public Property Width As Integer
    Public Property Height As Integer
    Private ReadOnly UploadPath As String = "~/Views/card/uploads/"

    Public Function RenameUploadFile(ByVal file As HttpPostedFileBase, ByVal AgentData As CardInfo, ByVal ppath As String, ByVal Optional counter As Int32 = 0) As ImageResult
        Dim fileName = Path.GetFileName(file.FileName)


        Dim finalFileName As String = ""

        Select Case ppath
            Case = "companypictures"
                finalFileName = AgentData.CompanyID
            Case Else
                finalFileName = AgentData.DetailID

        End Select


        Return UploadFile(file, AgentData.CompanyID & "/" & AgentData.DetailID & "/" & ppath & "/" & finalFileName)
    End Function

    Private Function UploadFile(ByVal file As HttpPostedFileBase, ByVal fileName As String) As ImageResult
        Dim imageResult As ImageResult = New ImageResult With {
            .Success = True,
            .ErrorMessage = Nothing
        }
        Dim path As String = IO.Path.Combine(HttpContext.Current.Request.MapPath(UploadPath), fileName)
        Dim extension As String = IO.Path.GetExtension(file.FileName)

        If Not ValidateExtension(extension) Then
            'imageResult.Success = False
            'imageResult.ErrorMessage = "Invalid Extension"
            'Return imageResult
            path = path & extension
        Else

            path = path & ".png"
        End If

        Try
            file.SaveAs(path)
            Dim imgOriginal As Image = Image.FromFile(path)
            Dim imgActual As Image = Scale(imgOriginal)
            imgOriginal.Dispose()
            imgActual.Save(path)
            imgActual.Dispose()
            imageResult.ImageName = fileName
            imageResult.Success = True

            Return imageResult
        Catch ex As Exception
            imageResult.Success = False
            imageResult.ErrorMessage = ex.Message
            Return imageResult
        End Try
    End Function

    Private Function ValidateExtension(ByVal extension As String) As Boolean
        extension = extension.ToLower()

        Select Case extension
            Case ".jpg"
                Return True
            Case ".png"
                Return False
            Case ".gif"
                Return True
            Case ".jpeg"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Function Scale(ByVal imgPhoto As Image) As Image
        Dim sourceWidth As Single = imgPhoto.Width
        Dim sourceHeight As Single = imgPhoto.Height
        Dim destHeight As Single = 0
        Dim destWidth As Single = 0
        Dim sourceX As Integer = 0
        Dim sourceY As Integer = 0
        Dim destX As Integer = 0
        Dim destY As Integer = 0

        If Width <> 0 AndAlso Height <> 0 Then
            destWidth = Width
            destHeight = Height
        ElseIf Height <> 0 Then
            destWidth = CSng((Height * sourceWidth)) / sourceHeight
            destHeight = Height
        Else
            destWidth = Width
            destHeight = CSng((sourceHeight * Width / sourceWidth))
        End If

        Dim bmPhoto As Bitmap = New Bitmap(CInt(destWidth), CInt(destHeight), PixelFormat.Format32bppPArgb)
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)
        Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic
        grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, CInt(destWidth), CInt(destHeight)), New Rectangle(sourceX, sourceY, CInt(sourceWidth), CInt(sourceHeight)), GraphicsUnit.Pixel)
        grPhoto.Dispose()
        Return bmPhoto
    End Function

    Private Function Convert2png(ByVal img As HttpPostedFileBase)

        Dim extension As String = Path.GetExtension(img.FileName)

        If ValidateExtension(extension) = True Then

            Dim b As Bitmap = CType(Bitmap.FromStream(img.InputStream), Bitmap)

            Using ms As MemoryStream = New MemoryStream()

                b.Save(ms, ImageFormat.Png)

            End Using

            Return b

        End If

        Return img
    End Function
End Class

