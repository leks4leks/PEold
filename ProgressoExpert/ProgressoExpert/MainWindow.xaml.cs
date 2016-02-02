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
        private const double FILTER_ROW_HEIGHT = 30;
        private const double DELETED_PART_FROM_WINDOW_WIDTH = 410;

        public MainWindow()
        {
            InitializeComponent();
            //this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;


            StartDate.SelectedDate = new DateTime(2012, 09, 01);
            endDate.SelectedDate = new DateTime(2013, 12, 31);
        }

        private void ExpandAllBtn_Click(object sender, RoutedEventArgs e)
        {
            ResBusiness.Exp1.IsExpanded = true;
            RatiosIndicators.Exp1.IsExpanded = true;
            ResBusiness.BalanceExp.IsExpanded = true;
            ResBusiness.ProfitLossReportExp.IsExpanded = true;
            ResBusiness.StatementCashFlowsExp.IsExpanded = true;
            BusIndicator.Exp1.IsExpanded = true;
            StrTest.Exp1.IsExpanded = true;
            MonitorProject.Exp1.IsExpanded = true;
        }

        private void CollapseAllBtn_Click(object sender, RoutedEventArgs e)
        {
            ResBusiness.Exp1.IsExpanded = false;
            RatiosIndicators.Exp1.IsExpanded = false;
            ResBusiness.BalanceExp.IsExpanded = false;
            ResBusiness.ProfitLossReportExp.IsExpanded = false;
            ResBusiness.StatementCashFlowsExp.IsExpanded = false;
            BusIndicator.Exp1.IsExpanded = false;
            StrTest.Exp1.IsExpanded = false;
            MonitorProject.Exp1.IsExpanded = false;
        }

        private void ShowUpdatePanelBtn_Click(object sender, RoutedEventArgs e)
        {
            var filterRow = MainGrid.RowDefinitions[2];
            if (filterRow.ActualHeight != FILTER_ROW_HEIGHT)
            {
                filterRow.Height = new GridLength(FILTER_ROW_HEIGHT);
            }
            else
            {
                filterRow.Height = new GridLength(0);
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StartDate.SelectedDate == null || endDate.SelectedDate == null)
            {
                MessageBox.Show("Для обновления данных, укажите начало и конец периода");
                return;
            }

            MainModel vm = ProcessesEngine.GetResult((DateTime)StartDate.SelectedDate, (DateTime)endDate.SelectedDate);
            vm.StartDate = (DateTime)StartDate.SelectedDate;
            vm.EndDate = (DateTime)endDate.SelectedDate;

            ResBusiness.RB_Balance.DataContext = vm.BusinessResults;
            RatiosIndicators.RI_BusinessActivity.DataContext = RatiosIndicators.RI_FinancialStability.DataContext
                = RatiosIndicators.RI_Liquidity.DataContext = RatiosIndicators.RI_ProfitabilityRatios.DataContext = vm.RatiosIndicatorsResult;

            CreateAndFillReportProfitAndLosses(vm);

            //CollapseAllBtn_Click(sender, e);
            #region Видимость
            ResBusiness.RB_Balance.BalanceGrid.Visibility = Visibility.Visible;
            ResBusiness.RB_Balance.BalanceGridNoData.Visibility = Visibility.Hidden;
            ResBusiness.RB_ProfitLossReport.dataProfitLossReportGrid.Visibility = Visibility.Visible;
            ResBusiness.RB_ProfitLossReport.nodataProfitLossReportGrid.Visibility = Visibility.Hidden;
            ResBusiness.RB_StatementCashFlows.dataStatementCashFlowsGrid.Visibility = Visibility.Visible;
            ResBusiness.RB_StatementCashFlows.nodataStatementCashFlowsGrid.Visibility = Visibility.Hidden;

            BusIndicator.BI1.liquidityGrid.Visibility = Visibility.Visible;
            BusIndicator.BI1.nodataLiquidityGrid.Visibility = Visibility.Hidden;
            BusIndicator.BI2.BusinessActivityGrid.Visibility = Visibility.Visible;
            BusIndicator.BI2.nodataBusinessActivityGrid.Visibility = Visibility.Hidden;
            BusIndicator.BI3.BusinessActivityGrid.Visibility = Visibility.Visible;
            BusIndicator.BI3.nodataBusinessActivityGrid.Visibility = Visibility.Hidden;

            RatiosIndicators.RI_Liquidity.liquidityGrid.Visibility = Visibility.Visible;
            RatiosIndicators.RI_Liquidity.nodataliquidityGrid.Visibility = Visibility.Hidden;
            RatiosIndicators.RI_BusinessActivity.BusinessActivityGrid.Visibility = Visibility.Visible;
            RatiosIndicators.RI_BusinessActivity.nodataBusinessActivityGrid.Visibility = Visibility.Hidden;
            RatiosIndicators.RI_FinancialStability.FinancialStabilityGrid.Visibility = Visibility.Visible;
            RatiosIndicators.RI_FinancialStability.nodataFinancialStabilityGrid.Visibility = Visibility.Hidden;
            RatiosIndicators.RI_ProfitabilityRatios.ProfitabilityRatiosGrid.Visibility = Visibility.Visible;
            RatiosIndicators.RI_ProfitabilityRatios.nodataProfitabilityRatiosGrid.Visibility = Visibility.Hidden;

            StrTest.liquidityGrid.Visibility = Visibility.Visible;
            StrTest.nodataliquidityGrid.Visibility = Visibility.Hidden;

            MonitorProject.dataMonitorProjectGrid.Visibility = Visibility.Visible;
            MonitorProject.nodataMonitorProjectGrid.Visibility = Visibility.Hidden;
            #endregion
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
            ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(brd);

            Rectangle rct = new Rectangle();
            Grid.SetColumn(rct, 0);
            Grid.SetRow(rct, 0);
            Grid.SetColumnSpan(rct, monthCount + 2); // + год и  средневзвешанная
            rct.Fill = Brushes.LightGray;
            ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(rct);
            #endregion

            TextBlock tBlock = new TextBlock();
            monthCount = 0;
            startMonthYear = new int[] { vm.StartDate.Month, vm.StartDate.Year };
            do // в верхний цикл засунить не могли, иначе заливка поверх текста встает
            {
                ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition()); // создадим новую колонку в гриде
                tBlock = CreateAndFillTextBlock(((Month)startMonthYear[0]).ToString() + ", " + startMonthYear[1], 0, 0, false, ref monthCount);
                ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(tBlock);// добавим получившийся блок с текстом
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
            ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition());
            tBlock = CreateAndFillTextBlock("Год", 0, 0, false, ref monthCount);
            ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(tBlock);

            ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition());
            tBlock = CreateAndFillTextBlock("Средневзвешенная цена", 0, 0, false, ref monthCount);
            tBlock.Width = 250;
            ResBusiness.RB_ProfitLossReport.dataRowProfitLossReportGrid.Children.Add(tBlock);
            #endregion

            #region Данные 
            
            #region Красота, фон
            SetParamForRectangle(0, 0, 15, monthCount - 2, ResBusiness.RB_ProfitLossReport.WhiteSpaseForData);
            SetParamForRectangle(monthCount - 2, 0, 15, 2, ResBusiness.RB_ProfitLossReport.GraySpaseForData);
            SetParamForRectangle(0, 2, 0, monthCount, ResBusiness.RB_ProfitLossReport.SecondBlueRow, false);
            SetParamForRectangle(0, 9, 0, monthCount, ResBusiness.RB_ProfitLossReport.NineBlueRow, false);
            SetParamForRectangle(0, 11, 0, monthCount, ResBusiness.RB_ProfitLossReport.ElevenBlueRow, false);
            SetParamForRectangle(0, 14, 0, monthCount, ResBusiness.RB_ProfitLossReport.FourteenBlueRow, false);
            #endregion

            var model = vm.ReportProfitAndLoss;
            #region Заполнение
            for (int scoreNum = 0; scoreNum < (int)ProfitAndLossNumUI.Total; scoreNum++)
            {
                for (int j = 0; j < monthCount; j++)
                {
                    ResBusiness.RB_ProfitLossReport.GridDataProfitLossReportGrid.ColumnDefinitions.Add(new ColumnDefinition());
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
                    ResBusiness.RB_ProfitLossReport.GridDataProfitLossReportGrid.Children.Add(textBlock);                    
                }
            }
            #endregion

            #endregion
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResBusiness.RB_ProfitLossReport.grid1.ColumnDefinitions[1].Width = 
                new GridLength(GridMainTable.ColumnDefinitions[0].ActualWidth - DELETED_PART_FROM_WINDOW_WIDTH);
            ResBusiness.RB_StatementCashFlows.grid2.ColumnDefinitions[1].Width = 
                new GridLength(GridMainTable.ColumnDefinitions[0].ActualWidth - DELETED_PART_FROM_WINDOW_WIDTH);
            MonitorProject.grid2.ColumnDefinitions[1].Width =
                new GridLength(GridMainTable.ColumnDefinitions[0].ActualWidth - DELETED_PART_FROM_WINDOW_WIDTH);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Login wnd = new Login();
            wnd.Show();
            this.Close();
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Settings wnd = new Settings();
            wnd.ShowDialog();
        }

    }
}
