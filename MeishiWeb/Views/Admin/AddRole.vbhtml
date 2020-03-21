@ModelType MeishiWeb.MeishiWeb.Models.Role

@Code
	ViewData("Title") = "AddRole"
End Code

@Using Html.BeginForm()

@Html.AntiForgeryToken()

@<text>
	<div class="form-horizontal">
<h4> Create Role</h4>
<hr />
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})
		<div class="form-group">
			@Html.LabelFor(Function(model) model.RoleName, htmlAttributes:=New With {.Class = "control-label col-md-2"})
			<div class="col-md-10">
				@Html.EditorFor(Function(model) model.RoleName, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(model) model.RoleName, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<input type = "submit" value="Save" class="btn btn-default" />
					@Html.ActionLink("Back to List", "ViewAllRoles", Nothing, New With {.class = "btn btn-default"})
			</div>
		</div>

	</div>
</text>
End Using


