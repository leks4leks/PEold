using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;
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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Common
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisCommonBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisCommonBottom : UserControl
    {
        MainModel ViewModel;

        public BusinessAnalysisCommonBottom()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = (MainModel)model;
            this.DataContext = (GeneralBusinessAnalysis)model.GeneralBA;
            LoadDiagram(ref chart);
            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 0)
            {
                UpdateTable();
            }
        }

        public void LoadDiagram(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref _chart, 0, 0, 1, 0);

            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(186, 112, 50),
                DateUtils.ConvertToQuarter(ViewModel.GeneralBA.SalesDiagram, ViewModel), FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Средний оборотный капитал", System.Drawing.Color.FromArgb(149, 195, 213),
                DateUtils.ConvertToQuarter(ViewModel.GeneralBA.AverageWorkingCapitalDiagram, ViewModel), FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, "Чистая прибыль", System.Drawing.Color.FromArgb(249, 181, 144),
                DateUtils.ConvertToQuarter(ViewModel.GeneralBA.NetProfitDiagram, ViewModel), FormatUtils.Thousand, ref _chart);
        }

        public void UpdateTable()
        {
            var count = ViewModel.GeneralBA.ProfitabilityDiagram.Count;

            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 0)
            {
                ProductGroupLine1Tb.Text = count >= 1
                    ? ViewModel.GeneralBA.ProfitabilityDiagram[0].Name
                    : ViewModel.GeneralBA.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine1Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram[0].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 1)
            {
                ProductGroupLine2Tb.Text = count >= 2
                    ? ViewModel.GeneralBA.ProfitabilityDiagram[1].Name
                    : ViewModel.GeneralBA.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine2Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram[1].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 2)
            {
                ProductGroupLine3Tb.Text = count >= 3
                    ? ViewModel.GeneralBA.ProfitabilityDiagram[2].Name
                    : ViewModel.GeneralBA.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine3Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram[2].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 3)
            {
                ProductGroupLine4Tb.Text = count >= 4
                    ? ViewModel.GeneralBA.ProfitabilityDiagram[3].Name
                    : ViewModel.GeneralBA.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine4Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram[3].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 4)
            {
                ProductGroupLine5Tb.Text = count >= 5
                    ? ViewModel.GeneralBA.ProfitabilityDiagram[4].Name
                    : ViewModel.GeneralBA.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine5Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram[4].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.GeneralBA.ProfitabilityDiagram.Count > 5)
            {
                ProductGroupLine6Tb.Text = count >= 6
                    ? ViewModel.GeneralBA.ProfitabilityDiagram[5].Name
                    : ViewModel.GeneralBA.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine6Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram[5].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.GeneralBA.ProfitabilityDiagram.Last().Share);
            }
        }

        private void chart_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }
    }
}
