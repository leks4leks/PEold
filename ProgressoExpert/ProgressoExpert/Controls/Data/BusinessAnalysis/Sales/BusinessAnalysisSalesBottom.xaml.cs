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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Sales
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisSalesBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisSalesBottom : UserControl
    {
        SalesBusinessAnalysis ViewModel;

        public BusinessAnalysisSalesBottom()
        {
            InitializeComponent();
        }

        public void DataBind(SalesBusinessAnalysis model)
        {
            ViewModel = (SalesBusinessAnalysis)model;
            this.DataContext = (SalesBusinessAnalysis)model;
            LoadDiagram();
            LoadDiagram2();
            LoadDiagram4();
            if (ViewModel.StructureGrossProfitClientInfo != null && ViewModel.StructureGrossProfitClientInfo.Count > 0)
            {
                UpdateTable();
            };
            UpdateColors();
        }

        public void LoadDiagram()
        {
            chart.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(string.Empty, ref chart, 0, 0, 1, 1, true, false, false, false);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                ViewModel.DynamicsSalesDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Оплаты", System.Drawing.Color.FromArgb(147, 169, 207),
                ViewModel.DynamicsPaymentDiagram, FormatUtils.Thousand, ref chart);
        }

        public void LoadDiagram2()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart2, 0, 0, 1, 1, true, false, false, false, 1, 0);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, ViewModel.Goods1Info.Name,
                System.Drawing.Color.FromArgb(127, 154, 72), ViewModel.Goods1Diagram, FormatUtils.Thousand, ref chart2);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, ViewModel.Goods2Info.Name,
                System.Drawing.Color.FromArgb(155, 187, 89), ViewModel.Goods2Diagram, FormatUtils.Thousand, ref chart2);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, ViewModel.Goods3Info.Name,
                System.Drawing.Color.FromArgb(198, 214, 172), ViewModel.Goods3Diagram, FormatUtils.Thousand, ref chart2);
        }

        public void LoadDiagram4()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart4);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref chart4);
            ChartUtils.AddLegend(StringAlignment.Center, Docking.Right, ref chart4);

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
                ChartUtils.AddPoint("Series1", item.Value, FormatUtils.Percentage, item.Key, color, ref chart4);
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
    }
}
