using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GeneralInsuranceManagement.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        #region alerts
        protected void RedAlert(string MsgFlg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Error!', '" + MsgFlg + "', 'error');", true);

        }

        protected void WarningAlert(string MsgFlg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Warning!', '" + MsgFlg + "', 'warning');", true);

        }

        protected void SuccessAlert(string MsgFlg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Success!', '" + MsgFlg + "', 'success');", true);

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) 
            {
                getDashboardStats();
                getDatatable();
            }
        }

        private void getDashboardStats()
        {
            Models.Dashboard.Dashboard dashboard = new Models.Dashboard.Dashboard("cn", 1);
            DataSet dataSet = dashboard.GetStats();

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                int year = Convert.ToInt32(row["year"]);
                decimal maleNet = Convert.ToDecimal(row["malenet"]);
                decimal femaleNet = Convert.ToDecimal(row["femalenet"]);
                int maleCount = Convert.ToInt32(row["male_count"]);
                int femaleCount = Convert.ToInt32(row["female_count"]);

                lblMaleNet.Text = maleNet.ToString();
                lblFemaleNet.Text = femaleNet.ToString();
                lblMaleCount.Text = maleCount.ToString();
                lblFemaleCount.Text = femaleCount.ToString();


            }
            else
            {
                WarningAlert("No Data to Display");
            }

            DataSet newdataSet = dashboard.GetNewStats();

            if (newdataSet != null && newdataSet.Tables.Count > 0 && newdataSet.Tables[0].Rows.Count > 0)
            {
                // Prepare lists to store data
                List<string> months = new List<string>();
                List<decimal> monthlySalaries = new List<decimal>();
                List<decimal> netSalaries = new List<decimal>();
                List<int> memberCounts = new List<int>();

                // Populate lists with data from DataSet
                foreach (DataRow row in newdataSet.Tables[0].Rows)
                {
                    months.Add(row["Month"].ToString());
                    monthlySalaries.Add(Convert.ToDecimal(row["TotalMonthlySalary"]));
                    netSalaries.Add(Convert.ToDecimal(row["TotalNetSalary"]));
                    memberCounts.Add(Convert.ToInt32(row["member_count"]));
                }

                // Create a JavaScript block to generate the chart
                string script = @"
    <script src='https://cdn.amcharts.com/lib/4/core.js'></script>
    <script src='https://cdn.amcharts.com/lib/4/charts.js'></script>
    <script src='https://cdn.amcharts.com/lib/4/themes/animated.js'></script>
    <script>
        // Wait for the document to be fully loaded
        am4core.ready(function() {
            am4core.useTheme(am4themes_animated);
        
            // Create a new Radar Chart instance
            var chart = am4core.create('chartdiv4', am4charts.XYChart);
            chart.hiddenState.properties.opacity = 0; // Hide chart initially

            chart.colors.step = 2;
            chart.maskBullets = false;

            // Add and configure data
            chart.data = [
                " + GenerateChartData(months, monthlySalaries, netSalaries, memberCounts) + @"
            ];

            // Create axes
            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = 'month';
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 50;
            categoryAxis.renderer.grid.template.disabled = true;
            categoryAxis.renderer.fullWidthTooltip = true;

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.renderer.minGridDistance = 50;
            valueAxis.title.text = 'Valuation';
            valueAxis.renderer.grid.template.disabled = true;

            var memberAxis = chart.yAxes.push(new am4charts.ValueAxis());
            memberAxis.title.text = 'Number of Members';
            memberAxis.renderer.opposite = true;
            memberAxis.syncWithAxis = valueAxis;
            memberAxis.renderer.grid.template.disabled = true;

            // Create 'Monthly Salary' series
            var seriesMonthlySalary = chart.series.push(new am4charts.ColumnSeries());
            seriesMonthlySalary.dataFields.valueY = 'monthlySalary';
            seriesMonthlySalary.dataFields.categoryX = 'month';
            seriesMonthlySalary.name = 'Basic Salary';
            seriesMonthlySalary.columns.template.fillOpacity = 0.7;
            seriesMonthlySalary.columns.template.propertyFields.strokeDasharray = 'dashLength';
            seriesMonthlySalary.columns.template.propertyFields.fillOpacity = 'alpha';
            seriesMonthlySalary.showOnInit = true;
            seriesMonthlySalary.tooltipText = 'Basic Salary: \n{font-weight:bold}${valueY}';
            seriesMonthlySalary.columns.template.fill = am4core.color('#13afb2');

            // Customize tooltip appearance for seriesMonthlySalary
            seriesMonthlySalary.tooltip.getFillFromObject = false;
            seriesMonthlySalary.tooltip.background.fill = am4core.color('#13afb2').lighten(0.2); // Change tooltip background color
            seriesMonthlySalary.tooltip.background.fillOpacity = 0.5;
            seriesMonthlySalary.tooltip.background.stroke = am4core.color('#13afb2'); // Change tooltip border color
            seriesMonthlySalary.tooltip.label.fill = am4core.color('#000000'); // Change tooltip text color

            var monthlySalaryState = seriesMonthlySalary.columns.template.states.create('hover');
            monthlySalaryState.properties.fillOpacity = 0.9;

            // Create 'Net Salary' series
            var seriesNetSalary = chart.series.push(new am4charts.LineSeries());
            seriesNetSalary.dataFields.valueY = 'netSalary';
            seriesNetSalary.dataFields.categoryX = 'month';
            seriesNetSalary.name = 'Net Salary';
            seriesNetSalary.strokeWidth = 2;
            seriesNetSalary.propertyFields.strokeDasharray = 'dashLength';
            seriesNetSalary.tooltipText = 'Net Salary: \n${valueY}';
            seriesNetSalary.showOnInit = true;
            seriesNetSalary.stroke = am4core.color('#44495b');

            // Customize tooltip appearance for seriesMonthlySalary
            seriesNetSalary.tooltip.getFillFromObject = false;
            seriesNetSalary.tooltip.background.fill = am4core.color('#44495b').lighten(0.2); // Change tooltip background color
            seriesNetSalary.tooltip.background.fillOpacity = 0.5;
            seriesNetSalary.tooltip.background.stroke = am4core.color('#44495b'); // Change tooltip border color
            seriesNetSalary.tooltip.label.fill = am4core.color('#000000'); // Change tooltip text color

            // Set tension for curved lines
            seriesNetSalary.tensionX = 0.6; // Adjust the tension as needed for the desired curve
            seriesNetSalary.tensionY = 1; // Adjust the tension as needed for the desired curve

            var NetSalaryBullet = seriesNetSalary.bullets.push(new am4charts.CircleBullet());
            NetSalaryBullet.circle.fill = am4core.color('#fff');
            NetSalaryBullet.circle.strokeWidth = 2;

            var NetSalaryState = NetSalaryBullet.states.create('hover');
            NetSalaryState.properties.scale = 1.2;

            var NetSalaryLabel = seriesNetSalary.bullets.push(new am4charts.LabelBullet());
            NetSalaryLabel.label.horizontalCenter = 'left';
            NetSalaryLabel.label.dx = 14;

            // Create 'Member Count' series
            var seriesMemberCount = chart.series.push(new am4charts.LineSeries());
            seriesMemberCount.dataFields.valueY = 'memberCount';
            seriesMemberCount.dataFields.categoryX = 'month';
            seriesMemberCount.yAxis = memberAxis;
            seriesMemberCount.name = 'Number of Members';
            seriesMemberCount.strokeWidth = 2;
            seriesMemberCount.propertyFields.strokeDasharray = 'dashLength';
            seriesMemberCount.tooltipText = 'Number of Members: \n{valueY}';
            seriesMemberCount.showOnInit = true;
            seriesMemberCount.stroke = am4core.color('#fe7383');

            // Customize tooltip appearance for seriesMonthlySalary
            seriesMemberCount.tooltip.getFillFromObject = false;
            seriesMemberCount.tooltip.background.fill = am4core.color('#fe7383').lighten(0.2); // Change tooltip background color
            seriesMemberCount.tooltip.background.fillOpacity = 0.5;
            seriesMemberCount.tooltip.background.stroke = am4core.color('#fe7383'); // Change tooltip border color
            seriesMemberCount.tooltip.label.fill = am4core.color('#000000'); // Change tooltip text color

            // Configure broken line
            seriesMemberCount.strokeDasharray = '5, 5';

            seriesMemberCount.tensionX = 0.6; // Adjust the tension as needed for the desired curve
            seriesMemberCount.tensionY = 1; // Adjust the tension as needed for the desired curve

            var memberCountBullet = seriesMemberCount.bullets.push(new am4charts.CircleBullet());
            memberCountBullet.circle.fill = am4core.color('#fff');
            memberCountBullet.circle.strokeWidth = 2;

            var memberCountState = memberCountBullet.states.create('hover');
            memberCountState.properties.scale = 1.2;

            var memberCountLabel = seriesMemberCount.bullets.push(new am4charts.LabelBullet());
            memberCountLabel.label.horizontalCenter = 'left';
            memberCountLabel.label.dx = 14;

var totalLength;

// Event listener for when the chart is ready
chart.events.on(""ready"", function() {
    // Calculate the total length of the line series
    totalLength = seriesMemberCount.segments.getIndex(0).element.getTotalLength(); // Get total length of the first segment
    
    // Apply animation to the line series
    seriesMemberCount.segments.template.animate({ property: ""strokeDasharray"", to: totalLength + "", "" + totalLength }, 1000); // Adjust the duration as needed
});

            // Add a legend
            chart.legend = new am4charts.Legend();

            // Add cursor
            chart.cursor = new am4charts.XYCursor();
            chart.cursor.fullWidthLineX = true;
            chart.cursor.xAxis = categoryAxis;
            chart.cursor.lineX.strokeOpacity = 0;
            chart.cursor.lineX.fill = am4core.color('#000');
            chart.cursor.lineX.fillOpacity = 0.1;

            // Add scrollbar
            //chart.scrollbarX = new am4core.Scrollbar();

            chart.logo.disabled = true;

// Create a new Chart2 instance
var chart = am4core.create('chartdiv5', am4charts.RadarChart);
chart.hiddenState.properties.opacity = 0; // Hide chart initially

// Add and configure data
chart.data = [
                " + GenerateChartData(months, monthlySalaries, netSalaries, memberCounts) + @"
            ];

// Create axes
var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = 'month';

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.extraMin = 0.2;
valueAxis.extraMax = 0.2;
valueAxis.tooltip.disabled = true;

// Create 'Member Contributions' series
var seriesMemberPortion = chart.series.push(new am4charts.RadarSeries());
seriesMemberPortion.dataFields.valueY = 'monthlySalary'; // Assuming 'memberportion' is the data you want to visualize
seriesMemberPortion.dataFields.categoryX = 'month';
seriesMemberPortion.name = 'Basic Salary'; // Name for the series
seriesMemberPortion.strokeWidth = 2;
//seriesMemberPortion.bullets.create(am4charts.CircleBullet);
seriesMemberPortion.dataItems.template.locations.categoryX = 0.5;
seriesMemberPortion.tooltipText = 'Basic Salary: {valueY}';

// Create 'Employer Contributions' series
var seriesPreservationFund = chart.series.push(new am4charts.RadarSeries());
seriesPreservationFund.dataFields.valueY = 'netSalary'; // Assuming 'preservation_fund' is the data for Preservation Fund
seriesPreservationFund.dataFields.categoryX = 'month';
seriesPreservationFund.name = 'Net Salary'; // Name for the series
seriesPreservationFund.strokeWidth = 2;
//seriesPreservationFund.bullets.create(am4charts.CircleBullet);
seriesPreservationFund.dataItems.template.locations.categoryX = 0.5;
seriesPreservationFund.tooltipText = 'Net Salary: {valueY}';


// Create 'Lumpsum' series
var seriesLumpsum = chart.series.push(new am4charts.RadarSeries());
seriesLumpsum.dataFields.valueY = 'memberCount'; // Assuming 'memberportion' is the data you want to visualize
seriesLumpsum.dataFields.categoryX = 'month';
seriesLumpsum.name = 'Number of Members'; // Name for the series
seriesLumpsum.strokeWidth = 2;
//seriesPreservationFund.bullets.create(am4charts.CircleBullet);
seriesPreservationFund.dataItems.template.locations.categoryX = 0.5;
seriesLumpsum.tooltipText = 'Number of Members: {valueY}';

// Add a legend
chart.legend = new am4charts.Legend();

// Add cursor
chart.cursor = new am4charts.RadarCursor();

// Add scrollbar
//chart.scrollbarX = new am4core.Scrollbar();
//chart.scrollbarY = new am4core.Scrollbar();

chart.logo.disabled = true;

// Create a new Chart3 instance
            var chart = am4core.create('chartdiv6', am4charts.XYChart);
            chart.hiddenState.properties.opacity = 0; // Hide chart initially

            chart.colors.step = 2;
            chart.maskBullets = false;

            // Add and configure data
            chart.data = [
                " + GenerateChartData(months, monthlySalaries, netSalaries, memberCounts) + @"
            ];

            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = 'month';
categoryAxis.renderer.grid.template.location = 0;
categoryAxis.renderer.minGridDistance = 30;
categoryAxis.renderer.grid.template.disabled = true;
categoryAxis.renderer.fullWidthTooltip = true;
categoryAxis.renderer.labels.template.disabled = true;

// Hide x-axis base line
categoryAxis.renderer.line.disabled = true;
            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.renderer.minGridDistance = 50;
            //valueAxis.title.text = 'Valuation';
            valueAxis.renderer.labels.template.disabled = true;
            valueAxis.renderer.grid.template.disabled = true;

            var memberAxis = chart.yAxes.push(new am4charts.ValueAxis());
            //memberAxis.title.text = 'Number of Members';
            memberAxis.renderer.opposite = true;
            memberAxis.syncWithAxis = valueAxis;
            memberAxis.renderer.labels.template.disabled = true;
            memberAxis.renderer.grid.template.disabled = true;

            // Create 'Member Count' series
            var seriesMemberCount = chart.series.push(new am4charts.LineSeries());
            seriesMemberCount.dataFields.valueY = 'memberCount';
            seriesMemberCount.dataFields.categoryX = 'month';
            seriesMemberCount.yAxis = memberAxis;
            //seriesMemberCount.name = 'Number of Members';
            seriesMemberCount.strokeWidth = 2;
            seriesMemberCount.propertyFields.strokeDasharray = 'dashLength';
            seriesMemberCount.tooltipText = 'Number of Members: \n{valueY}';
            seriesMemberCount.showOnInit = true;
            seriesMemberCount.stroke = am4core.color('#b71c1c');

            // Customize tooltip appearance for seriesMemberCount
            seriesMemberCount.tooltip.getFillFromObject = false;
            seriesMemberCount.tooltip.background.fill = am4core.color('#b71c1c').lighten(0.2); // Change tooltip background color
            seriesMemberCount.tooltip.background.fillOpacity = 0.5;
            seriesMemberCount.tooltip.background.stroke = am4core.color('#b71c1c'); // Change tooltip border color
            seriesMemberCount.tooltip.label.fill = am4core.color('#fff'); // Change tooltip text color

            var memberCountBullet = seriesMemberCount.bullets.push(new am4charts.CircleBullet());
            memberCountBullet.circle.fill = am4core.color('#b71c1c');
            memberCountBullet.circle.strokeWidth = 2;

            var memberCountState = memberCountBullet.states.create('hover');
            memberCountState.properties.scale = 1.2;

            var memberCountLabel = seriesMemberCount.bullets.push(new am4charts.LabelBullet());
            memberCountLabel.label.horizontalCenter = 'left';
            memberCountLabel.label.dx = 14;

            // Add a legend
            //chart.legend = new am4charts.Legend();

            // Add cursor
            chart.cursor = new am4charts.XYCursor();
            chart.cursor.fullWidthLineX = true;
            chart.cursor.xAxis = categoryAxis;
            chart.cursor.lineX.strokeOpacity = 0;
            chart.cursor.lineX.fill = am4core.color('#000');
            chart.cursor.lineX.fillOpacity = 0.1;

            chart.logo.disabled = true;

            // Add scrollbar
            //chart.scrollbarX = new am4core.Scrollbar();


// Create a new Chart4 instance
            var chart = am4core.create('chartdiv7', am4charts.XYChart);
            chart.hiddenState.properties.opacity = 0; // Hide chart initially

            chart.colors.step = 2;
            chart.maskBullets = false;

            // Add and configure data
            chart.data = [
                " + GenerateChartData(months, monthlySalaries, netSalaries, memberCounts) + @"
            ];

            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = 'month';
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 30;
            categoryAxis.renderer.grid.template.disabled = true;
            categoryAxis.renderer.fullWidthTooltip = true;
            categoryAxis.renderer.labels.template.disabled = true;

            // Hide x-axis base line
            categoryAxis.renderer.line.disabled = true;
            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.renderer.minGridDistance = 50;
            //valueAxis.title.text = 'Valuation';
            valueAxis.renderer.labels.template.disabled = true;
            valueAxis.renderer.grid.template.disabled = true;

            var memberAxis = chart.yAxes.push(new am4charts.ValueAxis());
            //memberAxis.title.text = 'Number of Members';
            memberAxis.renderer.opposite = true;
            memberAxis.syncWithAxis = valueAxis;
            memberAxis.renderer.labels.template.disabled = true;
            memberAxis.renderer.grid.template.disabled = true;

            // Create 'Member Count' series
            var seriesMemberCount = chart.series.push(new am4charts.LineSeries());
            seriesMemberCount.dataFields.valueY = 'monthlySalary';
            seriesMemberCount.dataFields.categoryX = 'month';
            //seriesMemberCount.name = 'Number of Members';
            seriesMemberCount.strokeWidth = 2;
            seriesMemberCount.propertyFields.strokeDasharray = 'dashLength';
            seriesMemberCount.tooltipText = 'Basic Salary: \n${valueY}';
            seriesMemberCount.showOnInit = true;
            seriesMemberCount.stroke = am4core.color('#00692c');

            // Customize tooltip appearance for seriesMemberCount
            seriesMemberCount.tooltip.getFillFromObject = false;
            seriesMemberCount.tooltip.background.fill = am4core.color('#00692c').lighten(0.2); // Change tooltip background color
            seriesMemberCount.tooltip.background.fillOpacity = 0.5;
            seriesMemberCount.tooltip.background.stroke = am4core.color('#00692c'); // Change tooltip border color
            seriesMemberCount.tooltip.label.fill = am4core.color('#fff'); // Change tooltip text color


            var memberCountBullet = seriesMemberCount.bullets.push(new am4charts.CircleBullet());
            memberCountBullet.circle.fill = am4core.color('#00692c');
            memberCountBullet.circle.strokeWidth = 2;

            var memberCountState = memberCountBullet.states.create('hover');
            memberCountState.properties.scale = 1.2;

            var memberCountLabel = seriesMemberCount.bullets.push(new am4charts.LabelBullet());
            memberCountLabel.label.horizontalCenter = 'left';
            memberCountLabel.label.dx = 14;

            // Add a legend
            //chart.legend = new am4charts.Legend();

            // Add cursor
            chart.cursor = new am4charts.XYCursor();
            chart.cursor.fullWidthLineX = true;
            chart.cursor.xAxis = categoryAxis;
            chart.cursor.lineX.strokeOpacity = 0;
            chart.cursor.lineX.fill = am4core.color('#000');
            chart.cursor.lineX.fillOpacity = 0.1;

            chart.logo.disabled = true;

            // Add scrollbar
            //chart.scrollbarX = new am4core.Scrollbar();

// Create a new Chart4 instance
            var chart = am4core.create('chartdiv8', am4charts.XYChart);
            chart.hiddenState.properties.opacity = 0; // Hide chart initially

            chart.colors.step = 2;
            chart.maskBullets = false;

            // Add and configure data
            chart.data = [
                " + GenerateChartData(months, monthlySalaries, netSalaries, memberCounts) + @"
            ];

            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = 'month';
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 30;
            categoryAxis.renderer.grid.template.disabled = true;
            categoryAxis.renderer.fullWidthTooltip = true;
            categoryAxis.renderer.labels.template.disabled = true;

            // Hide x-axis base line
            categoryAxis.renderer.line.disabled = true;
            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.renderer.minGridDistance = 50;
            //valueAxis.title.text = 'Valuation';
            valueAxis.renderer.labels.template.disabled = true;
            valueAxis.renderer.grid.template.disabled = true;

            var memberAxis = chart.yAxes.push(new am4charts.ValueAxis());
            //memberAxis.title.text = 'Number of Members';
            memberAxis.renderer.opposite = true;
            memberAxis.syncWithAxis = valueAxis;
            memberAxis.renderer.labels.template.disabled = true;
            memberAxis.renderer.grid.template.disabled = true;

            // Create 'Member Count' series
            var seriesMemberCount = chart.series.push(new am4charts.LineSeries());
            seriesMemberCount.dataFields.valueY = 'netSalary';
            seriesMemberCount.dataFields.categoryX = 'month';
            //seriesMemberCount.name = 'Number of Members';
            seriesMemberCount.strokeWidth = 2;
            seriesMemberCount.propertyFields.strokeDasharray = 'dashLength';
            seriesMemberCount.tooltipText = 'Net Salary: \n${valueY}';
            seriesMemberCount.showOnInit = true;
            seriesMemberCount.stroke = am4core.color('#085b5c');

            // Customize tooltip appearance for seriesMemberCount
            seriesMemberCount.tooltip.getFillFromObject = false;
            seriesMemberCount.tooltip.background.fill = am4core.color('#085b5c').lighten(0.2); // Change tooltip background color
            seriesMemberCount.tooltip.background.fillOpacity = 0.5;
            seriesMemberCount.tooltip.background.stroke = am4core.color('#085b5c'); // Change tooltip border color
            seriesMemberCount.tooltip.label.fill = am4core.color('#fff'); // Change tooltip text color

            var memberCountBullet = seriesMemberCount.bullets.push(new am4charts.CircleBullet());
            memberCountBullet.circle.fill = am4core.color('#085b5c');
            memberCountBullet.circle.strokeWidth = 2;

            var memberCountState = memberCountBullet.states.create('hover');
            memberCountState.properties.scale = 1.2;

            var memberCountLabel = seriesMemberCount.bullets.push(new am4charts.LabelBullet());
            memberCountLabel.label.horizontalCenter = 'left';
            memberCountLabel.label.dx = 14;

            // Add a legend
            //chart.legend = new am4charts.Legend();

            // Add cursor
            chart.cursor = new am4charts.XYCursor();
            chart.cursor.fullWidthLineX = true;
            chart.cursor.xAxis = categoryAxis;
            chart.cursor.lineX.strokeOpacity = 0;
            chart.cursor.lineX.fill = am4core.color('#000');
            chart.cursor.lineX.fillOpacity = 0.1;

            chart.logo.disabled = true;

            // Add scrollbar
            //chart.scrollbarX = new am4core.Scrollbar();

        });
    </script>
    ";

                // Register the JavaScript block to the page
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyChart", script);
            }
            else
            {
                WarningAlert("No Data to Display");
            }
        }

        private void getDatatable()
        {
            Models.Dashboard.Dashboard dashboard = new Models.Dashboard.Dashboard("cn", 1);
            DataSet datatable = dashboard.GetDataTable();

            if (datatable != null && datatable.Tables.Count > 0 && datatable.Tables[0].Rows.Count > 0)
            {
                grdDashboard.DataSource = datatable;
                grdDashboard.DataBind();
                grdDashboard.UseAccessibleHeader = true;
                grdDashboard.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdDashboard.DataSource = null;
                grdDashboard.DataBind();
                WarningAlert("No Data to Display");
            }
        }

        private string GenerateChartData(List<string> months, List<decimal> monthlySalaries, List<decimal> netSalaries, List<int> memberCounts)
        {
            StringBuilder data = new StringBuilder();

            for (int i = 0; i < months.Count; i++)
            {
                data.Append("{");
                data.Append("'month': '" + months[i] + "', ");
                data.Append("'monthlySalary': " + monthlySalaries[i] + ", ");
                data.Append("'netSalary': " + netSalaries[i] + ", ");
                data.Append("'memberCount': " + memberCounts[i] + "}");
                if (i < months.Count - 1)
                {
                    data.Append(",");
                }
            }

            return data.ToString();
        }

        protected void grdDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDashboard.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);

        }

        private void BindGrid(int newPageIndex = 0)
        {
            try
            {
                Models.Dashboard.Dashboard dashboard = new Models.Dashboard.Dashboard("cn", 1);
                DataSet datatable = dashboard.GetDataTable();
                if (datatable != null)
                {
                    int maxPageIndex = grdDashboard.PageCount - 1;
                    if (newPageIndex < 0 || newPageIndex > maxPageIndex) 
                    {
                        if (maxPageIndex >= 0)
                        {
                            newPageIndex = maxPageIndex;
                        }
                        else
                        {
                            newPageIndex = 0;
                        }
                    }
                    grdDashboard.DataSource = datatable;
                    grdDashboard.PageIndex = newPageIndex;
                    grdDashboard.DataBind();
                }
                else
                {
                    grdDashboard.DataSource = null;
                    grdDashboard.DataBind();
                }
            }
            catch (Exception ex)
            {

                WarningAlert($"{ex.Message}");
            }
        }
    }
}