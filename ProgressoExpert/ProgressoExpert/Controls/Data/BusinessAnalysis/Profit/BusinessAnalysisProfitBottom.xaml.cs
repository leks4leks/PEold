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
            chart.ChartAreas.Add(new ChartArea("Default"));
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart.Series[0].LegendText = "Валовая прибыль";
            chart.Series[0].Color = System.Drawing.Color.FromArgb(65, 152, 175);

            chart.Series[1].LegendText = "Чистая прибыль";
            chart.Series[1].Color = System.Drawing.Color.FromArgb(145, 195, 213);

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
                chart.Series[0].Points.AddXY(data.Key, data.Value);

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
                chart.Series[1].Points.AddXY(data.Key, data.Value);
        }

        public void LoadDiagram2()
        {
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart2.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart2.Series[0].LegendText = "Валовая рентабельность";
            chart2.Series[0].Color = System.Drawing.Color.FromArgb(65, 152, 175);
            chart2.Series[0].ChartType = SeriesChartType.Spline;

            chart2.Series[1].LegendText = "Чистая рентабельность";
            chart2.Series[1].Color = System.Drawing.Color.FromArgb(145, 195, 213);
            chart2.Series[1].ChartType = SeriesChartType.Spline;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Янв", 1);
            seriesData1.Add("Фев", 2);
            seriesData1.Add("Мар", 3);
            seriesData1.Add("Апр", 4);
            seriesData1.Add("Май", 5);
            seriesData1.Add("Июн", 6);
            seriesData1.Add("Июл", 7);
            seriesData1.Add("Авг", 8);
            seriesData1.Add("Сен", 9);
            seriesData1.Add("Окт", 10);
            seriesData1.Add("Ноя", 11);
            seriesData1.Add("Дек", 12);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart2.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Янв", 11);
            seriesData2.Add("Фев", 22);
            seriesData2.Add("Мар", 33);
            seriesData2.Add("Апр", 44);
            seriesData2.Add("Май", 55);
            seriesData2.Add("Июн", 66);
            seriesData2.Add("Июл", 77);
            seriesData2.Add("Авг", 88);
            seriesData2.Add("Сен", 99);
            seriesData2.Add("Окт", 100);
            seriesData2.Add("Ноя", 110);
            seriesData2.Add("Дек", 120);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart2.Series[1].Points.AddXY(data.Key, data.Value);
        }

        public void LoadDiagram3()
        {
            chart3.ChartAreas.Add(new ChartArea("Default"));
            chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart3.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart3.Series[0].LegendText = "Валовая прибыль по товарам";
            chart3.Series[0].Color = System.Drawing.Color.FromArgb(149, 179, 215);
            chart3.Series[0].ChartType = SeriesChartType.Bar;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Масла", 1);
            seriesData1.Add("Запчасти", 2);
            seriesData1.Add("Шины", 3);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart3.Series[0].Points.AddXY(data.Key, data.Value);
        }

        public void LoadDiagram4()
        {
            chart4.ChartAreas.Add(new ChartArea("Default"));
            chart4.IsSoftShadows = false;

            var legend = new Legend("Legend1");
            var series = new Series("Series1");
            series.ShadowColor = System.Drawing.Color.Black;
            series.ShadowOffset = 1;

            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "Default";
            series.Legend = "Legend1";


            Dictionary<string, decimal> seriesData1 = new Dictionary<string, decimal>();

            seriesData1.Add("Иванов", 1);
            seriesData1.Add("Петров", 2);
            seriesData1.Add("Сидоров", 3);
            seriesData1.Add("Другие", 4);

            var dataPointData = seriesData1["Иванов"];
            series.Points.Add(new DataPoint()
            {
                Label = dataPointData.ToString(),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Иванов",
                Color = System.Drawing.Color.FromArgb(137, 165, 78),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Петров"];
            series.Points.Add(new DataPoint()
            {
                Label = dataPointData.ToString(),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Петров",
                Color = System.Drawing.Color.FromArgb(185, 205, 150),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Сидоров"];
            series.Points.Add(new DataPoint()
            {
                Label = dataPointData.ToString(),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Сидоров",
                Color = System.Drawing.Color.FromArgb(185, 205, 25),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Другие"];
            series.Points.Add(new DataPoint()
            {
                Label = dataPointData.ToString(),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Другие",
                Color = System.Drawing.Color.FromArgb(185, 10, 150),
                BorderColor = System.Drawing.Color.White
            });

            chart4.Series.Add(series);
            chart4.Legends.Add(legend);
            chart4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
        }
    }
}
