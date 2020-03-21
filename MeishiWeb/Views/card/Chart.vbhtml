@ModelType MeishiWeb.MeishiWeb.Models.CardInfoView
@Code
    ViewData("Title") = "Chart"
End Code

<h2>Chart</h2>

<html>
<head>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart(@Model.CardInfoViews.CompanyID);

        function drawChart(x1) {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['x1', 11],
                ['Nap', 2],
                ['Eat', 2],
                ['Watch TV', 2],
                ['Sleep', 7]
            ]);

            var options = {
                title: 'My Daily Activities'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }
    </script>
</head>
<body>
    <div id="piechart" style="width: 900px; height: 500px;"></div>
</body>
</html>