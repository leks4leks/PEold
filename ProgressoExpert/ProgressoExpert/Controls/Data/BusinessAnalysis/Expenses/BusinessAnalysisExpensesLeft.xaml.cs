using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Expenses
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisExpensesLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisExpensesLeft : UserControl
    {
        public BusinessAnalysisExpensesLeft()
        {
            InitializeComponent();
            LoadDiagram1();
        }

        public void LoadDiagram1()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisY.LabelStyle.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisY.MinorTickMark.Enabled = false;
            chartArea.AxisY.LineWidth = 0;
            chart1.ChartAreas.Add(chartArea);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Bar,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Валовая прибыль по товарам",
                Color = System.Drawing.Color.FromArgb(149, 55, 53),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Шины", 38000000);
            seriesData1.Add("Админ-ые", 3500000);
            seriesData1.Add("По реализации", 700000);
            seriesData1.Add("Бонусы", 800000);
            seriesData1.Add("Прочие", 150000);

            foreach (KeyValuePair<string, int> data in seriesData1)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart1.Series.Add(series);
        }
    }
}
