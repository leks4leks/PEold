using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models.BusinessAnalysis;
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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Expenses
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisExpensesLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisExpensesLeft : UserControl
    {
        CostsBusinessAnalysis ViewModel;

        public BusinessAnalysisExpensesLeft()
        {
            InitializeComponent();
        }

        public void DataBind(CostsBusinessAnalysis model)
        {
            ViewModel = (CostsBusinessAnalysis)model;
            this.DataContext = (CostsBusinessAnalysis)model;
            LoadDiagram1(ref chart1);
        }

        public void LoadDiagram1(ref Chart _chart)
        {
            ChartUtils.AddChartArea(string.Empty, ref _chart, 0, 0, 1, 1, true, false, false, false, 0);
            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, "Валовая прибыль по товарам",
                System.Drawing.Color.FromArgb(149, 55, 53), ViewModel.CostsDiagram, FormatUtils.Thousand, ref _chart);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            ChartViewWindow.AddLegend();
            LoadDiagram1(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }
    }
}
