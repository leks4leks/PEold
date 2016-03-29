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
    public partial class LsCurrentMonthControl : UserControl
    {
        public LsCurrentMonthControl()
        {
            InitializeComponent();
        }

        private void WindowsFormsHost_Loaded_1(object sender, RoutedEventArgs e)
        {
            chart.ChartAreas.Add(new ChartArea("Default"));
            var legend = new Legend("Legend1");
            chart.Legends.Add(legend);

            chart.Series[0].LegendText = "Прошлый месяц";
            chart.Series[0].Color = System.Drawing.Color.FromArgb(250, 203, 180);

            chart.Series[1].LegendText = "Текущий месяц";
            chart.Series[1].Color = System.Drawing.Color.FromArgb(248, 170, 121);

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();

            seriesData1.Add("Продажи", 78000);
            seriesData1.Add("Валовая прибыль", 11000);
            seriesData1.Add("Оплата покупателя", 200000);

            foreach (KeyValuePair<string, int> data in seriesData1)
                chart.Series[0].Points.AddXY(data.Key, data.Value);

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();

            seriesData2.Add("Продажи", 52000);
            seriesData2.Add("Валовая прибыль", 3000);
            seriesData2.Add("Оплата покупателя", 20000);

            foreach (KeyValuePair<string, int> data in seriesData2)
                chart.Series[1].Points.AddXY(data.Key, data.Value);
        }
    }
}
