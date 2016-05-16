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
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            NCalc.Expression exp = new NCalc.Expression(ResultTb.Text);
            ResultTb.Text = exp.Evaluate().ToString();
        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultTb.Text = "";
        }

        private void DeleteLastSymbolBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultTb.Text = ResultTb.Text.Remove(ResultTb.Text.Length - 1, 1);
        }
    }
}
