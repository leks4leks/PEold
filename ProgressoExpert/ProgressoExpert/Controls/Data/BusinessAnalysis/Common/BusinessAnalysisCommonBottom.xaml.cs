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
            if (ViewModel.gSales.Count > 0)
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
            var count = ViewModel.gSales.Count;

            ProductGroupLine1Tb.Text = count >= 1
                ? ViewModel.gSales[0].GroupName
                : ViewModel.gSales.Last().GroupName;
            ProductGroupValueLine1Tb.Text = count >= 1
                ? String.Format(FormatUtils.Percentage, ViewModel.gSales[0].GroupName)
                : String.Format(FormatUtils.Percentage, ViewModel.gSales.Last().GroupName);


            ProductGroupLine2Tb.Text = count >= 2
                ? ViewModel.gSales[1].GroupName
                : ViewModel.gSales.Last().GroupName;
            ProductGroupValueLine2Tb.Text = count >= 1
                ? String.Format(FormatUtils.Percentage, ViewModel.gSales[1].GroupName)
                : String.Format(FormatUtils.Percentage, ViewModel.gSales.Last().GroupName);


            ProductGroupLine3Tb.Text = count >= 3
                ? ViewModel.gSales[2].GroupName
                : ViewModel.gSales.Last().GroupName;
            ProductGroupValueLine3Tb.Text = count >= 1
                ? String.Format(FormatUtils.Percentage, ViewModel.gSales[2].GroupName)
                : String.Format(FormatUtils.Percentage, ViewModel.gSales.Last().GroupName);


            ProductGroupLine4Tb.Text = count >= 4
                ? ViewModel.gSales[3].GroupName
                : ViewModel.gSales.Last().GroupName;
            ProductGroupValueLine4Tb.Text = count >= 1
                ? String.Format(FormatUtils.Percentage, ViewModel.gSales[3].GroupName)
                : String.Format(FormatUtils.Percentage, ViewModel.gSales.Last().GroupName);


            ProductGroupLine5Tb.Text = count >= 5
                ? ViewModel.gSales[4].GroupName
                : ViewModel.gSales.Last().GroupName;
            ProductGroupValueLine5Tb.Text = count >= 1
                ? String.Format(FormatUtils.Percentage, ViewModel.gSales[4].GroupName)
                : String.Format(FormatUtils.Percentage, ViewModel.gSales.Last().GroupName);


            ProductGroupLine6Tb.Text = count >= 6
                ? ViewModel.gSales[5].GroupName
                : ViewModel.gSales.Last().GroupName;
            ProductGroupValueLine6Tb.Text = count >= 1
                ? String.Format(FormatUtils.Percentage, ViewModel.gSales[5].GroupName)
                : String.Format(FormatUtils.Percentage, ViewModel.gSales.Last().GroupName);
        }
    }
}
