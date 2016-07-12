using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.App
{
    public class AnnCreditCalculatorModel : BaseViewModel
    {
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



        public void Calculate()
        {
            MonthlyRate2 = AnnualRate2 / 12;
            Annuity2 = Sum2 * MonthlyRate2 / 100 / (1-Math.Pow(1 + MonthlyRate2 / 100, Months2 * -1));

            DataList2 = new List<CreditCalculatorTableModel>();
            for(int i = 0; i < Months2 + Delay2-1; i++)
            {
                var item = new CreditCalculatorTableModel();
                item.Num = i+1;

                // Остаток задолженности
                if (i==0)
                {
                    item.DebtBalance = Sum2;
                }
                else
                {
                    item.DebtBalance = DataList2[i-1].DebtBalance - DataList2[i-1].RedemptionSum;
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

        public void SetDefault()
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
