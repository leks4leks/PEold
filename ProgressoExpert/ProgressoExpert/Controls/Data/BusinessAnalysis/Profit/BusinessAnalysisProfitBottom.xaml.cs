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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Profit
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisProfitBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisProfitBottom : UserControl
    {
        public BusinessAnalysisProfitBottom()
        {
            InitializeComponent();
            LoadDiagram();
            LoadDiagram2();
            LoadDiagram3();
            LoadDiagram4();
        }

        public void LoadDiagram()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chart.ChartAreas.Add(chartArea);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Валовая прибыль",
                Color = System.Drawing.Color.FromArgb(65, 152, 175),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();
            seriesData1.Add("1", 1);
            seriesData1.Add("2", 2);
            seriesData1.Add("3", 3);
            seriesData1.Add("4", 4);
            seriesData1.Add("5", 5);
            seriesData1.Add("6", 6);
            seriesData1.Add("7", 7);
            seriesData1.Add("8", 8);
            seriesData1.Add("9", 9);
            seriesData1.Add("10", 10);
            seriesData1.Add("11", 11);
            seriesData1.Add("12", 12);
            foreach (KeyValuePair<string, int> data in seriesData1)
                series.Points.AddXY(data.Key, data.Value);
            chart.Series.Add(series);


            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Чистая прибыль",
                Color = System.Drawing.Color.FromArgb(145, 195, 213),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();
            seriesData2.Add("1", 11);
            seriesData2.Add("2", 22);
            seriesData2.Add("3", 33);
            seriesData2.Add("4", 44);
            seriesData2.Add("5", 55);
            seriesData2.Add("6", 66);
            seriesData2.Add("7", 77);
            seriesData2.Add("8", 88);
            seriesData2.Add("9", 99);
            seriesData2.Add("10", 100);
            seriesData2.Add("11", 110);
            seriesData2.Add("12", 120);
            foreach (KeyValuePair<string, int> data in seriesData2)
                series2.Points.AddXY(data.Key, data.Value);
            chart.Series.Add(series2);
        }

        public void LoadDiagram2()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chart2.ChartAreas.Add(chartArea);

            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Spline,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Валовая рентабельность",
                Color = System.Drawing.Color.FromArgb(65, 152, 175),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, double> seriesData1 = new Dictionary<string, double>();
            seriesData1.Add("Янв", 14.2);
            seriesData1.Add("Фев", 8.7);
            seriesData1.Add("Мар", 8.8);
            seriesData1.Add("Апр", 10.2);
            seriesData1.Add("Май", 6.6);
            seriesData1.Add("Июн", 7.2);
            seriesData1.Add("Июл", 0.6);
            seriesData1.Add("Авг", 4.3);
            seriesData1.Add("Сен", 6.2);
            seriesData1.Add("Окт", 7.2);
            seriesData1.Add("Ноя", 7.4);
            seriesData1.Add("Дек", 9.8);
            foreach (KeyValuePair<string, double> data in seriesData1)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format("{0}%", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }

            chart2.Series.Add(series);

            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Spline,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Чистая рентабельность",
                Color = System.Drawing.Color.FromArgb(145, 195, 213),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, double> seriesData2 = new Dictionary<string, double>();
            seriesData2.Add("Янв", 17);
            seriesData2.Add("Фев", 11);
            seriesData2.Add("Мар", 11);
            seriesData2.Add("Апр", 11);
            seriesData2.Add("Май", 8);
            seriesData2.Add("Июн", 10);
            seriesData2.Add("Июл", 13);
            seriesData2.Add("Авг", 13);
            seriesData2.Add("Сен", 13);
            seriesData2.Add("Окт", 12);
            seriesData2.Add("Ноя", 14);
            seriesData2.Add("Дек", 16);
            foreach (KeyValuePair<string, double> data in seriesData2)
            {
                series2.Points.AddXY(data.Key, data.Value);
                var _point = series2.Points.Last();
                _point.Label = string.Format("{0}%", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }

            chart2.Series.Add(series2);
        }

        public void LoadDiagram3()
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
            chart3.ChartAreas.Add(chartArea);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Bar,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Валовая прибыль по товарам",
                Color = System.Drawing.Color.FromArgb(149, 179, 215),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();
            seriesData1.Add("Масла", 5400000);
            seriesData1.Add("Запчасти", 14500000);
            seriesData1.Add("Шины", 25150000);
            foreach (KeyValuePair<string, int> data in seriesData1)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }

            chart3.Series.Add(series);
        }

        public void LoadDiagram4()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chart4.ChartAreas.Add(chartArea);

            var legend = new Legend()
            {
                Name = "Legend",
                Alignment = System.Drawing.StringAlignment.Center,
                Docking = Docking.Right,
                Font = new System.Drawing.Font("Arial", 10)
            };
            chart4.Legends.Add(legend);

            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Pie,
                ChartArea = chartArea.Name,
                Legend = legend.Name
            };
            chart4.Series.Add(series);


            Dictionary<string, decimal> seriesData1 = new Dictionary<string, decimal>();

            seriesData1.Add("Иванов", 25);
            seriesData1.Add("Петров", 17);
            seriesData1.Add("Сидоров", 10);
            seriesData1.Add("Носков", 9);
            seriesData1.Add("Дюжин", 8);
            seriesData1.Add("Прочие", 31);

            var dataPointData = seriesData1["Иванов"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Иванов",
                Color = System.Drawing.Color.FromArgb(69, 114, 167),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Петров"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Петров",
                Color = System.Drawing.Color.FromArgb(170, 70, 67),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Сидоров"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Сидоров",
                Color = System.Drawing.Color.FromArgb(137, 165, 78),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Носков"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Носков",
                Color = System.Drawing.Color.FromArgb(113, 88, 143),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Дюжин"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Дюжин",
                Color = System.Drawing.Color.FromArgb(65, 152, 175),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Прочие"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Прочие",
                Color = System.Drawing.Color.FromArgb(219, 132, 61),
                BorderColor = System.Drawing.Color.White
            });
        }
    }
}
