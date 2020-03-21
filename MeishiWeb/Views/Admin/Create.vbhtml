@ModelType MeishiWeb.MeishiWeb.Models.ExpandedUser

@Code
	ViewData("Title") = "Create"
End Code

@Using Html.BeginForm()

@Html.AntiForgeryToken()

@<text>

	<div class="form-horizontal">
		<h4> Create User</h4>
		<hr />
			@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

		<div class="form-group">
			@Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
			<div class=" = col-md-10">
				@Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div class="form-group">
			@Html.LabelFor(Function(model) model.Password, htmlAttributes:=New With {.class = "control-label col-md-2"})
			<div class=" = col-md-10">
				@Html.EditorFor(Function(model) model.Password, New With {.htmlAttributes = New With {.class = "form-control"}})
				@Html.ValidationMessageFor(Function(model) model.Password, "", New With {.class = "text-danger"})
			</div>
		</div>

		<div class="form-group">
			@Html.LabelFor(Function(model) model.Password, htmlAttributes:=New With {.class = "control-label col-md-2"})
			<div class=" = col-md-10">
				@Html.DropDownList("Roles")
			</div>
		</div>

		<div class="form-group">
			<div class=" = col-md-offset-2 col-md-10">
				<input type = "submit" value="Save" class="btn btn-default" />
				@Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
			</div>
		</div>

	</div>
</text>
End Using

