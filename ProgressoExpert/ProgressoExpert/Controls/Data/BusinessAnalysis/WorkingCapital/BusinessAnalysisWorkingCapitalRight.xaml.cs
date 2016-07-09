using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;
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
        MainModel mainModel;

        public BusinessAnalysisWorkingCapitalRight()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = (WorkingСapitalBusinessAnalysis)model.WorkingСapitalBA;
            this.DataContext = (WorkingСapitalBusinessAnalysis)model.WorkingСapitalBA;
            mainModel = model;
            LoadDiagram(ref chart);
            LoadDiagram2(ref chart2);
        }


        public void LoadDiagram(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart, 0, 0, 1, 0, true, false, false, false, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.StackedColumn, "ДЗ Средний долг",
                System.Drawing.Color.FromArgb(128, 100, 162), DateUtils.ConvertToQuarter(ViewModel.aveDZDiagram, mainModel),
                FormatUtils.Thousand, ref _chart, false);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.StackedColumn, "Товары средний остаток",
                System.Drawing.Color.FromArgb(170, 186, 215), DateUtils.ConvertToQuarter(ViewModel.aveGoodsDiagram, mainModel),
                FormatUtils.Thousand, ref _chart, false);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.StackedColumn, "Деньги средний остаток",
                System.Drawing.Color.FromArgb(186, 176, 201), DateUtils.ConvertToQuarter(ViewModel.aveMoneyDiagram, mainModel),
                FormatUtils.Thousand, ref _chart, false);
            ChartUtils.AddSeriesAndPoints("Series4", SeriesChartType.StackedColumn, "Продажи",
                System.Drawing.Color.FromArgb(60, 103, 154), DateUtils.ConvertToQuarter(ViewModel.aveSalesDiagram, mainModel),
                FormatUtils.Thousand, ref _chart, false);
        }

        public void LoadDiagram2(ref Chart _chart)
        {
            ChartUtils.AddChartArea(FormatUtils.Thousand, ref _chart, 0, 0, 1, 0, true, false, false, false, 0);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Top, ref _chart);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "КЗ Средний долг",
                System.Drawing.Color.FromArgb(128, 100, 162), DateUtils.ConvertToQuarter(ViewModel.KZ_dzVsKzDiagram, mainModel),
                 FormatUtils.Thousand, ref _chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "ДЗ Средний долг",
                System.Drawing.Color.FromArgb(186, 176, 201), DateUtils.ConvertToQuarter(ViewModel.DZ_dzVsKzDiagram, mainModel),
                 FormatUtils.Thousand, ref _chart);
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
    }
}
