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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.WorkingCapital
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisWorkingCapitalRight.xaml
    /// </summary>
    public partial class BusinessAnalysisWorkingCapitalRight : UserControl
    {
        public BusinessAnalysisWorkingCapitalRight()
        {
            InitializeComponent();
            LoadDiagram();
            LoadDiagram2();
        }

        public void LoadDiagram()
        {
            chart.ChartAreas.Add(new ChartArea("Default"));
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.LineWidth = 0;

            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            var legend = new Legend("Legend");
            legend.Alignment = System.Drawing.StringAlignment.Center;
            legend.Docking = Docking.Top;
            chart.Legends.Add(legend);


            chart.Series.Add(new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.StackedColumn,
                IsValueShownAsLabel = true,
                LegendText = "ДЗ Средний долг",
                Color = System.Drawing.Color.FromArgb(128, 100, 162),
                BorderColor = System.Drawing.Color.FromArgb(128, 100, 162)
            });
            chart.Series.Add(new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.StackedColumn,
                IsValueShownAsLabel = true,
                LegendText = "Товары средний остаток",
                Color = System.Drawing.Color.FromArgb(170, 186, 215),
                BorderColor = System.Drawing.Color.FromArgb(170, 186, 215)
            });

            chart.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.StackedColumn, IsValueShownAsLabel = true });
            chart.Series[2].LegendText = "Деньги средний остаток";
            chart.Series[2].Color = System.Drawing.Color.FromArgb(186, 176, 201);
            chart.Series[2].BorderColor = System.Drawing.Color.FromArgb(186, 176, 201);


            chart.Series.Add(new Series() { Name = "Series4", ChartType = SeriesChartType.Line, IsValueShownAsLabel = true });
            chart.Series[3].LegendText = "Продажи";
            chart.Series[3].Color = System.Drawing.Color.FromArgb(60, 103, 154);
            chart.Series[3].BorderColor = System.Drawing.Color.FromArgb(60, 103, 154);


            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Янв", 10);
            seriesData1.Add("Фев", 20);
            seriesData1.Add("Мар", 30);
            seriesData1.Add("Апр", 40);
            seriesData1.Add("Май", 50);
            seriesData1.Add("Июн", 60);
            seriesData1.Add("Июл", 70);
            seriesData1.Add("Авг", 80);
            seriesData1.Add("Сен", 90);
            seriesData1.Add("Окт", 100);
            seriesData1.Add("Ноя", 110);
            seriesData1.Add("Дек", 120);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Янв", 15);
            seriesData2.Add("Фев", 25);
            seriesData2.Add("Мар", 35);
            seriesData2.Add("Апр", 45);
            seriesData2.Add("Май", 55);
            seriesData2.Add("Июн", 65);
            seriesData2.Add("Июл", 70);
            seriesData2.Add("Авг", 85);
            seriesData2.Add("Сен", 95);
            seriesData2.Add("Окт", 105);
            seriesData2.Add("Ноя", 115);
            seriesData2.Add("Дек", 125);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart.Series[1].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData3 = new Dictionary<string, int>();

            seriesData3.Add("Янв", 19);
            seriesData3.Add("Фев", 29);
            seriesData3.Add("Мар", 39);
            seriesData3.Add("Апр", 49);
            seriesData3.Add("Май", 59);
            seriesData3.Add("Июн", 69);
            seriesData3.Add("Июл", 79);
            seriesData3.Add("Авг", 89);
            seriesData3.Add("Сен", 99);
            seriesData3.Add("Окт", 109);
            seriesData3.Add("Ноя", 119);
            seriesData3.Add("Дек", 129);

            foreach (KeyValuePair<string, int> data in seriesData3)
                chart.Series[2].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData4 = new Dictionary<string, int>();

            seriesData4.Add("Янв", 19);
            seriesData4.Add("Фев", 29);
            seriesData4.Add("Мар", 19);
            seriesData4.Add("Апр", 49);
            seriesData4.Add("Май", 29);
            seriesData4.Add("Июн", 69);
            seriesData4.Add("Июл", 39);
            seriesData4.Add("Авг", 49);
            seriesData4.Add("Сен", 99);
            seriesData4.Add("Окт", 29);
            seriesData4.Add("Ноя", 59);
            seriesData4.Add("Дек", 129);

            foreach (KeyValuePair<string, int> data in seriesData4)
                chart.Series[3].Points.AddXY(data.Key, data.Value);
        }

        public void LoadDiagram2()
        {
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.LineWidth = 0;

            chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            var legend = new Legend("Legend");
            legend.Alignment = System.Drawing.StringAlignment.Center;
            legend.Docking = Docking.Top;
            chart2.Legends.Add(legend);


            chart2.Series.Add(new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LegendText = "КЗ Средний долг",
                Color = System.Drawing.Color.FromArgb(128, 100, 162),
                BorderColor = System.Drawing.Color.FromArgb(128, 100, 162)
            });
            chart2.Series.Add(new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LegendText = "ДЗ Средний долг",
                Color = System.Drawing.Color.FromArgb(186, 176, 201),
                BorderColor = System.Drawing.Color.FromArgb(170, 186, 215)
            });


            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Янв", 10);
            seriesData1.Add("Фев", 20);
            seriesData1.Add("Мар", 30);
            seriesData1.Add("Апр", 40);
            seriesData1.Add("Май", 50);
            seriesData1.Add("Июн", 60);
            seriesData1.Add("Июл", 70);
            seriesData1.Add("Авг", 80);
            seriesData1.Add("Сен", 90);
            seriesData1.Add("Окт", 100);
            seriesData1.Add("Ноя", 110);
            seriesData1.Add("Дек", 120);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart2.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Янв", 15);
            seriesData2.Add("Фев", 25);
            seriesData2.Add("Мар", 35);
            seriesData2.Add("Апр", 45);
            seriesData2.Add("Май", 55);
            seriesData2.Add("Июн", 65);
            seriesData2.Add("Июл", 70);
            seriesData2.Add("Авг", 85);
            seriesData2.Add("Сен", 95);
            seriesData2.Add("Окт", 105);
            seriesData2.Add("Ноя", 115);
            seriesData2.Add("Дек", 125);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart2.Series[1].Points.AddXY(data.Key, data.Value);
        }
    }
}
