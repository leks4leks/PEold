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
    /// Логика взаимодействия для BusinessAnalysisWorkingCapitalLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisWorkingCapitalLeft : UserControl
    {
        public BusinessAnalysisWorkingCapitalLeft()
        {
            InitializeComponent();
            LoadDiagram();
            LoadDiagram2();
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

            var legend = new Legend("Legend");
            legend.Alignment = System.Drawing.StringAlignment.Center;
            legend.Docking = Docking.Top;
            legend.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart.Legends.Add(legend);


            chart.Series.Add(new Series() 
            { 
                Name = "Series1",
                ChartType = SeriesChartType.StackedColumn,
                IsValueShownAsLabel = false,
                LegendText = "СОК",
                Color = System.Drawing.Color.FromArgb(96, 74, 123),
                BorderColor = System.Drawing.Color.White
            });
            chart.Series.Add(new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.StackedColumn,
                IsValueShownAsLabel = false,
                LegendText = "Прибыль",
                Color = System.Drawing.Color.FromArgb(10, 198, 28),
                BorderColor = System.Drawing.Color.White
            });
            chart.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.StackedColumn, IsValueShownAsLabel = false });

            chart.Series[2].LegendText = "Задолженность";
            chart.Series[2].Color = System.Drawing.Color.FromArgb(204, 193, 218);
            chart.Series[2].BorderColor = System.Drawing.Color.White;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("янв", 150);
            seriesData1.Add("янв - дек", 0);
            seriesData1.Add("дек", 250);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("янв", 0);
            seriesData2.Add("янв - дек", 100);
            seriesData2.Add("дек", 0);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart.Series[1].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData3 = new Dictionary<string, int>();

            seriesData3.Add("янв", 100);
            seriesData3.Add("янв - дек", 0);
            seriesData3.Add("дек", 200);

            foreach (KeyValuePair<string, int> data in seriesData3)
                chart.Series[2].Points.AddXY(data.Key, data.Value);
        }

        public void LoadDiagram2()
        {
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart2.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart2.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);

            chart2.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart2.Series[0].LegendText = "Закуп";
            chart2.Series[0].Color = System.Drawing.Color.FromArgb(79, 129, 189);
            chart2.Series[0].ChartType = SeriesChartType.Bar;

            //chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            //chart1.ChartAreas[0].AxisY.LineWidth = 0;

            chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Шины", 110);
            seriesData1.Add("Запчасти", 50);
            seriesData1.Add("Масла", 53);
            seriesData1.Add("Прочее", 29);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart2.Series[0].Points.AddXY(data.Key, data.Value);
        }
    }
}
