using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Common.Enums
{
    public enum ScoresForBusinessResults : long
    {
        #region Сумма графы "Итого краткосрочные активы" и "Итого долгосрочные активы активы" является показателем графы "Итого Валюта Баланса"
        #region Сумма статей с 1 по 4 является показателем графы "Итого краткосрочные активы"
        /// <summary>
        /// 1. Денежные средства - 1000
        /// </summary>
        Cash = 10,

        /// <summary>
        /// 2. Краткосрочная Дебиторская задолженность - 1200
        /// </summary>        
        ShortTermReceivables = 12,

        /// <summary>
        /// 3. Запасы - 1300
        /// </summary>
        Inventories = 13,

        /// <summary>
        /// 4. Прочие краткосрочные активы - 1100, 1400, 1500, 1600
        /// </summary>        
        OtherCurrentAssets = 11141516,
        #endregion

        #region Сумма статей с 5 по 8 является показателем графы "Итого долгосрочные активы активы"
        /// <summary>
        /// 5. Долгосрочная Дебиторская задолженность - 2100
        /// </summary>        
        LongTermReceivables = 21,

        /// <summary>
        /// 6. Прочие долгосрочные активы - 2000, 2500, 2600, 2700, 2800, 2900
        /// </summary>        
        OtherLongTermReceivables = 202526272829,

        /// <summary>
        /// 7. Инвестиции - 2200, 2300
        /// </summary>   
        Investments = 2223,

        /// <summary>
        /// 8. Основные средства - 2400
        /// </summary>        
        FixedAssets = 24,
        #endregion
        #endregion

        #region Сумма графы "Итого краткосрочная задолженность", "Итого долгосрочная задолженность", "Собственный капитал" является показателем графы "Итого Валюта Баланса" (в правой стороне Баланса)
        #region Сумма статей с 9 по 12 является показателем графы "Итого краткосрочная задолженность"
        /// <summary>
        /// 9. Краткосрочные Долги перед Банком - 3000
        /// </summary>        
        ShortTermDebtsBanks = 30,

        /// <summary>
        /// 10. Долги перед Налоговой и прочим платежам в бюджет - 3100, 3200
        /// </summary>   
        DebtsTaxAndOtherPaymentsBudget = 3132,

        /// <summary>
        /// 11. Краткосрочные Долги перед поставщиками/покупателями - 3300
        /// </summary>           
        ShortTermDebtsSupplierBuyers = 33,

        /// <summary>
        /// 12. Прочие долги - 3400, 3500
        /// </summary>        
        OtherDebts = 3435,
        #endregion

        #region Сумма статей с 13 по 15 является показателем графы "Итого долгосрочная задолженность"
        /// <summary>
        /// 13. Долгосрочные Долги перед Банком - 4000
        /// </summary>   
        LongTermDebtsBanks = 40,

        /// <summary>
        /// 14. Долгосрочные Долги перед поставщиками/покупателями - 4100
        /// </summary>  
        LongTermDebtSuppliersBuyers = 41,

        /// <summary>
        /// 15. Прочие долгосрочные долги - 4200, 4300, 4400
        /// </summary>        
        OtherLongTermDebt = 424344,
        #endregion

        /// <summary>
        /// 16. Собственный капитал - 5000, 5100, 5200, 5300, 5400, 5500, 5600
        /// </summary>        
        Equity = 505152535455556,
        #endregion
    }
}									
										