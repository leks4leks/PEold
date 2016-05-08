using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class CostsBusinessAnalysis : BaseViewModel
    {        
        /// <summary>
        /// Расходы
        /// </summary>
        public decimal allCosts
        {
            get { return _allCosts; }
            set { SetValue(ref _allCosts, value, "allCosts"); }
        }
        private decimal _allCosts = 0;

        /// <summary>
        /// разница с пред периодом
        /// </summary>
        public string difPastPeriod
        {
            get { return _difPastPeriod; }
            set { SetValue(ref _difPastPeriod, value, "difPastPeriod"); }
        }
        private string _difPastPeriod;

        /// <summary>
        /// макс расходы за период
        /// </summary>
        public decimal maxCostsByMonth
        {
            get { return _maxCostsByMonth; }
            set { SetValue(ref _maxCostsByMonth, value, "maxCostsByMonth"); }
        }
        private decimal _maxCostsByMonth;

        /// <summary>
        /// средние расходы
        /// </summary>
        public decimal averageCostsByMonth
        {
            get { return _averageCostsByMonth; }
            set { SetValue(ref _averageCostsByMonth, value, "averageCostsByMonth"); }
        }
        private decimal _averageCostsByMonth;
                        
        /// <summary>
        /// Диаграмма расходов
        /// </summary>
        public Dictionary<string, decimal> CostsDiagram
        {
            get { return _costsDiagram; }
            set { SetValue(ref _costsDiagram, value, "CostsDiagram"); }
        }
        private Dictionary<string, decimal> _costsDiagram;

        /// <summary>
        /// Продажи
        /// </summary>
        public Dictionary<string, decimal> SalesDiagram
        {
            get { return _salesDiagram; }
            set { SetValue(ref _salesDiagram, value, "SalesDiagram"); }
        }
        private Dictionary<string, decimal> _salesDiagram;
                
        /// <summary>
        /// Расходы
        /// </summary>
        public Dictionary<string, decimal> CostsByMonthDiagram
        {
            get { return _costsByMonthDiagram; }
            set { SetValue(ref _costsByMonthDiagram, value, "CostsByMonthDiagram"); }
        }
        private Dictionary<string, decimal> _costsByMonthDiagram;

        /// <summary>
        /// валовая прибыль
        /// </summary>
        public Dictionary<string, decimal> GrosProfitDiagram
        {
            get { return _grosProfitDiagram; }
            set { SetValue(ref _grosProfitDiagram, value, "GrosProfitDiagram"); }
        }
        private Dictionary<string, decimal> _grosProfitDiagram;
        
        /// <summary>
        /// Расходов начислено
        /// </summary>
        public decimal CostsComming
        {
            get { return _costsComming; }
            set { SetValue(ref _costsComming, value, "CostsComming"); }
        }
        private decimal _costsComming;
        
        /// <summary>
        /// Расходов оплачено
        /// </summary>
        public decimal CostsOut
        {
            get { return _costsOut; }
            set { SetValue(ref _costsOut, value, "CostsOut"); }
        }
        private decimal _costsOut;


        /// <summary>
        /// оплачено налогов
        /// </summary>
        public decimal paidTaxes
        {
            get { return _paidTaxes; }
            set { SetValue(ref _paidTaxes, value, "paidTaxes"); }
        }
        private decimal _paidTaxes;        

        /// <summary>
        /// Расходов начислено от продаж
        /// </summary>
        public decimal paidTaxesFromSales
        {
            get { return _paidTaxesFromSales; }
            set { SetValue(ref _paidTaxesFromSales, value, "paidTaxesFromSales"); }
        }
        private decimal _paidTaxesFromSales;
        
        /// <summary>
        /// Расходов начислено от валовой прибыли
        /// </summary>
        public decimal paidTaxesFromGrosProfit
        {
            get { return _paidTaxesFromGrosProfit; }
            set { SetValue(ref _paidTaxesFromGrosProfit, value, "paidTaxesFromGrosProfit"); }
        }
        private decimal _paidTaxesFromGrosProfit;
        
        /// <summary>
        /// расходы начислено
        /// </summary>
        public Dictionary<string, decimal> CostsCommingDiagram
        {
            get { return _costsCommingDiagram; }
            set { SetValue(ref _costsCommingDiagram, value, "CostsCommingDiagram"); }
        }
        private Dictionary<string, decimal> _costsCommingDiagram;

        /// <summary>
        /// расходы оплачено
        /// </summary>
        public Dictionary<string, decimal> CostsOutDiagram
        {
            get { return _сostsOutDiagram; }
            set { SetValue(ref _сostsOutDiagram, value, "CostsOutDiagram"); }
        }
        private Dictionary<string, decimal> _сostsOutDiagram;

    }
}
