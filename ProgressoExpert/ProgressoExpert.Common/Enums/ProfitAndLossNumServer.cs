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
        /// Доход от реализации товаров и услуг
        /// </summary>
        Income = 0,
        /// <summary>
        /// Себестоимость
        /// </summary>
        CostPrice = 1,
        /// <summary>
        /// Прочий доход
        /// </summary>
        OtherIncome = 2,
        /// <summary>
        /// Расходы по реализации продукции и услуг
        /// </summary>
        CostsSalesServices = 3,
        /// <summary>
        /// Административные расходы
        /// </summary>
        AdministrativeExpenses = 4,
        /// <summary>
        /// Расходы на финансирование
        /// </summary>
        FinancingCosts = 5,
        /// <summary>
        /// Прочие расходы
        /// </summary>
        OtherCosts = 6,
        /// <summary>
        /// Амортизация
        /// </summary>
        Depreciation = 7,
        /// <summary>
        /// Прочие налоги
        /// </summary>
        OtherTaxes = 8,
        /// <summary>
        /// KPN20
        /// </summary>
        KPN20 = 9,

        /// <summary>
        /// Общее кол-во строк необходимых для построения таблицы
        /// </summary>     
        Total = 10,
    }
}									
										