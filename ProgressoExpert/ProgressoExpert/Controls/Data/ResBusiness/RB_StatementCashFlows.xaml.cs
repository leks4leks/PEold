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
    /// Логика взаимодействия для RB_StatementCashFlows.xaml
    /// </summary>
    public partial class RB_StatementCashFlows : UserControl
    {
        MainModel ViewModel;
        public RB_StatementCashFlows()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel vm)
        {
            ViewModel = vm;
            CreateAndFillADDS(ViewModel);
        }

        private void CreateAndFillADDS(MainModel vm)
        {
            int monthCount = 0; // заглушка
            int rowNum = 0;
            
            // Операционная деятельность
            var list = vm.ADDSTranz.Where(i => i.en450 == 0).OrderBy(i => i.en302).Select(i => i).ToList();
            if (list.Count > 0)
            {
                SetParamForRectangle(0, rowNum, 0, 2, BlueRow1, false);
                AddTextBlockToGrid("Операционная деятельность", 
                    String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 0).Sum(i => i.Money)), true, ref rowNum,
                    ref monthCount, ref GridStatementCashFlowsGrid, 500, "TextBlock12WhiteLeftCenterMarginLeft5", "TextBlock12WhiteCenterCenter");
                bool ad1 = false;
                bool ad2 = false;
                foreach (var item in list)
                {
                    if (!ad1 && item.en302 == 0)
                    {
                        AddTextBlockToGrid("Поступление",  
                            String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 0 && i.en302 == 0).Sum(i => i.Money)), true, ref rowNum, 
                            ref monthCount, ref GridStatementCashFlowsGrid, 500);
                        ad1 = true;
                    }
                    if (!ad2 && item.en302 == 1)
                    {
                        AddTextBlockToGrid("Выбытие",
                            String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 0 && i.en302 == 1).Sum(i => i.Money)), true, ref rowNum, 
                            ref monthCount, ref GridStatementCashFlowsGrid, 500);
                        ad2 = true;
                    }
                    AddTextBlockToGrid(item.GroupName, String.Format(FormatUtils.Thousand, item.Money), true, ref rowNum, ref monthCount, 
                        ref GridStatementCashFlowsGrid, 500);
                }
            }

            // Инвестиционная деятельность
            list = vm.ADDSTranz.Where(i => i.en450 == 1).OrderBy(i => i.en302).Select(i => i).ToList();
            if (list.Count > 0)
            {
                SetParamForRectangle(0, rowNum, 0, 2, BlueRow2, false);
                AddTextBlockToGrid("Инвестиционная деятельность",  
                    String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 1).Sum(i => i.Money)), true, ref rowNum,
                    ref monthCount, ref GridStatementCashFlowsGrid, 500, "TextBlock12WhiteLeftCenterMarginLeft5", "TextBlock12WhiteCenterCenter");
                var ad1 = false;
                var ad2 = false;
                foreach (var item in list)
                {
                    if (!ad1 && item.en302 == 0)
                    {
                        AddTextBlockToGrid("Поступление",
                            String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 1 && i.en302 == 0).Sum(i => i.Money)), true, ref rowNum, 
                            ref monthCount, ref GridStatementCashFlowsGrid, 500);
                        ad1 = true;
                    }
                    if (!ad2 && item.en302 == 1)
                    {
                        AddTextBlockToGrid("Выбытие",
                            String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 1 && i.en302 == 1).Sum(i => i.Money)), true, ref rowNum, 
                            ref monthCount, ref GridStatementCashFlowsGrid, 500);
                        ad2 = true;
                    }
                    AddTextBlockToGrid(item.GroupName, String.Format(FormatUtils.Thousand, item.Money), true, ref rowNum, ref monthCount, 
                        ref GridStatementCashFlowsGrid, 500);
                }
            }

            // Финансовая деятельность
            list = vm.ADDSTranz.Where(i => i.en450 == 2).OrderBy(i => i.en302).Select(i => i).ToList();
            if (list.Count > 0)
            {
                SetParamForRectangle(0, rowNum, 0, 2, BlueRow3, false);
                AddTextBlockToGrid("Финансовая деятельность",  
                    String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 2).Sum(i => i.Money)), true, ref rowNum,
                    ref monthCount, ref GridStatementCashFlowsGrid, 500, "TextBlock12WhiteLeftCenterMarginLeft5", "TextBlock12WhiteCenterCenter");
                var ad1 = false;
                var ad2 = false;
                foreach (var item in list)
                {
                    if (!ad1 && item.en302 == 0)
                    {
                        AddTextBlockToGrid("Поступление",
                            String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 2 && i.en302 == 0).Sum(i => i.Money)), true, ref rowNum, 
                            ref monthCount, ref GridStatementCashFlowsGrid, 500);
                        ad1 = true;
                    }
                    if (!ad2 && item.en302 == 1)
                    {
                        AddTextBlockToGrid("Выбытие",
                            String.Format(FormatUtils.Thousand, vm.ADDSTranz.Where(i => i.en450 == 2 && i.en302 == 1).Sum(i => i.Money)), true, ref rowNum, 
                            ref monthCount, ref GridStatementCashFlowsGrid, 500);
                        ad2 = true;
                    }
                    AddTextBlockToGrid(item.GroupName, String.Format(FormatUtils.Thousand, item.Money), true, ref rowNum, ref monthCount, 
                        ref GridStatementCashFlowsGrid, 500);
                }
            }
        }

        private void AddTextBlockToGrid(string text, string text2, bool useRowColumn, ref int rowNum, ref int monthCount, ref Grid grid,
            double width = 80, string style1 = "TextBlock12LeftCenterMarginLeft5", string style2 = "TextBlock12CenterCenter")
        {
            grid.RowDefinitions.Add(new RowDefinition());
            TextBlock textBlock = new TextBlock();
            textBlock = CreateAndFillTextBlock(text, rowNum, 0, true, ref monthCount, 500);
            textBlock.Width = 500;
            textBlock.Style = (Style)FindResource(style1);
            GridStatementCashFlowsGrid.Children.Add(textBlock);

            textBlock = CreateAndFillTextBlock(text2, rowNum, 1, true, ref monthCount);
            textBlock.Style = (Style)FindResource(style2);
            GridStatementCashFlowsGrid.Children.Add(textBlock);
            rowNum++;
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
        private TextBlock CreateAndFillTextBlock(string text, int row, int column, bool useRowColumn, ref int monthCount, double width = 80)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            Grid.SetColumn(textBlock, useRowColumn ? column : monthCount++);
            Grid.SetRow(textBlock, row);
            //textBlock.Width = width;
            //textBlock.TextAlignment = TextAlignment.Center;
            //textBlock.HorizontalAlignment = HorizontalAlignment.Center;
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
