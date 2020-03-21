Imports System
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Collections.Generic
Imports PagedList
Imports MeishiWeb.MeishiWeb.Models

Namespace MeishiWeb.Controllers
    Public Class AdminController
        Inherits Controller

        Private _userManager As ApplicationUserManager
        Private _roleManager As ApplicationRoleManager

        <Authorize(Roles:="Administrator")>
        Public Function Index(ByVal searchStringUserNameOrEmail As String, ByVal currentFilter As String, ByVal page As Integer?) As ActionResult
            Try
                Dim intPage As Integer = 1
                Dim intPageSize As Integer = 100
                Dim intTotalPageCount As Integer = 0

                If searchStringUserNameOrEmail IsNot Nothing Then
                    intPage = 1
                Else

                    If currentFilter IsNot Nothing Then
                        searchStringUserNameOrEmail = currentFilter
                        intPage = If(page, 1)
                    Else
                        searchStringUserNameOrEmail = ""
                        intPage = If(page, 1)
                    End If
                End If

                ViewBag.CurrentFilter = searchStringUserNameOrEmail
                Dim col_User As List(Of ExpandedUser) = New List(Of ExpandedUser)()
                Dim intSkip As Integer = (intPage - 1) * intPageSize
                intTotalPageCount = UserManager.Users.Where(Function(x) x.UserName.Contains(searchStringUserNameOrEmail)).Count()
                Dim result = UserManager.Users.Where(Function(x) x.UserName.Contains(searchStringUserNameOrEmail)).OrderBy(Function(x) x.UserName).Skip(intSkip).Take(intPageSize).ToList()


                For Each item In result
                    Dim objUser As ExpandedUser = New ExpandedUser()
                    objUser.UserName = item.UserName
                    objUser.Email = item.Email
                    objUser.LockoutEndDateUTC = item.LockoutEndDateUtc
                    Dim gUser As ExpandedUser = GetUser(item.UserName)
                    objUser.Role = gUser.Role
                    col_User.Add(objUser)
                Next

                Dim _UserAsIPagedList = New StaticPagedList(Of ExpandedUser)(col_User, intPage, intPageSize, intTotalPageCount)
                Return View(_UserAsIPagedList)
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Dim col_User As List(Of ExpandedUser) = New List(Of ExpandedUser)()
                Return View(col_User.ToPagedList(1, 25))
            End Try
        End Function

        Private Function GetUserAndRoles(ByVal UserName As String) As UserAndRoles
            Dim user As ApplicationUser = UserManager.FindByName(UserName)
            Dim colUserRole As List(Of UserRole) = (From objRole In UserManager.GetRoles(user.Id) Select New UserRole With {
                .RoleName = objRole,
                .UserName = UserName
            }).ToList()

            If colUserRole.Count() = 0 Then
                colUserRole.Add(New UserRole With {
                    .RoleName = "No Roles Found"
                })
            End If

            ViewBag.AddRole = New SelectList(RolesUserIsNotIn(UserName))
            Dim objUserAndRoles As UserAndRoles = New UserAndRoles()
            objUserAndRoles.UserName = UserName
            objUserAndRoles.colUserRole = colUserRole
            Return objUserAndRoles
        End Function
        <HttpPost>
        Private Function RolesUserIsNotIn(ByVal UserName As String) As List(Of String)
            Dim colAllRoles = RoleManager.Roles.[Select](Function(x) x.Name).ToList()
            Dim user As ApplicationUser = UserManager.FindByName(UserName)

            If user Is Nothing Then
                Throw New Exception("Could not find the User")
            End If

            Dim colRolesForUser = UserManager.GetRoles(user.Id).ToList()
            Dim colRolesUserInNotIn = (From objRole In colAllRoles Where Not colRolesForUser.Contains(objRole) Select objRole).ToList()

            If colRolesUserInNotIn.Count() = 0 Then
                colRolesUserInNotIn.Add("No Roles Found")
            End If

            Return colRolesUserInNotIn
        End Function

        Private Function GetAllRolesAsSelectList() As List(Of SelectListItem)
            Dim SelectRoleListItems As List(Of SelectListItem) = New List(Of SelectListItem)()
            Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
            Dim colRoleSelectList = roleManager.Roles.OrderBy(Function(x) x.Name).ToList()
            SelectRoleListItems.Add(New SelectListItem With {
                .Text = "Select",
                .Value = "0"
            })

            For Each item In colRoleSelectList
                SelectRoleListItems.Add(New SelectListItem With {
                    .Text = item.Name.ToString(),
                    .Value = item.Name.ToString()
                })
            Next

            Return SelectRoleListItems
        End Function

        Public Property UserManager As ApplicationUserManager
            Get
                Return If(_userManager, HttpContext.GetOwinContext().GetUserManager(Of ApplicationUserManager)())
            End Get
            Private Set(ByVal value As ApplicationUserManager)
                _userManager = value
            End Set
        End Property

        Public Property RoleManager As ApplicationRoleManager
            Get
                Return If(_roleManager, HttpContext.GetOwinContext().GetUserManager(Of ApplicationRoleManager)())
            End Get
            Private Set(ByVal value As ApplicationRoleManager)
                _roleManager = value
            End Set
        End Property

        Private Function UpdateUser(ByVal paramExpandedUser As ExpandedUser) As ExpandedUser
            Dim result As ApplicationUser = UserManager.FindByName(paramExpandedUser.UserName)

            If result Is Nothing Then
                Throw New Exception("Could not find the User")
            End If

            result.Email = paramExpandedUser.Email

            If UserManager.IsLockedOut(result.Id) Then
                UserManager.ResetAccessFailedCountAsync(result.Id)
            End If

            UserManager.Update(result)

            If Not String.IsNullOrEmpty(paramExpandedUser.Password) Then
                Dim removePassword = UserManager.RemovePassword(result.Id)

                If removePassword.Succeeded Then
                    Dim AddPassword = UserManager.AddPassword(result.Id, paramExpandedUser.Password)

                    If AddPassword.Errors.Count() > 0 Then
                        Throw New Exception(AddPassword.Errors.FirstOrDefault())
                    End If
                End If
            End If

            Return paramExpandedUser
        End Function

        Private Sub DeleteUser(ByVal paramExpandedUser As ExpandedUser)
            Dim user As ApplicationUser = UserManager.FindByName(paramExpandedUser.UserName)

            If user Is Nothing Then
                Throw New Exception("Could not find the User")
            End If

            UserManager.RemoveFromRoles(user.Id, UserManager.GetRoles(user.Id).ToArray())
            UserManager.Update(user)
            UserManager.Delete(user)
        End Sub

        Private Function GetUser(ByVal UserName As String) As ExpandedUser
            Dim user As ApplicationUser = UserManager.FindByName(UserName)

            If user Is Nothing Then
                Throw New Exception("Could not find the User")
            End If

            Dim paramExpandedUser As ExpandedUser = New ExpandedUser()
            paramExpandedUser.UserName = user.UserName
            paramExpandedUser.Email = user.Email
            paramExpandedUser.Password = user.PasswordHash
            Dim uRole As UserAndRoles = GetUserAndRoles(user.UserName)
            paramExpandedUser.Role = uRole.colUserRole(0).RoleName
            Return paramExpandedUser
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function ViewAllRoles() As ActionResult
            Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
            Dim colRole As List(Of Role) = (From objRole In roleManager.Roles Select New Role With {
                .Id = objRole.Id,
                .RoleName = objRole.Name
            }).ToList()
            Return View(colRole)
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function AddRole() As ActionResult
            Dim objRole As Role = New Role()
            Return View(objRole)
        End Function

        <Authorize(Roles:="Administrator")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function AddRole(ByVal paramRole As Role) As ActionResult
            Try

                If paramRole Is Nothing Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                Dim RoleName = paramRole.RoleName.Trim()

                If RoleName = "" Then
                    Throw New Exception("No RoleName")
                End If

                Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))

                If Not roleManager.RoleExists(RoleName) Then
                    roleManager.Create(New IdentityRole(RoleName))
                End If

                Return Redirect("~/Admin/ViewAllRoles")
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Return View("AddRole")
            End Try
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function DeleteUserRole(ByVal RoleName As String) As ActionResult
            Try

                If RoleName Is Nothing Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                If RoleName.ToLower() = "administrator" Then
                    Throw New Exception(String.Format("Cannot delete {0} Role.", RoleName))
                End If

                Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
                Dim UsersInRole = roleManager.FindByName(RoleName).Users.Count()

                If UsersInRole > 0 Then
                    Throw New Exception(String.Format("Canot delete {0} Role because it still has users.", RoleName))
                End If

                Dim objRoleToDelete = (From objRole In roleManager.Roles Where objRole.Name = RoleName Select objRole).FirstOrDefault()

                If objRoleToDelete IsNot Nothing Then
                    roleManager.Delete(objRoleToDelete)
                Else
                    Throw New Exception(String.Format("Cannot delete {0} Role does not exist.", RoleName))
                End If

                Dim colRole As List(Of Role) = (From objRole In roleManager.Roles Select New Role With {
                    .Id = objRole.Id,
                    .RoleName = objRole.Name
                }).ToList()
                Return View("ViewAllRoles", colRole)
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
                Dim colRole As List(Of Role) = (From objRole In roleManager.Roles Select New Role With {
                    .Id = objRole.Id,
                    .RoleName = objRole.Name
                }).ToList()
                Return View("ViewAllRoles", colRole)
            End Try
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function Create() As ActionResult
            Dim objExpandedUser As ExpandedUser = New ExpandedUser()
            ViewBag.Roles = GetAllRolesAsSelectList()
            Return View(objExpandedUser)
        End Function

        <Authorize(Roles:="Administrator")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Create(ByVal paramExpandedUser As ExpandedUser) As ActionResult
            Try

                If paramExpandedUser Is Nothing Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                Dim Email = paramExpandedUser.Email.Trim()
                Dim UserName = paramExpandedUser.Email.Trim()
                Dim Password = paramExpandedUser.Password.Trim()

                If Email = "" Then
                    Throw New Exception("No Email")
                End If

                If Password = "" Then
                    Throw New Exception("No Password")
                End If

                UserName = Email.ToLower()
                Dim objNewAdminUser = New ApplicationUser With {
                    .UserName = UserName,
                    .Email = Email
                }
                Dim AdminUserCreateResult = UserManager.Create(objNewAdminUser, Password)

                If AdminUserCreateResult.Succeeded = True Then
                    Dim strNewRole As String = Convert.ToString(Request.Form("Roles"))

                    If strNewRole <> "0" Then
                        UserManager.AddToRole(objNewAdminUser.Id, strNewRole)
                    End If

                    Return Redirect("~/Admin")
                Else
                    ViewBag.Roles = GetAllRolesAsSelectList()
                    ModelState.AddModelError(String.Empty, "Error: Failed to create the user. Check password requirements.")
                    Return View(paramExpandedUser)
                End If

            Catch ex As Exception
                ViewBag.Roles = GetAllRolesAsSelectList()
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Return View("Create")
            End Try
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function EditUser(ByVal UserName As String) As ActionResult
            If UserName Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim objExpandedUser As ExpandedUser = GetUser(UserName)

            If objExpandedUser Is Nothing Then
                Return HttpNotFound()
            End If

            Return View(objExpandedUser)
        End Function

        <Authorize(Roles:="Administrator")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function EditUser(ByVal paramExpandedUser As ExpandedUser) As ActionResult
            Try

                If paramExpandedUser Is Nothing Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                Dim objExpandedUser As ExpandedUser = UpdateUser(paramExpandedUser)

                If objExpandedUser Is Nothing Then
                    Return HttpNotFound()
                End If

                Return Redirect("~/Admin")
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Return View("EditUser", GetUser(paramExpandedUser.UserName))
            End Try
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function DeleteUser(ByVal UserName As String) As ActionResult
            Try

                If UserName Is Nothing Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                If UserName.ToLower() = Me.User.Identity.Name.ToLower() Then
                    ModelState.AddModelError(String.Empty, "Error: Cannot delete the current user")
                    Return View("EditUser")
                End If

                Dim objExpandedUser As ExpandedUser = GetUser(UserName)

                If objExpandedUser Is Nothing Then
                    Return HttpNotFound()
                Else
                    DeleteUser(objExpandedUser)
                End If

                Return Redirect("~/Admin")
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Return View("EditUser", GetUser(UserName))
            End Try
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function EditRoles(ByVal UserName As String) As ActionResult
            If UserName Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            UserName = UserName.ToLower()
            Dim objExpandedUser As ExpandedUser = GetUser(UserName)

            If objExpandedUser Is Nothing Then
                Return HttpNotFound()
            End If

            Dim objUserAndRoles As UserAndRoles = GetUserAndRoles(UserName)
            Return View(objUserAndRoles)
        End Function

        <Authorize(Roles:="Administrator")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function EditRoles(ByVal paramUserAndRoles As UserAndRoles) As ActionResult
            Try

                If paramUserAndRoles Is Nothing Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                Dim UserName As String = paramUserAndRoles.UserName
                Dim strNewRole As String = Convert.ToString(Request.Form("AddRole"))

                If strNewRole <> "No Roles Found" Then
                    Dim user As ApplicationUser = UserManager.FindByName(UserName)
                    UserManager.AddToRole(user.Id, strNewRole)
                End If

                ViewBag.AddRole = New SelectList(RolesUserIsNotIn(UserName))
                Dim objUserAndRoles As UserAndRoles = GetUserAndRoles(UserName)
                Return View(objUserAndRoles)
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                Return View("EditRoles")
            End Try
        End Function

        <Authorize(Roles:="Administrator")>
        Public Function DeleteRole(ByVal UserName As String, ByVal RoleName As String) As ActionResult
            Try

                If (UserName Is Nothing) OrElse (RoleName Is Nothing) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                UserName = UserName.ToLower()
                Dim objExpandedUser As ExpandedUser = GetUser(UserName)

                If objExpandedUser Is Nothing Then
                    Return HttpNotFound()
                End If

                If UserName.ToLower() = Me.User.Identity.Name.ToLower() AndAlso RoleName = "Administrator" Then
                    ModelState.AddModelError(String.Empty, "Error: Cannot delete Administrator Role for the current user")
                End If

                Dim user As ApplicationUser = UserManager.FindByName(UserName)
                UserManager.RemoveFromRoles(user.Id, RoleName)
                UserManager.Update(user)
                ViewBag.AddRole = New SelectList(RolesUserIsNotIn(UserName))
                Return RedirectToAction("EditRoles", New With {.UserName = UserName})
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Error: " & ex.Message)
                ViewBag.AddRole = New SelectList(RolesUserIsNotIn(UserName))
                Dim objUserAndRoles As UserAndRoles = GetUserAndRoles(UserName)
                Return View("EditRoles", objUserAndRoles)
            End Try
        End Function
    End Class
End Namespace
