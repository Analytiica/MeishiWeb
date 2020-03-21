@ModelType MeishiWeb.MeishiWeb.Models.UserAndRoles

@Code
	ViewData("Title") = "EditRoles"
End Code

@Using Html.BeginForm()

@Html.AntiForgeryToken()

@<text>
	<br />
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

	<div>
		@Html.ActionLink("Back", "EditUser", New With {.UserName = Model.UserName}, New With {.class = "btn btn-default"})
		<input type = "submit" value="Add Role" class="btn btn-default" />
		@Html.DropDownList("AddRole")
	</div>
	<br />
	<table class="table">
		<tr>
			<th>
				Existing Roles:
			</th>
			<th></th>
		</tr>

			@For Each item In Model.colUserRole
				@<text>
					<tr>
						<td>
							@Html.DisplayFor(Function(modelItem) item.RoleName)
						</td>
						<td>
							@If Not ((Model.UserName.ToLower() = User.Identity.Name.ToLower()) AndAlso item.RoleName = "Administrator") AndAlso item.RoleName <> "No Roles Found" Then
								@Html.ActionLink("Delete", "DeleteRole", New With {.UserName = item.UserName, .RoleName = item.RoleName}, New With {.onclick = "return confirm('Are you sure you wish to delete this role?');"})
							End If
						</td>
					</tr>
				</text>
			Next
	</table>
</text>
End Using
