using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.App
{
    public class CreditCalculatorModel : BaseViewModel
    {
        const int daysInMonth = 30;

        public List<CreditCalculatorTableModel> DataList { get; set; }

        /// <summary>
        /// Сумма займа
        /// </summary>
        public double Sum
        {
            get { return _sum; }
            set { SetValue(ref _sum, value, "Sum"); }
        }
        private double _sum = 0;

        /// <summary>
        /// Годовая ставка
        /// </summary>
        public double AnnualRate
        {
            get { return _annualRate; }
            set { SetValue(ref _annualRate, value, "AnnualRate"); }
        }
        private double _annualRate = 18;

        /// <summary>
        /// Месячная ставка
        /// </summary>
        public double MonthlyRate
        {
            get { return _monthlyRate; }
            set { SetValue(ref _monthlyRate, value, "MonthlyRate"); }
        }
        private double _monthlyRate = 0;

        /// <summary>
        /// Срок в месяцах
        /// </summary>
        public int Months
        {
            get { return _months; }
            set { SetValue(ref _months, value, "Months"); }
        }
        private int _months = 120;

        /// <summary>
        /// Дней в году
        /// </summary>
        public int DaysInYear
        {
            get { return _daysInYear; }
            set { SetValue(ref _daysInYear, value, "DaysInYear"); }
        }
        private int _daysInYear = 360;

        /// <summary>
        /// Итого
        /// </summary>
        public double SumTotal
        {
            get { return _sumTotal; }
            set { SetValue(ref _sumTotal, value, "SumTotal"); }
        }
        private double _sumTotal = 0;

        /// <summary>
        /// Сумма займа ??
        /// </summary>
        public double SumLoan
        {
            get { return _sumLoan; }
            set { SetValue(ref _sumLoan, value, "SumLoan"); }
        }
        private double _sumLoan = 0;

        /// <summary>
        /// Переплата
        /// </summary>
        public double Overpayment
        {
            get { return _overPayment; }
            set { SetValue(ref _overPayment, value, "Overpayment"); }
        }
        private double _overPayment = 0;

        /// <summary>
        /// Отсрочка по ОД
        /// </summary>
        public double Delay
        {
            get { return _delay; }
            set { SetValue(ref _delay, value, "Delay"); }
        }
        private double _delay = 3;



        public void Calculate()
        {
            MonthlyRate = AnnualRate / 12;

            DataList = new List<CreditCalculatorTableModel>();
            for(int i = 0; i < Months+Delay-1; i++)
            {
                var item = new CreditCalculatorTableModel();
                item.Num = i+1;

                // Остаток задолженности
                if (i==0)
                {
                    item.DebtBalance = Sum;
                }
                else
                {
                    item.DebtBalance = DataList[i-1].DebtBalance - DataList[i-1].RedemptionSum;
                }   

                // Сумма вознаграждения
                item.RemunerationSum = item.DebtBalance * AnnualRate / 100 / DaysInYear * 30;

                // Сумма погашения ОД
                item.RedemptionSum = Delay > 0
                    ? Delay <= item.Num
                        ? Sum / (Months - Delay)
                        : 0
                    : Sum / Months;

                // Итого взнос
                item.TotalPayment = item.RedemptionSum + item.RemunerationSum;

                DataList.Add(item);

                Debug.Print("_____________________________________________");
                Debug.Print("item.Num:" + item.Num);
                Debug.Print("item.DebtBalance:" + item.DebtBalance);
                Debug.Print("item.RedemptionSum:" + item.RedemptionSum);
                Debug.Print("item.RemunerationSum:" + item.RemunerationSum);
                Debug.Print("item.TotalPayment:" + item.TotalPayment);
            }

            SumLoan = DataList.Sum(i => i.RedemptionSum);
            Overpayment = DataList.Sum(i => i.RemunerationSum);

            SumTotal = SumLoan + Overpayment;

            Debug.Print("");
            Debug.Print("SumLoan:" + SumLoan);
            Debug.Print("Overpayment:" + Overpayment);
            Debug.Print("SumTotal:" + SumTotal);
        }

        public void SetDefault()
        {
            Sum = 0;
            AnnualRate = 10;
            Months = 36;
            DaysInYear = 365;
            Overpayment = 0;
            SumTotal = 0;
            SumLoan = 0;
        }
    }
}
