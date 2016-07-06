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
    /// Логика взаимодействия для BusinessAnalysisPurchaseRight.xaml
    /// </summary>
    public partial class BusinessAnalysisPurchaseRight : UserControl
    {
        PurchaseBusinessAnalysis ViewModel;

        public BusinessAnalysisPurchaseRight()
        {
            InitializeComponent();
        }

        public void DataBind(PurchaseBusinessAnalysis model)
        {
            ViewModel = (PurchaseBusinessAnalysis)model;
            this.DataContext = (PurchaseBusinessAnalysis)model;
            LoadDiagram2(ref chart2);
            LoadDiagram3(ref chart3);
            if (ViewModel.ClientDiagramInfo != null)
            {
                UpdateTable();
            }
            UpdateColors();
        }

        public void LoadDiagram2(ref Chart _chart)
        {
            chart2.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Оплата", System.Drawing.Color.FromArgb(49, 133, 156),
                ViewModel.PaymentDiagram, FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Закуп", System.Drawing.Color.FromArgb(228, 108, 10),
                ViewModel.PurchaseDiagram, FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(10, 198, 28),
                ViewModel.SalesDiagram, FormatUtils.Thousand, ref _chart);
        }

        public void LoadDiagram3(ref Chart _chart)
        {
            chart3.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Закуп", System.Drawing.Color.FromArgb(228, 108, 10),
                ViewModel.PurchaseByClientDiagram, FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Оплачено", System.Drawing.Color.FromArgb(49, 133, 156),
                ViewModel.PaymentByClientDiagram, FormatUtils.Thousand, ref _chart);
        }

        public void UpdateTable()
        {
            TableName1Tb.Text = ViewModel.ClientDiagramInfo[0].Name;
            TableShare1Tb.Text = string.Format("{0}%", ViewModel.ClientDiagramInfo[0].Share);

            TableName2Tb.Text = ViewModel.ClientDiagramInfo[1].Name;
            TableShare2Tb.Text = string.Format("{0}%", ViewModel.ClientDiagramInfo[1].Share);

            TableName3Tb.Text = ViewModel.ClientDiagramInfo[2].Name;
            TableShare3Tb.Text = string.Format("{0}%", ViewModel.ClientDiagramInfo[2].Share);

            TableName4Tb.Text = ViewModel.ClientDiagramInfo[3].Name;
            TableShare4Tb.Text = string.Format("{0}%", ViewModel.ClientDiagramInfo[3].Share);

            TableName5Tb.Text = ViewModel.ClientDiagramInfo[4].Name;
            TableShare5Tb.Text = string.Format("{0}%", ViewModel.ClientDiagramInfo[4].Share);

            TableName6Tb.Text = ViewModel.ClientDiagramInfo[5].Name;
            TableShare6Tb.Text = string.Format("{0}%", ViewModel.ClientDiagramInfo[5].Share);
        }

        private void UpdateColors()
        {
            difSalesvsPurchasePastPeriodTb.Style = ViewModel.difSalesvsPurchasePastPeriod >= 0
                ? (Style)FindResource("TextBlockStyle12Green0")
                : (Style)FindResource("TextBlockStyle12Red3");
        }

        private void chart2_Click_1(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram2(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }

        private void chart3_Click_1(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram3(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }
    }
}
