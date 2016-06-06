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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.WorkingCapital
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisWorkingCapitalRight.xaml
    /// </summary>
    public partial class BusinessAnalysisWorkingCapitalRight : UserControl
    {
        WorkingСapitalBusinessAnalysis ViewModel;

        public BusinessAnalysisWorkingCapitalRight()
        {
            InitializeComponent();
        }

        public void DataBind(WorkingСapitalBusinessAnalysis model)
        {
            ViewModel = (WorkingСapitalBusinessAnalysis)model;
            this.DataContext = (WorkingСapitalBusinessAnalysis)model;
            LoadDiagram();
            LoadDiagram2();
        }


        public void LoadDiagram()
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref chart, 0, 0, 1, 0, true, false, false, false, 0, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.StackedColumn, "ДЗ Средний долг",
                System.Drawing.Color.FromArgb(128, 100, 162), ViewModel.aveDZDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.StackedColumn, "Товары средний остаток",
                System.Drawing.Color.FromArgb(170, 186, 215), ViewModel.aveGoodsDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.StackedColumn, "Деньги средний остаток",
                System.Drawing.Color.FromArgb(186, 176, 201), ViewModel.aveMoneyDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series4", SeriesChartType.StackedColumn, "Продажи",
                System.Drawing.Color.FromArgb(60, 103, 154), ViewModel.aveSalesDiagram, FormatUtils.Thousand, ref chart);
        }

        public void LoadDiagram2()
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref chart2, 0, 0, 1, 0, true, false, false, false, 0, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref chart2);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "КЗ Средний долг",
                System.Drawing.Color.FromArgb(128, 100, 162), ViewModel.KZ_dzVsKzDiagram, FormatUtils.Thousand, ref chart2);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "ДЗ Средний долг",
                System.Drawing.Color.FromArgb(186, 176, 201), ViewModel.DZ_dzVsKzDiagram, FormatUtils.Thousand, ref chart2);
        }
    }
}
