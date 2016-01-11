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
        Income = 0,

        /// <summary>
        /// 2. Доход от реализации  - продажи
        /// </summary>
        IncomeSale = 1,

        /// <summary>
        /// 3. Доход от реализации  - сервис
        /// </summary>
        IncomeService = 2,

        /// <summary>
        /// 4. Себестоимость 
        /// </summary>
        CostPrice = 3,
        
        /// <summary>
        /// 5. Себестоимость - продажи
        /// </summary>
        CostPriceSale = 4,
        
        /// <summary>
        /// 6. Себестоимость - сервис
        /// </summary>
        CostPriceService = 5,

        /// <summary>
        /// 7. Валовая прибыль
        /// </summary>
        GrossProfit = 6,

        /// <summary>
        /// 8. Валовая прибыль - продажи
        /// </summary>
        GrossProfitSale = 7,

        /// <summary>
        /// 9. Валовая прибыль - сервис
        /// </summary>
        GrossProfitService = 8,

        /// <summary>
        /// 10. Расходы
        /// </summary>
        Costs = 9,

        /// <summary>
        /// 11. Заработная плата АП - расходы
        /// </summary>
        SalaryAdmPer = 10,

        /// <summary>
        /// 12. ЗП отдла продаж - расходы
        /// </summary>
        SalarySalesDepartment = 11,

        /// <summary>
        /// 13. ЗП сервис персонала - расходы
        /// </summary>
        SalaryServicePer = 12,

        /// <summary>
        /// 14. Бонусы от продаж менеджера и продавцов - расходы
        /// </summary>        
        BonusesSalesManagerSellers = 13,
        
        /// <summary>
        /// 15. Арендная плата за офис и склад - расходы
        /// </summary>        
        RentOfficeWarehouse = 14,

        /// <summary>
        /// 16. Расходы по реализации - расходы
        /// </summary>      
        DistributionСosts = 15,

        /// <summary>
        /// 17. Прочие административные расходы - расходы
        /// </summary>      
        OtherAdministrativeExpenses = 16,

        /// <summary>
        /// 18. Ebitda
        /// </summary>     
        Ebitda = 17,

        /// <summary>
        /// 19. Проценты банка
        /// </summary>     
        BankInterest = 18,

        /// <summary>
        /// 20. Амортизация
        /// </summary>  
        Depreciation = 19,

        /// <summary>
        /// 21. Прибыль до налогооблажения
        /// </summary>  
        ProfitBeforeTaxation = 20,
        
        /// <summary>
        /// 22. КПН (20%)
        /// </summary>     
        KPN20 = 21,

        /// <summary>
        /// 23. Прибыль после налогооблажения
        /// </summary>  
        ProfitAfterTaxation = 22,

        /// <summary>
        /// Общее кол-во строк необходимых для построения таблицы
        /// </summary>     
        Total = 23,
    }
}									
										