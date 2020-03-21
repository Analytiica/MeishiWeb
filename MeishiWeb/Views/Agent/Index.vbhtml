@ModelType IEnumerable(Of MeishiWeb.MeishiWeb.CardInfo)


@*@Html.Partial("_CardView", Model.CardViews)
    @Html.Partial("_LinkView", Model.LinkViews)*@


@Code
	ViewData("Title") = "Index"


End Code



<!DOCTYPE html>

<html>

<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

</head>
<body>

    <h2>Customer List</h2>

    <p>
        @Html.ActionLink("Create New", "Create", "Agent")

    </p>
    <table class="table">
        <tr>

            <th>
                @Html.DisplayNameFor(Function(model) model.CompanyName)
            </th>

            <th>
                @Html.DisplayNameFor(Function(model) model.FirstName)
            </th>

            <th>
                @Html.DisplayNameFor(Function(model) model.LastName)
            </th>

            <th>
                @Html.DisplayNameFor(Function(model) model.email)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.AgentName)
            </th>

            <th></th>
        </tr>

        @For Each item In Model
            @<tr>

                <td>
                    @Html.DisplayFor(Function(modelItem) item.CompanyName)
                </td>

                <td>
                    @Html.DisplayFor(Function(modelItem) item.FirstName)
                </td>

                <td>
                    @Html.DisplayFor(Function(modelItem) item.LastName)
                </td>

                <td>
                    @Html.DisplayFor(Function(modelItem) item.email)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.AgentName)
                </td>

                <td>
                    @Html.ActionLink("Edit", "Edit", New With {.controller = "card", .id = item.DetailID, .company = item.CompanyID})
                    @Html.ActionLink("View", Nothing, New With {.controller = "card", .id = item.DetailID, .company = item.CompanyID})
                    @If User.IsInRole("Administrator") Then
                        @Html.ActionLink("Delete", "Delete", New With {.controller = "card", .id = item.DetailID, .company = item.CompanyID}, New With {.onClick = "return confirm('Are you sure you wish to delete this card?');"})
                        @Html.ActionLink(" Edit Links", "EditLinks", New With {.controller = "Agent", .id = item.DetailID, .company = item.CompanyID})
                        @Html.ActionLink("Send Analytics", "Deploy", "chart", New With {.email = item.email}, Nothing)



					End If


                </td>
            </tr>
		Next




    </table>



</body>
</html>





