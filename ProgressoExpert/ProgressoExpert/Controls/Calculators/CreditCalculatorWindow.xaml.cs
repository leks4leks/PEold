using ProgressoExpert.Models.Models.App;
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
    /// Логика взаимодействия для CreditCalculatorWindow.xaml
    /// </summary>
    public partial class CreditCalculatorWindow : Window
    {
        private CreditCalculatorModel ViewModel;

        public CreditCalculatorWindow()
        {
            InitializeComponent();
            ViewModel = new CreditCalculatorModel();
            this.DataContext = ViewModel;
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                ViewModel.Calculate();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetDefault();
        }

        private void Window_Deactivated_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void AnnualRateTB_GotFocus(object sender, RoutedEventArgs e)
        {
            var indexPercent = AnnualRateTb.Text.IndexOf('%');
            AnnualRateTb.Text = AnnualRateTb.Text.Remove(indexPercent, 1);
            AnnualRateTb.SelectAll();
        }

        private bool Validate()
        {
            SumTb.BorderBrush = Brushes.Gray;
            AnnualRateTb.BorderBrush = Brushes.Gray;
            MonthsTb.BorderBrush = Brushes.Gray;
            DaysInYearTb.BorderBrush = Brushes.Gray;

            var result = true;
            if (ViewModel.Sum <= 0)
            {
                SumTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ViewModel.AnnualRate <= 0)
            {
                AnnualRateTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ViewModel.Months <= 0)
            {
                MonthsTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ViewModel.DaysInYear <= 0)
            {
                DaysInYearTb.BorderBrush = Brushes.Red;
                result = false;
            }

            return result;
        }
    }
}
