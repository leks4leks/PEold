using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;
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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Expenses
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisExpensesRight.xaml
    /// </summary>
    public partial class BusinessAnalysisExpensesRight : UserControl
    {
        CostsBusinessAnalysis ViewModel;
        MainModel mainModel;

        
        public BusinessAnalysisExpensesRight()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = (CostsBusinessAnalysis)model.CostsBA;
            this.DataContext = (CostsBusinessAnalysis)model.CostsBA;
            mainModel = model;
            LoadDiagram2(ref chart2);
            LoadDiagram3(ref chart3);
            LoadDiagram4(ref chart4);
        }

        public void LoadDiagram2(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Расходы", System.Drawing.Color.FromArgb(170, 70, 67),
                DateUtils.ConvertToQuarter(ViewModel.CostsByMonthDiagram, mainModel), FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Валовая прибыль", System.Drawing.Color.FromArgb(209, 147, 146),
                DateUtils.ConvertToQuarter(ViewModel.GrosProfitDiagram, mainModel), FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                DateUtils.ConvertToQuarter(ViewModel.SalesDiagram, mainModel), FormatUtils.Thousand, ref _chart);

            ChartUtils.UpdateAxisTitle(true, mainModel.IsItQuarter, ref _chart);
        }

        public void LoadDiagram3(ref Chart _chart)
        {
            if (ViewModel.CostsCommingDiagram != null)
            {
                ChartUtils.AddChartArea(string.Empty, ref _chart);
                ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

                ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref _chart);
                var index = 1;
                foreach (var item in ViewModel.CostsCommingDiagram)
                {
                    System.Drawing.Color color;
                    switch (index)
                    {
                        case 1:
                            color = System.Drawing.Color.FromArgb(192, 80, 77);
                            break;
                        case 2:
                            color = System.Drawing.Color.FromArgb(179, 74, 71);
                            break;
                        case 3:
                            color = System.Drawing.Color.FromArgb(202, 126, 125);
                            break;
                        case 4:
                            color = System.Drawing.Color.FromArgb(221, 182, 181);
                            break;
                        default:
                            color = System.Drawing.Color.Red;
                            break;

                    };
                    index++;
                    ChartUtils.AddPoint("Series1", item.Value, FormatUtils.Percentage, item.Key, color, ref _chart);
                }
            }
        }

        public void LoadDiagram4(ref Chart _chart)
        {
            if (ViewModel.CostsOutDiagram != null)
            {
                ChartUtils.AddChartArea(string.Empty, ref _chart);
                ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

                ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref _chart);
                var index = 1;
                foreach (var item in ViewModel.CostsOutDiagram)
                {
                    System.Drawing.Color color;
                    switch (index)
                    {
                        case 1:
                            color = System.Drawing.Color.FromArgb(192, 80, 77);
                            break;
                        case 2:
                            color = System.Drawing.Color.FromArgb(179, 74, 71);
                            break;
                        case 3:
                            color = System.Drawing.Color.FromArgb(202, 126, 125);
                            break;
                        case 4:
                            color = System.Drawing.Color.FromArgb(221, 182, 181);
                            break;
                        default:
                            color = System.Drawing.Color.Red;
                            break;

                    };
                    index++;
                    ChartUtils.AddPoint("Series1", item.Value, FormatUtils.Percentage, item.Key, color, ref _chart);
                }
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram2(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }

        private void chart3_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram3(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }

        private void chart4_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram4(ref ChartViewWindow.chart);
            ChartViewWindow.AddLegend();
            ChartViewWindow.Show();
        }
    }
}
