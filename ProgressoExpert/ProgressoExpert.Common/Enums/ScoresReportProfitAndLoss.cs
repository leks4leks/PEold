using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Common.Enums
{
    public enum ScoresReportProfitAndLoss
    {
        // TODO: Где Enum = 0 - индивидуальная настройка для каждого потенциального клиента

        /// <summary>
        /// 2. Доход от реализации  - продажи 6010
        /// </summary>
        IncomeSale = 6010,

        /// <summary>
        /// 3. Доход от реализации  - сервис 6020
        /// </summary>
        IncomeService1 = 6020,

        /// <summary>
        /// 3. Доход от реализации  - сервис 6030
        /// </summary>
        IncomeService2 = 6030,

        /// <summary>
        /// 3. Доход от реализации  - сервис 6100
        /// </summary>
        IncomeService3 = 6100,

        /// <summary>
        /// 3. Доход от реализации  - сервис 6200
        /// </summary>
        IncomeService4 = 6200,

        /// <summary>
        /// 3. Доход от реализации  - сервис 6300
        /// </summary>
        IncomeService5 = 6300,

        /// <summary>
        /// 3. Доход от реализации  - сервис 6400
        /// </summary>
        IncomeService6 = 6400,
        
        /// <summary>
        /// 5. Себестоимость - продажи 7011
        /// </summary>
        СostPriceSale1 = 7010,

        /// <summary>
        /// 5. Себестоимость - продажи 7012
        /// </summary>
        СostPriceSale2 = 7012,

        /// <summary>
        /// 6. Себестоимость - сервис 7013
        /// </summary>
        СostPriceService = 7013,

        /// <summary>
        /// 11. Заработная плата АП - расходы -1
        /// </summary>
        SalaryAdmPer = -1,

        /// <summary>
        /// 12. ЗП отдла продаж - расходы 7211
        /// </summary>
        SalarySalesDepartment = 7211,

        /// <summary>
        /// 13. ЗП сервис персонала - расходы 7212
        /// </summary>
        SalaryServicePer = 7212,

        /// <summary>
        /// 14. Бонусы от продаж менеджера и продавцов - расходы -1
        /// </summary>        
        BonusesSalesManagerSellers = -1,
        
        /// <summary>
        /// 15. Арендная плата за офис и склад - расходы 7450
        /// </summary>        
        RentOfficeWarehouse = 7450,

        /// <summary>
        /// 16. Расходы по реализации - расходы 7100
        /// </summary>      
        DistributionСosts = 7100,

        /// <summary>
        /// 17. Прочие административные расходы - расходы -1
        /// </summary>      
        OtherAdministrativeExpenses = -1,

        /// <summary>
        /// 19. Проценты банка - 7300
        /// </summary>     
        BankInterest = 7300,

        /// <summary>
        /// 19. Амортизация - 7410
        /// </summary>  
        Depreciation1 = 7410,

        /// <summary>
        /// 19. Амортизация - 7420
        /// </summary>     
        Depreciation2 = 7420,

        /// <summary>
        /// 19. КПН (20%) - 7710
        /// </summary>     
        KPN20 = 7710
    }
}									
										