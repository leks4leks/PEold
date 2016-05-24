using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ProgressoExpert.Common.Const;

namespace ProgressoExpert.Models.Models.App
{
    public class InfoModel : BaseViewModel
    {
        private Timer timer;
        private Timer timer2;

        private int index = 0;

        /// <summary>
        /// Наименование фирмы
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { SetValue(ref _companyName, value, "CompanyName"); }
        }
        private string _companyName;


        /// <summary>
        /// Текущий день недели
        /// </summary>
        public string DayOfWeek
        {
            get { return _dayOfWeek.ToUpper(); }
            set { SetValue(ref _dayOfWeek, value, "DayOfWeek"); }
        }
        private string _dayOfWeek;

        /// <summary>
        /// Текущая дата
        /// </summary>
        public string CurrentDate
        {
            get { return _currentDate; }
            set { SetValue(ref _currentDate, value, "CurrentDate"); }
        }
        private string _currentDate;

        /// <summary>
        /// Время
        /// </summary>
        public string CurrentTime
        {
            get { return _currentTime; }
            set { SetValue(ref _currentTime, value, "CurrentTime"); }
        }
        private string _currentTime;

        /// <summary>
        /// Котировки валют
        /// </summary>
        public string CurrencyRate
        {
            get { return _currencyRate; }
            set { SetValue(ref _currencyRate, value, "CurrencyRate"); }
        }
        private string _currencyRate;

        public List<CurrencyRate> CurrencyRateList;

        public InfoModel()
        {
            DayOfWeek = DateTime.Now.ToString(CommonConst.DayOfWeekFormat).First().ToString().ToUpper() 
                + DateTime.Now.ToString(CommonConst.DayOfWeekFormat).Substring(1);
            CurrentDate = DateTime.Now.ToString(CommonConst.DateFormat);

            timer = new Timer() { Interval = 500 };
            timer.Elapsed += timer_Elapsed;
            timer.Start();


            CompanyName = "Наименование фирмы";
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now.ToString(CommonConst.TimeFormat);
            if (CurrentDate != DateTime.Now.ToString(CommonConst.DateFormat))
            {
                DayOfWeek = DateTime.Now.ToString(CommonConst.DayOfWeekFormat).First().ToString().ToUpper() 
                    + DateTime.Now.ToString(CommonConst.DayOfWeekFormat).Substring(1);
                CurrentDate = DateTime.Now.ToString(CommonConst.DateFormat);
            }
        }

        public void StartTimer2()
        {
            timer2 = new Timer() { Interval = 5000 };
            timer2.Elapsed += timer2_Elapsed;
            timer2.Start();
        }

        void timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrencyRate = string.Format("{0}/KZT - {1}    {2}", CurrencyRateList[index].Name,
                CurrencyRateList[index].ExchangeRate, CurrencyRateList[index].Change);
            index++;
            if (index > 2)
            {
                index = 0;
            }
        }
    }
}
