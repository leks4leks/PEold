using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ProgressoExpert.Common.Const;
using ProgressoExpert.Models.Entities;

namespace ProgressoExpert.Models.Models
{
    public class SalesModel : BaseViewModel
    {
        /// <summary>
        /// продажи
        /// </summary>
        public List<SalesEnt> Sales
        {
            get { return _sales; }
            set { SetValue(ref _sales, value, "Sales"); }
        }
        private List<SalesEnt> _sales;

        /// <summary>
        /// месяц
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { SetValue(ref _Date, value, "Date"); }
        }
        private DateTime _Date;
    }
}
