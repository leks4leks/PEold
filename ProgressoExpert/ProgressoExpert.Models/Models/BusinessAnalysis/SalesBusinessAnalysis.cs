using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class SalesBusinessAnalysis : BaseViewModel
    {        
        /// <summary>
        /// макс продажи в месяц за период
        /// </summary>
        public decimal maxCountSaleGoods
        {
            get { return _maxCountSaleGoods; }
            set { SetValue(ref _maxCountSaleGoods, value, "maxCountSaleGoods"); }
        }
        private decimal _maxCountSaleGoods;

        /// <summary>
        /// месяц за который были макс продажи за период
        /// </summary>
        public string MonthOfMaxCountSaleGoods
        {
            get { return _monthOfMaxCountSaleGoods; }
            set { SetValue(ref _monthOfMaxCountSaleGoods, value, "MonthOfMaxCountSaleGoods"); }
        }
        private string _monthOfMaxCountSaleGoods;

        /// <summary>
        /// средние продажи в месяц за период
        /// </summary>
        public decimal maxAverageCountSaleGoods
        {
            get { return _maxAverageCountSaleGoods; }
            set { SetValue(ref _maxAverageCountSaleGoods, value, "maxAverageCountSaleGoods"); }
        }
        private decimal _maxAverageCountSaleGoods;

        /// <summary>
        /// сумма продаж
        /// </summary>
        public decimal SummSaleGoods
        {
            get { return _summSaleGoods; }
            set { SetValue(ref _summSaleGoods, value, "SummSaleGoods"); }
        }
        private decimal _summSaleGoods;

        /// <summary>
        /// процент от прошлого периода
        /// </summary>
        public decimal AveragePercentSaleGoods
        {
            get { return _averagePercentSaleGoods; }
            set { SetValue(ref _averagePercentSaleGoods, value, "AveragePercentSaleGoods"); }
        }
        private decimal _averagePercentSaleGoods;

        /// <summary>
        /// + сумм от прошлого периода
        /// </summary>
        public decimal AverageSummSaleGoods
        {
            get { return _averageSummSaleGoods; }
            set { SetValue(ref _averageSummSaleGoods, value, "AverageSummSaleGoods"); }
        }
        private decimal _averageSummSaleGoods;
        

        /// <summary>
        /// макс оплаты в месяц за период
        /// </summary>
        public decimal maxCountPaymentBuyer
        {
            get { return _maxCountPaymentBuyer; }
            set { SetValue(ref _maxCountPaymentBuyer, value, "maxCountPaymentBuyer"); }
        }
        private decimal _maxCountPaymentBuyer;

        /// <summary>
        /// месяц за который были макс оплат за период
        /// </summary>
        public string MonthOfMaxCountPaymentBuyer
        {
            get { return _monthOfMaxCountPaymentBuyer; }
            set { SetValue(ref _monthOfMaxCountPaymentBuyer, value, "MonthOfMaxCountPaymentBuyer"); }
        }
        private string _monthOfMaxCountPaymentBuyer;

        /// <summary>
        /// средние оплаты в месяц за период
        /// </summary>
        public decimal maxAverageCountPaymentBuyer
        {
            get { return _maxAverageCountPaymentBuyer; }
            set { SetValue(ref _maxAverageCountPaymentBuyer, value, "maxAverageCountPaymentBuyer"); }
        }
        private decimal _maxAverageCountPaymentBuyer;

        /// <summary>
        /// сумма оплат
        /// </summary>
        public decimal SummPaymentBuyer
        {
            get { return _summPaymentBuyer; }
            set { SetValue(ref _summPaymentBuyer, value, "SummPaymentBuyer"); }
        }
        private decimal _summPaymentBuyer;

        /// <summary>
        /// процент от прошлого периода
        /// </summary>
        public decimal AveragePercentPaymentBuyer
        {
            get { return _averagePercentPaymentBuyer; }
            set { SetValue(ref _averagePercentPaymentBuyer, value, "AveragePercentPaymentBuyer"); }
        }
        private decimal _averagePercentPaymentBuyer;

        /// <summary>
        /// + сумм от прошлого периода
        /// </summary>
        public decimal AverageSummPaymentBuyer
        {
            get { return _averageSummPaymentBuyer; }
            set { SetValue(ref _averageSummPaymentBuyer, value, "AverageSummPaymentBuyer"); }
        }
        private decimal _averageSummPaymentBuyer;
        
        /// <summary>
        /// продажи - диаграмма продаж и оплат
        /// </summary>
        public Dictionary<string, decimal> DynamicsSalesDiagram
        {
            get { return _dynamicsSalesDiagram; }
            set { SetValue(ref _dynamicsSalesDiagram, value, "DynamicsSalesDiagram"); }
        }
        private Dictionary<string, decimal> _dynamicsSalesDiagram;

        /// <summary>
        /// Оплаты - диаграмма продаж и оплат
        /// </summary>
        public Dictionary<string, decimal> DynamicsPaymentDiagram
        {
            get { return _dynamicsPaymentDiagram; }
            set { SetValue(ref _dynamicsPaymentDiagram, value, "DynamicsPaymentDiagram"); }
        }
        private Dictionary<string, decimal> _dynamicsPaymentDiagram;
                
        /// <summary>
        /// Продажи по клиентам
        /// </summary>
        public Dictionary<string, decimal> StructureGrossProfitClientDiagram
        {
            get { return _structureGrossProfitClientDiagram; }
            set { SetValue(ref _structureGrossProfitClientDiagram, value, "StructureGrossProfitClientDiagram"); }
        }
        private Dictionary<string, decimal> _structureGrossProfitClientDiagram;

        /// <summary>
        /// продажи по клиентам + продажи + оплаты
        /// </summary>
        public List<FillModel> StructureGrossProfitClientInfo
        {
            get { return _structureGrossProfitClientInfo; }
            set { SetValue(ref _structureGrossProfitClientInfo, value, "StructureGrossProfitClientInfo"); }
        }
        private List<FillModel> _structureGrossProfitClientInfo;


        ///// <summary>
        ///// продажи по видам товара
        ///// </summary>
        //public Dictionary<string, decimal> DynamicsSalesDiagram
        //{
        //    get { return _dynamicsSalesDiagram; }
        //    set { SetValue(ref _dynamicsSalesDiagram, value, "DynamicsSalesDiagram"); }
        //}
        //private Dictionary<string, decimal> _dynamicsSalesDiagram;

        ///// <summary>
        ///// Оплаты - диаграмма продаж и оплат
        ///// </summary>
        //public Dictionary<string, decimal> DynamicsPaymentDiagram
        //{
        //    get { return _dynamicsPaymentDiagram; }
        //    set { SetValue(ref _dynamicsPaymentDiagram, value, "DynamicsPaymentDiagram"); }
        //}
        //private Dictionary<string, decimal> _dynamicsPaymentDiagram;


    }
}
