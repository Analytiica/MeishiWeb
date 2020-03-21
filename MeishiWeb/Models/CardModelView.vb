Imports System.ComponentModel.DataAnnotations

Namespace MeishiWeb.Models
    Public Class CardModelView

        Public Property CardViews As CardView
        Public Property LinkViews As New LinkView

    End Class

    Public Class CardInfoView

        Public Property CardInfoViews As CardInfo
        Public Property LinkInfoViews As CardLink

    End Class
    Public Class CardView
        Public Property DetailID As String
        <Key>
        Public Property CompanyID As String
        <Display(Name:="Company Name")>
        Public Property CompanyName As String
        <Display(Name:="Street Name")>
        Public Property StreetName As String
        <Display(Name:="Address Line")>
        Public Property AddressLine As String
        <Display(Name:="Province")>
        Public Property Province As String
        <Display(Name:="Postal Code")>
        Public Property PostalCode As String
        Public Property Country As String
        <Display(Name:="Display Name")>
        Public Property DisplayName As String
        <Display(Name:="Company Logo")>
        Public Property CompanyLogo As String
        <Display(Name:="Company Moto")>
        <DataType(DataType.MultilineText)>
        Public Property Company_moto As String
        <Display(Name:="Agent Name")>
        Public Property AgentName As String
        <DataType(DataType.MultilineText)>
        Public Property Introduction As String
        <Display(Name:="First Name")>
        Public Property FirstName As String
        <Display(Name:="Middle Name")>
        Public Property MiddleName As String
        <Display(Name:="Last Name")>
        Public Property LastName As String
        <Display(Name:="Alias Name")>
        Public Property [Alias] As String
        <DataType(DataType.MultilineText)>
        Public Property Bio As String
        <Display(Name:="Job Title")>
        Public Property JobTitle As String
        Public Property Location As String
        <Display(Name:="Profile Picture")>
        Public Property ProfilePic As String
        <Display(Name:=" Card Email")>
        Public Property email As String
        Public Property WebSite As String
        <Display(Name:="Facebook Link")>
        Public Property Facebook As String
        <Display(Name:="Instagram Link")>
        Public Property Instagram As String
        <Display(Name:="Twitter Link")>
        Public Property Twitter As String
        <Display(Name:="LinkedIn Link")>
        Public Property LinkedIn As String
        <Display(Name:="YouTube Link")>
        Public Property YouTube As String
        <Display(Name:="Telephone Number")>
        Public Property LandLineNumber As String
        <Display(Name:="Mobile Number")>
        Public Property MobileNumber As String
        <Display(Name:="Fax Number")>
        Public Property FaxNumber As String
        Public Property ActiveAccount As String
        <Display(Name:="Bot Link for Company")>
        Public Property CompanyBot As String
        <Display(Name:="Bot Link for Person")>
        Public Property PersonBot As String

    End Class

    Public Class LinkView

        <Display(Name:="Web Link1")>
        Public Property LinkName1 As String
        <Display(Name:="Web Link2")>
        Public Property LinkName2 As String
        <Display(Name:="Web Link3")>
        Public Property LinkName3 As String
        <Display(Name:="Web Link4")>
        Public Property LinkName4 As String
        <Display(Name:="Web Link5")>
        Public Property LinkName5 As String
        <Display(Name:="Web Link6")>
        Public Property LinkName6 As String
        <Display(Name:="Web Link7")>
        Public Property LinkName7 As String
        <Display(Name:="Web Link8")>
        Public Property LinkName8 As String
        <Display(Name:="Web Link9")>
        Public Property LinkName9 As String
        <Display(Name:="Web Link10")>
        Public Property LinkName10 As String
        <Display(Name:="Web Link11")>
        Public Property LinkName11 As String
        <Display(Name:="Web Link12")>
        Public Property LinkName12 As String
        <Display(Name:="Web Link13")>
        Public Property LinkName13 As String
        <Display(Name:="Web Link14")>
        Public Property LinkName14 As String
        <Display(Name:="Web Link15")>
        Public Property LinkName15 As String

        Public Property Title1 As String
        Public Property Title2 As String
        Public Property Title3 As String
        Public Property Title4 As String
        Public Property Title5 As String
        Public Property Title6 As String
        Public Property Title7 As String
        Public Property Title8 As String
        Public Property Title9 As String
        Public Property Title10 As String
        Public Property Title11 As String
        Public Property Title12 As String
        Public Property Title13 As String
        Public Property Title14 As String
        Public Property Title15 As String

    End Class

    Public Class InsertView

        Public Property DetailID As String
        <Key>
        Public Property CompanyID As String
        <Display(Name:="Company Name")>
        <Required(ErrorMessage:="Company Name is required")>
        Public Property CompanyName As String
        <Display(Name:="Street Name")>
        Public Property StreetName As String
        <Display(Name:="Address Line")>
        Public Property AddressLine As String
        <Display(Name:="Province")>
        Public Property Province As String
        <Display(Name:="Postal Code")>
        Public Property PostalCode As String
        Public Property Country As String
        <Display(Name:="Display Name")>
        Public Property DisplayName As String
        <Display(Name:="Company Logo")>
        Public Property CompanyLogo As String
        <Display(Name:="Company Moto")>
        <DataType(DataType.MultilineText)>
        Public Property Company_moto As String
        <Display(Name:="Agent Name")>
        Public Property AgentName As String
        <DataType(DataType.MultilineText)>
        Public Property Introduction As String
        <Display(Name:="First Name")>
        <Required(ErrorMessage:="First Name is required")>
        Public Property FirstName As String
        <Display(Name:="Middle Name")>
        Public Property MiddleName As String
        <Display(Name:="Last Name")>
        <Required(ErrorMessage:="Last Name is required")>
        Public Property LastName As String
        <Display(Name:="Alias Name")>
        Public Property [Alias] As String
        <DataType(DataType.MultilineText)>
        Public Property Bio As String
        <Display(Name:="Job Title")>
        Public Property JobTitle As String
        <HiddenInput>
        Public Property Location As String
        <Display(Name:="Profile Picture")>
        Public Property ProfilePic As String
        <Display(Name:="Email")>
        <Required(ErrorMessage:="Email Address is required")>
        Public Property email As String
        Public Property WebSite As String
        <Display(Name:="Facebook Link")>
        Public Property Facebook As String
        <Display(Name:="Instagram Link")>
        Public Property Instagram As String
        <Display(Name:="Twitter Link")>
        Public Property Twitter As String
        <Display(Name:="LinkedIn Link")>
        Public Property LinkedIn As String
        <Display(Name:="YouTube Link")>
        Public Property YouTube As String
        <Display(Name:="Telephone Number")>
        Public Property LandLineNumber As String
        <Display(Name:="Mobile Number")>
        Public Property MobileNumber As String
        <Display(Name:="Fax Number")>
        Public Property FaxNumber As String
        Public Property ActiveAccount As String
        <Display(Name:="Bot Link for Company")>
        Public Property CompanyBot As String
        <Display(Name:="Bot Link for Person")>
        Public Property PersonBot As String


        <Display(Name:="Web Link1")>
        Public Property LinkName1 As String
        <Display(Name:="Web Link2")>
        Public Property LinkName2 As String
        <Display(Name:="Web Link3")>
        Public Property LinkName3 As String
        <Display(Name:="Web Link4")>
        Public Property LinkName4 As String
        <Display(Name:="Web Link5")>
        Public Property LinkName5 As String
        <Display(Name:="Web Link6")>
        Public Property LinkName6 As String
        <Display(Name:="Web Link7")>
        Public Property LinkName7 As String
        <Display(Name:="Web Link8")>
        Public Property LinkName8 As String
        <Display(Name:="Web Link9")>
        Public Property LinkName9 As String
        <Display(Name:="Web Link10")>
        Public Property LinkName10 As String

        <Display(Name:="Web Link11")>
        Public Property LinkName11 As String
        <Display(Name:="Web Link12")>
        Public Property LinkName12 As String
        <Display(Name:="Web Link13")>
        Public Property LinkName13 As String
        <Display(Name:="Web Link14")>
        Public Property LinkName14 As String
        <Display(Name:="Web Link15")>
        Public Property LinkName15 As String
        <Display(Name:="Link Title")>
        Public Property Title1 As String
        <Display(Name:="Link Title")>
        Public Property Title2 As String
        <Display(Name:="Link Title")>
        Public Property Title3 As String
        <Display(Name:="Link Title")>
        Public Property Title4 As String
        <Display(Name:="Link Title")>
        Public Property Title5 As String
        <Display(Name:="Link Title")>
        Public Property Title6 As String
        <Display(Name:="Link Title")>
        Public Property Title7 As String
        <Display(Name:="Link Title")>
        Public Property Title8 As String
        <Display(Name:="Link Title")>
        Public Property Title9 As String
        <Display(Name:="Link Title")>
        Public Property Title10 As String
        <Display(Name:="Link Title")>
        Public Property Title11 As String
        <Display(Name:="Link Title")>
        Public Property Title12 As String
        <Display(Name:="Link Title")>
        Public Property Title13 As String
        <Display(Name:="Link Title")>
        Public Property Title14 As String
        <Display(Name:="Link Title")>
        Public Property Title15 As String
    End Class

    Public Class ChartView

        Public Property DetailID As String
        <Key>
        Public Property CompanyID As String
        <Display(Name:="Company Name")>
        Public Property CompanyName As String
        <Display(Name:="Street Name")>
        Public Property StreetName As String
        <Display(Name:="Address Line")>
        Public Property AddressLine As String
        <Display(Name:="Province")>
        Public Property Province As String
        <Display(Name:="Postal Code")>
        Public Property PostalCode As String
        Public Property Country As String
        <Display(Name:="Display Name")>
        Public Property DisplayName As String
        <Display(Name:="Company Logo")>
        Public Property CompanyLogo As String
        <Display(Name:="Company Moto")>
        <DataType(DataType.MultilineText)>
        Public Property Company_moto As String
        <Display(Name:="Agent Name")>
        Public Property AgentName As String
        <DataType(DataType.MultilineText)>
        Public Property Introduction As String
        <Display(Name:="First Name")>
        Public Property FirstName As String
        <Display(Name:="Middle Name")>
        Public Property MiddleName As String
        <Display(Name:="Last Name")>
        Public Property LastName As String
        <Display(Name:="Alias Name")>
        Public Property [Alias] As String
        <DataType(DataType.MultilineText)>
        Public Property Bio As String
        <Display(Name:="Job Title")>
        Public Property JobTitle As String
        <HiddenInput>
        Public Property Location As String
        <Display(Name:="Profile Picture")>
        Public Property ProfilePic As String
        <Display(Name:="Email")>
        Public Property email As String
        Public Property WebSite As String
        <Display(Name:="Facebook Link")>
        Public Property Facebook As String
        <Display(Name:="Instagram Link")>
        Public Property Instagram As String
        <Display(Name:="Twitter Link")>
        Public Property Twitter As String
        <Display(Name:="LinkedIn Link")>
        Public Property LinkedIn As String
        <Display(Name:="YouTube Link")>
        Public Property YouTube As String
        <Display(Name:="Telephone Number")>
        Public Property LandLineNumber As String
        <Display(Name:="Mobile Number")>
        Public Property MobileNumber As String
        <Display(Name:="Fax Number")>
        Public Property FaxNumber As String
        <Display(Name:="Link Title")>
        Public Property Title1 As String
        <Display(Name:="Link Title")>
        Public Property Title2 As String
        <Display(Name:="Link Title")>
        Public Property Title3 As String
        <Display(Name:="Link Title")>
        Public Property Title4 As String
        <Display(Name:="Link Title")>
        Public Property Title5 As String
        <Display(Name:="Link Title")>
        Public Property Title6 As String
        <Display(Name:="Link Title")>
        Public Property Title7 As String
        <Display(Name:="Link Title")>
        Public Property Title8 As String
        <Display(Name:="Link Title")>
        Public Property Title9 As String
        <Display(Name:="Link Title")>
        Public Property Title10 As String
        <Display(Name:="Link Title")>
        Public Property Title11 As String
        <Display(Name:="Link Title")>
        Public Property Title12 As String
        <Display(Name:="Link Title")>
        Public Property Title13 As String
        <Display(Name:="Link Title")>
        Public Property Title14 As String
        <Display(Name:="Link Title")>
        Public Property Title15 As String
        Public Property AllProfiles As String()
        Public Property AllServices As String()
        Public Property ProfileCount As Integer()
        Public Property ServiceCount As Integer()

        Public Property rDate As String()
        Public Property rPrf As Integer()
        Public Property rSrv As Integer()
        Public Property CurrentMonth As String
    End Class

End Namespace


