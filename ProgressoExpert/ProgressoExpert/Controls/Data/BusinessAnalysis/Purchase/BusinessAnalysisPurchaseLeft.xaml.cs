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
            chart1.ChartAreas.Add(new ChartArea("Default"));
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            var legend = new Legend("Legend");
            legend.Docking = Docking.Top;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            chart1.Legends.Add(legend);

            chart1.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart1.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart1.Series[0].LegendText = "Закуп";
            chart1.Series[0].Color = System.Drawing.Color.FromArgb(228, 108, 10);
            chart1.Series[0].ChartType = SeriesChartType.Bar;

            chart1.Series[1].LegendText = "Продажи";
            chart1.Series[1].Color = System.Drawing.Color.FromArgb(10, 198, 28);
            chart1.Series[1].ChartType = SeriesChartType.Bar;

            //chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            //chart1.ChartAreas[0].AxisY.LineWidth = 0;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Шины", 940);
            seriesData1.Add("Запчасти", 313);
            seriesData1.Add("Масла", 235);
            seriesData1.Add("Прочее", 78);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart1.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Шины", 980);
            seriesData2.Add("Запчасти", 377);
            seriesData2.Add("Масла", 106);
            seriesData2.Add("Прочее", 45);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart1.Series[1].Points.AddXY(data.Key, data.Value);
        }
    }
}
