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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Expenses
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisExpensesLeft.xaml
    /// </summary>
    public partial class BusinessAnalysisExpensesLeft : UserControl
    {
        CostsBusinessAnalysis ViewModel;

        public BusinessAnalysisExpensesLeft()
        {
            InitializeComponent();
        }

        public void DataBind(CostsBusinessAnalysis model)
        {
            ViewModel = (CostsBusinessAnalysis)model;
            this.DataContext = (CostsBusinessAnalysis)model;
            if (ViewModel.CostsDiagram != null)
            {
                LoadDiagram1();
            }
        }

        public void LoadDiagram1()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart1, 0, 0, 1, 1, true, false, false, false, 0, 0);
            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Bar, "Валовая прибыль по товарам",
                System.Drawing.Color.FromArgb(149, 55, 53), ViewModel.CostsDiagram, FormatUtils.Thousand, ref chart1);
        }
    }
}
