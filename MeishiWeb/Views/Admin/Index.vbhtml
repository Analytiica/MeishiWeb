@ModelType PagedList.IPagedList(Of MeishiWeb.MeishiWeb.Models.ExpandedUser)

<link href="~Content/PageList.css" rel="stylesheet" type="text/css" />

@Code
	ViewData("Title") = "Index"
End Code

<br />
<p>
	@Html.ActionLink("Create New", "Create", Nothing, New With {.class = "btn btn-default"})
	@Html.ActionLink("Edit Roles", "ViewAllRoles", Nothing, New With {.class = "btn btn-default"})
	@Html.ActionLink("Back to Home", "../", "Home", Nothing, New With {.class = "btn btn-default"})

</p>
<br />

@Using (Html.BeginForm("Index", "Admin", FormMethod.Get))

	@<text>
		<div class="form-group">
			Search:&nbsp; @Html.TextBox("searchStringUserNameofEmail", CType(ViewBag.CurrentFilter, String))

			<input type = "submit" value="Search" />
		</div>
	</text>


End Using
<br />

<table class="table">
	<tr>
		<th>
			Email
		</th>
		<th>
			Roles
		</th>
		<th></th>
	</tr>

	@For Each item In Model

		@<text>

			<tr>
				<td>
					@Html.DisplayFor(Function(modelItem) item.Email)
				</td>
				<td>
					@Html.DisplayFor(Function(modelItem) item.Role)
				</td>
				<td>
					@Html.ActionLink("Edit", "EditUser", New With {.UserName = item.UserName}) |

					@If item.UserName.ToLower() <> User.Identity.Name.ToLower() Then

					@Html.ActionLink("Delete", "DeleteUser", New With {.Username = item.UserName}, New With {.onclick = "return confirm('Are you sure you wish to delete this user?');"})

					End If
				</td>
			</tr>

		</text>


	Next

</table>

