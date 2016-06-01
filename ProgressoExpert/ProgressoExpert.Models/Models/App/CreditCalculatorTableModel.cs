using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.App
{
    public class CreditCalculatorTableModel
    {
        /// <summary>
        /// Номер взноса
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// Остаток задолженности
        /// </summary>
        public double DebtBalance { get; set; }

        /// <summary>
        /// Сумма погашения ОД
        /// </summary>
        public double RedemptionSum { get; set; }

        /// <summary>
        ///  Сумма вознаграждения 
        /// </summary>
        public double RemunerationSum { get; set; }

        /// <summary>
        ///  Итого взнос
        /// </summary>
        public double TotalPayment { get; set; }
    }
}
