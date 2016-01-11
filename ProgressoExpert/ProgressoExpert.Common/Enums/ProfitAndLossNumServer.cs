using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Common.Enums
{
    public enum ProfitAndLossNumServer
    {
        // Просто присваиваем операциям номер, такой в очереди она и будет стоять при получении данных из БД
        /// <summary>
        /// 2. Доход от реализации  - продажи
        /// </summary>
        IncomeSale = 0,

        /// <summary>
        /// 3. Доход от реализации  - сервис
        /// </summary>
        IncomeService = 1,
        
        /// <summary>
        /// 5. Себестоимость - продажи
        /// </summary>
        CostPriceSale = 2,
        
        /// <summary>
        /// 6. Себестоимость - сервис
        /// </summary>
        CostPriceService = 3,

        /// <summary>
        /// 11. Заработная плата АП - расходы 
        /// </summary>
        SalaryAdmPer = 4,

        /// <summary>
        /// 12. ЗП отдла продаж - расходы
        /// </summary>
        SalarySalesDepartment = 5,

        /// <summary>
        /// 13. ЗП сервис персонала - расходы
        /// </summary>
        SalaryServicePer = 6,

        /// <summary>
        /// 14. Бонусы от продаж менеджера и продавцов - расходы 
        /// </summary>        
        BonusesSalesManagerSellers = 7,
        
        /// <summary>
        /// 15. Арендная плата за офис и склад - расходы
        /// </summary>        
        RentOfficeWarehouse = 8,

        /// <summary>
        /// 16. Расходы по реализации - расходы
        /// </summary>      
        DistributionСosts = 9,

        /// <summary>
        /// 17. Прочие административные расходы - расходы 
        /// </summary>      
        OtherAdministrativeExpenses = 10,

        /// <summary>
        /// 19. Проценты банка
        /// </summary>     
        BankInterest = 11,

        /// <summary>
        /// 19. Амортизация
        /// </summary>  
        Depreciation = 12,
        
        /// <summary>
        /// 19. КПН (20%)
        /// </summary>     
        KPN20 = 13,

        /// <summary>
        /// Общее кол-во строк необходимых для построения таблицы
        /// </summary>     
        Total = 14,
    }
}									
										