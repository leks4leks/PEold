using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models
{
    public class ReportProfitAndLoss : BaseViewModel
    {
        /// <summary>
        /// Доход от реализации
        /// </summary>
        public List<decimal> TotalIncome
        {
            get { return _totalIncome; }
            set { SetValue(ref _totalIncome, value, "TotalIncome"); }
        }
        private List<decimal> _totalIncome;

        /// <summary>
        /// Доход от реализации - продажи
        /// </summary>
        public List<decimal> IncomeSale
        {
            get { return _incomeSale; }
            set { SetValue(ref _incomeSale, value, "IncomeSale"); }
        }
        private List<decimal> _incomeSale;

        /// <summary>
        /// Доход от реализации - сервис
        /// </summary>
        public List<decimal> IncomeService
        {
            get { return _incomeService; }
            set { SetValue(ref _incomeService, value, "IncomeService"); }
        }
        private List<decimal> _incomeService;

        /// <summary>
        /// Себестоимость 
        /// </summary>
        public List<decimal> TotalCostPrice
        {
            get { return _totalCostPrice; }
            set { SetValue(ref _totalCostPrice, value, "TotalCostPrice"); }
        }
        private List<decimal> _totalCostPrice;

        /// <summary>
        /// Себестоимость - продажи 
        /// </summary>
        public List<decimal> CostPriceSale
        {
            get { return _сostPriceSale; }
            set { SetValue(ref _сostPriceSale, value, "CostPriceSale"); }
        }
        private List<decimal> _сostPriceSale;

        /// <summary>
        /// Себестоимость - сервис 
        /// </summary>
        public List<decimal> CostPriceService
        {
            get { return _сostPriceService; }
            set { SetValue(ref _сostPriceService, value, "CostPriceService"); }
        }
        private List<decimal> _сostPriceService;

        /// <summary>
        /// Валовая прибыль
        /// </summary>
        public List<decimal> GrossProfit
        {
            get { return _grossProfit; }
            set { SetValue(ref _grossProfit, value, "GrossProfit"); }
        }
        private List<decimal> _grossProfit;

        /// <summary>
        /// Валовая прибыль - продажи
        /// </summary>
        public List<decimal> GrossProfitSale
        {
            get { return _grossProfitSale; }
            set { SetValue(ref _grossProfitSale, value, "GrossProfitSale"); }
        }
        private List<decimal> _grossProfitSale;

        /// <summary>
        /// Валовая прибыль - сервис
        /// </summary>
        public List<decimal> GrossProfitService
        {
            get { return _grossProfitService; }
            set { SetValue(ref _grossProfitService, value, "GrossProfitService"); }
        }
        private List<decimal> _grossProfitService;

        /// <summary>
        /// Расходы
        /// </summary>
        public List<decimal> Costs
        {
            get { return _сosts; }
            set { SetValue(ref _сosts, value, "Costs"); }
        }
        private List<decimal> _сosts;

        /// <summary>
        /// Заработная плата АП
        /// </summary>
        public List<decimal> SalaryAdmPer
        {
            get { return _salaryAdmPer; }
            set { SetValue(ref _salaryAdmPer, value, "SalaryAdmPer"); }
        }
        private List<decimal> _salaryAdmPer;

        /// <summary>
        /// ЗП отдла продаж
        /// </summary>
        public List<decimal> SalarySalesDepartment
        {
            get { return _salarySalesDepartment; }
            set { SetValue(ref _salarySalesDepartment, value, "SalarySalesDepartment"); }
        }
        private List<decimal> _salarySalesDepartment;

        /// <summary>
        /// ЗП сервис персонала
        /// </summary>
        public List<decimal> SalaryServicePer
        {
            get { return _salaryServicePer; }
            set { SetValue(ref _salaryServicePer, value, "SalaryServicePer"); }
        }
        private List<decimal> _salaryServicePer;

        /// <summary>
        /// Бонусы от продаж менеджера и продавцов
        /// </summary>
        public List<decimal> BonusesSalesManagerSellers
        {
            get { return _bonusesSalesManagerSellers; }
            set { SetValue(ref _bonusesSalesManagerSellers, value, "BonusesSalesManagerSellers"); }
        }
        private List<decimal> _bonusesSalesManagerSellers;

        /// <summary>
        /// Арендная плата за офис и склад
        /// </summary>
        public List<decimal> RentOfficeWarehouse
        {
            get { return _rentOfficeWarehouse; }
            set { SetValue(ref _rentOfficeWarehouse, value, "RentOfficeWarehouse"); }
        }
        private List<decimal> _rentOfficeWarehouse;
        
        /// <summary>
        /// Расходы по реализации
        /// </summary>
        public List<decimal> DistributionСosts
        {
            get { return _distributionСosts; }
            set { SetValue(ref _distributionСosts, value, "DistributionСosts"); }
        }
        private List<decimal> _distributionСosts;

        /// <summary>
        /// Прочие административные расходы
        /// </summary>
        public List<decimal> OtherAdministrativeExpenses
        {
            get { return _otherAdministrativeExpenses; }
            set { SetValue(ref _otherAdministrativeExpenses, value, "OtherAdministrativeExpenses"); }
        }
        private List<decimal> _otherAdministrativeExpenses;

        /// <summary>
        /// EBITDA
        /// </summary>
        public List<decimal> Ebitda
        {
            get { return _ebitda; }
            set { SetValue(ref _ebitda, value, "Ebitda"); }
        }
        private List<decimal> _ebitda;

        /// <summary>
        /// Проценты банка
        /// </summary>
        public List<decimal> BankInterest
        {
            get { return _bankInterest; }
            set { SetValue(ref _bankInterest, value, "BankInterest"); }
        }
        private List<decimal> _bankInterest;

        /// <summary>
        /// Амортизация
        /// </summary>
        public List<decimal> Depreciation
        {
            get { return _depreciation; }
            set { SetValue(ref _depreciation, value, "Depreciation"); }
        }
        private List<decimal> _depreciation;

        /// <summary>
        /// Прибыль до налогооблажения
        /// </summary>
        public List<decimal> ProfitBeforeTaxation
        {
            get { return _profitBeforeTaxation; }
            set { SetValue(ref _profitBeforeTaxation, value, "ProfitBeforeTaxation"); }
        }
        private List<decimal> _profitBeforeTaxation;

        /// <summary>
        /// КПН (20%)
        /// </summary>
        public List<decimal> KPN20
        {
            get { return _kpn20; }
            set { SetValue(ref _kpn20, value, "KPN20"); }
        }
        private List<decimal> _kpn20;

        /// <summary>
        /// Прибыль после налогооблажения
        /// </summary>
        public List<decimal> ProfitAfterTaxation
        {
            get { return _profitAfterTaxation; }
            set { SetValue(ref _profitAfterTaxation, value, "ProfitAfterTaxation"); }
        }
        private List<decimal> _profitAfterTaxation;
        
    }
}
