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
        private decimal _maxCountSaleGoods = 0;

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
        public decimal DifPercentSaleGoods
        {
            get { return _difPercentSaleGoods; }
            set { SetValue(ref _difPercentSaleGoods, value, "DifPercentSaleGoods"); }
        }
        private decimal _difPercentSaleGoods;

        /// <summary>
        /// + сумм от прошлого периода
        /// </summary>
        public decimal DifSummSaleGoods
        {
            get { return _difSummSaleGoods; }
            set { SetValue(ref _difSummSaleGoods, value, "DifSummSaleGoods"); }
        }
        private decimal _difSummSaleGoods;
        

        /// <summary>
        /// макс оплаты в месяц за период
        /// </summary>
        public decimal maxCountPaymentBuyer
        {
            get { return _maxCountPaymentBuyer; }
            set { SetValue(ref _maxCountPaymentBuyer, value, "maxCountPaymentBuyer"); }
        }
        private decimal _maxCountPaymentBuyer = 0;

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
        public decimal DifPercentPaymentBuyer
        {
            get { return _difPercentPaymentBuyer; }
            set { SetValue(ref _difPercentPaymentBuyer, value, "DifPercentPaymentBuyer"); }
        }
        private decimal _difPercentPaymentBuyer;

        /// <summary>
        /// + сумм от прошлого периода
        /// </summary>
        public decimal DifSummPaymentBuyer
        {
            get { return _difSummPaymentBuyer; }
            set { SetValue(ref _difSummPaymentBuyer, value, "DifSummPaymentBuyer"); }
        }
        private decimal _difSummPaymentBuyer;
        
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

        /// <summary>
        /// товар1 - продажи по видам товара
        /// </summary>
        public Dictionary<string, decimal> Goods1Diagram
        {
            get { return _doods1Diagram; }
            set { SetValue(ref _doods1Diagram, value, "Goods1Diagram"); }
        }
        private Dictionary<string, decimal> _doods1Diagram;

        /// <summary>
        /// товар2 - продажи по видам товара
        /// </summary>
        public Dictionary<string, decimal> Goods2Diagram
        {
            get { return _doods2Diagram; }
            set { SetValue(ref _doods2Diagram, value, "Goods2Diagram"); }
        }
        private Dictionary<string, decimal> _doods2Diagram;
        
        /// <summary>
        /// товар3 - продажи по видам товара
        /// </summary>
        public Dictionary<string, decimal> Goods3Diagram
        {
            get { return _doods3Diagram; }
            set { SetValue(ref _doods3Diagram, value, "Goods3Diagram"); }
        }
        private Dictionary<string, decimal> _doods3Diagram;

        /// <summary>
        /// товар1 - инфо
        /// </summary>
        public FillGoodsModel Goods1Info
        {
            get { return _goods1Info; }
            set { SetValue(ref _goods1Info, value, "Goods1Info"); }
        }
        private FillGoodsModel _goods1Info;

        /// <summary>
        /// товар2 - инфо
        /// </summary>
        public FillGoodsModel Goods2Info
        {
            get { return _goods2Info; }
            set { SetValue(ref _goods2Info, value, "Goods2Info"); }
        }
        private FillGoodsModel _goods2Info;

        /// <summary>
        /// товар3 - инфо
        /// </summary>
        public FillGoodsModel Goods3Info
        {
            get { return _goods3Info; }
            set { SetValue(ref _goods3Info, value, "Goods3Info"); }
        }
        private FillGoodsModel _goods3Info;


    }
}
