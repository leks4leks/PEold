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
using System.Drawing;
using System.Globalization;
using ProgressoExpert.Models.Models.BusinessAnalysis;
using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Sales
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisSalesBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisSalesBottom : UserControl
    {
        SalesBusinessAnalysis ViewModel;
        MainModel mainModel;

        public BusinessAnalysisSalesBottom()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = (SalesBusinessAnalysis)model.SalesBA;
            this.DataContext = (SalesBusinessAnalysis)model.SalesBA;
            mainModel = model;
            LoadDiagram(ref chart);
            LoadDiagram2(ref chart2);
            LoadDiagram4(ref chart4);
            if (ViewModel.StructureGrossProfitClientInfo != null && ViewModel.StructureGrossProfitClientInfo.Count > 0)
            {
                UpdateTable();
            };
            UpdateColors();
        }

        public void LoadDiagram(ref Chart _chart)
        {
            chart.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(string.Empty, ref _chart, 0, 0, 1, 1, true, false, false, false);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                DateUtils.ConvertToQuarter(ViewModel.DynamicsSalesDiagram, mainModel), FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Оплаты", System.Drawing.Color.FromArgb(147, 169, 207),
                DateUtils.ConvertToQuarter(ViewModel.DynamicsPaymentDiagram, mainModel), FormatUtils.Thousand, ref _chart);
        }

        public void LoadDiagram2(ref Chart _chart)
        {
            ChartUtils.AddChartArea(string.Empty, ref _chart, 0, 0, 1, 1, true, false, false, false, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, ViewModel.Goods1Info.Name,
                System.Drawing.Color.FromArgb(127, 154, 72), DateUtils.ConvertToQuarter(ViewModel.Goods1Diagram, mainModel), 
                FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, ViewModel.Goods2Info.Name,
                System.Drawing.Color.FromArgb(155, 187, 89), DateUtils.ConvertToQuarter(ViewModel.Goods2Diagram, mainModel), 
                FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, ViewModel.Goods3Info.Name,
                System.Drawing.Color.FromArgb(198, 214, 172), DateUtils.ConvertToQuarter(ViewModel.Goods3Diagram, mainModel), 
                FormatUtils.Thousand, ref _chart);
        }

        public void LoadDiagram4(ref Chart _chart)
        {
            ChartUtils.AddChartArea(string.Empty, ref _chart);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref _chart);
            ChartUtils.AddLegend(StringAlignment.Center, Docking.Right, ref _chart);

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
        /// Клиенты
        /// </summary>
        public void UpdateTable()
        {
            Table2Name1Tb.Text = ViewModel.StructureGrossProfitClientInfo[0].Name;
            Table2Sales1Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[0].Value);
            Table2Payment1Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[0].Value2);

            Table2Name2Tb.Text = ViewModel.StructureGrossProfitClientInfo[1].Name;
            Table2Sales2Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[1].Value);
            Table2Payment2Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[1].Value2);

            Table2Name3Tb.Text = ViewModel.StructureGrossProfitClientInfo[2].Name;
            Table2Sales3Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[2].Value);
            Table2Payment3Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[2].Value2);

            Table2Name4Tb.Text = ViewModel.StructureGrossProfitClientInfo[3].Name;
            Table2Sales4Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[3].Value);
            Table2Payment4Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[3].Value2);

            Table2Name5Tb.Text = ViewModel.StructureGrossProfitClientInfo[4].Name;
            Table2Sales5Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[4].Value);
            Table2Payment5Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[4].Value2);

            Table2Name6Tb.Text = ViewModel.StructureGrossProfitClientInfo[5].Name;
            Table2Sales6Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[5].Value);
            Table2Payment6Tb.Text = string.Format(FormatUtils.Thousand, ViewModel.StructureGrossProfitClientInfo[5].Value2);
        }

        public void UpdateColors()
        {
            Goods1InfoPercentTb.Style = ViewModel.Goods1Info.Percent >= 0
                ? (Style)FindResource("TextBlock15BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock15BoldRed3CenterCenter");

            Goods2InfoPercentTb.Style = ViewModel.Goods2Info.Percent >= 0
                ? (Style)FindResource("TextBlock15BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock15BoldRed3CenterCenter");

            Goods3InfoPercentTb.Style = ViewModel.Goods3Info.Percent >= 0
                ? (Style)FindResource("TextBlock15BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock15BoldRed3CenterCenter");
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram2(ref ChartViewWindow.chart);
            ChartViewWindow.Show();
        }

        private void chart_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var ChartViewWindow = new ChartViewWindow(mainWindow);
            LoadDiagram(ref ChartViewWindow.chart);
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
