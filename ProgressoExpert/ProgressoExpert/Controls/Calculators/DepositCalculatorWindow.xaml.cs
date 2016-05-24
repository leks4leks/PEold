using ProgressoExpert.Controls.Utils;
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
        const int daysInMonth = 30;

        private double _sum = 0;
        public double Sum
        {
            get { return _sum; }
            set
            {
                if (value != _sum)
                {
                    _sum = value;
                }
            }
        }
        private double _annualRate = 0;
        public double AnnualRate
        {
            get { return _annualRate; }
            set
            {
                if (value != _annualRate)
                {
                    _annualRate = value;
                }
            }
        }
        private int _months = 12;
        public int Months
        {
            get { return _months; }
            set
            {
                if (value != _months)
                {
                    _months = value;
                }
            }
        }
        private int _daysInYear = 365;
        public int DaysInYear
        {
            get { return _daysInYear; }
            set
            {
                if (value != _daysInYear)
                {
                    _daysInYear = value;
                }
            }
        }

        double percentInMonth;
        double incomeTax;
        double profit;

        private double _sumTotal = 0;
        public double SumTotal
        {
            get { return _sumTotal; }
            set
            {
                if (value != _sumTotal)
                {
                    _sumTotal = value;
                }
            }
        }
        private double _percentTotal = 0;
        public double PercentTotal
        {
            get { return _percentTotal; }
            set
            {
                if (value != _percentTotal)
                {
                    _percentTotal = value;
                }
            }
        }

        private double _percentForJuric = 20;
        public double PercentForJuric
        {
            get { return _percentForJuric; }
            set
            {
                if (value != _percentForJuric)
                {
                    _percentForJuric = value;
                }
            }
        }

        private double _percentForPhys = 10;
        public double PercentForPhys
        {
            get { return _percentForPhys; }
            set
            {
                if (value != _percentForPhys)
                {
                    _percentForPhys = value;
                }
            }
        }

        public DepositCalculatorWindow()
        {
            InitializeComponent();
            this.DataContext = this;
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
                percentInMonth = Math.Round(Sum * AnnualRate / 100 / DaysInYear * daysInMonth, 0);
                incomeTax = Math.Round(phys.IsSelected ? percentInMonth * PercentForPhys / 100 : percentInMonth * PercentForJuric / 100, 0);
                profit = Math.Round(percentInMonth - incomeTax, 0);

                SumTotal = profit * Months;
                PercentTotal = Math.Round(SumTotal / Sum * 100, 0);

                ResultSumTb.Text = string.Format(FormatUtils.Thousand2, SumTotal);
                ResultPercentTb.Text = string.Format(FormatUtils.Percentage, PercentTotal);
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
            DaysInYearTb.BorderBrush = Brushes.Gray;
            TaxForJuric.BorderBrush = Brushes.Gray;
            TaxForPhysTb.BorderBrush = Brushes.Gray;

            var result = true;
            if (Sum <= 0)
            {
                SumTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (AnnualRate <= 0)
            {
                AnnualRateTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (Months <= 0)
            {
                MonthsTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (DaysInYear <= 0)
            {
                DaysInYearTb.BorderBrush = Brushes.Red;
                result = false;
            }
            if (PercentForJuric <= 0)
            {
                TaxForJuric.BorderBrush = Brushes.Red;
                result = false;
            }
            if (PercentForPhys <= 0)
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
            Sum = 0;
            AnnualRate = 10;
            Months = 12;
            DaysInYear = 365;
            PercentForPhys = 10;
            PercentForJuric = 20;
            ResultSumTb.Text = string.Empty;
            ResultPercentTb.Text = string.Empty;
            this.DataContext = this;
        }

    }
}
