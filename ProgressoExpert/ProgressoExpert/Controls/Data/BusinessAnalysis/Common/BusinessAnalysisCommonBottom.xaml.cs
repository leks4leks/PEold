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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Common
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisCommonBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisCommonBottom : UserControl
    {
        GeneralBusinessAnalysis ViewModel;

        public BusinessAnalysisCommonBottom()
        {
            InitializeComponent();
        }

        public void DataBind(GeneralBusinessAnalysis model)
        {
            ViewModel = (GeneralBusinessAnalysis)model;
            this.DataContext = (GeneralBusinessAnalysis)model;
            LoadDiagram();
            if (ViewModel.ProfitabilityDiagram.Count > 0)
            {
                UpdateTable();
            }
        }

        public void LoadDiagram()
        {
            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref chart, 0, 0, 1, 0);

            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "КЗ Продажи", System.Drawing.Color.FromArgb(186, 112, 50),
                ViewModel.SalesDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "ОК Средний остаток", System.Drawing.Color.FromArgb(149, 195, 213),
                ViewModel.AverageWorkingCapitalDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, "0 Чистая прибыль", System.Drawing.Color.FromArgb(249, 181, 144),
                ViewModel.NetProfitDiagram, FormatUtils.Thousand, ref chart);
        }

        public void UpdateTable()
        {
            var count = ViewModel.ProfitabilityDiagram.Count;

            if (ViewModel.ProfitabilityDiagram.Count > 0)
            {
                ProductGroupLine1Tb.Text = count >= 1
                    ? ViewModel.ProfitabilityDiagram[0].Name
                    : ViewModel.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine1Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram[0].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.ProfitabilityDiagram.Count > 1)
            {
                ProductGroupLine2Tb.Text = count >= 2
                    ? ViewModel.ProfitabilityDiagram[1].Name
                    : ViewModel.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine2Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram[1].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.ProfitabilityDiagram.Count > 2)
            {
                ProductGroupLine3Tb.Text = count >= 3
                    ? ViewModel.ProfitabilityDiagram[2].Name
                    : ViewModel.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine3Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram[2].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.ProfitabilityDiagram.Count > 3)
            {
                ProductGroupLine4Tb.Text = count >= 4
                    ? ViewModel.ProfitabilityDiagram[3].Name
                    : ViewModel.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine4Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram[3].Name)
                    : String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram.Last().Name);
            }

            if (ViewModel.ProfitabilityDiagram.Count > 4)
            {
                ProductGroupLine5Tb.Text = count >= 5
                    ? ViewModel.ProfitabilityDiagram[4].Name
                    : ViewModel.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine5Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram[4].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram.Last().Share);
            }

            if (ViewModel.ProfitabilityDiagram.Count > 5)
            {
                ProductGroupLine6Tb.Text = count >= 6
                    ? ViewModel.ProfitabilityDiagram[5].Name
                    : ViewModel.ProfitabilityDiagram.Last().Name;
                ProductGroupValueLine6Tb.Text = count >= 1
                    ? String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram[5].Share)
                    : String.Format(FormatUtils.Percentage, ViewModel.ProfitabilityDiagram.Last().Share);
            }
        }
    }
}
