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
            ResultTb.Text += (sender as Button).Tag.ToString();
            nonOperation = true;
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
            ResultTb.Text = "";
            nonOperation = false;
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
                nonOperation = false;
                ResultTb.Text += ".";
            }
        }

        private void DivisionBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                nonOperation = false;
                ResultTb.Text += "/";
            }
        }

        private void MultipleBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                nonOperation = false;
                ResultTb.Text += "*";
            }
        }

        private void MinusBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                nonOperation = false;
                ResultTb.Text += "-";
            }
        }

        private void PlusBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (nonOperation)
            {
                nonOperation = false;
                ResultTb.Text += "+";
            }
        }
    }
}
