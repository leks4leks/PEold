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
    /// Логика взаимодействия для BusinessAnalysisPurchaseRight.xaml
    /// </summary>
    public partial class BusinessAnalysisPurchaseRight : UserControl
    {
        public BusinessAnalysisPurchaseRight()
        {
            InitializeComponent();
            LoadDiagram2();
            LoadDiagram3();
        }

        public void LoadDiagram2()
        {
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            var legend = new Legend("Legend1");
            legend.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            legend.Docking = Docking.Top;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            chart2.Legends.Add(legend);
            chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart2.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart2.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);

            chart2.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart2.Series.Add(new Series() { Name = "Series3", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart2.Series[0].LegendText = "Оплата";
            chart2.Series[0].Color = System.Drawing.Color.FromArgb(49, 133, 156);

            chart2.Series[1].LegendText = "Закуп";
            chart2.Series[1].Color = System.Drawing.Color.FromArgb(228, 108, 10);

            chart2.Series[2].LegendText = "Продажи";
            chart2.Series[2].Color = System.Drawing.Color.FromArgb(10, 198, 28);

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
            chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            var legend = new Legend("Legend1");
            legend.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            legend.Docking = Docking.Top;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            chart3.Legends.Add(legend);
            chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart3.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            chart3.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);

            chart3.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });
            chart3.Series.Add(new Series() { Name = "Series2", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart3.Series[0].LegendText = "Закуп";
            chart3.Series[0].Color = System.Drawing.Color.FromArgb(228, 108, 10);

            chart3.Series[1].LegendText = "Оплачено";
            chart3.Series[1].Color = System.Drawing.Color.FromArgb(49, 133, 156);


            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Иванов", 1);
            seriesData1.Add("Петров", 2);
            seriesData1.Add("Сидоров", 3);
            seriesData1.Add("Чиж", 4);
            seriesData1.Add("Васин", 5);
            seriesData1.Add("Прочие", 6);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart3.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Иванов", 11);
            seriesData2.Add("Петров", 22);
            seriesData2.Add("Сидоров", 33);
            seriesData2.Add("Чиж", 44);
            seriesData2.Add("Васин", 55);
            seriesData2.Add("Прочие", 66);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart3.Series[1].Points.AddXY(data.Key, data.Value);
        }
    }
}
