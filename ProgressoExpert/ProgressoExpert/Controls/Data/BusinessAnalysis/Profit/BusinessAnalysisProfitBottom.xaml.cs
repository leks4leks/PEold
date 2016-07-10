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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Profit
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisProfitBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisProfitBottom : UserControl
    {
        ProfitBusinessAnalysis ViewModel;
        MainModel mainModel;

        public BusinessAnalysisProfitBottom()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = (ProfitBusinessAnalysis)model.ProfitBA;
            mainModel = model;
            this.DataContext = (ProfitBusinessAnalysis)ViewModel;
            LoadDiagram(ref chart);
            LoadDiagram2(ref chart2);
            LoadDiagram3(ref chart3);
            LoadDiagram4(ref chart4);
            if (ViewModel.StructureGrossProfitGoodsInfo != null && ViewModel.StructureGrossProfitGoodsInfo.Count > 0)
            {
                UpdateTable1();
            }
            if (ViewModel.StructureGrossProfitClientInfo != null && ViewModel.StructureGrossProfitClientInfo.Count > 0)
            {
                UpdateTable2();
            }
        }

        public void LoadDiagram(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref _chart, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Валовая прибыль", System.Drawing.Color.FromArgb(65, 152, 175),
                DateUtils.ConvertToQuarter(ViewModel.GrossProfitDiagram, mainModel), FormatUtils.Thousand, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Чистая прибыль", System.Drawing.Color.FromArgb(145, 195, 213),
                DateUtils.ConvertToQuarter(ViewModel.NetProfitDiagram, mainModel), FormatUtils.Thousand, ref _chart);
        }

        public void LoadDiagram2(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.Percentage, ref _chart, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Spline, "Валовая рентабельность",
                System.Drawing.Color.FromArgb(65, 152, 175), DateUtils.ConvertToQuarter(ViewModel.GrossProfitabilityDiagram, mainModel), 
                FormatUtils.Percentage, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Spline, "Чистая рентабельность",
                System.Drawing.Color.FromArgb(145, 195, 213), DateUtils.ConvertToQuarter(ViewModel.NetProfitabilityDiagram, mainModel), 
                FormatUtils.Percentage, ref _chart);
        }

        public void LoadDiagram3(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart, 0, 0, 1, 1, true, false, false, false, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, "Валовая прибыль по товарам",
                System.Drawing.Color.FromArgb(149, 179, 215), ViewModel.StructureGrossProfitGoodsDiagram, FormatUtils.Thousand,
                ref _chart);
        }

        public void LoadDiagram4(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref _chart);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref _chart);

            var index = 1;
            foreach (var item in ViewModel.StructureGrossProfitClientDiagram)
            {
                System.Drawing.Color color;
                switch (index)
                {
                    case 1:
                        color = System.Drawing.Color.FromArgb(69, 114, 167);
                        break;
                    case 2:
                        color = System.Drawing.Color.FromArgb(170, 70, 67);
                        break;
                    case 3:
                        color = System.Drawing.Color.FromArgb(137, 165, 78);
                        break;
                    case 4:
                        color = System.Drawing.Color.FromArgb(113, 88, 143);
                        break;
                    case 5:
                        color = System.Drawing.Color.FromArgb(65, 152, 175);
                        break;
                    case 6:
                        color = System.Drawing.Color.FromArgb(219, 132, 61);
                        break;
                    default:
                        color = System.Drawing.Color.Red;
                        break;

                };
                index++;
                ChartUtils.AddPoint("Series1", item.Value, FormatUtils.Percentage, item.Key, color, ref _chart);
            }
        }
        
        /// <summary>
        /// Товары
        /// </summary>
        public void UpdateTable1()
        {
            Table1Name1Tb.Text = ViewModel.StructureGrossProfitGoodsInfo[0].Name;
            Table1Profitability1Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitGoodsInfo[0].Value);
            Table1Share1Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitGoodsInfo[0].Share);

            Table1Name2Tb.Text = ViewModel.StructureGrossProfitGoodsInfo[1].Name;
            Table1Profitability2Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitGoodsInfo[1].Value);
            Table1Share2Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitGoodsInfo[1].Share);

            Table1Name3Tb.Text = ViewModel.StructureGrossProfitGoodsInfo[2].Name;
            Table1Profitability3Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitGoodsInfo[2].Value);
            Table1Share3Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitGoodsInfo[2].Share);
        }

        /// <summary>
        /// Клиенты
        /// </summary>
        public void UpdateTable2()
        {
            Table2Name1Tb.Text = ViewModel.StructureGrossProfitClientInfo[0].Name;
            Table2Profitability1Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[0].Value);
            Table2Share1Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[0].Share);

            if (ViewModel.StructureGrossProfitClientInfo.Count() > 1)
            {
                Table2Name2Tb.Text = ViewModel.StructureGrossProfitClientInfo[1].Name;
                Table2Profitability2Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[1].Value);
                Table2Share2Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[1].Share);
            }

            if (ViewModel.StructureGrossProfitClientInfo.Count() > 2)
            {
                Table2Name3Tb.Text = ViewModel.StructureGrossProfitClientInfo[2].Name;
                Table2Profitability3Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[2].Value);
                Table2Share3Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[2].Share);
            }

            if (ViewModel.StructureGrossProfitClientInfo.Count() > 3)
            {
                Table2Name4Tb.Text = ViewModel.StructureGrossProfitClientInfo[3].Name;
                Table2Profitability4Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[3].Value);
                Table2Share4Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[3].Share);
            }

            if (ViewModel.StructureGrossProfitClientInfo.Count() > 4)
            {
                Table2Name5Tb.Text = ViewModel.StructureGrossProfitClientInfo[4].Name;
                Table2Profitability5Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[4].Value);
                Table2Share5Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[4].Share);
            }

            if (ViewModel.StructureGrossProfitClientInfo.Count() > 5)
            {
                Table2Name6Tb.Text = ViewModel.StructureGrossProfitClientInfo[5].Name;
                Table2Profitability6Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[5].Value);
                Table2Share6Tb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureGrossProfitClientInfo[5].Share);
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram2(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }

        private void chart3_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram3(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }

        private void chart4_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram4(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }
    }
}
