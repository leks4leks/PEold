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
        int months;
        int daysInYear;

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
            //sum = Convert.ToDouble(SumTb.Text);
            //annualRate = Convert.ToDouble(AnnualRateTB.Text);
            months = Convert.ToInt32(MonthsTb.Text);
            daysInYear = Convert.ToInt32(DaysInYearTb.Text);

            percentInMonth = Math.Round(Sum * AnnualRate / 100 / daysInYear * daysInMonth, 0);
            incomeTax = Math.Round(phys.IsSelected ? percentInMonth * PercentForPhys / 100 : percentInMonth * PercentForJuric / 100, 0);
            profit = Math.Round(percentInMonth - incomeTax, 0);

            SumTotal = profit * months;
            PercentTotal = Math.Round(SumTotal / Sum * 100, 0);

            //ResultSumTb.Text = sumTotal.ToString();
            //ResultPercentTb.Text = percentTotal.ToString();

        }
    }
}
