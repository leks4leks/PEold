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
using System.Windows.Shapes;

namespace ProgressoExpert.Controls.Calculators
{
    /// <summary>
    /// Логика взаимодействия для CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        private bool nonOperation = false;


        public CalculatorWindow()
        {
            InitializeComponent();
        }


        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Deactivated_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            SetResultText((sender as Button).Tag.ToString(), true);
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nonOperation && !string.IsNullOrEmpty(ResultTb.Text))
            {
                NCalc.Expression exp = new NCalc.Expression(ResultTb.Text);
                ResultTb.Text = exp.Evaluate().ToString();
            }
        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            SetResultText(string.Empty, false);
        }

        private void DeleteLastSymbolBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ResultTb.Text))
            {
                if (ResultTb.Text.Last() == '.' || ResultTb.Text.Last() == '/' || ResultTb.Text.Last() == '*'
                     || ResultTb.Text.Last() == '-' || ResultTb.Text.Last() == '+')
                {
                    nonOperation = true;
                }
                else
                {
                    nonOperation = false;
                }
                ResultTb.Text = ResultTb.Text.Remove(ResultTb.Text.Length - 1, 1);
            }
        }

        private void PointBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                SetResultText(".", false);
            }
        }

        private void DivisionBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                SetResultText("/", false);
            }
        }

        private void MultipleBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                SetResultText("*", false);
            }
        }

        private void MinusBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                SetResultText("-", false);
            }
        }

        private void PlusBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                SetResultText("+", false);
            }
        }

        private void SetResultText(string text, bool _nonOperation)
        {
            ResultTb.Text += text;
            nonOperation = _nonOperation;
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    SetResultText("1", true);
                    break;
                case Key.D2:
                    SetResultText("2", true);
                    break;
                case Key.D3:
                    SetResultText("3", true);
                    break;
                case Key.D4:
                    SetResultText("4", true);
                    break;
                case Key.D5:
                    SetResultText("5", true);
                    break; 
                case Key.D6:
                    SetResultText("6", true);
                    break;
                case Key.D7:
                    SetResultText("7", true);
                    break;
                case Key.D8:
                    SetResultText("8", true);
                    break;
                case Key.D9:
                    SetResultText("9", true);
                    break;
                case Key.D0:
                    SetResultText("0", true);
                    break;
                case Key.Add:
                    SetResultText("+", false);
                    break;
                case Key.Subtract:
                    SetResultText("-", false);
                    break;
                case Key.Multiply:
                    SetResultText("*", false);
                    break;
                case Key.Divide:
                    SetResultText("/", false);
                    break;


                case Key.Enter:
                    ResultBtn_Click(this, null);
                    break;
            }
        }
    }
}
