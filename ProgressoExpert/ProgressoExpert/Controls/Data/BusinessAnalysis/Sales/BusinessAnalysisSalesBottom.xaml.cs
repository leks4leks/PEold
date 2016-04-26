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
            chart.ChartAreas.Add(new ChartArea("Default"));
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);

            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.LineWidth = 0;
            
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;


            chart.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart.Series[0].LegendText = "Продажи";
            chart.Series[0].Color = System.Drawing.Color.FromArgb(0, 176, 80);
            chart.Series[0].BorderColor = System.Drawing.Color.White;
            chart.Series[0].BorderColor = System.Drawing.Color.White;

            chart.Series[1].LegendText = "Оплаты";
            chart.Series[1].Color = System.Drawing.Color.FromArgb(147, 169, 207);
            chart.Series[1].BorderColor = System.Drawing.Color.White;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("янв", 10);
            seriesData1.Add("фев", 20);
            seriesData1.Add("мар", 30);
            seriesData1.Add("апр", 40);
            seriesData1.Add("май", 50);
            seriesData1.Add("июн", 60);
            seriesData1.Add("июл", 70);
            seriesData1.Add("авг", 80);
            seriesData1.Add("сен", 90);
            seriesData1.Add("окт", 100);
            seriesData1.Add("ноя", 110);
            seriesData1.Add("дек", 120);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("янв", 15);
            seriesData2.Add("фев", 25);
            seriesData2.Add("мар", 35);
            seriesData2.Add("апр", 45);
            seriesData2.Add("май", 55);
            seriesData2.Add("июн", 65);
            seriesData2.Add("июл", 75);
            seriesData2.Add("авг", 85);
            seriesData2.Add("сен", 95);
            seriesData2.Add("окт", 105);
            seriesData2.Add("ноя", 115);
            seriesData2.Add("дек", 125);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart.Series[1].Points.AddXY(data.Key, data.Value);
        }

        public void LoadDiagram2()
        {
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart2.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart2.Series[0].LegendText = "Шины";
            chart2.Series[0].Color = System.Drawing.Color.FromArgb(127, 154, 72);

            chart2.Series[1].LegendText = "Масла";
            chart2.Series[1].Color = System.Drawing.Color.FromArgb(155, 187, 89);

            chart2.Series[2].LegendText = "Запчасти";
            chart2.Series[2].Color = System.Drawing.Color.FromArgb(198, 214, 172);

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

            Dictionary<string, int> seriesData3 = new Dictionary<string, int>();

            seriesData3.Add("Янв", 11);
            seriesData3.Add("Фев", 22);
            seriesData3.Add("Мар", 33);
            seriesData3.Add("Апр", 44);
            seriesData3.Add("Май", 55);
            seriesData3.Add("Июн", 66);
            seriesData3.Add("Июл", 77);
            seriesData3.Add("Авг", 88);
            seriesData3.Add("Сен", 99);
            seriesData3.Add("Окт", 100);
            seriesData3.Add("Ноя", 110);
            seriesData3.Add("Дек", 120);

            foreach (KeyValuePair<string, int> data in seriesData3)
                chart2.Series[2].Points.AddXY(data.Key, data.Value);
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
