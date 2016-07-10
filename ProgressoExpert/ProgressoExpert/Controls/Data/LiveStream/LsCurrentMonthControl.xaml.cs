using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ProgressoExpert.Controls.Data.LiveStream
{
    /// <summary>
    /// Логика взаимодействия для LsTodayControl.xaml
    /// </summary>
    public partial class LsCurrentMonthControl : UserControl
    {
        LiveStreamModel ViewModel;

        public LsCurrentMonthControl()
        {
            InitializeComponent();
        }

        public void DataBind(LiveStreamModel model)
        {
            ViewModel = (LiveStreamModel)model;
            this.DataContext = (LiveStreamModel)model;
            if (ViewModel.CurrentMonthDiagram != null && ViewModel.LastMonthDiagram != null)
            {
                LoadDiagram(ref chart);
            }
            UpdateColors();
        }

        /// <summary>
        /// Текущий месяц vs Прошлый месяц
        /// </summary>
        public void LoadDiagram(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref _chart, 0, 0, 0, 0, true, true, true, false);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, "Прошлый месяц", System.Drawing.Color.FromArgb(250, 203, 180),
                ViewModel.CurrentMonthDiagram, FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Bar, "Текущий месяц", System.Drawing.Color.FromArgb(248, 170, 121),
                ViewModel.LastMonthDiagram, FormatUtils.Thousand, ref _chart);
        }

        public void UpdateColors()
        {
            AveragePaymentTb.Style = ViewModel.AveragePayment >= 0
                ? (Style)FindResource("TextBlock16BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock16BoldRed2CenterCenter");

            AverageGrossProfitTb.Style = ViewModel.AverageGrossProfit >= 0
                ? (Style)FindResource("TextBlock16BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock16BoldRed2CenterCenter");

            AverageSalesTb.Style = ViewModel.AverageSales >= 0
                ? (Style)FindResource("TextBlock16BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock16BoldRed2CenterCenter");
        }

        private void chart_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }
    }
}
