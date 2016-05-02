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
            if (ViewModel.DynamicsSalesDiagram != null && ViewModel.DynamicsPaymentDiagram != null)
            {
                LoadDiagram();
            }
            if (ViewModel.StructureGrossProfitClientDiagram != null && ViewModel.StructureGrossProfitClientDiagram.Count > 0)
            {
                LoadDiagram4();
            }
            if (ViewModel.StructureGrossProfitClientInfo != null && ViewModel.StructureGrossProfitClientInfo.Count > 0)
            {
                UpdateTable2();
            };
        }

        public void LoadDiagram()
        {
            //var chartArea = new ChartArea() { Name = "ChartArea" };
            //chartArea.AxisX.LabelStyle.Interval = 1;
            //chartArea.AxisX.LabelStyle.Interval = 1;
            //chartArea.AxisX.MajorGrid.LineWidth = 0;
            //chartArea.AxisY.MajorGrid.LineWidth = 0;
            //chartArea.AxisY.LabelStyle.Enabled = false;
            //chartArea.AxisY.MajorTickMark.Enabled = false;
            //chartArea.AxisY.MinorTickMark.Enabled = false;
            //chartArea.AxisY.LineWidth = 0;
            //chartArea.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            //chart.ChartAreas.Add(chartArea);

            chart.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            ChartUtils.AddChartArea(string.Empty, ref chart, 0, 0, 1, 1, true, false, false, false);

            ChartUtils.AddSeriesAndPoints("Series1", SeriesChartType.Column, "Продажи", System.Drawing.Color.FromArgb(0, 176, 80),
                ViewModel.DynamicsSalesDiagram, FormatUtils.Thousand, ref chart);
            ChartUtils.AddSeriesAndPoints("Series2", SeriesChartType.Column, "Оплаты", System.Drawing.Color.FromArgb(147, 169, 207),
                ViewModel.DynamicsPaymentDiagram, FormatUtils.Thousand, ref chart);
        }

        public void LoadDiagram2()
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisY.LabelStyle.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisY.MinorTickMark.Enabled = false;
            chartArea.AxisY.LineWidth = 0;
            chart2.ChartAreas.Add(chartArea);

            //ChartUtils.AddChartArea(string.Empty, ref chart, 0, 0, 1, 1, true, false, false, false);


            var series = new Series()
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Шины",
                Color = System.Drawing.Color.FromArgb(127, 154, 72),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData1 = new Dictionary<string, int>();
            seriesData1.Add("Янв", 17500);
            seriesData1.Add("Фев", 18300);
            seriesData1.Add("Мар", 19900);
            seriesData1.Add("Апр", 20200);
            seriesData1.Add("Май", 21500);
            seriesData1.Add("Июн", 20000);
            seriesData1.Add("Июл", 19100);
            seriesData1.Add("Авг", 18200);
            seriesData1.Add("Сен", 16500);
            seriesData1.Add("Окт", 10000);
            seriesData1.Add("Ноя", 11000);
            seriesData1.Add("Дек", 12000);

            foreach (KeyValuePair<string, int> data in seriesData1)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart2.Series.Add(series);



            var series2 = new Series()
            {
                Name = "Series2",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Масла",
                Color = System.Drawing.Color.FromArgb(155, 187, 89),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData2 = new Dictionary<string, int>();
            seriesData2.Add("Янв", 1100);
            seriesData2.Add("Фев", 2200);
            seriesData2.Add("Мар", 3300);
            seriesData2.Add("Апр", 440);
            seriesData2.Add("Май", 550);
            seriesData2.Add("Июн", 660);
            seriesData2.Add("Июл", 7700);
            seriesData2.Add("Авг", 8800);
            seriesData2.Add("Сен", 9900);
            seriesData2.Add("Окт", 10000);
            seriesData2.Add("Ноя", 11000);
            seriesData2.Add("Дек", 12000);

            foreach (KeyValuePair<string, int> data in seriesData2)
            {
                series2.Points.AddXY(data.Key, data.Value);
                var _point = series2.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart2.Series.Add(series2);




            var series3 = new Series()
            {
                Name = "Series3",
                ChartType = SeriesChartType.Column,
                ChartArea = chartArea.Name,
                IsValueShownAsLabel = true,
                LegendText = "Запчасти",
                Color = System.Drawing.Color.FromArgb(198, 214, 172),
                BorderColor = System.Drawing.Color.White
            };

            Dictionary<string, int> seriesData3 = new Dictionary<string, int>();

            seriesData3.Add("Янв", 1100);
            seriesData3.Add("Фев", 2200);
            seriesData3.Add("Мар", 3300);
            seriesData3.Add("Апр", 4400);
            seriesData3.Add("Май", 550);
            seriesData3.Add("Июн", 660);
            seriesData3.Add("Июл", 770);
            seriesData3.Add("Авг", 8800);
            seriesData3.Add("Сен", 990);
            seriesData3.Add("Окт", 1000);
            seriesData3.Add("Ноя", 1100);
            seriesData3.Add("Дек", 12000);


            foreach (KeyValuePair<string, int> data in seriesData3)
            {
                series3.Points.AddXY(data.Key, data.Value);
                var _point = series3.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), "{0:N0}", _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            chart2.Series.Add(series3);
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
        public void UpdateTable2()
        {
            Table2Name1Tb.Text = ViewModel.StructureGrossProfitClientInfo[0].Name;
            Table2Sales1Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[0].Value);
            Table2Payment1Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[0].Share);

            Table2Name2Tb.Text = ViewModel.StructureGrossProfitClientInfo[1].Name;
            Table2Sales2Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[1].Value);
            Table2Payment2Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[1].Share);

            Table2Name3Tb.Text = ViewModel.StructureGrossProfitClientInfo[2].Name;
            Table2Sales3Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[2].Value);
            Table2Payment3Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[2].Share);

            Table2Name4Tb.Text = ViewModel.StructureGrossProfitClientInfo[3].Name;
            Table2Sales4Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[3].Value);
            Table2Payment4Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[3].Share);

            Table2Name5Tb.Text = ViewModel.StructureGrossProfitClientInfo[4].Name;
            Table2Sales5Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[4].Value);
            Table2Payment5Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[4].Share);

            Table2Name6Tb.Text = ViewModel.StructureGrossProfitClientInfo[5].Name;
            Table2Sales6Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[5].Value);
            Table2Payment6Tb.Text = string.Format("{0}%", ViewModel.StructureGrossProfitClientInfo[5].Share);
        }
    }
}
