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
        /// Доход от реализации товаров и услуг
        /// </summary>
        public List<decimal> TotalIncome
        {
            get { return _totalIncome; }
            set { SetValue(ref _totalIncome, value, "TotalIncome"); }
        }
        private List<decimal> _totalIncome;
        
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
        /// Валовая прибыль
        /// </summary>
        public List<decimal> GrossProfit
        {
            get { return _grossProfit; }
            set { SetValue(ref _grossProfit, value, "GrossProfit"); }
        }
        private List<decimal> _grossProfit;
        
        /// <summary>
        /// Прочий доход
        /// </summary>
        public List<decimal> OtherIncome
        {
            get { return _otherIncome; }
            set { SetValue(ref _otherIncome, value, "OtherIncome"); }
        }
        private List<decimal> _otherIncome;

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
        /// Расходы по реализации продукции и услуг
        /// </summary>
        public List<decimal> CostsSalesServices
        {
            get { return _costsSalesServices; }
            set { SetValue(ref _costsSalesServices, value, "CostsSalesServices"); }
        }
        private List<decimal> _costsSalesServices;

        /// <summary>
        /// Административные расходы
        /// </summary>
        public List<decimal> AdministrativeExpenses
        {
            get { return _administrativeExpenses; }
            set { SetValue(ref _administrativeExpenses, value, "AdministrativeExpenses"); }
        }
        private List<decimal> _administrativeExpenses;

        /// <summary>
        /// Расходы на финансирование
        /// </summary>
        public List<decimal> FinancingCosts
        {
            get { return _financingCosts; }
            set { SetValue(ref _financingCosts, value, "FinancingCosts"); }
        }
        private List<decimal> _financingCosts;

        /// <summary>
        /// Прочие расходы
        /// </summary>
        public List<decimal> OtherCosts
        {
            get { return _otherCosts; }
            set { SetValue(ref _otherCosts, value, "OtherCosts"); }
        }
        private List<decimal> _otherCosts;

        /// <summary>
        /// Операционная прибыль
        /// </summary>
        public List<decimal> OperatingProfit
        {
            get { return _operatingProfitt; }
            set { SetValue(ref _operatingProfitt, value, "OperatingProfit"); }
        }
        private List<decimal> _operatingProfitt;

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
        /// Прочие налоги
        /// </summary>
        public List<decimal> OtherTaxes
        {
            get { return _otherTaxes; }
            set { SetValue(ref _otherTaxes, value, "OtherTaxes"); }
        }
        private List<decimal> _otherTaxes;

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
        /// Итоговая прибыль
        /// </summary>
        public List<decimal> TotalProfit
        {
            get { return _totalProfit; }
            set { SetValue(ref _totalProfit, value, "TotalProfit"); }
        }
        private List<decimal> _totalProfit;

        /// <summary>
        /// Валовая рентабельность 
        /// </summary>
        public decimal GrossMargin
        {
            get { return _grossMargin; }
            set { SetValue(ref _grossMargin, value, "GrossMargin"); }
        }
        private decimal _grossMargin;

        /// <summary>
        /// Чистая рентабельность 
        /// </summary>
        public decimal NetMargin
        {
            get { return _netMargin; }
            set { SetValue(ref _netMargin, value, "NetMargin"); }
        }
        private decimal _netMargin;

        /// <summary>
        /// Коэффициент обслуживания процентов
        /// </summary>
        public decimal ServiceRatioPercent
        {
            get { return _serviceRatioPercent; }
            set { SetValue(ref _serviceRatioPercent, value, "ServiceRatioPercent"); }
        }
        private decimal _serviceRatioPercent;

        public void Calculate()
        {
            GrossMargin = Divide(TotalIncome[TotalIncome.Count - 2], GrossProfit[GrossProfit.Count - 2]);
            NetMargin = Divide(TotalIncome[TotalIncome.Count - 2], TotalProfit[TotalProfit.Count - 2]);
            ServiceRatioPercent = Divide(FinancingCosts[FinancingCosts.Count - 2], OperatingProfit[OperatingProfit.Count - 2]);
        }

        private decimal Divide(decimal value1, decimal value2)
        {
            decimal result;
            try
            {
                result = value1 / value2;
            }
            catch { result = 0; }
            return result;
        }
        
    }
}
