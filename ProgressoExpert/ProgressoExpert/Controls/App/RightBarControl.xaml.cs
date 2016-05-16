using ProgressoExpert.Controls.Calculators;
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

namespace ProgressoExpert.Controls.App
{
    /// <summary>
    /// Логика взаимодействия для RightBarControl.xaml
    /// </summary>
    public partial class RightBarControl : UserControl
    {
        CalculatorWindow CalculatorWindow;
        DepositCalculatorWindow DepositCalculatorWindow;

        public RightBarControl()
        {
            InitializeComponent();
        }

        private void SimpleCalculatorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CalculatorWindow == null)
            {
                CalculatorWindow = new CalculatorWindow();
            }
            CalculatorWindow.Show();
        }

        private void DepositCalculatorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DepositCalculatorWindow == null)
            {
                DepositCalculatorWindow = new DepositCalculatorWindow();
            }
            DepositCalculatorWindow.Show();
        }
    }
}
