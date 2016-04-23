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
                LoadDiagram();
            }
            UpdateColors();
        }

        /// <summary>
        /// Текущий месяц vs Прошлый месяц
        /// </summary>
        public void LoadDiagram()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisY.LabelStyle.Format = "# ##0,тыс";
            chart.ChartAreas.Add(chartArea);

            var legend = new Legend()
            {
                Name = "Legend",
                Alignment = System.Drawing.StringAlignment.Center,
                Docking = Docking.Right,
                Font = new System.Drawing.Font("Arial", 10)
            };
            chart.Legends.Add(legend);

            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Bar,
                ChartArea = chartArea.Name,
                Legend = legend.Name,
                LegendText = "Прошлый месяц",
                Color = System.Drawing.Color.FromArgb(250, 203, 180),
                BorderColor = System.Drawing.Color.White,
                IsValueShownAsLabel = true
            };

            foreach (KeyValuePair<string, decimal> data in ViewModel.CurrentMonthDiagram)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N2}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }

            chart.Series.Add(series);

            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Bar,
                ChartArea = chartArea.Name,
                Legend = legend.Name,
                LegendText = "Текущий месяц",
                Color = System.Drawing.Color.FromArgb(248, 170, 121),
                BorderColor = System.Drawing.Color.White,
                IsValueShownAsLabel = true
            };

            foreach (KeyValuePair<string, decimal> data in ViewModel.LastMonthDiagram)
            {
                series2.Points.AddXY(data.Key, data.Value);
                var _point = series2.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N2}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }

            chart.Series.Add(series2);
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
    }
}
