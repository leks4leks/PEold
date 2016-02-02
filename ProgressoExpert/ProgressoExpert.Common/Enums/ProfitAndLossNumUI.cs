using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Common.Enums
{
    public enum ProfitAndLossNumUI
    {
        // Просто присваиваем операциям номер, такой в очереди она и будет стоять при отрисовки таблички на UI
        /// <summary>
        /// 1. Доход от реализации 
        /// </summary>
        TotalIncome = 0,

        /// <summary>
        /// 2. Себестоимость
        /// </summary>
        TotalCostPrice = 1,

        /// <summary>
        /// 3. Валовая прибыль 
        /// </summary>
        GrossProfit = 2,

        /// <summary>
        /// 4. Прочий доход 
        /// </summary>
        OtherIncome = 3,

        /// <summary>
        /// 5. Расходы 
        /// </summary>
        Costs = 4,

        /// <summary>
        /// 6. Расходы по реализации продукции и услуг 
        /// </summary>
        CostsSalesServices = 5,

        /// <summary>
        /// 7. Административные расходы
        /// </summary>
        AdministrativeExpenses = 6,

        /// <summary>
        /// 8. Расходы на финансирование 
        /// </summary>
        FinancingCosts = 7,

        /// <summary>
        /// 9. Прочие расходы 
        /// </summary>
        OtherCosts = 8,

        /// <summary>
        /// 10. Операционная прибыль 
        /// </summary>
        OperatingProfit = 9,

        /// <summary>
        /// 11. Амортизация
        /// </summary>
        Depreciation = 10,

        /// <summary>
        /// 12. Прибыль до налогооблажения 
        /// </summary>
        ProfitBeforeTaxation = 11,

        /// <summary>
        /// 13. Прочие расходы 
        /// </summary>
        OtherTaxes = 12,

        /// <summary>
        /// 14. Расходы 
        /// </summary>
        KPN20 = 13,

        /// <summary>
        /// 15. Итоговая прибыль 
        /// </summary>
        TotalProfit = 14,
        
        /// <summary>
        /// Общее кол-во строк необходимых для построения таблицы
        /// </summary>     
        Total = 15,
    }
}									
										