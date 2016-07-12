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
            for(int i = 0; i < Months-1; i++)
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







        const int daysInMonth2 = 30;

        public List<CreditCalculatorTableModel> DataList2 { get; set; }

        /// <summary>
        /// Сумма займа
        /// </summary>
        public double Sum2
        {
            get { return _sum2; }
            set { SetValue(ref _sum2, value, "Sum2"); }
        }
        private double _sum2 = 0;

        /// <summary>
        /// Годовая ставка
        /// </summary>
        public double AnnualRate2
        {
            get { return _annualRate2; }
            set { SetValue(ref _annualRate2, value, "AnnualRate2"); }
        }
        private double _annualRate2 = 18;

        /// <summary>
        /// Месячная ставка
        /// </summary>
        public double MonthlyRate2
        {
            get { return _monthlyRate2; }
            set { SetValue(ref _monthlyRate2, value, "MonthlyRate2"); }
        }
        private double _monthlyRate2 = 0;

        /// <summary>
        /// Срок в месяцах
        /// </summary>
        public int Months2
        {
            get { return _months2; }
            set { SetValue(ref _months2, value, "Months2"); }
        }
        private int _months2 = 120;

        /// <summary>
        /// Дней в году
        /// </summary>
        public int DaysInYear2
        {
            get { return _daysInYear2; }
            set { SetValue(ref _daysInYear2, value, "DaysInYear2"); }
        }
        private int _daysInYear2 = 360;

        /// <summary>
        /// Итого
        /// </summary>
        public double SumTotal2
        {
            get { return _sumTotal2; }
            set { SetValue(ref _sumTotal2, value, "SumTotal2"); }
        }
        private double _sumTotal2 = 0;

        /// <summary>
        /// Сумма займа ??
        /// </summary>
        public double SumLoan2
        {
            get { return _sumLoan2; }
            set { SetValue(ref _sumLoan2, value, "SumLoan2"); }
        }
        private double _sumLoan2 = 0;

        /// <summary>
        /// Переплата
        /// </summary>
        public double Overpayment2
        {
            get { return _overPayment2; }
            set { SetValue(ref _overPayment2, value, "Overpayment2"); }
        }
        private double _overPayment2 = 0;

        /// <summary>
        /// Аннуитет
        /// </summary>
        public double Annuity2
        {
            get { return _annuity2; }
            set { SetValue(ref _annuity2, value, "Annuity2"); }
        }
        private double _annuity2 = 0;

        /// <summary>
        /// Отсрочка по ОД
        /// </summary>
        public double Delay2
        {
            get { return _delay2; }
            set { SetValue(ref _delay2, value, "Delay2"); }
        }
        private double _delay2 = 3;



        public void Calculate2()
        {
            MonthlyRate2 = AnnualRate2 / 12;
            Annuity2 = Sum2 * MonthlyRate2 / 100 / (1 - Math.Pow(1 + MonthlyRate2 / 100, Months2 * -1));

            DataList2 = new List<CreditCalculatorTableModel>();
            for (int i = 0; i < Months2 + Delay2 - 1; i++)
            {
                var item = new CreditCalculatorTableModel();
                item.Num = i + 1;

                // Остаток задолженности
                if (i == 0)
                {
                    item.DebtBalance = Sum2;
                }
                else
                {
                    item.DebtBalance = DataList2[i - 1].DebtBalance - DataList2[i - 1].RedemptionSum;
                }

                // Итого взнос
                item.TotalPayment = Annuity2;

                // Сумма вознаграждения
                item.RemunerationSum = item.DebtBalance * AnnualRate2 / 100 / DaysInYear2 * 30;

                // Сумма погашения ОД
                item.RedemptionSum = Delay2 - 1 > i
                    ? 0
                    : item.TotalPayment - item.RemunerationSum;

                DataList2.Add(item);

                Debug.Print("_____________________________________________");
                Debug.Print("item.Num:" + item.Num);
                Debug.Print("item.DebtBalance:" + item.DebtBalance);
                Debug.Print("item.RedemptionSum:" + item.RedemptionSum);
                Debug.Print("item.RemunerationSum:" + item.RemunerationSum);
                Debug.Print("item.TotalPayment:" + item.TotalPayment);
            }

            SumLoan2 = DataList2.Sum(i => i.RedemptionSum);
            Overpayment2 = DataList2.Sum(i => i.RemunerationSum);

            SumTotal2 = SumLoan2 + Overpayment2;

            Debug.Print("");
            Debug.Print("SumLoan:" + SumLoan2);
            Debug.Print("Overpayment:" + Overpayment2);
            Debug.Print("SumTotal:" + SumTotal2);
        }

        public void SetDefault2()
        {
            Sum2 = 0;
            AnnualRate2 = 10;
            Months2 = 36;
            DaysInYear2 = 365;
            Annuity2 = 0;
            Overpayment2 = 0;
            SumTotal2 = 0;
            SumLoan2 = 0;
        }
    }
}
