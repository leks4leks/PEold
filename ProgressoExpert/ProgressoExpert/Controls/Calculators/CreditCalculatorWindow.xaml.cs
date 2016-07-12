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
        private bool IsItAnn = false;

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
                if (!IsItAnn)
                {
                    ViewModel.Calculate();
                    gridResults.ItemsSource = ViewModel.DataList;
                }
                else
                {
                    ViewModel.Calculate2();
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsItAnn)
            {
                ViewModel.SetDefault();
                gridResults.ItemsSource = null;
            }
            else
            {
                ViewModel.SetDefault2();
            }
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
            try
            {
                var indexPercent = AnnualRateTb.Text.IndexOf('%');
                AnnualRateTb.Text = AnnualRateTb.Text.Remove(indexPercent, 1);
                AnnualRateTb.SelectAll();
            }
            catch { }
        }

        private void AnnualRateTB2_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var indexPercent = AnnualRateTb2.Text.IndexOf('%');
                AnnualRateTb2.Text = AnnualRateTb2.Text.Remove(indexPercent, 1);
                AnnualRateTb2.SelectAll();
            }
            catch { }
        }

        private bool Validate()
        {
            if (!IsItAnn)
            {
                SumTb.BorderBrush = Brushes.Gray;
                AnnualRateTb.BorderBrush = Brushes.Gray;
                MonthsTb.BorderBrush = Brushes.Gray;

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

                return result;
            }
            else
            {
                SumTb2.BorderBrush = Brushes.Gray;
                AnnualRateTb2.BorderBrush = Brushes.Gray;
                MonthsTb2.BorderBrush = Brushes.Gray;

                var result = true;
                if (ViewModel.Sum2 <= 0)
                {
                    SumTb2.BorderBrush = Brushes.Red;
                    result = false;
                }
                if (ViewModel.AnnualRate2 <= 0)
                {
                    AnnualRateTb2.BorderBrush = Brushes.Red;
                    result = false;
                }
                if (ViewModel.Months2 <= 0)
                {
                    MonthsTb2.BorderBrush = Brushes.Red;
                    result = false;
                }

                return result;
            }
        }

        private void CreditCalcBtn_Click(object sender, RoutedEventArgs e)
        {
            IsItAnn = false;
            CreditCalcGrid.Visibility = System.Windows.Visibility.Visible;
            AnnCreditCalcGrid.Visibility = System.Windows.Visibility.Hidden;
            AnnCreditBtn.IsChecked = false;

        }

        private void AnnCreditBtn_Click(object sender, RoutedEventArgs e)
        {
            IsItAnn = true;
            CreditCalcGrid.Visibility = System.Windows.Visibility.Hidden;
            AnnCreditCalcGrid.Visibility = System.Windows.Visibility.Visible;
            CreditCalcBtn.IsChecked = false;
        }
    }
}
