using ProgressoExpert.Controls.Utils;
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

        
        public BusinessAnalysisExpensesRight()
        {
            InitializeComponent();
        }

        public void DataBind(CostsBusinessAnalysis model)
        {
            ViewModel = (CostsBusinessAnalysis)model;
            this.DataContext = (CostsBusinessAnalysis)model;
            LoadDiagram2();
            LoadDiagram3();
            LoadDiagram4();
        }

        public void LoadDiagram2()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart2, 0, 0, 1, 1, true, true, false, false);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart2);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Расходы", System.Drawing.Color.FromArgb(170, 70, 67),
                ViewModel.CostsByMonthDiagram, string.Empty, ref chart2);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Валовая прибыль", System.Drawing.Color.FromArgb(209, 147, 146),
                ViewModel.GrosProfitDiagram, string.Empty, ref chart2);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                ViewModel.SalesDiagram, string.Empty, ref chart2);
        }


        public void LoadDiagram3()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart3);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart3);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref chart3);
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
                ChartUtils.AddPoint("Series1", item.Value, FormatUtils.Percentage, item.Key, color, ref chart3);
            }
        }

        public void LoadDiagram4()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart4);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart4);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref chart4);
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
                ChartUtils.AddPoint("Series1", item.Value, FormatUtils.Percentage, item.Key, color, ref chart4);
            }
        }
    }
}
