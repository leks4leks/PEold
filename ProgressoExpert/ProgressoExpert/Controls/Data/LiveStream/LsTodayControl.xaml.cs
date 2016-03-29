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

namespace ProgressoExpert.Controls.Data.LiveStream
{
    /// <summary>
    /// Логика взаимодействия для LsTodayControl.xaml
    /// </summary>
    public partial class LsTodayControl : UserControl
    {
        public LsTodayControl()
        {
            InitializeComponent();
        }

        private void WindowsFormsHost_Loaded_1(object sender, RoutedEventArgs e)
        {
            chart.ChartAreas.Add(new ChartArea("Default"));
            chart.IsSoftShadows = false;

            var legend = new Legend("Legend1");
            var series = new Series("Series1");
            series.ShadowColor = System.Drawing.Color.Black;
            series.ShadowOffset = 1;

            series.ChartType = SeriesChartType.Doughnut;
            series.ChartArea = "Default";
            series.Legend = "Legend1";

            series.Points.Add(new DataPoint() 
            { 
                Label = "3000", 
                XValue = 3000, 
                YValues = new double[] { 3000 }, 
                LegendText = "Деньги в кассе",
                Color = System.Drawing.Color.FromArgb(137, 165, 78),
                BorderColor = System.Drawing.Color.White
            });
            series.Points.Add(new DataPoint()
            {
                Label = "7000",
                XValue = 7000,
                YValues = new double[] { 7000 },
                LegendText = "Деньги на счетах",
                Color = System.Drawing.Color.FromArgb(155, 187, 89),
                BorderColor = System.Drawing.Color.White
            });

            chart.Series.Add(series);
            chart.Legends.Add(legend);
            chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;

            //Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            //seriesData1.Add("Деньги в кассе", 7000);
            //seriesData1.Add("Деньги на счетах", 3000);

            //foreach (KeyValuePair<string, int> data in seriesData1)
            //    chart.Series[0].Points.AddXY(data.Key, data.Value);



        }
    }
}
