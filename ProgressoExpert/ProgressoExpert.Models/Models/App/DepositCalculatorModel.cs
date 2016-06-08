using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.App
{
    public class DepositCalculatorModel : BaseViewModel
    {
        const int daysInMonth = 30;

        private double _sum = 0;
        public double Sum
        {
            get { return _sum; }
            set { SetValue(ref _sum, value, "Sum"); }
        }
        private double _annualRate = 0;
        public double AnnualRate
        {
            get { return _annualRate; }
            set { SetValue(ref _annualRate, value, "AnnualRate"); }
        }
        private int _months = 12;
        public int Months
        {
            get { return _months; }
            set { SetValue(ref _months, value, "Months"); }
        }
        private int _daysInYear = 360;
        public int DaysInYear
        {
            get { return _daysInYear; }
            set { SetValue(ref _daysInYear, value, "DaysInYear"); }
        }

        private double _sumTotal = 0;
        public double SumTotal
        {
            get { return _sumTotal; }
            set { SetValue(ref _sumTotal, value, "SumTotal"); }

        }
        private double _percentTotal = 0;
        public double PercentTotal
        {
            get { return _percentTotal; }
            set { SetValue(ref _percentTotal, value, "PercentTotal"); }
        }

        private double _percentForJuric = 20;
        public double PercentForJuric
        {
            get { return _percentForJuric; }
            set { SetValue(ref _percentForJuric, value, "PercentForJuric"); }
        }

        private double _percentForPhys = 10;
        public double PercentForPhys
        {
            get { return _percentForPhys; }
            set { SetValue(ref _percentForPhys, value, "PercentForPhys"); }
        }

        private double _percentInMonth;
        public double PercentInMonth
        {
            get { return _percentInMonth; }
            set { SetValue(ref _percentInMonth, value, "PercentInMonth"); }
        }

        private double _incomeTax;
        public double IncomeTax
        {
            get { return _incomeTax; }
            set { SetValue(ref _incomeTax, value, "IncomeTax"); }
        }

        private double _profit;
        public double Profit
        {
            get { return _profit; }
            set { SetValue(ref _profit, value, "Profit"); }
        }

        public void Calculate(bool _isPhysSelected)
        {
            PercentInMonth = Math.Round(Sum * AnnualRate / 100 / DaysInYear * daysInMonth, 0);
            IncomeTax = Math.Round(_isPhysSelected ? PercentInMonth * PercentForPhys / 100 : PercentInMonth * PercentForJuric / 100, 0);
            Profit = Math.Round(PercentInMonth - IncomeTax, 0);

            SumTotal = Profit * Months;
            PercentTotal = Math.Round(SumTotal / Sum * 100, 0);

            //ResultSumTb.Text = string.Format(FormatUtils.Thousand2, SumTotal);
            //ResultPercentTb.Text = string.Format(FormatUtils.Percentage, PercentTotal);
        }

        public void SetDefault()
        {
            Sum = 0;
            AnnualRate = 10;
            Months = 12;
            DaysInYear = 365;
            PercentForPhys = 10;
            PercentForJuric = 20;
            SumTotal = 0;
            PercentTotal = 0;
            PercentInMonth = 0;
        }
    }
}
