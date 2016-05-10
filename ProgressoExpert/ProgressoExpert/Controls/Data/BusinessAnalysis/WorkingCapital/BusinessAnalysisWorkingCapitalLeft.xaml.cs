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
    /// Логика взаимодействия для BusinessAnalysisWorkingCapitalLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisWorkingCapitalLeft : UserControl
    {
        WorkingСapitalBusinessAnalysis ViewModel;

        public BusinessAnalysisWorkingCapitalLeft()
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
            chart.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(string.Empty, ref chart, 0, 0, 1, 0, true, false, false, false, 0, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.StackedColumn, "СОК", System.Drawing.Color.FromArgb(96, 74, 123),
                ViewModel.stSokDiagram, string.Empty, ref chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.StackedColumn, "Прибыль", System.Drawing.Color.FromArgb(10, 198, 28),
                ViewModel.profit, string.Empty, ref chart);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.StackedColumn, "Задолженность", System.Drawing.Color.FromArgb(204, 193, 218),
                ViewModel.stDebtsDiagram, string.Empty, ref chart);
        }

        public void LoadDiagram2()
        {
            chart2.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(string.Empty, ref chart2, 0, 0, 1, 0, true, false, false, false, 0, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref chart2);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, string.Empty, System.Drawing.Color.FromArgb(79, 129, 189),
                ViewModel.turnoverDiagram, string.Empty, ref chart2);
        }
    }
}
