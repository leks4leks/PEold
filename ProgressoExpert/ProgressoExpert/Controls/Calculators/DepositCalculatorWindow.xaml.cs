using ProgressoExpert.Controls.Utils;
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
    /// Логика взаимодействия для DepositCalculatorWindow.xaml
    /// </summary>
    public partial class DepositCalculatorWindow : Window
    {
        private DepositCalculatorModel ViewModel;


        public DepositCalculatorWindow()
        {
            InitializeComponent();
            ViewModel = new DepositCalculatorModel();
            this.DataContext = ViewModel;
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

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                ViewModel.Calculate(phys.IsSelected);
            }

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
            TaxForJuric.BorderBrush = Brushes.Gray;
            TaxForPhysTb.BorderBrush = Brushes.Gray;

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
            if (ViewModel.PercentForJuric <= 0)
            {
                TaxForJuric.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ViewModel.PercentForPhys <= 0)
            {
                TaxForPhysTb.BorderBrush = Brushes.Red;
                result = false;
            }

            return result;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetDefault();
        }

    }
}
