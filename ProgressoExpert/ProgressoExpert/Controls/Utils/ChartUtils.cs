using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgressoExpert.Controls.Utils
{
    public static class ChartUtils
    {
        public static void AddSeriesAndPoints(string seriesName, SeriesChartType chartType, string legendText, System.Drawing.Color color, 
            Dictionary<string, decimal> dataValues, string pointLabelFormat, ref Chart _chart)
        {
            var series = new Series()
            {
                Name = seriesName,
                ChartType = chartType,
                Color = color,
                LegendText = legendText,
                BorderColor = System.Drawing.Color.White,
                IsValueShownAsLabel = true
            };
            foreach (KeyValuePair<string, decimal> data in dataValues)
            {
                series.Points.AddXY(data.Key, data.Value);
                var _point = series.Points.Last();
                _point.Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), pointLabelFormat, _point.YValues[0]);
                _point.Font = new System.Drawing.Font("Arial", 10);
            }
            _chart.Series.Add(series);
        }

        public static void AddSeries(string seriesName, SeriesChartType chartType, ref Chart _chart)
        {
            var series = new Series()
            {
                Name = seriesName,
                ChartType = chartType,
            };
            _chart.Series.Add(series);
        }

        public static void AddPoint(string seriesName, decimal dataPointData, string labelFormat, string legendText, System.Drawing.Color color, ref Chart chart)
        {
            //var dataPointData = ViewModel.CycleMoneyDiagram["Деньги в кассе"];
            chart.Series[seriesName].Points.Add(new DataPoint()
            {
                Label = string.Format(CultureInfo.CreateSpecificCulture("ru-Ru"), labelFormat, dataPointData),
                Font = new System.Drawing.Font("Arial", 10),
                XValue = (double)dataPointData,
                YValues = new double[] { (double)dataPointData },
                LegendText = legendText,
                Color = color,
                BorderColor = System.Drawing.Color.White
            });
        }

        /// <summary>
        /// Add ChartArea
        /// </summary>
        /// <param name="labelStyleFormat">AxisY.LabelStyle.Format</param>
        /// <param name="_chart">Chart</param>
        /// <param name="xMajorGridLineWidth">AxisX.MajorGrid.LineWidth</param>
        /// <param name="yMajorGridLineWidth">AxisY.MajorGrid.LineWidth</param>
        /// <param name="xLabelStyleInterval">AxisX.LabelStyle.Interval</param>
        public static void AddChartArea(string labelStyleFormat, ref Chart _chart, int xMajorGridLineWidth = 0,
            int yMajorGridLineWidth = 0, int xLabelStyleInterval = 0, int yLabelStyleInterval = 0,
            bool xLabelStyleEnabled = true, bool yLabelStyleEnabled = true, bool yMajorTickMarkEnabled = true,
            bool yMinorTickMarkEnabled = true)
        {
            var chartArea = new ChartArea() { Name = "ChartArea" };
            chartArea.AxisX.MajorGrid.LineWidth = xMajorGridLineWidth;
            chartArea.AxisY.MajorGrid.LineWidth = yMajorGridLineWidth;

            chartArea.AxisX.LabelStyle.Interval = xLabelStyleInterval;
            chartArea.AxisY.LabelStyle.Interval = yLabelStyleInterval;

            chartArea.AxisX.LabelStyle.Enabled = xLabelStyleEnabled;
            chartArea.AxisY.LabelStyle.Enabled = yLabelStyleEnabled;

            chartArea.AxisY.MajorTickMark.Enabled = yMajorTickMarkEnabled;
            chartArea.AxisY.MinorTickMark.Enabled = yMinorTickMarkEnabled;

            chartArea.AxisY.LabelStyle.Format = labelStyleFormat;

            chartArea.BackColor = System.Drawing.Color.Transparent;

            _chart.ChartAreas.Add(chartArea);
        }

        /// <summary>
        /// Add Legend
        /// </summary>
        /// <param name="alignment"></param>
        /// <param name="docking"></param>
        /// <param name="_chart"></param>
        public static void AddLegend(System.Drawing.StringAlignment alignment, Docking docking, ref Chart _chart)
        {
            var legend = new Legend()
            {
                Name = "Legend",
                Alignment = alignment,
                Docking = docking,
                Font = new System.Drawing.Font("Arial", 10)
            };
            _chart.Legends.Add(legend);
        }
    }
}
