@ModelType IEnumerable(Of MeishiWeb.MeishiWeb.Models.Role)

@Code
	ViewData("Title") = "ViewAllRoles"
End Code

<br />
@Html.ValidationSummary(True, "", New With {.class = "text-danger"})
<p>
	@Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
	@Html.ActionLink("Add Role", "AddRole", Nothing, New With {.class = "btn btn-default"})
</p>
<table class="table">
	<tr>
		<th>Role</th>
		<th></th>
	</tr>
	@for Each item In Model
		@<text>
			<tr>
				<td>
					@Html.DisplayFor(Function(modelItem) item.RoleName)
				</td>
				<td>
					@if item.RoleName.ToLower() <> "administrator" Then
						@Html.ActionLink("Delete", "DeleteUserRole", New With {.RoleName = item.RoleName}, New With {.onclick = "return confirm('Are you sure you wish to delete this role?');"})
					End If
				</td>
			</tr>
		</text>
	Next
	 </table>

