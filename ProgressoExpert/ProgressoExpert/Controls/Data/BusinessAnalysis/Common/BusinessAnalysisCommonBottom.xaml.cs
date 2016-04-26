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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Common
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisCommonBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisCommonBottom : UserControl
    {
        public BusinessAnalysisCommonBottom()
        {
            InitializeComponent();
            LoadDiagram();
        }

        public void LoadDiagram()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas.Add(chartArea);

            var legend = new Legend()
            {
                Name = "Legend",
                Alignment = System.Drawing.StringAlignment.Center,
                Docking = Docking.Right,
                Font = new System.Drawing.Font("Arial", 10)
            };
            chart.Legends.Add(legend);

            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                Legend = legend.Name,
                LegendText = "КЗ Продажи",
                Color = System.Drawing.Color.FromArgb(186, 112, 50),
                BorderColor = System.Drawing.Color.White,
                IsValueShownAsLabel = true
            };

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
                series.Points.AddXY(data.Key, data.Value);

            chart.Series.Add(series);




            chart.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });


            chart.Series[1].LegendText = "ОК Средний остаток";
            chart.Series[1].Color = System.Drawing.Color.FromArgb(149, 195, 213);

            chart.Series[2].LegendText = "0 Чистая прибыль";
            chart.Series[2].Color = System.Drawing.Color.FromArgb(249, 181, 144);

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
                chart.Series[1].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData3 = new Dictionary<string, int>();

            seriesData3.Add("Янв", 2);
            seriesData3.Add("Фев", 13);
            seriesData3.Add("Мар", 24);
            seriesData3.Add("Апр", 35);
            seriesData3.Add("Май", 46);
            seriesData3.Add("Июн", 57);
            seriesData3.Add("Июл", 68);
            seriesData3.Add("Авг", 79);
            seriesData3.Add("Сен", 89);
            seriesData3.Add("Окт", 99);
            seriesData3.Add("Ноя", 109);
            seriesData3.Add("Дек", 119);

            foreach (KeyValuePair<string, int> data in seriesData3)
                chart.Series[2].Points.AddXY(data.Key, data.Value);
        }
    }
}
