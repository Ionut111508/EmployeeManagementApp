using Newtonsoft.Json; // Asigurați-vă că aveți pachetul Newtonsoft.Json instalat
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ManagementulProiectelor.Forms
{
    public partial class FormTest : Form
    {
        static List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();

        public FormTest()
        {
            InitializeComponent();
            Test();
        }

        public void Test()
        {
            if (listaAngajati.Count == 0)
            {
                MessageBox.Show("Nu există angajați în baza de date.");
                return;
            }

            var ganttChartData = new StringBuilder();
            ganttChartData.Append("[");
            foreach (var angajat in listaAngajati)
            {
                ganttChartData.Append("[");
                ganttChartData.Append("'" + angajat.numeAngajat.Replace("'", "\\'") + "', ");
                ganttChartData.Append("'" + angajat.Id_Angajat + "', ");
                ganttChartData.Append("new Date(" + DateTime.Now.Year + ", " + (DateTime.Now.Month - 1) + ", " + DateTime.Now.Day + "), ");
                ganttChartData.Append("new Date(" + DateTime.Now.Year + ", " + (DateTime.Now.Month - 1) + ", " + DateTime.Now.AddDays(5).Day + ")");
                ganttChartData.Append("],");
            }
            ganttChartData.Append("]");

            string html = @"
<!DOCTYPE html>
<html>
<head>
  <script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>
  <script type='text/javascript'>
    google.charts.load('current', {'packages':['gantt']});
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
      var data = new google.visualization.DataTable();
      data.addColumn('string', 'Task ID');
      data.addColumn('string', 'Task Name');
      data.addColumn('string', 'Resource');
      data.addColumn('date', 'Start Date');
      data.addColumn('date', 'End Date');
      data.addColumn('number', 'Duration');
      data.addColumn('number', 'Percent Complete');
      data.addColumn('string', 'Dependencies');

      data.addRows(" + ganttChartData.ToString() + @");

      var options = {
        height: 400
      };

      var chart = new google.visualization.Gantt(document.getElementById('chart_div'));

      chart.draw(data, options);
    }
  </script>
</head>
<body>
  <div id='chart_div'></div>
</body>
</html>
";

            WebBrowser webBrowser = new WebBrowser();
            webBrowser.DocumentText = html;
            webBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(webBrowser);
        }
    }
}
