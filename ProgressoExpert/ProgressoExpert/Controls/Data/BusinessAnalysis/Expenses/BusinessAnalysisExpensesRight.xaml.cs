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
            if (ViewModel.SalesDiagram != null && ViewModel.CostsByMonthDiagram != null && ViewModel.GrosProfitDiagram != null)
            {
                LoadDiagram2();
            }
            if (ViewModel.CostsDiagram != null)
            {
                LoadDiagram3();
            }
            if (ViewModel.CostsDiagram != null)
            {
                LoadDiagram4();
            }
        }

        public void LoadDiagram2()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart2, 0, 0, 1, 1, true, true, false, false);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart2);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Расходы", System.Drawing.Color.FromArgb(170, 70, 67),
                ViewModel.CostsByMonthDiagram, string.Empty, ref chart3);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Валовая прибыль", System.Drawing.Color.FromArgb(209, 147, 146),
                ViewModel.GrosProfitDiagram, string.Empty, ref chart3);
            ChartUtils.AddSeriesAndPoints("Series3", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                ViewModel.SalesDiagram, string.Empty, ref chart3);
        }


        public void LoadDiagram3()
        {
            ChartUtils.AddChartArea(string.Empty, ref chart3);
            ChartUtils.AddLegend(System.Drawing.StringAlignment.Center, Docking.Right, ref chart3);

            ChartUtils.AddSeries("Series1", SeriesChartType.Pie, ref chart3);
            //ChartUtils.AddPoint("Series1"

            //Dictionary<string, decimal> seriesData1 = new Dictionary<string, decimal>();

            //seriesData1.Add("Расходы по реализации продукции и услуг", 41);
            //seriesData1.Add("Административные расходы", 11);
            //seriesData1.Add("Расходы на финансирование", 45);
            //seriesData1.Add("Прочие расходы", 3);

            //var dataPointData = seriesData1["Расходы по реализации продукции и услуг"];
            //series.Points.Add(new DataPoint()
            //{
            //    Label = string.Format("{0}%", dataPointData),
            //    XValue = (double)dataPointData,
            //    YValues = new double[] { (double)dataPointData },
            //    LegendText = "Расходы по реализации продукции и услуг",
            //    Color = System.Drawing.Color.FromArgb(192, 80, 77),
            //    BorderColor = System.Drawing.Color.White
            //});

            //dataPointData = seriesData1["Административные расходы"];
            //series.Points.Add(new DataPoint()
            //{
            //    Label = string.Format("{0}%", dataPointData),
            //    XValue = (double)dataPointData,
            //    YValues = new double[] { (double)dataPointData },
            //    LegendText = "Административные расходы",
            //    Color = System.Drawing.Color.FromArgb(179, 74, 71),
            //    BorderColor = System.Drawing.Color.White
            //});

            //dataPointData = seriesData1["Расходы на финансирование"];
            //series.Points.Add(new DataPoint()
            //{
            //    Label = string.Format("{0}%", dataPointData),
            //    XValue = (double)dataPointData,
            //    YValues = new double[] { (double)dataPointData },
            //    LegendText = "Расходы на финансирование",
            //    Color = System.Drawing.Color.FromArgb(202, 126, 125),
            //    BorderColor = System.Drawing.Color.White
            //});

            //dataPointData = seriesData1["Прочие расходы"];
            //series.Points.Add(new DataPoint()
            //{
            //    Label = string.Format("{0}%", dataPointData),
            //    XValue = (double)dataPointData,
            //    YValues = new double[] { (double)dataPointData },
            //    LegendText = "Прочие расходы",
            //    Color = System.Drawing.Color.FromArgb(221, 182, 181),
            //    BorderColor = System.Drawing.Color.White
            //});
        }

        public void LoadDiagram4()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chart4.ChartAreas.Add(chartArea);

            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Pie,
                ChartArea = chartArea.Name,
            };
            chart4.Series.Add(series);

            Dictionary<string, decimal> seriesData1 = new Dictionary<string, decimal>();

            seriesData1.Add("Расходы по реализации продукции и услуг", 38);
            seriesData1.Add("Административные расходы", 12);
            seriesData1.Add("Расходы на финансирование", 47);
            seriesData1.Add("Прочие расходы", 3);

            var dataPointData = seriesData1["Расходы по реализации продукции и услуг"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Расходы по реализации продукции и услуг",
                Color = System.Drawing.Color.FromArgb(192, 80, 77),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Административные расходы"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Административные расходы",
                Color = System.Drawing.Color.FromArgb(179, 74, 71),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Расходы на финансирование"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Расходы на финансирование",
                Color = System.Drawing.Color.FromArgb(202, 126, 125),
                BorderColor = System.Drawing.Color.White
            });

            dataPointData = seriesData1["Прочие расходы"];
            series.Points.Add(new DataPoint()
            {
                Label = string.Format("{0}%", dataPointData),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = "Прочие расходы",
                Color = System.Drawing.Color.FromArgb(221, 182, 181),
                BorderColor = System.Drawing.Color.White
            });
        }
    }
}
