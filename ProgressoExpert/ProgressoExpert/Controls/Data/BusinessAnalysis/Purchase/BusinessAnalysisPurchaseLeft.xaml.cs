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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Purchase
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisPurchaseLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisPurchaseLeft : UserControl
    {
        PurchaseBusinessAnalysis ViewModel;

        public BusinessAnalysisPurchaseLeft()
        {
            InitializeComponent();
        }

        public void DataBind(PurchaseBusinessAnalysis model)
        {
            ViewModel = (PurchaseBusinessAnalysis)model;
            this.DataContext = (PurchaseBusinessAnalysis)model;
            LoadDiagram1(ref chart1);
        }

        public void LoadDiagram1(ref Chart _chart)
        {
            ChartUtils.AddChartArea(string.Empty, ref _chart, 0, 0, 1, 1, true, true, false, false);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, "Закуп", System.Drawing.Color.FromArgb(228, 108, 10),
                ViewModel.PurchaseByGoodsDiagram, FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Bar, "Продажи", System.Drawing.Color.FromArgb(10, 198, 28),
                ViewModel.salesByGoodsDiagram, FormatUtils.Thousand, ref _chart);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram1(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }
    }
}
