using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;
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

namespace ProgressoExpert.Controls.Data.StressTesting
{
    /// <summary>
    /// Логика взаимодействия для StressTestingGeneralControl.xaml
    /// </summary>
    public partial class StressTestingGeneralControl : UserControl
    {
        StressTestingModel ViewModel;

        public StressTestingGeneralControl()
        {
            InitializeComponent();
        }

        public void DataBind(StressTestingModel model)
        {
            ViewModel = model;
            DataContext = model;

            ViewModel.CalculateAll();

            LoadDiagramm(ref chart);
            LoadDiagramm2(ref chart2);
            LoadDiagramm3(ref chart3);
        }

        private void LoadDiagramm(ref Chart _chart)
        {
            ChartUtils.ClearChart(ref _chart);

            var data = new Dictionary<string, decimal>();
            data.Add("Факт", ViewModel.Sales);
            data.Add("Прогноз", ViewModel.SalesForecast);

            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref _chart, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                data, FormatUtils.Thousand, ref _chart);
        }

        private void LoadDiagramm2(ref Chart _chart)
        {
            ChartUtils.ClearChart(ref _chart);

            var data = new Dictionary<string, decimal>();
            data.Add("Факт", ViewModel.GrossProfit);
            data.Add("Прогноз", ViewModel.GrossProfitForecast);

            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref _chart, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Валовая прибыль", System.Drawing.Color.FromArgb(52, 148, 195),
                data, FormatUtils.Thousand, ref _chart);
        }

        private void LoadDiagramm3(ref Chart _chart)
        {
            ChartUtils.ClearChart(ref _chart);

            var data = new Dictionary<string, decimal>();
            data.Add("Факт", ViewModel.NetProfit);
            data.Add("Прогноз", ViewModel.NetProfitForecast);

            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref _chart, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Чистая прибыль", System.Drawing.Color.FromArgb(149, 55, 53),
                data, FormatUtils.Thousand, ref _chart);
        }


        private void TextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                int tmp = 0;
                Int32.TryParse(tbSalesGeneralPercentage.Text, out tmp);
                ViewModel.SalesGeneralPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbSalesTop3ClientsPercentage.Text, out tmp);
                ViewModel.SalesTop3ClientsPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbSalesTopProductPercentage.Text, out tmp);
                ViewModel.SalesTopProductPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbSalesTop3ProductsPercentage.Text, out tmp);
                ViewModel.SalesTop3ProductsPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbProfitabilityGeneralPercentage.Text, out tmp);
                ViewModel.ProfitabilityGeneralPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbProfitabilityTop3ClientsPercentage.Text, out tmp);
                ViewModel.ProfitabilityTop3ClientsPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbProfitabilityTopProductPercentage.Text, out tmp);
                ViewModel.ProfitabilityTopProductPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbProfitabilityTop3ProductsPercentage.Text, out tmp);
                ViewModel.ProfitabilityTop3ProductsPercentage = tmp;

                tmp = 0;
                Int32.TryParse(tbExpensesPercentage.Text, out tmp);
                ViewModel.ExpensesPercentage = tmp;

                ViewModel.CalculateAll();

                LoadDiagramm(ref chart);
                LoadDiagramm2(ref chart2);
                LoadDiagramm3(ref chart3);
            }
            catch
            {
                MessageBox.Show("Отсутствуют данные.", "Информация");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbSalesGeneralPercentage.Text =
                tbSalesTop3ClientsPercentage.Text =
                tbSalesTopProductPercentage.Text =
                tbSalesTop3ProductsPercentage.Text =
                tbProfitabilityGeneralPercentage.Text =
                tbProfitabilityTop3ClientsPercentage.Text =
                tbProfitabilityTopProductPercentage.Text =
                tbProfitabilityTop3ProductsPercentage.Text =
                tbExpensesPercentage.Text = "0";
            TextBox_KeyUp_1(this, null);
        }
    }
}
