@ModelType MeishiWeb.MeishiWeb.Models.ExpandedUser

@Code
	ViewData("Title") = "EditUser"
End Code


@Using Html.BeginForm()


@Html.AntiForgeryToken()
@<text>

	<div Class="form-horizontal">
	<h4> Edit User</h4>
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

		<div Class="form-group">
			@Html.LabelFor(Function(model) model.UserName, htmlAttributes:=New With {.class = "control-label col-md-2"})

			<div Class="col-md-10">
				@Html.DisplayFor(Function(model) model.UserName, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(model) model.UserName, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div Class="form-group">
			@Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})

			<div Class="col-md-10">
				@Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div Class="form-group">
			@Html.LabelFor(Function(Model) Model.Password, htmlAttributes:=New With {.Class = "control-label col-md-2"})

			<div Class="col-md-10">
				@Html.PasswordFor(Function(Model) Model.Password, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(Model) Model.Password, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div Class="form-group">
			@Html.LabelFor(Function(Model) Model.LockoutEndDateUTC, htmlAttributes:=New With {.Class = "control-label col-md-2"})

			<div Class="col-md-10">
				@Html.DisplayFor(Function(Model) Model.LockoutEndDateUTC, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(Model) Model.LockoutEndDateUTC, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div Class="form-group">
			<div Class="col-md-offset-2 col-md-10">
				<input type = "submit" value="Save" Class="btn btn-default" />
					@Html.ActionLink("Edit Roles", "EditRoles", New With {.UserName = Model.UserName}, New With {.class = "btn btn-default"})
					@Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
			</div>
		</div>
	</div>

</text>
End Using
