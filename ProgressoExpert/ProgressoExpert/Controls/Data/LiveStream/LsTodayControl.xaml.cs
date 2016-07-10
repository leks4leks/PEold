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
    public partial class LsTodayControl : UserControl
    {
        LiveStreamModel ViewModel;

        public LsTodayControl()
        {
            InitializeComponent();
        }

        public void DataBind(LiveStreamModel model)
        {
            ViewModel = (LiveStreamModel)model;
            this.DataContext = (LiveStreamModel)model;
            if (ViewModel.CycleMoneyDiagram != null)
            {
                LoadDiagram(ref chart);
            }
        }

        /// <summary>
        /// Диаграмма Деньги в кассе / Деньги на счетах
        /// </summary>
        public void LoadDiagram(ref Chart _chart)
        {
            ChartUtils.AddChartArea(string.Empty, ref _chart);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

            ChartUtils.AddSeries("Series1", SeriesChartType.Doughnut, ref _chart);

            ChartUtils.AddPoint("Series1", ViewModel.CycleMoneyDiagram["Деньги в кассе"], FormatUtils.Thousand, "Деньги в кассе",
                System.Drawing.Color.FromArgb(137, 165, 78), ref _chart);
            ChartUtils.AddPoint("Series1", ViewModel.CycleMoneyDiagram["Деньги на счетах"], FormatUtils.Thousand, "Деньги на счетах",
                System.Drawing.Color.FromArgb(185, 205, 150), ref _chart);
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
