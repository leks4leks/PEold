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
using System.Drawing;
using System.Globalization;

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Sales
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisSalesBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisSalesBottom : UserControl
    {
        public BusinessAnalysisSalesBottom()
        {
            InitializeComponent();
            LoadDiagram();
            LoadDiagram2();
            LoadDiagram4();
        }

        public void LoadDiagram()
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
            chartArea.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart.ChartAreas.Add(chartArea);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Продажи",
                Color = System.Drawing.Color.FromArgb(0, 176, 80),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();
            seriesData1.Add("янв", 5600);
            seriesData1.Add("фев", 3900);
            seriesData1.Add("мар", 6800);
            seriesData1.Add("апр", 11800);
            seriesData1.Add("май", 9300);
            seriesData1.Add("июн", 2900);
            seriesData1.Add("июл", 3800);
            seriesData1.Add("авг", 4100);
            seriesData1.Add("сен", 10500);
            seriesData1.Add("окт", 7800);
            seriesData1.Add("ноя", 6300);
            seriesData1.Add("дек", 12700);
            foreach (KeyValuePair<string, int> data in seriesData1)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }

            chart.Series.Add(series);


            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Оплаты",
                Color = System.Drawing.Color.FromArgb(147, 169, 207),
                BorderColor = System.Drawing.Color.White
            };


            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("янв", 5500);
            seriesData2.Add("фев", 3700);
            seriesData2.Add("мар", 6400);
            seriesData2.Add("апр", 9400);
            seriesData2.Add("май", 7700);
            seriesData2.Add("июн", 2100);
            seriesData2.Add("июл", 3600);
            seriesData2.Add("авг", 3200);
            seriesData2.Add("сен", 8400);
            seriesData2.Add("окт", 10600);
            seriesData2.Add("ноя", 7000);
            seriesData2.Add("дек", 5000);

            foreach (KeyValuePair<string, int> data in seriesData2)
            {
                series2.Points.AddXY(data.Key, data.Value);
                var _point = series2.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart.Series.Add(series2);
        }

        public void LoadDiagram2()
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
            chartArea.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart2.ChartAreas.Add(chartArea);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Шины",
                Color = System.Drawing.Color.FromArgb(127, 154, 72),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();
            seriesData1.Add("Янв", 17500);
            seriesData1.Add("Фев", 18300);
            seriesData1.Add("Мар", 19900);
            seriesData1.Add("Апр", 20200);
            seriesData1.Add("Май", 21500);
            seriesData1.Add("Июн", 20000);
            seriesData1.Add("Июл", 19100);
            seriesData1.Add("Авг", 18200);
            seriesData1.Add("Сен", 16500);
            seriesData1.Add("Окт", 10000);
            seriesData1.Add("Ноя", 11000);
            seriesData1.Add("Дек", 12000);

            foreach (KeyValuePair<string, int> data in seriesData1)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart2.Series.Add(series);



            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Масла",
                Color = System.Drawing.Color.FromArgb(155, 187, 89),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();
            seriesData2.Add("Янв", 1100);
            seriesData2.Add("Фев", 2200);
            seriesData2.Add("Мар", 3300);
            seriesData2.Add("Апр", 440);
            seriesData2.Add("Май", 550);
            seriesData2.Add("Июн", 660);
            seriesData2.Add("Июл", 7700);
            seriesData2.Add("Авг", 8800);
            seriesData2.Add("Сен", 9900);
            seriesData2.Add("Окт", 10000);
            seriesData2.Add("Ноя", 11000);
            seriesData2.Add("Дек", 12000);

            foreach (KeyValuePair<string, int> data in seriesData2)
            {
                series2.Points.AddXY(data.Key, data.Value);
                var _point = series2.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart2.Series.Add(series2);




            var series3 = new Series()
            {
                Name = "Series3",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Запчасти",
                Color = System.Drawing.Color.FromArgb(198, 214, 172),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData3 = new Dictionary<string, int>();

            seriesData3.Add("Янв", 1100);
            seriesData3.Add("Фев", 2200);
            seriesData3.Add("Мар", 3300);
            seriesData3.Add("Апр", 4400);
            seriesData3.Add("Май", 550);
            seriesData3.Add("Июн", 660);
            seriesData3.Add("Июл", 770);
            seriesData3.Add("Авг", 8800);
            seriesData3.Add("Сен", 990);
            seriesData3.Add("Окт", 1000);
            seriesData3.Add("Ноя", 1100);
            seriesData3.Add("Дек", 12000);


            foreach (KeyValuePair<string, int> data in seriesData3)
            {
                series3.Points.AddXY(data.Key, data.Value);
                var _point = series3.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart2.Series.Add(series3);
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
