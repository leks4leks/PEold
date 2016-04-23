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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Expenses
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisExpensesRight.xaml
    /// </summary>
    public partial class BusinessAnalysisExpensesRight : UserControl
    {
        public BusinessAnalysisExpensesRight()
        {
            InitializeComponent();
            LoadDiagram2();
            LoadDiagram3();
            LoadDiagram4();
        }

        public void LoadDiagram2()
        {
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            var legend = new Legend("Legend1");
            chart2.Legends.Add(legend);
            chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart2.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart2.Series[0].LegendText = "Расходы";
            chart2.Series[0].Color = System.Drawing.Color.FromArgb(170, 70, 67);

            chart2.Series[1].LegendText = "Валовая прибыль";
            chart2.Series[1].Color = System.Drawing.Color.FromArgb(209, 147, 146);

            chart2.Series[2].LegendText = "Продажи";
            chart2.Series[2].Color = System.Drawing.Color.FromArgb(0, 176, 80);

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


        public void LoadDiagram3()
        {
            chart3.ChartAreas.Add(new ChartArea("Default"));
            chart3.IsSoftShadows = false;

            var legend = new Legend("Legend1");
            var series = new Series("Series1");
            series.ShadowColor = System.Drawing.Color.Black;
            series.ShadowOffset = 1;

            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "Default";
            series.Legend = "Legend1";


            Dictionary<string, decimal> seriesData1 = new Dictionary<string, decimal>();

            seriesData1.Add("Расходы по реализации продукции и услуг", 41);
            seriesData1.Add("Административные расходы", 11);
            seriesData1.Add("Расходы на финансирование", 45);
            seriesData1.Add("Прочие расходы", 3);

            var dataPointData = seriesData1["Расходы по реализации продукции и услуг"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Расходы по реализации продукции и услуг",
                Color = System.Drawing.Color.FromArgb(192, 80, 77),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Административные расходы"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Административные расходы",
                Color = System.Drawing.Color.FromArgb(179, 74, 71),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Расходы на финансирование"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Расходы на финансирование",
                Color = System.Drawing.Color.FromArgb(202, 126, 125),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Прочие расходы"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Прочие расходы",
                Color = System.Drawing.Color.FromArgb(221, 182, 181),
                BorderColor = System.Drawing.Color.White
            });

            chart3.Series.Add(series);
            chart3.Legends.Add(legend);
            legend.Docking = Docking.Right;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
        }

        public void LoadDiagram4()
        {
            chart4.ChartAreas.Add(new ChartArea("Default"));
            chart4.IsSoftShadows = false;

            var series = new Series("Series1");
            series.ShadowColor = System.Drawing.Color.Black;
            series.ShadowOffset = 1;

            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "Default";
            series.Legend = "Legend1";


            Dictionary<string, decimal> seriesData1 = new Dictionary<string, decimal>();

            seriesData1.Add("Расходы по реализации продукции и услуг", 38);
            seriesData1.Add("Административные расходы", 12);
            seriesData1.Add("Расходы на финансирование", 47);
            seriesData1.Add("Прочие расходы", 3);

            var dataPointData = seriesData1["Расходы по реализации продукции и услуг"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Расходы по реализации продукции и услуг",
                Color = System.Drawing.Color.FromArgb(192, 80, 77),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Административные расходы"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Административные расходы",
                Color = System.Drawing.Color.FromArgb(179, 74, 71),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Расходы на финансирование"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Расходы на финансирование",
                Color = System.Drawing.Color.FromArgb(202, 126, 125),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Прочие расходы"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Прочие расходы",
                Color = System.Drawing.Color.FromArgb(221, 182, 181),
                BorderColor = System.Drawing.Color.White
            });

            chart4.Series.Add(series);
            chart4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
        }
    }
}
