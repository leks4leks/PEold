using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models
{
    public class LiveStreamModel : BaseViewModel
    {
        #region Сегодня

        /// <summary>
        /// Продажи
        /// </summary>
        public decimal SalesToday
        {
            get { return _salesToday; }
            set { SetValue(ref _salesToday, value, "SalesToday"); }
        }
        private decimal _salesToday;

        /// <summary>
        /// Валовая прибыль
        /// </summary>
        public decimal GrossProfitToday
        {
            get { return _grossProfitToday; }
            set { SetValue(ref _grossProfitToday, value, "GrossProfitToday"); }
        }
        private decimal _grossProfitToday;

        /// <summary>
        /// Рентабельность
        /// </summary>
        public decimal ProfitabilityToday
        {
            get { return _profitabilityToday; }
            set { SetValue(ref _profitabilityToday, value, "ProfitabilityToday"); }
        }
        private decimal _profitabilityToday;

        /// <summary>
        /// Оплата клиентов
        /// </summary>
        public decimal PaymentCustomersToday
        {
            get { return _paymentCustomersToday; }
            set { SetValue(ref _paymentCustomersToday, value, "PaymentCustomersToday"); }
        }
        private decimal _paymentCustomersToday;

        #endregion



        #region Текущий месяц

        /// <summary>
        /// Продажи
        /// </summary>
        public decimal SalesMonth
        {
            get { return _salesMonth; }
            set { SetValue(ref _salesMonth, value, "SalesMonth"); }
        }
        private decimal _salesMonth;

        /// <summary>
        /// Валовая прибыль
        /// </summary>
        public decimal GrossProfitMonth
        {
            get { return _grossProfitMonth; }
            set { SetValue(ref _grossProfitMonth, value, "GrossProfitMonth"); }
        }
        private decimal _grossProfitMonth;

        /// <summary>
        /// Рентабельность
        /// </summary>
        public decimal ProfitabilityMonth
        {
            get { return _profitabilityMonth; }
            set { SetValue(ref _profitabilityMonth, value, "ProfitabilityMonth"); }
        }
        private decimal _profitabilityMonth;

        /// <summary>
        /// Оплата клиентов
        /// </summary>
        public decimal PaymentCustomersMonth
        {
            get { return _paymentCustomersMonth; }
            set { SetValue(ref _paymentCustomersMonth, value, "PaymentCustomersMonth"); }
        }
        private decimal _paymentCustomersMonth;

        #endregion
    }
}
