@ModelType MeishiWeb.MeishiWeb.Models.ChartView

@Code
	Layout = Nothing

End Code



    <html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta http-equiv="x-ua-compatible" content="ie=edge">

        <title>Analytics | Dashboard</title>

       
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <link rel="stylesheet" href="https://developers.google.com/chart/interactive/css/carousel_style.css">
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/all.css">
        <link rel="stylesheet" href="/Views/chart/styles/adminlte.min.css">
        <!-- Google Font: Source Sans Pro -->
        <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
        <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);




        function drawChart() {

            var allprofiles = [@Html.Raw(Json.Encode(Model.AllProfiles))][0];
            var profilecount = [@Html.Raw(Json.Encode(Model.ProfileCount))][0];
            var profile = new google.visualization.DataTable();
                profile.addColumn('string', 'Profile');
                profile.addColumn('number', 'type');
			for (i = 0; i < allprofiles.length; i++) {
            	    profile.addRow([allprofiles[i], profilecount[i]]);
			}


			var rDate = [@Html.Raw(Json.Encode(Model.rDate))][0];
			var rPrf = [@Html.Raw(Json.Encode(Model.rPrf))][0];
			var rSrv = [@Html.Raw(Json.Encode(Model.rSrv))][0];
			var activity = new google.visualization.DataTable();
              activity.addColumn('string', 'Date');
              activity.addColumn('number', 'Profile');
              activity.addColumn('number', 'Services');
			for (i = 0; i < rDate.length; i++) {

				activity.addRow([rDate[i], rPrf[i], rSrv[i]]);
			}




            var allservices = [@Html.Raw(Json.Encode(Model.AllServices))][0];
            var servicescount = [@Html.Raw(Json.Encode(Model.ServiceCount))][0];
			var services = new google.visualization.DataTable()
				services.addColumn('string', 'Services');
				services.addColumn('number', 'type');
            for (i = 0; i < allservices.length; i++) {
            	    services.addRow([allservices[i], servicescount[i]]);
			}

            var optionsprofile = {
				title: 'Profile',
				pieHole: 0.4,
                height: 400,
			};

			var optionsservice = {
				title: 'Services',
				pieHole: 0.4,
				height: 400,

			};

            var optionsactivity = {
				legend:  {
                    position: 'top'
                },
                title: 'Activities'
            };

            var ProfileChart = new google.visualization.PieChart(document.getElementById('profilepiechart'));
			var ActivityChart = new google.visualization.ColumnChart(document.getElementById('linechart'));
				var ServicesChart = new google.visualization.PieChart(document.getElementById('servicespiechart'));

				ProfileChart.draw(profile, optionsprofile);
            ActivityChart.draw(activity, optionsactivity);
            ServicesChart.draw(services, optionsservice);
        }
        </script>


        <!-- Font Awesome Icons -->




    </head>
    @Using Html.BeginForm("Export", "chart", FormMethod.Post)

        @<text>
            <body>
                <div>
                    <div>
                        <div Class="content-header">
                            <div Class="container-fluid">
                                <div Class="row mb-2">
                                    <div Class="col-sm-6">
                                        <h1 Class="m-0 text-dark">Analytics for @Model.DisplayName For @Model.CurrentMonth </h1>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <section Class="content">
                            <div Class="container-fluid">
                                <!-- Info boxes -->
                                <div Class="row">
                                    <div Class="col-md-12">
                                        <div Class="card">
                                            <div Class="card-header">

                                                <h5 Class="card-title">Your information</h5>

                                            </div>

                                            <div Class="card-body">
                                                <div Class="row">
                                                    <div Class="col-md-6">

                                                        <img Class="img-fluid" height="254" width="254" src="@String.Format("{0}/profilepictures/{1}.png", Model.ProfilePic, Model.DetailID)" />

                                                    </div>
                                                    <div Class="col-md-6">
                                                        <h1> @Model.DisplayName Details</h1>

                                                        <address>
                                                            Email <a href="mailto:@Model.email">@Model.email</a>.<br>
                                                            City: @Model.AddressLine<br>
                                                            Province: @Model.Province<br>
                                                            Country: @Model.Country<br>
                                                            Cell: @Model.MobileNumber
                                                        </address>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div Class="row">
                                    <div Class="col-12 col-sm-6 col-md-2">
                                        <div Class="info-box">
                                            <Span Class="info-box-icon bg-blue elevation-1"><i class="fab fa-facebook"></i></Span>

                                            <div Class="info-box-content">
                                                <Span Class="info-box-text">Facebook Clicks</Span>
                                                <Span Class="info-box-number">@Model.ProfileCount(0)</Span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <div Class="col-12 col-sm-6 col-md-2">
                                        <div Class="info-box mb-3">
                                            <Span Class="info-box-icon bg-gradient-blue elevation-1"><i class="fab fa-linkedin"></i></Span>

                                            <div Class="info-box-content">
                                                <Span Class="info-box-text">LinkedIn CLicks</Span>
                                                <Span Class="info-box-number">@Model.ProfileCount(7)</Span>
                                            </div>
                                            <!-- /.info-box-content -->
                                        </div>
                                        <!-- /.info-box -->
                                    </div>
                                    <!-- /.col -->
                                    <!-- fix for small devices only -->
                                    <div Class="clearfix hidden-md-up"></div>

                                    <div Class="col-12 col-sm-6 col-md-2">
                                        <div Class="info-box mb-3">
                                            <Span Class="info-box-icon bg-gradient-blue elevation-1"><i class="fab fa-instagram"></i></Span>

                                            <div Class="info-box-content">
                                                <Span Class="info-box-text">Instagram Clicks</Span>
                                                <Span Class="info-box-number">@Model.ProfileCount(9)</Span>
                                            </div>

                                        </div>

                                    </div>
                                    <!-- /.col -->
                                    <div Class="col-12 col-sm-6 col-md-2">
                                        <div Class="info-box mb-3">
                                            <Span Class="info-box-icon bg-red elevation-1"><i class="fab fa-youtube"></i></Span>

                                            <div Class="info-box-content">
                                                <Span Class="info-box-text">YouTube Clicks</Span>
                                                <Span Class="info-box-number">@Model.ProfileCount(10)</Span>
                                            </div>

                                        </div>

                                    </div>

                                    <div Class="col-12 col-sm-6 col-md-2">
                                        <div Class="info-box mb-3">
                                            <Span Class="info-box-icon bg-lightblue elevation-1"><i class="fab fa-twitter"></i></Span>

                                            <div Class="info-box-content">
                                                <Span Class="info-box-text">Twitter Clicks</Span>
                                                <Span Class="info-box-number">@Model.ProfileCount(8)</Span>
                                            </div>

                                        </div>

                                    </div>
                                    <div Class="col-12 col-sm-6 col-md-2">
                                        <div Class="info-box mb-3">
                                            <Span Class="info-box-icon bg-black elevation-1"><i class="fas fa-link"></i></Span>

                                            <div Class="info-box-content">
                                                <Span Class="info-box-text">Weblink Clicks</Span>
                                                <Span Class="info-box-number">@Model.ProfileCount(6)</Span>
                                            </div>

                                        </div>

                                    </div>
                                </div>

                                <div Class="row">
                                    <div Class="col-md-12">
                                        <div Class="card">
                                            <div Class="card-header">
                                                <h5 Class="card-title">Monthly Overview</h5>


                                            </div>

                                            <div Class="col-md-12 card-body">
                                                <div Class="row">
                                                    <div Class="col-md-6">
                                                        <p Class="text-center">
                                                            <strong> Overview Of Profile</strong>
                                                        </p>

                                                        <div id="profilepiechart" Class="col-md-12"></div>

                                                    </div>
                                                    <div Class="col-md-6">
                                                        <p Class="text-center">
                                                            <strong> Overview Of Services</strong>
                                                        </p>

                                                        <div id="servicespiechart" Class="col-md-12"></div>

                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                        <!-- /.card -->
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <div Class="row">
                                    <div Class="col-md-12">
                                        <div Class="card">
                                            <div Class="card-header">
                                                <h5 Class="card-title">Monthly Interaction Report</h5>


                                            </div>

                                            <div Class="col-md-12 card-body">
                                                <div Class="row">
                                                    <div Class="col-md-12">
                                                        <p Class="text-center">
                                                            <strong> Interactions For @Model.CurrentMonth</strong>
                                                        </p>

                                                        <div id="linechart"></div>

                                                    </div>

                                                </div>

                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </div>
                           
                        </section>

                    </div>

                </div>


            </body>
</text>
	End Using
        </html>
