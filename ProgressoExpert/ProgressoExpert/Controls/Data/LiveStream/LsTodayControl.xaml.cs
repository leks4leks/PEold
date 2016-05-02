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
                LoadDiagram();
            }
        }

        /// <summary>
        /// Диаграмма Деньги в кассе / Деньги на счетах
        /// </summary>
        public void LoadDiagram()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart);
            
            ChartUtils.AddSeries("Series1", SeriesChartType.Doughnut, ref chart);

            ChartUtils.AddPoint("Series1", ViewModel.CycleMoneyDiagram["Деньги в кассе"], FormatUtils.Thousand, "Деньги в кассе",
                System.Drawing.Color.FromArgb(137, 165, 78), ref chart);
            ChartUtils.AddPoint("Series1", ViewModel.CycleMoneyDiagram["Деньги на счетах"], FormatUtils.Thousand, "Деньги на счетах",
                System.Drawing.Color.FromArgb(185, 205, 150), ref chart);
        }
    }
}
