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
    /// Логика взаимодействия для BusinessAnalysisExpensesLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisExpensesLeft : UserControl
    {
        public BusinessAnalysisExpensesLeft()
        {
            InitializeComponent();
            LoadDiagram1();
        }

        public void LoadDiagram1()
        {
            chart1.ChartAreas.Add(new ChartArea("Default"));
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            chart1.Series.Add(new Series() { Name = "Series1", ChartType = SeriesChartType.Column, IsValueShownAsLabel = true });

            chart1.Series[0].LegendText = "Валовая прибыль по товарам";
            chart1.Series[0].Color = System.Drawing.Color.FromArgb(149, 55, 53);
            chart1.Series[0].ChartType = SeriesChartType.Bar;

            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.LineWidth = 0;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Шины", 38000000);
            seriesData1.Add("Админ-ые", 3500000);
            seriesData1.Add("По реализации", 700000);
            seriesData1.Add("Бонусы", 800000);
            seriesData1.Add("Прочие", 150000);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart1.Series[0].Points.AddXY(data.Key, data.Value);
        }
    }
}
