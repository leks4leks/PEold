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
    /// Логика взаимодействия для AnnCreditCalculatorWindow.xaml
    /// </summary>
    public partial class AnnCreditCalculatorWindow : Window
    {
        private AnnCreditCalculatorModel ViewModel2;

        public AnnCreditCalculatorWindow()
        {
            InitializeComponent();
            ViewModel2 = new AnnCreditCalculatorModel();
            this.DataContext = ViewModel2;
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                ViewModel2.Calculate();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.SetDefault();
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

        private void AnnualRateTB2_GotFocus(object sender, RoutedEventArgs e)
        {
            var indexPercent = AnnualRateTb2.Text.IndexOf('%');
            AnnualRateTb2.Text = AnnualRateTb2.Text.Remove(indexPercent, 1);
            AnnualRateTb2.SelectAll();
        }

        private bool Validate()
        {
            SumTb2.BorderBrush = Brushes.Gray;
            AnnualRateTb2.BorderBrush = Brushes.Gray;
            MonthsTb2.BorderBrush = Brushes.Gray;

            var result = true;
            if (ViewModel2.Sum2 <= 0)
            {
                SumTb2.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ViewModel2.AnnualRate2 <= 0)
            {
                AnnualRateTb2.BorderBrush = Brushes.Red;
                result = false;
            }
            if (ViewModel2.Months2 <= 0)
            {
                MonthsTb2.BorderBrush = Brushes.Red;
                result = false;
            }

            return result;
        }
    }
}
