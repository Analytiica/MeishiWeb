@ModelType MeishiWeb.MeishiWeb.Models.CardInfoView

@Code
	ViewData("Title") = "Edit Links"
End Code

<h2>EditLinks</h2>

@Using Html.BeginForm("EditLinks", "Agent", New With {.id = Model.CardInfoViews.DetailID, .company = Model.CardInfoViews.CompanyID})

    @Html.AntiForgeryToken

    @<text>



        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName1, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title1, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName1, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName1, "", New With {.class = "text-danger"})

                        </div>
         </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName2, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title2, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName2, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName2, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName3, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title3, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName3, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName3, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName4, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title4, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName4, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName4, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName5, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title5, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName5, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName5, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName6, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title6, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName6, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName6, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName7, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title7, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName7, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName7, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName8, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title8, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName8, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName8, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName9, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title9, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName9, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName9, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName10, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            <div Class="form-inline">
                                @Html.EditorFor(Function(model) model.LinkInfoViews.Title10, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                            </div>
                                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName10, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName10, "", New With {.class = "text-danger"})
                        </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName11, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                <div Class="form-inline">
                    @Html.EditorFor(Function(model) model.LinkInfoViews.Title11, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                </div>
                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName11, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName11, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName12, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                <div Class="form-inline">
                    @Html.EditorFor(Function(model) model.LinkInfoViews.Title12, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                </div>
                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName12, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName12, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName13, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                <div Class="form-inline">
                    @Html.EditorFor(Function(model) model.LinkInfoViews.Title13, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                </div>
                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName13, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName13, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName14, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                <div Class="form-inline">
                    @Html.EditorFor(Function(model) model.LinkInfoViews.Title14, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                </div>
                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName14, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName14, "", New With {.class = "text-danger"})
            </div>
        </div>

        @*<div Class="form-group">

            @Html.LabelFor(Function(model) model.LinkInfoViews.LinkName15, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                <div Class="form-inline">
                    @Html.EditorFor(Function(model) model.LinkInfoViews.Title15, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Title for Link"}})
                </div>
                @Html.EditorFor(Function(model) model.LinkInfoViews.LinkName15, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.LinkInfoViews.LinkName15, "", New With {.class = "text-danger"})
            </div>
        </div>*@

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.CardInfoViews.CompanyBot, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                
                @Html.EditorFor(Function(model) model.CardInfoViews.CompanyBot, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.CardInfoViews.CompanyBot, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">

            @Html.LabelFor(Function(model) model.CardInfoViews.PersonBot, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                
                @Html.EditorFor(Function(model) model.CardInfoViews.PersonBot, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.CardInfoViews.PersonBot, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" class="btn btn-default" />
                @*@Html.ActionLink("Update", "EditLinks", "Agent", New With {.id = Model.CardInfoViews.DetailID, .company = Model.CardInfoViews.CompanyID}, New With {.class = "btn btn-default", .method = "Post"})*@
            </div>
        </div>
</text>



End Using