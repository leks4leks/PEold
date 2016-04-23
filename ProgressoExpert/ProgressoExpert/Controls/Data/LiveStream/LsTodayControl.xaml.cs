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
            var chartArea = new ChartArea() { Name = "ChartArea" };
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
                ChartType = SeriesChartType.Doughnut,
                ChartArea = chartArea.Name,
                Legend = legend.Name
            };
            chart.Series.Add(series);

            var dataPointData = ViewModel.CycleMoneyDiagram["Деньги в кассе"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N2}", dataPointData),
                Font = new System.Drawing.Font("Arial", 10),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Деньги в кассе",
                Color = System.Drawing.Color.FromArgb(137, 165, 78),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = ViewModel.CycleMoneyDiagram["Деньги на счетах"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N2}", dataPointData),
                Font = new System.Drawing.Font("Arial", 10),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Деньги на счетах",
                Color = System.Drawing.Color.FromArgb(185, 205, 150),
                BorderColor = System.Drawing.Color.White
            });
        }
    }
}
