using ProgressoExpert.Common.Enums;
using ProgressoExpert.Models.Models;
using ProgressoExpert.Process;
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

namespace ProgressoExpert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new MainModel();
            HeaderControl.DataContext = ViewModel.InfoModel;
            MenuControl.DataContext = MenuControl.ViewModel = ViewModel;
        }

        private void CreateAndFillADDS(MainModel vm)
        {
            int monthCount = 0; // заглушка
            int rowNum = 0;
            foreach (var item in vm.ADDSTranz)
            {
                this.ResBusinessControl.RB_StatementCashFlows.GridStatementCashFlowsGrid.RowDefinitions.Add(new RowDefinition());
                TextBlock textBlock = new TextBlock();
                textBlock = CreateAndFillTextBlock(item.GroupName, rowNum, 0, true, ref monthCount);
                textBlock.Width = 500; // последнюю колонку сделаем пошырше
                this.ResBusinessControl.RB_StatementCashFlows.GridStatementCashFlowsGrid.Children.Add(textBlock);

                textBlock = CreateAndFillTextBlock(item.Money.ToString("### ### ### ##0.00"), rowNum, 1, true, ref monthCount);
                this.ResBusinessControl.RB_StatementCashFlows.GridStatementCashFlowsGrid.Children.Add(textBlock);
                rowNum++;
            }
            for (int scoreNum = 0; scoreNum < (int)ProfitAndLossNumUI.Total; scoreNum++)
            {
                for (int j = 0; j < monthCount; j++)
                {

                }
            }
        }

        private void CreateAndFillReportProfitAndLosses(MainModel vm)
        {
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
            this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(brd);

            Rectangle rct = new Rectangle();
            Grid.SetColumn(rct, 0);
            Grid.SetRow(rct, 0);
            Grid.SetColumnSpan(rct, monthCount + 2); // + год и  средневзвешанная
            rct.Fill = Brushes.LightGray;
            this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(rct);
            #endregion

            TextBlock tBlock = new TextBlock();
            monthCount = 0;
            startMonthYear = new int[] { vm.StartDate.Month, vm.StartDate.Year };
            do // в верхний цикл засунить не могли, иначе заливка поверх текста встает
            {
                this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition()); // создадим новую колонку в гриде
                tBlock = CreateAndFillTextBlock(((Month)startMonthYear[0]).ToString() + ", " + startMonthYear[1], 0, 0, false, ref monthCount);
                this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
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
            this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition());
            tBlock = CreateAndFillTextBlock("Год", 0, 0, false, ref monthCount);
            this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(tBlock);

            this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition());
            tBlock = CreateAndFillTextBlock("Средневзвешенная цена", 0, 0, false, ref monthCount);
            tBlock.Width = 250;
            this.ResBusinessControl.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(tBlock);
            #endregion

            #region Данные 

            #region Красота, фон
            SetParamForRectangle(0, 0, 15, monthCount - 2, this.ResBusinessControl.RB_ProfitLossReport.WhiteSpaseForData);
            SetParamForRectangle(monthCount - 2, 0, 15, 2, this.ResBusinessControl.RB_ProfitLossReport.GraySpaseForData);
            SetParamForRectangle(0, 2, 0, monthCount, this.ResBusinessControl.RB_ProfitLossReport.SecondBlueRow, false);
            SetParamForRectangle(0, 9, 0, monthCount, this.ResBusinessControl.RB_ProfitLossReport.NineBlueRow, false);
            SetParamForRectangle(0, 11, 0, monthCount, this.ResBusinessControl.RB_ProfitLossReport.ElevenBlueRow, false);
            SetParamForRectangle(0, 14, 0, monthCount, this.ResBusinessControl.RB_ProfitLossReport.FourteenBlueRow, false);
            #endregion

            var model = vm.ReportProfitAndLoss;
            #region Заполнение
            for (int scoreNum = 0; scoreNum < (int)ProfitAndLossNumUI.Total; scoreNum++)
            {
                for (int j = 0; j < monthCount; j++)
                {
                    this.ResBusinessControl.RB_ProfitLossReport.GridDataProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    TextBlock textBlock = new TextBlock();
                    switch (scoreNum)
                    {
                        #region Запишем суммы в модель
                        case (int)ProfitAndLossNumUI.TotalIncome://доход
                            textBlock = CreateAndFillTextBlock((model.TotalIncome[j]).ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.TotalCostPrice:
                            textBlock = CreateAndFillTextBlock(model.TotalCostPrice[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.GrossProfit:
                            textBlock = CreateAndFillTextBlock(model.GrossProfit[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.OtherIncome:
                            textBlock = CreateAndFillTextBlock((model.OtherIncome[j]).ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.Costs:
                            textBlock = CreateAndFillTextBlock(model.Costs[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.CostsSalesServices:
                            textBlock = CreateAndFillTextBlock(model.CostsSalesServices[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.AdministrativeExpenses:
                            textBlock = CreateAndFillTextBlock((model.AdministrativeExpenses[j]).ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.FinancingCosts:
                            textBlock = CreateAndFillTextBlock((model.FinancingCosts[j]).ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.OtherCosts:
                            textBlock = CreateAndFillTextBlock((model.OtherCosts[j]).ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.OperatingProfit:
                            textBlock = CreateAndFillTextBlock(model.OperatingProfit[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.Depreciation:
                            textBlock = CreateAndFillTextBlock(model.Depreciation[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.ProfitBeforeTaxation:
                            textBlock = CreateAndFillTextBlock(model.ProfitBeforeTaxation[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.OtherTaxes:
                            textBlock = CreateAndFillTextBlock(model.OtherTaxes[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.KPN20:
                            textBlock = CreateAndFillTextBlock(model.KPN20[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                        case (int)ProfitAndLossNumUI.TotalProfit:
                            textBlock = CreateAndFillTextBlock(model.TotalProfit[j].ToString(), scoreNum, j, true, ref monthCount);
                            break;
                            #endregion
                    }
                    if (j == monthCount - 1) textBlock.Width = 250; // последнюю колонку сделаем пошырше
                    this.ResBusinessControl.RB_ProfitLossReport.GridDataProfitLossReportGrid.Children.Add(textBlock);
                }
            }
            #endregion

            #endregion
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
            textBlock.Width = 150;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.FontSize = 14;
            textBlock.Foreground = Brushes.Black;
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

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ViewModel.StartDate = new DateTime(2012, 02, 01); //;(DateTime)StartDate.SelectedDate;
            ViewModel.EndDate = new DateTime(2012, 04, 01); // (DateTime)endDate.SelectedDate;
            ViewModel = ProcessesEngine.GetResult(ViewModel.StartDate, ViewModel.EndDate);
            ProcessesEngine.GetGeneralBusinessAnalysis(ViewModel.StartDate, ViewModel.EndDate, ViewModel);
            //return;
            LiveStreamControl.DataBind(ViewModel.LiveStreamModel);
        }
    }
}
