using ProgressoExpert.Common.Enums;
using ProgressoExpert.Controls.Utils;
using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressoExpert.Controls.Data.ResBusiness
{
    /// <summary>
    /// Логика взаимодействия для RB_ProfitLossReport.xaml
    /// </summary>
    public partial class RB_ProfitLossReport : UserControl
    {
        public RB_ProfitLossReport()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel vm)
        {
            DataContext = vm.ReportProfitAndLoss;
            CreateAndFillReportProfitAndLosses(vm);
        }



        private void CreateAndFillReportProfitAndLosses(MainModel vm)
        {
            //vm.StartDate = vm.StartDate.AddYears(vm.TimeSpan * -1);
            //vm.EndDate = vm.EndDate.AddYears(vm.TimeSpan * -1);

            int[] endMonthYear = new int[] { vm.EndDate.Month, vm.EndDate.Year };

            int monthCount = 0;
            int[] startMonthYear = new int[] { vm.StartDate.Month, vm.StartDate.Year };//будем бежать от начала до конца периода
            do
            {
                #region Cчитаем кол-во месяцев
                if (startMonthYear[0] == 12)
                {
                    startMonthYear[1]++;
                    startMonthYear[0] = 1;
                    monthCount++;
                }
                else
                {
                    startMonthYear[0]++;
                    monthCount++;
                }
                #endregion
            }
            while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));

            #region Шапка
            #region Рамка + заливка в виде прямоугольника
            Border brd = new Border();
            Grid.SetColumn(brd, 0);
            Grid.SetRow(brd, 0);
            Grid.SetColumnSpan(brd, monthCount + 2); // + год и  средневзвешанная
            brd.BorderBrush = Brushes.Black;
            Thickness BorderThickness = brd.BorderThickness;
            BorderThickness.Left = 0;
            BorderThickness.Top = 0;
            BorderThickness.Right = 0;
            BorderThickness.Bottom = 0;
            brd.Margin = BorderThickness;
            GridDataProfitLossReportGrid.Children.Add(brd);

            Rectangle rct = new Rectangle();
            Grid.SetColumn(rct, 0);
            Grid.SetRow(rct, 0);
            Grid.SetColumnSpan(rct, monthCount + 2); // + год и  средневзвешанная
            rct.Fill = Brushes.LightGray;
            GridDataProfitLossReportGrid.Children.Add(rct);
            #endregion

            //TextBlock tBlock = new TextBlock();
            //monthCount = 0;
            //startMonthYear = new int[] { vm.StartDate.Month, vm.StartDate.Year };
            //do // в верхний цикл засунить не могли, иначе заливка поверх текста встает
            //{
            //    dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) }); // создадим новую колонку в гриде
            //    tBlock = CreateAndFillTextBlock(((Month)startMonthYear[0]).ToString() + ", " + startMonthYear[1], 0, 0, false, ref monthCount);
            //    dataRowProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
            //    #region
            //    if (startMonthYear[0] == 12)
            //    {
            //        startMonthYear[1]++;
            //        startMonthYear[0] = 1;
            //    }
            //    else
            //    {
            //        startMonthYear[0]++;
            //    }
            //    #endregion
            //}
            //while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));

            //// Две дополнительных колонки, которые есть всегда
            //dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) });
            //tBlock = CreateAndFillTextBlock("Итого за период", 0, 0, false, ref monthCount);
            //dataRowProfitLossReportGrid.Children.Add(tBlock);

            //dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) });
            //tBlock = CreateAndFillTextBlock("Средняя цена за период", 0, 0, false, ref monthCount);
            ////tBlock.Width = 100;
            //dataRowProfitLossReportGrid.Children.Add(tBlock);
            #endregion

            #region Данные

            #region Красота, фон
            SetParamForRectangle(0, 1, 15, monthCount - 2, WhiteSpaseForData);
            SetParamForRectangle(monthCount, 1, 15, 2, GraySpaseForData);
            SetParamForRectangle(0, 3, 0, monthCount + 2, SecondBlueRow, false);
            SetParamForRectangle(0, 10, 0, monthCount + 2, NineBlueRow, false);
            SetParamForRectangle(0, 12, 0, monthCount + 2, ElevenBlueRow, false);
            SetParamForRectangle(0, 15, 0, monthCount+2, FourteenBlueRow, false);
            #endregion

            TextBlock tBlock;
            monthCount = 0;
            startMonthYear = new int[] { vm.StartDate.Month, vm.StartDate.Year };
            do // в верхний цикл засунить не могли, иначе заливка поверх текста встает
            {
                GridDataProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Pixel) }); // создадим новую колонку в гриде
                tBlock = CreateAndFillTextBlock(((Month)startMonthYear[0]).ToString() + ", " + startMonthYear[1], 0, 0, false, ref monthCount);
                GridDataProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
                #region
                if (startMonthYear[0] == 12)
                {
                    startMonthYear[1]++;
                    startMonthYear[0] = 1;
                }
                else
                {
                    startMonthYear[0]++;
                }
                #endregion
            }
            while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));

            // Две дополнительных колонки, которые есть всегда
            GridDataProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) });
            tBlock = CreateAndFillTextBlock("Итого за период", 0, 0, false, ref monthCount);
            GridDataProfitLossReportGrid.Children.Add(tBlock);

            GridDataProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) });
            tBlock = CreateAndFillTextBlock("Средняя цена за период", 0, 0, false, ref monthCount);
            //tBlock.Width = 100;
            GridDataProfitLossReportGrid.Children.Add(tBlock);

            var model = vm.ReportProfitAndLoss;
            #region Заполнение
            for (int scoreNum = 0; scoreNum < (int)ProfitAndLossNumUI.Total; scoreNum++)
            {
                for (int j = 0; j < monthCount; j++)
                {
                    //GridDataProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80, GridUnitType.Star) });
                    TextBlock textBlock = new TextBlock();
                    switch (scoreNum)
                    {
                        #region Запишем суммы в модель
                        case (int)ProfitAndLossNumUI.TotalIncome://доход
                            textBlock = CreateAndFillTextBlock((string.Format(FormatUtils.Thousand, model.TotalIncome[j])), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.TotalCostPrice:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.TotalCostPrice[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.GrossProfit:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.GrossProfit[j]), scoreNum + 1, j, true, ref monthCount);
                            textBlock.Style = (Style)FindResource("TextBlock12WhiteCenterCenter");
                            break;
                        case (int)ProfitAndLossNumUI.OtherIncome:
                            textBlock = CreateAndFillTextBlock((string.Format(FormatUtils.Thousand, model.OtherIncome[j])), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.Costs:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.Costs[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.CostsSalesServices:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.CostsSalesServices[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.AdministrativeExpenses:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.AdministrativeExpenses[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.FinancingCosts:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.FinancingCosts[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.OtherCosts:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.OtherCosts[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.OperatingProfit:
                            {
                                textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.OperatingProfit[j]), scoreNum + 1, j, true, ref monthCount);
                                textBlock.Style = (Style)FindResource("TextBlock12WhiteCenterCenter");
                                break;
                            }
                        case (int)ProfitAndLossNumUI.Depreciation:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.Depreciation[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.ProfitBeforeTaxation:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.ProfitBeforeTaxation[j]), scoreNum + 1, j, true, ref monthCount);
                            textBlock.Style = (Style)FindResource("TextBlock12WhiteCenterCenter");
                            break;
                        case (int)ProfitAndLossNumUI.OtherTaxes:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.OtherTaxes[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.KPN20:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.KPN20[j]), scoreNum + 1, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.TotalProfit:
                            textBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Thousand, model.TotalProfit[j]), scoreNum + 1, j, true, ref monthCount);
                            textBlock.Style = (Style)FindResource("TextBlock12WhiteCenterCenter");
                            break;
                        #endregion
                    }
                    if (textBlock.Style == null)
                    {
                        textBlock.Style = (Style)FindResource("TextBlock12CenterCenter");
                    }
                    //if (j == monthCount - 1) textBlock.Width = 100; // последнюю колонку сделаем пошырше
                    GridDataProfitLossReportGrid.Children.Add(textBlock);
                }
            }
            #endregion

            #endregion

            tBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Percentage, model.GrossMargin), 17, GridDataProfitLossReportGrid.ColumnDefinitions.Count - 3, true, ref monthCount);
            tBlock.Style = (Style)FindResource("TextBlock12CenterCenter");
            GridDataProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
            var border = new Border();
            border.BorderThickness = new Thickness(0, 1, 1, 0);
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            Grid.SetColumn(border, 0);
            Grid.SetRow(border, 17);
            Grid.SetColumnSpan(border, GridDataProfitLossReportGrid.ColumnDefinitions.Count - 2);
            GridDataProfitLossReportGrid.Children.Add(border);

            tBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Percentage, model.NetMargin), 18, GridDataProfitLossReportGrid.ColumnDefinitions.Count - 3, true, ref monthCount);
            tBlock.Style = (Style)FindResource("TextBlock12CenterCenter");
            GridDataProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
            border = new Border();
            border.BorderThickness = new Thickness(0, 1, 1, 0);
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            Grid.SetColumn(border, 0);
            Grid.SetRow(border, 18);
            Grid.SetColumnSpan(border, GridDataProfitLossReportGrid.ColumnDefinitions.Count - 2);
            GridDataProfitLossReportGrid.Children.Add(border);

            tBlock = CreateAndFillTextBlock(string.Format(FormatUtils.Percentage, model.ServiceRatioPercent), 19, GridDataProfitLossReportGrid.ColumnDefinitions.Count - 3, true, ref monthCount);
            tBlock.Style = (Style)FindResource("TextBlock12CenterCenter");
            GridDataProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
            border = new Border();
            border.BorderThickness = new Thickness(0, 1, 1, 1);
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            Grid.SetColumn(border, 0);
            Grid.SetRow(border, 19);
            Grid.SetColumnSpan(border, GridDataProfitLossReportGrid.ColumnDefinitions.Count - 2);
            GridDataProfitLossReportGrid.Children.Add(border);
        }

        /// <summary>
        /// Создаем новый влок с текстом, если не знаем сколько будет столбцов то column = 0 и monthCount это динамическая переменная
        /// </summary>
        /// <param name="text"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="useRowColumn"></param>
        /// <param name="monthCount"></param>
        /// <returns></returns>
        private TextBlock CreateAndFillTextBlock(string text, int row, int column, bool useRowColumn, ref int monthCount)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            Grid.SetColumn(textBlock, useRowColumn ? column : monthCount++);
            Grid.SetRow(textBlock, row);
            textBlock.Width = 80;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            //textBlock.FontSize = 12;
            //textBlock.Foreground = Brushes.Black;
            textBlock.TextWrapping = TextWrapping.Wrap;
            #region Отступ
            //Thickness margin = textBox.Margin;
            //margin.Left = 2;
            //margin.Top = 0;
            //margin.Right = 2;
            //margin.Bottom = 4;
            //textBox.Margin = margin;
            #endregion
            return textBlock;
        }

        /// <summary>
        /// Установим так называемую высоту и ширину области, путем слияния ячеек
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="rowSpan"></param>
        /// <param name="colSpan"></param>
        /// <param name="rct"></param>
        /// <param name="useRowSpan"></param>
        private static void SetParamForRectangle(int column, int row, int rowSpan, int colSpan, Rectangle rct, bool useRowSpan = true)
        {
            Grid.SetColumn(rct, column);
            Grid.SetRow(rct, row);
            if (useRowSpan)
                Grid.SetRowSpan(rct, rowSpan);
            Grid.SetColumnSpan(rct, colSpan);
        }


    }
}
