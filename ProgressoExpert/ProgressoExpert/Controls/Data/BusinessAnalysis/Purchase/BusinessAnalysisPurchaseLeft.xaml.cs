using System;
using System.Collections.Generic;
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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Purchase
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisPurchaseLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisPurchaseLeft : UserControl
    {
        public BusinessAnalysisPurchaseLeft()
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
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisY.MinorTickMark.Enabled = false;
            chart1.ChartAreas.Add(chartArea);

            var legend = new Legend() { Name = "Legend", Docking = Docking.Top, Alignment = System.Drawing.StringAlignment.Center };
            chart1.Legends.Add(legend);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Bar,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Закуп",
                Color = System.Drawing.Color.FromArgb(228, 108, 10),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Шины", 940);
            seriesData1.Add("Запчасти", 313);
            seriesData1.Add("Масла", 235);
            seriesData1.Add("Прочее", 78);

            foreach (KeyValuePair<string, int> data in seriesData1)
                series.Points.AddXY(data.Key, data.Value);

            chart1.Series.Add(series);

            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Bar,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Продажи",
                Color = System.Drawing.Color.FromArgb(10, 198, 28),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Шины", 980);
            seriesData2.Add("Запчасти", 377);
            seriesData2.Add("Масла", 106);
            seriesData2.Add("Прочее", 45);

            foreach (KeyValuePair<string, int> data in seriesData2)
                series2.Points.AddXY(data.Key, data.Value);

            chart1.Series.Add(series2);
        }
    }
}
