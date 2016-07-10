using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models.BusinessAnalysis;
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
        WorkingСapitalBusinessAnalysis ViewModel;

        public BusinessAnalysisWorkingCapitalLeft()
        {
            InitializeComponent();
        }

        public void DataBind(WorkingСapitalBusinessAnalysis model)
        {
            ViewModel = (WorkingСapitalBusinessAnalysis)model;
            this.DataContext = (WorkingСapitalBusinessAnalysis)model;
            LoadDiagram(ref chart);
            LoadDiagram2(ref chart2);
            UpdateColors();
        }

        public void LoadDiagram(ref Chart _chart)
        {
            chart.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart, 0, 0, 1, 0, true, false, false, false, 1, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.StackedColumn, "СОК", System.Drawing.Color.FromArgb(96, 74, 123),
                ViewModel.stSokDiagram, FormatUtils.Thousand, ref _chart, false);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.StackedColumn, "Прибыль", System.Drawing.Color.FromArgb(10, 198, 28),
                ViewModel.profit, FormatUtils.Thousand, ref _chart, false);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.StackedColumn, "Задолженность", System.Drawing.Color.FromArgb(204, 193, 218),
                ViewModel.stDebtsDiagram, FormatUtils.Thousand, ref _chart, false);
        }

        public void LoadDiagram2(ref Chart _chart)
        {
            chart2.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart, 0, 0, 1, 0, true, false, false, false, 1, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, string.Empty, System.Drawing.Color.FromArgb(79, 129, 189),
                ViewModel.turnoverDiagram, FormatUtils.IntNumber, ref _chart);
        }

        private void chart_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram2(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }

        private void UpdateColors()
        {
            difmyMoneyByPercentTb.Style = ViewModel.difmyMoneyByPercent >= 0
                ? (Style)FindResource("TextBlockStyle14Green0")
                : (Style)FindResource("TextBlockStyle14Red3");
            difmyCostsByPercentTb.Style = ViewModel.difmyCostsByPercent >= 0
                ? (Style)FindResource("TextBlockStyle14Green0")
                : (Style)FindResource("TextBlockStyle14Red3");
        }
    }
}
