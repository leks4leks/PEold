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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Profit
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisProfitBottom.xaml
    /// </summary>
    public partial class BusinessAnalysisProfitBottom : UserControl
    {
        ProfitBusinessAnalysis ViewModel;

        public BusinessAnalysisProfitBottom()
        {
            InitializeComponent();
        }

        public void DataBind(ProfitBusinessAnalysis model)
        {
            ViewModel = (ProfitBusinessAnalysis)model;
            this.DataContext = (ProfitBusinessAnalysis)model;
            if (ViewModel.GrossProfitDiagram != null && ViewModel.NetProfitDiagram != null)
            {
                LoadDiagram();
            }
            if (ViewModel.GrossProfitabilityDiagram != null && ViewModel.NetProfitabilityDiagram != null)
            {
                LoadDiagram2();
            }
            if (ViewModel.StructureGrossProfitGoodsDiagram != null)
            {
                LoadDiagram3();
            }
            if (ViewModel.StructureGrossProfitClientDiagram != null)
            {
                LoadDiagram4();
            }
            if (ViewModel.StructureGrossProfitGoodsInfo != null && ViewModel.StructureGrossProfitGoodsInfo.Count > 0)
            {
                UpdateTable1();
            }
            if (ViewModel.StructureGrossProfitClientInfo != null && ViewModel.StructureGrossProfitClientInfo.Count > 0)
            {
                UpdateTable2();
            }
        }

        public void LoadDiagram()
        {
            ChartUtils.AddChartArea(FormatUtils.ThousandWithK, ref chart, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Валовая прибыль", System.Drawing.Color.FromArgb(65, 152, 175),
                ViewModel.GrossProfitDiagram, FormatUtils.Thousand, ref chart);

            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Чистая прибыль", System.Drawing.Color.FromArgb(145, 195, 213),
                ViewModel.NetProfitDiagram, FormatUtils.Thousand, ref chart);
        }

        public void LoadDiagram2()
        {
            ChartUtils.AddChartArea(FormatUtils.Percentage, ref chart2, 0, 0, 1);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Spline, "Валовая рентабельность",
                System.Drawing.Color.FromArgb(65, 152, 175), ViewModel.GrossProfitabilityDiagram, FormatUtils.Percentage, ref chart2);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Spline, "Чистая рентабельность",
                System.Drawing.Color.FromArgb(145, 195, 213), ViewModel.NetProfitabilityDiagram, FormatUtils.Percentage, ref chart2);
        }

        public void LoadDiagram3()
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref chart3, 0, 0, 1, 1, true, false, false, false);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, "Валовая прибыль по товарам",
                System.Drawing.Color.FromArgb(149, 179, 215), ViewModel.StructureGrossProfitGoodsDiagram, FormatUtils.Thousand,
                ref chart3);
        }

        public void LoadDiagram4()
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref chart4);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart4);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref chart4);

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
        /// Товары
        /// </summary>
        public void UpdateTable1()
        {
            Table1Name1Tb.Text = ViewModel.StructureGrossProfitGoodsInfo[0].Name;
            Table1Profitability1Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitGoodsInfo[0].Value);
            Table1Share1Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitGoodsInfo[0].Share);

            Table1Name2Tb.Text = ViewModel.StructureGrossProfitGoodsInfo[1].Name;
            Table1Profitability2Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitGoodsInfo[1].Value);
            Table1Share2Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitGoodsInfo[1].Share);

            Table1Name3Tb.Text = ViewModel.StructureGrossProfitGoodsInfo[2].Name;
            Table1Profitability3Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitGoodsInfo[2].Value);
            Table1Share3Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitGoodsInfo[2].Share);
        }

        /// <summary>
        /// Клиенты
        /// </summary>
        public void UpdateTable2()
        {
            Table2Name1Tb.Text = ViewModel.StructureGrossProfitClientInfo[0].Name;
            Table2Profitability1Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[0].Value);
            Table2Share1Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[0].Share);

            Table2Name2Tb.Text = ViewModel.StructureGrossProfitClientInfo[1].Name;
            Table2Profitability2Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[1].Value);
            Table2Share2Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[1].Share);

            Table2Name3Tb.Text = ViewModel.StructureGrossProfitClientInfo[2].Name;
            Table2Profitability3Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[2].Value);
            Table2Share3Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[2].Share);

            Table2Name4Tb.Text = ViewModel.StructureGrossProfitClientInfo[3].Name;
            Table2Profitability4Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[3].Value);
            Table2Share4Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[3].Share);

            Table2Name5Tb.Text = ViewModel.StructureGrossProfitClientInfo[4].Name;
            Table2Profitability5Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[4].Value);
            Table2Share5Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[4].Share);

            Table2Name6Tb.Text = ViewModel.StructureGrossProfitClientInfo[5].Name;
            Table2Profitability6Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[5].Value);
            Table2Share6Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[5].Share);
        }
    }
}
