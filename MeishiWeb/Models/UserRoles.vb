Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

Namespace MeishiWeb.Models
    Public Class ExpandedUser
        <Key>
        <Display(Name:="User Name")>
        Public Property UserName As String
        Public Property Email As String
        Public Property Password As String
        Public Property Role As String
        <Display(Name:="Lockout End Date UTC")>
        Public Property LockoutEndDateUTC As DateTime?
        Public Property AccessFailedCount As Integer
        Public Property PhoneNumber As String
        Public Property Roles As IEnumerable(Of ExpandedUser)
    End Class

    Public Class UserRoles
        <Key>
        <Display(Name:="Role Name")>
        Public Property RoleName As String
    End Class

    Public Class UserRole
        <Key>
        <Display(Name:="User Name")>
        Public Property UserName As String
        <Display(Name:="Role Name")>
        Public Property RoleName As String
    End Class

    Public Class Role
        <Key>
        Public Property Id As String
        <Display(Name:="Role Name")>
        Public Property RoleName As String
    End Class

    Public Class UserAndRoles
        <Key>
        <Display(Name:="User Name")>
        Public Property UserName As String
        Public Property colUserRole As List(Of UserRole)
    End Class
End Namespace
