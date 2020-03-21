@ModelType MeishiWeb.MeishiWeb.Models.CardInfoView

@Code
	Layout = Nothing

End Code





@Using Html.BeginForm("SaveLeft", "Save", FormMethod.Post)

    @<text>

        <div Class="modal-header">
            <Button type="button" Class="close" data-dismiss="modal" aria-hidden="true">&times;</Button>
            <h4 Class="modal-title" id="myModalLabel" style="color: black;">Edit @Model.CardInfoViews.DisplayName</h4>
        </div>


        <div Class="modal-body">


            <div class="form-horizontal">
                <div class="form-group">
                    @Html.HiddenFor(Function(model) model.CardInfoViews.DetailID)
                    @Html.HiddenFor(Function(model) model.CardInfoViews.CardID)
                    @Html.HiddenFor(Function(model) model.CardInfoViews.CompanyID)
                    @Html.LabelFor(Function(model) model.CardInfoViews.Introduction, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "color: Black;"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.CardInfoViews.Introduction, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.CardInfoViews.Introduction, "", New With {.class = "text-danger"})
                    </div>
                </div>


               



                <div class="form-group">
                    @Html.LabelFor(Function(model) model.CardInfoViews.JobTitle, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "color: Black;"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.CardInfoViews.JobTitle, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.CardInfoViews.JobTitle, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div Class="form-group">
                    <div Class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Save" Class="btn btn-default" style="color: Black" />
                    </div>
                </div>
            </div>



        </div>






        <div Class="modal-footer">

            <Button Class="btn" type="button" data-dismiss="modal" style="color: Black">Close</Button>

        </div>
        


    </text>

End Using





